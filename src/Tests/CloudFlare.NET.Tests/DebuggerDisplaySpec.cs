namespace CloudFlare.NET.DebuggerDisplaySpec
{
    using System;
    using System.Collections.Generic;
    using System.Diagnostics;
    using System.Linq;
    using System.Reflection;
    using Machine.Specifications;
    using Ploeh.AutoFixture;

    public abstract class DebuggerDisplayContext<T> : FixtureContext
        where T : class
    {
        protected static T _sut;
        protected static DebuggerDisplayAttribute _debuggerDisplay;
        protected static PropertyInfo _debuggerDisplayPropertyInfo;
        protected static MethodInfo _debuggerDisplayGetMethod;
        protected static object _debuggerDisplayValue;

        /// <summary>
        /// Returns the <see cref="DebuggerDisplayAttribute"/> data of the <see cref="_sut"/>
        /// </summary>
        /// <returns>The <see cref="DebuggerDisplayAttribute"/> data of the <see cref="_sut"/>.</returns>
        protected static string GetDebuggerDisplay()
        {
            Type type = _sut.GetType();

            _debuggerDisplay = type.GetCustomAttribute<DebuggerDisplayAttribute>(inherit: false);

            _debuggerDisplayPropertyInfo =
                type.GetProperty("DebuggerDisplay", BindingFlags.NonPublic | BindingFlags.Instance);

            _debuggerDisplayGetMethod = _debuggerDisplayPropertyInfo.GetGetMethod(true);

            _debuggerDisplayValue = _debuggerDisplayGetMethod.Invoke(_sut, new object[] {});

            return _debuggerDisplayValue.ToString();
        }
    }

    [Behaviors]
    public class DebuggerDisplayBehavior
    {
        protected static object _sut;
        protected static DebuggerDisplayAttribute _debuggerDisplay;
        protected static PropertyInfo _debuggerDisplayPropertyInfo;
        protected static MethodInfo _debuggerDisplayGetMethod;
        protected static object _debuggerDisplayValue;

        It should_have_the_debugger_display_attribute = () => _debuggerDisplay.ShouldNotBeNull();

        It should_specify_the_debugger_display_property =
            () => _debuggerDisplay.Value.ShouldEqual("{DebuggerDisplay,nq}");

        It should_have_the_debugger_display_private_property = () => _debuggerDisplayPropertyInfo.ShouldNotBeNull();

        It should_have_a_getter_on_the_debugger_display_property = () => _debuggerDisplayGetMethod.ShouldNotBeNull();

        It should_provide_a_string_display_property = () => _debuggerDisplayValue.ShouldBeOfExactType<string>();

        It should_include_the_type_in_the_debugger_display =
            () => _debuggerDisplayValue.ToString().ShouldStartWith($"{_sut.GetType().Name}:");
    }

    namespace CloudFlareAuthSpec
    {
        [Subject(typeof(CloudFlareAuth))]
        public class When_running_in_the_debugger : DebuggerDisplayContext<CloudFlareAuth>
        {
            static string _debuggerDisplayText;

            Establish contect = () => _sut = _fixture.Create<CloudFlareAuth>();

            Because of = () => _debuggerDisplayText = GetDebuggerDisplay();

            Behaves_like<DebuggerDisplayBehavior> debugger_display_behaviour;

            It should_include_the_email_in_the_debugger_display = () => _debuggerDisplayText.ShouldContain(_sut.Email);
        }
    }

    namespace CloudFlareClientSpec
    {
        [Subject(typeof(CloudFlareClient))]
        public class When_running_in_the_debugger : DebuggerDisplayContext<CloudFlareClient>
        {
            static string _debuggerDisplayText;

            Establish contect = () => _sut = _fixture.Create<CloudFlareClient>();

            Because of = () => _debuggerDisplayText = GetDebuggerDisplay();

            Behaves_like<DebuggerDisplayBehavior> debugger_display_behaviour;

            It should_include_the_authentication_email_in_the_debugger_display =
                () => _debuggerDisplayText.ShouldContain(_sut.Auth.Email);
        }
    }

    namespace CloudFlareErrorSpec
    {
        [Subject(typeof(CloudFlareError))]
        public class When_running_in_the_debugger : DebuggerDisplayContext<CloudFlareError>
        {
            static string _debuggerDisplayText;

            Establish contect = () => _sut = _fixture.Create<CloudFlareError>();

            Because of = () => _debuggerDisplayText = GetDebuggerDisplay();

            Behaves_like<DebuggerDisplayBehavior> debugger_display_behaviour;

            It should_include_the_code_in_the_debugger_display =
                () => _debuggerDisplayText.ShouldContain(_sut.Code.ToString());

            It should_include_the_message_in_the_debugger_display =
                () => _debuggerDisplayText.ShouldContain(_sut.Message);
        }
    }

    namespace CloudFlareResponseBaseSpec
    {
        [Subject(typeof(CloudFlareResponseBase))]
        public class When_running_in_the_debugger : DebuggerDisplayContext<CloudFlareResponseBase>
        {
            static string _debuggerDisplayText;

            Establish contect = () => _sut = _fixture.Create<CloudFlareResponseBase>();

            Because of = () => _debuggerDisplayText = GetDebuggerDisplay();

            Behaves_like<DebuggerDisplayBehavior> debugger_display_behaviour;

            It should_include_the_success_status_in_the_debugger_display =
                () => _debuggerDisplayText.ShouldContain($"Success={_sut.Success}");
        }
    }

    namespace DnsRecordSpec
    {
        [Subject(typeof(DnsRecord))]
        public class When_running_in_the_debugger : DebuggerDisplayContext<DnsRecord>
        {
            static string _debuggerDisplayText;

            Establish contect = () => _sut = _fixture.Create<DnsRecord>();

            Because of = () => _debuggerDisplayText = GetDebuggerDisplay();

            Behaves_like<DebuggerDisplayBehavior> debugger_display_behaviour;

            It should_include_the_type_in_the_debugger_display =
                () => _debuggerDisplayText.ShouldContain($"{_sut.Type}");

            It should_include_the_name_in_the_debugger_display =
                () => _debuggerDisplayText.ShouldContain($"{_sut.Name}");

            It should_include_the_content_in_the_debugger_display =
                () => _debuggerDisplayText.ShouldContain($"{_sut.Content}");
        }
    }

    namespace ZoneSpec
    {
        [Subject(typeof(Zone))]
        public class When_running_in_the_debugger : DebuggerDisplayContext<Zone>
        {
            static string _debuggerDisplayText;

            Establish contect = () => _sut = _fixture.Create<Zone>();

            Because of = () => _debuggerDisplayText = GetDebuggerDisplay();

            Behaves_like<DebuggerDisplayBehavior> debugger_display_behaviour;

            It should_include_the_name_in_the_debugger_display =
                () => _debuggerDisplayText.ShouldContain($"{_sut.Name}");
        }
    }
}
