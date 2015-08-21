namespace CloudFlare.NET.Serialization
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Reflection;
    using Newtonsoft.Json.Linq;

    /// <summary>
    /// Abstract implementation of implementation of <see cref="IPreJsonFormatter"/> and
    /// <see cref="IPostJsonFormatter"/> to provided type checking.
    /// </summary>
    /// <typeparam name="T">The type of the entity to format.</typeparam>
    public abstract class TypedJsonFormatter<T> : IPreJsonFormatter, IPostJsonFormatter
        where T : class
    {
        /// <summary>
        /// Returns <see langword="true"/> if the <paramref name="type"/> <see cref="TypeInfo.IsAssignableFrom"/>
        /// the <typeparamref name="T"/>; otherwise <see langword="false"/>.
        /// </summary>
        public virtual bool Accepts(Type type)
        {
            if (type == null)
                throw new ArgumentNullException(nameof(type));

            return typeof(T).GetTypeInfo().IsAssignableFrom(type.GetTypeInfo());
        }

        /// <summary>
        /// Casts the <paramref name="value"/> to <typeparamref name="T"/> and calls the typed
        /// <see cref="PreFormat(T)"/> equivalent.
        /// </summary>
        public object PreFormat(object value, Type type)
        {
            if (value == null)
                throw new ArgumentNullException(nameof(value));
            if (type == null)
                throw new ArgumentNullException(nameof(type));

            return PreFormat((T)value);
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
        /// Allows for pre-formatting of the <paramref name="value"/>.
        /// </summary>
        /// <returns>The <paramref name="value"/>.</returns>
        protected virtual T PreFormat(T value)
        {
            if (value == null)
                throw new ArgumentNullException(nameof(value));

            return value;
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
