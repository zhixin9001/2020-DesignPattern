using NUnit.Framework;

namespace _1_Adapter.Tests
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void NAdapterTest()
        {
            IDatabaseAdapter adapter = new OracleAdapter();
            Assert.AreEqual("oracle", adapter.ProviderName);
        }
    }
}