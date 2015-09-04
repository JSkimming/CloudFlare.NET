namespace CloudFlare.NET
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Newtonsoft.Json;

    /// <summary>
    /// A Zone setting changes how the Zone works in relation to caching, security, or other features of CloudFlare.
    /// </summary>
    /// <typeparam name="TValue">The type of the <see cref="Value"/>.</typeparam>
    /// <seealso href="https://api.cloudflare.com/#zone-settings" />
    public class ZoneSetting<TValue> : ZoneSettingBase
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ZoneSetting{TValue}"/> class.
        /// </summary>
        public ZoneSetting(string id, TValue value, bool editable, DateTimeOffset modifiedOn)
            : base(id, editable, modifiedOn)
        {
            Value = value;
        }

        /// <summary>
        /// Value of the zone setting.
        /// </summary>
        [JsonProperty("value")]
        public TValue Value { get; }
    }
}
