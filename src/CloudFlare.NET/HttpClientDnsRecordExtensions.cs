namespace CloudFlare.NET
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Net.Http;
    using System.Threading;
    using System.Threading.Tasks;

    /// <summary>
    /// Extension methods on <see cref="HttpClient"/> to wrap the Zone APIs
    /// </summary>
    /// <seealso href="https://api.cloudflare.com/#dns-records-for-a-zone"/>
    public static class HttpClientDnsRecordExtensions
    {
        /// <summary>
        /// Gets the zones for the account specified by the <paramref name="auth"/> details.
        /// </summary>
        /// <seealso href="https://api.cloudflare.com/#dns-records-for-a-zone-list-dns-records"/>
        public static async Task<IReadOnlyList<DnsRecord>> GetDnsRecordsAsync(
            this HttpClient client,
            IdentifierTag zoneId,
            CancellationToken cancellationToken,
            CloudFlareAuth auth)
        {
            if (client == null)
                throw new ArgumentNullException(nameof(client));
            if (zoneId == null)
                throw new ArgumentNullException(nameof(zoneId));
            if (auth == null)
                throw new ArgumentNullException(nameof(auth));

            Uri uri = new Uri(CloudFlareConstants.BaseUri, $"zones/{zoneId}/dns_records");
            var request = new HttpRequestMessage(HttpMethod.Get, uri);
            request.AddAuth(auth);

            HttpResponseMessage response =
                await client.SendAsync(request, HttpCompletionOption.ResponseHeadersRead, cancellationToken)
                    .ConfigureAwait(false);

            return (await response
                .GetResultAsync<IReadOnlyList<DnsRecord>>(cancellationToken)
                .ConfigureAwait(false))
                .Result;
        }
    }
}
