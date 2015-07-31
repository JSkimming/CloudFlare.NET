namespace CloudFlare.NET.ZoneSpec
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

    [Subject(typeof(ZoneClientExtensions))]
    public class When_getting_zones : FixtureContext
    {
        static Mock<IZoneClient> _zoneClientMock;
        static CloudFlareAuth _auth;
        static IReadOnlyList<Zone> _expected;
        static IReadOnlyList<Zone> _actual;

        Establish context = () =>
        {
            _zoneClientMock = _fixture.Create<Mock<IZoneClient>>();
            _auth = _fixture.Create<CloudFlareAuth>();
            _expected = _fixture.Create<Zone[]>();
            _zoneClientMock
                .Setup(c => c.GetZonesAsync(CancellationToken.None, _auth))
                .ReturnsAsync(_expected);
        };

        Because of = () => _actual = _zoneClientMock.Object.GetZonesAsync(_auth).Await().AsTask.Result;

        It should_return_the_zones = () => _actual.ShouldBeTheSameAs(_expected);
    }
}
