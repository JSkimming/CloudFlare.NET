namespace CloudFlare.NET
{
    using System.Diagnostics.CodeAnalysis;
    using Newtonsoft.Json;
    using Newtonsoft.Json.Converters;

// ReSharper disable InconsistentNaming
#pragma warning disable 1591

    /// <summary>
    /// The type of a <see cref="DnsRecord"/>.
    /// </summary>
    [SuppressMessage(
        "StyleCop.CSharp.DocumentationRules",
        "SA1602:EnumerationItemsMustBeDocumented",
        Justification = "Names are self-explanatory.")]
    [JsonConverter(typeof(StringEnumConverter))]
    public enum DnsRecordType
    {
        A,
        AAAA,
        CNAME,
        TXT,
        SRV,
        LOC,
        MX,
        NS,
        SPF,
    }
}
