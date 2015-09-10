namespace CloudFlare.NET
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading;
    using System.Threading.Tasks;

    /// <summary>
    /// The CloudFlare Zone Settings API Client.
    /// </summary>
    /// <seealso href="https://api.cloudflare.com/#zone-settings"/>
    public interface IZoneSettingsClient
    {
        /// <summary>
        /// Gets the zone settings for the zone with the specified <paramref name="zoneId"/>.
        /// </summary>
        /// <seealso href="https://api.cloudflare.com/#zone-settings-get-all-zone-settings"/>
        Task<IEnumerable<ZoneSettingBase>> GetAllZoneSettingsAsync(
            IdentifierTag zoneId,
            CancellationToken cancellationToken,
            CloudFlareAuth auth = null);

        /// <summary>
        /// Advanced protection from Distributed Denial of Service (DDoS) attacks on your website.
        /// This is an uneditable value that is 'on' in the case of Business and Enterprise zones
        /// </summary>
        /// <seealso href="https://api.cloudflare.com/#zone-settings-get-advanced-ddos-setting"/>
        Task<ZoneSetting<SettingOnOffTypes>> GetAdvancedDdosSettingAsync(
            IdentifierTag zoneId,
            CancellationToken cancellationToken,
            CloudFlareAuth auth = null);

        /// <summary>
        /// When enabled, Always Online will serve pages from our cache if your server is offline.
        /// </summary>
        /// <seealso href="https://api.cloudflare.com/#zone-settings-get-always-online-setting"/>
        Task<ZoneSetting<SettingOnOffTypes>> GetAlwaysOnlineSettingAsync(
            IdentifierTag zoneId,
            CancellationToken cancellationToken,
            CloudFlareAuth auth = null);
    }
}
