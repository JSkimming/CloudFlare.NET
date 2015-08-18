namespace CloudFlare.NET.Serialization
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Newtonsoft.Json.Linq;

    /// <summary>
    /// Abstract implementation of implementation of <see cref="IPostJsonFormatter"/> to provided type checking.
    /// </summary>
    /// <typeparam name="T">The type of the entity to format.</typeparam>
    public abstract class TypedJsonFormatter<T> : IPostJsonFormatter
        where T : class
    {
        /// <summary>
        /// Returns <see langword="true"/> if the <paramref name="type"/> is <typeparamref name="T"/>; otherwise
        /// <see langword="false"/>.
        /// </summary>
        public virtual bool Accepts(Type type)
        {
            if (type == null)
                throw new ArgumentNullException(nameof(type));

            return type == typeof(T);
        }

        /// <summary>
        /// Casts the <paramref name="value"/> to <typeparamref name="T"/> and calls the typed
        /// <see cref="PostFormat(JObject, T)"/> equivalent.
        /// </summary>
        public virtual JObject PostFormat(JObject json, object value, Type type)
        {
            if (json == null)
                throw new ArgumentNullException(nameof(json));
            if (value == null)
                throw new ArgumentNullException(nameof(value));
            if (type == null)
                throw new ArgumentNullException(nameof(type));

            return PostFormat(json, (T)value);
        }

        /// <summary>
        /// Allows for post-formatting of the <paramref name="value"/>.
        /// </summary>
        protected virtual JObject PostFormat(JObject json, T value)
        {
            if (json == null)
                throw new ArgumentNullException(nameof(json));
            if (value == null)
                throw new ArgumentNullException(nameof(value));

            return json;
        }
    }
}
