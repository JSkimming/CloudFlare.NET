namespace CloudFlare.NET
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Machine.Specifications;

    [Subject("Zone Settings")]
    public class ZonesSettingsSpec
    {
        static IZoneSettingsClient _client;
        static CloudFlareAuth _auth;
        static Zone _zone;
        static IReadOnlyList<ZoneSettingBase> _response;

        Establish context = () =>
        {
            var client = new CloudFlareClient();
            _auth = new CloudFlareAuth(Helper.AuthEmail, Helper.AuthKey);
            CloudFlareResponse<IReadOnlyList<Zone>> response = client.GetZonesAsync(_auth).Await();
            _zone = response.Result.First();
            _client = client;
        };

        Because of = () => _response = _client.GetAllZoneSettingsAsync(_zone.Id, _auth).Await().AsTask.Result.ToList();

        It should_return_the_zone_settings = () => _response.ShouldNotBeEmpty();
    }
}
