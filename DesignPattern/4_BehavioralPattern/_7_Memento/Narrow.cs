using System;
using System.Collections.Generic;
using System.Text;

namespace _7_Memento.Narrow
{
    public interface IMemento { }

    public class Originator
    {
        private class Memento : IMemento
        {
            public string State { get; set; }

            public Memento(string state)
            {
                this.State = state;
            }
        }
        private string state;
        public string State
        {
            get
            {
                return state;
            }
            set
            {
                state = value;
                Console.WriteLine(state);
            }
        }

        public IMemento CreateMemento()
        {
            return new Memento(state);
        }
        //将发起人恢复到备忘录对象所记载的状态
        public void RestoreMemento(IMemento memento)
        {
            if (memento == null)
            {
                return;
            }
            this.State = (memento as Memento).State;
        }
    }

    public class Caretaker
    {

        private IMemento memento;
        //备忘录的取值方法
        public IMemento RetrieveMemento()
        {
            return this.memento;
        }
        //备忘录的赋值方法
        public void SaveMemento(IMemento memento)
        {
            this.memento = memento;
        }
    }
    public class MultiCaretaker
    {
        private Stack<IMemento> mementos = new Stack<IMemento>();
        //备忘录的取值方法
        public IMemento RetrieveMemento()
        {
            if (mementos.Count == 0)
            {
                return null;
            }
            return mementos.Pop();
        }
        //备忘录的赋值方法
        public void SaveMemento(IMemento memento)
        {
            mementos.Push(memento);
        }
    }

    public class NarrowClient
    {
        public static void Entry()
        {
            Originator originator = new Originator();
            originator.State = "ON";
            Caretaker caretaker = new Caretaker();
            caretaker.SaveMemento(originator.CreateMemento());
            originator.State = "OFF";
            originator.RestoreMemento(caretaker.RetrieveMemento());
        }
    }

    public class MultiCheckpoint
    {
        public static void Entry()
        {
            Originator originator = new Originator();
            originator.State = "ON";
            MultiCaretaker caretaker = new MultiCaretaker();
            caretaker.SaveMemento(originator.CreateMemento());
            originator.State = "Volume 1";
            caretaker.SaveMemento(originator.CreateMemento());
            originator.State = "Volume 2";
            caretaker.SaveMemento(originator.CreateMemento());
            originator.State = "Volume 3";
            caretaker.SaveMemento(originator.CreateMemento());
            originator.State = "OFF";
            originator.RestoreMemento(caretaker.RetrieveMemento());
            originator.RestoreMemento(caretaker.RetrieveMemento());
            originator.RestoreMemento(caretaker.RetrieveMemento());
            originator.RestoreMemento(caretaker.RetrieveMemento());
        }
    }
}
