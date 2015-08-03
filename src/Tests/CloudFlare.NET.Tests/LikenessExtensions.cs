namespace CloudFlare.NET
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Ploeh.SemanticComparison;
    using Ploeh.SemanticComparison.Fluent;

    internal static class LikenessExtensions
    {
        public static Likeness<T, T> AsLikeness<T>(this T actual)
                    where T : class
        {
            if (actual == null)
                throw new ArgumentNullException(nameof(actual));

            return actual.AsSource().OfLikeness<T>();
        }
    }
}
