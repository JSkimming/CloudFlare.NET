namespace CloudFlare.NET.Serialization
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Newtonsoft.Json.Linq;

    internal static class FormatterHelpers
    {
        public static JObject Remove(this JObject json, IEnumerable<string> properties)
        {
            if (json == null)
                throw new ArgumentNullException(nameof(json));
            if (properties == null)
                throw new ArgumentNullException(nameof(properties));

            foreach (string property in properties)
            {
                json.Remove(property);
            }

            return json;
        }

        public static JObject Keep(this JObject json, IEnumerable<string> properties)
        {
            if (json == null)
                throw new ArgumentNullException(nameof(json));
            if (properties == null)
                throw new ArgumentNullException(nameof(properties));

            IEnumerable<JProperty> toRemove = json.Properties().Where(p => !properties.Contains(p.Name)).ToList();

            foreach (JProperty property in toRemove)
            {
                property.Remove();
            }

            return json;
        }
    }
}
