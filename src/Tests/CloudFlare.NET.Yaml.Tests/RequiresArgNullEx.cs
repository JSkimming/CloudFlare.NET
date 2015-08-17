namespace CloudFlare.NET
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using AutoTest.ArgNullEx;
    using AutoTest.ArgNullEx.Xunit;
    using CloudFlare.NET.Serialization;
    using Xunit;
    using Xunit.Extensions;

    public class RequiresArgNullEx
    {
        [Theory, RequiresArgNullExAutoMoq(typeof(ToYamlExtensions))]
        [Substitute(typeof(TypedJsonFormatter<>), typeof(TypedJsonFormatter<object>))]
        public Task CloudFlareYaml(MethodData method)
        {
            return method.Execute();
        }

        /// <summary>
        /// This test was added just to ensure the assembly references xunit, not just xunit.extensions.
        /// </summary>
        [Fact]
        public void ForXunit()
        {
        }
    }
}
