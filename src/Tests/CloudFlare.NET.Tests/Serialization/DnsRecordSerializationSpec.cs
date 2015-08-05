namespace CloudFlare.NET.Serialization
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Machine.Specifications;
    using Newtonsoft.Json.Linq;

    [Subject(typeof(DnsRecord))]
    public class When_deserializing_dns_record
    {
        static JObject _json;
        static DnsRecord _sut;

        Because of = () =>
        {
            _json = SampleJson.DnsRecord;
            _sut = _json.ToObject<DnsRecord>();
        };

        It should_deserialize_id = () => _sut.Id.ToString().ShouldEqual(_json["id"].Value<string>());

        It should_deserialize_type = () => _sut.Type.ToString().ShouldEqual(_json["type"].Value<string>());

        It should_deserialize_name = () => _sut.Name.ShouldEqual(_json["name"].Value<string>());

        It should_deserialize_content = () => _sut.Content.ShouldEqual(_json["content"].Value<string>());

        It should_deserialize_proxiable = () => _sut.Proxiable.ShouldEqual(_json["proxiable"].Value<bool>());

        It should_deserialize_proxied = () => _sut.Proxied.ShouldEqual(_json["proxied"].Value<bool>());

        It should_deserialize_ttl = () => _sut.Ttl.ShouldEqual(_json["ttl"].Value<int>());

        It should_deserialize_locked = () => _sut.Locked.ShouldEqual(_json["locked"].Value<bool>());

        It should_deserialize_zone_id = () => _sut.ZoneId.ToString().ShouldEqual(_json["zone_id"].Value<string>());

        It should_deserialize_zone_name = () => _sut.ZoneName.ShouldEqual(_json["zone_name"].Value<string>());

        It should_deserialize_created_on = () => _sut.CreatedOn.ShouldEqual(_json["created_on"].Value<DateTime>());

        It should_deserialize_modified_on = () => _sut.ModifiedOn.ShouldEqual(_json["modified_on"].Value<DateTime>());

        It should_deserialize_priority = () => _sut.Priority.ShouldEqual(_json["priority"].Value<int>());
    }

    [Subject(typeof(DnsRecord))]
    public class When_deserializing_dns_record_minimal
    {
        static JObject _json;
        static DnsRecord _sut;

        Because of = () =>
        {
            _json = SampleJson.DnsRecordMinimal;
            _sut = _json.ToObject<DnsRecord>();
        };

        It should_deserialize_id = () => _sut.Id.ToString().ShouldEqual(_json["id"].Value<string>());

        It should_deserialize_name = () => _sut.Name.ShouldEqual(_json["name"].Value<string>());

        It should_deserialize_zone_id = () => _sut.ZoneId.ToString().ShouldEqual(_json["zone_id"].Value<string>());
    }
}
