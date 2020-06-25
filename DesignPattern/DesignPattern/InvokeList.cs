using System;
using System.Collections.Generic;
using System.Text;

namespace _1_LauguageCharacter
{
    public delegate void StringAssignmentEventHandler();
    public class InvokeList
    {

        private IList<StringAssignmentEventHandler> handlers;
        private string[] message = new string[3];

        public InvokeList()
        {
            handlers = new List<StringAssignmentEventHandler>();
            handlers.Add(AppendHello);
            handlers.Add(AppendComma);
            handlers.Add(AppendWorld);
        }

        public void Invoke()
        {
            foreach (var handler in handlers)
            {
                handler();
            }
        }

        public void MulticastDelegateInvoke()
        {
            StringAssignmentEventHandler handler = null;
            handler += new StringAssignmentEventHandler(AppendHello);
            handler += new StringAssignmentEventHandler(AppendComma);
            //handler += new StringAssignmentEventHandler(AppendWorld);
            //handler += delegate { message[2] = "world"; };
            handler += () => { message[2] = "world"; };
            handler.Invoke();
        }

        public string this[int index]
        {
            get { return message[index]; }
        }

        public void AppendHello()
        {
            message[0] = "hello";
        }
        public void AppendComma()
        {
            message[1] = ",";
        }
        public void AppendWorld()
        {
            message[2] = "world";
        }
    }


}
