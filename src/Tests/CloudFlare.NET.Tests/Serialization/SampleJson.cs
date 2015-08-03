namespace CloudFlare.NET.Serialization
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using Newtonsoft.Json.Linq;

    internal class SampleJson
    {
        public static JObject Load(string fileName)
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
                return JObject.Parse(json);
            }
        }

        public static JObject ErrorResponse => Load(nameof(ErrorResponse));

        public static JObject SuccessResponse => Load(nameof(SuccessResponse));

        public static JObject Zone => Load(nameof(Zone));

        public static JObject ZoneMinimal => Load(nameof(ZoneMinimal));
    }
}
