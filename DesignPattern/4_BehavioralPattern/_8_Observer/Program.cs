using _8_Observer.A;
using _8_Observer.Event;
using System;

namespace _8_Observer
{
    class Program
    {
        static void Main(string[] args)
        {
            SubjectBase<int> subject = new Subject<int>();
            Observer<int> observer1 = new Observer<int>();
            observer1.State = 10;
            Observer<int> observer2 = new Observer<int>();
            observer2.State = 20;
            subject += observer1;
            subject += observer2;
            subject.Update(30);
            Console.WriteLine($"ob1:{observer1.State}  ob2:{observer2.State}");
            //ob1:30 ob2:30
            subject -= observer2;
            subject.Update(40);
            Console.WriteLine($"ob1:{observer1.State}  ob2:{observer2.State}");
            //ob1:40 ob2:30

            Test.Entry();

        }

    }
}
