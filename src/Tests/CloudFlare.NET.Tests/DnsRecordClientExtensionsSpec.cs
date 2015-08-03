namespace CloudFlare.NET.DnsRecordSpec
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading;
    using System.Threading.Tasks;
    using Machine.Specifications;
    using Moq;
    using Ploeh.AutoFixture;
    using MoqIt = Moq.It;
    using It = Machine.Specifications.It;

    [Subject(typeof(DnsRecordClientExtensions))]
    public class When_getting_dnsRecords : FixtureContext
    {
        static Mock<IDnsRecordClient> _dnsRecordClientMock;
        static CloudFlareAuth _auth;
        static IdentifierTag _zoneId;
        static IReadOnlyList<DnsRecord> _expected;
        static IReadOnlyList<DnsRecord> _actual;

        Establish context = () =>
        {
            _dnsRecordClientMock = _fixture.Create<Mock<IDnsRecordClient>>();
            _auth = _fixture.Create<CloudFlareAuth>();
            _zoneId = _fixture.Create<IdentifierTag>();
            _expected = _fixture.Create<DnsRecord[]>();
            _dnsRecordClientMock
                .Setup(c => c.GetDnsRecordsAsync(_zoneId, CancellationToken.None, _auth))
                .ReturnsAsync(_expected);
        };

        Because of = () => _actual = _dnsRecordClientMock.Object.GetDnsRecordsAsync(_zoneId, _auth).Await().AsTask.Result;

        It should_return_the_zones = () => _actual.ShouldBeTheSameAs(_expected);
    }
}
