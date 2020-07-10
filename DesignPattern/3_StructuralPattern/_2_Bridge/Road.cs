using System;
using System.Collections.Generic;
using System.Text;

namespace _2_Bridge
{
    public interface IVehicle
    {
        string Drive();
    }

    public class Car : IVehicle
    {
        public string Drive()
        {
            return "Car";
        }
    }

    public class Bus : IVehicle
    {
        public string Drive()
        {
            return "Bus";
        }
    }

    public abstract class Road
    {
        protected IVehicle vehicle;
        public Road(IVehicle vehicle)
        {
            this.vehicle = vehicle;
        }

        public abstract string DriveOnRoad();
    }

    public class UnpavedRoad : Road
    {
        public UnpavedRoad(IVehicle vehicle) : base(vehicle) { }
        public override string DriveOnRoad()
        {
            return vehicle.Drive() + " is on Unpaved Road";
        }
    }

    public class CementRoad : Road
    {
        public CementRoad(IVehicle vehicle) : base(vehicle) { }
        public override string DriveOnRoad()
        {
            return vehicle.Drive() + " is on Cement Road";
        }
    }

    public abstract class Speed
    {
        protected Road road;
        public Speed(Road road)
        {
            this.road = road;
        }

        public abstract string DriveWithSpeed();
    }

    public class FastSpeed : Speed
    {
        public FastSpeed(Road road) : base(road) { }
        public override string DriveWithSpeed()
        {
            return road.DriveOnRoad() + ", so Fast!";
        }
    }

    public class SlowSpeed : Speed
    {
        public SlowSpeed(Road road) : base(road) { }
        public override string DriveWithSpeed()
        {
            return road.DriveOnRoad() + ", so Slow!";
        }
    }
}
