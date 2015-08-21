namespace CloudFlare.NET.Serialization
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Machine.Specifications;
    using Newtonsoft.Json.Linq;

    [Behaviors]
    public class IdentifierFormattingBehavior
    {
        protected static JObject _json;

        It should_remove_id = () => _json["id"].ShouldBeNull();
    }

    [Behaviors]
    public class ModifiedFormattingBehavior
    {
        protected static JObject _json;

        It should_remove_created_on = () => _json["created_on"].ShouldBeNull();

        It should_remove_modified_on = () => _json["modified_on"].ShouldBeNull();
    }
}
