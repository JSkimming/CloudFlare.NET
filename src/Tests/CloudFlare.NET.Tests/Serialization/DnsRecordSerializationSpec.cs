namespace CloudFlare.NET.Serialization.DnsRecordSpec
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Machine.Specifications;
    using Newtonsoft.Json.Linq;
    using Ploeh.AutoFixture;

    [Subject(typeof(DnsRecord))]
    public class When_deserializing
    {
        protected static JObject _json;
        protected static DnsRecord _sut;

        Because of = () =>
        {
            _json = SampleJson.DnsRecord;
            _sut = _json.ToObject<DnsRecord>();
        };

        Behaves_like<IdentifierDeserializeBehavior> identifier_deserialize_behavior;

        Behaves_like<ModifiedDeserializeBehavior> modified_deserialize_behavior;

        It should_deserialize_type = () => _sut.Type.ToString().ShouldEqual(_json["type"].Value<string>());

        It should_deserialize_name = () => _sut.Name.ShouldEqual(_json["name"].Value<string>());

        It should_deserialize_content = () => _sut.Content.ShouldEqual(_json["content"].Value<string>());

        It should_deserialize_proxiable = () => _sut.Proxiable.ShouldEqual(_json["proxiable"].Value<bool>());

        It should_deserialize_proxied = () => _sut.Proxied.ShouldEqual(_json["proxied"].Value<bool>());

        It should_deserialize_ttl = () => _sut.Ttl.ShouldEqual(_json["ttl"].Value<int>());

        It should_deserialize_locked = () => _sut.Locked.ShouldEqual(_json["locked"].Value<bool>());

        It should_deserialize_zone_id = () => _sut.ZoneId.ToString().ShouldEqual(_json["zone_id"].Value<string>());

        It should_deserialize_zone_name = () => _sut.ZoneName.ShouldEqual(_json["zone_name"].Value<string>());

        It should_deserialize_priority = () => _sut.Priority.ShouldEqual(_json["priority"].Value<int>());
    }

    [Subject(typeof(DnsRecord))]
    public class When_deserializing_minimal
    {
        protected static JObject _json;
        protected static DnsRecord _sut;

        Because of = () =>
        {
            _json = SampleJson.DnsRecordMinimal;
            _sut = _json.ToObject<DnsRecord>();
        };

        Behaves_like<IdentifierDeserializeBehavior> identifier_deserialize_behavior;

        It should_deserialize_name = () => _sut.Name.ShouldEqual(_json["name"].Value<string>());

        It should_deserialize_zone_id = () => _sut.ZoneId.ToString().ShouldEqual(_json["zone_id"].Value<string>());
    }

    [Subject(typeof(DnsRecord))]
    public class When_serializing : FixtureContext
    {
        protected static DnsRecord _sut;
        protected static JObject _json;

        Establish context = () => _sut = _fixture.Create<DnsRecord>();

        Because of = () => _json = JObject.FromObject(_sut);

        Behaves_like<IdentifierSerializeBehavior> identifier_serialize_behavior;

        Behaves_like<ModifiedSerializeBehavior> modified_serialize_behavior;

        It should_serialize_type = () => _sut.Type.ToString().ShouldEqual(_json["type"].Value<string>());

        It should_serialize_name = () => _sut.Name.ShouldEqual(_json["name"].Value<string>());

        It should_serialize_content = () => _sut.Content.ShouldEqual(_json["content"].Value<string>());

        It should_serialize_proxiable = () => _sut.Proxiable.ShouldEqual(_json["proxiable"].Value<bool>());

        It should_serialize_proxied = () => _sut.Proxied.ShouldEqual(_json["proxied"].Value<bool>());

        It should_serialize_ttl = () => _sut.Ttl.ShouldEqual(_json["ttl"].Value<int>());

        It should_serialize_locked = () => _sut.Locked.ShouldEqual(_json["locked"].Value<bool>());

        It should_serialize_zone_id = () => _sut.ZoneId.ToString().ShouldEqual(_json["zone_id"].Value<string>());

        It should_serialize_zone_name = () => _sut.ZoneName.ShouldEqual(_json["zone_name"].Value<string>());

        It should_serialize_priority = () => _sut.Priority.ShouldEqual(_json["priority"].Value<int>());
    }

    [Subject(typeof(DnsRecord))]
    public class When_serializing_and_deserializing : FixtureContext
    {
        static DnsRecord _expected;
        static DnsRecord _actual;

        Establish context = () => _expected = _fixture.Create<DnsRecord>();

        Because of = () => _actual = JObject.FromObject(_expected).ToObject<DnsRecord>();

        It should_retain_all_properties = () => _actual.AsLikeness().ShouldEqual(_expected);
    }
}
