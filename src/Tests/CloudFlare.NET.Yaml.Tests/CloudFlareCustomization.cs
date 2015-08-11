namespace CloudFlare.NET
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
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
        }
    }
}
