namespace CloudFlare.NET
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using CloudFlare.NET.Serialization;
    using Newtonsoft.Json;

    /// <summary>
    /// The base class for all Zone settings.
    /// </summary>
    /// <seealso href="https://api.cloudflare.com/#zone-settings" />
    public abstract class ZoneSettingBase
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ZoneSettingBase"/> class.
        /// </summary>
        protected ZoneSettingBase(string id, bool editable, DateTimeOffset? modifiedOn)
        {
            if (id == null)
                throw new ArgumentNullException(nameof(id));

            Id = id;
            Editable = editable;
            ModifiedOn = modifiedOn;
        }

        /// <summary>
        /// ID of the zone setting.
        /// </summary>
        [JsonProperty("id")]
        public string Id { get; }

        /// <summary>
        /// Value of the zone setting.
        /// </summary>
        [JsonProperty("editable")]
        public bool Editable { get; }

        /// <summary>
        /// last time this setting was modified.
        /// </summary>
        [JsonProperty("modified_on")]
        [JsonConverter(typeof(IsoDateTimeOffsetConverter))]
        public DateTimeOffset? ModifiedOn { get; }
    }
}
