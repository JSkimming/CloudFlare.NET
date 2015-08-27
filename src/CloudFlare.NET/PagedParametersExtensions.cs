namespace CloudFlare.NET
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using Newtonsoft.Json;
    using Newtonsoft.Json.Linq;

    /// <summary>
    /// Extension methinks on paged parameter objects.
    /// </summary>
    public static class PagedParametersExtensions
    {
        /// <summary>
        /// <para>Converts the <paramref name="parameters"/> to their equivalent key value pair representation.</para>
        /// <para>NOTE. Default values are excluded</para>
        /// </summary>
        /// <typeparam name="TOrder">The type of the <see cref="PagedParameters{TOrder}.Order"/> property.</typeparam>
        public static IEnumerable<KeyValuePair<string, string>> ToKvp<TOrder>(this PagedParameters<TOrder> parameters)
            where TOrder : struct
        {
            if (parameters == null)
                throw new ArgumentNullException(nameof(parameters));

            // Remove default values to ensure they're not passed as parameters.
            JsonSerializer serializer = JsonSerializer.CreateDefault(new JsonSerializerSettings
            {
                DefaultValueHandling = DefaultValueHandling.Ignore,
            });

            JObject json = JObject.FromObject(parameters, serializer);

            return
                ((IDictionary<string, JToken>)json).Select(
                    kvp => new KeyValuePair<string, string>(kvp.Key, kvp.Value.Value<string>()));
        }

        /// <summary>
        /// <para>Converts the <paramref name="parameters"/> to their equivalent query string representation.</para>
        /// <para>NOTE. Default values are excluded</para>
        /// </summary>
        /// <typeparam name="TOrder">The type of the <see cref="PagedParameters{TOrder}.Order"/> property.</typeparam>
        public static string ToQuery<TOrder>(this PagedParameters<TOrder> parameters)
            where TOrder : struct
        {
            IEnumerable<KeyValuePair<string, string>> keyValuePairs = parameters.ToKvp();

            StringBuilder stringBuilder = new StringBuilder();
            foreach (KeyValuePair<string, string> keyValuePair in keyValuePairs)
            {
                if (stringBuilder.Length > 0)
                    stringBuilder.Append('&');
                stringBuilder.Append(Uri.EscapeDataString(keyValuePair.Key));
                stringBuilder.Append('=');
                stringBuilder.Append(Uri.EscapeDataString(keyValuePair.Value));
            }

            return stringBuilder.ToString();
        }
    }
}
