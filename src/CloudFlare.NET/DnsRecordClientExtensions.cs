﻿namespace CloudFlare.NET
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading;
    using System.Threading.Tasks;

    /// <summary>
    /// Helper extension methods on <see cref="IDnsRecordClient"/>.
    /// </summary>
    public static class DnsRecordClientExtensions
    {
        /// <summary>
        /// Gets the zones for the subscription.
        /// </summary>
        /// <seealso href="https://api.cloudflare.com/#dns-records-for-a-zone-list-dns-records"/>
        public static Task<IReadOnlyList<DnsRecord>> GetDnsRecordsAsync(
            this IDnsRecordClient client,
            IdentifierTag zoneId,
            PagedDnsRecordParameters parameters = null)
        {
            if (client == null)
                throw new ArgumentNullException(nameof(client));
            if (zoneId == null)
                throw new ArgumentNullException(nameof(zoneId));

            return client.GetDnsRecordsAsync(zoneId, CancellationToken.None, parameters);
        }

        /// <summary>
        /// Gets the zones for the subscription.
        /// </summary>
        /// <seealso href="https://api.cloudflare.com/#dns-records-for-a-zone-list-dns-records"/>
        public static Task<IReadOnlyList<DnsRecord>> GetDnsRecordsAsync(
            this IDnsRecordClient client,
            IdentifierTag zoneId,
            CloudFlareAuth auth,
            PagedDnsRecordParameters parameters = null)
        {
            if (client == null)
                throw new ArgumentNullException(nameof(client));
            if (zoneId == null)
                throw new ArgumentNullException(nameof(zoneId));
            if (auth == null)
                throw new ArgumentNullException(nameof(auth));

            return client.GetDnsRecordsAsync(zoneId, CancellationToken.None, parameters, auth);
        }
    }
}
