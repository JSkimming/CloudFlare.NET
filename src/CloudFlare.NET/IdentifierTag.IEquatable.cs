namespace CloudFlare.NET
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    /// <summary>
    /// A CloudFlare Identifier.
    /// </summary>
    public partial class IdentifierTag : IEquatable<IdentifierTag>
    {
        /// <summary>
        /// Gets the <see cref="IEqualityComparer{T}"/> for <see cref="IdentifierTag"/> objects.
        /// </summary>
        public static IEqualityComparer<IdentifierTag> Comparer { get; } = new EqualityComparer();

        /// <summary>
        /// Determines whether two specified <see cref="IdentifierTag"/> objects have the same value.
        /// </summary>
        /// <param name="a">The first <see cref="IdentifierTag"/> to compare, or <see langword="null"/>.</param>
        /// <param name="b">The second <see cref="IdentifierTag"/> to compare, or <see langword="null"/>.</param>
        /// <returns>
        /// <see langword="true"/> if the value of <paramref name="a"/> is the same as the value of
        /// <paramref name="b"/>; otherwise, <see langword="false"/>.</returns>
        public static bool operator ==(IdentifierTag a, IdentifierTag b) => Comparer.Equals(a, b);

        /// <summary>
        /// Determines whether two specified <see cref="IdentifierTag"/> objects have different values.
        /// </summary>
        /// <param name="a">The first <see cref="IdentifierTag"/> to compare, or <see langword="null"/>.</param>
        /// <param name="b">The second <see cref="IdentifierTag"/> to compare, or <see langword="null"/>.</param>
        /// <returns>
        /// <see langword="true"/> if the value of <paramref name="a"/> is different from the value of
        /// <paramref name="b"/>; otherwise, <see langword="false"/>.
        /// </returns>
        public static bool operator !=(IdentifierTag a, IdentifierTag b) => !(a == b);

        /// <summary>
        /// Indicates whether the current <see cref="IdentifierTag"/> is equal to another object
        /// <see cref="IdentifierTag"/>.
        /// </summary>
        /// <param name="other">An object to compare with this object.</param>
        /// <returns>
        /// <see langword="true"/> if the current object is equal to the <paramref name="other"/> parameter;
        /// otherwise,
        /// <see langword="false"/>.
        /// </returns>
        public bool Equals(IdentifierTag other)
        {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;
            return string.Equals(_id, other._id);
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
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != GetType()) return false;
            return Equals((IdentifierTag)obj);
        }

        /// <summary>
        /// Gets a hash code for the current object.
        /// </summary>
        /// <returns>
        /// A hash code for the current object.
        /// </returns>
        public override int GetHashCode() => _id.GetHashCode();

        private sealed class EqualityComparer : IEqualityComparer<IdentifierTag>
        {
            public bool Equals(IdentifierTag x, IdentifierTag y)
            {
                if (ReferenceEquals(x, y)) return true;
                if (ReferenceEquals(x, null)) return false;
                if (ReferenceEquals(y, null)) return false;
                if (x.GetType() != y.GetType()) return false;
                return string.Equals(x._id, y._id);
            }

            public int GetHashCode(IdentifierTag obj) => obj._id.GetHashCode();
        }
    }
}
