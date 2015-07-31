namespace CloudFlare.NET
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Net;
    using System.Net.Http;
    using System.Net.Http.Headers;
    using System.Threading;
    using System.Threading.Tasks;

    /// <inheritdoc/>
    public class CloudFlareClient : ICloudFlareClient
    {
        private static readonly Lazy<HttpClient> LazyClient = new Lazy<HttpClient>(
            () =>
            {
                var client = new HttpClient(
                    new HttpClientHandler
                    {
                        AutomaticDecompression = DecompressionMethods.GZip,
                    })
                    ;

                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                return client;
            },
            LazyThreadSafetyMode.PublicationOnly);

        private static HttpClient Client => LazyClient.Value;

        /// <inheritdoc/>
        public Task<IReadOnlyList<Zone>> GetZonesAsync(CancellationToken cancellationToken, CloudFlareAuth auth = null)
        {
            return Client.GetZonesAsync(auth, cancellationToken);
        }
    }
}
