namespace CloudFlare.NET
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using CloudFlare.NET.HttpHandlers;
    using Machine.Specifications;

    /// <seealso href="https://api.cloudflare.com/#requests"/>
    [Behaviors]
    public class AuthenticatedRequestBehaviour
    {
        protected static TestHttpHandler _handler;
        protected static CloudFlareAuth _auth;

        It should_provide_the_email_authentication_header = () =>
            _handler.Request.Headers.GetValues("X-Auth-Email").Single().ShouldEqual(_auth.Email);

        It should_provide_the_key_authentication_header = () =>
            _handler.Request.Headers.GetValues("X-Auth-Key").Single().ShouldEqual(_auth.Key);
    }

    /// <seealso href="https://api.cloudflare.com/#responses"/>
    [Behaviors]
    public class ErredRequestBehaviour
    {
        protected static CloudFlareResponseBase _erredResponse;
        protected static Exception _exception;

        It should_throw_a_CloudFlareException = () => _exception.ShouldBeOfExactType<CloudFlareException>();

        It should_contain_the_erred_response_in_the_exception =
            () => ((CloudFlareException)_exception).Response.AsLikeness().ShouldEqual(_erredResponse);
    }
}
