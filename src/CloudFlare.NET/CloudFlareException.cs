namespace CloudFlare.NET
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Net.Http;

    /// <summary>
    /// Contains the erred <see cref="CloudFlareResponseBase"/> to a request.
    /// </summary>
    public class CloudFlareException : Exception
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="CloudFlareException"/> class.
        /// </summary>
        public CloudFlareException(
            CloudFlareResponseBase response,
            HttpResponseMessage httpResponse = null,
            Exception innerException = null)
            : base(GetMessage(response, httpResponse), innerException)
        {
            Response = response;
            SetupData(response);
        }

        /// <summary>
        /// Gets the error information of the response.
        /// </summary>
        public CloudFlareResponseBase Response { get; }

        private static string GetMessage(CloudFlareResponseBase response, HttpResponseMessage httpResponse = null)
        {
            if (response == null)
                throw new ArgumentNullException(nameof(response));

            string message = response.Errors.FirstOrDefault()?.Message ?? "Unknown error.";
            string requestMethod = httpResponse?.RequestMessage?.Method?.ToString() ?? "Unknown HTTP Method";
            string requestUri = httpResponse?.RequestMessage?.RequestUri?.AbsoluteUri ?? "Unknown Uri";

            return $"{message}: {requestMethod} {requestUri}";
        }

        private void SetupData(CloudFlareResponseBase response)
        {
            if (response == null)
                throw new ArgumentNullException(nameof(response));

            int index = 1;
            foreach (CloudFlareError error in response.Errors)
            {
                Data[$"ErrorCode{index}"] = error.Code;
                Data[$"ErrorMessage{index}"] = error.Message;
            }

            index = 1;
            foreach (string message in response.Messages)
            {
                Data[$"Message{index}"] = message;
            }
        }
    }
}
