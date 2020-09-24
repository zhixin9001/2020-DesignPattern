using System;
using System.Collections.Generic;
using System.Text;

namespace _9_State.B
{
    public interface ILift
    {
        void Open();
        void Close();
        void Run();
        void Stop();
    }

    public class Lift : ILift
    {
        public void Close()
        {
            Console.WriteLine("电梯门关闭");
        }

        public void Open()
        {
            Console.WriteLine("电梯门打开");
        }

        public void Run()
        {
            Console.WriteLine("电梯运行");
        }

        public void Stop()
        {
            Console.WriteLine("电梯停止");
        }
    }

    public abstract class LiftState
    {
        protected Context context;
        public void SetContext(Context context)
        {
            this.context = context;
        }

        public abstract void Open();
        public abstract void Close();
        public abstract void Run();
        public abstract void Stop();
    }
    public class Context
    {
        public readonly static OpenningState openningState = new OpenningState();
        public readonly static ClosingState closingState = new ClosingState();
        public readonly static RunningState runningState = new RunningState();
        public readonly static StoppingState stoppingState = new StoppingState();

        private LiftState liftState;
        public LiftState LiftState
        {
            get
            {
                return liftState;
            }
            set
            {
                liftState = value;
                liftState.SetContext(this);
            }
        }

        public void Open()
        {
            this.liftState.Open();
        }
        public void Close()
        {
            this.liftState.Close();
        }
        public void Run()
        {
            this.liftState.Run();
        }
        public void Stop()
        {
            this.liftState.Stop();
        }
    }

    public class OpenningState : LiftState
    {
        public override void Close()
        {
            base.context.LiftState = Context.closingState;
            base.context.LiftState.Close();
        }

        public override void Open()
        {
            Console.WriteLine("Openning");
        }

        public override void Run()
        {
            //
        }

        public override void Stop()
        {
            //
        }
    }
    public class ClosingState : LiftState
    {
        public override void Close()
        {
            Console.WriteLine("Closing");
        }

        public override void Open()
        {
            base.context.LiftState = Context.openningState;
            base.context.LiftState.Open();
        }

        public override void Run()
        {
            base.context.LiftState = Context.runningState;
            base.context.LiftState.Run();
        }

        public override void Stop()
        {
            base.context.LiftState = Context.stoppingState;
            base.context.LiftState.Stop();
        }
    }

    public class RunningState : LiftState
    {
        public override void Close()
        {
            //
        }

        public override void Open()
        {
            //
        }

        public override void Run()
        {
            Console.WriteLine("Running");
        }

        public override void Stop()
        {
            base.context.LiftState = Context.stoppingState;
            base.context.LiftState.Stop();
        }
    }

    public class StoppingState : LiftState
    {
        public override void Close()
        {
            //
        }

        public override void Open()
        {
            base.context.LiftState = Context.openningState;
            base.context.LiftState.Open();
        }

        public override void Run()
        {
            base.context.LiftState = Context.runningState;
            base.context.LiftState.Run();
        }

        public override void Stop()
        {
            Console.WriteLine("Stopping");
        }
    }
}
