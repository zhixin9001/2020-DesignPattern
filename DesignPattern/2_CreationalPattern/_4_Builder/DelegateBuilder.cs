using System;
using System.Collections.Generic;
using System.Text;

namespace _4_Builder
{
    public interface IBuilder<T> where T : class, new()
    {
        T BuildUp();
    }

    public abstract class BuilderBase<T> : IBuilder<T> where T : class, new()
    {
        protected IList<Action> steps = new List<Action>();

        protected T product = new T();
        public virtual T BuildUp()
        {
            foreach (Action step in steps)
            {
                step();
            }
            return product;
        }
    }

    public class ConcreteCarBuilder : BuilderBase<Car>
    {
        public ConcreteCarBuilder() : base()
        {
            steps.Add(product.AddEngine);
            steps.Add(product.AddWheel);
            steps.Add(product.AddBody);
        }
    }

    public class ConcreteHouseBuilder : BuilderBase<House>
    {
        public ConcreteHouseBuilder() : base()
        {
            steps.Add(product.AddWallAndFloor);
            steps.Add(product.AddCeiling);
            steps.Add(product.AddWindowAndDoor);
        }
    }
}
