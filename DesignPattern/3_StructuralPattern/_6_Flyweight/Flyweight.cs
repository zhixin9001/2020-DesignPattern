using System;
using System.Collections.Generic;
using System.Text;

namespace _6_Flyweight
{
    public abstract class Flyweight
    {
        //内部状态
        public string Instrinsic { get; set; }
        //外部状态
        protected string Extrinsic { get; set; }

        public Flyweight(string extrinsic)
        {
            this.Extrinsic = extrinsic;
        }

        //定义业务操作
        public abstract void Operate(int id);
    }

    public class ConcreteFlyweight : Flyweight
    {
        //接受外部状态
        public ConcreteFlyweight(String extrinsic) : base(extrinsic)
        {
        }

        //根据外部状态进行逻辑处理
        public override void Operate(int id)
        {
            Console.WriteLine("Flyweight:" + id);
        }
    }

    public class UnsharedConcreteFlyweight : Flyweight
    {

        public UnsharedConcreteFlyweight(String extrinsic) : base(extrinsic)
        {
        }

        public override void Operate(int id)
        {
            Console.WriteLine("不共享的Flyweight:" + id);
        }
    }

    public class FlyweightFactory
    {
        //定义一个池容器
        private static Dictionary<String, Flyweight> pool = new Dictionary<String, Flyweight>();

        //享元工厂
        public static Flyweight GetFlyweight(string extrinsic)
        {
            Flyweight flyweight = null;
            if (pool.ContainsKey(extrinsic))
            {
                flyweight = pool[extrinsic];
                Console.Write($"已有{extrinsic} ");
            }
            else
            {
                flyweight = new ConcreteFlyweight(extrinsic);
                pool.Add(extrinsic, flyweight);
                Console.Write($"新建{extrinsic} ");
            }
            return flyweight;
        }
    }
}
