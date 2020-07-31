using System;
using System.Collections.Generic;
using System.Text;

namespace _3_Interpreter
{
    public class Context
    {
        public int Value;
        public char Operator;
    }

    public interface IExpression
    {
        void Evaluate(Context context);
    }

    public class Operator : IExpression
    {
        private char op;
        public Operator(char op)
        {
            this.op = op;
        }

        public virtual void Evaluate(Context context)
        {
            context.Operator = op;
        }
    }

    public class Operand : IExpression
    {
        int num;
        public Operand(int num)
        {
            this.num = num;
        }

        public virtual void Evaluate(Context context)
        {
            switch (context.Operator)
            {
                case '\0': context.Value = num; break;
                case '+': context.Value += num; break;
                case '-': context.Value -= num; break;
            }
        }
    }

    public class Calculator
    {
        public int Calculate(string expression)
        {
            Context context = new Context();
            IList<IExpression> tree = new List<IExpression>();

            char[] elements = expression.ToCharArray();
            foreach (char c in elements)
            {
                if (c == '+' || c == '-')
                {
                    tree.Add(new Operator(c));
                }
                else
                {
                    tree.Add(new Operand((int)(c - 48)));
                }
            }

            foreach (IExpression exp in tree)
            {
                exp.Evaluate(context);
            }

            return context.Value;

        }
    }
}
