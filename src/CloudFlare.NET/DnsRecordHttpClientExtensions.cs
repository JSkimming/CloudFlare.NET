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
    /// <seealso href="https://api.cloudflare.com/#dns-records-for-a-zone"/>
    public static class DnsRecordHttpClientExtensions
    {
        /// <summary>
        /// Gets the DNS records for the zone with the specified <paramref name="zoneId"/>.
        /// </summary>
        /// <seealso href="https://api.cloudflare.com/#dns-records-for-a-zone-list-dns-records"/>
        public static Task<CloudFlareResponse<IReadOnlyList<DnsRecord>>> GetDnsRecordsAsync(
            this HttpClient client,
            IdentifierTag zoneId,
            CancellationToken cancellationToken,
            CloudFlareAuth auth,
            DnsRecordGetParameters parameters = null)
        {
            if (zoneId == null)
                throw new ArgumentNullException(nameof(zoneId));

            Uri uri = new Uri(CloudFlareConstants.BaseUri, $"zones/{zoneId}/dns_records");
            if (parameters != null)
            {
                uri = new UriBuilder(uri) { Query = parameters.ToQuery() }.Uri;
            }

            return client.GetCloudFlareResponseAsync<IReadOnlyList<DnsRecord>>(uri, auth, cancellationToken);
        }
    }
}
