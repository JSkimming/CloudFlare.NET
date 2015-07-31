namespace CloudFlare.NET
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Machine.Specifications;
    using Ploeh.AutoFixture;

    [Subject(typeof(CloudFlareError))]
    public class When_evaluating_error_equality_via_default_Equals
    {
        protected static object _source;
        protected static object _same;
        protected static object _different;

        Because of = () =>
        {
            _source = new CloudFlareError(1);
            _same = new CloudFlareError(1);
            _different = new CloudFlareError(2);
        };

        Behaves_like<DefaultEqualsBehavior> default_equals_behavior;
    }

    [Subject(typeof(CloudFlareError))]
    public class When_evaluating_error_equality_via_typed_Equals
    {
        protected static CloudFlareError _source;
        protected static CloudFlareError _same;
        protected static CloudFlareError _different;

        Because of = () =>
        {
            _source = new CloudFlareError(1);
            _same = new CloudFlareError(1);
            _different = new CloudFlareError(2);
        };

        Behaves_like<TypedEqualsBehavior<CloudFlareError>> typed_equals_behavior;
    }

    [Subject(typeof(CloudFlareError))]
    public class When_evaluating_error_equality_via_Equals_operator
    {
        protected static Func<CloudFlareError, CloudFlareError, bool> _equals;
        protected static CloudFlareError _source;
        protected static CloudFlareError _same;
        protected static CloudFlareError _different;
        protected static CloudFlareError _differentType;

        Because of = () =>
        {
            _equals = (l, r) => l == r;
            _source = new CloudFlareError(1);
            _same = new CloudFlareError(1);
            _different = new CloudFlareError(2);
            _differentType = new Moq.Mock<CloudFlareError>(1, string.Empty).Object;
        };

        Behaves_like<ComparerEqualsBehavior<CloudFlareError>> equals_operator_behavior;
    }

    [Subject(typeof(CloudFlareError))]
    public class When_evaluating_error_enequality_via_Notequals_operator
    {
        protected static Func<CloudFlareError, CloudFlareError, bool> _notequals;
        protected static CloudFlareError _source;
        protected static CloudFlareError _same;
        protected static CloudFlareError _different;
        protected static CloudFlareError _differentType;

        Because of = () =>
        {
            _notequals = (l, r) => l != r;
            _source = new CloudFlareError(1);
            _same = new CloudFlareError(1);
            _different = new CloudFlareError(2);
            _differentType = new Moq.Mock<CloudFlareError>(1, string.Empty).Object;
        };

        Behaves_like<ComparerNotEqualsBehavior<CloudFlareError>> notequals_operator_behavior;
    }

    [Subject(typeof(CloudFlareError))]
    public class When_initializing_an_error
    {
        static int _code;
        static string _message;
        static CloudFlareError _error;

        Because of = () =>
        {
            var fixture = new Fixture();
            _code = fixture.Freeze<int>();
            _message = fixture.Freeze<string>();
            _error = fixture.Freeze<CloudFlareError>();
        };

        It should_initialize_the_code = () => _error.Code.ShouldEqual(_code);

        It should_initialize_the_message = () => _error.Message.ShouldEqual(_message);

        It should_be_equal_to_the_same_code = () => (_code == _error).ShouldBeTrue();

        It should_have_the_same_hashcode_as_the_code = () => _error.GetHashCode().ShouldEqual(_code);
    }
}
