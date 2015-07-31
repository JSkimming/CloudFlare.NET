namespace CloudFlare.NET
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Machine.Specifications;

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

    [Subject(typeof(IdentifierTag))]
    public class When_evaluating_equality_via_default_Equals
    {
        protected static object _source;
        protected static object _same;
        protected static object _different;

        Establish context = () =>
        {
            _source = new IdentifierTag(Guid.NewGuid().ToString("N"));
            _same = new IdentifierTag(_source.ToString());
            _different = new IdentifierTag(Guid.NewGuid().ToString("N"));
        };

        It should_be_equal_when_compared_against_the_same_reference =
            () => _source.Equals(_source).ShouldBeTrue();

        It should_be_equal_when_compared_against_the_same_value =
            () => _source.Equals(_same).ShouldBeTrue();

        It should_not_be_equal_when_compared_against_the_a_different_value =
            () => _source.Equals(_different).ShouldBeFalse();

        It should_not_be_equal_when_compared_against_a_different_type =
            () => _source.Equals(Guid.NewGuid()).ShouldBeFalse();

        It should_not_be_equal_when_compared_against_null =
            () => _source.Equals(null).ShouldBeFalse();
    }

    [Subject(typeof(IdentifierTag))]
    public class When_evaluating_equality_via_typed_Equals
    {
        protected static IdentifierTag _source;
        protected static IdentifierTag _same;
        protected static IdentifierTag _different;

        Establish context = () =>
        {
            _source = new IdentifierTag(Guid.NewGuid().ToString("N"));
            _same = new IdentifierTag(_source.ToString());
            _different = new IdentifierTag(Guid.NewGuid().ToString("N"));
        };

        It should_be_equal_when_compared_against_the_same_reference =
            () => _source.Equals(_source).ShouldBeTrue();

        It should_be_equal_when_compared_against_the_same_value =
            () => _source.Equals(_same).ShouldBeTrue();

        It should_not_be_equal_when_compared_against_the_a_different_value =
            () => _source.Equals(_different).ShouldBeFalse();

        It should_not_be_equal_when_compared_against_null =
            () => _source.Equals(null).ShouldBeFalse();
    }

    [Subject(typeof(IdentifierTag))]
    public class When_evaluating_equality_via_Comparer_Equals
    {
        protected static IdentifierTag _source;
        protected static IdentifierTag _same;
        protected static IdentifierTag _different;
        protected static IdentifierTag _differentType;

        Establish context = () =>
        {
            _source = new IdentifierTag(Guid.NewGuid().ToString("N"));
            _same = new IdentifierTag(_source.ToString());
            _different = new IdentifierTag(Guid.NewGuid().ToString("N"));
            _differentType = new Moq.Mock<IdentifierTag>(_source.ToString()).Object;
        };

        It should_be_equal_when_compared_against_the_same_reference =
            () => IdentifierTag.Comparer.Equals(_source, _source).ShouldBeTrue();

        It should_be_equal_when_both_operands_null =
            () => IdentifierTag.Comparer.Equals(null, null).ShouldBeTrue();

        It should_be_equal_when_compared_against_the_same_value =
            () => IdentifierTag.Comparer.Equals(_source, _same).ShouldBeTrue();

        It should_not_be_equal_when_compared_against_the_a_different_value =
            () => IdentifierTag.Comparer.Equals(_source, _different).ShouldBeFalse();

        It should_not_be_equal_when_compared_against_null_lhs =
            () => IdentifierTag.Comparer.Equals(null, _source).ShouldBeFalse();

        It should_not_be_equal_when_compared_against_null_rhs =
            () => IdentifierTag.Comparer.Equals(_source, null).ShouldBeFalse();

        It should_not_be_equal_when_compared_against_different_type =
            () => IdentifierTag.Comparer.Equals(_source, _differentType).ShouldBeFalse();
    }
}
