using System;
using System.Collections.Generic;
using System.Text;

namespace _1_FactoryMethod
{
    public class ProductCollection
    {
        private IList<IProduct> data = new List<IProduct>();
        public void Insert(IProduct item)
        {
            data.Add(item);
        }

        public void Insert(IProduct[] items)
        {
            if (items == null || items.Length <= 0)
            {
                return;
            }
            foreach (var item in items)
            {
                data.Add(item);
            }
        }

        public IProduct[] Data
        {
            get
            {
                if (data == null || data.Count == 0) return null;
                IProduct[] result = new IProduct[data.Count];
                data.CopyTo(result, 0);
                return result;
            }
        }
    }
    public interface IBatchFactory
    {
        ProductCollection Create(int qty);
    }
    public class BatchProductFactoryBase<T> : IBatchFactory where T : IProduct, new()
    {
        public virtual ProductCollection Create(int qty)
        {
            if (qty <= 0) throw new ArgumentException();

            ProductCollection collection = new ProductCollection();
            for (int i = 0; i < qty; i++)
            {
                collection.Insert(new T());
            }
            return collection;
        }
    }

    public class BatchProductAFactory : BatchProductFactoryBase<ProductA> { }

    public class BatchProductBFactory : BatchProductFactoryBase<ProductB> { }

    public abstract class DecisionBase
    {
        protected IBatchFactory factory;
        protected int qty;
        public DecisionBase(IBatchFactory factory, int qty)
        {
            this.factory = factory;
            this.qty = qty;
        }

        public virtual IBatchFactory Factory { get { return factory; } }
        public virtual int Qty { get { return qty; } }
    }

    public abstract class DirectorBase
    {
        protected IList<DecisionBase> decisions = new List<DecisionBase>();

        protected virtual void Insert(DecisionBase decision)
        {
            if (decision == null || decision.Factory == null || decision.Qty < 0)
            {
                throw new ArgumentException();
            }
            decisions.Add(decision);
        }

        public virtual IEnumerable<DecisionBase> Decisions
        {
            get { return decisions; }
        }
    }

    public class ProductADecision : DecisionBase
    {
        public ProductADecision() : base(new BatchProductAFactory(), 2) { }
    }
    public class ProductBDecision : DecisionBase
    {
        public ProductBDecision() : base(new BatchProductBFactory(), 3) { }
    }

    public class ProductDirector : DirectorBase
    {
        public ProductDirector()
        {
            base.Insert(new ProductADecision());
            base.Insert(new ProductBDecision());
        }
    }

    public class Client3
    {
        private DirectorBase director = new ProductDirector();
        public ProductCollection Produce()
        {
            ProductCollection collection = new ProductCollection();
            foreach (DecisionBase decision in director.Decisions)
            {
                ProductCollection products = decision.Factory.Create(decision.Qty);
                foreach (IProduct product in products.Data)
                {
                    collection.Insert(product);
                }
            }
            return collection;
        }
    }
}
