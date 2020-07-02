using System;
using System.Collections.Generic;
using System.Text;

namespace _3_AbstractFactory.IAbstractFactoryWithTypeMapper
{
    public abstract class TypeMapperBase : Dictionary<Type, Type>
    {

    }

    public class TypeMapperDictionary : Dictionary<Type, TypeMapperBase>
    {

    }

    public interface IAbstractFactory
    {
        T Create<T>();
    }

    public interface IAbstractFactoryWithTypeMapper : IAbstractFactory
    {
        TypeMapperBase Mapper { get; set; }
    }

    public abstract class AbstractFactoryBase : IAbstractFactoryWithTypeMapper
    {
        protected TypeMapperBase mapper;
        public TypeMapperBase Mapper
        {
            get { return mapper; }
            set { mapper = value; }
        }
        public virtual T Create<T>()
        {
            Type targetType = mapper[typeof(T)];
            return (T)Activator.CreateInstance(targetType);
        }
    }

    public interface IProductXA { }
    public interface IProductXB { }
    public interface IProductYA { }
    public interface IProductYB { }
    public interface IProductYC { }
    public class ProductXA1 : IProductXA { }
    public class ProductXA2 : IProductXA { }
    public class ProductXA3 : IProductXA { }
    public class ProductXB1 : IProductXB { }
    public class ProductYA1 : IProductYA { }
    public class ProductYB1 : IProductYB { }
    public class ProductYB2 : IProductYB { }
    public class ProductYC1 : IProductYC { }
    public class ConcreteXTypeMapper : TypeMapperBase
    {
        public ConcreteXTypeMapper()
        {
            base.Add(typeof(IProductXA), typeof(ProductXA2));
            base.Add(typeof(IProductXB), typeof(ProductXB1));
        }
    }

    public class ConcreteYTypeMapper : TypeMapperBase
    {
        public ConcreteYTypeMapper()
        {
            base.Add(typeof(IProductYA), typeof(ProductYA1));
            base.Add(typeof(IProductYB), typeof(ProductYB1));
            base.Add(typeof(IProductYC), typeof(ProductYC1));
        }
    }

    public class ConcreteFactoryX : AbstractFactoryBase { }
    public class ConcreteFactoryY : AbstractFactoryBase { }

    /// <summary>
    /// /////////////////////
    /// </summary>
    public static class AssemblyMechanism
    {
        private static TypeMapperDictionary dictionary = new TypeMapperDictionary();

        static AssemblyMechanism()
        {
            dictionary.Add(typeof(ConcreteFactoryX), new ConcreteXTypeMapper());
            dictionary.Add(typeof(ConcreteFactoryY), new ConcreteYTypeMapper());
        }

        public static void Assembly(IAbstractFactoryWithTypeMapper factory)
        {
            TypeMapperBase mapper = dictionary[factory.GetType()];
            factory.Mapper = mapper;
        }
    }
}