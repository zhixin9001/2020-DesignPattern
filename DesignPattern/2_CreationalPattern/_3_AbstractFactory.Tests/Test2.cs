using NUnit.Framework;

namespace _3_AbstractFactory.IAbstractFactoryWithTypeMapper
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void Test1()
        {
            IAbstractFactoryWithTypeMapper factory = new ConcreteFactoryX();
            AssemblyMechanism.Assembly(factory);

            IProductXB productXB = factory.Create<IProductXB>();

            Assert.AreEqual(typeof(ProductXB1), productXB.GetType());

            factory = new ConcreteFactoryY();
            AssemblyMechanism.Assembly(factory);
            IProductYC productYC = factory.Create<IProductYC>();
            Assert.AreEqual(typeof(ProductYC1), productYC.GetType());
        }
    }
}