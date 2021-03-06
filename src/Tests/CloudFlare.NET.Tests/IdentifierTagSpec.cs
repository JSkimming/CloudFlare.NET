﻿namespace CloudFlare.NET
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

        Because of = () =>
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
    public class When_evaluating_identifier_equality_via_default_Equals
    {
        protected static object _source;
        protected static object _same;
        protected static object _different;

        Because of = () =>
        {
            _source = new IdentifierTag(Guid.NewGuid().ToString("N"));
            _same = new IdentifierTag(_source.ToString());
            _different = new IdentifierTag(Guid.NewGuid().ToString("N"));
        };

        Behaves_like<DefaultEqualsBehavior> default_equals_behavior;
    }

    [Subject(typeof(IdentifierTag))]
    public class When_evaluating_identifier_equality_via_typed_Equals
    {
        protected static IdentifierTag _source;
        protected static IdentifierTag _same;
        protected static IdentifierTag _different;

        Because of = () =>
        {
            _source = new IdentifierTag(Guid.NewGuid().ToString("N"));
            _same = new IdentifierTag(_source.ToString());
            _different = new IdentifierTag(Guid.NewGuid().ToString("N"));
        };

        Behaves_like<TypedEqualsBehavior<IdentifierTag>> typed_equals_behavior;
    }

    [Subject(typeof(IdentifierTag))]
    public class When_evaluating_identifier_equality_via_Comparer_Equals
    {
        protected static Func<IdentifierTag, IdentifierTag, bool> _equals;
        protected static IdentifierTag _source;
        protected static IdentifierTag _same;
        protected static IdentifierTag _different;
        protected static IdentifierTag _differentType;

        Because of = () =>
        {
            _equals = IdentifierTag.Comparer.Equals;
            _source = new IdentifierTag(Guid.NewGuid().ToString("N"));
            _same = new IdentifierTag(_source.ToString());
            _different = new IdentifierTag(Guid.NewGuid().ToString("N"));
            _differentType = new Moq.Mock<IdentifierTag>(_source.ToString()).Object;
        };

        Behaves_like<ComparerEqualsBehavior<IdentifierTag>> equals_operator_behavior;
    }

    [Subject(typeof(IdentifierTag))]
    public class When_evaluating_identifier_equality_via_Equals_operator
    {
        protected static Func<IdentifierTag, IdentifierTag, bool> _equals;
        protected static IdentifierTag _source;
        protected static IdentifierTag _same;
        protected static IdentifierTag _different;
        protected static IdentifierTag _differentType;

        Because of = () =>
        {
            _equals = (l, r) => l == r;
            _source = new IdentifierTag(Guid.NewGuid().ToString("N"));
            _same = new IdentifierTag(_source.ToString());
            _different = new IdentifierTag(Guid.NewGuid().ToString("N"));
            _differentType = new Moq.Mock<IdentifierTag>(_source.ToString()).Object;
        };

        Behaves_like<ComparerEqualsBehavior<IdentifierTag>> equals_operator_behavior;
    }

    [Subject(typeof(IdentifierTag))]
    public class When_evaluating_identifier_enequality_via_Notequals_operator
    {
        protected static Func<IdentifierTag, IdentifierTag, bool> _notequals;
        protected static IdentifierTag _source;
        protected static IdentifierTag _same;
        protected static IdentifierTag _different;
        protected static IdentifierTag _differentType;

        Because of = () =>
        {
            _notequals = (l, r) => l != r;
            _source = new IdentifierTag(Guid.NewGuid().ToString("N"));
            _same = new IdentifierTag(_source.ToString());
            _different = new IdentifierTag(Guid.NewGuid().ToString("N"));
            _differentType = new Moq.Mock<IdentifierTag>(_source.ToString()).Object;
        };

        Behaves_like<ComparerNotEqualsBehavior<IdentifierTag>> notequals_operator_behavior;
    }
}
