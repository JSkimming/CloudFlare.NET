namespace CloudFlare.NET
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using Newtonsoft.Json.Linq;
    using YamlDotNet.Serialization;

    /// <summary>
    /// Extension methods to convert CloudFlare objects to YAML.
    /// </summary>
    public static class ToYamlExtensions
    {
        /// <summary>
        /// Returns the YAML representation of a <see cref="Zone"/>.
        /// </summary>
        /// <typeparam name="TWriter">The type of the <paramref name="writer"/>.</typeparam>
        /// <returns>The <paramref name="writer"/> to allow for fluent usage.</returns>
        public static TWriter SerializeYaml<TWriter>(this TWriter writer, Zone zone)
            where TWriter : TextWriter
        {
            if (zone == null)
                throw new ArgumentNullException(nameof(zone));
            if (writer == null)
                throw new ArgumentNullException(nameof(writer));

            var jObject = JObject.FromObject(zone);
            var serializer = new Serializer();
            ////serializer.RegisterTypeConverter(new CloudFlareYamlTypeConverter());
            serializer.RegisterTypeConverter(new JsonYamlTypeConverter());
            serializer.Serialize(writer, jObject);

            return writer;
        }

        /// <summary>
        /// Returns the YAML representation of a <see cref="Zone"/>.
        /// </summary>
        public static string ToYaml(this Zone zone)
        {
            if (zone == null)
                throw new ArgumentNullException(nameof(zone));

            var writer = new StringWriter();

            return writer.SerializeYaml(zone).ToString();
        }
    }
}
