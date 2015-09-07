namespace CloudFlare.NET.Serialization.ZoneDevelopmentModeSettingSpec
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Machine.Specifications;
    using Newtonsoft.Json.Linq;
    using Ploeh.AutoFixture;

    [Subject(typeof(ZoneDevelopmentModeSetting))]
    public class When_serializing : FixtureContext
    {
        protected static ZoneDevelopmentModeSetting _sut;
        protected static JObject _json;

        Establish context = () => _sut = _fixture.Create<ZoneDevelopmentModeSetting>();

        Because of = () => _json = JObject.FromObject(_sut);

        Behaves_like<ZoneSettingSerializeBehavior> zone_setting_serialize_behavior;

        It should_serialize_value = () => _sut.Value.ToString().ShouldEqual(_json["value"].Value<string>());

        It should_serialize_time_remaining
            = () => _sut.TimeRemaining.ToString().ShouldEqual(_json["time_remaining"].Value<string>());
    }

    [Subject(typeof(ZoneDevelopmentModeSetting))]
    public class When_serializing_and_deserializing : FixtureContext
    {
        static ZoneDevelopmentModeSetting _expected;
        static ZoneDevelopmentModeSetting _actual;

        Establish context = () => _expected = _fixture.Create<ZoneDevelopmentModeSetting>();

        Because of = () => _actual = JObject.FromObject(_expected).ToObject<ZoneDevelopmentModeSetting>();

        It should_retain_all_properties = () => _actual.AsLikeness().ShouldEqual(_expected);
    }

    [Subject(typeof(ZoneDevelopmentModeSetting))]
    public class When_deserializing
    {
        protected static JObject _json;
        protected static ZoneDevelopmentModeSetting _sut;

        Establish context = () => _json = SampleJson.ZoneSettingDevelopmentMode;

        Because of = () => _sut = _json.ToObject<ZoneDevelopmentModeSetting>();

        Behaves_like<ZoneSettingDeserializeBehavior> zone_setting_deserialize_behavior;

        It should_deserialize_value = () => _sut.Value.ToString().ShouldEqual(_json["value"].Value<string>());

        It should_deserialize_time_remaining
            = () => _sut.TimeRemaining.ToString().ShouldEqual(_json["time_remaining"].Value<string>());
    }
}
