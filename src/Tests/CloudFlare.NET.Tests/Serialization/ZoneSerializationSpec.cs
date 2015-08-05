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
        static JObject _json;
        static Zone _sut;

        Because of = () =>
        {
            _json = SampleJson.Zone;
            _sut = _json.ToObject<Zone>();
        };

        It should_deserialize_id = () => _sut.Id.ToString().ShouldEqual(_json["id"].Value<string>());

        It should_deserialize_name = () => _sut.Name.ShouldEqual(_json["name"].Value<string>());

        It should_deserialize_development_mode =
            () => _sut.DevelopmentMode.ShouldEqual(_json["development_mode"].Value<int>());

        It should_deserialize_original_name_servers =
            () => _sut.OriginalNameServers
                .ShouldContainOnly(_json["original_name_servers"].ToObject<List<string>>());

        It should_deserialize_original_registrar =
            () => _sut.OriginalRegistrar.ShouldEqual(_json["original_registrar"].Value<string>());

        It should_deserialize_original_dnshost =
            () => _sut.OriginalDnshost.ShouldEqual(_json["original_dnshost"].Value<string>());

        It should_deserialize_created_on =
            () => _sut.CreatedOn.ShouldEqual(_json["created_on"].Value<DateTime>());

        It should_deserialize_modified_on =
            () => _sut.ModifiedOn.ShouldEqual(_json["modified_on"].Value<DateTime>());

        It should_deserialize_name_servers =
            () => _sut.NameServers.ShouldContainOnly(_json["name_servers"].ToObject<List<string>>());
    }

    [Subject(typeof(Zone))]
    public class When_deserializing_zone_minimal
    {
        static JObject _json;
        static Zone _sut;

        Because of = () =>
        {
            _json = SampleJson.ZoneMinimal;
            _sut = _json.ToObject<Zone>();
        };

        It should_deserialize_id = () => _sut.Id.ToString().ShouldEqual(_json["id"].Value<string>());

        It should_deserialize_name = () => _sut.Name.ShouldEqual(_json["name"].Value<string>());
    }
}
