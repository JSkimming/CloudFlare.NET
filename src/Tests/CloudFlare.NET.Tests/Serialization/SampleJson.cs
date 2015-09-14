namespace CloudFlare.NET.Serialization
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using Newtonsoft.Json.Linq;

    internal class SampleJson
    {
        public static TJson Load<TJson>(string fileName)
            where TJson : JToken
        {
            Stream stream =
                typeof(SampleJson).Assembly.GetManifestResourceStream(typeof(SampleJson), $"{fileName}.json");

            if (stream == null)
                throw new InvalidOperationException(
                    $"Unable to load Sample JSON file '{fileName}'" +
                    " - did you mark the file as an 'embedded resource'?");

            using (var sr = new StreamReader(stream))
            {
                string json = sr.ReadToEnd();
                return (TJson)JToken.Parse(json);
            }
        }

        private static JObject GetZoneSetting(string setting)
            => ZoneSettings.Cast<JObject>().Single(s => s["id"].Value<string>() == setting);

        public static JObject DnsRecord => Load<JObject>(nameof(DnsRecord));

        public static JObject DnsRecordMinimal => Load<JObject>(nameof(DnsRecordMinimal));

        public static JObject ErrorResponse => Load<JObject>(nameof(ErrorResponse));

        public static JObject SuccessResponse => Load<JObject>(nameof(SuccessResponse));

        public static JObject Zone => Load<JObject>(nameof(Zone));

        public static JObject ZoneMinimal => Load<JObject>(nameof(ZoneMinimal));

        public static JArray ZoneSettings => Load<JArray>(nameof(ZoneSettings));

        public static JArray ZoneSettingsErred => Load<JArray>(nameof(ZoneSettingsErred));

        public static JObject ZoneSettingAdvancedDdos => GetZoneSetting("advanced_ddos");

        public static JObject ZoneSettingAlwaysOnline => GetZoneSetting("always_online");

        public static JObject ZoneSettingBrowserCacheTtl => GetZoneSetting("browser_cache_ttl");

        public static JObject ZoneSettingBrowserCheck => GetZoneSetting("browser_check");

        public static JObject ZoneSettingCacheLevel => GetZoneSetting("cache_level");

        public static JObject ZoneSettingChallengeTtl => GetZoneSetting("challenge_ttl");

        public static JObject ZoneSettingDevelopmentMode => GetZoneSetting("development_mode");

        public static JObject ZoneSettingEmailObfuscation => GetZoneSetting("email_obfuscation");

        public static JObject ZoneSettingHotlinkProtection => GetZoneSetting("hotlink_protection");

        public static JObject ZoneSettingIpGeolocation => GetZoneSetting("ip_geolocation");

        public static JObject ZoneSettingIPv6 => GetZoneSetting("ipv6");

        public static JObject ZoneSettingMinify => GetZoneSetting("minify");

        public static JObject ZoneSettingMobileRedirect => GetZoneSetting("mobile_redirect");

        public static JObject ZoneSettingMirage => GetZoneSetting("mirage");

        public static JObject ZoneSettingEnableErrorPagesOn => GetZoneSetting("origin_error_page_pass_thru");

        public static JObject ZoneSettingPolish => GetZoneSetting("polish");

        public static JObject ZoneSettingPrefetchPreload => GetZoneSetting("prefetch_preload");

        public static JObject ZoneSettingResponseBuffering => GetZoneSetting("response_buffering");

        public static JObject ZoneSettingRocketLoader => GetZoneSetting("rocket_loader");

        public static JObject ZoneSettingSecurityHeader => GetZoneSetting("security_header");

        public static JObject ZoneSettingSecurityLevel => GetZoneSetting("security_level");

        public static JObject ZoneSettingServerSideExclude => GetZoneSetting("server_side_exclude");

        public static JObject ZoneSettingEnableQueryStringSort => GetZoneSetting("sort_query_string_for_cache");

        public static JObject ZoneSettingSsl => GetZoneSetting("ssl");

        public static JObject ZoneSettingEnableTls12 => GetZoneSetting("tls_1_2_only");

        public static JObject ZoneSettingTlsClientAuth => GetZoneSetting("tls_client_auth");

        public static JObject ZoneSettingTrueClientIp => GetZoneSetting("true_client_ip_header");

        public static JObject ZoneSettingWebApplicationFirewall => GetZoneSetting("waf");

        public static JObject ZoneSettingTest1 => GetZoneSetting("xxx_test1");
    }
}
