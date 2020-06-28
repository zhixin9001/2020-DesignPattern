using System;
using System.Collections.Generic;
using System.Text;

namespace _1_Factory
{
    //产品接口
    public interface IProduct { };
    //具体产品
    public class ConcreteProductA : IProduct { }
    public class ConcreteProductB : IProduct { }

    public enum Category { A, B }
    //简单工厂
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
