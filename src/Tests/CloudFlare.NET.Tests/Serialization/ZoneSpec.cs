namespace CloudFlare.NET.Serialization.ZoneSpec
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Machine.Specifications;
    using Newtonsoft.Json;
    using Newtonsoft.Json.Linq;
    using Ploeh.AutoFixture;

    [Subject(typeof(Zone))]
    public class When_deserializing
    {
        protected static JObject _json;
        protected static Zone _sut;

        Because of = () =>
        {
            _json = SampleJson.Zone;
            _sut = _json.ToObject<Zone>();
        };

        Behaves_like<IdentifierDeserializeBehavior> identifier_deserialize_behavior;

        Behaves_like<ModifiedDeserializeBehavior> modified_deserialize_behavior;

        It should_deserialize_name = () => _sut.Name.ShouldEqual(_json["name"].Value<string>());

        It should_deserialize_development_mode =
            () => _sut.DevelopmentMode.ShouldEqual(_json["development_mode"].Value<int>());

        It should_deserialize_original_name_servers =
            () => _sut.OriginalNameServers
                .ShouldContainOnly(_json["original_name_servers"].ToObject<List<string>>());

        It should_deserialize_original_registrar =
            () => _sut.OriginalRegistrar.ShouldEqual(_json["original_registrar"].Value<string>());

        It should_deserialize_original_dnshost =
            () => _sut.OriginalDnshost.ShouldEqual(_json["original_dnshost"].Value<string>());

        It should_deserialize_name_servers =
            () => _sut.NameServers.ShouldContainOnly(_json["name_servers"].ToObject<List<string>>());

        It should_deserialize_status = () => _sut.Status.ToString().ShouldEqual(_json["status"].Value<string>());
    }

    [Subject(typeof(Zone))]
    public class When_deserializing_minimal
    {
        protected static JObject _json;
        protected static Zone _sut;

        Because of = () =>
        {
            _json = SampleJson.ZoneMinimal;
            _sut = _json.ToObject<Zone>();
        };

        Behaves_like<IdentifierDeserializeBehavior> identifier_deserialize_behavior;

        It should_deserialize_name = () => _sut.Name.ShouldEqual(_json["name"].Value<string>());
    }

    [Subject(typeof(Zone))]
    public class When_serializing : FixtureContext
    {
        protected static Zone _sut;
        protected static JObject _json;

        Establish context = () => _sut = _fixture.Create<Zone>();

        Because of = () => _json = JObject.FromObject(_sut);

        Behaves_like<IdentifierSerializeBehavior> identifier_serialize_behavior;

        Behaves_like<ModifiedSerializeBehavior> modified_serialize_behavior;

        It should_serialize_name = () => _sut.Name.ShouldEqual(_json["name"].Value<string>());

        It should_serialize_development_mode =
            () => _sut.DevelopmentMode.ShouldEqual(_json["development_mode"].Value<int>());

        It should_serialize_original_name_servers =
            () => _sut.OriginalNameServers
                .ShouldContainOnly(_json["original_name_servers"].ToObject<List<string>>());

        It should_serialize_original_registrar =
            () => _sut.OriginalRegistrar.ShouldEqual(_json["original_registrar"].Value<string>());

        It should_serialize_original_dnshost =
            () => _sut.OriginalDnshost.ShouldEqual(_json["original_dnshost"].Value<string>());

        It should_serialize_name_servers =
            () => _sut.NameServers.ShouldContainOnly(_json["name_servers"].ToObject<List<string>>());

        It should_serialize_status = () => _sut.Status.ToString().ShouldEqual(_json["status"].Value<string>());
    }

    [Subject(typeof(Zone))]
    public class When_serializing_and_deserializing : FixtureContext
    {
        static Zone _expected;
        static Zone _actual;

        Establish context = () => _expected = _fixture.Create<Zone>();

        Because of = () =>
        {
            var serializeObject = JsonConvert.SerializeObject(_expected);
            _actual = JObject.FromObject(_expected).ToObject<Zone>();
        };

        It should_retain_all_properties = () => _actual.AsLikeness().ShouldEqual(_expected);
    }
}
