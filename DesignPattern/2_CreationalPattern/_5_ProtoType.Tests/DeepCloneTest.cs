using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace _5_ProtoType.Tests
{
    public class DeepCloneTest1
    {
        [Test]
        public void DeepCloneTest()
        {
            DeepClone sample = new DeepClone();
            sample.Name = "A";
            sample.Users.Add("1");
            DeepClone cloned = (DeepClone)sample.Clone();

            Assert.AreEqual(sample.Name, cloned.Name);
            cloned.Users.Add("2");

            Assert.AreNotEqual(sample.Users.Count, cloned.Users.Count);
        }
    }
}
