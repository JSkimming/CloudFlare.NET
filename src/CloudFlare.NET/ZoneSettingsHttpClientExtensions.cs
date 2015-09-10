namespace CloudFlare.NET
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Net.Http;
    using System.Threading;
    using System.Threading.Tasks;
    using Newtonsoft.Json.Linq;

    /// <summary>
    /// Extension methods on <see cref="HttpClient"/> to wrap the Zone APIs
    /// </summary>
    /// <seealso href="https://api.cloudflare.com/#zone-settings"/>
    public static class ZoneSettingsHttpClientExtensions
    {
        /// <summary>
        /// Gets the zone settings for the zone with the specified <paramref name="zoneId"/>.
        /// </summary>
        /// <seealso href="https://api.cloudflare.com/#zone-settings-get-all-zone-settings"/>
        public static async Task<IEnumerable<ZoneSettingBase>> GetAllZoneSettingsAsync(
            this HttpClient client,
            IdentifierTag zoneId,
            CancellationToken cancellationToken,
            CloudFlareAuth auth)
        {
            if (zoneId == null)
                throw new ArgumentNullException(nameof(zoneId));

            Uri uri = new Uri(CloudFlareConstants.BaseUri, $"zones/{zoneId}/settings");

            JArray jsonSettings = await client.GetCloudFlareResultAsync<JArray>(uri, auth, cancellationToken)
                .ConfigureAwait(false);

            return GetZoneSetting(jsonSettings.Cast<JObject>());
        }

        /// <summary>
        /// Advanced protection from Distributed Denial of Service (DDoS) attacks on your website.
        /// This is an uneditable value that is 'on' in the case of Business and Enterprise zones
        /// </summary>
        /// <seealso href="https://api.cloudflare.com/#zone-settings-get-advanced-ddos-setting"/>
        public static Task<ZoneSetting<SettingOnOffTypes>> GetAdvancedDdosSettingAsync(
            this HttpClient client,
            IdentifierTag zoneId,
            CancellationToken cancellationToken,
            CloudFlareAuth auth)
        {
            if (zoneId == null)
                throw new ArgumentNullException(nameof(zoneId));

            Uri uri = new Uri(CloudFlareConstants.BaseUri, $"zones/{zoneId}/settings/advanced_ddos");

            return client.GetCloudFlareResultAsync<ZoneSetting<SettingOnOffTypes>>(uri, auth, cancellationToken);
        }

        /// <summary>
        /// When enabled, Always Online will serve pages from our cache if your server is offline.
        /// </summary>
        /// <seealso href="https://api.cloudflare.com/#zone-settings-get-always-online-setting"/>
        public static Task<ZoneSetting<SettingOnOffTypes>> GetAlwaysOnlineSettingAsync(
            this HttpClient client,
            IdentifierTag zoneId,
            CancellationToken cancellationToken,
            CloudFlareAuth auth)
        {
            if (zoneId == null)
                throw new ArgumentNullException(nameof(zoneId));

            Uri uri = new Uri(CloudFlareConstants.BaseUri, $"zones/{zoneId}/settings/always_online");

            return client.GetCloudFlareResultAsync<ZoneSetting<SettingOnOffTypes>>(uri, auth, cancellationToken);
        }

        /// <summary>
        /// Browser Cache TTL (in seconds) specifies how long CloudFlare-cached resources will remain on your visitors'
        /// computers.
        /// </summary>
        /// <seealso href="https://api.cloudflare.com/#zone-settings-get-browser-cache-ttl-setting"/>
        public static Task<ZoneSetting<int>> GetBrowserCacheTtlSettingAsync(
            this HttpClient client,
            IdentifierTag zoneId,
            CancellationToken cancellationToken,
            CloudFlareAuth auth)
        {
            if (zoneId == null)
                throw new ArgumentNullException(nameof(zoneId));

            Uri uri = new Uri(CloudFlareConstants.BaseUri, $"zones/{zoneId}/settings/browser_cache_ttl");

            return client.GetCloudFlareResultAsync<ZoneSetting<int>>(uri, auth, cancellationToken);
        }

        private static IEnumerable<ZoneSettingBase> GetZoneSetting(IEnumerable<JObject> jsons)
        {
            if (jsons == null)
                throw new ArgumentNullException(nameof(jsons));

            foreach (JObject json in jsons)
            {
                JToken idToken = json["id"];
                if (idToken == null)
                {
                    throw new InvalidOperationException($"The setting does not have an id property.\n{json}");
                }

                string id = idToken.Value<string>();

                switch (id)
                {
                    case "advanced_ddos":
                    case "always_online":
                    case "browser_check":
                    case "origin_error_page_pass_thru":
                    case "sort_query_string_for_cache":
                    case "email_obfuscation":
                    case "hotlink_protection":
                    case "ip_geolocation":
                    case "mirage":
                    case "prefetch_preload":
                    case "pseudo_ipv4":
                    case "response_buffering":
                    case "server_side_exclude":
                    case "tls_client_auth":
                    case "true_client_ip_header":
                    case "waf":
                    case "tls_1_2_only":
                        yield return json.ToObject<ZoneSetting<SettingOnOffTypes>>();
                        break;
                    case "browser_cache_ttl":
                    case "challenge_ttl":
                    case "edge_cache_ttl":
                    case "max_upload":
                        yield return json.ToObject<ZoneSetting<int>>();
                        break;
                    case "cache_level":
                        yield return json.ToObject<ZoneSetting<SettingCacheLevelTypes>>();
                        break;
                    case "ipv6":
                        yield return json.ToObject<ZoneSetting<SettingIPv6Types>>();
                        break;
                    case "polish":
                        yield return json.ToObject<ZoneSetting<SettingPolishTypes>>();
                        break;
                    case "rocket_loader":
                        yield return json.ToObject<ZoneSetting<SettingRocketLoaderTypes>>();
                        break;
                    case "security_level":
                        yield return json.ToObject<ZoneSetting<SettingSecurityLevelTypes>>();
                        break;
                    case "ssl":
                        yield return json.ToObject<ZoneSetting<SettingSslTypes>>();
                        break;
                    case "development_mode":
                        yield return json.ToObject<ZoneDevelopmentModeSetting>();
                        break;
                    case "minify":
                        yield return json.ToObject<ZoneSetting<SettingMinify>>();
                        break;
                    case "mobile_redirect":
                        yield return json.ToObject<ZoneSetting<SettingMobileRedirect>>();
                        break;
                    case "security_header":
                        yield return json.ToObject<ZoneSetting<SettingSecurityHeader>>();
                        break;
                    default:
                        yield return json.ToObject<ZoneSetting<JToken>>();
                        break;
                }
            }
        }
    }
}
