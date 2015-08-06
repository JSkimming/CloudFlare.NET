namespace CloudFlare.NET
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Newtonsoft.Json;

    /// <summary>
    /// A Zone is a domain name along with its subdomains and other identities.
    /// </summary>
    /// <seealso href="https://api.cloudflare.com/#zone-properties"/>
    public class Zone
    {
        private static readonly IReadOnlyList<string> EmptyStrings = Enumerable.Empty<string>().ToArray();

        /// <summary>
        /// Initializes a new instance of the <see cref="Zone"/> class.
        /// </summary>
        public Zone(
            IdentifierTag id,
            string name,
            int developmentMode,
            DateTimeOffset? createdOn,
            DateTimeOffset modifiedOn,
            IReadOnlyList<string> originalNameServers = null,
            string originalRegistrar = null,
            string originalDnshost = null,
            IReadOnlyList<string> nameServers = null)
        {
            if (id == null)
                throw new ArgumentNullException(nameof(id));
            if (string.IsNullOrWhiteSpace(name))
                throw new ArgumentNullException(nameof(name));

            Id = id;
            Name = name;
            DevelopmentMode = developmentMode;
            OriginalNameServers = originalNameServers ?? EmptyStrings;
            OriginalRegistrar = originalRegistrar ?? string.Empty;
            OriginalDnshost = originalDnshost ?? string.Empty;
            CreatedOn = createdOn;
            ModifiedOn = modifiedOn;
            NameServers = nameServers ?? EmptyStrings;
        }

        /// <summary>
        /// API item identifier tag.
        /// </summary>
        [JsonProperty("id")]
        public IdentifierTag Id { get; }

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
        /// When the zone was created.
        /// </summary>
        [JsonProperty("created_on")]
        public DateTimeOffset? CreatedOn { get; }

        /// <summary>
        /// When the zone was last modified.
        /// </summary>
        [JsonProperty("modified_on")]
        public DateTimeOffset ModifiedOn { get; }

        /// <summary>
        /// CloudFlare-assigned name servers. This is only populated for zones that use CloudFlare DNS.
        /// </summary>
        [JsonProperty("name_servers")]
        public IReadOnlyList<string> NameServers { get; }
    }
}
