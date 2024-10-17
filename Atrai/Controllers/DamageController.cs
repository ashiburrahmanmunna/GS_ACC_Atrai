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
    public class DamageController : Controller
    {
        public TransactionLogRepository tranlog { get; }

        private readonly ICustomerRepository customerRepository;
        private readonly ISupplierRepository supplierRepository;

        private readonly IDamageRepository DamageRepository;
        private readonly IDamageItemsRepository DamageItemRepository;

        private readonly IDamageBatchItemsRepository _DamageBatchItemRepository;

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


        public DamageController(ICustomerRepository customerRepository, IDamageRepository DamageRepository,
            ISupplierRepository supplierRepository, IPurchaseRepository purchaseRepository,

            IDamageItemsRepository DamageItemRepository, IDamageBatchItemsRepository DamageBatchItemRepository,

             IPurchaseItemsRepository purchaseItemsRepository, IPurchasePaymentRepository purchasePaymentRepository, IInternetUserRepository internetUserRepository,

            IStoreSettingRepository storeSettingRepository,
            ICategoryRepository categoryRepository, IUnitRepository unitRepository, IProductRepository productRepository,
            IWarehouseRepository warehouseRepository, IFromWarehousePermissionRepository FromWarehousePermissionRepository, IToWarehousePermissionRepository ToWarehousePermissionRepository, IAccountHeadRepository accountHeadRepository,
            IPaymentTypeRepository paymentTypeRepository, ICompanyRepository companyRepository,
            IConfiguration configuration, TransactionLogRepository tranlogRepository)
        {
            this.configuration = configuration;

            this.customerRepository = customerRepository;
            this.DamageRepository = DamageRepository;
            this.DamageItemRepository = DamageItemRepository;
            this._DamageBatchItemRepository = DamageBatchItemRepository;

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

            this.accountHeadRepository = accountHeadRepository;
            this.paymentTypeRepository = paymentTypeRepository;
            tranlog = tranlogRepository;

        }

        public IActionResult Index()
        {
            ViewBag.FromDate = DateTime.Now.Date;
            ViewBag.ToDate = DateTime.Now.Date;

            ViewBag.Customers = customerRepository.GetAllForDropDown();

            return View();
        }


        [HttpGet]
        public IActionResult AddDamage()
        {

            ViewBag.ActionType = "Create";
            int DamageId = 0;
            //ViewBag.customers = customerRepository.GetAllForDropDown();
            if (FromWarehousePermissionRepository.GetAllForDropDown().Count() > 0) { ViewBag.Warehouse = FromWarehousePermissionRepository.GetAllForDropDown(); } else { ViewBag.Warehouse = warehouseRepository.GetWarehouseLedgerHeadForDropDown(); }
            ViewBag.Category = categoryRepository.GetAllForDropDown();
            ViewBag.Unit = _unitRepository.GetAllForDropDown();

            return View(model: DamageId);
        }


        public class DamageResultList : DamageModel
        {
            public string? StatusPosted { get; set; }
            public string? DamageDateString { get; set; }
        }



        [AllowAnonymous]
        public IActionResult GetDamageList(string FromDate, string ToDate, int? InternetUserId, int isAll)
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

                var Damagelist = DamageRepository.All();




                if (y.ToString().Length > 0)
                {

                }
                else
                {
                    if (InternetUserId == null)
                    {
                        Damagelist = Damagelist.Where(p => p.DamageDate >= dtFrom && p.DamageDate <= dtTo);

                    }
                    else
                    {
                        if (InternetUserId == 1)
                        {
                            Damagelist = Damagelist.Where(p => p.DamageDate >= dtFrom && p.DamageDate <= dtTo);
                        }
                        else
                        {
                            Damagelist = Damagelist.Where(p => (p.DamageDate >= dtFrom && p.DamageDate <= dtTo) && p.InternetUserId == InternetUserId);
                        }
                    }
                }


                var query = from e in Damagelist.Include(x => x.Items).ThenInclude(x => x.Product).ThenInclude(x => x.Category)
                            select new DamageResultList
                            {
                                Id = e.Id,
                                DamageCode = e.DamageCode,
                                DamageDate = e.DamageDate,
                                DamageDateString = e.DamageDate.ToString("dd-MMM-yy"),

                                ReferanceOne = (e.ReferanceOne.Length == 0 || e.ReferanceOne == null) ? e.InternetUserList.UserId : e.InternetUserList.UserId + " - " + e.ReferanceOne,
                                //ReferanceOne = e.ReferanceOne,
                                ReferanceTwo = e.ReferanceTwo,
                                Notes = e.Notes,
                                isPosted = e.isPosted,
                                StatusPosted = e.isPosted != false ? "Posted" : "Not Posted",
                                Items = e.Items.Where(x => x.IsDelete == false).ToList()
                            };


                var parser = new Parser<DamageResultList>(Request.Form, query);
                return Json(parser.Parse());


            }
            catch (Exception ex)
            {
                return Json(new { Success = "0", error = ex.Message });
                //throw ex;
            }

        }


        [HttpPost]
        public IActionResult AddDamage([FromBody] DamageModel model)
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



                        DamageRepository.Update(model, model.Id);
                        foreach (DamageItemsModel item in model.Items)
                        {

                            if (item.Id > 0)
                            {
                                if (item.IsDelete == true)
                                {
                                    int z = item.Id;
                                    DamageItemRepository.Delete(item);

                                }
                                else
                                {
                                    if (item.IsTransaction == true)//item.IsDelete == false &&  
                                    {

                                        foreach (DamageBatchItemsModel batchitem in item.BatchSerialItems)
                                        {
                                            if (batchitem.Id > 0)
                                            {
                                                if (batchitem.IsDelete == true)
                                                {
                                                    int z = batchitem.Id;
                                                    _DamageBatchItemRepository.Delete(batchitem);

                                                }
                                                else
                                                {
                                                    if (batchitem.IsTransaction == true)
                                                    {
                                                        batchitem.ComId = ComId.GetValueOrDefault();
                                                        _DamageBatchItemRepository.Update(batchitem, batchitem.Id);
                                                    }
                                                }
                                            }
                                            else if (batchitem.Id == 0 && batchitem.IsDelete == false)
                                            {
                                                batchitem.ComId = ComId.GetValueOrDefault();
                                                _DamageBatchItemRepository.Insert(batchitem);
                                            }


                                        }

                                        DamageItemRepository.Update(item, item.Id);

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
                                    DamageItemRepository.Insert(item);
                                }
                            }
                        }

                        TempData["Message"] = "Data Update Successfully";
                        TempData["Status"] = "2";
                        tranlog.TransactionLog(RouteData.Values["controller"].ToString(), RouteData.Values["action"].ToString(), TempData["Message"].ToString(), model.Id.ToString(), "Update", model.DamageCode);

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

                        DamageRepository.Insert(model);

                        TempData["Message"] = "Data Save Successfully";
                        TempData["Status"] = "1";
                        tranlog.TransactionLog(RouteData.Values["controller"].ToString(), RouteData.Values["action"].ToString(), TempData["Message"].ToString(), model.Id.ToString(), "Create", model.DamageCode);

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
        public IActionResult EditDamage(int DamageId)
        {

            ViewBag.ActionType = "Edit";
            ViewBag.customers = customerRepository.GetAllForDropDown();
            if (FromWarehousePermissionRepository.GetAllForDropDown().Count() > 0) { ViewBag.Warehouse = FromWarehousePermissionRepository.GetAllForDropDown(); } else { ViewBag.Warehouse = warehouseRepository.GetWarehouseLedgerHeadForDropDown(); }
            ViewBag.Category = categoryRepository.GetAllForDropDown();
            ViewBag.Unit = _unitRepository.GetAllForDropDown();
            return View("AddDamage", model: DamageId);



        }



        [HttpPost]
        public IActionResult EditDamage(DamageModel model)
        {
            if (model != null)
            {
                var UserId = HttpContext.Session.GetInt32("UserId");
                var ComId = HttpContext.Session.GetInt32("ComId");

                var items = DamageItemRepository.AllSubData().Where(x => x.DamageId == model.Id).ToList();
                if (items.Any())
                {
                    foreach (var item in items)
                    {
                        DamageItemRepository.Delete(item);
                    }
                }

                var Damage = DamageRepository.Find(model.Id);
                Damage.Notes = model.Notes;
                Damage.ReferanceOne = model.ReferanceOne;
                Damage.ReferanceTwo = model.ReferanceTwo;

                Damage.DamageCode = model.DamageCode;
                Damage.DamageDate = model.DamageDate;

                //add again
                foreach (var item in model.Items)
                {
                    Damage.Items.Add(new DamageItemsModel
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
                DamageRepository.Update(Damage, model.Id);



                TempData["Message"] = "Data Update Successfully";
                TempData["Status"] = "2";
                tranlog.TransactionLog(RouteData.Values["controller"].ToString(), RouteData.Values["action"].ToString(), TempData["Message"].ToString(), model.Id.ToString(), "Update", model.DamageCode.ToString());

                return Json(new { error = false, message = "Damage updated successfully" });
            }
            return Json(new { error = true, message = "failed to update Damage" });
        }

        public IActionResult DeleteDamage(int DamageId)
        {
            var model = this.DamageRepository.Find(DamageId);
            DamageRepository.Delete(model);


            TempData["Message"] = "Data Delete Successfully";
            TempData["Status"] = "3";
            tranlog.TransactionLog(RouteData.Values["controller"].ToString(), RouteData.Values["action"].ToString(), TempData["Message"].ToString(), model.Id.ToString(), "Delete", model.DamageCode);



            return RedirectToAction("index");
        }

        [AllowAnonymous]

        public ActionResult DamageReport(int DamageId)
        {
            var UserId = HttpContext.Session.GetInt32("UserId");
            var ComId = HttpContext.Session.GetInt32("ComId");
            string weburl = configuration.GetSection("hostimage").Value;
            HttpContext.Session.SetString("weburl", weburl);



            string reportname = "rptDamage";
            var filename = "Damage_";
            //string apppath = "";

            HttpContext.Session.SetString("ReportQuery", "Exec  [rptDamage] '" + DamageId + "','" + ComId + "', '" + weburl + "'");
            HttpContext.Session.SetString("ReportPath", "~/ReportViewer/POS/" + reportname + ".rdlc");
            HttpContext.Session.SetString("PrintFileName", filename.Replace(".", "").Replace(" ", "").Replace(",", "").Replace("\"", ""));


            //postData.Add(1, new subReport("rptInvoice_Terms", "", "DataSet1", "Exec " + AppData.AppData.dbGTCommercial.ToString() + ".dbo.rptInvoice_Terms '" + id + "','" + Session["comid"].ToString() + "',''"));

            //postData.Add(1, new subReport("rptInvoice_BankDetails", "", "DataSet1", "Exec rptInvoice_BankDetails '" + DamageId + "'," + ComId + ",'" + AppData.AppData.AppPath.ToString() + "'"));
            //postData.Add(2, new subReport("rptInvoice_PM", "", "DataSet1", "Exec rptInvoice_PM '" + DamageId + "'," + ComId + ""));


            //clsReport.rptList.Add(new subReport("rptInvoice_Terms", "", "DataSet1", "Exec " + AppData.AppData.dbGTCommercial.ToString() + ".dbo.rptInvoice_Terms '" + id + "'," + Session["comid"].ToString() + ",'" + AppData.AppData.AppPath.ToString() + "'"));

            //HttpContext.Session.SetObject("rptList", postData);


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


            ViewBag.AccountPayType = accountHeadRepository.GetCashBankHeadForDropDown();
            ViewBag.AccountReceiveType = accountHeadRepository.GetCashBankHeadForDropDown();

            ViewBag.Category = categoryRepository.GetAllForDropDown();




            return View();
        }


        [HttpGet]
        [AllowAnonymous]
        public JsonResult GetDamage(int DamageId)
        {
            try
            {



                DamageModel Damage = DamageRepository.All().FirstOrDefault(x => x.Id == DamageId && x.isPosted == false);
                if (Damage == null)
                {
                    return Json("No Data Found");
                }

                //Damage.Items = DamageItemRepository.AllSubData().Where(x => x.DamageId == Damage.Id).ToList();
                Damage.Items = DamageItemRepository.AllSubData()
                    .Include(x => x.Product).Include(x => x.vWarehouse)
                    .Include(x => x.BatchSerialItems)
                    .Where(x => x.DamageId == Damage.Id).ToList();


                //var batchlistArray = DamageItemRepository.AllSubData().Where(x => x.DamageId == DamageId && x.SerialItem.Length != 0).Count();

                //if (batchlistArray != null)
                //{
                foreach (var item in Damage.Items)
                {
                    if (item.SerialItem != null)
                    {
                        var serialitems = item.SerialItem.Split(',');
                        //serialitems.Reverse();

                        item.SerialItemArray = serialitems;
                    }

                }
                //}



                //DamageItemsModel a = new DamageItemsModel { Name = "abc", Amount = 2.5, Id = 1, IsDelete = false, Price = 2.5, Quantity = 1, DamageId = 5};
                //Damage.Items.Add(a);
                return Json(Damage);
                //return Json(new { Success = 1, Damage = Damage, ex = "Data Load Successfully" });
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
            public double DamagePrice { get; set; }
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
                                    DamagePrice = e.Price,
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
                                    DamagePrice = e.Price,
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