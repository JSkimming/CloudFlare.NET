namespace CloudFlare.NET
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Net.Http;
    using CloudFlare.NET.HttpHandlers;
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

    public abstract class RequestContext : FixtureContext
    {
        protected static TestHttpHandler _handler;
        protected static CloudFlareClient _sut;
        protected static CloudFlareAuth _auth;

        Establish context = () =>
        {
            _handler = new TestHttpHandler();
            _sut = new CloudFlareClient(new HttpClient(_handler), _fixture.Create<CloudFlareAuth>());
            _auth = _fixture.Create<CloudFlareAuth>();
        };
    }
}
