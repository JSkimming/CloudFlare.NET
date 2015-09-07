namespace CloudFlare.NET.Serialization.ZoneSettingSpec
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Machine.Specifications;
    using Newtonsoft.Json.Linq;
    using Ploeh.AutoFixture;

    [Subject(typeof(ZoneSetting<>))]
    public class When_serializing : FixtureContext
    {
        protected static ZoneSetting<string> _sut;
        protected static JObject _json;

        Establish context = () => _sut = _fixture.Create<ZoneSetting<string>>();

        Because of = () => _json = JObject.FromObject(_sut);

        Behaves_like<ZoneSettingSerializeBehavior> zone_setting_serialize_behavior;

        It should_serialize_value = () => _sut.Value.ShouldEqual(_json["value"].Value<string>());
    }

    [Subject(typeof(ZoneSetting<>))]
    public class When_serializing_and_deserializing : FixtureContext
    {
        static ZoneSetting<string> _expected;
        static ZoneSetting<string> _actual;

        Establish context = () => _expected = _fixture.Create<ZoneSetting<string>>();

        Because of = () => _actual = JObject.FromObject(_expected).ToObject<ZoneSetting<string>>();

        It should_retain_all_properties = () => _actual.AsLikeness().ShouldEqual(_expected);
    }

    [Subject(typeof(ZoneSetting<>))]
    public class When_deserializing
    {
        protected static JObject _json;
        protected static ZoneSetting<string> _sut;

        Establish context = () => _json = SampleJson.ZoneSettingTest1;

        Because of = () => _sut = _json.ToObject<ZoneSetting<string>>();

        Behaves_like<ZoneSettingDeserializeBehavior> zone_setting_deserialize_behavior;

        It should_deserialize_value = () => _sut.Value.ShouldEqual(_json["value"].Value<string>());
    }
}
