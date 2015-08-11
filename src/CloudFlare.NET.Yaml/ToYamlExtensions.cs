namespace CloudFlare.NET
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    /// <summary>
    /// Extension methods to convert CloudFlare objects to YAML.
    /// </summary>
    public static class ToYamlExtensions
    {
        /// <summary>
        /// Returns the YAML representation of a <see cref="Zone"/>.
        /// </summary>
        public static string ToYaml(Zone zone)
        {
            if (zone == null)
                throw new ArgumentNullException(nameof(zone));

            throw new NotImplementedException();
        }
    }
}
