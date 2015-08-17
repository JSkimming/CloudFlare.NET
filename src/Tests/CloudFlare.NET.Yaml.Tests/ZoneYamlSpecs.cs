namespace CloudFlare.NET
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Ploeh.AutoFixture;
    using Machine.Specifications;

    [Subject("Zone YAML")]
    public class When_serializing_a_Zone_to_YAML : FixtureContext
    {
        static Zone _zone;
        static string _yaml;

        Establish context = () => _zone = _fixture.Create<Zone>();

        Because of = () => _yaml =_zone.ToYaml();


        It should_serialize_the_name = () => _yaml.ShouldNotBeEmpty();
    }

    [Subject("DNS Records YAML")]
    public class When_serializing_a_DNS_records_to_YAML : FixtureContext
    {
        static DnsRecord[] _dnsRecords;
        static string _yaml;

        Establish context = () => _dnsRecords = _fixture.Create<DnsRecord[]>();

        Because of = () => _yaml = _dnsRecords.ToYaml("dns_records");

        It should_serialize_the_name = () => _yaml.ShouldNotBeEmpty();
    }

}
