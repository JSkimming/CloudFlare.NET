namespace CloudFlare.NET
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Newtonsoft.Json;
    using Newtonsoft.Json.Linq;

    /// <summary>
    /// Specifies the parameters of the <see cref="IDnsRecordClient.GetDnsRecordsAsync"/> request.
    /// </summary>
    /// <seealso href="https://api.cloudflare.com/#dns-records-for-a-zone-list-dns-records"/>
    public class DnsRecordGetParameters : PagedParameters<DnsRecordOrderTypes>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="DnsRecordGetParameters"/> class.
        /// </summary>
        public DnsRecordGetParameters(
            DnsRecordType? type = null,
            string name = null,
            string content = null,
            int page = 0,
            int perPage = 0,
            DnsRecordOrderTypes order = default(DnsRecordOrderTypes),
            PagedParametersOrderType direction = default(PagedParametersOrderType),
            PagedParametersMatchType match = default(PagedParametersMatchType))
            : base(page, perPage, order, direction, match)
        {
            Type = type;
            Name = name;
            Content = content;
        }

        /// <summary>
        /// DNS record type
        /// </summary>
        [JsonProperty("type")]
        public DnsRecordType? Type { get; }

        /// <summary>
        /// DNS record name.
        /// </summary>
        [JsonProperty("name")]
        public string Name { get; }

        /// <summary>
        /// DNS record content.
        /// </summary>
        [JsonProperty("content")]
        public string Content { get; }

        /// <summary>
        /// Creates a <see cref="DnsRecordGetParameters"/> from the <paramref name="data"/> copying any matching
        /// properties.
        /// </summary>
        public static DnsRecordGetParameters Create(object data)
        {
            if (data == null)
                throw new ArgumentNullException(nameof(data));

            return JObject.FromObject(data).ToObject<DnsRecordGetParameters>();
        }
    }
}
