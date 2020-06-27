using _1_FactoryMethod;
using _1_GenericFactory;
using NUnit.Framework;

namespace _1_Factory.Tests
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void SampleFactoryTest()
        {
            SampleFactory sampleFactory = new SampleFactory();
            IProduct product = sampleFactory.Create(Category.A);
            Assert.AreEqual(product.GetType(), typeof(ConcreteProductA));
        }

        [Test]
        public void Client2Test()
        {
            Assembler assembler = new Assembler();
            Client2 client2 = new Client2(assembler.Create<IFactory>());
            Assert.AreEqual("A", client2.SomeMethod());
        }

        [Test]
        public void BatchFactoryTest()
        {
            Client3 client = new Client3();
            ProductCollection productCollection = client.Produce();
            _1_FactoryMethod.IProduct[] products = productCollection.Data;
            for (int i = 0; i < 2; i++)
            {
                Assert.AreEqual("A", products[i].Name);
            }
            for (int i = 2; i < 5; i++)
            {
                Assert.AreEqual("B", products[i].Name);
            }
        }

        [Test]
        public void CalculateHandlerTest()
        {
            CalculateHandler handler = new CalculateHandlerFactory().Create();

            Assert.AreEqual(1 + 2 + 3, handler(1, 2, 3));
        }
    }
}