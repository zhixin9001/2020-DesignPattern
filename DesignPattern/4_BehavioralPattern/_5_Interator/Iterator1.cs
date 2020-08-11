using System;
using System.Collections.Generic;
using System.Text;

namespace _15_Iterator2
{
    //迭代器接口
    public interface IIterator<T>
    {
        T Next();
        bool HasNext();
    }
    //具体迭代器
    public class ConcreteIterator<T> : IIterator<T>
    {
        private ConcreteAggretate<T> Aggretate; //成员变量，关联关系
        private int cursor = 0;
        public ConcreteIterator(ConcreteAggretate<T> agg)
        {
            this.Aggretate = agg;
        }
        public bool HasNext()
        {
            return !(cursor >= Aggretate.Size);
        }

        public T Next()
        {
            if (HasNext())
            {
                return Aggretate.GetELement(cursor++);
            }
            else
            {
                return default(T);
            }

        }
    }
    //聚合接口
    public interface IAggretate<T>
    {
        public void Add(T obj);
        public void Remove(T obj);
        public int Size { get; }
        public T GetELement(int index);
        public IIterator<T> GetIterator();
    }
    //具体聚合
    public class ConcreteAggretate<T> : IAggretate<T>
    {
        private List<T> list = new List<T>();  //
        public void Add(T obj)
        {
            list.Add(obj);
        }

        public void Remove(T obj)
        {
            list.Remove(obj);
        }

        public IIterator<T> GetIterator()
        {
            return new ConcreteIterator<T>(this);  //在局部方法中new实例，属依赖关系
        }

        public int Size
        {
            get
            {
                return list.Count;
            }
        }

        public T GetELement(int index)
        {
            return list[index];
        }
    }
}
