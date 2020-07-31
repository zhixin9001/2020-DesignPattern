using System;
using System.Collections.Generic;
using System.Text;

namespace _4_Command
{
    public interface ICommand
    {
        void Execute();
        Receiver Receiver { set; }
    }

    public class Receiver
    {
        public string Name { get; private set; }
        public string Address { get; private set; }

        public void SetName()
        {
            this.Name = "Name";
        }

        public void SetAddress()
        {
            this.Name = "Address";
        }
    }

    public abstract class CommandBase : ICommand
    {
        public Receiver Receiver { set; get; }

        public abstract void Execute();
    }

    public class SetAddressCommand : CommandBase
    {
        public override void Execute()
        {
            base.Receiver.SetName();
        }
    }

    public class SetNameCommand : CommandBase
    {
        public override void Execute()
        {
            base.Receiver.SetAddress();
        }
    }

    public class Invoker
    {
        private IList<ICommand> commands = new List<ICommand>();
        public void AddCommand(ICommand command)
        {
            commands.Add(command);
        }

        public void Run()
        {
            foreach (ICommand command in commands)
            {
                command.Execute();
            }
        }
    }
}
