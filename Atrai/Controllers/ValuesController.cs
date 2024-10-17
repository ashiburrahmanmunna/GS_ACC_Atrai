using Atrai.Core.Common;
using Atrai.Data.Context.AppDataContext;
using Atrai.Data.Interfaces;
using Atrai.Model.Core.Entity;
using Atrai.Model.Core.ViewModel;
using Atrai.Services;
using DataTablesParser;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using UAParser;

namespace Atrai.Controllers
{
    public class ValuesController : Controller
    {
        #region all referance
        public TransactionLogRepository tranlog { get; }
        private readonly INotificationSettingRepository _notificationSettingRepository;

        private readonly ICustomerRepository _customerRepository;
        private readonly ISupplierRepository _supplierRepository;
        private readonly IInternetUserRepository _InternetUserRepository;

        private readonly IMemberRepository _memberRepository;
        private readonly IEmployeeRepository _employeeRepository;

        private readonly ICountryRepository _countryRepository;
        private readonly IVGMRepository _vgmRepository;
        private readonly IShortLinkRepository _shortLinkRepository;
        private readonly IShortLinkHitRepository _shortLinkHitRepository;
        private readonly IApprovalStatusRepository approvalStatusRepository;


        private readonly IProductRepository _productRepository;
        private readonly IUnitRepository _unitRepository;
        private readonly IWarrentyRepository _warrentyRepository;
        private readonly IColorsRepository _colorRepository;

        private readonly IStoreSettingRepository _storeSettingRepository;
        private readonly IOrdersRepository _ordresRepository;
        private readonly IOrdersItemsRepository orderItemRepository;


        private readonly ISaleRepository _saleRepository;
        private readonly ISalesItemsRepository saleItemRepository;
        private readonly ISalesPaymentRepository _salesPaymentRepository;


        private INIDVerify _nidVerify { get; }
        private readonly ICreditBalanceRepository _CreditBalanceRepository;
        private readonly ICreditUsedRepository _creditUsedLogRepository;
        private readonly IVoterRepository _voterRepository;
        private readonly ITransactionApprovalStatusRepository transactionApprovalStatusRepository;





        private readonly IPurchaseRepository _purchaseRepository;
        private readonly IPurchaseBatchItemsRepository _purchaseBatchItemsRepository;
        private readonly ISalesBatchItemsRepository _salesBatchItemRepository;
        private readonly IPurchaseItemsRepository PurchaseItemRepository;
        private readonly IPurchasePaymentRepository _purchasePaymentRepository;


        private readonly ICostCalculatedRepository _costCalculatedRepository;
        private readonly IUserAccountRepository _userAccountRepository;
        private readonly IAccountHeadRepository _accountHeadRepository;

        private readonly IAccountHeadPermissionRepository _accountHeadPermissionRepository;
        private readonly IAccountHeadSystemRepository _accountHeadSystemRepository;

        private readonly ITransactionRepository _transactionRepository;
        private readonly IInvoiceBillRepository _invoiceBillRepository;
        private readonly ICategoryRepository _categoryRepository;
        private readonly IInternetPackageRepository _internetPackageRepository;
        private readonly IInternetUserStatusRepository _internetUserStatusRepository;


        private readonly IWarehouseRepository _warehouseRepository;
        private readonly IBusinessTypeRepository _businessTypeRepository;
        private readonly ISubscriptionTypeRepository _subscriptionTypeRepository;
        private readonly IAndroidMenuRepository _androidMenuRepository;



        private readonly IUserRoleRepository _userRoleRepository;
        private readonly IMenuPermissionRepository _menuPermissionRepository;
        private readonly IAndroidMenuPermissionRepository _androidMenuPermissionRepository;

        private readonly IAndroidMenuPermission_MasterRepository _androidMenuPermission_MasterRepository;
        private readonly IAndroidMenuPermission_DetailsRepository _androidMenuPermission_DetailsRepository;


        private readonly IUserLogingInfoRepository _userLogingInfoRepository;
        private readonly IUserTransactionLogRepository _userTransactionLogRepository;
        private readonly ICompanyRepository _companyRepository;


        private readonly IExpireDateExtendRepository _expireDateExtendRepository;
        private readonly IUserTerminateRepository _userTerminateRepository;
        private readonly IUserService _userserviceauthenticate;
        private readonly ISubscriptionActivationRepository _subscriptionActivationRepository;
        private readonly IFromWarehousePermissionRepository FromWarehousePermissionRepository;
        private readonly INotificationRepository _notificationRepository;
        private readonly INotificationSeenRepository _notificationSeenRepository;
        private readonly IEmployeeAttendanceRepository _employeeAttendanceRepository;


        private readonly ITaskToDoRepository _taskToDoRepository;
        private readonly IMobileTextAnimationRepository _mobileTextAnimationRepository;
        private readonly IDocTypeRepository _docTypeRepository;
        private readonly IAccFiscalYearRepository _accFiscalYear;


        private readonly ISoftwarePackageRepository _softwarePackageRepository;
        private readonly IPackageActivationRepository _packageActivationRepository;


        private INotificationSender _notificationSender { get; }
        private IEmailSender _emailsender { get; }
        private ISmsSender _smsSender { get; }




        //private readonly IConfiguration configuration;

        //public TransactionLogRepository LogRepository { get; }
        public IConfiguration Config { get; }

        Dictionary<int, dynamic> postData = new Dictionary<int, dynamic>();
        private readonly InvoiceDbContext db;

        public ValuesController(ICustomerRepository customerRepository, ISupplierRepository supplierRepository, IVGMRepository vgmRepository,
        IProductRepository productRepository, IUnitRepository unitRepository,
        IStoreSettingRepository storeSettingRepository, ICompanyRepository companyRepository,
        ISaleRepository saleRepository,
        IPurchaseRepository purchaseRepository,
        ICostCalculatedRepository costCalculatedRepository,


        InvoiceDbContext context, IUserAccountRepository userAccountRepository,
        IAccountHeadRepository accountHeadRepository, ITransactionRepository transactionRepository,
        IInvoiceBillRepository invoiceBillRepository,
        ICategoryRepository categoryRepository, IWarehouseRepository warehouseRepository,
        IInternetPackageRepository internetPackageRepository,
        IInternetUserStatusRepository internetUserStatusRepository,

        IInternetUserRepository InternetUserRepository,

        IMemberRepository memberRepository,

        IBusinessTypeRepository businessTypeRepository,
        ISubscriptionTypeRepository subscriptionTypeRepository,

        IAndroidMenuRepository androidMenuRepository,
        IUserRoleRepository userRoleRepository,
        IMenuPermissionRepository menuPermissionRepository,

        IUserLogingInfoRepository userLogingInfoRepository,
        IUserTransactionLogRepository userTrnsactionLogRepository,
        ICountryRepository countryRepository,


        IExpireDateExtendRepository expireDateExtendRepository,
        IUserTerminateRepository userTerminateRepository,



        IConfiguration configuration, TransactionLogRepository tranlogRepository, IUserService userserviceauthenticate,
        IWarrentyRepository warrentyRepository, IPurchaseBatchItemsRepository purchaseBatchItemsRepository,
        IFromWarehousePermissionRepository fromWarehousePermissionRepository,
        ISalesBatchItemsRepository salesBatchItemsRepository, IApprovalStatusRepository approvalStatusRepository,
        ISalesItemsRepository saleItemRepository, ISalesPaymentRepository _salesPaymentRepository,
        ISubscriptionActivationRepository subscriptionActivationRepository, INotificationRepository notificationRepository,
        INotificationSeenRepository notificationSeenRepository, IEmployeeAttendanceRepository employeeAttendanceRepository,
        IOrdersRepository ordresRepository, ITaskToDoRepository taskToDoRepository, ITransactionApprovalStatusRepository transactionApprovalStatusRepository,
        IMobileTextAnimationRepository mobileTextAnimationRepository, IColorsRepository colorRepository,
        IPurchaseItemsRepository purchaseItemRepository, IPurchasePaymentRepository purchasePaymentRepository, IShortLinkRepository shortLinkRepository, IShortLinkHitRepository shortLinkHitRepository, IAndroidMenuPermissionRepository androidMenuPermissionRepository, IAndroidMenuPermission_MasterRepository androidMenuPermission_MasterRepository, IAndroidMenuPermission_DetailsRepository androidMenuPermission_DetailsRepository, IDocTypeRepository docTypeRepository, IOrdersItemsRepository orderItemRepository, IAccountHeadSystemRepository accountHeadSystemRepository, ICreditBalanceRepository sMSBalanceRepository, ICreditUsedRepository creditUsedLogRepository, INIDVerify nidVerify, IVoterRepository voterRepository, IEmployeeRepository employeeRepository, IAccountHeadPermissionRepository accountHeadPermissionRepository, IAccFiscalYearRepository accFiscalYear, IEmailSender emailsender, ISmsSender smsSender, ISoftwarePackageRepository softwarePackageRepository, IPackageActivationRepository packageActivationRepository, INotificationSender notificationSender, INotificationSettingRepository notificationSettingRepository)
        {
            tranlog = tranlogRepository;
            _customerRepository = customerRepository;
            _supplierRepository = supplierRepository;
            _InternetUserRepository = InternetUserRepository;
            _vgmRepository = vgmRepository;
            _storeSettingRepository = storeSettingRepository;
            _companyRepository = companyRepository;
            this.approvalStatusRepository = approvalStatusRepository;
            this.transactionApprovalStatusRepository = transactionApprovalStatusRepository;

            _saleRepository = saleRepository;
            _purchaseRepository = purchaseRepository;
            _costCalculatedRepository = costCalculatedRepository;
            _productRepository = productRepository;
            _unitRepository = unitRepository;
            _userAccountRepository = userAccountRepository;
            _accountHeadRepository = accountHeadRepository;
            _transactionRepository = transactionRepository;
            _invoiceBillRepository = invoiceBillRepository;
            _memberRepository = memberRepository;
            _categoryRepository = categoryRepository;
            _internetPackageRepository = internetPackageRepository;
            _internetUserStatusRepository = internetUserStatusRepository;


            _warehouseRepository = warehouseRepository;
            _androidMenuRepository = androidMenuRepository;
            _userRoleRepository = userRoleRepository;
            _menuPermissionRepository = menuPermissionRepository;
            _businessTypeRepository = businessTypeRepository;
            _subscriptionTypeRepository = subscriptionTypeRepository;
            _userLogingInfoRepository = userLogingInfoRepository;
            _userTransactionLogRepository = userTrnsactionLogRepository;
            _countryRepository = countryRepository;
            _userTerminateRepository = userTerminateRepository;
            _expireDateExtendRepository = expireDateExtendRepository;
            this.Config = configuration; db = context;
            _userserviceauthenticate = userserviceauthenticate;
            _warrentyRepository = warrentyRepository;
            _purchaseBatchItemsRepository = purchaseBatchItemsRepository;
            FromWarehousePermissionRepository = fromWarehousePermissionRepository;
            _salesBatchItemRepository = salesBatchItemsRepository;
            this.saleItemRepository = saleItemRepository;
            this._salesPaymentRepository = _salesPaymentRepository;
            _subscriptionActivationRepository = subscriptionActivationRepository;
            _notificationRepository = notificationRepository;
            _notificationSeenRepository = notificationSeenRepository;
            _employeeAttendanceRepository = employeeAttendanceRepository;
            _ordresRepository = ordresRepository;
            _taskToDoRepository = taskToDoRepository;
            _mobileTextAnimationRepository = mobileTextAnimationRepository;
            _colorRepository = colorRepository;
            PurchaseItemRepository = purchaseItemRepository;
            _purchasePaymentRepository = purchasePaymentRepository;
            _shortLinkRepository = shortLinkRepository;
            _shortLinkHitRepository = shortLinkHitRepository;
            _androidMenuPermissionRepository = androidMenuPermissionRepository;
            _androidMenuPermission_MasterRepository = androidMenuPermission_MasterRepository;
            _androidMenuPermission_DetailsRepository = androidMenuPermission_DetailsRepository;
            _docTypeRepository = docTypeRepository;
            this.orderItemRepository = orderItemRepository;
            _accountHeadSystemRepository = accountHeadSystemRepository;
            _CreditBalanceRepository = sMSBalanceRepository;
            _creditUsedLogRepository = creditUsedLogRepository;
            _nidVerify = nidVerify;
            _voterRepository = voterRepository;
            _employeeRepository = employeeRepository;
            _accountHeadPermissionRepository = accountHeadPermissionRepository;
            _accFiscalYear = accFiscalYear;
            _emailsender = emailsender;
            _smsSender = smsSender;
            _softwarePackageRepository = softwarePackageRepository;
            _packageActivationRepository = packageActivationRepository;
            _notificationSender = notificationSender;
            _notificationSettingRepository = notificationSettingRepository;
        }

        #endregion

        #region custom function
        public static int? randomnumbergenerate(int outputdigit, int minimumRange, int maximumRange = 10)
        {
            Random numberGen = new Random();
            //int outputdigit = 4;
            //int minimumRange = 1;
            //int maximumRange = 20;

            for (int i = 0; i < outputdigit; i++)
            {
                int randomNumber = numberGen.Next(minimumRange, maximumRange);
                return randomNumber;
                //Console.WriteLine(randomNumber);
            }

            return null;
            //Random rnd = new Random();
            //int month = rnd.Next(1, 13);  // creates a number between 1 and 12
            //int dice = rnd.Next(1, 7);   // creates a number between 1 and 6
            //int card = rnd.Next(52);     // creates a number between 0 and 51

        }
        #endregion

        #region user authentication

        //[HttpGet("LogIn/{UserName}/{Password}")]
        [HttpGet]
        public ActionResult LogIn(string UserName, string Password, string Latitude, string Longitude, int? ComId)
        {
            try
            {
                //var data = systemContext.tblLogin_User.Where(w => w.LUserName == UserName && w.wid.ToString().Substring(0, 8).ToUpper() == Password.ToUpper()).FirstOrDefault();
                var userinfo = _userserviceauthenticate.Authenticate(UserName, Password, ComId); //systemContext.tblLogin_User.Where(w => w.LUserName == UserName && w.wid.ToString().Substring(0, 8).ToUpper() == Password.ToUpper()).FirstOrDefault();
                var basecomid = 0;// userinfo.BaseComId;
                if (ComId != null)
                {
                    basecomid = _storeSettingRepository.All(false).Where(x => x.ComId == ComId).FirstOrDefault().BaseComId;
                }
                else
                {
                    if (userinfo != null)
                    {
                        basecomid = userinfo.ComId;
                    }
                }

                if (userinfo != null)
                {
                    //basecomid = userinfo.BaseComId;
                    Atrai.Model.AppData.DefaultConnectionString = Config.GetConnectionString("DefaultConnection");
                    string weburl = Config.GetSection("hostimage").Value;
                    HttpContext.Session.SetString("weburl", weburl);



                    var userid = userinfo.Id;
                    var rolename = _userAccountRepository.All(false).Where(A => A.Id == userid).Include(x => x.UserRole).Include(x => x.EmployeeList).FirstOrDefault();
                    var compnayinfo = _companyRepository.Find(userinfo.ComId);
                    var storeinfo = _storeSettingRepository.All(false).Include(x => x.BusinessType).Include(x => x.Currency).Where(x => x.ComId == compnayinfo.Id).FirstOrDefault();

                    var companyuserlist = _storeSettingRepository.All(false).Where(x => x.BaseComId == basecomid).OrderBy(x => x.ComId).Select(x => new SelectListItem { Text = x.StoreName, Value = x.ComId.ToString() }).ToList();


                    if (ComId != null)
                    {
                        compnayinfo = _companyRepository.Find(int.Parse(ComId.ToString()));
                        //userinfo.ComId = ComId.GetValueOrDefault();

                    }
                    else
                    {
                        ComId = userinfo.ComId;
                    }

                    //companyuserlist = _storeSettingRepository.All(false).Where(x => x.BaseComId == userinfo.BaseComId).Select(x => new SelectListItem { Text = x.StoreName, Value = x.ComId.ToString() }).OrderBy(x => x.Value).ToList();


                    if (rolename.UserRole.RoleName != "SuperAdmin")
                    {
                        var subscriptionactivationdata = _subscriptionActivationRepository.All().Where(x => x.LuserId == userid && x.ActiveToDate > DateTime.Now.Date).FirstOrDefault();

                        if (subscriptionactivationdata == null)
                        {
                            return new JsonResult(new { message = "User Expired . Please Activate Your user by Pay renewal fee.. or Contact with your service provider 01671303302." }) { StatusCode = StatusCodes.Status401Unauthorized };

                        }


                        //var activatepackage = _packageActivationRepository.All().Where(x => x.ComId == ComId && x.ActiveYesNo == true).OrderByDescending(x => x.Id).FirstOrDefault();

                        //if (activatepackage == null)
                        //{
                        //    return RedirectToAction("PurchasePackage", "License");
                        //    /// return RedirectToAction(firstmenu.Menus.ActionName, firstmenu.Menus.ControllerName);
                        //}


                    }




                    HttpContext.Session.SetInt32("ComId", ComId.GetValueOrDefault());
                    HttpContext.Session.SetInt32("UserId", userinfo.Id);
                    tranlog.SuccessLogin(Latitude, Longitude, "Success");

                    return Ok(new
                    {
                        UserName = userinfo.Name,
                        Token = userinfo.Token,
                        UserId = userinfo.Id,
                        ComId = ComId,
                        userinfo.Email,
                        compnayinfo.CompanyName,
                        RoleName = rolename.UserRole.RoleName,
                        WeightScaleBarcodeStartWith = "99",
                        EmpImagePath = rolename?.EmployeeList?.EmployeeImagePath,
                        CompanyUserList = companyuserlist,
                        IsSerialSales = true,
                        DecimalField = storeinfo.DecimalField,
                        BusinessTypeName = storeinfo.BusinessType.BusinessTypeName,
                        DefaultCurrencyId = storeinfo.CountryId,
                        CurrencySymbol = storeinfo.Currency.CurrencySymbol,
                        CurrencyShortName = storeinfo.Currency.CountryShortName
                    });
                }
                return new JsonResult(new { message = " Unauthorized" }) { StatusCode = StatusCodes.Status401Unauthorized };
            }
            catch (Exception x)
            {
                Console.WriteLine(x.Message);
                return Ok(false);
            }
        }



        [HttpPost]
        public JsonResult CheckExistingPhoneCustomer(string LoginId, int Id)
        {
            var customerPhone = _customerRepository.All(false).Where(x => x.LoginId == LoginId && x.Id != Id).FirstOrDefault();

            return Json(customerPhone == null);
        }

        [HttpPost]
        public JsonResult CheckExistingPhoneSupplier(string LoginId, int Id)
        {
            var supplierPhone = _supplierRepository.All(false).Where(x => x.LoginId == LoginId && x.Id != Id).FirstOrDefault();

            return Json(supplierPhone == null);
        }


        [HttpPost]
        public JsonResult CheckExistingEmail(string email, int id)
        {
            var userEmail = _userAccountRepository.All(false).Where(x => x.Email == email && x.Id != id).FirstOrDefault();

            return Json(userEmail == null);


        }

        [HttpPost]
        public JsonResult CheckOTP(string otp, int Id)
        {
            var userEmail = _userAccountRepository.All(false).Where(x => x.OTP == otp && x.Id != Id).FirstOrDefault();
            if (userEmail != null)
            {
                return Json(true);
            }
            else
            {
                return Json(false);
            }


        }


        [HttpPost]
        public JsonResult CheckExistingPhone(string PhoneNumber, int Id)
        {
            var userPhone = _userAccountRepository.All(false).Where(x => x.PhoneNumber == PhoneNumber && x.Id != Id).FirstOrDefault();

            return Json(userPhone == null);
        }


        [HttpPost]
        public JsonResult CheckExistingBarcode(string Code, int Id)
        {
            var productExist = _productRepository.All().Where(x => x.Code == Code && x.Id != Id).SingleOrDefault();

            return Json(productExist == null);
        }


        [HttpPost]
        public JsonResult CheckExistingEANCode(string EANCode, int Id)
        {
            var productExist = _productRepository.All().Where(x => x.EANCode == EANCode && x.EANCode.Length > 0 && x.Id != Id).SingleOrDefault();

            return Json(productExist == null);
        }

        [HttpPost]
        public JsonResult CheckExistingAccountCode(string AccCode, int Id)
        {
            var AccountCode = _accountHeadRepository.All().Where(x => x.AccCode == AccCode && x.Id != Id).SingleOrDefault();

            return Json(AccountCode == null);
        }

        [HttpPost]
        public JsonResult CheckExistingAccountName(string AccName, int Id)
        {
            var AccountNameExist = _accountHeadRepository.All().Where(x => x.AccName == AccName && x.Id != Id).SingleOrDefault();

            return Json(AccountNameExist == null);
        }


        [HttpPost]
        public JsonResult CheckExistingAccountCodeSystem(string AccCode, int Id)
        {
            var AccountCode = _accountHeadSystemRepository.All().Where(x => x.AccCode == AccCode && x.Id != Id).SingleOrDefault();

            return Json(AccountCode == null);
        }

        [HttpPost]
        public JsonResult CheckExistingAccountNameSystem(string AccName, int Id)
        {
            var AccountNameExist = _accountHeadSystemRepository.All().Where(x => x.AccName == AccName && x.Id != Id).SingleOrDefault();

            return Json(AccountNameExist == null);
        }




        [ApiAuthorize]
        [HttpPost]
        public async Task<IActionResult> Logout(string Latitude, string Longitude)
        {
            try
            {
                await HttpContext.SignOutAsync();
                tranlog.SuccessLogin(Latitude, Longitude, "Logout");
                return Ok(true);
            }
            catch (Exception x)
            {
                Console.WriteLine(x.Message);
                return Ok(false);
            }
        }

        [ApiAuthorize]
        [HttpPost]
        public ActionResult AutoLogin(string Latitude, string Longitude)
        {
            try
            {
                var userid = HttpContext.Session.GetInt32("UserId");
                var userinfo = _userAccountRepository.Find(int.Parse(userid.ToString()));
                HttpContext.Session.SetString("UserInfo", userinfo.Email);

                tranlog.SuccessLogin(Latitude, Longitude, "AutoLogin");
                return Ok(true);
            }
            catch (Exception x)
            {
                Console.WriteLine(x.Message);
                return Ok(false);
            }
        }

        [HttpPost]
        public ActionResult PasswordReset(string email, string phoneno, string password, string otp)
        {
            try
            {
                UserAccountModel userinfo = _userAccountRepository.All(false).Where(x => x.Email == email && x.PhoneNumber == phoneno && x.OTP == otp).FirstOrDefault();

                if (userinfo != null && password.Length >= 5)
                {
                    userinfo.Password = password;
                    userinfo.OTP = "";
                    _userAccountRepository.Update(userinfo, userinfo.Id);
                    return Ok(true);

                }
                else
                {
                    return Ok(false);
                }

            }
            catch (Exception x)
            {
                Console.WriteLine(x.Message);
                return Ok(false);
                //return Json(new { Success = false, error = true, message = x.Message + " ; " + x.InnerException });
            }
        }




        public ActionResult ForgetPassword(string email, string phoneno)
        {
            try
            {
                bool emaildata = _userAccountRepository.All(false).Any(x => x.Email.ToLower() == email.ToLower());
                bool phonedata = _userAccountRepository.All(false).Any(x => x.PhoneNumber.ToLower() == phoneno.ToLower());


                var message = "Abcd";
                var success = false;
                int? randomnumber = null;

                if (emaildata == false)
                {
                    message = "Username Or Email Address is not valid.";

                }
                else if (phonedata == false)
                {
                    message = "Phone No is not valid.";
                }
                else if (emaildata == false && phonedata == false)
                {
                    message = "Username Or Email Address and Phone No is not valid.";
                }
                else
                {
                    success = true;
                    message = "User name and Phone is valid";
                    randomnumber = randomnumbergenerate(4, 1050, 9999);

                    UserAccountModel userinfo = _userAccountRepository.All(false).Where(x => x.Email == email && x.PhoneNumber == phoneno).FirstOrDefault();

                    if (userinfo != null)
                    {
                        userinfo.OTP = randomnumber.ToString();
                        _userAccountRepository.Update(userinfo, userinfo.Id);

                    }
                }


                return Ok(new
                {
                    isEmail = emaildata,
                    isPhone = phonedata,
                    message,
                    success,
                    otp = randomnumber
                });

                //return new JsonResult(new { message = "Unauthorized" }) { StatusCode = StatusCodes.Status401Unauthorized };
            }
            catch (Exception x)
            {
                Console.WriteLine(x.Message);
                return Ok(false);
            }
        }


        [Route("~/Values/ResendOTP/{EmailorPhone}")]
        public IActionResult ResendOTP(string EmailorPhone)
        {
            var errors = ModelState.Where(x => x.Value.Errors.Any())
                        .Select(x => new { x.Key, x.Value.Errors });

            try
            {
                if (ModelState.IsValid)
                {
                    var OTPvalue = ValuesController.randomnumbergenerate(6, 105011, 999999).ToString();

                    var abc = _userAccountRepository.All(false).Where(x => (x.Email.ToLower() == EmailorPhone.ToLower()) || (x.PhoneNumber.ToLower() == EmailorPhone.ToLower())).FirstOrDefault();

                    if (abc != null)
                    {
                        abc.OTP = OTPvalue;
                        _userAccountRepository.Update(abc, abc.Id);

                        if (abc != null)
                        {
                            string mailList = abc.Email;
                            //string subject = $"Email Confirmation OTP";
                            //string body = $"User Account Confirmation Email. <br/><br/> Created Time : - {DateTime.Now}<br/> Your Confirmation OTP is  " + OTPvalue + "";


                            string subject = $"Care Customer Service";
                            string body = $"Password Reset Email. <br/><br/> Created Time : - {DateTime.Now}<br/> Your Confirmation OTP is  " + OTPvalue + "";



                            _emailsender.SendEmailAsync(mailList, subject, body);
                            //_smsSender.SendSmsAsync(signinmodel.PhoneNo, $"Your Confirmation OTP is " + OTPvalue + "");
                            _smsSender.SendSmsAsync(abc.PhoneNumber, $"Your Confirmation OTP is " + OTPvalue + "");
                        }



                        return Ok(true);

                        //TempData["Message"] = "Put Your OTP to Confirm Your Account.";
                        //TempData["Status"] = "1";

                        //return RedirectToAction("EmailConfirmation", new { Email = abc.Email, PhoneNo = abc.PhoneNumber });


                        //return RedirectToAction("Login");

                    }
                    else
                    {

                        return Ok(false);


                        //TempData["Message"] = "Wrong user Informtion";
                        //TempData["Status"] = "3";

                        //return RedirectToAction("EmailConfirmation", new { Email = abc.Email, PhoneNo = abc.PhoneNumber });
                    }



                }

                return Ok(false);

            }
            catch (Exception ex)
            {
                return Ok(false);
                //throw ex;
            }
        }


        //[HttpPost]
        //public ActionResult ForgetPasswordPost(string UserName, string Password)
        //{
        //    try
        //    {
        //        var userinfo = _userserviceauthenticate.a(UserName, Password);


        //        return Ok(new
        //        {
        //            isEmail = emaildata,
        //            isPhone = phonedata,
        //            message,
        //            success
        //        }); ;

        //        //return new JsonResult(new { message = "Unauthorized" }) { StatusCode = StatusCodes.Status401Unauthorized };
        //    }
        //    catch (Exception x)
        //    {
        //        Console.WriteLine(x.Message);
        //        return Ok(false);
        //    }
        //}


        #endregion

        #region Product

        [HttpGet]
        [ApiAuthorize]

        public JsonResult GetProductList(int? CategoryId, int pageNo = 1, decimal pageSize = 10, string searchquery = "")
        {
            try
            {
                #region unnecessarcode

                #endregion





                var products = _productRepository.All();//.Take(200);//.Include(x=>x.vUnit).Include(x=>x.Category);

                if (searchquery?.Length > 1)
                {
                    products = products.Where(x => x.Name.ToLower().Contains(searchquery.ToLower()) || x.Code.ToLower().Contains(searchquery.ToLower()));
                }
                if (CategoryId != null)
                {
                    products = products.Where(x => x.CategoryId == CategoryId);
                }


                decimal TotalRecordCount = products.Count();
                var PageCountabc = decimal.Parse((TotalRecordCount / pageSize).ToString());
                var PageCount = Math.Ceiling(PageCountabc);





                decimal skip = (pageNo - 1) * pageSize;

                // Get total number of records
                int total = products.Count();

                //var products = productslist.OrderBy(c => c.Id)
                //                .Skip(skip)
                //                .Take(pageSize)
                //                .ToList();



                var warehouselist = FromWarehousePermissionRepository.GetAllForDropDown();
                if (warehouselist.Count() == 0)
                {
                    warehouselist = _warehouseRepository.GetWarehouseLedgerHeadForDropDown();
                }

                List<int?> permitwarehouselist = new List<int?>();

                foreach (var item in warehouselist)
                {
                    permitwarehouselist.Add(int.Parse(item.Value.ToString()));
                }


                var query = (from p in products

                                 //let costcallist = p.CostCalculated
                             let costcallist = p.CostCalculated.Where(x => permitwarehouselist.Contains(x.WarehouseId))

                         .GroupBy(st => new { st.WarehouseId, st.ProductId })
                             .Select(grouping => grouping.Max(row => row.Id))
                             .ToArray()

                             //let  SubThings = p.CostCalculateds.GroupBy(st=>new {st.WarehouseId,st.ProductId}).Select(grouping => grouping.Max(row => row.Id)).ToList()

                             //let  LastPurchase = p.PurchaseItems.Sum(st=>new {st.ProductId}).Select(grouping => grouping.Max(row => row.Id)).ToList()


                             let WarehouseQty =
                             //p.CostCalculated != null ?
                             p.CostCalculated.OrderByDescending(x => x.Id)
                             .Select(x => new WarehouseResult
                             {
                                 CostCalculatedId = x.Id,
                                 //WarehouseId = x.WarehouseId, 
                                 WhShortName = x.Warehouse.WhShortName,
                                 CurrentStock = x.CurrQty + x.PrevQty,
                                 AverageCosting = x.CalculatedPrice,
                                 CostingValue = (x.CalculatedPrice) * (x.CurrQty + x.PrevQty),
                                 SalesValue = (double)p.Price * (x.CurrQty + x.PrevQty)
                             })
                             .Where(x => costcallist.Contains(x.CostCalculatedId))
                             //.Where(x => x.CostCalculatedId == 86)
                             .ToList()
                             ?? null

                             select new ProductResult
                             {
                                 Id = p.Id,
                                 Name = p.Name,
                                 Code = p.Code,
                                 Price = p.Price,
                                 CostPrice = p.CostPrice,

                                 UnitName = p.Unit.UnitName,

                                 CategoryName = p.Category.Name,
                                 BrandName = p.Brand != null ? p.Brand.BrandName : "",
                                 ModelName = p.ModelName,
                                 VariantName = p.SizeName,
                                 SizeName = p.SizeName,
                                 ColorName = p.ColorName,

                                 //ROL = p.ROL,
                                 //ROQ = p.ROQ,
                                 //MOQ = p.MOQ,
                                 OldPrice = p.OldPrice,
                                 ImagePath = p.ImagePath,



                                 ProductBarcode = p.Code,
                                 Description = p.Description,
                                 //CostPrice = p.CostPrice,

                                 //TotalPurchase = p.PurchaseItems.Sum(x => x.Quantity),
                                 //TotalSales = p.SalesItems.Sum(x => x.Quantity),
                                 //LastPurchaseDate = p.PurchaseItems.OrderByDescending(x => x.Id).FirstOrDefault().PurchaseModel.PurchaseDate.ToString("dd-MMM-yy") ?? "",
                                 //LastSalesDate = p.SalesItems.OrderByDescending(x => x.Id).FirstOrDefault().SalesModel.SalesDate.ToString("dd-MMM-yy") ?? "",

                                 ////LastPurchaseDate = (DateTime)p.PurchaseItems.OrderByDescending(x => x.Id).FirstOrDefault().PurchaseModel.PurchaseDate,
                                 ////LastSalesDate = p.SalesItems.OrderByDescending(x => x.Id).FirstOrDefault().SalesModel.SalesDate,

                                 //LastPurchaseSupplier = p.PurchaseItems.OrderByDescending(x => x.Id).FirstOrDefault().PurchaseModel.SupplierModel.SupplierName ?? null,
                                 //LastSalesCustomer = p.SalesItems.OrderByDescending(x => x.Id).FirstOrDefault().SalesModel.CustomerModel.Name ?? "" + " - " + p.SalesItems.OrderByDescending(x => x.Id).FirstOrDefault().SalesModel.CustomerName ?? "",

                                 WarehouseList = WarehouseQty
                             });




                //var parser = new Parser<ProductResult>(Request.Form, query);
                //return Json(parser.Parse());


                var abcd = query.OrderByDescending(x => x.Id).Skip(int.Parse(skip.ToString())).Take(int.Parse(pageSize.ToString())).ToList();// Take(50);
                var pageinfo = new PagingInfo();
                pageinfo.PageCount = int.Parse(PageCount.ToString());
                pageinfo.PageNo = pageNo;
                pageinfo.PageSize = int.Parse(pageSize.ToString());
                pageinfo.TotalRecordCount = int.Parse(TotalRecordCount.ToString());

                //return  abcd;
                return Json(new { Success = 1, error = false, ProductList = abcd, PageInfo = pageinfo });
                //return Json(abcd, pageinfo);

            }
            catch (Exception ex)
            {

                Console.WriteLine(ex.Message);
                return Json(ex.Message);
            }
        }

        //public class PagedResult<T>
        //{
        //    public class PagingInfo
        //    {
        //        public int PageNo { get; set; }

        //        public int PageSize { get; set; }

        //        public int PageCount { get; set; }

        //        public long TotalRecordCount { get; set; }

        //    }
        //    public List<T> Data { get; private set; }

        //    public PagingInfo Paging { get; private set; }

        //    public PagedResult(IEnumerable<T> items, int pageNo, int pageSize, long totalRecordCount)
        //    {
        //        Data = new List<T>(items);
        //        Paging = new PagingInfo
        //        {
        //            PageNo = pageNo,
        //            PageSize = pageSize,
        //            TotalRecordCount = totalRecordCount,
        //            PageCount = totalRecordCount > 0
        //                ? (int)Math.Ceiling(totalRecordCount / (double)pageSize)
        //                : 0
        //        };
        //    }
        //}

        //public IHttpActionResult GetPagedProductList(int pageNo = 1, int pageSize = 50)
        //{
        //    // Determine the number of records to skip
        //    decimal skip = (pageNo - 1) * pageSize;

        //    var products = _productRepository.All();
        //    // Get total number of records
        //    int total = products.Count();

        //    // Select the customers based on paging parameters
        //    products = products
        //        .OrderBy(c => c.Id)
        //        .Skip(skip)
        //        .Take(pageSize)
        //        .ToList();

        //    // Return the list of customers
        //    return Ok(new PagedResult<ProductModel>(products, pageNo, pageSize, total));
        //}


        [HttpGet]
        [ApiAuthorize]

        public JsonResult GetProductListApk()
        {
            try
            {
                #region unnecessarcode

                #endregion

                var products = _productRepository.All();//.Take(30);//.Include(x=>x.vUnit).Include(x=>x.Category);
                var query = (from p in products

                             let costcallist = p.CostCalculated
                             .GroupBy(st => new { st.WarehouseId, st.ProductId })
                             .Select(grouping => grouping.Max(row => row.Id))
                             .ToArray()

                             //let  SubThings = p.CostCalculateds.GroupBy(st=>new {st.WarehouseId,st.ProductId}).Select(grouping => grouping.Max(row => row.Id)).ToList()

                             //let  LastPurchase = p.PurchaseItems.Sum(st=>new {st.ProductId}).Select(grouping => grouping.Max(row => row.Id)).ToList()


                             let WarehouseQty =
                             //p.CostCalculated != null ?
                             p.CostCalculated.OrderByDescending(x => x.Id)
                             .Select(x => new WarehouseResult
                             {
                                 CostCalculatedId = x.Id,
                                 //WarehouseId = x.WarehouseId, 
                                 WhShortName = x.Warehouse.WhShortName,
                                 CurrentStock = x.CurrQty + x.PrevQty,
                                 AverageCosting = x.CalculatedPrice,
                                 CostingValue = (x.CalculatedPrice) * (x.CurrQty + x.PrevQty),
                                 SalesValue = (double)p.Price * (x.CurrQty + x.PrevQty)
                             })
                             .Where(x => costcallist.Contains(x.CostCalculatedId))
                             //.Where(x => x.CostCalculatedId == 86)
                             .ToList()
                             ?? null

                             select new ProductResult
                             {
                                 Id = p.Id,
                                 Name = p.Name,
                                 Code = p.Code,
                                 Price = p.Price,
                                 UnitName = p.Unit.UnitName,
                                 CategoryName = p.Category.Name,

                                 BrandName = p.Brand != null ? p.Brand.BrandName : "",
                                 //ROL = p.ROL,
                                 //ROQ = p.ROQ,
                                 //MOQ = p.MOQ,
                                 OldPrice = p.OldPrice,
                                 ImagePath = p.ImagePath,
                                 SizeName = p.SizeName,
                                 ColorName = p.ColorName,


                                 ProductBarcode = p.Code,
                                 Description = p.Description,
                                 //CostPrice = p.CostPrice,

                                 TotalPurchase = p.PurchaseItems.Sum(x => x.Quantity),
                                 TotalSales = p.SalesItems.Sum(x => x.Quantity),
                                 LastPurchaseDate = p.PurchaseItems.OrderByDescending(x => x.Id).FirstOrDefault().PurchaseModel.PurchaseDate.ToString("dd-MMM-yy") ?? "",
                                 LastSalesDate = p.SalesItems.OrderByDescending(x => x.Id).FirstOrDefault().SalesModel.SalesDate.ToString("dd-MMM-yy") ?? "",

                                 //LastPurchaseDate = (DateTime)p.PurchaseItems.OrderByDescending(x => x.Id).FirstOrDefault().PurchaseModel.PurchaseDate,
                                 //LastSalesDate = p.SalesItems.OrderByDescending(x => x.Id).FirstOrDefault().SalesModel.SalesDate,

                                 LastPurchaseSupplier = p.PurchaseItems.OrderByDescending(x => x.Id).FirstOrDefault().PurchaseModel.SupplierModel.SupplierName ?? null,
                                 LastSalesCustomer = p.SalesItems.OrderByDescending(x => x.Id).FirstOrDefault().SalesModel.CustomerModel.Name ?? "" + " - " + p.SalesItems.OrderByDescending(x => x.Id).FirstOrDefault().SalesModel.CustomerName ?? "",

                                 WarehouseList = WarehouseQty
                             });




                var parser = new Parser<ProductResult>(Request.Form, query);
                return Json(parser.Parse());


                //List<ProductResult> abcd = query.ToList();

                ////return  abcd;

                //return Json(abcd);

            }
            catch (Exception ex)
            {

                Console.WriteLine(ex.Message);
                return Json(ex.Message);
            }
        }


        [HttpGet]
        public List<ProductResult> GetProductListAll()
        {
            try
            {
                #region unnecessarcode

                #endregion


                var warehouselist = FromWarehousePermissionRepository.GetAllForDropDown();
                if (warehouselist.Count() == 0)
                {
                    warehouselist = _warehouseRepository.GetWarehouseLedgerHeadForDropDown();
                }

                List<int?> permitwarehouselist = new List<int?>();

                foreach (var item in warehouselist)
                {
                    permitwarehouselist.Add(int.Parse(item.Value.ToString()));
                }


                var products = _productRepository.All(false).Take(30);//.Include(x=>x.vUnit).Include(x=>x.Category);
                var query = (from p in products

                                 //let costcallist = p.CostCalculated
                             let costcallist = p.CostCalculated.Where(x => permitwarehouselist.Contains(x.WarehouseId))

                         .GroupBy(st => new { st.WarehouseId, st.ProductId })
                             .Select(grouping => grouping.Max(row => row.Id))
                             .ToArray()

                             //let  SubThings = p.CostCalculateds.GroupBy(st=>new {st.WarehouseId,st.ProductId}).Select(grouping => grouping.Max(row => row.Id)).ToList()

                             //let  LastPurchase = p.PurchaseItems.Sum(st=>new {st.ProductId}).Select(grouping => grouping.Max(row => row.Id)).ToList()


                             let WarehouseQty =
                             //p.CostCalculated != null ?
                             p.CostCalculated.OrderByDescending(x => x.Id)
                             .Select(x => new WarehouseResult
                             {
                                 CostCalculatedId = x.Id,
                                 //WarehouseId = x.WarehouseId, 
                                 WhShortName = x.Warehouse.WhShortName,
                                 CurrentStock = x.CurrQty + x.PrevQty,
                                 AverageCosting = x.CalculatedPrice,
                                 CostingValue = (x.CalculatedPrice) * (x.CurrQty + x.PrevQty),
                                 SalesValue = (double)p.Price * (x.CurrQty + x.PrevQty)
                             })
                             .Where(x => costcallist.Contains(x.CostCalculatedId))
                             //.Where(x => x.CostCalculatedId == 86)
                             .ToList()
                             ?? null

                             select new ProductResult
                             {
                                 Id = p.Id,
                                 Name = p.Name,
                                 Code = p.Code,
                                 Price = p.Price,
                                 UnitName = p.Unit.UnitName,
                                 CategoryName = p.Category.Name,

                                 BrandName = p.Brand != null ? p.Brand.BrandName : "",
                                 //ROL = p.ROL,
                                 //ROQ = p.ROQ,
                                 //MOQ = p.MOQ,
                                 OldPrice = p.OldPrice,
                                 ImagePath = p.ImagePath,
                                 SizeName = p.SizeName,
                                 ColorName = p.ColorName,


                                 ProductBarcode = p.Code,
                                 Description = p.Description,
                                 //CostPrice = p.CostPrice,

                                 TotalPurchase = p.PurchaseItems.Sum(x => x.Quantity),
                                 TotalSales = p.SalesItems.Sum(x => x.Quantity),
                                 LastPurchaseDate = p.PurchaseItems.OrderByDescending(x => x.Id).FirstOrDefault().PurchaseModel.PurchaseDate.ToString("dd-MMM-yy") ?? "",
                                 LastSalesDate = p.SalesItems.OrderByDescending(x => x.Id).FirstOrDefault().SalesModel.SalesDate.ToString("dd-MMM-yy") ?? "",

                                 //LastPurchaseDate = (DateTime)p.PurchaseItems.OrderByDescending(x => x.Id).FirstOrDefault().PurchaseModel.PurchaseDate,
                                 //LastSalesDate = p.SalesItems.OrderByDescending(x => x.Id).FirstOrDefault().SalesModel.SalesDate,

                                 LastPurchaseSupplier = p.PurchaseItems.OrderByDescending(x => x.Id).FirstOrDefault().PurchaseModel.SupplierModel.SupplierName ?? null,
                                 LastSalesCustomer = p.SalesItems.OrderByDescending(x => x.Id).FirstOrDefault().SalesModel.CustomerModel.Name ?? "" + " - " + p.SalesItems.OrderByDescending(x => x.Id).FirstOrDefault().SalesModel.CustomerName ?? "",

                                 WarehouseList = WarehouseQty,
                                 Type = "simple",///grouped , external , variable
                                 Status = "publish" // draft  , pending , private


                             });




                //var parser = new Parser<ProductResult>(Request.Form, query);
                //return Json(parser.Parse());


                List<ProductResult> abcd = query.OrderByDescending(x => x.Id).ToList();

                return abcd;

                //return Json(abcd);

            }
            catch (Exception ex)
            {

                throw ex;
            }
        }


        [ApiAuthorize]

        public JsonResult GetSingleProduct(int ProductId)
        {
            try
            {
                #region unnecessarcode

                #endregion

                var singleproduct = _productRepository.All()
                    .Where(x => x.Id == ProductId)
                    .Select(x => new
                    {
                        x.Name,
                        x.Code,
                        x.Price,
                        x.CostPrice,
                        x.WholeSalePrice,
                        x.CategoryId,
                        x.Description,
                        x.UnitId,
                        x.WarrentyId,
                        x.PCTN,
                        x.OldPrice,
                        BrandName = x.Brand != null ? x.Brand.BrandName : "",
                        x.ModelName,

                        x.SizeName,
                        x.ColorName,
                        x.CommissionPer,
                        x.CommissionAmount,
                        x.Id,
                        x.IsNonInventory,
                        x.IsPublished,
                        x.CreateDate,
                        x.LuserId,

                        x.ROL,
                        x.ROLTwo,
                        x.ROLThree,
                        x.MOQ,
                        x.ROQ,
                        x.ImagePath



                    }).FirstOrDefault();//.Include(x=>x.vUnit).Include(x=>x.Category);

                return Json(singleproduct);
                //return Json(abcd);

            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        [ApiAuthorize]
        public JsonResult GetProduct(int ProductId)
        {
            try
            {
                var singleproduct = _productRepository.All()
                    .Where(x => x.Id == ProductId)
                    .Select(x => new
                    {
                        x.Name,
                        x.Code,
                        x.Price,
                        x.CostPrice,
                        x.WholeSalePrice,
                        x.CategoryId,
                        x.Description,
                        x.UnitId,
                        x.WarrentyId,
                        x.PCTN,
                        x.OldPrice,
                        BrandName = x.Brand != null ? x.Brand.BrandName : "",
                        x.ModelName,
                        x.SizeName,
                        x.ColorName,
                        x.CommissionPer,
                        x.CommissionAmount,
                        x.Id,
                        x.CreateDate,
                        x.LuserId
                    }).FirstOrDefault();//.Include(x=>x.vUnit).Include(x=>x.Category);

                return Json(singleproduct);

                //var singleproduct = _productRepository.All().Where(x => x.Id == ProductId)
                //    .FirstOrDefault();//.Include(x=>x.vUnit).Include(x=>x.Category);

                //return singleproduct;

                //return Json(abcd);

            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        // [Consumes("multipart/form-data")]
        [ApiAuthorize]
        [HttpPost]//("CreateCall")
        public IActionResult CreateProduct([FromBody] ProductModel model)//, IFormFile logoPostedFileBase
        {
            try
            {


                //var request = HttpContext.Current.Request;
                //var filePath = "C:\\temp\\" + request.Headers["filename"];
                //using (var fs = new System.IO.FileStream(filePath, System.IO.FileMode.Create))
                //{
                //    request.InputStream.CopyTo(fs);
                //}

                //if (ModelState.IsValid)
                //{

                var productExist = _productRepository.All().Where(x => x.Code == model.Code && x.Id != model.Id).SingleOrDefault();
                if (productExist != null)
                {
                    return BadRequest(new { message = "Product Code Duplicate.Please change Product Code." });

                }
                //return Json(productExist == null);


                if (model.Id > 0)
                {

                    //if (model.BrandName == null)
                    //{
                    //    model.BrandName = "";
                    //}

                    if (model.Description == null)
                    {
                        model.Description = "";
                    }

                    if (model.ModelName == null)
                    {
                        model.ModelName = "";
                    }

                    if (model.SizeName == null)
                    {
                        model.SizeName = "";
                    }

                    if (model.ColorName == null)
                    {
                        model.ColorName = "";
                    }

                    if (model.LocalName == null)
                    {
                        model.LocalName = "";
                    }


                    _productRepository.UpdateApi(model, model.Id);
                }
                else
                {

                    //if (model.BrandName == null)
                    //{
                    //    model.BrandName = "";
                    //}

                    if (model.Description == null)
                    {
                        model.Description = "";
                    }

                    if (model.ModelName == null)
                    {
                        model.ModelName = "";
                    }

                    if (model.SizeName == null)
                    {
                        model.SizeName = "";
                    }

                    if (model.ColorName == null)
                    {
                        model.ColorName = "";
                    }

                    if (model.LocalName == null)
                    {
                        model.LocalName = "";
                    }

                    _productRepository.InsertApi(model);
                }


                //byte[] bytes = Convert.FromBase64String(model.ProductImageString);

                //Image image;
                //using (MemoryStream ms = new MemoryStream(bytes))
                //{
                //    image = Image.FromStream(ms);
                //}
                //var fullOutputPath = "wwwroot/Content/ProductImages/"+ model.Id +".png";
                //image.Save(fullOutputPath, System.Drawing.Imaging.ImageFormat.Png);


                byte[] bytes = null;
                if (model.ProductImageString != null)
                {
                    bytes = Convert.FromBase64String(model.ProductImageString);
                }
                if (bytes != null)
                {
                    if (bytes.Length > 0)
                    {
                        Image image;

                        using (MemoryStream ms = new MemoryStream(bytes))
                        {
                            image = Image.FromStream(ms);
                        }
                        var path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/Content/ProductImages", model.Id.ToString() + ".png");

                        //using (var stream = new FileStream(path, FileMode.Create))
                        //{
                        //    logoPostedFileBase.CopyTo(logoPostedFileBase);
                        //}
                        image.Save(path, System.Drawing.Imaging.ImageFormat.Png);
                        model.ImagePath = $"/Content/ProductImages/{model.Id.ToString() + ".png"}";
                    }

                }
                else
                {
                    var products = _productRepository.Find(model.Id);
                    if (products != null)
                        model.ImagePath = products.ImagePath;
                }
                _productRepository.Update(model, model.Id);

                return Ok(true);

                //var singleproduct = _productRepository.All()
                //   .Where(x => x.Id == model.Id)
                //   .Select(x => new {
                //       x.Name,
                //       x.Code,
                //       x.Price,
                //       x.CostPrice,
                //       x.WholeSalePrice,
                //       x.CategoryId,
                //       x.Description,
                //       x.UnitId,
                //       x.WarrentyId,
                //       x.PCTN,
                //       x.OldPrice,
                //       x.BrandName,
                //       x.ModelName,
                //       x.ImagePath,

                //       x.SizeName,
                //       x.ColorName,
                //       x.CommissionPer,
                //       x.CommissionAmount,
                //       x.Id,
                //       x.IsNonInventory,
                //       x.IsPublished,
                //       x.CreateDate,
                //       x.LuserId,

                //       x.ROL,
                //       x.ROLTwo,
                //       x.ROLThree,
                //       x.MOQ,
                //       x.ROQ
                //   }).FirstOrDefault();//.Include(x=>x.vUnit).Include(x=>x.Category);

                //return Ok(new { Success = "true", ProductInfo = singleproduct });
                //}
                //return Ok(false);
            }
            catch (Exception x)
            {
                Console.WriteLine(x.Message);
                return Ok(false);

            }
        }

        //[HttpDelete("DeleteCall/{id}")]
        [ApiAuthorize]
        public ActionResult DeleteProduct(int id)
        {
            try
            {
                var response = _productRepository.Find(id);

                if (response != null) _productRepository.Delete(response);
                else if (response == null) return BadRequest(new { message = "Product information is not available" });

                //Ok(false);

                return Ok(true);

            }
            catch (Exception x)
            {
                Console.WriteLine(x.Message);
                return BadRequest(new { message = "Something Wrong" });
            }
        }

        #endregion

        #region Customer

        [HttpGet]
        [ApiAuthorize]
        public JsonResult GetCustomerList(int pageNo = 1, decimal pageSize = 10, string searchquery = "")
        //public List<CustomerResultList> GetCustomerList(int pageNo = 1, int pageSize = 10, string searchquery = "")
        {
            try
            {
                var customers = _customerRepository.All();//.Take(30);//.Include(x=>x.vUnit).Include(x=>x.Category);.Where(x => x.ComId == 1)

                if (searchquery?.Length > 1)
                {
                    customers = customers.Where(x => x.Name.ToLower().Contains(searchquery.ToLower()) || x.PrimaryAddress.ToLower().Contains(searchquery.ToLower()) || x.Phone.ToLower().Contains(searchquery.ToLower()));
                }




                decimal TotalRecordCount = customers.Count();
                var PageCountabc = (TotalRecordCount / pageSize);
                var PageCount = Math.Ceiling(PageCountabc);
                decimal skip = (pageNo - 1) * pageSize;
                // Get total number of records
                int total = customers.Count();


                //decimal TotalRecordCount =  customers.Count();
                //var PageCountabc = decimal.Parse((TotalRecordCount / pageSize).ToString());
                //var PageCount = Math.Ceiling(PageCountabc);
                //decimal skip = (pageNo - 1) * pageSize;
                //// Get total number of records
                //int total = customers.Count();


                var query = from e in customers//.Where(x => x.Id > 0 && x.ComId == ComId).OrderByDescending(x => x.Id)

                            select new CustomerResultList
                            {
                                Id = e.Id,
                                Name = e.Name,
                                Email = e.Email,
                                PrimaryAddress = e.PrimaryAddress,
                                SecoundaryAddress = e.SecoundaryAddress,
                                Notes = e.Notes,
                                Phone = e.Phone,
                                CustType = e.CustType,
                                ParentCustomer = e.Customers.Name,

                                TotalSalesValue = e.AccountsDailyTransaction.Where(x => x.TransactionType == "System Sales").Sum(x => x.TransactionAmount),
                                TotalSalesReturnValue = e.AccountsDailyTransaction.Where(x => x.TransactionType == "System Sales Return").Sum(x => x.TransactionAmount),
                                TotalAmountBack = e.AccountsDailyTransaction.Where(x => x.TransactionType.Contains("Paid")).Sum(x => x.TransactionAmount),
                                TotalCollection = e.AccountsDailyTransaction.Where(x => x.TransactionType.Contains("Received")).Sum(x => x.TransactionAmount),

                                TotalDue =
                                (decimal)e.OpBalance
                                + e.AccountsDailyTransaction.Where(x => x.TransactionType == "System Sales").Sum(x => x.TransactionAmount)
                                + e.AccountsDailyTransaction.Where(x => x.TransactionType == "System Sales Return").Sum(x => x.TransactionAmount)
                                - e.AccountsDailyTransaction.Where(x => x.TransactionType.Contains("Received")).Sum(x => x.TransactionAmount)
                                + e.AccountsDailyTransaction.Where(x => x.TransactionType.Contains("Paid") && !x.TransactionCategory.Contains("CustomerDiscount")).Sum(x => x.TransactionAmount)
                                - e.AccountsDailyTransaction.Where(x => x.TransactionCategory.Contains("CustomerDiscount")).Sum(x => x.TransactionAmount),


                                LastSalesDate = e.Sales.OrderByDescending(x => x.Id).FirstOrDefault().SalesDate.ToString("dd-MMM-yy") ?? "",
                                LastInvoiceNo = e.Sales.OrderByDescending(x => x.Id).FirstOrDefault().SaleCode ?? "",
                                LastSoldProduct = e.Sales.OrderByDescending(x => x.Id).FirstOrDefault().Items.OrderByDescending(x => x.Id).FirstOrDefault().Product.Name ?? "",



                                //TotalSalesValue = e.AccountsDailyTransaction.Where(x => x.TransactionType == "System Sales").Sum(x => x.TransactionAmount),
                                //TotalCollection = e.AccountsDailyTransaction.Where(x => x.TransactionType.Contains("Received")).Sum(x => x.TransactionAmount),
                                //TotalDue = (decimal)e.OpBalance + e.AccountsDailyTransaction.Where(x => x.TransactionType == "System Sales").Sum(x => x.TransactionAmount) - e.AccountsDailyTransaction.Where(x => x.TransactionType.Contains("Received")).Sum(x => x.TransactionAmount),
                                //LastSalesDate = e.Sales.OrderByDescending(x => x.Id).FirstOrDefault().SalesDate.ToString("dd-MMM-yy") ?? "",
                                //LastInvoiceNo = e.Sales.OrderByDescending(x => x.Id).FirstOrDefault().SaleCode ?? "",
                                //LastSoldProduct = e.Sales.OrderByDescending(x => x.Id).FirstOrDefault().Items.OrderByDescending(x => x.Id).FirstOrDefault().Product.Name ?? "",

                            };

                //if (Status == "Due")
                //{
                //    query = query.Where(x => x.TotalDue > 0);
                //}


                var abcd = query.OrderBy(x => x.Id).Skip(int.Parse(skip.ToString())).Take(int.Parse(pageSize.ToString())).ToList();// Take(50);
                var pageinfo = new PagingInfo();
                pageinfo.PageCount = int.Parse(PageCount.ToString());
                pageinfo.PageNo = pageNo;
                pageinfo.PageSize = int.Parse(pageSize.ToString());
                pageinfo.TotalRecordCount = int.Parse(TotalRecordCount.ToString());


                //var pageinfo = new PagingInfo();
                //pageinfo.PageCount = int.Parse(PageCount.ToString());
                //pageinfo.PageNo = pageNo;
                //pageinfo.PageSize = pageSize;
                //pageinfo.TotalRecordCount = TotalRecordCount;
                //List<CustomerResultList> abcd = query.OrderBy(x => x.Id).Skip(skip).Take(pageSize).ToList();

                //return  abcd;
                return Json(new { Success = 1, error = false, CustomerList = abcd, PageInfo = pageinfo });


                //List<CustomerResultList> abcd = query.ToList();

                //return abcd;

                //return Json(abcd);




            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        [ApiAuthorize]
        public JsonResult GetCustomer(int CustomerId)
        {
            try
            {

                var singleCustomer = _customerRepository.All(false).Where(x => x.Id == CustomerId)
                    .Select(x => new
                    {
                        x.Id,
                        x.Name,
                        x.PrimaryAddress,
                        x.SecoundaryAddress,
                        x.City,
                        x.Phone,
                        x.PostalCode,
                        x.Notes,
                        x.CustParentId,
                        x.Email,
                        x.CreateDate,
                        x.CustType,
                        x.LuserId
                    }).FirstOrDefault();

                return Json(singleCustomer);

            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        [HttpPost]
        [ApiAuthorize]
        public ActionResult CreateCustomer(CustomerModel model)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    //if (ModelState.IsValid)
                    //{
                    if (model.Id > 0)
                    {
                        _customerRepository.UpdateApi(model, model.Id);
                    }
                    else
                    {
                        _customerRepository.InsertApi(model);
                    }

                    return Ok(true);
                    //}
                    //return Ok(false);
                }
                catch (Exception x)
                {
                    Console.WriteLine(x.Message);
                    return Ok(false);

                }
            }
            else
            {
                return Ok(false);
            }

        }


        [ApiAuthorize]
        public List<SelectListItem> GetCustomerGroupDropdown()
        {
            var x = _customerRepository.GetCustomerGroupHeadForDropDown(0).ToList();
            return x;
        }

        [ApiAuthorize]
        public List<SelectListItem> GetCustomerTypeDropdown()
        {
            var datalist = new SelectList(
                   new List<SelectListItem>
                   {
            new SelectListItem {Text = "Ledger", Value = "L"},
            new SelectListItem {Text = "Group", Value = "G"},
                   }, "Value", "Text");

            var x = datalist.ToList();
            return x;
        }

        [ApiAuthorize]
        public JsonResult GetSingleCustomer(int CustomerId)
        {
            try
            {

                var singleCustomer = _customerRepository.All(false).Where(x => x.Id == CustomerId)
                    .Select(x => new
                    {
                        x.Id,
                        x.Name,
                        x.PrimaryAddress,
                        x.SecoundaryAddress,
                        x.City,
                        x.Phone,
                        x.PostalCode,
                        x.Notes,
                        x.CustParentId,
                        x.Email,
                        x.CustType,
                        x.CreateDate,
                        x.LuserId
                    }).FirstOrDefault();

                return Json(singleCustomer);

            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        [ApiAuthorize]

        public ActionResult DeleteCustomer(int CustomerId)
        {
            try
            {
                var response = _customerRepository.Find(CustomerId);

                if (response != null) _customerRepository.Delete(response);
                else if (response == null) return BadRequest(new { message = "Customer information is not available" });

                //Ok(false);

                return Ok(true);

            }
            catch (Exception x)
            {
                Console.WriteLine(x.Message);
                return BadRequest(new { message = "Something Wrong" });
            }
        }



        //[HttpGet]
        //public List<string> Get()
        //{
        //    return new List<string> { "Hello", "World" };
        //}

        //[HttpGet]
        //[Route("values/{valueName}")]
        //public string? Get(string valueName)
        //{
        //    return valueName;
        //}



        #endregion

        #region Account

        [HttpGet]
        [ApiAuthorize]
        public JsonResult GetAccountList(int pageNo = 1, decimal pageSize = 10, string searchquery = "")
        //public List<AccountResultList> GetAccountList(int pageNo = 1, int pageSize = 10, string searchquery = "")
        {
            try
            {
                var accounts = _accountHeadRepository.All();//.Include(x=>x.AccountCategorys);//.Take(30);//.Include(x=>x.vUnit).Include(x=>x.Category);.Where(x => x.ComId == 1)

                accounts = accounts.Where(x => x.AccType == "L");

                if (searchquery?.Length > 1)
                {
                    accounts = accounts.Where(x => x.AccName.ToLower().Contains(searchquery.ToLower()) || x.AccCode.ToLower().Contains(searchquery.ToLower()) || x.AccountCategorys.AccountCategoryName.ToLower().Contains(searchquery.ToLower()));
                }



                decimal TotalRecordCount = accounts.Count();
                var PageCountabc = decimal.Parse((TotalRecordCount / pageSize).ToString());
                var PageCount = Math.Ceiling(PageCountabc);
                decimal skip = (pageNo - 1) * pageSize;
                // Get total number of records
                int total = accounts.Count();


                var query = from e in accounts//.Where(x => x.Id > 0 && x.ComId == ComId).OrderByDescending(x => x.Id)
                            select new
                            {
                                Id = e.Id,
                                NumericNumber = e.NumericNumber,
                                AccCode = e.AccCode,

                                AccName = e.AccName,
                                AccType = e.AccType,

                                //AccountCategory = e.AccountCategory,
                                AccountCategory = e.AccountCategorys.AccountType ?? "",

                                ParentHeadName = e.vAccountGroupHead.AccName,
                                isSystem = e.isSystem,
                                AccountBalance = e.AccountBalance
                                //,  AccountBalance = e.AccountsTransaction.Where(x => x.TransactionType.ToLower().Contains("received")).Sum(x=>x.TransactionAmount) - e.AccountsTransaction.Where(x => x.TransactionType.ToLower().Contains("paid")).Sum(x => x.TransactionAmount)
                            };

                //if (Status == "Due")
                //{
                //    query = query.Where(x => x.TotalDue > 0);
                //}



                var abcd = query.OrderByDescending(x => x.Id).Skip(int.Parse(skip.ToString())).Take(int.Parse(pageSize.ToString())).ToList();// Take(50);
                var pageinfo = new PagingInfo();
                pageinfo.PageCount = int.Parse(PageCount.ToString());
                pageinfo.PageNo = pageNo;
                pageinfo.PageSize = int.Parse(pageSize.ToString());
                pageinfo.TotalRecordCount = int.Parse(TotalRecordCount.ToString());


                //var abcd = query.OrderBy(x => x.Id).Skip(skip).Take(pageSize).ToList();

                //return  abcd;
                return Json(new { Success = 1, error = false, AccountList = abcd, PageInfo = pageinfo });


                //List<AccountResultList> abcd = query.ToList();

                //return abcd;

                //return Json(abcd);




            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        [ApiAuthorize]
        public JsonResult GetAccount(int AccountId)
        {
            try
            {

                var singleAccount = _accountHeadRepository.All(false).Where(x => x.Id == AccountId)
                    .Select(x => new
                    {
                        x.Id,
                        x.AccCode,
                        x.AccName,
                        x.AccountCategoryId,
                        x.ParentId,
                        x.CreateDate,
                        x.AccType,
                        x.LuserId
                    }).FirstOrDefault();

                return Json(singleAccount);

            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        [HttpPost]
        [ApiAuthorize]
        public ActionResult CreateAccount(AccountHeadModel model)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    //if (ModelState.IsValid)
                    //{
                    if (model.Id > 0)
                    {
                        _accountHeadRepository.UpdateApi(model, model.Id);
                    }
                    else
                    {
                        _accountHeadRepository.InsertApi(model);
                    }

                    return Ok(true);
                    //}
                    //return Ok(false);
                }
                catch (Exception x)
                {
                    Console.WriteLine(x.Message);
                    return Ok(false);

                }
            }
            else
            {
                return Ok(false);
            }

        }


        [ApiAuthorize]
        public List<SelectListItem> GetAccountGroupDropdown()
        {
            var x = _accountHeadRepository.GetAccountGroupHeadForDropDown().ToList();
            return x;
        }

        [ApiAuthorize]
        public List<SelectListItem> GetAccountTypeDropdown()
        {
            var datalist = new SelectList(
                   new List<SelectListItem>
                   {
            new SelectListItem {Text = "Ledger", Value = "L"},
            new SelectListItem {Text = "Group", Value = "G"},
                   }, "Value", "Text");

            var x = datalist.ToList();
            return x;
        }

        [ApiAuthorize]
        public JsonResult GetSingleAccount(int AccountId)
        {
            try
            {

                var singleAccount = _accountHeadRepository.All(false).Where(x => x.Id == AccountId)
                    .Select(x => new
                    {
                        x.Id,
                        x.AccCode,
                        x.AccName,
                        x.AccountCategoryId,
                        x.ParentId,
                        x.CreateDate,
                        x.AccType,
                        x.LuserId
                    }).FirstOrDefault();

                return Json(singleAccount);

            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        [ApiAuthorize]

        public ActionResult DeleteAccount(int AccountId)
        {
            try
            {
                var response = _accountHeadRepository.Find(AccountId);

                if (response != null) _accountHeadRepository.Delete(response);
                else if (response == null) return BadRequest(new { message = "Account information is not available" });

                //Ok(false);

                return Ok(true);

            }
            catch (Exception x)
            {
                Console.WriteLine(x.Message);
                return BadRequest(new { message = "Something Wrong" });
            }
        }



        //[HttpGet]
        //public List<string> Get()
        //{
        //    return new List<string> { "Hello", "World" };
        //}

        //[HttpGet]
        //[Route("values/{valueName}")]
        //public string? Get(string valueName)
        //{
        //    return valueName;
        //}



        #endregion


        #region Unit
        [ApiAuthorize]
        public JsonResult GetUnitList()
        {
            var x = _unitRepository.All()
                .Select(p => new
                {
                    p.Id,
                    p.UnitName,
                    p.UnitShortName,
                    p.UnitNameBangla
                });

            return Json(x);
        }

        [ApiAuthorize]
        public List<SelectListItem> GetUnitDropdown()
        {
            var x = _unitRepository.GetAllForDropDown().ToList();
            return x;
        }

        [ApiAuthorize]
        public List<SelectListItem> GetAllDocForDropDown()
        {
            // Retrieve the list of documents
            var x = _docTypeRepository.GetAllDocForDropDown().ToList();

            // Create the "Please Select" item
            var pleaseSelectItem = new SelectListItem
            {
                Text = "Please Select",
                Value = "0"
            };

            // Insert the "Please Select" item at the top of the list
            x.Insert(0, pleaseSelectItem);

            // Return the modified list
            return x;
        }


        [ApiAuthorize]
        public List<SelectListItem> GetSalesDocTypeDropdown()
        {
            var x = _docTypeRepository.GetSalesDocForDropDown().ToList();
            return x;
        }


        [ApiAuthorize]
        public List<SelectListItem> GetPurchaseDocTypeDropdown()
        {
            var x = _docTypeRepository.GetPurchaseDocForDropDown().ToList();
            return x;
        }




        [HttpPost]
        [ApiAuthorize]
        public ActionResult CreateUnit(UnitModel model)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    //if (ModelState.IsValid)
                    //{
                    if (model.Id > 0)
                    {
                        _unitRepository.UpdateApi(model, model.Id);
                    }
                    else
                    {
                        _unitRepository.InsertApi(model);
                    }

                    return Ok(true);
                    //}
                    //return Ok(false);
                }
                catch (Exception x)
                {
                    Console.WriteLine(x.Message);
                    return Ok(false);

                }
            }
            else
            {
                return Ok(false);
            }

        }

        [HttpGet]
        [ApiAuthorize]
        public JsonResult GetSingleUnit(int UnitId)
        {
            var Unit = _unitRepository.All().Where(x => x.Id == UnitId)
                .Select(p => new
                {
                    p.Id,
                    p.UnitName,
                    p.UnitShortName,
                    p.UnitNameBangla,
                    p.CreateDate,
                    p.LuserId
                });

            return Json(Unit);
        }
        [ApiAuthorize]
        public ActionResult DeleteUnit(int UnitId)
        {
            try
            {
                var response = _unitRepository.Find(UnitId);

                if (response != null) _unitRepository.Delete(response);
                else if (response == null) return BadRequest(new { message = "Unit information Can not be Deleted" });

                //Ok(false);

                return Ok(true);

            }
            catch (Exception x)
            {
                Console.WriteLine(x.Message);
                return BadRequest(new { message = "Something Wrong" });
            }
        }
        #endregion

        #region Category
        [ApiAuthorize]
        public JsonResult GetCategoryList()
        {
            var x = _categoryRepository.All().Include(x => x.Categories).OrderByDescending(x => x.Id)
            .Select(p => new
            {
                Id = p.Id,
                Name = p.Name,
                Description = p.Description,
                ParentCategory = p.Categories.Name,
                p.CategoryParentId,
                p.CreateDate,
                p.LuserId
            });
            return Json(x);
        }

        [ApiAuthorize]
        public List<SelectListItem> GetCategoryDropdown(int? IsReport)
        {
            //fahad
            var x = _categoryRepository.GetAllForDropDown().ToList();
            if (x.Count() > 1)
            {
                x[1].Selected = true;
            }


            //x = x.FirstOrDefault().Selected;
            if (IsReport == 1)
            {
                var AllData = new SelectListItem { Text = "ALL", Value = null };
                x.Add(AllData);
            }
            return x.OrderBy(x => x.Value).ToList();

            //var x = _categoryRepository.GetAllForDropDown().ToList();
            //return x;
        }


        [ApiAuthorize]
        public List<SelectListItem> GetBrandDropdown(int? IsReport)
        {
            //fahad
            var x = _productRepository.GetBrandDropDown().ToList();
            if (x.Count() > 1)
            {
                x[1].Selected = true;
            }


            //x = x.FirstOrDefault().Selected;
            if (IsReport == 1)
            {
                var AllData = new SelectListItem { Text = "ALL", Value = null };
                x.Add(AllData);
            }
            return x.OrderBy(x => x.Value).ToList();

            //var x = _categoryRepository.GetAllForDropDown().ToList();
            //return x;
        }
        [ApiAuthorize]
        public List<SelectListItem> GetColorDropdown(int? IsReport)
        {
            //fahad
            var x = _productRepository.GetColorDropDown().ToList();
            if (x.Count() > 1)
            {
                x[1].Selected = true;
            }


            //x = x.FirstOrDefault().Selected;
            if (IsReport == 1)
            {
                var AllData = new SelectListItem { Text = "ALL", Value = null };
                x.Add(AllData);
            }
            return x.OrderBy(x => x.Value).ToList();

            //var x = _categoryRepository.GetAllForDropDown().ToList();
            //return x;
        }
        [ApiAuthorize]
        public List<SelectListItem> GetSizeDropdown(int? IsReport)
        {
            //fahad
            var x = _productRepository.GetSizeDropDown().ToList();
            if (x.Count() > 1)
            {
                x[1].Selected = true;
            }


            //x = x.FirstOrDefault().Selected;
            if (IsReport == 1)
            {
                var AllData = new SelectListItem { Text = "ALL", Value = null };
                x.Add(AllData);
            }
            return x.OrderBy(x => x.Value).ToList();

            //var x = _categoryRepository.GetAllForDropDown().ToList();
            //return x;
        }
        [ApiAuthorize]
        public List<SelectListItem> GetModelDropdown(int? IsReport)
        {
            //fahad
            var x = _productRepository.GetModelDropDown().ToList();
            if (x.Count() > 1)
            {
                x[1].Selected = true;
            }


            //x = x.FirstOrDefault().Selected;
            if (IsReport == 1)
            {
                var AllData = new SelectListItem { Text = "ALL", Value = null };
                x.Add(AllData);
            }
            return x.OrderBy(x => x.Value).ToList();

            //var x = _categoryRepository.GetAllForDropDown().ToList();
            //return x;
        }



        //[HttpGet]
        //public ActionResult AddCategory()
        //{
        //    ViewBag.ActionType = "Create";
        //    return View();
        //}

        [HttpPost]
        [ApiAuthorize]
        public ActionResult CreateCategory(CategoryModel model)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    //if (ModelState.IsValid)
                    //{
                    if (model.Id > 0)
                    {
                        _categoryRepository.UpdateApi(model, model.Id);
                    }
                    else
                    {
                        _categoryRepository.InsertApi(model);
                    }

                    return Ok(true);
                    //}
                    //return Ok(false);
                }
                catch (Exception x)
                {
                    Console.WriteLine(x.Message);
                    return Ok(false);

                }
            }
            else
            {
                return Ok(false);
            }

        }

        [HttpGet]
        [ApiAuthorize]
        public JsonResult GetSingleCategory(int CategoryId)
        {
            var Category = _categoryRepository.All().Include(x => x.Categories).Where(x => x.Id == CategoryId)
                .Select(p => new
                {
                    Id = p.Id,
                    Name = p.Name,
                    Description = p.Description,
                    CategoryParentId = p.CategoryParentId,
                    ParentCategory = p.Categories.Name,
                    p.CreateDate,
                    p.LuserId
                });
            return Json(Category);
        }
        [ApiAuthorize]
        public ActionResult DeleteCategory(int CategoryId)
        {
            try
            {
                var response = _categoryRepository.Find(CategoryId);

                if (response != null) _categoryRepository.Delete(response);
                else if (response == null) return BadRequest(new { message = "Category information Can not be Deleted" });

                //Ok(false);

                return Ok(true);

            }
            catch (Exception x)
            {
                Console.WriteLine(x.Message);
                return BadRequest(new { message = "Something Wrong" });
            }
        }
        #endregion

        #region Dashboard

        [ApiAuthorize]
        public JsonResult Dashboard()
        {
            try
            {
                //Exec [prcProcessMonthlySubscriptionFee] 1, '01-Jan-2021','31-JAN-2021'/
                var ComId = HttpContext.Session.GetInt32("ComId");

                var query = $"Exec prcProcessAccountData '{ComId}'";

                SqlParameter[] sqlParameter = new SqlParameter[1];
                sqlParameter[0] = new SqlParameter("@ComId", ComId);
                Helper.ExecProc("prcProcessAccountData", sqlParameter);

                var genericResult = new
                {
                    totalsalessummary = "Dashboard"
                };
                return Json(genericResult);

            }
            catch (Exception ex)
            {
                return Json(new { success = false, values = ex.Message.ToString() });
            }
        }





        #endregion

        #region SalesEntry


        [ApiAuthorize]
        public ActionResult SaleReport(int saleId, string format = "PDF", int isfile = 0)
        {
            //string resulta = "";
            //var weburl = Request.Scheme + "://" + Request.Host.Value + "/" + Request.QueryString.Value;
            ////var weburl = Request.GetTypedHeaders().Referer.ToString().ToLower();//.Replace("/Home/Login".ToLower(), "");

            //var origin = weburl.ToLower();
            //var weburlquerystring = Request.QueryString.HasValue == true ? Request.QueryString.ToString() : "";// Request.QueryString == null ? "": Request.QueryString;// Request.QueryString?? Request.QueryString;//.Replace("/Home/Login".ToLower(), "");

            //if (weburlquerystring.Length > 2)
            //{
            //    resulta = origin.Replace(weburlquerystring.ToLower(), "").Replace("/Home/Login".ToLower(), "");

            //}
            //else
            //{
            //    resulta = origin.Replace("/Home/Login".ToLower(), "");

            //}
            //HttpContext.Session.SetString("weburl", resulta.ToString());
            HttpContext.Session.SetString("ReportType", format);



            //string weburl = Config.GetSection("host").Value;

            Atrai.Model.AppData.DefaultConnectionString = Config.GetConnectionString("DefaultConnection");

            var UserId = HttpContext.Session.GetInt32("UserId");
            var ComId = HttpContext.Session.GetInt32("ComId");

            string weburl = Config.GetSection("hostimage").Value;

            //string weburl = HttpContext.Session.GetString("weburl"); //"https://www.pqstec.com/InvoiceApps";//  HttpContext.Session.GetString("weburl"); 
            var ReportStyle = _storeSettingRepository.All().Include(x => x.SalesReportStyle).Select(x => x.SalesReportStyle.ReportStyleName).FirstOrDefault(); //HttpContext.Session.GetString("SalesReportStyle");

            string reportname = "rptInvoice";
            var filename = "Invoice_";


            if (ReportStyle.ToString().Length > 0)
            {
                reportname = "rptInvoice_" + ReportStyle.ToString();
            }

            //Atrai.Model.AppDataDynamic ReportInfo = new Atrai.Model.AppDataDynamic();
            //ReportInfo.ReportPath = "~/ReportViewer/POS/" + reportname + ".rdlc";
            //ReportInfo.ReportQuery = "Exec  [rptInvoice] '" + saleId + "','" + ComId + "', '" + weburl + "','Invoice'";
            //ReportInfo.PrintFileName = filename.Replace(".", "").Replace(" ", "").Replace(",", "").Replace("\"", "");

            HttpContext.Session.SetString("ReportQuery", "Exec  [rptInvoice] '" + saleId + "','" + ComId + "', '" + weburl + "','Invoice'");
            HttpContext.Session.SetString("ReportPath", "~/ReportViewer/POS/" + reportname + ".rdlc");
            HttpContext.Session.SetString("PrintFileName", filename.Replace(".", "").Replace(" ", "").Replace(",", "").Replace("\"", ""));




            //postData.Add(1, new subReport("rptInvoice_Terms", "", "DataSet1", "Exec " + Atrai.Model.AppData.dbGTCommercial.ToString() + ".dbo.rptInvoice_Terms '" + id + "','" + Session["comid"].ToString() + "',''"));
            //postData.Add(1, new subReport("rptInvoice_BankDetails", "", "DataSet1", "Exec rptInvoice_BankDetails '" + saleId + "'," + ComId + ",'" + Atrai.Model.AppData.AppPath.ToString() + "'"));
            //postData.Add(1, new subReport("rptInvoice_PM", "", "DataSet1", "Exec rptInvoice_PM '" + saleId + "'," + ComId + ""));

            if (reportname.ToLower().Contains("pos"))
            {
                postData.Add(1, new subReport("rptInvoice_POS_PM", "", "DataSet1", "Exec rptInvoice_PM '" + saleId + "'," + ComId + ""));
            }
            else
            {
                postData.Add(1, new subReport("rptInvoice_PM", "", "DataSet1", "Exec rptInvoice_PM '" + saleId + "'," + ComId + ""));
                //postData.Add(1, new subReport("rptInvoice_Terms", "", "DataSet1", "Exec rptInvoice_Terms '" + saleId + "'," + ComId + ""));

            }
            postData.Add(2, new subReport("rptInvoice_Terms", "", "DataSet1", "Exec rptInvoice_Terms '" + saleId + "'," + ComId + ""));

            //clsReport.rptList.Add(new subReport("rptInvoice_Terms", "", "DataSet1", "Exec " + Atrai.Model.AppData.dbGTCommercial.ToString() + ".dbo.rptInvoice_Terms '" + id + "'," + Session["comid"].ToString() + ",'" + Atrai.Model.AppData.AppPath.ToString() + "'"));

            HttpContext.Session.SetObject("rptList", postData);
            //return RedirectToAction("Index", "ReportViewer");
            return RedirectToAction("Index", "ReportViewer", new { reporttype = format, isfile = isfile });
        }



        [ApiAuthorize]
        public ActionResult OnlineSaleReport(int saleId, string format = "PDF", int isfile = 0)
        {

            HttpContext.Session.SetString("ReportType", format);



            //string weburl = Config.GetSection("host").Value;

            Atrai.Model.AppData.DefaultConnectionString = Config.GetConnectionString("DefaultConnection");

            var UserId = HttpContext.Session.GetInt32("UserId");
            var ComId = HttpContext.Session.GetInt32("ComId");

            string weburl = Config.GetSection("hostimage").Value;

            //string weburl = HttpContext.Session.GetString("weburl"); //"https://www.pqstec.com/InvoiceApps";//  HttpContext.Session.GetString("weburl"); 
            var ReportStyle = _storeSettingRepository.All().Include(x => x.SalesReportStyle).Select(x => x.SalesReportStyle.ReportStyleName).FirstOrDefault(); //HttpContext.Session.GetString("SalesReportStyle");

            string reportname = "rptInvoice";
            var filename = "Invoice_";


            if (ReportStyle.ToString().Length > 0)
            {
                reportname = "rptInvoice_" + ReportStyle.ToString();
            }

            //Atrai.Model.AppDataDynamic ReportInfo = new Atrai.Model.AppDataDynamic();
            //ReportInfo.ReportPath = "~/ReportViewer/POS/" + reportname + ".rdlc";
            //ReportInfo.ReportQuery = "Exec  [rptInvoice] '" + saleId + "','" + ComId + "', '" + weburl + "','Invoice'";
            //ReportInfo.PrintFileName = filename.Replace(".", "").Replace(" ", "").Replace(",", "").Replace("\"", "");

            HttpContext.Session.SetString("ReportQuery", "Exec  [rptOnlineOrders] '" + saleId + "','" + ComId + "', '" + weburl + "','Invoice'");
            HttpContext.Session.SetString("ReportPath", "~/ReportViewer/POS/" + reportname + ".rdlc");
            HttpContext.Session.SetString("PrintFileName", filename.Replace(".", "").Replace(" ", "").Replace(",", "").Replace("\"", ""));




            //postData.Add(1, new subReport("rptInvoice_Terms", "", "DataSet1", "Exec " + Atrai.Model.AppData.dbGTCommercial.ToString() + ".dbo.rptInvoice_Terms '" + id + "','" + Session["comid"].ToString() + "',''"));
            //postData.Add(1, new subReport("rptInvoice_BankDetails", "", "DataSet1", "Exec rptInvoice_BankDetails '" + saleId + "'," + ComId + ",'" + Atrai.Model.AppData.AppPath.ToString() + "'"));
            //postData.Add(1, new subReport("rptInvoice_PM", "", "DataSet1", "Exec rptInvoice_PM '" + saleId + "'," + ComId + ""));

            if (reportname.ToLower().Contains("pos"))
            {
                postData.Add(1, new subReport("rptInvoice_POS_PM", "", "DataSet1", "Exec rptInvoice_PM '" + saleId + "'," + ComId + ""));
            }
            else
            {
                postData.Add(1, new subReport("rptInvoice_PM", "", "DataSet1", "Exec rptInvoice_PM '" + saleId + "'," + ComId + ""));
                //postData.Add(1, new subReport("rptInvoice_Terms", "", "DataSet1", "Exec rptInvoice_Terms '" + saleId + "'," + ComId + ""));

            }
            postData.Add(2, new subReport("rptInvoice_Terms", "", "DataSet1", "Exec rptInvoice_Terms '" + saleId + "'," + ComId + ""));

            //clsReport.rptList.Add(new subReport("rptInvoice_Terms", "", "DataSet1", "Exec " + Atrai.Model.AppData.dbGTCommercial.ToString() + ".dbo.rptInvoice_Terms '" + id + "'," + Session["comid"].ToString() + ",'" + Atrai.Model.AppData.AppPath.ToString() + "'"));

            HttpContext.Session.SetObject("rptList", postData);
            //return RedirectToAction("Index", "ReportViewer");
            return RedirectToAction("Index", "ReportViewer", new { reporttype = format, isfile = isfile });
        }




        [ApiAuthorize]
        public JsonResult GetSalesList(string FromDate, string ToDate, int? CustomerId, int? UserId, string Status, int? WarehouseId, int? CategoryId, int pageNo = 1, decimal pageSize = 10, string searchquery = "")
        {

            var ComId = (HttpContext.Session.GetInt32("ComId"));
            var sessionLuserId = (HttpContext.Session.GetInt32("UserId"));
            var UserRole = HttpContext.Session.GetString("UserRole");

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
            //var x = Request.Form.TryGetValue("search[value]", out y);

            var saleslist = _saleRepository.All();




            //if (y.ToString().Length > 0)
            //{


            //}
            if (searchquery?.Length > 1)
            {
                saleslist = saleslist.Where(x => x.SaleCode.ToLower().Contains(searchquery.ToLower()));
            }
            else
            {
                saleslist = saleslist.Where(p => (p.SalesDate >= dtFrom && p.SalesDate <= dtTo));

                if (CustomerId != null)
                {
                    saleslist = saleslist.Where(p => p.CustomerId == CustomerId);
                }
                if (UserId != null)
                {
                    saleslist = saleslist.Where(p => p.LuserId == UserId);
                }
                if (CategoryId != null)
                {
                    saleslist = saleslist.Where(x => x.Items.Any(x => x.Product.CategoryId == CategoryId));
                }
                else
                {
                    if (UserRole == "Admin" || UserRole == "SuperAdmin")
                    {
                    }
                    else
                    {
                        saleslist = saleslist.Where(p => p.LuserId == sessionLuserId);

                    }

                }
                if (WarehouseId != null)
                {
                    saleslist = saleslist.Where(p => p.WarehouseIdMain == WarehouseId);
                }
                else
                {
                    var arrayabc = FromWarehousePermissionRepository.All().Where(x => x.LuserIdAllow == sessionLuserId).Select(x => x.WarehouseId).ToList();
                    //int a = 1;
                    //List<int> IDs = new List<int> { 1, 3, 4, 8 };

                    //var warehouselist = FromWarehousePermissionRepository.All().Select(x=>x.Id);
                    if (arrayabc.Count() > 0)
                    {
                        saleslist = saleslist.Where(p => arrayabc.Contains(p.WarehouseIdMain));
                    }
                }


                if (Status == "Due")
                {
                    //var saleslistmore = saleslist.Where(x => x.GrandTotal -  x.SalesPayments.Sum(x=>x.Amount) > 0);

                    saleslist = saleslist.Where(x => x.GrandTotal - x.SalesPayments.Sum(x => x.Amount) > 0);

                    //saleslist = saleslist.Where(x=>x.SalesPayments.Count == 0);


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



            //////// pagination with lenght

            decimal TotalRecordCount = saleslist.Count();
            var PageCountabc = decimal.Parse((TotalRecordCount / pageSize).ToString());
            var PageCount = Math.Ceiling(PageCountabc);
            decimal skip = (pageNo - 1) * pageSize;
            // Get total number of records
            int total = saleslist.Count();
            ///


            var query = from e in saleslist.Include(x => x.Items).Include(x => x.SalesPayments).ThenInclude(x => x.vChartofAccounts).Include(x => x.DocTypeList)
                        select new SalesResultList
                        {
                            Id = e.Id,
                            SaleCode = e.SaleCode,
                            SalesDate = e.SalesDate,
                            SalesDateString = e.SalesDate.ToString("dd-MMM-yy") + " " + e.CreateDate.ToString("HH:mm"),

                            SalesUser = e.UserAccountList.Name,
                            CustomerName = (e.CustomerName.Length == 0 || e.CustomerName == null) ? e.CustomerModel.Name : e.CustomerModel.Name + " - " + e.CustomerName,
                            //CustomerName = e.CustomerName,
                            PrimaryAddress = e.PrimaryAddress,
                            SecoundaryAddress = e.SecoundaryAddress,
                            Notes = e.Notes,
                            PhoneNo = e.PhoneNo,
                            Discount = e.Discount,
                            Total = e.Total,
                            StatusRemarks = e.StatusRemarks,
                            NetAmount = e.NetAmount,
                            isPOSSales = e.isPOSSales,
                            isSerialSales = e.isSerialSales,
                            isPosted = e.isPosted,
                            FinalCostingPrice = e.FinalCostingPrice,
                            Profit = e.Profit,
                            DocType = e.DocTypeList.DocType,

                            ProfitPercentage = e.ProfitPercentage,
                            Location = e.Warehouses.WhShortName,
                            StatusPosted = e.isPosted != false ? "Posted" : "Not Posted",
                            PaidAmt = e.SalesPayments.Sum(x => x.Amount),// e.PaidAmt,
                            DueAmt = e.NetAmount - e.SalesPayments.Sum(x => x.Amount),
                            //ReceivingHead = e.AccountPayType != null ? e.AccountPayType.AccName : "=N/A="




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

                                BrandName = x.Product.Brand != null ? x.Product.Brand.BrandName : "",
                                ModelName = x.Product.ModelName,
                                VariantName = x.Product.SizeName,
                                SizeName = x.Product.SizeName,
                                ColorName = x.Product.ColorName,
                                UnitName = x.Product.Unit.UnitShortName,


                                //ProductSerial = x.Product.PurchaseBatchItems.ToList(),
                                ProductSerialList = x.BatchSerialItems.Select(x => new
                                {
                                    SerialNo = x.BatchSerialNo
                                }
                                ),
                                Price = x.Price,
                                CostPrice = x.CostPrice,
                                AvgCostPrice = x.AvgCostPrice,
                                IndDiscountProportion = x.IndDiscountProportion,
                                Quantity = x.Quantity,
                                Amount = x.Amount,
                                //ProfitPer = x.profit,
                                CommissionAmount = x.CommissionAmount

                            }),




                            //SalesPayments = e.SalesPayments.Select(x => new
                            //{
                            //    x.SalesId,
                            //    x.PaymentCardNo,
                            //    x.isPosted,
                            //    x.Amount,
                            //    x.RowNo,
                            //    x.AccountHeadId,
                            //    AccType = x.vChartofAccounts.AccType,
                            //    AccName = x.vChartofAccounts.AccName
                            //}).ToList()





                        };



            var abcd = query.OrderByDescending(x => x.Id).Skip(int.Parse(skip.ToString())).Take(int.Parse(pageSize.ToString())).ToList();// Take(50);
            var pageinfo = new PagingInfo();
            pageinfo.PageCount = int.Parse(PageCount.ToString());
            pageinfo.PageNo = pageNo;
            pageinfo.PageSize = int.Parse(pageSize.ToString());
            pageinfo.TotalRecordCount = int.Parse(TotalRecordCount.ToString());


            //List<ProductResult> abcd = query.OrderByDescending(x => x.Id).Skip(skip).Take(pageSize).ToList();

            //return  abcd;
            return Json(new { Success = 1, error = false, SalesList = abcd, PageInfo = pageinfo });


            //return Json(abcd);

            //var parser = new Parser<SalesResultList>(Request.Form, query);

            //return Json(parser.Parse());


        }




        [ApiAuthorize]
        public JsonResult GetOnlineSalesList(string FromDate, string ToDate, int? CustomerId, int? UserId, string Status, int? WarehouseId, int? CategoryId, int pageNo = 1, decimal pageSize = 10, string searchquery = "")
        {

            var ComId = (HttpContext.Session.GetInt32("ComId"));
            var sessionLuserId = (HttpContext.Session.GetInt32("UserId"));
            var UserRole = HttpContext.Session.GetString("UserRole");

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
            ////var x = Request.Form.TryGetValue("search[value]", out y);

            //var saleslist = _ordresRepository.All();




            ////if (y.ToString().Length > 0)
            ////{


            ////}
            //if (searchquery?.Length > 1)
            //{
            //    saleslist = saleslist.Where(x => x.OrderCode.ToLower().Contains(searchquery.ToLower()));
            //}
            //else
            //{
            //    saleslist = saleslist.Where(p => (p.OrdersDate >= dtFrom && p.OrdersDate <= dtTo));

            //    if (CustomerId != null)
            //    {
            //        saleslist = saleslist.Where(p => p.CustomerId == CustomerId);
            //    }
            //    if (UserId != null)
            //    {
            //        saleslist = saleslist.Where(p => p.LuserId == UserId);
            //    }
            //    if (CategoryId != null)
            //    {
            //        saleslist = saleslist.Where(x => x.Items.Any(x => x.Product.CategoryId == CategoryId));
            //    }
            //    else
            //    {
            //        if (UserRole == "Admin" || UserRole == "SuperAdmin")
            //        {
            //        }
            //        else
            //        {
            //            saleslist = saleslist.Where(p => p.LuserId == sessionLuserId);

            //        }

            //    }
            //    //if (WarehouseId != null)
            //    //{
            //    //    saleslist = saleslist.Where(p => p.WarehouseIdMain == WarehouseId);
            //    //}
            //    //else
            //    //{
            //    //    var arrayabc = FromWarehousePermissionRepository.All().Where(x => x.LuserIdAllow == sessionLuserId).Select(x => x.WarehouseId).ToList();
            //    //    //int a = 1;
            //    //    //List<int> IDs = new List<int> { 1, 3, 4, 8 };

            //    //    //var warehouselist = FromWarehousePermissionRepository.All().Select(x=>x.Id);
            //    //    if (arrayabc.Count() > 0)
            //    //    {
            //    //        saleslist = saleslist.Where(p => arrayabc.Contains(p.WarehouseIdMain));
            //    //    }
            //    //}


            //    if (Status == "Due")
            //    {
            //        //var saleslistmore = saleslist.Where(x => x.GrandTotal -  x.SalesPayments.Sum(x=>x.Amount) > 0);

            //        saleslist = saleslist.Where(x => x.GrandTotal - x.OrdersPayments.Sum(x => x.Amount) > 0);

            //        //saleslist = saleslist.Where(x=>x.SalesPayments.Count == 0);


            //    }
            //    //else
            //    //{
            //    //    //saleslist = saleslist.Where(p => p.SalesDate >= dtFrom && p.SalesDate <= dtTo);

            //    //    //if (CustomerId == 1)
            //    //    //{
            //    //    //    saleslist = saleslist.Where(p => p.SalesDate >= dtFrom && p.SalesDate <= dtTo);
            //    //    //}
            //    //    //else
            //    //    //{
            //    //    //}
            //    //}

            //}








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

            //Microsoft.Extensions.Primitives.StringValues y = "";
            //var x = Request.Form.TryGetValue("search[value]", out y);

            var onlinesaleslist = _ordresRepository.All();




            if (searchquery?.Length > 1)
            {
                onlinesaleslist = onlinesaleslist.Where(x => x.OrderCode.ToLower().Contains(searchquery.ToLower()));
            }
            else
            {
                onlinesaleslist = onlinesaleslist.Where(p => (p.OrdersDate >= dtFrom && p.OrdersDate <= dtTo));



                //var UserRole = HttpContext.Session.GetString("UserRole");
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
                    var empid = _userAccountRepository.All().Where(x => x.Id == sessionLuserId).FirstOrDefault().EmployeeId;
                    var custidlist = _customerRepository.All().Where(p => p.SalesRepresentativeId == empid)
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
                //    var arrayabc = FromWarehousePermissionRepository.All().Where(x => x.LuserIdAllow == sessionLuserId).Select(x => x.WarehouseId).ToList();
                //    //int a = 1;
                //    //List<int> IDs = new List<int> { 1, 3, 4, 8 };

                //    //var warehouselist = FromWarehousePermissionRepository.All().Select(x=>x.Id);
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







            //////// pagination with lenght

            decimal TotalRecordCount = onlinesaleslist.Count();
            var PageCountabc = decimal.Parse((TotalRecordCount / pageSize).ToString());
            var PageCount = Math.Ceiling(PageCountabc);
            decimal skip = (pageNo - 1) * pageSize;
            // Get total number of records
            int total = onlinesaleslist.Count();
            ///


            var query = from e in onlinesaleslist.Include(x => x.Items).Include(x => x.OrdersPayments)
                        select new
                        {
                            Id = e.Id,
                            SaleCode = e.OrderCode,
                            SalesDate = e.OrdersDate,
                            SalesDateString = e.OrdersDate.ToString("dd-MMM-yy"),

                            SalesUser = e.UserAccountList.Name,

                            CustomerName = (e.CustomerName.Length == 0 || e.CustomerName == null) ? e.CustomerModel.Name : e.CustomerModel.Name + " - " + e.CustomerName,
                            //CustomerName = e.CustomerName,
                            PrimaryAddress = e.PrimaryAddress,
                            SecoundaryAddress = e.SecoundaryAddress,
                            Notes = e.Notes,
                            PhoneNo = e.PhoneNo,
                            Discount = e.DisAmt,
                            Total = e.GrandTotal,
                            Status = e.Status,
                            NetAmount = e.NetAmount,
                            //isPOSSales = e.isPOSSales,
                            //isSerialSales = e.isSerialSales,
                            isPosted = e.isPosted,
                            //FinalCostingPrice = e.FinalCostingPrice,
                            //Profit = e.Profit,
                            //ProfitPercentage = e.ProfitPercentage,
                            //Location = e.Warehouses.WhShortName,
                            StatusPosted = e.isPosted != false ? "Placed" : "Pending",
                            PaidAmt = e.OrdersPayments.Sum(x => x.Amount),// e.PaidAmt,
                                                                          //ReceivingHead = e.AccountPayType != null ? e.AccountPayType.AccName : "=N/A="
                            SalesPayments = e.OrdersPayments.Select(x => new
                            {
                                x.Id,
                                x.PaymentCardNo,
                                //x.isPosted,
                                x.Amount,
                                x.RowNo,
                                //x.AccountHeadId,
                                //AccType = x.vChartofAccounts.AccType,
                                //AccName = x.vChartofAccounts.AccName
                            }).ToList()
                        };



            var abcd = query.OrderByDescending(x => x.Id).Skip(int.Parse(skip.ToString())).Take(int.Parse(pageSize.ToString())).ToList();// Take(50);
            var pageinfo = new PagingInfo();
            pageinfo.PageCount = int.Parse(PageCount.ToString());
            pageinfo.PageNo = pageNo;
            pageinfo.PageSize = int.Parse(pageSize.ToString());
            pageinfo.TotalRecordCount = int.Parse(TotalRecordCount.ToString());


            //List<ProductResult> abcd = query.OrderByDescending(x => x.Id).Skip(skip).Take(pageSize).ToList();

            //return  abcd;
            return Json(new { Success = 1, error = false, SalesList = abcd, PageInfo = pageinfo });


            //return Json(abcd);

            //var parser = new Parser<SalesResultList>(Request.Form, query);

            //return Json(parser.Parse());


        }





        [ApiAuthorize]
        public List<SelectListItem> GetCustomerDropdown()
        { /// sales list

            var UserId = HttpContext.Session.GetInt32("UserId");
            var userrole = HttpContext.Session.GetString("UserRole") ?? "";

            //var AllData = new SelectList(new List<SelectListItem> { new SelectListItem { Text = "ALL", Value = null } }, "Value", "Text").FirstOrDefault();
            var AllData = new SelectListItem { Text = "ALL", Value = null };

            var x = _customerRepository.GetAllForDropDown().ToList();
            x.Add(AllData);
            return x.OrderBy(x => x.Value).ToList();
        }

        [ApiAuthorize]
        public List<SelectListItem> GetWarehouseDropdown(int? IsReport)
        { // sales list
            var sessionLuserId = (HttpContext.Session.GetInt32("UserId"));
            var UserId = HttpContext.Session.GetInt32("UserId");
            var UserRole = HttpContext.Session.GetString("UserRole") ?? "";
            //var AllData = new SelectList(new List<SelectListItem> { new SelectListItem { Text = "ALL", Value = null } }, "Value", "Text").FirstOrDefault();
            //var AllData = new SelectListItem { Text = "ALL", Value = null };


            //SelectListItem abc = new SelectListItem() { Text = "Please Select", Value = "" };
            SelectListItem AllData = new SelectListItem() { Text = "ALL", Value = null };


            var warehosuepermission = FromWarehousePermissionRepository.GetAllForDropDown().ToList();
            if (warehosuepermission.Count() == 0)
            {
                warehosuepermission = _warehouseRepository.GetWarehouseLedgerHeadForDropDown().ToList();
                if (IsReport == 1)
                {
                    warehosuepermission.Add(AllData);
                }
            }
            //else            //{            //    //x.Append(abc);            //}
            return warehosuepermission.OrderBy(x => x.Value).ToList();

            //if (UserRole == "Admin" || UserRole == "SuperAdmin")
            //{
            //    var x = _warehouseRepository.GetWarehouseLedgerHeadForDropDown().ToList();
            //    if (IsReport != null)
            //    {
            //        x.Add(AllData);

            //    }
            //    return x;//.OrderBy(x => x.Value).ToList();
            //}
            //else
            //{
            //    //var abc = FromWarehousePermissionRepository.All().Where(x => x.LuserId == UserId).Count();
            //    var x = FromWarehousePermissionRepository.GetAllForDropDown().ToList();
            //    if (x.Count() == 0)
            //    {
            //        x = _warehouseRepository.GetWarehouseLedgerHeadForDropDown().ToList();
            //    }

            //    if (IsReport != null)
            //    {
            //        x.Add(AllData);

            //    }
            //    //x.OrderBy(x => x.Value);
            //    return x;//.OrderBy(x => x.Value).ToList();
            //}

        }




        [ApiAuthorize]
        public JsonResult GetProductDropdown()
        {
            var x = _productRepository.All().Include(x => x.Unit)
                   .Select(p => new { ProductId = p.Id, PrdName = p.Name, SalesPrice = p.Price, CostPrice = p.CostPrice, UnitName = p.Unit.UnitShortName, Unitid = p.UnitId })
                   .Take(30);

            return Json(x);
        }

        [ApiAuthorize]
        public List<SelectListItem> GetBarcodeDropdown()
        {
            var x = _productRepository.GetAllBarcodeForDropDown().ToList();
            return x;
        }

        [ApiAuthorize]
        public List<SelectListItem> GetAccountHeadDropdown()
        {
            var x = _accountHeadPermissionRepository.GetAllForDropDown();
            if (x.Count() == 0)
            {
                x = _accountHeadRepository.GetCashBankHeadForDropDown(false);
            }
            //ViewBag.Warehouse = x;

            ///fahad need to update
            return x.ToList();



            //var x = _accountHeadRepository.GetCashBankHeadForDropDown().ToList();
            //return x;
        }

        [ApiAuthorize]
        public List<SelectListItem> GetFiscalYearDropdown()
        {
            var x = _accFiscalYear.GetAllForDropDown();

            return x.ToList();

        }

        [ApiAuthorize]
        public List<SelectListItem> GetSalesRepresentativeDropdown()
        {
            var x = _employeeRepository.GetAllForDropDown().ToList();
            return x;
        }



        [AllowAnonymous]
        public JsonResult GetLedgerBalance(int AccountId, int TransactionId = 0)
        {

            ////exec dbo.[PrcProcess_Transaction_ConvertDebitCredit] 'AccountsTransactionCheck', '1-jan-1900' , '31-dec-2025' , @comid , 0 , @accid-- - for reset the data send to 1 for reset value

            var fromdate = DateTime.Now.Date;
            var todate = DateTime.Now.Date.AddYears(3);

            var ComId = HttpContext.Session.GetInt32("ComId");
            //Exec [prcProcessMonthlySubscriptionFee] 1, '01-Jan-2021','31-JAN-2021'/
            var query = $"Exec PrcProcess_Transaction_ConvertDebitCredit 'AccountsTransactionCheck','{fromdate}','{todate}','{ComId}','0',{AccountId}";
            //@Criteria varchar(200), 
            //@FromDate datetime = default,
            //@ToDate datetime = default , 
            //@comid varchar(20) = '',
            //@Reset int = 0,
            //@AccId varchar(40) = ''
            SqlParameter[] sqlParameter = new SqlParameter[6];
            sqlParameter[0] = new SqlParameter("@Criteria", "AccountsTransactionCheck");
            sqlParameter[1] = new SqlParameter("@FromDate", fromdate);
            sqlParameter[2] = new SqlParameter("@ToDate", todate);
            sqlParameter[3] = new SqlParameter("@comid", ComId);
            sqlParameter[4] = new SqlParameter("@Reset", "0");
            sqlParameter[5] = new SqlParameter("@AccId", AccountId);

            Helper.ExecProc("PrcProcess_Transaction_ConvertDebitCredit", sqlParameter);



            if (TransactionId > 0)
            {
                //var transactionamount = _transactionRepository.All().Where(x => x.Id == TransactionId).FirstOrDefault().TransactionAmount;
                var AccountBalance = _accountHeadRepository.All().Where(x => x.Id == AccountId).FirstOrDefault().AccountBalance; //- transactionamount;

                return Json(AccountBalance);

            }
            else
            {
                var AccountBalance = _accountHeadRepository.All().Where(x => x.Id == AccountId).FirstOrDefault().AccountBalance;

                return Json(AccountBalance);
            }


        }



        [AllowAnonymous]
        public JsonResult GetLedgerBalanceWithCategory(string AccountId = "", int TransactionId = 0)
        {


            try
            {



                ////exec dbo.[PrcProcess_Transaction_ConvertDebitCredit] 'AccountsTransactionCheck', '1-jan-1900' , '31-dec-2025' , @comid , 0 , @accid-- - for reset the data send to 1 for reset value

                var fromdate = DateTime.Now.Date;
                var todate = DateTime.Now.Date.AddYears(3);

                var ComId = HttpContext.Session.GetInt32("ComId");
                //Exec [prcProcessMonthlySubscriptionFee] 1, '01-Jan-2021','31-JAN-2021'/
                var query = $"Exec PrcProcess_Transaction_ConvertDebitCredit 'AccountsTransactionCheck','{fromdate.ToString("dd-MMM-yy")}','{todate.ToString("dd-MMM-yy")}','{ComId}','0',{AccountId}";
                //@Criteria varchar(200), 
                //@FromDate datetime = default,
                //@ToDate datetime = default , 
                //@comid varchar(20) = '',
                //@Reset int = 0,
                //@AccId varchar(40) = ''
                //fahad
                SqlParameter[] sqlParameter = new SqlParameter[6];
                sqlParameter[0] = new SqlParameter("@Criteria", "AccountsTransactionCheck");
                sqlParameter[1] = new SqlParameter("@FromDate", fromdate.ToString("dd-MMM-yy"));
                sqlParameter[2] = new SqlParameter("@ToDate", todate.ToString("dd-MMM-yy"));
                sqlParameter[3] = new SqlParameter("@comid", ComId);
                sqlParameter[4] = new SqlParameter("@Reset", "0");
                sqlParameter[5] = new SqlParameter("@AccId", AccountId.ToString());

                Helper.ExecProc("PrcProcess_Transaction_ConvertDebitCredit", sqlParameter);


                var account = _accountHeadRepository.All().Include(x => x.AccountCategorys).Where(x => x.Id.ToString() == AccountId).FirstOrDefault();

                if (account != null)
                {
                    if (TransactionId > 0)
                    {
                        //var transactionamount = _transactionRepository.All().Where(x => x.Id == TransactionId).FirstOrDefault().TransactionAmount;
                        // Adjust the above line according to your actual data model

                        var response = new
                        {
                            AccountBalance = account.AccountBalance,
                            AccountCategory = account.AccountCategorys.AccountCategoryName
                        };

                        return Json(response);
                    }
                    else
                    {
                        var response = new
                        {
                            AccountBalance = account.AccountBalance,
                            AccountCategory = account.AccountCategorys.AccountCategoryName
                        };

                        return Json(response);
                    }
                }
                else
                {
                    // Handle the case when the account is not found
                    return Json(new { Error = "Account not found" });
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }

        [ApiAuthorize]
        public JsonResult SearchProductSerialDropdown(string query)
        {
            var x = _purchaseBatchItemsRepository.All()
                .Include(x => x.Products).ThenInclude(x => x.Unit)
                .Include(x => x.Products).ThenInclude(x => x.Brand)
                .Include(x => x.Products).ThenInclude(x => x.Category)

                .Where(p => (p.BatchSerialNo.ToLower().Contains(query.ToLower())) && (p.IsUsed == false))
            .Select(p => new
            {
                p.Id,
                ProductId = p.ProductId,
                SerialNo = p.BatchSerialNo,
                CostPrice = p.PurchaseItems.Price,
                SalesPrice = p.Products.Price,
                PrdName = p.Products.Name,
                Barcode = p.Products.Code,

                CategoryName = p.Products.Category.Name,
                BrandName = p.Products.Brand != null ? p.Products.Brand.BrandName : "",
                ModelName = p.Products.ModelName,
                VariantName = p.Products.SizeName,
                SizeName = p.Products.SizeName,
                ColorName = p.Products.ColorName,


                UnitName = p.Products.Unit.UnitShortName,
                Unitid = p.Products.UnitId
            })
           //.Select(p => p.BatchSerialNo)
           //.Take(10)
           .ToList();

            return Json(x);
        }

        [ApiAuthorize]
        public JsonResult GetProductSerialDropdown(string query, int? ProductId)
        {
            ///active search for serial
            var x = _purchaseBatchItemsRepository.All()
                .Include(x => x.Products).ThenInclude(x => x.Unit)
                .Include(x => x.Products).ThenInclude(x => x.Category)
                .Include(x => x.Products).ThenInclude(x => x.Brand)


                .Where(p => (p.IsUsed == false) && (p.IsReturn == false) && (p.ProductId == ProductId)) // &&  (p.BatchSerialNo.ToLower().Contains(query.ToLower()))
            .Select(p => new
            {
                SerialId = p.Id,
                ProductId = p.ProductId,
                SerialNo = p.BatchSerialNo,
                CostPrice = p.PurchaseItems.Price,
                SalesPrice = p.Products.Price,
                PrdName = p.Products.Name,
                Barcode = p.Products.Code,

                CategoryName = p.Products.Category.Name,
                BrandName = p.Products.Brand != null ? p.Products.Brand.BrandName : "",
                ModelName = p.Products.ModelName,
                VariantName = p.Products.SizeName,
                SizeName = p.Products.SizeName,
                ColorName = p.Products.ColorName,

                UnitName = p.Products.Unit.UnitShortName,
                Unitid = p.Products.UnitId
            })
            //.Take(20)
            .ToList().OrderByDescending(x => x.SerialId);
            //.Select(p => p.BatchSerialNo)
            //.Take(10);




            //var xx = _salesBatchItemRepository.All().Include(x => x.Products).Where(p => p.SalesItems.SalesId == saleid && p.ProductId == ProductId)
            //.Select(p => new { SerialId = p.Id, ProductId = p.ProductId, SerialNo = p.BatchSerialNo, CostPrice = p.PurchaseBatchItems.PurchaseItems.Price, SalesPrice = p.Products.Price }).ToList();

            //foreach (var item in xx)
            //{
            //    x.Add(item);
            //}

            return Json(x);
        }


        [ApiAuthorize]
        public JsonResult GetProductSerialDropdownWithSaleId(int? ProductId, int? saleid)//string query, 
        {

            var x = _purchaseBatchItemsRepository.All()
                .Include(x => x.Products).ThenInclude(x => x.Unit)

                .Include(x => x.Products).ThenInclude(x => x.Brand)
                .Include(x => x.Products).ThenInclude(x => x.Category)


                .Where(p => (p.IsUsed == false) && (p.IsReturn == false) && p.ProductId == ProductId) ////(p.BatchSerialNo.ToLower().Contains(query.ToLower())) &&
            .Select(p => new
            {
                Id = 0,
                SerialId = p.Id,
                ProductId = p.ProductId,
                SerialNo = p.BatchSerialNo,

                CategoryName = p.Products.Category.Name,
                BrandName = p.Products.Brand != null ? p.Products.Brand.BrandName : "",
                ModelName = p.Products.ModelName,
                VariantName = p.Products.SizeName,
                SizeName = p.Products.SizeName,
                ColorName = p.Products.ColorName,

                CostPrice = p.PurchaseItems.Price,
                SalesPrice = p.Products.Price,
                UnitName = p.Products.Unit.UnitShortName,
                Unitid = p.Products.UnitId
            }).Take(20).ToList();
            //.Select(p => p.BatchSerialNo)
            //.Take(10);


            var xx = _salesBatchItemRepository.All()
                .Include(x => x.Products).ThenInclude(x => x.Unit)

                .Include(x => x.Products).ThenInclude(x => x.Brand)
                .Include(x => x.Products).ThenInclude(x => x.Category)

                .Where(p => p.SalesItems.SalesId == saleid && p.ProductId == ProductId)
            .Select(p => new
            {
                Id = p.Id,
                SerialId = p.PurchaseBatchItems.Id,
                ProductId = p.ProductId,
                SerialNo = p.BatchSerialNo,

                CategoryName = p.Products.Category.Name,
                BrandName = p.Products.Brand != null ? p.Products.Brand.BrandName : "",
                ModelName = p.Products.ModelName,
                VariantName = p.Products.SizeName,
                SizeName = p.Products.SizeName,
                ColorName = p.Products.ColorName,

                CostPrice = p.PurchaseBatchItems.PurchaseItems.Price,
                SalesPrice = p.Products.Price,
                UnitName = p.Products.Unit.UnitShortName,
                Unitid = p.Products.UnitId
            })
            .ToList();

            foreach (var item in xx)
            {
                x.Add(item);
            }

            return Json(x);
        }

        //[ApiAuthorize]
        //public JsonResult SearchProductDropdown(string query)
        //{
        //    var x = _productRepository.All().Include(x => x.Unit).Where(x => x.Name.ToLower().Contains(query.ToLower()) || x.Code.ToLower().Contains(query)).Take(10).ToList()
        //        .Select(p => new { ProductId = p.Id, PrdName = p.Name, Barcode = p.Code, SalesPrice = p.Price, CostPrice = p.CostPrice, UnitName = p.Unit.UnitShortName, Unitid = p.UnitId }
        //        );

        //    return Json(x);

        //}

        [ApiAuthorize]
        public JsonResult SearchProductDropdown(string query)
        {
            try
            {

                var warehouselist = FromWarehousePermissionRepository.GetAllForDropDown();
                if (warehouselist.Count() == 0)
                {
                    warehouselist = _warehouseRepository.GetWarehouseLedgerHeadForDropDown();
                }

                List<int?> permitwarehouselist = new List<int?>();

                foreach (var item in warehouselist)
                {
                    permitwarehouselist.Add(int.Parse(item.Value.ToString()));
                }




                var products = _productRepository.All().Include(x => x.Category).Include(x => x.CostCalculated).Include(x => x.Unit)
                    .Where(x => x.Name.ToLower().Contains(query.ToLower()) || x.Code.ToLower().Contains(query)).Take(10);//.Include(x=>x.vUnit).Include(x=>x.Category);


                var querylist = (from p in products

                                 let costcallist = p.CostCalculated.Where(x => permitwarehouselist.Contains(x.WarehouseId))
                                 //let costcallist = p.CostCalculated
                                 .GroupBy(st => new { st.WarehouseId, st.ProductId })
                                 .Select(grouping => grouping.Max(row => row.Id))
                                 .ToArray()

                                 let WarehouseQty =
                                 //p.CostCalculated != null ?
                                 p.CostCalculated.OrderByDescending(x => x.Id)
                                 .Select(x => new WarehouseResult
                                 {
                                     CostCalculatedId = x.Id,
                                     //WarehouseId = x.WarehouseId, 
                                     WhShortName = x.Warehouse.WhShortName,
                                     CurrentStock = x.CurrQty + x.PrevQty,
                                     AverageCosting = x.CalculatedPrice,
                                     CostingValue = (x.CalculatedPrice) * (x.CurrQty + x.PrevQty),
                                     SalesValue = (double)p.Price * (x.CurrQty + x.PrevQty)
                                 })
                                 .Where(x => costcallist.Contains(x.CostCalculatedId))
                                 //.Where(x => x.CostCalculatedId == 86)
                                 .ToList()
                                 ?? null


                                 let CurrentStockCalc =
                                 //p.CostCalculated != null ?
                                 p.CostCalculated.OrderByDescending(x => x.Id)
                                 .Select(x => new
                                 {
                                     CostCalculatedId = x.Id,
                                     CurrentStock = x.CurrQty + x.PrevQty,

                                 })
                                 .Where(x => costcallist.Contains(x.CostCalculatedId))
                                 .Sum(x => x.CurrentStock)

                                 select new
                                 {

                                     ProductId = p.Id,
                                     PrdName = p.Name,
                                     Barcode = p.Code,
                                     SalesPrice = p.Price,
                                     CostPrice = p.CostPrice,
                                     UnitName = p.Unit.UnitShortName,
                                     Unitid = p.UnitId,
                                     //WarehouseList = WarehouseQty,
                                     //CurrentStock = CurrentStockCalc,

                                     SizeName = p.SizeName ?? "",
                                     BrandName = p.Brand != null ? p.Brand.BrandName : "",
                                     ColorName = p.ColorName ?? "",
                                     Category = p.Category.Name,
                                     Description = p.Description ?? "",
                                     WholeSalePrice = p.WholeSalePrice > 0 ? p.WholeSalePrice : p.Price,
                                     PCTN = p.PCTN,
                                     CommissionAmount = p.CommissionAmount,
                                     CommissionPer = p.CommissionPer,
                                     //CostPrice = p.CostCalculated.Where(x => x.WarehouseId == WarehouseId) != null ? p.CostPrice : p.CostCalculated.Where(x => x.WarehouseId == WarehouseId).OrderByDescending(x => x.Id).FirstOrDefault().CalculatedPrice,

                                     WarehouseList = WarehouseQty,
                                     CurrentStock = CurrentStockCalc,
                                     ImagePath = p.ImagePath

                                 });




                //var parser = new Parser<ProductResult>(Request.Form, query);
                //return Json(parser.Parse());


                //List<ProductResult> abcd = querylist.OrderByDescending(x => x.PrdName).ToList();

                //return abcd;

                return Json(querylist);
            }
            catch (Exception ex)
            {
                return Json(ex);
                throw ex;

            }
        }



        [ApiAuthorize]
        public JsonResult SearchBarcodeDropdown(string query)
        {

            var x = _productRepository.All().Include(x => x.Unit)
                    .Include(x => x.Category)
                    .Include(x => x.Brand)


                .Where(x => x.Code.ToLower().Contains(query.ToLower())).Take(10).ToList()
                .Select(p => new
                {
                    ProductId = p.Id,
                    PrdName = p.Name,
                    Barcode = p.Code,
                    SalesPrice = p.Price,
                    CostPrice = p.CostPrice,


                    CategoryName = p.Category.Name,
                    BrandName = p.Brand != null ? p.Brand.BrandName : "",
                    ModelName = p.ModelName,
                    VariantName = p.SizeName,
                    SizeName = p.SizeName,
                    ColorName = p.ColorName,


                    UnitName = p.Unit.UnitShortName,
                    Unitid = p.UnitId
                }
              );

            return Json(x);

        }


        [ApiAuthorize]
        public JsonResult CustomerSearchByPhoneNo(string query)
        {
            return Json(_saleRepository.All().Where(x => (x.PhoneNo.ToLower().Contains(query.ToLower()) || (x.CustomerName.ToLower().Contains(query.ToLower()))))
                  .GroupBy(x => new { x.PhoneNo, x.CustomerName, x.PrimaryAddress })
                  .Select(g => new { PhoneNo = g.Key.PhoneNo == null ? "" : g.Key.PhoneNo, CustomerName = g.Key.CustomerName == null ? "" : g.Key.CustomerName, PrimaryAddress = g.Key.PrimaryAddress == null ? "" : g.Key.PrimaryAddress }).ToList()
                  .Take(10));
        }

        [ApiAuthorize]
        public JsonResult CustomerSearchByName(string query)
        {
            return Json(_customerRepository.All().Where(x => (x.Name.ToLower().Contains(query.ToLower()) || (x.PrimaryAddress.ToLower().Contains(query.ToLower())) || (x.Phone.ToLower().Contains(query.ToLower()))))
                  //.GroupBy(x => new { x.Name, x.Phone, x.PrimaryAddress })
                  .Select(g => new { g.Id, PhoneNo = g.Phone == null ? "" : g.Phone, CustomerName = g.Name == null ? "" : g.Name, PrimaryAddress = g.PrimaryAddress == null ? "" : g.PrimaryAddress }).ToList()
                  .Take(10));
        }

        //[HttpGet]
        //public ActionResult AddCategory()
        //{
        //    ViewBag.ActionType = "Create";
        //    return View();
        //}

        [HttpPost]
        [ApiAuthorize]
        public ActionResult CreateSales([FromBody] SalesModel model)
        {
            Atrai.Model.AppData.DefaultConnectionString = Config.GetConnectionString("DefaultConnection");
            var errors = ModelState.Where(x => x.Value.Errors.Any())
            .Select(x => new { x.Key, x.Value.Errors });

            var ComId = (HttpContext.Session.GetInt32("ComId"));
            var LuserId = (HttpContext.Session.GetInt32("UserId"));
            var doctypeid = _docTypeRepository.All().Where(x => x.DocType == "Sales").FirstOrDefault().Id;


            if (ModelState.IsValid)
            {
                try
                {
                    //if (ModelState.IsValid)
                    //{
                    if (model.Id > 0)
                    {

                        model.CreateDate = DateTime.Now.Date;
                        model.SalesDate = model.SalesDate.Date;

                        //_saleRepository.UpdateApi(model, model.Id);


                        SqlParameter[] sqlParameter = new SqlParameter[4];
                        sqlParameter[0] = new SqlParameter("@ComId", ComId);
                        sqlParameter[1] = new SqlParameter("@Id", model.Id);
                        sqlParameter[2] = new SqlParameter("@ProcessFor", "Sales");
                        sqlParameter[3] = new SqlParameter("@SaveUpdateDelete", "Update");
                        Helper.ExecProc("prcSerialProcess", sqlParameter);


                        var salesitems = saleItemRepository.All().Where(x => x.SalesId == model.Id).ToList();
                        saleItemRepository.RemoveRange(salesitems);


                        var saleinfo = _saleRepository.Find(model.Id);

                        if (model.DocTypeId == null)
                        {
                            model.DocTypeId = saleinfo.DocTypeId;
                        }

                        _saleRepository.Update(model, model.Id);



                        foreach (SalesItemsModel item in model.Items)
                        {
                            ///item.Amount = item.Quantity * item.Price;////fahad

                            if (item.Id > 0)
                            {
                                if (item.IsDelete == true)
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
                                if (item.IsDelete == true)
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



                        var salespaymentsdata = _salesPaymentRepository.All().Where(x => x.SalesId == model.Id).ToList();
                        _salesPaymentRepository.RemoveRange(salespaymentsdata);


                        foreach (SalesPaymentModel item in model.SalesPayments.Where(x => x.IsDelete == false))
                        {
                            item.Id = 0;
                            _salesPaymentRepository.Insert(item);


                            //if (item.Id > 0)
                            //{
                            //    if (item.IsDelete == true)
                            //    {
                            //        int z = item.Id;
                            //        _salesPaymentRepository.Delete(item);

                            //    }
                            //    else
                            //    {
                            //        _salesPaymentRepository.Update(item, item.Id);

                            //    }
                            //}
                            //else
                            //{
                            //    if (item.IsDelete == true)
                            //    {
                            //    }
                            //    else
                            //    {

                            //        _salesPaymentRepository.Insert(item);

                            //    }
                            //}
                        }


                        ////for update the serial item column data
                        //foreach (var item in model.Items)
                        //{
                        //    var multiserial = "";
                        //    foreach (var itemserial in item.BatchSerialItems)
                        //    {
                        //        multiserial += itemserial.PurchaseBatchId.ToString() + ",";
                        //    }

                        //    if (item.BatchSerialItems != null)
                        //    {
                        //        item.SerialItem = multiserial.TrimEnd(',');
                        //        saleItemRepository.Update(item, item.Id);
                        //    }
                        //}



                        //////update for serial no combine with comman
                        var salesdata = _saleRepository.All()
                       .Include(x => x.Items).ThenInclude(x => x.BatchSerialItems)
                       .Where(x => x.Id == model.Id && x.isPosted == false).FirstOrDefault();

                        foreach (var itemabc in salesdata.Items)
                        {
                            var multiserial = "";
                            foreach (var itemserial in itemabc.BatchSerialItems)
                            {
                                multiserial += itemserial.PurchaseBatchId + ",";
                            }

                            if (itemabc.BatchSerialItems.Count != 0)
                            {
                                itemabc.SerialItem = multiserial.TrimEnd(',');
                                saleItemRepository.Update(itemabc, itemabc.Id);
                            }
                        }


                        NotificationModel abcd = new NotificationModel();
                        abcd.TextMessage = model.SaleCode + " - " + "Invoice Modified by User.";
                        abcd.Value = model.Id;
                        abcd.Type = "Sales";



                        _notificationRepository.Insert(abcd);



                        TempData["Message"] = "Data Update Successfully";
                        TempData["Status"] = "2";
                        tranlog.TransactionLog(RouteData.Values["controller"].ToString(), RouteData.Values["action"].ToString(), TempData["Message"].ToString(), model.Id.ToString(), "Update", model.SaleCode);



                        SqlParameter[] sqlParameter1 = new SqlParameter[4];
                        sqlParameter1[0] = new SqlParameter("@ComId", ComId);
                        sqlParameter1[1] = new SqlParameter("@Id", model.Id);
                        sqlParameter1[2] = new SqlParameter("@ProcessFor", "Sales");
                        sqlParameter1[3] = new SqlParameter("@SaveUpdateDelete", "Save");
                        Helper.ExecProc("prcSerialProcess", sqlParameter1);

                        return Json(new { Success = 1, error = false, message = "Data Update successfully", Id = model.Id });



                    }
                    else
                    {
                        if (model.DocTypeId == null)
                        {
                            model.DocTypeId = doctypeid;

                        }

                        model.CreateDate = DateTime.Now.Date;
                        model.SalesDate = model.SalesDate.Date;


                        _saleRepository.Insert(model);
                        //fahad amount is not calcualted need to talk with iftekhar


                        //foreach (var item in model.Items)
                        //{
                        //    var multiserial = "";
                        //    foreach (var itemserial in item.BatchSerialItems)
                        //    {
                        //        multiserial += itemserial.PurchaseBatchId.ToString() + ",";
                        //    }

                        //    if (item.BatchSerialItems != null)
                        //    {
                        //        item.SerialItem = multiserial.TrimEnd(',');
                        //        saleItemRepository.Update(item, item.Id);
                        //    }
                        //}


                        //////update for serial no combine with comman
                        var salesdata = _saleRepository.All()
                       .Include(x => x.Items).ThenInclude(x => x.BatchSerialItems)
                       .Where(x => x.Id == model.Id && x.isPosted == false).FirstOrDefault();

                        foreach (var itemabc in salesdata.Items)
                        {
                            var multiserial = "";
                            foreach (var itemserial in itemabc.BatchSerialItems)
                            {
                                multiserial += itemserial.PurchaseBatchId + ",";
                            }

                            if (itemabc.BatchSerialItems.Count != 0)
                            {
                                itemabc.SerialItem = multiserial.TrimEnd(',');
                                saleItemRepository.Update(itemabc, itemabc.Id);
                            }
                        }


                        NotificationModel abcd = new NotificationModel();
                        abcd.TextMessage = model.SaleCode + " - " + "New Invoice Created.";
                        abcd.Value = model.Id;
                        abcd.Type = "Sales";
                        _notificationRepository.Insert(abcd);


                        if ((model.OrderId != null) || (model.OrderId.HasValue == true))
                        {
                            var onlineorder = _ordresRepository.All().Where(x => x.Id == model.OrderId).FirstOrDefault();
                            onlineorder.isPosted = true;

                            _ordresRepository.Update(onlineorder, onlineorder.Id);

                        }



                        SqlParameter[] sqlParameter1 = new SqlParameter[4];
                        sqlParameter1[0] = new SqlParameter("@ComId", ComId);
                        sqlParameter1[1] = new SqlParameter("@Id", model.Id);
                        sqlParameter1[2] = new SqlParameter("@ProcessFor", "Sales");
                        sqlParameter1[3] = new SqlParameter("@SaveUpdateDelete", "Save");
                        Helper.ExecProc("prcSerialProcess", sqlParameter1);
                    }




                    return Json(new { Success = 1, error = false, message = "Data Save successfully", Id = model.Id });
                    //return Ok(true);
                    //}
                    //return Ok(false);
                }
                catch (Exception x)
                {
                    //Console.WriteLine(x.Message );
                    //return Ok(x.Message);

                    return Json(new { Success = 0, error = true, message = x.Message + " ; " + x.InnerException, Id = model.Id });

                }
            }
            else
            {
                return Ok(false);
            }

        }

        [HttpGet]
        [ApiAuthorize]
        public JsonResult GetSingleSale(int SaleId)
        {
            var salesdata = _saleRepository.All()
            .Include(x => x.Items).ThenInclude(x => x.BatchSerialItems)
            .Include(x => x.Items).ThenInclude(x => x.Product).ThenInclude(x => x.Unit)
            .Include(x => x.SalesPayments)
            .Include(x => x.AccountTransaction)
            .Where(x => x.Id == SaleId && x.isPosted == false)
            .Select(p => new
            {
                Id = p.Id,
                SaleCode = p.SaleCode,
                //CustomerModel = p.CustomerModel,
                OrderId = p.OrderId,


                //CustomerName = p.CustomerName,
                CustomerName = (p.CustomerName.Length == 0 || p.CustomerName == null) ? p.CustomerModel.Name : p.CustomerModel.Name + " - " + p.CustomerName,
                PhoneNo = p.PhoneNo,
                PrimaryAddress = p.PrimaryAddress,
                SecoundaryAddress = p.SecoundaryAddress,
                SalesPayments = p.SalesPayments.Where(a => a.IsDelete == false)
                                .Select(a => new
                                {
                                    SalesId = a.SalesId,
                                    PaymentCardNo = a.PaymentCardNo,
                                    Amount = a.Amount,
                                    AccountHeadId = a.AccountHeadId,
                                    Id = a.Id,
                                    CreateDate = a.CreateDate
                                }),

                Discount = p.Discount,
                DisPer = p.DisPer,
                DisAmt = p.DisAmt,
                isDisPer = p.isDisPer,


                GrandTotal = p.GrandTotal,
                p.ChangeAmount,
                p.PaidAmount,

                CustomerId = p.CustomerId,
                //DueAmt = p.DueAmt,
                DueAmt = p.NetAmount - p.SalesPayments.Sum(x => x.Amount),
                Notes = p.Notes,
                SalesDate = p.SalesDate,
                SalesDateString = p.SalesDate.ToString("dd-MMM-yy"),


                CreateDate = p.CreateDate,
                Total = p.Total,

                NetAmount = p.NetAmount,
                PaidAmt = p.PaidAmt,
                ServiceCharge = p.ServiceCharge,
                Shipping = p.Shipping,

                TotalVat = p.TotalVat,

                isPosted = p.isPosted,
                isSerialSales = p.isSerialSales,

                isWholeSales = p.isWholeSales,
                WarehouseIdMain = p.WarehouseIdMain,


                Profit = p.Profit,
                ProfitPercentage = p.ProfitPercentage,
                FinalCostingPrice = p.FinalCostingPrice,
                TotalCommisionAmount = p.TotalCommisionAmount,
                DocTypeId = p.DocTypeId,
                SalesRepId = p.SalesRepId,


                Items = p.Items.Where(x => x.IsDelete == false).Select(x =>
                   new
                   {
                       Id = x.Id,
                       SalesId = x.SalesId,
                       Name = x.Product.Name,
                       Barcode = x.Product.Code,

                       CategoryName = x.Product.Category.Name,
                       BrandName = x.Product.Brand != null ? x.Product.Brand.BrandName : "",
                       ModelName = x.Product.ModelName,
                       VariantName = x.Product.SizeName,
                       SizeName = x.Product.SizeName,
                       ColorName = x.Product.ColorName,


                       Description = x.Description,
                       WarehouseId = x.WarehouseId,
                       SerialItem = x.SerialItem,

                       CommissionAmount = x.CommissionAmount,
                       CommissionPer = x.CommissionPer,
                       UserCommissionAmount = x.UserCommissionAmount,

                       CartonQty = x.CartonQty,
                       PCTN = x.PCTN,
                       IndDiscount = x.IndDiscount,

                       UnitName = x.Product.Unit.UnitShortName,
                       isDisPerRow = x.isDisPerRow,




                       ProductId = x.ProductId,
                       Quantity = x.Quantity,
                       CostPrice = x.CostPrice,
                       Price = x.Price,
                       Amount = x.Amount,
                       BatchSerialItems = x.BatchSerialItems
                       .Where(y => y.IsDelete == false).Select(y =>
                       new
                       {
                           Id = y.Id,
                           SalesItemId = y.SalesItemId,
                           PurchaseBatchId = y.PurchaseBatchId,
                           ProductId = y.ProductId,
                           BatchSerialNo = y.BatchSerialNo,
                           SalesBatchQuantity = y.SalesBatchQuantity,
                           SalesBatchAmount = y.SalesBatchAmount,
                           SalesBatchPrice = y.SalesBatchPrice

                       }).ToList(),
                   }).ToList()



            }).FirstOrDefault();
            //x.UserAccountList = null;

            return Json(salesdata);
        }
        [ApiAuthorize]
        public ActionResult DeleteSale(int SaleId)
        {
            try
            {
                var response = _saleRepository.Find(SaleId);

                if (response != null) _saleRepository.Delete(response);
                else if (response == null) return BadRequest(new { message = "Sales Can not be Deleted" });



                if ((response.OrderId != null) || (response.OrderId.HasValue == true))
                {
                    var onlineorder = _ordresRepository.All().Where(x => x.Id == response.OrderId).FirstOrDefault();
                    onlineorder.isPosted = false;

                    _ordresRepository.Update(onlineorder, onlineorder.Id);

                }



                var ComId = HttpContext.Session.GetInt32("ComId");

                SqlParameter[] sqlParameter = new SqlParameter[4];
                sqlParameter[0] = new SqlParameter("@ComId", ComId);
                sqlParameter[1] = new SqlParameter("@Id", SaleId);
                sqlParameter[2] = new SqlParameter("@ProcessFor", "Sales");
                sqlParameter[3] = new SqlParameter("@SaveUpdateDelete", "Update");
                Helper.ExecProc("prcSerialProcess", sqlParameter);

                //Ok(false);

                return Ok(true);

            }
            catch (Exception x)
            {
                Console.WriteLine(x.Message);
                return BadRequest(new { message = "Something Wrong" });
            }
        }


        [ApiAuthorize]
        public JsonResult GetSaleSummaryInfo(string FromDate, string ToDate, int? CustomerId, int? UserId, int? WarehouseId)
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

                var daywisesalescount = _saleRepository.All()
                 .Where(x => x.SalesDate >= DateTime.Now.Date.AddDays(-6) && x.SalesDate <= DateTime.Now.Date)
                 .GroupBy(x => new { x.ComId, x.SalesDate })
                 .Select(g => new { SalesDate = g.Key.SalesDate.ToString("dd-MMM-yy"), TotalSalesCount = g.Count(), TotalSalesSum = g.Sum(x => x.NetAmount) }).ToList().OrderByDescending(a => a.SalesDate);


                var saleslist = _saleRepository.All().Where(x => x.SalesDate >= dtFrom && x.SalesDate <= dtTo);
                var salespaymentlist = _salesPaymentRepository.All().Include(x => x.SalesMain).ThenInclude(x => x.CustomerModel).Where(x => x.SalesMain.SalesDate >= dtFrom && x.SalesMain.SalesDate <= dtTo && x.SalesMain.IsDelete == false);
                var salesitemlist = saleItemRepository.All().Where(x => x.SalesModel.SalesDate >= dtFrom && x.SalesModel.SalesDate <= dtTo && x.SalesModel.IsDelete == false);

                if (CustomerId != null)
                {
                    saleslist = saleslist.Where(p => p.CustomerId == CustomerId);
                    salespaymentlist = salespaymentlist.Where(p => p.SalesMain.CustomerId == CustomerId);
                    salesitemlist = salesitemlist.Where(p => p.SalesModel.CustomerId == CustomerId);

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
                    var arrayabc = FromWarehousePermissionRepository.All().Where(x => x.LuserIdAllow == sessionLuserId).Select(x => x.WarehouseId).ToList();
                    //int a = 1;
                    //List<int> IDs = new List<int> { 1, 3, 4, 8 };

                    //var warehouselist = FromWarehousePermissionRepository.All().Select(x => x.Id);
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
                .Select(g => new { TotalSalesCount = g.Count(), TotalSalesValue = g.Sum(x => x.NetAmount), TotalCosting = g.Sum(x => x.FinalCostingPrice), TotalProfit = g.Sum(x => x.Profit) });



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
                 .Select(g => new { ProductName = g.Key.Name, ProductCount = g.Count() }).ToList().OrderByDescending(x => x.ProductCount).Take(5);

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
                .Select(g => new { CategoryName = g.Key.CategoryName, CategoryCount = g.Count(), TotalProfit = g.Sum(x => x.Price * x.Quantity) - g.Sum(x => x.IndDiscount * x.Quantity) - g.Sum(x => x.CostPrice * x.Quantity), TotalSales = g.Sum(x => x.Price * x.Quantity) - g.Sum(x => x.IndDiscount * x.Quantity) }) ///g.Sum(x=>x.SalesModel.DisAmt
                .OrderByDescending(x => x.TotalSales).Take(10);



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


        [HttpGet]
        [ApiAuthorize]
        public JsonResult GetSingleOnlineOrder(int SaleId)
        {
            var salesdata = _ordresRepository.All()
            .Include(x => x.Items).ThenInclude(x => x.Product).ThenInclude(x => x.Unit)
            .Where(x => x.Id == SaleId && x.isPosted == false)
            .Select(p => new
            {
                Id = 0,
                SaleCode = p.OrderCode,
                OrderId = p.Id,

                //CustomerModel = p.CustomerModel,
                CustomerName = p.CustomerName,
                PhoneNo = p.PhoneNo,
                PrimaryAddress = p.PrimaryAddress,
                SecoundaryAddress = p.SecoundaryAddress,
                SalesPayments = p.OrdersPayments.Where(a => a.IsDelete == false)
                                .Select(a => new
                                {
                                    SalesId = a.OrdersId,
                                    PaymentCardNo = a.PaymentCardNo,
                                    Amount = a.Amount,
                                    //AccountHeadId = null,
                                    Id = a.Id,
                                    CreateDate = a.CreateDate
                                }),

                Discount = p.DisAmt,
                DisPer = p.DisPer,
                DisAmt = p.DisAmt,
                //isDisPer = p.isDisPer,


                GrandTotal = p.GrandTotal,

                CustomerId = p.CustomerId,
                DueAmt = 0.00,
                Notes = p.Notes,
                SalesDate = p.OrdersDate,

                CreateDate = p.CreateDate,
                Total = p.GrandTotal,

                NetAmount = p.NetAmount,
                PaidAmt = 0.00,
                ServiceCharge = p.ServiceCharge,
                Shipping = p.Shipping,

                TotalVat = p.TotalVat,

                isPosted = p.isPosted,
                isSerialSales = 1,





                Items = p.Items.Where(x => x.IsDelete == false).Select(x =>
                   new
                   {
                       Id = x.Id,
                       SalesId = x.OrdersId,
                       Name = x.Product.Name,
                       Barcode = x.Product.Code,
                       Description = "",

                       IndDiscount = 0.00,

                       UnitName = x.Product.Unit.UnitShortName,

                       ProductId = x.ProductId,
                       Quantity = x.Quantity,
                       CostPrice = x.Product.CostPrice,
                       Price = x.Price,
                   }).ToList()



            }).FirstOrDefault();
            //x.UserAccountList = null;

            return Json(salesdata);
        }


        [HttpGet]
        [ApiAuthorize]
        public ActionResult DeleteOnlineOrder(int SaleId)
        {
            try
            {
                var response = _ordresRepository.Find(SaleId);

                if (response != null) _ordresRepository.Delete(response);
                else if (response == null) return BadRequest(new { message = "Orders Can not be Deleted" });


                //Ok(false);

                return Ok(true);

            }
            catch (Exception x)
            {
                Console.WriteLine(x.Message);
                return BadRequest(new { message = "Something Wrong" });
            }
        }



        #endregion

        #region PurchaseEntry


        [ApiAuthorize]
        public ActionResult PurchaseReport(int PurchaseId, string format = "PDF", int isfile = 0)
        {
            //string resulta = "";
            //var weburl = Request.Scheme + "://" + Request.Host.Value + "/" + Request.QueryString.Value;
            ////var weburl = Request.GetTypedHeaders().Referer.ToString().ToLower();//.Replace("/Home/Login".ToLower(), "");

            //var origin = weburl.ToLower();
            //var weburlquerystring = Request.QueryString.HasValue == true ? Request.QueryString.ToString() : "";// Request.QueryString == null ? "": Request.QueryString;// Request.QueryString?? Request.QueryString;//.Replace("/Home/Login".ToLower(), "");

            //if (weburlquerystring.Length > 2)
            //{
            //    resulta = origin.Replace(weburlquerystring.ToLower(), "").Replace("/Home/Login".ToLower(), "");

            //}
            //else
            //{
            //    resulta = origin.Replace("/Home/Login".ToLower(), "");

            //}
            //HttpContext.Session.SetString("weburl", resulta.ToString());
            HttpContext.Session.SetString("PurchaseReportType", format);


            //string weburl = Config.GetSection("hostimage").Value;
            //string weburl = Config.GetSection("host").Value;

            Atrai.Model.AppData.DefaultConnectionString = Config.GetConnectionString("DefaultConnection");

            //var UserId = HttpContext.Session.GetInt32("UserId");
            //var ComId = HttpContext.Session.GetInt32("ComId");
            //weburl = HttpContext.Session.GetString("weburl"); //"https://www.pqstec.com/InvoiceApps";//  HttpContext.Session.GetString("weburl"); 
            //var ReportStyle = _storeSettingRepository.All().Include(x => x.ReportStyle).Select(x => x.ReportStyle.ReportStyleName).FirstOrDefault(); //HttpContext.Session.GetString("PurchaseReportStyle");

            var UserId = HttpContext.Session.GetInt32("UserId");
            var ComId = HttpContext.Session.GetInt32("ComId");
            //var weburl = HttpContext.Session.GetString("weburl");

            string weburl = Config.GetSection("hostimage").Value;

            //string weburl = HttpContext.Session.GetString("weburl"); //"https://www.pqstec.com/InvoiceApps";//  HttpContext.Session.GetString("weburl"); 
            var ReportStyle = _storeSettingRepository.All().Include(x => x.PurchaseReportStyle).Select(x => x.PurchaseReportStyle.ReportStyleName).FirstOrDefault(); //HttpContext.Session.GetString("PurchaseReportStyle");


            string reportname = "rptPurchaseOrder";
            var filename = "Purchase_";
            //string apppath = "";





            if (ReportStyle.ToString().Length > 0)
            {
                reportname = "rptPurchaseOrder_" + ReportStyle.ToString();
            }


            HttpContext.Session.SetString("ReportQuery", "Exec  [rptPurchase] '" + PurchaseId + "','" + ComId + "', '" + weburl + "' , 'Purchase'");
            HttpContext.Session.SetString("ReportPath", "~/ReportViewer/POS/" + reportname + ".rdlc");
            HttpContext.Session.SetString("PrintFileName", filename.Replace(".", "").Replace(" ", "").Replace(",", "").Replace("\"", ""));


            //postData.Add(1, new subReport("rptPurchaseOrder_Terms", "", "DataSet1", "Exec " + Atrai.Model.AppData.dbGTCommercial.ToString() + ".dbo.rptPurchaseOrder_Terms '" + id + "','" + Session["comid"].ToString() + "',''"));

            //postData.Add(1, new subReport("rptPurchaseOrder_BankDetails", "", "DataSet1", "Exec rptPurchaseOrder_BankDetails '" + PurchaseId + "'," + ComId + ",'" + Atrai.Model.AppData.AppPath.ToString() + "'"));
            postData.Add(2, new subReport("rptPurchaseOrder_PM", "", "DataSet1", "Exec rptPurchaseOrder_PM '" + PurchaseId + "'," + ComId + ""));


            //clsReport.rptList.Add(new subReport("rptPurchaseOrder_Terms", "", "DataSet1", "Exec " + Atrai.Model.AppData.dbGTCommercial.ToString() + ".dbo.rptPurchaseOrder_Terms '" + id + "'," + Session["comid"].ToString() + ",'" + Atrai.Model.AppData.AppPath.ToString() + "'"));

            HttpContext.Session.SetObject("rptList", postData);
            //return RedirectToAction("Index", "ReportViewer");
            return RedirectToAction("Index", "ReportViewer", new { reporttype = format, isfile = isfile });


        }




        [ApiAuthorize]
        public JsonResult GetPurchaseList(string FromDate, string ToDate, int? SupplierId, int? UserId, string Status, int? WarehouseId, int? CategoryId, int pageNo = 1, decimal pageSize = 10, string searchquery = "")
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
            //var x = Request.Form.TryGetValue("search[value]", out y);

            var Purchaselist = _purchaseRepository.All();




            //if (y.ToString().Length > 0)
            //{


            //}
            if (searchquery?.Length > 1)
            {
                Purchaselist = Purchaselist.Where(x => x.PurchaseCode.ToLower().Contains(searchquery.ToLower()));
            }
            else
            {
                Purchaselist = Purchaselist.Where(p => (p.PurchaseDate >= dtFrom && p.PurchaseDate <= dtTo));

                if (SupplierId != null)
                {
                    Purchaselist = Purchaselist.Where(p => p.SupplierId == SupplierId);
                }
                if (CategoryId != null)
                {
                    Purchaselist = Purchaselist.Where(x => x.Items.Any(x => x.Product.CategoryId == CategoryId));
                }
                if (UserId != null)
                {
                    Purchaselist = Purchaselist.Where(p => p.LuserId == UserId);
                }
                if (WarehouseId != null)
                {
                    Purchaselist = Purchaselist.Where(p => p.WarehouseIdMain == WarehouseId);
                }
                else
                {
                    var arrayabc = FromWarehousePermissionRepository.All().Where(x => x.LuserIdAllow == sessionLuserId).Select(x => x.WarehouseId).ToList();
                    //int a = 1;
                    //List<int> IDs = new List<int> { 1, 3, 4, 8 };

                    //var warehouselist = FromWarehousePermissionRepository.All().Select(x=>x.Id);
                    if (arrayabc.Count() > 0)
                    {
                        Purchaselist = Purchaselist.Where(p => arrayabc.Contains(p.WarehouseIdMain));
                    }
                }


                if (Status == "Due")
                {
                    //var Purchaselistmore = Purchaselist.Where(x => x.GrandTotal -  x.PurchasePayments.Sum(x=>x.Amount) > 0);

                    Purchaselist = Purchaselist.Where(x => x.GrandTotal - x.PurchasePayments.Sum(x => x.Amount) > 0);

                    //Purchaselist = Purchaselist.Where(x=>x.PurchasePayments.Count == 0);


                }
                //else
                //{
                //    //Purchaselist = Purchaselist.Where(p => p.PurchaseDate >= dtFrom && p.PurchaseDate <= dtTo);

                //    //if (SupplierId == 1)
                //    //{
                //    //    Purchaselist = Purchaselist.Where(p => p.PurchaseDate >= dtFrom && p.PurchaseDate <= dtTo);
                //    //}
                //    //else
                //    //{
                //    //}
                //}

            }




            //////// pagination with lenght

            decimal TotalRecordCount = Purchaselist.Count();
            var PageCountabc = decimal.Parse((TotalRecordCount / pageSize).ToString());
            var PageCount = Math.Ceiling(PageCountabc);





            decimal skip = (pageNo - 1) * pageSize;

            // Get total number of records
            int total = Purchaselist.Count();
            ///




            var query = from e in Purchaselist.Include(x => x.Items).Include(x => x.PurchasePayments).ThenInclude(x => x.vChartofAccounts).Include(x => x.DocTypeList)
                        select new
                        {
                            Id = e.Id,
                            PurchaseCode = e.PurchaseCode,
                            PurchaseDate = e.PurchaseDate,
                            PurchaseDateString = e.PurchaseDate.ToString("dd-MMM-yy"),

                            PurchaseUser = e.UserAccountList.Name,

                            SupplierName = (e.SupplierName.Length == 0 || e.SupplierName == null) ? e.SupplierModel.SupplierName : e.SupplierModel.SupplierName + " - " + e.SupplierName,
                            //SupplierName = e.SupplierName,
                            PrimaryAddress = e.PrimaryAddress,
                            SecoundaryAddress = e.SecoundaryAddress,
                            Notes = e.Notes,
                            PhoneNo = e.PhoneNo,
                            Discount = e.Discount,
                            Total = e.Total,
                            Status = e.Status,
                            NetAmount = e.NetAmount,
                            //isPOSPurchase = e.isPOSPurchase,
                            isBatchPurchase = e.isBatchPurchase,

                            //isSerialPurchase = e.isSerialPurchase,
                            isPosted = e.isPosted,
                            DocType = e.DocTypeList.DocType,
                            //FinalCostingPrice = e.FinalCostingPrice,
                            //Profit = e.Profit,
                            //ProfitPercentage = e.ProfitPercentage,
                            Location = e.Warehouses.WhShortName,
                            StatusPosted = e.isPosted != false ? "Posted" : "Not Posted",
                            PaidAmt = e.PurchasePayments.Sum(x => x.Amount),// e.PaidAmt,
                            DueAmt = e.NetAmount - e.PurchasePayments.Sum(x => x.Amount),//ReceivingHead = e.AccountPayType != null ? e.AccountPayType.AccName : "=N/A="
                            PurchasePayments = e.PurchasePayments.Select(x => new
                            {
                                x.PurchaseId,
                                x.PaymentCardNo,
                                x.isPosted,
                                x.Amount,
                                x.RowNo,
                                x.AccountHeadId,
                                AccType = x.vChartofAccounts.AccType,
                                AccName = x.vChartofAccounts.AccName
                            }).ToList(),
                            PurchaseItems = e.Items.Select(x => new
                            {
                                x.Id,
                                CategoryName = x.Product.Category.Name,
                                ProductCode = x.Product.Code,
                                ProductName = x.Product.Name,

                                BrandName = x.Product.Brand != null ? x.Product.Brand.BrandName : "",
                                ModelName = x.Product.ModelName,
                                VariantName = x.Product.SizeName,
                                SizeName = x.Product.SizeName,
                                ColorName = x.Product.ColorName,
                                UnitName = x.Product.Unit.UnitShortName,


                                //ProductSerial = x.Product.PurchaseBatchItems.ToList(),
                                ProductSerialList = x.PurchaseBatchItems.Select(x => new
                                {
                                    SerialNo = x.BatchSerialNo,
                                    IsUsed = x.IsUsed
                                }
                                ),
                                //Price = x.Price,
                                CostPrice = x.Price,
                                IndDiscount = x.IndDiscount,
                                Quantity = x.Quantity,
                                Amount = x.Amount

                            }),
                        };



            ///var abcd = query.OrderByDescending(x => x.Id).ToList();

            ///return Json(abcd);





            var abcd = query.OrderByDescending(x => x.Id).Skip(int.Parse(skip.ToString())).Take(int.Parse(pageSize.ToString())).ToList();// Take(50);
            var pageinfo = new PagingInfo();
            pageinfo.PageCount = int.Parse(PageCount.ToString());
            pageinfo.PageNo = pageNo;
            pageinfo.PageSize = int.Parse(pageSize.ToString());
            pageinfo.TotalRecordCount = int.Parse(TotalRecordCount.ToString());


            //List<ProductResult> abcd = query.OrderByDescending(x => x.Id).Skip(skip).Take(pageSize).ToList();

            //return  abcd;
            return Json(new { Success = 1, error = false, Purchaselist = abcd, PageInfo = pageinfo });





            //var parser = new Parser<PurchaseResultList>(Request.Form, query);

            //return Json(parser.Parse());


        }



        [ApiAuthorize]
        public List<SelectListItem> GetSupplierDropdown()
        {
            var x = _supplierRepository.GetAllForDropDown().ToList();
            return x;
        }
        //[ApiAuthorize]
        //public List<SelectListItem> GetWarehouseDropdown()
        //{
        //    var x = _warehouseRepository.GetWarehouseLedgerHeadForDropDown().ToList();
        //    return x;
        //}



        //[ApiAuthorize]
        //public JsonResult GetProductDropdown()
        //{
        //    var x = _productRepository.All().Include(x => x.Unit)
        //           .Select(p => new { ProductId = p.Id, PrdName = p.Name, PurchasePrice = p.Price, CostPrice = p.CostPrice, UnitName = p.Unit.UnitShortName, Unitid = p.UnitId })
        //           .Take(30);

        //    return Json(x);
        //}

        //[ApiAuthorize]
        //public List<SelectListItem> GetBarcodeDropdown()
        //{
        //    var x = _productRepository.GetAllBarcodeForDropDown().ToList();
        //    return x;
        //}

        //[ApiAuthorize]
        //public List<SelectListItem> GetAccountHeadDropdown()
        //{
        //    var x = _accountHeadRepository.GetCashBankHeadForDropDown().ToList();
        //    return x;
        //}

        //[ApiAuthorize]
        //public JsonResult SearchProductSerialDropdown(string query)
        //{
        //    var x = _purchaseBatchItemsRepository.All().Include(x => x.Products).ThenInclude(x => x.Unit).Where(p => (p.BatchSerialNo.ToLower().Contains(query.ToLower())) && (p.IsUsed == false))
        //    .Select(p => new { p.Id, ProductId = p.ProductId, SerialNo = p.BatchSerialNo, CostPrice = p.PurchaseItems.Price, PurchasePrice = p.Products.Price, PrdName = p.Products.Name, Barcode = p.Products.Code, UnitName = p.Products.Unit.UnitShortName, Unitid = p.Products.UnitId })
        //   //.Select(p => p.BatchSerialNo)
        //   .Take(10);



        //    return Json(x);
        //}

        //[ApiAuthorize]
        //public JsonResult GetProductSerialDropdown(string query, int? ProductId)
        //{

        //    var x = _purchaseBatchItemsRepository.All().Include(x => x.Products).ThenInclude(x => x.Unit).Where(p => (p.BatchSerialNo.ToLower().Contains(query.ToLower())) && (p.IsUsed == false) && (p.IsReturn == false) && p.ProductId == ProductId)
        //    .Select(p => new { SerialId = p.Id, ProductId = p.ProductId, SerialNo = p.BatchSerialNo, CostPrice = p.PurchaseItems.Price, PurchasePrice = p.Products.Price, PrdName = p.Products.Name, Barcode = p.Products.Code, UnitName = p.Products.Unit.UnitShortName, Unitid = p.Products.UnitId }).Take(20).ToList();
        //    //.Select(p => p.BatchSerialNo)
        //    //.Take(10);




        //    //var xx = _purchaseBatchItemsRepository.All().Include(x => x.Products).Where(p => p.PurchaseItems.PurchaseId == Purchaseid && p.ProductId == ProductId)
        //    //.Select(p => new { SerialId = p.Id, ProductId = p.ProductId, SerialNo = p.BatchSerialNo, CostPrice = p.PurchaseBatchItems.PurchaseItems.Price, PurchasePrice = p.Products.Price }).ToList();

        //    //foreach (var item in xx)
        //    //{
        //    //    x.Add(item);
        //    //}

        //    return Json(x);
        //}


        [ApiAuthorize]
        public JsonResult GetProductSerialDropdownWithPurchaseId(int? ProductId, int? Purchaseid)//string query, 
        {

            var x = _purchaseBatchItemsRepository.All()
                .Include(x => x.Products).ThenInclude(x => x.Unit)

                .Include(x => x.Products).ThenInclude(x => x.Category)
                .Include(x => x.Products).ThenInclude(x => x.Brand)


                .Where(p => (p.IsUsed == false) && (p.IsReturn == false) && p.ProductId == ProductId) ////(p.BatchSerialNo.ToLower().Contains(query.ToLower())) &&
            .Select(p => new
            {
                Id = 0,
                SerialId = p.Id,
                ProductId = p.ProductId,
                SerialNo = p.BatchSerialNo,
                CostPrice = p.PurchaseItems.Price,
                PurchasePrice = p.Products.Price,

                CategoryName = p.Products.Category.Name,
                BrandName = p.Products.Brand != null ? p.Products.Brand.BrandName : "",
                ModelName = p.Products.ModelName,
                VariantName = p.Products.SizeName,
                SizeName = p.Products.SizeName,
                ColorName = p.Products.ColorName,

                UnitName = p.Products.Unit.UnitShortName,
                Unitid = p.Products.UnitId
            }).Take(20).ToList();
            //.Select(p => p.BatchSerialNo)
            //.Take(10);


            var xx = _purchaseBatchItemsRepository.All()
                .Include(x => x.Products).ThenInclude(x => x.Unit)

                .Include(x => x.Products).ThenInclude(x => x.Category)
                .Include(x => x.Products).ThenInclude(x => x.Brand)

                .Where(p => p.PurchaseItems.PurchaseId == Purchaseid && p.ProductId == ProductId)
            .Select(p => new
            {
                Id = p.Id,
                SerialId = p.Id,
                ProductId = p.ProductId,
                SerialNo = p.BatchSerialNo,
                CostPrice = p.PurchaseItems.Price,
                PurchasePrice = p.Products.Price,

                CategoryName = p.Products.Category.Name,
                BrandName = p.Products.Brand != null ? p.Products.Brand.BrandName : "",
                ModelName = p.Products.ModelName,
                VariantName = p.Products.SizeName,
                SizeName = p.Products.SizeName,
                ColorName = p.Products.ColorName,

                UnitName = p.Products.Unit.UnitShortName,
                Unitid = p.Products.UnitId
            }).ToList();

            foreach (var item in xx)
            {
                x.Add(item);
            }

            return Json(x);
        }

        //[ApiAuthorize]
        //public JsonResult SearchProductDropdown(string query)
        //{
        //    var x = _productRepository.All().Include(x => x.Unit).Where(x => x.Name.ToLower().Contains(query.ToLower()) || x.Code.ToLower().Contains(query)).Take(10).ToList()
        //        .Select(p => new { ProductId = p.Id, PrdName = p.Name, Barcode = p.Code, PurchasePrice = p.Price, CostPrice = p.CostPrice, UnitName = p.Unit.UnitShortName, Unitid = p.UnitId }
        //        );

        //    return Json(x);
        //}

        //[ApiAuthorize]
        //public JsonResult SearchBarcodeDropdown(string query)
        //{

        //    var x = _productRepository.All().Include(x => x.Unit).Where(x => x.Code.ToLower().Contains(query.ToLower())).Take(10).ToList()
        //      .Select(p => new { ProductId = p.Id, PrdName = p.Name, Barcode = p.Code, PurchasePrice = p.Price, CostPrice = p.CostPrice, UnitName = p.Unit.UnitShortName, Unitid = p.UnitId }
        //      );

        //    return Json(x);

        //}

        [ApiAuthorize]
        public JsonResult SupplierSearchByPhoneNo(string query)
        {
            return Json(_purchaseRepository.All().Where(x => (x.PhoneNo.ToLower().Contains(query.ToLower()) || (x.SupplierName.ToLower().Contains(query.ToLower()))))
                  .GroupBy(x => new { x.PhoneNo, x.SupplierName, x.PrimaryAddress })
                  .Select(g => new { PhoneNo = g.Key.PhoneNo == null ? "" : g.Key.PhoneNo, SupplierName = g.Key.SupplierName == null ? "" : g.Key.SupplierName, PrimaryAddress = g.Key.PrimaryAddress == null ? "" : g.Key.PrimaryAddress }).ToList()
                  .Take(10));
        }

        [ApiAuthorize]
        public JsonResult SupplierSearchByName(string query)
        {
            return Json(_supplierRepository.All().Where(x => (x.SupplierName.ToLower().Contains(query.ToLower()) || (x.PrimaryAddress.ToLower().Contains(query.ToLower())) || (x.Phone.ToLower().Contains(query.ToLower()))))
                  //.GroupBy(x => new { x.Name, x.Phone, x.PrimaryAddress })
                  .Select(g => new { g.Id, PhoneNo = g.Phone == null ? "" : g.Phone, SupplierName = g.SupplierName == null ? "" : g.SupplierName, PrimaryAddress = g.PrimaryAddress == null ? "" : g.PrimaryAddress }).ToList()
                  .Take(10));
        }

        //[HttpGet]
        //public ActionResult AddCategory()
        //{
        //    ViewBag.ActionType = "Create";
        //    return View();
        //}

        [HttpPost]
        [ApiAuthorize]
        public ActionResult CreatePurchase([FromBody] PurchaseModel model)
        {
            Atrai.Model.AppData.DefaultConnectionString = Config.GetConnectionString("DefaultConnection");
            var errors = ModelState.Where(x => x.Value.Errors.Any())
            .Select(x => new { x.Key, x.Value.Errors });

            var ComId = (HttpContext.Session.GetInt32("ComId"));
            var LuserId = (HttpContext.Session.GetInt32("UserId"));



            if (model.DocTypeId == null)
            {
                var x = _docTypeRepository.All().Where(x => x.DocType == "Purchase").FirstOrDefault().Id;
                model.DocTypeId = x;
            }


            if (ModelState.IsValid)
            {
                try
                {
                    //if (ModelState.IsValid)
                    //{
                    if (model.Id > 0)
                    {
                        //_purchaseRepository.UpdateApi(model, model.Id);


                        //SqlParameter[] sqlParameter = new SqlParameter[4];
                        //sqlParameter[0] = new SqlParameter("@ComId", ComId);
                        //sqlParameter[1] = new SqlParameter("@Id", model.Id);
                        //sqlParameter[2] = new SqlParameter("@ProcessFor", "Purchase");
                        //sqlParameter[3] = new SqlParameter("@SaveUpdateDelete", "Update");
                        //Helper.ExecProc("prcSerialProcess", sqlParameter);

                        if (model.isBatchPurchase == null)
                        {
                            model.isBatchPurchase = true;
                        }


                        var Purchaseitems = PurchaseItemRepository.All().Where(x => x.PurchaseId == model.Id).ToList();
                        PurchaseItemRepository.RemoveRange(Purchaseitems);

                        _purchaseRepository.Update(model, model.Id);



                        foreach (PurchaseItemsModel item in model.Items)
                        {

                            if (item.Id > 0)
                            {
                                if (item.IsDelete == true)
                                {
                                    int z = item.Id;
                                    PurchaseItemRepository.Delete(item);

                                }
                                else
                                {
                                    if (item.isTransaction == true)//item.IsDelete == false &&  
                                    {

                                        if (item.PurchaseBatchItems != null)
                                        {

                                            var batchitemlist = _purchaseBatchItemsRepository.All().Where(x => x.PurchaseItemId == item.Id).ToList();
                                            _purchaseBatchItemsRepository.RemoveRange(batchitemlist);

                                        }


                                        foreach (PurchaseBatchItemsModel batchitem in item.PurchaseBatchItems)
                                        {
                                            if (batchitem.Id > 0)
                                            {
                                                if (batchitem.IsDelete == true)
                                                {
                                                    int z = batchitem.Id;
                                                    _purchaseBatchItemsRepository.Delete(batchitem);

                                                }
                                                else
                                                {
                                                    if (batchitem.IsTransaction == true)
                                                    {
                                                        batchitem.ComId = ComId.GetValueOrDefault();
                                                        _purchaseBatchItemsRepository.Update(batchitem, batchitem.Id);
                                                    }
                                                }
                                            }
                                            else if (batchitem.Id == 0 && batchitem.IsDelete == false)
                                            {
                                                batchitem.ComId = ComId.GetValueOrDefault();
                                                _purchaseBatchItemsRepository.Insert(batchitem);
                                            }


                                        }

                                        PurchaseItemRepository.Update(item, item.Id);

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

                                    PurchaseItemRepository.Insert(item);




                                    //foreach (PurchaseBatchItemsModel batchitem in item.BatchSerialItems)
                                    //{
                                    //    if (batchitem.IsDelete == true)
                                    //    {

                                    //    }
                                    //    else
                                    //    {
                                    //        PurchaseItemRepository.Insert(item);

                                    //    }


                                    //}

                                }
                            }
                        }



                        var Purchasepaymentsdata = _purchasePaymentRepository.All().Where(x => x.PurchaseId == model.Id).ToList();
                        _purchasePaymentRepository.RemoveRange(Purchasepaymentsdata);


                        foreach (PurchasePaymentModel item in model.PurchasePayments.Where(x => x.IsDelete == false))
                        {

                            _purchasePaymentRepository.Insert(item);


                            //if (item.Id > 0)
                            //{
                            //    if (item.IsDelete == true)
                            //    {
                            //        int z = item.Id;
                            //        _purchasePaymentRepository.Delete(item);

                            //    }
                            //    else
                            //    {
                            //        _purchasePaymentRepository.Update(item, item.Id);

                            //    }
                            //}
                            //else
                            //{
                            //    if (item.IsDelete == true)
                            //    {
                            //    }
                            //    else
                            //    {

                            //        _purchasePaymentRepository.Insert(item);

                            //    }
                            //}
                        }




                        NotificationModel abcd = new NotificationModel();
                        abcd.TextMessage = model.PurchaseCode + " - " + "Invoice Modified by User.";
                        abcd.Value = model.Id;
                        abcd.Type = "Purchase";

                        _notificationRepository.Insert(abcd);



                        TempData["Message"] = "Data Update Successfully";
                        TempData["Status"] = "2";
                        tranlog.TransactionLog(RouteData.Values["controller"].ToString(), RouteData.Values["action"].ToString(), TempData["Message"].ToString(), model.Id.ToString(), "Update", model.PurchaseCode);



                        SqlParameter[] sqlParameter1 = new SqlParameter[4];
                        sqlParameter1[0] = new SqlParameter("@ComId", ComId);
                        sqlParameter1[1] = new SqlParameter("@Id", model.Id);
                        sqlParameter1[2] = new SqlParameter("@ProcessFor", "Purchase");
                        sqlParameter1[3] = new SqlParameter("@SaveUpdateDelete", "Save");
                        Helper.ExecProc("prcSerialProcess", sqlParameter1);

                        return Json(new { Success = 1, error = false, message = "Data Update successfully", Id = model.Id });



                    }
                    else
                    {
                        if (model.isBatchPurchase == null)
                        {
                            model.isBatchPurchase = true;
                        }

                        _purchaseRepository.Insert(model);



                        NotificationModel abcd = new NotificationModel();
                        abcd.TextMessage = model.PurchaseCode + " - " + "New Invoice Created.";
                        abcd.Value = model.Id;
                        abcd.Type = "Purchase";
                        _notificationRepository.Insert(abcd);


                        SqlParameter[] sqlParameter1 = new SqlParameter[4];
                        sqlParameter1[0] = new SqlParameter("@ComId", ComId);
                        sqlParameter1[1] = new SqlParameter("@Id", model.Id);
                        sqlParameter1[2] = new SqlParameter("@ProcessFor", "Purchase");
                        sqlParameter1[3] = new SqlParameter("@SaveUpdateDelete", "Save");
                        Helper.ExecProc("prcSerialProcess", sqlParameter1);
                    }

                    return Json(new { Success = 1, error = false, message = "Data Save successfully", Id = model.Id });
                    //return Ok(true);
                    //}
                    //return Ok(false);
                }
                catch (Exception x)
                {
                    //Console.WriteLine(x.Message );
                    //return Ok(x.Message);

                    return Json(new { Success = 0, error = true, message = x.Message + " ; " + x.InnerException, Id = model.Id });

                }
            }
            else
            {
                return Ok(false);
            }

            //try
            //{
            //    Atrai.Model.AppData.DefaultConnectionString = Config.GetConnectionString("DefaultConnection");

            //    var UserId = HttpContext.Session.GetInt32("UserId");
            //    var ComId = HttpContext.Session.GetInt32("ComId");


            //    var errors = ModelState.Where(x => x.Value.Errors.Any())
            //    .Select(x => new { x.Key, x.Value.Errors });

            //    if (ModelState.IsValid)
            //    {
            //        if (model.Id > 0)
            //        {
            //            _purchaseRepository.Update(model, model.Id);
            //            foreach (PurchaseItemsModel item in model.Items)
            //            {

            //                if (item.Id > 0)
            //                {
            //                    if (item.IsDelete == true)
            //                    {
            //                        int z = item.Id;
            //                        PurchaseItemRepository.Delete(item);

            //                    }
            //                    else
            //                    {
            //                        if (item.isTransaction == true)//item.IsDelete == false &&  
            //                        {
            //                            if (item.PurchaseBatchItems != null)
            //                            {
            //                                foreach (PurchaseBatchItemsModel batchitem in item.PurchaseBatchItems)
            //                                {
            //                                    if (batchitem.Id > 0)
            //                                    {
            //                                        if (batchitem.IsDelete == true)
            //                                        {
            //                                            int z = batchitem.Id;
            //                                            _purchaseBatchItemsRepository.Delete(batchitem);

            //                                        }
            //                                        else
            //                                        {
            //                                            if (batchitem.IsTransaction == true)
            //                                            {
            //                                                batchitem.ComId = ComId.GetValueOrDefault();
            //                                                batchitem.LuserId = UserId.GetValueOrDefault();


            //                                                _purchaseBatchItemsRepository.Update(batchitem, batchitem.Id);
            //                                            }
            //                                        }
            //                                    }
            //                                    else if (batchitem.Id == 0 && batchitem.IsDelete == false)
            //                                    {
            //                                        batchitem.ComId = ComId.GetValueOrDefault();
            //                                        batchitem.LuserId = UserId.GetValueOrDefault();
            //                                        _purchaseBatchItemsRepository.Insert(batchitem);
            //                                    }


            //                                }
            //                            }

            //                            PurchaseItemRepository.Update(item, item.Id);

            //                        }
            //                    }
            //                }
            //                else
            //                {
            //                    if (item.IsDelete == true)
            //                    {
            //                    }
            //                    else
            //                    {
            //                        PurchaseItemRepository.Insert(item);


            //                        //if (item.PurchaseBatchItems != null)
            //                        //{
            //                        //    foreach (PurchaseBatchItemsModel batchitem in item.PurchaseBatchItems)
            //                        //    {
            //                        //        if (batchitem.IsDelete == true)
            //                        //        {

            //                        //        }
            //                        //        else
            //                        //        {
            //                        //            _purchaseBatchItemsRepository.Insert(batchitem);
            //                        //        }


            //                        //    }
            //                        //}

            //                    }
            //                }
            //            }


            //            var salespaymentsdata = _purchasePaymentRepository.All().Where(x => x.PurchaseId == model.Id).ToList();
            //            _purchasePaymentRepository.RemoveRange(salespaymentsdata);


            //            foreach (PurchasePaymentModel item in model.PurchasePayments.Where(x => x.IsDelete == false))
            //            {
            //                _purchasePaymentRepository.Insert(item);
            //            }



            //            //var items = PurchaseItemRepository.AllSubData().Where(x => x.PurchaseId == model.Id).ToList();
            //            //if (items.Any())
            //            //{
            //            //    PurchaseItemRepository.RemoveRange(items.ToList());

            //            //    //foreach (var item in items)
            //            //    //{
            //            //    //    PurchaseItemRepository.Delete(item);
            //            //    //}
            //            //}
            //            //_purchaseRepository.Update(model, model.Id);


            //            //if (model.Items != null)
            //            //{

            //            //    PurchaseItemRepository.AddRange(model.Items);

            //            //    //foreach (PurchaseItemsModel data in model.Items)
            //            //    //{
            //            //    //    //ss.DateAdded = DateTime.Now;
            //            //    //    //ss.DateUpdated = DateTime.Now;

            //            //    //    PurchaseItemRepository.Insert(data);
            //            //    //    //db.SaveChanges();
            //            //    //}
            //            //    //db.SaveChanges();

            //            //}

            //            ////var Purchase = _purchaseRepository.Find(model.Id);
            //            ////Purchase.SupplierName = model.SupplierName;
            //            ////Purchase.PrimaryAddress = model.PrimaryAddress;
            //            ////Purchase.PhoneNo = model.PhoneNo;

            //            ////Purchase.Notes = model.Notes;
            //            ////Purchase.PaymentMethod = model.PaymentMethod;
            //            ////Purchase.PurchaseCode = model.PurchaseCode;
            //            ////Purchase.SupplierId = model.SupplierId;
            //            ////Purchase.Total = model.Total;
            //            ////Purchase.PurchaseDate = model.PurchaseDate;
            //            ////Purchase.Status = model.Status;
            //            ////Purchase.Discount = model.Discount;

            //            ////Purchase.ServiceCharge = model.ServiceCharge;
            //            ////Purchase.Shipping = model.Shipping;
            //            ////Purchase.TotalVat = model.TotalVat;

            //            ////Purchase.GrandTotal = model.GrandTotal;

            //            ////Purchase.NetAmount = model.NetAmount;
            //            ////Purchase.PaidAmt = model.PaidAmt;
            //            ////Purchase.DisAmt = model.DisAmt;
            //            ////Purchase.DueAmt = model.DueAmt;





            //            ////add again
            //            ////foreach (var item in model.Items)
            //            ////{

            //            ////    //if (item.PurchaseBatchItems != null)
            //            ////    //{
            //            ////    //    foreach (var batchitem in item.PurchaseBatchItems)
            //            ////    //    {
            //            ////    //        item.PurchaseBatchItems.Add(new PurchaseBatchItemsModel
            //            ////    //        {
            //            ////    //            BatchSerialNo = batchitem.BatchSerialNo,
            //            ////    //            Price = batchitem.Price,
            //            ////    //            Quantity = batchitem.Quantity,
            //            ////    //            BatchRemarks = batchitem.BatchRemarks,
            //            ////    //            ProductId = batchitem.ProductId,
            //            ////    //            SLNo = batchitem.SLNo,
            //            ////    //            CreateDate = DateTime.Now,
            //            ////    //            UpdateDate = DateTime.Now,
            //            ////    //            ComId = int.Parse(ComId.ToString())
            //            ////    //        });
            //            ////    //    }
            //            ////    //}


            //            ////    //Purchase.Items.Add(new PurchaseItemsModel
            //            ////    //{
            //            ////    //    Id = item.Id,
            //            ////    //    WarehouseId = item.WarehouseId,
            //            ////    //    Price = item.Price,
            //            ////    //    Amount = item.Amount,
            //            ////    //    Quantity = item.Quantity,
            //            ////    //    Name = item.Name,
            //            ////    //    ProductId = item.ProductId,
            //            ////    //    Description = item.Description,
            //            ////    //    CreateDate = DateTime.Now,
            //            ////    //    UpdateDate = DateTime.Now,
            //            ////    //    ComId = int.Parse(ComId.ToString()),
            //            ////    //    PurchaseBatchItems = item.PurchaseBatchItems,
            //            ////    //    IsDelete = false,
            //            ////    //});
            //            ////}
            //            ////_purchaseRepository.Update(model, model.Id);



            //            TempData["Message"] = "Data Update Successfully";
            //            TempData["Status"] = "2";
            //            tranlog.TransactionLog(RouteData.Values["controller"].ToString(), RouteData.Values["action"].ToString(), TempData["Message"].ToString(), model.Id.ToString(), "Update", model.PurchaseCode);

            //            return Json(new { error = false, message = "Purchase updated successfully", Id = model.Id });
            //        }
            //        else
            //        {

            //            //var UserId = HttpContext.Session.GetInt32("UserId");
            //            //var ComId = HttpContext.Session.GetInt32("ComId");

            //            foreach (var item in model.Items)
            //            {

            //                item.CreateDate = DateTime.Now;
            //                item.UpdateDate = DateTime.Now;
            //                item.ComId = int.Parse(ComId.ToString());
            //                item.LuserId = int.Parse(UserId.ToString());


            //                if (item.PurchaseBatchItems != null)
            //                {
            //                    foreach (var Batchitem in item.PurchaseBatchItems)
            //                    {

            //                        Batchitem.CreateDate = DateTime.Now;
            //                        Batchitem.UpdateDate = DateTime.Now.Date;
            //                        Batchitem.ComId = int.Parse(ComId.ToString());
            //                        Batchitem.LuserId = int.Parse(UserId.ToString());
            //                        //Batchitem.ComId = int.Parse(ComId.ToString());

            //                    }
            //                }

            //            }




            //            _purchaseRepository.Insert(model);


            //            TempData["Message"] = "Data Save Successfully";
            //            TempData["Status"] = "1";
            //            tranlog.TransactionLog(RouteData.Values["controller"].ToString(), RouteData.Values["action"].ToString(), TempData["Message"].ToString(), model.Id.ToString(), "Create", model.PurchaseCode);


            //            return Json(new { error = false, message = "Purchase saved successfully",Id = model.Id });
            //        }

            //    }
            //    else
            //    {
            //        return Json(new { error = true, message = "Failed to save Purchase" });
            //    }



            //}
            //catch (Exception ex)
            //{

            //    return Json(new { error = true, message = ex.Message });
            //}





        }

        [HttpGet]
        [ApiAuthorize]
        public JsonResult GetSinglePurchase(int PurchaseId)
        {
            var Purchasedata = _purchaseRepository.All()
            .Include(x => x.Items).ThenInclude(x => x.PurchaseBatchItems)
            .Include(x => x.Items).ThenInclude(x => x.Product).ThenInclude(x => x.Unit)
            .Include(x => x.PurchasePayments)
            .Include(x => x.AccountTransaction)
            .Where(x => x.Id == PurchaseId && x.isPosted == false)
            .Select(p => new
            {
                Id = p.Id,
                PurchaseCode = p.PurchaseCode,
                //SupplierModel = p.SupplierModel,
                //SupplierName = p.SupplierName,
                SupplierName = (p.SupplierName.Length == 0 || p.SupplierName == null) ? p.SupplierModel.SupplierName : p.SupplierModel.SupplierName + " - " + p.SupplierName,

                PhoneNo = p.PhoneNo,
                PrimaryAddress = p.PrimaryAddress,
                SecoundaryAddress = p.SecoundaryAddress,
                PurchasePayments = p.PurchasePayments.Where(a => a.IsDelete == false)
                                .Select(a => new
                                {
                                    PurchaseId = a.PurchaseId,
                                    PaymentCardNo = a.PaymentCardNo,
                                    Amount = a.Amount,
                                    AccountHeadId = a.AccountHeadId,
                                    Id = a.Id,
                                    CreateDate = a.CreateDate
                                }),

                Discount = p.Discount,
                DisPer = p.DisPer,
                DisAmt = p.DisAmt,
                isDisPer = p.isDisPer,//p.isDisPer,


                GrandTotal = p.GrandTotal,
                SupplierId = p.SupplierId,
                //DueAmt = p.DueAmt,
                DueAmt = p.NetAmount - p.PurchasePayments.Sum(x => x.Amount),
                Notes = p.Notes,
                PurchaseDate = p.PurchaseDate,
                PurchaseDateString = p.PurchaseDate.ToString("dd-MMM-yy"),

                CreateDate = p.CreateDate,
                Total = p.Total,
                NetAmount = p.NetAmount,
                PaidAmt = p.PaidAmt,
                ServiceCharge = p.ServiceCharge,
                Shipping = p.Shipping,
                TotalVat = p.TotalVat,
                isPosted = p.isPosted,
                isBatchPurchase = p.isBatchPurchase,
                //isWholePurchase = p.isWholePurchase,
                WarehouseIdMain = p.WarehouseIdMain,


                //Profit = p.Profit,
                //ProfitPercentage = p.ProfitPercentage,
                //FinalCostingPrice = p.FinalCostingPrice,
                //TotalCommisionAmount = p.TotalCommisionAmount,

                DocTypeId = p.DocTypeId,



                Items = p.Items.Where(x => x.IsDelete == false).Select(x =>
                   new
                   {
                       Id = x.Id,
                       PurchaseId = x.PurchaseId,
                       Name = x.Product.Name,
                       Barcode = x.Product.Code,




                       CategoryName = x.Product.Category.Name,
                       BrandName = x.Product.Brand != null ? x.Product.Brand.BrandName : "",
                       ModelName = x.Product.ModelName,
                       VariantName = x.Product.SizeName,
                       SizeName = x.Product.SizeName,
                       ColorName = x.Product.ColorName,


                       Description = x.Description,
                       WarehouseId = x.WarehouseId,
                       //SerialItem = x.PurchaseBatchItems,

                       //CommissionAmount = x.CommissionAmount,
                       //CommissionPer = x.CommissionPer,
                       //UserCommissionAmount = x.UserCommissionAmount,

                       //CartonQty = x.CartonQty,
                       //PCTN = x.PCTN,
                       //IndDiscount = x.IndDiscount,

                       UnitName = x.Product.Unit.UnitShortName,
                       //isDisPerRow = x.isDisPerRow,




                       ProductId = x.ProductId,
                       Quantity = x.Quantity,
                       //CostPrice = x.CostPrice,
                       Price = x.Price,
                       Amount = x.Amount,
                       IndDiscount = x.IndDiscount,
                       isDisPerRow = x.isDisPerRow,
                       BatchSerialItems = x.PurchaseBatchItems
                       .Where(y => y.IsDelete == false).Select(y =>
                            new
                            {
                                Id = y.Id,
                                PurchaseItemId = y.PurchaseItemId,
                                ProductId = y.ProductId,
                                BatchSerialNo = y.BatchSerialNo,
                                IsUsed = y.IsUsed,
                                PurchaseBatchQuantity = y.PurchaseBatchQuantity,
                                PurchaseBatchAmount = y.PurchaseBatchAmount,
                                PurchaseBatchPrice = y.PurchaseBatchPrice
                            }).ToList(),
                   }).ToList()



            }).FirstOrDefault();
            //x.UserAccountList = null;

            return Json(Purchasedata);
        }
        [ApiAuthorize]
        public ActionResult DeletePurchase(int PurchaseId)
        {
            try
            {
                var response = _purchaseRepository.Find(PurchaseId);

                if (response != null) _purchaseRepository.Delete(response);
                else if (response == null) return BadRequest(new { message = "Purchase Can not be Deleted" });

                //Ok(false);

                return Ok(true);

            }
            catch (Exception x)
            {
                Console.WriteLine(x.Message);
                return BadRequest(new { message = "Something Wrong" });
            }
        }


        //[ApiAuthorize]
        //public JsonResult GetPurchaseSummaryInfo(string FromDate, string ToDate, int? SupplierId, int? UserId, int? WarehouseId)
        //{
        //    try
        //    {
        //        var sessionLuserId = (HttpContext.Session.GetInt32("UserId"));

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

        //        var daywisePurchasecount = _purchaseRepository.All()
        //         .Where(x => x.PurchaseDate >= DateTime.Now.Date.AddDays(-6) && x.PurchaseDate <= DateTime.Now.Date)
        //         .GroupBy(x => new { x.ComId, x.PurchaseDate })
        //         .Select(g => new { PurchaseDate = g.Key.PurchaseDate.ToString("dd-MMM-yy"), TotalPurchaseCount = g.Count(), TotalPurchaseSum = g.Sum(x => x.NetAmount) }).ToList();


        //        var Purchaselist = _purchaseRepository.All().Where(x => x.PurchaseDate >= dtFrom && x.PurchaseDate <= dtTo);
        //        var Purchasepaymentlist = _purchasePaymentRepository.All().Include(x => x.PurchaseMain).ThenInclude(x => x.SupplierModel).Where(x => x.PurchaseMain.PurchaseDate >= dtFrom && x.PurchaseMain.PurchaseDate <= dtTo  && x.PurchaseMain.IsDelete == false);
        //        var Purchaseitemlist = PurchaseItemRepository.All().Where(x => x.PurchaseModel.PurchaseDate >= dtFrom && x.PurchaseModel.PurchaseDate <= dtTo  && x.PurcahseMainModel.IsDelete == false);

        //        if (SupplierId != null)
        //        {
        //            Purchaselist = Purchaselist.Where(p => p.SupplierId == SupplierId);
        //            Purchasepaymentlist = Purchasepaymentlist.Where(p => p.PurchaseMain.SupplierId == SupplierId);
        //            Purchaseitemlist = Purchaseitemlist.Where(p => p.PurchaseModel.SupplierId == SupplierId);
        //        }

        //        if (UserId != null)
        //        {
        //            Purchaselist = Purchaselist.Where(p => p.LuserId == UserId);
        //            Purchasepaymentlist = Purchasepaymentlist.Where(p => p.PurchaseMain.LuserId == UserId);
        //            Purchaseitemlist = Purchaseitemlist.Where(p => p.PurchaseModel.LuserId == UserId);
        //        }


        //        if (WarehouseId != null)
        //        {
        //            Purchaselist = Purchaselist.Where(p => p.WarehouseIdMain == WarehouseId);
        //            Purchasepaymentlist = Purchasepaymentlist.Where(p => p.PurchaseMain.WarehouseIdMain == WarehouseId);
        //            Purchaseitemlist = Purchaseitemlist.Where(p => p.PurchaseModel.WarehouseIdMain == WarehouseId);
        //        }
        //        else
        //        {
        //            var arrayabc = FromWarehousePermissionRepository.All().Where(x => x.LuserIdAllow == sessionLuserId).Select(x => x.WarehouseId).ToList();
        //            //int a = 1;
        //            //List<int> IDs = new List<int> { 1, 3, 4, 8 };

        //            //var warehouselist = FromWarehousePermissionRepository.All().Select(x => x.Id);
        //            if (arrayabc.Count() > 0)
        //            {
        //                //Purchaselist = Purchaselist.Where(p => arrayabc.Contains(p.WarehouseIdMain));

        //                Purchaselist = Purchaselist.Where(p => arrayabc.Contains(p.WarehouseIdMain));
        //                Purchasepaymentlist = Purchasepaymentlist.Where(p => arrayabc.Contains(p.PurchaseMain.WarehouseIdMain));
        //                Purchaseitemlist = Purchaseitemlist.Where(p => arrayabc.Contains(p.PurchaseModel.WarehouseIdMain));

        //            }
        //        }



        //        var totalPurchasesummary = Purchaselist //.GroupBy(p => p.vPaymentType.TypeName);
        //        .GroupBy(x => new { x.ComId })
        //        .Select(g => new { TotalPurchaseCount = g.Count(), TotalPurchaseValue = g.Sum(x => x.NetAmount), TotalCosting = g.Sum(x => x.FinalCostingPrice), TotalProfit = g.Sum(x => x.Profit) });



        //        var Purchasebyuser = Purchaselist //.GroupBy(p => p.vPaymentType.TypeName);
        //        .GroupBy(x => new { x.UserAccountList.Name })
        //        .Select(g => new { UserName = g.Key.Name, TotalPurchaseCount = g.Count(), TotalPurchaseSum = g.Sum(x => x.NetAmount) }).ToList();


        //        var commissionbyuser = Purchaselist //.GroupBy(p => p.vPaymentType.TypeName);
        //        .GroupBy(x => new { x.UserAccountList.Name })
        //        .Select(g => new { UserName = g.Key.Name, TotalPurchaseCount = g.Count(), TotalCommissionAmount = g.Sum(x => x.TotalCommisionAmount) }).ToList();


        //        var Purchasereceivebyhead = Purchasepaymentlist.GroupBy(x => new { x.vChartofAccounts.AccName })
        //        .Select(g => new { AccName = g.Key.AccName, Amount = g.Sum(x => x.Amount) }).ToList();


        //        var totalreceivedamount = Purchasepaymentlist.Sum(x => x.Amount);
        //        var totalPurchase = Purchaselist.Sum(x => x.GrandTotal);
        //        Purchasereceivebyhead.Add(new
        //        {
        //            AccName = "Due",
        //            Amount = (totalPurchase - totalreceivedamount)
        //        });


        //        var topsellingitem = Purchaseitemlist //.GroupBy(p => p.vPaymentType.TypeName);
        //         .GroupBy(x => new { x.Product.Name })
        //         .Select(g => new { ProductName = g.Key.Name, ProductCount = g.Count() }).ToList().OrderByDescending(x => x.ProductCount).Take(5);

        //        var topsellingSupplier = Purchaselist.Include(x => x.SupplierModel)//.GroupBy(p => p.vPaymentType.TypeName);
        //         .GroupBy(x => new { walkinSupplier = x.SupplierName, SupplierName = x.SupplierModel.SupplierName })
        //         .Select(g => new { SupplierName = g.Key.SupplierName.ToLower().Contains("Supplier") ? g.Key.walkinSupplier : g.Key.SupplierName, PurchaseAmount = g.Sum(x => x.GrandTotal) }).ToList().OrderByDescending(x => x.PurchaseAmount).Take(5);


        //        var topdueSupplier = Purchasepaymentlist
        //        .GroupBy(x => new { walkinSupplier = x.PurchaseMain.SupplierName, SupplierName = x.PurchaseMain.SupplierModel.SupplierName, GradnTotal = x.PurchaseMain.GrandTotal })
        //        .Select(g => new { SupplierName = g.Key.SupplierName.ToLower().Contains("Supplier") ? g.Key.walkinSupplier : g.Key.SupplierName, TotalPurchase = g.Key.GradnTotal, ReceivedAmount = g.Sum(x => x.Amount) })
        //        .Where(x => (x.TotalPurchase - x.ReceivedAmount > 0))
        //        .ToList().OrderByDescending(x => x.TotalPurchase - x.ReceivedAmount)
        //        .Take(5).ToList();

        //        var topdueSuppliermore = Purchaselist.Include(x => x.PurchasePayments).Include(x => x.SupplierModel).Where(x => x.PurchasePayments.Count() == 0)
        //       .GroupBy(x => new { walkinSupplier = x.SupplierName, SupplierName = x.SupplierModel.SupplierName, GradnTotal = x.GrandTotal })
        //       .Select(g => new { SupplierName = g.Key.SupplierName.ToLower().Contains("Supplier") ? g.Key.walkinSupplier : g.Key.SupplierName, TotalPurchase = g.Sum(x => g.Key.GradnTotal), ReceivedAmount = decimal.Parse("0") })
        //       .Where(x => (x.TotalPurchase - x.ReceivedAmount > 0))
        //       .ToList().OrderByDescending(x => x.TotalPurchase - x.ReceivedAmount)
        //       .Take(5).ToList();

        //        foreach (var item in topdueSuppliermore)
        //        {
        //            topdueSupplier.Add(item);
        //        }


        //        var postunpostcount = Purchaselist //.GroupBy(p => p.vPaymentType.TypeName);
        //        .GroupBy(x => new { isPosted = x.isPosted })
        //        .Select(g => new { isPosted = g.Key.isPosted, DocCount = g.Count() }).ToList();


        //        var sellingitembycategory = Purchaseitemlist //.GroupBy(p => p.vPaymentType.TypeName);
        //        .GroupBy(x => new { CategoryName = x.Product.Category.Name })
        //        .Select(g => new { CategoryName = g.Key.CategoryName, CategoryCount = g.Count(), TotalProfit = g.Sum(x => x.Price * x.Quantity) - g.Sum(x => x.IndDiscount * x.Quantity) - g.Sum(x => x.CostPrice * x.Quantity), TotalPurchase = g.Sum(x => x.Price * x.Quantity) - g.Sum(x => x.IndDiscount * x.Quantity) }) ///g.Sum(x=>x.PurchaseModel.DisAmt
        //        .OrderByDescending(x => x.TotalPurchase).Take(10);



        //        var genericResult = new
        //        {
        //            totalPurchasesummary = totalPurchasesummary,
        //            Purchasebyuser = Purchasebyuser,
        //            Purchasereceivebyhead = Purchasereceivebyhead,
        //            commissionbyuser = commissionbyuser,
        //            topsellingitem = topsellingitem,
        //            topsellingSupplier = topsellingSupplier,
        //            topdueSupplier = topdueSupplier,
        //            postunpostcount = postunpostcount,
        //            sellingitembycategory = sellingitembycategory,
        //            daywisePurchasecount = daywisePurchasecount
        //        };
        //        return Json(genericResult);

        //    }
        //    catch (Exception ex)
        //    {
        //        return Json(new { success = false, values = ex.Message.ToString() });
        //    }
        //}



        #endregion

        #region Online Orders


        public JsonResult OrdersStatus(int orderid)
        {
            var x = _ordresRepository.All(false).Where(x => x.Id == orderid)
              .Select(p => new { p.Id, p.OrderCode, p.CustomerName, p.PrimaryAddress, p.GrandTotal, p.PhoneNo, Message = ("Order No : " + p.OrderCode + "///Order By : " + p.CustomerName + "///Phone No : " + p.PhoneNo + "///Delivery Address : " + p.PrimaryAddress + "///Amount : " + p.GrandTotal).Replace("///", System.Environment.NewLine) });

            return Json(x);
        }

        [HttpGet]
        public IActionResult OrdersReport(int orderid, string format = "PDF", int isfile = 0)
        {
            //string resulta = "";
            //var weburl = Request.Scheme + "://" + Request.Host.Value + "/" + Request.QueryString.Value;
            ////var weburl = Request.GetTypedHeaders().Referer.ToString().ToLower();//.Replace("/Home/Login".ToLower(), "");

            //var origin = weburl.ToLower();
            //var weburlquerystring = Request.QueryString.HasValue == true ? Request.QueryString.ToString() : "";// Request.QueryString == null ? "": Request.QueryString;// Request.QueryString?? Request.QueryString;//.Replace("/Home/Login".ToLower(), "");

            //if (weburlquerystring.Length > 2)
            //{
            //    resulta = origin.Replace(weburlquerystring.ToLower(), "").Replace("/Home/Login".ToLower(), "");

            //}
            //else
            //{
            //    resulta = origin.Replace("/Home/Login".ToLower(), "");

            //}
            //HttpContext.Session.SetString("weburl", resulta.ToString());
            HttpContext.Session.SetString("ReportType", format);

            //var weburl = Request.Host.Value;
            //ViewBag.weburl = weburl.Trim();

            string weburl = "pqstec.com";//Config.GetSection("host").Value;


            Atrai.Model.AppData.DefaultConnectionString = Config.GetConnectionString("DefaultConnection");

            var company = _companyRepository.All().Where(x => x.comWeb.ToLower().Contains(weburl.ToLower().Trim())).FirstOrDefault();

            if (company != null)
            {
                HttpContext.Session.SetInt32("ComId", company.Id);
            }

            //var UserId = HttpContext.Session.GetInt32("UserId");
            var ComId = HttpContext.Session.GetInt32("ComId");
            //weburl = HttpContext.Session.GetString("weburl"); //"https://www.pqstec.com/InvoiceApps";//  HttpContext.Session.GetString("weburl"); 
            var ReportStyle = _storeSettingRepository.All().Include(x => x.SalesReportStyle).Select(x => x.SalesReportStyle.ReportStyleName).FirstOrDefault(); //HttpContext.Session.GetString("SalesReportStyle");

            string reportname = "rptInvoice";
            var filename = "Invoice_";


            if (ReportStyle.ToString().Length > 0)
            {
                reportname = "rptInvoice_" + ReportStyle.ToString();
            }

            //Atrai.Model.AppDataDynamic ReportInfo = new Atrai.Model.AppDataDynamic();
            //ReportInfo.ReportPath = "~/ReportViewer/POS/" + reportname + ".rdlc";
            //ReportInfo.ReportQuery = "Exec  [rptInvoice] '" + saleId + "','" + ComId + "', '" + weburl + "','Invoice'";
            //ReportInfo.PrintFileName = filename.Replace(".", "").Replace(" ", "").Replace(",", "").Replace("\"", "");

            HttpContext.Session.SetString("ReportQuery", "Exec [rptOnlineOrders] '" + orderid + "','" + ComId + "', '" + weburl + "','Invoice'");
            HttpContext.Session.SetString("ReportPath", "~/ReportViewer/POS/" + reportname + ".rdlc");
            HttpContext.Session.SetString("PrintFileName", filename.Replace(".", "").Replace(" ", "").Replace(",", "").Replace("\"", ""));


            postData.Add(1, new subReport("rptInvoice_PM", "", "DataSet1", "Exec rptInvoice_PM '" + orderid + "'," + ComId + ""));
            HttpContext.Session.SetObject("rptList", postData);

            //return RedirectToAction("Index", "ReportViewer");
            return RedirectToAction("Index", "ReportViewer", new { reporttype = format, isfile = isfile });
        }



        #endregion

        #region Warrenty

        [ApiAuthorize]
        public List<SelectListItem> GetWarrentyDropdown()
        {
            var x = _warrentyRepository.GetAllForDropDown().ToList();
            return x;
        }

        #endregion

        #region notification


        [HttpGet]
        [ApiAuthorize]
        public JsonResult GetNotificationList(int pageNo = 1, decimal pageSize = 10, string searchquery = "", string SortyBy = "") // Alphabet // Balance
        //public List<CustomerResultList> GetCustomerList(int pageNo = 1, int pageSize = 10, string searchquery = "")
        {
            try
            {

                var ComId = (HttpContext.Session.GetInt32("ComId"));
                var LuserId = (HttpContext.Session.GetInt32("UserId"));

                var notificationlist = _notificationRepository.All();//.Take(30);//.Include(x=>x.vUnit).Include(x=>x.Category);.Where(x => x.ComId == 1)

                //if (searchquery?.Length > 1)
                //{
                //    notificationlist = notificationlist.Where(x => x.Name.ToLower().Contains(searchquery.ToLower()) || x.PrimaryAddress.ToLower().Contains(searchquery.ToLower()) || x.Phone.ToLower().Contains(searchquery.ToLower()));
                //}




                decimal TotalRecordCount = notificationlist.Count();
                var PageCountabc = (TotalRecordCount / pageSize);
                var PageCount = Math.Ceiling(PageCountabc);
                decimal skip = (pageNo - 1) * pageSize;
                // Get total number of records
                int total = notificationlist.Count();



                var query = from e in notificationlist//.Where(x => x.Id > 0 && x.ComId == ComId).OrderByDescending(x => x.Id)

                            select new //CustomerResultList
                            {
                                e.Id,
                                //e.NotificationSeenList,
                                IsSeen = e.NotificationSeenList != null && e.NotificationSeenList.Any(),
                                e.Type,
                                e.TextMessage,
                                e.NotifyDate,

                                //heading: String
                                //subtitle: String
                                //DateTime
                                //categoryType: (String - Flag) Exe:
                                //payment,
                                //bill,
                                //cashIn,
                                //cashOut,
                                //paymentSuccessful

                            };

                var pageinfo = new PagingInfo();


                var defaultlist = query.OrderByDescending(x => x.Id).Skip(int.Parse(skip.ToString())).Take(int.Parse(pageSize.ToString())).ToList();// Take(50);
                pageinfo.PageCount = int.Parse(PageCount.ToString());
                pageinfo.PageNo = pageNo;
                pageinfo.PageSize = int.Parse(pageSize.ToString());
                pageinfo.TotalRecordCount = int.Parse(TotalRecordCount.ToString());
                return Json(new { Success = 1, error = false, NotificationList = defaultlist, PageInfo = pageinfo });



            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        //fahad


        // [ApiAuthorize]
        public JsonResult GetUserNotification(int LuserId)
        {
            var y = _notificationSeenRepository.All().Where(s => s.LuserId == LuserId);
            var x = (from p in _notificationRepository.All().OrderByDescending(x => x.Id).Take(2).Where(m => m.LuserId != LuserId)
                     where !y.Any(f => f.NotificationId == p.Id)
                     select new
                     {
                         Id = p.Id,
                         Messageid = p.Id,
                         TextMessage = p.TextMessage,
                         Value = p.Value,
                         Type = p.Type
                     });


            //var x = _notificationSeenRepository.All().Include(x => x.Notificaioninfo).Where(x => x.LuserId != LuserId).OrderByDescending(x => x.Notificaioninfo.Id).Take(5)
            //.Select(p => new { Id = p.NotificationId, Messageid = p.Id, TextMessage = p.Notificaioninfo.TextMessage , Value =  p.Notificaioninfo.Value , Type = p.Notificaioninfo.Type });


            //        var query =
            //from c in _notificationRepository.All()
            //where !(from o in dc.Orders
            //        select o.CustomerID)
            //       .Contains(c.CustomerID)
            //select c;

            //foreach (var c in query) Console.WriteLine(c);


            //var x = _notificationRepository.All(false).Include(x => x.NotificationSeenList).Where(x => x.LuserId != LuserId).OrderByDescending(x => x.Id).Take(5)
            //.Select(p => new { p.Id, Messageid = p.Id, TextMessage = p.TextMessage , p.Value , p.Type });

            return Json(x);
        }

        [ApiAuthorize]
        public ActionResult SaveUserNotification(int LuserId, int NotificationId)
        {
            try
            {
                var abcd = new NotificationSeenModel();
                abcd.LuserId = LuserId;
                abcd.NotificationId = NotificationId;

                _notificationSeenRepository.InsertApi(abcd);

                return Ok(new { success = true, Id = abcd.Id });
            }
            catch (Exception ex)
            {
                return Ok(false);
            }

        }

        #endregion

        #region Attendance

        [ApiAuthorize]
        [HttpPost]
        public ActionResult AddEmployeeAttendance(int LuserId, string Latitude, string Longitude, string LocationName, string EmpFrontImage, string EmpBackImage)
        {
            try
            {
                var abcd = new EmployeeAttendanceModel();
                abcd.EmployeeLuerId = LuserId;
                abcd.Latitude = Latitude;
                abcd.Longitude = Longitude;
                abcd.PunchDateTime = DateTime.Now;
                abcd.LocationName = LocationName;
                abcd.EmpFrontImageString = EmpFrontImage;
                abcd.EmpBackImageString = EmpBackImage;



                _employeeAttendanceRepository.InsertApi(abcd);





                byte[] bytes = null;
                if (abcd.EmpFrontImageString != null)
                {
                    bytes = Convert.FromBase64String(abcd.EmpFrontImageString);
                }
                if (bytes != null)
                {
                    if (bytes.Length > 0)
                    {
                        Image image;

                        using (MemoryStream ms = new MemoryStream(bytes))
                        {
                            image = Image.FromStream(ms);
                        }
                        var path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/Content/EmpAttendanceImages", abcd.Id.ToString() + ".png");

                        image.Save(path, System.Drawing.Imaging.ImageFormat.Png);
                        abcd.EmpFrontImageString = $"/Content/EmpAttendanceImages/Front_{abcd.Id.ToString() + ".png"}";
                        abcd.EmpBackImageString = $"/Content/EmpAttendanceImages/Back_{abcd.Id.ToString() + ".png"}";

                    }

                }
                else
                {
                    var employeeattendance = _employeeAttendanceRepository.Find(abcd.Id);
                    if (employeeattendance != null)
                        abcd.ImagePathFront = employeeattendance.ImagePathFront;
                    abcd.ImagePathBack = employeeattendance.ImagePathBack;

                }
                _employeeAttendanceRepository.Update(abcd, abcd.Id);











                return Ok(new { success = true, Id = abcd.Id, PunchDateTime = abcd.PunchDateTime, LocationName = abcd.LocationName });
            }
            catch (Exception ex)
            {
                return Ok(false);
            }

        }


        [ApiAuthorize]
        public ActionResult EmployeeAttendanceList(List<EmployeeAttendanceModel> model)
        {
            try
            {

                foreach (var item in model)
                {
                    var abcd = new EmployeeAttendanceModel();
                    abcd.EmployeeLuerId = abcd.LuserId;
                    abcd.Latitude = abcd.Latitude;
                    abcd.Longitude = abcd.Longitude;
                    abcd.PunchDateTime = DateTime.Now;
                    abcd.LocationName = abcd.LocationName;

                    _employeeAttendanceRepository.InsertApi(abcd);
                }

                return Ok(new { success = true, Id = model.LastOrDefault().Id, PunchDateTime = model.LastOrDefault().PunchDateTime, LocationName = model.LastOrDefault().LocationName });

            }
            catch (Exception ex)
            {
                return Ok(false);
            }

        }


        public class EmployeeAttendance
        {
            public string? EmployeeName { get; set; }
            public string? PunchDate { get; set; }
            public string? InTime { get; set; }
            public string? OutTime { get; set; }
            public string? LocationName { get; set; }
            public string? Status { get; set; }
            public string? Color { get; set; }
            public string? Remarks { get; set; }


        }


        [ApiAuthorize]
        public List<SelectListItem> GetEmployeeDropdown()
        {////for sales list 
            //var ComId = HttpContext.Session.GetInt32("ComId");
            var UserId = HttpContext.Session.GetInt32("UserId");
            var userrole = HttpContext.Session.GetString("UserRole") ?? "";

            //var AllData = new SelectList(new List<SelectListItem> { new SelectListItem {Text = "ALL", Value = null} }, "Value", "Text").FirstOrDefault();
            var AllData = new SelectListItem { Text = "ALL", Value = null };

            if (userrole.ToString().ToLower().Contains("admin"))
            {
                var x = _userAccountRepository.GetAllForDropDown().ToList();
                x.Add(AllData);
                return x.OrderBy(x => x.Value).ToList();
            }
            else
            {
                var x = _userAccountRepository.GetAllForDropDown().Where(x => x.Value == UserId.ToString()).ToList();
                x.Add(AllData);
                return x.OrderBy(x => x.Value).ToList();
            }

        }

        [ApiAuthorize]
        [HttpGet]
        public IActionResult AttendanceReport(string EmpId, string FromDate, string ToDate, int IsLocation = 0, string format = "PDF", int isfile = 0)
        {

            HttpContext.Session.SetString("ReportType", format);

            var weburl = Request.Host.Value;
            //ViewBag.weburl = weburl.Trim();

            //string weburl = "pqstec.com";//Config.GetSection("host").Value;


            Atrai.Model.AppData.DefaultConnectionString = Config.GetConnectionString("DefaultConnection");

            var company = _companyRepository.All().Where(x => x.comWeb.ToLower().Contains(weburl.ToLower().Trim())).FirstOrDefault();

            if (company != null)
            {
                HttpContext.Session.SetInt32("ComId", company.Id);
            }

            //var UserId = HttpContext.Session.GetInt32("UserId");
            var ComId = HttpContext.Session.GetInt32("ComId");
            //weburl = HttpContext.Session.GetString("weburl"); //"https://www.pqstec.com/InvoiceApps";//  HttpContext.Session.GetString("weburl"); 
            //var ReportStyle = _storeSettingRepository.All().Include(x => x.ReportStyle).Select(x => x.ReportStyle.ReportStyleName).FirstOrDefault(); //HttpContext.Session.GetString("SalesReportStyle");

            string reportname = "rptJobCard";
            var filename = "JobCard_";



            HttpContext.Session.SetString("ReportQuery", "Exec [rptJobCard] '" + EmpId + "','" + ComId + "','" + FromDate + "','" + ToDate + "','" + IsLocation + "', '" + weburl + "'");
            HttpContext.Session.SetString("ReportPath", "~/ReportViewer/Attendance/" + reportname + ".rdlc");
            HttpContext.Session.SetString("PrintFileName", filename.Replace(".", "").Replace(" ", "").Replace(",", "").Replace("\"", ""));


            //return RedirectToAction("Index", "ReportViewer");
            return RedirectToAction("Index", "ReportViewer", new { reporttype = format, isfile = isfile });
        }


        [ApiAuthorize]
        public IActionResult GetEmployeeAttendanceList(string EmpId, string FromDate, string ToDate, int IsLocation = 0)
        {
            try
            {
                var UserId = HttpContext.Session.GetInt32("UserId");
                var ComId = HttpContext.Session.GetInt32("ComId");
                Atrai.Model.AppData.DefaultConnectionString = Config.GetConnectionString("DefaultConnection");
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


                var query = $"Exec EmployeeAttendanceList '{ComId}','{EmpId}','{FromDate}','{ToDate}','{IsLocation}'";



                SqlParameter[] sqlParameter = new SqlParameter[5];
                sqlParameter[0] = new SqlParameter("@comid", ComId);
                sqlParameter[1] = new SqlParameter("@luserid", EmpId);
                sqlParameter[2] = new SqlParameter("@fromdate", FromDate);
                sqlParameter[3] = new SqlParameter("@todate", ToDate);
                sqlParameter[4] = new SqlParameter("@islocation", IsLocation);

                List<EmployeeAttendance> AttendanceList = Helper.ExecProcMapTList<EmployeeAttendance>("EmployeeAttendanceList", sqlParameter).ToList();



                //ViewBag.EmployeeAttedance = attendancelist;


                // var AttendanceList = _employeeAttendanceRepository.All().Where(x=>x.EmployeeLuerId == EmpId)
                //List<EmployeeAttendance> AttendanceList = _employeeAttendanceRepository.All()
                //    .Where(x => x.LuserId == EmpId && x.PunchDateTime.Date >= dtFrom && x.PunchDateTime.Date <= dtTo)
                //    .Include(x => x.UserAccountList)
                //    .GroupBy(s => new { s.UserAccountList.Name, s.PunchDateTime.Date })
                //    .Select(s => new EmployeeAttendance {
                //        EmployeeName = s.Key.Name,
                //        PunchDate = s.Key.Date.ToString("dd-MMM-yy"), //s.Min(m => m.PunchDateTime).Date.ToString("dd-MMM-yy"),
                //        InTime = s.Min(m => m.PunchDateTime).TimeOfDay.ToString(),
                //        OutTime = s.Max(m => m.PunchDateTime).TimeOfDay.ToString()
                //    }).ToList();

                return Ok(new { success = true, AttendanceList });

            }
            catch (Exception ex)
            {
                return Ok(false);
            }

        }


        #endregion

        #region reporting ledger and stock 

        [ApiAuthorize]
        public ActionResult SubsidiaryLedger(int Id, string Type, string FromDate, string ToDate, string format = "PDF", int isfile = 0)
        {
            HttpContext.Session.SetString("ReportType", format);
            string weburl = Config.GetSection("host").Value;

            Atrai.Model.AppData.DefaultConnectionString = Config.GetConnectionString("DefaultConnection");

            var UserId = HttpContext.Session.GetInt32("UserId");
            var ComId = HttpContext.Session.GetInt32("ComId");


            var ReportStyle = _storeSettingRepository.All().Include(x => x.SalesReportStyle).Select(x => x.SalesReportStyle.ReportStyleName).FirstOrDefault(); //HttpContext.Session.GetString("SalesReportStyle");

            var reportname = "rptTransactionLedger";
            FromDate = "1-jan-2020";
            ToDate = "31-Dec-2023";

            string filename = "";

            if (Type == "Supplier")
            {
                filename = _supplierRepository.All().Where(x => x.Id == Id).Select(x => x.SupplierName).Single();
            }
            else if (Type == "Customer")
            {
                filename = _customerRepository.All().Where(x => x.Id == Id).Select(x => x.Name).Single();
            }
            else if (Type == "Account")
            {
                filename = _accountHeadRepository.All().Where(x => x.Id == Id).Select(x => x.AccName).Single();
            }
            else if (Type == "Transaction")
            {
                filename = _transactionRepository.All().Where(x => x.Id == Id).Select(x => x.TransactionCode).Single();
                reportname = "rptShowVoucher_Journal";

                HttpContext.Session.SetString("ReportPath", "~/ReportViewer/Accounts/" + reportname + ".rdlc");
                HttpContext.Session.SetString("ReportQuery", "Exec Acc_rptVoucher_Transaction '" + ComId + "' ,  " + Id + "");
                var xyz = HttpContext.Session.GetString("ReportQuery");


                HttpContext.Session.SetString("PrintFileName", filename.Replace(".", "").Replace(" ", "").Replace(",", "").Replace("\"", ""));
                return RedirectToAction("Index", "ReportViewer", new { reporttype = format, isfile = isfile });

            }
            //reportname = "rptTransactionLedger";
            filename = "Ledger_From_" + FromDate + "To_" + ToDate;
            HttpContext.Session.SetString("ReportQuery", "Exec Accounts_LedgerList '" + ComId + "','" + Id + "',0,'" + weburl + "','" + FromDate + "', '" + ToDate + "' ,'" + Type + "' ");



            var abcd = HttpContext.Session.GetString("ReportQuery");
            HttpContext.Session.SetString("ReportPath", "~/ReportViewer/Accounts/" + reportname + ".rdlc");
            HttpContext.Session.SetString("PrintFileName", filename.Replace(".", "").Replace(" ", "").Replace(",", "").Replace("\"", ""));
            //HttpContext.Session.SetString("ReportType", rptFormat);



            //return RedirectToAction("Index", "ReportViewer");
            return RedirectToAction("Index", "ReportViewer", new { reporttype = format, isfile = isfile });
        }



        [ApiAuthorize]
        public ActionResult StockProductList(string CategoryId, string WarehouseId, string FromDate, string ToDate, string format = "PDF", int isfile = 0)
        {
            HttpContext.Session.SetString("ReportType", format);
            string weburl = Config.GetSection("host").Value;

            Atrai.Model.AppData.DefaultConnectionString = Config.GetConnectionString("DefaultConnection");

            var UserId = HttpContext.Session.GetInt32("UserId");
            var ComId = HttpContext.Session.GetInt32("ComId");


            FromDate = "1-jan-2020";
            ToDate = "31-Dec-2023";

            string filename = "";



            var reportname = "rptProductList";
            filename = "Product_List_" + DateTime.Now.Date;
            HttpContext.Session.SetString("ReportQuery", "Exec Inv_rptProductList '" + ComId + "', '" + CategoryId + "' ,'" + WarehouseId + "' , 1 ");
            HttpContext.Session.SetString("ReportPath", "~/ReportViewer/Inventory/" + reportname + ".rdlc");
            HttpContext.Session.SetString("PrintFileName", filename.Replace(".", "").Replace(" ", "").Replace(",", "").Replace("\"", ""));
            //HttpContext.Session.SetString("ReportType", rptFormat);



            //return RedirectToAction("Index", "ReportViewer");
            return RedirectToAction("Index", "ReportViewer", new { reporttype = format, isfile = isfile });
        }


        #endregion

        #region Supplier

        [HttpGet]
        [ApiAuthorize]
        public JsonResult GetSupplierList(int pageNo = 1, decimal pageSize = 10, string searchquery = "")
        //public List<SupplierResultList> GetSupplierList()
        {
            try
            {
                var Suppliers = _supplierRepository.All();//.Take(30);//.Include(x=>x.vUnit).Include(x=>x.Category);.Where(x => x.ComId == 1)

                if (searchquery?.Length > 1)
                {
                    Suppliers = Suppliers.Where(x => x.SupplierName.ToLower().Contains(searchquery.ToLower()) || x.PrimaryAddress.ToLower().Contains(searchquery.ToLower()) || x.Phone.ToLower().Contains(searchquery.ToLower()));
                }



                decimal TotalRecordCount = Suppliers.Count();
                var PageCountabc = decimal.Parse((TotalRecordCount / pageSize).ToString());
                var PageCount = Math.Ceiling(PageCountabc);
                decimal skip = (pageNo - 1) * pageSize;
                // Get total number of records
                int total = Suppliers.Count();


                var query = from e in Suppliers//.Where(x => x.Id > 0 && x.ComId == ComId).OrderByDescending(x => x.Id)

                            select new SupplierResultList
                            {
                                Id = e.Id,
                                Name = e.SupplierName,
                                Email = e.Email,
                                Address = e.PrimaryAddress,/////Address
                                PrimaryAddress = e.PrimaryAddress,/////Address
                                SecoundaryAddress = e.SecoundaryAddress,/////Address
                                SupplierCode = e.SupplierCode,
                                Notes = e.Notes,
                                Phone = e.Phone,
                                SupType = e.SupType,
                                ParentSupplier = e.Suppliers.SupplierName,




                                TotalDue =
                                (decimal)e.OpBalance
                                + e.AccountsDailyTransaction.Where(x => x.TransactionType == "System Purchase").Sum(x => x.TransactionAmount)
                                - e.AccountsDailyTransaction.Where(x => x.TransactionType == "System Purchase Return").Sum(x => x.TransactionAmount)

                                - e.AccountsDailyTransaction.Where(x => x.TransactionType.Contains("Paid")).Sum(x => x.TransactionAmount)
                                //- e.AccountsDailyTransaction.Where(x => x.TransactionType.Contains("Received") && !x.TransactionCategory.Contains("SupplierDiscount")).Sum(x => x.TransactionAmount)
                                - e.AccountsDailyTransaction.Where(x => x.TransactionCategory.Contains("SupplierDiscount")).Sum(x => x.TransactionAmount),



                                LastPurchaseDate = e.Purchase.OrderByDescending(x => x.Id).FirstOrDefault().PurchaseDate.ToString("dd-MMM-yy") ?? "",
                                LastInvoiceNo = e.Purchase.OrderByDescending(x => x.Id).FirstOrDefault().PurchaseCode ?? "",
                                LastPurchaseProduct = e.Purchase.OrderByDescending(x => x.Id).FirstOrDefault().Items.OrderByDescending(x => x.Id).FirstOrDefault().Product.Name ?? "",




                                TotalPurchaseValue = e.AccountsDailyTransaction.Where(x => x.TransactionType == "System Purchase").Sum(x => x.TransactionAmount),
                                TotalPurchaseReturnValue = e.AccountsDailyTransaction.Where(x => x.TransactionType == "System Purchase Return").Sum(x => x.TransactionAmount),
                                TotalAmountBack = e.AccountsDailyTransaction.Where(x => x.TransactionType.Contains("Received")).Sum(x => x.TransactionAmount),
                                TotalPayment = e.AccountsDailyTransaction.Where(x => x.TransactionType.Contains("Paid")).Sum(x => x.TransactionAmount),





                                //TotalPurchaseValue = e.AccountsDailyTransaction.Where(x => x.TransactionType == "System Purchase").Sum(x => x.TransactionAmount),
                                //TotalPurchaseReturnValue = e.AccountsDailyTransaction.Where(x => x.TransactionType == "System Purchase Return").Sum(x => x.TransactionAmount),
                                //TotalPayment = e.AccountsDailyTransaction.Where(x => x.TransactionType.Contains("Paid")).Sum(x => x.TransactionAmount),
                                //TotalAmountBack = e.AccountsDailyTransaction.Where(x => x.TransactionType.Contains("Received")).Sum(x => x.TransactionAmount),
                                //TotalDue = (decimal)e.OpBalance + e.AccountsDailyTransaction.Where(x => x.TransactionType == "System Purchase").Sum(x => x.TransactionAmount) - e.AccountsDailyTransaction.Where(x => x.TransactionType == "System Purchase Return").Sum(x => x.TransactionAmount) - e.AccountsDailyTransaction.Where(x => x.TransactionType.Contains("Paid")).Sum(x => x.TransactionAmount) + e.AccountsDailyTransaction.Where(x => x.TransactionType.Contains("Received")).Sum(x => x.TransactionAmount),
                                //LastPurchaseDate = e.Purchase.OrderByDescending(x => x.Id).FirstOrDefault().PurchaseDate.ToString("dd-MMM-yy") ?? "",
                                //LastInvoiceNo = e.Purchase.OrderByDescending(x => x.Id).FirstOrDefault().PurchaseCode ?? "",
                                //LastPurchaseProduct = e.Purchase.OrderByDescending(x => x.Id).FirstOrDefault().Items.OrderByDescending(x => x.Id).FirstOrDefault().Product.Name ?? "",

                            };

                //if (Status == "Due")
                //{
                //    query = query.Where(x => x.TotalDue > 0);
                //}


                var abcd = query.OrderBy(x => x.Id).Skip(int.Parse(skip.ToString())).Take(int.Parse(pageSize.ToString())).ToList();// Take(50);
                var pageinfo = new PagingInfo();
                pageinfo.PageCount = int.Parse(PageCount.ToString());
                pageinfo.PageNo = pageNo;
                pageinfo.PageSize = int.Parse(pageSize.ToString());
                pageinfo.TotalRecordCount = int.Parse(TotalRecordCount.ToString());


                //return  abcd;
                return Json(new { Success = 1, error = false, SupplierList = abcd, PageInfo = pageinfo });


                //List<SupplierResultList> abcd = query.ToList();

                //return abcd;

                //return Json(abcd);

            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        [ApiAuthorize]
        public JsonResult GetSupplier(int SupplierId)
        {
            try
            {
                var singleSupplier = _supplierRepository.All(false).Where(x => x.Id == SupplierId)
                    .Select(x => new
                    {
                        x.Id,
                        Name = x.SupplierName,
                        x.PrimaryAddress, // Address
                        x.SecoundaryAddress,
                        x.City,
                        x.Phone,
                        PostalCode = "",
                        x.Notes,
                        x.SupParentId,
                        x.Email,
                        x.CreateDate,
                        x.SupType,
                        x.LuserId
                    }).FirstOrDefault();

                return Json(singleSupplier);

            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        [HttpPost]
        [ApiAuthorize]
        public ActionResult CreateSupplier(SupplierModel model)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    //if (ModelState.IsValid)
                    //{
                    if (model.Id > 0)
                    {
                        _supplierRepository.UpdateApi(model, model.Id);
                    }
                    else
                    {
                        _supplierRepository.InsertApi(model);
                    }

                    return Ok(true);
                    //}
                    //return Ok(false);
                }
                catch (Exception x)
                {
                    Console.WriteLine(x.Message);
                    return Ok(false);

                }
            }
            else
            {
                return Ok(false);
            }

        }


        [ApiAuthorize]
        public List<SelectListItem> GetSupplierGroupDropdown()
        {
            var x = _supplierRepository.GetAllForDropDown().ToList();
            return x;
        }

        [ApiAuthorize]
        public List<SelectListItem> GetSupplierTypeDropdown()
        {
            var datalist = new SelectList(
                   new List<SelectListItem>
                   {
            new SelectListItem {Text = "Ledger", Value = "L"},
            new SelectListItem {Text = "Group", Value = "G"},
                   }, "Value", "Text");

            var x = datalist.ToList();
            return x;
        }

        [ApiAuthorize]
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
                        x.LuserId
                    }).FirstOrDefault();

                return Json(singleSupplier);

            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        [ApiAuthorize]

        public ActionResult DeleteSupplier(int SupplierId)
        {
            try
            {
                var response = _supplierRepository.Find(SupplierId);

                if (response != null) _supplierRepository.Delete(response);
                else if (response == null) return BadRequest(new { message = "Supplier information is not available" });

                //Ok(false);

                return Ok(true);

            }
            catch (Exception x)
            {
                Console.WriteLine(x.Message);
                return BadRequest(new { message = "Something Wrong" });
            }
        }



        #endregion

        #region TaskToDo



        [ApiAuthorize]
        public List<SelectListItem> GetTaskToDoDropdown(string Id = "")
        {
            var x = _taskToDoRepository.GetAllForDropDown().Where(x => x.Value != Id).ToList();
            return x;
        }



        [ApiAuthorize]
        public List<SelectListItem> GetColorDoDropdown()
        {
            var x = _colorRepository.GetAllForDropDown().ToList();
            return x;
        }

        //[ApiAuthorize]
        //public JsonResult GetTaskToDoList(string FromDate , string ToDate , bool IsComplete)
        //{
        //    DateTime dtFrom = Convert.ToDateTime(DateTime.Now.Date);
        //    DateTime dtTo = Convert.ToDateTime(DateTime.Now.Date);

        //    if (FromDate == null || FromDate == "")
        //    {
        //    }
        //    else
        //    {
        //        dtFrom = Convert.ToDateTime(FromDate);
        //    }
        //    if (ToDate == null || ToDate == "")
        //    {
        //    }
        //    else
        //    {
        //        dtTo = Convert.ToDateTime(ToDate);
        //    }

        //    var x = _taskToDoRepository.All()//.Include(x=>x.ParentTaskToDo)
        //        .Where(p => (p.InputDate >= dtFrom && p.InputDate <= dtTo))
        //        .Where(x => x.IsComplete == IsComplete)
        //        .OrderByDescending(x => x.Id)

        //    .Select(p => new {
        //        p.Id,
        //        p.TaskTitle,
        //        p.TaskDetails,
        //        p.TaskRemarks,
        //        p.InputDate,
        //        p.ExpiryDate,
        //        p.CompleteDate,
        //        p.TaskPercentage,
        //        p.IsComplete,
        //        p.LuserId,
        //        p.AssaignToPerson,
        //        ParentTaskToDo = new { 

        //        }
        //    });
        //    return Json(x);
        //}




        [ApiAuthorize]
        public JsonResult GetTaskToDoList(string FromDate, string ToDate, bool IsComplete)
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
                dtFrom = Convert.ToDateTime(FromDate.ToString());
            }
            if (ToDate == null || ToDate == "")
            {
            }
            else
            {
                dtTo = Convert.ToDateTime(ToDate);
            }

            //Microsoft.Extensions.Primitives.StringValues y = "";
            ////var x = Request.Form.TryGetValue("search[value]", out y);


            var tasklist = _taskToDoRepository.All().Where(x => x.TaskToDoParentId == null && x.LuserId == sessionLuserId);

            if (IsComplete == true)
            {
                ////var tasklist = _taskToDoRepository.All().Where(x => x.TaskToDoParentId == null && x.IsComplete == IsComplete && x.LuserId == sessionLuserId);
                ///
                tasklist = tasklist.Where(x => x.TaskPercentage == 100).Where(x => x.InputDate >= dtFrom && x.InputDate <= dtTo);


            }
            else
            {
                tasklist = tasklist.Where(x => x.TaskPercentage < 100);

                //var tasklist = _taskToDoRepository.All().Where(x => x.TaskToDoParentId == null && x.IsComplete == IsComplete && x.LuserId == sessionLuserId);

            }




            //if (y.ToString().Length > 0)
            //{


            //}
            //else
            //{
            //    tasklist = tasklist.Where(p => (p.CreateDate >= dtFrom && p.CreateDate <= dtTo));
            //}



            var query = from e in tasklist.Include(x => x.ParentTaskToDo)
                        select new
                        {
                            e.Id,
                            e.TaskTitle,
                            e.TaskDetails,
                            e.TaskRemarks,
                            e.InputDate,
                            e.ExpiryDate,
                            e.CompleteDate,
                            e.TaskPercentage,
                            e.Amount,
                            e.IsComplete,
                            e.LuserId,
                            e.AssaignToPerson,
                            e.TaskToDoParentId,
                            e.TaskColour,
                            //ParentTaskTitle = e.ParentTaskToDo.TaskTitle,
                            SubTaskList = e.SubTaskList.ToList()
                            .Select(x => new
                            {
                                x.Id,
                                x.TaskTitle,
                                x.TaskDetails,
                                x.TaskRemarks,
                                x.InputDate,
                                x.ExpiryDate,
                                x.CompleteDate,
                                x.TaskPercentage,
                                x.Amount,
                                x.IsComplete,
                                x.LuserId,
                                x.AssaignToPerson,
                                x.TaskToDoParentId,
                                x.TaskColour
                            }
                            )
                            //ParentTask = e.ParentTaskToDo (x => new {
                            //    x.Id,
                            //    x.TaskDetails,
                            //    x.TaskRemarks,
                            //    x.InputDate,
                            //    x.ExpiryDate,
                            //    x.CompleteDate,
                            //    x.TaskPercentage,
                            //    x.IsComplete,
                            //    x.LuserId,
                            //    x.AssaignToPerson
                            //}).ToList()
                        };



            var abcd = query.ToList();

            return Json(abcd);

            //var parser = new Parser<SalesResultList>(Request.Form, query);

            //return Json(parser.Parse());


        }

        [HttpPost]
        [ApiAuthorize]
        public ActionResult CreateTaskToDo([FromBody] TaskToDoModel model)
        {
            var errors = ModelState.Where(x => x.Value.Errors.Any())
            .Select(x => new { x.Key, x.Value.Errors });

            if (ModelState.IsValid)
            {
                try
                {
                    //if (ModelState.IsValid)
                    //{
                    if (model.Id > 0)
                    {
                        _taskToDoRepository.UpdateApi(model, model.Id);
                    }
                    else
                    {
                        model.InputDate = DateTime.Now.Date;
                        _taskToDoRepository.InsertApi(model);

                    }


                    if (model.TaskToDoParentId == null)
                    {
                        var abc = _taskToDoRepository.All().Where(x => x.Id == model.Id).Include(x => x.SubTaskList).FirstOrDefault();
                        int totalpercentage = abc.SubTaskList.Sum(x => x.TaskPercentage);
                        var totalcount = abc.SubTaskList.Count();
                        if (totalcount > 0)
                        {
                            abc.TaskPercentage = Convert.ToInt32((totalpercentage / (totalcount)));
                            if (abc.TaskPercentage > 95)
                            {
                                abc.IsComplete = true;
                            }
                            else
                            {
                                abc.IsComplete = false;
                            }
                            _taskToDoRepository.UpdateApi(abc, abc.Id);
                        }

                        var TaskToDo = _taskToDoRepository.All().Where(x => x.Id == abc.Id).Include(x => x.ParentTaskToDo)
                           .Select(p => new
                           {
                               p.Id,
                               p.TaskTitle,
                               p.TaskDetails,
                               p.TaskRemarks,
                               p.InputDate,
                               p.ExpiryDate,
                               p.CompleteDate,
                               p.TaskPercentage,
                               p.IsComplete,
                               p.LuserId,
                               p.AssaignToPerson,
                               p.TaskToDoParentId,
                               ParentTaskToDo = p.ParentTaskToDo.TaskTitle
                           });

                        return Json(TaskToDo);

                    }
                    else
                    {
                        var abc = _taskToDoRepository.All().Where(x => x.Id == model.TaskToDoParentId).Include(x => x.SubTaskList).FirstOrDefault();
                        int totalpercentage = abc.SubTaskList.Sum(x => x.TaskPercentage);
                        var totalcount = abc.SubTaskList.Count();
                        if (totalcount > 0)
                        {
                            abc.TaskPercentage = Convert.ToInt32((abc.SubTaskList.Sum(x => x.TaskPercentage) / (abc.SubTaskList.Count())));

                            if (abc.TaskPercentage > 95)
                            {
                                abc.IsComplete = true;
                            }
                            else
                            {
                                abc.IsComplete = false;
                            }
                            _taskToDoRepository.UpdateApi(abc, abc.Id);


                            var TaskToDo = _taskToDoRepository.All().Where(x => x.Id == abc.Id).Include(x => x.ParentTaskToDo)
                               .Select(p => new
                               {
                                   p.Id,
                                   p.TaskTitle,
                                   p.TaskDetails,
                                   p.TaskRemarks,
                                   p.InputDate,
                                   p.ExpiryDate,
                                   p.CompleteDate,
                                   p.TaskPercentage,
                                   p.IsComplete,
                                   p.LuserId,
                                   p.AssaignToPerson,
                                   p.TaskToDoParentId,
                                   ParentTaskToDo = p.ParentTaskToDo.TaskTitle
                               });

                            return Json(TaskToDo);

                        }


                    }


                    //return Json(true);
                    return Ok(true);
                    //}
                    //return Ok(false);
                }
                catch (Exception x)
                {
                    Console.WriteLine(x.Message);
                    return Ok(false);

                }
            }
            else
            {
                return Ok(false);
            }

        }

        [HttpGet]
        [ApiAuthorize]
        public JsonResult GetSingleTaskToDo(int TaskToDoId)
        {
            var TaskToDo = _taskToDoRepository.All().Where(x => x.Id == TaskToDoId).Include(x => x.ParentTaskToDo)
                .Select(p => new
                {
                    p.Id,
                    p.TaskTitle,
                    p.TaskDetails,
                    p.TaskRemarks,
                    p.InputDate,
                    p.ExpiryDate,
                    p.CompleteDate,
                    p.TaskPercentage,
                    p.IsComplete,
                    p.LuserId,
                    p.AssaignToPerson,
                    p.TaskToDoParentId,
                    ParentTaskToDo = p.ParentTaskToDo.TaskTitle
                });

            return Json(TaskToDo);
        }
        [ApiAuthorize]
        public ActionResult DeleteTaskToDo(int TaskToDoId)
        {
            try
            {
                var response = _taskToDoRepository.Find(TaskToDoId);

                if (response != null) _taskToDoRepository.Delete(response);
                else if (response == null) return BadRequest(new { message = "Task / ToDo information Can not be Deleted" });

                //Ok(false);

                return Ok(true);

            }
            catch (Exception x)
            {
                Console.WriteLine(x.Message);
                return BadRequest(new { message = "Something Wrong" });
            }
        }
        #endregion

        #region Text_Animation


        [ApiAuthorize]
        public JsonResult GetMobileTextAnimation()
        {
            var x = _mobileTextAnimationRepository.All().Where(s => s.IsSeen == false)
                      .Select(p => new
                      {
                          p.Id,
                          p.TextMessageOne,
                          p.TextMessageTwo,
                          p.TextMessageThree,
                          p.Type,
                          p.LuserId,
                          p.TypeColor,
                          p.TextMessageOneColor,
                          p.TextMessageTwoColor,
                          p.TextMessageThreeColor,
                          p.TypeSize,
                          p.TextMessageOneSize,
                          p.TextMessageTwoSize,
                          p.TextMessageThreeSize

                      }).ToList();


            return Json(x);
        }

        #endregion

        #region ShortLinkModel
        //[ApiAuthorize]
        //public JsonResult GetShortLinkModelList()
        //{
        //    var x = _shortLinkRepository.All().Include(x => x.Categories).OrderByDescending(x => x.Id)
        //    .Select(p => new {
        //        Id = p.Id,
        //        Name = p.Name,
        //        Description = p.Description,
        //        ParentShortLinkModel = p.Categories.Name,
        //        p.ShortLinkModelParentId,
        //        p.CreateDate,
        //        p.LuserId
        //    });
        //    return Json(x);
        //}

        //[ApiAuthorize]
        //public List<SelectListItem> GetShortLinkModelDropdown()
        //{
        //    var x = _shortLinkRepository.GetAllForDropDown().ToList();
        //    return x;
        //}

        //[HttpGet]
        //public ActionResult AddShortLinkModel()
        //{
        //    ViewBag.ActionType = "Create";
        //    return View();
        //}

        //[HttpPost]
        //[ApiAuthorize]
        //public ActionResult CreateShortLinkModel(ShortLinkModelModel model)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        try
        //        {
        //            //if (ModelState.IsValid)
        //            //{
        //            if (model.Id > 0)
        //            {
        //                _shortLinkRepository.UpdateApi(model, model.Id);
        //            }
        //            else
        //            {
        //                _shortLinkRepository.InsertApi(model);
        //            }

        //            return Ok(true);
        //            //}
        //            //return Ok(false);
        //        }
        //        catch (Exception x)
        //        {
        //            Console.WriteLine(x.Message);
        //            return Ok(false);

        //        }
        //    }
        //    else
        //    {
        //        return Ok(false);
        //    }

        //}

        [HttpGet]
        //[ApiAuthorize]
        public JsonResult GetShortUrlLink(int shortlinkid)
        {



            var activationexpiredate = _shortLinkRepository.All(false)
                .Include(x => x.UserAccountList)
                .ThenInclude(x => x.UserActivationList)
                .Where(x => x.Id == shortlinkid).FirstOrDefault().UserAccountList.UserActivationList.OrderByDescending(x => x.Id).FirstOrDefault().ActiveToDate;

            if (activationexpiredate >= DateTime.Now.Date)
            {
                var ShortLinkModel = _shortLinkRepository.All(false).Where(x => x.Id == shortlinkid)
                    .Select(p => new
                    {
                        Id = p.Id,
                        p.Url,
                        p.CreateDate,
                        p.LuserId,
                        p.ComId
                    }).FirstOrDefault();

                //var ComId = HttpContext.Session.GetInt32("ComId");
                //var UserId = HttpContext.Session.GetInt32("UserId");

                string userIpAddress = HttpContext.Connection.RemoteIpAddress.ToString();

                var abcd = new ShortLinkHitModel();
                //abcd.LuserId = ShortLinkModel.LuserId;
                abcd.ShortLinkId = shortlinkid;


                //abcd.LuserId = int.Parse(UserId.ToString());
                //abcd.ComId = int.Parse(ComId.ToString());

                //abcd.LoginDate = DateTime.Now.Date;
                //abcd.LoginTime = DateTime.Now;

                //abcd.Latitude = Latitude;
                //abcd.Longitude = Longitude;


                //abcd.ComId = ShortLinkModel.ComId;
                _shortLinkHitRepository.Insert(abcd);


                var userAgent = HttpContext.Request.Headers["User-Agent"];

                //if (userAgent != null)
                //{
                string uaString = Convert.ToString(userAgent[0]);

                var uaParser = Parser.GetDefault();

                ClientInfo c = uaParser.Parse(uaString);
                //var devicetype = c.Device.Family;

                var devicetype = "";
                if (userAgent == true)
                {
                    devicetype = "Mobile";
                }
                else
                {
                    devicetype = "Computer";
                }



                abcd.DeviceType = devicetype;
                abcd.IPAddress = userIpAddress;
                abcd.Platform = c.OS.Family;
                abcd.LongString = c.String;
                //abcd.UserName = Environment.UserName;

                //abcd.PcName = Environment.MachineName; // DetermineCompName(request.UserHostName);
                abcd.WebBrowserName = c.UA.Family;
                //abcd.MacAddress = "";// c.String;//request.UserHostAddress;
                abcd.WebLink = HttpContext.Request.Headers["Referer"];


                _shortLinkHitRepository.Update(abcd, abcd.Id);

                //}

                return Json(ShortLinkModel);
            }
            else
            {
                var ShortLinkModel = new ShortLinkModel();
                return Json(ShortLinkModel);
            }
        }

        [HttpGet]
        //[ApiAuthorize]
        public JsonResult UpdateClickedCount(int shortlinkid)
        {
            var activationexpiredate = _shortLinkRepository.All(false)
                .Include(x => x.UserAccountList)
                .ThenInclude(x => x.UserActivationList)
                .Where(x => x.Id == shortlinkid).FirstOrDefault().UserAccountList.UserActivationList.OrderByDescending(x => x.Id).FirstOrDefault().ActiveToDate;

            if (activationexpiredate >= DateTime.Now.Date)
            {
                //var ShortLinkModel = _shortLinkRepository.All(false).Where(x => x.Id == shortlinkid)
                //    .Select(p => new
                //    {
                //        Id = p.Id,
                //        p.Url,
                //        p.CreateDate,
                //        p.LuserId,
                //        p.ComId
                //    }).FirstOrDefault();

                //var ComId = HttpContext.Session.GetInt32("ComId");
                //var UserId = HttpContext.Session.GetInt32("UserId");

                string userIpAddress = HttpContext.Connection.RemoteIpAddress.ToString();

                var abcd = new ShortLinkHitModel();
                //abcd.LuserId = ShortLinkModel.LuserId;
                abcd.ShortLinkId = shortlinkid;


                //abcd.LuserId = int.Parse(UserId.ToString());
                //abcd.ComId = int.Parse(ComId.ToString());

                //abcd.LoginDate = DateTime.Now.Date;
                //abcd.LoginTime = DateTime.Now;

                //abcd.Latitude = Latitude;
                //abcd.Longitude = Longitude;


                //abcd.ComId = ShortLinkModel.ComId;


                var userAgent = HttpContext.Request.Headers["User-Agent"];

                //if (userAgent != null)
                //{
                string uaString = Convert.ToString(userAgent[0]);

                var uaParser = Parser.GetDefault();

                ClientInfo c = uaParser.Parse(uaString);
                //var devicetype = c.Device.Family;

                var devicetype = "";
                if (userAgent == true)
                {
                    devicetype = "Mobile";
                }
                else
                {
                    devicetype = "Computer";
                }



                abcd.DeviceType = devicetype;
                abcd.IPAddress = userIpAddress;
                abcd.Platform = c.OS.Family;
                abcd.LongString = c.String;
                //abcd.UserName = Environment.UserName;

                //abcd.PcName = Environment.MachineName; // DetermineCompName(request.UserHostName);
                abcd.WebBrowserName = c.UA.Family;
                //abcd.MacAddress = "";// c.String;//request.UserHostAddress;
                abcd.WebLink = HttpContext.Request.Headers["Referer"];

                _shortLinkHitRepository.Insert(abcd);

                // _shortLinkHitRepository.Update(abcd, abcd.Id);


                return Json("success");
            }
            else
            {
                var ShortLinkModel = new ShortLinkModel();
                return Json(ShortLinkModel);
            }
        }
        //[ApiAuthorize]
        //public ActionResult DeleteShortLinkModel(int shortlinkid)
        //{
        //    try
        //    {
        //        var response = _shortLinkRepository.Find(shortlinkid);

        //        if (response != null) _shortLinkRepository.Delete(response);
        //        else if (response == null) return BadRequest(new { message = "ShortLinkModel information Can not be Deleted" });

        //        //Ok(false);

        //        return Ok(true);

        //    }
        //    catch (Exception x)
        //    {
        //        Console.WriteLine(x.Message);
        //        return BadRequest(new { message = "Something Wrong" });
        //    }
        //}
        #endregion

        #region AndroidMenu

        [ApiAuthorize]
        public JsonResult GetAndroidMenuList(int LuserId)
        {
            try
            {
                var UserId = HttpContext.Session.GetInt32("UserId");
                var ComId = HttpContext.Session.GetInt32("ComId");

                var company = _companyRepository.All().Where(x => x.Id == ComId).FirstOrDefault();
                var userdata = _userAccountRepository.All(false).Include(x => x.UserRole).Where(x => x.Id == UserId).FirstOrDefault();

                if (userdata.IsBaseUser == true)
                {
                    var userpermissionmenulist = _androidMenuPermissionRepository.All().Include(x => x.AndroidMenus).Where(x => x.BusinessTypeId == company.BusinessTypeId).OrderBy(x => x.AndroidMenus.DisplayOrder).OrderBy(x => x.AndroidMenus.DisplayOrder);

                    if (userpermissionmenulist == null)
                    {
                        return Json(new { Success = 0, error = true, message = "No Available Permission" });
                    }
                    else
                    {
                        if (userdata.UserRole.RoleName != "Super Admin")
                        {
                            var subscriptionactivationdata = _subscriptionActivationRepository.All().Where(x => x.LuserId == UserId && x.ActiveToDate > DateTime.Now.Date).FirstOrDefault();

                            if (subscriptionactivationdata == null)
                            {
                                //HttpContext.Session.SetInt32("PurchasePackage", 1);
                                return Json(new { Success = 0, error = true, message = "User Subscriptioin Validity Expired" });
                            }
                        }
                        var adminmenulist = userpermissionmenulist
                        .Select(p => new
                        {
                            Id = p.Id,
                            p.AndroidMenus.MenuName,
                            p.AndroidMenus.MenuCaption,

                            p.AndroidMenus.MenuPage,
                            p.AndroidMenus.DisplayOrder,

                            p.AndroidMenus.IconPath,
                            p.AndroidMenus.IconName,

                            p.AndroidMenus.ColorOne,
                            p.AndroidMenus.ColorTwo,
                            p.AndroidMenus.ColorThree,

                            p.AndroidMenus.FontColor,
                            p.AndroidMenus.GradiantStyle,
                            p.AndroidMenus.MenuRemarks,
                            p.AndroidMenus.Radius,

                            IsDisabled = 0

                        });
                        return Json(adminmenulist);
                    }
                    //return RedirectToAction(firstmenu.Menus.ActionName, firstmenu.Menus.ControllerName);
                }
                else
                {
                    var userpermissionmenulist = _androidMenuPermission_DetailsRepository.All().Include(x => x.AndroidMenuPermissionMasters).Include(x => x.AndroidMenus).Where(x => x.AndroidMenuPermissionMasters.LUserIdPermission == UserId).OrderBy(x => x.AndroidMenus.DisplayOrder).ToList();
                    if (userpermissionmenulist == null)
                    {
                        return Json(new { Success = 0, error = true, message = "No Available Permission" });
                    }
                    else
                    {
                        var x = userpermissionmenulist
                        //.Include(x => x.AndroidMenuPermissionMasters).Where(x => x.AndroidMenuPermissionMasters.LUserIdPermission == UserId)
                        ////.Include(x=>x.AndroidMenuPermission_Details)
                        //.Include(x => x.AndroidMenus).OrderBy(x => x.Id)
                        .Select(p => new
                        {
                            Id = p.Id,
                            p.AndroidMenus.MenuName,
                            p.AndroidMenus.MenuCaption,

                            p.AndroidMenus.MenuPage,
                            p.AndroidMenus.DisplayOrder,


                            p.AndroidMenus.IconPath,
                            p.AndroidMenus.IconName,


                            p.AndroidMenus.ColorOne,
                            p.AndroidMenus.ColorTwo,
                            p.AndroidMenus.ColorThree,

                            p.AndroidMenus.FontColor,
                            p.AndroidMenus.GradiantStyle,
                            p.AndroidMenus.MenuRemarks,
                            p.AndroidMenus.Radius,

                            IsDisabled = 0

                        });
                        return Json(x);
                    }

                    //return RedirectToAction(firstmenu.Menus.ActionName, firstmenu.Menus.ControllerName);
                }

                //var x = _androidMenuPermissionRepository.All().Where(x => x.BusinessTypeId == company.BusinessTypeId).OrderBy(x => x.AndroidMenus.MenuPage)

                return Json(new { Success = 0, error = true, message = "No Available Permission" });
            }
            catch (Exception ex)
            {
                return Json(new { Success = 0, error = true, message = ex.Message });

                //throw ex;

            }
        }


        #endregion

        #region Referance
        public JsonResult ProductCodeReferance(string query)
        {
            //var ComId = HttpContext.Session.GetInt32("ComId");
            List<SelectListItem> Referance = new List<SelectListItem>();
            if (query != null)
            {
                var Referancedb = _productRepository.All()
                        .Where(x => (x.Code).ToLower().Contains(query.ToLower())).Take(10)
                        .Select(m => new { ProductCode = m.Code })
                        .Distinct()
                        .ToList();




                if (Referancedb != null)
                {
                    foreach (var x in Referancedb)
                    {
                        Referance.Add(new SelectListItem { Text = x.ProductCode, Value = "0" });

                    }
                }

                return Json(Referance);
            }

            return Json(Referance);

        }
        #endregion

        #region Classes

        public class PagingInfo
        {
            public int PageNo { get; set; }

            public int PageSize { get; set; }

            public int PageCount { get; set; }

            public long TotalRecordCount { get; set; }

        }

        #endregion

        #region Transaction

        #region Receipt&Payment



        //[ApiAuthorize]
        //public JsonResult GetAccountHeadListDropdown(string TransactionType = "All", int? IsReport = 0)
        //{

        //    var sessionLuserId = (HttpContext.Session.GetInt32("UserId"));
        //    var UserId = HttpContext.Session.GetInt32("UserId");
        //    var UserRole = HttpContext.Session.GetString("UserRole") ?? "";
        //    //var AllData = new SelectList(new List<SelectListItem> { new SelectListItem { Text = "ALL", Value = null } }, "Value", "Text").FirstOrDefault();
        //    //var AllData = new SelectListItem { Text = "ALL", Value = null };


        //    //SelectListItem abc = new SelectListItem() { Text = "Please Select", Value = "" };
        //    SelectListItem AllData = new SelectListItem() { Text = "ALL", Value = null };


        //    var warehosuepermission = FromWarehousePermissionRepository.GetAllForDropDown().ToList();
        //    if (warehosuepermission.Count() == 0)
        //    {
        //        warehosuepermission = _warehouseRepository.GetWarehouseLedgerHeadForDropDown().ToList();
        //        if (IsReport == 1)
        //        {
        //            warehosuepermission.Add(AllData);
        //        }
        //    }
        //    //else            //{            //    //x.Append(abc);            //}
        //    ///return warehosuepermission.OrderBy(x => x.Value).ToList();






        //    if (TransactionType == "All")
        //    {
        //        var DebitList = _accountHeadRepository.GetDebitHeadForDropDown().ToList();
        //        var CreditList = _accountHeadRepository.GetCreditHeadForDropDown().ToList();
        //        var CustomerList = _customerRepository.GetCustomerLedgerHeadForDropDown().ToList();
        //        var SupplierList = _customerRepository.GetCustomerLedgerHeadForDropDown().ToList();
        //        var EmployeeList = _customerRepository.GetCustomerLedgerHeadForDropDown().ToList();

        //        var SalesInvoiceList = _customerRepository.GetCustomerLedgerHeadForDropDown().ToList();
        //        var PurchaseInvoiceList = _customerRepository.GetCustomerLedgerHeadForDropDown().ToList();



        //        return Json(new { Success = 1, DebitHeadList = DebitList, CreditHeadList = CreditList, WarehouseList = warehosuepermission.OrderBy(x => x.Value).ToList(), TransactionType = "abc", TransactionCategory = "xyz" });
        //    }
        //    else if (TransactionType == "Customer")
        //    {
        //        var DebitList = _accountHeadRepository.GetDebitHeadForDropDown().ToList();
        //        var CreditList = _accountHeadRepository.GetCreditHeadForDropDown().ToList();
        //        var CustomerList = _customerRepository.GetCustomerLedgerHeadForDropDown().ToList();
        //        var SupplierList = _customerRepository.GetCustomerLedgerHeadForDropDown().Take(0).ToList();
        //        var EmployeeList = _customerRepository.GetCustomerLedgerHeadForDropDown().Take(0).ToList();

        //        return Json(new { Success = 1, DebitHeadList = DebitList, CreditHeadList = CreditList, WarehouseList = warehosuepermission.OrderBy(x => x.Value).ToList(), TransactionType = "abc", TransactionCategory = "xyz", Customer = CustomerList, Supplier = SupplierList, Employee = EmployeeList });
        //    }
        //    else if (TransactionType == "Supplier")
        //    {
        //        var DebitList = _accountHeadRepository.GetDebitHeadForDropDown().ToList();
        //        var CreditList = _accountHeadRepository.GetCreditHeadForDropDown().ToList();
        //        var CustomerList = _customerRepository.GetCustomerLedgerHeadForDropDown().Take(0).ToList();
        //        var SupplierList = _customerRepository.GetCustomerLedgerHeadForDropDown().ToList();
        //        var EmployeeList = _customerRepository.GetCustomerLedgerHeadForDropDown().Take(0).ToList();

        //        return Json(new { Success = 1, DebitHeadList = DebitList, CreditHeadList = CreditList, WarehouseList = warehosuepermission.OrderBy(x => x.Value).ToList(), TransactionType = "abc", TransactionCategory = "xyz", Customer = CustomerList, Supplier = SupplierList, Employee = EmployeeList });
        //    }
        //    else if (TransactionType == "ReceivedFromSupplier")
        //    {
        //        var DebitList = _accountHeadRepository.GetCashBankHeadForDropDown().ToList();
        //        var CreditList = _accountHeadRepository.GetCreditHeadForDropDown().ToList();
        //        var CustomerList = _customerRepository.GetCustomerLedgerHeadForDropDown().Take(0).ToList();
        //        var SupplierList = _customerRepository.GetCustomerLedgerHeadForDropDown().ToList();
        //        var EmployeeList = _customerRepository.GetCustomerLedgerHeadForDropDown().Take(0).ToList();

        //        return Json(new { Success = 1, DebitHeadList = DebitList, CreditHeadList = CreditList, WarehouseList = warehosuepermission.OrderBy(x => x.Value).ToList(), TransactionType = "abc", TransactionCategory = "xyz", Customer = CustomerList, Supplier = SupplierList, Employee = EmployeeList });
        //    }
        //    else if (TransactionType == "PaidToEmployee")
        //    {
        //        var DebitList = _accountHeadRepository.GetLoanAdvanceHeadForDropDown().ToList();
        //        var CreditList = _accountHeadRepository.GetCashBankHeadForDropDown().ToList();
        //        var CustomerList = _customerRepository.GetCustomerLedgerHeadForDropDown().Take(0).ToList();
        //        var SupplierList = _customerRepository.GetCustomerLedgerHeadForDropDown().Take(0).ToList();
        //        var EmployeeList = _customerRepository.GetCustomerLedgerHeadForDropDown().ToList();

        //        return Json(new { Success = 1, DebitHeadList = DebitList, CreditHeadList = CreditList, WarehouseList = warehosuepermission.OrderBy(x => x.Value).ToList(), TransactionType = "abc", TransactionCategory = "xyz", Customer = CustomerList, Supplier = SupplierList, Employee = EmployeeList });
        //    }
        //    else if (TransactionType == "ReceivedFromEmployee")
        //    {
        //        var DebitList = _accountHeadRepository.GetCashBankHeadForDropDown().ToList();
        //        var CreditList = _accountHeadRepository.GetLoanAdvanceHeadForDropDown().ToList();
        //        var CustomerList = _customerRepository.GetCustomerLedgerHeadForDropDown().Take(0).ToList();
        //        var SupplierList = _customerRepository.GetCustomerLedgerHeadForDropDown().Take(0).ToList();
        //        var EmployeeList = _customerRepository.GetCustomerLedgerHeadForDropDown().ToList();

        //        return Json(new { Success = 1, DebitHeadList = DebitList, CreditHeadList = CreditList, WarehouseList = warehosuepermission.OrderBy(x => x.Value).ToList(), TransactionType = "abc", TransactionCategory = "xyz", Customer = CustomerList, Supplier = SupplierList, Employee = EmployeeList });
        //    }
        //    else if (TransactionType == "Expense")
        //    {
        //        var DebitList = _accountHeadRepository.GetExpenseHeadForDropDown().ToList();
        //        var CreditList = _accountHeadRepository.GetCashBankHeadForDropDown().ToList();
        //        var CustomerList = _customerRepository.GetCustomerLedgerHeadForDropDown().Take(0).ToList();
        //        var SupplierList = _customerRepository.GetCustomerLedgerHeadForDropDown().Take(0).ToList();
        //        var EmployeeList = _customerRepository.GetCustomerLedgerHeadForDropDown().Take(0).ToList();

        //        return Json(new { Success = 1, DebitHeadList = DebitList, CreditHeadList = CreditList, WarehouseList = warehosuepermission.OrderBy(x => x.Value).ToList(), TransactionType = "abc", TransactionCategory = "xyz", Customer = CustomerList, Supplier = SupplierList, Employee = EmployeeList });
        //    }
        //    else if (TransactionType == "Income")
        //    {
        //        var DebitList = _accountHeadRepository.GetCashBankHeadForDropDown().ToList();
        //        var CreditList = _accountHeadRepository.GetIncomeHeadForDropDown().ToList();
        //        var CustomerList = _customerRepository.GetCustomerLedgerHeadForDropDown().Take(0).ToList();
        //        var SupplierList = _customerRepository.GetCustomerLedgerHeadForDropDown().Take(0).ToList();
        //        var EmployeeList = _customerRepository.GetCustomerLedgerHeadForDropDown().Take(0).ToList();

        //        return Json(new { Success = 1, DebitHeadList = DebitList, CreditHeadList = CreditList, WarehouseList = warehosuepermission.OrderBy(x => x.Value).ToList(), TransactionType = "abc", TransactionCategory = "xyz", Customer = CustomerList, Supplier = SupplierList, Employee = EmployeeList });
        //    }

        //    else if (TransactionType == "TransactionList")
        //    {
        //        var DebitList = _accountHeadRepository.GetDebitHeadForDropDown().ToList();
        //        var CreditList = _accountHeadRepository.GetCreditHeadForDropDown().ToList();
        //        var CustomerList = _customerRepository.GetCustomerLedgerHeadForDropDown().Take(0).ToList();
        //        var SupplierList = _customerRepository.GetCustomerLedgerHeadForDropDown().ToList();
        //        var EmployeeList = _customerRepository.GetCustomerLedgerHeadForDropDown().Take(0).ToList();
        //        //var WarehouseList = _warehouseRepository.GetWarehouseLedgerHeadForDropDown().ToList();



        //        return Json(new { Success = 1, DebitHeadList = DebitList, CreditHeadList = CreditList, WarehouseList = warehosuepermission.OrderBy(x => x.Value).ToList(), TransactionType = "abc", TransactionCategory = TransactionCategoryList, Customer = CustomerList, Supplier = SupplierList, Employee = EmployeeList });
        //    }
        //    else
        //    {
        //        var DebitList = _accountHeadRepository.GetDebitHeadForDropDown().ToList();
        //        var CreditList = _accountHeadRepository.GetCreditHeadForDropDown().ToList();
        //        return Json(new { Success = 1, DebitHeadList = DebitList, CreditHeadList = CreditList, WarehouseList = warehosuepermission.OrderBy(x => x.Value).ToList(), TransactionType = "abc", TransactionCategory = "xyz" });
        //    }

        //    //return Json(new { Success = 1,  DebitHeadList = x, CreditHeadList = y});



        //}


        [ApiAuthorize]
        public JsonResult GetAccountHeadListDropdown(string TransactionType = "All", int? IsReport = 0)
        {

            var TransactionCategoryList = TransactionCategoryList_New.ToList();

            var sessionLuserId = (HttpContext.Session.GetInt32("UserId"));
            var UserId = HttpContext.Session.GetInt32("UserId");
            var UserRole = HttpContext.Session.GetString("UserRole") ?? "";
            //var AllData = new SelectList(new List<SelectListItem> { new SelectListItem { Text = "ALL", Value = null } }, "Value", "Text").FirstOrDefault();
            //var AllData = new SelectListItem { Text = "ALL", Value = null };


            //SelectListItem abc = new SelectListItem() { Text = "Please Select", Value = "" };
            SelectListItem AllData = new SelectListItem() { Text = "ALL", Value = null };


            var warehosuepermission = FromWarehousePermissionRepository.GetAllForDropDown().ToList();
            if (warehosuepermission.Count() == 0)
            {
                warehosuepermission = _warehouseRepository.GetWarehouseLedgerHeadForDropDown().ToList();
                if (IsReport == 1)
                {
                    warehosuepermission.Add(AllData);
                }
            }
            //else            //{            //    //x.Append(abc);            //}
            ///return warehosuepermission.OrderBy(x => x.Value).ToList();

            var CurrencyList = _countryRepository.GetAllForDropDown().ToList();


            if (TransactionType == "All")
            {
                var DebitList = _accountHeadRepository.GetDebitHeadForDropDown().ToList();
                var CreditList = _accountHeadRepository.GetCreditHeadForDropDown().ToList();
                var CustomerList = _customerRepository.GetCustomerLedgerHeadForDropDown().ToList();
                var SupplierList = _supplierRepository.GetSupplierGroupHeadForDropDown().ToList();
                var EmployeeList = _employeeRepository.GetAllForDropDown().ToList();

                var SalesInvoiceList = _saleRepository.GetAllForDropDown().Take(10).ToList();
                var PurchaseInvoiceList = _purchaseRepository.GetAllForDropDown().Take(10).ToList();

                return Json(new { Success = 1, DebitHeadList = DebitList, CreditHeadList = CreditList, WarehouseList = warehosuepermission.OrderBy(x => x.Value).ToList(), TransactionType = "abc", TransactionCategory = "xyz" });
            }
            else if (TransactionType == "Customer")
            {
                var DebitList = _accountHeadRepository.GetCashBankHeadForDropDown().ToList();
                var CreditList = _accountHeadRepository.GetCustomerReceivableHeadForDropDown().ToList();
                var CustomerList = _customerRepository.GetCustomerLedgerHeadForDropDown().ToList();
                var SupplierList = _supplierRepository.GetSupplierLedgerHeadForDropDown().Take(0).ToList();
                var EmployeeList = _employeeRepository.GetAllForDropDown().Take(0).ToList();
                var Desciption = "Amount Collection from Customer.";

                return Json(new { Success = 1, DebitHeadList = DebitList, CreditHeadList = CreditList, WarehouseList = warehosuepermission.OrderBy(x => x.Value).ToList(), TransactionType = "abc", TransactionCategory = "xyz", Customer = CustomerList, Supplier = SupplierList, Employee = EmployeeList, Desciption = Desciption });
            }
            else if (TransactionType == "Supplier")
            {
                var DebitList = _accountHeadRepository.GetSupplierPayableHeadForDropDown().ToList();
                var CreditList = _accountHeadRepository.GetCashBankHeadForDropDown().ToList();
                var CustomerList = _customerRepository.GetCustomerLedgerHeadForDropDown().Take(0).ToList();
                var SupplierList = _supplierRepository.GetSupplierLedgerHeadForDropDown().ToList();
                var EmployeeList = _employeeRepository.GetAllForDropDown().Take(0).ToList();
                var Desciption = "Amount Paid to Supplier.";

                return Json(new { Success = 1, DebitHeadList = DebitList, CreditHeadList = CreditList, WarehouseList = warehosuepermission.OrderBy(x => x.Value).ToList(), TransactionType = "abc", TransactionCategory = "xyz", Customer = CustomerList, Supplier = SupplierList, Employee = EmployeeList, Desciption = Desciption });
            }
            else if (TransactionType == "ReceivedFromSupplier")
            {
                var DebitList = _accountHeadRepository.GetCashBankHeadForDropDown().ToList();
                var CreditList = _accountHeadRepository.GetCreditHeadForDropDown().ToList();
                var CustomerList = _customerRepository.GetCustomerLedgerHeadForDropDown().Take(0).ToList();
                var SupplierList = _supplierRepository.GetSupplierLedgerHeadForDropDown().ToList();
                var EmployeeList = _employeeRepository.GetAllForDropDown().Take(0).ToList();
                var Desciption = "Amount Received from Supplier.";

                return Json(new { Success = 1, DebitHeadList = DebitList, CreditHeadList = CreditList, WarehouseList = warehosuepermission.OrderBy(x => x.Value).ToList(), TransactionType = "abc", TransactionCategory = "xyz", Customer = CustomerList, Supplier = SupplierList, Employee = EmployeeList, Desciption = Desciption });
            }
            else if (TransactionType == "PaidToEmployee")
            {
                var DebitList = _accountHeadRepository.GetLoanAdvanceHeadForDropDown().ToList();
                var CreditList = _accountHeadRepository.GetCashBankHeadForDropDown().ToList();
                var CustomerList = _customerRepository.GetCustomerLedgerHeadForDropDown().Take(0).ToList();
                var SupplierList = _supplierRepository.GetSupplierLedgerHeadForDropDown().Take(0).ToList();
                var EmployeeList = _employeeRepository.GetAllForDropDown().ToList();
                var Desciption = "Amount Paid To Employee.";
                return Json(new { Success = 1, DebitHeadList = DebitList, CreditHeadList = CreditList, WarehouseList = warehosuepermission.OrderBy(x => x.Value).ToList(), TransactionType = "abc", TransactionCategory = "xyz", Customer = CustomerList, Supplier = SupplierList, Employee = EmployeeList, Desciption = Desciption });
            }
            else if (TransactionType == "ReceivedFromEmployee")
            {
                var DebitList = _accountHeadRepository.GetCashBankHeadForDropDown().ToList();
                var CreditList = _accountHeadRepository.GetLoanAdvanceHeadForDropDown().ToList();
                var CustomerList = _customerRepository.GetCustomerLedgerHeadForDropDown().Take(0).ToList();
                var SupplierList = _supplierRepository.GetSupplierLedgerHeadForDropDown().Take(0).ToList();
                var EmployeeList = _employeeRepository.GetAllForDropDown().ToList();
                var Desciption = "Amount Received from Employee.";

                return Json(new { Success = 1, DebitHeadList = DebitList, CreditHeadList = CreditList, WarehouseList = warehosuepermission.OrderBy(x => x.Value).ToList(), TransactionType = "abc", TransactionCategory = "xyz", Customer = CustomerList, Supplier = SupplierList, Employee = EmployeeList, Desciption = Desciption });
            }
            else if (TransactionType == "Expense")
            {
                var DebitList = _accountHeadRepository.GetExpenseHeadForDropDown().ToList();
                var CreditList = _accountHeadRepository.GetCashBankHeadForDropDown().ToList();
                var CustomerList = _customerRepository.GetCustomerLedgerHeadForDropDown().Take(0).ToList();
                var SupplierList = _supplierRepository.GetSupplierLedgerHeadForDropDown().Take(0).ToList();
                var EmployeeList = _employeeRepository.GetAllForDropDown().Take(0).ToList();
                var Desciption = "Expense Entry.";
                return Json(new { Success = 1, DebitHeadList = DebitList, CreditHeadList = CreditList, WarehouseList = warehosuepermission.OrderBy(x => x.Value).ToList(), TransactionType = "abc", TransactionCategory = "xyz", Customer = CustomerList, Supplier = SupplierList, Employee = EmployeeList, Desciption = Desciption });
            }
            else if (TransactionType == "Income")
            {
                var DebitList = _accountHeadRepository.GetCashBankHeadForDropDown().ToList();
                var CreditList = _accountHeadRepository.GetIncomeHeadForDropDown().ToList();
                var CustomerList = _customerRepository.GetCustomerLedgerHeadForDropDown().Take(0).ToList();
                var SupplierList = _supplierRepository.GetSupplierLedgerHeadForDropDown().Take(0).ToList();
                var EmployeeList = _employeeRepository.GetAllForDropDown().Take(0).ToList();
                var Desciption = "Income Entry.";

                return Json(new { Success = 1, DebitHeadList = DebitList, CreditHeadList = CreditList, WarehouseList = warehosuepermission.OrderBy(x => x.Value).ToList(), TransactionType = "abc", TransactionCategory = "xyz", Customer = CustomerList, Supplier = SupplierList, Employee = EmployeeList, Desciption = Desciption });
            }

            else if (TransactionType == "TransactionList")
            {
                var DebitList = _accountHeadRepository.GetAccountLedgerHeadForDropDown().ToList();//_accountHeadRepository.GetCreditHeadForDropDown().ToList()
                var CreditList = DebitList;
                var CustomerList = _customerRepository.GetCustomerLedgerHeadForDropDown().ToList();
                var SupplierList = _supplierRepository.GetSupplierLedgerHeadForDropDown().ToList();
                var EmployeeList = _employeeRepository.GetAllForDropDown().ToList();
                var WarehouseList = _warehouseRepository.GetAllForDropDown().ToList();
                var TransactionTypeList = TransactionCategoryList_New.ToList();
                //var WarehouseList = _warehouseRepository.GetWarehouseLedgerHeadForDropDown().ToList();
                var Desciption = "Journl.";


                return Json(new { Success = 1, DebitHeadList = DebitList, CreditHeadList = CreditList, WarehouseList = warehosuepermission.OrderBy(x => x.Value).ToList(), TransactionType = "abc", TransactionCategory = TransactionCategoryList, Customer = CustomerList, Supplier = SupplierList, Employee = EmployeeList, Desciption = Desciption });
            }
            else
            {
                var DebitList = _accountHeadRepository.GetDebitHeadForDropDown().ToList();
                var CreditList = _accountHeadRepository.GetCreditHeadForDropDown().ToList();
                var Desciption = "";

                return Json(new { Success = 1, DebitHeadList = DebitList, CreditHeadList = CreditList, WarehouseList = warehosuepermission.OrderBy(x => x.Value).ToList(), TransactionType = "abc", TransactionCategory = "xyz", Desciption = Desciption });
            }
            //return Json(new { Success = 1,  DebitHeadList = x, CreditHeadList = y});



        }





        [ApiAuthorize]
        public List<SelectListItem> GetAssetLiabilityHeadDropdown()
        {
            var x = _accountHeadRepository.GetAssetLiabilityHeadForDropDown().ToList();
            return x;
        }

        #endregion

        #region Income&Expense


        [ApiAuthorize]
        public List<SelectListItem> GetIncomeExpenseHeadDropdown()
        {
            var x = _accountHeadRepository.GetIncomeExpenseHeadForDropDown().ToList();
            return x;
        }

        #endregion



        [HttpPost]
        [ApiAuthorize]
        public ActionResult CreateTransaction([FromBody] TransactionModel model)
        {

            var errors = ModelState.Where(x => x.Value.Errors.Any())
       .Select(x => new { x.Key, x.Value.Errors });

            if (ModelState.IsValid)
            {
                try
                {
                    //if (ModelState.IsValid)
                    //{
                    if (model.CurrencyId == null)
                    {
                        model.CurrencyId = _storeSettingRepository.All().FirstOrDefault().CountryId;
                        model.CurrencyRate = 1;
                    }


                    if (model.Id > 0)
                    {
                        _transactionRepository.UpdateApi(model, model.Id);


                        if (model.SalesId > 0)
                        {
                            var salespayment = _salesPaymentRepository.All().Where(x => x.TransactionId == model.Id).FirstOrDefault(); ////Where(x => x.SalesId == model.SalesId && x.RowNo == 999 && x.isPosted == false).FirstOrDefault();
                                                                                                                                       //SalesPaymentModel salespayment = new SalesPaymentModel();


                            salespayment.SalesId = model.SalesId.GetValueOrDefault();
                            salespayment.AccountHeadId = model.DebitAccountId;
                            salespayment.Amount = model.TransactionAmount;
                            salespayment.isPosted = false;
                            salespayment.RowNo = 999;
                            salespayment.TransactionId = model.Id;


                            var transactioncount = _salesPaymentRepository.All().Where(x => x.TransactionId == model.Id).Count();
                            if (transactioncount > 0)
                            {
                                _salesPaymentRepository.Update(salespayment, salespayment.Id);
                            }
                            else
                            {
                                _salesPaymentRepository.Insert(salespayment);
                            }



                        }
                        else if (model.PurchaseId > 0)
                        {


                            var transactioncount = _purchasePaymentRepository.All().Where(x => x.TransactionId == model.Id).Count();
                            if (transactioncount > 0)
                            {

                                var purchasepayment = _purchasePaymentRepository.All().Where(x => x.TransactionId == model.Id).FirstOrDefault(); ////Where(x => x.SalesId == model.SalesId && x.RowNo == 999 && x.isPosted == false).FirstOrDefault();
                                                                                                                                                 //PurchasePaymentModel purchasepayment = new PurchasePaymentModel();
                                purchasepayment.PurchaseId = model.PurchaseId.GetValueOrDefault();
                                purchasepayment.AccountHeadId = model.CreditAccountId;
                                purchasepayment.Amount = model.TransactionAmount;
                                purchasepayment.isPosted = false;
                                purchasepayment.RowNo = 999;
                                purchasepayment.TransactionId = model.Id;

                                _purchasePaymentRepository.Update(purchasepayment, purchasepayment.Id);
                            }
                            else
                            {

                                PurchasePaymentModel purchasepayment = new PurchasePaymentModel();
                                purchasepayment.PurchaseId = model.PurchaseId.GetValueOrDefault();
                                purchasepayment.AccountHeadId = model.CreditAccountId;
                                purchasepayment.Amount = model.TransactionAmount;
                                purchasepayment.isPosted = false;
                                purchasepayment.RowNo = 999;
                                purchasepayment.TransactionId = model.Id;

                                _purchasePaymentRepository.Insert(purchasepayment);


                            }


                        }
                    }
                    else
                    {
                        _transactionRepository.InsertApi(model);


                        if (model.SalesId > 0)
                        {
                            SalesPaymentModel salespayment = new SalesPaymentModel();
                            salespayment.SalesId = model.SalesId.GetValueOrDefault();
                            salespayment.AccountHeadId = model.DebitAccountId;
                            salespayment.Amount = model.TransactionAmount;
                            salespayment.isPosted = false;
                            salespayment.RowNo = 999;
                            salespayment.TransactionId = model.Id;

                            _salesPaymentRepository.Insert(salespayment);
                        }
                        else if (model.PurchaseId > 0)
                        {
                            PurchasePaymentModel purchasepayment = new PurchasePaymentModel();
                            purchasepayment.PurchaseId = model.PurchaseId.GetValueOrDefault();
                            purchasepayment.AccountHeadId = model.CreditAccountId;
                            purchasepayment.Amount = model.TransactionAmount;
                            purchasepayment.isPosted = false;
                            purchasepayment.RowNo = 999;
                            purchasepayment.TransactionId = model.Id;

                            _purchasePaymentRepository.Insert(purchasepayment);

                        }


                    }

                    return Ok(true);
                    //}
                    //return Ok(false);
                }
                catch (Exception x)
                {
                    Console.WriteLine(x.Message);
                    return Ok(false);

                }
            }
            else
            {
                return Ok(false);
            }

        }

        [HttpGet]
        [ApiAuthorize]
        public JsonResult GetSingleTransaction(int TransactionId)
        {
            var Transaction = _transactionRepository.All().Include(x => x.Supplier).Include(x => x.Customer)
                //.Include(x => x.AccountPayType)
                .Where(x => x.Id == TransactionId)
                .Select(p => new
                {
                    p.Id,
                    p.TransactionCode,
                    p.Description,

                    p.TransactionType,
                    p.TransactionCategory,
                    p.TransactionAmount,
                    p.DiscountAmount,

                    p.CustomerId,
                    p.SupplierId,
                    p.MemberId,
                    p.EmployeeId,

                    p.SalesId,
                    p.PurchaseId,
                    p.SalesReturnId,
                    p.PurchaseReturnId,
                    p.TransferInId,
                    p.TransferOutId,

                    p.WarehouseId,
                    p.CurrencyId,
                    p.CurrencyRate,

                    p.CreditAccountId,
                    p.DebitAccountId,

                    p.CreateDate,
                    p.LuserId,
                    p.TransactionImageString,

                    SupplierName = p.Supplier != null ? p.Supplier.SupplierName : "",
                    CustomerName = p.Customer != null ? p.Customer.Name : ""

                });
            return Json(Transaction);
        }


        [HttpGet]
        [ApiAuthorize]
        public JsonResult GetTransactionEntry(string Type, int Id)
        {

            try
            {


                var newtransaction = new TransactionModel();
                newtransaction.TransactionCategory = Type;
                //newtransaction.InputDate = DateTime.Now;


                if (Type == "Sales")
                {
                    var salesdata = _saleRepository.All().Include(x => x.SalesPayments).Where(x => x.Id == Id).FirstOrDefault();
                    var assetliabilityid = _accountHeadRepository.All().Where(x => x.AccountCategorys.AccountCategoryName == "Accounts Receivable" && x.AccType == "L").FirstOrDefault().Id;

                    if (salesdata != null)
                    {
                        newtransaction.CustomerId = salesdata.CustomerId;
                        newtransaction.SalesId = salesdata.Id;
                        newtransaction.TransactionAmount = salesdata.NetAmount - salesdata.SalesPayments.Sum(x => x.Amount);

                    }
                    else
                    {
                        newtransaction.TransactionAmount = 0;

                    }

                    newtransaction.TransactionType = "Received";
                    newtransaction.DiscountAmount = 0;
                    newtransaction.DebitAccountId = null;
                    newtransaction.CreditAccountId = assetliabilityid;

                    newtransaction.TransactionCode = "MDT-" + DateTime.Now.ToString("ddMMyyHHmmssfff");
                    newtransaction.InputDate = DateTime.Now.Date;
                    newtransaction.Description = "Amount Collection from Customer Agt. Sales.";


                }
                else if (Type == "Customer")
                {
                    var customerdata = _customerRepository.All().Where(x => x.Id == Id).FirstOrDefault();
                    var assetliabilityid = _accountHeadRepository.All().Where(x => x.AccountCategorys.AccountCategoryName == "Accounts Receivable" && x.AccType == "L").FirstOrDefault().Id;

                    if (customerdata != null)
                    {
                        newtransaction.CustomerId = customerdata.Id;
                    }

                    newtransaction.TransactionType = "Received";


                    newtransaction.TransactionAmount = 0;// salesdata.NetAmount - salesdata.SalesPayments.Sum(x => x.Amount);
                    newtransaction.DiscountAmount = 0;


                    newtransaction.DebitAccountId = null;
                    newtransaction.CreditAccountId = assetliabilityid;
                    newtransaction.TransactionCode = "MDT-" + DateTime.Now.ToString("ddMMyyHHmmssfff");
                    newtransaction.InputDate = DateTime.Now.Date;
                    newtransaction.Description = "Amount Collection from Customer Agt. Sales.";


                }
                else if (Type == "Received")
                {
                    //var salesdata = _saleRepository.All().Include(x => x.SalesPayments).Where(x => x.Id == Id).FirstOrDefault();
                    //var assetliabilityid = _accountHeadRepository.All().Where(x => x.AccountCategorys.AccountCategoryName == "Accounts Receivable" && x.AccType == "L").FirstOrDefault().Id;

                    newtransaction.CustomerId = null;
                    newtransaction.SalesId = null;
                    newtransaction.TransactionType = "Received";


                    newtransaction.TransactionAmount = 0;
                    newtransaction.DiscountAmount = 0;


                    newtransaction.DebitAccountId = null;
                    newtransaction.CreditAccountId = null;
                    newtransaction.TransactionCode = "MDT-" + DateTime.Now.ToString("ddMMyyHHmmssfff");
                    newtransaction.InputDate = DateTime.Now.Date;
                    newtransaction.Description = "Amount Received";


                }
                else if (Type == "Purchase")
                {



                    var purchasedata = _purchaseRepository.All().Include(x => x.PurchasePayments).Where(x => x.Id == Id).FirstOrDefault();
                    var assetliabilityid = _accountHeadRepository.All().Where(x => x.AccountCategorys.AccountCategoryName == "Accounts Payable" && x.AccType == "L").FirstOrDefault().Id;

                    if (purchasedata != null)
                    {
                        newtransaction.SupplierId = purchasedata.SupplierId;
                        newtransaction.PurchaseId = purchasedata.Id;
                        newtransaction.TransactionAmount = purchasedata.NetAmount - purchasedata.PurchasePayments.Sum(x => x.Amount);

                    }
                    else
                    {
                        newtransaction.TransactionAmount = 0;
                    }
                    newtransaction.TransactionType = "Paid";
                    newtransaction.DiscountAmount = 0;
                    newtransaction.DebitAccountId = null;
                    newtransaction.CreditAccountId = null;


                    newtransaction.TransactionCode = "MDT-" + DateTime.Now.ToString("ddMMyyHHmmssfff");
                    newtransaction.InputDate = DateTime.Now.Date;
                    newtransaction.Description = "Amount Paid to Supplier Agt. Purchase.";

                }
                else if (Type == "Supplier")
                {
                    var supplierdata = _supplierRepository.All().Where(x => x.Id == Id).FirstOrDefault();
                    var assetliabilityid = _accountHeadRepository.All().Where(x => x.AccountCategorys.AccountCategoryName == "Accounts Payable" && x.AccType == "L").FirstOrDefault().Id;

                    if (supplierdata != null)
                    {
                        newtransaction.SupplierId = supplierdata.Id;

                    }
                    newtransaction.TransactionType = "Paid";


                    newtransaction.TransactionAmount = 0;// purchasedata.NetAmount - purchasedata.PurchasePayments.Sum(x => x.Amount);
                    newtransaction.DiscountAmount = 0;


                    newtransaction.CreditAccountId = null;
                    newtransaction.DebitAccountId = assetliabilityid;
                    newtransaction.TransactionCode = "MDT-" + DateTime.Now.ToString("ddMMyyHHmmssfff");
                    newtransaction.InputDate = DateTime.Now.Date;
                    newtransaction.Description = "Amount Paid to Supplier Agt. Purchase.";

                }
                else if (Type == "Paid")
                {
                    //var purchasedata = _purchaseRepository.All().Include(x => x.PurchasePayments).Where(x => x.Id == Id).FirstOrDefault();
                    //var assetliabilityid = _accountHeadRepository.All().Where(x => x.AccountCategorys.AccountCategoryName == "Accounts Payable" && x.AccType == "L").FirstOrDefault().Id;

                    //newtransaction.SupplierId = purchasedata.SupplierId;
                    //newtransaction.PurchaseId = purchasedata.Id;
                    newtransaction.TransactionType = "Paid";


                    //newtransaction.TransactionAmount = purchasedata.NetAmount - purchasedata.PurchasePayments.Sum(x => x.Amount);
                    newtransaction.DiscountAmount = 0;


                    newtransaction.DebitAccountId = null;
                    newtransaction.CreditAccountId = null;
                    newtransaction.TransactionCode = "MDT-" + DateTime.Now.ToString("ddMMyyHHmmssfff");
                    newtransaction.InputDate = DateTime.Now.Date;
                    newtransaction.Description = "Amount Paid";

                }
                else if (Type == "CashContra")
                {
                    //var purchasedata = _purchaseRepository.All().Include(x => x.PurchasePayments).Where(x => x.Id == Id).FirstOrDefault();
                    //var assetliabilityid = _accountHeadRepository.All().Where(x => x.AccountCategorys.AccountCategoryName == "Accounts Payable" && x.AccType == "L").FirstOrDefault().Id;

                    //newtransaction.SupplierId = purchasedata.SupplierId;
                    //newtransaction.PurchaseId = purchasedata.Id;
                    newtransaction.TransactionType = "Received";


                    newtransaction.TransactionAmount = 0;// purchasedata.NetAmount - purchasedata.PurchasePayments.Sum(x => x.Amount);
                    newtransaction.DiscountAmount = 0;


                    newtransaction.CreditAccountId = null;
                    newtransaction.DebitAccountId = null;
                    //newtransaction.AssetLiabilityAccountId = assetliabilityid;
                    newtransaction.TransactionCode = "MDT-" + DateTime.Now.ToString("ddMMyyHHmmssfff");
                    newtransaction.InputDate = DateTime.Now.Date;
                    newtransaction.Description = "Amount Paid";

                }
                else if (Type == "BankContra")
                {
                    //var purchasedata = _purchaseRepository.All().Include(x => x.PurchasePayments).Where(x => x.Id == Id).FirstOrDefault();
                    //var assetliabilityid = _accountHeadRepository.All().Where(x => x.AccountCategorys.AccountCategoryName == "Accounts Payable" && x.AccType == "L").FirstOrDefault().Id;

                    //newtransaction.SupplierId = purchasedata.SupplierId;
                    //newtransaction.PurchaseId = purchasedata.Id;
                    newtransaction.TransactionType = "Received";


                    newtransaction.TransactionAmount = 0;// purchasedata.NetAmount - purchasedata.PurchasePayments.Sum(x => x.Amount);
                    newtransaction.DiscountAmount = 0;


                    newtransaction.DebitAccountId = null;
                    newtransaction.CreditAccountId = null;
                    //newtransaction.AssetLiabilityAccountId = assetliabilityid;
                    newtransaction.TransactionCode = "MDT-" + DateTime.Now.ToString("ddMMyyHHmmssfff");
                    newtransaction.InputDate = DateTime.Now.Date;
                    newtransaction.Description = "Amount Paid";

                }
                else
                {
                    //var purchasedata = _purchaseRepository.All().Include(x => x.PurchasePayments).Where(x => x.Id == Id).FirstOrDefault();
                    //var assetliabilityid = _accountHeadRepository.All().Where(x => x.AccountCategorys.AccountCategoryName == "Accounts Payable" && x.AccType == "L").FirstOrDefault().Id;

                    //newtransaction.SupplierId = purchasedata.SupplierId;
                    //newtransaction.PurchaseId = purchasedata.Id;
                    //newtransaction.TransactionType = "Paid";


                    newtransaction.TransactionAmount = 0;
                    newtransaction.DiscountAmount = 0;


                    newtransaction.DebitAccountId = null;
                    newtransaction.CreditAccountId = null;
                    //newtransaction.AssetLiabilityAccountId = assetliabilityid;
                    newtransaction.TransactionCode = "MDT-" + DateTime.Now.ToString("ddMMyyHHmmssfff");
                    newtransaction.InputDate = DateTime.Now.Date;
                    newtransaction.Description = "";
                } //// other


                //string json = @"{"" "+ newtransaction + "}";


                //JObject o = JObject.Parse(
                //    {
                //    Id : newtransaction.Id,
                //    ABC :  newtransaction.InternetUser
                //    }

                //    );

                //JObject abc = new JObject(); 
                //var Transaction = newtransaction.
                //    //.Include(x => x.AccountPayType)
                //    //.Where(x => x.Id == TransactionId)
                //    //.Select(p => new TransactionModel
                //{
                //    p.Id,
                //        p.TransactionCode,
                //        p.Description,

                //        p.CustomerId,
                //        p.Supplier,
                //        p.MemberId,
                //        p.EmployeeId,
                //    });
                return Json(newtransaction);

            }
            catch (Exception x)
            {
                return Json(new { Success = false, error = true, message = x.Message + " ; " + x.InnerException });
                //throw x;
            }
        }




        [ApiAuthorize]
        public JsonResult GetTransactionList(string FromDate, string ToDate, int? UserId, int? CustomerId, int? SupplierId, int? AccountId, int? DebitAccountId, int? AssetLiabilityAccountId, string TransactionCategory, int pageNo = 1, decimal pageSize = 10, string searchquery = "")
        {


            var ComId = (HttpContext.Session.GetInt32("ComId"));
            var sessionLuserId = (HttpContext.Session.GetInt32("UserId"));
            var UserRole = HttpContext.Session.GetString("UserRole");

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
            //var x = Request.Form.TryGetValue("search[value]", out y);

            var transactionlist = _transactionRepository.All();
            transactionlist = transactionlist.Where(x => x.isSystem == false);

            if (searchquery?.Length > 1)
            {
                transactionlist = transactionlist.Where(x => x.TransactionCode.ToLower().Contains(searchquery.ToLower()));
            }
            else
            {
                transactionlist = transactionlist.Where(p => (p.InputDate >= dtFrom && p.InputDate <= dtTo));



                if (UserId != null)
                {
                    transactionlist = transactionlist.Where(p => p.LuserId == UserId);
                }

                if (SupplierId != null)
                {
                    transactionlist = transactionlist.Where(p => p.SupplierId == SupplierId);
                }

                if (CustomerId != null)
                {
                    transactionlist = transactionlist.Where(p => p.CustomerId == CustomerId);
                }


                if (AccountId != null)
                {
                    transactionlist = transactionlist.Where(p => p.DebitAccountId == AccountId);
                }

                if (DebitAccountId != null)
                {
                    transactionlist = transactionlist.Where(p => p.CreditAccountId == DebitAccountId);
                }



                if (TransactionCategory != null && TransactionCategory.Length > 1)
                {
                    transactionlist = transactionlist.Where(p => p.TransactionCategory == TransactionCategory);
                }


            }



            //////// pagination with lenght

            decimal TotalRecordCount = transactionlist.Count();
            var PageCountabc = decimal.Parse((TotalRecordCount / pageSize).ToString());
            var PageCount = Math.Ceiling(PageCountabc);





            decimal skip = (pageNo - 1) * pageSize;

            // Get total number of records
            int total = transactionlist.Count();
            ///


            var query = from e in transactionlist
                        .Include(x => x.DebitAccount).Include(x => x.CreditAccount)
                        .Include(x => x.Customer).Include(x => x.Supplier).Include(x => x.Employee).Include(x => x.Member)
                        .Include(x => x.Sales).Include(x => x.Purchase).Include(x => x.SalesReturn).Include(x => x.PurchaseReturn).Include(x => x.Issue).Include(x => x.TransferIn).Include(x => x.TransferOut)
                        .Include(x => x.VoucherMain).ThenInclude(x => x.Acc_VoucherTypes)
                        select new
                        {
                            e.Id,
                            e.TransactionCode,
                            InputDate = e.InputDate,
                            InputDateString = e.InputDate.ToString("dd-MMM-yy"),
                            EntryUser = e.UserAccountList.Name,

                            DebitAccountName = e.DebitAccount.AccName,
                            CreditAccountName = e.CreditAccount.AccName,

                            CustomerName = e.Customer.Name,
                            SupplierName = e.Supplier.SupplierName,
                            MemberName = e.Member.MembersNameEng,
                            EmployeeName = e.Employee.EmployeeName,


                            SalesCode = e.Sales.SaleCode,
                            PurchaseCode = e.Purchase.PurchaseCode,
                            SalesReturnCode = e.SalesReturn.SalesReturnCode,
                            PurchaseReturnCode = e.PurchaseReturn.PurchaseReturnCode,

                            TransferInCode = e.TransferIn.InternalTransferCode,
                            TransferCodeCode = e.TransferOut.InternalTransferCode,


                            e.Description,
                            StatusPosted = e.isPost != false ? "Posted" : "Not Posted",
                            e.TransactionAmount,
                            VoucherNo = e.VoucherMain.VoucherNo,
                            VoucherType = e.VoucherMain.Acc_VoucherTypes.VoucherTypeName,

                            e.TransactionCategory,
                            e.TransactionType

                        };



            var abcd = query.OrderByDescending(x => x.Id).Skip(int.Parse(skip.ToString())).Take(int.Parse(pageSize.ToString())).ToList();// Take(50);
            var pageinfo = new PagingInfo();
            pageinfo.PageCount = int.Parse(PageCount.ToString());
            pageinfo.PageNo = pageNo;
            pageinfo.PageSize = int.Parse(pageSize.ToString());
            pageinfo.TotalRecordCount = int.Parse(TotalRecordCount.ToString());


            return Json(new { Success = 1, error = false, TransactionList = abcd, PageInfo = pageinfo });



        }



        [ApiAuthorize]
        public ActionResult DeleteTransaction(int TransactionId)
        {
            try
            {
                var response = _transactionRepository.Find(TransactionId);

                if (response.SalesId > 0)
                {
                    var modelsalespayments = _salesPaymentRepository.All().Where(x => x.TransactionId == TransactionId).ToList();
                    _salesPaymentRepository.RemoveRange(modelsalespayments);

                }
                else if (response.PurchaseId > 0)
                {
                    var modelpurchasepayments = _purchasePaymentRepository.All().Where(x => x.TransactionId == TransactionId).ToList();
                    _purchasePaymentRepository.RemoveRange(modelpurchasepayments);
                }


                if (response != null) _transactionRepository.Delete(response);
                else if (response == null) return BadRequest(new { message = "Transaction information Can not be Deleted" });

                //Ok(false);

                return Ok(true);

            }
            catch (Exception x)
            {
                Console.WriteLine(x.Message);
                return BadRequest(new { message = "Something Wrong" });
            }
        }




        [ApiAuthorize]
        public List<SelectListItem> GetPurchaseDropdown()
        {
            var x = _purchaseRepository.GetAllForDropDown().ToList();
            return x;
        }

        [ApiAuthorize]
        public List<SelectListItem> GetSalesDropdown()
        {
            var x = _saleRepository.GetAllForDropDown().ToList();
            return x;
        }

        //// CashBankHead  -- GetAccountHeadDropdown
        ///  AssetLiabilityHead -- GetAssetLiabilityHeadDropdown
        ///  Customer  -- GetCustomerDropdown
        ///  Supplier -- GetSupplierDropdown
        ///  member -- GetMemberDropdown
        ///  Employee -- GetEmployeeDropdown
        ///  Sales -- GetPurchaseDropdown
        ///  Purchase -- GetSalesDropdown

        [ApiAuthorize]
        public List<SelectListItem> GetMemberDropdown()
        { /// sales list

            var UserId = HttpContext.Session.GetInt32("UserId");
            var userrole = HttpContext.Session.GetString("UserRole") ?? "";

            //var AllData = new SelectList(new List<SelectListItem> { new SelectListItem { Text = "ALL", Value = null } }, "Value", "Text").FirstOrDefault();
            var AllData = new SelectListItem { Text = "ALL", Value = null };

            var x = _memberRepository.GetAllForDropDown().ToList();
            x.Add(AllData);
            return x.OrderBy(x => x.Value).ToList();
        }



        #endregion

        #region TransactionType
        public static List<SelectListItem> TransactionTypeList = new List<SelectListItem>()
        {
            new SelectListItem() { Text="Received", Value="Received"},
            new SelectListItem() { Text="Paid", Value="Paid"},
            new SelectListItem() { Text="Increase", Value="Increase"},
            new SelectListItem() { Text="Decrease", Value="Decrease"},
        };


        [ApiAuthorize]
        public List<SelectListItem> GetTransactionTypeDropdown()
        {
            var x = TransactionTypeList.ToList();
            return x;
        }
        #endregion



        #region TransactionCategory
        public static List<SelectListItem> TransactionCategoryList = new List<SelectListItem>()
        {
            
            //Received
            new SelectListItem() { Text="All", Value=null},
            new SelectListItem() { Text="Sales", Value="Received"},
            new SelectListItem() { Text="Customer", Value="Received"},
            new SelectListItem() { Text="Received", Value="Received"},

            //Paid
            new SelectListItem() { Text="Purchase", Value="Paid"},
            new SelectListItem() { Text="Supplier", Value="Paid"},
            new SelectListItem() { Text="Paid", Value="Paid"},


            ///Increase
            new SelectListItem() { Text="CashContra", Value="Received"},
            new SelectListItem() { Text="BankContra", Value="Received"},
             //new SelectListItem() { Text="BankContra", Value="Received"},


            ///Decrease
        };


        [ApiAuthorize]
        public List<SelectListItem> GetTransactionCategoryDropdown()
        {
            var x = TransactionCategoryList.ToList();
            return x;
        }
        #endregion


        #region ApprovalList

        [ApiAuthorize]
        public JsonResult GetCheckVerifyList(string? type, int? DocTypeId)
        {
            try
            {
                var ComId = HttpContext.Session.GetInt32("ComId");
                var UserId = HttpContext.Session.GetInt32("UserId");

                SqlParameter[] sqlParameter = new SqlParameter[4];
                sqlParameter[0] = new SqlParameter("@ComId", ComId);
                sqlParameter[1] = new SqlParameter("@Type", type);
                sqlParameter[2] = new SqlParameter("@DocTypeId", DocTypeId);
                sqlParameter[3] = new SqlParameter("@UserId", UserId);

                var datasetabc = new System.Data.DataSet();
                datasetabc = Helper.ExecProcMapDS("get_CheckVerifyList", sqlParameter);

                SqlParameter[] sqlParameter1 = new SqlParameter[4];
                sqlParameter1[0] = new SqlParameter("@ComId", ComId);
                sqlParameter1[1] = new SqlParameter("@Type", type);
                sqlParameter1[2] = new SqlParameter("@DocTypeId", DocTypeId);
                sqlParameter1[3] = new SqlParameter("@UserId", UserId);

                var datasetabc1 = new System.Data.DataSet();
                datasetabc1 = Helper.ExecProcMapDS("get_CheckVerifyListCount", sqlParameter1);

                return Json(new { Success = 1, error = false, data = datasetabc, count = datasetabc1.Tables[0] });

            }
            catch (Exception ex)
            {
                return Json(new { Success = 0, ex = ex.InnerException?.InnerException?.Message ?? ex.Message });
            }
        }

        [ApiAuthorize]
        public IActionResult DisapproveDocInCheckGRR(int Id, int DocTypeId, string Type, int TransactionId)
        {
            try
            {
                var UserId = HttpContext.Session.GetInt32("UserId");
                if (Type == "Check")
                {
                    if (TransactionId == 0)
                    {
                        var model = new TransactionApprovalStatusModel();
                        var approvalStatus = approvalStatusRepository.All().Where(x => x.ApprovalStatus == "Check").FirstOrDefault();

                        var doctype = _docTypeRepository.Find(DocTypeId);

                        if (doctype.DocFor == "Sales" && doctype.DocType != "Receive payment")
                        {
                            model.SalesId = Id;
                        }
                        else if (doctype.DocFor == "Purchase" && doctype.DocType != "Payment")
                        {
                            model.PurchaseId = Id;
                        }
                        else if (doctype.DocFor == "Voucher")
                        {
                            model.VoucherId = Id;
                        }
                        else if (doctype.DocType == "Receive payment" || doctype.DocType == "Payment")
                        {
                            model.TransactionId = Id;
                        }

                        model.ApprovalStatusId = approvalStatus.Id;
                        model.CheckApproverId = UserId;
                        model.DisApproverId = UserId;
                        model.IsDisApproved = true;
                        model.DocTypeId = DocTypeId;

                        transactionApprovalStatusRepository.Insert(model);
                    }
                    else
                    {
                        var model = transactionApprovalStatusRepository.Find(TransactionId);
                        var approvalStatus = approvalStatusRepository.All().Where(x => x.ApprovalStatus == "Check").FirstOrDefault();
                        model.ApprovalStatusId = approvalStatus.Id;
                        model.CheckApproverId = UserId;
                        model.DisApproverId = UserId;
                        model.IsDisApproved = true;

                        transactionApprovalStatusRepository.Update(model, model.Id);
                    }
                }
                else
                if (Type == "Verify")
                {
                    var model = transactionApprovalStatusRepository.Find(TransactionId);
                    var approvalStatus = approvalStatusRepository.All().Where(x => x.ApprovalStatus == "Verify").FirstOrDefault();
                    model.ApprovalStatusId = approvalStatus.Id;
                    model.VerifyApproverId = UserId;
                    model.DisApproverId = UserId;
                    model.IsDisApproved = true;

                    transactionApprovalStatusRepository.Update(model, model.Id);
                }
                else
                if (Type == "Approve")
                {
                    if (TransactionId != 0)
                    {
                        var model = transactionApprovalStatusRepository.Find(TransactionId);
                        var approvalStatus1 = approvalStatusRepository.All().Where(x => x.ApprovalStatus == "Approve").FirstOrDefault();
                        model.ApprovalStatusId = approvalStatus1.Id;
                        model.FinalApproverId = UserId;
                        model.DisApproverId = UserId;
                        model.IsDisApproved = true;

                        transactionApprovalStatusRepository.Update(model, model.Id);
                    }
                    else
                    {
                        var model = new TransactionApprovalStatusModel();
                        var approvalStatus = approvalStatusRepository.All().Where(x => x.ApprovalStatus == "Approve").FirstOrDefault();
                        var doctype = _docTypeRepository.Find(DocTypeId);

                        if (doctype.DocFor == "Sales" && doctype.DocType != "Receive payment")
                        {
                            model.SalesId = Id;
                        }
                        else if (doctype.DocFor == "Purchase" && doctype.DocType != "Payment")
                        {
                            model.PurchaseId = Id;
                        }
                        else if (doctype.DocFor == "Approval" && doctype.DocType == "Voucher")
                        {
                            model.VoucherId = Id;
                        }
                        else if (doctype.DocType == "Receive payment" || doctype.DocType == "Payment")
                        {
                            model.TransactionId = Id;
                        }
                        model.ApprovalStatusId = approvalStatus.Id;
                        model.CheckApproverId = UserId;
                        model.DisApproverId = UserId;
                        model.IsDisApproved = true;
                        model.DocTypeId = DocTypeId;

                        transactionApprovalStatusRepository.Insert(model);
                    }


                }


                return Json(new { success = "1", msg = "Disapprove Successfully" });
            }
            catch
            {

                return Json(new { success = "0", msg = "Occuring error while disapproved" });

            }

        }

        [ApiAuthorize]
        public IActionResult ApproveDocInCheckGRR(int Id, int DocTypeId, string Type, int TransactionId)
        {
            try
            {
                var UserId = HttpContext.Session.GetInt32("UserId");
                if (Type == "Check")
                {
                    var model = new TransactionApprovalStatusModel();
                    var approvalStatus = approvalStatusRepository.All().Where(x => x.ApprovalStatus == "Check").FirstOrDefault();

                    var doctype = _docTypeRepository.Find(DocTypeId);

                    if (doctype.DocFor == "Sales" && doctype.DocType != "Receive payment")
                    {
                        model.SalesId = Id;
                    }
                    else if (doctype.DocFor == "Purchase" && doctype.DocType != "Payment")
                    {
                        model.PurchaseId = Id;
                    }
                    else if (doctype.DocFor == "Voucher")
                    {
                        model.VoucherId = Id;
                    }
                    else if (doctype.DocType == "Receive payment" || doctype.DocType == "Payment")
                    {
                        model.TransactionId = Id;
                    }

                    model.ApprovalStatusId = approvalStatus.Id;
                    model.CheckApproverId = UserId;
                    model.DocTypeId = DocTypeId;

                    transactionApprovalStatusRepository.Insert(model);
                }
                else
                if (Type == "Verify")
                {
                    var model = transactionApprovalStatusRepository.Find(TransactionId);
                    var approvalStatus = approvalStatusRepository.All().Where(x => x.ApprovalStatus == "Verify").FirstOrDefault();
                    model.ApprovalStatusId = approvalStatus.Id;
                    model.VerifyApproverId = UserId;

                    transactionApprovalStatusRepository.Update(model, model.Id);
                }
                else
                if (Type == "Approve")
                {
                    if (TransactionId != 0)
                    {
                        var model = transactionApprovalStatusRepository.Find(TransactionId);
                        var approvalStatus1 = approvalStatusRepository.All().Where(x => x.ApprovalStatus == "Approve").FirstOrDefault();
                        model.ApprovalStatusId = approvalStatus1.Id;
                        model.FinalApproverId = UserId;

                        transactionApprovalStatusRepository.Update(model, model.Id);
                    }
                    else
                    {
                        var model = new TransactionApprovalStatusModel();
                        var approvalStatus = approvalStatusRepository.All().Where(x => x.ApprovalStatus == "Approve").FirstOrDefault();
                        var doctype = _docTypeRepository.Find(DocTypeId);

                        if (doctype.DocFor == "Sales" && doctype.DocType != "Receive payment")
                        {
                            model.SalesId = Id;
                        }
                        else if (doctype.DocFor == "Purchase" && doctype.DocType != "Payment")
                        {
                            model.PurchaseId = Id;
                        }
                        else if (doctype.DocFor == "Voucher")
                        {
                            model.VoucherId = Id;
                        }
                        else if (doctype.DocType == "Receive payment" || doctype.DocType == "Payment")
                        {
                            model.TransactionId = Id;
                        }
                        model.ApprovalStatusId = approvalStatus.Id;
                        model.FinalApproverId = UserId;
                        model.DocTypeId = DocTypeId;

                        transactionApprovalStatusRepository.Insert(model);
                    }
                }
                else
                if (Type == "Disapprove")
                {
                    var model = transactionApprovalStatusRepository.Find(TransactionId);
                    model.IsDisApproved = false;
                    model.DisApproverId = null;

                    transactionApprovalStatusRepository.Update(model, model.Id);
                }


                return Json(new { success = "1", msg = "Approve Successfully" });
            }
            catch
            {

                return Json(new { success = "0", msg = "Occuring error while Approved" });

            }

        }

        #endregion


        public static List<SelectListItem> TransactionCategoryList_New = new List<SelectListItem>()
        {
            
            //Received
            new SelectListItem() { Text="Transaction", Value="Transaction"},

            new SelectListItem() { Text="By Income", Value="Income"},
            new SelectListItem() { Text="From Customer", Value="Customer"},
            new SelectListItem() { Text="By Invoice", Value="Sales"},
            new SelectListItem() { Text="From Customer - Multiple Invoice", Value="CustomerMultipleInvoice"},
            new SelectListItem() { Text="From Supplier", Value="ReceivedFromSupplier"},
            new SelectListItem() { Text="From Employee", Value="ReceivedFromEmployee"},


            //Paid
            new SelectListItem() { Text="For Expense", Value="Expense"},
            new SelectListItem() { Text="To Supplier", Value="Supplier"},

            new SelectListItem() { Text="By Purchase Order", Value="Purchase"},
            new SelectListItem() { Text="To Supplier - Multiple Invoice", Value="SupplierMultipleInvoice"},
            new SelectListItem() { Text="To Customer", Value="PaidToCustomer"},
            new SelectListItem() { Text="To Employee", Value="PaidToEmployee"},


            ///Increase
            new SelectListItem() { Text="Cash Received From Bank", Value="CashContra"},
            new SelectListItem() { Text="Cash Deposit To Bank", Value="BankContra"},
            new SelectListItem() { Text="Contra", Value="Contra"},
            new SelectListItem() { Text="Discount To Customer", Value="CustomerDiscount"},
            new SelectListItem() { Text="Discount From Supplier", Value="SupplierDiscount"},
             //new SelectListItem() { Text="BankContra", Value="Received"},


            ///Decrease
        };



        [ApiAuthorize]
        public async Task<JsonResult> NIDVerifyAPI(string VoterIdCardScan, string dateOfBirth)
        {
            ViewBag.ActionType = "NIDCheck";
            VoterModel abc = new VoterModel();
            abc.DateOfBirth = "";
            var comid = HttpContext.Session.GetInt32("ComId");


            try
            {


                decimal CreditBalance = 0;

                var balancesms = _CreditBalanceRepository.All().Where(x => x.ValidityDate >= DateTime.Now.Date && x.PurchaseQuantity - x.UsedQuantity > 0 && x.ComId == comid).OrderBy(x => x.ValidityDate).FirstOrDefault();
                abc.CreditCost = 0;
                if (balancesms != null)
                {
                    abc.CreditCurrent = balancesms.PurchaseQuantity - balancesms.UsedQuantity;

                    if (VoterIdCardScan != null && dateOfBirth != "0001-01-01T00:00")
                    {

                        if (balancesms.PurchaseQuantity - balancesms.UsedQuantity > 0)
                        {

                            var nidfromdb = _voterRepository.All(false)
                                .Where(x => x.voterNo == VoterIdCardScan)
                                .Select(p => new
                                {
                                    p.Id,
                                    p.voterNo,
                                    p.name,
                                    p.nameEn,
                                    p.father,
                                    p.mother,
                                    p.gender,
                                    p.permanentAddress,
                                    p.presentAddressBN,

                                    p.spouse,
                                    p.dob,
                                    p.profession,
                                    p.photo,
                                    p.Status,
                                    CreditCost = 1,
                                    CreditCurrent = balancesms.PurchaseQuantity - (balancesms.UsedQuantity - 1),
                                    DateOfBirth = p.dob.ToString("yyyy-MM-dd")

                                }).FirstOrDefault();


                            balancesms.UsedQuantity = balancesms.UsedQuantity + 1;
                            _CreditBalanceRepository.Update(balancesms, balancesms.Id);

                            CreditUsedModel abcd = new CreditUsedModel();
                            abcd.SendingDate = DateTime.Now;
                            abcd.TextLength = 1;
                            abcd.Quantity = 1;
                            abcd.CommandType = "NID Verify";
                            abcd.Remarks = "Credit Deduct for Verify voter Id : " + VoterIdCardScan.ToString();
                            abcd.SMSText = VoterIdCardScan + "  " + dateOfBirth;
                            _creditUsedLogRepository.Insert(abcd);




                            if (nidfromdb != null)
                            {
                                //nidfromdb.CreditCost = 1;
                                //nidfromdb.CreditCurrent = balancesms.PurchaseQuantity- balancesms.UsedQuantity;
                                //nidfromdb.DateOfBirth = nidfromdb.dob.ToString("yyyy-MM-dd");



                                TempData["Message"] = "NID Verify Data from Local Server.";
                                TempData["Status"] = "1";
                                tranlog.TransactionLog(RouteData.Values["controller"].ToString(), RouteData.Values["action"].ToString(), TempData["Message"].ToString(), VoterIdCardScan.ToString(), "Create", VoterIdCardScan.ToString());


                                //return Json(nidfromdb);
                                return Json(new { Success = 1, voterdata = nidfromdb });
                            }
                            else
                            {
                                //var dateformatstring = DateTime.Parse(dateOfBirth).ToString("yyyy-MM-dd");
                                var x = await _nidVerify.NIDVerifyAsync(VoterIdCardScan, dateOfBirth);
                                x.DateOfBirth = x.dob.ToString("yyyy-MM-dd");

                                var nidfromserver = _voterRepository.All(false)
                                .Where(x => x.voterNo == VoterIdCardScan)
                                .Select(p => new
                                {
                                    p.Id,
                                    p.voterNo,
                                    p.name,
                                    p.nameEn,
                                    p.father,
                                    p.mother,
                                    p.gender,
                                    p.permanentAddress,
                                    p.presentAddressBN,

                                    p.spouse,
                                    p.dob,
                                    p.profession,
                                    p.photo,
                                    p.Status,
                                    CreditCost = 1,
                                    CreditCurrent = balancesms.PurchaseQuantity - (balancesms.UsedQuantity - 1),
                                    DateOfBirth = p.dob.ToString("yyyy-MM-dd")

                                }).FirstOrDefault();

                                //nidfromserver.CreditCost = 1;
                                //nidfromserver.CreditCurrent = balancesms.PurchaseQuantity- balancesms.UsedQuantity;


                                if (x.voterNo == null)
                                {
                                    //TempData["Error"] = "No Valid Data found for :" + VoterIdCardScan;
                                    return Json(new { Success = 0, error = "No Valid Data found for :" + VoterIdCardScan });
                                }



                                TempData["Message"] = "NID Verify Data from Live Server.";
                                TempData["Status"] = "1";
                                tranlog.TransactionLog(RouteData.Values["controller"].ToString(), RouteData.Values["action"].ToString(), TempData["Message"].ToString(), VoterIdCardScan.ToString(), "Create", VoterIdCardScan.ToString());


                                return Json(new { Success = 1, voterdata = nidfromserver });
                            }



                        }
                        else
                        {
                            return Json(new { Success = 0, error = "You have no Credit" });
                            //TempData["Error"] = "You have no Credit";
                            //msg = "You have no Credit";
                            //return Json(new { Success = false, ex = msg });
                            //return Json(abc);
                        }


                    }
                    else
                    {
                        return Json(new { Success = 0, error = "Please Provide Voter No and Birthdate in a correct format. Birthday format should be [YYYY-MM-DD]" });

                        //return BadRequest(new { message = "Please Provide Voter No and Birthdate in a correct format. Birthday format should be [YYYY-MM-DD]" });
                        //TempData["Error"] = "Please Provide Voter No and Birthdate in a correct format. Birthday format should be [YYYY-MM-DD]";
                        //return Json(abc);
                    }
                }
                else
                {
                    return Json(new { Success = 0, error = "You have no Credit" });

                    //TempData["Error"] = "You have no Credit";
                    //msg = "You have no Credit";
                    //return Json(new { Success = false, ex = msg });
                    //return Json(abc);
                }


                //var singleAccount = _accountHeadRepository.All(false).Where(x => x.Id == AccountId)
                //    .Select(x => new
                //    {
                //        x.Id,
                //        x.AccCode,
                //        x.AccName,
                //        x.AccountCategoryId,
                //        x.ParentId,
                //        x.CreateDate,
                //        x.AccType,
                //        x.LuserId
                //    }).FirstOrDefault();

                //return Json(singleAccount);

            }
            catch (Exception ex)
            {
                return Json(new { Success = 0, error = ex.Message });
                //return BadRequest(new { message = "Something Wrong" });
                throw ex;
            }
        }

        public JsonResult GetModelByBrandId(int BrandId)
        {
            var itemlist = _productRepository.GetModelByBrandDropDown(BrandId);
            return Json(new { item = itemlist });
        }


        [HttpPost]
        [AllowAnonymous]

        public IActionResult AddCategory(string categoryName)
        {
            //// Here you can add code to save the new category to the server
            //// and get the newly added category data (e.g., ID and name)
            //// For simplicity, I'll assume you have a service or repository method to handle this.

            //// Your logic to save the category and get the added category data
            //var newCategoryId = 123; // Replace with the actual ID of the newly added category
            //var newCategoryName = categoryName; // Use the provided category name

            var categorymodel = new CategoryModel();
            categorymodel.Name = categoryName;
            var categoryid = _categoryRepository.InsertInt(categorymodel);

            // Return the newly added category data as JSON
            return Json(new { id = categoryid, name = categoryName });
        }



        [HttpPost]
        [AllowAnonymous]

        public IActionResult AddUnit(string unitName, string unitShortName)
        {
            //// Here you can add code to save the new unit to the server
            //// and get the newly added unit data (e.g., ID and name)
            //// For simplicity, I'll assume you have a service or repository method to handle this.

            //// Your logic to save the unit and get the added unit data
            //var newUnitId = 123; // Replace with the actual ID of the newly added unit
            //var newUnitName = unitName; // Use the provided unit name

            var unitmodel = new UnitModel();
            unitmodel.UnitName = unitName;
            unitmodel.UnitShortName = unitShortName;

            var unitid = _unitRepository.InsertInt(unitmodel);

            // Return the newly added unit data as JSON
            return Json(new { id = unitid, name = unitShortName });
        }



        [ApiAuthorize]
        [HttpPost]
        public async Task<IActionResult> SetDeviceInfo([FromBody] NotificationDto model)
        {
            try
            {
                var ComId = (HttpContext.Session.GetInt32("ComId"));
                var LuserId = (HttpContext.Session.GetInt32("UserId"));

                var usernoft = await _notificationSettingRepository.All().Where(x => x.LuserId == LuserId).ToListAsync(); //fahad

                if (usernoft.Count() == 0)
                {
                    var abc = new NotificationSetting { DeviceToken = model.NewDeviceToken, LuserId = LuserId.GetValueOrDefault() };

                    _notificationSettingRepository.Insert(abc);


                    return StatusCode(StatusCodes.Status200OK);

                }
                else
                {
                    foreach (var item in usernoft)
                    {
                        if (item.LuserId == LuserId && item.DeviceToken != model.OldDeviceToken)
                        {
                            item.DeviceToken = model.NewDeviceToken;
                            _notificationSettingRepository.Update(item, item.Id);
                        }
                    }

                    return StatusCode(StatusCodes.Status200OK);
                }

                return NoContent();
            }
            catch (Exception ex)
            {

                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }

        }
        [HttpPost]
        public async Task<IActionResult> TestNotification(string massage, string token, int count)
        {

            try
            {
                if (string.IsNullOrEmpty(massage))
                {
                    return BadRequest("Massage Not available");
                }
                //if (string.IsNullOrEmpty(token))
                //{
                //    token = "fhX0dT3FRgujU-DnKMtDkV:APA91bEWGNMoGZkUF-YpWB9xX4ssPimHzYyFsruoUf6uGTJw7CQuhKs2lAEJ2fUKZ_j5xTEcV8v4GtK4mIAatr9kb95q8Zgc7M5K2zZYnuEvRqDPXa_jIAR7bpBMhPeHOH_xm1SLg2F7";
                //}
                for (var i = 0; i < count; i++)
                {

                    await Task.Delay(10000);
                    await _notificationSender.SendNotification(token, massage, "atrai");
                }



                return Ok();
            }
            catch (Exception ex)
            {

                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }


        [ApiAuthorize]
        public JsonResult GetCashBankMonthlyBalance(int FiscalYearId)
        {
            //var x = _mobileTextAnimationRepository.All().Where(s => s.IsSeen == false)
            //          .Select(p => new
            //          {
            //              p.Id,
            //              p.TextMessageOne,
            //              p.TextMessageTwo,
            //              p.TextMessageThree,
            //              p.Type,
            //              p.LuserId,
            //              p.TypeColor,
            //              p.TextMessageOneColor,
            //              p.TextMessageTwoColor,
            //              p.TextMessageThreeColor,
            //              p.TypeSize,
            //              p.TextMessageOneSize,
            //              p.TextMessageTwoSize,
            //              p.TextMessageThreeSize

            //          }).ToList();


            //return Json(x);

            var getfiscalid = _accFiscalYear.All().FirstOrDefault();
            var dtFrom = getfiscalid.OpeningDate;
            var dtTo = getfiscalid.ClosingDate;
            var ComId = HttpContext.Session.GetInt32("ComId");
            var WarehouseId = FiscalYearId;


            SqlParameter[] sqlParameter1 = new SqlParameter[5];
            sqlParameter1[0] = new SqlParameter("@Criteria", "CashBankMonthlyBalance");
            sqlParameter1[1] = new SqlParameter("@FromDate", dtFrom);
            sqlParameter1[2] = new SqlParameter("@ToDate", dtTo);
            sqlParameter1[3] = new SqlParameter("@ComId", ComId);
            sqlParameter1[4] = new SqlParameter("@Id", FiscalYearId);


            List<MonthWiseCashBankBalance> daywisesales = Helper.ExecProcMapTList<MonthWiseCashBankBalance>("prcGetDashboard", sqlParameter1).ToList();

            return Json(daywisesales);

        }



        [ApiAuthorize]
        public JsonResult GetCashBankMonthlyBalanceColumn(int FiscalYearId)
        {

            var getfiscalid = _accFiscalYear.All().FirstOrDefault();
            var dtFrom = getfiscalid.OpeningDate;
            var dtTo = getfiscalid.ClosingDate;
            var ComId = HttpContext.Session.GetInt32("ComId");
            var WarehouseId = FiscalYearId;


            SqlParameter[] sqlParameter1 = new SqlParameter[5];
            sqlParameter1[0] = new SqlParameter("@Criteria", "CashBankMonthlyBalanceColumn");
            sqlParameter1[1] = new SqlParameter("@FromDate", dtFrom);
            sqlParameter1[2] = new SqlParameter("@ToDate", dtTo);
            sqlParameter1[3] = new SqlParameter("@ComId", ComId);
            sqlParameter1[4] = new SqlParameter("@Id", FiscalYearId);


            List<MonthWiseBalance> daywisesales = Helper.ExecProcMapTList<MonthWiseBalance>("prcGetDashboard", sqlParameter1).ToList();

            return Json(daywisesales);

        }


        [ApiAuthorize]
        public JsonResult GetProductStockByWarehouseId(string WarehouseId)
        {

            var ComId = HttpContext.Session.GetInt32("ComId");
            var UserId = HttpContext.Session.GetInt32("UserId");

            var datasetabc = new System.Data.DataSet();


            SqlParameter[] sqlParameter = new SqlParameter[2];
            sqlParameter[0] = new SqlParameter("@ComId", ComId);
            sqlParameter[1] = new SqlParameter("@WarehouseId", WarehouseId);

            datasetabc = Helper.ExecProcMapDS("Inv_ProductByWarehouse", sqlParameter);
            var StockBalance = datasetabc.Tables[0];

            return Json(StockBalance);

        }



        [ApiAuthorize]

        public JsonResult ProductStockViewReportForWordpress(string dtFrom, string dtTo, string Type, int? WarehouseId)
        {
            try
            {

                Atrai.Model.AppData.DefaultConnectionString = Config.GetConnectionString("DefaultConnection");

                var result = "";
                var ComId = HttpContext.Session.GetInt32("ComId");
                var UserId = HttpContext.Session.GetInt32("UserId");

                if (ComId == null)
                {
                    result = "Please Login first";
                }
                var URLLink = "";
                var TopSize = 20;



                var quary = $"Exec [ProductAnalysisReport]  '" + ComId + "','" + dtFrom + "' ,'" + dtTo + "','" + Type + "','" + URLLink + "','" + TopSize + "','" + WarehouseId + "'";


                SqlParameter[] parameters = new SqlParameter[7];
                parameters[0] = new SqlParameter("@ComId", ComId);
                parameters[1] = new SqlParameter("@FromDate", DateTime.Parse(dtFrom));
                parameters[2] = new SqlParameter("@ToDate", DateTime.Parse(dtTo));
                parameters[3] = new SqlParameter("@Type", Type);
                parameters[4] = new SqlParameter("@UrlLink", URLLink);
                parameters[5] = new SqlParameter("@TopSize", TopSize);
                parameters[6] = new SqlParameter("@WarehouseId", WarehouseId);


                List<AdminController.ProductAnalysisViewModel> productanalysisreport = Helper.ExecProcMapTList<AdminController.ProductAnalysisViewModel>("ProductAnalysisReport", parameters);

                //if (Type.ToLower().Contains("notposted"))
                //{
                //    return View("AccountsLedgerViewReportAll", TrialBalanceReport);
                //}


                //return View(productanalysisreport);

                return Json(new { stockinfo = productanalysisreport, ex = result });
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }




        [ApiAuthorize]

        public JsonResult DailySalesStockSummary(string dtFrom, string dtTo, int? WarehouseId, int? IsRefresh)
        {
            try
            {

                Atrai.Model.AppData.DefaultConnectionString = Config.GetConnectionString("DefaultConnection");

                var result = "";
                var ComId = HttpContext.Session.GetInt32("ComId");
                var UserId = HttpContext.Session.GetInt32("UserId");

                if (ComId == null)
                {
                    result = "Please Login first";
                }

                var Sales = new System.Data.DataSet();
                var Expense = new System.Data.DataSet();
                var Stock = new System.Data.DataSet();


                var Type = "DailyAmountSummary";

                var quary = $"Exec [Acc_rptDashboard_Mobile_POS]  '" + ComId + "','" + dtFrom + "' ,'" + dtTo + "','" + IsRefresh + "','" + Type + "','" + WarehouseId + "'";


                SqlParameter[] parameters = new SqlParameter[6];
                parameters[0] = new SqlParameter("@ComId", ComId);
                parameters[1] = new SqlParameter("@FromDate", DateTime.Parse(dtFrom));
                parameters[2] = new SqlParameter("@ToDate", DateTime.Parse(dtTo));
                parameters[3] = new SqlParameter("@IsRefresh", IsRefresh);
                parameters[4] = new SqlParameter("@Type", Type);
                parameters[5] = new SqlParameter("@WarehouseId", WarehouseId);


                var datasetabc = Helper.ExecProcMapDS("Acc_rptDashboard_Mobile_POS", parameters);

                datasetabc.Tables[0].TableName = "Sales";
                datasetabc.Tables[1].TableName = "Expense";
                datasetabc.Tables[2].TableName = "Stock";

                //return View(productanalysisreport);

                return Json(new { SummaryData = datasetabc, ex = result });
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }





        [ApiAuthorize]
        public JsonResult GetAccountsDashboard(int? IsRefresh = 0)
        {
            try
            {



                var ComId = HttpContext.Session.GetInt32("ComId");
                var UserId = HttpContext.Session.GetInt32("UserId");



                SqlParameter[] sqlParameterxx = new SqlParameter[2];
                sqlParameterxx[0] = new SqlParameter("@ComId", ComId);
                sqlParameterxx[1] = new SqlParameter("@IsRefresh", IsRefresh);

                //sqlParameter[1] = new SqlParameter("@Criterial", "MonthWiseProfit");

                var datasetabc = new System.Data.DataSet();
                //List<MonthlySalesModel> monthlysales = Helper.ExecProcMapTList<MonthlySalesModel>("prcGetDashboard", sqlParameter2).ToList();
                datasetabc = Helper.ExecProcMapDS("Acc_rptDashboard_Mobile", sqlParameterxx);

                // ... Your previous code ...

                var NetIncome = new System.Data.DataSet();
                var InvoiceInfo = new System.Data.DataSet();
                var Expense = new System.Data.DataSet();
                var Sales = new System.Data.DataSet();
                var CashBank = new System.Data.DataSet();
                var TopSellingItem = new System.Data.DataSet();
                var ReceivingHead = new System.Data.DataSet();


                var CashFlow = new System.Data.DataSet();
                var CashFlowInfo = new System.Data.DataSet();
                var TopSellingItemInfo = new System.Data.DataSet();



                // Copy and add DataTables for NetIncome DataSet
                NetIncome.Tables.Add(datasetabc.Tables[0].Copy());
                NetIncome.Tables.Add(datasetabc.Tables[1].Copy());
                NetIncome.Tables.Add(datasetabc.Tables[2].Copy());
                NetIncome.Tables.Add(datasetabc.Tables[3].Copy());
                NetIncome.Tables.Add(datasetabc.Tables[4].Copy());
                NetIncome.Tables.Add(datasetabc.Tables[5].Copy());

                NetIncome.Tables[0].TableName = "HourBasis";
                NetIncome.Tables[1].TableName = "WeekBasis";
                NetIncome.Tables[2].TableName = "Last30Days";
                NetIncome.Tables[3].TableName = "Last6Months";
                NetIncome.Tables[4].TableName = "Last12Months";
                NetIncome.Tables[5].TableName = "Last5Years";

                // Copy and add DataTable for InvoiceInfo DataSet
                InvoiceInfo.Tables.Add(datasetabc.Tables[6].Copy());
                InvoiceInfo.Tables[0].TableName = "InvoiceInfo";

                // Copy and add DataTables for Expense DataSet
                Expense.Tables.Add(datasetabc.Tables[7].Copy());
                Expense.Tables.Add(datasetabc.Tables[8].Copy());
                Expense.Tables.Add(datasetabc.Tables[9].Copy());
                Expense.Tables.Add(datasetabc.Tables[10].Copy());
                Expense.Tables.Add(datasetabc.Tables[11].Copy());
                Expense.Tables.Add(datasetabc.Tables[12].Copy());
                Expense.Tables.Add(datasetabc.Tables[13].Copy());

                Expense.Tables[0].TableName = "ExpenseLast30Days";
                Expense.Tables[1].TableName = "ExpenseThisMonth";
                Expense.Tables[2].TableName = "ExpenseThisQurter";
                Expense.Tables[3].TableName = "ExpenseThisYear";
                Expense.Tables[4].TableName = "ExpenseLastMonth";
                Expense.Tables[5].TableName = "ExpenseLastQuarter";
                Expense.Tables[6].TableName = "ExpenseLastYear";



                // Copy and add DataTables for Sales DataSet
                Sales.Tables.Add(datasetabc.Tables[14].Copy());
                Sales.Tables.Add(datasetabc.Tables[15].Copy());
                Sales.Tables.Add(datasetabc.Tables[16].Copy());
                Sales.Tables.Add(datasetabc.Tables[17].Copy());
                Sales.Tables.Add(datasetabc.Tables[18].Copy());
                Sales.Tables.Add(datasetabc.Tables[19].Copy());

                Sales.Tables[0].TableName = "HourBasis";
                Sales.Tables[1].TableName = "WeekBasis";
                Sales.Tables[2].TableName = "Last30Days";
                Sales.Tables[3].TableName = "Last6Months";
                Sales.Tables[4].TableName = "Last12Months";
                Sales.Tables[5].TableName = "Last5Years";



                CashBank.Tables.Add(datasetabc.Tables[20].Copy());
                CashBank.Tables.Add(datasetabc.Tables[21].Copy());

                CashBank.Tables[0].TableName = "Bank";
                CashBank.Tables[1].TableName = "Cash";

                //var HourBasis = Helper.ConvertDataTableasJSON(datasetabc.Tables["HourBasis"]);





                // Copy and add DataTables for NetIncome DataSet
                CashFlow.Tables.Add(datasetabc.Tables[22].Copy());
                CashFlow.Tables.Add(datasetabc.Tables[23].Copy());
                CashFlow.Tables.Add(datasetabc.Tables[24].Copy());
                CashFlow.Tables.Add(datasetabc.Tables[25].Copy());
                CashFlow.Tables.Add(datasetabc.Tables[26].Copy());
                CashFlow.Tables.Add(datasetabc.Tables[27].Copy());

                //CashFlow.Tables[0].TableName = "Hour Basis";
                //CashFlow.Tables[1].TableName = "Week Basis";
                //CashFlow.Tables[2].TableName = "Last 30 Days";
                //CashFlow.Tables[3].TableName = "Last 6 Months";
                //CashFlow.Tables[4].TableName = "Last 12 Months";
                //CashFlow.Tables[5].TableName = "Last 5 Years";

                CashFlow.Tables[0].TableName = "1D";
                CashFlow.Tables[1].TableName = "1W";
                CashFlow.Tables[2].TableName = "1M";
                CashFlow.Tables[3].TableName = "6M";
                CashFlow.Tables[4].TableName = "1Y";
                CashFlow.Tables[5].TableName = "5Y";


                //// Copy and add DataTable for InvoiceInfo DataSet
                //CashFlowInfo.Tables.Add(datasetabc.Tables[6].Copy());
                //CashFlowInfo.Tables[0].TableName = "InvoiceInfo";


                //var CashFlowList = new List<object>();
                //foreach (DataTable table in CashFlow.Tables)
                //{
                //    CashFlowList.Add(new { Caption = table.TableName, Data = table });
                //}
                var CashFlowList = new List<object>();
                var HeaderCaption = new List<string> { "Money In", "Money Out", "Balance" };
                foreach (DataTable table in CashFlow.Tables)
                {
                    CashFlowList.Add(new { HeaderCaption = HeaderCaption, Caption = table.TableName, Data = table });
                }




                // Copy and add DataTables for TopSellingItem DataSet
                TopSellingItem.Tables.Add(datasetabc.Tables[28].Copy());
                TopSellingItem.Tables.Add(datasetabc.Tables[29].Copy());
                TopSellingItem.Tables.Add(datasetabc.Tables[30].Copy());
                TopSellingItem.Tables.Add(datasetabc.Tables[31].Copy());
                TopSellingItem.Tables.Add(datasetabc.Tables[32].Copy());
                TopSellingItem.Tables.Add(datasetabc.Tables[33].Copy());
                TopSellingItem.Tables.Add(datasetabc.Tables[34].Copy());
                TopSellingItem.Tables.Add(datasetabc.Tables[35].Copy());
                TopSellingItem.Tables.Add(datasetabc.Tables[36].Copy());


                TopSellingItem.Tables[0].TableName = "Last 30 Days";
                TopSellingItem.Tables[1].TableName = "Current Date";
                TopSellingItem.Tables[2].TableName = "This Month";
                TopSellingItem.Tables[3].TableName = "This Quarter";
                TopSellingItem.Tables[4].TableName = "This Year";
                TopSellingItem.Tables[5].TableName = "Last Month";
                TopSellingItem.Tables[6].TableName = "Last Quarter";
                TopSellingItem.Tables[7].TableName = "Last Year";
                TopSellingItem.Tables[8].TableName = "Last 5 Years";

                var TopSellingItemList = new List<object>();
                foreach (DataTable table in TopSellingItem.Tables)
                {
                    TopSellingItemList.Add(new { Caption = table.TableName, Data = table });
                }




                // Copy and add DataTables for NetIncome DataSet
                ReceivingHead.Tables.Add(datasetabc.Tables[37].Copy());
                ReceivingHead.Tables.Add(datasetabc.Tables[38].Copy());
                ReceivingHead.Tables.Add(datasetabc.Tables[39].Copy());
                ReceivingHead.Tables.Add(datasetabc.Tables[40].Copy());
                ReceivingHead.Tables.Add(datasetabc.Tables[41].Copy());
                ReceivingHead.Tables.Add(datasetabc.Tables[42].Copy());
                ReceivingHead.Tables.Add(datasetabc.Tables[43].Copy());
                ReceivingHead.Tables.Add(datasetabc.Tables[44].Copy());
                ReceivingHead.Tables.Add(datasetabc.Tables[45].Copy());

                ReceivingHead.Tables[0].TableName = "Last 30 Days";
                ReceivingHead.Tables[1].TableName = "Current Date";
                ReceivingHead.Tables[2].TableName = "This Month";
                ReceivingHead.Tables[3].TableName = "This Quarter";
                ReceivingHead.Tables[4].TableName = "This Year";
                ReceivingHead.Tables[5].TableName = "Last Month";
                ReceivingHead.Tables[6].TableName = "Last Quarter";
                ReceivingHead.Tables[7].TableName = "Last Year";
                ReceivingHead.Tables[8].TableName = "Last 5 Years";

                var ReceivingHeadList = new List<object>();
                foreach (DataTable table in ReceivingHead.Tables)
                {
                    ReceivingHeadList.Add(new { Caption = table.TableName, Data = table });
                }

                //// Copy and add DataTable for InvoiceInfo DataSet
                //TopSellingItemInfo.Tables.Add(datasetabc.Tables[6].Copy());
                //TopSellingItemInfo.Tables[0].TableName = "InvoiceInfo";

                var TransactionTypeList = TransactionCategoryList_New.ToList();



                //var NetIncome = Helper.ConvertDataSetasJSON(datasetabc);
                return Json(new
                {
                    Success = 1,
                    NetIncome = NetIncome,
                    InvoiceInfo = InvoiceInfo,
                    Expense = Expense,
                    Sales = Sales,
                    CashBank = CashBank,
                    TransactionCategoryList = TransactionTypeList,

                    AllDynamicListOfData = new List<object>
                            {
                                new { Caption = "Receiving Head" , Flag = "PieChart" , Data = ReceivingHeadList },
                                new { Caption = "Cash Flow" , Flag = "DetailGraph" , Data = CashFlowList },
                                new { Caption = "Top Selling Item" , Flag = "List" , Data = TopSellingItemList}
                            }

                    //CashFlowInfo = CashFlow , 
                    //    TopSellingItem = TopSellingItem , 
                    //    ReceivingHead= ReceivingHead 
                }
                );

            }
            catch (Exception ex)
            {

                return Json(new { Success = false, error = true, message = ex.Message + " ; " + ex.InnerException });



                throw ex;
            }
        }




        [AllowAnonymous]
        //[HttpPost]
        public JsonResult ExternalPayment(int? packageid, string useremailaddress, string browserId, string amount, string transactionid)
        {


            //GetBrowserId();
            //var browserId =  GetOrSetTrackingCookie();


            //if (browserId_Test.Length != 0)
            //{
            //    browserId = GetOrSetTrackingCookie();
            //}

            //string userAgent = HttpContext.Request.Headers["User-Agent"];

            //// Process the user agent string to extract the browser ID
            //// Example: using a library like UAParser.Net (Install the NuGet package: UAParser)
            //var uaParser = Parser.GetDefault();
            //ClientInfo clientInfo = uaParser.Parse(userAgent);
            //string browserId = clientInfo.UA.Family;





            //var browserId =  GetOrSetTrackingCookie();

            //browserId = GetOrSetTrackingCookie();
            //browserId = Request.Cookies["CookieName"];
            //errorlog("Value Controller get value : " + browserId.ToString());

            browserId = "fahad";
            Random random = new Random();
            int merchantInvoiceNumber = random.Next(100000, 999999);
            string trxID = transactionid;// random.Next(100000, 999999);


            var packageinfo = _softwarePackageRepository.All()
                   .Include(x => x.Country)
                   .Where(x => x.Id == packageid).FirstOrDefault();

            PackageActivationModel cstpayment = new PackageActivationModel();

            cstpayment.InvoiceNo = browserId;// merchantInvoiceNumber.ToString();
            cstpayment.TrxId = trxID.ToString();
            cstpayment.PaymentDate = DateTime.Now.Date;
            cstpayment.Amount = decimal.Parse(packageinfo.PackagePrice.ToString());
            cstpayment.Status = "Success";
            cstpayment.ActiveFromDate = DateTime.Now.Date;
            cstpayment.ActiveToDate = DateTime.Now.Date.AddDays(packageinfo.Duration);
            cstpayment.ActiveYesNo = true;
            cstpayment.PackageId = packageinfo.Id;
            cstpayment.ValidityDay = packageinfo.Duration;
            cstpayment.BillingName = useremailaddress;



            ////if new user then set the session value for sussessfully_paid_new_user
            ///if old user then auotmatically activate and 
            ///



            var getuserbyemailaddress = _userAccountRepository.All(false).Where(x => x.Email == useremailaddress).FirstOrDefault();

            if (getuserbyemailaddress == null)
            {

                HttpContext.Session.SetString("sussessfully_paid_new_user", useremailaddress);
                if (packageid != null)
                {
                    _packageActivationRepository.Insert(cstpayment);

                    _emailsender.SendEmailAsync(useremailaddress, "Payment Status", "Your Payment have received Successfully.");
                    //db.SaveChanges();
                    //Session["activepackage"] = 1;
                }
                //return Json(new { Success = 2, error = false ,message = "Payment Done Successfully , but user not found under this mail address." });
            }
            else
            {
                HttpContext.Session.SetInt32("UserId", getuserbyemailaddress.Id);
                HttpContext.Session.SetInt32("ComId", getuserbyemailaddress.ComId);


                if (packageid != null)
                {
                    _packageActivationRepository.Insert(cstpayment);

                    _emailsender.SendEmailAsync(useremailaddress, "Payment Status", "Your Payment have received Successfully.");
                    //db.SaveChanges();
                    //Session["activepackage"] = 1;
                }


                SubscriptionActivationModel activation = new SubscriptionActivationModel();
                var prevActivation = _subscriptionActivationRepository.All().Where(x => x.UserAccount.Email == useremailaddress).OrderByDescending(x => x.Id).FirstOrDefault();

                var subscriptiontypeId = _subscriptionTypeRepository.All().Where(x => x.SubscriptionName.ToLower().Contains("monthly")).FirstOrDefault().Id; ;

                if (prevActivation == null)
                {

                    activation.ActiveFromDate = DateTime.Now.Date;
                    activation.ActiveToDate = DateTime.Now.Date.AddMonths(1);
                    activation.Remarks = "Payment by Stripe via Online";
                    activation.ActiveToDate = DateTime.Now.AddMonths(1);
                    activation.IsActive = true;
                    activation.ValidityDay = Math.Round((DateTime.Now.Date.AddMonths(1) - DateTime.Now.Date).TotalDays);
                    activation.SubscriptionTypeId = subscriptiontypeId;
                    activation.LuserId = getuserbyemailaddress.LuserId ?? 0;
                    activation.ComId = getuserbyemailaddress.ComId;

                    _subscriptionActivationRepository.Insert(activation);
                }
                else
                {
                    //_userAccountRepository.

                    prevActivation.ActiveFromDate = DateTime.Now.Date;
                    prevActivation.ActiveToDate = DateTime.Now.Date.AddMonths(1);
                    prevActivation.ValidityDay = Math.Round((DateTime.Now.Date.AddMonths(1) - DateTime.Now.Date).TotalDays);

                    prevActivation.LuserId = getuserbyemailaddress.Id;
                    prevActivation.ComId = getuserbyemailaddress.ComId;
                    prevActivation.SubscriptionTypeId = 11;
                    prevActivation.Amount = 0;
                    prevActivation.IsDelete = false;
                    prevActivation.IsActive = true;
                    prevActivation.Remarks = "Payment by Stripe via Online";
                    prevActivation.ActiveToDate = DateTime.Now.AddMonths(1);
                    prevActivation.SubscriptionTypeId = subscriptiontypeId;

                    _subscriptionActivationRepository.Update(prevActivation, prevActivation.Id);

                }





            }

            var UserId = HttpContext.Session.GetInt32("UserId");
            var ComId = HttpContext.Session.GetInt32("ComId");

            cstpayment.LuserId = UserId.GetValueOrDefault();

            //cstpayment.userid = HttpContext.Session.GetInt32("UserId");
            //cstpayment.UserPhoneNo = Session["userphoneno"].ToString();
            //var useremailaddress = HttpContext.Session.GetString("UserInfo");
            //cstpayment.PaymentDate =



            //else
            //{
            //    _packageActivationRepository.Insert(cstpayment);

            //    var subscritpion = _subscriptionActivationRepository.All().Where(x => x.LuserId == UserId).OrderByDescending(x => x.Id).FirstOrDefault();
            //    subscritpion.ValidityDay = packageinfo.TotalDays;
            //    subscritpion.ActiveToDate = DateTime.Now.AddMonths(1);
            //    subscritpion.Amount = float.Parse(packageinfo.PackagePrice.ToString());
            //    subscritpion.IsActive = true;
            //    subscritpion.UpdateDate = DateTime.Now.Date;
            //    subscritpion.Remarks = "Payment Via Stripe ";


            //    _subscriptionActivationRepository.Update(subscritpion, subscritpion.Id);
            //}

            //var jsonData = useremailaddress.ToString();
            //// Create a cookie with the serialized data
            //Response.Cookies.Append("MyData", jsonData);
            //Response.Cookies.Append("sussessfully_paid_new_user_cookies", useremailaddress);

            //var getjsonData = Request.Cookies["MyData"];


            //Response.Cookies.Append("sussessfully_paid_new_user_cookies", useremailaddress);

            //var abc = HttpContext.Session.GetString("sussessfully_paid_new_user");

            //var jsonData = Request.Cookies["sussessfully_paid_new_user_cookies"];

            //Response.Cookies.Append("sussessfully_paid_new_user_cookies", useremailaddress);

            //var cookieValue = useremailaddress;

            //// Create a new cookie with shared settings
            //var cookieOptions = new CookieOptions
            //{
            //    Domain = "http://localhost:25534", // Replace with your domain
            //    Path = "/",
            //    Expires = DateTime.UtcNow.AddDays(7),
            //    IsEssential = true,
            //    HttpOnly = true
            //};

            // Set the cookie value
            ///Response.Cookies.Append("GlobalCookie", cookieValue, cookieOptions);


            //var getcookieValue = Request.Cookies["GlobalCookie"];







            //var cookieOptions = new CookieOptions
            //{
            //    // Set the properties of the cookie
            //    Path = "/",
            //    HttpOnly = true,
            //    Secure = true,
            //    Expires = DateTime.Now.AddDays(7)
            //};

            // Set the cookie value
            ///Response.Cookies.Append("sussessfully_paid_new_user_cookies", useremailaddress, cookieOptions);



            errorlog("External Payment Done : " + useremailaddress.DefaultIfEmpty().ToString());

            return Json(new { Success = 1, error = false, message = "Package activation done." }); //,usermailaddress = getcookieValue 


            //return Json(cstpayment);

        }



        public string? GetOrSetTrackingCookie()
        {
            // Try to read the tracking cookie
            if (Request.Cookies.TryGetValue("sussessfully_paid_new_user_cookies", out string userId))
            {
                // The cookie value (userId) is available
                return userId;
            }
            else
            {
                // The cookie does not exist or could not be retrieved
                // Generate a new unique identifier
                userId = Guid.NewGuid().ToString();
                errorlog("sussessfully_paid_new_user_cookies [Values Page]: " + userId.ToString());
                // Create a new cookie
                var cookieOptions = new CookieOptions
                {
                    // Set the cookie expiration time
                    Expires = DateTime.UtcNow.AddDays(30),
                    // Set the cookie to be accessible across different websites within the same domain
                    SameSite = SameSiteMode.None,
                    Secure = false,
                    // Set the cookie path
                    Path = "/",
                    Domain = ".w2u.io"
                };

                // Set the cookie value in the response
                Response.Cookies.Append("sussessfully_paid_new_user_cookies", userId, cookieOptions);

                return userId;
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
}
