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

        public static JObject ZoneSettingDevelopmentMode => GetZoneSetting("development_mode");

        public static JObject ZoneSettingMinify => GetZoneSetting("minify");

        public static JObject ZoneSettingMobileRedirect => GetZoneSetting("mobile_redirect");

        public static JObject ZoneSettingSecurityHeader => GetZoneSetting("security_header");

        public static JObject ZoneSettingTest1 => GetZoneSetting("xxx_test1");
    }
}
