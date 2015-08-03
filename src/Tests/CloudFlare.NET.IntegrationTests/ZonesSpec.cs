namespace CloudFlare.NET
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Machine.Specifications;

    [Subject("Zones")]
    public class ZonesSpec
    {
        static ICloudFlareClient _client;
        static CloudFlareAuth _auth;
        static IReadOnlyList<Zone> _zones;

        Establish context = () =>
        {
            _client = new CloudFlareClient();
            _auth = new CloudFlareAuth(Helper.AuthEmail, Helper.AuthKey);
        };

        Because of = () => _zones = _client.GetZonesAsync(_auth).Await().AsTask.Result;

        It should_return_the_zones = () => _zones.ShouldNotBeEmpty();
    }
}
