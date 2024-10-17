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
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace Atrai.Controllers
{
    [Authorize]
    [OverridableAuthorize]
    public class AssociationController : Controller
    {
        public TransactionLogRepository tranlog { get; }

        private readonly IMemberRepository _memberRepository;
        private readonly IMarketRepository _marketRepository;
        private readonly IShopRepository _shopRepository;
        private readonly ITransactionRepository _transactionRepository;
        private readonly IMemberStatusRepository _memberStatusRepository;
        private readonly IEmployeeRepository _employeeRepository;
        private readonly IDepartmentRepository _departmentRepository;
        private readonly IDesignationRepository _designationRepository;
        private readonly IBloodGroupRepository _bloodGroupRepository;
        private readonly IShiftRepository _shiftRepository;
        private readonly ISectionRepository _sectionRepository;
        private readonly IEmployeeTypeRepository _employeeTypeRepository;





        private readonly IConfiguration configuration;
        private readonly InvoiceDbContext db;

        public AssociationController(InvoiceDbContext context, IMemberRepository memberRepository,
        IMarketRepository marketRepository, IShopRepository shopRepository,
        IMemberStatusRepository memberStatusRepository,
        IEmployeeRepository employeeRepository,
        ITransactionRepository transactionRepository, IConfiguration configuration,
        TransactionLogRepository tranlogRepository, IDepartmentRepository departmentRepository, IDesignationRepository designationRepository, IBloodGroupRepository bloodGroupRepository, IShiftRepository shiftRepository, ISectionRepository sectionRepository, IEmployeeTypeRepository employeeTypeRepository)
        {
            tranlog = tranlogRepository;
            _memberRepository = memberRepository;
            _marketRepository = marketRepository;
            _shopRepository = shopRepository;
            _transactionRepository = transactionRepository;
            _memberStatusRepository = memberStatusRepository;
            _employeeRepository = employeeRepository;
            this.configuration = configuration;
            db = context;
            _departmentRepository = departmentRepository;
            _designationRepository = designationRepository;
            _bloodGroupRepository = bloodGroupRepository;
            _shiftRepository = shiftRepository;
            _sectionRepository = sectionRepository;
            _employeeTypeRepository = employeeTypeRepository;
        }
        public IActionResult Index()
        {
            var dashboard = new AssociationDashboardViewModel
            {
                TotalMember = _memberRepository.All().Count(),
                TotalLifeMember = _memberRepository.All().Where(x => x.MemberType == "Life Member").Count(),
                TotalGeneralMember = _memberRepository.All().Where(x => x.MemberType == "General Member").Count(),

                TotalMarket = _marketRepository.All().Where(x => x.IsInActive == false).Count(),
                TotalShop = _shopRepository.All().Where(x => x.IsInActive == false).Count(),

                //TotalIncome = _transactionRepository.All().Where(x=>x.Account.Type == "Income").Sum(x => x.TransactionAmount),
                //TotalExpense = _transactionRepository.All().Where(x => x.Account.Type == "Expense").Sum(x => x.TransactionAmount),


                TotalApplied = _memberRepository.All().Where(x => x.IsApplied == true && x.isVerified == false && x.IsChecked == false && x.isApproved == false).Count(),
                TotalChecked = _memberRepository.All().Where(x => x.IsChecked == true && x.isVerified == false && x.isApproved == false).Count(),
                TotalVerified = _memberRepository.All().Where(x => x.isVerified == true && x.isApproved == false).Count(),
                TotalApproved = _memberRepository.All().Where(x => x.isApproved == true).Count(),
                TotalCanceled = _memberRepository.All().Where(x => x.isCanceled == true && x.isApproved == false).Count(),



                LastFiveTransaction = _transactionRepository.All().Where(x => x.isSystem == false).OrderByDescending(x => x.InputDate).Take(5).ToList()
            };
            return View(dashboard);
        }


        #region Applied

        public IActionResult MemberListApplied()
        {
            return View();
        }
        [HttpGet]
        public IActionResult MemberApplied(int MemberId)
        {
            ViewBag.ActionType = "Applied";
            var Member = _memberRepository.Find(MemberId);
            ViewBag.Market = _marketRepository.GetAllForDropDown();
            ViewBag.Shop = _shopRepository.GetAllForDropDown();
            ViewBag.MemberStatus = _memberStatusRepository.GetAllForDropDown();
            return View("MemberApplied", Member);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult MemberApplied(MemberModel model)
        {
            //string RandomNumber = RandomDigits(15);
            //string createfilenme = RandomDigits(15);

            if (ModelState.IsValid)
            {
                if (model.Id == 0)
                {
                    // _memberRepository.Insert(model);
                }
                else
                {
                    model.isCanceled = true;
                    _memberRepository.Update(model, model.Id);


                    TempData["Message"] = "Data Update Successfully";
                    TempData["Status"] = "2";
                    tranlog.TransactionLog(RouteData.Values["controller"].ToString(), RouteData.Values["action"].ToString(), TempData["Message"].ToString(), model.Id.ToString(), "Update", model.MembersNameEng + " " + model.MembersNameBng);

                }

                return RedirectToAction("MemberListApplied");
            }
            else
            {
                if (model.Id == 0)
                {
                    ViewBag.ActionType = "Applied";
                }

            }
            return View(model);
        }
        public ActionResult MemberAppliedApprove(int MemberId)
        {
            var model = _memberRepository.Find(MemberId);

            if (model != null)
            {
                model.IsApplied = true;
                _memberRepository.Update(model, model.Id);



                TempData["Message"] = "Data Update Successfully";
                TempData["Status"] = "2";
                tranlog.TransactionLog(RouteData.Values["controller"].ToString(), RouteData.Values["action"].ToString(), TempData["Message"].ToString(), model.Id.ToString(), "Update", model.MembersNameEng + " " + model.MembersNameBng);

                return RedirectToAction("MemberListApplied");
            }
            return RedirectToAction("MemberListApplied");
        }
        #endregion


        #region checking

        public IActionResult MemberListChecking()
        {
            return View();
        }
        [HttpGet]
        public IActionResult MemberChecking(int MemberId)
        {
            ViewBag.ActionType = "Checking";
            var Member = _memberRepository.Find(MemberId);
            ViewBag.Market = _marketRepository.GetAllForDropDown();
            ViewBag.Shop = _shopRepository.GetAllForDropDown();
            ViewBag.MemberStatus = _memberStatusRepository.GetAllForDropDown();
            return View("MemberChecking", Member);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult MemberChecking(MemberModel model)
        {
            //string RandomNumber = RandomDigits(15);
            //string createfilenme = RandomDigits(15);

            if (ModelState.IsValid)
            {
                if (model.Id == 0)
                {
                    // _memberRepository.Insert(model);
                }
                else
                {
                    model.IsApplied = false;
                    _memberRepository.Update(model, model.Id);



                    TempData["Message"] = "Data Update Successfully";
                    TempData["Status"] = "2";
                    tranlog.TransactionLog(RouteData.Values["controller"].ToString(), RouteData.Values["action"].ToString(), TempData["Message"].ToString(), model.Id.ToString(), "Update", model.MembersNameEng + " " + model.MembersNameBng);

                }

                return RedirectToAction("MemberListChecking");
            }
            else
            {
                if (model.Id == 0)
                {
                    ViewBag.ActionType = "Checking";
                }

            }
            return View(model);
        }
        public ActionResult MemberCheckingApprove(int MemberId)
        {
            var model = _memberRepository.Find(MemberId);

            if (model != null)
            {
                model.IsChecked = true;
                _memberRepository.Update(model, model.Id);



                TempData["Message"] = "Member Checking Approve Successfully";
                TempData["Status"] = "2";
                tranlog.TransactionLog(RouteData.Values["controller"].ToString(), RouteData.Values["action"].ToString(), TempData["Message"].ToString(), model.Id.ToString(), "Update", model.MembersNameEng + " " + model.MembersNameBng);

                return RedirectToAction("MemberListChecking");
            }
            return RedirectToAction("MemberListChecking");
        }
        #endregion


        #region Verified

        public IActionResult MemberListVerified()
        {
            return View();
        }
        [HttpGet]
        public IActionResult MemberVerified(int MemberId)
        {
            ViewBag.ActionType = "Verified";
            var Member = _memberRepository.Find(MemberId);
            ViewBag.Market = _marketRepository.GetAllForDropDown();
            ViewBag.Shop = _shopRepository.GetAllForDropDown();
            ViewBag.MemberStatus = _memberStatusRepository.GetAllForDropDown();
            return View("MemberVerified", Member);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult MemberVerified(MemberModel model)
        {
            //string RandomNumber = RandomDigits(15);
            //string createfilenme = RandomDigits(15);

            if (ModelState.IsValid)
            {
                if (model.Id == 0)
                {
                    // _memberRepository.Insert(model);
                }
                else
                {
                    model.IsChecked = false;
                    _memberRepository.Update(model, model.Id);



                    TempData["Message"] = "Member Verified Cancel";
                    TempData["Status"] = "2";
                    tranlog.TransactionLog(RouteData.Values["controller"].ToString(), RouteData.Values["action"].ToString(), TempData["Message"].ToString(), model.Id.ToString(), "Update", model.MembersNameEng + " " + model.MembersNameBng);

                }

                return RedirectToAction("MemberListVerified");
            }
            else
            {
                if (model.Id == 0)
                {
                    ViewBag.ActionType = "Verified";
                }

            }
            return View(model);
        }
        public ActionResult MemberVerifiedApprove(int MemberId)
        {
            var model = _memberRepository.Find(MemberId);

            if (model != null)
            {
                model.isVerified = true;
                _memberRepository.Update(model, model.Id);



                TempData["Message"] = "Member Verified Approved";
                TempData["Status"] = "2";
                tranlog.TransactionLog(RouteData.Values["controller"].ToString(), RouteData.Values["action"].ToString(), TempData["Message"].ToString(), model.Id.ToString(), "Update", model.MembersNameEng + " " + model.MembersNameBng.ToString());

                return RedirectToAction("MemberListVerified");
            }
            return RedirectToAction("MemberListVerified");
        }
        #endregion


        #region Approval

        public IActionResult MemberListApproval()
        {
            return View();
        }
        [HttpGet]
        public IActionResult MemberApproval(int MemberId)
        {
            ViewBag.ActionType = "Approval";
            var Member = _memberRepository.Find(MemberId);
            ViewBag.Market = _marketRepository.GetAllForDropDown();
            ViewBag.Shop = _shopRepository.GetAllForDropDown();
            ViewBag.MemberStatus = _memberStatusRepository.GetAllForDropDown();
            return View("MemberApproval", Member);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult MemberApproval(MemberModel model)
        {
            //string RandomNumber = RandomDigits(15);
            //string createfilenme = RandomDigits(15);

            if (ModelState.IsValid)
            {
                if (model.Id == 0)
                {
                    // _memberRepository.Insert(model);
                }
                else
                {
                    model.isVerified = false;
                    _memberRepository.Update(model, model.Id);



                    TempData["Message"] = "Data Update Successfully";
                    TempData["Status"] = "2";
                    tranlog.TransactionLog(RouteData.Values["controller"].ToString(), RouteData.Values["action"].ToString(), TempData["Message"].ToString(), model.Id.ToString(), "Update", model.MembersNameEng + " " + model.MembersNameBng);

                }

                return RedirectToAction("MemberListApproval");
            }
            else
            {
                if (model.Id == 0)
                {
                    ViewBag.ActionType = "Approval";
                }

            }
            return View(model);
        }
        public ActionResult MemberApprovalApprove(int MemberId)
        {
            var model = _memberRepository.Find(MemberId);

            if (model != null)
            {
                model.isApproved = true;
                model.isActive = true;
                _memberRepository.Update(model, model.Id);



                TempData["Message"] = "Member Approval Successfully";
                TempData["Status"] = "2";
                tranlog.TransactionLog(RouteData.Values["controller"].ToString(), RouteData.Values["action"].ToString(), TempData["Message"].ToString(), model.Id.ToString(), "Update", model.MembersNameEng + " " + model.MembersNameBng.ToString());

                return RedirectToAction("MemberListApproval");
            }
            return RedirectToAction("MemberListApproval");
        }
        #endregion


        #region Canceld

        public IActionResult MemberListCanceled()
        {
            return View();
        }
        [HttpGet]
        public IActionResult MemberCanceled(int MemberId)
        {
            ViewBag.ActionType = "Canceled";
            var Member = _memberRepository.Find(MemberId);
            ViewBag.Market = _marketRepository.GetAllForDropDown();
            ViewBag.Shop = _shopRepository.GetAllForDropDown();
            ViewBag.MemberStatus = _memberStatusRepository.GetAllForDropDown();
            return View("MemberCanceled", Member);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult MemberCanceled(MemberModel model)
        {
            //string RandomNumber = RandomDigits(15);
            //string createfilenme = RandomDigits(15);

            if (ModelState.IsValid)
            {
                if (model.Id == 0)
                {
                    // _memberRepository.Insert(model);
                }
                else
                {
                    model.IsChecked = false;
                    _memberRepository.Update(model, model.Id);



                    TempData["Message"] = "Data Update Successfully";
                    TempData["Status"] = "2";
                    tranlog.TransactionLog(RouteData.Values["controller"].ToString(), RouteData.Values["action"].ToString(), TempData["Message"].ToString(), model.Id.ToString(), "Update", model.MembersNameEng + " " + model.MembersNameBng);

                }

                return RedirectToAction("MemberListCanceled");
            }
            else
            {
                if (model.Id == 0)
                {
                    ViewBag.ActionType = "Canceled";
                }

            }
            return View(model);
        }
        public ActionResult MemberCanceledApprove(int MemberId)
        {
            var model = _memberRepository.Find(MemberId);

            if (model != null)
            {
                model.IsChecked = true;
                _memberRepository.Update(model, model.Id);



                TempData["Message"] = "Member Canceled Approved";
                TempData["Status"] = "2";
                tranlog.TransactionLog(RouteData.Values["controller"].ToString(), RouteData.Values["action"].ToString(), TempData["Message"].ToString(), model.Id.ToString(), "Update", model.MembersNameEng + " " + model.MembersNameBng.ToString());

                return RedirectToAction("MemberListCanceled");
            }
            return RedirectToAction("MemberListCanceled");
        }
        #endregion


        #region Member
        public IActionResult MemberList()
        {
            //var Members = _memberRepository.All();
            //return View(Members);
            return View();
        }
        public async Task<IActionResult> MemberLIstSearch()
        {
            var Members = await _memberRepository.All().ToListAsync();
            return View(Members);
            //return View();
        }





        public IActionResult MonthlySubscriptionProcess(string From, string To)
        {
            try
            {
                var UserId = HttpContext.Session.GetInt32("UserId");
                var ComId = HttpContext.Session.GetInt32("ComId");

                if (From == null || From == "")
                {
                    From = DateTime.Now.Date.ToString("dd-MMM-yy");
                    To = DateTime.Now.Date.ToString("dd-MMM-yy");
                }

                //Exec [prcProcessMonthlySubscriptionFee] 1, '01-Jan-2021','31-JAN-2021'/
                var query = $"Exec prcProcessMonthlySubscriptionFee '{UserId}','{ComId}','{From}','{To}'";

                SqlParameter[] sqlParameter = new SqlParameter[4];
                sqlParameter[0] = new SqlParameter("@UserId", UserId);
                sqlParameter[1] = new SqlParameter("@ComId", ComId);
                sqlParameter[2] = new SqlParameter("@dtFrom", From);
                sqlParameter[3] = new SqlParameter("@dtTo", To);
                Helper.ExecProc("prcProcessMonthlySubscriptionFee", sqlParameter);



                TempData["Message"] = "Data Process Successfully";
                return View("MemberList");


            }
            catch (Exception ex)
            {
                errorlog(ex);
                throw ex;
            }

        }

        public IActionResult ImageExistCheck(string From, string To)
        {
            try
            {



                var UserId = HttpContext.Session.GetInt32("UserId");
                var ComId = HttpContext.Session.GetInt32("ComId");

                if (From == null || From == "")
                {
                    From = "9999";
                    To = "9999";
                }


                {
                    List<string> listoferror = new List<string>();



                    var abcd = _memberRepository.All().Where(x => x.MemberAccessId >= int.Parse(From) && x.MemberAccessId <= int.Parse(To));

                    //listoferror.Add("location not found - path not found");
                    foreach (var item in abcd)
                    {
                        if (item.MemberImagePath != null)
                        {
                            string abcdef = "wwwroot" + item.MemberImagePath;
                            //C:\D drive\Programing\WEB Project Entity Framwork\Invoice\InvoiceCore\Invoice\wwwroot\Content\MemberImages\0.png
                            if (System.IO.File.Exists(abcdef))
                            {
                                //if (item.IsExistImage == false)
                                //{
                                //    item.IsExistImage = true;
                                //    listoferror.Add(item.MemberAccessId.ToString());
                                //}
                                //errorlog("location not found - path not found");
                            }
                            else
                            {
                                //item.IsExistImage = false;
                                listoferror.Add(item.MemberAccessId.ToString());
                            }
                        }
                    }
                    if (listoferror != null)
                    {
                        if (listoferror.Count > 0)
                        {
                            errorlog(listoferror);
                        }
                    }
                    //var Members = _memberRepository.All();
                    //return View(Members);
                }
                TempData["Message"] = "Data Process Successfully";
                return View("MemberList");


            }
            catch (Exception ex)
            {
                errorlog(ex);
                throw ex;
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


        public void errorlog(List<string> ex)
        {
            string filePath = @"C:\DevelopmentError\DevelopmentFile.txt";

            using (StreamWriter writer = new StreamWriter(filePath, true))
            {

                foreach (var item in ex)
                {
                    writer.WriteLine(item.ToString());

                    MemberModel model = _memberRepository.All().Where(x => x.MemberAccessId == int.Parse(item.ToString())).FirstOrDefault();

                    model.IsExistImage = false;
                    _memberRepository.Update(model, model.Id);

                    TempData["Message"] = "Data Update Successfully";
                    TempData["Status"] = "2";
                    tranlog.TransactionLog(RouteData.Values["controller"].ToString(), RouteData.Values["action"].ToString(), TempData["Message"].ToString(), model.Id.ToString(), "Update", model.MembersNameEng + " " + model.MembersNameBng.ToString());
                }

                writer.WriteLine("-----------------------------------------------------------------------------");
                writer.WriteLine("Date : " + DateTime.Now.ToString());
                writer.WriteLine();

            }



        }

        public class memberResult
        {
            public int Id { get; set; }
            public string? MemberAccessId { get; set; }
            public string? MemberType { get; set; }
            public string? MembersNameEng { get; set; }
            public string? MembersNameBng { get; set; }
            public string? FathersNameEng { get; set; }
            public string? FathersNameBng { get; set; }
            public string? ShopNameEng { get; set; }
            public string? ShopNameBng { get; set; }
            public string? HoldingNoEng { get; set; }

            public string? HoldingNoBng { get; set; }


            public string? DOB { get; set; }

            public string? BloodGroup { get; set; }
            public string? Mobile { get; set; }
            public string? MemberHomePhone { get; set; }

            public string? MarketName { get; set; }
            public string? BusinessAddressBng { get; set; }
            public string? BusinessAddressEng { get; set; }
            public string? FixedAddress { get; set; }
            public string? NID { get; set; }
            public string? CardNo { get; set; }


            public string? MemberBarcodeId { get; set; }


            public string? ImagePath { get; set; }
            public string? Photo { get; set; }

            public string? IsActive { get; set; }
            public string? Status { get; set; }


        }

        [AllowAnonymous]
        public JsonResult GetMemberList(string filter = "All")
        {
            try
            {

                //var Members= _context.Members.ToList();
                var Members = _memberRepository.All();



                if (filter == "All")
                {
                    Members = _memberRepository.All().Where(x => x.isActive == true);
                }
                else if (filter == "Canceled")
                {
                    Members = _memberRepository.All().Where(x => x.isCanceled == true);
                }
                else if (filter == "Applied")
                {
                    Members = _memberRepository.All().Where(x => x.isCanceled == false && x.IsApplied == false);
                }
                else if (filter == "Checking")
                {
                    Members = _memberRepository.All().Where(x => x.IsChecked == false && x.IsApplied == true);
                }
                else if (filter == "Verified")
                {
                    Members = _memberRepository.All().Where(x => x.isVerified == false && x.IsChecked == true);
                }
                else if (filter == "Approval")
                {
                    Members = _memberRepository.All().Where(x => x.isApproved == false && x.isVerified == true);
                }
                //.Include(x=>x.vUnit).Include(x=>x.Market);
                var query = from e in Members//.Where(x => x.Id > 0 && x.ComId == comid).OrderByDescending(x => x.Id)

                            select new memberResult
                            {
                                Id = e.Id,
                                MemberAccessId = e.MemberAccessId.ToString(),
                                MemberType = e.MemberType,
                                MembersNameEng = e.MembersNameEng,
                                MembersNameBng = e.MembersNameBng,

                                FathersNameEng = e.FathersNameEng,
                                FathersNameBng = e.FathersNameBng,
                                ShopNameEng = e.ShopNameEng,
                                ShopNameBng = e.ShopNameBng,


                                BusinessAddressEng = e.HoldingNoEng + " , " + e.BusinessAddressEng,
                                BusinessAddressBng = e.HoldingNoBng + " , " + e.BusinessAddressBng,

                                FixedAddress = e.FixedAddress,
                                NID = e.NID,
                                CardNo = e.CardNo,

                                MemberBarcodeId = e.MemberBarcodeId,



                                DOB = e.DOB != null ? e.DOB.Value.ToString("dd-MMM-yy") : "=N/A=",//e.DOB.ToString("dd-MMM-yy"),
                                IsActive = e.isActive != false ? "Active" : "Not Active",//e.DOB.ToString("dd-MMM-yy"),
                                Status = e.MemberStatus != null ? e.MemberStatus.MemberStatusShort : "=N/A=",//e.DOB.ToString("dd-MMM-yy"),


                                //isPost = e.isPost,
                                //Status = e.isPost != false ? "Posted" : "Not Posted"


                                BloodGroup = e.BloodGroup,
                                Mobile = e.Mobile,
                                MemberHomePhone = e.MemberHomePhone,

                                MarketName = e.MarketName,
                                ImagePath = e.MemberImagePath
                                //Photo = e.MemberImagePath.ToString()

                            };



                var parser = new Parser<memberResult>(Request.Form, query);
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
        public IActionResult MembershipForm()
        {
            ViewBag.ActionType = "Create";
            //ViewBag.Market = _marketRepository.GetAllForDropDown();
            //ViewBag.Shop = _shopRepository.GetAllForDropDown();
            //ViewBag.MemberStatus = _memberStatusRepository.GetAllForDropDown();


            MemberModel abc = new MemberModel();
            abc.CreateDate = DateTime.Now;
            return View(abc);
        }



        [HttpGet]
        public IActionResult AddMember()
        {
            ViewBag.ActionType = "Create";
            ViewBag.Market = _marketRepository.GetAllForDropDown();
            ViewBag.Shop = _shopRepository.GetAllForDropDown();
            ViewBag.MemberStatus = _memberStatusRepository.GetAllForDropDown();


            MemberModel abc = new MemberModel();
            return View(abc);
        }

        public string? RandomDigits(int length)
        {
            var random = new Random();
            string s = string.Empty;
            for (int i = 0; i < length; i++)
                s = String.Concat(s, random.Next(10).ToString());
            return s;
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult AddMember(MemberModel model, IFormFile logoPostedFileBase)
        {
            //string RandomNumber = RandomDigits(15);
            string createfilenme = RandomDigits(15);

            if (ModelState.IsValid)
            {
                if (model.Id == 0)
                {
                    _memberRepository.Insert(model);

                    TempData["Message"] = "Data Save Successfully";
                    TempData["Status"] = "1";
                    tranlog.TransactionLog(RouteData.Values["controller"].ToString(), RouteData.Values["action"].ToString(), TempData["Message"].ToString(), model.Id.ToString(), "Create", model.MembersNameEng + " " + model.MembersNameBng.ToString());

                }
                else
                {
                    _memberRepository.Update(model, model.Id);



                    TempData["Message"] = "Data Update Successfully";
                    TempData["Status"] = "2";
                    tranlog.TransactionLog(RouteData.Values["controller"].ToString(), RouteData.Values["action"].ToString(), TempData["Message"].ToString(), model.Id.ToString(), "Update", model.MembersNameEng + " " + model.MembersNameBng.ToString());

                }

                if (model.MemberType != null) createfilenme = model.MemberType.Substring(0, 1) + model.MemberAccessId + "-" + createfilenme + System.IO.Path.GetExtension(logoPostedFileBase.FileName); //else /*Do something else*/ ;

                //craetefilenme =  model.MemberAccessId

                if (logoPostedFileBase != null && logoPostedFileBase.Length > 0)
                {
                    var path = Path.Combine(
                     Directory.GetCurrentDirectory(), "wwwroot/Content/MemberImages",
                     //logoPostedFileBase.FileName
                     createfilenme
                     );

                    using (var stream = new FileStream(path, FileMode.Create))
                    {
                        logoPostedFileBase.CopyTo(stream);
                    }
                    //model.MemberImagePath = $"/Content/MemberImages/{logoPostedFileBase.FileName}";
                    model.MemberImagePath = $"/Content/MemberImages/{createfilenme}";
                    model.IsExistImage = true;
                }
                else
                {
                    var Members = _memberRepository.Find(model.Id);
                    if (Members != null)
                        model.MemberImagePath = Members.MemberImagePath;
                    model.IsExistImage = model.IsExistImage;
                }
                _memberRepository.Update(model, model.Id);



                TempData["Message"] = "Data Update Successfully";
                TempData["Status"] = "2";
                tranlog.TransactionLog(RouteData.Values["controller"].ToString(), RouteData.Values["action"].ToString(), TempData["Message"].ToString(), model.Id.ToString(), "Update", model.MembersNameEng + " " + model.MembersNameBng.ToString());



                return RedirectToAction("MemberList");
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


        [HttpPost]
        public IActionResult SaveMemberModal([FromBody] MemberModel model)
        {
            if (!ModelState.IsValid)
            {
                return Json("Model is not valid");

            }
            _memberRepository.Insert(model);


            TempData["Message"] = "Data Save Successfully";
            TempData["Status"] = "1";
            tranlog.TransactionLog(RouteData.Values["controller"].ToString(), RouteData.Values["action"].ToString(), TempData["Message"].ToString(), model.Id.ToString(), "Create", model.MembersNameEng + " " + model.MembersNameBng.ToString());


            return Json("Member Added Successfully");
        }


        [HttpGet]
        public IActionResult EditMember(int MemberId)
        {
            ViewBag.ActionType = "Edit";
            var Member = _memberRepository.Find(MemberId);
            ViewBag.Market = _marketRepository.GetAllForDropDown();
            ViewBag.Shop = _shopRepository.GetAllForDropDown();
            ViewBag.MemberStatus = _memberStatusRepository.GetAllForDropDown();
            return View("AddMember", Member);
        }


        [HttpGet]
        public IActionResult MemberSearch(string MemberBarcode)
        {
            ViewBag.ActionType = "Search";
            var Member = new MemberModel();

            if (MemberBarcode != null && MemberBarcode != "")
            {
                Member = _memberRepository.All().Where(x => x.MemberBarcodeId == MemberBarcode).FirstOrDefault();


            }
            else
            {
                Member = _memberRepository.All().Where(x => x.MemberBarcodeId == "L100000").FirstOrDefault();
            }

            ViewBag.Market = _marketRepository.GetAllForDropDown();
            ViewBag.Shop = _shopRepository.GetAllForDropDown();
            ViewBag.MemberStatus = _memberStatusRepository.GetAllForDropDown();


            return View(Member);
        }


        [HttpGet]
        [AllowAnonymous]
        public IActionResult OnlineMemberSearch(string MemberBarcode, string CardNo)
        {
            ViewBag.ActionType = "Search";
            var Member = new MemberModel();

            if (MemberBarcode != null && MemberBarcode != "")
            {
                Member = _memberRepository.All(false).Where(x => x.MemberBarcodeId == MemberBarcode && x.CardNo == CardNo).FirstOrDefault();

                if (Member != null)
                {
                    if (Member.ComId != null)
                    {
                        HttpContext.Session.SetInt32("ComId", Member.ComId);
                    }
                }


                TempData["Message"] = "Data Search Successfully";
                TempData["Status"] = "3";
                tranlog.TransactionLog(RouteData.Values["controller"].ToString(), RouteData.Values["action"].ToString(), TempData["Message"].ToString(), CardNo, "OnlineMemberSearch", MemberBarcode);

            }
            else
            {
                Member = _memberRepository.All(false).Where(x => x.MemberBarcodeId == "L100000").FirstOrDefault();

                if (Member != null)
                {
                    if (Member.ComId != null)
                    {
                        HttpContext.Session.SetInt32("ComId", Member.ComId);
                    }
                }


                TempData["Message"] = "Data Search Successfully";
                TempData["Status"] = "3";
                tranlog.TransactionLog(RouteData.Values["controller"].ToString(), RouteData.Values["action"].ToString(), TempData["Message"].ToString(), CardNo, "OnlineMemberSearch", MemberBarcode);
            }

            ViewBag.Market = _marketRepository.GetAllForDropDown();
            ViewBag.Shop = _shopRepository.GetAllForDropDown();
            ViewBag.MemberStatus = _memberStatusRepository.GetAllForDropDown();



            return View(Member);
        }


        public ActionResult DeleteMember(int MemberId)
        {
            var model = _memberRepository.Find(MemberId);

            if (model != null)
            {
                _memberRepository.Delete(model);

                TempData["Message"] = "Data Delete Successfully";
                TempData["Status"] = "3";
                tranlog.TransactionLog(RouteData.Values["controller"].ToString(), RouteData.Values["action"].ToString(), TempData["Message"].ToString(), model.Id.ToString(), "Delete", model.MembersNameEng + " " + model.MembersNameBng);

                return RedirectToAction("MemberList");
            }
            return RedirectToAction("MemberList");
        }




        #endregion





        #region Employee
        public IActionResult EmployeeList()
        {
            //var Employees = _employeeRepository.All();
            //return View(Employees);
            return View();
        }
        public async Task<IActionResult> EmployeeLIstSearch()
        {
            var Employees = await _employeeRepository.All().ToListAsync();
            return View(Employees);
            //return View();
        }







        public class employeeResult : EmployeeModel
        {

            public string? IsActiveString { get; set; }
            public string? BloodGroup { get; set; }


            public string? DOBString { get; set; }
            public string? JoiningDateString { get; set; }




        }

        public class PagingInfo
        {
            public int PageNo { get; set; }

            public int PageSize { get; set; }

            public int PageCount { get; set; }

            public long TotalRecordCount { get; set; }

        }



        [AllowAnonymous]
        public IActionResult GetEmployetListAll(string searchquery = "", int page = 1, decimal size = 5)
        {
            var employeeList = _employeeRepository.All();

            if (searchquery?.Length > 1)
            {
                employeeList = employeeList.Where(x =>
                    x.EmployeeName.ToLower().Contains(searchquery.ToLower())
                );

            }
            decimal TotalRecordCount = employeeList.Count();
            var PageCountabc = decimal.Parse((TotalRecordCount / size).ToString());
            var PageCount = Math.Ceiling(PageCountabc);
            decimal skip = (page - 1) * size;

            var query = from e in employeeList.Include(x => x.DesignationList)
                        .Include(x => x.DepartmentList)
                        .Include(x => x.Cat_Shift)
                        .Include(x => x.Cat_Section)

                        select new
                        {
                            e.Id,
                            e.SLNo,
                            e.EmployeeCode,
                            e.FingerId,
                            e.EmployeeName,
                            e.DesignationList.DesigName,
                            e.DepartmentList.DeptName,
                            e.Cat_Shift.ShiftName,
                            e.Cat_Section.SectName,
                            e.EmployeeType.EmployeeType,
                            DtJoin = ((DateTime)e.DtJoin).ToString("dd-MMM-yyyy"),
                            e.GrossSalary,
                            e.EmpAdvanceBalance,
                            e.EmpLoanBalance,
                            e.EmpEmail,
                            e.MobileNo
                        };

            var abcd = query.OrderByDescending(x => x.Id).Skip(int.Parse(skip.ToString())).Take(int.Parse(size.ToString())).ToList();// Take(50);
            var pageinfo = new PagingInfo();
            pageinfo.PageCount = int.Parse(PageCount.ToString());
            pageinfo.PageNo = page;
            pageinfo.PageSize = int.Parse(size.ToString());
            pageinfo.TotalRecordCount = int.Parse(TotalRecordCount.ToString());
            return Json(new { Success = 1, error = false, data = abcd, page = page, size = size, last_page = pageinfo.PageCount, total = pageinfo.TotalRecordCount });
        }


        [AllowAnonymous]
        public JsonResult GetEmployeeList(string filter = "All")
        {
            try
            {

                //var Employees= _context.Employees.ToList();
                var Employees = _employeeRepository.All();




                if (filter == "All")
                {
                    Employees = _employeeRepository.All();//.Where(x => x.isActive == true)
                }

                //.Include(x=>x.vUnit).Include(x=>x.Market);
                var query = from e in Employees//.Where(x => x.Id > 0 && x.ComId == comid).OrderByDescending(x => x.Id)

                            select new employeeResult
                            {
                                Id = e.Id,
                                EmployeeCode = e.EmployeeCode,
                                EmployeeName = e.EmployeeName,
                                FathersName = e.FathersName,

                                PermanentAddress = e.PermanentAddress,
                                PresentAddress = e.PresentAddress,


                                PositionTitle = e.PositionTitle,
                                //Department = e.Cat_Department.DeptName,
                                NID = e.NID,



                                IntroducerName = e.IntroducerName,
                                IntroducerContctNo = e.IntroducerContctNo,
                                IntroducerAddress = e.IntroducerAddress,

                                EmergencyContactName = e.EmergencyContactName,
                                EmergencyContactRelationship = e.EmergencyContactRelationship,
                                EmergencyMobileNo = e.EmergencyMobileNo,


                                DOBString = e.DtBirth != null ? e.DtBirth.GetValueOrDefault().ToString("dd-MMM-yy") : "=N/A=",//e.DOB.ToString("dd-MMM-yy"),
                                JoiningDateString = e.DtJoin != null ? e.DtJoin.GetValueOrDefault().ToString("dd-MMM-yy") : "=N/A=",//e.DOB.ToString("dd-MMM-yy"),
                                IsActiveString = e.isActive != false ? "Active" : "Not Active",//e.DOB.ToString("dd-MMM-yy"),

                                //isPost = e.isPost,
                                //Status = e.isPost != false ? "Posted" : "Not Posted"

                                BloodGroup = e.Cat_BloodGroup.BloodName,
                                MobileNo = e.MobileNo,
                                EmployeeImagePath = e.EmployeeImagePath

                                //Photo = e.EmployeeImagePath.ToString()

                            };



                var parser = new Parser<employeeResult>(Request.Form, query);
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
        public IActionResult AddEmployee()
        {
            ViewBag.ActionType = "Create";
            //ViewBag.Shop = _shopRepository.GetAllForDropDown();
            ViewBag.Department = _departmentRepository.GetAllForDropDown();
            ViewBag.Designation = _designationRepository.GetAllForDropDown();
            ViewBag.BloodGroup = _bloodGroupRepository.GetAllForDropDown();
            ViewBag.Shift = _shiftRepository.GetAllForDropDown();
            ViewBag.Section = _sectionRepository.GetAllForDropDown();
            ViewBag.EmployeeType = _employeeTypeRepository.GetAllForDropDown();





            EmployeeModel abc = new EmployeeModel();
            return View(abc);
        }



        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult AddEmployee(EmployeeModel model, IFormFile logoPostedFileBase)
        {

            var errors = ModelState.Where(x => x.Value.Errors.Any())
            .Select(x => new { x.Key, x.Value.Errors });
            //string RandomNumber = RandomDigits(15);
            string createfilenme = RandomDigits(15);

            if (ModelState.IsValid)
            {
                if (model.Id == 0)
                {
                    _employeeRepository.Insert(model);

                    TempData["Message"] = "Data Save Successfully";
                    TempData["Status"] = "1";
                    tranlog.TransactionLog(RouteData.Values["controller"].ToString(), RouteData.Values["action"].ToString(), TempData["Message"].ToString(), model.Id.ToString(), "Create", model.EmployeeName.ToString());
                }
                else
                {
                    _employeeRepository.Update(model, model.Id);

                    TempData["Message"] = "Data Update Successfully";
                    TempData["Status"] = "2";
                    tranlog.TransactionLog(RouteData.Values["controller"].ToString(), RouteData.Values["action"].ToString(), TempData["Message"].ToString(), model.Id.ToString(), "Update", model.EmployeeName.ToString());

                }
                //if (model.EmployeeType != null) createfilenme = model.EmployeeType.Substring(0, 1) + model.EmployeeId + "-" + createfilenme + System.IO.Path.GetExtension(logoPostedFileBase.FileName); //else /*Do something else*/ ;
                //craetefilenme =  model.EmployeeId




                if (logoPostedFileBase != null && logoPostedFileBase.Length > 0)
                {
                    var filename = model.Id + "_" + model.EmployeeCode + "_" + model.EmployeeName + "_" + logoPostedFileBase.FileName;

                    var path = Path.Combine(
                     Directory.GetCurrentDirectory(), "wwwroot/Content/EmployeeImages",
                     filename);

                    using (var stream = new FileStream(path, FileMode.Create))
                    {
                        logoPostedFileBase.CopyTo(stream);
                    }
                    model.EmployeeImagePath = $"/Content/EmployeeImages/{filename}";
                    model.IsExistImage = true;
                }
                else
                {
                    var Employees = _employeeRepository.Find(model.Id);
                    if (Employees != null)
                        model.EmployeeImagePath = Employees.EmployeeImagePath;
                    model.IsExistImage = model.IsExistImage;
                }

                //if (logoPostedFileBase != null && logoPostedFileBase.Length > 0)
                //{


                //    var path = Path.Combine(
                //     Directory.GetCurrentDirectory(), "wwwroot/Content/EmployeeImages",
                //     //logoPostedFileBase.FileName
                //     createfilenme + logoPostedFileBase.FileName
                //     );

                //    using (var stream = new FileStream(path, FileMode.Create))
                //    {
                //        logoPostedFileBase.CopyTo(stream);
                //    }
                //    //model.EmployeeImagePath = $"/Content/EmployeeImages/{logoPostedFileBase.FileName}";
                //    model.EmployeeImagePath = $"/Content/EmployeeImages/{createfilenme}";
                //    model.IsExistImage = true;
                //}
                //else
                //{
                //    var Employees = _employeeRepository.Find(model.Id);
                //    if (Employees != null)
                //        model.EmployeeImagePath = Employees.EmployeeImagePath;
                //    model.IsExistImage = model.IsExistImage;
                //}
                _employeeRepository.Update(model, model.Id);

                TempData["Message"] = "Data Update Successfully";
                TempData["Status"] = "2";
                tranlog.TransactionLog(RouteData.Values["controller"].ToString(), RouteData.Values["action"].ToString(), TempData["Message"].ToString(), model.Id.ToString(), "Update", model.EmployeeName.ToString());

                return RedirectToAction("EmployeeList");
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


        [HttpPost]
        public IActionResult SaveEmployeeModal([FromBody] EmployeeModel model)
        {
            if (!ModelState.IsValid)
            {
                return Json("Model is not valid");

            }
            _employeeRepository.Insert(model);


            TempData["Message"] = "Data Save Successfully";
            TempData["Status"] = "1";
            tranlog.TransactionLog(RouteData.Values["controller"].ToString(), RouteData.Values["action"].ToString(), TempData["Message"].ToString(), model.Id.ToString(), "Create", model.EmployeeName + " " + model.EmployeeName.ToString());


            return Json("Employee Added Successfully");
        }


        [HttpGet]
        public IActionResult EditEmployee(int Id)
        {
            ViewBag.ActionType = "Edit";
            var Employee = _employeeRepository.Find(Id);

            ViewBag.Department = _departmentRepository.GetAllForDropDown();
            ViewBag.Designation = _designationRepository.GetAllForDropDown();
            ViewBag.BloodGroup = _bloodGroupRepository.GetAllForDropDown();
            ViewBag.Shift = _shiftRepository.GetAllForDropDown();
            ViewBag.Section = _sectionRepository.GetAllForDropDown();
            ViewBag.EmployeeType = _employeeTypeRepository.GetAllForDropDown();
            //ViewBag.Market = _marketRepository.GetAllForDropDown();

            return View("AddEmployee", Employee);
        }


        [HttpGet]
        [AllowAnonymous]
        public ActionResult DeleteEmployee(int EmployeeId)
        {
            var model = _employeeRepository.Find(EmployeeId);

            if (model != null)
            {
                _employeeRepository.Delete(model);

                TempData["Message"] = "Data Delete Successfully";
                TempData["Status"] = "3";
                tranlog.TransactionLog(RouteData.Values["controller"].ToString(), RouteData.Values["action"].ToString(), TempData["Message"].ToString(), model.Id.ToString(), "Delete", model.EmployeeName);

                return Json(new { success = "1", msg = "Deleted Successfully" });

                //return RedirectToAction("EmployeeList");
            }
            return Json(new { success = "0", msg = "No items found to delete." });
            //return RedirectToAction("EmployeeList");
        }




        #endregion









        #region Shop
        public IActionResult ShopList()
        {
            //var Shops = _shopRepository.All();
            //return View(Shops);
            return View();
        }

        public class ShopResult
        {
            public int Id { get; set; }
            public string? ShopCode { get; set; }
            public string? ShopNameEng { get; set; }
            public string? ShopNameBng { get; set; }
            public string? MarketName { get; set; }
            public string? ShopBusinessAddressEng { get; set; }
            public string? ShopBusinessAddressBng { get; set; }
            public string? HoldingNoEng { get; set; }
            public string? HoldingNoBng { get; set; }
            public string? ShopImagePath { get; set; }
            public string? ShopOwnerEng { get; set; }
            public string? ShopOwnerBng { get; set; }

            public string? ShopMobile { get; set; }
            public string? ItemsProduct { get; set; }

            public string? ShopImage { get; set; }


        }

        [AllowAnonymous]
        public JsonResult GetShopList()
        {
            try
            {

                //var Shops= _context.Shops.ToList();



                var Shops = _shopRepository.All();//.Include(x=>x.vUnit).Include(x=>x.Market);
                var query = from e in Shops//.Where(x => x.Id > 0 && x.ComId == comid).OrderByDescending(x => x.Id)

                            select new ShopResult
                            {
                                Id = e.Id,
                                ShopCode = e.ShopCode,
                                ShopNameBng = e.ShopNameBng,
                                ShopNameEng = e.ShopNameEng,

                                ShopBusinessAddressEng = e.HoldingNoEng + " , " + e.ShopBusinessAddressEng,
                                ShopBusinessAddressBng = e.HoldingNoBng + " , " + e.ShopBusinessAddressBng,

                                //HoldingNoBng = e.HoldingNoBng,
                                //HoldingNoEng = e.HoldingNoEng,


                                ShopOwnerEng = e.ShopOwnerEng,
                                ShopOwnerBng = e.ShopOwnerBng,

                                ShopMobile = e.ShopMobile,
                                ItemsProduct = e.ShopTypeItemProduct,


                                MarketName = e.Market.MarketNameBng + " " + e.Market.MarketNameEng,
                                ShopImagePath = e.ShopImagePath
                            };



                var parser = new Parser<ShopResult>(Request.Form, query);
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
        public IActionResult AddShop()
        {
            ViewBag.ActionType = "Create";
            ViewBag.Market = _marketRepository.GetAllForDropDown();


            ShopModel abc = new ShopModel();
            return View(abc);
        }


        [HttpGet]
        public IActionResult Report()
        {
            ViewBag.ActionType = "Report";
            ViewBag.Member = _memberRepository.GetAllForDropDown();
            ViewBag.Market = _marketRepository.GetAllForDropDown();
            return View();
        }



        [HttpGet]
        public async Task<IActionResult> VoterList(string MemberType, string YearRef)
        {
            string banglatype = "";
            if (MemberType == "Life Member")
            {
                banglatype = " (আজীবন)";
            }

            ViewBag.ActionType = "Report";
            HttpContext.Session.SetString("CaptionOne", "বিসমিল্লাহির রাহমানির রাহীম");
            HttpContext.Session.SetString("CaptionTwo", "তামাকুমন্ডি লেইন বণিক সমিতি সাধারণ সভা " + YearRef + " " + banglatype);

            List<MemberModel> memberlist = _memberRepository.All().Where(x => x.MemberType == MemberType).ToList();

            //var memberlist = await _memberRepository.All().Where(x => x.MemberType == MemberType);

            return View(memberlist);
        }

        [HttpGet]
        public async Task<IActionResult> SubLedgerList(string MemberType, string YearRef)
        {
            string banglatype = "";
            if (MemberType == "Life Member")
            {
                banglatype = " (আজীবন)";
            }

            ViewBag.ActionType = "Report";
            HttpContext.Session.SetString("CaptionOne", "বিসমিল্লাহির রাহমানির রাহীম");
            HttpContext.Session.SetString("CaptionTwo", "তামাকুমন্ডি লেইন বণিক সমিতি সাধারণ সভা " + YearRef + " " + banglatype);

            List<MemberModel> memberlist = _memberRepository.All().Where(x => x.MemberType == MemberType).Take(30).ToList();

            //var memberlist = await _memberRepository.All().Where(x => x.MemberType == MemberType);

            return View(memberlist);

        }



        [HttpPost, ActionName("ShowReport")]
        [AllowAnonymous]
        ////[Authorize(Roles = "Admin, SuperAdmin , Commercial-Admin ")]
        //[OverridableAuthorize]
        //[ValidateAntiForgeryToken]
        public JsonResult ShowReport(string reporttype, string action, string refno, string dtFrom, string dtTo, int? memberid, string membertype, string origin, string urllink, string fromno, string tono, string fromdate, string todate, int? marketid)
        {
            try
            {

                var reportname = "";
                var filename = "";
                var UserId = HttpContext.Session.GetInt32("UserId");
                var ComId = HttpContext.Session.GetInt32("ComId");

                var controllerName = this.ControllerContext.RouteData.Values["Controller"].ToString().ToLower();

                String St = urllink.ToLower();

                int pFrom = St.IndexOf("/") + "/".Length;
                int pTo = St.LastIndexOf("/" + controllerName);

                string result = "";
                if (pTo < 1)
                {
                    result = origin;

                }
                else
                {
                    result = St.Substring(pFrom, pTo - pFrom);
                    result = origin + "/" + result;

                }


                if (action == "PrintVoterList")
                {

                    reportname = "rptVoterList";
                    filename = "VoterList" + refno;// db.Acc_VoucherMains.Where(x => x.VoucherNo == VoucherFrom).Select(x => x.VoucherNo + "_" + x.Acc_VoucherType.VoucherTypeName).Single();
                    HttpContext.Session.SetString("ReportQuery", "Exec Association_rptVoterList '" + ComId.ToString() + "','" + refno + "' ,'" + membertype + "','" + result + "'   ");

                    var abcd = HttpContext.Session.GetString("ReportQuery");

                }
                else if (action == "PrintMarketWiseList")
                {

                    reportname = "rptMarketWiseVoterList";
                    filename = "rptMarketWiseVoterList" + refno;// db.Acc_VoucherMains.Where(x => x.VoucherNo == VoucherFrom).Select(x => x.VoucherNo + "_" + x.Acc_VoucherType.VoucherTypeName).Single();
                    HttpContext.Session.SetString("ReportQuery", "Exec Association_rptMarketWiseVoterList '" + ComId.ToString() + "','" + refno + "' ,'" + membertype + "','" + result + "','" + marketid + "'   ");

                    var abcd = HttpContext.Session.GetString("ReportQuery");

                }
                else if (action == "PrintSubLedger")
                {

                    reportname = "rptSubLedger";
                    filename = "rptSubLedger" + refno;// db.Acc_VoucherMains.Where(x => x.VoucherNo == VoucherFrom).Select(x => x.VoucherNo + "_" + x.Acc_VoucherType.VoucherTypeName).Single();
                    HttpContext.Session.SetString("ReportQuery", "Exec Association_rptVoterList '" + ComId.ToString() + "','" + refno + "' ,'" + membertype + "','" + result + "'   ");

                    var abcd = HttpContext.Session.GetString("ReportQuery");

                }
                else if (action == "TransactionLedger")
                {

                    reportname = "rptTransactionLedger";
                    filename = "rptTransactionLedger" + refno;// db.Acc_VoucherMains.Where(x => x.VoucherNo == VoucherFrom).Select(x => x.VoucherNo + "_" + x.Acc_VoucherType.VoucherTypeName).Single();
                    HttpContext.Session.SetString("ReportQuery", "Exec Association_LedgerList '" + ComId.ToString() + "','" + memberid + "' ,'" + memberid + "','" + result + "','" + fromdate + "','" + todate + "'   ");

                    var abcd = HttpContext.Session.GetString("ReportQuery");

                }


                else if (action == "ViewVoterList")
                {


                    string viewurl = this.Url.Action("VoterList", "Association", new { MemberType = membertype, YearRef = refno });
                    return Json(new { Url = viewurl });
                }
                else if (action == "ViewSubLedger")
                {
                    string viewurl = this.Url.Action("SubLedgerList", "Association", new { MemberType = membertype, YearRef = refno });
                    return Json(new { Url = viewurl });
                }

                HttpContext.Session.SetString("ReportPath", "~/ReportViewer/Association/" + reportname + ".rdlc");
                HttpContext.Session.SetString("PrintFileName", filename.Replace(".", "").Replace(" ", "").Replace(",", "").Replace("\"", ""));

                string redirectUrl = this.Url.Action("Index", "ReportViewer", new { reporttype = reporttype });
                return Json(new { Url = redirectUrl });
            }

            catch (Exception ex)
            {
                errorlog(ex);
                // If Sucess== 0 then Unable to perform Save/Update Operation and send Exception to View as JSON
                return Json(new { Success = 0, ex = ex.InnerException.InnerException.Message.ToString() });
            }

            //return Json(new { Success = 0, ex = new Exception("Unable to Show Report").Message.ToString() });

        }




        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult AddShop(ShopModel model, IFormFile logoPostedFileBase)
        {


            if (ModelState.IsValid)
            {
                if (model.Id == 0)
                {
                    _shopRepository.Insert(model);

                    TempData["Message"] = "Data Save Successfully";
                    TempData["Status"] = "1";
                    tranlog.TransactionLog(RouteData.Values["controller"].ToString(), RouteData.Values["action"].ToString(), TempData["Message"].ToString(), model.Id.ToString(), "Create", model.ShopNameEng + " " + model.ShopNameBng.ToString());

                }
                else
                {
                    _shopRepository.Update(model, model.Id);



                    TempData["Message"] = "Data Update Successfully";
                    TempData["Status"] = "2";
                    tranlog.TransactionLog(RouteData.Values["controller"].ToString(), RouteData.Values["action"].ToString(), TempData["Message"].ToString(), model.Id.ToString(), "Update", model.ShopNameEng + " " + model.ShopNameBng.ToString());

                }

                if (logoPostedFileBase != null && logoPostedFileBase.Length > 0)
                {
                    var path = Path.Combine(
                     Directory.GetCurrentDirectory(), "wwwroot/Content/ShopImages",
                     logoPostedFileBase.FileName);

                    using (var stream = new FileStream(path, FileMode.Create))
                    {
                        logoPostedFileBase.CopyTo(stream);
                    }
                    model.ShopImagePath = $"/Content/ShopImages/{logoPostedFileBase.FileName}";
                }
                else
                {
                    var Shops = _shopRepository.Find(model.Id);
                    if (Shops != null)
                        model.ShopImagePath = Shops.ShopImagePath;
                }
                _shopRepository.Update(model, model.Id);



                TempData["Message"] = "Data Update Successfully";
                TempData["Status"] = "2";
                tranlog.TransactionLog(RouteData.Values["controller"].ToString(), RouteData.Values["action"].ToString(), TempData["Message"].ToString(), model.Id.ToString(), "Update", model.ShopNameEng + " " + model.ShopNameBng.ToString());



                return RedirectToAction("ShopList");
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


        [HttpPost]
        public IActionResult SaveShopModal([FromBody] ShopModel model)
        {
            if (!ModelState.IsValid)
            {
                return Json("Model is not valid");

            }
            _shopRepository.Insert(model);

            TempData["Message"] = "Data Save Successfully";
            TempData["Status"] = "1";
            tranlog.TransactionLog(RouteData.Values["controller"].ToString(), RouteData.Values["action"].ToString(), TempData["Message"].ToString(), model.Id.ToString(), "Create", model.ShopNameEng + " " + model.ShopNameBng.ToString());

            return Json("Shop Added Successfully");
        }


        [HttpGet]
        public IActionResult EditShop(int ShopId)
        {
            ViewBag.ActionType = "Edit";
            var Shop = _shopRepository.Find(ShopId);
            ViewBag.Market = _marketRepository.GetAllForDropDown();

            return View("AddShop", Shop);
        }

        public ActionResult DeleteShop(int ShopId)
        {
            var model = _shopRepository.Find(ShopId);

            if (model != null)
            {
                _shopRepository.Delete(model);

                TempData["Message"] = "Data Delete Successfully";
                TempData["Status"] = "3";
                tranlog.TransactionLog(RouteData.Values["controller"].ToString(), RouteData.Values["action"].ToString(), TempData["Message"].ToString(), model.Id.ToString(), "Delete", model.ShopNameEng + " " + model.ShopNameBng);

                return RedirectToAction("ShopList");
            }
            return RedirectToAction("ShopList");
        }



        #endregion



        #region Market
        public IActionResult MarketList()
        {
            //var Markets = _marketRepository.All();
            //return View(Markets);
            return View();
        }

        public class MarketResult
        {
            public int Id { get; set; }
            public string? MarketCode { get; set; }
            public string? MarketNameEng { get; set; }
            public string? MarketNameBng { get; set; }
            public string? PrName { get; set; }
            public string? PrPhoneNo { get; set; }

            public string? SecName { get; set; }
            public string? SecPhoneNo { get; set; }

            public int? Floors { get; set; }
            public int? ActiveMembers { get; set; }
            public int? TotalShop { get; set; }

            public int? ClosedShop { get; set; }

            public string? PresidentImagePath { get; set; }
            public string? SecretaryImagePath { get; set; }

        }

        [AllowAnonymous]
        public JsonResult GetMarketList()
        {
            try
            {

                //var Markets= _context.Markets.ToList();


                var Markets = _marketRepository.All();//.Include(x=>x.vUnit).Include(x=>x.Market);
                var query = from e in Markets//.Where(x => x.Id > 0 && x.ComId == comid).OrderByDescending(x => x.Id)


                            select new MarketResult
                            {
                                Id = e.Id,
                                MarketCode = e.MarketCode,

                                MarketNameEng = e.MarketNameEng,
                                MarketNameBng = e.MarketNameBng,
                                PrName = e.PrName,
                                PrPhoneNo = e.PrPhoneNo,
                                SecName = e.SecName,
                                SecPhoneNo = e.SecPhoneNo,
                                Floors = e.Floors,
                                ActiveMembers = e.ActiveMember,
                                TotalShop = e.TotalShop,
                                ClosedShop = e.ClosedShop,
                                PresidentImagePath = e.PresidentImagePath,
                                SecretaryImagePath = e.SecretaryImagePath
                            };



                var parser = new Parser<MarketResult>(Request.Form, query);
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
        public IActionResult AddMarket()
        {
            ViewBag.ActionType = "Create";
            //ViewBag.Market = _marketRepository.GetAllForDropDown();



            MarketModel abc = new MarketModel();
            return View(abc);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult AddMarket(MarketModel model, IFormFile logoPostedFileBase)
        {


            if (ModelState.IsValid)
            {
                if (model.Id == 0)
                {
                    _marketRepository.Insert(model);


                    TempData["Message"] = "Data Save Successfully";
                    TempData["Status"] = "1";
                    tranlog.TransactionLog(RouteData.Values["controller"].ToString(), RouteData.Values["action"].ToString(), TempData["Message"].ToString(), model.Id.ToString(), "Create", model.MarketNameEng + " " + model.MarketNameEng);

                }
                else
                {
                    _marketRepository.Update(model, model.Id);



                    TempData["Message"] = "Data Update Successfully";
                    TempData["Status"] = "2";
                    tranlog.TransactionLog(RouteData.Values["controller"].ToString(), RouteData.Values["action"].ToString(), TempData["Message"].ToString(), model.Id.ToString(), "Update", model.MarketNameEng + " " + model.MarketNameEng);

                }

                if (logoPostedFileBase != null && logoPostedFileBase.Length > 0)
                {
                    var path = Path.Combine(
                     Directory.GetCurrentDirectory(), "wwwroot/Content/PresidentImages",
                     logoPostedFileBase.FileName);

                    using (var stream = new FileStream(path, FileMode.Create))
                    {
                        logoPostedFileBase.CopyTo(stream);
                    }
                    model.PresidentImagePath = $"/Content/PresidentImages/{logoPostedFileBase.FileName}";
                }
                else
                {
                    var Markets = _marketRepository.Find(model.Id);
                    if (Markets != null)
                        //Console.WriteLine("1");
                        model.PresidentImagePath = Markets.PresidentImagePath;
                }
                _marketRepository.Update(model, model.Id);



                TempData["Message"] = "Data Update Successfully";
                TempData["Status"] = "2";
                tranlog.TransactionLog(RouteData.Values["controller"].ToString(), RouteData.Values["action"].ToString(), TempData["Message"].ToString(), model.Id.ToString(), "Update", model.MarketNameEng + " " + model.MarketNameEng);





                if (logoPostedFileBase != null && logoPostedFileBase.Length > 0)
                {
                    var path = Path.Combine(
                     Directory.GetCurrentDirectory(), "wwwroot/Content/SecretaryImages",
                     logoPostedFileBase.FileName);

                    using (var stream = new FileStream(path, FileMode.Create))
                    {
                        logoPostedFileBase.CopyTo(stream);
                    }
                    model.SecretaryImagePath = $"/Content/SecretaryImages/{logoPostedFileBase.FileName}";
                }
                else
                {
                    var Markets = _marketRepository.Find(model.Id);
                    if (Markets != null)
                        //Console.WriteLine("1");
                        model.SecretaryImagePath = Markets.SecretaryImagePath;
                }
                _marketRepository.Update(model, model.Id);



                TempData["Message"] = "Data Update Successfully";
                TempData["Status"] = "2";
                tranlog.TransactionLog(RouteData.Values["controller"].ToString(), RouteData.Values["action"].ToString(), TempData["Message"].ToString(), model.Id.ToString(), "Update", model.MarketNameEng + " " + model.MarketNameEng);






                return RedirectToAction("MarketList");
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


        [HttpPost]
        public IActionResult SaveMarketModal([FromBody] MarketModel model)
        {
            if (!ModelState.IsValid)
            {
                return Json("Model is not valid");

            }
            _marketRepository.Insert(model);


            TempData["Message"] = "Data Save Successfully";
            TempData["Status"] = "1";
            tranlog.TransactionLog(RouteData.Values["controller"].ToString(), RouteData.Values["action"].ToString(), TempData["Message"].ToString(), model.Id.ToString(), "Create", model.MarketNameEng + " " + model.MarketNameBng);

            return Json("Market Added Successfully");
        }


        [HttpGet]
        public IActionResult EditMarket(int MarketId)
        {
            ViewBag.ActionType = "Edit";
            var Market = _marketRepository.Find(MarketId);
            //ViewBag.Market = _marketRepository.GetAllForDropDown();
            return View("AddMarket", Market);
        }

        public ActionResult DeleteMarket(int MarketId)
        {
            var model = _marketRepository.Find(MarketId);

            if (model != null)
            {
                _marketRepository.Delete(model);

                TempData["Message"] = "Data Delete Successfully";
                TempData["Status"] = "3";
                tranlog.TransactionLog(RouteData.Values["controller"].ToString(), RouteData.Values["action"].ToString(), TempData["Message"].ToString(), model.Id.ToString(), "Delete", model.MarketNameEng + " " + model.MarketNameBng);

                return RedirectToAction("MarketList");
            }
            return RedirectToAction("MarketList");
        }



        #endregion

    }
}