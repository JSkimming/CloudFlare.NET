namespace CloudFlare.NET.Serialization.ZoneGetParametersSpec
{
    using System;
    using System.Collections.Generic;
    using System.Collections.Specialized;
    using System.Linq;
    using System.Net.Http;
    using Machine.Specifications;
    using Newtonsoft.Json.Linq;
    using Ploeh.AutoFixture;

    [Subject(typeof(ZoneGetParameters))]
    public class When_serializing : FixtureContext
    {
        protected static ZoneGetParameters _sut;
        protected static JObject _json;

        Establish context = () => _sut = _fixture.Create<ZoneGetParameters>();

        Because of = () => _json = JObject.FromObject(_sut);

        Behaves_like<PagedParametersSerializeBehavior<ZoneOrderTypes>> paged_parameters_serialize_behavior;

        It should_serialize_name = () => _sut.Name.ShouldEqual(_json["name"].Value<string>());

        It should_serialize_status = () => _sut.Status.ToString().ShouldEqual(_json["status"].Value<string>());
    }

    [Subject(typeof(ZoneGetParameters))]
    public class When_serializing_and_deserializing : FixtureContext
    {
        static ZoneGetParameters _expected;
        static ZoneGetParameters _actual;

        Establish context = () => _expected = _fixture.Create<ZoneGetParameters>();

        Because of = () => _actual = JObject.FromObject(_expected).ToObject<ZoneGetParameters>();

        It should_retain_all_properties = () => _actual.AsLikeness().ShouldEqual(_expected);
    }

    [Subject(typeof(ZoneGetParameters))]
    public class When_creating_with_a_subset_of_properties : FixtureContext
    {
        static ZoneGetParameters _expected;
        static object _source;
        static ZoneGetParameters _actual;

        Establish context = () =>
        {
            _expected = _fixture.Create<ZoneGetParameters>();
            _source = new
            {
                _expected.Name,
                _expected.Match,
                _expected.PerPage,
            };
        };

        Because of = () => _actual = ZoneGetParameters.Create(_source);

        It should_retain_all_properties = () =>
            _actual.AsLikeness()
                .OmitAutoComparison()
                .WithDefaultEquality(e => e.Name)
                .WithDefaultEquality(e => e.Match)
                .WithDefaultEquality(e => e.PerPage)
                .ShouldEqual(_expected);
    }

    [Subject(typeof (ZoneGetParameters))]
    public class When_converting_to_key_value_pair_with_all_default_values
    {
        static ZoneGetParameters _parameters;
        static IEnumerable<KeyValuePair<string, string>> _result;

        Establish context = () => _parameters = new ZoneGetParameters();

        Because of = () => _result = _parameters.ToKvp();

        It should_have_no_values = () => _result.ShouldBeEmpty();
    }

    [Subject(typeof(ZoneGetParameters))]
    public class When_converting_to_key_value_pair_with_no_default_values : FixtureContext
    {
        protected static ZoneGetParameters _parameters;
        protected static Dictionary<string, string> _result;

        Establish context = () =>
        {
            // Auto fixture chooses the default value for enumerations.
            _fixture.Inject(ZoneOrderTypes.email);
            _fixture.Inject(PagedParametersOrderType.desc);
            _fixture.Inject(PagedParametersMatchType.any);

            _parameters = _fixture.Create<ZoneGetParameters>();
        };

        Because of = () => _result = _parameters.ToKvp().ToDictionary(kvp => kvp.Key, kvp => kvp.Value);

        Behaves_like<PagedParametersKvpBehavior<ZoneOrderTypes>> paged_parameters_kvp_behavior;

        It should_have_name_value = () => _result["name"].ShouldEqual(_parameters.Name);

        It should_have_status_value = () => _result["status"].ShouldEqual(_parameters.Status.ToString());
    }

    [Subject(typeof(ZoneGetParameters))]
    public class When_converting_to_query_string : FixtureContext
    {
        protected static ZoneGetParameters _parameters;
        protected static Dictionary<string, string> _result;

        Establish context = () =>
        {
            // Auto fixture chooses the default value for enumerations.
            _fixture.Inject(ZoneOrderTypes.email);
            _fixture.Inject(PagedParametersOrderType.desc);
            _fixture.Inject(PagedParametersMatchType.any);

            _parameters = _fixture.Create<ZoneGetParameters>();
        };

        Because of = () =>
        {
            string query = _parameters.ToQuery();
            // Convert
            var builder = new UriBuilder("http://localhost/path") { Query = query };

            // Get the values back as a dictionary to validate their values.
            NameValueCollection kvp = builder.Uri.ParseQueryString();
            _result = kvp.Cast<string>().ToDictionary(k => k, k => kvp[k]);
        };

        Behaves_like<PagedParametersKvpBehavior<ZoneOrderTypes>> paged_parameters_kvp_behavior;

        It should_have_name_value = () => _result["name"].ShouldEqual(_parameters.Name);

        It should_have_status_value = () => _result["status"].ShouldEqual(_parameters.Status.ToString());
    }
}
