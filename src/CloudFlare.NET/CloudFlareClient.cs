namespace CloudFlare.NET
{
    using System;
    using System.Collections.Generic;
    using System.Diagnostics;
    using System.Linq;
    using System.Net;
    using System.Net.Http;
    using System.Net.Http.Headers;
    using System.Threading;
    using System.Threading.Tasks;
    using Newtonsoft.Json.Linq;

    /// <inheritdoc/>
    [DebuggerDisplay("{DebuggerDisplay,nq}")]
    public partial class CloudFlareClient : ICloudFlareClient
    {
        private static readonly Lazy<HttpClient> LazyClient = new Lazy<HttpClient>(
            () => CreateDefaultHttpClient(),
            LazyThreadSafetyMode.PublicationOnly);

        private readonly HttpClient _client;

        private readonly CloudFlareAuth _auth;

        /// <summary>
        /// Initializes a new instance of the <see cref="CloudFlareClient"/> class.
        /// </summary>
        /// <param name="auth">
        /// <para>The authentication details for accessing the CloudFlare API.</para>
        /// <para>If authentication details are not provided via the constructor, they must be provided to every method
        /// call.</para>
        /// </param>
        public CloudFlareClient(CloudFlareAuth auth = null)
            : this(LazyClient.Value, auth)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="CloudFlareClient"/> class.
        /// </summary>
        /// <param name="client">A custom <see cref="HttpClient"/> to be used instead of the internal client.</param>
        /// <param name="auth">
        /// <para>The authentication details for accessing the CloudFlare API.</para>
        /// <para>If authentication details are not provided via the constructor, they must be provided to every method
        /// call.</para>
        /// </param>
        public CloudFlareClient(HttpClient client, CloudFlareAuth auth = null)
        {
            if (client == null)
                throw new ArgumentNullException(nameof(client));

            _client = client;
            _auth = auth;
        }

        /// <summary>
        /// Gets the <see cref="CloudFlareAuth"/> for this client.
        /// </summary>
        public CloudFlareAuth Auth => _auth;

        /// <summary>
        /// Gets the underlying HttpClient used to make requests.
        /// </summary>
        public HttpClient Client => _client;

        private string DebuggerDisplay => $"{GetType().Name}: {_auth?.Email ?? string.Empty}";

        /// <summary>
        /// Creates the default <see cref="HttpClient"/>
        /// </summary>
        /// <param name="handlers">
        /// Chain of <see cref="HttpMessageHandler" /> instances.
        /// All but the last should be <see cref="DelegatingHandler"/>s.
        /// </param>
        /// <returns>The default <see cref="HttpClient"/>.</returns>
        public static HttpClient CreateDefaultHttpClient(params HttpMessageHandler[] handlers)
        {
            if (handlers == null)
                throw new ArgumentNullException(nameof(handlers));

            var client = new HttpClient(CreatePipeline(handlers));

            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            return client;
        }

        /// <summary>
        /// Transform a collection of <see cref="HttpMessageHandler"/>s into a chain of
        /// <see cref="HttpMessageHandler"/>s.
        /// </summary>
        /// <param name="handlers">
        /// Chain of <see cref="HttpMessageHandler" /> instances.
        /// All but the last should be <see cref="DelegatingHandler"/>s.
        /// </param>
        /// <returns>A chain of <see cref="HttpMessageHandler"/>s</returns>
        public static HttpMessageHandler CreatePipeline(IReadOnlyCollection<HttpMessageHandler> handlers)
        {
            if (handlers == null)
                throw new ArgumentNullException(nameof(handlers));

            HttpMessageHandler pipeline = handlers.LastOrDefault() ?? CreateDefaultHttpClientHandler();
            DelegatingHandler dHandler = pipeline as DelegatingHandler;
            if (dHandler != null)
            {
                dHandler.InnerHandler = CreateDefaultHttpClientHandler();
                pipeline = dHandler;
            }

            // Wire handlers up in reverse order
            IEnumerable<HttpMessageHandler> reversedHandlers = handlers.Reverse().Skip(1);
            foreach (HttpMessageHandler handler in reversedHandlers)
            {
                dHandler = handler as DelegatingHandler;
                if (dHandler == null)
                {
                    throw new ArgumentException(
                        $"All message handlers except the last must be of type '{typeof(DelegatingHandler).Name}'.",
                        nameof(handlers));
                }

                dHandler.InnerHandler = pipeline;
                pipeline = dHandler;
            }

            return pipeline;
        }

        /// <summary>
        /// Returns a default HttpMessageHandler that supports automatic decompression.
        /// </summary>
        public static HttpClientHandler CreateDefaultHttpClientHandler()
        {
            var handler = new HttpClientHandler();
            if (handler.SupportsAutomaticDecompression)
            {
                handler.AutomaticDecompression = DecompressionMethods.GZip;
            }

            return handler;
        }

        /// <inheritdoc/>
        public Task<CloudFlareResponse<IReadOnlyList<Zone>>> GetZonesAsync(
            CancellationToken cancellationToken,
            PagedZoneParameters parameters = null,
            CloudFlareAuth auth = null)
        {
            return _client.GetZonesAsync(cancellationToken, auth ?? _auth, parameters);
        }

        /// <inheritdoc/>
        public Task<IEnumerable<Zone>> GetAllZonesAsync(
            CancellationToken cancellationToken,
            PagedZoneParameters parameters = null,
            CloudFlareAuth auth = null)
        {
            return GetAllPagedResultsAsync<Zone, PagedZoneParameters, PagedZoneOrderFieldTypes>(
                _client.GetZonesAsync,
                cancellationToken,
                auth ?? _auth,
                50,
                parameters);
        }

        /// <inheritdoc/>
        public Task<Zone> GetZoneAsync(
            IdentifierTag zoneId,
            CancellationToken cancellationToken,
            CloudFlareAuth auth = null)
        {
            return _client.GetZoneAsync(zoneId, cancellationToken, auth ?? _auth);
        }

        private static async Task<IEnumerable<TResult>> GetAllPagedResultsAsync<TResult, TParams, TOrder>(
            Func<CancellationToken, CloudFlareAuth, TParams, Task<CloudFlareResponse<IReadOnlyList<TResult>>>> request,
            CancellationToken cancellationToken,
            CloudFlareAuth auth,
            int maxPerPage,
            TParams parameters = null)
            where TResult : class
            where TParams : PagedParameters<TOrder>
            where TOrder : struct
        {
            IEnumerable<TResult> result = Enumerable.Empty<TResult>();
            int page = 0;
            CloudFlareResultInfo resultInfo;

            do
            {
                ++page;

                // Create the paged parameters;
                JObject jsonParams = JObject.FromObject(new { page, per_page = maxPerPage });

                // If parameters have been supplied use them, but override the paged parameters into them.
                if (parameters != null)
                {
                    JObject mergedParams = JObject.FromObject(parameters);
                    mergedParams.Merge(jsonParams);
                    jsonParams = mergedParams;
                }

                TParams pagedParams = jsonParams.ToObject<TParams>();
                CloudFlareResponse<IReadOnlyList<TResult>> response =
                    await request(
                        cancellationToken,
                        auth,
                        pagedParams).ConfigureAwait(false);

                result = result.Concat(response.Result);
                resultInfo = response.ResultInfo;
            }
            while (resultInfo.Page < resultInfo.TotalPages);

            return result;
        }
    }
}
