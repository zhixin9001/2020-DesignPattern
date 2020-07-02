using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace _3_AbstractFactory.Tests
{
    class Test3
    {
        [Test]
        public void AbstractFactoryWithMapperTest()
        {
            IDictionary<Type, Type> dictionary = new Dictionary<Type, Type>();
            dictionary.Add(typeof(IProductA), typeof(ProductA1));
            dictionary.Add(typeof(IProductB), typeof(ProductB1));

            IAbstractFactoryWithMapper factory = new ConcreteFactory(dictionary);
            IProductA productA = factory.Create<IProductA>();
            IProductB productB = factory.Create<IProductB>();

            Assert.AreEqual(typeof(ProductA1), productA.GetType());
            Assert.AreEqual(typeof(ProductB1), productB.GetType());
        }
    }
}
