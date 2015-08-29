namespace CloudFlare.NET
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Net.Http;
    using Machine.Specifications;
    using Ploeh.AutoFixture;
    using Ploeh.AutoFixture.Kernel;

    [Subject(typeof(CloudFlareClient))]
    public class When_creating_the_message_handler_pipeline_using_only_delegates : FixtureContext
    {
        static IReadOnlyCollection<DelegatingHandler> _handlers;
        static HttpMessageHandler _result;

        Establish context = () => _handlers = _fixture.Create<DelegatingHandler[]>();

        Because of = () => _result = CloudFlareClient.CreatePipeline(_handlers);

        It should_start_the_chain_with_the_first_handler = () => _result.ShouldBeTheSameAs(_handlers.First());

        It should_create_a_chain_of_delegates = () =>
        {
            HttpMessageHandler current = _result;
            foreach (DelegatingHandler handler in _handlers)
            {
                current.ShouldBeTheSameAs(handler);
                current = handler.InnerHandler;
            }
        };

        It should_end_the_chain_with_a_HttpClientHandler = () =>
        {
            HttpMessageHandler current = _result;
            DelegatingHandler @delegate;
            while ((@delegate = current as DelegatingHandler) != null)
            {
                current = @delegate.InnerHandler;
            }

            current.ShouldBeOfExactType<HttpClientHandler>();
        };
    }

    [Subject(typeof(CloudFlareClient))]
    public class When_creating_the_message_handler_pipeline_with_a_HttpClientHandler_at_the_end : FixtureContext
    {
        static List<HttpMessageHandler> _handlers;
        static HttpClientHandler _last;
        static HttpMessageHandler _result;

        Establish context = () =>
        {
            _last = new HttpClientHandler();
            _handlers = _fixture.Create<DelegatingHandler[]>().ToList<HttpMessageHandler>();
            _handlers.Add(_last);
        };

        Because of = () => _result = CloudFlareClient.CreatePipeline(_handlers);

        It should_start_the_chain_with_the_first_handler = () => _result.ShouldBeTheSameAs(_handlers.First());

        It should_create_a_chain_of_delegates = () =>
        {
            HttpMessageHandler current = _result;
            foreach (DelegatingHandler handler in _handlers.OfType<DelegatingHandler>())
            {
                current.ShouldBeTheSameAs(handler);
                current = handler.InnerHandler;
            }
        };

        It should_end_the_chain_with_the_last_HttpClientHandler = () =>
        {
            HttpMessageHandler current = _result;
            DelegatingHandler @delegate;
            while ((@delegate = current as DelegatingHandler) != null)
            {
                current = @delegate.InnerHandler;
            }

            current.ShouldBeTheSameAs(_last);
        };
    }

    [Subject(typeof(CloudFlareClient))]
    public class When_creating_a_pipeline_with_a_HttpClientHandler_at_the_front : FixtureContext
    {
        static List<HttpMessageHandler> _handlers;
        static Exception _exception;

        Establish context = () =>
        {
            _handlers = _fixture.Create<DelegatingHandler[]>().ToList<HttpMessageHandler>();
            _handlers.Insert(0, new HttpClientHandler());
        };

        Because of = () => _exception = Catch.Exception(() => CloudFlareClient.CreatePipeline(_handlers));

        It should_throw_an_ArgumentException = () => _exception.ShouldBeOfExactType<ArgumentException>();
    }

    [Subject(typeof (CloudFlareClient))]
    public class When_initialising_with_a_custom_HttpClient : FixtureContext
    {
        static HttpClient _httpClient;
        static CloudFlareClient _sut;

        Establish context = () =>
        {
            _httpClient = _fixture.Freeze<HttpClient>();
            _fixture.Customize(new ConstructorCustomization(typeof(CloudFlareClient), new GreedyConstructorQuery()));
        };

        Because of = () => _sut = _fixture.Create<CloudFlareClient>();

        It should_use_the_HttpClient = () => _sut.Client.ShouldBeTheSameAs(_httpClient);
    }
}
