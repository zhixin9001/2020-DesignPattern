using System;
using System.Collections.Generic;
using System.Text;

namespace _3_Composite
{
    public interface IMatchRule
    {
        bool IsMatch(Component target);
    }

    //public abstract class Component
    //{
    //    protected IList<Component> children;

    //    public virtual string Name { get; set; }

    //    public virtual void Add(Component child)
    //    {
    //        children.Add(child);
    //    }

    //    public virtual void Remove(Component child)
    //    {
    //        children.Remove(child);
    //    }

    //    public virtual Component this[int index]
    //    {
    //        get { return children[index]; }
    //    }

    //    public virtual IEnumerable<Component> Enumerate(IMatchRule rule)
    //    {
    //        if (rule == null || rule.IsMatch(this))
    //        {
    //            yield return this;
    //        }

    //        if (children != null && children.Count > 0)
    //        {
    //            foreach (Component child in children)
    //            {
    //                foreach (Component item in child.Enumerate(rule))
    //                {
    //                    if (rule == null || rule.IsMatch(item))
    //                    {
    //                        yield return item;
    //                    }
    //                }
    //            }
    //        }
    //    }

    //    public virtual IEnumerable<string> GetNameList(Func<Component, bool> isMatchFunc)
    //    {
    //        if (isMatchFunc == null || isMatchFunc(this))
    //        {
    //            yield return Name;
    //        }

    //        if (children != null && children.Count > 0)
    //        {
    //            foreach (Component child in children)
    //            {
    //                if (isMatchFunc == null || isMatchFunc(child))
    //                {
    //                    foreach (string item in child.GetNameList(isMatchFunc))
    //                    {

    //                        yield return item;
    //                    }
    //                }
    //            }
    //        }
    //    }
    //}

    public class LeafMatchRule : IMatchRule
    {
        public bool IsMatch(Component target)
        {
            if (target == null) return false;
            return target.GetType().IsAssignableFrom(typeof(Leaf)) ? true : false;
        }
    }
}
