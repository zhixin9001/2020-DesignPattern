using System;
using System.Collections.Generic;

namespace _3_Interpreter1
{
    class Program
    {
        static void Main(string[] args)
        {
            //Calculator calculator = new Calculator();

            //Console.WriteLine(calculator.Calculate("1+3-9"));


            string exp = "a+b-c";
            Dictionary<string, int> var = new Dictionary<string, int>();
            var.Add("a", 3);
            var.Add("b", 5);
            var.Add("c", 7);

            Calculator calculator = new Calculator(exp);
            Console.WriteLine(calculator.Run(var));
        }
    }
}
