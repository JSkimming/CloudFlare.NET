namespace CloudFlare.NET.ZoneSpec
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Net.Http;
    using Machine.Specifications;
    using Ploeh.AutoFixture;

    [Subject(typeof(CloudFlareClient))]
    public class When_getting_all_zones : RequestContext
    {
        static IReadOnlyList<Zone> _expected;
        static IReadOnlyList<Zone> _actual;

        Establish context = () =>
        {
            var response = _fixture.Create<CloudFlareResponse<IReadOnlyList<Zone>>>();
            _expected = response.Result;
            _handler.SetResponseContent(response);
        };

        Because of = () => _actual = _sut.GetZonesAsync(_auth).Await().AsTask.Result;

        Behaves_like<AuthenticatedRequestBehaviour> authenticated_request_behaviour;

        It should_make_a_GET_request = () => _handler.Request.Method.ShouldEqual(HttpMethod.Get);

        It should_request_the_zones_endpoint = () =>
            _handler.Request.RequestUri.ShouldEqual(new Uri(CloudFlareConstants.BaseUri, "zones"));

        It should_return_the_expected_zones = () =>
            _actual.Select(z => z.AsLikeness().CreateProxy()).SequenceEqual(_expected).ShouldBeTrue();
    }
}
