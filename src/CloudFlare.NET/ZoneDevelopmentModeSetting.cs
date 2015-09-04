namespace CloudFlare.NET
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Newtonsoft.Json;

    /// <summary>
    /// Development Mode temporarily allows you to enter development mode for your websites if you need to make changes
    /// to your site. This will bypass CloudFlare's accelerated cache and slow down your site, but is useful if you are
    /// making changes to cacheable content (like images, css, or JavaScript) and would like to see those changes right
    /// away. Once entered, development mode will last for 3 hours and then automatically toggle off.
    /// </summary>
    /// <seealso href="https://api.cloudflare.com/#zone-settings-get-development-mode-setting"/>
    public class ZoneDevelopmentModeSetting : ZoneSetting<SettingOnOffTypes>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ZoneDevelopmentModeSetting"/> class.
        /// </summary>
        public ZoneDevelopmentModeSetting(
            string id,
            SettingOnOffTypes value,
            bool editable,
            DateTimeOffset? modifiedOn,
            int timeRemaining)
            : base(id, value, editable, modifiedOn)
        {
            TimeRemaining = timeRemaining;
        }

        /// <summary>
        /// The interval (in seconds) from when development mode expires (positive integer) or last expired (negative
        /// integer) for the domain. If development mode has never been enabled, this value is false.
        /// </summary>
        [JsonProperty("time_remaining")]
        public int TimeRemaining { get; }
    }
}
