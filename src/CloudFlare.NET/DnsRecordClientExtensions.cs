namespace CloudFlare.NET
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
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
        /// <returns>The zones for the subscription.</returns>
        public static Task<IReadOnlyList<DnsRecord>> GetDnsRecordsAsync(
            this IDnsRecordClient client,
            IdentifierTag zoneId,
            CloudFlareAuth auth = null)
        {
            if (client == null)
                throw new ArgumentNullException(nameof(client));
            if (zoneId == null)
                throw new ArgumentNullException(nameof(zoneId));

            return client.GetDnsRecordsAsync(zoneId, CancellationToken.None, auth);
        }
    }
}
