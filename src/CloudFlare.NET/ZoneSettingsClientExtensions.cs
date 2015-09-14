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

            return client.GetAllZoneSettingsAsync(zoneId, CancellationToken.None, auth);
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

        /// <summary>
        /// Enable IPv6 on all subdomains that are CloudFlare enabled.
        /// </summary>
        /// <seealso href="https://api.cloudflare.com/#zone-settings-get-ipv6-setting"/>
        public static Task<ZoneSetting<SettingIPv6Types>> GetIPv6SettingAsync(
            this IZoneSettingsClient client,
            IdentifierTag zoneId,
            CloudFlareAuth auth = null)
        {
            if (client == null)
                throw new ArgumentNullException(nameof(client));
            if (zoneId == null)
                throw new ArgumentNullException(nameof(zoneId));

            return client.GetIPv6SettingAsync(zoneId, CancellationToken.None, auth);
        }

        /// <summary>
        /// Automatically minify certain assets for your website
        /// </summary>
        /// <seealso href="https://api.cloudflare.com/#zone-settings-get-minify-setting"/>
        public static Task<ZoneSetting<SettingMinify>> GetMinifySettingAsync(
            this IZoneSettingsClient client,
            IdentifierTag zoneId,
            CloudFlareAuth auth = null)
        {
            if (client == null)
                throw new ArgumentNullException(nameof(client));
            if (zoneId == null)
                throw new ArgumentNullException(nameof(zoneId));

            return client.GetMinifySettingAsync(zoneId, CancellationToken.None, auth);
        }

        /// <summary>
        /// Automatically redirect visitors on mobile devices to a mobile-optimized subdomain.
        /// </summary>
        /// <seealso href="https://api.cloudflare.com/#zone-settings-get-mobile-redirect-setting"/>
        public static Task<ZoneSetting<SettingMobileRedirect>> GetMobileRedirectSettingAsync(
            this IZoneSettingsClient client,
            IdentifierTag zoneId,
            CloudFlareAuth auth = null)
        {
            if (client == null)
                throw new ArgumentNullException(nameof(client));
            if (zoneId == null)
                throw new ArgumentNullException(nameof(zoneId));

            return client.GetMobileRedirectSettingAsync(zoneId, CancellationToken.None, auth);
        }

        /// <summary>
        /// Automatically optimize image loading for website visitors on mobile devices.
        /// </summary>
        /// <seealso href="https://api.cloudflare.com/#zone-settings-get-mirage-setting"/>
        public static Task<ZoneSetting<SettingOnOffTypes>> GetMirageSettingAsync(
            this IZoneSettingsClient client,
            IdentifierTag zoneId,
            CloudFlareAuth auth = null)
        {
            if (client == null)
                throw new ArgumentNullException(nameof(client));
            if (zoneId == null)
                throw new ArgumentNullException(nameof(zoneId));

            return client.GetMirageSettingAsync(zoneId, CancellationToken.None, auth);
        }

        /// <summary>
        /// CloudFlare will proxy customer error pages on any 502,504 errors on origin server instead of showing a
        /// default CloudFlare error page.
        /// </summary>
        /// <seealso href="https://api.cloudflare.com/#zone-settings-get-enable-error-pages-on-setting"/>
        public static Task<ZoneSetting<SettingOnOffTypes>> GetEnableErrorPagesOnSettingAsync(
            this IZoneSettingsClient client,
            IdentifierTag zoneId,
            CloudFlareAuth auth = null)
        {
            if (client == null)
                throw new ArgumentNullException(nameof(client));
            if (zoneId == null)
                throw new ArgumentNullException(nameof(zoneId));

            return client.GetEnableErrorPagesOnSettingAsync(zoneId, CancellationToken.None, auth);
        }

        /// <summary>
        /// Strips metadata and compresses your images for faster page load times.
        /// </summary>
        /// <seealso href="https://api.cloudflare.com/#zone-settings-get-polish-setting"/>
        public static Task<ZoneSetting<SettingPolishTypes>> GetPolishSettingAsync(
            this IZoneSettingsClient client,
            IdentifierTag zoneId,
            CloudFlareAuth auth = null)
        {
            if (client == null)
                throw new ArgumentNullException(nameof(client));
            if (zoneId == null)
                throw new ArgumentNullException(nameof(zoneId));

            return client.GetPolishSettingAsync(zoneId, CancellationToken.None, auth);
        }

        /// <summary>
        /// CloudFlare will prefetch any URLs that are included in the response headers.
        /// </summary>
        /// <seealso href="https://api.cloudflare.com/#zone-settings-get-prefetch-preload-setting"/>
        public static Task<ZoneSetting<SettingOnOffTypes>> GetPrefetchPreloadSettingAsync(
            this IZoneSettingsClient client,
            IdentifierTag zoneId,
            CloudFlareAuth auth = null)
        {
            if (client == null)
                throw new ArgumentNullException(nameof(client));
            if (zoneId == null)
                throw new ArgumentNullException(nameof(zoneId));

            return client.GetPrefetchPreloadSettingAsync(zoneId, CancellationToken.None, auth);
        }

        /// <summary>
        /// Enables or disables buffering of responses from the proxied server.
        /// </summary>
        /// <seealso href="https://api.cloudflare.com/#zone-settings-get-response-buffering-setting"/>
        public static Task<ZoneSetting<SettingOnOffTypes>> GetResponseBufferingSettingAsync(
            this IZoneSettingsClient client,
            IdentifierTag zoneId,
            CloudFlareAuth auth = null)
        {
            if (client == null)
                throw new ArgumentNullException(nameof(client));
            if (zoneId == null)
                throw new ArgumentNullException(nameof(zoneId));

            return client.GetResponseBufferingSettingAsync(zoneId, CancellationToken.None, auth);
        }

        /// <summary>
        /// Rocket Loader is a general-purpose asynchronous JavaScript loader coupled with a lightweight virtual
        /// browser which can safely run any JavaScript code after window.onload.
        /// </summary>
        /// <seealso href="https://api.cloudflare.com/#zone-settings-get-rocket-loader-setting"/>
        public static Task<ZoneSetting<SettingRocketLoaderTypes>> GetRocketLoaderSettingAsync(
            this IZoneSettingsClient client,
            IdentifierTag zoneId,
            CloudFlareAuth auth = null)
        {
            if (client == null)
                throw new ArgumentNullException(nameof(client));
            if (zoneId == null)
                throw new ArgumentNullException(nameof(zoneId));

            return client.GetRocketLoaderSettingAsync(zoneId, CancellationToken.None, auth);
        }

        /// <summary>
        /// CloudFlare security header for a zone.
        /// </summary>
        /// <seealso href="https://api.cloudflare.com/#zone-settings-get-security-header-hsts-setting"/>
        public static Task<ZoneSetting<SettingSecurityHeader>> GetSecurityHeaderSettingAsync(
            this IZoneSettingsClient client,
            IdentifierTag zoneId,
            CloudFlareAuth auth = null)
        {
            if (client == null)
                throw new ArgumentNullException(nameof(client));
            if (zoneId == null)
                throw new ArgumentNullException(nameof(zoneId));

            return client.GetSecurityHeaderSettingAsync(zoneId, CancellationToken.None, auth);
        }

        /// <summary>
        /// Choose the appropriate security profile for your website, which will automatically adjust each of the
        /// security settings.
        /// </summary>
        /// <seealso href="https://api.cloudflare.com/#zone-settings-get-security-level-setting"/>
        public static Task<ZoneSetting<SettingSecurityLevelTypes>> GetSecurityLevelSettingAsync(
            this IZoneSettingsClient client,
            IdentifierTag zoneId,
            CloudFlareAuth auth = null)
        {
            if (client == null)
                throw new ArgumentNullException(nameof(client));
            if (zoneId == null)
                throw new ArgumentNullException(nameof(zoneId));

            return client.GetSecurityLevelSettingAsync(zoneId, CancellationToken.None, auth);
        }

        /// <summary>
        /// If there is sensitive content on your website that you want visible to real visitors, but that you want to
        /// hide from suspicious visitors, all you have to do is wrap the content with CloudFlare SSE tags.
        /// </summary>
        /// <seealso href="https://api.cloudflare.com/#zone-settings-get-server-side-exclude-setting"/>
        public static Task<ZoneSetting<SettingOnOffTypes>> GetServerSideExcludeSettingAsync(
            this IZoneSettingsClient client,
            IdentifierTag zoneId,
            CloudFlareAuth auth = null)
        {
            if (client == null)
                throw new ArgumentNullException(nameof(client));
            if (zoneId == null)
                throw new ArgumentNullException(nameof(zoneId));

            return client.GetServerSideExcludeSettingAsync(zoneId, CancellationToken.None, auth);
        }

        /// <summary>
        /// CloudFlare will treat files with the same query strings as the same file in cache, regardless of the order
        /// of the query strings.
        /// </summary>
        /// <seealso href="https://api.cloudflare.com/#zone-settings-get-enable-query-string-sort-setting"/>
        public static Task<ZoneSetting<SettingOnOffTypes>> GetEnableQueryStringSortSettingAsync(
            this IZoneSettingsClient client,
            IdentifierTag zoneId,
            CloudFlareAuth auth = null)
        {
            if (client == null)
                throw new ArgumentNullException(nameof(client));
            if (zoneId == null)
                throw new ArgumentNullException(nameof(zoneId));

            return client.GetEnableQueryStringSortSettingAsync(zoneId, CancellationToken.None, auth);
        }

        /// <summary>
        /// SSL encrypts your visitor's connection and safeguards credit card numbers and other personal data to and
        /// from your website.
        /// </summary>
        /// <seealso href="https://api.cloudflare.com/#zone-settings-get-ssl-setting"/>
        public static Task<ZoneSetting<SettingSslTypes>> GetSslSettingAsync(
            this IZoneSettingsClient client,
            IdentifierTag zoneId,
            CloudFlareAuth auth = null)
        {
            if (client == null)
                throw new ArgumentNullException(nameof(client));
            if (zoneId == null)
                throw new ArgumentNullException(nameof(zoneId));

            return client.GetSslSettingAsync(zoneId, CancellationToken.None, auth);
        }

        /// <summary>
        /// Enable Crypto TLS 1.2 feature for this zone and prevent use of previous versions.
        /// </summary>
        /// <seealso href="https://api.cloudflare.com/#zone-settings-get-zone-enable-tls-1-2-setting"/>
        public static Task<ZoneSetting<SettingOnOffTypes>> GetZoneEnableTls12SettingAsync(
            this IZoneSettingsClient client,
            IdentifierTag zoneId,
            CloudFlareAuth auth = null)
        {
            if (client == null)
                throw new ArgumentNullException(nameof(client));
            if (zoneId == null)
                throw new ArgumentNullException(nameof(zoneId));

            return client.GetZoneEnableTls12SettingAsync(zoneId, CancellationToken.None, auth);
        }

        /// <summary>
        /// TLS Client Auth requires CloudFlare to connect to your origin server using a client certificate.
        /// </summary>
        /// <seealso href="https://api.cloudflare.com/#zone-settings-get-tls-client-auth-setting"/>
        public static Task<ZoneSetting<SettingOnOffTypes>> GetTlsClientAuthSettingAsync(
            this IZoneSettingsClient client,
            IdentifierTag zoneId,
            CloudFlareAuth auth = null)
        {
            if (client == null)
                throw new ArgumentNullException(nameof(client));
            if (zoneId == null)
                throw new ArgumentNullException(nameof(zoneId));

            return client.GetTlsClientAuthSettingAsync(zoneId, CancellationToken.None, auth);
        }

        /// <summary>
        /// Allows customer to continue to use True Client IP (Akamai feature) in the headers we send to the origin.
        /// </summary>
        /// <seealso href="https://api.cloudflare.com/#zone-settings-get-true-client-ip-setting"/>
        public static Task<ZoneSetting<SettingOnOffTypes>> GetTrueClientIpSettingAsync(
            this IZoneSettingsClient client,
            IdentifierTag zoneId,
            CloudFlareAuth auth = null)
        {
            if (client == null)
                throw new ArgumentNullException(nameof(client));
            if (zoneId == null)
                throw new ArgumentNullException(nameof(zoneId));

            return client.GetTrueClientIpSettingAsync(zoneId, CancellationToken.None, auth);
        }
    }
}