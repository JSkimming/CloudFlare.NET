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
        static ZoneSetting<string> _sut;
        static JObject _json;

        Establish context = () => _sut = _fixture.Create<ZoneSetting<string>>();

        Because of = () => _json = JObject.FromObject(_sut);

        It should_serialize_id = () => _sut.Id.ShouldEqual(_json["id"].Value<string>());

        It should_serialize_editable = () => _sut.Editable.ShouldEqual(_json["editable"].Value<bool>());

        It should_serialize_modified_on = () => _sut.ModifiedOn.ShouldEqual(_json["modified_on"].Value<DateTime>());

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
        static JObject _json;
        static ZoneSetting<string> _sut;

        Establish context = () => _json = SampleJson.ZoneSettingTest1;

        Because of = () => _sut = _json.ToObject<ZoneSetting<string>>();

        It should_deserialize_id = () => _sut.Id.ShouldEqual(_json["id"].Value<string>());

        It should_deserialize_editable = () => _sut.Editable.ShouldEqual(_json["editable"].Value<bool>());

        It should_deserialize_modified_on = () => _sut.ModifiedOn.ShouldEqual(_json["modified_on"].Value<DateTime>());

        It should_deserialize_value = () => _sut.Value.ShouldEqual(_json["value"].Value<string>());
    }
}
