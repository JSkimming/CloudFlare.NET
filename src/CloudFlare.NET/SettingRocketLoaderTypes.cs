namespace CloudFlare.NET
{
    using System.Diagnostics.CodeAnalysis;
    using Newtonsoft.Json;
    using Newtonsoft.Json.Converters;

    // ReSharper disable InconsistentNaming
#pragma warning disable 1591

    /// <summary>
    /// Rocket Loader is a general-purpose asynchronous JavaScript loader coupled with a lightweight virtual browser
    /// which can safely run any JavaScript code after window.onload.
    /// <seealso href="https://api.cloudflare.com/#zone-settings-get-rocket-loader-setting"/>
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
    public enum SettingRocketLoaderTypes
    {
        off,
        on,
        manual,
    }
}
