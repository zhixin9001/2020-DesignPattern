using NUnit.Framework;

namespace _5_ProtoType.Tests
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void PrototypeTest()
        {
            IProtoType sample = new ConcretePrototype();
            sample.Name = "A";

            IProtoType cloned = sample.Clone();

            Assert.AreEqual(sample.Name, cloned.Name);
            cloned.Name = "B";

            Assert.AreNotEqual(sample.Name, cloned.Name);
        }
    }
}