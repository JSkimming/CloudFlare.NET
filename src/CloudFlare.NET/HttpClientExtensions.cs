namespace CloudFlare.NET
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Net.Http;
    using System.Threading;
    using System.Threading.Tasks;

    /// <summary>
    /// Extension methods on <see cref="HttpClient"/> to wrap the CloudFlare APIs
    /// </summary>
    /// <seealso href="https://api.cloudflare.com"/>
    public static class HttpClientExtensions
    {
        /// <summary>
        /// Gets the <see cref="CloudFlareResponse{T}"/> of a CloudFlare API <paramref name="response"/>.
        /// </summary>
        /// <typeparam name="T">The type of the <see cref="CloudFlareResponse{T}.Result"/>.</typeparam>
        public static async Task<CloudFlareResponse<T>> ReadCloudFlareResponseAsync<T>(
            this HttpResponseMessage response,
            CancellationToken cancellationToken)
            where T : class
        {
            if (response == null)
                throw new ArgumentNullException(nameof(response));

            if (response.IsSuccessStatusCode)
            {
                return await response
                    .Content
                    .ReadAsAsync<CloudFlareResponse<T>>(cancellationToken)
                    .ConfigureAwait(false);
            }

            CloudFlareResponseBase errorResponse =
                await response
                    .Content
                    .ReadAsAsync<CloudFlareResponseBase>(cancellationToken)
                    .ConfigureAwait(false);

            throw new CloudFlareException(errorResponse, response);
        }

        /// <summary>
        /// Adds the authentication headers to the <paramref name="request"/>.
        /// </summary>
        public static void AddAuth(this HttpRequestMessage request, CloudFlareAuth auth)
        {
            if (request == null)
                throw new ArgumentNullException(nameof(request));
            if (auth == null)
                throw new ArgumentNullException(nameof(auth));

            request.Headers.Add("X-Auth-Key", auth.Key);
            request.Headers.Add("X-Auth-Email", auth.Email);
        }

        /// <summary>
        /// Executes a <see cref="HttpMethod.Get"/> request returning the <see cref="CloudFlareResponse{T}"/>.
        /// </summary>
        /// <typeparam name="T">The type of the <see cref="CloudFlareResponse{T}.Result"/>.</typeparam>
        public static async Task<CloudFlareResponse<T>> GetCloudFlareResponseAsync<T>(
            this HttpClient client,
            Uri uri,
            CloudFlareAuth auth,
            CancellationToken cancellationToken)
            where T : class
        {
            if (client == null)
                throw new ArgumentNullException(nameof(client));
            if (uri == null)
                throw new ArgumentNullException(nameof(uri));
            if (auth == null)
                throw new ArgumentNullException(nameof(auth));

            using (var request = new HttpRequestMessage(HttpMethod.Get, uri))
            {
                request.AddAuth(auth);

                HttpResponseMessage response =
                    await client.SendAsync(request, HttpCompletionOption.ResponseHeadersRead, cancellationToken)
                        .ConfigureAwait(false);
                using (response)
                {
                    CloudFlareResponse<T> cloudFlareResponse =
                        await response.ReadCloudFlareResponseAsync<T>(cancellationToken).ConfigureAwait(false);
                    return cloudFlareResponse;
                }
            }
        }

        /// <summary>
        /// Executes a <see cref="HttpMethod.Get"/> request returning the type specified by <typeparamref name="T"/>.
        /// </summary>
        /// <typeparam name="T">The type of the <see cref="CloudFlareResponse{T}.Result"/>.</typeparam>
        public static async Task<T> GetCloudFlareResultAsync<T>(
            this HttpClient client,
            Uri uri,
            CloudFlareAuth auth,
            CancellationToken cancellationToken)
            where T : class
        {
            CloudFlareResponse<T> cloudFlareResponse =
                await client.GetCloudFlareResponseAsync<T>(uri, auth, cancellationToken);

            return cloudFlareResponse.Result;
        }
    }
}
