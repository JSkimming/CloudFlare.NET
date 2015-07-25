namespace CloudFlare.NET
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Machine.Specifications;

    [Subject(typeof(IdentifierTag))]
    public class When_initializing_with_a_null_string
    {
        static Exception _exception;

        Because of = () =>
            _exception = Catch.Exception(() => new IdentifierTag(null));

        It throw_an_ArgumentNullException = () => _exception.ShouldBeOfExactType<ArgumentNullException>();
    }

    [Subject(typeof(IdentifierTag))]
    public class When_initializing_with_an_empty_string
    {
        static Exception _exception;

        Because of = () =>
            _exception = Catch.Exception(() => new IdentifierTag(string.Empty));

        It throw_an_ArgumentException = () => _exception.ShouldBeOfExactType<ArgumentException>();
    }

    [Subject(typeof(IdentifierTag))]
    public class When_initializing_with_a_long_string
    {
        static Exception _exception;

        Because of = () =>
            _exception = Catch.Exception(() => new IdentifierTag(Guid.NewGuid().ToString()));

        It throw_an_ArgumentException = () => _exception.ShouldBeOfExactType<ArgumentException>();
    }

    [Subject(typeof(IdentifierTag))]
    public class When_initializing_with_a_guid_string
    {
        static string _guid;
        static IdentifierTag _constructorCreated;
        static IdentifierTag _implicitCreated;

        Establish context = () =>
        {
            _guid = Guid.NewGuid().ToString("N");
            _constructorCreated = new IdentifierTag(_guid);
            _implicitCreated = _guid;
        };

        It can_be_created_via_the_constructor = () => _constructorCreated.ToString().ShouldEqual(_guid);

        It can_be_created_implicitly_with_a_string = () => _implicitCreated.ToString().ShouldEqual(_guid);

        It should_be_equal_to_the_same_string_id = () => (_implicitCreated == _guid).ShouldBeTrue();

        It should_implicitly_cast_to_a_string = () =>
        {
            string x = _implicitCreated;
        };

        It should_not_be_equal_to_the_a_different_string_id =
            () => (_implicitCreated == Guid.NewGuid().ToString("N")).ShouldBeFalse();

        It should_be_equal_to_the_same_identifier =
            () => _implicitCreated.Equals(_guid).ShouldBeTrue();

        It should_be_equal_to_the_same_identifier_when_cast_to_object =
            () => _implicitCreated.Equals((object)_constructorCreated).ShouldBeTrue();

        It should_not_be_equal_to_a_different_identifier =
            () => _implicitCreated.Equals(Guid.NewGuid().ToString("N")).ShouldBeFalse();

        It should_not_be_equal_to_a_different_object =
            () => _implicitCreated.Equals(new object()).ShouldBeFalse();

        It should_have_the_same_hashcode_as_the_same_id =
            () => _implicitCreated.GetHashCode().ShouldEqual(_guid.GetHashCode());

        It should_have_the_same_comparer_hashcode_ =
            () => IdentifierTag.Comparer.GetHashCode(_implicitCreated).ShouldEqual(_implicitCreated.GetHashCode());

        It should_be_equal_to_the_same_identifier_when_using_the_operator =
            () => (_implicitCreated == _constructorCreated).ShouldBeTrue();

        It should_not_be_equal_to_a_different_identifier_when_using_the_operator =
            () => (_implicitCreated == Guid.NewGuid().ToString("N")).ShouldBeFalse();

        It should_not_be_inequal_to_the_same_identifier_when_using_the_operator =
            () => (_implicitCreated != _constructorCreated).ShouldBeFalse();

        It should_be_inequal_to_a_different_identifier_when_using_the_operator =
            () => (_implicitCreated != Guid.NewGuid().ToString("N")).ShouldBeTrue();
    }
}
