using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Csla;

namespace MobileKidsIdApp.Models
{
    [Serializable]
    public class DistinguishingFeature : BaseTypes.BusinessBase<DistinguishingFeature>
    {
        public static readonly PropertyInfo<string> IdProperty = RegisterProperty<string>(c => c.Id);
        public string Id
        {
            get { return GetProperty(IdProperty); }
            private set { LoadProperty(IdProperty, value); }
        }

        public static readonly PropertyInfo<string> DescriptionProperty = RegisterProperty<string>(c => c.Description);
        public string Description
        {
            get { return GetProperty(DescriptionProperty); }
            set { SetProperty(DescriptionProperty, value); }
        }

        public static readonly PropertyInfo<FileReference> PhotoReference = RegisterProperty<FileReference>(c => c.FileReference);
        public FileReference FileReference
        {
            get { return GetProperty(PhotoReference); }
            private set { LoadProperty(PhotoReference, value); }
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

        private void Child_Fetch(DataAccess.DataModels.DistinguishingFeature feature)
        {
            using (BypassPropertyChecks)
            {
                Id = feature.Id;
                Description = feature.Description;
                FileReference = DataPortal.FetchChild<FileReference>(feature.FileReference);
            }
        }

        private void Child_Update(List<DataAccess.DataModels.DistinguishingFeature> list)
        {
            var feature = new DataAccess.DataModels.DistinguishingFeature();
            using (BypassPropertyChecks)
            {
                feature.Id = Id;
                feature.Description = Description;
                if (FieldManager.FieldExists(PhotoReference))
                {
                    feature.FileReference = new DataAccess.DataModels.FileReference();
                    DataPortal.UpdateChild(FileReference, feature.FileReference);
                }
            }
            list.Add(feature);
        }
    }
}
