using NUnit.Framework;
using System;
using System.Collections;
using System.Collections.Generic;

namespace _3_AbstractFactory.Tests
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void AbstractFactoryTest()
        {
            IAbstractFactory factory = new ConcreteFactory1();
            IProductA productA = factory.CreateProductA();
            IProductB productB = factory.CreateProductB();

            Assert.AreEqual(typeof(ProductA1), productA.GetType());
            Assert.AreEqual(typeof(ProductB1), productB.GetType());
        }

        [Test]
        public void Factory3Test()
        {
            IAbstractFactory factory = new ConcreteFactory3(typeof(ProductA2), typeof(ProductB2));

            IProductA productA = factory.CreateProductA();
            IProductB productB = factory.CreateProductB();

            Assert.AreEqual(typeof(ProductA2), productA.GetType());
            Assert.AreEqual(typeof(ProductB2), productB.GetType());
        }
    }
}