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
    /// <seealso href="https://api.cloudflare.com/#zone"/>
    public static class HttpClientZoneExtensions
    {
        /// <summary>
        /// Gets the zones for the account specified by the <paramref name="auth"/> details.
        /// </summary>
        /// <seealso href="https://api.cloudflare.com/#zone-list-zones"/>
        public static async Task<IReadOnlyList<Zone>> GetZonesAsync(
            this HttpClient client,
            CancellationToken cancellationToken,
            CloudFlareAuth auth,
            PagedZoneParameters parameters = null)
        {
            if (client == null)
                throw new ArgumentNullException(nameof(client));
            if (auth == null)
                throw new ArgumentNullException(nameof(auth));

            Uri uri = new Uri(CloudFlareConstants.BaseUri, "zones");
            if (parameters != null)
            {
                uri = new UriBuilder(uri) { Query = parameters.ToQuery() }.Uri;
            }

            var request = new HttpRequestMessage(HttpMethod.Get, uri);
            request.AddAuth(auth);

            HttpResponseMessage response =
                await client.SendAsync(request, HttpCompletionOption.ResponseHeadersRead, cancellationToken)
                    .ConfigureAwait(false);

            return (await response
                .GetResultAsync<IReadOnlyList<Zone>>(cancellationToken)
                .ConfigureAwait(false))
                .Result;
        }

        /// <summary>
        /// Gets the zones for the account specified by the <paramref name="auth"/> details.
        /// </summary>
        /// <seealso href="https://api.cloudflare.com/#zone-zone-details"/>
        public static async Task<Zone> GetZoneAsync(
            this HttpClient client,
            IdentifierTag zoneId,
            CancellationToken cancellationToken,
            CloudFlareAuth auth)
        {
            if (client == null)
                throw new ArgumentNullException(nameof(client));
            if (zoneId == null)
                throw new ArgumentNullException(nameof(zoneId));
            if (auth == null)
                throw new ArgumentNullException(nameof(auth));

            Uri uri = new Uri(CloudFlareConstants.BaseUri, $"zones/{zoneId}");
            var request = new HttpRequestMessage(HttpMethod.Get, uri);
            request.AddAuth(auth);

            HttpResponseMessage response =
                await client.SendAsync(request, HttpCompletionOption.ResponseHeadersRead, cancellationToken)
                    .ConfigureAwait(false);

            return (await response
                .GetResultAsync<Zone>(cancellationToken)
                .ConfigureAwait(false))
                .Result;
        }
    }
}
