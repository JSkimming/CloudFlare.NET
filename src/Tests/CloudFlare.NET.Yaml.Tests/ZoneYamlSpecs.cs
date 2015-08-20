namespace CloudFlare.NET
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Ploeh.AutoFixture;
    using Machine.Specifications;
    using SharpYaml.Serialization;

    [Subject("Zone data YAML")]
    public class When_serializing_a_Zone_data_to_YAML : FixtureContext
    {
        static ZoneData _zoneData;
        static Dictionary<object, object> _yaml;

        Establish context = () => _zoneData = _fixture.Create<ZoneData>();

        Because of = () =>
        {
            string yaml = _zoneData.ToYaml();
            var serializer = new Serializer();
            _yaml = (Dictionary<object, object>)serializer.Deserialize(yaml);
        };

        It should_serialize_the_name = () => _yaml["name"].ToString().ShouldEqual(_zoneData.Zone.Name);

        It should_deserialize_2_properties = () => _yaml.Count.ShouldEqual(2);
    }

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
        static List<Dictionary<object, object>> _yaml;

        Establish context = () => _dnsRecords = _fixture.Create<DnsRecord[]>();

        Because of = () =>
        {
            string yaml = _dnsRecords.ToYaml();
            var serializer = new Serializer();
            _yaml = ((IEnumerable<object>)serializer.Deserialize(yaml)).Cast<Dictionary<object, object>>().ToList();
        };

        It should_serialize_name = () => _yaml[1]["name"].ToString().ShouldEqual(_dnsRecords[1].Name);

        It should_serialize_type = () => _yaml[1]["type"].ToString().ShouldEqual(_dnsRecords[1].Type.ToString());

        It should_serialize_content = () => _yaml[1]["content"].ToString().ShouldEqual(_dnsRecords[1].Content);

        It should_serialize_proxied = () => ((bool)_yaml[1]["proxied"]).ShouldEqual(_dnsRecords[1].Proxied);

        It should_serialize_ttl = () => ((int)_yaml[1]["ttl"]).ShouldEqual(_dnsRecords[1].Ttl);

        It should_serialize_priority = () => ((int)_yaml[1]["priority"]).ShouldEqual(_dnsRecords[1].Priority);

        It should_serialize_6_properties = () => _yaml.Count().ShouldEqual(_dnsRecords.Length);
    }
}
