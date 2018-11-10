using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Csla;

namespace MobileKidsIdApp.Models
{
    [Serializable]
    public class FileReference : BaseTypes.BusinessBase<FileReference>
    {
        public static readonly PropertyInfo<int> IdProperty = RegisterProperty<int>(c => c.Id);
        public int Id
        {
            get { return GetProperty(IdProperty); }
            set { LoadProperty(IdProperty, value); }
        }

        public static readonly PropertyInfo<string> ResourceTypeProperty = RegisterProperty<string>(c => c.ResourceType);
        public string ResourceType
        {
            get { return GetProperty(ResourceTypeProperty); }
            private set { LoadProperty(ResourceTypeProperty, value); }
        }

        public static readonly PropertyInfo<string> DescriptionProperty = RegisterProperty<string>(c => c.Description);
        public string Description
        {
            get { return GetProperty(DescriptionProperty); }
            set { SetProperty(DescriptionProperty, value); }
        }

        public static readonly PropertyInfo<string> FileNameProperty = RegisterProperty<string>(c => c.FileName);
        public string FileName
        {
            get { return GetProperty(FileNameProperty); }
            set { SetProperty(FileNameProperty, value); }
        }

        private void Child_Create(int id)
        {
            using (BypassPropertyChecks)
            {
                Id = id;
            }
            base.Child_Create();
        }

        private void Child_Fetch(DataAccess.DataModels.FileReference reference)
        {
            using (BypassPropertyChecks)
            {
                Id = reference.Id;
                ResourceType = reference.ResourceType;
                Description = reference.Description;
                FileName = reference.FileName;
            }
        }

        private void Child_Insert(List<DataAccess.DataModels.FileReference> list)
        {
            Id = 0;
            var parent = (FileReferenceList)Parent;
            if (parent.Count > 0)
            {
                Id = parent.Max(_ => _.Id) + 1;
            }
            Child_Update(list);
        }

        private void Child_Update(List<DataAccess.DataModels.FileReference> list)
        {
            using (BypassPropertyChecks)
            {
                var reference = new DataAccess.DataModels.FileReference();
                reference.Id = Id;
                reference.ResourceType = ResourceType;
                reference.Description = Description;
                reference.FileName = FileName;
            }
        }
    }
}
