namespace CloudFlare.NET
{
    using System;
    using System.Collections.Generic;
    using System.Diagnostics;
    using System.Linq;

    /// <summary>
    /// A CloudFlare Identifier.
    /// </summary>
    [DebuggerDisplay("{_id}")]
    public partial class IdentifierTag
    {
        /// <summary>
        /// The maximum length of an <see cref="IdentifierTag"/>.
        /// </summary>
        public const int MaxLength = 32;

        private readonly string _id;

        /// <summary>
        /// Initializes a new instance of the <see cref="IdentifierTag"/> class.
        /// </summary>
        /// <param name="id">The unique identifier of an entity in CloudFlare.</param>
        public IdentifierTag(string id)
        {
            if (id == null)
                throw new ArgumentNullException(nameof(id));

            if (string.IsNullOrEmpty(id))
            {
                throw new ArgumentException(
                    $"The { nameof(id) } cannot be empty.",
                    nameof(id));
            }

            if (id.Length > MaxLength)
            {
                throw new ArgumentException(
                    $"The { nameof(id) } '{id}' is of length {id.Length} but cannot be greater than {MaxLength}.",
                    nameof(id));
            }

            _id = id;
        }

        /// <summary>
        /// The implicit operator to create a new <see cref="IdentifierTag"/> from a string.
        /// </summary>
        /// <param name="id">The unique identifier of an entity in CloudFlare.</param>
        public static implicit operator IdentifierTag(string id) => new IdentifierTag(id);

        /// <summary>
        /// The implicit operator to return the string representation of an <see cref="IdentifierTag"/>.
        /// </summary>
        /// <param name="identifier">The unique identifier of an entity in CloudFlare.</param>
        public static implicit operator string(IdentifierTag identifier)
        {
            if (identifier == null)
                throw new ArgumentNullException(nameof(identifier));

            return identifier._id;
        }

        /// <summary>
        /// Returns a string that represents the current object.
        /// </summary>
        /// <returns>
        /// A string that represents the current object.
        /// </returns>
        public override string ToString() => _id;
    }
}
