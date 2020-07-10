using System;
using System.Collections.Generic;
using System.Text;

namespace _2_Bridge
{
    public interface IRestaurant
    {
        string Taste();
    }

    public class XiaoNanGuo : IRestaurant
    {
        public string Taste()
        {
            return "红烧肉比较好吃";
        }
    }

    public class WaiPoJia : IRestaurant
    {
        public string Taste()
        {
            return "红烧肉比较一般";
        }
    }

    public abstract class AbstractCityArea
    {
        protected IRestaurant restaurant;

        public AbstractCityArea(IRestaurant restaurant)
        {
            this.restaurant = restaurant;
        }

        public abstract void commentTaste();
    }

    public class ShanxiRestaurant : AbstractCityArea
    {
        public ShanxiRestaurant(IRestaurant restaurant) : base(restaurant) { }
        public override void commentTaste()
        {
            Console.WriteLine("陕西的" + base.restaurant.Taste());
        }
    }

    public class ChongqiRestaurant : AbstractCityArea
    {
        public ChongqiRestaurant(IRestaurant restaurant) : base(restaurant) { }
        public override void commentTaste()
        {
            Console.WriteLine("重庆的" + base.restaurant.Taste());
        }
    }
}