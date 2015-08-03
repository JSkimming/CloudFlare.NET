namespace CloudFlare.NET
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Net.Http;
    using System.Threading;
    using System.Threading.Tasks;

    /// <summary>
    /// Extension methods on <see cref="HttpClient"/> to wrap the Zone APIs
    /// </summary>
    /// <seealso href="https://api.cloudflare.com/#zone-properties"/>
    public static class HttpClientZoneExtensions
    {
        /// <summary>
        /// Gets the base address of the CloudFlare API.
        /// </summary>
        public static Uri ZonesUri { get; } = new Uri(CloudFlareConstants.BaseUri, "zones");

        /// <summary>
        /// Gets the zones for the account specified by the <paramref name="auth"/> details.
        /// </summary>
        /// <returns>The zones for the subscription.</returns>
        public static async Task<IReadOnlyList<Zone>> GetZonesAsync(
            this HttpClient client,
            CloudFlareAuth auth,
            CancellationToken cancellationToken)
        {
            if (client == null)
                throw new ArgumentNullException(nameof(client));
            if (auth == null)
                throw new ArgumentNullException(nameof(auth));

            var request = new HttpRequestMessage(HttpMethod.Get, ZonesUri);
            request.Headers.Add("X-Auth-Key", auth.Key);
            request.Headers.Add("X-Auth-Email", auth.Email);

            HttpResponseMessage response =
                await client.SendAsync(request, HttpCompletionOption.ResponseHeadersRead, cancellationToken)
                    .ConfigureAwait(false);

            if (response.IsSuccessStatusCode)
            {
                var result = await response
                    .Content
                    .ReadAsAsync<CloudFlareResponse<IReadOnlyList<Zone>>>(cancellationToken)
                    .ConfigureAwait(false);

                return result.Result;
            }

            var errorResult = await response
                .Content
                .ReadAsAsync<CloudFlareResponseBase>(cancellationToken)
                .ConfigureAwait(false);

            // TODO: Do some nice error handling.
            throw new Exception("It's Not so good and stuff.");
        }
    }
}
