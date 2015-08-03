namespace CloudFlare.NET
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    /// <summary>
    /// Represents the authorization parameters for accessing the CloudFlare API.
    /// </summary>
    /// <seealso href="https://api.cloudflare.com/#requests"/>
    public class CloudFlareAuth
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="CloudFlareAuth"/> class.
        /// </summary>
        public CloudFlareAuth(string email, string key)
        {
            if (string.IsNullOrWhiteSpace(email))
                throw new ArgumentNullException(nameof(email));
            if (string.IsNullOrWhiteSpace(key))
                throw new ArgumentNullException(nameof(key));

            Email = email;
            Key = key;
        }

        /// <summary>
        /// Gets the Email address associated with your account.
        /// </summary>
        public string Email { get; }

        /// <summary>
        /// Gets the API key generated on the "My Account" page.
        /// </summary>
        public string Key { get; }
    }
}
