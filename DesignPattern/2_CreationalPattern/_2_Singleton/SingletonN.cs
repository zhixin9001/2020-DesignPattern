using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _2_Singleton
{
    public enum Status
    {
        Busy,
        Free
    }

    public interface IWorkItem
    {
        Status Status { get; set; }
        void Deactivate();
    }

    public class WorkItemCollection<T> where T : class, IWorkItem
    {
        protected int max;
        protected IList<T> items = new List<T>();
        public WorkItemCollection(int max)
        {
            this.max = max;
        }

        public virtual T GetWorkItem()
        {
            if (items == null || items.Count == 0) return null;

            var freeItem = items.FirstOrDefault(a => a.Status == Status.Free);
            return freeItem != null ? freeItem : null;
        }

        public virtual bool CouldAddNewInstance
        {
            get { return items.Count < max; }
        }
        public virtual void Add(T item)
        {
            if (item == null) throw new ArgumentNullException();
            if (!CouldAddNewInstance) throw new ArgumentOutOfRangeException();

            item.Status = Status.Free;
            items.Add(item);
        }
    }

    public class SingletonN : IWorkItem
    {
        private const int MaxInstance = 2;
        private Status status = Status.Free;
        public Status Status
        {
            get { return this.status; }
            set { this.status = value; }
        }

        public void Deactivate()
        {
            this.status = Status.Free;
        }
        private SingletonN() { }

        private static WorkItemCollection<SingletonN> collection = new WorkItemCollection<SingletonN>(MaxInstance);

        public static SingletonN GetInstance()
        {
            SingletonN instance = collection.GetWorkItem();
            if (instance == null)
            {
                if (!collection.CouldAddNewInstance)
                {
                    return null;
                }
                else
                {
                    instance = new SingletonN();
                    collection.Add(instance);
                }
            }
            instance.status = Status.Busy;
            return instance;
        }
    }
}
