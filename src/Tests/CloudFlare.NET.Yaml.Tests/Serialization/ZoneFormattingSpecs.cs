namespace CloudFlare.NET.Serialization.ZoneSpec
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Machine.Specifications;
    using Newtonsoft.Json.Linq;
    using Ploeh.AutoFixture;

    [Subject(typeof(Zone))]
    public class When_formatting : FixtureContext
    {
        protected static JObject _json;
        static YamlJsonFormatter _formatter;
        static Zone _source;

        Establish context = () =>
        {
            _formatter = new YamlJsonFormatter();
            _source = _fixture.Create<Zone>();
        };

        Because of = () => _json = _formatter.Process(_source);

        Behaves_like<IdentifierFormattingBehavior> identifier_formatting_behavior;

        Behaves_like<ModifiedFormattingBehavior> modified_formatting_behavior;

        It should_serialize_name = () => _json["name"].Value<string>().ShouldEqual(_source.Name);

        It should_remove_development_mode = () => _json["development_mode"].ShouldBeNull();

        It should_remove_original_name_servers = () => _json["original_name_servers"].ShouldBeNull();

        It should_remove_original_registrar = () => _json["original_registrar"].ShouldBeNull();

        It should_remove_original_dnshost = () => _json["original_dnshost"].ShouldBeNull();

        It should_remove_name_servers = () => _json["name_servers"].ShouldBeNull();

        It should_serialize_1_property = () => _json.Count.ShouldEqual(1);
    }
}
