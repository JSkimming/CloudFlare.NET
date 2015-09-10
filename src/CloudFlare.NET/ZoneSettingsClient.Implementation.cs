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

        /// <inheritdoc/>
        public Task<ZoneSetting<SettingOnOffTypes>> GetAdvancedDdosSettingAsync(
            IdentifierTag zoneId,
            CancellationToken cancellationToken,
            CloudFlareAuth auth = null)
        {
            return _client.GetAdvancedDdosSettingAsync(zoneId, cancellationToken, auth ?? _auth);
        }

        /// <inheritdoc/>
        public Task<ZoneSetting<SettingOnOffTypes>> GetAlwaysOnlineSettingAsync(
            IdentifierTag zoneId,
            CancellationToken cancellationToken,
            CloudFlareAuth auth = null)
        {
            return _client.GetAlwaysOnlineSettingAsync(zoneId, cancellationToken, auth ?? _auth);
        }

        /// <inheritdoc/>
        public Task<ZoneSetting<int>> GetBrowserCacheTtlSettingAsync(
            IdentifierTag zoneId,
            CancellationToken cancellationToken,
            CloudFlareAuth auth = null)
        {
            return _client.GetBrowserCacheTtlSettingAsync(zoneId, cancellationToken, auth ?? _auth);
        }

        /// <inheritdoc/>
        public Task<ZoneSetting<SettingOnOffTypes>> GetBrowserCheckSettingAsync(
            IdentifierTag zoneId,
            CancellationToken cancellationToken,
            CloudFlareAuth auth = null)
        {
            return _client.GetBrowserCheckSettingAsync(zoneId, cancellationToken, auth ?? _auth);
        }
    }
}
