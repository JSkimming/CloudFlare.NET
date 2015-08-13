namespace CloudFlare.NET
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using YamlDotNet.Core;
    using YamlDotNet.Core.Events;
    using YamlDotNet.Serialization;

    internal class CloudFlareYamlTypeConverter : IYamlTypeConverter
    {
        public bool Accepts(Type type)
        {
            if (type == null)
                throw new ArgumentNullException(nameof(type));

            return type == typeof(DateTimeOffset);
        }

        public object ReadYaml(IParser parser, Type type)
        {
            if (parser == null)
                throw new ArgumentNullException(nameof(parser));
            if (type == null)
                throw new ArgumentNullException(nameof(type));

            string date = ((Scalar)parser.Current).Value;
            parser.MoveNext();
            return DateTimeOffset.Parse(date);
        }

        public void WriteYaml(IEmitter emitter, object value, Type type)
        {
            if (emitter == null)
                throw new ArgumentNullException(nameof(emitter));
            if (value == null)
                throw new ArgumentNullException(nameof(value));
            if (type == null)
                throw new ArgumentNullException(nameof(type));

            var date = (DateTimeOffset)value;
            emitter.Emit(new Scalar(date.UtcDateTime.ToString("O")));
        }
    }
}
