using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using MobileKidsIdApp.Models;

namespace MobileKidsIdApp.ViewModels
{
    public class PhysicalDetailsViewModel : CurrentChildViewModel
    {
        private Child _child;
        public Child Child
        {
            get => _child;
            set => SetProperty(ref _child, value);
        }

        private GenderValue _selectedGender;
        public GenderValue SelectedGender
        {
            get => _selectedGender;
            set
            {
                SetProperty(ref _selectedGender, value);
                if (value.Value != Child.Gender)
                {
                    Child.Gender = value.Value;
                }
            }
        }

        public ObservableCollection<GenderValue> GenderValues { get; } = new ObservableCollection<GenderValue>();

        public PhysicalDetailsViewModel()
        { 
            Child = CurrentChild;
            GenderValue.GenerateAllValues().ForEach(_ => GenderValues.Add(_));
            SelectedGender = GenderValues.Single(_ => _.Value == Child.Gender);
        }

        public class GenderValue
        {
            public string Name { get; set; }
            public Gender Value { get; set; }

            public static List<GenderValue> GenerateAllValues() => new List<GenderValue>()
            {
                new GenderValue() { Name = null, Value = Gender.NotSelected },
                new GenderValue() { Name = "Male", Value = Gender.Male },
                new GenderValue() { Name = "Female", Value = Gender.Female },
            };
        }
    }
}
