namespace CloudFlare.NET
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Reflection;
    using AutoTest.ArgNullEx;
    using AutoTest.ArgNullEx.Xunit;
    using Ploeh.AutoFixture;
    using Ploeh.AutoFixture.AutoMoq;

    [AttributeUsage(AttributeTargets.Method, AllowMultiple = true)]
    internal class RequiresArgNullExAutoMoqAttribute : RequiresArgumentNullExceptionAttribute
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="RequiresArgNullExAutoMoqAttribute"/> class.
        /// </summary>
        /// <param name="assemblyUnderTest">A type in the assembly under test.</param>
        public RequiresArgNullExAutoMoqAttribute(Type assemblyUnderTest)
            : base(CreateFixture(GetAssembly(assemblyUnderTest)))
        {
        }

        private static Assembly GetAssembly(Type assemblyUnderTest)
        {
            if (assemblyUnderTest == null)
                throw new ArgumentNullException(nameof(assemblyUnderTest));

            return assemblyUnderTest.Assembly;
        }

        private static IArgumentNullExceptionFixture CreateFixture(Assembly assemblyUnderTest)
        {
            var fixture =
                new Fixture()
                    .Customize(new CloudFlareCustomization());

            return new ArgumentNullExceptionFixture(assemblyUnderTest, fixture);
        }
    }
}
