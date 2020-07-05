using NUnit.Framework;

namespace _4_Builder.Tests
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void BuilderTest()
        {
            Director director = new Director();
            CarBuilder carBuilder = new CarBuilder();
            HouseBuilder houseBuilder = new HouseBuilder();

            director.Construct(carBuilder);
            director.Construct(houseBuilder);

            Assert.AreEqual(typeof(Car), carBuilder.Car.GetType());
            Assert.AreEqual(typeof(House), houseBuilder.House.GetType());
        }
    }
}