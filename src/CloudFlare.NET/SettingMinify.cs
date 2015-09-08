namespace CloudFlare.NET
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Newtonsoft.Json;

    /// <summary>
    /// Automatically minify certain assets for your website.
    /// </summary>
    /// <seealso href="https://api.cloudflare.com/#zone-settings-get-minify-setting" />
    public class SettingMinify
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="SettingMinify"/> class.
        /// </summary>
        public SettingMinify(SettingOnOffTypes css, SettingOnOffTypes html, SettingOnOffTypes js)
        {
            Css = css;
            Html = html;
            Js = js;
        }

        /// <summary>
        /// Automatically minify all CSS for your website.
        /// </summary>
        [JsonProperty("css")]
        public SettingOnOffTypes Css { get; }

        /// <summary>
        /// Automatically minify all HTML for your website.
        /// </summary>
        [JsonProperty("html")]
        public SettingOnOffTypes Html { get; }

        /// <summary>
        /// Automatically minify all JavaScript for your website.
        /// </summary>
        [JsonProperty("js")]
        public SettingOnOffTypes Js { get; }
    }
}
