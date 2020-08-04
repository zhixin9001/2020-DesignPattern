using System;
using System.Collections.Generic;
using System.Text;

namespace _3_Interpreter1
{
    public interface IExpression
    {
        //解析公式和数值，其中var中的key-val是参数-具体数字
        int Interpreter(Dictionary<string, int> var);
    }

    public class VarExpression : IExpression
    {
        private string key;
        public VarExpression(string key)
        {
            this.key = key;
        }

        public int Interpreter(Dictionary<string, int> var)
        {
            return var[this.key];
        }
    }

    public abstract class SymbolExpression : IExpression
    {
        protected IExpression left;
        protected IExpression right;
        public SymbolExpression(IExpression left, IExpression right)
        {
            this.left = left;
            this.right = right;
        }

        public abstract int Interpreter(Dictionary<string, int> var);
    }

    //加法解析器
    public class AddExpression : SymbolExpression
    {
        public AddExpression(IExpression left, IExpression right) : base(left, right) { }
        public override int Interpreter(Dictionary<string, int> var)
        {
            return this.left.Interpreter(var) + this.right.Interpreter(var);
        }
    }

    //减法解析器
    public class SubExpression : SymbolExpression
    {
        public SubExpression(IExpression left, IExpression right) : base(left, right) { }
        public override int Interpreter(Dictionary<string, int> var)
        {
            return this.left.Interpreter(var) - this.right.Interpreter(var);
        }
    }

    public class Calculator
    {
        private IExpression expression;

        public Calculator(string exp)
        {
            //定义一个栈，安排运算的先后顺序
            Stack<IExpression> stack = new Stack<IExpression>();

            //表达式拆分为字符数组
            char[] charArray = exp.ToCharArray();

            //构建表达式树
            IExpression left = null;
            IExpression right = null;
            for (int i = 0; i < charArray.Length; i++)
            {
                switch (charArray[i])
                {
                    case '+':
                        left = stack.Pop();
                        right = new VarExpression(charArray[++i].ToString());
                        stack.Push(new AddExpression(left, right));
                        break;
                    case '-':
                        left = stack.Pop();
                        right = new VarExpression(charArray[++i].ToString());
                        stack.Push(new SubExpression(left, right));
                        break;
                    default: //公式中的变量
                        stack.Push(new VarExpression(charArray[i].ToString()));
                        break;
                }
            }
            this.expression = stack.Pop();
        }

        public int Run(Dictionary<string, int> var)
        {
            return this.expression.Interpreter(var);
        }
    }
}
