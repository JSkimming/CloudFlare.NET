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

    [Subject("ZoneSettingsClient")]
    public class When_getting_zone_advanced_DDOS_setting : RequestContext
    {
        static IdentifierTag _zoneId;
        static ZoneSetting<SettingOnOffTypes> _expected;
        static ZoneSetting<SettingOnOffTypes> _actual;
        static Uri _expectedRequestUri;

        Establish context = () =>
        {
            JObject source = SampleJson.ZoneSettingAdvancedDdos;
            _expected = source.ToObject<ZoneSetting<SettingOnOffTypes>>();
            var response = new CloudFlareResponse<JObject>(true, source);
            _zoneId = _fixture.Create<IdentifierTag>();
            _handler.SetResponseContent(response);
            _expectedRequestUri = new Uri(CloudFlareConstants.BaseUri, $"zones/{_zoneId}/settings/advanced_ddos");
        };

        Because of = () => _actual = _sut.GetAdvancedDdosSettingAsync(_zoneId, _auth).Await();

        Behaves_like<AuthenticatedRequestBehaviour> authenticated_request_behaviour;

        It should_make_a_GET_request = () => _handler.Request.Method.ShouldEqual(HttpMethod.Get);

        It should_request_the_zone_settings_endpoint
            = () => _handler.Request.RequestUri.ShouldEqual(_expectedRequestUri);

        It should_return_the_expected_zone_setting = () => _actual.AsLikeness().ShouldEqual(_expected);
    }

    [Subject("ZoneSettingsClient")]
    public class When_getting_zone_always_online_setting : RequestContext
    {
        static IdentifierTag _zoneId;
        static ZoneSetting<SettingOnOffTypes> _expected;
        static ZoneSetting<SettingOnOffTypes> _actual;
        static Uri _expectedRequestUri;

        Establish context = () =>
        {
            JObject source = SampleJson.ZoneSettingAlwaysOnline ;
            _expected = source.ToObject<ZoneSetting<SettingOnOffTypes>>();
            var response = new CloudFlareResponse<JObject>(true, source);
            _zoneId = _fixture.Create<IdentifierTag>();
            _handler.SetResponseContent(response);
            _expectedRequestUri = new Uri(CloudFlareConstants.BaseUri, $"zones/{_zoneId}/settings/always_online");
        };

        Because of = () => _actual = _sut.GetAlwaysOnlineSettingAsync(_zoneId, _auth).Await();

        Behaves_like<AuthenticatedRequestBehaviour> authenticated_request_behaviour;

        It should_make_a_GET_request = () => _handler.Request.Method.ShouldEqual(HttpMethod.Get);

        It should_request_the_zone_settings_endpoint
            = () => _handler.Request.RequestUri.ShouldEqual(_expectedRequestUri);

        It should_return_the_expected_zone_setting = () => _actual.AsLikeness().ShouldEqual(_expected);
    }

    [Subject("ZoneSettingsClient")]
    public class When_getting_zone_browser_cache_TTL_setting : RequestContext
    {
        static IdentifierTag _zoneId;
        static ZoneSetting<int> _expected;
        static ZoneSetting<int> _actual;
        static Uri _expectedRequestUri;

        Establish context = () =>
        {
            JObject source = SampleJson.ZoneSettingBrowserCacheTtl;
            _expected = source.ToObject<ZoneSetting<int>>();
            var response = new CloudFlareResponse<JObject>(true, source);
            _zoneId = _fixture.Create<IdentifierTag>();
            _handler.SetResponseContent(response);
            _expectedRequestUri = new Uri(CloudFlareConstants.BaseUri, $"zones/{_zoneId}/settings/browser_cache_ttl");
        };

        Because of = () => _actual = _sut.GetBrowserCacheTtlSettingAsync(_zoneId, _auth).Await();

        Behaves_like<AuthenticatedRequestBehaviour> authenticated_request_behaviour;

        It should_make_a_GET_request = () => _handler.Request.Method.ShouldEqual(HttpMethod.Get);

        It should_request_the_zone_settings_endpoint
            = () => _handler.Request.RequestUri.ShouldEqual(_expectedRequestUri);

        It should_return_the_expected_zone_setting = () => _actual.AsLikeness().ShouldEqual(_expected);
    }

    [Subject("ZoneSettingsClient")]
    public class When_getting_zone_browser_check_setting : RequestContext
    {
        static IdentifierTag _zoneId;
        static ZoneSetting<SettingOnOffTypes> _expected;
        static ZoneSetting<SettingOnOffTypes> _actual;
        static Uri _expectedRequestUri;

        Establish context = () =>
        {
            JObject source = SampleJson.ZoneSettingBrowserCheck;
            _expected = source.ToObject<ZoneSetting<SettingOnOffTypes>>();
            var response = new CloudFlareResponse<JObject>(true, source);
            _zoneId = _fixture.Create<IdentifierTag>();
            _handler.SetResponseContent(response);
            _expectedRequestUri = new Uri(CloudFlareConstants.BaseUri, $"zones/{_zoneId}/settings/browser_check");
        };

        Because of = () => _actual = _sut.GetBrowserCheckSettingAsync(_zoneId, _auth).Await();

        Behaves_like<AuthenticatedRequestBehaviour> authenticated_request_behaviour;

        It should_make_a_GET_request = () => _handler.Request.Method.ShouldEqual(HttpMethod.Get);

        It should_request_the_zone_settings_endpoint
            = () => _handler.Request.RequestUri.ShouldEqual(_expectedRequestUri);

        It should_return_the_expected_zone_setting = () => _actual.AsLikeness().ShouldEqual(_expected);
    }

    [Subject("ZoneSettingsClient")]
    public class When_getting_zone_cache_level_setting : RequestContext
    {
        static IdentifierTag _zoneId;
        static ZoneSetting<SettingCacheLevelTypes> _expected;
        static ZoneSetting<SettingCacheLevelTypes> _actual;
        static Uri _expectedRequestUri;

        Establish context = () =>
        {
            JObject source = SampleJson.ZoneSettingCacheLevel;
            _expected = source.ToObject<ZoneSetting<SettingCacheLevelTypes>>();
            var response = new CloudFlareResponse<JObject>(true, source);
            _zoneId = _fixture.Create<IdentifierTag>();
            _handler.SetResponseContent(response);
            _expectedRequestUri = new Uri(CloudFlareConstants.BaseUri, $"zones/{_zoneId}/settings/cache_level");
        };

        Because of = () => _actual = _sut.GetCacheLevelSettingAsync(_zoneId, _auth).Await();

        Behaves_like<AuthenticatedRequestBehaviour> authenticated_request_behaviour;

        It should_make_a_GET_request = () => _handler.Request.Method.ShouldEqual(HttpMethod.Get);

        It should_request_the_zone_settings_endpoint
            = () => _handler.Request.RequestUri.ShouldEqual(_expectedRequestUri);

        It should_return_the_expected_zone_setting = () => _actual.AsLikeness().ShouldEqual(_expected);
    }

    [Subject("ZoneSettingsClient")]
    public class When_getting_zone_challenge_TTL_setting : RequestContext
    {
        static IdentifierTag _zoneId;
        static ZoneSetting<int> _expected;
        static ZoneSetting<int> _actual;
        static Uri _expectedRequestUri;

        Establish context = () =>
        {
            JObject source = SampleJson.ZoneSettingChallengeTtl;
            _expected = source.ToObject<ZoneSetting<int>>();
            var response = new CloudFlareResponse<JObject>(true, source);
            _zoneId = _fixture.Create<IdentifierTag>();
            _handler.SetResponseContent(response);
            _expectedRequestUri = new Uri(CloudFlareConstants.BaseUri, $"zones/{_zoneId}/settings/challenge_ttl");
        };

        Because of = () => _actual = _sut.GetChallengeTtlSettingAsync(_zoneId, _auth).Await();

        Behaves_like<AuthenticatedRequestBehaviour> authenticated_request_behaviour;

        It should_make_a_GET_request = () => _handler.Request.Method.ShouldEqual(HttpMethod.Get);

        It should_request_the_zone_settings_endpoint
            = () => _handler.Request.RequestUri.ShouldEqual(_expectedRequestUri);

        It should_return_the_expected_zone_setting = () => _actual.AsLikeness().ShouldEqual(_expected);
    }

    [Subject("ZoneSettingsClient")]
    public class When_getting_zone_development_mode_setting : RequestContext
    {
        static IdentifierTag _zoneId;
        static ZoneDevelopmentModeSetting _expected;
        static ZoneDevelopmentModeSetting _actual;
        static Uri _expectedRequestUri;

        Establish context = () =>
        {
            JObject source = SampleJson.ZoneSettingDevelopmentMode;
            _expected = source.ToObject<ZoneDevelopmentModeSetting>();
            var response = new CloudFlareResponse<JObject>(true, source);
            _zoneId = _fixture.Create<IdentifierTag>();
            _handler.SetResponseContent(response);
            _expectedRequestUri = new Uri(CloudFlareConstants.BaseUri, $"zones/{_zoneId}/settings/development_mode");
        };

        Because of = () => _actual = _sut.GetDevelopmentModeSettingAsync(_zoneId, _auth).Await();

        Behaves_like<AuthenticatedRequestBehaviour> authenticated_request_behaviour;

        It should_make_a_GET_request = () => _handler.Request.Method.ShouldEqual(HttpMethod.Get);

        It should_request_the_zone_settings_endpoint
            = () => _handler.Request.RequestUri.ShouldEqual(_expectedRequestUri);

        It should_return_the_expected_zone_setting = () => _actual.AsLikeness().ShouldEqual(_expected);
    }

    [Subject("ZoneSettingsClient")]
    public class When_getting_zone_email_obfuscation_setting : RequestContext
    {
        static IdentifierTag _zoneId;
        static ZoneSetting<SettingOnOffTypes> _expected;
        static ZoneSetting<SettingOnOffTypes> _actual;
        static Uri _expectedRequestUri;

        Establish context = () =>
        {
            JObject source = SampleJson.ZoneSettingEmailObfuscation;
            _expected = source.ToObject<ZoneSetting<SettingOnOffTypes>>();
            var response = new CloudFlareResponse<JObject>(true, source);
            _zoneId = _fixture.Create<IdentifierTag>();
            _handler.SetResponseContent(response);
            _expectedRequestUri = new Uri(CloudFlareConstants.BaseUri, $"zones/{_zoneId}/settings/email_obfuscation");
        };

        Because of = () => _actual = _sut.GetEmailObfuscationSettingAsync(_zoneId, _auth).Await();

        Behaves_like<AuthenticatedRequestBehaviour> authenticated_request_behaviour;

        It should_make_a_GET_request = () => _handler.Request.Method.ShouldEqual(HttpMethod.Get);

        It should_request_the_zone_settings_endpoint
            = () => _handler.Request.RequestUri.ShouldEqual(_expectedRequestUri);

        It should_return_the_expected_zone_setting = () => _actual.AsLikeness().ShouldEqual(_expected);
    }

    [Subject("ZoneSettingsClient")]
    public class When_getting_zone_hotlink_protection_setting : RequestContext
    {
        static IdentifierTag _zoneId;
        static ZoneSetting<SettingOnOffTypes> _expected;
        static ZoneSetting<SettingOnOffTypes> _actual;
        static Uri _expectedRequestUri;

        Establish context = () =>
        {
            JObject source = SampleJson.ZoneSettingHotlinkProtection;
            _expected = source.ToObject<ZoneSetting<SettingOnOffTypes>>();
            var response = new CloudFlareResponse<JObject>(true, source);
            _zoneId = _fixture.Create<IdentifierTag>();
            _handler.SetResponseContent(response);
            _expectedRequestUri = new Uri(CloudFlareConstants.BaseUri, $"zones/{_zoneId}/settings/hotlink_protection");
        };

        Because of = () => _actual = _sut.GetHotlinkProtectionSettingAsync(_zoneId, _auth).Await();

        Behaves_like<AuthenticatedRequestBehaviour> authenticated_request_behaviour;

        It should_make_a_GET_request = () => _handler.Request.Method.ShouldEqual(HttpMethod.Get);

        It should_request_the_zone_settings_endpoint
            = () => _handler.Request.RequestUri.ShouldEqual(_expectedRequestUri);

        It should_return_the_expected_zone_setting = () => _actual.AsLikeness().ShouldEqual(_expected);
    }

    [Subject("ZoneSettingsClient")]
    public class When_getting_zone_ip_geolocation_setting : RequestContext
    {
        static IdentifierTag _zoneId;
        static ZoneSetting<SettingOnOffTypes> _expected;
        static ZoneSetting<SettingOnOffTypes> _actual;
        static Uri _expectedRequestUri;

        Establish context = () =>
        {
            JObject source = SampleJson.ZoneSettingIpGeolocation;
            _expected = source.ToObject<ZoneSetting<SettingOnOffTypes>>();
            var response = new CloudFlareResponse<JObject>(true, source);
            _zoneId = _fixture.Create<IdentifierTag>();
            _handler.SetResponseContent(response);
            _expectedRequestUri = new Uri(CloudFlareConstants.BaseUri, $"zones/{_zoneId}/settings/ip_geolocation");
        };

        //Because of = () => _actual = _sut.GetIpGeolocationSettingAsync(_zoneId, _auth).Await();

        Behaves_like<AuthenticatedRequestBehaviour> authenticated_request_behaviour;

        It should_make_a_GET_request = () => _handler.Request.Method.ShouldEqual(HttpMethod.Get);

        It should_request_the_zone_settings_endpoint
            = () => _handler.Request.RequestUri.ShouldEqual(_expectedRequestUri);

        It should_return_the_expected_zone_setting = () => _actual.AsLikeness().ShouldEqual(_expected);
    }

    [Subject("ZoneSettingsClient")]
    public class When_getting_zone_ipv6_setting : RequestContext
    {
        static IdentifierTag _zoneId;
        static ZoneSetting<SettingIPv6Types> _expected;
        static ZoneSetting<SettingIPv6Types> _actual;
        static Uri _expectedRequestUri;

        Establish context = () =>
        {
            JObject source = SampleJson.ZoneSettingIPv6;
            _expected = source.ToObject<ZoneSetting<SettingIPv6Types>>();
            var response = new CloudFlareResponse<JObject>(true, source);
            _zoneId = _fixture.Create<IdentifierTag>();
            _handler.SetResponseContent(response);
            _expectedRequestUri = new Uri(CloudFlareConstants.BaseUri, $"zones/{_zoneId}/settings/ipv6");
        };

        //Because of = () => _actual = _sut.GetIPv6SettingAsync(_zoneId, _auth).Await();

        Behaves_like<AuthenticatedRequestBehaviour> authenticated_request_behaviour;

        It should_make_a_GET_request = () => _handler.Request.Method.ShouldEqual(HttpMethod.Get);

        It should_request_the_zone_settings_endpoint
            = () => _handler.Request.RequestUri.ShouldEqual(_expectedRequestUri);

        It should_return_the_expected_zone_setting = () => _actual.AsLikeness().ShouldEqual(_expected);
    }

    [Subject("ZoneSettingsClient")]
    public class When_getting_zone_minify_setting : RequestContext
    {
        static IdentifierTag _zoneId;
        static ZoneSetting<SettingMinify> _expected;
        static ZoneSetting<SettingMinify> _actual;
        static Uri _expectedRequestUri;

        Establish context = () =>
        {
            JObject source = SampleJson.ZoneSettingMinify;
            _expected = source.ToObject<ZoneSetting<SettingMinify>>();
            var response = new CloudFlareResponse<JObject>(true, source);
            _zoneId = _fixture.Create<IdentifierTag>();
            _handler.SetResponseContent(response);
            _expectedRequestUri = new Uri(CloudFlareConstants.BaseUri, $"zones/{_zoneId}/settings/minify");
        };

        //Because of = () => _actual = _sut.GetMinifySettingAsync(_zoneId, _auth).Await();

        Behaves_like<AuthenticatedRequestBehaviour> authenticated_request_behaviour;

        It should_make_a_GET_request = () => _handler.Request.Method.ShouldEqual(HttpMethod.Get);

        It should_request_the_zone_settings_endpoint
            = () => _handler.Request.RequestUri.ShouldEqual(_expectedRequestUri);

        It should_return_the_expected_zone_setting = () => _actual.AsLikeness().ShouldEqual(_expected);
    }

    [Subject("ZoneSettingsClient")]
    public class When_getting_zone_mobile_redirect_setting : RequestContext
    {
        static IdentifierTag _zoneId;
        static ZoneSetting<SettingMobileRedirect> _expected;
        static ZoneSetting<SettingMobileRedirect> _actual;
        static Uri _expectedRequestUri;

        Establish context = () =>
        {
            JObject source = SampleJson.ZoneSettingMobileRedirect;
            _expected = source.ToObject<ZoneSetting<SettingMobileRedirect>>();
            var response = new CloudFlareResponse<JObject>(true, source);
            _zoneId = _fixture.Create<IdentifierTag>();
            _handler.SetResponseContent(response);
            _expectedRequestUri = new Uri(CloudFlareConstants.BaseUri, $"zones/{_zoneId}/settings/mobile_redirect");
        };

        //Because of = () => _actual = _sut.GetMobileRedirectSettingAsync(_zoneId, _auth).Await();

        Behaves_like<AuthenticatedRequestBehaviour> authenticated_request_behaviour;

        It should_make_a_GET_request = () => _handler.Request.Method.ShouldEqual(HttpMethod.Get);

        It should_request_the_zone_settings_endpoint
            = () => _handler.Request.RequestUri.ShouldEqual(_expectedRequestUri);

        It should_return_the_expected_zone_setting = () => _actual.AsLikeness().ShouldEqual(_expected);
    }

    [Subject("ZoneSettingsClient")]
    public class When_getting_zone_mirage_setting : RequestContext
    {
        static IdentifierTag _zoneId;
        static ZoneSetting<SettingOnOffTypes> _expected;
        static ZoneSetting<SettingOnOffTypes> _actual;
        static Uri _expectedRequestUri;

        Establish context = () =>
        {
            JObject source = SampleJson.ZoneSettingMirage;
            _expected = source.ToObject<ZoneSetting<SettingOnOffTypes>>();
            var response = new CloudFlareResponse<JObject>(true, source);
            _zoneId = _fixture.Create<IdentifierTag>();
            _handler.SetResponseContent(response);
            _expectedRequestUri = new Uri(CloudFlareConstants.BaseUri, $"zones/{_zoneId}/settings/mirage");
        };

        //Because of = () => _actual = _sut.GetMirageSettingAsync(_zoneId, _auth).Await();

        Behaves_like<AuthenticatedRequestBehaviour> authenticated_request_behaviour;

        It should_make_a_GET_request = () => _handler.Request.Method.ShouldEqual(HttpMethod.Get);

        It should_request_the_zone_settings_endpoint
            = () => _handler.Request.RequestUri.ShouldEqual(_expectedRequestUri);

        It should_return_the_expected_zone_setting = () => _actual.AsLikeness().ShouldEqual(_expected);
    }

    [Subject("ZoneSettingsClient")]
    public class When_getting_enable_error_pages_on_setting : RequestContext
    {
        static IdentifierTag _zoneId;
        static ZoneSetting<SettingOnOffTypes> _expected;
        static ZoneSetting<SettingOnOffTypes> _actual;
        static Uri _expectedRequestUri;

        Establish context = () =>
        {
            JObject source = SampleJson.ZoneSettingEnableErrorPagesOn;
            _expected = source.ToObject<ZoneSetting<SettingOnOffTypes>>();
            var response = new CloudFlareResponse<JObject>(true, source);
            _zoneId = _fixture.Create<IdentifierTag>();
            _handler.SetResponseContent(response);
            _expectedRequestUri =
                new Uri(CloudFlareConstants.BaseUri, $"zones/{_zoneId}/settings/origin_error_page_pass_thru");
        };

        //Because of = () => _actual = _sut.GetEnableErrorPagesOnSettingAsync(_zoneId, _auth).Await();

        Behaves_like<AuthenticatedRequestBehaviour> authenticated_request_behaviour;

        It should_make_a_GET_request = () => _handler.Request.Method.ShouldEqual(HttpMethod.Get);

        It should_request_the_zone_settings_endpoint
            = () => _handler.Request.RequestUri.ShouldEqual(_expectedRequestUri);

        It should_return_the_expected_zone_setting = () => _actual.AsLikeness().ShouldEqual(_expected);
    }

    [Subject("ZoneSettingsClient")]
    public class When_getting_zone_polish_setting : RequestContext
    {
        static IdentifierTag _zoneId;
        static ZoneSetting<SettingPolishTypes> _expected;
        static ZoneSetting<SettingPolishTypes> _actual;
        static Uri _expectedRequestUri;

        Establish context = () =>
        {
            JObject source = SampleJson.ZoneSettingPolish;
            _expected = source.ToObject<ZoneSetting<SettingPolishTypes>>();
            var response = new CloudFlareResponse<JObject>(true, source);
            _zoneId = _fixture.Create<IdentifierTag>();
            _handler.SetResponseContent(response);
            _expectedRequestUri = new Uri(CloudFlareConstants.BaseUri, $"zones/{_zoneId}/settings/polish");
        };

        //Because of = () => _actual = _sut.GetPolishSettingAsync(_zoneId, _auth).Await();

        Behaves_like<AuthenticatedRequestBehaviour> authenticated_request_behaviour;

        It should_make_a_GET_request = () => _handler.Request.Method.ShouldEqual(HttpMethod.Get);

        It should_request_the_zone_settings_endpoint
            = () => _handler.Request.RequestUri.ShouldEqual(_expectedRequestUri);

        It should_return_the_expected_zone_setting = () => _actual.AsLikeness().ShouldEqual(_expected);
    }

    [Subject("ZoneSettingsClient")]
    public class When_getting_zone_prefetch_preload_setting : RequestContext
    {
        static IdentifierTag _zoneId;
        static ZoneSetting<SettingOnOffTypes> _expected;
        static ZoneSetting<SettingOnOffTypes> _actual;
        static Uri _expectedRequestUri;

        Establish context = () =>
        {
            JObject source = SampleJson.ZoneSettingPrefetchPreload;
            _expected = source.ToObject<ZoneSetting<SettingOnOffTypes>>();
            var response = new CloudFlareResponse<JObject>(true, source);
            _zoneId = _fixture.Create<IdentifierTag>();
            _handler.SetResponseContent(response);
            _expectedRequestUri = new Uri(CloudFlareConstants.BaseUri, $"zones/{_zoneId}/settings/prefetch_preload");
        };

        //Because of = () => _actual = _sut.GetPrefetchPreloadSettingAsync(_zoneId, _auth).Await();

        Behaves_like<AuthenticatedRequestBehaviour> authenticated_request_behaviour;

        It should_make_a_GET_request = () => _handler.Request.Method.ShouldEqual(HttpMethod.Get);

        It should_request_the_zone_settings_endpoint
            = () => _handler.Request.RequestUri.ShouldEqual(_expectedRequestUri);

        It should_return_the_expected_zone_setting = () => _actual.AsLikeness().ShouldEqual(_expected);
    }

    [Subject("ZoneSettingsClient")]
    public class When_getting_zone_response_buffering_setting : RequestContext
    {
        static IdentifierTag _zoneId;
        static ZoneSetting<SettingOnOffTypes> _expected;
        static ZoneSetting<SettingOnOffTypes> _actual;
        static Uri _expectedRequestUri;

        Establish context = () =>
        {
            JObject source = SampleJson.ZoneSettingResponseBuffering;
            _expected = source.ToObject<ZoneSetting<SettingOnOffTypes>>();
            var response = new CloudFlareResponse<JObject>(true, source);
            _zoneId = _fixture.Create<IdentifierTag>();
            _handler.SetResponseContent(response);
            _expectedRequestUri = new Uri(CloudFlareConstants.BaseUri, $"zones/{_zoneId}/settings/response_buffering");
        };

        //Because of = () => _actual = _sut.GetResponseBufferingSettingAsync(_zoneId, _auth).Await();

        Behaves_like<AuthenticatedRequestBehaviour> authenticated_request_behaviour;

        It should_make_a_GET_request = () => _handler.Request.Method.ShouldEqual(HttpMethod.Get);

        It should_request_the_zone_settings_endpoint
            = () => _handler.Request.RequestUri.ShouldEqual(_expectedRequestUri);

        It should_return_the_expected_zone_setting = () => _actual.AsLikeness().ShouldEqual(_expected);
    }

    [Subject("ZoneSettingsClient")]
    public class When_getting_zone_rocket_loader_setting : RequestContext
    {
        static IdentifierTag _zoneId;
        static ZoneSetting<SettingRocketLoaderTypes> _expected;
        static ZoneSetting<SettingRocketLoaderTypes> _actual;
        static Uri _expectedRequestUri;

        Establish context = () =>
        {
            JObject source = SampleJson.ZoneSettingRocketLoader;
            _expected = source.ToObject<ZoneSetting<SettingRocketLoaderTypes>>();
            var response = new CloudFlareResponse<JObject>(true, source);
            _zoneId = _fixture.Create<IdentifierTag>();
            _handler.SetResponseContent(response);
            _expectedRequestUri = new Uri(CloudFlareConstants.BaseUri, $"zones/{_zoneId}/settings/rocket_loader");
        };

        //Because of = () => _actual = _sut.GetRocketLoaderSettingAsync(_zoneId, _auth).Await();

        Behaves_like<AuthenticatedRequestBehaviour> authenticated_request_behaviour;

        It should_make_a_GET_request = () => _handler.Request.Method.ShouldEqual(HttpMethod.Get);

        It should_request_the_zone_settings_endpoint
            = () => _handler.Request.RequestUri.ShouldEqual(_expectedRequestUri);

        It should_return_the_expected_zone_setting = () => _actual.AsLikeness().ShouldEqual(_expected);
    }

    [Subject("ZoneSettingsClient")]
    public class When_getting_zone_security_header_setting : RequestContext
    {
        static IdentifierTag _zoneId;
        static ZoneSetting<SettingSecurityHeader> _expected;
        static ZoneSetting<SettingSecurityHeader> _actual;
        static Uri _expectedRequestUri;

        Establish context = () =>
        {
            JObject source = SampleJson.ZoneSettingSecurityHeader;
            _expected = source.ToObject<ZoneSetting<SettingSecurityHeader>>();
            var response = new CloudFlareResponse<JObject>(true, source);
            _zoneId = _fixture.Create<IdentifierTag>();
            _handler.SetResponseContent(response);
            _expectedRequestUri = new Uri(CloudFlareConstants.BaseUri, $"zones/{_zoneId}/settings/security_header");
        };

        //Because of = () => _actual = _sut.GetSecurityHeaderSettingAsync(_zoneId, _auth).Await();

        Behaves_like<AuthenticatedRequestBehaviour> authenticated_request_behaviour;

        It should_make_a_GET_request = () => _handler.Request.Method.ShouldEqual(HttpMethod.Get);

        It should_request_the_zone_settings_endpoint
            = () => _handler.Request.RequestUri.ShouldEqual(_expectedRequestUri);

        It should_return_the_expected_zone_setting = () => _actual.AsLikeness().ShouldEqual(_expected);
    }

    [Subject("ZoneSettingsClient")]
    public class When_getting_zone_security_level_setting : RequestContext
    {
        static IdentifierTag _zoneId;
        static ZoneSetting<SettingSecurityLevelTypes> _expected;
        static ZoneSetting<SettingSecurityLevelTypes> _actual;
        static Uri _expectedRequestUri;

        Establish context = () =>
        {
            JObject source = SampleJson.ZoneSettingSecurityLevel;
            _expected = source.ToObject<ZoneSetting<SettingSecurityLevelTypes>>();
            var response = new CloudFlareResponse<JObject>(true, source);
            _zoneId = _fixture.Create<IdentifierTag>();
            _handler.SetResponseContent(response);
            _expectedRequestUri = new Uri(CloudFlareConstants.BaseUri, $"zones/{_zoneId}/settings/security_level");
        };

        //Because of = () => _actual = _sut.GetSecurityLevelSettingAsync(_zoneId, _auth).Await();

        Behaves_like<AuthenticatedRequestBehaviour> authenticated_request_behaviour;

        It should_make_a_GET_request = () => _handler.Request.Method.ShouldEqual(HttpMethod.Get);

        It should_request_the_zone_settings_endpoint
            = () => _handler.Request.RequestUri.ShouldEqual(_expectedRequestUri);

        It should_return_the_expected_zone_setting = () => _actual.AsLikeness().ShouldEqual(_expected);
    }

    [Subject("ZoneSettingsClient")]
    public class When_getting_zone_server_side_exclude_setting : RequestContext
    {
        static IdentifierTag _zoneId;
        static ZoneSetting<SettingOnOffTypes> _expected;
        static ZoneSetting<SettingOnOffTypes> _actual;
        static Uri _expectedRequestUri;

        Establish context = () =>
        {
            JObject source = SampleJson.ZoneSettingServerSideExclude;
            _expected = source.ToObject<ZoneSetting<SettingOnOffTypes>>();
            var response = new CloudFlareResponse<JObject>(true, source);
            _zoneId = _fixture.Create<IdentifierTag>();
            _handler.SetResponseContent(response);
            _expectedRequestUri =
                new Uri(CloudFlareConstants.BaseUri, $"zones/{_zoneId}/settings/server_side_exclude");
        };

        //Because of = () => _actual = _sut.GetServerSideExcludeSettingAsync(_zoneId, _auth).Await();

        Behaves_like<AuthenticatedRequestBehaviour> authenticated_request_behaviour;

        It should_make_a_GET_request = () => _handler.Request.Method.ShouldEqual(HttpMethod.Get);

        It should_request_the_zone_settings_endpoint
            = () => _handler.Request.RequestUri.ShouldEqual(_expectedRequestUri);

        It should_return_the_expected_zone_setting = () => _actual.AsLikeness().ShouldEqual(_expected);
    }

    [Subject("ZoneSettingsClient")]
    public class When_getting_zone_enable_query_string_sort_setting : RequestContext
    {
        static IdentifierTag _zoneId;
        static ZoneSetting<SettingOnOffTypes> _expected;
        static ZoneSetting<SettingOnOffTypes> _actual;
        static Uri _expectedRequestUri;

        Establish context = () =>
        {
            JObject source = SampleJson.ZoneSettingEnableQueryStringSort;
            _expected = source.ToObject<ZoneSetting<SettingOnOffTypes>>();
            var response = new CloudFlareResponse<JObject>(true, source);
            _zoneId = _fixture.Create<IdentifierTag>();
            _handler.SetResponseContent(response);
            _expectedRequestUri =
                new Uri(CloudFlareConstants.BaseUri, $"zones/{_zoneId}/settings/sort_query_string_for_cache");
        };

        //Because of = () => _actual = _sut.GetEnableQueryStringSortSettingAsync(_zoneId, _auth).Await();

        Behaves_like<AuthenticatedRequestBehaviour> authenticated_request_behaviour;

        It should_make_a_GET_request = () => _handler.Request.Method.ShouldEqual(HttpMethod.Get);

        It should_request_the_zone_settings_endpoint
            = () => _handler.Request.RequestUri.ShouldEqual(_expectedRequestUri);

        It should_return_the_expected_zone_setting = () => _actual.AsLikeness().ShouldEqual(_expected);
    }

    [Subject("ZoneSettingsClient")]
    public class When_getting_zone_ssl_setting : RequestContext
    {
        static IdentifierTag _zoneId;
        static ZoneSetting<SettingSslTypes> _expected;
        static ZoneSetting<SettingSslTypes> _actual;
        static Uri _expectedRequestUri;

        Establish context = () =>
        {
            JObject source = SampleJson.ZoneSettingSsl;
            _expected = source.ToObject<ZoneSetting<SettingSslTypes>>();
            var response = new CloudFlareResponse<JObject>(true, source);
            _zoneId = _fixture.Create<IdentifierTag>();
            _handler.SetResponseContent(response);
            _expectedRequestUri = new Uri(CloudFlareConstants.BaseUri, $"zones/{_zoneId}/settings/ssl");
        };

        //Because of = () => _actual = _sut.GetSslSettingAsync(_zoneId, _auth).Await();

        Behaves_like<AuthenticatedRequestBehaviour> authenticated_request_behaviour;

        It should_make_a_GET_request = () => _handler.Request.Method.ShouldEqual(HttpMethod.Get);

        It should_request_the_zone_settings_endpoint
            = () => _handler.Request.RequestUri.ShouldEqual(_expectedRequestUri);

        It should_return_the_expected_zone_setting = () => _actual.AsLikeness().ShouldEqual(_expected);
    }

    [Subject("ZoneSettingsClient")]
    public class When_getting_zone_enable_TLS_1_2_setting : RequestContext
    {
        static IdentifierTag _zoneId;
        static ZoneSetting<SettingOnOffTypes> _expected;
        static ZoneSetting<SettingOnOffTypes> _actual;
        static Uri _expectedRequestUri;

        Establish context = () =>
        {
            JObject source = SampleJson.ZoneSettingEnableTls12;
            _expected = source.ToObject<ZoneSetting<SettingOnOffTypes>>();
            var response = new CloudFlareResponse<JObject>(true, source);
            _zoneId = _fixture.Create<IdentifierTag>();
            _handler.SetResponseContent(response);
            _expectedRequestUri = new Uri(CloudFlareConstants.BaseUri, $"zones/{_zoneId}/settings/tls_1_2_only");
        };

        //Because of = () => _actual = _sut.GetZoneEnableTls12SettingAsync(_zoneId, _auth).Await();

        Behaves_like<AuthenticatedRequestBehaviour> authenticated_request_behaviour;

        It should_make_a_GET_request = () => _handler.Request.Method.ShouldEqual(HttpMethod.Get);

        It should_request_the_zone_settings_endpoint
            = () => _handler.Request.RequestUri.ShouldEqual(_expectedRequestUri);

        It should_return_the_expected_zone_setting = () => _actual.AsLikeness().ShouldEqual(_expected);
    }

    [Subject("ZoneSettingsClient")]
    public class When_getting_zone_tls_client_auth_setting : RequestContext
    {
        static IdentifierTag _zoneId;
        static ZoneSetting<SettingOnOffTypes> _expected;
        static ZoneSetting<SettingOnOffTypes> _actual;
        static Uri _expectedRequestUri;

        Establish context = () =>
        {
            JObject source = SampleJson.ZoneSettingTlsClientAuth;
            _expected = source.ToObject<ZoneSetting<SettingOnOffTypes>>();
            var response = new CloudFlareResponse<JObject>(true, source);
            _zoneId = _fixture.Create<IdentifierTag>();
            _handler.SetResponseContent(response);
            _expectedRequestUri = new Uri(CloudFlareConstants.BaseUri, $"zones/{_zoneId}/settings/tls_client_auth");
        };

        //Because of = () => _actual = _sut.GetTlsClientAuthSettingAsync(_zoneId, _auth).Await();

        Behaves_like<AuthenticatedRequestBehaviour> authenticated_request_behaviour;

        It should_make_a_GET_request = () => _handler.Request.Method.ShouldEqual(HttpMethod.Get);

        It should_request_the_zone_settings_endpoint
            = () => _handler.Request.RequestUri.ShouldEqual(_expectedRequestUri);

        It should_return_the_expected_zone_setting = () => _actual.AsLikeness().ShouldEqual(_expected);
    }

    [Subject("ZoneSettingsClient")]
    public class When_getting_zone_true_client_ip_setting : RequestContext
    {
        static IdentifierTag _zoneId;
        static ZoneSetting<SettingOnOffTypes> _expected;
        static ZoneSetting<SettingOnOffTypes> _actual;
        static Uri _expectedRequestUri;

        Establish context = () =>
        {
            JObject source = SampleJson.ZoneSettingTrueClientIp;
            _expected = source.ToObject<ZoneSetting<SettingOnOffTypes>>();
            var response = new CloudFlareResponse<JObject>(true, source);
            _zoneId = _fixture.Create<IdentifierTag>();
            _handler.SetResponseContent(response);
            _expectedRequestUri =
                new Uri(CloudFlareConstants.BaseUri, $"zones/{_zoneId}/settings/true_client_ip_header");
        };

        //Because of = () => _actual = _sut.GetTrueClientIpSettingAsync(_zoneId, _auth).Await();

        Behaves_like<AuthenticatedRequestBehaviour> authenticated_request_behaviour;

        It should_make_a_GET_request = () => _handler.Request.Method.ShouldEqual(HttpMethod.Get);

        It should_request_the_zone_settings_endpoint
            = () => _handler.Request.RequestUri.ShouldEqual(_expectedRequestUri);

        It should_return_the_expected_zone_setting = () => _actual.AsLikeness().ShouldEqual(_expected);
    }

    [Subject("ZoneSettingsClient")]
    public class When_getting_zone_web_application_firewall_setting : RequestContext
    {
        static IdentifierTag _zoneId;
        static ZoneSetting<SettingOnOffTypes> _expected;
        static ZoneSetting<SettingOnOffTypes> _actual;
        static Uri _expectedRequestUri;

        Establish context = () =>
        {
            JObject source = SampleJson.ZoneSettingWebApplicationFirewall;
            _expected = source.ToObject<ZoneSetting<SettingOnOffTypes>>();
            var response = new CloudFlareResponse<JObject>(true, source);
            _zoneId = _fixture.Create<IdentifierTag>();
            _handler.SetResponseContent(response);
            _expectedRequestUri = new Uri(CloudFlareConstants.BaseUri, $"zones/{_zoneId}/settings/waf");
        };

        //Because of = () => _actual = _sut.GetWebApplicationFirewallSettingAsync(_zoneId, _auth).Await();

        Behaves_like<AuthenticatedRequestBehaviour> authenticated_request_behaviour;

        It should_make_a_GET_request = () => _handler.Request.Method.ShouldEqual(HttpMethod.Get);

        It should_request_the_zone_settings_endpoint
            = () => _handler.Request.RequestUri.ShouldEqual(_expectedRequestUri);

        It should_return_the_expected_zone_setting = () => _actual.AsLikeness().ShouldEqual(_expected);
    }
}
