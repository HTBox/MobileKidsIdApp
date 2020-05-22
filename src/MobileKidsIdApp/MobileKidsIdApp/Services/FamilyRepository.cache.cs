using System;
using System.Collections.Generic;
using MobileKidsIdApp.Models;

namespace MobileKidsIdApp.Services
{
    // TODO: add calls to save from views
    public partial class FamilyRepository
    {
        private Lazy<List<Child>> _childCache;

        public List<Child> Children => _childCache.Value;
        public Child CurrentChild { get; private set; }

        public void SetCurrentChild(Child child) => CurrentChild = child;
        public void ClearCurrentChild() => CurrentChild = null;
        public bool HasCurrentChild => CurrentChild != null;

        public FamilyRepository()
            => _childCache = new Lazy<List<Child>>(LoadChildren);

        public void AddChild(Child child)
        {
            Children.Add(child);
            SaveChildren();
        }

        public void RemoveChild(Child child)
        {
            Children.Remove(child);
            SaveChildren();
        }

        public void SaveChildren() => StoreChildren();
    }
}
