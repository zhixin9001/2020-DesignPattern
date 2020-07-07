using System;
using System.Collections.Generic;
using System.Text;

namespace _1_Adapter
{
    public class ClassAdapter : ITarget
    {
        private Adaptee adaptee;

        public void Request()
        {
            adaptee.SpecifiedRequest();
        }
    }
}
