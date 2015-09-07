namespace CloudFlare.NET
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading;
    using System.Threading.Tasks;

    /// <inheritdoc/>
    public partial class CloudFlareClient : IZoneSettingsClient
    {
        /// <inheritdoc/>
        public Task<IEnumerable<ZoneSettingBase>> GetAllZoneSettingsAsync(
            IdentifierTag zoneId,
            CancellationToken cancellationToken,
            CloudFlareAuth auth = null)
        {
            return _client.GetAllZoneSettingsAsync(zoneId, cancellationToken, auth ?? _auth);
        }
    }
}
