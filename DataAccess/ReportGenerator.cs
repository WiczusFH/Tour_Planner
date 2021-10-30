using System;
using System.Collections.Generic;
using System.Text;
using PdfSharp;
using PdfSharp.Drawing;
using PdfSharp.Pdf;
using System.Data;
using System.Data.Common;

namespace DataAccess
{
    public class ReportGenerator
    {
        public void generateTourReport(List<DataAccess.ILog> logListDA, DataAccess.ITour tour)
        {
            System.Text.Encoding.RegisterProvider(System.Text.CodePagesEncodingProvider.Instance);
            PdfDocument pdf = new PdfDocument();
            PdfPage pdfPage1 = pdf.AddPage();
            PdfPage pdfPage2 = pdf.AddPage();
            XGraphics gfx1 = XGraphics.FromPdfPage(pdfPage1);
            XGraphics gfx2 = XGraphics.FromPdfPage(pdfPage2);
            XFont headerFont = new XFont("Arial", 20, XFontStyle.Bold);
            XFont chapterFont = new XFont("Arial", 14, XFontStyle.Bold);
            XFont textFont = new XFont("Arial", 12);
            double paragraph_Height = 18;
            double tab_Width = pdfPage2.Width / 24;
            //Tour
            gfx1.DrawString("Tour Log Summary", headerFont, XBrushes.Black, new XRect(0, 0, pdfPage1.Width, pdfPage1.Height), XStringFormat.Center);
            gfx2.DrawString(tour.name, chapterFont, XBrushes.Black, new XRect(pdfPage2.Width * 0.15, paragraph_Height * 4, pdfPage2.Width, 30), XStringFormat.TopLeft);
            gfx2.DrawString("- Description: "+tour.routeDescription, textFont, XBrushes.Black, new XRect(pdfPage2.Width * 0.15 + tab_Width, paragraph_Height * 6, pdfPage2.Width, 30), XStringFormat.TopLeft);
            gfx2.DrawString("- Information: " + tour.routeInformation, textFont, XBrushes.Black, new XRect(pdfPage2.Width * 0.15 + tab_Width, paragraph_Height * 7, pdfPage2.Width, 30), XStringFormat.TopLeft);
            gfx2.DrawString("- Starting Location: "+tour.sl_name, textFont, XBrushes.Black, new XRect(pdfPage2.Width * 0.15 + tab_Width, paragraph_Height * 8, pdfPage2.Width, 30), XStringFormat.TopLeft);
            gfx2.DrawString("- End Location: "+tour.el_name, textFont, XBrushes.Black, new XRect(pdfPage2.Width * 0.15 + tab_Width, paragraph_Height * 9, pdfPage2.Width, 30), XStringFormat.TopLeft);
            gfx2.DrawString("- Distance: "+tour.distance+"km", textFont, XBrushes.Black, new XRect(pdfPage2.Width * 0.15 + tab_Width, paragraph_Height * 10, pdfPage2.Width, 30), XStringFormat.TopLeft);
            string execPath = AppDomain.CurrentDomain.BaseDirectory;
            StringBuilder sb = new StringBuilder();
            sb.Append(execPath);
            sb.Append("/Images/");
            sb.Append(tour.name);
            sb.Append(".png");
            try
            {
                gfx2.DrawImage(XImage.FromFile(sb.ToString()), new XRect(pdfPage2.Width * 0.15, paragraph_Height * 14, pdfPage2.Width * 0.70, paragraph_Height * 26));
            } catch (Exception e) { }
            List<DataAccess.ILog> logListDisplay = new List<DataAccess.ILog>();
            foreach (ILog log in logListDA)
            {
                if (log.route_id == tour.id)
                {
                    logListDisplay.Add(log);
                }
            }
            //Logs
            PdfPage currPage = null;
            XGraphics currgfx = null;
            int index = 0;
            foreach (ILog log in logListDisplay)
            {
                if (index % 3 == 0)
                {
                    currPage = pdf.AddPage();
                    currgfx = XGraphics.FromPdfPage(currPage);
                }
                currgfx.DrawString(log.logTitle, chapterFont, XBrushes.Black, new XRect(tab_Width * 4, paragraph_Height * 4 + (index % 3) * paragraph_Height * 10, currPage.Width, 30), XStringFormat.TopLeft);
                currgfx.DrawString("- Date: " + log.date, textFont, XBrushes.Black, new XRect(tab_Width * 5, paragraph_Height * 6 + (index % 3) * paragraph_Height * 10, currPage.Width, 30), XStringFormat.TopLeft);
                currgfx.DrawString("- Duration: " + log.duration.ToString()+" hours", textFont, XBrushes.Black, new XRect(tab_Width * 5, paragraph_Height * 7 + (index % 3) * paragraph_Height * 10, currPage.Width, 30), XStringFormat.TopLeft);
                currgfx.DrawString("- Report: " + log.duration.ToString(), textFont, XBrushes.Black, new XRect(tab_Width * 5, paragraph_Height * 8 + (index % 3) * paragraph_Height * 10, currPage.Width, 30), XStringFormat.TopLeft);
                currgfx.DrawString("- Rating: " + log.rating.ToString() + "/5", textFont, XBrushes.Black, new XRect(tab_Width * 5, paragraph_Height * 9 + (index % 3) * paragraph_Height * 10, currPage.Width, 30), XStringFormat.TopLeft);
                currgfx.DrawString("- Top Speed: " + log.topSpeed.ToString() + "km/h", textFont, XBrushes.Black, new XRect(tab_Width * 5, paragraph_Height * 10 + (index % 3) * paragraph_Height * 10, currPage.Width, 30), XStringFormat.TopLeft);
                currgfx.DrawString("- Average Speed: " + log.averageSpeed.ToString() + "km/h", textFont, XBrushes.Black, new XRect(tab_Width * 5, paragraph_Height * 11 + (index % 3) * paragraph_Height * 10, currPage.Width, 30), XStringFormat.TopLeft);
                index++;
            }

            pdf.Save("TourReport.pdf");
        }

        public void generateLogReport(float totalTime, float totalDistance)
        {
            System.Text.Encoding.RegisterProvider(System.Text.CodePagesEncodingProvider.Instance);
            PdfDocument pdf = new PdfDocument();
            PdfPage pdfPage1 = pdf.AddPage();
            PdfPage pdfPage2 = pdf.AddPage();
            XGraphics gfx1 = XGraphics.FromPdfPage(pdfPage1);
            XGraphics gfx2 = XGraphics.FromPdfPage(pdfPage2);
            XFont headerFont = new XFont("Arial", 20, XFontStyle.Bold);
            XFont chapterFont = new XFont("Arial", 14, XFontStyle.Bold);
            XFont textFont = new XFont("Arial", 12);
            double paragraph_Height = 18;
            double tab_Width = pdfPage2.Width / 24;

            //Tour
            gfx1.DrawString("Summarize Report", headerFont, XBrushes.Black, new XRect(0, 0, pdfPage1.Width, pdfPage1.Height), XStringFormat.Center);
            gfx2.DrawString("Statistics: ", chapterFont, XBrushes.Black, new XRect(pdfPage2.Width * 0.15, paragraph_Height * 4, pdfPage2.Width, 30), XStringFormat.TopLeft);
            gfx2.DrawString("- Total Time Logged: " + totalTime + "h", textFont, XBrushes.Black, new XRect(pdfPage2.Width * 0.15 + tab_Width, paragraph_Height * 6, pdfPage2.Width, 30), XStringFormat.TopLeft);
            gfx2.DrawString("- Total Distance Logged: " + totalDistance + "km", textFont, XBrushes.Black, new XRect(pdfPage2.Width * 0.15 + tab_Width, paragraph_Height * 7, pdfPage2.Width, 30), XStringFormat.TopLeft);


            pdf.Save("SummarizeReport.pdf");
        }

    }
}
