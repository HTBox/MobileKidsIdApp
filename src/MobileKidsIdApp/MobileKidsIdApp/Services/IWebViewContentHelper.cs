using System;
using System.Threading.Tasks;

namespace MobileKidsIdApp.Services
{
    public interface IWebViewContentHelper
    { 
        string GetBaseUrl();
        string LoadContentString(string contentResourceName);
    }
}
