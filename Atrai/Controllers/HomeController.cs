using Atrai.Core.Common;
using Atrai.Data.Context.AppDataContext;
using Atrai.Data.Interfaces;
using Atrai.Model.Core.Entity;
using Atrai.Model.Core.ViewModel;
using Atrai.Services;
using DataTablesParser;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Routing;
using Microsoft.AspNetCore.WebUtilities;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Text.Encodings.Web;
using System.Threading.Tasks;

namespace Atrai.Controllers
{
    //public class CompanySetupModel
    //{
    //    public string? CompanyName { get; set; }
    //    public string? Currency { get; set; }
    //    public string? TimeZone { get; set; }
    //    public string? FiscalYear { get; set; }
    //    public string? CompanyType { get; set; }
    //    public string? CompanyEmail { get; set; }
    //    public string? CompanyAddress { get; set; }
    //}

    public class MyModel
    {
        public string? Name { get; set; }
        public string? Address { get; set; }
    }


    [AllowAnonymous]
    public class HomeController : Controller
    {
        private readonly IOptions<SMTPConfigModel> _smtpConfig;

        private readonly IUserAccountRepository userAccountRepository;
        private readonly ICompanyRepository companyRepository;
        private readonly IStoreSettingRepository storeSettingRepository;
        private readonly IMenuPermissionRepository _menuPermissionRepository;
        private readonly ICompanyPermissionRepository _companyPermissionRepository;

        private readonly IMenuPermission_MasterRepository _menuPermissionMasterRepository;
        private readonly IMenuPermission_DetailsRepository _menuPermissionDetailsRepository;
        private readonly IEmailSettingRepository _emailSettingRepository;
        private IEmailSender _emailsender { get; }
        private ISmsSender _smsSender { get; }
        private readonly InvoiceDbContext db;


        private readonly IMenuRepository _menuRepository;
        private readonly ICountryRepository _countryRepository;
        private readonly ICategoryRepository _categoryRepository;
        private readonly IBrandRepository _brandRepository;

        private readonly IProductRepository _productRepository;
        private readonly IBusinessTypeRepository _businessTypeRepository;
        private readonly IFiscalYearTypeRepository _fiscalYearTypeRepository;

        private readonly ISubscriptionTypeRepository _subscriptionTypeRepository;
        private readonly ISubscriptionActivationRepository _subscriptionActivationRepository;
        private readonly ISubscriptionActivationCompanyRepository _subscriptionActivationCompanyRepository;

        private readonly IUnitRepository _unitRepository;
        private readonly ITimeZoneSettingsRepository _timeZoneSettingsRepository;


        private readonly ICustomerRepository _customerRepository;
        private readonly ISupplierRepository _supplierRepository;
        private readonly IWarehouseRepository _warehouseRepository;
        private readonly IAccountHeadRepository _accountHeadRepository;
        private readonly ISoftwarePackageRepository _softwarePackageRepository;
        private readonly IPackageActivationRepository _packageActivationRepository;
        private readonly IReportStyleRepository _reportStyleRepository;

        private readonly IOrdersRepository _ordersRepository;
        private readonly IOrdersItemsRepository _ordersItemsRepository;
        private readonly IAccFiscalYearRepository _accFiscalYearRepository;


        private readonly ISalesItemsRepository _salesItemsRepository;





        //private readonly IUserTransactionLogRepository _userTransactionLogRepository;


        public TransactionLogRepository LogRepository { get; }
        public IConfiguration Config { get; }
        Dictionary<int, dynamic> postData = new Dictionary<int, dynamic>();
        public HomeController(IUserAccountRepository userAccountRepository, ICompanyRepository companyRepository,
            IStoreSettingRepository storeSettingRepository,
            IConfiguration config, TransactionLogRepository logRepository, //IUserTransactionLogRepository logRepository, 
            IMenuRepository menuRepository, ICountryRepository countryRepository, ICategoryRepository categoryRepository, IUnitRepository unitRepository,
            ICustomerRepository customerRepository, ISupplierRepository supplierRepository,
            IProductRepository productRepository, IWarehouseRepository warehouseRepository, IAccountHeadRepository accountHeadRepository, ISoftwarePackageRepository softwarePackageRepository, IPackageActivationRepository packageActivationRepository,
            IMenuPermissionRepository menuPermissionRepository, IMenuPermission_MasterRepository menuPermissionMasterRepository, IMenuPermission_DetailsRepository menuPermissionDetailsRepository, IBusinessTypeRepository businessTypeRepository,
            ISubscriptionTypeRepository subscriptionTypeRepository, ISubscriptionActivationRepository subscriptionActivationRepository, IReportStyleRepository reportStyleRepository, IOrdersRepository ordersRepository, IOrdersItemsRepository ordersItemsRepository, IOptions<SMTPConfigModel> smtpConfig, IEmailSettingRepository emailSettingRepository, IEmailSender emailsender, ISmsSender smsSender, ICompanyPermissionRepository companyPermissionRepository, IAccFiscalYearRepository accFiscalYearRepository, IFiscalYearTypeRepository fiscalYearTypeRepository, ISubscriptionActivationCompanyRepository subscriptionActivationCompanyRepository, IBrandRepository brandRepository, ISalesItemsRepository salesItemsRepository, InvoiceDbContext db, ITimeZoneSettingsRepository timeZoneSettingsRepository)
        {
            this.userAccountRepository = userAccountRepository;
            this.companyRepository = companyRepository;
            this.storeSettingRepository = storeSettingRepository;
            Config = config;
            LogRepository = logRepository;
            //_userTransactionLogRepository = logRepository;
            _menuPermissionRepository = menuPermissionRepository;

            _menuPermissionMasterRepository = menuPermissionMasterRepository;
            _menuPermissionDetailsRepository = menuPermissionDetailsRepository;


            _menuRepository = menuRepository;
            _countryRepository = countryRepository;
            _categoryRepository = categoryRepository;
            _unitRepository = unitRepository;


            _customerRepository = customerRepository;
            _supplierRepository = supplierRepository;
            _warehouseRepository = warehouseRepository;
            _accountHeadRepository = accountHeadRepository;
            _softwarePackageRepository = softwarePackageRepository;
            _packageActivationRepository = packageActivationRepository;


            _productRepository = productRepository;
            _businessTypeRepository = businessTypeRepository;

            _subscriptionTypeRepository = subscriptionTypeRepository;
            _subscriptionActivationRepository = subscriptionActivationRepository;
            _reportStyleRepository = reportStyleRepository;
            _ordersRepository = ordersRepository;
            _ordersItemsRepository = ordersItemsRepository;
            _smtpConfig = smtpConfig;
            _emailSettingRepository = emailSettingRepository;
            _emailsender = emailsender;
            _smsSender = smsSender;
            _companyPermissionRepository = companyPermissionRepository;
            _accFiscalYearRepository = accFiscalYearRepository;
            _fiscalYearTypeRepository = fiscalYearTypeRepository;
            _subscriptionActivationCompanyRepository = subscriptionActivationCompanyRepository;
            _brandRepository = brandRepository;
            _salesItemsRepository = salesItemsRepository;
            this.db = db;
            _timeZoneSettingsRepository = timeZoneSettingsRepository;
        }

        [HttpPost]
        public JsonResult CheckUserEmail(string email)
        {
            var userEmail = db.Users.Where(x => x.Email == email || x.PhoneNumber == email).FirstOrDefault();
            return Json(userEmail != null);
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


        [HttpPost]
        public IActionResult OTPConfirmation(ForgetPasswordOTPViewModel model)
        {

            var weburl = Request.Host.Value;
            ViewBag.weburl = weburl.Trim();
            HttpContext.Session.SetString("weburl", weburl);


            if (model.Email.Length > 0 && model.PhoneNo.Length > 0 && model.OTP.Length > 0)
            {

                var userconfirmtiondata = userAccountRepository.All(false).Where(x => x.Email == model.Email && x.PhoneNumber == model.PhoneNo && x.OTP == model.OTP).FirstOrDefault();




                ////////////////////////////////////////////////




                var storesettingsdata = storeSettingRepository.All().Where(x => x.ComId == userconfirmtiondata.ComId).FirstOrDefault();


                //HttpContext.Session.GetString("ComIdString");
                //int ComId = HttpContext.Session.GetInt32("ComId");
                //var abcd = HttpContext.Session.GetString("comid");

                if (storesettingsdata == null)
                {

                    var OTPvalue = ValuesController.randomnumbergenerate(4, 1050, 9999).ToString();


                    var signinmodel = companyRepository.All().Where(x => x.Id == userconfirmtiondata.ComId).FirstOrDefault();


                    var comid = userconfirmtiondata.ComId;
                    var userid = userconfirmtiondata.Id;
                    HttpContext.Session.SetInt32("UserId", userid);
                    HttpContext.Session.SetInt32("ComId", comid);


                    StoreSettingModel storesettings = new StoreSettingModel();
                    storesettings.StoreName = signinmodel.CompanyName ?? "";
                    storesettings.Phone = signinmodel.comPhone ?? "";
                    storesettings.Email = signinmodel.comEmail ?? "";
                    storesettings.Web = signinmodel.comWeb ?? "";
                    storesettings.BusinessTypeId = signinmodel.BusinessTypeId;
                    storesettings.SubscriptionTypeId = signinmodel.SubscriptionTypeId;
                    storesettings.TimeZoneSettingsId = 36;
                    storesettings.SalesReportStyleId = _reportStyleRepository.All().FirstOrDefault().Id;
                    storesettings.PurchaseReportStyleId = _reportStyleRepository.All().FirstOrDefault().Id;

                    //storesettings.Currency = "BDT ";
                    storesettings.CountryId = 18;


                    storesettings.Address = "=N/A=";
                    storesettings.Logo = "/Content/Storeimages/0.png";
                    storesettings.ComId = comid;
                    storesettings.BaseComId = comid;



                    storesettings.TaxPer = 0;
                    storesettings.isTaxExcluded = false;
                    storesettings.SalesReportStyleId = 2;
                    storesettings.PurchaseReportStyleId = 2;

                    storesettings.isChequeDetails = false;
                    storesettings.isMultiCurrency = false;
                    storesettings.isMultiDebitCredit = false;
                    storesettings.isVoucherDistributionEntry = false;



                    storesettings.isSMSService = false;
                    storesettings.isEmailSerivce = false;

                    //storesettings.Email = signinmodel.Email;

                    storeSettingRepository.Insert(storesettings);



                    var UserId = HttpContext.Session.GetInt32("UserId");
                    var companypermission = new CompanyPermissionModel();
                    companypermission.LuserId = userid;
                    companypermission.ComId = comid;

                    _companyPermissionRepository.Insert(companypermission);



                    var validitydays = _subscriptionTypeRepository.Find(signinmodel.SubscriptionTypeId.GetValueOrDefault()).ValidityDay;

                    SubscriptionActivationModel subscriptionActivation = new SubscriptionActivationModel();
                    subscriptionActivation.IsActive = true;
                    subscriptionActivation.IsDelete = false;
                    subscriptionActivation.LuserId = userid;
                    subscriptionActivation.Remarks = "Auto Entry by System";
                    subscriptionActivation.SubscriptionTypeId = signinmodel.SubscriptionTypeId;
                    subscriptionActivation.ActiveFromDate = DateTime.Now.Date;
                    subscriptionActivation.ActiveToDate = DateTime.Now.Date.AddDays(validitydays);
                    _subscriptionActivationRepository.Insert(subscriptionActivation);




                    SubscriptionActivationCompanyModel subscriptionActivationCompany = new SubscriptionActivationCompanyModel();
                    subscriptionActivationCompany.IsActive = true;
                    subscriptionActivationCompany.IsDelete = false;
                    subscriptionActivationCompany.Remarks = "Auto Entry by System";
                    subscriptionActivationCompany.SubscriptionTypeId = signinmodel.SubscriptionTypeId;
                    subscriptionActivationCompany.ActiveFromDate = DateTime.Now.Date;
                    subscriptionActivationCompany.ActiveToDate = DateTime.Now.Date.AddDays(validitydays);
                    subscriptionActivationCompany.ComId = comid;
                    _subscriptionActivationCompanyRepository.Insert(subscriptionActivationCompany);



                    //////Auto Unit Input by System 
                    UnitModel Units = new UnitModel();
                    Units.UnitName = "Pcs";
                    Units.UnitShortName = "Pcs";
                    Units.UnitNameBangla = "";
                    _unitRepository.Insert(Units);


                    var businesstypename = _businessTypeRepository.Find(storesettings.BusinessTypeId).BusinessTypeName;
                    if (businesstypename.ToLower().Contains("walton") || businesstypename.ToLower().Contains("marcel"))
                    {
                        //////Auto Category Input by System 
                        CategoryModel categorydata = new CategoryModel();
                        categorydata.Name = "Electronics";
                        categorydata.Description = "Electronics";
                        _categoryRepository.Insert(categorydata);
                    }
                    else
                    {
                        //////Auto Category Input by System 
                        CategoryModel categorydata = new CategoryModel();
                        categorydata.Name = "=N/A=";
                        categorydata.Description = "=N/A=";
                        _categoryRepository.Insert(categorydata);
                    }



                    CustomerModel customerdata = new CustomerModel();
                    customerdata.Name = "Walk In Customer";
                    customerdata.Phone = "";
                    customerdata.ComId = comid;
                    _customerRepository.Insert(customerdata);


                    SupplierModel supplierdata = new SupplierModel();
                    supplierdata.SupplierName = "Cash Supplier";
                    supplierdata.Phone = "";
                    supplierdata.ComId = comid;
                    _supplierRepository.Insert(supplierdata);


                    WarehouseModel warehousedata = new WarehouseModel();
                    warehousedata.WhName = "Main";
                    warehousedata.WhShortName = "Main";
                    warehousedata.WhType = "L";
                    warehousedata.ComId = comid;
                    _warehouseRepository.Insert(warehousedata);


                    //if (signinmodel.BusinessTypeId > 0)
                    //{
                    //    var businesstypename = _businessTypeRepository.Find(signinmodel.BusinessTypeId).BusinessTypeName.ToLower();

                    //    if (businesstypename.Contains("waltonmarcel"))
                    //    {
                    //        SqlParameter[] sqlParameter1 = new SqlParameter[3];
                    //        sqlParameter1[0] = new SqlParameter("@comId", comid);
                    //        sqlParameter1[1] = new SqlParameter("@TableName", "AccountHead");
                    //        sqlParameter1[2] = new SqlParameter("@BrandName", businesstypename);

                    //        Helper.ExecProc("prcAutoInsert", sqlParameter1);
                    //    }

                    //}

                    //var businesstypeinfo = _businessTypeRepository.Find(signinmodel.BusinessTypeId);
                    //if (businesstypeinfo.IsAccounts == true)
                    //{

                    //    ///Account Data Auto Insert
                    //    SqlParameter[] sqlParameter = new SqlParameter[2];
                    //    sqlParameter[0] = new SqlParameter("@comId", comid);
                    //    sqlParameter[1] = new SqlParameter("@TableName", "AccountHead");
                    //    //sqlParameter[2] = new SqlParameter("@BrandName", "");

                    //    Helper.ExecProc("prcAutoInsert", sqlParameter);
                    //    ///Account Data Auto Insert



                    //    //var fiscalyearinfo = _fiscalYearTypeRepository.Find(signinmodel.BusinessTypeId);
                    //    var fiscalyearinfo = _fiscalYearTypeRepository.Find(signinmodel.FiscalYearTypeId.GetValueOrDefault());
                    //    ///fiscal year Creation



                    //    var PrevYear = DateTime.Now.Year - 1;
                    //    var fromdate = new DateTime(PrevYear, 1, 1);
                    //    var todate = new DateTime(PrevYear, 12, 31);
                    //    //if (fiscalyearinfo != null)
                    //    //{
                    //    //    PrevYear = DateTime.Now.Year - 1;
                    //    //    fromdate = new DateTime(PrevYear, fiscalyearinfo.FYStartMonth, fiscalyearinfo.FYStartDate);
                    //    //    todate = new DateTime(PrevYear, fiscalyearinfo.FYEndMonth, fiscalyearinfo.FYEndDate);
                    //    //}


                    //    SqlParameter[] sqlParameterfy = new SqlParameter[4];
                    //    sqlParameterfy[0] = new SqlParameter("@comid", comid);
                    //    sqlParameterfy[1] = new SqlParameter("@dtFrom", fromdate);
                    //    sqlParameterfy[2] = new SqlParameter("@dtTo", todate);
                    //    sqlParameterfy[3] = new SqlParameter("@UserId", userid);
                    //    Helper.ExecProc("Acc_prcCloseFiscalYearManual", sqlParameterfy);
                    //    ///fiscal year Creation
                    //}



                    TempData["Message"] = "User Created Successfully";
                    TempData["Status"] = "1";


                }


                ///////////////////////////////////////////////////














                //userconfirmtiondata.OTP = null;
                //userAccountRepository.Update(userconfirmtiondata, userconfirmtiondata.Id);

                if (userconfirmtiondata != null)
                {
                    ChangePasswordViewModel abc = new ChangePasswordViewModel();

                    abc.EmailOrPhone = model.Email;
                    //abc.PhoneNo = model.PhoneNo;

                    userconfirmtiondata.IsEmailVerified = true;
                    userconfirmtiondata.OTP = "";


                    userAccountRepository.Update(userconfirmtiondata, userconfirmtiondata.Id);

                    TempData["UserLoginFailed"] = null;
                    TempData["Message"] = "Email or Phone No Verified Successfully";
                    TempData["Status"] = "1";

                    return RedirectToAction("Login", "Home");
                    //return View("Login");
                }

            }


            TempData["Status"] = "3";
            TempData["Message"] = "Please Verify your OTP from Your Mail Account";
            return View(model);

        }

        [AllowAnonymous]
        public IActionResult CompanySetup()
        {
            try
            {



                ViewBag.Country = _countryRepository.GetAllForDropDown();
                ViewBag.BusinessType = _businessTypeRepository.GetActiveForDropDown();
                ViewBag.FiscalYearType = _fiscalYearTypeRepository.GetAllForDropDown();
                ViewBag.TimeZoneSettings = _timeZoneSettingsRepository.GetAllForDropDown();
                ViewBag.SubscriptionType = _subscriptionTypeRepository.GetAllForDropDown();




                TempData["Status"] = "3";
                TempData["Message"] = "Please Verify your OTP from Your Mail Account";
                return View();

            }
            catch (Exception ex)
            {

                throw ex;
            }

            //return View();
        }


        //Trial form controller
        //[HttpPost]
        //public IActionResult Action([FromBody] MyModel model, [FromForm] IFormFile image)
        //{
        //    Console.WriteLine("Name: " + model.Name);
        //    Console.WriteLine("Address: " + model.Address);
        //    Console.WriteLine("Image Name: " + image.FileName);
        //    // do something with the model
        //    return Json(new { success = true });
        //}


        [HttpPost]
        public IActionResult CompanySetup(string CompanyName, IFormFile CompanyImage, int CountryId, int CurrencyId, int TimeZoneId, int FiscalYearId, int BusinessTypeId, int SubscriptionTypeId, string CompanyEmail, string CompanyPhone, string BusinessAddress)
        {

            try
            {
                if (!ModelState.IsValid)
                {
                    // If there are validation errors, return BadRequest with the error details
                    var errors = ModelState.Values.SelectMany(v => v.Errors.Select(e => e.ErrorMessage));
                    return BadRequest(errors);
                }
                CompanyModel com = new CompanyModel();
                com.CompanyName = CompanyName ?? "";
                com.comEmail = CompanyEmail ?? "";
                com.comPhone = CompanyPhone ?? "";
                com.BusinessTypeId = BusinessTypeId;
                com.SubscriptionTypeId = SubscriptionTypeId;
                //com.CountryId = CountryId;
                //com.CurrencyId = CurrencyId;
                //com.isMultiDebitCredit = true;
                //com.comWeb = websi ?? "";
                com.PrimaryAddress = BusinessAddress ?? "";

                int comid = companyRepository.Insert(com);
                HttpContext.Session.SetString("ComIdString", comid.ToString());
                HttpContext.Session.SetInt32("ComId", comid);
                //var abcd = HttpContext.Session.GetString("comid");





                StoreSettingModel storesettings = new StoreSettingModel();
                storesettings.StoreName = CompanyName ?? "";
                //storesettings.Phone = PhoneNumber ?? "";
                storesettings.Email = CompanyEmail ?? "";
                //storesettings.Web = CompanyAddress ?? "";
                storesettings.BusinessTypeId = BusinessTypeId;
                storesettings.SubscriptionTypeId = SubscriptionTypeId;

                storesettings.CountryId = CountryId;
                storesettings.CurrencyId = CurrencyId;
                storesettings.Address = BusinessAddress;


                //storesettings.SubscriptionTypeId = SubscriptionTypeId;
                storesettings.TimeZoneSettingsId = TimeZoneId; //////////////////timezone by fahad
                                                               //storesettings.SalesReportStyleId = int.Parse(_reportStyleRepository.GetAllInvoiceReportForDropDown().FirstOrDefault().Value);
                                                               //storesettings.PurchaseReportStyleId = int.Parse(_reportStyleRepository.GetAllPurchaseReportForDropDown().FirstOrDefault().Value);
                                                               //storesettings.BarcodeReportStyleId = int.Parse(_reportStyleRepository.GetAllBarcodeReportForDropDown().FirstOrDefault().Value);


                Console.WriteLine(CompanyName);

                // validate the image file
                if (CompanyImage == null || CompanyImage.Length == 0)
                {
                    return BadRequest("File not selected");

                }
                // process the image file

                var imagefilename = comid.ToString() + "_" + CompanyImage.FileName.Replace(".", "_").Replace("@", "_").Replace("$", "_").Replace("#", "_");
                var path = Path.Combine(
                    Directory.GetCurrentDirectory(), "wwwroot", "images",
                    imagefilename);
                using (var stream = new FileStream(path, FileMode.Create))
                {
                    CompanyImage.CopyTo(stream);
                }
                storesettings.Logo = "/images/" + imagefilename;


                //storesettings.Logo = "/Content/Storeimages/0.png";
                storesettings.ComId = comid;
                storesettings.BaseComId = comid;



                storesettings.TaxPer = 0;
                storesettings.isTaxExcluded = false;
                //storesettings.SalesReportStyleId = 2;
                //storesettings.PurchaseReportStyleId = 2;

                storesettings.isChequeDetails = true;
                storesettings.isMultiCurrency = true;
                storesettings.isMultiDebitCredit = true;
                storesettings.isVoucherDistributionEntry = false;

                storesettings.isSMSService = false;
                storesettings.isEmailSerivce = false;
                storesettings.Phone = CompanyPhone ?? "";




                storesettings.Email = CompanyEmail ?? "";
                storesettings.Web = "N/A" ?? "";
                storesettings.Address = BusinessAddress ?? "";
                storesettings.StoreName = CompanyName ?? "";
                var UserId = HttpContext.Session.GetInt32("UserId");

                storeSettingRepository.Insert(storesettings);
                var fydata = _fiscalYearTypeRepository.Find(FiscalYearId);
                var fromdate = DateTime.Now.Date;
                var todate = DateTime.Now.Date;
                if (fydata.FYStartMonth == 1)
                {
                    System.Globalization.DateTimeFormatInfo mfi = new System.Globalization.DateTimeFormatInfo();
                    string strMonthName = mfi.GetMonthName(fydata.FYStartMonth).ToString();
                    string endMonthName = mfi.GetMonthName(fydata.FYEndMonth).ToString();

                    fromdate = Convert.ToDateTime(fydata.FYStartDate.ToString() + "-" + strMonthName.ToString() + "-" + (DateTime.Now.Year - 1));
                    todate = Convert.ToDateTime(fydata.FYEndDate.ToString() + "-" + endMonthName.ToString() + "-" + (DateTime.Now.Year - 1));
                }
                else
                {
                    System.Globalization.DateTimeFormatInfo mfi = new System.Globalization.DateTimeFormatInfo();
                    string strMonthName = mfi.GetMonthName(fydata.FYStartMonth).ToString();
                    string endMonthName = mfi.GetMonthName(fydata.FYEndMonth).ToString();

                    fromdate = Convert.ToDateTime(fydata.FYStartDate.ToString() + "-" + strMonthName.ToString() + "-" + (DateTime.Now.Year - 1));
                    todate = Convert.ToDateTime(fydata.FYEndDate.ToString() + "-" + endMonthName.ToString() + "-" + (DateTime.Now.Year));
                }

                //fiscal year creation
                SqlParameter[] sqlParameter = new SqlParameter[4];
                sqlParameter[0] = new SqlParameter("@comid", comid);
                sqlParameter[1] = new SqlParameter("@dtFrom", fromdate);
                sqlParameter[2] = new SqlParameter("@dtTo", todate);
                sqlParameter[3] = new SqlParameter("@UserId", UserId);

                Helper.ExecProc("Acc_prcCloseFiscalYearManual", sqlParameter);

                //////Auto Unit Input by System 
                UnitModel Units = new UnitModel();
                Units.UnitName = "Pcs";
                Units.UnitShortName = "Pcs";
                Units.UnitNameBangla = "";
                _unitRepository.Insert(Units);



                CustomerModel customerdata = new CustomerModel();
                customerdata.Name = "Walk In Customer";
                customerdata.Phone = "";
                customerdata.ComId = comid;
                customerdata.CustomerCurrencyId = CountryId;
                _customerRepository.Insert(customerdata);


                SupplierModel supplierdata = new SupplierModel();
                supplierdata.SupplierName = "Cash Supplier";
                supplierdata.Phone = "";
                supplierdata.ComId = comid;
                supplierdata.SupplierCurrencyId = CountryId;
                _supplierRepository.Insert(supplierdata);


                WarehouseModel warehousedata = new WarehouseModel();
                warehousedata.WhName = "Main";
                warehousedata.WhShortName = "Main";
                warehousedata.WhType = "L";
                warehousedata.ComId = comid;
                _warehouseRepository.Insert(warehousedata);


                //db.Database.ExecuteSqlCommand("Exec prcCloseFiscalYear @comid", new SqlParameter("@comid", comid));
                //TempData["Message"] = "Year Craeted Successfully.";
                //tranlog.TransactionLog(RouteData.Values["controller"].ToString(), RouteData.Values["action"].ToString(), TempData["Message"].ToString(), model.FYName, "Acc_PrcCloseFiscalYear", model.FYName);

                //accountheadlist creation
                //var xx = _accountHeadRepository.All().Count();

                //if (xx == 0)
                //{
                //     string ffUrl = "http://localhost:2555/Accounts/importaccount";
                //    return Redirect(ffUrl);
                //    //SqlParameter[] sqlParameter1 = new SqlParameter[2];
                //    //sqlParameter1[0] = new SqlParameter("@ComId", comid);
                //    //sqlParameter1[1] = new SqlParameter("@TableName", "AccountHead");

                //    //Helper.ExecProc("[prcAutoInsert]", sqlParameter1);


                //    //db.Database.ExecuteSqlCommand("Exec prcCloseFiscalYear @comid", new SqlParameter("@comid", comid));
                //    //TempData["Message"] = "Fiscal year and Accounts Head Craeted Successfully.";
                //    //tranlog.TransactionLog(RouteData.Values["controller"].ToString(), RouteData.Values["action"].ToString(), TempData["Message"].ToString(), model.OpeningYear.ToString(), "prcAutoInsert", model.OpeningYear.ToString());

                //}


                var userinfo = userAccountRepository.Find(UserId.GetValueOrDefault());
                userinfo.ComId = comid;
                userAccountRepository.Update(userinfo, UserId.GetValueOrDefault());


                var companypermission = new CompanyPermissionModel();
                companypermission.LuserId = UserId.GetValueOrDefault();
                companypermission.ComId = comid;
                _companyPermissionRepository.Insert(companypermission);



                var validitydays = _subscriptionTypeRepository.Find(SubscriptionTypeId).ValidityDay;

                SubscriptionActivationModel subscriptionActivation = new SubscriptionActivationModel();
                subscriptionActivation.IsActive = true;
                subscriptionActivation.IsDelete = false;
                subscriptionActivation.LuserId = UserId.GetValueOrDefault();
                subscriptionActivation.Remarks = "Auto Entry by System";
                subscriptionActivation.SubscriptionTypeId = SubscriptionTypeId;
                subscriptionActivation.ActiveFromDate = DateTime.Now.Date;
                subscriptionActivation.ActiveToDate = DateTime.Now.Date.AddDays(validitydays);
                _subscriptionActivationRepository.Insert(subscriptionActivation);


                SubscriptionActivationCompanyModel subscriptionActivationCompany = new SubscriptionActivationCompanyModel();
                subscriptionActivationCompany.IsActive = true;
                subscriptionActivationCompany.IsDelete = false;
                subscriptionActivationCompany.Remarks = "Auto Entry by System";
                subscriptionActivationCompany.SubscriptionTypeId = SubscriptionTypeId;
                subscriptionActivationCompany.ActiveFromDate = DateTime.Now.Date;
                subscriptionActivationCompany.ActiveToDate = DateTime.Now.Date.AddDays(validitydays);
                subscriptionActivationCompany.ComId = comid;
                _subscriptionActivationCompanyRepository.Insert(subscriptionActivationCompany);


                var ff = _accountHeadRepository.All().Count();

                if (ff == 0)
                {
                    //string ffUrl = "http://localhost:2555/Accounts/importaccount";
                    //return Json(new { ff = ff, redirectUrl = ffUrl });
                    string ffUrl = Url.Action("ImportAccount", "Accounts");
                    return Json(new { ff = ff, redirectUrl = ffUrl });
                }
                else
                {
                    return Json(new { ff = ff });
                }


                // return success
                // 
            }
            catch (Exception ex)
            {
                return Json(new { IsSuccess = 0, status = "Fail" });
                throw ex;
            }
        }


        //[HttpPost]
        //[AllowAnonymous]
        //public IActionResult CompanySetup(CompanyModel CompanyInfo)//, IFormFile image
        //{

        //    var abc = CompanyInfo; 
        //    return View();
        //}

        //[HttpPost]
        //public ActionResult CompanySetup(CompanyModel input)
        //{
        //    // Do something with the data in the model and image
        //    // ...

        //    // Return a success status or a view
        //   // return Json(new { success = true });
        //    // or
        //    return View();
        //}

        //[HttpPost]
        //public ActionResult CompanySetup(InputModel input)
        //{
        //    // Do something with input
        //    // ...

        //    // Return a response
        //    return Json(new { success = true });
        //}
        [AllowAnonymous]
        public IActionResult OTPConfirmation(string Email, string PhoneNo)
        {
            try
            {


                var weburl = Request.Host.Value;
                ViewBag.weburl = weburl.Trim();
                HttpContext.Session.SetString("weburl", weburl);

                //var userconfirmtiondata = userAccountRepository.All(false).Where(x => x.OTP == OTP && x.PhoneNumber == PhoneNo).FirstOrDefault();
                var userconfirmtiondata = userAccountRepository.All().Where(x => x.Email == Email || x.PhoneNumber == PhoneNo).FirstOrDefault();

                //userconfirmtiondata.OTP = null;
                //userAccountRepository.Update(userconfirmtiondata, userconfirmtiondata.Id);

                if (userconfirmtiondata != null)
                {
                    OTPSetViewModel abc = new OTPSetViewModel();

                    //abc.OTP = OTP;
                    //abc.EmailOrPhone = PhoneNo;
                    abc.EmailOrPhone = Email;
                    abc.OTP = "";
                    //userconfirmtiondata.IsOTPVerified = true;

                    //userAccountRepository.Update(userconfirmtiondata, userconfirmtiondata.Id);
                    //TempData["Message"] = "Password Reset Successfully";
                    //TempData["Status"] = "1";

                    return View(abc);
                    //return View("ConfirmPassword", abc);
                }

                TempData["Status"] = "3";
                TempData["Message"] = "Please Verify your OTP from Your Mail Account";
                return View("Login");


                //return View();
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }


        public IActionResult Index()
        {
            try
            {


                var weburl = Request.Host.Value;
                //errorlog(weburl.ToString());
                //ViewBag.weburl = weburl.Trim();
                HttpContext.Session.SetString("weburl", weburl);

                //var company = companyRepository.All().Include(x => x.BusinessType).Where(x => x.comWeb.ToLower().Contains(weburl.ToLower())).FirstOrDefault();

                //if (company != null)
                //{
                //    ViewBag.ComId = company.Id;
                //    var companysettings = storeSettingRepository.All(false).Where(x => x.ComId == company.Id).FirstOrDefault();
                //    ViewBag.comImagePath = companysettings.Logo;
                //    //ViewBag.AppsName = companysettings.BusinessType.AppsName;
                //    HttpContext.Session.SetString("AppsName", company.BusinessType.AppsName);
                //}
                //else
                //{
                //    company = companyRepository.All().Include(x => x.BusinessType).Where(x => x.Id == 1).FirstOrDefault();
                //    ViewBag.ComId = company.Id;
                //    ///fahad vai code
                //    var companysettings = storeSettingRepository.All(false).Where(x => x.ComId == company.Id).FirstOrDefault();
                //    ViewBag.comImagePath = companysettings.Logo;
                //    HttpContext.Session.SetString("AppsName", "Easy Apps");
                //}
                /////fahad vai code
                //var settingsdata = storeSettingRepository.All(false).Where(x => x.ComId == company.Id).FirstOrDefault();
                //if (User.Identity.IsAuthenticated == false && settingsdata?.RedirectToEcommercePage == true)
                //{
                //    return RedirectToAction("EcomIndex", new { IsMobile = 0 });
                //}

                //to fix bug changed this code
                //var companysettingss = storeSettingRepository.All(false).Where(x => x.ComId == company.Id).FirstOrDefault();
                //if (companysettingss != null)
                //{
                //    ViewBag.comImagePath = companysettingss.Logo;
                //    HttpContext.Session.SetString("AppsName", "Easy Apps");
                //}
                //else
                //{
                //    var settingsdata = storeSettingRepository.All(false).Where(x => x.ComId == company.Id).FirstOrDefault();
                //    if (User.Identity.IsAuthenticated == false && settingsdata?.RedirectToEcommercePage == true)
                //    {
                //        return RedirectToAction("EcomIndex", new { IsMobile = 0 });
                //    }
                //}
                //to fix bug changed this code

                //RedirectToAction("Home","EcommerceIndex");

                return View();
            }
            catch (Exception ex)
            {
                return Json(new { message = ex.Message });
                throw ex;
            }
        }

        [HttpGet]
        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync();

            HttpContext.Session.SetString("Latitude", "");
            HttpContext.Session.SetString("Longitude", "");

            HttpContext.Session.SetString("CompanyName", "");
            HttpContext.Session.SetString("PrimaryAddress", "");
            HttpContext.Session.SetString("SecoundaryAddress", "");
            HttpContext.Session.SetString("comPhone", "");
            HttpContext.Session.SetString("comWeb", "");
            HttpContext.Session.SetString("comEmail", "");
            HttpContext.Session.SetString("CaptionOne", "");
            HttpContext.Session.SetString("CaptionTwo", "");
            HttpContext.Session.SetString("PrintDate", "");
            HttpContext.Session.SetString("comImagePath", "");
            HttpContext.Session.SetString("weburl", "");

            HttpContext.Session.SetObject("UserAllMenu", null);
            HttpContext.Session.SetObject("UserGroupMenu", null);
            HttpContext.Session.SetObject("UserParentMenu", null);
            HttpContext.Session.SetObject("UserChildMenu", null);
            HttpContext.Session.SetObject("MenuList", null);

            HttpContext.Session.SetString("CurrencyShortNameViewFormat", "");
            HttpContext.Session.SetString("CultureInfoViewFormat", "");
            HttpContext.Session.SetString("CountryShortNameViewFormat", "");
            HttpContext.Session.SetString("CurrencySymbolViewFormat", "");

            HttpContext.Session.SetString("CurrencyShortName", "");
            HttpContext.Session.SetString("CultureInfo", "");
            HttpContext.Session.SetString("CountryShortName", "");
            HttpContext.Session.SetString("CurrencySymbol", "");



            HttpContext.Session.SetString("isTaxExcluded", "");
            HttpContext.Session.SetString("SalesReportStyle", "");
            HttpContext.Session.SetString("PurchaseReportStyle", "");
            HttpContext.Session.SetString("BarcodeReportStyle", "");



            HttpContext.Session.SetInt32("TaxPer", 0);
            HttpContext.Session.SetInt32("CustomerId", 0);



            LogRepository.SuccessLogin(HttpContext.Session.GetString("Latitude"), HttpContext.Session.GetString("Longitude"), "Logout");


            return RedirectToAction("index", "home");
        }

        [HttpGet]
        public ActionResult Login(string ReturnUrl)
        {
            try
            {
                var weburl = Request.Host.Value;
                //errorlog(weburl.ToString());
                var q = companyRepository.All().ToList();
                HttpContext.Session.SetString("weburl", weburl.Trim());

                //ViewBag.weburl = weburl.Trim();
                var company = companyRepository.All().Include(x => x.BusinessType).Where(x => x.comWeb.ToLower().Contains(weburl.ToLower())).FirstOrDefault();

                if (company != null)
                {
                    ViewBag.ComId = company.Id;
                    var companysettings = storeSettingRepository.All(false).Where(x => x.ComId == company.Id).FirstOrDefault();
                    ViewBag.comImagePath = companysettings.Logo;
                    //ViewBag.AppsName = companysettings.BusinessType.AppsName;
                    HttpContext.Session.SetString("AppsName", company.BusinessType.AppsName);
                }
                else
                {
                    company = companyRepository.All().Include(x => x.BusinessType).Where(x => x.Id == 1).FirstOrDefault();
                    ViewBag.ComId = company.Id;
                    var companysettings = storeSettingRepository.All(false).Where(x => x.ComId == company.Id).FirstOrDefault();
                    ViewBag.comImagePath = companysettings.Logo;
                    HttpContext.Session.SetString("AppsName", "Easy Apps");
                }

                return View(new LoginViewModel() { ReturnUrl = ReturnUrl });
            }
            catch (Exception ex)
            {
                return Json(new { message = ex.Message });
                throw ex;
            }

        }


        [HttpGet]
        public ActionResult AtraiLogin()
        {
            try
            {
                var weburl = Request.Host.Value;
                errorlog(weburl.ToString());

                HttpContext.Session.SetString("weburl", weburl.Trim());

                //ViewBag.weburl = weburl.Trim();
                var company = companyRepository.All().Include(x => x.BusinessType).Where(x => x.comWeb.ToLower().Contains(weburl.ToLower())).FirstOrDefault();

                if (company != null)
                {
                    ViewBag.ComId = company.Id;
                    var companysettings = storeSettingRepository.All(false).Where(x => x.ComId == company.Id).FirstOrDefault();
                    ViewBag.comImagePath = companysettings.Logo;
                    //ViewBag.AppsName = companysettings.BusinessType.AppsName;
                    HttpContext.Session.SetString("AppsName", company.BusinessType.AppsName);
                }
                else
                {
                    company = companyRepository.All().Include(x => x.BusinessType).Where(x => x.Id == 1).FirstOrDefault();
                    ViewBag.ComId = company.Id;
                    var companysettings = storeSettingRepository.All(false).Where(x => x.ComId == company.Id).FirstOrDefault();
                    ViewBag.comImagePath = companysettings.Logo;
                    HttpContext.Session.SetString("AppsName", "Easy Apps");
                }
                //ViewBag.UrlAddress = weburl;

                return View();
            }
            catch (Exception ex)
            {
                return Json(new { message = ex.Message });
                throw ex;
            }

        }

        [HttpGet]
        public ActionResult CustomerLogin()
        {
            try
            {
                var weburl = Request.Host.Value;
                errorlog(weburl.ToString());

                HttpContext.Session.SetString("weburl", weburl.Trim());

                //ViewBag.weburl = weburl.Trim();
                var company = companyRepository.All().Include(x => x.BusinessType).Where(x => x.comWeb.ToLower().Contains(weburl.ToLower())).FirstOrDefault();

                if (company != null)
                {
                    ViewBag.ComId = company.Id;
                    var companysettings = storeSettingRepository.All(false).Where(x => x.ComId == company.Id).FirstOrDefault();
                    ViewBag.comImagePath = companysettings.Logo;
                    //ViewBag.AppsName = companysettings.BusinessType.AppsName;
                    HttpContext.Session.SetString("AppsName", company.BusinessType.AppsName);
                }
                else
                {
                    company = companyRepository.All().Include(x => x.BusinessType).Where(x => x.Id == 1).FirstOrDefault();
                    ViewBag.ComId = company.Id;
                    var companysettings = storeSettingRepository.All(false).Where(x => x.ComId == company.Id).FirstOrDefault();
                    ViewBag.comImagePath = companysettings.Logo;
                    HttpContext.Session.SetString("AppsName", "Easy Invoice");
                }
                //ViewBag.UrlAddress = weburl;

                return View();
            }
            catch (Exception ex)
            {
                return Json(new { message = ex.Message });
                throw ex;
            }

        }


        [AllowAnonymous]
        [HttpGet]
        public ActionResult CustomerOrder(int IsMobile = 0)
        {
            HttpContext.Session.SetInt32("IsMobile", IsMobile);



            ViewBag.CategoryId = _categoryRepository.GetAllForDropDown(true);

            ViewBag.BrandName = _brandRepository.GetAllForDropDown(true);


            //ViewBag.BrandName = _productRepository.All(true)
            //    .GroupBy(x => new { x.BrandName })
            //    .Select(g => new SelectListItem { Text = g.Key.BrandName, Value = g.Count().ToString() }).ToList();



            return View();
        }


        //public IActionResult DeleteCustomerOrder(int saleId)
        //{

        //    ViewBag.ActionType = "Delete";
        //    var model = this.CustomerOrder.All().Where(x => x.Id == saleId && x.isPosted == false).FirstOrDefault(); //.Find(saleId);
        //    CustomerOrder.Delete(model);


        //    TempData["Message"] = "Data Delete Successfully";
        //    TempData["Status"] = "3";
        //    tranlog.TransactionLog(RouteData.Values["controller"].ToString(), RouteData.Values["action"].ToString(), TempData["Message"].ToString(), model.Id.ToString(), "Delete", model.SaleCode);



        //    return RedirectToAction("index");


        //}




        [HttpPost]
        [AllowAnonymous]
        public IActionResult CustomerOrder(OrdersModel model)
        {
            try
            {
                //var UserId = HttpContext.Session.GetInt32("UserId");
                //var ComId = HttpContext.Session.GetInt32("ComId");

                //ViewBag.ComId = model.ComId;
                //ViewBag.weburl = model.Notes;

                var errors = ModelState.Where(x => x.Value.Errors.Any())
                .Select(x => new { x.Key, x.Value.Errors });

                if (ModelState.IsValid)
                {
                    //model.OrdersDate = DateTime.Now;
                    if (model.Id > 0)
                    {

                        if (model.NetAmount == 0)
                        {
                            model.NetAmount = model.GrandTotal;
                        }

                        _ordersRepository.Update(model, model.Id);

                        foreach (OrdersItemsModel item in model.Items)
                        {

                            if (item.Id > 0)
                            {
                                if (item.IsDelete == true)
                                {
                                    _ordersItemsRepository.Delete(item);
                                }
                                else
                                {
                                    _ordersItemsRepository.Update(item, item.Id);
                                }
                            }
                            else
                            {
                                if (item.IsDelete == true)
                                {
                                }
                                else
                                {
                                    _ordersItemsRepository.Insert(item);
                                }
                            }
                        }



                        TempData["Message"] = "Data Update Successfully";
                        TempData["Status"] = "2";
                        LogRepository.TransactionLog(RouteData.Values["controller"].ToString(), RouteData.Values["action"].ToString(), TempData["Message"].ToString(), model.Id.ToString(), "Update", model.OrderCode);


                        return Json(new { Success = 1, error = false, message = "Date Update successfully" });
                    }
                    else
                    {
                        foreach (var item in model.Items)
                        {
                            item.CreateDate = DateTime.Now;
                            item.UpdateDate = DateTime.Now;


                        }

                        if (model.NetAmount == 0)
                        {
                            model.NetAmount = model.GrandTotal;
                        }

                        var orderid = _ordersRepository.InsertInt(model);


                        TempData["Message"] = "Data Save Successfully";
                        TempData["Status"] = "1";
                        LogRepository.TransactionLog(RouteData.Values["controller"].ToString(), RouteData.Values["action"].ToString(), TempData["Message"].ToString(), model.Id.ToString(), "Create", model.OrderCode);



                        return Json(new { Success = 1, Id = orderid, message = "Data Save successfully" });
                    }

                }
                else
                {
                    return Json(new { error = true, message = "failed to Save the Data.  " + errors.FirstOrDefault() }); ;
                }



            }
            catch (Exception ex)
            {

                return Json(new { error = true, message = ex.Message });
            }
        }


        [HttpGet]
        public ActionResult Ecommerce()
        {
            ViewBag.Category = _categoryRepository.GetAllForDropDown(false);
            //ViewBag.SupplierCompany = companyRepository.GetAllForDropDown();

            return View();
        }

        [HttpGet]
        public IActionResult Blank()
        {
            return View();
        }

        [HttpGet]
        public IActionResult EcomIndex()
        {
            var abccomid = 69;


            //HttpContext.Session.SetInt32("UserId", 1);
            ////HttpContext.Session.SetInt32("ComId", 156);

            //List<string> mystring = new List<string>() { "ComId", "Id" };
            //mystring = Enumerable.Reverse(mystring).Take(2).Reverse().ToList();




            var weburl = Request.Host.Value;
            ViewBag.weburl = weburl.Trim();


            //var weburl = Request.Host.Value;
            //errorlog(weburl.ToString());
            //ViewBag.weburl = weburl.Trim();
            HttpContext.Session.SetString("weburl", weburl);

            //var company = companyRepository.All().Include(x => x.BusinessType).Where(x => x.comWeb.ToLower().Contains(weburl.ToLower())).FirstOrDefault();
            var company = companyRepository.All().Include(x => x.BusinessType).Where(x => x.Id == abccomid).FirstOrDefault();


            if (company != null)
            {
                ViewBag.ComId = company.Id;
                var companysettings = storeSettingRepository.All(false).Where(x => x.ComId == company.Id).FirstOrDefault();
                ViewBag.comImagePath = companysettings.Logo;
                //ViewBag.AppsName = companysettings.BusinessType.AppsName;
                HttpContext.Session.SetString("AppsName", company.BusinessType.AppsName);
                HttpContext.Session.SetString("iscompany", "true");
                ////HttpContext.Session.SetInt32("UserId", userid);
                //HttpContext.Session.SetInt32("ComId", company.Id);

            }
            else
            {
                company = companyRepository.All().Include(x => x.BusinessType).Where(x => x.Id == abccomid).FirstOrDefault();
                ViewBag.ComId = company.Id;
                var companysettings = storeSettingRepository.All(false).Where(x => x.ComId == company.Id).FirstOrDefault();
                ViewBag.comImagePath = companysettings.Logo;
                HttpContext.Session.SetString("AppsName", "Easy Invoice");
                HttpContext.Session.SetString("iscompany", "false");

            }




            //var company = companyRepository.All().Where(x => x.comWeb.ToLower().Contains(weburl.ToLower())).FirstOrDefault();

            if (company != null)
            {
                ViewBag.ComId = company.Id;
                ViewBag.Category = _categoryRepository.All(true).Where(x => x.ComId == company.Id).Take(5).Select(x => new SelectListItem
                {
                    Text = x.Name,
                    Value = x.Id.ToString(),
                });

                var companysettings = storeSettingRepository.All(false).Where(x => x.ComId == company.Id).FirstOrDefault();
                ViewBag.comImagePath = companysettings.Logo;




                var CategoryWithImage = from p in db.Categories.Where(x => x.ComId == company.Id && x.ImagePath.Length > 1)
                                        join g in db.Galleries on p.ImagePath equals g.Id into gg
                                        from g in gg.DefaultIfEmpty()
                                        select new CategoryModel
                                        {
                                            Id = p.Id,
                                            Name = p.Name,
                                            ImagePath = p.ImagePath,
                                            //ProductPicture1 = p.ProductPicture1,
                                            ProductPicturePreview1 = g.Name != null ? $"/{g.Name}" : null
                                        };


                //var CategoryWithImage = _categoryRepository.All(true)
                //  .Where(x => x.ComId == abccomid && x.ImagePath != null)
                //  .AsEnumerable().TakeLast(4)
                //  .Select(e => new CategoryResultDemo
                //  {
                //      CategoryId = e.Id,
                //      CategoryName = e.Name,
                //      CategoryImage = e.ImagePath,
                //      ProductCount = e.ProductCount.Count()
                //  });

                ViewBag.CategoryWithImage = CategoryWithImage;



            }






            var NewTopTenproduct = _productRepository.All(false)
                .Where(x => x.ComId == abccomid && x.ImagePath != null)
                .Include(x => x.CompanyList)
                .Include(x => x.Category)
                .Include(x => x.ProductReviews)
                .AsEnumerable().TakeLast(10)
                .Select(e => new ProductResultDemo
                {
                    ProductId = e.Id,
                    CategoryName = e.Category.Name,
                    ProductName = e.Name,
                    ProductBarcode = e.Code,
                    SizeName = e.SizeName,// != null ? e.SizeName.Length > 0 ? "[ " + e.SizeName + " ]" : "" : "",
                    //BrandName = e.BrandName,
                    BrandName = e.Brand != null ? e.Brand.BrandName : "",
                    ColorName = e.ColorName,
                    CompanyName = e.CompanyList.CompanyName,
                    CompanyPhone = e.CompanyList.comPhone,
                    ProductReviews = e.ProductReviews.ToList(),
                    ProductReviewsCount = e.ProductReviews.Count(),
                    Ratings = 2,//e.ProductReviews.Average(x => x.Ratings),
                    Description = e.Description,
                    //CostPrice = e.CostPrice,
                    SalesPrice = e.Price,
                    OldPrice = e.OldPrice,
                    Discount = e.OldPrice > 0 ? ((e.OldPrice - e.Price) / e.OldPrice) * 100 : 0,
                    ImagePath = e.ImagePath
                });

            ViewBag.TopTenProduct = NewTopTenproduct;




            var TopTenProductTwo = _productRepository.All(false)
            .Where(x => x.ComId == abccomid && x.ImagePath != null)
            .Include(x => x.CompanyList)
            .Include(x => x.Category)
            .Include(x => x.ProductReviews)
            .AsEnumerable().Take(5)
            .Select(e => new ProductResultDemo
            {
                ProductId = e.Id,
                CategoryName = e.Category.Name,
                ProductName = e.Name,
                ProductBarcode = e.Code,
                SizeName = e.SizeName,// != null ? e.SizeName.Length > 0 ? "[ " + e.SizeName + " ]" : "" : "",
                                      //BrandName = e.BrandName,
                BrandName = e.Brand != null ? e.Brand.BrandName : "",
                ColorName = e.ColorName,
                CompanyName = e.CompanyList.CompanyName,
                CompanyPhone = e.CompanyList.comPhone,
                ProductReviews = e.ProductReviews.ToList(),
                ProductReviewsCount = e.ProductReviews.Count(),
                Ratings = 2,//e.ProductReviews.Average(x => x.Ratings),
                Description = e.Description,
                //CostPrice = e.CostPrice,
                SalesPrice = e.Price,
                OldPrice = e.OldPrice,
                Discount = e.OldPrice > 0 ? ((e.OldPrice - e.Price) / e.OldPrice) * 100 : 0,
                ImagePath = e.ImagePath
            });

            ViewBag.TopTenProductTwo = TopTenProductTwo;





            var NewTopSaleProduct = _salesItemsRepository.All(false)
                .Where(x => x.ComId == abccomid && x.Product.ImagePath != null)
                .Include(x => x.Product)
                .Include(x => x.CompanyList)
                .Include(x => x.Product).ThenInclude(x => x.Category)
                .Include(x => x.Product).ThenInclude(x => x.ProductReviews)
                .AsEnumerable().TakeLast(10)
                .Select(e => new ProductResultDemo
                {
                    ProductId = e.Id,
                    CategoryName = e.Product.Category.Name,
                    ProductName = e.Name,
                    ProductBarcode = e.Product.Code,
                    SizeName = e.Product.SizeName,// != null ? e.SizeName.Length > 0 ? "[ " + e.SizeName + " ]" : "" : "",
                    //BrandName = e.BrandName,
                    BrandName = e.Product.Brand != null ? e.Product.Brand.BrandName : "",
                    ColorName = e.Product.ColorName,
                    CompanyName = e.CompanyList.CompanyName,
                    CompanyPhone = e.CompanyList.comPhone,
                    ProductReviews = e.Product.ProductReviews.ToList(),
                    ProductReviewsCount = e.Product.ProductReviews.Count(),
                    Ratings = 2,//e.ProductReviews.Average(x => x.Ratings),
                    Description = e.Description,
                    //CostPrice = e.CostPrice,
                    SalesPrice = e.Product.Price,
                    OldPrice = e.Product.OldPrice,
                    Discount = e.Product.OldPrice > 0 ? ((e.Product.OldPrice - e.Product.Price) / e.Product.OldPrice) * 100 : 0,
                    ImagePath = e.Product.ImagePath
                });

            ViewBag.TopSaleProduct = NewTopSaleProduct;



            ViewBag.Category = _categoryRepository.GetAllForDropDownComId(false, abccomid).Where(x => x.Text != "=N/A=").Take(5);

            return View();
        }

        [HttpGet]
        public async Task<IActionResult> Product(int? ProductId)
        {
            var weburl = Request.Host.Value;
            //errorlog(weburl.ToString());
            //ViewBag.weburl = weburl.Trim();
            HttpContext.Session.SetString("weburl", weburl);

            var abccomid = 69;
            //var company = companyRepository.All().Include(x => x.BusinessType).Where(x => x.comWeb.ToLower().Contains(weburl.ToLower())).FirstOrDefault();
            var company = companyRepository.All().Include(x => x.BusinessType).Where(x => x.Id == abccomid).FirstOrDefault();

            if (company != null)
            {
                ViewBag.ComId = company.Id;
                var companysettings = storeSettingRepository.All(false).Where(x => x.ComId == company.Id).FirstOrDefault();
                ViewBag.comImagePath = companysettings.Logo;
                //ViewBag.AppsName = companysettings.BusinessType.AppsName;
                HttpContext.Session.SetString("AppsName", company.BusinessType.AppsName);
            }
            else
            {
                company = companyRepository.All().Include(x => x.BusinessType).Where(x => x.Id == 1).FirstOrDefault();
                ViewBag.ComId = company.Id;
                var companysettings = storeSettingRepository.All(false).Where(x => x.ComId == company.Id).FirstOrDefault();
                ViewBag.comImagePath = companysettings.Logo;
                HttpContext.Session.SetString("AppsName", "Easy Invoice");
            }


            if (ProductId == null)
            {
                return NotFound();
            }

            var product = await _productRepository.All(false)
                .Include(x => x.CompanyList)
                .Include(x => x.Category)
                .Include(x => x.ProductReviews)
                .Select(e => new ProductResultDemo
                {
                    ProductId = e.Id,
                    CategoryId = e.CategoryId,
                    CategoryName = e.Category.Name,
                    ProductName = e.Name,
                    ProductBarcode = e.Code,
                    SizeName = e.SizeName,// != null ? e.SizeName.Length > 0 ? "[ " + e.SizeName + " ]" : "" : "",
                    //BrandName = e.BrandName,
                    BrandName = e.Brand != null ? e.Brand.BrandName : "",
                    ColorName = e.ColorName,
                    CompanyName = e.CompanyList.CompanyName,
                    CompanyPhone = e.CompanyList.comPhone,
                    ProductReviews = e.ProductReviews.ToList(),
                    Description = e.Description,
                    //CostPrice = e.CostPrice,
                    SalesPrice = e.Price,
                    OldPrice = e.OldPrice,
                    ImagePath = e.ImagePath
                })
                .FirstOrDefaultAsync(m => m.ProductId == ProductId);

            ViewBag.Category = _categoryRepository.GetAllForDropDownComId(false, abccomid).Where(x => x.Text != "=N/A=").Take(10);


            var RelatedProduct = _productRepository.All(false)
            .Where(x => x.ComId == company.Id && x.ImagePath != null && x.CategoryId == product.CategoryId)
            .Include(x => x.CompanyList)
            .Include(x => x.Category)
            .Include(x => x.ProductReviews)
            .AsEnumerable().Take(4)
            .Select(e => new ProductResultDemo
            {
                ProductId = e.Id,
                CategoryName = e.Category.Name,
                ProductName = e.Name,
                ProductBarcode = e.Code,
                SizeName = e.SizeName,// != null ? e.SizeName.Length > 0 ? "[ " + e.SizeName + " ]" : "" : "",
                                      //BrandName = e.BrandName,
                BrandName = e.Brand != null ? e.Brand.BrandName : "",
                ColorName = e.ColorName,
                CompanyName = e.CompanyList.CompanyName,
                CompanyPhone = e.CompanyList.comPhone,
                ProductReviews = e.ProductReviews.ToList(),
                ProductReviewsCount = e.ProductReviews.Count(),
                Ratings = 2,//e.ProductReviews.Average(x => x.Ratings),
                Description = e.Description,
                //CostPrice = e.CostPrice,
                SalesPrice = e.Price,
                OldPrice = e.OldPrice,
                Discount = e.OldPrice > 0 ? ((e.OldPrice - e.Price) / e.OldPrice) * 100 : 0,
                ImagePath = e.ImagePath
            }); ;

            ViewBag.RelatedProduct = RelatedProduct;


            if (product == null)
            {
                return NotFound();
            }

            return View(product);
        }

        [HttpGet]
        public IActionResult store()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Checkout()
        {
            return View();
        }


        [HttpGet]
        public IActionResult EcommerceSample()
        {
            var weburl = "Pqstec.com";// Request.Host.Value;
            ViewBag.weburl = weburl.Trim();
            var company = companyRepository.All().Where(x => x.comWeb.ToLower().Contains(weburl.ToLower())).FirstOrDefault();


            var datalist = new SelectList(new List<SelectListItem>{
                    new SelectListItem {Text = "Relevance", Value = "RV"},
                    new SelectListItem {Text = "Price Descending", Value = "PD"},
                    new SelectListItem {Text = "Price Ascending", Value = "PA"},
                    new SelectListItem {Text = "Best Selling", Value = "BS"},
                    new SelectListItem {Text = "Top Review", Value = "TR"},
               }, "Value", "Text");
            ViewBag.Sorting = datalist.ToList();


            if (company != null)
            {
                ViewBag.ComId = company.Id;
                ViewBag.Category = _categoryRepository.All(false).Where(x => x.ComId == company.Id).Select(x => new SelectListItem
                {
                    Text = x.Name,
                    Value = x.Id.ToString(),
                });

                ViewBag.Size = _productRepository.All(false).Where(x => x.ComId == company.Id && x.SizeName.Length > 0).GroupBy(bi => bi.SizeName)
                .Select(x => new SelectListItem { Text = x.Key, Value = x.Key.ToString() }).ToList();


                var companysettings = storeSettingRepository.All(false).Where(x => x.ComId == company.Id).FirstOrDefault();
                ViewBag.comImagePath = companysettings.Logo;
            }
            else
            {

                ViewBag.Category = _categoryRepository.GetAllForDropDown(false);
                ViewBag.Size = _productRepository.All(false).Where(x => x.SizeName.Length > 0).GroupBy(bi => bi.SizeName)
               .Select(x => new SelectListItem { Text = x.Key, Value = x.Key.ToString() }).ToList();

            }
            return View();

        }



        [HttpGet]
        public ActionResult EcommerceIndex(int IsMobile = 1)
        {
            HttpContext.Session.SetInt32("IsMobile", IsMobile);
            var weburl = Request.Host.Value;
            ViewBag.weburl = weburl.Trim();


            //var weburl = Request.Host.Value;
            //errorlog(weburl.ToString());
            //ViewBag.weburl = weburl.Trim();
            HttpContext.Session.SetString("weburl", weburl);

            var company = companyRepository.All().Include(x => x.BusinessType).Where(x => x.comWeb.ToLower().Contains(weburl.ToLower())).FirstOrDefault();

            if (company != null)
            {
                ViewBag.ComId = company.Id;
                var companysettings = storeSettingRepository.All(false).Where(x => x.ComId == company.Id).FirstOrDefault();
                ViewBag.comImagePath = companysettings.Logo;
                //ViewBag.AppsName = companysettings.BusinessType.AppsName;
                HttpContext.Session.SetString("AppsName", company.BusinessType.AppsName);
                HttpContext.Session.SetString("iscompany", "true");
                //HttpContext.Session.SetInt32("UserId", userid);
                HttpContext.Session.SetInt32("ComId", company.Id);

            }
            else
            {
                company = companyRepository.All().Include(x => x.BusinessType).Where(x => x.Id == 1).FirstOrDefault();
                ViewBag.ComId = company.Id;
                var companysettings = storeSettingRepository.All(false).Where(x => x.ComId == company.Id).FirstOrDefault();
                ViewBag.comImagePath = companysettings.Logo;
                HttpContext.Session.SetString("AppsName", "Easy Invoice");
                HttpContext.Session.SetString("iscompany", "false");

            }




            //var company = companyRepository.All().Where(x => x.comWeb.ToLower().Contains(weburl.ToLower())).FirstOrDefault();

            if (company != null)
            {
                ViewBag.ComId = company.Id;
                ViewBag.Category = _categoryRepository.All(false).Where(x => x.ComId == company.Id).Select(x => new SelectListItem
                {
                    Text = x.Name,
                    Value = x.Id.ToString(),
                });

                var companysettings = storeSettingRepository.All(false).Where(x => x.ComId == company.Id).FirstOrDefault();
                ViewBag.comImagePath = companysettings.Logo;
            }
            else
            {

                ViewBag.Category = _categoryRepository.GetAllForDropDown(false);

            }
            return View();
        }



        [HttpPost]
        [AllowAnonymous]
        public IActionResult EcommerceIndex(OrdersModel model)
        {
            try
            {
                //var UserId = HttpContext.Session.GetInt32("UserId");
                //var ComId = HttpContext.Session.GetInt32("ComId");

                ViewBag.ComId = model.ComId;
                ViewBag.weburl = model.Notes;

                var errors = ModelState.Where(x => x.Value.Errors.Any())
                .Select(x => new { x.Key, x.Value.Errors });

                if (ModelState.IsValid)
                {
                    //model.OrdersDate = DateTime.Now;
                    if (model.Id > 0)
                    {
                        _ordersRepository.Update(model, model.Id);

                        foreach (OrdersItemsModel item in model.Items)
                        {

                            if (item.Id > 0)
                            {
                                if (item.IsDelete == true)
                                {
                                    _ordersItemsRepository.Delete(item);
                                }
                                else
                                {
                                    _ordersItemsRepository.Update(item, item.Id);
                                }
                            }
                            else
                            {
                                if (item.IsDelete == true)
                                {
                                }
                                else
                                {
                                    _ordersItemsRepository.Insert(item);
                                }
                            }
                        }



                        TempData["Message"] = "Data Update Successfully";
                        TempData["Status"] = "2";
                        LogRepository.TransactionLog(RouteData.Values["controller"].ToString(), RouteData.Values["action"].ToString(), TempData["Message"].ToString(), model.Id.ToString(), "Update", model.OrderCode);


                        return Json(new { Success = 1, error = false, message = "Date Update successfully" });
                    }
                    else
                    {
                        foreach (var item in model.Items)
                        {
                            item.CreateDate = DateTime.Now;
                            item.UpdateDate = DateTime.Now;


                        }

                        if (model.NetAmount == 0)
                        {
                            model.NetAmount = model.GrandTotal;
                        }

                        if (model.CustomerId == null)
                        {
                            model.CustomerId = _customerRepository.All(false).Where(x => x.ComId == model.ComId).FirstOrDefault().Id;
                        }

                        var orderid = _ordersRepository.InsertEcommerce(model);


                        TempData["Message"] = "Data Save Successfully";
                        TempData["Status"] = "1";
                        LogRepository.TransactionLog(RouteData.Values["controller"].ToString(), RouteData.Values["action"].ToString(), TempData["Message"].ToString(), model.Id.ToString(), "Create", model.OrderCode);



                        return Json(new { Success = 1, Id = orderid, message = "Data Save successfully" });
                    }

                }
                else
                {
                    return Json(new { error = true, message = "failed to Save the Data.  " + errors.FirstOrDefault() }); ;
                }



            }
            catch (Exception ex)
            {

                return Json(new { error = true, message = ex.Message });
            }
        }

        public async Task<IActionResult> ProductDetails(int? ProductId)
        {


            var weburl = Request.Host.Value;
            //errorlog(weburl.ToString());
            //ViewBag.weburl = weburl.Trim();
            HttpContext.Session.SetString("weburl", weburl);

            var company = companyRepository.All().Include(x => x.BusinessType).Where(x => x.comWeb.ToLower().Contains(weburl.ToLower())).FirstOrDefault();

            if (company != null)
            {
                ViewBag.ComId = company.Id;
                var companysettings = storeSettingRepository.All(false).Where(x => x.ComId == company.Id).FirstOrDefault();
                ViewBag.comImagePath = companysettings.Logo;
                //ViewBag.AppsName = companysettings.BusinessType.AppsName;
                HttpContext.Session.SetString("AppsName", company.BusinessType.AppsName);
            }
            else
            {
                company = companyRepository.All().Include(x => x.BusinessType).Where(x => x.Id == 1).FirstOrDefault();
                ViewBag.ComId = company.Id;
                var companysettings = storeSettingRepository.All(false).Where(x => x.ComId == company.Id).FirstOrDefault();
                ViewBag.comImagePath = companysettings.Logo;
                HttpContext.Session.SetString("AppsName", "Easy Invoice");
            }


            if (ProductId == null)
            {
                return NotFound();
            }

            var product = await _productRepository.All(false)
                .Include(x => x.CompanyList)
                .Include(x => x.Category)
                .Include(x => x.ProductReviews)
                .Select(e => new ProductResultDemo
                {
                    ProductId = e.Id,
                    CategoryName = e.Category.Name,
                    ProductName = e.Name,
                    ProductBarcode = e.Code,
                    SizeName = e.SizeName,// != null ? e.SizeName.Length > 0 ? "[ " + e.SizeName + " ]" : "" : "",
                    //BrandName = e.BrandName,
                    BrandName = e.Brand != null ? e.Brand.BrandName : "",
                    ColorName = e.ColorName,
                    CompanyName = e.CompanyList.CompanyName,
                    CompanyPhone = e.CompanyList.comPhone,
                    ProductReviews = e.ProductReviews.ToList(),
                    Description = e.Description,
                    //CostPrice = e.CostPrice,
                    SalesPrice = e.Price,
                    OldPrice = e.OldPrice,
                    ImagePath = e.ImagePath
                })
                .FirstOrDefaultAsync(m => m.ProductId == ProductId);

            if (product == null)
            {
                return NotFound();
            }

            return View(product);
        }


        public static List<int> TraverseTree(List<CategoryModel> list, List<int> arraycategoryid)
        {
            //List<int> arraycategoryid = new List<int>();

            foreach (var item in list)
            {
                arraycategoryid.Add(item.Id);
                if (item.ChildCategoryList != null)
                {
                    TraverseTree(item.ChildCategoryList.ToList(), arraycategoryid);
                }
            }

            return arraycategoryid;
        }

        public IActionResult GetProductListClick(int CategoryId, string BrandName, bool iscompany)
        {
            try
            {
                var productlist = _productRepository.All(iscompany).Where(x => x.Id > 0 && x.Name.Length > 5 && x.IsPublished == true && x.ImagePath.Length > 23);


                if (CategoryId > 0)
                {



                    //productlist = productlist.Where(x => x.CategoryId == CategoryId);
                    List<int> arraycategoryid = new List<int>();
                    arraycategoryid.Add(CategoryId);


                    List<CategoryModel> resultlist = _categoryRepository.All().Where(x => x.Id == CategoryId).SelectMany(x => x.ChildCategoryList).ToList();

                    arraycategoryid = TraverseTree(resultlist, arraycategoryid).ToList();

                    productlist = productlist.Where(p => arraycategoryid.Contains(p.CategoryId.GetValueOrDefault()));




                }

                //if (BrandName != null)
                //{
                //    productlist = productlist.Where(x => x.BrandName == BrandName);
                //}
                var query = from e in productlist.OrderByDescending(x => x.Id)
                            select new ProductResultDemo
                            {
                                CategoryId = e.CategoryId,
                                ProductId = e.Id,

                                //ProductImage = e.ProductImage != null ? Convert.ToBase64String(e.ProductImage) : null,
                                //CategoryName = e.vPrimaryCategory.Name,
                                ProductName = e.Name ?? "",

                                //ProductCode = e.ProductCode,
                                ProductBarcode = e.Code ?? "",
                                SizeName = e.SizeName ?? "",// != null ? e.SizeName.Length > 0 ? "[ " + e.SizeName + " ]" : "" : "",
                                //BrandName = e.BrandName ?? "",//e.BrandName != null ? e.BrandName : "",
                                BrandName = e.Brand != null ? e.Brand.BrandName : "",
                                ColorName = e.ColorName ?? "",


                                //Description = e.Description,
                                //CostPrice = e.CostPrice,
                                SalesPrice = e.Price,
                                OldPrice = e.OldPrice,

                                //BlankData = null,

                                ImagePath = e.ImagePath ?? ""
                                //ProductImage = e.ProductImage != null ? Convert.ToBase64String(e.ProductImage) : null,//(asset.ProductImage != null) ? (asset.ProductImage) : null
                                //WarehouseList = WarehouseQty

                            };



                var parser = new Parser<ProductResultDemo>(Request.Form, query);

                return Json(parser.Parse());


            }
            catch (Exception ex)
            {

                Console.WriteLine(ex.Message);
                return Json(ex.Message);
                //throw ex;
            }
        }

        [HttpGet]
        //[AllowAnonymous]
        public ActionResult OrdersReport(int OrderId)
        {
            //var UserId = HttpContext.Session.GetInt32("UserId");
            //var ComId = HttpContext.Session.GetInt32("ComId");

            //var weburl = "http://localhost:2553/Home/OrdersReport";//Request.GetTypedHeaders().Referer.ToString().ToLower();//.Replace("/Home/Login".ToLower(), "");

            var weburl = Request.Host.Value.ToLower() + Request.Path.Value.ToLower() + Request.QueryString.Value.ToLower();

            var weburlquerystring = Request.QueryString.HasValue == true ? Request.QueryString.ToString() : "";// Request.QueryString == null ? "": Request.QueryString;// Request.QueryString?? Request.QueryString;//.Replace("/Home/Login".ToLower(), "");

            var origin = weburl.ToLower();
            var controllerName = this.ControllerContext.RouteData.Values["Controller"].ToString().ToLower();


            string St = weburl.ToLower();
            int pFrom = St.IndexOf("/?");

            if (pFrom > 0)
            {
                var filterurl = St.Substring(0, pFrom);
                origin = filterurl;
            }
            string resulta = "";

            if (weburlquerystring.Length > 2)
            {
                resulta = origin.Replace(weburlquerystring, "").Replace("/Home/OrdersReport".ToLower(), "");

            }
            else
            {
                resulta = origin.Replace("/Home/OrdersReport".ToLower(), "");

            }


            var ComId = _ordersRepository.All(false).Where(x => x.Id == OrderId).FirstOrDefault().ComId;

            var storeinfo = storeSettingRepository.All(false).Where(x => x.ComId == ComId)
                            .Include(x => x.SalesReportStyle)
                            .Include(x => x.PurchaseReportStyle)
                            .Include(x => x.BarcodeReportStyle).FirstOrDefault();
            var ReportStyle = storeinfo.SalesReportStyle != null ? storeinfo.SalesReportStyle.ReportStyleName : "Style1";



            string reportname = "rptInvoice";
            var filename = "Invoice_";


            if (ReportStyle.ToString().Length > 0)
            {
                reportname = "rptInvoice_" + ReportStyle.ToString();
            }

            HttpContext.Session.SetString("ReportQuery", "Exec [rptOnlineOrders] '" + OrderId + "','" + ComId + "', '" + weburl + "','Invoice'");
            HttpContext.Session.SetString("ReportPath", "~/ReportViewer/POS/" + reportname + ".rdlc");
            HttpContext.Session.SetString("PrintFileName", filename.Replace(".", "").Replace(" ", "").Replace(",", "").Replace("\"", ""));


            postData.Add(2, new subReport("rptInvoice_PM", "", "DataSet1", "Exec rptInvoice_PM '" + OrderId + "'," + ComId + ""));
            HttpContext.Session.SetObject("rptList", postData);


            Atrai.Model.AppData.DefaultConnectionString = Config.GetConnectionString("DefaultConnection");

            return RedirectToAction("Index", "ReportViewer");
        }
        [HttpPost]
        [AllowAnonymous]
        //[ValidateAntiForgeryToken]
        //[Route("/login")]
        public async Task<IActionResult> Login(LoginViewModel user)
        {


            if (user.CredentialType == "U")
            {
                #region UserLogin
                #region weburlinfo
                var weburl = Request.GetTypedHeaders().Referer.ToString().ToLower();//.Replace("/Home/Login".ToLower(), "");
                var weburlquerystring = Request.QueryString.HasValue == true ? Request.QueryString.ToString() : "";// Request.QueryString == null ? "": Request.QueryString;// Request.QueryString?? Request.QueryString;//.Replace("/Home/Login".ToLower(), "");

                var origin = weburl.ToLower();
                var controllerName = this.ControllerContext.RouteData.Values["Controller"].ToString().ToLower();


                string St = weburl.ToLower();
                int pFrom = St.IndexOf("/?");

                if (pFrom > 0)
                {
                    var filterurl = St.Substring(0, pFrom);
                    origin = filterurl;
                }
                //string example = "Hello, World!";

                //// Get the 5 characters from the left of the string
                //string exampleLeft = example.Substring(0, 5);



                //String St = weburl.ToLower();

                //int pFrom = St.IndexOf("/") + "/".Length;
                //int pTo = St.LastIndexOf("/" + controllerName);
                string resulta = "";
                //if (pTo < 1)
                //{
                //    resulta = origin;

                //}
                //else
                //{
                //    resulta = St.Substring(pFrom, pTo - pFrom);
                //    resulta = origin + "/" + resulta;

                //}


                if (weburlquerystring.Length > 2)
                {
                    resulta = origin.Replace(weburlquerystring, "").Replace("/Home/Login".ToLower(), "");

                }
                else
                {
                    resulta = origin.Replace("/Home/Login".ToLower(), "");

                }

                #endregion



                if (ModelState.IsValid)
                {
                    bool result = userAccountRepository.ValidateUser(user);



                    if (result)
                    {
                        #region email send if not confirmed email by user or by click from the email link 
                        var Emailverifiedinfo = userAccountRepository.All(false).Where(x => x.Email == user.Email && x.IsEmailVerified == false).ToList();
                        if (Emailverifiedinfo.Count > 0)
                        {
                            TempData["UserLoginFailed"] = "Email Not Confirmed Yet. Please check Your mail to Activate Your user Account. or Contact with your service provider 01671303302.";
                            var OTPvalue = ValuesController.randomnumbergenerate(4, 1050, 9999).ToString();
                            int usercomid = userAccountRepository.GetComId(user);
                            var compnayinfo = companyRepository.Find(usercomid);

                            //var userconfirmtiondata = userAccountRepository.All(false).Where(x => x.Email == user.Email).FirstOrDefault();

                            //if (userconfirmtiondata != null)
                            //{
                            //    userconfirmtiondata.OTP = OTPvalue;
                            //    userAccountRepository.Update(userconfirmtiondata, userconfirmtiondata.Id);
                            //}

                            if (user.Email != null && Emailverifiedinfo.FirstOrDefault().OTP != "" || Emailverifiedinfo.FirstOrDefault().OTP != null)
                            {
                                //return RedirectToAction("EmailConfirmation", "Home", new { Email = user.Email, PhoneNo = Emailverifiedinfo.FirstOrDefault().PhoneNumber });
                                return RedirectToAction("OTPConfirmation", "Home", new { Email = user.Email, PhoneNo = Emailverifiedinfo.FirstOrDefault().PhoneNumber });

                                //var callBackUrl = Url.ActionLink("UserConfirmation", "Home", new { Email = user.Email, OTPValue = OTPvalue });
                                //string mailList = user.Email;
                                //string subject = $"User has been created Successfully for Compnay  {compnayinfo.CompanyName}";
                                //string body = $"Thanks for Register Your Email for {compnayinfo.CompanyName} . <br/><br/> Created Time : - {DateTime.Now}<br/>To Activate Account Please follow the link <br/><br/><a href='{HtmlEncoder.Default.Encode(callBackUrl)}'>Active the Email by Clicking Here</a>";
                                //var hostaddressforsender = Request.GetTypedHeaders().Host.Value;

                                //SendEmail(mailList, subject, body , hostaddressforsender);
                            }

                            return View();
                        }

                        #endregion




                        //var claims = new List<Claim>
                        //{
                        //    new Claim(ClaimTypes.Name, user.Email , user.EmpImagePath )
                        //};
                        //var _claim = new Claim("Role", userdata.UserRole.RoleName);
                        //claims.Add(_claim);
                        //ClaimsIdentity userIdentity = new ClaimsIdentity(claims, "login");
                        //ClaimsPrincipal principal = new ClaimsPrincipal(userIdentity);

                        Atrai.Model.AppData.DefaultConnectionString = Config.GetConnectionString("DefaultConnection");



                        int? vatview = HttpContext.Session.GetInt32("VatViewActivate");
                        if (vatview == null || vatview == 0)
                        {
                            HttpContext.Session.SetInt32("VatViewActivate", 0);
                        }
                        else
                        {
                            HttpContext.Session.SetInt32("VatViewActivate", 1);
                        }



                        HttpContext.Session.SetInt32("IsMobile", 0);

                        int UserId = userAccountRepository.GetUserId(user);
                        HttpContext.Session.SetInt32("UserId", UserId);

                        int ComId = userAccountRepository.GetComId(user);
                        HttpContext.Session.SetInt32("ComId", ComId);

                        string ComName = companyRepository.GetComName(ComId);
                        HttpContext.Session.SetString("ComName", ComName);





                        HttpContext.Session.SetString("UserInfo", user.Email);

                        //var rolename = userAccountRepository.All(false).Where(A => A.Id == UserId).Include(x => x.UserRole).Include(x => x.EmployeeList).FirstOrDefault();
                        //HttpContext.Session.SetString("RoleName", rolename.UserRole.RoleName);


                        HttpContext.Session.SetInt32("PurchasePackage", 0);
                        if (userAccountRepository.All().Include(x => x.UserRole).Where(x => x.Id == UserId).FirstOrDefault().UserRole.RoleName != "SuperAdmin")
                        {
                            var subscriptionactivationdata = _subscriptionActivationRepository.All().Where(x => x.LuserId == UserId && x.ActiveToDate > DateTime.Now.Date).FirstOrDefault();

                            //HttpContext.Session.SetInt32("UserValidityDays", (int)subscriptionactivationdata.ValidityDay);

                            HttpContext.Session.SetInt32("UserValidityDays", (int)(subscriptionactivationdata?.ValidityDay ?? 0));

                            //userdata.EmployeeList?.EmployeeImagePath ?? ""
                            HttpContext.Session.SetInt32("ShowAlert", 1);



                            if (subscriptionactivationdata == null)
                            {
                                HttpContext.Session.SetInt32("PurchasePackage", 1);

                                ////off after talk with mr. noman
                                //TempData["UserLoginFailed"] = "User Expired . Please Activate Your user by Pay renewal fee.. or Contact with your service provider 01671303302.";
                                //return View();

                            }


                            //var activatepackage = _packageActivationRepository.All().Where(x => x.ComId == ComId && x.ActiveYesNo == true).OrderByDescending(x => x.Id).FirstOrDefault();

                            //if (activatepackage == null)
                            //{
                            //    return RedirectToAction("PurchasePackage", "License");
                            //    /// return RedirectToAction(firstmenu.Menus.ActionName, firstmenu.Menus.ControllerName);
                            //}


                        }



                        //return View(saleRepository.All().Include(x => x.CustomerModel).OrderByDescending(x => x.Id));

                        var userdata = userAccountRepository.All().Include(x => x.UserRole).Include(x => x.EmployeeList).Where(x => x.Id == UserId).FirstOrDefault();
                        var claims = new List<Claim>
                    {
                        new Claim(ClaimTypes.Name, user.Email , user.EmpImagePath )
                    };
                        var _claim = new Claim("Role", userdata.UserRole.RoleName);
                        claims.Add(_claim);
                        ClaimsIdentity userIdentity = new ClaimsIdentity(claims, "login");
                        ClaimsPrincipal principal = new ClaimsPrincipal(userIdentity);

                        //applicat

                        HttpContext.Session.SetInt32("UserRoleId", userdata.UserRoleId ?? 0);
                        HttpContext.Session.SetString("UserRole", userdata.UserRole.RoleName ?? "");


                        HttpContext.Session.SetString("EmpImagePath", userdata.EmployeeList?.EmployeeImagePath ?? "");

                        if (userdata.UserRole.RoleName.Contains("SuperAdmin"))
                        {
                            HttpContext.Session.SetInt32("IsUserLevel", 1);

                            //HttpContext.Session.SetInt32("IsSuperAdmin", 1);
                            //HttpContext.Session.SetInt32("IsAdmin", 0);
                            //HttpContext.Session.SetInt32("IsUser", 0);
                        }
                        else if (userdata.UserRole.RoleName.Contains("Admin"))
                        {
                            HttpContext.Session.SetInt32("IsUserLevel", 2);


                            //HttpContext.Session.SetInt32("IsSuperAdmin", 0);
                            //HttpContext.Session.SetInt32("IsAdmin", 1);
                            //HttpContext.Session.SetInt32("IsUser", 0);
                        }
                        else if (userdata.UserRole.RoleName.Contains("User"))
                        {
                            HttpContext.Session.SetInt32("IsUserLevel", 3);


                            //HttpContext.Session.SetInt32("IsSuperAdmin", 0);
                            //HttpContext.Session.SetInt32("IsAdmin", 0);
                            //HttpContext.Session.SetInt32("IsUser", 1);
                        }
                        else
                        {
                            HttpContext.Session.SetInt32("IsUserLevel", 4);


                            //HttpContext.Session.SetInt32("IsSuperAdmin", 0);
                            //HttpContext.Session.SetInt32("IsAdmin", 0);
                            //HttpContext.Session.SetInt32("IsUser", 0);
                        }



                        if (userdata.UserRole.RoleName.Contains("SuperAdmin"))
                        {
                            var CompanyUserList = companyRepository.All().Select(x => new SelectListItem { Text = x.CompanyName, Value = x.Id.ToString() }).OrderBy(x => x.Value).ToList();

                            //var CompanyUserList = _companyPermissionRepository.All().Include(x => x.CompanyList).Where(x => x.ComId == ComId && x.LuserId == UserId).Select(x => new SelectListItem { Text = x.CompanyList.CompanyName, Value = x.ComId.ToString() }).OrderBy(x=>x.Value).ToList();
                            if (CompanyUserList.Count > 0)
                            {
                                HttpContext.Session.SetObject("UserCompanys", CompanyUserList);
                            }
                        }
                        else //if (!userdata.UserRole.RoleName.Contains("Admin"))
                        {
                            /////////////if multi compnay is avaialable but he have only single company permission not the default one.
                            var CompanyUserList = _companyPermissionRepository.All().Include(x => x.CompanyList).Where(x => x.LuserId == UserId).Select(x => new SelectListItem { Text = x.CompanyList.CompanyName, Value = x.ComId.ToString() }).ToList();
                            HttpContext.Session.SetObject("UserCompanys", CompanyUserList);

                            if (CompanyUserList.Count() > 0)
                            {
                                ComId = int.Parse(CompanyUserList.FirstOrDefault().Value);
                                HttpContext.Session.SetInt32("ComId", ComId);

                                ComName = CompanyUserList.FirstOrDefault().Text;
                                HttpContext.Session.SetString("ComName", ComName);
                            }
                        }
                        //////////need to set the permit compnay 


                        var company = companyRepository.All().Where(x => x.Id == ComId).Include(x => x.BusinessType).FirstOrDefault();
                        var storeinfo = storeSettingRepository.All().Where(x => x.ComId == ComId)
                            .Include(x => x.SalesReportStyle)
                            .Include(x => x.PurchaseReportStyle)
                            .Include(x => x.BarcodeReportStyle)
                                                .Include(x => x.TimeZones)
                                                .Include(x => x.Currency)
                            .FirstOrDefault();

                        HttpContext.Session.SetString("ShortCutKey", storeinfo.ShortCutKey != null ? storeinfo.ShortCutKey : "q"); // "y"
                        HttpContext.Session.SetString("SearchType", storeinfo.isScanner == true ? "Scanner" : "Manual"); // "Scanner"
                        HttpContext.Session.SetString("barcodeprefixforweightscale", storeinfo.BarcodePrefixForWeightScale != null ? storeinfo.BarcodePrefixForWeightScale : "99"); // "Scanner"


                        HttpContext.Session.SetInt32("BaseComId", storeinfo.BaseComId);

                        HttpContext.Session.SetInt32("BusinessTypeId", company.BusinessTypeId);
                        HttpContext.Session.SetString("BusinessType", company.BusinessType.BusinessTypeName);
                        HttpContext.Session.SetString("AppsName", company.BusinessType.AppsName);


                        HttpContext.Session.SetString("CompanyName", company.CompanyName != null ? company.CompanyName : "");
                        HttpContext.Session.SetString("PrimaryAddress", company.PrimaryAddress != null ? company.PrimaryAddress : "");
                        HttpContext.Session.SetString("SecoundaryAddress", company.SecoundaryAddress != null ? company.SecoundaryAddress : "");
                        HttpContext.Session.SetString("comPhone", company.comPhone != null ? company.comPhone : "");
                        HttpContext.Session.SetString("comWeb", company.comWeb != null ? company.comWeb : "");
                        HttpContext.Session.SetString("comEmail", company.comEmail != null ? company.comEmail : "");
                        HttpContext.Session.SetString("CaptionOne", "CaptionOne");
                        HttpContext.Session.SetString("CaptionTwo", "CaptionTwo");
                        HttpContext.Session.SetString("PrintDate", DateTime.Now.Date.ToString("dd-MMM-yy"));
                        HttpContext.Session.SetString("comImagePath", storeinfo != null ? storeinfo.Logo != null ? storeinfo.Logo : "" : "");
                        HttpContext.Session.SetString("weburl", resulta.ToString());

                        HttpContext.Session.SetString("OfferDiscountPer", storeinfo != null ? storeinfo.OfferDiscountPer.ToString() : "0.00");
                        HttpContext.Session.SetInt32("isDiscountOffer", storeinfo != null ? storeinfo.isDiscountOffer != false ? 1 : 0 : 0);


                        HttpContext.Session.SetString("TaxPer", storeinfo != null ? storeinfo.TaxPer.ToString() : "0.00");
                        HttpContext.Session.SetString("SalesReportStyle", storeinfo.SalesReportStyle != null ? storeinfo.SalesReportStyle.ReportStyleName : "Style1");
                        HttpContext.Session.SetString("PurchaseReportStyle", storeinfo.PurchaseReportStyle != null ? storeinfo.PurchaseReportStyle.ReportStyleName : "Style1");
                        HttpContext.Session.SetString("BarcodeReportStyle", storeinfo.BarcodeReportStyle != null ? storeinfo.BarcodeReportStyle.ReportStyleName : "Style1");

                        HttpContext.Session.SetInt32("isTaxExcluded", storeinfo != null ? storeinfo.isTaxExcluded != false ? 1 : 0 : 0);

                        HttpContext.Session.SetInt32("isMultiSelect", storeinfo != null ? storeinfo.isMultiSelect != false ? 1 : 0 : 0);
                        HttpContext.Session.SetInt32("isFixedSalesValue", storeinfo != null ? storeinfo.IsFixedSalesValue != false ? 1 : 0 : 0);
                        HttpContext.Session.SetInt32("IsFirstLetterUpperCase", storeinfo != null ? storeinfo.IsFirstLetterUpperCase != false ? 1 : 0 : 0);


                        HttpContext.Session.SetInt32("IsSerialSales", storeinfo != null ? storeinfo.IsSerialSales != false ? 1 : 0 : 0);
                        HttpContext.Session.SetInt32("IsIndDiscount", storeinfo != null ? storeinfo.IsIndDiscount != false ? 1 : 0 : 0);
                        HttpContext.Session.SetInt32("IsSalesDescription", storeinfo != null ? storeinfo.IsSalesDescription != false ? 1 : 0 : 0);
                        HttpContext.Session.SetInt32("IsVatLogin", storeinfo != null ? storeinfo.IsVatLogin != false ? 1 : 0 : 0);
                        HttpContext.Session.SetInt32("isMultiCurrency", storeinfo != null ? storeinfo.isMultiCurrency != false ? 1 : 0 : 0);
                        HttpContext.Session.SetInt32("IsTermsCondition", storeinfo != null ? storeinfo.IsTermsCondition != false ? 1 : 0 : 0);
                        HttpContext.Session.SetInt32("IsDefaultDisAmount", storeinfo != null ? storeinfo.IsDefaultDisAmount != false ? 1 : 0 : 0);
                        HttpContext.Session.SetInt32("DecimalField", storeinfo != null ? storeinfo.DecimalField : 0);


                        HttpContext.Session.SetInt32("IsFixedDiscountMainValue", storeinfo != null ? storeinfo.IsFixedDiscountMainValue != false ? 1 : 0 : 0);
                        HttpContext.Session.SetInt32("IsFixedDiscountRowValue", storeinfo != null ? storeinfo.IsFixedDiscountRowValue != false ? 1 : 0 : 0);
                        HttpContext.Session.SetString("MaxDiscountMainValue", storeinfo != null ? storeinfo.MaxDiscountMainValue.ToString() : "0.00");
                        HttpContext.Session.SetString("MaxDiscountPercentageMainValue", storeinfo != null ? storeinfo.MaxDiscountPercentageMainValue.ToString() : "0.00");
                        HttpContext.Session.SetString("MaxDiscountRowValue", storeinfo != null ? storeinfo.MaxDiscountRowValue.ToString() : "0.00");




                        HttpContext.Session.SetInt32("PrintProductName", storeinfo != null ? storeinfo.PrintProductName != false ? 1 : 0 : 0);
                        HttpContext.Session.SetInt32("PrintProductCode", storeinfo != null ? storeinfo.PrintProductCode != false ? 1 : 0 : 0);
                        HttpContext.Session.SetInt32("PrintProductDescription", storeinfo != null ? storeinfo.PrintProductDescription != false ? 1 : 0 : 0);
                        HttpContext.Session.SetInt32("PrintBrandName", storeinfo != null ? storeinfo.PrintBrandName != false ? 1 : 0 : 0);
                        HttpContext.Session.SetInt32("PrintModelName", storeinfo != null ? storeinfo.PrintModelName != false ? 1 : 0 : 0);
                        HttpContext.Session.SetInt32("PrintSizeName", storeinfo != null ? storeinfo.PrintSizeName != false ? 1 : 0 : 0);
                        HttpContext.Session.SetInt32("VisibleSalesCommission", storeinfo != null ? storeinfo.VisibleSalesCommission != false ? 1 : 0 : 0);



                        HttpContext.Session.SetString("isMultiDebitCredit", storeinfo.isMultiDebitCredit.ToString());
                        //HttpContext.Session.SetString("isMultiCurrency", company.isMultiCurrency.ToString());

                        HttpContext.Session.SetString("isVoucherDistributionEntry", storeinfo.isVoucherDistributionEntry.ToString());
                        HttpContext.Session.SetString("isChequeDetails", storeinfo.isChequeDetails.ToString());

                        HttpContext.Session.SetString("isSMSService", storeinfo.isSMSService.ToString());
                        HttpContext.Session.SetString("isEmailSerivce", storeinfo.isEmailSerivce.ToString());
                        HttpContext.Session.SetString("IsSignature", company != null ? storeinfo.IsSignature.ToString() : "false");


                        HttpContext.Session.SetInt32("defaultcurrencyid", storeinfo.CountryId);
                        HttpContext.Session.SetString("defaultcurrencyname", storeinfo.Currency.CurrencyShortName.ToString());
                        HttpContext.Session.SetInt32("TimeZoneSettingsId", storeinfo.TimeZones != null ? storeinfo.TimeZoneSettingsId : 36);
                        HttpContext.Session.SetString("TimeZoneSettingsName", storeinfo.TimeZones != null ? storeinfo.TimeZones.TimeZoneName : "");
                        HttpContext.Session.SetString("TimeZoneSettingsNameJquery", storeinfo.TimeZones != null ? storeinfo.TimeZones.TimeZoneNameJquery : "");







                        //HttpContext.Session.SetObject("UserAllMenu", _menuPermissionRepository.All().Include(x => x.Menu).Where(x => x.UserRoleId == userdata.UserRoleId && x.BusinessTypeId == company.BusinessTypeId).OrderBy(x => x.Menu.DisplayOrder));
                        //HttpContext.Session.SetObject("UserGroupMenu", _menuPermissionRepository.All().Include(x => x.Menu).Where(x => x.Menu.isGroup == true && x.UserRoleId == userdata.UserRoleId && x.BusinessTypeId == company.BusinessTypeId).OrderBy(x => x.Menu.DisplayOrder));
                        //HttpContext.Session.SetObject("UserParentMenu", _menuPermissionRepository.All().Include(x => x.Menu).Where(x => x.Menu.isParent == true && x.UserRoleId == userdata.UserRoleId && x.BusinessTypeId == company.BusinessTypeId).OrderBy(x => x.Menu.DisplayOrder));
                        //HttpContext.Session.SetObject("UserChildMenu", _menuPermissionRepository.All().Include(x => x.Menu).Where(x => x.Menu.ParentId != null && x.UserRoleId == userdata.UserRoleId && x.BusinessTypeId == company.BusinessTypeId).OrderBy(x => x.Menu.DisplayOrder));





                        //HttpContext.Session.SetObject("UserAllMenu", _menuPermissionMasterRepository.All().Include(x => x.MenuPermission_Details).ThenInclude(x => x.Menus).Where(x => x.LUserIdPermission == UserId));






                        if (userdata.IsBaseUser == true)
                        {
                            var userpermissionmenulist = _menuPermissionRepository.All().Include(x => x.Menus).Where(x => x.BusinessTypeId == company.BusinessTypeId);

                            if (storeinfo.IsVatLogin == true)
                            {
                                userpermissionmenulist = userpermissionmenulist.Where(x => x.Menus.IsVatMenu == true);
                                HttpContext.Session.SetInt32("VatViewActivate", 1);
                            }

                            List<UserMenuPermissionViewModel> userallmenulist = new List<UserMenuPermissionViewModel>();

                            if (userpermissionmenulist != null)
                            {
                                foreach (var item in userpermissionmenulist.OrderBy(x => x.Menus.DisplayOrder))
                                {
                                    UserMenuPermissionViewModel usermenudata = new UserMenuPermissionViewModel();

                                    usermenudata.Id = item.Menus.Id;

                                    usermenudata.ActionName = item.Menus.ActionName;
                                    usermenudata.ControllerName = item.Menus.ControllerName;
                                    usermenudata.IsCreate = true;// item.IsCreate;
                                    usermenudata.IsView = true;// item.IsCreate;
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
                                    usermenudata.FirstParameter = item.Menus.FirstParameter;
                                    usermenudata.FirstValue = item.Menus.FirstValue;


                                    userallmenulist.Add(usermenudata);
                                }
                            }

                            HttpContext.Session.SetObject("UserAllMenu", userallmenulist);
                            HttpContext.Session.SetObject("UserGroupMenu", userallmenulist.Where(x => x.IsGroup == true));
                            HttpContext.Session.SetObject("UserParentMenu", userallmenulist.Where(x => x.IsParent == true));
                            HttpContext.Session.SetObject("UserChildMenu", userallmenulist.Where(x => x.ParentId != null));


                        }
                        else
                        {

                            var userpermissionmenulist = _menuPermissionDetailsRepository.All().Include(x => x.MenuPermissionMasters).Include(x => x.Menus).Where(x => x.MenuPermissionMasters.LUserIdPermission == UserId && x.MenuPermissionMasters.ComId == ComId);

                            //HttpContext.Session.SetString("SummaryView", userpermissionmenulist.FirstOrDefault().MenuPermissionMasters.SummaryView.ToString()); /// fahad need to check for sales summary view activate


                            if (storeinfo.IsVatLogin == true)
                            {
                                userpermissionmenulist = userpermissionmenulist.Where(x => x.Menus.IsVatMenu == true);
                                HttpContext.Session.SetInt32("VatViewActivate", 1);
                            }

                            List<UserMenuPermissionViewModel> userallmenulist = new List<UserMenuPermissionViewModel>();

                            if (userpermissionmenulist != null)
                            {
                                foreach (var item in userpermissionmenulist.OrderBy(x => x.Menus.DisplayOrder))
                                {
                                    UserMenuPermissionViewModel usermenudata = new UserMenuPermissionViewModel();

                                    usermenudata.Id = item.Menus.Id;

                                    usermenudata.ActionName = item.Menus.ActionName;
                                    usermenudata.ControllerName = item.Menus.ControllerName;
                                    usermenudata.IsView = item.IsView;
                                    usermenudata.IsCreate = item.IsCreate;
                                    usermenudata.IsDeleteP = item.IsDeleteP;
                                    usermenudata.IsEdit = item.IsEdit;
                                    usermenudata.isDefault = item.isDefault;
                                    usermenudata.SLNo = item.SLNo;

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
                                    usermenudata.FirstParameter = item.Menus.FirstParameter;
                                    usermenudata.FirstValue = item.Menus.FirstValue;

                                    userallmenulist.Add(usermenudata);
                                }
                            }

                            HttpContext.Session.SetObject("UserAllMenu", userallmenulist);
                            HttpContext.Session.SetObject("UserGroupMenu", userallmenulist.Where(x => x.IsGroup == true));
                            HttpContext.Session.SetObject("UserParentMenu", userallmenulist.Where(x => x.IsParent == true));
                            HttpContext.Session.SetObject("UserChildMenu", userallmenulist.Where(x => x.ParentId != null));

                        }







                        //if (userdata.UserRole.RoleName.Contains("SuperAdmin"))
                        //{
                        //    var CompanyUserList = companyRepository.All().Select(x => new SelectListItem { Text = x.CompanyName, Value = x.Id.ToString() }).OrderBy(x => x.Value).ToList();


                        //    //var CompanyUserList = _companyPermissionRepository.All().Include(x => x.CompanyList).Where(x => x.ComId == ComId && x.LuserId == UserId).Select(x => new SelectListItem { Text = x.CompanyList.CompanyName, Value = x.ComId.ToString() }).OrderBy(x=>x.Value).ToList();
                        //    if (CompanyUserList.Count > 0)
                        //    {
                        //        HttpContext.Session.SetObject("UserCompanys", CompanyUserList);
                        //    }
                        //}
                        //else //if (!userdata.UserRole.RoleName.Contains("Admin"))
                        //{

                        //    var CompanyUserList = _companyPermissionRepository.All().Include(x => x.CompanyList).Where(x => x.LuserId == UserId).Select(x => new SelectListItem { Text = x.CompanyList.CompanyName, Value = x.ComId.ToString() }).ToList();
                        //    // x.ComId == ComId && 
                        //    //if (CompanyUserList.Count > 0) 
                        //    //{
                        //    HttpContext.Session.SetObject("UserCompanys", CompanyUserList);
                        //    //}
                        //}
                        ////////////need to set the permit compnay 











                        //HttpContext.Session.SetObject("UserGroupMenu", _menuPermissionDetailsRepository.All().Include(x => x.MenuPermissionMasters).Include(x => x.Menus).Where(x => x.Menus.isGroup == true && x.MenuPermissionMasters.LUserIdPermission == UserId).OrderBy(x => x.SLNo));
                        //var testmenu = HttpContext.Session.GetObject<List<MenuPermission_DetailsModel>>("UserGroupMenu");


                        //HttpContext.Session.SetObject("UserParentMenu", _menuPermissionDetailsRepository.All().Include(x => x.MenuPermissionMasters).Include(x => x.Menus).Where(x => x.Menus.isParent == true && x.MenuPermissionMasters.LUserIdPermission == UserId).OrderBy(x => x.SLNo));
                        //HttpContext.Session.SetObject("UserChildMenu", _menuPermissionDetailsRepository.All().Include(x => x.MenuPermissionMasters).Include(x => x.Menus).Where(x => x.Menus.ParentId != null && x.MenuPermissionMasters.LUserIdPermission == UserId).OrderBy(x => x.SLNo));
                        HttpContext.Session.SetObject("MenuList", _menuRepository.All().OrderBy(x => x.ParentMenu.DisplayOrder));





                        var countryinfo = _countryRepository.All().Where(x => x.Id == storeinfo.CountryId).FirstOrDefault();
                        var countryinfoViewFormat = _countryRepository.All().Where(x => x.Id == 231).FirstOrDefault();

                        //var cultureInfo = new CultureInfo(countryinfo.CultureInfo);
                        //cultureInfo.NumberFormat.CurrencySymbol = countryinfo.CurrencySymbol;
                        //CultureInfo.DefaultThreadCurrentCulture = cultureInfo;
                        //CultureInfo.DefaultThreadCurrentUICulture = cultureInfo;


                        HttpContext.Session.SetString("CurrencyShortNameViewFormat", countryinfoViewFormat.CurrencyShortName);
                        HttpContext.Session.SetString("CultureInfoViewFormat", countryinfoViewFormat.CultureInfo);
                        HttpContext.Session.SetString("CountryShortNameViewFormat", countryinfoViewFormat.CountryShortName);
                        HttpContext.Session.SetString("CurrencySymbolViewFormat", countryinfoViewFormat.CurrencySymbol);


                        HttpContext.Session.SetString("CurrencyShortName", countryinfo.CurrencyShortName);
                        HttpContext.Session.SetString("CultureInfo", countryinfo.CultureInfo);
                        HttpContext.Session.SetString("CountryShortName", countryinfo.CountryShortName);
                        HttpContext.Session.SetString("CurrencySymbol", countryinfo.CurrencySymbol);


                        ///off by fahad
                        //var fiscalyear = _accFiscalYearRepository.All().Where(x => x.OpeningDate.Year == DateTime.Now.Year).ToList().Count();

                        //if (fiscalyear == 0)
                        //{
                        //    ///fiscal year Creation
                        //    var PrevYear = DateTime.Now.Year - 1;
                        //    var fromdate = new DateTime(PrevYear, 1, 1);
                        //    var todate = new DateTime(PrevYear, 12, 31);

                        //    SqlParameter[] sqlParameterfy = new SqlParameter[4];
                        //    sqlParameterfy[0] = new SqlParameter("@comid", ComId);
                        //    sqlParameterfy[1] = new SqlParameter("@dtFrom", fromdate);
                        //    sqlParameterfy[2] = new SqlParameter("@dtTo", todate);
                        //    sqlParameterfy[3] = new SqlParameter("@UserId", UserId);
                        //    Helper.ExecProc("Acc_prcCloseFiscalYearManual", sqlParameterfy);
                        //    ///fiscal year Creation
                        //}

                        ///off by fahad 
                        //HttpContext.Session.SetString("CompanyAddressBangla", company.CompanyAddressBangla != null ? company.CompanyAddressBangla : "");
                        //HttpContext.Session.SetString("CompanyNameBangla", company.CompanyNameBangla != null ? company.CompanyNameBangla : "");



                        await HttpContext.SignInAsync(principal);

                        //var UserId = HttpContext.Session.GetInt32("UserId");
                        //var ComId = HttpContext.Session.GetInt32("ComId");

                        HttpContext.Session.SetString("Latitude", "");
                        HttpContext.Session.SetString("Longitude", "");


                        LogRepository.SuccessLogin(HttpContext.Session.GetString("Latitude"), HttpContext.Session.GetString("Longitude"), "Success");

                        //return RedirectToAction("Index", "Admin");


                        //var firstmenu = _menuPermissionRepository.All().Include(x => x.Menu).Where(x => x.Menu.ParentId != null && x.UserRoleId == userdata.UserRoleId && x.BusinessTypeId == company.BusinessTypeId).OrderBy(x => x.Menu.DisplayOrder).FirstOrDefault();






                        if (userdata.IsBaseUser == true)
                        {
                            var firstmenu = _menuPermissionRepository.All().Include(x => x.Menus).Where(x => x.Menus.ParentId != null && x.BusinessTypeId == company.BusinessTypeId).OrderBy(x => x.Menus.DisplayOrder).FirstOrDefault();

                            if (firstmenu == null)
                            {
                                return RedirectToAction("AccessDenied");
                            }
                            return RedirectToAction(firstmenu.Menus.ActionName, firstmenu.Menus.ControllerName);
                        }
                        else
                        {
                            var firstmenu = _menuPermissionDetailsRepository.All().Include(x => x.MenuPermissionMasters).Include(x => x.Menus).Where(x => x.Menus.ParentId != null && x.MenuPermissionMasters.LUserIdPermission == UserId).OrderBy(x => x.Menus.DisplayOrder).FirstOrDefault();

                            if (firstmenu == null)
                            {
                                return RedirectToAction("AccessDenied");
                            }
                            return RedirectToAction(firstmenu.Menus.ActionName, firstmenu.Menus.ControllerName);
                        }


                    }
                    else
                    {
                        HttpContext.Session.SetString("Latitude", "=N/A=");
                        HttpContext.Session.SetString("Longitude", "=N/A=");
                        HttpContext.Session.SetString("UserInfo", user.Email + " " + user.Password);

                        LogRepository.SuccessLogin(HttpContext.Session.GetString("Latitude"), HttpContext.Session.GetString("Longitude"), "Failure");

                        TempData["UserLoginFailed"] = "Login Failed.Please enter correct credentials";
                        return View();
                    }
                }
                else
                    return View(user);
                #endregion
            }
            else if (user.CredentialType == "C")
            {
                #region CustomerLogin

                #region weburlinfo
                var weburl = Request.GetTypedHeaders().Referer.ToString().ToLower();//.Replace("/Home/Login".ToLower(), "");
                var weburlquerystring = Request.QueryString.HasValue == true ? Request.QueryString.ToString() : "";// Request.QueryString == null ? "": Request.QueryString;// Request.QueryString?? Request.QueryString;//.Replace("/Home/Login".ToLower(), "");

                var origin = weburl.ToLower();
                var controllerName = this.ControllerContext.RouteData.Values["Controller"].ToString().ToLower();


                string St = weburl.ToLower();
                int pFrom = St.IndexOf("/?");

                if (pFrom > 0)
                {
                    var filterurl = St.Substring(0, pFrom);
                    origin = filterurl;
                }
                string resulta = "";


                if (weburlquerystring.Length > 2)
                {
                    resulta = origin.Replace(weburlquerystring, "").Replace("/Home/Login".ToLower(), "");

                }
                else
                {
                    resulta = origin.Replace("/Home/Login".ToLower(), "");

                }

                #endregion



                if (ModelState.IsValid)
                {
                    CustomerModel abc = new CustomerModel();
                    abc.LoginId = user.Email;
                    abc.Password = user.Password;


                    //bool result = userAccountRepository.ValidateUser(user);
                    bool result = _customerRepository.ValidateCustomer(abc);


                    var customerdata = _customerRepository.All(false).Include(x => x.SalesRepresentative).Include(x => x.UserAccountList).Where(x => x.LoginId == user.Email && x.Password == user.Password).FirstOrDefault();


                    if (result)
                    {
                        Atrai.Model.AppData.DefaultConnectionString = Config.GetConnectionString("DefaultConnection");

                        int ComId = customerdata.ComId;

                        //var UserIdabc = userAccountRepository.All().Where(x => x.EmployeeId == customerdata.SalesRepresentativeId).FirstOrDefault().Id; //  customerdata.SalesRepresentative.LinkedUserAccount.FirstOrDefault().Id;
                        int UserId = 0;


                        HttpContext.Session.SetInt32("IsMobile", 0);
                        HttpContext.Session.SetInt32("UserId", customerdata.LuserId);
                        HttpContext.Session.SetInt32("CustomerId", customerdata.Id);
                        HttpContext.Session.SetInt32("ComId", customerdata.ComId);



                        string ComName = companyRepository.GetComName(ComId);
                        HttpContext.Session.SetString("ComName", ComName);

                        HttpContext.Session.SetString("UserInfo", user.Email);
                        HttpContext.Session.SetString("SearchType", "Scanner");



                        var userdata = userAccountRepository.All().Include(x => x.UserRole).Include(x => x.EmployeeList).Where(x => x.Id == UserId).FirstOrDefault();
                        var claims = new List<Claim>
                            {
                                new Claim(ClaimTypes.Name, user.Email )
                            };
                        var _claim = new Claim("Role", "Customer"); //userdata.UserRole.RoleName
                        claims.Add(_claim);
                        ClaimsIdentity userIdentity = new ClaimsIdentity(claims, "login");
                        ClaimsPrincipal principal = new ClaimsPrincipal(userIdentity);

                        //applicat

                        //HttpContext.Session.SetInt32("UserRoleId", userdata.UserRoleId ?? 0);
                        //HttpContext.Session.SetString("UserRole", userdata.UserRole.RoleName ?? "");
                        //HttpContext.Session.SetString("EmpImagePath", userdata.EmployeeList?.EmployeeImagePath ?? "");







                        var company = companyRepository.All().Where(x => x.Id == ComId).Include(x => x.BusinessType).FirstOrDefault();
                        var storeinfo = storeSettingRepository.All().Where(x => x.ComId == ComId)
                            .Include(x => x.SalesReportStyle)
                            .Include(x => x.PurchaseReportStyle)
                            .Include(x => x.BarcodeReportStyle)
                            .Include(x => x.Currency)
                            .Include(x => x.TimeZones)
                            .FirstOrDefault();



                        HttpContext.Session.SetInt32("BaseComId", storeinfo.BaseComId);

                        HttpContext.Session.SetInt32("BusinessTypeId", company.BusinessTypeId);
                        HttpContext.Session.SetString("BusinessType", company.BusinessType.BusinessTypeName);
                        HttpContext.Session.SetString("AppsName", company.BusinessType.AppsName);


                        HttpContext.Session.SetString("CompanyName", company.CompanyName != null ? company.CompanyName : "");
                        HttpContext.Session.SetString("PrimaryAddress", company.PrimaryAddress != null ? company.PrimaryAddress : "");
                        HttpContext.Session.SetString("SecoundaryAddress", company.SecoundaryAddress != null ? company.SecoundaryAddress : "");
                        HttpContext.Session.SetString("comPhone", company.comPhone != null ? company.comPhone : "");
                        HttpContext.Session.SetString("comWeb", company.comWeb != null ? company.comWeb : "");
                        HttpContext.Session.SetString("comEmail", company.comEmail != null ? company.comEmail : "");
                        HttpContext.Session.SetString("CaptionOne", "CaptionOne");
                        HttpContext.Session.SetString("CaptionTwo", "CaptionTwo");
                        HttpContext.Session.SetString("PrintDate", DateTime.Now.Date.ToString("dd-MMM-yy"));
                        HttpContext.Session.SetString("comImagePath", storeinfo != null ? storeinfo.Logo != null ? storeinfo.Logo : "" : "");
                        HttpContext.Session.SetString("weburl", resulta.ToString());


                        HttpContext.Session.SetString("OfferDiscountPer", storeinfo != null ? storeinfo.OfferDiscountPer.ToString() : "0.00");
                        HttpContext.Session.SetInt32("isDiscountOffer", storeinfo != null ? storeinfo.isDiscountOffer != false ? 1 : 0 : 0);



                        HttpContext.Session.SetString("TaxPer", storeinfo != null ? storeinfo.TaxPer.ToString() : "0.00");
                        HttpContext.Session.SetString("SalesReportStyle", storeinfo.SalesReportStyle != null ? storeinfo.SalesReportStyle.ReportStyleName : "Style1");
                        HttpContext.Session.SetString("PurchaseReportStyle", storeinfo.PurchaseReportStyle != null ? storeinfo.PurchaseReportStyle.ReportStyleName : "Style1");
                        HttpContext.Session.SetString("BarcodeReportStyle", storeinfo.BarcodeReportStyle != null ? storeinfo.BarcodeReportStyle.ReportStyleName : "Style1");


                        HttpContext.Session.SetInt32("isTaxExcluded", storeinfo != null ? storeinfo.isTaxExcluded != false ? 1 : 0 : 0);
                        HttpContext.Session.SetInt32("isMultiSelect", storeinfo != null ? storeinfo.isMultiSelect != false ? 1 : 0 : 0);
                        HttpContext.Session.SetInt32("isFixedSalesValue", storeinfo != null ? storeinfo.IsFixedSalesValue != false ? 1 : 0 : 0);
                        HttpContext.Session.SetInt32("IsFirstLetterUpperCase", storeinfo != null ? storeinfo.IsFirstLetterUpperCase != false ? 1 : 0 : 0);
                        HttpContext.Session.SetInt32("isMultiCurrency", storeinfo != null ? storeinfo.isMultiCurrency != false ? 1 : 0 : 0);
                        HttpContext.Session.SetInt32("IsTermsCondition", storeinfo != null ? storeinfo.IsTermsCondition != false ? 1 : 0 : 0);
                        HttpContext.Session.SetInt32("IsDefaultDisAmount", storeinfo != null ? storeinfo.IsDefaultDisAmount != false ? 1 : 0 : 0);
                        HttpContext.Session.SetInt32("DecimalField", storeinfo != null ? storeinfo.DecimalField : 0);

                        HttpContext.Session.SetInt32("IsFixedDiscountMainValue", storeinfo != null ? storeinfo.IsFixedDiscountMainValue != false ? 1 : 0 : 0);
                        HttpContext.Session.SetInt32("IsFixedDiscountRowValue", storeinfo != null ? storeinfo.IsFixedDiscountRowValue != false ? 1 : 0 : 0);
                        HttpContext.Session.SetString("MaxDiscountMainValue", storeinfo != null ? storeinfo.MaxDiscountMainValue.ToString() : "0.00");
                        HttpContext.Session.SetString("MaxDiscountPercentageMainValue", storeinfo != null ? storeinfo.MaxDiscountPercentageMainValue.ToString() : "0.00");
                        HttpContext.Session.SetString("MaxDiscountRowValue", storeinfo != null ? storeinfo.MaxDiscountRowValue.ToString() : "0.00");

                        HttpContext.Session.SetInt32("PrintProductName", storeinfo != null ? storeinfo.PrintProductName != false ? 1 : 0 : 0);
                        HttpContext.Session.SetInt32("PrintProductCode", storeinfo != null ? storeinfo.PrintProductCode != false ? 1 : 0 : 0);
                        HttpContext.Session.SetInt32("PrintProductDescription", storeinfo != null ? storeinfo.PrintProductDescription != false ? 1 : 0 : 0);
                        HttpContext.Session.SetInt32("PrintBrandName", storeinfo != null ? storeinfo.PrintBrandName != false ? 1 : 0 : 0);
                        HttpContext.Session.SetInt32("PrintModelName", storeinfo != null ? storeinfo.PrintModelName != false ? 1 : 0 : 0);
                        HttpContext.Session.SetInt32("PrintSizeName", storeinfo != null ? storeinfo.PrintSizeName != false ? 1 : 0 : 0);
                        HttpContext.Session.SetInt32("VisibleSalesCommission", storeinfo != null ? storeinfo.VisibleSalesCommission != false ? 1 : 0 : 0);

                        //HttpContext.Session.SetString("isFixedSalesValue", storeinfo.IsFixedSalesValue.ToString());




                        HttpContext.Session.SetString("isMultiDebitCredit", storeinfo.isMultiDebitCredit.ToString());
                        //HttpContext.Session.SetString("isMultiCurrency", company.isMultiCurrency.ToString());

                        HttpContext.Session.SetString("isVoucherDistributionEntry", storeinfo.isVoucherDistributionEntry.ToString());
                        HttpContext.Session.SetString("isChequeDetails", storeinfo.isChequeDetails.ToString());

                        HttpContext.Session.SetString("isSMSService", storeinfo.isSMSService.ToString());
                        HttpContext.Session.SetString("isEmailSerivce", storeinfo.isEmailSerivce.ToString());

                        HttpContext.Session.SetInt32("defaultcurrencyid", storeinfo.CountryId);
                        HttpContext.Session.SetString("defaultcurrencyname", storeinfo.Currency.CurrencyShortName.ToString());
                        HttpContext.Session.SetInt32("TimeZoneSettingsId", storeinfo.TimeZones != null ? storeinfo.TimeZoneSettingsId : 36);
                        HttpContext.Session.SetString("TimeZoneSettingsName", storeinfo != null ? storeinfo.TimeZones.TimeZoneName : "");
                        HttpContext.Session.SetString("TimeZoneSettingsNameJquery", storeinfo.TimeZones != null ? storeinfo.TimeZones.TimeZoneNameJquery : "");

                        var countryinfo = _countryRepository.All().Where(x => x.Id == storeinfo.CountryId).FirstOrDefault();
                        var countryinfoViewFormat = _countryRepository.All().Where(x => x.Id == 231).FirstOrDefault();



                        HttpContext.Session.SetString("CurrencyShortNameViewFormat", countryinfoViewFormat.CurrencyShortName);
                        HttpContext.Session.SetString("CultureInfoViewFormat", countryinfoViewFormat.CultureInfo);
                        HttpContext.Session.SetString("CountryShortNameViewFormat", countryinfoViewFormat.CountryShortName);
                        HttpContext.Session.SetString("CurrencySymbolViewFormat", countryinfoViewFormat.CurrencySymbol);


                        HttpContext.Session.SetString("CurrencyShortName", countryinfo.CurrencyShortName);
                        HttpContext.Session.SetString("CultureInfo", countryinfo.CultureInfo);
                        HttpContext.Session.SetString("CountryShortName", countryinfo.CountryShortName);
                        HttpContext.Session.SetString("CurrencySymbol", countryinfo.CurrencySymbol);


                        await HttpContext.SignInAsync(principal);



                        HttpContext.Session.SetString("Latitude", "");
                        HttpContext.Session.SetString("Longitude", "");


                        LogRepository.SuccessLogin(HttpContext.Session.GetString("Latitude"), HttpContext.Session.GetString("Longitude"), "Success");


                        return RedirectToAction("CustomerDashboard", "Admin");

                    }
                    else
                    {
                        HttpContext.Session.SetString("Latitude", "=N/A=");
                        HttpContext.Session.SetString("Longitude", "=N/A=");
                        HttpContext.Session.SetString("UserInfo", user.Email + " " + user.Password);

                        LogRepository.SuccessLogin(HttpContext.Session.GetString("Latitude"), HttpContext.Session.GetString("Longitude"), "Failure");

                        TempData["UserLoginFailed"] = "Login Failed.Please enter correct credentials";
                        return View();
                    }
                }
                else
                    return View(user);

                #endregion
            }
            else if (user.CredentialType == "S")
            {
                #region SupplierLogin
                #region weburlinfo
                var weburl = Request.GetTypedHeaders().Referer.ToString().ToLower();//.Replace("/Home/Login".ToLower(), "");
                var weburlquerystring = Request.QueryString.HasValue == true ? Request.QueryString.ToString() : "";// Request.QueryString == null ? "": Request.QueryString;// Request.QueryString?? Request.QueryString;//.Replace("/Home/Login".ToLower(), "");

                var origin = weburl.ToLower();
                var controllerName = this.ControllerContext.RouteData.Values["Controller"].ToString().ToLower();


                string St = weburl.ToLower();
                int pFrom = St.IndexOf("/?");

                if (pFrom > 0)
                {
                    var filterurl = St.Substring(0, pFrom);
                    origin = filterurl;
                }
                string resulta = "";


                if (weburlquerystring.Length > 2)
                {
                    resulta = origin.Replace(weburlquerystring, "").Replace("/Home/Login".ToLower(), "");

                }
                else
                {
                    resulta = origin.Replace("/Home/Login".ToLower(), "");

                }

                #endregion



                if (ModelState.IsValid)
                {
                    SupplierModel abc = new SupplierModel();
                    abc.LoginId = user.Email;
                    abc.Password = user.Password;


                    //bool result = userAccountRepository.ValidateUser(user);
                    bool result = _supplierRepository.ValidateSupplier(abc);


                    var supplierdata = _supplierRepository.All(false).Include(x => x.UserAccountList).Where(x => x.LoginId == user.Email && x.Password == user.Password).FirstOrDefault();


                    if (result)
                    {
                        Atrai.Model.AppData.DefaultConnectionString = Config.GetConnectionString("DefaultConnection");

                        int ComId = supplierdata.ComId;

                        //var UserIdabc = userAccountRepository.All().Where(x => x.EmployeeId == supplierdata.SalesRepresentativeId).FirstOrDefault().Id; //  supplierdata.SalesRepresentative.LinkedUserAccount.FirstOrDefault().Id;
                        int UserId = 0;


                        HttpContext.Session.SetInt32("IsMobile", 0);
                        HttpContext.Session.SetInt32("UserId", supplierdata.LuserId);
                        HttpContext.Session.SetInt32("SupplierId", supplierdata.Id);
                        HttpContext.Session.SetInt32("ComId", supplierdata.ComId);



                        string ComName = companyRepository.GetComName(ComId);
                        HttpContext.Session.SetString("ComName", ComName);

                        HttpContext.Session.SetString("UserInfo", user.Email);
                        HttpContext.Session.SetString("SearchType", "Scanner");



                        var userdata = userAccountRepository.All().Include(x => x.UserRole).Include(x => x.EmployeeList).Where(x => x.Id == UserId).FirstOrDefault();
                        var claims = new List<Claim>
                    {
                        new Claim(ClaimTypes.Name, user.Email)
                    };
                        var _claim = new Claim("Role", "Supplier"); //userdata.UserRole.RoleName
                        claims.Add(_claim);
                        ClaimsIdentity userIdentity = new ClaimsIdentity(claims, "login");
                        ClaimsPrincipal principal = new ClaimsPrincipal(userIdentity);

                        //applicat

                        //HttpContext.Session.SetInt32("UserRoleId", userdata.UserRoleId ?? 0);
                        //HttpContext.Session.SetString("UserRole", userdata.UserRole.RoleName ?? "");
                        //HttpContext.Session.SetString("EmpImagePath", userdata.EmployeeList?.EmployeeImagePath ?? "");







                        var company = companyRepository.All().Where(x => x.Id == ComId).Include(x => x.BusinessType).FirstOrDefault();
                        var storeinfo = storeSettingRepository.All().Where(x => x.ComId == ComId)
                            .Include(x => x.SalesReportStyle)
                            .Include(x => x.PurchaseReportStyle)
                            .Include(x => x.BarcodeReportStyle)
                                                .Include(x => x.TimeZones)
                                                .Include(x => x.Currency)
                            .FirstOrDefault();



                        HttpContext.Session.SetInt32("BaseComId", storeinfo.BaseComId);

                        HttpContext.Session.SetInt32("BusinessTypeId", company.BusinessTypeId);
                        HttpContext.Session.SetString("BusinessType", company.BusinessType.BusinessTypeName);
                        HttpContext.Session.SetString("AppsName", company.BusinessType.AppsName);


                        HttpContext.Session.SetString("CompanyName", company.CompanyName != null ? company.CompanyName : "");
                        HttpContext.Session.SetString("PrimaryAddress", company.PrimaryAddress != null ? company.PrimaryAddress : "");
                        HttpContext.Session.SetString("SecoundaryAddress", company.SecoundaryAddress != null ? company.SecoundaryAddress : "");
                        HttpContext.Session.SetString("comPhone", company.comPhone != null ? company.comPhone : "");
                        HttpContext.Session.SetString("comWeb", company.comWeb != null ? company.comWeb : "");
                        HttpContext.Session.SetString("comEmail", company.comEmail != null ? company.comEmail : "");
                        HttpContext.Session.SetString("CaptionOne", "CaptionOne");
                        HttpContext.Session.SetString("CaptionTwo", "CaptionTwo");
                        HttpContext.Session.SetString("PrintDate", DateTime.Now.Date.ToString("dd-MMM-yy"));
                        HttpContext.Session.SetString("comImagePath", storeinfo != null ? storeinfo.Logo != null ? storeinfo.Logo : "" : "");
                        HttpContext.Session.SetString("weburl", resulta.ToString());


                        HttpContext.Session.SetString("OfferDiscountPer", storeinfo != null ? storeinfo.OfferDiscountPer.ToString() : "0.00");
                        HttpContext.Session.SetInt32("isDiscountOffer", storeinfo != null ? storeinfo.isDiscountOffer != false ? 1 : 0 : 0);

                        HttpContext.Session.SetString("TaxPer", storeinfo != null ? storeinfo.TaxPer.ToString() : "0.00");
                        HttpContext.Session.SetString("SalesReportStyle", storeinfo.SalesReportStyle != null ? storeinfo.SalesReportStyle.ReportStyleName : "Style1");
                        HttpContext.Session.SetString("PurchaseReportStyle", storeinfo.PurchaseReportStyle != null ? storeinfo.PurchaseReportStyle.ReportStyleName : "Style1");
                        HttpContext.Session.SetString("BarcodeReportStyle", storeinfo.BarcodeReportStyle != null ? storeinfo.BarcodeReportStyle.ReportStyleName : "Style1");


                        HttpContext.Session.SetInt32("isTaxExcluded", storeinfo != null ? storeinfo.isTaxExcluded != false ? 1 : 0 : 0);
                        HttpContext.Session.SetInt32("isMultiSelect", storeinfo != null ? storeinfo.isMultiSelect != false ? 1 : 0 : 0);
                        HttpContext.Session.SetInt32("isFixedSalesValue", storeinfo != null ? storeinfo.IsFixedSalesValue != false ? 1 : 0 : 0);
                        HttpContext.Session.SetInt32("IsFirstLetterUpperCase", storeinfo != null ? storeinfo.IsFirstLetterUpperCase != false ? 1 : 0 : 0);
                        HttpContext.Session.SetInt32("isMultiCurrency", storeinfo != null ? storeinfo.isMultiCurrency != false ? 1 : 0 : 0);
                        HttpContext.Session.SetInt32("IsTermsCondition", storeinfo != null ? storeinfo.IsTermsCondition != false ? 1 : 0 : 0);
                        HttpContext.Session.SetInt32("IsDefaultDisAmount", storeinfo != null ? storeinfo.IsDefaultDisAmount != false ? 1 : 0 : 0);
                        HttpContext.Session.SetInt32("DecimalField", storeinfo != null ? storeinfo.DecimalField : 0);

                        HttpContext.Session.SetInt32("IsFixedDiscountMainValue", storeinfo != null ? storeinfo.IsFixedDiscountMainValue != false ? 1 : 0 : 0);
                        HttpContext.Session.SetInt32("IsFixedDiscountRowValue", storeinfo != null ? storeinfo.IsFixedDiscountRowValue != false ? 1 : 0 : 0);
                        HttpContext.Session.SetString("MaxDiscountMainValue", storeinfo != null ? storeinfo.MaxDiscountMainValue.ToString() : "0.00");
                        HttpContext.Session.SetString("MaxDiscountPercentageMainValue", storeinfo != null ? storeinfo.MaxDiscountPercentageMainValue.ToString() : "0.00");
                        HttpContext.Session.SetString("MaxDiscountRowValue", storeinfo != null ? storeinfo.MaxDiscountRowValue.ToString() : "0.00");

                        HttpContext.Session.SetInt32("PrintProductName", storeinfo != null ? storeinfo.PrintProductName != false ? 1 : 0 : 0);
                        HttpContext.Session.SetInt32("PrintProductCode", storeinfo != null ? storeinfo.PrintProductCode != false ? 1 : 0 : 0);
                        HttpContext.Session.SetInt32("PrintProductDescription", storeinfo != null ? storeinfo.PrintProductDescription != false ? 1 : 0 : 0);
                        HttpContext.Session.SetInt32("PrintBrandName", storeinfo != null ? storeinfo.PrintBrandName != false ? 1 : 0 : 0);
                        HttpContext.Session.SetInt32("PrintModelName", storeinfo != null ? storeinfo.PrintModelName != false ? 1 : 0 : 0);
                        HttpContext.Session.SetInt32("PrintSizeName", storeinfo != null ? storeinfo.PrintSizeName != false ? 1 : 0 : 0);
                        HttpContext.Session.SetInt32("VisibleSalesCommission", storeinfo != null ? storeinfo.VisibleSalesCommission != false ? 1 : 0 : 0);

                        //HttpContext.Session.SetString("isFixedSalesValue", storeinfo.IsFixedSalesValue.ToString());




                        HttpContext.Session.SetString("isMultiDebitCredit", storeinfo.isMultiDebitCredit.ToString());
                        //HttpContext.Session.SetString("isMultiCurrency", company.isMultiCurrency.ToString());

                        HttpContext.Session.SetString("isVoucherDistributionEntry", storeinfo.isVoucherDistributionEntry.ToString());
                        HttpContext.Session.SetString("isChequeDetails", storeinfo.isChequeDetails.ToString());

                        HttpContext.Session.SetString("isSMSService", storeinfo.isSMSService.ToString());
                        HttpContext.Session.SetString("isEmailSerivce", storeinfo.isEmailSerivce.ToString());

                        HttpContext.Session.SetInt32("defaultcurrencyid", storeinfo.CountryId);
                        HttpContext.Session.SetString("defaultcurrencyname", storeinfo.Currency.CurrencyShortName.ToString());
                        HttpContext.Session.SetInt32("TimeZoneSettingsId", storeinfo.TimeZones != null ? storeinfo.TimeZoneSettingsId : 36);
                        HttpContext.Session.SetString("TimeZoneSettingsName", storeinfo != null ? storeinfo.TimeZones.TimeZoneName : "");
                        HttpContext.Session.SetString("TimeZoneSettingsNameJquery", storeinfo.TimeZones != null ? storeinfo.TimeZones.TimeZoneNameJquery : "");

                        var countryinfo = _countryRepository.All().Where(x => x.Id == storeinfo.CountryId).FirstOrDefault();
                        var countryinfoViewFormat = _countryRepository.All().Where(x => x.Id == 231).FirstOrDefault();



                        HttpContext.Session.SetString("CurrencyShortNameViewFormat", countryinfoViewFormat.CurrencyShortName);
                        HttpContext.Session.SetString("CultureInfoViewFormat", countryinfoViewFormat.CultureInfo);
                        HttpContext.Session.SetString("CountryShortNameViewFormat", countryinfoViewFormat.CountryShortName);
                        HttpContext.Session.SetString("CurrencySymbolViewFormat", countryinfoViewFormat.CurrencySymbol);


                        HttpContext.Session.SetString("CurrencyShortName", countryinfo.CurrencyShortName);
                        HttpContext.Session.SetString("CultureInfo", countryinfo.CultureInfo);
                        HttpContext.Session.SetString("CountryShortName", countryinfo.CountryShortName);
                        HttpContext.Session.SetString("CurrencySymbol", countryinfo.CurrencySymbol);


                        await HttpContext.SignInAsync(principal);



                        HttpContext.Session.SetString("Latitude", "");
                        HttpContext.Session.SetString("Longitude", "");


                        LogRepository.SuccessLogin(HttpContext.Session.GetString("Latitude"), HttpContext.Session.GetString("Longitude"), "Success");


                        return RedirectToAction("SupplierDashboard", "Admin");

                    }
                    else
                    {
                        HttpContext.Session.SetString("Latitude", "=N/A=");
                        HttpContext.Session.SetString("Longitude", "=N/A=");
                        HttpContext.Session.SetString("UserInfo", user.Email + " " + user.Password);

                        LogRepository.SuccessLogin(HttpContext.Session.GetString("Latitude"), HttpContext.Session.GetString("Longitude"), "Failure");

                        TempData["UserLoginFailed"] = "Login Failed.Please enter correct credentials";
                        return View();
                    }
                }
                else
                    return View(user);

                #endregion
            }
            else
            {
                return View();
            }


        }

        [HttpPost]
        //[Route("/LoginAtrai")]

        public ActionResult LoginAtrai(LoginViewModel user)
        {
            try
            {
                var returnurl = user.ReturnUrl;
                //if (!Url.IsLocalUrl(returnurl))
                //{
                //    returnurl = "/Admin";
                //}
                //var abc = 1;
                //return Json(abc);

                #region weburlinfo
                var weburl = Request.GetTypedHeaders().Referer.ToString().ToLower();//.Replace("/Home/Login".ToLower(), "");
                var weburlquerystring = Request.QueryString.HasValue == true ? Request.QueryString.ToString() : "";// Request.QueryString == null ? "": Request.QueryString;// Request.QueryString?? Request.QueryString;//.Replace("/Home/Login".ToLower(), "");

                var origin = weburl.ToLower();
                var controllerName = this.ControllerContext.RouteData.Values["Controller"].ToString().ToLower();


                string St = weburl.ToLower();
                int pFrom = St.IndexOf("/?");

                if (pFrom > 0)
                {
                    var filterurl = St.Substring(0, pFrom);
                    origin = filterurl;
                }
                //string example = "Hello, World!";

                //// Get the 5 characters from the left of the string
                //string exampleLeft = example.Substring(0, 5);



                //String St = weburl.ToLower();

                //int pFrom = St.IndexOf("/") + "/".Length;
                //int pTo = St.LastIndexOf("/" + controllerName);
                string resulta = "";
                //if (pTo < 1)
                //{
                //    resulta = origin;

                //}
                //else
                //{
                //    resulta = St.Substring(pFrom, pTo - pFrom);
                //    resulta = origin + "/" + resulta;

                //}


                if (weburlquerystring.Length > 2)
                {
                    resulta = origin.Replace(weburlquerystring, "").Replace("/Home/Login".ToLower(), "");

                }
                else
                {
                    resulta = origin.Replace("/Home/Login".ToLower(), "");

                }

                #endregion

                var abc = user;

                //var redirectUrl = Url.Action("Signup", "Home");
                var redirectUrl = Url.Action("Login", "Home");

                bool result = userAccountRepository.ValidateUser(user);

                if (result)
                {
                    #region email send if not confirmed email by user or by click from the email link 
                    var Emailverifiedinfo = userAccountRepository.All(false).Where(x => x.Email == user.Email && x.IsEmailVerified == false).ToList();
                    if (Emailverifiedinfo.Count > 0)
                    {
                        //TempData["UserLoginFailed"] = "Email Not Confirmed Yet. Please check Your mail to Activate Your user Account. or Contact with your service provider 01671303302.";
                        var OTPvalue = ValuesController.randomnumbergenerate(4, 1050, 9999).ToString();
                        int usercomid = userAccountRepository.GetComId(user);
                        var compnayinfo = companyRepository.Find(usercomid);

                        if (user.Email != null && Emailverifiedinfo.FirstOrDefault().OTP != "" || Emailverifiedinfo.FirstOrDefault().OTP != null)
                        {


                            redirectUrl = Url.Action("OTPConfirmation", "Home", new { Email = user.Email, PhoneNo = "" });
                            return Json(new { Url = redirectUrl });

                        }

                        //if (user.Email != null && Emailverifiedinfo.FirstOrDefault().OTP != "" || Emailverifiedinfo.FirstOrDefault().OTP != null)
                        //{
                        //    return RedirectToAction("EmailConfirmation", "Home", new { Email = user.Email, PhoneNo = Emailverifiedinfo.FirstOrDefault().PhoneNumber });

                        //}

                        //return View();
                    }

                    #endregion



                    Atrai.Model.AppData.DefaultConnectionString = Config.GetConnectionString("DefaultConnection");



                    int? vatview = HttpContext.Session.GetInt32("VatViewActivate");
                    if (vatview == null || vatview == 0)
                    {
                        HttpContext.Session.SetInt32("VatViewActivate", 0);
                    }
                    else
                    {
                        HttpContext.Session.SetInt32("VatViewActivate", 1);
                    }



                    HttpContext.Session.SetInt32("IsMobile", 0);

                    int UserId = userAccountRepository.GetUserId(user);
                    HttpContext.Session.SetInt32("UserId", UserId);

                    int ComId = userAccountRepository.GetComId(user);
                    HttpContext.Session.SetInt32("ComId", ComId);

                    if (ComId == 0)
                    {
                        redirectUrl = Url.Action("CompanySetup", "Home");
                        return Json(new { Url = redirectUrl });

                    }

                    string ComName = companyRepository.GetComName(ComId);
                    HttpContext.Session.SetString("ComName", ComName);

                    HttpContext.Session.SetString("UserInfo", user.Email);

                    //var rolename = userAccountRepository.All(false).Where(A => A.Id == UserId).Include(x => x.UserRole).Include(x => x.EmployeeList).FirstOrDefault();
                    //HttpContext.Session.SetString("RoleName", rolename.UserRole.RoleName);


                    HttpContext.Session.SetInt32("PurchasePackage", 0);
                    if (userAccountRepository.All().Include(x => x.UserRole).Where(x => x.Id == UserId).FirstOrDefault().UserRole.RoleName != "SuperAdmin")
                    {
                        var subscriptionactivationdata = _subscriptionActivationRepository.All().Where(x => x.LuserId == UserId && x.ActiveToDate > DateTime.Now.Date).FirstOrDefault();

                        //HttpContext.Session.SetInt32("UserValidityDays", (int)subscriptionactivationdata.ValidityDay);

                        HttpContext.Session.SetInt32("UserValidityDays", (int)(subscriptionactivationdata?.ValidityDay ?? 0));

                        //userdata.EmployeeList?.EmployeeImagePath ?? ""
                        HttpContext.Session.SetInt32("ShowAlert", 1);



                        if (subscriptionactivationdata == null)
                        {
                            HttpContext.Session.SetInt32("PurchasePackage", 1);


                        }


                    }



                    //return View(saleRepository.All().Include(x => x.CustomerModel).OrderByDescending(x => x.Id));

                    var userdata = userAccountRepository.All().Include(x => x.UserRole).Include(x => x.EmployeeList).ThenInclude(x => x.DesignationList).Where(x => x.Id == UserId).FirstOrDefault();
                    var claims = new List<Claim>
                    {
                        new Claim(ClaimTypes.Name, user.Email , user.EmpImagePath )
                    };
                    var _claim = new Claim("Role", userdata.UserRole.RoleName);
                    claims.Add(_claim);
                    ClaimsIdentity userIdentity = new ClaimsIdentity(claims, "login");
                    ClaimsPrincipal principal = new ClaimsPrincipal(userIdentity);

                    //applicat

                    HttpContext.Session.SetInt32("UserRoleId", userdata.UserRoleId ?? 0);
                    HttpContext.Session.SetString("UserRole", userdata.UserRole.RoleName ?? "");
                    HttpContext.Session.SetString("UserDesignation", userdata?.EmployeeList?.DesignationList?.DesigName ?? "");



                    HttpContext.Session.SetString("EmpImagePath", userdata.EmployeeList?.EmployeeImagePath ?? "");

                    if (userdata.UserRole.RoleName.Contains("SuperAdmin"))
                    {
                        HttpContext.Session.SetInt32("IsUserLevel", 1);

                        //HttpContext.Session.SetInt32("IsSuperAdmin", 1);
                        //HttpContext.Session.SetInt32("IsAdmin", 0);
                        //HttpContext.Session.SetInt32("IsUser", 0);
                    }
                    else if (userdata.UserRole.RoleName.Contains("Admin"))
                    {
                        HttpContext.Session.SetInt32("IsUserLevel", 2);


                        //HttpContext.Session.SetInt32("IsSuperAdmin", 0);
                        //HttpContext.Session.SetInt32("IsAdmin", 1);
                        //HttpContext.Session.SetInt32("IsUser", 0);
                    }
                    else if (userdata.UserRole.RoleName.Contains("User"))
                    {
                        HttpContext.Session.SetInt32("IsUserLevel", 3);


                        //HttpContext.Session.SetInt32("IsSuperAdmin", 0);
                        //HttpContext.Session.SetInt32("IsAdmin", 0);
                        //HttpContext.Session.SetInt32("IsUser", 1);
                    }
                    else
                    {
                        HttpContext.Session.SetInt32("IsUserLevel", 4);


                        //HttpContext.Session.SetInt32("IsSuperAdmin", 0);
                        //HttpContext.Session.SetInt32("IsAdmin", 0);
                        //HttpContext.Session.SetInt32("IsUser", 0);
                    }



                    if (userdata.UserRole.RoleName.Contains("SuperAdmin"))
                    {
                        var CompanyUserList = companyRepository.All().Select(x => new SelectListItem { Text = x.CompanyName, Value = x.Id.ToString() }).OrderBy(x => x.Value).ToList();

                        //var CompanyUserList = _companyPermissionRepository.All().Include(x => x.CompanyList).Where(x => x.ComId == ComId && x.LuserId == UserId).Select(x => new SelectListItem { Text = x.CompanyList.CompanyName, Value = x.ComId.ToString() }).OrderBy(x=>x.Value).ToList();
                        if (CompanyUserList.Count > 0)
                        {
                            HttpContext.Session.SetObject("UserCompanys", CompanyUserList);
                        }
                    }
                    else //if (!userdata.UserRole.RoleName.Contains("Admin"))
                    {
                        /////////////if multi compnay is avaialable but he have only single company permission not the default one.
                        var CompanyUserList = _companyPermissionRepository.All().Include(x => x.CompanyList).Where(x => x.LuserId == UserId).Select(x => new SelectListItem { Text = x.CompanyList.CompanyName, Value = x.ComId.ToString() }).ToList();
                        HttpContext.Session.SetObject("UserCompanys", CompanyUserList);

                        if (CompanyUserList.Count() > 0)
                        {
                            ComId = int.Parse(CompanyUserList.FirstOrDefault().Value);
                            HttpContext.Session.SetInt32("ComId", ComId);

                            ComName = CompanyUserList.FirstOrDefault().Text;
                            HttpContext.Session.SetString("ComName", ComName);
                        }
                    }
                    //////////need to set the permit compnay 


                    var company = companyRepository.All().Where(x => x.Id == ComId).Include(x => x.BusinessType).FirstOrDefault();



                    var storeinfo = storeSettingRepository.All().Where(x => x.ComId == ComId)
                    .Include(x => x.SalesReportStyle)
                    .Include(x => x.PurchaseReportStyle)
                    .Include(x => x.BarcodeReportStyle)
                    .Include(x => x.Currency)
                                        .Include(x => x.TimeZones)
                    .FirstOrDefault();



                    HttpContext.Session.SetString("ShortCutKey", storeinfo.ShortCutKey != null ? storeinfo.ShortCutKey : "q"); // "y"
                    HttpContext.Session.SetString("SearchType", storeinfo.isScanner == true ? "Scanner" : "Manual"); // "Scanner"
                    HttpContext.Session.SetString("barcodeprefixforweightscale", storeinfo.BarcodePrefixForWeightScale != null ? storeinfo.BarcodePrefixForWeightScale : "99"); // "Scanner"


                    HttpContext.Session.SetInt32("BaseComId", storeinfo.BaseComId);

                    HttpContext.Session.SetInt32("BusinessTypeId", company.BusinessTypeId);
                    HttpContext.Session.SetString("BusinessType", company.BusinessType.BusinessTypeName);
                    HttpContext.Session.SetString("AppsName", company.BusinessType.AppsName != null ? company.BusinessType.AppsName : "");


                    HttpContext.Session.SetString("CompanyName", company.CompanyName != null ? company.CompanyName : "");
                    HttpContext.Session.SetString("PrimaryAddress", company.PrimaryAddress != null ? company.PrimaryAddress : "");
                    HttpContext.Session.SetString("SecoundaryAddress", company.SecoundaryAddress != null ? company.SecoundaryAddress : "");
                    HttpContext.Session.SetString("comPhone", company.comPhone != null ? company.comPhone : "");
                    HttpContext.Session.SetString("comWeb", company.comWeb != null ? company.comWeb : "");
                    HttpContext.Session.SetString("comEmail", company.comEmail != null ? company.comEmail : "");
                    HttpContext.Session.SetString("CaptionOne", "CaptionOne");
                    HttpContext.Session.SetString("CaptionTwo", "CaptionTwo");
                    HttpContext.Session.SetString("PrintDate", DateTime.Now.Date.ToString("dd-MMM-yy"));
                    HttpContext.Session.SetString("comImagePath", storeinfo != null ? storeinfo.Logo != null ? storeinfo.Logo : "" : "");
                    HttpContext.Session.SetString("weburl", resulta.ToString());

                    HttpContext.Session.SetString("OfferDiscountPer", storeinfo != null ? storeinfo.OfferDiscountPer.ToString() : "0.00");
                    HttpContext.Session.SetInt32("isDiscountOffer", storeinfo != null ? storeinfo.isDiscountOffer != false ? 1 : 0 : 0);


                    HttpContext.Session.SetString("TaxPer", storeinfo != null ? storeinfo.TaxPer.ToString() : "0.00");
                    HttpContext.Session.SetString("SalesReportStyle", storeinfo.SalesReportStyle != null ? storeinfo.SalesReportStyle.ReportStyleName : "Style1");
                    HttpContext.Session.SetString("PurchaseReportStyle", storeinfo.PurchaseReportStyle != null ? storeinfo.PurchaseReportStyle.ReportStyleName : "Style1");
                    HttpContext.Session.SetString("BarcodeReportStyle", storeinfo.BarcodeReportStyle != null ? storeinfo.BarcodeReportStyle.ReportStyleName : "Style1");

                    HttpContext.Session.SetInt32("isTaxExcluded", storeinfo != null ? storeinfo.isTaxExcluded != false ? 1 : 0 : 0);

                    HttpContext.Session.SetInt32("isMultiSelect", storeinfo != null ? storeinfo.isMultiSelect != false ? 1 : 0 : 0);
                    HttpContext.Session.SetInt32("isFixedSalesValue", storeinfo != null ? storeinfo.IsFixedSalesValue != false ? 1 : 0 : 0);
                    HttpContext.Session.SetInt32("IsFirstLetterUpperCase", storeinfo != null ? storeinfo.IsFirstLetterUpperCase != false ? 1 : 0 : 0);


                    HttpContext.Session.SetInt32("IsSerialSales", storeinfo != null ? storeinfo.IsSerialSales != false ? 1 : 0 : 0);
                    HttpContext.Session.SetInt32("IsIndDiscount", storeinfo != null ? storeinfo.IsIndDiscount != false ? 1 : 0 : 0);
                    HttpContext.Session.SetInt32("IsSalesDescription", storeinfo != null ? storeinfo.IsSalesDescription != false ? 1 : 0 : 0);
                    HttpContext.Session.SetInt32("IsVatLogin", storeinfo != null ? storeinfo.IsVatLogin != false ? 1 : 0 : 0);
                    HttpContext.Session.SetInt32("isMultiCurrency", storeinfo != null ? storeinfo.isMultiCurrency != false ? 1 : 0 : 0);
                    HttpContext.Session.SetInt32("IsTermsCondition", storeinfo != null ? storeinfo.IsTermsCondition != false ? 1 : 0 : 0);
                    HttpContext.Session.SetInt32("IsDefaultDisAmount", storeinfo != null ? storeinfo.IsDefaultDisAmount != false ? 1 : 0 : 0);
                    HttpContext.Session.SetInt32("DecimalField", storeinfo != null ? storeinfo.DecimalField : 0);


                    HttpContext.Session.SetInt32("IsFixedDiscountMainValue", storeinfo != null ? storeinfo.IsFixedDiscountMainValue != false ? 1 : 0 : 0);
                    HttpContext.Session.SetInt32("IsFixedDiscountRowValue", storeinfo != null ? storeinfo.IsFixedDiscountRowValue != false ? 1 : 0 : 0);
                    HttpContext.Session.SetString("MaxDiscountMainValue", storeinfo != null ? storeinfo.MaxDiscountMainValue.ToString() : "0.00");
                    HttpContext.Session.SetString("MaxDiscountPercentageMainValue", storeinfo != null ? storeinfo.MaxDiscountPercentageMainValue.ToString() : "0.00");
                    HttpContext.Session.SetString("MaxDiscountRowValue", storeinfo != null ? storeinfo.MaxDiscountRowValue.ToString() : "0.00");




                    HttpContext.Session.SetInt32("PrintProductName", storeinfo != null ? storeinfo.PrintProductName != false ? 1 : 0 : 0);
                    HttpContext.Session.SetInt32("PrintProductCode", storeinfo != null ? storeinfo.PrintProductCode != false ? 1 : 0 : 0);
                    HttpContext.Session.SetInt32("PrintProductDescription", storeinfo != null ? storeinfo.PrintProductDescription != false ? 1 : 0 : 0);
                    HttpContext.Session.SetInt32("PrintBrandName", storeinfo != null ? storeinfo.PrintBrandName != false ? 1 : 0 : 0);
                    HttpContext.Session.SetInt32("PrintModelName", storeinfo != null ? storeinfo.PrintModelName != false ? 1 : 0 : 0);
                    HttpContext.Session.SetInt32("PrintSizeName", storeinfo != null ? storeinfo.PrintSizeName != false ? 1 : 0 : 0);
                    HttpContext.Session.SetInt32("VisibleSalesCommission", storeinfo != null ? storeinfo.VisibleSalesCommission != false ? 1 : 0 : 0);



                    HttpContext.Session.SetString("isMultiDebitCredit", storeinfo.isMultiDebitCredit.ToString());
                    //HttpContext.Session.SetString("isMultiCurrency", company.isMultiCurrency.ToString());

                    HttpContext.Session.SetString("isVoucherDistributionEntry", storeinfo.isVoucherDistributionEntry.ToString());
                    HttpContext.Session.SetString("isChequeDetails", storeinfo.isChequeDetails.ToString());

                    HttpContext.Session.SetString("isSMSService", storeinfo.isSMSService.ToString());
                    HttpContext.Session.SetString("isEmailSerivce", storeinfo.isEmailSerivce.ToString());
                    HttpContext.Session.SetString("IsSignature", storeinfo != null ? storeinfo.IsSignature.ToString() : "false");


                    HttpContext.Session.SetInt32("defaultcurrencyid", storeinfo.CountryId);
                    HttpContext.Session.SetString("defaultcurrencyname", storeinfo.Currency.CurrencyShortName.ToString());
                    HttpContext.Session.SetInt32("TimeZoneSettingsId", storeinfo.TimeZones != null ? storeinfo.TimeZoneSettingsId : 36);
                    HttpContext.Session.SetString("TimeZoneSettingsName", storeinfo.TimeZones != null ? storeinfo.TimeZones.TimeZoneName : "");
                    HttpContext.Session.SetString("TimeZoneSettingsNameJquery", storeinfo.TimeZones != null ? storeinfo.TimeZones.TimeZoneNameJquery : "");





                    if (userdata.IsBaseUser == true)
                    {
                        var userpermissionmenulist = _menuPermissionRepository.All().Include(x => x.Menus).Where(x => x.BusinessTypeId == company.BusinessTypeId);

                        if (storeinfo.IsVatLogin == true)
                        {
                            userpermissionmenulist = userpermissionmenulist.Where(x => x.Menus.IsVatMenu == true);
                            HttpContext.Session.SetInt32("VatViewActivate", 1);
                        }


                        List<UserMenuPermissionViewModel> userallmenulist = new List<UserMenuPermissionViewModel>();

                        if (userpermissionmenulist != null)
                        {
                            foreach (var item in userpermissionmenulist.OrderBy(x => x.Menus.DisplayOrder))
                            {
                                UserMenuPermissionViewModel usermenudata = new UserMenuPermissionViewModel();

                                usermenudata.Id = item.Menus.Id;

                                usermenudata.ActionName = item.Menus.ActionName;
                                usermenudata.ControllerName = item.Menus.ControllerName;
                                usermenudata.IsView = true;// item.IsCreate;
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
                                usermenudata.FirstParameter = item.Menus.FirstParameter;
                                usermenudata.FirstValue = item.Menus.FirstValue;

                                userallmenulist.Add(usermenudata);
                            }
                        }

                        HttpContext.Session.SetObject("UserAllMenu", userallmenulist);
                        HttpContext.Session.SetObject("UserGroupMenu", userallmenulist.Where(x => x.IsGroup == true));
                        HttpContext.Session.SetObject("UserParentMenu", userallmenulist.Where(x => x.IsParent == true));
                        HttpContext.Session.SetObject("UserChildMenu", userallmenulist.Where(x => x.ParentId != null));


                    }
                    else
                    {

                        var userpermissionmenulist = _menuPermissionDetailsRepository.All().Include(x => x.MenuPermissionMasters).Include(x => x.Menus).Where(x => x.MenuPermissionMasters.LUserIdPermission == UserId && x.MenuPermissionMasters.ComId == ComId);

                        //HttpContext.Session.SetString("SummaryView", userpermissionmenulist.FirstOrDefault().MenuPermissionMasters.SummaryView.ToString()); /// fahad need to check for sales summary view activate


                        if (storeinfo.IsVatLogin == true)
                        {
                            userpermissionmenulist = userpermissionmenulist.Where(x => x.Menus.IsVatMenu == true);
                            HttpContext.Session.SetInt32("VatViewActivate", 1);
                        }

                        List<UserMenuPermissionViewModel> userallmenulist = new List<UserMenuPermissionViewModel>();

                        if (userpermissionmenulist != null)
                        {
                            foreach (var item in userpermissionmenulist.OrderBy(x => x.Menus.DisplayOrder))
                            {
                                UserMenuPermissionViewModel usermenudata = new UserMenuPermissionViewModel();

                                usermenudata.Id = item.Menus.Id;

                                usermenudata.ActionName = item.Menus.ActionName;
                                usermenudata.ControllerName = item.Menus.ControllerName;
                                usermenudata.IsCreate = item.IsCreate;
                                usermenudata.IsView = item.IsView;
                                usermenudata.IsDeleteP = item.IsDeleteP;
                                usermenudata.IsEdit = item.IsEdit;
                                usermenudata.isDefault = item.isDefault;
                                usermenudata.SLNo = item.SLNo;

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
                                usermenudata.FirstParameter = item.Menus.FirstParameter;
                                usermenudata.FirstValue = item.Menus.FirstValue;

                                userallmenulist.Add(usermenudata);
                            }
                        }

                        HttpContext.Session.SetObject("UserAllMenu", userallmenulist);
                        HttpContext.Session.SetObject("UserGroupMenu", userallmenulist.Where(x => x.IsGroup == true));
                        HttpContext.Session.SetObject("UserParentMenu", userallmenulist.Where(x => x.IsParent == true));
                        HttpContext.Session.SetObject("UserChildMenu", userallmenulist.Where(x => x.ParentId != null));

                    }


                    HttpContext.Session.SetObject("MenuList", _menuRepository.All().OrderBy(x => x.ParentMenu.DisplayOrder));





                    var countryinfo = _countryRepository.All().Where(x => x.Id == storeinfo.CountryId).FirstOrDefault();
                    var countryinfoViewFormat = _countryRepository.All().Where(x => x.Id == 231).FirstOrDefault();


                    HttpContext.Session.SetString("CurrencyShortNameViewFormat", countryinfoViewFormat.CurrencyShortName);
                    HttpContext.Session.SetString("CultureInfoViewFormat", countryinfoViewFormat.CultureInfo);
                    HttpContext.Session.SetString("CountryShortNameViewFormat", countryinfoViewFormat.CountryShortName);
                    HttpContext.Session.SetString("CurrencySymbolViewFormat", countryinfoViewFormat.CurrencySymbol);


                    HttpContext.Session.SetString("CurrencyShortName", countryinfo.CurrencyShortName);
                    HttpContext.Session.SetString("CultureInfo", countryinfo.CultureInfo);
                    HttpContext.Session.SetString("CountryShortName", countryinfo.CountryShortName);
                    HttpContext.Session.SetString("CurrencySymbol", countryinfo.CurrencySymbol);




                    HttpContext.SignInAsync(principal);

                    HttpContext.Session.SetInt32("AccountHeadExist", 1);
                    var AccountHeadExist = _accountHeadRepository.All().Count();
                    if (AccountHeadExist == 0)
                    {
                        HttpContext.Session.SetInt32("AccountHeadExist", 0);
                        redirectUrl = Url.Action("ImportAccount", "Accounts");
                        return Json(new { Url = redirectUrl });

                    }


                    HttpContext.Session.SetString("Latitude", "");
                    HttpContext.Session.SetString("Longitude", "");


                    LogRepository.SuccessLogin(HttpContext.Session.GetString("Latitude"), HttpContext.Session.GetString("Longitude"), "Success");

                    if (userdata.IsBaseUser == true)
                    {
                        var firstmenu = _menuPermissionRepository.All().Include(x => x.Menus).Where(x => x.Menus.ParentId != null && x.BusinessTypeId == storeinfo.BusinessTypeId).OrderBy(x => x.Menus.DisplayOrder).FirstOrDefault();

                        if (firstmenu == null)
                        {
                            return Json(new { Url = redirectUrl });
                            //return RedirectToAction("AccessDenied");
                        }
                        //return RedirectToAction(firstmenu.Menus.ActionName, firstmenu.Menus.ControllerName);


                        redirectUrl = Url.Action(firstmenu.Menus.ActionName, firstmenu.Menus.ControllerName);
                        if (!string.IsNullOrEmpty(returnurl))
                        {
                            redirectUrl = returnurl;
                        }
                        return Json(new { Url = redirectUrl });

                    }
                    else
                    {
                        var firstmenu = _menuPermissionDetailsRepository.All().Include(x => x.MenuPermissionMasters).Include(x => x.Menus).Where(x => x.Menus.ParentId != null && x.MenuPermissionMasters.LUserIdPermission == UserId).OrderBy(x => x.Menus.DisplayOrder).FirstOrDefault();

                        if (firstmenu == null)
                        {
                            return RedirectToAction("AccessDenied");
                        }
                        //return RedirectToAction(firstmenu.Menus.ActionName, firstmenu.Menus.ControllerName);
                        redirectUrl = Url.Action(firstmenu.Menus.ActionName, firstmenu.Menus.ControllerName);
                        if (!string.IsNullOrEmpty(returnurl))
                        {
                            redirectUrl = returnurl;
                        }
                        return Json(new { Url = redirectUrl });
                    }


                }
                else
                {
                    HttpContext.Session.SetString("Latitude", "=N/A=");
                    HttpContext.Session.SetString("Longitude", "=N/A=");
                    HttpContext.Session.SetString("UserInfo", user.Email + " " + user.Password);

                    LogRepository.SuccessLogin(HttpContext.Session.GetString("Latitude"), HttpContext.Session.GetString("Longitude"), "Failure");

                    if (!string.IsNullOrEmpty(returnurl))
                    {
                        redirectUrl = returnurl;
                    }


                    TempData["UserLoginFailed"] = "Login Failed.Please enter correct credentials";
                    return Json(new { Url = redirectUrl });
                }



                return Json(new { Url = redirectUrl });
            }
            catch (Exception ex)
            {
                var a = ex;
                Console.WriteLine(a);
                throw ex;
            }

        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AtraiLogin(LoginViewModel user)
        {


            if (user.CredentialType == "U")
            {
                #region UserLogin
                #region weburlinfo
                var weburl = Request.GetTypedHeaders().Referer.ToString().ToLower();//.Replace("/Home/Login".ToLower(), "");
                var weburlquerystring = Request.QueryString.HasValue == true ? Request.QueryString.ToString() : "";// Request.QueryString == null ? "": Request.QueryString;// Request.QueryString?? Request.QueryString;//.Replace("/Home/Login".ToLower(), "");

                var origin = weburl.ToLower();
                var controllerName = this.ControllerContext.RouteData.Values["Controller"].ToString().ToLower();


                string St = weburl.ToLower();
                int pFrom = St.IndexOf("/?");

                if (pFrom > 0)
                {
                    var filterurl = St.Substring(0, pFrom);
                    origin = filterurl;
                }
                //string example = "Hello, World!";

                //// Get the 5 characters from the left of the string
                //string exampleLeft = example.Substring(0, 5);



                //String St = weburl.ToLower();

                //int pFrom = St.IndexOf("/") + "/".Length;
                //int pTo = St.LastIndexOf("/" + controllerName);
                string resulta = "";
                //if (pTo < 1)
                //{
                //    resulta = origin;

                //}
                //else
                //{
                //    resulta = St.Substring(pFrom, pTo - pFrom);
                //    resulta = origin + "/" + resulta;

                //}


                if (weburlquerystring.Length > 2)
                {
                    resulta = origin.Replace(weburlquerystring, "").Replace("/Home/Login".ToLower(), "");

                }
                else
                {
                    resulta = origin.Replace("/Home/Login".ToLower(), "");

                }

                #endregion



                if (ModelState.IsValid)
                {
                    bool result = userAccountRepository.ValidateUser(user);

                    if (result)
                    {
                        #region email send if not confirmed email by user or by click from the email link 
                        //var Emailverifiedinfo = userAccountRepository.All(false).Where(x => x.Email == user.Email && x.IsEmailVerified == false).ToList();
                        var Emailverifiedinfo = userAccountRepository.All().Where(x => x.Email == user.Email && x.IsEmailVerified == false).ToList();

                        if (Emailverifiedinfo.Count > 0)
                        {
                            TempData["UserLoginFailed"] = "Email Not Confirmed Yet. Please check Your mail to Activate Your user Account. or Contact with your service provider 01671303302.";
                            var OTPvalue = ValuesController.randomnumbergenerate(4, 1050, 9999).ToString();
                            int usercomid = userAccountRepository.GetComId(user);
                            var compnayinfo = companyRepository.Find(usercomid);

                            //var userconfirmtiondata = userAccountRepository.All(false).Where(x => x.Email == user.Email).FirstOrDefault();

                            //if (userconfirmtiondata != null)
                            //{
                            //    userconfirmtiondata.OTP = OTPvalue;
                            //    userAccountRepository.Update(userconfirmtiondata, userconfirmtiondata.Id);
                            //}

                            if (user.Email != null && Emailverifiedinfo.FirstOrDefault().OTP != "" || Emailverifiedinfo.FirstOrDefault().OTP != null)
                            {
                                //return RedirectToAction("EmailConfirmation", "Home", new { Email = user.Email, PhoneNo = Emailverifiedinfo.FirstOrDefault().PhoneNumber });
                                return RedirectToAction("OTPConfirmation", "Home", new { Email = user.Email, PhoneNo = Emailverifiedinfo.FirstOrDefault().PhoneNumber });

                                //var callBackUrl = Url.ActionLink("UserConfirmation", "Home", new { Email = user.Email, OTPValue = OTPvalue });
                                //string mailList = user.Email;
                                //string subject = $"User has been created Successfully for Compnay  {compnayinfo.CompanyName}";
                                //string body = $"Thanks for Register Your Email for {compnayinfo.CompanyName} . <br/><br/> Created Time : - {DateTime.Now}<br/>To Activate Account Please follow the link <br/><br/><a href='{HtmlEncoder.Default.Encode(callBackUrl)}'>Active the Email by Clicking Here</a>";
                                //var hostaddressforsender = Request.GetTypedHeaders().Host.Value;

                                //SendEmail(mailList, subject, body , hostaddressforsender);
                            }

                            return View();
                        }

                        #endregion




                        //var claims = new List<Claim>
                        //{
                        //    new Claim(ClaimTypes.Name, user.Email , user.EmpImagePath )
                        //};
                        //var _claim = new Claim("Role", userdata.UserRole.RoleName);
                        //claims.Add(_claim);
                        //ClaimsIdentity userIdentity = new ClaimsIdentity(claims, "login");
                        //ClaimsPrincipal principal = new ClaimsPrincipal(userIdentity);

                        Atrai.Model.AppData.DefaultConnectionString = Config.GetConnectionString("DefaultConnection");



                        int? vatview = HttpContext.Session.GetInt32("VatViewActivate");
                        if (vatview == null || vatview == 0)
                        {
                            HttpContext.Session.SetInt32("VatViewActivate", 0);
                        }
                        else
                        {
                            HttpContext.Session.SetInt32("VatViewActivate", 1);
                        }



                        HttpContext.Session.SetInt32("IsMobile", 0);

                        int UserId = userAccountRepository.GetUserId(user);
                        HttpContext.Session.SetInt32("UserId", UserId);

                        int ComId = userAccountRepository.GetComId(user);
                        HttpContext.Session.SetInt32("ComId", ComId);

                        string ComName = companyRepository.GetComName(ComId);
                        HttpContext.Session.SetString("ComName", ComName);

                        HttpContext.Session.SetString("UserInfo", user.Email);

                        //var rolename = userAccountRepository.All(false).Where(A => A.Id == UserId).Include(x => x.UserRole).Include(x => x.EmployeeList).FirstOrDefault();
                        //HttpContext.Session.SetString("RoleName", rolename.UserRole.RoleName);


                        HttpContext.Session.SetInt32("PurchasePackage", 0);
                        if (userAccountRepository.All().Include(x => x.UserRole).Where(x => x.Id == UserId).FirstOrDefault().UserRole.RoleName != "SuperAdmin")
                        {
                            var subscriptionactivationdata = _subscriptionActivationRepository.All().Where(x => x.LuserId == UserId && x.ActiveToDate > DateTime.Now.Date).FirstOrDefault();

                            //HttpContext.Session.SetInt32("UserValidityDays", (int)subscriptionactivationdata.ValidityDay);

                            HttpContext.Session.SetInt32("UserValidityDays", (int)(subscriptionactivationdata?.ValidityDay ?? 0));

                            //userdata.EmployeeList?.EmployeeImagePath ?? ""
                            HttpContext.Session.SetInt32("ShowAlert", 1);



                            if (subscriptionactivationdata == null)
                            {
                                HttpContext.Session.SetInt32("PurchasePackage", 1);

                                ////off after talk with mr. noman
                                //TempData["UserLoginFailed"] = "User Expired . Please Activate Your user by Pay renewal fee.. or Contact with your service provider 01671303302.";
                                //return View();

                            }


                            //var activatepackage = _packageActivationRepository.All().Where(x => x.ComId == ComId && x.ActiveYesNo == true).OrderByDescending(x => x.Id).FirstOrDefault();

                            //if (activatepackage == null)
                            //{
                            //    return RedirectToAction("PurchasePackage", "License");
                            //    /// return RedirectToAction(firstmenu.Menus.ActionName, firstmenu.Menus.ControllerName);
                            //}


                        }



                        //return View(saleRepository.All().Include(x => x.CustomerModel).OrderByDescending(x => x.Id));

                        var userdata = userAccountRepository.All().Include(x => x.UserRole).Include(x => x.EmployeeList).Where(x => x.Id == UserId).FirstOrDefault();
                        var claims = new List<Claim>
                    {
                        new Claim(ClaimTypes.Name, user.Email , user.EmpImagePath )
                    };
                        var _claim = new Claim("Role", userdata.UserRole.RoleName);
                        claims.Add(_claim);
                        ClaimsIdentity userIdentity = new ClaimsIdentity(claims, "login");
                        ClaimsPrincipal principal = new ClaimsPrincipal(userIdentity);

                        //applicat

                        HttpContext.Session.SetInt32("UserRoleId", userdata.UserRoleId ?? 0);
                        HttpContext.Session.SetString("UserRole", userdata.UserRole.RoleName ?? "");


                        HttpContext.Session.SetString("EmpImagePath", userdata.EmployeeList?.EmployeeImagePath ?? "");

                        if (userdata.UserRole.RoleName.Contains("SuperAdmin"))
                        {
                            HttpContext.Session.SetInt32("IsUserLevel", 1);

                            //HttpContext.Session.SetInt32("IsSuperAdmin", 1);
                            //HttpContext.Session.SetInt32("IsAdmin", 0);
                            //HttpContext.Session.SetInt32("IsUser", 0);
                        }
                        else if (userdata.UserRole.RoleName.Contains("Admin"))
                        {
                            HttpContext.Session.SetInt32("IsUserLevel", 2);


                            //HttpContext.Session.SetInt32("IsSuperAdmin", 0);
                            //HttpContext.Session.SetInt32("IsAdmin", 1);
                            //HttpContext.Session.SetInt32("IsUser", 0);
                        }
                        else if (userdata.UserRole.RoleName.Contains("User"))
                        {
                            HttpContext.Session.SetInt32("IsUserLevel", 3);


                            //HttpContext.Session.SetInt32("IsSuperAdmin", 0);
                            //HttpContext.Session.SetInt32("IsAdmin", 0);
                            //HttpContext.Session.SetInt32("IsUser", 1);
                        }
                        else
                        {
                            HttpContext.Session.SetInt32("IsUserLevel", 4);


                            //HttpContext.Session.SetInt32("IsSuperAdmin", 0);
                            //HttpContext.Session.SetInt32("IsAdmin", 0);
                            //HttpContext.Session.SetInt32("IsUser", 0);
                        }



                        if (userdata.UserRole.RoleName.Contains("SuperAdmin"))
                        {
                            var CompanyUserList = companyRepository.All().Select(x => new SelectListItem { Text = x.CompanyName, Value = x.Id.ToString() }).OrderBy(x => x.Value).ToList();

                            //var CompanyUserList = _companyPermissionRepository.All().Include(x => x.CompanyList).Where(x => x.ComId == ComId && x.LuserId == UserId).Select(x => new SelectListItem { Text = x.CompanyList.CompanyName, Value = x.ComId.ToString() }).OrderBy(x=>x.Value).ToList();
                            if (CompanyUserList.Count > 0)
                            {
                                HttpContext.Session.SetObject("UserCompanys", CompanyUserList);
                            }
                        }
                        else //if (!userdata.UserRole.RoleName.Contains("Admin"))
                        {
                            /////////////if multi compnay is avaialable but he have only single company permission not the default one.
                            var CompanyUserList = _companyPermissionRepository.All().Include(x => x.CompanyList).Where(x => x.LuserId == UserId).Select(x => new SelectListItem { Text = x.CompanyList.CompanyName, Value = x.ComId.ToString() }).ToList();
                            HttpContext.Session.SetObject("UserCompanys", CompanyUserList);

                            if (CompanyUserList.Count() > 0)
                            {
                                ComId = int.Parse(CompanyUserList.FirstOrDefault().Value);
                                HttpContext.Session.SetInt32("ComId", ComId);

                                ComName = CompanyUserList.FirstOrDefault().Text;
                                HttpContext.Session.SetString("ComName", ComName);
                            }
                        }
                        //////////need to set the permit compnay 


                        var company = companyRepository.All().Where(x => x.Id == ComId).Include(x => x.BusinessType).FirstOrDefault();
                        var storeinfo = storeSettingRepository.All().Where(x => x.ComId == ComId)
                            .Include(x => x.SalesReportStyle)
                            .Include(x => x.PurchaseReportStyle)
                            .Include(x => x.BarcodeReportStyle)
                                                .Include(x => x.TimeZones)
                                                .Include(x => x.Currency)
                            .FirstOrDefault();

                        HttpContext.Session.SetString("ShortCutKey", storeinfo.ShortCutKey != null ? storeinfo.ShortCutKey : "q"); // "y"
                        HttpContext.Session.SetString("SearchType", storeinfo.isScanner == true ? "Scanner" : "Manual"); // "Scanner"
                        HttpContext.Session.SetString("barcodeprefixforweightscale", storeinfo.BarcodePrefixForWeightScale != null ? storeinfo.BarcodePrefixForWeightScale : "99"); // "Scanner"


                        HttpContext.Session.SetInt32("BaseComId", storeinfo.BaseComId);

                        HttpContext.Session.SetInt32("BusinessTypeId", company.BusinessTypeId);
                        HttpContext.Session.SetString("BusinessType", company.BusinessType.BusinessTypeName);
                        HttpContext.Session.SetString("AppsName", company.BusinessType.AppsName);


                        HttpContext.Session.SetString("CompanyName", company.CompanyName != null ? company.CompanyName : "");
                        HttpContext.Session.SetString("PrimaryAddress", company.PrimaryAddress != null ? company.PrimaryAddress : "");
                        HttpContext.Session.SetString("SecoundaryAddress", company.SecoundaryAddress != null ? company.SecoundaryAddress : "");
                        HttpContext.Session.SetString("comPhone", company.comPhone != null ? company.comPhone : "");
                        HttpContext.Session.SetString("comWeb", company.comWeb != null ? company.comWeb : "");
                        HttpContext.Session.SetString("comEmail", company.comEmail != null ? company.comEmail : "");
                        HttpContext.Session.SetString("CaptionOne", "CaptionOne");
                        HttpContext.Session.SetString("CaptionTwo", "CaptionTwo");
                        HttpContext.Session.SetString("PrintDate", DateTime.Now.Date.ToString("dd-MMM-yy"));
                        HttpContext.Session.SetString("comImagePath", storeinfo != null ? storeinfo.Logo != null ? storeinfo.Logo : "" : "");
                        HttpContext.Session.SetString("weburl", resulta.ToString());

                        HttpContext.Session.SetString("OfferDiscountPer", storeinfo != null ? storeinfo.OfferDiscountPer.ToString() : "0.00");
                        HttpContext.Session.SetInt32("isDiscountOffer", storeinfo != null ? storeinfo.isDiscountOffer != false ? 1 : 0 : 0);


                        HttpContext.Session.SetString("TaxPer", storeinfo != null ? storeinfo.TaxPer.ToString() : "0.00");
                        HttpContext.Session.SetString("SalesReportStyle", storeinfo.SalesReportStyle != null ? storeinfo.SalesReportStyle.ReportStyleName : "Style1");
                        HttpContext.Session.SetString("PurchaseReportStyle", storeinfo.PurchaseReportStyle != null ? storeinfo.PurchaseReportStyle.ReportStyleName : "Style1");
                        HttpContext.Session.SetString("BarcodeReportStyle", storeinfo.BarcodeReportStyle != null ? storeinfo.BarcodeReportStyle.ReportStyleName : "Style1");

                        HttpContext.Session.SetInt32("isTaxExcluded", storeinfo != null ? storeinfo.isTaxExcluded != false ? 1 : 0 : 0);

                        HttpContext.Session.SetInt32("isMultiSelect", storeinfo != null ? storeinfo.isMultiSelect != false ? 1 : 0 : 0);
                        HttpContext.Session.SetInt32("isFixedSalesValue", storeinfo != null ? storeinfo.IsFixedSalesValue != false ? 1 : 0 : 0);
                        HttpContext.Session.SetInt32("IsFirstLetterUpperCase", storeinfo != null ? storeinfo.IsFirstLetterUpperCase != false ? 1 : 0 : 0);


                        HttpContext.Session.SetInt32("IsSerialSales", storeinfo != null ? storeinfo.IsSerialSales != false ? 1 : 0 : 0);
                        HttpContext.Session.SetInt32("IsIndDiscount", storeinfo != null ? storeinfo.IsIndDiscount != false ? 1 : 0 : 0);
                        HttpContext.Session.SetInt32("IsSalesDescription", storeinfo != null ? storeinfo.IsSalesDescription != false ? 1 : 0 : 0);
                        HttpContext.Session.SetInt32("IsVatLogin", storeinfo != null ? storeinfo.IsVatLogin != false ? 1 : 0 : 0);
                        HttpContext.Session.SetInt32("isMultiCurrency", storeinfo != null ? storeinfo.isMultiCurrency != false ? 1 : 0 : 0);
                        HttpContext.Session.SetInt32("IsTermsCondition", storeinfo != null ? storeinfo.IsTermsCondition != false ? 1 : 0 : 0);
                        HttpContext.Session.SetInt32("IsDefaultDisAmount", storeinfo != null ? storeinfo.IsDefaultDisAmount != false ? 1 : 0 : 0);
                        HttpContext.Session.SetInt32("DecimalField", storeinfo != null ? storeinfo.DecimalField : 0);


                        HttpContext.Session.SetInt32("IsFixedDiscountMainValue", storeinfo != null ? storeinfo.IsFixedDiscountMainValue != false ? 1 : 0 : 0);
                        HttpContext.Session.SetInt32("IsFixedDiscountRowValue", storeinfo != null ? storeinfo.IsFixedDiscountRowValue != false ? 1 : 0 : 0);
                        HttpContext.Session.SetString("MaxDiscountMainValue", storeinfo != null ? storeinfo.MaxDiscountMainValue.ToString() : "0.00");
                        HttpContext.Session.SetString("MaxDiscountPercentageMainValue", storeinfo != null ? storeinfo.MaxDiscountPercentageMainValue.ToString() : "0.00");
                        HttpContext.Session.SetString("MaxDiscountRowValue", storeinfo != null ? storeinfo.MaxDiscountRowValue.ToString() : "0.00");




                        HttpContext.Session.SetInt32("PrintProductName", storeinfo != null ? storeinfo.PrintProductName != false ? 1 : 0 : 0);
                        HttpContext.Session.SetInt32("PrintProductCode", storeinfo != null ? storeinfo.PrintProductCode != false ? 1 : 0 : 0);
                        HttpContext.Session.SetInt32("PrintProductDescription", storeinfo != null ? storeinfo.PrintProductDescription != false ? 1 : 0 : 0);
                        HttpContext.Session.SetInt32("PrintBrandName", storeinfo != null ? storeinfo.PrintBrandName != false ? 1 : 0 : 0);
                        HttpContext.Session.SetInt32("PrintModelName", storeinfo != null ? storeinfo.PrintModelName != false ? 1 : 0 : 0);
                        HttpContext.Session.SetInt32("PrintSizeName", storeinfo != null ? storeinfo.PrintSizeName != false ? 1 : 0 : 0);
                        HttpContext.Session.SetInt32("VisibleSalesCommission", storeinfo != null ? storeinfo.VisibleSalesCommission != false ? 1 : 0 : 0);



                        HttpContext.Session.SetString("isMultiDebitCredit", storeinfo.isMultiDebitCredit.ToString());
                        //HttpContext.Session.SetString("isMultiCurrency", company.isMultiCurrency.ToString());

                        HttpContext.Session.SetString("isVoucherDistributionEntry", storeinfo.isVoucherDistributionEntry.ToString());
                        HttpContext.Session.SetString("isChequeDetails", storeinfo.isChequeDetails.ToString());

                        HttpContext.Session.SetString("isSMSService", storeinfo.isSMSService.ToString());
                        HttpContext.Session.SetString("isEmailSerivce", storeinfo.isEmailSerivce.ToString());
                        HttpContext.Session.SetString("IsSignature", company != null ? storeinfo.IsSignature.ToString() : "false");


                        HttpContext.Session.SetInt32("defaultcurrencyid", storeinfo.CountryId);
                        HttpContext.Session.SetString("defaultcurrencyname", storeinfo.Currency.CurrencyShortName.ToString());
                        HttpContext.Session.SetInt32("TimeZoneSettingsId", storeinfo.TimeZones != null ? storeinfo.TimeZoneSettingsId : 36);
                        HttpContext.Session.SetString("TimeZoneSettingsName", storeinfo.TimeZones != null ? storeinfo.TimeZones.TimeZoneName : "");
                        HttpContext.Session.SetString("TimeZoneSettingsNameJquery", storeinfo.TimeZones != null ? storeinfo.TimeZones.TimeZoneNameJquery : "");







                        //HttpContext.Session.SetObject("UserAllMenu", _menuPermissionRepository.All().Include(x => x.Menu).Where(x => x.UserRoleId == userdata.UserRoleId && x.BusinessTypeId == company.BusinessTypeId).OrderBy(x => x.Menu.DisplayOrder));
                        //HttpContext.Session.SetObject("UserGroupMenu", _menuPermissionRepository.All().Include(x => x.Menu).Where(x => x.Menu.isGroup == true && x.UserRoleId == userdata.UserRoleId && x.BusinessTypeId == company.BusinessTypeId).OrderBy(x => x.Menu.DisplayOrder));
                        //HttpContext.Session.SetObject("UserParentMenu", _menuPermissionRepository.All().Include(x => x.Menu).Where(x => x.Menu.isParent == true && x.UserRoleId == userdata.UserRoleId && x.BusinessTypeId == company.BusinessTypeId).OrderBy(x => x.Menu.DisplayOrder));
                        //HttpContext.Session.SetObject("UserChildMenu", _menuPermissionRepository.All().Include(x => x.Menu).Where(x => x.Menu.ParentId != null && x.UserRoleId == userdata.UserRoleId && x.BusinessTypeId == company.BusinessTypeId).OrderBy(x => x.Menu.DisplayOrder));





                        //HttpContext.Session.SetObject("UserAllMenu", _menuPermissionMasterRepository.All().Include(x => x.MenuPermission_Details).ThenInclude(x => x.Menus).Where(x => x.LUserIdPermission == UserId));






                        if (userdata.IsBaseUser == true)
                        {
                            var userpermissionmenulist = _menuPermissionRepository.All().Include(x => x.Menus).Where(x => x.BusinessTypeId == company.BusinessTypeId);

                            if (storeinfo.IsVatLogin == true)
                            {
                                userpermissionmenulist = userpermissionmenulist.Where(x => x.Menus.IsVatMenu == true);
                                HttpContext.Session.SetInt32("VatViewActivate", 1);
                            }

                            List<UserMenuPermissionViewModel> userallmenulist = new List<UserMenuPermissionViewModel>();

                            if (userpermissionmenulist != null)
                            {
                                foreach (var item in userpermissionmenulist.OrderBy(x => x.Menus.DisplayOrder))
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
                                    usermenudata.FirstParameter = item.Menus.FirstParameter;
                                    usermenudata.FirstValue = item.Menus.FirstValue;

                                    userallmenulist.Add(usermenudata);
                                }
                            }

                            HttpContext.Session.SetObject("UserAllMenu", userallmenulist);
                            HttpContext.Session.SetObject("UserGroupMenu", userallmenulist.Where(x => x.IsGroup == true));
                            HttpContext.Session.SetObject("UserParentMenu", userallmenulist.Where(x => x.IsParent == true));
                            HttpContext.Session.SetObject("UserChildMenu", userallmenulist.Where(x => x.ParentId != null));


                        }
                        else
                        {

                            var userpermissionmenulist = _menuPermissionDetailsRepository.All().Include(x => x.MenuPermissionMasters).Include(x => x.Menus).Where(x => x.MenuPermissionMasters.LUserIdPermission == UserId && x.MenuPermissionMasters.ComId == ComId);

                            //HttpContext.Session.SetString("SummaryView", userpermissionmenulist.FirstOrDefault().MenuPermissionMasters.SummaryView.ToString()); /// fahad need to check for sales summary view activate


                            if (storeinfo.IsVatLogin == true)
                            {
                                userpermissionmenulist = userpermissionmenulist.Where(x => x.Menus.IsVatMenu == true);
                                HttpContext.Session.SetInt32("VatViewActivate", 1);
                            }

                            List<UserMenuPermissionViewModel> userallmenulist = new List<UserMenuPermissionViewModel>();

                            if (userpermissionmenulist != null)
                            {
                                foreach (var item in userpermissionmenulist.OrderBy(x => x.Menus.DisplayOrder))
                                {
                                    UserMenuPermissionViewModel usermenudata = new UserMenuPermissionViewModel();

                                    usermenudata.Id = item.Menus.Id;

                                    usermenudata.ActionName = item.Menus.ActionName;
                                    usermenudata.ControllerName = item.Menus.ControllerName;
                                    usermenudata.IsCreate = item.IsCreate;
                                    usermenudata.IsDeleteP = item.IsDeleteP;
                                    usermenudata.IsEdit = item.IsEdit;
                                    usermenudata.isDefault = item.isDefault;
                                    usermenudata.SLNo = item.SLNo;

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
                                    usermenudata.FirstParameter = item.Menus.FirstParameter;
                                    usermenudata.FirstValue = item.Menus.FirstValue;

                                    userallmenulist.Add(usermenudata);
                                }
                            }

                            HttpContext.Session.SetObject("UserAllMenu", userallmenulist);
                            HttpContext.Session.SetObject("UserGroupMenu", userallmenulist.Where(x => x.IsGroup == true));
                            HttpContext.Session.SetObject("UserParentMenu", userallmenulist.Where(x => x.IsParent == true));
                            HttpContext.Session.SetObject("UserChildMenu", userallmenulist.Where(x => x.ParentId != null));

                        }







                        //if (userdata.UserRole.RoleName.Contains("SuperAdmin"))
                        //{
                        //    var CompanyUserList = companyRepository.All().Select(x => new SelectListItem { Text = x.CompanyName, Value = x.Id.ToString() }).OrderBy(x => x.Value).ToList();


                        //    //var CompanyUserList = _companyPermissionRepository.All().Include(x => x.CompanyList).Where(x => x.ComId == ComId && x.LuserId == UserId).Select(x => new SelectListItem { Text = x.CompanyList.CompanyName, Value = x.ComId.ToString() }).OrderBy(x=>x.Value).ToList();
                        //    if (CompanyUserList.Count > 0)
                        //    {
                        //        HttpContext.Session.SetObject("UserCompanys", CompanyUserList);
                        //    }
                        //}
                        //else //if (!userdata.UserRole.RoleName.Contains("Admin"))
                        //{

                        //    var CompanyUserList = _companyPermissionRepository.All().Include(x => x.CompanyList).Where(x => x.LuserId == UserId).Select(x => new SelectListItem { Text = x.CompanyList.CompanyName, Value = x.ComId.ToString() }).ToList();
                        //    // x.ComId == ComId && 
                        //    //if (CompanyUserList.Count > 0) 
                        //    //{
                        //    HttpContext.Session.SetObject("UserCompanys", CompanyUserList);
                        //    //}
                        //}
                        ////////////need to set the permit compnay 











                        //HttpContext.Session.SetObject("UserGroupMenu", _menuPermissionDetailsRepository.All().Include(x => x.MenuPermissionMasters).Include(x => x.Menus).Where(x => x.Menus.isGroup == true && x.MenuPermissionMasters.LUserIdPermission == UserId).OrderBy(x => x.SLNo));
                        //var testmenu = HttpContext.Session.GetObject<List<MenuPermission_DetailsModel>>("UserGroupMenu");


                        //HttpContext.Session.SetObject("UserParentMenu", _menuPermissionDetailsRepository.All().Include(x => x.MenuPermissionMasters).Include(x => x.Menus).Where(x => x.Menus.isParent == true && x.MenuPermissionMasters.LUserIdPermission == UserId).OrderBy(x => x.SLNo));
                        //HttpContext.Session.SetObject("UserChildMenu", _menuPermissionDetailsRepository.All().Include(x => x.MenuPermissionMasters).Include(x => x.Menus).Where(x => x.Menus.ParentId != null && x.MenuPermissionMasters.LUserIdPermission == UserId).OrderBy(x => x.SLNo));
                        HttpContext.Session.SetObject("MenuList", _menuRepository.All().OrderBy(x => x.ParentMenu.DisplayOrder));





                        var countryinfo = _countryRepository.All().Where(x => x.Id == storeinfo.CountryId).FirstOrDefault();
                        var countryinfoViewFormat = _countryRepository.All().Where(x => x.Id == 231).FirstOrDefault();

                        //var cultureInfo = new CultureInfo(countryinfo.CultureInfo);
                        //cultureInfo.NumberFormat.CurrencySymbol = countryinfo.CurrencySymbol;
                        //CultureInfo.DefaultThreadCurrentCulture = cultureInfo;
                        //CultureInfo.DefaultThreadCurrentUICulture = cultureInfo;


                        HttpContext.Session.SetString("CurrencyShortNameViewFormat", countryinfoViewFormat.CurrencyShortName);
                        HttpContext.Session.SetString("CultureInfoViewFormat", countryinfoViewFormat.CultureInfo);
                        HttpContext.Session.SetString("CountryShortNameViewFormat", countryinfoViewFormat.CountryShortName);
                        HttpContext.Session.SetString("CurrencySymbolViewFormat", countryinfoViewFormat.CurrencySymbol);


                        HttpContext.Session.SetString("CurrencyShortName", countryinfo.CurrencyShortName);
                        HttpContext.Session.SetString("CultureInfo", countryinfo.CultureInfo);
                        HttpContext.Session.SetString("CountryShortName", countryinfo.CountryShortName);
                        HttpContext.Session.SetString("CurrencySymbol", countryinfo.CurrencySymbol);


                        ///off by fahad
                        //var fiscalyear = _accFiscalYearRepository.All().Where(x => x.OpeningDate.Year == DateTime.Now.Year).ToList().Count();

                        //if (fiscalyear == 0)
                        //{
                        //    ///fiscal year Creation
                        //    var PrevYear = DateTime.Now.Year - 1;
                        //    var fromdate = new DateTime(PrevYear, 1, 1);
                        //    var todate = new DateTime(PrevYear, 12, 31);

                        //    SqlParameter[] sqlParameterfy = new SqlParameter[4];
                        //    sqlParameterfy[0] = new SqlParameter("@comid", ComId);
                        //    sqlParameterfy[1] = new SqlParameter("@dtFrom", fromdate);
                        //    sqlParameterfy[2] = new SqlParameter("@dtTo", todate);
                        //    sqlParameterfy[3] = new SqlParameter("@UserId", UserId);
                        //    Helper.ExecProc("Acc_prcCloseFiscalYearManual", sqlParameterfy);
                        //    ///fiscal year Creation
                        //}

                        ///off by fahad 
                        //HttpContext.Session.SetString("CompanyAddressBangla", company.CompanyAddressBangla != null ? company.CompanyAddressBangla : "");
                        //HttpContext.Session.SetString("CompanyNameBangla", company.CompanyNameBangla != null ? company.CompanyNameBangla : "");



                        await HttpContext.SignInAsync(principal);

                        //var UserId = HttpContext.Session.GetInt32("UserId");
                        //var ComId = HttpContext.Session.GetInt32("ComId");

                        HttpContext.Session.SetString("Latitude", "");
                        HttpContext.Session.SetString("Longitude", "");


                        LogRepository.SuccessLogin(HttpContext.Session.GetString("Latitude"), HttpContext.Session.GetString("Longitude"), "Success");

                        //return RedirectToAction("Index", "Admin");


                        //var firstmenu = _menuPermissionRepository.All().Include(x => x.Menu).Where(x => x.Menu.ParentId != null && x.UserRoleId == userdata.UserRoleId && x.BusinessTypeId == company.BusinessTypeId).OrderBy(x => x.Menu.DisplayOrder).FirstOrDefault();






                        if (userdata.IsBaseUser == true)
                        {
                            var firstmenu = _menuPermissionRepository.All().Include(x => x.Menus).Where(x => x.Menus.ParentId != null && x.BusinessTypeId == company.BusinessTypeId).OrderBy(x => x.Menus.DisplayOrder).FirstOrDefault();

                            if (firstmenu == null)
                            {
                                return RedirectToAction("AccessDenied");
                            }
                            return RedirectToAction(firstmenu.Menus.ActionName, firstmenu.Menus.ControllerName);
                        }
                        else
                        {
                            var firstmenu = _menuPermissionDetailsRepository.All().Include(x => x.MenuPermissionMasters).Include(x => x.Menus).Where(x => x.Menus.ParentId != null && x.MenuPermissionMasters.LUserIdPermission == UserId).OrderBy(x => x.Menus.DisplayOrder).FirstOrDefault();

                            if (firstmenu == null)
                            {
                                return RedirectToAction("AccessDenied");
                            }
                            return RedirectToAction(firstmenu.Menus.ActionName, firstmenu.Menus.ControllerName);
                        }


                    }
                    else
                    {
                        HttpContext.Session.SetString("Latitude", "=N/A=");
                        HttpContext.Session.SetString("Longitude", "=N/A=");
                        HttpContext.Session.SetString("UserInfo", user.Email + " " + user.Password);

                        LogRepository.SuccessLogin(HttpContext.Session.GetString("Latitude"), HttpContext.Session.GetString("Longitude"), "Failure");

                        TempData["UserLoginFailed"] = "Login Failed.Please enter correct credentials";
                        return View();
                    }
                }
                else
                    return View(user);
                #endregion
            }
            else if (user.CredentialType == "C")
            {
                #region CustomerLogin

                #region weburlinfo
                var weburl = Request.GetTypedHeaders().Referer.ToString().ToLower();//.Replace("/Home/Login".ToLower(), "");
                var weburlquerystring = Request.QueryString.HasValue == true ? Request.QueryString.ToString() : "";// Request.QueryString == null ? "": Request.QueryString;// Request.QueryString?? Request.QueryString;//.Replace("/Home/Login".ToLower(), "");

                var origin = weburl.ToLower();
                var controllerName = this.ControllerContext.RouteData.Values["Controller"].ToString().ToLower();


                string St = weburl.ToLower();
                int pFrom = St.IndexOf("/?");

                if (pFrom > 0)
                {
                    var filterurl = St.Substring(0, pFrom);
                    origin = filterurl;
                }
                string resulta = "";


                if (weburlquerystring.Length > 2)
                {
                    resulta = origin.Replace(weburlquerystring, "").Replace("/Home/Login".ToLower(), "");

                }
                else
                {
                    resulta = origin.Replace("/Home/Login".ToLower(), "");

                }

                #endregion



                if (ModelState.IsValid)
                {
                    CustomerModel abc = new CustomerModel();
                    abc.LoginId = user.Email;
                    abc.Password = user.Password;


                    //bool result = userAccountRepository.ValidateUser(user);
                    bool result = _customerRepository.ValidateCustomer(abc);


                    var customerdata = _customerRepository.All(false).Include(x => x.SalesRepresentative).Include(x => x.UserAccountList).Where(x => x.LoginId == user.Email && x.Password == user.Password).FirstOrDefault();


                    if (result)
                    {
                        Atrai.Model.AppData.DefaultConnectionString = Config.GetConnectionString("DefaultConnection");

                        int ComId = customerdata.ComId;

                        //var UserIdabc = userAccountRepository.All().Where(x => x.EmployeeId == customerdata.SalesRepresentativeId).FirstOrDefault().Id; //  customerdata.SalesRepresentative.LinkedUserAccount.FirstOrDefault().Id;
                        int UserId = 0;


                        HttpContext.Session.SetInt32("IsMobile", 0);
                        HttpContext.Session.SetInt32("UserId", customerdata.LuserId);
                        HttpContext.Session.SetInt32("CustomerId", customerdata.Id);
                        HttpContext.Session.SetInt32("ComId", customerdata.ComId);



                        string ComName = companyRepository.GetComName(ComId);
                        HttpContext.Session.SetString("ComName", ComName);

                        HttpContext.Session.SetString("UserInfo", user.Email);
                        HttpContext.Session.SetString("SearchType", "Scanner");



                        var userdata = userAccountRepository.All().Include(x => x.UserRole).Include(x => x.EmployeeList).Where(x => x.Id == UserId).FirstOrDefault();
                        var claims = new List<Claim>
                            {
                                new Claim(ClaimTypes.Name, user.Email )
                            };
                        var _claim = new Claim("Role", "Customer"); //userdata.UserRole.RoleName
                        claims.Add(_claim);
                        ClaimsIdentity userIdentity = new ClaimsIdentity(claims, "login");
                        ClaimsPrincipal principal = new ClaimsPrincipal(userIdentity);

                        //applicat

                        //HttpContext.Session.SetInt32("UserRoleId", userdata.UserRoleId ?? 0);
                        //HttpContext.Session.SetString("UserRole", userdata.UserRole.RoleName ?? "");
                        //HttpContext.Session.SetString("EmpImagePath", userdata.EmployeeList?.EmployeeImagePath ?? "");







                        var company = companyRepository.All().Where(x => x.Id == ComId).Include(x => x.BusinessType).FirstOrDefault();
                        var storeinfo = storeSettingRepository.All().Where(x => x.ComId == ComId)
                            .Include(x => x.SalesReportStyle)
                            .Include(x => x.PurchaseReportStyle)
                            .Include(x => x.BarcodeReportStyle)
                                                .Include(x => x.TimeZones)
                                                .Include(x => x.Currency)
                            .FirstOrDefault();



                        HttpContext.Session.SetInt32("BaseComId", storeinfo.BaseComId);

                        HttpContext.Session.SetInt32("BusinessTypeId", company.BusinessTypeId);
                        HttpContext.Session.SetString("BusinessType", company.BusinessType.BusinessTypeName);
                        HttpContext.Session.SetString("AppsName", company.BusinessType.AppsName);


                        HttpContext.Session.SetString("CompanyName", company.CompanyName != null ? company.CompanyName : "");
                        HttpContext.Session.SetString("PrimaryAddress", company.PrimaryAddress != null ? company.PrimaryAddress : "");
                        HttpContext.Session.SetString("SecoundaryAddress", company.SecoundaryAddress != null ? company.SecoundaryAddress : "");
                        HttpContext.Session.SetString("comPhone", company.comPhone != null ? company.comPhone : "");
                        HttpContext.Session.SetString("comWeb", company.comWeb != null ? company.comWeb : "");
                        HttpContext.Session.SetString("comEmail", company.comEmail != null ? company.comEmail : "");
                        HttpContext.Session.SetString("CaptionOne", "CaptionOne");
                        HttpContext.Session.SetString("CaptionTwo", "CaptionTwo");
                        HttpContext.Session.SetString("PrintDate", DateTime.Now.Date.ToString("dd-MMM-yy"));
                        HttpContext.Session.SetString("comImagePath", storeinfo != null ? storeinfo.Logo != null ? storeinfo.Logo : "" : "");
                        HttpContext.Session.SetString("weburl", resulta.ToString());


                        HttpContext.Session.SetString("OfferDiscountPer", storeinfo != null ? storeinfo.OfferDiscountPer.ToString() : "0.00");
                        HttpContext.Session.SetInt32("isDiscountOffer", storeinfo != null ? storeinfo.isDiscountOffer != false ? 1 : 0 : 0);



                        HttpContext.Session.SetString("TaxPer", storeinfo != null ? storeinfo.TaxPer.ToString() : "0.00");
                        HttpContext.Session.SetString("SalesReportStyle", storeinfo.SalesReportStyle != null ? storeinfo.SalesReportStyle.ReportStyleName : "Style1");
                        HttpContext.Session.SetString("PurchaseReportStyle", storeinfo.PurchaseReportStyle != null ? storeinfo.PurchaseReportStyle.ReportStyleName : "Style1");
                        HttpContext.Session.SetString("BarcodeReportStyle", storeinfo.BarcodeReportStyle != null ? storeinfo.BarcodeReportStyle.ReportStyleName : "Style1");


                        HttpContext.Session.SetInt32("isTaxExcluded", storeinfo != null ? storeinfo.isTaxExcluded != false ? 1 : 0 : 0);
                        HttpContext.Session.SetInt32("isMultiSelect", storeinfo != null ? storeinfo.isMultiSelect != false ? 1 : 0 : 0);
                        HttpContext.Session.SetInt32("isFixedSalesValue", storeinfo != null ? storeinfo.IsFixedSalesValue != false ? 1 : 0 : 0);
                        HttpContext.Session.SetInt32("IsFirstLetterUpperCase", storeinfo != null ? storeinfo.IsFirstLetterUpperCase != false ? 1 : 0 : 0);
                        HttpContext.Session.SetInt32("isMultiCurrency", storeinfo != null ? storeinfo.isMultiCurrency != false ? 1 : 0 : 0);
                        HttpContext.Session.SetInt32("IsTermsCondition", storeinfo != null ? storeinfo.IsTermsCondition != false ? 1 : 0 : 0);
                        HttpContext.Session.SetInt32("IsDefaultDisAmount", storeinfo != null ? storeinfo.IsDefaultDisAmount != false ? 1 : 0 : 0);
                        HttpContext.Session.SetInt32("DecimalField", storeinfo != null ? storeinfo.DecimalField : 0);

                        HttpContext.Session.SetInt32("IsFixedDiscountMainValue", storeinfo != null ? storeinfo.IsFixedDiscountMainValue != false ? 1 : 0 : 0);
                        HttpContext.Session.SetInt32("IsFixedDiscountRowValue", storeinfo != null ? storeinfo.IsFixedDiscountRowValue != false ? 1 : 0 : 0);
                        HttpContext.Session.SetString("MaxDiscountMainValue", storeinfo != null ? storeinfo.MaxDiscountMainValue.ToString() : "0.00");
                        HttpContext.Session.SetString("MaxDiscountPercentageMainValue", storeinfo != null ? storeinfo.MaxDiscountPercentageMainValue.ToString() : "0.00");
                        HttpContext.Session.SetString("MaxDiscountRowValue", storeinfo != null ? storeinfo.MaxDiscountRowValue.ToString() : "0.00");

                        HttpContext.Session.SetInt32("PrintProductName", storeinfo != null ? storeinfo.PrintProductName != false ? 1 : 0 : 0);
                        HttpContext.Session.SetInt32("PrintProductCode", storeinfo != null ? storeinfo.PrintProductCode != false ? 1 : 0 : 0);
                        HttpContext.Session.SetInt32("PrintProductDescription", storeinfo != null ? storeinfo.PrintProductDescription != false ? 1 : 0 : 0);
                        HttpContext.Session.SetInt32("PrintBrandName", storeinfo != null ? storeinfo.PrintBrandName != false ? 1 : 0 : 0);
                        HttpContext.Session.SetInt32("PrintModelName", storeinfo != null ? storeinfo.PrintModelName != false ? 1 : 0 : 0);
                        HttpContext.Session.SetInt32("PrintSizeName", storeinfo != null ? storeinfo.PrintSizeName != false ? 1 : 0 : 0);
                        HttpContext.Session.SetInt32("VisibleSalesCommission", storeinfo != null ? storeinfo.VisibleSalesCommission != false ? 1 : 0 : 0);

                        //HttpContext.Session.SetString("isFixedSalesValue", storeinfo.IsFixedSalesValue.ToString());




                        HttpContext.Session.SetString("isMultiDebitCredit", storeinfo.isMultiDebitCredit.ToString());
                        //HttpContext.Session.SetString("isMultiCurrency", company.isMultiCurrency.ToString());

                        HttpContext.Session.SetString("isVoucherDistributionEntry", storeinfo.isVoucherDistributionEntry.ToString());
                        HttpContext.Session.SetString("isChequeDetails", storeinfo.isChequeDetails.ToString());

                        HttpContext.Session.SetString("isSMSService", storeinfo.isSMSService.ToString());
                        HttpContext.Session.SetString("isEmailSerivce", storeinfo.isEmailSerivce.ToString());

                        HttpContext.Session.SetInt32("defaultcurrencyid", storeinfo.CountryId);
                        HttpContext.Session.SetString("defaultcurrencyname", storeinfo.Currency.CurrencyShortName.ToString());
                        HttpContext.Session.SetInt32("TimeZoneSettingsId", storeinfo.TimeZones != null ? storeinfo.TimeZoneSettingsId : 36);
                        HttpContext.Session.SetString("TimeZoneSettingsName", storeinfo != null ? storeinfo.TimeZones.TimeZoneName : "");
                        HttpContext.Session.SetString("TimeZoneSettingsNameJquery", storeinfo.TimeZones != null ? storeinfo.TimeZones.TimeZoneNameJquery : "");

                        var countryinfo = _countryRepository.All().Where(x => x.Id == storeinfo.CountryId).FirstOrDefault();
                        var countryinfoViewFormat = _countryRepository.All().Where(x => x.Id == 231).FirstOrDefault();



                        HttpContext.Session.SetString("CurrencyShortNameViewFormat", countryinfoViewFormat.CurrencyShortName);
                        HttpContext.Session.SetString("CultureInfoViewFormat", countryinfoViewFormat.CultureInfo);
                        HttpContext.Session.SetString("CountryShortNameViewFormat", countryinfoViewFormat.CountryShortName);
                        HttpContext.Session.SetString("CurrencySymbolViewFormat", countryinfoViewFormat.CurrencySymbol);


                        HttpContext.Session.SetString("CurrencyShortName", countryinfo.CurrencyShortName);
                        HttpContext.Session.SetString("CultureInfo", countryinfo.CultureInfo);
                        HttpContext.Session.SetString("CountryShortName", countryinfo.CountryShortName);
                        HttpContext.Session.SetString("CurrencySymbol", countryinfo.CurrencySymbol);


                        await HttpContext.SignInAsync(principal);



                        HttpContext.Session.SetString("Latitude", "");
                        HttpContext.Session.SetString("Longitude", "");


                        LogRepository.SuccessLogin(HttpContext.Session.GetString("Latitude"), HttpContext.Session.GetString("Longitude"), "Success");


                        return RedirectToAction("CustomerDashboard", "Admin");

                    }
                    else
                    {
                        HttpContext.Session.SetString("Latitude", "=N/A=");
                        HttpContext.Session.SetString("Longitude", "=N/A=");
                        HttpContext.Session.SetString("UserInfo", user.Email + " " + user.Password);

                        LogRepository.SuccessLogin(HttpContext.Session.GetString("Latitude"), HttpContext.Session.GetString("Longitude"), "Failure");

                        TempData["UserLoginFailed"] = "Login Failed.Please enter correct credentials";
                        return View();
                    }
                }
                else
                    return View(user);

                #endregion
            }
            else if (user.CredentialType == "S")
            {
                #region SupplierLogin
                #region weburlinfo
                var weburl = Request.GetTypedHeaders().Referer.ToString().ToLower();//.Replace("/Home/Login".ToLower(), "");
                var weburlquerystring = Request.QueryString.HasValue == true ? Request.QueryString.ToString() : "";// Request.QueryString == null ? "": Request.QueryString;// Request.QueryString?? Request.QueryString;//.Replace("/Home/Login".ToLower(), "");

                var origin = weburl.ToLower();
                var controllerName = this.ControllerContext.RouteData.Values["Controller"].ToString().ToLower();


                string St = weburl.ToLower();
                int pFrom = St.IndexOf("/?");

                if (pFrom > 0)
                {
                    var filterurl = St.Substring(0, pFrom);
                    origin = filterurl;
                }
                string resulta = "";


                if (weburlquerystring.Length > 2)
                {
                    resulta = origin.Replace(weburlquerystring, "").Replace("/Home/Login".ToLower(), "");

                }
                else
                {
                    resulta = origin.Replace("/Home/Login".ToLower(), "");

                }

                #endregion



                if (ModelState.IsValid)
                {
                    SupplierModel abc = new SupplierModel();
                    abc.LoginId = user.Email;
                    abc.Password = user.Password;


                    //bool result = userAccountRepository.ValidateUser(user);
                    bool result = _supplierRepository.ValidateSupplier(abc);


                    var supplierdata = _supplierRepository.All(false).Include(x => x.UserAccountList).Where(x => x.LoginId == user.Email && x.Password == user.Password).FirstOrDefault();


                    if (result)
                    {
                        Atrai.Model.AppData.DefaultConnectionString = Config.GetConnectionString("DefaultConnection");

                        int ComId = supplierdata.ComId;

                        //var UserIdabc = userAccountRepository.All().Where(x => x.EmployeeId == supplierdata.SalesRepresentativeId).FirstOrDefault().Id; //  supplierdata.SalesRepresentative.LinkedUserAccount.FirstOrDefault().Id;
                        int UserId = 0;


                        HttpContext.Session.SetInt32("IsMobile", 0);
                        HttpContext.Session.SetInt32("UserId", supplierdata.LuserId);
                        HttpContext.Session.SetInt32("SupplierId", supplierdata.Id);
                        HttpContext.Session.SetInt32("ComId", supplierdata.ComId);



                        string ComName = companyRepository.GetComName(ComId);
                        HttpContext.Session.SetString("ComName", ComName);

                        HttpContext.Session.SetString("UserInfo", user.Email);
                        HttpContext.Session.SetString("SearchType", "Scanner");



                        var userdata = userAccountRepository.All().Include(x => x.UserRole).Include(x => x.EmployeeList).Where(x => x.Id == UserId).FirstOrDefault();
                        var claims = new List<Claim>
                    {
                        new Claim(ClaimTypes.Name, user.Email)
                    };
                        var _claim = new Claim("Role", "Supplier"); //userdata.UserRole.RoleName
                        claims.Add(_claim);
                        ClaimsIdentity userIdentity = new ClaimsIdentity(claims, "login");
                        ClaimsPrincipal principal = new ClaimsPrincipal(userIdentity);

                        //applicat

                        //HttpContext.Session.SetInt32("UserRoleId", userdata.UserRoleId ?? 0);
                        //HttpContext.Session.SetString("UserRole", userdata.UserRole.RoleName ?? "");
                        //HttpContext.Session.SetString("EmpImagePath", userdata.EmployeeList?.EmployeeImagePath ?? "");







                        var company = companyRepository.All().Where(x => x.Id == ComId).Include(x => x.BusinessType).FirstOrDefault();
                        var storeinfo = storeSettingRepository.All().Where(x => x.ComId == ComId)
                            .Include(x => x.SalesReportStyle)
                            .Include(x => x.PurchaseReportStyle)
                            .Include(x => x.BarcodeReportStyle)
                            .Include(x => x.Currency)
                                                .Include(x => x.TimeZones)
                            .FirstOrDefault();



                        HttpContext.Session.SetInt32("BaseComId", storeinfo.BaseComId);

                        HttpContext.Session.SetInt32("BusinessTypeId", company.BusinessTypeId);
                        HttpContext.Session.SetString("BusinessType", company.BusinessType.BusinessTypeName);
                        HttpContext.Session.SetString("AppsName", company.BusinessType.AppsName);


                        HttpContext.Session.SetString("CompanyName", company.CompanyName != null ? company.CompanyName : "");
                        HttpContext.Session.SetString("PrimaryAddress", company.PrimaryAddress != null ? company.PrimaryAddress : "");
                        HttpContext.Session.SetString("SecoundaryAddress", company.SecoundaryAddress != null ? company.SecoundaryAddress : "");
                        HttpContext.Session.SetString("comPhone", company.comPhone != null ? company.comPhone : "");
                        HttpContext.Session.SetString("comWeb", company.comWeb != null ? company.comWeb : "");
                        HttpContext.Session.SetString("comEmail", company.comEmail != null ? company.comEmail : "");
                        HttpContext.Session.SetString("CaptionOne", "CaptionOne");
                        HttpContext.Session.SetString("CaptionTwo", "CaptionTwo");
                        HttpContext.Session.SetString("PrintDate", DateTime.Now.Date.ToString("dd-MMM-yy"));
                        HttpContext.Session.SetString("comImagePath", storeinfo != null ? storeinfo.Logo != null ? storeinfo.Logo : "" : "");
                        HttpContext.Session.SetString("weburl", resulta.ToString());


                        HttpContext.Session.SetString("OfferDiscountPer", storeinfo != null ? storeinfo.OfferDiscountPer.ToString() : "0.00");
                        HttpContext.Session.SetInt32("isDiscountOffer", storeinfo != null ? storeinfo.isDiscountOffer != false ? 1 : 0 : 0);

                        HttpContext.Session.SetString("TaxPer", storeinfo != null ? storeinfo.TaxPer.ToString() : "0.00");
                        HttpContext.Session.SetString("SalesReportStyle", storeinfo.SalesReportStyle != null ? storeinfo.SalesReportStyle.ReportStyleName : "Style1");
                        HttpContext.Session.SetString("PurchaseReportStyle", storeinfo.PurchaseReportStyle != null ? storeinfo.PurchaseReportStyle.ReportStyleName : "Style1");
                        HttpContext.Session.SetString("BarcodeReportStyle", storeinfo.BarcodeReportStyle != null ? storeinfo.BarcodeReportStyle.ReportStyleName : "Style1");


                        HttpContext.Session.SetInt32("isTaxExcluded", storeinfo != null ? storeinfo.isTaxExcluded != false ? 1 : 0 : 0);
                        HttpContext.Session.SetInt32("isMultiSelect", storeinfo != null ? storeinfo.isMultiSelect != false ? 1 : 0 : 0);
                        HttpContext.Session.SetInt32("isFixedSalesValue", storeinfo != null ? storeinfo.IsFixedSalesValue != false ? 1 : 0 : 0);
                        HttpContext.Session.SetInt32("IsFirstLetterUpperCase", storeinfo != null ? storeinfo.IsFirstLetterUpperCase != false ? 1 : 0 : 0);
                        HttpContext.Session.SetInt32("isMultiCurrency", storeinfo != null ? storeinfo.isMultiCurrency != false ? 1 : 0 : 0);
                        HttpContext.Session.SetInt32("IsTermsCondition", storeinfo != null ? storeinfo.IsTermsCondition != false ? 1 : 0 : 0);
                        HttpContext.Session.SetInt32("IsDefaultDisAmount", storeinfo != null ? storeinfo.IsDefaultDisAmount != false ? 1 : 0 : 0);
                        HttpContext.Session.SetInt32("DecimalField", storeinfo != null ? storeinfo.DecimalField : 0);

                        HttpContext.Session.SetInt32("IsFixedDiscountMainValue", storeinfo != null ? storeinfo.IsFixedDiscountMainValue != false ? 1 : 0 : 0);
                        HttpContext.Session.SetInt32("IsFixedDiscountRowValue", storeinfo != null ? storeinfo.IsFixedDiscountRowValue != false ? 1 : 0 : 0);
                        HttpContext.Session.SetString("MaxDiscountMainValue", storeinfo != null ? storeinfo.MaxDiscountMainValue.ToString() : "0.00");
                        HttpContext.Session.SetString("MaxDiscountPercentageMainValue", storeinfo != null ? storeinfo.MaxDiscountPercentageMainValue.ToString() : "0.00");
                        HttpContext.Session.SetString("MaxDiscountRowValue", storeinfo != null ? storeinfo.MaxDiscountRowValue.ToString() : "0.00");

                        HttpContext.Session.SetInt32("PrintProductName", storeinfo != null ? storeinfo.PrintProductName != false ? 1 : 0 : 0);
                        HttpContext.Session.SetInt32("PrintProductCode", storeinfo != null ? storeinfo.PrintProductCode != false ? 1 : 0 : 0);
                        HttpContext.Session.SetInt32("PrintProductDescription", storeinfo != null ? storeinfo.PrintProductDescription != false ? 1 : 0 : 0);
                        HttpContext.Session.SetInt32("PrintBrandName", storeinfo != null ? storeinfo.PrintBrandName != false ? 1 : 0 : 0);
                        HttpContext.Session.SetInt32("PrintModelName", storeinfo != null ? storeinfo.PrintModelName != false ? 1 : 0 : 0);
                        HttpContext.Session.SetInt32("PrintSizeName", storeinfo != null ? storeinfo.PrintSizeName != false ? 1 : 0 : 0);
                        HttpContext.Session.SetInt32("VisibleSalesCommission", storeinfo != null ? storeinfo.VisibleSalesCommission != false ? 1 : 0 : 0);

                        //HttpContext.Session.SetString("isFixedSalesValue", storeinfo.IsFixedSalesValue.ToString());




                        HttpContext.Session.SetString("isMultiDebitCredit", storeinfo.isMultiDebitCredit.ToString());
                        //HttpContext.Session.SetString("isMultiCurrency", company.isMultiCurrency.ToString());

                        HttpContext.Session.SetString("isVoucherDistributionEntry", storeinfo.isVoucherDistributionEntry.ToString());
                        HttpContext.Session.SetString("isChequeDetails", storeinfo.isChequeDetails.ToString());

                        HttpContext.Session.SetString("isSMSService", storeinfo.isSMSService.ToString());
                        HttpContext.Session.SetString("isEmailSerivce", storeinfo.isEmailSerivce.ToString());

                        HttpContext.Session.SetInt32("defaultcurrencyid", storeinfo.CountryId);
                        HttpContext.Session.SetString("defaultcurrencyname", storeinfo.Currency.CurrencyShortName.ToString());
                        HttpContext.Session.SetInt32("TimeZoneSettingsId", storeinfo.TimeZones != null ? storeinfo.TimeZoneSettingsId : 36);
                        HttpContext.Session.SetString("TimeZoneSettingsName", storeinfo != null ? storeinfo.TimeZones.TimeZoneName : "");
                        HttpContext.Session.SetString("TimeZoneSettingsNameJquery", storeinfo.TimeZones != null ? storeinfo.TimeZones.TimeZoneNameJquery : "");

                        var countryinfo = _countryRepository.All().Where(x => x.Id == storeinfo.CountryId).FirstOrDefault();
                        var countryinfoViewFormat = _countryRepository.All().Where(x => x.Id == 231).FirstOrDefault();



                        HttpContext.Session.SetString("CurrencyShortNameViewFormat", countryinfoViewFormat.CurrencyShortName);
                        HttpContext.Session.SetString("CultureInfoViewFormat", countryinfoViewFormat.CultureInfo);
                        HttpContext.Session.SetString("CountryShortNameViewFormat", countryinfoViewFormat.CountryShortName);
                        HttpContext.Session.SetString("CurrencySymbolViewFormat", countryinfoViewFormat.CurrencySymbol);


                        HttpContext.Session.SetString("CurrencyShortName", countryinfo.CurrencyShortName);
                        HttpContext.Session.SetString("CultureInfo", countryinfo.CultureInfo);
                        HttpContext.Session.SetString("CountryShortName", countryinfo.CountryShortName);
                        HttpContext.Session.SetString("CurrencySymbol", countryinfo.CurrencySymbol);


                        await HttpContext.SignInAsync(principal);



                        HttpContext.Session.SetString("Latitude", "");
                        HttpContext.Session.SetString("Longitude", "");


                        LogRepository.SuccessLogin(HttpContext.Session.GetString("Latitude"), HttpContext.Session.GetString("Longitude"), "Success");


                        return RedirectToAction("SupplierDashboard", "Admin");

                    }
                    else
                    {
                        HttpContext.Session.SetString("Latitude", "=N/A=");
                        HttpContext.Session.SetString("Longitude", "=N/A=");
                        HttpContext.Session.SetString("UserInfo", user.Email + " " + user.Password);

                        LogRepository.SuccessLogin(HttpContext.Session.GetString("Latitude"), HttpContext.Session.GetString("Longitude"), "Failure");

                        TempData["UserLoginFailed"] = "Login Failed.Please enter correct credentials";
                        return View();
                    }
                }
                else
                    return View(user);

                #endregion
            }
            else
            {
                return View();
            }


        }



        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CustomerLogin(CustomerLoginViewModel customer)
        {

            #region CustomerLogin

            #region weburlinfo
            var weburl = Request.GetTypedHeaders().Referer.ToString().ToLower();//.Replace("/Home/Login".ToLower(), "");
            var weburlquerystring = Request.QueryString.HasValue == true ? Request.QueryString.ToString() : "";// Request.QueryString == null ? "": Request.QueryString;// Request.QueryString?? Request.QueryString;//.Replace("/Home/Login".ToLower(), "");

            var origin = weburl.ToLower();
            var controllerName = this.ControllerContext.RouteData.Values["Controller"].ToString().ToLower();


            string St = weburl.ToLower();
            int pFrom = St.IndexOf("/?");

            if (pFrom > 0)
            {
                var filterurl = St.Substring(0, pFrom);
                origin = filterurl;
            }
            string resulta = "";


            if (weburlquerystring.Length > 2)
            {
                resulta = origin.Replace(weburlquerystring, "").Replace("/Home/Login".ToLower(), "");

            }
            else
            {
                resulta = origin.Replace("/Home/Login".ToLower(), "");

            }

            #endregion



            if (ModelState.IsValid)
            {
                CustomerModel abc = new CustomerModel();
                abc.LoginId = customer.PhoneNo;
                abc.Password = customer.Password;


                //bool result = userAccountRepository.ValidateUser(user);
                bool result = _customerRepository.ValidateCustomer(abc);


                var customerdata = _customerRepository.All(false).Include(x => x.SalesRepresentative).Include(x => x.UserAccountList).Where(x => x.LoginId == customer.PhoneNo && x.Password == customer.Password).FirstOrDefault();


                if (result)
                {
                    Atrai.Model.AppData.DefaultConnectionString = Config.GetConnectionString("DefaultConnection");

                    int ComId = customerdata.ComId;

                    //var UserIdabc = userAccountRepository.All().Where(x => x.EmployeeId == customerdata.SalesRepresentativeId).FirstOrDefault().Id; //  customerdata.SalesRepresentative.LinkedUserAccount.FirstOrDefault().Id;
                    int UserId = 0;


                    HttpContext.Session.SetInt32("IsMobile", 0);
                    HttpContext.Session.SetInt32("UserId", customerdata.LuserId);
                    HttpContext.Session.SetInt32("CustomerId", customerdata.Id);
                    HttpContext.Session.SetInt32("ComId", customerdata.ComId);



                    string ComName = companyRepository.GetComName(ComId);
                    HttpContext.Session.SetString("ComName", ComName);

                    HttpContext.Session.SetString("UserInfo", customer.PhoneNo);
                    HttpContext.Session.SetString("SearchType", "Scanner");



                    var userdata = userAccountRepository.All().Include(x => x.UserRole).Include(x => x.EmployeeList).Where(x => x.Id == UserId).FirstOrDefault();
                    var claims = new List<Claim>
                    {
                        new Claim(ClaimTypes.Name, customer.PhoneNo )
                    };
                    var _claim = new Claim("Role", "Customer"); //userdata.UserRole.RoleName
                    claims.Add(_claim);
                    ClaimsIdentity userIdentity = new ClaimsIdentity(claims, "login");
                    ClaimsPrincipal principal = new ClaimsPrincipal(userIdentity);

                    //applicat

                    //HttpContext.Session.SetInt32("UserRoleId", userdata.UserRoleId ?? 0);
                    //HttpContext.Session.SetString("UserRole", userdata.UserRole.RoleName ?? "");
                    //HttpContext.Session.SetString("EmpImagePath", userdata.EmployeeList?.EmployeeImagePath ?? "");







                    var company = companyRepository.All().Where(x => x.Id == ComId).Include(x => x.BusinessType).FirstOrDefault();
                    var storeinfo = storeSettingRepository.All().Where(x => x.ComId == ComId)
                               .Include(x => x.SalesReportStyle)
                               .Include(x => x.PurchaseReportStyle)
                               .Include(x => x.BarcodeReportStyle)
                                                   .Include(x => x.TimeZones)
                                                   .Include(x => x.Currency)
                               .FirstOrDefault();



                    HttpContext.Session.SetInt32("BaseComId", storeinfo.BaseComId);

                    HttpContext.Session.SetInt32("BusinessTypeId", company.BusinessTypeId);
                    HttpContext.Session.SetString("BusinessType", company.BusinessType.BusinessTypeName);
                    HttpContext.Session.SetString("AppsName", company.BusinessType.AppsName);


                    HttpContext.Session.SetString("CompanyName", company.CompanyName != null ? company.CompanyName : "");
                    HttpContext.Session.SetString("PrimaryAddress", company.PrimaryAddress != null ? company.PrimaryAddress : "");
                    HttpContext.Session.SetString("SecoundaryAddress", company.SecoundaryAddress != null ? company.SecoundaryAddress : "");
                    HttpContext.Session.SetString("comPhone", company.comPhone != null ? company.comPhone : "");
                    HttpContext.Session.SetString("comWeb", company.comWeb != null ? company.comWeb : "");
                    HttpContext.Session.SetString("comEmail", company.comEmail != null ? company.comEmail : "");
                    HttpContext.Session.SetString("CaptionOne", "CaptionOne");
                    HttpContext.Session.SetString("CaptionTwo", "CaptionTwo");
                    HttpContext.Session.SetString("PrintDate", DateTime.Now.Date.ToString("dd-MMM-yy"));
                    HttpContext.Session.SetString("comImagePath", storeinfo != null ? storeinfo.Logo != null ? storeinfo.Logo : "" : "");
                    HttpContext.Session.SetString("weburl", resulta.ToString());

                    HttpContext.Session.SetString("OfferDiscountPer", storeinfo != null ? storeinfo.OfferDiscountPer.ToString() : "0.00");
                    HttpContext.Session.SetInt32("isDiscountOffer", storeinfo != null ? storeinfo.isDiscountOffer != false ? 1 : 0 : 0);

                    HttpContext.Session.SetString("TaxPer", storeinfo != null ? storeinfo.TaxPer.ToString() : "0.00");
                    HttpContext.Session.SetString("SalesReportStyle", storeinfo.SalesReportStyle != null ? storeinfo.SalesReportStyle.ReportStyleName : "Style1");
                    HttpContext.Session.SetString("PurchaseReportStyle", storeinfo.PurchaseReportStyle != null ? storeinfo.PurchaseReportStyle.ReportStyleName : "Style1");
                    HttpContext.Session.SetString("BarcodeReportStyle", storeinfo.BarcodeReportStyle != null ? storeinfo.BarcodeReportStyle.ReportStyleName : "Style1");


                    HttpContext.Session.SetInt32("isTaxExcluded", storeinfo != null ? storeinfo.isTaxExcluded != false ? 1 : 0 : 0);
                    HttpContext.Session.SetInt32("isMultiSelect", storeinfo != null ? storeinfo.isMultiSelect != false ? 1 : 0 : 0);
                    HttpContext.Session.SetInt32("isFixedSalesValue", storeinfo != null ? storeinfo.IsFixedSalesValue != false ? 1 : 0 : 0);
                    HttpContext.Session.SetInt32("IsFirstLetterUpperCase", storeinfo != null ? storeinfo.IsFirstLetterUpperCase != false ? 1 : 0 : 0);
                    HttpContext.Session.SetInt32("isMultiCurrency", storeinfo != null ? storeinfo.isMultiCurrency != false ? 1 : 0 : 0);
                    HttpContext.Session.SetInt32("IsTermsCondition", storeinfo != null ? storeinfo.IsTermsCondition != false ? 1 : 0 : 0);
                    HttpContext.Session.SetInt32("IsDefaultDisAmount", storeinfo != null ? storeinfo.IsDefaultDisAmount != false ? 1 : 0 : 0);
                    HttpContext.Session.SetInt32("DecimalField", storeinfo != null ? storeinfo.DecimalField : 0);

                    HttpContext.Session.SetInt32("IsFixedDiscountMainValue", storeinfo != null ? storeinfo.IsFixedDiscountMainValue != false ? 1 : 0 : 0);
                    HttpContext.Session.SetInt32("IsFixedDiscountRowValue", storeinfo != null ? storeinfo.IsFixedDiscountRowValue != false ? 1 : 0 : 0);
                    HttpContext.Session.SetString("MaxDiscountMainValue", storeinfo != null ? storeinfo.MaxDiscountMainValue.ToString() : "0.00");
                    HttpContext.Session.SetString("MaxDiscountPercentageMainValue", storeinfo != null ? storeinfo.MaxDiscountPercentageMainValue.ToString() : "0.00");
                    HttpContext.Session.SetString("MaxDiscountRowValue", storeinfo != null ? storeinfo.MaxDiscountRowValue.ToString() : "0.00");

                    HttpContext.Session.SetInt32("PrintProductName", storeinfo != null ? storeinfo.PrintProductName != false ? 1 : 0 : 0);
                    HttpContext.Session.SetInt32("PrintProductCode", storeinfo != null ? storeinfo.PrintProductCode != false ? 1 : 0 : 0);
                    HttpContext.Session.SetInt32("PrintProductDescription", storeinfo != null ? storeinfo.PrintProductDescription != false ? 1 : 0 : 0);
                    HttpContext.Session.SetInt32("PrintBrandName", storeinfo != null ? storeinfo.PrintBrandName != false ? 1 : 0 : 0);
                    HttpContext.Session.SetInt32("PrintModelName", storeinfo != null ? storeinfo.PrintModelName != false ? 1 : 0 : 0);
                    HttpContext.Session.SetInt32("PrintSizeName", storeinfo != null ? storeinfo.PrintSizeName != false ? 1 : 0 : 0);
                    HttpContext.Session.SetInt32("VisibleSalesCommission", storeinfo != null ? storeinfo.VisibleSalesCommission != false ? 1 : 0 : 0);

                    //HttpContext.Session.SetString("isFixedSalesValue", storeinfo.IsFixedSalesValue.ToString());




                    HttpContext.Session.SetString("isMultiDebitCredit", storeinfo.isMultiDebitCredit.ToString());
                    //HttpContext.Session.SetString("isMultiCurrency", company.isMultiCurrency.ToString());

                    HttpContext.Session.SetString("isVoucherDistributionEntry", storeinfo.isVoucherDistributionEntry.ToString());
                    HttpContext.Session.SetString("isChequeDetails", storeinfo.isChequeDetails.ToString());

                    HttpContext.Session.SetString("isSMSService", storeinfo.isSMSService.ToString());
                    HttpContext.Session.SetString("isEmailSerivce", storeinfo.isEmailSerivce.ToString());

                    HttpContext.Session.SetInt32("defaultcurrencyid", storeinfo.CountryId);
                    HttpContext.Session.SetString("defaultcurrencyname", storeinfo.Currency.CurrencyShortName.ToString());
                    //HttpContext.Session.SetInt32("TimeZoneSettingsId", storeinfo != null ? storeinfo.TimeZoneSettingsId.GetValueOrDefault() : 0);
                    HttpContext.Session.SetInt32("TimeZoneSettingsId", storeinfo.TimeZones != null ? storeinfo.TimeZoneSettingsId : 36);

                    HttpContext.Session.SetString("TimeZoneSettingsName", storeinfo != null ? storeinfo.TimeZones.TimeZoneName : "");
                    HttpContext.Session.SetString("TimeZoneSettingsNameJquery", storeinfo.TimeZones != null ? storeinfo.TimeZones.TimeZoneNameJquery : "");

                    var countryinfo = _countryRepository.All().Where(x => x.Id == storeinfo.CountryId).FirstOrDefault();
                    var countryinfoViewFormat = _countryRepository.All().Where(x => x.Id == 231).FirstOrDefault();



                    HttpContext.Session.SetString("CurrencyShortNameViewFormat", countryinfoViewFormat.CurrencyShortName);
                    HttpContext.Session.SetString("CultureInfoViewFormat", countryinfoViewFormat.CultureInfo);
                    HttpContext.Session.SetString("CountryShortNameViewFormat", countryinfoViewFormat.CountryShortName);
                    HttpContext.Session.SetString("CurrencySymbolViewFormat", countryinfoViewFormat.CurrencySymbol);


                    HttpContext.Session.SetString("CurrencyShortName", countryinfo.CurrencyShortName);
                    HttpContext.Session.SetString("CultureInfo", countryinfo.CultureInfo);
                    HttpContext.Session.SetString("CountryShortName", countryinfo.CountryShortName);
                    HttpContext.Session.SetString("CurrencySymbol", countryinfo.CurrencySymbol);


                    await HttpContext.SignInAsync(principal);



                    HttpContext.Session.SetString("Latitude", "");
                    HttpContext.Session.SetString("Longitude", "");


                    LogRepository.SuccessLogin(HttpContext.Session.GetString("Latitude"), HttpContext.Session.GetString("Longitude"), "Success");


                    return RedirectToAction("CustomerDashboard", "Admin");

                }
                else
                {
                    HttpContext.Session.SetString("Latitude", "=N/A=");
                    HttpContext.Session.SetString("Longitude", "=N/A=");
                    HttpContext.Session.SetString("UserInfo", customer.PhoneNo + " " + customer.Password);

                    LogRepository.SuccessLogin(HttpContext.Session.GetString("Latitude"), HttpContext.Session.GetString("Longitude"), "Failure");

                    TempData["UserLoginFailed"] = "Login Failed.Please enter correct credentials";
                    return View();
                }
            }
            else
                return View(customer);

            #endregion
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> SupplierLogin(SupplierLoginViewModel supplier)
        {

            #region SupplierLogin
            #region weburlinfo
            var weburl = Request.GetTypedHeaders().Referer.ToString().ToLower();//.Replace("/Home/Login".ToLower(), "");
            var weburlquerystring = Request.QueryString.HasValue == true ? Request.QueryString.ToString() : "";// Request.QueryString == null ? "": Request.QueryString;// Request.QueryString?? Request.QueryString;//.Replace("/Home/Login".ToLower(), "");

            var origin = weburl.ToLower();
            var controllerName = this.ControllerContext.RouteData.Values["Controller"].ToString().ToLower();


            string St = weburl.ToLower();
            int pFrom = St.IndexOf("/?");

            if (pFrom > 0)
            {
                var filterurl = St.Substring(0, pFrom);
                origin = filterurl;
            }
            string resulta = "";


            if (weburlquerystring.Length > 2)
            {
                resulta = origin.Replace(weburlquerystring, "").Replace("/Home/Login".ToLower(), "");

            }
            else
            {
                resulta = origin.Replace("/Home/Login".ToLower(), "");

            }

            #endregion



            if (ModelState.IsValid)
            {
                SupplierModel abc = new SupplierModel();
                abc.LoginId = supplier.PhoneNo;
                abc.Password = supplier.Password;


                //bool result = userAccountRepository.ValidateUser(user);
                bool result = _supplierRepository.ValidateSupplier(abc);


                var supplierdata = _supplierRepository.All(false).Include(x => x.UserAccountList).Where(x => x.LoginId == supplier.PhoneNo && x.Password == supplier.Password).FirstOrDefault();


                if (result)
                {
                    Atrai.Model.AppData.DefaultConnectionString = Config.GetConnectionString("DefaultConnection");

                    int ComId = supplierdata.ComId;

                    //var UserIdabc = userAccountRepository.All().Where(x => x.EmployeeId == supplierdata.SalesRepresentativeId).FirstOrDefault().Id; //  supplierdata.SalesRepresentative.LinkedUserAccount.FirstOrDefault().Id;
                    int UserId = 0;


                    HttpContext.Session.SetInt32("IsMobile", 0);
                    HttpContext.Session.SetInt32("UserId", supplierdata.LuserId);
                    HttpContext.Session.SetInt32("SupplierId", supplierdata.Id);
                    HttpContext.Session.SetInt32("ComId", supplierdata.ComId);



                    string ComName = companyRepository.GetComName(ComId);
                    HttpContext.Session.SetString("ComName", ComName);

                    HttpContext.Session.SetString("UserInfo", supplier.PhoneNo);
                    HttpContext.Session.SetString("SearchType", "Scanner");



                    var userdata = userAccountRepository.All().Include(x => x.UserRole).Include(x => x.EmployeeList).Where(x => x.Id == UserId).FirstOrDefault();
                    var claims = new List<Claim>
                    {
                        new Claim(ClaimTypes.Name, supplier.PhoneNo )
                    };
                    var _claim = new Claim("Role", "Supplier"); //userdata.UserRole.RoleName
                    claims.Add(_claim);
                    ClaimsIdentity userIdentity = new ClaimsIdentity(claims, "login");
                    ClaimsPrincipal principal = new ClaimsPrincipal(userIdentity);

                    //applicat

                    //HttpContext.Session.SetInt32("UserRoleId", userdata.UserRoleId ?? 0);
                    //HttpContext.Session.SetString("UserRole", userdata.UserRole.RoleName ?? "");
                    //HttpContext.Session.SetString("EmpImagePath", userdata.EmployeeList?.EmployeeImagePath ?? "");







                    var company = companyRepository.All().Where(x => x.Id == ComId).Include(x => x.BusinessType).FirstOrDefault();
                    var storeinfo = storeSettingRepository.All().Where(x => x.ComId == ComId)
                            .Include(x => x.SalesReportStyle)
                            .Include(x => x.PurchaseReportStyle)
                            .Include(x => x.BarcodeReportStyle)
                                                .Include(x => x.TimeZones)
                                                .Include(x => x.Currency)
                                                .FirstOrDefault();



                    HttpContext.Session.SetInt32("BaseComId", storeinfo.BaseComId);

                    HttpContext.Session.SetInt32("BusinessTypeId", company.BusinessTypeId);
                    HttpContext.Session.SetString("BusinessType", company.BusinessType.BusinessTypeName);
                    HttpContext.Session.SetString("AppsName", company.BusinessType.AppsName);


                    HttpContext.Session.SetString("CompanyName", company.CompanyName != null ? company.CompanyName : "");
                    HttpContext.Session.SetString("PrimaryAddress", company.PrimaryAddress != null ? company.PrimaryAddress : "");
                    HttpContext.Session.SetString("SecoundaryAddress", company.SecoundaryAddress != null ? company.SecoundaryAddress : "");
                    HttpContext.Session.SetString("comPhone", company.comPhone != null ? company.comPhone : "");
                    HttpContext.Session.SetString("comWeb", company.comWeb != null ? company.comWeb : "");
                    HttpContext.Session.SetString("comEmail", company.comEmail != null ? company.comEmail : "");
                    HttpContext.Session.SetString("CaptionOne", "CaptionOne");
                    HttpContext.Session.SetString("CaptionTwo", "CaptionTwo");
                    HttpContext.Session.SetString("PrintDate", DateTime.Now.Date.ToString("dd-MMM-yy"));
                    HttpContext.Session.SetString("comImagePath", storeinfo != null ? storeinfo.Logo != null ? storeinfo.Logo : "" : "");
                    HttpContext.Session.SetString("weburl", resulta.ToString());

                    HttpContext.Session.SetString("OfferDiscountPer", storeinfo != null ? storeinfo.OfferDiscountPer.ToString() : "0.00");
                    HttpContext.Session.SetInt32("isDiscountOffer", storeinfo != null ? storeinfo.isDiscountOffer != false ? 1 : 0 : 0);

                    HttpContext.Session.SetString("TaxPer", storeinfo != null ? storeinfo.TaxPer.ToString() : "0.00");
                    HttpContext.Session.SetString("SalesReportStyle", storeinfo.SalesReportStyle != null ? storeinfo.SalesReportStyle.ReportStyleName : "Style1");
                    HttpContext.Session.SetString("PurchaseReportStyle", storeinfo.PurchaseReportStyle != null ? storeinfo.PurchaseReportStyle.ReportStyleName : "Style1");
                    HttpContext.Session.SetString("BarcodeReportStyle", storeinfo.BarcodeReportStyle != null ? storeinfo.BarcodeReportStyle.ReportStyleName : "Style1");


                    HttpContext.Session.SetInt32("isTaxExcluded", storeinfo != null ? storeinfo.isTaxExcluded != false ? 1 : 0 : 0);
                    HttpContext.Session.SetInt32("isMultiSelect", storeinfo != null ? storeinfo.isMultiSelect != false ? 1 : 0 : 0);
                    HttpContext.Session.SetInt32("isFixedSalesValue", storeinfo != null ? storeinfo.IsFixedSalesValue != false ? 1 : 0 : 0);
                    HttpContext.Session.SetInt32("IsFirstLetterUpperCase", storeinfo != null ? storeinfo.IsFirstLetterUpperCase != false ? 1 : 0 : 0);
                    HttpContext.Session.SetInt32("isMultiCurrency", storeinfo != null ? storeinfo.isMultiCurrency != false ? 1 : 0 : 0);
                    HttpContext.Session.SetInt32("IsTermsCondition", storeinfo != null ? storeinfo.IsTermsCondition != false ? 1 : 0 : 0);
                    HttpContext.Session.SetInt32("IsDefaultDisAmount", storeinfo != null ? storeinfo.IsDefaultDisAmount != false ? 1 : 0 : 0);
                    HttpContext.Session.SetInt32("DecimalField", storeinfo != null ? storeinfo.DecimalField : 0);

                    HttpContext.Session.SetInt32("IsFixedDiscountMainValue", storeinfo != null ? storeinfo.IsFixedDiscountMainValue != false ? 1 : 0 : 0);
                    HttpContext.Session.SetInt32("IsFixedDiscountRowValue", storeinfo != null ? storeinfo.IsFixedDiscountRowValue != false ? 1 : 0 : 0);
                    HttpContext.Session.SetString("MaxDiscountMainValue", storeinfo != null ? storeinfo.MaxDiscountMainValue.ToString() : "0.00");
                    HttpContext.Session.SetString("MaxDiscountPercentageMainValue", storeinfo != null ? storeinfo.MaxDiscountPercentageMainValue.ToString() : "0.00");
                    HttpContext.Session.SetString("MaxDiscountRowValue", storeinfo != null ? storeinfo.MaxDiscountRowValue.ToString() : "0.00");

                    HttpContext.Session.SetInt32("PrintProductName", storeinfo != null ? storeinfo.PrintProductName != false ? 1 : 0 : 0);
                    HttpContext.Session.SetInt32("PrintProductCode", storeinfo != null ? storeinfo.PrintProductCode != false ? 1 : 0 : 0);
                    HttpContext.Session.SetInt32("PrintProductDescription", storeinfo != null ? storeinfo.PrintProductDescription != false ? 1 : 0 : 0);
                    HttpContext.Session.SetInt32("PrintBrandName", storeinfo != null ? storeinfo.PrintBrandName != false ? 1 : 0 : 0);
                    HttpContext.Session.SetInt32("PrintModelName", storeinfo != null ? storeinfo.PrintModelName != false ? 1 : 0 : 0);
                    HttpContext.Session.SetInt32("PrintSizeName", storeinfo != null ? storeinfo.PrintSizeName != false ? 1 : 0 : 0);
                    HttpContext.Session.SetInt32("VisibleSalesCommission", storeinfo != null ? storeinfo.VisibleSalesCommission != false ? 1 : 0 : 0);

                    //HttpContext.Session.SetString("isFixedSalesValue", storeinfo.IsFixedSalesValue.ToString());




                    HttpContext.Session.SetString("isMultiDebitCredit", storeinfo.isMultiDebitCredit.ToString());
                    //HttpContext.Session.SetString("isMultiCurrency", company.isMultiCurrency.ToString());

                    HttpContext.Session.SetString("isVoucherDistributionEntry", storeinfo.isVoucherDistributionEntry.ToString());
                    HttpContext.Session.SetString("isChequeDetails", storeinfo.isChequeDetails.ToString());

                    HttpContext.Session.SetString("isSMSService", storeinfo.isSMSService.ToString());
                    HttpContext.Session.SetString("isEmailSerivce", storeinfo.isEmailSerivce.ToString());

                    HttpContext.Session.SetInt32("defaultcurrencyid", storeinfo.CountryId);
                    HttpContext.Session.SetString("defaultcurrencyname", storeinfo.Currency.CurrencyShortName.ToString());
                    HttpContext.Session.SetInt32("TimeZoneSettingsId", storeinfo.TimeZones != null ? storeinfo.TimeZoneSettingsId : 36);
                    HttpContext.Session.SetString("TimeZoneSettingsName", storeinfo != null ? storeinfo.TimeZones.TimeZoneName : "");
                    HttpContext.Session.SetString("TimeZoneSettingsNameJquery", storeinfo.TimeZones != null ? storeinfo.TimeZones.TimeZoneNameJquery : "");

                    var countryinfo = _countryRepository.All().Where(x => x.Id == storeinfo.CountryId).FirstOrDefault();
                    var countryinfoViewFormat = _countryRepository.All().Where(x => x.Id == 231).FirstOrDefault();



                    HttpContext.Session.SetString("CurrencyShortNameViewFormat", countryinfoViewFormat.CurrencyShortName);
                    HttpContext.Session.SetString("CultureInfoViewFormat", countryinfoViewFormat.CultureInfo);
                    HttpContext.Session.SetString("CountryShortNameViewFormat", countryinfoViewFormat.CountryShortName);
                    HttpContext.Session.SetString("CurrencySymbolViewFormat", countryinfoViewFormat.CurrencySymbol);


                    HttpContext.Session.SetString("CurrencyShortName", countryinfo.CurrencyShortName);
                    HttpContext.Session.SetString("CultureInfo", countryinfo.CultureInfo);
                    HttpContext.Session.SetString("CountryShortName", countryinfo.CountryShortName);
                    HttpContext.Session.SetString("CurrencySymbol", countryinfo.CurrencySymbol);


                    await HttpContext.SignInAsync(principal);



                    HttpContext.Session.SetString("Latitude", "");
                    HttpContext.Session.SetString("Longitude", "");


                    LogRepository.SuccessLogin(HttpContext.Session.GetString("Latitude"), HttpContext.Session.GetString("Longitude"), "Success");


                    return RedirectToAction("SupplierDashboard", "Admin");

                }
                else
                {
                    HttpContext.Session.SetString("Latitude", "=N/A=");
                    HttpContext.Session.SetString("Longitude", "=N/A=");
                    HttpContext.Session.SetString("UserInfo", supplier.PhoneNo + " " + supplier.Password);

                    LogRepository.SuccessLogin(HttpContext.Session.GetString("Latitude"), HttpContext.Session.GetString("Longitude"), "Failure");

                    TempData["UserLoginFailed"] = "Login Failed.Please enter correct credentials";
                    return View();
                }
            }
            else
                return View(supplier);

            #endregion
        }










        public ActionResult ChangeSelectedCompany(int ComId)
        {


            //#region weburlinfo
            //var weburl = Request.GetTypedHeaders().Referer.ToString().ToLower();//.Replace("/Home/Login".ToLower(), "");
            //var weburlquerystring = Request.QueryString.HasValue == true ? Request.QueryString.ToString() : "";// Request.QueryString == null ? "": Request.QueryString;// Request.QueryString?? Request.QueryString;//.Replace("/Home/Login".ToLower(), "");

            //var origin = weburl.ToLower();
            //var controllerName = this.ControllerContext.RouteData.Values["Controller"].ToString().ToLower();


            //string St = weburl.ToLower();
            //int pFrom = St.IndexOf("/?");

            //if (pFrom > 0)
            //{
            //    var filterurl = St.Substring(0, pFrom);
            //    origin = filterurl;
            //}
            ////var com = companyRepository.All().Where(x => x.Id == comid).FirstOrDefault();
            ////if (com != null)
            ////{
            //string resulta = "";
            ////if (pTo < 1)
            ////{
            ////    resulta = origin;

            ////}
            ////else
            ////{
            ////    resulta = St.Substring(pFrom, pTo - pFrom);
            ////    resulta = origin + "/" + resulta;

            ////}


            //if (weburlquerystring.Length > 2)
            //{
            //    resulta = origin.Replace(weburlquerystring, "").Replace("/Home/Login".ToLower(), "");

            //}
            //else
            //{
            //    resulta = origin.Replace("/Home/Login".ToLower(), "");

            //}

            //#endregion

            HttpContext.Session.SetInt32("ComId", ComId);


            var company = companyRepository.All().Where(x => x.Id == ComId).Include(x => x.BusinessType).FirstOrDefault();
            var storeinfo = storeSettingRepository.All().Where(x => x.ComId == ComId)
                            .Include(x => x.SalesReportStyle)
                            .Include(x => x.PurchaseReportStyle)
                            .Include(x => x.BarcodeReportStyle)
                            .Include(x => x.Currency)
                                                .Include(x => x.TimeZones)
                                                .FirstOrDefault();



            HttpContext.Session.SetInt32("BaseComId", storeinfo.BaseComId);

            HttpContext.Session.SetInt32("BusinessTypeId", company.BusinessTypeId);
            HttpContext.Session.SetString("BusinessType", company.BusinessType.BusinessTypeName);
            HttpContext.Session.SetString("AppsName", company.BusinessType.AppsName);


            HttpContext.Session.SetString("CompanyName", company.CompanyName != null ? company.CompanyName : "");
            HttpContext.Session.SetString("PrimaryAddress", company.PrimaryAddress != null ? company.PrimaryAddress : "");
            HttpContext.Session.SetString("SecoundaryAddress", company.SecoundaryAddress != null ? company.SecoundaryAddress : "");
            HttpContext.Session.SetString("comPhone", company.comPhone != null ? company.comPhone : "");
            HttpContext.Session.SetString("comWeb", company.comWeb != null ? company.comWeb : "");
            HttpContext.Session.SetString("comEmail", company.comEmail != null ? company.comEmail : "");
            HttpContext.Session.SetString("CaptionOne", "CaptionOne");
            HttpContext.Session.SetString("CaptionTwo", "CaptionTwo");
            HttpContext.Session.SetString("PrintDate", DateTime.Now.Date.ToString("dd-MMM-yy"));
            HttpContext.Session.SetString("comImagePath", storeinfo != null ? storeinfo.Logo != null ? storeinfo.Logo : "" : "");
            //HttpContext.Session.SetString("weburl", resulta.ToString());  

            HttpContext.Session.SetString("OfferDiscountPer", storeinfo != null ? storeinfo.OfferDiscountPer.ToString() : "0.00");
            HttpContext.Session.SetInt32("isDiscountOffer", storeinfo != null ? storeinfo.isDiscountOffer != false ? 1 : 0 : 0);

            HttpContext.Session.SetString("TaxPer", storeinfo != null ? storeinfo.TaxPer.ToString() : "0.00");
            HttpContext.Session.SetString("SalesReportStyle", storeinfo.SalesReportStyle != null ? storeinfo.SalesReportStyle.ReportStyleName : "Style1");
            HttpContext.Session.SetString("PurchaseReportStyle", storeinfo.PurchaseReportStyle != null ? storeinfo.PurchaseReportStyle.ReportStyleName : "Style1");
            HttpContext.Session.SetString("BarcodeReportStyle", storeinfo.BarcodeReportStyle != null ? storeinfo.BarcodeReportStyle.ReportStyleName : "Style1");

            HttpContext.Session.SetInt32("isTaxExcluded", storeinfo != null ? storeinfo.isTaxExcluded != false ? 1 : 0 : 0);
            HttpContext.Session.SetInt32("isMultiSelect", storeinfo != null ? storeinfo.isMultiSelect != false ? 1 : 0 : 0);
            HttpContext.Session.SetInt32("isFixedSalesValue", storeinfo != null ? storeinfo.IsFixedSalesValue != false ? 1 : 0 : 0);
            HttpContext.Session.SetInt32("IsFirstLetterUpperCase", storeinfo != null ? storeinfo.IsFirstLetterUpperCase != false ? 1 : 0 : 0);

            HttpContext.Session.SetInt32("IsSerialSales", storeinfo != null ? storeinfo.IsSerialSales != false ? 1 : 0 : 0);
            HttpContext.Session.SetInt32("IsIndDiscount", storeinfo != null ? storeinfo.IsIndDiscount != false ? 1 : 0 : 0);
            HttpContext.Session.SetInt32("IsSalesDescription", storeinfo != null ? storeinfo.IsSalesDescription != false ? 1 : 0 : 0);
            HttpContext.Session.SetInt32("IsVatLogin", storeinfo != null ? storeinfo.IsVatLogin != false ? 1 : 0 : 0);
            HttpContext.Session.SetInt32("isMultiCurrency", storeinfo != null ? storeinfo.isMultiCurrency != false ? 1 : 0 : 0);
            HttpContext.Session.SetInt32("IsTermsCondition", storeinfo != null ? storeinfo.IsTermsCondition != false ? 1 : 0 : 0);
            HttpContext.Session.SetInt32("IsDefaultDisAmount", storeinfo != null ? storeinfo.IsDefaultDisAmount != false ? 1 : 0 : 0);
            HttpContext.Session.SetInt32("DecimalField", storeinfo != null ? storeinfo.DecimalField : 0);

            HttpContext.Session.SetInt32("IsFixedDiscountMainValue", storeinfo != null ? storeinfo.IsFixedDiscountMainValue != false ? 1 : 0 : 0);
            HttpContext.Session.SetInt32("IsFixedDiscountRowValue", storeinfo != null ? storeinfo.IsFixedDiscountRowValue != false ? 1 : 0 : 0);
            HttpContext.Session.SetString("MaxDiscountMainValue", storeinfo != null ? storeinfo.MaxDiscountMainValue.ToString() : "0.00");
            HttpContext.Session.SetString("MaxDiscountPercentageMainValue", storeinfo != null ? storeinfo.MaxDiscountPercentageMainValue.ToString() : "0.00");
            HttpContext.Session.SetString("MaxDiscountRowValue", storeinfo != null ? storeinfo.MaxDiscountRowValue.ToString() : "0.00");

            HttpContext.Session.SetInt32("PrintProductName", storeinfo != null ? storeinfo.PrintProductName != false ? 1 : 0 : 0);
            HttpContext.Session.SetInt32("PrintProductCode", storeinfo != null ? storeinfo.PrintProductCode != false ? 1 : 0 : 0);
            HttpContext.Session.SetInt32("PrintProductDescription", storeinfo != null ? storeinfo.PrintProductDescription != false ? 1 : 0 : 0);
            HttpContext.Session.SetInt32("PrintBrandName", storeinfo != null ? storeinfo.PrintBrandName != false ? 1 : 0 : 0);
            HttpContext.Session.SetInt32("PrintModelName", storeinfo != null ? storeinfo.PrintModelName != false ? 1 : 0 : 0);
            HttpContext.Session.SetInt32("PrintSizeName", storeinfo != null ? storeinfo.PrintSizeName != false ? 1 : 0 : 0);
            HttpContext.Session.SetInt32("VisibleSalesCommission", storeinfo != null ? storeinfo.VisibleSalesCommission != false ? 1 : 0 : 0);


            HttpContext.Session.SetString("ShortCutKey", storeinfo.ShortCutKey != null ? storeinfo.ShortCutKey : "q"); // "y"
            HttpContext.Session.SetString("SearchType", storeinfo.isScanner == true ? "Scanner" : "Manual"); // "Scanner"
            HttpContext.Session.SetString("barcodeprefixforweightscale", storeinfo.BarcodePrefixForWeightScale != null ? storeinfo.BarcodePrefixForWeightScale : "99"); // "Scanner"


            //HttpContext.Session.SetString("isFixedSalesValue", storeinfo.IsFixedSalesValue.ToString());




            HttpContext.Session.SetString("isMultiDebitCredit", storeinfo.isMultiDebitCredit.ToString());
            //HttpContext.Session.SetString("isMultiCurrency", company.isMultiCurrency.ToString());

            HttpContext.Session.SetString("isVoucherDistributionEntry", storeinfo.isVoucherDistributionEntry.ToString());
            HttpContext.Session.SetString("isChequeDetails", storeinfo.isChequeDetails.ToString());

            HttpContext.Session.SetString("isSMSService", storeinfo.isSMSService.ToString());
            HttpContext.Session.SetString("isEmailSerivce", storeinfo.isEmailSerivce.ToString());

            HttpContext.Session.SetInt32("defaultcurrencyid", storeinfo.CountryId);
            HttpContext.Session.SetString("defaultcurrencyname", storeinfo.Currency.CurrencyShortName.ToString());
            HttpContext.Session.SetInt32("TimeZoneSettingsId", storeinfo.TimeZones != null ? storeinfo.TimeZoneSettingsId : 36);
            HttpContext.Session.SetString("TimeZoneSettingsName", storeinfo != null ? storeinfo.TimeZones.TimeZoneName : "");
            HttpContext.Session.SetString("TimeZoneSettingsNameJquery", storeinfo.TimeZones != null ? storeinfo.TimeZones.TimeZoneNameJquery : "");

            var localtime = TimeZoneInfo.ConvertTime(DateTime.Now, TimeZoneInfo.FindSystemTimeZoneById(storeinfo.TimeZones.TimeZoneName));
            var dtFrom = localtime.Date;
            ViewBag.FromDate = dtFrom.ToString("dd-MMM-yyyy");
            ViewBag.ToDate = dtFrom.ToString("dd-MMM-yyyy");



            var UserId = HttpContext.Session.GetInt32("UserId");
            var userdata = userAccountRepository.All(false).Include(x => x.UserRole).Where(x => x.Id == UserId).FirstOrDefault();
            //var rolename = userAccountRepository.All(false).Where(A => A.Id == UserId).Include(x => x.UserRole).Include(x => x.EmployeeList).FirstOrDefault();
            //HttpContext.Session.SetString("RoleName", userdata.UserRole.RoleName);
            HttpContext.Session.SetInt32("UserRoleId", userdata.UserRoleId ?? 0);
            HttpContext.Session.SetString("UserRole", userdata.UserRole.RoleName ?? "");

            if (userdata.IsBaseUser == true)
            {
                var userpermissionmenulist = _menuPermissionRepository.All().Include(x => x.Menus).Where(x => x.BusinessTypeId == company.BusinessTypeId).OrderBy(x => x.Menus.DisplayOrder);


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
                        usermenudata.IsView = true;// item.IsCreate;
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
                        usermenudata.FirstParameter = item.Menus.FirstParameter;
                        usermenudata.FirstValue = item.Menus.FirstValue;

                        userallmenulist.Add(usermenudata);
                    }
                }

                HttpContext.Session.SetObject("UserAllMenu", userallmenulist);
                HttpContext.Session.SetObject("UserGroupMenu", userallmenulist.Where(x => x.IsGroup == true));
                HttpContext.Session.SetObject("UserParentMenu", userallmenulist.Where(x => x.IsParent == true));
                HttpContext.Session.SetObject("UserChildMenu", userallmenulist.Where(x => x.ParentId != null));


            }
            else
            {

                var userpermissionmenulist = _menuPermissionDetailsRepository.All().Include(x => x.MenuPermissionMasters).Include(x => x.Menus).Where(x => x.MenuPermissionMasters.LUserIdPermission == UserId).ToList();
                List<UserMenuPermissionViewModel> userallmenulist = new List<UserMenuPermissionViewModel>();

                if (userpermissionmenulist != null)
                {
                    foreach (var item in userpermissionmenulist)
                    {
                        UserMenuPermissionViewModel usermenudata = new UserMenuPermissionViewModel();

                        usermenudata.Id = item.Menus.Id;

                        usermenudata.ActionName = item.Menus.ActionName;
                        usermenudata.ControllerName = item.Menus.ControllerName;
                        usermenudata.IsCreate = item.IsCreate;
                        usermenudata.IsView = item.IsView;
                        usermenudata.IsDeleteP = item.IsDeleteP;
                        usermenudata.IsEdit = item.IsEdit;
                        usermenudata.isDefault = item.isDefault;
                        usermenudata.SLNo = item.SLNo;

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
                        usermenudata.FirstParameter = item.Menus.FirstParameter;
                        usermenudata.FirstValue = item.Menus.FirstValue;

                        userallmenulist.Add(usermenudata);
                    }
                }

                HttpContext.Session.SetObject("UserAllMenu", userallmenulist);
                HttpContext.Session.SetObject("UserGroupMenu", userallmenulist.Where(x => x.IsGroup == true));
                HttpContext.Session.SetObject("UserParentMenu", userallmenulist.Where(x => x.IsParent == true));
                HttpContext.Session.SetObject("UserChildMenu", userallmenulist.Where(x => x.ParentId != null));


                //var fiscalyear = _accFiscalYearRepository.All().Where(x => x.OpeningDate.Year == DateTime.Now.Year).ToList().Count();

                //if (fiscalyear == 0)
                //{
                //    ///fiscal year Creation
                //    var PrevYear = DateTime.Now.Year - 1;
                //    var fromdate = new DateTime(PrevYear, 1, 1);
                //    var todate = new DateTime(PrevYear, 12, 31);

                //    SqlParameter[] sqlParameterfy = new SqlParameter[4];
                //    sqlParameterfy[0] = new SqlParameter("@comid", ComId);
                //    sqlParameterfy[1] = new SqlParameter("@dtFrom", fromdate);
                //    sqlParameterfy[2] = new SqlParameter("@dtTo", todate);
                //    sqlParameterfy[3] = new SqlParameter("@UserId", UserId);
                //    Helper.ExecProc("Acc_prcCloseFiscalYearManual", sqlParameterfy);
                //    ///fiscal year Creation
                //}

            }


            return Json(new { success = 1 });
            //return View("Index");
            //}


            //return Json(new { error = 0 });
        }


        [HttpGet]
        public IActionResult UserConfirmation(string Email, int OTPValue = 0)
        {

            var weburl = Request.Host.Value;
            ViewBag.weburl = weburl.Trim();
            HttpContext.Session.SetString("weburl", weburl);

            var userconfirmtiondata = userAccountRepository.All(false).Where(x => x.Email == Email && x.OTP == OTPValue.ToString()).FirstOrDefault();

            if (userconfirmtiondata != null)
            {
                userconfirmtiondata.IsEmailVerified = true;

                userAccountRepository.Update(userconfirmtiondata, userconfirmtiondata.Id);
                TempData["Message"] = "User Created Successfully";
                TempData["Status"] = "1";

                return View("Login");
            }

            TempData["Status"] = "3";
            TempData["Message"] = "Please Verify your OTP from Your Mail Account";
            return View("Login");

        }





        [HttpGet]
        public async Task<IActionResult> LoginApi(string Email, string Password, int IsMobile = 1, int DefaultComId = 0)
        {
            HttpContext.Session.SetInt32("IsMobile", IsMobile);


            LoginViewModel user = new LoginViewModel();
            user.Email = Email;
            user.Password = Password;

            bool result = userAccountRepository.ValidateUser(user);

            if (result)
            {
                //var claims = new List<Claim>
                //    {
                //        new Claim(ClaimTypes.Name, user.Email)
                //    };
                //ClaimsIdentity userIdentity = new ClaimsIdentity(claims, "login");
                //ClaimsPrincipal principal = new ClaimsPrincipal(userIdentity);

                Atrai.Model.AppData.DefaultConnectionString = Config.GetConnectionString("DefaultConnection");




                int UserId = userAccountRepository.GetUserId(user);
                HttpContext.Session.SetInt32("UserId", UserId);



                int ComId = userAccountRepository.GetComId(user);
                HttpContext.Session.SetInt32("ComId", ComId);




                string ComName = companyRepository.GetComName(ComId);
                HttpContext.Session.SetString("ComName", ComName);

                HttpContext.Session.SetString("UserInfo", user.Email);




                if (userAccountRepository.All().Include(x => x.UserRole).Where(x => x.Id == UserId).FirstOrDefault().UserRole.RoleName != "SuperAdmin")
                {
                    var subscriptionactivationdata = _subscriptionActivationRepository.All().Where(x => x.LuserId == UserId && x.ActiveToDate > DateTime.Now.Date).FirstOrDefault();

                    if (subscriptionactivationdata == null)
                    {
                        TempData["UserLoginFailed"] = "User Expired . Please Activate Your user by Pay renewal fee.. or Contact with your service provider 01671303302.";
                        return View();

                    }


                    //var activatepackage = _packageActivationRepository.All().Where(x => x.ComId == ComId && x.ActiveYesNo == true).OrderByDescending(x => x.Id).FirstOrDefault();

                    //if (activatepackage == null)
                    //{
                    //    return RedirectToAction("PurchasePackage", "License");
                    //    /// return RedirectToAction(firstmenu.Menus.ActionName, firstmenu.Menus.ControllerName);
                    //}


                }






                //return View(saleRepository.All().Include(x => x.CustomerModel).OrderByDescending(x => x.Id));

                var userdata = userAccountRepository.All().Include(x => x.UserRole).Where(x => x.Id == UserId).FirstOrDefault();

                var claims = new List<Claim>
                    {
                        new Claim(ClaimTypes.Name, user.Email)
                    };
                var _claim = new Claim("Role", userdata.UserRole.RoleName);
                claims.Add(_claim);

                ClaimsIdentity userIdentity = new ClaimsIdentity(claims, "login");
                ClaimsPrincipal principal = new ClaimsPrincipal(userIdentity);



                HttpContext.Session.SetInt32("UserRoleId", userdata.UserRoleId ?? 0);
                HttpContext.Session.SetString("UserRole", userdata.UserRole.RoleName ?? "");



                if (userdata.UserRole.RoleName.Contains("SuperAdmin"))
                {
                    var CompanyUserList = companyRepository.All().Select(x => new SelectListItem { Text = x.CompanyName, Value = x.Id.ToString() }).OrderBy(x => x.Value).ToList();
                    if (CompanyUserList.Count > 0)
                    {
                        HttpContext.Session.SetObject("UserCompanys", CompanyUserList);
                    }


                    HttpContext.Session.SetInt32("IsUserLevel", 1);

                    //HttpContext.Session.SetInt32("IsSuperAdmin", 1);
                    //HttpContext.Session.SetInt32("IsAdmin", 0);
                    //HttpContext.Session.SetInt32("IsUser", 0);
                }
                else if (userdata.UserRole.RoleName.Contains("Admin"))
                {
                    var CompanyUserList = _companyPermissionRepository.All().Include(x => x.CompanyList).Where(x => x.LuserId == UserId).Select(x => new SelectListItem { Text = x.CompanyList.CompanyName, Value = x.ComId.ToString() }).ToList();
                    HttpContext.Session.SetObject("UserCompanys", CompanyUserList);

                    HttpContext.Session.SetInt32("IsUserLevel", 2);


                    //HttpContext.Session.SetInt32("IsSuperAdmin", 0);
                    //HttpContext.Session.SetInt32("IsAdmin", 1);
                    //HttpContext.Session.SetInt32("IsUser", 0);
                }
                else if (userdata.UserRole.RoleName.Contains("User"))
                {
                    HttpContext.Session.SetInt32("IsUserLevel", 3);


                    //HttpContext.Session.SetInt32("IsSuperAdmin", 0);
                    //HttpContext.Session.SetInt32("IsAdmin", 0);
                    //HttpContext.Session.SetInt32("IsUser", 1);
                }
                else
                {
                    HttpContext.Session.SetInt32("IsUserLevel", 4);


                    //HttpContext.Session.SetInt32("IsSuperAdmin", 0);
                    //HttpContext.Session.SetInt32("IsAdmin", 0);
                    //HttpContext.Session.SetInt32("IsUser", 0);
                }


                if (DefaultComId > 0)
                {
                    HttpContext.Session.SetInt32("ComId", DefaultComId);
                    ComId = DefaultComId;
                }
                var company = companyRepository.All().Where(x => x.Id == ComId).Include(x => x.BusinessType).FirstOrDefault();
                var storeinfo = storeSettingRepository.All().Where(x => x.ComId == ComId)
                    .Include(x => x.SalesReportStyle)
                    .Include(x => x.PurchaseReportStyle)
                    .Include(x => x.BarcodeReportStyle)
                    .Include(x => x.TimeZones)
                    .Include(x => x.Currency)
                    .FirstOrDefault();



                HttpContext.Session.SetString("ShortCutKey", storeinfo.ShortCutKey != null ? storeinfo.ShortCutKey : "q"); // "y"
                HttpContext.Session.SetString("SearchType", storeinfo.isScanner == true ? "Scanner" : "Manual"); // "Scanner"
                HttpContext.Session.SetString("barcodeprefixforweightscale", storeinfo.BarcodePrefixForWeightScale != null ? storeinfo.BarcodePrefixForWeightScale : "99"); // "Scanner"



                string weburl = Config.GetSection("host").Value;

                //AppData.AppData.DefaultConnectionString = Config.GetConnectionString("DefaultConnection");

                //var weburl = ; //Request.GetTypedHeaders().Referer.ToString().ToLower();//.Replace("/Home/Login".ToLower(), "");
                var weburlquerystring = Request.QueryString.HasValue == true ? Request.QueryString.ToString() : "";// Request.QueryString == null ? "": Request.QueryString;// Request.QueryString?? Request.QueryString;//.Replace("/Home/Login".ToLower(), "");

                var origin = weburl.ToLower();
                var controllerName = this.ControllerContext.RouteData.Values["Controller"].ToString().ToLower();


                string St = weburl.ToLower();
                int pFrom = St.IndexOf("/?");

                if (pFrom > 0)
                {
                    var filterurl = St.Substring(0, pFrom);
                    origin = filterurl;
                }
                //string example = "Hello, World!";

                //// Get the 5 characters from the left of the string
                //string exampleLeft = example.Substring(0, 5);



                //String St = weburl.ToLower();

                //int pFrom = St.IndexOf("/") + "/".Length;
                //int pTo = St.LastIndexOf("/" + controllerName);
                string resulta = "";
                //if (pTo < 1)
                //{
                //    resulta = origin;

                //}
                //else
                //{
                //    resulta = St.Substring(pFrom, pTo - pFrom);
                //    resulta = origin + "/" + resulta;

                //}


                if (weburlquerystring.Length > 2)
                {
                    resulta = origin.Replace(weburlquerystring, "").Replace("/Home/Login".ToLower(), "");

                }
                else
                {
                    resulta = origin.Replace("/Home/Login".ToLower(), "");

                }



                HttpContext.Session.SetInt32("BaseComId", storeinfo.BaseComId);

                HttpContext.Session.SetInt32("BusinessTypeId", company.BusinessTypeId);
                HttpContext.Session.SetString("BusinessType", company.BusinessType.BusinessTypeName);
                HttpContext.Session.SetString("AppsName", company.BusinessType.AppsName);


                HttpContext.Session.SetString("CompanyName", company.CompanyName != null ? company.CompanyName : "");
                HttpContext.Session.SetString("PrimaryAddress", company.PrimaryAddress != null ? company.PrimaryAddress : "");
                HttpContext.Session.SetString("SecoundaryAddress", company.SecoundaryAddress != null ? company.SecoundaryAddress : "");
                HttpContext.Session.SetString("comPhone", company.comPhone != null ? company.comPhone : "");
                HttpContext.Session.SetString("comWeb", company.comWeb != null ? company.comWeb : "");
                HttpContext.Session.SetString("comEmail", company.comEmail != null ? company.comEmail : "");
                HttpContext.Session.SetString("CaptionOne", "CaptionOne");
                HttpContext.Session.SetString("CaptionTwo", "CaptionTwo");
                HttpContext.Session.SetString("PrintDate", DateTime.Now.Date.ToString("dd-MMM-yy"));
                HttpContext.Session.SetString("comImagePath", storeinfo != null ? storeinfo.Logo : "");
                HttpContext.Session.SetString("weburl", resulta.ToString());

                HttpContext.Session.SetString("OfferDiscountPer", storeinfo != null ? storeinfo.OfferDiscountPer.ToString() : "0.00");
                HttpContext.Session.SetInt32("isDiscountOffer", storeinfo != null ? storeinfo.isDiscountOffer != false ? 1 : 0 : 0);

                HttpContext.Session.SetString("TaxPer", storeinfo != null ? storeinfo.TaxPer.ToString() : "0.00");
                HttpContext.Session.SetString("SalesReportStyle", storeinfo.SalesReportStyle != null ? storeinfo.SalesReportStyle.ReportStyleName : "Style1");
                HttpContext.Session.SetString("PurchaseReportStyle", storeinfo.PurchaseReportStyle != null ? storeinfo.PurchaseReportStyle.ReportStyleName : "Style1");
                HttpContext.Session.SetString("BarcodeReportStyle", storeinfo.BarcodeReportStyle != null ? storeinfo.BarcodeReportStyle.ReportStyleName : "Style1");

                HttpContext.Session.SetInt32("isTaxExcluded", storeinfo != null ? storeinfo.isTaxExcluded != false ? 1 : 0 : 0);
                HttpContext.Session.SetInt32("isMultiCurrency", storeinfo != null ? storeinfo.isMultiCurrency != false ? 1 : 0 : 0);
                HttpContext.Session.SetInt32("IsTermsCondition", storeinfo != null ? storeinfo.IsTermsCondition != false ? 1 : 0 : 0);
                HttpContext.Session.SetInt32("IsDefaultDisAmount", storeinfo != null ? storeinfo.IsDefaultDisAmount != false ? 1 : 0 : 0);
                HttpContext.Session.SetInt32("DecimalField", storeinfo != null ? storeinfo.DecimalField : 0);

                HttpContext.Session.SetInt32("IsFixedDiscountMainValue", storeinfo != null ? storeinfo.IsFixedDiscountMainValue != false ? 1 : 0 : 0);
                HttpContext.Session.SetInt32("IsFixedDiscountRowValue", storeinfo != null ? storeinfo.IsFixedDiscountRowValue != false ? 1 : 0 : 0);
                HttpContext.Session.SetString("MaxDiscountMainValue", storeinfo != null ? storeinfo.MaxDiscountMainValue.ToString() : "0.00");
                HttpContext.Session.SetString("MaxDiscountPercentageMainValue", storeinfo != null ? storeinfo.MaxDiscountPercentageMainValue.ToString() : "0.00");
                HttpContext.Session.SetString("MaxDiscountRowValue", storeinfo != null ? storeinfo.MaxDiscountRowValue.ToString() : "0.00");

                HttpContext.Session.SetInt32("PrintProductName", storeinfo != null ? storeinfo.PrintProductName != false ? 1 : 0 : 0);
                HttpContext.Session.SetInt32("PrintProductCode", storeinfo != null ? storeinfo.PrintProductCode != false ? 1 : 0 : 0);
                HttpContext.Session.SetInt32("PrintProductDescription", storeinfo != null ? storeinfo.PrintProductDescription != false ? 1 : 0 : 0);
                HttpContext.Session.SetInt32("PrintBrandName", storeinfo != null ? storeinfo.PrintBrandName != false ? 1 : 0 : 0);
                HttpContext.Session.SetInt32("PrintModelName", storeinfo != null ? storeinfo.PrintModelName != false ? 1 : 0 : 0);
                HttpContext.Session.SetInt32("PrintSizeName", storeinfo != null ? storeinfo.PrintSizeName != false ? 1 : 0 : 0);
                HttpContext.Session.SetInt32("VisibleSalesCommission", storeinfo != null ? storeinfo.VisibleSalesCommission != false ? 1 : 0 : 0);


                HttpContext.Session.SetString("isMultiDebitCredit", storeinfo.isMultiDebitCredit.ToString());
                //HttpContext.Session.SetString("isMultiCurrency", company.isMultiCurrency.ToString());
                HttpContext.Session.SetString("isVoucherDistributionEntry", storeinfo.isVoucherDistributionEntry.ToString());
                HttpContext.Session.SetString("isChequeDetails", storeinfo.isChequeDetails.ToString());

                HttpContext.Session.SetString("isSMSService", storeinfo.isSMSService.ToString());
                HttpContext.Session.SetString("isEmailSerivce", storeinfo.isEmailSerivce.ToString());

                HttpContext.Session.SetInt32("defaultcurrencyid", storeinfo.CountryId);
                HttpContext.Session.SetString("defaultcurrencyname", storeinfo.Currency.CurrencyShortName.ToString());
                HttpContext.Session.SetInt32("TimeZoneSettingsId", storeinfo.TimeZones != null ? storeinfo.TimeZoneSettingsId : 36);
                HttpContext.Session.SetString("TimeZoneSettingsName", storeinfo != null ? storeinfo.TimeZones.TimeZoneName : "");
                HttpContext.Session.SetString("TimeZoneSettingsNameJquery", storeinfo.TimeZones != null ? storeinfo.TimeZones.TimeZoneNameJquery : "");

                //HttpContext.Session.SetObject("UserAllMenu", _menuPermissionRepository.All().Include(x => x.Menu).Where(x => x.UserRoleId == userdata.UserRoleId && x.BusinessTypeId == company.BusinessTypeId).OrderBy(x => x.Menu.DisplayOrder));
                //HttpContext.Session.SetObject("UserGroupMenu", _menuPermissionRepository.All().Include(x => x.Menu).Where(x => x.Menu.isGroup == true && x.UserRoleId == userdata.UserRoleId && x.BusinessTypeId == company.BusinessTypeId).OrderBy(x => x.Menu.DisplayOrder));
                //HttpContext.Session.SetObject("UserParentMenu", _menuPermissionRepository.All().Include(x => x.Menu).Where(x => x.Menu.isParent == true && x.UserRoleId == userdata.UserRoleId && x.BusinessTypeId == company.BusinessTypeId).OrderBy(x => x.Menu.DisplayOrder));
                //HttpContext.Session.SetObject("UserChildMenu", _menuPermissionRepository.All().Include(x => x.Menu).Where(x => x.Menu.ParentId != null && x.UserRoleId == userdata.UserRoleId && x.BusinessTypeId == company.BusinessTypeId).OrderBy(x => x.Menu.DisplayOrder));





                //HttpContext.Session.SetObject("UserAllMenu", _menuPermissionMasterRepository.All().Include(x => x.MenuPermission_Details).ThenInclude(x => x.Menus).Where(x => x.LUserIdPermission == UserId));






                if (userdata.IsBaseUser == true)
                {
                    var userpermissionmenulist = _menuPermissionRepository.All().Include(x => x.Menus).Where(x => x.BusinessTypeId == company.BusinessTypeId).OrderBy(x => x.Menus.DisplayOrder);


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
                            usermenudata.FirstParameter = item.Menus.FirstParameter;
                            usermenudata.FirstValue = item.Menus.FirstValue;

                            userallmenulist.Add(usermenudata);
                        }
                    }

                    HttpContext.Session.SetObject("UserAllMenu", userallmenulist);
                    HttpContext.Session.SetObject("UserGroupMenu", userallmenulist.Where(x => x.IsGroup == true));
                    HttpContext.Session.SetObject("UserParentMenu", userallmenulist.Where(x => x.IsParent == true));
                    HttpContext.Session.SetObject("UserChildMenu", userallmenulist.Where(x => x.ParentId != null));


                }
                else
                {

                    var userpermissionmenulist = _menuPermissionDetailsRepository.All().Include(x => x.MenuPermissionMasters).Include(x => x.Menus).Where(x => x.MenuPermissionMasters.LUserIdPermission == UserId).ToList();
                    List<UserMenuPermissionViewModel> userallmenulist = new List<UserMenuPermissionViewModel>();

                    if (userpermissionmenulist != null)
                    {
                        foreach (var item in userpermissionmenulist)
                        {
                            UserMenuPermissionViewModel usermenudata = new UserMenuPermissionViewModel();

                            usermenudata.Id = item.Menus.Id;

                            usermenudata.ActionName = item.Menus.ActionName;
                            usermenudata.ControllerName = item.Menus.ControllerName;
                            usermenudata.IsCreate = item.IsCreate;
                            usermenudata.IsDeleteP = item.IsDeleteP;
                            usermenudata.IsEdit = item.IsEdit;
                            usermenudata.isDefault = item.isDefault;
                            usermenudata.SLNo = item.SLNo;

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
                            usermenudata.FirstParameter = item.Menus.FirstParameter;
                            usermenudata.FirstValue = item.Menus.FirstValue;

                            userallmenulist.Add(usermenudata);
                        }
                    }

                    HttpContext.Session.SetObject("UserAllMenu", userallmenulist);
                    HttpContext.Session.SetObject("UserGroupMenu", userallmenulist.Where(x => x.IsGroup == true));
                    HttpContext.Session.SetObject("UserParentMenu", userallmenulist.Where(x => x.IsParent == true));
                    HttpContext.Session.SetObject("UserChildMenu", userallmenulist.Where(x => x.ParentId != null));

                }













                //HttpContext.Session.SetObject("UserGroupMenu", _menuPermissionDetailsRepository.All().Include(x => x.MenuPermissionMasters).Include(x => x.Menus).Where(x => x.Menus.isGroup == true && x.MenuPermissionMasters.LUserIdPermission == UserId).OrderBy(x => x.SLNo));
                //var testmenu = HttpContext.Session.GetObject<List<MenuPermission_DetailsModel>>("UserGroupMenu");


                //HttpContext.Session.SetObject("UserParentMenu", _menuPermissionDetailsRepository.All().Include(x => x.MenuPermissionMasters).Include(x => x.Menus).Where(x => x.Menus.isParent == true && x.MenuPermissionMasters.LUserIdPermission == UserId).OrderBy(x => x.SLNo));
                //HttpContext.Session.SetObject("UserChildMenu", _menuPermissionDetailsRepository.All().Include(x => x.MenuPermissionMasters).Include(x => x.Menus).Where(x => x.Menus.ParentId != null && x.MenuPermissionMasters.LUserIdPermission == UserId).OrderBy(x => x.SLNo));
                HttpContext.Session.SetObject("MenuList", _menuRepository.All().OrderBy(x => x.ParentMenu.DisplayOrder));





                var countryinfo = _countryRepository.All().Where(x => x.Id == storeinfo.CountryId).FirstOrDefault();
                var countryinfoViewFormat = _countryRepository.All().Where(x => x.Id == 231).FirstOrDefault();

                //var cultureInfo = new CultureInfo(countryinfo.CultureInfo);
                //cultureInfo.NumberFormat.CurrencySymbol = countryinfo.CurrencySymbol;
                //CultureInfo.DefaultThreadCurrentCulture = cultureInfo;
                //CultureInfo.DefaultThreadCurrentUICulture = cultureInfo;


                HttpContext.Session.SetString("CurrencyShortNameViewFormat", countryinfoViewFormat.CurrencyShortName);
                HttpContext.Session.SetString("CultureInfoViewFormat", countryinfoViewFormat.CultureInfo);
                HttpContext.Session.SetString("CountryShortNameViewFormat", countryinfoViewFormat.CountryShortName);
                HttpContext.Session.SetString("CurrencySymbolViewFormat", countryinfoViewFormat.CurrencySymbol);


                HttpContext.Session.SetString("CurrencyShortName", countryinfo.CurrencyShortName);
                HttpContext.Session.SetString("CultureInfo", countryinfo.CultureInfo);
                HttpContext.Session.SetString("CountryShortName", countryinfo.CountryShortName);
                HttpContext.Session.SetString("CurrencySymbol", countryinfo.CurrencySymbol);




                //HttpContext.Session.SetString("CompanyAddressBangla", company.CompanyAddressBangla != null ? company.CompanyAddressBangla : "");
                //HttpContext.Session.SetString("CompanyNameBangla", company.CompanyNameBangla != null ? company.CompanyNameBangla : "");



                await HttpContext.SignInAsync(principal);

                //var UserId = HttpContext.Session.GetInt32("UserId");
                //var ComId = HttpContext.Session.GetInt32("ComId");

                HttpContext.Session.SetString("Latitude", "");
                HttpContext.Session.SetString("Longitude", "");


                LogRepository.SuccessLogin(HttpContext.Session.GetString("Latitude"), HttpContext.Session.GetString("Longitude"), "Success");

                //return RedirectToAction("Index", "Admin");


                //var firstmenu = _menuPermissionRepository.All().Include(x => x.Menu).Where(x => x.Menu.ParentId != null && x.UserRoleId == userdata.UserRoleId && x.BusinessTypeId == company.BusinessTypeId).OrderBy(x => x.Menu.DisplayOrder).FirstOrDefault();






                if (userdata.IsBaseUser == true)
                {
                    var firstmenu = _menuPermissionRepository.All().Include(x => x.Menus).Where(x => x.Menus.ParentId != null && x.BusinessTypeId == company.BusinessTypeId).OrderBy(x => x.Menus.DisplayOrder).FirstOrDefault();

                    if (firstmenu == null)
                    {
                        return RedirectToAction("AccessDenied");
                    }
                    return RedirectToAction(firstmenu.Menus.ActionName, firstmenu.Menus.ControllerName);
                }
                else
                {
                    var firstmenu = _menuPermissionDetailsRepository.All().Include(x => x.MenuPermissionMasters).Include(x => x.Menus).Where(x => x.Menus.ParentId != null && x.MenuPermissionMasters.LUserIdPermission == UserId).OrderBy(x => x.Menus.DisplayOrder).FirstOrDefault();

                    if (firstmenu == null)
                    {
                        return RedirectToAction("AccessDenied");
                    }
                    return RedirectToAction(firstmenu.Menus.ActionName, firstmenu.Menus.ControllerName);
                }


            }
            else
            {
                HttpContext.Session.SetString("Latitude", "=N/A=");
                HttpContext.Session.SetString("Longitude", "=N/A=");
                HttpContext.Session.SetString("UserInfo", user.Email + " " + user.Password);

                LogRepository.SuccessLogin(HttpContext.Session.GetString("Latitude"), HttpContext.Session.GetString("Longitude"), "Failure");

                TempData["UserLoginFailed"] = "Login Failed.Please enter correct credentials";
                return View();
            }

        }



        [HttpGet]
        public ActionResult Signup()
        {
            var weburl = Request.Host.Value;
            //errorlog(weburl.ToString());
            //ViewBag.weburl = weburl.Trim();
            HttpContext.Session.SetString("weburl", weburl);

            var company = companyRepository.All().Include(x => x.BusinessType).Where(x => x.comWeb.ToLower().Contains(weburl.ToLower())).FirstOrDefault();

            if (company != null)
            {
                ViewBag.ComId = company.Id;
                var companysettings = storeSettingRepository.All(false).Where(x => x.ComId == company.Id).FirstOrDefault();
                ViewBag.comImagePath = companysettings.Logo;
                //ViewBag.AppsName = companysettings.BusinessType.AppsName;
                HttpContext.Session.SetString("AppsName", company.BusinessType.AppsName);
            }
            else
            {
                company = companyRepository.All().Include(x => x.BusinessType).Where(x => x.Id == 1).FirstOrDefault();
                ViewBag.ComId = company.Id;
                var companysettings = storeSettingRepository.All(false).Where(x => x.ComId == company.Id).FirstOrDefault();
                ViewBag.comImagePath = companysettings.Logo;
                HttpContext.Session.SetString("AppsName", "Easy Invoice");
            }


            ViewBag.Country = _countryRepository.GetAllForDropDown();
            ViewBag.BusinessType = _businessTypeRepository.GetActiveForDropDown();
            ViewBag.FiscalYearType = _fiscalYearTypeRepository.GetAllForDropDown();

            ViewBag.SubscriptionType = _subscriptionTypeRepository.GetActiveForDropDown();

            Atrai.Model.AppData.DefaultConnectionString = Config.GetConnectionString("DefaultConnection");

            return View();
        }


        [HttpGet]
        public ActionResult SignupURL()
        {

            var weburl = Request.Host.Value;
            //errorlog(weburl.ToString());
            //ViewBag.weburl = weburl.Trim();
            HttpContext.Session.SetString("weburl", weburl);

            var company = companyRepository.All().Include(x => x.BusinessType).Where(x => x.comWeb.ToLower().Contains(weburl.ToLower())).FirstOrDefault();

            if (company != null)
            {
                ViewBag.ComId = company.Id;
                var companysettings = storeSettingRepository.All(false).Where(x => x.ComId == company.Id).FirstOrDefault();
                ViewBag.comImagePath = companysettings.Logo;
                //ViewBag.AppsName = companysettings.BusinessType.AppsName;
                HttpContext.Session.SetString("AppsName", company.BusinessType.AppsName);
            }
            else
            {
                company = companyRepository.All().Include(x => x.BusinessType).Where(x => x.Id == 1).FirstOrDefault();
                ViewBag.ComId = company.Id;
                var companysettings = storeSettingRepository.All(false).Where(x => x.ComId == company.Id).FirstOrDefault();
                ViewBag.comImagePath = companysettings.Logo;
                HttpContext.Session.SetString("AppsName", "Easy Invoice");
            }


            ViewBag.Country = _countryRepository.GetAllForDropDown();
            ViewBag.BusinessType = _businessTypeRepository.GetActiveForDropDown();
            ViewBag.FiscalYearType = _fiscalYearTypeRepository.GetAllForDropDown();
            ViewBag.SubscriptionType = _subscriptionTypeRepository.GetActiveForDropDown();

            Atrai.Model.AppData.DefaultConnectionString = Config.GetConnectionString("DefaultConnection");

            return View();
        }

        [HttpGet]
        public ActionResult AtraiSignupURL()
        {

            var weburl = Request.Host.Value;
            //errorlog(weburl.ToString());
            //ViewBag.weburl = weburl.Trim();
            HttpContext.Session.SetString("weburl", weburl);

            var company = companyRepository.All().Include(x => x.BusinessType).Where(x => x.comWeb.ToLower().Contains(weburl.ToLower())).FirstOrDefault();

            if (company != null)
            {
                ViewBag.ComId = company.Id;
                var companysettings = storeSettingRepository.All(false).Where(x => x.ComId == company.Id).FirstOrDefault();
                ViewBag.comImagePath = companysettings.Logo;
                //ViewBag.AppsName = companysettings.BusinessType.AppsName;
                HttpContext.Session.SetString("AppsName", company.BusinessType.AppsName);
            }
            else
            {
                company = companyRepository.All().Include(x => x.BusinessType).Where(x => x.Id == 1).FirstOrDefault();
                ViewBag.ComId = company.Id;
                var companysettings = storeSettingRepository.All(false).Where(x => x.ComId == company.Id).FirstOrDefault();
                ViewBag.comImagePath = companysettings.Logo;
                HttpContext.Session.SetString("AppsName", "Easy Invoice");
            }


            ViewBag.Country = _countryRepository.GetAllForDropDown();
            ViewBag.BusinessType = _businessTypeRepository.GetActiveForDropDown();
            ViewBag.FiscalYearType = _fiscalYearTypeRepository.GetAllForDropDown();
            ViewBag.SubscriptionType = _subscriptionTypeRepository.GetActiveForDropDown();

            Atrai.Model.AppData.DefaultConnectionString = Config.GetConnectionString("DefaultConnection");

            return View();
        }

        [HttpGet]
        public ActionResult ChangePassword()
        {
            var UserId = HttpContext.Session.GetInt32("UserId");
            var ComId = HttpContext.Session.GetInt32("ComId");

            var userdata = userAccountRepository.All().Where(x => x.Id == UserId).FirstOrDefault();

            ChangePasswordViewModel abc = new ChangePasswordViewModel();
            //abc.PhoneNo = userdata.PhoneNumber;
            abc.EmailOrPhone = userdata.Email;


            return View(abc);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult ChangePassword(ChangePasswordViewModel signinmodel)
        {
            var errors = ModelState.Where(x => x.Value.Errors.Any())
            .Select(x => new { x.Key, x.Value.Errors });
            try
            {
                if (ModelState.IsValid)
                {
                    var UserId = HttpContext.Session.GetInt32("UserId");
                    var userccountinfo = userAccountRepository.All().Where(x => x.Id == UserId).FirstOrDefault();

                    if (userccountinfo.Email == signinmodel.EmailOrPhone && userccountinfo.Password == signinmodel.OldPassword)
                    {
                        var callBackUrl = Url.ActionLink("Login", "Home");
                        if (signinmodel.EmailOrPhone != null)
                        {
                            string mailList = signinmodel.EmailOrPhone;
                            string subject = $"Password Change.";
                            string body = $"Your Password Have changed successfully. <br/><br/> Changing Time : - {DateTime.Now}<br/> To Login Your Account please go to the link <br/><br/><a href='{HtmlEncoder.Default.Encode(callBackUrl)}'>Click here to login software.</a>";


                            //var hostaddressforsender = Request.GetTypedHeaders().Host.Value;
                            _emailsender.SendEmailAsync(mailList, subject, body);
                            //_smsSender.SendSmsAsync(signinmodel.PhoneNo, "Your Password Have changed successfully. Changing Time : - " + DateTime.Now);
                            _smsSender.SendSmsAsync(signinmodel.EmailOrPhone, "Your Password Have changed successfully. Changing Time : - " + DateTime.Now);


                        }

                        userccountinfo.Password = signinmodel.Password;
                        userAccountRepository.Update(userccountinfo, userccountinfo.Id);


                        TempData["Message"] = "Password change Successfully.";
                        TempData["Status"] = "1";
                    }
                    else
                    {

                        TempData["Message"] = "Wrong Information! Please Try Again.";
                        TempData["Status"] = "3";
                        return View(signinmodel);
                    }

                    //var OTPvalue = ValuesController.randomnumbergenerate(4, 1050, 9999).ToString();


                    //return Json(data: new { success = true, message = "Successfully Registerd" }, JsonRequesBehaviour.AllowGet);


                    //return Json(new { Success = 1, accname = signinmodel.Email, ex = "Registration Applied Successfully.Check Your EMail to Confirm Your Account." });

                    return RedirectToAction("Login");
                    //model.


                }

                //return Json(new { Success = 1, accname = signinmodel.Email, ex = "Registration Applied Successfully.Check Your EMail to Confirm Your Account." });

                return RedirectToAction("Login");

            }
            catch (Exception e)
            {


                errorlog(e);

                //TempData["FFMsg"] = "Something wrong! Contact with Administrator!";
                TempData["FFMsg"] = e.Message.ToString();
                ViewBag.Country = _countryRepository.GetAllForDropDown();
                //ViewBag.BusinessType = _businessTypeRepository.GetAllForDropDown();
                //ViewBag.SubscriptionType = _subscriptionTypeRepository.GetAllForDropDown();

                return Json(new { Success = 0, ex = e.Message });

                //return Json(new { Success = 1, accname = signinmodel.Email, ex = "User Registered Successfully." });

                //return View(signinmodel);
            }
        }



        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult OTPSet(OTPSetViewModel signinmodel)
        {
            var errors = ModelState.Where(x => x.Value.Errors.Any())
            .Select(x => new { x.Key, x.Value.Errors });
            try
            {
                if (ModelState.IsValid)
                {

                    var userccountinfo = userAccountRepository.All().Where(x => ((x.Email == signinmodel.EmailOrPhone) || (x.PhoneNumber == signinmodel.EmailOrPhone)) && (x.OTP == signinmodel.OTP)).FirstOrDefault();


                    if (userccountinfo != null)
                    {
                        var callBackUrl = Url.ActionLink("Login", "Home");

                        string mailList = signinmodel.EmailOrPhone;
                        string subject = $"Password Change.";
                        //string body = $"Your Account Have Craeted successfully. <br/><br/> Created Time : - {DateTime.Now}<br/> To Login Your Account please go to the link <br/><br/><a href='{HtmlEncoder.Default.Encode(callBackUrl)}'>Click here to login software.</a>";
                        string body = $"Your Account Have Craeted successfully. <br/><br/> Created Time : - {DateTime.Now}<br/> To Login Your Account please go to the link <br/><br/><a href='{HtmlEncoder.Default.Encode(callBackUrl)}'>Click here to login software.</a>";


                        //var hostaddressforsender = Request.GetTypedHeaders().Host.Value;
                        _emailsender.SendEmailAsync(userccountinfo.Email, subject, body);
                        //_smsSender.SendSmsAsync(signinmodel.PhoneNo, "Your Password Have changed successfully. Changing Time : - " + DateTime.Now);
                        _smsSender.SendSmsAsync(userccountinfo.PhoneNumber, "Your Account Have Craeted successfully. Created Time : - " + DateTime.Now);

                        userccountinfo.OTP = "";
                        userccountinfo.IsEmailVerified = true;
                        userAccountRepository.Update(userccountinfo, userccountinfo.Id);


                        TempData["Message"] = "User Created Successfully.";
                        TempData["Status"] = "1";

                        //userccountinfo.Password = signinmodel.Password;

                        return RedirectToAction("Login", "Home");
                    }
                    else
                    {

                        TempData["Message"] = "Wrong Information! Please Try Again.";
                        TempData["Status"] = "3";
                        return RedirectToAction("OTPConfirmation", "Home", signinmodel);


                    }

                    //var OTPvalue = ValuesController.randomnumbergenerate(4, 1050, 9999).ToString();


                    //return Json(data: new { success = true, message = "Successfully Registerd" }, JsonRequesBehaviour.AllowGet);


                    //return Json(new { Success = 1, accname = signinmodel.Email, ex = "Registration Applied Successfully.Check Your EMail to Confirm Your Account." });

                    return RedirectToAction("Login");
                    //model.


                }

                //return Json(new { Success = 1, accname = signinmodel.Email, ex = "Registration Applied Successfully.Check Your EMail to Confirm Your Account." });

                return RedirectToAction("Login");

            }
            catch (Exception e)
            {


                errorlog(e);

                //TempData["FFMsg"] = "Something wrong! Contact with Administrator!";
                TempData["FFMsg"] = e.Message.ToString();
                ViewBag.Country = _countryRepository.GetAllForDropDown();
                //ViewBag.BusinessType = _businessTypeRepository.GetAllForDropDown();
                //ViewBag.SubscriptionType = _subscriptionTypeRepository.GetAllForDropDown();

                return Json(new { Success = 0, ex = e.Message });

                //return Json(new { Success = 1, accname = signinmodel.Email, ex = "User Registered Successfully." });

                //return View(signinmodel);
            }
        }

        [HttpGet]
        public ActionResult ForgetPassword()
        {


            return View();
        }


        [HttpGet]
        public IActionResult ForgetPasswordOTP(string Email, string PhoneNo)
        {

            var weburl = Request.Host.Value;
            ViewBag.weburl = weburl.Trim();
            HttpContext.Session.SetString("weburl", weburl);



            var userconfirmtiondata = userAccountRepository.All(false).Where(x => x.Email == Email && x.PhoneNumber == PhoneNo).FirstOrDefault();



            //userconfirmtiondata.OTP = null;
            //userAccountRepository.Update(userconfirmtiondata, userconfirmtiondata.Id);

            if (userconfirmtiondata != null)
            {
                ForgetPasswordOTPViewModel abc = new ForgetPasswordOTPViewModel();

                abc.Email = Email;
                abc.PhoneNo = PhoneNo;
                //userconfirmtiondata.IsEmailVerified = true;

                //userAccountRepository.Update(userconfirmtiondata, userconfirmtiondata.Id);
                //TempData["Message"] = "Password Reset Successfully";
                //TempData["Status"] = "1";

                return View(abc);
                //return View("ConfirmPassword", abc);
            }



            TempData["Status"] = "3";
            TempData["Message"] = "Please Verify your OTP from Your Mail Account";
            return View("Login");

        }


        [HttpPost]
        public IActionResult ForgetPasswordOTP(ForgetPasswordOTPViewModel model)
        {

            var weburl = Request.Host.Value;
            ViewBag.weburl = weburl.Trim();
            HttpContext.Session.SetString("weburl", weburl);


            if (model.Email.Length > 0 && model.PhoneNo.Length > 0 && model.OTP.Length > 0)
            {

                var userconfirmtiondata = userAccountRepository.All(false).Where(x => x.Email == model.Email && x.PhoneNumber == model.PhoneNo && x.OTP == model.OTP).FirstOrDefault();



                //userconfirmtiondata.OTP = null;
                //userAccountRepository.Update(userconfirmtiondata, userconfirmtiondata.Id);

                if (userconfirmtiondata != null)
                {
                    ChangePasswordViewModel abc = new ChangePasswordViewModel();

                    abc.EmailOrPhone = model.Email;
                    //abc.PhoneNo = model.PhoneNo;
                    //userconfirmtiondata.IsEmailVerified = true;

                    //userAccountRepository.Update(userconfirmtiondata, userconfirmtiondata.Id);
                    //TempData["Message"] = "Password Reset Successfully";
                    //TempData["Status"] = "1";

                    return View("ConfirmPassword", abc);
                }

            }


            TempData["Status"] = "3";
            TempData["Message"] = "Please Verify your OTP from Your Mail Account";
            return View(model);

        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        //public ActionResult Signup(SigninViewModel signinmodel)
        public IActionResult ForgetPassword(ForgetPasswordViewModel signinmodel)
        {
            var errors = ModelState.Where(x => x.Value.Errors.Any())
            .Select(x => new { x.Key, x.Value.Errors });

            try
            {
                if (ModelState.IsValid)
                {
                    var OTPvalue = ValuesController.randomnumbergenerate(6, 105011, 999999).ToString();

                    var abc = userAccountRepository.All(false).Where(x => (x.Email.ToLower() == signinmodel.EmailOrPhone.ToLower()) || (x.PhoneNumber.ToLower() == signinmodel.EmailOrPhone.ToLower())).FirstOrDefault(); //&& x.PhoneNumber.ToLower().Contains(signinmodel.PhoneNo.ToLower()) 

                    if (abc != null)
                    {
                        abc.OTP = OTPvalue;
                        userAccountRepository.Update(abc, abc.Id);

                        //var callBackUrl = Url.ActionLink("PasswordReset", "Home", new { Email = signinmodel.Email, PhoneNumber = signinmodel.PhoneNo, OTPValue = OTPvalue });
                        //var callBackUrlQuery = Url.ActionLink("PasswordResetQuery", "Home") + "/" + signinmodel.Email + "/" + signinmodel.PhoneNo + "/" + OTPvalue.ToString();

                        if (signinmodel.EmailOrPhone != null)
                        {
                            string mailList = abc.Email;
                            string subject = $"Password Reset";
                            //string body = $"Password Reset Email. <br/><br/> Created Time : - {DateTime.Now}<br/> To Reset Your Password, Please follow the link <br/><br/><a href='{HtmlEncoder.Default.Encode(callBackUrl)}'>Reset Your password by Clicking Here</a>";
                            string body = $"Password Reset Email. <br/><br/> Created Time : - {DateTime.Now}<br/> Your Confirmation OTP is  " + OTPvalue + "";

                            //var hostaddressforsender = Request.GetTypedHeaders().Host.Value;
                            //SendEmail(mailList, subject, body, hostaddressforsender);
                            _emailsender.SendEmailAsync(mailList, subject, body);
                            //_smsSender.SendSmsAsync(signinmodel.PhoneNo, $"Your Confirmation OTP is " + OTPvalue + "");
                            _smsSender.SendSmsAsync(abc.PhoneNumber, $"Your Confirmation OTP is " + OTPvalue + "");

                        }


                        TempData["Message"] = "Check Your Mail to Reset Your Password";
                        TempData["Status"] = "1";

                        return RedirectToAction("ForgetPasswordOTP", new { Email = abc.Email, PhoneNo = abc.PhoneNumber });


                        //return RedirectToAction("Login");

                    }
                    else
                    {
                        TempData["Message"] = "Wrong user Informtion";
                        TempData["Status"] = "3";

                        return RedirectToAction("Login");
                    }



                }

                return RedirectToAction("Login");

            }
            catch (Exception e)
            {


                errorlog(e);

                //TempData["FFMsg"] = "Something wrong! Contact with Administrator!";
                TempData["FFMsg"] = e.Message.ToString();
                ViewBag.Country = _countryRepository.GetAllForDropDown();
                //ViewBag.BusinessType = _businessTypeRepository.GetAllForDropDown();
                //ViewBag.SubscriptionType = _subscriptionTypeRepository.GetAllForDropDown();

                return Json(new { Success = 0, ex = e.Message });

                //return Json(new { Success = 1, accname = signinmodel.Email, ex = "User Registered Successfully." });

                //return View(signinmodel);
            }
        }

        [HttpGet]
        public IActionResult PasswordReset(string Email, string PhoneNumber, int OTPValue = 0)
        {

            var weburl = Request.Host.Value;
            ViewBag.weburl = weburl.Trim();
            HttpContext.Session.SetString("weburl", weburl);

            var userconfirmtiondata = userAccountRepository.All(false).Where(x => x.Email == Email && x.PhoneNumber == PhoneNumber && x.OTP == OTPValue.ToString()).FirstOrDefault();



            //userconfirmtiondata.OTP = null;
            //userAccountRepository.Update(userconfirmtiondata, userconfirmtiondata.Id);

            if (userconfirmtiondata != null)
            {
                ChangePasswordViewModel abc = new ChangePasswordViewModel();

                abc.EmailOrPhone = Email;
                //abc.PhoneNo = PhoneNumber;
                //userconfirmtiondata.IsEmailVerified = true;

                //userAccountRepository.Update(userconfirmtiondata, userconfirmtiondata.Id);
                //TempData["Message"] = "Password Reset Successfully";
                //TempData["Status"] = "1";

                return View("ConfirmPassword", abc);
            }

            TempData["Status"] = "3";
            TempData["Message"] = "Please Verify your Link and OTP with Mail and Phone No from Your Mail Account";
            return View("Login");

        }


        public IActionResult ResendOTPEmailConfirmation(string EmailorPhone)
        {
            var errors = ModelState.Where(x => x.Value.Errors.Any())
                        .Select(x => new { x.Key, x.Value.Errors });

            try
            {
                if (ModelState.IsValid)
                {
                    var OTPvalue = ValuesController.randomnumbergenerate(6, 105011, 999999).ToString();

                    var abc = userAccountRepository.All(false).Where(x => (x.Email.ToLower() == EmailorPhone.ToLower()) || (x.PhoneNumber.ToLower() == EmailorPhone.ToLower())).FirstOrDefault();

                    if (abc != null)
                    {
                        abc.OTP = OTPvalue;
                        userAccountRepository.Update(abc, abc.Id);

                        if (abc != null)
                        {
                            string mailList = abc.Email;
                            //string subject = $"Email Confirmation OTP";
                            //string body = $"User Account Confirmation Email. <br/><br/> Created Time : - {DateTime.Now}<br/> Your Confirmation OTP is  " + OTPvalue + "";


                            string subject = $"Care Customer Service";
                            string body = $"Dear Sir,<br/><br/>Greetings from GTR!<br/><br/>Your Request has been successfully submitted at our end. <br/><br/>Your Confirmation OTP : <h1><b>{OTPvalue}</b></h1> Thanks for being with us. <br/> <br/> Sincerely,<br/> Care Service<br/> Dominate Software Solution.";



                            //var hostaddressforsender = Request.GetTypedHeaders().Host.Value;
                            //SendEmail(mailList, subject, body, hostaddressforsender);
                            _emailsender.SendEmailAsync(mailList, subject, body);
                            _smsSender.SendSmsAsync(abc.PhoneNumber, $"Your Confirmation OTP is " + OTPvalue + "");
                        }


                        TempData["Message"] = "Put Your OTP to Confirm Your Account.";
                        TempData["Status"] = "1";

                        //return RedirectToAction("EmailConfirmation", new { Email = abc.Email, PhoneNo = abc.PhoneNumber });
                        return RedirectToAction("OTPConfirmation", new { Email = abc.Email, PhoneNo = abc.PhoneNumber });


                        //return RedirectToAction("Login");

                    }
                    else
                    {
                        TempData["Message"] = "Wrong user Informtion";
                        TempData["Status"] = "3";

                        //return RedirectToAction("EmailConfirmation", new { Email = abc.Email, PhoneNo = abc.PhoneNumber });
                        return RedirectToAction("OTPConfirmation", new { Email = abc.Email, PhoneNo = abc.PhoneNumber });
                    }



                }

                return RedirectToAction("Login");

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }



        [HttpGet]
        [Route("{Home}/{PasswordReset}/{Email}/{PhoneNumber}/{OTPValue}")]
        public IActionResult PasswordResetQuery(string Email, string PhoneNumber, int OTPValue = 0)
        {

            var weburl = Request.Host.Value;
            ViewBag.weburl = weburl.Trim();
            HttpContext.Session.SetString("weburl", weburl);

            var userconfirmtiondata = userAccountRepository.All(false).Where(x => x.Email == Email && x.PhoneNumber == PhoneNumber && x.OTP == OTPValue.ToString()).FirstOrDefault();



            //userconfirmtiondata.OTP = null;
            //userAccountRepository.Update(userconfirmtiondata, userconfirmtiondata.Id);

            if (userconfirmtiondata != null)
            {
                ChangePasswordViewModel abc = new ChangePasswordViewModel();

                abc.EmailOrPhone = Email;
                //abc.PhoneNo = PhoneNumber;
                //userconfirmtiondata.IsEmailVerified = true;

                //userAccountRepository.Update(userconfirmtiondata, userconfirmtiondata.Id);
                //TempData["Message"] = "Password Reset Successfully";
                //TempData["Status"] = "1";

                return View("ConfirmPassword", abc);
            }

            TempData["Status"] = "3";
            TempData["Message"] = "Please Verify your Link and OTP with Mail and Phone No from Your Mail Account";
            return View("Login");

        }



        [HttpPost]
        public IActionResult ConfirmPassword(ChangePasswordViewModel signinmodel)
        {

            var weburl = Request.Host.Value;
            ViewBag.weburl = weburl.Trim();
            HttpContext.Session.SetString("weburl", weburl);

            var userconfirmtiondata = userAccountRepository.All(false).Where(x => (x.Email == signinmodel.EmailOrPhone) || (x.PhoneNumber == signinmodel.EmailOrPhone)).FirstOrDefault();

            //userconfirmtiondata.OTP = null;
            //userAccountRepository.Update(userconfirmtiondata, userconfirmtiondata.Id);

            if (userconfirmtiondata != null)
            {
                userconfirmtiondata.Password = signinmodel.Password;
                userconfirmtiondata.OTP = null;

                userAccountRepository.Update(userconfirmtiondata, userconfirmtiondata.Id);

                TempData["Message"] = "Password Reset Successfully";
                TempData["Status"] = "1";

                //return View("Login");
                return RedirectToAction("Login", "Home");
            }

            TempData["Status"] = "3";
            TempData["Message"] = "Please Verify your Link and OTP with Mail and Phone No from Your Mail Account";
            //return View("Login");
            //return RedirectToAction("Login", "Home");
            return View();

        }


        [HttpGet]
        public ActionResult DeliveryService()
        {
            ViewBag.Country = _countryRepository.GetAllForDropDown();
            ViewBag.BusinessType = _businessTypeRepository.GetAllForDropDown();
            ViewBag.FiscalYearType = _fiscalYearTypeRepository.GetAllForDropDown();
            ViewBag.SubscriptionType = _subscriptionTypeRepository.GetAllForDropDown();


            return View();
        }

        [HttpGet]
        public ActionResult AccessDenied()
        {
            ViewBag.Message = "Access Denied";

            return View();
        }

        [HttpGet]
        public IActionResult AccessDeniedJson()
        {
            ViewBag.Message = "Access Denied";
            return Json(new { success = "-1", error = false, message = "Access Denied", Id = -1 });
            //return View();
        }

        [HttpGet]
        public ActionResult NotFound()
        {
            ViewBag.Message = "404 Not Found";

            return View();
        }
        [HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult Signup(SigninViewModel signinmodel)
        public JsonResult Signup(SigninViewModel signinmodel)
        {
            var errors = ModelState.Where(x => x.Value.Errors.Any())
            .Select(x => new { x.Key, x.Value.Errors });

            try
            {
                if (ModelState.IsValid)
                {

                    var alreadyemailfound = userAccountRepository.All(false).Where(x => x.Email == signinmodel.Email).ToList().Count();
                    if (alreadyemailfound > 0)
                    {

                        return Json(new { Success = 0, ex = new Exception("Email Already Taken . Please Try with another Mail address").Message.ToString() });

                    }

                    var alreadyphonefound = userAccountRepository.All(false).Where(x => x.PhoneNumber == signinmodel.PhoneNumber).ToList().Count();
                    if (alreadyphonefound > 0)
                    {

                        return Json(new { Success = 0, ex = new Exception("Phone Already Taken . Please Try with another Phone").Message.ToString() });

                    }


                    //CompanyModel com = new CompanyModel();
                    //com.CompanyName = signinmodel.CompanyName ?? "";
                    //com.comPhone = signinmodel.PhoneNumber ?? "";
                    //com.ContPerson = signinmodel.ContactName ?? "";
                    //com.comEmail = signinmodel.Email ?? "";
                    //com.BusinessTypeId = signinmodel.BusinessTypeId;
                    //com.SubscriptionTypeId = signinmodel.SubscriptionTypeId;
                    //com.CountryId = signinmodel.CountryId;
                    //com.comWeb = signinmodel.Web ?? "";
                    //com.PrimaryAddress = signinmodel.BusinessAddress ?? "";
                    //com.CompanyShortName = signinmodel.CompanyShortName ?? "";
                    //com.ContDesig = signinmodel.ContactDesig ?? "";






                    //int comid = companyRepository.Insert(com);
                    //HttpContext.Session.SetString("ComIdString", comid.ToString());
                    //HttpContext.Session.SetInt32("ComId", comid);
                    ////var abcd = HttpContext.Session.GetString("comid");

                    UserAccountModel model = new UserAccountModel();
                    //model.ComId = comid;
                    model.Email = signinmodel.Email;
                    model.Password = signinmodel.Password;
                    model.Name = signinmodel.ContactName;
                    model.UserRoleId = 2;
                    model.IsBaseUser = true;
                    model.PhoneNumber = signinmodel.PhoneNumber;
                    model.OTP = ValuesController.randomnumbergenerate(6, 105000, 999999).ToString();
                    model.ComId = 0;

                    var userid = userAccountRepository.Insert(model);

                    //HttpContext.Session.SetInt32("UserId", 0);
                    //int userid = userAccountRepository.InsertInt(model);
                    ////userid = userid == null ? 0 : int.Parse(userid.ToString());
                    //HttpContext.Session.SetString("UserIdString", userid.ToString());
                    //HttpContext.Session.SetInt32("UserId", userid);
                    ////userid == null ? 0 : userid.ToString();



                    //StoreSettingModel storesettings = new StoreSettingModel();
                    //storesettings.StoreName = signinmodel.CompanyName ?? "";
                    //storesettings.Phone = signinmodel.PhoneNumber ?? "";
                    //storesettings.Email = signinmodel.Email ?? "";
                    //storesettings.Web = signinmodel.Web ?? "";
                    //storesettings.BusinessTypeId = signinmodel.BusinessTypeId;
                    //storesettings.SubscriptionTypeId = signinmodel.SubscriptionTypeId;
                    //storesettings.TimeZoneSettingsId = 36; //////////////////timezone by fahad
                    //storesettings.SalesReportStyleId = int.Parse(_reportStyleRepository.GetAllInvoiceReportForDropDown().FirstOrDefault().Value);
                    //storesettings.PurchaseReportStyleId = int.Parse(_reportStyleRepository.GetAllPurchaseReportForDropDown().FirstOrDefault().Value);
                    //storesettings.BarcodeReportStyleId = int.Parse(_reportStyleRepository.GetAllBarcodeReportForDropDown().FirstOrDefault().Value);



                    ////storesettings.Currency = "BDT ";
                    //storesettings.CountryId = signinmodel.CountryId;


                    //storesettings.Address = "=N/A=";
                    //storesettings.Logo = "/Content/Storeimages/0.png";
                    //storesettings.ComId = comid;
                    //storesettings.BaseComId = comid;



                    //storesettings.TaxPer = 0;
                    //storesettings.isTaxExcluded = false;
                    ////storesettings.SalesReportStyleId = 2;
                    ////storesettings.PurchaseReportStyleId = 2;

                    //storesettings.isChequeDetails = false;
                    //storesettings.isMultiCurrency = false;
                    //storesettings.isMultiDebitCredit = false;
                    //storesettings.isVoucherDistributionEntry = false;

                    //storesettings.isSMSService = false;
                    //storesettings.isEmailSerivce = false;




                    ////storesettings.Email = signinmodel.Email;

                    //storeSettingRepository.Insert(storesettings);



                    //var UserId = HttpContext.Session.GetInt32("UserId");
                    //var companypermission = new CompanyPermissionModel();
                    //companypermission.LuserId = userid;
                    //companypermission.ComId = comid;

                    //_companyPermissionRepository.Insert(companypermission);



                    //var validitydays = _subscriptionTypeRepository.Find(signinmodel.SubscriptionTypeId.GetValueOrDefault()).ValidityDay;

                    //SubscriptionActivationModel subscriptionActivation = new SubscriptionActivationModel();
                    //subscriptionActivation.IsActive = true;
                    //subscriptionActivation.IsDelete = false;
                    //subscriptionActivation.LuserId = userid;
                    //subscriptionActivation.Remarks = "Auto Entry by System";
                    //subscriptionActivation.SubscriptionTypeId = signinmodel.SubscriptionTypeId;
                    //subscriptionActivation.ActiveFromDate = DateTime.Now.Date;
                    //subscriptionActivation.ActiveToDate = DateTime.Now.Date.AddDays(validitydays);
                    //_subscriptionActivationRepository.Insert(subscriptionActivation);




                    //SubscriptionActivationCompanyModel subscriptionActivationCompany = new SubscriptionActivationCompanyModel();
                    //subscriptionActivationCompany.IsActive = true;
                    //subscriptionActivationCompany.IsDelete = false;
                    //subscriptionActivationCompany.Remarks = "Auto Entry by System";
                    //subscriptionActivationCompany.SubscriptionTypeId = signinmodel.SubscriptionTypeId;
                    //subscriptionActivationCompany.ActiveFromDate = DateTime.Now.Date;
                    //subscriptionActivationCompany.ActiveToDate = DateTime.Now.Date.AddDays(validitydays);
                    //subscriptionActivationCompany.ComId = comid;
                    //_subscriptionActivationCompanyRepository.Insert(subscriptionActivationCompany);


                    ////////Auto Unit Input by System 
                    //UnitModel Units = new UnitModel();
                    //Units.UnitName = "Pcs";
                    //Units.UnitShortName = "Pcs";
                    //Units.UnitNameBangla = "";
                    //_unitRepository.Insert(Units);


                    //var businesstypename = _businessTypeRepository.Find(storesettings.BusinessTypeId).BusinessTypeName;
                    //if (businesstypename.ToLower().Contains("walton") || businesstypename.ToLower().Contains("marcel"))
                    //{
                    //    //////Auto Category Input by System 
                    //    CategoryModel categorydata = new CategoryModel();
                    //    categorydata.Name = "Electronics";
                    //    categorydata.Description = "Electronics";
                    //    _categoryRepository.Insert(categorydata);
                    //}
                    //else
                    //{
                    //    //////Auto Category Input by System 
                    //    CategoryModel categorydata = new CategoryModel();
                    //    categorydata.Name = "=N/A=";
                    //    categorydata.Description = "=N/A=";
                    //    _categoryRepository.Insert(categorydata);
                    //}



                    //CustomerModel customerdata = new CustomerModel();
                    //customerdata.Name = "Walk In Customer";
                    //customerdata.Phone = "";
                    //customerdata.ComId = comid;
                    //_customerRepository.Insert(customerdata);


                    //SupplierModel supplierdata = new SupplierModel();
                    //supplierdata.SupplierName = "Cash Supplier";
                    //supplierdata.Phone = "";
                    //supplierdata.ComId = comid;
                    //_supplierRepository.Insert(supplierdata);


                    //WarehouseModel warehousedata = new WarehouseModel();
                    //warehousedata.WhName = "Main";
                    //warehousedata.WhShortName = "Main";
                    //warehousedata.WhType = "L";
                    //warehousedata.ComId = comid;
                    //_warehouseRepository.Insert(warehousedata);


                    //if (signinmodel.BusinessTypeId > 0)
                    //{
                    //    var businesstypename = _businessTypeRepository.Find(signinmodel.BusinessTypeId).BusinessTypeName.ToLower();

                    //    if (businesstypename.Contains("waltonmarcel"))
                    //    {
                    //        SqlParameter[] sqlParameter1 = new SqlParameter[3];
                    //        sqlParameter1[0] = new SqlParameter("@comId", comid);
                    //        sqlParameter1[1] = new SqlParameter("@TableName", "AccountHead");
                    //        sqlParameter1[2] = new SqlParameter("@BrandName", businesstypename);

                    //        Helper.ExecProc("prcAutoInsert", sqlParameter1);
                    //    }

                    //}


                    //fahad
                    //var businesstypeinfo =  _businessTypeRepository.Find(signinmodel.BusinessTypeId);
                    //if (businesstypeinfo.IsAccounts == true)
                    //{
                    //    ///Account Data Auto Insert
                    //    SqlParameter[] sqlParameter = new SqlParameter[2];
                    //    sqlParameter[0] = new SqlParameter("@comId", comid);
                    //    sqlParameter[1] = new SqlParameter("@TableName", "AccountHead");
                    //    //sqlParameter[2] = new SqlParameter("@BrandName", "");

                    //    Helper.ExecProc("prcAutoInsert", sqlParameter);
                    //    ///Account Data Auto Insert


                    //    var fiscalyearinfo = _fiscalYearTypeRepository.Find(signinmodel.FiscalYearTypeId.GetValueOrDefault());
                    //    ///fiscal year Creation
                    //    var PrevYear = DateTime.Now.Year - 1;
                    //    var fromdate = new DateTime(PrevYear, 1, 1);
                    //    var todate = new DateTime(PrevYear, 12, 31);

                    //    SqlParameter[] sqlParameterfy = new SqlParameter[4];
                    //    sqlParameterfy[0] = new SqlParameter("@comid", comid);
                    //    sqlParameterfy[1] = new SqlParameter("@dtFrom", fromdate);
                    //    sqlParameterfy[2] = new SqlParameter("@dtTo", todate);
                    //    sqlParameterfy[3] = new SqlParameter("@UserId", userid);
                    //    Helper.ExecProc("Acc_prcCloseFiscalYearManual", sqlParameterfy);
                    //    ///fiscal year Creation
                    //}



                    TempData["Message"] = "User Created Successfully";
                    TempData["Status"] = "1";




                    var OTPvalue = model.OTP;// ValuesController.randomnumbergenerate(6, 105000, 999999).ToString();
                    //var callBackUrl = Url.ActionLink("UserConfirmation", "Home", new { Email = signinmodel.Email, OTPValue = OTPvalue });
                    //var callBackUrlQuery = Url.ActionLink("UserConfirmationQuery", "Home") + "/" + signinmodel.Email + "/" + OTPvalue.ToString();



                    var weburl = Request.Host.Value;
                    ViewBag.weburl = weburl.Trim();
                    HttpContext.Session.SetString("weburl", weburl);


                    if (signinmodel.Email != null)
                    {
                        var hostaddressforsender = Request.GetTypedHeaders().Host.Value;
                        string mailList = signinmodel.Email;
                        //string subject = $"{hostaddressforsender} - Email Confirmation  {signinmodel.CompanyName}";
                        //string body = $"Dear Sir, <br/> Thank you for using Domiante Easy Invoice for {signinmodel.CompanyName} . <br/><br/> Create Time : - {DateTime.Now}<br/> To Activate your account please click <a href='{HtmlEncoder.Default.Encode(callBackUrl)}'> here</a> <br/> <br/> For all kind of support please call Us 01709383003 . <br/> Best Wishes <br/> w2u.io";


                        string subject = $"Care Customer Service";
                        string body = $"Dear Sir,<br/><br/>Greetings from PQSTEC!<br/><br/>Your Request has been successfully submitted at our end. <br/><br/>Your Confirmation OTP : <h1><b>{OTPvalue}</b></h1> Thanks for being with us. <br/> <br/> Sincerely,<br/> Care Service<br/> Dominate Software Solution.";



                        //string body = $"Dear Sir, <br/> Thank you for using Domiante Easy Invoice for {signinmodel.CompanyName} . <br/><br/> Create Time : - {DateTime.Now}<br/> To Activate your account please use this OTP "+ OTPvalue +"> <br/> <br/> For all kind of support please call Us 01709383003 . <br/> Best Wishes <br/> "+  weburl + ""; //w2u.io "

                        //SendEmail(mailList, subject, body, hostaddressforsender);
                        _emailsender.SendEmailAsync(mailList, subject, body);

                        _smsSender.SendSmsAsync(signinmodel.PhoneNumber, $"Dear Sir, Thank you for using Domiante Easy Invoice for {signinmodel.CompanyName}.Your Confirmation OTP {OTPvalue}. For any kind of support please call Us 01709383003."); ;
                        ////_smsSender.SendSmsAsync(signinmodel.PhoneNumber, $"Dear Sir, Thank you for using Domiante Easy Invoice for {signinmodel.CompanyName}.To Activate your account please follow the link. {callBackUrlQuery} For any kind of support please call Us 01709383003.");
                        ////_smsSender.SendSmsAsync(signinmodel.PhoneNumber, $"Dear Sir, Thank you for using Domiante Easy Invoice for {signinmodel.CompanyName}.Your Confirmation OTP "+ OTPvalue +". For any kind of support please call Us 01709383003.");



                        //_emailsender.SendEmailAsync(mailList, subject, body);



                    }


                    //return Json(data: new { success = true, message = "Successfully Registerd" }, JsonRequesBehaviour.AllowGet);

                    return Json(new { Success = 1, accname = signinmodel.Email, ex = "User Registered Successfully." });

                    //return RedirectToAction("Login");
                    //model.


                }

                return Json(new { Success = 1, accname = signinmodel.Email, ex = "User Registered Successfully." });

                //return RedirectToAction("Login");

            }
            catch (Exception e)
            {


                errorlog(e);

                //TempData["FFMsg"] = "Something wrong! Contact with Administrator!";
                TempData["FFMsg"] = e.Message.ToString();
                ViewBag.Country = _countryRepository.GetAllForDropDown();
                ViewBag.BusinessType = _businessTypeRepository.GetAllForDropDown();
                ViewBag.FiscalYearType = _fiscalYearTypeRepository.GetAllForDropDown();
                ViewBag.SubscriptionType = _subscriptionTypeRepository.GetAllForDropDown();

                return Json(new { Success = 0, ex = e.Message });

                //return Json(new { Success = 1, accname = signinmodel.Email, ex = "User Registered Successfully." });

                //return View(signinmodel);
            }
        }






        [HttpPost]
        public JsonResult SendMail(string emailContent, string emailSubject)
        {
            try
            {
                if (!string.IsNullOrEmpty(emailContent))
                {
                    var email = "immahin96@gmail.com";

                    if (email != null)
                    {
                        // Add necessary code for sending emails here
                        // For example, using your existing email sending logic
                        _emailsender.SendEmailAsync(email, emailSubject, emailContent);
                    }

                    return Json(new { Success = 1, Message = "Email sent." });
                }

                return Json(new { Success = 0, Message = "Email content is empty." });
            }
            catch (Exception ex)
            {
                // Log the exception
                errorlog(ex);

                return Json(new { Success = 0, Message = ex.Message });
            }
        }





        //[HttpPost]
        //[ValidateAntiForgeryToken]
        ////public ActionResult Signup(SigninViewModel signinmodel)
        //public JsonResult SignupURL(SigninViewModel signinmodel)
        //{


        //    var errors = ModelState.Where(x => x.Value.Errors.Any())
        //    .Select(x => new { x.Key, x.Value.Errors });

        //    try
        //    {
        //        if (ModelState.IsValid)
        //        {

        //            var alreadyemailfound = userAccountRepository.All(false).Where(x => x.Email == signinmodel.Email).ToList().Count();
        //            if (alreadyemailfound > 0)
        //            {

        //                return Json(new { Success = 0, ex = new Exception("Email Already Taken . Please Try with another Mail address").Message.ToString() });

        //            }

        //            var alreadyphonefound = userAccountRepository.All(false).Where(x => x.PhoneNumber == signinmodel.PhoneNumber).ToList().Count();
        //            if (alreadyphonefound > 0)
        //            {

        //                return Json(new { Success = 0, ex = new Exception("Phone Already Taken . Please Try with another Phone").Message.ToString() });

        //            }

        //            signinmodel.BusinessTypeId = _businessTypeRepository.All().Where(x => x.BusinessTypeName.Contains("URL Shortener")).FirstOrDefault().Id;
        //            signinmodel.SubscriptionTypeId = _subscriptionTypeRepository.All().Where(x => x.SubscriptionName.Contains("Monthly Subscription")).FirstOrDefault().Id;

        //            signinmodel.Web = "www.w2u.io";



        //            CompanyModel com = new CompanyModel();
        //            com.CompanyName = signinmodel.CompanyName ?? "";
        //            com.comPhone = signinmodel.PhoneNumber ?? "";
        //            com.ContPerson = signinmodel.ContactName ?? "";
        //            com.comEmail = signinmodel.Email ?? "";
        //            com.BusinessTypeId = signinmodel.BusinessTypeId;
        //            com.SubscriptionTypeId = signinmodel.SubscriptionTypeId;
        //            com.CountryId = signinmodel.CountryId;
        //            com.comWeb = signinmodel.Web ?? "";
        //            com.PrimaryAddress = signinmodel.BusinessAddress ?? "";
        //            com.CompanyShortName = signinmodel.CompanyShortName ?? "";
        //            com.ContDesig = signinmodel.ContactDesig ?? "";







        //            int comid = companyRepository.Insert(com);
        //            HttpContext.Session.SetString("ComIdString", comid.ToString());
        //            HttpContext.Session.SetInt32("ComId", comid);
        //            //var abcd = HttpContext.Session.GetString("comid");

        //            var OTPvalue = ValuesController.randomnumbergenerate(4, 1050, 9999).ToString();





        //            UserAccountModel model = new UserAccountModel();
        //            model.ComId = comid;
        //            model.Email = signinmodel.Email;
        //            model.Password = signinmodel.Password;
        //            model.Name = signinmodel.ContactName;
        //            model.UserRoleId = 2;
        //            model.IsBaseUser = true;
        //            model.PhoneNumber = signinmodel.PhoneNumber;
        //            model.OTP = OTPvalue;



        //            HttpContext.Session.SetInt32("UserId", 0);
        //            int userid = userAccountRepository.InsertInt(model);
        //            //userid = userid == null ? 0 : int.Parse(userid.ToString());
        //            HttpContext.Session.SetString("UserIdString", userid.ToString());
        //            HttpContext.Session.SetInt32("UserId", userid);
        //            //userid == null ? 0 : userid.ToString();



        //            StoreSettingModel storesettings = new StoreSettingModel();
        //            storesettings.StoreName = signinmodel.CompanyName;
        //            storesettings.Phone = signinmodel.PhoneNumber;
        //            storesettings.Email = signinmodel.Email;
        //            storesettings.Web = signinmodel.Web;
        //            storesettings.BusinessTypeId = signinmodel.BusinessTypeId;
        //            storesettings.SubscriptionTypeId = signinmodel.SubscriptionTypeId;
        //            storesettings.TimeZoneSettingsId = 36;
        //            storesettings.SalesReportStyleId = _reportStyleRepository.All().FirstOrDefault().Id;
        //            storesettings.PurchaseReportStyleId = _reportStyleRepository.All().FirstOrDefault().Id;


        //            //storesettings.Currency = "BDT ";
        //            storesettings.CountryId = signinmodel.CountryId;


        //            storesettings.Address = "=N/A=";
        //            storesettings.Logo = "/Images/w2u.png";
        //            storesettings.ComId = comid;
        //            storesettings.BaseComId = comid;



        //            storesettings.TaxPer = 0;
        //            storesettings.isTaxExcluded = false;
        //            storesettings.SalesReportStyleId = 2;
        //            storesettings.isChequeDetails = false;
        //            storesettings.isMultiCurrency = false;
        //            storesettings.isMultiDebitCredit = false;
        //            storesettings.isVoucherDistributionEntry = false;


        //            storesettings.isSMSService = false;
        //            storesettings.isEmailSerivce = false;



        //            //storesettings.Email = signinmodel.Email;

        //            storeSettingRepository.Insert(storesettings);



        //            var UserId = HttpContext.Session.GetInt32("UserId");
        //            var companypermission = new CompanyPermissionModel();
        //            companypermission.LuserId = userid;
        //            companypermission.ComId = comid;

        //            _companyPermissionRepository.Insert(companypermission);




        //            var validitydays = 15;// _subscriptionTypeRepository.Find(signinmodel.SubscriptionTypeId.GetValueOrDefault()).ValidityDay;

        //            SubscriptionActivationModel subscriptionActivation = new SubscriptionActivationModel();
        //            subscriptionActivation.IsActive = true;
        //            subscriptionActivation.IsDelete = false;
        //            subscriptionActivation.LuserId = userid;
        //            subscriptionActivation.Remarks = "Auto Entry by System";
        //            subscriptionActivation.SubscriptionTypeId = signinmodel.SubscriptionTypeId;
        //            subscriptionActivation.ActiveFromDate = DateTime.Now.Date;
        //            subscriptionActivation.ActiveToDate = DateTime.Now.Date.AddDays(validitydays);
        //            _subscriptionActivationRepository.Insert(subscriptionActivation);


        //            SubscriptionActivationCompanyModel subscriptionActivationCompany = new SubscriptionActivationCompanyModel();
        //            subscriptionActivationCompany.IsActive = true;
        //            subscriptionActivationCompany.IsDelete = false;
        //            subscriptionActivationCompany.Remarks = "Auto Entry by System";
        //            subscriptionActivationCompany.SubscriptionTypeId = signinmodel.SubscriptionTypeId;
        //            subscriptionActivationCompany.ActiveFromDate = DateTime.Now.Date;
        //            subscriptionActivationCompany.ActiveToDate = DateTime.Now.Date.AddDays(validitydays);
        //            subscriptionActivationCompany.ComId = comid;
        //            _subscriptionActivationCompanyRepository.Insert(subscriptionActivationCompany);



        //            var callBackUrl = Url.ActionLink("UserConfirmation", "Home", new { Email = signinmodel.Email, OTPValue = OTPvalue });
        //            var callBackUrlQuery = Url.ActionLink("UserConfirmationQuery", "Home") + "/" + signinmodel.Email + "/" + OTPvalue.ToString();

        //            if (signinmodel.Email != null)
        //            {
        //                var hostaddressforsender = Request.GetTypedHeaders().Host.Value;
        //                string mailList = signinmodel.Email;
        //                //string subject = $"{hostaddressforsender} - Email Confirmation  {signinmodel.CompanyName}";
        //                //string body = $"Dear Sir, <br/> Thank you for using W2U URL shortener for {signinmodel.CompanyName} . <br/><br/> Create Time : - {DateTime.Now}<br/> To Activate your account please click <a href='{HtmlEncoder.Default.Encode(callBackUrl)}'> here</a> <br/> <br/> For all kind of support please call Us 01709383003 . <br/> Best Wishes <br/> w2u.io";

        //                string subject = $"Care Customer Service";
        //                string body = $"Dear Sir,<br/><br/>Greetings from w2u.io!<br/><br/>Thank you for using W2U URL shortener for {signinmodel.CompanyName}. <br/><br/>Your Confirmation OTP : <h1><b>{OTPvalue}</b></h1> Thanks for being with us. <br/> <br/> Sincerely,<br/> Care Service<br/> Dominate Software Solution. <br/> <br/> For all kind of support please call Us 01709383003 . <br/> Best Wishes <br/> w2u.io";




        //                //SendEmail(mailList, subject, body, hostaddressforsender);
        //                _emailsender.SendEmailAsync(mailList, subject, body);
        //                //_smsSender.SendSmsAsync(signinmodel.PhoneNumber, "Your Password Have changed successfully. Changing Time : - " + DateTime.Now);
        //                //_smsSender.SendSmsAsync(signinmodel.PhoneNumber, $"Dear Sir, Thank you for using W2U URL shortener for {signinmodel.CompanyName}.To Activate your account please follow the link. {callBackUrlQuery} For any kind of support please call Us 01709383003."); ;
        //                _smsSender.SendSmsAsync(signinmodel.PhoneNumber, $"Dear Sir, Thank you for using W2U URL shortener for {signinmodel.CompanyName}.Your Confirmation OTP {OTPvalue}. For any kind of support please call Us 01709383003."); ;

        //            }


        //            //////////Auto Unit Input by System 
        //            ////UnitModel Units = new UnitModel();
        //            ////Units.UnitName = "Pcs";
        //            ////Units.UnitShortName = "Pcs";
        //            ////Units.UnitNameBangla = "";
        //            ////_unitRepository.Insert(Units);


        //            ////var businesstypename = _businessTypeRepository.Find(storesettings.BusinessTypeId).BusinessTypeName;
        //            ////if (businesstypename.ToLower().Contains("walton") || businesstypename.ToLower().Contains("marcel"))
        //            ////{
        //            ////    //////Auto Category Input by System 
        //            ////    CategoryModel categorydata = new CategoryModel();
        //            ////    categorydata.Name = "Electronics";
        //            ////    categorydata.Description = "Electronics";
        //            ////    _categoryRepository.Insert(categorydata);
        //            ////}
        //            ////else
        //            ////{
        //            ////    //////Auto Category Input by System 
        //            ////    CategoryModel categorydata = new CategoryModel();
        //            ////    categorydata.Name = "=N/A=";
        //            ////    categorydata.Description = "=N/A=";
        //            ////    _categoryRepository.Insert(categorydata);
        //            ////}



        //            ////CustomerModel customerdata = new CustomerModel();
        //            ////customerdata.Name = "Walk In Customer";
        //            ////customerdata.Phone = "";
        //            ////customerdata.ComId = comid;
        //            ////_customerRepository.Insert(customerdata);


        //            ////SupplierModel supplierdata = new SupplierModel();
        //            ////supplierdata.SupplierName = "Cash Supplier";
        //            ////supplierdata.Phone = "";
        //            ////supplierdata.ComId = comid;
        //            ////_supplierRepository.Insert(supplierdata);


        //            ////WarehouseModel warehousedata = new WarehouseModel();
        //            ////warehousedata.WhName = "Main";
        //            ////warehousedata.WhShortName = "Main";
        //            ////warehousedata.WhType = "L";
        //            ////warehousedata.ComId = comid;
        //            ////_warehouseRepository.Insert(warehousedata);


        //            //if (signinmodel.BusinessTypeId > 0)
        //            //{
        //            //    var businesstypename = _businessTypeRepository.Find(signinmodel.BusinessTypeId).BusinessTypeName.ToLower();

        //            //    if (businesstypename.Contains("waltonmarcel"))
        //            //    {
        //            //        SqlParameter[] sqlParameter1 = new SqlParameter[3];
        //            //        sqlParameter1[0] = new SqlParameter("@comId", comid);
        //            //        sqlParameter1[1] = new SqlParameter("@TableName", "AccountHead");
        //            //        sqlParameter1[2] = new SqlParameter("@BrandName", businesstypename);

        //            //        Helper.ExecProc("prcAutoInsert", sqlParameter1);
        //            //    }

        //            //}


        //            //SqlParameter[] sqlParameter = new SqlParameter[2];
        //            //sqlParameter[0] = new SqlParameter("@comId", comid);
        //            //sqlParameter[1] = new SqlParameter("@TableName", "AccountHead");
        //            ////sqlParameter[2] = new SqlParameter("@BrandName", "");

        //            //Helper.ExecProc("prcAutoInsert", sqlParameter);


        //            TempData["Message"] = "User Created Successfully";
        //            TempData["Status"] = "1";

        //            //return Json(data: new { success = true, message = "Successfully Registerd" }, JsonRequesBehaviour.AllowGet);

        //            return Json(new { Success = 1, accname = signinmodel.Email, ex = "Registration Applied Successfully.Check Your eMail to Confirm Your Account." });

        //            //return RedirectToAction("Login");
        //            //model.


        //        }

        //        return Json(new { Success = 1, accname = signinmodel.Email, ex = "Registration Applied Successfully.Check Your eMail to Confirm Your Account." });

        //        //return RedirectToAction("Login");

        //    }
        //    catch (Exception e)
        //    {


        //        errorlog(e);

        //        //TempData["FFMsg"] = "Something wrong! Contact with Administrator!";
        //        TempData["FFMsg"] = e.Message.ToString();
        //        ViewBag.Country = _countryRepository.GetAllForDropDown();
        //        //ViewBag.BusinessType = _businessTypeRepository.GetAllForDropDown();
        //        //ViewBag.SubscriptionType = _subscriptionTypeRepository.GetAllForDropDown();

        //        return Json(new { Success = 0, ex = e.Message });

        //        //return Json(new { Success = 1, accname = signinmodel.Email, ex = "User Registered Successfully." });

        //        //return View(signinmodel);
        //    }
        //}


        //public IActionResult SendEmail(string email, string subject, string body, string senderaddress)
        //{
        //    try
        //    {



        //        var emailsettings = _emailSettingRepository.All(false).Where(x => x.IsActive == true).FirstOrDefault();

        //        var message = new MailMessage();
        //        message.From = new MailAddress(emailsettings.Sender, emailsettings.SenderName);
        //        MailAddress addressBCC = new MailAddress("fahad@gtrbd.net");
        //        //message.From = new MailAddress(config.GetSection("CredentialMail").Value, "Genuine Technology & Research Ltd.");
        //        //message.From = new MailAddress(_smtpConfig.Value.SenderAddress, senderaddress); //w2u User Mail Confirmation.


        //        string[] mailSplit = email.Split(", ");
        //        foreach (var mail in mailSplit)
        //        {
        //            message.To.Add(new MailAddress(mail));
        //        }

        //        message.Subject = subject;
        //        message.Body = body;
        //        message.Bcc.Add(addressBCC);

        //        message.IsBodyHtml = _smtpConfig.Value.IsBodyHTML; //true;

        //        using (var client = new SmtpClient())
        //        {
        //            //client.Host = "smtp.gmail.com";
        //            client.Host = emailsettings.MailServer; //"smtp.gmail.com";
        //            client.Port = emailsettings.MailPort;//587;
        //                                                 //client.Host = _smtpConfig.Value.Host; //"smtp.gmail.com";
        //                                                 //client.Port = _smtpConfig.Value.Port;//587;
        //            client.EnableSsl = _smtpConfig.Value.EnableSSL;// true;
        //                                                           //client.Credentials = new NetworkCredential(config.GetSection("CredentialMail").Value, config.GetSection("CredentialPassword").Value);
        //                                                           //client.Credentials = new NetworkCredential(_smtpConfig.Value.UserName, _smtpConfig.Value.Password);
        //            client.Credentials = new NetworkCredential(emailsettings.Sender, emailsettings.Password);



        //            client.Send(message);

        //        }

        //        return View();
        //    }
        //    catch (Exception ex)
        //    {

        //        throw ex;
        //    }
        //}


        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        public IActionResult Latest()
        {
            return View();
        }

        public IActionResult Error()
        {

            var ehf = HttpContext.Features.Get<IExceptionHandlerFeature>();
            ViewData["ErrorMessage"] = ehf.Error.Message;
            ViewData["ErrorInnerException"] = ehf.Error.InnerException;
            ViewData["ErrorLocation"] = ehf.Path;
            //ViewData["ErrorProcedure"] = ehf.Error.Procedure;


            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }




        public IActionResult EmailConfirmation(string Email, string PhoneNo)
        {

            var weburl = Request.Host.Value;
            ViewBag.weburl = weburl.Trim();
            HttpContext.Session.SetString("weburl", weburl);



            //var userconfirmtiondata = userAccountRepository.All(false).Where(x => x.Email == Email && x.PhoneNumber == PhoneNo).FirstOrDefault();
            var userconfirmtiondata = userAccountRepository.All().Where(x => x.Email == Email && x.PhoneNumber == PhoneNo).FirstOrDefault();




            //userconfirmtiondata.OTP = null;
            //userAccountRepository.Update(userconfirmtiondata, userconfirmtiondata.Id);

            if (userconfirmtiondata != null)
            {
                ForgetPasswordOTPViewModel abc = new ForgetPasswordOTPViewModel();

                abc.Email = Email;
                abc.PhoneNo = PhoneNo;
                //userconfirmtiondata.IsEmailVerified = true;

                //userAccountRepository.Update(userconfirmtiondata, userconfirmtiondata.Id);
                //TempData["Message"] = "Password Reset Successfully";
                //TempData["Status"] = "1";

                return View(abc);
                //return View("ConfirmPassword", abc);
            }



            TempData["Status"] = "3";
            TempData["Message"] = "Please Verify your OTP from Your Mail Account";
            return View("Login");


            //return View();
        }


        [HttpPost]
        public IActionResult EmailConfirmation(ForgetPasswordOTPViewModel model)
        {

            var weburl = Request.Host.Value;
            ViewBag.weburl = weburl.Trim();
            HttpContext.Session.SetString("weburl", weburl);


            if (model.Email.Length > 0 && model.PhoneNo.Length > 0 && model.OTP.Length > 0)
            {

                var userconfirmtiondata = userAccountRepository.All(false).Where(x => x.Email == model.Email && x.PhoneNumber == model.PhoneNo && x.OTP == model.OTP).FirstOrDefault();




                ////////////////////////////////////////////////




                var storesettingsdata = storeSettingRepository.All().Where(x => x.ComId == userconfirmtiondata.ComId).FirstOrDefault();


                //HttpContext.Session.GetString("ComIdString");
                //int ComId = HttpContext.Session.GetInt32("ComId");
                //var abcd = HttpContext.Session.GetString("comid");

                if (storesettingsdata == null)
                {

                    var OTPvalue = ValuesController.randomnumbergenerate(4, 1050, 9999).ToString();


                    var signinmodel = companyRepository.All().Where(x => x.Id == userconfirmtiondata.ComId).FirstOrDefault();


                    var comid = userconfirmtiondata.ComId;
                    var userid = userconfirmtiondata.Id;
                    HttpContext.Session.SetInt32("UserId", userid);
                    HttpContext.Session.SetInt32("ComId", comid);


                    StoreSettingModel storesettings = new StoreSettingModel();
                    storesettings.StoreName = signinmodel.CompanyName ?? "";
                    storesettings.Phone = signinmodel.comPhone ?? "";
                    storesettings.Email = signinmodel.comEmail ?? "";
                    storesettings.Web = signinmodel.comWeb ?? "";
                    storesettings.BusinessTypeId = signinmodel.BusinessTypeId;
                    storesettings.SubscriptionTypeId = signinmodel.SubscriptionTypeId;
                    storesettings.TimeZoneSettingsId = 36;
                    storesettings.SalesReportStyleId = _reportStyleRepository.All().FirstOrDefault().Id;
                    storesettings.PurchaseReportStyleId = _reportStyleRepository.All().FirstOrDefault().Id;

                    //storesettings.Currency = "BDT ";
                    storesettings.CountryId = 18;


                    storesettings.Address = "=N/A=";
                    storesettings.Logo = "/Content/Storeimages/0.png";
                    storesettings.ComId = comid;
                    storesettings.BaseComId = comid;



                    storesettings.TaxPer = 0;
                    storesettings.isTaxExcluded = false;
                    storesettings.SalesReportStyleId = 2;
                    storesettings.PurchaseReportStyleId = 2;

                    storesettings.isChequeDetails = false;
                    storesettings.isMultiCurrency = false;
                    storesettings.isMultiDebitCredit = false;
                    storesettings.isVoucherDistributionEntry = false;



                    storesettings.isSMSService = false;
                    storesettings.isEmailSerivce = false;

                    //storesettings.Email = signinmodel.Email;

                    storeSettingRepository.Insert(storesettings);



                    var UserId = HttpContext.Session.GetInt32("UserId");
                    var companypermission = new CompanyPermissionModel();
                    companypermission.LuserId = userid;
                    companypermission.ComId = comid;

                    _companyPermissionRepository.Insert(companypermission);



                    var validitydays = _subscriptionTypeRepository.Find(signinmodel.SubscriptionTypeId.GetValueOrDefault()).ValidityDay;

                    SubscriptionActivationModel subscriptionActivation = new SubscriptionActivationModel();
                    subscriptionActivation.IsActive = true;
                    subscriptionActivation.IsDelete = false;
                    subscriptionActivation.LuserId = userid;
                    subscriptionActivation.Remarks = "Auto Entry by System";
                    subscriptionActivation.SubscriptionTypeId = signinmodel.SubscriptionTypeId;
                    subscriptionActivation.ActiveFromDate = DateTime.Now.Date;
                    subscriptionActivation.ActiveToDate = DateTime.Now.Date.AddDays(validitydays);
                    _subscriptionActivationRepository.Insert(subscriptionActivation);




                    SubscriptionActivationCompanyModel subscriptionActivationCompany = new SubscriptionActivationCompanyModel();
                    subscriptionActivationCompany.IsActive = true;
                    subscriptionActivationCompany.IsDelete = false;
                    subscriptionActivationCompany.Remarks = "Auto Entry by System";
                    subscriptionActivationCompany.SubscriptionTypeId = signinmodel.SubscriptionTypeId;
                    subscriptionActivationCompany.ActiveFromDate = DateTime.Now.Date;
                    subscriptionActivationCompany.ActiveToDate = DateTime.Now.Date.AddDays(validitydays);
                    subscriptionActivationCompany.ComId = comid;
                    _subscriptionActivationCompanyRepository.Insert(subscriptionActivationCompany);



                    //////Auto Unit Input by System 
                    UnitModel Units = new UnitModel();
                    Units.UnitName = "Pcs";
                    Units.UnitShortName = "Pcs";
                    Units.UnitNameBangla = "";
                    _unitRepository.Insert(Units);


                    var businesstypename = _businessTypeRepository.Find(storesettings.BusinessTypeId).BusinessTypeName;
                    if (businesstypename.ToLower().Contains("walton") || businesstypename.ToLower().Contains("marcel"))
                    {
                        //////Auto Category Input by System 
                        CategoryModel categorydata = new CategoryModel();
                        categorydata.Name = "Electronics";
                        categorydata.Description = "Electronics";
                        _categoryRepository.Insert(categorydata);
                    }
                    else
                    {
                        //////Auto Category Input by System 
                        CategoryModel categorydata = new CategoryModel();
                        categorydata.Name = "=N/A=";
                        categorydata.Description = "=N/A=";
                        _categoryRepository.Insert(categorydata);
                    }



                    CustomerModel customerdata = new CustomerModel();
                    customerdata.Name = "Walk In Customer";
                    customerdata.Phone = "";
                    customerdata.ComId = comid;
                    _customerRepository.Insert(customerdata);


                    SupplierModel supplierdata = new SupplierModel();
                    supplierdata.SupplierName = "Cash Supplier";
                    supplierdata.Phone = "";
                    supplierdata.ComId = comid;
                    _supplierRepository.Insert(supplierdata);


                    WarehouseModel warehousedata = new WarehouseModel();
                    warehousedata.WhName = "Main";
                    warehousedata.WhShortName = "Main";
                    warehousedata.WhType = "L";
                    warehousedata.ComId = comid;
                    _warehouseRepository.Insert(warehousedata);


                    //if (signinmodel.BusinessTypeId > 0)
                    //{
                    //    var businesstypename = _businessTypeRepository.Find(signinmodel.BusinessTypeId).BusinessTypeName.ToLower();

                    //    if (businesstypename.Contains("waltonmarcel"))
                    //    {
                    //        SqlParameter[] sqlParameter1 = new SqlParameter[3];
                    //        sqlParameter1[0] = new SqlParameter("@comId", comid);
                    //        sqlParameter1[1] = new SqlParameter("@TableName", "AccountHead");
                    //        sqlParameter1[2] = new SqlParameter("@BrandName", businesstypename);

                    //        Helper.ExecProc("prcAutoInsert", sqlParameter1);
                    //    }

                    //}

                    //var businesstypeinfo = _businessTypeRepository.Find(signinmodel.BusinessTypeId);
                    //if (businesstypeinfo.IsAccounts == true)
                    //{

                    //    ///Account Data Auto Insert
                    //    SqlParameter[] sqlParameter = new SqlParameter[2];
                    //    sqlParameter[0] = new SqlParameter("@comId", comid);
                    //    sqlParameter[1] = new SqlParameter("@TableName", "AccountHead");
                    //    //sqlParameter[2] = new SqlParameter("@BrandName", "");

                    //    Helper.ExecProc("prcAutoInsert", sqlParameter);
                    //    ///Account Data Auto Insert



                    //    //var fiscalyearinfo = _fiscalYearTypeRepository.Find(signinmodel.BusinessTypeId);
                    //    var fiscalyearinfo = _fiscalYearTypeRepository.Find(signinmodel.FiscalYearTypeId.GetValueOrDefault());
                    //    ///fiscal year Creation



                    //    var PrevYear = DateTime.Now.Year - 1;
                    //    var fromdate = new DateTime(PrevYear, 1, 1);
                    //    var todate = new DateTime(PrevYear, 12, 31);
                    //    //if (fiscalyearinfo != null)
                    //    //{
                    //    //    PrevYear = DateTime.Now.Year - 1;
                    //    //    fromdate = new DateTime(PrevYear, fiscalyearinfo.FYStartMonth, fiscalyearinfo.FYStartDate);
                    //    //    todate = new DateTime(PrevYear, fiscalyearinfo.FYEndMonth, fiscalyearinfo.FYEndDate);
                    //    //}


                    //    SqlParameter[] sqlParameterfy = new SqlParameter[4];
                    //    sqlParameterfy[0] = new SqlParameter("@comid", comid);
                    //    sqlParameterfy[1] = new SqlParameter("@dtFrom", fromdate);
                    //    sqlParameterfy[2] = new SqlParameter("@dtTo", todate);
                    //    sqlParameterfy[3] = new SqlParameter("@UserId", userid);
                    //    Helper.ExecProc("Acc_prcCloseFiscalYearManual", sqlParameterfy);
                    //    ///fiscal year Creation
                    //}



                    TempData["Message"] = "User Created Successfully";
                    TempData["Status"] = "1";


                }


                ///////////////////////////////////////////////////



                //userconfirmtiondata.OTP = null;
                //userAccountRepository.Update(userconfirmtiondata, userconfirmtiondata.Id);

                if (userconfirmtiondata != null)
                {
                    ChangePasswordViewModel abc = new ChangePasswordViewModel();

                    abc.EmailOrPhone = model.Email;
                    //abc.PhoneNo = model.PhoneNo;

                    userconfirmtiondata.IsEmailVerified = true;
                    userconfirmtiondata.OTP = "";


                    userAccountRepository.Update(userconfirmtiondata, userconfirmtiondata.Id);

                    TempData["UserLoginFailed"] = null;
                    TempData["Message"] = "Email or Phone No Verified Successfully";
                    TempData["Status"] = "1";

                    return RedirectToAction("Login", "Home");
                    //return View("Login");
                }

            }


            TempData["Status"] = "3";
            TempData["Message"] = "Please Verify your OTP from Your Mail Account";
            return View(model);

        }


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

    }






    public class ShortLink
    {
        public string? GetUrlChunk()
        {
            return WebEncoders.Base64UrlEncode(BitConverter.GetBytes(Id));
        }

        public static int GetId(string urlChunk)
        {
            return BitConverter.ToInt32(WebEncoders.Base64UrlDecode(urlChunk));
        }

        public int Id { get; set; }

        public string? Url { get; set; }
    }
}



