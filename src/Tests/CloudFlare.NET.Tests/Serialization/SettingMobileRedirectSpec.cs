namespace CloudFlare.NET.Serialization.SettingMobileRedirectSpec
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Machine.Specifications;
    using Newtonsoft.Json.Linq;
    using Ploeh.AutoFixture;

    [Subject(typeof(SettingMobileRedirect))]
    public class When_serializing : FixtureContext
    {
        static SettingMobileRedirect _sut;
        static JObject _json;

        Establish context = () => _sut = _fixture.Create<SettingMobileRedirect>();

        Because of = () => _json = JObject.FromObject(_sut);

        It should_serialize_status = () => _sut.Status.ToString().ShouldEqual(_json["status"].Value<string>());

        It should_serialize_mobile_subdomain =
            () => _sut.MobileSubdomain.ToString().ShouldEqual(_json["mobile_subdomain"].Value<string>());

        It should_serialize_strip_uri = () => _sut.StripUri.ToString().ShouldEqual(_json["strip_uri"].Value<string>());
    }

    [Subject(typeof(SettingMobileRedirect))]
    public class When_serializing_and_deserializing : FixtureContext
    {
        static SettingMobileRedirect _expected;
        static SettingMobileRedirect _actual;

        Establish context = () => _expected = _fixture.Create<SettingMobileRedirect>();

        Because of = () => _actual = JObject.FromObject(_expected).ToObject<SettingMobileRedirect>();

        It should_retain_all_properties = () => _actual.AsLikeness().ShouldEqual(_expected);
    }

    [Subject(typeof(SettingMobileRedirect))]
    public class When_deserializing
    {
        static JToken _json;
        static SettingMobileRedirect _sut;

        Establish context = () => _json = SampleJson.ZoneSettingMobileRedirect["value"];

        Because of = () => _sut = _json.ToObject<SettingMobileRedirect>();

        It should_deserialize_status = () => _sut.Status.ToString().ShouldEqual(_json["status"].Value<string>());

        It should_deserialize_mobile_subdomain =
            () => _sut.MobileSubdomain.ToString().ShouldEqual(_json["mobile_subdomain"].Value<string>());

        It should_deserialize_strip_uri =
            () => _sut.StripUri.ToString().ShouldEqual(_json["strip_uri"].Value<string>());
    }
}
