namespace CloudFlare.NET
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Net;
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

    public abstract class GetAllResultsContext<TResult> : RequestContext
        where TResult : class
    {
        protected static CloudFlareResponse<IReadOnlyList<TResult>> _firstRequest;
        protected static CloudFlareResponse<IReadOnlyList<TResult>> _secondRequest;
        protected static CloudFlareResponse<IReadOnlyList<TResult>> _lastRequest;
        protected static IEnumerable<TResult> _expected;
        protected static IEnumerable<TResult> _actual;

        Establish context = () =>
        {
            _firstRequest = new CloudFlareResponse<IReadOnlyList<TResult>>(
                true,
                _fixture.CreateMany<TResult>(100).ToList(),
                resultInfo: new CloudFlareResultInfo(page: 1, totalPages: 3, perPage: 100, count: 100, totalCount: 250));
            _secondRequest = new CloudFlareResponse<IReadOnlyList<TResult>>(
                true,
                _fixture.CreateMany<TResult>(100).ToList(),
                resultInfo: new CloudFlareResultInfo(page: 2, totalPages: 3, perPage: 100, count: 100, totalCount: 250));
            _lastRequest = new CloudFlareResponse<IReadOnlyList<TResult>>(
                true,
                _fixture.CreateMany<TResult>(50).ToList(),
                resultInfo: new CloudFlareResultInfo(page: 3, totalPages: 3, perPage: 100, count: 50, totalCount: 250));

            _handler.AddResponseContent(_firstRequest);
            _handler.AddResponseContent(_secondRequest);
            _handler.AddResponseContent(_lastRequest);
            _expected = _firstRequest.Result.Concat(_secondRequest.Result).Concat(_lastRequest.Result);
        };
    }

    public abstract class ErredRequestContext : RequestContext
    {
        protected static CloudFlareResponseBase _erredResponse;
        protected static Exception _exception;

        Establish context = () =>
        {
            _erredResponse = _fixture.Create<CloudFlareResponseBase>();
            _handler.SetResponseContent(_erredResponse, (HttpStatusCode)new Random().Next(400, 600));
        };
    }
}
