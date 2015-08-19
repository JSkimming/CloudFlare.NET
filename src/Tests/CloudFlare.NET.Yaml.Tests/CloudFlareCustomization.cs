namespace CloudFlare.NET
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Newtonsoft.Json.Linq;
    using Ploeh.AutoFixture;
    using Ploeh.AutoFixture.AutoMoq;

    internal class CloudFlareCustomization : CompositeCustomization
    {
        public CloudFlareCustomization()
            :base (new AutoMoqCustomization(), new FixtureCustomization())
        {
        }
    }

    internal class FixtureCustomization : ICustomization
    {
        void ICustomization.Customize(IFixture fixture)
        {
            fixture.Register(() => new IdentifierTag(Guid.NewGuid().ToString("N")));
            fixture.Register<IReadOnlyList<string>>(fixture.Create<string[]>);
            fixture.Register<IReadOnlyList<DnsRecord>>(fixture.Create<DnsRecord[]>);
            fixture.Register<IReadOnlyList<CloudFlareError>>(fixture.Create<CloudFlareError[]>);
            fixture.Register(() => JObject.FromObject(fixture.Create<CloudFlareResponseBase>()));
        }
    }
}
