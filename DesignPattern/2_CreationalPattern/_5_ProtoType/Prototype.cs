using System;

namespace _5_ProtoType
{
    public interface IProtoType
    {
        IProtoType Clone();
        string Name { get; set; }
    }
    public class ConcretePrototype : IProtoType
    {
        public string Name { get; set; }

        public IProtoType Clone()
        {
            return (IProtoType)this.MemberwiseClone();
        }
    }
}
