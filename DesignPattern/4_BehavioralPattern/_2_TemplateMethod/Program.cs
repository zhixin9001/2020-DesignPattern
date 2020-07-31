using System;

namespace _2_TemplateMethod
{
    class Program
    {
        static void Main(string[] args)
        {
            Template template = new ConcreteProcessor1();
            template.Process();

            template = new ConcreteProcessor2();
            template.Process();
        }
    }
}
