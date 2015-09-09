namespace CloudFlare.NET
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Newtonsoft.Json;

    /// <summary>
    /// CloudFlare security header for a zone.
    /// </summary>
    /// <seealso href="https://api.cloudflare.com/#zone-settings-get-security-header-hsts-setting" />
    public class SettingStrictTransportSecurity
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="SettingStrictTransportSecurity"/> class.
        /// </summary>
        public SettingStrictTransportSecurity(bool enabled, int maxAge, bool includeSubdomains, bool nosniff)
        {
            Enabled = enabled;
            MaxAge = maxAge;
            IncludeSubdomains = includeSubdomains;
            Nosniff = nosniff;
        }

        /// <summary>
        /// Whether or not strict transport security is enabled.
        /// </summary>
        [JsonProperty("enabled")]
        public bool Enabled { get; }

        /// <summary>
        /// Max age in seconds of the strict transport security.
        /// </summary>
        [JsonProperty("max_age")]
        public int MaxAge { get; }

        /// <summary>
        /// Include all subdomains for strict transport security.
        /// </summary>
        [JsonProperty("include_subdomains")]
        public bool IncludeSubdomains { get; }

        /// <summary>
        /// Whether or not to include 'X-Content-Type-Options: nosniff' header.
        /// </summary>
        [JsonProperty("nosniff")]
        public bool Nosniff { get; }
    }
}
