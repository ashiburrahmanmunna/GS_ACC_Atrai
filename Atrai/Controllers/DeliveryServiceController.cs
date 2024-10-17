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
using System.Linq;

namespace Atrai.Controllers
{
    [Authorize]
    [OverridableAuthorize]
    public class DeliveryServiceController : Controller
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




        private readonly IDeliveryServiceRepository _DeliveryServiceRepository;
        private readonly IDeliveryServiceCommentRepository _DeliveryServiceCommentRepository;


        private readonly IDeliveryServiceDistanceRepository _DeliveryServiceDistanceRepository;
        private readonly IDeliveryServiceWeightRepository _DeliveryServiceWeightRepository;
        private readonly IDeliveryServiceTimingRepository _DeliveryServiceTimingRepository;
        private readonly IPaymentTypeRepository _PaymentTypeRepository;




        private readonly IUserAccountRepository _userAccountRepository;

        private readonly IAccountHeadRepository _accountHeadRepository;
        private readonly ITransactionRepository _transactionRepository;
        private readonly IInvoiceBillRepository _invoiceBillRepository;


        private readonly ICategoryRepository _categoryRepository;
        private readonly IInternetPackageRepository _internetPackageRepository;
        private readonly IInternetUserStatusRepository _internetUserStatusRepository;


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

        public DeliveryServiceController(ICustomerRepository customerRepository, ISupplierRepository supplierRepository, IVGMRepository vgmRepository,
        IProductRepository productRepository, IUnitRepository unitRepository, IStoreSettingRepository storeSettingRepository, ICompanyRepository companyRepository,



        IPaymentTypeRepository PaymentTypeRepository,
        IDeliveryServiceRepository deliveryServiceRepository,
        IDeliveryServiceCommentRepository deliveryServiceCommentRepository,

        IDeliveryServiceWeightRepository deliveryServiceWeightRepository,
        IDeliveryServiceDistanceRepository deliveryServiceDistanceRepository,
        IDeliveryServiceTimingRepository deliveryServiceTimingRepository,




        ISaleRepository saleRepository,
        IPurchaseRepository purchaseRepository,
        ICostCalculatedRepository costCalculatedRepository,


        InvoiceDbContext context, IUserAccountRepository userAccountRepository,
        IAccountHeadRepository accountHeadRepository, ITransactionRepository transactionRepository, IInvoiceBillRepository invoiceBillRepository,
        ICategoryRepository categoryRepository, IWarrentyRepository warrentyRepository, IWarehouseRepository warehouseRepository,
        IInternetPackageRepository internetPackageRepository,
        IInternetUserStatusRepository internetUserStatusRepository,

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


            _PaymentTypeRepository = PaymentTypeRepository;
            _DeliveryServiceRepository = deliveryServiceRepository;
            _DeliveryServiceCommentRepository = deliveryServiceCommentRepository;

            _DeliveryServiceWeightRepository = deliveryServiceWeightRepository;
            _DeliveryServiceDistanceRepository = deliveryServiceDistanceRepository;
            _DeliveryServiceTimingRepository = deliveryServiceTimingRepository;






            _userAccountRepository = userAccountRepository;
            _accountHeadRepository = accountHeadRepository;
            _transactionRepository = transactionRepository;
            _invoiceBillRepository = invoiceBillRepository;

            _memberRepository = memberRepository;
            _categoryRepository = categoryRepository;
            _warrentyRepository = warrentyRepository;

            _internetPackageRepository = internetPackageRepository;
            _internetUserStatusRepository = internetUserStatusRepository;


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

        #region DeliveryServiceDistance
        public IActionResult DeliveryServiceDistanceList()
        {
            return View(_DeliveryServiceDistanceRepository.All());
        }

        [HttpGet]
        public ActionResult AddDeliveryServiceDistance()
        {
            ViewBag.ActionType = "Create";
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult AddDeliveryServiceDistance(DeliveryServiceDistanceModel model)
        {
            if (ModelState.IsValid)
            {
                if (model.Id == 0)
                {
                    _DeliveryServiceDistanceRepository.Insert(model);


                    TempData["Message"] = "Data Save Successfully";
                    TempData["Status"] = "1";
                    tranlog.TransactionLog(RouteData.Values["controller"].ToString(), RouteData.Values["action"].ToString(), TempData["Message"].ToString(), model.Id.ToString(), "Create", model.DistanceName.ToString());

                }
                else
                {
                    _DeliveryServiceDistanceRepository.Update(model, model.Id);


                    TempData["Message"] = "Data Update Successfully";
                    TempData["Status"] = "2";
                    tranlog.TransactionLog(RouteData.Values["controller"].ToString(), RouteData.Values["action"].ToString(), TempData["Message"].ToString(), model.Id.ToString(), "Update", model.DistanceName.ToString());

                }
                return RedirectToAction("DeliveryServiceDistanceList");
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
        public ActionResult EditDeliveryServiceDistance(int DeliveryServiceDistanceId)
        {
            ViewBag.ActionType = "Edit";
            var DeliveryServiceDistance = _DeliveryServiceDistanceRepository.Find(DeliveryServiceDistanceId);
            return View("AddDeliveryServiceDistance", DeliveryServiceDistance);
        }

        public ActionResult DeleteDeliveryServiceDistance(int DeliveryServiceDistanceId)
        {
            var model = _DeliveryServiceDistanceRepository.Find(DeliveryServiceDistanceId);
            if (model != null)
            {
                _DeliveryServiceDistanceRepository.Delete(model);


                TempData["Message"] = "Data Delete Successfully";
                TempData["Status"] = "3";
                tranlog.TransactionLog(RouteData.Values["controller"].ToString(), RouteData.Values["action"].ToString(), TempData["Message"].ToString(), model.Id.ToString(), "Delete", model.DistanceName);


                return RedirectToAction("DeliveryServiceDistanceList");
            }
            return RedirectToAction("DeliveryServiceDistanceList");
        }
        #endregion

        #region DeliveryServiceWeight
        public IActionResult DeliveryServiceWeightList()
        {
            return View(_DeliveryServiceWeightRepository.All());
        }

        [HttpGet]
        public ActionResult AddDeliveryServiceWeight()
        {
            ViewBag.ActionType = "Create";
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult AddDeliveryServiceWeight(DeliveryServiceWeightModel model)
        {
            if (ModelState.IsValid)
            {
                if (model.Id == 0)
                {
                    _DeliveryServiceWeightRepository.Insert(model);


                    TempData["Message"] = "Data Save Successfully";
                    TempData["Status"] = "1";
                    tranlog.TransactionLog(RouteData.Values["controller"].ToString(), RouteData.Values["action"].ToString(), TempData["Message"].ToString(), model.Id.ToString(), "Create", model.WeightName.ToString());

                }
                else
                {
                    _DeliveryServiceWeightRepository.Update(model, model.Id);


                    TempData["Message"] = "Data Update Successfully";
                    TempData["Status"] = "2";
                    tranlog.TransactionLog(RouteData.Values["controller"].ToString(), RouteData.Values["action"].ToString(), TempData["Message"].ToString(), model.Id.ToString(), "Update", model.WeightName.ToString());

                }
                return RedirectToAction("DeliveryServiceWeightList");
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
        public ActionResult EditDeliveryServiceWeight(int DeliveryServiceWeightId)
        {
            ViewBag.ActionType = "Edit";
            var DeliveryServiceWeight = _DeliveryServiceWeightRepository.Find(DeliveryServiceWeightId);
            return View("AddDeliveryServiceWeight", DeliveryServiceWeight);
        }

        public ActionResult DeleteDeliveryServiceWeight(int DeliveryServiceWeightId)
        {
            var model = _DeliveryServiceWeightRepository.Find(DeliveryServiceWeightId);
            if (model != null)
            {
                _DeliveryServiceWeightRepository.Delete(model);


                TempData["Message"] = "Data Delete Successfully";
                TempData["Status"] = "3";
                tranlog.TransactionLog(RouteData.Values["controller"].ToString(), RouteData.Values["action"].ToString(), TempData["Message"].ToString(), model.Id.ToString(), "Delete", model.WeightName);


                return RedirectToAction("DeliveryServiceWeightList");
            }
            return RedirectToAction("DeliveryServiceWeightList");
        }
        #endregion

        #region DeliveryServiceTiming
        public IActionResult DeliveryServiceTimingList()
        {
            return View(_DeliveryServiceTimingRepository.All());
        }

        [HttpGet]
        public ActionResult AddDeliveryServiceTiming()
        {
            ViewBag.ActionType = "Create";
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult AddDeliveryServiceTiming(DeliveryServiceTimingModel model)
        {
            if (ModelState.IsValid)
            {
                if (model.Id == 0)
                {
                    _DeliveryServiceTimingRepository.Insert(model);


                    TempData["Message"] = "Data Save Successfully";
                    TempData["Status"] = "1";
                    tranlog.TransactionLog(RouteData.Values["controller"].ToString(), RouteData.Values["action"].ToString(), TempData["Message"].ToString(), model.Id.ToString(), "Create", model.TimingName.ToString());

                }
                else
                {
                    _DeliveryServiceTimingRepository.Update(model, model.Id);


                    TempData["Message"] = "Data Update Successfully";
                    TempData["Status"] = "2";
                    tranlog.TransactionLog(RouteData.Values["controller"].ToString(), RouteData.Values["action"].ToString(), TempData["Message"].ToString(), model.Id.ToString(), "Update", model.TimingName.ToString());

                }
                return RedirectToAction("DeliveryServiceTimingList");
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
        public ActionResult EditDeliveryServiceTiming(int DeliveryServiceTimingId)
        {
            ViewBag.ActionType = "Edit";
            var DeliveryServiceTiming = _DeliveryServiceTimingRepository.Find(DeliveryServiceTimingId);
            return View("AddDeliveryServiceTiming", DeliveryServiceTiming);
        }

        public ActionResult DeleteDeliveryServiceTiming(int DeliveryServiceTimingId)
        {
            var model = _DeliveryServiceTimingRepository.Find(DeliveryServiceTimingId);
            if (model != null)
            {
                _DeliveryServiceTimingRepository.Delete(model);


                TempData["Message"] = "Data Delete Successfully";
                TempData["Status"] = "3";
                tranlog.TransactionLog(RouteData.Values["controller"].ToString(), RouteData.Values["action"].ToString(), TempData["Message"].ToString(), model.Id.ToString(), "Delete", model.TimingName);


                return RedirectToAction("DeliveryServiceTimingList");
            }
            return RedirectToAction("DeliveryServiceTimingList");
        }
        #endregion




        #region DeliveryService
        public IActionResult DeliveryServiceList()
        {
            var UserId = HttpContext.Session.GetInt32("UserId");
            //var ComId = HttpContext.Session.GetInt32("ComId");
            //return View(_DeliveryServiceRepository.All());
            ViewBag.CommentToLuserId = _userAccountRepository.All().Where(x => x.Id != UserId).Select(x => new SelectListItem
            {
                Text = x.Name,
                Value = x.Id.ToString()
            });
            return View();

        }

        [HttpGet]
        public ActionResult AddDeliveryService()
        {
            var UserId = HttpContext.Session.GetInt32("UserId");


            ViewBag.ActionType = "Create";

            ViewBag.WeightId = _DeliveryServiceWeightRepository.GetAllForDropDown();
            ViewBag.DeliveryTimingId = _DeliveryServiceTimingRepository.GetAllForDropDown();
            ViewBag.DistanceId = _DeliveryServiceDistanceRepository.GetAllForDropDown();
            ViewBag.PaymentTypeId = _PaymentTypeRepository.GetAllForDropDown();
            ViewBag.CategoryId = _categoryRepository.GetAllForDropDown();


            DeliveryServiceModel abc = new DeliveryServiceModel();
            //abc.PromiseDate = DateTime.Now.Date;
            abc.BillNo = "DS-" + DateTime.Now.ToString("ddmmyyHHmmssfff");
            abc.BilledDate = DateTime.Now.Date;
            abc.PreferableDateTime = DateTime.Now.AddHours(3);


            _userAccountRepository.All().Where(x => x.Id == UserId).FirstOrDefault();

            abc.PickupPoint = _userAccountRepository.All().Where(x => x.Id == UserId).FirstOrDefault().Email; /// later we will add delivery client profile which name is my Profile for delivery client 
            //abc.PickupPoint = _customerRepository.All().Where(x => x.Id == 30).FirstOrDefault().PrimaryAddress;



            return View(abc);
        }


        [AllowAnonymous]
        public JsonResult DeliveryClientdata(string query)
        {
            try
            {

                var UserId = HttpContext.Session.GetInt32("UserId");


                var deliveryclientinfo = _DeliveryServiceRepository.All().Where(x => x.LuserId == UserId && x.DeliveryClientPhoneNo.ToLower().Contains(query.ToLower())).Take(10)
                .Select(x => new { DeliveryClientPhoneNo = x.DeliveryClientPhoneNo, DeliveryClientName = x.DeliveryClientName, DeliveryClientAddress = x.DeliveryClientAddress, PickupPoint = x.PickupPoint })
                //.GroupBy(x => new { x.DeliveryClientPhoneNo, x.DeliveryClientName , x.DeliveryClientAddress })
                //.Select(g => new { DeliveryClientPhoneNo = g.Key.DeliveryClientPhoneNo, DeliveryClientName = g.Key.DeliveryClientName, Id = g.Max(x => x.Id) })
                .ToList();


                return Json(deliveryclientinfo);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }


        public class DeliveryServiceResultList : DeliveryServiceModel
        {

            public string? WeightName { get; set; }
            public string? CategoryName { get; set; }
            public string? TimingName { get; set; }
            public string? UserName { get; set; }
            public string? DeliveryEntryClientName { get; set; }




            public string? DistanceName { get; set; }

            public string? CreateDateString { get; set; }
            public string? PreferableDateTimeString { get; set; }
            public string? BilledDateString { get; set; }


            public List<DeliveryCommentResult> CommentList { get; set; }



        }


        public class DeliveryCommentResult
        {
            //public int Id { get; set; }
            public int CommentId { get; set; }
            public string? Comment { get; set; }

            public string? CreateDateString { get; set; }
            public string? CommentByUser { get; set; }
            public string? CommentToUser { get; set; }


        }

        [HttpPost]
        [AllowAnonymous]

        public IActionResult SaveCommentModal([FromBody] DeliveryServiceCommentModel model)
        {
            var errors = ModelState.Where(x => x.Value.Errors.Any())
            .Select(x => new { x.Key, x.Value.Errors });


            if (!ModelState.IsValid)
            {
                //return Json("Model is not valid");
                return Json(new { Success = 3, ex = errors });
            }
            _DeliveryServiceCommentRepository.Insert(model);



            TempData["Message"] = "Data Save Successfully";
            TempData["Status"] = "1";
            tranlog.TransactionLog(RouteData.Values["controller"].ToString(), RouteData.Values["action"].ToString(), TempData["Message"].ToString(), model.Id.ToString(), "Create", model.Comment.ToString());

            return Json(new { Success = 1, ex = "Comment Added Successfully" });
            //return Json("Product Added Successfully");
        }


        [AllowAnonymous]
        public JsonResult GetDeliveryServiceList()
        {
            try
            {
                var UserId = HttpContext.Session.GetInt32("UserId");

                var DeliveryServices = _DeliveryServiceRepository.All(true);//.Include(x=>x.vUnit).Include(x=>x.Category);
                var query = from e in DeliveryServices//.Where(x => x.Id > 0 && x.ComId == ComId).OrderByDescending(x => x.Id)


                            let CommentList =
                            //p.CostCalculated != null ?
                            e.DeliveryServiceComment//.OrderByDescending(x => x.Id)
                            .Select(x => new DeliveryCommentResult
                            {
                                CommentId = x.Id,
                                Comment = x.Comment,
                                CommentByUser = x.LuserId == UserId ? "Me" : x.UserAccountList.Name,// x.UserAccountList.Name,
                                CommentToUser = x.CommentToUserList.Name,//x.UserAccountList.Name,
                                CreateDateString = x.CreateDate.ToString("dd-MMM-yy HH:mm:ss")
                            }).ToList()
                            ?? null

                            select new DeliveryServiceResultList
                            {
                                Id = e.Id,
                                BillNo = e.BillNo,
                                BilledDateString = e.BilledDate.ToString("dd-MMM-yy"),
                                PreferableDateTimeString = e.PreferableDateTime.ToString("dd-MMM-yy HH:mm"),


                                DeliveryClientPhoneNo = e.DeliveryClientPhoneNo,
                                DeliveryClientName = e.DeliveryClientName,
                                DeliveryClientAddress = e.DeliveryClientAddress,
                                UserName = e.UserAccountList != null ? e.UserAccountList.Name : null,


                                //UserId = e.InternetUser.UserId,
                                //UserName = e.InternetUser.UserName,
                                DeliveryEntryClientName = e.CustomerList != null ? e.CustomerList.Name : null,  //e.InternetPackageList.PackageName

                                CategoryName = e.CategoryList != null ? e.CategoryList.Name : null,  //e.InternetPackageList.PackageName
                                WeightName = e.WeightList != null ? e.WeightList.WeightName : null,  //e.InternetPackageList.PackageName
                                DistanceName = e.DistanceList != null ? e.DistanceList.DistanceName : null,  //e.InternetPackageList.PackageName

                                Note = e.Note,
                                PickupPoint = e.PickupPoint,
                                //Priority = e.Priority,
                                DeliveryServiceComment = e.DeliveryServiceComment,
                                CommentList = CommentList,//p.DeliveryServiceComment.OrderByDescending(x => x.Id).FirstOrDefault().PurchaseModel.SupplierModel.SupplierName ?? null,
                                CreateDateString = e.CreateDate != null ? e.CreateDate.ToString("dd-MMM-yy") : null,

                            };



                var parser = new Parser<DeliveryServiceResultList>(Request.Form, query);
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
        public ActionResult AddDeliveryService(DeliveryServiceModel model)
        {
            if (ModelState.IsValid)
            {
                if (model.Id == 0)
                {
                    _DeliveryServiceRepository.Insert(model);


                    TempData["Message"] = "Data Save Successfully";
                    TempData["Status"] = "1";
                    tranlog.TransactionLog(RouteData.Values["controller"].ToString(), RouteData.Values["action"].ToString(), TempData["Message"].ToString(), model.Id.ToString(), "Create", model.BillNo);

                }
                else
                {
                    _DeliveryServiceRepository.Update(model, model.Id);


                    TempData["Message"] = "Data Update Successfully";
                    TempData["Status"] = "2";
                    tranlog.TransactionLog(RouteData.Values["controller"].ToString(), RouteData.Values["action"].ToString(), TempData["Message"].ToString(), model.Id.ToString(), "Update", model.BillNo.ToString());

                }
                return RedirectToAction("DeliveryServiceList");
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
        public ActionResult EditDeliveryService(int DeliveryServiceId)
        {
            ViewBag.ActionType = "Edit";

            ViewBag.WeightId = _DeliveryServiceWeightRepository.GetAllForDropDown();
            ViewBag.DeliveryTimingId = _DeliveryServiceTimingRepository.GetAllForDropDown();
            ViewBag.DistanceId = _DeliveryServiceDistanceRepository.GetAllForDropDown();
            ViewBag.PaymentTypeId = _PaymentTypeRepository.GetAllForDropDown();
            ViewBag.CategoryId = _categoryRepository.GetAllForDropDown();


            //var DeliveryService = _DeliveryServiceRepository.Find(DeliveryServiceId);

            var DeliveryService = _DeliveryServiceRepository.All().Include(x => x.UserAccountList).Where(x => x.Id == DeliveryServiceId).FirstOrDefault();

            //if (DeliveryService != null)
            //{
            //    DeliveryService.UserId = DeliveryService.InternetUser.UserId;
            //    DeliveryService.UserName = DeliveryService.InternetUser.UserName;

            //}


            return View("AddDeliveryService", DeliveryService);
        }

        public ActionResult DeleteDeliveryService(int DeliveryServiceId)
        {
            var model = _DeliveryServiceRepository.Find(DeliveryServiceId);
            if (model != null)
            {
                _DeliveryServiceRepository.Delete(model);

                TempData["Message"] = "Data Delete Successfully";
                TempData["Status"] = "3";
                tranlog.TransactionLog(RouteData.Values["controller"].ToString(), RouteData.Values["action"].ToString(), TempData["Message"].ToString(), model.Id.ToString(), "Delete", model.BillNo);



                return RedirectToAction("DeliveryServiceList");
            }
            return RedirectToAction("DeliveryServiceList");
        }
        #endregion


    }
}