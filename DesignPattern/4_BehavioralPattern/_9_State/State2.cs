using System;
using System.Collections.Generic;
using System.Text;

namespace _9_State
{
    public abstract class State
    {
        protected Context context;

        public void SetState(Context context)
        {
            this.context = context;
        }

        public abstract void Handle1();
        public abstract void Handle2();
    }

    public class ConcreteState1 : State
    {
        public override void Handle1()
        {
            //本状态下必须处理的逻辑
        }

        public override void Handle2()
        {
            base.context.CurrentState = Context.STATE2;
            base.context.Handle2();
        }
    }

    public class ConcreteState2 : State
    {
        public override void Handle1()
        {
            base.context.CurrentState = Context.STATE1;
            base.context.Handle1();
        }

        public override void Handle2()
        {
            //本状态下必须处理的逻辑
        }
    }

    public class Context
    {
        public readonly static State STATE1 = new ConcreteState1();
        public readonly static State STATE2 = new ConcreteState2();

        private State currentState;
        public State CurrentState
        {
            get
            {
                return currentState;
            }
            set
            {
                this.currentState = value;
                this.currentState.SetState(this);
            }
        }

        public void Handle1()
        {
            this.CurrentState.Handle1();
        }

        public void Handle2()
        {
            this.CurrentState.Handle2();
        }
    }

    public class Test
    {
        public static void Entry()
        {
            Context context = new Context();
            context.CurrentState = Context.STATE1;
            context.Handle1();
            context.Handle2();
        }
    }
}
