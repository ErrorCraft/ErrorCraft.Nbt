namespace ErrorCraft.Nbt.Tags {
    public interface INumberTag : ITag {
        sbyte GetAsByte();
        short GetAsShort();
        int GetAsInt();
        long GetAsLong();
        float GetAsFloat();
        double GetAsDouble();
    }
}
