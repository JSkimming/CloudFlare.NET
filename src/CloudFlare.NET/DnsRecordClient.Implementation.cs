namespace CloudFlare.NET
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading;
    using System.Threading.Tasks;

    /// <inheritdoc/>
    public partial class CloudFlareClient : IDnsRecordClient
    {
        /// <inheritdoc/>
        public Task<CloudFlareResponse<IReadOnlyList<DnsRecord>>> GetDnsRecordsAsync(
            IdentifierTag zoneId,
            CancellationToken cancellationToken,
            DnsRecordGetParameters parameters = null,
            CloudFlareAuth auth = null)
        {
            return _client.GetDnsRecordsAsync(zoneId, cancellationToken, auth ?? _auth, parameters);
        }

        /// <inheritdoc/>
        public Task<IEnumerable<DnsRecord>> GetAllDnsRecordsAsync(
            IdentifierTag zoneId,
            CancellationToken cancellationToken,
            DnsRecordGetParameters parameters = null,
            CloudFlareAuth auth = null)
        {
            if (zoneId == null)
                throw new ArgumentNullException(nameof(zoneId));

            return GetAllPagedResultsAsync<DnsRecord, DnsRecordGetParameters, DnsRecordOrderTypes>(
                (ct, a, p) => _client.GetDnsRecordsAsync(zoneId, ct, a, p),
                cancellationToken,
                auth ?? _auth,
                100,
                parameters);
        }
    }
}
