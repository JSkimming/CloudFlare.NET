namespace CloudFlare.NET
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading;
    using Machine.Specifications;

    [Subject("Zones")]
    public class DnsRecordsSpec
    {
        static IDnsRecordClient _client;
        static CloudFlareAuth _auth;
        static Zone _zone;
        static IReadOnlyList<DnsRecord> _dnsRecords;

        Establish context = () =>
        {
            var client = new CloudFlareClient();
            _auth = new CloudFlareAuth(Helper.AuthEmail, Helper.AuthKey);
            _zone = client.GetZonesAsync(_auth).Await().AsTask.Result.First();
            _client = client;
        };

        Because of = () => _dnsRecords = _client.GetDnsRecordsAsync(_zone.Id, _auth).Await().AsTask.Result;

        It should_return_the_zones = () => _dnsRecords.ShouldNotBeEmpty();
    }
}
