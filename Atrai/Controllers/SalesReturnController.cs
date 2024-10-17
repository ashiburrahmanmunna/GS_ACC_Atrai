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
    public class SalesReturnController : Controller
    {
        public TransactionLogRepository tranlog { get; }

        private readonly ICustomerRepository customerRepository;
        private readonly IUserAccountRepository UserAccountRepository;

        private readonly ISupplierRepository supplierRepository;

        private readonly ISalesReturnRepository salesreturnRepository;
        private readonly ISalesReturnItemsRepository salesreturnItemRepository;
        private readonly ISalesReturnBatchItemsRepository _SalesReturnBatchItemRepository;

        private readonly ISalesExchangeItemsRepository salesExchangeItemRepository;
        private readonly ISalesExchangeBatchItemsRepository _SalesExchangeBatchItemRepository;

        private readonly IPurchaseBatchItemsRepository _purchaseBatchItemRepository;

        private readonly ISalesReturnPaymentRepository SalesReturnPaymentRepository;

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

        private readonly IDocTypeRepository _docTypeRepository;
        private readonly IEmployeeRepository _employeeRepository;
        private readonly ICountryRepository _currencyRepository;
        private readonly ISaleRepository saleRepository;


        //private readonly IpaymentTypesRepository paymentTypesRepository;


        public static string ExpressionParameterizationException { get; }
        Dictionary<int, dynamic> postData = new Dictionary<int, dynamic>();


        public SalesReturnController(ICustomerRepository customerRepository, IUserAccountRepository UserAccountRepository, ISalesReturnRepository salesreturnRepository,
            ISupplierRepository supplierRepository, IPurchaseRepository purchaseRepository,

            ISalesReturnItemsRepository salesreturnItemRepository, ISalesReturnBatchItemsRepository salesreturnBatchItemRepository, ISalesReturnPaymentRepository SalesReturnPaymentRepository,
            IPurchaseBatchItemsRepository purchaseBatchItemRepository,
             IPurchaseItemsRepository purchaseItemsRepository, IPurchasePaymentRepository purchasePaymentRepository,

            IStoreSettingRepository storeSettingRepository,
            ICategoryRepository categoryRepository, IUnitRepository unitRepository, IProductRepository productRepository,
            IWarehouseRepository warehouseRepository, IFromWarehousePermissionRepository FromWarehousePermissionRepository, IToWarehousePermissionRepository ToWarehousePermissionRepository, IAccountHeadRepository accountHeadRepository,
            IPaymentTypeRepository paymentTypeRepository, ICompanyRepository companyRepository,
            IConfiguration configuration, TransactionLogRepository tranlogRepository, ISalesExchangeItemsRepository salesExchangeItemRepository, ISalesExchangeBatchItemsRepository salesExchangeBatchItemRepository, IDocTypeRepository docTypeRepository, IEmployeeRepository employeeRepository, ICountryRepository currencyRepository, ISaleRepository saleRepository, IAccountHeadPermissionRepository accountHeadPermissionRepository)
        {
            this.configuration = configuration;

            this.customerRepository = customerRepository;
            this.UserAccountRepository = UserAccountRepository;
            this.salesreturnRepository = salesreturnRepository;
            this.salesreturnItemRepository = salesreturnItemRepository;
            this._SalesReturnBatchItemRepository = salesreturnBatchItemRepository;
            this._purchaseBatchItemRepository = purchaseBatchItemRepository;

            this.SalesReturnPaymentRepository = SalesReturnPaymentRepository;


            this.supplierRepository = supplierRepository;
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
            this.salesExchangeItemRepository = salesExchangeItemRepository;
            _SalesExchangeBatchItemRepository = salesExchangeBatchItemRepository;
            _docTypeRepository = docTypeRepository;
            _employeeRepository = employeeRepository;
            _currencyRepository = currencyRepository;
            this.saleRepository = saleRepository;
            AccountHeadPermissionRepository = accountHeadPermissionRepository;
        }

        public IActionResult Index()
        {
            ViewBag.FromDate = DateTime.Now.Date;
            ViewBag.ToDate = DateTime.Now.Date;

            ViewBag.Customers = customerRepository.GetAllForDropDown();
            ViewBag.Users = UserAccountRepository.GetAllForDropDown();
            //int abcd = HttpContext.Session.GetInt32("ComId");
            //return View(salesreturnRepository.All().Include(x=>x.CustomerModel).OrderByDescending(x=>x.Id));
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
        public IActionResult AddSalesReturn()
        {

            ViewBag.ActionType = "Create";
            int salesreturnId = 0;
            ViewBag.customers = customerRepository.GetAllForDropDown();


            //if (FromWarehousePermissionRepository.GetAllForDropDown().Count() > 0) { ViewBag.Warehouse = FromWarehousePermissionRepository.GetAllForDropDown(); } else { ViewBag.Warehouse = warehouseRepository.GetWarehouseLedgerHeadForDropDown(); }

            var x = FromWarehousePermissionRepository.GetAllForDropDown();
            if (x.Count() == 0)
            {
                x = warehouseRepository.GetWarehouseLedgerHeadForDropDown();
            }
            ViewBag.Warehouse = x;


            ViewBag.Category = categoryRepository.GetAllForDropDown();
            ViewBag.Unit = _unitRepository.GetAllForDropDown();

            ViewBag.DocType = _docTypeRepository.GetSalesDocForDropDown();
            ViewBag.SalesRep = _employeeRepository.GetAllForDropDown();
            ViewBag.Currency = _currencyRepository.GetCurrencyList();

            return View(model: salesreturnId);
        }
        [HttpGet]
        [AllowAnonymous]
        public IActionResult AddSalesReturnSerial()
        {

            ViewBag.ActionType = "Create";
            int salesreturnId = 0;
            //ViewBag.customers = customerRepository.GetAllForDropDown();


            if (FromWarehousePermissionRepository.GetAllForDropDown().Count() > 0) { ViewBag.Warehouse = FromWarehousePermissionRepository.GetAllForDropDown(); } else { ViewBag.Warehouse = warehouseRepository.GetWarehouseLedgerHeadForDropDown(); }


            ViewBag.Category = categoryRepository.GetAllForDropDown();
            ViewBag.Unit = _unitRepository.GetAllForDropDown();

            ViewBag.DocType = _docTypeRepository.GetSalesDocForDropDown();
            ViewBag.SalesRep = _employeeRepository.GetAllForDropDown();
            ViewBag.Currency = _currencyRepository.GetCurrencyList();


            return View(model: salesreturnId);
        }

        [HttpGet]
        [AllowAnonymous]
        public IActionResult AddSalesReturnBySerialSearch()
        {

            ViewBag.ActionType = "Create";
            int salesreturnId = 0;
            //ViewBag.customers = customerRepository.GetAllForDropDown();
            if (FromWarehousePermissionRepository.GetAllForDropDown().Count() > 0)
            { ViewBag.Warehouse = FromWarehousePermissionRepository.GetAllForDropDown(); }
            else { ViewBag.Warehouse = warehouseRepository.GetWarehouseLedgerHeadForDropDown(); }
            ViewBag.Category = categoryRepository.GetAllForDropDown();
            ViewBag.Unit = _unitRepository.GetAllForDropDown();

            ViewBag.DocType = _docTypeRepository.GetSalesDocForDropDown();
            ViewBag.SalesRep = _employeeRepository.GetAllForDropDown();
            ViewBag.Currency = _currencyRepository.GetCurrencyList();


            return View(model: salesreturnId);
        }

        [HttpGet]
        [AllowAnonymous]
        public IActionResult AddSalesReturnSerialSide()
        {

            ViewBag.ActionType = "Create";
            int salesreturnId = 0;
            //ViewBag.customers = customerRepository.GetAllForDropDown();
            if (FromWarehousePermissionRepository.GetAllForDropDown().Count() > 0) { ViewBag.Warehouse = FromWarehousePermissionRepository.GetAllForDropDown(); } else { ViewBag.Warehouse = warehouseRepository.GetWarehouseLedgerHeadForDropDown(); }
            ViewBag.Category = categoryRepository.GetAllForDropDown();
            ViewBag.Unit = _unitRepository.GetAllForDropDown();

            ViewBag.DocType = _docTypeRepository.GetSalesDocForDropDown();
            ViewBag.SalesRep = _employeeRepository.GetAllForDropDown();
            ViewBag.Currency = _currencyRepository.GetCurrencyList();

            return View(model: salesreturnId);
        }


        public class SalesReturnResultList : SalesReturnModel
        {
            public string? StatusPosted { get; set; }
            public string? SalesReturnDateString { get; set; }
            public string? ReceivingHead { get; set; }
            public string? SalesReturnUser { get; set; }
            public object SalesReturnPayments { get; set; }

        }


        //[HttpPost]
        [AllowAnonymous]
        public JsonResult GetSalesReturnSummaryInfo(string FromDate, string ToDate, int? CustomerId, int? UserId)
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


                //var saleinfo = saleRepository.All().Where(p => p.salesreturnDate >= dtFrom && p.salesreturnDate <= dtTo).SingleOrDefault();


                var salesreturnlist = salesreturnRepository.All().Where(x => x.SalesReturnDate >= dtFrom && x.SalesReturnDate <= dtTo);
                var salesreturnpaymentlist = SalesReturnPaymentRepository.All().Include(x => x.SalesReturnMain).ThenInclude(x => x.CustomerModel).Where(x => x.SalesReturnMain.SalesReturnDate >= dtFrom && x.SalesReturnMain.SalesReturnDate <= dtTo && x.SalesReturnMain.IsDelete == false);
                var salesreturnitemlist = salesreturnItemRepository.All().Where(x => x.SalesReturnModel.SalesReturnDate >= dtFrom && x.SalesReturnModel.SalesReturnDate <= dtTo && x.SalesReturnModel.IsDelete == false);

                if (CustomerId != null)
                {
                    salesreturnlist = salesreturnlist.Where(p => p.CustomerId == CustomerId);
                    salesreturnpaymentlist = salesreturnpaymentlist.Where(p => p.SalesReturnMain.CustomerId == CustomerId);
                    salesreturnitemlist = salesreturnitemlist.Where(p => p.SalesReturnModel.CustomerId == CustomerId);

                }

                if (UserId != null)
                {
                    salesreturnlist = salesreturnlist.Where(p => p.LuserId == UserId);
                    salesreturnpaymentlist = salesreturnpaymentlist.Where(p => p.SalesReturnMain.LuserId == UserId);
                    salesreturnitemlist = salesreturnitemlist.Where(p => p.SalesReturnModel.LuserId == UserId);
                }



                var totalsalesreturnsummary = salesreturnlist //.GroupBy(p => p.vPaymentType.TypeName);
                .GroupBy(x => new { x.ComId })
                .Select(g => new { TotalsalesreturnCount = g.Count(), TotalsalesreturnValue = g.Sum(x => x.NetAmount), TotalCosting = g.Sum(x => x.FinalCostingPrice), TotalProfit = g.Sum(x => x.Profit) });



                var salesreturnbyuser = salesreturnlist //.GroupBy(p => p.vPaymentType.TypeName);
                .GroupBy(x => new { x.UserAccountList.Name })
                .Select(g => new { UserName = g.Key.Name, TotalsalesreturnCount = g.Count(), TotalsalesreturnSum = g.Sum(x => x.NetAmount) }).ToList();


                var commissionbyuser = salesreturnlist //.GroupBy(p => p.vPaymentType.TypeName);
                .GroupBy(x => new { x.UserAccountList.Name })
                .Select(g => new { UserName = g.Key.Name, TotalsalesreturnCount = g.Count(), TotalCommissionAmount = g.Sum(x => x.TotalCommisionAmount) }).ToList();


                var salesreturnreceivebyhead = salesreturnpaymentlist.GroupBy(x => new { x.vChartofAccounts.AccName })
                .Select(g => new { AccName = g.Key.AccName, Amount = g.Sum(x => x.Amount) }).ToList();


                var totalreceivedamount = salesreturnpaymentlist.Sum(x => x.Amount);
                var totalsalesreturn = salesreturnlist.Sum(x => x.GrandTotal);
                salesreturnreceivebyhead.Add(new
                {
                    AccName = "Due",
                    Amount = (totalsalesreturn - totalreceivedamount)
                });




                var topsellingitem = salesreturnitemlist //.GroupBy(p => p.vPaymentType.TypeName);
                 .GroupBy(x => new { x.Product.Name })
                 .Select(g => new { ProductName = g.Key.Name, ProductCount = g.Count() }).ToList().OrderByDescending(x => x.ProductCount).Take(5);



                var topsellingcustomer = salesreturnlist.Include(x => x.CustomerModel)//.GroupBy(p => p.vPaymentType.TypeName);
                 .GroupBy(x => new { walkincustomer = x.CustomerName, CustomerName = x.CustomerModel.Name })
                 .Select(g => new { CustomerName = g.Key.CustomerName.ToLower().Contains("customer") ? g.Key.walkincustomer : g.Key.CustomerName, salesreturnAmount = g.Sum(x => x.GrandTotal) }).ToList().OrderByDescending(x => x.salesreturnAmount).Take(5);


                //var topduecustomer = saleRepository.All().Include(x => x.CustomerModel).Include(x => x.salesreturnPayments).Where(x => x.salesreturnDate >= dtFrom && x.salesreturnDate <= dtTo)
                ////.Select(x => new { walkintcustomer = x.CustomerName, customername = x.CustomerModel.Name , DueAmount = x.GrandTotal - x.salesreturnPayments.Sum(x=>x.Amount) })  //.GroupBy(p => p.vPaymentType.TypeName);
                //.GroupBy(x => new { walkintcustomer =  x.CustomerName, CustomerName = x.CustomerModel.Name })
                //.Select(g => new { CustomerName = g.Key.CustomerName + " " + g.Key.walkintcustomer, DueAmount = g.Sum(x => x.GrandTotal - x.salesreturnPayments.Sum(x => x.Amount)) })
                //.ToList();//.OrderByDescending(x => x.DueAmount).Take(5);


                var topduecustomer = salesreturnpaymentlist
                .GroupBy(x => new { walkincustomer = x.SalesReturnMain.CustomerName, CustomerName = x.SalesReturnMain.CustomerModel.Name, GradnTotal = x.SalesReturnMain.GrandTotal })
                .Select(g => new { CustomerName = g.Key.CustomerName.ToLower().Contains("customer") ? g.Key.walkincustomer : g.Key.CustomerName, Totalsalesreturn = g.Key.GradnTotal, ReceivedAmount = g.Sum(x => x.Amount) })
                .Where(x => (x.Totalsalesreturn - x.ReceivedAmount > 0))
                .ToList().OrderByDescending(x => x.Totalsalesreturn - x.ReceivedAmount)
                .Take(5).ToList();

                var topduecustomermore = salesreturnlist.Include(x => x.SalesReturnPayments).Include(x => x.CustomerModel).Where(x => x.SalesReturnPayments.Count() == 0)
               .GroupBy(x => new { walkincustomer = x.CustomerName, CustomerName = x.CustomerModel.Name, GradnTotal = x.GrandTotal })
               .Select(g => new { CustomerName = g.Key.CustomerName.ToLower().Contains("customer") ? g.Key.walkincustomer : g.Key.CustomerName, Totalsalesreturn = g.Sum(x => g.Key.GradnTotal), ReceivedAmount = decimal.Parse("0") })
               .Where(x => (x.Totalsalesreturn - x.ReceivedAmount > 0))
               .ToList().OrderByDescending(x => x.Totalsalesreturn - x.ReceivedAmount)
               .Take(5).ToList();

                foreach (var item in topduecustomermore)
                {
                    topduecustomer.Add(item);
                }


                var postunpostcount = salesreturnlist //.GroupBy(p => p.vPaymentType.TypeName);
                .GroupBy(x => new { isPosted = x.isPosted })
                .Select(g => new { isPosted = g.Key.isPosted, DocCount = g.Count() }).ToList();



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
                //                     join o in saleRepository.All().ToList() on op.salesreturnId equals o.Id
                //                     where op.ProductId == p.Id && o.salesreturnDate >= dtFrom && o.salesreturnDate <= dtTo
                //                     select op.Quantity).Sum()
                //where totalQuantity > 0
                //orderby totalQuantity descending
                //select p).Take(10);


                //return Json(totalsalesreturnsummary);

                var genericResult = new
                {
                    totalsalesreturnsummary = totalsalesreturnsummary,
                    salesreturnbyuser = salesreturnbyuser,
                    salesreturnreceivebyhead = salesreturnreceivebyhead,
                    commissionbyuser = commissionbyuser,
                    topsellingitem = topsellingitem,
                    topsellingcustomer = topsellingcustomer,
                    topduecustomer = topduecustomer,
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
        public IActionResult GetSalesReturnList(string FromDate, string ToDate, int? CustomerId, int? UserId, string Status, int isAll)
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

                var SalesReturnlist = salesreturnRepository.All();




                if (y.ToString().Length > 0)
                {


                }
                else
                {
                    SalesReturnlist = SalesReturnlist.Where(p => (p.SalesReturnDate >= dtFrom && p.SalesReturnDate <= dtTo));

                    if (CustomerId != null)
                    {
                        SalesReturnlist = SalesReturnlist.Where(p => p.CustomerId == CustomerId);
                    }
                    if (UserId != null)
                    {
                        SalesReturnlist = SalesReturnlist.Where(p => p.LuserId == UserId);
                    }
                    if (Status == "Due")
                    {
                        //var SalesReturnlistmore = SalesReturnlist.Where(x => x.GrandTotal -  x.SalesReturnPayments.Sum(x=>x.Amount) > 0);

                        SalesReturnlist = SalesReturnlist.Where(x => x.GrandTotal - x.SalesReturnPayments.Sum(x => x.Amount) > 0);

                        //SalesReturnlist = SalesReturnlist.Where(x=>x.SalesReturnPayments.Count == 0);


                    }
                    //else
                    //{
                    //    //SalesReturnlist = SalesReturnlist.Where(p => p.SalesReturnDate >= dtFrom && p.SalesReturnDate <= dtTo);

                    //    //if (CustomerId == 1)
                    //    //{
                    //    //    SalesReturnlist = SalesReturnlist.Where(p => p.SalesReturnDate >= dtFrom && p.SalesReturnDate <= dtTo);
                    //    //}
                    //    //else
                    //    //{
                    //    //}
                    //}

                }



                var query = from e in SalesReturnlist.Include(x => x.Items).ThenInclude(x => x.Product).ThenInclude(x => x.Category)
                            .Include(x => x.ExchangeItems).ThenInclude(x => x.Product).ThenInclude(x => x.Category)
                            .Include(x => x.SalesReturnPayments).ThenInclude(x => x.vChartofAccounts)
                            .Include(x => x.SalesReturnPayments).ThenInclude(x => x.Transaction)
                            select new SalesReturnResultList
                            {
                                Id = e.Id,
                                SalesReturnCode = e.SalesReturnCode,
                                SalesReturnDate = e.SalesReturnDate,
                                SalesReturnDateString = e.SalesReturnDate.ToString("dd-MMM-yy"),

                                SalesReturnUser = e.UserAccountList.Name,

                                CustomerName = (e.CustomerName.Length == 0 || e.CustomerName == null) ? e.CustomerModel.Name : e.CustomerModel.Name + " - " + e.CustomerName,
                                //CustomerName = e.CustomerName,
                                PrimaryAddress = e.PrimaryAddress,
                                SecoundaryAddress = e.SecoundaryAddress,
                                Notes = e.Notes,
                                PhoneNo = e.PhoneNo,
                                Discount = e.Discount,
                                Total = e.Total,
                                Status = e.Status,
                                NetAmount = e.NetAmount,
                                isPOSSalesReturn = e.isPOSSalesReturn,
                                isSerialSalesReturn = e.isSerialSalesReturn,
                                isPosted = e.isPosted,
                                FinalCostingPrice = e.FinalCostingPrice,
                                Profit = e.Profit,
                                ProfitPercentage = e.ProfitPercentage,

                                StatusPosted = e.isPosted != false ? "Posted" : "Not Posted",
                                PaidAmt = e.SalesReturnPayments.Sum(x => x.Amount),
                                //SalesReturnPayments = e.SalesReturnPayments.ToList()

                                SalesReturnPayments = e.SalesReturnPayments.Select(x => new
                                {
                                    x.SalesReturnId,
                                    x.PaymentCardNo,
                                    x.isPosted,
                                    x.Amount,
                                    x.RowNo,
                                    x.AccountHeadId,
                                    AccType = x.vChartofAccounts.AccType,
                                    AccName = x.vChartofAccounts.AccName,
                                    TransactionCode = x.Transaction.TransactionCode
                                }).ToList(),
                                Items = e.Items.Where(x => x.IsDelete == false).ToList(),
                                ExchangeItems = e.ExchangeItems.Where(x => x.IsDelete == false).ToList(),

                            };


                var parser = new Parser<SalesReturnResultList>(Request.Form, query);

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
        public IActionResult AddSalesReturn([FromBody] SalesReturnModel model)
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

                        SqlParameter[] sqlParameter = new SqlParameter[4];
                        sqlParameter[0] = new SqlParameter("@ComId", ComId);
                        sqlParameter[1] = new SqlParameter("@Id", model.Id);
                        sqlParameter[2] = new SqlParameter("@ProcessFor", "SalesReturn");
                        sqlParameter[3] = new SqlParameter("@SaveUpdateDelete", "Update");
                        Helper.ExecProc("prcSerialProcess", sqlParameter);


                        salesreturnRepository.Update(model, model.Id);




                        foreach (SalesReturnItemsModel item in model.Items)
                        {

                            if (item.Id > 0)
                            {
                                if (item.IsDelete == true || item.Quantity == 0)
                                {
                                    int z = item.Id;
                                    salesreturnItemRepository.Delete(item);

                                }
                                else
                                {
                                    if (item.IsTransaction == true)//item.IsDelete == false &&  
                                    {

                                        if (item.SerialItem != null)
                                        {

                                            var batchitemlist = _SalesReturnBatchItemRepository.All().Where(x => x.SalesReturnItemId == item.Id).ToList();
                                            _SalesReturnBatchItemRepository.RemoveRange(batchitemlist);

                                        }


                                        foreach (SalesReturnBatchItemsModel batchitem in item.BatchSerialItems)
                                        {
                                            if (batchitem.Id > 0)
                                            {
                                                if (batchitem.IsDelete == true)
                                                {
                                                    int z = batchitem.Id;
                                                    _SalesReturnBatchItemRepository.Delete(batchitem);

                                                }
                                                else
                                                {
                                                    if (batchitem.IsTransaction == true)
                                                    {
                                                        batchitem.ComId = ComId.GetValueOrDefault();
                                                        _SalesReturnBatchItemRepository.Update(batchitem, batchitem.Id);
                                                    }
                                                }
                                            }
                                            else if (batchitem.Id == 0 && batchitem.IsDelete == false)
                                            {
                                                batchitem.ComId = ComId.GetValueOrDefault();
                                                _SalesReturnBatchItemRepository.Insert(batchitem);
                                            }


                                        }

                                        salesreturnItemRepository.Update(item, item.Id);

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

                                    salesreturnItemRepository.Insert(item);

                                    //foreach (SalesReturnBatchItemsModel batchitem in item.BatchSerialItems)
                                    //{
                                    //    if (batchitem.IsDelete == true)
                                    //    {

                                    //    }
                                    //    else
                                    //    {
                                    //        salesreturnItemRepository.Insert(item);

                                    //    }


                                    //}

                                }
                            }
                        }


                        foreach (SalesExchangeItemsModel item in model.ExchangeItems)
                        {

                            if (item.Id > 0)
                            {
                                if (item.IsDelete == true)
                                {
                                    int z = item.Id;
                                    salesExchangeItemRepository.Delete(item);

                                }
                                else
                                {
                                    if (item.IsTransaction == true)//item.IsDelete == false &&  
                                    {

                                        if (item.SerialItem != null)
                                        {

                                            var batchitemlist = _SalesExchangeBatchItemRepository.All().Where(x => x.SalesExchangeItemId == item.Id).ToList();
                                            _SalesExchangeBatchItemRepository.RemoveRange(batchitemlist);

                                        }


                                        foreach (SalesExchangeBatchItemsModel batchitem in item.BatchSerialItems)
                                        {
                                            if (batchitem.Id > 0)
                                            {
                                                if (batchitem.IsDelete == true)
                                                {
                                                    int z = batchitem.Id;
                                                    _SalesExchangeBatchItemRepository.Delete(batchitem);

                                                }
                                                else
                                                {
                                                    if (batchitem.IsTransaction == true)
                                                    {
                                                        batchitem.ComId = ComId.GetValueOrDefault();
                                                        _SalesExchangeBatchItemRepository.Update(batchitem, batchitem.Id);
                                                    }
                                                }
                                            }
                                            else if (batchitem.Id == 0 && batchitem.IsDelete == false)
                                            {
                                                batchitem.ComId = ComId.GetValueOrDefault();
                                                _SalesExchangeBatchItemRepository.Insert(batchitem);
                                            }


                                        }

                                        salesExchangeItemRepository.Update(item, item.Id);

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

                                    salesExchangeItemRepository.Insert(item);

                                    //foreach (SalesExchangeBatchItemsModel batchitem in item.BatchSerialItems)
                                    //{
                                    //    if (batchitem.IsDelete == true)
                                    //    {

                                    //    }
                                    //    else
                                    //    {
                                    //        salesexchangeItemRepository.Insert(item);

                                    //    }


                                    //}

                                }
                            }
                        }



                        var SalesReturnpaymentsdata = SalesReturnPaymentRepository.All().Where(x => x.SalesReturnId == model.Id && x.TransactionId == null).ToList();
                        SalesReturnPaymentRepository.RemoveRange(SalesReturnpaymentsdata);


                        foreach (SalesReturnPaymentModel item in model.SalesReturnPayments.Where(x => x.IsDelete == false))
                        {

                            SalesReturnPaymentRepository.Insert(item);


                            //if (item.Id > 0)
                            //{
                            //    if (item.IsDelete == true)
                            //    {
                            //        int z = item.Id;
                            //        SalesReturnPaymentRepository.Delete(item);

                            //    }
                            //    else
                            //    {
                            //        SalesReturnPaymentRepository.Update(item, item.Id);

                            //    }
                            //}
                            //else
                            //{
                            //    if (item.IsDelete == true)
                            //    {
                            //    }
                            //    else
                            //    {

                            //        SalesReturnPaymentRepository.Insert(item);

                            //    }
                            //}
                        }



                        TempData["Message"] = "Data Update Successfully";
                        TempData["Status"] = "2";
                        tranlog.TransactionLog(RouteData.Values["controller"].ToString(), RouteData.Values["action"].ToString(), TempData["Message"].ToString(), model.Id.ToString(), "Update", model.SalesReturnCode);



                        SqlParameter[] sqlParameter1 = new SqlParameter[4];
                        sqlParameter1[0] = new SqlParameter("@ComId", ComId);
                        sqlParameter1[1] = new SqlParameter("@Id", model.Id);
                        sqlParameter1[2] = new SqlParameter("@ProcessFor", "SalesReturn");
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
                            //        SalesReturnBatchItemsModel abc = new SalesReturnBatchItemsModel();
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




                        salesreturnRepository.Insert(model);


                        TempData["Message"] = "Data Save Successfully";
                        TempData["Status"] = "1";
                        tranlog.TransactionLog(RouteData.Values["controller"].ToString(), RouteData.Values["action"].ToString(), TempData["Message"].ToString(), model.Id.ToString(), "Create", model.SalesReturnCode);


                        SqlParameter[] sqlParameter1 = new SqlParameter[4];
                        sqlParameter1[0] = new SqlParameter("@ComId", ComId);
                        sqlParameter1[1] = new SqlParameter("@Id", model.Id);
                        sqlParameter1[2] = new SqlParameter("@ProcessFor", "SalesReturn");
                        sqlParameter1[3] = new SqlParameter("@SaveUpdateDelete", "Save");
                        Helper.ExecProc("prcSerialProcess", sqlParameter1);


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
        public JsonResult POSCreate(SalesReturnModel model)
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

                        var items = salesreturnItemRepository.AllSubData().Where(x => x.SalesReturnId == model.Id).ToList();
                        if (items.Any())
                        {
                            foreach (var item in items)
                            {
                                salesreturnItemRepository.Delete(item);
                            }
                        }

                        var SalesReturnpayment = SalesReturnPaymentRepository.AllSubData().Where(x => x.SalesReturnId == model.Id).ToList();
                        if (SalesReturnpayment.Any())
                        {
                            foreach (var item in SalesReturnpayment)
                            {
                                SalesReturnPaymentRepository.Delete(item);
                            }
                        }

                        var salesreturn = salesreturnRepository.Find(model.Id);

                        salesreturn.CustomerName = model.CustomerName;
                        salesreturn.PrimaryAddress = model.PrimaryAddress;
                        salesreturn.PhoneNo = model.PhoneNo;


                        salesreturn.Notes = model.Notes;
                        //salesreturn.PaymentMethod = model.PaymentMethod;
                        salesreturn.SalesReturnCode = model.SalesReturnCode;
                        salesreturn.CustomerId = model.CustomerId;
                        salesreturn.Total = model.Total;
                        salesreturn.SalesReturnDate = model.SalesReturnDate;
                        salesreturn.Status = model.Status;
                        salesreturn.Discount = model.Discount;


                        salesreturn.ServiceCharge = model.ServiceCharge;
                        salesreturn.Shipping = model.Shipping;
                        salesreturn.TotalVat = model.TotalVat;

                        salesreturn.GrandTotal = model.GrandTotal;
                        salesreturn.DisPer = model.DisPer;
                        salesreturn.DisAmt = model.DisAmt;
                        salesreturn.DueAmt = model.DueAmt;



                        //salesreturn.ttlCountQty = model.ttlCountQty;
                        //salesreturn.ttlIndDisAmt = model.ttlIndDisAmt;
                        //salesreturn.ttlIndPrice = model.ttlIndPrice;

                        //salesreturn.ttlIndVat = model.ttlIndVat;
                        //salesreturn.ttlSumAmt = model.ttlSumAmt;
                        //salesreturn.ttlSumQty = model.ttlSumQty;
                        //salesreturn.ttlUnitPrice = model.ttlUnitPrice;
                        salesreturn.LuserIdUpdate = int.Parse(UserId.ToString());



                        //add again
                        foreach (var item in model.Items)
                        {
                            salesreturn.Items.Add(new SalesReturnItemsModel
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

                        foreach (var item in model.SalesReturnPayments)
                        {
                            salesreturn.SalesReturnPayments.Add(new SalesReturnPaymentModel
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


                        salesreturnRepository.Update(salesreturn, model.Id);



                        TempData["Message"] = "Data Update Successfully";
                        TempData["Status"] = "2";
                        tranlog.TransactionLog(RouteData.Values["controller"].ToString(), RouteData.Values["action"].ToString(), TempData["Message"].ToString(), model.Id.ToString(), "Update", model.SalesReturnCode.ToString());

                        return Json(new { Success = 1, Id = model.Id, error = false, message = "SalesReturn updated successfully" });
                    }
                    else
                    {
                        model.isPOSSalesReturn = true;
                        var UserId = HttpContext.Session.GetInt32("UserId");
                        var ComId = HttpContext.Session.GetInt32("ComId");

                        foreach (var item in model.Items)
                        {

                            item.CreateDate = DateTime.Now;
                            item.UpdateDate = DateTime.Now;
                            item.ComId = int.Parse(ComId.ToString());
                        }

                        foreach (var item in model.SalesReturnPayments)
                        {

                            item.CreateDate = DateTime.Now;
                            item.UpdateDate = DateTime.Now;
                            item.ComId = int.Parse(ComId.ToString());
                        }

                        salesreturnRepository.Insert(model);


                        TempData["Message"] = "Data Save Successfully";
                        TempData["Status"] = "1";
                        tranlog.TransactionLog(RouteData.Values["controller"].ToString(), RouteData.Values["action"].ToString(), TempData["Message"].ToString(), model.Id.ToString(), "Create", model.SalesReturnCode);


                        return Json(new { Success = 1, Id = model.Id, error = false, message = "SalesReturn saved successfully" });
                    }

                }
                return Json(new { Success = 0, error = true, message = "failed to save SalesReturn" });

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return Json(new { Success = 0, error = true, message = "failed to save/update SalesReturn" });
            }





            //try
            //{
            //    var errors = ModelState.Where(x => x.Value.Errors.Any())
            //    .Select(x => new { x.Key, x.Value.Errors });

            //    if (ModelState.IsValid)
            //    {

            //        // If SalesReturn main has SalesReturnID then we can understand we have existing SalesReturn Information
            //        // So we need to Perform Update Operation

            //        // Perform Update
            //        if (SalesReturnmain.Id > 0)
            //        {

            //            IQueryable<SalesReturnSub> CurrentSalesReturnSUb = db.SalesReturnSubs.Where(p => p.SalesReturnId == SalesReturnmain.SalesReturnId);
            //            IQueryable<SalesReturnTermsSub> CurrentSalesReturnTermsSUb = db.SalesReturnTermsSubs.Where(p => p.SalesReturnId == SalesReturnmain.SalesReturnId);
            //            IQueryable<SalesReturnPaymentSub> CurrentSalesReturnPaymentSUb = db.SalesReturnPaymentSubs.Where(p => p.SalesReturnId == SalesReturnmain.SalesReturnId);


            //            foreach (SalesReturnSub ss in CurrentSalesReturnSUb)
            //            {
            //                db.SalesReturnSubs.Remove(ss);


            //                ///inventory calculation after remove the data
            //                Inventory inv = db.Inventory.Where(x => x.ProductId == ss.ProductId && x.WareHouseId == ss.WarehouseId).FirstOrDefault();
            //                if (inv != null)
            //                {
            //                    inv.SalesReturnQty = inv.SalesReturnQty - ss.Qty;
            //                    db.Entry(inv).State = EntityState.Modified;
            //                }
            //            }

            //            foreach (SalesReturnTermsSub sss in CurrentSalesReturnTermsSUb)
            //            {
            //                db.SalesReturnTermsSubs.Remove(sss);
            //            }

            //            foreach (SalesReturnPaymentSub ssss in CurrentSalesReturnPaymentSUb)
            //            {
            //                db.SalesReturnPaymentSubs.Remove(ssss);
            //            }

            //            foreach (SalesReturnSub ss in SalesReturnmain.SalesReturnSubs)
            //            {
            //                db.SalesReturnSubs.Add(ss);

            //                ///inventory calculation after add the data
            //                Inventory inv = db.Inventory.Where(x => x.ProductId == ss.ProductId && x.WareHouseId == ss.WarehouseId).FirstOrDefault();
            //                if (inv != null)
            //                {
            //                    inv.SalesReturnQty = inv.SalesReturnQty + ss.Qty;
            //                    //inv.CurrentStock = (inv.OpStock + inv.PurQty + inv.PurExcQty + inv.SalesReturnRetQty) - (inv.SalesReturnQty + inv.SalesReturnExcQty + inv.PurRetQty);
            //                    inv.CurrentStock = (inv.OpStock + inv.PurQty + inv.PurExcQty + inv.SalesReturnRetQty + inv.GoodsReceiveQty + inv.IssueRtnQty) - (inv.SalesReturnQty + inv.SalesReturnExcQty + inv.PurRetQty + inv.IssueQty + inv.GoodsRcvRtnQty);

            //                    db.Entry(inv).State = EntityState.Modified;
            //                }
            //            }
            //            ///terms subs
            //            if (SalesReturnmain.SalesReturnTermsSubs == null)
            //            { }
            //            else
            //            {

            //                foreach (SalesReturnTermsSub sss in SalesReturnmain.SalesReturnTermsSubs)
            //                {
            //                    db.SalesReturnTermsSubs.Add(sss);
            //                }
            //            }
            //            ///payments
            //            if (SalesReturnmain.SalesReturnPaymentSubs == null)
            //            { }
            //            else
            //            {

            //                foreach (SalesReturnPaymentSub ssss in SalesReturnmain.SalesReturnPaymentSubs)
            //                {
            //                    db.SalesReturnPaymentSubs.Add(ssss);
            //                }
            //            }


            //            db.Entry(SalesReturnmain).State = EntityState.Modified;
            //        }
            //        //Perform Save
            //        else
            //        {
            //            db.SalesReturnMains.Add(SalesReturnmain);


            //            ///inventory calculation after Added New data in Save mode
            //            foreach (SalesReturnSub ss in SalesReturnmain.SalesReturnSubs)
            //            {
            //                db.SalesReturnSubs.Add(ss);
            //                ////if no warehouse found then it will throw error
            //                //Inventory inv = db.Inventory.Where(x => x.ProductId == ss.ProductId && x.WareHouseId == ss.WarehouseId).FirstOrDefault();
            //                //if (inv != null) ///added by fahad for solving error if no ware house found then no update of the data
            //                //{
            //                //    inv.SalesReturnQty = inv.SalesReturnQty + ss.Qty;
            //                //    //inv.CurrentStock = (inv.OpStock + inv.PurQty + inv.PurExcQty + inv.SalesReturnRetQty) - (inv.SalesReturnQty + inv.SalesReturnExcQty + inv.PurRetQty);
            //                //    //inv.CurrentStock = (inv.OpStock + inv.PurQty + inv.PurExcQty + inv.SalesReturnRetQty + inv.GoodsReceiveQty + inv.IssueRtnQty) - (inv.SalesReturnQty + inv.SalesReturnExcQty + inv.PurRetQty + inv.IssueQty + inv.GoodsRcvRtnQty);

            //                //    db.Entry(inv).State = EntityState.Modified;
            //                //}

            //            }

            //        }

            //        db.SaveChanges();

            //        // If Sucess== 1 then Save/Update Successfull else there it has Exception
            //        return Json(new { Success = 1, SalesReturnID = SalesReturnmain.SalesReturnId, ex = "" });
            //    }
            //}
            //catch (Exception ex)
            //{

            //    // If Sucess== 0 then Unable to perform Save/Update Operation and send Exception to View as JSON
            //    return Json(new { Success = 0, ex = ex.Message.ToString() });
            //}

            //return Json(new { Success = 0, ex = new Exception("Unable to save").Message.ToString() });
        }

        public async Task<IActionResult> POSEdit(int? SalesReturnId)
        {
            if (SalesReturnId == null)
            {
                return NotFound();
            }

            SalesReturnModel SalesReturnmain = await salesreturnRepository.All()
            .Include(x => x.Items).ThenInclude(x => x.Product)
            //.Include(x => x.SalesReturnPayments).ThenInclude(x => x.vPaymentType)
            .Include(x => x.SalesReturnPayments).ThenInclude(x => x.vChartofAccounts)
            .Include(x => x.Items).ThenInclude(x => x.vWarehouse)
            .Where(x => x.Id == SalesReturnId).FirstOrDefaultAsync();

            if (SalesReturnmain.IsDelete == true)
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
            if (FromWarehousePermissionRepository.GetAllForDropDown().Count() > 0) { ViewBag.Warehouse = FromWarehousePermissionRepository.GetAllForDropDown(); } else { ViewBag.Warehouse = warehouseRepository.GetWarehouseLedgerHeadForDropDown(); }

            ViewBag.PaymentTypes = paymentTypeRepository.GetAllForDropDown();
            ViewBag.AccountHead = accountHeadRepository.GetCashBankHeadForDropDown();
            if (SalesReturnmain == null)
            {
                return NotFound();
            }

            //Call Create View
            return View("POSCreate", SalesReturnmain);
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

            SalesReturnModel SalesReturnmain = await salesreturnRepository.All()
            .Include(x => x.Items).ThenInclude(x => x.Product)
            //.Include(x => x.SalesReturnPayments).ThenInclude(x => x.vPaymentType)
            .Include(x => x.SalesReturnPayments).ThenInclude(x => x.vChartofAccounts)
            .Include(x => x.Items).ThenInclude(x => x.vWarehouse)
            .Where(x => x.Id == id).FirstOrDefaultAsync();

            if (SalesReturnmain == null)
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
            if (FromWarehousePermissionRepository.GetAllForDropDown().Count() > 0) { ViewBag.Warehouse = FromWarehousePermissionRepository.GetAllForDropDown(); } else { ViewBag.Warehouse = warehouseRepository.GetWarehouseLedgerHeadForDropDown(); }

            ViewBag.PaymentTypes = paymentTypeRepository.GetAllForDropDown();
            ViewBag.AccountHead = accountHeadRepository.GetCashBankHeadForDropDown();
            if (SalesReturnmain == null)
            {
                return NotFound();
            }

            //Call Create View
            return View("POSCreate", SalesReturnmain);
        }


        [HttpGet]
        public IActionResult EditSalesReturn(int salesreturnId)
        {

            ViewBag.ActionType = "Edit";
            ViewBag.customers = customerRepository.GetAllForDropDown();
            if (FromWarehousePermissionRepository.GetAllForDropDown().Count() > 0) { ViewBag.Warehouse = FromWarehousePermissionRepository.GetAllForDropDown(); } else { ViewBag.Warehouse = warehouseRepository.GetWarehouseLedgerHeadForDropDown(); }
            ViewBag.Category = categoryRepository.GetAllForDropDown();
            ViewBag.Unit = _unitRepository.GetAllForDropDown();

            ViewBag.DocType = _docTypeRepository.GetSalesDocForDropDown();
            ViewBag.SalesRep = _employeeRepository.GetAllForDropDown();
            ViewBag.Currency = _currencyRepository.GetCurrencyList();




            var batchlist = salesreturnItemRepository.AllSubData().Where(x => x.SalesReturnId == salesreturnId).Include(x => x.BatchSerialItems).Select(x => x.BatchSerialItems.Count()).FirstOrDefault();
            var batchlistArray = salesreturnItemRepository.AllSubData().Where(x => x.SalesReturnId == salesreturnId && x.SerialItem != null).Count();


            var batchdata = batchlist;

            var isSerialSalesReturn = false;
            isSerialSalesReturn = salesreturnRepository.All().Where(x => x.Id == salesreturnId).Select(x => x.isSerialSalesReturn).FirstOrDefault();



            //if (isSerialSalesReturn == true)
            //{
            return View("AddSalesReturnBySerialSearch", model: salesreturnId);

            //}
            //else if (batchdata > 0 && batchlistArray == 0 && isSerialSalesReturn == false)
            //{
            //    return View("AddSalesReturnerial", model: salesreturnId);
            //}
            //else if (batchlistArray > 0 && isSerialSalesReturn == false)
            //{
            //    return View("AddSalesReturnerialSide", model: salesreturnId);
            //}

            //return View("AddSalesReturn", model: salesreturnId);


            //var salesreturn = salesreturnRepository.All()
            //    .Include(x => x.Items)
            //    .SingleOrDefault(x => x.Id == salesreturnId);

            ////var salesreturn = salesreturnRepository.Find(salesreturnId);
            //if (salesreturn != null)
            //    return View("AddSalesReturn",model: salesreturn);
            //return RedirectToAction("index");

        }
        [HttpGet]
        public IActionResult EditSalesReturnerial(int salesreturnId)
        {

            ViewBag.ActionType = "Edit";
            ViewBag.customers = customerRepository.GetAllForDropDown();
            if (FromWarehousePermissionRepository.GetAllForDropDown().Count() > 0) { ViewBag.Warehouse = FromWarehousePermissionRepository.GetAllForDropDown(); } else { ViewBag.Warehouse = warehouseRepository.GetWarehouseLedgerHeadForDropDown(); }
            ViewBag.Category = categoryRepository.GetAllForDropDown();
            ViewBag.Unit = _unitRepository.GetAllForDropDown();

            ViewBag.DocType = _docTypeRepository.GetSalesDocForDropDown();
            ViewBag.SalesRep = _employeeRepository.GetAllForDropDown();
            ViewBag.Currency = _currencyRepository.GetCurrencyList();


            return View("AddSalesReturnerial", model: salesreturnId);



        }

        [HttpGet]
        public IActionResult EditSalesReturnSerialSide(int salesreturnId)
        {

            ViewBag.ActionType = "Edit";
            ViewBag.customers = customerRepository.GetAllForDropDown();
            if (FromWarehousePermissionRepository.GetAllForDropDown().Count() > 0) { ViewBag.Warehouse = FromWarehousePermissionRepository.GetAllForDropDown(); } else { ViewBag.Warehouse = warehouseRepository.GetWarehouseLedgerHeadForDropDown(); }
            ViewBag.Category = categoryRepository.GetAllForDropDown();
            ViewBag.Unit = _unitRepository.GetAllForDropDown();


            ViewBag.DocType = _docTypeRepository.GetSalesDocForDropDown();
            ViewBag.SalesRep = _employeeRepository.GetAllForDropDown();
            ViewBag.Currency = _currencyRepository.GetCurrencyList();

            return View("AddSalesReturnerialSide", model: salesreturnId);



        }



        [HttpPost]
        public IActionResult EditSalesReturn(SalesReturnModel model)
        {
            if (model != null)
            {
                var UserId = HttpContext.Session.GetInt32("UserId");
                var ComId = HttpContext.Session.GetInt32("ComId");

                var items = salesreturnItemRepository.AllSubData().Where(x => x.SalesReturnId == model.Id).ToList();
                if (items.Any())
                {
                    foreach (var item in items)
                    {
                        salesreturnItemRepository.Delete(item);
                    }
                }

                var salesreturn = salesreturnRepository.Find(model.Id);
                salesreturn.Notes = model.Notes;
                salesreturn.CustomerName = model.CustomerName;
                salesreturn.PhoneNo = model.PhoneNo;
                salesreturn.PrimaryAddress = model.PrimaryAddress;

                //salesreturn.PaymentMethod = model.PaymentMethod;
                salesreturn.SalesReturnCode = model.SalesReturnCode;
                salesreturn.CustomerId = model.CustomerId;
                salesreturn.Total = model.Total;
                salesreturn.SalesReturnDate = model.SalesReturnDate;
                salesreturn.Status = model.Status;
                salesreturn.Discount = model.Discount;

                salesreturn.ServiceCharge = model.ServiceCharge;
                salesreturn.Shipping = model.Shipping;
                salesreturn.TotalVat = model.TotalVat;

                salesreturn.GrandTotal = model.GrandTotal;

                //add again
                foreach (var item in model.Items)
                {
                    salesreturn.Items.Add(new SalesReturnItemsModel
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
                salesreturnRepository.Update(salesreturn, model.Id);



                TempData["Message"] = "Data Update Successfully";
                TempData["Status"] = "2";
                tranlog.TransactionLog(RouteData.Values["controller"].ToString(), RouteData.Values["action"].ToString(), TempData["Message"].ToString(), model.Id.ToString(), "Update", model.SalesReturnCode.ToString());

                return Json(new { error = false, message = "SalesReturn updated successfully" });
            }
            return Json(new { error = true, message = "failed to update SalesReturn" });
        }

        public IActionResult DeleteSalesReturn(int salesreturnId)
        {

            var UserId = HttpContext.Session.GetInt32("UserId");
            var ComId = HttpContext.Session.GetInt32("ComId");

            SqlParameter[] sqlParameter1 = new SqlParameter[4];
            sqlParameter1[0] = new SqlParameter("@ComId", ComId);
            sqlParameter1[1] = new SqlParameter("@Id", salesreturnId);
            sqlParameter1[2] = new SqlParameter("@ProcessFor", "SalesReturn");
            sqlParameter1[3] = new SqlParameter("@SaveUpdateDelete", "Delete");
            Helper.ExecProc("prcSerialProcess", sqlParameter1);


            //return Json(new { Success = 1, error = false, message = "Date Update successfully" });

            var model = this.salesreturnRepository.Find(salesreturnId);
            salesreturnRepository.Delete(model);


            TempData["Message"] = "Data Delete Successfully";
            TempData["Status"] = "3";
            tranlog.TransactionLog(RouteData.Values["controller"].ToString(), RouteData.Values["action"].ToString(), TempData["Message"].ToString(), model.Id.ToString(), "Delete", model.SalesReturnCode);



            return RedirectToAction("index");
        }



        [AllowAnonymous]

        public ActionResult SalesReturnReport(int salesreturnId)
        {
            var UserId = HttpContext.Session.GetInt32("UserId");
            var ComId = HttpContext.Session.GetInt32("ComId");
            var weburl = HttpContext.Session.GetString("weburl");
            var ReportStyle = HttpContext.Session.GetString("SalesReportStyle");


            string reportname = "rptInvoice";
            var filename = "Invoice_";


            if (ReportStyle.ToString().Length > 0)
            {
                reportname = "rptInvoice_" + ReportStyle.ToString();
            }


            HttpContext.Session.SetString("ReportQuery", "Exec  [rptSalesReturn] '" + salesreturnId + "','" + ComId + "', '" + weburl + "' ,'Sales Return' ");
            HttpContext.Session.SetString("ReportPath", "~/ReportViewer/POS/" + reportname + ".rdlc");
            HttpContext.Session.SetString("PrintFileName", filename.Replace(".", "").Replace(" ", "").Replace(",", "").Replace("\"", ""));


            //postData.Add(1, new subReport("rptInvoice_Terms", "", "DataSet1", "Exec " + AppData.AppData.dbGTCommercial.ToString() + ".dbo.rptInvoice_Terms '" + id + "','" + Session["comid"].ToString() + "',''"));

            //postData.Add(1, new subReport("rptInvoice_BankDetails", "", "DataSet1", "Exec rptInvoice_BankDetails '" + salesreturnId + "'," + ComId + ",'" + AppData.AppData.AppPath.ToString() + "'"));
            if (reportname.ToLower().Contains("pos"))
            {
                postData.Add(1, new subReport("rptInvoice_POS_PM", "", "DataSet1", "Exec rptSalesReturn_PM '" + salesreturnId + "'," + ComId + ""));
            }
            else
            {
                postData.Add(1, new subReport("rptInvoice_PM", "", "DataSet1", "Exec rptSalesReturn_PM '" + salesreturnId + "'," + ComId + ""));
            }

            postData.Add(2, new subReport("rptInvoice_Terms", "", "DataSet1", "Exec rptInvoice_Terms '" + salesreturnId + "'," + ComId + ""));
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


            ViewBag.Customer = customerRepository.GetAllForDropDown();
            ViewBag.Supplier = supplierRepository.GetAllForDropDown();


            ViewBag.CreditAccount = accountHeadRepository.GetCashBankHeadForDropDown();
            ViewBag.AccountReceiveType = accountHeadRepository.GetCashBankHeadForDropDown();

            ViewBag.Category = categoryRepository.GetAllForDropDown();




            return View();
        }


        [HttpGet]
        [AllowAnonymous]
        public JsonResult GetSalesReturn(int salesreturnId)
        {
            try
            {



                SalesReturnModel SalesReturn = salesreturnRepository.All().Include(x => x.SalesInfo).FirstOrDefault(x => x.Id == salesreturnId && x.isPosted == false);
                if (SalesReturn == null)
                {
                    return Json("No Data Found");
                }

                //SalesReturn.Items = salesreturnItemRepository.AllSubData().Where(x => x.SalesReturnId == SalesReturn.Id).ToList();
                SalesReturn.Items = salesreturnItemRepository.AllSubData()
                    .Include(x => x.Product).Include(x => x.vWarehouse)
                    .Include(x => x.BatchSerialItems)
                    .Where(x => x.SalesReturnId == SalesReturn.Id).ToList();

                SalesReturn.ExchangeItems = salesExchangeItemRepository.AllSubData()
                .Include(x => x.Product).Include(x => x.vWarehouse)
                .Include(x => x.BatchSerialItems)
                .Where(x => x.SalesReturnId == SalesReturn.Id).ToList();


                SalesReturn.SalesReturnPayments = SalesReturnPaymentRepository.AllSubData()
                //.Include(x => x.vPaymentType)
                .Include(x => x.vChartofAccounts)
                .Where(x => x.SalesReturnId == SalesReturn.Id).ToList();


                //var batchlistArray = salesreturnItemRepository.AllSubData().Where(x => x.SalesReturnId == salesreturnId && x.SerialItem.Length != 0).Count();

                //if (batchlistArray != null)
                //{
                foreach (var item in SalesReturn.Items)
                {
                    if (item.SerialItem != null)
                    {
                        var serialitems = item.SerialItem.Split(',');
                        //serialitems.Reverse();

                        item.SerialItemArray = serialitems;
                    }

                }


                foreach (var item in SalesReturn.ExchangeItems)
                {
                    if (item.SerialItem != null)
                    {
                        var serialitems = item.SerialItem.Split(',');
                        //serialitems.Reverse();

                        item.SerialItemArray = serialitems;
                    }

                }
                //}



                //SalesReturnItemsModel a = new SalesReturnItemsModel { Name = "abc", Amount = 2.5, Id = 1, IsDelete = false, Price = 2.5, Quantity = 1, SalesReturnId = 5};
                //SalesReturn.Items.Add(a);
                return Json(SalesReturn);
                //return Json(new { Success = 1, SalesReturn = SalesReturn, ex = "Data Load Successfully" });
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

        [AllowAnonymous]
        public JsonResult GetPaymentTypes()
        {
            return Json(paymentTypeRepository.GetAllForDropDownTrading());
        }

        public IActionResult POSCreate()
        {
            try
            {
                SalesReturnModel abc = new SalesReturnModel();
                abc.SalesReturnDate = DateTime.Now.Date;

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
                if (FromWarehousePermissionRepository.GetAllForDropDown().Count() > 0) { ViewBag.Warehouse = FromWarehousePermissionRepository.GetAllForDropDown(); } else { ViewBag.Warehouse = warehouseRepository.GetWarehouseLedgerHeadForDropDown(); }

                ViewBag.PaymentTypes = paymentTypeRepository.GetAllForDropDown();
                ViewBag.AccountHead = accountHeadRepository.GetCashBankHeadForDropDown();

                //////////////ViewBag.SalesReturnType = new SelectList(POS.GetSalesReturnType(), "SalesReturnTypeId", "TypeShortName");
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
        public JsonResult CustomerInfo(int id)
        {
            try
            {
                CustomerModel customer = customerRepository.All().Where(y => y.Id == id).SingleOrDefault();
                return Json(customer);
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