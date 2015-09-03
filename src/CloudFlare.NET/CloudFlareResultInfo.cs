namespace CloudFlare.NET
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Newtonsoft.Json;

    /// <summary>
    /// Represent additional pagination information from successful CloudFlare API requests.
    /// <seealso href="https://api.cloudflare.com/#requests"/>
    /// </summary>
    public class CloudFlareResultInfo
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="CloudFlareResultInfo"/> class.
        /// </summary>
        public CloudFlareResultInfo(int page, int totalPages, int perPage, int count, int totalCount)
        {
            Page = page;
            TotalPages = totalPages;
            PerPage = perPage;
            Count = count;
            TotalCount = totalCount;
        }

        /// <summary>
        /// Gets the page number of the current <see cref="CloudFlareResponse{T}"/>.
        /// </summary>
        [JsonProperty("page")]
        public int Page { get; }

        /// <summary>
        /// Gets the total number of pages.
        /// </summary>
        [JsonProperty("total_pages")]
        public int TotalPages { get; }

        /// <summary>
        /// Gets the number of results per page.
        /// </summary>
        [JsonProperty("per_page")]
        public int PerPage { get; }

        /// <summary>
        /// Gets the number of results of the current <see cref="CloudFlareResponse{T}"/>.
        /// </summary>
        [JsonProperty("count")]
        public int Count { get; }

        /// <summary>
        /// Gets the total number of results.
        /// </summary>
        [JsonProperty("total_count")]
        public int TotalCount { get; }
    }
}
