using iTextSharp.text;
using iTextSharp.text.html.simpleparser;
using iTextSharp.text.pdf;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.IO;
using System.Web;
using System.Web.Http;

namespace MobileKidsId.PdfGenerationAppService.Controllers
{
    public class JsonToPdfController : ApiController
    {
        public FileStreamResult GetMissingChildProfilePdf(string missingChildJson)
        {
            if(!string.IsNullOrWhiteSpace(missingChildJson))
            {
            missingChildJson = @"{
                            'FirstName': 'Jane',
                            'LastName': 'Doe',
                            'Sex': 'Female',
                            'Description': 'Dark hair, 5 foot dix inches'  
                            }";
            }                     


            string htmlContent = PopulateMissingChildProfileBody(JsonConvert.DeserializeObject<Models.ProfileModel>(missingChildJson));
            return RenderPdf(htmlContent);

        }
        private string PopulateMissingChildProfileBody(Models.ProfileModel profile)
        {
            var body = string.Empty;
            using (StreamReader reader = new StreamReader(HttpContext.Current.Server.MapPath("~/Template.htm")))
            {
                body = reader.ReadToEnd();
            }
            body = body.Replace("{FirstName}", profile.FirstName);
            body = body.Replace("{LastName}", profile.LastName);
            body = body.Replace("{Sex}", profile.Sex);
            body = body.Replace("{Description}", profile.Description);
            return body;
        }
        private FileStreamResult RenderPdf(string htmlContent)
        {            

            HttpContext.Current.Response.Clear();
            HttpContext.Current.Response.ContentType = "application/pdf";
            HttpContext.Current.Response.AddHeader("content-disposition", "attachment;filename=" + "MissingChildProfile.pdf");
            HttpContext.Current.Response.Cache.SetCacheability(HttpCacheability.NoCache);
            HttpContext.Current.Response.BinaryWrite(GetPDF(htmlContent));
            HttpContext.Current.Response.End();
            return new FileStreamResult(HttpContext.Current.Response.OutputStream, "application/pdf");
        }
        private byte[] GetPDF(string inputHtml)
        {
            byte[] pdfBytes = null;
            var ms = new MemoryStream();
            var txtReader = new StringReader(inputHtml);
            var doc = new Document(PageSize.A4, 25, 25, 25, 25);
            var pdfWriterInstnace = PdfWriter.GetInstance(doc, ms);
            var htmlWorker = new HTMLWorker(doc);

            doc.Open();
            htmlWorker.StartDocument();
            htmlWorker.Parse(txtReader);
            htmlWorker.EndDocument();
            htmlWorker.Close();
            doc.Close();
            pdfBytes = ms.ToArray();

            return pdfBytes;
        }
    }      
}