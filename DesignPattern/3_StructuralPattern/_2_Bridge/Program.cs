using System;

namespace _2_Bridge
{
    class Program
    {
        static void Main(string[] args)
        {
            //RefinedAbstration refinedAbstration = new RefinedAbstration();
            //IImpl implementatorA = new ConcreteImplementatorA();
            //IImpl implementatorB = new ConcreteImplementatorB();

            //refinedAbstration.Implementor = implementatorA;
            //refinedAbstration.Operation();

            //refinedAbstration.Implementor = implementatorB;
            //refinedAbstration.Operation();

            //IRestaurant restaurant = new XiaoNanGuo();
            //AbstractCityArea city = new ShanxiRestaurant(restaurant);
            //city.commentTaste();

            //restaurant = new WaiPoJia();
            //city = new ChongqiRestaurant(restaurant);
            //city.commentTaste();

            IVehicle vehicle = new Car();
            Road road = new CementRoad(vehicle);
            Console.WriteLine(road.DriveOnRoad());
            // Car is on Cement Road
            Speed speed = new FastSpeed(road);
            Console.WriteLine(speed.DriveWithSpeed());
            // Car is on Cement Road, so Fast!
        }
    }
}
