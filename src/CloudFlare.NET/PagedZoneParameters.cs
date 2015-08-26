namespace CloudFlare.NET
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Newtonsoft.Json;
    using Newtonsoft.Json.Linq;

    /// <summary>
    /// Specifies the parameters of the get zone request.
    /// </summary>
    /// <seealso href="https://api.cloudflare.com/#zone-list-zones"/>
    public class PagedZoneParameters : PagedParameters<PagedZoneOrderFieldTypes>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="PagedZoneParameters"/> class.
        /// </summary>
        public PagedZoneParameters(
            string name = null,
            ZoneStatusType? status = null,
            int page = 0,
            int perPage = 0,
            PagedZoneOrderFieldTypes order = default(PagedZoneOrderFieldTypes),
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
        /// Creates a <see cref="PagedZoneParameters"/> from the <paramref name="data"/> copying any matching
        /// properties.
        /// </summary>
        public static PagedZoneParameters Create(object data)
        {
            if (data == null)
                throw new ArgumentNullException(nameof(data));

            return JObject.FromObject(data).ToObject<PagedZoneParameters>();
        }
    }
}
