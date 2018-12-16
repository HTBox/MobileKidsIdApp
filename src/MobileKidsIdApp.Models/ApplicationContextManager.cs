using System;
using System.Collections.Generic;
using System.Security.Principal;
using System.Text;
using System.Threading;

namespace MobileKidsIdApp.Models
{
    /// <summary>
    /// This is a temporary workaround because for some reason 
    /// the Csla.Xaml.ApplicationContextManager isn't available and
    /// so isn't being used.
    /// </summary>
    /// <remarks>
    /// Should be addressed in the future by 
    /// https://github.com/MarimerLLC/csla/issues/980
    /// </remarks>
    public class ApplicationContextManager : Csla.ApplicationContext.ApplicationContextManager
    {
        private static IPrincipal _principal;

        /// <summary>
        /// Gets the current principal.
        /// </summary>
        /// <returns></returns>
        public override IPrincipal GetUser()
        {
            IPrincipal current;
            if (_principal == null)
                _principal = new Csla.Security.UnauthenticatedPrincipal();
            current = _principal;
            return current;
        }

        /// <summary>
        /// Sets the current principal.
        /// </summary>
        /// <param name="principal">Principal object.</param>
        public override void SetUser(IPrincipal principal)
        {
            _principal = principal;
        }
    }
}
