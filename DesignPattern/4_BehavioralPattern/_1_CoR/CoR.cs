using System;
using System.Collections.Generic;
using System.Text;

namespace _1_CoR
{
    public enum PurchaseType
    {
        Internal, //内部认购价格
        Discount, //折扣价
        Regular, //平价
        Mail //邮购价
    }

    //请求对象
    public class Request
    {
        public double Price { get; set; }
        public PurchaseType Type { get; set; }
        public Request(double price, PurchaseType type)
        {
            this.Price = price;
            this.Type = type;
        }
    }

    //抽象的操作对象
    public interface IHandler
    {
        void HandleRequest(Request request);
        IHandler Next { get; set; }
        PurchaseType Type { get; set; }
    }

    public abstract class HandlerBase : IHandler
    {
        public IHandler Successor { get; set; }
        public PurchaseType Type { get; set; }
        public HandlerBase(PurchaseType type, IHandler successor)
        {
            this.Type = type;
            this.Successor = successor;
        }

        public HandlerBase(PurchaseType type) : this(type, null) { }

        //需要具体IHandler类型处理的内容
        public abstract void Process(Request request);
        //在当前结点处理，还是传递给下一个结点
        public virtual void HandleRequest(Request request)
        {
            if (request == null) return;
            if (request.Type == Type)
            {
                Process(request);
            }
            else if (Successor != null)
            {
                Successor.HandleRequest(request);
            }
        }

        public class InternalHandler : HandlerBase
        {
            public InternalHandler() : base(PurchaseType.Internal) { }
            public override void Process(Request request)
            {
                request.Price *= 0.6;
            }
        }

        public class MailHandler : HandlerBase
        {
            public MailHandler() : base(PurchaseType.Mail) { }
            public override void Process(Request request)
            {
                request.Price *= 1.3;
            }
        }

        public class DiscountHandler : HandlerBase
        {
            public DiscountHandler() : base(PurchaseType.Discount) { }
            public override void Process(Request request)
            {
                request.Price *= 0.9;
            }
        }

        public class RegularHandler : HandlerBase
        {
            public RegularHandler() : base(PurchaseType.Regular) { }
            public override void Process(Request request) { }
        }
    }
}
