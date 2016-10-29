using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MobileKidsIdApp.Services
{
  public interface IAuthenticate
  {
    Task<Models.AppIdentity> Authenticate(LoginProviders provider);
  }

    public enum LoginProviders
    {
        Google,
        Microsoft,
        Facebook
#if DEBUG
        , Test
#endif
    }
}
