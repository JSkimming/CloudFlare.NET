namespace CloudFlare.NET.ZoneSettingsClientSpec
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Net.Http;
    using CloudFlare.NET.Serialization;
    using Machine.Specifications;
    using Newtonsoft.Json.Linq;
    using Ploeh.AutoFixture;

    [Subject("ZoneSettingsClient")]
    public class When_getting_zone_settings : RequestContext
    {
        static IdentifierTag _zoneId;
        static JArray _source;
        static IReadOnlyList<ZoneSettingBase> _actual;
        static Uri _expectedRequestUri;

        Establish context = () =>
        {
            _source = SampleJson.ZoneSettings;
            var response = new CloudFlareResponse<JArray>(true, _source);
            _zoneId = _fixture.Create<IdentifierTag>();
            _handler.SetResponseContent(response);
            _expectedRequestUri = new Uri(CloudFlareConstants.BaseUri, $"zones/{_zoneId}/settings");
        };

        Because of = () => _actual = _sut.GetAllZoneSettingsAsync(_zoneId, _auth).Await().AsTask.Result.ToList();

        Behaves_like<AuthenticatedRequestBehaviour> authenticated_request_behaviour;

        It should_make_a_GET_request = () => _handler.Request.Method.ShouldEqual(HttpMethod.Get);

        It should_request_the_zone_settings_endpoint
            = () => _handler.Request.RequestUri.ShouldEqual(_expectedRequestUri);

        It should_return_the_expected_zone_settings = () => _actual.Count.ShouldEqual(_source.Count);

        It should_be_only_2_test_generic_types =
            () => _actual.Count(s => s.GetType() == typeof(ZoneSetting<JToken>)).ShouldEqual(2);

        It should_return_the_test_simple_type =
            () => _actual.Single(s => s.Id == "xxx_test1").ShouldBeOfExactType<ZoneSetting<JToken>>();

        It should_return_the_test_comples_type =
            () => _actual.Single(s => s.Id == "xxx_test2").ShouldBeOfExactType<ZoneSetting<JToken>>();
    }

    [Subject("ZoneSettingsClient")]
    public class When_getting_zone_settings_and_an_error_occurs : ErredRequestContext
    {
        static IdentifierTag _zoneId;
        static Uri _expectedRequestUri;

        Establish context = () =>
        {
            _zoneId = _fixture.Create<IdentifierTag>();
            _expectedRequestUri = new Uri(CloudFlareConstants.BaseUri, $"zones/{_zoneId}/settings");
        };

        Because of = () => _exception = Catch.Exception(() => _sut.GetAllZoneSettingsAsync(_zoneId, _auth).Await());

        Behaves_like<AuthenticatedRequestBehaviour> authenticated_request_behaviour;

        Behaves_like<ErredRequestBehaviour> erred_request_behaviour;

        It should_make_a_GET_request = () => _handler.Request.Method.ShouldEqual(HttpMethod.Get);

        It should_request_the_zone_settings_endpoint
            = () => _handler.Request.RequestUri.ShouldEqual(_expectedRequestUri);
    }

    [Subject("ZoneSettingsClient")]
    public class When_getting_zone_settings_and_a_setting_has_no_id : RequestContext
    {
        static IdentifierTag _zoneId;
        static Uri _expectedRequestUri;
        static Exception _exception;

        Establish context = () =>
        {
            var response = new CloudFlareResponse<JArray>(true, SampleJson.ZoneSettingsErred);
            _zoneId = _fixture.Create<IdentifierTag>();
            _handler.SetResponseContent(response);
            _expectedRequestUri = new Uri(CloudFlareConstants.BaseUri, $"zones/{_zoneId}/settings");
        };

        Because of = () => _exception = Catch.Exception(
            () => _sut.GetAllZoneSettingsAsync(_zoneId, _auth).Await().AsTask.Result.ToList());

        It should_throw_an_InvalidOperationException =
            () => _exception.ShouldBeOfExactType<InvalidOperationException>();

        Behaves_like<AuthenticatedRequestBehaviour> authenticated_request_behaviour;

        It should_request_the_zone_settings_endpoint
            = () => _handler.Request.RequestUri.ShouldEqual(_expectedRequestUri);
    }
}
