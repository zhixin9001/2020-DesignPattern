using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace _5_Iterator
{
    public class ConcreteAggretate<T> : IEnumerable<T>
    {
        private List<T> list = new List<T>();
        public void Add(T obj)
        {
            list.Add(obj);
        }

        public void Remove(T obj)
        {
            list.Remove(obj);
        }

        public IEnumerator<T> GetEnumerator()
        {
            foreach (var item in list)
            {
                yield return item;
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            throw new NotImplementedException();
        }
    }

}
