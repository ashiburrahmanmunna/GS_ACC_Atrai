using Atrai.Core.Common;
using Atrai.Data.Context.AppDataContext;
using Atrai.Data.Interfaces;
using Atrai.Model.Core.Entity;
using Atrai.Model.Core.ViewModel;
using Atrai.Services;
using DataTablesParser;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;

namespace Atrai.Controllers
{
    [Authorize]
    [OverridableAuthorize]
    public class InternetController : Controller
    {
        public TransactionLogRepository tranlog { get; }

        private readonly ICustomerRepository _customerRepository;
        private readonly ISupplierRepository _supplierRepository;
        private readonly IInternetUserRepository _InternetUserRepository;

        private readonly IMemberRepository _memberRepository;
        private readonly ICountryRepository _countryRepository;

        private readonly IVGMRepository _vgmRepository;

        private readonly IProductRepository _productRepository;

        private readonly IUnitRepository _unitRepository;
        private readonly IStoreSettingRepository _storeSettingRepository;
        private readonly ISaleRepository _saleRepository;
        private readonly IPurchaseRepository _purchaseRepository;
        private readonly ICostCalculatedRepository _costCalculatedRepository;


        private readonly IUserAccountRepository _userAccountRepository;

        private readonly IAccountHeadRepository _accountHeadRepository;
        private readonly ITransactionRepository _transactionRepository;
        private readonly IInvoiceBillRepository _invoiceBillRepository;


        private readonly ICategoryRepository _categoryRepository;
        private readonly IInternetPackageRepository _internetPackageRepository;
        private readonly IInternetUserStatusRepository _internetUserStatusRepository;

        private readonly IInternetComplainRepository _InternetComplainRepository;
        private readonly IInternetDiagnosisReportRepository _InternetDiagnosisReportRepository;

        private readonly IActivationTicketRepository _ActivationTicketRepository;
        private readonly ITroubleTicketRepository _TroubleTicketRepository;
        private readonly ITroubleTicketCommentRepository _TroubleTicketCommentRepository;







        private readonly IWarehouseRepository _warehouseRepository;

        private readonly IBusinessTypeRepository _businessTypeRepository;
        private readonly ISubscriptionTypeRepository _subscriptionTypeRepository;

        private readonly IMenuRepository _menuRepository;
        private readonly IUserRoleRepository _userRoleRepository;
        private readonly IMenuPermissionRepository _menuPermissionRepository;
        private readonly IUserLogingInfoRepository _userLogingInfoRepository;
        private readonly IUserTransactionLogRepository _userTransactionLogRepository;
        private readonly ICompanyRepository _companyRepository;


        private readonly IExpireDateExtendRepository _expireDateExtendRepository;
        private readonly IUserTerminateRepository _userTerminateRepository;


        private readonly IToDoRepository _toDoRepository;
        private readonly IProductLedgerRepository _productLedgerRepository;
        private readonly ITestRouterOnuTrackingRepository _testRouterOnuTrackingRepository;



        private readonly IWarrentyRepository _warrentyRepository;










        private readonly IConfiguration configuration;
        Dictionary<int, dynamic> postData = new Dictionary<int, dynamic>();
        private readonly InvoiceDbContext db;

        public InternetController(ICustomerRepository customerRepository, ISupplierRepository supplierRepository, IVGMRepository vgmRepository,
        IProductRepository productRepository, IUnitRepository unitRepository, IStoreSettingRepository storeSettingRepository, ICompanyRepository companyRepository,
        ISaleRepository saleRepository,
        IPurchaseRepository purchaseRepository,
        ICostCalculatedRepository costCalculatedRepository,


        InvoiceDbContext context, IUserAccountRepository userAccountRepository,
        IAccountHeadRepository accountHeadRepository, ITransactionRepository transactionRepository, IInvoiceBillRepository invoiceBillRepository,
        ICategoryRepository categoryRepository, IWarrentyRepository warrentyRepository, IWarehouseRepository warehouseRepository,
        IInternetPackageRepository internetPackageRepository,
        IInternetUserStatusRepository internetUserStatusRepository,

        IInternetComplainRepository internetComplainRepository,
        IInternetDiagnosisReportRepository internetDiagnosisReportRepository,

        IActivationTicketRepository ActivationTicketRepository,
        ITroubleTicketRepository TroubleTicketRepository,
        ITroubleTicketCommentRepository TroubleTicketCommentRepository,




        IInternetUserRepository InternetUserRepository,

        IMemberRepository memberRepository,

        IBusinessTypeRepository businessTypeRepository,
        ISubscriptionTypeRepository subscriptionTypeRepository,

        IMenuRepository menuRepository,
        IUserRoleRepository userRoleRepository,
        IMenuPermissionRepository menuPermissionRepository,

        IUserLogingInfoRepository userLogingInfoRepository,
        IUserTransactionLogRepository userTrnsactionLogRepository,
        ICountryRepository countryRepository,


        IExpireDateExtendRepository expireDateExtendRepository,
        IUserTerminateRepository userTerminateRepository,

        IToDoRepository toDoRepository,
        IProductLedgerRepository productLedgerRepository,
        ITestRouterOnuTrackingRepository testRouterOnuTrackingRepository,





        IConfiguration configuration, TransactionLogRepository tranlogRepository)
        {
            tranlog = tranlogRepository;
            _customerRepository = customerRepository;
            _supplierRepository = supplierRepository;
            _InternetUserRepository = InternetUserRepository;


            _vgmRepository = vgmRepository;
            _storeSettingRepository = storeSettingRepository;
            _companyRepository = companyRepository;

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
            _warrentyRepository = warrentyRepository;

            _internetPackageRepository = internetPackageRepository;
            _internetUserStatusRepository = internetUserStatusRepository;

            _InternetComplainRepository = internetComplainRepository;
            _InternetDiagnosisReportRepository = internetDiagnosisReportRepository;

            _ActivationTicketRepository = ActivationTicketRepository;
            _TroubleTicketRepository = TroubleTicketRepository;
            _TroubleTicketCommentRepository = TroubleTicketCommentRepository;






            _warehouseRepository = warehouseRepository;

            _menuRepository = menuRepository;
            _userRoleRepository = userRoleRepository;
            _menuPermissionRepository = menuPermissionRepository;
            _businessTypeRepository = businessTypeRepository;
            _subscriptionTypeRepository = subscriptionTypeRepository;


            _userLogingInfoRepository = userLogingInfoRepository;
            _userTransactionLogRepository = userTrnsactionLogRepository;
            _countryRepository = countryRepository;


            _userTerminateRepository = userTerminateRepository;

            _toDoRepository = toDoRepository;
            _productLedgerRepository = productLedgerRepository;
            _testRouterOnuTrackingRepository = testRouterOnuTrackingRepository;




            _expireDateExtendRepository = expireDateExtendRepository;


            this.configuration = configuration;

            db = context;
        }

        public IActionResult ServiceDashboard()
        {
            var today = DateTime.Today;
            var today_Plus_Threedays = today.AddDays(3);

            var month = new DateTime(today.Year, today.Month, 1);
            var first = month.AddMonths(-1);
            var last = month.AddDays(-1);


            var Currentfirst = new DateTime(today.Year, today.Month, 1);
            var Currentlast = Currentfirst.AddMonths(1).AddDays(-1);





            var dashboard = new InternetServiceDashboardViewModel
            {


                TotalCashReceived = _invoiceBillRepository.All().Where(x => x.AccountReceiveByHead.vAccountGroupHead.AccName.ToLower().Contains("Cash".ToLower())).Sum(x => x.ReceivedAmount),
                TotalBankReceived = _invoiceBillRepository.All().Where(x => x.AccountReceiveByHead.vAccountGroupHead.AccName.ToLower().Contains("Bank".ToLower()) && (!x.AccountReceiveByHead.AccName.ToLower().Contains("bkash"))).Sum(x => x.ReceivedAmount),
                TotalBkashMerchantReceived = _invoiceBillRepository.All().Where(x => x.AccountReceiveByHead.AccName.ToLower().Contains("Merchant".ToLower())).Sum(x => x.ReceivedAmount),
                TotalBkashPersonalReceived = _invoiceBillRepository.All().Where(x => x.AccountReceiveByHead.AccName.ToLower().Contains("Personal".ToLower())).Sum(x => x.ReceivedAmount),

                //TotalOtherReceived = _invoiceBillRepository.All().Where(x => x.AccountReceiveByHead.vAccountGroupHead.AccName.ToLower().Contains("Cash".ToLower()).Sum(x => x.BillAmount),


                TodaysBilledAmount = _invoiceBillRepository.All().Where(x => x.BilledDate == DateTime.Now.Date).Sum(x => x.BillAmount),
                TotalDue = _invoiceBillRepository.All().Sum(x => x.BillAmount - (x.ReceivedAmount + x.BadDebt + x.Discount)),

                TodaysReceivedAmount = _invoiceBillRepository.All().Where(x => x.ReceivedDate == DateTime.Now.Date).Sum(x => x.ReceivedAmount),
                TotalBilledAmount = _invoiceBillRepository.All().Sum(x => x.BillAmount),
                TotalReceivedAmount = _invoiceBillRepository.All().Sum(x => x.ReceivedAmount),
                TotalBadDebtAmount = _invoiceBillRepository.All().Sum(x => x.BadDebt),
                TotalDiscountAmount = _invoiceBillRepository.All().Sum(x => x.Discount),


                LastMonthReceived = _invoiceBillRepository.All().Where(x => x.ReceivedDate >= first && x.ReceivedDate <= last).Sum(x => x.ReceivedAmount),
                LastMonthDue = _invoiceBillRepository.All().Where(x => x.ReceivedDate >= first && x.ReceivedDate <= last).Sum(x => ((x.BillAmount) - (x.ReceivedAmount + x.BadDebt + x.Discount))),
                LastMonthExpense = _transactionRepository.All().Where(x => x.InputDate >= first && x.InputDate <= last && x.TransactionType.Contains("Paid")).Sum(x => x.TransactionAmount),

                CurrentMonthReceived = _invoiceBillRepository.All().Where(x => x.ReceivedDate >= Currentfirst && x.ReceivedDate <= Currentlast).Sum(x => x.ReceivedAmount),
                CurrentMonthDue = _invoiceBillRepository.All().Where(x => x.ReceivedDate >= Currentfirst && x.ReceivedDate <= Currentlast).Sum(x => ((x.BillAmount) - (x.ReceivedAmount + x.BadDebt + x.Discount))),
                CurrentMonthExpense = _transactionRepository.All().Where(x => x.InputDate >= Currentfirst && x.InputDate <= Currentlast && x.TransactionType.Contains("Paid")).Sum(x => x.TransactionAmount),


                LastFiveBilled = _invoiceBillRepository.All().OrderByDescending(x => x.Id).Take(5).ToList(),
                LastFiveReceived = _invoiceBillRepository.All().Include(x => x.AccountReceiveByHead).Where(x => x.ReceivedAmount > 0).OrderByDescending(x => x.Id).Take(5).ToList(),


                TotalRegisteredUser = _InternetUserRepository.All().Count(),// _invoiceBillRepository.All().GroupBy(p => p.UserId).Count(),
                TotalActiveUser = _InternetUserRepository.All().Where(x => x.UserStatus.UserStatusShort.ToLower().Contains("active")).Count(),//_invoiceBillRepository.All().GroupBy(p => p.UserId).Count(),
                TotalInactiveUser = _InternetUserRepository.All().Where(x => x.UserStatus.UserStatusShort.ToLower().Contains("disabled")).Count(),//_invoiceBillRepository.All().GroupBy(p => p.UserId).Count(),
                TotalExpiredUser = _InternetUserRepository.All().Where(x => x.UserStatus.UserStatusShort.ToLower().Contains("expired")).Count(),//_invoiceBillRepository.All().GroupBy(p => p.UserId).Count(),
                ExpiringInThreeDays = 0,//_invoiceBillRepository.All().GroupBy(p => p.UserId).Count(),
                TodayExpired = _InternetUserRepository.All().Where(x => x.LastExpiredDate >= DateTime.Now.Date && x.LastExpiredDate <= today_Plus_Threedays).Count(),//_invoiceBillRepository.All().GroupBy(p => p.UserId).Count(),
                TotalTerminatedUsers = _InternetUserRepository.All().Where(x => x.UserStatus.UserStatusShort.ToLower().Contains("terminated")).Count(),





            };
            return View(dashboard);
        }


        #region InternetUser
        public IActionResult InternetUserList()
        {
            //return View(_InternetUserRepository.All());
            return View();

        }

        [HttpGet]
        public ActionResult AddInternetUser()
        {
            ViewBag.ActionType = "Create";
            ViewBag.PackageId = _internetPackageRepository.GetAllForDropDown();
            ViewBag.UserStatusId = _internetUserStatusRepository.GetAllForDropDown();
            return View();
        }

        public class InternetUserResultList : InternetUserModel
        {

            public string? PackageName { get; set; }
            public string? UserStatusName { get; set; }

            public string? LastBilledDateString { get; set; }
            public string? LastExpiredDateString { get; set; }
            public string? LastReceivedDateString { get; set; }
            public string? CreateDateString { get; set; }




        }
        [AllowAnonymous]
        public JsonResult GetInternetUserList()
        {
            try
            {
                //var products= _context.Products.ToList();


                var InternetUsers = _InternetUserRepository.All(true);//.Include(x=>x.vUnit).Include(x=>x.Category);
                var query = from e in InternetUsers//.Where(x => x.Id > 0 && x.ComId == ComId).OrderByDescending(x => x.Id)

                            select new InternetUserResultList
                            {
                                Id = e.Id,
                                UserId = e.UserId,
                                Password = e.Password,
                                UserName = e.UserName,


                                LastBilledDateString = e.LastBilledDate.ToString("dd-MMM-yy"),
                                LastExpiredDateString = e.LastExpiredDate != null ? e.LastExpiredDate.GetValueOrDefault().ToString("dd-MMM-yy") : null,
                                LastReceivedDateString = e.LastReceivedDate != null ? e.LastReceivedDate.GetValueOrDefault().ToString("dd-MMM-yy") : null,

                                MobileNo = e.MobileNo,
                                Address = e.Address,

                                Amount = e.Amount,
                                ONUMac = e.ONUMac,
                                IPAddress = e.IPAddress,
                                ConnectionPointAddress = e.ConnectionPointAddress,

                                Description = e.Description,
                                CreateDateString = e.CreateDate != null ? e.CreateDate.ToString("dd-MMM-yy") : null,
                                CreatedBy = e.CreatedBy,

                                NationalIdCard = e.NationalIdCard,
                                UserStatusName = e.UserStatus != null ? e.UserStatus.UserStatusLong : null,  //e.UserStatus.HasValue == true ? "" : e.UserStatus.UserStatusLong, // e.UserStatus.UserStatusLong,
                                ImagePath = e.ImagePath,

                                PackageName = e.InternetPackageList != null ? e.InternetPackageList.PackageName : null,  //e.InternetPackageList.PackageName






                                //Email = e.Email,
                                //Address = e.Address,
                                //Notes = e.Notes,
                                //Phone = e.Phone,


                                //TotalPurchaseValue = e.AccountsDailyTransaction.Where(x => x.TransactionType == "System Purchase").Sum(x => x.TransactionAmount),
                                //TotalPayment = e.AccountsDailyTransaction.Where(x => x.TransactionType.Contains("Paid")).Sum(x => x.TransactionAmount),
                                //TotalDue = e.AccountsDailyTransaction.Where(x => x.TransactionType == "System Purchase").Sum(x => x.TransactionAmount) - e.AccountsDailyTransaction.Where(x => x.TransactionType.Contains("Paid")).Sum(x => x.TransactionAmount),
                                //LastPurchaseDate = e.Purchase.OrderByDescending(x => x.Id).FirstOrDefault().PurchaseDate.ToString("dd-MMM-yy") ?? "",
                                //LastInvoiceNo = e.Purchase.OrderByDescending(x => x.Id).FirstOrDefault().PurchaseCode ?? "",
                                //LastPurchaseProduct = e.Purchase.OrderByDescending(x => x.Id).FirstOrDefault().Items.OrderByDescending(x => x.Id).FirstOrDefault().Product.Name ?? "",


                            };



                var parser = new Parser<InternetUserResultList>(Request.Form, query);
                return Json(parser.Parse());
                //dynamic abcd = parser.Parse();
                //return Json(abcd);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult AddInternetUser(InternetUserModel model)
        {
            if (ModelState.IsValid)
            {
                if (model.Id == 0)
                {
                    _InternetUserRepository.Insert(model);


                    TempData["Message"] = "Data Save Successfully";
                    TempData["Status"] = "1";
                    tranlog.TransactionLog(RouteData.Values["controller"].ToString(), RouteData.Values["action"].ToString(), TempData["Message"].ToString(), model.Id.ToString(), "Create", model.UserName.ToString());

                }
                else
                {
                    _InternetUserRepository.Update(model, model.Id);


                    TempData["Message"] = "Data Update Successfully";
                    TempData["Status"] = "2";
                    tranlog.TransactionLog(RouteData.Values["controller"].ToString(), RouteData.Values["action"].ToString(), TempData["Message"].ToString(), model.Id.ToString(), "Update", model.UserName.ToString());

                }
                return RedirectToAction("InternetUserList");
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
        public ActionResult EditInternetUser(int InternetUserId)
        {
            ViewBag.ActionType = "Edit";
            ViewBag.PackageId = _internetPackageRepository.GetAllForDropDown();
            ViewBag.UserStatusId = _internetUserStatusRepository.GetAllForDropDown();

            var InternetUser = _InternetUserRepository.Find(InternetUserId);
            return View("AddInternetUser", InternetUser);
        }


        [HttpPost]
        [AllowAnonymous]

        public IActionResult SaveCommentModal([FromBody] TroubleTicketCommentModel model)
        {
            var errors = ModelState.Where(x => x.Value.Errors.Any())
            .Select(x => new { x.Key, x.Value.Errors });


            if (!ModelState.IsValid)
            {
                //return Json("Model is not valid");
                return Json(new { Success = 3, ex = errors });
            }
            _TroubleTicketCommentRepository.Insert(model);



            TempData["Message"] = "Data Save Successfully";
            TempData["Status"] = "1";
            tranlog.TransactionLog(RouteData.Values["controller"].ToString(), RouteData.Values["action"].ToString(), TempData["Message"].ToString(), model.Id.ToString(), "Create", model.Comment.ToString());

            return Json(new { Success = 1, ex = "Comment Added Successfully" });
            //return Json("Product Added Successfully");
        }

        public ActionResult DeleteInternetUser(int InternetUserId)
        {
            var model = _InternetUserRepository.Find(InternetUserId);
            if (model != null)
            {
                _InternetUserRepository.Delete(model);

                TempData["Message"] = "Data Delete Successfully";
                TempData["Status"] = "3";
                tranlog.TransactionLog(RouteData.Values["controller"].ToString(), RouteData.Values["action"].ToString(), TempData["Message"].ToString(), model.Id.ToString(), "Delete", model.UserName);



                return RedirectToAction("InternetUserList");
            }
            return RedirectToAction("InternetUserList");
        }
        #endregion

        #region ExpireDateExtend
        public IActionResult ExpireDateExtendList()
        {
            //return View(_ExpireDateExtendRepository.All());



            return View();

        }

        [HttpGet]
        public ActionResult AddExpireDateExtend()
        {
            ViewBag.ActionType = "Create";

            ExpireDateExtendModel abc = new ExpireDateExtendModel();
            abc.OldExpireDate = DateTime.Now.Date;
            abc.NewExpiredDate = DateTime.Now.Date;

            //ViewBag.PackageId = _internetPackageRepository.GetAllForDropDown();
            //ViewBag.UserStatusId = _internetUserStatusRepository.GetAllForDropDown();
            return View();
        }

        public class ExpireDateExtendResultList : ExpireDateExtendModel
        {
            public string? NewExpiredDateString { get; set; }
            public string? OldExpireDateString { get; set; }
            //public string? UserId { get; set; }
            //public string? UserName { get; set; }




        }

        [AllowAnonymous]
        public JsonResult GetExpireDateExtendList()
        {
            try
            {
                //var products= _context.Products.ToList();


                var ExpireDateExtends = _expireDateExtendRepository.All();
                var query = from e in ExpireDateExtends

                            select new ExpireDateExtendResultList
                            {
                                Id = e.Id,
                                UserId = e.InternetUserList.UserId,
                                UserName = e.InternetUserList.UserName,
                                InternetUserId = e.InternetUserId,
                                OldExpireDateString = e.OldExpireDate.ToString("dd-MMM-yy"),
                                NewExpiredDateString = e.NewExpiredDate.ToString("dd-MMM-yy"),
                                Note = e.Note,
                                TotalDays = int.Parse((e.NewExpiredDate - e.OldExpireDate).TotalDays.ToString()),
                                CreateDate = e.CreateDate,
                                //UserName = e.InternetUserList != null ? e.InternetUserList.UserName : null
                            };



                var parser = new Parser<ExpireDateExtendResultList>(Request.Form, query);
                return Json(parser.Parse());
                //dynamic abcd = parser.Parse();
                //return Json(abcd);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult AddExpireDateExtend(ExpireDateExtendModel model)
        {
            if (ModelState.IsValid)
            {
                if (model.Id == 0)
                {
                    if (model.Note == null) model.Note = "Validity Extend";

                    _expireDateExtendRepository.Insert(model);

                    var internetuserdata = _InternetUserRepository.Find(model.InternetUserId);
                    internetuserdata.LastExpiredDate = model.NewExpiredDate;
                    _InternetUserRepository.Update(internetuserdata, internetuserdata.Id);


                    TempData["Message"] = "Data Save Successfully";
                    TempData["Status"] = "1";
                    tranlog.TransactionLog(RouteData.Values["controller"].ToString(), RouteData.Values["action"].ToString(), TempData["Message"].ToString(), model.Id.ToString(), "Create", model.Note.DefaultIfEmpty().ToString());

                }
                else
                {
                    if (model.Note == null) model.Note = "Validity Extend";
                    _expireDateExtendRepository.Update(model, model.Id);

                    var internetuserdata = _InternetUserRepository.Find(model.InternetUserId);
                    internetuserdata.LastExpiredDate = model.NewExpiredDate;
                    _InternetUserRepository.Update(internetuserdata, internetuserdata.Id);


                    TempData["Message"] = "Data Update Successfully";
                    TempData["Status"] = "2";
                    tranlog.TransactionLog(RouteData.Values["controller"].ToString(), RouteData.Values["action"].ToString(), TempData["Message"].ToString(), model.Id.ToString(), "Update", model.Note.DefaultIfEmpty().ToString());

                }
                return RedirectToAction("ExpireDateExtendList");
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
        public ActionResult EditExpireDateExtend(int ExpireDateExtendId)
        {
            ViewBag.ActionType = "Edit";
            //ViewBag.PackageId = _internetPackageRepository.GetAllForDropDown();
            //ViewBag.UserStatusId = _internetUserStatusRepository.GetAllForDropDown();

            //var ExpireDateExtend = _expireDateExtendRepository.Find(ExpireDateExtendId);


            var ExpireDateExtend = _expireDateExtendRepository.All().Include(x => x.InternetUserList).Where(x => x.Id == ExpireDateExtendId).FirstOrDefault();

            if (ExpireDateExtend != null)
            {
                ExpireDateExtend.UserId = ExpireDateExtend.InternetUserList.UserId;
                ExpireDateExtend.UserName = ExpireDateExtend.InternetUserList.UserName;
            }


            return View("AddExpireDateExtend", ExpireDateExtend);
        }

        public ActionResult DeleteExpireDateExtend(int ExpireDateExtendId)
        {
            var model = _expireDateExtendRepository.Find(ExpireDateExtendId);
            if (model != null)
            {
                _expireDateExtendRepository.Delete(model);

                TempData["Message"] = "Data Delete Successfully";
                TempData["Status"] = "3";
                tranlog.TransactionLog(RouteData.Values["controller"].ToString(), RouteData.Values["action"].ToString(), TempData["Message"].ToString(), model.Id.ToString(), "Delete", model.Note);



                return RedirectToAction("ExpireDateExtendList");
            }
            return RedirectToAction("ExpireDateExtendList");
        }
        #endregion

        #region UserTerminate
        public IActionResult UserTerminateList()
        {
            //return View(_UserTerminateRepository.All());
            return View();

        }

        [HttpGet]
        public ActionResult AddUserTerminate()
        {
            ViewBag.ActionType = "Create";

            UserTerminateModel abc = new UserTerminateModel();
            abc.TerminateDate = DateTime.Now.Date;
            abc.NextFollowDate = DateTime.Now.Date;


            //ViewBag.PackageId = _internetPackageRepository.GetAllForDropDown();
            //ViewBag.UserStatusId = _internetUserStatusRepository.GetAllForDropDown();
            return View(abc);
        }

        public class UserTerminateResultList : UserTerminateModel
        {
            public string? UserName { get; set; }
            public string? TerminateDateString { get; set; }
            public string? NextFollowDateString { get; set; }
            public string? CreateDateString { get; set; }


        }

        [AllowAnonymous]
        public JsonResult GetUserTerminateList()
        {
            try
            {
                //var products= _context.Products.ToList();


                var UserTerminates = _userTerminateRepository.All();
                var query = from e in UserTerminates

                            select new UserTerminateResultList
                            {
                                Id = e.Id,
                                InternetUserId = e.InternetUserId,
                                //e.LastReceivedDate != null ? e.LastReceivedDate.GetValueOrDefault().ToString("dd-MMM-yy") : null,
                                TerminateDateString = e.TerminateDate != null ? e.TerminateDate.ToString("dd-MMM-yy") : null,
                                NextFollowDateString = e.NextFollowDate != null ? e.NextFollowDate.ToString("dd-MMM-yy") : null,
                                CreateDateString = e.CreateDate != null ? e.CreateDate.ToString("dd-MMM-yy") : null,

                                Note = e.Note,
                                DeviceUpdate = e.DeviceUpdate,
                                MobileNoIfNecessary = e.MobileNoIfNecessary,
                                CreateDate = e.CreateDate,
                                UserName = e.InternetUserList != null ? e.InternetUserList.UserId : null

                            };



                var parser = new Parser<UserTerminateResultList>(Request.Form, query);
                return Json(parser.Parse());
                //dynamic abcd = parser.Parse();
                //return Json(abcd);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult AddUserTerminate(UserTerminateModel model)
        {
            if (ModelState.IsValid)
            {
                if (model.Id == 0)
                {
                    _userTerminateRepository.Insert(model);

                    var internetuserdata = _InternetUserRepository.Find(model.InternetUserId);
                    internetuserdata.UserStatusId = 2;
                    _InternetUserRepository.Update(internetuserdata, internetuserdata.Id);


                    TempData["Message"] = "Data Save Successfully";
                    TempData["Status"] = "1";
                    tranlog.TransactionLog(RouteData.Values["controller"].ToString(), RouteData.Values["action"].ToString(), TempData["Message"].ToString(), model.Id.ToString(), "Create", model.Note.ToString());




                }
                else
                {
                    _userTerminateRepository.Update(model, model.Id);


                    TempData["Message"] = "Data Update Successfully";
                    TempData["Status"] = "2";
                    tranlog.TransactionLog(RouteData.Values["controller"].ToString(), RouteData.Values["action"].ToString(), TempData["Message"].ToString(), model.Id.ToString(), "Update", model.Note.ToString());

                }
                return RedirectToAction("UserTerminateList");
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
        public ActionResult EditUserTerminate(int UserTerminateId)
        {
            ViewBag.ActionType = "Edit";
            //ViewBag.PackageId = _internetPackageRepository.GetAllForDropDown();
            //ViewBag.UserStatusId = _internetUserStatusRepository.GetAllForDropDown();

            var UserTerminate = _userTerminateRepository.All().Include(x => x.InternetUserList).Where(x => x.Id == UserTerminateId).FirstOrDefault();

            if (UserTerminate != null)
            {
                UserTerminate.UserId = UserTerminate.InternetUserList.UserId;
                UserTerminate.UserName = UserTerminate.InternetUserList.UserName;
            }

            return View("AddUserTerminate", UserTerminate);

        }

        public ActionResult DeleteUserTerminate(int UserTerminateId)
        {
            var model = _userTerminateRepository.Find(UserTerminateId);
            if (model != null)
            {
                _userTerminateRepository.Delete(model);


                var internetuserdata = _InternetUserRepository.Find(model.InternetUserId);
                internetuserdata.UserStatusId = 1;
                _InternetUserRepository.Update(internetuserdata, internetuserdata.Id);


                TempData["Message"] = "Data Delete Successfully";
                TempData["Status"] = "3";
                tranlog.TransactionLog(RouteData.Values["controller"].ToString(), RouteData.Values["action"].ToString(), TempData["Message"].ToString(), model.Id.ToString(), "Delete", model.Note);



                return RedirectToAction("UserTerminateList");
            }
            return RedirectToAction("UserTerminateList");
        }
        #endregion

        #region ProductLedger
        public IActionResult ProductLedgerList()
        {
            //return View(_productLedgerRepository.All());
            return View();

        }

        [HttpGet]
        public ActionResult AddProductLedger()
        {
            ViewBag.ActionType = "Create";

            ProductLedgerModel abc = new ProductLedgerModel();
            abc.EntryDate = DateTime.Now.Date;


            //ViewBag.PackageId = _internetPackageRepository.GetAllForDropDown();
            //ViewBag.UserStatusId = _internetUserStatusRepository.GetAllForDropDown();
            return View(abc);
        }

        public class ProductLedgerResultList : ProductLedgerModel
        {

            public string? EntryDateString { get; set; }

            public string? ProductName { get; set; }




        }

        [AllowAnonymous]

        public JsonResult GetProductLedgerList()
        {
            try
            {
                //var products= _context.Products.ToList();


                var ProductLedgers = _productLedgerRepository.All();
                var query = from e in ProductLedgers

                            select new ProductLedgerResultList
                            {
                                Id = e.Id,
                                InternetUserId = e.InternetUserId,
                                EntryDateString = e.EntryDate != null ? e.EntryDate.ToString("dd-MMM-yy") : null,
                                PrdDescription = e.PrdDescription,
                                ProductName = e.ProductList.Name,
                                Subject = e.Subject,
                                TicketId = e.TicketId,
                                Quantity = e.Quantity,
                                UserId = e.InternetUserList != null ? e.InternetUserList.UserId : null,
                                UserName = e.InternetUserList != null ? e.InternetUserList.UserName : null,
                                Referance = e.Referance,
                                ReceivedBy = e.ReceivedBy,
                                Comment = e.Comment,
                                TeamType = e.TeamType
                            };



                var parser = new Parser<ProductLedgerResultList>(Request.Form, query);
                return Json(parser.Parse());
                //dynamic abcd = parser.Parse();
                //return Json(abcd);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult AddProductLedger(ProductLedgerModel model)
        {
            var errors = ModelState.Where(x => x.Value.Errors.Any())
        .Select(x => new { x.Key, x.Value.Errors });
            if (ModelState.IsValid)
            {
                if (model.Id == 0)
                {
                    _productLedgerRepository.Insert(model);


                    TempData["Message"] = "Data Save Successfully";
                    TempData["Status"] = "1";
                    tranlog.TransactionLog(RouteData.Values["controller"].ToString(), RouteData.Values["action"].ToString(), TempData["Message"].ToString(), model.Id.ToString(), "Create", model.InternetUserId.ToString());




                }
                else
                {
                    _productLedgerRepository.Update(model, model.Id);


                    TempData["Message"] = "Data Update Successfully";
                    TempData["Status"] = "2";
                    tranlog.TransactionLog(RouteData.Values["controller"].ToString(), RouteData.Values["action"].ToString(), TempData["Message"].ToString(), model.Id.ToString(), "Update", model.InternetUserId.ToString());

                }
                return RedirectToAction("ProductLedgerList");
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
        public ActionResult EditProductLedger(int ProductLedgerId)
        {
            ViewBag.ActionType = "Edit";
            //ViewBag.PackageId = _internetPackageRepository.GetAllForDropDown();
            //ViewBag.UserStatusId = _internetUserStatusRepository.GetAllForDropDown();

            var ProductLedger = _productLedgerRepository.All().Include(x => x.InternetUserList).Include(x => x.ProductList).Where(x => x.Id == ProductLedgerId).FirstOrDefault();

            if (ProductLedger != null)
            {
                ProductLedger.UserId = ProductLedger.InternetUserList.UserId;
                ProductLedger.UserName = ProductLedger.InternetUserList.UserName;
                ProductLedger.ProductName = ProductLedger.ProductList.Name;

            }

            return View("AddProductLedger", ProductLedger);

        }

        public ActionResult DeleteProductLedger(int ProductLedgerId)
        {
            var model = _productLedgerRepository.Find(ProductLedgerId);
            if (model != null)
            {
                _productLedgerRepository.Delete(model);


                TempData["Message"] = "Data Delete Successfully";
                TempData["Status"] = "3";
                tranlog.TransactionLog(RouteData.Values["controller"].ToString(), RouteData.Values["action"].ToString(), TempData["Message"].ToString(), model.Id.ToString(), "Delete", model.TeamType);



                return RedirectToAction("ProductLedgerList");
            }
            return RedirectToAction("ProductLedgerList");
        }
        #endregion

        #region TestRouterOnuTracking
        public IActionResult TestRouterOnuTrackingList()
        {
            //return View(_productLedgerRepository.All());
            return View();

        }

        [HttpGet]
        public ActionResult AddTestRouterOnuTracking()
        {
            ViewBag.ActionType = "Create";

            TestRouterOnuTrackingModel abc = new TestRouterOnuTrackingModel();
            abc.EntryDate = DateTime.Now.Date;
            abc.WithdrawnDate = DateTime.Now.Date;



            //ViewBag.PackageId = _testRouterOnuTrackingRepository.GetAllForDropDown();
            //ViewBag.UserStatusId = _internetUserStatusRepository.GetAllForDropDown();
            return View(abc);
        }

        public class TestRouterOnuTrackingResultList : TestRouterOnuTrackingModel
        {

            public string? EntryDateString { get; set; }

            public string? WithdrawnDateString { get; set; }




        }

        [AllowAnonymous]
        public JsonResult GetTestRouterOnuTrackingList()
        {
            try
            {
                //var products= _context.Products.ToList();


                var TestRouterOnuTrackings = _testRouterOnuTrackingRepository.All();
                var query = from e in TestRouterOnuTrackings

                            select new TestRouterOnuTrackingResultList
                            {
                                Id = e.Id,
                                InternetUserId = e.InternetUserId,
                                EntryDateString = e.EntryDate != null ? e.EntryDate.ToString("dd-MMM-yy") : null,
                                WithdrawnDateString = e.WithdrawnDate != null ? e.WithdrawnDate.ToString("dd-MMM-yy") : null,

                                PrdDescription = e.PrdDescription,
                                ProductName = e.ProductList.Name,
                                MacSerial = e.MacSerial,
                                Status = e.Status,
                                UserId = e.InternetUserList != null ? e.InternetUserList.UserId : null,
                                UserName = e.InternetUserList != null ? e.InternetUserList.UserName : null,
                                GivenBy = e.GivenBy,
                                WithdrawnBy = e.WithdrawnBy,
                                Note = e.Note
                            };



                var parser = new Parser<TestRouterOnuTrackingResultList>(Request.Form, query);
                return Json(parser.Parse());
                //dynamic abcd = parser.Parse();
                //return Json(abcd);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult AddTestRouterOnuTracking(TestRouterOnuTrackingModel model)
        {
            var errors = ModelState.Where(x => x.Value.Errors.Any())
        .Select(x => new { x.Key, x.Value.Errors });
            if (ModelState.IsValid)
            {
                if (model.Id == 0)
                {
                    _testRouterOnuTrackingRepository.Insert(model);


                    TempData["Message"] = "Data Save Successfully";
                    TempData["Status"] = "1";
                    tranlog.TransactionLog(RouteData.Values["controller"].ToString(), RouteData.Values["action"].ToString(), TempData["Message"].ToString(), model.Id.ToString(), "Create", model.InternetUserId.ToString());

                }
                else
                {
                    _testRouterOnuTrackingRepository.Update(model, model.Id);


                    TempData["Message"] = "Data Update Successfully";
                    TempData["Status"] = "2";
                    tranlog.TransactionLog(RouteData.Values["controller"].ToString(), RouteData.Values["action"].ToString(), TempData["Message"].ToString(), model.Id.ToString(), "Update", model.InternetUserId.ToString());

                }
                return RedirectToAction("TestRouterOnuTrackingList");
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
        public ActionResult EditTestRouterOnuTracking(int TestRouterOnuTrackingId)
        {
            ViewBag.ActionType = "Edit";


            var TestRouterOnuTracking = _testRouterOnuTrackingRepository.All().Include(x => x.InternetUserList).Include(x => x.ProductList).Where(x => x.Id == TestRouterOnuTrackingId).FirstOrDefault();

            if (TestRouterOnuTracking != null)
            {
                TestRouterOnuTracking.UserId = TestRouterOnuTracking.InternetUserList.UserId;
                TestRouterOnuTracking.UserName = TestRouterOnuTracking.InternetUserList.UserName;
                TestRouterOnuTracking.ProductName = TestRouterOnuTracking.ProductList.Name;

            }

            return View("AddTestRouterOnuTracking", TestRouterOnuTracking);

        }

        public ActionResult DeleteTestRouterOnuTracking(int TestRouterOnuTrackingId)
        {
            var model = _testRouterOnuTrackingRepository.Find(TestRouterOnuTrackingId);
            if (model != null)
            {
                _testRouterOnuTrackingRepository.Delete(model);


                TempData["Message"] = "Data Delete Successfully";
                TempData["Status"] = "3";
                tranlog.TransactionLog(RouteData.Values["controller"].ToString(), RouteData.Values["action"].ToString(), TempData["Message"].ToString(), model.Id.ToString(), "Delete", model.PrdDescription);



                return RedirectToAction("TestRouterOnuTrackingList");
            }
            return RedirectToAction("TestRouterOnuTrackingList");
        }
        #endregion

        #region ToDo
        public IActionResult ToDoList()
        {
            //return View(_toDoRepository.All());
            return View();

        }

        [HttpGet]
        public ActionResult AddToDo()
        {
            ViewBag.ActionType = "Create";

            ToDoModel abc = new ToDoModel();
            abc.EntryDate = DateTime.Now.Date;


            //ViewBag.PackageId = _internetPackageRepository.GetAllForDropDown();
            //ViewBag.UserStatusId = _internetUserStatusRepository.GetAllForDropDown();
            return View(abc);
        }

        public class ToDoResultList : ToDoModel
        {
            public string? EntryDateString { get; set; }


        }

        [AllowAnonymous]
        public JsonResult GetToDoList()
        {
            try
            {
                //var products= _context.Products.ToList();


                var ToDos = _toDoRepository.All();
                var query = from e in ToDos

                            select new ToDoResultList
                            {
                                Id = e.Id,
                                InternetUserId = e.InternetUserId,
                                EntryDateString = e.EntryDate != null ? e.EntryDate.ToString("dd-MMM-yy") : null,
                                Subject = e.Subject,
                                Description = e.Description,

                                TicketId = e.TicketId,
                                StaffComment = e.StaffComment,
                                AssaignFusionTeam = e.AssaignFusionTeam,
                                Status = e.Status,
                                Comment = e.Comment,


                                CreateDate = e.CreateDate,
                                UpdateDate = e.UpdateDate,

                                UserName = e.InternetUserList != null ? e.InternetUserList.UserId : null,
                                UserId = e.InternetUserList != null ? e.InternetUserList.UserId : null,

                            };



                var parser = new Parser<ToDoResultList>(Request.Form, query);
                return Json(parser.Parse());
                //dynamic abcd = parser.Parse();
                //return Json(abcd);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult AddToDo(ToDoModel model)
        {
            if (ModelState.IsValid)
            {
                if (model.Id == 0)
                {
                    _toDoRepository.Insert(model);


                    TempData["Message"] = "Data Save Successfully";
                    TempData["Status"] = "1";
                    tranlog.TransactionLog(RouteData.Values["controller"].ToString(), RouteData.Values["action"].ToString(), TempData["Message"].ToString(), model.Id.ToString(), "Create", model.Subject);




                }
                else
                {
                    _toDoRepository.Update(model, model.Id);


                    TempData["Message"] = "Data Update Successfully";
                    TempData["Status"] = "2";
                    tranlog.TransactionLog(RouteData.Values["controller"].ToString(), RouteData.Values["action"].ToString(), TempData["Message"].ToString(), model.Id.ToString(), "Update", model.Subject);

                }
                return RedirectToAction("ToDoList");
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
        public ActionResult EditToDo(int ToDoId)
        {
            ViewBag.ActionType = "Edit";
            //ViewBag.PackageId = _internetPackageRepository.GetAllForDropDown();
            //ViewBag.UserStatusId = _internetUserStatusRepository.GetAllForDropDown();

            var ToDo = _toDoRepository.All().Include(x => x.InternetUserList).Where(x => x.Id == ToDoId).FirstOrDefault();

            if (ToDo != null)
            {
                ToDo.UserId = ToDo.InternetUserList.UserId;
                ToDo.UserName = ToDo.InternetUserList.UserName;
            }

            return View("AddToDo", ToDo);

        }

        public ActionResult DeleteToDo(int ToDoId)
        {
            var model = _toDoRepository.Find(ToDoId);
            if (model != null)
            {
                _toDoRepository.Delete(model);



                TempData["Message"] = "Data Delete Successfully";
                TempData["Status"] = "3";
                tranlog.TransactionLog(RouteData.Values["controller"].ToString(), RouteData.Values["action"].ToString(), TempData["Message"].ToString(), model.Id.ToString(), "Delete", model.Subject);
            }
            return RedirectToAction("ToDoList");
        }
        #endregion

        #region json
        [AllowAnonymous]

        public JsonResult Products(string query)
        {
            var UserId = HttpContext.Session.GetInt32("UserId");
            var ComId = HttpContext.Session.GetInt32("ComId");

            return Json(_productRepository.All().Where(x => (x.Name.ToLower().Contains(query.ToLower())) || (x.Description.ToLower().Contains(query.ToLower())) || (x.Code.ToLower().Contains(query.ToLower())) || (x.Category.Name.ToLower().Contains(query.ToLower()))).Take(10));
        }


        [AllowAnonymous]

        public JsonResult internetuserIddata(string query)
        {
            try
            {


                var invoiceuserinfo = _InternetUserRepository.All().Where(x => x.UserId.ToLower().Contains(query.ToLower())).Take(10)
                .Select(x => new { UserId = x.UserId, UserName = x.UserName, Id = x.Id })
                //.GroupBy(x => new { x.UserId, x.UserName })
                //.Select(g => new { UserId = g.Key.UserId, UserName = g.Key.UserName, Id = g.Max(x => x.Id) })
                .ToList();


                return Json(invoiceuserinfo);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        [AllowAnonymous]

        public JsonResult internetuserIddataforExpire(string query)
        {
            try
            {


                var invoiceuserinfo = _InternetUserRepository.All().Where(x => x.UserId.ToLower().Contains(query.ToLower())).Take(10)
                .Select(x => new { UserId = x.UserId, UserName = x.UserName, Id = x.Id, LastExpireDate = x.LastExpiredDate.GetValueOrDefault().ToString("dd-MMM-yy"), testdate = x.LastExpiredDate })
                //.GroupBy(x => new { x.UserId, x.UserName })
                //.Select(g => new { UserId = g.Key.UserId, UserName = g.Key.UserName, Id = g.Max(x => x.Id) })
                .ToList();


                return Json(invoiceuserinfo);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }




        [AllowAnonymous]

        public JsonResult billuserIddata(string query)
        {
            try
            {



                var invoiceuserinfo = _invoiceBillRepository.All().Where(x => x.UserId.ToLower().Contains(query.ToLower()))
                .GroupBy(x => new { x.UserId, x.UserName, x.InternetUserId })
                .Select(g => new { UserId = g.Key.UserId, UserName = g.Key.UserName, InternetUserId = g.Key.InternetUserId, Id = g.Max(x => x.Id) })
                .ToList().Take(20);


                return Json(invoiceuserinfo);
            }
            catch (Exception ex)
            {

                throw ex;
            }

            //return Json(_invoiceBillRepository.All().Where(x => x.UserId.ToLower().Contains(query.ToLower())).Take(10));
        }
        [AllowAnonymous]

        public JsonResult BillAmountbyId(int query)
        {
            var UserId = HttpContext.Session.GetInt32("UserId");
            var ComId = HttpContext.Session.GetInt32("ComId");

            var invoiceuserinfo = _invoiceBillRepository.All().Where(x => x.Id == query).FirstOrDefault();

            return Json(invoiceuserinfo);

            //return Json(_invoiceBillRepository.All().GroupBy(x=>x.UserId).Where(x => x.UserName.ToLower().Contains(query.ToLower())).Take(10));

        }
        [AllowAnonymous]

        public JsonResult billuserNamedata(string query)
        {
            var UserId = HttpContext.Session.GetInt32("UserId");
            var ComId = HttpContext.Session.GetInt32("ComId");

            var invoiceuserinfo = _invoiceBillRepository.All().Where(x => x.UserName.Contains(query.ToLower()))
                                    .GroupBy(x => x.UserId)
                                    .Select(grp => grp.OrderByDescending(x => x.Id).First())
                                    .ToList();

            return Json(invoiceuserinfo.Take(10));

            //return Json(_invoiceBillRepository.All().GroupBy(x=>x.UserId).Where(x => x.UserName.ToLower().Contains(query.ToLower())).Take(10));

        }


        #endregion

        #region UserAccount 
        [HttpGet]
        public ActionResult UserAccount()
        {
            var BusinessTypeId = 0;
            //ViewBag.Role = _userRoleRepository.GetAllForDropDown();
            var ComId = HttpContext.Session.GetInt32("ComId");

            //var ComId = HttpContext.Session.GetInt32("ComId");
            var SelectedBusinessTypes = _storeSettingRepository.All().FirstOrDefault();

            if (SelectedBusinessTypes != null)
                BusinessTypeId = SelectedBusinessTypes.BusinessTypeId;

            ViewBag.Role = _userRoleRepository.GetAllForDropDownWithCondition(BusinessTypeId, ComId);

            return View(_userAccountRepository.All().Include(x => x.UserRole));

        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult UserAccount(UserAccountModel model)
        {
            var errors = ModelState.Where(x => x.Value.Errors.Any())
            .Select(x => new { x.Key, x.Value.Errors });

            //if (ModelState.IsValid)
            //{
            _userAccountRepository.Insert(model);


            TempData["Message"] = "Data Save Successfully";
            TempData["Status"] = "1";
            tranlog.TransactionLog(RouteData.Values["controller"].ToString(), RouteData.Values["action"].ToString(), TempData["Message"].ToString(), model.Id.ToString(), "Create", model.Name.ToString());


            return RedirectToAction("UserAccount");
            //}
            //return View(); // _userAccountRepository.All()
        }
        [HttpGet]
        public ActionResult EditUserAccount(int UserAccountId)
        {
            ViewBag.ActionType = "Edit";
            var BusinessTypeId = 0;

            var SelectedBusinessTypes = _storeSettingRepository.All().FirstOrDefault();

            if (SelectedBusinessTypes != null)
                BusinessTypeId = SelectedBusinessTypes.BusinessTypeId;
            var ComId = HttpContext.Session.GetInt32("ComId");

            var UserAccount = _userAccountRepository.Find(UserAccountId);
            ViewBag.Role = _userRoleRepository.GetAllForDropDownWithCondition(BusinessTypeId, ComId);
            return View(UserAccount);
        }

        public ActionResult DeleteUserAccount(int UserAccountId)
        {
            var model = _userAccountRepository.Find(UserAccountId);
            if (model != null)
            {
                _userAccountRepository.Delete(model);


                TempData["Message"] = "Data Delete Successfully";
                TempData["Status"] = "3";
                tranlog.TransactionLog(RouteData.Values["controller"].ToString(), RouteData.Values["action"].ToString(), TempData["Message"].ToString(), model.Id.ToString(), "Delete", model.Name);


                return RedirectToAction("UserAccount");
            }
            return RedirectToAction("UserAccount");
        }



        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult EditUserAccount(UserAccountModel model)
        {
            var errors = ModelState.Where(x => x.Value.Errors.Any())
        .Select(x => new { x.Key, x.Value.Errors });

            if (!ModelState.IsValid)
                return View(model);


            //model.LuserId = 0;
            _userAccountRepository.Update(model, model.Id);


            TempData["Message"] = "Data Update Successfully";
            TempData["Status"] = "2";
            tranlog.TransactionLog(RouteData.Values["controller"].ToString(), RouteData.Values["action"].ToString(), TempData["Message"].ToString(), model.Id.ToString(), "Update", model.Name.ToString());

            return RedirectToAction("UserAccount");
        }

        #endregion UserAccount

        #region invoiceBillforfnf

        [HttpGet]
        public ActionResult AddInvoiceBill()
        {
            ViewBag.CashBankHead = _accountHeadRepository.GetCashBankHeadForDropDown();
            ViewBag.ActionType = "Create";
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public JsonResult AddInvoiceBill(InvoiceBillModel model)
        {
            try
            {
                var errors = ModelState.Where(x => x.Value.Errors.Any())
                   .Select(x => new { x.Key, x.Value.Errors });


                if (ModelState.IsValid)
                {
                    if (model.Id == 0)
                    {
                        model.ExpiredDate = model.BilledDate.AddMonths(1);
                        if (model.ReceivedAmount == 0)
                            model.ReceivedDate = null;


                        _invoiceBillRepository.Insert(model);

                        var internetuser = _InternetUserRepository.All().Where(x => x.UserId == model.UserId).FirstOrDefault();
                        if (internetuser == null)
                        {
                            internetuser = new InternetUserModel();
                            internetuser.UserId = model.UserId;
                            internetuser.UserName = model.UserName;
                            internetuser.Amount = model.BillAmount;
                            internetuser.CreatedOn = model.CreateDate;
                            internetuser.CreatedBy = "System";
                            internetuser.LastBilledDate = model.BilledDate;
                            internetuser.UserStatusId = 1;
                            internetuser.IsDelete = false;


                            internetuser.LastReceivedDate = model.ReceivedAmount == 0 ? model.ReceivedDate : null; //model.ReceivedDate;
                            internetuser.LastExpiredDate = model.BilledDate.AddMonths(1);

                            //internetuser.Amount = model.BillAmount;
                            _InternetUserRepository.Insert(internetuser);


                            model.InternetUserId = internetuser.Id;
                            _invoiceBillRepository.Update(model, model.Id);
                        }
                        else
                        {

                            internetuser.LastReceivedDate = model.ReceivedAmount == 0 ? model.ReceivedDate : null; //model.ReceivedDate;
                            internetuser.LastExpiredDate = model.BilledDate.AddMonths(1);

                            var expiredatedata = _expireDateExtendRepository.All().Where(x => x.InternetUserId == model.InternetUserId).OrderByDescending(x => x.Id).FirstOrDefault().NewExpiredDate;
                            if (expiredatedata != null && expiredatedata > internetuser.LastExpiredDate)
                            {
                                internetuser.LastExpiredDate = expiredatedata;

                            }

                            _InternetUserRepository.Update(internetuser, internetuser.Id);

                        }


                        TempData["Message"] = "Data Save Successfully";
                        TempData["Status"] = "1";
                        tranlog.TransactionLog(RouteData.Values["controller"].ToString(), RouteData.Values["action"].ToString(), TempData["Message"].ToString(), model.Id.ToString(), "Create", model.UserId != null ? model.UserName : "");

                    }
                    else
                    {
                        model.ExpiredDate = model.BilledDate.AddMonths(1);
                        if (model.ReceivedAmount == 0)
                            model.ReceivedDate = null;

                        _invoiceBillRepository.Update(model, model.Id);


                        var internetuser = _InternetUserRepository.All().Where(x => x.Id == model.InternetUserId).FirstOrDefault();
                        if (internetuser != null)
                        {
                            //internetuser = new InternetUserModel();
                            internetuser.UserId = model.UserId;
                            internetuser.UserName = model.UserName;
                            internetuser.Amount = model.BillAmount;
                            internetuser.CreatedOn = model.CreateDate;
                            internetuser.CreatedBy = "System";
                            internetuser.LastBilledDate = model.BilledDate;
                            internetuser.LastReceivedDate = model.ReceivedAmount == 0 ? model.ReceivedDate : null; //model.ReceivedDate;
                            internetuser.LastExpiredDate = model.BilledDate.AddMonths(1);

                            //internetuser.Amount = model.BillAmount;
                            _InternetUserRepository.Update(internetuser, internetuser.Id);
                        }


                        TempData["Message"] = "Data Update Successfully";
                        TempData["Status"] = "2";
                        tranlog.TransactionLog(RouteData.Values["controller"].ToString(), RouteData.Values["action"].ToString(), TempData["Message"].ToString(), model.Id.ToString(), "Update", model.UserId != null ? model.UserName : "");

                    }

                    return Json(new { Success = 1, Id = model.Id, ex = TempData["Message"] });

                    //return RedirectToAction("AddInvoiceBill");
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

                    //return View(model);
                    return Json(new { Success = 0, Id = model.Id, ex = "Some Error Occured !!!" });
                }
            }
            catch (Exception ex)
            {

                return Json(new { Success = 0, Id = model.Id, ex = ex });
            }
        }


        [HttpGet]
        public ActionResult EditInvoiceBill(int InvoiceBillId)
        {
            ViewBag.ActionType = "Edit";
            var Transaction = _invoiceBillRepository.Find(InvoiceBillId);
            ViewBag.CashBankHead = _accountHeadRepository.GetCashBankHeadForDropDown();




            return View("AddInvoiceBill", Transaction);
        }

        [HttpGet]
        public ActionResult ViewInvoiceBill(int InvoiceBillId)
        {
            ViewBag.ActionType = "View";
            var Transaction = _invoiceBillRepository.Find(InvoiceBillId);
            ViewBag.CashBankHead = _accountHeadRepository.GetCashBankHeadForDropDown();

            return View("AddInvoiceBill", Transaction);
        }

        public ActionResult DeleteInvoicebill(int InvoiceBillId)
        {
            var model = _invoiceBillRepository.Find(InvoiceBillId);
            if (model != null)
            {
                _invoiceBillRepository.Delete(model);

                TempData["Message"] = "Data Delete Successfully";
                TempData["Status"] = "3";
                tranlog.TransactionLog(RouteData.Values["controller"].ToString(), RouteData.Values["action"].ToString(), TempData["Message"].ToString(), model.Id.ToString(), "Delete", model.UserId != null ? model.UserName : "");


                return RedirectToAction("InvoiceBillList");
            }
            return RedirectToAction("InvoiceBillList");
        }


        public IActionResult InvoicebillList()
        {
            ViewBag.User = _userAccountRepository.UserAccountForDropdown();
            //ViewBag.User = _invoiceBillRepository.UserAccountForDropdown();

            return View();
        }
        [AllowAnonymous]
        public IActionResult InvoiceBillPrint(int InvoiceBillId)
        {
            var weburl = HttpContext.Session.GetString("weburl"); //"https://pqstec.com/invoiceapps/Home/login/?ReturnUrl=%2Finvoiceapps%2FInternet%2FInvoiceBillList";// 
            //var origin = weburl;
            //var controllerName = this.ControllerContext.RouteData.Values["Controller"].ToString().ToLower();

            //String St = weburl.ToLower();

            //int pFrom = St.IndexOf("/") + "/".Length;
            //int pTo = St.LastIndexOf("/" + controllerName);

            //string result = "";
            //if (pTo < 1)
            //{
            //    result = origin;

            //}
            //else
            //{
            //    result = St.Substring(pFrom, pTo - pFrom);
            //    result = origin + "/" + result;

            //}

            errorlog(weburl);

            var UserId = HttpContext.Session.GetInt32("UserId");
            var ComId = HttpContext.Session.GetInt32("ComId");


            string reportname = "rptInvoiceBill";

            //var ab = _invoiceBillRepository.Find(InvoiceBillId).BillNo;
            string filename = _invoiceBillRepository.All().Where(x => x.Id == InvoiceBillId).Select(x => x.UserId + "_" + x.BillNo).Single();
            //var filename = "Invoice_BIll_";
            //string apppath = "";

            HttpContext.Session.SetString("ReportQuery", "Exec  [rptInvoiceBill] '" + InvoiceBillId + "','" + ComId + "', '" + weburl + "'");
            HttpContext.Session.SetString("ReportPath", "~/ReportViewer/POS/" + reportname + ".rdlc");
            HttpContext.Session.SetString("PrintFileName", filename.Replace(".", "").Replace(" ", "").Replace(",", "").Replace("\"", ""));

            HttpContext.Session.SetObject("rptList", postData);


            return RedirectToAction("Index", "ReportViewer");
        }


        public IActionResult InvoiceBillSmallPrint(int InvoiceBillId)
        {
            var weburl = HttpContext.Session.GetString("weburl"); //"https://pqstec.com/invoiceapps/Home/login/?ReturnUrl=%2Finvoiceapps%2FInternet%2FInvoiceBillList";// 

            errorlog(weburl);

            var UserId = HttpContext.Session.GetInt32("UserId");
            var ComId = HttpContext.Session.GetInt32("ComId");


            string reportname = "rptInvoiceBill";

            //var ab = _invoiceBillRepository.Find(InvoiceBillId).BillNo;
            string filename = _invoiceBillRepository.All().Where(x => x.Id == InvoiceBillId).Select(x => x.UserId + "_" + x.BillNo).Single();
            //var filename = "Invoice_BIll_";
            //string apppath = "";

            HttpContext.Session.SetString("ReportQuery", "Exec  [rptInvoiceBill] '" + InvoiceBillId + "','" + ComId + "', '" + weburl + "'");
            HttpContext.Session.SetString("ReportPath", "~/ReportViewer/POS/" + reportname + ".rdlc");
            HttpContext.Session.SetString("PrintFileName", filename.Replace(".", "").Replace(" ", "").Replace(",", "").Replace("\"", ""));

            HttpContext.Session.SetObject("rptList", postData);


            return RedirectToAction("Index", "ReportViewer");
        }


        [AllowAnonymous]
        public IActionResult InternetUserLedgerPrintOther(string InternetUserId)
        {
            var weburl = HttpContext.Session.GetString("weburl"); //"https://pqstec.com/invoiceapps/Home/login/?ReturnUrl=%2Finvoiceapps%2FAdmin%2FInvoiceBillList";// 


            errorlog(weburl);

            var UserId = HttpContext.Session.GetInt32("UserId");
            var ComId = HttpContext.Session.GetInt32("ComId");
            string UrlLink = "";
            //string redirectUrl = "";
            string reportname = "rptInvoiceBill";
            string FromDate = "1-jan-2020";
            string ToDate = "31-Dec-2023";


            string filename = _InternetUserRepository.All().Where(x => x.UserId == InternetUserId).Select(x => x.UserId + "_" + x.UserName).Single();
            reportname = "rptInternetUserLedgerOther";
            filename = "rptInternetUserLedgerOther_" + filename;
            HttpContext.Session.SetString("ReportQuery", "Exec InternetService_LedgerList '" + ComId + "','" + InternetUserId + "','" + FromDate + "','" + ToDate + "','" + UrlLink + "'   ");



            HttpContext.Session.SetString("ReportPath", "~/ReportViewer/InternetService/" + reportname + ".rdlc");
            HttpContext.Session.SetString("PrintFileName", filename.Replace(".", "").Replace(" ", "").Replace(",", "").Replace("\"", ""));
            HttpContext.Session.SetObject("rptList", postData);


            return RedirectToAction("Index", "ReportViewer");
        }


        public class InvoiceBillResultList : InvoiceBillModel
        {
            public decimal DueAmount { get; set; }
            public string? BilledDateString { get; set; }
            public string? ExpiredDateString { get; set; }
            public string? NextFollowDateString { get; set; }

            public string? ReceivedDateString { get; set; }
            public string? ReceivedByHead { get; set; }



        }

        [AllowAnonymous]
        public JsonResult GetInvoiceDueList(string id)
        {

            var deliveryChallanList = _invoiceBillRepository.All().Where(p => p.UserId == id && ((p.ReceivedAmount + p.Discount + p.BadDebt) != p.BillAmount)).ToList().Take(5);

            List<InvoiceBillResultList> data = new List<InvoiceBillResultList>();

            foreach (var item in deliveryChallanList)
            {
                InvoiceBillResultList asdf = new InvoiceBillResultList();
                asdf.Id = item.Id;
                asdf.BillNo = item.BillNo;
                asdf.UserId = item.UserId;
                asdf.UserName = item.UserName;
                asdf.BilledDateString = item.BilledDate.ToString("dd-MMM-yy");
                asdf.BillAmount = item.BillAmount;
                asdf.ReceivedAmount = item.ReceivedAmount;
                asdf.Discount = item.Discount;
                asdf.BadDebt = item.BadDebt;
                asdf.DueAmount = item.BillAmount - (item.ReceivedAmount + item.BadDebt + item.Discount);
                asdf.Description = item.Description;


                //asdf.DeliveryDate = DateTime.Parse(item.DeliveryDate.ToString()).ToString("dd-MMM-yy");
                //asdf.DeliveryQty = item.DeliveryQty;

                data.Add(asdf);
            }

            return Json(data.OrderByDescending(x => x.Id));
            //return Json(new { Success = 1, data = asdf }, JsonRequestBehavior.AllowGet);
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
        [AllowAnonymous]
        [HttpPost, ActionName("InvoiceBillReportList")]
        ////[Authorize(Roles = "Internet, SuperInternet , Commercial-Internet ")]
        //[OverridableAuthorize]
        //[ValidateAntiForgeryToken]
        public JsonResult SetSessionInvoiceBillReport(string rptFormat, string action, string FromDate, string ToDate, string InternetUserId, string UserId)
        {
            try
            {
                var ComId = (HttpContext.Session.GetInt32("ComId"));
                string UrlLink = "";
                var reportname = "";
                var filename = "";
                string redirectUrl = "";

                if (action == "PrintInvoiceSummary")
                {
                    reportname = "rptProductList";
                    filename = "InvoiceSummary_From_" + FromDate + "To_" + ToDate;
                    HttpContext.Session.SetString("ReportQuery", "Exec rptInvoiceSummary '" + ComId + "','" + FromDate + "', '" + ToDate + "' ");
                }
                else if (action == "PrintSubLedger")
                {

                    reportname = "rptInternetUserLedger";
                    filename = "rptInternetUserLedger_" + InternetUserId;
                    HttpContext.Session.SetString("ReportQuery", "Exec InternetService_LedgerList '" + ComId + "','" + InternetUserId + "','" + FromDate + "','" + ToDate + "','" + UrlLink + "'   ");


                }


                var abcd = HttpContext.Session.GetString("ReportQuery");
                HttpContext.Session.SetString("ReportPath", "~/ReportViewer/InternetService/" + reportname + ".rdlc");
                HttpContext.Session.SetString("PrintFileName", filename.Replace(".", "").Replace(" ", "").Replace(",", "").Replace("\"", ""));
                HttpContext.Session.SetString("ReportType", rptFormat);


                string DataSourceName = "DataSet1";
                clsReport.strReportPathMain = HttpContext.Session.GetString("ReportPath");// Session["ReportPath"].ToString();
                clsReport.strQueryMain = HttpContext.Session.GetString("ReportQuery");
                clsReport.strDSNMain = DataSourceName;
                string callBackUrl = this.Url.Action("Index", "ReportViewer", new { reporttype = rptFormat });
                redirectUrl = callBackUrl;

                return Json(new { Url = redirectUrl });

            }

            catch (Exception ex)
            {
                return Json(new { Success = 0, ex = ex.InnerException.InnerException.Message.ToString() });
            }

            //return Json(new { Success = 0, ex = new Exception("Unable to Open").Message.ToString() });
            //return RedirectToAction("Index");

        }

        [AllowAnonymous]
        public IActionResult GetInvoiceBillList(string FromDate, string ToDate, int? UserId, int isAll, string Status)
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

                var invoicebill = _invoiceBillRepository.All().Where(x => x.isSystem == false);

                if (Status == "Received")
                {
                    invoicebill = invoicebill.Where(x => x.ReceivedAmount > 0);
                }
                else if (Status == "BadDebt")
                {
                    invoicebill = invoicebill.Where(x => x.BadDebt > 0);
                }
                else if (Status == "Discount")
                {
                    invoicebill = invoicebill.Where(x => x.Discount > 0);
                }




                if (y.ToString().Length > 0)
                {

                }
                else
                {
                    if (UserId == null)
                    {

                        invoicebill = invoicebill.Where(p => p.BilledDate >= dtFrom && p.BilledDate <= dtTo);



                    }
                    else
                    {
                        if (UserId == 1)
                        {

                            invoicebill = invoicebill.Where(p => p.BilledDate >= dtFrom && p.BilledDate <= dtTo);

                        }
                        else
                        {


                            invoicebill = invoicebill.Where(p => (p.BilledDate >= dtFrom && p.BilledDate <= dtTo) && p.LuserId == UserId);



                        }
                    }

                }

                //invoicebill = invoicebill.OrderByDescending(x => x.Id);


                var query = from e in invoicebill
                            select new InvoiceBillResultList
                            {
                                Id = e.Id,
                                BillNo = e.BillNo,
                                UserId = e.UserId,
                                UserName = e.UserName,
                                //BilledDate = e.BilledDate,
                                BilledDateString = e.BilledDate.ToString("dd-MMM-yy"),
                                //ReceivedDateString = e.ReceivedDate.GetValueOrDefault().ToString("dd-MMM-yy"),// e.ReceivedDate.HasValue == true ? e.ReceivedDate.ToString("dd-MMM-yy") : "",  //e.ReceivedDate != null ? e.ReceivedDate.ToString("dd-MMM-yy") : "", //e.ReceivedDate.ToString("dd-MMM-yy"),
                                ExpiredDateString = e.ExpiredDate.GetValueOrDefault().ToString("dd-MMM-yy"),
                                NextFollowDateString = e.NextFollowDate.GetValueOrDefault().ToString("dd-MMM-yy"),

                                //ReceivedDate = e.ReceivedDate,
                                BillAmount = e.BillAmount,
                                ReceivedAmount = e.ReceivedAmount,
                                Description = e.Description,
                                Discount = e.Discount,
                                BadDebt = e.BadDebt,
                                isPost = e.isPost,
                                InWords = e.InWords,
                                Balance = e.BillAmount - e.Discount - e.BadDebt - e.ReceivedAmount,
                                ReceivedByHead = e.AccountReceiveByHead != null ? e.AccountReceiveByHead.AccName : null,
                                ReceivedDateString = e.AccountReceiveByHead != null ? e.ReceivedDate.GetValueOrDefault().ToString("dd-MMM-yy") : null



                            };
                var parser = new Parser<InvoiceBillResultList>(Request.Form, query);
                return Json(parser.Parse());
            }
            catch (Exception ex)
            {
                return Json(new { Success = "0", error = ex.Message });
                //throw ex;
            }

        }


        #endregion

        #region InternetPackage
        public IActionResult InternetPackageList()
        {
            return View(_internetPackageRepository.All());
        }

        [HttpGet]
        public ActionResult AddInternetPackage()
        {
            ViewBag.ActionType = "Create";
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult AddInternetPackage(InternetPackageModel model)
        {
            if (ModelState.IsValid)
            {
                if (model.Id == 0)
                {
                    _internetPackageRepository.Insert(model);


                    TempData["Message"] = "Data Save Successfully";
                    TempData["Status"] = "1";
                    tranlog.TransactionLog(RouteData.Values["controller"].ToString(), RouteData.Values["action"].ToString(), TempData["Message"].ToString(), model.Id.ToString(), "Create", model.PackageName.ToString());

                }
                else
                {
                    _internetPackageRepository.Update(model, model.Id);


                    TempData["Message"] = "Data Update Successfully";
                    TempData["Status"] = "2";
                    tranlog.TransactionLog(RouteData.Values["controller"].ToString(), RouteData.Values["action"].ToString(), TempData["Message"].ToString(), model.Id.ToString(), "Update", model.PackageName.ToString());

                }
                return RedirectToAction("InternetPackageList");
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
        public ActionResult EditInternetPackage(int InternetPackageId)
        {
            ViewBag.ActionType = "Edit";
            var InternetPackage = _internetPackageRepository.Find(InternetPackageId);
            return View("AddInternetPackage", InternetPackage);
        }

        public ActionResult DeleteInternetPackage(int InternetPackageId)
        {
            var model = _internetPackageRepository.Find(InternetPackageId);
            if (model != null)
            {
                _internetPackageRepository.Delete(model);


                TempData["Message"] = "Data Delete Successfully";
                TempData["Status"] = "3";
                tranlog.TransactionLog(RouteData.Values["controller"].ToString(), RouteData.Values["action"].ToString(), TempData["Message"].ToString(), model.Id.ToString(), "Delete", model.PackageName);


                return RedirectToAction("InternetPackageList");
            }
            return RedirectToAction("InternetPackageList");
        }
        #endregion





        #region InternetComplain
        public IActionResult InternetComplainList()
        {
            return View(_InternetComplainRepository.All());
        }

        [HttpGet]
        public ActionResult AddInternetComplain()
        {
            ViewBag.ActionType = "Create";
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult AddInternetComplain(InternetComplainModel model)
        {
            if (ModelState.IsValid)
            {
                if (model.Id == 0)
                {
                    _InternetComplainRepository.Insert(model);


                    TempData["Message"] = "Data Save Successfully";
                    TempData["Status"] = "1";
                    tranlog.TransactionLog(RouteData.Values["controller"].ToString(), RouteData.Values["action"].ToString(), TempData["Message"].ToString(), model.Id.ToString(), "Create", model.ComplainName.ToString());

                }
                else
                {
                    _InternetComplainRepository.Update(model, model.Id);


                    TempData["Message"] = "Data Update Successfully";
                    TempData["Status"] = "2";
                    tranlog.TransactionLog(RouteData.Values["controller"].ToString(), RouteData.Values["action"].ToString(), TempData["Message"].ToString(), model.Id.ToString(), "Update", model.ComplainName.ToString());

                }
                return RedirectToAction("InternetComplainList");
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
        public ActionResult EditInternetComplain(int InternetComplainId)
        {
            ViewBag.ActionType = "Edit";
            var InternetComplain = _InternetComplainRepository.Find(InternetComplainId);
            return View("AddInternetComplain", InternetComplain);
        }

        public ActionResult DeleteInternetComplain(int InternetComplainId)
        {
            var model = _InternetComplainRepository.Find(InternetComplainId);
            if (model != null)
            {
                _InternetComplainRepository.Delete(model);


                TempData["Message"] = "Data Delete Successfully";
                TempData["Status"] = "3";
                tranlog.TransactionLog(RouteData.Values["controller"].ToString(), RouteData.Values["action"].ToString(), TempData["Message"].ToString(), model.Id.ToString(), "Delete", model.ComplainName);


                return RedirectToAction("InternetComplainList");
            }
            return RedirectToAction("InternetComplainList");
        }
        #endregion


        #region InternetDiagnosisReport
        public IActionResult InternetDiagnosisReportList()
        {
            return View(_InternetDiagnosisReportRepository.All());
        }

        [HttpGet]
        public ActionResult AddInternetDiagnosisReport()
        {
            ViewBag.ActionType = "Create";
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult AddInternetDiagnosisReport(DiagnosisReportModel model)
        {
            if (ModelState.IsValid)
            {
                if (model.Id == 0)
                {
                    _InternetDiagnosisReportRepository.Insert(model);


                    TempData["Message"] = "Data Save Successfully";
                    TempData["Status"] = "1";
                    tranlog.TransactionLog(RouteData.Values["controller"].ToString(), RouteData.Values["action"].ToString(), TempData["Message"].ToString(), model.Id.ToString(), "Create", model.Name.ToString());

                }
                else
                {
                    _InternetDiagnosisReportRepository.Update(model, model.Id);


                    TempData["Message"] = "Data Update Successfully";
                    TempData["Status"] = "2";
                    tranlog.TransactionLog(RouteData.Values["controller"].ToString(), RouteData.Values["action"].ToString(), TempData["Message"].ToString(), model.Id.ToString(), "Update", model.Name.ToString());

                }
                return RedirectToAction("InternetDiagnosisReportList");
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
        public ActionResult EditInternetDiagnosisReport(int InternetDiagnosisReportId)
        {
            ViewBag.ActionType = "Edit";
            var InternetDiagnosisReport = _InternetDiagnosisReportRepository.Find(InternetDiagnosisReportId);
            return View("AddInternetDiagnosisReport", InternetDiagnosisReport);
        }

        public ActionResult DeleteInternetDiagnosisReport(int InternetDiagnosisReportId)
        {
            var model = _InternetDiagnosisReportRepository.Find(InternetDiagnosisReportId);
            if (model != null)
            {
                _InternetDiagnosisReportRepository.Delete(model);


                TempData["Message"] = "Data Delete Successfully";
                TempData["Status"] = "3";
                tranlog.TransactionLog(RouteData.Values["controller"].ToString(), RouteData.Values["action"].ToString(), TempData["Message"].ToString(), model.Id.ToString(), "Delete", model.Name);


                return RedirectToAction("InternetDiagnosisReportList");
            }
            return RedirectToAction("InternetDiagnosisReportList");
        }
        #endregion






        #region ActivationTicket
        public IActionResult ActivationTicketList()
        {
            //return View(_ActivationTicketRepository.All());
            return View();

        }

        [HttpGet]
        public ActionResult AddActivationTicket()
        {
            ViewBag.ActionType = "Create";
            ViewBag.PackageId = _internetPackageRepository.GetAllForDropDown();
            ViewBag.FusionTeamLUserId = _userAccountRepository.GetAllForDropDown();
            ViewBag.ActivatedbyLUserId = _userAccountRepository.GetAllForDropDown();

            ActivationTicketModel abc = new ActivationTicketModel();
            abc.PromiseDate = DateTime.Now.Date;
            abc.TicketNo = "A-" + DateTime.Now.ToString("ddMMyyHHmmssfff");



            return View(abc);
        }

        public class ActivationTicketResultList : ActivationTicketModel
        {

            public string? PackageName { get; set; }
            public string? UserStatusName { get; set; }

            public string? PromiseDateString { get; set; }
            public string? CreateDateString { get; set; }

            public string? FusionTeamUser { get; set; }
            public string? ActivatedByUser { get; set; }



        }
        [AllowAnonymous]
        public JsonResult GetActivationTicketList()
        {
            try
            {
                //var products= _context.Products.ToList();


                var ActivationTickets = _ActivationTicketRepository.All(true);//.Include(x=>x.vUnit).Include(x=>x.Category);
                var query = from e in ActivationTickets//.Where(x => x.Id > 0 && x.ComId == ComId).OrderByDescending(x => x.Id)

                            select new ActivationTicketResultList
                            {
                                Id = e.Id,
                                TicketNo = e.TicketNo,

                                ContactName = e.ContactName,
                                ContactNumber = e.ContactNumber,
                                Address = e.Address,
                                AreaZone = e.AreaZone,
                                PromiseDateString = e.PromiseDate.ToString("dd-MMM-yy"),
                                OTC = e.OTC,
                                MRC = e.MRC,

                                PackageName = e.InternetPackageList != null ? e.InternetPackageList.PackageName : null,  //e.InternetPackageList.PackageName
                                UserType = e.UserType,
                                Priority = e.Priority,
                                ONUFrom = e.ONUFrom,
                                ROUTERFrom = e.ROUTERFrom,
                                ReferanceBy = e.ReferanceBy,
                                Note = e.Note,
                                FusionTeamUser = e.FusionTeamAssaign.Name,
                                ActivatedByUser = e.ActivatedbyUser.Name,
                                CreateDateString = e.CreateDate != null ? e.CreateDate.ToString("dd-MMM-yy") : null,

                            };



                var parser = new Parser<ActivationTicketResultList>(Request.Form, query);
                return Json(parser.Parse());
                //dynamic abcd = parser.Parse();
                //return Json(abcd);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult AddActivationTicket(ActivationTicketModel model)
        {
            if (ModelState.IsValid)
            {
                if (model.Id == 0)
                {
                    _ActivationTicketRepository.Insert(model);


                    TempData["Message"] = "Data Save Successfully";
                    TempData["Status"] = "1";
                    tranlog.TransactionLog(RouteData.Values["controller"].ToString(), RouteData.Values["action"].ToString(), TempData["Message"].ToString(), model.Id.ToString(), "Create", model.TicketNo.ToString());

                }
                else
                {
                    _ActivationTicketRepository.Update(model, model.Id);


                    TempData["Message"] = "Data Update Successfully";
                    TempData["Status"] = "2";
                    tranlog.TransactionLog(RouteData.Values["controller"].ToString(), RouteData.Values["action"].ToString(), TempData["Message"].ToString(), model.Id.ToString(), "Update", model.TicketNo.ToString());

                }
                return RedirectToAction("ActivationTicketList");
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
        public ActionResult EditActivationTicket(int ActivationTicketId)
        {
            ViewBag.ActionType = "Edit";
            ViewBag.PackageId = _internetPackageRepository.GetAllForDropDown();
            ViewBag.FusionTeamLUserId = _userAccountRepository.GetAllForDropDown();
            ViewBag.ActivatedbyLUserId = _userAccountRepository.GetAllForDropDown();

            var ActivationTicket = _ActivationTicketRepository.Find(ActivationTicketId);
            return View("AddActivationTicket", ActivationTicket);
        }

        public ActionResult DeleteActivationTicket(int ActivationTicketId)
        {
            var model = _ActivationTicketRepository.Find(ActivationTicketId);
            if (model != null)
            {
                _ActivationTicketRepository.Delete(model);

                TempData["Message"] = "Data Delete Successfully";
                TempData["Status"] = "3";
                tranlog.TransactionLog(RouteData.Values["controller"].ToString(), RouteData.Values["action"].ToString(), TempData["Message"].ToString(), model.Id.ToString(), "Delete", model.TicketNo);



                return RedirectToAction("ActivationTicketList");
            }
            return RedirectToAction("ActivationTicketList");
        }
        #endregion


        #region TroubleTicket
        public IActionResult TroubleTicketList()
        {
            var UserId = HttpContext.Session.GetInt32("UserId");
            //var ComId = HttpContext.Session.GetInt32("ComId");
            //return View(_TroubleTicketRepository.All());
            ViewBag.CommentToLuserId = _userAccountRepository.All().Where(x => x.Id != UserId).Select(x => new SelectListItem
            {
                Text = x.Name,
                Value = x.Id.ToString()
            });
            return View();

        }

        [HttpGet]
        public ActionResult AddTroubleTicket()
        {
            ViewBag.ActionType = "Create";

            ViewBag.InternetComplainId = _InternetComplainRepository.GetAllForDropDown();
            ViewBag.DiagnosisReportId = _InternetDiagnosisReportRepository.GetAllForDropDown();
            ViewBag.SupportByLUserId = _userAccountRepository.GetAllForDropDown();
            ViewBag.DiagonosisByLUserId = _userAccountRepository.GetAllForDropDown();

            TroubleTicketModel abc = new TroubleTicketModel();
            //abc.PromiseDate = DateTime.Now.Date;
            abc.TicketNo = "T-" + DateTime.Now.ToString("ddMMyyHHmmssfff");



            return View(abc);
        }

        public class TroubleTicketResultList : TroubleTicketModel
        {

            public string? ComplainName { get; set; }
            public string? DiagnosisReportName { get; set; }
            public string? DiagonosisByUserNameString { get; set; }
            public string? SupportByUserNameString { get; set; }


            //public string? UserId { get; set; }
            public string? CreateDateString { get; set; }

            public string? FusionTeamUser { get; set; }
            public string? ActivatedByUser { get; set; }

            public List<CommentResult> CommentList { get; set; }



        }


        public class CommentResult
        {
            //public int Id { get; set; }
            public int CommentId { get; set; }
            public string? Comment { get; set; }

            public string? CreateDateString { get; set; }
            public string? CommentByUser { get; set; }
            public string? CommentToUser { get; set; }


        }

        [AllowAnonymous]
        public JsonResult GetTroubleTicketList()
        {
            try
            {
                var UserId = HttpContext.Session.GetInt32("UserId");

                var TroubleTickets = _TroubleTicketRepository.All(true);//.Include(x=>x.vUnit).Include(x=>x.Category);
                var query = from e in TroubleTickets//.Where(x => x.Id > 0 && x.ComId == ComId).OrderByDescending(x => x.Id)

                            let CommentList =
                            //p.CostCalculated != null ?
                            e.TroubleTicketComment//.OrderByDescending(x => x.Id)
                            .Select(x => new CommentResult
                            {
                                CommentId = x.Id,
                                Comment = x.Comment,
                                CommentByUser = x.LuserId == UserId ? "Me" : x.UserAccountList.Name,// x.UserAccountList.Name,
                                CommentToUser = x.CommentToUserList.Name,//x.UserAccountList.Name,
                                CreateDateString = x.CreateDate.ToString("dd-MMM-yy HH:mm:ss")
                            }).ToList()
                            ?? null

                            select new TroubleTicketResultList
                            {
                                Id = e.Id,
                                TicketNo = e.TicketNo,

                                UserId = e.InternetUser.UserId,
                                UserName = e.InternetUser.UserName,


                                ComplainName = e.InternetComplain != null ? e.InternetComplain.ComplainName : null,  //e.InternetPackageList.PackageName
                                DiagnosisReportName = e.DiagnosisReport != null ? e.DiagnosisReport.Name : null,  //e.InternetPackageList.PackageName

                                DiagonosisByUserNameString = e.DiagonosisByUser != null ? e.DiagonosisByUser.Name : null,  //e.InternetPackageList.PackageName
                                SupportByUserNameString = e.SupportByUser != null ? e.SupportByUser.Name : null,  //e.InternetPackageList.PackageName

                                Note = e.Note,
                                Recommendation = e.Recommendation,
                                Priority = e.Priority,
                                TroubleTicketComment = e.TroubleTicketComment,
                                CommentList = CommentList,//p.TroubleTicketComment.OrderByDescending(x => x.Id).FirstOrDefault().PurchaseModel.SupplierModel.SupplierName ?? null,
                                CreateDateString = e.CreateDate != null ? e.CreateDate.ToString("dd-MMM-yy") : null,

                            };



                var parser = new Parser<TroubleTicketResultList>(Request.Form, query);
                return Json(parser.Parse());
                //dynamic abcd = parser.Parse();
                //return Json(abcd);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult AddTroubleTicket(TroubleTicketModel model)
        {
            if (ModelState.IsValid)
            {
                if (model.Id == 0)
                {
                    _TroubleTicketRepository.Insert(model);


                    TempData["Message"] = "Data Save Successfully";
                    TempData["Status"] = "1";
                    tranlog.TransactionLog(RouteData.Values["controller"].ToString(), RouteData.Values["action"].ToString(), TempData["Message"].ToString(), model.Id.ToString(), "Create", model.TicketNo.ToString());

                }
                else
                {
                    _TroubleTicketRepository.Update(model, model.Id);


                    TempData["Message"] = "Data Update Successfully";
                    TempData["Status"] = "2";
                    tranlog.TransactionLog(RouteData.Values["controller"].ToString(), RouteData.Values["action"].ToString(), TempData["Message"].ToString(), model.Id.ToString(), "Update", model.TicketNo.ToString());

                }
                return RedirectToAction("TroubleTicketList");
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
        public ActionResult EditTroubleTicket(int TroubleTicketId)
        {
            ViewBag.ActionType = "Edit";

            ViewBag.InternetComplainId = _InternetComplainRepository.GetAllForDropDown();
            ViewBag.DiagnosisReportId = _InternetDiagnosisReportRepository.GetAllForDropDown();
            ViewBag.SupportByLUserId = _userAccountRepository.GetAllForDropDown();
            ViewBag.DiagonosisByLUserId = _userAccountRepository.GetAllForDropDown();

            //var TroubleTicket = _TroubleTicketRepository.Find(TroubleTicketId);

            var TroubleTicket = _TroubleTicketRepository.All().Include(x => x.InternetUser).Where(x => x.Id == TroubleTicketId).FirstOrDefault();

            if (TroubleTicket != null)
            {
                TroubleTicket.UserId = TroubleTicket.InternetUser.UserId;
                TroubleTicket.UserName = TroubleTicket.InternetUser.UserName;

            }


            return View("AddTroubleTicket", TroubleTicket);
        }

        public ActionResult DeleteTroubleTicket(int TroubleTicketId)
        {
            var model = _TroubleTicketRepository.Find(TroubleTicketId);
            if (model != null)
            {
                _TroubleTicketRepository.Delete(model);

                TempData["Message"] = "Data Delete Successfully";
                TempData["Status"] = "3";
                tranlog.TransactionLog(RouteData.Values["controller"].ToString(), RouteData.Values["action"].ToString(), TempData["Message"].ToString(), model.Id.ToString(), "Delete", model.TicketNo);



                return RedirectToAction("TroubleTicketList");
            }
            return RedirectToAction("TroubleTicketList");
        }
        #endregion

    }
}