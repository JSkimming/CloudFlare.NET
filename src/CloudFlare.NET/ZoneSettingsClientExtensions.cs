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

        /// <summary>
        /// Browser Integrity Check is similar to Bad Behavior and looks for common HTTP headers abused most commonly
        /// by spammers and denies access to your page.
        /// </summary>
        /// <seealso href="https://api.cloudflare.com/#zone-settings-get-browser-check-setting"/>
        public static Task<ZoneSetting<SettingOnOffTypes>> GetBrowserCheckSettingAsync(
            this IZoneSettingsClient client,
            IdentifierTag zoneId,
            CloudFlareAuth auth = null)
        {
            if (client == null)
                throw new ArgumentNullException(nameof(client));
            if (zoneId == null)
                throw new ArgumentNullException(nameof(zoneId));

            return client.GetBrowserCheckSettingAsync(zoneId, CancellationToken.None, auth);
        }

        /// <summary>
        /// Cache Level functions based off the setting level.
        /// </summary>
        /// <seealso href="https://api.cloudflare.com/#zone-settings-get-cache-level-setting"/>
        public static Task<ZoneSetting<SettingCacheLevelTypes>> GetCacheLevelSettingAsync(
            this IZoneSettingsClient client,
            IdentifierTag zoneId,
            CloudFlareAuth auth = null)
        {
            if (client == null)
                throw new ArgumentNullException(nameof(client));
            if (zoneId == null)
                throw new ArgumentNullException(nameof(zoneId));

            return client.GetCacheLevelSettingAsync(zoneId, CancellationToken.None, auth);
        }

        /// <summary>
        /// Specify how long a visitor is allowed access to your site after successfully completing a challenge
        /// (such as a CAPTCHA).
        /// </summary>
        /// <seealso href="https://api.cloudflare.com/#zone-settings-get-challenge-ttl-setting"/>
        public static Task<ZoneSetting<int>> GetChallengeTtlSettingAsync(
            this IZoneSettingsClient client,
            IdentifierTag zoneId,
            CloudFlareAuth auth = null)
        {
            if (client == null)
                throw new ArgumentNullException(nameof(client));
            if (zoneId == null)
                throw new ArgumentNullException(nameof(zoneId));

            return client.GetChallengeTtlSettingAsync(zoneId, CancellationToken.None, auth);
        }

        /// <summary>
        /// Development Mode temporarily allows you to enter development mode for your websites if you need to make
        /// changes to your site.
        /// </summary>
        /// <seealso href="https://api.cloudflare.com/#zone-settings-get-development-mode-setting"/>
        public static Task<ZoneDevelopmentModeSetting> GetDevelopmentModeSettingAsync(
            this IZoneSettingsClient client,
            IdentifierTag zoneId,
            CloudFlareAuth auth = null)
        {
            if (client == null)
                throw new ArgumentNullException(nameof(client));
            if (zoneId == null)
                throw new ArgumentNullException(nameof(zoneId));

            return client.GetDevelopmentModeSettingAsync(zoneId, CancellationToken.None, auth);
        }

        /// <summary>
        /// Encrypt email addresses on your web page from bots, while keeping them visible to humans.
        /// </summary>
        /// <seealso href="https://api.cloudflare.com/#zone-settings-get-email-obfuscation-setting"/>
        public static Task<ZoneSetting<SettingOnOffTypes>> GetEmailObfuscationSettingAsync(
            this IZoneSettingsClient client,
            IdentifierTag zoneId,
            CloudFlareAuth auth = null)
        {
            if (client == null)
                throw new ArgumentNullException(nameof(client));
            if (zoneId == null)
                throw new ArgumentNullException(nameof(zoneId));

            return client.GetEmailObfuscationSettingAsync(zoneId, CancellationToken.None, auth);
        }

        /// <summary>
        /// When enabled, the Hotlink Protection option ensures that other sites cannot suck up your bandwidth by
        /// building pages that use images hosted on your site.
        /// </summary>
        /// <seealso href="https://api.cloudflare.com/#zone-settings-get-hotlink-protection-setting"/>
        public static Task<ZoneSetting<SettingOnOffTypes>> GetHotlinkProtectionSettingAsync(
            this IZoneSettingsClient client,
            IdentifierTag zoneId,
            CloudFlareAuth auth = null)
        {
            if (client == null)
                throw new ArgumentNullException(nameof(client));
            if (zoneId == null)
                throw new ArgumentNullException(nameof(zoneId));

            return client.GetHotlinkProtectionSettingAsync(zoneId, CancellationToken.None, auth);
        }

        /// <summary>
        /// Enable IP Geolocation to have CloudFlare geolocate visitors to your website and pass the country code to
        /// you.
        /// </summary>
        /// <seealso href="https://api.cloudflare.com/#zone-settings-get-ip-geolocation-setting"/>
        public static Task<ZoneSetting<SettingOnOffTypes>> GetIpGeolocationSettingAsync(
            this IZoneSettingsClient client,
            IdentifierTag zoneId,
            CloudFlareAuth auth = null)
        {
            if (client == null)
                throw new ArgumentNullException(nameof(client));
            if (zoneId == null)
                throw new ArgumentNullException(nameof(zoneId));

            return client.GetIpGeolocationSettingAsync(zoneId, CancellationToken.None, auth);
        }
    }
}
