namespace CloudFlare.NET
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Ploeh.AutoFixture;
    using Machine.Specifications;
    using SharpYaml.Serialization;

    [Subject("Zone YAML")]
    public class When_serializing_a_Zone_to_YAML : FixtureContext
    {
        static Zone _zone;
        static Dictionary<object, object> _yaml;

        Establish context = () => _zone = _fixture.Create<Zone>();

        Because of = () =>
        {
            string yaml = _zone.ToYaml();
            var serializer = new Serializer();
            _yaml = (Dictionary<object, object>)serializer.Deserialize(yaml);
        };

        It should_serialize_the_name = () => _yaml["name"].ToString().ShouldEqual(_zone.Name);

        It should_deserialize_1_property = () => _yaml.Count.ShouldEqual(1);
    }

    [Subject("DNS Records YAML")]
    public class When_serializing_a_DNS_records_to_YAML : FixtureContext
    {
        static DnsRecord[] _dnsRecords;
        static string _yaml;

        Establish context = () => _dnsRecords = _fixture.Create<DnsRecord[]>();

        Because of = () =>
        {
            _yaml = _dnsRecords.ToYaml("dns_records");
            var serializer = new Serializer();
            object deserialize = serializer.Deserialize(_yaml);
            var type = deserialize.GetType();
        };

        It should_serialize_the_name = () => _yaml.ShouldNotBeEmpty();
    }

}
