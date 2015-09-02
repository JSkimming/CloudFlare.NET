namespace CloudFlare.NET.HttpHandlers
{
    using System;
    using System.Collections.Generic;
    using System.Net;
    using System.Net.Http;
    using System.Text;
    using System.Threading;
    using System.Threading.Tasks;
    using Newtonsoft.Json;
    using Newtonsoft.Json.Linq;

    /// <summary>
    /// ServiceFilter that allows a test to control the HTTP pipeline and
    /// analyze a request and provide a set response.
    /// </summary>
    public class TestHttpHandler : DelegatingHandler
    {
        readonly HttpResponseMessage _nullResponse;
        int _responseIndex;

        public TestHttpHandler()
        {
            Requests = new List<HttpRequestMessage>();
            Responses = new List<HttpResponseMessage>();
            RequestContents = new List<string>();

            _nullResponse = CreateResponse(string.Empty);
        }

        public HttpRequestMessage Request
        {
            get { return Requests.Count == 0 ? null : Requests[Requests.Count - 1]; }
            set
            {
                Requests.Clear();
                Requests.Add(value);
            }
        }

        public List<HttpRequestMessage> Requests { get; set; }
        public List<string> RequestContents { get; set; }

        public HttpResponseMessage Response
        {
            get { return Responses.Count == 0 ? null : Responses[Responses.Count - 1]; }
            set
            {
                _responseIndex = 0;
                Responses.Clear();
                Responses.Add(value);
            }
        }

        public List<HttpResponseMessage> Responses { get; set; }

        public Func<HttpRequestMessage, Task<HttpRequestMessage>> OnSendingRequest { get; set; }

        public void SetResponseContent(object content, HttpStatusCode code = HttpStatusCode.OK)
        {
            SetResponseContent(JObject.FromObject(content).ToString(Formatting.None), code);
        }

        public void SetResponseContent(string content, HttpStatusCode code = HttpStatusCode.OK)
        {
            Response = CreateResponse(content, code);
        }

        public void AddResponseContent(object content, HttpStatusCode code = HttpStatusCode.OK)
        {
            AddResponseContent(JObject.FromObject(content).ToString(Formatting.None), code);
        }

        public void AddResponseContent(string content, HttpStatusCode code = HttpStatusCode.OK)
        {
            Responses.Add(CreateResponse(content, code));
        }

        protected async override Task<HttpResponseMessage> SendAsync(
            HttpRequestMessage request,
            CancellationToken cancellationToken)
        {
            string content = request.Content == null
                ? null
                : await request.Content.ReadAsStringAsync().ConfigureAwait(false);
            RequestContents.Add(content);

            if (OnSendingRequest != null)
            {
                Requests.Add(await OnSendingRequest(request).ConfigureAwait(false));
            }
            else
            {
                Requests.Add(request);
            }

            if (_responseIndex < Responses.Count)
            {
                return Responses[_responseIndex++];
            }

            return _nullResponse;
        }

        public static HttpResponseMessage CreateResponse(string content, HttpStatusCode code = HttpStatusCode.OK)
        {
            return new HttpResponseMessage(code)
            {
                Content = new StringContent(content, Encoding.UTF8, "application/json")
            };
        }

    }
}
