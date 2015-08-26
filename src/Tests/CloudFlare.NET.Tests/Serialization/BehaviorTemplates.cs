namespace CloudFlare.NET.Serialization
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Machine.Specifications;
    using Newtonsoft.Json.Linq;

    [Behaviors]
    public class IdentifierSerializeBehavior
    {
        protected static JObject _json;
        protected static IIdentifier _sut;

        It should_serialize_id = () => _sut.Id.ToString().ShouldEqual(_json["id"].Value<string>());
    }

    [Behaviors]
    public class IdentifierDeserializeBehavior
    {
        protected static JObject _json;
        protected static IIdentifier _sut;

        It should_deserialize_id = () => _sut.Id.ToString().ShouldEqual(_json["id"].Value<string>());
    }

    [Behaviors]
    public class ModifiedDeserializeBehavior
    {
        protected static JObject _json;
        protected static IModified _sut;

        It should_deserialize_created_on = () => _sut.CreatedOn.ShouldEqual(_json["created_on"].Value<DateTime>());

        It should_deserialize_modified_on = () => _sut.ModifiedOn.ShouldEqual(_json["modified_on"].Value<DateTime>());
    }

    [Behaviors]
    public class ModifiedSerializeBehavior
    {
        protected static JObject _json;
        protected static IModified _sut;

        It should_serialize_created_on =
            () => _sut.CreatedOn.Value.UtcDateTime.ToString("yyyy'-'MM'-'dd'T'HH':'mm':'ss.FFFFFFFK")
                .ShouldEqual(_json["created_on"].Value<string>());

        It should_serialize_created_on_for_ISO8601 = () => _json["created_on"].ToString().ShouldEndWith("Z");

        It should_serialize_modified_on =
            () => _sut.ModifiedOn.UtcDateTime.ToString("yyyy'-'MM'-'dd'T'HH':'mm':'ss.FFFFFFFK")
                .ShouldEqual(_json["modified_on"].Value<string>());

        It should_serialize_modified_on_for_ISO8601 = () => _json["modified_on"].ToString().ShouldEndWith("Z");
    }

    [Behaviors]
    public class PagedParametersSerializeBehavior<TOrder>
        where TOrder : struct
    {
        protected static JObject _json;
        protected static PagedParameters<TOrder> _sut;

        It should_serialize_id = () => _sut.Page.ShouldEqual(_json["page"].Value<int>());

        It should_serialize_per_page = () => _sut.PerPage.ShouldEqual(_json["per_page"].Value<int>());

        It should_serialize_order = () => _sut.Order.ToString().ShouldEqual(_json["order"].Value<string>());

        It should_serialize_direction =
            () => _sut.Direction.ToString().ShouldEqual(_json["direction"].Value<string>());

        It should_serialize_match = () => _sut.Match.ToString().ShouldEqual(_json["match"].Value<string>());
    }
}
