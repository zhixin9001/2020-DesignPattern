using _1_LauguageCharacter;
using NUnit.Framework;

namespace _1_LanguageCharacter.Tests
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void DelegateSampleTest()
        {
            DelegateSample delegateSample = new DelegateSample();
            System.Threading.Thread.Sleep(3000);
            Assert.AreEqual("method", delegateSample.Output[0]);
            Assert.AreEqual("fast", delegateSample.Output[1]);
            Assert.AreEqual("slow", delegateSample.Output[2]);
        }

        [Test]
        public void InvokeListTest()
        {
            InvokeList list = new InvokeList();
            //list.Invoke();
            list.MulticastDelegateInvoke();
            Assert.AreEqual("hello", list[0]);
        }

        [Test]
        public void RawIteratorTest()
        {
            int count = 0;
            RawIterator iterator = new RawIterator();

            foreach (var item in iterator)
            {
                Assert.AreEqual(count++, item);
            }

            count = 1;

            foreach (var item in iterator.GetRange(1, 3))
            {
                Assert.AreEqual(count++, item);
            }

            foreach (var item in iterator.Greeting)
            {
                var a1 = item;
            }

        }

        [Test]
        public void ObjectBuilderTest()
        {
            var iterator = new ObjectBuilder().BuildUp<RawIterator>();
            int count = 0;

            foreach (var item in iterator)
            {
                Assert.AreEqual(count++, item);
            }
        }
    }
}