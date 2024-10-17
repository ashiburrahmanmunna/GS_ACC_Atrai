using Atrai.Data.Interfaces;
using Atrai.Data.Repository;
using Atrai.Model.Core.Entity;
using Atrai.Services;
using Invoice.Core.Interfaces;
using Microsoft.Extensions.DependencyInjection;

namespace Atrai.Dependency
{
    public static class AppDataServiceDependency
    {
        public static IServiceCollection RegisterReporsitory(this IServiceCollection services)
        {
            services.AddTransient<IBusinessTypeRepository, BusinessTypeRepository>();
            services.AddTransient<ITaxFormRepository, TaxFormRepository>();
            services.AddTransient<IAllReportRepository, AllReportRepository>();
            services.AddTransient<IAccountsReportRepository, AccountsReportRepository>();
            services.AddTransient<IPurchaseTagsRepository, PurchaseTagsRepository>();
            services.AddTransient<IColorsRepository, ColorsRepository>();
            services.AddTransient<IColorsChildRepository, ColorsChildRepository>();
            services.AddTransient<ISizesRepository, SizesRepository>();
            services.AddTransient<IFiscalYearTypeRepository, FiscalYearTypeRepository>();
            services.AddTransient<IExportRealizationMasterRepository, ExportRealizationMasterRepository>();
            services.AddTransient<IExportRealizationDetailsRepository, ExportRealizationDetailsRepository>();
            services.AddTransient<ILCTypeRepository, LCTypeRepository>();
            services.AddTransient<ILCStatusRepository, LCStatusRepository>();
            services.AddTransient<IBOMQuantitySizeWiseRepository, BOMQuantitySizeWiseRepository>();
            services.AddTransient<IDocPrefixRepository, DocPrefixRepository>();
            services.AddTransient<IPINatureRepository, PINatureRepository>();
            services.AddTransient<IImportCIMasterRepository, ImportCIMasterRepository>();
            services.AddTransient<IImportCIDetailsRepository, ImportCIDetailsRepository>();
            services.AddTransient<IImportCIContainerRepository, ImportCIContainerRepository>();
            services.AddTransient<IContainerRepository, ContainerRepository>();
            services.AddTransient<IPurchaseTermsRepository, PurchaseTermsRepository>();
            services.AddTransient<ICategoryTypeRepository, CategoryTypeRepository>();
            services.AddTransient<IApprovalStatusRepository, ApprovalStatusRepository>();
            services.AddTransient<IAuditLogRepository, AuditLogRepository>();
            services.AddTransient<IColumnFilterRepository, ColumnFilterRepository>();
            services.AddTransient<ITaxCriteriaRepository, TaxCriteriaRepository>();

            services.AddTransient<IReportStyleRepository, ReportStyleRepository>();
            services.AddTransient<IRecurringDetailsRepository, RecurringDetailsRepository>();
            services.AddTransient<IStyleRepository, StyleRepository>();
            services.AddTransient<IProductWarehouseRepository, ProductWarehouseRepository>();
            services.AddTransient<IExportInvoiceTruckDetailsRepository, ExportInvoiceTruckDetailsRepository>();
            services.AddTransient<IUnitConversionRepository, UnitConversionRepository>();

            services.AddTransient<ISubscriptionTypeRepository, SubscriptionTypeRepository>();
            services.AddTransient<ISubscriptionActivationRepository, SubscriptionActivationRepository>();
            services.AddTransient<ISubscriptionActivationCompanyRepository, SubscriptionActivationCompanyRepository>();
            services.AddTransient<IAdvanceTrasactionTrackingRepository, AdvanceTrasactionTrackingRepository>();
            services.AddTransient<IDeptWiseDailyProduction_MasterRepository, DeptWiseDailyProduction_MasterRepository>();
            services.AddTransient<IDeptWiseDailyProduction_DetailsRepository, DeptWiseDailyProduction_DetailsRepository>();
            services.AddTransient<IBoxCategoryRepository, BoxCategoryRepository>();

            services.AddTransient<ISoftwarePackageRepository, SoftwarePackageRepository>();
            services.AddTransient<IPackageActivationRepository, PackageActivationRepository>();
            services.AddTransient<IReportStyleVariableRepository, ReportStyleVariableRepository>();
            services.AddTransient<IVariableRepository, VariableRepository>();
            services.AddTransient<IDyDashBoardModelRepository, DyDashBoardModelRepository>();
            services.AddTransient<IDashBoardLayoutOrderRepository, DashBoardLayoutOrderRepository>();
            services.AddTransient<ICompanyCurrencyRepository, CompanyCurrencyRepository>();
            // services.AddTransient<IEmailSettingRepository, EmailSettingRepository>();
            //services.AddTransient<ISmsSettingRepository, SmsSettingRepository>();






            services.AddTransient<IWorkOrderMasterRepository, WorkOrderMasterRepository>();
            services.AddTransient<ICOM_MachineryLCDetailsRepository, COM_MachineryLCDetailsRepository>();
            services.AddTransient<ICOM_MachineryLCMasterRepository, COM_MachineryLCMasterRepository>();
            services.AddTransient<IApprovedByRepository, ApprovedByRepository>();
            services.AddTransient<IWorkorderStatusRepository, WorkorderStatusRepository>();

            services.AddTransient<ITruckInfoRepository, TruckInfoRepository>();









            services.AddTransient<ICOM_ProformaInvoice_SubInvoiceRepository, COM_ProformaInvoice_SubInvoiceRepository>();
            services.AddTransient<ITransactionApprovalStatusRepository, TransactionApprovalStatusRepository>();



            services.AddTransient<ICOM_CommercialInvoiceRepository, CommercialInvoiceRepository>();
            services.AddTransient<ICOM_CommercialInvoice_SubRepository, CommercialInvoice_SubRepository>();
            services.AddTransient<ICOM_MachinaryLC_MasterRepository, MachinaryLC_MasterRepository>();
            services.AddTransient<ICOM_MachinaryLC_DetailsRepository, MachinaryLC_DetailsRepository>();
            services.AddTransient<IDocumentStatusRepository, DocumentStatusRepository>();
            services.AddTransient<ICommercialLCTypeRepository, CommercialLCTypeRepository>();



            services.AddTransient<IDocumentAcceptance_MasterRepository, DocumentAcceptance_MasterRepository>();
            services.AddTransient<IDocumentAcceptance_DetailsRepository, DocumentAcceptance_DetailsRepository>();





            services.AddTransient<IBankAccountNoLienBankRepository, BankAccountNoLienBankRepository>();





            services.AddTransient<IStyleRepository, StyleRepository>();
            services.AddTransient<IMasterPOConsumptionRepository, MasterPOConsumptionRepository>();
            services.AddTransient<IColorChildRepository, ColorChildRepository>();
            services.AddTransient<ISizeChildRepository, SizeChildRepository>();

            services.AddTransient<IBomCategoryRepository, BomCategoryRepository>();

            services.AddTransient<IMasterPORepository, MasterPORepository>();
            services.AddTransient<IMasterPODetailsRepository, MasterPODetailsRepository>();
            services.AddTransient<IDailyProduction_DetailsRepository, DailyProduction_DetailsRepository>();
            services.AddTransient<IDailyProduction_MasterRepository, DailyProduction_MasterRepository>();
            services.AddTransient<IReportFilterRepository, ReportFilterRepository>();





            services.AddTransient<IMenuRepository, MenuRepository>();
            services.AddTransient<IAndroidMenuRepository, AndroidMenuRepository>();
            services.AddTransient<IBuyerPO_DetailsRepository, BuyerPO_DetailsRepository>();
            services.AddTransient<IBuyerPO_MasterRepository, BuyerPO_MasterRepository>();
            services.AddTransient<IBOMMasterRepository, BOMMasterRepository>();
            services.AddTransient<IBOMDetailsRepository, BOMDetailsRepository>();
            services.AddTransient<IBOMAllocationCategoryRepository, BOMAllocationCategoryRepository>();


            services.AddTransient<IUserRoleRepository, UserRoleRepository>();
            services.AddTransient<IMenuPermissionRepository, MenuPermissionRepository>();
            services.AddTransient<ICompanyPermissionRepository, CompanyPermissionRepository>();

            services.AddTransient<IAndroidMenuPermissionRepository, AndroidMenuPermissionRepository>();

            services.AddTransient<IFromWarehousePermissionRepository, FromWarehousePermissionRepository>();
            services.AddTransient<IToWarehousePermissionRepository, ToWarehousePermissionRepository>();

            services.AddTransient<IAccountHeadPermissionRepository, AccountHeadPermissionRepository>();


            services.AddTransient<IMenuPermission_MasterRepository, MenuPermission_MasterRepository>();
            services.AddTransient<IMenuPermission_DetailsRepository, MenuPermission_DetailsRepository>();

            services.AddTransient<IAndroidMenuPermission_MasterRepository, AndroidMenuPermission_MasterRepository>();
            services.AddTransient<IAndroidMenuPermission_DetailsRepository, AndroidMenuPermission_DetailsRepository>();


            services.AddTransient<IUserTransactionLogRepository, UserTransactionLogRepository>();
            services.AddTransient<IUserLogingInfoRepository, UserLogingInfoRepository>();


            services.AddTransient<IWalletRepository, WalletRepository>();
            services.AddTransient<ICreditBalanceRepository, CreditBalanceRepository>();
            services.AddTransient<ICreditUsedRepository, CreditUsedRepository>();


            services.AddTransient<IBarcodePrintRepository, BarcodePrintRepository>();

            services.AddTransient<IUnitRepository, UnitRepository>();
            services.AddTransient<ITermRepository, TermRepository>();
            services.AddTransient<ITermMainRepository, TermMainRepository>();
            services.AddTransient<ILinkShareRepository, LinkShareRepository>();
            services.AddTransient<IReportsRepository, ReportsRepository>();
            services.AddTransient<IReportGrouptRepository, ReportGrouptRepository>();
            services.AddTransient<IReportUserTrackingRepository, ReportUserTrackingRepository>();

            services.AddTransient<IProductRepository, ProductRepository>();
            services.AddTransient<IProductTypeRepository, ProductTypeRepository>();

            services.AddTransient<IProductColorRepository, ProductColorRepository>();
            services.AddTransient<IProductSizeRepository, ProductSizeRepository>();

            services.AddTransient<IProductReviewsRepository, ProductReviewsRepository>();

            services.AddTransient<IProductSecUnitRepository, ProductSecUnitRepository>();
            services.AddTransient<ICustomerRepository, CustomerRepository>();
            services.AddTransient<ISupplierRepository, SupplierRepository>();

            services.AddTransient<ISaleRepository, SaleRepository>();
            services.AddTransient<IFeedbackRepository, FeedbackRepository>();
            services.AddTransient<ISalesItemsRepository, SalesItemRepository>();
            services.AddTransient<ISalesTagRepository, SalesTagRepository>();
            services.AddTransient<ISalesBatchItemsRepository, SalesBatchItemsRepository>();
            services.AddTransient<ISalesPaymentRepository, SalesPaymentRepository>();
            services.AddTransient<ISalesTermsRepository, SalesTermsRepository>();
            services.AddTransient<IAgencyRepository, AgencyRepository>();
            services.AddTransient<ISalesTaxRepository, SalesTaxRepository>();
            services.AddTransient<IMasterSalesTaxRepository, MasterSalesTaxRepository>();
            services.AddTransient<ISalesProductTaxRepository, SalesProductTaxRepository>();
            services.AddTransient<IPurchaseProductTaxRepository, PurchaseProductTaxRepository>();


            services.AddTransient<IBBLCMainRepository, BBLCMainRepository>();
            services.AddTransient<IBBLCDetailsRepository, BBLCDetailsRepository>();








            services.AddTransient<IGatePassRepository, GatePassRepository>();
            services.AddTransient<IGatePassItemsRepository, GatePassItemRepository>();


            services.AddTransient<ITermsMainRepository, TermsMainRepository>();
            services.AddTransient<ITermsSubRepository, TermsSubRepository>();

            services.AddTransient<IMonthlySalesRepository, MonthlySalesRepository>();

            services.AddTransient<ITokenSalesRepository, TokenSalesRepository>();

            services.AddTransient<IOrdersRepository, OrdersRepository>();
            services.AddTransient<IOrdersItemsRepository, OrdersItemRepository>();
            services.AddTransient<IOrdersPaymentRepository, OrdersPaymentRepository>();

            services.AddTransient<ISalesReturnRepository, SaleReturnRepository>();
            services.AddTransient<ISalesReturnItemsRepository, SalesReturnItemRepository>();
            services.AddTransient<ISalesReturnBatchItemsRepository, SalesReturnBatchItemsRepository>();
            services.AddTransient<ISalesReturnPaymentRepository, SalesReturnPaymentRepository>();
            services.AddTransient<ISalesExchangeItemsRepository, SalesExchangeItemRepository>();
            services.AddTransient<ISalesExchangeBatchItemsRepository, SalesExchangeBatchItemsRepository>();

            services.AddTransient<IPurchaseReturnRepository, PurchaseReturnRepository>();
            services.AddTransient<IPurchaseReturnItemsRepository, PurchaseReturnItemRepository>();
            services.AddTransient<IPurchaseReturnBatchItemsRepository, PurchaseReturnBatchItemsRepository>();
            services.AddTransient<IPurchaseReturnPaymentRepository, PurchaseReturnPaymentRepository>();


            services.AddTransient<IBudgetMainRepository, BudgetMainRepository>();
            services.AddTransient<IBudgetSubRepository, BudgetSubRepository>();


            services.AddTransient<IPurchaseRepository, PurchaseRepository>();
            services.AddTransient<IPurchaseItemsRepository, PurchaseItemsRepository>();
            services.AddTransient<IPurchaseItemsCategoryRepository, PurchaseItemsCategoryRepository>();
            services.AddTransient<IPurchaseBatchItemsRepository, PurchaseBatchItemsRepository>();
            services.AddTransient<IWarrantyItemsRepository, WarrantyItemsRepository>();


            services.AddTransient<IPurchasePaymentRepository, PurchasePaymentRepository>();

            services.AddTransient<ICostCalculatedRepository, CostCalculatedRepository>();


            services.AddTransient<ICountryRepository, CountryRepository>();
            services.AddTransient<IAccountCategoryRepository, AccountCategoryRepository>();

            services.AddTransient<IStoreSettingRepository, StoreSettingRepository>();
            services.AddTransient<ICustomFormStyleRepository, CustomFormStyleRepository>();
            services.AddTransient<IUserAccountRepository, UserAccountRepository>();
            services.AddTransient<ICompanyRepository, CompanyRepository>();
            services.AddTransient<IVGMRepository, VGMRepository>();
            services.AddTransient<IShortLinkRepository, ShortLinkRepository>();
            services.AddTransient<IShortLinkHitRepository, ShortLinkHitRepository>();





            services.AddTransient<IDayListRepository, DayListRepository>();
            services.AddTransient<IPaymentTermsRepository, PaymentTermsRepository>();
            services.AddTransient<ICommercialTypeRepository, CommercialTypeRepository>();
            services.AddTransient<IIncoTermRepository, IncoTermRepository>();
            services.AddTransient<IDayListTermRepository, DayListTermRepository>();
            services.AddTransient<IShipModeRepository, ShipModeRepository>();
















            services.AddTransient<ICommercialRepository, CommercialRepository>();
            //services.AddTransient<IConcernBankAccountRepository, ConcernBankAccountRepository>();
            services.AddTransient<IConcernBankRepository, ConcernBankRepository>();
            services.AddTransient<IDestinationRepository, DestinationRepository>();

            services.AddTransient<IUnitGroupRepository, UnitGroupRepository>();
            services.AddTransient<IDynamicReportRepository, DynamicReportRepository>();
            services.AddTransient<INotifyPartyRepository, NotifyPartyRepository>();
            services.AddTransient<ICOM_ProformaInvoiceRepository, COM_ProformaInvoiceRepository>();
            services.AddTransient<IBuyerGroupRepository, BuyerGroupRepository>();
            services.AddTransient<IMasterLCExportRepository, MasterLCExportRepository>();
            services.AddTransient<IMasterLCDetailsRepository, MasterLCDetailsRepository>();
            services.AddTransient<IMasterLCDetailsTempRepository, MasterLCDetailsTempRepository>();
            services.AddTransient<IExportInvoicePackingListRepository, ExportInvoicePackingListRepository>();
            services.AddTransient<IExportInvoiceDetailsRepository, ExportInvoiceDetailsRepository>();
            services.AddTransient<IExportInvoiceMasterRepository, ExportInvoiceMasterRepository>();
            services.AddTransient<IExportOrderRepository, ExportOrderRepository>();
            services.AddTransient<IUnitMasterRepository, UnitMasterRepository>();
            //services.AddTransient<IOpeningBankRepository, OpeningBankRepository>();
            services.AddTransient<IBankAccountNoRepository, BankAccountNoRepository>();
            services.AddTransient<ILienBankRepository, LienBankRepository>();
            services.AddTransient<IPostOfLoadingRepository, PostOfLoadingRepository>();
            services.AddTransient<IPostOfDischargeRepository, PostOfDischargeRepository>();
            services.AddTransient<IMasterLCRepository, MasterLCRepository>();
            services.AddTransient<IGroupLCSubRepository, GroupLCSubRepository>();
            services.AddTransient<IGroupLCMainRepository, GroupLCMainRepository>();
            services.AddTransient<IItemDescriptionRepository, ItemDescriptionRepository>();
            services.AddTransient<IPITypeRepository, PITypeRepository>();
            services.AddTransient<IItemGroupRepository, ItemGroupRepository>();
            services.AddTransient<ISupplierBankAccountRepository, SupplierBankAccountRepository>();


            services.AddTransient<IAccountHeadRepository, AccountHeadRepository>();
            services.AddTransient<IAccountHeadSystemRepository, AccountHeadSystemRepository>();

            services.AddTransient<ICategoryRepository, CategoryRepository>();
            services.AddTransient<IPaymentMethodRepository, PaymentMethodRepository>();
            services.AddTransient<IBrandRepository, BrandRepository>();

            services.AddTransient<IBookRepository, BookRepository>();
            services.AddTransient<IGalleryRepository, GalleryRepository>();


            services.AddTransient<IEmailSettingRepository, EmailSettingRepository>();
            services.AddTransient<ISmsSettingRepository, SmsSettingRepository>();
            services.AddTransient<IVoterRepository, VoterRepository>();



            services.AddTransient<IWarehouseRepository, WarehouseRepository>();
            services.AddTransient<ITagsRepository, TagsRepository>();
            services.AddTransient<ITransactionRepository, TransactionRepository>();
            services.AddTransient<ITransactionDetailsRepository, TransactionDetailsRepository>();

            services.AddTransient<IInvoiceBillRepository, InvoiceBillRepository>();



            services.AddTransient<IInternetPackageRepository, InternetPackageRepository>();
            services.AddTransient<IInternetUserRepository, InternetUserRepository>();
            services.AddTransient<IInternetUserStatusRepository, InternetUserStatusRepository>();
            services.AddTransient<IExpireDateExtendRepository, ExpireDateExtendRepository>();
            services.AddTransient<IUserTerminateRepository, UserTerminateRepository>();

            services.AddTransient<IToDoRepository, ToDoRepository>();
            services.AddTransient<IProductLedgerRepository, ProductLedgerRepository>();
            services.AddTransient<ITestRouterOnuTrackingRepository, TestRouterOnuTrackingRepository>();




            services.AddTransient<IActivationTicketRepository, ActivationTicketRepository>();
            services.AddTransient<ITroubleTicketRepository, TroubleTicketRepository>();
            services.AddTransient<ITroubleTicketCommentRepository, TroubleTicketCommentRepository>();


            services.AddTransient<IInternetComplainRepository, InternetComplainRepository>();
            services.AddTransient<IInternetDiagnosisReportRepository, InternetDiagnosisReportRepository>();
            services.AddTransient<IDeliveryServiceWeightRepository, DeliveryServiceWeightRepository>();
            services.AddTransient<IDeliveryServiceDistanceRepository, DeliveryServiceDistanceRepository>();
            services.AddTransient<IDeliveryServiceTimingRepository, DeliveryServiceTimingRepository>();
            services.AddTransient<IDeliveryServiceRepository, DeliveryServiceRepository>();
            services.AddTransient<IDeliveryServiceCommentRepository, DeliveryServiceCommentRepository>();

            services.AddTransient<INotificationSettingRepository, NotificationSettingRepository>();






            services.AddTransient<IPaymentTypeRepository, PaymentTypeRepository>();

            services.AddTransient<IMemberRepository, MemberRepository>();
            services.AddTransient<IEmployeeRepository, EmployeeRepository>();

            services.AddTransient<IMemberStatusRepository, MemberStatusRepository>();
            services.AddTransient<IShopRepository, ShopRepository>();
            services.AddTransient<IMarketRepository, MarketRepository>();
            services.AddScoped<TransactionLogRepository>();
            services.AddScoped<Atrai.Core.Common.clsProcedure>();

            services.AddScoped<IEmailSender, EmailSender>();
            services.AddScoped<ISmsSender, SmsSender>();

            services.AddTransient<IMediaService, MediaService>();
            services.AddScoped<INIDVerify, NIDVerify>();


            services.AddScoped<NPGCrypto>();


            services.AddTransient<ITimeZoneSettingsRepository, TimeZoneSettingsRepository>();
            services.AddTransient<IWarrentyRepository, WarrentyRepository>();
            services.AddTransient<IDurationTimeRepository, DurationTimeRepository>();
            services.AddScoped<ITradeTermRepository, TradeTermRepository>();



            //services.AddTransient<IColorRepository, ColorRepository>();
            //services.AddTransient<ISizeRepository, SizeRepository>();
            services.AddTransient<IDocTypeRepository, DocTypeRepository>();
            services.AddScoped<IDocStatusRepository, DocStatusRepository>();
            services.AddScoped<IStatusRepository, StatusRepository>();

            services.AddTransient<IApprovalTypeRepository, ApprovalTypeRepository>();
            services.AddTransient<IDocApprovalSettingRepository, DocApprovalSettingRepository>();




            services.AddTransient<IIssueRepository, IssueRepository>();
            services.AddTransient<IIssueItemsRepository, IssueItemRepository>();
            services.AddTransient<IIssueBatchItemsRepository, IssueBatchItemsRepository>();


            services.AddTransient<IDamageRepository, DamageRepository>();
            services.AddTransient<IDamageItemsRepository, DamageItemRepository>();
            services.AddTransient<IDamageBatchItemsRepository, DamageBatchItemsRepository>();



            services.AddTransient<IInternalTransferRepository, InternalTransferRepository>();
            services.AddTransient<IInternalTransferItemsRepository, InternalTransferItemRepository>();
            services.AddTransient<IInternalTransferBatchItemsRepository, InternalTransferBatchItemsRepository>();

            services.AddTransient<IDailyCurrencyRateRepository, DailyCurrencyRateRepository>();


            services.AddTransient<IAccVoucherMainRepository, AccVoucherMainRepository>();
            services.AddTransient<IAccVoucherSubRepository, AccVoucherSubRepository>();
            services.AddTransient<IAccVoucherSubCheckNoRepository, AccVoucherSubCheckNoRepository>();
            services.AddTransient<IAccVoucherSubSectionRepository, AccVoucherSubSectionRepository>();
            services.AddTransient<IAccVoucherTranGroupRepository, AccVoucherTranGroupRepository>();
            services.AddTransient<IVoucherTranGroupRepository, VoucherTranGroupRepository>();
            services.AddTransient<IAccVoucherTagsRepository, AccVoucherTagsRepository>();
            services.AddTransient<ITransactionTagsRepository, TransactionTagsRepository>();

            services.AddTransient<ISubSectionRepository, SubSectionRepository>();
            services.AddTransient<ISectionRepository, SectionRepository>();
            services.AddTransient<IDepartmentRepository, DepartmentRepository>();
            services.AddTransient<IDesignationRepository, DesignationRepository>();


            services.AddTransient<IGradeRepository, GradeRepository>();
            services.AddTransient<IShiftRepository, ShiftRepository>();


            services.AddTransient<IOfferRepository, OfferRepository>();
            services.AddTransient<IShippingChargeRepository, ShippingChargeRepository>();



            services.AddTransient<IEmployeeSalaryMasterRepository, EmployeeSalaryMasterRepository>();
            services.AddTransient<IEmployeeSalaryDetailsRepository, EmployeeSalaryDetailsRepository>();


            services.AddTransient<ISalaryTypeRepository, SalaryTypeRepository>();
            services.AddTransient<IEmployeeTypeRepository, EmployeeTypeRepository>();
            services.AddTransient<IWeekSegmentRepository, WeekSegmentRepository>();


            services.AddTransient<IBloodGroupRepository, BloodGroupRepository>();
            services.AddTransient<ILineRepository, LineRepository>();
            services.AddTransient<IFloorRepository, FloorRepository>();
            services.AddTransient<IBuildingTypeRepository, BuildingTypeRepository>();
            services.AddTransient<IBankRepository, BankRepository>();
            services.AddTransient<IBankBranchRepository, BankBranchRepository>();
            services.AddTransient<IReligionRepository, ReligionRepository>();
            services.AddTransient<IEmpTypeRepository, EmpTypeRepository>();
            services.AddTransient<ISkillRepository, SkillRepository>();
            services.AddTransient<ICatUnitRepository, CatUnitRepository>();
            services.AddTransient<IEmpTypeRepository, EmpTypeRepository>();
            services.AddTransient<IPoliceStationRepository, PoliceStationRepository>();
            services.AddTransient<IDistrictRepository, DisctrictRepository>();
            services.AddTransient<IPostOfficeRepository, PostOfficeRepository>();
            services.AddTransient<IGenderRepository, GenderRepository>();
            services.AddTransient<IHREmpInfoRepository, HREmpInfoListRepository>();





            services.AddTransient<IAccVoucherNoPrefixRepository, AccVoucherNoPrefixRepository>();
            services.AddTransient<IAccVoucherTypeRepository, AccVoucherTypeRepository>();
            services.AddTransient<IAccVoucherCreatedTypeRepository, AccVoucherCreatedTypeRepository>();
            services.AddTransient<IAccFiscalYearRepository, AccFiscalYearRepository>();
            services.AddTransient<IAccFiscalMonthRepository, AccFiscalMonthRepository>();
            services.AddTransient<IAccFiscalHalfYearRepository, AccFiscalHalfYearRepository>();
            services.AddTransient<IAccFiscalQtrRepository, AccFiscalQtrRepository>();
            services.AddTransient<IPrdUnitRepository, PrdUnitRepository>();



            services.AddTransient<IPayrollIntegrationSummaryRepository, PayrollIntegrationSummaryRepository>();
            services.AddTransient<IIntegrationSettingMainRepository, IntegrationSettingMainRepository>();
            services.AddTransient<IIntegrationSettingDetailsRepository, IntegrationSettingDetailsRepository>();
            services.AddTransient<IProcessLockRepository, ProcessLockRepository>();



            services.AddTransient<INotificationRepository, NotificationRepository>();
            services.AddTransient<INotificationSeenRepository, NotificationSeenRepository>();
            services.AddTransient<IEmployeeAttendanceRepository, EmployeeAttendanceRepository>();
            services.AddTransient<IAttendanceProcessRepository, AttendanceProcessRepository>();

            services.AddTransient<IDiscountTypeRepository, DiscountTypeRepository>();


            services.AddTransient<ITaskToDoRepository, TaskToDoRepository>();
            services.AddTransient<IMobileTextAnimationRepository, MobileTextAnimationRepository>();



            return services;
        }
    }
}
