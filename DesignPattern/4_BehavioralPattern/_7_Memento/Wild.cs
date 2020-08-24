using System;
using System.Collections.Generic;
using System.Text;

namespace _7_Memento.Wild
{
    public class Memento
    {
        public string State { get; set; }

        public Memento(string state)
        {
            this.State = state;
        }
    }
    public class Originator
    {
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

        public Memento CreateMemento()
        {
            return new Memento(state);
        }
        //将发起人恢复到备忘录对象所记载的状态
        public void RestoreMemento(Memento memento)
        {
            this.State = memento.State;
        }
    }

    public class Caretaker
    {

        private Memento memento;
        //备忘录的取值方法
        public Memento RetrieveMemento()
        {
            return this.memento;
        }
        //备忘录的赋值方法
        public void SaveMemento(Memento memento)
        {
            this.memento = memento;
        }
    }

    public class WildClient
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
}
