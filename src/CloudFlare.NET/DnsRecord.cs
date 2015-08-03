namespace CloudFlare.NET
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Newtonsoft.Json;
    using Newtonsoft.Json.Linq;

    /// <summary>
    /// Represents a DNS record for a <see cref="Zone"/>.
    /// </summary>
    /// <seealso href="https://api.cloudflare.com/#dns-records-for-a-zone-properties"/>
    public class DnsRecord
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="DnsRecord"/> class.
        /// </summary>
        public DnsRecord(
            IdentifierTag id,
            DnsRecordType type,
            string name,
            bool proxiable,
            bool proxied,
            int ttl,
            bool locked,
            IdentifierTag zoneId,
            DateTimeOffset createdOn,
            DateTimeOffset modifiedOn,
            int priority,
            string content = null,
            string zoneName = null,
            JObject data = null,
            JObject meta = null)
        {
            if (id == null)
                throw new ArgumentNullException(nameof(id));
            if (name == null)
                throw new ArgumentNullException(nameof(name));
            if (zoneId == null)
                throw new ArgumentNullException(nameof(zoneId));

            Id = id;
            Type = type;
            Name = name;
            Content = content ?? string.Empty;
            Proxiable = proxiable;
            Proxied = proxied;
            Ttl = ttl;
            Locked = locked;
            ZoneId = zoneId;
            ZoneName = zoneName ?? string.Empty;
            CreatedOn = createdOn;
            ModifiedOn = modifiedOn;
            Data = data ?? new JObject();
            Meta = meta ?? new JObject();
            Priority = priority;
        }

        /// <summary>
        /// API item identifier tag.
        /// </summary>
        [JsonProperty("id")]
        public IdentifierTag Id { get; }

        /// <summary>
        /// Record type.
        /// </summary>
        [JsonProperty("type")]
        public DnsRecordType Type { get; }

        /// <summary>
        /// A valid host name.
        /// </summary>
        [JsonProperty("name")]
        public string Name { get; }

        /// <summary>
        /// Valid content for the given <see cref="Type"/>.
        /// </summary>
        [JsonProperty("content")]
        public string Content { get; }

        /// <summary>
        /// Whether the record can be proxied by CloudFlare or not.
        /// </summary>
        [JsonProperty("proxiable")]
        public bool Proxiable { get; }

        /// <summary>
        /// Whether the record is receiving the performance and security benefits of CloudFlare
        /// </summary>
        [JsonProperty("proxied")]
        public bool Proxied { get; }

        /// <summary>
        /// Time to live for DNS record. Value of 1 is 'automatic'.
        /// </summary>
        [JsonProperty("ttl")]
        public int Ttl { get; }

        /// <summary>
        /// Whether this record can be modified/deleted (<see langword="true"/> means it's managed by CloudFlare).
        /// </summary>
        [JsonProperty("locked")]
        public bool Locked { get; }

        /// <summary>
        /// API item identifier tag.
        /// </summary>
        [JsonProperty("zone_id")]
        public IdentifierTag ZoneId { get; }

        /// <summary>
        /// The domain of the record.
        /// </summary>
        [JsonProperty("zone_name")]
        public string ZoneName { get; }

        /// <summary>
        /// When the record was created.
        /// </summary>
        [JsonProperty("created_on")]
        public DateTimeOffset CreatedOn { get; }

        /// <summary>
        /// When the record was last modified.
        /// </summary>
        [JsonProperty("modified_on")]
        public DateTimeOffset ModifiedOn { get; }

        /// <summary>
        /// Metadata about the record.
        /// </summary>
        [JsonProperty("data")]
        public JObject Data { get; }

        /// <summary>
        /// Extra CloudFlare-specific information about the record.
        /// </summary>
        [JsonProperty("meta")]
        public JObject Meta { get; }

        /// <summary>
        /// The priority of this is a <see cref="DnsRecordType.MX"/> record.
        /// </summary>
        [JsonProperty("priority")]
        public int Priority { get; }
    }
}
