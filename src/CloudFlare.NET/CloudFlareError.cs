namespace CloudFlare.NET
{
    using System;
    using System.Collections.Generic;
    using System.Diagnostics;
    using System.Linq;
    using Newtonsoft.Json;

    /// <summary>
    /// Represents an error that can occur as a result of a CloudFlare API request.
    /// </summary>
    /// <seealso href="https://api.cloudflare.com/#responses"/>
    [DebuggerDisplay("{DebuggerDisplay,nq}")]
    public class CloudFlareError : IEquatable<CloudFlareError>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="CloudFlareError"/> class.
        /// </summary>
        public CloudFlareError(int code, string message = null)
        {
            Code = code;
            Message = message ?? string.Empty;
        }

        /// <summary>
        /// Gets the error code.
        /// </summary>
        [JsonProperty("code")]
        public int Code { get; }

        /// <summary>
        /// Gets the error message.
        /// </summary>
        [JsonProperty("message")]
        public string Message { get; }

        private string DebuggerDisplay => $"{GetType().Name}: {Code} '{Message}'";

        /// <summary>
        /// The implicit operator to return the <see cref="Code"/> of a <see cref="CloudFlareError"/>.
        /// </summary>
        public static implicit operator int(CloudFlareError error)
        {
            if (error == null)
                throw new ArgumentNullException(nameof(error));

            return error.Code;
        }

        /// <summary>
        /// Determines whether two specified <see cref="CloudFlareError"/> objects have the same value.
        /// </summary>
        /// <param name="left">The first <see cref="CloudFlareError"/> to compare, or <see langword="null"/>.</param>
        /// <param name="right">The second <see cref="CloudFlareError"/> to compare, or <see langword="null"/>.</param>
        /// <returns>
        /// <see langword="true"/> if the value of <paramref name="left"/> is the same as the value of
        /// <paramref name="right"/>; otherwise, <see langword="false"/>.</returns>
        public static bool operator ==(CloudFlareError left, CloudFlareError right) => Equals(left, right);

        /// <summary>
        /// Determines whether two specified <see cref="CloudFlareError"/> objects have different values.
        /// </summary>
        /// <param name="left">The first <see cref="CloudFlareError"/> to compare, or <see langword="null"/>.</param>
        /// <param name="right">The second <see cref="CloudFlareError"/> to compare, or <see langword="null"/>.</param>
        /// <returns>
        /// <see langword="true"/> if the value of <paramref name="left"/> is different from the value of
        /// <paramref name="right"/>; otherwise, <see langword="false"/>.
        /// </returns>
        public static bool operator !=(CloudFlareError left, CloudFlareError right) => !Equals(left, right);

        /// <summary>
        /// Indicates whether the current <see cref="CloudFlareError"/> is equal to another object
        /// <see cref="CloudFlareError"/>.
        /// </summary>
        /// <param name="other">An object to compare with this object.</param>
        /// <returns>
        /// <see langword="true"/> if the current object is equal to the <paramref name="other"/> parameter;
        /// otherwise,
        /// <see langword="false"/>.
        /// </returns>
        public bool Equals(CloudFlareError other)
        {
            if (ReferenceEquals(null, other))
                return false;
            if (ReferenceEquals(this, other))
                return true;

            return Code == other.Code;
        }

        /// <summary>
        /// Determines whether the specified object is equal to the current object.
        /// </summary>
        /// <param name="obj">The object to compare with the current object. </param>
        /// <returns>
        /// <see langword="true"/> if the specified object is equal to the current object; otherwise,
        /// <see langword="false"/>.
        /// </returns>
        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj))
                return false;
            if (ReferenceEquals(this, obj))
                return true;
            if (obj.GetType() != GetType())
                return false;

            return Equals((CloudFlareError)obj);
        }

        /// <summary>
        /// Gets a hash code for the current object.
        /// </summary>
        public override int GetHashCode() => Code;
    }
}
