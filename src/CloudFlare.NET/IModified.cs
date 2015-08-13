namespace CloudFlare.NET
{
    using System;
    using CloudFlare.NET.Serialization;
    using Newtonsoft.Json;

    /// <summary>
    /// Defines the <see cref="CreatedOn"/> and <see cref="ModifiedOn"/> properies of an entity.
    /// </summary>
    public interface IModified
    {
        /// <summary>
        /// When the entity was created.
        /// </summary>
        [JsonProperty("created_on")]
        [JsonConverter(typeof(IsoDateTimeOffsetConverter))]
        DateTimeOffset? CreatedOn { get; }

        /// <summary>
        /// When the entity was last modified.
        /// </summary>
        [JsonProperty("modified_on")]
        [JsonConverter(typeof(IsoDateTimeOffsetConverter))]
        DateTimeOffset ModifiedOn { get; }
    }
}
