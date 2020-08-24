using System;
using System.Collections.Generic;
using System.Text;

namespace _8_Observer.A
{
    public interface IObserver<T>
    {
        void Update(SubjectBase<T> subject);
    }

    public abstract class SubjectBase<T>
    {
        protected IList<IObserver<T>> observers = new List<IObserver<T>>();

        protected T state;
        public virtual T State
        {
            get { return state; }
        }

        //Attach
        public static SubjectBase<T> operator +(SubjectBase<T> subject, IObserver<T> observer)
        {
            subject.observers.Add(observer);
            return subject;
        }

        //Detach
        public static SubjectBase<T> operator -(SubjectBase<T> subject, IObserver<T> observer)
        {
            subject.observers.Remove(observer);
            return subject;
        }

        //更新各观察者
        public virtual void Notify()
        {
            foreach (var observer in observers)
            {
                observer.Update(this);
            }
        }

        public virtual void Update(T state)
        {
            this.state = state;
            Notify();//触发对外通知
        }
    }

    public class Subject<T> : SubjectBase<T> { }

    public class Observer<T> : IObserver<T>
    {
        public T State;
        public void Update(SubjectBase<T> subject)
        {
            this.State = subject.State;
        }
    }
}
