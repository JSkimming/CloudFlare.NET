namespace CloudFlare.NET
{
    using System;
    using System.Collections.Generic;
    using System.Diagnostics;
    using System.Linq;
    using Newtonsoft.Json;

    /// <summary>
    /// Represent the base response from CloudFlare indicating success or failure.
    /// </summary>
    /// <seealso href="https://api.cloudflare.com/#responses"/>
    [DebuggerDisplay("{DebuggerDisplay,nq}")]
    public class CloudFlareResponseBase
    {
        private static readonly IReadOnlyList<CloudFlareError> EmptyErrors = new CloudFlareError[0];

        private static readonly CloudFlareResultInfo DefaultResultInfo =
            new CloudFlareResultInfo(-1, -1, -1, -1, -1);

        private static readonly IReadOnlyList<string> EmptyMessages = new string[0];

        /// <summary>
        /// Initializes a new instance of the <see cref="CloudFlareResponseBase"/> class.
        /// </summary>
        public CloudFlareResponseBase(
            bool success,
            IReadOnlyList<CloudFlareError> errors = null,
            IReadOnlyList<string> messages = null,
            CloudFlareResultInfo resultInfo = null)
        {
            Success = success;
            Errors = errors ?? EmptyErrors;
            Messages = messages ?? EmptyMessages;
            ResultInfo = resultInfo ?? DefaultResultInfo;
        }

        /// <summary>
        /// Gets the value indicating whether the request was successful.
        /// </summary>
        [JsonProperty("success")]
        public bool Success { get; }

        /// <summary>
        /// Gets the errors for unsuccessful requests.
        /// </summary>
        [JsonProperty("errors")]
        public IReadOnlyList<CloudFlareError> Errors { get; }

        /// <summary>
        /// Gets the messages for unsuccessful requests.
        /// </summary>
        [JsonProperty("messages")]
        public IReadOnlyList<string> Messages { get; }

        /// <summary>
        /// Gets the result info about the request.
        /// </summary>
        [JsonProperty("result_info")]
        public CloudFlareResultInfo ResultInfo { get; }

        private string DebuggerDisplay => $"{GetType().Name}: Success={Success}";
    }
}
