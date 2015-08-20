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
        public YamlJsonFormatter(
            IEnumerable<IPreJsonFormatter> customPreFormatters = null,
            IEnumerable<IPostJsonFormatter> customPostFormatters = null)
        {
            PreFormatters = customPreFormatters == null ? DefaultPreFormatters : customPreFormatters.ToList();
            PostFormatters = customPostFormatters == null ? DefaultPostFormatters : customPostFormatters.ToList();
        }

        /// <summary>
        /// The default pre-formatters.
        /// </summary>
        public static IReadOnlyList<IPreJsonFormatter> DefaultPreFormatters { get; } =
            new IPreJsonFormatter[]
            {
            };

        /// <summary>
        /// The default post-formatters.
        /// </summary>
        public static IReadOnlyList<IPostJsonFormatter> DefaultPostFormatters { get; } =
            new IPostJsonFormatter[]
            {
                new StandardNonconfigurablePropertyFormatter(),
                new ZoneFormatter(),
                new DnsRecordFormatter(),
            };

        /// <summary>
        /// The pre-formatters.
        /// </summary>
        public IReadOnlyList<IPreJsonFormatter> PreFormatters { get; }

        /// <summary>
        /// The post-formatters.
        /// </summary>
        public IReadOnlyList<IPostJsonFormatter> PostFormatters { get; }

        /// <summary>
        /// Processes the value into a <see cref="JObject"/>.
        /// </summary>
        /// <param name="value">The value to process.</param>
        public JObject Process(object value)
        {
            if (value == null)
                throw new ArgumentNullException(nameof(value));

            var valueType = value.GetType();

            // Perform an pre-formatting of the value.
            value = PreFormatters.Where(f => f.Accepts(valueType))
                .Aggregate(value, (current, f) => f.PreFormat(current, valueType));

            JObject json = JObject.FromObject(value);

            // Perform an post-formatting of the json.
            return PostFormatters.Where(f => f.Accepts(valueType))
                .Aggregate(json, (current, f) => f.PostFormat(current, value, valueType));
        }
    }
}
