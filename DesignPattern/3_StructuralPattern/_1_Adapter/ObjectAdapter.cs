using System;

namespace _1_Adapter
{
    public interface ITarget
    {
        void Request();
    }
    public class Adaptee
    {
        public void SpecifiedRequest() { }
    }

    public class ObjectAdapter : Adaptee, ITarget
    {
        public void Request()
        {
            //其他处理
            //...
            base.SpecifiedRequest();
        }
    }
}
