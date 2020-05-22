namespace MobileKidsIdApp.Platform
{
    public interface IWebViewContentHelper
    { 
        string GetBaseUrl();
        string LoadContentString(string contentResourceName);
    }
}
