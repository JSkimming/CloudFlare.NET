namespace CloudFlare.NET.Serialization.PagedZoneParametersSpec
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Machine.Specifications;
    using Newtonsoft.Json;
    using Newtonsoft.Json.Linq;
    using Ploeh.AutoFixture;

    [Subject(typeof(PagedZoneParameters))]
    public class When_serializing : FixtureContext
    {
        protected static PagedZoneParameters _sut;
        protected static JObject _json;

        Establish context = () => _sut = _fixture.Create<PagedZoneParameters>();

        Because of = () => _json = JObject.FromObject(_sut);

        Behaves_like<PagedParametersSerializeBehavior<PagedZoneOrderFieldTypes>> paged_parameters_serialize_behavior;

        It should_serialize_name = () => _sut.Name.ShouldEqual(_json["name"].Value<string>());

        It should_serialize_status = () => _sut.Status.ToString().ShouldEqual(_json["status"].Value<string>());
    }

    [Subject(typeof(PagedZoneParameters))]
    public class When_serializing_and_deserializing : FixtureContext
    {
        static PagedZoneParameters _expected;
        static PagedZoneParameters _actual;

        Establish context = () => _expected = _fixture.Create<PagedZoneParameters>();

        Because of = () =>
        {
            var serializeObject = JsonConvert.SerializeObject(_expected);
            _actual = JObject.FromObject(_expected).ToObject<PagedZoneParameters>();
        };

        It should_retain_all_properties = () => _actual.AsLikeness().ShouldEqual(_expected);
    }

    [Subject(typeof(PagedZoneParameters))]
    public class When_creating_with_a_subset_of_properties : FixtureContext
    {
        static PagedZoneParameters _expected;
        static object _source;
        static PagedZoneParameters _actual;

        Establish context = () =>
        {
            _expected = _fixture.Create<PagedZoneParameters>();
            _source = new
            {
                _expected.Name,
                _expected.Match,
                _expected.PerPage,
            };
        };

        Because of = () => _actual = PagedZoneParameters.Create(_source);

        It should_retain_all_properties = () =>
            _actual.AsLikeness()
                .OmitAutoComparison()
                .WithDefaultEquality(e => e.Name)
                .WithDefaultEquality(e => e.Match)
                .WithDefaultEquality(e => e.PerPage)
                .ShouldEqual(_expected);
    }
}
