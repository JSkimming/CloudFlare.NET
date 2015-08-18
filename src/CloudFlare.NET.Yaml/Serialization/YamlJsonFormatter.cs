namespace CloudFlare.NET.Serialization
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Newtonsoft.Json.Linq;

    /// <summary>
    /// Formats the JSON of entities prior to conversion to YAML.
    /// </summary>
    public class YamlJsonFormatter
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="YamlJsonFormatter"/> class.
        /// </summary>
        public YamlJsonFormatter(IEnumerable<IPostJsonFormatter> additionalPostFormatters = null)
        {
            PostFormatters =
                DefaultPostFormatters
                    .Union(additionalPostFormatters ?? Enumerable.Empty<IPostJsonFormatter>())
                    .ToList();
        }

        /// <summary>
        /// The default formatters.
        /// </summary>
        public static IReadOnlyList<IPostJsonFormatter> DefaultPostFormatters { get; } =
            new IPostJsonFormatter[]
            {
                new StandardNonconfigurablePropertyFormatter(),
                new ZoneFormatter(),
                new DnsRecordFormatter(),
            };

        /// <summary>
        /// The formatters.
        /// </summary>
        public List<IPostJsonFormatter> PostFormatters { get; }

        /// <summary>
        /// Processes the value into a <see cref="JObject"/>.
        /// </summary>
        /// <typeparam name="T">The type of the object to process, the <paramref name="value"/> can potentially derive
        /// <typeparamref name="T"/>.</typeparam>
        /// <param name="value">The value to process.</param>
        public JObject Process<T>(T value)
            where T : class
        {
            if (value == null)
                throw new ArgumentNullException(nameof(value));

            JObject json = JObject.FromObject(value);

            List<IPostJsonFormatter> formatters = PostFormatters.Where(f => f.Accepts(typeof(T))).ToList();

            foreach (IPostJsonFormatter formatter in formatters)
            {
                formatter.PostFormat(json, value, typeof(T));
            }

            return json;
        }
    }
}
