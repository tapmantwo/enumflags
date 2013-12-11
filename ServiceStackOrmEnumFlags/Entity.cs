namespace ServiceStackOrmEnumFlags
{
    using System;

    [Flags]
    public enum EntityFlags
    {
        FlagOne = 0x0,
        FlagTwo = 0x01,
        FlagThree = 0x02
    }

    public class Entity
    {
        public int Id { get; set; }
        public EntityFlags Flags { get; set; }
    }
}