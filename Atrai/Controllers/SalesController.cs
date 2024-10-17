using Atrai.Core.Common;
using Atrai.Data.Interfaces;
using Atrai.Data.Repository;
using Atrai.Model.Core.Entity;
using Atrai.Model.Core.ViewModel;
using Atrai.Services;
using DataTablesParser;
using Invoice.Core.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
//using Atrai.Data.Reports;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using static Atrai.Controllers.AdminController;
using static Atrai.Controllers.ValuesController;

namespace Atrai.Controllers
{
    //[Authorize]
    [OverridableAuthorize]
    public class SalesController : Controller
    {
        public TransactionLogRepository tranlog { get; }


        private readonly IMenuPermissionRepository _menuPermissionRepository;
        private readonly IReportStyleRepository reportStyleRepository;

        private readonly ICustomerRepository customerRepository;
        private readonly IUserAccountRepository UserAccountRepository;
        private readonly IPurchaseItemsRepository _purchaseItemRepository;
        private readonly IColumnFilterRepository columnFilterRepository;

        private readonly ISupplierRepository supplierRepository;
        private readonly ITermsMainRepository termsmainRepository;
        private readonly IRecurringDetailsRepository recurringDetailsRepository;
        private readonly ITransactionRepository transactionRepository;
        private readonly IAdvanceTrasactionTrackingRepository advanceTransactionTrackingRepository;
        private readonly IDocPrefixRepository docPrefixRepository;
        private readonly IDocApprovalSettingRepository _docApprovalSettingRepository;
        private readonly IApprovalStatusRepository approvalStatusRepository;
        private readonly ITransactionApprovalStatusRepository transactionApprovalStatusRepository;

        private IEmailSender _emailsender { get; }
        private ISmsSender _smsSender { get; }

        private readonly IOrdersRepository onlineOrderRepository;
        private readonly IOrdersItemsRepository orderItemRepository;
        private readonly ISalesTagRepository salesTagRepository;
        private readonly ICustomFormStyleRepository _customFormStyleRepository;
        private readonly ITagsRepository tagsRepository;

        private readonly ISalesItemsRepository saleItemRepository;
        private readonly ISalesReturnItemsRepository salesReturnItemRepository;
        private readonly ISalesProductTaxRepository salesProductTaxRepository;
        private readonly IAuditLogRepository auditLogRepository;

        private readonly ISalesBatchItemsRepository _salesBatchItemRepository;
        private readonly IPurchaseBatchItemsRepository _purchaseBatchItemRepository;

        private readonly ISalesPaymentRepository salesPaymentRepository;
        private readonly ISalesTermsRepository salesTermsRepository;
        private readonly ITransactionRepository _accountsDailyTransaction;
        private readonly ITransactionDetailsRepository _transactionDetailsRepository;

        private readonly IBrandRepository brandRepository;
        private readonly IPurchaseRepository purchaseRepository;
        private readonly IStoreSettingRepository _storeSettingRepository;

        private readonly IPurchaseItemsRepository purchaseItemsRepository;
        private readonly IPurchasePaymentRepository purchasePaymentRepository;
        private readonly ITaxCriteriaRepository taxCriteriaRepository;

        private readonly IStoreSettingRepository storeSettingRepository;
        private readonly IConfiguration configuration;
        private readonly ICompanyRepository companyRepository;
        private readonly ICategoryRepository categoryRepository;
        private readonly IUnitRepository _unitRepository;

        private readonly IProductRepository productRepository;
        private readonly IProductTypeRepository productTypeRepository;
        private readonly IWarehouseRepository _warehouseRepository;
        private readonly IFromWarehousePermissionRepository _FromWarehousePermissionRepository;
        private readonly IToWarehousePermissionRepository ToWarehousePermissionRepository;

        private readonly IAccountHeadPermissionRepository AccountHeadPermissionRepository;



        private readonly IAccountHeadRepository accountHeadRepository;
        private readonly IPaymentTypeRepository paymentTypeRepository;
        private readonly IDocTypeRepository _docTypeRepository;
        private readonly IEmployeeRepository _employeeRepository;
        private readonly ITimeZoneSettingsRepository _timeZoneSettingsRepository;

        private readonly ICountryRepository _currencyRepository;
        private readonly ISaleRepository saleRepository;
        private readonly IAccountCategoryRepository accountCategoryRepository;


        private readonly IGatePassRepository gatePassRepository;
        private readonly IGatePassItemsRepository gatePassItemRepository;

        private readonly ICostCalculatedRepository costCalculatedRepository;
        private readonly IFeedbackRepository _feedbackRepository;
        private readonly ICreditBalanceRepository _CreditBalanceRepository;
        private readonly ICreditUsedRepository _creditUsedRepository;
        private readonly IAgencyRepository _agencyRepository;
        private readonly ISalesTaxRepository _salestaxRepository;
        private readonly IMasterSalesTaxRepository _mastersalestaxRepository;
        private readonly IHttpContextAccessor httpcontext;
        private readonly ITermsMainRepository _termsMainRepository;
        private readonly ITermRepository _termRepository;
        private readonly IWebHostEnvironment _webHostEnvironment;
        private readonly IProductWarehouseRepository _productWarehouseRepository;
        //private readonly IpaymentTypesRepository paymentTypesRepository;


        public static string ExpressionParameterizationException { get; }
        Dictionary<int, dynamic> postData = new Dictionary<int, dynamic>();


        public SalesController(ICustomerRepository customerRepository, IUserAccountRepository UserAccountRepository, ISaleRepository saleRepository,
            ISupplierRepository supplierRepository, IPurchaseRepository purchaseRepository, IStoreSettingRepository storeSettingRepository, IRecurringDetailsRepository recurringDetailsRepository,
            ITransactionRepository transactionRepository, IProductWarehouseRepository productWarehouseRepository, IDocPrefixRepository docPrefixRepository,
            ISalesItemsRepository saleItemRepository, ISalesBatchItemsRepository saleBatchItemRepository, ISalesPaymentRepository salesPaymentRepository, ITransactionApprovalStatusRepository transactionApprovalStatusRepository, ITaxCriteriaRepository taxCriteriaRepository,
            IPurchaseBatchItemsRepository purchaseBatchItemRepository, ICostCalculatedRepository costCalculatedRepository, IDocApprovalSettingRepository docApprovalSettingRepository,
             IPurchaseItemsRepository purchaseItemsRepository, IPurchasePaymentRepository purchasePaymentRepository, ITagsRepository tagsRepository, IApprovalStatusRepository approvalStatusRepository,
        ITransactionDetailsRepository transactionDetailsRepository, IProductTypeRepository productTypeRepository, IBrandRepository brandRepository, ISalesTagRepository salesTagRepository, IAdvanceTrasactionTrackingRepository advanceTransactionTrackingRepository, IAuditLogRepository auditLogRepository, IColumnFilterRepository columnFilterRepository,
        ICategoryRepository categoryRepository, IUnitRepository unitRepository, IProductRepository productRepository, IPurchaseItemsRepository purchaseItemRepository,
            IWarehouseRepository _warehouseRepository, IFromWarehousePermissionRepository FromWarehousePermissionRepository, IToWarehousePermissionRepository ToWarehousePermissionRepository, IAccountHeadRepository accountHeadRepository,
            IPaymentTypeRepository paymentTypeRepository, ICompanyRepository companyRepository, ICustomFormStyleRepository customFormStyleRepository,
            IConfiguration configuration, TransactionLogRepository tranlogRepository, IReportStyleRepository reportStyleRepository, IOrdersRepository onlineOrderRepository, IOrdersItemsRepository orderItemRepository, IDocTypeRepository docTypeRepository, ICreditBalanceRepository sMSBalanceRepository, ICreditUsedRepository creditUsedRepository, IEmailSender emailsender, ISmsSender smsSender, IAccountHeadPermissionRepository accountHeadPermissionRepository, IMenuPermissionRepository menuPermissionRepository, ITermsMainRepository termsmainRepository, ICountryRepository currencyRepository, IEmployeeRepository employeeRepository, ISalesTermsRepository salesTermsRepository, ITransactionRepository accountsDailyTransaction, ISalesReturnItemsRepository salesReturnItemRepository, IGatePassRepository gatePassRepository, IGatePassItemsRepository gatePassItemRepository, IAgencyRepository agencyRepository, ISalesTaxRepository salestaxRepository, IMasterSalesTaxRepository masterSalesTaxRepository, ISalesProductTaxRepository salesProductTaxRepository, IFeedbackRepository feedbackRepository, IAccountCategoryRepository accountCategoryRepository,
        ITermsMainRepository termsMainRepository, ITermRepository termRepository, IWebHostEnvironment webHostEnvironment)
        {
            this.configuration = configuration;

            this.customerRepository = customerRepository;
            this.UserAccountRepository = UserAccountRepository;
            this.brandRepository = brandRepository;
            this.saleRepository = saleRepository;
            this.saleItemRepository = saleItemRepository;
            this._salesBatchItemRepository = saleBatchItemRepository;
            this._purchaseBatchItemRepository = purchaseBatchItemRepository;
            this.salesTagRepository = salesTagRepository;
            this.approvalStatusRepository = approvalStatusRepository;
            this.salesPaymentRepository = salesPaymentRepository;
            this.columnFilterRepository = columnFilterRepository;
            this.salesProductTaxRepository = salesProductTaxRepository;
            this.productTypeRepository = productTypeRepository;
            this.recurringDetailsRepository = recurringDetailsRepository;
            this.auditLogRepository = auditLogRepository;
            _docApprovalSettingRepository = docApprovalSettingRepository;
            _purchaseItemRepository = purchaseItemRepository;
            this._storeSettingRepository = storeSettingRepository;
            this.supplierRepository = supplierRepository;
            this.taxCriteriaRepository = taxCriteriaRepository;
            this.purchaseRepository = purchaseRepository;
            this.purchaseItemsRepository = purchaseItemsRepository;
            this.purchasePaymentRepository = purchasePaymentRepository;
            this.tagsRepository = tagsRepository;
            this.docPrefixRepository = docPrefixRepository;
            this.transactionRepository = transactionRepository;
            this.advanceTransactionTrackingRepository = advanceTransactionTrackingRepository;
            this.costCalculatedRepository = costCalculatedRepository;
            this.storeSettingRepository = storeSettingRepository;
            this.companyRepository = companyRepository;
            this.categoryRepository = categoryRepository;
            _productWarehouseRepository = productWarehouseRepository;
            _unitRepository = unitRepository;
            _customFormStyleRepository = customFormStyleRepository;
            this.productRepository = productRepository;
            this._warehouseRepository = _warehouseRepository;
            _FromWarehousePermissionRepository = FromWarehousePermissionRepository;
            this.ToWarehousePermissionRepository = ToWarehousePermissionRepository;
            this.accountCategoryRepository = accountCategoryRepository;
            _feedbackRepository = feedbackRepository;
            this.accountHeadRepository = accountHeadRepository;
            this.paymentTypeRepository = paymentTypeRepository;
            tranlog = tranlogRepository;
            this.reportStyleRepository = reportStyleRepository;
            this.onlineOrderRepository = onlineOrderRepository;
            this.orderItemRepository = orderItemRepository;
            _docTypeRepository = docTypeRepository;
            _CreditBalanceRepository = sMSBalanceRepository;
            _creditUsedRepository = creditUsedRepository;
            _emailsender = emailsender;
            _smsSender = smsSender;
            AccountHeadPermissionRepository = accountHeadPermissionRepository;
            _menuPermissionRepository = menuPermissionRepository;
            this.termsmainRepository = termsmainRepository;
            _currencyRepository = currencyRepository;
            _employeeRepository = employeeRepository;
            this.salesTermsRepository = salesTermsRepository;
            _accountsDailyTransaction = accountsDailyTransaction;
            this.salesReturnItemRepository = salesReturnItemRepository;
            this.gatePassRepository = gatePassRepository;
            this.gatePassItemRepository = gatePassItemRepository;
            _agencyRepository = agencyRepository;
            _salestaxRepository = salestaxRepository;
            _mastersalestaxRepository = masterSalesTaxRepository;
            httpcontext = new HttpContextAccessor();
            _termsMainRepository = termsMainRepository;
            _termRepository = termRepository;
            _webHostEnvironment = webHostEnvironment;
            _transactionDetailsRepository = transactionDetailsRepository;
        }

        [AllowAnonymous]
        public IActionResult OnlineOrderList(string filter = "All")
        {
            var sessionLuserId = (HttpContext.Session.GetInt32("UserId"));
            var UserRole = HttpContext.Session.GetString("UserRole");
            //var CustomerId = HttpContext.Session.GetInt32("CustomerId");


            if (UserRole == "Admin" || UserRole == "SuperAdmin")
            {
                ViewBag.Users = UserAccountRepository.GetAllForDropDown();
                ViewBag.Customers = customerRepository.GetAllForDropDown();
            }
            else if (UserRole == "User")//(CustomerId != 0 || CustomerId != null)
            {
                ViewBag.Users = UserAccountRepository.CurrentUserAccountForDropdown();
                //ViewBag.Customers = customerRepository.CurrentUserCustomerForDropdown().Where(x=>x.Value == CustomerId.GetValueOrDefault().ToString());

                var employeeid = UserAccountRepository.All().Where(x => x.Id == sessionLuserId).FirstOrDefault().EmployeeId;

                ViewBag.Customers = customerRepository.All().Where(p => p.SalesRepresentativeId == employeeid)
                       .Select(x => new SelectListItem
                       {
                           Text = x.Name,
                           Value = x.Id.ToString()
                       });

            }
            else
            {
                ViewBag.Users = UserAccountRepository.CurrentUserAccountForDropdown();
                ViewBag.Customers = customerRepository.CurrentUserCustomerForDropdown();
            }






            ViewBag.filter = filter;


            return View();
        }

        public static DateTime DateNow(string timezone = "Middle East Standard Time")
        {
            return TimeZoneInfo.ConvertTimeFromUtc(DateTime.UtcNow, TimeZoneInfo.FindSystemTimeZoneById(timezone));
        }


        public IActionResult Index(string filter = "All")
        {
            ViewBag.FromDate = DateTime.Now.Date;
            ViewBag.ToDate = DateTime.Now.Date;

            var TimeZoneSettingsName = HttpContext.Session.GetString("TimeZoneSettingsName");
            if (TimeZoneSettingsName.Length > 3)
            {
                var localtime = TimeZoneInfo.ConvertTime(DateTime.Now, TimeZoneInfo.FindSystemTimeZoneById(TimeZoneSettingsName));
                ViewBag.FromDate = localtime.Date;
                ViewBag.ToDate = localtime.Date;

            }



            ViewBag.Customers = customerRepository.GetAllForDropDown();
            ViewBag.Category = categoryRepository.GetAllForDropDown();
            ViewBag.DocType = _docTypeRepository.GetSalesDocForDropDown();
            ViewBag.SalesRep = _employeeRepository.GetAllForDropDown();

            //ViewBag.Currency = _currencyRepository.GetCurrencyList();



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

            //var arrayabc = _FromWarehousePermissionRepository.All().Where(x => x.LuserIdAllow == sessionLuserId).Select(x => x.WarehouseId).ToList();


            //if (arrayabc.Count() > 0)
            //{
            //    ViewBag.Warehouse = _FromWarehousePermissionRepository.All().Where(p => arrayabc.Contains(p.WarehouseId))
            //        .Select(x => new SelectListItem
            //        {
            //            Text = x.WarehouseList.WhShortName,
            //            Value = x.WarehouseList.Id.ToString()
            //        });

            //}
            //else
            //{
            //    ViewBag.Warehouse = _warehouseRepository.GetWarehouseLedgerHeadForDropDown();
            //}

            SelectListItem abc = new SelectListItem() { Text = "Please Select", Value = "" };

            var x = _FromWarehousePermissionRepository.GetAllForDropDown().ToList();
            if (x.Count() == 0)
            {
                x = _warehouseRepository.GetWarehouseLedgerHeadForDropDown().ToList();
                x.Add(abc);
            }
            //else
            //{
            //    //x.Append(abc);
            //}

            ViewBag.Warehouse = x.OrderBy(x => x.Value);


            //if (arrayabc.Count() > 0) 
            //{ 
            //    ViewBag.Warehouse = _FromWarehousePermissionRepository.All().Where(x=> arrayabc.Contains() WarehouseList == ).GetAllForDropDown(); 
            //} 
            //else 
            //{ 
            //    ViewBag.Warehouse = _warehouseRepository.GetWarehouseLedgerHeadForDropDown(); 
            //}

            //ViewBag.FromDate = DateTime.Now.Date.ToString("dd-MMM-yy");

            //int abcd = HttpContext.Session.GetInt32("ComId");
            //return View(saleRepository.All().Include(x=>x.CustomerModel).OrderByDescending(x=>x.Id));
            return View();
        }

        [AllowAnonymous]
        public IActionResult GatePassList(string filter = "All")
        {
            ViewBag.FromDate = DateTime.Now.Date;
            ViewBag.ToDate = DateTime.Now.Date;

            var TimeZoneSettingsName = HttpContext.Session.GetString("TimeZoneSettingsName");
            if (TimeZoneSettingsName.Length > 3)
            {
                var localtime = TimeZoneInfo.ConvertTime(DateTime.Now, TimeZoneInfo.FindSystemTimeZoneById(TimeZoneSettingsName));
                ViewBag.FromDate = localtime.Date;
                ViewBag.ToDate = localtime.Date;

            }



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


            return View();
        }

        [AllowAnonymous]
        public IActionResult ChartSample()
        {

            return View();
        }

        public IActionResult SerialProductHistory()
        {
            ViewBag.Products = productRepository.GetAllProductForDropDown();

            return View();
        }
        public IActionResult SalesDetailsList()
        {
            ViewBag.FromDate = DateTime.Now.Date;
            ViewBag.ToDate = DateTime.Now.Date;

            ViewBag.Customers = customerRepository.GetAllForDropDown();
            ViewBag.Category = categoryRepository.GetAllForDropDown();
            ViewBag.DocType = _docTypeRepository.GetSalesDocForDropDown();
            ViewBag.SalesRep = _employeeRepository.GetAllForDropDown();


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

            var x = _FromWarehousePermissionRepository.GetAllForDropDown();
            if (x.Count() == 0)
            {
                x = _warehouseRepository.GetWarehouseLedgerHeadForDropDown();
            }
            else
            {
                x.Append(abc);
            }

            ViewBag.Warehouse = x;

            return View();
        }





        [HttpGet]
        [AllowAnonymous]

        public IActionResult HTMLBarcodePrint()
        {
            return View();
        }

        [HttpGet]
        [AllowAnonymous]

        public IActionResult JqueryBarcodePrint()
        {



            var sessionLuserId = (HttpContext.Session.GetInt32("UserId"));
            //var UserRole = HttpContext.Session.GetString("UserRole");

            var arrayabc = _FromWarehousePermissionRepository.All().Where(x => x.LuserIdAllow == sessionLuserId).Select(x => x.WarehouseId).ToList();


            if (arrayabc.Count() > 0)
            {
                ViewBag.Warehouse = _FromWarehousePermissionRepository.All().Where(p => arrayabc.Contains(p.WarehouseId))
                    .Select(x => new SelectListItem
                    {
                        Text = x.WarehouseList.WhShortName,
                        Value = x.WarehouseList.Id.ToString()
                    });

            }
            else
            {
                ViewBag.Warehouse = _warehouseRepository.GetWarehouseLedgerHeadForDropDown();
            }


            return View();
        }


        [AllowAnonymous]
        [HttpPost, ActionName("ShowAlertSession")]

        public JsonResult ShowAlertSession(string CommandType)
        {
            try
            {
                HttpContext.Session.SetInt32("ShowAlert", 0);
                return Json(new { Success = 1, ex = "Command Executed Successfully." });

            }

            catch (Exception ex)
            {
                // If Sucess== 0 then Unable to perform Save/Update Operation and send Exception to View as JSON
                return Json(new { Success = 0, ex = ex.InnerException.InnerException.Message.ToString() });
            }


        }


        [AllowAnonymous]
        [HttpPost, ActionName("SomeAction")]

        public JsonResult SomeAction(string[] SalesId, string CommandType)
        {
            try
            {
                var ComId = HttpContext.Session.GetInt32("ComId");
                //var saleslist = SalesId.TrimStart('[').TrimEnd(']').Split(',');


                if (CommandType == "cntrlh")
                {
                    foreach (var item in SalesId)
                    {
                        var singlesaledata = saleRepository.Find(int.Parse(item));
                        singlesaledata.IsDelete = true;

                        saleRepository.Update(singlesaledata, int.Parse(item));
                    }


                }
                else if (CommandType == "cntrlu")
                {
                    foreach (var item in SalesId)
                    {
                        var singlesaledata = saleRepository.Find(int.Parse(item));
                        singlesaledata.IsDelete = false;

                        saleRepository.Update(singlesaledata, int.Parse(item));
                    }

                }
                else if (CommandType == "cntrlq")
                {

                    var company = companyRepository.All().Where(x => x.Id == ComId).FirstOrDefault();
                    var userpermissionmenulist = _menuPermissionRepository.All();//.Include(x => x.Menus)

                    userpermissionmenulist = userpermissionmenulist.Include(x => x.Menus).Where(x => x.BusinessTypeId == company.BusinessTypeId).OrderBy(x => x.Menus.DisplayOrder);

                    bool vatactivate;
                    int? vatview = HttpContext.Session.GetInt32("VatViewActivate");

                    if (vatview == null || vatview == 0)
                    {
                        HttpContext.Session.SetInt32("VatViewActivate", 1);
                        //vatactivate = true;
                        userpermissionmenulist = userpermissionmenulist.Include(x => x.Menus).Where(x => x.Menus.IsVatMenu == true);
                    }
                    else
                    {
                        HttpContext.Session.SetInt32("VatViewActivate", 0);
                        //vatactivate = false;
                    }





                    List<UserMenuPermissionViewModel> userallmenulist = new List<UserMenuPermissionViewModel>();

                    if (userpermissionmenulist != null)
                    {
                        foreach (var item in userpermissionmenulist)
                        {
                            UserMenuPermissionViewModel usermenudata = new UserMenuPermissionViewModel();

                            usermenudata.Id = item.Menus.Id;

                            usermenudata.ActionName = item.Menus.ActionName;
                            usermenudata.ControllerName = item.Menus.ControllerName;
                            usermenudata.IsCreate = true;// item.IsCreate;
                            usermenudata.IsDeleteP = true;//item.IsDeleteP;
                            usermenudata.IsEdit = true;//item.IsEdit;
                            usermenudata.isDefault = true;//item.isDefault;
                            usermenudata.SLNo = item.Menus.DisplayOrder.GetValueOrDefault();

                            usermenudata.IsGroup = item.Menus.isGroup;
                            usermenudata.IsParent = item.Menus.isParent;
                            usermenudata.ParentId = item.Menus.ParentId;

                            usermenudata.MenuGroupName = item.Menus.MenuGroupName;
                            usermenudata.MenuName = item.Menus.MenuName;
                            usermenudata.MenuClass = item.Menus.MenuClass;


                            usermenudata.AllActionName = item.Menus.AllActionName;
                            usermenudata.IsCreateAction = item.Menus.IsCreateAction;
                            usermenudata.IsEditAction = item.Menus.IsEditAction;
                            usermenudata.IsDeleteAction = item.Menus.IsDeleteAction;
                            usermenudata.IsViewAction = item.Menus.IsViewAction;
                            usermenudata.IsListAction = item.Menus.IsListAction;
                            usermenudata.IsReportAction = item.Menus.IsReportAction;


                            userallmenulist.Add(usermenudata);
                        }
                    }

                    HttpContext.Session.SetObject("UserAllMenu", userallmenulist);
                    HttpContext.Session.SetObject("UserGroupMenu", userallmenulist.Where(x => x.IsGroup == true));
                    HttpContext.Session.SetObject("UserParentMenu", userallmenulist.Where(x => x.IsParent == true));
                    HttpContext.Session.SetObject("UserChildMenu", userallmenulist.Where(x => x.ParentId != null));


                }

                return Json(new { Success = 1, ex = "Command Executed Successfully." });

            }

            catch (Exception ex)
            {
                // If Sucess== 0 then Unable to perform Save/Update Operation and send Exception to View as JSON
                return Json(new { Success = 0, ex = ex.InnerException.InnerException.Message.ToString() });
            }

            //return Json(new { Success = 0, ex = new Exception("Unable to Open").Message.ToString() });
            //return RedirectToAction("Index");

        }



        [AllowAnonymous]
        [HttpPost, ActionName("ProfitAction")]

        public JsonResult ProfitAction(string[] SalesId, string CommandType)
        {
            try
            {
                var ComId = HttpContext.Session.GetInt32("ComId");
                //var saleslist = SalesId.TrimStart('[').TrimEnd(']').Split(',');


                if (CommandType == "cntrlr")
                {
                    foreach (var item in SalesId)
                    {


                        SqlParameter[] sqlParameter1 = new SqlParameter[2];
                        sqlParameter1[0] = new SqlParameter("@ComId", ComId);
                        sqlParameter1[1] = new SqlParameter("@SalesId", item);
                        Helper.ExecProc("[Sales_ProcessRuntimeProfitCalculation]", sqlParameter1);


                    }


                }


                return Json(new { Success = 1, ex = "Command Executed Successfully." });

            }

            catch (Exception ex)
            {
                // If Sucess== 0 then Unable to perform Save/Update Operation and send Exception to View as JSON
                return Json(new { Success = 0, ex = ex.InnerException.InnerException.Message.ToString() });
            }

            //return Json(new { Success = 0, ex = new Exception("Unable to Open").Message.ToString() });
            //return RedirectToAction("Index");

        }



        [AllowAnonymous]
        [HttpPost, ActionName("AllSalesReport")]

        public JsonResult AllSalesReport(string rptFormat, string action, string CustomerId, string UserId, string FromDate, string ToDate, string WarehouseId, string Status)
        {
            try
            {
                var ComId = HttpContext.Session.GetInt32("ComId");

                var reportname = "";
                var filename = "";
                string redirectUrl = "";
                if (action == "PrintSalesListWithItem")
                {
                    reportname = "rptSalesListWithItem";
                    filename = "Sales_Details_List_" + DateTime.Now.Date;
                    HttpContext.Session.SetString("ReportQuery", "Exec Sales_rptSalesList '" + ComId + "','" + FromDate + "','" + ToDate + "', '" + CustomerId + "' ,'" + WarehouseId + "' ,'" + UserId + "' , '" + Status + "' ");
                    HttpContext.Session.SetString("ReportPath", "~/ReportViewer/Sales/" + reportname + ".rdlc");
                }
                else if (action == "PrintSalesCommissionSummary")
                {
                    reportname = "rptSalesCommissionSummary";
                    filename = "Sales_Details_List_" + DateTime.Now.Date;
                    HttpContext.Session.SetString("ReportQuery", "Exec Sales_rptSalesCommission '" + ComId + "','" + FromDate + "','" + ToDate + "', '" + CustomerId + "' ,'" + WarehouseId + "' ,'" + UserId + "' , '" + Status + "' ");
                    HttpContext.Session.SetString("ReportPath", "~/ReportViewer/Sales/" + reportname + ".rdlc");
                }
                else if (action == "PrintBusinessSummary") /// mr. asif saheb requirement when he going for print.
                {

                    reportname = "rptBusinessSummary";
                    filename = "Summary_" + DateTime.Now.Date;
                    HttpContext.Session.SetString("ReportQuery", "Exec POS_rptBusinessSummary '" + ComId + "','" + FromDate + "','" + ToDate + "',Business Summary");
                    HttpContext.Session.SetString("ReportPath", "~/ReportViewer/POS/" + reportname + ".rdlc");

                    postData.Add(1, new subReport("rptInvoice_PM", "", "DataSet1", "Exec POS_rptBusinessSummary ," + ComId + "," + FromDate + "," + ToDate + ",Total Sales Amount"));
                    postData.Add(2, new subReport("rptInvoice_PM", "", "DataSet1", "Exec POS_rptBusinessSummary ," + ComId + "," + FromDate + "," + ToDate + ",Total Purchase Amount"));
                    postData.Add(3, new subReport("rptInvoice_PM", "", "DataSet1", "Exec POS_rptBusinessSummary ," + ComId + "," + FromDate + "," + ToDate + ",Total Received Amount"));
                    postData.Add(4, new subReport("rptInvoice_PM", "", "DataSet1", "Exec POS_rptBusinessSummary ," + ComId + "," + FromDate + "," + ToDate + ",Total Paid Amount"));
                    postData.Add(5, new subReport("rptInvoice_PM", "", "DataSet1", "Exec POS_rptBusinessSummary ," + ComId + "," + FromDate + "," + ToDate + ",Sales Due"));
                    postData.Add(6, new subReport("rptInvoice_PM", "", "DataSet1", "Exec POS_rptBusinessSummary ," + ComId + "," + FromDate + "," + ToDate + ",Customer Wise Sales Due"));
                    postData.Add(7, new subReport("rptInvoice_PM", "", "DataSet1", "Exec POS_rptBusinessSummary ," + ComId + "," + FromDate + "," + ToDate + ",Total Supplier Due"));
                    postData.Add(7, new subReport("rptInvoice_PM", "", "DataSet1", "Exec POS_rptBusinessSummary ," + ComId + "," + FromDate + "," + ToDate + ",Supplier Wise Purcahse Due"));



                }




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



        [HttpGet]
        [AllowAnonymous]
        public IActionResult AddSale(int saleId = 0)
        {

            ViewBag.ActionType = "Create";
            //int saleId = 0;
            ViewBag.customers = customerRepository.GetAllForDropDown();


            //if (_FromWarehousePermissionRepository.GetAllForDropDown().Count() > 0) 
            //{ 
            //    ViewBag.Warehouse = _FromWarehousePermissionRepository.GetAllForDropDown(); 
            //} 
            //else 
            //{ 
            //    ViewBag.Warehouse = _warehouseRepository.GetWarehouseLedgerHeadForDropDown(); 
            //}
            var x = _FromWarehousePermissionRepository.GetAllForDropDown();
            if (x.Count() == 0)
            {
                x = _warehouseRepository.GetWarehouseLedgerHeadForDropDown();
            }
            ViewBag.Warehouse = x;



            ViewBag.Category = categoryRepository.GetAllForDropDown();
            ViewBag.Unit = _unitRepository.GetAllForDropDown();
            ViewBag.DocType = _docTypeRepository.GetSalesDocForDropDown();
            ViewBag.SalesRep = _employeeRepository.GetAllForDropDown();
            ViewBag.Currency = _currencyRepository.GetCurrencyList();


            return View(model: saleId);
        }
        [HttpGet]
        [AllowAnonymous]
        public IActionResult AddSaleSerial()
        {

            ViewBag.ActionType = "Create";
            int saleId = 0;
            //ViewBag.customers = customerRepository.GetAllForDropDown();


            ///if (_FromWarehousePermissionRepository.GetAllForDropDown().Count() > 0) { ViewBag.Warehouse = _FromWarehousePermissionRepository.GetAllForDropDown(); } else { ViewBag.Warehouse = _warehouseRepository.GetWarehouseLedgerHeadForDropDown(); }

            var x = _FromWarehousePermissionRepository.GetAllForDropDown();
            if (x.Count() == 0)
            {
                x = _warehouseRepository.GetWarehouseLedgerHeadForDropDown();
            }
            ViewBag.Warehouse = x;

            ViewBag.Category = categoryRepository.GetAllForDropDown();
            ViewBag.Unit = _unitRepository.GetAllForDropDown();
            ViewBag.DocType = _docTypeRepository.GetSalesDocForDropDown();
            ViewBag.SalesRep = _employeeRepository.GetAllForDropDown();
            ViewBag.Currency = _currencyRepository.GetCurrencyList();

            return View(model: saleId);
        }

        [HttpGet]
        [AllowAnonymous]
        public IActionResult AddSaleBySerialSearch()
        {


            //var abc = DateNow();
            //var test = TimeZoneInfo.ConvertTimeFromUtc(DateTime.UtcNow, TimeZoneInfo.FindSystemTimeZoneById("Arabic Standard Time"));




            @ViewBag.IsCopy = "0";
            ViewBag.ActionType = "Create";
            int saleId = 0;
            //ViewBag.customers = customerRepository.GetAllForDropDown();
            //if (_FromWarehousePermissionRepository.GetAllForDropDown().Count() > 0) { ViewBag.Warehouse = _FromWarehousePermissionRepository.GetAllForDropDown(); } else { ViewBag.Warehouse = _warehouseRepository.GetWarehouseLedgerHeadForDropDown(); }

            var x = _FromWarehousePermissionRepository.GetAllForDropDown();
            if (x.Count() == 0)
            {
                x = _warehouseRepository.GetWarehouseLedgerHeadForDropDown();
            }
            ViewBag.Warehouse = x;

            ViewBag.Category = categoryRepository.GetAllForDropDown();
            ViewBag.Unit = _unitRepository.GetAllForDropDown();
            ViewBag.DocType = _docTypeRepository.GetSalesDocForDropDown();
            ViewBag.SalesRep = _employeeRepository.GetAllForDropDown();
            ViewBag.Currency = _currencyRepository.GetCurrencyList();




            return View(model: saleId);
        }


        [HttpGet]
        [AllowAnonymous]
        public IActionResult AddGatePass(int GatePassId = 0)
        {


            //var abc = DateNow();
            //var test = TimeZoneInfo.ConvertTimeFromUtc(DateTime.UtcNow, TimeZoneInfo.FindSystemTimeZoneById("Arabic Standard Time"));




            @ViewBag.IsCopy = "0";
            ViewBag.ActionType = "Create";

            //ViewBag.customers = customerRepository.GetAllForDropDown();
            //if (_FromWarehousePermissionRepository.GetAllForDropDown().Count() > 0) { ViewBag.Warehouse = _FromWarehousePermissionRepository.GetAllForDropDown(); } else { ViewBag.Warehouse = _warehouseRepository.GetWarehouseLedgerHeadForDropDown(); }

            //var x = _FromWarehousePermissionRepository.GetAllForDropDown();
            //if (x.Count() == 0)
            //{
            //    x = _warehouseRepository.GetWarehouseLedgerHeadForDropDown();
            //}
            //ViewBag.Warehouse = x;

            //ViewBag.Category = categoryRepository.GetAllForDropDown();
            //ViewBag.Unit = _unitRepository.GetAllForDropDown();
            //ViewBag.DocType = _docTypeRepository.GetSalesDocForDropDown();
            //ViewBag.SalesRep = _employeeRepository.GetAllForDropDown();
            //ViewBag.Currency = _currencyRepository.GetCurrencyList();




            return View(model: GatePassId);
        }





        [HttpGet]
        [AllowAnonymous]
        public IActionResult AddSaleStatus()
        {


            //var abc = DateNow();
            //var test = TimeZoneInfo.ConvertTimeFromUtc(DateTime.UtcNow, TimeZoneInfo.FindSystemTimeZoneById("Arabic Standard Time"));




            @ViewBag.IsCopy = "0";
            ViewBag.ActionType = "Create";
            int saleStatusId = 0;


            return View(model: saleStatusId);
        }


        public class SalesStatusModel
        {
            public int SalesId { get; set; }
            public int SalesStatusId { get; set; }

        }

        [HttpPost]
        [AllowAnonymous]
        public IActionResult SalesStatusUpdate([FromBody] List<SalesStatusModel> model)
        {
            try
            {
                var UserId = HttpContext.Session.GetInt32("UserId");
                var ComId = HttpContext.Session.GetInt32("ComId");


                var errors = ModelState.Where(x => x.Value.Errors.Any())
                .Select(x => new { x.Key, x.Value.Errors });

                //var x = model;

                foreach (var item in model)
                {
                    //if (item.SalesStatusId != null)
                    //{

                    var currentsalesdata = saleRepository.Find(item.SalesId);
                    currentsalesdata.DocStatusId = item.SalesStatusId;
                    saleRepository.Update(currentsalesdata, item.SalesId);
                    //}


                }



                return Json(new { error = true, message = "Data Update Successfully" });


            }
            catch (Exception ex)
            {

                return Json(new { error = true, message = ex.Message });
            }
        }




        [HttpPost]
        [AllowAnonymous]
        public IActionResult AddGatePass([FromBody] GatePassModel model)
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


                        gatePassRepository.Update(model, model.Id);



                        var previousitem = gatePassItemRepository.All().Where(x => x.GatePassId == model.Id).ToList();
                        var tmp = previousitem.Where(x => !model.Items.Any(z => x.Id == z.Id)).ToList();
                        gatePassItemRepository.RemoveRange(tmp);



                        foreach (GatePassItemsModel item in model.Items)
                        {
                            item.ComId = ComId.HasValue ? ComId.Value : 0;

                            if (item.Id > 0)
                            {
                                if (item.IsDelete == true || item.Quantity == 0)
                                {
                                    int z = item.Id;
                                    gatePassItemRepository.Delete(item);

                                }
                                else
                                {
                                    if (item.IsTransaction == true)//item.IsDelete == false &&  
                                    {
                                        gatePassItemRepository.Update(item, item.Id);

                                    }
                                }
                            }
                            else
                            {
                                if (item.IsDelete == true || item.Quantity == 0)
                                {
                                }
                                else
                                {

                                    gatePassItemRepository.Insert(item);


                                }
                            }
                        }


                        TempData["Message"] = "Data Update Successfully";
                        TempData["Status"] = "2";
                        tranlog.TransactionLog(RouteData.Values["controller"].ToString(), RouteData.Values["action"].ToString(), TempData["Message"].ToString(), model.Id.ToString(), "Update", model.GatePassCode);


                        return Json(new { Success = 2, Id = model.Id, message = "Date Update successfully" });
                    }
                    else
                    {

                        foreach (var item in model.Items)
                        {

                            item.CreateDate = DateTime.Now;
                            item.UpdateDate = DateTime.Now;


                        }




                        gatePassRepository.Insert(model);



                        TempData["Message"] = "Data Save Successfully";
                        TempData["Status"] = "1";
                        tranlog.TransactionLog(RouteData.Values["controller"].ToString(), RouteData.Values["action"].ToString(), TempData["Message"].ToString(), model.Id.ToString(), "Create", model.GatePassCode);


                        return Json(new { Success = 1, Id = model.Id, message = "Data Save successfully" });

                        //return Json(new {Success=1, error = false, message = "Data Save successfully" });
                    }

                }
                else
                {
                    return Json(new { error = true, message = "failed to Save the Data" });
                }



            }
            catch (Exception ex)
            {

                return Json(new { error = true, message = ex.Message });
            }
        }



        public IActionResult DeleteGatePass(int GatePassId)
        {
            try
            {
                var ComId = HttpContext.Session.GetInt32("ComId");


                var model = gatePassRepository.All().Where(x => x.Id == GatePassId && x.isPosted == false).FirstOrDefault(); //.Find(saleId);


                gatePassRepository.Delete(model);
                TempData["Message"] = "Data Delete Successfully";
                TempData["Status"] = "3";
                tranlog.TransactionLog(RouteData.Values["controller"].ToString(), RouteData.Values["action"].ToString(), TempData["Message"].ToString(), model.Id.ToString(), "Delete", model.GatePassCode);

                return Json(new { success = "1", msg = "Deleted Successfully" });

            }

            catch (Exception ex)
            {
                throw ex;
            }
        }


        [HttpGet]
        [AllowAnonymous]
        public IActionResult AddWholeSale()
        {
            ViewBag.ActionType = "Create";
            int saleId = 0;
            //ViewBag.customers = customerRepository.GetAllForDropDown();
            //if (_FromWarehousePermissionRepository.GetAllForDropDown().Count() > 0) { ViewBag.Warehouse = _FromWarehousePermissionRepository.GetAllForDropDown(); } else { ViewBag.Warehouse = _warehouseRepository.GetWarehouseLedgerHeadForDropDown(); }


            var x = _FromWarehousePermissionRepository.GetAllForDropDown();
            if (x.Count() == 0)
            {
                x = _warehouseRepository.GetWarehouseLedgerHeadForDropDown();
            }
            ViewBag.Warehouse = x;
            ViewBag.Category = categoryRepository.GetAllForDropDown();
            ViewBag.Unit = _unitRepository.GetAllForDropDown();
            ViewBag.DocType = _docTypeRepository.GetSalesDocForDropDown();
            ViewBag.SalesRep = _employeeRepository.GetAllForDropDown();
            ViewBag.Currency = _currencyRepository.GetCurrencyList();

            return View(model: saleId);
        }

        [HttpGet]
        [AllowAnonymous]
        public IActionResult AddSaleSerialSide()
        {

            ViewBag.ActionType = "Create";
            int saleId = 0;
            //ViewBag.customers = customerRepository.GetAllForDropDown();
            //if (_FromWarehousePermissionRepository.GetAllForDropDown().Count() > 0) { ViewBag.Warehouse = _FromWarehousePermissionRepository.GetAllForDropDown(); } else { ViewBag.Warehouse = _warehouseRepository.GetWarehouseLedgerHeadForDropDown(); }

            var x = _FromWarehousePermissionRepository.GetAllForDropDown();
            if (x.Count() == 0)
            {
                x = _warehouseRepository.GetWarehouseLedgerHeadForDropDown();
            }
            ViewBag.Warehouse = x;
            ViewBag.Category = categoryRepository.GetAllForDropDown();
            ViewBag.Unit = _unitRepository.GetAllForDropDown();
            ViewBag.DocType = _docTypeRepository.GetSalesDocForDropDown();
            ViewBag.SalesRep = _employeeRepository.GetAllForDropDown();
            ViewBag.Currency = _currencyRepository.GetCurrencyList();

            return View(model: saleId);
        }





        //[HttpPost]
        [AllowAnonymous]
        public JsonResult GetSaleSummaryInfo(string FromDate, string ToDate, int? CustomerId, int? UserId, int? WarehouseId, int? CategoryId, int? DocTypeId)
        {
            try
            {
                var sessionLuserId = (HttpContext.Session.GetInt32("UserId"));

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


                //var saleinfo = saleRepository.All().Where(p => p.SalesDate >= dtFrom && p.SalesDate <= dtTo).SingleOrDefault();


                var saleslist = saleRepository.All().Where(x => x.SalesDate >= dtFrom && x.SalesDate <= dtTo).Where(x => x.DocTypeList.DocType == "Sales"); //  && x.DocTypeList.DocType == "Sales"
                var salespaymentlist = salesPaymentRepository.All().Include(x => x.SalesMain).ThenInclude(x => x.CustomerModel).Where(x => x.SalesMain.SalesDate >= dtFrom && x.SalesMain.SalesDate <= dtTo && x.SalesMain.IsDelete == false).Where(p => p.SalesMain.DocTypeList.DocType == "Sales");
                var salesitemlist = saleItemRepository.All().Where(x => x.SalesModel.SalesDate >= dtFrom && x.SalesModel.SalesDate <= dtTo && x.SalesModel.IsDelete == false).Where(x => x.SalesModel.DocTypeList.DocType == "Sales");

                var daywisesalescount = saleRepository.All().Where(x => x.DocTypeList.DocType == "Sales")
                .Where(x => x.SalesDate >= DateTime.Now.Date.AddDays(-7) && x.SalesDate <= DateTime.Now.Date.AddDays(-1))
                .GroupBy(x => new { x.ComId, x.SalesDate })
                .Select(g => new { SalesDate = g.Key.SalesDate.ToString("dd-MMM-yy"), TotalSalesCount = g.Count(), TotalSalesSum = g.Sum(x => x.NetAmount) }).ToList();


                int? vatview = HttpContext.Session.GetInt32("VatViewActivate");
                if (vatview == null || vatview == 0)
                {

                }
                else
                {
                    saleslist = saleslist.Where(x => x.IsVatSales == true);
                    salespaymentlist = salespaymentlist.Where(x => x.SalesMain.IsVatSales == true);
                    salesitemlist = salesitemlist.Where(x => x.SalesModel.IsVatSales == true);

                    daywisesalescount = saleRepository.All().Where(x => x.DocTypeList.DocType == "Sales" && x.IsVatSales == true)
                   .Where(x => x.SalesDate >= DateTime.Now.Date.AddDays(-7) && x.SalesDate <= DateTime.Now.Date.AddDays(-1))
                   .GroupBy(x => new { x.ComId, x.SalesDate })
                   .Select(g => new { SalesDate = g.Key.SalesDate.ToString("dd-MMM-yy"), TotalSalesCount = g.Count(), TotalSalesSum = g.Sum(x => x.NetAmount) }).ToList();

                }



                if (CustomerId != null)
                {
                    saleslist = saleslist.Where(p => p.CustomerId == CustomerId);
                    salespaymentlist = salespaymentlist.Where(p => p.SalesMain.CustomerId == CustomerId);
                    salesitemlist = salesitemlist.Where(p => p.SalesModel.CustomerId == CustomerId);
                }

                if (CategoryId != null)
                {
                    saleslist = saleslist.Where(p => p.Items.Any(x => x.Product.CategoryId == CategoryId));
                    salespaymentlist = salespaymentlist.Where(p => p.SalesMain.Items.Any(x => x.Product.CategoryId == CategoryId));
                    salesitemlist = salesitemlist.Where(p => p.Product.CategoryId == CategoryId);
                }

                if (UserId != null)
                {
                    saleslist = saleslist.Where(p => p.LuserId == UserId);
                    salespaymentlist = salespaymentlist.Where(p => p.SalesMain.LuserId == UserId);
                    salesitemlist = salesitemlist.Where(p => p.SalesModel.LuserId == UserId);
                }

                //if (DocTypeId != null)
                //{
                //    saleslist = saleslist.Where(p => p.DocTypeId == DocTypeId);
                //    //salespaymentlist = salespaymentlist.Where(p => p.SalesMain.DocTypeList.DocType == "Sales");
                //    salesitemlist = salesitemlist.Where(p => p.SalesModel.DocTypeId == DocTypeId);
                //}


                if (WarehouseId != null)
                {
                    saleslist = saleslist.Where(p => p.WarehouseIdMain == WarehouseId);
                    salespaymentlist = salespaymentlist.Where(p => p.SalesMain.WarehouseIdMain == WarehouseId);
                    salesitemlist = salesitemlist.Where(p => p.SalesModel.WarehouseIdMain == WarehouseId);
                }
                else
                {
                    var arrayabc = _FromWarehousePermissionRepository.All().Where(x => x.LuserIdAllow == sessionLuserId).Select(x => x.WarehouseId).ToList();
                    //int a = 1;
                    //List<int> IDs = new List<int> { 1, 3, 4, 8 };

                    //var warehouselist = _FromWarehousePermissionRepository.All().Select(x => x.Id);
                    if (arrayabc.Count() > 0)
                    {
                        //saleslist = saleslist.Where(p => arrayabc.Contains(p.WarehouseIdMain));

                        saleslist = saleslist.Where(p => arrayabc.Contains(p.WarehouseIdMain));
                        salespaymentlist = salespaymentlist.Where(p => arrayabc.Contains(p.SalesMain.WarehouseIdMain));
                        salesitemlist = salesitemlist.Where(p => arrayabc.Contains(p.SalesModel.WarehouseIdMain));

                    }
                }



                var totalsalessummary = saleslist //.GroupBy(p => p.vPaymentType.TypeName);
                .GroupBy(x => new { x.ComId })
                .Select(g => new { TotalSalesCount = g.Count(), TotalSalesValue = g.Sum(x => x.NetAmount), TotalCosting = g.Sum(x => x.FinalCostingPrice), TotalDiscount = g.Sum(x => x.Discount), TotalProfit = g.Sum(x => x.Profit) });//g.Sum(x => x.Profit) //g.Sum(x => x.NetAmount) - g.Sum(x => x.FinalCostingPrice) 



                var salesbyuser = saleslist //.GroupBy(p => p.vPaymentType.TypeName);
                .GroupBy(x => new { x.UserAccountList.Name })
                .Select(g => new { UserName = g.Key.Name, TotalSalesCount = g.Count(), TotalSalesSum = g.Sum(x => x.NetAmount) }).ToList();


                var commissionbyuser = saleslist //.GroupBy(p => p.vPaymentType.TypeName);
                .GroupBy(x => new { x.UserAccountList.Name })
                .Select(g => new { UserName = g.Key.Name, TotalSalesCount = g.Count(), TotalCommissionAmount = g.Sum(x => x.TotalCommisionAmount) }).ToList();


                var salesreceivebyhead = salespaymentlist.GroupBy(x => new { x.vChartofAccounts.AccName })
                .Select(g => new { AccName = g.Key.AccName, Amount = g.Sum(x => x.Amount) }).ToList();


                var totalreceivedamount = salespaymentlist.Sum(x => x.Amount);
                var totalsales = saleslist.Sum(x => x.GrandTotal);
                salesreceivebyhead.Add(new
                {
                    AccName = "Due",
                    Amount = (totalsales - totalreceivedamount)
                });




                var topsellingitem = salesitemlist //.GroupBy(p => p.vPaymentType.TypeName);
                 .GroupBy(x => new { x.Product.Name })
                 .Select(g => new { ProductName = g.Key.Name, ProductCount = g.Sum(x => x.Quantity) }).ToList().OrderByDescending(x => x.ProductCount).Take(5);



                var topsellingcustomer = saleslist.Include(x => x.CustomerModel)//.GroupBy(p => p.vPaymentType.TypeName);
                 .GroupBy(x => new { walkincustomer = x.CustomerName, CustomerName = x.CustomerModel.Name })
                 .Select(g => new { CustomerName = g.Key.CustomerName.ToLower().Contains("customer") ? g.Key.walkincustomer : g.Key.CustomerName, SalesAmount = g.Sum(x => x.GrandTotal) }).ToList().OrderByDescending(x => x.SalesAmount).Take(5);


                //var topduecustomer = saleRepository.All().Include(x => x.CustomerModel).Include(x => x.SalesPayments).Where(x => x.SalesDate >= dtFrom && x.SalesDate <= dtTo)
                ////.Select(x => new { walkintcustomer = x.CustomerName, customername = x.CustomerModel.Name , DueAmount = x.GrandTotal - x.SalesPayments.Sum(x=>x.Amount) })  //.GroupBy(p => p.vPaymentType.TypeName);
                //.GroupBy(x => new { walkintcustomer =  x.CustomerName, CustomerName = x.CustomerModel.Name })
                //.Select(g => new { CustomerName = g.Key.CustomerName + " " + g.Key.walkintcustomer, DueAmount = g.Sum(x => x.GrandTotal - x.SalesPayments.Sum(x => x.Amount)) })
                //.ToList();//.OrderByDescending(x => x.DueAmount).Take(5);


                var topduecustomer = salespaymentlist
                .GroupBy(x => new { walkincustomer = x.SalesMain.CustomerName, CustomerName = x.SalesMain.CustomerModel.Name, GradnTotal = x.SalesMain.GrandTotal })
                .Select(g => new { CustomerName = g.Key.CustomerName.ToLower().Contains("customer") ? g.Key.walkincustomer : g.Key.CustomerName, TotalSales = g.Key.GradnTotal, ReceivedAmount = g.Sum(x => x.Amount) })
                .Where(x => (x.TotalSales - x.ReceivedAmount > 0))
                .ToList().OrderByDescending(x => x.TotalSales - x.ReceivedAmount)
                .Take(5).ToList();

                // var topduecustomermore = saleslist.Include(x => x.SalesPayments).Include(x => x.CustomerModel).Where(x => x.SalesPayments.Count() == 0)
                //.GroupBy(x => new { walkincustomer = x.CustomerName, CustomerName = x.CustomerModel.Name, GradnTotal = x.GrandTotal })
                //.Select(g => new { CustomerName = g.Key.CustomerName.ToLower().Contains("customer") ? g.Key.walkincustomer : g.Key.CustomerName, TotalSales = g.Sum(x => g.Key.GradnTotal), ReceivedAmount = decimal.Parse("0") })
                //.Where(x => (x.TotalSales - x.ReceivedAmount > 0))
                //.ToList().OrderByDescending(x => x.TotalSales - x.ReceivedAmount)
                //.Take(5).ToList();

                // foreach (var item in topduecustomermore)
                // {
                //     topduecustomer.Add(item);
                // }


                var postunpostcount = saleslist //.GroupBy(p => p.vPaymentType.TypeName);
                .GroupBy(x => new { isPosted = x.isPosted })
                .Select(g => new { isPosted = g.Key.isPosted, DocCount = g.Count() }).ToList();


                var sellingitembycategory = salesitemlist //.GroupBy(p => p.vPaymentType.TypeName);
                .GroupBy(x => new { CategoryName = x.Product.Category.Name })
                //.Select(g => new { CategoryName = g.Key.CategoryName, CategoryCount = g.Sum(x => x.Quantity), TotalProfitAvgCost = g.Sum(x => x.Price * x.Quantity) - g.Sum(x => x.IndDiscountProportion * x.Quantity) - g.Sum(x => x.AvgCostPrice), TotalProfit = g.Sum(x => x.Price * x.Quantity) - g.Sum(x => x.IndDiscountProportion * x.Quantity) - g.Sum(x => x.CostPrice * x.Quantity), TotalSales = g.Sum(x => x.Price * x.Quantity) - g.Sum(x => x.IndDiscountProportion * x.Quantity) }) ///g.Sum(x=>x.SalesModel.DisAmt
                .Select(g => new { CategoryName = g.Key.CategoryName, CategoryCount = g.Sum(x => x.Quantity), TotalProfitAvgCost = g.Sum(x => x.Price * x.Quantity) - g.Sum(x => x.IndDiscountProportion) - g.Sum(x => x.IndDiscount * x.Quantity) - g.Sum(x => x.AvgCostPrice * x.Quantity), TotalProfit = g.Sum(x => x.Price * x.Quantity) - g.Sum(x => x.IndDiscountProportion) - g.Sum(x => x.CostPrice * x.Quantity), TotalSales = g.Sum(x => x.Price * x.Quantity) - g.Sum(x => x.IndDiscountProportion) }) ///g.Sum(x=>x.SalesModel.DisAmt

                .OrderByDescending(x => x.TotalSales);//.Take(10);


                //var topsellingproduct = (from product in productRepository.All()
                //        from orderedProduct in saleItemRepository.All()
                //        where orderedProduct.ProductId == product.Id
                //        group orderedProduct by product into productGroups
                //        select new
                //        {
                //            product = productGroups.Key,
                //            numberOfOrders = productGroups.Count()
                //        }
                //     ).OrderByDescending(x => x.numberOfOrders).Distinct().Take(10);



                //var query = (from p in productRepository.All()
                //let totalQuantity = (from op in saleItemRepository.All().ToList()
                //                     join o in saleRepository.All().ToList() on op.SalesId equals o.Id
                //                     where op.ProductId == p.Id && o.SalesDate >= dtFrom && o.SalesDate <= dtTo
                //                     select op.Quantity).Sum()
                //where totalQuantity > 0
                //orderby totalQuantity descending
                //select p).Take(10);


                //return Json(totalsalessummary);

                var genericResult = new
                {
                    totalsalessummary = totalsalessummary,
                    salesbyuser = salesbyuser,
                    salesreceivebyhead = salesreceivebyhead,
                    commissionbyuser = commissionbyuser,
                    topsellingitem = topsellingitem,
                    topsellingcustomer = topsellingcustomer,
                    topduecustomer = topduecustomer,
                    postunpostcount = postunpostcount,
                    sellingitembycategory = sellingitembycategory,
                    daywisesalescount = daywisesalescount
                };
                return Json(genericResult);

            }
            catch (Exception ex)
            {
                return Json(new { success = false, values = ex.Message.ToString() });
            }
        }







        [AllowAnonymous]
        public JsonResult GetSalesDetailsSummaryInfo(string FromDate, string ToDate, int? CustomerId, int? UserId, int? WarehouseId, int? CategoryId, int? DocTypeId)
        {
            try
            {
                var sessionLuserId = (HttpContext.Session.GetInt32("UserId"));

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

                ViewBag.FromDate = dtFrom;
                ViewBag.ToDate = dtTo;


                var saleslist = saleRepository.All().Where(x => x.SalesDate >= dtFrom && x.SalesDate <= dtTo).Where(x => x.DocTypeList.DocType == "Sales"); //  && x.DocTypeList.DocType == "Sales"
                var salespaymentlist = salesPaymentRepository.All().Include(x => x.SalesMain).ThenInclude(x => x.CustomerModel).Where(x => x.SalesMain.SalesDate >= dtFrom && x.SalesMain.SalesDate <= dtTo && x.SalesMain.IsDelete == false).Where(p => p.SalesMain.DocTypeList.DocType == "Sales");
                var salesitemlist = saleItemRepository.All().Where(x => x.SalesModel.SalesDate >= dtFrom && x.SalesModel.SalesDate <= dtTo && x.SalesModel.IsDelete == false).Where(x => x.SalesModel.DocTypeList.DocType == "Sales");

                var daywisesalescount = saleRepository.All().Where(x => x.DocTypeList.DocType == "Sales")
                .Where(x => x.SalesDate >= DateTime.Now.Date.AddDays(-7) && x.SalesDate <= DateTime.Now.Date.AddDays(-1))
                .GroupBy(x => new { x.ComId, x.SalesDate })
                .Select(g => new { SalesDate = g.Key.SalesDate.ToString("dd-MMM-yy"), TotalSalesCount = g.Count(), TotalSalesSum = g.Sum(x => x.NetAmount) }).ToList();


                int? vatview = HttpContext.Session.GetInt32("VatViewActivate");
                if (vatview == null || vatview == 0)
                {

                }
                else
                {
                    saleslist = saleslist.Where(x => x.IsVatSales == true);
                    salespaymentlist = salespaymentlist.Where(x => x.SalesMain.IsVatSales == true);
                    salesitemlist = salesitemlist.Where(x => x.SalesModel.IsVatSales == true);

                    daywisesalescount = saleRepository.All().Where(x => x.DocTypeList.DocType == "Sales" && x.IsVatSales == true)
                   .Where(x => x.SalesDate >= DateTime.Now.Date.AddDays(-7) && x.SalesDate <= DateTime.Now.Date.AddDays(-1))
                   .GroupBy(x => new { x.ComId, x.SalesDate })
                   .Select(g => new { SalesDate = g.Key.SalesDate.ToString("dd-MMM-yy"), TotalSalesCount = g.Count(), TotalSalesSum = g.Sum(x => x.NetAmount) }).ToList();

                }



                if (CustomerId != null)
                {
                    saleslist = saleslist.Where(p => p.CustomerId == CustomerId);
                    salespaymentlist = salespaymentlist.Where(p => p.SalesMain.CustomerId == CustomerId);
                    salesitemlist = salesitemlist.Where(p => p.SalesModel.CustomerId == CustomerId);
                }

                if (CategoryId != null)
                {
                    saleslist = saleslist.Where(p => p.Items.Any(x => x.Product.CategoryId == CategoryId));
                    salespaymentlist = salespaymentlist.Where(p => p.SalesMain.Items.Any(x => x.Product.CategoryId == CategoryId));
                    salesitemlist = salesitemlist.Where(p => p.Product.CategoryId == CategoryId);
                }

                if (UserId != null)
                {
                    saleslist = saleslist.Where(p => p.LuserId == UserId);
                    salespaymentlist = salespaymentlist.Where(p => p.SalesMain.LuserId == UserId);
                    salesitemlist = salesitemlist.Where(p => p.SalesModel.LuserId == UserId);
                }


                if (WarehouseId != null)
                {
                    saleslist = saleslist.Where(p => p.WarehouseIdMain == WarehouseId);
                    salespaymentlist = salespaymentlist.Where(p => p.SalesMain.WarehouseIdMain == WarehouseId);
                    salesitemlist = salesitemlist.Where(p => p.SalesModel.WarehouseIdMain == WarehouseId);
                }
                else
                {
                    var arrayabc = _FromWarehousePermissionRepository.All().Where(x => x.LuserIdAllow == sessionLuserId).Select(x => x.WarehouseId).ToList();
                    //int a = 1;
                    //List<int> IDs = new List<int> { 1, 3, 4, 8 };

                    //var warehouselist = _FromWarehousePermissionRepository.All().Select(x => x.Id);
                    if (arrayabc.Count() > 0)
                    {
                        //saleslist = saleslist.Where(p => arrayabc.Contains(p.WarehouseIdMain));

                        saleslist = saleslist.Where(p => arrayabc.Contains(p.WarehouseIdMain));
                        salespaymentlist = salespaymentlist.Where(p => arrayabc.Contains(p.SalesMain.WarehouseIdMain));
                        salesitemlist = salesitemlist.Where(p => arrayabc.Contains(p.SalesModel.WarehouseIdMain));

                    }
                }



                var totalsalessummary = saleslist //.GroupBy(p => p.vPaymentType.TypeName);
                .GroupBy(x => new { x.ComId })
                .Select(g => new { TotalSalesCount = g.Count(), TotalSalesValue = g.Sum(x => x.NetAmount), TotalCosting = g.Sum(x => x.FinalCostingPrice), TotalDiscount = g.Sum(x => x.Discount), TotalProfit = g.Sum(x => x.Profit) });//g.Sum(x => x.Profit) //g.Sum(x => x.NetAmount) - g.Sum(x => x.FinalCostingPrice) 



                var salesbyuser = saleslist //.GroupBy(p => p.vPaymentType.TypeName);
                .GroupBy(x => new { x.UserAccountList.Name })
                .Select(g => new { UserName = g.Key.Name, TotalSalesCount = g.Count(), TotalSalesSum = g.Sum(x => x.NetAmount) }).ToList();


                var commissionbyuser = saleslist //.GroupBy(p => p.vPaymentType.TypeName);
                .GroupBy(x => new { x.UserAccountList.Name })
                .Select(g => new { UserName = g.Key.Name, TotalSalesCount = g.Count(), TotalCommissionAmount = g.Sum(x => x.TotalCommisionAmount) }).ToList();


                var salesreceivebyhead = salespaymentlist.GroupBy(x => new { x.vChartofAccounts.AccName })
                .Select(g => new { AccName = g.Key.AccName, Amount = g.Sum(x => x.Amount) }).ToList();


                var totalreceivedamount = salespaymentlist.Sum(x => x.Amount);
                var totalsales = saleslist.Sum(x => x.GrandTotal);
                salesreceivebyhead.Add(new
                {
                    AccName = "Due",
                    Amount = (totalsales - totalreceivedamount)
                });




                var topsellingitem = salesitemlist //.GroupBy(p => p.vPaymentType.TypeName);
                 .GroupBy(x => new { x.Product.Name })
                 .Select(g => new { ProductName = g.Key.Name, ProductCount = g.Sum(x => x.Quantity) }).ToList().OrderByDescending(x => x.ProductCount).Take(5);



                var topsellingcustomer = saleslist.Include(x => x.CustomerModel)//.GroupBy(p => p.vPaymentType.TypeName);
                 .GroupBy(x => new { walkincustomer = x.CustomerName, CustomerName = x.CustomerModel.Name })
                 .Select(g => new { CustomerName = g.Key.CustomerName.ToLower().Contains("customer") ? g.Key.walkincustomer : g.Key.CustomerName, SalesAmount = g.Sum(x => x.GrandTotal) }).ToList().OrderByDescending(x => x.SalesAmount).Take(5);




                var topduecustomer = salespaymentlist
                .GroupBy(x => new { walkincustomer = x.SalesMain.CustomerName, CustomerName = x.SalesMain.CustomerModel.Name, GradnTotal = x.SalesMain.GrandTotal })
                .Select(g => new { CustomerName = g.Key.CustomerName.ToLower().Contains("customer") ? g.Key.walkincustomer : g.Key.CustomerName, TotalSales = g.Key.GradnTotal, ReceivedAmount = g.Sum(x => x.Amount) })
                .Where(x => (x.TotalSales - x.ReceivedAmount > 0))
                .ToList().OrderByDescending(x => x.TotalSales - x.ReceivedAmount)
                .Take(5).ToList();

                var topduecustomermore = saleslist.Include(x => x.SalesPayments).Include(x => x.CustomerModel).Where(x => x.SalesPayments.Count() == 0)
               .GroupBy(x => new { walkincustomer = x.CustomerName, CustomerName = x.CustomerModel.Name, GradnTotal = x.GrandTotal })
               .Select(g => new { CustomerName = g.Key.CustomerName.ToLower().Contains("customer") ? g.Key.walkincustomer : g.Key.CustomerName, TotalSales = g.Sum(x => g.Key.GradnTotal), ReceivedAmount = decimal.Parse("0") })
               .Where(x => (x.TotalSales - x.ReceivedAmount > 0))
               .ToList().OrderByDescending(x => x.TotalSales - x.ReceivedAmount)
               .Take(5).ToList();

                foreach (var item in topduecustomermore)
                {
                    topduecustomer.Add(item);
                }


                var postunpostcount = saleslist //.GroupBy(p => p.vPaymentType.TypeName);
                .GroupBy(x => new { isPosted = x.isPosted })
                .Select(g => new { isPosted = g.Key.isPosted, DocCount = g.Count() }).ToList();


                var sellingitembycategory = salesitemlist //.GroupBy(p => p.vPaymentType.TypeName);
                .GroupBy(x => new { CategoryName = x.Product.Category.Name })
                //.Select(g => new { CategoryName = g.Key.CategoryName, CategoryCount = g.Sum(x => x.Quantity), TotalProfitAvgCost = g.Sum(x => x.Price * x.Quantity) - g.Sum(x => x.IndDiscountProportion * x.Quantity) - g.Sum(x => x.AvgCostPrice), TotalProfit = g.Sum(x => x.Price * x.Quantity) - g.Sum(x => x.IndDiscountProportion * x.Quantity) - g.Sum(x => x.CostPrice * x.Quantity), TotalSales = g.Sum(x => x.Price * x.Quantity) - g.Sum(x => x.IndDiscountProportion * x.Quantity) }) ///g.Sum(x=>x.SalesModel.DisAmt
                .Select(g => new { CategoryName = g.Key.CategoryName, CategoryCount = g.Sum(x => x.Quantity), TotalProfitAvgCost = g.Sum(x => x.Price * x.Quantity) - g.Sum(x => x.IndDiscountProportion) - g.Sum(x => x.IndDiscount * x.Quantity) - g.Sum(x => x.AvgCostPrice * x.Quantity), TotalProfit = g.Sum(x => x.Price * x.Quantity) - g.Sum(x => x.IndDiscountProportion) - g.Sum(x => x.CostPrice * x.Quantity), TotalSales = g.Sum(x => x.Price * x.Quantity) - g.Sum(x => x.IndDiscountProportion) }) ///g.Sum(x=>x.SalesModel.DisAmt

                .OrderByDescending(x => x.TotalSales);//.Take(10);


                var genericResult = new
                {
                    totalsalessummary = totalsalessummary,
                    salesbyuser = salesbyuser,
                    salesreceivebyhead = salesreceivebyhead,
                    commissionbyuser = commissionbyuser,
                    topsellingitem = topsellingitem,
                    topsellingcustomer = topsellingcustomer,
                    topduecustomer = topduecustomer,
                    postunpostcount = postunpostcount,
                    sellingitembycategory = sellingitembycategory,
                    daywisesalescount = daywisesalescount
                };
                return Json(genericResult);

            }
            catch (Exception ex)
            {
                return Json(new { success = false, values = ex.Message.ToString() });
            }
        }





        [AllowAnonymous]
        public IActionResult GetSalesListByPage(int? UserId, string Status, int? WarehouseId, int? IsPosted, int? CustomerId, int? CategoryId, int? DocTypeId, int pageNo = 1, decimal pageSize = 10, string searchquery = "", string FromDate = "", string ToDate = "")
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


                var saleslist = saleRepository.All();
                if (vatview == null || vatview == 0) { }
                else { saleslist = saleslist.Where(x => x.IsVatSales == true); }
                var saleslistDateWise = saleslist;



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
                        saleslist = saleslist.Where(x => x.NetAmount.ToString() == searchitem.NetAmount); // || x.Code.ToLower().Contains(searchitem.Name.ToLower())

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
                    saleslistDateWise = saleslistDateWise.Where(p => (p.SalesDate >= dtFrom && p.SalesDate <= dtTo));

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

                    saleslistDateWise = saleslistDateWise.Where(p => (p.SalesDate >= dtFrom && p.SalesDate <= dtTo));

                    saleslistDateWise = saleslistDateWise.Where(p => p.LuserId == sessionLuserId);

                }

                if (CustomerId != null)
                {
                    saleslistDateWise = saleslistDateWise.Where(p => p.CustomerId == CustomerId);
                }
                if (CategoryId != null)
                {
                    saleslistDateWise = saleslistDateWise.Where(p => p.Items.Any(x => x.Product.CategoryId == CategoryId));
                }
                if (DocTypeId != null)
                {
                    saleslistDateWise = saleslistDateWise.Where(p => p.DocTypeId == DocTypeId);
                }
                if (UserId != null)
                {
                    saleslistDateWise = saleslistDateWise.Where(p => p.LuserId == UserId);
                }
                else
                {
                    if (UserRole == "Admin" || UserRole == "SuperAdmin")
                    {
                    }
                    else
                    {
                        //var storesettings = storeSettingRepository.All().FirstOrDefault();
                        //if (storesettings.isBackDatePermission == true)
                        //{
                        //    dtTo = Convert.ToDateTime(DateTime.Now.Date);
                        //    DateTime dtFromwithprevdate = Convert.ToDateTime(DateTime.Now.Date.AddDays(-storesettings.Days));

                        //    if (dtFrom < dtFromwithprevdate)
                        //    {
                        //        dtFrom = dtFromwithprevdate;
                        //    }
                        //}


                        saleslistDateWise = saleslistDateWise.Where(p => p.LuserId == sessionLuserId);

                    }

                }
                if (WarehouseId != null)
                {
                    saleslistDateWise = saleslistDateWise.Where(p => p.WarehouseIdMain == WarehouseId);
                }
                else
                {
                    var arrayabc = _FromWarehousePermissionRepository.All().Where(x => x.LuserIdAllow == sessionLuserId).Select(x => x.WarehouseId).ToList();
                    //int a = 1;
                    //List<int> IDs = new List<int> { 1, 3, 4, 8 };

                    //var warehouselist = _FromWarehousePermissionRepository.All().Select(x=>x.Id);
                    if (arrayabc.Count() > 0)
                    {
                        saleslistDateWise = saleslistDateWise.Where(p => arrayabc.Contains(p.WarehouseIdMain));
                    }
                }


                if (Status == "Due")
                {
                    //var saleslistmore = saleslist.Where(x => x.GrandTotal -  x.SalesPayments.Sum(x=>x.Amount) > 0);

                    saleslist = saleslist.Where(x => x.DocTypeList.DocType != "Quotation" && x.NetAmount - x.SalesPayments.Sum(x => x.Amount) != 0);


                    saleslistDateWise = saleslist;
                    //saleslist = saleslist.Where(x=>x.SalesPayments.Count == 0);



                }
                else if (Status == "Date Wise Due")
                {
                    saleslistDateWise = saleslistDateWise.Where(x => x.DocTypeList.DocType != "Quotation" && x.NetAmount - x.SalesPayments.Sum(x => x.Amount) != 0);

                }
                else if (Status == "Cash Discount")
                {
                    saleslist = saleslist.Where(x => x.SalesPayments.Where(x => x.vChartofAccounts.AccName.ToUpper().Contains("Discount".ToUpper())).Sum(x => x.Amount) != 0);
                    saleslistDateWise = saleslist;

                }
                else if (Status == "Date Wise Cash Discount")
                {
                    saleslistDateWise = saleslistDateWise.Where(x => x.SalesPayments.Where(x => x.vChartofAccounts.AccName.ToUpper().Contains("Discount".ToUpper())).Sum(x => x.Amount) != 0);
                }
                else if (Status == "Missing Head")
                {
                    saleslist = saleslist.Where(x => x.SalesPayments.Where(x => x.vChartofAccounts == null).Sum(x => x.Amount) != 0);
                    saleslistDateWise = saleslist;
                }





                if (TimeZoneSettingsName.Length > 3)
                {
                    var localtime = TimeZoneInfo.ConvertTime(DateTime.Now, TimeZoneInfo.FindSystemTimeZoneById(TimeZoneSettingsName));
                    ViewBag.FromDate = localtime.Date.ToString("dd-MMM-yyyy");

                }




                decimal TotalRecordCount = saleslist.Count();
                var PageCountabc = decimal.Parse((TotalRecordCount / pageSize).ToString());
                var PageCount = Math.Ceiling(PageCountabc);





                decimal skip = (pageNo - 1) * pageSize;

                // Get total number of records
                int total = saleslist.Count();


                var query = from e in saleslistDateWise.Include(x => x.Items)
                            .ThenInclude(x => x.Product).ThenInclude(x => x.Category)
                            .Include(x => x.SalesPayments).ThenInclude(x => x.vChartofAccounts)
                            .Include(x => x.SalesPayments).ThenInclude(x => x.Transaction)
                            .Include(x => x.SalesReturn).ThenInclude(x => x.SalesReturnPayments)
                            .Include(x => x.DocTypeList)


                            select new SalesResultList
                            {
                                Id = e.Id,
                                SaleCode = e.SaleCode,
                                SalesDate = e.SalesDate,
                                SalesDateString = e.SalesDate.ToString("dd-MMM-yy"),
                                EntryTimeString = TimeZoneSettingsName.Length > 3 ? TimeZoneInfo.ConvertTime(e.CreateDate, TimeZoneInfo.FindSystemTimeZoneById(TimeZoneSettingsName)).ToString("HH:mm") : e.CreateDate.ToString("HH:mm"),
                                SalesUser = e.UserAccountList.Name,

                                CustomerName = (e.CustomerName.Length == 0 || e.CustomerName == null) ? e.CustomerModel.Name : e.CustomerName,
                                //CustomerName = e.CustomerName,
                                PrimaryAddress = e.PrimaryAddress,
                                SecoundaryAddress = e.SecoundaryAddress,
                                Notes = e.Notes,
                                PhoneNo = e.PhoneNo,
                                Discount = e.Discount,

                                CustomerCommissionAmount = e.CustomerCommissionAmount,
                                SRCommissionAmount = e.SRCommissionAmount,



                                Total = e.Total,
                                StatusRemarks = e.StatusRemarks,
                                NetAmount = e.NetAmount,
                                ServiceCharge = e.ServiceCharge,
                                TotalVat = e.TotalVat,
                                Shipping = e.Shipping,
                                DocType = e.DocTypeList.DocType,
                                //TransactionCode = e.AccountTransaction.,



                                isPOSSales = e.isPOSSales,
                                isSerialSales = e.isSerialSales,
                                isPosted = e.isPosted,
                                FinalCostingPrice = e.FinalCostingPrice,
                                Profit = e.Profit,
                                ProfitPercentage = e.ProfitPercentage,
                                Location = e.Warehouses.WhShortName,
                                StatusPosted = e.isPosted != false ? "Posted" : "Not Posted",
                                PaidAmt = e.SalesPayments.Sum(x => x.Amount),// e.PaidAmt,
                                                                             //ReceivingHead = e.CreditAccount != null ? e.CreditAccount.AccName : "=N/A="
                                                                             //SalesPayments = e.SalesPayments.ToList(),
                                SalesReturnPayments = e.SalesReturn.FirstOrDefault().SalesReturnPayments.Sum(x => x.Amount),
                                SalesReturnAmount = e.SalesReturn.Sum(x => x.NetAmount),
                                SalesPayments = e.SalesPayments.Select(x => new
                                {
                                    x.SalesId,
                                    x.PaymentCardNo,
                                    x.isPosted,
                                    x.Amount,
                                    x.RowNo,
                                    x.AccountHeadId,
                                    AccType = x.vChartofAccounts.AccType,
                                    AccName = x.vChartofAccounts.AccName,
                                    TransactionCode = x.Transaction.TransactionCode
                                }),
                                SalesItems = e.Items.Select(x => new
                                {
                                    x.Id,
                                    CategoryName = x.Product.Category.Name,
                                    ProductCode = x.Product.Code,
                                    ProductName = x.Product.Name,

                                    BatchSerial = x.BatchSerialItems.Select(x => new
                                    {
                                        BatchSerialNo = x.PurchaseBatchItems.BatchSerialNo
                                    }),

                                    Price = x.Price,
                                    CostPrice = x.CostPrice,
                                    AvgCostPrice = x.AvgCostPrice,
                                    IndDiscountProportion = x.IndDiscountProportion,
                                    Quantity = x.Quantity,
                                    //ProfitPer = x.profit,
                                    CommissionAmount = x.CommissionAmount

                                })
                                //Items = e.Items
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

        public class SalesFilterData
        {
            public int SalesId { get; set; }
            public int UserList { get; set; }

            public string? SaleCode { get; set; }
            public string? DocTypeName { get; set; }

            public string? SalesDate { get; set; }
            public string? NetAmount { get; set; }
            public int? pageIndex { get; set; }
            public int? pageSize { get; set; }

        }


        [AllowAnonymous]
        public IActionResult GetSalesList(string FromDate, string ToDate, int? CustomerId, int? UserId, string Status, int? WarehouseId, int? CategoryId, int? DocTypeId)
        //public IActionResult GetSalesList(int? UserId, string Status, int? WarehouseId, int? IsPosted, int? CustomerId, int? CategoryId, int? DocTypeId, int pageNo = 1, decimal pageSize = 10, string searchquery = "", string FromDate = "", string ToDate = "")
        {
            try
            {
                var ComId = (HttpContext.Session.GetInt32("ComId"));
                var sessionLuserId = (HttpContext.Session.GetInt32("UserId"));
                var UserRole = HttpContext.Session.GetString("UserRole");
                int? vatview = HttpContext.Session.GetInt32("VatViewActivate");

                var TimeZoneSettingsName = HttpContext.Session.GetString("TimeZoneSettingsName");





                //DateTime dateNow = DateTime.Now;
                //Console.WriteLine("The date and time are {0} UTC.",
                //                   TimeZoneInfo.ConvertTimeToUtc(dateNow));


                //var utctime = TimeZoneInfo.ConvertTimeToUtc(dateNow);

                ///////timezone work
                /////

                //TimeZoneInfo localZone = TimeZoneInfo.Local;
                //Console.WriteLine("Local Time Zone ID: {0}", localZone.Id);
                //Console.WriteLine("   Display Name is: {0}.", localZone.DisplayName);
                //Console.WriteLine("   Standard name is: {0}.", localZone.StandardName);
                //Console.WriteLine("   Daylight saving name is: {0}.", localZone.DaylightName);

                //var TimeZoneSettingsId = HttpContext.Session.GetString("TimeZoneSettingsName"); //string timezonename =  _timeZoneSettingsRepository.All().Where(x=>x.Id ==  TimeZoneSettingsId).FirstOrDefault().TimeZoneName;






                //TimeZoneInfo tzi = TimeZoneInfo.FindSystemTimeZoneById(TimeZoneSettingsName);
                //TimeSpan offset = tzi.GetUtcOffset(DateTime.Now.Date);





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

                var saleslist = saleRepository.All();
                if (vatview == null || vatview == 0) { }
                else { saleslist = saleslist.Where(x => x.IsVatSales == true); }
                var saleslistDateWise = saleslist;





                if (y.ToString().Length > 0)
                {


                }
                else
                {
                    if (UserRole == "Admin" || UserRole == "SuperAdmin")
                    {
                        saleslistDateWise = saleslistDateWise.Where(p => (p.SalesDate >= dtFrom && p.SalesDate <= dtTo));

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

                        saleslistDateWise = saleslistDateWise.Where(p => (p.SalesDate >= dtFrom && p.SalesDate <= dtTo));

                        saleslistDateWise = saleslistDateWise.Where(p => p.LuserId == sessionLuserId);

                    }

                    if (CustomerId != null)
                    {
                        saleslistDateWise = saleslistDateWise.Where(p => p.CustomerId == CustomerId);
                    }
                    if (CategoryId != null)
                    {
                        saleslistDateWise = saleslistDateWise.Where(p => p.Items.Any(x => x.Product.CategoryId == CategoryId));
                    }
                    if (DocTypeId != null)
                    {
                        saleslistDateWise = saleslistDateWise.Where(p => p.DocTypeId == DocTypeId);
                    }
                    if (UserId != null)
                    {
                        saleslistDateWise = saleslistDateWise.Where(p => p.LuserId == UserId);
                    }
                    else
                    {
                        if (UserRole == "Admin" || UserRole == "SuperAdmin")
                        {
                        }
                        else
                        {
                            //var storesettings = storeSettingRepository.All().FirstOrDefault();
                            //if (storesettings.isBackDatePermission == true)
                            //{
                            //    dtTo = Convert.ToDateTime(DateTime.Now.Date);
                            //    DateTime dtFromwithprevdate = Convert.ToDateTime(DateTime.Now.Date.AddDays(-storesettings.Days));

                            //    if (dtFrom < dtFromwithprevdate)
                            //    {
                            //        dtFrom = dtFromwithprevdate;
                            //    }
                            //}


                            saleslistDateWise = saleslistDateWise.Where(p => p.LuserId == sessionLuserId);

                        }

                    }
                    if (WarehouseId != null)
                    {
                        saleslistDateWise = saleslistDateWise.Where(p => p.WarehouseIdMain == WarehouseId);
                    }
                    else
                    {
                        var arrayabc = _FromWarehousePermissionRepository.All().Where(x => x.LuserIdAllow == sessionLuserId).Select(x => x.WarehouseId).ToList();
                        //int a = 1;
                        //List<int> IDs = new List<int> { 1, 3, 4, 8 };

                        //var warehouselist = _FromWarehousePermissionRepository.All().Select(x=>x.Id);
                        if (arrayabc.Count() > 0)
                        {
                            saleslistDateWise = saleslistDateWise.Where(p => arrayabc.Contains(p.WarehouseIdMain));
                        }
                    }


                    if (Status == "Due")
                    {
                        //var saleslistmore = saleslist.Where(x => x.GrandTotal -  x.SalesPayments.Sum(x=>x.Amount) > 0);

                        saleslist = saleslist.Where(x => x.DocTypeList.DocType != "Quotation" && x.NetAmount - x.SalesPayments.Sum(x => x.Amount) != 0);


                        saleslistDateWise = saleslist;
                        //saleslist = saleslist.Where(x=>x.SalesPayments.Count == 0);



                    }
                    else if (Status == "Date Wise Due")
                    {
                        saleslistDateWise = saleslistDateWise.Where(x => x.DocTypeList.DocType != "Quotation" && x.NetAmount - x.SalesPayments.Sum(x => x.Amount) != 0);

                    }
                    else if (Status == "Cash Discount")
                    {
                        saleslist = saleslist.Where(x => x.SalesPayments.Where(x => x.vChartofAccounts.AccName.ToUpper().Contains("Discount".ToUpper())).Sum(x => x.Amount) != 0);
                        saleslistDateWise = saleslist;

                    }
                    else if (Status == "Date Wise Cash Discount")
                    {
                        saleslistDateWise = saleslistDateWise.Where(x => x.SalesPayments.Where(x => x.vChartofAccounts.AccName.ToUpper().Contains("Discount".ToUpper())).Sum(x => x.Amount) != 0);
                    }
                    else if (Status == "Missing Head")
                    {
                        saleslist = saleslist.Where(x => x.SalesPayments.Where(x => x.vChartofAccounts == null).Sum(x => x.Amount) != 0);
                        saleslistDateWise = saleslist;
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



                if (TimeZoneSettingsName.Length > 3)
                {
                    var localtime = TimeZoneInfo.ConvertTime(DateTime.Now, TimeZoneInfo.FindSystemTimeZoneById(TimeZoneSettingsName));
                    ViewBag.FromDate = localtime.Date.ToString("dd-MMM-yyyy");

                }


                var query = from e in saleslistDateWise.Include(x => x.Items)
                            .ThenInclude(x => x.Product).ThenInclude(x => x.Category)
                            .Include(x => x.SalesPayments).ThenInclude(x => x.vChartofAccounts)
                            .Include(x => x.SalesPayments).ThenInclude(x => x.Transaction)
                            .Include(x => x.SalesReturn).ThenInclude(x => x.SalesReturnPayments)
                            .Include(x => x.DocTypeList)


                            select new SalesResultList
                            {
                                Id = e.Id,
                                SaleCode = e.SaleCode,
                                SalesDate = e.SalesDate,
                                SalesDateString = e.SalesDate.ToString("dd-MMM-yy"),
                                EntryTimeString = TimeZoneSettingsName.Length > 3 ? TimeZoneInfo.ConvertTime(e.CreateDate, TimeZoneInfo.FindSystemTimeZoneById(TimeZoneSettingsName)).ToString("HH:mm") : e.CreateDate.ToString("HH:mm"),
                                SalesUser = e.UserAccountList.Name,

                                CustomerName = (e.CustomerName.Length == 0 || e.CustomerName == null) ? e.CustomerModel.Name : e.CustomerName,
                                //CustomerName = e.CustomerName,
                                PrimaryAddress = e.PrimaryAddress,
                                SecoundaryAddress = e.SecoundaryAddress,
                                Notes = e.Notes,
                                PhoneNo = e.PhoneNo,
                                Discount = e.Discount,

                                CustomerCommissionAmount = e.CustomerCommissionAmount,
                                SRCommissionAmount = e.SRCommissionAmount,



                                Total = e.Total,
                                StatusRemarks = e.StatusRemarks,
                                NetAmount = e.NetAmount,
                                ServiceCharge = e.ServiceCharge,
                                TotalVat = e.TotalVat,
                                Shipping = e.Shipping,
                                DocType = e.DocTypeList.DocType,
                                //TransactionCode = e.AccountTransaction.,



                                isPOSSales = e.isPOSSales,
                                isSerialSales = e.isSerialSales,
                                isPosted = e.isPosted,
                                FinalCostingPrice = e.FinalCostingPrice,
                                Profit = e.Profit,
                                ProfitPercentage = e.ProfitPercentage,
                                Location = e.Warehouses.WhShortName,
                                StatusPosted = e.isPosted != false ? "Posted" : "Not Posted",
                                PaidAmt = e.SalesPayments.Sum(x => x.Amount),// e.PaidAmt,
                                                                             //ReceivingHead = e.CreditAccount != null ? e.CreditAccount.AccName : "=N/A="
                                                                             //SalesPayments = e.SalesPayments.ToList(),
                                SalesReturnPayments = e.SalesReturn.FirstOrDefault().SalesReturnPayments.Sum(x => x.Amount),
                                SalesReturnAmount = e.SalesReturn.Sum(x => x.NetAmount),
                                SalesPayments = e.SalesPayments.Select(x => new
                                {
                                    x.SalesId,
                                    x.PaymentCardNo,
                                    x.isPosted,
                                    x.Amount,
                                    x.RowNo,
                                    x.AccountHeadId,
                                    AccType = x.vChartofAccounts.AccType,
                                    AccName = x.vChartofAccounts.AccName,
                                    TransactionCode = x.Transaction.TransactionCode
                                }),
                                SalesItems = e.Items.Select(x => new
                                {
                                    x.Id,
                                    CategoryName = x.Product.Category.Name,
                                    ProductCode = x.Product.Code,
                                    ProductName = x.Product.Name,

                                    BatchSerial = x.BatchSerialItems.Select(x => new
                                    {
                                        BatchSerialNo = x.PurchaseBatchItems.BatchSerialNo
                                    }),

                                    Price = x.Price,
                                    CostPrice = x.CostPrice,
                                    AvgCostPrice = x.AvgCostPrice,
                                    IndDiscountProportion = x.IndDiscountProportion,
                                    Quantity = x.Quantity,
                                    //ProfitPer = x.profit,
                                    CommissionAmount = x.CommissionAmount

                                })
                                //Items = e.Items
                            };


                var parser = new Parser<SalesResultList>(Request.Form, query);

                return Json(parser.Parse());


            }
            catch (Exception ex)
            {
                return Json(new { Success = "0", error = ex.Message });
                //throw ex;
            }

        }



        //[AllowAnonymous]
        //public IActionResult GetGatePassList(string FromDate, string ToDate, int? CustomerId, int? UserId, string Status, int? WarehouseId, int? CategoryId, int? DocTypeId)
        //{
        //    try
        //    {
        //        var ComId = (HttpContext.Session.GetInt32("ComId"));
        //        var sessionLuserId = (HttpContext.Session.GetInt32("UserId"));
        //        var UserRole = HttpContext.Session.GetString("UserRole");
        //        int? vatview = HttpContext.Session.GetInt32("VatViewActivate");

        //        var TimeZoneSettingsName = HttpContext.Session.GetString("TimeZoneSettingsName");


        //        DateTime dtFrom = Convert.ToDateTime(DateTime.Now.Date);
        //        DateTime dtTo = Convert.ToDateTime(DateTime.Now.Date);

        //        if (FromDate == null || FromDate == "")
        //        {
        //        }
        //        else
        //        {
        //            dtFrom = Convert.ToDateTime(FromDate);
        //        }
        //        if (ToDate == null || ToDate == "")
        //        {
        //        }
        //        else
        //        {
        //            dtTo = Convert.ToDateTime(ToDate);
        //        }

        //        Microsoft.Extensions.Primitives.StringValues y = "";
        //        var x = Request.Form.TryGetValue("search[value]", out y);

        //        var gatePassslist = gatePassRepository.All();
        //        var gatePassslistDateWise = gatePassslist;


        //        if (y.ToString().Length > 0)
        //        {


        //        }
        //        else
        //        {
        //            if (UserRole == "Admin" || UserRole == "SuperAdmin")
        //            {
        //                gatePassslistDateWise = gatePassslistDateWise.Where(p => (p.GatePassDate >= dtFrom && p.GatePassDate <= dtTo));

        //            }
        //            else
        //            {
        //                var storesettings = storeSettingRepository.All().FirstOrDefault();
        //                if (storesettings.isBackDatePermission == true)
        //                {
        //                    dtTo = Convert.ToDateTime(DateTime.Now.Date);
        //                    DateTime dtFromwithprevdate = Convert.ToDateTime(DateTime.Now.Date.AddDays(-storesettings.Days));

        //                    if (dtFrom < dtFromwithprevdate)
        //                    {
        //                        dtFrom = dtFromwithprevdate;
        //                    }
        //                }

        //                gatePassslistDateWise = gatePassslistDateWise.Where(p => (p.GatePassDate >= dtFrom && p.GatePassDate <= dtTo));

        //                gatePassslistDateWise = gatePassslistDateWise.Where(p => p.LuserId == sessionLuserId);

        //            }


        //            if (UserId != null)
        //            {
        //                gatePassslistDateWise = gatePassslistDateWise.Where(p => p.LuserId == UserId);
        //            }
        //            else
        //            {
        //                if (UserRole == "Admin" || UserRole == "SuperAdmin")
        //                {
        //                }
        //                else
        //                {
        //                    gatePassslistDateWise = gatePassslistDateWise.Where(p => p.LuserId == sessionLuserId);
        //                }
        //            }
        //        }

        //        if (TimeZoneSettingsName.Length > 3)
        //        {
        //            var localtime = TimeZoneInfo.ConvertTime(DateTime.Now, TimeZoneInfo.FindSystemTimeZoneById(TimeZoneSettingsName));
        //            ViewBag.FromDate = localtime.Date.ToString("dd-MMM-yyyy");

        //        }


        //        var query = from e in gatePassslistDateWise.Include(x => x.Items)
        //                    .ThenInclude(x => x.Product).ThenInclude(x => x.Category)



        //                    select new GatePassResultList
        //                    {
        //                        Id = e.Id,
        //                        GatePassCode = e.GatePassCode,
        //                        GatePassDate = e.GatePassDate,
        //                        Transport=e.Transport,
        //                        ManualNo=e.ManualNo,
        //                        Through=e.Through,
        //                        StyleNo=e.StyleNo,
        //                        BuyerName=e.BuyerName,
        //                        ToName=e.ToName,
        //                        Remarks=e.Remarks,
        //                        GatePassDateString = e.GatePassDate.ToString("dd-MMM-yy"),
        //                        EntryTimeString = TimeZoneSettingsName.Length > 3 ? TimeZoneInfo.ConvertTime(e.CreateDate, TimeZoneInfo.FindSystemTimeZoneById(TimeZoneSettingsName)).ToString("HH:mm") : e.CreateDate.ToString("HH:mm"),
        //                        GatePassItems = e.Items.Select(x => new
        //                        {
        //                            x.Id,
        //                            Name = x.Product.Name,
        //                            ColorName = x.Product.ColorName,
        //                            SizeName = x.Product.SizeName,
        //                            ProductCode = x.Product.Code,
        //                            ProductName = x.Product.Name,
        //                            Price = x.Price,
        //                            Quantity = x.Quantity,
        //                            PackageQuantity = x.PackageQuantity,
        //                            Description=x.Description


        //                        })
        //                        //Items = e.Items
        //                    };


        //        var parser = new Parser<GatePassResultList>(Request.Form, query);

        //        return Json(parser.Parse());


        //    }
        //    catch (Exception ex)
        //    {
        //        return Json(new { Success = "0", error = ex.Message });
        //    }

        //}

        [AllowAnonymous]
        public JsonResult GetGatePassList(int? UserId, int? GatePassId, int pageNo = 1, decimal pageSize = 10, string searchquery = "")
        {
            try
            {
                var gatepasslist = gatePassRepository.All().Where(x => x.IsDelete == false);
                if (GatePassId.HasValue)
                {
                    gatepasslist = gatepasslist.Where(x => x.Id == GatePassId);
                }
                //var products= _context.Products.ToList();

                //var accountheadlist = _accountHeadRepository.All().Include(x => x.vAccountGroupHead).Where(x => x.IsDelete == false);//.Include(x=>x.vUnit).Include(x=>x.Category);


                var TimeZoneSettingsName = HttpContext.Session.GetString("TimeZoneSettingsName");
                if (searchquery?.Length > 1)
                {
                    //products = products.Where(x => x.Name.ToLower().Contains(searchquery.ToLower()) || x.Code.ToLower().Contains(searchquery.ToLower()));


                    var searchitem = JsonConvert.DeserializeObject<gatepassFilterData>(searchquery);

                    if (searchitem.pageIndex != null)
                    {
                        pageNo = searchitem.pageIndex.GetValueOrDefault(); // || x.Code.ToLower().Contains(searchitem.Name.ToLower())
                        pageSize = searchitem.pageSize.GetValueOrDefault(); // || x.Code.ToLower().Contains(searchitem.Name.ToLower())


                    }



                    //if (searchitem.GatePassCode != null)
                    //{
                    //    gatepasslist = gatepasslist.Where(x => x.GatePassCode.ToLower().Contains(searchitem.GatePassCode.ToLower())); // || x.Code.ToLower().Contains(searchitem.Name.ToLower())

                    //}

                    //if (searchitem.Description != null)
                    //{
                    //    gatepasslist = gatepasslist.Where(x => x.Remarks.ToLower().Contains(searchitem.Description.ToLower())); // || x.Code.ToLower().Contains(searchitem.Name.ToLower())

                    //}

                    //if (searchitem.BuyerName != null)
                    //{
                    //    gatepasslist = gatepasslist.Where(x => x.BuyerName.ToString() == searchitem.BuyerName); // || x.Code.ToLower().Contains(searchitem.Name.ToLower())

                    //}
                    //if (searchitem.Transport != null)
                    //{
                    //    gatepasslist = gatepasslist.Where(x => x.Transport.ToString() == searchitem.Transport); // || x.Code.ToLower().Contains(searchitem.Name.ToLower())

                    //}


                    //if (searchitem.CategoryName != null)
                    //{
                    //    voucherlist = voucherlist.Where(x => x.AccountCategorys.AccountCategoryName.ToLower().Contains(searchitem.CategoryName.ToLower())); // || x.Code.ToLower().Contains(searchitem.Name.ToLower())

                    //}



                }

                //if (GatePassId != null)
                //{
                //    gatepasslist = gatepasslist.Where(x => x.Id == GatePassId);
                //}
                //if (UserId != null)
                //{
                //    gatepasslist = gatepasslist.Where(x => x.LuserId == UserId);
                //}

                decimal TotalRecordCount = gatepasslist.Count();
                var PageCountabc = decimal.Parse((TotalRecordCount / pageSize).ToString());
                var PageCount = Math.Ceiling(PageCountabc);






                //decimal skip = (pageNo - 1) * pageSize;

                // Get total number of records
                int total = gatepasslist.Count();



                var query = from e in gatepasslist.Include(x => x.Items)
                                //.ThenInclude(x => x.Product).ThenInclude(x => x.Category)



                            select new GatePassResultList
                            {
                                Id = e.Id,
                                GatePassCode = e.GatePassCode,
                                GatePassDate = e.GatePassDate,
                                Transport = e.Transport,
                                ManualNo = e.ManualNo,
                                Through = e.Through,
                                StyleNo = e.StyleNo,
                                BuyerName = e.BuyerName,
                                ToName = e.ToName,
                                Remarks = e.Remarks,
                                //GatePassDateString = e.GatePassDate.ToString("dd-MMM-yy"),
                                //EntryTimeString = TimeZoneSettingsName.Length > 3 ? TimeZoneInfo.ConvertTime(e.CreateDate, TimeZoneInfo.FindSystemTimeZoneById(TimeZoneSettingsName)).ToString("HH:mm") : e.CreateDate.ToString("HH:mm"),
                                GatePassItems = e.Items.Select(x => new
                                {
                                    x.GatePassId,
                                    //Name = x.Product.Name,
                                    //ColorName = x.Product.ColorName,
                                    //SizeName = x.Product.SizeName,
                                    //ProductCode = x.Product.Code,
                                    ProductName = x.Product.Name,
                                    x.SLNo,
                                    x.IsTransaction,
                                    x.Name,
                                    x.ColorName,
                                    x.SizeName,
                                    x.Price,
                                    x.Quantity,
                                    x.PackageQuantity,
                                    x.Description,



                                })
                            };


                //var parser = new Parser<GatePassResultList>(Request.Form, query);

                //return Json(parser.Parse());





                var abcd = query.OrderByDescending(x => x.Id).Take(int.Parse(pageSize.ToString())).ToList();// Take(50);
                var pageinfo = new PagingInfo();
                pageinfo.PageCount = int.Parse(PageCount.ToString());
                pageinfo.PageNo = pageNo;
                pageinfo.PageSize = int.Parse(pageSize.ToString());
                pageinfo.TotalRecordCount = int.Parse(TotalRecordCount.ToString());

                //return  abcd;
                return Json(new { Success = 1, error = false, gatepasslist = abcd, PageInfo = pageinfo });


            }
            catch (Exception ex)
            {
                throw ex;
            }
        }





        [AllowAnonymous]
        public IActionResult GetOnlineOrderList(string FromDate, string ToDate, int? CustomerId, int? UserId, string Status, int? WarehouseId)
        {
            try
            {
                var ComId = (HttpContext.Session.GetInt32("ComId"));
                var sessionLuserId = (HttpContext.Session.GetInt32("UserId"));


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

                var onlinesaleslist = onlineOrderRepository.All();




                if (y.ToString().Length > 0)
                {


                }
                else
                {
                    onlinesaleslist = onlinesaleslist.Where(p => (p.OrdersDate >= dtFrom && p.OrdersDate <= dtTo));



                    var UserRole = HttpContext.Session.GetString("UserRole");
                    var SessionCustomerId = HttpContext.Session.GetInt32("CustomerId");
                    if (SessionCustomerId > 0)
                    {
                        UserRole = "Customer";
                    }


                    if (UserRole == "Admin" || UserRole == "SuperAdmin")
                    {
                        if (CustomerId != null)
                        {
                            onlinesaleslist = onlinesaleslist.Where(p => p.CustomerId == CustomerId);
                        }
                        if (UserId != null)
                        {
                            onlinesaleslist = onlinesaleslist.Where(p => p.CustomerModel.SalesRepresentative.UserAccountList.Id == UserId);
                        }
                    }
                    else if (UserRole == "User")
                    {
                        var empid = UserAccountRepository.All().Where(x => x.Id == sessionLuserId).FirstOrDefault().EmployeeId;
                        var custidlist = customerRepository.All().Where(p => p.SalesRepresentativeId == empid)
                        .Select(x => new
                        {
                            x.Id
                        });

                        List<int?> custidarray = new List<int?>();

                        foreach (var item in custidlist)
                        {
                            custidarray.Add(int.Parse(item.Id.ToString()));
                        }
                        onlinesaleslist = onlinesaleslist.Where(p => custidarray.Contains(p.CustomerId));

                        if (CustomerId != null)
                        {
                            onlinesaleslist = onlinesaleslist.Where(p => p.CustomerId == CustomerId);
                        }

                    }
                    else if (UserRole == "Customer")
                    {
                        onlinesaleslist = onlinesaleslist.Where(p => p.CustomerId == SessionCustomerId);
                        //var CustomerId = HttpContext.Session.GetInt32("CustomerId");


                    }




                    //if (WarehouseId != null)
                    //{
                    //    saleslist = saleslist.Where(p => p.WarehouseIdMain == WarehouseId);
                    //}
                    //else
                    //{
                    //    var arrayabc = _FromWarehousePermissionRepository.All().Where(x => x.LuserIdAllow == sessionLuserId).Select(x => x.WarehouseId).ToList();
                    //    //int a = 1;
                    //    //List<int> IDs = new List<int> { 1, 3, 4, 8 };

                    //    //var warehouselist = _FromWarehousePermissionRepository.All().Select(x=>x.Id);
                    //    if (arrayabc.Count() > 0)
                    //    {
                    //        onlinesaleslist = onlinesaleslist.Where(p => arrayabc.Contains(p.WarehouseIdMain));
                    //    }
                    //}


                    //if (Status == "Due")
                    //{
                    //    //var saleslistmore = saleslist.Where(x => x.GrandTotal -  x.SalesPayments.Sum(x=>x.Amount) > 0);

                    //    onlinesaleslist = onlinesaleslist.Where(x => x.GrandTotal - x.OrdersPayments.Sum(x => x.Amount) != 0);

                    //    //saleslist = saleslist.Where(x=>x.SalesPayments.Count == 0);


                    //}

                    if (Status != "All")
                    {
                        if (Status == "True")
                        {
                            onlinesaleslist = onlinesaleslist.Where(x => x.isPosted == true);
                        }
                        else if (Status == "False")
                        {
                            onlinesaleslist = onlinesaleslist.Where(x => x.isPosted == false);
                        }
                    }



                }



                var query = from e in onlinesaleslist.Include(x => x.Items).ThenInclude(x => x.Product).ThenInclude(x => x.Category)
                                //.Include(x => x.OrdersPayments).ThenInclude(x => x.vChartofAccounts)
                                //.Include(x => x.OrdersPayments).ThenInclude(x => x.Transaction)
                                //.Include(x => x.OrdersPayments).ThenInclude(x => x.vChartofAccounts)
                            select new OrdersResultList
                            {
                                Id = e.Id,
                                OrderCode = e.OrderCode,
                                OrdersDate = e.OrdersDate,
                                OrdersDateString = e.OrdersDate.ToString("dd-MMM-yy"),

                                OrdersUser = e.UserAccountList.Name,

                                CustomerName = (e.CustomerName.Length == 0 || e.CustomerName == null) ? e.CustomerModel.Name : e.CustomerModel.Name + " - " + e.CustomerName, //e.CustomerName,//
                                //CustomerName = e.CustomerName,
                                PrimaryAddress = (e.CustomerName.Length == 0 || e.CustomerName == null) ? e.CustomerModel.PrimaryAddress : e.CustomerModel.PrimaryAddress + " - " + e.PrimaryAddress, // e.PrimaryAddress,
                                SecoundaryAddress = (e.SecoundaryAddress.Length == 0 || e.SecoundaryAddress == null) ? e.CustomerModel.SecoundaryAddress : e.CustomerModel.SecoundaryAddress + " - " + e.SecoundaryAddress, // e.PrimaryAddress,
                                Notes = e.Notes,
                                PhoneNo = (e.PhoneNo.Length == 0 || e.PhoneNo == null) ? e.CustomerModel.Phone : e.CustomerModel.Phone + " - " + e.PhoneNo,
                                //Discount = e.Discount,
                                //Total = e.Total,
                                Status = e.Status,
                                NetAmount = e.NetAmount,
                                //isPOSSales = e.isPOSSales,
                                //isSerialSales = e.isSerialSales,
                                isPosted = e.isPosted,
                                //FinalCostingPrice = e.FinalCostingPrice,
                                //Profit = e.Profit,
                                //ProfitPercentage = e.ProfitPercentage,
                                // Location = e.Warehouses.WhShortName,
                                StatusPosted = e.isPosted != false ? "Placed for Invoice" : "Pending",
                                //PaidAmt = e.SalesPayments.Sum(x => x.Amount),// e.PaidAmt,
                                //ReceivingHead = e.CreditAccount != null ? e.CreditAccount.AccName : "=N/A="
                                OrdersPayments = e.OrdersPayments.ToList(),
                                Items = e.Items.ToList()


                            };


                var parser = new Parser<OrdersResultList>(Request.Form, query);

                return Json(parser.Parse());


            }
            catch (Exception ex)
            {
                return Json(new { Success = "0", error = ex.Message });
                //throw ex;
            }

        }



        [AllowAnonymous]
        public IActionResult GetSerialProductList(string FromDate, string ToDate, int? ProductId, int isAll)
        {
            try
            {
                var ComId = (HttpContext.Session.GetInt32("ComId"));

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

                var productlist = _purchaseBatchItemRepository.All();




                if (y.ToString().Length > 0)
                {


                }
                else
                {
                    //if (ProductId == null)
                    //{
                    //    productlist = productlist.Where(p => p.SalesDate >= dtFrom && p.SalesDate <= dtTo);

                    //}
                    //else
                    //{
                    //    //if (ProductId == 1)
                    //    //{
                    //    //    productlist = productlist.Where(p => p.SalesDate >= dtFrom && p.SalesDate <= dtTo);
                    //    //}
                    //    //else
                    //    //{
                    //    productlist = productlist.Where(p => (p.SalesDate >= dtFrom && p.SalesDate <= dtTo) && p.ProductId == ProductId);
                    //    //}
                    //}

                }



                var query = from e in productlist
                            select new SerialProductResultList
                            {
                                Id = e.Id,
                                CustomerName = (e.SalesBatchItems.FirstOrDefault().SalesItems.SalesModel.CustomerName.Length == 0 || e.SalesBatchItems.FirstOrDefault().SalesItems.SalesModel.CustomerName == null) ? e.SalesBatchItems.FirstOrDefault().SalesItems.SalesModel.CustomerModel.Name : e.SalesBatchItems.FirstOrDefault().SalesItems.SalesModel.CustomerModel.Name + " - " + e.SalesBatchItems.FirstOrDefault().SalesItems.SalesModel.CustomerName,
                                //CustomerMobileNo = (e.SalesBatchItems.FirstOrDefault().SalesItems.SalesModel.PhoneNo.Length == 0 || e.SalesBatchItems.FirstOrDefault().SalesItems.SalesModel.PhoneNo == null) ? e.SalesBatchItems.FirstOrDefault().SalesItems.SalesModel.CustomerModel.Phone : e.SalesBatchItems.FirstOrDefault().SalesItems.SalesModel.CustomerModel.Phone + " - " + e.SalesBatchItems.FirstOrDefault().SalesItems.SalesModel.PhoneNo,
                                //CustomerAddress = (e.SalesBatchItems.FirstOrDefault().SalesItems.SalesModel.PrimaryAddress.Length == 0 || e.SalesBatchItems.FirstOrDefault().SalesItems.SalesModel.PrimaryAddress == null) ? e.SalesBatchItems.FirstOrDefault().SalesItems.SalesModel.CustomerModel.PrimaryAddress : e.SalesBatchItems.FirstOrDefault().SalesItems.SalesModel.CustomerModel.PrimaryAddress + " - " + e.SalesBatchItems.FirstOrDefault().SalesItems.SalesModel.PrimaryAddress,

                                SupplierName = (e.PurchaseItems.PurchaseModel.SupplierName.Length == 0 || e.PurchaseItems.PurchaseModel.SupplierName == null) ? e.PurchaseItems.PurchaseModel.SupplierModel.SupplierName : e.PurchaseItems.PurchaseModel.SupplierModel.SupplierName + " - " + e.PurchaseItems.PurchaseModel.SupplierName,
                                //SupplierMobileNo = (e.PurchaseItems.PurchaseModel.PhoneNo.Length == 0 || e.PurchaseItems.PurchaseModel.PhoneNo == null) ? e.PurchaseItems.PurchaseModel.SupplierModel.Phone : e.PurchaseItems.PurchaseModel.SupplierModel.Phone + " - " + e.PurchaseItems.PurchaseModel.PhoneNo,
                                //SupplierAddress = (e.PurchaseItems.PurchaseModel.PrimaryAddress.Length == 0 || e.PurchaseItems.PurchaseModel.PrimaryAddress == null) ? e.PurchaseItems.PurchaseModel.SupplierModel.Address : e.PurchaseItems.PurchaseModel.SupplierModel.Address + " - " + e.PurchaseItems.PurchaseModel.PrimaryAddress,


                                BatchSerialNo = e.BatchSerialNo,
                                ReplaceSerialNo = e.WarrentyList.FirstOrDefault().ReplacedSerialNo,
                                ReplaceDate = e.WarrentyList.FirstOrDefault().ReplacedDate.GetValueOrDefault().ToString("dd-MMM-yy"),


                                SalesCode = e.SalesBatchItems.FirstOrDefault().SalesItems.SalesModel.SaleCode,
                                PurchaseCode = e.PurchaseItems.PurchaseModel.PurchaseCode,



                                ProductName = e.Products.Name,


                                ProductCode = e.Products.Code,
                                BrandName = e.Products.Brand != null ? e.Products.Brand.BrandName : "",
                                ModelName = e.Products.ModelName,
                                SizeName = e.Products.SizeName,
                                ColorName = e.Products.ColorName,


                                SellingPrice = e.SalesBatchItems.FirstOrDefault().SalesItems.Price,//e.SalesBatchItems == null e.SalesBatchItems.FirstOrDefault().SalesItems.Price,
                                PurchasePrice = e.PurchaseItems.Price,

                                WarrentyName = e.Products.Warrenty.Name,
                                WarrentyDay = e.Products.Warrenty.Day,
                                //ProductAge = (DateTime.Now.Date - e.SalesBatchItems.FirstOrDefault().SalesItems.SalesModel.SalesDate).Days,
                                ProductAge = null,//(DateTime.Now.Date - DateTime.Parse("12-june-21").Date).Days.ToString(),
                                salesdateformat = e.SalesBatchItems.FirstOrDefault().SalesItems.SalesModel.SalesDate,


                                //SalesDate = e.SalesDate,
                                SalesDate = e.SalesBatchItems.FirstOrDefault().SalesItems.SalesModel.SalesDate.ToString("dd-MMM-yy"),
                                PurchaseDate = e.PurchaseItems.PurchaseModel.PurchaseDate.ToString("dd-MMM-yy")


                            };


                //var abc = query.ToList();


                var parser = new Parser<SerialProductResultList>(Request.Form, query);

                return Json(parser.Parse());


            }
            catch (Exception ex)
            {
                return Json(new { Success = "0", error = ex.Message });
                //throw ex;
            }

        }







        public class SalesDetailsResultList
        {
            public int Id { get; set; }
            public string? SalesCode { get; set; }
            public string? SalesDate { get; set; }
            public DateTime SalesDateOrg { get; set; }



            public string? CustomerName { get; set; }
            public string? CustomerMobileNo { get; set; }
            public string? CustomerAddress { get; set; }
            public string? CategoryName { get; set; }

            public string? ProductName { get; set; }
            public string? ProductCode { get; set; }


            public string? ModelName { get; set; }
            public string? SizeName { get; set; }
            public string? ColorName { get; set; }


            public string? BrandName { get; set; }

            public string? WarehouseName { get; set; }




            public string? BatchSerialNo { get; set; }

            public string? PurchaseCode { get; set; }

            public string? PurchaseDate { get; set; }


            //public int WarrentyDay { get; set; }
            //public string? WarrentyName { get; set; }


            //public string? ProductAge { get; set; }

            //public string? WarrentyStatus { get; set; }

            public double? SalesPrice { get; set; }
            public double CostPrice { get; set; }
            public double Profit { get; set; }
            public double IndDiscountProportion { get; set; }
            public double Quantity { get; set; }



            public DateTime? salesdateformat { get; set; }

            public string? SalesRepName { get; set; }
            public double SalesRepCommission { get; set; }
            public double TotalSalesRepCommission { get; set; }





        }

        [AllowAnonymous]
        //public IActionResult GetSalesDetailsList(string FromDate, string ToDate, int? CategoryId, int isAll , int? SalesRepId)
        public IActionResult GetSalesDetailsList(string FromDate, string ToDate, int? CustomerId, int? UserId, string Status, int? WarehouseId, int? CategoryId, int? DocTypeId, int? SalesRepId)
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


                var productlist = saleItemRepository.All();
                //var productreturnlist = salesReturnItemRepository.All();

                //.Include(x => x.BatchSerialItems);

                //var productlist = saleItemRepository.All()
                //    .Include(x=>x.Product).ThenInclude(x=>x.Category)
                //    .Include(x=>x.SalesModel)
                //    .Include(x=>x.BatchSerialItems);


                ///.Include(x => x.Product).ThenInclude(x => x.Category).Include(x => x.SalesModel)

                if (y.ToString().Length > 0)
                {


                }
                else
                {
                    if (UserRole == "Admin" || UserRole == "SuperAdmin")
                    {
                        productlist = productlist.Where(p => (p.SalesModel.SalesDate >= dtFrom && p.SalesModel.SalesDate <= dtTo));
                        //productreturnlist = productreturnlist.Where(p => (p.SalesReturnModel.SalesReturnDate >= dtFrom && p.SalesReturnModel.SalesReturnDate <= dtTo));


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

                        productlist = productlist.Where(p => (p.SalesModel.SalesDate >= dtFrom && p.SalesModel.SalesDate <= dtTo));
                        productlist = productlist.Where(p => p.LuserId == sessionLuserId);


                        //productreturnlist = productreturnlist.Where(p => (p.SalesReturnModel.SalesReturnDate >= dtFrom && p.SalesReturnModel.SalesReturnDate <= dtTo));
                        //productreturnlist = productreturnlist.Where(p => p.LuserId == sessionLuserId);

                    }



                    //if (CategoryId != null)
                    //{
                    //    productlist = productlist.Where(p => p.Product.CategoryId == CategoryId);

                    //}
                    if (CustomerId != null)
                    {
                        productlist = productlist.Where(p => p.SalesModel.CustomerId == CustomerId);
                        //productreturnlist = productreturnlist.Where(p => p.SalesReturnModel.CustomerId == CustomerId);

                    }
                    if (CategoryId != null)
                    {
                        productlist = productlist.Where(p => p.Product.CategoryId == CategoryId);
                        //productreturnlist = productreturnlist.Where(p => p.Product.CategoryId == CategoryId);

                    }
                    if (DocTypeId != null)
                    {
                        productlist = productlist.Where(p => p.SalesModel.DocTypeId == DocTypeId);
                        // productreturnlist = productreturnlist.Where(p => p.SalesReturnModel.DocTypeId == DocTypeId);

                    }
                    if (UserId != null)
                    {
                        productlist = productlist.Where(p => p.LuserId == UserId);
                        //productreturnlist = productreturnlist.Where(p => p.LuserId == UserId);

                    }

                    if (SalesRepId != null)
                    {
                        productlist = productlist.Where(p => p.SalesModel.SalesRepId == SalesRepId);
                        //productreturnlist = productreturnlist.Where(p => p.SalesReturnModel.SalesRepId == SalesRepId);

                    }



                    productlist = productlist.Where(p => (p.SalesModel.SalesDate >= dtFrom && p.SalesModel.SalesDate <= dtTo));
                    //productreturnlist = productreturnlist.Where(p => (p.SalesReturnModel.SalesReturnDate >= dtFrom && p.SalesReturnModel.SalesReturnDate <= dtTo));


                }



                var query = from e in productlist.Include(x => x.Product).ThenInclude(x => x.Category).Include(x => x.SalesModel).ThenInclude(x => x.SalesRep)
                            select new SalesDetailsResultList
                            {
                                Id = e.Id,
                                SalesCode = e.SalesModel.SaleCode,
                                SalesDate = e.SalesModel.SalesDate.ToString("dd-MMM-yy"),
                                CustomerName = (e.SalesModel.CustomerName.Length == 0 || e.SalesModel.CustomerName == null) ? e.SalesModel.CustomerModel.Name : e.SalesModel.CustomerModel.Name + " - " + e.SalesModel.CustomerName,
                                CustomerAddress = (e.SalesModel.PrimaryAddress.Length == 0 || e.SalesModel.PrimaryAddress == null) ? e.SalesModel.CustomerModel.PrimaryAddress : e.SalesModel.CustomerModel.PrimaryAddress + " - " + e.SalesModel.PrimaryAddress,
                                CustomerMobileNo = (e.SalesModel.PhoneNo.Length == 0 || e.SalesModel.PhoneNo == null) ? e.SalesModel.CustomerModel.Phone : e.SalesModel.CustomerModel.Phone + " - " + e.SalesModel.PhoneNo,
                                CategoryName = e.Product.Category.Name,
                                ProductName = e.Product.Name,
                                ProductCode = e.Product.Code,
                                BrandName = e.Product.Brand != null ? e.Product.Brand.BrandName : "",
                                ModelName = e.Product.ModelName,
                                SizeName = e.Product.SizeName,
                                ColorName = e.Product.ColorName,


                                Quantity = e.Quantity,
                                SalesPrice = e.Quantity * Math.Round(e.Price, 2),//e.SalesBatchItems == null e.Price,
                                CostPrice = e.Quantity * Math.Round(e.CostPrice, 2),//e.SalesBatchItems == null e.Price,
                                //IndDiscountProportion = e.Quantity * Math.Round(e.IndDiscountProportion, 2),
                                IndDiscountProportion = Math.Round(e.IndDiscountProportion, 2),
                                Profit = e.Quantity * Math.Round((e.Price - (e.CostPrice + (e.IndDiscountProportion / e.Quantity))), 2),
                                SalesRepName = e.SalesModel.SalesRep.EmployeeName,
                                SalesRepCommission = e.CommissionAmount,
                                //PurchasePrice = e.PurchaseItems.Price,
                                //WarrentyName = e.Products.Warrenty.Name,
                                //WarrentyDay = e.Products.Warrenty.Day,
                                //ProductAge = (DateTime.Now.Date - e.SalesModel.SalesDate).Days,
                                //ProductAge = null,//(DateTime.Now.Date - DateTime.Parse("12-june-21").Date).Days.ToString(),
                                salesdateformat = e.SalesModel.SalesDate


                                //SalesDate = e.SalesDate,
                                //PurchaseDate = e.PurchaseItems.PurchaseModel.PurchaseDate.ToString("dd-MMM-yy")


                            };





                //var abc = query.ToList();


                var parser = new Parser<SalesDetailsResultList>(Request.Form, query);

                //var returnparser = new Parser<SalesDetailsResultList>(Request.Form, returnquery);

                //var abc = parser.Parse();
                //var xyz = returnparser.Parse();

                //abc.data.AddRange(xyz.data);
                //var xyz = returnquery.ToList();

                //abc.AddRange(xyz);

                //return Json(abc.Parse());


                return Json(parser.Parse());
            }
            catch (Exception ex)
            {
                return Json(new { Success = "0", error = ex.Message });
                //throw ex;
            }

        }



        public IActionResult SalesDetailsViewList()
        {
            ViewBag.FromDate = DateTime.Now.Date;
            ViewBag.ToDate = DateTime.Now.Date;

            ViewBag.Customers = customerRepository.GetAllForDropDown();
            ViewBag.Category = categoryRepository.GetAllForDropDown();
            ViewBag.DocType = _docTypeRepository.GetSalesDocForDropDown();
            ViewBag.SalesRep = _employeeRepository.GetAllForDropDown();


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

            var x = _FromWarehousePermissionRepository.GetAllForDropDown();
            if (x.Count() == 0)
            {
                x = _warehouseRepository.GetWarehouseLedgerHeadForDropDown();
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
        public IActionResult GetSalesDetailsListViewReport(string FromDate, string ToDate, int? CustomerId, int? UserId, string Status, int? WarehouseId, int? CategoryId, int? DocTypeId, int? SalesRepId)
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



                var productlist = saleItemRepository.All();
                var productreturnlist = salesReturnItemRepository.All();

                //.Include(x => x.BatchSerialItems);

                //var productlist = saleItemRepository.All()
                //    .Include(x=>x.Product).ThenInclude(x=>x.Category)
                //    .Include(x=>x.SalesModel)
                //    .Include(x=>x.BatchSerialItems);


                ///.Include(x => x.Product).ThenInclude(x => x.Category).Include(x => x.SalesModel)

                //if (y.ToString().Length > 0)
                //{


                //}
                //else
                {
                    if (UserRole == "Admin" || UserRole == "SuperAdmin")
                    {
                        productlist = productlist.Where(p => (p.SalesModel.SalesDate >= dtFrom && p.SalesModel.SalesDate <= dtTo));
                        productreturnlist = productreturnlist.Where(p => (p.SalesReturnModel.SalesReturnDate >= dtFrom && p.SalesReturnModel.SalesReturnDate <= dtTo));


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

                        productlist = productlist.Where(p => (p.SalesModel.SalesDate >= dtFrom && p.SalesModel.SalesDate <= dtTo));
                        //productlist = productlist.Where(p => p.LuserId == sessionLuserId);


                        productreturnlist = productreturnlist.Where(p => (p.SalesReturnModel.SalesReturnDate >= dtFrom && p.SalesReturnModel.SalesReturnDate <= dtTo));
                        //productreturnlist = productreturnlist.Where(p => p.LuserId == sessionLuserId);

                    }



                    //if (CategoryId != null)
                    //{
                    //    productlist = productlist.Where(p => p.Product.CategoryId == CategoryId);

                    //}
                    if (CustomerId != null)
                    {
                        productlist = productlist.Where(p => p.SalesModel.CustomerId == CustomerId);
                        productreturnlist = productreturnlist.Where(p => p.SalesReturnModel.CustomerId == CustomerId);

                    }
                    if (CategoryId != null)
                    {
                        productlist = productlist.Where(p => p.Product.CategoryId == CategoryId);
                        productreturnlist = productreturnlist.Where(p => p.Product.CategoryId == CategoryId);

                    }
                    if (DocTypeId != null)
                    {
                        productlist = productlist.Where(p => p.SalesModel.DocTypeId == DocTypeId);
                        //productreturnlist = productreturnlist.Where(p => p.SalesReturnModel.DocTypeId == DocTypeId);

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

                    if (SalesRepId != null)
                    {
                        productlist = productlist.Where(p => p.SalesModel.SalesRepId == SalesRepId);
                        productreturnlist = productreturnlist.Where(p => p.SalesReturnModel.SalesRepId == SalesRepId);

                    }



                    productlist = productlist.Where(p => (p.SalesModel.SalesDate >= dtFrom && p.SalesModel.SalesDate <= dtTo));
                    productreturnlist = productreturnlist.Where(p => (p.SalesReturnModel.SalesReturnDate >= dtFrom && p.SalesReturnModel.SalesReturnDate <= dtTo));


                }



                var query = from e in productlist.Include(x => x.Product).ThenInclude(x => x.Category).Include(x => x.SalesModel).ThenInclude(x => x.SalesRep)
                            select new SalesDetailsResultList()
                            {
                                Id = e.Id,
                                SalesCode = e.SalesModel.SaleCode,
                                SalesDate = e.SalesModel.SalesDate.ToString("dd-MMM-yy"),
                                SalesDateOrg = e.SalesModel.SalesDate,

                                CustomerName = (e.SalesModel.CustomerName.Length == 0 || e.SalesModel.CustomerName == null) ? e.SalesModel.CustomerModel.Name : e.SalesModel.CustomerModel.Name + " - " + e.SalesModel.CustomerName,
                                CustomerAddress = (e.SalesModel.PrimaryAddress.Length == 0 || e.SalesModel.PrimaryAddress == null) ? e.SalesModel.CustomerModel.PrimaryAddress : e.SalesModel.CustomerModel.PrimaryAddress + " - " + e.SalesModel.PrimaryAddress,
                                CustomerMobileNo = (e.SalesModel.PhoneNo.Length == 0 || e.SalesModel.PhoneNo == null) ? e.SalesModel.CustomerModel.Phone : e.SalesModel.CustomerModel.Phone + " - " + e.SalesModel.PhoneNo,
                                CategoryName = e.Product.Category.Name,
                                ProductName = e.Product.Name,

                                ProductCode = e.Product.Code,
                                BrandName = e.Product.Brand != null ? e.Product.Brand.BrandName : "",
                                ModelName = e.Product.ModelName,
                                SizeName = e.Product.SizeName,
                                ColorName = e.Product.ColorName,
                                WarehouseName = e.vWarehouse.WhShortName,

                                Quantity = e.Quantity,
                                SalesPrice = e.Quantity * Math.Round(e.Price, 2),//e.SalesBatchItems == null e.Price,
                                CostPrice = e.Quantity * Math.Round(e.CostPrice, 2),//e.SalesBatchItems == null e.Price,
                                //IndDiscountProportion = e.Quantity * Math.Round(e.IndDiscountProportion, 2),
                                IndDiscountProportion = Math.Round(e.IndDiscountProportion, 2),
                                Profit = e.Quantity * Math.Round((e.Price - (e.CostPrice + (e.IndDiscountProportion / e.Quantity))), 2),
                                SalesRepName = e.SalesModel.SalesRep.EmployeeName,
                                SalesRepCommission = e.CommissionAmount,
                                TotalSalesRepCommission = e.CommissionAmount * e.Quantity,

                                //PurchasePrice = e.PurchaseItems.Price,
                                //WarrentyName = e.Products.Warrenty.Name,
                                //WarrentyDay = e.Products.Warrenty.Day,
                                //ProductAge = (DateTime.Now.Date - e.SalesModel.SalesDate).Days,
                                //ProductAge = null,//(DateTime.Now.Date - DateTime.Parse("12-june-21").Date).Days.ToString(),
                                salesdateformat = e.SalesModel.SalesDate


                                //SalesDate = e.SalesDate,
                                //PurchaseDate = e.PurchaseItems.PurchaseModel.PurchaseDate.ToString("dd-MMM-yy")


                            };


                var returnquery = from e in productreturnlist.Include(x => x.Product).ThenInclude(x => x.Category).Include(x => x.SalesReturnModel).ThenInclude(x => x.SalesRep)
                                  select new SalesDetailsResultList()
                                  {
                                      Id = e.Id,
                                      SalesCode = e.SalesReturnModel.SalesReturnCode,
                                      SalesDate = e.SalesReturnModel.SalesReturnDate.ToString("dd-MMM-yy"),
                                      SalesDateOrg = e.SalesReturnModel.SalesReturnDate,
                                      CustomerName = (e.SalesReturnModel.CustomerName.Length == 0 || e.SalesReturnModel.CustomerName == null) ? e.SalesReturnModel.CustomerModel.Name : e.SalesReturnModel.CustomerModel.Name + " - " + e.SalesReturnModel.CustomerName,
                                      CustomerAddress = (e.SalesReturnModel.PrimaryAddress.Length == 0 || e.SalesReturnModel.PrimaryAddress == null) ? e.SalesReturnModel.CustomerModel.PrimaryAddress : e.SalesReturnModel.CustomerModel.PrimaryAddress + " - " + e.SalesReturnModel.PrimaryAddress,
                                      CustomerMobileNo = (e.SalesReturnModel.PhoneNo.Length == 0 || e.SalesReturnModel.PhoneNo == null) ? e.SalesReturnModel.CustomerModel.Phone : e.SalesReturnModel.CustomerModel.Phone + " - " + e.SalesReturnModel.PhoneNo,
                                      CategoryName = e.Product.Category.Name,
                                      ProductName = e.Product.Name,
                                      ProductCode = e.Product.Code,
                                      BrandName = e.Product.Brand != null ? e.Product.Brand.BrandName : "",
                                      ModelName = e.Product.ModelName,
                                      SizeName = e.Product.SizeName,
                                      ColorName = e.Product.ColorName,

                                      Quantity = -e.Quantity,
                                      SalesPrice = -e.Quantity * Math.Round(e.Price, 2),//e.SalesBatchItems == null e.Price,
                                      CostPrice = -e.Quantity * Math.Round(e.CostPrice, 2),//e.SalesBatchItems == null e.Price,
                                                                                           //IndDiscountProportion = e.Quantity * Math.Round(e.IndDiscountProportion, 2),
                                      IndDiscountProportion = -Math.Round(e.IndDiscount, 2),
                                      Profit = -(e.Quantity * Math.Round((e.Price - (e.CostPrice + (e.IndDiscount / e.Quantity))), 2)),
                                      SalesRepName = e.SalesReturnModel.SalesRep.EmployeeName,
                                      SalesRepCommission = -e.CommissionAmount,
                                      TotalSalesRepCommission = -(e.CommissionAmount * e.Quantity),
                                      //PurchasePrice = e.PurchaseItems.Price,
                                      //WarrentyName = e.Products.Warrenty.Name,
                                      //WarrentyDay = e.Products.Warrenty.Day,
                                      //ProductAge = (DateTime.Now.Date - e.SalesModel.SalesDate).Days,
                                      //ProductAge = null,//(DateTime.Now.Date - DateTime.Parse("12-june-21").Date).Days.ToString(),
                                      salesdateformat = e.SalesReturnModel.SalesReturnDate


                                      //SalesDate = e.SalesDate,
                                      //PurchaseDate = e.PurchaseItems.PurchaseModel.PurchaseDate.ToString("dd-MMM-yy")


                                  };





                var abc = query.ToList();


                //var parser = new Parser<SalesDetailsResultList>(Request.Form, query);

                //var returnparser = new Parser<SalesDetailsResultList>(Request.Form, returnquery);

                //var abc = parser.Parse();
                //var xyz = returnparser.Parse();

                //abc.data.AddRange(xyz.data);
                var xyz = returnquery.ToList();

                abc.AddRange(xyz);


                return Json(new { Success = 1, data = abc.OrderBy(x => x.SalesDateOrg) });


                //return Json(parser.Parse());

                //return Json(parser.Parse());

            }
            catch (Exception ex)
            {
                return Json(new { Success = "0", error = ex.Message });
                //throw ex;
            }

        }




        [AllowAnonymous]
        //public IActionResult GetSalesDetailsList(string FromDate, string ToDate, int? CategoryId, int isAll , int? SalesRepId)
        public IActionResult GetSalesReturnDetailsList(string FromDate, string ToDate, int? CustomerId, int? UserId, string Status, int? WarehouseId, int? CategoryId, int? DocTypeId, int? SalesRepId)
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


                var productreturnlist = salesReturnItemRepository.All();


                if (y.ToString().Length > 0)
                {


                }
                else
                {
                    if (UserRole == "Admin" || UserRole == "SuperAdmin")
                    {
                        productreturnlist = productreturnlist.Where(p => (p.SalesReturnModel.SalesReturnDate >= dtFrom && p.SalesReturnModel.SalesReturnDate <= dtTo));


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

                        productreturnlist = productreturnlist.Where(p => (p.SalesReturnModel.SalesReturnDate >= dtFrom && p.SalesReturnModel.SalesReturnDate <= dtTo));
                        productreturnlist = productreturnlist.Where(p => p.LuserId == sessionLuserId);

                    }



                    //if (CategoryId != null)
                    //{
                    //    productlist = productlist.Where(p => p.Product.CategoryId == CategoryId);

                    //}
                    if (CustomerId != null)
                    {
                        productreturnlist = productreturnlist.Where(p => p.SalesReturnModel.CustomerId == CustomerId);

                    }
                    if (CategoryId != null)
                    {
                        productreturnlist = productreturnlist.Where(p => p.Product.CategoryId == CategoryId);

                    }
                    if (DocTypeId != null)
                    {
                    }
                    if (UserId != null)
                    {
                        productreturnlist = productreturnlist.Where(p => p.LuserId == UserId);

                    }

                    if (SalesRepId != null)
                    {
                        productreturnlist = productreturnlist.Where(p => p.SalesReturnModel.SalesRepId == SalesRepId);

                    }

                    productreturnlist = productreturnlist.Where(p => (p.SalesReturnModel.SalesReturnDate >= dtFrom && p.SalesReturnModel.SalesReturnDate <= dtTo));


                }




                var returnquery = from e in productreturnlist.Include(x => x.Product).ThenInclude(x => x.Category).Include(x => x.SalesReturnModel).ThenInclude(x => x.SalesRep)
                                  select new SalesDetailsResultList
                                  {
                                      Id = e.Id,
                                      SalesCode = e.SalesReturnModel.SalesReturnCode,
                                      SalesDate = e.SalesReturnModel.SalesReturnDate.ToString("dd-MMM-yy"),
                                      CustomerName = (e.SalesReturnModel.CustomerName.Length == 0 || e.SalesReturnModel.CustomerName == null) ? e.SalesReturnModel.CustomerModel.Name : e.SalesReturnModel.CustomerModel.Name + " - " + e.SalesReturnModel.CustomerName,
                                      CustomerAddress = (e.SalesReturnModel.PrimaryAddress.Length == 0 || e.SalesReturnModel.PrimaryAddress == null) ? e.SalesReturnModel.CustomerModel.PrimaryAddress : e.SalesReturnModel.CustomerModel.PrimaryAddress + " - " + e.SalesReturnModel.PrimaryAddress,
                                      CustomerMobileNo = (e.SalesReturnModel.PhoneNo.Length == 0 || e.SalesReturnModel.PhoneNo == null) ? e.SalesReturnModel.CustomerModel.Phone : e.SalesReturnModel.CustomerModel.Phone + " - " + e.SalesReturnModel.PhoneNo,
                                      CategoryName = e.Product.Category.Name,
                                      ProductName = e.Product.Name,
                                      BrandName = e.Product.Brand != null ? e.Product.Brand.BrandName : "",
                                      ModelName = e.Product.ModelName,
                                      ProductCode = e.Product.Code,
                                      SizeName = e.Product.SizeName,
                                      ColorName = e.Product.ColorName,

                                      Quantity = e.Quantity,
                                      SalesPrice = e.Quantity * Math.Round(e.Price, 2),//e.SalesBatchItems == null e.Price,
                                      CostPrice = e.Quantity * Math.Round(e.CostPrice, 2),//e.SalesBatchItems == null e.Price,
                                                                                          //IndDiscountProportion = e.Quantity * Math.Round(e.IndDiscountProportion, 2),
                                      IndDiscountProportion = Math.Round(e.IndDiscount, 2),
                                      Profit = e.Quantity * Math.Round((e.Price - (e.CostPrice + (e.IndDiscount / e.Quantity))), 2),
                                      SalesRepName = e.SalesReturnModel.SalesRep.EmployeeName,
                                      SalesRepCommission = e.CommissionAmount,
                                      //PurchasePrice = e.PurchaseItems.Price,
                                      //WarrentyName = e.Products.Warrenty.Name,
                                      //WarrentyDay = e.Products.Warrenty.Day,
                                      //ProductAge = (DateTime.Now.Date - e.SalesModel.SalesDate).Days,
                                      //ProductAge = null,//(DateTime.Now.Date - DateTime.Parse("12-june-21").Date).Days.ToString(),
                                      salesdateformat = e.SalesReturnModel.SalesReturnDate


                                      //SalesDate = e.SalesDate,
                                      //PurchaseDate = e.PurchaseItems.PurchaseModel.PurchaseDate.ToString("dd-MMM-yy")


                                  };



                //var abc = query.ToList();


                //var parser = new Parser<SalesDetailsResultList>(Request.Form, query);

                var returnparser = new Parser<SalesDetailsResultList>(Request.Form, returnquery);

                //var abc = parser.Parse();
                //var xyz = returnparser.Parse();

                //abc.data.AddRange(xyz.data);
                //var xyz = returnquery.ToList();

                //abc.AddRange(xyz);

                //return Json(abc.Parse());



                return Json(returnparser.Parse);
            }
            catch (Exception ex)
            {
                return Json(new { Success = "0", error = ex.Message });
                //throw ex;
            }

        }



        public class SerialProductResultList
        {
            public int Id { get; set; }
            public string? SalesCode { get; set; }
            public string? SalesDate { get; set; }


            public string? CustomerName { get; set; }
            public string? CustomerMobileNo { get; set; }
            public string? CustomerAddress { get; set; }

            public string? SupplierName { get; set; }
            public string? SupplierMobileNo { get; set; }
            public string? SupplierAddress { get; set; }

            public string? ProductCode { get; set; }

            public string? ProductName { get; set; }

            public string? ModelName { get; set; }
            public string? BrandName { get; set; }

            public string? SizeName { get; set; }
            public string? ColorName { get; set; }


            public string? BatchSerialNo { get; set; }
            public string? ReplaceSerialNo { get; set; }




            public string? PurchaseCode { get; set; }

            public string? PurchaseDate { get; set; }
            public string? ReplaceDate { get; set; }



            public int WarrentyDay { get; set; }
            public string? WarrentyName { get; set; }


            public string? ProductAge { get; set; }

            public string? WarrentyStatus { get; set; }

            public double? SellingPrice { get; set; }
            public double PurchasePrice { get; set; }
            public DateTime? salesdateformat { get; set; }


        }

        [HttpPost]
        [AllowAnonymous]
        public IActionResult AddSaleOld([FromBody] SalesModel model)
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

                        var items = saleItemRepository.AllSubData().Where(x => x.SalesId == model.Id).ToList();
                        if (items.Any())
                        {
                            foreach (var item in items)
                            {
                                saleItemRepository.Delete(item);
                            }
                        }

                        var sale = saleRepository.Find(model.Id);
                        sale.CustomerName = model.CustomerName;
                        sale.PrimaryAddress = model.PrimaryAddress;
                        sale.PhoneNo = model.PhoneNo;

                        sale.Notes = model.Notes;
                        //sale.PaymentMethod = model.PaymentMethod;
                        sale.SaleCode = model.SaleCode;
                        sale.CustomerId = model.CustomerId;
                        sale.Total = model.Total;
                        sale.SalesDate = model.SalesDate;
                        sale.StatusRemarks = model.StatusRemarks;
                        sale.Discount = model.Discount;

                        sale.ServiceCharge = model.ServiceCharge;
                        sale.Shipping = model.Shipping;
                        sale.TotalVat = model.TotalVat;



                        sale.GrandTotal = model.GrandTotal;

                        sale.NetAmount = model.NetAmount;
                        sale.PaidAmt = model.PaidAmt;
                        sale.DisAmt = model.DisAmt;
                        sale.DueAmt = model.DueAmt;





                        //add again
                        foreach (var item in model.Items)
                        {
                            sale.Items.Add(new SalesItemsModel
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
                                ComId = int.Parse(ComId.ToString())
                            });
                        }
                        saleRepository.Update(sale, model.Id);



                        TempData["Message"] = "Data Update Successfully";
                        TempData["Status"] = "2";
                        tranlog.TransactionLog(RouteData.Values["controller"].ToString(), RouteData.Values["action"].ToString(), TempData["Message"].ToString(), model.Id.ToString(), "Update", model.SaleCode);

                        return Json(new { error = false, message = "Sales updated successfully" });
                    }
                    else
                    {

                        var UserId = HttpContext.Session.GetInt32("UserId");
                        var ComId = HttpContext.Session.GetInt32("ComId");

                        foreach (var item in model.Items)
                        {

                            item.CreateDate = DateTime.Now;
                            item.UpdateDate = DateTime.Now;
                            item.ComId = int.Parse(ComId.ToString());
                        }

                        saleRepository.Insert(model);


                        TempData["Message"] = "Data Save Successfully";
                        TempData["Status"] = "1";
                        tranlog.TransactionLog(RouteData.Values["controller"].ToString(), RouteData.Values["action"].ToString(), TempData["Message"].ToString(), model.Id.ToString(), "Create", model.SaleCode.ToString());


                        return Json(new { error = false, message = "Sales saved successfully" });
                    }

                }
                else
                {
                    return Json(new { error = true, message = "failed to save Sales" });
                }



            }
            catch (Exception)
            {

                return Json(new { error = true, message = "failed to save/update Sales" });
            }
        }





        [HttpPost]
        [AllowAnonymous]
        public IActionResult AddSale([FromBody] SalesModel model)
        {
            try
            {
                var UserId = HttpContext.Session.GetInt32("UserId");
                var ComId = HttpContext.Session.GetInt32("ComId");

                int? vatview = HttpContext.Session.GetInt32("VatViewActivate");
                if (vatview == null || vatview == 0) { }
                else { model.IsVatSales = true; }


                var errors = ModelState.Where(x => x.Value.Errors.Any())
                .Select(x => new { x.Key, x.Value.Errors });

                if (ModelState.IsValid)
                {
                    if (model.Id > 0)
                    {

                        SqlParameter[] sqlParameter = new SqlParameter[4];
                        sqlParameter[0] = new SqlParameter("@ComId", ComId);
                        sqlParameter[1] = new SqlParameter("@Id", model.Id);
                        sqlParameter[2] = new SqlParameter("@ProcessFor", "Sales");
                        sqlParameter[3] = new SqlParameter("@SaveUpdateDelete", "Update");
                        Helper.ExecProc("prcSerialProcess", sqlParameter);


                        saleRepository.Update(model, model.Id);




                        foreach (SalesItemsModel item in model.Items)
                        {

                            if (item.Id > 0)
                            {
                                if (item.IsDelete == true || item.Quantity == 0)
                                {
                                    int z = item.Id;
                                    saleItemRepository.Delete(item);

                                }
                                else
                                {
                                    if (item.IsTransaction == true)//item.IsDelete == false &&  
                                    {

                                        if (item.SerialItem != null)
                                        {

                                            var batchitemlist = _salesBatchItemRepository.All().Where(x => x.SalesItemId == item.Id).ToList();
                                            _salesBatchItemRepository.RemoveRange(batchitemlist);

                                        }


                                        foreach (SalesBatchItemsModel batchitem in item.BatchSerialItems)
                                        {
                                            if (batchitem.Id > 0)
                                            {
                                                if (batchitem.IsDelete == true)
                                                {
                                                    int z = batchitem.Id;
                                                    _salesBatchItemRepository.Delete(batchitem);

                                                }
                                                else
                                                {
                                                    if (batchitem.IsTransaction == true)
                                                    {
                                                        batchitem.ComId = ComId.GetValueOrDefault();
                                                        _salesBatchItemRepository.Update(batchitem, batchitem.Id);
                                                    }
                                                }
                                            }
                                            else if (batchitem.Id == 0 && batchitem.IsDelete == false)
                                            {
                                                batchitem.ComId = ComId.GetValueOrDefault();
                                                _salesBatchItemRepository.Insert(batchitem);
                                            }


                                        }

                                        saleItemRepository.Update(item, item.Id);

                                    }
                                }
                            }
                            else
                            {
                                if (item.IsDelete == true || item.Quantity == 0)
                                {
                                }
                                else
                                {

                                    saleItemRepository.Insert(item);

                                    //foreach (SalesBatchItemsModel batchitem in item.BatchSerialItems)
                                    //{
                                    //    if (batchitem.IsDelete == true)
                                    //    {

                                    //    }
                                    //    else
                                    //    {
                                    //        saleItemRepository.Insert(item);

                                    //    }


                                    //}

                                }
                            }
                        }



                        var salespaymentsdata = salesPaymentRepository.All().Where(x => x.SalesId == model.Id && x.TransactionId == null).ToList();
                        salesPaymentRepository.RemoveRange(salespaymentsdata);


                        foreach (SalesPaymentModel item in model.SalesPayments.Where(x => x.IsDelete == false))
                        {

                            salesPaymentRepository.Insert(item);


                            //if (item.Id > 0)
                            //{
                            //    if (item.IsDelete == true)
                            //    {
                            //        int z = item.Id;
                            //        salesPaymentRepository.Delete(item);

                            //    }
                            //    else
                            //    {
                            //        salesPaymentRepository.Update(item, item.Id);

                            //    }
                            //}
                            //else
                            //{
                            //    if (item.IsDelete == true)
                            //    {
                            //    }
                            //    else
                            //    {

                            //        salesPaymentRepository.Insert(item);

                            //    }
                            //}
                        }



                        var salestermsdata = salesTermsRepository.All().Where(x => x.SalesId == model.Id).ToList();
                        salesTermsRepository.RemoveRange(salestermsdata);
                        foreach (SalesTermsModel item in model.SalesTerms.Where(x => x.IsDelete == false))
                        {
                            salesTermsRepository.Insert(item);
                        }


                        TempData["Message"] = "Data Update Successfully";
                        TempData["Status"] = "2";
                        tranlog.TransactionLog(RouteData.Values["controller"].ToString(), RouteData.Values["action"].ToString(), TempData["Message"].ToString(), model.Id.ToString(), "Update", model.SaleCode);
                        SendingFunction("Invoice", model.Id, "Update");


                        SqlParameter[] sqlParameter1 = new SqlParameter[4];
                        sqlParameter1[0] = new SqlParameter("@ComId", ComId);
                        sqlParameter1[1] = new SqlParameter("@Id", model.Id);
                        sqlParameter1[2] = new SqlParameter("@ProcessFor", "Sales");
                        sqlParameter1[3] = new SqlParameter("@SaveUpdateDelete", "Save");
                        Helper.ExecProc("prcSerialProcess", sqlParameter1);



                        ///profit Calculation
                        SqlParameter[] sqlParameter2 = new SqlParameter[2];
                        sqlParameter2[0] = new SqlParameter("@ComId", ComId);
                        sqlParameter2[1] = new SqlParameter("@SalesId", model.Id);
                        Helper.ExecProc("[Sales_ProcessRuntimeProfitCalculation]", sqlParameter2);


                        return Json(new { Success = 2, Id = model.Id, message = "Date Update successfully" });
                    }
                    else
                    {

                        //var UserId = HttpContext.Session.GetInt32("UserId");
                        //var ComId = HttpContext.Session.GetInt32("ComId");

                        foreach (var item in model.Items)
                        {


                            //if (item.BatchSerialItems.Count == 0)
                            //{
                            //    foreach (var serialdata in item.SerialItem)
                            //    {
                            //        SalesBatchItemsModel abc = new SalesBatchItemsModel();
                            //        abc.ProductId = item.ProductId;
                            //        abc.PurchaseBatchId = serialdata;


                            //        item.BatchSerialItems.Add(abc);
                            //    }
                            //}

                            item.CreateDate = DateTime.Now;
                            item.UpdateDate = DateTime.Now;
                            //item.ComId = int.Parse(ComId.ToString());

                            if (item.BatchSerialItems != null)
                            {
                                foreach (var Batchitem in item.BatchSerialItems)
                                {

                                    Batchitem.CreateDate = DateTime.Now;
                                    Batchitem.UpdateDate = DateTime.Now.Date;
                                    //Batchitem.ComId = int.Parse(ComId.ToString());

                                }
                            }

                        }




                        saleRepository.Insert(model);


                        if (model.OrderId != null)
                        {
                            var onlineorder = onlineOrderRepository.All().Where(x => x.Id == model.OrderId).FirstOrDefault();
                            onlineorder.isPosted = true;

                            onlineOrderRepository.Update(onlineorder, onlineorder.Id);

                        }



                        TempData["Message"] = "Data Save Successfully";
                        TempData["Status"] = "1";
                        tranlog.TransactionLog(RouteData.Values["controller"].ToString(), RouteData.Values["action"].ToString(), TempData["Message"].ToString(), model.Id.ToString(), "Create", model.SaleCode);



                        SendingFunction("Invoice", model.Id, "Save");




                        SqlParameter[] sqlParameter1 = new SqlParameter[4];
                        sqlParameter1[0] = new SqlParameter("@ComId", ComId);
                        sqlParameter1[1] = new SqlParameter("@Id", model.Id);
                        sqlParameter1[2] = new SqlParameter("@ProcessFor", "Sales");
                        sqlParameter1[3] = new SqlParameter("@SaveUpdateDelete", "Save");
                        Helper.ExecProc("prcSerialProcess", sqlParameter1);


                        ///profit Calculation
                        SqlParameter[] sqlParameter2 = new SqlParameter[2];
                        sqlParameter2[0] = new SqlParameter("@ComId", ComId);
                        sqlParameter2[1] = new SqlParameter("@SalesId", model.Id);
                        Helper.ExecProc("[Sales_ProcessRuntimeProfitCalculation]", sqlParameter2);



                        return Json(new { Success = 1, Id = model.Id, message = "Data Save successfully" });

                        //return Json(new {Success=1, error = false, message = "Data Save successfully" });
                    }

                }
                else
                {
                    return Json(new { error = true, message = "failed to Save the Data" });
                }



            }
            catch (Exception ex)
            {

                return Json(new { error = true, message = ex.Message });
            }
        }


        #region custom function
        public void SendingFunction(string smstype, int Id, string CommandType)
        {
            try
            {



                var UserId = HttpContext.Session.GetInt32("UserId");
                var ComId = HttpContext.Session.GetInt32("ComId");


                if (smstype == "Invoice")
                {
                    var salesdata = saleRepository.All().Where(x => x.Id == Id).Include(x => x.CustomerModel).Include(x => x.CompanyList).FirstOrDefault();
                    var storeinfo = _storeSettingRepository.All().Where(x => x.ComId == ComId).FirstOrDefault();

                    //var companydata = companyRepository.Find(ComId.GetValueOrDefault());
                    //var callBackUrl = Url.ActionLink("Login", "Home");
                    //var customerdata = customerRepository.Find(salesdata.CustomerId);

                    if (storeinfo.isEmailSerivce == true)
                    {
                        if (salesdata.CustomerModel.Email != null && salesdata.CustomerModel.Email.Length > 10)
                        {
                            string mailList = salesdata.CustomerModel.Email;
                            string subject = $"Sales order";
                            string body = $"<br/>Thanks for placing order.<br/><br/>Invoice Date :<b>{salesdata.SalesDate}</b> <br/> <h1> Invoice No : <b>{salesdata.SaleCode}</b></h1> <br/> Invoice Amount : <b>{salesdata.NetAmount}</b> <br/> Received Amount : <b>{salesdata.PaidAmount}</b> <br/> Balance Amount : <b>{salesdata.NetAmount - salesdata.PaidAmount}</b>  <br/> <br/> Sincerely,<br/>{salesdata.CompanyList.CompanyName} ";
                            //var hostaddressforsender = Request.GetTypedHeaders().Host.Value;
                            _emailsender.SendEmailAsync(mailList, subject, body);
                        }
                    }

                    if (storeinfo.isSMSService == true)
                    {
                        CreditUsedModel sendsmsmodel = new CreditUsedModel();
                        sendsmsmodel.SMSText = $"Sales Order{Environment.NewLine}Thanks for placing order.{Environment.NewLine}Bill Date:{salesdata.SalesDate.ToString("dd-MMM-yy")}{Environment.NewLine}Bill No:{salesdata.SaleCode}{Environment.NewLine}Bill Amount:{salesdata.NetAmount.ToString()}{Environment.NewLine}Rcvd. :{salesdata.PaidAmount}{Environment.NewLine}Due:{(salesdata.NetAmount - salesdata.PaidAmount).ToString()}{Environment.NewLine}{salesdata.CompanyList.CompanyName}";
                        sendsmsmodel.TextLength = sendsmsmodel.SMSText.Length;
                        sendsmsmodel.Quantity = (sendsmsmodel.SMSText.Length / 160) + 1;
                        sendsmsmodel.SendingDate = DateTime.Now;
                        sendsmsmodel.CommandType = CommandType;
                        sendsmsmodel.Remarks = salesdata.CustomerModel.Phone + " " + salesdata.CustomerModel.Name + " Customer Id : " + salesdata.CustomerModel.Id;

                        if (salesdata.CustomerModel.Phone != null && salesdata.CustomerModel.Phone.Length > 10)
                        {
                            //var balancesms = _CreditBalanceRepository.All().Where(x => x.ValidityDate <= DateTime.Now.Date && (x.SMSPurchaseQuantity - x.SMSUsedQuantity) > 0).OrderBy(x => x.ValidityDate).FirstOrDefault();
                            var balancesms = _CreditBalanceRepository.All().Where(x => (x.PurchaseQuantity - x.UsedQuantity) > 0 && x.ValidityDate >= DateTime.Now.Date && x.ComId == ComId && x.Type == "SMS").OrderBy(x => x.ValidityDate).FirstOrDefault();

                            if (balancesms != null)
                            {
                                if (balancesms.PurchaseQuantity - balancesms.UsedQuantity > 0)
                                {
                                    _smsSender.SendSmsAsync(salesdata.CustomerModel.Phone, sendsmsmodel.SMSText);


                                    balancesms.UsedQuantity = balancesms.UsedQuantity + sendsmsmodel.Quantity;
                                    _CreditBalanceRepository.Update(balancesms, balancesms.Id);

                                    _creditUsedRepository.Insert(sendsmsmodel);
                                }
                            }

                        }







                    }

                }
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }
        #endregion



        [HttpPost]
        public JsonResult POSCreate(SalesModel model)
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

                        var items = saleItemRepository.AllSubData().Where(x => x.SalesId == model.Id).ToList();
                        if (items.Any())
                        {
                            foreach (var item in items)
                            {
                                saleItemRepository.Delete(item);
                            }
                        }

                        var salespayment = salesPaymentRepository.AllSubData().Where(x => x.SalesId == model.Id).ToList();
                        if (salespayment.Any())
                        {
                            foreach (var item in salespayment)
                            {
                                salesPaymentRepository.Delete(item);
                            }
                        }

                        var sale = saleRepository.Find(model.Id);

                        sale.CustomerName = model.CustomerName;
                        sale.PrimaryAddress = model.PrimaryAddress;
                        sale.PhoneNo = model.PhoneNo;


                        sale.Notes = model.Notes;
                        //sale.PaymentMethod = model.PaymentMethod;
                        sale.SaleCode = model.SaleCode;
                        sale.CustomerId = model.CustomerId;
                        sale.Total = model.Total;
                        sale.SalesDate = model.SalesDate;
                        sale.StatusRemarks = model.StatusRemarks;
                        sale.Discount = model.Discount;


                        sale.ServiceCharge = model.ServiceCharge;
                        sale.Shipping = model.Shipping;
                        sale.TotalVat = model.TotalVat;

                        sale.GrandTotal = model.GrandTotal;
                        sale.DisPer = model.DisPer;
                        sale.DisAmt = model.DisAmt;
                        sale.DueAmt = model.DueAmt;



                        //sale.ttlCountQty = model.ttlCountQty;
                        //sale.ttlIndDisAmt = model.ttlIndDisAmt;
                        //sale.ttlIndPrice = model.ttlIndPrice;

                        //sale.ttlIndVat = model.ttlIndVat;
                        //sale.ttlSumAmt = model.ttlSumAmt;
                        //sale.ttlSumQty = model.ttlSumQty;
                        //sale.ttlUnitPrice = model.ttlUnitPrice;
                        sale.LuserIdUpdate = int.Parse(UserId.ToString());



                        //add again
                        foreach (var item in model.Items)
                        {
                            sale.Items.Add(new SalesItemsModel
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
                                ComId = int.Parse(ComId.ToString())

                            });
                        }

                        foreach (var item in model.SalesPayments)
                        {
                            sale.SalesPayments.Add(new SalesPaymentModel
                            {
                                //PaymentTypeId = item.PaymentTypeId,
                                Amount = item.Amount,
                                RowNo = item.RowNo,
                                AccountHeadId = item.AccountHeadId,
                                PaymentCardNo = item.PaymentCardNo,
                                CreateDate = DateTime.Now,
                                UpdateDate = DateTime.Now,
                                ComId = int.Parse(ComId.ToString())
                            });
                        }


                        saleRepository.Update(sale, model.Id);



                        TempData["Message"] = "Data Update Successfully";
                        TempData["Status"] = "2";
                        tranlog.TransactionLog(RouteData.Values["controller"].ToString(), RouteData.Values["action"].ToString(), TempData["Message"].ToString(), model.Id.ToString(), "Update", model.SaleCode.ToString());

                        return Json(new { Success = 1, Id = model.Id, error = false, message = "Sales updated successfully" });
                    }
                    else
                    {
                        model.isPOSSales = true;
                        var UserId = HttpContext.Session.GetInt32("UserId");
                        var ComId = HttpContext.Session.GetInt32("ComId");

                        foreach (var item in model.Items)
                        {

                            item.CreateDate = DateTime.Now;
                            item.UpdateDate = DateTime.Now;
                            item.ComId = int.Parse(ComId.ToString());
                        }

                        foreach (var item in model.SalesPayments)
                        {

                            item.CreateDate = DateTime.Now;
                            item.UpdateDate = DateTime.Now;
                            item.ComId = int.Parse(ComId.ToString());
                        }

                        saleRepository.Insert(model);


                        TempData["Message"] = "Data Save Successfully";
                        TempData["Status"] = "1";
                        tranlog.TransactionLog(RouteData.Values["controller"].ToString(), RouteData.Values["action"].ToString(), TempData["Message"].ToString(), model.Id.ToString(), "Create", model.SaleCode);


                        return Json(new { Success = 1, Id = model.Id, error = false, message = "Sales saved successfully" });
                    }

                }
                return Json(new { Success = 0, error = true, message = "failed to save Sales" });

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return Json(new { Success = 0, error = true, message = "failed to save/update Sales" });
            }





            //try
            //{
            //    var errors = ModelState.Where(x => x.Value.Errors.Any())
            //    .Select(x => new { x.Key, x.Value.Errors });

            //    if (ModelState.IsValid)
            //    {

            //        // If sales main has SalesID then we can understand we have existing sales Information
            //        // So we need to Perform Update Operation

            //        // Perform Update
            //        if (salesmain.Id > 0)
            //        {

            //            IQueryable<SalesSub> CurrentsalesSUb = db.SalesSubs.Where(p => p.SalesId == salesmain.SalesId);
            //            IQueryable<SalesTermsSub> CurrentsalesTermsSUb = db.SalesTermsSubs.Where(p => p.SalesId == salesmain.SalesId);
            //            IQueryable<SalesPaymentSub> CurrentsalesPaymentSUb = db.SalesPaymentSubs.Where(p => p.SalesId == salesmain.SalesId);


            //            foreach (SalesSub ss in CurrentsalesSUb)
            //            {
            //                db.SalesSubs.Remove(ss);


            //                ///inventory calculation after remove the data
            //                Inventory inv = db.Inventory.Where(x => x.ProductId == ss.ProductId && x.WareHouseId == ss.WarehouseId).FirstOrDefault();
            //                if (inv != null)
            //                {
            //                    inv.SalesQty = inv.SalesQty - ss.Qty;
            //                    db.Entry(inv).State = EntityState.Modified;
            //                }
            //            }

            //            foreach (SalesTermsSub sss in CurrentsalesTermsSUb)
            //            {
            //                db.SalesTermsSubs.Remove(sss);
            //            }

            //            foreach (SalesPaymentSub ssss in CurrentsalesPaymentSUb)
            //            {
            //                db.SalesPaymentSubs.Remove(ssss);
            //            }

            //            foreach (SalesSub ss in salesmain.SalesSubs)
            //            {
            //                db.SalesSubs.Add(ss);

            //                ///inventory calculation after add the data
            //                Inventory inv = db.Inventory.Where(x => x.ProductId == ss.ProductId && x.WareHouseId == ss.WarehouseId).FirstOrDefault();
            //                if (inv != null)
            //                {
            //                    inv.SalesQty = inv.SalesQty + ss.Qty;
            //                    //inv.CurrentStock = (inv.OpStock + inv.PurQty + inv.PurExcQty + inv.SalesRetQty) - (inv.SalesQty + inv.SalesExcQty + inv.PurRetQty);
            //                    inv.CurrentStock = (inv.OpStock + inv.PurQty + inv.PurExcQty + inv.SalesRetQty + inv.GoodsReceiveQty + inv.IssueRtnQty) - (inv.SalesQty + inv.SalesExcQty + inv.PurRetQty + inv.IssueQty + inv.GoodsRcvRtnQty);

            //                    db.Entry(inv).State = EntityState.Modified;
            //                }
            //            }
            //            ///terms subs
            //            if (salesmain.SalesTermsSubs == null)
            //            { }
            //            else
            //            {

            //                foreach (SalesTermsSub sss in salesmain.SalesTermsSubs)
            //                {
            //                    db.SalesTermsSubs.Add(sss);
            //                }
            //            }
            //            ///payments
            //            if (salesmain.SalesPaymentSubs == null)
            //            { }
            //            else
            //            {

            //                foreach (SalesPaymentSub ssss in salesmain.SalesPaymentSubs)
            //                {
            //                    db.SalesPaymentSubs.Add(ssss);
            //                }
            //            }


            //            db.Entry(salesmain).State = EntityState.Modified;
            //        }
            //        //Perform Save
            //        else
            //        {
            //            db.SalesMains.Add(salesmain);


            //            ///inventory calculation after Added New data in Save mode
            //            foreach (SalesSub ss in salesmain.SalesSubs)
            //            {
            //                db.SalesSubs.Add(ss);
            //                ////if no warehouse found then it will throw error
            //                //Inventory inv = db.Inventory.Where(x => x.ProductId == ss.ProductId && x.WareHouseId == ss.WarehouseId).FirstOrDefault();
            //                //if (inv != null) ///added by fahad for solving error if no ware house found then no update of the data
            //                //{
            //                //    inv.SalesQty = inv.SalesQty + ss.Qty;
            //                //    //inv.CurrentStock = (inv.OpStock + inv.PurQty + inv.PurExcQty + inv.SalesRetQty) - (inv.SalesQty + inv.SalesExcQty + inv.PurRetQty);
            //                //    //inv.CurrentStock = (inv.OpStock + inv.PurQty + inv.PurExcQty + inv.SalesRetQty + inv.GoodsReceiveQty + inv.IssueRtnQty) - (inv.SalesQty + inv.SalesExcQty + inv.PurRetQty + inv.IssueQty + inv.GoodsRcvRtnQty);

            //                //    db.Entry(inv).State = EntityState.Modified;
            //                //}

            //            }

            //        }

            //        db.SaveChanges();

            //        // If Sucess== 1 then Save/Update Successfull else there it has Exception
            //        return Json(new { Success = 1, SalesID = salesmain.SalesId, ex = "" });
            //    }
            //}
            //catch (Exception ex)
            //{

            //    // If Sucess== 0 then Unable to perform Save/Update Operation and send Exception to View as JSON
            //    return Json(new { Success = 0, ex = ex.Message.ToString() });
            //}

            //return Json(new { Success = 0, ex = new Exception("Unable to save").Message.ToString() });
        }

        public async Task<IActionResult> POSEdit(int? SaleId)
        {
            if (SaleId == null)
            {
                return NotFound();
            }

            SalesModel salesmain = await saleRepository.All()
            .Include(x => x.Items).ThenInclude(x => x.Product)
            //.Include(x => x.SalesPayments).ThenInclude(x => x.vPaymentType)
            .Include(x => x.SalesPayments).ThenInclude(x => x.vChartofAccounts)
            .Include(x => x.Items).ThenInclude(x => x.vWarehouse)
            .Where(x => x.Id == SaleId).FirstOrDefaultAsync();

            if (salesmain.IsDelete == true)
            {
                return NotFound();
            }
            var comid = HttpContext.Session.GetString("ComId");
            var userid = HttpContext.Session.GetString("UserId");

            object a = HttpContext.Session.GetString("isProductSearch");
            ViewBag.ActionType = "Edit";

            ViewBag.Customer = customerRepository.GetAllForDropDown();
            ViewBag.Category = categoryRepository.GetAllForDropDown();
            var Productresult = productRepository.All().Take(30);

            ViewBag.Product = new SelectList(Productresult.Where(x => x.Id > 0).Select(s => new { Text = s.Code.Length < 4 ? s.Name : s.Name + " - [ " + s.Code + " ]", Value = s.Id }).ToList(), "Value", "Text");
            ViewBag.ProductSearch = Productresult;
            //if (_FromWarehousePermissionRepository.GetAllForDropDown().Count() > 0) { ViewBag.Warehouse = _FromWarehousePermissionRepository.GetAllForDropDown(); } else { ViewBag.Warehouse = _warehouseRepository.GetWarehouseLedgerHeadForDropDown(); }
            var x = _FromWarehousePermissionRepository.GetAllForDropDown();
            if (x.Count() == 0)
            {
                x = _warehouseRepository.GetWarehouseLedgerHeadForDropDown();
            }
            ViewBag.Warehouse = x;


            ViewBag.PaymentTypes = paymentTypeRepository.GetAllForDropDown();
            ViewBag.AccountHead = accountHeadRepository.GetCashBankHeadForDropDown(false);
            if (salesmain == null)
            {
                return NotFound();
            }

            //Call Create View
            return View("POSCreate", salesmain);
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

            SalesModel salesmain = await saleRepository.All()
            .Include(x => x.Items).ThenInclude(x => x.Product)
            //.Include(x => x.SalesPayments).ThenInclude(x => x.vPaymentType)
            .Include(x => x.SalesPayments).ThenInclude(x => x.vChartofAccounts)
            .Include(x => x.Items).ThenInclude(x => x.vWarehouse)
            .Where(x => x.Id == id).FirstOrDefaultAsync();

            if (salesmain == null)
            {
                return NotFound();
            }
            var comid = HttpContext.Session.GetString("ComId");
            var userid = HttpContext.Session.GetString("userid");

            //object a = HttpContext.Session.GetString("isProductSearch");
            ViewBag.ActionType = "Delete";

            ViewBag.Customer = customerRepository.GetAllForDropDown();
            ViewBag.Category = categoryRepository.GetAllForDropDown();
            var Productresult = productRepository.All().Take(30);

            ViewBag.Product = new SelectList(Productresult.Where(x => x.Id > 0).Select(s => new { Text = s.Code.Length < 4 ? s.Name : s.Name + " - [ " + s.Code + " ]", Value = s.Id }).ToList(), "Value", "Text");
            ViewBag.ProductSearch = Productresult;
            ///if (_FromWarehousePermissionRepository.GetAllForDropDown().Count() > 0) { ViewBag.Warehouse = _FromWarehousePermissionRepository.GetAllForDropDown(); } else { ViewBag.Warehouse = _warehouseRepository.GetWarehouseLedgerHeadForDropDown(); }

            var x = _FromWarehousePermissionRepository.GetAllForDropDown();
            if (x.Count() == 0)
            {
                x = _warehouseRepository.GetWarehouseLedgerHeadForDropDown();
            }
            ViewBag.Warehouse = x;

            ViewBag.PaymentTypes = paymentTypeRepository.GetAllForDropDown();
            ViewBag.AccountHead = accountHeadRepository.GetCashBankHeadForDropDown(false);
            if (salesmain == null)
            {
                return NotFound();
            }

            //Call Create View
            return View("POSCreate", salesmain);
        }


        [HttpGet]
        [Authorize]
        public IActionResult EditSale(int saleId, int IsCopy = 0)
        {

            ViewBag.ActionType = "Edit";
            ViewBag.customers = customerRepository.GetAllForDropDown();
            ///if (_FromWarehousePermissionRepository.GetAllForDropDown().Count() > 0) { ViewBag.Warehouse = _FromWarehousePermissionRepository.GetAllForDropDown(); } else { ViewBag.Warehouse = _warehouseRepository.GetWarehouseLedgerHeadForDropDown(); }

            var x = _FromWarehousePermissionRepository.GetAllForDropDown();
            if (x.Count() == 0)
            {
                x = _warehouseRepository.GetWarehouseLedgerHeadForDropDown();
            }
            ViewBag.Warehouse = x;

            ViewBag.Category = categoryRepository.GetAllForDropDown();
            ViewBag.Unit = _unitRepository.GetAllForDropDown();
            ViewBag.DocType = _docTypeRepository.GetSalesDocForDropDown();
            ViewBag.SalesRep = _employeeRepository.GetAllForDropDown();
            ViewBag.Currency = _currencyRepository.GetCurrencyList();


            ViewBag.IsCopy = IsCopy;
            if (IsCopy == 2)
            {
                ViewBag.ActionType = "Copy";
            }


            var batchlist = saleItemRepository.AllSubData().Where(x => x.SalesId == saleId).Include(x => x.BatchSerialItems).Select(x => x.BatchSerialItems.Count()).FirstOrDefault();
            var batchlistArray = _salesBatchItemRepository.All().Where(x => x.SalesItems.SalesId == saleId).Count(); //&& x.SerialItem != null


            var batchdata = batchlist;

            var isSerialSales = false;
            isSerialSales = saleRepository.All().Where(x => x.Id == saleId).Select(x => x.isSerialSales).FirstOrDefault();



            var isWholeSales = false;
            isWholeSales = saleRepository.All().Where(x => x.Id == saleId).Select(x => x.isWholeSales).FirstOrDefault();


            if (isSerialSales == true)
            {
                return View("AddSaleBySerialSearch", model: saleId);
            }
            else if (batchdata > 0 && batchlistArray == 0 && isSerialSales == false)
            {
                return View("AddSaleSerial", model: saleId);
            }
            else if (isWholeSales == true)
            {
                return View("AddWholeSale", model: saleId);
            }
            else if (batchlistArray > 0 && isSerialSales == false)
            {
                return View("AddSaleSerialSide", model: saleId);
            }

            return View("AddSale", model: saleId);


            //var sale = saleRepository.All()
            //    .Include(x => x.Items)
            //    .SingleOrDefault(x => x.Id == saleId);

            ////var sale = saleRepository.Find(saleId);
            //if (sale != null)
            //    return View("AddSale",model: sale);
            //return RedirectToAction("index");

        }


        [HttpGet]
        [AllowAnonymous]
        public IActionResult InvoiceViewReport(int saleId, string ReportType = "", int IsMobile = 0)
        {

            try
            {
                HttpContext.Session.SetInt32("IsMobile", IsMobile);

                var salesquery = saleRepository.All()
                    .Include(x => x.CompanyList).ThenInclude(x => x.storeinfo).ThenInclude(x => x.SalesReportStyle)
                    .Include(x => x.DocTypeList)
                    .Include(x => x.CustomerModel)
                    .Include(x => x.Items).ThenInclude(x => x.Product).ThenInclude(x => x.Unit)
                    .Include(x => x.Items).ThenInclude(x => x.Product).ThenInclude(x => x.Warrenty)
                    .Include(x => x.Items).ThenInclude(x => x.Product).ThenInclude(x => x.Brand)
                    .Include(x => x.Items).ThenInclude(x => x.BatchSerialItems).ThenInclude(x => x.PurchaseBatchItems)
                    .Include(x => x.Items).ThenInclude(x => x.vWarehouse)
                    .Include(x => x.SalesPayments).ThenInclude(x => x.vChartofAccounts)
                    .Include(x => x.SalesPayments).ThenInclude(x => x.Transaction)
                    .Include(x => x.Items).ThenInclude(x => x.BatchSerialItems).ThenInclude(x => x.PurchaseBatchItems)
                    .Include(x => x.Currency)
                    .Include(x => x.SalesTerms)
                    .Where(x => x.Id == saleId).FirstOrDefault();

                ViewBag.TermsMain = termsmainRepository.All().Include(x => x.TermsSubs).FirstOrDefault();

                if (ReportType == "" || ReportType == null)
                {
                    ViewBag.ReportType = "SALES INVOICE";

                }
                else
                {
                    ViewBag.ReportType = ReportType;

                }

                //SalesModel sales = salesquery.FirstOrDefault();

                //if (sales == null)
                //{
                //    return Json("No Data Found");
                //}

                ////sales.Items = saleItemRepository.AllSubData().Where(x => x.SalesId == sales.Id).ToList();
                //sales.Items = saleItemRepository.AllSubData()
                //    .Include(x => x.Product).Include(x => x.vWarehouse)
                //    .Include(x => x.BatchSerialItems)
                //    .Where(x => x.SalesId == sales.Id).ToList();


                //sales.SalesPayments = salesPaymentRepository.AllSubData()
                //    //.Include(x => x.vPaymentType)
                //    .Include(x => x.vChartofAccounts)
                //    .Where(x => x.SalesId == sales.Id && x.TransactionId == null).ToList();


                //var batchlistArray = saleItemRepository.AllSubData().Where(x => x.SalesId == saleId && x.SerialItem.Length != 0).Count();

                //if (batchlistArray != null)
                //{
                //foreach (var item in salesquery.Items)
                //{
                //    if (item.SerialItem != null)
                //    {
                //        var serialitems = item.SerialItem.Split(',');
                //        //serialitems.Reverse();

                //        item.SerialItemArray = serialitems;
                //    }

                //}
                //}

                //var html = View(salesquery);

                return View(salesquery);

                //SalesItemsModel a = new SalesItemsModel { Name = "abc", Amount = 2.5, Id = 1, IsDelete = false, Price = 2.5, Quantity = 1, SalesId = 5};
                //sales.Items.Add(a);
                ///////////////return Json(sales);
                //return Json(new { Success = 1, sales = sales, ex = "Data Load Successfully" });
            }
            catch (Exception e)
            {
                return Json(e.ToString());
            }


        }



        [HttpGet]
        public IActionResult EditSaleSerial(int saleId)
        {

            ViewBag.ActionType = "Edit";
            ViewBag.customers = customerRepository.GetAllForDropDown();
            ///if (_FromWarehousePermissionRepository.GetAllForDropDown().Count() > 0) { ViewBag.Warehouse = _FromWarehousePermissionRepository.GetAllForDropDown(); } else { ViewBag.Warehouse = _warehouseRepository.GetWarehouseLedgerHeadForDropDown(); }
            var x = _FromWarehousePermissionRepository.GetAllForDropDown();
            if (x.Count() == 0)
            {
                x = _warehouseRepository.GetWarehouseLedgerHeadForDropDown();
            }
            ViewBag.Warehouse = x;

            ViewBag.Category = categoryRepository.GetAllForDropDown();
            ViewBag.Unit = _unitRepository.GetAllForDropDown();
            ViewBag.DocType = _docTypeRepository.GetSalesDocForDropDown();
            ViewBag.SalesRep = _employeeRepository.GetAllForDropDown();
            ViewBag.Currency = _currencyRepository.GetCurrencyList();

            return View("AddSaleSerial", model: saleId);



        }

        [HttpGet]
        public IActionResult EditSaleSerialSide(int saleId)
        {

            ViewBag.ActionType = "Edit";
            ViewBag.customers = customerRepository.GetAllForDropDown();
            ///if (_FromWarehousePermissionRepository.GetAllForDropDown().Count() > 0) { ViewBag.Warehouse = _FromWarehousePermissionRepository.GetAllForDropDown(); } else { ViewBag.Warehouse = _warehouseRepository.GetWarehouseLedgerHeadForDropDown(); }

            var x = _FromWarehousePermissionRepository.GetAllForDropDown();
            if (x.Count() == 0)
            {
                x = _warehouseRepository.GetWarehouseLedgerHeadForDropDown();
            }
            ViewBag.Warehouse = x;

            ViewBag.Category = categoryRepository.GetAllForDropDown();
            ViewBag.Unit = _unitRepository.GetAllForDropDown();
            ViewBag.DocType = _docTypeRepository.GetSalesDocForDropDown();
            ViewBag.SalesRep = _employeeRepository.GetAllForDropDown();
            ViewBag.Currency = _currencyRepository.GetCurrencyList();

            return View("AddSaleSerialSide", model: saleId);



        }



        [HttpPost]
        public IActionResult EditSale(SalesModel model)
        {
            if (model != null)
            {
                var UserId = HttpContext.Session.GetInt32("UserId");
                var ComId = HttpContext.Session.GetInt32("ComId");

                var items = saleItemRepository.AllSubData().Where(x => x.SalesId == model.Id).ToList();
                if (items.Any())
                {
                    foreach (var item in items)
                    {
                        saleItemRepository.Delete(item);
                    }
                }

                var sale = saleRepository.Find(model.Id);
                sale.Notes = model.Notes;
                sale.CustomerName = model.CustomerName;
                sale.PhoneNo = model.PhoneNo;
                sale.PrimaryAddress = model.PrimaryAddress;

                //sale.PaymentMethod = model.PaymentMethod;
                sale.SaleCode = model.SaleCode;
                sale.CustomerId = model.CustomerId;
                sale.Total = model.Total;
                sale.SalesDate = model.SalesDate;
                sale.StatusRemarks = model.StatusRemarks;
                sale.Discount = model.Discount;
                sale.CustomerCommissionAmount = model.CustomerCommissionAmount;
                sale.SRCommissionAmount = model.SRCommissionAmount;


                sale.ServiceCharge = model.ServiceCharge;
                sale.Shipping = model.Shipping;
                sale.TotalVat = model.TotalVat;

                sale.GrandTotal = model.GrandTotal;

                //add again
                foreach (var item in model.Items)
                {
                    sale.Items.Add(new SalesItemsModel
                    {
                        WarehouseId = item.WarehouseId,
                        Price = item.Price,
                        Amount = item.Amount,
                        Quantity = item.Quantity,
                        Name = item.Name,
                        ProductId = item.ProductId,
                        CommissionPer = item.CommissionPer,
                        CommissionAmount = item.CommissionAmount,
                        UserCommissionAmount = item.UserCommissionAmount,

                        PCTN = item.PCTN,
                        CartonQty = item.CartonQty,

                        Description = item.Description,
                        CreateDate = DateTime.Now,
                        UpdateDate = DateTime.Now,
                        ComId = int.Parse(ComId.ToString())
                    });
                }
                saleRepository.Update(sale, model.Id);



                TempData["Message"] = "Data Update Successfully";
                TempData["Status"] = "2";
                tranlog.TransactionLog(RouteData.Values["controller"].ToString(), RouteData.Values["action"].ToString(), TempData["Message"].ToString(), model.Id.ToString(), "Update", model.SaleCode.ToString());

                return Json(new { error = false, message = "Sales updated successfully" });
            }
            return Json(new { error = true, message = "failed to update Sales" });
        }

        public IActionResult DeleteSale(int saleId)
        {
            try
            {


                var salesreceivingamount = _accountsDailyTransaction.All().Where(x => x.SalesId == saleId).ToList();
                if (salesreceivingamount != null)
                {
                    _accountsDailyTransaction.RemoveRange(salesreceivingamount);
                }


                var ComId = HttpContext.Session.GetInt32("ComId");

                SqlParameter[] sqlParameter = new SqlParameter[4];
                sqlParameter[0] = new SqlParameter("@ComId", ComId);
                sqlParameter[1] = new SqlParameter("@Id", saleId);
                sqlParameter[2] = new SqlParameter("@ProcessFor", "Sales");
                sqlParameter[3] = new SqlParameter("@SaveUpdateDelete", "Update");
                Helper.ExecProc("prcSerialProcess", sqlParameter);


                var model = this.saleRepository.All().Where(x => x.Id == saleId && x.isPosted == false).FirstOrDefault(); //.Find(saleId);
                saleRepository.Delete(model);


                if (model.OrderId != null)
                {
                    var onlineorder = onlineOrderRepository.All().Where(x => x.Id == model.OrderId).FirstOrDefault();
                    onlineorder.isPosted = false;

                    onlineOrderRepository.Update(onlineorder, onlineorder.Id);

                }




                TempData["Message"] = "Data Delete Successfully";
                TempData["Status"] = "3";
                tranlog.TransactionLog(RouteData.Values["controller"].ToString(), RouteData.Values["action"].ToString(), TempData["Message"].ToString(), model.Id.ToString(), "Delete", model.SaleCode);

                return RedirectToAction("index");
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        [HttpGet]
        public ActionResult SalesReport(DateTime? From, DateTime? To)
        {
            if (From.HasValue && To.HasValue)
                return View(saleRepository.All().Where(x => x.SalesDate >= From && x.SalesDate <= To));
            return View(new List<SalesModel>());
        }

        [AllowAnonymous]

        public ActionResult SaleInvoice(int saleId, int style)
        {
            if (storeSettingRepository.All().Count() == 0)
            {
                TempData["Msg"] = "Setup store setting first then print sale invoice";
                return RedirectToAction("Index");
            }
            var store = storeSettingRepository.All().FirstOrDefault();

            var sale = saleRepository.All().Include(x => x.CustomerModel).SingleOrDefault(x => x.Id == saleId);
            sale.Items = saleItemRepository.All().Where(x => x.SalesId == saleId).ToList();
            if (sale != null)
            {
                var sales = new SaleReportViewModel
                {
                    company = store,
                    Sales = sale
                };
                //if (style == 1)
                //{
                //    SalesReport paymentReport = new SalesReport(configuration);
                //    byte[] bytes = paymentReport.CreateReport(sales);
                //    return File(bytes, "application/pdf");
                //}
                //if (style == 2)
                //{
                //    SalesReportSmall paymentReport = new SalesReportSmall();
                //    byte[] bytes = paymentReport.CreateReport(sales);
                //    return File(bytes, "application/pdf");
                //}
            }
            return RedirectToAction("index");
        }
        [AllowAnonymous]
        public ActionResult SaleReport(int saleId)
        {
            var UserId = HttpContext.Session.GetInt32("UserId");
            var ComId = HttpContext.Session.GetInt32("ComId");
            //var weburl = HttpContext.Session.GetString("weburl");

            string weburl = configuration.GetSection("hostimage").Value;
            HttpContext.Session.SetString("weburl", weburl);

            var ReportStyle = HttpContext.Session.GetString("SalesReportStyle");



            string reportname = "rptInvoice";
            var filename = "Invoice_";


            if (ReportStyle.ToString().Length > 0)
            {
                reportname = "rptInvoice_" + ReportStyle.ToString();
            }


            //string apppath = "";


            //if (ComId == 23)
            //{ 
            //   reportname = "rptInvoice_globalmedia";

            //}





            HttpContext.Session.SetString("ReportQuery", "Exec  [rptInvoice] '" + saleId + "','" + ComId + "', '" + weburl + "','Invoice'");
            HttpContext.Session.SetString("ReportPath", "~/ReportViewer/POS/" + reportname + ".rdlc");
            HttpContext.Session.SetString("PrintFileName", filename.Replace(".", "").Replace(" ", "").Replace(",", "").Replace("\"", ""));


            //postData.Add(1, new subReport("rptInvoice_Terms", "", "DataSet1", "Exec " + AppData.AppData.dbGTCommercial.ToString() + ".dbo.rptInvoice_Terms '" + id + "','" + Session["comid"].ToString() + "',''"));

            //postData.Add(1, new subReport("rptInvoice_BankDetails", "", "DataSet1", "Exec rptInvoice_BankDetails '" + saleId + "'," + ComId + ",'" + AppData.AppData.AppPath.ToString() + "'"));
            //postData.Add(2, new subReport("rptInvoice_PM", "", "DataSet1", "Exec rptInvoice_PM '" + saleId + "'," + ComId + ""));


            if (reportname.ToLower().Contains("pos"))
            {
                postData.Add(1, new subReport("rptInvoice_POS_PM", "", "DataSet1", "Exec rptInvoice_PM '" + saleId + "'," + ComId + ""));
            }
            else
            {
                postData.Add(1, new subReport("rptInvoice_PM", "", "DataSet1", "Exec rptInvoice_PM '" + saleId + "'," + ComId + ""));
            }

            postData.Add(2, new subReport("rptInvoice_Terms", "", "DataSet1", "Exec rptInvoice_Terms '" + saleId + "'," + ComId + ""));
            postData.Add(3, new subReport("rptInvoice_Tax", "", "DataSet1", "Exec rptInvoice_Tax '" + saleId + "'," + ComId + ""));

            //clsReport.rptList.Add(new subReport("rptInvoice_Terms", "", "DataSet1", "Exec " + AppData.AppData.dbGTCommercial.ToString() + ".dbo.rptInvoice_Terms '" + id + "'," + Session["comid"].ToString() + ",'" + AppData.AppData.AppPath.ToString() + "'"));

            HttpContext.Session.SetObject("rptList", postData);


            return RedirectToAction("Index", "ReportViewer");
        }


        [AllowAnonymous]
        public ActionResult ChallanReport(int saleId)
        {
            var UserId = HttpContext.Session.GetInt32("UserId");
            var ComId = HttpContext.Session.GetInt32("ComId");
            var weburl = HttpContext.Session.GetString("weburl");
            var ReportStyle = HttpContext.Session.GetString("SalesReportStyle");

            string reportname = "rptChallan";
            var filename = "Challan_";

            if (ReportStyle.ToString().Length > 0)
            {
                reportname = "rptChallan_" + ReportStyle.ToString();
            }

            HttpContext.Session.SetString("ReportQuery", "Exec  [rptInvoice] '" + saleId + "','" + ComId + "', '" + weburl + "', 'Challan'");
            HttpContext.Session.SetString("ReportPath", "~/ReportViewer/POS/" + reportname + ".rdlc");
            HttpContext.Session.SetString("PrintFileName", filename.Replace(".", "").Replace(" ", "").Replace(",", "").Replace("\"", ""));

            //postData.Add(2, new subReport("rptInvoice_PM", "", "DataSet1", "Exec rptInvoice_PM '" + saleId + "'," + ComId + ""));
            //HttpContext.Session.SetObject("rptList", postData);

            return RedirectToAction("Index", "ReportViewer");
        }

        [AllowAnonymous]
        public ActionResult OrderReport(int OrderId)
        {
            var UserId = HttpContext.Session.GetInt32("UserId");
            var ComId = HttpContext.Session.GetInt32("ComId");
            //var weburl = HttpContext.Session.GetString("weburl");
            string weburl = configuration.GetSection("host").Value;
            var ReportStyle = HttpContext.Session.GetString("SalesReportStyle");

            string reportname = "rptInvoice";
            var filename = "Invoice_";


            if (ReportStyle.ToString().Length > 0)
            {
                reportname = "rptInvoice_" + ReportStyle.ToString();
            }

            HttpContext.Session.SetString("ReportQuery", "Exec  [rptOnlineOrders] '" + OrderId + "','" + ComId + "', '" + weburl + "','Invoice'");
            HttpContext.Session.SetString("ReportPath", "~/ReportViewer/POS/" + reportname + ".rdlc");
            HttpContext.Session.SetString("PrintFileName", filename.Replace(".", "").Replace(" ", "").Replace(",", "").Replace("\"", ""));

            if (reportname.ToLower().Contains("pos"))
            {
                postData.Add(1, new subReport("rptInvoice_POS_PM", "", "DataSet1", "Exec rptInvoice_PM '" + OrderId + "'," + ComId + ""));
            }
            else
            {
                postData.Add(1, new subReport("rptInvoice_PM", "", "DataSet1", "Exec rptInvoice_PM '" + OrderId + "'," + ComId + ""));
            }
            HttpContext.Session.SetObject("rptList", postData);


            return RedirectToAction("Index", "ReportViewer");
        }

        [HttpGet]
        public IActionResult Report()
        {
            ViewBag.ActionType = "Report";
            ViewBag.Product = productRepository.GetAllProductForDropDown();
            ///if (_FromWarehousePermissionRepository.GetAllForDropDown().Count() > 0) { ViewBag.Warehouse = _FromWarehousePermissionRepository.GetAllForDropDown(); } else { ViewBag.Warehouse = _warehouseRepository.GetWarehouseLedgerHeadForDropDown(); }

            var x = _FromWarehousePermissionRepository.GetAllForDropDown();
            if (x.Count() == 0)
            {
                x = _warehouseRepository.GetWarehouseLedgerHeadForDropDown();
            }
            ViewBag.Warehouse = x;

            ViewBag.Customer = customerRepository.GetAllForDropDown();
            ViewBag.Supplier = supplierRepository.GetAllForDropDown();


            ViewBag.CreditAccount = accountHeadRepository.GetCashBankHeadForDropDown(false);
            ViewBag.AccountReceiveType = accountHeadRepository.GetCashBankHeadForDropDown(false);

            ViewBag.Category = categoryRepository.GetAllForDropDown();




            return View();
        }


        [HttpGet]
        [AllowAnonymous]
        public IActionResult CopyOnlineOrder(int OrderId)
        {
            try
            {
                var ComId = (HttpContext.Session.GetInt32("ComId"));
                var userid = (HttpContext.Session.GetInt32("UserId"));


                var salesquery = onlineOrderRepository.All().Include(x => x.Items).Where(x => x.Id == OrderId);

                OrdersModel orders = salesquery.FirstOrDefault();



                if (orders == null)
                {
                    return Json("No Data Found");
                }


                SalesModel salesinfo = new SalesModel();

                salesinfo.SaleCode = orders.OrderCode;
                salesinfo.SalesDate = DateTime.Now.Date;

                salesinfo.CustomerId = customerRepository.All().Where(x => x.Name.ToLower().Contains("customer")).FirstOrDefault().Id;
                salesinfo.CustomerName = orders.CustomerName;
                salesinfo.PrimaryAddress = orders.PrimaryAddress;
                salesinfo.SecoundaryAddress = orders.SecoundaryAddress;
                salesinfo.PhoneNo = orders.PhoneNo;
                salesinfo.NetAmount = orders.NetAmount;
                salesinfo.GrandTotal = orders.GrandTotal;
                salesinfo.Notes = orders.Notes;
                salesinfo.DisAmt = orders.DisAmt;
                salesinfo.Discount = orders.DisAmt;
                salesinfo.DisPer = orders.DisPer;
                salesinfo.isSerialSales = true;
                salesinfo.TotalCommisionAmount = 0;
                salesinfo.WarehouseIdMain = _warehouseRepository.All().FirstOrDefault().Id;


                var orderlist = new List<SalesItemsModel>();
                //orders.Items = saleItemRepository.AllSubData().Where(x => x.SalesId == orders.Id).ToList();
                //orders.Items = orderItemRepository.AllSubData().Include(x => x.Product).Where(x => x.OrdersId == orders.Id).ToList();
                foreach (var item in orders.Items)
                {
                    SalesItemsModel orderitem = new SalesItemsModel();
                    orderitem.SalesId = 0;
                    orderitem.CreateDate = DateTime.Now;
                    orderitem.IsDelete = item.IsDelete;
                    orderitem.Name = "";
                    orderitem.Price = double.Parse(item.Price.ToString());
                    orderitem.Quantity = double.Parse(item.Quantity.ToString());
                    orderitem.Amount = double.Parse(item.Amount.ToString());

                    orderitem.UpdateDate = DateTime.Now;
                    orderitem.Description = "";
                    orderitem.ComId = item.ComId;
                    //orderitem.LuserId = userid;
                    orderitem.ProductId = item.ProductId;
                    orderitem.WarehouseId = _warehouseRepository.All().FirstOrDefault().Id;
                    orderitem.SerialItem = "";
                    orderitem.CommissionAmount = 0;
                    orderitem.CommissionPer = 0;
                    orderitem.UserCommissionAmount = 0;

                    orderlist.Add(orderitem);
                }

                salesinfo.Items = orderlist;

                saleRepository.Insert(salesinfo);


                orders.isPosted = true;
                onlineOrderRepository.Update(orders, orders.Id);












                //ViewBag.ActionType = "Edit";
                //var saleId = salesinfo.Id;

                ////ViewBag.customers = customerRepository.GetAllForDropDown();
                ////if (_FromWarehousePermissionRepository.GetAllForDropDown().Count() > 0) { ViewBag.Warehouse = _FromWarehousePermissionRepository.GetAllForDropDown(); } else { ViewBag.Warehouse = _warehouseRepository.GetWarehouseLedgerHeadForDropDown(); }

                //var x = _FromWarehousePermissionRepository.GetAllForDropDown();
                //if (x.Count() == 0)
                //{
                //    x = _warehouseRepository.GetWarehouseLedgerHeadForDropDown();
                //}
                //ViewBag.Warehouse = x;

                //ViewBag.Category = categoryRepository.GetAllForDropDown();
                //ViewBag.Unit = _unitRepository.GetAllForDropDown();

                //return View(model: saleId);

                return RedirectToAction("EditSale", new { saleId = salesinfo.Id });
                //return View("AddSaleBySerialSearch", model: saleId);

                //orders.SalesPayments = salesPaymentRepository.AllSubData()
                //    //.Include(x => x.vPaymentType)
                //    .Include(x => x.vChartofAccounts)
                //    .Where(x => x.SalesId == orders.Id).ToList();


                //var batchlistArray = saleItemRepository.AllSubData().Where(x => x.SalesId == saleId && x.SerialItem.Length != 0).Count();

                //if (batchlistArray != null)
                //{

                //}



                //SalesItemsModel a = new SalesItemsModel { Name = "abc", Amount = 2.5, Id = 1, IsDelete = false, Price = 2.5, Quantity = 1, SalesId = 5};
                //orders.Items.Add(a);
                //return Json(orders);
                //return Json(new { Success = 1, sales = sales, ex = "Data Load Successfully" });
            }
            catch (Exception ex)
            {
                throw ex;
                //return Json(e.ToString());
            }

        }

        [HttpGet]
        [AllowAnonymous]
        public JsonResult GetSales(int saleId, int isreturn = 0)
        {
            try
            {
                var salesquery = saleRepository.All().Where(x => x.Id == saleId);

                if (isreturn == 0)
                {
                    salesquery = salesquery.Where(x => x.isPosted == false);
                }
                else if (isreturn == 1)
                {
                    salesquery = salesquery.Where(x => x.isPosted == true);
                }
                else if (isreturn == 2)
                {

                }

                SalesModel sales = salesquery.FirstOrDefault();

                if (sales == null)
                {
                    return Json("No Data Found");
                }

                //sales.Items = saleItemRepository.AllSubData().Where(x => x.SalesId == sales.Id).ToList();
                sales.Items = saleItemRepository.AllSubData()
                    .Include(x => x.Product).Include(x => x.vWarehouse)
                    .Include(x => x.BatchSerialItems)
                    .Where(x => x.SalesId == sales.Id).ToList();


                sales.SalesPayments = salesPaymentRepository.AllSubData()
                    //.Include(x => x.vPaymentType)
                    .Include(x => x.vChartofAccounts)
                    .Where(x => x.SalesId == sales.Id && x.TransactionId == null).ToList();


                sales.SalesTerms = salesTermsRepository.AllSubData()
                .Where(x => x.SalesId == sales.Id).ToList();


                //var batchlistArray = saleItemRepository.AllSubData().Where(x => x.SalesId == saleId && x.SerialItem.Length != 0).Count();

                //if (batchlistArray != null)
                //{
                foreach (var item in sales.Items)
                {
                    if (item.SerialItem != null)
                    {
                        var serialitems = item.SerialItem.Split(',');
                        //serialitems.Reverse();

                        item.SerialItemArray = serialitems;
                    }

                }
                //}



                //SalesItemsModel a = new SalesItemsModel { Name = "abc", Amount = 2.5, Id = 1, IsDelete = false, Price = 2.5, Quantity = 1, SalesId = 5};
                //sales.Items.Add(a);
                return Json(sales);
                //return Json(new { Success = 1, sales = sales, ex = "Data Load Successfully" });
            }
            catch (Exception e)
            {
                return Json(e.ToString());
            }

        }


        [HttpGet]
        [AllowAnonymous]
        public JsonResult GetGatePass(int GatePassId)
        {
            try
            {
                var gatepassquery = gatePassRepository.All().Where(x => x.Id == GatePassId);

                var gatepass = gatepassquery.Select(e => new
                {
                    Id = e.Id,
                    GatePassCode = e.GatePassCode,
                    GatePassDate = e.GatePassDate,
                    Transport = e.Transport,
                    ManualNo = e.ManualNo,
                    Through = e.Through,
                    StyleNo = e.StyleNo,
                    BuyerName = e.BuyerName,
                    ToName = e.ToName,
                    Remarks = e.Remarks,
                    GatePassItems = e.Items.Select(x => new
                    {
                        GatePassId = x.GatePassId,
                        ProductName = x.Product != null ? x.Product.Name : null,
                        ProductId = x.ProductId,
                        SLNo = x.SLNo,
                        Id = x.Id,
                        IsTransaction = x.IsTransaction,
                        ComId = x.ComId,
                        Name = x.Name,
                        ColorName = x.ColorName,
                        SizeName = x.SizeName,
                        Price = x.Price,
                        Quantity = x.Quantity,
                        PackageQuantity = x.PackageQuantity,
                        Description = x.Description
                    }).ToList()
                }).FirstOrDefault();

                return Json(gatepass);
            }
            catch (Exception e)
            {
                return Json(e.ToString());
            }
        }



        //public IActionResult GetGatePass(int GatePassId, bool isCopy)
        //{
        //    try
        //    {
        //        var gatePass = gatePassRepository.GetById(GatePassId);

        //        if (gatePass != null)
        //        {
        //            // Convert the gate pass data to the format expected by the client-side code
        //            var gatePassData = new
        //            {
        //                GatePassNo = gatePass.GatePassCode,
        //                GatePassItems = gatePass.Items,
        //                ToName = gatePass.ToName,
        //                GatePassDate = gatePass.GatePassDate.ToString("yyyy-MM-dd"), // Format the date as a string
        //                StyleNo = gatePass.StyleNo,
        //                BuyerName = gatePass.BuyerName,
        //                Remarks = gatePass.Remarks,
        //                ManualNo = gatePass.ManualNo,
        //                Transport = gatePass.Transport,
        //                Through = gatePass.Through
        //            };

        //            return Json(gatePassData);
        //        }

        //        return Json(null); // Return null if the gate pass is not found
        //    }
        //    catch (Exception ex)
        //    {
        //        return Json(new { error = true, message = ex.Message });
        //    }
        //}









        [HttpGet]
        [AllowAnonymous]
        public JsonResult GetSaleStatus(int saleStatusId)
        {
            try
            {
                var gatepassquery = gatePassRepository.All().Where(x => x.Id == saleStatusId);

                GatePassModel gatepasss = gatepassquery.FirstOrDefault();

                if (gatepasss == null)
                {
                    return Json("No Data Found");
                }

                //sales.Items = saleItemRepository.AllSubData().Where(x => x.SalesId == sales.Id).ToList();
                gatepasss.Items = gatePassItemRepository.AllSubData()
                    .Where(x => x.GatePassId == gatepasss.Id).ToList();

                return Json(gatepasss);
                //return Json(new { Success = 1, sales = sales, ex = "Data Load Successfully" });
            }
            catch (Exception e)
            {
                return Json(e.ToString());
            }

        }



        [AllowAnonymous]
        public JsonResult GetCustomers()
        {
            return Json(customerRepository.All());
        }

        [AllowAnonymous]
        public JsonResult GetCustomersDropdown()
        {
            return Json(customerRepository.All().
            Select(e => new
            {
                Id = e.Id,
                Name = e.Name,
                PrimaryAddress = e.PrimaryAddress
            }));
        }


        [AllowAnonymous]
        public JsonResult GetCustomerInvoice(int CustomerId, int? TransactionId)
        {

            var TransactionInformation = _accountsDailyTransaction.All().Where(x => x.Id == TransactionId).FirstOrDefault();


            #region customerbalance_calculation

            var currentdate = DateTime.Now.Date;


            if (TransactionInformation == null)
            {
                currentdate = currentdate.AddDays(1);
            }
            else
            {
                if (TransactionInformation.CustomerId != CustomerId)
                {
                    TransactionInformation = null;
                    currentdate = currentdate.AddDays(1);
                }
            }

            var Type = "Customer";
            var dtFrom = currentdate.ToString("dd-MMM-yy");
            var dtTo = currentdate.ToString("dd-MMM-yy");

            var comid = HttpContext.Session.GetInt32("ComId");
            var userid = HttpContext.Session.GetInt32("UserId");

            var quary = $"Exec Acc_CustomerBalance  '" + comid + "','" + CustomerId + "',0,'" + dtFrom + "' ,'" + dtTo + "','" + Type + "',1";

            SqlParameter[] parameters = new SqlParameter[7];
            parameters[0] = new SqlParameter("@ComId", comid);
            parameters[1] = new SqlParameter("@CustomerId", CustomerId);
            parameters[2] = new SqlParameter("@UrlLink", "");
            parameters[3] = new SqlParameter("@FromDate", DateTime.Parse(dtFrom));
            parameters[4] = new SqlParameter("@ToDate", DateTime.Parse(dtTo));
            parameters[5] = new SqlParameter("@LedgerFor", Type);
            parameters[6] = new SqlParameter("@BalanceUpdate", "1");


            Helper.ExecProc("Acc_CustomerBalance", parameters);

            #endregion




            if (TransactionInformation != null && CustomerId == TransactionInformation.CustomerId)
            {
                var customer = customerRepository.All().Include(x => x.AccountsDailyTransaction)
                          .Where(y => y.Id == CustomerId)
                          .Select(g => new
                          {
                              g.Name,
                              g.PrimaryAddress,
                              g.SecoundaryAddress,
                              g.PostalCode,
                              g.Email,
                              g.City,
                              g.Phone,
                              g.CreditLimit,
                              PrevDue = g.ClBalance + TransactionInformation.TransactionAmount,
                              //PrevDue = Convert.ToDecimal(g.OpBalance) +
                              //g.AccountsDailyTransaction.Where(x => x.TransactionType == "System Sales").Sum(x => x.TransactionAmount)
                              //+ g.AccountsDailyTransaction.Where(x => x.TransactionType == "System Sales Return").Sum(x => x.TransactionAmount)
                              //- g.AccountsDailyTransaction.Where(x => x.TransactionType.Contains("Received") && x.Id != TransactionId).Sum(x => x.TransactionAmount)
                              //- g.AccountsDailyTransaction.Where(x => x.TransactionType.Contains("Paid") && !x.TransactionCategory.Contains("PaidToCustomer") && x.Id != TransactionId).Sum(x => x.TransactionAmount)
                              //+ g.AccountsDailyTransaction.Where(x => x.TransactionType.Contains("Paid") && x.TransactionCategory.Contains("PaidToCustomer") && x.Id != TransactionId).Sum(x => x.TransactionAmount),

                              //PrevDue = Convert.ToDecimal(g.OpBalance) + g.AccountsDailyTransaction.Where(x => x.TransactionType == "System Sales").Sum(x => x.TransactionAmount) + g.AccountsDailyTransaction.Where(x => x.TransactionType == "System Sales Return").Sum(x => x.TransactionAmount) - g.AccountsDailyTransaction.Where(x => x.TransactionType.Contains("Received")).Sum(x => x.TransactionAmount) + g.AccountsDailyTransaction.Where(x => x.TransactionType.Contains("Paid")).Sum(x => x.TransactionAmount),
                              g.CustomerCommissionPer,
                              g.SRCommissionPer,
                              g.SalesRepresentativeId
                          })
                          .SingleOrDefault();


                var saledata = salesPaymentRepository.All().Include(x => x.SalesMain).ThenInclude(x => x.CustomerModel).Where(x => x.TransactionId == TransactionId).FirstOrDefault();

                //var abc = new SelectList();
                var prevselecteddata = new SelectListItem { Text = saledata.SalesMain.SaleCode + " - " + saledata.SalesMain.CustomerModel.Name + "  " + saledata.SalesMain.CustomerName + " - " + saledata.SalesMain.NetAmount + "    Due : " + (saledata.Amount), Value = saledata.SalesId.ToString(), Selected = true }; //saledata.SalesMain.NetAmount - 
                var customerinvoicelist = saleRepository.GetAllForDropDownForCustomer(true, CustomerId).ToList();
                customerinvoicelist.Add(prevselecteddata);

                var genericResult = new
                {
                    CustomerInvoiceList = customerinvoicelist,
                    CustomerInfo = customer
                };
                return Json(genericResult);

            }
            else
            {
                var customer = customerRepository.All().Include(x => x.AccountsDailyTransaction)
                            .Where(y => y.Id == CustomerId)
                            .Select(g => new
                            {
                                g.Name,
                                g.PrimaryAddress,
                                g.SecoundaryAddress,
                                g.PostalCode,
                                g.Email,
                                g.City,
                                g.Phone,
                                g.CreditLimit,
                                PrevDue = g.ClBalance,
                                //PrevDue = Convert.ToDecimal(g.OpBalance)
                                //+ g.AccountsDailyTransaction.Where(x => x.TransactionType == "System Sales").Sum(x => x.TransactionAmount)
                                //+ g.AccountsDailyTransaction.Where(x => x.TransactionType == "System Sales Return").Sum(x => x.TransactionAmount)
                                //- g.AccountsDailyTransaction.Where(x => x.TransactionType.Contains("Received")).Sum(x => x.TransactionAmount)
                                //- g.AccountsDailyTransaction.Where(x => x.TransactionType.Contains("Paid") && !x.TransactionCategory.Contains("PaidToCustomer")).Sum(x => x.TransactionAmount)
                                //+ g.AccountsDailyTransaction.Where(x => x.TransactionType.Contains("Paid") && x.TransactionCategory.Contains("PaidToCustomer")).Sum(x => x.TransactionAmount),

                                //PrevDue = Convert.ToDecimal(g.OpBalance) + g.AccountsDailyTransaction.Where(x => x.TransactionType == "System Sales").Sum(x => x.TransactionAmount) + g.AccountsDailyTransaction.Where(x => x.TransactionType == "System Sales Return").Sum(x => x.TransactionAmount) - g.AccountsDailyTransaction.Where(x => x.TransactionType.Contains("Received")).Sum(x => x.TransactionAmount) + g.AccountsDailyTransaction.Where(x => x.TransactionType.Contains("Paid")).Sum(x => x.TransactionAmount),
                                g.CustomerCommissionPer,
                                g.SRCommissionPer,
                                g.SalesRepresentativeId
                            })
                            .SingleOrDefault();

                var genericResult = new
                {
                    CustomerInvoiceList = saleRepository.GetAllForDropDownForCustomer(true, CustomerId),
                    CustomerInfo = customer
                };
                return Json(genericResult);
            }


        }



        [AllowAnonymous]
        public JsonResult GetAccountHead()
        {

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


        [AllowAnonymous]
        public JsonResult GetSalesTermsList()
        {

            var x = termsmainRepository.GetAllForDropDown();
            return Json(x);

            //return Json(accountHeadRepository.GetCashBankHeadForDropDown(false));

        }

        [AllowAnonymous]
        public JsonResult GetPaymentTypes()
        {
            return Json(paymentTypeRepository.GetAllForDropDownTrading());
        }

        public IActionResult POSCreate()
        {
            try
            {
                SalesModel abc = new SalesModel();
                abc.SalesDate = DateTime.Now.Date;

                var comid = HttpContext.Session.GetString("ComId");
                var userid = HttpContext.Session.GetString("userid");

                object a = HttpContext.Session.GetString("isProductSearch");
                ViewBag.ActionType = "Entry";

                ViewBag.Customer = customerRepository.GetAllForDropDown();
                ViewBag.Category = categoryRepository.GetAllForDropDown();
                var Productresult = productRepository.All().Take(4000);

                //ViewBag.Product = productRepository.GetAllProductForDropDown();
                //ViewBag.Product = new SelectList(Productresult, "Id", "Name");
                ViewBag.Product = new SelectList(Productresult.Where(x => x.Id > 0).Select(s => new { Text = s.Code.Length < 4 ? s.Name : s.Name + " - [ " + s.Code + " ]", Value = s.Id }).ToList(), "Value", "Text");
                ViewBag.ProductSearch = Productresult;

                ///if (_FromWarehousePermissionRepository.GetAllForDropDown().Count() > 0) { ViewBag.Warehouse = _FromWarehousePermissionRepository.GetAllForDropDown(); } else { ViewBag.Warehouse = _warehouseRepository.GetWarehouseLedgerHeadForDropDown(); }
                var x = _FromWarehousePermissionRepository.GetAllForDropDown();
                if (x.Count() == 0)
                {
                    x = _warehouseRepository.GetWarehouseLedgerHeadForDropDown();
                }
                ViewBag.Warehouse = x;


                ViewBag.PaymentTypes = paymentTypeRepository.GetAllForDropDown();
                ViewBag.AccountHead = accountHeadRepository.GetCashBankHeadForDropDown(false);

                //////////////ViewBag.SalesType = new SelectList(POS.GetSalesType(), "SalesTypeId", "TypeShortName");
                //////////////ViewBag.Customer = new SelectList(db.Customers.Where(x => x.comid == comid).Take(20), "CustomerId", "CustomerName");

                //ViewBag.Category = new SelectList(POS.GetCategory(comid), "CategoryId", "Name");
                //var Productresult = db.Products.Where(x => x.comid == comid && x.ProductId > 0).Take(20);
                //ViewBag.Product = new SelectList(Productresult, "ProductId", "ProductName");
                //this.ViewBag.Product = new SelectList(Productresult.Where(x => x.ProductId > 0).Select(s => new { Text = s.ProductBarcode.Length < 4 ? s.ProductName : s.ProductName + " - [ " + s.ProductBarcode + " ]", Value = s.ProductId }).ToList(), "Value", "Text");
                //ViewBag.ProductSearch = Productresult;
                //ViewBag.Warehouse = new SelectList(POS.GetWarehouse(comid), "WarehouseId", "WhName");
                //ViewBag.PaymentTypes = new SelectList(POS.GetPaymentTypes(), "PaymentTypeId", "TypeShortName");
                //ViewBag.AccountHead = new SelectList(POS.GetChartOfAccountCash(comid), "AccId", "AccName");
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

        [HttpPost]
        [AllowAnonymous]
        public JsonResult CustomerInfo(int id, int isCreditLimit = 0)
        {
            try
            {
                if (isCreditLimit == 1)
                {
                    var customer = customerRepository.All().Include(x => x.AccountsDailyTransaction)
                        .Where(y => y.Id == id)
                        .Select(g => new
                        {
                            g.Name,
                            g.PrimaryAddress,
                            g.SecoundaryAddress,
                            g.PostalCode,
                            g.Email,
                            g.City,
                            g.Phone,
                            g.CreditLimit,
                            //PrevDue = Convert.ToDecimal(g.OpBalance) 
                            //+ g.AccountsDailyTransaction.Where(x => x.TransactionType == "System Sales").Sum(x => x.TransactionAmount) 
                            //- g.AccountsDailyTransaction.Where(x => x.TransactionType == "System Sales Return").Sum(x => x.TransactionAmount) 
                            //- g.AccountsDailyTransaction.Where(x => x.TransactionType.Contains("Received")).Sum(x => x.TransactionAmount) 
                            //////+ g.AccountsDailyTransaction.Where(x => x.TransactionType.Contains("Paid")).Sum(x => x.TransactionAmount),
                            //- g.AccountsDailyTransaction.Where(x => x.TransactionType.Contains("Paid") && !x.TransactionCategory.Contains("PaidToCustomer")).Sum(x => x.TransactionAmount)
                            //+ g.AccountsDailyTransaction.Where(x => x.TransactionType.Contains("Paid") && x.TransactionCategory.Contains("PaidToCustomer")).Sum(x => x.TransactionAmount),



                            PrevDue = Convert.ToDecimal(g.OpBalance)
                                + g.AccountsDailyTransaction.Where(x => x.TransactionType == "System Sales").Sum(x => x.TransactionAmount)
                                + g.AccountsDailyTransaction.Where(x => x.TransactionType == "System Sales Return").Sum(x => x.TransactionAmount)
                                - g.AccountsDailyTransaction.Where(x => x.TransactionType.Contains("Received")).Sum(x => x.TransactionAmount)
                                - g.AccountsDailyTransaction.Where(x => x.TransactionType.Contains("Paid") && !x.TransactionCategory.Contains("PaidToCustomer")).Sum(x => x.TransactionAmount)
                                + g.AccountsDailyTransaction.Where(x => x.TransactionType.Contains("Paid") && x.TransactionCategory.Contains("PaidToCustomer")).Sum(x => x.TransactionAmount),



                            g.CustomerCommissionPer,
                            g.SRCommissionPer,
                            g.SalesRepresentativeId
                        })
                        .SingleOrDefault();
                    return Json(customer);
                }
                else
                {
                    var customer = customerRepository.All().Include(x => x.AccountsDailyTransaction)
                        .Where(y => y.Id == id)
                        .Select(g => new
                        {
                            g.Name,
                            g.PrimaryAddress,
                            g.SecoundaryAddress,
                            g.PostalCode,
                            g.Email,
                            g.City,
                            g.Phone,
                            g.CreditLimit,
                            PrevDue = Convert.ToDecimal(g.OpBalance)
                                + g.AccountsDailyTransaction.Where(x => x.TransactionType == "System Sales").Sum(x => x.TransactionAmount)
                                + g.AccountsDailyTransaction.Where(x => x.TransactionType == "System Sales Return").Sum(x => x.TransactionAmount)
                                - g.AccountsDailyTransaction.Where(x => x.TransactionType.Contains("Received")).Sum(x => x.TransactionAmount)
                                - g.AccountsDailyTransaction.Where(x => x.TransactionType.Contains("Paid") && !x.TransactionCategory.Contains("PaidToCustomer")).Sum(x => x.TransactionAmount)
                                + g.AccountsDailyTransaction.Where(x => x.TransactionType.Contains("Paid") && x.TransactionCategory.Contains("PaidToCustomer")).Sum(x => x.TransactionAmount),
                            //PrevDue = 0,
                            g.CustomerCommissionPer,
                            g.SRCommissionPer,
                            g.SalesRepresentativeId

                        })
                        .SingleOrDefault();
                    return Json(customer);
                }
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
                                select new ProductResultDemo
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
                                    SalesPrice = e.Price,
                                    //BlankData = null,

                                    ImagePath = e.ImagePath
                                    //ProductImage = e.ProductImage != null ? Convert.ToBase64String(e.ProductImage) : null,//(asset.ProductImage != null) ? (asset.ProductImage) : null
                                    //WarehouseList = WarehouseQty

                                };



                    var parser = new Parser<ProductResultDemo>(Request.Form, query);

                    return Json(parser.Parse());

                }
                else
                {

                    var query = from e in productRepository.All().Where(x => x.Id > 0 && x.ComId == int.Parse(comid.ToString()))//.OrderByDescending(x => x.ProductId)
                                                                                                                                //let FullName = e.ProductName + " " + e.ProductCode
                                                                                                                                //let ImagePath = e.ImagePath + e.Id + e.FileExtension
                                                                                                                                //let WarehouseQty = e.InventorySubs != null ? e.InventorySubs.Select(x => new WarehouseResult { WhShortName = x.Warehouses.WhShortName, CurrentStock = x.CurrentStock }).ToList() : null
                                select new ProductResultDemo
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
                                    SalesPrice = e.Price,
                                    //BlankData = null,

                                    ImagePath = e.ImagePath
                                    //ProductImage = e.ProductImage != null ? Convert.ToBase64String(e.ProductImage) : null,//(asset.ProductImage != null) ? (asset.ProductImage) : null
                                    //WarehouseList = WarehouseQty

                                };


                    //var sql = query.ToQueryString();

                    //var abcd = query.ToList();


                    var parser = new Parser<ProductResultDemo>(Request.Form, query);



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
            //List<GTERP.Models.Product> product = db.Products.Where(x => x.CategoryId == id).ToList();

            //List<SelectListItem> licities = new List<SelectListItem>();

            ////licities.Add(new SelectListItem { Text = "--Select State--", Value = "0" });
            //if (product != null)
            //{
            //    foreach (GTERP.Models.Product x in product)
            //    {
            //        licities.Add(new SelectListItem { Text = x.ProductName, Value = x.ProductId.ToString() });
            //    }
            //}

            var licities = productRepository.GetAllProductForDropDown();

            return Json(new SelectList(licities, "Value", "Text"));
        }
        //public JsonResult getAccountHead(string id)
        //{
        //    //List<Acc_ChartOfAccount> chartofaccounts = db.Acc_ChartOfAccounts.Where(x => x.AccType == "L" && x.AccCode.Contains("103070")).ToList();

        //    //List<SelectListItem> licoa = new List<SelectListItem>();

        //    ////licities.Add(new SelectListItem { Text = "--Select State--", Value = "0" });
        //    //if (chartofaccounts != null)
        //    //{
        //    //    foreach (Acc_ChartOfAccount x in chartofaccounts)
        //    //    {
        //    //        licoa.Add(new SelectListItem { Text = x.AccName, Value = x.AccId.ToString() });
        //    //    }
        //    //}

        //    var licoa = accountHeadRepository.GetCashBankHeadForDropDown(false);

        //    return Json(new SelectList(licoa, "Value", "Text"));
        //}
        [AllowAnonymous]
        public JsonResult getBarcode(int id)
        {
            //List<GTERP.Models.Product> product = db.Products.Where(x => x.ProductId == id).ToList();

            //List<SelectListItem> barcodelist = new List<SelectListItem>();

            ////licities.Add(new SelectListItem { Text = "--Select State--", Value = "0" });
            //if (product != null)
            //{
            //    foreach (GTERP.Models.Product x in product)
            //    {
            //        barcodelist.Add(new SelectListItem { Text = x.ProductBarcode, Value = x.ProductId.ToString() });
            //    }
            //}
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

                return Json(new { success = true, data = product });
                //return Json("tesst" );

            }
            catch (Exception ex)
            {
                return Json(new { success = false, values = ex.Message.ToString() });
            }
            //return Json(new SelectList(product, "Value", "Text" ));
        }


        #region Sales Tax

        [AllowAnonymous]
        [HttpGet]
        public IActionResult SalesTax()
        {
            var agency = _agencyRepository.All();
            var data = agency.ToList();
            SelectList agencyList = new SelectList(data, "Id", "AgencyName");

            // Assign the SelectList to ViewData
            ViewData["AgencyList"] = agencyList;
            ViewBag.TaxCriteria = taxCriteriaRepository.GetAllDropDown();
            ViewBag.SalesVAT = accountHeadRepository.GetSalesVATDropdown();
            ViewBag.PurchaseVAT = accountHeadRepository.GetPurchaseVATDropdown();
            ViewBag.ExpenseVAT = accountHeadRepository.GetExpenseVATDropdown();
            return View();
        }

        [AllowAnonymous]
        [HttpGet]
        public IActionResult GetAgenciesJson(int page = 1, decimal size = 10, string searchquery = "")
        {
            try
            {
                var agency = _agencyRepository.All();

                if (searchquery?.Length > 1)
                {
                    agency = agency.Where(x => x.AgencyName.ToLower().Contains(searchquery.ToLower()) ||
                            x.Fillingfrequency.ToLower().Contains(searchquery.ToLower()) ||
                            x.StartOfTaxPeriod.ToLower().Contains(searchquery.ToLower()) ||
                            x.ReportingMethod.ToLower().Contains(searchquery.ToLower())
                    );
                }

                decimal TotalRecordCount = agency.Count();
                var PageCountabc = decimal.Parse((TotalRecordCount / size).ToString());
                var PageCount = Math.Ceiling(PageCountabc);

                decimal skip = (page - 1) * size;

                var query = from e in agency

                            select new
                            {
                                Id = e.Id,
                                e.AgencyName,
                                e.Fillingfrequency,
                                e.StartOfTaxPeriod,
                                e.StartDate,
                                e.ReportingMethod

                            };



                var abcd = query.OrderByDescending(x => x.Id).Skip(int.Parse(skip.ToString())).Take(int.Parse(size.ToString())).ToList();
                var pageinfo = new PagingInfo();
                pageinfo.PageCount = int.Parse(PageCount.ToString());
                pageinfo.PageNo = page;
                pageinfo.PageSize = int.Parse(size.ToString());
                pageinfo.TotalRecordCount = int.Parse(TotalRecordCount.ToString());

                return Json(new { Success = 1, error = false, data = abcd, page = page, size = size, last_page = pageinfo.PageCount, total = pageinfo.TotalRecordCount });
                //return Json(new { Success = 1, data = data, ex = "Data " });

            }
            catch (Exception ex)
            {

                return Json(new { Success = 0, ex = ex.InnerException.InnerException.Message.ToString() });
                throw ex;

            }
        }

        [AllowAnonymous]
        [HttpGet]
        public IActionResult GetSalesJson(int page = 1, decimal size = 10, string searchquery = "")
        {
            try
            {
                var sales = _salestaxRepository.All();

                if (searchquery?.Length > 1)
                {
                    sales = sales.Where(x => x.Nickname.ToLower().Contains(searchquery.ToLower())
                    );
                }

                decimal TotalRecordCount = sales.Count();
                var PageCountabc = decimal.Parse((TotalRecordCount / size).ToString());
                var PageCount = Math.Ceiling(PageCountabc);

                decimal skip = (page - 1) * size;

                var query = from e in sales

                            select new
                            {
                                Id = e.Id,
                                e.Nickname,
                                AgentName = e.Agency.AgencyName,
                                Rate = e.Rate,
                                e.SalesTaxMasterId
                            };



                var abcd = query.OrderByDescending(x => x.Id).Skip(int.Parse(skip.ToString())).Take(int.Parse(size.ToString())).ToList();
                var pageinfo = new PagingInfo();
                pageinfo.PageCount = int.Parse(PageCount.ToString());
                pageinfo.PageNo = page;
                pageinfo.PageSize = int.Parse(size.ToString());
                pageinfo.TotalRecordCount = int.Parse(TotalRecordCount.ToString());

                return Json(new { Success = 1, error = false, data = abcd, page = page, size = size, last_page = pageinfo.PageCount, total = pageinfo.TotalRecordCount });
                //var agency = _agencyRepository.All();
                //var sales = _salestaxRepository.All();
                //var mastersales = _mastersalestaxRepository.All();
                //var masterdata = mastersales.ToList();
                //var data = sales.ToList();
                //var data1 = agency.ToList();
                //foreach (var item in data)
                //{
                //    item.AgentName = data1.Where(x => x.Id == item.AgentId).Select(p => p.AgencyName).FirstOrDefault();
                //    item.Name = masterdata.Where(x => x.Id == item.SalesTaxMasterId).Select(p => p.Name).FirstOrDefault();
                //}
                //return Json(new { Success = 1, data = data, ex = "Data " });

            }
            catch (Exception ex)
            {

                return Json(new { Success = 0, ex = ex.InnerException.InnerException.Message.ToString() });
                throw ex;

            }
        }
        [AllowAnonymous]
        [HttpPost]
        // public ActionResult AddAccountHeadByJson(AccountHeadModel model)
        public IActionResult AgencyCreation(AgencyModel model)
        {

            var errors = ModelState.Where(x => x.Value.Errors.Any())
            .Select(x => new { x.Key, x.Value.Errors });

            if (ModelState.IsValid)
            {
                if (model.Id == 0)
                {

                    _agencyRepository.Insert(model);



                    TempData["Message"] = "Data Save Successfully";
                    TempData["Status"] = "1";
                    tranlog.TransactionLog(RouteData.Values["controller"].ToString(), RouteData.Values["action"].ToString(), TempData["Message"].ToString(), model.Id.ToString(), "Create", model.AgencyName.ToString());
                    return Json(new { success = "1", message = "Data Save Successfully" });

                }
                else
                {
                    _agencyRepository.Update(model, model.Id);


                    TempData["Message"] = "Data Update Successfully";
                    TempData["Status"] = "2";
                    tranlog.TransactionLog(RouteData.Values["controller"].ToString(), RouteData.Values["action"].ToString(), TempData["Message"].ToString(), model.Id.ToString(), "Update", model.AgencyName.ToString());
                    return Json(new { success = "1", message = "Data Update Successfully" });

                }
                return RedirectToAction("SalesTax");
            }
            else
            {
                if (model.Id == 0)
                {
                    ViewBag.ActionType = "Create";



                }
                else
                {
                    ViewBag.ActionType = "Edit";

                }
            }
            return View(model);
        }

        [AllowAnonymous]
        [HttpPost]
        public IActionResult TaxCreation(MasterSalesTaxModel model)
        {

            var errors = ModelState.Where(x => x.Value.Errors.Any())
            .Select(x => new { x.Key, x.Value.Errors });
            var UserId = httpcontext.HttpContext.Session.GetInt32("UserId");
            var ComId = httpcontext.HttpContext.Session.GetInt32("ComId");

            if (ModelState.IsValid)
            {
                if (model.Id == 0)
                {
                    foreach (var item in model.SalesTax)
                    {

                        item.CreateDate = DateTime.Now;
                        item.UpdateDate = DateTime.Now;
                        item.ComId = ComId.GetValueOrDefault();
                        item.LuserId = UserId.GetValueOrDefault();
                    }

                    _mastersalestaxRepository.Insert(model);



                    TempData["Message"] = "Data Save Successfully";
                    TempData["Status"] = "1";
                    //tranlog.TransactionLog(RouteData.Values["controller"].ToString(), RouteData.Values["action"].ToString(), TempData["Message"].ToString(), model.Id.ToString(), "Create", model.Name.ToString());
                    return Json(new { success = "1", message = "Data Save Successfully" });

                }
                else
                {
                    _mastersalestaxRepository.Update(model, model.Id);
                    foreach (var item in model.SalesTax)
                    {

                        if (item.Id > 0)
                        {
                            _salestaxRepository.Update(item, item.Id);
                        }
                        else
                        {
                            _salestaxRepository.Insert(item);
                        }
                    }


                    TempData["Message"] = "Data Update Successfully";
                    TempData["Status"] = "2";
                    //tranlog.TransactionLog(RouteData.Values["controller"].ToString(), RouteData.Values["action"].ToString(), TempData["Message"].ToString(), model.Id.ToString(), "Update", model.Name.ToString());
                    return Json(new { success = "1", message = "Data Update Successfully" });

                }
                return RedirectToAction("SalesTax");
            }
            else
            {
                if (model.Id == 0)
                {
                    ViewBag.ActionType = "Create";



                }
                else
                {
                    ViewBag.ActionType = "Edit";

                }
            }
            return View(model);
        }

        [AllowAnonymous]
        [HttpPost]
        public IActionResult MultiTaxCreation(MasterSalesTaxModel model)
        {

            var errors = ModelState.Where(x => x.Value.Errors.Any())
            .Select(x => new { x.Key, x.Value.Errors });
            var UserId = httpcontext.HttpContext.Session.GetInt32("UserId");
            var ComId = httpcontext.HttpContext.Session.GetInt32("ComId");

            if (ModelState.IsValid)
            {
                if (model.Id == 0)
                {
                    foreach (var item in model.SalesTax)
                    {

                        item.CreateDate = DateTime.Now;
                        item.UpdateDate = DateTime.Now;
                        item.ComId = ComId.GetValueOrDefault();
                        item.LuserId = UserId.GetValueOrDefault();
                        item.IsSingleTax = false;
                    }

                    _mastersalestaxRepository.Insert(model);



                    TempData["Message"] = "Data Save Successfully";
                    TempData["Status"] = "1";
                    return Json(new { success = "1", message = "Data Save Successfully" });

                }
                else
                {
                    _mastersalestaxRepository.Update(model, model.Id);

                    var taxId = _salestaxRepository.All().Where(x => x.SalesTaxMasterId == model.Id).Select(x => x.Id).ToList();

                    foreach (var item in model.SalesTax)
                    {
                        if (taxId.Contains(item.Id))
                        {
                            taxId.Remove(item.Id);
                        }

                        if (item.Id > 0)
                        {
                            _salestaxRepository.Update(item, item.Id);
                        }
                        else
                        {
                            _salestaxRepository.Insert(item);
                        }
                    }

                    if (taxId.Count > 0)
                    {
                        foreach (var id in taxId)
                        {
                            var tempModel = _salestaxRepository.All().Where(x => x.Id == id).FirstOrDefault();
                            _salestaxRepository.Delete(tempModel);
                        }
                    }
                    TempData["Message"] = "Data Update Successfully";
                    TempData["Status"] = "2";
                    return Json(new { success = "1", message = "Data Update Successfully" });

                }
                //return RedirectToAction("SalesTax");
            }
            else
            {
                if (model.Id == 0)
                {
                    ViewBag.ActionType = "Create";



                }
                else
                {
                    ViewBag.ActionType = "Edit";

                }
            }
            return View(model);
        }


        [HttpGet]
        [AllowAnonymous]       
        public JsonResult DeleteTaxRate(int id)
        {
            try
            {

                var model = _salestaxRepository.Find(id);

                if (model != null)
                {

                    _salestaxRepository.Delete(model);


                    return Json(new { success = "1", msg = "Deleted Successfully" });
                }
                return Json(new { success = "0", msg = "No items found to delete." });

            }
            catch (Exception ex)
            {
                return Json(new { success = "0", msg = "No items found to delete." }); //msg = ex.ToString()
                throw ex;
            }
        }

        [HttpGet]
        [AllowAnonymous]
        public JsonResult DeleteTaxAgency(int id)
        {
            try
            {

                var model = _agencyRepository.Find(id);

                if (model != null)
                {
                    _agencyRepository.Delete(model);
                  

                    return Json(new { success = "1", msg = "Deleted Successfully" });
                }
                return Json(new { success = "0", msg = "No items found to delete." });

            }
            catch (Exception ex)
            {
                return Json(new { success = "0", msg = "No items found to delete." }); //msg = ex.ToString()
                throw ex;
            }
        }


        [AllowAnonymous]
        [HttpGet]
        public IActionResult GetAllChild(int id)
        {
            try
            {
                var agency = _agencyRepository.All();
                var sales = _salestaxRepository.All();
                var mastersales = _mastersalestaxRepository.All();
                var masterdata = mastersales.ToList();
                var data = sales.Where(x => x.SalesTaxMasterId == id).ToList();
                var data1 = agency.ToList();
                foreach (var item in data)
                {
                    item.AgentName = data1.Where(x => x.Id == item.AgentId).Select(p => p.AgencyName).FirstOrDefault();
                    item.Name = masterdata.Where(x => x.Id == item.SalesTaxMasterId).Select(p => p.Name).FirstOrDefault();
                }
                return Json(new { Success = 1, data = data, ex = "Data " });

            }
            catch (Exception ex)
            {

                return Json(new { Success = 0, ex = ex.InnerException.InnerException.Message.ToString() });
                throw ex;

            }
        }

        [AllowAnonymous]
        public JsonResult GetCustomersForInvoice(int page = 1, decimal size = 10, string searchquery = "")
        {
            try
            {
                var errors = ModelState.Where(x => x.Value.Errors.Any())
          .Select(x => new { x.Key, x.Value.Errors });

                var ComId = httpcontext.HttpContext.Session.GetInt32("ComId");
                var customers = customerRepository.All().Where(x => x.ComId == ComId && x.IsDelete == false);


                if (searchquery?.Length > 1)
                {
                    customers = customers.Where(x =>
               x.Name.ToLower().Contains(searchquery.ToLower()) ||
               x.Title.ToLower().Contains(searchquery.ToLower()) ||
               x.FirstName.ToLower().Contains(searchquery.ToLower()) ||
               x.MiddelName.ToLower().Contains(searchquery.ToLower()) ||
               x.LastName.ToLower().Contains(searchquery.ToLower()) ||
               x.CompanyName.ToLower().Contains(searchquery.ToLower()) ||
               x.Phone.ToLower().Contains(searchquery.ToLower()) ||
               x.CustomerCode.ToLower().Contains(searchquery.ToLower()) ||
               x.Email.ToLower().Contains(searchquery.ToLower())
               );

                }


                decimal TotalRecordCount = customers.Count();
                var PageCountabc = decimal.Parse((TotalRecordCount / size).ToString());
                var PageCount = Math.Ceiling(PageCountabc);

                decimal skip = (page - 1) * size;

                var query = from e in customers
                            select new
                            {
                                Id = e.Id,
                                CustomerNames = e.Name,
                                CompanyName = e.CompanyName,
                                Phone = e.Phone,
                                ClBalance = e.OpBalance,
                                BillingStreetAddress = e.BillingStreetAddress,
                                Currency = e.Currency.CurrencyShortName,
                                e.CustomerCode

                            };

                var abcd = query.OrderByDescending(x => x.Id).Skip(int.Parse(skip.ToString())).Take(int.Parse(size.ToString())).ToList();
                var pageinfo = new PagingInfo();
                pageinfo.PageCount = int.Parse(PageCount.ToString());
                pageinfo.PageNo = page;
                pageinfo.PageSize = int.Parse(size.ToString());
                pageinfo.TotalRecordCount = int.Parse(TotalRecordCount.ToString());

                return Json(new { Success = 1, error = false, data = abcd, page = page, size = size, last_page = pageinfo.PageCount, total = pageinfo.TotalRecordCount });

                //return Json(new { Success = 1, data = customers, ex = "Data " });
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        #endregion




        #region Invoice


        [OverridableAuthorize]
        public IActionResult AddInvoiceQB(string type)
        {
            var ComId = HttpContext.Session.GetInt32("ComId");

            ViewBag.Customers = customerRepository.All().Where(p => p.ComId == ComId).Include(x => x.Currency)
                       .Select(x => new SelectListItem
                       {
                           Text = x.Name + '-' + x.Currency.CurrencyShortName,
                           Value = x.Id.ToString()
                       });

            ViewBag.WarehouseIdMain = _warehouseRepository.All().Where(x => x.ComId == ComId)
                            .Select(x => new SelectListItem
                            {
                                Text = x.WhName,
                                Value = x.Id.ToString()
                            });
            ViewBag.ActionType = "Create";

            if (type == null)
            {
                type = "Invoice";
            }
            if (type == "Credit Note")
            {
                type = "Credit-note";
            }
            if (type == "Sales receipt")
            {
                type = "Sales_Receipt";
            }
            if (type == "Delayed Charge")
            {
                type = "Delayed_Charge";
            }

            ViewBag.TransactionType = type;

            var products = productRepository.All().Where(p => p.ComId == ComId).ToList();

            SelectList productslist = new SelectList(products, "Id", "Name");
            ViewData["ProductList"] = productslist;

            var taxes = _mastersalestaxRepository.All().Where(f => f.ComId == ComId).ToList();
            SelectList taxList = new SelectList(taxes, "Id", "Name");
            ViewData["TaxList"] = taxList;

            var agency = _agencyRepository.All();
            var data = agency.ToList();
            SelectList agencyList = new SelectList(data, "Id", "AgencyName");

            ViewData["AgencyList"] = agencyList;

            var taxCalculation = new List<SelectListItem>
            {
                new SelectListItem { Text = "Exclusive of Tax", Value = "exclusive" },
                new SelectListItem { Text = "Inclusive of Tax", Value = "inclusive" },
                new SelectListItem { Text = "Out of scope of Tax", Value = "outscope" }
            };

            var estimateStatus = new List<SelectListItem>
            {
                new SelectListItem { Text = "Pending", Value = "Pending" },
                new SelectListItem { Text = "Accepted", Value = "Accepted" },
                new SelectListItem { Text = "Closed", Value = "Closed" },
                new SelectListItem { Text = "Rejected", Value = "Rejected" }
            };

            var estimateStatusList = new SelectList(estimateStatus, "Value", "Text");
            ViewData["EstimateStatus"] = estimateStatusList;

            var taxCalculationList = new SelectList(taxCalculation, "Value", "Text");

            ViewData["CategoryList"] = accountHeadRepository.GetCashBankHeadForDropDown();

            ViewData["AmountsAre"] = taxCalculationList;

            ViewBag.Id = 0;
            return View();
        }

        [HttpPost]
        [AllowAnonymous]
        //[ValidateAntiForgeryToken]
        public IActionResult AddTerms(PaymentTermsModel model)
        {
            try
            {
                var errors = ModelState.Where(x => x.Value.Errors.Any())
                    .Select(x => new { x.Key, x.Value.Errors });

                if (true)
                {

                    if (model.Id == 0)
                    {
                        bool isTermNameExists = _termRepository.GetAllTerms().Any(t => t.TermName == model.TermName);

                        if (isTermNameExists)
                        {
                            TempData["Message"] = "Name already exists.";
                            TempData["Status"] = "0";
                            return Json(new { success = "2", message = "Name already exists." });
                        }
                        else
                        {
                            _termRepository.Insert(model);

                            TempData["Message"] = "Data Save Successfully";
                            TempData["Status"] = "1";
                            tranlog.TransactionLog(RouteData.Values["controller"].ToString(), RouteData.Values["action"].ToString(), TempData["Message"].ToString(), model.Id.ToString(), "Create", model.TermName.ToString());
                            return Json(new { success = "1", message = "Data Save Successfully", model.Id });
                        }
                    }
                    else
                    {

                        bool isTermNameExists = _termRepository.GetAllTerms().Any(t => t.TermName == model.TermName);

                        if (isTermNameExists)
                        {
                            TempData["Message"] = "Name already exists.";
                            TempData["Status"] = "0";
                            return Json(new { success = "2", message = "Name already exists." });
                        }
                        else
                        {
                            _termRepository.Update(model, model.Id);

                            TempData["Message"] = "Data Update Successfully";
                            TempData["Status"] = "2";
                            tranlog.TransactionLog(RouteData.Values["controller"].ToString(), RouteData.Values["action"].ToString(), TempData["Message"].ToString(), model.Id.ToString(), "Update", model.TermName.ToString());
                            return Json(new { success = "1", message = "Data Update Successfully" });
                        }
                    }
                }
                else
                {
                    if (model.Id == 0)
                    {
                        ViewBag.ActionType = "Create";
                    }
                    else
                    {
                        ViewBag.ActionType = "Edit";
                    }
                    return Json(new { error = true, message = "Failed to Save the Data" });
                }
            }
            catch (Exception ex)
            {
                return Json(new { error = true, message = ex.Message });
            }
        }

        [AllowAnonymous]
        public JsonResult GetDoctypeList(string criteria)
        {
            var doctypes = _docTypeRepository.GetAllDoctype().Where(x => x.DocFor == "Sales" && x.IsDelete == false);

            if (criteria != "All")
            {
                doctypes = doctypes.Where(x => x.DocType == criteria);
            }
            return Json(doctypes.ToList());
        }


        [AllowAnonymous]
        public JsonResult TermsList()
        {
            var terms = _termRepository.GetAllTerms().ToList();
            return Json(terms);
        }

        [AllowAnonymous]
        public JsonResult RateCount(int id, float amount)
        {
            var data = _salestaxRepository.All().Where(x => x.AgentId == id).ToList();

            float? totalrate = 0;
            if (data != null)
            {
                foreach (var item in data)
                {
                    totalrate += item.Rate;
                }
            }

            Console.WriteLine(amount);

            totalrate = totalrate / 100;
            totalrate = totalrate * amount;
            return Json(totalrate);
        }

        [AllowAnonymous]
        [HttpPost]
        public IActionResult InvoiceCreation([FromBody] SalesModelVM model)
        {
            var errors = ModelState.Where(x => x.Value.Errors.Any())
           .Select(x => new { x.Key, x.Value.Errors });

            string format = "dd-MMM-yyyy"; // The format of the input date string
            var ComId = HttpContext.Session.GetInt32("ComId");
            var UserId = HttpContext.Session.GetInt32("UserId");
            DateTime dateTime;
            var doctypeId = _docTypeRepository.All().Where(x => x.DocType == "Invoice" && x.DocFor == "Sales").Select(x => x.Id).FirstOrDefault();

            if (DateTime.TryParseExact(model.SalesDate, format, CultureInfo.InvariantCulture, DateTimeStyles.None, out dateTime))
            {
                var temp = dateTime;
                dateTime = temp;
            }
            if (model.Id == 0)
            {
                DateTime now = DateTime.Now;
                string uniqueNumber = "IN-" + DateTime.Now.ToString("ddMMyyHHmmssfff");
                var model1 = new SalesModel();
                var docPrefix = docPrefixRepository.All().Where(x => x.ComId == ComId && x.DocTypeId == doctypeId).FirstOrDefault();
                if (docPrefix != null)
                {
                    uniqueNumber = GetSalesCode(doctypeId);
                }


                model1.ComId = model.ComId;
                model1.LuserId = model.LuserId;
                model1.Id = model.Id;
                model1.CurrencyId = model.CurrencyId;
                model1.CustomerId = int.Parse(model.CustomerId);
                model1.EmailId = model.EmailId;
                model1.PrimaryAddress = model.PrimaryAddress;
                model1.SalesDate = dateTime;
                model1.DueDate = DateTime.Parse(model.DueDate);
                model1.ShippingVia = model.ShippingVia;
                model1.ShippingDate = DateTime.Parse(model.ShippingDate);
                model1.TrackingNo = model.TrackingNo;
                model1.SaleCode = uniqueNumber;
                model1.CurrencyRate = model.CurrencyRate;
                model1.SecoundaryAddress = model.SecoundaryAddress;
                model1.ShippingTo = model.ShippingTo;
                model1.MessageInvoice = model.MessageInvoice;
                model1.MessageStatement = model.MessageStatement;
                model1.Total = model.Total;
                model1.SubTotal = model.SubTotal;
                model1.TotalVat = (decimal)model.TotalVat;
                model1.Shipping = model.Shipping;
                model1.ShippingTax = model.ShippingTax;
                model1.AmountsAre = model.AmountsAre;
                model1.NetAmount = (decimal)model.Total;
                model1.StatusRemarks = "Overdue on " + model.DueDate.ToString();
                model1.DocTypeId = doctypeId;
                model1.WarehouseIdMain = model.WarehouseIdMain;
                model1.IsRecurring = model.IsRecurring;
                model1.salesRecievedtTermsId = model.salesRecievedtTermsId;
                model1.FiscalMonthId = model.FiscalMonthId;




                var custname = customerRepository.Find(model1.CustomerId);
                model1.CustomerName = custname.Name;
                List<SalesItemsModel> ls = new List<SalesItemsModel>();
                List<SalesProductTaxModel> lt = new List<SalesProductTaxModel>();
                List<SalesTagModel> ltag = new List<SalesTagModel>();
                if (model.SalesItemVM.Count > 0)
                {

                    foreach (var item in model.SalesItemVM)
                    {
                        var salesitem = new SalesItemsModel();
                        if (item.ProductId != "" && item.ServiceDate != null)
                        {
                            salesitem.Id = 0;
                            salesitem.ServiceDate = DateTime.Parse(item.ServiceDate);
                            salesitem.ProductId = int.Parse(item.ProductId);
                            salesitem.Description = item.Description;
                            salesitem.Quantity = double.Parse(item.Quantity);
                            salesitem.Price = float.Parse(item.Price);
                            salesitem.SecondaryPrice = float.Parse(item.SecondaryPrice);
                            salesitem.DefaultPrice = float.Parse(item.DefaultPrice);
                            salesitem.CostPrice = float.Parse(item.CostPrice);
                            salesitem.Amount = float.Parse(item.Amount);
                            salesitem.IndDiscount = float.Parse(item.IndDiscount);
                            salesitem.ComId = ComId ?? 0;
                            salesitem.LuserId = UserId ?? 0;
                            salesitem.WarehouseId = item.WarehouseId;
                            salesitem.WHName = item.WHName;
                            if (item.MasterTaxId == "0" || item.MasterTaxId == null)
                            {
                                salesitem.MasterTaxId = 0;
                                salesitem.MasterTaxName = "";
                            }
                            else
                            {
                                salesitem.MasterTaxId = int.Parse(item.MasterTaxId);
                                var mastertaxname = _mastersalestaxRepository.Find(salesitem.MasterTaxId);
                                salesitem.MasterTaxName = mastertaxname.Name;
                            }


                            var productname = productRepository.Find(salesitem.ProductId);
                            salesitem.Name = productname.Name;
                            salesitem.PrimaryUnitId = item.PrimaryUnitId;
                            salesitem.SecondaryUnitId = item.SecondaryUnitId;
                            salesitem.ConversionRate = item.ConversionRate;
                            salesitem.InputQuantity = item.InputQuantity;
                            salesitem.Unit = item.Unit;
                            //if (item.IsTax == "")
                            //{
                            //    item.IsTax = "false";
                            //}
                            //salesitem.IsTax = bool.Parse(item.IsTax);

                            ls.Add(salesitem);
                        }
                    }

                }
                if (model.SalesProductTaxVM.Count > 0)
                {

                    foreach (var item in model.SalesProductTaxVM)
                    {
                        var salesitem = new SalesProductTaxModel();
                        salesitem.Id = 0;
                        salesitem.Nickname = item.Nickname;
                        salesitem.IsSum = item.IsSum;
                        salesitem.Amount = float.Parse(item.Amount);
                        salesitem.TotalAmount = float.Parse(item.TotalAmount);
                        salesitem.TaxId = item.TaxId;
                        salesitem.ComId = ComId ?? 0;



                        lt.Add(salesitem);
                    }

                }
                if (model.SalesTags.Count > 0)
                {
                    foreach (var item in model.SalesTags)
                    {
                        var salesTags = new SalesTagModel();
                        var newtag = new TagsModel();

                        if (item.Any(char.IsLetter))
                        {
                            newtag.ComId = ComId ?? 0;
                            newtag.TagsType = "G";
                            newtag.TagShortName = item;
                            newtag.TagName = item;

                            tagsRepository.Insert(newtag);

                            salesTags.TagsId = newtag.Id;
                            salesTags.ComId = ComId ?? 0;
                            ltag.Add(salesTags);
                        }
                        else
                        {
                            salesTags.TagsId = int.Parse(item);
                            salesTags.ComId = ComId ?? 0;
                            ltag.Add(salesTags);
                        }

                    }
                }
                if (ltag != null)
                {
                    model1.SalesTags = ltag;
                }
                if (ls != null)
                {
                    model1.Items = ls;
                }
                if (lt != null)
                {
                    model1.SalesProductTax = lt;
                }
                saleRepository.Insert(model1);


                var email = model.EmailId;

                if (email.Length > 4)
                {
                    var EmailSubject = _customFormStyleRepository.All().Where(x => x.ComId == ComId && x.IsDefault == true).FirstOrDefault()?.StandardEmailSubject ?? "EmailSubject";
                    var EmailBody = _customFormStyleRepository.All().Where(x => x.ComId == ComId && x.IsDefault == true).FirstOrDefault()?.StandardEmailTemplateHolder ?? "EmailBody";
                    Console.WriteLine(EmailBody);
                    var customername = customerRepository.All().Where(x => x.Id.ToString() == model.CustomerId).FirstOrDefault().Name;
                    Console.WriteLine(customername);

                    EmailBody = EmailBody.Replace("[amount]", model1.SaleCode)
                           .Replace("[date]", model1.SalesDate.ToString("dd-MMM-yyyy"))
                           .Replace("[balancedue]", model1.NetAmount.ToString("N"))
                            .Replace("[FullName]", customername)
                            .Replace("[First][Last]", customername)
                            .Replace("[Title][Last]", customername)
                            .Replace("[First]", customername)
                            .Replace("[CompanyName]", customername)
                            .Replace("[DisplayName]", customername);

                    _emailsender.SendEmailAsync(email, EmailSubject, EmailBody);
                }
                return Json(new { error = false, message = "Invoice saved successfully", Id = model1.Id });

            }
            else
            {
                var model1 = new SalesModel();
                var oldModel = saleRepository.All().Where(x => x.Id == model.Id).FirstOrDefault();
                model1.ComId = model.ComId;
                model1.LuserId = model.LuserId;
                model1.Id = model.Id;
                model1.CurrencyId = model.CurrencyId;
                model1.CustomerId = int.Parse(model.CustomerId);
                model1.EmailId = model.EmailId;
                model1.PrimaryAddress = model.PrimaryAddress;
                model1.SalesDate = DateTime.Parse(model.SalesDate);
                model1.DueDate = DateTime.Parse(model.DueDate);
                model1.ShippingVia = model.ShippingVia;
                model1.ShippingDate = DateTime.Parse(model.ShippingDate);
                model1.TrackingNo = model.TrackingNo;
                model1.SaleCode = model.SaleCode;

                model1.FiscalMonthId = model.FiscalMonthId;
                model1.CurrencyRate = model.CurrencyRate;
                model1.SecoundaryAddress = model.SecoundaryAddress;
                model1.ShippingTo = model.ShippingTo;
                model1.MessageInvoice = model.MessageInvoice;
                model1.MessageStatement = model.MessageStatement;
                model1.Total = model.Total;
                model1.SubTotal = model.SubTotal;
                model1.TotalVat = (decimal)model.TotalVat;
                model1.Shipping = model.Shipping;
                model1.ShippingTax = model.ShippingTax;
                model1.AmountsAre = model.AmountsAre;
                model1.NetAmount = (decimal)model.Total;
                model1.StatusRemarks = "Overdue on " + model.DueDate.ToString();
                model1.DocTypeId = doctypeId;
                model1.WarehouseIdMain = model.WarehouseIdMain;
                model1.IsRecurring = model.IsRecurring;
                model1.FileName = oldModel.FileName;
                //model1.ApprovalStatusId = oldModel.ApprovalStatusId;
                model1.salesRecievedtTermsId = model.salesRecievedtTermsId;

                var custname = customerRepository.Find(model1.CustomerId);
                model1.CustomerName = custname.Name;
                List<SalesItemsModel> ls = new List<SalesItemsModel>();
                if (model.SalesItemVM != null)
                {
                    var nonZeroId = new List<int>();
                    nonZeroId = saleItemRepository.All().Where(x => x.SalesId == model.Id).Select(y => y.Id).ToList();

                    foreach (var item in model.SalesItemVM)
                    {
                        var salesitem = new SalesItemsModel();

                        var id = item.Id;
                        if (id == 0)
                        {
                            salesitem.ComId = ComId ?? 0;
                            salesitem.LuserId = UserId ?? 0;
                            salesitem.Id = 0;
                            salesitem.SalesId = model.Id;
                            salesitem.ServiceDate = DateTime.Parse(item.ServiceDate);
                            salesitem.ProductId = int.Parse(item.ProductId);
                            salesitem.Description = item.Description;
                            salesitem.Quantity = double.Parse(item.Quantity);
                            salesitem.Price = float.Parse(item.Price);
                            salesitem.SecondaryPrice = float.Parse(item.SecondaryPrice);
                            salesitem.DefaultPrice = float.Parse(item.DefaultPrice);
                            salesitem.CostPrice = float.Parse(item.CostPrice);
                            salesitem.Amount = float.Parse(item.Amount);
                            salesitem.IndDiscount = float.Parse(item.IndDiscount);
                            salesitem.WarehouseId = item.WarehouseId;
                            salesitem.WHName = item.WHName;
                            if (item.MasterTaxId == null || item.MasterTaxId == "0")
                            {
                                salesitem.MasterTaxId = 0;
                                salesitem.MasterTaxName = "";
                            }
                            else
                            {
                                salesitem.MasterTaxId = int.Parse(item.MasterTaxId);
                                var mastertaxname = _mastersalestaxRepository.Find(salesitem.MasterTaxId);
                                salesitem.MasterTaxName = mastertaxname.Name;

                            }

                            var productname = productRepository.Find(salesitem.ProductId);
                            salesitem.Name = productname.Name;
                            salesitem.PrimaryUnitId = item.PrimaryUnitId;
                            salesitem.SecondaryUnitId = item.SecondaryUnitId;
                            salesitem.ConversionRate = item.ConversionRate;
                            salesitem.InputQuantity = item.InputQuantity;
                            salesitem.Unit = item.Unit;

                            saleItemRepository.Insert(salesitem);
                        }
                        else
                        {
                            if (nonZeroId.Contains(id))
                            {
                                // Remove the element
                                nonZeroId.Remove(id);
                            }

                            salesitem = saleItemRepository.Find(id);
                            salesitem.Id = id;
                            salesitem.ServiceDate = DateTime.Parse(item.ServiceDate);
                            salesitem.ProductId = int.Parse(item.ProductId);
                            salesitem.Description = item.Description;
                            salesitem.Quantity = double.Parse(item.Quantity);
                            salesitem.Price = float.Parse(item.Price);
                            salesitem.SecondaryPrice = float.Parse(item.SecondaryPrice);
                            salesitem.DefaultPrice = float.Parse(item.DefaultPrice);
                            salesitem.CostPrice = float.Parse(item.CostPrice);
                            salesitem.Amount = float.Parse(item.Amount);
                            salesitem.IndDiscount = float.Parse(item.IndDiscount);
                            salesitem.ComId = ComId ?? 0;
                            salesitem.LuserId = UserId ?? 0;
                            salesitem.WarehouseId = item.WarehouseId;
                            salesitem.WHName = item.WHName;
                            if (item.MasterTaxId == null || item.MasterTaxId == "0")
                            {
                                salesitem.MasterTaxId = 0;
                                salesitem.MasterTaxName = "";
                            }
                            else
                            {
                                salesitem.MasterTaxId = int.Parse(item.MasterTaxId);
                                var mastertaxname = _mastersalestaxRepository.Find(salesitem.MasterTaxId);
                                salesitem.MasterTaxName = mastertaxname.Name;

                            }

                            var productname = productRepository.Find(salesitem.ProductId);
                            salesitem.Name = productname.Name;

                            salesitem.PrimaryUnitId = item.PrimaryUnitId;
                            salesitem.SecondaryUnitId = item.SecondaryUnitId;
                            salesitem.ConversionRate = item.ConversionRate;
                            salesitem.InputQuantity = item.InputQuantity;
                            salesitem.Unit = item.Unit;
                            //ls.Add(salesitem);
                            saleItemRepository.Update(salesitem, id);

                        }

                    }

                    if (nonZeroId.Count > 0)
                    {
                        foreach (var id in nonZeroId)
                        {
                            var items = saleItemRepository.All().Where(x => x.Id == id).FirstOrDefault();
                            saleItemRepository.Delete(items);
                        }
                    }

                }
                var data = salesProductTaxRepository.All().Where(x => x.SalesId == model1.Id).ToList();
                if (data != null || data.Count > 0)
                {
                    foreach (var item in data)
                    {
                        salesProductTaxRepository.Delete(item);
                    }
                }
                if (model.SalesProductTaxVM != null)
                {
                    var temp = new SalesProductTaxModel();
                    foreach (var item in model.SalesProductTaxVM)
                    {
                        temp.Id = 0;
                        temp.SalesId = model1.Id;
                        temp.Nickname = item.Nickname;
                        temp.IsSum = item.IsSum;
                        temp.Amount = float.Parse(item.Amount);
                        temp.TotalAmount = float.Parse(item.TotalAmount);
                        temp.TaxId = item.TaxId;
                        temp.ComId = ComId ?? 0;
                        salesProductTaxRepository.Insert(temp);
                    }

                }
                List<SalesTagModel> ltag = new List<SalesTagModel>();
                var tagsData = salesTagRepository.All().Where(x => x.SalesId == model1.Id).ToList();
                if (tagsData.Count > 0)
                {
                    foreach (var tag in tagsData)
                    {
                        salesTagRepository.Delete(tag);
                    }
                }

                if (model.SalesTags.Count > 0)
                {
                    foreach (var item in model.SalesTags)
                    {
                        var salesTags = new SalesTagModel();
                        var newtag = new TagsModel();

                        if (item.Any(char.IsLetter))
                        {
                            newtag.ComId = ComId ?? 0;
                            newtag.TagsType = "G";
                            newtag.TagShortName = item;
                            newtag.TagName = item;

                            tagsRepository.Insert(newtag);

                            salesTags.TagsId = newtag.Id;
                            salesTags.SalesId = model1.Id;
                            salesTags.ComId = ComId ?? 0;
                            salesTagRepository.Insert(salesTags);
                        }
                        else
                        {
                            salesTags.TagsId = int.Parse(item);
                            salesTags.ComId = ComId ?? 0;
                            salesTags.SalesId = model1.Id;
                            salesTagRepository.Insert(salesTags);
                        }

                    }
                }
                saleRepository.Update(model1, model1.Id);
                var email = model.EmailId;

                if (email.Length > 4)
                {

                    var EmailSubject = _customFormStyleRepository.All().Where(x => x.ComId == ComId && x.IsDefault == true).FirstOrDefault()?.StandardEmailSubject ?? "EmailSubject";
                    var EmailBody = _customFormStyleRepository.All().Where(x => x.ComId == ComId && x.IsDefault == true).FirstOrDefault()?.StandardEmailTemplateHolder ?? "EmailBody";
                    Console.WriteLine(EmailBody);
                    var customername = customerRepository.All().Where(x => x.Id.ToString() == model.CustomerId).FirstOrDefault().Name;
                    Console.WriteLine(customername);

                    EmailBody = EmailBody.Replace("[amount]", model1.SaleCode)
                           .Replace("[date]", model1.SalesDate.ToString("dd-MMM-yyyy"))
                           .Replace("[balancedue]", model1.NetAmount.ToString("N"))
                            .Replace("[FullName]", customername)
                            .Replace("[First][Last]", customername)
                            .Replace("[Title][Last]", customername)
                            .Replace("[First]", customername)
                            .Replace("[CompanyName]", customername)
                            .Replace("[DisplayName]", customername);
                    _emailsender.SendEmailAsync(email, EmailSubject, EmailBody);
                }
                return Json(new { error = false, message = "Invoice Updated successfully", Id = model1.Id });

            }
            return View(model);
        }

        [HttpPost]
        [AllowAnonymous]
        public JsonResult UpdateEstimateStatus(int SalesId, string Status, string StatusUpdateBy, DateTime UpdateDate)
        {
            try
            {
                var salesModel = saleRepository.All().Where(x => x.Id == SalesId).FirstOrDefault();
                salesModel.StatusRemarks = Status;
                salesModel.StatusUpdateDate = UpdateDate;
                salesModel.StatusUpdatedBy = StatusUpdateBy;

                saleRepository.Update(salesModel, salesModel.Id);

                return Json(new { success = true, values = "Status Updated Successfully." });

            }
            catch (Exception ex)
            {
                return Json(new { success = false, values = ex.Message.ToString() });
            }
        }

        [HttpPost]
        //[AllowAnonymous]
        [OverridableAuthorize]
        public IActionResult AddUpdateCustomer([FromBody] CustomerModel model)
        {
            var errors = ModelState.Where(x => x.Value.Errors.Any())
           .Select(x => new { x.Key, x.Value.Errors });

            var ComId = HttpContext.Session.GetInt32("ComId");
            var LuserId = (HttpContext.Session.GetInt32("UserId"));

            if (model.Id == 0)
            {

                string uniqueNumber = "C-" + DateTime.Now.ToString("ddMMyyHHmmssfff");
                var doctypeId = _docTypeRepository.All().Where(x => x.DocType == "Customer").Select(x => x.Id).FirstOrDefault();
                if (doctypeId != null)
                {
                    var docPrefix = docPrefixRepository.All().Where(x => x.ComId == ComId && x.DocTypeId == doctypeId).FirstOrDefault();
                    if (docPrefix != null)
                    {
                        uniqueNumber = GetSalesCode(doctypeId);
                    }
                }

                if (model.CustomerCode == null || model.CustomerCode.Length == 0)
                {
                    model.CustomerCode = uniqueNumber;
                }

                customerRepository.Insert(model);

                //procedure call to insert accounthead by multicurrency starts

                var queryname = "procSetAccountHeadForSupplierCustomer";

                var viewquery = $"Exec {queryname} '{ComId}' '{model.LuserId}' '{"Customer"}' '{model.Id}' '{model.CustomerCurrencyId}'";

                Console.WriteLine(viewquery);
                SqlParameter[] parameters = new SqlParameter[5];
                parameters[0] = new SqlParameter("@ComId", ComId);
                parameters[1] = new SqlParameter("@LuserId", model.LuserId);
                parameters[2] = new SqlParameter("@Criteria", "Customer");
                parameters[3] = new SqlParameter("@SupplierId", model.Id);
                parameters[4] = new SqlParameter("@CurrencyId", model.CustomerCurrencyId);

                var datasetabc = new System.Data.DataSet();
                datasetabc = Helper.ExecProcMapDS(queryname, parameters);

                return Json(new { success = "1", error = false, message = "Customer saved successfully", Id = model.Id });

            }
            else
            {
                customerRepository.Update(model, model.Id);

                return Json(new { success = "1", error = false, message = "Customer updated successfully", Id = model.Id });

            }

        }
        [HttpGet]
        [AllowAnonymous]
        public IActionResult DeleteCustomer(int customerId)
        {
            var model = customerRepository.Find(customerId);
            if (model != null)
            {
                customerRepository.Delete(model);

                return Json(new { success = "1", msg = "Deleted Successfully" });

            }
            return Json(new { success = "0", msg = "Delete failed.." });
        }

        [HttpGet]
        [AllowAnonymous]
        public IActionResult GetDueDate(int termsId)
        {
            var model = _termRepository.Find(termsId);
            if (model != null)
            {

                return Json(new { success = "1", msg = "Data Loaded", data = model.DueInFixedDays });

            }
            return Json(new { success = "0", msg = "Not found" });
        }

        [AllowAnonymous]
        public JsonResult GetCustomerCodes()
        {
            var ComId = HttpContext.Session.GetInt32("ComId");

            var customerCode = customerRepository.All().Where(p => p.ComId == ComId).ToList();

            foreach (var item in customerCode)
            {
                if (item.CustomerCode == null)
                {
                    item.CustomerCode = "Not found";
                }
            }

            SelectList masterLCList = new SelectList(customerCode, "Id", "CustomerCode");
            return Json(masterLCList);
        }

        [HttpPost]
        [AllowAnonymous]
        public IActionResult UploadImageForCustomer(IFormFile file, [FromForm] string CustomerId)
        {
            var ComId = HttpContext.Session.GetInt32("ComId");
            var cusomter_info = customerRepository.Find(int.Parse(CustomerId));

            string filePath = configuration.GetValue<string>("MediaManager:VoucherFilePath");
            var folderPath = filePath + "/";
            var filename = string.Empty;

            if (file != null && file.Length > 0)
            {
                filename = cusomter_info.Id + '_' + cusomter_info.ComId + file.FileName;

                var path = Path.Combine(
                    Directory.GetCurrentDirectory(), "wwwroot/Content/Customer",
                    filename);

                using (var stream = new FileStream(path, FileMode.Create))
                {
                    file.CopyTo(stream);
                }
                cusomter_info.FileName = $"/Content/Customer/{filename}";

                string serverFolder = Path.Combine(_webHostEnvironment.WebRootPath, folderPath);
                serverFolder += Guid.NewGuid().ToString() + "_" + file.FileName;
                file.CopyToAsync(new FileStream(serverFolder, FileMode.Create));
            }

            // Update the Purchaseinfo object even when no file was selected
            cusomter_info.FileName = cusomter_info.FileName;
            customerRepository.Update(cusomter_info, cusomter_info.Id);

            return Json(new { status = "File upload Successfully." });
        }

        [HttpPost]
        //[AllowAnonymous]
        [OverridableAuthorize]
        public IActionResult AddUpdateProduct([FromBody] ProductModel model)
        {
            try
            {
                var ComId = HttpContext.Session.GetInt32("ComId");
                if (model.Id == 0)
                {
                    model.ProductTypeId = productTypeRepository.All().Where(x => x.TypeName == model.ProductTypeFlag).Select(y => y.Id).FirstOrDefault();
                    if (model.Code == null || model.Code.Length == 0)
                    {
                        model.Code = "P" + DateTime.Now.ToString("ddMMyyHHmmssfff");
                        var doctypeId = _docTypeRepository.All().Where(x => x.DocType == "Product").FirstOrDefault().Id;

                        var docPrefix = docPrefixRepository.All().Where(x => x.ComId == ComId && x.DocTypeId == doctypeId).FirstOrDefault();
                        if (docPrefix != null)
                        {
                            model.Code = GetSalesCode(doctypeId);
                        }
                    }
                    productRepository.Insert(model);

                    var settings = new JsonSerializerSettings
                    {
                        PreserveReferencesHandling = PreserveReferencesHandling.Objects
                    };

                    string modelStringify = JsonConvert.SerializeObject(model, settings);
                    //var modelStringify = JsonConvert.SerializeObject(model);

                    InsertIntoAuditLog("Product", "Create", modelStringify, model.Id);

                    var purcahseId = 0;

                    if (model.RunTimeLiveStock > 0)
                    {
                        int openingDocTypeId = _docTypeRepository.All().Where(x => x.DocTypeValue == "OpeningStock").FirstOrDefault().Id;
                        int CreditAccId = accountHeadRepository.All().Where(x => (x.AccName.ToLower().Contains("Capital") || x.AccName.ToLower().Contains("Capital")) && x.AccType == "L").FirstOrDefault().Id;
                        int WarehouseId = _warehouseRepository.All().Where(x => x.WhType == "L").FirstOrDefault().Id;


                        PurchaseModel newstargingqty = new PurchaseModel();
                        newstargingqty.PurchaseCode = model.Code = "QSIH" + DateTime.Now.ToString("ddMMyyHHmmssfff");
                        newstargingqty.PurchaseDate = model.OpeningDate;
                        newstargingqty.NetAmount = ((decimal)(model.RunTimeLiveStock * model.CostPrice));
                        newstargingqty.DocTypeId = (int)openingDocTypeId;
                        newstargingqty.WarehouseIdMain = WarehouseId;
                        newstargingqty.IsSystem = true;
                        //newstargingqty.inventory = model.AccIdInventory;
                        //newstargingqty.inventory = model.AccIdInventory;

                        PurchaseItemsModel newstartingqtyItems = new PurchaseItemsModel();

                        newstartingqtyItems.ProductId = model.Id;
                        newstartingqtyItems.Price = model.CostPrice;
                        newstartingqtyItems.SalesUnitPrice = model.Price;
                        //newstartingqtyItems.SalesUnitPrice = model.SalesAccount;
                        //newstartingqtyItems.Quantity = model.RunTimeLiveStock;
                        newstartingqtyItems.QTY = model.RunTimeLiveStock;
                        newstartingqtyItems.Quantity = model.RunTimeLiveStock;
                        newstartingqtyItems.Rate = model.CostPrice;
                        newstartingqtyItems.Amount = model.RunTimeLiveStock * model.CostPrice;
                        newstartingqtyItems.ComId = model.ComId;
                        newstartingqtyItems.LuserId = model.LuserId;
                        newstartingqtyItems.WarehouseId = WarehouseId;


                        newstargingqty.Items.Add(newstartingqtyItems);





                        PurchasePaymentModel newstartingqtyCreditItem = new PurchasePaymentModel();

                        newstartingqtyCreditItem.AccountHeadId = CreditAccId;//owners equity id /// owners capital
                        newstartingqtyCreditItem.Amount = ((decimal)(model.RunTimeLiveStock * model.CostPrice));
                        newstartingqtyCreditItem.ComId = model.ComId;
                        newstartingqtyCreditItem.LuserId = model.LuserId;


                        newstargingqty.PurchasePayments.Add(newstartingqtyCreditItem);


                        purchaseRepository.Insert(newstargingqty);

                        purcahseId = newstargingqty.Id;

                    }

                    return Json(new { success = "1", error = false, message = "Product saved successfully", Id = model.Id, PurchaseId = purcahseId });

                }
                else
                {
                    var product = productRepository.All().Where(x => x.Id == model.Id).FirstOrDefault();
                    model.ProductTypeId = productTypeRepository.All().Where(x => x.TypeName == model.ProductTypeFlag).Select(y => y.Id).FirstOrDefault();
                    model.Code = product.Code;
                    model.LuserId = product.LuserId;
                    model.ImagePath = product.ImagePath;
                    productRepository.Update(model, model.Id);

                    var settings = new JsonSerializerSettings
                    {
                        PreserveReferencesHandling = PreserveReferencesHandling.Objects
                    };
                    var modelStringify = JsonConvert.SerializeObject(model, settings);
                    InsertIntoAuditLog("Product", "Update", modelStringify, model.Id);

                    var productItemCount = purchaseItemsRepository.All().Where(x => x.ProductId == model.Id).Count();
                    if (model.RunTimeLiveStock > 0 && productItemCount == 0)
                    {
                        int openingDocTypeId = _docTypeRepository.All().Where(x => x.DocTypeValue == "OpeningStock").FirstOrDefault().Id;
                        int CreditAccId = accountHeadRepository.All().Where(x => (x.AccName.ToLower().Contains("Capital") || x.AccName.ToLower().Contains("Capital")) && x.AccType == "L").FirstOrDefault().Id;
                        int WarehouseId = _warehouseRepository.All().Where(x => x.WhType == "L").FirstOrDefault().Id;


                        PurchaseModel newstargingqty = new PurchaseModel();
                        newstargingqty.PurchaseCode = model.Code = "QSIH" + DateTime.Now.ToString("ddMMyyHHmmssfff");
                        newstargingqty.PurchaseDate = model.OpeningDate;
                        newstargingqty.NetAmount = ((decimal)(model.RunTimeLiveStock * model.CostPrice));
                        newstargingqty.DocTypeId = (int)openingDocTypeId;
                        newstargingqty.WarehouseIdMain = WarehouseId;
                        newstargingqty.IsSystem = true;
                        //newstargingqty.inventory = model.AccIdInventory;
                        //newstargingqty.inventory = model.AccIdInventory;

                        PurchaseItemsModel newstartingqtyItems = new PurchaseItemsModel();

                        newstartingqtyItems.ProductId = model.Id;
                        newstartingqtyItems.Price = model.CostPrice;
                        newstartingqtyItems.SalesUnitPrice = model.Price;
                        newstartingqtyItems.Rate = model.CostPrice;
                        //newstartingqtyItems.SalesUnitPrice = model.SalesAccount;
                        //newstartingqtyItems.Quantity = model.RunTimeLiveStock;
                        newstartingqtyItems.QTY = model.RunTimeLiveStock;
                        newstartingqtyItems.Quantity = model.RunTimeLiveStock;
                        newstartingqtyItems.Amount = model.RunTimeLiveStock * model.CostPrice;
                        newstartingqtyItems.ComId = model.ComId;
                        newstartingqtyItems.LuserId = model.LuserId;
                        newstartingqtyItems.WarehouseId = WarehouseId;


                        newstargingqty.Items.Add(newstartingqtyItems);





                        PurchasePaymentModel newstartingqtyCreditItem = new PurchasePaymentModel();

                        newstartingqtyCreditItem.AccountHeadId = CreditAccId;//owners equity id /// owners capital
                        newstartingqtyCreditItem.Amount = ((decimal)(model.RunTimeLiveStock * model.CostPrice));
                        newstartingqtyCreditItem.ComId = model.ComId;
                        newstartingqtyCreditItem.LuserId = model.LuserId;


                        newstargingqty.PurchasePayments.Add(newstartingqtyCreditItem);


                        purchaseRepository.Insert(newstargingqty);

                    }

                    var warehouseData = _productWarehouseRepository.All(true, true).Where(x => x.ProductId == model.Id).ToList();
                    foreach (var item in warehouseData)
                    {
                        _productWarehouseRepository.Delete(item);
                    }

                    foreach (var newitem in model.ProductWarehouseList)
                    {
                        newitem.ProductId = model.Id;
                        newitem.Id = 0;
                        _productWarehouseRepository.Insert(newitem);
                    }


                    return Json(new { success = "1", error = false, message = "Product updated successfully", Id = model.Id });

                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        [HttpPost]
        [AllowAnonymous]
        public IActionResult UploadImageForProduct(IFormFile file, [FromForm] string ProductId)
        {
            var ComId = HttpContext.Session.GetInt32("ComId");
            var product_info = productRepository.Find(int.Parse(ProductId));

            string filePath = configuration.GetValue<string>("MediaManager:VoucherFilePath");
            var folderPath = filePath + "/";
            var filename = string.Empty;

            if (file != null && file.Length > 0)
            {
                filename = product_info.Id + '_' + product_info.ComId + file.FileName;

                var path = Path.Combine(
                    Directory.GetCurrentDirectory(), "wwwroot/Content/Product",
                    filename);

                using (var stream = new FileStream(path, FileMode.Create))
                {
                    file.CopyTo(stream);
                }
                product_info.ImagePath = $"/Content/Product/{filename}";

                string serverFolder = Path.Combine(_webHostEnvironment.WebRootPath, folderPath);
                serverFolder += Guid.NewGuid().ToString() + "_" + file.FileName;
                file.CopyToAsync(new FileStream(serverFolder, FileMode.Create));
            }

            // Update the Purchaseinfo object even when no file was selected
            product_info.ImagePath = product_info.ImagePath;
            productRepository.Update(product_info, product_info.Id);

            return Json(new { status = "File upload Successfully." });
        }

        [HttpPost]
        //[AllowAnonymous]
        [OverridableAuthorize]
        public JsonResult GetProductInfoEdit(int id)
        {
            try
            {

                var product = productRepository.All().Include(x => x.ProductTypes).Where(x => x.Id == id);

                var purchaseCheck = purchaseItemsRepository.All().Where(x => x.ProductId == id).Select(x => x.PurchaseId).FirstOrDefault();

                if (purchaseCheck == null)
                {
                    purchaseCheck = 0;
                }


                var productDetails = product.Select(e => new
                {
                    Id = e.Id,
                    Name = e.Name,
                    EANCode = e.EANCode,
                    Code = e.Code,
                    CategoryId = e.CategoryId,
                    RunTimeLiveStock = e.RunTimeLiveStock,
                    OpeningDate = e.OpeningDate,
                    ROL = e.ROL,
                    Description = e.Description,
                    Price = e.Price,
                    AccIdSales = e.AccIdSales,
                    AccIdInventory = e.AccIdInventory,
                    IsTaxInclusive = e.IsTaxInclusive,
                    SalesTaxId = e.SalesTaxId,
                    Remarks = e.Remarks,
                    CostPrice = e.CostPrice,
                    PurchaseTaxId = e.PurchaseTaxId,
                    UnitId = e.UnitId,
                    ColorName = e.ColorName,
                    SizeName = e.SizeName,
                    ModelName = e.ModelName,
                    AccIdConsumption = e.AccIdConsumption,
                    IsPurchaseTaxInclusive = e.IsPurchaseTaxInclusive,
                    SupplierId = e.SupplierId,
                    ProductType = e.ProductTypes.TypeName,
                    e.ImagePath,
                    ProductWarehouseList = e.ProductWarehouseList.Select(x => new
                    {
                        x.Id,
                        x.WarehouseId,
                        Warehouse = x.Warehouse.WhShortName
                    })
                }).FirstOrDefault();

                return Json(new { Success = 1, success = true, data = productDetails, PurchaseId = purchaseCheck });
                //return Json("tesst" );

            }
            catch (Exception ex)
            {
                return Json(new { success = false, values = ex.Message.ToString() });
            }
            //return Json(new SelectList(product, "Value", "Text" ));
        }

        [HttpPost]
        //[AllowAnonymous]
        [OverridableAuthorize]
        public ActionResult DeleteProduct(int productId)
        {
            var model = productRepository.Find(productId);

            if (model != null)
            {
                if (costCalculatedRepository.All().Where(x => x.ProductId == productId).Count() > 1)
                {
                    TempData["Message"] = "Data Delete Not Possible";
                    TempData["Status"] = "3";
                    return RedirectToAction("InvoiceList");
                }

                productRepository.Delete(model);


                return Json(new { success = "1", msg = "Deleted Successfully" });
            }
            return Json(new { success = "0", msg = "Deleted Failed.." });
        }

        [HttpGet]
        [OverridableAuthorize]
        public IActionResult InactiveInvoice(int InvoiceId)
        {
            try
            {
                var data = saleRepository.Find(InvoiceId);
                //data.IsDelete = true;
                //saleRepository.Update(data,InvoiceId);
                if (data.IsRecurring == true)
                {
                    var item = recurringDetailsRepository.All().Where(x => x.SalesId == InvoiceId).FirstOrDefault();
                    recurringDetailsRepository.Delete(item);
                }
                saleRepository.Delete(data);

                var transactionapproval = transactionApprovalStatusRepository.All().Where(x => x.SalesId == InvoiceId).FirstOrDefault();
                if (transactionapproval != null)
                {
                    transactionApprovalStatusRepository.Delete(transactionapproval);
                }

                return Json(new { success = "1", msg = "Deleted Successfully" });
            }
            catch
            {
                //var data = saleItemRepository.All().Where(x=>x.SalesId == InvoiceId).FirstOrDefault();
                //var parentSalesItem = data.SalesItemsId;

                //var salesId = saleItemRepository.All().Where(x => x.Id == parentSalesItem).Select(x=>x.SalesId).FirstOrDefault();

                //var salesCode = saleRepository.All().Where(x=>x.Id == salesId).Select(x=>x.SaleCode).FirstOrDefault();

                var data = saleItemRepository.All().Where(x => x.SalesId == InvoiceId).ToList();

                foreach (var item in data)
                {
                    var childSalesItem = saleItemRepository.All().Where(x => x.SalesItemsId == item.Id).ToList();
                    if (childSalesItem.Count > 0)
                    {
                        foreach (var child in childSalesItem)
                        {
                            var childSalesId = child.SalesId;
                            var salesCode = saleRepository.All().Where(x => x.Id == childSalesId).Select(x => x.SaleCode).FirstOrDefault();

                            var message = "This document is linked with " + salesCode;

                            return Json(new { success = "0", msg = message });
                        }
                    }
                }
                return Json(new { success = "0", msg = "Occuring error while deleting" });

            }

        }

        //[HttpPost]
        //[AllowAnonymous]
        //public IActionResult UploadImage(IFormFile file, [FromForm] string InvoiceId)
        //{
        //    var ComId = HttpContext.Session.GetInt32("ComId");
        //    var invoice_info = saleRepository.Find(int.Parse(InvoiceId));

        //    string filePath = configuration.GetValue<string>("MediaManager:VoucherFilePath");
        //    var folderPath = filePath + "/";
        //    var filename = string.Empty;

        //    if (file != null && file.Length > 0)
        //    {
        //        filename = invoice_info.Id + '_' + invoice_info.ComId + file.FileName;

        //        var path = Path.Combine(
        //            Directory.GetCurrentDirectory(), "wwwroot/Content/InvoiceBill",
        //            filename);

        //        using (var stream = new FileStream(path, FileMode.Create))
        //        {
        //            file.CopyTo(stream);
        //        }
        //        invoice_info.FileName = $"/Content/InvoiceBill/{filename}";

        //        string serverFolder = Path.Combine(_webHostEnvironment.WebRootPath, folderPath);
        //        serverFolder += Guid.NewGuid().ToString() + "_" + file.FileName;
        //        file.CopyToAsync(new FileStream(serverFolder, FileMode.Create));
        //    }

        //    // Update the Purchaseinfo object even when no file was selected
        //    invoice_info.FileName = invoice_info.FileName;
        //    saleRepository.Update(invoice_info, invoice_info.Id);

        //    return Json(new { status = "File upload Successfully." });
        //}

        [HttpPost]
        [AllowAnonymous]
        public IActionResult UploadImage(List<IFormFile> files, [FromForm] string InvoiceId)
        {
            var ComId = HttpContext.Session.GetInt32("ComId");
            var invoice_info = saleRepository.Find(int.Parse(InvoiceId));

            string filePath = configuration.GetValue<string>("MediaManager:VoucherFilePath");
            var folderPath = Path.Combine(_webHostEnvironment.WebRootPath, filePath);
            Directory.CreateDirectory(folderPath); // Ensure the directory exists

            if (files != null && files.Count > 0)
            {
                foreach (var file in files)
                {
                    if (file.Length > 0)
                    {
                        var filename = invoice_info.Id.ToString() + '_' + invoice_info.ComId.ToString() + "_" + file.FileName;
                        var path = Path.Combine(folderPath, filename);

                        using (var stream = new FileStream(path, FileMode.Create))
                        {
                            file.CopyTo(stream);
                        }
                        // Update the invoice_info with each file uploaded
                        invoice_info.FileName += $"/Content/VoucherFile/{filename};";
                    }
                }
            }
            else
            {
                // Handle the case where no file was selected if necessary
                invoice_info.FileName = invoice_info.FileName;
            }

            saleRepository.Update(invoice_info, invoice_info.Id);

            return Json(new { status = "Files uploaded successfully." });
        }

        [AllowAnonymous]
        [HttpGet]
        public IActionResult RecurringTransactionList()
        {
            return View();
        }

        [AllowAnonymous]
        [HttpGet]
        public IActionResult GetRecurringList()
        {
            try
            {
                var ComId = HttpContext.Session.GetInt32("ComId");

                var recurringList = recurringDetailsRepository.All().Where(x => x.ComId == ComId && x.IsDelete == false).OrderByDescending(x => x.Id).ToList();

                var data = new List<RecurringDetailsModel>();

                foreach (var item in recurringList)
                {
                    if (item.SalesId != null)
                    {
                        var salesData = saleRepository.All().Include(x => x.DocTypeList).Where(x => x.Id == item.SalesId).FirstOrDefault();

                        item.DocType = salesData.DocTypeList.DocType;
                        item.NetAmount = salesData.NetAmount;
                        item.CustomerOrSupplier = salesData.CustomerName;
                    }
                    if (item.PurchaseId != null)
                    {
                        var purchaseData = purchaseRepository.All().Include(x => x.DocTypeList).Where(x => x.Id == item.PurchaseId).FirstOrDefault();

                        item.DocType = purchaseData.DocTypeList.DocType;
                        item.NetAmount = purchaseData.NetAmount;
                        item.CustomerOrSupplier = purchaseData.SupplierName;
                    }
                    if (item.TransactionId != null)
                    {
                        var trxnData = transactionRepository.All().Where(x => x.Id == item.TransactionId).FirstOrDefault();

                        item.DocType = trxnData.TransactionCategory;
                        item.NetAmount = trxnData.TransactionAmount;
                        item.CustomerOrSupplier = "";
                    }

                    data.Add(item);
                }

                return Json(new { Success = 1, data = data, ex = "Data " });
            }
            catch (Exception ex)
            {
                return Json(new { Success = 0, ex = ex.InnerException?.InnerException?.Message ?? ex.Message });
            }
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

                var model = saleRepository.Find(firstPart);


                model.FileName = model.FileName.Replace(fileName + ";", "");


                // Update model in repository if needed
                saleRepository.Update(model, model.Id);

                return Json(new { Success = 1, ex = "Data " });
            }
            catch (Exception ex)
            {
                return Json(new { Success = 0, ex = ex.InnerException?.InnerException?.Message ?? ex.Message });
            }
        }

        public List<SelectListItem> GetDurationItems()
        {
            return new List<SelectListItem>
                {
                    new SelectListItem { Text = "Today", Value = "Today", Selected = true },
                    new SelectListItem { Text = "Yesterday", Value = "Yesterday" },
                    new SelectListItem { Text = "This Week", Value = "This Week" },
                    new SelectListItem { Text = "Last Week", Value = "Last Week" },
                    new SelectListItem { Text = "This Month", Value = "This Month" },
                    new SelectListItem { Text = "This Quarter", Value = "This Quarter" },
                    new SelectListItem { Text = "Last Quarter", Value = "Last Quarter" },
                    new SelectListItem { Text = "This Year", Value = "This Year" },
                    new SelectListItem { Text = "Last Year", Value = "Last Year" },
                    new SelectListItem { Text = "Last Month", Value = "Last Month" },
                    //new SelectListItem { Text = "This Week-to-date", Value = "This Week-to-date" },
                    //new SelectListItem { Text = "Next Week", Value = "Next Week" },
                    //new SelectListItem { Text = "Next Month", Value = "Next Month" },
                    //new SelectListItem { Text = "Next Quarter", Value = "Next Quarter" },
                    new SelectListItem { Text = "Next Year", Value = "Next Year" },
                    new SelectListItem { Text = "Custom", Value = "Custom" },
                    new SelectListItem { Text = "All", Value = "All" }
                };
        }

        public void InsertIntoAuditLog(string doctype, string actionType, string keyValue, int Id)
        {
            var model = new AuditLogModel();

            model.DocTypeId = _docTypeRepository.All().Where(x => x.DocType == doctype).FirstOrDefault().Id;
            model.DocType = doctype;
            model.KeyValue = keyValue;
            model.TransactionId = Id;
            model.Action = actionType;

            auditLogRepository.Insert(model);
        }


        [OverridableAuthorize]
        [HttpGet]
        public IActionResult InvoiceList(string Type, int IsRefresh = 1)
        {
            var ComId = HttpContext.Session.GetInt32("ComId");
            var LuserId = (HttpContext.Session.GetInt32("UserId"));
            var isMultiCurrency = _storeSettingRepository.All().Where(x => x.ComId == ComId).FirstOrDefault().isMultiCurrency;

            var userInfo = UserAccountRepository.All().Include(x => x.UserRole).Where(x => x.Id == LuserId).FirstOrDefault();

            if (userInfo.UserRole.RoleName == "Store Keeper")
            {
                ViewBag.isStoreKeeper = 1;
            }
            else
            {
                ViewBag.isStoreKeeper = 0;
            }

            ViewBag.isMultiCurrency = isMultiCurrency;

            var doctyperesult = _docTypeRepository.All();

            var allTransactionItem = new SelectListItem
            {
                Text = "All Transaction",
                Value = "0"
            };
            var selectListItems = new List<SelectListItem> { allTransactionItem };

            // Add the rest of the items           
            selectListItems.AddRange(doctyperesult
               .Where(x => x.DocFor == "Sales" && !new[] { "Receive payment", "Stock Count", "Time Activity" }.Contains(x.DocType))
               .Select(s => new SelectListItem { Text = s.DocType, Value = s.Id.ToString() }));

            allTransactionItem = new SelectListItem
            {
                Text = "Overdue",
                Value = "9999"
            };
            selectListItems.Add(allTransactionItem);
            allTransactionItem = new SelectListItem
            {
                Text = "Recently Paid",
                Value = "8888"
            };
            selectListItems.Add(allTransactionItem);


            ViewBag.ListType = Type ?? "Sales";
            ViewBag.Status = new SelectList(selectListItems, "Value", "Text");

            var paymentstatusItems = new List<SelectListItem>
            {
                new SelectListItem { Text = "All", Value = "All" },
                new SelectListItem { Text = "Cash", Value = "Cash" },
                new SelectListItem { Text = "Bank", Value = "Bank" }
            };

            var paymentselectList = new SelectList(paymentstatusItems, "Value", "Text");

            ViewData["PaymentStatus"] = paymentselectList;

            //var durationItems = new List<SelectListItem>
            //{
            //    new SelectListItem { Text = "Today", Value = "Today" },
            //    new SelectListItem { Text = "This month", Value = "This month" },
            //    new SelectListItem { Text = "Last month", Value = "Last month" },
            //    new SelectListItem { Text = "Last year", Value = "Last year" },
            //    new SelectListItem { Text = "This year", Value = "This year" },
            //    new SelectListItem { Text = "All", Value = "All" }
            //};            
            //var durationList = new SelectList(durationItems, "Value", "Text");
            //ViewData["Duration"] = durationList;

            ViewData["Duration"] = GetDurationItems();

            var deliveryOptions = new List<SelectListItem>
            {

                new SelectListItem { Text = "Use Company default", Value = "Use Company default" },
                new SelectListItem { Text = "Print Later", Value = "Print Later" },
                new SelectListItem { Text = "Send Later", Value = "Send Later" },
                new SelectListItem { Text = "None", Value = "None" }
            };

            var deliveryOption = new SelectList(deliveryOptions, "Value", "Text");
            ViewData["DeliveryOptions"] = deliveryOptions;

            var language = new List<SelectListItem>
            {

                new SelectListItem { Text = "English", Value = "English" },
                new SelectListItem { Text = "Bangla", Value = "Bangla" }
            };

            var languages = new SelectList(language, "Value", "Text");
            ViewData["Language"] = languages;

            var customerList = customerRepository.All().Where(p => p.ComId == ComId)
            .Select(x => new SelectListItem
            {
                Text = x.Name,
                Value = x.Id.ToString()
            }).ToList();

            // Insert the "Please select" option at the beginning of the list
            customerList.Insert(0, new SelectListItem { Value = "0", Text = "All" });

            ViewBag.Customers = new SelectList(customerList, "Value", "Text");

            SelectListItem abc = new SelectListItem() { Text = "Warehouse", Value = "" };
            var x = _FromWarehousePermissionRepository.GetAllForDropDown().ToList();
            if (x.Count() == 0)
            {
                x = _warehouseRepository.GetWarehouseLedgerHeadForDropDown().ToList();
                x.Append(abc);
            }
            else
            {
                x.Append(abc);
            }
            ViewBag.WarehouseId = x.ToList();

            var paymentmethods = paymentTypeRepository.All().ToList();
            SelectList paymentMethodList = new SelectList(paymentmethods, "Id", "TypeName");
            ViewData["PaymentMethod"] = paymentMethodList;

            var paymentType = productTypeRepository.All()
            .Select(x => new { TypeName = x.TypeName, IconClass = x.IconClass, Description = x.Description })
            .ToList();

            ViewBag.PaymentType = paymentType;

            ViewBag.CategoryId = categoryRepository.GetAllForDropDown();
            ViewBag.BrandId = brandRepository.GetAllForDropDown();
            ViewBag.ModelId = productRepository.GetModelDropDown();


            ViewData["SalesTaxList"] = _mastersalestaxRepository.GetAllSalesTaxForDropDown();
            ViewData["PurchaseTaxList"] = _mastersalestaxRepository.GetAllPurchaseTaxForDropDown();

            ViewBag.IncomeAccount = accountHeadRepository.GetSalesDropdown();
            ViewBag.Supplier = supplierRepository.GetAllForDropDown();
            ViewBag.Inventory = accountHeadRepository.GetInventoryDropdown();
            ViewBag.Unit = _unitRepository.GetAllForDropDown();

            ViewBag.ImagePath = "";

            SqlParameter[] parameters = new SqlParameter[1];
            parameters[0] = new SqlParameter("@ComId", ComId);

            var datasetabc = new System.Data.DataSet();
            datasetabc = Helper.ExecProcMapDS("CountingStock", parameters);
            var OutOfStock = 0;
            var LowStock = 0;
            var availableStock = 0;
            var allStock = 0;
            var dataTable = datasetabc.Tables[0];
            foreach (DataRow row in dataTable.Rows)
            {
                OutOfStock = row.Field<Int32>("OutOfStock");
                LowStock = row.Field<Int32>("LowStock");
                availableStock = row.Field<Int32>("availableStock");
                allStock = row.Field<Int32>("allStock");
                break;
            }
            ViewBag.LowStock = LowStock.ToString();
            ViewBag.OutOfStock = OutOfStock.ToString();
            ViewBag.availableStock = availableStock.ToString();
            ViewBag.allStock = allStock.ToString();

            if (Type == "Products")
            {
                if (IsRefresh == 1)
                {
                    var UserId = HttpContext.Session.GetInt32("UserId");

                    var productid = "";

                    string dtFrom = DateTime.Now.Date.ToString("dd-MMM-yy");
                    string dtTo = DateTime.Now.Date.ToString("dd-MMM-yy");


                    var query = $"Exec Inv_ProductBalance '{ComId}','{DateTime.Parse(dtFrom)}','{DateTime.Parse(dtTo)}','{productid}','','','','','','','','1'";

                    SqlParameter[] parameters2 = new SqlParameter[12];
                    parameters2[0] = new SqlParameter("@ComId", ComId);
                    parameters2[1] = new SqlParameter("@FromDate", DateTime.Parse(dtFrom));
                    parameters2[2] = new SqlParameter("@ToDate", DateTime.Parse(dtTo));
                    parameters2[3] = new SqlParameter("@ProductId", productid);
                    parameters2[4] = new SqlParameter("@WarehouseId", "");
                    parameters2[5] = new SqlParameter("@CategoryId", "");
                    parameters2[6] = new SqlParameter("@BrandId", "");
                    parameters2[7] = new SqlParameter("@SizeName", "1");
                    parameters2[8] = new SqlParameter("@ColorName", "");
                    parameters2[9] = new SqlParameter("@ModelName", "");
                    parameters2[10] = new SqlParameter("@SupplierId", "");
                    parameters2[11] = new SqlParameter("@BalanceUpdate", "1");

                    Helper.ExecProc("Inv_ProductBalance", parameters2);


                }
            }

            if (Type == "Customers")
            {
                var customerid = "";

                string dtFrom = DateTime.Now.Date.ToString("dd-MMM-yy");
                string dtTo = DateTime.Now.Date.ToString("dd-MMM-yy");
                var Types = "Customer";


                var quary = $"Exec Acc_CustomerBalance  '" + ComId + "','" + customerid + "',0,'" + dtFrom + "' ,'" + dtTo + "','" + Type + "',1";


                SqlParameter[] parameters3 = new SqlParameter[7];
                parameters3[0] = new SqlParameter("@ComId", ComId);
                parameters3[1] = new SqlParameter("@CustomerId", customerid);
                parameters3[2] = new SqlParameter("@UrlLink", "");
                parameters3[3] = new SqlParameter("@FromDate", DateTime.Parse(dtFrom));
                parameters3[4] = new SqlParameter("@ToDate", DateTime.Parse(dtTo));
                parameters3[5] = new SqlParameter("@LedgerFor", Types);
                parameters3[6] = new SqlParameter("@BalanceUpdate", "1");


                Helper.ExecProc("Acc_CustomerBalance", parameters3);
            }
            return View();
        }

        public string GetSalesCode(int doctypeId)
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
        public JsonResult GetExpenseAccount()
        {
            var ComId = HttpContext.Session.GetInt32("ComId");
            var listeddata = accountHeadRepository.GetConsumptionDropdown();
            return Json(listeddata);
        }
        
        [AllowAnonymous]
        public JsonResult GetInventoryAccount(string type)
        {
            var inventoryData = accountHeadRepository.GetInventoryDropdown();

            IEnumerable<SelectListItem> listeddata;
            if (type == "Inventory" || type == null)
            {
                listeddata = inventoryData;
            }
            else
            {
                var expenseData = accountHeadRepository.GetExpenseHeadForDropDown();

                listeddata = inventoryData.Concat(expenseData);
            }
            return Json(listeddata);
        }

        [AllowAnonymous]
        [HttpGet]
        public IActionResult GetInvoiceList1(string status, string duration, int customerId, int page = 1, decimal size = 10, string searchquery = "")  //It's Required
        {
            try
            {
                var ComId = HttpContext.Session.GetInt32("ComId");
                var salesId = 0;

                SqlParameter[] sqlParameter1 = new SqlParameter[3];
                sqlParameter1[0] = new SqlParameter("@ComId", ComId);
                sqlParameter1[1] = new SqlParameter("@SalesId", salesId);
                sqlParameter1[2] = new SqlParameter("@CustomerId", customerId);
                Helper.ExecProc("[SalesStatusUpdate]", sqlParameter1);

                var salelist = saleRepository.All();

                if (searchquery?.Length > 1)
                {
                    salelist = salelist.Where(x =>
                    x.DocTypeList.DocType.ToLower().Contains(searchquery.ToLower()) ||
                    x.SaleCode.ToLower().Contains(searchquery.ToLower()) ||
                    x.CustomerName.ToLower().Contains(searchquery.ToLower()) ||
                    x.Total.ToString().ToLower().Contains(searchquery.ToLower())
               );

                }

                if (status != "0" && status != null)
                {
                    salelist = salelist.Where(x => x.DocTypeId == int.Parse(status));
                    //if (status == "Unpaid")
                    //{

                    //}
                    //else if (status == "Paid")
                    //{
                    //    salelist = salelist.Where(x => x.Status == "paid");
                    //}
                }

                if (!string.IsNullOrEmpty(duration))
                {
                    DateTime startDate, endDate;

                    if (duration == "Today")
                    {
                        startDate = DateTime.Today;
                        endDate = DateTime.Today.AddDays(1);
                    }
                    else if (duration == "This month")
                    {
                        startDate = new DateTime(DateTime.Today.Year, DateTime.Today.Month, 1);
                        endDate = startDate.AddMonths(1);
                    }
                    else if (duration == "Last month")
                    {
                        startDate = new DateTime(DateTime.Today.Year, DateTime.Today.Month, 1).AddMonths(-1);
                        endDate = new DateTime(DateTime.Today.Year, DateTime.Today.Month, 1);
                    }
                    else if (duration == "Last year")
                    {
                        startDate = new DateTime(DateTime.Today.Year - 1, 1, 1);
                        endDate = new DateTime(DateTime.Today.Year, 1, 1);
                    }
                    else if (duration == "This year")
                    {
                        startDate = new DateTime(DateTime.Today.Year, 1, 1);
                        endDate = new DateTime(DateTime.Today.Year + 1, 1, 1);
                    }
                    else
                    {
                        // Handle other duration options if needed
                        startDate = endDate = DateTime.MinValue;
                    }

                    salelist = salelist.Where(x => x.SalesDate >= startDate && x.SalesDate < endDate);
                }

                if (customerId > 0)
                {
                    salelist = salelist.Where(x => x.CustomerId == customerId);
                }

                var data = salelist.Where(x => x.IsRecurring == false).Include(x => x.DocTypeList).Include(x => x.Items).OrderByDescending(x => x.Id);

                salelist = salelist.Where(x => x.IsRecurring == false);

                decimal TotalRecordCount = salelist.Count();
                var PageCountabc = decimal.Parse((TotalRecordCount / size).ToString());
                var PageCount = Math.Ceiling(PageCountabc);

                decimal skip = (page - 1) * size;


                var query = from e in salelist.Include(x => x.Items)
                            .ThenInclude(x => x.Product).ThenInclude(x => x.Category)
                            .Include(x => x.SalesPayments).ThenInclude(x => x.vChartofAccounts)
                            .Include(x => x.SalesPayments).ThenInclude(x => x.Transaction)
                            .Include(x => x.SalesReturn).ThenInclude(x => x.SalesReturnPayments)
                            .Include(x => x.DocTypeList)


                            select new
                            {
                                Id = e.Id,
                                SaleCodes = e.SaleCode,
                                SalesDates = e.SalesDate,
                                SalesDateString = e.SalesDate.ToString("dd-MMM-yy"),

                                SalesUser = e.UserAccountList.Name,

                                CustomerNames = (e.CustomerName.Length == 0 || e.CustomerName == null) ? e.CustomerModel.Name : e.CustomerName,
                                //CustomerName = e.CustomerName,
                                PrimaryAddress = e.PrimaryAddress,
                                SecoundaryAddress = e.SecoundaryAddress,
                                Notes = e.Notes,
                                PhoneNo = e.PhoneNo,
                                Discount = e.Discount,
                                e.IsDelete,
                                CustomerCommissionAmount = e.CustomerCommissionAmount,
                                SRCommissionAmount = e.SRCommissionAmount,



                                Totals = e.Total,
                                StatusRemarkss = e.StatusRemarks,
                                NetAmount = e.NetAmount,
                                ServiceCharge = e.ServiceCharge,
                                TotalVat = e.TotalVat,
                                Shipping = e.Shipping,
                                DocTypes = e.DocTypeList.DocType,
                                //TransactionCode = e.AccountTransaction.,



                                isPOSSales = e.isPOSSales,
                                isSerialSales = e.isSerialSales,
                                isPosted = e.isPosted,
                                FinalCostingPrice = e.FinalCostingPrice,
                                Profit = e.Profit,
                                ProfitPercentage = e.ProfitPercentage,
                                Location = e.Warehouses.WhShortName,
                                StatusPosted = e.isPosted != false ? "Posted" : "Not Posted",
                                PaidAmt = e.SalesPayments.Sum(x => x.Amount),// e.PaidAmt,
                                                                             //ReceivingHead = e.CreditAccount != null ? e.CreditAccount.AccName : "=N/A="
                                                                             //SalesPayments = e.SalesPayments.ToList(),
                                SalesReturnPayments = e.SalesReturn.FirstOrDefault().SalesReturnPayments.Sum(x => x.Amount),
                                SalesReturnAmount = e.SalesReturn.Sum(x => x.NetAmount),
                                SalesPayments = e.SalesPayments.Select(x => new
                                {
                                    x.SalesId,
                                    x.PaymentCardNo,
                                    x.isPosted,
                                    x.Amount,
                                    x.RowNo,
                                    x.AccountHeadId,
                                    AccType = x.vChartofAccounts.AccType,
                                    AccName = x.vChartofAccounts.AccName,
                                    TransactionCode = x.Transaction.TransactionCode
                                }),
                                SalesItems = e.Items.Select(x => new
                                {
                                    x.Id,
                                    CategoryName = x.Product.Category.Name,
                                    ProductCode = x.Product.Code,
                                    ProductName = x.Product.Name,

                                    BatchSerial = x.BatchSerialItems.Select(x => new
                                    {
                                        BatchSerialNo = x.PurchaseBatchItems.BatchSerialNo
                                    }),

                                    Price = Math.Round(x.Price, 4),
                                    CostPrice = Math.Round(x.CostPrice, 4),
                                    AvgCostPrice = Math.Round(x.AvgCostPrice, 4),
                                    IndDiscountProportion = Math.Round(x.IndDiscountProportion, 4),
                                    Quantity = x.Quantity,
                                    //ProfitPer = x.profit,
                                    CommissionAmount = x.CommissionAmount

                                })
                                //Items = e.Items
                            };



                var abcd = query.OrderByDescending(x => x.Id).Skip(int.Parse(skip.ToString())).Take(int.Parse(size.ToString())).ToList();
                var pageinfo = new PagingInfo();
                pageinfo.PageCount = int.Parse(PageCount.ToString());
                pageinfo.PageNo = page;
                pageinfo.PageSize = int.Parse(size.ToString());
                pageinfo.TotalRecordCount = int.Parse(TotalRecordCount.ToString());

                return Json(new { Success = 1, error = false, data = abcd, page = page, size = size, last_page = pageinfo.PageCount, total = pageinfo.TotalRecordCount });

                //return Json(new { Success = 1, data = data, ex = "Data " });
            }
            catch (Exception ex)
            {
                return Json(new { Success = 0, ex = ex.InnerException?.InnerException?.Message ?? ex.Message });
            }
        }

        public static string[] GetDateRange(string criteria, DateTime fromDate, DateTime toDate)
        {
            string[] dateRange = new string[2];

            switch (criteria)
            {
                case "Today":
                    DateTime startDateToday = DateTime.Today;
                    DateTime endDateToday = DateTime.Today.AddDays(1);
                    dateRange[0] = startDateToday.ToString("dd-MMM-yyyy");
                    dateRange[1] = endDateToday.ToString("dd-MMM-yyyy");
                    break;
                case "Yesterday":
                    DateTime yesterday = fromDate.AddDays(-1);
                    dateRange[0] = yesterday.ToString("dd-MMM-yyyy");
                    dateRange[1] = yesterday.ToString("dd-MMM-yyyy");
                    break;
                case "This Week":
                    int daysToStartOfWeek = (int)fromDate.DayOfWeek;
                    int daysToEndOfWeek = 6 - (int)fromDate.DayOfWeek;
                    DateTime startDateThisWeek = fromDate.AddDays(-daysToStartOfWeek);
                    DateTime endDateThisWeek = toDate.AddDays(daysToEndOfWeek);
                    dateRange[0] = startDateThisWeek.ToString("dd-MMM-yyyy");
                    dateRange[1] = endDateThisWeek.ToString("dd-MMM-yyyy");
                    break;
                case "This Week-to-date":
                    dateRange[0] = fromDate.ToString("dd-MMM-yyyy");
                    dateRange[1] = toDate.ToString("dd-MMM-yyyy");
                    break;
                case "This Month":
                    DateTime firstDayThisMonth = new DateTime(fromDate.Year, fromDate.Month, 1);
                    DateTime lastDayThisMonth = firstDayThisMonth.AddMonths(1).AddDays(-1);
                    dateRange[0] = firstDayThisMonth.ToString("dd-MMM-yyyy");
                    dateRange[1] = lastDayThisMonth.ToString("dd-MMM-yyyy");
                    break;
                case "This Quarter":
                    DateTime firstDayThisQuarter = new DateTime(fromDate.Year, (3 * ((fromDate.Month - 1) / 3)) + 1, 1);
                    DateTime lastDayThisQuarter = firstDayThisQuarter.AddMonths(3).AddDays(-1);
                    dateRange[0] = firstDayThisQuarter.ToString("dd-MMM-yyyy");
                    dateRange[1] = lastDayThisQuarter.ToString("dd-MMM-yyyy");
                    break;
                case "This Year":
                    DateTime firstDayThisYear = new DateTime(fromDate.Year, 1, 1);
                    DateTime lastDayThisYear = new DateTime(fromDate.Year, 12, 31);
                    dateRange[0] = firstDayThisYear.ToString("dd-MMM-yyyy");
                    dateRange[1] = lastDayThisYear.ToString("dd-MMM-yyyy");
                    break;
                case "Last Week":
                    int daysToStartOfLastWeek = 7 + (int)fromDate.DayOfWeek - 1;
                    int daysToEndOfLastWeek = 7 - (int)fromDate.DayOfWeek;
                    DateTime startDateLastWeek = fromDate.AddDays(-daysToStartOfLastWeek);
                    DateTime endDateLastWeek = toDate.AddDays(-daysToEndOfLastWeek);
                    dateRange[0] = startDateLastWeek.ToString("dd-MMM-yyyy");
                    dateRange[1] = endDateLastWeek.ToString("dd-MMM-yyyy");
                    break;
                case "Last Month":
                    DateTime firstDayLastMonth = new DateTime(fromDate.AddMonths(-1).Year, fromDate.AddMonths(-1).Month, 1);
                    DateTime lastDayLastMonth = firstDayLastMonth.AddMonths(1).AddDays(-1);
                    dateRange[0] = firstDayLastMonth.ToString("dd-MMM-yyyy");
                    dateRange[1] = lastDayLastMonth.ToString("dd-MMM-yyyy");
                    break;
                case "Last Quarter":
                    DateTime firstDayLastQuarter = new DateTime(fromDate.AddMonths(-3).Year, (3 * ((fromDate.AddMonths(-3).Month - 1) / 3)) + 1, 1);
                    DateTime lastDayLastQuarter = firstDayLastQuarter.AddMonths(3).AddDays(-1);
                    dateRange[0] = firstDayLastQuarter.ToString("dd-MMM-yyyy");
                    dateRange[1] = lastDayLastQuarter.ToString("dd-MMM-yyyy");
                    break;
                case "Last Year":
                    DateTime firstDayLastYear = new DateTime(fromDate.AddYears(-1).Year, 1, 1);
                    DateTime lastDayLastYear = new DateTime(fromDate.AddYears(-1).Year, 12, 31);
                    dateRange[0] = firstDayLastYear.ToString("dd-MMM-yyyy");
                    dateRange[1] = lastDayLastYear.ToString("dd-MMM-yyyy");
                    break;
                case "Next Week":
                    int daysToStartOfNextWeek = 7 - (int)fromDate.DayOfWeek + 1;
                    int daysToEndOfNextWeek = 7 - (int)fromDate.DayOfWeek + 7;
                    DateTime startDateNextWeek = fromDate.AddDays(daysToStartOfNextWeek);
                    DateTime endDateNextWeek = toDate.AddDays(daysToEndOfNextWeek);
                    dateRange[0] = startDateNextWeek.ToString("dd-MMM-yyyy");
                    dateRange[1] = endDateNextWeek.ToString("dd-MMM-yyyy");
                    break;
                case "Next Month":
                    DateTime firstDayNextMonth = new DateTime(fromDate.AddMonths(1).Year, fromDate.AddMonths(1).Month, 1);
                    DateTime lastDayNextMonth = firstDayNextMonth.AddMonths(1).AddDays(-1);
                    dateRange[0] = firstDayNextMonth.ToString("dd-MMM-yyyy");
                    dateRange[1] = lastDayNextMonth.ToString("dd-MMM-yyyy");
                    break;
                case "Next Quarter":
                    DateTime firstDayNextQuarter = new DateTime(fromDate.AddMonths(3).Year, (3 * ((fromDate.AddMonths(3).Month - 1) / 3)) + 1, 1);
                    DateTime lastDayNextQuarter = firstDayNextQuarter.AddMonths(3).AddDays(-1);
                    dateRange[0] = firstDayNextQuarter.ToString("dd-MMM-yyyy");
                    dateRange[1] = lastDayNextQuarter.ToString("dd-MMM-yyyy");
                    break;
                case "Next Year":
                    DateTime firstDayNextYear = new DateTime(fromDate.AddYears(1).Year, 1, 1);
                    DateTime lastDayNextYear = new DateTime(fromDate.AddYears(1).Year, 12, 31);
                    dateRange[0] = firstDayNextYear.ToString("dd-MMM-yyyy");
                    dateRange[1] = lastDayNextYear.ToString("dd-MMM-yyyy");
                    break;
                case "All":
                    DateTime startDateAll = DateTime.MinValue;
                    DateTime endDateAll = DateTime.MaxValue;
                    dateRange[0] = startDateAll.ToString("dd-MMM-yyyy");
                    dateRange[1] = endDateAll.ToString("dd-MMM-yyyy");
                    break;
                case "Custom":
                    // Assuming you have customStartDate and customEndDate defined elsewhere
                    DateTime startDateCustom = fromDate;
                    DateTime endDateCustom = toDate;

                    dateRange[0] = startDateCustom.ToString("dd-MMM-yyyy");
                    dateRange[1] = endDateCustom.ToString("dd-MMM-yyyy");
                    break;
                default:
                    dateRange[0] = DateTime.Now.Date.ToString("dd-MMM-yyyy");
                    dateRange[1] = DateTime.Now.Date.ToString("dd-MMM-yyyy");
                    break;
            }

            return dateRange;
        }



        [AllowAnonymous]
        [HttpGet]
        public IActionResult GetInvoiceList(string status, string duration, int customerId, string startDate = "", string endDate = "", int page = 1, decimal size = 10, string searchquery = "")
        {
            try
            {

                var FromDate = DateTime.Now.Date;
                var ToDate = DateTime.Now.Date;

                if (duration != "Custom")
                {
                    if (startDate == "" || endDate == "")
                    {
                        FromDate = DateTime.Now.Date;
                        ToDate = DateTime.Now.Date;

                    }
                }
                else
                {
                    if (duration == "Custom")
                    {
                        FromDate = DateTime.Parse(startDate);
                        ToDate = DateTime.Parse(endDate);

                    }
                }



                var ComId = HttpContext.Session.GetInt32("ComId");
                var salesId = 0;
                var currentDate = DateTime.Now;

                SqlParameter[] sqlParameter1 = new SqlParameter[3];
                sqlParameter1[0] = new SqlParameter("@ComId", ComId);
                sqlParameter1[1] = new SqlParameter("@SalesId", salesId);
                sqlParameter1[2] = new SqlParameter("@CustomerId", customerId);
                Helper.ExecProc("[SalesStatusUpdate]", sqlParameter1);

                // Approval
                SqlParameter[] sqlParameter2 = new SqlParameter[2];
                sqlParameter2[0] = new SqlParameter("@ComId", ComId);
                sqlParameter2[1] = new SqlParameter("@SalesId", salesId);               
                Helper.ExecProc("[SalesApprovalStatus]", sqlParameter2);

                var salelist = saleRepository.All();

                if (searchquery?.Length > 1)
                {
                    salelist = salelist.Where(x =>
                    x.DocTypeList.DocType.ToLower().Contains(searchquery.ToLower()) ||
                    x.SaleCode.ToLower().Contains(searchquery.ToLower()) ||
                    x.CustomerName.ToLower().Contains(searchquery.ToLower()) ||
                    x.Total.ToString().ToLower().Contains(searchquery.ToLower()));

                }

                if (status != "0" && status != null)
                {

                    if (status == "9999")
                    {
                        var invoiceDocTypeId = _docTypeRepository.All()
                            .FirstOrDefault(x => x.DocType == "Invoice")?.Id;

                        var dueSalesList = saleRepository.All()
                            .Where(x => x.NetAmount - x.SalesPayments.Sum(sp => sp.Amount) > 0)
                            .Select(x => x.Id)
                            .Distinct()
                            .ToList();

                        //var uniqueSalesIds = salesPaymentRepository.All()
                        //    .Where(x => x.ComId == ComId && dueSalesList.Contains(x.SalesId))
                        //    .Select(x => x.SalesId)
                        //    .Distinct()
                        //    .ToList();

                        salelist = salelist
                            .Where(s => s.ComId == ComId && dueSalesList.Contains(s.Id)
                                     && s.DocTypeId == invoiceDocTypeId && s.DueDate < currentDate);
                    }
                    else if (status == "8888")
                    {
                        var invoiceDocTypeId = _docTypeRepository.All()
                            .Where(x => x.DocType != "Estimate").Select(x => x.Id).Distinct()
                            .ToList();

                        var salesPayment = salesPaymentRepository.All().Where(x => x.ComId == ComId).Include(x => x.Transaction)
                            .Where(x => x.Transaction.InputDate.Month == currentDate.Month).Select(x => x.SalesId).ToList();


                        //Note: If TransactionId is null then SalesDate is used for load recently paid data. 

                        salelist = salelist
                            .Where(s => s.ComId == ComId
                            && salesPayment.Contains(s.Id)
                            && invoiceDocTypeId.Contains(s.DocTypeId.GetValueOrDefault())
                            );

                        var QuerTest = salelist.ToQueryString();
                    }
                    else
                    {
                        salelist = salelist.Where(x => x.DocTypeId == int.Parse(status));
                    }

                }
                if (!string.IsNullOrEmpty(duration))
                {
                    // DateTime startDate, endDate;
                    string[] dateinfo = GetDateRange(duration, FromDate, ToDate);
                    FromDate = DateTime.Parse(dateinfo[0]);
                    ToDate = DateTime.Parse(dateinfo[1]);

                    salelist = salelist.Where(x => x.SalesDate >= FromDate && x.SalesDate <= ToDate);
                }
                //if (!string.IsNullOrEmpty(duration))
                //{
                //    DateTime startDate, endDate;

                //    if (duration == "Today")
                //    {
                //        startDate = DateTime.Today;
                //        endDate = DateTime.Today.AddDays(1);
                //    }
                //    else if (duration == "This month")
                //    {
                //        startDate = new DateTime(DateTime.Today.Year, DateTime.Today.Month, 1);
                //        endDate = startDate.AddMonths(1);
                //    }
                //    else if (duration == "Last month")
                //    {
                //        startDate = new DateTime(DateTime.Today.Year, DateTime.Today.Month, 1).AddMonths(-1);
                //        endDate = new DateTime(DateTime.Today.Year, DateTime.Today.Month, 1);
                //    }
                //    else if (duration == "Last year")
                //    {
                //        startDate = new DateTime(DateTime.Today.Year - 1, 1, 1);
                //        endDate = new DateTime(DateTime.Today.Year, 1, 1);
                //    }
                //    else if (duration == "This year")
                //    {
                //        startDate = new DateTime(DateTime.Today.Year, 1, 1);
                //        endDate = new DateTime(DateTime.Today.Year + 1, 1, 1);
                //    }
                //    else if (duration == "All")
                //    {
                //        startDate = DateTime.MinValue;
                //        endDate = DateTime.MaxValue;
                //    }
                //    else
                //    {
                //        // Handle other duration options if needed
                //        startDate = endDate = DateTime.MinValue;
                //    }

                //    salelist = salelist.Where(x => x.SalesDate >= startDate && x.SalesDate < endDate);
                //}

                if (customerId > 0)
                {
                    salelist = salelist.Where(x => x.CustomerId == customerId);
                }

                var data = salelist.Where(x => x.IsRecurring == false).Include(x => x.DocTypeList).Include(x => x.Items).OrderByDescending(x => x.Id);

                salelist = salelist.Where(x => x.IsRecurring == false && x.IsPending == false);

                decimal TotalRecordCount = salelist.Count();
                var PageCountabc = decimal.Parse((TotalRecordCount / size).ToString());
                var PageCount = Math.Ceiling(PageCountabc);

                decimal skip = (page - 1) * size;


                var query = from e in salelist.Include(x => x.Items)
                            .ThenInclude(x => x.Product).ThenInclude(x => x.Category)
                            .Include(x => x.SalesPayments).ThenInclude(x => x.vChartofAccounts)
                            .Include(x => x.SalesPayments).ThenInclude(x => x.Transaction)
                            .Include(x => x.SalesReturn).ThenInclude(x => x.SalesReturnPayments)
                            .Include(x => x.DocTypeList)


                            select new
                            {
                                Id = e.Id,
                                SaleCode = e.SaleCode,
                                SalesDate = e.SalesDate,
                                DueDate = e.DueDate,
                                SalesDateString = e.SalesDate.ToString("dd-MMM-yy"),

                                SalesUser = e.UserAccountList.Name,

                                CustomerName = (e.CustomerName.Length == 0 || e.CustomerName == null) ? e.CustomerModel.Name : e.CustomerName,
                                //CustomerName = e.CustomerName,
                                PrimaryAddress = e.PrimaryAddress,
                                SecoundaryAddress = e.SecoundaryAddress,
                                Notes = e.Notes,
                                PhoneNo = e.PhoneNo,
                                Discount = e.Discount,
                                e.IsDelete,
                                CustomerCommissionAmount = e.CustomerCommissionAmount,
                                SRCommissionAmount = e.SRCommissionAmount,



                                Total = e.Total,
                                StatusRemarks = e.StatusRemarks,
                                ApprovalStage1 = e.ApprovalStage,
                                NetAmount = e.NetAmount,
                                DueAmount = e.NetAmount - e.SalesPayments.Sum(x => x.Amount),
                                PaidAmount = e.SalesPayments.Sum(x => x.Amount),
                                ServiceCharge = e.ServiceCharge,
                                TotalVat = e.TotalVat,
                                Shipping = e.Shipping,
                                DocType = e.DocTypeList.DocType,
                                //TransactionCode = e.AccountTransaction.,



                                isPOSSales = e.isPOSSales,
                                isSerialSales = e.isSerialSales,
                                isPosted = e.isPosted,
                                FinalCostingPrice = e.FinalCostingPrice,
                                Profit = e.Profit,
                                ProfitPercentage = e.ProfitPercentage,
                                Location = e.Warehouses.WhShortName,
                                StatusPosted = e.isPosted != false ? "Posted" : "Not Posted",
                                PaidAmt = e.SalesPayments.Sum(x => x.Amount),// e.PaidAmt,
                                                                             //ReceivingHead = e.CreditAccount != null ? e.CreditAccount.AccName : "=N/A="
                                                                             //SalesPayments = e.SalesPayments.ToList(),
                                SalesReturnPayments = e.SalesReturn.FirstOrDefault().SalesReturnPayments.Sum(x => x.Amount),
                                SalesReturnAmount = e.SalesReturn.Sum(x => x.NetAmount),
                                SalesPayments = e.SalesPayments.Select(x => new
                                {
                                    x.SalesId,
                                    x.PaymentCardNo,
                                    x.isPosted,
                                    x.Amount,
                                    x.RowNo,
                                    x.AccountHeadId,
                                    AccType = x.vChartofAccounts.AccType,
                                    AccName = x.vChartofAccounts.AccName,
                                    TransactionCode = x.Transaction.TransactionCode
                                }),
                                SalesItems = e.Items.Select(x => new
                                {
                                    x.Id,
                                    CategoryName = x.Product.Category.Name,
                                    ProductCode = x.Product.Code,
                                    ProductName = x.Product.Name,

                                    BatchSerial = x.BatchSerialItems.Select(x => new
                                    {
                                        BatchSerialNo = x.PurchaseBatchItems.BatchSerialNo
                                    }),

                                    Price = Math.Round(x.Price, 4),
                                    CostPrice = Math.Round(x.CostPrice, 4),
                                    AvgCostPrice = Math.Round(x.AvgCostPrice, 4),
                                    IndDiscountProportion = Math.Round(x.IndDiscountProportion, 4),
                                    Quantity = x.Quantity,
                                    //ProfitPer = x.profit,
                                    CommissionAmount = x.CommissionAmount

                                })
                                //Items = e.Items
                            };



                var abcd = query.OrderByDescending(x => x.Id).Skip(int.Parse(skip.ToString())).Take(int.Parse(size.ToString())).ToList();
                var pageinfo = new PagingInfo();
                pageinfo.PageCount = int.Parse(PageCount.ToString());
                pageinfo.PageNo = page;
                pageinfo.PageSize = int.Parse(size.ToString());
                pageinfo.TotalRecordCount = int.Parse(TotalRecordCount.ToString());

                return Json(new { Success = 1, error = false, data = abcd, page = page, size = size, last_page = pageinfo.PageCount, total = pageinfo.TotalRecordCount });

                //return Json(new { Success = 1, data = data, ex = "Data " });
            }
            catch (Exception ex)
            {
                return Json(new { Success = 0, ex = ex.InnerException?.InnerException?.Message ?? ex.Message });
            }
        }

        [AllowAnonymous]
        [HttpGet]
        public IActionResult GetPendingTransactionList(int page = 1, decimal size = 10, string searchquery = "")
        {
            try
            {

                var FromDate = DateTime.Now.Date;
                var ToDate = DateTime.Now.Date;

                var ComId = HttpContext.Session.GetInt32("ComId");
                var salesId = 0;
                var currentDate = DateTime.Now;

                var salelist = saleRepository.All();

                if (searchquery?.Length > 1)
                {
                    salelist = salelist.Where(x =>
                    x.DocTypeList.DocType.ToLower().Contains(searchquery.ToLower()) ||
                    x.SaleCode.ToLower().Contains(searchquery.ToLower()) ||
                    x.CustomerName.ToLower().Contains(searchquery.ToLower()) ||
                    x.SalesDate == DateTime.Parse(searchquery) ||
                    x.Total.ToString().ToLower().Contains(searchquery.ToLower()));

                }


                var data = salelist.Where(x => x.IsRecurring == false).Include(x => x.DocTypeList).Include(x => x.Items).OrderByDescending(x => x.Id);

                salelist = salelist.Where(x => x.IsRecurring == false && x.IsPending == true);

                decimal TotalRecordCount = salelist.Count();
                var PageCountabc = decimal.Parse((TotalRecordCount / size).ToString());
                var PageCount = Math.Ceiling(PageCountabc);

                decimal skip = (page - 1) * size;


                var query = from e in salelist.Include(x => x.Items)
                            .ThenInclude(x => x.Product).ThenInclude(x => x.Category)
                            .Include(x => x.SalesPayments).ThenInclude(x => x.vChartofAccounts)
                            .Include(x => x.SalesPayments).ThenInclude(x => x.Transaction)
                            .Include(x => x.SalesReturn).ThenInclude(x => x.SalesReturnPayments)
                            .Include(x => x.DocTypeList)


                            select new
                            {
                                Id = e.Id,
                                SaleCode = e.SaleCode,
                                SalesDate = e.SalesDate,
                                DueDate = e.DueDate,
                                SalesDateString = e.SalesDate.ToString("dd-MMM-yy"),

                                SalesUser = e.UserAccountList.Name,

                                CustomerName = (e.CustomerName.Length == 0 || e.CustomerName == null) ? e.CustomerModel.Name : e.CustomerName,
                                //CustomerName = e.CustomerName,
                                PrimaryAddress = e.PrimaryAddress,
                                SecoundaryAddress = e.SecoundaryAddress,
                                Notes = e.Notes,
                                PhoneNo = e.PhoneNo,
                                Discount = e.Discount,
                                e.IsDelete,
                                CustomerCommissionAmount = e.CustomerCommissionAmount,
                                SRCommissionAmount = e.SRCommissionAmount,



                                Total = e.Total,
                                StatusRemarks = e.StatusRemarks,
                                NetAmount = e.NetAmount,
                                DueAmount = e.NetAmount - e.SalesPayments.Sum(x => x.Amount),
                                PaidAmount = e.SalesPayments.Sum(x => x.Amount),
                                ServiceCharge = e.ServiceCharge,
                                TotalVat = e.TotalVat,
                                Shipping = e.Shipping,
                                DocType = e.DocTypeList.DocType,
                                //TransactionCode = e.AccountTransaction.,



                                isPOSSales = e.isPOSSales,
                                isSerialSales = e.isSerialSales,
                                isPosted = e.isPosted,
                                FinalCostingPrice = e.FinalCostingPrice,
                                Profit = e.Profit,
                                ProfitPercentage = e.ProfitPercentage,
                                Location = e.Warehouses.WhShortName,
                                StatusPosted = e.isPosted != false ? "Posted" : "Not Posted",
                                PaidAmt = e.SalesPayments.Sum(x => x.Amount),// e.PaidAmt,
                                                                             //ReceivingHead = e.CreditAccount != null ? e.CreditAccount.AccName : "=N/A="
                                                                             //SalesPayments = e.SalesPayments.ToList(),
                                SalesReturnPayments = e.SalesReturn.FirstOrDefault().SalesReturnPayments.Sum(x => x.Amount),
                                SalesReturnAmount = e.SalesReturn.Sum(x => x.NetAmount),

                            };



                var abcd = query.OrderByDescending(x => x.Id).Skip(int.Parse(skip.ToString())).Take(int.Parse(size.ToString())).ToList();
                var pageinfo = new PagingInfo();
                pageinfo.PageCount = int.Parse(PageCount.ToString());
                pageinfo.PageNo = page;
                pageinfo.PageSize = int.Parse(size.ToString());
                pageinfo.TotalRecordCount = int.Parse(TotalRecordCount.ToString());

                return Json(new { Success = 1, error = false, data = abcd, page = page, size = size, last_page = pageinfo.PageCount, total = pageinfo.TotalRecordCount });

                //return Json(new { Success = 1, data = data, ex = "Data " });
            }
            catch (Exception ex)
            {
                return Json(new { Success = 0, ex = ex.InnerException?.InnerException?.Message ?? ex.Message });
            }
        }

        [AllowAnonymous]
        [HttpGet]
        public IActionResult changeStatus(int Id)
        {
            try
            {
                var ComId = HttpContext.Session.GetInt32("ComId");

                var model = saleRepository.All().Where(x => x.Id == Id).FirstOrDefault();
                model.IsPending = false;

                saleRepository.Update(model, Id);
                return Json(new { Success = 1, ex = "Data " });
            }
            catch (Exception ex)
            {
                return Json(new { Success = 0, ex = ex.InnerException?.InnerException?.Message ?? ex.Message });
            }
        }

        [AllowAnonymous]
        [HttpPost]
        public IActionResult RecurringDetailsCreation([FromBody] RecurringDetailsModelVM model)
        {
            try
            {
                if (model.Id == 0)
                {
                    var model1 = new RecurringDetailsModel();
                    model1.Id = model.Id;
                    model1.TemplateName = model.TemplateName;
                    model1.TemplateType = model.TemplateType;
                    model1.CreateDays = model.CreateDays;
                    model1.Interval = model.Interval;
                    model1.Every_ = model.Every_;
                    model1.Week_ = model.Week_;
                    model1.Month_ = model.Month_;
                    model1.Integer_ = model.Integer_;
                    model1.Count_ = model.Count_;
                    model1.PurchaseId = model.PurchaseId;
                    model1.TransactionId = model.TransactionId;
                    if (model.RecurringStartDate != "")
                    {
                        model1.RecurringStartDate = DateTime.Parse(model.RecurringStartDate);
                        if (model.Interval == "Daily")
                        {
                            model1.NextDate = model1.RecurringStartDate.AddDays(model1.Every_);
                        }
                        if (model.Interval == "Weekly")
                        {
                            DateTime nextDate = (DateTime)FindNextDate(model1.RecurringStartDate, model1.Every_, model1.Week_);
                            model1.NextDate = nextDate;
                        }

                        if (model.Interval == "Yearly")
                        {
                            int dayOfMonth = GetNumericDay(model.Integer_);
                            DateTime nextDate = GetNextTransactionDate(model1.RecurringStartDate, dayOfMonth, model.Month_, 1);

                            model1.NextDate = nextDate;
                        }

                        if (model.Interval == "Monthly")
                        {
                            if (model1.Count_ == "day")
                            {
                                int dayOfMonth = GetNumericDay(model.Integer_);
                                DateTime nextDate = GetNextTxnDateForMonth(model1.RecurringStartDate, dayOfMonth, model1.Every_);
                                model1.NextDate = nextDate;
                            }
                            else
                            {
                                DateTime nextDate = CalculateNextTransactionDate(model1.RecurringStartDate, model1.Every_, model1.Week_, model1.Count_);
                                model1.NextDate = nextDate;
                            }

                        }

                    }
                    if (model.RecurringEndDate != "")
                    {
                        model1.RecurringEndDate = DateTime.Parse(model.RecurringEndDate);
                    }
                    model1.End_ = model.End_;
                    model1.occurences = model.occurences;
                    model1.SalesId = model.SalesId;

                    recurringDetailsRepository.Insert(model1);
                    return Json(new { error = false });
                }
                else
                {
                    var model1 = recurringDetailsRepository.All().Where(x => x.Id == model.Id).FirstOrDefault();
                    model1.TemplateName = model.TemplateName;
                    model1.TemplateType = model.TemplateType;
                    model1.CreateDays = model.CreateDays;
                    model1.Interval = model.Interval;
                    model1.Every_ = model.Every_;
                    model1.Week_ = model.Week_;
                    model1.Month_ = model.Month_;
                    model1.Integer_ = model.Integer_;
                    model1.Count_ = model.Count_;
                    if (model.RecurringStartDate != "")
                    {
                        model1.RecurringStartDate = DateTime.Parse(model.RecurringStartDate);
                        if (model.Interval == "Daily")
                        {
                            model1.NextDate = model1.RecurringStartDate.AddDays(model1.Every_);
                        }
                        if (model.Interval == "Weekly")
                        {
                            DateTime nextDate = (DateTime)FindNextDate(model1.RecurringStartDate, model1.Every_, model1.Week_);
                            model1.NextDate = nextDate;
                        }

                        if (model.Interval == "Yearly")
                        {
                            int dayOfMonth = GetNumericDay(model.Integer_);
                            DateTime nextDate = GetNextTransactionDate(model1.RecurringStartDate, dayOfMonth, model.Month_, 1);

                            model1.NextDate = nextDate;
                        }
                        if (model.Interval == "Monthly")
                        {
                            if (model1.Count_ == "day")
                            {
                                int dayOfMonth = GetNumericDay(model.Integer_);
                                DateTime nextDate = GetNextTxnDateForMonth(model1.RecurringStartDate, dayOfMonth, model1.Every_);
                                model1.NextDate = nextDate;
                            }
                            else
                            {
                                DateTime nextDate = CalculateNextTransactionDate(model1.RecurringStartDate, model1.Every_, model1.Week_, model1.Count_);
                                model1.NextDate = nextDate;
                            }

                        }
                    }
                    if (model.RecurringEndDate != "")
                    {
                        model1.RecurringEndDate = DateTime.Parse(model.RecurringEndDate);
                    }
                    model1.End_ = model.End_;
                    model1.occurences = model.occurences;

                    recurringDetailsRepository.Update(model1, model1.Id);
                    return Json(new { error = false });
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        [AllowAnonymous]
        [HttpPost]
        public IActionResult AdvanceSalesCreation([FromBody] AdvanceTrasactionTrackingModelVM model)
        {
            try
            {
                var ComId = HttpContext.Session.GetInt32("ComId");
                if (model.Id == 0)
                {
                    var data = new AdvanceTrasactionTrackingModel();
                    data.Id = model.Id;
                    data.SalesId = model.SalesId;
                    data.PurchaseId = model.PurchaseId;
                    data.ExpenseHeadId = model.ExpenseHeadId;
                    data.ComId = ComId ?? 0;
                    data.Duration = model.Duration;
                    data.Occurence = model.Occurence;
                    data.OccuringDate = model.OccuringDate;
                    data.StartDate = model.StartDate;

                    advanceTransactionTrackingRepository.Insert(data);
                    return Json(new { error = false });
                }
                else
                {
                    var data = new AdvanceTrasactionTrackingModel();
                    data.Id = model.Id;
                    data.SalesId = model.SalesId;
                    data.PurchaseId = model.PurchaseId;
                    data.ExpenseHeadId = model.ExpenseHeadId;
                    data.ComId = ComId ?? 0;
                    data.Duration = model.Duration;
                    data.Occurence = model.Occurence;
                    data.OccuringDate = model.OccuringDate;
                    data.StartDate = model.StartDate;

                    advanceTransactionTrackingRepository.Update(data, data.Id);
                    return Json(new { error = false });
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        [AllowAnonymous]
        [HttpGet]
        public IActionResult ExecuteRecurrTransaction()
        {
            try
            {
                var ComId = HttpContext.Session.GetInt32("ComId");

                var data = recurringDetailsRepository.All().Where(x => x.ComId == ComId && x.SalesId != null).Include(x => x.SalesModel).ToList();

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
                                    item.NextDate = todayMidnight.AddDays(item.Every_);
                                    item.occurences--;
                                }
                                if (item.PreviousDate != DateTime.Today)
                                {
                                    if (item.PreviousDate?.AddDays(item.Every_) <= item.RecurringEndDate)
                                    {
                                        //item.NextDate = item.PreviousDate?.AddDays(item.Every_);
                                        item.NextDate = todayMidnight.AddDays(item.Every_);
                                    }

                                }
                                if (item.End_ == "None" && item.PreviousDate != DateTime.Today)
                                {
                                    if (item.PreviousDate == null)
                                    {
                                        item.NextDate = todayMidnight.AddDays(item.Every_);
                                    }
                                    else
                                    {
                                        item.NextDate = todayMidnight.AddDays(item.Every_);
                                    }
                                }
                                item.PreviousDate = DateTime.Today;
                                var salesData = saleRepository.All().Where(x => x.Id == item.SalesId).Include(x => x.Items).Include(x => x.SalesTags).Include(x => x.SalesProductTax).AsNoTracking().FirstOrDefault();
                                if (salesData != null)
                                {
                                    TimeSpan dueDateDiff = salesData.DueDate - salesData.SalesDate;
                                    if (dueDateDiff.TotalDays > 0)
                                    {
                                        salesData.DueDate = DateTime.Now.AddDays(dueDateDiff.TotalDays);
                                    }

                                    salesData.Id = 0;
                                    salesData.SaleCode = uniqueNumber;
                                    salesData.IsRecurring = false;
                                    salesData.SalesDate = DateTime.Now;
                                    salesData.ShippingDate = DateTime.Now;
                                    salesData.IsPending = true;
                                    foreach (var Childitem in salesData.Items)
                                    {
                                        Childitem.Id = 0;
                                        Childitem.SalesId = 0;
                                        Childitem.ServiceDate = DateTime.Now;
                                    }
                                    foreach (var tag in salesData.SalesTags)
                                    {
                                        tag.Id = 0;
                                        tag.SalesId = 0;
                                    }
                                    foreach (var tax in salesData.SalesProductTax)
                                    {
                                        tax.Id = 0;
                                        tax.SalesId = 0;
                                    }
                                }


                                saleRepository.Insert(salesData);
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

                                var salesData = saleRepository.All().Where(x => x.Id == item.SalesId).Include(x => x.Items).Include(x => x.SalesTags).Include(x => x.SalesProductTax).AsNoTracking().FirstOrDefault();
                                if (salesData != null)
                                {
                                    TimeSpan dueDateDiff = salesData.DueDate - salesData.SalesDate;
                                    if (dueDateDiff.TotalDays > 0)
                                    {
                                        salesData.DueDate = DateTime.Now.AddDays(dueDateDiff.TotalDays);
                                    }

                                    salesData.Id = 0;
                                    salesData.SaleCode = uniqueNumber;
                                    salesData.IsRecurring = false;
                                    salesData.SalesDate = DateTime.Now;
                                    salesData.ShippingDate = DateTime.Now;
                                    salesData.IsPending = true;
                                    foreach (var Childitem in salesData.Items)
                                    {
                                        Childitem.Id = 0;
                                        Childitem.SalesId = 0;
                                        Childitem.ServiceDate = DateTime.Now;
                                    }
                                    foreach (var tag in salesData.SalesTags)
                                    {
                                        tag.Id = 0;
                                        tag.SalesId = 0;
                                    }
                                    foreach (var tax in salesData.SalesProductTax)
                                    {
                                        tax.Id = 0;
                                        tax.SalesId = 0;
                                    }
                                }


                                saleRepository.Insert(salesData);
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

                                var salesData = saleRepository.All().Where(x => x.Id == item.SalesId).Include(x => x.Items).Include(x => x.SalesTags).Include(x => x.SalesProductTax).AsNoTracking().FirstOrDefault();
                                if (salesData != null)
                                {
                                    TimeSpan dueDateDiff = salesData.DueDate - salesData.SalesDate;
                                    if (dueDateDiff.TotalDays > 0)
                                    {
                                        salesData.DueDate = DateTime.Now.AddDays(dueDateDiff.TotalDays);
                                    }

                                    salesData.Id = 0;
                                    salesData.SaleCode = uniqueNumber;
                                    salesData.IsRecurring = false;
                                    salesData.SalesDate = DateTime.Now;
                                    salesData.ShippingDate = DateTime.Now;
                                    salesData.IsPending = true;
                                    foreach (var Childitem in salesData.Items)
                                    {
                                        Childitem.Id = 0;
                                        Childitem.SalesId = 0;
                                        Childitem.ServiceDate = DateTime.Now;
                                    }
                                    foreach (var tag in salesData.SalesTags)
                                    {
                                        tag.Id = 0;
                                        tag.SalesId = 0;
                                    }
                                    foreach (var tax in salesData.SalesProductTax)
                                    {
                                        tax.Id = 0;
                                        tax.SalesId = 0;
                                    }
                                }


                                saleRepository.Insert(salesData);
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

                                var salesData = saleRepository.All().Where(x => x.Id == item.SalesId).Include(x => x.Items).Include(x => x.SalesTags).Include(x => x.SalesProductTax).AsNoTracking().FirstOrDefault();
                                if (salesData != null)
                                {
                                    TimeSpan dueDateDiff = salesData.DueDate - salesData.SalesDate;
                                    if (dueDateDiff.TotalDays > 0)
                                    {
                                        salesData.DueDate = DateTime.Now.AddDays(dueDateDiff.TotalDays);
                                    }

                                    salesData.Id = 0;
                                    salesData.SaleCode = uniqueNumber;
                                    salesData.IsRecurring = false;
                                    salesData.SalesDate = DateTime.Now;
                                    salesData.ShippingDate = DateTime.Now;
                                    salesData.IsPending = true;
                                    foreach (var Childitem in salesData.Items)
                                    {
                                        Childitem.Id = 0;
                                        Childitem.SalesId = 0;
                                        Childitem.ServiceDate = DateTime.Now;
                                    }
                                    foreach (var tag in salesData.SalesTags)
                                    {
                                        tag.Id = 0;
                                        tag.SalesId = 0;
                                    }
                                    foreach (var tax in salesData.SalesProductTax)
                                    {
                                        tax.Id = 0;
                                        tax.SalesId = 0;
                                    }
                                }


                                saleRepository.Insert(salesData);
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
        [HttpGet]
        public IActionResult GetInvoiceListOverview(string type)
        {
            var ComId = HttpContext.Session.GetInt32("ComId");

            var data = saleRepository.All().Include(x => x.DocTypeList).Where(x => x.ComId == ComId);
            if (type == "Estimate")
            {
                var doctypeid = _docTypeRepository.All().FirstOrDefault(x => x.DocType == "Estimate")?.Id;

                if (doctypeid.HasValue)
                {
                    data = data.Where(x => x.DocTypeId == doctypeid);
                }

            }
            if (type == "Unbilled")
            {
                var doctypeid = _docTypeRepository.All().FirstOrDefault(x => x.DocType == "Sales receipt")?.Id;

                if (doctypeid.HasValue)
                {
                    data = data.Where(x => x.DocTypeId == doctypeid);
                }
            }
            if (type == "Overdue")
            {
                var currentDate = DateTime.Now;

                var doctypeid = _docTypeRepository.All().FirstOrDefault(x => x.DocType == "Invoice")?.Id;

                var uniSalesId = salesPaymentRepository.All().Where(x => x.ComId == ComId).Select(x => x.SalesId).Distinct().ToList();

                var salesNotInSalesPayment = saleRepository.All().Where(s => s.ComId == ComId && !uniSalesId.Contains(s.Id)
                                             && s.DocTypeId == doctypeid && s.DueDate < currentDate);

                data = salesNotInSalesPayment;
            }
            if (type == "Invoices")
            {
                var doctypeid = _docTypeRepository.All().FirstOrDefault(x => x.DocType == "Invoice")?.Id;

                if (doctypeid.HasValue)
                {
                    data = data.Where(x => x.DocTypeId == doctypeid);
                }
            }
            if (type == "RecentlyPaid")
            {
                var currentDate = DateTime.Now;

                var salesList = new List<SalesModel>();

                var salesPayment = salesPaymentRepository.All().Where(x => x.ComId == ComId).Include(x => x.Transaction).Where(x => x.Transaction.InputDate.Month == currentDate.Month).ToList();

                foreach (var item in salesPayment)
                {
                    var salesdata = saleRepository.All().Where(x => x.Id == item.SalesId).FirstOrDefault();
                    salesList.Add(salesdata);
                }


            }

            return Json(new { Success = 1, data = data.ToList(), ex = "Data " });
        }

        [AllowAnonymous]
        [HttpGet]
        public IActionResult GetOverviewData()
        {
            try
            {
                var ComId = HttpContext.Session.GetInt32("ComId");

                SqlParameter[] sqlParameter1 = new SqlParameter[1];
                sqlParameter1[0] = new SqlParameter("@Comid", ComId);

                var datasetabc = new System.Data.DataSet();
                datasetabc = Helper.ExecProcMapDS("Acc_prcTransactionOverview", sqlParameter1);

                var dataTable = datasetabc.Tables[0];

                decimal[] datas = new decimal[5];
                foreach (DataRow row in dataTable.Rows)
                {
                    datas[0] = row.Field<decimal>("EstimateAmount");
                    datas[1] = row.Field<decimal>("UnbilledAmount");
                    datas[2] = row.Field<decimal>("OverdueAmount");
                    datas[3] = row.Field<decimal>("InvoiceCreditsAmount");
                    datas[4] = row.Field<decimal>("recentlyPaid");
                    break;
                }

                List<double> percentageRatios = CalculatePercentageRatios(datas);
                return Json(new { Success = 1, data = dataTable, ratio = percentageRatios, ex = "Data " });
            }
            catch (Exception ex)
            {
                return Json(new { Success = 0, ex = ex.InnerException?.InnerException?.Message ?? ex.Message });
            }
        }


        static List<double> CalculatePercentageRatios(decimal[] values)
        {
            List<double> ratios = new List<double>();

            decimal sum = 0;

            for (int i = 0; i < values.Length; i++)
            {
                sum += values[i];
            }

            for (int i = 0; i < values.Length; i++)
            {
                if (sum == 0)
                {
                    sum = 1;
                }
                var temp = Math.Round((double)(values[i] / sum * 100), 1);


                ratios.Add(temp);
            }

            return ratios;
        }


        [OverridableAuthorize]
        [HttpGet]
        public IActionResult EditInvoice(int id, string type)
        {
            try
            {

                var errors = ModelState.Where(x => x.Value.Errors.Any())
              .Select(x => new { x.Key, x.Value.Errors });

                var ComId = HttpContext.Session.GetInt32("ComId");

                ViewBag.Customers = customerRepository.All().Where(p => p.ComId == ComId).Include(x => x.Currency)
                           .Select(x => new SelectListItem
                           {
                               Text = x.Name + '-' + x.Currency.CurrencyShortName,
                               Value = x.Id.ToString()
                           });
                ViewBag.WarehouseIdMain = _warehouseRepository.All().Where(x => x.ComId == ComId)
                               .Select(x => new SelectListItem
                               {
                                   Text = x.WhName,
                                   Value = x.Id.ToString()
                               });
                var taxes = _mastersalestaxRepository.All().Where(f => f.ComId == ComId).ToList();
                SelectList taxList = new SelectList(taxes, "Id", "Name");
                ViewData["TaxList"] = taxList;

                if (type == null)
                {
                    type = "Invoice";
                }
                if (type == "Credit Note")
                {
                    type = "Credit-note";
                }
                if (type == "Sales receipt")
                {
                    type = "Sales_Receipt";
                }
                if (type == "Delayed Charge")
                {
                    type = "Delayed_Charge";
                }

                ViewBag.TransactionType = type;
                ViewBag.ActionType = "Edit";
                ViewBag.Id = id;
                var products = productRepository.All().Where(p => p.ComId == ComId).ToList();

                SelectList productslist = new SelectList(products, "Id", "Name");
                ViewData["ProductList"] = productslist;

                var agency = _agencyRepository.All();
                var data = agency.ToList();
                SelectList agencyList = new SelectList(data, "Id", "AgencyName");

                ViewData["AgencyList"] = agencyList;
                var data1 = saleRepository.All().Where(x => x.Id == id).FirstOrDefault();

                var estimateStatus = new List<SelectListItem>
     {
         new SelectListItem { Text = "Pending", Value = "Pending" },
         new SelectListItem { Text = "Accepted", Value = "Accepted" },
         new SelectListItem { Text = "Closed", Value = "Closed" },
         new SelectListItem { Text = "Rejected", Value = "Rejected" }
     };

                var estimateStatusList = new SelectList(estimateStatus, "Value", "Text");
                ViewData["EstimateStatus"] = estimateStatusList;

                var taxCalculation = new List<SelectListItem>
     {
         new SelectListItem { Text = "Exclusive of Tax", Value = "exclusive" },
         new SelectListItem { Text = "Inclusive of Tax", Value = "inclusive" },
         new SelectListItem { Text = "Out of scope of Tax", Value = "outscope" }
     };

                var taxCalculationList = new SelectList(taxCalculation, "Value", "Text");

                ViewData["AmountsAre"] = taxCalculationList;
                ViewData["CategoryList"] = accountHeadRepository.GetCashBankHeadForDropDown();

                return View("AddInvoiceQB");

            }
            catch (Exception ex)
            {

                throw ex;
            }

        }

        [AllowAnonymous]
        public JsonResult GetUnitConversion(int primaryUnitId, int productId)
        {
            var ComId = HttpContext.Session.GetInt32("ComId");

            SqlParameter[] sqlParameter1 = new SqlParameter[3];

            sqlParameter1[0] = new SqlParameter("@ComId", ComId);
            sqlParameter1[1] = new SqlParameter("@primaryUnitId", primaryUnitId);
            sqlParameter1[2] = new SqlParameter("@productId", productId);

            var datasetabc = new System.Data.DataSet();
            datasetabc = Helper.ExecProcMapDS("get_unitFromConversion", sqlParameter1);

            var dataTable = datasetabc.Tables[0];
            return Json(dataTable);
        }

        [HttpGet]
        [AllowAnonymous]
        public IActionResult GetInvoiceDetails(int id)
        {

            var data = saleRepository.All().Where(x => x.Id == id).FirstOrDefault();
            var item = saleItemRepository.All().Where(x => x.SalesId == id).ToList();
            var productTax = salesProductTaxRepository.All().Where(x => x.SalesId == id).ToList();
            var salesTag = salesTagRepository.All().Where(x => x.SalesId == id).ToList();
            data.Items = item;
            data.SalesProductTax = productTax;
            data.SalesTags = salesTag;
            return Json(new { Success = 1, data = data, ex = "Data Loaded Successfully" });
        }

        [HttpGet]
        [AllowAnonymous]
        public IActionResult GetInvoiceDetails2Copy(int id)
        {
            var salesData = saleRepository.All().Where(x => x.Id == id).Include(x => x.Items).Include(x => x.SalesTags).Include(x => x.SalesProductTax).AsNoTracking().FirstOrDefault();
            if (salesData != null)
            {
                TimeSpan dueDateDiff = salesData.DueDate - salesData.SalesDate;
                if (dueDateDiff.TotalDays > 0)
                {
                    salesData.DueDate = DateTime.Now.AddDays(dueDateDiff.TotalDays);
                }

                salesData.Id = 0;
                salesData.IsRecurring = false;
                salesData.SalesDate = DateTime.Now;
                salesData.ShippingDate = DateTime.Now;
                foreach (var Childitem in salesData.Items)
                {
                    Childitem.Id = 0;
                    Childitem.SalesId = 0;
                    Childitem.ServiceDate = DateTime.Now;
                }
                foreach (var tag in salesData.SalesTags)
                {
                    tag.Id = 0;
                    tag.SalesId = 0;
                }
                foreach (var tax in salesData.SalesProductTax)
                {
                    tax.Id = 0;
                    tax.SalesId = 0;
                }
            }

            return Json(new { Success = 1, data = salesData, ex = "Data Loaded Successfully" });
        }

        [HttpGet]
        [AllowAnonymous]
        public IActionResult GetRecurringDetails(int id)
        {

            var data = recurringDetailsRepository.All().Where(x => x.SalesId == id).FirstOrDefault();
            return Json(new { Success = 1, data = data, ex = "Data Loaded Successfully" });
        }
        [HttpGet]
        [AllowAnonymous]
        public IActionResult GetRecurringDetailsForTrxn(int id)
        {

            var data = recurringDetailsRepository.All().Where(x => x.TransactionId == id).FirstOrDefault();
            return Json(new { Success = 1, data = data, ex = "Data Loaded Successfully" });
        }

        [HttpGet]
        [AllowAnonymous]
        public IActionResult ProductPrice(int ProductId)
        {
            var productinfo = productRepository.All().Where(x => x.Id == ProductId).FirstOrDefault();
            var price = productinfo.Price;
            var costprice = productinfo.CostPrice;


            return Json(new { Success = 1, price = price, costprice = costprice, unitId = productinfo.UnitId, ex = "Data no found" });
        }

        public class NicknameInfo
        {
            public int OccurrenceCount { get; set; }
            public double Amount { get; set; }
            public double TotalAmount { get; set; }
            public int TaxId { get; set; }
            public bool IsSum { get; set; }
        }

        public class ProductTaxAmount
        {
            public string? Nickname { get; set; }
            public double Amount { get; set; }
            public double TotalAmount { get; set; }
            public int TaxId { get; set; }
            public bool IsSum { get; set; }
        }

        [HttpGet]
        [AllowAnonymous]
        public IActionResult ProductWiseTax(string taxes, string amounts, string criteria)
        {

            string[] taxParts = taxes.Split(','); 
            int[] taxIntArray = Array.ConvertAll(taxParts, int.Parse);

            string[] amountParts = amounts.Split(',');
            double[] amountIntArray = Array.ConvertAll(amountParts, double.Parse);

            var tdsAmount = 0.00;
            var vdsAmount = 0.00;
            var vatAmount = 0.00;
            var aitAmount = 0.00;

            Dictionary<string, NicknameInfo> distinctDataOccurrences = new Dictionary<string, NicknameInfo>();

            if (criteria == "inclusive")
            {
                for (int i = 0; i < taxIntArray.Length; i++)
                {
                    var data = _salestaxRepository.All().Where(x => x.SalesTaxMasterId == taxIntArray[i]).Include(x=>x.TaxCriteria).ToList();
                    var totalRate = _salestaxRepository.All().Where(x => x.SalesTaxMasterId == taxIntArray[i] && (x.TaxCriteria.Criteria == "VAT" || x.TaxCriteria.Criteria == null)).Select(x => x.Rate).Sum();

                    double amount = amountIntArray[i];

                    foreach (var dataItem in data)
                    {
                        string nickname = dataItem.Nickname + "(" + dataItem.Rate + "% )";

                        if (distinctDataOccurrences.ContainsKey(nickname))
                        {
                            distinctDataOccurrences[nickname].OccurrenceCount++;

                            //var tempAmount = amount / ((totalRate / 100) + 1);
                            //var onAmount = tempAmount;
                            //tempAmount = amount - tempAmount;
                            //tempAmount = (tempAmount * dataItem.Rate) / totalRate ?? 0;
                            var afterCalculation = amount - ((amount * totalRate) / (100 + totalRate)) ?? 0;
                            var tempAmount = (afterCalculation * dataItem.Rate / 100) ?? 0.00;
                            var onAmount = tempAmount;
                            var isSum = true;

                            if (dataItem.TaxCriteria.Criteria == "TDS")
                            {
                                tempAmount = (afterCalculation * dataItem.Rate / 100) ?? 0.00;

                                tdsAmount += tempAmount;
                                isSum = false;
                            }
                            else if (dataItem.TaxCriteria.Criteria == "VDS")
                            {
                                tempAmount = (afterCalculation * dataItem.Rate / 100) ?? 0.00;

                                vdsAmount += tempAmount;
                                isSum = false;
                            }
                            else if (dataItem.TaxCriteria.Criteria == "AIT")
                            {
                                tempAmount = (afterCalculation * dataItem.Rate / 100) ?? 0.00;

                                aitAmount += tempAmount;
                                isSum = false;
                            }
                            else
                            {
                                vatAmount += tempAmount;
                            }

                            distinctDataOccurrences[nickname].Amount += tempAmount;
                            distinctDataOccurrences[nickname].TotalAmount += onAmount;
                            distinctDataOccurrences[nickname].TaxId = dataItem.Id;
                            distinctDataOccurrences[nickname].IsSum = isSum;
                        }
                        else
                        {
                            //var tempAmount = amount / ((totalRate / 100) + 1);
                            //var onAmount = tempAmount;
                            //tempAmount = amount - tempAmount;
                            //tempAmount = (tempAmount * dataItem.Rate) / totalRate ?? 0;
                            var afterCalculation = amount - ((amount * totalRate) / (100 + totalRate)) ?? 0;
                            var tempAmount = (afterCalculation * dataItem.Rate / 100) ?? 0.00;
                            var onAmount = tempAmount;
                            var isSum = true;

                            if (dataItem.TaxCriteria.Criteria == "TDS")
                            {
                                tempAmount = (afterCalculation * dataItem.Rate / 100) ?? 0.00;

                                tdsAmount += tempAmount;
                                isSum = false;
                            }
                            else if (dataItem.TaxCriteria.Criteria == "VDS")
                            {
                                tempAmount = (afterCalculation * dataItem.Rate / 100) ?? 0.00;

                                vdsAmount += tempAmount;
                                isSum = false;
                            }
                            else if (dataItem.TaxCriteria.Criteria == "AIT")
                            {
                                tempAmount = (afterCalculation * dataItem.Rate / 100) ?? 0.00;

                                aitAmount += tempAmount;
                                isSum = false;
                            }
                            else 
                            {
                                vatAmount += tempAmount;
                            }

                            distinctDataOccurrences[nickname] = new NicknameInfo
                            {
                                OccurrenceCount = 1,
                                //Amount = (amount * dataItem.Rate / 100) ?? 0
                                Amount = tempAmount,
                                TotalAmount = onAmount,
                                TaxId = dataItem.Id,
                                IsSum = isSum
                            };
                        }

                    }
                }
            }
            else
            {
                for (int i = 0; i < taxIntArray.Length; i++)
                {
                    var data = _salestaxRepository.All().Where(x => x.SalesTaxMasterId == taxIntArray[i]).Include(x=>x.TaxCriteria).ToList();
                    var amount = amountIntArray[i];
                    

                    // Count the occurrences of each Nickname in the 'data' list
                    foreach (var dataItem in data)
                    {
                        string nickname = dataItem.Nickname + "(" + dataItem.Rate + "% )";

                        if (distinctDataOccurrences.ContainsKey(nickname))
                        {
                            distinctDataOccurrences[nickname].OccurrenceCount++;
                            distinctDataOccurrences[nickname].Amount += (amount * dataItem.Rate / 100) ?? 0;
                            distinctDataOccurrences[nickname].TotalAmount += amount;
                            distinctDataOccurrences[nickname].TaxId = dataItem.Id;

                            if (dataItem.TaxCriteria.Criteria == "TDS")
                            {
                                tdsAmount += (amount * dataItem.Rate / 100) ?? 0.00;
                            }
                            else if (dataItem.TaxCriteria.Criteria == "VDS")
                            {
                                vdsAmount += (amount * dataItem.Rate / 100) ?? 0;
                            }
                            else if (dataItem.TaxCriteria.Criteria == "AIT")
                            {
                                aitAmount += (amount * dataItem.Rate / 100) ?? 0;
                            }
                            else
                            {
                                vatAmount += (amount * dataItem.Rate / 100) ?? 0;
                            }
                        }
                        else
                        {
                            distinctDataOccurrences[nickname] = new NicknameInfo
                            {
                                OccurrenceCount = 1,
                                Amount = (amount * dataItem.Rate / 100) ?? 0,
                                TotalAmount = amount,
                                TaxId = dataItem.Id,
                                IsSum = true
                            };

                            if (dataItem.TaxCriteria.Criteria == "TDS")
                            {
                                tdsAmount += (amount * dataItem.Rate / 100) ?? 0.00;
                                distinctDataOccurrences[nickname].IsSum = false;
                            }
                            else if (dataItem.TaxCriteria.Criteria == "VDS")
                            {
                                vdsAmount += (amount * dataItem.Rate / 100) ?? 0;
                                distinctDataOccurrences[nickname].IsSum = false;
                            }
                            else if (dataItem.TaxCriteria.Criteria == "AIT")
                            {
                                aitAmount += (amount * dataItem.Rate / 100) ?? 0;
                                distinctDataOccurrences[nickname].IsSum = false;
                            }
                            else
                            {
                                vatAmount += (amount * dataItem.Rate / 100) ?? 0;
                            }
                        }
                        
                    }
                }
            }


            List<ProductTaxAmount> data1 = new List<ProductTaxAmount>();
            foreach (var item in distinctDataOccurrences)
            {
                var listitem = new ProductTaxAmount();
                listitem.Nickname = item.Key;
                listitem.Amount = Math.Round(item.Value.Amount, 4);
                listitem.TotalAmount = Math.Round(item.Value.TotalAmount, 4);
                listitem.TaxId = item.Value.TaxId;
                listitem.IsSum = item.Value.IsSum;
                data1.Add(listitem);
            }

            return Json(new { Success = 1, Ex = "Data Loaded Successfully", Data = data1, tds = tdsAmount, vds = vdsAmount, VAT = vatAmount, AIT = aitAmount });

        }

        [HttpGet]
        [AllowAnonymous]
        public IActionResult ProductWiseTaxForExpense(string taxes, string amounts, string criteria)
        {

            string[] taxParts = taxes.Split(',');
            int[] taxIntArray = Array.ConvertAll(taxParts, int.Parse);

            string[] amountParts = amounts.Split(',');
            double[] amountIntArray = Array.ConvertAll(amountParts, double.Parse);

            Dictionary<string, NicknameInfo> distinctDataOccurrences = new Dictionary<string, NicknameInfo>();


            var tdsAmount = 0.00;
            var vdsAmount = 0.00;
            var vatAmount = 0.00;

            if (criteria == "inclusive")
            {
                for (int i = 0; i < taxIntArray.Length; i++)
                {
                    var data = _salestaxRepository.All().Where(x => x.SalesTaxMasterId == taxIntArray[i]).Include(x=>x.TaxCriteria).ToList();
                    //var totalRate = _salestaxRepository.All().Where(x => x.SalesTaxMasterId == taxIntArray[i]).Select(x => x.Rate).Sum().GetValueOrDefault();
                    double amount = amountIntArray[i];

                    foreach (var dataItem in data)
                    {
                        string nickname = dataItem.Nickname + "(" + dataItem.Rate + "% )";

                        if (distinctDataOccurrences.ContainsKey(nickname))
                        {
                            distinctDataOccurrences[nickname].OccurrenceCount++;

                            //var tempAmount = amount / ((totalRate / 100) + 1);
                            //var onAmount = tempAmount;
                            //tempAmount = amount - tempAmount;
                            //tempAmount = (tempAmount * dataItem.Rate) / totalRate ?? 0;
                            var tempAmount = (amount * dataItem.Rate / 100) ?? 0.00;
                            var onAmount = tempAmount;

                            if (dataItem.TaxCriteria.Criteria == "TDS")
                            {
                                tempAmount = (amount * dataItem.Rate / 100) ?? 0.00;

                                tdsAmount += tempAmount;
                            }
                            else if (dataItem.TaxCriteria.Criteria == "VDS")
                            {
                                tempAmount = (amount * dataItem.Rate / 100) ?? 0.00;

                                vdsAmount += tempAmount;
                            }
                            else
                            {
                                vatAmount += tempAmount;
                            }

                            distinctDataOccurrences[nickname].Amount += tempAmount;
                            distinctDataOccurrences[nickname].TotalAmount += onAmount;
                            distinctDataOccurrences[nickname].TaxId = dataItem.Id;
                        }
                        else
                        {
                            var tempAmount = (amount * dataItem.Rate / 100) ?? 0.00;
                            var onAmount = tempAmount;
                            //tempAmount = amount - tempAmount;
                            //tempAmount = (tempAmount * dataItem.Rate) / totalRate ?? 0;

                            if (dataItem.TaxCriteria.Criteria == "TDS")
                            {
                                tempAmount = (amount * dataItem.Rate / 100) ?? 0.00;

                                tdsAmount += tempAmount;
                            }
                            else if (dataItem.TaxCriteria.Criteria == "VDS")
                            {
                                tempAmount = (amount * dataItem.Rate / 100) ?? 0.00;

                                vdsAmount += tempAmount;
                            }
                            else
                            {
                                vatAmount += (amount * dataItem.Rate / 100) ?? 0;
                            }

                            distinctDataOccurrences[nickname] = new NicknameInfo
                            {
                                OccurrenceCount = 1,
                                //Amount = (amount * dataItem.Rate / 100) ?? 0
                                Amount = tempAmount,
                                TotalAmount = onAmount,
                                TaxId = dataItem.Id
                            };
                        }


                    }
                }
            }
            else
            {
                for (int i = 0; i < taxIntArray.Length; i++)
                {
                    var data = _salestaxRepository.All().Where(x => x.SalesTaxMasterId == taxIntArray[i]).Include(x=>x.TaxCriteria).ToList();
                    var amount = amountIntArray[i];

                    // Count the occurrences of each Nickname in the 'data' list
                    foreach (var dataItem in data)
                    {
                        string nickname = dataItem.Nickname + "(" + dataItem.Rate + "% )";

                        if (distinctDataOccurrences.ContainsKey(nickname))
                        {
                            distinctDataOccurrences[nickname].OccurrenceCount++;
                            distinctDataOccurrences[nickname].Amount += (amount * dataItem.Rate / 100) ?? 0;
                            distinctDataOccurrences[nickname].TotalAmount += amount;
                            distinctDataOccurrences[nickname].TaxId = dataItem.Id;
                        }
                        else
                        {
                            distinctDataOccurrences[nickname] = new NicknameInfo
                            {
                                OccurrenceCount = 1,
                                Amount = (amount * dataItem.Rate / 100) ?? 0,
                                TotalAmount = amount,
                                TaxId = dataItem.Id,
                                IsSum = true
                            };

                            if (dataItem.TaxCriteria.Criteria == "TDS")
                            {
                                tdsAmount += (amount * dataItem.Rate / 100) ?? 0.00;
                                distinctDataOccurrences[nickname].IsSum = false;
                            }
                            else if (dataItem.TaxCriteria.Criteria == "VDS")
                            {
                                vdsAmount += (amount * dataItem.Rate / 100) ?? 0;
                                distinctDataOccurrences[nickname].IsSum = false;
                            }
                        }

                    }
                }
            }


            List<ProductTaxAmount> data1 = new List<ProductTaxAmount>();
            foreach (var item in distinctDataOccurrences)
            {
                var listitem = new ProductTaxAmount();
                listitem.Nickname = item.Key;
                listitem.Amount = Math.Round(item.Value.Amount, 2);
                listitem.IsSum = item.Value.IsSum;
                listitem.TaxId = item.Value.TaxId;
                data1.Add(listitem);
            }

            return Json(new { Success = 1, Ex = "Data Loaded Successfully", Data = data1, TDS = tdsAmount, VDS = vdsAmount, VAT = vatAmount });

        }



        [HttpGet]
        [AllowAnonymous]
        public IActionResult ProductWiseChangeRate(string taxes, string amounts, string products, string criteria)
        {

            string[] taxParts = taxes.Split(',');
            int[] taxIntArray = Array.ConvertAll(taxParts, int.Parse);

            string[] amountParts = amounts.Split(',');
            double[] amountIntArray = Array.ConvertAll(amountParts, double.Parse);

            string[] productParts = products.Split(',');
            int[] productIntArray = Array.ConvertAll(productParts, int.Parse);

            List<double> data1 = new List<double>();

            if (criteria == "inclusive")
            {
                for (int i = 0; i < taxIntArray.Length; i++)
                {
                    var data = _salestaxRepository.All().Where(x => x.SalesTaxMasterId == taxIntArray[i] && (x.TaxCriteria.Criteria == "VAT" || x.TaxCriteria.Criteria == null)).Select(x => x.Rate).Sum();
                    var amount = amountIntArray[i];
                    var afterCalculation = amount - ((amount * data) / (100 + data)) ?? 0;
                    var roundedValue = Math.Round(afterCalculation, 4);
                    data1.Add(roundedValue);

                }
            }
            else
            {
                for (int i = 0; i < taxIntArray.Length; i++)
                {
                    var data = productRepository.All().Where(x => x.Id == productIntArray[i]).Select(x => x.Price).FirstOrDefault();
                    var afterCalculation = data;

                    data1.Add(afterCalculation);
                }

            }




            return Json(new { Success = 1, Ex = "Data Loaded Successfully", Data = data1 });

        }

        [HttpGet]
        [AllowAnonymous]
        public IActionResult CategoryWiseChangeRate(string taxes, string amounts, string criteria)
        {

            string[] taxParts = taxes.Split(',');
            int[] taxIntArray = Array.ConvertAll(taxParts, int.Parse);

            string[] amountParts = amounts.Split(',');
            double[] amountIntArray = Array.ConvertAll(amountParts, double.Parse);

            List<double> data1 = new List<double>();

            if (criteria == "inclusive")
            {
                for (int i = 0; i < taxIntArray.Length; i++)
                {
                    var data = _salestaxRepository.All().Where(x => x.SalesTaxMasterId == taxIntArray[i] && (x.TaxCriteria.Criteria == "VAT" || x.TaxCriteria.Criteria == null)).Select(x => x.Rate).Sum();
                    var amount = amountIntArray[i];
                    var afterCalculation = amount - ((amount * data) / (100 + data)) ?? 0;
                    var roundedValue = Math.Round(afterCalculation, 4);
                    data1.Add(roundedValue);

                }
            }
            else
            {
                for (int i = 0; i < taxIntArray.Length; i++)
                {
                    var data = _salestaxRepository.All().Where(x => x.SalesTaxMasterId == taxIntArray[i]).Select(x => x.Rate).Sum();
                    var primaryRate = (data / 100) + 1;

                    var afterCalculation = amountIntArray[i] * primaryRate ?? 0;
                    var roundedValue = Math.Round(afterCalculation, 4);
                    data1.Add(roundedValue);
                }

            }




            return Json(new { Success = 1, Ex = "Data Loaded Successfully", Data = data1 });

        }


        [HttpPost]
        [AllowAnonymous]
        public IActionResult InsertFeedback(string rating, string feedback)
        {
            int rate = 0;
            if (rating == "Happy")
            {
                rate = 5;
            }
            if (rating == "Good")
            {
                rate = 4;
            }
            if (rating == "Satisfactory")
            {
                rate = 3;
            }
            if (rating == "Sad")
            {
                rate = 2;
            }
            if (rating == "Angry")
            {
                rate = 1;
            }

            var model = new FeedbackModel();
            model.Rating = rate;
            if (feedback != null)
            {
                model.Feedback = feedback;
            }
            else
            {
                model.Feedback = "";
            }
            model.FeedbackForm = "Sales";

            _feedbackRepository.Insert(model);

            return Json(new { error = false, message = "Thanks for your feedback.." });

        }

        [HttpGet]
        [AllowAnonymous]
        public IActionResult GetCustomerDetails(int id)
        {

            var customer = customerRepository.All().Where(x => x.Id == id).FirstOrDefault();

            var BillingAddress = $"{customer.BillingStreetAddress ?? ""}, {customer.BillingCity ?? ""}".TrimEnd(',');

            if (BillingAddress.StartsWith(","))
            {
                BillingAddress = BillingAddress.Substring(1);
            }

            return Json(new { Success = 1, Ex = "Data Loaded Successfully", data = customer, Email = customer.Email, BillingAddress = BillingAddress });

        }
        #endregion

        [HttpGet]
        public ActionResult EditCustomer(int CustomerId)
        {
            ViewBag.ActionType = "Edit";
            ViewBag.CustomerGroupHead = customerRepository.GetCustomerGroupHeadForDropDown();
            var customer = customerRepository.Find(CustomerId);
            return View("AddCustomer", customer);
        }

        [HttpGet]
        //[AllowAnonymous]
        [OverridableAuthorize]
        public JsonResult GetCustomerForEdit(int CustomerId)
        {
            try
            {

                var customerData = customerRepository.All().Where(x => x.Id == CustomerId)
                    .Select(x => new
                    {
                        x.Id,
                        x.Title,
                        x.FirstName,
                        x.MiddelName,
                        x.LastName,
                        x.Suffix,
                        x.Name,
                        x.CompanyName,
                        x.Email,
                        x.Phone,
                        x.MobileNumber,
                        x.Fax,
                        x.Other,
                        x.Website,
                        x.CustParentId,
                        x.BillingStreetAddress,
                        x.BillingCity,
                        x.BillingProvince,
                        x.BillingPostalCode,
                        x.BillingCountry,
                        x.ShippingStreetAddress,
                        x.ShippingCity,
                        x.ShippingProvince,
                        x.ShippingPostalCode,
                        x.ShippingCountry,
                        x.Notes,
                        x.CustomerCode,
                        x.PaymentTypeId,
                        x.PaymentTermsId,
                        x.DeliveryOptions,
                        x.Language,
                        x.Taxes,
                        x.ClBalance,
                        x.OverDueBalance,
                        x.OpBalance,
                        x.CustomerCurrencyId,
                        x.BuyerGroupId,
                        OpeningDate = x.OpeningDate.ToString("dd-MMM-yyyy")

                    }).FirstOrDefault();

                //return Json(singleCustomer);
                return Json(new { success = "1", data = customerData });


            }
            catch (Exception ex)
            {
                return Json(new { success = "0", message = ex });
                //throw ex;
            }
        }


        [HttpGet]
        //[AllowAnonymous]
        [OverridableAuthorize]
        public JsonResult DeleteCustomerQB(int CustomerId)
        {
            try
            {


                var model = customerRepository.Find(CustomerId);

                if (model != null)
                {

                    customerRepository.Delete(model);

                    return Json(new { success = "1", msg = "Deleted Successfully" });
                }
                return Json(new { success = "0", msg = "No items found to delete." });

            }
            catch (Exception ex)
            {
                return Json(new { success = "0", msg = "No items found to delete." }); //msg = ex.ToString()
                throw ex;
            }
        }

        #region Receive payment

        [OverridableAuthorize]
        [HttpGet]
        public IActionResult AddReceivePaymentQB(int? id)
        {
            var ComId = HttpContext.Session.GetInt32("ComId");

            if (id == null)
            {
                id = 0;
            }
            var SalesId = id.ToString();
            ViewBag.SalesId = SalesId;
            ViewBag.Customers = customerRepository.All().Where(p => p.ComId == ComId).Include(x => x.Currency)
                       .Select(x => new SelectListItem
                       {
                           Text = x.Name + '-' + x.Currency.CurrencyShortName,
                           Value = x.Id.ToString()
                       });
            ViewBag.ActionType = "Create";

            ViewBag.WarehouseIdMain = _warehouseRepository.All().Where(x => x.ComId == ComId)
                            .Select(x => new SelectListItem
                            {
                                Text = x.WhName,
                                Value = x.Id.ToString()
                            });

            var customerId = saleRepository.All().Where(x => x.Id == id).Select(z => z.CustomerId).FirstOrDefault();
            ViewBag.CustomerId = customerId.ToString();

            var products = productRepository.All().Where(p => p.ComId == ComId).ToList();

            SelectList productslist = new SelectList(products, "Id", "Name");
            ViewData["ProductList"] = productslist;

            var paymentmethods = paymentTypeRepository.All().ToList();
            SelectList paymentMethodList = new SelectList(paymentmethods, "Id", "TypeName");
            ViewData["PaymentMethod"] = paymentMethodList;

            var creditAccountId = accountHeadRepository.All().Where(x => x.AccName.Contains("Sales Receivable") && x.AccType == "L").ToList();
            SelectList creditAccountList = new SelectList(creditAccountId, "Id", "AccName");
            ViewData["CreditAccount"] = creditAccountList;

            var taxes = _mastersalestaxRepository.All().Where(f => f.ComId == ComId).ToList();
            SelectList taxList = new SelectList(taxes, "Id", "Name");
            ViewData["TaxList"] = taxList;

            var agency = _agencyRepository.All();
            var data = agency.ToList();
            SelectList agencyList = new SelectList(data, "Id", "AgencyName");

            ViewData["AgencyList"] = agencyList;

            var uniquenumber = "DT-" + DateTime.Now.ToString("ddMMyyHHmmssfff");

            var doctypeId = _docTypeRepository.All().Where(x => x.DocType == "Receive payment").FirstOrDefault().Id;

            var docPrefix = docPrefixRepository.All().Where(x => x.ComId == ComId && x.DocTypeId == doctypeId).FirstOrDefault();
            if (docPrefix != null)
            {
                uniquenumber = "";
            }

            ViewBag.DefaultInvoice = uniquenumber;

            //var accountCategory = accountCategoryRepository.All();
            //var catParentId = accountCategory.Where(x => x.AccountCategoryName == "Current Asset").Select(y=>y.Id).FirstOrDefault();
            //var accountCat = accountCategoryRepository.All();
            //var cat = accountCategory.Where(x => x.ParentAccountCategoryId == catParentId).ToList();
            //SelectList catlist = new SelectList(cat, "Id", "AccountCategoryName");
            //ViewData["CategoryList"] = catlist;

            ViewData["CategoryList"] = accountHeadRepository.GetCashBankHeadForDropDown();

            ViewBag.Id = 0.ToString();
            return View();
        }


        [OverridableAuthorize]
        [HttpGet]
        public IActionResult EditReceivePaymentQB(int? id)
        {
            var ComId = HttpContext.Session.GetInt32("ComId");


            ViewBag.SalesId = 0.ToString();
            ViewBag.Customers = customerRepository.All().Where(p => p.ComId == ComId).Include(x => x.Currency)
                       .Select(x => new SelectListItem
                       {
                           Text = x.Name + '-' + x.Currency.CurrencyShortName,
                           Value = x.Id.ToString()
                       });
            ViewBag.ActionType = "Edit";
            ViewBag.WarehouseIdMain = _warehouseRepository.All().Where(x => x.ComId == ComId)
                            .Select(x => new SelectListItem
                            {
                                Text = x.WhName,
                                Value = x.Id.ToString()
                            });

            var customerId = saleRepository.All().Where(x => x.Id == id).Select(z => z.CustomerId).FirstOrDefault();
            ViewBag.CustomerId = customerId.ToString();

            var products = productRepository.All().Where(p => p.ComId == ComId).ToList();

            SelectList productslist = new SelectList(products, "Id", "Name");
            ViewData["ProductList"] = productslist;

            var paymentmethods = paymentTypeRepository.All().ToList();
            SelectList paymentMethodList = new SelectList(paymentmethods, "Id", "TypeName");
            ViewData["PaymentMethod"] = paymentMethodList;

            var creditAccountId = accountHeadRepository.All().Where(x => (x.AccName.Contains("Sales Receivable") && x.AccType == "L") || x.AccName.Contains("Accounts Receivable")).ToList();
            SelectList creditAccountList = new SelectList(creditAccountId, "Id", "AccName");
            ViewData["CreditAccount"] = creditAccountList;

            var taxes = _mastersalestaxRepository.All().Where(f => f.ComId == ComId).ToList();
            SelectList taxList = new SelectList(taxes, "Id", "Name");
            ViewData["TaxList"] = taxList;

            var agency = _agencyRepository.All();
            var data = agency.ToList();
            SelectList agencyList = new SelectList(data, "Id", "AgencyName");

            ViewData["AgencyList"] = agencyList;



            ViewData["CategoryList"] = accountHeadRepository.GetCashBankHeadForDropDown();

            ViewBag.Id = id.ToString();
            return View("AddReceivePaymentQB");
        }

        [AllowAnonymous]
        [HttpGet]
        public IActionResult ViewReceivePaymentQB(int? id)
        {
            var ComId = HttpContext.Session.GetInt32("ComId");


            ViewBag.SalesId = 0.ToString();
            ViewBag.Customers = customerRepository.All().Where(p => p.ComId == ComId).Include(x => x.Currency)
                       .Select(x => new SelectListItem
                       {
                           Text = x.Name + '-' + x.Currency.CurrencyShortName,
                           Value = x.Id.ToString()
                       });

            ViewBag.WarehouseIdMain = _warehouseRepository.All().Where(x => x.ComId == ComId)
                .Select(x => new SelectListItem
                {
                    Text = x.WhName,
                    Value = x.Id.ToString()
                });
            ViewBag.ActionType = "View";

            var customerId = saleRepository.All().Where(x => x.Id == id).Select(z => z.CustomerId).FirstOrDefault();
            ViewBag.CustomerId = customerId.ToString();

            var products = productRepository.All().Where(p => p.ComId == ComId).ToList();

            SelectList productslist = new SelectList(products, "Id", "Name");
            ViewData["ProductList"] = productslist;

            var paymentmethods = paymentTypeRepository.All().ToList();
            SelectList paymentMethodList = new SelectList(paymentmethods, "Id", "TypeName");
            ViewData["PaymentMethod"] = paymentMethodList;

            var creditAccountId = accountHeadRepository.All().Where(x => x.AccName.Contains("Sales Receivable") && x.AccType == "L").ToList();
            SelectList creditAccountList = new SelectList(creditAccountId, "Id", "AccName");
            ViewData["CreditAccount"] = creditAccountList;

            var taxes = _mastersalestaxRepository.All().Where(f => f.ComId == ComId).ToList();
            SelectList taxList = new SelectList(taxes, "Id", "Name");
            ViewData["TaxList"] = taxList;

            var agency = _agencyRepository.All();
            var data = agency.ToList();
            SelectList agencyList = new SelectList(data, "Id", "AgencyName");

            ViewData["AgencyList"] = agencyList;



            ViewData["CategoryList"] = accountHeadRepository.GetCashBankHeadForDropDown();

            ViewBag.Id = id.ToString();
            return View("AddReceivePaymentQB");
        }

        [AllowAnonymous]
        [HttpGet]
        public IActionResult LoadReceivePaymentDetails(int id)
        {
            var doctypeId = _docTypeRepository
                .All()
                .Where(x => (x.DocType == "Invoice" && x.DocFor == "Sales") || (x.DocType == "Sales receipt"))
                .Select(x => x.Id)
                .ToList();

            var data = _accountsDailyTransaction.All().Where(x => x.Id == id).FirstOrDefault();

            data.TransactionDetails = _transactionDetailsRepository.All().Include(x => x.Sales).Where(x => x.TransactionId == data.Id && doctypeId.Contains(x.Sales.DocTypeId.GetValueOrDefault())).ToList();

            return Json(new { Success = 1, Data = data, ex = "Data Loaded Successfully" });
        }

        [AllowAnonymous]
        [HttpGet]
        public IActionResult LoadTransactionDetails(int id)
        {
            var doctypeId = _docTypeRepository
                .All()
                .Where(x => (x.DocType == "Invoice" && x.DocFor == "Sales") || (x.DocType == "Sales receipt"))
                .Select(x => x.Id)
                .ToList();

            var obj = _transactionDetailsRepository.All().Include(x => x.Sales).Where(x => x.TransactionId == id && doctypeId.Contains(x.Sales.DocTypeId.GetValueOrDefault())).ToList();
            var data = new List<TransactionDetailsVM>();
            foreach (var item in obj)
            {
                var temp = new TransactionDetailsVM();
                var salesData = saleRepository.All().Where(x => x.Id == item.SalesId).FirstOrDefault();
                temp.TransactionDetailsId = item.Id;
                temp.Id = item.SalesId ?? 0;
                temp.SalesCode = salesData.SaleCode;
                temp.SalesDate = salesData.SalesDate;
                temp.Description = salesData.SaleCode;
                temp.DueDate = salesData.DueDate;
                temp.Original_Amount = (decimal)salesData.Total;
                temp.CurrencyRate = salesData.CurrencyRate;
                temp.Payment = (decimal)item.NetAmount;
                temp.ExchangeLossGain = (decimal)item.ExchangeLossGain;
                temp.CheckBox = true;
                var netAmountSum = salesPaymentRepository.All().Where(x => x.SalesId == item.SalesId).Select(x => x.Amount).Sum();
                temp.Open_Balance = (double)(temp.Original_Amount - netAmountSum + temp.Payment);

                data.Add(temp);
            }
            return Json(new { Success = 1, Data = data, ex = "Data Loaded Successfully" });
        }

        [AllowAnonymous]
        [HttpGet]
        public IActionResult LoadTransactionDetailsForCredit(int id, int? customerId)
        {
            var parentTrxn = 0;
            var doctypeId = _docTypeRepository
                .All()
                .Where(x => x.DocType == "Credit Note")
                .Select(x => x.Id)
                .ToList();



            var obj = _transactionDetailsRepository.All().Include(x => x.Sales).Where(x => x.TransactionId == id && doctypeId.Contains(x.Sales.DocTypeId.GetValueOrDefault())).ToList();
            var data = new List<TransactionDetailsVM>();
            foreach (var item in obj)
            {
                var temp = new TransactionDetailsVM();
                var salesData = saleRepository.All().Where(x => x.Id == item.SalesId).FirstOrDefault();
                temp.TransactionDetailsId = item.Id;
                temp.Id = item.SalesId ?? 0;
                temp.SalesCode = salesData.SaleCode;
                temp.SalesDate = salesData.SalesDate;
                temp.Description = salesData.SaleCode;
                temp.DueDate = salesData.DueDate;
                temp.Original_Amount = (decimal)salesData.Total;
                temp.CurrencyRate = salesData.CurrencyRate;
                temp.Payment = (decimal)item.NetAmount;
                var netAmountSum = salesPaymentRepository.All().Where(x => x.SalesId == item.SalesId).Select(x => x.Amount).Sum();
                temp.Open_Balance = (double)(temp.Original_Amount - netAmountSum);

                data.Add(temp);
            }

            var CreditAccountId = accountHeadRepository.All().Where(x => x.AccountCategorys.AccountCategoryName.ToLower() == "Adv. Received from Customer")
                                  .FirstOrDefault().Id;
            var advdata = _accountsDailyTransaction.All().Where(x => x.CustomerId == customerId && x.CreditAccountId == CreditAccountId && x.Id != id).ToList();

            var trxnData = _accountsDailyTransaction.All().Where(x => x.Id == id).FirstOrDefault();

            var getOpenBalance = _accountsDailyTransaction.All().Where(x => x.ParentTransactionId == trxnData.ParentTransactionId && x.Id != id).Sum(x => x.AdjustedAmount);

            foreach (var item in advdata)
            {
                var singledata = new TransactionDetailsVM();
                var descp = "Adv. Receive #" + item.TransactionCode;
                var openBlnc = item.TransactionAmount - (decimal)item.ReceivedAmount;

                singledata.Id = 0;
                singledata.SalesDate = item.InputDate;
                singledata.Original_Amount = (decimal)item.TransactionAmount;
                singledata.CurrencyRate = item.CurrencyRate;
                singledata.TransactionDetailsId = item.Id;
                //int roundedValue = (int)Math.Truncate(item.DueAmt);
                singledata.Open_Balance = (double)item.TransactionAmount - getOpenBalance;
                singledata.Description = descp;
                singledata.CheckBox = false;
                singledata.SalesCode = item.TransactionCode;
                singledata.Payment = (decimal)trxnData.AdjustedAmount;
                data.Add(singledata);

                parentTrxn = item.Id;
            }
            return Json(new { Success = 1, Data = data, ParentTransactionId = parentTrxn, ex = "Data Loaded Successfully" });
        }

        public class TransactionDetailsVM
        {
            public int TransactionDetailsId { get; set; }
            public int Id { get; set; }
            public string? SalesCode { get; set; }
            public DateTime SalesDate { get; set; }
            public string? Description { get; set; }
            public DateTime DueDate { get; set; }
            public decimal Original_Amount { get; set; }
            public double CurrencyRate { get; set; }
            public double Open_Balance { get; set; }
            public decimal Payment { get; set; }
            public decimal ExchangeLossGain { get; set; }
            public bool CheckBox { get; set; }
            public double TransactionAmount { get; set; }
        }
        [HttpGet]
        [AllowAnonymous]
        public IActionResult LoadReceivePayment(string invoiceid)
        {
            var customerId = saleRepository.All().Where(x => x.Id == int.Parse(invoiceid)).Select(z => z.CustomerId).FirstOrDefault();

            var doctypeId = _docTypeRepository
            .All()
            .Where(x => (x.DocType == "Invoice" || x.DocType == "Sales receipt") && x.DocFor == "Sales")
            .Select(x => x.Id)
            .ToList();


            var salesData = saleRepository.All().Where(x => x.CustomerId == customerId && doctypeId.Contains(x.DocTypeId.GetValueOrDefault())).ToList();

            if (salesData != null && salesData.Count >= 0)
            {
                var data = new List<invoiceGridItem>();
                foreach (var item in salesData)
                {
                    var singledata = new invoiceGridItem();
                    var totalAmount = salesPaymentRepository.All().Where(x => x.SalesId == item.Id).Sum(x => x.Amount);
                    var openBlnc = item.Total - (double)totalAmount;
                    var descp = "Invoice #" + item.SaleCode;

                    singledata.Id = item.Id;
                    singledata.DueDate = item.DueDate;
                    singledata.SalesDate = item.SalesDate;
                    singledata.Original_Amount = item.Total;
                    singledata.CurrencyRate = item.CurrencyRate;
                    singledata.Open_Balance = openBlnc;
                    singledata.Description = descp;
                    singledata.SalesCode = item.SaleCode;
                    if (item.Id == int.Parse(invoiceid))
                    {
                        singledata.CheckBox = true;
                    }
                    else
                    {
                        singledata.CheckBox = false;
                    }
                    if (openBlnc > 0)
                    {
                        data.Add(singledata);
                    }

                }
                return Json(new { Success = 1, Data = data, ex = "Data Loaded Successfully" });
            }
            return Json(new { Success = 2, ex = "Data Loaded Failed" });
        }

        [HttpGet]
        [AllowAnonymous]
        public IActionResult LoadReceivePaymentCredit(string invoiceid)
        {
            var customerId = saleRepository.All().Where(x => x.Id == int.Parse(invoiceid)).Select(z => z.CustomerId).FirstOrDefault();
            var parentTrxnId = 0;
            var doctypeId = _docTypeRepository
            .All()
            .Where(x => x.DocType == "Credit Note" && x.DocFor == "Sales")
            .Select(x => x.Id)
            .ToList();


            var salesData = saleRepository.All().Where(x => x.CustomerId == customerId && doctypeId.Contains(x.DocTypeId.GetValueOrDefault())).ToList();
            var data = new List<invoiceGridItem>();
            if (salesData != null && salesData.Count >= 0)
            {

                foreach (var item in salesData)
                {
                    var singledata = new invoiceGridItem();
                    var descp = "Credit Note #" + item.SaleCode;
                    var totalAmount = salesPaymentRepository.All().Where(x => x.SalesId == item.Id).Sum(x => x.Amount);
                    var openBlnc = item.Total - (double)totalAmount;

                    singledata.Id = item.Id;
                    singledata.DueDate = item.DueDate;
                    singledata.SalesDate = item.SalesDate;
                    singledata.Original_Amount = item.Total;
                    singledata.CurrencyRate = item.CurrencyRate;
                    //int roundedValue = (int)Math.Truncate(item.DueAmt) ;
                    singledata.Open_Balance = openBlnc;
                    singledata.Description = descp;
                    singledata.SalesCode = item.SaleCode;
                    if (item.Id == int.Parse(invoiceid))
                    {
                        singledata.CheckBox = true;
                    }
                    else
                    {
                        singledata.CheckBox = false;
                    }
                    data.Add(singledata);
                }


                var CreditAccountId = accountHeadRepository.All().Where(x => x.AccountCategorys.AccountCategoryName.ToLower() == "Adv. Received from Customer").FirstOrDefault().Id;

                var advdata = _accountsDailyTransaction.All().Where(x => x.CustomerId == customerId && x.CreditAccountId == CreditAccountId).FirstOrDefault();
                ///var receiveAmnt = _accountsDailyTransaction.All().Where(x => x.ParentTransactionId == advdata.Id).Select(x => x.AdjustedAmount)?.Sum() : 0.00;

                var receiveAmnt = _accountsDailyTransaction.All().Where(x => x.ParentTransactionId == advdata.Id).Select(x => x.AdjustedAmount).DefaultIfEmpty(0.00).Sum();

                var advsingledata = new invoiceGridItem();
                var advdescp = "Adv. Receive #" + advdata.TransactionCode;
                //var advopenBlnc = advdata.TransactionAmount - (decimal)advdata.ReceivedAmount;
                var advopenBlnc = advdata.TransactionAmount - (decimal)receiveAmnt;

                advsingledata.Id = 0;
                advsingledata.SalesDate = advdata.InputDate;
                advsingledata.Original_Amount = (double)advdata.TransactionAmount;
                advsingledata.CurrencyRate = advdata.CurrencyRate;
                advsingledata.TransactionDetailsId = advdata.Id;
                //int roundedValue = (int)Math.Truncate(item.DueAmt);
                advsingledata.Open_Balance = (double)advopenBlnc;
                advsingledata.Payment = (double)advopenBlnc;
                advsingledata.Description = advdescp;
                advsingledata.CheckBox = false;
                advsingledata.SalesCode = advdata.TransactionCode;
                data.Add(advsingledata);

                parentTrxnId = advdata.Id;
                return Json(new { Success = 1, Data = data, ParentTransactionId = parentTrxnId, ex = "Data Loaded Successfully" });
            }


            return Json(new { Success = 1, Data = data, ex = "Data Loaded Successfully" });
        }

        [HttpGet]
        [AllowAnonymous]
        public IActionResult LoadCustomerWiseData(int customerid)
        {
            var doctypeId = _docTypeRepository
            .All()
            .Where(x => (x.DocType == "Invoice" || x.DocType == "Sales receipt") && x.DocFor == "Sales")
            .Select(x => x.Id)
            .ToList();


            var salesData = saleRepository.All().Where(x => x.CustomerId == customerid
            && doctypeId.Contains(x.DocTypeId.GetValueOrDefault())
            && x.Total - (double)x.SalesPayments.Sum(x => x.Amount) > 1
            && x.Total - x.SalesReturn.Sum(x => x.Total) > 0
            )

                .ToList();
            //var salesData = saleRepository.All().Where(x => x.CustomerId == customerid && x.DocTypeId == doctypeId).ToList();

            if (salesData != null && salesData.Count >= 0)
            {
                var data = new List<invoiceGridItem>();
                foreach (var item in salesData)
                {
                    var singledata = new invoiceGridItem();
                    var totalpaymentAmount = salesPaymentRepository.All().Where(x => x.SalesId == item.Id).Sum(x => x.Amount);
                    var openBlnc = item.Total - (double)totalpaymentAmount;
                    var descp = "Invoice #" + item.SaleCode;

                    singledata.Id = item.Id;
                    singledata.DueDate = item.DueDate;
                    singledata.SalesDate = item.SalesDate;
                    singledata.Original_Amount = item.Total;
                    singledata.CurrencyRate = item.CurrencyRate;
                    singledata.Open_Balance = openBlnc;
                    singledata.Description = descp;
                    singledata.CheckBox = false;
                    singledata.SalesCode = item.SaleCode;
                    if (openBlnc > 0)
                    {
                        data.Add(singledata);
                    }

                }
                return Json(new { Success = 1, Data = data, ex = "Data Loaded Successfully" });
            }
            return Json(new { Success = 2, ex = "Data Loaded Failed" });
        }

        [HttpGet]
        [AllowAnonymous]
        public IActionResult LoadCustomerWiseDataForCredit(int customerid)
        {

            var parentTrxnId = 0;

            var doctypeId = _docTypeRepository
            .All()
            .Where(x => x.DocType == "Credit Note")
            .Select(x => x.Id)
            .ToList();


            var salesData = saleRepository.All().Where(x => x.CustomerId == customerid && doctypeId.Contains(x.DocTypeId.GetValueOrDefault())).ToList();
            var data = new List<invoiceGridItem>();

            if (salesData != null && salesData.Count >= 0)
            {

                foreach (var item in salesData)
                {
                    var singledata = new invoiceGridItem();
                    var descp = "Credit note #" + item.SaleCode;
                    var totalAmount = salesPaymentRepository.All().Where(x => x.SalesId == item.Id).Sum(x => x.Amount);
                    var openBlnc = item.Total - (double)totalAmount;

                    singledata.Id = item.Id;
                    singledata.DueDate = item.DueDate;
                    singledata.SalesDate = item.SalesDate;
                    singledata.Original_Amount = item.Total;
                    singledata.CurrencyRate = item.CurrencyRate;
                    //int roundedValue = (int)Math.Truncate(item.DueAmt);
                    singledata.Open_Balance = openBlnc;
                    singledata.Payment = openBlnc;
                    singledata.Description = descp;
                    singledata.CheckBox = false;
                    singledata.SalesCode = item.SaleCode;
                    data.Add(singledata);
                }


            }

            var CreditAccountId = accountHeadRepository.All()
                 .Where(x => x.AccountCategorys.AccountCategoryName.ToLower() == "Adv. Received from Customer").FirstOrDefault().Id;

            var advdata = _accountsDailyTransaction.All().Where(x => x.CustomerId == customerid && x.CreditAccountId == CreditAccountId).FirstOrDefault();
            if (advdata != null)
            {
                var receiveAmnt = _accountsDailyTransaction.All().Where(x => x.ParentTransactionId == advdata.Id).Select(x => x.AdjustedAmount).Sum();

                var advsingledata = new invoiceGridItem();
                var advdescp = "Adv. Receive #" + advdata.TransactionCode;
                //var advopenBlnc = advdata.TransactionAmount - (decimal)advdata.ReceivedAmount;
                var advopenBlnc = advdata.TransactionAmount - (decimal)receiveAmnt;

                advsingledata.Id = 0;
                advsingledata.SalesDate = advdata.InputDate;
                advsingledata.Original_Amount = (double)advdata.TransactionAmount;
                advsingledata.CurrencyRate = advdata.CurrencyRate;
                advsingledata.TransactionDetailsId = advdata.Id;
                //int roundedValue = (int)Math.Truncate(item.DueAmt);
                advsingledata.Open_Balance = (double)advopenBlnc;
                advsingledata.Payment = (double)advopenBlnc;
                advsingledata.Description = advdescp;
                advsingledata.CheckBox = false;
                advsingledata.SalesCode = advdata.TransactionCode;
                data.Add(advsingledata);

                parentTrxnId = advdata.Id;
            }

            return Json(new { Success = 1, Data = data, ParentTransactionId = parentTrxnId, ex = "Data Loaded Successfully" });
            //return Json(new { Success = 2, ex = "Data Loaded Failed" });
        }

        [HttpGet]
        [AllowAnonymous]
        public IActionResult LoadFindInvoice(string InvoiceNo, int CustomerId)
        {
            var salesData = new List<SalesModel>();
            if (InvoiceNo != null)
            {
                salesData = saleRepository.All().Where(x => x.CustomerId == CustomerId && x.SaleCode.Contains(InvoiceNo)).ToList();
            }
            else
            {
                salesData = saleRepository.All().Where(x => x.CustomerId == CustomerId).ToList();
            }


            if (salesData != null && salesData.Count >= 0)
            {
                var data = new List<invoiceGridItem>();
                foreach (var item in salesData)
                {
                    var singledata = new invoiceGridItem();
                    var openBlnc = item.Total - (double)item.PaidAmount;
                    var descp = "Invoice #" + item.SaleCode;

                    singledata.Id = item.Id;
                    singledata.DueDate = item.DueDate;
                    singledata.SalesDate = item.SalesDate;
                    singledata.Original_Amount = item.Total;
                    singledata.CurrencyRate = item.CurrencyRate;
                    singledata.Open_Balance = openBlnc;
                    singledata.Description = descp;
                    singledata.CheckBox = false;
                    singledata.SalesCode = item.SaleCode;
                    data.Add(singledata);
                }
                return Json(new { Success = 1, Data = data, ex = "Data Loaded Successfully" });
            }
            return Json(new { Success = 2, ex = "Data Loaded Failed" });
        }

        [HttpGet]
        [AllowAnonymous]
        public IActionResult LoadFindCredit(string InvoiceNo, int CustomerId)
        {
            var doctypeId = _docTypeRepository
            .All()
            .Where(x => x.DocType == "Credit Note")
            .Select(x => x.Id)
            .ToList();

            var salesData = new List<SalesModel>();
            if (InvoiceNo != null)
            {
                salesData = saleRepository.All().Where(x => x.CustomerId == CustomerId && x.SaleCode.Contains(InvoiceNo) && doctypeId.Contains(x.DocTypeId.GetValueOrDefault())).ToList();
            }
            else
            {
                salesData = saleRepository.All().Where(x => x.CustomerId == CustomerId && doctypeId.Contains(x.DocTypeId.GetValueOrDefault())).ToList();
            }
            var data = new List<invoiceGridItem>();
            var parentTrxnId = 0;

            if (salesData != null && salesData.Count >= 0)
            {
                foreach (var item in salesData)
                {
                    var singledata = new invoiceGridItem();
                    var openBlnc = item.Total - (double)item.PaidAmount;
                    var descp = "Credit note #" + item.SaleCode;

                    singledata.Id = item.Id;
                    singledata.DueDate = item.DueDate;
                    singledata.SalesDate = item.SalesDate;
                    singledata.Original_Amount = item.Total;
                    singledata.CurrencyRate = item.CurrencyRate;
                    int roundedValue = (int)Math.Truncate(item.DueAmt);
                    singledata.Open_Balance = roundedValue;
                    singledata.Description = descp;
                    singledata.CheckBox = false;
                    singledata.SalesCode = item.SaleCode;
                    data.Add(singledata);
                }
                //return Json(new { Success = 1, Data = data, ex = "Data Loaded Successfully" });
            }

            var CreditAccountId = accountHeadRepository.All()
                 .Where(x => x.AccountCategorys.AccountCategoryName.ToLower() == "Adv. Received from Customer").FirstOrDefault().Id;

            var advdata = _accountsDailyTransaction.All().Where(x => x.CustomerId == CustomerId && x.CreditAccountId == CreditAccountId).FirstOrDefault();
            if (advdata != null)
            {
                var receiveAmnt = _accountsDailyTransaction.All().Where(x => x.ParentTransactionId == advdata.Id).Select(x => x.AdjustedAmount).Sum();

                var advsingledata = new invoiceGridItem();
                var advdescp = "Adv. Receive #" + advdata.TransactionCode;
                //var advopenBlnc = advdata.TransactionAmount - (decimal)advdata.ReceivedAmount;
                var advopenBlnc = advdata.TransactionAmount - (decimal)receiveAmnt;

                advsingledata.Id = 0;
                advsingledata.SalesDate = advdata.InputDate;
                advsingledata.Original_Amount = (double)advdata.TransactionAmount;
                advsingledata.CurrencyRate = advdata.CurrencyRate;
                advsingledata.TransactionDetailsId = advdata.Id;
                //int roundedValue = (int)Math.Truncate(item.DueAmt);
                advsingledata.Open_Balance = (double)advopenBlnc;
                advsingledata.Payment = (double)advopenBlnc;
                advsingledata.Description = advdescp;
                advsingledata.CheckBox = false;
                advsingledata.SalesCode = advdata.TransactionCode;
                data.Add(advsingledata);

                parentTrxnId = advdata.Id;
            }

            return Json(new { Success = 1, Data = data, ParentTransactionId = parentTrxnId, ex = "Data Loaded Successfully" });
            //return Json(new { Success = 2, ex = "Data Loaded Failed" });
        }

        [HttpGet]
        [AllowAnonymous]
        public IActionResult LoadFilteredData(DateTime dtFrom, DateTime dtTo, int CustomerId)
        {
            var salesData = saleRepository.All().Where(x => x.SalesDate >= dtFrom && x.SalesDate <= dtTo && x.CustomerId == CustomerId).ToList();

            if (salesData != null && salesData.Count >= 0)
            {
                var data = new List<invoiceGridItem>();
                foreach (var item in salesData)
                {
                    var singledata = new invoiceGridItem();
                    var openBlnc = item.Total - (double)item.PaidAmount;
                    var descp = "Invoice #" + item.SaleCode;

                    singledata.Id = item.Id;
                    singledata.DueDate = item.DueDate;
                    singledata.SalesDate = item.SalesDate;
                    singledata.Original_Amount = item.Total;
                    singledata.CurrencyRate = item.CurrencyRate;
                    singledata.Open_Balance = openBlnc;
                    singledata.Description = descp;
                    singledata.CheckBox = false;
                    singledata.SalesCode = item.SaleCode;
                    data.Add(singledata);
                }
                return Json(new { Success = 1, Data = data, ex = "Data Loaded Successfully" });
            }
            return Json(new { Success = 2, ex = "Data Loaded Failed" });
        }

        [HttpGet]
        [AllowAnonymous]
        public IActionResult LoadFilteredDataForCredit(DateTime dtFrom, DateTime dtTo, int CustomerId)
        {
            var doctypeId = _docTypeRepository
                .All()
                .Where(x => x.DocType == "Credit Note")
                .Select(x => x.Id)
                .ToList();

            var salesData = saleRepository.All().Where(x => x.SalesDate >= dtFrom && x.SalesDate <= dtTo && x.CustomerId == CustomerId && doctypeId.Contains(x.DocTypeId.GetValueOrDefault())).ToList();
            var data = new List<invoiceGridItem>();
            var parentTrxnId = 0;

            if (salesData != null && salesData.Count >= 0)
            {

                foreach (var item in salesData)
                {
                    var singledata = new invoiceGridItem();
                    var openBlnc = item.Total - (double)item.PaidAmount;
                    var descp = "Invoice #" + item.SaleCode;

                    singledata.Id = item.Id;
                    singledata.DueDate = item.DueDate;
                    singledata.SalesDate = item.SalesDate;
                    singledata.Original_Amount = item.Total;
                    singledata.CurrencyRate = item.CurrencyRate;
                    int roundedValue = (int)Math.Truncate(item.DueAmt);
                    singledata.Open_Balance = roundedValue;
                    singledata.Description = descp;
                    singledata.CheckBox = false;
                    singledata.SalesCode = item.SaleCode;
                    data.Add(singledata);
                }

            }

            var CreditAccountId = accountHeadRepository.All()
                 .Where(x => x.AccountCategorys.AccountCategoryName.ToLower() == "Adv. Received from Customer").FirstOrDefault().Id;

            var advdata = _accountsDailyTransaction.All().Where(x => x.CustomerId == CustomerId && x.CreditAccountId == CreditAccountId && x.InputDate >= dtFrom && x.InputDate <= dtTo).FirstOrDefault();
            if (advdata != null)
            {
                var receiveAmnt = _accountsDailyTransaction.All().Where(x => x.ParentTransactionId == advdata.Id).Select(x => x.AdjustedAmount).Sum();

                var advsingledata = new invoiceGridItem();
                var advdescp = "Adv. Receive #" + advdata.TransactionCode;
                //var advopenBlnc = advdata.TransactionAmount - (decimal)advdata.ReceivedAmount;
                var advopenBlnc = advdata.TransactionAmount - (decimal)receiveAmnt;

                advsingledata.Id = 0;
                advsingledata.SalesDate = advdata.InputDate;
                advsingledata.Original_Amount = (double)advdata.TransactionAmount;
                advsingledata.CurrencyRate = advdata.CurrencyRate;
                advsingledata.TransactionDetailsId = advdata.Id;
                //int roundedValue = (int)Math.Truncate(item.DueAmt);
                advsingledata.Open_Balance = (double)advopenBlnc;
                advsingledata.Payment = (double)advopenBlnc;
                advsingledata.Description = advdescp;
                advsingledata.CheckBox = false;
                advsingledata.SalesCode = advdata.TransactionCode;
                data.Add(advsingledata);

                parentTrxnId = advdata.Id;
            }

            return Json(new { Success = 1, Data = data, ParentTransactionId = parentTrxnId, ex = "Data Loaded Successfully" });
            //return Json(new { Success = 2, ex = "Data Loaded Failed" });
        }

        public class invoiceGridItem
        {
            public int Id { get; set; }
            public string? SalesCode { get; set; }
            public string? Description { get; set; }
            public DateTime DueDate { get; set; }
            public DateTime SalesDate { get; set; }
            public double Original_Amount { get; set; }
            public double CurrencyRate { get; set; }
            public double Open_Balance { get; set; }
            public bool CheckBox { get; set; }
            public double Payment { get; set; }
            public int? TransactionDetailsId { get; set; }
        }

        public class MakePaymentVM
        {
            public int Id { get; set; }
            public int CustomerId { get; set; }
            public string? CustomerName { get; set; }
            public string? EmailId { get; set; }
            public string? PaymentDate { get; set; }
            public int PaymentMethod { get; set; }
            public string? ReferenceNo { get; set; }
            public int DepositTo { get; set; }
            public string? AmountReceived { get; set; }
            public string? Memo { get; set; }
            public string? AmountToCredit { get; set; }
            public List<invoiceGridItem> invoiceGridItem { get; set; }
        }

        //[AllowAnonymous]
        //[HttpPost]
        //public IActionResult MakePayment([FromBody] MakePaymentVM model)
        //{
        //    var ComId = HttpContext.Session.GetInt32("ComId");
        //    if(model.Id == 0)
        //    {
        //        var obj = new TransactionModel();
        //        obj.Id = model.Id;
        //        obj.TransactionAmount = decimal.Parse(model.AmountReceived);
        //        obj.CustomerId = model.CustomerId;
        //        obj.CreditAccountId = model.DepositTo;
        //        obj.Description = model.Memo;
        //        obj.InputDate = DateTime.Parse(model.PaymentDate);
        //        obj.PaymentTypeId = model.PaymentMethod;
        //        obj.TransactionCode = model.ReferenceNo;

        //        if (model.invoiceGridItem.Count > 0)
        //        {
        //            var childData = new List<TransactionDetailsModel>();
        //            foreach (var item in model.invoiceGridItem)
        //            {
        //                var childobj = new TransactionDetailsModel();
        //                childobj.SalesId = item.Id;
        //                childobj.NetAmount = decimal.Parse(item.Original_Amount);
        //                childobj.Amount = float.Parse(item.Payment);
        //                childobj.ComId = ComId ?? 0;

        //                childData.Add(childobj);

        //                var salesdata = saleRepository.All().Where(x => x.Id == item.Id).FirstOrDefault();
        //                salesdata.PaidAmount += decimal.Parse(item.Payment);

        //                saleRepository.Update(salesdata, salesdata.Id);


        //            }
        //            obj.TransactionDetails = childData;


        //        }

        //        _accountsDailyTransaction.Insert(obj);

        //        if (model.invoiceGridItem.Count > 0 && obj.Id > 0)
        //        {
        //            foreach (var item in model.invoiceGridItem)
        //            {
        //                SalesPaymentModel salespayment = new SalesPaymentModel();
        //                salespayment.SalesId = item.Id;
        //                salespayment.Amount = decimal.Parse(item.Payment);
        //                salespayment.isPosted = false;
        //                salespayment.RowNo = 999;
        //                salespayment.TransactionId = obj.Id;

        //                salesPaymentRepository.Insert(salespayment);
        //            }
        //        }

        //        return Json(new { error = false, message = "Make payment successfully", Id = obj.Id });
        //    }
        //    else
        //    {
        //        var obj = new TransactionModel();
        //        obj.Id = model.Id;
        //        obj.TransactionAmount = decimal.Parse(model.AmountReceived);
        //        obj.CustomerId = model.CustomerId;
        //        obj.DebitAccountId = model.DepositTo;
        //        obj.Description = model.Memo;
        //        obj.InputDate = DateTime.Parse(model.PaymentDate);
        //        obj.CreditAccountId = model.PaymentMethod;
        //        obj.TransactionCode = model.ReferenceNo;

        //        if (model.invoiceGridItem.Count > 0)
        //        {
        //            var childData = new List<TransactionDetailsModel>();
        //            foreach (var item in model.invoiceGridItem)
        //            {
        //                var childobj = new TransactionDetailsModel();
        //                childobj.SalesId = item.Id;
        //                childobj.NetAmount = decimal.Parse(item.Original_Amount);
        //                childobj.Amount = float.Parse(item.Payment);
        //                childobj.ComId = ComId ?? 0;

        //                childData.Add(childobj);

        //                var salesdata = saleRepository.All().Where(x => x.Id == item.Id).FirstOrDefault();
        //                salesdata.PaidAmount += decimal.Parse(item.Payment);

        //                saleRepository.Update(salesdata, salesdata.Id);


        //            }
        //            obj.TransactionDetails = childData;


        //        }

        //        _accountsDailyTransaction.Update(obj, obj.Id);

        //        if (model.invoiceGridItem.Count > 0 && obj.Id > 0)
        //        {
        //            foreach (var item in model.invoiceGridItem)
        //            {
        //                SalesPaymentModel salespayment = new SalesPaymentModel();
        //                salespayment.SalesId = item.Id;
        //                salespayment.Amount = decimal.Parse(item.Payment);
        //                salespayment.isPosted = false;
        //                salespayment.RowNo = 999;
        //                salespayment.TransactionId = obj.Id;

        //                salesPaymentRepository.Update(salespayment, salespayment.Id);
        //            }
        //        }

        //        return Json(new { error = false, message = "Update payment successfully", Id = obj.Id });
        //    }

        //}


        [HttpPost]
        [AllowAnonymous]
        public IActionResult AdjustAdvanceAmount([FromBody] List<TransactionDetailsModel> datalist)
        {
            foreach (var item in datalist)
            {
                var model = _accountsDailyTransaction.All().Where(x => x.Id == item.Id).FirstOrDefault();
                model.ReceivedAmount = model.ReceivedAmount + (double)item.NetAmount;
                model.LuserId = HttpContext.Session.GetInt32("UserId") ?? 0;
                _accountsDailyTransaction.Update(model, model.Id);
            }
            return Json(new { error = false, message = "Update Adv. Payment successfully" });
        }

        [HttpPost]
        [AllowAnonymous]
        public IActionResult UploadImageForPayment(List<IFormFile> files, [FromForm] string InvoiceId)
        {
            var ComId = HttpContext.Session.GetInt32("ComId");
            var invoice_info = _accountsDailyTransaction.Find(int.Parse(InvoiceId));

            string filePath = configuration.GetValue<string>("MediaManager:VoucherFilePath");
            var folderPath = Path.Combine(_webHostEnvironment.WebRootPath, filePath);
            Directory.CreateDirectory(folderPath); // Ensure the directory exists

            if (files != null && files.Count > 0)
            {
                foreach (var file in files)
                {
                    if (file.Length > 0)
                    {
                        var filename = invoice_info.Id.ToString() + '_' + invoice_info.ComId.ToString() + "_" + file.FileName;
                        var path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/Content/ReceivePayment", filename);

                        using (var stream = new FileStream(path, FileMode.Create))
                        {
                            file.CopyTo(stream);
                        }
                        // Update the invoice_info with each file uploaded
                        invoice_info.FilePath += $"/Content/ReceivePayment/{filename};";
                    }
                }
            }
            else
            {
                // Handle the case where no file was selected if necessary
                invoice_info.FilePath = invoice_info.FilePath;
            }

            _accountsDailyTransaction.Update(invoice_info, invoice_info.Id);

            return Json(new { status = "Files uploaded successfully." });
        }
        //[HttpPost]
        //[AllowAnonymous]
        //public IActionResult UploadImageForPayment(IFormFile file, [FromForm] string InvoiceId)
        //{
        //    var ComId = HttpContext.Session.GetInt32("ComId");
        //    var invoice_info = _accountsDailyTransaction.Find(int.Parse(InvoiceId));

        //    string filePath = configuration.GetValue<string>("MediaManager:VoucherFilePath");
        //    var folderPath = filePath + "/";
        //    var filename = string.Empty;

        //    if (file != null && file.Length > 0)
        //    {
        //        filename = invoice_info.Id + '_' + invoice_info.ComId + file.FileName;

        //        var path = Path.Combine(
        //            Directory.GetCurrentDirectory(), "wwwroot/Content/ReceivePayment",
        //            filename);

        //        using (var stream = new FileStream(path, FileMode.Create))
        //        {
        //            file.CopyTo(stream);
        //        }
        //        invoice_info.FilePath = $"/Content/ReceivePayment/{filename}";

        //        string serverFolder = Path.Combine(_webHostEnvironment.WebRootPath, folderPath);
        //        serverFolder += Guid.NewGuid().ToString() + "_" + file.FileName;
        //        file.CopyToAsync(new FileStream(serverFolder, FileMode.Create));
        //    }

        //    // Update the Purchaseinfo object even when no file was selected
        //    invoice_info.FilePath = invoice_info.FilePath;
        //    _accountsDailyTransaction.Update(invoice_info, invoice_info.Id);

        //    return Json(new { status = "File upload Successfully." });
        //}

        [AllowAnonymous]
        public IActionResult GetReceivePaymentList(string? duration, int? customerId, int page = 1, decimal size = 5, string searchquery = "")
        {
            try
            {
                var ComId = HttpContext.Session.GetInt32("ComId");
                var CurrentUserId = HttpContext.Session.GetInt32("UserId");

                var TransactionId = 0;

                SqlParameter[] sqlParameter1 = new SqlParameter[2];
                sqlParameter1[0] = new SqlParameter("@ComId", ComId);
                sqlParameter1[1] = new SqlParameter("@TransactionId", TransactionId);              
                Helper.ExecProc("[ReceiveApprovalStatus]", sqlParameter1);

                var paymentlist = _accountsDailyTransaction.All().Where(x => x.isSystem == false && x.isReceipt == true && (x.SalesId != null || x.CustomerId != null));


                if (searchquery?.Length > 1)
                {
                    paymentlist = paymentlist.Where(x =>
                    x.Customer.Name.ToLower().Contains(searchquery.ToLower()) ||
                    x.TransactionAmount.ToString().ToLower().Contains(searchquery.ToLower()) ||
                    x.DebitAccount.AccName.ToLower().Contains(searchquery.ToLower()));                  

                }


                if (!string.IsNullOrEmpty(duration))
                {
                    DateTime startDate, endDate;

                    if (duration == "Today")
                    {
                        startDate = DateTime.Today;
                        endDate = DateTime.Today.AddDays(1);
                    }
                    else if (duration == "This Month")
                    {
                        startDate = new DateTime(DateTime.Today.Year, DateTime.Today.Month, 1);
                        endDate = startDate.AddMonths(1);
                    }
                    else if (duration == "Last Month")
                    {
                        startDate = new DateTime(DateTime.Today.Year, DateTime.Today.Month, 1).AddMonths(-1);
                        endDate = new DateTime(DateTime.Today.Year, DateTime.Today.Month, 1);
                    }
                    else if (duration == "Last Year")
                    {
                        startDate = new DateTime(DateTime.Today.Year - 1, 1, 1);
                        endDate = new DateTime(DateTime.Today.Year, 1, 1);
                    }
                    else if (duration == "This Year")
                    {
                        startDate = new DateTime(DateTime.Today.Year, 1, 1);
                        endDate = new DateTime(DateTime.Today.Year + 1, 1, 1);
                    }
                    else if (duration == "Next Year")
                    {
                        startDate = new DateTime(DateTime.Today.Year + 1, 1, 1);
                        endDate = new DateTime(DateTime.Today.Year + 2, 1, 1);
                    }

                    else
                    {
                        // Handle other duration options if needed
                        startDate = DateTime.MinValue;
                        endDate = DateTime.Today;
                    }

                    paymentlist = paymentlist.Where(x => x.InputDate >= startDate && x.InputDate < endDate);
                }

                if (customerId > 0)
                {
                    paymentlist = paymentlist.Where(x => x.CustomerId == customerId);
                }

                decimal TotalRecordCount = paymentlist.Count();
                var PageCountabc = decimal.Parse((TotalRecordCount / size).ToString());
                var PageCount = Math.Ceiling(PageCountabc);

                decimal skip = (page - 1) * size;

                var query = from e in paymentlist
                        .Include(x => x.CreditAccount).Include(x => x.DebitAccount)
                        .Include(x => x.Customer).Include(x => x.Supplier).Include(x => x.Employee).Include(x => x.Member)
                        .Include(x => x.Sales).Include(x => x.Purchase).Include(x => x.SalesReturn).Include(x => x.PurchaseReturn).Include(x => x.Issue).Include(x => x.TransferIn).Include(x => x.TransferOut)
                        .Include(x => x.VoucherMain).ThenInclude(x => x.Acc_VoucherTypes)
                        .Include(x => x.vWarehouse)
                            select new
                            {
                                e.Id,
                                e.TransactionCode,
                                Description1 = e.Description,
                                e.TransactionAmount,
                                e.isPost,
                                e.IsDelete,
                                InputDate = e.InputDate,
                                InputDateString = e.InputDate.ToString("dd-MMM-yy"),
                                EntryUser = e.UserAccountList.Name,

                                CreditAccountName = e.CreditAccount.AccName,
                                DebitAccountName = e.DebitAccount.AccName,
                                ApprovalStage = e.ApprovalStage,
                                CustomerName1 = e.Customer.Name,
                                SupplierName = e.Supplier.SupplierName,
                                MemberName = e.Member.MembersNameEng,
                                EmployeeName = e.Employee.EmployeeName,
                                WarehouseName = e.vWarehouse != null ? e.vWarehouse.WhName : ""
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
                return Json(new { Success = 0, ex = ex.InnerException?.InnerException?.Message ?? ex.Message });
            }
        }
        #endregion


        #region Credit Note

        [OverridableAuthorize]
        public IActionResult AddCreditNote()
        {
            var ComId = HttpContext.Session.GetInt32("ComId");

            ViewBag.Customers = customerRepository.All().Where(p => p.ComId == ComId).Include(x => x.Currency)
                       .Select(x => new SelectListItem
                       {
                           Text = x.Name + '-' + x.Currency.CurrencyShortName,
                           Value = x.Id.ToString()
                       });

            ViewBag.WarehouseIdMain = _warehouseRepository.All().Where(x => x.ComId == ComId)
                            .Select(x => new SelectListItem
                            {
                                Text = x.WhName,
                                Value = x.Id.ToString()
                            });
            ViewBag.ActionType = "Create";

            var type = "Credit-Note";

            ViewBag.TransactionType = type;

            var products = productRepository.All().Where(p => p.ComId == ComId).ToList();

            SelectList productslist = new SelectList(products, "Id", "Name");
            ViewData["ProductList"] = productslist;

            var taxes = _mastersalestaxRepository.All().Where(f => f.ComId == ComId).ToList();
            SelectList taxList = new SelectList(taxes, "Id", "Name");
            ViewData["TaxList"] = taxList;

            var agency = _agencyRepository.All();
            var data = agency.ToList();
            SelectList agencyList = new SelectList(data, "Id", "AgencyName");

            ViewData["AgencyList"] = agencyList;

            var taxCalculation = new List<SelectListItem>
    {
        new SelectListItem { Text = "Exclusive of Tax", Value = "exclusive" },
        new SelectListItem { Text = "Inclusive of Tax", Value = "inclusive" },
        new SelectListItem { Text = "Out of scope of Tax", Value = "outscope" }
    };

            var estimateStatus = new List<SelectListItem>
    {
        new SelectListItem { Text = "Pending", Value = "Pending" },
        new SelectListItem { Text = "Accepted", Value = "Accepted" },
        new SelectListItem { Text = "Closed", Value = "Closed" },
        new SelectListItem { Text = "Rejected", Value = "Rejected" }
    };

            var estimateStatusList = new SelectList(estimateStatus, "Value", "Text");
            ViewData["EstimateStatus"] = estimateStatusList;

            var taxCalculationList = new SelectList(taxCalculation, "Value", "Text");

            ViewData["CategoryList"] = accountHeadRepository.GetCashBankHeadForDropDown();

            ViewData["AmountsAre"] = taxCalculationList;

            ViewBag.Id = 0;
            return View("AddInvoiceQB");
        }

        [OverridableAuthorize]
        [HttpGet]
        public IActionResult EditCreditNote(int id)
        {
            try
            {

                var errors = ModelState.Where(x => x.Value.Errors.Any())
              .Select(x => new { x.Key, x.Value.Errors });

                var ComId = HttpContext.Session.GetInt32("ComId");

                ViewBag.Customers = customerRepository.All().Where(p => p.ComId == ComId).Include(x => x.Currency)
                           .Select(x => new SelectListItem
                           {
                               Text = x.Name + '-' + x.Currency.CurrencyShortName,
                               Value = x.Id.ToString()
                           });
                ViewBag.WarehouseIdMain = _warehouseRepository.All().Where(x => x.ComId == ComId)
                               .Select(x => new SelectListItem
                               {
                                   Text = x.WhName,
                                   Value = x.Id.ToString()
                               });
                var taxes = _mastersalestaxRepository.All().Where(f => f.ComId == ComId).ToList();
                SelectList taxList = new SelectList(taxes, "Id", "Name");
                ViewData["TaxList"] = taxList;

                var type = "Credit-note";


                ViewBag.TransactionType = type;
                ViewBag.ActionType = "Edit";
                ViewBag.Id = id;
                var products = productRepository.All().Where(p => p.ComId == ComId).ToList();

                SelectList productslist = new SelectList(products, "Id", "Name");
                ViewData["ProductList"] = productslist;

                var agency = _agencyRepository.All();
                var data = agency.ToList();
                SelectList agencyList = new SelectList(data, "Id", "AgencyName");

                ViewData["AgencyList"] = agencyList;
                var data1 = saleRepository.All().Where(x => x.Id == id).FirstOrDefault();

                var estimateStatus = new List<SelectListItem>
            {
                new SelectListItem { Text = "Pending", Value = "Pending" },
                new SelectListItem { Text = "Accepted", Value = "Accepted" },
                new SelectListItem { Text = "Closed", Value = "Closed" },
                new SelectListItem { Text = "Rejected", Value = "Rejected" }
            };

                var estimateStatusList = new SelectList(estimateStatus, "Value", "Text");
                ViewData["EstimateStatus"] = estimateStatusList;

                var taxCalculation = new List<SelectListItem>
            {
                new SelectListItem { Text = "Exclusive of Tax", Value = "exclusive" },
                new SelectListItem { Text = "Inclusive of Tax", Value = "inclusive" },
                new SelectListItem { Text = "Out of scope of Tax", Value = "outscope" }
            };

                var taxCalculationList = new SelectList(taxCalculation, "Value", "Text");

                ViewData["AmountsAre"] = taxCalculationList;
                ViewData["CategoryList"] = accountHeadRepository.GetCashBankHeadForDropDown();

                return View("AddInvoiceQB");

            }
            catch (Exception ex)
            {

                throw ex;
            }

        }

        [AllowAnonymous]
        public IActionResult CreateCreditNoteQB()
        {
            var ComId = HttpContext.Session.GetInt32("ComId");

            ViewBag.Customers = customerRepository.All().Where(p => p.ComId == ComId)
                       .Select(x => new SelectListItem
                       {
                           Text = x.Name + '-' + x.Currency.CurrencyShortName,
                           Value = x.Id.ToString()
                       });
            ViewBag.WarehouseIdMain = _warehouseRepository.All().Where(x => x.ComId == ComId)
                           .Select(x => new SelectListItem
                           {
                               Text = x.WhName,
                               Value = x.Id.ToString()
                           });
            ViewBag.ActionType = "Create";

            ViewBag.TransactionType = "Credit-note";

            var products = productRepository.All().Where(p => p.ComId == ComId).ToList();

            SelectList productslist = new SelectList(products, "Id", "Name");
            ViewData["ProductList"] = productslist;

            var taxes = _mastersalestaxRepository.All().Where(f => f.ComId == ComId).ToList();
            SelectList taxList = new SelectList(taxes, "Id", "Name");
            ViewData["TaxList"] = taxList;

            var agency = _agencyRepository.All();
            var data = agency.ToList();
            SelectList agencyList = new SelectList(data, "Id", "AgencyName");

            ViewData["AgencyList"] = agencyList;
            ViewBag.Id = 0;

            var taxCalculation = new List<SelectListItem>
            {
                new SelectListItem { Text = "Exclusive of Tax", Value = "exclusive" },
                new SelectListItem { Text = "Inclusive of Tax", Value = "inclusive" },
                new SelectListItem { Text = "Out of scope of Tax", Value = "outscope" }
            };

            var taxCalculationList = new SelectList(taxCalculation, "Value", "Text");

            ViewData["AmountsAre"] = taxCalculationList;

            return View("CreateInvoiceQB");
        }

        [AllowAnonymous]
        public IActionResult EditCreditNoteQB(int id)
        {

            var ComId = HttpContext.Session.GetInt32("ComId");

            ViewBag.Customers = customerRepository.All().Where(p => p.ComId == ComId)
                       .Select(x => new SelectListItem
                       {
                           Text = x.Name,
                           Value = x.Id.ToString()
                       });
            ViewBag.ActionType = "Edit";

            ViewBag.WarehouseIdMain = _warehouseRepository.All().Where(x => x.ComId == ComId)
                           .Select(x => new SelectListItem
                           {
                               Text = x.WhName,
                               Value = x.Id.ToString()
                           });

            ViewBag.TransactionType = "Credit-note";

            var products = productRepository.All().Where(p => p.ComId == ComId).ToList();

            SelectList productslist = new SelectList(products, "Id", "Name");
            ViewData["ProductList"] = productslist;

            var taxes = _mastersalestaxRepository.All().Where(f => f.ComId == ComId).ToList();
            SelectList taxList = new SelectList(taxes, "Id", "Name");
            ViewData["TaxList"] = taxList;

            var agency = _agencyRepository.All();
            var data = agency.ToList();
            SelectList agencyList = new SelectList(data, "Id", "AgencyName");

            ViewData["AgencyList"] = agencyList;
            ViewBag.Id = id;

            var taxCalculation = new List<SelectListItem>
            {
                new SelectListItem { Text = "Exclusive of Tax", Value = "exclusive" },
                new SelectListItem { Text = "Inclusive of Tax", Value = "inclusive" },
                new SelectListItem { Text = "Out of scope of Tax", Value = "outscope" }
            };

            var taxCalculationList = new SelectList(taxCalculation, "Value", "Text");

            ViewData["AmountsAre"] = taxCalculationList;

            return View("CreateInvoiceQB");
        }

        [HttpGet]
        [AllowAnonymous]
        public IActionResult CustomerWiseInvoiceData(int customerid)
        {

            var ComId = HttpContext.Session.GetInt32("ComId");
            string queryname = "UpdateSalesReturnStatus";
            var viewquary = $"Exec {queryname}  '" + ComId + "','" + customerid + "' ";
            Console.WriteLine(viewquary);

            SqlParameter[] parameters = new SqlParameter[1];
            parameters[0] = new SqlParameter("@ComId", ComId);

            var datasetabc = new System.Data.DataSet();
            datasetabc = Helper.ExecProcMapDS(queryname, parameters);

            var salesData = saleRepository.All().Include(x => x.DocTypeList).Where(x => x.CustomerId == customerid && x.ReturnStatus != 1 && x.DocTypeList.DocType == "Invoice" && x.DocTypeList.DocFor == "Sales").ToList();

            if (salesData != null && salesData.Count >= 0)
            {
                var data = new List<invoiceGridItem>();
                foreach (var item in salesData)
                {
                    var singledata = new invoiceGridItem();
                    var openBlnc = item.Total - (double)item.PaidAmount;
                    var descp = "Invoice #" + item.SaleCode;

                    singledata.Id = item.Id;
                    singledata.DueDate = item.DueDate;
                    singledata.SalesDate = item.SalesDate;
                    singledata.Original_Amount = item.Total;
                    singledata.Open_Balance = openBlnc;
                    singledata.Description = descp;
                    singledata.CheckBox = false;
                    singledata.SalesCode = item.SaleCode;

                    data.Add(singledata);
                }
                return Json(new { Success = 1, Data = data, ex = "Data Loaded Successfully" });
            }
            return Json(new { Success = 2, ex = "Data Loaded Failed" });
        }

        [AllowAnonymous]
        [HttpPost]
        public IActionResult CreditNoteCreation([FromBody] SalesModelVM model)
        {
            try
            {

                var errors = ModelState.Where(x => x.Value.Errors.Any())
               .Select(x => new { x.Key, x.Value.Errors });

                string format = "dd-MMM-yyyy"; // The format of the input date string
                var ComId = HttpContext.Session.GetInt32("ComId");
                var UserId = HttpContext.Session.GetInt32("UserId");
                DateTime dateTime;

                if (DateTime.TryParseExact(model.SalesDate, format, CultureInfo.InvariantCulture, DateTimeStyles.None, out dateTime))
                {
                    var temp = dateTime;
                    dateTime = temp;
                }
                if (model.Id == 0)
                {
                    DateTime now = DateTime.Now;
                    string uniqueNumber = "CN-" + DateTime.Now.ToString("ddMMyyHHmmssfff");
                    var model1 = new SalesModel();
                    var doctypeId = _docTypeRepository.All().Where(x => x.DocType == "Credit Note").Select(x => x.Id).FirstOrDefault();
                    var docPrefix = docPrefixRepository.All().Where(x => x.ComId == ComId && x.DocTypeId == doctypeId).FirstOrDefault();
                    if (docPrefix != null)
                    {
                        uniqueNumber = GetSalesCode(doctypeId);
                    }

                    model1.ComId = model.ComId;
                    model1.LuserId = model.LuserId;
                    model1.LuserId = UserId.GetValueOrDefault();
                    model1.Id = model.Id;
                    model1.CustomerId = int.Parse(model.CustomerId);
                    model1.EmailId = model.EmailId;
                    model1.PrimaryAddress = model.PrimaryAddress;
                    model1.SalesDate = dateTime;
                    model1.TrackingNo = model.TrackingNo;
                    model1.SaleCode = uniqueNumber;
                    model1.MessageInvoice = model.MessageInvoice;
                    model1.MessageStatement = model.MessageStatement;
                    model1.CurrencyId = model.CurrencyId;
                    model1.CurrencyRate = model.CurrencyRate;
                    model1.FiscalMonthId = model.FiscalMonthId;
                    model1.Total = model.Total;
                    model1.SubTotal = model.SubTotal;
                    model1.TotalVat = (decimal)model.TotalVat;
                    model1.Shipping = model.Shipping;
                    model1.ShippingTax = model.ShippingTax;
                    model1.AmountsAre = model.AmountsAre;
                    model1.NetAmount = (decimal)model.Total;
                    model1.DocTypeId = doctypeId;
                    model1.WarehouseIdMain = model.WarehouseIdMain;
                    model1.IsRecurring = model.IsRecurring;
                    model1.StatusRemarks = "Applied";
                    var custname = customerRepository.Find(model1.CustomerId);
                    model1.CustomerName = custname.Name;
                    List<SalesItemsModel> ls = new List<SalesItemsModel>();
                    List<SalesProductTaxModel> lt = new List<SalesProductTaxModel>();

                    if (model.SalesItemVM.Count > 0)
                    {

                        foreach (var item in model.SalesItemVM)
                        {
                            var salesitem = new SalesItemsModel();
                            if (item.ProductId != "" && item.ServiceDate != null)
                            {
                                var updateItem = saleItemRepository.Find(item.Id);

                                var temp = saleItemRepository.All().Where(x => x.SalesItemsId == item.Id).ToList();
                                var sum = 0;
                                if (temp != null && temp.Count > 0)
                                {
                                    foreach (var y in temp)
                                    {
                                        sum = (int)(sum + y.Quantity);
                                    }
                                }
                                updateItem.Quantity = updateItem.Quantity - sum;

                                if (updateItem.Quantity >= int.Parse(item.Quantity))
                                {
                                    //updateItem.Quantity = updateItem.Quantity - int.Parse(item.Quantity);
                                    //saleItemRepository.Update(updateItem, updateItem.Id);

                                    salesitem.Id = 0;
                                    salesitem.ServiceDate = DateTime.Parse(item.ServiceDate);
                                    salesitem.ProductId = int.Parse(item.ProductId);
                                    salesitem.Description = item.Description;
                                    salesitem.Quantity = double.Parse(item.Quantity);
                                    salesitem.Price = float.Parse(item.Price);
                                    salesitem.SecondaryPrice = float.Parse(item.SecondaryPrice);
                                    salesitem.CostPrice = float.Parse(item.CostPrice);
                                    salesitem.DefaultPrice = float.Parse(item.DefaultPrice);
                                    salesitem.Amount = float.Parse(item.Amount);
                                    salesitem.IndDiscount = float.Parse(item.IndDiscount);
                                    salesitem.ComId = ComId ?? 0;
                                    salesitem.LuserId = UserId ?? 0;
                                    salesitem.LuserIdUpdate = UserId ?? 0;
                                    if (item.Id > 0)
                                    {
                                        salesitem.SalesItemsId = item.Id;
                                    }
                                    salesitem.WarehouseId = item.WarehouseId;
                                    salesitem.WHName = item.WHName;
                                    if (item.MasterTaxId == null || item.MasterTaxId == "0")
                                    {
                                        salesitem.MasterTaxId = 0;
                                        salesitem.MasterTaxName = "";
                                    }
                                    else
                                    {
                                        salesitem.MasterTaxId = int.Parse(item.MasterTaxId);
                                        var mastertaxname = _mastersalestaxRepository.Find(salesitem.MasterTaxId);
                                        salesitem.MasterTaxName = mastertaxname.Name;
                                    }


                                    var productname = productRepository.Find(salesitem.ProductId);
                                    salesitem.Name = productname.Name;
                                    salesitem.PrimaryUnitId = item.PrimaryUnitId;
                                    salesitem.SecondaryUnitId = item.SecondaryUnitId;
                                    salesitem.ConversionRate = item.ConversionRate;
                                    salesitem.InputQuantity = item.InputQuantity;
                                    salesitem.Unit = item.Unit;
                                    ls.Add(salesitem);
                                }

                            }
                        }

                    }
                    if (model.SalesProductTaxVM.Count > 0)
                    {

                        foreach (var item in model.SalesProductTaxVM)
                        {
                            var salesitem = new SalesProductTaxModel();
                            salesitem.Id = 0;
                            salesitem.Nickname = item.Nickname;
                            salesitem.IsSum = item.IsSum;
                            salesitem.Amount = float.Parse(item.Amount);
                            salesitem.TotalAmount = float.Parse(item.TotalAmount);
                            salesitem.TaxId = item.TaxId;
                            salesitem.ComId = ComId ?? 0;
                            salesitem.LuserId = UserId ?? 0;
                            salesitem.LuserIdUpdate = UserId ?? 0;


                            lt.Add(salesitem);
                        }

                    }
                    List<SalesTagModel> ltag = new List<SalesTagModel>();
                    if (model.SalesTags.Count > 0)
                    {
                        foreach (var item in model.SalesTags)
                        {
                            var salesTags = new SalesTagModel();
                            var newtag = new TagsModel();

                            if (item.Any(char.IsLetter))
                            {
                                newtag.ComId = ComId ?? 0;
                                newtag.TagsType = "G";
                                newtag.TagShortName = item;
                                newtag.TagName = item;

                                tagsRepository.Insert(newtag);

                                salesTags.TagsId = newtag.Id;
                                salesTags.ComId = ComId ?? 0;
                                ltag.Add(salesTags);
                            }
                            else
                            {
                                salesTags.TagsId = int.Parse(item);
                                salesTags.ComId = ComId ?? 0;
                                ltag.Add(salesTags);
                            }

                        }
                    }
                    if (ltag != null)
                    {
                        model1.SalesTags = ltag;
                    }
                    if (ls != null)
                    {
                        model1.Items = ls;
                    }
                    if (lt != null)
                    {
                        model1.SalesProductTax = lt;
                    }
                    saleRepository.Insert(model1);
                    return Json(new { error = false, message = "Credit saved successfully", Id = model1.Id });

                }
                else
                {
                    DateTime now = DateTime.Now;
                    string uniqueNumber = "CN-" + DateTime.Now.ToString("ddMMyyHHmmssfff");
                    var model1 = new SalesModel();
                    var doctypeId = _docTypeRepository.All().Where(x => x.DocType == "Credit Note").Select(x => x.Id).FirstOrDefault();
                    var oldModel = saleRepository.All().Where(x => x.Id == model.Id).FirstOrDefault();

                    model1.Id = model.Id;
                    model1.LuserId = oldModel.LuserId;
                    model1.LuserIdUpdate = UserId;
                    model1.ComId = oldModel.ComId;
                    model1.CustomerId = int.Parse(model.CustomerId);
                    model1.EmailId = model.EmailId;
                    model1.PrimaryAddress = model.PrimaryAddress;
                    model1.SalesDate = DateTime.Parse(model.SalesDate);
                    model1.TrackingNo = model.TrackingNo;
                    model1.SaleCode = oldModel.SaleCode;
                    model1.CurrencyId = model.CurrencyId;
                    model1.CurrencyRate = model.CurrencyRate;
                    model1.MessageInvoice = model.MessageInvoice;
                    model1.MessageStatement = model.MessageStatement;
                    model1.Total = model.Total;
                    model1.FiscalMonthId = model.FiscalMonthId;
                    model1.SubTotal = model.SubTotal;
                    model1.TotalVat = (decimal)model.TotalVat;
                    model1.Shipping = model.Shipping;
                    model1.ShippingTax = model.ShippingTax;
                    model1.AmountsAre = model.AmountsAre;
                    model1.NetAmount = (decimal)model.Total;
                    model1.StatusRemarks = "Applied";
                    model1.DocTypeId = doctypeId;
                    model1.WarehouseIdMain = model.WarehouseIdMain;
                    model1.IsRecurring = model.IsRecurring;
                    model1.FileName = oldModel.FileName;

                    var custname = customerRepository.Find(model1.CustomerId);
                    model1.CustomerName = custname.Name;
                    List<SalesItemsModel> ls = new List<SalesItemsModel>();
                    List<SalesProductTaxModel> lt = new List<SalesProductTaxModel>();
                    if (model.SalesItemVM.Count > 0)
                    {

                        foreach (var item in model.SalesItemVM)
                        {

                            var salesitem = new SalesItemsModel();
                            if (item.ProductId != "" && item.ServiceDate != null)
                            {
                                var updateItem = saleItemRepository.Find(item.Id);

                                var temp = saleItemRepository.All().Where(x => x.SalesItemsId == item.Id).ToList();
                                var returnId = saleItemRepository.All().Where(x => x.Id == item.Id).FirstOrDefault();

                                salesitem.SalesItemsId = returnId.SalesItemsId;

                                saleItemRepository.Delete(returnId);
                                var sum = 0;
                                if (temp != null && temp.Count > 0)
                                {
                                    foreach (var y in temp)
                                    {
                                        sum = (int)(sum + y.Quantity);
                                    }
                                }
                                updateItem.Quantity = updateItem.Quantity - sum;

                                if (updateItem.Quantity >= int.Parse(item.Quantity))
                                {

                                    salesitem.Id = 0;
                                    salesitem.ServiceDate = DateTime.Parse(item.ServiceDate);
                                    salesitem.ProductId = int.Parse(item.ProductId);
                                    salesitem.Description = item.Description;
                                    salesitem.Quantity = double.Parse(item.Quantity);
                                    salesitem.Price = float.Parse(item.Price);
                                    salesitem.SecondaryPrice = float.Parse(item.SecondaryPrice);
                                    salesitem.CostPrice = float.Parse(item.CostPrice);
                                    salesitem.DefaultPrice = float.Parse(item.DefaultPrice);
                                    salesitem.Amount = float.Parse(item.Amount);
                                    salesitem.IndDiscount = float.Parse(item.IndDiscount);
                                    salesitem.ComId = ComId ?? 0;
                                    salesitem.LuserId = UserId ?? 0;
                                    salesitem.LuserIdUpdate = UserId ?? 0;
                                    salesitem.SalesId = model.Id;
                                    salesitem.WarehouseId = item.WarehouseId;
                                    salesitem.WHName = item.WHName;
                                    if (item.MasterTaxId == null || item.MasterTaxId == "0")
                                    {
                                        salesitem.MasterTaxId = 0;
                                        salesitem.MasterTaxName = "";
                                    }
                                    else
                                    {
                                        salesitem.MasterTaxId = int.Parse(item.MasterTaxId);
                                        var mastertaxname = _mastersalestaxRepository.Find(salesitem.MasterTaxId);
                                        salesitem.MasterTaxName = mastertaxname.Name;
                                    }


                                    var productname = productRepository.Find(salesitem.ProductId);
                                    salesitem.Name = productname.Name;
                                    salesitem.PrimaryUnitId = item.PrimaryUnitId;
                                    salesitem.SecondaryUnitId = item.SecondaryUnitId;
                                    salesitem.ConversionRate = item.ConversionRate;
                                    salesitem.InputQuantity = item.InputQuantity;
                                    salesitem.Unit = item.Unit;
                                    saleItemRepository.Insert(salesitem);
                                }

                            }
                        }

                    }
                    if (model.SalesProductTaxVM.Count > 0)
                    {

                        foreach (var item in model.SalesProductTaxVM)
                        {
                            var salesitem = new SalesProductTaxModel();
                            salesitem.Id = item.Id;
                            salesitem.Nickname = item.Nickname;
                            salesitem.IsSum = item.IsSum;
                            salesitem.Amount = float.Parse(item.Amount);
                            salesitem.TotalAmount = float.Parse(item.TotalAmount);
                            salesitem.TaxId = item.TaxId;
                            salesitem.ComId = ComId ?? 0;
                            salesitem.LuserId = UserId ?? 0;
                            salesitem.LuserIdUpdate = UserId ?? 0;
                            salesitem.SalesId = model.Id;


                            salesProductTaxRepository.Update(salesitem, salesitem.Id);
                        }

                    }
                    var tagsData = salesTagRepository.All().Where(x => x.SalesId == model1.Id).ToList();
                    if (tagsData.Count > 0)
                    {
                        foreach (var tag in tagsData)
                        {
                            salesTagRepository.Delete(tag);
                        }
                    }

                    if (model.SalesTags.Count > 0)
                    {
                        foreach (var item in model.SalesTags)
                        {
                            var salesTags = new SalesTagModel();
                            var newtag = new TagsModel();

                            if (item.Any(char.IsLetter))
                            {
                                newtag.ComId = ComId ?? 0;
                                newtag.TagsType = "G";
                                newtag.TagShortName = item;
                                newtag.TagName = item;

                                tagsRepository.Insert(newtag);

                                salesTags.TagsId = newtag.Id;
                                salesTags.SalesId = model1.Id;
                                salesTags.ComId = ComId ?? 0;
                                salesTagRepository.Insert(salesTags);
                            }
                            else
                            {
                                salesTags.TagsId = int.Parse(item);
                                salesTags.ComId = ComId ?? 0;
                                salesTags.SalesId = model1.Id;
                                salesTagRepository.Insert(salesTags);
                            }

                        }
                    }
                    if (ls != null)
                    {
                        model1.Items = ls;
                    }
                    if (lt != null)
                    {
                        model1.SalesProductTax = lt;
                    }
                    saleRepository.Update(model1, model1.Id);
                    return Json(new { error = false, message = "Credit Note Updated successfully", Id = model1.Id });

                }
                return View(model);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        [HttpGet]
        [AllowAnonymous]
        public IActionResult GetInvoiceDetailsForCredit(int id)
        {
            try
            {

                var data = saleRepository.All().Where(x => x.Id == id).FirstOrDefault();
                var item = saleItemRepository.All().Where(x => x.SalesId == id && x.ItemsReturnStatus != 1).ToList();
                foreach (var x in item)
                {
                    int itemId = x.Id;
                    //Console.WriteLine(itemId);
                    var temp = saleItemRepository.All().Where(x => x.SalesItemsId == itemId).ToList();
                    var sum = 0;
                    if (temp != null && temp.Count > 0)
                    {
                        foreach (var y in temp)
                        {
                            sum = (int)(sum + y.Quantity);
                        }
                    }
                    x.Quantity = x.Quantity - sum;
                }
                var productTax = salesProductTaxRepository.All().Where(x => x.SalesId == id).ToList();
                data.Items = item;
                data.SalesProductTax = productTax;
                return Json(new { Success = 1, data = data, ex = "Data Loaded Successfully" });

            }
            catch (Exception ex)
            {

                throw ex;
            }
        }


        [HttpGet]
        [AllowAnonymous]
        public IActionResult GetCreditNoteDetails(int id)
        {
            var data = saleRepository.All().Where(x => x.Id == id).FirstOrDefault();
            var childData = saleItemRepository.All().Where(x => x.SalesId == id).ToList();
            var productTax = salesProductTaxRepository.All().Where(x => x.SalesId == id).ToList();
            data.Items = childData;
            data.SalesProductTax = productTax;
            return Json(new { Success = 1, data = data, ex = "Data Loaded Successfully" });
        }

        [HttpGet]
        [AllowAnonymous]
        public IActionResult GetCreditNoteDetails2Copy(int id)
        {
            var salesData = saleRepository.All().Where(x => x.Id == id).Include(x => x.Items).Include(x => x.SalesProductTax).FirstOrDefault();
            TimeSpan dueDateDiff = salesData.DueDate - salesData.SalesDate;
            if (dueDateDiff.TotalDays > 0)
            {
                salesData.DueDate = DateTime.Now.AddDays(dueDateDiff.TotalDays);
            }

            salesData.Id = 0;
            salesData.IsRecurring = false;
            salesData.SalesDate = DateTime.Now;
            salesData.ShippingDate = DateTime.Now;
            foreach (var Childitem in salesData.Items)
            {
                Childitem.Id = 0;
                Childitem.SalesId = 0;
                Childitem.ServiceDate = DateTime.Now;
            }
            if (salesData.SalesTags != null)
            {
                foreach (var tag in salesData.SalesTags)
                {
                    tag.Id = 0;
                    tag.SalesId = 0;
                }
            }
            if (salesData.SalesProductTax != null)
            {
                foreach (var tax in salesData.SalesProductTax)
                {
                    tax.Id = 0;
                    tax.SalesId = 0;
                }
            }

            return Json(new { Success = 1, data = salesData, ex = "Data Loaded Successfully" });
        }
        #endregion



        #region Estimate

        [OverridableAuthorize]
        public IActionResult AddEstimate()
        {
            var ComId = HttpContext.Session.GetInt32("ComId");

            ViewBag.Customers = customerRepository.All().Where(p => p.ComId == ComId).Include(x => x.Currency)
                       .Select(x => new SelectListItem
                       {
                           Text = x.Name + '-' + x.Currency.CurrencyShortName,
                           Value = x.Id.ToString()
                       });

            ViewBag.WarehouseIdMain = _warehouseRepository.All().Where(x => x.ComId == ComId)
                            .Select(x => new SelectListItem
                            {
                                Text = x.WhName,
                                Value = x.Id.ToString()
                            });
            ViewBag.ActionType = "Create";

            var type = "Estimate";

            ViewBag.TransactionType = type;

            var products = productRepository.All().Where(p => p.ComId == ComId).ToList();

            SelectList productslist = new SelectList(products, "Id", "Name");
            ViewData["ProductList"] = productslist;

            var taxes = _mastersalestaxRepository.All().Where(f => f.ComId == ComId).ToList();
            SelectList taxList = new SelectList(taxes, "Id", "Name");
            ViewData["TaxList"] = taxList;

            var agency = _agencyRepository.All();
            var data = agency.ToList();
            SelectList agencyList = new SelectList(data, "Id", "AgencyName");

            ViewData["AgencyList"] = agencyList;

            var taxCalculation = new List<SelectListItem>
            {
                new SelectListItem { Text = "Exclusive of Tax", Value = "exclusive" },
                new SelectListItem { Text = "Inclusive of Tax", Value = "inclusive" },
                new SelectListItem { Text = "Out of scope of Tax", Value = "outscope" }
            };

            var estimateStatus = new List<SelectListItem>
            {
                new SelectListItem { Text = "Pending", Value = "Pending" },
                new SelectListItem { Text = "Accepted", Value = "Accepted" },
                new SelectListItem { Text = "Closed", Value = "Closed" },
                new SelectListItem { Text = "Rejected", Value = "Rejected" }
            };

            var estimateStatusList = new SelectList(estimateStatus, "Value", "Text");
            ViewData["EstimateStatus"] = estimateStatusList;

            var taxCalculationList = new SelectList(taxCalculation, "Value", "Text");

            ViewData["CategoryList"] = accountHeadRepository.GetCashBankHeadForDropDown();

            ViewData["AmountsAre"] = taxCalculationList;

            ViewBag.Id = 0;
            return View("AddInvoiceQB");
        }

        [OverridableAuthorize]
        [HttpGet]
        public IActionResult EditEstimate(int id)
        {
            try
            {

                var errors = ModelState.Where(x => x.Value.Errors.Any())
              .Select(x => new { x.Key, x.Value.Errors });

                var ComId = HttpContext.Session.GetInt32("ComId");

                ViewBag.Customers = customerRepository.All().Where(p => p.ComId == ComId).Include(x => x.Currency)
                           .Select(x => new SelectListItem
                           {
                               Text = x.Name + '-' + x.Currency.CurrencyShortName,
                               Value = x.Id.ToString()
                           });
                ViewBag.WarehouseIdMain = _warehouseRepository.All().Where(x => x.ComId == ComId)
                               .Select(x => new SelectListItem
                               {
                                   Text = x.WhName,
                                   Value = x.Id.ToString()
                               });
                var taxes = _mastersalestaxRepository.All().Where(f => f.ComId == ComId).ToList();
                SelectList taxList = new SelectList(taxes, "Id", "Name");
                ViewData["TaxList"] = taxList;

                var type = "Estimate";


                ViewBag.TransactionType = type;
                ViewBag.ActionType = "Edit";
                ViewBag.Id = id;
                var products = productRepository.All().Where(p => p.ComId == ComId).ToList();

                SelectList productslist = new SelectList(products, "Id", "Name");
                ViewData["ProductList"] = productslist;

                var agency = _agencyRepository.All();
                var data = agency.ToList();
                SelectList agencyList = new SelectList(data, "Id", "AgencyName");

                ViewData["AgencyList"] = agencyList;
                var data1 = saleRepository.All().Where(x => x.Id == id).FirstOrDefault();

                var estimateStatus = new List<SelectListItem>
            {
                new SelectListItem { Text = "Pending", Value = "Pending" },
                new SelectListItem { Text = "Accepted", Value = "Accepted" },
                new SelectListItem { Text = "Closed", Value = "Closed" },
                new SelectListItem { Text = "Rejected", Value = "Rejected" }
            };

                var estimateStatusList = new SelectList(estimateStatus, "Value", "Text");
                ViewData["EstimateStatus"] = estimateStatusList;

                var taxCalculation = new List<SelectListItem>
            {
                new SelectListItem { Text = "Exclusive of Tax", Value = "exclusive" },
                new SelectListItem { Text = "Inclusive of Tax", Value = "inclusive" },
                new SelectListItem { Text = "Out of scope of Tax", Value = "outscope" }
            };

                var taxCalculationList = new SelectList(taxCalculation, "Value", "Text");

                ViewData["AmountsAre"] = taxCalculationList;
                ViewData["CategoryList"] = accountHeadRepository.GetCashBankHeadForDropDown();

                return View("AddInvoiceQB");

            }
            catch (Exception ex)
            {

                throw ex;
            }

        }

        [AllowAnonymous]
        public IActionResult CreateEstimateQB()
        {
            var ComId = HttpContext.Session.GetInt32("ComId");

            ViewBag.Customers = customerRepository.All().Where(p => p.ComId == ComId)
                       .Select(x => new SelectListItem
                       {
                           Text = x.Name + '-' + x.Currency.CurrencyShortName,
                           Value = x.Id.ToString()
                       });
            ViewBag.ActionType = "Create";

            ViewBag.WarehouseIdMain = _warehouseRepository.All().Where(x => x.ComId == ComId)
                           .Select(x => new SelectListItem
                           {
                               Text = x.WhName,
                               Value = x.Id.ToString()
                           });

            ViewBag.TransactionType = "Estimate";

            var products = productRepository.All().Where(p => p.ComId == ComId).ToList();

            SelectList productslist = new SelectList(products, "Id", "Name");
            ViewData["ProductList"] = productslist;

            var taxes = _mastersalestaxRepository.All().Where(f => f.ComId == ComId).ToList();
            SelectList taxList = new SelectList(taxes, "Id", "Name");
            ViewData["TaxList"] = taxList;

            var taxCalculation = new List<SelectListItem>
            {
                new SelectListItem { Text = "Exclusive of Tax", Value = "exclusive" },
                new SelectListItem { Text = "Inclusive of Tax", Value = "inclusive" },
                new SelectListItem { Text = "Out of scope of Tax", Value = "outscope" }
            };

            var taxCalculationList = new SelectList(taxCalculation, "Value", "Text");

            ViewData["AmountsAre"] = taxCalculationList;

            ViewBag.Id = 0;
            return View("CreateInvoiceQB");
        }

        [AllowAnonymous]
        [HttpPost]
        public IActionResult EstimateCreation([FromBody] SalesModelVM model)
        {
            try
            {

                var errors = ModelState.Where(x => x.Value.Errors.Any())
              .Select(x => new { x.Key, x.Value.Errors });

                string format = "dd-MMM-yyyy"; // The format of the input date string
                var ComId = HttpContext.Session.GetInt32("ComId");
                var UserId = HttpContext.Session.GetInt32("UserId");
                DateTime dateTime;

                if (DateTime.TryParseExact(model.SalesDate, format, CultureInfo.InvariantCulture, DateTimeStyles.None, out dateTime))
                {
                    var temp = dateTime;
                    dateTime = temp;
                }
                if (model.Id == 0)
                {
                    DateTime now = DateTime.Now;
                    string uniqueNumber = "ES-" + DateTime.Now.ToString("ddMMyyHHmmssfff");
                    var model1 = new SalesModel();
                    var doctypeId = _docTypeRepository.All().Where(x => x.DocType == "Estimate").Select(x => x.Id).FirstOrDefault();
                    var docPrefix = docPrefixRepository.All().Where(x => x.ComId == ComId && x.DocTypeId == doctypeId).FirstOrDefault();
                    if (docPrefix != null)
                    {
                        uniqueNumber = GetSalesCode(doctypeId);
                    }

                    model1.ComId = model.ComId;
                    model1.LuserId = model.LuserId;
                    model1.Id = model.Id;
                    model1.CustomerId = int.Parse(model.CustomerId);
                    model1.EmailId = model.EmailId;
                    model1.PrimaryAddress = model.PrimaryAddress;
                    model1.SalesDate = dateTime;
                    model1.DueDate = DateTime.Parse(model.DueDate);
                    model1.ShippingVia = model.ShippingVia;
                    model1.ShippingDate = DateTime.Parse(model.ShippingDate);
                    model1.TrackingNo = model.TrackingNo;
                    model1.SaleCode = uniqueNumber;
                    model1.CurrencyRate = model.CurrencyRate;
                    model1.SecoundaryAddress = model.SecoundaryAddress;
                    model1.ShippingTo = model.ShippingTo;
                    model1.MessageInvoice = model.MessageInvoice;
                    model1.MessageStatement = model.MessageStatement;
                    model1.Total = model.Total;
                    model1.SubTotal = model.SubTotal;
                    model1.StatusRemarks = model.EstimateStatus;
                    model1.StatusBy = model.StatusBy;
                    model1.StatusDate = model.StatusDate;
                    model1.TotalVat = (decimal)model.TotalVat;
                    model1.Shipping = model.Shipping;
                    model1.ShippingTax = model.ShippingTax;
                    model1.AmountsAre = model.AmountsAre;
                    model1.NetAmount = (decimal)model.Total;
                    model1.Notes = model.Notes;
                    model1.FiscalMonthId = model.FiscalMonthId;
                    //model1.StatusRemarks = "Pending";
                    model1.DocTypeId = doctypeId;
                    model1.WarehouseIdMain = model.WarehouseIdMain;
                    model1.IsRecurring = model.IsRecurring;
                    var custname = customerRepository.Find(model1.CustomerId);
                    model1.CustomerName = custname.Name;
                    List<SalesItemsModel> ls = new List<SalesItemsModel>();
                    List<SalesProductTaxModel> lt = new List<SalesProductTaxModel>();
                    List<SalesTagModel> ltag = new List<SalesTagModel>();
                    if (model.SalesItemVM.Count > 0)
                    {

                        foreach (var item in model.SalesItemVM)
                        {
                            var salesitem = new SalesItemsModel();
                            if (item.ProductId != "" && item.ServiceDate != null)
                            {
                                salesitem.Id = 0;
                                salesitem.ServiceDate = DateTime.Parse(item.ServiceDate);
                                salesitem.ProductId = int.Parse(item.ProductId);
                                salesitem.Description = item.Description;
                                salesitem.Quantity = double.Parse(item.Quantity);
                                salesitem.Price = float.Parse(item.Price);
                                salesitem.SecondaryPrice = float.Parse(item.SecondaryPrice);
                                salesitem.CostPrice = float.Parse(item.CostPrice);
                                salesitem.DefaultPrice = float.Parse(item.DefaultPrice);
                                salesitem.Amount = float.Parse(item.Amount);
                                salesitem.IndDiscount = float.Parse(item.IndDiscount);
                                salesitem.ComId = ComId ?? 0;
                                salesitem.LuserId = UserId ?? 0;
                                salesitem.LuserIdUpdate = UserId ?? 0;
                                salesitem.IsTax = false;
                                salesitem.WarehouseId = null;
                                salesitem.WHName = "N/A";
                                if (item.MasterTaxId == null || item.MasterTaxId == "0")
                                {
                                    salesitem.MasterTaxId = 0;
                                    salesitem.MasterTaxName = "";
                                }
                                else
                                {
                                    salesitem.MasterTaxId = int.Parse(item.MasterTaxId);
                                    var mastertaxname = _mastersalestaxRepository.Find(salesitem.MasterTaxId);
                                    salesitem.MasterTaxName = mastertaxname.Name;
                                }


                                var productname = productRepository.Find(salesitem.ProductId);
                                salesitem.Name = productname.Name;

                                salesitem.PrimaryUnitId = item.PrimaryUnitId;
                                salesitem.SecondaryUnitId = item.SecondaryUnitId;
                                salesitem.ConversionRate = item.ConversionRate;
                                salesitem.InputQuantity = item.InputQuantity;
                                salesitem.Unit = item.Unit;
                                //if (item.IsTax == "")
                                //{
                                //    item.IsTax = "false";
                                //}
                                //salesitem.IsTax = bool.Parse(item.IsTax);

                                ls.Add(salesitem);
                            }
                        }

                    }
                    if (model.SalesProductTaxVM.Count > 0)
                    {

                        foreach (var item in model.SalesProductTaxVM)
                        {
                            var salesitem = new SalesProductTaxModel();
                            salesitem.Id = 0;
                            salesitem.Nickname = item.Nickname;
                            salesitem.IsSum = item.IsSum;
                            salesitem.Amount = float.Parse(item.Amount);
                            salesitem.TotalAmount = float.Parse(item.TotalAmount);
                            salesitem.TaxId = item.TaxId;
                            salesitem.ComId = ComId ?? 0;
                            salesitem.LuserId = UserId ?? 0;
                            salesitem.LuserIdUpdate = UserId ?? 0;


                            lt.Add(salesitem);
                        }

                    }
                    if (model.SalesTags.Count > 0)
                    {
                        foreach (var item in model.SalesTags)
                        {
                            var salesTags = new SalesTagModel();
                            var newtag = new TagsModel();

                            if (item.Any(char.IsLetter))
                            {
                                newtag.ComId = ComId ?? 0;
                                newtag.TagsType = "G";
                                newtag.TagShortName = item;
                                newtag.TagName = item;

                                tagsRepository.Insert(newtag);

                                salesTags.TagsId = newtag.Id;
                                salesTags.ComId = ComId ?? 0;
                                ltag.Add(salesTags);
                            }
                            else
                            {
                                salesTags.TagsId = int.Parse(item);
                                salesTags.ComId = ComId ?? 0;
                                ltag.Add(salesTags);
                            }

                        }
                    }
                    if (ltag != null)
                    {
                        model1.SalesTags = ltag;
                    }
                    if (ls != null)
                    {
                        model1.Items = ls;
                    }
                    if (lt != null)
                    {
                        model1.SalesProductTax = lt;
                    }

                    saleRepository.Insert(model1);
                    return Json(new { error = false, message = "Estimate saved successfully", Id = model1.Id });

                }
                else
                {
                    var model1 = new SalesModel();
                    var doctypeId = _docTypeRepository.All().Where(x => x.DocType == "Estimate").Select(x => x.Id).FirstOrDefault();
                    var oldModel = saleRepository.All().Where(x => x.Id == model.Id).FirstOrDefault();

                    model1.ComId = model.ComId;
                    model1.LuserId = model.LuserId;
                    model1.Id = model.Id;
                    model1.CustomerId = int.Parse(model.CustomerId);
                    model1.EmailId = model.EmailId;
                    model1.PrimaryAddress = model.PrimaryAddress;
                    model1.SalesDate = DateTime.Parse(model.SalesDate);
                    model1.DocTypeId = doctypeId;
                    model1.WarehouseIdMain = model.WarehouseIdMain;
                    model1.IsRecurring = model.IsRecurring;
                    model1.DueDate = DateTime.Parse(model.DueDate);
                    model1.ShippingVia = model.ShippingVia;
                    model1.ShippingDate = DateTime.Parse(model.ShippingDate);
                    model1.TrackingNo = model.TrackingNo;
                    model1.SaleCode = model.SaleCode;
                    model1.CurrencyRate = model.CurrencyRate;
                    model1.StatusRemarks = model.EstimateStatus;
                    model1.StatusBy = model.StatusBy;
                    model1.StatusDate = model.StatusDate;
                    model1.SecoundaryAddress = model.SecoundaryAddress;
                    model1.ShippingTo = model.ShippingTo;
                    model1.MessageInvoice = model.MessageInvoice;
                    model1.FiscalMonthId = model.FiscalMonthId;
                    model1.MessageStatement = model.MessageStatement;
                    model1.Total = model.Total;
                    model1.SubTotal = model.SubTotal;
                    model1.TotalVat = (decimal)model.TotalVat;
                    model1.Shipping = model.Shipping;
                    model1.ShippingTax = model.ShippingTax;
                    model1.AmountsAre = model.AmountsAre;
                    model1.NetAmount = (decimal)model.Total;
                    model1.Notes = model.Notes;
                    //model1.StatusRemarks = "Pending";
                    model1.FileName = oldModel.FileName;

                    var custname = customerRepository.Find(model1.CustomerId);
                    model1.CustomerName = custname.Name;
                    List<SalesItemsModel> ls = new List<SalesItemsModel>();
                    if (model.SalesItemVM != null)
                    {
                        var nonZeroId = new List<int>();
                        nonZeroId = saleItemRepository.All().Where(x => x.SalesId == model.Id).Select(y => y.Id).ToList();

                        foreach (var item in model.SalesItemVM)
                        {
                            var salesitem = new SalesItemsModel();

                            var id = item.Id;
                            if (id == 0)
                            {
                                salesitem.Id = 0;
                                salesitem.SalesId = model.Id;
                                salesitem.ServiceDate = DateTime.Parse(item.ServiceDate);
                                salesitem.ProductId = int.Parse(item.ProductId);
                                salesitem.Description = item.Description;
                                salesitem.Quantity = double.Parse(item.Quantity);
                                salesitem.Price = float.Parse(item.Price);
                                salesitem.SecondaryPrice = float.Parse(item.SecondaryPrice);
                                salesitem.CostPrice = float.Parse(item.CostPrice);
                                salesitem.DefaultPrice = float.Parse(item.DefaultPrice);
                                salesitem.Amount = float.Parse(item.Amount);
                                salesitem.IndDiscount = float.Parse(item.IndDiscount);
                                salesitem.ComId = ComId ?? 0;
                                salesitem.LuserId = UserId ?? 0;
                                salesitem.LuserIdUpdate = UserId ?? 0;
                                salesitem.WarehouseId = null;
                                salesitem.WHName = "N/A";
                                if (item.MasterTaxId == null || item.MasterTaxId == "0")
                                {
                                    salesitem.MasterTaxId = 0;
                                    salesitem.MasterTaxName = "";
                                }
                                else
                                {
                                    salesitem.MasterTaxId = int.Parse(item.MasterTaxId);
                                    var mastertaxname = _mastersalestaxRepository.Find(salesitem.MasterTaxId);
                                    salesitem.MasterTaxName = mastertaxname.Name;

                                }

                                var productname = productRepository.Find(salesitem.ProductId);
                                salesitem.Name = productname.Name;
                                salesitem.PrimaryUnitId = item.PrimaryUnitId;
                                salesitem.SecondaryUnitId = item.SecondaryUnitId;
                                salesitem.ConversionRate = item.ConversionRate;
                                salesitem.InputQuantity = item.InputQuantity;
                                salesitem.Unit = item.Unit;

                                saleItemRepository.Insert(salesitem);
                            }
                            else
                            {
                                if (nonZeroId.Contains(id))
                                {
                                    // Remove the element
                                    nonZeroId.Remove(id);
                                }

                                salesitem = saleItemRepository.Find(id);
                                salesitem.Id = id;
                                salesitem.ServiceDate = DateTime.Parse(item.ServiceDate);
                                salesitem.ProductId = int.Parse(item.ProductId);
                                salesitem.Description = item.Description;
                                salesitem.Quantity = double.Parse(item.Quantity);
                                salesitem.Price = float.Parse(item.Price);
                                salesitem.SecondaryPrice = float.Parse(item.SecondaryPrice);
                                salesitem.CostPrice = float.Parse(item.CostPrice);
                                salesitem.DefaultPrice = float.Parse(item.DefaultPrice);
                                salesitem.Amount = float.Parse(item.Amount);
                                salesitem.IndDiscount = float.Parse(item.IndDiscount);
                                salesitem.ComId = ComId ?? 0;
                                salesitem.LuserId = UserId ?? 0;
                                salesitem.LuserIdUpdate = UserId ?? 0;
                                salesitem.WarehouseId = item.WarehouseId;
                                salesitem.WHName = item.WHName;

                                if (item.MasterTaxId == null || item.MasterTaxId == "0")
                                {
                                    salesitem.MasterTaxId = 0;
                                    salesitem.MasterTaxName = "";
                                }
                                else
                                {
                                    salesitem.MasterTaxId = int.Parse(item.MasterTaxId);
                                    var mastertaxname = _mastersalestaxRepository.Find(salesitem.MasterTaxId);
                                    salesitem.MasterTaxName = mastertaxname.Name;

                                }

                                var productname = productRepository.Find(salesitem.ProductId);
                                salesitem.Name = productname.Name;
                                salesitem.PrimaryUnitId = item.PrimaryUnitId;
                                salesitem.SecondaryUnitId = item.SecondaryUnitId;
                                salesitem.ConversionRate = item.ConversionRate;
                                salesitem.InputQuantity = item.InputQuantity;
                                salesitem.Unit = item.Unit;

                                //ls.Add(salesitem);
                                saleItemRepository.Update(salesitem, id);

                            }

                        }

                        if (nonZeroId.Count > 0)
                        {
                            foreach (var id in nonZeroId)
                            {
                                var items = saleItemRepository.All().Where(x => x.Id == id).FirstOrDefault();
                                saleItemRepository.Delete(items);
                            }
                        }

                    }
                    var data = salesProductTaxRepository.All().Where(x => x.SalesId == model1.Id).ToList();
                    if (data != null || data.Count > 0)
                    {
                        foreach (var item in data)
                        {
                            salesProductTaxRepository.Delete(item);
                        }
                    }
                    if (model.SalesProductTaxVM != null)
                    {
                        var temp = new SalesProductTaxModel();
                        foreach (var item in model.SalesProductTaxVM)
                        {
                            temp.Id = 0;
                            temp.SalesId = model1.Id;
                            temp.Nickname = item.Nickname;
                            temp.IsSum = item.IsSum;
                            temp.Amount = float.Parse(item.Amount);
                            temp.TotalAmount = float.Parse(item.TotalAmount);
                            temp.TaxId = item.TaxId;
                            temp.ComId = ComId ?? 0;
                            salesProductTaxRepository.Insert(temp);
                        }

                    }

                    List<SalesTagModel> ltag = new List<SalesTagModel>();
                    var tagsData = salesTagRepository.All().Where(x => x.SalesId == model1.Id).ToList();
                    if (tagsData.Count > 0)
                    {
                        foreach (var tag in tagsData)
                        {
                            salesTagRepository.Delete(tag);
                        }
                    }

                    if (model.SalesTags.Count > 0)
                    {
                        foreach (var item in model.SalesTags)
                        {
                            var salesTags = new SalesTagModel();
                            var newtag = new TagsModel();

                            if (item.Any(char.IsLetter))
                            {
                                newtag.ComId = ComId ?? 0;
                                newtag.TagsType = "G";
                                newtag.TagShortName = item;
                                newtag.TagName = item;

                                tagsRepository.Insert(newtag);

                                salesTags.TagsId = newtag.Id;
                                salesTags.SalesId = model1.Id;
                                salesTags.ComId = ComId ?? 0;
                                salesTagRepository.Insert(salesTags);
                            }
                            else
                            {
                                salesTags.TagsId = int.Parse(item);
                                salesTags.ComId = ComId ?? 0;
                                salesTags.SalesId = model1.Id;
                                salesTagRepository.Insert(salesTags);
                            }

                        }
                    }
                    saleRepository.Update(model1, model1.Id);
                    return Json(new { error = false, message = "Estimate Updated successfully", Id = model1.Id });

                }
                return View(model);

            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        [OverridableAuthorize]
        public IActionResult AddIssue()
        {
            var ComId = HttpContext.Session.GetInt32("ComId");

            ViewBag.Customers = customerRepository.All().Where(p => p.ComId == ComId).Include(x => x.Currency)
                       .Select(x => new SelectListItem
                       {
                           Text = x.Name + '-' + x.Currency.CurrencyShortName,
                           Value = x.Id.ToString()
                       });

            ViewBag.WarehouseIdMain = _warehouseRepository.All().Where(x => x.ComId == ComId)
                            .Select(x => new SelectListItem
                            {
                                Text = x.WhName,
                                Value = x.Id.ToString()
                            });
            ViewBag.ActionType = "Create";

            var type = "Issue";

            ViewBag.TransactionType = type;

            var products = productRepository.All().Where(p => p.ComId == ComId).ToList();

            SelectList productslist = new SelectList(products, "Id", "Name");
            ViewData["ProductList"] = productslist;

            var taxes = _mastersalestaxRepository.All().Where(f => f.ComId == ComId).ToList();
            SelectList taxList = new SelectList(taxes, "Id", "Name");
            ViewData["TaxList"] = taxList;

            var agency = _agencyRepository.All();
            var data = agency.ToList();
            SelectList agencyList = new SelectList(data, "Id", "AgencyName");

            ViewData["AgencyList"] = agencyList;

            var taxCalculation = new List<SelectListItem>
    {
        new SelectListItem { Text = "Exclusive of Tax", Value = "exclusive" },
        new SelectListItem { Text = "Inclusive of Tax", Value = "inclusive" },
        new SelectListItem { Text = "Out of scope of Tax", Value = "outscope" }
    };

            var estimateStatus = new List<SelectListItem>
    {
        new SelectListItem { Text = "Pending", Value = "Pending" },
        new SelectListItem { Text = "Accepted", Value = "Accepted" },
        new SelectListItem { Text = "Closed", Value = "Closed" },
        new SelectListItem { Text = "Rejected", Value = "Rejected" }
    };

            var estimateStatusList = new SelectList(estimateStatus, "Value", "Text");
            ViewData["EstimateStatus"] = estimateStatusList;

            var taxCalculationList = new SelectList(taxCalculation, "Value", "Text");

            ViewData["CategoryList"] = accountHeadRepository.GetCashBankHeadForDropDown();

            ViewData["AmountsAre"] = taxCalculationList;

            ViewBag.Id = 0;
            return View("AddInvoiceQB");
        }

        [OverridableAuthorize]
        [HttpGet]
        public IActionResult EditIssue(int id)
        {
            try
            {

                var errors = ModelState.Where(x => x.Value.Errors.Any())
              .Select(x => new { x.Key, x.Value.Errors });

                var ComId = HttpContext.Session.GetInt32("ComId");

                ViewBag.Customers = customerRepository.All().Where(p => p.ComId == ComId).Include(x => x.Currency)
                           .Select(x => new SelectListItem
                           {
                               Text = x.Name + '-' + x.Currency.CurrencyShortName,
                               Value = x.Id.ToString()
                           });
                ViewBag.WarehouseIdMain = _warehouseRepository.All().Where(x => x.ComId == ComId)
                               .Select(x => new SelectListItem
                               {
                                   Text = x.WhName,
                                   Value = x.Id.ToString()
                               });
                var taxes = _mastersalestaxRepository.All().Where(f => f.ComId == ComId).ToList();
                SelectList taxList = new SelectList(taxes, "Id", "Name");
                ViewData["TaxList"] = taxList;

                var type = "Issue";


                ViewBag.TransactionType = type;
                ViewBag.ActionType = "Edit";
                ViewBag.Id = id;
                var products = productRepository.All().Where(p => p.ComId == ComId).ToList();

                SelectList productslist = new SelectList(products, "Id", "Name");
                ViewData["ProductList"] = productslist;

                var agency = _agencyRepository.All();
                var data = agency.ToList();
                SelectList agencyList = new SelectList(data, "Id", "AgencyName");

                ViewData["AgencyList"] = agencyList;
                var data1 = saleRepository.All().Where(x => x.Id == id).FirstOrDefault();

                var estimateStatus = new List<SelectListItem>
            {
                new SelectListItem { Text = "Pending", Value = "Pending" },
                new SelectListItem { Text = "Accepted", Value = "Accepted" },
                new SelectListItem { Text = "Closed", Value = "Closed" },
                new SelectListItem { Text = "Rejected", Value = "Rejected" }
            };

                var estimateStatusList = new SelectList(estimateStatus, "Value", "Text");
                ViewData["EstimateStatus"] = estimateStatusList;

                var taxCalculation = new List<SelectListItem>
            {
                new SelectListItem { Text = "Exclusive of Tax", Value = "exclusive" },
                new SelectListItem { Text = "Inclusive of Tax", Value = "inclusive" },
                new SelectListItem { Text = "Out of scope of Tax", Value = "outscope" }
            };

                var taxCalculationList = new SelectList(taxCalculation, "Value", "Text");

                ViewData["AmountsAre"] = taxCalculationList;
                ViewData["CategoryList"] = accountHeadRepository.GetCashBankHeadForDropDown();

                return View("AddInvoiceQB");

            }
            catch (Exception ex)
            {

                throw ex;
            }

        }

        [AllowAnonymous]
        [HttpPost]
        public IActionResult IssueCreation([FromBody] SalesModelVM model)
        {
            try
            {

                var errors = ModelState.Where(x => x.Value.Errors.Any())
              .Select(x => new { x.Key, x.Value.Errors });

                string format = "dd-MMM-yyyy"; // The format of the input date string
                var ComId = HttpContext.Session.GetInt32("ComId");
                var UserId = HttpContext.Session.GetInt32("UserId");
                DateTime dateTime;

                if (DateTime.TryParseExact(model.SalesDate, format, CultureInfo.InvariantCulture, DateTimeStyles.None, out dateTime))
                {
                    var temp = dateTime;
                    dateTime = temp;
                }
                if (model.Id == 0)
                {
                    DateTime now = DateTime.Now;
                    string uniqueNumber = "Iss_" + DateTime.Now.ToString("ddMMyyHHmmssfff");
                    var model1 = new SalesModel();
                    var doctypeId = _docTypeRepository.All().Where(x => x.DocType == "Issue").Select(x => x.Id).FirstOrDefault();
                    var docPrefix = docPrefixRepository.All().Where(x => x.ComId == ComId && x.DocTypeId == doctypeId).FirstOrDefault();
                    if (docPrefix != null)
                    {
                        uniqueNumber = GetSalesCode(doctypeId);
                    }

                    model1.ComId = model.ComId;
                    model1.LuserId = model.LuserId;
                    model1.Id = model.Id;
                    model1.CustomerId = int.Parse(model.CustomerId);
                    model1.EmailId = model.EmailId;
                    model1.PrimaryAddress = model.PrimaryAddress;
                    model1.SalesDate = DateTime.Now;
                    model1.DueDate = DateTime.Now;
                    model1.ShippingVia = model.ShippingVia;
                    model1.ShippingDate = DateTime.Now;
                    model1.TrackingNo = model.TrackingNo;
                    model1.SaleCode = uniqueNumber;
                    model1.CurrencyRate = model.CurrencyRate;
                    model1.SecoundaryAddress = model.SecoundaryAddress;
                    model1.ShippingTo = model.ShippingTo;
                    model1.MessageInvoice = model.MessageInvoice;
                    model1.MessageStatement = model.MessageStatement;
                    model1.Total = model.Total;
                    model1.SubTotal = model.SubTotal;
                    model1.TotalVat = (decimal)model.TotalVat;
                    model1.Shipping = model.Shipping;
                    model1.ShippingTax = model.ShippingTax;
                    model1.AmountsAre = model.AmountsAre;
                    model1.NetAmount = (decimal)model.Total;                  
                    model1.Notes = model.Notes;
                    model1.DocTypeId = doctypeId;
                    model1.WarehouseIdMain = model.WarehouseIdMain;
                    model1.IsRecurring = model.IsRecurring;
                    var custname = customerRepository.Find(model1.CustomerId);
                    model1.CustomerName = custname.Name;
                    List<SalesItemsModel> ls = new List<SalesItemsModel>();
                    List<SalesProductTaxModel> lt = new List<SalesProductTaxModel>();
                    List<SalesTagModel> ltag = new List<SalesTagModel>();
                    if (model.SalesItemVM.Count > 0)
                    {

                        foreach (var item in model.SalesItemVM)
                        {
                            var salesitem = new SalesItemsModel();
                            if (item.ProductId != "" && item.ServiceDate != null)
                            {
                                salesitem.Id = 0;
                                salesitem.ServiceDate = DateTime.Parse(item.ServiceDate);
                                salesitem.ProductId = int.Parse(item.ProductId);
                                salesitem.Description = item.Description;
                                salesitem.Quantity = double.Parse(item.Quantity);
                                salesitem.Price = float.Parse(item.Price);
                                salesitem.SecondaryPrice = float.Parse(item.SecondaryPrice);
                                salesitem.CostPrice = float.Parse(item.CostPrice);
                                salesitem.DefaultPrice = float.Parse(item.DefaultPrice);
                                salesitem.Amount = float.Parse(item.Amount);
                                salesitem.IndDiscount = float.Parse(item.IndDiscount);
                                salesitem.ComId = ComId ?? 0;
                                salesitem.LuserId = UserId ?? 0;
                                salesitem.LuserIdUpdate = UserId ?? 0;
                                salesitem.IsTax = false;
                                salesitem.WarehouseId = item.WarehouseId;
                                salesitem.PurchaseItemsId = item.PurchaseItemsId;
                                salesitem.WHName = item.WHName;
                                if (item.MasterTaxId == null || item.MasterTaxId == "0")
                                {
                                    salesitem.MasterTaxId = 0;
                                    salesitem.MasterTaxName = "";
                                }
                                else
                                {
                                    salesitem.MasterTaxId = int.Parse(item.MasterTaxId);
                                    var mastertaxname = _mastersalestaxRepository.Find(salesitem.MasterTaxId);
                                    salesitem.MasterTaxName = mastertaxname.Name;
                                }


                                var productname = productRepository.Find(salesitem.ProductId);
                                salesitem.Name = productname.Name;
                                salesitem.PrimaryUnitId = item.PrimaryUnitId;
                                salesitem.SecondaryUnitId = item.SecondaryUnitId;
                                salesitem.ConversionRate = item.ConversionRate;
                                salesitem.InputQuantity = item.InputQuantity;
                                salesitem.Unit = item.Unit;
                                //if (item.IsTax == "")
                                //{
                                //    item.IsTax = "false";
                                //}
                                //salesitem.IsTax = bool.Parse(item.IsTax);

                                ls.Add(salesitem);
                            }
                        }

                    }

                    if (ls != null)
                    {
                        model1.Items = ls;
                    }


                    saleRepository.Insert(model1);
                    return Json(new { error = false, message = "Issue saved successfully", Id = model1.Id });

                }
                else
                {
                    var model1 = new SalesModel();
                    var doctypeId = _docTypeRepository.All().Where(x => x.DocType == "Issue").Select(x => x.Id).FirstOrDefault();
                    var oldModel = saleRepository.All().Where(x => x.Id == model.Id).FirstOrDefault();

                    model1.ComId = model.ComId;
                    model1.LuserId = model.LuserId;
                    model1.Id = model.Id;
                    model1.CustomerId = int.Parse(model.CustomerId);
                    model1.EmailId = model.EmailId;
                    model1.SaleCode = oldModel.SaleCode;
                    model1.SalesDate = DateTime.Now;
                    model1.DocTypeId = doctypeId;
                    model1.WarehouseIdMain = model.WarehouseIdMain;
                    model1.IsRecurring = model.IsRecurring;
                    model1.DueDate = DateTime.Now;
                    model1.ShippingVia = model.ShippingVia;
                    model1.ShippingDate = DateTime.Now;
                    model1.CurrencyRate = model.CurrencyRate;
                    model1.StatusBy = model.StatusBy;
                    model1.MessageInvoice = model.MessageInvoice;
                    model1.FiscalMonthId = model.FiscalMonthId;
                    model1.MessageStatement = model.MessageStatement;
                    model1.Total = model.Total;
                    model1.SubTotal = model.SubTotal;
                    model1.TotalVat = (decimal)model.TotalVat;                  
                    model1.Shipping = model.Shipping;
                    model1.ShippingTax = model.ShippingTax;
                    model1.AmountsAre = model.AmountsAre;
                    model1.NetAmount = (decimal)model.Total;
                    model1.Notes = model.Notes;
                    //model1.StatusRemarks = "Pending";
                    model1.FileName = oldModel.FileName;

                    var custname = customerRepository.Find(model1.CustomerId);
                    model1.CustomerName = custname.Name;
                    List<SalesItemsModel> ls = new List<SalesItemsModel>();
                    if (model.SalesItemVM != null)
                    {
                        var nonZeroId = new List<int>();
                        nonZeroId = saleItemRepository.All().Where(x => x.SalesId == model.Id).Select(y => y.Id).ToList();

                        foreach (var item in model.SalesItemVM)
                        {
                            var salesitem = new SalesItemsModel();

                            var id = item.Id;
                            if (id == 0)
                            {
                                salesitem.Id = 0;
                                salesitem.SalesId = model.Id;
                                salesitem.ServiceDate = DateTime.Parse(item.ServiceDate);
                                salesitem.ProductId = int.Parse(item.ProductId);
                                salesitem.Description = item.Description;
                                salesitem.Quantity = double.Parse(item.Quantity);
                                salesitem.Price = float.Parse(item.Price);
                                salesitem.SecondaryPrice = float.Parse(item.SecondaryPrice);
                                salesitem.CostPrice = float.Parse(item.CostPrice);
                                salesitem.DefaultPrice = float.Parse(item.DefaultPrice);
                                salesitem.Amount = float.Parse(item.Amount);
                                salesitem.IndDiscount = float.Parse(item.IndDiscount);
                                salesitem.ComId = ComId ?? 0;
                                salesitem.LuserId = UserId ?? 0;
                                salesitem.LuserIdUpdate = UserId ?? 0;
                                salesitem.WarehouseId = item.WarehouseId;
                                salesitem.WHName = item.WHName;
                                salesitem.PurchaseItemsId = item.PurchaseItemsId;
                                if (item.MasterTaxId == null || item.MasterTaxId == "0")
                                {
                                    salesitem.MasterTaxId = 0;
                                    salesitem.MasterTaxName = "";
                                }
                                else
                                {
                                    salesitem.MasterTaxId = int.Parse(item.MasterTaxId);
                                    var mastertaxname = _mastersalestaxRepository.Find(salesitem.MasterTaxId);
                                    salesitem.MasterTaxName = mastertaxname.Name;

                                }

                                var productname = productRepository.Find(salesitem.ProductId);
                                salesitem.Name = productname.Name;
                                salesitem.PrimaryUnitId = item.PrimaryUnitId;
                                salesitem.SecondaryUnitId = item.SecondaryUnitId;
                                salesitem.ConversionRate = item.ConversionRate;
                                salesitem.InputQuantity = item.InputQuantity;
                                salesitem.Unit = item.Unit;

                                saleItemRepository.Insert(salesitem);
                            }
                            else
                            {
                                if (nonZeroId.Contains(id))
                                {
                                    // Remove the element
                                    nonZeroId.Remove(id);
                                }

                                salesitem = saleItemRepository.Find(id);
                                salesitem.Id = id;
                                salesitem.ServiceDate = DateTime.Parse(item.ServiceDate);
                                salesitem.ProductId = int.Parse(item.ProductId);
                                salesitem.Description = item.Description;
                                salesitem.Quantity = double.Parse(item.Quantity);
                                salesitem.Price = float.Parse(item.Price);
                                salesitem.SecondaryPrice = float.Parse(item.SecondaryPrice);
                                salesitem.CostPrice = float.Parse(item.CostPrice);
                                salesitem.DefaultPrice = float.Parse(item.DefaultPrice);
                                salesitem.Amount = float.Parse(item.Amount);
                                salesitem.IndDiscount = float.Parse(item.IndDiscount);
                                salesitem.ComId = ComId ?? 0;
                                salesitem.LuserId = UserId ?? 0;
                                salesitem.LuserIdUpdate = UserId ?? 0;
                                salesitem.WarehouseId = item.WarehouseId;
                                salesitem.WHName = item.WHName;
                                salesitem.PurchaseItemsId = item.PurchaseItemsId;

                                if (item.MasterTaxId == null || item.MasterTaxId == "0")
                                {
                                    salesitem.MasterTaxId = 0;
                                    salesitem.MasterTaxName = "";
                                }
                                else
                                {
                                    salesitem.MasterTaxId = int.Parse(item.MasterTaxId);
                                    var mastertaxname = _mastersalestaxRepository.Find(salesitem.MasterTaxId);
                                    salesitem.MasterTaxName = mastertaxname.Name;

                                }

                                var productname = productRepository.Find(salesitem.ProductId);
                                salesitem.Name = productname.Name;
                                salesitem.PrimaryUnitId = item.PrimaryUnitId;
                                salesitem.SecondaryUnitId = item.SecondaryUnitId;
                                salesitem.ConversionRate = item.ConversionRate;
                                salesitem.InputQuantity = item.InputQuantity;
                                salesitem.Unit = item.Unit;

                                //ls.Add(salesitem);
                                saleItemRepository.Update(salesitem, id);

                            }

                        }

                        if (nonZeroId.Count > 0)
                        {
                            foreach (var id in nonZeroId)
                            {
                                var items = saleItemRepository.All().Where(x => x.Id == id).FirstOrDefault();
                                saleItemRepository.Delete(items);
                            }
                        }

                    }
                    saleRepository.Update(model1, model1.Id);
                    return Json(new { error = false, message = "Issue Updated successfully", Id = model1.Id });

                }
                return View(model);

            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        //[AllowAnonymous]
        //public JsonResult GetProductListByBDPOForIssue(int? CustomerId = null)
        //{
        //    try
        //    {

        //        var purchase = _purchaseItemRepository.All(true, true); 

        //        purchase = purchase.Where(x => x.PurchaseInfo.PurchaseModel.DocTypeList.DocType.ToLower().Contains("Supplier PO"));


        //        if (CustomerId != null)
        //        {
        //            purchase = purchase.Where(x => x.PurchaseInfo.PurchaseModel.CustomerId == CustomerId);
        //        }


        //        var query = (from p in purchase
        //                         //let StockQty = (float)(p.Quantity - p.SalesItemsList.Sum(x => x.Quantity)) //p.Quantity - p.SalesItemsList.Sum(x => x.Quantity)
        //                     let StockQty = (float)(p.Quantity - p.SalesItemsList.Sum(x => x.Quantity)) //p.Quantity - p.SalesItemsList.Sum(x => x.Quantity)

        //                     select new //ProductResult
        //                     {
        //                         ProductId = p.Product.Id,
        //                         PurchaseItemsId = p.PurchaseInfo.PurchaseItems.FirstOrDefault().Id,
        //                         BDPOItemsId = p.PurchaseInfo.PurchaseItems.FirstOrDefault().PurchaseItemsId,

        //                         Name = p.Product.Name,
        //                         LocalName = p.Product.LocalName,
        //                         Code = p.Product.Code,
        //                         Price = p.Product.Price,
        //                         DefaultPrice = p.Product.Price,
        //                         CostPrice = p.Product.CostPrice,


        //                         ETA = p.PurchaseInfo.PurchaseModel.PurchaseDate.ToString("dd-MMM-yy"),
        //                         ShipperName = p.PurchaseModel.ShipVia,

        //                         ShipmentFrom = p.PurchaseModel.ShipVia,



        //                         UnitName = p.Product.Unit.UnitName,
        //                         UnitId = p.Product.UnitId,

        //                         CategoryName = p.Product.Category.Name,
        //                         BrandName = p.Product.Brand != null ? p.Product.Brand.BrandName : "",
        //                         ModelName = p.Product.ModelName,
        //                         VariantName = p.Product.SizeName,
        //                         SizeName = p.Product.SizeName,
        //                         ColorName = p.Product.ColorName,
        //                         Desc = p.Product.Description,


        //                         //ROL = p.ROL,
        //                         //ROQ = p.ROQ,
        //                         //MOQ = p.MOQ,
        //                         OldPrice = p.Product.OldPrice,
        //                         ImagePath = p.Product.ImagePath,



        //                         ProductBarcode = p.Product.Code,
        //                         GRRDescription = p.Description,


        //                         SupplierPO = p.PurchaseInfo.PurchaseModel.PurchaseCode,
        //                         CustomerName = p.PurchaseInfo.PurchaseModel.CustomerModel.Name,
        //                         Style = p.PurchaseInfo.Style.StyleNo,
        //                         BuyerPO = p.PurchaseInfo.BuyerPO_Master.BuyerPO,

        //                         SupplierName = p.PurchaseInfo.PurchaseModel.SupplierModel.SupplierName,
        //                         GRRQty = p.Quantity,
        //                         GRRDate = p.PurchaseModel.PurchaseDate.ToString("dd-MMM-yy"),
        //                         StockQty = StockQty,
        //                         WarehouseId = p.WarehouseId,
        //                         WHName = p.vWarehouse.WhName,
        //                         GRRNO = p.PurchaseModel.PurchaseCode


        //                     });



        //        var abcd = query.OrderByDescending(x => x.PurchaseItemsId).ToList();


        //        return Json(new { Success = 1, error = false, ProductList = abcd });


        //    }
        //    catch (Exception ex)
        //    {

        //        Console.WriteLine(ex.Message);
        //        return Json(ex.Message);
        //    }
        //}

        [AllowAnonymous]
        public JsonResult GetProductListByBDPOForIssue(int? CustomerId = null)
        {
            try
            {

                var purchase = _purchaseItemRepository.All(true, true);

                purchase = purchase.Where(x => x.PurchaseModel.DocTypeList.DocType.ToLower().Contains("GRR"));


                if (CustomerId != null)
                {
                    purchase = purchase.Where(x => x.CustomerId == CustomerId);
                }


                var query = (from p in purchase
                             let StockQty = (float)(p.Quantity - p.SalesItemsList.Sum(x => x.Quantity)) //p.Quantity - p.SalesItemsList.Sum(x => x.Quantity)

                             select new //ProductResult
                             {
                                 ProductId = p.Product.Id,
                                 PurchaseItemsId = p.Id,

                                 Name = p.Product.Name,
                                 LocalName = p.Product.LocalName,
                                 Code = p.Product.Code,
                                 Price = p.Product.Price,
                                 DefaultPrice = p.Product.Price,
                                 CostPrice = p.Product.CostPrice,


                                 ETA = p.PurchaseInfo.PurchaseModel.PurchaseDate.ToString("dd-MMM-yy"),
                                 ShipperName = p.PurchaseModel.ShipVia,

                                 ShipmentFrom = p.PurchaseModel.ShipVia,



                                 UnitName = p.Product.Unit.UnitName,
                                 UnitId = p.Product.UnitId,

                                 CategoryName = p.Product.Category.Name,
                                 BrandName = p.Product.Brand != null ? p.Product.Brand.BrandName : "",
                                 ModelName = p.Product.ModelName,
                                 VariantName = p.Product.SizeName,
                                 SizeName = p.Product.SizeName,
                                 ColorName = p.Product.ColorName,
                                 Desc = p.Product.Description,


                                 //ROL = p.ROL,
                                 //ROQ = p.ROQ,
                                 //MOQ = p.MOQ,
                                 OldPrice = p.Product.OldPrice,
                                 ImagePath = p.Product.ImagePath,



                                 ProductBarcode = p.Product.Code,
                                 GRRDescription = p.Description,


                                 SupplierPO = p.PurchaseInfo.PurchaseModel.PurchaseCode,
                                 CustomerName = p.PurchaseModel.CustomerModel.Name,
                                 Style = p.Style.StyleNo,
                                 BuyerPO = p.BuyerPO_Master.BuyerPO,

                                 SupplierName = p.PurchaseModel.SupplierModel.SupplierName,
                                 Quantity = p.Quantity,
                                 GRRDate = p.PurchaseModel.PurchaseDate.ToString("dd-MMM-yy"),
                                 StockQty = StockQty,
                                 WarehouseId = p.WarehouseId,
                                 WHName = p.vWarehouse.WhName,
                                 GRRNO = p.PurchaseModel.PurchaseCode


                             });



                var abcd = query.Where(x => x.StockQty > 0).OrderByDescending(x => x.PurchaseItemsId).ToList();


                return Json(new { Success = 1, error = false, ProductList = abcd });


            }
            catch (Exception ex)
            {

                Console.WriteLine(ex.Message);
                return Json(ex.Message);
            }
        }

        //[AllowAnonymous]
        //[HttpGet]
        //public IActionResult EditEstimate(int id)
        //{
        //    var ComId = HttpContext.Session.GetInt32("ComId");

        //    ViewBag.Customers = customerRepository.All().Where(p => p.ComId == ComId)
        //               .Select(x => new SelectListItem
        //               {
        //                   Text = x.Name,
        //                   Value = x.Id.ToString()
        //               });

        //    ViewBag.WarehouseIdMain = _warehouseRepository.All().Where(x => x.ComId == ComId)
        //                   .Select(x => new SelectListItem
        //                   {
        //                       Text = x.WhName,
        //                       Value = x.Id.ToString()
        //                   });

        //    var taxes = _mastersalestaxRepository.All().Where(f => f.ComId == ComId).ToList();
        //    SelectList taxList = new SelectList(taxes, "Id", "Name");
        //    ViewData["TaxList"] = taxList;

        //    ViewBag.TransactionType = "Estimate";
        //    ViewBag.ActionType = "Edit";
        //    ViewBag.Id = id;
        //    var products = productRepository.All().Where(p => p.ComId == ComId).ToList();

        //    SelectList productslist = new SelectList(products, "Id", "Name");
        //    ViewData["ProductList"] = productslist;

        //    var agency = _agencyRepository.All();
        //    var data = agency.ToList();
        //    SelectList agencyList = new SelectList(data, "Id", "AgencyName");

        //    ViewData["AgencyList"] = agencyList;
        //    var data1 = saleRepository.All().Where(x => x.Id == id).FirstOrDefault();

        //    var taxCalculation = new List<SelectListItem>
        //    {
        //        new SelectListItem { Text = "Exclusive of Tax", Value = "exclusive" },
        //        new SelectListItem { Text = "Inclusive of Tax", Value = "inclusive" },
        //        new SelectListItem { Text = "Out of scope of Tax", Value = "outscope" }
        //    };

        //    var taxCalculationList = new SelectList(taxCalculation, "Value", "Text");

        //    ViewData["AmountsAre"] = taxCalculationList;

        //    return View("CreateInvoiceQB");
        //}

        #endregion



        #region Sales Order

        [AllowAnonymous]
        public IActionResult CreateSalesOrderQB()
        {
            var ComId = HttpContext.Session.GetInt32("ComId");

            ViewBag.Customers = customerRepository.All().Where(p => p.ComId == ComId)
                       .Select(x => new SelectListItem
                       {
                           Text = x.Name + '-' + x.Currency.CurrencyShortName,
                           Value = x.Id.ToString()
                       });
            ViewBag.ActionType = "Create";

            ViewBag.WarehouseIdMain = _warehouseRepository.All().Where(x => x.ComId == ComId)
                           .Select(x => new SelectListItem
                           {
                               Text = x.WhName,
                               Value = x.Id.ToString()
                           });

            ViewBag.TransactionType = "Sales_Order";

            var products = productRepository.All().Where(p => p.ComId == ComId).ToList();

            SelectList productslist = new SelectList(products, "Id", "Name");
            ViewData["ProductList"] = productslist;

            var taxes = _mastersalestaxRepository.All().Where(f => f.ComId == ComId).ToList();
            SelectList taxList = new SelectList(taxes, "Id", "Name");
            ViewData["TaxList"] = taxList;
            var taxCalculation = new List<SelectListItem>
            {
                new SelectListItem { Text = "Exclusive of Tax", Value = "exclusive" },
                new SelectListItem { Text = "Inclusive of Tax", Value = "inclusive" },
                new SelectListItem { Text = "Out of scope of Tax", Value = "outscope" }
            };

            var taxCalculationList = new SelectList(taxCalculation, "Value", "Text");

            ViewData["AmountsAre"] = taxCalculationList;

            ViewBag.Id = 0;
            return View("CreateInvoiceQB");
        }

        [HttpGet]
        [AllowAnonymous]
        public IActionResult CustomerWiseEstimateData(int customerid)
        {

            var ComId = HttpContext.Session.GetInt32("ComId");

            var doctypeId = _docTypeRepository.All().Where(x => x.DocType == "Estimate").Select(x => x.Id).FirstOrDefault();

            var salesData = saleRepository.All().Where(x => x.CustomerId == customerid && x.DocTypeId == doctypeId).ToList();

            if (salesData != null && salesData.Count >= 0)
            {
                var data = new List<invoiceGridItem>();
                foreach (var item in salesData)
                {
                    var singledata = new invoiceGridItem();
                    var openBlnc = item.Total - (double)item.PaidAmount;
                    var descp = "Estimate #" + item.SaleCode;

                    singledata.Id = item.Id;
                    singledata.DueDate = item.DueDate;
                    singledata.SalesDate = item.SalesDate;
                    singledata.Original_Amount = item.Total;
                    singledata.Open_Balance = openBlnc;
                    singledata.Description = descp;
                    singledata.CheckBox = false;
                    singledata.SalesCode = item.SaleCode;

                    data.Add(singledata);
                }
                return Json(new { Success = 1, Data = data, ex = "Data Loaded Successfully" });
            }
            return Json(new { Success = 2, ex = "Data Loaded Failed" });
        }

        [AllowAnonymous]
        [HttpPost]
        public IActionResult SalesOrderCreation([FromBody] SalesModelVM model)
        {
            string format = "dd-MMM-yyyy"; // The format of the input date string
            var ComId = HttpContext.Session.GetInt32("ComId");
            DateTime dateTime;

            if (DateTime.TryParseExact(model.SalesDate, format, CultureInfo.InvariantCulture, DateTimeStyles.None, out dateTime))
            {
                var temp = dateTime;
                dateTime = temp;
            }
            if (model.Id == 0)
            {
                DateTime now = DateTime.Now;
                string uniqueNumber = "SO-" + DateTime.Now.ToString("ddMMyyHHmmssfff");
                var model1 = new SalesModel();
                var doctypeId = _docTypeRepository.All().Where(x => x.DocType == "Sales order").Select(x => x.Id).FirstOrDefault();

                model1.Id = model.Id;
                model1.CustomerId = int.Parse(model.CustomerId);
                model1.EmailId = model.EmailId;
                model1.PrimaryAddress = model.PrimaryAddress;
                model1.SalesDate = dateTime;
                model1.DueDate = DateTime.Parse(model.DueDate);
                model1.ShippingVia = model.ShippingVia;
                model1.ShippingDate = DateTime.Parse(model.ShippingDate);
                model1.TrackingNo = model.TrackingNo;
                model1.SaleCode = uniqueNumber;
                model1.SecoundaryAddress = model.SecoundaryAddress;
                model1.ShippingTo = model.ShippingTo;
                model1.MessageInvoice = model.MessageInvoice;
                model1.MessageStatement = model.MessageStatement;
                model1.Total = model.Total;
                model1.SubTotal = model.SubTotal;
                model1.TotalVat = (decimal)model.TotalVat;
                model1.Shipping = model.Shipping;
                model1.ShippingTax = model.ShippingTax;
                model1.AmountsAre = model.AmountsAre;
                model1.NetAmount = (decimal)model.Total;
                model1.Notes = model.Notes;
                model1.StatusRemarks = "Open";
                model1.DocTypeId = doctypeId;
                model1.WarehouseIdMain = model.WarehouseIdMain;
                model1.IsRecurring = model.IsRecurring;

                var custname = customerRepository.Find(model1.CustomerId);
                model1.CustomerName = custname.Name;
                List<SalesItemsModel> ls = new List<SalesItemsModel>();
                List<SalesProductTaxModel> lt = new List<SalesProductTaxModel>();
                if (model.SalesItemVM.Count > 0)
                {

                    foreach (var item in model.SalesItemVM)
                    {
                        var salesitem = new SalesItemsModel();
                        if (item.ProductId != "" && item.ServiceDate != null)
                        {
                            salesitem.Id = 0;
                            salesitem.ServiceDate = DateTime.Parse(item.ServiceDate);
                            salesitem.ProductId = int.Parse(item.ProductId);
                            salesitem.Description = item.Description;
                            salesitem.Quantity = double.Parse(item.Quantity);
                            salesitem.Price = float.Parse(item.Price);
                            salesitem.DefaultPrice = float.Parse(item.DefaultPrice);
                            salesitem.Amount = float.Parse(item.Amount);
                            salesitem.ComId = ComId ?? 0;
                            if (item.Id > 0)
                            {
                                salesitem.SalesItemsId = item.Id;
                            }

                            salesitem.WarehouseId = item.WarehouseId;
                            salesitem.WHName = item.WHName;
                            if (item.MasterTaxId == "0" || item.MasterTaxId == null)
                            {
                                salesitem.MasterTaxId = 0;
                                salesitem.MasterTaxName = "";
                            }
                            else
                            {
                                salesitem.MasterTaxId = int.Parse(item.MasterTaxId);
                                var mastertaxname = _mastersalestaxRepository.Find(salesitem.MasterTaxId);
                                salesitem.MasterTaxName = mastertaxname.Name;
                            }


                            var productname = productRepository.Find(salesitem.ProductId);
                            salesitem.Name = productname.Name;


                            ls.Add(salesitem);
                        }
                    }

                }
                if (model.SalesProductTaxVM.Count > 0)
                {

                    foreach (var item in model.SalesProductTaxVM)
                    {
                        var salesitem = new SalesProductTaxModel();
                        salesitem.Id = 0;
                        salesitem.Nickname = item.Nickname;
                        salesitem.IsSum = item.IsSum;
                        salesitem.Amount = float.Parse(item.Amount);
                        salesitem.TotalAmount = float.Parse(item.TotalAmount);
                        salesitem.TaxId = item.TaxId;
                        salesitem.ComId = ComId ?? 0;



                        lt.Add(salesitem);
                    }

                }
                List<SalesTagModel> ltag = new List<SalesTagModel>();
                if (model.SalesTags.Count > 0)
                {
                    foreach (var item in model.SalesTags)
                    {
                        var salesTags = new SalesTagModel();
                        var newtag = new TagsModel();

                        if (item.Any(char.IsLetter))
                        {
                            newtag.ComId = ComId ?? 0;
                            newtag.TagsType = "G";
                            newtag.TagShortName = item;
                            newtag.TagName = item;

                            tagsRepository.Insert(newtag);

                            salesTags.TagsId = newtag.Id;
                            salesTags.ComId = ComId ?? 0;
                            ltag.Add(salesTags);
                        }
                        else
                        {
                            salesTags.TagsId = int.Parse(item);
                            salesTags.ComId = ComId ?? 0;
                            ltag.Add(salesTags);
                        }

                    }
                }
                if (ltag != null)
                {
                    model1.SalesTags = ltag;
                }
                if (ls != null)
                {
                    model1.Items = ls;
                }
                if (lt != null)
                {
                    model1.SalesProductTax = lt;
                }
                saleRepository.Insert(model1);
                return Json(new { error = false, message = "Sales Order saved successfully", Id = model1.Id });

            }
            else
            {
                var model1 = new SalesModel();
                var doctypeId = _docTypeRepository.All().Where(x => x.DocType == "Sales order").Select(x => x.Id).FirstOrDefault();
                var oldModel = saleRepository.All().Where(x => x.Id == model.Id).FirstOrDefault();

                model1.Id = model.Id;
                model1.CustomerId = int.Parse(model.CustomerId);
                model1.EmailId = model.EmailId;
                model1.PrimaryAddress = model.PrimaryAddress;
                model1.SalesDate = DateTime.Parse(model.SalesDate);
                model1.DocTypeId = doctypeId;
                model1.WarehouseIdMain = model.WarehouseIdMain;
                model1.IsRecurring = model.IsRecurring;
                model1.DueDate = DateTime.Parse(model.DueDate);
                model1.ShippingVia = model.ShippingVia;
                model1.ShippingDate = DateTime.Parse(model.ShippingDate);
                model1.TrackingNo = model.TrackingNo;
                model1.SaleCode = model.SaleCode;
                model1.SecoundaryAddress = model.SecoundaryAddress;
                model1.ShippingTo = model.ShippingTo;
                model1.MessageInvoice = model.MessageInvoice;
                model1.MessageStatement = model.MessageStatement;
                model1.Total = model.Total;
                model1.SubTotal = model.SubTotal;
                model1.TotalVat = (decimal)model.TotalVat;
                model1.Shipping = model.Shipping;
                model1.ShippingTax = model.ShippingTax;
                model1.AmountsAre = model.AmountsAre;
                model1.NetAmount = (decimal)model.Total;
                model1.Notes = model.Notes;
                model1.StatusRemarks = "Open";
                model1.FileName = oldModel.FileName;

                var custname = customerRepository.Find(model1.CustomerId);
                model1.CustomerName = custname.Name;
                List<SalesItemsModel> ls = new List<SalesItemsModel>();
                if (model.SalesItemVM != null)
                {
                    var nonZeroId = new List<int>();
                    nonZeroId = saleItemRepository.All().Where(x => x.SalesId == model.Id).Select(y => y.Id).ToList();

                    foreach (var item in model.SalesItemVM)
                    {
                        var salesitem = new SalesItemsModel();

                        var id = item.Id;
                        if (id == 0)
                        {
                            salesitem.Id = 0;
                            salesitem.SalesId = model.Id;
                            salesitem.ServiceDate = DateTime.Parse(item.ServiceDate);
                            salesitem.ProductId = int.Parse(item.ProductId);
                            salesitem.Description = item.Description;
                            salesitem.Quantity = double.Parse(item.Quantity);
                            salesitem.Price = float.Parse(item.Price);
                            salesitem.DefaultPrice = float.Parse(item.DefaultPrice);
                            salesitem.Amount = float.Parse(item.Amount);
                            salesitem.ComId = ComId ?? 0;
                            salesitem.WarehouseId = item.WarehouseId;
                            salesitem.WHName = item.WHName;
                            if (item.MasterTaxId == null || item.MasterTaxId == "0")
                            {
                                salesitem.MasterTaxId = 0;
                                salesitem.MasterTaxName = "";
                            }
                            else
                            {
                                salesitem.MasterTaxId = int.Parse(item.MasterTaxId);
                                var mastertaxname = _mastersalestaxRepository.Find(salesitem.MasterTaxId);
                                salesitem.MasterTaxName = mastertaxname.Name;

                            }

                            var productname = productRepository.Find(salesitem.ProductId);
                            salesitem.Name = productname.Name;


                            saleItemRepository.Insert(salesitem);
                        }
                        else
                        {
                            if (nonZeroId.Contains(id))
                            {
                                // Remove the element
                                nonZeroId.Remove(id);
                            }

                            salesitem = saleItemRepository.Find(id);
                            salesitem.Id = id;
                            salesitem.ServiceDate = DateTime.Parse(item.ServiceDate);
                            salesitem.ProductId = int.Parse(item.ProductId);
                            salesitem.Description = item.Description;
                            salesitem.Quantity = double.Parse(item.Quantity);
                            salesitem.Price = float.Parse(item.Price);
                            salesitem.DefaultPrice = float.Parse(item.DefaultPrice);
                            salesitem.Amount = float.Parse(item.Amount);
                            salesitem.ComId = ComId ?? 0;
                            salesitem.WarehouseId = item.WarehouseId;
                            salesitem.WHName = item.WHName;

                            if (item.MasterTaxId == null || item.MasterTaxId == "0")
                            {
                                salesitem.MasterTaxId = 0;
                                salesitem.MasterTaxName = "";
                            }
                            else
                            {
                                salesitem.MasterTaxId = int.Parse(item.MasterTaxId);
                                var mastertaxname = _mastersalestaxRepository.Find(salesitem.MasterTaxId);
                                salesitem.MasterTaxName = mastertaxname.Name;

                            }

                            var productname = productRepository.Find(salesitem.ProductId);
                            salesitem.Name = productname.Name;


                            //ls.Add(salesitem);
                            saleItemRepository.Update(salesitem, id);

                        }

                    }

                    if (nonZeroId.Count > 0)
                    {
                        foreach (var id in nonZeroId)
                        {
                            var items = saleItemRepository.All().Where(x => x.Id == id).FirstOrDefault();
                            saleItemRepository.Delete(items);
                        }
                    }

                }
                var data = salesProductTaxRepository.All().Where(x => x.SalesId == model1.Id).ToList();
                if (data != null || data.Count > 0)
                {
                    foreach (var item in data)
                    {
                        salesProductTaxRepository.Delete(item);
                    }
                }
                if (model.SalesProductTaxVM != null)
                {
                    var temp = new SalesProductTaxModel();
                    foreach (var item in model.SalesProductTaxVM)
                    {
                        temp.Id = 0;
                        temp.SalesId = model1.Id;
                        temp.Nickname = item.Nickname;
                        temp.IsSum = item.IsSum;
                        temp.Amount = float.Parse(item.Amount);
                        temp.TotalAmount = float.Parse(item.TotalAmount);
                        temp.TaxId = item.TaxId;
                        temp.ComId = ComId ?? 0;
                        salesProductTaxRepository.Insert(temp);
                    }

                }

                var tagsData = salesTagRepository.All().Where(x => x.SalesId == model1.Id).ToList();
                if (tagsData.Count > 0)
                {
                    foreach (var tag in tagsData)
                    {
                        salesTagRepository.Delete(tag);
                    }
                }

                if (model.SalesTags.Count > 0)
                {
                    foreach (var item in model.SalesTags)
                    {
                        var salesTags = new SalesTagModel();
                        var newtag = new TagsModel();

                        if (item.Any(char.IsLetter))
                        {
                            newtag.ComId = ComId ?? 0;
                            newtag.TagsType = "G";
                            newtag.TagShortName = item;
                            newtag.TagName = item;

                            tagsRepository.Insert(newtag);

                            salesTags.TagsId = newtag.Id;
                            salesTags.SalesId = model1.Id;
                            salesTags.ComId = ComId ?? 0;
                            salesTagRepository.Insert(salesTags);
                        }
                        else
                        {
                            salesTags.TagsId = int.Parse(item);
                            salesTags.ComId = ComId ?? 0;
                            salesTags.SalesId = model1.Id;
                            salesTagRepository.Insert(salesTags);
                        }

                    }
                }
                saleRepository.Update(model1, model1.Id);
                return Json(new { error = false, message = "Sales Order Updated successfully", Id = model1.Id });

            }
        }

        [AllowAnonymous]
        [HttpGet]
        public IActionResult EditSalesOrder(int id)
        {
            var ComId = HttpContext.Session.GetInt32("ComId");

            ViewBag.Customers = customerRepository.All().Where(p => p.ComId == ComId)
                       .Select(x => new SelectListItem
                       {
                           Text = x.Name,
                           Value = x.Id.ToString()
                       });

            ViewBag.WarehouseIdMain = _warehouseRepository.All().Where(x => x.ComId == ComId)
                           .Select(x => new SelectListItem
                           {
                               Text = x.WhName,
                               Value = x.Id.ToString()
                           });

            var taxes = _mastersalestaxRepository.All().Where(f => f.ComId == ComId).ToList();
            SelectList taxList = new SelectList(taxes, "Id", "Name");
            ViewData["TaxList"] = taxList;

            ViewBag.TransactionType = "Sales_Order";
            ViewBag.ActionType = "Edit";
            ViewBag.Id = id;
            var products = productRepository.All().Where(p => p.ComId == ComId).ToList();

            SelectList productslist = new SelectList(products, "Id", "Name");
            ViewData["ProductList"] = productslist;

            var agency = _agencyRepository.All();
            var data = agency.ToList();
            SelectList agencyList = new SelectList(data, "Id", "AgencyName");

            ViewData["AgencyList"] = agencyList;
            var data1 = saleRepository.All().Where(x => x.Id == id).FirstOrDefault();

            var taxCalculation = new List<SelectListItem>
            {
                new SelectListItem { Text = "Exclusive of Tax", Value = "exclusive" },
                new SelectListItem { Text = "Inclusive of Tax", Value = "inclusive" },
                new SelectListItem { Text = "Out of scope of Tax", Value = "outscope" }
            };

            var taxCalculationList = new SelectList(taxCalculation, "Value", "Text");

            ViewData["AmountsAre"] = taxCalculationList;

            return View("CreateInvoiceQB");
        }

        [HttpGet]
        [AllowAnonymous]
        public IActionResult CustomerWiseSalesOrderData(int customerid)
        {

            var ComId = HttpContext.Session.GetInt32("ComId");

            string queryname = "UpdateEstimateStatus";
            var viewquary = $"Exec {queryname}  '" + ComId + "','" + customerid + "' ";
            Console.WriteLine(viewquary);

            SqlParameter[] parameters = new SqlParameter[1];
            parameters[0] = new SqlParameter("@ComId", ComId);

            var datasetabc = new System.Data.DataSet();
            datasetabc = Helper.ExecProcMapDS(queryname, parameters);

            var salesData = saleRepository.All().Include(x => x.DocTypeList).Where(x => x.CustomerId == customerid && x.ReturnStatus != 1 && x.DocTypeList.DocType == "Estimate" && x.DocTypeList.DocFor == "Sales").ToList();

            //var doctypeId = _docTypeRepository.All().Where(x => x.DocType == "Sales order").Select(x => x.Id).FirstOrDefault();
            //if(doctypeId == 0)
            //{
            //    doctypeId = _docTypeRepository.All().Where(x => x.DocType == "Estimate").Select(x => x.Id).FirstOrDefault();
            //}


            //var salesData = saleRepository.All().Where(x => x.CustomerId == customerid && x.DocTypeId == doctypeId).ToList();

            if (salesData != null && salesData.Count >= 0)
            {
                var data = new List<invoiceGridItem>();
                foreach (var item in salesData)
                {
                    var singledata = new invoiceGridItem();
                    var openBlnc = item.Total - (double)item.PaidAmount;
                    var descp = "Estimate #" + item.SaleCode;

                    singledata.Id = item.Id;
                    singledata.DueDate = item.DueDate;
                    singledata.SalesDate = item.SalesDate;
                    singledata.Original_Amount = item.Total;
                    singledata.Open_Balance = openBlnc;
                    singledata.Description = descp;
                    singledata.CheckBox = false;
                    singledata.SalesCode = item.SaleCode;

                    data.Add(singledata);
                }
                return Json(new { Success = 1, Data = data, ex = "Data Loaded Successfully" });
            }
            return Json(new { Success = 2, ex = "Data Loaded Failed" });
        }
        #endregion


        #region Sales receipt

        [OverridableAuthorize]
        public IActionResult AddSalesReceipt()
        {
            var ComId = HttpContext.Session.GetInt32("ComId");

            ViewBag.Customers = customerRepository.All().Where(p => p.ComId == ComId).Include(x => x.Currency)
                       .Select(x => new SelectListItem
                       {
                           Text = x.Name + '-' + x.Currency.CurrencyShortName,
                           Value = x.Id.ToString()
                       });

            ViewBag.WarehouseIdMain = _warehouseRepository.All().Where(x => x.ComId == ComId)
                            .Select(x => new SelectListItem
                            {
                                Text = x.WhName,
                                Value = x.Id.ToString()
                            });
            ViewBag.ActionType = "Create";

            var type = "Sales_Receipt";

            ViewBag.TransactionType = type;

            var products = productRepository.All().Where(p => p.ComId == ComId).ToList();

            SelectList productslist = new SelectList(products, "Id", "Name");
            ViewData["ProductList"] = productslist;

            var taxes = _mastersalestaxRepository.All().Where(f => f.ComId == ComId).ToList();
            SelectList taxList = new SelectList(taxes, "Id", "Name");
            ViewData["TaxList"] = taxList;

            var agency = _agencyRepository.All();
            var data = agency.ToList();
            SelectList agencyList = new SelectList(data, "Id", "AgencyName");

            ViewData["AgencyList"] = agencyList;

            var taxCalculation = new List<SelectListItem>
            {
                new SelectListItem { Text = "Exclusive of Tax", Value = "exclusive" },
                new SelectListItem { Text = "Inclusive of Tax", Value = "inclusive" },
                new SelectListItem { Text = "Out of scope of Tax", Value = "outscope" }
            };

            var estimateStatus = new List<SelectListItem>
            {
                new SelectListItem { Text = "Pending", Value = "Pending" },
                new SelectListItem { Text = "Accepted", Value = "Accepted" },
                new SelectListItem { Text = "Closed", Value = "Closed" },
                new SelectListItem { Text = "Rejected", Value = "Rejected" }
            };

            var estimateStatusList = new SelectList(estimateStatus, "Value", "Text");
            ViewData["EstimateStatus"] = estimateStatusList;

            var taxCalculationList = new SelectList(taxCalculation, "Value", "Text");

            ViewData["CategoryList"] = accountHeadRepository.GetCashBankHeadForDropDown();

            ViewData["AmountsAre"] = taxCalculationList;

            ViewBag.Id = 0;
            return View("AddInvoiceQB");
        }

        [OverridableAuthorize]
        [HttpGet]
        public IActionResult EditSalesReceipt(int id)
        {
            try
            {

                var errors = ModelState.Where(x => x.Value.Errors.Any())
              .Select(x => new { x.Key, x.Value.Errors });

                var ComId = HttpContext.Session.GetInt32("ComId");

                ViewBag.Customers = customerRepository.All().Where(p => p.ComId == ComId).Include(x => x.Currency)
                           .Select(x => new SelectListItem
                           {
                               Text = x.Name + '-' + x.Currency.CurrencyShortName,
                               Value = x.Id.ToString()
                           });
                ViewBag.WarehouseIdMain = _warehouseRepository.All().Where(x => x.ComId == ComId)
                               .Select(x => new SelectListItem
                               {
                                   Text = x.WhName,
                                   Value = x.Id.ToString()
                               });
                var taxes = _mastersalestaxRepository.All().Where(f => f.ComId == ComId).ToList();
                SelectList taxList = new SelectList(taxes, "Id", "Name");
                ViewData["TaxList"] = taxList;

                var type = "Sales_Receipt";


                ViewBag.TransactionType = type;
                ViewBag.ActionType = "Edit";
                ViewBag.Id = id;
                var products = productRepository.All().Where(p => p.ComId == ComId).ToList();

                SelectList productslist = new SelectList(products, "Id", "Name");
                ViewData["ProductList"] = productslist;

                var agency = _agencyRepository.All();
                var data = agency.ToList();
                SelectList agencyList = new SelectList(data, "Id", "AgencyName");

                ViewData["AgencyList"] = agencyList;
                var data1 = saleRepository.All().Where(x => x.Id == id).FirstOrDefault();

                var estimateStatus = new List<SelectListItem>
            {
                new SelectListItem { Text = "Pending", Value = "Pending" },
                new SelectListItem { Text = "Accepted", Value = "Accepted" },
                new SelectListItem { Text = "Closed", Value = "Closed" },
                new SelectListItem { Text = "Rejected", Value = "Rejected" }
            };

                var estimateStatusList = new SelectList(estimateStatus, "Value", "Text");
                ViewData["EstimateStatus"] = estimateStatusList;

                var taxCalculation = new List<SelectListItem>
            {
                new SelectListItem { Text = "Exclusive of Tax", Value = "exclusive" },
                new SelectListItem { Text = "Inclusive of Tax", Value = "inclusive" },
                new SelectListItem { Text = "Out of scope of Tax", Value = "outscope" }
            };

                var taxCalculationList = new SelectList(taxCalculation, "Value", "Text");

                ViewData["AmountsAre"] = taxCalculationList;
                ViewData["CategoryList"] = accountHeadRepository.GetCashBankHeadForDropDown();

                return View("AddInvoiceQB");

            }
            catch (Exception ex)
            {

                throw ex;
            }

        }

        [AllowAnonymous]
        public IActionResult CreateSalesReceiptQB()
        {
            var ComId = HttpContext.Session.GetInt32("ComId");

            ViewBag.Customers = customerRepository.All().Where(p => p.ComId == ComId)
                       .Select(x => new SelectListItem
                       {
                           Text = x.Name + '-' + x.Currency.CurrencyShortName,
                           Value = x.Id.ToString()
                       });

            ViewBag.WarehouseIdMain = _warehouseRepository.All().Where(x => x.ComId == ComId)
                           .Select(x => new SelectListItem
                           {
                               Text = x.WhName,
                               Value = x.Id.ToString()
                           });
            ViewBag.ActionType = "Create";

            ViewBag.TransactionType = "Sales_Receipt";

            var products = productRepository.All().Where(p => p.ComId == ComId).ToList();

            SelectList productslist = new SelectList(products, "Id", "Name");
            ViewData["ProductList"] = productslist;

            var taxes = _mastersalestaxRepository.All().Where(f => f.ComId == ComId).ToList();
            SelectList taxList = new SelectList(taxes, "Id", "Name");
            ViewData["TaxList"] = taxList;

            var paymentmethods = paymentTypeRepository.All().ToList();
            SelectList paymentMethodList = new SelectList(paymentmethods, "Id", "TypeName");
            ViewData["PaymentMethod"] = paymentMethodList;

            ViewData["CategoryList"] = accountHeadRepository.GetCashBankHeadForDropDown();

            ViewBag.Id = 0;
            var taxCalculation = new List<SelectListItem>
            {
                new SelectListItem { Text = "Exclusive of Tax", Value = "exclusive" },
                new SelectListItem { Text = "Inclusive of Tax", Value = "inclusive" },
                new SelectListItem { Text = "Out of scope of Tax", Value = "outscope" }
            };

            var taxCalculationList = new SelectList(taxCalculation, "Value", "Text");

            ViewData["AmountsAre"] = taxCalculationList;

            return View("CreateInvoiceQB");
        }


        [AllowAnonymous]
        [HttpPost]
        public IActionResult SalesReceiptCreation([FromBody] SalesModelVM model)
        {
            try
            {

                var errors = ModelState.Where(x => x.Value.Errors.Any())
                .Select(x => new { x.Key, x.Value.Errors });

                string format = "dd-MMM-yyyy"; // The format of the input date string
                var ComId = HttpContext.Session.GetInt32("ComId");
                var UserId = HttpContext.Session.GetInt32("UserId");
                DateTime dateTime;
                var doctypeId = _docTypeRepository.All().Where(x => x.DocType == "Sales receipt" && x.DocFor == "Sales").Select(x => x.Id).FirstOrDefault();

                if (DateTime.TryParseExact(model.SalesDate, format, CultureInfo.InvariantCulture, DateTimeStyles.None, out dateTime))
                {
                    var temp = dateTime;
                    dateTime = temp;
                }
                if (model.Id == 0)
                {
                    DateTime now = DateTime.Now;
                    string uniqueNumber = "SR-" + DateTime.Now.ToString("ddMMyyHHmmssfff");
                    var docPrefix = docPrefixRepository.All().Where(x => x.ComId == ComId && x.DocTypeId == doctypeId).FirstOrDefault();
                    if (docPrefix != null)
                    {
                        uniqueNumber = GetSalesCode(doctypeId);
                    }
                    var model1 = new SalesModel();

                    model1.ComId = model.ComId;
                    model1.LuserId = model.LuserId;
                    model1.Id = model.Id;
                    model1.CurrencyId = model.CurrencyId;
                    model1.CustomerId = int.Parse(model.CustomerId);
                    model1.EmailId = model.EmailId;
                    model1.PrimaryAddress = model.PrimaryAddress;
                    model1.SalesDate = dateTime;
                    //model1.DueDate = DateTime.Parse(model.DueDate);

                    model1.FiscalMonthId = model.FiscalMonthId;
                    model1.ShippingVia = model.ShippingVia;
                    model1.ShippingDate = DateTime.Parse(model.ShippingDate);
                    model1.TrackingNo = model.TrackingNo;
                    model1.SaleCode = uniqueNumber;
                    model1.CurrencyRate = model.CurrencyRate;
                    model1.SecoundaryAddress = model.SecoundaryAddress;
                    model1.ShippingTo = model.ShippingTo;
                    model1.MessageInvoice = model.MessageInvoice;
                    model1.MessageStatement = model.MessageStatement;
                    model1.Total = model.Total;
                    model1.SubTotal = model.SubTotal;
                    model1.TotalVat = (decimal)model.TotalVat;
                    model1.Shipping = model.Shipping;
                    model1.ShippingTax = model.ShippingTax;
                    model1.AmountsAre = model.AmountsAre;
                    model1.NetAmount = (decimal)model.Total;
                    model1.Notes = model.Notes;
                    model1.StatusRemarks = "Paid";
                    model1.DocTypeId = doctypeId;
                    model1.WarehouseIdMain = model.WarehouseIdMain;
                    model1.IsRecurring = model.IsRecurring;
                    model1.IsRecognition = model.IsRecognition;

                    var custname = customerRepository.Find(model1.CustomerId);
                    model1.CustomerName = custname.Name;
                    List<SalesItemsModel> ls = new List<SalesItemsModel>();
                    List<SalesProductTaxModel> lt = new List<SalesProductTaxModel>();
                    List<SalesPaymentModel> lp = new List<SalesPaymentModel>();
                    if (model.SalesItemVM.Count > 0)
                    {

                        foreach (var item in model.SalesItemVM)
                        {
                            var salesitem = new SalesItemsModel();
                            if (item.ProductId != "" && item.ServiceDate != null)
                            {
                                salesitem.Id = 0;
                                salesitem.ServiceDate = DateTime.Parse(item.ServiceDate);
                                salesitem.ProductId = int.Parse(item.ProductId);
                                salesitem.Description = item.Description;
                                salesitem.Quantity = double.Parse(item.Quantity);
                                salesitem.Price = float.Parse(item.Price);
                                salesitem.SecondaryPrice = float.Parse(item.SecondaryPrice);
                                salesitem.CostPrice = float.Parse(item.CostPrice);
                                salesitem.DefaultPrice = float.Parse(item.DefaultPrice);
                                salesitem.Amount = float.Parse(item.Amount);
                                salesitem.IndDiscount = float.Parse(item.IndDiscount);
                                salesitem.ComId = ComId ?? 0;
                                salesitem.LuserId = UserId ?? 0;
                                salesitem.LuserIdUpdate = UserId ?? 0;
                                salesitem.WarehouseId = item.WarehouseId;
                                salesitem.WHName = item.WHName;
                                if (item.MasterTaxId == null || item.MasterTaxId == "0")
                                {
                                    salesitem.MasterTaxId = 0;
                                    salesitem.MasterTaxName = "";
                                }
                                else
                                {
                                    salesitem.MasterTaxId = int.Parse(item.MasterTaxId);
                                    var mastertaxname = _mastersalestaxRepository.Find(salesitem.MasterTaxId);
                                    salesitem.MasterTaxName = mastertaxname.Name;
                                }


                                var productname = productRepository.Find(salesitem.ProductId);
                                salesitem.Name = productname.Name;
                                salesitem.PrimaryUnitId = item.PrimaryUnitId;
                                salesitem.SecondaryUnitId = item.SecondaryUnitId;
                                salesitem.ConversionRate = item.ConversionRate;
                                salesitem.InputQuantity = item.InputQuantity;
                                salesitem.Unit = item.Unit;
                                //if (item.IsTax == "")
                                //{
                                //    item.IsTax = "false";
                                //}
                                //salesitem.IsTax = bool.Parse(item.IsTax);

                                ls.Add(salesitem);
                            }
                        }

                    }
                    if (model.SalesProductTaxVM.Count > 0)
                    {

                        foreach (var item in model.SalesProductTaxVM)
                        {
                            var salesitem = new SalesProductTaxModel();
                            salesitem.Id = 0;
                            salesitem.Nickname = item.Nickname;
                            salesitem.IsSum = item.IsSum;
                            salesitem.Amount = float.Parse(item.Amount);
                            salesitem.TotalAmount = float.Parse(item.TotalAmount);
                            salesitem.TaxId = item.TaxId;
                            salesitem.ComId = ComId ?? 0;



                            lt.Add(salesitem);
                        }

                    }
                    if (model.TransactionModelVM.Count > 0)
                    {

                        foreach (var item in model.TransactionModelVM)
                        {
                            var salesitem = new SalesPaymentModel();
                            salesitem.Id = 0;
                            salesitem.AccountHeadId = item.AccountHeadId;
                            salesitem.Amount = item.Amount;
                            salesitem.PaymentCardNo = item.PaymentCardNo;
                            salesitem.ComId = ComId ?? 0;



                            lp.Add(salesitem);
                        }

                    }
                    //if (model.SalesItemVM.Count > 0)
                    //{

                    //    foreach (var item in model.SalesItemVM)
                    //    {
                    //        var salesitem = new SalesItemsModel();
                    //        if (item.ProductId != "" && item.ServiceDate != null)
                    //        {
                    //            salesitem.Id = 0;
                    //            salesitem.ServiceDate = DateTime.Parse(item.ServiceDate);
                    //            salesitem.ProductId = int.Parse(item.ProductId);
                    //            salesitem.Description = item.Description;
                    //            salesitem.Quantity = int.Parse(item.Quantity);
                    //            salesitem.Price = int.Parse(item.Price);
                    //            salesitem.Amount = int.Parse(item.Amount);
                    //            salesitem.ComId = ComId ?? 0;
                    //            if (item.MasterTaxId == null)
                    //            {
                    //                salesitem.MasterTaxId = 0;
                    //                salesitem.MasterTaxName = "";
                    //            }
                    //            else
                    //            {
                    //                salesitem.MasterTaxId = int.Parse(item.MasterTaxId);
                    //                var mastertaxname = _mastersalestaxRepository.Find(salesitem.MasterTaxId);
                    //                salesitem.MasterTaxName = mastertaxname.Name;
                    //            }


                    //            var productname = productRepository.Find(salesitem.ProductId);
                    //            salesitem.Name = productname.Name;
                    //            //if (item.IsTax == "")
                    //            //{
                    //            //    item.IsTax = "false";
                    //            //}
                    //            //salesitem.IsTax = bool.Parse(item.IsTax);

                    //            ls.Add(salesitem);
                    //        }
                    //    }

                    //}
                    List<SalesTagModel> ltag = new List<SalesTagModel>();
                    if (model.SalesTags.Count > 0)
                    {
                        foreach (var item in model.SalesTags)
                        {
                            var salesTags = new SalesTagModel();
                            var newtag = new TagsModel();

                            if (item.Any(char.IsLetter))
                            {
                                newtag.ComId = ComId ?? 0;
                                newtag.TagsType = "G";
                                newtag.TagShortName = item;
                                newtag.TagName = item;

                                tagsRepository.Insert(newtag);

                                salesTags.TagsId = newtag.Id;
                                salesTags.ComId = ComId ?? 0;
                                ltag.Add(salesTags);
                            }
                            else
                            {
                                salesTags.TagsId = int.Parse(item);
                                salesTags.ComId = ComId ?? 0;
                                ltag.Add(salesTags);
                            }

                        }
                    }
                    if (ltag != null)
                    {
                        model1.SalesTags = ltag;
                    }
                    if (ls != null)
                    {
                        model1.Items = ls;
                    }
                    if (lt != null)
                    {
                        model1.SalesProductTax = lt;
                    }
                    if (lp != null)
                    {
                        model1.SalesPayments = lp;
                    }
                    saleRepository.Insert(model1);
                    return Json(new { error = false, message = "Sales Receipt saved successfully", Id = model1.Id });

                }
                else
                {
                    var model1 = new SalesModel();
                    var oldModel = saleRepository.All().Where(x => x.Id == model.Id).FirstOrDefault();
                    model1.ComId = model.ComId;
                    model1.LuserId = model.LuserId;
                    model1.Id = model.Id;
                    model1.CustomerId = int.Parse(model.CustomerId);
                    model1.EmailId = model.EmailId;
                    model1.PrimaryAddress = model.PrimaryAddress;
                    model1.SalesDate = DateTime.Parse(model.SalesDate);
                    //model1.DueDate = DateTime.Parse(model.DueDate);

                    model1.FiscalMonthId = model.FiscalMonthId;
                    model1.ShippingVia = model.ShippingVia;
                    model1.ShippingDate = DateTime.Parse(model.ShippingDate);
                    model1.TrackingNo = model.TrackingNo;
                    model1.SaleCode = model.SaleCode;
                    model1.CurrencyRate = model.CurrencyRate;

                    model1.CurrencyId = model.CurrencyId;
                    model1.SecoundaryAddress = model.SecoundaryAddress;
                    model1.ShippingTo = model.ShippingTo;
                    model1.MessageInvoice = model.MessageInvoice;
                    model1.MessageStatement = model.MessageStatement;
                    model1.Total = model.Total;
                    model1.SubTotal = model.SubTotal;
                    model1.TotalVat = (decimal)model.TotalVat;
                    model1.Shipping = model.Shipping;
                    model1.ShippingTax = model.ShippingTax;
                    model1.AmountsAre = model.AmountsAre;
                    model1.NetAmount = (decimal)model.Total;
                    model1.Notes = model.Notes;
                    model1.StatusRemarks = "Paid";
                    model1.DocTypeId = doctypeId;
                    model1.WarehouseIdMain = model.WarehouseIdMain;
                    model1.IsRecurring = model.IsRecurring;
                    model1.IsRecognition = model.IsRecognition;
                    model1.FileName = oldModel.FileName;

                    var custname = customerRepository.Find(model1.CustomerId);
                    model1.CustomerName = custname.Name;
                    List<SalesItemsModel> ls = new List<SalesItemsModel>();
                    if (model.SalesItemVM != null)
                    {
                        var nonZeroId = new List<int>();
                        nonZeroId = saleItemRepository.All().Where(x => x.SalesId == model.Id).Select(y => y.Id).ToList();

                        foreach (var item in model.SalesItemVM)
                        {
                            var salesitem = new SalesItemsModel();

                            var id = item.Id;
                            if (id == 0)
                            {
                                salesitem.Id = 0;
                                salesitem.SalesId = model.Id;
                                salesitem.ServiceDate = DateTime.Parse(item.ServiceDate);
                                salesitem.ProductId = int.Parse(item.ProductId);
                                salesitem.Description = item.Description;
                                salesitem.Quantity = double.Parse(item.Quantity);
                                salesitem.Price = float.Parse(item.Price);
                                salesitem.SecondaryPrice = float.Parse(item.SecondaryPrice);
                                salesitem.CostPrice = float.Parse(item.CostPrice);
                                salesitem.DefaultPrice = float.Parse(item.DefaultPrice);
                                salesitem.Amount = float.Parse(item.Amount);
                                salesitem.IndDiscount = float.Parse(item.IndDiscount);
                                salesitem.ComId = ComId ?? 0;
                                salesitem.LuserId = UserId ?? 0;
                                salesitem.LuserIdUpdate = UserId ?? 0;
                                salesitem.WarehouseId = item.WarehouseId;
                                salesitem.WHName = item.WHName;
                                if (item.MasterTaxId == null || item.MasterTaxId == "0")
                                {
                                    salesitem.MasterTaxId = 0;
                                    salesitem.MasterTaxName = "";
                                }
                                else
                                {
                                    salesitem.MasterTaxId = int.Parse(item.MasterTaxId);
                                    var mastertaxname = _mastersalestaxRepository.Find(salesitem.MasterTaxId);
                                    salesitem.MasterTaxName = mastertaxname.Name;

                                }

                                var productname = productRepository.Find(salesitem.ProductId);
                                salesitem.Name = productname.Name;
                                salesitem.PrimaryUnitId = item.PrimaryUnitId;
                                salesitem.SecondaryUnitId = item.SecondaryUnitId;
                                salesitem.ConversionRate = item.ConversionRate;
                                salesitem.InputQuantity = item.InputQuantity;
                                salesitem.Unit = item.Unit;

                                saleItemRepository.Insert(salesitem);
                            }
                            else
                            {
                                if (nonZeroId.Contains(id))
                                {
                                    // Remove the element
                                    nonZeroId.Remove(id);
                                }

                                salesitem = saleItemRepository.Find(id);
                                salesitem.Id = id;
                                salesitem.ServiceDate = DateTime.Parse(item.ServiceDate);
                                salesitem.ProductId = int.Parse(item.ProductId);
                                salesitem.Description = item.Description;
                                salesitem.Quantity = double.Parse(item.Quantity);
                                salesitem.Price = float.Parse(item.Price);
                                salesitem.SecondaryPrice = float.Parse(item.SecondaryPrice);
                                salesitem.CostPrice = float.Parse(item.CostPrice);
                                salesitem.DefaultPrice = float.Parse(item.DefaultPrice);
                                salesitem.Amount = float.Parse(item.Amount);
                                salesitem.IndDiscount = float.Parse(item.IndDiscount);
                                salesitem.ComId = ComId ?? 0;
                                salesitem.LuserId = UserId ?? 0;
                                salesitem.LuserIdUpdate = UserId ?? 0;
                                salesitem.WarehouseId = item.WarehouseId;

                                salesitem.WHName = item.WHName;
                                if (item.MasterTaxId == null || item.MasterTaxId == "0")
                                {
                                    salesitem.MasterTaxId = 0;
                                    salesitem.MasterTaxName = "";
                                }
                                else
                                {
                                    salesitem.MasterTaxId = int.Parse(item.MasterTaxId);
                                    var mastertaxname = _mastersalestaxRepository.Find(salesitem.MasterTaxId);
                                    salesitem.MasterTaxName = mastertaxname.Name;

                                }

                                var productname = productRepository.Find(salesitem.ProductId);
                                salesitem.Name = productname.Name;
                                salesitem.PrimaryUnitId = item.PrimaryUnitId;
                                salesitem.SecondaryUnitId = item.SecondaryUnitId;
                                salesitem.ConversionRate = item.ConversionRate;
                                salesitem.InputQuantity = item.InputQuantity;
                                salesitem.Unit = item.Unit;

                                //ls.Add(salesitem);
                                saleItemRepository.Update(salesitem, id);

                            }

                        }

                        if (nonZeroId.Count > 0)
                        {
                            foreach (var id in nonZeroId)
                            {
                                var items = saleItemRepository.All().Where(x => x.Id == id).FirstOrDefault();
                                saleItemRepository.Delete(items);
                            }
                        }

                    }
                    var data = salesProductTaxRepository.All().Where(x => x.SalesId == model1.Id).ToList();
                    if (data != null || data.Count > 0)
                    {
                        foreach (var item in data)
                        {
                            salesProductTaxRepository.Delete(item);
                        }
                    }
                    if (model.SalesProductTaxVM != null)
                    {
                        var temp = new SalesProductTaxModel();
                        foreach (var item in model.SalesProductTaxVM)
                        {
                            temp.Id = 0;
                            temp.SalesId = model1.Id;
                            temp.Nickname = item.Nickname;
                            temp.IsSum = item.IsSum;
                            temp.Amount = float.Parse(item.Amount);
                            temp.TotalAmount = float.Parse(item.TotalAmount);
                            temp.TaxId = item.TaxId;
                            temp.ComId = ComId ?? 0;
                            salesProductTaxRepository.Insert(temp);
                        }

                    }
                    var paymentdata = salesPaymentRepository.All().Where(x => x.SalesId == model1.Id).ToList();
                    if (paymentdata.Count > 0)
                    {
                        foreach (var item in paymentdata)
                        {
                            salesPaymentRepository.Delete(item);
                        }
                    }
                    if (model.TransactionModelVM.Count > 0)
                    {

                        foreach (var item in model.TransactionModelVM)
                        {
                            var salesitem = new SalesPaymentModel();
                            salesitem.Id = 0;
                            salesitem.AccountHeadId = item.AccountHeadId;
                            salesitem.Amount = item.Amount;
                            salesitem.PaymentCardNo = item.PaymentCardNo;
                            salesitem.ComId = ComId ?? 0;
                            salesitem.SalesId = model1.Id;
                            salesPaymentRepository.Insert(salesitem);
                        }

                    }

                    var tagsData = salesTagRepository.All().Where(x => x.SalesId == model1.Id).ToList();
                    if (tagsData.Count > 0)
                    {
                        foreach (var tag in tagsData)
                        {
                            salesTagRepository.Delete(tag);
                        }
                    }

                    if (model.SalesTags.Count > 0)
                    {
                        foreach (var item in model.SalesTags)
                        {
                            var salesTags = new SalesTagModel();
                            var newtag = new TagsModel();

                            if (item.Any(char.IsLetter))
                            {
                                newtag.ComId = ComId ?? 0;
                                newtag.TagsType = "G";
                                newtag.TagShortName = item;
                                newtag.TagName = item;

                                tagsRepository.Insert(newtag);

                                salesTags.TagsId = newtag.Id;
                                salesTags.SalesId = model1.Id;
                                salesTags.ComId = ComId ?? 0;
                                salesTagRepository.Insert(salesTags);
                            }
                            else
                            {
                                salesTags.TagsId = int.Parse(item);
                                salesTags.ComId = ComId ?? 0;
                                salesTags.SalesId = model1.Id;
                                salesTagRepository.Insert(salesTags);
                            }

                        }
                    }
                    saleRepository.Update(model1, model1.Id);
                    return Json(new { error = false, message = "Sales Receipt Updated successfully", Id = model1.Id });

                }
                return View(model);

            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        //[AllowAnonymous]
        //[HttpGet]
        //public IActionResult EditSalesReceipt(int id)
        //{
        //    var ComId = HttpContext.Session.GetInt32("ComId");

        //    ViewBag.Customers = customerRepository.All().Where(p => p.ComId == ComId)
        //               .Select(x => new SelectListItem
        //               {
        //                   Text = x.Name,
        //                   Value = x.Id.ToString()
        //               });

        //    ViewBag.WarehouseIdMain = _warehouseRepository.All().Where(x => x.ComId == ComId)
        //                   .Select(x => new SelectListItem
        //                   {
        //                       Text = x.WhName,
        //                       Value = x.Id.ToString()
        //                   });

        //    var taxes = _mastersalestaxRepository.All().Where(f => f.ComId == ComId).ToList();
        //    SelectList taxList = new SelectList(taxes, "Id", "Name");
        //    ViewData["TaxList"] = taxList;

        //    ViewBag.TransactionType = "Sales_Receipt";
        //    ViewBag.ActionType = "Edit";
        //    ViewBag.Id = id;
        //    var products = productRepository.All().Where(p => p.ComId == ComId).ToList();

        //    SelectList productslist = new SelectList(products, "Id", "Name");
        //    ViewData["ProductList"] = productslist;

        //    var agency = _agencyRepository.All();
        //    var data = agency.ToList();
        //    SelectList agencyList = new SelectList(data, "Id", "AgencyName");

        //    ViewData["AgencyList"] = agencyList;
        //    var data1 = saleRepository.All().Where(x => x.Id == id).FirstOrDefault();

        //    var paymentmethods = paymentTypeRepository.All().ToList();
        //    SelectList paymentMethodList = new SelectList(paymentmethods, "Id", "TypeName");
        //    ViewData["PaymentMethod"] = paymentMethodList;

        //    ViewData["CategoryList"] = accountHeadRepository.GetCashBankHeadForDropDown();

        //    var taxCalculation = new List<SelectListItem>
        //    {
        //        new SelectListItem { Text = "Exclusive of Tax", Value = "exclusive" },
        //        new SelectListItem { Text = "Inclusive of Tax", Value = "inclusive" },
        //        new SelectListItem { Text = "Out of scope of Tax", Value = "outscope" }
        //    };

        //    var taxCalculationList = new SelectList(taxCalculation, "Value", "Text");

        //    ViewData["AmountsAre"] = taxCalculationList;

        //    return View("CreateInvoiceQB");
        //}

        [AllowAnonymous]
        [HttpGet]
        public IActionResult CopySalesForm(int id, string type)
        {
            var ComId = HttpContext.Session.GetInt32("ComId");

            ViewBag.Customers = customerRepository.All().Where(p => p.ComId == ComId).Include(x => x.Currency)
                       .Select(x => new SelectListItem
                       {
                           Text = x.Name + '-' + x.Currency.CurrencyShortName,
                           Value = x.Id.ToString()
                       });

            ViewBag.WarehouseIdMain = _warehouseRepository.All().Where(x => x.ComId == ComId)
                           .Select(x => new SelectListItem
                           {
                               Text = x.WhName,
                               Value = x.Id.ToString()
                           });

            var taxes = _mastersalestaxRepository.All().Where(f => f.ComId == ComId).ToList();
            SelectList taxList = new SelectList(taxes, "Id", "Name");
            ViewData["TaxList"] = taxList;

            if (type == "Sales order")
            {
                type = "Sales_Order";
            }
            if (type == "Credit Note")
            {
                type = "Credit-note";
            }
            if (type == "Sales receipt")
            {
                type = "Sales_Receipt";
            }
            if (type == "Delayed Charge")
            {
                type = "Delayed_Charge";
            }
            ViewBag.TransactionType = type;
            ViewBag.ActionType = "Copy";
            ViewBag.Id = id;
            var products = productRepository.All().Where(p => p.ComId == ComId).ToList();

            SelectList productslist = new SelectList(products, "Id", "Name");
            ViewData["ProductList"] = productslist;

            var agency = _agencyRepository.All();
            var data = agency.ToList();
            SelectList agencyList = new SelectList(data, "Id", "AgencyName");

            ViewData["AgencyList"] = agencyList;
            var data1 = saleRepository.All().Where(x => x.Id == id).FirstOrDefault();

            var paymentmethods = paymentTypeRepository.All().ToList();
            SelectList paymentMethodList = new SelectList(paymentmethods, "Id", "TypeName");
            ViewData["PaymentMethod"] = paymentMethodList;

            ViewData["CategoryList"] = accountHeadRepository.GetCashBankHeadForDropDown();

            var taxCalculation = new List<SelectListItem>
            {
                new SelectListItem { Text = "Exclusive of Tax", Value = "exclusive" },
                new SelectListItem { Text = "Inclusive of Tax", Value = "inclusive" },
                new SelectListItem { Text = "Out of scope of Tax", Value = "outscope" }
            };

            var taxCalculationList = new SelectList(taxCalculation, "Value", "Text");

            var estimateStatus = new List<SelectListItem>
            {
                new SelectListItem { Text = "Pending", Value = "Pending" },
                new SelectListItem { Text = "Accepted", Value = "Accepted" },
                new SelectListItem { Text = "Closed", Value = "Closed" },
                new SelectListItem { Text = "Rejected", Value = "Rejected" }
            };

            var estimateStatusList = new SelectList(estimateStatus, "Value", "Text");
            ViewData["EstimateStatus"] = estimateStatusList;


            ViewData["AmountsAre"] = taxCalculationList;

            return View("CreateInvoiceQB");
        }

        [HttpGet]
        [AllowAnonymous]
        public IActionResult GetSalesReceiptDetails(int id)
        {

            var data = saleRepository.All().Where(x => x.Id == id).FirstOrDefault();
            var item = saleItemRepository.All().Where(x => x.SalesId == id).ToList();
            var productTax = salesProductTaxRepository.All().Where(x => x.SalesId == id).ToList();
            var payment = salesPaymentRepository.All().Where(x => x.SalesId == id).ToList();
            var salesTag = salesTagRepository.All().Where(x => x.SalesId == id).ToList();
            data.Items = item;
            data.SalesProductTax = productTax;
            if (payment.Count > 0)
            {
                foreach (var child in payment)
                {
                    child.DepositTo = accountHeadRepository.All().Where(x => x.Id == child.AccountHeadId).Select(x => x.AccName).FirstOrDefault();
                }
            }
            data.SalesTags = salesTag;
            data.SalesPayments = payment;
            return Json(new { Success = 1, data = data, ex = "Data Loaded Successfully" });
        }

        [HttpGet]
        [AllowAnonymous]
        public IActionResult GetAdvanceTrxDetails(int id)
        {

            var data = advanceTransactionTrackingRepository.All().Where(x => x.SalesId == id).FirstOrDefault();

            return Json(new { Success = 1, data = data, ex = "Data Loaded Successfully" });
        }

        [HttpGet]
        [AllowAnonymous]
        public IActionResult GetSalesReceiptDetails2Copy(int id)
        {

            var salesData = saleRepository.All().Where(x => x.Id == id).Include(x => x.Items).Include(x => x.SalesProductTax).Include(x => x.SalesPayments).Include(x => x.SalesTags).FirstOrDefault();

            if (salesData.SalesPayments.Count > 0)
            {
                foreach (var child in salesData.SalesPayments)
                {
                    child.DepositTo = accountHeadRepository.All().Where(x => x.Id == child.AccountHeadId).Select(x => x.AccName).FirstOrDefault();
                }
            }
            TimeSpan dueDateDiff = salesData.DueDate - salesData.SalesDate;
            if (dueDateDiff.TotalDays > 0)
            {
                salesData.DueDate = DateTime.Now.AddDays(dueDateDiff.TotalDays);
            }

            salesData.Id = 0;
            salesData.IsRecurring = false;
            salesData.SalesDate = DateTime.Now;
            salesData.ShippingDate = DateTime.Now;
            foreach (var Childitem in salesData.Items)
            {
                Childitem.Id = 0;
                Childitem.SalesId = 0;
                Childitem.ServiceDate = DateTime.Now;
            }
            foreach (var tag in salesData.SalesTags)
            {
                tag.Id = 0;
                tag.SalesId = 0;
            }
            foreach (var tax in salesData.SalesProductTax)
            {
                tax.Id = 0;
                tax.SalesId = 0;
            }
            return Json(new { Success = 1, data = salesData, ex = "Data Loaded Successfully" });
        }
        #endregion


        #region Delayed Charge

        [OverridableAuthorize]
        public IActionResult AddDelayedCharge()
        {
            var ComId = HttpContext.Session.GetInt32("ComId");

            ViewBag.Customers = customerRepository.All().Where(p => p.ComId == ComId).Include(x => x.Currency)
                       .Select(x => new SelectListItem
                       {
                           Text = x.Name + '-' + x.Currency.CurrencyShortName,
                           Value = x.Id.ToString()
                       });

            ViewBag.WarehouseIdMain = _warehouseRepository.All().Where(x => x.ComId == ComId)
                            .Select(x => new SelectListItem
                            {
                                Text = x.WhName,
                                Value = x.Id.ToString()
                            });
            ViewBag.ActionType = "Create";

            var type = "Delayed_Charge";

            ViewBag.TransactionType = type;

            var products = productRepository.All().Where(p => p.ComId == ComId).ToList();

            SelectList productslist = new SelectList(products, "Id", "Name");
            ViewData["ProductList"] = productslist;

            var taxes = _mastersalestaxRepository.All().Where(f => f.ComId == ComId).ToList();
            SelectList taxList = new SelectList(taxes, "Id", "Name");
            ViewData["TaxList"] = taxList;

            var agency = _agencyRepository.All();
            var data = agency.ToList();
            SelectList agencyList = new SelectList(data, "Id", "AgencyName");

            ViewData["AgencyList"] = agencyList;

            var taxCalculation = new List<SelectListItem>
    {
        new SelectListItem { Text = "Exclusive of Tax", Value = "exclusive" },
        new SelectListItem { Text = "Inclusive of Tax", Value = "inclusive" },
        new SelectListItem { Text = "Out of scope of Tax", Value = "outscope" }
    };

            var estimateStatus = new List<SelectListItem>
    {
        new SelectListItem { Text = "Pending", Value = "Pending" },
        new SelectListItem { Text = "Accepted", Value = "Accepted" },
        new SelectListItem { Text = "Closed", Value = "Closed" },
        new SelectListItem { Text = "Rejected", Value = "Rejected" }
    };

            var estimateStatusList = new SelectList(estimateStatus, "Value", "Text");
            ViewData["EstimateStatus"] = estimateStatusList;

            var taxCalculationList = new SelectList(taxCalculation, "Value", "Text");

            ViewData["CategoryList"] = accountHeadRepository.GetCashBankHeadForDropDown();

            ViewData["AmountsAre"] = taxCalculationList;

            ViewBag.Id = 0;
            return View("AddInvoiceQB");
        }

        [OverridableAuthorize]
        [HttpGet]
        public IActionResult EditDelayedCharge(int id)
        {
            try
            {

                var errors = ModelState.Where(x => x.Value.Errors.Any())
              .Select(x => new { x.Key, x.Value.Errors });

                var ComId = HttpContext.Session.GetInt32("ComId");

                ViewBag.Customers = customerRepository.All().Where(p => p.ComId == ComId).Include(x => x.Currency)
                           .Select(x => new SelectListItem
                           {
                               Text = x.Name + '-' + x.Currency.CurrencyShortName,
                               Value = x.Id.ToString()
                           });
                ViewBag.WarehouseIdMain = _warehouseRepository.All().Where(x => x.ComId == ComId)
                               .Select(x => new SelectListItem
                               {
                                   Text = x.WhName,
                                   Value = x.Id.ToString()
                               });
                var taxes = _mastersalestaxRepository.All().Where(f => f.ComId == ComId).ToList();
                SelectList taxList = new SelectList(taxes, "Id", "Name");
                ViewData["TaxList"] = taxList;

                var type = "Delayed_Charge";


                ViewBag.TransactionType = type;
                ViewBag.ActionType = "Edit";
                ViewBag.Id = id;
                var products = productRepository.All().Where(p => p.ComId == ComId).ToList();

                SelectList productslist = new SelectList(products, "Id", "Name");
                ViewData["ProductList"] = productslist;

                var agency = _agencyRepository.All();
                var data = agency.ToList();
                SelectList agencyList = new SelectList(data, "Id", "AgencyName");

                ViewData["AgencyList"] = agencyList;
                var data1 = saleRepository.All().Where(x => x.Id == id).FirstOrDefault();

                var estimateStatus = new List<SelectListItem>
            {
                new SelectListItem { Text = "Pending", Value = "Pending" },
                new SelectListItem { Text = "Accepted", Value = "Accepted" },
                new SelectListItem { Text = "Closed", Value = "Closed" },
                new SelectListItem { Text = "Rejected", Value = "Rejected" }
            };

                var estimateStatusList = new SelectList(estimateStatus, "Value", "Text");
                ViewData["EstimateStatus"] = estimateStatusList;

                var taxCalculation = new List<SelectListItem>
            {
                new SelectListItem { Text = "Exclusive of Tax", Value = "exclusive" },
                new SelectListItem { Text = "Inclusive of Tax", Value = "inclusive" },
                new SelectListItem { Text = "Out of scope of Tax", Value = "outscope" }
            };

                var taxCalculationList = new SelectList(taxCalculation, "Value", "Text");

                ViewData["AmountsAre"] = taxCalculationList;
                ViewData["CategoryList"] = accountHeadRepository.GetCashBankHeadForDropDown();

                return View("AddInvoiceQB");

            }
            catch (Exception ex)
            {

                throw ex;
            }

        }

        [AllowAnonymous]
        public IActionResult DelayedChargeQB()
        {
            var ComId = HttpContext.Session.GetInt32("ComId");

            ViewBag.Customers = customerRepository.All().Where(p => p.ComId == ComId)
                       .Select(x => new SelectListItem
                       {
                           Text = x.Name + '-' + x.Currency.CurrencyShortName,
                           Value = x.Id.ToString()
                       });
            ViewBag.ActionType = "Create";

            ViewBag.TransactionType = "Delayed_Charge";

            ViewBag.WarehouseIdMain = _warehouseRepository.All().Where(x => x.ComId == ComId)
                           .Select(x => new SelectListItem
                           {
                               Text = x.WhName,
                               Value = x.Id.ToString()
                           });

            var products = productRepository.All().Where(p => p.ComId == ComId).ToList();

            SelectList productslist = new SelectList(products, "Id", "Name");
            ViewData["ProductList"] = productslist;

            var taxes = _mastersalestaxRepository.All().Where(f => f.ComId == ComId).ToList();
            SelectList taxList = new SelectList(taxes, "Id", "Name");
            ViewData["TaxList"] = taxList;

            var taxCalculation = new List<SelectListItem>
            {
                new SelectListItem { Text = "Exclusive of Tax", Value = "exclusive" },
                new SelectListItem { Text = "Inclusive of Tax", Value = "inclusive" },
                new SelectListItem { Text = "Out of scope of Tax", Value = "outscope" }
            };

            var taxCalculationList = new SelectList(taxCalculation, "Value", "Text");

            ViewData["AmountsAre"] = taxCalculationList;

            ViewBag.Id = 0;
            return View("CreateInvoiceQB");
        }


        [AllowAnonymous]
        [HttpPost]
        public IActionResult DelayedChargeCreation([FromBody] SalesModelVM model)
        {
            try
            {

                var errors = ModelState.Where(x => x.Value.Errors.Any())
               .Select(x => new { x.Key, x.Value.Errors });

                string format = "dd-MMM-yyyy"; // The format of the input date string
                var ComId = HttpContext.Session.GetInt32("ComId");
                var UserId = HttpContext.Session.GetInt32("UserId");
                DateTime dateTime;

                if (DateTime.TryParseExact(model.SalesDate, format, CultureInfo.InvariantCulture, DateTimeStyles.None, out dateTime))
                {
                    var temp = dateTime;
                    dateTime = temp;
                }
                if (model.Id == 0)
                {
                    DateTime now = DateTime.Now;
                    string uniqueNumber = "DC-" + DateTime.Now.ToString("ddMMyyHHmmssfff");
                    var model1 = new SalesModel();
                    var doctypeId = _docTypeRepository.All().Where(x => x.DocType == "Delayed Charge").Select(x => x.Id).FirstOrDefault();
                    var docPrefix = docPrefixRepository.All().Where(x => x.ComId == ComId && x.DocTypeId == doctypeId).FirstOrDefault();
                    if (docPrefix != null)
                    {
                        uniqueNumber = GetSalesCode(doctypeId);
                    }

                    model1.ComId = model.ComId;
                    model1.LuserId = model.LuserId;
                    model1.Id = model.Id;
                    model1.CustomerId = int.Parse(model.CustomerId);
                    model1.EmailId = model.EmailId;
                    model1.PrimaryAddress = model.PrimaryAddress;
                    model1.SalesDate = dateTime;
                    model1.ShippingVia = model.ShippingVia;
                    model1.TrackingNo = model.TrackingNo;
                    model1.SaleCode = uniqueNumber;
                    model1.CurrencyRate = model.CurrencyRate;
                    model1.SecoundaryAddress = model.SecoundaryAddress;
                    model1.ShippingTo = model.ShippingTo;
                    model1.MessageInvoice = model.MessageInvoice;
                    model1.MessageStatement = model.MessageStatement;
                    model1.FiscalMonthId = model.FiscalMonthId;
                    model1.Total = model.Total;
                    model1.SubTotal = model.SubTotal;
                    model1.TotalVat = (decimal)model.TotalVat;
                    model1.Shipping = model.Shipping;
                    model1.ShippingTax = model.ShippingTax;
                    model1.AmountsAre = model.AmountsAre;
                    model1.NetAmount = (decimal)model.Total;
                    model1.Notes = model.Notes;
                    model1.StatusRemarks = "SalesDate " + model.SalesDate.ToString();
                    model1.DocTypeId = doctypeId;
                    model1.WarehouseIdMain = model.WarehouseIdMain;
                    model1.IsRecurring = model.IsRecurring;

                    var custname = customerRepository.Find(model1.CustomerId);
                    model1.CustomerName = custname.Name;
                    List<SalesItemsModel> ls = new List<SalesItemsModel>();
                    List<SalesProductTaxModel> lt = new List<SalesProductTaxModel>();
                    if (model.SalesItemVM.Count > 0)
                    {

                        foreach (var item in model.SalesItemVM)
                        {
                            var salesitem = new SalesItemsModel();
                            if (item.ProductId != "" && item.ServiceDate != null)
                            {
                                salesitem.Id = 0;
                                salesitem.ServiceDate = DateTime.Parse(item.ServiceDate);
                                salesitem.ProductId = int.Parse(item.ProductId);
                                salesitem.Description = item.Description;
                                salesitem.Quantity = double.Parse(item.Quantity);
                                salesitem.Price = float.Parse(item.Price);
                                salesitem.SecondaryPrice = float.Parse(item.SecondaryPrice);
                                salesitem.DefaultPrice = float.Parse(item.DefaultPrice);
                                salesitem.CostPrice = float.Parse(item.CostPrice);
                                salesitem.Amount = float.Parse(item.Amount);
                                salesitem.IndDiscount = float.Parse(item.IndDiscount);
                                salesitem.ComId = ComId ?? 0;
                                salesitem.LuserId = UserId ?? 0;
                                salesitem.LuserIdUpdate = UserId ?? 0;
                                salesitem.WarehouseId = item.WarehouseId;
                                salesitem.WHName = item.WHName;
                                if (item.MasterTaxId == null || item.MasterTaxId == "0")
                                {
                                    salesitem.MasterTaxId = 0;
                                    salesitem.MasterTaxName = "";
                                }
                                else
                                {
                                    salesitem.MasterTaxId = int.Parse(item.MasterTaxId);
                                    var mastertaxname = _mastersalestaxRepository.Find(salesitem.MasterTaxId);
                                    salesitem.MasterTaxName = mastertaxname.Name;
                                }


                                var productname = productRepository.Find(salesitem.ProductId);
                                salesitem.Name = productname.Name;
                                salesitem.PrimaryUnitId = item.PrimaryUnitId;
                                salesitem.SecondaryUnitId = item.SecondaryUnitId;
                                salesitem.ConversionRate = item.ConversionRate;
                                salesitem.InputQuantity = item.InputQuantity;
                                salesitem.Unit = item.Unit;

                                ls.Add(salesitem);
                            }
                        }

                    }
                    if (model.SalesProductTaxVM.Count > 0)
                    {

                        foreach (var item in model.SalesProductTaxVM)
                        {
                            var salesitem = new SalesProductTaxModel();
                            salesitem.Id = 0;
                            salesitem.Nickname = item.Nickname;
                            salesitem.IsSum = item.IsSum;
                            salesitem.Amount = float.Parse(item.Amount);
                            salesitem.TotalAmount = float.Parse(item.TotalAmount);
                            salesitem.TaxId = item.TaxId;
                            salesitem.ComId = ComId ?? 0;



                            lt.Add(salesitem);
                        }

                    }

                    List<SalesTagModel> ltag = new List<SalesTagModel>();
                    if (model.SalesTags.Count > 0)
                    {
                        foreach (var item in model.SalesTags)
                        {
                            var salesTags = new SalesTagModel();
                            var newtag = new TagsModel();

                            if (item.Any(char.IsLetter))
                            {
                                newtag.ComId = ComId ?? 0;
                                newtag.TagsType = "G";
                                newtag.TagShortName = item;
                                newtag.TagName = item;

                                tagsRepository.Insert(newtag);

                                salesTags.TagsId = newtag.Id;
                                salesTags.ComId = ComId ?? 0;
                                ltag.Add(salesTags);
                            }
                            else
                            {
                                salesTags.TagsId = int.Parse(item);
                                salesTags.ComId = ComId ?? 0;
                                ltag.Add(salesTags);
                            }

                        }
                    }
                    if (ltag != null)
                    {
                        model1.SalesTags = ltag;
                    }
                    if (ls != null)
                    {
                        model1.Items = ls;
                    }
                    if (lt != null)
                    {
                        model1.SalesProductTax = lt;
                    }
                    saleRepository.Insert(model1);
                    return Json(new { error = false, message = "Delayed Charge saved successfully", Id = model1.Id });

                }
                else
                {
                    var model1 = new SalesModel();
                    var doctypeId = _docTypeRepository.All().Where(x => x.DocType == "Delayed Charge").Select(x => x.Id).FirstOrDefault();
                    var oldModel = saleRepository.All().Where(x => x.Id == model.Id).FirstOrDefault();

                    model1.ComId = model.ComId;
                    model1.LuserId = model.LuserId;
                    model1.Id = model.Id;
                    model1.CustomerId = int.Parse(model.CustomerId);
                    model1.EmailId = model.EmailId;
                    model1.PrimaryAddress = model.PrimaryAddress;
                    model1.SalesDate = DateTime.Parse(model.SalesDate);
                    model1.DocTypeId = doctypeId;
                    model1.WarehouseIdMain = model.WarehouseIdMain;
                    model1.IsRecurring = model.IsRecurring;
                    model1.ShippingVia = model.ShippingVia;
                    model1.TrackingNo = model.TrackingNo;
                    model1.SaleCode = model.SaleCode;
                    model1.CurrencyRate = model.CurrencyRate;
                    model1.SecoundaryAddress = model.SecoundaryAddress;
                    model1.ShippingTo = model.ShippingTo;
                    model1.MessageInvoice = model.MessageInvoice;
                    model1.MessageStatement = model.MessageStatement;

                    model1.FiscalMonthId = model.FiscalMonthId;
                    model1.Total = model.Total;
                    model1.SubTotal = model.SubTotal;
                    model1.TotalVat = (decimal)model.TotalVat;
                    model1.Shipping = model.Shipping;
                    model1.ShippingTax = model.ShippingTax;
                    model1.AmountsAre = model.AmountsAre;
                    model1.NetAmount = (decimal)model.Total;
                    model1.Notes = model.Notes;
                    model1.StatusRemarks = "SalesDate " + model.SalesDate.ToString();
                    model1.FileName = oldModel.FileName;

                    var custname = customerRepository.Find(model1.CustomerId);
                    model1.CustomerName = custname.Name;
                    List<SalesItemsModel> ls = new List<SalesItemsModel>();
                    if (model.SalesItemVM != null)
                    {
                        var nonZeroId = new List<int>();
                        nonZeroId = saleItemRepository.All().Where(x => x.SalesId == model.Id).Select(y => y.Id).ToList();

                        foreach (var item in model.SalesItemVM)
                        {
                            var salesitem = new SalesItemsModel();

                            var id = item.Id;
                            if (id == 0)
                            {
                                salesitem.Id = 0;
                                salesitem.SalesId = model.Id;
                                salesitem.ServiceDate = DateTime.Parse(item.ServiceDate);
                                salesitem.ProductId = int.Parse(item.ProductId);
                                salesitem.Description = item.Description;
                                salesitem.Quantity = double.Parse(item.Quantity);
                                salesitem.Price = float.Parse(item.Price);
                                salesitem.SecondaryPrice = float.Parse(item.SecondaryPrice);
                                salesitem.CostPrice = float.Parse(item.CostPrice);
                                salesitem.DefaultPrice = float.Parse(item.DefaultPrice);
                                salesitem.Amount = float.Parse(item.Amount);
                                salesitem.IndDiscount = float.Parse(item.IndDiscount);
                                salesitem.ComId = ComId ?? 0;
                                salesitem.LuserId = UserId ?? 0;
                                salesitem.LuserIdUpdate = UserId ?? 0;
                                salesitem.WarehouseId = item.WarehouseId;
                                salesitem.WHName = item.WHName;
                                if (item.MasterTaxId == null || item.MasterTaxId == "0")
                                {
                                    salesitem.MasterTaxId = 0;
                                    salesitem.MasterTaxName = "";
                                }
                                else
                                {
                                    salesitem.MasterTaxId = int.Parse(item.MasterTaxId);
                                    var mastertaxname = _mastersalestaxRepository.Find(salesitem.MasterTaxId);
                                    salesitem.MasterTaxName = mastertaxname.Name;

                                }

                                var productname = productRepository.Find(salesitem.ProductId);
                                salesitem.Name = productname.Name;
                                salesitem.PrimaryUnitId = item.PrimaryUnitId;
                                salesitem.SecondaryUnitId = item.SecondaryUnitId;
                                salesitem.ConversionRate = item.ConversionRate;
                                salesitem.InputQuantity = item.InputQuantity;
                                salesitem.Unit = item.Unit;

                                saleItemRepository.Insert(salesitem);
                            }
                            else
                            {
                                if (nonZeroId.Contains(id))
                                {
                                    // Remove the element
                                    nonZeroId.Remove(id);
                                }

                                salesitem = saleItemRepository.Find(id);
                                salesitem.Id = id;
                                salesitem.ServiceDate = DateTime.Parse(item.ServiceDate);
                                salesitem.ProductId = int.Parse(item.ProductId);
                                salesitem.Description = item.Description;
                                salesitem.Quantity = double.Parse(item.Quantity);
                                salesitem.Price = float.Parse(item.Price);
                                salesitem.SecondaryPrice = float.Parse(item.SecondaryPrice);
                                salesitem.CostPrice = float.Parse(item.CostPrice);
                                salesitem.DefaultPrice = float.Parse(item.DefaultPrice);
                                salesitem.Amount = float.Parse(item.Amount);
                                salesitem.IndDiscount = float.Parse(item.IndDiscount);
                                salesitem.ComId = ComId ?? 0;
                                salesitem.LuserId = UserId ?? 0;
                                salesitem.LuserIdUpdate = UserId ?? 0;
                                salesitem.WarehouseId = item.WarehouseId;
                                salesitem.WHName = item.WHName;

                                if (item.MasterTaxId == null || item.MasterTaxId == "0")
                                {
                                    salesitem.MasterTaxId = 0;
                                    salesitem.MasterTaxName = "";
                                }
                                else
                                {
                                    salesitem.MasterTaxId = int.Parse(item.MasterTaxId);
                                    var mastertaxname = _mastersalestaxRepository.Find(salesitem.MasterTaxId);
                                    salesitem.MasterTaxName = mastertaxname.Name;

                                }

                                var productname = productRepository.Find(salesitem.ProductId);
                                salesitem.Name = productname.Name;
                                salesitem.PrimaryUnitId = item.PrimaryUnitId;
                                salesitem.SecondaryUnitId = item.SecondaryUnitId;
                                salesitem.ConversionRate = item.ConversionRate;
                                salesitem.InputQuantity = item.InputQuantity;
                                salesitem.Unit = item.Unit;

                                //ls.Add(salesitem);
                                saleItemRepository.Update(salesitem, id);

                            }

                        }

                        if (nonZeroId.Count > 0)
                        {
                            foreach (var id in nonZeroId)
                            {
                                var items = saleItemRepository.All().Where(x => x.Id == id).FirstOrDefault();
                                saleItemRepository.Delete(items);
                            }
                        }

                    }
                    var data = salesProductTaxRepository.All().Where(x => x.SalesId == model1.Id).ToList();
                    if (data != null || data.Count > 0)
                    {
                        foreach (var item in data)
                        {
                            salesProductTaxRepository.Delete(item);
                        }
                    }
                    if (model.SalesProductTaxVM != null)
                    {
                        var temp = new SalesProductTaxModel();
                        foreach (var item in model.SalesProductTaxVM)
                        {
                            temp.Id = 0;
                            temp.SalesId = model1.Id;
                            temp.Nickname = item.Nickname;
                            temp.IsSum = item.IsSum;
                            temp.Amount = float.Parse(item.Amount);
                            temp.TotalAmount = float.Parse(item.TotalAmount);
                            temp.TaxId = item.TaxId;
                            temp.ComId = ComId ?? 0;
                            salesProductTaxRepository.Insert(temp);
                        }

                    }
                    var tagsData = salesTagRepository.All().Where(x => x.SalesId == model1.Id).ToList();
                    if (tagsData.Count > 0)
                    {
                        foreach (var tag in tagsData)
                        {
                            salesTagRepository.Delete(tag);
                        }
                    }

                    if (model.SalesTags.Count > 0)
                    {
                        foreach (var item in model.SalesTags)
                        {
                            var salesTags = new SalesTagModel();
                            var newtag = new TagsModel();

                            if (item.Any(char.IsLetter))
                            {
                                newtag.ComId = ComId ?? 0;
                                newtag.TagsType = "G";
                                newtag.TagShortName = item;
                                newtag.TagName = item;

                                tagsRepository.Insert(newtag);

                                salesTags.TagsId = newtag.Id;
                                salesTags.SalesId = model1.Id;
                                salesTags.ComId = ComId ?? 0;
                                salesTagRepository.Insert(salesTags);
                            }
                            else
                            {
                                salesTags.TagsId = int.Parse(item);
                                salesTags.ComId = ComId ?? 0;
                                salesTags.SalesId = model1.Id;
                                salesTagRepository.Insert(salesTags);
                            }

                        }
                    }
                    saleRepository.Update(model1, model1.Id);
                    return Json(new { error = false, message = "Delayed Charge Updated successfully", Id = model1.Id });

                }

            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        //[AllowAnonymous]
        //[HttpGet]
        //public IActionResult EditDelayedCharge(int id)
        //{
        //    var ComId = HttpContext.Session.GetInt32("ComId");

        //    ViewBag.Customers = customerRepository.All().Where(p => p.ComId == ComId)
        //               .Select(x => new SelectListItem
        //               {
        //                   Text = x.Name,
        //                   Value = x.Id.ToString()
        //               });

        //    ViewBag.WarehouseIdMain = _warehouseRepository.All().Where(x => x.ComId == ComId)
        //                   .Select(x => new SelectListItem
        //                   {
        //                       Text = x.WhName,
        //                       Value = x.Id.ToString()
        //                   });

        //    var taxes = _mastersalestaxRepository.All().Where(f => f.ComId == ComId).ToList();
        //    SelectList taxList = new SelectList(taxes, "Id", "Name");
        //    ViewData["TaxList"] = taxList;

        //    ViewBag.TransactionType = "Delayed_Charge";
        //    ViewBag.ActionType = "Edit";
        //    ViewBag.Id = id;
        //    var products = productRepository.All().Where(p => p.ComId == ComId).ToList();

        //    SelectList productslist = new SelectList(products, "Id", "Name");
        //    ViewData["ProductList"] = productslist;

        //    var agency = _agencyRepository.All();
        //    var data = agency.ToList();
        //    SelectList agencyList = new SelectList(data, "Id", "AgencyName");

        //    ViewData["AgencyList"] = agencyList;
        //    var data1 = saleRepository.All().Where(x => x.Id == id).FirstOrDefault();

        //    var taxCalculation = new List<SelectListItem>
        //    {
        //        new SelectListItem { Text = "Exclusive of Tax", Value = "exclusive" },
        //        new SelectListItem { Text = "Inclusive of Tax", Value = "inclusive" },
        //        new SelectListItem { Text = "Out of scope of Tax", Value = "outscope" }
        //    };

        //    var taxCalculationList = new SelectList(taxCalculation, "Value", "Text");

        //    ViewData["AmountsAre"] = taxCalculationList;

        //    return View("CreateInvoiceQB");
        //}
        #endregion

        #region  Stock Count

        [AllowAnonymous]
        public IActionResult CreateStockCount()
        {
            var ComId = HttpContext.Session.GetInt32("ComId");

            ViewBag.Customers = customerRepository.All().Where(p => p.ComId == 0 && p.Name == "Working Customer")
                       .Select(x => new SelectListItem
                       {
                           Text = x.Name,
                           Value = x.Id.ToString()
                       });
            ViewBag.ActionType = "Create";

            ViewBag.WarehouseIdMain = _warehouseRepository.All().Where(x => x.ComId == ComId)
                           .Select(x => new SelectListItem
                           {
                               Text = x.WhName,
                               Value = x.Id.ToString()
                           });

            ViewBag.TransactionType = "Stock Count";

            var products = productRepository.All().Where(p => p.ComId == ComId).ToList();

            SelectList productslist = new SelectList(products, "Id", "Name");
            ViewData["ProductList"] = productslist;

            var taxes = _mastersalestaxRepository.All().Where(f => f.ComId == ComId).ToList();
            SelectList taxList = new SelectList(taxes, "Id", "Name");
            ViewData["TaxList"] = taxList;

            var taxCalculation = new List<SelectListItem>
            {
                new SelectListItem { Text = "Exclusive of Tax", Value = "exclusive" },
                new SelectListItem { Text = "Inclusive of Tax", Value = "inclusive" },
                new SelectListItem { Text = "Out of scope of Tax", Value = "outscope" }
            };

            var taxCalculationList = new SelectList(taxCalculation, "Value", "Text");

            ViewData["AmountsAre"] = taxCalculationList;

            ViewBag.Id = 0;
            return View();
        }

        [AllowAnonymous]
        [HttpPost]
        public IActionResult StockCountCreation([FromBody] StockCountModelVM model)
        {
            string format = "dd-MMM-yyyy"; // The format of the input date string
            var ComId = HttpContext.Session.GetInt32("ComId");
            DateTime dateTime;


            if (model.Id == 0)
            {
                DateTime now = DateTime.Now;
                string uniqueNumber = "StC-" + DateTime.Now.ToString("ddMMyyHHmmssfff");
                var model1 = new SalesModel();
                var doctypeId = _docTypeRepository.All().Where(x => x.DocType == "Stock Count").Select(x => x.Id).FirstOrDefault();

                model1.Id = model.Id;
                model1.CustomerId = model.CustomerId == null ? customerRepository.All().Where(p => p.ComId == 0 && p.Name == "Working Customer")
                       .Select(x => x.Id).FirstOrDefault() : int.Parse(model.CustomerId);

                model1.DocTypeId = doctypeId;
                //var custname = customerRepository.All().Where(x=>x.Id == model1.CustomerId && x.ComId == 0).FirstOrDefault();
                model1.CustomerName = "Working Customer";
                model1.StatusRemarks = "Applied";
                model1.SaleCode = uniqueNumber;
                model1.SalesDate = DateTime.Now;
                List<SalesItemsModel> ls = new List<SalesItemsModel>();

                if (model.StockCountItem.Count > 0)
                {

                    foreach (var item in model.StockCountItem)
                    {
                        var salesitem = new SalesItemsModel();
                        if (item.ProductId != "" && item.ServiceDate != null)
                        {
                            salesitem.Id = 0;
                            salesitem.ServiceDate = DateTime.Parse(item.ServiceDate);
                            salesitem.ProductId = int.Parse(item.ProductId);
                            salesitem.Description = item.Description;
                            salesitem.Quantity = double.Parse(item.Quantity);
                            salesitem.ComId = ComId ?? 0;
                            salesitem.IsTax = false;
                            salesitem.WarehouseId = item.WarehouseId;
                            salesitem.WHName = item.WHName;


                            var productname = productRepository.Find(salesitem.ProductId);
                            salesitem.Name = productname.Name;
                            //if (item.IsTax == "")
                            //{
                            //    item.IsTax = "false";
                            //}
                            //salesitem.IsTax = bool.Parse(item.IsTax);

                            ls.Add(salesitem);
                        }
                    }

                }


                if (ls != null)
                {
                    model1.Items = ls;
                }


                try
                {
                    saleRepository.Insert(model1);
                    return Json(new { error = false, message = "Stock Count saved successfully", Id = model1.Id });
                }
                catch (Exception ex)
                {
                    return Json(new { success = false, values = ex.Message.ToString() });
                }

            }
            else
            {
                var model1 = new SalesModel();
                var doctypeId = _docTypeRepository.All().Where(x => x.DocType == "Stock Count").Select(x => x.Id).FirstOrDefault();
                var oldModel = saleRepository.All().Where(x => x.Id == model.Id).FirstOrDefault();

                model1.Id = model.Id;
                model1.CustomerId = oldModel.CustomerId;
                model1.DocTypeId = doctypeId;
                model1.SalesDate = oldModel.SalesDate;
                model1.StatusRemarks = "Applied";
                model1.SaleCode = oldModel.SaleCode;

                //var custname = customerRepository.All().Where(x => x.Id == model1.CustomerId).FirstOrDefault();
                model1.CustomerName = "Working Customer";
                List<SalesItemsModel> ls = new List<SalesItemsModel>();
                if (model.StockCountItem != null)
                {
                    var nonZeroId = new List<int>();
                    nonZeroId = saleItemRepository.All().Where(x => x.SalesId == model.Id).Select(y => y.Id).ToList();

                    foreach (var item in model.StockCountItem)
                    {
                        var salesitem = new SalesItemsModel();

                        var id = item.Id;
                        if (id == 0)
                        {
                            salesitem.Id = 0;
                            salesitem.SalesId = model.Id;
                            salesitem.ServiceDate = DateTime.Parse(item.ServiceDate);
                            salesitem.ProductId = int.Parse(item.ProductId);
                            salesitem.Description = item.Description;
                            salesitem.Quantity = double.Parse(item.Quantity);

                            salesitem.ComId = ComId ?? 0;
                            salesitem.WarehouseId = item.WarehouseId;
                            salesitem.WHName = item.WHName;


                            var productname = productRepository.Find(salesitem.ProductId);
                            salesitem.Name = productname.Name;


                            saleItemRepository.Insert(salesitem);
                        }
                        else
                        {

                            salesitem = saleItemRepository.Find(id);
                            salesitem.Id = id;
                            salesitem.ServiceDate = DateTime.Parse(item.ServiceDate);
                            salesitem.ProductId = int.Parse(item.ProductId);
                            salesitem.Description = item.Description;
                            salesitem.Quantity = double.Parse(item.Quantity);

                            salesitem.ComId = ComId ?? 0;
                            salesitem.WarehouseId = item.WarehouseId;
                            salesitem.WHName = item.WHName;



                            var productname = productRepository.Find(salesitem.ProductId);
                            salesitem.Name = productname.Name;


                            saleItemRepository.Update(salesitem, id);

                        }

                    }



                }

                saleRepository.Update(model1, model1.Id);
                return Json(new { error = false, message = "Stock Count Updated successfully", Id = model1.Id });

            }
            return View(model);
        }

        [AllowAnonymous]
        [HttpGet]
        public IActionResult EditStockCount(int id)
        {
            var ComId = HttpContext.Session.GetInt32("ComId");

            ViewBag.Customers = customerRepository.All().Where(p => p.ComId == 0)
                       .Select(x => new SelectListItem
                       {
                           Text = x.Name,
                           Value = x.Id.ToString()
                       });

            ViewBag.WarehouseIdMain = _warehouseRepository.All().Where(x => x.ComId == ComId)
                           .Select(x => new SelectListItem
                           {
                               Text = x.WhName,
                               Value = x.Id.ToString()
                           });

            var taxes = _mastersalestaxRepository.All().Where(f => f.ComId == ComId).ToList();
            SelectList taxList = new SelectList(taxes, "Id", "Name");
            ViewData["TaxList"] = taxList;

            ViewBag.TransactionType = "Stock Count";
            ViewBag.ActionType = "Edit";
            ViewBag.Id = id;
            var products = productRepository.All().Where(p => p.ComId == ComId).ToList();

            SelectList productslist = new SelectList(products, "Id", "Name");
            ViewData["ProductList"] = productslist;

            var agency = _agencyRepository.All();
            var data = agency.ToList();
            SelectList agencyList = new SelectList(data, "Id", "AgencyName");

            ViewData["AgencyList"] = agencyList;
            var data1 = saleRepository.All().Where(x => x.Id == id).FirstOrDefault();

            var taxCalculation = new List<SelectListItem>
            {
                new SelectListItem { Text = "Exclusive of Tax", Value = "exclusive" },
                new SelectListItem { Text = "Inclusive of Tax", Value = "inclusive" },
                new SelectListItem { Text = "Out of scope of Tax", Value = "outscope" }
            };

            var taxCalculationList = new SelectList(taxCalculation, "Value", "Text");

            ViewData["AmountsAre"] = taxCalculationList;

            return View("CreateStockCount");
        }

        #endregion


        #region ColumnFilter

        [AllowAnonymous]
        [HttpPost]
        public IActionResult ColumnFilterCreation([FromBody] ColumnFilterRequest request)
        {
            try
            {
                var ComId = HttpContext.Session.GetInt32("ComId");
                var UserId = HttpContext.Session.GetInt32("UserId");

                var columnFilter = columnFilterRepository.All().Where(x => x.LuserId == UserId && x.ListName == request.type && x.ComId == ComId).FirstOrDefault();

                if(columnFilter == null)
                {
                    var model = new ColumnFilterModel();
                    model.ListName = request.type;
                    model.KeyValue = request.keyValue;

                    columnFilterRepository.Insert(model);
                }
                else
                {
                    columnFilter.ListName = request.type;
                    columnFilter.KeyValue = request.keyValue;

                    columnFilterRepository.Update(columnFilter, columnFilter.Id);
                }

               

                return Json(new { Success = 1, ex = "Data saved Successfully" });
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        [AllowAnonymous]
        public IActionResult GetFilteredColumn(string type)
        {
            var ComId = HttpContext.Session.GetInt32("ComId");
            var UserId = HttpContext.Session.GetInt32("UserId");

            var columnFilter = columnFilterRepository.All().Where(x => x.LuserId == UserId && x.ListName == type && x.ComId == ComId).FirstOrDefault();

            if (columnFilter == null)
            {
                return Json(new { Success = 0});
            }
            else
            {
                return Json(new { Success = 1, data = columnFilter });
            }
        }

        [AllowAnonymous]
        [HttpGet]
        public JsonResult DeleteColumnFilter(ColumnFilterRemove Filter)
        {
            try
            {

                var ComId = HttpContext.Session.GetInt32("ComId");
                var UserId = HttpContext.Session.GetInt32("UserId");

                var columnFilter = columnFilterRepository.All().Where(x => x.LuserId == UserId && x.ListName == Filter.type && x.ComId == ComId).FirstOrDefault();

                if (columnFilter != null)
                {
                    columnFilter.ListName = Filter.type;

                    columnFilterRepository.Delete(columnFilter);
                    return Json(new { success = "1", msg = "Deleted Successfully" });
                }
                

                //var model = columnFilterRepository.Find(id);

                //if (model != null)
                //{

                //    columnFilterRepository.Delete(model);

                //    return Json(new { success = "1", msg = "Deleted Successfully" });
                //}
                return Json(new { success = "0", msg = "No items found to delete." });
                
            }
            catch (Exception ex)
            {
                return Json(new { success = "0", msg = "No items found to delete." }); //msg = ex.ToString()
                throw ex;
            }
        }

        public class ColumnFilterRequest
        {
            public string keyValue { get; set; }
            public string type { get; set; }
        }


        public class ColumnFilterRemove
        {          
            public string type { get; set; }
        }

        #endregion



        [AllowAnonymous]
        public JsonResult GetSalesListTabulator(int? UserId, int page = 1, decimal size = 5, string searchquery = "", string FromDate = "", string ToDate = "")
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


                var salelist = saleRepository.All().Where(x => x.ComId == ComId && x.IsDelete == false);


                if (searchquery?.Length > 1)
                {
                    salelist = salelist.Where(x =>
               x.CustomerName.ToLower().Contains(searchquery.ToLower())
               );

                }

                decimal TotalRecordCount = salelist.Count();
                var PageCountabc = decimal.Parse((TotalRecordCount / size).ToString());
                var PageCount = Math.Ceiling(PageCountabc);



                decimal skip = (page - 1) * size;



                var query = from e in salelist.Include(x => x.Items)
                         .ThenInclude(x => x.Product).ThenInclude(x => x.Category)
                         .Include(x => x.CustomerModel).Include(x => x.SalesPayments)
                            .Include(x => x.AccountTransaction)
                            .Include(x => x.DocTypeList).Include(x => x.DocStatus)


                            select new
                            {
                                Id = e.Id,
                                DueDate = e.DueDate,
                                SaleCode = e.SaleCode,
                                SalesDate = e.SalesDate.ToString("dd-MMM-yy"),
                                UserAccountList = e.UserAccountList.Name,
                                CustomerId = e.CustomerId,
                                CustomerName = (e.CustomerName.Length == 0 || e.CustomerName == null) ? e.CustomerModel.Name : e.CustomerModel.Name + " - " + e.CustomerName,
                                PrimaryAddress = e.PrimaryAddress,
                                SecoundaryAddress = e.SecoundaryAddress,
                                Notes = e.Notes,
                                PhoneNo = e.PhoneNo,
                                Discount = e.Discount,
                                Total = e.Total,
                                Status = e.DocStatus,
                                NetAmount = e.NetAmount,
                                DocType = e.DocTypeList.DocType,

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





    }
}