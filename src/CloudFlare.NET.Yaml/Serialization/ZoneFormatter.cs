namespace CloudFlare.NET.Serialization
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Newtonsoft.Json.Linq;

    /// <summary>
    /// Performs post processing on a <see cref="Zone"/> before conversion to YAML.
    /// </summary>
    public class ZoneFormatter : TypedJsonFormatter<Zone>
    {
        /// <summary>
        /// Post formats the <paramref name="json"/> of a <see cref="Zone"/>.
        /// </summary>
        protected override JObject PostFormat(JObject json, Zone value)
        {
            base.PostFormat(json, value);

            return json.Keep(new[] { "name" });
        }
    }
}
