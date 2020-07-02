using System;
using System.Collections.Generic;
using System.Text;

namespace _3_AbstractFactory.AsyncFactory
{
    //回调委托
    //public delegate void Action<T>(T newProduct);
    //抽象结构部分
    public interface IProduct { };
    public interface IFactory
    {
        IProduct Create();
    }

    public interface IFactoryWithNotifier : IFactory
    {
        void Create(Action<IProduct> callBack);
    }

    //实体结构部分
    public class ConcreteProduct : IProduct { }
    public class ConcreteFactory : IFactoryWithNotifier
    {
        public IProduct Create() //同步构造
        {
            return new ConcreteProduct();
        }

        public void Create(Action<IProduct> callBack)  //异步构造
        {
            IProduct product = Create();
            callBack(product);
        }
    }

    //为方便单元测试构造的订阅者
    public class Subscriber
    {
        private IProduct product;
        public void SetProduct(IProduct product)
        {
            this.product = product;
        }

        public IProduct GetProduct()
        {
            return product;
        }
    }
}
