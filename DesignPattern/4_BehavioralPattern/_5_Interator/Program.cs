using _15_Iterator2;
using System;

namespace _5_Interator
{
    class Program
    {
        static void Main(string[] args)
        {
            //IAggretate<int> aggretate = new ConcreteAggretate<int>();
            //aggretate.Add(9);
            //aggretate.Add(8);
            //aggretate.Add(7);
            //IIterator<int> iterator = aggretate.GetIterator();
            //while (iterator.HasNext())
            //{
            //    Console.WriteLine(iterator.Next());
            //}

            var aggretate = new _5_Iterator.ConcreteAggretate<int>();
            aggretate.Add(9);
            aggretate.Add(8);
            aggretate.Add(7);

            foreach (var item in aggretate)
            {
                Console.WriteLine(item);
            }

        }
    }
}
