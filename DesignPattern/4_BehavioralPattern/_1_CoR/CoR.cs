using System;
using System.Collections.Generic;
using System.Text;

namespace _1_CoR
{
    public enum PurchaseType
    {
        Internal,
        Discount,
        Regular,
        Mail
    }

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

    public interface IHandler
    {
        void HandleRequest(Request request);
        IHandler Successor { get; set; }
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

        public abstract void Process(Request request);
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
