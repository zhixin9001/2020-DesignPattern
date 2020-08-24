using System;
using System.Collections.Generic;
using System.Text;

namespace _8_Observer.Event
{
    public class UserEventArgs : EventArgs
    {
        public string Name { get; }
        public UserEventArgs(string name)
        {
            this.Name = name;
        }
    }

    public class User
    {
        public event EventHandler<UserEventArgs> NameChanged;
        private string name;
        public string Name
        {
            get { return name; }
            set
            {
                name = value;
                NameChanged(this, new UserEventArgs(value));
            }
        }
    }

    public class Test
    {
        public static void Entry()
        {
            User user = new User();
            user.NameChanged += (sender, args) =>
            {
                Console.WriteLine(args.Name);
            };
            user.Name = "Andy";
        }
    }
}
