namespace CloudFlare.NET
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Machine.Specifications;

    [Subject("Zones")]
    public class ZonesSpec
    {
        static IZoneClient _client;
        static CloudFlareAuth _auth;
        static CloudFlareResponse<IReadOnlyList<Zone>> _response;

        Establish context = () =>
        {
            _client = new CloudFlareClient();
            _auth = new CloudFlareAuth(Helper.AuthEmail, Helper.AuthKey);
        };

        Because of = () => _response = _client.GetZonesAsync(_auth).Await();

        It should_return_the_zones = () => _response.Result.ShouldNotBeEmpty();
    }
}
