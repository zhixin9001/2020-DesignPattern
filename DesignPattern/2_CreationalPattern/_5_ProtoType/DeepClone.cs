using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;

namespace _5_ProtoType
{
    [Serializable]
    public class DeepClone : IProtoType
    {
        [NonSerialized]
        public List<string> Users = new List<string>();
        public string Name { get; set; }

        public IProtoType Clone()
        {
            string graph = SerializeHelper.BinarySerialize(this);
            return SerializeHelper.BinaryDeSerialize<IProtoType>(graph);
        }
    }
}
