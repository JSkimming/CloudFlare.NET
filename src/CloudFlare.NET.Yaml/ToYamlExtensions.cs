namespace CloudFlare.NET
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using CloudFlare.NET.Serialization;
    using Newtonsoft.Json.Linq;
    using YamlDotNet.Serialization;

    /// <summary>
    /// Extension methods to convert CloudFlare objects to YAML.
    /// </summary>
    public static class ToYamlExtensions
    {
        /// <summary>
        /// Returns the YAML representation of a collection of <see cref="DnsRecord"/>.
        /// </summary>
        /// <typeparam name="TWriter">The type of the <paramref name="writer"/>.</typeparam>
        /// <returns>The <paramref name="writer"/> to allow for fluent usage.</returns>
        public static TWriter SerializeYaml<TWriter>(
            this TWriter writer,
            IEnumerable<DnsRecord> dnsRecords,
            string containerName = null)
            where TWriter : TextWriter
        {
            if (writer == null)
                throw new ArgumentNullException(nameof(writer));
            if (dnsRecords == null)
                throw new ArgumentNullException(nameof(dnsRecords));

            var formatter = new YamlJsonFormatter();

            JToken jsonRecords = JArray.FromObject(dnsRecords.Select(formatter.Process));

            if (!string.IsNullOrWhiteSpace(containerName))
            {
                jsonRecords = new JObject(new JProperty(containerName, jsonRecords));
            }

            var serializer = new Serializer(SerializationOptions.DisableAliases);
            serializer.RegisterTypeConverter(new JsonYamlTypeConverter());
            serializer.Serialize(writer, jsonRecords);

            return writer;
        }

        /// <summary>
        /// Returns the YAML representation of a <see cref="Zone"/>.
        /// </summary>
        /// <typeparam name="TWriter">The type of the <paramref name="writer"/>.</typeparam>
        /// <returns>The <paramref name="writer"/> to allow for fluent usage.</returns>
        public static TWriter SerializeYaml<TWriter>(this TWriter writer, Zone zone)
            where TWriter : TextWriter
        {
            if (writer == null)
                throw new ArgumentNullException(nameof(writer));
            if (zone == null)
                throw new ArgumentNullException(nameof(zone));

            var formatter = new YamlJsonFormatter();

            JObject jObject = formatter.Process(zone);

            var serializer = new Serializer(SerializationOptions.DisableAliases);
            serializer.RegisterTypeConverter(new JsonYamlTypeConverter());
            serializer.Serialize(writer, jObject);

            return writer;
        }

        /// <summary>
        /// Returns the YAML representation of a collection of <see cref="DnsRecord"/>.
        /// </summary>
        public static string ToYaml(this IEnumerable<DnsRecord> dnsRecords, string containerName = null)
        {
            if (dnsRecords == null)
                throw new ArgumentNullException(nameof(dnsRecords));

            var writer = new StringWriter();

            return writer.SerializeYaml(dnsRecords, containerName).ToString();
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
