using MCM.KidsIdApp.MobileApp.DataObjects;
using Microsoft.Azure.Mobile.Server.Config;
using SendGrid;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Mail;
using System.Web.Http;
using System.Threading.Tasks;

namespace MCM.KidsIdApp.MobileApp.Controllers
{
    [MobileAppController]
    public class EmailController : ApiController
    {
        // POST: api/Email
        {
            var myMessage = new SendGridMessage();
            myMessage.AddTo(value.EmailAddress.ToString());
            myMessage.From = new MailAddress("dan@dnord.com", "Dan Nordquist");
            myMessage.Subject = "Your Details";
            myMessage.Text = value.Profile.ToString();

            var transportWeb = new Web("key goes here");
            transportWeb.DeliverAsync(myMessage).Wait();
        }
    }
}
