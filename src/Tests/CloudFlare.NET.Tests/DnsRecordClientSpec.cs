namespace CloudFlare.NET.DnsRecordClientSpec
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Net.Http;
    using Machine.Specifications;
    using Newtonsoft.Json.Linq;
    using Ploeh.AutoFixture;

    [Subject("DnsRecordClient")]
    public class When_getting_dns_records : RequestContext
    {
        static IdentifierTag _zoneId;
        static CloudFlareResponse<IReadOnlyList<DnsRecord>> _expected;
        static CloudFlareResponse<IReadOnlyList<DnsRecord>> _actual;
        static Uri _expectedRequestUri;

        Establish context = () =>
        {
            _zoneId = _fixture.Create<IdentifierTag>();
            _expected = _fixture.Create<CloudFlareResponse<IReadOnlyList<DnsRecord>>>();
            _handler.SetResponseContent(_expected);
            _expectedRequestUri = new Uri(CloudFlareConstants.BaseUri, $"zones/{_zoneId}/dns_records");
        };

        Because of = () => _actual = _sut.GetDnsRecordsAsync(_zoneId, _auth).Await();

        Behaves_like<AuthenticatedRequestBehaviour> authenticated_request_behaviour;

        It should_make_a_GET_request = () => _handler.Request.Method.ShouldEqual(HttpMethod.Get);

        It should_request_the_DNS_records_endpoint
            = () => _handler.Request.RequestUri.ShouldEqual(_expectedRequestUri);

        It should_return_the_expected_dns_records = () =>
            _actual.Result.Select(i => i.AsLikeness().CreateProxy()).SequenceEqual(_expected.Result).ShouldBeTrue();
    }

    [Subject("DnsRecordClient")]
    public class When_getting_dns_records_with_parameters : RequestContext
    {
        static IdentifierTag _zoneId;
        static CloudFlareResponse<IReadOnlyList<DnsRecord>> _expected;
        static CloudFlareResponse<IReadOnlyList<DnsRecord>> _actual;
        static DnsRecordGetParameters _parameters;
        static Uri _expectedRequestUri;

        Establish context = () =>
        {
            _zoneId = _fixture.Create<IdentifierTag>();
            _expected = _fixture.Create<CloudFlareResponse<IReadOnlyList<DnsRecord>>>();
            _handler.SetResponseContent(_expected);

            // Auto fixture chooses the default value for enumerations.
            _fixture.Inject(DnsRecordOrderTypes.proxied);
            _fixture.Inject(PagedParametersOrderType.desc);
            _fixture.Inject(PagedParametersMatchType.any);

            _parameters = _fixture.Create<DnsRecordGetParameters>();

            _expectedRequestUri
                = new Uri(CloudFlareConstants.BaseUri, $"zones/{_zoneId}/dns_records?{_parameters.ToQuery()}");
        };

        Because of = () => _actual = _sut.GetDnsRecordsAsync(_zoneId, _auth, _parameters).Await();

        Behaves_like<AuthenticatedRequestBehaviour> authenticated_request_behaviour;

        It should_make_a_GET_request = () => _handler.Request.Method.ShouldEqual(HttpMethod.Get);

        It should_request_the_DNS_records_endpoint
            = () => _handler.Request.RequestUri.ShouldEqual(_expectedRequestUri);

        It should_return_the_expected_dns_records = () =>
            _actual.Result.Select(i => i.AsLikeness().CreateProxy()).SequenceEqual(_expected.Result).ShouldBeTrue();
    }

    [Subject("DnsRecordClient")]
    public class When_getting_all_dns_records : GetAllResultsContext<DnsRecord>
    {
        static IdentifierTag _zoneId;
        static Uri _expectedFirstRequestUri;
        static Uri _expectedSecondRequestUri;
        static Uri _expectedLastRequestUri;

        Establish context = () =>
        {
            _zoneId = _fixture.Create<IdentifierTag>();

            string firstParams = new DnsRecordGetParameters(page: 1, perPage: 100).ToQuery();
            string secondParams = new DnsRecordGetParameters(page: 2, perPage: 100).ToQuery();
            string lastParams = new DnsRecordGetParameters(page: 3, perPage: 100).ToQuery();

            _expectedFirstRequestUri
                = new Uri(CloudFlareConstants.BaseUri, $"zones/{_zoneId}/dns_records?{firstParams}");
            _expectedSecondRequestUri
                = new Uri(CloudFlareConstants.BaseUri, $"zones/{_zoneId}/dns_records?{secondParams}");
            _expectedLastRequestUri
                = new Uri(CloudFlareConstants.BaseUri, $"zones/{_zoneId}/dns_records?{lastParams}");
        };

        Because of = () => _actual = _sut.GetAllDnsRecordsAsync(_zoneId, _auth).Await().AsTask.Result;

        Behaves_like<AuthenticatedRequestBehaviour> authenticated_request_behaviour;

        It should_make_a_GET_request = () => _handler.Request.Method.ShouldEqual(HttpMethod.Get);

        It should_request_the_first_page = () => _handler.Requests[0].RequestUri.ShouldEqual(_expectedFirstRequestUri);

        It should_request_the_second_page =
            () => _handler.Requests[1].RequestUri.ShouldEqual(_expectedSecondRequestUri);

        It should_request_the_last_page = () => _handler.Requests[2].RequestUri.ShouldEqual(_expectedLastRequestUri);

        It should_return_the_expected_dns_records = () =>
            _actual.Select(z => z.AsLikeness().CreateProxy()).SequenceEqual(_expected).ShouldBeTrue();
    }

    [Subject("DnsRecordClient")]
    public class When_getting_all_dns_records_with_parameters : GetAllResultsContext<DnsRecord>
    {
        static IdentifierTag _zoneId;
        static DnsRecordGetParameters _parameters;
        static Uri _expectedFirstRequestUri;
        static Uri _expectedSecondRequestUri;
        static Uri _expectedLastRequestUri;

        Establish context = () =>
        {
            _zoneId = _fixture.Create<IdentifierTag>();

            // Auto fixture chooses the default value for enumerations.
            _fixture.Inject(DnsRecordOrderTypes.proxied);
            _fixture.Inject(PagedParametersOrderType.desc);
            _fixture.Inject(PagedParametersMatchType.any);

            _parameters = _fixture.Create<DnsRecordGetParameters>();

            JObject first = JObject.FromObject(_parameters);
            first.Merge(JObject.FromObject(new { page = 1, per_page = 100 }));
            string firstParams = first.ToObject<DnsRecordGetParameters>().ToQuery();

            JObject second = JObject.FromObject(_parameters);
            second.Merge(JObject.FromObject(new { page = 2, per_page = 100 }));
            string secondParams = second.ToObject<DnsRecordGetParameters>().ToQuery();

            JObject last = JObject.FromObject(_parameters);
            last.Merge(JObject.FromObject(new { page = 3, per_page = 100 }));
            string lastParams = last.ToObject<DnsRecordGetParameters>().ToQuery();

            _expectedFirstRequestUri
                = new Uri(CloudFlareConstants.BaseUri, $"zones/{_zoneId}/dns_records?{firstParams}");
            _expectedSecondRequestUri
                = new Uri(CloudFlareConstants.BaseUri, $"zones/{_zoneId}/dns_records?{secondParams}");
            _expectedLastRequestUri
                = new Uri(CloudFlareConstants.BaseUri, $"zones/{_zoneId}/dns_records?{lastParams}");
        };

        Because of = () => _actual = _sut.GetAllDnsRecordsAsync(_zoneId, _auth, _parameters).Await().AsTask.Result;

        Behaves_like<AuthenticatedRequestBehaviour> authenticated_request_behaviour;

        It should_make_a_GET_request = () => _handler.Request.Method.ShouldEqual(HttpMethod.Get);

        It should_request_the_first_page = () => _handler.Requests[0].RequestUri.ShouldEqual(_expectedFirstRequestUri);

        It should_request_the_second_page =
            () => _handler.Requests[1].RequestUri.ShouldEqual(_expectedSecondRequestUri);

        It should_request_the_last_page = () => _handler.Requests[2].RequestUri.ShouldEqual(_expectedLastRequestUri);

        It should_return_the_expected_dns_records = () =>
            _actual.Select(z => z.AsLikeness().CreateProxy()).SequenceEqual(_expected).ShouldBeTrue();
    }

    [Subject("DnsRecordClient")]
    public class When_getting_dns_records_and_an_error_occurs : ErredRequestContext
    {
        static IdentifierTag _zoneId;
        static Uri _expectedRequestUri;

        Establish context = () =>
        {
            _zoneId = _fixture.Create<IdentifierTag>();
            _expectedRequestUri = new Uri(CloudFlareConstants.BaseUri, $"zones/{_zoneId}/dns_records");
        };

        Because of = () => _exception = Catch.Exception(() => _sut.GetDnsRecordsAsync(_zoneId, _auth).Await());

        Behaves_like<AuthenticatedRequestBehaviour> authenticated_request_behaviour;

        Behaves_like<ErredRequestBehaviour> erred_request_behaviour;

        It should_make_a_GET_request = () => _handler.Request.Method.ShouldEqual(HttpMethod.Get);

        It should_request_the_DNS_records_endpoint
            = () => _handler.Request.RequestUri.ShouldEqual(_expectedRequestUri);
    }
}
