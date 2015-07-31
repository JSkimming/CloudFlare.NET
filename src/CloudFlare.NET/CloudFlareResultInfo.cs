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
        public CloudFlareResultInfo(int page, int perPage, int count, int totalCount)
        {
            Page = page;
            PerPage = perPage;
            Count = count;
            TotalCount = totalCount;
        }

        /// <summary>
        /// Gets the TBD.
        /// </summary>
        [JsonProperty("page")]
        public int Page { get; }

        /// <summary>
        /// Gets the TBD.
        /// </summary>
        [JsonProperty("per_page")]
        public int PerPage { get; }

        /// <summary>
        /// Gets the TBD.
        /// </summary>
        [JsonProperty("count")]
        public int Count { get; }

        /// <summary>
        /// Gets the TBD.
        /// </summary>
        [JsonProperty("total_count")]
        public int TotalCount { get; }
    }
}
