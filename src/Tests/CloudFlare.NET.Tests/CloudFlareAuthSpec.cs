namespace CloudFlare.NET.AuthSpecs
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Machine.Specifications;
    using Newtonsoft.Json.Linq;
    using Ploeh.AutoFixture;

    [Subject(typeof(CloudFlareAuth))]
    public class When_initializing
    {
        static string _email;
        static string _key;
        static CloudFlareAuth _auth;
        static CloudFlareAuth _authCopy;

        Because of = () =>
        {
            var fixture = new Fixture();
            _email = fixture.Create<string>();
            _key = fixture.Create<string>();
            _auth = new CloudFlareAuth(_email, _key);
            _authCopy = JObject.FromObject(_auth).ToObject<CloudFlareAuth>();
        };

        It should_initialize_code = () => _auth.Email.ShouldBeTheSameAs(_email);

        It should_initialize_key = () => _auth.Key.ShouldBeTheSameAs(_key);

        It should_serialze_as_json = () => _authCopy.AsLikeness().ShouldEqual(_auth);
    }
}
