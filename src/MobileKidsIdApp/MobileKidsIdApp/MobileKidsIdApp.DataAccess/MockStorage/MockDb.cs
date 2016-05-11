using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MobileKidsIdApp.DataAccess.MockStorage
{
    public static class MockDb
    {
        public static DataModels.ApplicationData ApplicationData = new DataModels.ApplicationData();
        public static DataModels.Family Family = new DataModels.Family();

        static MockDb()
        {
            ApplicationData.UserApplicationProfile = new DataModels.UserApplicationProfile();
            ApplicationData.UserApplicationProfile.FirstUse = DateTime.Now;
            ApplicationData.UserApplicationProfile.LegalAcknowlegeDataSecurityPolicy = false;
            ApplicationData.PermittedLoginIdentities.Add(new DataModels.UserIdentity { ProviderName = "Facebook", UserIdFromProvider = "fb123" });

            var child = new DataModels.Child();
            child.Id = "1";
            child.ChildDetails = new DataModels.ChildDetails
            {
                GivenName = "Amaria", AdditonalName = "Jusui", FamilyName="Johnson",
                Birthday=new DateTime(2010, 4, 20)
            };
            Family.Children.Add(child);

            child = new DataModels.Child();
            child.Id = "2";
            child.ChildDetails = new DataModels.ChildDetails
            {
                GivenName = "Mario",
                AdditonalName = "",
                FamilyName = "Kumarick",
                Birthday = new DateTime(2012, 11, 2)
            };
            Family.Children.Add(child);
        }

    }
}
