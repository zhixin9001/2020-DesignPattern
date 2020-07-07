using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;

namespace _5_ProtoType
{
    public class SerializeHelper
    {
        public static string BinarySerialize(object graph)
        {
            using (MemoryStream memoryStream = new MemoryStream())
            {
                IFormatter formatter = new BinaryFormatter();
                formatter.Serialize(memoryStream, graph);
                Byte[] arrGraph = memoryStream.ToArray();
                return Convert.ToBase64String(arrGraph);
            }
        }


        public static T BinaryDeSerialize<T>(string graph)
        {
            Byte[] arrGraph = Convert.FromBase64String(graph);
            using (MemoryStream memoryStream = new MemoryStream(arrGraph))
            {
                IFormatter formatter = new BinaryFormatter();
                return (T)formatter.Deserialize(memoryStream);
            }
        }
    }
}
