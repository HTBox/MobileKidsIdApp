using Csla.Xaml;
using MobileKidsIdApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MobileKidsIdApp.ViewModels
{
    public class PreparationChecklist : ViewModelBase<Models.PreparationChecklist>
    {
        public PreparationChecklist(Models.PreparationChecklist preparationChecklist)
        {
            Model = preparationChecklist;
        }
    }
}
