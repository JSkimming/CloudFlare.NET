namespace CloudFlare.NET
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading;
    using System.Threading.Tasks;

    /// <summary>
    /// The CloudFlare API Client.
    /// </summary>
    /// <seealso href="https://api.cloudflare.com/#zone"/>
    public interface IZoneClient
    {
        /// <summary>
        /// Gets the zones for the subscription.
        /// </summary>
        /// <seealso href="https://api.cloudflare.com/#zone-list-zones"/>
        Task<CloudFlareResponse<IReadOnlyList<Zone>>> GetZonesAsync(
            CancellationToken cancellationToken,
            PagedZoneParameters parameters = null,
            CloudFlareAuth auth = null);

        /// <summary>
        /// Gets the zone with the specified <paramref name="zoneId"/>.
        /// </summary>
        /// <seealso href="https://api.cloudflare.com/#zone-zone-details"/>
        Task<Zone> GetZoneAsync(IdentifierTag zoneId, CancellationToken cancellationToken, CloudFlareAuth auth);
    }
}
