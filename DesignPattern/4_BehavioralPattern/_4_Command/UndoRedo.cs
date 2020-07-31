using System;
using System.Collections.Generic;
using System.Text;

namespace _4_Command2
{
    public interface ICommand
    {
        public void Execute();
        public void Undo();
    }

    public class SQLExcute
    {
        public void InsertInto(string id)
        {
            Console.WriteLine("插入一条数据，id:" + id);
        }

        public void Delete(string id)
        {
            Console.WriteLine("删除一条数据，id:" + id);
        }
    }

    public class InsertIntoCommand : ICommand
    {
        private SQLExcute sqlExcute;
        private string id;
        public InsertIntoCommand(SQLExcute sqlExcute, string id)
        {
            this.sqlExcute = sqlExcute;
            this.id = id;
        }

        public void Execute()
        {
            sqlExcute.InsertInto(id);
        }

        public void Undo()
        {
            sqlExcute.Delete(id);
        }
    }

    public class CommandManager
    {
        private Stack<ICommand> undoStacks = new Stack<ICommand>();
        private Stack<ICommand> redoStacks = new Stack<ICommand>();

        public void Execute(ICommand command)
        {
            command.Execute();
            undoStacks.Push(command);
            if (redoStacks.Count > 0)
            {
                redoStacks.Clear();
            }
        }

        public void Undo()
        {
            if (undoStacks.Count > 0)
            {
                ICommand pop = undoStacks.Pop();
                pop.Undo();
                redoStacks.Push(pop);
            }
        }

        public void Redo()
        {
            if (redoStacks.Count > 0)
            {
                ICommand pop = redoStacks.Pop();
                pop.Execute();
            }
        }
    }
}
