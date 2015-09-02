namespace CloudFlare.NET.DnsRecordSpec
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading;
    using Machine.Specifications;
    using Moq;
    using Ploeh.AutoFixture;
    using It = Machine.Specifications.It;

    [Subject(typeof(DnsRecordClientExtensions))]
    public class When_getting_dns_records : FixtureContext
    {
        static Mock<IDnsRecordClient> _dnsRecordClientMock;
        static CloudFlareAuth _auth;
        static IdentifierTag _zoneId;
        static CloudFlareResponse<IReadOnlyList<DnsRecord>> _expected;
        static CloudFlareResponse<IReadOnlyList<DnsRecord>> _actual;

        Establish context = () =>
        {
            _dnsRecordClientMock = _fixture.Create<Mock<IDnsRecordClient>>();
            _auth = _fixture.Create<CloudFlareAuth>();
            _zoneId = _fixture.Create<IdentifierTag>();
            _expected = _fixture.Create<CloudFlareResponse<IReadOnlyList<DnsRecord>>>();
            _dnsRecordClientMock
                .Setup(
                    c => c.GetDnsRecordsAsync(
                        _zoneId,
                        CancellationToken.None,
                        default(PagedDnsRecordParameters),
                        _auth))
                .ReturnsAsync(_expected);
        };

        Because of = () => _actual = _dnsRecordClientMock.Object.GetDnsRecordsAsync(_zoneId, _auth).Await();

        It should_return_the_dns_records = () => _actual.ShouldBeTheSameAs(_expected);
    }

    [Subject(typeof(DnsRecordClientExtensions))]
    public class When_getting_dns_records_with_parameters : FixtureContext
    {
        static Mock<IDnsRecordClient> _dnsRecordClientMock;
        static IdentifierTag _zoneId;
        static PagedDnsRecordParameters _parameters;
        static CloudFlareResponse<IReadOnlyList<DnsRecord>> _expected;
        static CloudFlareResponse<IReadOnlyList<DnsRecord>> _actual;

        Establish context = () =>
        {
            _dnsRecordClientMock = _fixture.Create<Mock<IDnsRecordClient>>();
            _zoneId = _fixture.Create<IdentifierTag>();
            _parameters = _fixture.Create<PagedDnsRecordParameters>();
            _expected = _fixture.Create<CloudFlareResponse<IReadOnlyList<DnsRecord>>>();
            _dnsRecordClientMock
                .Setup(
                    c => c.GetDnsRecordsAsync(_zoneId, CancellationToken.None, _parameters, default(CloudFlareAuth)))
                .ReturnsAsync(_expected);
        };

        Because of = () => _actual = _dnsRecordClientMock.Object.GetDnsRecordsAsync(_zoneId, _parameters).Await();

        It should_return_the_dns_records = () => _actual.ShouldBeTheSameAs(_expected);
    }

    [Subject(typeof(DnsRecordClientExtensions))]
    public class When_getting_all_dns_records : FixtureContext
    {
        static Mock<IDnsRecordClient> _dnsRecordClientMock;
        static CloudFlareAuth _auth;
        static IdentifierTag _zoneId;
        static IEnumerable<DnsRecord> _expected;
        static IEnumerable<DnsRecord> _actual;

        Establish context = () =>
        {
            _dnsRecordClientMock = _fixture.Create<Mock<IDnsRecordClient>>();
            _auth = _fixture.Create<CloudFlareAuth>();
            _zoneId = _fixture.Create<IdentifierTag>();
            _expected = _fixture.CreateMany<DnsRecord>();
            _dnsRecordClientMock
                .Setup(
                    c => c.GetAllDnsRecordsAsync(
                        _zoneId,
                        CancellationToken.None,
                        default(PagedDnsRecordParameters),
                        _auth))
                .ReturnsAsync(_expected);
        };

        Because of =
            () => _actual = _dnsRecordClientMock.Object.GetAllDnsRecordsAsync(_zoneId, _auth).Await().AsTask.Result;

        It should_return_all_the_dns_records = () => _actual.ShouldBeTheSameAs(_expected);
    }

    [Subject(typeof(DnsRecordClientExtensions))]
    public class When_getting_all_dns_records_with_parameters : FixtureContext
    {
        static Mock<IDnsRecordClient> _dnsRecordClientMock;
        static IdentifierTag _zoneId;
        static PagedDnsRecordParameters _parameters;
        static IEnumerable<DnsRecord> _expected;
        static IEnumerable<DnsRecord> _actual;

        Establish context = () =>
        {
            _dnsRecordClientMock = _fixture.Create<Mock<IDnsRecordClient>>();
            _zoneId = _fixture.Create<IdentifierTag>();
            _parameters = _fixture.Create<PagedDnsRecordParameters>();
            _expected = _fixture.CreateMany<DnsRecord>();
            _dnsRecordClientMock
                .Setup(
                    c => c.GetAllDnsRecordsAsync(
                        _zoneId,
                        CancellationToken.None,
                        _parameters,
                        default(CloudFlareAuth)))
                .ReturnsAsync(_expected);
        };

        Because of =
            () => _actual = _dnsRecordClientMock.Object.GetAllDnsRecordsAsync(_zoneId, _parameters).Await()
                .AsTask.Result;

        It should_return_all_the_dns_records = () => _actual.ShouldBeTheSameAs(_expected);
    }
}
