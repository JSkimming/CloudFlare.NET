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
        /// Gets the base address of the CloudFlare API.
        /// </summary>
        public static Uri ZonesUri { get; } = new Uri(CloudFlareConstants.BaseUri, "zones");

        /// <summary>
        /// Gets the <see cref="CloudFlareResponse{T}"/> of a CloudFlare API <paramref name="response"/>.
        /// </summary>
        /// <typeparam name="T">The type of the <see cref="CloudFlareResponse{T}.Result"/>.</typeparam>
        public static async Task<CloudFlareResponse<T>> GetResultAsync<T>(
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
    }
}
