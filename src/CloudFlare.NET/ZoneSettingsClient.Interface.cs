namespace CloudFlare.NET
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading;
    using System.Threading.Tasks;

    /// <summary>
    /// The CloudFlare Zone Settings API Client.
    /// </summary>
    /// <seealso href="https://api.cloudflare.com/#zone-settings"/>
    public interface IZoneSettingsClient
    {
        /// <summary>
        /// Gets the zone settings for the zone with the specified <paramref name="zoneId"/>.
        /// </summary>
        /// <seealso href="https://api.cloudflare.com/#zone-settings-get-all-zone-settings"/>
        Task<IEnumerable<ZoneSettingBase>> GetAllZoneSettingsAsync(
            IdentifierTag zoneId,
            CancellationToken cancellationToken,
            CloudFlareAuth auth = null);

        /// <summary>
        /// Advanced protection from Distributed Denial of Service (DDoS) attacks on your website.
        /// This is an uneditable value that is 'on' in the case of Business and Enterprise zones
        /// </summary>
        /// <seealso href="https://api.cloudflare.com/#zone-settings-get-advanced-ddos-setting"/>
        Task<ZoneSetting<SettingOnOffTypes>> GetAdvancedDdosSettingAsync(
            IdentifierTag zoneId,
            CancellationToken cancellationToken,
            CloudFlareAuth auth = null);

        /// <summary>
        /// When enabled, Always Online will serve pages from our cache if your server is offline.
        /// </summary>
        /// <seealso href="https://api.cloudflare.com/#zone-settings-get-always-online-setting"/>
        Task<ZoneSetting<SettingOnOffTypes>> GetAlwaysOnlineSettingAsync(
            IdentifierTag zoneId,
            CancellationToken cancellationToken,
            CloudFlareAuth auth = null);

        /// <summary>
        /// Browser Cache TTL (in seconds) specifies how long CloudFlare-cached resources will remain on your visitors'
        /// computers.
        /// </summary>
        /// <seealso href="https://api.cloudflare.com/#zone-settings-get-browser-cache-ttl-setting"/>
        Task<ZoneSetting<int>> GetBrowserCacheTtlSettingAsync(
            IdentifierTag zoneId,
            CancellationToken cancellationToken,
            CloudFlareAuth auth = null);

        /// <summary>
        /// Browser Integrity Check is similar to Bad Behavior and looks for common HTTP headers abused most commonly
        /// by spammers and denies access to your page.
        /// </summary>
        /// <seealso href="https://api.cloudflare.com/#zone-settings-get-browser-check-setting"/>
        Task<ZoneSetting<SettingOnOffTypes>> GetBrowserCheckSettingAsync(
            IdentifierTag zoneId,
            CancellationToken cancellationToken,
            CloudFlareAuth auth = null);

        /// <summary>
        /// Cache Level functions based off the setting level.
        /// </summary>
        /// <seealso href="https://api.cloudflare.com/#zone-settings-get-cache-level-setting"/>
        Task<ZoneSetting<SettingCacheLevelTypes>> GetCacheLevelSettingAsync(
            IdentifierTag zoneId,
            CancellationToken cancellationToken,
            CloudFlareAuth auth = null);

        /// <summary>
        /// Specify how long a visitor is allowed access to your site after successfully completing a challenge
        /// (such as a CAPTCHA).
        /// </summary>
        /// <seealso href="https://api.cloudflare.com/#zone-settings-get-challenge-ttl-setting"/>
        Task<ZoneSetting<int>> GetChallengeTtlSettingAsync(
            IdentifierTag zoneId,
            CancellationToken cancellationToken,
            CloudFlareAuth auth = null);

        /// <summary>
        /// Development Mode temporarily allows you to enter development mode for your websites if you need to make
        /// changes to your site.
        /// </summary>
        /// <seealso href="https://api.cloudflare.com/#zone-settings-get-development-mode-setting"/>
        Task<ZoneDevelopmentModeSetting> GetDevelopmentModeSettingAsync(
            IdentifierTag zoneId,
            CancellationToken cancellationToken,
            CloudFlareAuth auth = null);

        /// <summary>
        /// Encrypt email addresses on your web page from bots, while keeping them visible to humans.
        /// </summary>
        /// <seealso href="https://api.cloudflare.com/#zone-settings-get-email-obfuscation-setting"/>
        Task<ZoneSetting<SettingOnOffTypes>> GetEmailObfuscationSettingAsync(
            IdentifierTag zoneId,
            CancellationToken cancellationToken,
            CloudFlareAuth auth = null);

        /// <summary>
        /// When enabled, the Hotlink Protection option ensures that other sites cannot suck up your bandwidth by
        /// building pages that use images hosted on your site.
        /// </summary>
        /// <seealso href="https://api.cloudflare.com/#zone-settings-get-hotlink-protection-setting"/>
        Task<ZoneSetting<SettingOnOffTypes>> GetHotlinkProtectionSettingAsync(
            IdentifierTag zoneId,
            CancellationToken cancellationToken,
            CloudFlareAuth auth = null);
    }
}
