using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;

namespace _4_Decorator.Undo
{
    public interface IState
    {
        bool Equals(IState newState);
    }
    public interface IText
    {
        string Content { get; }
    }

    public class TextObject : IText
    {
        public string Content { get { return "hello"; } }

    }

    public interface IDecorator : IText
    {
        IState State { get; set; }
        void Refresh<T>(IState newState) where T : IDecorator;
    }

    public abstract class DecoratorBase : IDecorator
    {
        protected IText target;
        public DecoratorBase(IText target)
        {
            this.target = target;
        }
        public abstract string Content { get; }
        public IState State { get; set; }

        public virtual void Refresh<T>(IState newState) where T : IDecorator
        {
            if (this.GetType() == typeof(T))
            {
                if (newState == null)
                {
                    State = null;
                }
                if (State != null && !State.Equals(newState))
                {
                    State = newState;
                }
            }
            if (target != null && typeof(IDecorator).IsAssignableFrom(target.GetType()))
            {
                ((IDecorator)target).Refresh<T>(newState);
            }
        }

    }

    public class BoldState : IState
    {
        public bool IsBold;
        public bool Equals(IState newState)
        {
            if (newState == null)
            {
                return false;
            }
            return ((BoldState)newState).IsBold == IsBold;
        }
    }

    public class ColorState : IState
    {
        public Color Color = Color.Black;
        public bool Equals(IState newState)
        {
            if (newState == null)
            {
                return false;
            }
            return ((ColorState)newState).Color == Color;
        }
    }

    public class BoldDecorator : DecoratorBase
    {
        public BoldDecorator(IText target) : base(target)
        {
            base.State = new BoldState();
        }

        public override string Content
        {
            get
            {
                if (((BoldState)State).IsBold)
                {
                    return $"<b>{base.target.Content}</b>";
                }
                else
                {
                    return base.target.Content;
                }
            }
        }
    }

    public class ColorDecorator : DecoratorBase
    {
        public ColorDecorator(IText target) : base(target)
        {
            base.State = new ColorState();
        }

        public override string Content
        {
            get
            {
                if (State != null)
                {
                    string colorName = (((ColorState)State).Color).Name;
                    return $"<{colorName}>{base.target.Content}</{colorName}>";
                }
                else
                {
                    return base.target.Content;
                }      
            }
        }
    }
}
