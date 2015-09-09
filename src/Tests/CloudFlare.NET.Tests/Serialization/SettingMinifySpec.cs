namespace CloudFlare.NET.Serialization.SettingMinifySpec
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Machine.Specifications;
    using Newtonsoft.Json.Linq;
    using Ploeh.AutoFixture;

    [Subject(typeof(SettingMinify))]
    public class When_serializing : FixtureContext
    {
        static SettingMinify _sut;
        static JObject _json;

        Establish context = () => _sut = _fixture.Create<SettingMinify>();

        Because of = () => _json = JObject.FromObject(_sut);

        It should_serialize_css = () => _sut.Css.ToString().ShouldEqual(_json["css"].Value<string>());

        It should_serialize_html = () => _sut.Html.ToString().ShouldEqual(_json["html"].Value<string>());

        It should_serialize_js = () => _sut.Js.ToString().ShouldEqual(_json["js"].Value<string>());
    }

    [Subject(typeof(SettingMinify))]
    public class When_serializing_and_deserializing : FixtureContext
    {
        static SettingMinify _expected;
        static SettingMinify _actual;

        Establish context = () => _expected = _fixture.Create<SettingMinify>();

        Because of = () => _actual = JObject.FromObject(_expected).ToObject<SettingMinify>();

        It should_retain_all_properties = () => _actual.AsLikeness().ShouldEqual(_expected);
    }

    [Subject(typeof(SettingMinify))]
    public class When_deserializing
    {
        static JToken _json;
        static SettingMinify _sut;

        Establish context = () => _json = SampleJson.ZoneSettingMinify["value"];

        Because of = () => _sut = _json.ToObject<SettingMinify>();

        It should_deserialize_css = () => _sut.Css.ToString().ShouldEqual(_json["css"].Value<string>());

        It should_deserialize_html = () => _sut.Html.ToString().ShouldEqual(_json["html"].Value<string>());

        It should_deserialize_js = () => _sut.Js.ToString().ShouldEqual(_json["js"].Value<string>());
    }
}
