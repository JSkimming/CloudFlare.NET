namespace CloudFlare.NET
{
    using System;
    using System.Collections.Generic;
    using System.Configuration;
    using System.Linq;

    internal static class Helper
    {
        public static string AuthEmail { get; } = Environment.GetEnvironmentVariable("CloudFlare.NET.AuthEmail");

        public static string AuthKey { get; } = Environment.GetEnvironmentVariable("CloudFlare.NET.AuthKey");

        /// <summary>
        /// Gets the setting my the <paramref name="name"/>.
        /// </summary>
        /// <param name="name">The name of the setting.</param>
        /// <returns>The setting my the <paramref name="name"/>.</returns>
        public static string GetSetting(string name)
        {
            if (name == null)
                throw new ArgumentNullException(nameof(name));

            return ("True".Equals(Environment.GetEnvironmentVariable("APPVEYOR"), StringComparison.OrdinalIgnoreCase)
                ? Environment.GetEnvironmentVariable(name)
                : ConfigurationManager.AppSettings[name])
                   ?? string.Empty;
        }
    }
}
