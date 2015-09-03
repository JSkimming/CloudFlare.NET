namespace CloudFlare.NET
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading;
    using System.Threading.Tasks;

    /// <summary>
    /// Helper extension methods on <see cref="ICloudFlareClient"/>.
    /// </summary>
    public static class CloudFlareClientExtensions
    {
        /// <summary>
        /// Gets the all the zone data.
        /// </summary>
        public static Task<ZoneData> GetZoneDataAsync(
            this ICloudFlareClient client,
            IdentifierTag zoneId,
            CloudFlareAuth auth = null)
        {
            return client.GetZoneDataAsync(zoneId, CancellationToken.None, auth);
        }

        /// <summary>
        /// Gets the all the zone data.
        /// </summary>
        public static async Task<ZoneData> GetZoneDataAsync(
            this ICloudFlareClient client,
            IdentifierTag zoneId,
            CancellationToken cancellationToken,
            CloudFlareAuth auth = null)
        {
            if (client == null)
                throw new ArgumentNullException(nameof(client));
            if (zoneId == null)
                throw new ArgumentNullException(nameof(zoneId));

            Task<Zone> zoneTask = client.GetZoneAsync(zoneId, cancellationToken, auth);
            Task<IEnumerable<DnsRecord>> dnsRecordsTask =
                client.GetAllDnsRecordsAsync(zoneId, cancellationToken, auth: auth);

            await Task.WhenAll(zoneTask, dnsRecordsTask).ConfigureAwait(false);

            return new ZoneData(zoneTask.Result, dnsRecordsTask.Result.ToArray());
        }
    }
}
