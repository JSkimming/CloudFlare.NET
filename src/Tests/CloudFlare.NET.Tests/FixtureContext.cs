namespace CloudFlare.NET
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Machine.Specifications;
    using Ploeh.AutoFixture;

    public abstract class FixtureContext
    {
        protected static IFixture _fixture;

        Establish context = () =>
        {
            _fixture = new Fixture().Customize(new CloudFlareCustomization());
        };
    }
}
