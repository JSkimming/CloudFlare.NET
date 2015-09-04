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
    public static class ZoneHttpClientExtensions
    {
        /// <summary>
        /// Gets the zones for the account specified by the <paramref name="auth"/> details.
        /// </summary>
        /// <seealso href="https://api.cloudflare.com/#zone-list-zones"/>
        public static Task<CloudFlareResponse<IReadOnlyList<Zone>>> GetZonesAsync(
            this HttpClient client,
            CancellationToken cancellationToken,
            CloudFlareAuth auth,
            ZoneGetParameters parameters = null)
        {
            Uri uri = new Uri(CloudFlareConstants.BaseUri, "zones");
            if (parameters != null)
            {
                uri = new UriBuilder(uri) { Query = parameters.ToQuery() }.Uri;
            }

            return client.GetCloudFlareResponseAsync<IReadOnlyList<Zone>>(uri, auth, cancellationToken);
        }

        /// <summary>
        /// Gets the zones for the account specified by the <paramref name="auth"/> details.
        /// </summary>
        /// <seealso href="https://api.cloudflare.com/#zone-zone-details"/>
        public static Task<Zone> GetZoneAsync(
            this HttpClient client,
            IdentifierTag zoneId,
            CancellationToken cancellationToken,
            CloudFlareAuth auth)
        {
            if (zoneId == null)
                throw new ArgumentNullException(nameof(zoneId));

            Uri uri = new Uri(CloudFlareConstants.BaseUri, $"zones/{zoneId}");
            return client.GetCloudFlareResultAsync<Zone>(uri, auth, cancellationToken);
        }
    }
}
