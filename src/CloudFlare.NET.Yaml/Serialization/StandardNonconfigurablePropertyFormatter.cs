namespace CloudFlare.NET.Serialization
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Reflection;
    using Newtonsoft.Json.Linq;

    /// <summary>
    /// Removes the standard non configurable properties.
    /// </summary>
    public class StandardNonconfigurablePropertyFormatter : IPostJsonFormatter
    {
        /// <summary>
        /// Returns <see langword="true"/> if the <paramref name="type"/> has standard non-configurable properties;
        /// otherwise <see langword="false"/>.
        /// </summary>
        public bool Accepts(Type type)
        {
            if (type == null)
                throw new ArgumentNullException(nameof(type));

            TypeInfo info = type.GetTypeInfo();
            return typeof(IIdentifier).GetTypeInfo().IsAssignableFrom(info)
                   || typeof(IModified).GetTypeInfo().IsAssignableFrom(info);
        }

        /// <summary>
        /// Removes the standard non configurable properties.
        /// </summary>
        public JObject PostFormat(JObject json, object value, Type type)
        {
            if (json == null)
                throw new ArgumentNullException(nameof(json));
            if (value == null)
                throw new ArgumentNullException(nameof(value));
            if (type == null)
                throw new ArgumentNullException(nameof(type));

            if (value is IIdentifier)
                json.Remove("id");

            if (value is IModified)
                json.Remove(new[] { "created_on", "modified_on" });

            return json;
        }
    }
}
