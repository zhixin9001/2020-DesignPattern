using System;
using System.Collections.Generic;
using System.Text;

namespace _1_LauguageCharacter
{
    public interface IObjectBuilder
    {
        T BuildUp<T>(object[] args);
        T BuildUp<T>() where T : new();
        T BuildUp<T>(string typeName);
        T BuildUp<T>(string typeName, object[] args);
    }
    public class ObjectBuilder : IObjectBuilder
    {
        public T BuildUp<T>(object[] args)
        {
            object result = Activator.CreateInstance(typeof(T), args);
            return (T)result;
        }

        public T BuildUp<T>() where T : new()
        {
            return Activator.CreateInstance<T>();
        }

        public T BuildUp<T>(string typeName)
        {
            return (T)Activator.CreateInstance(Type.GetType(typeName));
        }

        public T BuildUp<T>(string typeName, object[] args)
        {
            object result = Activator.CreateInstance(Type.GetType(typeName), args);
            return (T)result;
        }
    }
}
