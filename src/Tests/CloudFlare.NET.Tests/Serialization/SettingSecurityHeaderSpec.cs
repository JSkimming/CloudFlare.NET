namespace CloudFlare.NET.Serialization.SettingSecurityHeaderSpec
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Machine.Specifications;
    using Newtonsoft.Json.Linq;
    using Ploeh.AutoFixture;

    [Subject(typeof(SettingSecurityHeader))]
    public class When_serializing : FixtureContext
    {
        static SettingSecurityHeader _sut;
        static JObject _json;

        Establish context = () => _sut = _fixture.Create<SettingSecurityHeader>();

        Because of = () => _json = JObject.FromObject(_sut);

        It should_serialize_strict_transport_security_enabled =
            () => _sut.StrictTransportSecurity.Enabled
                .ShouldEqual(_json["strict_transport_security"]["enabled"].Value<bool>());

        It should_serialize_strict_transport_security_max_age =
            () => _sut.StrictTransportSecurity.MaxAge
                .ShouldEqual(_json["strict_transport_security"]["max_age"].Value<int>());

        It should_serialize_strict_transport_security_include_subdomains =
            () => _sut.StrictTransportSecurity.IncludeSubdomains
                .ShouldEqual(_json["strict_transport_security"]["include_subdomains"].Value<bool>());

        It should_serialize_strict_transport_security_nosniff =
            () => _sut.StrictTransportSecurity.Nosniff
                .ShouldEqual(_json["strict_transport_security"]["nosniff"].Value<bool>());
    }

    [Subject(typeof(SettingSecurityHeader))]
    public class When_serializing_and_deserializing : FixtureContext
    {
        static SettingSecurityHeader _expected;
        static SettingSecurityHeader _actual;

        Establish context = () => _expected = _fixture.Create<SettingSecurityHeader>();

        Because of = () => _actual = JObject.FromObject(_expected).ToObject<SettingSecurityHeader>();

        It should_retain_all_properties = () => _actual.AsLikeness().ShouldEqual(_expected);
    }

    [Subject(typeof(SettingSecurityHeader))]
    public class When_deserializing
    {
        static JToken _json;
        static SettingSecurityHeader _sut;

        Establish context = () => _json = SampleJson.ZoneSettingSecurityHeader["value"];

        Because of = () => _sut = _json.ToObject<SettingSecurityHeader>();

        It should_deserialize_strict_transport_security_enabled =
            () => _sut.StrictTransportSecurity.Enabled
                .ShouldEqual(_json["strict_transport_security"]["enabled"].Value<bool>());

        It should_deserialize_strict_transport_security_max_age =
            () => _sut.StrictTransportSecurity.MaxAge
                .ShouldEqual(_json["strict_transport_security"]["max_age"].Value<int>());

        It should_deserialize_strict_transport_security_include_subdomains =
            () => _sut.StrictTransportSecurity.IncludeSubdomains
                .ShouldEqual(_json["strict_transport_security"]["include_subdomains"].Value<bool>());

        It should_deserialize_strict_transport_security_nosniff =
            () => _sut.StrictTransportSecurity.Nosniff
                .ShouldEqual(_json["strict_transport_security"]["nosniff"].Value<bool>());
    }
}
