using System;

namespace ErrorCraft.Nbt.Tags {
    public interface INumberTag : ITag, IEquatable<INumberTag> {
        sbyte GetAsByte();
        short GetAsShort();
        int GetAsInt();
        long GetAsLong();
        float GetAsFloat();
        double GetAsDouble();
    }
}
