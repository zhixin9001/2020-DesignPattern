using System;
using System.Collections.Generic;
using System.Text;

namespace _1_LauguageCharacter
{
    public class Assembler
    {
        private static Dictionary<Type, Type> dictionary = new Dictionary<Type, Type>();

        static Assembler()
        {
            //dictionary.Add()
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
