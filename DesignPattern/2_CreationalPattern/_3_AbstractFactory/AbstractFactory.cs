using System;

namespace _3_AbstractFactory
{
    public interface IProductA { };
    public interface IProductB { };

    public interface IAbstractFactory
    {
        IProductA CreateProductA();
        IProductB CreateProductB();
    }

    public class ProductA1 : IProductA { }
    public class ProductA2 : IProductA { }
    public class ProductB1 : IProductB { }
    public class ProductB2 : IProductB { }

    public class ConcreteFactory1 : IAbstractFactory
    {
        public IProductA CreateProductA()
        {
            return new ProductA1();
        }

        public IProductB CreateProductB()
        {
            return new ProductB1();
        }
    }

    public class ConcreteFactory2 : IAbstractFactory
    {
        public IProductA CreateProductA()
        {
            return new ProductA2();
        }

        public IProductB CreateProductB()
        {
            return new ProductB2();
        }
    }

    public class ConcreteFactory3 : IAbstractFactory
    {
        private Type typeA;
        private Type typeB;

        public ConcreteFactory3(Type typeA, Type typeB)
        {
            this.typeA = typeA;
            this.typeB = typeB;
        }

        public IProductA CreateProductA()
        {
            return (IProductA)Activator.CreateInstance(typeA);
        }

        public IProductB CreateProductB()
        {
            return (IProductB)Activator.CreateInstance(typeB);
        }
    }
}
