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
    public class SettingSecurityHeader
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="SettingSecurityHeader"/> class.
        /// </summary>
        public SettingSecurityHeader(SettingStrictTransportSecurity strictTransportSecurity)
        {
            if (strictTransportSecurity == null)
                throw new ArgumentNullException(nameof(strictTransportSecurity));

            StrictTransportSecurity = strictTransportSecurity;
        }

        /// <summary>
        /// Whether or not strict transport security is enabled.
        /// </summary>
        [JsonProperty("strict_transport_security")]
        public SettingStrictTransportSecurity StrictTransportSecurity { get; }
    }
}
