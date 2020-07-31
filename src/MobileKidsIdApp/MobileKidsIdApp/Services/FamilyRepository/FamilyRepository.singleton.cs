using System;
using System.Collections.Generic;
using MobileKidsIdApp.Models;

namespace MobileKidsIdApp.Services
{
    public partial class FamilyRepository
    {
        private static Lazy<FamilyRepository> _instance = new Lazy<FamilyRepository>(() => new FamilyRepository());
        public static FamilyRepository Instance => _instance.Value;

        private FamilyRepository()
            => _childCache = new Lazy<List<Child>>(LoadChildren);
    }
}
