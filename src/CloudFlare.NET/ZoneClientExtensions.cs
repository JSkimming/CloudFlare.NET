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
        /// <returns>The zones for the subscription.</returns>
        public static Task<IReadOnlyList<Zone>> GetZonesAsync(this IZoneClient client, CloudFlareAuth auth = null)
        {
            if (client == null)
                throw new ArgumentNullException(nameof(client));

            return client.GetZonesAsync(CancellationToken.None, auth);
        }
    }
}
