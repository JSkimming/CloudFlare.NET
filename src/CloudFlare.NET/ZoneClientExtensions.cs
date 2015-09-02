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
        public static Task<CloudFlareResponse<IReadOnlyList<Zone>>> GetZonesAsync(
            this IZoneClient client,
            PagedZoneParameters parameters = null)
        {
            if (client == null)
                throw new ArgumentNullException(nameof(client));

            return client.GetZonesAsync(CancellationToken.None, parameters);
        }

        /// <summary>
        /// Gets the zones for the subscription.
        /// </summary>
        /// <seealso href="https://api.cloudflare.com/#zone-list-zones"/>
        public static Task<CloudFlareResponse<IReadOnlyList<Zone>>> GetZonesAsync(
            this IZoneClient client,
            CloudFlareAuth auth,
            PagedZoneParameters parameters = null)
        {
            if (client == null)
                throw new ArgumentNullException(nameof(client));
            if (auth == null)
                throw new ArgumentNullException(nameof(auth));

            return client.GetZonesAsync(CancellationToken.None, parameters, auth);
        }

        /// <summary>
        /// Gets the zones for the subscription.
        /// </summary>
        /// <seealso href="https://api.cloudflare.com/#zone-list-zones"/>
        public static Task<IEnumerable<Zone>> GetAllZonesAsync(
            this IZoneClient client,
            PagedZoneParameters parameters = null)
        {
            if (client == null)
                throw new ArgumentNullException(nameof(client));

            return client.GetAllZonesAsync(CancellationToken.None, parameters);
        }

        /// <summary>
        /// Gets the zones for the subscription.
        /// </summary>
        /// <seealso href="https://api.cloudflare.com/#zone-list-zones"/>
        public static Task<IEnumerable<Zone>> GetAllZonesAsync(
            this IZoneClient client,
            CloudFlareAuth auth,
            PagedZoneParameters parameters = null)
        {
            if (client == null)
                throw new ArgumentNullException(nameof(client));
            if (auth == null)
                throw new ArgumentNullException(nameof(auth));

            return client.GetAllZonesAsync(CancellationToken.None, parameters, auth);
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
