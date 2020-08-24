using System;
using System.Collections.Generic;
using System.Text;

namespace _16_Mediator1
{
    public interface IMediator<T>
    {
        void Operation();
        void Register(IColleague<T> provider, params IColleague<T>[] consumers);
    }

    public interface IColleague<T>
    {
        T Data { get; set; }
        IMediator<T> Mediator { get; set; }
    }

    public abstract class ColleagueBase<T> : IColleague<T>
    {
        public virtual T Data { get; set; }
        private IMediator<T> mediator;
        public virtual IMediator<T> Mediator
        {
            get
            {
                return mediator;
            }
            set
            {
                mediator = value;
            }
        }
    }

    public class Mediator<T> : IMediator<T>
    {
        private IColleague<T> provider;
        private IList<IColleague<T>> consumers;
        public void Operation()
        {
            if (provider != null && consumers != null && consumers.Count > 0)
            {
                foreach (var item in consumers)
                {
                    item.Data = provider.Data;
                }
            }
        }

        public void Register(IColleague<T> provider, params IColleague<T>[] consumers)
        {
            this.provider = provider;
            if (consumers != null && consumers.Length > 0)
            {
                this.consumers = new List<IColleague<T>>(consumers);
            }
        }
    }

    public class ConcreteColleagueA : ColleagueBase<int>
    {
        public override int Data
        {
            get => base.Data;
            set
            {
                base.Data = value;
                base.Mediator.Operation();
            }
        }
    }

    public class ConcreteColleagueB : ColleagueBase<int>
    {
    }

    public class ConcreteColleagueC : ColleagueBase<int>
    {
    }

    public class Test
    {
        public static void Entry()
        {
            Mediator<int> mA2BC = new Mediator<int>();
            ConcreteColleagueA a = new ConcreteColleagueA();
            ConcreteColleagueB b = new ConcreteColleagueB();
            ConcreteColleagueC c = new ConcreteColleagueC();

            a.Mediator = b.Mediator = c.Mediator = mA2BC;
            mA2BC.Register(a, b, c);
            a.Data = 20;
            Console.WriteLine($"a:{a.Data},b:{b.Data}, c:{c.Data}");

            mA2BC.Register(a, b);
            a.Data = 30;
            Console.WriteLine($"a:{a.Data},b:{b.Data}, c:{c.Data}");
        }
    }
}