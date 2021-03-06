﻿using System;
using System.Collections.Generic;
using System.Text;

namespace _2_Bridge
{
    public interface IImpl
    {
        void OperationImpl();
    }

    public interface IAbstraction
    {
        IImpl Implementor { get; set; }
        void Operation();
    }
    public class ConcreteImplementatorA : IImpl
    {
        public void OperationImpl()
        {
            ...
        }
    }

    public class ConcreteImplementatorB : IImpl
    {
        public void OperationImpl()
        {
            ...
        }
    }

    public class RefinedAbstration : IAbstraction
    {
        public IImpl Implementor { get; set; }

        public void Operation()
        {
            Implementor.OperationImpl();
        }
    }
}
