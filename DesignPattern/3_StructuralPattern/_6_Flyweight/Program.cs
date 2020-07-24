using System;

namespace _6_Flyweight
{
    class Program
    {
        static void Main(string[] args)
        {
            int id = 0;
            Flyweight flyweightA = FlyweightFactory.GetFlyweight("A");
            flyweightA.Operate(++id);
            Flyweight flyweightB = FlyweightFactory.GetFlyweight("B");
            flyweightB.Operate(++id);
            Flyweight flyweightA1 = FlyweightFactory.GetFlyweight("A");
            flyweightA1.Operate(++id);

            Flyweight flyweightX = new UnsharedConcreteFlyweight("X");
            flyweightX.Operate(++id);
        }
    }
}
