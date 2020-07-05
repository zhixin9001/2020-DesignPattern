using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace _4_Builder.Tests
{
    class DelegateBuilderTest1
    {
        [Test]
        public void DelegateBuilderTest()
        {
            IBuilder<Car> builder = new ConcreteCarBuilder();
            var product = builder.BuildUp();
            Assert.AreEqual(typeof(Car), product.GetType());

            IBuilder<House> builder1 = new ConcreteHouseBuilder();
            var product1 = builder1.BuildUp();
            Assert.AreEqual(typeof(House), product1.GetType());
        }
    }
}
