using System;

namespace ErrorCraft.Nbt.Tags {
    /// <summary>
    /// Represents the interface for all numeric NBT types.
    /// </summary>
    public interface INumberTag : ITag, IEquatable<INumberTag> {
        /// <summary>
        /// Gets the value of this number as a signed byte.
        /// </summary>
        /// <returns>The numeric value represented by this object after converting it to a signed byte.</returns>
        sbyte GetAsByte();

        /// <summary>
        /// Gets the value of this number as a signed 16-bit integer.
        /// </summary>
        /// <returns>The numeric value represented by this object after converting it to a signed short.</returns>
        short GetAsShort();

        /// <summary>
        /// Gets the value of this number as a signed 32-bit integer.
        /// </summary>
        /// <returns>The numeric value represented by this object after converting it to a signed integer.</returns>
        int GetAsInt();

        /// <summary>
        /// Gets the value of this number as a signed 64-bit integer.
        /// </summary>
        /// <returns>The numeric value represented by this object after converting it to a signed long.</returns>
        long GetAsLong();

        /// <summary>
        /// Gets the value of this number as an IEEE-754 single-precision floating point number.
        /// </summary>
        /// <returns>The numeric value represented by this object after converting it to a float.</returns>
        float GetAsFloat();

        /// <summary>
        /// Gets the value of this number as an IEEE-754 double-precision floating point number.
        /// </summary>
        /// <returns>The numeric value represented by this object after converting it to a double.</returns>
        double GetAsDouble();
    }
}
