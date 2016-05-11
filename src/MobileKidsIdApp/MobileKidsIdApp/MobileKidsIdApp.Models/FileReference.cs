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
        public static readonly PropertyInfo<string> IdProperty = RegisterProperty<string>(c => c.Id);
        public string Id
        {
            get { return GetProperty(IdProperty); }
            private set { LoadProperty(IdProperty, value); }
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

        public static int LastId = -1;
        protected override void Child_Create()
        {
            using (BypassPropertyChecks)
            {
                LastId++;
                Id = LastId.ToString();
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

        private void Child_Update(DataAccess.DataModels.FileReference reference)
        {
            using (BypassPropertyChecks)
            {
                reference.Id = Id;
                reference.ResourceType = ResourceType;
                reference.Description = Description;
                reference.FileName = FileName;
            }
        }

        private void Child_Update(List<DataAccess.DataModels.FileReference> list)
        {
            var reference = new DataAccess.DataModels.FileReference();
            Child_Update(reference);
            list.Add(reference);
        }
    }
}
