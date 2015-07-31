namespace CloudFlare.NET.Serialization
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Machine.Specifications;
    using Newtonsoft.Json.Linq;

    [Subject(typeof(CloudFlareResponseBase))]
    public class When_deserializing_error_response
    {
        static JObject _errorResponseJson;
        static CloudFlareResponseBase _errorResponse;

        Because of = () =>
        {
            _errorResponseJson = SampleJson.ErrorResponse;
            _errorResponse = _errorResponseJson.ToObject<CloudFlareResponseBase>();
        };

        It should_deserialize_success =
            () => _errorResponse.Success.ShouldEqual(_errorResponseJson["success"].Value<bool>());

        It should_deserialize_errors =
            () => _errorResponse.Errors
                .ShouldContainOnly(_errorResponseJson["errors"].ToObject<List<CloudFlareError>>());

        It should_deserialize_messages =
            () => _errorResponse.Messages
                .ShouldContainOnly(_errorResponseJson["messages"].ToObject<List<string>>());
    }
}
