namespace CloudFlare.NET.Serialization.PagedDnsRecordParametersSpec
{
    using System;
    using System.Collections.Generic;
    using System.Collections.Specialized;
    using System.Linq;
    using System.Net.Http;
    using Machine.Specifications;
    using Newtonsoft.Json;
    using Newtonsoft.Json.Linq;
    using Ploeh.AutoFixture;

    [Subject(typeof(PagedDnsRecordParameters))]
    public class When_serializing : FixtureContext
    {
        protected static PagedDnsRecordParameters _sut;
        protected static JObject _json;

        Establish context = () => _sut = _fixture.Create<PagedDnsRecordParameters>();

        Because of = () => _json = JObject.FromObject(_sut);

        Behaves_like<PagedParametersSerializeBehavior<PagedDnsRecordOrderFieldTypes>> paged_parameters_serialize_behavior;

        It should_serialize_type = () => _sut.Type.ToString().ShouldEqual(_json["type"].Value<string>());

        It should_serialize_name = () => _sut.Name.ShouldEqual(_json["name"].Value<string>());

        It should_serialize_content = () => _sut.Content.ShouldEqual(_json["content"].Value<string>());
    }

    [Subject(typeof(PagedDnsRecordParameters))]
    public class When_serializing_and_deserializing : FixtureContext
    {
        static PagedDnsRecordParameters _expected;
        static PagedDnsRecordParameters _actual;

        Establish context = () => _expected = _fixture.Create<PagedDnsRecordParameters>();

        Because of = () =>
        {
            var serializeObject = JsonConvert.SerializeObject(_expected);
            _actual = JObject.FromObject(_expected).ToObject<PagedDnsRecordParameters>();
        };

        It should_retain_all_properties = () => _actual.AsLikeness().ShouldEqual(_expected);
    }

    [Subject(typeof(PagedDnsRecordParameters))]
    public class When_creating_with_a_subset_of_properties : FixtureContext
    {
        static PagedDnsRecordParameters _expected;
        static object _source;
        static PagedDnsRecordParameters _actual;

        Establish context = () =>
        {
            _expected = _fixture.Create<PagedDnsRecordParameters>();
            _source = new
            {
                _expected.Name,
                _expected.Match,
                _expected.PerPage,
            };
        };

        Because of = () => _actual = PagedDnsRecordParameters.Create(_source);

        It should_retain_all_properties = () =>
            _actual.AsLikeness()
                .OmitAutoComparison()
                .WithDefaultEquality(e => e.Name)
                .WithDefaultEquality(e => e.Match)
                .WithDefaultEquality(e => e.PerPage)
                .ShouldEqual(_expected);
    }

    [Subject(typeof(PagedDnsRecordParameters))]
    public class When_converting_to_key_value_pair_with_all_default_values
    {
        static PagedDnsRecordParameters _parameters;
        static IEnumerable<KeyValuePair<string, string>> _result;

        Establish context = () => _parameters = new PagedDnsRecordParameters();

        Because of = () => _result = _parameters.ToKvp();

        It should_have_no_values = () => _result.ShouldBeEmpty();
    }

    [Subject(typeof(PagedDnsRecordParameters))]
    public class When_converting_to_key_value_pair_with_no_default_values : FixtureContext
    {
        protected static PagedDnsRecordParameters _parameters;
        protected static Dictionary<string, string> _result;

        Establish context = () =>
        {
            // Auto fixture chooses the default value for enumerations.
            _fixture.Inject(PagedDnsRecordOrderFieldTypes.proxied);
            _fixture.Inject(PagedParametersOrderType.desc);
            _fixture.Inject(PagedParametersMatchType.any);

            _parameters = _fixture.Create<PagedDnsRecordParameters>();
        };

        Because of = () => _result = _parameters.ToKvp().ToDictionary(kvp => kvp.Key, kvp => kvp.Value);

        Behaves_like<PagedParametersKvpBehavior<PagedDnsRecordOrderFieldTypes>> paged_parameters_kvp_behavior;

        It should_have_type_value = () => _result["type"].ShouldEqual(_parameters.Type.ToString());

        It should_have_name_value = () => _result["name"].ShouldEqual(_parameters.Name);

        It should_have_content_value = () => _result["content"].ShouldEqual(_parameters.Content);
    }

    [Subject(typeof(PagedDnsRecordParameters))]
    public class When_converting_to_query_string : FixtureContext
    {
        protected static PagedDnsRecordParameters _parameters;
        protected static Dictionary<string, string> _result;

        Establish context = () =>
        {
            // Auto fixture chooses the default value for enumerations.
            _fixture.Inject(PagedDnsRecordOrderFieldTypes.proxied);
            _fixture.Inject(PagedParametersOrderType.desc);
            _fixture.Inject(PagedParametersMatchType.any);

            _parameters = _fixture.Create<PagedDnsRecordParameters>();
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

        Behaves_like<PagedParametersKvpBehavior<PagedDnsRecordOrderFieldTypes>> paged_parameters_kvp_behavior;

        It should_have_type_value = () => _result["type"].ShouldEqual(_parameters.Type.ToString());

        It should_have_name_value = () => _result["name"].ShouldEqual(_parameters.Name);

        It should_have_content_value = () => _result["content"].ShouldEqual(_parameters.Content);
    }
}
