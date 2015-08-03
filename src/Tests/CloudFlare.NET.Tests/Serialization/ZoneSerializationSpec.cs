namespace CloudFlare.NET.Serialization
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Machine.Specifications;
    using Newtonsoft.Json.Linq;

    [Subject(typeof(Zone))]
    public class When_deserializing_zone
    {
        static JObject _zoneJson;
        static Zone _zone;

        Because of = () =>
        {
            _zoneJson = SampleJson.Zone;
            _zone = _zoneJson.ToObject<Zone>();
        };

        It should_deserialize_id = () => _zone.Id.ToString().ShouldEqual(_zoneJson["id"].Value<string>());

        It should_deserialize_name = () => _zone.Name.ShouldEqual(_zoneJson["name"].Value<string>());

        It should_deserialize_development_mode =
            () => _zone.DevelopmentMode.ShouldEqual(_zoneJson["development_mode"].Value<int>());

        It should_deserialize_original_name_servers =
            () => _zone.OriginalNameServers
                .ShouldContainOnly(_zoneJson["original_name_servers"].ToObject<List<string>>());

        It should_deserialize_original_registrar =
            () => _zone.OriginalRegistrar.ShouldEqual(_zoneJson["original_registrar"].Value<string>());

        It should_deserialize_original_dnshost =
            () => _zone.OriginalDnshost.ShouldEqual(_zoneJson["original_dnshost"].Value<string>());

        It should_deserialize_created_on =
            () => _zone.CreatedOn.ShouldEqual(_zoneJson["created_on"].Value<DateTime>());

        It should_deserialize_modified_on =
            () => _zone.ModifiedOn.ShouldEqual(_zoneJson["modified_on"].Value<DateTime>());

        It should_deserialize_name_servers =
            () => _zone.NameServers.ShouldContainOnly(_zoneJson["name_servers"].ToObject<List<string>>());
    }

    [Subject(typeof(Zone))]
    public class When_deserializing_zone_minimal
    {
        static JObject _zoneJson;
        static Zone _zone;

        Because of = () =>
        {
            _zoneJson = SampleJson.ZoneMinimal;
            _zone = _zoneJson.ToObject<Zone>();
        };

        It should_deserialize_id = () => _zone.Id.ToString().ShouldEqual(_zoneJson["id"].Value<string>());

        It should_deserialize_name = () => _zone.Name.ShouldEqual(_zoneJson["name"].Value<string>());
    }
}
