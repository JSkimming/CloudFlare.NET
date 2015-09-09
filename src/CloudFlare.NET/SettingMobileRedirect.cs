namespace CloudFlare.NET
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Newtonsoft.Json;

    /// <summary>
    /// Automatically redirect visitors on mobile devices to a mobile-optimized subdomain.
    /// </summary>
    /// <seealso href="https://api.cloudflare.com/#zone-settings-get-mobile-redirect-setting" />
    public class SettingMobileRedirect
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="SettingMobileRedirect"/> class.
        /// </summary>
        public SettingMobileRedirect(SettingOnOffTypes status, string mobileSubdomain = null, bool stripUri = false)
        {
            Status = status;
            MobileSubdomain = mobileSubdomain ?? string.Empty;
            StripUri = stripUri;
        }

        /// <summary>
        /// Automatically minify all CSS for your website.
        /// </summary>
        [JsonProperty("status")]
        public SettingOnOffTypes Status { get; }

        /// <summary>
        /// Automatically minify all HTML for your website.
        /// </summary>
        [JsonProperty("mobile_subdomain")]
        public string MobileSubdomain { get; }

        /// <summary>
        /// Automatically minify all JavaScript for your website.
        /// </summary>
        [JsonProperty("strip_uri")]
        public bool StripUri { get; }
    }
}
