using SkiaSharp;
using System;
using System.IO;

namespace MobileKidsIdApp.Views
{
    public partial class DocumentsPage : ContentPageBase
    {
        public DocumentsPage()
        { 
            InitializeComponent();
            var path = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Personal), $"{Guid.NewGuid():N}.pdf");
            GenerateDocument(path);
            webView.Source = path;
        }
        async void OnBackButtonClicked(object sender, EventArgs e)
        {
            if (webView.CanGoBack)
            {
                webView.GoBack();
            }
            else
            {
                await Navigation.PopAsync();
            }
        }

        void OnForwardButtonClicked(object sender, EventArgs e)
        {
            if (webView.CanGoForward)
            {
                webView.GoForward();
            }
        }

        private void GenerateDocument(string path)
        {
            var metadata = new SKDocumentPdfMetadata
            {
                Author = "GiveCamp 2020",
                Creation = DateTime.Now,
                Creator = "That Conference Library",
                Keywords = "GiveCamp, That Conference, Test",
                Modified = DateTime.Now,
                Producer = "Test",
                Subject = "Test",
                Title = "Test PDF",
            };
            using var document = SKDocument.CreatePdf(path, metadata);
            using var paint = new SKPaint
            {
                TextSize = 64.0f,
                IsAntialias = true,
                Color = 0xFF9CAFB7,
                IsStroke = true,
                StrokeWidth = 3,
                TextAlign = SKTextAlign.Center
            };
            var pageWidth = 840;
            var pageHeight = 1188;

            // draw page 1
            using (var pdfCanvas = document.BeginPage(pageWidth, pageHeight))
            {
                // draw button
                using var nextPagePaint = new SKPaint
                {
                    IsAntialias = true,
                    TextSize = 16,
                    Color = SKColors.OrangeRed
                };
                var nextText = "Next Page >>";
                var btn = new SKRect(pageWidth - nextPagePaint.MeasureText(nextText) - 24, 0, pageWidth, nextPagePaint.TextSize + 24);
                pdfCanvas.DrawText(nextText, btn.Left + 12, btn.Bottom - 12, nextPagePaint);
                // make button link
                pdfCanvas.DrawLinkDestinationAnnotation(btn, "next-page");

                // draw contents
                pdfCanvas.DrawText("...PDF 1/2...", pageWidth / 2, pageHeight / 4, paint);
                document.EndPage();
            }
            // draw page 2
            using (var pdfCanvas = document.BeginPage(pageWidth, pageHeight))
            {
                // draw link destintion
                pdfCanvas.DrawNamedDestinationAnnotation(SKPoint.Empty, "next-page");

                // draw contents
                pdfCanvas.DrawText("...PDF 2/2...", pageWidth / 2, pageHeight / 4, paint);
                document.EndPage();
            }

            // end the doc
            document.Close();
        }    }

}
