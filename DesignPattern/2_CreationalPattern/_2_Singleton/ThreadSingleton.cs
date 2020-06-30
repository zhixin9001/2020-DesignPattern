using System;
using System.Collections.Generic;
using System.Text;

namespace _2_Singleton
{
    public class ThreadSingleton
    {
        private ThreadSingleton() { }

        [ThreadStatic] //instance只在当前线程内为静态
        private static ThreadSingleton instance;
        public static ThreadSingleton Instance()
        {
            if (instance == null)
            {
                instance = new ThreadSingleton();
            }
            return instance;
        }
    }
}
