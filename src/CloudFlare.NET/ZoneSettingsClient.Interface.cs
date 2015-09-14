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

        /// <summary>
        /// Enable IP Geolocation to have CloudFlare geolocate visitors to your website and pass the country code to
        /// you.
        /// </summary>
        /// <seealso href="https://api.cloudflare.com/#zone-settings-get-ip-geolocation-setting"/>
        Task<ZoneSetting<SettingOnOffTypes>> GetIpGeolocationSettingAsync(
            IdentifierTag zoneId,
            CancellationToken cancellationToken,
            CloudFlareAuth auth = null);

        /// <summary>
        /// Enable IPv6 on all subdomains that are CloudFlare enabled.
        /// </summary>
        /// <seealso href="https://api.cloudflare.com/#zone-settings-get-ipv6-setting"/>
        Task<ZoneSetting<SettingIPv6Types>> GetIPv6SettingAsync(
            IdentifierTag zoneId,
            CancellationToken cancellationToken,
            CloudFlareAuth auth = null);

        /// <summary>
        /// Automatically minify certain assets for your website
        /// </summary>
        /// <seealso href="https://api.cloudflare.com/#zone-settings-get-minify-setting"/>
        Task<ZoneSetting<SettingMinify>> GetMinifySettingAsync(
            IdentifierTag zoneId,
            CancellationToken cancellationToken,
            CloudFlareAuth auth = null);

        /// <summary>
        /// Automatically redirect visitors on mobile devices to a mobile-optimized subdomain.
        /// </summary>
        /// <seealso href="https://api.cloudflare.com/#zone-settings-get-mobile-redirect-setting"/>
        Task<ZoneSetting<SettingMobileRedirect>> GetMobileRedirectSettingAsync(
            IdentifierTag zoneId,
            CancellationToken cancellationToken,
            CloudFlareAuth auth = null);

        /// <summary>
        /// Automatically optimize image loading for website visitors on mobile devices.
        /// </summary>
        /// <seealso href="https://api.cloudflare.com/#zone-settings-get-mirage-setting"/>
        Task<ZoneSetting<SettingOnOffTypes>> GetMirageSettingAsync(
            IdentifierTag zoneId,
            CancellationToken cancellationToken,
            CloudFlareAuth auth = null);

        /// <summary>
        /// CloudFlare will proxy customer error pages on any 502,504 errors on origin server instead of showing a
        /// default CloudFlare error page.
        /// </summary>
        /// <seealso href="https://api.cloudflare.com/#zone-settings-get-enable-error-pages-on-setting"/>
        Task<ZoneSetting<SettingOnOffTypes>> GetEnableErrorPagesOnSettingAsync(
            IdentifierTag zoneId,
            CancellationToken cancellationToken,
            CloudFlareAuth auth = null);

        /// <summary>
        /// Strips metadata and compresses your images for faster page load times.
        /// </summary>
        /// <seealso href="https://api.cloudflare.com/#zone-settings-get-polish-setting"/>
        Task<ZoneSetting<SettingPolishTypes>> GetPolishSettingAsync(
            IdentifierTag zoneId,
            CancellationToken cancellationToken,
            CloudFlareAuth auth = null);

        /// <summary>
        /// CloudFlare will prefetch any URLs that are included in the response headers.
        /// </summary>
        /// <seealso href="https://api.cloudflare.com/#zone-settings-get-prefetch-preload-setting"/>
        Task<ZoneSetting<SettingOnOffTypes>> GetPrefetchPreloadSettingAsync(
            IdentifierTag zoneId,
            CancellationToken cancellationToken,
            CloudFlareAuth auth = null);

        /// <summary>
        /// Enables or disables buffering of responses from the proxied server.
        /// </summary>
        /// <seealso href="https://api.cloudflare.com/#zone-settings-get-response-buffering-setting"/>
        Task<ZoneSetting<SettingOnOffTypes>> GetResponseBufferingSettingAsync(
            IdentifierTag zoneId,
            CancellationToken cancellationToken,
            CloudFlareAuth auth = null);

        /// <summary>
        /// Rocket Loader is a general-purpose asynchronous JavaScript loader coupled with a lightweight virtual
        /// browser which can safely run any JavaScript code after window.onload.
        /// </summary>
        /// <seealso href="https://api.cloudflare.com/#zone-settings-get-rocket-loader-setting"/>
        Task<ZoneSetting<SettingRocketLoaderTypes>> GetRocketLoaderSettingAsync(
            IdentifierTag zoneId,
            CancellationToken cancellationToken,
            CloudFlareAuth auth = null);

        /// <summary>
        /// CloudFlare security header for a zone.
        /// </summary>
        /// <seealso href="https://api.cloudflare.com/#zone-settings-get-security-header-hsts-setting"/>
        Task<ZoneSetting<SettingSecurityHeader>> GetSecurityHeaderSettingAsync(
            IdentifierTag zoneId,
            CancellationToken cancellationToken,
            CloudFlareAuth auth = null);

        /// <summary>
        /// Choose the appropriate security profile for your website, which will automatically adjust each of the
        /// security settings.
        /// </summary>
        /// <seealso href="https://api.cloudflare.com/#zone-settings-get-security-level-setting"/>
        Task<ZoneSetting<SettingSecurityLevelTypes>> GetSecurityLevelSettingAsync(
            IdentifierTag zoneId,
            CancellationToken cancellationToken,
            CloudFlareAuth auth = null);

        /// <summary>
        /// If there is sensitive content on your website that you want visible to real visitors, but that you want to
        /// hide from suspicious visitors, all you have to do is wrap the content with CloudFlare SSE tags.
        /// </summary>
        /// <seealso href="https://api.cloudflare.com/#zone-settings-get-server-side-exclude-setting"/>
        Task<ZoneSetting<SettingOnOffTypes>> GetServerSideExcludeSettingAsync(
            IdentifierTag zoneId,
            CancellationToken cancellationToken,
            CloudFlareAuth auth = null);

        /// <summary>
        /// CloudFlare will treat files with the same query strings as the same file in cache, regardless of the order
        /// of the query strings.
        /// </summary>
        /// <seealso href="https://api.cloudflare.com/#zone-settings-get-enable-query-string-sort-setting"/>
        Task<ZoneSetting<SettingOnOffTypes>> GetEnableQueryStringSortSettingAsync(
            IdentifierTag zoneId,
            CancellationToken cancellationToken,
            CloudFlareAuth auth = null);

        /// <summary>
        /// SSL encrypts your visitor's connection and safeguards credit card numbers and other personal data to and
        /// from your website.
        /// </summary>
        /// <seealso href="https://api.cloudflare.com/#zone-settings-get-ssl-setting"/>
        Task<ZoneSetting<SettingSslTypes>> GetSslSettingAsync(
            IdentifierTag zoneId,
            CancellationToken cancellationToken,
            CloudFlareAuth auth = null);

        /// <summary>
        /// Enable Crypto TLS 1.2 feature for this zone and prevent use of previous versions.
        /// </summary>
        /// <seealso href="https://api.cloudflare.com/#zone-settings-get-zone-enable-tls-1-2-setting"/>
        Task<ZoneSetting<SettingOnOffTypes>> GetZoneEnableTls12SettingAsync(
            IdentifierTag zoneId,
            CancellationToken cancellationToken,
            CloudFlareAuth auth = null);
    }
}
