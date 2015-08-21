namespace CloudFlare.NET.Serialization
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Newtonsoft.Json.Linq;

    /// <summary>
    /// Performs post processing on a <see cref="DnsRecord"/> before conversion to YAML.
    /// </summary>
    public class DnsRecordFormatter : TypedJsonFormatter<DnsRecord>
    {
        /// <summary>
        /// Post formats the <paramref name="json"/> of a <see cref="DnsRecord"/>.
        /// </summary>
        protected override JObject PostFormat(JObject json, DnsRecord value)
        {
            base.PostFormat(json, value);

            return json.Keep(new[] { "name", "type", "content", "proxied", "ttl", "priority" });
        }
    }
}
