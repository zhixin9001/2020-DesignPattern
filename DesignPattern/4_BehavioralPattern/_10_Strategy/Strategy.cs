using System;
using System.Collections.Generic;
using System.Text;

namespace _19_Strategy
{
    public interface Strategy
    {
        double CalcPrice(double originalPrice);
    }

    public class PrimaryStrategy : Strategy
    {
        public double CalcPrice(double originalPrice)
        {
            return originalPrice;
        }
    }

    public class IntermediateStrategy : Strategy
    {
        public double CalcPrice(double originalPrice)
        {
            return originalPrice * 0.9;
        }
    }
    public class AdvancedStrategy : Strategy
    {
        public double CalcPrice(double originalPrice)
        {
            return originalPrice * 0.8;
        }
    }

    public class PriceContext
    {
        public Strategy Strategy { get; set; }

        public double GetPrice(double originalPrice)
        {
            return this.Strategy.CalcPrice(originalPrice);
        }
    }

    public class Test
    {
        public static void Entry()
        {
            Strategy strategy = new PrimaryStrategy();
            PriceContext price = new PriceContext();
            price.Strategy = strategy;

            Console.WriteLine(price.GetPrice(100)); //100

            strategy = new IntermediateStrategy();
            price.Strategy = strategy;
            Console.WriteLine(price.GetPrice(100)); //90

            strategy = new AdvancedStrategy();
            price.Strategy = strategy;
            Console.WriteLine(price.GetPrice(100)); //80
        }
    }
}
