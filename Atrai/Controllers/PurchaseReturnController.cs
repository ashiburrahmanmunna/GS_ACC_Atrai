using Atrai.Core.Common;
using Atrai.Data.Interfaces;
using Atrai.Model.Core.Entity;
using Atrai.Services;
using DataTablesParser;
using Microsoft.AspNetCore.Authorization;
//using Atrai.Data.Reports;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Atrai.Controllers
{
    [Authorize]
    [OverridableAuthorize]
    public class PurchaseReturnController : Controller
    {
        public TransactionLogRepository tranlog { get; }

        private readonly ISupplierRepository supplierRepository;
        private readonly IUserAccountRepository UserAccountRepository;

        private readonly IPurchaseReturnRepository purchasereturnRepository;
        private readonly IPurchaseReturnItemsRepository purchasereturnItemRepository;

        private readonly IPurchaseReturnBatchItemsRepository _PurchaseReturnBatchItemRepository;
        private readonly IPurchaseBatchItemsRepository _purchaseBatchItemRepository;

        private readonly IPurchaseReturnPaymentRepository PurchaseReturnPaymentRepository;

        private readonly IPurchaseRepository purchaseRepository;
        private readonly IPurchaseItemsRepository purchaseItemsRepository;
        private readonly IPurchasePaymentRepository purchasePaymentRepository;


        private readonly IStoreSettingRepository storeSettingRepository;
        private readonly IConfiguration configuration;
        private readonly ICompanyRepository companyRepository;
        private readonly ICategoryRepository categoryRepository;
        private readonly IUnitRepository _unitRepository;

        private readonly IProductRepository productRepository;
        private readonly IWarehouseRepository warehouseRepository;
        private readonly IFromWarehousePermissionRepository FromWarehousePermissionRepository;
        private readonly IToWarehousePermissionRepository ToWarehousePermissionRepository;


        private readonly IAccountHeadRepository accountHeadRepository;
        private readonly IPaymentTypeRepository paymentTypeRepository;
        private readonly IAccountHeadPermissionRepository AccountHeadPermissionRepository;
        //private readonly IpaymentTypesRepository paymentTypesRepository;


        public static string ExpressionParameterizationException { get; }
        Dictionary<int, dynamic> postData = new Dictionary<int, dynamic>();


        public PurchaseReturnController(IUserAccountRepository UserAccountRepository, IPurchaseReturnRepository purchasereturnRepository,
            ISupplierRepository supplierRepository, IPurchaseRepository purchaseRepository,

            IPurchaseReturnItemsRepository purchasereturnItemRepository, IPurchaseReturnBatchItemsRepository purchasereturnBatchItemRepository, IPurchaseReturnPaymentRepository PurchaseReturnPaymentRepository,
            IPurchaseBatchItemsRepository purchaseBatchItemRepository,
             IPurchaseItemsRepository purchaseItemsRepository, IPurchasePaymentRepository purchasePaymentRepository,

            IStoreSettingRepository storeSettingRepository,
            ICategoryRepository categoryRepository, IUnitRepository unitRepository, IProductRepository productRepository,
            IWarehouseRepository warehouseRepository, IFromWarehousePermissionRepository FromWarehousePermissionRepository, IToWarehousePermissionRepository ToWarehousePermissionRepository, IAccountHeadRepository accountHeadRepository,
            IPaymentTypeRepository paymentTypeRepository, ICompanyRepository companyRepository,
            IConfiguration configuration, TransactionLogRepository tranlogRepository, IAccountHeadPermissionRepository accountHeadPermissionRepository)
        {
            this.configuration = configuration;

            this.supplierRepository = supplierRepository;
            this.UserAccountRepository = UserAccountRepository;
            this.purchasereturnRepository = purchasereturnRepository;
            this.purchasereturnItemRepository = purchasereturnItemRepository;
            this._PurchaseReturnBatchItemRepository = purchasereturnBatchItemRepository;
            this._purchaseBatchItemRepository = purchaseBatchItemRepository;

            this.PurchaseReturnPaymentRepository = PurchaseReturnPaymentRepository;


            this.purchaseRepository = purchaseRepository;
            this.purchaseItemsRepository = purchaseItemsRepository;
            this.purchasePaymentRepository = purchasePaymentRepository;


            this.storeSettingRepository = storeSettingRepository;
            this.companyRepository = companyRepository;
            this.categoryRepository = categoryRepository;
            _unitRepository = unitRepository;

            this.productRepository = productRepository;
            this.warehouseRepository = warehouseRepository;
            this.FromWarehousePermissionRepository = FromWarehousePermissionRepository;
            this.ToWarehousePermissionRepository = ToWarehousePermissionRepository;


            this.accountHeadRepository = accountHeadRepository;
            this.paymentTypeRepository = paymentTypeRepository;
            tranlog = tranlogRepository;
            AccountHeadPermissionRepository = accountHeadPermissionRepository;
        }

        public IActionResult Index()
        {
            ViewBag.FromDate = DateTime.Now.Date;
            ViewBag.ToDate = DateTime.Now.Date;

            ViewBag.Suppliers = supplierRepository.GetAllForDropDown();
            ViewBag.Users = UserAccountRepository.GetAllForDropDown();
            //int abcd = HttpContext.Session.GetInt32("ComId");
            //return View(purchasereturnRepository.All().Include(x=>x.SupplierModel).OrderByDescending(x=>x.Id));
            return View();
        }


        public IActionResult SerialProductHistory()
        {
            ViewBag.Products = productRepository.GetAllProductForDropDown();

            return View();
        }

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


        [HttpGet]
        [AllowAnonymous]
        public IActionResult AddPurchaseReturn()
        {

            ViewBag.ActionType = "Create";
            int purchasereturnId = 0;
            ViewBag.suppliers = supplierRepository.GetAllForDropDown();


            if (FromWarehousePermissionRepository.GetAllForDropDown().Count() > 0) { ViewBag.Warehouse = FromWarehousePermissionRepository.GetAllForDropDown(); } else { ViewBag.Warehouse = warehouseRepository.GetWarehouseLedgerHeadForDropDown(); }


            ViewBag.Category = categoryRepository.GetAllForDropDown();
            ViewBag.Unit = _unitRepository.GetAllForDropDown();

            return View(model: purchasereturnId);
        }
        [HttpGet]
        [AllowAnonymous]
        public IActionResult AddPurchaseReturnSerial()
        {

            ViewBag.ActionType = "Create";
            int purchasereturnId = 0;
            //ViewBag.suppliers = supplierRepository.GetAllForDropDown();


            if (FromWarehousePermissionRepository.GetAllForDropDown().Count() > 0) { ViewBag.Warehouse = FromWarehousePermissionRepository.GetAllForDropDown(); } else { ViewBag.Warehouse = warehouseRepository.GetWarehouseLedgerHeadForDropDown(); }


            ViewBag.Category = categoryRepository.GetAllForDropDown();
            ViewBag.Unit = _unitRepository.GetAllForDropDown();

            return View(model: purchasereturnId);
        }

        [HttpGet]
        [AllowAnonymous]
        public IActionResult AddPurchaseReturnBySerialSearch()
        {

            ViewBag.ActionType = "Create";
            int purchasereturnId = 0;
            //ViewBag.suppliers = supplierRepository.GetAllForDropDown();
            if (FromWarehousePermissionRepository.GetAllForDropDown().Count() > 0)
            { ViewBag.Warehouse = FromWarehousePermissionRepository.GetAllForDropDown(); }
            else { ViewBag.Warehouse = warehouseRepository.GetWarehouseLedgerHeadForDropDown(); }
            ViewBag.Category = categoryRepository.GetAllForDropDown();
            ViewBag.Unit = _unitRepository.GetAllForDropDown();

            return View(model: purchasereturnId);
        }

        [HttpGet]
        [AllowAnonymous]
        public IActionResult AddPurchaseReturnSerialSide()
        {

            ViewBag.ActionType = "Create";
            int purchasereturnId = 0;
            //ViewBag.suppliers = supplierRepository.GetAllForDropDown();
            if (FromWarehousePermissionRepository.GetAllForDropDown().Count() > 0) { ViewBag.Warehouse = FromWarehousePermissionRepository.GetAllForDropDown(); } else { ViewBag.Warehouse = warehouseRepository.GetWarehouseLedgerHeadForDropDown(); }
            ViewBag.Category = categoryRepository.GetAllForDropDown();
            ViewBag.Unit = _unitRepository.GetAllForDropDown();

            return View(model: purchasereturnId);
        }


        public class PurchaseReturnResultList : PurchaseReturnModel
        {
            public string? StatusPosted { get; set; }
            public string? PurchaseReturnDateString { get; set; }
            public string? ReceivingHead { get; set; }
            public string? PurchaseReturnUser { get; set; }

        }


        //[HttpPost]
        [AllowAnonymous]
        public JsonResult GetPurchaseReturnSummaryInfo(string FromDate, string ToDate, int? SupplierId, int? UserId)
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


                //var purchaseinfo = purchaseRepository.All().Where(p => p.purchasereturnDate >= dtFrom && p.purchasereturnDate <= dtTo).SingleOrDefault();


                var purchasereturnlist = purchasereturnRepository.All().Where(x => x.PurchaseReturnDate >= dtFrom && x.PurchaseReturnDate <= dtTo);
                var purchasereturnpaymentlist = PurchaseReturnPaymentRepository.All().Include(x => x.PurchaseReturnMain).ThenInclude(x => x.SupplierModel).Where(x => x.PurchaseReturnMain.PurchaseReturnDate >= dtFrom && x.PurchaseReturnMain.PurchaseReturnDate <= dtTo && x.PurchaseReturnMain.IsDelete == false);
                var purchasereturnitemlist = purchasereturnItemRepository.All().Where(x => x.PurchaseReturnModel.PurchaseReturnDate >= dtFrom && x.PurchaseReturnModel.PurchaseReturnDate <= dtTo && x.PurchaseReturnModel.IsDelete == false);

                if (SupplierId != null)
                {
                    purchasereturnlist = purchasereturnlist.Where(p => p.SupplierId == SupplierId);
                    purchasereturnpaymentlist = purchasereturnpaymentlist.Where(p => p.PurchaseReturnMain.SupplierId == SupplierId);
                    purchasereturnitemlist = purchasereturnitemlist.Where(p => p.PurchaseReturnModel.SupplierId == SupplierId);

                }

                if (UserId != null)
                {
                    purchasereturnlist = purchasereturnlist.Where(p => p.LuserId == UserId);
                    purchasereturnpaymentlist = purchasereturnpaymentlist.Where(p => p.PurchaseReturnMain.LuserId == UserId);
                    purchasereturnitemlist = purchasereturnitemlist.Where(p => p.PurchaseReturnModel.LuserId == UserId);
                }



                var totalpurchasereturnsummary = purchasereturnlist //.GroupBy(p => p.vPaymentType.TypeName);
                .GroupBy(x => new { x.ComId })
                .Select(g => new { TotalpurchasereturnCount = g.Count(), TotalpurchasereturnValue = g.Sum(x => x.NetAmount), TotalCosting = g.Sum(x => x.FinalCostingPrice), TotalProfit = g.Sum(x => x.Profit) });



                var purchasereturnbyuser = purchasereturnlist //.GroupBy(p => p.vPaymentType.TypeName);
                .GroupBy(x => new { x.UserAccountList.Name })
                .Select(g => new { UserName = g.Key.Name, TotalpurchasereturnCount = g.Count(), TotalpurchasereturnSum = g.Sum(x => x.NetAmount) }).ToList();


                var commissionbyuser = purchasereturnlist //.GroupBy(p => p.vPaymentType.TypeName);
                .GroupBy(x => new { x.UserAccountList.Name })
                .Select(g => new { UserName = g.Key.Name, TotalpurchasereturnCount = g.Count(), TotalCommissionAmount = g.Sum(x => x.TotalCommisionAmount) }).ToList();


                var purchasereturnreceivebyhead = purchasereturnpaymentlist.GroupBy(x => new { x.vChartofAccounts.AccName })
                .Select(g => new { AccName = g.Key.AccName, Amount = g.Sum(x => x.Amount) }).ToList();


                var totalreceivedamount = purchasereturnpaymentlist.Sum(x => x.Amount);
                var totalpurchasereturn = purchasereturnlist.Sum(x => x.GrandTotal);
                purchasereturnreceivebyhead.Add(new
                {
                    AccName = "Due",
                    Amount = (totalpurchasereturn - totalreceivedamount)
                });




                var toppurchasingitem = purchasereturnitemlist //.GroupBy(p => p.vPaymentType.TypeName);
                 .GroupBy(x => new { x.Product.Name })
                 .Select(g => new { ProductName = g.Key.Name, ProductCount = g.Count() }).ToList().OrderByDescending(x => x.ProductCount).Take(5);



                var toppurchasingsupplier = purchasereturnlist.Include(x => x.SupplierModel)//.GroupBy(p => p.vPaymentType.TypeName);
                 .GroupBy(x => new { walkinsupplier = x.SupplierName, SupplierName = x.SupplierModel.SupplierName })
                 .Select(g => new { SupplierName = g.Key.SupplierName.ToLower().Contains("supplier") ? g.Key.walkinsupplier : g.Key.SupplierName, purchasereturnAmount = g.Sum(x => x.GrandTotal) }).ToList().OrderByDescending(x => x.purchasereturnAmount).Take(5);


                //var topduesupplier = purchaseRepository.All().Include(x => x.SupplierModel).Include(x => x.purchasereturnPayments).Where(x => x.purchasereturnDate >= dtFrom && x.purchasereturnDate <= dtTo)
                ////.Select(x => new { walkintsupplier = x.SupplierName, suppliername = x.SupplierModel.SupplierName , DueAmount = x.GrandTotal - x.purchasereturnPayments.Sum(x=>x.Amount) })  //.GroupBy(p => p.vPaymentType.TypeName);
                //.GroupBy(x => new { walkintsupplier =  x.SupplierName, SupplierName = x.SupplierModel.SupplierName })
                //.Select(g => new { SupplierName = g.Key.SupplierName + " " + g.Key.walkintsupplier, DueAmount = g.Sum(x => x.GrandTotal - x.purchasereturnPayments.Sum(x => x.Amount)) })
                //.ToList();//.OrderByDescending(x => x.DueAmount).Take(5);


                var topduesupplier = purchasereturnpaymentlist
                .GroupBy(x => new { walkinsupplier = x.PurchaseReturnMain.SupplierName, SupplierName = x.PurchaseReturnMain.SupplierModel.SupplierName, GradnTotal = x.PurchaseReturnMain.GrandTotal })
                .Select(g => new { SupplierName = g.Key.SupplierName.ToLower().Contains("supplier") ? g.Key.walkinsupplier : g.Key.SupplierName, Totalpurchasereturn = g.Key.GradnTotal, ReceivedAmount = g.Sum(x => x.Amount) })
                .Where(x => (x.Totalpurchasereturn - x.ReceivedAmount > 0))
                .ToList().OrderByDescending(x => x.Totalpurchasereturn - x.ReceivedAmount)
                .Take(5).ToList();

                var topduesuppliermore = purchasereturnlist.Include(x => x.PurchaseReturnPayments).Include(x => x.SupplierModel).Where(x => x.PurchaseReturnPayments.Count() == 0)
               .GroupBy(x => new { walkinsupplier = x.SupplierName, SupplierName = x.SupplierModel.SupplierName, GradnTotal = x.GrandTotal })
               .Select(g => new { SupplierName = g.Key.SupplierName.ToLower().Contains("supplier") ? g.Key.walkinsupplier : g.Key.SupplierName, Totalpurchasereturn = g.Sum(x => g.Key.GradnTotal), ReceivedAmount = decimal.Parse("0") })
               .Where(x => (x.Totalpurchasereturn - x.ReceivedAmount > 0))
               .ToList().OrderByDescending(x => x.Totalpurchasereturn - x.ReceivedAmount)
               .Take(5).ToList();

                foreach (var item in topduesuppliermore)
                {
                    topduesupplier.Add(item);
                }


                var postunpostcount = purchasereturnlist //.GroupBy(p => p.vPaymentType.TypeName);
                .GroupBy(x => new { isPosted = x.isPosted })
                .Select(g => new { isPosted = g.Key.isPosted, DocCount = g.Count() }).ToList();



                //var toppurchasingproduct = (from product in productRepository.All()
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
                //                     join o in purchaseRepository.All().ToList() on op.purchasereturnId equals o.Id
                //                     where op.ProductId == p.Id && o.purchasereturnDate >= dtFrom && o.purchasereturnDate <= dtTo
                //                     select op.Quantity).Sum()
                //where totalQuantity > 0
                //orderby totalQuantity descending
                //select p).Take(10);


                //return Json(totalpurchasereturnsummary);

                var genericResult = new
                {
                    totalpurchasereturnsummary = totalpurchasereturnsummary,
                    purchasereturnbyuser = purchasereturnbyuser,
                    purchasereturnreceivebyhead = purchasereturnreceivebyhead,
                    commissionbyuser = commissionbyuser,
                    toppurchasingitem = toppurchasingitem,
                    toppurchasingsupplier = toppurchasingsupplier,
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
        public IActionResult GetPurchaseReturnList(string FromDate, string ToDate, int? SupplierId, int? UserId, string Status, int isAll)
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

                var PurchaseReturnlist = purchasereturnRepository.All();




                if (y.ToString().Length > 0)
                {


                }
                else
                {
                    PurchaseReturnlist = PurchaseReturnlist.Where(p => (p.PurchaseReturnDate >= dtFrom && p.PurchaseReturnDate <= dtTo));

                    if (SupplierId != null)
                    {
                        PurchaseReturnlist = PurchaseReturnlist.Where(p => p.SupplierId == SupplierId);
                    }
                    if (UserId != null)
                    {
                        PurchaseReturnlist = PurchaseReturnlist.Where(p => p.LuserId == UserId);
                    }
                    if (Status == "Due")
                    {
                        //var PurchaseReturnlistmore = PurchaseReturnlist.Where(x => x.GrandTotal -  x.PurchaseReturnPayments.Sum(x=>x.Amount) > 0);

                        PurchaseReturnlist = PurchaseReturnlist.Where(x => x.GrandTotal - x.PurchaseReturnPayments.Sum(x => x.Amount) > 0);

                        //PurchaseReturnlist = PurchaseReturnlist.Where(x=>x.PurchaseReturnPayments.Count == 0);


                    }
                    //else
                    //{
                    //    //PurchaseReturnlist = PurchaseReturnlist.Where(p => p.PurchaseReturnDate >= dtFrom && p.PurchaseReturnDate <= dtTo);

                    //    //if (SupplierId == 1)
                    //    //{
                    //    //    PurchaseReturnlist = PurchaseReturnlist.Where(p => p.PurchaseReturnDate >= dtFrom && p.PurchaseReturnDate <= dtTo);
                    //    //}
                    //    //else
                    //    //{
                    //    //}
                    //}

                }



                var query = from e in PurchaseReturnlist.Include(x => x.Items).Include(x => x.PurchaseReturnPayments).ThenInclude(x => x.vChartofAccounts)
                            select new PurchaseReturnResultList
                            {
                                Id = e.Id,
                                PurchaseReturnCode = e.PurchaseReturnCode,
                                PurchaseReturnDate = e.PurchaseReturnDate,
                                PurchaseReturnDateString = e.PurchaseReturnDate.ToString("dd-MMM-yy"),

                                PurchaseReturnUser = e.UserAccountList.Name,

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
                                isPOSPurchaseReturn = e.isPOSPurchaseReturn,
                                isSerialPurchaseReturn = e.isSerialPurchaseReturn,
                                isPosted = e.isPosted,
                                FinalCostingPrice = e.FinalCostingPrice,
                                Profit = e.Profit,
                                ProfitPercentage = e.ProfitPercentage,

                                StatusPosted = e.isPosted != false ? "Posted" : "Not Posted",
                                PaidAmt = e.PurchaseReturnPayments.Sum(x => x.Amount),// e.PaidAmt,
                                //ReceivingHead = e.CreditAccount != null ? e.CreditAccount.AccName : "=N/A="
                                PurchaseReturnPayments = e.PurchaseReturnPayments.ToList()


                            };


                var parser = new Parser<PurchaseReturnResultList>(Request.Form, query);

                return Json(parser.Parse());


            }
            catch (Exception ex)
            {
                return Json(new { Success = "0", error = ex.Message });
                //throw ex;
            }

        }




        [HttpPost]
        [AllowAnonymous]
        public IActionResult AddPurchaseReturn([FromBody] PurchaseReturnModel model)
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

                        //SqlParameter[] sqlParameter = new SqlParameter[4];
                        //sqlParameter[0] = new SqlParameter("@ComId", ComId);
                        //sqlParameter[1] = new SqlParameter("@Id", model.Id);
                        //sqlParameter[2] = new SqlParameter("@ProcessFor", "PurchaseReturn");
                        //sqlParameter[3] = new SqlParameter("@SaveUpdateDelete", "Update");
                        //Helper.ExecProc("prcSerialProcess", sqlParameter);


                        purchasereturnRepository.Update(model, model.Id);




                        foreach (PurchaseReturnItemsModel item in model.Items)
                        {

                            if (item.Id > 0)
                            {
                                if (item.IsDelete == true)
                                {
                                    int z = item.Id;
                                    purchasereturnItemRepository.Delete(item);

                                }
                                else
                                {
                                    if (item.IsTransaction == true)//item.IsDelete == false &&  
                                    {

                                        if (item.SerialItem != null)
                                        {

                                            var batchitemlist = _PurchaseReturnBatchItemRepository.All().Where(x => x.PurchaseReturnItemId == item.Id).ToList();
                                            _PurchaseReturnBatchItemRepository.RemoveRange(batchitemlist);

                                        }


                                        foreach (PurchaseReturnBatchItemsModel batchitem in item.BatchSerialItems)
                                        {
                                            if (batchitem.Id > 0)
                                            {
                                                if (batchitem.IsDelete == true)
                                                {
                                                    int z = batchitem.Id;
                                                    _PurchaseReturnBatchItemRepository.Delete(batchitem);

                                                }
                                                else
                                                {
                                                    if (batchitem.IsTransaction == true)
                                                    {
                                                        batchitem.ComId = ComId.GetValueOrDefault();
                                                        _PurchaseReturnBatchItemRepository.Update(batchitem, batchitem.Id);
                                                    }
                                                }
                                            }
                                            else if (batchitem.Id == 0 && batchitem.IsDelete == false)
                                            {
                                                batchitem.ComId = ComId.GetValueOrDefault();
                                                _PurchaseReturnBatchItemRepository.Insert(batchitem);
                                            }


                                        }

                                        purchasereturnItemRepository.Update(item, item.Id);

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

                                    purchasereturnItemRepository.Insert(item);

                                    //foreach (PurchaseReturnBatchItemsModel batchitem in item.BatchSerialItems)
                                    //{
                                    //    if (batchitem.IsDelete == true)
                                    //    {

                                    //    }
                                    //    else
                                    //    {
                                    //        purchasereturnItemRepository.Insert(item);

                                    //    }


                                    //}

                                }
                            }
                        }



                        var PurchaseReturnpaymentsdata = PurchaseReturnPaymentRepository.All().Where(x => x.PurchaseReturnId == model.Id && x.TransactionId == null).ToList();
                        PurchaseReturnPaymentRepository.RemoveRange(PurchaseReturnpaymentsdata);


                        foreach (PurchaseReturnPaymentModel item in model.PurchaseReturnPayments.Where(x => x.IsDelete == false))
                        {

                            PurchaseReturnPaymentRepository.Insert(item);


                            //if (item.Id > 0)
                            //{
                            //    if (item.IsDelete == true)
                            //    {
                            //        int z = item.Id;
                            //        PurchaseReturnPaymentRepository.Delete(item);

                            //    }
                            //    else
                            //    {
                            //        PurchaseReturnPaymentRepository.Update(item, item.Id);

                            //    }
                            //}
                            //else
                            //{
                            //    if (item.IsDelete == true)
                            //    {
                            //    }
                            //    else
                            //    {

                            //        PurchaseReturnPaymentRepository.Insert(item);

                            //    }
                            //}
                        }



                        TempData["Message"] = "Data Update Successfully";
                        TempData["Status"] = "2";
                        tranlog.TransactionLog(RouteData.Values["controller"].ToString(), RouteData.Values["action"].ToString(), TempData["Message"].ToString(), model.Id.ToString(), "Update", model.PurchaseReturnCode);



                        SqlParameter[] sqlParameter1 = new SqlParameter[4];
                        sqlParameter1[0] = new SqlParameter("@ComId", ComId);
                        sqlParameter1[1] = new SqlParameter("@Id", model.Id);
                        sqlParameter1[2] = new SqlParameter("@ProcessFor", "PurchaseReturn");
                        sqlParameter1[3] = new SqlParameter("@SaveUpdateDelete", "Save");
                        Helper.ExecProc("prcSerialProcess", sqlParameter1);

                        return Json(new { Success = 1, error = false, message = "Date Update successfully" });
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
                            //        PurchaseReturnBatchItemsModel abc = new PurchaseReturnBatchItemsModel();
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




                        purchasereturnRepository.Insert(model);


                        TempData["Message"] = "Data Save Successfully";
                        TempData["Status"] = "1";
                        tranlog.TransactionLog(RouteData.Values["controller"].ToString(), RouteData.Values["action"].ToString(), TempData["Message"].ToString(), model.Id.ToString(), "Create", model.PurchaseReturnCode);

                        //SqlParameter[] sqlParameter1 = new SqlParameter[4];
                        //sqlParameter1[0] = new SqlParameter("@ComId", ComId);
                        //sqlParameter1[1] = new SqlParameter("@Id", model.Id);
                        //sqlParameter1[2] = new SqlParameter("@ProcessFor", "PurchaseReturn");
                        //sqlParameter1[3] = new SqlParameter("@SaveUpdateDelete", "Save");
                        //Helper.ExecProc("prcSerialProcess", sqlParameter1);

                        return Json(new { Success = 1, error = false, message = "Data Save successfully" });
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


        [HttpPost]
        public JsonResult POSCreate(PurchaseReturnModel model)
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

                        var items = purchasereturnItemRepository.AllSubData().Where(x => x.PurchaseReturnId == model.Id).ToList();
                        if (items.Any())
                        {
                            foreach (var item in items)
                            {
                                purchasereturnItemRepository.Delete(item);
                            }
                        }

                        var PurchaseReturnpayment = PurchaseReturnPaymentRepository.AllSubData().Where(x => x.PurchaseReturnId == model.Id).ToList();
                        if (PurchaseReturnpayment.Any())
                        {
                            foreach (var item in PurchaseReturnpayment)
                            {
                                PurchaseReturnPaymentRepository.Delete(item);
                            }
                        }

                        var purchasereturn = purchasereturnRepository.Find(model.Id);

                        purchasereturn.SupplierName = model.SupplierName;
                        purchasereturn.PrimaryAddress = model.PrimaryAddress;
                        purchasereturn.PhoneNo = model.PhoneNo;


                        purchasereturn.Notes = model.Notes;
                        //purchasereturn.PaymentMethod = model.PaymentMethod;
                        purchasereturn.PurchaseReturnCode = model.PurchaseReturnCode;
                        purchasereturn.SupplierId = model.SupplierId;
                        purchasereturn.Total = model.Total;
                        purchasereturn.PurchaseReturnDate = model.PurchaseReturnDate;
                        purchasereturn.Status = model.Status;
                        purchasereturn.Discount = model.Discount;


                        purchasereturn.ServiceCharge = model.ServiceCharge;
                        purchasereturn.Shipping = model.Shipping;
                        purchasereturn.TotalVat = model.TotalVat;

                        purchasereturn.GrandTotal = model.GrandTotal;
                        purchasereturn.DisPer = model.DisPer;
                        purchasereturn.DisAmt = model.DisAmt;
                        purchasereturn.DueAmt = model.DueAmt;



                        //purchasereturn.ttlCountQty = model.ttlCountQty;
                        //purchasereturn.ttlIndDisAmt = model.ttlIndDisAmt;
                        //purchasereturn.ttlIndPrice = model.ttlIndPrice;

                        //purchasereturn.ttlIndVat = model.ttlIndVat;
                        //purchasereturn.ttlSumAmt = model.ttlSumAmt;
                        //purchasereturn.ttlSumQty = model.ttlSumQty;
                        //purchasereturn.ttlUnitPrice = model.ttlUnitPrice;
                        purchasereturn.LuserIdUpdate = int.Parse(UserId.ToString());



                        //add again
                        foreach (var item in model.Items)
                        {
                            purchasereturn.Items.Add(new PurchaseReturnItemsModel
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

                        foreach (var item in model.PurchaseReturnPayments)
                        {
                            purchasereturn.PurchaseReturnPayments.Add(new PurchaseReturnPaymentModel
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


                        purchasereturnRepository.Update(purchasereturn, model.Id);



                        TempData["Message"] = "Data Update Successfully";
                        TempData["Status"] = "2";
                        tranlog.TransactionLog(RouteData.Values["controller"].ToString(), RouteData.Values["action"].ToString(), TempData["Message"].ToString(), model.Id.ToString(), "Update", model.PurchaseReturnCode.ToString());

                        return Json(new { Success = 1, Id = model.Id, error = false, message = "PurchaseReturn updated successfully" });
                    }
                    else
                    {
                        model.isPOSPurchaseReturn = true;
                        var UserId = HttpContext.Session.GetInt32("UserId");
                        var ComId = HttpContext.Session.GetInt32("ComId");

                        foreach (var item in model.Items)
                        {

                            item.CreateDate = DateTime.Now;
                            item.UpdateDate = DateTime.Now;
                            item.ComId = int.Parse(ComId.ToString());
                        }

                        foreach (var item in model.PurchaseReturnPayments)
                        {

                            item.CreateDate = DateTime.Now;
                            item.UpdateDate = DateTime.Now;
                            item.ComId = int.Parse(ComId.ToString());
                        }

                        purchasereturnRepository.Insert(model);


                        TempData["Message"] = "Data Save Successfully";
                        TempData["Status"] = "1";
                        tranlog.TransactionLog(RouteData.Values["controller"].ToString(), RouteData.Values["action"].ToString(), TempData["Message"].ToString(), model.Id.ToString(), "Create", model.PurchaseReturnCode);


                        return Json(new { Success = 1, Id = model.Id, error = false, message = "PurchaseReturn saved successfully" });
                    }

                }
                return Json(new { Success = 0, error = true, message = "failed to save PurchaseReturn" });

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return Json(new { Success = 0, error = true, message = "failed to save/update PurchaseReturn" });
            }





            //try
            //{
            //    var errors = ModelState.Where(x => x.Value.Errors.Any())
            //    .Select(x => new { x.Key, x.Value.Errors });

            //    if (ModelState.IsValid)
            //    {

            //        // If PurchaseReturn main has PurchaseReturnID then we can understand we have existing PurchaseReturn Information
            //        // So we need to Perform Update Operation

            //        // Perform Update
            //        if (PurchaseReturnmain.Id > 0)
            //        {

            //            IQueryable<PurchaseReturnSub> CurrentPurchaseReturnSUb = db.PurchaseReturnSubs.Where(p => p.PurchaseReturnId == PurchaseReturnmain.PurchaseReturnId);
            //            IQueryable<PurchaseReturnTermsSub> CurrentPurchaseReturnTermsSUb = db.PurchaseReturnTermsSubs.Where(p => p.PurchaseReturnId == PurchaseReturnmain.PurchaseReturnId);
            //            IQueryable<PurchaseReturnPaymentSub> CurrentPurchaseReturnPaymentSUb = db.PurchaseReturnPaymentSubs.Where(p => p.PurchaseReturnId == PurchaseReturnmain.PurchaseReturnId);


            //            foreach (PurchaseReturnSub ss in CurrentPurchaseReturnSUb)
            //            {
            //                db.PurchaseReturnSubs.Remove(ss);


            //                ///inventory calculation after remove the data
            //                Inventory inv = db.Inventory.Where(x => x.ProductId == ss.ProductId && x.WareHouseId == ss.WarehouseId).FirstOrDefault();
            //                if (inv != null)
            //                {
            //                    inv.PurchaseReturnQty = inv.PurchaseReturnQty - ss.Qty;
            //                    db.Entry(inv).State = EntityState.Modified;
            //                }
            //            }

            //            foreach (PurchaseReturnTermsSub sss in CurrentPurchaseReturnTermsSUb)
            //            {
            //                db.PurchaseReturnTermsSubs.Remove(sss);
            //            }

            //            foreach (PurchaseReturnPaymentSub ssss in CurrentPurchaseReturnPaymentSUb)
            //            {
            //                db.PurchaseReturnPaymentSubs.Remove(ssss);
            //            }

            //            foreach (PurchaseReturnSub ss in PurchaseReturnmain.PurchaseReturnSubs)
            //            {
            //                db.PurchaseReturnSubs.Add(ss);

            //                ///inventory calculation after add the data
            //                Inventory inv = db.Inventory.Where(x => x.ProductId == ss.ProductId && x.WareHouseId == ss.WarehouseId).FirstOrDefault();
            //                if (inv != null)
            //                {
            //                    inv.PurchaseReturnQty = inv.PurchaseReturnQty + ss.Qty;
            //                    //inv.CurrentStock = (inv.OpStock + inv.PurQty + inv.PurExcQty + inv.PurchaseReturnRetQty) - (inv.PurchaseReturnQty + inv.PurchaseReturnExcQty + inv.PurRetQty);
            //                    inv.CurrentStock = (inv.OpStock + inv.PurQty + inv.PurExcQty + inv.PurchaseReturnRetQty + inv.GoodsReceiveQty + inv.IssueRtnQty) - (inv.PurchaseReturnQty + inv.PurchaseReturnExcQty + inv.PurRetQty + inv.IssueQty + inv.GoodsRcvRtnQty);

            //                    db.Entry(inv).State = EntityState.Modified;
            //                }
            //            }
            //            ///terms subs
            //            if (PurchaseReturnmain.PurchaseReturnTermsSubs == null)
            //            { }
            //            else
            //            {

            //                foreach (PurchaseReturnTermsSub sss in PurchaseReturnmain.PurchaseReturnTermsSubs)
            //                {
            //                    db.PurchaseReturnTermsSubs.Add(sss);
            //                }
            //            }
            //            ///payments
            //            if (PurchaseReturnmain.PurchaseReturnPaymentSubs == null)
            //            { }
            //            else
            //            {

            //                foreach (PurchaseReturnPaymentSub ssss in PurchaseReturnmain.PurchaseReturnPaymentSubs)
            //                {
            //                    db.PurchaseReturnPaymentSubs.Add(ssss);
            //                }
            //            }


            //            db.Entry(PurchaseReturnmain).State = EntityState.Modified;
            //        }
            //        //Perform Save
            //        else
            //        {
            //            db.PurchaseReturnMains.Add(PurchaseReturnmain);


            //            ///inventory calculation after Added New data in Save mode
            //            foreach (PurchaseReturnSub ss in PurchaseReturnmain.PurchaseReturnSubs)
            //            {
            //                db.PurchaseReturnSubs.Add(ss);
            //                ////if no warehouse found then it will throw error
            //                //Inventory inv = db.Inventory.Where(x => x.ProductId == ss.ProductId && x.WareHouseId == ss.WarehouseId).FirstOrDefault();
            //                //if (inv != null) ///added by fahad for solving error if no ware house found then no update of the data
            //                //{
            //                //    inv.PurchaseReturnQty = inv.PurchaseReturnQty + ss.Qty;
            //                //    //inv.CurrentStock = (inv.OpStock + inv.PurQty + inv.PurExcQty + inv.PurchaseReturnRetQty) - (inv.PurchaseReturnQty + inv.PurchaseReturnExcQty + inv.PurRetQty);
            //                //    //inv.CurrentStock = (inv.OpStock + inv.PurQty + inv.PurExcQty + inv.PurchaseReturnRetQty + inv.GoodsReceiveQty + inv.IssueRtnQty) - (inv.PurchaseReturnQty + inv.PurchaseReturnExcQty + inv.PurRetQty + inv.IssueQty + inv.GoodsRcvRtnQty);

            //                //    db.Entry(inv).State = EntityState.Modified;
            //                //}

            //            }

            //        }

            //        db.SaveChanges();

            //        // If Sucess== 1 then Save/Update Successfull else there it has Exception
            //        return Json(new { Success = 1, PurchaseReturnID = PurchaseReturnmain.PurchaseReturnId, ex = "" });
            //    }
            //}
            //catch (Exception ex)
            //{

            //    // If Sucess== 0 then Unable to perform Save/Update Operation and send Exception to View as JSON
            //    return Json(new { Success = 0, ex = ex.Message.ToString() });
            //}

            //return Json(new { Success = 0, ex = new Exception("Unable to save").Message.ToString() });
        }

        public async Task<IActionResult> POSEdit(int? PurchaseReturnId)
        {
            if (PurchaseReturnId == null)
            {
                return NotFound();
            }

            PurchaseReturnModel PurchaseReturnmain = await purchasereturnRepository.All()
            .Include(x => x.Items).ThenInclude(x => x.Product)
            //.Include(x => x.PurchaseReturnPayments).ThenInclude(x => x.vPaymentType)
            .Include(x => x.PurchaseReturnPayments).ThenInclude(x => x.vChartofAccounts)
            .Include(x => x.Items).ThenInclude(x => x.vWarehouse)
            .Where(x => x.Id == PurchaseReturnId).FirstOrDefaultAsync();

            if (PurchaseReturnmain.IsDelete == true)
            {
                return NotFound();
            }
            var comid = HttpContext.Session.GetString("ComId");
            var userid = HttpContext.Session.GetString("UserId");

            object a = HttpContext.Session.GetString("isProductSearch");
            ViewBag.ActionType = "Edit";

            ViewBag.Supplier = supplierRepository.GetAllForDropDown();
            ViewBag.Category = categoryRepository.GetAllForDropDown();
            var Productresult = productRepository.All().Take(30);

            ViewBag.Product = new SelectList(Productresult.Where(x => x.Id > 0).Select(s => new { Text = s.Code.Length < 4 ? s.Name : s.Name + " - [ " + s.Code + " ]", Value = s.Id }).ToList(), "Value", "Text");
            ViewBag.ProductSearch = Productresult;
            if (FromWarehousePermissionRepository.GetAllForDropDown().Count() > 0) { ViewBag.Warehouse = FromWarehousePermissionRepository.GetAllForDropDown(); } else { ViewBag.Warehouse = warehouseRepository.GetWarehouseLedgerHeadForDropDown(); }

            ViewBag.PaymentTypes = paymentTypeRepository.GetAllForDropDown();
            ViewBag.AccountHead = accountHeadRepository.GetCashBankHeadForDropDown();
            if (PurchaseReturnmain == null)
            {
                return NotFound();
            }

            //Call Create View
            return View("POSCreate", PurchaseReturnmain);
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

            PurchaseReturnModel PurchaseReturnmain = await purchasereturnRepository.All()
            .Include(x => x.Items).ThenInclude(x => x.Product)
            //.Include(x => x.PurchaseReturnPayments).ThenInclude(x => x.vPaymentType)
            .Include(x => x.PurchaseReturnPayments).ThenInclude(x => x.vChartofAccounts)
            .Include(x => x.Items).ThenInclude(x => x.vWarehouse)
            .Where(x => x.Id == id).FirstOrDefaultAsync();

            if (PurchaseReturnmain == null)
            {
                return NotFound();
            }
            var comid = HttpContext.Session.GetString("ComId");
            var userid = HttpContext.Session.GetString("userid");

            //object a = HttpContext.Session.GetString("isProductSearch");
            ViewBag.ActionType = "Delete";

            ViewBag.Supplier = supplierRepository.GetAllForDropDown();
            ViewBag.Category = categoryRepository.GetAllForDropDown();
            var Productresult = productRepository.All().Take(30);

            ViewBag.Product = new SelectList(Productresult.Where(x => x.Id > 0).Select(s => new { Text = s.Code.Length < 4 ? s.Name : s.Name + " - [ " + s.Code + " ]", Value = s.Id }).ToList(), "Value", "Text");
            ViewBag.ProductSearch = Productresult;
            if (FromWarehousePermissionRepository.GetAllForDropDown().Count() > 0) { ViewBag.Warehouse = FromWarehousePermissionRepository.GetAllForDropDown(); } else { ViewBag.Warehouse = warehouseRepository.GetWarehouseLedgerHeadForDropDown(); }

            ViewBag.PaymentTypes = paymentTypeRepository.GetAllForDropDown();
            ViewBag.AccountHead = accountHeadRepository.GetCashBankHeadForDropDown();
            if (PurchaseReturnmain == null)
            {
                return NotFound();
            }

            //Call Create View
            return View("POSCreate", PurchaseReturnmain);
        }


        [HttpGet]
        public IActionResult EditPurchaseReturn(int purchasereturnId)
        {

            ViewBag.ActionType = "Edit";
            ViewBag.suppliers = supplierRepository.GetAllForDropDown();
            if (FromWarehousePermissionRepository.GetAllForDropDown().Count() > 0) { ViewBag.Warehouse = FromWarehousePermissionRepository.GetAllForDropDown(); } else { ViewBag.Warehouse = warehouseRepository.GetWarehouseLedgerHeadForDropDown(); }
            ViewBag.Category = categoryRepository.GetAllForDropDown();
            ViewBag.Unit = _unitRepository.GetAllForDropDown();





            var batchlist = purchasereturnItemRepository.AllSubData().Where(x => x.PurchaseReturnId == purchasereturnId).Include(x => x.BatchSerialItems).Select(x => x.BatchSerialItems.Count()).FirstOrDefault();
            var batchlistArray = purchasereturnItemRepository.AllSubData().Where(x => x.PurchaseReturnId == purchasereturnId && x.SerialItem != null).Count();


            var batchdata = batchlist;

            var isSerialPurchaseReturn = false;
            isSerialPurchaseReturn = purchasereturnRepository.All().Where(x => x.Id == purchasereturnId).Select(x => x.isSerialPurchaseReturn).FirstOrDefault();



            //if (isSerialPurchaseReturn == true)
            //{
            return View("AddPurchaseReturnBySerialSearch", model: purchasereturnId);

            //}
            //else if (batchdata > 0 && batchlistArray == 0 && isSerialPurchaseReturn == false)
            //{
            //    return View("AddPurchaseReturnerial", model: purchasereturnId);
            //}
            //else if (batchlistArray > 0 && isSerialPurchaseReturn == false)
            //{
            //    return View("AddPurchaseReturnerialSide", model: purchasereturnId);
            //}

            //return View("AddPurchaseReturn", model: purchasereturnId);


            //var purchasereturn = purchasereturnRepository.All()
            //    .Include(x => x.Items)
            //    .SingleOrDefault(x => x.Id == purchasereturnId);

            ////var purchasereturn = purchasereturnRepository.Find(purchasereturnId);
            //if (purchasereturn != null)
            //    return View("AddPurchaseReturn",model: purchasereturn);
            //return RedirectToAction("index");

        }
        [HttpGet]
        public IActionResult EditPurchaseReturnerial(int purchasereturnId)
        {

            ViewBag.ActionType = "Edit";
            ViewBag.suppliers = supplierRepository.GetAllForDropDown();
            if (FromWarehousePermissionRepository.GetAllForDropDown().Count() > 0) { ViewBag.Warehouse = FromWarehousePermissionRepository.GetAllForDropDown(); } else { ViewBag.Warehouse = warehouseRepository.GetWarehouseLedgerHeadForDropDown(); }
            ViewBag.Category = categoryRepository.GetAllForDropDown();
            ViewBag.Unit = _unitRepository.GetAllForDropDown();
            return View("AddPurchaseReturnerial", model: purchasereturnId);



        }

        [HttpGet]
        public IActionResult EditPurchaseReturnSerialSide(int purchasereturnId)
        {

            ViewBag.ActionType = "Edit";
            ViewBag.suppliers = supplierRepository.GetAllForDropDown();
            if (FromWarehousePermissionRepository.GetAllForDropDown().Count() > 0) { ViewBag.Warehouse = FromWarehousePermissionRepository.GetAllForDropDown(); } else { ViewBag.Warehouse = warehouseRepository.GetWarehouseLedgerHeadForDropDown(); }
            ViewBag.Category = categoryRepository.GetAllForDropDown();
            ViewBag.Unit = _unitRepository.GetAllForDropDown();
            return View("AddPurchaseReturnerialSide", model: purchasereturnId);



        }



        [HttpPost]
        public IActionResult EditPurchaseReturn(PurchaseReturnModel model)
        {
            if (model != null)
            {
                var UserId = HttpContext.Session.GetInt32("UserId");
                var ComId = HttpContext.Session.GetInt32("ComId");

                var items = purchasereturnItemRepository.AllSubData().Where(x => x.PurchaseReturnId == model.Id).ToList();
                if (items.Any())
                {
                    foreach (var item in items)
                    {
                        purchasereturnItemRepository.Delete(item);
                    }
                }

                var purchasereturn = purchasereturnRepository.Find(model.Id);
                purchasereturn.Notes = model.Notes;
                purchasereturn.SupplierName = model.SupplierName;
                purchasereturn.PhoneNo = model.PhoneNo;
                purchasereturn.PrimaryAddress = model.PrimaryAddress;

                //purchasereturn.PaymentMethod = model.PaymentMethod;
                purchasereturn.PurchaseReturnCode = model.PurchaseReturnCode;
                purchasereturn.SupplierId = model.SupplierId;
                purchasereturn.Total = model.Total;
                purchasereturn.PurchaseReturnDate = model.PurchaseReturnDate;
                purchasereturn.Status = model.Status;
                purchasereturn.Discount = model.Discount;

                purchasereturn.ServiceCharge = model.ServiceCharge;
                purchasereturn.Shipping = model.Shipping;
                purchasereturn.TotalVat = model.TotalVat;

                purchasereturn.GrandTotal = model.GrandTotal;

                //add again
                foreach (var item in model.Items)
                {
                    purchasereturn.Items.Add(new PurchaseReturnItemsModel
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
                purchasereturnRepository.Update(purchasereturn, model.Id);



                TempData["Message"] = "Data Update Successfully";
                TempData["Status"] = "2";
                tranlog.TransactionLog(RouteData.Values["controller"].ToString(), RouteData.Values["action"].ToString(), TempData["Message"].ToString(), model.Id.ToString(), "Update", model.PurchaseReturnCode.ToString());

                return Json(new { error = false, message = "PurchaseReturn updated successfully" });
            }
            return Json(new { error = true, message = "failed to update PurchaseReturn" });
        }

        public IActionResult DeletePurchaseReturn(int purchasereturnId)
        {
            var model = this.purchasereturnRepository.Find(purchasereturnId);
            purchasereturnRepository.Delete(model);


            TempData["Message"] = "Data Delete Successfully";
            TempData["Status"] = "3";
            tranlog.TransactionLog(RouteData.Values["controller"].ToString(), RouteData.Values["action"].ToString(), TempData["Message"].ToString(), model.Id.ToString(), "Delete", model.PurchaseReturnCode);



            return RedirectToAction("index");
        }



        [AllowAnonymous]

        public ActionResult PurchaseReturnReport(int purchasereturnId)
        {
            var UserId = HttpContext.Session.GetInt32("UserId");
            var ComId = HttpContext.Session.GetInt32("ComId");
            var weburl = HttpContext.Session.GetString("weburl");



            string reportname = "rptPurchaseOrder";
            var filename = "PurchaseReturn_";
            //string apppath = "";


            //if (ComId == 23)
            //{
            //    reportname = "rptInvoice_globalmedia";

            //}


            HttpContext.Session.SetString("ReportQuery", "Exec  [rptPurchaseReturn] '" + purchasereturnId + "','" + ComId + "', '" + weburl + "'");
            HttpContext.Session.SetString("ReportPath", "~/ReportViewer/POS/" + reportname + ".rdlc");
            HttpContext.Session.SetString("PrintFileName", filename.Replace(".", "").Replace(" ", "").Replace(",", "").Replace("\"", ""));


            //postData.Add(1, new subReport("rptInvoice_Terms", "", "DataSet1", "Exec " + AppData.AppData.dbGTCommercial.ToString() + ".dbo.rptInvoice_Terms '" + id + "','" + Session["comid"].ToString() + "',''"));

            //postData.Add(1, new subReport("rptInvoice_BankDetails", "", "DataSet1", "Exec rptInvoice_BankDetails '" + purchasereturnId + "'," + ComId + ",'" + AppData.AppData.AppPath.ToString() + "'"));
            postData.Add(2, new subReport("rptPurchaseOrder_PM", "", "DataSet1", "Exec [rptPurchaseReturn_PM] '" + purchasereturnId + "'," + ComId + ""));


            //clsReport.rptList.Add(new subReport("rptInvoice_Terms", "", "DataSet1", "Exec " + AppData.AppData.dbGTCommercial.ToString() + ".dbo.rptInvoice_Terms '" + id + "'," + Session["comid"].ToString() + ",'" + AppData.AppData.AppPath.ToString() + "'"));

            HttpContext.Session.SetObject("rptList", postData);


            return RedirectToAction("Index", "ReportViewer");
        }


        [HttpGet]
        public IActionResult Report()
        {
            ViewBag.ActionType = "Report";
            ViewBag.Product = productRepository.GetAllProductForDropDown();
            if (FromWarehousePermissionRepository.GetAllForDropDown().Count() > 0) { ViewBag.Warehouse = FromWarehousePermissionRepository.GetAllForDropDown(); } else { ViewBag.Warehouse = warehouseRepository.GetWarehouseLedgerHeadForDropDown(); }


            ViewBag.Supplier = supplierRepository.GetAllForDropDown();
            ViewBag.Supplier = supplierRepository.GetAllForDropDown();


            ViewBag.CreditAccount = accountHeadRepository.GetCashBankHeadForDropDown();
            ViewBag.AccountReceiveType = accountHeadRepository.GetCashBankHeadForDropDown();

            ViewBag.Category = categoryRepository.GetAllForDropDown();




            return View();
        }


        [HttpGet]
        [AllowAnonymous]
        public JsonResult GetPurchaseReturn(int purchasereturnId)
        {
            try
            {



                PurchaseReturnModel PurchaseReturn = purchasereturnRepository.All().Include(x => x.PurchaseInfo).FirstOrDefault(x => x.Id == purchasereturnId && x.isPosted == false);
                if (PurchaseReturn == null)
                {
                    return Json("No Data Found");
                }

                //PurchaseReturn.Items = purchasereturnItemRepository.AllSubData().Where(x => x.PurchaseReturnId == PurchaseReturn.Id).ToList();
                PurchaseReturn.Items = purchasereturnItemRepository.AllSubData()
                    .Include(x => x.Product).Include(x => x.vWarehouse)
                    .Include(x => x.BatchSerialItems)
                    .Where(x => x.PurchaseReturnId == PurchaseReturn.Id).ToList();


                PurchaseReturn.PurchaseReturnPayments = PurchaseReturnPaymentRepository.AllSubData()
                    //.Include(x => x.vPaymentType)
                    .Include(x => x.vChartofAccounts)
                    .Where(x => x.PurchaseReturnId == PurchaseReturn.Id).ToList();


                //var batchlistArray = purchasereturnItemRepository.AllSubData().Where(x => x.PurchaseReturnId == purchasereturnId && x.SerialItem.Length != 0).Count();

                //if (batchlistArray != null)
                //{
                foreach (var item in PurchaseReturn.Items)
                {
                    if (item.SerialItem != null)
                    {
                        var serialitems = item.SerialItem.Split(',');
                        //serialitems.Reverse();

                        item.SerialItemArray = serialitems;
                    }

                }
                //}



                //PurchaseReturnItemsModel a = new PurchaseReturnItemsModel { Name = "abc", Amount = 2.5, Id = 1, IsDelete = false, Price = 2.5, Quantity = 1, PurchaseReturnId = 5};
                //PurchaseReturn.Items.Add(a);
                return Json(PurchaseReturn);
                //return Json(new { Success = 1, PurchaseReturn = PurchaseReturn, ex = "Data Load Successfully" });
            }
            catch (Exception e)
            {
                return Json(e.ToString());
            }

        }

        [AllowAnonymous]
        public JsonResult GetSuppliers()
        {
            return Json(supplierRepository.All());
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

            //return Json(accountHeadRepository.GetCashBankHeadForDropDown());
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
                PurchaseReturnModel abc = new PurchaseReturnModel();
                abc.PurchaseReturnDate = DateTime.Now.Date;

                var comid = HttpContext.Session.GetString("ComId");
                var userid = HttpContext.Session.GetString("userid");

                object a = HttpContext.Session.GetString("isProductSearch");
                ViewBag.ActionType = "Entry";

                ViewBag.Supplier = supplierRepository.GetAllForDropDown();
                ViewBag.Category = categoryRepository.GetAllForDropDown();
                var Productresult = productRepository.All().Take(4000);

                //ViewBag.Product = productRepository.GetAllProductForDropDown();
                //ViewBag.Product = new SelectList(Productresult, "Id", "Name");
                ViewBag.Product = new SelectList(Productresult.Where(x => x.Id > 0).Select(s => new { Text = s.Code.Length < 4 ? s.Name : s.Name + " - [ " + s.Code + " ]", Value = s.Id }).ToList(), "Value", "Text");
                ViewBag.ProductSearch = Productresult;
                if (FromWarehousePermissionRepository.GetAllForDropDown().Count() > 0) { ViewBag.Warehouse = FromWarehousePermissionRepository.GetAllForDropDown(); } else { ViewBag.Warehouse = warehouseRepository.GetWarehouseLedgerHeadForDropDown(); }

                ViewBag.PaymentTypes = paymentTypeRepository.GetAllForDropDown();
                ViewBag.AccountHead = accountHeadRepository.GetCashBankHeadForDropDown();

                //////////////ViewBag.PurchaseReturnType = new SelectList(POS.GetPurchaseReturnType(), "PurchaseReturnTypeId", "TypeShortName");
                //////////////ViewBag.Supplier = new SelectList(db.Suppliers.Where(x => x.comid == comid).Take(20), "SupplierId", "SupplierName");

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
        public JsonResult SupplierInfo(int id)
        {
            try
            {
                SupplierModel supplier = supplierRepository.All().Where(y => y.Id == id).SingleOrDefault();
                return Json(supplier);
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
                                    CostPrice = e.Price,
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
                                    CostPrice = e.Price,
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

        //    var licoa = accountHeadRepository.GetCashBankHeadForDropDown();

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