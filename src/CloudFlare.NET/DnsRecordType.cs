namespace CloudFlare.NET
{
    using System.Diagnostics.CodeAnalysis;

// ReSharper disable InconsistentNaming
#pragma warning disable 1591

    /// <summary>
    /// The type of a <see cref="DnsRecord"/>.
    /// </summary>
    [SuppressMessage("StyleCop.CSharp.DocumentationRules", "SA1602:EnumerationItemsMustBeDocumented",
        Justification = "Names a self-explanatory.")]
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
