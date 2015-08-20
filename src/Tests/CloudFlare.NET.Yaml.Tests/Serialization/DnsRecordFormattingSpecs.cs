namespace CloudFlare.NET.Serialization.DnsRecordSpec
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Machine.Specifications;
    using Newtonsoft.Json.Linq;
    using Ploeh.AutoFixture;

    [Subject(typeof(DnsRecord))]
    public class When_formatting : FixtureContext
    {
        protected static JObject _json;
        static YamlJsonFormatter _formatter;
        static DnsRecord _source;

        Establish context = () =>
        {
            _formatter = new YamlJsonFormatter();
            _source = _fixture.Create<DnsRecord>();
        };

        Because of = () => _json = _formatter.Process(_source);

        Behaves_like<IdentifierFormattingBehavior> identifier_formatting_behavior;

        Behaves_like<ModifiedFormattingBehavior> modified_formatting_behavior;

        It should_serialize_name = () => _json["name"].Value<string>().ShouldEqual(_source.Name);

        It should_serialize_type = () => _json["type"].Value<string>().ShouldEqual(_source.Type.ToString());

        It should_serialize_content = () => _json["content"].Value<string>().ShouldEqual(_source.Content);

        It should_serialize_proxied = () => _json["proxied"].Value<string>().ShouldEqual(_source.Proxied.ToString());

        It should_serialize_ttl = () => _json["ttl"].Value<int>().ShouldEqual(_source.Ttl);

        It should_serialize_priority = () => _json["priority"].Value<int>().ShouldEqual(_source.Priority);

        It should_remove_proxiable = () => _json["proxiable"].ShouldBeNull();

        It should_remove_locked = () => _json["locked"].ShouldBeNull();

        It should_remove_zone_id = () => _json["zone_id"].ShouldBeNull();

        It should_remove_zone_name = () => _json["zone_name"].ShouldBeNull();

        It should_remove_data = () => _json["data"].ShouldBeNull();

        It should_remove_meta = () => _json["meta"].ShouldBeNull();

        It should_serialize_6_properties = () => _json.Count.ShouldEqual(6);
    }
}
