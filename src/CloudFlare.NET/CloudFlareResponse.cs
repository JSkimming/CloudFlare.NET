namespace CloudFlare.NET
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Newtonsoft.Json;

    /// <summary>
    /// Represent the base generic response from CloudFlare indicating success or failure.
    /// </summary>
    /// <typeparam name="T">The type of the <see cref="Result"/>.</typeparam>
    /// <seealso href="https://api.cloudflare.com/#responses"/>
    public class CloudFlareResponse<T> : CloudFlareResponseBase
        where T : class
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="CloudFlareResponse{T}"/> class.
        /// </summary>
        public CloudFlareResponse(
            bool success,
            T result = null,
            IReadOnlyList<CloudFlareError> errors = null,
            IReadOnlyList<string> messages = null,
            CloudFlareResultInfo resultInfo = null)
            : base(success, errors, messages, resultInfo)
        {
            Result = result;
        }

        /// <summary>
        /// Gets the result of the request.
        /// </summary>
        [JsonProperty("result")]
        public T Result { get; }
    }
}
