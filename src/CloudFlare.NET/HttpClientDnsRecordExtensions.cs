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
    public static class HttpClientDnsRecordExtensions
    {
        /// <summary>
        /// Gets the zones for the account specified by the <paramref name="auth"/> details.
        /// </summary>
        /// <seealso href="https://api.cloudflare.com/#dns-records-for-a-zone-list-dns-records"/>
        public static Task<IReadOnlyList<DnsRecord>> GetDnsRecordsAsync(
            this HttpClient client,
            IdentifierTag zoneId,
            CancellationToken cancellationToken,
            CloudFlareAuth auth,
            PagedDnsRecordParameters parameters = null)
        {
            if (zoneId == null)
                throw new ArgumentNullException(nameof(zoneId));

            Uri uri = new Uri(CloudFlareConstants.BaseUri, $"zones/{zoneId}/dns_records");
            if (parameters != null)
            {
                uri = new UriBuilder(uri) { Query = parameters.ToQuery() }.Uri;
            }

            return client.GetCloudFlareResultAsync<IReadOnlyList<DnsRecord>>(uri, auth, cancellationToken);
        }
    }
}
