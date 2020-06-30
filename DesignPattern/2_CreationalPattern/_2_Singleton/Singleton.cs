using System;
using System.Collections.Generic;
using System.Text;

namespace _2_Singleton
{
    //public class Singleton
    //{
    //    private Singleton() { }
    //    private static Singleton instance;
    //    public static Singleton Instance()
    //    {
    //        if (instance == null)
    //        {
    //            instance = new Singleton();
    //        }
    //        return instance;
    //    }
    //}


    public class Singleton : BaseEntity
    {
        private static  Singleton instance;
        public static Singleton Instance()
        {
            if (instance == null)
            {
                lock (typeof(Singleton))
                {
                    if (instance == null)
                    {
                        instance = new Singleton();
                    }
                }
            }
            return instance;
        }
    }

    public class BaseEntity : ICloneable
    {
        public object Clone()
        {
            return this.MemberwiseClone();
        }
    }
}
