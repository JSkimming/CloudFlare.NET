namespace CloudFlare.NET
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading;
    using System.Threading.Tasks;

    /// <inheritdoc/>
    public partial class CloudFlareClient : IZoneClient
    {
        /// <inheritdoc/>
        public Task<CloudFlareResponse<IReadOnlyList<Zone>>> GetZonesAsync(
            CancellationToken cancellationToken,
            ZoneGetParameters parameters = null,
            CloudFlareAuth auth = null)
        {
            return _client.GetZonesAsync(cancellationToken, auth ?? _auth, parameters);
        }

        /// <inheritdoc/>
        public Task<IEnumerable<Zone>> GetAllZonesAsync(
            CancellationToken cancellationToken,
            ZoneGetParameters parameters = null,
            CloudFlareAuth auth = null)
        {
            return GetAllPagedResultsAsync<Zone, ZoneGetParameters, ZoneOrderTypes>(
                _client.GetZonesAsync,
                cancellationToken,
                auth ?? _auth,
                50,
                parameters);
        }

        /// <inheritdoc/>
        public Task<Zone> GetZoneAsync(
            IdentifierTag zoneId,
            CancellationToken cancellationToken,
            CloudFlareAuth auth = null)
        {
            return _client.GetZoneAsync(zoneId, cancellationToken, auth ?? _auth);
        }
    }
}
