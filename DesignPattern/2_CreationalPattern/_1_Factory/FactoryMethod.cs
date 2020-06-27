using System;
using System.Collections.Generic;
using System.Text;

namespace _1_FactoryMethod
{
    //抽象产品类型
    public interface IProduct
    {
        string Name { get; } //抽象产品所必须具有的特征
    }

    public class ProductA : IProduct
    {
        public string Name { get { return "A"; } }
    }
    public class ProductB : IProduct
    {
        public string Name { get { return "B"; } }
    }

    public interface IFactory
    {
        IProduct Create(); //抽象的工厂描述
    }
    public class FactoryA : IFactory
    {
        public IProduct Create()
        {
            return new ProductA();
        }
    }

    public class FactoryB : IFactory
    {
        public IProduct Create()
        {
            return new ProductB();
        }
    }

    public class Client1
    {
        public void SomeMethod()
        {
            IFactory factory = new FactoryA();
            IProduct product = factory.Create();
        }
    }

    public class Client2
    {
        private IFactory factory;
        public Client2(IFactory factory)
        {
            this.factory = factory;
        }
        public string SomeMethod()
        {
            IProduct product = factory.Create();
            return product.Name;
        }
    }
}
