using NUnit.Framework;
using System.Collections.Generic;
using System.Linq;
using System.Threading;

namespace _2_Singleton.Tests
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void SingletonTest()
        {
            var a = Singleton.Instance();
            //var c = new Singleton().Clone();
            var str = System.Text.Json.JsonSerializer.Serialize(a);
            var e = System.Text.Json.JsonSerializer.Deserialize<Singleton>(str);
        }

        [Test]
        public void ThreadSingletonTest()
        {
            int threadCount = 4;
            Thread[] threads = new Thread[threadCount];  //����4���߳�
            for (int i = 0; i < threadCount; i++)
            {
                ThreadStart work = new ThreadStart(new Work().Procedure);
                threads[i] = new Thread(work);
            }

            //ִ���߳�
            foreach (var thread in threads)
            {
                thread.Start();
            }

            Thread.Sleep(10000);
            Assert.AreEqual(threadCount, Work.Log.Distinct().Count());
        }

        [Test]
        public void SingletonNTest()
        {
            SingletonN s1 = SingletonN.GetInstance();
            SingletonN s2 = SingletonN.GetInstance();
            SingletonN s3 = SingletonN.GetInstance();

            Assert.IsNull(s3);

            Assert.AreNotEqual(s1.GetHashCode(), s2.GetHashCode());

            s1.Deactivate();

            s3 = SingletonN.GetInstance();
            Assert.IsNotNull(s3);  

            Assert.IsTrue(s3.GetHashCode() == s1.GetHashCode()
                || s3.GetHashCode() == s2.GetHashCode());
        }
    }

    class Work
    {
        public static IList<int> Log = new List<int>();

        /// <summary>
        /// ÿ���̵߳�ִ�в���
        /// </summary>
        public void Procedure()
        {
            ThreadSingleton s1 = ThreadSingleton.Instance();
            ThreadSingleton s2 = ThreadSingleton.Instance();

            //֤��������������ʵ��
            Assert.IsNotNull(s1);
            Assert.IsNotNull(s2);

            //��֤��ǰ�߳�ִ���������λ�ȡ����ͬһ��ʵ��
            Assert.AreEqual(s1.GetHashCode(), s2.GetHashCode());

            //��¼��ǰ�߳���ʹ�ö����HashCode
            Log.Add(s1.GetHashCode());
        }
    }
}