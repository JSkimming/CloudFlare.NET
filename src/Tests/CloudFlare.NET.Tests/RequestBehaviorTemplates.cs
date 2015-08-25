namespace CloudFlare.NET
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using CloudFlare.NET.HttpHandlers;
    using Machine.Specifications;

    /// <seealso href="https://api.cloudflare.com/#requests"/>
    [Behaviors]
    public class AuthenticatedRequestBehaviour
    {
        protected static TestHttpHandler _handler;
        protected static CloudFlareAuth _auth;

        It It_should_provide_the_email_authentication_header = () =>
            _handler.Request.Headers.GetValues("X-Auth-Email").Single().ShouldEqual(_auth.Email);

        It It_should_provide_the_key_authentication_header = () =>
            _handler.Request.Headers.GetValues("X-Auth-Key").Single().ShouldEqual(_auth.Key);
    }
}
