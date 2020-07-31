using System;
using System.Collections.Generic;
using System.Text;

namespace _2_TemplateMethod
{
    public abstract class Template
    {
        public abstract void Init();
        public abstract void Start();
        public abstract void End();

        public void Process()
        {
            Init();
            Start();
            End();
        }
    }

    public class ConcreteProcessor1 : Template
    {
        public override void End()
        {
            Console.WriteLine("Process1 End");
        }

        public override void Init()
        {
            Console.WriteLine("Process1 Init");
        }

        public override void Start()
        {
            Console.WriteLine("Process1 Start");
        }
    }

    public class ConcreteProcessor2 : Template
    {
        public override void End()
        {
            Console.WriteLine("Process2 End");
        }

        public override void Init()
        {
            Console.WriteLine("Process2 Init");
        }

        public override void Start()
        {
            Console.WriteLine("Process2 Start");
        }        
    }
}
