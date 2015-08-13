namespace CloudFlare.NET
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Newtonsoft.Json.Linq;
    using YamlDotNet.Core;
    using YamlDotNet.Core.Events;
    using YamlDotNet.Serialization;

    internal class JsonYamlTypeConverter : IYamlTypeConverter
    {
        public bool Accepts(Type type)
        {
            if (type == null)
                throw new ArgumentNullException(nameof(type));

            return type == typeof(JValue);
        }

        public object ReadYaml(IParser parser, Type type)
        {
            if (parser == null)
                throw new ArgumentNullException(nameof(parser));
            if (type == null)
                throw new ArgumentNullException(nameof(type));

            throw new NotImplementedException();
        }

        public void WriteYaml(IEmitter emitter, object value, Type type)
        {
            if (emitter == null)
                throw new ArgumentNullException(nameof(emitter));
            if (value == null)
                throw new ArgumentNullException(nameof(value));
            if (type == null)
                throw new ArgumentNullException(nameof(type));

            var json = (JValue)value;
            emitter.Emit(new Scalar(json.ToString()));
        }
    }
}
