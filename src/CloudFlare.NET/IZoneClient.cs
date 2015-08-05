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
        /// <returns>The zones for the subscription.</returns>
        Task<IReadOnlyList<Zone>> GetZonesAsync(CancellationToken cancellationToken, CloudFlareAuth auth = null);
    }
}
