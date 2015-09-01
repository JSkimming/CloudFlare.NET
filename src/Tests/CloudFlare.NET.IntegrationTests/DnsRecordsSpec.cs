namespace CloudFlare.NET
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Machine.Specifications;

    [Subject("Zones")]
    public class DnsRecordsSpec
    {
        static IDnsRecordClient _client;
        static CloudFlareAuth _auth;
        static Zone _zone;
        static CloudFlareResponse<IReadOnlyList<DnsRecord>> _response;

        Establish context = () =>
        {
            var client = new CloudFlareClient();
            _auth = new CloudFlareAuth(Helper.AuthEmail, Helper.AuthKey);
            CloudFlareResponse<IReadOnlyList<Zone>> response = client.GetZonesAsync(_auth).Await();
            _zone = response.Result.First();
            _client = client;
        };

        Because of = () => _response = _client.GetDnsRecordsAsync(_zone.Id, _auth).Await();

        It should_return_the_zones = () => _response.Result.ShouldNotBeEmpty();
    }
}
