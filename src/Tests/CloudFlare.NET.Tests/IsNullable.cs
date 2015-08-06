namespace CloudFlare.NET
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Reflection;
    using AutoTest.ArgNullEx.Filter;

    /// <summary>
    /// Filters out parameters that are <see cref="Nullable"/> value types.
    /// </summary>
    public sealed class IsNullable : FilterBase, IParameterFilter
    {
        /// <summary>
        /// Filters out parameters that are <see cref="Nullable"/> value types.
        /// </summary>
        /// <param name="type">The type.</param>
        /// <param name="method">The method.</param>
        /// <param name="parameter">The parameter.</param>
        /// <returns><see langword="true"/> if the <paramref name="parameter"/> should be excluded;
        /// otherwise <see langword="false"/>.</returns>
        /// <exception cref="ArgumentNullException">The <paramref name="type"/>, <paramref name="method"/> or
        /// <paramref name="parameter"/> parameters are <see langword="null"/>.</exception>
        bool IParameterFilter.ExcludeParameter(Type type, MethodBase method, ParameterInfo parameter)
        {
            if (type == null)
                throw new ArgumentNullException(nameof(type));
            if (method == null)
                throw new ArgumentNullException(nameof(method));
            if (parameter == null)
                throw new ArgumentNullException(nameof(parameter));

            return parameter.ParameterType.IsGenericType &&
                   parameter.ParameterType.GetGenericTypeDefinition() == typeof(Nullable<>);
        }
    }
}
