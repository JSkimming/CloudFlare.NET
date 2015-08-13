namespace CloudFlare.NET
{
    using Newtonsoft.Json;

    /// <summary>
    /// Defines an entity that has a unique <see cref="Id"/>.
    /// </summary>
    public interface IIdentifier
    {
        /// <summary>
        /// API item identifier tag.
        /// </summary>
        [JsonProperty("id")]
        IdentifierTag Id { get; }
    }
}
