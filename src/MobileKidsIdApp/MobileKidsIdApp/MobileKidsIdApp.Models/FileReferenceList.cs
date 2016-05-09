using System;
using Csla;
using System.Collections.Generic;

namespace MobileKidsIdApp.Models
{
    [Serializable]
    public class FileReferenceList : BusinessListBase<FileReferenceList, FileReference>
    {
        private void Child_Fetch(List<DataAccess.DataModels.FileReference> list)
        {
            foreach (var item in list)
                Add(DataPortal.FetchChild<FileReference>(item));
        }
    }
}