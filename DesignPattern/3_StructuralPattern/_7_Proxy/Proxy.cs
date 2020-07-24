using System;
using System.Collections.Generic;
using System.Text;

namespace _7_Proxy
{
    public interface ISubject
    {
        string Request();
    }

    public class RealSubject : ISubject
    {
        public string Request()
        {
            return "From real subject";
        }

        //这里使用Singleton的目地是模拟复杂性，比如客户程序并不知道如何使用远端的具体类型
        private static ISubject singleton = new RealSubject();
        private RealSubject() { }

        public static ISubject GetInstance()
        {
            return singleton;
        }
    }

    public class Proxy : ISubject
    {
        public string Request()
        {
            //预处理
            var result= RealSubject.GetInstance().Request();
            //后处理
            return result;
        }
    }
}
