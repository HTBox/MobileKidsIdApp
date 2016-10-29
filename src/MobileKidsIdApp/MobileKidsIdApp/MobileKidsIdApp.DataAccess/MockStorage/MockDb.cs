using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MobileKidsIdApp.DataAccess.MockStorage
{
    public static class MockDb
    {
        private static DataModels.ApplicationData ApplicationData = new DataModels.ApplicationData();
        private static DataModels.Family Family = new DataModels.Family();
        public static string ApplicationDataFile;
        public static string FamilyFile;
        private static bool _isInitialized;

        public static async Task Init()
        {
            if (!_isInitialized)
                _isInitialized = true;
            else
                return;

            ApplicationData.UserApplicationProfile = new DataModels.UserApplicationProfile();
            ApplicationData.UserApplicationProfile.FirstUse = DateTime.Now;
            ApplicationData.UserApplicationProfile.LegalAcknowlegeDataSecurityPolicy = false;
            ApplicationData.PermittedLoginIdentities.Add(new DataModels.UserIdentity { ProviderName = "Facebook", UserIdFromProvider = "fb123" });
            var provider = new ApplicationDataProvider();
            await provider.Save(ApplicationData);

            var child = new DataModels.Child();
            child.Id = 1;
            child.ChildDetails = new DataModels.ChildDetails
            {
                GivenName = "Amaria", AdditonalName = "Jusui", FamilyName="Johnson",
                Birthday=new DateTime(2010, 4, 20),
            };
            child.PhysicalDetails = new DataModels.PhysicalDetails { MeasurementDate = DateTime.Now };
            child.Checklist = new DataModels.PreparationChecklist();

            Family.Children.Add(child);

            child = new DataModels.Child();
            child.Id = 2;
            child.ChildDetails = new DataModels.ChildDetails
            {
                GivenName = "Mario",
                AdditonalName = "",
                FamilyName = "Kumarick",
                Birthday = new DateTime(2012, 11, 2)
            };
            child.PhysicalDetails = new DataModels.PhysicalDetails { MeasurementDate = DateTime.Now };
            child.Checklist = new DataModels.PreparationChecklist();

            Family.Children.Add(child);

            var familyProvider = new FamilyProvider();
            await familyProvider.Save(Family);
        }

    }
}
