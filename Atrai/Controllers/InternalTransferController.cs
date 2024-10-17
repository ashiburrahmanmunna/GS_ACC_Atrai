using Atrai.Data.Interfaces;
using Atrai.Model.Core.Entity;
using Atrai.Services;
using DataTablesParser;
using Microsoft.AspNetCore.Authorization;
//using Atrai.Data.Reports;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Atrai.Controllers
{
    [Authorize]
    [OverridableAuthorize]
    public class InternalTransferController : Controller
    {
        public TransactionLogRepository tranlog { get; }

        private readonly ICustomerRepository customerRepository;
        private readonly ISupplierRepository supplierRepository;

        private readonly IInternalTransferRepository InternalTransferRepository;
        private readonly IInternalTransferItemsRepository InternalTransferItemRepository;

        private readonly IInternalTransferBatchItemsRepository _InternalTransferBatchItemRepository;

        private readonly IPurchaseRepository purchaseRepository;
        private readonly IPurchaseItemsRepository purchaseItemsRepository;
        private readonly IInternetUserRepository internetUserRepository;

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

        //private readonly IpaymentTypesRepository paymentTypesRepository;


        public static string ExpressionParameterizationException { get; }
        Dictionary<int, dynamic> postData = new Dictionary<int, dynamic>();


        public InternalTransferController(ICustomerRepository customerRepository, IInternalTransferRepository InternalTransferRepository,
            ISupplierRepository supplierRepository, IPurchaseRepository purchaseRepository,

            IInternalTransferItemsRepository InternalTransferItemRepository, IInternalTransferBatchItemsRepository InternalTransferBatchItemRepository,

            IPurchaseItemsRepository purchaseItemsRepository, IPurchasePaymentRepository purchasePaymentRepository, IInternetUserRepository internetUserRepository,

            IStoreSettingRepository storeSettingRepository,
            ICategoryRepository categoryRepository, IUnitRepository unitRepository, IProductRepository productRepository,
            IWarehouseRepository warehouseRepository, IFromWarehousePermissionRepository FromWarehousePermissionRepository, IToWarehousePermissionRepository ToWarehousePermissionRepository, IAccountHeadRepository accountHeadRepository,
            IPaymentTypeRepository paymentTypeRepository, ICompanyRepository companyRepository,
            IConfiguration configuration, TransactionLogRepository tranlogRepository)
        {
            this.configuration = configuration;

            this.customerRepository = customerRepository;
            this.InternalTransferRepository = InternalTransferRepository;
            this.InternalTransferItemRepository = InternalTransferItemRepository;
            this._InternalTransferBatchItemRepository = InternalTransferBatchItemRepository;

            this.supplierRepository = supplierRepository;
            this.purchaseRepository = purchaseRepository;
            this.purchaseItemsRepository = purchaseItemsRepository;
            this.internetUserRepository = internetUserRepository;

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

        }

        public IActionResult Index()
        {
            ViewBag.Customers = customerRepository.GetAllForDropDown();

            return View();
        }


        [HttpGet]
        public IActionResult AddInternalTransfer()
        {

            ViewBag.ActionType = "Create";
            int InternalTransferId = 0;
            //ViewBag.customers = customerRepository.GetAllForDropDown();
            if (FromWarehousePermissionRepository.GetAllForDropDown().Count() > 0) { ViewBag.FromWarehouse = FromWarehousePermissionRepository.GetAllForDropDown(); } else { ViewBag.FromWarehouse = warehouseRepository.GetWarehouseLedgerHeadForDropDown(); }
            if (ToWarehousePermissionRepository.GetAllForDropDown().Count() > 0) { ViewBag.ToWarehouse = ToWarehousePermissionRepository.GetAllForDropDown(); } else { ViewBag.ToWarehouse = warehouseRepository.GetWarehouseLedgerHeadForDropDown(); }

            ViewBag.Category = categoryRepository.GetAllForDropDown();
            ViewBag.Unit = _unitRepository.GetAllForDropDown();

            return View(model: InternalTransferId);
        }


        public class InternalTransferResultList : InternalTransferModel
        {
            public string? StatusPosted { get; set; }
            public string? InternalTransferDateString { get; set; }
        }



        [AllowAnonymous]
        public IActionResult GetInternalTransferList(string FromDate, string ToDate, int? InternetUserId, int isAll)
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

                var InternalTransferlist = InternalTransferRepository.All();




                if (y.ToString().Length > 0)
                {

                }
                else
                {
                    if (InternetUserId == null)
                    {
                        InternalTransferlist = InternalTransferlist.Where(p => p.InternalTransferDate >= dtFrom && p.InternalTransferDate <= dtTo);

                    }
                    else
                    {
                        if (InternetUserId == 1)
                        {
                            InternalTransferlist = InternalTransferlist.Where(p => p.InternalTransferDate >= dtFrom && p.InternalTransferDate <= dtTo);
                        }
                        else
                        {
                            InternalTransferlist = InternalTransferlist.Where(p => (p.InternalTransferDate >= dtFrom && p.InternalTransferDate <= dtTo) && p.InternetUserId == InternetUserId);
                        }
                    }
                }


                var query = from e in InternalTransferlist
                            select new InternalTransferResultList
                            {
                                Id = e.Id,
                                InternalTransferCode = e.InternalTransferCode,
                                InternalTransferDate = e.InternalTransferDate,
                                InternalTransferDateString = e.InternalTransferDate.ToString("dd-MMM-yy"),

                                ReferanceOne = (e.ReferanceOne.Length == 0 || e.ReferanceOne == null) ? e.InternetUserList.UserId : e.InternetUserList.UserId + " - " + e.ReferanceOne,
                                //ReferanceOne = e.ReferanceOne,
                                ReferanceTwo = e.ReferanceTwo,
                                Notes = e.Notes,
                                isPosted = e.isPosted,
                                StatusPosted = e.isPosted != false ? "Posted" : "Not Posted"
                            };


                var parser = new Parser<InternalTransferResultList>(Request.Form, query);
                return Json(parser.Parse());


            }
            catch (Exception ex)
            {
                return Json(new { Success = "0", error = ex.Message });
                //throw ex;
            }

        }


        [HttpPost]
        public IActionResult AddInternalTransfer([FromBody] InternalTransferModel model)
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



                        InternalTransferRepository.Update(model, model.Id);
                        foreach (InternalTransferItemsModel item in model.Items)
                        {

                            if (item.Id > 0)
                            {
                                if (item.IsDelete == true)
                                {
                                    int z = item.Id;
                                    InternalTransferItemRepository.Delete(item);

                                }
                                else
                                {
                                    if (item.IsTransaction == true)//item.IsDelete == false &&  
                                    {

                                        foreach (InternalTransferBatchItemsModel batchitem in item.BatchSerialItems)
                                        {
                                            if (batchitem.Id > 0)
                                            {
                                                if (batchitem.IsDelete == true)
                                                {
                                                    int z = batchitem.Id;
                                                    _InternalTransferBatchItemRepository.Delete(batchitem);

                                                }
                                                else
                                                {
                                                    if (batchitem.IsTransaction == true)
                                                    {
                                                        batchitem.ComId = ComId.GetValueOrDefault();
                                                        _InternalTransferBatchItemRepository.Update(batchitem, batchitem.Id);
                                                    }
                                                }
                                            }
                                            else if (batchitem.Id == 0 && batchitem.IsDelete == false)
                                            {
                                                batchitem.ComId = ComId.GetValueOrDefault();
                                                _InternalTransferBatchItemRepository.Insert(batchitem);
                                            }


                                        }

                                        InternalTransferItemRepository.Update(item, item.Id);

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
                                    InternalTransferItemRepository.Insert(item);
                                }
                            }
                        }

                        TempData["Message"] = "Data Update Successfully";
                        TempData["Status"] = "2";
                        tranlog.TransactionLog(RouteData.Values["controller"].ToString(), RouteData.Values["action"].ToString(), TempData["Message"].ToString(), model.Id.ToString(), "Update", model.InternalTransferCode);

                        return Json(new { error = false, message = "Purchase updated successfully" });
                    }
                    else
                    {

                        //var UserId = HttpContext.Session.GetInt32("UserId");
                        //var ComId = HttpContext.Session.GetInt32("ComId");

                        foreach (var item in model.Items)
                        {
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

                        InternalTransferRepository.Insert(model);

                        TempData["Message"] = "Data Save Successfully";
                        TempData["Status"] = "1";
                        tranlog.TransactionLog(RouteData.Values["controller"].ToString(), RouteData.Values["action"].ToString(), TempData["Message"].ToString(), model.Id.ToString(), "Create", model.InternalTransferCode);

                        return Json(new { error = false, message = "Purchase saved successfully" });
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



        [HttpGet]
        public IActionResult EditInternalTransfer(int InternalTransferId)
        {

            ViewBag.ActionType = "Edit";
            ViewBag.customers = customerRepository.GetAllForDropDown();
            if (FromWarehousePermissionRepository.GetAllForDropDown().Count() > 0) { ViewBag.FromWarehouse = FromWarehousePermissionRepository.GetAllForDropDown(); } else { ViewBag.FromWarehouse = warehouseRepository.GetWarehouseLedgerHeadForDropDown(); }
            if (ToWarehousePermissionRepository.GetAllForDropDown().Count() > 0) { ViewBag.ToWarehouse = ToWarehousePermissionRepository.GetAllForDropDown(); } else { ViewBag.ToWarehouse = warehouseRepository.GetWarehouseLedgerHeadForDropDown(); }

            ViewBag.Category = categoryRepository.GetAllForDropDown();
            ViewBag.Unit = _unitRepository.GetAllForDropDown();
            return View("AddInternalTransfer", model: InternalTransferId);



        }



        [HttpPost]
        public IActionResult EditInternalTransfer(InternalTransferModel model)
        {
            if (model != null)
            {
                var UserId = HttpContext.Session.GetInt32("UserId");
                var ComId = HttpContext.Session.GetInt32("ComId");

                var items = InternalTransferItemRepository.AllSubData().Where(x => x.InternalTransferId == model.Id).ToList();
                if (items.Any())
                {
                    foreach (var item in items)
                    {
                        InternalTransferItemRepository.Delete(item);
                    }
                }

                var InternalTransfer = InternalTransferRepository.Find(model.Id);
                InternalTransfer.Notes = model.Notes;
                InternalTransfer.ReferanceOne = model.ReferanceOne;
                InternalTransfer.ReferanceTwo = model.ReferanceTwo;

                InternalTransfer.InternalTransferCode = model.InternalTransferCode;
                InternalTransfer.InternalTransferDate = model.InternalTransferDate;

                //add again
                foreach (var item in model.Items)
                {
                    InternalTransfer.Items.Add(new InternalTransferItemsModel
                    {
                        FromWarehouseId = item.FromWarehouseId,
                        ToWarehouseId = item.ToWarehouseId,
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
                InternalTransferRepository.Update(InternalTransfer, model.Id);



                TempData["Message"] = "Data Update Successfully";
                TempData["Status"] = "2";
                tranlog.TransactionLog(RouteData.Values["controller"].ToString(), RouteData.Values["action"].ToString(), TempData["Message"].ToString(), model.Id.ToString(), "Update", model.InternalTransferCode.ToString());

                return Json(new { error = false, message = "InternalTransfer updated successfully" });
            }
            return Json(new { error = true, message = "failed to update InternalTransfer" });
        }

        public IActionResult DeleteInternalTransfer(int InternalTransferId)
        {
            var model = this.InternalTransferRepository.Find(InternalTransferId);
            InternalTransferRepository.Delete(model);


            TempData["Message"] = "Data Delete Successfully";
            TempData["Status"] = "3";
            tranlog.TransactionLog(RouteData.Values["controller"].ToString(), RouteData.Values["action"].ToString(), TempData["Message"].ToString(), model.Id.ToString(), "Delete", model.InternalTransferCode);



            return RedirectToAction("index");
        }
        [AllowAnonymous]

        public ActionResult InternalTransferReport(int InternalTransferId)
        {
            var UserId = HttpContext.Session.GetInt32("UserId");
            var ComId = HttpContext.Session.GetInt32("ComId");
            var weburl = HttpContext.Session.GetString("weburl");



            string reportname = "rptInternalTransfer";
            var filename = "InternalTransfer_";
            //string apppath = "";

            HttpContext.Session.SetString("ReportQuery", "Exec  [rptInternalTransfer] '" + InternalTransferId + "','" + ComId + "', '" + weburl + "'");
            HttpContext.Session.SetString("ReportPath", "~/ReportViewer/POS/" + reportname + ".rdlc");
            HttpContext.Session.SetString("PrintFileName", filename.Replace(".", "").Replace(" ", "").Replace(",", "").Replace("\"", ""));


            ////postData.Add(1, new subReport("rptInternalTransfer_Terms", "", "DataSet1", "Exec " + AppData.AppData.dbGTCommercial.ToString() + ".dbo.rptInternalTransfer_Terms '" + id + "','" + Session["comid"].ToString() + "',''"));

            ////postData.Add(1, new subReport("rptInternalTransfer_BankDetails", "", "DataSet1", "Exec rptInternalTransfer_BankDetails '" + InternalTransferId + "'," + ComId + ",'" + AppData.AppData.AppPath.ToString() + "'"));
            //postData.Add(2, new subReport("rptInternalTransfer_PM", "", "DataSet1", "Exec rptInternalTransfer_PM '" + InternalTransferId + "'," + ComId + ""));


            ////clsReport.rptList.Add(new subReport("rptInternalTransfer_Terms", "", "DataSet1", "Exec " + AppData.AppData.dbGTCommercial.ToString() + ".dbo.rptInternalTransfer_Terms '" + id + "'," + Session["comid"].ToString() + ",'" + AppData.AppData.AppPath.ToString() + "'"));

            //HttpContext.Session.SetObject("rptList", postData);


            return RedirectToAction("Index", "ReportViewer");
        }


        [HttpGet]
        public IActionResult Report()
        {
            ViewBag.ActionType = "Report";
            ViewBag.Product = productRepository.GetAllProductForDropDown();
            if (FromWarehousePermissionRepository.GetAllForDropDown().Count() > 0) { ViewBag.FromWarehouse = FromWarehousePermissionRepository.GetAllForDropDown(); } else { ViewBag.FromWarehouse = warehouseRepository.GetWarehouseLedgerHeadForDropDown(); }
            if (ToWarehousePermissionRepository.GetAllForDropDown().Count() > 0) { ViewBag.ToWarehouse = ToWarehousePermissionRepository.GetAllForDropDown(); } else { ViewBag.ToWarehouse = warehouseRepository.GetWarehouseLedgerHeadForDropDown(); }

            ViewBag.Customer = customerRepository.GetAllForDropDown();
            ViewBag.Supplier = supplierRepository.GetAllForDropDown();


            ViewBag.AccountPayType = accountHeadRepository.GetCashBankHeadForDropDown();
            ViewBag.AccountReceiveType = accountHeadRepository.GetCashBankHeadForDropDown();

            ViewBag.Category = categoryRepository.GetAllForDropDown();




            return View();
        }


        [HttpGet]
        [AllowAnonymous]
        public JsonResult GetInternalTransfer(int InternalTransferId)
        {
            try
            {



                InternalTransferModel InternalTransfer = InternalTransferRepository.All().FirstOrDefault(x => x.Id == InternalTransferId && x.isPosted == false);
                if (InternalTransfer == null)
                {
                    return Json("No Data Found");
                }

                //InternalTransfer.Items = InternalTransferItemRepository.AllSubData().Where(x => x.InternalTransferId == InternalTransfer.Id).ToList();
                InternalTransfer.Items = InternalTransferItemRepository.AllSubData()
                    .Include(x => x.Product)
                    .Include(x => x.FromWarehouse).Include(x => x.ToWarehouse)
                    .Include(x => x.BatchSerialItems)
                    .Where(x => x.InternalTransferId == InternalTransfer.Id).ToList();


                //var batchlistArray = InternalTransferItemRepository.AllSubData().Where(x => x.InternalTransferId == InternalTransferId && x.SerialItem.Length != 0).Count();

                //if (batchlistArray != null)
                //{
                foreach (var item in InternalTransfer.Items)
                {
                    if (item.SerialItem != null)
                    {
                        var serialitems = item.SerialItem.Split(',');
                        //serialitems.Reverse();

                        item.SerialItemArray = serialitems;
                    }

                }
                //}



                //InternalTransferItemsModel a = new InternalTransferItemsModel { Name = "abc", Amount = 2.5, Id = 1, IsDelete = false, Price = 2.5, Quantity = 1, InternalTransferId = 5};
                //InternalTransfer.Items.Add(a);
                return Json(InternalTransfer);
                //return Json(new { Success = 1, InternalTransfer = InternalTransfer, ex = "Data Load Successfully" });
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
            return Json(accountHeadRepository.GetCashBankHeadForDropDown());
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
            public double InternalTransferPrice { get; set; }
            public string? BlankData { get; set; }
            public string? ImagePath { get; set; }
        }
        [HttpPost]
        [AllowAnonymous]
        public JsonResult CustomerInfo(int id)
        {
            try
            {
                InternetUserModel customer = internetUserRepository.All().Where(y => y.Id == id).SingleOrDefault();
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
                                    InternalTransferPrice = e.Price,
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
                                    InternalTransferPrice = e.Price,
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