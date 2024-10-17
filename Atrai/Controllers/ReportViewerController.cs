using Atrai.Core.Common;
using Atrai.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Reporting.NETCore;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
//using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Atrai.Controllers
{
    public class ReportViewerController : Controller

    //public class IndexModel : PageModel
    {

        public TransactionLogRepository tranlog { get; }
        //[Obsolete]
        //private readonly IHostingEnvironment _hostingEnvironment;
        ////private TransactionLogRepository tranlog;
        ////[Obsolete]
        //public ReportViewerController(IHostingEnvironment hostingEnvironment)//, TransactionLogRepository tran
        //{
        //    _hostingEnvironment = hostingEnvironment;
        //    //tranlog = tran;
        //}
        public ReportViewerController(TransactionLogRepository tranlogRepository)
        {
            tranlog = tranlogRepository;
        }

        //LocalReport lr = new LocalReport();
        //private string strMainRP = "";
        //private string strMainDSN = "";
        //private string strMainQuery = "";
        //private DataSet dsReport;
        //string strFormat = "";

        ////Variabl For Sub Report
        //private string subrp = "";
        private string strDSN = "";
        private string strQuery = "";
        private string strRFN = "";



        public void errorlog(Exception ex)
        {
            string filePath = @"C:\DevelopmentError\DevelopmentFile.txt";


            using (StreamWriter writer = new StreamWriter(filePath, true))
            {
                writer.WriteLine("-----------------------------------------------------------------------------");
                writer.WriteLine("Date : " + DateTime.Now.ToString());
                writer.WriteLine();

                while (ex != null)
                {
                    writer.WriteLine(ex.GetType().FullName);
                    writer.WriteLine("Message : " + ex.Message);
                    writer.WriteLine("StackTrace : " + ex.StackTrace);

                    ex = ex.InnerException;
                }
            }
        }

        public void errorlog(string ex)
        {
            string filePath = @"C:\DevelopmentError\DevelopmentFile.txt";


            using (StreamWriter writer = new StreamWriter(filePath, true))
            {
                writer.WriteLine(ex);
                writer.WriteLine("-----------------------------------------------------------------------------");
                writer.WriteLine("Date : " + DateTime.Now.ToString());
                writer.WriteLine();


            }
        }
        // GET: ReportViewer
        //[Obsolete]
        public IActionResult Index(string reporttype, int isfile = 0)
        {
            string[] streams;
            try
            {
                //errorlog("report viewer start");

                LocalReport lr = new LocalReport();
                //errorlog("1ST LINE");


                clsConnectionNew clsCon = new clsConnectionNew();
                string mimeType = "application/pdf";

                //GTRDBContext dc = new GTRDBContext();

                DataTable dt = new DataTable();
                DataSet ds = new DataSet();


                string reportpath = "";
                string reportquery = "";
                //string reporttype = "PDF";
                string reportformat = "PDF";

                if (reporttype != null)
                {
                    reportformat = reporttype;

                }

                reporttype = HttpContext.Session.GetString("ReportType");
                if (reporttype == null)
                {
                    reporttype = reportformat;
                }

                //reporttype = "HTML5";
                if (reporttype.ToString().ToUpper() == "EXCEL")
                {
                    reportformat = "xls";
                    mimeType = "application/vnd.ms-excel";
                    HttpContext.Session.SetString("ReportType", reporttype);
                }
                else if (reporttype.ToString().ToUpper() == "WORD")
                {
                    reportformat = "doc";
                    //mimeType = "application/msword";
                    mimeType = "application/vnd.openxmlformats-officedocument.wordprocessingml.document";
                    HttpContext.Session.SetString("ReportType", reporttype);

                }
                else if (reporttype.ToString().ToUpper() == "HTML5")
                {
                    reportformat = "html";
                    mimeType = "text/html";
                    HttpContext.Session.SetString("ReportType", reporttype);
                }
                else if (reporttype.ToString().ToUpper() == "IMAGE")
                {

                    reportformat = "jpeg";
                    mimeType = "image/jpeg";
                    HttpContext.Session.SetString("ReportType", reporttype);
                }
                else if (reporttype.ToString().ToUpper() == "Browser")
                {
                    //reportformat = "html";
                    //mimeType = "text/html";
                }
                else if (reporttype.ToString().ToUpper() == "JSON")
                {
                    // .json JSON format application/ json
                    reportformat = "json";
                    mimeType = "application/json";
                    HttpContext.Session.SetString("ReportType", reporttype);
                }
                else
                {
                    reportformat = "pdf";
                    mimeType = "application/pdf";
                    HttpContext.Session.SetString("ReportType", reporttype);
                }


                //if (Session["DisplayName"] == null)
                //{
                //    return RedirectToRoute("GTR");
                //}


                //HttpContext.Session.GetString("ReportType");
                if (HttpContext.Session.GetString("ReportPath") != null)
                {
                    reportpath = HttpContext.Session.GetString("ReportPath");
                    HttpContext.Session.SetString("ReportPath", "");
                }
                //if (HttpContext.Session.GetString("ReportQuery") != null)
                //{
                //    reportquery = HttpContext.Session.GetString("ReportQuery");
                //    //HttpContext.Session.SetString("ReportQuery","");
                //}
                if (HttpContext.Session.GetString("ReportQuery") != null)
                {
                    reportquery = HttpContext.Session.GetString("ReportQuery");
                    //HttpContext.Session.SetString("ReportQuery","");
                }
                if (HttpContext.Session.GetString("ReportType") != null)
                {
                    reporttype = HttpContext.Session.GetString("ReportType");

                    if (reporttype.ToString().ToUpper() == "EXCEL")
                    {
                        reportformat = "xls";
                        mimeType = "application/vnd.ms-excel";
                    }
                    else if (reporttype.ToString().ToUpper() == "WORD")
                    {
                        reportformat = "doc";
                        mimeType = "application/vnd.openxmlformats-officedocument.wordprocessingml.document";
                    }
                    else if (reporttype.ToString().ToUpper() == "HTML5")
                    {
                        reportformat = "html";
                        mimeType = "text/html";
                    }
                    else if (reporttype.ToString().ToUpper() == "IMAGE")
                    {
                        reportformat = "jpeg";
                        mimeType = "image/jpeg";
                    }
                    else if (reporttype.ToString().ToUpper() == "JSON")
                    {
                        reportformat = "json";
                        mimeType = "application/json";
                    }
                    else
                    {
                        reportformat = "pdf";
                        mimeType = "application/pdf";
                    }
                }

                //errorlog("2nd LINE");

                //Session["ReportType"] = "";

                //LocalReport lr = new LocalReport();
                //string path = Path.Combine(Server.MapPath(reportpath));
                //string path = Path.Combine(_hostingEnvironment.ContentRootPath + "//ReportViewer/Accounts/rptCOA.rdlc");
                //string path = Path.Combine("localhost/anjerptest/" + reportpath.Replace("~", ""));//_hostingEnvironment.ContentRootPath + 


                string path = "." + reportpath.Replace("~", "");//_hostingEnvironment.ContentRootPath + 


                //"~/ReportViewer/coatree.rdlc";

                //errorlog(path);

                //errorlog("3rd LINE");

                try
                {
                    if (System.IO.File.Exists(path))
                    {
                        lr.ReportPath = path;




                        TempData["Message"] = "Report Preview Successfully";
                        TempData["Status"] = "1";
                        tranlog.TransactionLog(RouteData.Values["controller"].ToString(), RouteData.Values["action"].ToString(), TempData["Message"].ToString(), "0", "Create", path + " - " + reportquery.ToString());



                    }
                    //else
                    //{
                    //    errorlog(path + " - location not found - path not found - report viewer");
                    //    return View("Index");

                    //}
                }
                catch (Exception ex)
                {
                    errorlog(path + " - location not found - path not found - report viewer");
                    throw new Exception(ex.Message, ex.InnerException);
                }


                //errorlog("exist ok LINE");



                lr.EnableExternalImages = true;
                lr.EnableHyperlinks = true;

                clsCon.GTRFillDatasetWithSQLCommand(ref ds, reportquery);

                dt = ds.Tables[0];

                ReportDataSource rd = new ReportDataSource();
                rd.Name = "DataSet1";
                rd.Value = dt;

                lr.DataSources.Add(rd);
                lr.SubreportProcessing += new SubreportProcessingEventHandler(prcProcessSubReport);
                //reportType = "PDF";


                string encoding;
                string fileNameExtension = reportformat;

                ReportPageSettings aPageSettings = lr.GetDefaultPageSettings();
                int width = aPageSettings.PaperSize.Width;
                int height = aPageSettings.PaperSize.Height;
                int margintop = aPageSettings.Margins.Top;
                int marginbottom = aPageSettings.Margins.Bottom;
                int marginleft = aPageSettings.Margins.Left;
                int marginright = aPageSettings.Margins.Right;

                //new LocalReport().EnableExternalImages = true;

                // errorlog("4th LINE");
                string deviceInfo =

                    "<DeviceInfo>" +
                    "  <OutputFormat>" + "PDF" + "</OutputFormat>" +
                    "  <PageWidth>" + width + "</PageWidth>" +
                    "  <PageHeight>" + height + "</PageHeight>" +
                    "  <MarginTop>" + margintop + "</MarginTop>" +
                    "  <MarginLeft>" + marginleft + "</MarginLeft>" +
                    "  <MarginRight>" + marginright + "</MarginRight>" +
                    "  <MarginBottom>" + marginbottom + "</MarginBottom>" +
                    "</DeviceInfo>";

                Warning[] warnings;
                //string[] streams;
                byte[] renderedBytes;

                lr.DisplayName = "GTR_Report";

                renderedBytes = lr.Render(
                    reporttype,
                    deviceInfo,
                    out mimeType,
                    out encoding,
                    out fileNameExtension,
                    out streams,
                    out warnings
                    );





                var sFileName = HttpContext.Session.GetString("PrintFileName") + "_" + DateTime.Now.ToString("yyyyMMdd");


                //errorlog("5th LINE");

                ///Response.Buffer = true;
                Response.Clear();
                Response.ContentType = mimeType;
                //Response.Headers.Add("Content-Disposition", "inline; filename=" + sFileName.Replace(".", "").Replace(" ", "").Replace(",", "").Replace("\t", "").Replace("\"", "") + "." + reportformat);


                //var pdf = lr.Render(reportformat);
                //var html = lr.Render("HTML5");


                Stream stream = new MemoryStream(renderedBytes);


                if (isfile == 0)
                {
                    Response.Headers.Add("Content-Disposition", "inline; filename=" + sFileName.Replace(".", "").Replace(" ", "").Replace(",", "").Replace("\t", "").Replace("\"", "") + "." + reportformat);

                    var fsResult = new FileStreamResult(stream, mimeType);
                    return fsResult;
                }
                else
                {

                    //return File(pdf, mimeType, "report." + reportformat);
                    //return File(html, mimeType, "report." + "html");


                    //public IActionResult OnPostGetHTML() => PrepareReport("HTML5", "html", "text/html"); reportformat // extension




                    //Response.AddHeader("content-disposition", ("attachment; filename=" + sFileName + "." + reportformat)); //
                    //Response.Headers.Add("content-disposition", ("open; filename=" + sFileName + "." + reportformat)); //

                    Response.Headers.Add("content-disposition", "attachment; filename=" + sFileName + "." + reportformat); //
                    return File(renderedBytes, mimeType);
                }

                //errorlog("6th LINE");

                //var abc = File(renderedBytes, mimeType);

                //pdfModel abcdef = new pdfModel { pdfid = "testpdf", pdffile = renderedBytes };
                //return View("getpdf", abcdef);




            }
            catch (Exception ex)
            {


                errorlog(ex);
                //var abc  = ex.StackTrace;
                //ViewData["ErrorProcedure"] = ex.Errors[i].Procedure;
                Console.WriteLine(ex.Message);
                throw ex;

            }
            finally
            {
                streams = null;
            }

        }


        public IActionResult Indextest(string reporttype = "PDF", int isfile = 0, AppData.AppDataDynamic ReportInfoabc = null)
        {
            string[] streams;
            try
            {
                //errorlog("report viewer start");

                LocalReport lr = new LocalReport();
                //errorlog("1ST LINE");


                clsConnectionNew clsCon = new clsConnectionNew();
                string mimeType = "application/pdf";

                //GTRDBContext dc = new GTRDBContext();

                DataTable dt = new DataTable();
                DataSet ds = new DataSet();

                string reportpath = "";
                string reportquery = "";
                //string reporttype = "PDF";
                string reportformat = "PDF";

                //reporttype = "HTML5";
                if (reporttype.ToString().ToUpper() == "EXCEL")
                {
                    reportformat = "xls";
                    mimeType = "application/vnd.ms-excel";
                }
                else if (reporttype.ToString().ToUpper() == "WORD")
                {
                    reportformat = "doc";
                    //mimeType = "application/msword";
                    mimeType = "application/vnd.openxmlformats-officedocument.wordprocessingml.document";

                }
                else if (reporttype.ToString().ToUpper() == "HTML5")
                {
                    reportformat = "html";
                    mimeType = "text/html";
                }
                else if (reporttype.ToString().ToUpper() == "IMAGE")
                {

                    reportformat = "jpeg";
                    mimeType = "image/jpeg";
                }
                else if (reporttype.ToString().ToUpper() == "Browser")
                {
                    //reportformat = "html";
                    //mimeType = "text/html";
                }
                else if (reporttype.ToString().ToUpper() == "JSON")
                {
                    // .json JSON format application/ json
                    reportformat = "json";
                    mimeType = "application/json";
                }
                else
                {
                    reportformat = "pdf";
                    mimeType = "application/pdf";
                }


                //if (Session["DisplayName"] == null)
                //{
                //    return RedirectToRoute("GTR");
                //}


                //ReportInfoabc.ReportType;
                if (ReportInfoabc.ReportPath != null)
                {
                    reportpath = ReportInfoabc.ReportPath;
                    HttpContext.Session.SetString("ReportPath", "");
                }
                if (ReportInfoabc.ReportQuery != null)
                {
                    reportquery = ReportInfoabc.ReportQuery;
                    //HttpContext.Session.SetString("ReportQuery","");
                }
                if (ReportInfoabc.ReportQuery != null)
                {
                    reportquery = ReportInfoabc.ReportQuery;
                    //HttpContext.Session.SetString("ReportQuery","");
                }
                if (ReportInfoabc.ReportType != null)
                {
                    reporttype = ReportInfoabc.ReportType;

                    if (reporttype.ToString().ToUpper() == "EXCEL")
                    {
                        reportformat = "xls";
                        mimeType = "application/vnd.ms-excel";
                    }
                    else if (reporttype.ToString().ToUpper() == "WORD")
                    {
                        reportformat = "doc";
                        mimeType = "application/vnd.openxmlformats-officedocument.wordprocessingml.document";
                    }
                    else if (reporttype.ToString().ToUpper() == "HTML5")
                    {
                        reportformat = "html";
                        mimeType = "text/html";
                    }
                    else if (reporttype.ToString().ToUpper() == "IMAGE")
                    {
                        reportformat = "jpeg";
                        mimeType = "image/jpeg";
                    }
                    else if (reporttype.ToString().ToUpper() == "JSON")
                    {
                        reportformat = "json";
                        mimeType = "application/json";
                    }
                    else
                    {
                        reportformat = "pdf";
                        mimeType = "application/pdf";
                    }
                }

                //errorlog("2nd LINE");

                //Session["ReportType"] = "";

                //LocalReport lr = new LocalReport();
                //string path = Path.Combine(Server.MapPath(reportpath));
                //string path = Path.Combine(_hostingEnvironment.ContentRootPath + "//ReportViewer/Accounts/rptCOA.rdlc");
                //string path = Path.Combine("localhost/anjerptest/" + reportpath.Replace("~", ""));//_hostingEnvironment.ContentRootPath + 


                string path = "." + reportpath.Replace("~", "");//_hostingEnvironment.ContentRootPath + 


                //"~/ReportViewer/coatree.rdlc";

                //errorlog(path);

                //errorlog("3rd LINE");

                try
                {
                    if (System.IO.File.Exists(path))
                    {
                        lr.ReportPath = path;




                        TempData["Message"] = "Report Preview Successfully";
                        TempData["Status"] = "1";
                        tranlog.TransactionLog(RouteData.Values["controller"].ToString(), RouteData.Values["action"].ToString(), TempData["Message"].ToString(), "0", "Create", path + " - " + reportquery.ToString());



                    }
                    //else
                    //{
                    //    errorlog(path + " - location not found - path not found - report viewer");
                    //    return View("Index");

                    //}
                }
                catch (Exception ex)
                {
                    errorlog(path + " - location not found - path not found - report viewer");
                    throw new Exception(ex.Message, ex.InnerException);
                }


                //errorlog("exist ok LINE");



                lr.EnableExternalImages = true;

                clsCon.GTRFillDatasetWithSQLCommand(ref ds, reportquery);

                dt = ds.Tables[0];

                ReportDataSource rd = new ReportDataSource();
                rd.Name = "DataSet1";
                rd.Value = dt;

                lr.DataSources.Add(rd);
                lr.SubreportProcessing += new SubreportProcessingEventHandler(prcProcessSubReport);
                //reportType = "PDF";



                string encoding;
                string fileNameExtension = reportformat;

                ReportPageSettings aPageSettings = lr.GetDefaultPageSettings();
                int width = aPageSettings.PaperSize.Width;
                int height = aPageSettings.PaperSize.Height;
                int margintop = aPageSettings.Margins.Top;
                int marginbottom = aPageSettings.Margins.Bottom;
                int marginleft = aPageSettings.Margins.Left;
                int marginright = aPageSettings.Margins.Right;

                //new LocalReport().EnableExternalImages = true;

                // errorlog("4th LINE");
                string deviceInfo =

                    "<DeviceInfo>" +
                    "  <OutputFormat>" + "PDF" + "</OutputFormat>" +
                    "  <PageWidth>" + width + "</PageWidth>" +
                    "  <PageHeight>" + height + "</PageHeight>" +
                    "  <MarginTop>" + margintop + "</MarginTop>" +
                    "  <MarginLeft>" + marginleft + "</MarginLeft>" +
                    "  <MarginRight>" + marginright + "</MarginRight>" +
                    "  <MarginBottom>" + marginbottom + "</MarginBottom>" +
                    "</DeviceInfo>";

                Warning[] warnings;
                //string[] streams;
                byte[] renderedBytes;

                lr.DisplayName = "GTR_Report";

                renderedBytes = lr.Render(
                    reporttype,
                    deviceInfo,
                    out mimeType,
                    out encoding,
                    out fileNameExtension,
                    out streams,
                    out warnings
                    );





                var sFileName = ReportInfoabc.PrintFileName + "_" + DateTime.Now.ToString("yyyyMMdd");


                //errorlog("5th LINE");

                ///Response.Buffer = true;
                Response.Clear();
                Response.ContentType = mimeType;
                //Response.Headers.Add("Content-Disposition", "inline; filename=" + sFileName.Replace(".", "").Replace(" ", "").Replace(",", "").Replace("\t", "").Replace("\"", "") + "." + reportformat);


                //var pdf = lr.Render(reportformat);
                //var html = lr.Render("HTML5");


                MemoryStream stream = new MemoryStream(renderedBytes);


                if (isfile == 0)
                {
                    Response.Headers.Add("Content-Disposition", "inline; filename=" + sFileName.Replace(".", "").Replace(" ", "").Replace(",", "").Replace("\t", "").Replace("\"", "") + "." + reportformat);

                    var fsResult = new FileStreamResult(stream, mimeType);
                    Clear(stream);

                    return fsResult;
                }
                else
                {

                    //return File(pdf, mimeType, "report." + reportformat);
                    //return File(html, mimeType, "report." + "html");


                    //public IActionResult OnPostGetHTML() => PrepareReport("HTML5", "html", "text/html"); reportformat // extension




                    //Response.AddHeader("content-disposition", ("attachment; filename=" + sFileName + "." + reportformat)); //
                    //Response.Headers.Add("content-disposition", ("open; filename=" + sFileName + "." + reportformat)); //

                    Response.Headers.Add("content-disposition", "attachment; filename=" + sFileName + "." + reportformat); //
                    return File(renderedBytes, mimeType);
                }

                //errorlog("6th LINE");

                //var abc = File(renderedBytes, mimeType);

                //pdfModel abcdef = new pdfModel { pdfid = "testpdf", pdffile = renderedBytes };
                //return View("getpdf", abcdef);




            }
            catch (Exception ex)
            {


                errorlog(ex);
                Console.WriteLine(ex.Message);
                throw ex;

            }
            finally
            {
                streams = null;
            }

        }

        public static void Clear(MemoryStream ms)
        {
            var buffer = ms.GetBuffer();
            Array.Clear(buffer, 0, buffer.Length);
            ms.Position = 0;
            ms.SetLength(0);
            ms.Capacity = 0; // <<< this one ******
        }

        public ActionResult Create()
        {

            errorlog("report viewer create");

            return View("Create");
        }


        private void prcProcessSubReport(object sender, SubreportProcessingEventArgs e)
        {
            //Declare a data table
            DataTable dtSub = new DataTable();
            string sqlQuery = "", param = "";

            prcGetSubReportDetails(e.ReportPath);
            param = strRFN.Length == 0 ? "" : e.Parameters[strRFN].Values[0].ToString();
            //sqlQuery = strQuery + " " + param;


            sqlQuery = strQuery.Replace("xxxx", param);



            //Ready a datatable for report based on parameter data
            if (sqlQuery != "")
            {
                dtSub = prcGetDataSub(sqlQuery);

                //Processing sub report data
                // e.DataSources.Add(new ReportDataSource(strDSN, dtSub)); //old

                ReportDataSource rpd = new ReportDataSource();
                rpd.Name = strDSN;
                rpd.Value = dtSub;
                e.DataSources.Add(rpd);

            }
            //            this.Page.Title = "final checking title";
        }

        private DataTable prcGetDataSub(string strQuery)
        {
            //System.Data.DataSet 
            DataSet ds = new DataSet();
            clsConnectionNew clsCon = new clsConnectionNew();
            try
            {
                //SQL Query (Here i use Store procedure)
                if (strQuery.Length > 5)
                {
                    clsCon.GTRFillDatasetWithSQLCommand(ref ds, strQuery);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                clsCon = null;
            }
            if (strQuery.Length > 5)
            {
                return ds.Tables[0];
            }
            else
            {
                DataTable abc = new DataTable();

                return abc;
            }
        }

        private void prcGetSubReportDetails(string rptPath)
        {
            //Session["MyArrayList"] = new ArrayList();
            Dictionary<int, dynamic> postData = new Dictionary<int, dynamic>();
            //ArrayList rptList = new ArrayList();

            //postData = Session["rptList"] as Dictionary<int, dynamic>;

            postData = HttpContext.Session.GetObject<Dictionary<int, dynamic>>("rptList");

            if (postData != null)
            {
                foreach (var lst in postData)
                {

                    string abcd = lst.Value.strRptPathSub;

                    if (abcd.ToUpper() == rptPath.ToUpper())
                    {
                        strDSN = lst.Value.strDSNSub;
                        strQuery = lst.Value.strQuerySub;
                        strRFN = lst.Value.strRFNSub;
                    }
                }
            }
            //foreach (var lst in postData)
            //{
            //}

            //subrp = "rptInvoice_PM";
            //strDSN = "DataSet1";
            //strQuery = "Exec custbill_corporate.dbo.rptInvoice_PM 65,1";
            //strRFN = "";



            //foreach (var lst in Common.Classes.clsReport.rptList)
            //{
            //    if (lst.strRptPathSub.ToUpper() == rptPath.ToUpper())
            //    {
            //        strDSN = lst.strDSNSub;
            //        strQuery = lst.strQuerySub;
            //        strRFN = lst.strRFNSub;
            //    }
            //}

        }
    }
}
