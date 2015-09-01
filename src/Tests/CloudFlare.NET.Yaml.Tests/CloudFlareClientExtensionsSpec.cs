namespace CloudFlare.NET
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading;
    using System.Threading.Tasks;
    using Machine.Specifications;
    using Moq;
    using Ploeh.AutoFixture;
    using It = Machine.Specifications.It;

    public class When_getting_all_the_zone_data : FixtureContext
    {
        static Zone _expectedZone;
        static IReadOnlyList<DnsRecord> _expectedDnsRecords;
        static ZoneData _actual;
        static CloudFlareAuth _auth;
        static Mock<ICloudFlareClient> _clientMock;

        Establish context = () =>
        {
            _expectedZone = _fixture.Create<Zone>();
            var dnsRecordsResponse = _fixture.Create<CloudFlareResponse<IReadOnlyList<DnsRecord>>>();
            _expectedDnsRecords = dnsRecordsResponse.Result;
            _auth = _fixture.Create<CloudFlareAuth>();
            _clientMock = _fixture.Create<Mock<ICloudFlareClient>>();

            _clientMock.Setup(c => c.GetZoneAsync(_expectedZone.Id, CancellationToken.None, _auth))
                .ReturnsAsync(_expectedZone);
            _clientMock.Setup(
                c => c.GetDnsRecordsAsync(
                    _expectedZone.Id,
                    CancellationToken.None,
                    default(PagedDnsRecordParameters),
                    _auth))
                .ReturnsAsync(dnsRecordsResponse);
        };

        Because of = () => _actual = _clientMock.Object.GetZoneDataAsync(_expectedZone.Id, _auth).Await();

        It should_get_the_zone = () => _actual.Zone.ShouldBeTheSameAs(_expectedZone);

        It should_get_the_DNS_records = () => _actual.DnsRecords.ShouldBeTheSameAs(_expectedDnsRecords);
    }
}
