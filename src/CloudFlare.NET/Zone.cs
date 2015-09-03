namespace CloudFlare.NET
{
    using System;
    using System.Collections.Generic;
    using System.Diagnostics;
    using System.Linq;
    using Newtonsoft.Json;

    /// <summary>
    /// A Zone is a domain name along with its subdomains and other identities.
    /// </summary>
    /// <seealso href="https://api.cloudflare.com/#zone-properties"/>
    [DebuggerDisplay("{DebuggerDisplay,nq}")]
    public class Zone : IIdentifier, IModified
    {
        private static readonly IReadOnlyList<string> EmptyStrings = new string[0];

        /// <summary>
        /// Initializes a new instance of the <see cref="Zone"/> class.
        /// </summary>
        public Zone(
            IdentifierTag id,
            DateTimeOffset? createdOn,
            DateTimeOffset modifiedOn,
            string name,
            int developmentMode,
            IReadOnlyList<string> originalNameServers = null,
            string originalRegistrar = null,
            string originalDnshost = null,
            IReadOnlyList<string> nameServers = null,
            ZoneStatusType status = ZoneStatusType.active)
        {
            if (id == null)
                throw new ArgumentNullException(nameof(id));
            if (string.IsNullOrWhiteSpace(name))
                throw new ArgumentNullException(nameof(name));

            Id = id;
            CreatedOn = createdOn;
            ModifiedOn = modifiedOn;
            Name = name;
            DevelopmentMode = developmentMode;
            OriginalNameServers = originalNameServers ?? EmptyStrings;
            OriginalRegistrar = originalRegistrar ?? string.Empty;
            OriginalDnshost = originalDnshost ?? string.Empty;
            NameServers = nameServers ?? EmptyStrings;
            Status = status;
        }

        /// <summary>
        /// API item identifier tag.
        /// </summary>
        public IdentifierTag Id { get; }

        /// <summary>
        /// When the zone was created.
        /// </summary>
        public DateTimeOffset? CreatedOn { get; }

        /// <summary>
        /// When the zone was last modified.
        /// </summary>
        public DateTimeOffset ModifiedOn { get; }

        /// <summary>
        /// The domain name.
        /// </summary>
        [JsonProperty("name")]
        public string Name { get; }

        /// <summary>
        /// The interval (in seconds) from when development mode expires (positive integer) or last expired (negative
        /// integer) for the domain. If development mode has never been enabled, this value is 0.
        /// </summary>
        [JsonProperty("development_mode")]
        public int DevelopmentMode { get; }

        /// <summary>
        /// Original name servers before moving to CloudFlare.
        /// </summary>
        [JsonProperty("original_name_servers")]
        public IReadOnlyList<string> OriginalNameServers { get; }

        /// <summary>
        /// Registrar for the domain at the time of switching to CloudFlare.
        /// </summary>
        [JsonProperty("original_registrar")]
        public string OriginalRegistrar { get; }

        /// <summary>
        /// DNS host at the time of switching to CloudFlare.
        /// </summary>
        [JsonProperty("original_dnshost")]
        public string OriginalDnshost { get; }

        /// <summary>
        /// CloudFlare-assigned name servers. This is only populated for zones that use CloudFlare DNS.
        /// </summary>
        [JsonProperty("name_servers")]
        public IReadOnlyList<string> NameServers { get; }

        /// <summary>
        /// Status of the zone.
        /// </summary>
        [JsonProperty("status")]
        public ZoneStatusType Status { get; }

        private string DebuggerDisplay => $"{GetType().Name}: {Name}";
    }
}
