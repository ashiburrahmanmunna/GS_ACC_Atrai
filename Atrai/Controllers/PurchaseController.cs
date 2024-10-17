using Atrai.Core.Common;
using Atrai.Data.Interfaces;
using Atrai.Data.Repository;
using Atrai.Model.Core.Entity;
using Atrai.Services;
using DataTablesParser;
using Invoice.Core.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using static Atrai.Controllers.SalesController;
using static Atrai.Controllers.ValuesController;

namespace Atrai.Controllers
{
    [Authorize]
    [OverridableAuthorize]
    public class PurchaseController : Controller
    {
        public TransactionLogRepository tranlog { get; }

        private readonly ISupplierRepository _supplierRepository;
        private readonly IUserAccountRepository UserAccountRepository;
        private readonly ICountryRepository _countryRepository;
        private readonly IPurchaseTagsRepository _purchaseTagsRepository;
        private readonly ICustomFormStyleRepository _customFormStyleRepository;
        private readonly ITransactionRepository _accountsDailyTransaction;
        private readonly IDocPrefixRepository docPrefixRepository;

        private readonly IPurchaseRepository _purchaseRepository;
        private readonly IPurchaseItemsRepository _purchaseItemRepository;
        private readonly IPurchaseItemsCategoryRepository _purchaseItemCategoryRepository;
        private readonly IPurchaseReturnItemsRepository _purchaseReturnItemRepository;
        private IEmailSender _emailsender { get; }
        private readonly IPurchaseBatchItemsRepository _purchaseBatchItemRepository;
        private readonly IWebHostEnvironment _webHostEnvironment;
        private readonly IRecurringDetailsRepository recurringDetailsRepository;


        private readonly IPurchasePaymentRepository _purchasePaymentRepository;
        private readonly ITransactionRepository _transactionRepository;
        private readonly ITermMainRepository termMainRepository;


        private readonly IStoreSettingRepository storeSettingRepository;
        private readonly IConfiguration configuration;
        private readonly ICompanyRepository companyRepository;
        private readonly ICategoryRepository categoryRepository;
        private readonly IUnitRepository _unitRepository;

        private readonly IProductRepository productRepository;
        private readonly IWarehouseRepository warehouseRepository;
        private readonly IFromWarehousePermissionRepository FromWarehousePermissionRepository;
        private readonly IToWarehousePermissionRepository ToWarehousePermissionRepository;

        private readonly ITermsSubRepository _termsSubRepository;


        private readonly IAccountHeadRepository accountHeadRepository;
        private readonly IPaymentTypeRepository paymentTypeRepository;
        private readonly IAccountHeadPermissionRepository AccountHeadPermissionRepository;

        private readonly IDocTypeRepository _docTypeRepository;
        private readonly IPurchaseTermsRepository purchaseTermsRepository;
        private readonly IAuditLogRepository auditLogRepository;
        private readonly IPurchaseProductTaxRepository _purchaseProductRepository;
        //private readonly IpaymentTypesRepository paymentTypesRepository;

        public static string ExpressionParameterizationException { get; }
        Dictionary<int, dynamic> postData = new Dictionary<int, dynamic>();


        public PurchaseController(ISupplierRepository supplierRepository, IPurchaseRepository purchaseRepository,
            IPurchaseItemsRepository purchaseItemRepository, IPurchaseBatchItemsRepository purchaseBatchItemRepository, IPurchasePaymentRepository purchasePaymentRepository, IWebHostEnvironment webHostEnvironment,
            IStoreSettingRepository storeSettingRepository, IRecurringDetailsRepository recurringDetailsRepository, IDocPrefixRepository docPrefixRepository,
            ICategoryRepository categoryRepository, IUnitRepository unitRepository, IProductRepository productRepository, ITermMainRepository termMainRepository,
            IWarehouseRepository warehouseRepository, IFromWarehousePermissionRepository FromWarehousePermissionRepository, IToWarehousePermissionRepository ToWarehousePermissionRepository, IAccountHeadRepository accountHeadRepository, IPurchaseProductTaxRepository purchaseProductRepository,
            IPaymentTypeRepository paymentTypeRepository, ICompanyRepository companyRepository, IPurchaseTermsRepository purchaseTermsRepository, IAuditLogRepository auditLogRepository,
            IConfiguration configuration, TransactionLogRepository tranlogRepository, IUserAccountRepository userAccountRepository, IDocTypeRepository docTypeRepository, IPurchaseReturnItemsRepository purchaseReturnItemRepository, ITransactionRepository transactionRepository, IPurchaseItemsCategoryRepository purchaseItemCategoryRepository, IAccountHeadPermissionRepository accountHeadPermissionRepository, ICountryRepository countryRepository, IPurchaseTagsRepository purchaseTagsRepository, ICustomFormStyleRepository customFormStyleRepository, IEmailSender emailsender, ITransactionRepository accountsDailyTransaction, ITermsSubRepository termsSubRepository)
        {
            this.configuration = configuration;
            _supplierRepository = supplierRepository;
            _purchaseRepository = purchaseRepository;
            _purchaseItemRepository = purchaseItemRepository;
            _purchaseItemCategoryRepository = purchaseItemCategoryRepository;
            _purchaseBatchItemRepository = purchaseBatchItemRepository;
            _purchaseTagsRepository = purchaseTagsRepository;
            _purchasePaymentRepository = purchasePaymentRepository;
            _transactionRepository = transactionRepository;
            this.recurringDetailsRepository = recurringDetailsRepository;
            this.storeSettingRepository = storeSettingRepository;
            this.companyRepository = companyRepository;
            this.categoryRepository = categoryRepository;
            _unitRepository = unitRepository;
            this.auditLogRepository = auditLogRepository;
            _purchaseProductRepository = purchaseProductRepository;
            this.docPrefixRepository = docPrefixRepository;
            this.productRepository = productRepository;
            this.warehouseRepository = warehouseRepository;
            this.FromWarehousePermissionRepository = FromWarehousePermissionRepository;
            this.ToWarehousePermissionRepository = ToWarehousePermissionRepository;
            this.purchaseTermsRepository = purchaseTermsRepository;
            this.termMainRepository = termMainRepository;

            this.accountHeadRepository = accountHeadRepository;
            this.paymentTypeRepository = paymentTypeRepository;
            tranlog = tranlogRepository;
            UserAccountRepository = userAccountRepository;
            _docTypeRepository = docTypeRepository;
            _purchaseReturnItemRepository = purchaseReturnItemRepository;
            AccountHeadPermissionRepository = accountHeadPermissionRepository;
            _countryRepository = countryRepository;
            _webHostEnvironment = webHostEnvironment;
            _customFormStyleRepository = customFormStyleRepository;
            _emailsender = emailsender;
            _accountsDailyTransaction = accountsDailyTransaction;
            _termsSubRepository = termsSubRepository;
        }

        public IActionResult ExchangeList()
        {
            ViewBag.FromDate = DateTime.Now.Date;
            ViewBag.ToDate = DateTime.Now.Date;

            ViewBag.Suppliers = _supplierRepository.GetAllForDropDown();

            return View();
        }

        public IActionResult Index(string filter = "All")
        {
            ViewBag.FromDate = DateTime.Now.Date;
            ViewBag.ToDate = DateTime.Now.Date;

            ViewBag.Suppliers = _supplierRepository.GetAllForDropDown();
            ViewBag.Users = UserAccountRepository.GetAllForDropDown();
            ViewBag.Category = categoryRepository.GetAllForDropDown();
            ViewBag.DocType = _docTypeRepository.GetPurchaseDocForDropDown();


            var sessionLuserId = (HttpContext.Session.GetInt32("UserId"));
            var UserRole = HttpContext.Session.GetString("UserRole");

            if (UserRole == "Admin" || UserRole == "SuperAdmin")
            {
                ViewBag.Users = UserAccountRepository.GetAllForDropDown();
            }
            else
            {
                ViewBag.Users = UserAccountRepository.CurrentUserAccountForDropdown();
            }


            ViewBag.filter = filter;

            var arrayabc = FromWarehousePermissionRepository.All().Where(x => x.LuserIdAllow == sessionLuserId).Select(x => x.WarehouseId).ToList();


            if (arrayabc.Count() > 0)
            {
                ViewBag.Warehouse = FromWarehousePermissionRepository.All().Where(p => arrayabc.Contains(p.WarehouseId))
                    .Select(x => new SelectListItem
                    {
                        Text = x.WarehouseList.WhShortName,
                        Value = x.WarehouseList.Id.ToString()
                    });

            }
            else
            {
                ViewBag.Warehouse = warehouseRepository.GetWarehouseLedgerHeadForDropDown();
            }


            //ViewBag.FromDate = DateTime.Now.Date.ToString("dd-MMM-yy");

            //int abcd = HttpContext.Session.GetInt32("ComId");
            //return View(_purchaseRepository.All().Include(x=>x.SupplierModel).OrderByDescending(x=>x.Id));
            return View();
        }



        public IActionResult PurchaseDetailsViewList()
        {
            ViewBag.FromDate = DateTime.Now.Date;
            ViewBag.ToDate = DateTime.Now.Date;

            ViewBag.Supplier = _supplierRepository.GetAllForDropDown();
            ViewBag.Category = categoryRepository.GetAllForDropDown();
            ViewBag.DocType = _docTypeRepository.GetSalesDocForDropDown();


            var sessionLuserId = (HttpContext.Session.GetInt32("UserId"));
            var UserRole = HttpContext.Session.GetString("UserRole");

            if (UserRole == "Admin" || UserRole == "SuperAdmin")
            {
                ViewBag.Users = UserAccountRepository.GetAllForDropDown();
            }
            else
            {
                ViewBag.Users = UserAccountRepository.CurrentUserAccountForDropdown();
            }


            //ViewBag.filter = filter;

            SelectListItem abc = new SelectListItem() { Text = "Please Select", Value = "" };

            var x = FromWarehousePermissionRepository.GetAllForDropDown();
            if (x.Count() == 0)
            {
                x = warehouseRepository.GetWarehouseLedgerHeadForDropDown();
            }
            else
            {
                x.Append(abc);
            }

            ViewBag.Warehouse = x;

            return View();
        }


        [AllowAnonymous]
        //public IActionResult GetSalesDetailsList(string FromDate, string ToDate, int? CategoryId, int isAll , int? SalesRepId)
        public IActionResult GetPurchaseDetailsListViewReport(string FromDate, string ToDate, int? SupplierId, int? UserId, string Status, int? WarehouseId, int? CategoryId, int? DocTypeId)
        {
            try
            {

                var ComId = (HttpContext.Session.GetInt32("ComId"));
                var sessionLuserId = (HttpContext.Session.GetInt32("UserId"));
                var UserRole = HttpContext.Session.GetString("UserRole");
                int? vatview = HttpContext.Session.GetInt32("VatViewActivate");


                DateTime dtFrom = Convert.ToDateTime(DateTime.Now.Date);
                DateTime dtTo = Convert.ToDateTime(DateTime.Now.Date);

                if (FromDate == null || FromDate == "")
                {
                }
                else
                {
                    dtFrom = Convert.ToDateTime(FromDate);
                }
                if (ToDate == null || ToDate == "")
                {
                }
                else
                {
                    dtTo = Convert.ToDateTime(ToDate);
                }



                var productlist = _purchaseItemRepository.All();
                var productreturnlist = _purchaseReturnItemRepository.All();

                //.Include(x => x.BatchSerialItems);

                //var productlist = saleItemRepository.All()
                //    .Include(x=>x.Product).ThenInclude(x=>x.Category)
                //    .Include(x=>x.PurchaseModel)
                //    .Include(x=>x.BatchSerialItems);


                ///.Include(x => x.Product).ThenInclude(x => x.Category).Include(x => x.PurchaseModel)

                //if (y.ToString().Length > 0)
                //{


                //}
                //else
                {
                    if (UserRole == "Admin" || UserRole == "SuperAdmin")
                    {
                        productlist = productlist.Where(p => (p.PurchaseModel.PurchaseDate >= dtFrom && p.PurchaseModel.PurchaseDate <= dtTo));
                        productreturnlist = productreturnlist.Where(p => (p.PurchaseReturnModel.PurchaseReturnDate >= dtFrom && p.PurchaseReturnModel.PurchaseReturnDate <= dtTo));


                    }
                    else
                    {
                        var storesettings = storeSettingRepository.All().FirstOrDefault();
                        if (storesettings.isBackDatePermission == true)
                        {
                            dtTo = Convert.ToDateTime(DateTime.Now.Date);
                            DateTime dtFromwithprevdate = Convert.ToDateTime(DateTime.Now.Date.AddDays(-storesettings.Days));

                            if (dtFrom < dtFromwithprevdate)
                            {
                                dtFrom = dtFromwithprevdate;
                            }
                        }

                        productlist = productlist.Where(p => (p.PurchaseModel.PurchaseDate >= dtFrom && p.PurchaseModel.PurchaseDate <= dtTo));
                        //productlist = productlist.Where(p => p.LuserId == sessionLuserId);


                        productreturnlist = productreturnlist.Where(p => (p.PurchaseReturnModel.PurchaseReturnDate >= dtFrom && p.PurchaseReturnModel.PurchaseReturnDate <= dtTo));
                        //productreturnlist = productreturnlist.Where(p => p.LuserId == sessionLuserId);

                    }



                    //if (CategoryId != null)
                    //{
                    //    productlist = productlist.Where(p => p.Product.CategoryId == CategoryId);

                    //}
                    if (SupplierId != null)
                    {
                        productlist = productlist.Where(p => p.PurchaseModel.SupplierId == SupplierId);
                        productreturnlist = productreturnlist.Where(p => p.PurchaseReturnModel.SupplierId == SupplierId);

                    }
                    if (CategoryId != null)
                    {
                        productlist = productlist.Where(p => p.Product.CategoryId == CategoryId);
                        productreturnlist = productreturnlist.Where(p => p.Product.CategoryId == CategoryId);

                    }
                    if (DocTypeId != null)
                    {
                        productlist = productlist.Where(p => p.PurchaseModel.DocTypeId == DocTypeId);
                        //productreturnlist = productreturnlist.Where(p => p.PurchaseReturnModel.DocTypeId == DocTypeId);

                    }


                    if (UserId != null)
                    {
                        productlist = productlist.Where(p => p.LuserId == UserId);
                        productreturnlist = productreturnlist.Where(p => p.LuserId == UserId);

                    }
                    if (WarehouseId != null)
                    {
                        productlist = productlist.Where(p => p.WarehouseId == WarehouseId);
                        productreturnlist = productreturnlist.Where(p => p.WarehouseId == WarehouseId);

                    }

                    //if (PurchaseRepId != null)
                    //{
                    //    productlist = productlist.Where(p => p.PurchaseModel.PurchaseRepId == PurchaseRepId);
                    //    productreturnlist = productreturnlist.Where(p => p.PurchaseReturnModel.PurchaseRepId == PurchaseRepId);

                    //}



                    productlist = productlist.Where(p => (p.PurchaseModel.PurchaseDate >= dtFrom && p.PurchaseModel.PurchaseDate <= dtTo));
                    productreturnlist = productreturnlist.Where(p => (p.PurchaseReturnModel.PurchaseReturnDate >= dtFrom && p.PurchaseReturnModel.PurchaseReturnDate <= dtTo));


                }



                var query = from e in productlist.Include(x => x.Product).ThenInclude(x => x.Category).Include(x => x.PurchaseModel)
                            select new PurchaseDetailsResultList()
                            {
                                Id = e.Id,
                                PurchaseCode = e.PurchaseModel.PurchaseCode,
                                PurchaseDate = e.PurchaseModel.PurchaseDate.ToString("dd-MMM-yy"),
                                PurchaseDateOrg = e.PurchaseModel.PurchaseDate,

                                SupplierName = (e.PurchaseModel.SupplierName.Length == 0 || e.PurchaseModel.SupplierName == null) ? e.PurchaseModel.SupplierModel.SupplierName : e.PurchaseModel.SupplierModel.SupplierName + " - " + e.PurchaseModel.SupplierName,
                                SupplierAddress = (e.PurchaseModel.PrimaryAddress.Length == 0 || e.PurchaseModel.PrimaryAddress == null) ? e.PurchaseModel.SupplierModel.PrimaryAddress : e.PurchaseModel.SupplierModel.PrimaryAddress + " - " + e.PurchaseModel.PrimaryAddress,
                                SupplierMobileNo = (e.PurchaseModel.PhoneNo.Length == 0 || e.PurchaseModel.PhoneNo == null) ? e.PurchaseModel.SupplierModel.Phone : e.PurchaseModel.SupplierModel.Phone + " - " + e.PurchaseModel.PhoneNo,
                                CategoryName = e.Product.Category.Name,
                                ProductName = e.Product.Name,
                                ProductCode = e.Product.Code,
                                BrandName = e.Product.Brand != null ? e.Product.Brand.BrandName : "",
                                ModelName = e.Product.ModelName,
                                SizeName = e.Product.SizeName,
                                ColorName = e.Product.ColorName,
                                WarehouseName = e.vWarehouse.WhShortName,

                                PurchaseBatchItems = e.PurchaseBatchItems.Select(x => new
                                {
                                    x.BatchSerialNo,
                                    x.IsUsed
                                }).ToList(),

                                Quantity = e.Quantity,
                                PurchasePrice = e.Quantity * Math.Round(e.Price, 2),//e.PurchaseBatchItems == null e.Price,
                                //CostPrice = e.Quantity * Math.Round(e.CostPrice, 2),//e.PurchaseBatchItems == null e.Price,
                                //IndDiscountProportion = e.Quantity * Math.Round(e.IndDiscountProportion, 2),
                                //IndDiscountProportion = Math.Round(e.IndDiscountProportion, 2),
                                //Profit = e.Quantity * Math.Round((e.Price - (e.CostPrice + (e.IndDiscountProportion / e.Quantity))), 2),
                                //PurchaseRepName = e.PurchaseModel.PurchaseRep.EmployeeName,
                                //PurchaseRepCommission = e.CommissionAmount,
                                //TotalPurchaseRepCommission = e.CommissionAmount * e.Quantity,

                                //PurchasePrice = e.PurchaseItems.Price,
                                //WarrentyName = e.Products.Warrenty.Name,
                                //WarrentyDay = e.Products.Warrenty.Day,
                                //ProductAge = (DateTime.Now.Date - e.PurchaseModel.PurchaseDate).Days,
                                //ProductAge = null,//(DateTime.Now.Date - DateTime.Parse("12-june-21").Date).Days.ToString(),
                                Purchasedateformat = e.PurchaseModel.PurchaseDate


                                //PurchaseDate = e.PurchaseDate,
                                //PurchaseDate = e.PurchaseItems.PurchaseModel.PurchaseDate.ToString("dd-MMM-yy")


                            };


                var returnquery = from e in productreturnlist.Include(x => x.Product).ThenInclude(x => x.Category).Include(x => x.PurchaseReturnModel)
                                  select new PurchaseDetailsResultList()
                                  {
                                      Id = e.Id,
                                      PurchaseCode = e.PurchaseReturnModel.PurchaseReturnCode,
                                      PurchaseDate = e.PurchaseReturnModel.PurchaseReturnDate.ToString("dd-MMM-yy"),
                                      PurchaseDateOrg = e.PurchaseReturnModel.PurchaseReturnDate,
                                      SupplierName = (e.PurchaseReturnModel.SupplierName.Length == 0 || e.PurchaseReturnModel.SupplierName == null) ? e.PurchaseReturnModel.SupplierModel.SupplierName : e.PurchaseReturnModel.SupplierModel.SupplierName + " - " + e.PurchaseReturnModel.SupplierName,
                                      SupplierAddress = (e.PurchaseReturnModel.PrimaryAddress.Length == 0 || e.PurchaseReturnModel.PrimaryAddress == null) ? e.PurchaseReturnModel.SupplierModel.PrimaryAddress : e.PurchaseReturnModel.SupplierModel.PrimaryAddress + " - " + e.PurchaseReturnModel.PrimaryAddress,
                                      SupplierMobileNo = (e.PurchaseReturnModel.PhoneNo.Length == 0 || e.PurchaseReturnModel.PhoneNo == null) ? e.PurchaseReturnModel.SupplierModel.Phone : e.PurchaseReturnModel.SupplierModel.Phone + " - " + e.PurchaseReturnModel.PhoneNo,
                                      CategoryName = e.Product.Category.Name,
                                      ProductName = e.Product.Name,
                                      ProductCode = e.Product.Code,
                                      BrandName = e.Product.Brand != null ? e.Product.Brand.BrandName : "",
                                      ModelName = e.Product.ModelName,
                                      SizeName = e.Product.SizeName,
                                      ColorName = e.Product.ColorName,
                                      WarehouseName = e.vWarehouse.WhShortName,

                                      Quantity = -e.Quantity,
                                      PurchasePrice = -e.Quantity * Math.Round(e.Price, 2),//e.PurchaseBatchItems == null e.Price,
                                                                                           //CostPrice = -e.Quantity * Math.Round(e.CostPrice, 2),//e.PurchaseBatchItems == null e.Price,
                                                                                           //IndDiscountProportion = e.Quantity * Math.Round(e.IndDiscountProportion, 2),
                                                                                           //IndDiscountProportion = -Math.Round(e.IndDiscount, 2),
                                                                                           //Profit = -(e.Quantity * Math.Round((e.Price - (e.CostPrice + (e.IndDiscount / e.Quantity))), 2)),
                                                                                           //PurchaseRepName = e.PurchaseReturnModel.PurchaseRep.EmployeeName,
                                                                                           //PurchaseRepCommission = -e.CommissionAmount,
                                                                                           //TotalPurchaseRepCommission = -(e.CommissionAmount * e.Quantity),
                                                                                           //PurchasePrice = e.PurchaseItems.Price,
                                                                                           //WarrentyName = e.Products.Warrenty.Name,
                                                                                           //WarrentyDay = e.Products.Warrenty.Day,
                                                                                           //ProductAge = (DateTime.Now.Date - e.PurchaseModel.PurchaseDate).Days,
                                                                                           //ProductAge = null,//(DateTime.Now.Date - DateTime.Parse("12-june-21").Date).Days.ToString(),
                                      Purchasedateformat = e.PurchaseReturnModel.PurchaseReturnDate


                                      //PurchaseDate = e.PurchaseDate,
                                      //PurchaseDate = e.PurchaseItems.PurchaseModel.PurchaseDate.ToString("dd-MMM-yy")


                                  };





                var abc = query.ToList();


                //var parser = new Parser<PurchaseDetailsResultList>(Request.Form, query);

                //var returnparser = new Parser<PurchaseDetailsResultList>(Request.Form, returnquery);

                //var abc = parser.Parse();
                //var xyz = returnparser.Parse();

                //abc.data.AddRange(xyz.data);
                var xyz = returnquery.ToList();

                abc.AddRange(xyz);


                return Json(new { Success = 1, data = abc.OrderBy(x => x.PurchaseDateOrg) });


                //return Json(parser.Parse());

                //return Json(parser.Parse());

            }
            catch (Exception ex)
            {
                return Json(new { Success = "0", error = ex.Message });
                //throw ex;
            }

        }


        public class PurchaseDetailsResultList
        {
            public int Id { get; set; }
            public string? PurchaseCode { get; set; }
            public string? PurchaseDate { get; set; }
            public DateTime PurchaseDateOrg { get; set; }



            public string? SupplierName { get; set; }
            public string? SupplierMobileNo { get; set; }
            public string? SupplierAddress { get; set; }
            public string? CategoryName { get; set; }

            public string? ProductName { get; set; }
            public string? ProductCode { get; set; }


            public string? ModelName { get; set; }
            public string? SizeName { get; set; }
            public string? ColorName { get; set; }


            public string? BrandName { get; set; }

            public string? WarehouseName { get; set; }




            public string? BatchSerialNo { get; set; }



            public double? PurchasePrice { get; set; }
            public double CostPrice { get; set; }
            public double Profit { get; set; }
            public double IndDiscountProportion { get; set; }
            public double Quantity { get; set; }



            public DateTime? Purchasedateformat { get; set; }

            public string? PurchaseRepName { get; set; }
            public double PurchaseRepCommission { get; set; }
            public double TotalPurchaseRepCommission { get; set; }

            public object PurchaseBatchItems { get; set; }
            //public virtual List<PurchaseBatchItemList> PurchaseBatchItems { get; set; }



        }

        //public class PurchaseBatchItemList
        //{
        //    //public int Id { get; set; }
        //    public string? BatchSerialNo { get; set; }
        //    public bool IsUsed { get; set; }

        //}


        [HttpGet]
        public IActionResult HTMLBarcodePrint()
        {
            return View();
        }

        [HttpGet]
        public IActionResult JqueryBarcodePrint()
        {

            return View();
        }

        [AllowAnonymous]
        [HttpPost, ActionName("AllPurchaseReport")]

        public JsonResult AllPurchaseReport(string rptFormat, string action, string SupplierId, string UserId, string FromDate, string ToDate, string WarehouseId, string Status)
        {
            try
            {
                var ComId = HttpContext.Session.GetInt32("ComId");

                var reportname = "";
                var filename = "";
                string redirectUrl = "";
                if (action == "PrintPurchaseListWithItem")
                {
                    reportname = "rptPurchaseListWithItem";
                    filename = "Purchase_Details_List_" + DateTime.Now.Date;
                    HttpContext.Session.SetString("ReportQuery", "Exec Purchase_rptPurchaseDetailsList '" + ComId + "','" + FromDate + "','" + ToDate + "', '" + SupplierId + "' ,'" + WarehouseId + "' ,'" + UserId + "' , '" + Status + "' ");
                    HttpContext.Session.SetString("ReportPath", "~/ReportViewer/Purchase/" + reportname + ".rdlc");
                }
                //else if (action == "PrintProductListWithoutZero") /// mr. asif saheb requirement when he going for print.
                //{

                //    reportname = "rptProductList";
                //    filename = "Product_List_" + DateTime.Now.Date;
                //    HttpContext.Session.SetString("ReportQuery", "Exec Inv_rptProductList '" + ComId + "','" + FromDate + "','" + ToDate + "' '" + SupplierId + "' ,'" + WarehouseId + "','" + UserId + "' ,'" + Status + "' ");
                //    HttpContext.Session.SetString("ReportPath", "~/ReportViewer/Purchase/" + reportname + ".rdlc");
                //}


                HttpContext.Session.SetString("PrintFileName", filename.Replace(".", "").Replace(" ", "").Replace(",", "").Replace("\"", ""));


                string DataSourceName = "DataSet1";

                //HttpContext.Session.SetObject("Acc_rptList", postData);

                //Common.Classes.clsMain.intHasSubReport = 0;
                clsReport.strReportPathMain = HttpContext.Session.GetString("ReportPath");// Session["ReportPath"].ToString();
                clsReport.strQueryMain = HttpContext.Session.GetString("ReportQuery");
                clsReport.strDSNMain = DataSourceName;

                //var ConstrName = "ApplicationServices";
                //string callBackUrl = this.Url.Action("Index", "ReportViewer", new { reporttype = rptFormat }); //Repository.GenerateReport(clsReport.strReportPathMain, clsReport.strQueryMain, ConstrName, rptFormat);

                string callBackUrl = this.Url.Action("Index", "ReportViewer", new { reporttype = rptFormat });
                redirectUrl = callBackUrl;



                return Json(new { Url = redirectUrl });

            }

            catch (Exception ex)
            {
                // If Sucess== 0 then Unable to perform Save/Update Operation and send Exception to View as JSON
                return Json(new { Success = 0, ex = ex.InnerException.InnerException.Message.ToString() });
            }

            return Json(new { Success = 0, ex = new Exception("Unable to Open").Message.ToString() });
            //return RedirectToAction("Index");

        }



        public class ExchangeResultList : PurchaseBatchItemsModel
        {
            public string? ProductName { get; set; }
            public string? SupplierName { get; set; }
            public string? PurchaseCode { get; set; }

            public string? PurchaseDateString { get; set; }
            public string? ExchangeDateString { get; set; }




        }


        [AllowAnonymous]
        public JsonResult GetExchangeList(string FromDate, string ToDate, int? SupplierId)
        {
            try
            {


                DateTime dtFrom = Convert.ToDateTime(DateTime.Now.Date);
                DateTime dtTo = Convert.ToDateTime(DateTime.Now.Date);

                if (FromDate == null || FromDate == "")
                {
                }
                else
                {
                    dtFrom = Convert.ToDateTime(FromDate);
                }
                if (ToDate == null || ToDate == "")
                {
                }
                else
                {
                    dtTo = Convert.ToDateTime(ToDate);
                }

                Microsoft.Extensions.Primitives.StringValues y = "";
                var x = Request.Form.TryGetValue("search[value]", out y);

                var seriallist = _purchaseBatchItemRepository.All();


                if (y.ToString().Length > 0)
                {


                }
                else
                {
                    seriallist = seriallist.Where(p => (p.ExchangeDate >= dtFrom && p.ExchangeDate <= dtTo));

                }

                if (SupplierId != null)
                {
                    seriallist = seriallist.Where(p => p.SupplierId == SupplierId);

                }

                //var products= _context.Products.ToList();

                seriallist.Include(x => x.PurchaseItems).Include(x => x.Products);//.Include(x=>x.vUnit).Include(x=>x.Category);

                var query = from e in seriallist.Where(x => x.ExchangeSerialNo != null)//.Where(x => x.Id > 0 && x.ComId == ComId).OrderByDescending(x => x.Id) //let vAccountGroupHead = e.vAccountGroupHead.AccName
                            select new ExchangeResultList
                            {
                                Id = e.Id,
                                ExchangeSerialNo = e.ExchangeSerialNo,
                                BatchSerialNo = e.BatchSerialNo,
                                ProductName = e.PurchaseItems.Product.Name ?? "",
                                ExchangeDateString = e.ExchangeDate.ToString("dd-MMM-yy"),
                                PurchaseDateString = e.PurchaseItems.PurchaseModel.PurchaseDate.ToString("dd-MMM-yy"),
                                SupplierName = e.SupplierList.SupplierName ?? "",
                                PurchaseCode = e.PurchaseItems.PurchaseModel.PurchaseCode ?? "",
                                IsUsed = e.IsUsed

                            };

                var parser = new Parser<ExchangeResultList>(Request.Form, query);
                return Json(parser.Parse());
                //dynamic abcd = parser.Parse();
                //return Json(abcd);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        [HttpGet]
        [AllowAnonymous]
        public IActionResult AddPurchase()
        {

            ViewBag.ActionType = "Create";
            int PurchaseId = 0;
            ViewBag.Suppliers = _supplierRepository.GetAllForDropDown();
            ViewBag.Category = categoryRepository.GetAllForDropDown();
            ViewBag.Unit = _unitRepository.GetAllForDropDown();
            ViewBag.DocType = _docTypeRepository.GetPurchaseDocForDropDown();

            if (FromWarehousePermissionRepository.GetAllForDropDown().Count() > 0) { ViewBag.Warehouse = FromWarehousePermissionRepository.GetAllForDropDown(); } else { ViewBag.Warehouse = warehouseRepository.GetWarehouseLedgerHeadForDropDown(); }

            return View(model: PurchaseId);
        }


        [HttpGet]
        public IActionResult IMEIExchange()
        {

            PurchaseBatchItemsModel abc = new PurchaseBatchItemsModel();

            ViewBag.ActionType = "Create";
            ViewBag.Suppliers = _supplierRepository.GetAllForDropDown();

            return View(abc);
        }

        [HttpGet]
        public IActionResult EditIMEIExchange(int IMEIId)
        {

            var purcahsebatchitem = _purchaseBatchItemRepository.All().Where(x => x.Id == IMEIId)
                .Include(x => x.PurchaseItems).ThenInclude(x => x.Product)
                .Include(x => x.PurchaseItems).ThenInclude(x => x.PurchaseModel)

                .FirstOrDefault();

            var exchangeserialno = purcahsebatchitem.ExchangeSerialNo;
            var batchserialno = purcahsebatchitem.BatchSerialNo;


            purcahsebatchitem.BatchSerialNo = exchangeserialno;
            purcahsebatchitem.ExchangeSerialNo = batchserialno;
            purcahsebatchitem.ProductName = purcahsebatchitem.PurchaseItems.Product.Name;
            purcahsebatchitem.PurchaseInvoiceNo = purcahsebatchitem.PurchaseItems.PurchaseModel.PurchaseCode;
            purcahsebatchitem.PurchaseDate = purcahsebatchitem.PurchaseItems.PurchaseModel.PurchaseDate.ToString("dd-MMM-yy");





            ViewBag.ActionType = "Edit";
            ViewBag.Suppliers = _supplierRepository.GetAllForDropDown();

            return View("IMEIExchange", purcahsebatchitem);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult IMEIExchange(PurchaseBatchItemsModel model)
        {


            var purcahsebatchitem = _purchaseBatchItemRepository.Find(model.Id);

            purcahsebatchitem.ExchangeSerialNo = model.BatchSerialNo;
            purcahsebatchitem.ExchangeDate = model.ExchangeDate;
            purcahsebatchitem.SupplierId = model.SupplierId;
            purcahsebatchitem.BatchSerialNo = model.ExchangeSerialNo;


            _purchaseBatchItemRepository.Update(purcahsebatchitem, model.Id);


            TempData["Message"] = "Excahnge Information Updated Successfully";
            TempData["Status"] = "1";
            tranlog.TransactionLog(RouteData.Values["controller"].ToString(), RouteData.Values["action"].ToString(), TempData["Message"].ToString(), model.Id.ToString(), "Update", model.ExchangeSerialNo.ToString());


            return RedirectToAction("ExchangeList");

        }

        [HttpGet]
        public IActionResult AddPurchaseBatch()
        {

            ViewBag.ActionType = "Create";
            int PurchaseId = 0;
            ViewBag.Suppliers = _supplierRepository.GetAllForDropDown();
            if (FromWarehousePermissionRepository.GetAllForDropDown().Count() > 0) { ViewBag.Warehouse = FromWarehousePermissionRepository.GetAllForDropDown(); } else { ViewBag.Warehouse = warehouseRepository.GetWarehouseLedgerHeadForDropDown(); }

            ViewBag.Category = categoryRepository.GetAllForDropDown();
            ViewBag.Unit = _unitRepository.GetAllForDropDown();
            ViewBag.DocType = _docTypeRepository.GetPurchaseDocForDropDown();
            ViewBag.Currency = _countryRepository.GetCurrencyList();


            return View(model: PurchaseId);
        }



        public class PurchaseResultList : PurchaseModel
        {
            public string? StatusPosted { get; set; }
            public string? PurchaseDateString { get; set; }
            public string? PaymentHead { get; set; }

            public string? PurchaseUser { get; set; }

            public object PurchasePayments { get; set; }
            public object PurchaseItems { get; set; }


            public string? DocType { get; set; }
            public string? Location { get; set; }

        }

        //[HttpPost]
        [AllowAnonymous]
        public JsonResult GetPurchaseSummaryInfo(string FromDate, string ToDate, int? SupplierId, int? UserId)
        {
            try
            {

                DateTime dtFrom = Convert.ToDateTime(DateTime.Now.Date);
                DateTime dtTo = Convert.ToDateTime(DateTime.Now.Date);

                if (FromDate == null || FromDate == "")
                {
                }
                else
                {
                    dtFrom = Convert.ToDateTime(FromDate);
                }
                if (ToDate == null || ToDate == "")
                {
                }
                else
                {
                    dtTo = Convert.ToDateTime(ToDate);
                }


                //var purchaseinfo = purchaseRepository.All().Where(p => p.PurchaseDate >= dtFrom && p.PurchaseDate <= dtTo).SingleOrDefault();


                var purchaselist = _purchaseRepository.All().Where(x => x.PurchaseDate >= dtFrom && x.PurchaseDate <= dtTo);
                var purchasepaymentlist = _purchasePaymentRepository.All().Include(x => x.PurchaseMain).ThenInclude(x => x.SupplierModel).Where(x => x.PurchaseMain.PurchaseDate >= dtFrom && x.PurchaseMain.PurchaseDate <= dtTo && x.PurchaseMain.IsDelete == false);
                var purchaseitemlist = _purchaseItemRepository.All().Where(x => x.PurchaseModel.PurchaseDate >= dtFrom && x.PurchaseModel.PurchaseDate <= dtTo && x.PurchaseModel.IsDelete == false);

                if (SupplierId != null)
                {
                    purchaselist = purchaselist.Where(p => p.SupplierId == SupplierId);
                    purchasepaymentlist = purchasepaymentlist.Where(p => p.PurchaseMain.SupplierId == SupplierId);
                    purchaseitemlist = purchaseitemlist.Where(p => p.PurchaseModel.SupplierId == SupplierId);

                }

                if (UserId != null)
                {
                    purchaselist = purchaselist.Where(p => p.LuserId == UserId);
                    purchasepaymentlist = purchasepaymentlist.Where(p => p.PurchaseMain.LuserId == UserId);
                    purchaseitemlist = purchaseitemlist.Where(p => p.PurchaseModel.LuserId == UserId);
                }



                var totalpurchasesummary = purchaselist //.GroupBy(p => p.vPaymentType.TypeName);
                .GroupBy(x => new { x.ComId })
                .Select(g => new
                {
                    TotalPurchaseCount = g.Count(),
                    TotalPurchaseValue = g.Sum(x => x.NetAmount)
                    //, TotalCosting = g.Sum(x => x.FinalCostingPrice), 
                    //  TotalProfit = g.Sum(x => x.Profit) 
                });



                var purchasebyuser = purchaselist //.GroupBy(p => p.vPaymentType.TypeName);
                .GroupBy(x => new { x.UserAccountList.Name })
                .Select(g => new { UserName = g.Key.Name, TotalPurchaseCount = g.Count(), TotalPurchaseSum = g.Sum(x => x.NetAmount) }).ToList();


                //var commissionbyuser = purchaselist //.GroupBy(p => p.vPaymentType.TypeName);
                //.GroupBy(x => new { x.UserAccountList.Name })
                //.Select(g => new { UserName = g.Key.Name, TotalPurchaseCount = g.Count(), TotalCommissionAmount = g.Sum(x => x.TotalCommisionAmount) }).ToList();


                var purchasereceivebyhead = purchasepaymentlist.GroupBy(x => new { x.vChartofAccounts.AccName })
                .Select(g => new { AccName = g.Key.AccName, Amount = g.Sum(x => x.Amount) }).ToList();


                var totalPaidamount = purchasepaymentlist.Sum(x => x.Amount);
                var totalpurchase = purchaselist.Sum(x => x.GrandTotal);
                purchasereceivebyhead.Add(new
                {
                    AccName = "Due",
                    Amount = (totalpurchase - totalPaidamount)
                });




                var toppurchaseitem = purchaseitemlist //.GroupBy(p => p.vPaymentType.TypeName);
                 .GroupBy(x => new { x.Product.Name })
                 .Select(g => new { ProductName = g.Key.Name, ProductCount = g.Count() }).ToList().OrderByDescending(x => x.ProductCount).Take(5);



                var toppurchasesupplier = purchaselist.Include(x => x.SupplierModel)//.GroupBy(p => p.vPaymentType.TypeName);
                 .GroupBy(x => new { walkinsupplier = x.SupplierName, SupplierName = x.SupplierModel.SupplierName })
                 .Select(g => new { SupplierName = g.Key.SupplierName.ToLower().Contains("supplier") ? g.Key.walkinsupplier : g.Key.SupplierName, PurchaseAmount = g.Sum(x => x.GrandTotal) }).ToList().OrderByDescending(x => x.PurchaseAmount).Take(5);


                //var topduesupplier = purchaseRepository.All().Include(x => x.SupplierModel).Include(x => x.PurchasePayments).Where(x => x.PurchaseDate >= dtFrom && x.PurchaseDate <= dtTo)
                ////.Select(x => new { walkintsupplier = x.SupplierName, suppliername = x.SupplierModel.Name , DueAmount = x.GrandTotal - x.PurchasePayments.Sum(x=>x.Amount) })  //.GroupBy(p => p.vPaymentType.TypeName);
                //.GroupBy(x => new { walkintsupplier =  x.SupplierName, SupplierName = x.SupplierModel.Name })
                //.Select(g => new { SupplierName = g.Key.SupplierName + " " + g.Key.walkintsupplier, DueAmount = g.Sum(x => x.GrandTotal - x.PurchasePayments.Sum(x => x.Amount)) })
                //.ToList();//.OrderByDescending(x => x.DueAmount).Take(5);


                var topduesupplier = purchasepaymentlist
                .GroupBy(x => new { walkinsupplier = x.PurchaseMain.SupplierName, SupplierName = x.PurchaseMain.SupplierModel.SupplierName, GradnTotal = x.PurchaseMain.GrandTotal })
                .Select(g => new { SupplierName = g.Key.SupplierName.ToLower().Contains("supplier") ? g.Key.walkinsupplier : g.Key.SupplierName, TotalPurchase = g.Key.GradnTotal, PaidAmount = g.Sum(x => x.Amount) })
                .Where(x => (x.TotalPurchase - x.PaidAmount > 0))
                .ToList().OrderByDescending(x => x.TotalPurchase - x.PaidAmount)
                .Take(5).ToList();

                // var topduesuppliermore = purchaselist.Include(x => x.PurchasePayments).Include(x => x.SupplierModel).Where(x => x.PurchasePayments.Count() == 0)
                //.GroupBy(x => new { walkinsupplier = x.SupplierName, SupplierName = x.SupplierModel.SupplierName, GradnTotal = x.GrandTotal })
                //.Select(g => new { SupplierName = g.Key.SupplierName.ToLower().Contains("supplier") ? g.Key.walkinsupplier : g.Key.SupplierName, TotalPurchase = g.Sum(x => g.Key.GradnTotal), PaidAmount = decimal.Parse("0") })
                //.Where(x => (x.TotalPurchase - x.PaidAmount > 0))
                //.ToList().OrderByDescending(x => x.TotalPurchase - x.PaidAmount)
                //.Take(5).ToList();

                // foreach (var item in topduesuppliermore)
                // {
                //     topduesupplier.Add(item);
                // }


                var postunpostcount = purchaselist //.GroupBy(p => p.vPaymentType.TypeName);
                .GroupBy(x => new { isPosted = x.isPosted })
                .Select(g => new { isPosted = g.Key.isPosted, DocCount = g.Count() }).ToList();



                //var toppurchaseproduct = (from product in productRepository.All()
                //        from orderedProduct in purchaseItemRepository.All()
                //        where orderedProduct.ProductId == product.Id
                //        group orderedProduct by product into productGroups
                //        select new
                //        {
                //            product = productGroups.Key,
                //            numberOfOrders = productGroups.Count()
                //        }
                //     ).OrderByDescending(x => x.numberOfOrders).Distinct().Take(10);



                //var query = (from p in productRepository.All()
                //let totalQuantity = (from op in purchaseItemRepository.All().ToList()
                //                     join o in purchaseRepository.All().ToList() on op.PurchaseId equals o.Id
                //                     where op.ProductId == p.Id && o.PurchaseDate >= dtFrom && o.PurchaseDate <= dtTo
                //                     select op.Quantity).Sum()
                //where totalQuantity > 0
                //orderby totalQuantity descending
                //select p).Take(10);


                //return Json(totalpurchasesummary);

                var genericResult = new
                {
                    totalpurchasesummary = totalpurchasesummary,
                    purchasebyuser = purchasebyuser,
                    purchasereceivebyhead = purchasereceivebyhead,
                    //commissionbyuser = commissionbyuser,
                    toppurchaseitem = toppurchaseitem,
                    toppurchasesupplier = toppurchasesupplier,
                    topduesupplier = topduesupplier,
                    postunpostcount = postunpostcount
                };
                return Json(genericResult);

            }
            catch (Exception ex)
            {
                return Json(new { success = false, values = ex.Message.ToString() });
            }
        }


        [AllowAnonymous]
        public IActionResult GetPurchaseListByPage(int? SupplierId, int? UserId, string Status, int? IsPosted, int? WarehouseId, int? CategoryId, int? DocTypeId, int pageNo = 1, decimal pageSize = 10, string searchquery = "", string FromDate = "", string ToDate = "")
        {
            try
            {
                var ComId = (HttpContext.Session.GetInt32("ComId"));
                var sessionLuserId = (HttpContext.Session.GetInt32("UserId"));
                var UserRole = HttpContext.Session.GetString("UserRole");
                int? vatview = HttpContext.Session.GetInt32("VatViewActivate");

                var TimeZoneSettingsName = HttpContext.Session.GetString("TimeZoneSettingsName");

                DateTime dtFrom = Convert.ToDateTime(DateTime.Now.Date);
                DateTime dtTo = Convert.ToDateTime(DateTime.Now.Date);

                if (FromDate == null || FromDate == "")
                {
                }
                else
                {
                    dtFrom = Convert.ToDateTime(FromDate);
                }
                if (ToDate == null || ToDate == "")
                {
                }
                else
                {
                    dtTo = Convert.ToDateTime(ToDate);
                }


                var purchaselist = _purchaseRepository.All();
                if (vatview == null || vatview == 0) { }
                else
                {
                    purchaselist = purchaselist.Where(x => x.IsVatSales == true);

                }
                var purchaselistDateWise = purchaselist;

                if (searchquery?.Length > 1)
                {


                    var searchitem = JsonConvert.DeserializeObject<SalesFilterData>(searchquery);

                    if (searchitem.pageIndex != null)
                    {
                        pageNo = searchitem.pageIndex.GetValueOrDefault(); // || x.Code.ToLower().Contains(searchitem.Name.ToLower())
                        pageSize = searchitem.pageSize.GetValueOrDefault(); // || x.Code.ToLower().Contains(searchitem.Name.ToLower())


                    }


                    if (searchitem.NetAmount != null)
                    {
                        purchaselist = purchaselist.Where(x => x.NetAmount.ToString() == searchitem.NetAmount); // || x.Code.ToLower().Contains(searchitem.Name.ToLower())

                    }


                    //else
                    //{
                    //    //saleslist = saleslist.Where(p => p.SalesDate >= dtFrom && p.SalesDate <= dtTo);

                    //    //if (CustomerId == 1)
                    //    //{
                    //    //    saleslist = saleslist.Where(p => p.SalesDate >= dtFrom && p.SalesDate <= dtTo);
                    //    //}
                    //    //else
                    //    //{
                    //    //}
                    //}

                }



                if (UserRole == "Admin" || UserRole == "SuperAdmin")
                {
                    purchaselistDateWise = purchaselistDateWise.Where(p => (p.PurchaseDate >= dtFrom && p.PurchaseDate <= dtTo));

                }
                else
                {
                    var storesettings = storeSettingRepository.All().FirstOrDefault();
                    if (storesettings.isBackDatePermission == true)
                    {
                        dtTo = Convert.ToDateTime(DateTime.Now.Date);
                        DateTime dtFromwithprevdate = Convert.ToDateTime(DateTime.Now.Date.AddDays(-storesettings.Days));

                        if (dtFrom < dtFromwithprevdate)
                        {
                            dtFrom = dtFromwithprevdate;
                        }
                    }

                    purchaselistDateWise = purchaselistDateWise.Where(p => (p.PurchaseDate >= dtFrom && p.PurchaseDate <= dtTo));

                    purchaselistDateWise = purchaselistDateWise.Where(p => p.LuserId == sessionLuserId);

                }
                if (SupplierId != null)
                {
                    purchaselistDateWise = purchaselistDateWise.Where(p => p.SupplierId == SupplierId);

                }
                if (CategoryId != null)
                {
                    purchaselistDateWise = purchaselistDateWise.Where(p => p.Items.Any(x => x.Product.CategoryId == CategoryId));
                }
                if (DocTypeId != null)
                {
                    purchaselistDateWise = purchaselistDateWise.Where(p => p.DocTypeId == DocTypeId);
                }
                if (UserId != null)
                {
                    purchaselistDateWise = purchaselistDateWise.Where(p => p.LuserId == UserId);
                }
                else
                {
                    if (UserRole == "Admin" || UserRole == "SuperAdmin")
                    {
                    }
                    else
                    {



                        purchaselistDateWise = purchaselistDateWise.Where(p => p.LuserId == sessionLuserId);

                    }

                }



                if (WarehouseId != null)
                {
                    purchaselistDateWise = purchaselistDateWise.Where(p => p.WarehouseIdMain == WarehouseId);
                }
                else
                {
                    var arrayabc = FromWarehousePermissionRepository.All().Where(x => x.LuserIdAllow == sessionLuserId).Select(x => x.WarehouseId).ToList();
                    //int a = 1;
                    //List<int> IDs = new List<int> { 1, 3, 4, 8 };

                    //var warehouselist = _FromWarehousePermissionRepository.All().Select(x=>x.Id);
                    if (arrayabc.Count() > 0)
                    {
                        purchaselistDateWise = purchaselistDateWise.Where(p => arrayabc.Contains(p.WarehouseIdMain));
                    }
                }

                //if (Status == "Due")
                //{
                //    //var saleslistmore = saleslist.Where(x => x.GrandTotal -  x.SalesPayments.Sum(x=>x.Amount) > 0);

                //    purchaselistDateWise = purchaselistDateWise.Where(x => x.GrandTotal - x.PurchasePayments.Sum(x => x.Amount) > 0);

                //    //saleslist = saleslist.Where(x=>x.SalesPayments.Count == 0);


                //}


                if (Status == "Due")
                {
                    //var saleslistmore = saleslist.Where(x => x.GrandTotal -  x.SalesPayments.Sum(x=>x.Amount) > 0);

                    purchaselist = purchaselist.Where(x => x.GrandTotal - x.PurchasePayments.Sum(x => x.Amount) != 0 && x.DocTypeList.DocType == "Purchase");


                    purchaselistDateWise = purchaselist;
                    //saleslist = saleslist.Where(x=>x.SalesPayments.Count == 0);



                }
                else if (Status == "Date Wise Due")
                {
                    purchaselistDateWise = purchaselistDateWise.Where(x => x.GrandTotal - x.PurchasePayments.Sum(x => x.Amount) != 0 && x.DocTypeList.DocType == "Purchase");


                }




                if (TimeZoneSettingsName.Length > 3)
                {
                    var localtime = TimeZoneInfo.ConvertTime(DateTime.Now, TimeZoneInfo.FindSystemTimeZoneById(TimeZoneSettingsName));
                    ViewBag.FromDate = localtime.Date.ToString("dd-MMM-yyyy");

                }

                decimal TotalRecordCount = purchaselist.Count();
                var PageCountabc = decimal.Parse((TotalRecordCount / pageSize).ToString());
                var PageCount = Math.Ceiling(PageCountabc);

                decimal skip = (pageNo - 1) * pageSize;

                // Get total number of records
                int total = purchaselist.Count();



                var query = from e in purchaselistDateWise.Include(x => x.Items)
                            .ThenInclude(x => x.Product).ThenInclude(x => x.Category)
                            .Include(x => x.PurchasePayments).ThenInclude(x => x.vChartofAccounts)
                               .Include(x => x.PurchasePayments).ThenInclude(x => x.Transaction)
                               .Include(x => x.PurchaseReturn).ThenInclude(x => x.PurchaseReturnPayments)
                               .Include(x => x.DocTypeList)

                            select new PurchaseResultList
                            {
                                Id = e.Id,
                                PurchaseCode = e.PurchaseCode,
                                PurchaseDateString = e.PurchaseDate.ToString("dd-MMM-yy"),
                                PurchaseUser = e.UserAccountList.Name,
                                SupplierName = (e.SupplierName.Length == 0 || e.SupplierName == null) ? e.SupplierModel.SupplierName : e.SupplierModel.SupplierName + " - " + e.SupplierName,
                                PrimaryAddress = e.PrimaryAddress,
                                SecoundaryAddress = e.SecoundaryAddress,
                                Notes = e.Notes,
                                PhoneNo = e.PhoneNo,
                                Discount = e.Discount,
                                Total = e.Total,
                                Status = e.Status,
                                NetAmount = e.NetAmount,
                                DocType = e.DocTypeList.DocType,
                                isPOSPurchase = e.isPOSPurchase,
                                isBatchPurchase = e.isBatchPurchase,
                                isPosted = e.isPosted,
                                Location = e.Warehouses.WhShortName,
                                //StatusPosted = e.isPosted != false ? "Posted" : "Not Posted",
                                //PaidAmt = e.PaidAmt,
                                //PaymentHead = ""//e.CreditAccount != null ? e.CreditAccount.AccName : "=N/A="
                                StatusPosted = e.isPosted != false ? "Posted" : "Not Posted",
                                PaidAmt = e.PurchasePayments.Sum(x => x.Amount),// e.PaidAmt,
                                //ReceivingHead = e.CreditAccount != null ? e.CreditAccount.AccName : "=N/A="
                                //PurchasePayments = e.PurchasePayments.ToList(),
                                PurchasePayments = e.PurchasePayments.Select(x => new
                                {
                                    x.PurchaseId,
                                    x.PaymentCardNo,
                                    x.isPosted,
                                    x.Amount,
                                    x.RowNo,
                                    x.AccountHeadId,
                                    AccType = x.vChartofAccounts.AccType,
                                    AccName = x.vChartofAccounts.AccName,
                                    TransactionCode = x.Transaction.TransactionCode
                                }),
                                //Items = e.Items
                                PurchaseItems = e.Items.Where(x => x.IsDelete == false).Select(x => new
                                {
                                    x.Id,
                                    CategoryName = x.Product.Category.Name,
                                    ColorName = x.Product.ColorId != null ? x.Product.Color.ColorName : x.Product.ColorName,
                                    BrandName = x.Product.BrandId != null ? x.Product.Brand.BrandName : "",
                                    SizeName = x.Product.SizeName,

                                    ProductCode = x.Product.Code,
                                    ProductName = x.Product.Name,
                                    Price = x.Price,
                                    Quantity = x.Quantity,
                                    ProfitPer = x.ProfitPer,
                                    SalesUnitPrice = x.SalesUnitPrice

                                })
                            };


                var abcd = query.OrderByDescending(x => x.Id).Skip(int.Parse(skip.ToString())).Take(int.Parse(pageSize.ToString())).ToList();// Take(50);
                var pageinfo = new PagingInfo();
                pageinfo.PageCount = int.Parse(PageCount.ToString());
                pageinfo.PageNo = pageNo;
                pageinfo.PageSize = int.Parse(pageSize.ToString());
                pageinfo.TotalRecordCount = int.Parse(TotalRecordCount.ToString());

                //return  abcd;
                return Json(new { Success = 1, error = false, VoucherList = abcd, PageInfo = pageinfo });


            }
            catch (Exception ex)
            {
                return Json(new { Success = "0", error = ex.Message });
                //throw ex;
            }

        }

        public class PurchaseFilterData
        {
            public int PurchaseId { get; set; }
            public int UserList { get; set; }

            public string? PurchaseCode { get; set; }
            public string? DocTypeName { get; set; }

            public string? PurchaseDate { get; set; }
            public string? NetAmount { get; set; }
            public int? pageIndex { get; set; }
            public int? pageSize { get; set; }

        }



        [AllowAnonymous]
        public IActionResult GetPurchaseList(string FromDate, string ToDate, int? SupplierId, int? UserId, string Status, int? WarehouseId, int? CategoryId, int? DocTypeId, int isAll)
        {
            try
            {
                var ComId = (HttpContext.Session.GetInt32("ComId"));
                var sessionLuserId = (HttpContext.Session.GetInt32("UserId"));
                var UserRole = HttpContext.Session.GetString("UserRole");
                int? vatview = HttpContext.Session.GetInt32("VatViewActivate");



                DateTime dtFrom = Convert.ToDateTime(DateTime.Now.Date);
                DateTime dtTo = Convert.ToDateTime(DateTime.Now.Date);

                if (FromDate == null || FromDate == "")
                {
                }
                else
                {
                    dtFrom = Convert.ToDateTime(FromDate);
                }
                if (ToDate == null || ToDate == "")
                {
                }
                else
                {
                    dtTo = Convert.ToDateTime(ToDate);
                }

                Microsoft.Extensions.Primitives.StringValues y = "";
                var x = Request.Form.TryGetValue("search[value]", out y);

                var purchaselist = _purchaseRepository.All();
                if (vatview == null || vatview == 0) { }
                else
                {
                    purchaselist = purchaselist.Where(x => x.IsVatSales == true);

                }
                var purchaselistDateWise = purchaselist;

                if (y.ToString().Length > 0)
                {


                }
                else
                {
                    purchaselistDateWise = purchaselistDateWise.Where(p => (p.PurchaseDate >= dtFrom && p.PurchaseDate <= dtTo));


                    if (SupplierId != null)
                    {
                        purchaselistDateWise = purchaselistDateWise.Where(p => p.SupplierId == SupplierId);

                    }
                    if (CategoryId != null)
                    {
                        purchaselistDateWise = purchaselistDateWise.Where(p => p.Items.Any(x => x.Product.CategoryId == CategoryId));
                    }
                    if (UserId != null)
                    {
                        purchaselistDateWise = purchaselistDateWise.Where(p => p.LuserId == UserId);
                    }
                    if (DocTypeId != null)
                    {
                        purchaselistDateWise = purchaselistDateWise.Where(p => p.DocTypeId == DocTypeId);
                    }


                    if (WarehouseId != null)
                    {
                        purchaselistDateWise = purchaselistDateWise.Where(p => p.WarehouseIdMain == WarehouseId);
                    }
                    else
                    {
                        var arrayabc = FromWarehousePermissionRepository.All().Where(x => x.LuserIdAllow == sessionLuserId).Select(x => x.WarehouseId).ToList();
                        //int a = 1;
                        //List<int> IDs = new List<int> { 1, 3, 4, 8 };

                        //var warehouselist = _FromWarehousePermissionRepository.All().Select(x=>x.Id);
                        if (arrayabc.Count() > 0)
                        {
                            purchaselistDateWise = purchaselistDateWise.Where(p => arrayabc.Contains(p.WarehouseIdMain));
                        }
                    }

                    //if (Status == "Due")
                    //{
                    //    //var saleslistmore = saleslist.Where(x => x.GrandTotal -  x.SalesPayments.Sum(x=>x.Amount) > 0);

                    //    purchaselistDateWise = purchaselistDateWise.Where(x => x.GrandTotal - x.PurchasePayments.Sum(x => x.Amount) > 0);

                    //    //saleslist = saleslist.Where(x=>x.SalesPayments.Count == 0);


                    //}


                    if (Status == "Due")
                    {
                        //var saleslistmore = saleslist.Where(x => x.GrandTotal -  x.SalesPayments.Sum(x=>x.Amount) > 0);

                        purchaselist = purchaselist.Where(x => x.GrandTotal - x.PurchasePayments.Sum(x => x.Amount) != 0 && x.DocTypeList.DocType == "Purchase");


                        purchaselistDateWise = purchaselist;
                        //saleslist = saleslist.Where(x=>x.SalesPayments.Count == 0);



                    }
                    else if (Status == "Date Wise Due")
                    {
                        purchaselistDateWise = purchaselistDateWise.Where(x => x.GrandTotal - x.PurchasePayments.Sum(x => x.Amount) != 0 && x.DocTypeList.DocType == "Purchase");


                    }


                    //else
                    //{
                    //    //if (SupplierId == 1)
                    //    //{
                    //    //    purchaselistDateWise = purchaselistDateWise.Where(p => p.PurchaseDate >= dtFrom && p.PurchaseDate <= dtTo);
                    //    //}
                    //    //else
                    //    {
                    //        purchaselistDateWise = purchaselistDateWise.Where(p => (p.PurchaseDate >= dtFrom && p.PurchaseDate <= dtTo) && p.SupplierId == SupplierId);
                    //    }
                    //}

                }



                var query = from e in purchaselistDateWise.Include(x => x.Items)
                            .ThenInclude(x => x.Product).ThenInclude(x => x.Category)
                            .Include(x => x.PurchasePayments).ThenInclude(x => x.vChartofAccounts)
                               .Include(x => x.PurchasePayments).ThenInclude(x => x.Transaction)
                               .Include(x => x.PurchaseReturn).ThenInclude(x => x.PurchaseReturnPayments)
                               .Include(x => x.DocTypeList)

                            select new PurchaseResultList
                            {
                                Id = e.Id,
                                PurchaseCode = e.PurchaseCode,
                                PurchaseDateString = e.PurchaseDate.ToString("dd-MMM-yy"),
                                PurchaseUser = e.UserAccountList.Name,
                                SupplierName = (e.SupplierName.Length == 0 || e.SupplierName == null) ? e.SupplierModel.SupplierName : e.SupplierModel.SupplierName + " - " + e.SupplierName,
                                PrimaryAddress = e.PrimaryAddress,
                                SecoundaryAddress = e.SecoundaryAddress,
                                Notes = e.Notes,
                                PhoneNo = e.PhoneNo,
                                Discount = e.Discount,
                                Total = e.Total,
                                Status = e.Status,
                                NetAmount = e.NetAmount,
                                DocType = e.DocTypeList.DocType,
                                isPOSPurchase = e.isPOSPurchase,
                                isBatchPurchase = e.isBatchPurchase,
                                isPosted = e.isPosted,
                                Location = e.Warehouses.WhShortName,
                                //StatusPosted = e.isPosted != false ? "Posted" : "Not Posted",
                                //PaidAmt = e.PaidAmt,
                                //PaymentHead = ""//e.CreditAccount != null ? e.CreditAccount.AccName : "=N/A="
                                StatusPosted = e.isPosted != false ? "Posted" : "Not Posted",
                                PaidAmt = e.PurchasePayments.Sum(x => x.Amount),// e.PaidAmt,
                                //ReceivingHead = e.CreditAccount != null ? e.CreditAccount.AccName : "=N/A="
                                //PurchasePayments = e.PurchasePayments.ToList(),
                                PurchasePayments = e.PurchasePayments.Select(x => new
                                {
                                    x.PurchaseId,
                                    x.PaymentCardNo,
                                    x.isPosted,
                                    x.Amount,
                                    x.RowNo,
                                    x.AccountHeadId,
                                    AccType = x.vChartofAccounts.AccType,
                                    AccName = x.vChartofAccounts.AccName,
                                    TransactionCode = x.Transaction.TransactionCode
                                }),
                                //Items = e.Items
                                PurchaseItems = e.Items.Where(x => x.IsDelete == false).Select(x => new
                                {
                                    x.Id,
                                    CategoryName = x.Product.Category.Name,
                                    ColorName = x.Product.ColorId != null ? x.Product.Color.ColorName : x.Product.ColorName,
                                    BrandName = x.Product.BrandId != null ? x.Product.Brand.BrandName : "",
                                    SizeName = x.Product.SizeName,

                                    ProductCode = x.Product.Code,
                                    ProductName = x.Product.Name,
                                    Price = x.Price,
                                    Quantity = x.Quantity,
                                    ProfitPer = x.ProfitPer,
                                    SalesUnitPrice = x.SalesUnitPrice

                                })
                            };


                var parser = new Parser<PurchaseResultList>(Request.Form, query);

                return Json(parser.Parse());


            }
            catch (Exception ex)
            {
                return Json(new { Success = "0", error = ex.Message });
                //throw ex;
            }

        }


        [HttpGet]
        [AllowAnonymous]
        public IActionResult GetPurchaseListqb(string FromDate, string ToDate, int? SupplierId, int? UserId, string Status, int? WarehouseId, int? CategoryId, int? DocTypeId, int isAll)
        {
            try
            {
                var ComId = (HttpContext.Session.GetInt32("ComId"));
                var sessionLuserId = (HttpContext.Session.GetInt32("UserId"));
                var UserRole = HttpContext.Session.GetString("UserRole");
                int? vatview = HttpContext.Session.GetInt32("VatViewActivate");



                //DateTime dtFrom = Convert.ToDateTime(DateTime.Now.Date);
                //DateTime dtTo = Convert.ToDateTime(DateTime.Now.Date);

                //if (FromDate == null || FromDate == "")
                //{
                //}
                //else
                //{
                //    dtFrom = Convert.ToDateTime(FromDate);
                //}
                //if (ToDate == null || ToDate == "")
                //{
                //}
                //else
                //{
                //    dtTo = Convert.ToDateTime(ToDate);
                //}

                //Microsoft.Extensions.Primitives.StringValues y = "";
                //var x = Request.Form.TryGetValue("search[value]", out y);

                var purchaselist = _purchaseRepository.All();
                //if (vatview == null || vatview == 0) { }
                //else
                //{
                //    purchaselist = purchaselist.Where(x => x.IsVatSales == true);

                //}
                var purchaselistDateWise = purchaselist;

                //if (y.ToString().Length > 0)
                //{


                //}
                //else
                //{
                //    purchaselistDateWise = purchaselistDateWise.Where(p => (p.PurchaseDate >= dtFrom && p.PurchaseDate <= dtTo));


                //    if (SupplierId != null)
                //    {
                //        purchaselistDateWise = purchaselistDateWise.Where(p => p.SupplierId == SupplierId);

                //    }
                //    if (CategoryId != null)
                //    {
                //        purchaselistDateWise = purchaselistDateWise.Where(p => p.Items.Any(x => x.Product.CategoryId == CategoryId));
                //    }
                //    if (UserId != null)
                //    {
                //        purchaselistDateWise = purchaselistDateWise.Where(p => p.LuserId == UserId);
                //    }
                //    if (DocTypeId != null)
                //    {
                //        purchaselistDateWise = purchaselistDateWise.Where(p => p.DocTypeId == DocTypeId);
                //    }


                //    if (WarehouseId != null)
                //    {
                //        purchaselistDateWise = purchaselistDateWise.Where(p => p.WarehouseIdMain == WarehouseId);
                //    }
                //    else
                //    {
                //        var arrayabc = FromWarehousePermissionRepository.All().Where(x => x.LuserIdAllow == sessionLuserId).Select(x => x.WarehouseId).ToList();
                //        //int a = 1;
                //        //List<int> IDs = new List<int> { 1, 3, 4, 8 };

                //        //var warehouselist = _FromWarehousePermissionRepository.All().Select(x=>x.Id);
                //        if (arrayabc.Count() > 0)
                //        {
                //            purchaselistDateWise = purchaselistDateWise.Where(p => arrayabc.Contains(p.WarehouseIdMain));
                //        }
                //    }

                //    //if (Status == "Due")
                //    //{
                //    //    //var saleslistmore = saleslist.Where(x => x.GrandTotal -  x.SalesPayments.Sum(x=>x.Amount) > 0);

                //    //    purchaselistDateWise = purchaselistDateWise.Where(x => x.GrandTotal - x.PurchasePayments.Sum(x => x.Amount) > 0);

                //    //    //saleslist = saleslist.Where(x=>x.SalesPayments.Count == 0);


                //    //}


                //    if (Status == "Due")
                //    {
                //        //var saleslistmore = saleslist.Where(x => x.GrandTotal -  x.SalesPayments.Sum(x=>x.Amount) > 0);

                //        purchaselist = purchaselist.Where(x => x.GrandTotal - x.PurchasePayments.Sum(x => x.Amount) != 0 && x.DocTypeList.DocType == "Purchase");


                //        purchaselistDateWise = purchaselist;
                //        //saleslist = saleslist.Where(x=>x.SalesPayments.Count == 0);



                //    }
                //    else if (Status == "Date Wise Due")
                //    {
                //        purchaselistDateWise = purchaselistDateWise.Where(x => x.GrandTotal - x.PurchasePayments.Sum(x => x.Amount) != 0 && x.DocTypeList.DocType == "Purchase");


                //    }


                //    //else
                //    //{
                //    //    //if (SupplierId == 1)
                //    //    //{
                //    //    //    purchaselistDateWise = purchaselistDateWise.Where(p => p.PurchaseDate >= dtFrom && p.PurchaseDate <= dtTo);
                //    //    //}
                //    //    //else
                //    //    {
                //    //        purchaselistDateWise = purchaselistDateWise.Where(p => (p.PurchaseDate >= dtFrom && p.PurchaseDate <= dtTo) && p.SupplierId == SupplierId);
                //    //    }
                //    //}

                //}



                var query = from e in purchaselist.Include(x => x.Items)
                            .ThenInclude(x => x.Product).ThenInclude(x => x.Category)
                            .Include(x => x.PurchasePayments).ThenInclude(x => x.vChartofAccounts)
                               .Include(x => x.PurchasePayments).ThenInclude(x => x.Transaction)
                               .Include(x => x.PurchaseReturn).ThenInclude(x => x.PurchaseReturnPayments)
                               .Include(x => x.DocTypeList)

                            select new PurchaseResultList
                            {
                                Id = e.Id,
                                PurchaseCode = e.PurchaseCode,
                                PurchaseDateString = e.PurchaseDate.ToString("dd-MMM-yy"),
                                PurchaseUser = e.UserAccountList.Name,
                                SupplierName = (e.SupplierName.Length == 0 || e.SupplierName == null) ? e.SupplierModel.SupplierName : e.SupplierModel.SupplierName + " - " + e.SupplierName,
                                PrimaryAddress = e.PrimaryAddress,
                                SecoundaryAddress = e.SecoundaryAddress,
                                Notes = e.Notes,
                                PhoneNo = e.PhoneNo,
                                Discount = e.Discount,
                                Total = e.Total,
                                Status = e.Status,
                                NetAmount = e.NetAmount,
                                DocType = e.DocTypeList.DocType,
                                isPOSPurchase = e.isPOSPurchase,
                                isBatchPurchase = e.isBatchPurchase,
                                isPosted = e.isPosted,
                                Location = e.Warehouses.WhShortName,
                                //StatusPosted = e.isPosted != false ? "Posted" : "Not Posted",
                                //PaidAmt = e.PaidAmt,
                                //PaymentHead = ""//e.CreditAccount != null ? e.CreditAccount.AccName : "=N/A="
                                StatusPosted = e.isPosted != false ? "Posted" : "Not Posted",
                                PaidAmt = e.PurchasePayments.Sum(x => x.Amount),// e.PaidAmt,
                                //ReceivingHead = e.CreditAccount != null ? e.CreditAccount.AccName : "=N/A="
                                //PurchasePayments = e.PurchasePayments.ToList(),
                                //PurchasePayments = e.PurchasePayments.Select(x => new
                                //{
                                //    x.PurchaseId,
                                //    x.PaymentCardNo,
                                //    x.isPosted,
                                //    x.Amount,
                                //    x.RowNo,
                                //    x.AccountHeadId,
                                //    AccType = x.vChartofAccounts.AccType,
                                //    AccName = x.vChartofAccounts.AccName,
                                //    TransactionCode = x.Transaction.TransactionCode
                                //}),
                                //Items = e.Items
                                //PurchaseItems = e.Items.Where(x => x.IsDelete == false).Select(x => new
                                //{
                                //    x.Id,
                                //    CategoryName = x.Product.Category.Name,
                                //    ColorName = x.Product.ColorId != null ? x.Product.Color.ColorName : x.Product.ColorName,
                                //    BrandName = x.Product.BrandId != null ? x.Product.Brand.BrandName : "",
                                //    SizeName = x.Product.SizeName,

                                //    ProductCode = x.Product.Code,
                                //    ProductName = x.Product.Name,
                                //    Price = x.Price,
                                //    Quantity = x.Quantity,
                                //    ProfitPer = x.ProfitPer,
                                //    SalesUnitPrice = x.SalesUnitPrice

                                //})
                            };


                var parser = new Parser<PurchaseResultList>(Request.Form, query);

                return Json(parser.Parse());


            }
            catch (Exception ex)
            {
                return Json(new { Success = "0", error = ex.Message });
                //throw ex;
            }

        }

        [AllowAnonymous]
        public JsonResult JournalforSalesExpenses(int SourceId, string Source)
        {
            try
            {
                var comid = HttpContext.Session.GetInt32("ComId");
                var userid = HttpContext.Session.GetInt32("UserId");

                var quary = $"EXEC JournalforSalesExpense '{comid}'";

                SqlParameter[] parameters = new SqlParameter[3];

                parameters[0] = new SqlParameter("@SourceId", SourceId);
                parameters[1] = new SqlParameter("@Source", Source);
                parameters[2] = new SqlParameter("@ComId", comid);

                var datasetabc = new System.Data.DataSet();
                datasetabc = Helper.ExecProcMapDS("JournalforSalesExpense", parameters);

                var dataTable = datasetabc.Tables[0];

                return Json(new { Success = 1, data = dataTable });
            }
            catch (Exception ex)
            {

                //throw ex;
                return Json(new
                {
                    Success = 2,
                    data = ex.InnerException
                });
            }

        }



        [AllowAnonymous]
        public JsonResult GetPurchaseListTabulator(int? UserId, int? Warehouse, int? IsPosted, int? VoucherTypeId, int? SupplierId, int? DocTypeId, int? StatusId, int? Status, int? DeliveryMethod, int? PurchaseDate, int page = 1, decimal size = 5, string searchquery = "", string FromDate = "", string ToDate = "", int CopyBill = 0)
        {
            try
            {
                var CurrentUserId = HttpContext.Session.GetInt32("UserId");
                var ComId = HttpContext.Session.GetInt32("ComId");

                var purchaseId = 0;

                SqlParameter[] sqlParameter1 = new SqlParameter[2];
                sqlParameter1[0] = new SqlParameter("@ComId", ComId);
                sqlParameter1[1] = new SqlParameter("@PurchaseId", purchaseId);               
                Helper.ExecProc("[PurchaseApprovalStatus]", sqlParameter1);

                ///ViewBag.Userlist = _userAccountRepository.GetAllForDropDown();


                //SelectListItem warehouseall = new SelectListItem() { Text = "Please Select", Value = "" };
                //var warehouselist = _FromWarehousePermissionRepository.GetAllForDropDown().ToList();
                //if (warehouselist.Count() == 0)
                //{
                //    warehouselist = _warehouseRepository.GetWarehouseLedgerHeadForDropDown().ToList();
                //    warehouselist.Add(warehouseall);
                //}
                //ViewBag.Warehouse = warehouselist.OrderBy(x => x.Value);



                //var transactioncomid = HttpContext.Session.GetInt32("ComId");

                // DateTime dtFrom = Convert.ToDateTime(DateTime.Now.Date.ToString("dd-MMM-yy"));
                //  DateTime dtTo = Convert.ToDateTime(DateTime.Now.Date.ToString("dd-MMM-yy"));


                //ViewBag.FromDate = dtFrom.ToString("dd-MMM-yyyy");
                //ViewBag.ToDate = dtTo.ToString("dd-MMM-yyyy");

                DateTime dtFrom = DateTime.MinValue;
                DateTime dtTo = DateTime.MaxValue;

                if (!string.IsNullOrEmpty(FromDate))
                    dtFrom = Convert.ToDateTime(FromDate);

                if (!string.IsNullOrEmpty(ToDate))
                    dtTo = Convert.ToDateTime(ToDate);



                //if (FromDate == null || FromDate == "")
                //{
                //}
                //else
                //{
                //    dtFrom = Convert.ToDateTime(FromDate);

                //}
                //if (ToDate == null || ToDate == "")
                //{
                //}
                //else
                //{
                //    dtTo = Convert.ToDateTime(ToDate);

                //}

                //if (UserId == null)
                //{
                //    UserId = CurrentUserId;
                //}



                //var products= _context.Products.ToList();

                //var accountheadlist = _accountHeadRepository.All().Include(x => x.vAccountGroupHead).Where(x => x.IsDelete == false);//.Include(x=>x.vUnit).Include(x=>x.Category);

                // var voucherlist = _accVoucherRepository.All().Where(x => x.IsDelete == false );

                //var voucherlist = _accVoucherRepository.All().Where(x => x.IsDelete == false && x.VoucherDate >= dtFrom && x.VoucherDate <= dtTo);
                var purchaselist = _purchaseRepository.All().Where(x => x.IsSystem == false && x.IsRecurring == false && x.IsPending == false);

                if (searchquery?.Length > 1)
                {
                    purchaselist = purchaselist.Where(x =>
                        x.SupplierName.ToLower().Contains(searchquery.ToLower()) ||
                        x.DocTypeList.DocType.ToLower().Contains(searchquery.ToLower()) ||
                        x.PurchaseCode.ToLower().Contains(searchquery.ToLower()) ||
                        x.NetAmount.ToString().ToLower().Contains(searchquery.ToLower())
                    );

                }

                purchaselist = purchaselist.Where(x => x.PurchaseDate >= dtFrom && x.PurchaseDate <= dtTo);

                if (IsPosted != null)
                {
                    if (IsPosted == 1)
                    {
                        purchaselist = purchaselist.Where(x => x.isPosted == true);

                    }
                    else
                    {
                        purchaselist = purchaselist.Where(x => x.isPosted == false);

                    }
                }


                if (SupplierId != null)
                {
                    purchaselist = purchaselist.Where(x => x.SupplierId == SupplierId);
                }
                if (DocTypeId != null)
                {
                    purchaselist = purchaselist.Where(x => x.DocTypeId == DocTypeId);
                }
                if (StatusId != null)
                {
                    purchaselist = purchaselist.Where(x => x.StatusId == StatusId);
                }
                if (UserId != null)
                {
                    purchaselist = purchaselist.Where(x => x.LuserId == UserId);
                }
                //if (Status != null)
                //{
                //    purchaselist = purchaselist.Where(x => x.Status == Status);
                //}

                decimal TotalRecordCount = purchaselist.Count();
                var PageCountabc = decimal.Parse((TotalRecordCount / size).ToString());
                var PageCount = Math.Ceiling(PageCountabc);



                decimal skip = (page - 1) * size;

                // Get total number of records
                //int total = voucherlist.Count();



                var query = from e in purchaselist.Include(x => x.Items)
                         .ThenInclude(x => x.Product).ThenInclude(x => x.Category)
                         .Include(x => x.PurchasePayments).ThenInclude(x => x.vChartofAccounts)
                            .Include(x => x.PurchasePayments).ThenInclude(x => x.Transaction)
                            .Include(x => x.PurchaseReturn).ThenInclude(x => x.PurchaseReturnPayments)
                            .Include(x => x.DocTypeList)
                            .Include(x => x.StatusInfo)
                            .Include(x => x.ItemsCategory).ThenInclude(x => x.Acc_ChartOfAccount).ThenInclude(x => x.vAccountGroupHead)

                            select new PurchaseResultList
                            {
                                Id = e.Id,
                                DueDate = e.DueDate,
                                PurchaseCode = e.PurchaseCode,
                                PurchaseDateString = e.PurchaseDate.ToString("dd-MMM-yy"),
                                PurchaseUser = e.UserAccountList.Name,
                                SupplierId = e.SupplierId,
                                //SupplierName = (e.SupplierName.Length == 0 || e.SupplierName == null) ? e.SupplierName : e.SupplierName + " - " + e.SupplierName,
                                SupplierName = e.SupplierName,
                                PrimaryAddress = e.PrimaryAddress,
                                SecoundaryAddress = e.SecoundaryAddress,
                                Notes = e.Notes,
                                PhoneNo = e.PhoneNo,
                                Discount = e.Discount,
                                Total = e.Total,
                                Status = e.Status,
                                //Status = e.StatusInfo.Status,
                                NetAmount = e.NetAmount,
                                TotalVat = e.TotalVat,
                                BeforeTax = e.NetAmount - e.TotalVat,
                                DocType = e.DocTypeList.DocType,
                                isPOSPurchase = e.isPOSPurchase,
                                isBatchPurchase = e.isBatchPurchase,
                                isPosted = e.isPosted,
                                Location = e.Warehouses.WhShortName,
                                FilePath = e.FilePath,
                                StatusPosted = e.isPosted != false ? "Posted" : "Not Posted",
                                PaidAmt = e.PurchasePayments.Sum(x => x.Amount),// e.PaidAmt,
                                Remarks = e.Remarks,

                                PurchaseItems = e.Items.Where(x => x.IsDelete == false).Select(x => new
                                {
                                    PurchaseItemsId = CopyBill == 0 ? x.PurchaseItemsId : x.Id,
                                    Id = CopyBill == 0 ? x.Id : 0,
                                    x.PurchaseId,
                                    x.SLNo,
                                    x.ProductId,
                                    ProductName = x.Product.Name,
                                    ProductCode = x.Product.Code,
                                    CustomerId = x.CustomerId,
                                    Name = x.ItemWiseCustomer.Name,
                                    CategoryName = x.Product.Category.Name,
                                    x.Amount,
                                    x.Price,
                                    x.Description,
                                    PurchaseCode = e.PurchaseCode,
                                    DocType = e.DocTypeList.DocType,
                                    PurchaseDate = e.PurchaseDate,
                                    NetAmount = e.NetAmount,
                                    Quantity = CopyBill == 0 ? x.Quantity : x.Quantity - x.PurchaseItems.Sum(y => y.Quantity),
                                    x.NewQTY,
                                    x.QTYOnHand,
                                    //x.QTY,
                                    x.SKU,
                                    x.Rate,
                                    x.ComId,
                                    x.LuserId,
                                    x.isTransaction,
                                    x.MasterTaxId,
                                    x.MasterTaxName,
                                    x.WarehouseId,
                                    x.WHName,
                                    TotalQty = CopyBill == 0 ? 0 : x.Quantity,
                                    UsedQty = CopyBill == 0 ? 0 : x.PurchaseItems.Sum(y => y.Quantity),
                                }),

                                PurchasePayments = e.PurchasePayments.Where(x => x.IsDelete == false).Select(x => new
                                {
                                    Id = 0, //x.Id,
                                    x.PurchaseId,
                                    x.PaymentCardNo,
                                    DepositTo = x.vChartofAccounts.AccName,
                                    AccountHeadId = x.AccountHeadId,
                                    x.Amount,
                                    x.RowNo,
                                    x.ComId,
                                    x.LuserId,
                                }),

                            };


                //return Json(query);


                var abcd = query.OrderByDescending(x => x.Id).Skip(int.Parse(skip.ToString())).Take(int.Parse(size.ToString())).ToList();// Take(50);
                var pageinfo = new PagingInfo();
                pageinfo.PageCount = int.Parse(PageCount.ToString());
                pageinfo.PageNo = page;
                pageinfo.PageSize = int.Parse(size.ToString());
                pageinfo.TotalRecordCount = int.Parse(TotalRecordCount.ToString());

                //return  abcd;
                return Json(new { Success = 1, error = false, data = abcd, page = page, size = size, last_page = pageinfo.PageCount, total = pageinfo.TotalRecordCount });





            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        [AllowAnonymous]
        public JsonResult GetPendingTransactionList(int page = 1, decimal size = 5, string searchquery = "")
        {
            try
            {
                var CurrentUserId = HttpContext.Session.GetInt32("UserId");
                var ComId = HttpContext.Session.GetInt32("ComId");

                DateTime dtFrom = DateTime.MinValue;
                DateTime dtTo = DateTime.MaxValue;


                var purchaselist = _purchaseRepository.All().Where(x => x.IsSystem == false && x.IsRecurring == false && x.IsPending == true);

                if (searchquery?.Length > 1)
                {
                    purchaselist = purchaselist.Where(x =>
                        x.SupplierName.ToLower().Contains(searchquery.ToLower()) ||
                        x.DocTypeList.DocType.ToLower().Contains(searchquery.ToLower()) ||
                        x.PurchaseCode.ToLower().Contains(searchquery.ToLower()) ||
                        x.NetAmount.ToString().ToLower().Contains(searchquery.ToLower())
                    );

                }

                purchaselist = purchaselist.Where(x => x.PurchaseDate >= dtFrom && x.PurchaseDate <= dtTo);



                decimal TotalRecordCount = purchaselist.Count();
                var PageCountabc = decimal.Parse((TotalRecordCount / size).ToString());
                var PageCount = Math.Ceiling(PageCountabc);



                decimal skip = (page - 1) * size;

                // Get total number of records
                //int total = voucherlist.Count();



                var query = from e in purchaselist.Include(x => x.Items)
                         .ThenInclude(x => x.Product).ThenInclude(x => x.Category)
                         .Include(x => x.PurchasePayments).ThenInclude(x => x.vChartofAccounts)
                            .Include(x => x.PurchasePayments).ThenInclude(x => x.Transaction)
                            .Include(x => x.PurchaseReturn).ThenInclude(x => x.PurchaseReturnPayments)
                            .Include(x => x.DocTypeList)
                            .Include(x => x.StatusInfo)
                            .Include(x => x.ItemsCategory).ThenInclude(x => x.Acc_ChartOfAccount).ThenInclude(x => x.vAccountGroupHead)

                            select new PurchaseResultList
                            {
                                Id = e.Id,
                                DueDate = e.DueDate,
                                PurchaseCode = e.PurchaseCode,
                                PurchaseDateString = e.PurchaseDate.ToString("dd-MMM-yy"),
                                PurchaseUser = e.UserAccountList.Name,
                                SupplierId = e.SupplierId,
                                //SupplierName = (e.SupplierName.Length == 0 || e.SupplierName == null) ? e.SupplierName : e.SupplierName + " - " + e.SupplierName,
                                SupplierName = e.SupplierName,
                                PrimaryAddress = e.PrimaryAddress,
                                SecoundaryAddress = e.SecoundaryAddress,
                                Notes = e.Notes,
                                PhoneNo = e.PhoneNo,
                                Discount = e.Discount,
                                Total = e.Total,
                                Status = e.StatusInfo.Status,
                                NetAmount = e.NetAmount,
                                TotalVat = e.TotalVat,
                                BeforeTax = e.NetAmount - e.TotalVat,
                                DocType = e.DocTypeList.DocType,
                                isPOSPurchase = e.isPOSPurchase,
                                isBatchPurchase = e.isBatchPurchase,
                                isPosted = e.isPosted,
                                Location = e.Warehouses.WhShortName,
                                FilePath = e.FilePath,
                                StatusPosted = e.isPosted != false ? "Posted" : "Not Posted",
                                PaidAmt = e.PurchasePayments.Sum(x => x.Amount),// e.PaidAmt,
                                Remarks = e.Remarks,

                            };


                //return Json(query);


                var abcd = query.OrderByDescending(x => x.Id).Skip(int.Parse(skip.ToString())).Take(int.Parse(size.ToString())).ToList();// Take(50);
                var pageinfo = new PagingInfo();
                pageinfo.PageCount = int.Parse(PageCount.ToString());
                pageinfo.PageNo = page;
                pageinfo.PageSize = int.Parse(size.ToString());
                pageinfo.TotalRecordCount = int.Parse(TotalRecordCount.ToString());

                //return  abcd;
                return Json(new { Success = 1, error = false, data = abcd, page = page, size = size, last_page = pageinfo.PageCount, total = pageinfo.TotalRecordCount });





            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        [AllowAnonymous]
        [HttpGet]
        public IActionResult changeStatus(int Id)
        {
            try
            {
                var ComId = HttpContext.Session.GetInt32("ComId");

                var model = _purchaseRepository.All().Where(x => x.Id == Id).FirstOrDefault();
                model.IsPending = false;

                _purchaseRepository.Update(model, Id);
                return Json(new { Success = 1, ex = "Data " });
            }
            catch (Exception ex)
            {
                return Json(new { Success = 0, ex = ex.InnerException?.InnerException?.Message ?? ex.Message });
            }
        }

        [AllowAnonymous]
        public JsonResult GetSingleSupplier(int SupplierId)
        {
            try
            {

                var singleSupplier = _supplierRepository.All(false).Where(x => x.Id == SupplierId)
                    .Select(x => new
                    {
                        x.Id,
                        Name = x.SupplierName,
                        x.PrimaryAddress,
                        x.SecoundaryAddress,
                        x.City,
                        x.Phone,
                        PostalCode = "",
                        x.Notes,
                        x.SupParentId,
                        x.Email,
                        x.CreateDate,
                        x.SupType,
                        x.LuserId,
                        x.CompanyName,
                        x.ClBalance
                    }).FirstOrDefault();

                return Json(singleSupplier);

            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        [AllowAnonymous]
        public JsonResult GetSupplierList(int? UserId, int? Warehouse, int? IsPosted, int? VoucherTypeId, int? SupplierId, int? DocTypeId, int? Status, int? DeliveryMethod, int? PurchaseDate, int page = 1, decimal size = 5, string searchquery = "", string FromDate = "", string ToDate = "", int CopyBill = 0)
        {
            try
            {
                var ComId = HttpContext.Session.GetInt32("ComId");
                var CurrentUserId = HttpContext.Session.GetInt32("UserId");

                DateTime dtFrom = DateTime.MinValue;
                DateTime dtTo = DateTime.MaxValue;

                if (!string.IsNullOrEmpty(FromDate))
                    dtFrom = Convert.ToDateTime(FromDate);

                if (!string.IsNullOrEmpty(ToDate))
                    dtTo = Convert.ToDateTime(ToDate);

                var supplierlist = _supplierRepository.All().Where(x => x.ComId == ComId && x.IsDelete == false);

                // Apply search filter
                //if (!string.IsNullOrEmpty(searchquery))
                //{
                //    var searchValue = searchquery.ToLower();
                //    supplierlist = supplierlist.Where(x => x.SupplierName.ToLower().Contains(searchValue) || x.Phone.ToLower().Contains(searchValue));
                //}



                if (searchquery?.Length > 1)
                {
                    supplierlist = supplierlist.Where(x =>
                        x.SupplierName.ToLower().Contains(searchquery.ToLower()) ||
                        x.Title.ToLower().Contains(searchquery.ToLower()) ||
                        x.FirstName.ToLower().Contains(searchquery.ToLower()) ||
                        x.MiddleName.ToLower().Contains(searchquery.ToLower()) ||
                        x.LastName.ToLower().Contains(searchquery.ToLower()) ||
                        x.PrimaryAddress.ToLower().Contains(searchquery.ToLower()) ||
                        x.Phone.ToLower().Contains(searchquery.ToLower()) ||
                        x.SupplierCode.ToLower().Contains(searchquery.ToLower()) ||
                        x.Currency.CurrencyShortName.ToLower().Contains(searchquery.ToLower()) ||
                        x.Email.ToLower().Contains(searchquery.ToLower())

                    );

                }



                decimal TotalRecordCount = supplierlist.Count();
                var PageCountabc = decimal.Parse((TotalRecordCount / size).ToString());
                var PageCount = Math.Ceiling(PageCountabc);

                decimal skip = (page - 1) * size;

                var query = from e in supplierlist.Include(x => x.Suppliers)
                            select new
                            {
                                Id = e.Id,
                                SupplierNames = e.SupplierName,
                                PrimaryAddress = e.PrimaryAddress,
                                Email = e.Email,
                                ClBalance = e.ClBalance,
                                Phone = e.Phone,
                                e.CompanyName,
                                e.SupplierCode,
                                Currency = e.Currency.CurrencyShortName
                            };

                var abcd = query.OrderByDescending(x => x.Id).Skip(int.Parse(skip.ToString())).Take(int.Parse(size.ToString())).ToList();
                var pageinfo = new PagingInfo();
                pageinfo.PageCount = int.Parse(PageCount.ToString());
                pageinfo.PageNo = page;
                pageinfo.PageSize = int.Parse(size.ToString());
                pageinfo.TotalRecordCount = int.Parse(TotalRecordCount.ToString());

                return Json(new { Success = 1, error = false, data = abcd, page = page, size = size, last_page = pageinfo.PageCount, total = pageinfo.TotalRecordCount });
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        [AllowAnonymous]
        public JsonResult GetSupplierListAll(int? UserId, int? Warehouse, int? IsPosted, int? VoucherTypeId, int? SupplierId, int? DocTypeId, int? Status, int? DeliveryMethod, int? PurchaseDate, int page = 1, decimal size = 10, string searchquery = "", string FromDate = "", string ToDate = "", int CopyBill = 0)
        {
            try
            {
                var CurrentUserId = HttpContext.Session.GetInt32("UserId");

                DateTime dtFrom = DateTime.MinValue;
                DateTime dtTo = DateTime.MaxValue;

                if (!string.IsNullOrEmpty(FromDate))
                    dtFrom = Convert.ToDateTime(FromDate);

                if (!string.IsNullOrEmpty(ToDate))
                    dtTo = Convert.ToDateTime(ToDate);

                var supplierlist = _supplierRepository.AllData();

                // Apply search filter
                if (!string.IsNullOrEmpty(searchquery))
                {
                    var searchValue = searchquery.ToLower();
                    supplierlist = supplierlist.Where(x => x.SupplierName.ToLower().Contains(searchValue) || x.Phone.ToLower().Contains(searchValue));
                }

                decimal TotalRecordCount = supplierlist.Count();
                var PageCountabc = decimal.Parse((TotalRecordCount / size).ToString());
                var PageCount = Math.Ceiling(PageCountabc);

                decimal skip = (page - 1) * size;

                var query = from e in supplierlist.Include(x => x.Suppliers)
                            select new
                            {
                                Id = e.Id,
                                SupplierName = e.SupplierName,
                                Email = e.Email,
                                OpBalance = e.OpBalance,
                                Phone = e.Phone,
                                e.SupplierCode,
                                Currency = e.Currency.CurrencyShortName
                            };

                var abcd = query.OrderByDescending(x => x.Id).Skip(int.Parse(skip.ToString())).Take(int.Parse(size.ToString())).ToList();
                var pageinfo = new PagingInfo();
                pageinfo.PageCount = int.Parse(PageCount.ToString());
                pageinfo.PageNo = page;
                pageinfo.PageSize = int.Parse(size.ToString());
                pageinfo.TotalRecordCount = int.Parse(TotalRecordCount.ToString());

                return Json(new { Success = 1, error = false, data = abcd, page = page, size = size, last_page = pageinfo.PageCount, total = pageinfo.TotalRecordCount });
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        [AllowAnonymous]
        public JsonResult GetPurchaseListAll(string type, int? SupplierId, int? CustomerId, string? Stock, int page = 1, decimal size = 10, string searchquery = "")
        {
            try
            {
                var CurrentUserId = HttpContext.Session.GetInt32("UserId");
                var ComId = HttpContext.Session.GetInt32("ComId");

                DateTime dtFrom = DateTime.MinValue;
                DateTime dtTo = DateTime.MaxValue;

                var purchaseItemlist = _purchaseItemRepository.All().Where(x => x.PurchaseModel.DocTypeList.DocType == type && x.PurchaseModel.ComId == ComId);

                if (SupplierId != null)
                {
                    purchaseItemlist = purchaseItemlist.Where(x => x.PurchaseModel.SupplierId == SupplierId);
                }
                if (CustomerId != null)
                {
                    purchaseItemlist = purchaseItemlist.Where(x => x.CustomerId == CustomerId);
                }

                // Apply search filter
                if (!string.IsNullOrEmpty(searchquery))
                {
                    var searchValue = searchquery.ToLower();
                    purchaseItemlist = purchaseItemlist.Where(x => x.PurchaseModel.SupplierModel.SupplierName.ToLower().Contains(searchValue));
                }

                var query = from e in purchaseItemlist.Include(x => x.Product)
                            let poqty = (decimal)e.Quantity
                            let grrqty = (decimal)e.PurchaseItems.Sum(x => x.Quantity)
                            let rempoqty = poqty - grrqty
                            select new
                            {
                                PurchaseId = e.PurchaseId,
                                ItemCode = e.Product.Code,
                                ItemName = e.Product.Name,
                                ItemCategory = e.Product.Category.Name,
                                ItemDesciption = e.Product.Description,
                                Unit = e.Product.Unit.UnitName,
                                BDPO = e.PurchaseModel.PurchaseCode,
                                BuyerName = e.ItemWiseCustomer.Name,
                                Quantity = e.Quantity,
                                PurchaseDate = e.PurchaseModel.PurchaseDate.ToString("dd-MMM-yyyy"),
                                UnitCost = e.Product.CostPrice,
                                Color = e.Colors == null ? (e.Product.ColorName == null ? "" : e.Product.ColorName) : e.Colors.ColorName,
                                Status = rempoqty == 0 ? "Fully Received" : rempoqty < 0 ? "Excess Received" : (grrqty < poqty && grrqty > 0) ? "Partialy Received" : grrqty == 0 ? "Not Yet Received" : ""
                            };
                if (Stock != null && Stock.Length > 0)
                {
                    query = query.Where(x => x.Status == Stock);
                }
                decimal TotalRecordCount = purchaseItemlist.Count();
                var PageCountabc = decimal.Parse((TotalRecordCount / size).ToString());
                var PageCount = Math.Ceiling(PageCountabc);

                decimal skip = (page - 1) * size;

                var abcd = query.OrderByDescending(x => x.PurchaseId).Skip(int.Parse(skip.ToString())).Take(int.Parse(size.ToString())).ToList();
                var pageinfo = new PagingInfo();
                pageinfo.PageCount = int.Parse(PageCount.ToString());
                pageinfo.PageNo = page;
                pageinfo.PageSize = int.Parse(size.ToString());
                pageinfo.TotalRecordCount = int.Parse(TotalRecordCount.ToString());

                return Json(new { Success = 1, error = false, data = abcd, page = page, size = size, last_page = pageinfo.PageCount, total = pageinfo.TotalRecordCount });
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        //[AllowAnonymous]
        //public JsonResult GetSupplierList(int? UserId, int? Warehouse, int? IsPosted, int? VoucherTypeId, int? SupplierId, int? DocTypeId, int? Status, int? DeliveryMethod, int? PurchaseDate, int page = 1, decimal size = 5, string searchquery = "", string FromDate = "", string ToDate = "", int CopyBill = 0)
        //{
        //    try
        //    {
        //        var CurrentUserId = HttpContext.Session.GetInt32("UserId");

        //        DateTime dtFrom = DateTime.MinValue;
        //        DateTime dtTo = DateTime.MaxValue;

        //        if (!string.IsNullOrEmpty(FromDate))
        //            dtFrom = Convert.ToDateTime(FromDate);

        //        if (!string.IsNullOrEmpty(ToDate))
        //            dtTo = Convert.ToDateTime(ToDate);



        //        var supplierlist = _supplierRepository.All().Where(x => x.IsDelete == false);





        //        //if (IsPosted != null)
        //        //{
        //        //    if (IsPosted == 1)
        //        //    {
        //        //        purchaselist = purchaselist.Where(x => x.isPosted == true);

        //        //    }
        //        //    else
        //        //    {
        //        //        purchaselist = purchaselist.Where(x => x.isPosted == false);

        //        //    }
        //        //}


        //        ////if (UserId == null)
        //        ////{
        //        ////    purchaselist = purchaselist.Where(x => x.LuserId == UserId);
        //        ////}

        //        //if (searchquery?.Length > 1)
        //        //{
        //        //    //products = products.Where(x => x.Name.ToLower().Contains(searchquery.ToLower()) || x.Code.ToLower().Contains(searchquery.ToLower()));


        //        //    var searchitem = JsonConvert.DeserializeObject<PurchaseFilterData>(searchquery);

        //        //    //if (searchitem.pageIndex != null)
        //        //    //{
        //        //    //    pageNo = searchitem.pageIndex.GetValueOrDefault(); // || x.Code.ToLower().Contains(searchitem.Name.ToLower())
        //        //    //    pageSize = searchitem.pageSize.GetValueOrDefault(); // || x.Code.ToLower().Contains(searchitem.Name.ToLower())


        //        //    //}



        //        //    if (searchitem.PurchaseCode != null)
        //        //    {
        //        //        purchaselist = purchaselist.Where(x => x.PurchaseCode.ToLower().Contains(searchitem.PurchaseCode.ToLower())); // || x.Code.ToLower().Contains(searchitem.Name.ToLower())

        //        //    }

        //        //    //if (searchitem.Remarks != null)
        //        //    //{
        //        //    //    purchaselist = purchaselist.Where(x => x.Remarks.ToLower().Contains(searchitem.Remarks.ToLower())); // || x.Code.ToLower().Contains(searchitem.Name.ToLower())

        //        //    //}

        //        //    //if (searchitem.VAmount != "")
        //        //    //{
        //        //    //    purchaselist = purchaselist.Where(x => x.VAmount.ToString() == searchitem.VAmount); // || x.Code.ToLower().Contains(searchitem.Name.ToLower())

        //        //    //}


        //        //    if (dtFrom != null)
        //        //    {
        //        //        purchaselist = purchaselist.Where(p => p.PurchaseDate >= dtFrom && p.PurchaseDate <= dtTo);

        //        //    }


        //        //    //if (searchitem.CategoryName != null)
        //        //    //{
        //        //    //    voucherlist = voucherlist.Where(x => x.AccountCategorys.AccountCategoryName.ToLower().Contains(searchitem.CategoryName.ToLower())); // || x.Code.ToLower().Contains(searchitem.Name.ToLower())

        //        //    //}



        //        //}
        //        //else
        //        //{



        //        //}

        //        //if (SupplierId != null)
        //        //{
        //        //    purchaselist = purchaselist.Where(x => x.SupplierId == SupplierId);
        //        //}
        //        //if (DocTypeId != null)
        //        //{
        //        //    purchaselist = purchaselist.Where(x => x.DocTypeId == DocTypeId);
        //        //}
        //        //if (UserId != null)
        //        //{
        //        //    purchaselist = purchaselist.Where(x => x.LuserId == UserId);
        //        //}
        //        //if (Status != null)
        //        //{
        //        //    purchaselist = purchaselist.Where(x => x.Status == Status);
        //        //}

        //        decimal TotalRecordCount = supplierlist.Count();
        //        var PageCountabc = decimal.Parse((TotalRecordCount / size).ToString());
        //        var PageCount = Math.Ceiling(PageCountabc);



        //        decimal skip = (page - 1) * size;

        //        // Get total number of records
        //        //int total = voucherlist.Count();



        //        var query = from e in supplierlist.Include(x => x.Suppliers)
        //                    //.Include(x => x.DocTypeList)
        //                    //.Include(x => x.ItemsCategory).ThenInclude(x => x.Acc_ChartOfAccount).ThenInclude(x => x.vAccountGroupHead)

        //                    select new
        //                    {
        //                        Id = e.Id,
        //                        SupplierName = e.SupplierName,
        //                        Email = e.Email,
        //                        OpBalance = e.OpBalance,
        //                        Phone=e.Phone,
        //                        //PurchaseUser = e.UserAccountList.Name,
        //                        //SupplierName = (e.SupplierName.Length == 0 || e.SupplierName == null) ? e.SupplierModel.SupplierName : e.SupplierModel.SupplierName + " - " + e.SupplierName,
        //                        //PrimaryAddress = e.PrimaryAddress,
        //                        //SecoundaryAddress = e.SecoundaryAddress,
        //                        //Notes = e.Notes,
        //                        //PhoneNo = e.PhoneNo,
        //                        //Discount = e.Discount,
        //                        //Total = e.Total,
        //                        //Status = e.Status,
        //                        //NetAmount = e.NetAmount,
        //                        //DocType = e.DocTypeList.DocType,
        //                        //isPOSPurchase = e.isPOSPurchase,
        //                        //isBatchPurchase = e.isBatchPurchase,
        //                        //isPosted = e.isPosted,
        //                        //Location = e.Warehouses.WhShortName,
        //                        ////StatusPosted = e.isPosted != false ? "Posted" : "Not Posted",
        //                        ////PaidAmt = e.PaidAmt,
        //                        ////PaymentHead = ""//e.CreditAccount != null ? e.CreditAccount.AccName : "=N/A="
        //                        //StatusPosted = e.isPosted != false ? "Posted" : "Not Posted",
        //                        //PaidAmt = e.PurchasePayments.Sum(x => x.Amount),
        //                    };


        //        //return Json(query);


        //        var abcd = query.OrderByDescending(x => x.Id).Skip(int.Parse(skip.ToString())).Take(int.Parse(size.ToString())).ToList();// Take(50);
        //        var pageinfo = new PagingInfo();
        //        pageinfo.PageCount = int.Parse(PageCount.ToString());
        //        pageinfo.PageNo = page;
        //        pageinfo.PageSize = int.Parse(size.ToString());
        //        pageinfo.TotalRecordCount = int.Parse(TotalRecordCount.ToString());

        //        //return  abcd;
        //        return Json(new { Success = 1, error = false, data = abcd, page = page, size = size, last_page = pageinfo.PageCount, total = pageinfo.TotalRecordCount });





        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex;
        //    }
        //}
        [AllowAnonymous]
        [HttpGet]
        public IActionResult ExecuteRecurrTransaction()
        {
            try
            {
                var ComId = HttpContext.Session.GetInt32("ComId");

                var data = recurringDetailsRepository.All().Where(x => x.ComId == ComId && x.PurchaseId != null).Include(x => x.PurchaseModel).ToList();

                foreach (var item in data)
                {
                    if (item.TemplateType != "Unscheduled")
                    {
                        string uniqueNumber = "RT-" + DateTime.Now.ToString("ddMMyyHHmmssfff");
                        if (item.Interval == "Daily")
                        {
                            if (item.NextDate == DateTime.Today && ((item.occurences > 0 && item.End_ == "After") || (item.PreviousDate != DateTime.Today)))
                            {
                                DateTime todayMidnight = new DateTime(DateTime.Today.Year, DateTime.Today.Month, DateTime.Today.Day, 0, 0, 0);
                                if (item.occurences > 0 && item.End_ == "After")
                                {
                                    //item.NextDate = item.PreviousDate?.AddDays(item.Every_);
                                    item.NextDate = todayMidnight.AddDays(item.Every_);
                                    item.occurences--;
                                }
                                if (item.PreviousDate != DateTime.Today)
                                {
                                    if (item.PreviousDate?.AddDays(item.Every_) <= item.RecurringEndDate)
                                    {
                                        item.NextDate = todayMidnight.AddDays(item.Every_);
                                    }

                                }
                                if (item.End_ == "None" && item.PreviousDate != DateTime.Today)
                                {
                                    item.NextDate = todayMidnight.AddDays(item.Every_);
                                }
                                item.PreviousDate = DateTime.Today;
                                var purchaseData = _purchaseRepository.All().Where(x => x.Id == item.PurchaseId).Include(x => x.Items).Include(x => x.PurchaseTags).Include(x => x.ItemsCategory).AsNoTracking().FirstOrDefault();
                                if (purchaseData != null)
                                {
                                    purchaseData.Id = 0;
                                    purchaseData.PurchaseCode = uniqueNumber;
                                    purchaseData.IsRecurring = false;
                                    purchaseData.IsPending = true;
                                    foreach (var Childitem in purchaseData.Items)
                                    {
                                        Childitem.Id = 0;
                                        Childitem.PurchaseId = 0;
                                    }
                                    foreach (var tag in purchaseData.PurchaseTags)
                                    {
                                        tag.Id = 0;
                                        tag.PurchaseId = 0;
                                    }
                                    foreach (var tax in purchaseData.ItemsCategory)
                                    {
                                        tax.Id = 0;
                                        tax.PurchaseId = 0;
                                    }
                                }


                                _purchaseRepository.Insert(purchaseData);
                                recurringDetailsRepository.Update(item, item.Id);
                            }

                        }
                        if (item.Interval == "Weekly")
                        {
                            if (item.NextDate == DateTime.Today && ((item.occurences > 0 && item.End_ == "After") || (item.PreviousDate != DateTime.Today)))
                            {
                                DateTime nextDate = (DateTime)FindNextDate(item.NextDate, item.Every_, item.Week_);

                                if (item.occurences > 0 && item.End_ == "After")
                                {
                                    item.NextDate = nextDate;
                                    item.occurences--;
                                }
                                if (item.PreviousDate != DateTime.Today)
                                {
                                    if (item.PreviousDate?.AddDays(item.Every_) <= item.RecurringEndDate)
                                    {
                                        item.NextDate = nextDate;
                                    }

                                }
                                if (item.End_ == "None" && item.PreviousDate != DateTime.Today)
                                {
                                    item.NextDate = nextDate;
                                }

                                item.PreviousDate = DateTime.Today;

                                var purchaseData = _purchaseRepository.All().Where(x => x.Id == item.SalesId).Include(x => x.Items).Include(x => x.PurchaseTags).Include(x => x.ItemsCategory).AsNoTracking().FirstOrDefault();
                                if (purchaseData != null)
                                {
                                    purchaseData.Id = 0;
                                    purchaseData.PurchaseCode = uniqueNumber;
                                    purchaseData.IsRecurring = false;
                                    purchaseData.IsPending = true;
                                    foreach (var Childitem in purchaseData.Items)
                                    {
                                        Childitem.Id = 0;
                                        Childitem.PurchaseId = 0;
                                    }
                                    foreach (var tag in purchaseData.PurchaseTags)
                                    {
                                        tag.Id = 0;
                                        tag.PurchaseId = 0;
                                    }
                                    foreach (var tax in purchaseData.ItemsCategory)
                                    {
                                        tax.Id = 0;
                                        tax.PurchaseId = 0;
                                    }
                                }


                                _purchaseRepository.Insert(purchaseData);
                                recurringDetailsRepository.Update(item, item.Id);
                            }
                        }
                        if (item.Interval == "Yearly")
                        {
                            if (item.NextDate == DateTime.Today && ((item.occurences > 0 && item.End_ == "After") || (item.PreviousDate != DateTime.Today)))
                            {
                                int dayOfMonth = GetNumericDay(item.Integer_);
                                DateTime nextDate = GetNextTransactionDate(item.RecurringStartDate, dayOfMonth, item.Month_, 1);
                                if (item.occurences > 0 && item.End_ == "After")
                                {
                                    item.NextDate = nextDate;
                                    item.occurences--;
                                }
                                if (item.PreviousDate != DateTime.Today)
                                {
                                    if (item.PreviousDate?.AddDays(item.Every_) <= item.RecurringEndDate)
                                    {
                                        item.NextDate = nextDate;
                                    }

                                }
                                if (item.End_ == "None" && item.PreviousDate != DateTime.Today)
                                {
                                    item.NextDate = nextDate;
                                }

                                item.PreviousDate = DateTime.Today;

                                var purchaseData = _purchaseRepository.All().Where(x => x.Id == item.SalesId).Include(x => x.Items).Include(x => x.PurchaseTags).Include(x => x.ItemsCategory).AsNoTracking().FirstOrDefault();
                                if (purchaseData != null)
                                {
                                    purchaseData.Id = 0;
                                    purchaseData.PurchaseCode = uniqueNumber;
                                    purchaseData.IsRecurring = false;
                                    purchaseData.IsPending = true;
                                    foreach (var Childitem in purchaseData.Items)
                                    {
                                        Childitem.Id = 0;
                                        Childitem.PurchaseId = 0;
                                    }
                                    foreach (var tag in purchaseData.PurchaseTags)
                                    {
                                        tag.Id = 0;
                                        tag.PurchaseId = 0;
                                    }
                                    foreach (var tax in purchaseData.ItemsCategory)
                                    {
                                        tax.Id = 0;
                                        tax.PurchaseId = 0;
                                    }
                                }


                                _purchaseRepository.Insert(purchaseData);
                                recurringDetailsRepository.Update(item, item.Id);
                            }
                        }
                        if (item.Interval == "Monthly")
                        {
                            if (item.NextDate == DateTime.Today && ((item.occurences > 0 && item.End_ == "After") || (item.PreviousDate != DateTime.Today)))
                            {
                                if (item.Count_ == "day")
                                {
                                    int dayOfMonth = GetNumericDay(item.Integer_);
                                    DateTime nextDate = GetNextTxnDateForMonth(item.RecurringStartDate, dayOfMonth, item.Every_);
                                    if (item.occurences > 0 && item.End_ == "After")
                                    {
                                        item.NextDate = nextDate;
                                        item.occurences--;
                                    }
                                    if (item.PreviousDate != DateTime.Today)
                                    {
                                        if (item.PreviousDate?.AddDays(item.Every_) <= item.RecurringEndDate)
                                        {
                                            item.NextDate = nextDate;
                                        }

                                    }
                                    if (item.End_ == "None" && item.PreviousDate != DateTime.Today)
                                    {
                                        item.NextDate = nextDate;
                                    }
                                }
                                else
                                {
                                    DateTime nextDate = CalculateNextTransactionDate(item.RecurringStartDate, item.Every_, item.Week_, item.Count_);
                                    if (item.occurences > 0 && item.End_ == "After")
                                    {
                                        item.NextDate = nextDate;
                                        item.occurences--;
                                    }
                                    if (item.PreviousDate != DateTime.Today)
                                    {
                                        if (item.PreviousDate?.AddDays(item.Every_) <= item.RecurringEndDate)
                                        {
                                            item.NextDate = nextDate;
                                        }

                                    }
                                    if (item.End_ == "None" && item.PreviousDate != DateTime.Today)
                                    {
                                        item.NextDate = nextDate;
                                    }
                                }
                                item.PreviousDate = DateTime.Today;

                                var purchaseData = _purchaseRepository.All().Where(x => x.Id == item.PurchaseId).Include(x => x.Items).Include(x => x.PurchaseTags).Include(x => x.ItemsCategory).AsNoTracking().FirstOrDefault();
                                if (purchaseData != null)
                                {
                                    purchaseData.Id = 0;
                                    purchaseData.PurchaseCode = uniqueNumber;
                                    purchaseData.IsRecurring = false;
                                    purchaseData.IsPending = true;
                                    foreach (var Childitem in purchaseData.Items)
                                    {
                                        Childitem.Id = 0;
                                        Childitem.PurchaseId = 0;
                                    }
                                    foreach (var tag in purchaseData.PurchaseTags)
                                    {
                                        tag.Id = 0;
                                        tag.PurchaseId = 0;
                                    }
                                    foreach (var tax in purchaseData.ItemsCategory)
                                    {
                                        tax.Id = 0;
                                        tax.PurchaseId = 0;
                                    }
                                }


                                _purchaseRepository.Insert(purchaseData);
                                recurringDetailsRepository.Update(item, item.Id);
                            }



                        }
                    }

                }

                return Json(new { Success = 1, ex = "Data " });
            }
            catch (Exception ex)
            {
                return Json(new { Success = 0, ex = ex.InnerException?.InnerException?.Message ?? ex.Message });
            }
        }

        static DateTime GetNextTxnDateForMonth(DateTime startDate, int dayOfMonth, int monthInterval)
        {
            DateTime nextDate = startDate.AddMonths(monthInterval);

            nextDate = new DateTime(nextDate.Year, nextDate.Month, dayOfMonth);

            while (nextDate <= startDate)
            {
                nextDate = nextDate.AddMonths(monthInterval);
            }

            return nextDate;
        }
        static DateTime CalculateNextTransactionDate(DateTime startDate, int monthInterval, string weekdayName, string week)
        {
            int weekNumber = 5;
            if (week == "first")
            {
                weekNumber = 1;
            }
            if (week == "second")
            {
                weekNumber = 2;
            }
            if (week == "third")
            {
                weekNumber = 3;
            }
            if (week == "fourth")
            {
                weekNumber = 4;
            }
            DayOfWeek targetDayOfWeek = (DayOfWeek)Enum.Parse(typeof(DayOfWeek), weekdayName);
            DateTime nextWeekday = startDate.AddDays((7 + (targetDayOfWeek - startDate.DayOfWeek)) % 7);
            DateTime targetMonth = nextWeekday.AddMonths(monthInterval);
            int daysToAdd = (weekNumber - 1) * 7;

            return targetMonth.AddDays(daysToAdd);
        }
        static DateTime? FindNextDate(DateTime? startDate, int weeksToSkip, string targetWeekday)
        {
            if (!startDate.HasValue)
            {
                return null;
            }
            DayOfWeek targetDayOfWeek = (DayOfWeek)Enum.Parse(typeof(DayOfWeek), targetWeekday);

            int daysToAdd = (int)targetDayOfWeek - (int)startDate.Value.DayOfWeek + 7 * weeksToSkip;

            DateTime nextDate = startDate.Value.AddDays(daysToAdd);

            return nextDate;
        }

        static int GetNumericDay(string dayOfMonthStr)
        {
            return int.Parse(dayOfMonthStr.Substring(0, dayOfMonthStr.Length - 2));
        }


        static DateTime GetNextTransactionDate(DateTime startDate, int dayOfMonth, string targetMonth, int intervalYears)
        {
            var monthDict = new System.Collections.Generic.Dictionary<string, int>
            {
                {"January", 1}, {"February", 2}, {"March", 3}, {"April", 4},
                {"May", 5}, {"June", 6}, {"July", 7}, {"August", 8},
                {"September", 9}, {"October", 10}, {"November", 11}, {"December", 12}
            };

            DateTime nextDate = new DateTime(startDate.Year, monthDict[targetMonth], dayOfMonth);

            if (nextDate <= startDate)
            {
                nextDate = nextDate.AddYears(intervalYears);
            }

            return nextDate;
        }

        
        [AllowAnonymous]
        public JsonResult GetPaymentList(int? UserId, int? Warehouse, int? IsPosted, int? VoucherTypeId, int? SupplierId, int? DocTypeId, int? Status, int? DeliveryMethod, int? PurchaseDate, int page = 1, decimal size = 5, string searchquery = "", string FromDate = "", string ToDate = "", int CopyBill = 0)
        {
            try
            {
                var CurrentUserId = HttpContext.Session.GetInt32("UserId");
                var ComId = HttpContext.Session.GetInt32("ComId");

                var TransactionId = 0;

                SqlParameter[] sqlParameter1 = new SqlParameter[2];
                sqlParameter1[0] = new SqlParameter("@ComId", ComId);
                sqlParameter1[1] = new SqlParameter("@TransactionId", TransactionId);
                Helper.ExecProc("[PaymentsApprovalStatus]", sqlParameter1);

                DateTime dtFrom = DateTime.MinValue;
                DateTime dtTo = DateTime.MaxValue;

                if (!string.IsNullOrEmpty(FromDate))
                    dtFrom = Convert.ToDateTime(FromDate);

                if (!string.IsNullOrEmpty(ToDate))
                    dtTo = Convert.ToDateTime(ToDate);



                var paymentlist = _transactionRepository.All().Where(x => x.IsDelete == false && x.SupplierId != null && x.isPayment == true);

                if (searchquery?.Length > 1)
                {
                    paymentlist = paymentlist.Where(x =>
                    x.TransactionCode.ToLower().Contains(searchquery.ToLower()) ||
                    x.Supplier.SupplierName.ToLower().Contains(searchquery.ToLower()) ||
                    x.TransactionAmount.ToString().ToLower().Contains(searchquery.ToLower()));
                    
                }


                if (dtFrom != null)
                {
                    paymentlist = paymentlist.Where(p => p.InputDate >= dtFrom && p.InputDate <= dtTo);

                }

                if (SupplierId != null)
                {
                    paymentlist = paymentlist.Where(x => x.SupplierId == SupplierId);
                }
                if (UserId != null)
                {
                    paymentlist = paymentlist.Where(x => x.LuserId == UserId);
                }


                decimal TotalRecordCount = paymentlist.Count();
                var PageCountabc = decimal.Parse((TotalRecordCount / size).ToString());
                var PageCount = Math.Ceiling(PageCountabc);



                decimal skip = (page - 1) * size;

                // Get total number of records
                //int total = voucherlist.Count();



                var query = from e in paymentlist.Include(x => x.TransactionDetails)
                                //.Include(x => x.DocTypeList)
                                //.Include(x => x.ItemsCategory).ThenInclude(x => x.Acc_ChartOfAccount).ThenInclude(x => x.vAccountGroupHead)

                            select new
                            {
                                Id = e.Id,
                                SupplierName = e.Supplier.SupplierName,
                                SupplierId = e.SupplierId,
                                //Amount = e.TransactionDetails
                                //         .Where(td => td.IsDelete == false)
                                //         .Select(td => td.Amount)
                                //         .FirstOrDefault(),
                                Amount = e.TransactionAmount,
                                PaymentDate = e.InputDate,
                                TransactionCode = e.TransactionCode,
                                Remarks = e.Description,
                                ApprovalStage = e.ApprovalStage,
                                isPost = e.isPost,
                            };


                //return Json(query);


                //var abcd = query.GroupBy(x => x.SupplierName).Skip(int.Parse(skip.ToString())).Take(int.Parse(size.ToString())).ToList();// Take(50);
                var abcd = query.OrderByDescending(x => x.Id).Skip(int.Parse(skip.ToString())).Take(int.Parse(size.ToString())).ToList();// Take(50);
                //var groupedResult = abcd.GroupBy(x => x.SupplierName).ToList();

                var pageinfo = new PagingInfo();
                pageinfo.PageCount = int.Parse(PageCount.ToString());
                pageinfo.PageNo = page;
                pageinfo.PageSize = int.Parse(size.ToString());
                pageinfo.TotalRecordCount = int.Parse(TotalRecordCount.ToString());

                //return  abcd;
                return Json(new { Success = 1, error = false, data = abcd, page = page, size = size, last_page = pageinfo.PageCount, total = pageinfo.TotalRecordCount });
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }





        [AllowAnonymous]
        [HttpGet]
        public IActionResult AddPurchaseEntry(string Type)
        {
            ViewBag.IsCopy = "0";
            ViewBag.ActionType = "Create";
            ViewBag.DocTypeId = 0;
            int PurchaseId = 0;


            var DocTypeId = _docTypeRepository.All().Where(x => x.DocType.ToLower() == "Purchase".ToLower()).FirstOrDefault().Id;

            if (!string.IsNullOrEmpty(Type))
            {
                DocTypeId = _docTypeRepository.All().Where(x => x.DocType.ToLower() == Type.ToLower() && x.DocFor == "Purchase").FirstOrDefault().Id;
                ViewBag.DocTypeId = DocTypeId;

                //            ViewBag.SalesType = Type;
            }
            ViewBag.DocTypeId = DocTypeId;
            //ViewBag.DocType = "7";

            return View(model: PurchaseId);
        }



        //[HttpGet]
        //[AllowAnonymous]
        //public IActionResult GetPurchaseListQB()
        //{
        //    try
        //    {
        //        var ComId = (HttpContext.Session.GetInt32("ComId"));
        //        var sessionLuserId = (HttpContext.Session.GetInt32("UserId"));

        //        if (ComId == null)
        //        {
        //            // Handle the case where ComId is not available in the session
        //            return Json(new { Success = "0", error = "ComId not found in session" });
        //        }

        //        var purchaselist = _purchaseRepository.AllData();

        //        var query = purchaselist
        //            .Where(p => p.ComId == ComId)
        //            .Include(x => x.Items).ThenInclude(x => x.PurchaseModel)
        //            .Select(p => new
        //            {
        //                p.Id,
        //                p.SupplierName,
        //                p.DueDate,
        //                p.NetAmount,
        //                OPBalance = p.NetAmount,
        //                p.Status,
        //            }).ToList();

        //        return Json(query);
        //    }
        //    catch (Exception ex)
        //    {
        //        return Json(new { Success = "0", error = ex.Message });
        //    }
        //}




        //[HttpPost]
        //[AllowAnonymous]
        //public IActionResult UploadImage(IFormFile file, [FromForm] string PurchaseIdAbc)
        //{
        //    var Purchaseinfo = _purchaseRepository.Find(int.Parse(PurchaseIdAbc));

        //    string filePath = configuration.GetValue<string>("MediaManager:VoucherFilePath");
        //    var folderPath = filePath + "/";
        //    var filename = string.Empty;

        //    if (file != null && file.Length > 0)
        //    {
        //        filename = Purchaseinfo.Id + '_' + Purchaseinfo.ComId + file.FileName;

        //        var path = Path.Combine(
        //            Directory.GetCurrentDirectory(), "wwwroot/Content/PurchaseBillImages",
        //            filename);

        //        using (var stream = new FileStream(path, FileMode.Create))
        //        {
        //            file.CopyTo(stream);
        //        }
        //        Purchaseinfo.FilePath = $"/Content/PurchaseBillImages/{filename}";

        //        string serverFolder = Path.Combine(_webHostEnvironment.WebRootPath, folderPath);
        //        serverFolder += Guid.NewGuid().ToString() + "_" + file.FileName;
        //        file.CopyToAsync(new FileStream(serverFolder, FileMode.Create));
        //        Purchaseinfo.PurchaseFilePath = serverFolder;
        //    }

        //    // Update the Purchaseinfo object even when no file was selected
        //    Purchaseinfo.FilePath = Purchaseinfo.FilePath;
        //    Purchaseinfo.PurchaseFilePath = Purchaseinfo.PurchaseFilePath;
        //    _purchaseRepository.Update(Purchaseinfo, Purchaseinfo.Id);

        //    return Json(new { status = "File upload Successfully." });
        //}

        [HttpPost]
        [AllowAnonymous]
        public IActionResult UploadImage(List<IFormFile> files, [FromForm] string PurchaseIdAbc)
        {
            var ComId = HttpContext.Session.GetInt32("ComId");
            var Purchaseinfo = _purchaseRepository.Find(int.Parse(PurchaseIdAbc));

            string filePath = configuration.GetValue<string>("MediaManager:VoucherFilePath");
            var folderPath = Path.Combine(_webHostEnvironment.WebRootPath, filePath);
            Directory.CreateDirectory(folderPath); // Ensure the directory exists

            if (files != null && files.Count > 0)
            {
                foreach (var file in files)
                {
                    if (file.Length > 0)
                    {
                        var filename = Purchaseinfo.Id.ToString() + '_' + Purchaseinfo.ComId.ToString() + "_" + file.FileName;
                        //var path = Path.Combine(folderPath, filename);
                        var path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/Content/PurchaseBillImages", filename);

                        using (var stream = new FileStream(path, FileMode.Create))
                        {
                            file.CopyTo(stream);
                        }
                        // Update the invoice_info with each file uploaded
                        Purchaseinfo.FilePath += $"/Content/PurchaseBillImages/{filename};";
                    }
                }
            }
            else
            {
                // Handle the case where no file was selected if necessary
                Purchaseinfo.FilePath = Purchaseinfo.FilePath;
            }

            _purchaseRepository.Update(Purchaseinfo, Purchaseinfo.Id);

            return Json(new { status = "Files uploaded successfully." });
        }


        [AllowAnonymous]
        [HttpPost]
        public IActionResult DeleteFileName(string fileName)
        {
            try
            {
                var ComId = HttpContext.Session.GetInt32("ComId");

                string[] parts = fileName.Split('/');
                string lastPart = parts[parts.Length - 1];
                string[] subparts = lastPart.Split('_');
                var firstPart = int.Parse(subparts[0]);

                var model = _purchaseRepository.Find(firstPart);


                model.FilePath = model.FilePath.Replace(fileName + ";", "");


                // Update model in repository if needed
                _purchaseRepository.Update(model, model.Id);

                return Json(new { Success = 1, ex = "Data " });
            }
            catch (Exception ex)
            {
                return Json(new { Success = 0, ex = ex.InnerException?.InnerException?.Message ?? ex.Message });
            }
        }

        public string GetPurchaseCode(int doctypeId)
        {
            var ComId = HttpContext.Session.GetInt32("ComId");

            var docPrefix = docPrefixRepository.All().Where(x => x.ComId == ComId && x.DocTypeId == doctypeId).FirstOrDefault();

            if (docPrefix.MonthSuffix == false && docPrefix.YearSuffix == false && docPrefix.DateSuffix == false)
            {
                var docNo = docPrefix.LastDocNo + 1;
                var code = docPrefix.DocPrefix + "_" + docNo.ToString();

                docPrefix.LastDocNo += 1;
                docPrefix.LastGeneratedCode = code;
                docPrefixRepository.Update(docPrefix, docPrefix.Id);
                return code;
            }
            else if (docPrefix.YearSuffix == true)
            {
                string yearFormat = docPrefix.Format.Contains("yyyy") ? "yyyy" : "yy";


                DateTime currentDate = DateTime.Now;

                int currentYear = int.Parse(currentDate.ToString(yearFormat));

                if (docPrefix.LastGeneratedCode == null)
                {
                    var docNo = docPrefix.LastDocNo + 1;
                    var code = docPrefix.DocPrefix + "_" + currentYear.ToString() + "_" + docNo.ToString();

                    docPrefix.LastDocNo += 1;
                    docPrefix.LastGeneratedCode = code;
                    docPrefixRepository.Update(docPrefix, docPrefix.Id);
                    return code;
                }
                else
                {
                    int firstUnderscoreIndex = docPrefix.LastGeneratedCode.IndexOf('_');

                    int secondUnderscoreIndex = docPrefix.LastGeneratedCode.IndexOf('_', firstUnderscoreIndex + 1);

                    int yearSubstring = int.Parse(docPrefix.LastGeneratedCode.Substring(firstUnderscoreIndex + 1, secondUnderscoreIndex - firstUnderscoreIndex - 1));

                    if (yearFormat == "yy" && yearSubstring > 100)
                    {
                        yearSubstring = yearSubstring % 100;
                    }

                    if (yearSubstring < currentYear)
                    {
                        var docNo = docPrefix.FirstDocNo + 1;
                        var code = docPrefix.DocPrefix + "_" + currentYear.ToString() + "_" + docNo.ToString();

                        docPrefix.LastDocNo = docPrefix.FirstDocNo;
                        docPrefix.LastDocNo += 1;
                        docPrefix.LastGeneratedCode = code;
                        docPrefixRepository.Update(docPrefix, docPrefix.Id);
                        return code;
                    }
                    else
                    {
                        var docNo = docPrefix.LastDocNo + 1;
                        var code = docPrefix.DocPrefix + "_" + currentYear.ToString() + "_" + docNo.ToString();

                        docPrefix.LastDocNo += 1;
                        docPrefix.LastGeneratedCode = code;
                        docPrefixRepository.Update(docPrefix, docPrefix.Id);
                        return code;
                    }
                }
            }
            else if (docPrefix.MonthSuffix == true)
            {
                DateTime currentDate = DateTime.Now;

                string[] formatparts = docPrefix.Format.Split('/');


                int currentYear = int.Parse(currentDate.ToString(formatparts[1]));
                int currentMonth = int.Parse(currentDate.ToString(formatparts[0]));

                if (docPrefix.LastGeneratedCode == null)
                {
                    var docNo = docPrefix.LastDocNo + 1;
                    var code = docPrefix.DocPrefix + "_" + currentMonth.ToString() + "/" + currentYear.ToString() + "_" + docNo.ToString();

                    docPrefix.LastDocNo += 1;
                    docPrefix.LastGeneratedCode = code;
                    docPrefixRepository.Update(docPrefix, docPrefix.Id);
                    return code;
                }
                else
                {
                    string[] parts = docPrefix.LastGeneratedCode.Split('_');
                    string[] parts2 = parts[1].Split('/');

                    int month = int.Parse(parts2[0]);
                    int year = int.Parse(parts2[1]);

                    if (month < currentMonth && year <= currentYear)
                    {
                        var docNo = docPrefix.FirstDocNo + 1;
                        var code = docPrefix.DocPrefix + "_" + currentMonth.ToString() + "/" + currentYear.ToString() + "_" + docNo.ToString();

                        docPrefix.LastDocNo = docPrefix.FirstDocNo;
                        docPrefix.LastDocNo += 1;
                        docPrefix.LastGeneratedCode = code;
                        docPrefixRepository.Update(docPrefix, docPrefix.Id);
                        return code;
                    }
                    else
                    {
                        var docNo = docPrefix.LastDocNo + 1;
                        var code = docPrefix.DocPrefix + "_" + currentMonth.ToString() + "/" + currentYear.ToString() + "_" + docNo.ToString();

                        docPrefix.LastDocNo += 1;
                        docPrefix.LastGeneratedCode = code;
                        docPrefixRepository.Update(docPrefix, docPrefix.Id);
                        return code;
                    }
                }
            }
            else if (docPrefix.DateSuffix == true)
            {
                DateTimeOffset currentDate = DateTimeOffset.Now;

                var dateFormat = docPrefix.Format;
                string formattedDate = $"{currentDate.ToString(dateFormat)}";


                if (docPrefix.LastGeneratedCode == null)
                {
                    var docNo = docPrefix.LastDocNo + 1;
                    var code = docPrefix.DocPrefix + "_" + formattedDate + "_" + docNo.ToString();

                    docPrefix.LastDocNo += 1;
                    docPrefix.LastGeneratedCode = code;
                    docPrefixRepository.Update(docPrefix, docPrefix.Id);
                    return code;
                }
                else
                {
                    string inputString = docPrefix.LastGeneratedCode;
                    string[] parts = inputString.Split('_');

                    string dateString = parts[1];

                    DateTime date = DateTime.Parse(dateString);

                    if (date.Date < currentDate.Date)
                    {
                        var docNo = docPrefix.FirstDocNo + 1;
                        var code = docPrefix.DocPrefix + "_" + formattedDate + "_" + docNo.ToString();

                        docPrefix.LastDocNo = docPrefix.FirstDocNo;
                        docPrefix.LastDocNo += 1;
                        docPrefix.LastGeneratedCode = code;
                        docPrefixRepository.Update(docPrefix, docPrefix.Id);
                        return code;
                    }
                    else
                    {
                        var docNo = docPrefix.LastDocNo + 1;
                        var code = docPrefix.DocPrefix + "_" + formattedDate + "_" + docNo.ToString();

                        docPrefix.LastDocNo += 1;
                        docPrefix.LastGeneratedCode = code;
                        docPrefixRepository.Update(docPrefix, docPrefix.Id);
                        return code;
                    }
                }
            }

            return "";
        }

        [AllowAnonymous]
        public JsonResult GetTermsList()
        {
            var ComId = HttpContext.Session.GetInt32("ComId");

            var company = termMainRepository.GetAllForDropDown();
            return Json(company);
        }

        public void InsertIntoAuditLog(int? doctypeId , string actionType, string keyValue, int Id)
        {
            var model = new AuditLogModel();

            model.DocType = _docTypeRepository.All().Where(x => x.Id == doctypeId).FirstOrDefault().DocType;
            model.DocTypeId = doctypeId ?? 0;
            model.KeyValue = keyValue;
            model.TransactionId = Id;
            model.Action = actionType;

            auditLogRepository.Insert(model);
        }

        [HttpPost]
        [AllowAnonymous]
        public IActionResult AddPurchase([FromBody] PurchaseModel model, string doctype, int CopyBill = 0)
        {
            try
            {
                var UserId = HttpContext.Session.GetInt32("UserId");
                var ComId = HttpContext.Session.GetInt32("ComId");

                var errors = ModelState.Where(x => x.Value.Errors.Any())
                .Select(x => new { x.Key, x.Value.Errors });

                if (model.SupplierId == 0)
                {
                    model.SupplierId = null;
                }

                if (ModelState.IsValid)
                {
                    if (model.Id > 0)
                    {
                        var sqlquery = $"EXEC [PurchaseStatusUpdate] '{ComId}', '' ,''";

                        SqlParameter[] sqlParameter = new SqlParameter[3];
                        sqlParameter[0] = new SqlParameter("@ComId", ComId);
                        sqlParameter[1] = new SqlParameter("@PurchaseId", "");
                        sqlParameter[2] = new SqlParameter("@SupplierId", "");
                        Helper.ExecProc("PurchaseStatusUpdate", sqlParameter);

                        model.PurchaseCode = _purchaseRepository.All().Where(x => x.Id == model.Id).FirstOrDefault().PurchaseCode;

                        _purchaseRepository.Update(model, model.Id);

                        var settings = new JsonSerializerSettings
                        {
                            PreserveReferencesHandling = PreserveReferencesHandling.Objects
                        };

                        string modelStringify = JsonConvert.SerializeObject(model, settings);

                        InsertIntoAuditLog(model.DocTypeId , "Update", modelStringify, model.Id);

                        var CurrentVoucherTag = _purchaseTagsRepository.All().Where(p => p.PurchaseId == model.Id).ToList();

                        _purchaseTagsRepository.RemoveRange(CurrentVoucherTag);

                        if (model.PurchaseCode == null)
                        {
                            model.PurchaseCode = "PC-" + DateTime.Now.ToString("ddMMyyHHmmssfff");
                            model.SupplierId = (model.SupplierId == 0) ? null : model.SupplierId;

                        }
                        var purchaseData = _purchaseTagsRepository.All().Where(x => x.PurchaseId == model.Id).ToList();
                        if (purchaseData.Count > 0)
                        {
                            foreach (var item in purchaseData)
                            {
                                _purchaseTagsRepository.Delete(item);
                            }
                        }
                        for (int i = 0; i < model.VoucherTags.Length; i++)
                        {

                            //PurchaseTagModel vouchertags = new PurchaseTagModel { tag = (model.VoucherTags[i]), PurchaseId = model.Id };
                            PurchaseTagModel purchasetags = new PurchaseTagModel { TagsId = int.Parse(model.VoucherTags[i]), ComId = model.ComId, PurchaseId = model.Id };
                            _purchaseTagsRepository.Insert(purchasetags);

                        }

                        var previousitemCategory = _purchaseItemCategoryRepository.All().Where(x => x.PurchaseId == model.Id).ToList();
                        var tmpCat = previousitemCategory.Where(x => !model.ItemsCategory.Any(z => x.Id == z.Id)).ToList();
                        _purchaseItemCategoryRepository.RemoveRange(tmpCat);


                        var puchaseterms = purchaseTermsRepository.All().Where(x => x.PurchaseId == model.Id).ToList();
                        purchaseTermsRepository.RemoveRange(puchaseterms);

                        if (model.PurchaseTerms != null)
                        {
                            foreach (var item in model.PurchaseTerms)
                            {
                                item.PurchaseId = model.Id;
                                item.Id = 0;
                                purchaseTermsRepository.Insert(item);
                            }

                        }

                        var itemCategoryfinalist = model.ItemsCategory.Where(x => x.Amount > 0).ToList();
                        model.ItemsCategory = itemCategoryfinalist;

                        if (model.ItemsCategory != null)
                        {
                            foreach (PurchaseItemsCategoryModel item in model.ItemsCategory)
                            {
                                if (item.Id > 0 && item.AccId > 0)
                                {
                                    if (item.IsDelete)
                                    {
                                        int z = item.Id;
                                        _purchaseItemCategoryRepository.Delete(item);
                                    }
                                    else
                                    {
                                        _purchaseItemCategoryRepository.Update(item, item.Id);
                                    }
                                }
                                else if (!item.IsDelete)
                                {
                                    _purchaseItemCategoryRepository.Insert(item);
                                }
                            }
                        }


                        var previousitem = _purchaseItemRepository.All().Where(x => x.PurchaseId == model.Id).ToList();
                        var tmp = previousitem.Where(x => !model.Items.Any(z => x.Id == z.Id)).ToList();
                        _purchaseItemRepository.RemoveRange(tmp);


                        var itemfinalist = model.Items.Where(x => x.Amount > 0).ToList();
                        model.Items = itemfinalist;

                        foreach (PurchaseItemsModel item in model.Items)
                        {
                            if (item.Id > 0 && item.ProductId > 0)
                            {
                                if (item.IsDelete)
                                {
                                    int z = item.Id;
                                    _purchaseItemRepository.Delete(item);
                                }
                                else
                                {
                                    _purchaseItemRepository.Update(item, item.Id);
                                }
                            }
                            else if (!item.IsDelete)
                            {
                                item.PurchaseId = model.Id;
                                _purchaseItemRepository.Insert(item);
                            }
                        }

                        var purchaseTax = _purchaseProductRepository.All().Where(x=>x.PurchaseId == model.Id).ToList();
                        _purchaseProductRepository.RemoveRange(purchaseTax);

                        foreach(var item in model.PurchaseProductTax)
                        {
                            item.PurchaseId = model.Id;
                            _purchaseProductRepository.Insert(item);
                        }

                        var salespaymentsdata = _purchasePaymentRepository.All().Where(x => x.PurchaseId == model.Id && x.TransactionId == null).ToList();
                        _purchasePaymentRepository.RemoveRange(salespaymentsdata);

                        //var paymentfinalist = model.PurchasePayments.Where(x => x.AccountHeadId != null).ToList();
                        //model.PurchasePayments = paymentfinalist;

                        foreach (PurchasePaymentModel item in model.PurchasePayments.Where(x => x.IsDelete == false))
                        {
                            _purchasePaymentRepository.Insert(item);
                        }
                        TempData["Message"] = "Data Update Successfully";
                        TempData["Status"] = "2";
                        tranlog.TransactionLog(RouteData.Values["controller"].ToString(), RouteData.Values["action"].ToString(), TempData["Message"].ToString(), model.Id.ToString(), "Update", model.PurchaseCode);

                        if (model.EmailId != null)
                        {
                            var email = model.EmailId;

                            var EmailSubject = _customFormStyleRepository.All().Where(x => x.ComId == ComId && x.IsDefault == true).FirstOrDefault().StandardEmailSubject;
                            var EmailBody = _customFormStyleRepository.All().Where(x => x.ComId == ComId && x.IsDefault == true).FirstOrDefault().StandardEmailTemplateHolder;

                            Console.WriteLine(EmailBody);

                            EmailBody = EmailBody.Replace("[amount]", model.PurchaseCode)
                           .Replace("[date]", model.PurchaseDate.ToString("dd-MMM-yyyy"))
                           .Replace("[balancedue]", model.NetAmount.ToString("N"))
                            .Replace("[FullName]", model.SupplierName)
                            .Replace("[First][Last]", model.SupplierName)
                            .Replace("[Title][Last]", model.SupplierName)
                            .Replace("[First]", model.SupplierName)
                            .Replace("[CompanyName]", model.SupplierName)
                            .Replace("[DisplayName]", model.SupplierName);


                            if (email.Length > 9)
                            {
                                _emailsender.SendEmailAsync(email, EmailSubject + "[MODIFIED]", EmailBody);

                            }

                        }



                        return Json(new { error = false, message = "Purchase updated successfully", Id = model.Id });



                        var sqlquery1 = $"EXEC [PurchaseStatusUpdate] '{ComId}', '' ,''";

                        SqlParameter[] sqlParameter1 = new SqlParameter[3];
                        sqlParameter1[0] = new SqlParameter("@ComId", ComId);
                        sqlParameter1[1] = new SqlParameter("@PurchaseId", "");
                        sqlParameter1[2] = new SqlParameter("@SupplierId", "");
                        Helper.ExecProc("PurchaseStatusUpdate", sqlParameter);
                    }
                    else
                    {
                        var itemToRemove = model.Items.Where(x => x.IsDelete == true).ToList();

                        var type = _docTypeRepository.All().Where(x => x.Id == model.DocTypeId).Select(x => x.DocType).FirstOrDefault();

                        if (type == "Purchase Order")
                        {
                            model.PurchaseCode = "P0-" + DateTime.Now.ToString("ddMMyyHHmmssfff");
                        }
                        else
                        if (type == "Bill")
                        {
                            model.PurchaseCode = "BL-" + DateTime.Now.ToString("ddMMyyHHmmssfff");
                        }
                        else
                        if (type == "Expense")
                        {
                            model.PurchaseCode = "Ex-" + DateTime.Now.ToString("ddMMyyHHmmssfff");
                        }
                        else
                        if (type == "Cheque")
                        {
                            model.PurchaseCode = "Cq-" + DateTime.Now.ToString("ddMMyyHHmmssfff");
                        }
                        else
                        if (type == "Supplier credit")
                        {
                            model.PurchaseCode = "SC-" + DateTime.Now.ToString("ddMMyyHHmmssfff");
                        }
                        else
                        if (type == "Supplier PO")
                        {
                            model.PurchaseCode = "SPO-" + DateTime.Now.ToString("ddMMyyHHmmssfff");
                        }
                        else
                        {
                            model.PurchaseCode = "PC-" + DateTime.Now.ToString("ddMMyyHHmmssfff");
                        }

                        var docPrefix = docPrefixRepository.All().Where(x => x.ComId == ComId && x.DocTypeId == model.DocTypeId).FirstOrDefault();
                        if (docPrefix != null)
                        {
                            model.PurchaseCode = GetPurchaseCode(model.DocTypeId ?? 0);
                        }

                        foreach (var item in itemToRemove)
                        {
                            model.Items.Remove(item);
                        }


                        if (model.ItemsCategory != null)
                        {
                            foreach (var item in model.ItemsCategory.Where(x => x.IsDelete == false))
                            {

                                item.CreateDate = DateTime.Now;
                                item.UpdateDate = DateTime.Now;
                                item.ComId = int.Parse(ComId.ToString());
                                item.LuserId = int.Parse(UserId.ToString());
                                if (item.PurchaseItemsCategoryId == 0)
                                {
                                    item.PurchaseItemsCategoryId = null;
                                }

                            }
                        }


                        foreach (var item in model.Items.Where(x => x.IsDelete == false))
                        {

                            item.CreateDate = DateTime.Now;
                            item.UpdateDate = DateTime.Now;
                            item.ComId = int.Parse(ComId.ToString());
                            item.LuserId = int.Parse(UserId.ToString());
                            item.PurchaseItems = null;
                            if (item.PurchaseItemsId == 0)
                            {
                                item.PurchaseItemsId = null;
                            }


                            if (item.PurchaseBatchItems != null)
                            {
                                foreach (var Batchitem in item.PurchaseBatchItems)
                                {

                                    Batchitem.CreateDate = DateTime.Now;
                                    Batchitem.UpdateDate = DateTime.Now;
                                    Batchitem.ComId = int.Parse(ComId.ToString());
                                    Batchitem.LuserId = int.Parse(UserId.ToString());
                                    //Batchitem.ComId = int.Parse(ComId.ToString());

                                }
                            }

                        }
                        foreach (var item in model.PurchasePayments.Where(x => x.IsDelete == false))
                        {

                            item.CreateDate = DateTime.Now;
                            item.UpdateDate = DateTime.Now;
                            item.ComId = int.Parse(ComId.ToString());
                            item.LuserId = int.Parse(UserId.ToString());

                        }


                        //var itemscategorylist = model.ItemsCategory;//.Where(item => item.AccId == 0).ToList();
                        //itemscategorylist.Clear;
                        if (model.ItemsCategory != null)
                        {
                            var itemcategoryfinalist = model.ItemsCategory.Where(x => x.AccId != 0).ToList();
                            model.ItemsCategory = itemcategoryfinalist;
                        }


                        var itemfinalist = model.Items.Where(x => x.ProductId != 0).ToList();
                        model.Items = itemfinalist;

                        //itemscategorylist.Remove(item => item.AccId == 0);
                        //foreach (var item in itemscategorylist.Where(x=>x.AccId != 0))
                        //{
                        //    if (item.AccId == 0)
                        //    {
                        //        itemscategorylist.Remove(item);
                        //    }

                        //}



                        model.PurchaseTags = new List<PurchaseTagModel>();
                        if (model.VoucherTags != null)
                        {
                            for (int i = 0; i < model.VoucherTags.Length; i++)
                            {
                                //PurchaseTagModel purchasetags = new PurchaseTagModel { tag = (model.VoucherTags[i]), ComId = model.ComId }; 
                                PurchaseTagModel purchasetags = new PurchaseTagModel { TagsId = int.Parse(model.VoucherTags[i]), ComId = model.ComId };
                                model.PurchaseTags.Add(purchasetags);
                            }
                            //acc_voucherMain.VoucherTranGroupList = text.TrimEnd(',');
                        }
                        _purchaseRepository.Insert(model);

                        var settings = new JsonSerializerSettings
                        {
                            PreserveReferencesHandling = PreserveReferencesHandling.Objects
                        };

                        string modelStringify = JsonConvert.SerializeObject(model, settings);

                        InsertIntoAuditLog(model.DocTypeId, "Create", modelStringify, model.Id);

                        TempData["Message"] = "Data Save Successfully";
                        TempData["Status"] = "1";
                        tranlog.TransactionLog(RouteData.Values["controller"].ToString(), RouteData.Values["action"].ToString(), TempData["Message"].ToString(), model.Id.ToString(), "Create", model.PurchaseCode);

                        var sqlquery = $"EXEC [PurchaseStatusUpdate] '{ComId}', '' ,''";
                        Console.WriteLine(sqlquery);

                        SqlParameter[] sqlParameter = new SqlParameter[3];
                        sqlParameter[0] = new SqlParameter("@ComId", ComId);
                        sqlParameter[1] = new SqlParameter("@PurchaseId", "");
                        sqlParameter[2] = new SqlParameter("@SupplierId", "");
                        Helper.ExecProc("PurchaseStatusUpdate", sqlParameter);
                        if (model.SupplierId != null)
                        {
                            var supplierEmail = _supplierRepository.All().Where(x => x.Id == model.SupplierId).FirstOrDefault().Email;
                            supplierEmail = supplierEmail == null ? null : supplierEmail;
                            var email = model.EmailId == null ? supplierEmail : model.EmailId;

                            if (email != null)
                            {

                                var EmailSubject = _customFormStyleRepository.All().Where(x => x.ComId == ComId && x.IsDefault == true).FirstOrDefault()?.StandardEmailSubject ?? "EmailSubject";
                                var EmailBody = _customFormStyleRepository.All().Where(x => x.ComId == ComId && x.IsDefault == true).FirstOrDefault()?.StandardEmailTemplateHolder ?? "EmailBody";

                                Console.WriteLine(EmailBody);

                                EmailBody = EmailBody.Replace("[amount]", model.PurchaseCode)
                               .Replace("[date]", model.PurchaseDate.ToString("dd-MMM-yyyy"))
                               .Replace("[balancedue]", model.NetAmount.ToString("N"))
                                .Replace("[FullName]", model.SupplierName)
                                .Replace("[First][Last]", model.SupplierName)
                                .Replace("[Title][Last]", model.SupplierName)
                                .Replace("[First]", model.SupplierName)
                                .Replace("[CompanyName]", model.SupplierName)
                                .Replace("[DisplayName]", model.SupplierName);


                                if (email.Length > 9)
                                {
                                    //_emailsender.SendEmailAsync(email, EmailSubject + "[MODIFIED]", EmailBody);
                                    _emailsender.SendEmailAsync(email, EmailSubject ?? "", EmailBody ?? "");

                                }



                            }
                        }


                        return Json(new { error = false, message = "Purchase saved successfully", Id = model.Id, Doctype = doctype });


                    }



                }
                else
                {

                    return Json(new { error = true, message = "failed to save Purchase" });
                }



            }
            catch (Exception ex)
            {

                return Json(new { error = true, message = ex.Message });
            }
        }



        //[HttpPost]
        //[AllowAnonymous]
        //public IActionResult AddPurchase([FromBody] PurchaseModel model,int CopyBill =0)
        //{
        //    try
        //    {
        //        var UserId = HttpContext.Session.GetInt32("UserId");
        //        var ComId = HttpContext.Session.GetInt32("ComId");

        //        var errors = ModelState.Where(x => x.Value.Errors.Any())
        //        .Select(x => new { x.Key, x.Value.Errors });

        //        if (ModelState.IsValid)
        //        {
        //            if (model.Id > 0)
        //            {
        //                _purchaseRepository.Update(model, model.Id);
        //                foreach (PurchaseItemsModel item in model.Items)
        //                {

        //                    if (item.Id > 0)
        //                    {
        //                        if (item.IsDelete == true)
        //                        {
        //                            int z = item.Id;
        //                            _purchaseItemRepository.Delete(item);

        //                        }
        //                        else
        //                        {
        //                            if (item.isTransaction == true)//item.IsDelete == false &&  
        //                            {
        //                                if (item.PurchaseBatchItems != null)
        //                                {
        //                                    foreach (PurchaseBatchItemsModel batchitem in item.PurchaseBatchItems)
        //                                    {
        //                                        if (batchitem.Id > 0)
        //                                        {
        //                                            if (batchitem.IsDelete == true)
        //                                            {
        //                                                int z = batchitem.Id;
        //                                                _purchaseBatchItemRepository.Delete(batchitem);

        //                                            }
        //                                            else
        //                                            {
        //                                                if (batchitem.IsTransaction == true)
        //                                                {
        //                                                    batchitem.ComId = ComId.GetValueOrDefault();
        //                                                    batchitem.LuserId = UserId.GetValueOrDefault();


        //                                                    _purchaseBatchItemRepository.Update(batchitem, batchitem.Id);
        //                                                }
        //                                            }
        //                                        }
        //                                        else if (batchitem.Id == 0 && batchitem.IsDelete == false)
        //                                        {
        //                                            batchitem.ComId = ComId.GetValueOrDefault();
        //                                            batchitem.LuserId = UserId.GetValueOrDefault();
        //                                            _purchaseBatchItemRepository.Insert(batchitem);
        //                                        }


        //                                    }
        //                                }

        //                                _purchaseItemRepository.Update(item, item.Id);

        //                            }
        //                        }
        //                    }
        //                    else
        //                    {
        //                        if (item.IsDelete == true)
        //                        {
        //                        }
        //                        else
        //                        {
        //                            _purchaseItemRepository.Insert(item);


        //                            //if (item.PurchaseBatchItems != null)
        //                            //{
        //                            //    foreach (PurchaseBatchItemsModel batchitem in item.PurchaseBatchItems)
        //                            //    {
        //                            //        if (batchitem.IsDelete == true)
        //                            //        {

        //                            //        }
        //                            //        else
        //                            //        {
        //                            //            _purchaseBatchItemRepository.Insert(batchitem);
        //                            //        }


        //                            //    }
        //                            //}

        //                        }
        //                    }
        //                }


        //                var salespaymentsdata = _purchasePaymentRepository.All().Where(x => x.PurchaseId == model.Id && x.TransactionId == null).ToList();
        //                _purchasePaymentRepository.RemoveRange(salespaymentsdata);


        //                foreach (PurchasePaymentModel item in model.PurchasePayments.Where(x => x.IsDelete == false))
        //                {
        //                    _purchasePaymentRepository.Insert(item);
        //                }



        //                //var items = _purchaseItemRepository.AllSubData().Where(x => x.PurchaseId == model.Id).ToList();
        //                //if (items.Any())
        //                //{
        //                //    _purchaseItemRepository.RemoveRange(items.ToList());

        //                //    //foreach (var item in items)
        //                //    //{
        //                //    //    _purchaseItemRepository.Delete(item);
        //                //    //}
        //                //}
        //                //_purchaseRepository.Update(model, model.Id);


        //                //if (model.Items != null)
        //                //{

        //                //    _purchaseItemRepository.AddRange(model.Items);

        //                //    //foreach (PurchaseItemsModel data in model.Items)
        //                //    //{
        //                //    //    //ss.DateAdded = DateTime.Now;
        //                //    //    //ss.DateUpdated = DateTime.Now;

        //                //    //    _purchaseItemRepository.Insert(data);
        //                //    //    //db.SaveChanges();
        //                //    //}
        //                //    //db.SaveChanges();

        //                //}

        //                ////var Purchase = _purchaseRepository.Find(model.Id);
        //                ////Purchase.SupplierName = model.SupplierName;
        //                ////Purchase.PrimaryAddress = model.PrimaryAddress;
        //                ////Purchase.PhoneNo = model.PhoneNo;

        //                ////Purchase.Notes = model.Notes;
        //                ////Purchase.PaymentMethod = model.PaymentMethod;
        //                ////Purchase.PurchaseCode = model.PurchaseCode;
        //                ////Purchase.SupplierId = model.SupplierId;
        //                ////Purchase.Total = model.Total;
        //                ////Purchase.PurchaseDate = model.PurchaseDate;
        //                ////Purchase.Status = model.Status;
        //                ////Purchase.Discount = model.Discount;

        //                ////Purchase.ServiceCharge = model.ServiceCharge;
        //                ////Purchase.Shipping = model.Shipping;
        //                ////Purchase.TotalVat = model.TotalVat;

        //                ////Purchase.GrandTotal = model.GrandTotal;

        //                ////Purchase.NetAmount = model.NetAmount;
        //                ////Purchase.PaidAmt = model.PaidAmt;
        //                ////Purchase.DisAmt = model.DisAmt;
        //                ////Purchase.DueAmt = model.DueAmt;





        //                ////add again
        //                ////foreach (var item in model.Items)
        //                ////{

        //                ////    //if (item.PurchaseBatchItems != null)
        //                ////    //{
        //                ////    //    foreach (var batchitem in item.PurchaseBatchItems)
        //                ////    //    {
        //                ////    //        item.PurchaseBatchItems.Add(new PurchaseBatchItemsModel
        //                ////    //        {
        //                ////    //            BatchSerialNo = batchitem.BatchSerialNo,
        //                ////    //            Price = batchitem.Price,
        //                ////    //            Quantity = batchitem.Quantity,
        //                ////    //            BatchRemarks = batchitem.BatchRemarks,
        //                ////    //            ProductId = batchitem.ProductId,
        //                ////    //            SLNo = batchitem.SLNo,
        //                ////    //            CreateDate = DateTime.Now,
        //                ////    //            UpdateDate = DateTime.Now,
        //                ////    //            ComId = int.Parse(ComId.ToString())
        //                ////    //        });
        //                ////    //    }
        //                ////    //}


        //                ////    //Purchase.Items.Add(new PurchaseItemsModel
        //                ////    //{
        //                ////    //    Id = item.Id,
        //                ////    //    WarehouseId = item.WarehouseId,
        //                ////    //    Price = item.Price,
        //                ////    //    Amount = item.Amount,
        //                ////    //    Quantity = item.Quantity,
        //                ////    //    Name = item.Name,
        //                ////    //    ProductId = item.ProductId,
        //                ////    //    Description = item.Description,
        //                ////    //    CreateDate = DateTime.Now,
        //                ////    //    UpdateDate = DateTime.Now,
        //                ////    //    ComId = int.Parse(ComId.ToString()),
        //                ////    //    PurchaseBatchItems = item.PurchaseBatchItems,
        //                ////    //    IsDelete = false,
        //                ////    //});
        //                ////}
        //                ////_purchaseRepository.Update(model, model.Id);



        //                TempData["Message"] = "Data Update Successfully";
        //                TempData["Status"] = "2";
        //                tranlog.TransactionLog(RouteData.Values["controller"].ToString(), RouteData.Values["action"].ToString(), TempData["Message"].ToString(), model.Id.ToString(), "Update", model.PurchaseCode);

        //                return Json(new { error = false, message = "Purchase updated successfully", Id = model.Id });
        //            }
        //            else
        //            {

        //                //var UserId = HttpContext.Session.GetInt32("UserId");
        //                //var ComId = HttpContext.Session.GetInt32("ComId");


        //                var itemToRemove = model.Items.Where(x => x.IsDelete == true).ToList();


        //                foreach (var item in itemToRemove)
        //                {
        //                    model.Items.Remove(item);
        //                }




        //                foreach (var item in model.Items.Where(x => x.IsDelete == false))
        //                {

        //                    item.CreateDate = DateTime.Now;
        //                    item.UpdateDate = DateTime.Now;
        //                    item.ComId = int.Parse(ComId.ToString());
        //                    item.LuserId = int.Parse(UserId.ToString());


        //                    if (item.PurchaseBatchItems != null)
        //                    {
        //                        foreach (var Batchitem in item.PurchaseBatchItems)
        //                        {

        //                            Batchitem.CreateDate = DateTime.Now;
        //                            Batchitem.UpdateDate = DateTime.Now;
        //                            Batchitem.ComId = int.Parse(ComId.ToString());
        //                            Batchitem.LuserId = int.Parse(UserId.ToString());
        //                            //Batchitem.ComId = int.Parse(ComId.ToString());

        //                        }
        //                    }

        //                }





        //                _purchaseRepository.Insert(model);


        //                TempData["Message"] = "Data Save Successfully";
        //                TempData["Status"] = "1";
        //                tranlog.TransactionLog(RouteData.Values["controller"].ToString(), RouteData.Values["action"].ToString(), TempData["Message"].ToString(), model.Id.ToString(), "Create", model.PurchaseCode);


        //                return Json(new { error = false, message = "Purchase saved successfully", Id = model.Id });
        //            }

        //        }
        //        else
        //        {

        //            return Json(new { error = true, message = "failed to save Purchase" });
        //        }



        //    }
        //    catch (Exception ex)
        //    {

        //        return Json(new { error = true, message = ex.Message });
        //    }
        //}




        [HttpPost]
        [AllowAnonymous]
        public IActionResult AddBill([FromBody] PurchaseModel model)
        {
            try
            {
                var UserId = HttpContext.Session.GetInt32("UserId");
                var ComId = HttpContext.Session.GetInt32("ComId");

                var errors = ModelState.Where(x => x.Value.Errors.Any())
                .Select(x => new { x.Key, x.Value.Errors });

                if (ModelState.IsValid)
                {
                    if (model.Id > 0)
                    {
                        _purchaseRepository.Update(model, model.Id);
                        foreach (PurchaseItemsModel item in model.Items)
                        {

                            if (item.Id > 0)
                            {
                                if (item.IsDelete == true)
                                {
                                    int z = item.Id;
                                    _purchaseItemRepository.Delete(item);

                                }
                                else
                                {
                                    if (item.isTransaction == true)//item.IsDelete == false &&  
                                    {
                                        if (item.PurchaseBatchItems != null)
                                        {
                                            foreach (PurchaseBatchItemsModel batchitem in item.PurchaseBatchItems)
                                            {
                                                if (batchitem.Id > 0)
                                                {
                                                    if (batchitem.IsDelete == true)
                                                    {
                                                        int z = batchitem.Id;
                                                        _purchaseBatchItemRepository.Delete(batchitem);

                                                    }
                                                    else
                                                    {
                                                        if (batchitem.IsTransaction == true)
                                                        {
                                                            batchitem.ComId = ComId.GetValueOrDefault();
                                                            batchitem.LuserId = UserId.GetValueOrDefault();


                                                            _purchaseBatchItemRepository.Update(batchitem, batchitem.Id);
                                                        }
                                                    }
                                                }
                                                else if (batchitem.Id == 0 && batchitem.IsDelete == false)
                                                {
                                                    batchitem.ComId = ComId.GetValueOrDefault();
                                                    batchitem.LuserId = UserId.GetValueOrDefault();
                                                    _purchaseBatchItemRepository.Insert(batchitem);
                                                }


                                            }
                                        }

                                        _purchaseItemRepository.Update(item, item.Id);

                                    }
                                }
                            }
                            else
                            {
                                if (item.IsDelete == true)
                                {
                                }
                                else
                                {
                                    _purchaseItemRepository.Insert(item);

                                }
                            }
                        }


                        var salespaymentsdata = _purchasePaymentRepository.All().Where(x => x.PurchaseId == model.Id && x.TransactionId == null).ToList();
                        _purchasePaymentRepository.RemoveRange(salespaymentsdata);


                        foreach (PurchasePaymentModel item in model.PurchasePayments.Where(x => x.IsDelete == false))
                        {
                            _purchasePaymentRepository.Insert(item);
                        }
                        TempData["Message"] = "Data Update Successfully";
                        TempData["Status"] = "2";
                        tranlog.TransactionLog(RouteData.Values["controller"].ToString(), RouteData.Values["action"].ToString(), TempData["Message"].ToString(), model.Id.ToString(), "Update", model.PurchaseCode);

                        return Json(new { error = false, message = "Purchase updated successfully", Id = model.Id });
                    }
                    else
                    {

                        //var UserId = HttpContext.Session.GetInt32("UserId");
                        //var ComId = HttpContext.Session.GetInt32("ComId");


                        var itemToRemove = model.Items.Where(x => x.IsDelete == true).ToList();


                        foreach (var item in itemToRemove)
                        {
                            model.Items.Remove(item);
                        }




                        foreach (var item in model.Items.Where(x => x.IsDelete == false))
                        {

                            item.CreateDate = DateTime.Now;
                            item.UpdateDate = DateTime.Now;
                            item.ComId = int.Parse(ComId.ToString());
                            item.LuserId = int.Parse(UserId.ToString());


                            if (item.PurchaseBatchItems != null)
                            {
                                foreach (var Batchitem in item.PurchaseBatchItems)
                                {

                                    Batchitem.CreateDate = DateTime.Now;
                                    Batchitem.UpdateDate = DateTime.Now;
                                    Batchitem.ComId = int.Parse(ComId.ToString());
                                    Batchitem.LuserId = int.Parse(UserId.ToString());
                                    //Batchitem.ComId = int.Parse(ComId.ToString());

                                }
                            }

                        }





                        _purchaseRepository.Insert(model);


                        TempData["Message"] = "Data Save Successfully";
                        TempData["Status"] = "1";
                        tranlog.TransactionLog(RouteData.Values["controller"].ToString(), RouteData.Values["action"].ToString(), TempData["Message"].ToString(), model.Id.ToString(), "Create", model.PurchaseCode);


                        return Json(new { error = false, message = "Purchase saved successfully", Id = model.Id });
                    }

                }
                else
                {
                    return Json(new { error = true, message = "failed to save Purchase" });
                }



            }
            catch (Exception ex)
            {

                return Json(new { error = true, message = ex.Message });
            }
        }


        [HttpPost]
        public JsonResult POSCreate(PurchaseModel model)
        {
            try
            {
                var errors = ModelState.Where(x => x.Value.Errors.Any())
                .Select(x => new { x.Key, x.Value.Errors });

                if (ModelState.IsValid)
                {
                    if (model.Id > 0)
                    {
                        var UserId = HttpContext.Session.GetInt32("UserId");
                        var ComId = HttpContext.Session.GetInt32("ComId");

                        var items = _purchaseItemRepository.AllSubData().Where(x => x.PurchaseId == model.Id).ToList();
                        if (items.Any())
                        {
                            foreach (var item in items)
                            {
                                _purchaseItemRepository.Delete(item);
                            }
                        }

                        var Purchasepayment = _purchasePaymentRepository.AllSubData().Where(x => x.PurchaseId == model.Id).ToList();
                        if (Purchasepayment.Any())
                        {
                            foreach (var item in Purchasepayment)
                            {
                                _purchasePaymentRepository.Delete(item);
                            }
                        }

                        var Purchase = _purchaseRepository.Find(model.Id);

                        Purchase.SupplierName = model.SupplierName;
                        Purchase.PrimaryAddress = model.PrimaryAddress;
                        Purchase.PhoneNo = model.PhoneNo;


                        Purchase.Notes = model.Notes;
                        Purchase.PaymentMethod = model.PaymentMethod;
                        Purchase.PurchaseCode = model.PurchaseCode;
                        Purchase.SupplierId = model.SupplierId;
                        Purchase.Total = model.Total;
                        Purchase.PurchaseDate = model.PurchaseDate;
                        Purchase.Status = model.Status;
                        Purchase.Discount = model.Discount;


                        Purchase.ServiceCharge = model.ServiceCharge;
                        Purchase.Shipping = model.Shipping;
                        Purchase.TotalVat = model.TotalVat;

                        Purchase.GrandTotal = model.GrandTotal;

                        Purchase.DisPer = model.DisPer;
                        Purchase.DisAmt = model.DisAmt;
                        Purchase.DueAmt = model.DueAmt;



                        //Purchase.ttlCountQty = model.ttlCountQty;
                        //Purchase.ttlIndDisAmt = model.ttlIndDisAmt;
                        //Purchase.ttlIndPrice = model.ttlIndPrice;

                        //Purchase.ttlIndVat = model.ttlIndVat;
                        //Purchase.ttlSumAmt = model.ttlSumAmt;
                        //Purchase.ttlSumQty = model.ttlSumQty;
                        //Purchase.ttlUnitPrice = model.ttlUnitPrice;
                        Purchase.LuserIdUpdate = int.Parse(UserId.ToString());



                        //add again
                        foreach (var item in model.Items)
                        {
                            Purchase.Items.Add(new PurchaseItemsModel
                            {
                                Price = item.Price,
                                Amount = item.Amount,
                                Quantity = item.Quantity,
                                Name = item.Name,
                                ProductId = item.ProductId,
                                WarehouseId = item.WarehouseId,
                                Description = item.Description,
                                CreateDate = DateTime.Now,
                                UpdateDate = DateTime.Now,

                                ProfitPer = item.ProfitPer,
                                SalesUnitPrice = item.SalesUnitPrice,


                                ComId = int.Parse(ComId.ToString()),
                                LuserId = int.Parse(UserId.ToString())
                            });
                        }

                        foreach (var item in model.PurchasePayments)
                        {
                            Purchase.PurchasePayments.Add(new PurchasePaymentModel
                            {
                                //PaymentTypeId = item.PaymentTypeId,
                                Amount = item.Amount,
                                RowNo = item.RowNo,
                                AccountHeadId = item.AccountHeadId,
                                PaymentCardNo = item.PaymentCardNo,
                                CreateDate = DateTime.Now,
                                UpdateDate = DateTime.Now,
                                ComId = int.Parse(ComId.ToString()),
                                LuserId = int.Parse(UserId.ToString())
                            });
                        }


                        _purchaseRepository.Update(Purchase, model.Id);



                        TempData["Message"] = "Data Update Successfully";
                        TempData["Status"] = "2";
                        tranlog.TransactionLog(RouteData.Values["controller"].ToString(), RouteData.Values["action"].ToString(), TempData["Message"].ToString(), model.Id.ToString(), "Update", model.PurchaseCode.ToString());

                        return Json(new { Success = 1, Id = model.Id, error = false, message = "Purchase updated successfully" });
                    }
                    else
                    {
                        model.isPOSPurchase = true;
                        var UserId = HttpContext.Session.GetInt32("UserId");
                        var ComId = HttpContext.Session.GetInt32("ComId");

                        foreach (var item in model.Items)
                        {

                            item.CreateDate = DateTime.Now;
                            item.UpdateDate = DateTime.Now;
                            item.ComId = int.Parse(ComId.ToString());
                            item.LuserId = int.Parse(UserId.ToString());
                        }

                        foreach (var item in model.PurchasePayments)
                        {

                            item.CreateDate = DateTime.Now;
                            item.UpdateDate = DateTime.Now;
                            item.ComId = int.Parse(ComId.ToString());
                            item.LuserId = int.Parse(UserId.ToString());
                        }

                        _purchaseRepository.Insert(model);


                        TempData["Message"] = "Data Save Successfully";
                        TempData["Status"] = "1";
                        tranlog.TransactionLog(RouteData.Values["controller"].ToString(), RouteData.Values["action"].ToString(), TempData["Message"].ToString(), model.Id.ToString(), "Create", model.PurchaseCode);


                        return Json(new { Success = 1, Id = model.Id, error = false, message = "Purchase saved successfully" });
                    }

                }
                return Json(new { Success = 0, error = true, message = "failed to save Purchase" });

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return Json(new { Success = 0, error = true, message = "failed to save/update Purchase" });
            }


        }

        public async Task<IActionResult> POSEdit(int? PurchaseId)
        {
            if (PurchaseId == null)
            {
                return NotFound();
            }

            PurchaseModel Purchasemain = await _purchaseRepository.All()
            .Include(x => x.Items).ThenInclude(x => x.Product)
            //.Include(x => x.PurchasePayments).ThenInclude(x => x.vPaymentType)
            .Include(x => x.PurchasePayments).ThenInclude(x => x.vChartofAccounts)
            .Include(x => x.Items).ThenInclude(x => x.vWarehouse)
            .Where(x => x.Id == PurchaseId).FirstOrDefaultAsync();

            if (Purchasemain.IsDelete == true)
            {
                return NotFound();
            }
            var comid = HttpContext.Session.GetString("ComId");
            var userid = HttpContext.Session.GetString("UserId");

            object a = HttpContext.Session.GetString("isProductSearch");
            ViewBag.ActionType = "Edit";

            ViewBag.Supplier = _supplierRepository.GetAllForDropDown();
            ViewBag.Category = categoryRepository.GetAllForDropDown();
            var Productresult = productRepository.All().Take(30);

            ViewBag.Product = new SelectList(Productresult.Where(x => x.Id > 0).Select(s => new { Text = s.Code.Length < 4 ? s.Name : s.Name + " - [ " + s.Code + " ]", Value = s.Id }).ToList(), "Value", "Text");
            ViewBag.ProductSearch = Productresult;
            if (FromWarehousePermissionRepository.GetAllForDropDown().Count() > 0) { ViewBag.Warehouse = FromWarehousePermissionRepository.GetAllForDropDown(); } else { ViewBag.Warehouse = warehouseRepository.GetWarehouseLedgerHeadForDropDown(); }

            ViewBag.PaymentTypes = paymentTypeRepository.GetAllForDropDown();
            ViewBag.AccountHead = accountHeadRepository.GetCashBankHeadForDropDown();
            if (Purchasemain == null)
            {
                return NotFound();
            }

            //Call Create View
            return View("POSCreate", Purchasemain);
        }

        public async Task<IActionResult> POSDelete(int? id)
        {


            //HttpContext.Session.SetString("isBarcodeSearch", "true");
            //HttpContext.Session.SetString("isProductSearch", "true");
            //HttpContext.Session.SetString("isIMEISearch", "true");


            if (id == null)
            {
                return NotFound();
            }

            PurchaseModel Purchasemain = await _purchaseRepository.All()
            .Include(x => x.Items).ThenInclude(x => x.Product)
            //.Include(x => x.PurchasePayments).ThenInclude(x => x.vPaymentType)
            .Include(x => x.PurchasePayments).ThenInclude(x => x.vChartofAccounts)
            .Include(x => x.Items).ThenInclude(x => x.vWarehouse)
            .Where(x => x.Id == id).FirstOrDefaultAsync();

            if (Purchasemain == null)
            {
                return NotFound();
            }
            var comid = HttpContext.Session.GetString("ComId");
            var userid = HttpContext.Session.GetString("userid");

            //object a = HttpContext.Session.GetString("isProductSearch");
            ViewBag.ActionType = "Delete";

            ViewBag.Supplier = _supplierRepository.GetAllForDropDown();
            ViewBag.Category = categoryRepository.GetAllForDropDown();
            var Productresult = productRepository.All().Take(30);

            ViewBag.Product = new SelectList(Productresult.Where(x => x.Id > 0).Select(s => new { Text = s.Code.Length < 4 ? s.Name : s.Name + " - [ " + s.Code + " ]", Value = s.Id }).ToList(), "Value", "Text");
            ViewBag.ProductSearch = Productresult;
            if (FromWarehousePermissionRepository.GetAllForDropDown().Count() > 0) { ViewBag.Warehouse = FromWarehousePermissionRepository.GetAllForDropDown(); } else { ViewBag.Warehouse = warehouseRepository.GetWarehouseLedgerHeadForDropDown(); }

            ViewBag.PaymentTypes = paymentTypeRepository.GetAllForDropDown();
            ViewBag.AccountHead = accountHeadRepository.GetCashBankHeadForDropDown();
            if (Purchasemain == null)
            {
                return NotFound();
            }

            //Call Create View
            return View("POSCreate", Purchasemain);
        }


        [HttpGet]
        [AllowAnonymous]
        public IActionResult EditPurchase(int PurchaseId)
        {

            ViewBag.ActionType = "Edit";
            ViewBag.Suppliers = _supplierRepository.GetAllForDropDown();
            if (FromWarehousePermissionRepository.GetAllForDropDown().Count() > 0) { ViewBag.Warehouse = FromWarehousePermissionRepository.GetAllForDropDown(); } else { ViewBag.Warehouse = warehouseRepository.GetWarehouseLedgerHeadForDropDown(); }
            ViewBag.Category = categoryRepository.GetAllForDropDown();
            ViewBag.Unit = _unitRepository.GetAllForDropDown();
            ViewBag.DocType = _docTypeRepository.GetPurchaseDocForDropDown();

            var batchlist = _purchaseItemRepository.AllSubData().Where(x => x.PurchaseId == PurchaseId).Include(x => x.PurchaseBatchItems).Select(x => x.PurchaseBatchItems.Count()).FirstOrDefault();
            var batchdata = batchlist;
            //if (batchdata > 0)
            //return View("AddPurchaseBatch", model: PurchaseId);

            var isBatchPurchase = false;
            isBatchPurchase = _purchaseRepository.All().Where(x => x.Id == PurchaseId).Select(x => x.isBatchPurchase).FirstOrDefault();

            if (isBatchPurchase == true)
            {
                return View("AddPurchaseBatch", model: PurchaseId);

            }




            return View("AddPurchase", model: PurchaseId);


        }


        [HttpGet]
        [AllowAnonymous]
        public IActionResult EditPurchaseBatch(int PurchaseId)
        {

            ViewBag.ActionType = "Edit";
            ViewBag.Suppliers = _supplierRepository.GetAllForDropDown();
            if (FromWarehousePermissionRepository.GetAllForDropDown().Count() > 0) { ViewBag.Warehouse = FromWarehousePermissionRepository.GetAllForDropDown(); } else { ViewBag.Warehouse = warehouseRepository.GetWarehouseLedgerHeadForDropDown(); }


            ViewBag.Category = categoryRepository.GetAllForDropDown();
            ViewBag.Unit = _unitRepository.GetAllForDropDown();
            ViewBag.DocType = _docTypeRepository.GetPurchaseDocForDropDown();

            return View("AddPurchaseBatch", model: PurchaseId);


        }

        [HttpPost]
        public IActionResult EditPurchase(PurchaseModel model)
        {
            if (model != null)
            {
                var UserId = HttpContext.Session.GetInt32("UserId");
                var ComId = HttpContext.Session.GetInt32("ComId");

                var items = _purchaseItemRepository.AllSubData().Where(x => x.PurchaseId == model.Id).ToList();
                if (items.Any())
                {
                    foreach (var item in items)
                    {
                        _purchaseItemRepository.Delete(item);
                    }
                }

                var Purchase = _purchaseRepository.Find(model.Id);
                Purchase.Notes = model.Notes;
                Purchase.SupplierName = model.SupplierName;
                Purchase.PhoneNo = model.PhoneNo;
                Purchase.PrimaryAddress = model.PrimaryAddress;

                Purchase.PaymentMethod = model.PaymentMethod;
                Purchase.PurchaseCode = model.PurchaseCode;
                Purchase.SupplierId = model.SupplierId;
                Purchase.Total = model.Total;
                Purchase.PurchaseDate = model.PurchaseDate;
                Purchase.Status = model.Status;
                Purchase.Discount = model.Discount;

                Purchase.ServiceCharge = model.ServiceCharge;
                Purchase.Shipping = model.Shipping;
                Purchase.TotalVat = model.TotalVat;

                Purchase.GrandTotal = model.GrandTotal;

                //add again
                foreach (var item in model.Items)
                {
                    Purchase.Items.Add(new PurchaseItemsModel
                    {
                        WarehouseId = item.WarehouseId,
                        Price = item.Price,
                        Amount = item.Amount,
                        Quantity = item.Quantity,
                        Name = item.Name,
                        ProductId = item.ProductId,
                        Description = item.Description,
                        CreateDate = DateTime.Now,
                        UpdateDate = DateTime.Now,
                        ProfitPer = item.ProfitPer,
                        SalesUnitPrice = item.SalesUnitPrice,

                        ComId = int.Parse(ComId.ToString())
                    });
                }
                _purchaseRepository.Update(Purchase, model.Id);



                TempData["Message"] = "Data Update Successfully";
                TempData["Status"] = "2";
                tranlog.TransactionLog(RouteData.Values["controller"].ToString(), RouteData.Values["action"].ToString(), TempData["Message"].ToString(), model.Id.ToString(), "Update", model.PurchaseCode.ToString());

                return Json(new { error = false, message = "Purchase updated successfully" });
            }
            return Json(new { error = true, message = "failed to update Purchase" });
        }

        [HttpGet]
        [AllowAnonymous]
        public IActionResult PurchaseInvoiceViewReport(int PurchaseId, string ReportType = "")
        {

            try
            {



                var salesquery = _purchaseRepository.All()
                    .Include(x => x.CompanyList).ThenInclude(x => x.storeinfo)
                    .Include(x => x.DocTypeList)
                    .Include(x => x.SupplierModel)
                    .Include(x => x.Items).ThenInclude(x => x.Product).ThenInclude(x => x.Unit)
                    .Include(x => x.Items).ThenInclude(x => x.Product).ThenInclude(x => x.Warrenty)
                    .Include(x => x.Items).ThenInclude(x => x.Product).ThenInclude(x => x.Brand)
                    .Include(x => x.Items).ThenInclude(x => x.vWarehouse)
                    .Include(x => x.Items).ThenInclude(x => x.PurchaseBatchItems)
                    .Include(x => x.Items).ThenInclude(x => x.vWarehouse)
                    .Include(x => x.PurchasePayments).ThenInclude(x => x.vChartofAccounts)
                    .Include(x => x.PurchasePayments).ThenInclude(x => x.Transaction)
                    .Include(x => x.PurchasePayments).ThenInclude(x => x.vChartofAccounts)
                    //.Include(x => x.Currency)

                    .Where(x => x.Id == PurchaseId).FirstOrDefault();


                //ViewBag.ReportType = ReportType;

                //ViewBag.TermsMain = termsmainRepository.All().Include(x => x.TermsSubs).FirstOrDefault();

                if (ReportType == "" || ReportType == null)
                {
                    ViewBag.ReportType = "PURCHASE INVOICE";

                }
                else
                {
                    ViewBag.ReportType = ReportType;

                }



                return View(salesquery);

            }
            catch (Exception e)
            {
                return Json(e.ToString());
            }


        }


        //new for report
        [HttpGet]
        [AllowAnonymous]
        public IActionResult PurchaseInvoiceReport(int PurchaseId, int ReportStyle = 1)
        {

            try
            {
                if (ReportStyle == 1)
                {

                    ViewBag.PurchaseId = PurchaseId;
                    ViewBag.ReportStyle = ReportStyle;

                    return View();
                }
                if (ReportStyle == 2)
                {

                    ViewBag.PurchaseId = PurchaseId;
                    ViewBag.ReportStyle = ReportStyle;
                    return View();
                }
                return View();

            }
            catch (Exception e)
            {
                return Json(e.ToString());
            }


        }

        [AllowAnonymous]
        public JsonResult GetReportData(int PurchaseId = 0)
        {
            try
            {
                var ComId = HttpContext.Session.GetInt32("ComId");
                var UserId = HttpContext.Session.GetInt32("UserId");
                //var queryname = "prcDummyDataForPOReport";
                var queryname = "rpt_DynamicReportForSupplierPO";
                var viewquery = $"Exec {queryname} '{ComId}', '{PurchaseId}'";
                Console.WriteLine(viewquery);
                SqlParameter[] parameters = new SqlParameter[2];
                parameters[0] = new SqlParameter("@ComId", ComId);
                parameters[1] = new SqlParameter("@PurchaseId", PurchaseId);

                var datasetabc = new System.Data.DataSet();
                datasetabc = Helper.ExecProcMapDS(queryname, parameters);

                return Json(new { data = datasetabc, ex = "" });
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }


        [HttpGet]
        [AllowAnonymous]
        public IActionResult getTermsForReport(int PurchaseId)
        {
            var ComId = HttpContext.Session.GetInt32("ComId");

            var terms = purchaseTermsRepository.All().Where(x => x.ComId == ComId && x.PurchaseId == PurchaseId).Select(x => new
            {
                x.TermsDescription
            }).ToList();
            return Json(new { data = terms });
        }

        [HttpGet]
        [AllowAnonymous]
        public IActionResult getsubTerms(int id)
        {
            var ComId = HttpContext.Session.GetInt32("ComId");

            var terms = _termsSubRepository.All().Where(x => x.TermsId == id).Select(x => new
            {
                x.TermsDescription,
                TermsName = x.Terms

            }).ToList();
            return Json(new { data = terms });
        }


        //[HttpGet]
        //[AllowAnonymous]
        //public IActionResult PurchaseInvoiceViewReport(int PurchaseId, string ReportType = "")
        //{

        //    try
        //    {
        //        var salesquery = _purchaseRepository.All()
        //            .Include(x => x.CompanyList).ThenInclude(x => x.storeinfo)
        //            .Include(x => x.DocTypeList)
        //            .Include(x => x.SupplierModel)
        //            .Include(x => x.Items).ThenInclude(x => x.Product).ThenInclude(x => x.Unit)
        //            .Include(x => x.Items).ThenInclude(x => x.Product).ThenInclude(x => x.Warrenty)
        //            .Include(x => x.Items).ThenInclude(x => x.Product).ThenInclude(x => x.Brand)
        //            .Include(x => x.Items).ThenInclude(x => x.PurchaseBatchItems)
        //            .Include(x => x.Items).ThenInclude(x => x.vWarehouse)
        //             .Include(x => x.PurchasePayments).ThenInclude(x => x.vChartofAccounts)
        //            .Include(x => x.PurchasePayments).ThenInclude(x => x.Transaction)
        //            .Include(x => x.PurchasePayments).ThenInclude(x => x.vChartofAccounts)
        //                        //.Include(x => x.Currency)

        //            .Where(x => x.Id == PurchaseId).FirstOrDefault();

        //        //ViewBag.TermsMain = termsmainRepository.All().Include(x => x.TermsSubs).FirstOrDefault();

        //        if (ReportType == "" || ReportType == null)
        //        {
        //            ViewBag.ReportType = "PURCHASE INVOICE";

        //        }
        //        else
        //        {
        //            ViewBag.ReportType = ReportType;

        //        }



        //        return View(salesquery);

        //    }
        //    catch (Exception e)
        //    {
        //        return Json(e.ToString());
        //    }


        //}



        //[HttpPost]
        //[ValidateAntiForgeryToken]
        public IActionResult DeletePurchase(int PurchaseId) //JsonResult
        {
            try
            {

                var model = this._purchaseRepository.All().Where(x => x.Id == PurchaseId && x.isPosted == false).FirstOrDefault(); //.Find(saleId);
                                                                                                                                   // var model = this._purchaseRepository.Find(PurchaseId);
                _purchaseRepository.Delete(model);


                TempData["Message"] = "Data Delete Successfully";
                TempData["Status"] = "3";
                tranlog.TransactionLog(RouteData.Values["controller"].ToString(), RouteData.Values["action"].ToString(), TempData["Message"].ToString(), model.Id.ToString(), "Delete", model.PurchaseCode);


                return RedirectToAction("index");
                //  return RedirectToAction("index");
                //return Json(new { success = 1, message = "Data Delete Successfully" });
            }
            catch (Exception e)
            {
                return RedirectToAction("index");

                //return Json(new { error = 1, message = "Failed to Delete Purchase  " + e.Message });
                //throw ex;
            }
        }
        [HttpGet]
        [AllowAnonymous]

        public ActionResult PurchaseReport(int PurchaseId)
        {
            var UserId = HttpContext.Session.GetInt32("UserId");
            var ComId = HttpContext.Session.GetInt32("ComId");
            //var weburl = HttpContext.Session.GetString("weburl");
            string weburl = configuration.GetSection("hostimage").Value;
            HttpContext.Session.SetString("weburl", weburl);

            var ReportStyle = HttpContext.Session.GetString("PurchaseReportStyle");


            string reportname = "rptPurchaseOrder";
            var filename = "Purchase_";
            //string apppath = "";


            //if (ReportStyle.ToString().Length > 0)
            //{
            //    reportname = "rptPurchaseOrder_" + ReportStyle.ToString();
            //}


            HttpContext.Session.SetString("ReportQuery", "Exec  [rptPurchase] '" + PurchaseId + "','" + ComId + "', '" + weburl + "', 'Purchase'");
            HttpContext.Session.SetString("ReportPath", "~/ReportViewer/POS/" + reportname + ".rdlc");
            HttpContext.Session.SetString("PrintFileName", filename.Replace(".", "").Replace(" ", "").Replace(",", "").Replace("\"", ""));


            clsReport.strQueryMain = HttpContext.Session.GetString("ReportQuery");
            postData.Add(1, new subReport("rptPurchaseOrder_Terms", "", "DataSet1", "Exec rptPurchaseOrder_Terms '" + PurchaseId + "'," + ComId + ""));

            //postData.Add(1, new subReport("rptPurchaseOrder_Terms", "", "DataSet1", "Exec " + AppData.AppData.dbGTCommercial.ToString() + ".dbo.rptPurchaseOrder_Terms '" + id + "','" + Session["comid"].ToString() + "',''"));

            //postData.Add(1, new subReport("rptPurchaseOrder_BankDetails", "", "DataSet1", "Exec rptPurchaseOrder_BankDetails '" + PurchaseId + "'," + ComId + ",'" + AppData.AppData.AppPath.ToString() + "'"));
            postData.Add(2, new subReport("rptPurchaseOrder_PM", "", "DataSet1", "Exec rptPurchaseOrder_PM '" + PurchaseId + "'," + ComId + ""));


            //clsReport.rptList.Add(new subReport("rptPurchaseOrder_Terms", "", "DataSet1", "Exec " + AppData.AppData.dbGTCommercial.ToString() + ".dbo.rptPurchaseOrder_Terms '" + id + "'," + Session["comid"].ToString() + ",'" + AppData.AppData.AppPath.ToString() + "'"));

            HttpContext.Session.SetObject("rptList", postData);


            return RedirectToAction("Index", "ReportViewer");
        }









        public ActionResult PurchaseInvoice(int PurchaseId, int style)
        {
            if (storeSettingRepository.All().Count() == 0)
            {
                TempData["Msg"] = "Setup store setting first then print Purchase invoice";
                return RedirectToAction("Index");
            }
            var store = storeSettingRepository.All().FirstOrDefault();

            var Purchase = _purchaseRepository.All().Include(x => x.SupplierModel).SingleOrDefault(x => x.Id == PurchaseId);
            Purchase.Items = _purchaseItemRepository.All().Where(x => x.PurchaseId == PurchaseId).ToList();
            if (Purchase != null)
            {

            }
            return RedirectToAction("index");
        }



        [HttpGet]
        [AllowAnonymous]
        public JsonResult GetPurchase(int PurchaseId, int isreturn = 0)
        {
            try
            {

                var purchasequery = _purchaseRepository.All().Where(x => x.Id == PurchaseId);

                if (isreturn == 0)
                {
                    purchasequery = purchasequery.Where(x => x.isPosted == false);
                }
                else if (isreturn == 1)
                {
                    purchasequery = purchasequery.Where(x => x.isPosted == true);
                }

                PurchaseModel Purchase = purchasequery.FirstOrDefault();



                //PurchaseModel Purchase = _purchaseRepository.All().FirstOrDefault(x => x.Id == PurchaseId && x.isPosted == false);
                if (Purchase == null)
                {
                    return Json("No Data Found");
                }

                Purchase.Items = _purchaseItemRepository.AllSubData()
                    .Include(x => x.Product).ThenInclude(x => x.Brand)
                    .Include(x => x.Product).ThenInclude(x => x.SizeList)
                    .Include(x => x.Product).ThenInclude(x => x.ColorList)
                    .Include(x => x.vWarehouse)
                    .Include(x => x.PurchaseBatchItems)
                    .Where(x => x.PurchaseId == Purchase.Id).ToList();

                Purchase.PurchaseTerms = purchaseTermsRepository.All().Where(x => x.PurchaseId == Purchase.Id).ToList();



                Purchase.PurchasePayments = _purchasePaymentRepository.AllSubData()
                    //.Include(x => x.vPaymentType)
                    .Include(x => x.vChartofAccounts)
                    .Where(x => x.PurchaseId == Purchase.Id && x.TransactionId == null).ToList();

                return Json(Purchase);

            }
            catch (Exception e)
            {
                return Json(e.ToString());
            }

        }
        [AllowAnonymous]
        public JsonResult GetSuppliers()
        {
            var ComId = HttpContext.Session.GetInt32("ComId");

            var supplierDetails = _supplierRepository.All().Where(x => x.ComId == ComId)
                .Include(x => x.Currency)
                .Select(x => new
                {
                    x.Id,
                    x.SupplierName,
                    x.SupplierCurrencyId,
                    x.Currency.CurrencyShortName,
                    x.ComId
                });
            return Json(supplierDetails);
        }

        [AllowAnonymous]
        public JsonResult GetWarehouse()
        {
            return Json(warehouseRepository.All());
        }

        [AllowAnonymous]
        public JsonResult GetExpenseHead()
        {
            var ComId = HttpContext.Session.GetInt32("ComId");

            return Json(accountHeadRepository.GetExpenseHeadForDropDown());
        }

        [AllowAnonymous]
        public JsonResult GetSupplierInvoice(int SupplierId, int? TransactionId)
        {

            var TransactionInformation = _accountsDailyTransaction.All().Where(x => x.Id == TransactionId).FirstOrDefault();


            #region Supplierbalance_calculation

            var currentdate = DateTime.Now.Date;


            if (TransactionInformation == null)
            {
                currentdate = currentdate.AddDays(1);
            }
            else
            {
                if (TransactionInformation.SupplierId != SupplierId)
                {
                    TransactionInformation = null;
                    currentdate = currentdate.AddDays(1);
                }
            }

            var Type = "Supplier";
            var dtFrom = currentdate.ToString("dd-MMM-yy");
            var dtTo = currentdate.ToString("dd-MMM-yy");

            var comid = HttpContext.Session.GetInt32("ComId");
            var userid = HttpContext.Session.GetInt32("UserId");

            var quary = $"Exec Acc_SupplierBalance  '" + comid + "','" + SupplierId + "',0,'" + dtFrom + "' ,'" + dtTo + "','" + Type + "',1";

            SqlParameter[] parameters = new SqlParameter[7];
            parameters[0] = new SqlParameter("@ComId", comid);
            parameters[1] = new SqlParameter("@SupplierId", SupplierId);
            parameters[2] = new SqlParameter("@UrlLink", "");
            parameters[3] = new SqlParameter("@FromDate", DateTime.Parse(dtFrom));
            parameters[4] = new SqlParameter("@ToDate", DateTime.Parse(dtTo));
            parameters[5] = new SqlParameter("@LedgerFor", Type);
            parameters[6] = new SqlParameter("@BalanceUpdate", "1");


            Helper.ExecProc("Acc_SupplierBalance", parameters);

            #endregion




            if (TransactionInformation != null && SupplierId == TransactionInformation.SupplierId)
            {
                var Supplier = _supplierRepository.All().Include(x => x.AccountsDailyTransaction)
                          .Where(y => y.Id == SupplierId)
                          .Select(g => new
                          {
                              g.SupplierName,
                              g.PrimaryAddress,
                              g.SecoundaryAddress,
                              g.PostalCode,
                              g.Email,
                              g.City,
                              g.Phone,

                              PrevDue = g.ClBalance + TransactionInformation.TransactionAmount,
                              //PrevDue = Convert.ToDecimal(g.OpBalance) +
                              //g.AccountsDailyTransaction.Where(x => x.TransactionType == "System Sales").Sum(x => x.TransactionAmount)
                              //+ g.AccountsDailyTransaction.Where(x => x.TransactionType == "System Sales Return").Sum(x => x.TransactionAmount)
                              //- g.AccountsDailyTransaction.Where(x => x.TransactionType.Contains("Received") && x.Id != TransactionId).Sum(x => x.TransactionAmount)
                              //- g.AccountsDailyTransaction.Where(x => x.TransactionType.Contains("Paid") && !x.TransactionCategory.Contains("PaidToSupplier") && x.Id != TransactionId).Sum(x => x.TransactionAmount)
                              //+ g.AccountsDailyTransaction.Where(x => x.TransactionType.Contains("Paid") && x.TransactionCategory.Contains("PaidToSupplier") && x.Id != TransactionId).Sum(x => x.TransactionAmount),

                              //PrevDue = Convert.ToDecimal(g.OpBalance) + g.AccountsDailyTransaction.Where(x => x.TransactionType == "System Sales").Sum(x => x.TransactionAmount) + g.AccountsDailyTransaction.Where(x => x.TransactionType == "System Sales Return").Sum(x => x.TransactionAmount) - g.AccountsDailyTransaction.Where(x => x.TransactionType.Contains("Received")).Sum(x => x.TransactionAmount) + g.AccountsDailyTransaction.Where(x => x.TransactionType.Contains("Paid")).Sum(x => x.TransactionAmount),
                              g.SupplierCommissionPer
                          })
                          .SingleOrDefault();


                var saledata = _purchasePaymentRepository.All().Include(x => x.PurchaseMain).ThenInclude(x => x.SupplierModel).Where(x => x.TransactionId == TransactionId).FirstOrDefault();

                //var abc = new SelectList();
                var prevselecteddata = new SelectListItem { Text = saledata.PurchaseMain.PurchaseCode + " - " + saledata.PurchaseMain.SupplierModel.SupplierName + "  " + saledata.PurchaseMain.SupplierName + " - " + saledata.PurchaseMain.NetAmount + "    Due : " + (saledata.Amount), Value = saledata.PurchaseId.ToString(), Selected = true }; //saledata.SalesMain.NetAmount - 
                var Supplierinvoicelist = _purchaseRepository.GetAllForDropDownForSupplier(true, SupplierId).ToList();
                Supplierinvoicelist.Add(prevselecteddata);

                var genericResult = new
                {
                    SupplierInvoiceList = Supplierinvoicelist,
                    SupplierInfo = Supplier
                };
                return Json(genericResult);

            }
            else
            {
                var Supplier = _supplierRepository.All().Include(x => x.AccountsDailyTransaction)
                            .Where(y => y.Id == SupplierId)
                            .Select(g => new
                            {
                                g.SupplierName,
                                g.PrimaryAddress,
                                g.SecoundaryAddress,
                                g.PostalCode,
                                g.Email,
                                g.City,
                                g.Phone,

                                PrevDue = g.ClBalance,
                                //PrevDue = Convert.ToDecimal(g.OpBalance)
                                //+ g.AccountsDailyTransaction.Where(x => x.TransactionType == "System Sales").Sum(x => x.TransactionAmount)
                                //+ g.AccountsDailyTransaction.Where(x => x.TransactionType == "System Sales Return").Sum(x => x.TransactionAmount)
                                //- g.AccountsDailyTransaction.Where(x => x.TransactionType.Contains("Received")).Sum(x => x.TransactionAmount)
                                //- g.AccountsDailyTransaction.Where(x => x.TransactionType.Contains("Paid") && !x.TransactionCategory.Contains("PaidToSupplier")).Sum(x => x.TransactionAmount)
                                //+ g.AccountsDailyTransaction.Where(x => x.TransactionType.Contains("Paid") && x.TransactionCategory.Contains("PaidToSupplier")).Sum(x => x.TransactionAmount),

                                //PrevDue = Convert.ToDecimal(g.OpBalance) + g.AccountsDailyTransaction.Where(x => x.TransactionType == "System Sales").Sum(x => x.TransactionAmount) + g.AccountsDailyTransaction.Where(x => x.TransactionType == "System Sales Return").Sum(x => x.TransactionAmount) - g.AccountsDailyTransaction.Where(x => x.TransactionType.Contains("Received")).Sum(x => x.TransactionAmount) + g.AccountsDailyTransaction.Where(x => x.TransactionType.Contains("Paid")).Sum(x => x.TransactionAmount),
                                g.SupplierCommissionPer
                            })
                            .SingleOrDefault();

                var genericResult = new
                {
                    SupplierInvoiceList = _purchaseRepository.GetAllForDropDownForSupplier(true, SupplierId),
                    SupplierInfo = Supplier
                };
                return Json(genericResult);
            }


        }



        //[AllowAnonymous]
        //public JsonResult GetSupplierInvoice(int SupplierId)
        //{
        //    var supplier = _supplierRepository.All().Include(x => x.AccountsDailyTransaction)
        //    .Where(y => y.Id == SupplierId)
        //    .Select(g => new
        //    {
        //        g.SupplierName,
        //        g.PrimaryAddress,
        //        g.SecoundaryAddress,
        //        g.Email,
        //        g.City,
        //        g.Phone,
        //        PrevDue = g.ClBalance
        //        //PrevDue = Convert.ToDecimal(g.OpBalance) + g.AccountsDailyTransaction.Where(x => x.TransactionType == "System Purchase").Sum(x => x.TransactionAmount) - g.AccountsDailyTransaction.Where(x => x.TransactionType == "System Purchase Return").Sum(x => x.TransactionAmount) - g.AccountsDailyTransaction.Where(x => x.TransactionType.Contains("Paid")).Sum(x => x.TransactionAmount) + g.AccountsDailyTransaction.Where(x => x.TransactionType.Contains("Received")).Sum(x => x.TransactionAmount)
        //    })
        //    .SingleOrDefault();

        //    var genericResult = new
        //    {
        //        SupplierInvoiceList = _purchaseRepository.GetAllForDropDownForSupplier(true, SupplierId),
        //        SupplierInfo = supplier
        //    };
        //    return Json(genericResult);

        //}

        [AllowAnonymous]
        public JsonResult GetAccountHead()
        {
            //return Json(accountHeadRepository.GetCashBankHeadForDropDown());

            var x = AccountHeadPermissionRepository.GetAllForDropDown();
            if (x.Count() == 0)
            {
                x = accountHeadRepository.GetCashBankHeadForDropDown(false);
            }
            ViewBag.Warehouse = x;

            ///fahad need to update
            return Json(x);

            //return Json(accountHeadRepository.GetCashBankHeadForDropDown(false));
        }

        public IActionResult POSCreate()
        {
            try
            {
                PurchaseModel abc = new PurchaseModel();
                abc.PurchaseDate = DateTime.Now.Date;

                var comid = HttpContext.Session.GetString("ComId");
                var userid = HttpContext.Session.GetString("userid");

                object a = HttpContext.Session.GetString("isProductSearch");
                ViewBag.ActionType = "Entry";

                ViewBag.Supplier = _supplierRepository.GetAllForDropDown();
                ViewBag.Category = categoryRepository.GetAllForDropDown();
                var Productresult = productRepository.All().Take(4000);


                ViewBag.Product = new SelectList(Productresult.Where(x => x.Id > 0).Select(s => new { Text = s.Code.Length < 4 ? s.Name : s.Name + " - [ " + s.Code + " ]", Value = s.Id }).ToList(), "Value", "Text");
                ViewBag.ProductSearch = Productresult;
                if (FromWarehousePermissionRepository.GetAllForDropDown().Count() > 0) { ViewBag.Warehouse = FromWarehousePermissionRepository.GetAllForDropDown(); } else { ViewBag.Warehouse = warehouseRepository.GetWarehouseLedgerHeadForDropDown(); }

                ViewBag.PaymentTypes = paymentTypeRepository.GetAllForDropDown();
                ViewBag.AccountHead = accountHeadRepository.GetCashBankHeadForDropDown();


                return View(abc);

            }
            catch (Exception ex)
            {
                ViewBag.error = ex.Message;
                Console.WriteLine(ex.Message);
                return View();
            }


            //return View();


        }
        public class ProductResult
        {
            public int? CategoryId { get; set; }
            public int ProductId { get; set; }
            public string? ProductImage { get; set; }
            public string? CategoryName { get; set; }
            public string? ProductName { get; set; }
            public string? ProductCode { get; set; }
            public string? ProductBarcode { get; set; }
            public string? Description { get; set; }

            public decimal CostPrice { get; set; }
            public double PurchasePrice { get; set; }
            public string? BlankData { get; set; }
            public string? ImagePath { get; set; }
        }
        [HttpPost]
        [AllowAnonymous]
        public JsonResult SupplierInfo(int id)
        {
            try
            {
                SupplierModel Supplier = _supplierRepository.All().Where(y => y.Id == id).SingleOrDefault();
                return Json(Supplier);
            }
            catch (Exception ex)
            {
                return Json(new { success = false, values = ex.Message.ToString() });
            }
        }
        public IActionResult GetProductListClick(int CategoryId)
        {
            try
            {
                var comid = (HttpContext.Session.GetInt32("ComId"));
                //string comid = "F8759147-88B1-4DBA-93B8-E7504B0CE2BE";// HttpContext.Session.GetString("ComId");
                //var abc = db.Products.Include(y => y.vPrimaryCategory);

                if (CategoryId > 0)
                {
                    var query = from e in productRepository.All().Where(x => x.Id > 0 && x.CategoryId == CategoryId && x.ComId == int.Parse(comid.ToString())).OrderByDescending(x => x.Id)
                                    //let FullName = e.ProductName + " " + e.ProductCode
                                    //let ImagePath = e.ImagePath + e.Id + e.FileExtension
                                    //let WarehouseQty = e.InventorySubs != null ? e.InventorySubs.Select(x => new WarehouseResult { WhShortName = x.Warehouses.WhShortName, CurrentStock = x.CurrentStock }).ToList() : null

                                select new ProductResult
                                {
                                    CategoryId = e.CategoryId,
                                    ProductId = e.Id,

                                    //ProductImage = e.ProductImage != null ? Convert.ToBase64String(e.ProductImage) : null,
                                    //CategoryName = e.vPrimaryCategory.Name,
                                    ProductName = e.Name,

                                    //ProductCode = e.ProductCode,
                                    ProductBarcode = e.Code,
                                    //Description = e.Description,
                                    //CostPrice = e.CostPrice,
                                    PurchasePrice = e.Price,
                                    //BlankData = null,

                                    ImagePath = e.ImagePath
                                    //ProductImage = e.ProductImage != null ? Convert.ToBase64String(e.ProductImage) : null,//(asset.ProductImage != null) ? (asset.ProductImage) : null
                                    //WarehouseList = WarehouseQty

                                };



                    var parser = new Parser<ProductResult>(Request.Form, query);

                    return Json(parser.Parse());

                }
                else
                {

                    var query = from e in productRepository.All().Where(x => x.Id > 0 && x.ComId == int.Parse(comid.ToString()))//.OrderByDescending(x => x.ProductId)
                                                                                                                                //let FullName = e.ProductName + " " + e.ProductCode
                                                                                                                                //let ImagePath = e.ImagePath + e.Id + e.FileExtension
                                                                                                                                //let WarehouseQty = e.InventorySubs != null ? e.InventorySubs.Select(x => new WarehouseResult { WhShortName = x.Warehouses.WhShortName, CurrentStock = x.CurrentStock }).ToList() : null
                                select new ProductResult
                                {
                                    CategoryId = e.CategoryId,
                                    ProductId = e.Id,

                                    //ProductImage = e.ProductImage != null ? Convert.ToBase64String(e.ProductImage) : null,
                                    //CategoryName = e.vPrimaryCategory.Name,
                                    ProductName = e.Name,

                                    //ProductCode = e.ProductCode,
                                    ProductBarcode = e.Code,
                                    //Description = e.Description,
                                    //CostPrice = e.CostPrice,
                                    PurchasePrice = e.Price,
                                    //BlankData = null,

                                    ImagePath = e.ImagePath
                                    //ProductImage = e.ProductImage != null ? Convert.ToBase64String(e.ProductImage) : null,//(asset.ProductImage != null) ? (asset.ProductImage) : null
                                    //WarehouseList = WarehouseQty

                                };

                    //var sql = query.ToQueryString();
                    //var abcd = query.ToList();

                    var parser = new Parser<ProductResult>(Request.Form, query);



                    return Json(parser.Parse());
                }

            }
            catch (Exception ex)
            {

                Console.WriteLine(ex.Message);
                return Json(ex.Message);
                //throw ex;
            }
        }
        [AllowAnonymous]
        public JsonResult getProduct(int id)
        {
            var licities = productRepository.GetAllProductForDropDown();

            return Json(new SelectList(licities, "Value", "Text"));
        }
        [AllowAnonymous]
        public JsonResult getBarcode(int id)
        {

            var barcodelist = productRepository.GetAllBarcodeForDropDown();

            return Json(new SelectList(barcodelist, "Value", "Text"));
        }
        [HttpPost]
        [AllowAnonymous]
        public JsonResult ProductInfo(int id)
        {
            try
            {
                ProductModel product = productRepository.All().Where(y => y.Id == id).SingleOrDefault();

                return Json(product);
                //return Json("tesst" );

            }
            catch (Exception ex)
            {
                return Json(new { success = false, values = ex.Message.ToString() });
            }
            //return Json(new SelectList(product, "Value", "Text" ));
        }


    }
}