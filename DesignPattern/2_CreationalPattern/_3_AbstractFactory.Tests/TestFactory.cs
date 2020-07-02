using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace _3_AbstractFactory.AsyncFactory
{
    public class TestFactory
    {
        [Test]
        public void AsyncFactoryTest()
        {
            IFactoryWithNotifier factoryWithNotifier = new ConcreteFactory();
            Subscriber subscribe = new Subscriber();
            Action<IProduct> callback = new Action<IProduct>(subscribe.SetProduct);

            Assert.IsNull(subscribe.GetProduct());
            factoryWithNotifier.Create(callback);
            Assert.IsNotNull(subscribe.GetProduct());
        }
    }
}
