namespace CloudFlare.NET
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading;
    using System.Threading.Tasks;

    /// <summary>
    /// The CloudFlare DNS records for a zone API Client.
    /// </summary>
    /// <seealso href="https://api.cloudflare.com/#dns-records-for-a-zone"/>
    public interface IDnsRecordClient
    {
        /// <summary>
        /// Gets the DNS records for the zone with the specified <paramref name="zoneId"/>.
        /// </summary>
        /// <seealso href="https://api.cloudflare.com/#dns-records-for-a-zone-list-dns-records"/>
        Task<CloudFlareResponse<IReadOnlyList<DnsRecord>>> GetDnsRecordsAsync(
            IdentifierTag zoneId,
            CancellationToken cancellationToken,
            DnsRecordGetParameters parameters = null,
            CloudFlareAuth auth = null);

        /// <summary>
        /// Gets all the DNS records for the zone with the specified <paramref name="zoneId"/>. Making multiple paged
        /// requests if necessary.
        /// </summary>
        /// <seealso href="https://api.cloudflare.com/#dns-records-for-a-zone-list-dns-records"/>
        Task<IEnumerable<DnsRecord>> GetAllDnsRecordsAsync(
            IdentifierTag zoneId,
            CancellationToken cancellationToken,
            DnsRecordGetParameters parameters = null,
            CloudFlareAuth auth = null);
    }
}
