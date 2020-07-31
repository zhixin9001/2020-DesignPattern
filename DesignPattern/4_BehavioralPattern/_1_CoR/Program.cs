using System;
using static _1_CoR.HandlerBase;

namespace _1_CoR
{
    class Program
    {
        static void Main(string[] args)
        {
            IHandler handler1 = new InternalHandler();
            IHandler handler2 = new DiscountHandler();
            IHandler handler3 = new MailHandler();
            IHandler handler4 = new RegularHandler();

            handler1.Next = handler3;
            handler3.Next = handler2;
            handler2.Next = handler4;

            IHandler head = handler1;
            Request request = new Request(20, PurchaseType.Mail);
            head.HandleRequest(request);
            Console.Write(request.Price); //26

            //将MailHandler短路
            handler1.Next = handler1.Next.Next;
            request = new Request(20, PurchaseType.Mail);
            head.HandleRequest(request);
            Console.Write(request.Price); //20

        }
    }
}
