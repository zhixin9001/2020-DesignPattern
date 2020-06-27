using _1_FactoryMethod;
using System;
using System.Collections.Generic;
using System.Text;

namespace _1_Factory
{
    public class Assembler
    {
        private static Dictionary<Type, Type> dictionary = new Dictionary<Type, Type>();

        static Assembler()
        {
            dictionary.Add(typeof(IFactory), typeof(FactoryA));
            dictionary.Add(typeof(IProduct), typeof(ProductB));
        }

        public object Create(Type type)
        {
            if (type == null || !dictionary.ContainsKey(type))
            {
                throw new ArgumentNullException();
            }

            Type targetType = dictionary[type];
            return Activator.CreateInstance(targetType);
        }

        public T Create<T>()
        {
            return (T)Create(typeof(T));
        }
    }
}
