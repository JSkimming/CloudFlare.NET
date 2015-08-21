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
        static ZoneData _expected;
        static ZoneData _actual;
        static CloudFlareAuth _auth;
        static Mock<ICloudFlareClient> _clientMock;

        Establish context = () =>
        {
            _expected = _fixture.Create<ZoneData>();
            _auth = _fixture.Create<CloudFlareAuth>();
            _clientMock = _fixture.Create<Mock<ICloudFlareClient>>();

            _clientMock.Setup(c => c.GetZoneAsync(_expected.Zone.Id, CancellationToken.None, _auth))
                .ReturnsAsync(_expected.Zone);
            _clientMock.Setup(c => c.GetDnsRecordsAsync(_expected.Zone.Id, CancellationToken.None, _auth))
                .ReturnsAsync(_expected.DnsRecords);
        };

        Because of = () => _actual = _clientMock.Object.GetZoneDataAsync(_expected.Zone.Id, _auth).Await();

        It should_get_the_zone = () => _actual.Zone.ShouldBeTheSameAs(_expected.Zone);

        It should_get_the_DNS_records = () => _actual.DnsRecords.ShouldBeTheSameAs(_expected.DnsRecords);
    }
}
