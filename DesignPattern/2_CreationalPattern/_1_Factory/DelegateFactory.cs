using System;
using System.Collections.Generic;
using System.Text;

namespace _1_GenericFactory
{
    public delegate int CalculateHandler(params int[] items);

    public class Calculator
    {
        public int Add(params int[] items)
        {
            int result = 0;
            foreach (var item in items)
            {
                result += item;
            }
            return result;
        }

        public int Multi(params int[] items)
        {
            int result = 1;
            foreach (var item in items)
            {
                result *= item;
            }
            return result;
        }
    }

    public class AddHandlerFactory : IFactory<CalculateHandler>
    {
        public CalculateHandler Create()
        {
            return new Calculator().Add;
        }
    }

    public class MultiHandlerFactory : IFactory<CalculateHandler>
    {
        public CalculateHandler Create()
        {
            return new Calculator().Multi;
        }
    }
}
