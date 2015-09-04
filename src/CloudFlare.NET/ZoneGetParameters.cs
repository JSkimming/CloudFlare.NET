namespace CloudFlare.NET
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Newtonsoft.Json;
    using Newtonsoft.Json.Linq;

    /// <summary>
    /// Specifies the parameters of the <see cref="IZoneClient.GetZonesAsync"/> request.
    /// </summary>
    /// <seealso href="https://api.cloudflare.com/#zone-list-zones"/>
    public class ZoneGetParameters : PagedParameters<ZoneOrderTypes>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ZoneGetParameters"/> class.
        /// </summary>
        public ZoneGetParameters(
            string name = null,
            ZoneStatusType? status = null,
            int page = 0,
            int perPage = 0,
            ZoneOrderTypes order = default(ZoneOrderTypes),
            PagedParametersOrderType direction = default(PagedParametersOrderType),
            PagedParametersMatchType match = default(PagedParametersMatchType))
            : base(page, perPage, order, direction, match)
        {
            Name = name;
            Status = status;
        }

        /// <summary>
        /// A domain name.
        /// </summary>
        [JsonProperty("name")]
        public string Name { get; }

        /// <summary>
        /// Status of the zone
        /// </summary>
        [JsonProperty("status")]
        public ZoneStatusType? Status { get; }

        /// <summary>
        /// Creates a <see cref="ZoneGetParameters"/> from the <paramref name="data"/> copying any matching
        /// properties.
        /// </summary>
        public static ZoneGetParameters Create(object data)
        {
            if (data == null)
                throw new ArgumentNullException(nameof(data));

            return JObject.FromObject(data).ToObject<ZoneGetParameters>();
        }
    }
}
