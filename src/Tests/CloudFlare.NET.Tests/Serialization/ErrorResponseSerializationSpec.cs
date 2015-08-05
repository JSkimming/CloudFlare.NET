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
        static JObject _json;
        static CloudFlareResponseBase _sut;

        Because of = () =>
        {
            _json = SampleJson.ErrorResponse;
            _sut = _json.ToObject<CloudFlareResponseBase>();
        };

        It should_deserialize_success =
            () => _sut.Success.ShouldEqual(_json["success"].Value<bool>());

        It should_deserialize_errors =
            () => _sut.Errors
                .ShouldContainOnly(_json["errors"].ToObject<List<CloudFlareError>>());

        It should_deserialize_messages =
            () => _sut.Messages
                .ShouldContainOnly(_json["messages"].ToObject<List<string>>());
    }
}
