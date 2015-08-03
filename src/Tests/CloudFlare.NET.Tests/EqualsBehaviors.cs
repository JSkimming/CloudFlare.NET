namespace CloudFlare.NET
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Machine.Specifications;

    [Behaviors]
    public class DefaultEqualsBehavior
    {
        protected static object _source;
        protected static object _same;
        protected static object _different;

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

    [Behaviors]
    public class TypedEqualsBehavior<T>
        where T : class, IEquatable<T>
    {
        protected static T _source;
        protected static T _same;
        protected static T _different;

        It should_be_equal_when_compared_against_the_same_reference =
            () => _source.Equals(_source).ShouldBeTrue();

        It should_be_equal_when_compared_against_the_same_value =
            () => _source.Equals(_same).ShouldBeTrue();

        It should_not_be_equal_when_compared_against_the_a_different_value =
            () => _source.Equals(_different).ShouldBeFalse();

        It should_not_be_equal_when_compared_against_null =
            () => _source.Equals(default(T)).ShouldBeFalse();
    }

    [Behaviors]
    public class ComparerEqualsBehavior<T>
        where T : class
    {
        protected static Func<T, T, bool> _equals;
        protected static T _source;
        protected static T _same;
        protected static T _different;
        protected static T _differentType;

        It should_be_equal_when_compared_against_the_same_reference =
            () => _equals(_source, _source).ShouldBeTrue();

        It should_be_equal_when_both_operands_null =
            () => _equals(null, null).ShouldBeTrue();

        It should_be_equal_when_compared_against_the_same_value =
            () => _equals(_source, _same).ShouldBeTrue();

        It should_not_be_equal_when_compared_against_the_a_different_value =
            () => _equals(_source, _different).ShouldBeFalse();

        It should_not_be_equal_when_compared_against_null_lhs =
            () => _equals(null, _source).ShouldBeFalse();

        It should_not_be_equal_when_compared_against_null_rhs =
            () => _equals(_source, null).ShouldBeFalse();

        It should_not_be_equal_when_compared_against_different_type =
            () => _equals(_source, _differentType).ShouldBeFalse();
    }

    [Behaviors]
    public class ComparerNotEqualsBehavior<T>
        where T : class
    {
        protected static Func<T, T, bool> _notequals;
        protected static T _source;
        protected static T _same;
        protected static T _different;
        protected static T _differentType;

        It should_be_inequal_when_compared_against_the_same_reference =
            () => _notequals(_source, _source).ShouldBeFalse();

        It should_be_inequal_when_both_operands_null =
            () => _notequals(null, null).ShouldBeFalse();

        It should_be_inequal_when_compared_against_the_same_value =
            () => _notequals(_source, _same).ShouldBeFalse();

        It should_not_be_inequal_when_compared_against_the_a_different_value =
            () => _notequals(_source, _different).ShouldBeTrue();

        It should_not_be_inequal_when_compared_against_null_lhs =
            () => _notequals(null, _source).ShouldBeTrue();

        It should_not_be_inequal_when_compared_against_null_rhs =
            () => _notequals(_source, null).ShouldBeTrue();

        It should_not_be_inequal_when_compared_against_different_type =
            () => _notequals(_source, _differentType).ShouldBeTrue();
    }
}
