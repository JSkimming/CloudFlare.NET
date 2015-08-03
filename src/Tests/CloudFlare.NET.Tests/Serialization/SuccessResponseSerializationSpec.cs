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
        static JObject _successResponseJson;
        static CloudFlareResponse<JObject> _successResponse;

        Because of = () =>
        {
            _successResponseJson = SampleJson.SuccessResponse;
            _successResponse = _successResponseJson.ToObject<CloudFlareResponse<JObject>>();
        };

        It should_deserialize_result =
            () => _successResponse.Result["id"].ShouldEqual(_successResponseJson["result"]["id"]);

        It should_deserialize_success =
            () => _successResponse.Success.ShouldEqual(_successResponseJson["success"].Value<bool>());

        It should_deserialize_errors =
            () => _successResponse.Errors
                .ShouldContainOnly(_successResponseJson["errors"].ToObject<List<CloudFlareError>>());

        It should_deserialize_messages =
            () => _successResponse.Messages
                .ShouldContainOnly(_successResponseJson["messages"].ToObject<List<string>>());

        It should_deserialize_result_info_page =
            () => _successResponse.ResultInfo.Page
                .ShouldEqual(_successResponseJson["result_info"]["page"].Value<int>());

        It should_deserialize_result_info_per_page =
            () => _successResponse.ResultInfo.PerPage
                .ShouldEqual(_successResponseJson["result_info"]["per_page"].Value<int>());

        It should_deserialize_result_info_count =
            () => _successResponse.ResultInfo.Count
                .ShouldEqual(_successResponseJson["result_info"]["count"].Value<int>());

        It should_deserialize_result_info_total_count =
            () => _successResponse.ResultInfo.TotalCount
                .ShouldEqual(_successResponseJson["result_info"]["total_count"].Value<int>());
    }
}
