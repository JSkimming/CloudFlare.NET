namespace CloudFlare.NET
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading;
    using System.Threading.Tasks;

    /// <summary>
    /// Helper extension methods on <see cref="IZoneClient"/>.
    /// </summary>
    public static class ZoneClientExtensions
    {
        /// <summary>
        /// Gets the zones for the subscription.
        /// </summary>
        /// <seealso href="https://api.cloudflare.com/#zone-list-zones"/>
        public static Task<IReadOnlyList<Zone>> GetZonesAsync(this IZoneClient client, CloudFlareAuth auth = null)
        {
            if (client == null)
                throw new ArgumentNullException(nameof(client));

            return client.GetZonesAsync(CancellationToken.None, auth);
        }

        /// <summary>
        /// Gets the zones for the subscription.
        /// </summary>
        /// <seealso href="https://api.cloudflare.com/#zone-zone-details"/>
        public static Task<Zone> GetZoneAsync(
            this IZoneClient client,
            IdentifierTag zoneId,
            CloudFlareAuth auth = null)
        {
            if (zoneId == null)
                throw new ArgumentNullException(nameof(zoneId));
            if (client == null)
                throw new ArgumentNullException(nameof(client));

            return client.GetZoneAsync(zoneId, CancellationToken.None, auth);
        }
    }
}
