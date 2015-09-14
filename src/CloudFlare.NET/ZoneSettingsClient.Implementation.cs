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

        /// <inheritdoc/>
        public Task<ZoneSetting<SettingCacheLevelTypes>> GetCacheLevelSettingAsync(
            IdentifierTag zoneId,
            CancellationToken cancellationToken,
            CloudFlareAuth auth = null)
        {
            return _client.GetCacheLevelSettingAsync(zoneId, cancellationToken, auth ?? _auth);
        }

        /// <inheritdoc/>
        public Task<ZoneSetting<int>> GetChallengeTtlSettingAsync(
            IdentifierTag zoneId,
            CancellationToken cancellationToken,
            CloudFlareAuth auth = null)
        {
            return _client.GetChallengeTtlSettingAsync(zoneId, cancellationToken, auth ?? _auth);
        }

        /// <inheritdoc/>
        public Task<ZoneDevelopmentModeSetting> GetDevelopmentModeSettingAsync(
            IdentifierTag zoneId,
            CancellationToken cancellationToken,
            CloudFlareAuth auth = null)
        {
            return _client.GetDevelopmentModeSettingAsync(zoneId, cancellationToken, auth ?? _auth);
        }

        /// <inheritdoc/>
        public Task<ZoneSetting<SettingOnOffTypes>> GetEmailObfuscationSettingAsync(
            IdentifierTag zoneId,
            CancellationToken cancellationToken,
            CloudFlareAuth auth = null)
        {
            return _client.GetEmailObfuscationSettingAsync(zoneId, cancellationToken, auth ?? _auth);
        }

        /// <inheritdoc/>
        public Task<ZoneSetting<SettingOnOffTypes>> GetHotlinkProtectionSettingAsync(
            IdentifierTag zoneId,
            CancellationToken cancellationToken,
            CloudFlareAuth auth = null)
        {
            return _client.GetHotlinkProtectionSettingAsync(zoneId, cancellationToken, auth ?? _auth);
        }

        /// <inheritdoc/>
        public Task<ZoneSetting<SettingOnOffTypes>> GetIpGeolocationSettingAsync(
            IdentifierTag zoneId,
            CancellationToken cancellationToken,
            CloudFlareAuth auth = null)
        {
            return _client.GetIpGeolocationSettingAsync(zoneId, cancellationToken, auth ?? _auth);
        }

        /// <inheritdoc/>
        public Task<ZoneSetting<SettingIPv6Types>> GetIPv6SettingAsync(
            IdentifierTag zoneId,
            CancellationToken cancellationToken,
            CloudFlareAuth auth = null)
        {
            return _client.GetIPv6SettingAsync(zoneId, cancellationToken, auth ?? _auth);
        }

        /// <inheritdoc/>
        public Task<ZoneSetting<SettingMinify>> GetMinifySettingAsync(
            IdentifierTag zoneId,
            CancellationToken cancellationToken,
            CloudFlareAuth auth = null)
        {
            return _client.GetMinifySettingAsync(zoneId, cancellationToken, auth ?? _auth);
        }

        /// <inheritdoc/>
        public Task<ZoneSetting<SettingMobileRedirect>> GetMobileRedirectSettingAsync(
            IdentifierTag zoneId,
            CancellationToken cancellationToken,
            CloudFlareAuth auth = null)
        {
            return _client.GetMobileRedirectSettingAsync(zoneId, cancellationToken, auth ?? _auth);
        }

        /// <inheritdoc/>
        public Task<ZoneSetting<SettingOnOffTypes>> GetMirageSettingAsync(
            IdentifierTag zoneId,
            CancellationToken cancellationToken,
            CloudFlareAuth auth = null)
        {
            return _client.GetMirageSettingAsync(zoneId, cancellationToken, auth ?? _auth);
        }

        /// <inheritdoc/>
        public Task<ZoneSetting<SettingOnOffTypes>> GetEnableErrorPagesOnSettingAsync(
            IdentifierTag zoneId,
            CancellationToken cancellationToken,
            CloudFlareAuth auth = null)
        {
            return _client.GetEnableErrorPagesOnSettingAsync(zoneId, cancellationToken, auth ?? _auth);
        }

        /// <inheritdoc/>
        public Task<ZoneSetting<SettingPolishTypes>> GetPolishSettingAsync(
            IdentifierTag zoneId,
            CancellationToken cancellationToken,
            CloudFlareAuth auth = null)
        {
            return _client.GetPolishSettingAsync(zoneId, cancellationToken, auth ?? _auth);
        }

        /// <inheritdoc/>
        public Task<ZoneSetting<SettingOnOffTypes>> GetPrefetchPreloadSettingAsync(
            IdentifierTag zoneId,
            CancellationToken cancellationToken,
            CloudFlareAuth auth = null)
        {
            return _client.GetPrefetchPreloadSettingAsync(zoneId, cancellationToken, auth ?? _auth);
        }

        /// <inheritdoc/>
        public Task<ZoneSetting<SettingOnOffTypes>> GetResponseBufferingSettingAsync(
            IdentifierTag zoneId,
            CancellationToken cancellationToken,
            CloudFlareAuth auth = null)
        {
            return _client.GetResponseBufferingSettingAsync(zoneId, cancellationToken, auth ?? _auth);
        }

        /// <inheritdoc/>
        public Task<ZoneSetting<SettingRocketLoaderTypes>> GetRocketLoaderSettingAsync(
            IdentifierTag zoneId,
            CancellationToken cancellationToken,
            CloudFlareAuth auth = null)
        {
            return _client.GetRocketLoaderSettingAsync(zoneId, cancellationToken, auth ?? _auth);
        }

        /// <inheritdoc/>
        public Task<ZoneSetting<SettingSecurityHeader>> GetSecurityHeaderSettingAsync(
            IdentifierTag zoneId,
            CancellationToken cancellationToken,
            CloudFlareAuth auth = null)
        {
            return _client.GetSecurityHeaderSettingAsync(zoneId, cancellationToken, auth ?? _auth);
        }

        /// <inheritdoc/>
        public Task<ZoneSetting<SettingSecurityLevelTypes>> GetSecurityLevelSettingAsync(
            IdentifierTag zoneId,
            CancellationToken cancellationToken,
            CloudFlareAuth auth = null)
        {
            return _client.GetSecurityLevelSettingAsync(zoneId, cancellationToken, auth ?? _auth);
        }

        /// <inheritdoc/>
        public Task<ZoneSetting<SettingOnOffTypes>> GetServerSideExcludeSettingAsync(
            IdentifierTag zoneId,
            CancellationToken cancellationToken,
            CloudFlareAuth auth = null)
        {
            return _client.GetServerSideExcludeSettingAsync(zoneId, cancellationToken, auth ?? _auth);
        }

        /// <inheritdoc/>
        public Task<ZoneSetting<SettingOnOffTypes>> GetEnableQueryStringSortSettingAsync(
            IdentifierTag zoneId,
            CancellationToken cancellationToken,
            CloudFlareAuth auth = null)
        {
            return _client.GetEnableQueryStringSortSettingAsync(zoneId, cancellationToken, auth ?? _auth);
        }

        /// <inheritdoc/>
        public Task<ZoneSetting<SettingSslTypes>> GetSslSettingAsync(
            IdentifierTag zoneId,
            CancellationToken cancellationToken,
            CloudFlareAuth auth = null)
        {
            return _client.GetSslSettingAsync(zoneId, cancellationToken, auth ?? _auth);
        }

        /// <inheritdoc/>
        public Task<ZoneSetting<SettingOnOffTypes>> GetZoneEnableTls12SettingAsync(
            IdentifierTag zoneId,
            CancellationToken cancellationToken,
            CloudFlareAuth auth = null)
        {
            return _client.GetZoneEnableTls12SettingAsync(zoneId, cancellationToken, auth ?? _auth);
        }

        /// <inheritdoc/>
        public Task<ZoneSetting<SettingOnOffTypes>> GetTlsClientAuthSettingAsync(
            IdentifierTag zoneId,
            CancellationToken cancellationToken,
            CloudFlareAuth auth = null)
        {
            return _client.GetTlsClientAuthSettingAsync(zoneId, cancellationToken, auth ?? _auth);
        }

        /// <inheritdoc/>
        public Task<ZoneSetting<SettingOnOffTypes>> GetTrueClientIpSettingAsync(
            IdentifierTag zoneId,
            CancellationToken cancellationToken,
            CloudFlareAuth auth = null)
        {
            return _client.GetTrueClientIpSettingAsync(zoneId, cancellationToken, auth ?? _auth);
        }
    }
}
