namespace CloudFlare.NET.Serialization
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    /// <summary>
    /// Implementing this interface provides a mechanism of formatting an object before conversion to a JSON.NET DOM.
    /// </summary>
    public interface IPreJsonFormatter
    {
        /// <summary>
        /// Returns <see langword="true"/> if this <see cref="IPreJsonFormatter"/> accepts entities of the specified
        /// <paramref name="type"/>; otherwise <see langword="false"/>.
        /// </summary>
        bool Accepts(Type type);

        /// <summary>
        /// Allows for pre-formatting of the <paramref name="value"/>.
        /// </summary>
        /// <returns>The new value or the same <paramref name="value"/> if updated.</returns>
        object PreFormat(object value, Type type);
    }
}
