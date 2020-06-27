using System;
using System.Collections.Generic;
using System.Text;

namespace _1_GenericFactory
{
    public interface IProduct
    {
        string Name { get; }
    }

    public class ProductA : IProduct
    {
        public string Name { get { return "A"; } }
    }
    public class ProductB : IProduct
    {
        public string Name { get { return "B"; } }
    }

    public interface IFactory<T>
    {
        T Create(); //抽象的工厂描述
    }

    public abstract class FactoryBase<T> : IFactory<T> where T : new()
    {
        public T Create()
        {
            return new T();
        }
    }

    public class ProductAFactory : FactoryBase<ProductA> { }
    public class ProductBFactory : FactoryBase<ProductB> { }
}
