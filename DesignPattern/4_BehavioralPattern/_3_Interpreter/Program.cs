using System;

namespace _3_Interpreter
{
    class Program
    {
        static void Main(string[] args)
        {
            Calculator calculator = new Calculator();
            
            Console.WriteLine(calculator.Calculate("1+3-9"));
        }
    }
}
