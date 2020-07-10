using System;
using System.Collections.Generic;

namespace _3_Composite
{
    public abstract class Component
    {
        protected IList<Component> children;

        public virtual string Name { get; set; }

        public virtual void Add(Component child)
        {
            children.Add(child);
        }

        public virtual void Remove(Component child)
        {
            children.Remove(child);
        }

        public virtual Component this[int index]
        {
            get { return children[index]; }
        }

        public virtual IEnumerable<string> GetNameList()
        {
            yield return Name;
            if (children != null && children.Count > 0)
            {
                foreach (Component child in children)
                {
                    foreach (string item in child.GetNameList())
                    {
                        yield return item;
                    }
                }
            }
        }
    }

    public class Leaf : Component
    {
        public override void Add(Component child)
        {
            throw new NotSupportedException();
        }
        public override void Remove(Component child)
        {
            throw new NotSupportedException();
        }
        public override Component this[int index] => throw new NotSupportedException();
    }

    public class Composite : Component
    {
        public Composite()
        {
            base.children = new List<Component>();
        }
    }

    public class ComponentFactory
    {
        public Component Create<T>(string name) where T : Component, new()
        {
            T instance = new T();
            instance.Name = name;
            return instance;
        }

        public Component Create<T>(Component parent, string name) where T : Component, new()
        {
            if (parent == null) throw new ArgumentNullException();
            if (!(parent is Composite)) throw new Exception("non-composite type");
            Component instance = Create<T>(name);
            parent.Add(instance);
            return instance;
        }
    }
}
