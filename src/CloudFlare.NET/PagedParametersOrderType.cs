namespace CloudFlare.NET
{
    using System.Diagnostics.CodeAnalysis;
    using Newtonsoft.Json;
    using Newtonsoft.Json.Converters;

// ReSharper disable InconsistentNaming
#pragma warning disable 1591

    /// <summary>
    /// The types by which a paged results an be ordered.
    /// </summary>
    [SuppressMessage(
        "StyleCop.CSharp.DocumentationRules",
        "SA1602:EnumerationItemsMustBeDocumented",
        Justification = "Names are self-explanatory.")]
    [SuppressMessage(
        "StyleCop.CSharp.NamingRules",
        "SA1300:ConstFieldNamesMustBeginWithUpperCaseLetter",
        Justification = "Named to match serialized values.")]
    [JsonConverter(typeof(StringEnumConverter))]
    public enum PagedParametersOrderType
    {
        asc,
        desc,
    }
}
