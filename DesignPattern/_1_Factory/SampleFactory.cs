using System;
using System.Collections.Generic;
using System.Text;

namespace _1_Factory
{
    public interface IProduct { };
    public class ConcreteProductA : IProduct { }
    public class ConcreteProductB : IProduct { }

    public enum Category { A, B }
    public class SampleFactory
    {
        public IProduct Create(Category category)
        {
            switch (category)
            {
                case Category.A:
                    return new ConcreteProductA();
                case Category.B:
                    return new ConcreteProductB();
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }

    }


}
