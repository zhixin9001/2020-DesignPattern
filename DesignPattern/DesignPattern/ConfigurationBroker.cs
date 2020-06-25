using System;
using System.Collections.Generic;
using System.Text;

namespace _1_LauguageCharacter
{
    public interface IConfigurationSource
    {
        void Load();
    }
    public static class ConfigurationBroker
    {
        private static readonly GenericCache<Type, object> cache;

        static ConfigurationBroker()
        {
            
        }
    }
}
