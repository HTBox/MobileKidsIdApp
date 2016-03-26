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
using System.Configuration;

namespace MCM.KidsIdApp.MobileApp.Controllers
{
    [MobileAppController]
    public class EmailController : ApiController
    {
        // POST: api/Email
        public HttpResponseMessage Post([FromBody]dynamic value)
        {
            var myMessage = new SendGridMessage();
            myMessage.AddTo(value.emailAddress.ToString());
            myMessage.From = new MailAddress(
                ConfigurationManager.AppSettings["EmailFromAddress"],
                ConfigurationManager.AppSettings["EmailFromName"]
                );
            myMessage.Subject = "Your KidsID Profile Details";
            myMessage.Text = GetFormattedBody(value.profile);

            var transportWeb = new Web(ConfigurationManager.AppSettings["SendGridApiKey"]);
            transportWeb.DeliverAsync(myMessage);
            //this seems awfully happy-path to me, y'know
            HttpResponseMessage m = new HttpResponseMessage(HttpStatusCode.OK);
            return m;            
        }

        private string GetFormattedBody(dynamic profile)
        {
            string body = "You are recieving this email because a user of the KidsID app is sending you profile information for a child." + Environment.NewLine + Environment.NewLine;
            body += "Profile details have been attached, but only those that you selected." + Environment.NewLine + Environment.NewLine;
            body += "Authorities can use this data to communicate or create alerts for a child. Forward this email to authorities if necessary." + Environment.NewLine + Environment.NewLine;
            body += profile.ToString() + Environment.NewLine + Environment.NewLine;
            return body;
        }
    }
}
