using System;
using System.Collections.Generic;
using System.Text;

namespace _9_State.A
{
    public interface IState
    {
        void DoAction(Context context);
    }

    public class Context
    {
        public IState State { get; set; }
    }

    public class StartState : IState
    {
        public void DoAction(Context context)
        {
            Console.WriteLine("On Start State");
            context.State = this;
        }
    }

    public class StopState : IState
    {
        public void DoAction(Context context)
        {
            Console.WriteLine("On Stop State");
            context.State = this;
        }
    }

    public class Test
    {
        public static void Entry()
        {
            Context context = new Context();
            IState state = new StartState();
            state.DoAction(context);

            state = new StopState();
            state.DoAction(context);
        }
    }
}
