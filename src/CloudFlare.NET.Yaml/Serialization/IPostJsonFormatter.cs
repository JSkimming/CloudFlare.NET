namespace CloudFlare.NET.Serialization
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Newtonsoft.Json.Linq;

    /// <summary>
    /// Implementing this interface provides a mechanism of formatting an object after conversion to a JSON.NET DOM.
    /// </summary>
    public interface IPostJsonFormatter
    {
        /// <summary>
        /// Returns <see langword="true"/> if this <see cref="IPostJsonFormatter"/> accepts entities of the specified
        /// <paramref name="type"/>; otherwise <see langword="false"/>.
        /// </summary>
        bool Accepts(Type type);

        /// <summary>
        /// Allows for post-formatting of the <paramref name="value"/>.
        /// </summary>
        JObject PostFormat(JObject json, object value, Type type);
    }
}
