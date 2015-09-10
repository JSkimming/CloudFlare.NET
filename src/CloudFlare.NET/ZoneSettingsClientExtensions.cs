namespace CloudFlare.NET
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading;
    using System.Threading.Tasks;

    /// <summary>
    /// Helper extension methods on <see cref="IZoneSettingsClient"/>.
    /// </summary>
    public static class ZoneSettingsClientExtensions
    {
        /// <summary>
        /// Gets the zone settings for the zone with the specified <paramref name="zoneId"/>.
        /// </summary>
        /// <seealso href="https://api.cloudflare.com/#zone-settings-get-all-zone-settings"/>
        public static Task<IEnumerable<ZoneSettingBase>> GetAllZoneSettingsAsync(
            this IZoneSettingsClient client,
            IdentifierTag zoneId,
            CloudFlareAuth auth = null)
        {
            if (client == null)
                throw new ArgumentNullException(nameof(client));
            if (zoneId == null)
                throw new ArgumentNullException(nameof(zoneId));

            return client.GetAllZoneSettingsAsync(zoneId, CancellationToken.None,  auth);
        }

        /// <summary>
        /// Advanced protection from Distributed Denial of Service (DDoS) attacks on your website.
        /// This is an uneditable value that is 'on' in the case of Business and Enterprise zones
        /// </summary>
        /// <seealso href="https://api.cloudflare.com/#zone-settings-get-advanced-ddos-setting"/>
        public static Task<ZoneSetting<SettingOnOffTypes>> GetAdvancedDdosSettingAsync(
            this IZoneSettingsClient client,
            IdentifierTag zoneId,
            CloudFlareAuth auth = null)
        {
            if (client == null)
                throw new ArgumentNullException(nameof(client));
            if (zoneId == null)
                throw new ArgumentNullException(nameof(zoneId));

            return client.GetAdvancedDdosSettingAsync(zoneId, CancellationToken.None, auth);
        }

        /// <summary>
        /// When enabled, Always Online will serve pages from our cache if your server is offline.
        /// </summary>
        /// <seealso href="https://api.cloudflare.com/#zone-settings-get-always-online-setting"/>
        public static Task<ZoneSetting<SettingOnOffTypes>> GetAlwaysOnlineSettingAsync(
            this IZoneSettingsClient client,
            IdentifierTag zoneId,
            CloudFlareAuth auth = null)
        {
            if (client == null)
                throw new ArgumentNullException(nameof(client));
            if (zoneId == null)
                throw new ArgumentNullException(nameof(zoneId));

            return client.GetAlwaysOnlineSettingAsync(zoneId, CancellationToken.None, auth);
        }

        /// <summary>
        /// Browser Cache TTL (in seconds) specifies how long CloudFlare-cached resources will remain on your visitors'
        /// computers.
        /// </summary>
        /// <seealso href="https://api.cloudflare.com/#zone-settings-get-browser-cache-ttl-setting"/>
        public static Task<ZoneSetting<int>> GetBrowserCacheTtlSettingAsync(
            this IZoneSettingsClient client,
            IdentifierTag zoneId,
            CloudFlareAuth auth = null)
        {
            if (client == null)
                throw new ArgumentNullException(nameof(client));
            if (zoneId == null)
                throw new ArgumentNullException(nameof(zoneId));

            return client.GetBrowserCacheTtlSettingAsync(zoneId, CancellationToken.None, auth);
        }
    }
}
