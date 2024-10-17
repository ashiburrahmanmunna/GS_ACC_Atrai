using Atrai.Core.Common;
using Atrai.Data.Interfaces;
using Atrai.Data.Repository;
using Atrai.Model.Core.Entity;
using Atrai.Model.Core.ViewModel;
using Atrai.Services;
using Invoice.Core.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
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
using System.Linq;
using static Atrai.Controllers.AdminController;
using static Atrai.Controllers.ValuesController;

namespace Atrai.Controllers
{
    //[Authorize]
    [OverridableAuthorize]
    public class BuyerOrderController : Controller
    {
        public TransactionLogRepository tranlog { get; }


        private readonly IMenuPermissionRepository _menuPermissionRepository;
        private readonly IReportStyleRepository reportStyleRepository;

        private readonly ICustomerRepository customerRepository;
        private readonly IUserAccountRepository UserAccountRepository;
        private readonly IUnitMasterRepository unitMasterRepository;
        private readonly INotifyPartyRepository notifyPartyRepository;
        private readonly IExportInvoiceMasterRepository exportInvoiceMasterRepository;
        private readonly IExportInvoiceDetailsRepository exportInvoiceDetailsRepository;
        private readonly IExportInvoicePackingListRepository exportInvoicepackingListRepository;
        private readonly IExportRealizationMasterRepository exporRealizationMasterRepository;
        private readonly IExportRealizationDetailsRepository exporRealizationDetailsRepository;
        private readonly IExportInvoiceTruckDetailsRepository exporInvoiceTruckDetailsRepository;

        private readonly ISupplierRepository supplierRepository;
        private readonly ITermsMainRepository termsmainRepository;
        private readonly IRecurringDetailsRepository recurringDetailsRepository;
        private readonly ITransactionRepository transactionRepository;
        private readonly IBOMAllocationCategoryRepository bomAllocationCatRepository;
        private readonly IBOMMasterRepository bomMasterRepository;
        private readonly IBOMDetailsRepository bomDetailsRepository;
        private readonly IBOMQuantitySizeWiseRepository bomQtySizeWiseRepository;
        private readonly IMasterPOConsumptionRepository masterPOConsumptionRepository;
        private readonly IDepartmentRepository departmentRepository;
        private readonly ICommercialRepository commercialCompanyRepository;
        private readonly IBuyerGroupRepository buyerGroupRepository;
        private readonly IBankAccountNoRepository bankAccountNoRepository;
        private readonly ISupplierBankAccountRepository supplierBankAccountNoRepository;
        private readonly ILCTypeRepository lCTypeRepository;
        private readonly ICountryRepository countryRepository;
        private readonly IPostOfLoadingRepository loadingRepository;
        private readonly IPostOfDischargeRepository dischargeRepository;
        private readonly IDayListRepository dayListRepository;
        private readonly IIncoTermRepository tradeTermRepository;
        private readonly IDestinationRepository destinationRepository;
        private readonly IShipModeRepository shipModeRepository;
        private readonly IMasterLCRepository masterLCRepository;
        private readonly IMasterLCDetailsRepository masterLCDetailsRepository;
        private readonly IMasterLCDetailsTempRepository masterLCDetailsTempRepository;
        private readonly IDeptWiseDailyProduction_MasterRepository masterDeptwiseDailyProductionRepository;
        private readonly IDeptWiseDailyProduction_DetailsRepository detailsDeptwiseDailyProductionRepository;
        private readonly IBoxCategoryRepository boxCategoryRepository;


        private IEmailSender _emailsender { get; }
        private ISmsSender _smsSender { get; }

        private readonly IOrdersRepository onlineOrderRepository;
        private readonly IOrdersItemsRepository orderItemRepository;
        private readonly ISalesTagRepository salesTagRepository;
        private readonly ICustomFormStyleRepository _customFormStyleRepository;
        private readonly ITagsRepository tagsRepository;
        private readonly IGroupLCMainRepository groupLCMainRepository;
        private readonly IGroupLCSubRepository groupLCSubRepository;
        private readonly IReportFilterRepository ReportFilterRepository;

        private readonly ISalesItemsRepository saleItemRepository;
        private readonly ISalesReturnItemsRepository salesReturnItemRepository;
        private readonly ISalesProductTaxRepository salesProductTaxRepository;


        private readonly ISalesBatchItemsRepository _salesBatchItemRepository;
        private readonly IPurchaseBatchItemsRepository _purchaseBatchItemRepository;

        private readonly ISalesPaymentRepository salesPaymentRepository;
        private readonly ISalesTermsRepository salesTermsRepository;
        private readonly ITransactionRepository _accountsDailyTransaction;
        private readonly ITransactionDetailsRepository _transactionDetailsRepository;

        private readonly IBrandRepository brandRepository;
        private readonly IPurchaseRepository purchaseRepository;
        private readonly IStoreSettingRepository _storeSettingRepository;
        private readonly IStyleRepository _styleRepository;

        private readonly IPurchaseItemsRepository purchaseItemsRepository;
        private readonly IPurchasePaymentRepository purchasePaymentRepository;

        private readonly IStoreSettingRepository storeSettingRepository;
        private readonly IConfiguration configuration;
        private readonly ICompanyRepository companyRepository;
        private readonly ICategoryRepository categoryRepository;
        private readonly IUnitRepository _unitRepository;
        private readonly IConcernBankRepository concernBankRepository;

        private readonly IProductRepository productRepository;
        private readonly IProductTypeRepository productTypeRepository;
        private readonly IWarehouseRepository _warehouseRepository;
        private readonly IFromWarehousePermissionRepository _FromWarehousePermissionRepository;
        private readonly IToWarehousePermissionRepository ToWarehousePermissionRepository;

        private readonly IAccountHeadPermissionRepository AccountHeadPermissionRepository;
        private readonly IDailyProduction_MasterRepository dailyProductionMasterRepository;
        private readonly IDailyProduction_DetailsRepository dailyProductionDetailsRepository;
        private readonly ILCStatusRepository lcStatusRepository;
        private readonly IDocPrefixRepository docPrefixRepository;



        private readonly IAccountHeadRepository accountHeadRepository;
        private readonly IPaymentTypeRepository paymentTypeRepository;
        private readonly IDocTypeRepository _docTypeRepository;
        private readonly IEmployeeRepository _employeeRepository;
        private readonly ITimeZoneSettingsRepository _timeZoneSettingsRepository;

        private readonly ICountryRepository _currencyRepository;
        private readonly ISaleRepository saleRepository;
        private readonly IAccountCategoryRepository accountCategoryRepository;
        private readonly IBuyerPO_MasterRepository buyerPOMasterRepository;
        private readonly IBuyerPO_DetailsRepository buyerPODetailsRepository;
        private readonly IPaymentTermsRepository paymentTermsRepository;
        private readonly ICommercialTypeRepository CommercialTypeRepository;


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
        private readonly ISizesRepository sizesRepository;
        private readonly IColorChildRepository _colorChildRepository;
        private readonly ISizeChildRepository _sizeChildRepository;
        private readonly IColorsRepository colorsRepository;
        private readonly IColorsChildRepository colorsChildRepository;
        //private readonly IpaymentTypesRepository paymentTypesRepository;


        public static string ExpressionParameterizationException { get; }
        Dictionary<int, dynamic> postData = new Dictionary<int, dynamic>();


        public BuyerOrderController(ICustomerRepository customerRepository, IUserAccountRepository UserAccountRepository, ISaleRepository saleRepository,
            ISupplierRepository supplierRepository, IPurchaseRepository purchaseRepository, IStoreSettingRepository storeSettingRepository, IRecurringDetailsRepository recurringDetailsRepository, IColorsRepository colorsRepository, IColorsChildRepository colorsChildRepository, IColorChildRepository colorChildRepository, ISizeChildRepository sizeChildRepository,
            ITransactionRepository transactionRepository, ISizesRepository sizesRepository, IBuyerPO_MasterRepository buyerPOMasterRepository, IGroupLCMainRepository groupLCMainRepository,
            ISalesItemsRepository saleItemRepository, ISalesBatchItemsRepository saleBatchItemRepository, ISalesPaymentRepository salesPaymentRepository, IExportInvoiceTruckDetailsRepository exporInvoiceTruckDetailsRepository,
            IPurchaseBatchItemsRepository purchaseBatchItemRepository, ICostCalculatedRepository costCalculatedRepository, INotifyPartyRepository notifyPartyRepository,
             IPurchaseItemsRepository purchaseItemsRepository, IPurchasePaymentRepository purchasePaymentRepository, ITagsRepository tagsRepository, IBoxCategoryRepository boxCategoryRepository,
        ITransactionDetailsRepository transactionDetailsRepository, IProductTypeRepository productTypeRepository, IBrandRepository brandRepository, ISalesTagRepository salesTagRepository, IStyleRepository styleRepository, IBuyerPO_DetailsRepository buyerPODetailsRepository, IMasterPOConsumptionRepository masterPOConsumptionRepository, IDepartmentRepository departmentRepository, IDailyProduction_MasterRepository dailyProductionMasterRepository,
            ICategoryRepository categoryRepository, IUnitRepository unitRepository, IProductRepository productRepository, IBuyerGroupRepository buyerGroupRepository,
            IWarehouseRepository _warehouseRepository, IFromWarehousePermissionRepository FromWarehousePermissionRepository, IToWarehousePermissionRepository ToWarehousePermissionRepository, IAccountHeadRepository accountHeadRepository, IBOMAllocationCategoryRepository bomAllocationCatRepository,
            IPaymentTypeRepository paymentTypeRepository, ICompanyRepository companyRepository, ICustomFormStyleRepository customFormStyleRepository,
            IExportRealizationMasterRepository exporRealizationMasterRepository, IExportRealizationDetailsRepository exporRealizationDetailsRepository,
            IBOMQuantitySizeWiseRepository bomQtySizeWiseRepository, IMasterLCDetailsTempRepository masterLCDetailsTempRepository, IDocPrefixRepository docPrefixRepository,
            IDeptWiseDailyProduction_MasterRepository masterDeptwiseDailyProductionRepository, IDeptWiseDailyProduction_DetailsRepository detailsDeptwiseDailyProductionRepository,
            IExportInvoiceMasterRepository exportInvoiceMasterRepository, IExportInvoiceDetailsRepository exportInvoiceDetailsRepository, IExportInvoicePackingListRepository exportInvoicepackingListRepository,
            IConfiguration configuration, TransactionLogRepository tranlogRepository, IReportStyleRepository reportStyleRepository, IOrdersRepository onlineOrderRepository, IOrdersItemsRepository orderItemRepository, IDocTypeRepository docTypeRepository, ICreditBalanceRepository sMSBalanceRepository, ICreditUsedRepository creditUsedRepository, IEmailSender emailsender, ISmsSender smsSender, IAccountHeadPermissionRepository accountHeadPermissionRepository, IMenuPermissionRepository menuPermissionRepository, ITermsMainRepository termsmainRepository, ICountryRepository currencyRepository, IEmployeeRepository employeeRepository, ISalesTermsRepository salesTermsRepository, ITransactionRepository accountsDailyTransaction, ISalesReturnItemsRepository salesReturnItemRepository, IGatePassRepository gatePassRepository, IGatePassItemsRepository gatePassItemRepository, IAgencyRepository agencyRepository, ISalesTaxRepository salestaxRepository, IMasterSalesTaxRepository masterSalesTaxRepository, ISalesProductTaxRepository salesProductTaxRepository, IFeedbackRepository feedbackRepository, ICountryRepository countryRepository, IPostOfLoadingRepository loadingRepository, IPostOfDischargeRepository dischargeRepository,
            IAccountCategoryRepository accountCategoryRepository, IBOMMasterRepository bomMasterRepository, IBOMDetailsRepository bomDetailsRepository,
IPaymentTermsRepository paymentTermsRepository, IDailyProduction_DetailsRepository dailyProductionDetailsRepository, ICommercialRepository commercialCompanyRepository, IConcernBankRepository concernBankRepository, ILCTypeRepository lCTypeRepository, IBankAccountNoRepository bankAccountNoRepository, IUnitMasterRepository unitMasterRepository, IDayListRepository dayListRepository, ILCStatusRepository lcStatusRepository, IIncoTermRepository tradeTermRepository, IDestinationRepository destinationRepository, IShipModeRepository shipModeRepository, IMasterLCRepository masterLCRepository, IMasterLCDetailsRepository masterLCDetailsRepository,
        ITermsMainRepository termsMainRepository, ITermRepository termRepository, IWebHostEnvironment webHostEnvironment, ISupplierBankAccountRepository supplierBankAccountNoRepository, IGroupLCSubRepository groupLCSubRepository, ICommercialTypeRepository commercialTypeRepository, IReportFilterRepository reportFilterRepository)
        {
            this.configuration = configuration;
            this.masterDeptwiseDailyProductionRepository = masterDeptwiseDailyProductionRepository;
            this.detailsDeptwiseDailyProductionRepository = detailsDeptwiseDailyProductionRepository;
            this.customerRepository = customerRepository;
            this.UserAccountRepository = UserAccountRepository;
            this.brandRepository = brandRepository;
            this.saleRepository = saleRepository;
            this.saleItemRepository = saleItemRepository;
            this.exportInvoiceMasterRepository = exportInvoiceMasterRepository;
            this.exportInvoiceDetailsRepository = exportInvoiceDetailsRepository;
            this.exporRealizationMasterRepository = exporRealizationMasterRepository;
            this.exporRealizationDetailsRepository = exporRealizationDetailsRepository;
            this.tradeTermRepository = tradeTermRepository;
            this.groupLCMainRepository = groupLCMainRepository;
            this.boxCategoryRepository = boxCategoryRepository;
            this.masterLCRepository = masterLCRepository;
            this.bomQtySizeWiseRepository = bomQtySizeWiseRepository;
            this.lCTypeRepository = lCTypeRepository;
            this.masterLCDetailsTempRepository = masterLCDetailsTempRepository;
            this._salesBatchItemRepository = saleBatchItemRepository;
            this._purchaseBatchItemRepository = purchaseBatchItemRepository;
            this.paymentTermsRepository = paymentTermsRepository;
            this.concernBankRepository = concernBankRepository;
            this.exportInvoicepackingListRepository = exportInvoicepackingListRepository;
            this.salesTagRepository = salesTagRepository;
            this.lcStatusRepository = lcStatusRepository;
            this.salesPaymentRepository = salesPaymentRepository;
            this.salesProductTaxRepository = salesProductTaxRepository;
            this.exporInvoiceTruckDetailsRepository = exporInvoiceTruckDetailsRepository;
            this.productTypeRepository = productTypeRepository;
            this.recurringDetailsRepository = recurringDetailsRepository;
            this.notifyPartyRepository = notifyPartyRepository;
            this.destinationRepository = destinationRepository;
            this.dailyProductionMasterRepository = dailyProductionMasterRepository;
            this.dischargeRepository = dischargeRepository;
            this.shipModeRepository = shipModeRepository;
            this._storeSettingRepository = storeSettingRepository;
            this.supplierRepository = supplierRepository;
            this.purchaseRepository = purchaseRepository;
            this.commercialCompanyRepository = commercialCompanyRepository;
            this.buyerGroupRepository = buyerGroupRepository;
            this.countryRepository = countryRepository;
            this.dayListRepository = dayListRepository;
            this.loadingRepository = loadingRepository;
            this.masterLCDetailsRepository = masterLCDetailsRepository;
            this.unitMasterRepository = unitMasterRepository;
            this.purchaseItemsRepository = purchaseItemsRepository;
            this.bankAccountNoRepository = bankAccountNoRepository;
            this.departmentRepository = departmentRepository;
            this.purchasePaymentRepository = purchasePaymentRepository;
            this.dailyProductionDetailsRepository = dailyProductionDetailsRepository;
            this.tagsRepository = tagsRepository;
            this.transactionRepository = transactionRepository;
            this.sizesRepository = sizesRepository;
            this.buyerPODetailsRepository = buyerPODetailsRepository;
            this.buyerPOMasterRepository = buyerPOMasterRepository;
            this.colorsRepository = colorsRepository;
            this.colorsChildRepository = colorsChildRepository;
            this.masterPOConsumptionRepository = masterPOConsumptionRepository;
            _styleRepository = styleRepository;
            _colorChildRepository = colorChildRepository;
            _sizeChildRepository = sizeChildRepository;
            this.docPrefixRepository = docPrefixRepository;
            this.costCalculatedRepository = costCalculatedRepository;
            this.storeSettingRepository = storeSettingRepository;
            this.companyRepository = companyRepository;
            this.categoryRepository = categoryRepository;
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
            this.bomAllocationCatRepository = bomAllocationCatRepository;
            this.bomMasterRepository = bomMasterRepository;
            this.bomDetailsRepository = bomDetailsRepository;
            httpcontext = new HttpContextAccessor();
            _termsMainRepository = termsMainRepository;
            _termRepository = termRepository;
            _webHostEnvironment = webHostEnvironment;
            _transactionDetailsRepository = transactionDetailsRepository;
            this.supplierBankAccountNoRepository = supplierBankAccountNoRepository;
            this.groupLCSubRepository = groupLCSubRepository;
            CommercialTypeRepository = commercialTypeRepository;
            ReportFilterRepository = reportFilterRepository;
        }
        [AllowAnonymous]
        public IActionResult Index()
        {
            return View();
        }

        #region Order Allocation

        [HttpGet]
        //[AllowAnonymous]
        [OverridableAuthorize]
        public IActionResult CreateBuyerPO(int id = 0)
        {
            if (id == 0)
            {
                ViewBag.ActionType = "Create";
            }


            ViewBag.Id = id;

            return View();
        }

        [HttpGet]
        //[AllowAnonymous]
        [OverridableAuthorize]
        public IActionResult UpdateBuyerPO(int id = 0)
        {
            if (id > 0)
            {
                ViewBag.ActionType = "Edit";
            }

            ViewBag.Id = id;

            return View("CreateBuyerPO");
        }

        [HttpGet]
        [AllowAnonymous]
        public IActionResult GetColumnsName(int styleId)
        {
            var ComId = HttpContext.Session.GetInt32("ComId");

            var styleModel = _styleRepository.All().Where(x => x.Id == styleId).FirstOrDefault();

            SqlParameter[] sqlParameter1 = new SqlParameter[2];
            sqlParameter1[0] = new SqlParameter("@Comid", ComId);
            sqlParameter1[1] = new SqlParameter("@StyleId", styleId);

            var datasetabc = new System.Data.DataSet();
            datasetabc = Helper.ExecProcMapDS("Acc_prcGetSizes", sqlParameter1);

            var dataTable1 = datasetabc.Tables[0];
            var dataTable2 = datasetabc.Tables[1];

            var dataList = new List<SelectListItem>();
            var colordataList = new List<SelectListItem>();

            foreach (DataRow row in dataTable1.Rows)
            {
                var id = Convert.ToInt32(row["Id"]);
                var sizeName = row["SizeName"].ToString();

                var selectListItem = new SelectListItem
                {
                    Value = id.ToString(),
                    Text = sizeName
                };
                dataList.Add(selectListItem);
            }

            foreach (DataRow row in dataTable2.Rows)
            {
                var id = Convert.ToInt32(row["Id"]);
                var colorname = row["ColorName"].ToString();

                var selectListItem = new SelectListItem
                {
                    Value = id.ToString(),
                    Text = colorname
                };
                colordataList.Add(selectListItem);
            }


            return Json(new { Success = 1, data = dataList, colordata = colordataList, styleModel = styleModel, ex = "Data Loaded Successfully" });
        }

        [AllowAnonymous]
        public JsonResult GetBuyers()
        {
            var ComId = HttpContext.Session.GetInt32("ComId");

            var customer = customerRepository.All().Where(x => x.ComId == ComId)
                .Include(x => x.Currency)
                .Select(x => new
                {
                    x.Id,
                    x.Name,
                    x.CustomerCurrencyId,
                    x.Currency.CurrencyShortName,
                    x.ComId
                });
            return Json(customer);
        }

        [AllowAnonymous]
        public JsonResult SearchStyle(string term)
        {
            var comid = HttpContext.Session.GetInt32("ComId");
            var styles = _styleRepository.All()
                .Where(e => e.StyleNo.Contains(term) && e.ComId == comid)
                .Select(e => new { label = e.StyleNo, value = e.Id })
                .Take(10)
                .ToList();

            return new JsonResult(styles);
        }


        [AllowAnonymous]
        [HttpPost]
        public IActionResult BuyerPOCreation([FromBody] BuyerPO_MasterModel model)
        {
            var ComId = HttpContext.Session.GetInt32("ComId");

            if (model.Id == 0)
            {

                try
                {
                    buyerPOMasterRepository.Insert(model);

                    return Json(new { error = false, message = "Order Allocation saved successfully" });
                }
                catch (Exception ex)
                {
                    return Json(new { success = false, values = ex.Message.ToString() });
                }

            }
            else
            {

                buyerPOMasterRepository.Update(model, model.Id);

                var data = buyerPODetailsRepository.All().Where(x => x.BuyerPOId == model.Id).ToList();
                foreach (var item in data)
                {
                    buyerPODetailsRepository.Delete(item);
                }

                foreach (var item in model.BuyerPO_Details)
                {
                    item.BuyerPOId = model.Id;
                    item.Id = 0;

                    buyerPODetailsRepository.Insert(item);
                }

                return Json(new { error = false, message = "Order Allocation Updated successfully" });

            }
        }

        [AllowAnonymous]
        [HttpGet]
        public IActionResult BuyerPOList(string Type)
        {
            ViewBag.ListType = Type ?? "Order";
            return View();
        }

        [AllowAnonymous]
        [HttpGet]
        public IActionResult GetOrderListold()
        {
            try
            {
                var ComId = HttpContext.Session.GetInt32("ComId");

                var data = buyerPOMasterRepository.All()
                                                        .Where(x => x.ComId == ComId)
                                                        .Include(x => x.Buyers)
                                                        .Include(x => x.Style)
                                                        .Select(x => new
                                                        {
                                                            Id = x.Id,
                                                            BuyerName = x.Buyers.Name,
                                                            StyleName = x.Style.StyleNo,
                                                            BuyerPO = x.BuyerPO,
                                                            UnitPrice = x.UnitPrice,
                                                            TotalQuantity = x.TotalQuantity,
                                                        }).OrderByDescending(x => x.Id)
                                                        .ToList();




                return Json(new { Success = 1, error = false, data = data });

            }
            catch (Exception ex)
            {
                return Json(new { Success = 0, ex = ex.InnerException?.InnerException?.Message ?? ex.Message });
            }
        }

        [AllowAnonymous]
        public JsonResult GetOrderList(int page = 1, decimal size = 5, string searchquery = "")
        {
            try
            {
                var CurrentUserId = HttpContext.Session.GetInt32("UserId");
                var ComId = HttpContext.Session.GetInt32("ComId");
                var buyerPOlist = buyerPOMasterRepository.All().Where(x => x.IsDelete == false);

                var taburesquest = JsonConvert.DeserializeObject<TabulatorRequest>(searchquery);

                foreach (var item in taburesquest.Filter)
                {
                    if (item.Field == "BuyerName")
                    {
                        buyerPOlist = buyerPOlist.Where(x => x.Buyers.Name.ToLower().Contains(item.Value.ToLower()));
                    }
                    if (item.Field == "CompanyName")
                    {
                        buyerPOlist = buyerPOlist.Where(x => x.CommercialCompany.CompanyName.ToLower().Contains(item.Value.ToLower()));
                    }
                    if (item.Field == "StyleName")
                    {
                        buyerPOlist = buyerPOlist.Where(x => x.Style.StyleNo.ToLower().Contains(item.Value.ToLower()));
                    }
                    if (item.Field == "BuyerPO")
                    {
                        buyerPOlist = buyerPOlist.Where(x => x.BuyerPO.ToLower().Contains(item.Value.ToLower()));
                    }
                    if (item.Field == "UnitPrice")
                    {
                        buyerPOlist = buyerPOlist.Where(x => x.UnitPrice.ToString().ToLower().Contains(item.Value.ToLower()));
                    }
                    if (item.Field == "TotalQuantity")
                    {
                        buyerPOlist = buyerPOlist.Where(x => x.TotalQuantity.ToString().ToLower().Contains(item.Value.ToLower()));
                    }
                    if (item.Field == "OrderDate")
                    {
                        buyerPOlist = buyerPOlist.Where(x => x.OrderDate == DateTime.Parse(item.Value));
                    }
                }

                decimal TotalRecordCount = buyerPOlist.Count();
                var PageCountabc = decimal.Parse((TotalRecordCount / taburesquest.Size).ToString());
                var PageCount = Math.Ceiling(PageCountabc);

                int skip = (taburesquest.Page - 1) * taburesquest.Size;

                var query = from e in buyerPOlist.Include(x => x.Buyers).Include(x => x.Style).Include(x => x.CommercialCompany)
                            select new
                            {
                                Id = e.Id,
                                BuyerName = e.Buyers.Name,
                                CompanyName = e.CommercialCompany.CompanyName,
                                StyleName = e.Style.StyleNo,
                                BuyerPO = e.BuyerPO,
                                UnitPrice = e.UnitPrice,
                                TotalQuantity = e.TotalQuantity,
                                OrderDate = e.OrderDate
                            };
                var abcd = query.OrderByDescending(x => x.Id).Skip(skip).Take(taburesquest.Size).ToList();
                var pageinfo = new PagingInfo();
                pageinfo.PageCount = int.Parse(PageCount.ToString());
                pageinfo.PageNo = taburesquest.Page;
                pageinfo.PageSize = taburesquest.Size;
                pageinfo.TotalRecordCount = int.Parse(TotalRecordCount.ToString());

                //return  abcd;
                return Json(new { Success = 1, error = false, data = abcd, page = taburesquest.Page, size = taburesquest.Size, last_page = pageinfo.PageCount, total = pageinfo.TotalRecordCount });

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        [HttpGet]
        [AllowAnonymous]
        public IActionResult GetOrderDetails(int id)
        {

            var masterdata = buyerPOMasterRepository.All().Include(x => x.Style).Where(x => x.Id == id).FirstOrDefault();

            var ComId = HttpContext.Session.GetInt32("ComId");

            SqlParameter[] sqlParameter1 = new SqlParameter[3];
            sqlParameter1[0] = new SqlParameter("@Comid", ComId);
            sqlParameter1[1] = new SqlParameter("@StyleId", masterdata.StyleId);
            sqlParameter1[2] = new SqlParameter("@Id", id);

            var datasetabc = new System.Data.DataSet();
            datasetabc = Helper.ExecProcMapDS("Acc_prcGetSizes", sqlParameter1);

            var dataTable = datasetabc.Tables[0];

            return Json(new { Success = 1, masterdata = masterdata, data = dataTable, ex = "Data Loaded Successfully" });
        }

        [HttpGet]
        //[AllowAnonymous]
        [OverridableAuthorize]
        public IActionResult DeleteOrder(int Id)
        {
            try
            {
                var data = buyerPOMasterRepository.All().Where(x => x.Id == Id).FirstOrDefault();


                buyerPOMasterRepository.Delete(data);

                return Json(new { success = "1", msg = "Deleted Successfully" });
            }
            catch
            {

                return Json(new { success = "0", msg = "Occuring error while deleting" });

            }

        }

        #endregion

        #region BOM


        [HttpGet]
        //[AllowAnonymous]
        [OverridableAuthorize]
        public IActionResult CreateBOM(int id = 0, int IsCopy = 0, int IsRevised = 0)
        {
            var ComId = HttpContext.Session.GetInt32("ComId");
            if (id == 0)
            {
                ViewBag.ActionType = "Create";
            }
            else
            {
                if (IsCopy == 0)
                {
                    if (IsRevised == 0)
                    {
                        ViewBag.ActionType = "Edit";
                    }
                    else
                    {
                        ViewBag.ActionType = "Revision";
                    }
                }
                else
                {
                    ViewBag.ActionType = "Copy";
                }
            }

            ViewBag.Id = id;

            ViewBag.CategoryId = categoryRepository.GetAllForDropDown();

            var categoryList = bomAllocationCatRepository.All().Where(p => p.ComId == ComId && p.CategoryType.Name == "BOM Category")
            .Select(x => new SelectListItem
            {
                Text = x.Name,
                Value = x.Id.ToString()
            }).ToList();

            //categoryList.Insert(0, new SelectListItem { Value = "", Text = "Select" });

            ViewBag.BOMAllocationCat = new SelectList(categoryList, "Value", "Text");

            var categoryList1 = bomAllocationCatRepository.All().Where(p => p.ComId == ComId && p.CategoryType.Name == "Cost Category")
            .Select(x => new SelectListItem
            {
                Text = x.Name,
                Value = x.Id.ToString()
            }).ToList();


            ViewBag.CostAllocationCat = new SelectList(categoryList1, "Value", "Text");

            ViewBag.BrandId = brandRepository.GetAllForDropDown();
            ViewBag.ModelId = productRepository.GetModelDropDown();
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

            ViewBag.ColorList = colorsRepository.GetAllForDropDown();

            ViewBag.SizeList = sizesRepository.GetAllForDropDown();

            //ViewBag.BOMAllocationCat = bomAllocationCatRepository.GetAllForDropDown();

            return View();
        }

        [HttpGet]
        //[AllowAnonymous]
        [OverridableAuthorize]
        public IActionResult UpdateBOM(int id = 0, int IsCopy = 0, int IsRevised = 0)
        {
            var ComId = HttpContext.Session.GetInt32("ComId");
            if (id == 0)
            {
                ViewBag.ActionType = "Create";
            }
            else
            {
                if (IsCopy == 0)
                {
                    if (IsRevised == 0)
                    {
                        ViewBag.ActionType = "Edit";
                    }
                    else
                    {
                        ViewBag.ActionType = "Revision";
                    }
                }
                else
                {
                    ViewBag.ActionType = "Copy";
                }
            }

            ViewBag.Id = id;
            ViewBag.CategoryId = categoryRepository.GetAllForDropDown();
            ViewBag.BrandId = brandRepository.GetAllForDropDown();
            ViewBag.ModelId = productRepository.GetModelDropDown();
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

            ViewBag.ColorList = colorsRepository.GetAllForDropDown();

            ViewBag.SizeList = sizesRepository.GetAllForDropDown();

            //ViewBag.BOMAllocationCat = bomAllocationCatRepository.GetAllForDropDown();
            var categoryList = bomAllocationCatRepository.All().Where(p => p.ComId == ComId && p.CategoryType.Name == "BOM Category")
            .Select(x => new SelectListItem
            {
                Text = x.Name,
                Value = x.Id.ToString()
            }).ToList();

            //categoryList.Insert(0, new SelectListItem { Value = "", Text = "Select" });

            ViewBag.BOMAllocationCat = new SelectList(categoryList, "Value", "Text");

            var categoryList1 = bomAllocationCatRepository.All().Where(p => p.ComId == ComId && p.CategoryType.Name == "Cost Category")
            .Select(x => new SelectListItem
            {
                Text = x.Name,
                Value = x.Id.ToString()
            }).ToList();


            ViewBag.CostAllocationCat = new SelectList(categoryList1, "Value", "Text");

            return View("CreateBOM");
        }

        [AllowAnonymous]
        public JsonResult GetColorBOM(int style)
        {
            try
            {
                var errors = ModelState.Where(x => x.Value.Errors.Any())
               .Select(x => new { x.Key, x.Value.Errors });

                var styleData = _styleRepository.All().Where(x => x.Id == style).FirstOrDefault().Id;
                var colorData = colorsChildRepository.All().Where(x => x.StyleId == styleData).Include(x => x.Colors)
                    .Select(x => new
                    {
                        Value = x.ColorId,
                        Text = x.Colors.ColorName
                    });


                return Json(colorData);

            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        [AllowAnonymous]
        public JsonResult GetSizeBOM(int style)
        {
            try
            {
                var errors = ModelState.Where(x => x.Value.Errors.Any())
               .Select(x => new { x.Key, x.Value.Errors });

                var styleData = _styleRepository.All().Where(x => x.Id == style).FirstOrDefault().Id;
                var colorData = _sizeChildRepository.All().Where(x => x.StyleId == styleData).Include(x => x.Sizes)
                    .Select(x => new
                    {
                        Value = x.SizeId,
                        Text = x.Sizes.SizeName
                    });
                return Json(colorData);

            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        [AllowAnonymous]
        public JsonResult GetColorBOM1(int style)
        {
            try
            {
                var errors = ModelState.Where(x => x.Value.Errors.Any())
               .Select(x => new { x.Key, x.Value.Errors });

                var bomData = buyerPOMasterRepository.All().Where(x => x.StyleId == style).Include(x => x.BuyerPO_Details).FirstOrDefault();

                List<SelectListItem> colorSelectList = new List<SelectListItem>();

                HashSet<int> addedColorIds = new HashSet<int>();

                foreach (var item in bomData.BuyerPO_Details)
                {
                    var color = colorsRepository.All().Where(x => x.Id == item.ColorId).FirstOrDefault();

                    if (!addedColorIds.Contains(color.Id))
                    {
                        if (color != null)
                        {
                            var selectListItem = new SelectListItem
                            {
                                Text = color.ColorName,
                                Value = color.Id.ToString()
                            };

                            colorSelectList.Add(selectListItem);

                            addedColorIds.Add(color.Id);
                        }
                    }
                }
                return Json(colorSelectList);

            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        [AllowAnonymous]
        public JsonResult GetColor()
        {
            var ComId = HttpContext.Session.GetInt32("ComId");

            var color = colorsRepository.GetAllForDropDown();
            return Json(color);
        }

        [AllowAnonymous]
        public JsonResult GetSize()
        {
            var ComId = HttpContext.Session.GetInt32("ComId");

            var size = sizesRepository.GetAllForDropDown();
            return Json(size);
        }



        [AllowAnonymous]
        [HttpPost]
        public IActionResult BOMCreation([FromBody] BOMMasterModel model)
        {
            try
            {

                var errors = ModelState.Where(x => x.Value.Errors.Any())
               .Select(x => new { x.Key, x.Value.Errors });

                var ComId = HttpContext.Session.GetInt32("ComId");

                if (model.Id == 0)
                {

                    try
                    {
                        bomMasterRepository.Insert(model);

                        if (model.ParentId != null)
                        {
                            var parentData = bomMasterRepository.All().Where(x => x.Id == model.ParentId).FirstOrDefault();
                            parentData.IsRevised = true;
                            bomMasterRepository.Update(parentData, parentData.Id);
                        }

                        return Json(new { error = false, message = "BOM saved successfully" });
                    }
                    catch (Exception ex)
                    {
                        return Json(new { success = false, values = ex.Message.ToString() });
                    }

                }
                else
                {
                    var oldModel = bomMasterRepository.All().Where(x => x.Id == model.Id).FirstOrDefault();
                    model.IsRevised = oldModel.IsRevised;
                    bomMasterRepository.Update(model, model.Id);

                    var data = bomDetailsRepository.All().Where(x => x.BOMMasterId == model.Id && (x.ComId == 0 || x.ComId == ComId)).ToList();
                    foreach (var item in data)
                    {
                        bomDetailsRepository.Delete(item);
                    }

                    foreach (var item in model.BOMDetails)
                    {
                        item.BOMMasterId = model.Id;
                        item.Id = 0;

                        bomDetailsRepository.Insert(item);
                    }

                    return Json(new { error = false, message = "BOM Updated successfully" });

                }

            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        [AllowAnonymous]
        [HttpGet]
        public IActionResult GetBOMListold()
        {
            try
            {
                var ComId = HttpContext.Session.GetInt32("ComId");

                var data = bomMasterRepository.All()
                                                        .Where(x => x.ComId == ComId)
                                                        .Include(x => x.Style)
                                                        .Include(x => x.Colors)
                                                        .Include(x => x.Sizes)
                                                        .Select(x => new
                                                        {
                                                            Id = x.Id,
                                                            BOMCode = x.BOMCode,
                                                            Style = x.Style.StyleNo,
                                                            Color = x.Colors.ColorName,
                                                            Size = x.Sizes.SizeName,
                                                            x.IsRevised,
                                                        })
                                                        .ToList();




                return Json(new { Success = 1, error = false, data = data });

            }
            catch (Exception ex)
            {
                return Json(new { Success = 0, ex = ex.InnerException?.InnerException?.Message ?? ex.Message });
            }
        }

        [AllowAnonymous]
        public JsonResult GetBOMList(int page = 1, decimal size = 5, string searchquery = "")
        {
            try
            {
                var CurrentUserId = HttpContext.Session.GetInt32("UserId");
                var ComId = HttpContext.Session.GetInt32("ComId");
                var BomList = bomMasterRepository.All().Where(x => x.IsDelete == false);

                var taburesquest = JsonConvert.DeserializeObject<TabulatorRequest>(searchquery);

                foreach (var item in taburesquest.Filter)
                {
                    if (item.Field == "BOMCode")
                    {
                        BomList = BomList.Where(x => x.BOMCode.ToLower().Contains(item.Value.ToLower()));
                    }
                    if (item.Field == "Style")
                    {
                        BomList = BomList.Where(x => x.Style.StyleNo.ToLower().Contains(item.Value.ToLower()));
                    }
                    if (item.Field == "Color")
                    {
                        BomList = BomList.Where(x => x.Colors.ColorName.ToLower().Contains(item.Value.ToLower()));
                    }
                    if (item.Field == "Size")
                    {
                        BomList = BomList.Where(x => x.Sizes.SizeName.ToLower().Contains(item.Value.ToLower()));
                    }
                }

                decimal TotalRecordCount = BomList.Count();
                var PageCountabc = decimal.Parse((TotalRecordCount / taburesquest.Size).ToString());
                var PageCount = Math.Ceiling(PageCountabc);

                int skip = (taburesquest.Page - 1) * taburesquest.Size;

                var query = from e in BomList.Include(x => x.Style).Include(x => x.Colors).Include(x => x.Sizes)
                            select new
                            {
                                Id = e.Id,
                                BOMCode = e.BOMCode,
                                Style = e.Style.StyleNo,
                                Color = e.Colors.ColorName,
                                Size = e.Sizes.SizeName,
                                e.IsRevised,
                            };
                var abcd = query.OrderByDescending(x => x.Id).Skip(skip).Take(taburesquest.Size).ToList();
                var pageinfo = new PagingInfo();
                pageinfo.PageCount = int.Parse(PageCount.ToString());
                pageinfo.PageNo = taburesquest.Page;
                pageinfo.PageSize = taburesquest.Size;
                pageinfo.TotalRecordCount = int.Parse(TotalRecordCount.ToString());

                //return  abcd;
                return Json(new { Success = 1, error = false, data = abcd, page = taburesquest.Page, size = taburesquest.Size, last_page = pageinfo.PageCount, total = pageinfo.TotalRecordCount });

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        [HttpGet]
        //[AllowAnonymous]
        [OverridableAuthorize]
        public IActionResult DeleteBOM(int Id)
        {
            try
            {
                var data = bomMasterRepository.All().Where(x => x.Id == Id).FirstOrDefault();

                if (data.ParentId != null)
                {
                    var parentData = bomMasterRepository.All().Where(x => x.Id == data.ParentId).FirstOrDefault();
                    parentData.IsRevised = false;
                    bomMasterRepository.Update(parentData, parentData.Id);
                }

                bomMasterRepository.Delete(data);

                return Json(new { success = "1", msg = "Deleted Successfully" });
            }
            catch
            {

                return Json(new { success = "0", msg = "Occuring error while deleting" });

            }

        }

        [HttpGet]
        [AllowAnonymous]
        public IActionResult GetBOMDetails(int id)
        {
            var searchquery = bomMasterRepository.All().Where(x => x.Id == id);

            var data = searchquery
                .Include(x => x.Style)
                .Include(x => x.Colors)
                .Include(x => x.Sizes)
                .Select(x => new
                {
                    x.Id,
                    x.StyleId,
                    StyleNo = x.Style.StyleNo,
                    x.ColorId,
                    ColorName = x.Colors.ColorName,
                    x.SizeId,
                    x.BOMCode,
                    x.Revision,
                    BOMDetails = x.BOMDetails.Where(x => x.IsDelete == false).Select(a => new
                    {
                        a.Id,
                        a.Remarks1,
                        a.Remarks2,
                        a.ProductId,
                        Name = a.Product.Name,
                        PCategoryId = a.Product.CategoryId,
                        PCategoryName = a.Product.Category.Name,
                        BOMAllocationCategoryName = a.BOMAllocationCategory.Name,
                        CostAllocationCategoryName = a.CostCategory.Name,
                        a.BOMAllocationCategoryId,
                        a.CostCategoryId,
                        ColorName = a.Colors.ColorName,
                        ProductColor = a.Product.ColorName,
                        ColorId = a.ColorId,
                        SizeName = a.Sizes.SizeName,
                        ProductSize = a.Product.SizeName,
                        a.SizeId,
                        UnitName = a.Product.Unit.UnitName,
                        UnitId = a.Product.UnitId,
                        RunTimeLiveStock = a.Quantity,
                        a.UniqueId,
                        a.Price,
                        a.Amount,
                        a.IsCost
                    }).ToList()

                }).FirstOrDefault();

            var ComId = HttpContext.Session.GetInt32("ComId");

            SqlParameter[] sqlParameter = new SqlParameter[2];
            sqlParameter[0] = new SqlParameter("@ComId", ComId);
            sqlParameter[1] = new SqlParameter("@MasterBOMId", id);

            var datasetabc = new System.Data.DataSet();
            datasetabc = Helper.ExecProcMapDS("GetSizeAllocationList", sqlParameter);

            var dataTable = datasetabc.Tables[0];

            return Json(new { success = "1", msg = "Deleted Successfully", data = data, sizeAllocation = dataTable });
        }

        [HttpGet]
        [AllowAnonymous]
        public IActionResult GetmodalBOMDetailsWithProcess(int styleid, int orderAllocationId)
        {
            var ComId = HttpContext.Session.GetInt32("ComId");
            var zero = 0;

            SqlParameter[] sqlParameter1 = new SqlParameter[4];
            sqlParameter1[0] = new SqlParameter("@ComId", ComId);
            sqlParameter1[1] = new SqlParameter("@StyleId", styleid);
            sqlParameter1[2] = new SqlParameter("@BuyerPOId", orderAllocationId);
            sqlParameter1[3] = new SqlParameter("@IsView", zero);

            var datasetabc = new System.Data.DataSet();
            datasetabc = Helper.ExecProcMapDS("prc_OrderConsumption", sqlParameter1);

            var dataTable = datasetabc.Tables[0];

            return Json(new { Success = 1, data = dataTable, ex = "Data Loaded Successfully" });
        }

        [HttpGet]
        [AllowAnonymous]
        public IActionResult GetmodalBOMDetails(int styleid, int orderAllocationId)
        {
            var ComId = HttpContext.Session.GetInt32("ComId");

            SqlParameter[] sqlParameter1 = new SqlParameter[4];
            sqlParameter1[0] = new SqlParameter("@ComId", ComId);
            sqlParameter1[1] = new SqlParameter("@StyleId", styleid);
            sqlParameter1[2] = new SqlParameter("@BuyerPOId", orderAllocationId);
            sqlParameter1[3] = new SqlParameter("@IsView", 1);

            var datasetabc = new System.Data.DataSet();
            datasetabc = Helper.ExecProcMapDS("prc_OrderConsumption", sqlParameter1);

            var dataTable = datasetabc.Tables[0];

            return Json(new { Success = 1, data = dataTable, ex = "Data Loaded Successfully" });
        }

        [HttpGet]
        [AllowAnonymous]
        public IActionResult GetmodalBOMConDetails(int masterPOId)
        {
            var ComId = HttpContext.Session.GetInt32("ComId");

            int zero = 0;
            SqlParameter[] sqlParameter1 = new SqlParameter[3];
            sqlParameter1[0] = new SqlParameter("@ComId", ComId);
            sqlParameter1[1] = new SqlParameter("@MasterPOId", masterPOId);
            sqlParameter1[2] = new SqlParameter("@IsView", zero);

            var datasetabc = new System.Data.DataSet();
            datasetabc = Helper.ExecProcMapDS("prc_MasterPOOrderConsumptionSheet", sqlParameter1);

            var dataTable = datasetabc.Tables[0];
            var dataTable1 = datasetabc.Tables[1];
            var dataTable2 = datasetabc.Tables[2];

            return Json(new { Success = 1, data = dataTable, pivotData = dataTable1, captionData = dataTable2, ex = "Data Loaded Successfully" });
        }

        [HttpGet]
        [AllowAnonymous]
        public IActionResult GetmodalBOMConDetailsView(int masterPOId)
        {
            var ComId = HttpContext.Session.GetInt32("ComId");

            int zero = 1;
            SqlParameter[] sqlParameter1 = new SqlParameter[3];
            sqlParameter1[0] = new SqlParameter("@ComId", ComId);
            sqlParameter1[1] = new SqlParameter("@MasterPOId", masterPOId);
            sqlParameter1[2] = new SqlParameter("@IsView", zero);

            var datasetabc = new System.Data.DataSet();
            datasetabc = Helper.ExecProcMapDS("prc_MasterPOOrderConsumptionSheet", sqlParameter1);

            var dataTable = datasetabc.Tables[0];
            var dataTable1 = datasetabc.Tables[1];
            var dataTable2 = datasetabc.Tables[2];

            return Json(new { Success = 1, data = dataTable, pivotData = dataTable1, captionData = dataTable2, ex = "Data Loaded Successfully" });
        }

        [HttpPost]
        [AllowAnonymous]
        public IActionResult UpgradeSupplierForDetails([FromBody] List<SupplierDetailsModel> data)
        {

            foreach (var item in data)
            {
                var model = masterPOConsumptionRepository.All().Where(x => x.Id == item.Id).FirstOrDefault();
                model.SupplierId = item.SupplierId;
                masterPOConsumptionRepository.Update(model, model.Id);

            }

            return Json(new { Success = 1, ex = "Supplier Upgraded Successfully" });
        }

        public class SupplierDetailsModel
        {
            public int Id { get; set; }
            public int SupplierId { get; set; }
        }

        [HttpPost]
        [AllowAnonymous]
        public IActionResult UpgradeSupplierForPivot([FromBody] List<SupplierPivotModel> data)
        {

            foreach (var item in data)
            {
                var model = masterPOConsumptionRepository.All().Where(x => x.MasterPOId == item.Id && x.ProductId == item.ProductId).ToList();
                foreach (var x in model)
                {
                    x.SupplierId = item.SupplierId;
                    masterPOConsumptionRepository.Update(x, x.Id);
                }


            }

            return Json(new { Success = 1, ex = "Supplier Upgraded Successfully" });
        }

        public class SupplierPivotModel
        {
            public int Id { get; set; }
            public int ProductId { get; set; }
            public int SupplierId { get; set; }
        }

        #endregion

        [HttpGet]
        [AllowAnonymous]
        public IActionResult GetMasterPOConsumption(int SupplierId, int MasterId, int PurchaseId)
        {
            try
            {
                var ComId = HttpContext.Session.GetInt32("ComId");

                SqlParameter[] sqlParameter1 = new SqlParameter[4];
                sqlParameter1[0] = new SqlParameter("@ComId", ComId);
                sqlParameter1[1] = new SqlParameter("@MasterPOId", MasterId);
                sqlParameter1[2] = new SqlParameter("@SupplierId", SupplierId);
                sqlParameter1[3] = new SqlParameter("@PurchaseId", PurchaseId);

                var datasetabc = new System.Data.DataSet();
                datasetabc = Helper.ExecProcMapDS("get_MasterPOConsumption", sqlParameter1);

                var data = datasetabc.Tables[0];

                return Json(new { success = "1", msg = "Data retrieved successfully", data = data });
            }
            catch (Exception ex)
            {
                // Log the exception or handle it appropriately
                return Json(new { success = "0", msg = "An error occurred while fetching data", data = ex.Message });
            }
        }


        #region Daily Production


        [HttpGet]
        //[AllowAnonymous]
        [OverridableAuthorize]
        public IActionResult CreateDailyProduction(int id = 0)
        {
            if (id == 0)
            {
                ViewBag.ActionType = "Create";
            }


            ViewBag.Id = id;

            return View();
        }

        [HttpGet]
        //[AllowAnonymous]
        [OverridableAuthorize]
        public IActionResult UpdateDailyProduction(int id = 0)
        {

            if (id > 0)
            {
                ViewBag.ActionType = "Edit";
            }

            ViewBag.Id = id;

            return View("CreateDailyProduction");
        }

        [AllowAnonymous]
        public JsonResult GetBuyersPO()
        {
            var ComId = HttpContext.Session.GetInt32("ComId");

            var customer = buyerPOMasterRepository.All().Where(x => x.ComId == ComId)
                .Select(x => new
                {
                    x.Id,
                    x.BuyerPO
                });
            return Json(customer);
        }

        [AllowAnonymous]
        public JsonResult GetBuyersPOStyleWise(int styleId)
        {
            var ComId = HttpContext.Session.GetInt32("ComId");

            var customer = buyerPOMasterRepository.All().Where(x => x.ComId == ComId && x.StyleId == styleId)
                .Select(x => new
                {
                    x.Id,
                    x.BuyerPO
                });
            return Json(customer);
        }

        [AllowAnonymous]
        public JsonResult GetDepartments()
        {
            var ComId = HttpContext.Session.GetInt32("ComId");

            var customer = departmentRepository.All().Where(x => x.ComId == ComId)
                .Select(x => new
                {
                    x.Id,
                    x.DeptName
                });
            return Json(customer);
        }

        [AllowAnonymous]
        public JsonResult GetPODetails(int buyerPOId, int DeptId)
        {
            var ComId = HttpContext.Session.GetInt32("ComId");

            var masterData = buyerPOMasterRepository.All().Where(x => x.Id == buyerPOId)
                .Include(x => x.Style)
                .Select(
                x => new
                {
                    x.BuyerId,
                    x.StyleId,
                    x.UnitPrice,
                    StyleNo = x.Style.StyleNo
                }).FirstOrDefault();

            SqlParameter[] sqlParameter1 = new SqlParameter[4];
            sqlParameter1[0] = new SqlParameter("@ComId", ComId);
            sqlParameter1[1] = new SqlParameter("@StyleId", masterData.StyleId);
            sqlParameter1[2] = new SqlParameter("@BuyerPOId", buyerPOId);
            sqlParameter1[3] = new SqlParameter("@DepartmentId", DeptId);

            var datasetabc = new System.Data.DataSet();
            datasetabc = Helper.ExecProcMapDS("Acc_prcGetGridForDailyProduction", sqlParameter1);

            var dataTable = datasetabc.Tables[0];
            var dataTable1 = datasetabc.Tables[1];


            return Json(new { success = "1", msg = "Data retrieved successfully", data = masterData, dataTable = dataTable, dataTable1 = dataTable1 });
        }

        [AllowAnonymous]
        [HttpPost]
        public IActionResult DailyProductionCreation([FromBody] DailyProduction_MasterModel model)
        {
            var ComId = HttpContext.Session.GetInt32("ComId");

            if (model.Id == 0)
            {

                try
                {
                    dailyProductionMasterRepository.Insert(model);

                    return Json(new { error = false, message = "Daily Production saved successfully" });
                }
                catch (Exception ex)
                {
                    return Json(new { success = false, values = ex.Message.ToString() });
                }

            }
            else
            {

                dailyProductionMasterRepository.Update(model, model.Id);

                var data = dailyProductionDetailsRepository.All().Where(x => x.DailyProductionId == model.Id).ToList();

                dailyProductionDetailsRepository.RemoveRange(data);


                foreach (var item in model.DailyProduction_Details)
                {
                    item.DailyProductionId = model.Id;
                    item.Id = 0;
                    item.ReceivedQuantity = item.ReceivedQuantity;

                    dailyProductionDetailsRepository.Insert(item);
                }

                return Json(new { error = false, message = "Daily Production Updated successfully" });

            }
        }

        [AllowAnonymous]
        [HttpGet]
        public IActionResult GetDailyProductionListold()
        {
            try
            {
                var ComId = HttpContext.Session.GetInt32("ComId");

                var data = dailyProductionMasterRepository.All()
                                                        .Where(x => x.ComId == ComId)
                                                        .Include(x => x.Style)
                                                        .Include(x => x.Buyers)
                                                        .Include(x => x.BuyerPO_Master)
                                                        .Select(x => new
                                                        {
                                                            Id = x.Id,
                                                            Style = x.Style.StyleNo,
                                                            Buyer = x.Buyers.Name,
                                                            BuyerPO = x.BuyerPO_Master.BuyerPO,
                                                            TotalQuantity = x.TotalQuantity
                                                        })
                                                        .ToList();

                return Json(new { Success = 1, error = false, data = data });

            }
            catch (Exception ex)
            {
                return Json(new { Success = 0, ex = ex.InnerException?.InnerException?.Message ?? ex.Message });
            }
        }

        [AllowAnonymous]
        public JsonResult GetDailyProductionList(int page = 1, decimal size = 5, string searchquery = "")
        {
            try
            {
                var CurrentUserId = HttpContext.Session.GetInt32("UserId");
                var ComId = HttpContext.Session.GetInt32("ComId");
                var ProductionList = dailyProductionMasterRepository.All().Where(x => x.IsDelete == false);

                var taburesquest = JsonConvert.DeserializeObject<TabulatorRequest>(searchquery);

                foreach (var item in taburesquest.Filter)
                {
                    if (item.Field == "StyleNo")
                    {
                        ProductionList = ProductionList.Where(x => x.Style.StyleNo.ToLower().Contains(item.Value.ToLower()));
                    }
                    if (item.Field == "Buyer")
                    {
                        ProductionList = ProductionList.Where(x => x.Buyers.Name.ToLower().Contains(item.Value.ToLower()));
                    }
                    if (item.Field == "DailyBuyerPO")
                    {
                        ProductionList = ProductionList.Where(x => x.BuyerPO_Master.BuyerPO.ToLower().Contains(item.Value.ToLower()));
                    }
                    if (item.Field == "DailyTotalQuantity")
                    {
                        ProductionList = ProductionList.Where(x => x.TotalQuantity.ToString().ToLower().Contains(item.Value.ToLower()));
                    }
                }


                decimal TotalRecordCount = ProductionList.Count();
                var PageCountabc = decimal.Parse((TotalRecordCount / taburesquest.Size).ToString());
                var PageCount = Math.Ceiling(PageCountabc);

                int skip = (taburesquest.Page - 1) * taburesquest.Size;

                var query = from e in ProductionList.Include(x => x.Buyers).Include(x => x.Style).Include(x => x.BuyerPO_Master)
                            select new
                            {
                                Id = e.Id,
                                StyleNo = e.Style.StyleNo,
                                Buyer = e.Buyers.Name,
                                DailyBuyerPO = e.BuyerPO_Master.BuyerPO,
                                DailyTotalQuantity = e.TotalQuantity
                            };
                var abcd = query.OrderByDescending(x => x.Id).Skip(skip).Take(taburesquest.Size).ToList();
                var pageinfo = new PagingInfo();
                pageinfo.PageCount = int.Parse(PageCount.ToString());
                pageinfo.PageNo = taburesquest.Page;
                pageinfo.PageSize = taburesquest.Size;
                pageinfo.TotalRecordCount = int.Parse(TotalRecordCount.ToString());

                //return  abcd;
                return Json(new { Success = 1, error = false, data = abcd, page = taburesquest.Page, size = taburesquest.Size, last_page = pageinfo.PageCount, total = pageinfo.TotalRecordCount });

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        [HttpGet]
        //[AllowAnonymous]
        [OverridableAuthorize]
        public IActionResult DeleteDailyProduction(int Id)
        {
            try
            {
                var data = dailyProductionMasterRepository.All().Where(x => x.Id == Id).FirstOrDefault();


                dailyProductionMasterRepository.Delete(data);

                return Json(new { success = "1", msg = "Deleted Successfully" });
            }
            catch
            {

                return Json(new { success = "0", msg = "Occuring error while deleting" });

            }

        }

        [HttpGet]
        [AllowAnonymous]
        public IActionResult GetDailyProductionDetails(int id)
        {

            var masterdata = dailyProductionMasterRepository.All().Include(x => x.Style).Where(x => x.Id == id).FirstOrDefault();

            var ComId = HttpContext.Session.GetInt32("ComId");

            SqlParameter[] sqlParameter1 = new SqlParameter[5];
            sqlParameter1[0] = new SqlParameter("@ComId", ComId);
            sqlParameter1[1] = new SqlParameter("@StyleId", masterdata.StyleId);
            sqlParameter1[2] = new SqlParameter("@BuyerPOId", masterdata.BuyerPOId);
            sqlParameter1[3] = new SqlParameter("@DailyProductionId", id);
            sqlParameter1[4] = new SqlParameter("@DepartmentId", masterdata.DepartmentId);

            var datasetabc = new System.Data.DataSet();
            datasetabc = Helper.ExecProcMapDS("Acc_prcGetGridForDailyProduction", sqlParameter1);

            var dataTable = datasetabc.Tables[0];
            var dataTable1 = datasetabc.Tables[1];
            var dataTable2 = datasetabc.Tables[2];

            return Json(new { Success = 1, masterdata = masterdata, data = dataTable, data1 = dataTable1, data2 = dataTable2, ex = "Data Loaded Successfully" });
        }
        #endregion


        #region MasterLC

        [OverridableAuthorize]
        [HttpGet]
        public IActionResult AddMasterLC(int id = 0)
        {
            var ComId = HttpContext.Session.GetInt32("ComId");
            ViewBag.ActionType = "Create";

            ViewBag.Id = id;
            var buyerPO = buyerPOMasterRepository.All().Where(p => p.ComId == ComId).ToList();

            SelectList buyerPOList = new SelectList(buyerPO, "Id", "BuyerPO");
            ViewData["BuyerPOList"] = buyerPOList;

            var unit = _unitRepository.All().Where(x => x.ComId == ComId).ToList();
            SelectList unitList = new SelectList(unit, "Id", "UnitName");
            ViewData["UnitList"] = unitList;

            return View();
        }

        [OverridableAuthorize]
        [HttpGet]
        public IActionResult EditMasterLC(int id = 0)
        {
            var ComId = HttpContext.Session.GetInt32("ComId");

            ViewBag.ActionType = "Edit";

            ViewBag.Id = id;
            var buyerPO = buyerPOMasterRepository.All().Where(p => p.ComId == ComId).ToList();

            SelectList buyerPOList = new SelectList(buyerPO, "Id", "BuyerPO");
            ViewData["BuyerPOList"] = buyerPOList;

            var unit = _unitRepository.All().Where(x => x.ComId == ComId).ToList();
            SelectList unitList = new SelectList(unit, "Id", "UnitName");
            ViewData["UnitList"] = unitList;

            return View("AddMasterLC");
        }



        [AllowAnonymous]
        public JsonResult GetComercialCompany()
        {
            var ComId = HttpContext.Session.GetInt32("ComId");

            var company = commercialCompanyRepository.GetAllForDropDown();
            return Json(company);
        }

        [AllowAnonymous]
        public JsonResult GetBuyerGroup()
        {
            var ComId = HttpContext.Session.GetInt32("ComId");

            var buyerGroup = buyerGroupRepository.GetAllForDropDown();
            return Json(buyerGroup);
        }

        [AllowAnonymous]
        public JsonResult GetBankAccountNo()
        {
            var ComId = HttpContext.Session.GetInt32("ComId");

            var bankAccount = bankAccountNoRepository.GetAllForDropDown();
            return Json(bankAccount);
        }

        [AllowAnonymous]
        public JsonResult GetConcernBank()
        {
            var ComId = HttpContext.Session.GetInt32("ComId");

            var concernBank = concernBankRepository.GetAllForDropDown();
            return Json(concernBank);
        }

        [HttpPost]
        [AllowAnonymous]
        public IActionResult GetBankAccountNameByBankAccNo(int BankAccountNoId)
        {
            var openingBankId = bankAccountNoRepository.All().Where(x => x.Id == BankAccountNoId).FirstOrDefault().OpeningBankId;
            var concernBankData = concernBankRepository.All().Where(x => x.Id == openingBankId)
                .Select(x => new
                {
                    x.Id,
                    x.OpeningBankName
                }).FirstOrDefault();
            return Json(concernBankData);
        }

        [AllowAnonymous]
        public JsonResult GetBuyerBank()
        {
            var ComId = HttpContext.Session.GetInt32("ComId");

            var buyerBank = supplierBankAccountNoRepository.GetAllForDropDown();
            return Json(buyerBank);
        }

        [AllowAnonymous]
        public JsonResult GetLCType()
        {
            var ComId = HttpContext.Session.GetInt32("ComId");

            var lctype = lCTypeRepository.GetAllForDropDown();
            return Json(lctype);
        }

        [AllowAnonymous]
        public JsonResult GetUnit()
        {
            var ComId = HttpContext.Session.GetInt32("ComId");

            var unit = _unitRepository.GetAllForDropDown();
            return Json(unit);
        }

        [AllowAnonymous]
        public JsonResult GetCurrencies()
        {
            var ComId = HttpContext.Session.GetInt32("ComId");

            var currency = countryRepository.GetCurrencyList();
            return Json(currency);
        }

        [AllowAnonymous]
        public JsonResult GetTradeTerm()
        {
            var ComId = HttpContext.Session.GetInt32("ComId");

            var tradeTerm = tradeTermRepository.GetAllForDropDown();
            return Json(tradeTerm);
        }

        [AllowAnonymous]
        public JsonResult GetLoadingPort()
        {
            var ComId = HttpContext.Session.GetInt32("ComId");

            var currency = loadingRepository.GetAllForDropDown();
            return Json(currency);
        }

        [AllowAnonymous]
        public JsonResult GetCountryOfOrigin()
        {
            var ComId = HttpContext.Session.GetInt32("ComId");

            var currency = loadingRepository.GetAllForDropDown();
            return Json(currency);
        }

        [AllowAnonymous]
        public JsonResult GetPortOfDestination()
        {
            var ComId = HttpContext.Session.GetInt32("ComId");

            var currency = destinationRepository.GetAllForDropDown();
            return Json(currency);
        }

        [AllowAnonymous]
        public JsonResult GetDischargePort()
        {
            var ComId = HttpContext.Session.GetInt32("ComId");

            var currency = dischargeRepository.GetAllForDropDown();
            return Json(currency);
        }

        [AllowAnonymous]
        public JsonResult GetPaymentTerms()
        {
            var ComId = HttpContext.Session.GetInt32("ComId");

            var currency = paymentTermsRepository.GetAllForDropDown();
            return Json(currency);
        }

        [AllowAnonymous]
        public JsonResult GetCommercialType()
        {
            var ComId = HttpContext.Session.GetInt32("ComId");

            var currency = CommercialTypeRepository.GetAllForDropDown();
            return Json(currency);
        }

        [AllowAnonymous]
        public JsonResult GetDaylist()
        {
            var ComId = HttpContext.Session.GetInt32("ComId");

            var currency = dayListRepository.GetAllForDropDown();
            return Json(currency);
        }

        [AllowAnonymous]
        public JsonResult GetLCStatus()
        {
            var ComId = HttpContext.Session.GetInt32("ComId");

            var status = lcStatusRepository.GetAllForDropDown();
            return Json(status);
        }

        [AllowAnonymous]
        public JsonResult GetDestination()
        {
            var ComId = HttpContext.Session.GetInt32("ComId");

            var status = destinationRepository.GetAllForDropDown();
            return Json(status);
        }

        [AllowAnonymous]
        public JsonResult GetShipMode()
        {
            var ComId = HttpContext.Session.GetInt32("ComId");

            var status = shipModeRepository.GetAllForDropDown();
            return Json(status);
        }

        [AllowAnonymous]
        public JsonResult GetSupplier()
        {
            var ComId = HttpContext.Session.GetInt32("ComId");

            var supplier = supplierRepository.GetAllForDropDown();
            return Json(supplier);
        }

        [HttpGet]
        [AllowAnonymous]
        public IActionResult getBuyerPODetails(int BuyerPOId)
        {
            var buyerpo = buyerPOMasterRepository.All().Where(x => x.Id == BuyerPOId).Include(x => x.Style).FirstOrDefault();

            return Json(new { Success = 1, data = buyerpo, ex = "Data no found" });
        }

        [AllowAnonymous]
        public JsonResult GetBuyerPOSearchList(int? CategoryId, bool IncludingInative, int pageNo = 1, decimal pageSize = 10, string searchquery = "", string dropdownSearch = "")
        {
            try
            {
                if (dropdownSearch == null)
                {
                    dropdownSearch = "";
                }
                var buyerpoList = buyerPOMasterRepository.All().Include(x => x.Style).Where(x => x.IsDelete == false);

                if (searchquery?.Length > 1)
                {

                    var searchitem = JsonConvert.DeserializeObject<BuyerPOListFilterData>(searchquery);

                    if (searchitem.pageIndex != null)
                    {
                        pageNo = searchitem.pageIndex.GetValueOrDefault();
                        pageSize = searchitem.pageSize.GetValueOrDefault();

                    }


                    if (searchitem.BuyerPO != null)
                    {
                        buyerpoList = buyerpoList.Where(x => x.BuyerPO.ToLower().Contains(searchitem.BuyerPO.ToLower()));
                    }
                }

                if ((dropdownSearch.Length > 1) || (dropdownSearch == ""))
                {
                    buyerpoList = buyerpoList.Where(x => x.BuyerPO.ToLower().Contains(dropdownSearch.ToLower()));
                }



                decimal TotalRecordCount = buyerpoList.Count();
                var PageCountabc = decimal.Parse((TotalRecordCount / pageSize).ToString());
                var PageCount = Math.Ceiling(PageCountabc);





                decimal skip = (pageNo - 1) * pageSize;

                int total = buyerpoList.Count();



                var query = from e in buyerpoList.Include(x => x.Style).Where(x => x.IsDelete == false)
                            select new
                            {
                                Id = e.Id,
                                BuyerPO = e.BuyerPO,
                                StyleName = e.Style.StyleNo,
                                UnitPrice = e.UnitPrice,
                                TotalValue = e.TotalAmount,
                                OrderQty = e.TotalQuantity
                            };


                var abcd = query.OrderByDescending(x => x.Id).Skip(int.Parse(skip.ToString())).Take(int.Parse(pageSize.ToString())).ToList();// Take(50);
                var pageinfo = new PagingInfo();
                pageinfo.PageCount = int.Parse(PageCount.ToString());
                pageinfo.PageNo = pageNo;
                pageinfo.PageSize = int.Parse(pageSize.ToString());
                pageinfo.TotalRecordCount = int.Parse(TotalRecordCount.ToString());

                return Json(new { Success = 1, error = false, BuyerPOList = abcd, PageInfo = pageinfo });


            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        [AllowAnonymous]
        [HttpPost]
        public IActionResult MasterLCCreation([FromBody] MasterLCModel model)
        {
            try
            {
                var errors = ModelState.Where(x => x.Value.Errors.Any())
                .Select(x => new { x.Key, x.Value.Errors });

                var ComId = HttpContext.Session.GetInt32("ComId");

                if (model.Id == 0)
                {
                    masterLCRepository.Insert(model);
                    return Json(new { error = false, message = "Master LC saved successfully" });

                }
                else
                {
                    masterLCRepository.Update(model, model.Id);

                    foreach (COM_MasterLC_Details item in model.COM_MasterLC_Details)
                    {

                        if (item.Id > 0)
                        {
                            if (item.IsDelete == true)
                            {
                                int z = item.Id;
                                masterLCDetailsRepository.Delete(item);
                                //db.Entry(item).State = EntityState.Deleted;
                                //db.COM_MasterLC_Detailss.Remove(item);

                            }
                            else
                            {
                                if (item.isTransaction == true)
                                {
                                    masterLCDetailsRepository.Update(item, item.Id);

                                    //db.Entry(item).State = EntityState.Modified;
                                }
                            }

                        }
                        else
                        {
                            masterLCDetailsRepository.Insert(item);
                        }
                    }

                    //tranlog.TransactionLog(RouteData.Values["controller"].ToString(), RouteData.Values["action"].ToString(), TempData["Message"].ToString(), model.Id.ToString(), "Update", model.Id.ToString());
                    return Json(new { error = false, message = "Master LC Updated successfully" });


                    //masterLCRepository.Update(model, model.Id);

                    //var data = masterLCDetailsRepository.All().Where(x => x.MasterLCID == model.Id).ToList();
                    //foreach (var item in data)
                    //{
                    //    masterLCDetailsRepository.Delete(item);
                    //}

                    //foreach (var item in model.COM_MasterLC_Details)
                    //{
                    //    item.MasterLCID = model.Id;
                    //    item.Id = 0;

                    //    masterLCDetailsRepository.Insert(item);
                    //}

                    //return Json(new { error = false, message = "Master LC Updated successfully" });



                }

            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        [AllowAnonymous]
        [HttpPost]
        public IActionResult DetailsLCTempCreation([FromBody] List<COM_MasterLC_Details_Temp> buyerPOData)
        {
            if (buyerPOData == null || !buyerPOData.Any())
            {
                return BadRequest("Invalid data.");
            }
            var ComId = HttpContext.Session.GetInt32("ComId");

            foreach (var item in buyerPOData)
            {
                masterLCDetailsTempRepository.Insert(item);
            }

            SqlParameter[] sqlParameter1 = new SqlParameter[1];

            sqlParameter1[0] = new SqlParameter("@ComId", ComId);

            var datasetabc = new System.Data.DataSet();
            datasetabc = Helper.ExecProcMapDS("get_UniqueBuyerPO", sqlParameter1);

            var masterTable = datasetabc.Tables[0];
            var rowCount = masterTable.Rows.Count;

            if (buyerPOData.Count != rowCount)
            {
                return Json(new { Success = 1, data = masterTable, message = "Duplicate Export PO No.  exists. Where Unique is " + rowCount + " rows" });
            }

            return Json(new { Success = 0, data = masterTable, message = "Data Loaded successfully" });

        }

        [HttpGet]
        [AllowAnonymous]
        public IActionResult GetMasterLCDetails(int id)
        {

            var data = masterLCRepository.All().Where(x => x.Id == id).Include(x => x.COM_MasterLC_Details);

            var ComId = HttpContext.Session.GetInt32("ComId");

            SqlParameter[] sqlParameter1 = new SqlParameter[2];

            sqlParameter1[0] = new SqlParameter("@ComId", ComId);
            sqlParameter1[1] = new SqlParameter("@MasterLCId", id);

            var datasetabc = new System.Data.DataSet();
            datasetabc = Helper.ExecProcMapDS("get_MasterLCDetails", sqlParameter1);

            var masterTable = datasetabc.Tables[0];


            var query = (from e in data
                         select new
                         {
                             e.Id,
                             e.CommercialCompanyId,
                             e.BuyerGroupID,
                             e.BuyerID,
                             e.LCMargin,
                             e.BankAccountId,
                             e.OpeningBankId,
                             e.LienBankId,
                             e.LCTypeId,
                             e.LCRefNo,
                             e.MasterLCValueManual,
                             e.ExportLCValueManual,
                             e.SalesContractIssueDate,
                             e.LCExpirydate,
                             e.unitId,
                             e.UnitMasterId,
                             e.CurrencyId,
                             e.BuyerLCRef,
                             e.LCOpenDate,
                             e.TotalLCQty,
                             e.LCValue,
                             e.TradeTermId,
                             e.PortOfLoadingId,
                             e.PortOfDischargeId,
                             e.DestinationId,
                             e.ShipModeId,
                             e.PaymentTermsId,
                             e.DayListId,
                             e.LCStatusId,
                             e.DestinationContract,
                             e.Remarks,
                             e.FileNo,
                             e.RemainingContractValue,
                             e.LCNOforImport,
                             e.CommercialTypeId,
                             e.CMTPermission,
                             e.PINo,
                             e.PIDate,
                             COM_MasterLC_Details = masterTable
                             //e.COM_MasterLC_Details.Select(x => new
                             //{
                             //    x.Id,
                             //    x.ExportPONo,
                             //    x.BuyerPOId,
                             //    BuyerPO = x.BuyerPOId != null ? x.BuyerPO_Master.BuyerPO : null,
                             //    UnitName = x.Unit.UnitName,
                             //    x.UnitMasterId,
                             //    x.StyleName,
                             //    x.ItemName,
                             //    x.HSCode,
                             //    x.Fabrication,
                             //    x.OrderQty,
                             //    x.Factor,
                             //    x.QtyInPcs,
                             //    x.UnitPrice,
                             //    x.TotalValue,
                             //    x.ShipmentDate,
                             //    x.Destination,
                             //    x.ContractNo,
                             //    x.OrderType,
                             //    x.CatNo,
                             //    x.DeliveryNo,
                             //    x.DestinationPO,
                             //    x.Kimball,
                             //    x.ColorCode,
                             //    x.ContractDate,
                             //    x.IsDelete,
                             //    IsExist = 0
                             //})

                         }).FirstOrDefault();



            return Json(new { Success = 1, data = query, ex = "Data Loaded Successfully" });
        }

        [AllowAnonymous]
        [HttpGet]
        public IActionResult Export(string Type)
        {
            ViewBag.ListType = Type ?? "MasterLC";
            return View();
        }

        [AllowAnonymous]
        [HttpGet]
        public IActionResult GetMasterLCList(string fromDate = "", string toDate = "", int page = 1, decimal size = 5, string searchquery = "")
        {
            try
            {
                var errors = ModelState.Where(x => x.Value.Errors.Any())
                .Select(x => new { x.Key, x.Value.Errors });

                var Userid = HttpContext.Session.GetInt32("UserId");
                var ComId = HttpContext.Session.GetInt32("ComId");
                DateTime fromDateValue = Convert.ToDateTime(fromDate);
                DateTime toDateValue = Convert.ToDateTime(toDate);

                var masterlc = masterLCRepository.All().Where(x => x.IsDelete == false);

                var taburesquest = JsonConvert.DeserializeObject<TabulatorRequest>(searchquery);

                if (taburesquest.Filter.Count == 0)
                {
                    masterlc = masterlc.Where(x => x.SalesContractIssueDate >= fromDateValue.Date && x.SalesContractIssueDate <= toDateValue.Date);

                }

                foreach (var item in taburesquest.Filter)
                {
                    if (item.Field == "LCRefNo")
                    {
                        masterlc = masterlc.Where(x => x.LCRefNo.ToLower().Contains(item.Value.ToLower()));
                    }
                    if (item.Field == "Company")
                    {
                        masterlc = masterlc.Where(x => x.CommercialCompanies.CompanyName.ToLower().Contains(item.Value.ToLower()));
                    }
                    if (item.Field == "BuyerGroup")
                    {
                        masterlc = masterlc.Where(x => x.BuyerGroups.BuyerGroupName.ToLower().Contains(item.Value.ToLower()));
                    }
                    if (item.Field == "Buyer")
                    {
                        masterlc = masterlc.Where(x => x.BuyerInformations.Name.ToLower().Contains(item.Value.ToLower()));
                    }
                    if (item.Field == "ConcernBank")
                    {
                        masterlc = masterlc.Where(x => x.OpeningBank.OpeningBankName.ToLower().Contains(item.Value.ToLower()));
                    }
                    if (item.Field == "BuyerBank")
                    {
                        masterlc = masterlc.Where(x => x.LienBank.LienBankName.ToLower().Contains(item.Value.ToLower()));
                    }

                }


                decimal TotalRecordCount = masterlc.Count();
                var PageCountabc = decimal.Parse((TotalRecordCount / taburesquest.Size).ToString());
                var PageCount = Math.Ceiling(PageCountabc);

                int skip = (taburesquest.Page - 1) * taburesquest.Size;

                var query = (from x in masterlc.Include(x => x.CommercialCompanies).Include(x => x.BuyerGroups).Include(x => x.BuyerInformations).Include(x => x.OpeningBank).Include(x => x.LienBank)
                             select new
                             {
                                 Id = x.Id,
                                 LCRefNo = x.LCRefNo,
                                 Company = x.CommercialCompanies.CompanyName,
                                 BuyerGroup = x.BuyerGroups.BuyerGroupName,
                                 Buyer = x.BuyerInformations.Name,
                                 ConcernBank = x.OpeningBank.OpeningBankName,
                                 BuyerBank = x.LienBank.LienBankName,


                             }).ToList();

                var abcd = query.OrderByDescending(x => x.Id).Skip(skip).Take(taburesquest.Size).ToList();
                var pageinfo = new PagingInfo();
                pageinfo.PageCount = int.Parse(PageCount.ToString());
                pageinfo.PageNo = taburesquest.Page;
                pageinfo.PageSize = taburesquest.Size;
                pageinfo.TotalRecordCount = int.Parse(TotalRecordCount.ToString());

                //return  abcd;
                return Json(new { Success = 1, error = false, data = abcd, page = taburesquest.Page, size = taburesquest.Size, last_page = pageinfo.PageCount, total = pageinfo.TotalRecordCount });

                //return Json(new { Success = 1, error = false, data = data });

            }
            catch (Exception ex)
            {
                return Json(new { Success = 0, ex = ex.InnerException?.InnerException?.Message ?? ex.Message });
            }
        }

        [HttpGet]
        [OverridableAuthorize]
        public IActionResult DeleteMasterLC(int Id)
        {
            try
            {
                var data = masterLCRepository.All().Where(x => x.Id == Id).FirstOrDefault();


                masterLCRepository.Delete(data);

                return Json(new { success = "1", msg = "Deleted Successfully" });
            }
            catch
            {

                return Json(new { success = "0", msg = "Occuring error while deleting" });

            }

        }


        [AllowAnonymous]
        public ActionResult PrintMLCSC(int? id, string type)
        {
            try
            {
                var comid = HttpContext.Session.GetInt32("ComId");

                var reportname = "rptMasterLCSalesContact";


                if (type == null)
                {
                    type = "PDF";
                }

                clsReport.rptList = null;

                HttpContext.Session.SetString("ReportPath", "~/ReportViewer/CommercialReport/" + reportname + ".rdlc");
                HttpContext.Session.SetString("ReportQuery", "Exec rptMasterLCSalesContact '" + id + "', '" + comid + "'");


                string filename = "MasterLC";
                HttpContext.Session.SetString("PrintFileName", filename.Replace(".", "").Replace(" ", "").Replace(",", "").Replace("\"", ""));



                string DataSourceName = "DataSet1";

                clsReport.strReportPathMain = HttpContext.Session.GetString("ReportPath");
                clsReport.strQueryMain = HttpContext.Session.GetString("ReportQuery");
                clsReport.strDSNMain = DataSourceName;

                string callBackUrl = this.Url.Action("Index", "ReportViewer", new { reporttype = type });
                var redirectUrl = callBackUrl;


                return Redirect(redirectUrl);
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }

        [AllowAnonymous]
        public ActionResult PrintMLCEX(int? id, string type)
        {
            try
            {
                var comid = HttpContext.Session.GetInt32("ComId");

                var reportname = "rptMasterLCWiseExport";


                if (type == null)
                {
                    type = "PDF";
                }

                clsReport.rptList = null;

                HttpContext.Session.SetString("ReportPath", "~/ReportViewer/CommercialReport/" + reportname + ".rdlc");
                HttpContext.Session.SetString("ReportQuery", "Exec rptMasterLCWiseExport '" + id + "', '" + comid + "'");

                string filename = "GroupLC";
                HttpContext.Session.SetString("PrintFileName", filename.Replace(".", "").Replace(" ", "").Replace(",", "").Replace("\"", ""));



                string DataSourceName = "DataSet1";

                clsReport.strReportPathMain = HttpContext.Session.GetString("ReportPath");
                clsReport.strQueryMain = HttpContext.Session.GetString("ReportQuery");
                clsReport.strDSNMain = DataSourceName;

                string callBackUrl = this.Url.Action("Index", "ReportViewer", new { reporttype = type });
                var redirectUrl = callBackUrl;


                return Redirect(redirectUrl);
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }
        [AllowAnonymous]
        public ActionResult PrintBBLCMargin(int? id, string type)
        {
            try
            {

                var comid = HttpContext.Session.GetInt32("ComId");

                var reportname = "rptBBLCMarginAnalysis_Main";


                if (type == null)
                {
                    type = "PDF";
                }

                clsReport.rptList = null;
                var template = "GROUPLC";

                HttpContext.Session.SetString("ReportPath", "~/ReportViewer/CommercialReport/" + reportname + ".rdlc");
                HttpContext.Session.SetString("ReportQuery", "Exec rptBBLCMarginAnalysis '" + id + "', '" + comid + "', '" + template + "'");

                string filename = "Margin Analysis";
                HttpContext.Session.SetString("PrintFileName", filename.Replace(".", "").Replace(" ", "").Replace(",", "").Replace("\"", ""));

                string DataSourceName = "DataSet1";

                clsReport.strReportPathMain = HttpContext.Session.GetString("ReportPath");
                clsReport.strQueryMain = HttpContext.Session.GetString("ReportQuery");
                clsReport.strDSNMain = DataSourceName;

                //Dictionary<int, subReport> postData = new Dictionary<int, subReport>();
                postData.Add(1, new subReport("rptBBLCMarginAnalysis_Sub", "", "DataSet1", "Exec dbo.rptBBLCMarginAnalysis '" + id + "','" + comid + "','BBLC'"));
                HttpContext.Session.SetObject("rptList", postData);

                string callBackUrl = this.Url.Action("Index", "ReportViewer", new { reporttype = type });
                var redirectUrl = callBackUrl;


                return Redirect(redirectUrl);
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }


        #endregion


        #region GROUP LC region

        [OverridableAuthorize]
        //public IActionResult CreateGroupLC(int grouplcid = 0)
        public IActionResult AddGroupLC(int grouplcid = 0)
        {

            ViewBag.ActionType = "Create";
            ViewBag.GroupLCID = grouplcid;
            return View();
        }

        [OverridableAuthorize]
        //public IActionResult CreateGroupLC(int grouplcid = 0)
        public IActionResult UpdateGroupLC(int grouplcid = 0)
        {

            ViewBag.ActionType = "Edit";
            ViewBag.GroupLCID = grouplcid;
            return View("AddGroupLC");
        }

        [HttpPost]
        [AllowAnonymous]
        public IActionResult getMasterLCDataForGroupLC(int buyerid = 0)
        {
            //var groupLCData = _masterLCRepository.All().Where(x => x.BuyerID == buyerid)
            //    .Select(x => new
            //    {
            //        MasterLCID = x.Id,
            //        x.ComId,
            //        x.LCRefNo,
            //        x.LCOpenDate,
            //        x.TotalLCQty,
            //        x.LCValue,
            //        x.ExportLCValueManual

            //    }).ToList();

            var ComId = HttpContext.Session.GetInt32("ComId");
            var UserId = HttpContext.Session.GetInt32("UserId");
            var queryname = "getMasterLCData";
            var viewquery = $"Exec {queryname} '{ComId}','{buyerid}'";
            Console.WriteLine(viewquery);
            SqlParameter[] parameters = new SqlParameter[2];
            parameters[0] = new SqlParameter("@ComId", ComId);
            parameters[1] = new SqlParameter("@BuyerID ", buyerid);

            var datasetabc = new System.Data.DataSet();
            datasetabc = Helper.ExecProcMapDS(queryname, parameters);

            return Json(new { data = datasetabc, ex = "" });
        }



        [HttpPost]
        [AllowAnonymous]
        public IActionResult SaveGroupLC([FromBody] GroupLC_MainModel model)
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

                        groupLCMainRepository.Update(model, model.Id);

                        var previousitem = groupLCSubRepository.All().Where(x => x.GroupLCId == model.Id).ToList();
                        var tmp = previousitem.Where(x => !model.GroupLC_Sub.Any(z => x.Id == z.Id)).ToList();
                        groupLCSubRepository.RemoveRange(tmp);
                        foreach (GroupLC_SubModel item in model.GroupLC_Sub)
                        {
                            if (item.Id > 0)
                            {
                                item.GroupLCId = model.Id;
                                groupLCSubRepository.Update(item, item.Id);

                            }
                            else
                            {
                                item.GroupLCId = model.Id;
                                groupLCSubRepository.Insert(item);

                            }
                        }
                        TempData["Message"] = "Data Update Successfully";
                        TempData["Status"] = "2";
                        return Json(new { error = false, message = "Updated successfully", Id = model.Id });
                    }
                    else
                    {

                        foreach (var item in model.GroupLC_Sub.Where(x => x.IsDelete == false))
                        {

                            item.CreateDate = DateTime.Now;
                            item.UpdateDate = DateTime.Now;
                            item.ComId = int.Parse(ComId.ToString());
                            item.LuserId = int.Parse(UserId.ToString());
                            item.GroupLCId = model.Id;
                        }
                        groupLCMainRepository.Insert(model);
                        TempData["Message"] = "Data Save Successfully";
                        TempData["Status"] = "1";
                        return Json(new { error = false, message = "Saved successfully", Id = model.Id });
                    }
                }
                else
                {

                    return Json(new { error = true, message = "failed to save" });
                }



            }
            catch (Exception ex)
            {

                return Json(new { error = true, message = ex.Message });
            }
        }


        [HttpGet]
        [AllowAnonymous]
        public IActionResult getGroupLCData(int id = 0)
        {
            var getallGroupLC = groupLCMainRepository.All().Where(x => x.Id == id);
            var query = getallGroupLC.Include(x => x.GroupLC_Sub)
                .Select(x => new
                {
                    x.Id,
                    x.ComId,
                    x.BuyerId,
                    x.CommercialCompanyId,
                    x.GroupLCAmdNo,
                    x.Margin,
                    x.FreightChargePer,
                    x.GroupLCRefName,
                    x.TotalGroupLCValue,
                    x.TotalGroupLCValueManual,
                    x.TotalGroupLCQty,
                    FirstShipDate = x.FirstShipDate != null ? x.FirstShipDate.Value.ToString("dd-MMM-yyyy") : null,
                    LastShipDate = x.LastShipDate != null ? x.LastShipDate.Value.ToString("dd-MMM-yyyy") : null,
                    GroupLc = x.GroupLC_Sub.Select(y => new
                    {
                        grouplcid = y.GroupLCId,
                        MasterLCID = y.MasterLCID,
                        LCRefNo = y.MasterLC.LCRefNo,
                        //LCOpenDate = y.MasterLC.LCOpenDate.ToString("dd-MMM-yyyy"),
                        LCOpenDate = y.MasterLC.LCOpenDate != null ? y.MasterLC.LCOpenDate.Value.ToString("dd-MMM-yyyy") : null,
                        TotalLCQty = y.MasterLC.COM_MasterLC_Details.Sum(x => x.OrderQty),
                        LCValue = y.MasterLC.COM_MasterLC_Details.Sum(x => x.TotalValue),
                        ExportLCValueManual = y.MasterLC.ExportLCValueManual,
                    })
                }).FirstOrDefault();
            return Json(query);
        }


        [AllowAnonymous]
        public JsonResult GetGroupLCist(string fromDate = "", string toDate = "", int buyerId = 0, int concernid = 0, int page = 1, decimal size = 5, string searchquery = "")
        {
            try
            {
                var CurrentUserId = HttpContext.Session.GetInt32("UserId");
                var ComId = HttpContext.Session.GetInt32("ComId");
                DateTime fromDateValue = Convert.ToDateTime(fromDate);
                DateTime toDateValue = Convert.ToDateTime(toDate);
                var purchaselist = groupLCMainRepository.All().Where(x => x.IsDelete == false);

                //if (!string.IsNullOrEmpty(fromDate))
                //{
                //    DateTime fromDateValue = Convert.ToDateTime(fromDate);
                //    purchaselist = groupLCMainRepository.All().Where(x => x.FirstShipDate >= fromDateValue.Date);
                //}
                //if (!string.IsNullOrEmpty(toDate))
                //{
                //    DateTime toDateValue = Convert.ToDateTime(toDate);
                //    purchaselist = groupLCMainRepository.All().Where(x => x.LastShipDate <= toDateValue.Date);
                //}


                var taburesquest = JsonConvert.DeserializeObject<TabulatorRequest>(searchquery);

                if (taburesquest.Filter.Count == 0)
                {
                    purchaselist = purchaselist.Where(x => x.FirstShipDate >= fromDateValue.Date && x.FirstShipDate <= toDateValue.Date);

                }

                foreach (var item in taburesquest.Filter)
                {
                    if (item.Field == "GroupLCRefName")
                    {
                        purchaselist = purchaselist.Where(x => x.GroupLCRefName.ToLower().Contains(item.Value.ToLower()));
                    }
                    if (item.Field == "GroupLCAmdNo")
                    {
                        purchaselist = purchaselist.Where(x => x.GroupLCAmdNo.ToLower().Contains(item.Value.ToLower()));
                    }
                    if (item.Field == "Name")
                    {
                        purchaselist = purchaselist.Where(x => x.Buyers.Name.ToLower().Contains(item.Value.ToLower()));
                    }
                    if (item.Field == "CompanyName")
                    {
                        purchaselist = purchaselist.Where(x => x.CommercialCompanies.CompanyName.ToLower().Contains(item.Value.ToLower()));
                    }
                    if (item.Field == "TotalGroupLCQty")
                    {
                        purchaselist = purchaselist.Where(x => x.TotalGroupLCQty.ToString().ToLower().Contains(item.Value.ToLower()));
                    }
                    if (item.Field == "TotalGroupLCValue")
                    {
                        purchaselist = purchaselist.Where(x => x.TotalGroupLCValue.ToString().ToLower().Contains(item.Value.ToLower()));
                    }
                    if (item.Field == "TotalGroupLCValueManual")
                    {
                        purchaselist = purchaselist.Where(x => x.TotalGroupLCValueManual.ToString().ToLower().Contains(item.Value.ToLower()));
                    }
                }

                if (concernid > 0)
                {
                    purchaselist = groupLCMainRepository.All().Where(x => x.CommercialCompanyId == concernid);
                }
                if (buyerId > 0)
                {
                    purchaselist = groupLCMainRepository.All().Where(x => x.BuyerId == buyerId);
                }

                decimal TotalRecordCount = purchaselist.Count();
                var PageCountabc = decimal.Parse((TotalRecordCount / taburesquest.Size).ToString());
                var PageCount = Math.Ceiling(PageCountabc);

                int skip = (taburesquest.Page - 1) * taburesquest.Size;


                var query = from e in purchaselist.Include(x => x.GroupLC_Sub).Include(x => x.Buyers).Include(x => x.CompanyList)
                            select new
                            {
                                Id = e.Id,
                                e.ComId,
                                e.GroupLCRefName,
                                e.GroupLCAmdNo,
                                e.Buyers.Name,
                                e.TotalGroupLCQty,
                                e.TotalGroupLCValue,
                                e.TotalGroupLCValueManual,
                                e.CommercialCompanies.CompanyName,
                            };
                var abcd = query.OrderByDescending(x => x.Id).Skip(skip).Take(taburesquest.Size).ToList();
                var pageinfo = new PagingInfo();
                pageinfo.PageCount = int.Parse(PageCount.ToString());
                pageinfo.PageNo = taburesquest.Page;
                pageinfo.PageSize = taburesquest.Size;
                pageinfo.TotalRecordCount = int.Parse(TotalRecordCount.ToString());

                //return  abcd;
                return Json(new { Success = 1, error = false, data = abcd, page = taburesquest.Page, size = taburesquest.Size, last_page = pageinfo.PageCount, total = pageinfo.TotalRecordCount });

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }



        [OverridableAuthorize]
        public JsonResult DeleteGroupLc(int id)
        {
            try
            {


                var model = groupLCMainRepository.Find(id);
                var modelSub = groupLCSubRepository.All().Where(x => x.GroupLCId == model.Id).ToList();

                if (model != null)
                {

                    groupLCSubRepository.RemoveRange(modelSub);
                    groupLCMainRepository.Delete(model);

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

        public IActionResult Export()
        {
            return View();
        }
        #endregion


        #region ExportInvoice


        [OverridableAuthorize]
        [HttpGet]
        //public IActionResult ExportInvoice(int id = 0)
        public IActionResult AddExportInvoice(int id = 0)
        {
            var ComId = HttpContext.Session.GetInt32("ComId");
            ViewBag.ActionType = "Create";

            ViewBag.Id = id;

            //var buyerPO = buyerPOMasterRepository.All().Where(p => p.ComId == ComId).ToList();

            //SelectList buyerPOList = new SelectList(buyerPO, "Id", "BuyerPO");
            //ViewData["BuyerPOList"] = buyerPOList;

            return View();
        }

        [OverridableAuthorize]
        [HttpGet]
        public IActionResult UpdateExportInvoice(int id = 0)
        {
            var ComId = HttpContext.Session.GetInt32("ComId");
            ViewBag.ActionType = "Edit";

            ViewBag.Id = id;

            return View("AddExportInvoice");
        }

        //[AllowAnonymous]
        //public JsonResult GetMasterLC()
        //{
        //    var ComId = HttpContext.Session.GetInt32("ComId");

        //    var masterLC = masterLCRepository.All().Where(p => p.ComId == ComId).ToList();

        //    foreach (var item in masterLC)
        //    {
        //        if (item.LCRefNo == null)
        //        {
        //            item.LCRefNo = "Not found";
        //        }
        //    }

        //    SelectList masterLCList = new SelectList(masterLC, "Id", "LCRefNo");
        //    return Json(masterLCList);
        //}

        [AllowAnonymous]
        public JsonResult GetMasterLC(string query)
        {
            var ComId = HttpContext.Session.GetInt32("ComId");

            var masterLC = masterLCRepository.All()
                  .Where(x => x.LCRefNo.ToLower().Contains(query.ToLower()) && x.ComId == ComId)
                .Select(p => new
                {
                    Id = p.Id,
                    LCRefNo = p.LCRefNo,
                })
                .Take(10)
                .ToList();

            var masterLCList = masterLC.ToList();
            return Json(masterLCList);
        }

        [AllowAnonymous]
        public JsonResult ExportInvoiceList()
        {
            var ComId = HttpContext.Session.GetInt32("ComId");

            var masterLC = exportInvoiceMasterRepository.All().Where(p => p.ComId == ComId).ToList();

            foreach (var item in masterLC)
            {
                if (item.InvoiceNo == null)
                {
                    item.InvoiceNo = "Not found";
                }
            }

            SelectList InvoiceNo = new SelectList(masterLC, "Id", "InvoiceNo");
            return Json(InvoiceNo);
        }
        [AllowAnonymous]
        public JsonResult GroupLCList()
        {
            var ComId = HttpContext.Session.GetInt32("ComId");

            var masterLC = groupLCMainRepository.All().Where(p => p.ComId == ComId).ToList();

            foreach (var item in masterLC)
            {
                if (item.GroupLCRefName == null)
                {
                    item.GroupLCRefName = "Not found";
                }
            }

            SelectList InvoiceNo = new SelectList(masterLC, "Id", "GroupLCRefName");
            return Json(InvoiceNo);
        }

        [AllowAnonymous]
        public JsonResult GetNotifyParty()
        {
            var ComId = HttpContext.Session.GetInt32("ComId");

            var notify = notifyPartyRepository.GetAllForDropDown();
            return Json(notify);
        }

        [HttpPost]
        [AllowAnonymous]
        public IActionResult GetNotifyPartyNo(int BuyerId)
        {

            //var customerid = customerRepository.All().Where(x => x.Id == BuyerId).FirstOrDefault().Id;

            var notify = notifyPartyRepository.GetAllForDropDown(BuyerId);
            return Json(notify);
        }

        [AllowAnonymous]
        public JsonResult GetExportInvoiceList(int MasterLCId, int Id, int page = 1, decimal size = 5, string searchquery = "")
        {
            try
            {
                var errors = ModelState.Where(x => x.Value.Errors.Any())
                .Select(x => new { x.Key, x.Value.Errors });

                var userid = HttpContext.Session.GetInt32("UserId");
                var comid = HttpContext.Session.GetInt32("ComId");

                var invoice = exportInvoiceMasterRepository.All().Where(x => x.Id != Id && x.MasterLCId == MasterLCId);

                if (searchquery?.Length > 1)
                {


                }




                decimal TotalRecordCount = invoice.Count();
                var PageCountabc = decimal.Parse((TotalRecordCount / size).ToString());
                var PageCount = Math.Ceiling(PageCountabc);

                decimal skip = (page - 1) * size;



                var query = (from e in invoice
                             select new
                             {
                                 e.Id,
                                 e.InvoiceNo,
                                 e.InvoiceDate,
                                 e.TotalInvoiceQty,
                                 e.TotalValue,
                                 Destination = e.COM_MasterLC.Destination.DestinationName
                             }).ToList();

                var abcd = query.OrderByDescending(x => x.Id).Skip(int.Parse(skip.ToString())).Take(int.Parse(size.ToString())).ToList();
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

        [AllowAnonymous]
        public JsonResult GetBoxCategoryEditor(bool IncludingInative, int pageNo = 1, decimal pageSize = 10, string searchquery = "", string dropdownSearch = "")
        {
            try
            {
                if (dropdownSearch == null)
                {
                    dropdownSearch = "";
                }
                var buyerpoList = boxCategoryRepository.All().Where(x => x.IsDelete == false);

                if (searchquery?.Length > 1)
                {

                    var searchitem = JsonConvert.DeserializeObject<BoxCategoryFilterData>(searchquery);

                    if (searchitem.pageIndex != null)
                    {
                        pageNo = searchitem.pageIndex.GetValueOrDefault();
                        pageSize = searchitem.pageSize.GetValueOrDefault();

                    }


                    if (searchitem.MeasurementName != null)
                    {
                        buyerpoList = buyerpoList.Where(x => x.MeasurementName.ToLower().Contains(searchitem.MeasurementName.ToLower()));
                    }
                    if (searchitem.MeasurementNo != null)
                    {
                        buyerpoList = buyerpoList.Where(x => x.MeasurementNo.ToLower().Contains(searchitem.MeasurementNo.ToLower()));
                    }
                }

                if ((dropdownSearch.Length > 0) || (dropdownSearch == ""))
                {
                    buyerpoList = buyerpoList.Where(x => x.MeasurementName.ToLower().Contains(dropdownSearch.ToLower()) ||
                    x.MeasurementNo.ToLower().Contains(dropdownSearch.ToLower()) ||
                    (x.MeasurementNo + " - " + x.MeasurementName).ToLower().Contains(dropdownSearch.ToLower()));
                }



                decimal TotalRecordCount = buyerpoList.Count();
                var PageCountabc = decimal.Parse((TotalRecordCount / pageSize).ToString());
                var PageCount = Math.Ceiling(PageCountabc);





                decimal skip = (pageNo - 1) * pageSize;

                int total = buyerpoList.Count();



                var query = from e in buyerpoList.Where(x => x.IsDelete == false)
                            select new
                            {
                                Id = e.Id,
                                MeasurementNo = e.MeasurementNo,
                                MeasurementName = e.MeasurementNo + " - " + e.MeasurementName,
                                BoxHeight = e.BoxHeight,
                                BoxWidth = e.BoxWidth,
                                BoxLength = e.BoxLength,
                                Calculation = e.Calculation
                            };


                var abcd = query.OrderByDescending(x => x.Id).Skip(int.Parse(skip.ToString())).Take(int.Parse(pageSize.ToString())).ToList();// Take(50);
                var pageinfo = new PagingInfo();
                pageinfo.PageCount = int.Parse(PageCount.ToString());
                pageinfo.PageNo = pageNo;
                pageinfo.PageSize = int.Parse(pageSize.ToString());
                pageinfo.TotalRecordCount = int.Parse(TotalRecordCount.ToString());

                return Json(new { Success = 1, error = false, ItemDescList = abcd, PageInfo = pageinfo });


            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        [HttpGet]
        [AllowAnonymous]
        public IActionResult GetMasterLCData(int MasterLCId, int Id)
        {

            var data = masterLCRepository.All().Where(x => x.Id == MasterLCId).Include(x => x.COM_MasterLC_Details).Include(x => x.ExportInvoiceMasters);

            var totalShipped = exportInvoiceMasterRepository.All().Where(x => x.MasterLCId == MasterLCId && x.Id != Id).Sum(x => x.TotalInvoiceQty);
            if (totalShipped == null)
            {
                totalShipped = 0;
            }

            var query = (from e in data
                         select new
                         {
                             e.Id,
                             e.BuyerGroupID,
                             e.DestinationId,
                             e.BuyerID,
                             e.CommercialCompanyId,
                             e.PortOfLoadingId,
                             e.PortOfDischargeId,
                             InvoiceNo = e.ExportInvoiceMasters != null ? e.ExportInvoiceMasters.OrderByDescending(m => m.Id).Select(m => m.InvoiceNo).FirstOrDefault() : "",                              
                             //TotalLCQty = e.COM_MasterLC_Details.Sum(x => x.OrderQty),
                             TotalLCQty = 0,
                             e.ShipModeId,
                             //TotalShipped = totalShipped,
                             TotalShipped = 0,
                             //TotalCartonQty = e.COM_MasterLC_Details.Sum(x => x.QtyInPcs),
                             TotalCartonQty = 0,
                             COM_MasterLC_Details = e.COM_MasterLC_Details.Select(x => new
                             {
                                 MasterLCDetailsID = x.Id,
                                 ExportOrderNo = x.ExportPONo,
                                 StyleNo = x.StyleName,
                                 x.ShipmentDate,
                                 x.Destination,
                                 LCQty = x.OrderQty,
                                 InvoiceQty = x.OrderQty,
                                 UnitMasterId = e.unitId,
                                 UnitName = e.UnitMaster.UnitName,
                                 x.UnitPrice,
                                 InvoiceRate = x.UnitPrice,
                                 InvoiceValue = Convert.ToDouble(x.UnitPrice) * x.OrderQty,
                                 x.TotalValue,
                                 x.DestinationPO,
                                 x.ContractDate
                             })

                         }).FirstOrDefault();




            return Json(new { Success = 1, data = query, ex = "Data Loaded Successfully" });
        }

        [HttpGet]
        [AllowAnonymous]
        public IActionResult GetColorSizebyStyle(string styleNo, int MasterLCDetailsID, string ExportOrderNo, string UnitPrice)
        {

            var ComId = HttpContext.Session.GetInt32("ComId");

            SqlParameter[] sqlParameter1 = new SqlParameter[5];

            sqlParameter1[0] = new SqlParameter("@Comid", ComId);
            sqlParameter1[1] = new SqlParameter("@styleNo", styleNo);
            sqlParameter1[2] = new SqlParameter("@MasterLCDetailsID", MasterLCDetailsID);
            sqlParameter1[3] = new SqlParameter("@ExportOrderNo", ExportOrderNo);
            sqlParameter1[4] = new SqlParameter("@UnitPrice", UnitPrice);

            var datasetabc = new System.Data.DataSet();
            datasetabc = Helper.ExecProcMapDS("GetColorSizebyStyle", sqlParameter1);

            var masterTable = datasetabc.Tables[0];

            return Json(new { Success = 1, data = masterTable, ex = "Data Loaded Successfully" });
        }


        [AllowAnonymous]
        [HttpPost]
        public IActionResult ExportInvoiceCreation([FromBody] ExportInvoiceMaster model)
        {
            try
            {

                var ComId = HttpContext.Session.GetInt32("ComId");
                var UserId = HttpContext.Session.GetInt32("UserId");

                if (model.Id == 0)
                {
                    exportInvoiceMasterRepository.Insert(model);
                    return Json(new { error = false, message = "Export Invoice saved successfully" });

                }
                else
                {

                    exportInvoiceMasterRepository.Update(model, model.Id);

                    var data = exportInvoiceDetailsRepository.All().Where(x => x.ExportInvoiceMasterId == model.Id).ToList();
                    foreach (var item in data)
                    {
                        exportInvoiceDetailsRepository.Delete(item);
                    }

                    foreach (var item in model.ExportInvoiceDetails)
                    {
                        item.ExportInvoiceMasterId = model.Id;
                        item.Id = 0;

                        exportInvoiceDetailsRepository.Insert(item);

                    }

                    var truckData = exporInvoiceTruckDetailsRepository.All().Where(x => x.ExportInvoiceMasterId == model.Id).ToList();
                    exporInvoiceTruckDetailsRepository.RemoveRange(truckData);

                    foreach (var item in model.ExportInvoiceTruckDetails)
                    {
                        item.ExportInvoiceMasterId = model.Id;
                        item.Id = 0;

                        exporInvoiceTruckDetailsRepository.Insert(item);

                    }

                    return Json(new { error = false, message = "Export Invoice Updated successfully" });

                }

            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        [AllowAnonymous]
        public ActionResult PrintExportInvoice(int? id, string type, string value)
        {
            try
            {
                var comid = HttpContext.Session.GetInt32("ComId");
                var printDate = DateTime.Parse(HttpContext.Session.GetString("PrintDate"));

                var reportname = exportInvoiceMasterRepository.All().Where(x => x.Id == id).Select(x => x.NotifyPartyFirst.DynamicReports.DynamicReportName).FirstOrDefault();
                if (value == "Packing List")
                {
                    reportname = exportInvoiceMasterRepository.All().Where(x => x.Id == id).Select(x => x.NotifyPartyFirst.DynamicReports.DynamicReportPackingListName).FirstOrDefault();
                }

                if (value == "Out Pass")
                {
                    reportname = "rptCommercialInvoice_Export_PRIMARK_CMT_OutPass";
                }

                if (value == "Out PassEng")
                {
                    reportname = "rptCommercialInvoice_Export_PRIMARK_CMT_OutPassEng";
                }

                if (reportname == null || reportname == "")
                {
                    reportname = "rptCommercialInvoice_Export";
                }

                if (type == null)
                {
                    type = "PDF";
                }
                int WarehouseCount = exportInvoiceMasterRepository.All().Where(x => x.Id == id && x.COM_MasterLC.BuyerGroups.BuyerGroupName.ToUpper().Contains("H&M".ToUpper()) && x.Destination.DestinationNameSearch.ToUpper().Contains("warehouse".ToUpper())).Count();
                if (WarehouseCount > 0) { reportname = "rptCommercialInvoice_Export_HM_Warehouse"; }

                clsReport.rptList = null;

                HttpContext.Session.SetString("ReportPath", "~/ReportViewer/CommercialReport/" + reportname + ".rdlc");
                HttpContext.Session.SetString("ReportQuery", "Exec rptCommercialInvoice_Export '" + id + "', '" + comid + "'");


                string filename = exportInvoiceMasterRepository.All().Where(x => x.Id == id).Select(x => x.BuyerInformation.Name + "_" + x.ShipModel.ShipName + "_" + x.Destination.DestinationName + "_" + x.InvoiceNo).Single();
                HttpContext.Session.SetString("PrintFileName", filename.Replace(".", "").Replace(" ", "").Replace(",", "").Replace(" ", ""));



                string DataSourceName = "DataSet1";

                clsReport.strReportPathMain = HttpContext.Session.GetString("ReportPath");
                clsReport.strQueryMain = HttpContext.Session.GetString("ReportQuery");
                clsReport.strDSNMain = DataSourceName;

                string callBackUrl = this.Url.Action("Index", "ReportViewer", new { reporttype = type });
                var redirectUrl = callBackUrl;


                return Redirect(redirectUrl);
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }

        [AllowAnonymous]
        public ActionResult PrintPackingList(int? id, string type, string value)
        {
            try
            {
                var comid = HttpContext.Session.GetInt32("ComId");

                var reportname = exportInvoiceMasterRepository.All().Where(x => x.Id == id).Select(x => x.NotifyPartyFirst.DynamicReports.DynamicReportName).FirstOrDefault();

                if (value == "De_Packing List")
                {
                    reportname = "rptCommercialInvoice_Export_Details_Packing_List";
                }

                if (reportname == null)
                {
                    reportname = "rptCommercialInvoice_Export_Details_Packing_List";
                }

                if (type == null)
                {
                    type = "PDF";
                }
                int WarehouseCount = exportInvoiceMasterRepository.All().Where(x => x.Id == id && x.COM_MasterLC.BuyerGroups.BuyerGroupName.ToUpper().Contains("H&M".ToUpper()) && x.Destination.DestinationNameSearch.ToUpper().Contains("warehouse".ToUpper())).Count();
                if (WarehouseCount > 0) { reportname = "rptCommercialInvoice_Export_HM_Warehouse"; }

                clsReport.rptList = null;

                HttpContext.Session.SetString("ReportPath", "~/ReportViewer/CommercialReport/" + reportname + ".rdlc");
                HttpContext.Session.SetString("ReportQuery", "Exec rptCommercialInvoice_Export_PackingList_Static '" + id + "', '" + comid + "'");


                string filename = exportInvoiceMasterRepository.All().Where(x => x.Id == id).Select(x => x.BuyerInformation.Name + "_" + x.ShipModel.ShipName + "_" + x.Destination.DestinationName + "_" + x.InvoiceNo).Single();
                HttpContext.Session.SetString("PrintFileName", filename.Replace(".", "").Replace(" ", "").Replace(",", "").Replace(" ", ""));



                string DataSourceName = "DataSet1";

                clsReport.strReportPathMain = HttpContext.Session.GetString("ReportPath");
                clsReport.strQueryMain = HttpContext.Session.GetString("ReportQuery");
                clsReport.strDSNMain = DataSourceName;

                string callBackUrl = this.Url.Action("Index", "ReportViewer", new { reporttype = type });
                var redirectUrl = callBackUrl;


                return Redirect(redirectUrl);
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }


        [AllowAnonymous]
        public ActionResult DetailsPackingList(int? id, string type, string value)
        {
            try
            {
                var comid = HttpContext.Session.GetInt32("ComId");

                var reportname = exportInvoiceMasterRepository.All().Where(x => x.Id == id).Select(x => x.NotifyPartyFirst.DynamicReports.DynamicReportName).FirstOrDefault();

                if (value == "D.Packing List")
                {
                    reportname = exportInvoiceMasterRepository.All().Where(x => x.Id == id).Select(x => x.NotifyPartyFirst.DynamicReports.DynamicReportPackingDetailsName).FirstOrDefault();
                }

                if (reportname == null)
                {
                    reportname = "rptCommercialInvoice_Export_Packing_Details";
                }

                if (type == null)
                {
                    type = "PDF";
                }
                int WarehouseCount = exportInvoiceMasterRepository.All().Where(x => x.Id == id && x.COM_MasterLC.BuyerGroups.BuyerGroupName.ToUpper().Contains("H&M".ToUpper()) && x.Destination.DestinationNameSearch.ToUpper().Contains("warehouse".ToUpper())).Count();
                if (WarehouseCount > 0) { reportname = "rptCommercialInvoice_Export_HM_Warehouse"; }

                clsReport.rptList = null;

                HttpContext.Session.SetString("ReportPath", "~/ReportViewer/CommercialReport/" + reportname + ".rdlc");
                HttpContext.Session.SetString("ReportQuery", "Exec rptCommercialInvoice_Export_PackingList '" + id + "', '" + comid + "'");


                string filename = exportInvoiceMasterRepository.All().Where(x => x.Id == id).Select(x => x.BuyerInformation.Name + "_" + x.ShipModel.ShipName + "_" + x.Destination.DestinationName + "_" + x.InvoiceNo).Single();
                HttpContext.Session.SetString("PrintFileName", filename.Replace(".", "").Replace(" ", "").Replace(",", "").Replace(" ", ""));



                string DataSourceName = "DataSet1";

                clsReport.strReportPathMain = HttpContext.Session.GetString("ReportPath");
                clsReport.strQueryMain = HttpContext.Session.GetString("ReportQuery");
                clsReport.strDSNMain = DataSourceName;

                string callBackUrl = this.Url.Action("Index", "ReportViewer", new { reporttype = type });
                var redirectUrl = callBackUrl;


                return Redirect(redirectUrl);
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }


        [HttpGet]
        [AllowAnonymous]
        public IActionResult GetExportInvoiceDetails(int id)
        {

            var ComId = HttpContext.Session.GetInt32("ComId");

            SqlParameter[] sqlParameter1 = new SqlParameter[2];

            sqlParameter1[0] = new SqlParameter("@Id", id);
            sqlParameter1[1] = new SqlParameter("@Comid", ComId);

            var datasetabc = new System.Data.DataSet();
            datasetabc = Helper.ExecProcMapDS("GetExportInvoiceDetails", sqlParameter1);

            var masterTable = datasetabc.Tables[0];
            var detailsTable = datasetabc.Tables[1];
            var packingTable = datasetabc.Tables[2];
            var truckTable = datasetabc.Tables[3];

            return Json(new { Success = 1, data = masterTable, details = detailsTable, packing = packingTable, truckTable = truckTable, ex = "Data Loaded Successfully" });
        }

        [AllowAnonymous]
        public JsonResult GetExpInvoiceList(string fromDate = "", string toDate = "", int page = 1, decimal size = 5, string searchquery = "")
        {
            try
            {
                var errors = ModelState.Where(x => x.Value.Errors.Any())
                .Select(x => new { x.Key, x.Value.Errors });

                var userid = HttpContext.Session.GetInt32("UserId");
                var comid = HttpContext.Session.GetInt32("ComId");
                DateTime fromDateValue = Convert.ToDateTime(fromDate);
                DateTime toDateValue = Convert.ToDateTime(toDate);

                var invoice = exportInvoiceMasterRepository.All().Where(x => x.IsDelete == false);

                var taburesquest = JsonConvert.DeserializeObject<TabulatorRequest>(searchquery);

                if (taburesquest.Filter.Count == 0)
                {
                    invoice = invoice.Where(x => x.InvoiceDate >= fromDateValue.Date && x.InvoiceDate <= toDateValue.Date);

                }

                foreach (var item in taburesquest.Filter)
                {
                    if (item.Field == "InvoiceNo")
                    {
                        invoice = invoice.Where(x => x.InvoiceNo.ToLower().Contains(item.Value.ToLower()));
                    }
                    if (item.Field == "BuyerName")
                    {
                        invoice = invoice.Where(x => x.BuyerInformation.Name.ToLower().Contains(item.Value.ToLower()));
                    }
                    if (item.Field == "Destination")
                    {
                        invoice = invoice.Where(x => x.COM_MasterLC.Destination.DestinationName.ToLower().Contains(item.Value.ToLower()));
                    }
                    if (item.Field == "ExpNo")
                    {
                        invoice = invoice.Where(x => x.ExpNo.ToLower().Contains(item.Value.ToLower()));
                    }
                    if (item.Field == "BLNo")
                    {
                        invoice = invoice.Where(x => x.BLNo.ToLower().Contains(item.Value.ToLower()));
                    }
                    if (item.Field == "TotalValue")
                    {
                        invoice = invoice.Where(x => x.TotalValue.ToString().ToLower().Contains(item.Value.ToLower()));
                    }
                    if (item.Field == "NotifyParty")
                    {
                        invoice = invoice.Where(x => x.NotifyPartyFirst.NotifyPartyName.ToLower().Contains(item.Value.ToLower()));
                    }
                    if (item.Field == "TotalCartonQty")
                    {
                        invoice = invoice.Where(x => x.TotalCartonQty.ToString().ToLower().Contains(item.Value.ToLower()));
                    }
                    if (item.Field == "NetWeight")
                    {
                        invoice = invoice.Where(x => x.NetWeight.ToString().ToLower().Contains(item.Value.ToLower()));
                    }
                    if (item.Field == "GrossWeight")
                    {
                        invoice = invoice.Where(x => x.GrossWeight.ToString().ToLower().Contains(item.Value.ToLower()));
                    }
                }

                decimal TotalRecordCount = invoice.Count();
                var PageCountabc = decimal.Parse((TotalRecordCount / taburesquest.Size).ToString());
                var PageCount = Math.Ceiling(PageCountabc);

                int skip = (taburesquest.Page - 1) * taburesquest.Size;

                var query = (from e in invoice
                             select new
                             {
                                 e.Id,
                                 e.InvoiceNo,
                                 Destination = e.COM_MasterLC.Destination.DestinationName,
                                 BuyerName = e.BuyerInformation.Name,
                                 e.InvoiceDate,
                                 e.ExpNo,
                                 e.ExpDate,
                                 e.BLNo,
                                 e.BLDate,
                                 e.TotalValue,
                                 NotifyParty = e.NotifyPartyFirst.NotifyPartyName,
                                 e.TotalCartonQty,
                                 e.NetWeight,
                                 e.GrossWeight
                             }).ToList();

                var abcd = query.OrderByDescending(x => x.Id).Skip(skip).Take(taburesquest.Size).ToList();
                var pageinfo = new PagingInfo();
                pageinfo.PageCount = int.Parse(PageCount.ToString());
                pageinfo.PageNo = taburesquest.Page;
                pageinfo.PageSize = taburesquest.Size;
                pageinfo.TotalRecordCount = int.Parse(TotalRecordCount.ToString());

                //return  abcd;
                return Json(new { Success = 1, error = false, data = abcd, page = taburesquest.Page, size = taburesquest.Size, last_page = pageinfo.PageCount, total = pageinfo.TotalRecordCount });

            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        [HttpGet]
        [OverridableAuthorize]
        //public IActionResult InactiveExportInvoice(int Id)
        public IActionResult DeleteExportInvoice(int Id)
        {
            try
            {
                var data = exportInvoiceMasterRepository.All().Where(x => x.Id == Id).FirstOrDefault();


                exportInvoiceMasterRepository.Delete(data);

                return Json(new { success = "1", msg = "Deleted Successfully" });
            }
            catch
            {

                return Json(new { success = "0", msg = "Occuring error while deleting" });

            }

        }
        public class LCDetailsModel
        {
            public int Id { get; set; }
            public string ExportPONo { get; set; }
            public string HsCode { get; set; }
            public string Kimball { get; set; }
            public string Fabrication { get; set; }
            public string CatNo { get; set; }
        }


        [AllowAnonymous]
        [HttpPost]
        public IActionResult UpdateMasterLCDetails([FromBody] LCDetailsModel lcDetails)
        {
            try
            {
                var data = masterLCDetailsRepository.Find(lcDetails.Id);
                data.HSCode = lcDetails.HsCode;
                data.Kimball = lcDetails.Kimball;
                data.Fabrication = lcDetails.Fabrication;
                data.ExportPONo = lcDetails.ExportPONo;
                data.CatNo = lcDetails.CatNo;

                masterLCDetailsRepository.Update(data, data.Id);

                return Json(new { success = true, message = "Details updated successfully." });
            }
            catch (Exception ex)
            {
                // Handle the exception and return an error response
                return Json(new { success = false, message = ex.Message });
            }
        }

        [HttpGet]
        [AllowAnonymous]
        public IActionResult GetNonZeroOrderQtyMasterLC(int MasterLCId)
        {

            var ComId = HttpContext.Session.GetInt32("ComId");

            SqlParameter[] sqlParameter1 = new SqlParameter[2];

            sqlParameter1[0] = new SqlParameter("@MasterLCId", MasterLCId);
            sqlParameter1[1] = new SqlParameter("@Comid", ComId);

            var datasetabc = new System.Data.DataSet();
            datasetabc = Helper.ExecProcMapDS("get_NonZeroOrderQtyMasterLC", sqlParameter1);

            var masterTable = datasetabc.Tables[0];

            return Json(new { Success = 1, data = masterTable, ex = "Data Loaded Successfully" });
        }
        #endregion

        #region Realization

        [OverridableAuthorize]
        [HttpGet]
        //public IActionResult Realization(int id = 0)
        public IActionResult AddRealization(int id = 0)
        {
            var ComId = HttpContext.Session.GetInt32("ComId");
            if (id == 0)
            {
                ViewBag.ActionType = "Create";
            }
            else
            {
                ViewBag.ActionType = "Edit";
            }

            ViewBag.Id = id;


            return View();
        }

        [OverridableAuthorize]
        [HttpGet]
        public IActionResult UpdateRealization(int id = 0)
        {
            var ComId = HttpContext.Session.GetInt32("ComId");
            ViewBag.ActionType = "Edit";

            ViewBag.Id = id;


            return View("AddRealization");
        }


        [HttpGet]
        [AllowAnonymous]
        public IActionResult GetMasterLCForRealization(int MasterLCId, int Id)
        {

            var ComId = HttpContext.Session.GetInt32("ComId");

            var buyer = masterLCRepository.All().Where(x => x.Id == MasterLCId).Select(x => x.BuyerInformations.Name).FirstOrDefault();

            if (Id > 0)
            {
                MasterLCId = exporRealizationMasterRepository.All().Where(x => x.Id == Id).Select(x => x.MasterLCId).FirstOrDefault() ?? MasterLCId;
            }

            SqlParameter[] sqlParameter1 = new SqlParameter[3];

            sqlParameter1[0] = new SqlParameter("@MasterLCId", MasterLCId);
            sqlParameter1[1] = new SqlParameter("@ComId", ComId);
            sqlParameter1[2] = new SqlParameter("@Id", Id);

            var datasetabc = new System.Data.DataSet();
            datasetabc = Helper.ExecProcMapDS("get_MasterLCDataForRealization", sqlParameter1);

            if (Id == 0)
            {
                var masterTable = datasetabc.Tables[0];


                return Json(new { Success = 1, buyer = buyer, data = masterTable, ex = "Data Loaded Successfully" });
            }
            else
            {
                var masterTable = datasetabc.Tables[0];
                var detailsTable = datasetabc.Tables[1];
                var modalTable = datasetabc.Tables[2];


                return Json(new { Success = 1, buyer = buyer, data = masterTable, details = detailsTable, modal = modalTable, ex = "Data Loaded Successfully" });
            }

        }


        [AllowAnonymous]
        [HttpPost]
        public IActionResult RealizationCreation([FromBody] ExportRealization_Master model)
        {
            var ComId = HttpContext.Session.GetInt32("ComId");

            if (model.Id == 0)
            {
                exporRealizationMasterRepository.Insert(model);
                return Json(new { error = false, message = "Realization saved successfully" });

            }
            else
            {

                exporRealizationMasterRepository.Update(model, model.Id);

                var data = exporRealizationDetailsRepository.All().Where(x => x.RealizationId == model.Id).ToList();
                foreach (var item in data)
                {
                    exporRealizationDetailsRepository.Delete(item);
                }

                foreach (var item in model.ExportRealization_Details)
                {
                    item.RealizationId = model.Id;
                    item.Id = 0;

                    exporRealizationDetailsRepository.Insert(item);

                    //foreach(var child in item.ExportInvoicePackingLists)
                    //{
                    //    child.Id = 0;
                    //    child.ExportInvoiceDetailsId = item.Id;

                    //    exportInvoicepackingListRepository.Insert(child);
                    //}
                }

                return Json(new { error = false, message = "Realization Updated successfully" });

            }

        }

        [AllowAnonymous]
        public JsonResult GetRealizationList(string fromDate = "", string toDate = "", int page = 1, decimal size = 5, string searchquery = "")
        {
            try
            {
                var errors = ModelState.Where(x => x.Value.Errors.Any())
                .Select(x => new { x.Key, x.Value.Errors });

                var userid = HttpContext.Session.GetInt32("UserId");
                var comid = HttpContext.Session.GetInt32("ComId");
                DateTime fromDateValue = Convert.ToDateTime(fromDate);
                DateTime toDateValue = Convert.ToDateTime(toDate);

                var invoice = exporRealizationMasterRepository.All().Where(x => x.IsDelete == false);

                var taburesquest = JsonConvert.DeserializeObject<TabulatorRequest>(searchquery);

                if (taburesquest.Filter.Count == 0)
                {
                    invoice = invoice.Where(x => x.FBPDate >= fromDateValue.Date && x.FBPDate <= toDateValue.Date);

                }

                foreach (var item in taburesquest.Filter)
                {
                    if (item.Field == "FileNumber")
                    {
                        invoice = invoice.Where(x => x.FileNumber.ToLower().Contains(item.Value.ToLower()));
                    }
                    if (item.Field == "FBPNo")
                    {
                        invoice = invoice.Where(x => x.FBPNo.ToLower().Contains(item.Value.ToLower()));
                    }
                    if (item.Field == "BankRef")
                    {
                        invoice = invoice.Where(x => x.BankRef.ToLower().Contains(item.Value.ToLower()));
                    }
                    if (item.Field == "CourierNo")
                    {
                        invoice = invoice.Where(x => x.CourierNo.ToLower().Contains(item.Value.ToLower()));
                    }
                    if (item.Field == "TotalValue")
                    {
                        invoice = invoice.Where(x => x.TotalValue.ToString().ToLower().Contains(item.Value.ToLower()));
                    }
                    if (item.Field == "ReceivingValue")
                    {
                        invoice = invoice.Where(x => x.ReceivingVlaue.ToString().ToLower().Contains(item.Value.ToLower()));
                    }
                    if (item.Field == "BankCharge")
                    {
                        invoice = invoice.Where(x => x.BankCharge.ToString().ToLower().Contains(item.Value.ToLower()));
                    }
                    if (item.Field == "Remarks")
                    {
                        invoice = invoice.Where(x => x.Remarks.ToLower().Contains(item.Value.ToLower()));
                    }
                }


                decimal TotalRecordCount = invoice.Count();
                var PageCountabc = decimal.Parse((TotalRecordCount / taburesquest.Size).ToString());
                var PageCount = Math.Ceiling(PageCountabc);

                int skip = (taburesquest.Page - 1) * taburesquest.Size;

                var query = (from e in invoice
                             select new
                             {
                                 e.Id,
                                 e.FileNumber,
                                 e.FBPNo,
                                 e.FBPDate,
                                 e.BankRef,
                                 e.CourierNo,
                                 e.TotalValue,
                                 ReceivingValue = e.ReceivingVlaue,
                                 e.BankCharge,
                                 e.Remarks
                             }).ToList();

                var abcd = query.OrderByDescending(x => x.Id).Skip(skip).Take(taburesquest.Size).ToList();
                var pageinfo = new PagingInfo();
                pageinfo.PageCount = int.Parse(PageCount.ToString());
                pageinfo.PageNo = taburesquest.Page;
                pageinfo.PageSize = taburesquest.Size;
                pageinfo.TotalRecordCount = int.Parse(TotalRecordCount.ToString());

                //return  abcd;
                return Json(new { Success = 1, error = false, data = abcd, page = taburesquest.Page, size = taburesquest.Size, last_page = pageinfo.PageCount, total = pageinfo.TotalRecordCount });

            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        [HttpGet]
        [AllowAnonymous]
        //public IActionResult InactiveRealization(int Id)
        public IActionResult DeleteRealization(int Id)
        {
            try
            {
                var data = exporRealizationMasterRepository.All().Where(x => x.Id == Id).FirstOrDefault();


                exporRealizationMasterRepository.Delete(data);

                return Json(new { success = "1", msg = "Deleted Successfully" });
            }
            catch
            {

                return Json(new { success = "0", msg = "Occuring error while deleting" });

            }

        }
        #endregion

        #region DeptWise Daily Production


        [HttpGet]
        //[AllowAnonymous]
        [OverridableAuthorize]
        public IActionResult CreateDeptWiseDailyProduction(int id = 0)
        {
            if (id == 0)
            {
                ViewBag.ActionType = "Create";
            }


            ViewBag.Id = id;

            return View();
        }

        [HttpGet]
        //[AllowAnonymous]
        [OverridableAuthorize]
        public IActionResult UpdateDeptWiseDailyProduction(int id = 0)
        {

            if (id > 0)
            {
                ViewBag.ActionType = "Edit";
            }

            ViewBag.Id = id;

            return View("CreateDeptWiseDailyProduction");
        }


        [HttpGet]
        [AllowAnonymous]
        public IActionResult PopulateDeptWiseTable(int buyerPOId, int CommercialCompanyId, DateTime? defaultDate, string color = "", string size = "")
        {

            var ComId = HttpContext.Session.GetInt32("ComId");

            SqlParameter[] sqlParameter1 = new SqlParameter[6];

            sqlParameter1[0] = new SqlParameter("@ComId", ComId);
            sqlParameter1[1] = new SqlParameter("@BuyerPOId", buyerPOId);
            sqlParameter1[2] = new SqlParameter("@color", color);
            sqlParameter1[3] = new SqlParameter("@size", size);
            sqlParameter1[4] = new SqlParameter("@CommercialCompanyId", CommercialCompanyId);
            sqlParameter1[5] = new SqlParameter("@defaultDate", defaultDate);
            //sqlParameter1[1] = new SqlParameter("@StyleId", styleId);


            var datasetabc = new System.Data.DataSet();
            datasetabc = Helper.ExecProcMapDS("get_DeptWiseDailyProductionData", sqlParameter1);

            var masterTable = datasetabc.Tables[0];


            return Json(new { Success = 1, data = masterTable, ex = "Data Loaded Successfully" });

        }

        [HttpGet]
        [AllowAnonymous]
        public IActionResult GetDailyProductionStyleBuyerPOWise(int styleNo, int buyerPOId)
        {

            var ComId = HttpContext.Session.GetInt32("ComId");

            SqlParameter[] sqlParameter1 = new SqlParameter[3];

            sqlParameter1[0] = new SqlParameter("@ComId", ComId);
            sqlParameter1[1] = new SqlParameter("@styleId", styleNo);
            sqlParameter1[2] = new SqlParameter("@buyerPOId", buyerPOId);



            var datasetabc = new System.Data.DataSet();
            datasetabc = Helper.ExecProcMapDS("GetDailyProductionStyleBuyerPOWise", sqlParameter1);

            var masterTable = datasetabc.Tables[0];


            return Json(new { Success = 1, data = masterTable, ex = "Data Loaded Successfully" });

        }

        [AllowAnonymous]
        [HttpPost]
        public IActionResult DeptWiseDailyProductionCreation([FromBody] DeptWise_DailyProduction_MasterModel model)
        {
            var ComId = HttpContext.Session.GetInt32("ComId");
            var userid = HttpContext.Session.GetInt32("UserId");

            if (model.Id == 0)
            {

                try
                {
                    masterDeptwiseDailyProductionRepository.Insert(model);

                    return Json(new { error = false, message = "Daily Production saved successfully" });
                }
                catch (Exception ex)
                {
                    return Json(new { success = false, values = ex.Message.ToString() });
                }

            }
            else
            {
                model.LuserId = userid ?? 0;
                masterDeptwiseDailyProductionRepository.Update(model, model.Id);

                var data = detailsDeptwiseDailyProductionRepository.All().Where(x => x.DailyProductionId == model.Id).ToList();

                detailsDeptwiseDailyProductionRepository.RemoveRange(data);


                foreach (var item in model.DailyProduction_Details)
                {
                    item.DailyProductionId = model.Id;
                    item.Id = 0;

                    detailsDeptwiseDailyProductionRepository.Insert(item);
                }

                return Json(new { error = false, message = "Daily Production Updated successfully" });

            }
        }

        [HttpGet]
        [AllowAnonymous]
        public IActionResult GetDeptWiseDailyProductionDetails(int id)
        {

            var masterdata = masterDeptwiseDailyProductionRepository.All().Include(x => x.Style).Where(x => x.Id == id).FirstOrDefault();

            var ComId = HttpContext.Session.GetInt32("ComId");

            SqlParameter[] sqlParameter1 = new SqlParameter[2];
            sqlParameter1[0] = new SqlParameter("@ComId", ComId);
            sqlParameter1[1] = new SqlParameter("@DailyProductionId", id);

            var datasetabc = new System.Data.DataSet();
            datasetabc = Helper.ExecProcMapDS("get_IdWiseDailyProduction", sqlParameter1);

            var dataTable = datasetabc.Tables[0];

            return Json(new { Success = 1, masterdata = masterdata, data = dataTable, ex = "Data Loaded Successfully" });
        }

        [HttpGet]
        //[AllowAnonymous]
        [OverridableAuthorize]
        public IActionResult DeleteDeptWiseDailyProduction(int Id)
        {
            try
            {
                var data = masterDeptwiseDailyProductionRepository.All().Where(x => x.Id == Id).FirstOrDefault();


                masterDeptwiseDailyProductionRepository.Delete(data);

                return Json(new { success = "1", msg = "Deleted Successfully" });
            }
            catch
            {

                return Json(new { success = "0", msg = "Occuring error while deleting" });

            }

        }

        [AllowAnonymous]
        [HttpGet]
        public IActionResult GetDeptWiseDailyProductionListold()
        {
            try
            {
                var ComId = HttpContext.Session.GetInt32("ComId");

                var data = masterDeptwiseDailyProductionRepository.All()
                                                        .Where(x => x.ComId == ComId)
                                                        .Include(x => x.Style)
                                                        .Include(x => x.Departments)
                                                        .Include(x => x.BuyerPO_Master)
                                                        .Select(x => new
                                                        {
                                                            Id = x.Id,
                                                            Style = x.Style.StyleNo,
                                                            Department = x.Departments.DeptName,
                                                            BuyerPO = x.BuyerPO_Master.BuyerPO,
                                                            TotalQuantity = x.TotalQuantity
                                                        })
                                                        .ToList();

                return Json(new { Success = 1, error = false, data = data });

            }
            catch (Exception ex)
            {
                return Json(new { Success = 0, ex = ex.InnerException?.InnerException?.Message ?? ex.Message });
            }
        }

        [AllowAnonymous]
        public JsonResult GetDeptWiseDailyProductionList(int page = 1, decimal size = 5, string searchquery = "")
        {
            try
            {
                var CurrentUserId = HttpContext.Session.GetInt32("UserId");
                var ComId = HttpContext.Session.GetInt32("ComId");
                var DeptWiseProduction = masterDeptwiseDailyProductionRepository.All().Where(x => x.IsDelete == false);

                var taburesquest = JsonConvert.DeserializeObject<TabulatorRequest>(searchquery);

                foreach (var item in taburesquest.Filter)
                {
                    if (item.Field == "DeptStyle")
                    {
                        DeptWiseProduction = DeptWiseProduction.Where(x => x.Style.StyleNo.ToLower().Contains(item.Value.ToLower()));
                    }
                    if (item.Field == "DeptBuyerPO")
                    {
                        DeptWiseProduction = DeptWiseProduction.Where(x => x.BuyerPO_Master.BuyerPO.ToLower().Contains(item.Value.ToLower()));
                    }
                    if (item.Field == "Department")
                    {
                        DeptWiseProduction = DeptWiseProduction.Where(x => x.Departments.DeptName.ToLower().Contains(item.Value.ToLower()));
                    }
                    if (item.Field == "DeptTotalQuantity")
                    {
                        DeptWiseProduction = DeptWiseProduction.Where(x => x.TotalQuantity.ToString().ToLower().Contains(item.Value.ToLower()));
                    }
                }

                decimal TotalRecordCount = DeptWiseProduction.Count();
                var PageCountabc = decimal.Parse((TotalRecordCount / taburesquest.Size).ToString());
                var PageCount = Math.Ceiling(PageCountabc);

                int skip = (taburesquest.Page - 1) * taburesquest.Size;

                var query = from e in DeptWiseProduction.Include(x => x.Style).Include(x => x.Departments).Include(x => x.BuyerPO_Master)
                            select new
                            {
                                Id = e.Id,
                                DeptStyle = e.Style.StyleNo,
                                Department = e.Departments.DeptName,
                                DeptBuyerPO = e.BuyerPO_Master.BuyerPO,
                                DeptTotalQuantity = e.TotalQuantity,
                                Type = e.Type,
                            };
                var abcd = query.OrderByDescending(x => x.Id).Skip(skip).Take(taburesquest.Size).ToList();
                var pageinfo = new PagingInfo();
                pageinfo.PageCount = int.Parse(PageCount.ToString());
                pageinfo.PageNo = taburesquest.Page;
                pageinfo.PageSize = taburesquest.Size;
                pageinfo.TotalRecordCount = int.Parse(TotalRecordCount.ToString());

                //return  abcd;
                return Json(new { Success = 1, error = false, data = abcd, page = taburesquest.Page, size = taburesquest.Size, last_page = pageinfo.PageCount, total = pageinfo.TotalRecordCount });

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        [AllowAnonymous]
        [HttpGet]
        public IActionResult DailyProductionReport(int id = 0)
        {
            ViewBag.Id = id;

            return View();
        }

        [HttpGet]
        [AllowAnonymous]
        public IActionResult GetDailyproductionReport(int? styleId, int? buyerPOId)
        {

            var ComId = HttpContext.Session.GetInt32("ComId");

            SqlParameter[] sqlParameter1 = new SqlParameter[3];

            sqlParameter1[0] = new SqlParameter("@ComId", ComId);
            sqlParameter1[1] = new SqlParameter("@StyleId", styleId);
            sqlParameter1[2] = new SqlParameter("@BuyerPOId", buyerPOId);

            var datasetabc = new System.Data.DataSet();
            datasetabc = Helper.ExecProcMapDS("rpt_DailyProductionReport", sqlParameter1);

            var masterTable = datasetabc.Tables[0];


            return Json(new { Success = 1, data = masterTable, ex = "Data Loaded Successfully" });

        }

        #endregion

        #region Document prefix

        [AllowAnonymous]
        [HttpGet]
        public IActionResult DocPrefixCreation(int id = 0)
        {
            if (id == 0)
            {
                ViewBag.ActionType = "Create";
            }
            else
            {
                ViewBag.ActionType = "Edit";
            }

            ViewBag.Id = id;

            var dateformat = new List<SelectListItem>
            {
                new SelectListItem { Text = "dd/MM/yyyy", Value = "dd/MM/yyyy" },
                //new SelectListItem { Text = "DD/MM/YY", Value = "DD/MM/YY" },
                new SelectListItem { Text = "dd/MMM/yy", Value = "dd/MMM/yy" }
            };

            var dateformatList = new SelectList(dateformat, "Value", "Text");
            ViewData["dateformat"] = dateformatList;

            var monthformat = new List<SelectListItem>
            {
                new SelectListItem { Text = "MM/yyyy", Value = "MM/yyyy" },
                new SelectListItem { Text = "MM/yy", Value = "MM/yy" },
                //new SelectListItem { Text = "MMM/yy", Value = "MMM/yy" }
            };

            var monthformatList = new SelectList(monthformat, "Value", "Text");
            ViewData["monthformat"] = monthformatList;

            var yearformat = new List<SelectListItem>
            {
                new SelectListItem { Text = "yyyy", Value = "yyyy" },
                new SelectListItem { Text = "yy", Value = "yy" }
            };

            var yearformatList = new SelectList(yearformat, "Value", "Text");
            ViewData["yearformat"] = yearformatList;

            return View();
        }

        [AllowAnonymous]
        public JsonResult GetDocType()
        {
            var ComId = HttpContext.Session.GetInt32("ComId");

            var doctype = _docTypeRepository.All()
                .Select(x => new
                {
                    x.Id,
                    x.DocType
                });
            return Json(doctype);
        }

        [AllowAnonymous]
        [HttpPost]
        public IActionResult DocumentPrefixCreation([FromBody] DocPrefixModel model)
        {
            var ComId = HttpContext.Session.GetInt32("ComId");
            var userid = HttpContext.Session.GetInt32("UserId");

            if (model.Id == 0)
            {

                try
                {
                    docPrefixRepository.Insert(model);

                    return Json(new { error = false, message = "Document prefix saved successfully" });
                }
                catch (Exception ex)
                {
                    return Json(new { success = false, values = ex.Message.ToString() });
                }

            }
            else
            {
                model.LuserId = userid ?? 0;
                var oldData = docPrefixRepository.All().Where(x => x.Id == model.Id).FirstOrDefault();
                model.FirstDocNo = oldData.FirstDocNo;
                if (model.Format == oldData.Format)
                {
                    model.LastGeneratedCode = oldData.LastGeneratedCode;
                }
                else
                {

                    model.LastGeneratedCode = null;
                }
                docPrefixRepository.Update(model, model.Id);


                return Json(new { error = false, message = "Document prefix Updated successfully" });

            }
        }

        [AllowAnonymous]
        [HttpGet]
        public IActionResult GetDocPrefixDetails(int id)
        {
            try
            {
                var ComId = HttpContext.Session.GetInt32("ComId");

                var data = docPrefixRepository.All()
                                                        .Where(x => x.ComId == ComId && x.Id == id)
                                                        .Include(x => x.vDocTypes)
                                                        .Select(x => new
                                                        {
                                                            Id = x.Id,
                                                            x.DocTypeId,
                                                            x.LastDocNo,
                                                            x.YearSuffix,
                                                            x.MonthSuffix,
                                                            x.DateSuffix,
                                                            x.Format,
                                                            x.DocPrefix
                                                        })
                                                        .FirstOrDefault();

                return Json(new { Success = 1, error = false, data = data });

            }
            catch (Exception ex)
            {
                return Json(new { Success = 0, ex = ex.InnerException?.InnerException?.Message ?? ex.Message });
            }
        }

        [AllowAnonymous]
        [HttpGet]
        public IActionResult DocPrefix()
        {
            return View();
        }

        [HttpGet]
        [AllowAnonymous]
        public IActionResult InactiveDocPrefix(int Id)
        {
            try
            {
                var data = docPrefixRepository.All().Where(x => x.Id == Id).FirstOrDefault();



                docPrefixRepository.Delete(data);

                return Json(new { success = "1", msg = "Deleted Successfully" });
            }
            catch
            {

                return Json(new { success = "0", msg = "Occuring error while deleting" });

            }

        }

        [AllowAnonymous]
        [HttpGet]
        public IActionResult GetDocPrefixList()
        {
            try
            {
                var ComId = HttpContext.Session.GetInt32("ComId");

                var data = docPrefixRepository.All()
                                                        .Where(x => x.ComId == ComId)
                                                        .Include(x => x.vDocTypes)
                                                        .Select(x => new
                                                        {
                                                            Id = x.Id,
                                                            DocPrefix = x.DocPrefix,
                                                            DocType = x.vDocTypes.DocType,
                                                            LastDocNo = x.LastDocNo
                                                        }).OrderByDescending(x => x.Id)
                                                        .ToList();




                return Json(new { Success = 1, error = false, data = data });

            }
            catch (Exception ex)
            {
                return Json(new { Success = 0, ex = ex.InnerException?.InnerException?.Message ?? ex.Message });
            }
        }
        #endregion

        #region CommercialReport

        [AllowAnonymous]
        public IActionResult CommercialReport()
        {
            var reportName = reportStyleRepository.All().Where(x => x.ReportFor == "Commercial").Select(x => new SelectListItem
            {
                Text = x.ReportStyleName,
                Value = x.Id.ToString()
            }).ToList();

            ViewData["ReportName"] = reportName;

            return View();
        }

        [HttpGet]
        [AllowAnonymous]
        public IActionResult LoadCommercialReport(string reportName, DateTime dtFrom, DateTime dtTo, int CommercialCompanyId = 0, int? BuyerGroupId = 0)
        {

            var ComId = HttpContext.Session.GetInt32("ComId");
            var UserId = HttpContext.Session.GetInt32("UserId");
            SqlParameter[] sqlParameter1 = new SqlParameter[7];

            sqlParameter1[0] = new SqlParameter("@ComId", ComId);
            sqlParameter1[1] = new SqlParameter("@Criteria", reportName);
            sqlParameter1[2] = new SqlParameter("@FromDate", dtFrom);
            sqlParameter1[3] = new SqlParameter("@ToDate", dtTo);
            sqlParameter1[4] = new SqlParameter("@CommercialComId", CommercialCompanyId);
            sqlParameter1[5] = new SqlParameter("@BuyerId", BuyerGroupId);
            sqlParameter1[6] = new SqlParameter("@userid", UserId);

            var datasetabc = new System.Data.DataSet();
            datasetabc = Helper.ExecProcMapDS("Prc_rptCommercial", sqlParameter1);

            var dataTable = datasetabc.Tables[0];
            var dataTable1 = datasetabc.Tables[1];
            //var dataTable2 = datasetabc.Tables[2];

            object dataTable2 = null;
            if (datasetabc.Tables.Count > 2 && datasetabc.Tables[2].Rows.Count > 0)
            {
                dataTable2 = datasetabc.Tables[2];
            }

            return Json(new { Success = 1, data = dataTable, data1 = dataTable1, data2 = dataTable2, ex = "Data Loaded Successfully" });

        }
        #endregion



        [AllowAnonymous]
        [HttpGet]
        public IActionResult MultiSelect()
        {
            return View();
        }

        [AllowAnonymous]
        public JsonResult GetProducts(int? WarehouseId, string q, int page = 1)
        {
            var ComId = HttpContext.Session.GetInt32("ComId");
            var pageSize = 30; // Number of items per page
            var products = productRepository.All().Where(x => x.ComId == ComId);
            if (q != null && q.Length != 0)
            {
                products = products.Where(x => x.Name.Contains(q));

            }


            return Json(products.ToList());
        }

        [AllowAnonymous]
        public JsonResult GetProductNamesByIds(int ids)
        {
            var products = productRepository.All().Where(p => p.Id == ids).ToList();
            var result = products.Select(p => new { id = p.Id, text = p.Name }).ToList();
            return Json(result);
        }

        #region ReportFilter

        [AllowAnonymous]
        [HttpPost]
        public IActionResult ColumnFilterCreation([FromBody] ColumnFilterRequest request)
        {
            try
            {
                var ComId = HttpContext.Session.GetInt32("ComId");
                var UserId = HttpContext.Session.GetInt32("UserId");

                var columnFilter = ReportFilterRepository.All().Where(x => x.LuserId == UserId && x.ReportType == request.type && x.ComId == ComId).FirstOrDefault();

                if (columnFilter == null)
                {
                    var model = new ReportFilterModel();
                    model.ReportType = request.type;
                    model.KeyValue = request.keyValue;

                    ReportFilterRepository.Insert(model);
                }
                else
                {
                    columnFilter.ReportType = request.type;
                    columnFilter.KeyValue = request.keyValue;

                    ReportFilterRepository.Update(columnFilter, columnFilter.Id);
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

            var columnFilter = ReportFilterRepository.All().Where(x => x.LuserId == UserId && x.ReportType == type && x.ComId == ComId).FirstOrDefault();

            if (columnFilter == null)
            {
                return Json(new { Success = 0 });
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

                var columnFilter = ReportFilterRepository.All().Where(x => x.LuserId == UserId && x.ReportType == Filter.type && x.ComId == ComId).FirstOrDefault();

                if (columnFilter != null)
                {
                    columnFilter.ReportType = Filter.type;

                    ReportFilterRepository.Delete(columnFilter);
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
    }
}
