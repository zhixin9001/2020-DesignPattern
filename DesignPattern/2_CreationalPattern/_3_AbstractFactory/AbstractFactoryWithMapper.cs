using System;
using System.Collections.Generic;
using System.Text;

namespace _3_AbstractFactory
{
    public interface IAbstractFactoryWithMapper
    {
        T Create<T>() where T : class;
    }

    public abstract class AbstractFactoryBase : IAbstractFactoryWithMapper
    {
        protected IDictionary<Type, Type> mapper;
        public AbstractFactoryBase(IDictionary<Type, Type> mapper)
        {
            this.mapper = mapper;
        }

        public virtual T Create<T>() where T : class
        {
            if (mapper == null || mapper.Count == 0 || !mapper.ContainsKey(typeof(T)))
            {
                throw new ArgumentNullException();
            }
            Type targetType = mapper[typeof(T)];
            return (T)Activator.CreateInstance(targetType);
        }
    }

    public class ConcreteFactory : AbstractFactoryBase
    {
        public ConcreteFactory(IDictionary<Type, Type> mapper) : base(mapper) { }
    }
}
