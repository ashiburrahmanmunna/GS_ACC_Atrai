using Invoice.Core.ViewModel;
using iTextSharp.text;
using iTextSharp.text.pdf;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.Extensions;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Web;

namespace Invoice.Data.Reports
{
    public class VGMReportClass
    {
        #region Declaration

        private int _totalColumn = 6;
        private Document _document;
        private iTextSharp.text.Font _fontStyle;
        private iTextSharp.text.Font _fontStyleNormal;
        private PdfPTable _pdfPTable;
        private PdfPCell _pdfPCell;
        private MemoryStream _memoryStream;
        private PdfWriter writer;

        private PdfPTable paymentTable;

        public VGMReportViewModel _model;

        private IConfiguration Configuration;
        private readonly IHttpContextAccessor httpcontext;
        public VGMReportClass(IConfiguration configuration)
        {

            paymentTable = new PdfPTable(2);
            _pdfPTable = new PdfPTable(_totalColumn);
            _memoryStream = new MemoryStream();
            this.Configuration = configuration;
            httpcontext = new HttpContextAccessor();
        }
        #endregion
        public byte[] CreateReport(VGMReportViewModel model)
        {
            _model = model;

            #region page
            _document = new Document(PageSize.A4, 0f, 0f, 0f, 0f);
            _document.SetPageSize(PageSize.A4);
            _document.SetMargins(20f, 20f, 20f, 20f);
            _pdfPTable.WidthPercentage = 100;
            _pdfPTable.HorizontalAlignment = Element.ALIGN_LEFT;
            _fontStyle = FontFactory.GetFont("Tahoma", 8f, 1);
            writer = PdfWriter.GetInstance(_document, _memoryStream);
            _document.Open();
            _pdfPTable.SetWidths(new float[] { 30f, 110f, 100f, 70f, 70f, 70f });

            paymentTable.WidthPercentage = 100;
            paymentTable.HorizontalAlignment = Element.ALIGN_LEFT;
            paymentTable.SetWidths(new float[] { 100f, 100f });

            this.reportHeader();
            this.reportBody();

            _pdfPTable.HeaderRows = 2;
            _document.Add(paymentTable);
            _document.Add(_pdfPTable);
            _document.Close();
            return _memoryStream.ToArray();

            #endregion

        }
        private void reportHeader()
        {
            //string urlabc = "http://localhost:2553//Images/02BL0011.png";
            //string urlabc = "~/Images/02BL0011.png";
            var url = httpcontext.HttpContext.Request.Path;
            if (_model.company.Logo != null ){
                //string host = Configuration["host"];
                //var testlocation = new Uri($"{httpcontext.HttpContext.Request.Scheme}://{httpcontext.HttpContext.Request.Host}{httpcontext.HttpContext.Request.Path}{httpcontext.HttpContext.Request.QueryString}");
                //var location = new Uri($"{httpcontext.HttpContext.Request.Scheme}://{httpcontext.HttpContext.Request.Host}");

                //var absoluteurl = location.AbsoluteUri;
                //string abcdef = httpcontext.HttpContext.Request.GetDisplayUrl();
                string finalhosturl =  $"{this.httpcontext.HttpContext.Request.Scheme}://{this.httpcontext.HttpContext.Request.Host}{this.httpcontext.HttpContext.Request.PathBase}";
                //string host = System.Configuration.ConfigurationManager.AppSettings["host"];
                //string imageUrl =host + _model.company.Logo;
                //string imageUrl = absoluteurl;// host + _model.company.Logo;
                string imageUrl = finalhosturl + _model.company.Logo;


                iTextSharp.text.Image img = iTextSharp.text.Image.GetInstance(new Uri(imageUrl));
                img.ScaleToFit(50f, 50f);
                img.SpacingAfter = 10f;
                img.SpacingAfter = 5f;
                img.Alignment = Element.ALIGN_LEFT;
                _document.Add(img);
            }
           


            _fontStyle = FontFactory.GetFont("Tahoma", 15f, 1);
            _pdfPCell = new PdfPCell(new Phrase(_model.company.StoreName, _fontStyle));
            _pdfPCell.Colspan = _totalColumn;
            _pdfPCell.HorizontalAlignment = Element.ALIGN_LEFT;
            _pdfPCell.Border = 0;
            _pdfPCell.BackgroundColor = BaseColor.WHITE;
            _pdfPCell.ExtraParagraphSpace = 0;
            paymentTable.AddCell(_pdfPCell);
            paymentTable.CompleteRow();

            _fontStyle = FontFactory.GetFont("Tahoma", 9f, 0);
            _pdfPCell = new PdfPCell(new Phrase(_model.company.Email, _fontStyle));
            _pdfPCell.Colspan = _totalColumn;
            _pdfPCell.HorizontalAlignment = Element.ALIGN_LEFT;
            _pdfPCell.Border = 0;
            _pdfPCell.BackgroundColor = BaseColor.WHITE;
            _pdfPCell.ExtraParagraphSpace = 0;
            paymentTable.AddCell(_pdfPCell);
            paymentTable.CompleteRow();

            

            _fontStyle = FontFactory.GetFont("Tahoma", 9f, 0);
            _pdfPCell = new PdfPCell(new Phrase(_model.company.Web, _fontStyle));
            _pdfPCell.Colspan = _totalColumn;
            _pdfPCell.HorizontalAlignment = Element.ALIGN_LEFT;
            _pdfPCell.Border = 0;
            _pdfPCell.BackgroundColor = BaseColor.WHITE;
            _pdfPCell.ExtraParagraphSpace = 0;
            paymentTable.AddCell(_pdfPCell);
            paymentTable.CompleteRow();

            
            _pdfPCell = new PdfPCell(new Phrase(_model.company.Phone, _fontStyle));
            _pdfPCell.Colspan = _totalColumn;
            _pdfPCell.HorizontalAlignment = Element.ALIGN_LEFT;
            _pdfPCell.Border = 0;
            _pdfPCell.BackgroundColor = BaseColor.WHITE;
            _pdfPCell.ExtraParagraphSpace = 0;
            paymentTable.AddCell(_pdfPCell);
            paymentTable.CompleteRow();

          

            _fontStyle = FontFactory.GetFont("Tahoma", 9f, 0);
            _pdfPCell = new PdfPCell(new Phrase(_model.company.Address, _fontStyle));
            _pdfPCell.Colspan = _totalColumn;
            _pdfPCell.HorizontalAlignment = Element.ALIGN_LEFT;
            _pdfPCell.Border = 0;
            _pdfPCell.BackgroundColor = BaseColor.WHITE;
            _pdfPCell.ExtraParagraphSpace = 0;
            paymentTable.AddCell(_pdfPCell);
            paymentTable.CompleteRow();

            
            _pdfPCell = new PdfPCell(new Phrase(" ", _fontStyle));
            _pdfPCell.Colspan = _totalColumn;
            _pdfPCell.HorizontalAlignment = Element.ALIGN_LEFT;
            _pdfPCell.Border = 0;
            _pdfPCell.BackgroundColor = BaseColor.WHITE;
            _pdfPCell.ExtraParagraphSpace = 0;
            paymentTable.AddCell(_pdfPCell);
            paymentTable.CompleteRow();

            _pdfPCell = new PdfPCell(new Phrase(" ", _fontStyle));
            _pdfPCell.Colspan = _totalColumn;
            _pdfPCell.HorizontalAlignment = Element.ALIGN_LEFT;
            _pdfPCell.Border = 0;
            _pdfPCell.BackgroundColor = BaseColor.WHITE;
            _pdfPCell.ExtraParagraphSpace = 0;
            paymentTable.AddCell(_pdfPCell);
            paymentTable.CompleteRow();



            _fontStyle = FontFactory.GetFont("Tahoma", 9f, 0);
            _pdfPCell = new PdfPCell(new Phrase("1. VGA NO : ", _fontStyle));
            _pdfPCell.Colspan = 1;
            _pdfPCell.HorizontalAlignment = Element.ALIGN_LEFT;
            _pdfPCell.Border = 0;
            _pdfPCell.BackgroundColor = BaseColor.WHITE;
            _pdfPCell.ExtraParagraphSpace = 0;
            paymentTable.AddCell(_pdfPCell);
            //paymentTable.CompleteRow();


            _fontStyle = FontFactory.GetFont("Tahoma", 9f, 0);
            _pdfPCell = new PdfPCell(new Phrase(_model.VGMdata.VGANo, _fontStyle));
            _pdfPCell.Colspan = 1;
            _pdfPCell.HorizontalAlignment = Element.ALIGN_LEFT;
            _pdfPCell.Border = 0;
            _pdfPCell.BackgroundColor = BaseColor.WHITE;
            _pdfPCell.ExtraParagraphSpace = 0;
            paymentTable.AddCell(_pdfPCell);
            paymentTable.CompleteRow();


            _pdfPCell = new PdfPCell(new Phrase(" ", _fontStyle));
            _pdfPCell.Colspan = _totalColumn;
            _pdfPCell.HorizontalAlignment = Element.ALIGN_LEFT;
            _pdfPCell.Border = 0;
            _pdfPCell.BackgroundColor = BaseColor.WHITE;
            _pdfPCell.ExtraParagraphSpace = 0;
            paymentTable.AddCell(_pdfPCell);
            paymentTable.CompleteRow();



            _fontStyle = FontFactory.GetFont("Tahoma", 9f, 0);
            _pdfPCell = new PdfPCell(new Phrase("2. VGA Method : ", _fontStyle));
            _pdfPCell.Colspan = 1;
            _pdfPCell.HorizontalAlignment = Element.ALIGN_LEFT;
            _pdfPCell.Border = 0;
            _pdfPCell.BackgroundColor = BaseColor.WHITE;
            _pdfPCell.ExtraParagraphSpace = 0;
            paymentTable.AddCell(_pdfPCell);
            //paymentTable.CompleteRow();


            _fontStyle = FontFactory.GetFont("Tahoma", 9f, 0);
            _pdfPCell = new PdfPCell(new Phrase(_model.VGMdata.VGAMethod, _fontStyle));
            _pdfPCell.Colspan = 1;
            _pdfPCell.HorizontalAlignment = Element.ALIGN_LEFT;
            _pdfPCell.Border = 0;
            _pdfPCell.BackgroundColor = BaseColor.WHITE;
            _pdfPCell.ExtraParagraphSpace = 0;
            paymentTable.AddCell(_pdfPCell);
            paymentTable.CompleteRow();




            _pdfPCell = new PdfPCell(new Phrase(" ", _fontStyle));
            _pdfPCell.Colspan = _totalColumn;
            _pdfPCell.HorizontalAlignment = Element.ALIGN_LEFT;
            _pdfPCell.Border = 0;
            _pdfPCell.BackgroundColor = BaseColor.WHITE;
            _pdfPCell.ExtraParagraphSpace = 0;
            paymentTable.AddCell(_pdfPCell);
            paymentTable.CompleteRow();



            _fontStyle = FontFactory.GetFont("Tahoma", 9f, 0);
            _pdfPCell = new PdfPCell(new Phrase("3. Container No : ", _fontStyle));
            _pdfPCell.Colspan = 1;
            _pdfPCell.HorizontalAlignment = Element.ALIGN_LEFT;
            _pdfPCell.Border = 0;
            _pdfPCell.BackgroundColor = BaseColor.WHITE;
            _pdfPCell.ExtraParagraphSpace = 0;
            paymentTable.AddCell(_pdfPCell);
            //paymentTable.CompleteRow();



            _fontStyle = FontFactory.GetFont("Tahoma", 9f, 0);
            _pdfPCell = new PdfPCell(new Phrase(_model.VGMdata.ContainerNo, _fontStyle));
            _pdfPCell.Colspan = 1;
            _pdfPCell.HorizontalAlignment = Element.ALIGN_LEFT;
            _pdfPCell.Border = 0;
            _pdfPCell.BackgroundColor = BaseColor.WHITE;
            _pdfPCell.ExtraParagraphSpace = 0;
            paymentTable.AddCell(_pdfPCell);
            paymentTable.CompleteRow();



            _pdfPCell = new PdfPCell(new Phrase(" ", _fontStyle));
            _pdfPCell.Colspan = _totalColumn;
            _pdfPCell.HorizontalAlignment = Element.ALIGN_LEFT;
            _pdfPCell.Border = 0;
            _pdfPCell.BackgroundColor = BaseColor.WHITE;
            _pdfPCell.ExtraParagraphSpace = 0;
            paymentTable.AddCell(_pdfPCell);
            paymentTable.CompleteRow();


            _fontStyle = FontFactory.GetFont("Tahoma", 9f, 0);
            _pdfPCell = new PdfPCell(new Phrase("4. Container Type : ", _fontStyle));
            _pdfPCell.Colspan = 1;
            _pdfPCell.HorizontalAlignment = Element.ALIGN_LEFT;
            _pdfPCell.Border = 0;
            _pdfPCell.BackgroundColor = BaseColor.WHITE;
            _pdfPCell.ExtraParagraphSpace = 0;
            paymentTable.AddCell(_pdfPCell);
            //paymentTable.CompleteRow();


            _fontStyle = FontFactory.GetFont("Tahoma", 9f, 0);
            _pdfPCell = new PdfPCell(new Phrase(_model.VGMdata.ContainerType, _fontStyle));
            _pdfPCell.Colspan = 1;
            _pdfPCell.HorizontalAlignment = Element.ALIGN_LEFT;
            _pdfPCell.Border = 0;
            _pdfPCell.BackgroundColor = BaseColor.WHITE;
            _pdfPCell.ExtraParagraphSpace = 0;
            paymentTable.AddCell(_pdfPCell);
            paymentTable.CompleteRow();


            _pdfPCell = new PdfPCell(new Phrase(" ", _fontStyle));
            _pdfPCell.Colspan = _totalColumn;
            _pdfPCell.HorizontalAlignment = Element.ALIGN_LEFT;
            _pdfPCell.Border = 0;
            _pdfPCell.BackgroundColor = BaseColor.WHITE;
            _pdfPCell.ExtraParagraphSpace = 0;
            paymentTable.AddCell(_pdfPCell);
            paymentTable.CompleteRow();

            _fontStyle = FontFactory.GetFont("Tahoma", 9f, 0);
            _pdfPCell = new PdfPCell(new Phrase("5. Container Size : ", _fontStyle));
            _pdfPCell.Colspan = 1;
            _pdfPCell.HorizontalAlignment = Element.ALIGN_LEFT;
            _pdfPCell.Border = 0;
            _pdfPCell.BackgroundColor = BaseColor.WHITE;
            _pdfPCell.ExtraParagraphSpace = 0;
            paymentTable.AddCell(_pdfPCell);
            //paymentTable.CompleteRow();



            _fontStyle = FontFactory.GetFont("Tahoma", 9f, 0);
            _pdfPCell = new PdfPCell(new Phrase(_model.VGMdata.ContainerSize, _fontStyle));
            _pdfPCell.Colspan = 1;
            _pdfPCell.HorizontalAlignment = Element.ALIGN_LEFT;
            _pdfPCell.Border = 0;
            _pdfPCell.BackgroundColor = BaseColor.WHITE;
            _pdfPCell.ExtraParagraphSpace = 0;
            paymentTable.AddCell(_pdfPCell);
            paymentTable.CompleteRow();


            _pdfPCell = new PdfPCell(new Phrase(" ", _fontStyle));
            _pdfPCell.Colspan = _totalColumn;
            _pdfPCell.HorizontalAlignment = Element.ALIGN_LEFT;
            _pdfPCell.Border = 0;
            _pdfPCell.BackgroundColor = BaseColor.WHITE;
            _pdfPCell.ExtraParagraphSpace = 0;
            paymentTable.AddCell(_pdfPCell);
            paymentTable.CompleteRow();


            _fontStyle = FontFactory.GetFont("Tahoma", 9f, 0);
            _pdfPCell = new PdfPCell(new Phrase("6. Tare Weight : ", _fontStyle));
            _pdfPCell.Colspan = 1;
            _pdfPCell.HorizontalAlignment = Element.ALIGN_LEFT;
            _pdfPCell.Border = 0;
            _pdfPCell.BackgroundColor = BaseColor.WHITE;
            _pdfPCell.ExtraParagraphSpace = 0;
            paymentTable.AddCell(_pdfPCell);
            ///paymentTable.CompleteRow();


            _fontStyle = FontFactory.GetFont("Tahoma", 9f, 0);
            _pdfPCell = new PdfPCell(new Phrase(_model.VGMdata.TareWeight + " Kg", _fontStyle));
            _pdfPCell.Colspan = 1;
            _pdfPCell.HorizontalAlignment = Element.ALIGN_LEFT;
            _pdfPCell.Border = 0;
            _pdfPCell.BackgroundColor = BaseColor.WHITE;
            _pdfPCell.ExtraParagraphSpace = 0;
            paymentTable.AddCell(_pdfPCell);
            paymentTable.CompleteRow();


            _pdfPCell = new PdfPCell(new Phrase(" ", _fontStyle));
            _pdfPCell.Colspan = _totalColumn;
            _pdfPCell.HorizontalAlignment = Element.ALIGN_LEFT;
            _pdfPCell.Border = 0;
            _pdfPCell.BackgroundColor = BaseColor.WHITE;
            _pdfPCell.ExtraParagraphSpace = 0;
            paymentTable.AddCell(_pdfPCell);
            paymentTable.CompleteRow();


            _fontStyle = FontFactory.GetFont("Tahoma", 9f, 0);
            _pdfPCell = new PdfPCell(new Phrase("7. Verified Gross Mass : " + _model.VGMdata.VerifiedGrossMass, _fontStyle));
            _pdfPCell.Colspan = _totalColumn;
            _pdfPCell.HorizontalAlignment = Element.ALIGN_LEFT;
            _pdfPCell.Border = 0;
            _pdfPCell.BackgroundColor = BaseColor.WHITE;
            _pdfPCell.ExtraParagraphSpace = 0;
            paymentTable.AddCell(_pdfPCell);
            paymentTable.CompleteRow();


            _pdfPCell = new PdfPCell(new Phrase(" ", _fontStyle));
            _pdfPCell.Colspan = _totalColumn;
            _pdfPCell.HorizontalAlignment = Element.ALIGN_LEFT;
            _pdfPCell.Border = 0;
            _pdfPCell.BackgroundColor = BaseColor.WHITE;
            _pdfPCell.ExtraParagraphSpace = 0;
            paymentTable.AddCell(_pdfPCell);
            paymentTable.CompleteRow();


            _fontStyle = FontFactory.GetFont("Tahoma", 9f, 0);
            _pdfPCell = new PdfPCell(new Phrase("a. Previously declared weight : " + _model.VGMdata.PreviouslyDeclaredweight, _fontStyle));
            _pdfPCell.Colspan = _totalColumn;
            _pdfPCell.HorizontalAlignment = Element.ALIGN_LEFT;
            _pdfPCell.Border = 0;
            _pdfPCell.BackgroundColor = BaseColor.WHITE;
            _pdfPCell.ExtraParagraphSpace = 0;
            paymentTable.AddCell(_pdfPCell);
            paymentTable.CompleteRow();


            _pdfPCell = new PdfPCell(new Phrase(" ", _fontStyle));
            _pdfPCell.Colspan = _totalColumn;
            _pdfPCell.HorizontalAlignment = Element.ALIGN_LEFT;
            _pdfPCell.Border = 0;
            _pdfPCell.BackgroundColor = BaseColor.WHITE;
            _pdfPCell.ExtraParagraphSpace = 0;
            paymentTable.AddCell(_pdfPCell);
            paymentTable.CompleteRow();


            _fontStyle = FontFactory.GetFont("Tahoma", 9f, 0);
            _pdfPCell = new PdfPCell(new Phrase("b. VGM weight by CPA : " + _model.VGMdata.VGMWeightbyCPA, _fontStyle));
            _pdfPCell.Colspan = _totalColumn;
            _pdfPCell.HorizontalAlignment = Element.ALIGN_LEFT;
            _pdfPCell.Border = 0;
            _pdfPCell.BackgroundColor = BaseColor.WHITE;
            _pdfPCell.ExtraParagraphSpace = 0;
            paymentTable.AddCell(_pdfPCell);
            paymentTable.CompleteRow();


            _pdfPCell = new PdfPCell(new Phrase(" ", _fontStyle));
            _pdfPCell.Colspan = _totalColumn;
            _pdfPCell.HorizontalAlignment = Element.ALIGN_LEFT;
            _pdfPCell.Border = 0;
            _pdfPCell.BackgroundColor = BaseColor.WHITE;
            _pdfPCell.ExtraParagraphSpace = 0;
            paymentTable.AddCell(_pdfPCell);
            paymentTable.CompleteRow();


            _fontStyle = FontFactory.GetFont("Tahoma", 9f, 0);
            _pdfPCell = new PdfPCell(new Phrase("8. Name of Shipper : " + _model.VGMdata.NameofShipper, _fontStyle));
            _pdfPCell.Colspan = _totalColumn;
            _pdfPCell.HorizontalAlignment = Element.ALIGN_LEFT;
            _pdfPCell.Border = 0;
            _pdfPCell.BackgroundColor = BaseColor.WHITE;
            _pdfPCell.ExtraParagraphSpace = 0;
            paymentTable.AddCell(_pdfPCell);
            paymentTable.CompleteRow();


            _pdfPCell = new PdfPCell(new Phrase(" ", _fontStyle));
            _pdfPCell.Colspan = _totalColumn;
            _pdfPCell.HorizontalAlignment = Element.ALIGN_LEFT;
            _pdfPCell.Border = 0;
            _pdfPCell.BackgroundColor = BaseColor.WHITE;
            _pdfPCell.ExtraParagraphSpace = 0;
            paymentTable.AddCell(_pdfPCell);
            paymentTable.CompleteRow();

            _fontStyle = FontFactory.GetFont("Tahoma", 9f, 0);
            _pdfPCell = new PdfPCell(new Phrase("9. Name of MLO/Shipping Agent : " + _model.VGMdata.ShippingAgent, _fontStyle));
            _pdfPCell.Colspan = _totalColumn;
            _pdfPCell.HorizontalAlignment = Element.ALIGN_LEFT;
            _pdfPCell.Border = 0;
            _pdfPCell.BackgroundColor = BaseColor.WHITE;
            _pdfPCell.ExtraParagraphSpace = 0;
            paymentTable.AddCell(_pdfPCell);
            paymentTable.CompleteRow();



            _pdfPCell = new PdfPCell(new Phrase(" ", _fontStyle));
            _pdfPCell.Colspan = _totalColumn;
            _pdfPCell.HorizontalAlignment = Element.ALIGN_LEFT;
            _pdfPCell.Border = 0;
            _pdfPCell.BackgroundColor = BaseColor.WHITE;
            _pdfPCell.ExtraParagraphSpace = 0;
            paymentTable.AddCell(_pdfPCell);
            paymentTable.CompleteRow();


            _fontStyle = FontFactory.GetFont("Tahoma", 9f, 0);
            _pdfPCell = new PdfPCell(new Phrase("10. VGM performed on behalf of The shipper by : " + _model.VGMdata.VGMPerformedShipperBy, _fontStyle));
            _pdfPCell.Colspan = _totalColumn;
            _pdfPCell.HorizontalAlignment = Element.ALIGN_LEFT;
            _pdfPCell.Border = 0;
            _pdfPCell.BackgroundColor = BaseColor.WHITE;
            _pdfPCell.ExtraParagraphSpace = 0;
            paymentTable.AddCell(_pdfPCell);
            paymentTable.CompleteRow();



            _pdfPCell = new PdfPCell(new Phrase(" ", _fontStyle));
            _pdfPCell.Colspan = _totalColumn;
            _pdfPCell.HorizontalAlignment = Element.ALIGN_LEFT;
            _pdfPCell.Border = 0;
            _pdfPCell.BackgroundColor = BaseColor.WHITE;
            _pdfPCell.ExtraParagraphSpace = 0;
            paymentTable.AddCell(_pdfPCell);
            paymentTable.CompleteRow();


            _fontStyle = FontFactory.GetFont("Tahoma", 9f, 0);
            _pdfPCell = new PdfPCell(new Phrase("11. weight bridge registration no : " + _model.VGMdata.WeightBridgeRegistrationNo, _fontStyle));
            _pdfPCell.Colspan = _totalColumn;
            _pdfPCell.HorizontalAlignment = Element.ALIGN_LEFT;
            _pdfPCell.Border = 0;
            _pdfPCell.BackgroundColor = BaseColor.WHITE;
            _pdfPCell.ExtraParagraphSpace = 0;
            paymentTable.AddCell(_pdfPCell);
            paymentTable.CompleteRow();



            _pdfPCell = new PdfPCell(new Phrase(" ", _fontStyle));
            _pdfPCell.Colspan = _totalColumn;
            _pdfPCell.HorizontalAlignment = Element.ALIGN_LEFT;
            _pdfPCell.Border = 0;
            _pdfPCell.BackgroundColor = BaseColor.WHITE;
            _pdfPCell.ExtraParagraphSpace = 0;
            paymentTable.AddCell(_pdfPCell);
            paymentTable.CompleteRow();


            _fontStyle = FontFactory.GetFont("Tahoma", 9f, 0);
            _pdfPCell = new PdfPCell(new Phrase("12. Address of weight bridge : " + _model.VGMdata.AddressOfWeightBridge, _fontStyle));
            _pdfPCell.Colspan = _totalColumn;
            _pdfPCell.HorizontalAlignment = Element.ALIGN_LEFT;
            _pdfPCell.Border = 0;
            _pdfPCell.BackgroundColor = BaseColor.WHITE;
            _pdfPCell.ExtraParagraphSpace = 0;
            paymentTable.AddCell(_pdfPCell);
            paymentTable.CompleteRow();

        }
        private void reportBody()
        {
            _fontStyle = FontFactory.GetFont("Tahoma", 9f, 1);

           



            _fontStyle = FontFactory.GetFont("Tahoma", 8f, 1);
            _pdfPCell = new PdfPCell(new Phrase(" ", _fontStyle));
            _pdfPCell.Colspan = _totalColumn;
            _pdfPCell.HorizontalAlignment = Element.ALIGN_LEFT;
            _pdfPCell.Border = 0;
            _pdfPCell.BackgroundColor = BaseColor.WHITE;
            _pdfPCell.ExtraParagraphSpace = 0;
            _pdfPTable.AddCell(_pdfPCell);
            _pdfPTable.CompleteRow();



            #region Table body
            _fontStyle = FontFactory.GetFont("Tahoma", 8f, 0);



            //_pdfPCell = new PdfPCell(new Phrase(" ", _fontStyle));
            //_pdfPCell.Colspan = 6;
            //_pdfPCell.Border = 0;
            //_pdfPTable.AddCell(_pdfPCell);
            //_pdfPTable.CompleteRow();

            //_fontStyle = FontFactory.GetFont("Tahoma", 9f, 1);
            //_pdfPCell = new PdfPCell(new Phrase("Grand Total : ", _fontStyle));
            //_pdfPCell.HorizontalAlignment = Element.ALIGN_RIGHT;
            //_pdfPCell.Colspan = 5;
            //_pdfPCell.Border = 0;
            //_pdfPCell.VerticalAlignment = Element.ALIGN_MIDDLE;
            //_pdfPCell.BackgroundColor = BaseColor.WHITE;
            //_pdfPTable.AddCell(_pdfPCell);



            // _pdfPTable.CompleteRow();





            _fontStyle = FontFactory.GetFont("Tahoma", 120, 0);
            _pdfPCell = new PdfPCell(new Phrase("  ", _fontStyle));
            _pdfPCell.Colspan = _totalColumn;
            _pdfPCell.HorizontalAlignment = Element.ALIGN_LEFT;
            _pdfPCell.Border = 0;
            _pdfPCell.BackgroundColor = BaseColor.WHITE;
            _pdfPCell.ExtraParagraphSpace = 0;
            //_pdfPCell.Height(300f);
            paymentTable.AddCell(_pdfPCell);
            paymentTable.CompleteRow();





            #endregion

            var Border = PdfPCell.BOTTOM_BORDER;// | PdfPCell.TOP_BORDER;

            _fontStyle = FontFactory.GetFont("Tahoma", 9f, 0);
            _pdfPCell = new PdfPCell(new Phrase(" ", _fontStyle));
            _pdfPCell.Colspan = 1;
            _pdfPCell.HorizontalAlignment = Element.ALIGN_LEFT;
            //_pdfPCell.Border = 0;
            _pdfPCell.BackgroundColor = BaseColor.WHITE;
            _pdfPCell.ExtraParagraphSpace = 0;
            _pdfPCell.Border = Border;
            paymentTable.AddCell(_pdfPCell);
            //paymentTable.CompleteRow();



            _fontStyle = FontFactory.GetFont("Tahoma", 8f, 1);
            _pdfPCell = new PdfPCell(new Phrase("  ", _fontStyle));
            _pdfPCell.Colspan = 1;
            _pdfPCell.HorizontalAlignment = Element.ALIGN_LEFT;
            _pdfPCell.Border = 0;
            _pdfPCell.BackgroundColor = BaseColor.WHITE;
            _pdfPCell.ExtraParagraphSpace = 0;
            paymentTable.AddCell(_pdfPCell);
            paymentTable.CompleteRow();


            //Border = PdfPCell.TOP_BORDER;

            _fontStyle = FontFactory.GetFont("Tahoma", 9f, 0);
            _pdfPCell = new PdfPCell(new Phrase("Signature of the CPA Official", _fontStyle));
            _pdfPCell.Colspan = _totalColumn;
            _pdfPCell.HorizontalAlignment = Element.ALIGN_LEFT;
            _pdfPCell.Border = 0;
            _pdfPCell.BackgroundColor = BaseColor.WHITE;
            _pdfPCell.ExtraParagraphSpace = 0;
            //_pdfPCell.Border = Border;
            paymentTable.AddCell(_pdfPCell);
            paymentTable.CompleteRow();

            //_fontStyle = FontFactory.GetFont("Tahoma", 9f, 0);
            //_pdfPCell = new PdfPCell(new Phrase(" ", _fontStyle));
            //_pdfPCell.Colspan = 1;
            //_pdfPCell.HorizontalAlignment = Element.ALIGN_LEFT;
            //_pdfPCell.Border = 0;
            //_pdfPCell.BackgroundColor = BaseColor.WHITE;
            //_pdfPCell.ExtraParagraphSpace = 0;
            ////_pdfPCell.Border = Border;
            //paymentTable.AddCell(_pdfPCell);
            //paymentTable.CompleteRow();


            _pdfPCell = new PdfPCell(new Phrase("Designation", _fontStyle));
            _pdfPCell.Colspan = _totalColumn;
            _pdfPCell.HorizontalAlignment = Element.ALIGN_LEFT;
            _pdfPCell.Border = 0;
            _pdfPCell.BackgroundColor = BaseColor.WHITE;
            _pdfPCell.ExtraParagraphSpace = 0;
            paymentTable.AddCell(_pdfPCell);
            paymentTable.CompleteRow();





            _fontStyle = FontFactory.GetFont("Tahoma", 9f, 0);
            _pdfPCell = new PdfPCell(new Phrase("Seal", _fontStyle));
            _pdfPCell.Colspan = _totalColumn;
            _pdfPCell.HorizontalAlignment = Element.ALIGN_LEFT;
            _pdfPCell.Border = 0;
            _pdfPCell.BackgroundColor = BaseColor.WHITE;
            _pdfPCell.ExtraParagraphSpace = 0;
            paymentTable.AddCell(_pdfPCell);
            paymentTable.CompleteRow();



            //_fontStyle = FontFactory.GetFont("Tahoma", 9f, 0);
            //_pdfPCell = new PdfPCell(new Phrase(" Thanks for your shoping.", _fontStyle));
            //_pdfPCell.Colspan = _totalColumn;
            //_pdfPCell.HorizontalAlignment = Element.ALIGN_CENTER;
            //_pdfPCell.Border = 0;
            //_pdfPCell.BackgroundColor = BaseColor.WHITE;
            //_pdfPCell.ExtraParagraphSpace = 0;
            //_pdfPTable.AddCell(_pdfPCell);
            //_pdfPTable.CompleteRow();


            //_pdfPCell = new PdfPCell(new Phrase("VGM generated by : Dominatebd, contact : facebook.com/Dominatebd ", _fontStyle));
            //_pdfPCell.Colspan = _totalColumn;
            //_pdfPCell.HorizontalAlignment = Element.ALIGN_CENTER;
            //_pdfPCell.Border = 0;
            //_pdfPCell.BackgroundColor = BaseColor.WHITE;
            //_pdfPCell.ExtraParagraphSpace = 0;
            //_pdfPTable.AddCell(_pdfPCell);
            //_pdfPTable.CompleteRow();


            //pdfWriter.PageEvent = new PDFFooter();


        }




    }
}

//public class PDFFooter : PdfPageEventHelper
//{
//    // write on top of document
//    public override void OnOpenDocument(PdfWriter writer, Document document)
//    {
//        base.OnOpenDocument(writer, document);
//        PdfPTable tabFot = new PdfPTable(new float[] { 1F });
//        tabFot.SpacingAfter = 10F;
//        PdfPCell cell;
//        tabFot.TotalWidth = 300F;
//        cell = new PdfPCell(new Phrase(""));
//        cell.Border = Rectangle.NO_BORDER;
//        tabFot.AddCell(cell);
//        tabFot.WriteSelectedRows(0, -1, 150, document.Top, writer.DirectContent);
//    }

//    // write on start of each page
//    public override void OnStartPage(PdfWriter writer, Document document)
//    {
//        base.OnStartPage(writer, document);
//    }

//    // write on end of each page
//    public override void OnEndPage(PdfWriter writer, Document document)
//    {
//        DateTime horario = DateTime.Now;
//        base.OnEndPage(writer, document);
//        PdfPTable tabFot = new PdfPTable(new float[] { 1F });
//        PdfPCell cell;
//        tabFot.TotalWidth = 300F;
//        cell = new PdfPCell(new Phrase("TEST" + " - " + horario));
//        cell.Border = Rectangle.NO_BORDER;
//        cell.HorizontalAlignment = Element.ALIGN_CENTER;
//        tabFot.AddCell(cell);
//        tabFot.WriteSelectedRows(0, -1, 150, document.Bottom, writer.DirectContent);
//    }

//    //write on close of document
//    public override void OnCloseDocument(PdfWriter writer, Document document)
//    {
//        base.OnCloseDocument(writer, document);
//    }
//}
