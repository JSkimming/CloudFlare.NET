namespace CloudFlare.NET
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    /// <summary>
    /// Constants for CloudFlare.
    /// </summary>
    public static class CloudFlareConstants
    {
        /// <summary>
        /// Gets the base address of the CloudFlare API.
        /// </summary>
        /// <seealso href="https://api.cloudflare.com/#endpoints"/>
        public static Uri BaseUri { get; } = new Uri("https://api.cloudflare.com/client/v4/", UriKind.Absolute);
    }
}
