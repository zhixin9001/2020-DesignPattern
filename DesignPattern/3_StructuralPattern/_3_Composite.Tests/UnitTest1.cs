using NUnit.Framework;

namespace _3_Composite.Tests
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void ComponentTest()
        {
            ComponentFactory factory = new ComponentFactory();
            Component corporate = factory.Create<Composite>("corporate");
            factory.Create<Leaf>(corporate, "president");
            factory.Create<Leaf>(corporate, "vice president");
            Component sales = factory.Create<Composite>(corporate, "sales");
            factory.Create<Leaf>(sales, "joe");
            factory.Create<Leaf>(sales, "bob");
            //var names = corporate.GetNameList();
            //var names = corporate.GetNameList();
            //var names = corporate.GetNameList(new LeafMatchRule());
            var names = corporate.GetNameList(new LeafMatchRule().IsMatch);

        }
    }
}