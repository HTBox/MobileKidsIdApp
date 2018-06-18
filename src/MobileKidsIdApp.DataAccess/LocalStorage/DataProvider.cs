namespace MobileKidsIdApp.DataAccess.LocalStorage
{
    public class DataProvider : IDataProvider
    {
        public IApplicationDataProvider GetApplicationDataProvider()
        {
            return new ApplicationDataProvider();
        }

        public IFamilyProvider GetFamilyProvider()
        {
            return new FamilyProvider();
        }
    }
}
