using _4_Command2;
using System;

namespace _4_Command
{
    class Program
    {
        static void Main(string[] args)
        {
            Receiver receiver = new Receiver();
            ICommand command1 = new SetNameCommand();
            ICommand command2 = new SetAddressCommand();
            command1.Receiver = receiver;
            command2.Receiver = receiver;
            Invoker invoker = new Invoker();
            invoker.AddCommand(command1);
            invoker.AddCommand(command2);

            CommandManager manager = new CommandManager();
            SQLExcute excute = new SQLExcute();
            InsertIntoCommand command1 = new InsertIntoCommand(excute, "1");
            InsertIntoCommand command2 = new InsertIntoCommand(excute, "2");
            manager.Execute(command1);
            manager.Execute(command2);

            Console.WriteLine("undo------------");
            manager.Undo();
            manager.Undo();
            Console.WriteLine("redo------------");
            manager.Redo();
            manager.Redo();
        }
    }
}
