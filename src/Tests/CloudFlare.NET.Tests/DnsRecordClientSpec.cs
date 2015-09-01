namespace CloudFlare.NET.DnsRecordClientSpec
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Net.Http;
    using Machine.Specifications;
    using Ploeh.AutoFixture;

    [Subject(typeof(CloudFlareClient))]
    public class When_getting_all_dns_records : RequestContext
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

    [Subject(typeof(CloudFlareClient))]
    public class When_getting_all_dns_records_with_parameters : RequestContext
    {
        static IdentifierTag _zoneId;
        static CloudFlareResponse<IReadOnlyList<DnsRecord>> _expected;
        static CloudFlareResponse<IReadOnlyList<DnsRecord>> _actual;
        static PagedDnsRecordParameters _parameters;
        static Uri _expectedRequestUri;

        Establish context = () =>
        {
            _zoneId = _fixture.Create<IdentifierTag>();
            _expected = _fixture.Create<CloudFlareResponse<IReadOnlyList<DnsRecord>>>();
            _handler.SetResponseContent(_expected);

            // Auto fixture chooses the default value for enumerations.
            _fixture.Inject(PagedDnsRecordOrderFieldTypes.proxied);
            _fixture.Inject(PagedParametersOrderType.desc);
            _fixture.Inject(PagedParametersMatchType.any);

            _parameters = _fixture.Create<PagedDnsRecordParameters>();

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

    [Subject(typeof(CloudFlareClient))]
    public class When_getting_dnsRecords_and_an_error_occurs : ErredRequestContext
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
