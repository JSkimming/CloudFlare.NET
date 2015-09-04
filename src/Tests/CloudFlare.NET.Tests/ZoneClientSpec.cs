namespace CloudFlare.NET.ZoneClientSpec
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Net.Http;
    using Machine.Specifications;
    using Newtonsoft.Json.Linq;
    using Ploeh.AutoFixture;

    [Subject("ZoneClient")]
    public class When_getting_zones : RequestContext
    {
        static CloudFlareResponse<IReadOnlyList<Zone>> _expected;
        static CloudFlareResponse<IReadOnlyList<Zone>> _actual;
        static Uri _expectedRequestUri;

        Establish context = () =>
        {
            _expected = _fixture.Create<CloudFlareResponse<IReadOnlyList<Zone>>>();
            _handler.SetResponseContent(_expected);
            _expectedRequestUri = new Uri(CloudFlareConstants.BaseUri, "zones");
        };

        Because of = () => _actual = _sut.GetZonesAsync(_auth).Await();

        Behaves_like<AuthenticatedRequestBehaviour> authenticated_request_behaviour;

        It should_make_a_GET_request = () => _handler.Request.Method.ShouldEqual(HttpMethod.Get);

        It should_request_the_zones_endpoint = () => _handler.Request.RequestUri.ShouldEqual(_expectedRequestUri);

        It should_return_the_expected_zones = () =>
            _actual.Result.Select(z => z.AsLikeness().CreateProxy()).SequenceEqual(_expected.Result).ShouldBeTrue();
    }

    [Subject("ZoneClient")]
    public class When_getting_zones_with_parameters : RequestContext
    {
        static CloudFlareResponse<IReadOnlyList<Zone>> _expected;
        static CloudFlareResponse<IReadOnlyList<Zone>> _actual;
        static ZoneGetParameters _parameters;
        static Uri _expectedRequestUri;

        Establish context = () =>
        {
            _expected = _fixture.Create<CloudFlareResponse<IReadOnlyList<Zone>>>();
            _handler.SetResponseContent(_expected);

            // Auto fixture chooses the default value for enumerations.
            _fixture.Inject(ZoneOrderTypes.email);
            _fixture.Inject(PagedParametersOrderType.desc);
            _fixture.Inject(PagedParametersMatchType.any);

            _parameters = _fixture.Create<ZoneGetParameters>();

            _expectedRequestUri = new Uri(CloudFlareConstants.BaseUri, "zones?" + _parameters.ToQuery());
        };

        Because of = () => _actual = _sut.GetZonesAsync(_auth, _parameters).Await();

        Behaves_like<AuthenticatedRequestBehaviour> authenticated_request_behaviour;

        It should_make_a_GET_request = () => _handler.Request.Method.ShouldEqual(HttpMethod.Get);

        It should_request_the_zones_endpoint = () => _handler.Request.RequestUri.ShouldEqual(_expectedRequestUri);

        It should_return_the_expected_zones = () =>
            _actual.Result.Select(z => z.AsLikeness().CreateProxy()).SequenceEqual(_expected.Result).ShouldBeTrue();
    }

    [Subject("ZoneClient")]
    public class When_getting_all_zones : GetAllResultsContext<Zone>
    {
        static Uri _expectedFirstRequestUri;
        static Uri _expectedSecondRequestUri;
        static Uri _expectedLastRequestUri;

        Establish context = () =>
        {
            string firstParams = new ZoneGetParameters(page: 1, perPage: 50).ToQuery();
            string secondParams = new ZoneGetParameters(page: 2, perPage: 50).ToQuery();
            string lastParams = new ZoneGetParameters(page: 3, perPage: 50).ToQuery();

            _expectedFirstRequestUri = new Uri(CloudFlareConstants.BaseUri, "zones?" + firstParams);
            _expectedSecondRequestUri = new Uri(CloudFlareConstants.BaseUri, "zones?" + secondParams);
            _expectedLastRequestUri = new Uri(CloudFlareConstants.BaseUri, "zones?" + lastParams);
        };

        Because of = () => _actual = _sut.GetAllZonesAsync(_auth).Await().AsTask.Result;

        Behaves_like<AuthenticatedRequestBehaviour> authenticated_request_behaviour;

        It should_make_a_GET_request = () => _handler.Request.Method.ShouldEqual(HttpMethod.Get);

        It should_request_the_first_page = () => _handler.Requests[0].RequestUri.ShouldEqual(_expectedFirstRequestUri);

        It should_request_the_second_page =
            () => _handler.Requests[1].RequestUri.ShouldEqual(_expectedSecondRequestUri);

        It should_request_the_last_page = () => _handler.Requests[2].RequestUri.ShouldEqual(_expectedLastRequestUri);

        It should_return_the_expected_zones = () =>
            _actual.Select(z => z.AsLikeness().CreateProxy()).SequenceEqual(_expected).ShouldBeTrue();
    }

    [Subject("ZoneClient")]
    public class When_getting_all_zones_with_parameters : GetAllResultsContext<Zone>
    {
        static ZoneGetParameters _parameters;
        static Uri _expectedFirstRequestUri;
        static Uri _expectedSecondRequestUri;
        static Uri _expectedLastRequestUri;

        Establish context = () =>
        {
            // Auto fixture chooses the default value for enumerations.
            _fixture.Inject(ZoneOrderTypes.email);
            _fixture.Inject(PagedParametersOrderType.desc);
            _fixture.Inject(PagedParametersMatchType.any);

            _parameters = _fixture.Create<ZoneGetParameters>();

            JObject first = JObject.FromObject(_parameters);
            first.Merge(JObject.FromObject(new { page = 1, per_page = 50 }));
            string firstParams = first.ToObject<ZoneGetParameters>().ToQuery();

            JObject second = JObject.FromObject(_parameters);
            second.Merge(JObject.FromObject(new { page = 2, per_page = 50 }));
            string secondParams = second.ToObject<ZoneGetParameters>().ToQuery();

            JObject last = JObject.FromObject(_parameters);
            last.Merge(JObject.FromObject(new { page = 3, per_page = 50 }));
            string lastParams = last.ToObject<ZoneGetParameters>().ToQuery();

            _expectedFirstRequestUri = new Uri(CloudFlareConstants.BaseUri, "zones?" + firstParams);
            _expectedSecondRequestUri  = new Uri(CloudFlareConstants.BaseUri, "zones?" + secondParams);
            _expectedLastRequestUri = new Uri(CloudFlareConstants.BaseUri, "zones?" + lastParams);
        };

        Because of = () => _actual = _sut.GetAllZonesAsync(_auth, _parameters).Await().AsTask.Result;

        Behaves_like<AuthenticatedRequestBehaviour> authenticated_request_behaviour;

        It should_make_a_GET_request = () => _handler.Request.Method.ShouldEqual(HttpMethod.Get);

        It should_request_the_first_page = () => _handler.Requests[0].RequestUri.ShouldEqual(_expectedFirstRequestUri);

        It should_request_the_second_page =
            () => _handler.Requests[1].RequestUri.ShouldEqual(_expectedSecondRequestUri);

        It should_request_the_last_page = () => _handler.Requests[2].RequestUri.ShouldEqual(_expectedLastRequestUri);

        It should_return_the_expected_zones = () =>
            _actual.Select(z => z.AsLikeness().CreateProxy()).SequenceEqual(_expected).ShouldBeTrue();
    }

    [Subject("ZoneClient")]
    public class When_getting_zones_and_an_error_occurs : ErredRequestContext
    {
        static Uri _expectedRequestUri;

        Establish context = () =>
        {
            _expectedRequestUri = new Uri(CloudFlareConstants.BaseUri, "zones");
        };

        Because of = () => _exception = Catch.Exception(() => _sut.GetZonesAsync(_auth).Await());

        Behaves_like<AuthenticatedRequestBehaviour> authenticated_request_behaviour;

        Behaves_like<ErredRequestBehaviour> erred_request_behaviour;

        It should_make_a_GET_request = () => _handler.Request.Method.ShouldEqual(HttpMethod.Get);

        It should_request_the_zones_endpoint = () => _handler.Request.RequestUri.ShouldEqual(_expectedRequestUri);
    }

    [Subject("ZoneClient")]
    public class When_getting_a_zone : RequestContext
    {
        static Zone _expected;
        static Zone _actual;
        static Uri _expectedRequestUri;

        Establish context = () =>
        {
            var response = _fixture.Create<CloudFlareResponse<Zone>>();
            _expected = response.Result;
            _handler.SetResponseContent(response);
            _expectedRequestUri = new Uri(CloudFlareConstants.BaseUri, $"zones/{_expected.Id}");
        };

        Because of = () => _actual = _sut.GetZoneAsync(_expected.Id, _auth).Await();

        Behaves_like<AuthenticatedRequestBehaviour> authenticated_request_behaviour;

        It should_make_a_GET_request = () => _handler.Request.Method.ShouldEqual(HttpMethod.Get);

        It should_request_the_zone_endpoint = () => _handler.Request.RequestUri.ShouldEqual(_expectedRequestUri);

        It should_return_the_expected_zones = () => _actual.AsLikeness().ShouldEqual(_expected);
    }

    [Subject("ZoneClient")]
    public class When_getting_a_zone_and_an_error_occurs : ErredRequestContext
    {
        static IdentifierTag _zoneId;
        static Uri _expectedRequestUri;

        Establish context = () =>
        {
            _zoneId = _fixture.Create<IdentifierTag>();
            _expectedRequestUri = new Uri(CloudFlareConstants.BaseUri, $"zones/{_zoneId}");
        };

        Because of = () => _exception = Catch.Exception(() => _sut.GetZoneAsync(_zoneId, _auth).Await());

        Behaves_like<AuthenticatedRequestBehaviour> authenticated_request_behaviour;

        Behaves_like<ErredRequestBehaviour> erred_request_behaviour;

        It should_make_a_GET_request = () => _handler.Request.Method.ShouldEqual(HttpMethod.Get);

        It should_request_the_zone_endpoint = () => _handler.Request.RequestUri.ShouldEqual(_expectedRequestUri);
    }
}
