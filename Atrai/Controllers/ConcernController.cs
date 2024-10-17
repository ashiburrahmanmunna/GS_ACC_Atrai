using Atrai.Data.Interfaces;
using Atrai.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System.Collections.Generic;

namespace Atrai.Controllers
{
    [Authorize]
    [OverridableAuthorize]
    public class ConcernController : Controller
    {
        public TransactionLogRepository tranlog { get; }


        private readonly IMenuPermissionRepository _menuPermissionRepository;
        private readonly IReportStyleRepository reportStyleRepository;

        private readonly ICustomerRepository customerRepository;
        private readonly IUserAccountRepository UserAccountRepository;

        private readonly ISupplierRepository supplierRepository;
        private readonly ITermsMainRepository termsmainRepository;
        private readonly IRecurringDetailsRepository recurringDetailsRepository;
        private readonly ITransactionRepository transactionRepository;
        private readonly IBOMAllocationCategoryRepository bomAllocationCatRepository;
        private readonly IBOMMasterRepository bomMasterRepository;
        private readonly IBOMDetailsRepository bomDetailsRepository;
        private readonly IMasterPOConsumptionRepository masterPOConsumptionRepository;
        private readonly IDepartmentRepository departmentRepository;


        private IEmailSender _emailsender { get; }
        private ISmsSender _smsSender { get; }

        private readonly IOrdersRepository onlineOrderRepository;
        private readonly IOrdersItemsRepository orderItemRepository;
        private readonly ISalesTagRepository salesTagRepository;
        private readonly ICustomFormStyleRepository _customFormStyleRepository;
        private readonly ITagsRepository tagsRepository;

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

        private readonly IProductRepository productRepository;
        private readonly IProductTypeRepository productTypeRepository;
        private readonly IWarehouseRepository _warehouseRepository;
        private readonly IFromWarehousePermissionRepository _FromWarehousePermissionRepository;
        private readonly IToWarehousePermissionRepository ToWarehousePermissionRepository;

        private readonly IAccountHeadPermissionRepository AccountHeadPermissionRepository;
        private readonly IDailyProduction_MasterRepository dailyProductionMasterRepository;
        private readonly IDailyProduction_DetailsRepository dailyProductionDetailsRepository;



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
        //private readonly IpaymentTypesRepository paymentTypesRepository;


        public static string ExpressionParameterizationException { get; }
        Dictionary<int, dynamic> postData = new Dictionary<int, dynamic>();


        public ConcernController(ICustomerRepository customerRepository, IUserAccountRepository UserAccountRepository, ISaleRepository saleRepository,
            ISupplierRepository supplierRepository, IPurchaseRepository purchaseRepository, IStoreSettingRepository storeSettingRepository, IRecurringDetailsRepository recurringDetailsRepository, IColorsRepository colorsRepository, IColorChildRepository colorChildRepository, ISizeChildRepository sizeChildRepository,
            ITransactionRepository transactionRepository, ISizesRepository sizesRepository, IBuyerPO_MasterRepository buyerPOMasterRepository,
            ISalesItemsRepository saleItemRepository, ISalesBatchItemsRepository saleBatchItemRepository, ISalesPaymentRepository salesPaymentRepository,
            IPurchaseBatchItemsRepository purchaseBatchItemRepository, ICostCalculatedRepository costCalculatedRepository,
             IPurchaseItemsRepository purchaseItemsRepository, IPurchasePaymentRepository purchasePaymentRepository, ITagsRepository tagsRepository,
        ITransactionDetailsRepository transactionDetailsRepository, IProductTypeRepository productTypeRepository, IBrandRepository brandRepository, ISalesTagRepository salesTagRepository, IStyleRepository styleRepository, IBuyerPO_DetailsRepository buyerPODetailsRepository, IMasterPOConsumptionRepository masterPOConsumptionRepository, IDepartmentRepository departmentRepository, IDailyProduction_MasterRepository dailyProductionMasterRepository,
            ICategoryRepository categoryRepository, IUnitRepository unitRepository, IProductRepository productRepository,
            IWarehouseRepository _warehouseRepository, IFromWarehousePermissionRepository FromWarehousePermissionRepository, IToWarehousePermissionRepository ToWarehousePermissionRepository, IAccountHeadRepository accountHeadRepository, IBOMAllocationCategoryRepository bomAllocationCatRepository,
            IPaymentTypeRepository paymentTypeRepository, ICompanyRepository companyRepository, ICustomFormStyleRepository customFormStyleRepository,
            IConfiguration configuration, TransactionLogRepository tranlogRepository, IReportStyleRepository reportStyleRepository, IOrdersRepository onlineOrderRepository, IOrdersItemsRepository orderItemRepository, IDocTypeRepository docTypeRepository, ICreditBalanceRepository sMSBalanceRepository, ICreditUsedRepository creditUsedRepository, IEmailSender emailsender, ISmsSender smsSender, IAccountHeadPermissionRepository accountHeadPermissionRepository, IMenuPermissionRepository menuPermissionRepository, ITermsMainRepository termsmainRepository, ICountryRepository currencyRepository, IEmployeeRepository employeeRepository, ISalesTermsRepository salesTermsRepository, ITransactionRepository accountsDailyTransaction, ISalesReturnItemsRepository salesReturnItemRepository, IGatePassRepository gatePassRepository, IGatePassItemsRepository gatePassItemRepository, IAgencyRepository agencyRepository, ISalesTaxRepository salestaxRepository, IMasterSalesTaxRepository masterSalesTaxRepository, ISalesProductTaxRepository salesProductTaxRepository, IFeedbackRepository feedbackRepository, IAccountCategoryRepository accountCategoryRepository, IBOMMasterRepository bomMasterRepository, IBOMDetailsRepository bomDetailsRepository, IDailyProduction_DetailsRepository dailyProductionDetailsRepository,
        ITermsMainRepository termsMainRepository, ITermRepository termRepository, IWebHostEnvironment webHostEnvironment)
        {
            this.configuration = configuration;

            this.customerRepository = customerRepository;
            this.UserAccountRepository = UserAccountRepository;
            this.brandRepository = brandRepository;
            this.saleRepository = saleRepository;
            this.saleItemRepository = saleItemRepository;
            this._salesBatchItemRepository = saleBatchItemRepository;
            this._purchaseBatchItemRepository = purchaseBatchItemRepository;
            this.salesTagRepository = salesTagRepository;
            this.salesPaymentRepository = salesPaymentRepository;
            this.salesProductTaxRepository = salesProductTaxRepository;
            this.productTypeRepository = productTypeRepository;
            this.recurringDetailsRepository = recurringDetailsRepository;
            this.dailyProductionMasterRepository = dailyProductionMasterRepository;
            this._storeSettingRepository = storeSettingRepository;
            this.supplierRepository = supplierRepository;
            this.purchaseRepository = purchaseRepository;
            this.purchaseItemsRepository = purchaseItemsRepository;
            this.departmentRepository = departmentRepository;
            this.purchasePaymentRepository = purchasePaymentRepository;
            this.dailyProductionDetailsRepository = dailyProductionDetailsRepository;
            this.tagsRepository = tagsRepository;
            this.transactionRepository = transactionRepository;
            this.sizesRepository = sizesRepository;
            this.buyerPODetailsRepository = buyerPODetailsRepository;
            this.buyerPOMasterRepository = buyerPOMasterRepository;
            this.colorsRepository = colorsRepository;
            this.masterPOConsumptionRepository = masterPOConsumptionRepository;
            _styleRepository = styleRepository;
            _colorChildRepository = colorChildRepository;
            _sizeChildRepository = sizeChildRepository;
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
        }
        public IActionResult Index()
        {
            return View();
        }

        #region Sister Company Info
        [AllowAnonymous]
        [HttpGet]
        public IActionResult SisterCompany()
        {


            return View();
        }
        #endregion
    }
}
