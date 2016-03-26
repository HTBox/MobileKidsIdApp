using MCM.KidsIdApp.MobileApp.DataObjects;
using Microsoft.Azure.Mobile.Server.Config;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace MCM.KidsIdApp.MobileApp.Controllers
{
    [MobileAppController]
    public class EmailController : ApiController
    {
        // POST: api/Email
        public void Post([FromBody]EmailRequest value)
        {
        }
    }
}
