using System;
using System.Collections.Generic;
using System.Text;

namespace _4_Command1
{
    public delegate void VoidHandler();
    public class Receiver1
    {
        public void A()
        {
            Console.WriteLine("A");
        }
    }

    public class Receiver2
    {
        public void B()
        {
            Console.WriteLine("B");
        }
    }

    public class Receiver3
    {
        public void C()
        {
            Console.WriteLine("C");
        }
    }

    public class Invoker
    {
        List<VoidHandler> handlers = new List<VoidHandler>();
        public void AddHandler(VoidHandler handler)
        {
            handlers.Add(handler);
        }

        public void Run()
        {
            foreach (var handler in handlers)
            {
                handler();
            }
        }
    }
}
