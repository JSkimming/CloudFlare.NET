namespace CloudFlare.NET.Serialization
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Machine.Specifications;
    using Newtonsoft.Json.Linq;

    [Subject(typeof(CloudFlareResponse<>))]
    public class When_deserializing_success_response
    {
        static JObject _json;
        static CloudFlareResponse<JObject> _sut;

        Establish context = () => _json = SampleJson.SuccessResponse;

        Because of = () => _sut = _json.ToObject<CloudFlareResponse<JObject>>();

        It should_deserialize_result =
            () => _sut.Result["id"].ShouldEqual(_json["result"]["id"]);

        It should_deserialize_success =
            () => _sut.Success.ShouldEqual(_json["success"].Value<bool>());

        It should_deserialize_errors =
            () => _sut.Errors
                .ShouldContainOnly(_json["errors"].ToObject<List<CloudFlareError>>());

        It should_deserialize_messages =
            () => _sut.Messages
                .ShouldContainOnly(_json["messages"].ToObject<List<string>>());

        It should_deserialize_result_info_page =
            () => _sut.ResultInfo.Page
                .ShouldEqual(_json["result_info"]["page"].Value<int>());

        It should_deserialize_result_info_per_page =
            () => _sut.ResultInfo.PerPage
                .ShouldEqual(_json["result_info"]["per_page"].Value<int>());

        It should_deserialize_result_info_count =
            () => _sut.ResultInfo.Count
                .ShouldEqual(_json["result_info"]["count"].Value<int>());

        It should_deserialize_result_info_total_count =
            () => _sut.ResultInfo.TotalCount
                .ShouldEqual(_json["result_info"]["total_count"].Value<int>());
    }
}
