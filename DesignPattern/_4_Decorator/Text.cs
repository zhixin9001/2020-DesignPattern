using System;
using System.Collections.Generic;
using System.Text;

namespace _4_Decorator1
{
    public interface IText
    {
        string Content { get; }
    }

    public class TextObject : IText, IDecorator
    {
        public string Content { get { return "hello"; } }
    }

    public interface IDecorator : IText { }

    public abstract class DecoratorBase : IDecorator
    {
        protected IText target;

        public abstract string Content { get; }

        public DecoratorBase(IText target)
        {
            this.target = target;
        }
    }


    public class BoldDecorator : DecoratorBase
    {
        public BoldDecorator(IText target) : base(target) { }

        public override string Content => ChangeToBoldFont(target.Content);

        public string ChangeToBoldFont(string content)
        {
            return $"<b>{content}</b>";
        }
    }

    public class ColorDecorator : DecoratorBase
    {
        public ColorDecorator(IText target) : base(target) { }

        public override string Content => AddColorTag(target.Content);

        public string AddColorTag(string content)
        {
            return $"<color>{content}</color>";
        }
    }

    public class BlockAllDecorator : DecoratorBase
    {
        public BlockAllDecorator(IText target) : base(target) { }

        public override string Content => string.Empty;
    }
}
