namespace CloudFlare.NET.ZoneClientExtensionsSpec
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading;
    using Machine.Specifications;
    using Moq;
    using Ploeh.AutoFixture;
    using It = Machine.Specifications.It;

    [Subject(typeof(ZoneClientExtensions))]
    public class When_getting_zones : FixtureContext
    {
        static Mock<IZoneClient> _zoneClientMock;
        static CloudFlareAuth _auth;
        static CloudFlareResponse<IReadOnlyList<Zone>> _expected;
        static CloudFlareResponse<IReadOnlyList<Zone>> _actual;

        Establish context = () =>
        {
            _zoneClientMock = _fixture.Create<Mock<IZoneClient>>();
            _auth = _fixture.Create<CloudFlareAuth>();
            _expected = _fixture.Create<CloudFlareResponse<IReadOnlyList<Zone>>>();
            _zoneClientMock
                .Setup(c => c.GetZonesAsync(CancellationToken.None, default(PagedZoneParameters), _auth))
                .ReturnsAsync(_expected);
        };

        Because of = () => _actual = _zoneClientMock.Object.GetZonesAsync(_auth).Await();

        It should_return_the_zones = () => _actual.ShouldBeTheSameAs(_expected);
    }

    [Subject(typeof(ZoneClientExtensions))]
    public class When_getting_zones_with_parameters : FixtureContext
    {
        static Mock<IZoneClient> _zoneClientMock;
        static PagedZoneParameters _parameters;
        static CloudFlareResponse<IReadOnlyList<Zone>> _expected;
        static CloudFlareResponse<IReadOnlyList<Zone>> _actual;

        Establish context = () =>
        {
            _zoneClientMock = _fixture.Create<Mock<IZoneClient>>();
            _parameters = _fixture.Create<PagedZoneParameters>();
            _expected = _fixture.Create<CloudFlareResponse<IReadOnlyList<Zone>>>();
            _zoneClientMock
                .Setup(c => c.GetZonesAsync(CancellationToken.None, _parameters, default(CloudFlareAuth)))
                .ReturnsAsync(_expected);
        };

        Because of = () => _actual = _zoneClientMock.Object.GetZonesAsync(_parameters).Await();

        It should_return_the_zones = () => _actual.ShouldBeTheSameAs(_expected);
    }

    [Subject(typeof(ZoneClientExtensions))]
    public class When_getting_all_zones : FixtureContext
    {
        static Mock<IZoneClient> _zoneClientMock;
        static CloudFlareAuth _auth;
        static IEnumerable<Zone> _expected;
        static IEnumerable<Zone> _actual;

        Establish context = () =>
        {
            _zoneClientMock = _fixture.Create<Mock<IZoneClient>>();
            _auth = _fixture.Create<CloudFlareAuth>();
            _expected = _fixture.CreateMany<Zone>();
            _zoneClientMock
                .Setup(c => c.GetAllZonesAsync(CancellationToken.None, default(PagedZoneParameters), _auth))
                .ReturnsAsync(_expected);
        };

        Because of = () => _actual = _zoneClientMock.Object.GetAllZonesAsync(_auth).Await().AsTask.Result;

        It should_return_all_the_zones = () => _actual.ShouldBeTheSameAs(_expected);
    }

    [Subject(typeof(ZoneClientExtensions))]
    public class When_getting_all_zones_with_parameters : FixtureContext
    {
        static Mock<IZoneClient> _zoneClientMock;
        static PagedZoneParameters _parameters;
        static IEnumerable<Zone> _expected;
        static IEnumerable<Zone> _actual;

        Establish context = () =>
        {
            _zoneClientMock = _fixture.Create<Mock<IZoneClient>>();
            _parameters = _fixture.Create<PagedZoneParameters>();
            _expected = _fixture.CreateMany<Zone>();
            _zoneClientMock
                .Setup(c => c.GetAllZonesAsync(CancellationToken.None, _parameters, default(CloudFlareAuth)))
                .ReturnsAsync(_expected);
        };

        Because of = () => _actual = _zoneClientMock.Object.GetAllZonesAsync(_parameters).Await().AsTask.Result;

        It should_return_all_the_zones = () => _actual.ShouldBeTheSameAs(_expected);
    }

    [Subject(typeof(ZoneClientExtensions))]
    public class When_getting_a_zone : FixtureContext
    {
        static Mock<IZoneClient> _zoneClientMock;
        static IdentifierTag _zoneId;
        static CloudFlareAuth _auth;
        static Zone _expected;
        static Zone _actual;

        Establish context = () =>
        {
            _zoneClientMock = _fixture.Create<Mock<IZoneClient>>();
            _auth = _fixture.Create<CloudFlareAuth>();
            _expected = _fixture.Create<Zone>();
            _zoneId = _expected.Id;
            _zoneClientMock
                .Setup(c => c.GetZoneAsync(_zoneId, CancellationToken.None, _auth))
                .ReturnsAsync(_expected);
        };

        Because of = () => _actual = _zoneClientMock.Object.GetZoneAsync(_zoneId, _auth).Await();

        It should_return_the_zones = () => _actual.ShouldBeTheSameAs(_expected);
    }
}
