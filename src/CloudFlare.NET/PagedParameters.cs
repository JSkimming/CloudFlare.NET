namespace CloudFlare.NET
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Newtonsoft.Json;

    /// <summary>
    /// Specifies the parameters of a request supports paging.
    /// </summary>
    /// <typeparam name="TOrder">The type of the <see cref="Order"/> property.</typeparam>
    public abstract class PagedParameters<TOrder>
        where TOrder : struct
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="PagedParameters{TOrder}"/> class.
        /// </summary>
        protected PagedParameters(
            int page,
            int perPage,
            TOrder order,
            PagedParametersOrderType direction,
            PagedParametersMatchType match)
        {
            Page = page;
            PerPage = perPage;
            Order = order;
            Direction = direction;
            Match = match;
        }

        /// <summary>
        /// Gets the page number of paginated results.
        /// </summary>
        [JsonProperty("page")]
        public int Page { get; }

        /// <summary>
        /// Gets the number of results per page.
        /// </summary>
        [JsonProperty("per_page")]
        public int PerPage { get; }

        /// <summary>
        /// Field to order results by.
        /// </summary>
        [JsonProperty("order")]
        public TOrder Order { get; }

        /// <summary>
        /// Gets the direction to order.
        /// </summary>
        [JsonProperty("direction")]
        public PagedParametersOrderType Direction { get; }

        /// <summary>
        /// Gets the value of whether to match all search requirements or at least one (any).
        /// </summary>
        [JsonProperty("match")]
        public PagedParametersMatchType Match { get; }
    }
}
