namespace CloudFlare.NET
{
    using System.Diagnostics.CodeAnalysis;
    using Newtonsoft.Json;
    using Newtonsoft.Json.Converters;

    // ReSharper disable InconsistentNaming
#pragma warning disable 1591

    /// <summary>
    /// The values of Cache Level setting.
    /// </summary>
    [SuppressMessage("StyleCop.CSharp.DocumentationRules", "SA1602:EnumerationItemsMustBeDocumented",
        Justification = "Names are self-explanatory.")]
    [SuppressMessage("StyleCop.CSharp.NamingRules", "SA1303:ConstFieldNamesMustBeginWithUpperCaseLetter",
        Justification = "Named to match serialized values.")]
    [JsonConverter(typeof(StringEnumConverter))]
    public enum SettingSecurityLevelTypes
    {
        essentially_off,
        low,
        medium,
        high,
        under_attack,
    }
}
