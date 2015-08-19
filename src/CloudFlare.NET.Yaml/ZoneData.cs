namespace CloudFlare.NET
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    /// <summary>
    /// Represents the complete data of a <see cref="Zone"/>.
    /// </summary>
    public class ZoneData
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ZoneData"/> class.
        /// </summary>
        public ZoneData(Zone zone, IReadOnlyList<DnsRecord> dnsRecords)
        {
            if (zone == null)
                throw new ArgumentNullException(nameof(zone));
            if (dnsRecords == null)
                throw new ArgumentNullException(nameof(dnsRecords));

            Zone = zone;
            DnsRecords = dnsRecords;
        }

        /// <summary>
        /// Gets the <see cref="Zone"/>.
        /// </summary>
        public Zone Zone { get; }

        /// <summary>
        /// Gets the DNS records.
        /// </summary>
        public IReadOnlyList<DnsRecord> DnsRecords { get; }
    }
}
