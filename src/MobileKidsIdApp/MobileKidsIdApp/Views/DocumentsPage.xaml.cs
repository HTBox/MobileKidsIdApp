using MobileKidsIdApp.Services;
using System;
using System.IO;

namespace MobileKidsIdApp.Views
{
    public partial class DocumentsPage : ContentPageBase
    {
        public DocumentsPage()
        {
            InitializeComponent();
            var dgs = new DocumentGenerationService();
            customWebView.Uri = dgs.GeneratePdfDcoumentFromTemplate("Missing Child");
        }
    }
}
