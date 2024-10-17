using Atrai.Model.Core.Entity;
using Microsoft.EntityFrameworkCore;

namespace Atrai.Data.Context.AppDataContext
{
    public class InvoiceDbContext : DbContext
    {
        public InvoiceDbContext(DbContextOptions options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<UserAccountModel>()
                .HasIndex(p => new { p.Email })
                .IsUnique(true);

            modelBuilder.Entity<InternetUserModel>()
              .HasIndex(p => new { p.ComId, p.UserId })
              .IsUnique(true);


            modelBuilder.Entity<InvoiceBillModel>()
              .HasIndex(p => new { p.ComId, p.BillNo })
              .IsUnique(true);

            modelBuilder.Entity<ProductModel>()
            //.HasIndex(p => new { p.ComId, p.Code, p.Name, p.ColorName, p.SizeName, p.UnitId, p.CategoryId, p.ModelName})
            .HasIndex(p => new { p.ComId, p.Code, p.ColorName, p.SizeName, p.ModelName }) // p.Name,p.UnitId,p.CategoryId,

            .IsUnique(true);


            modelBuilder.Entity<DeliveryServiceModel>()
              .HasIndex(p => new { p.ComId, p.BillNo })
              .IsUnique(true);

            modelBuilder.Entity<SalesModel>()
              .HasIndex(p => new { p.ComId, p.SaleCode })
              .IsUnique(true);

            modelBuilder.Entity<TokenSalesModel>()
          .HasIndex(p => new { p.ComId, p.TokenCode })
          .IsUnique(true);

            modelBuilder.Entity<SalesReturnModel>()
             .HasIndex(p => new { p.ComId, p.SalesReturnCode })
             .IsUnique(true);

            modelBuilder.Entity<PurchaseReturnModel>()
             .HasIndex(p => new { p.ComId, p.PurchaseReturnCode })
             .IsUnique(true);




            modelBuilder.Entity<PurchaseModel>()
              .HasIndex(p => new { p.ComId, p.PurchaseCode })
              .IsUnique(true);


            modelBuilder.Entity<IssueModel>()
              .HasIndex(p => new { p.ComId, p.IssueCode })
              .IsUnique(true);


            modelBuilder.Entity<DamageModel>()
            .HasIndex(p => new { p.ComId, p.DamageCode })
            .IsUnique(true);


            modelBuilder.Entity<InternalTransferModel>()
              .HasIndex(p => new { p.ComId, p.InternalTransferCode })
              .IsUnique(true);


            modelBuilder.Entity<OrdersModel>()
          .HasIndex(p => new { p.ComId, p.OrderCode })
          .IsUnique(true);

            modelBuilder.Entity<TroubleTicketModel>()
              .HasIndex(p => new { p.ComId, p.TicketNo })
              .IsUnique(true);

            modelBuilder.Entity<ActivationTicketModel>()
            .HasIndex(p => new { p.ComId, p.TicketNo })
            .IsUnique(true);


            modelBuilder.Entity<DeliveryServiceModel>()
            .HasIndex(p => new { p.ComId, p.BillNo })
            .IsUnique(true);

            modelBuilder.Entity<PackageActivationModel>()
            .HasIndex(p => new { p.ComId, p.InvoiceNo })
            .IsUnique(true);


        }

        public DbSet<MasterPOModel> MasterPO { get; set; }
        public DbSet<TruckInfo> TruckInfo { get; set; }
        public DbSet<UnitConversionModel> UnitConversion { get; set; }
        public DbSet<AuditLogModel> AuditLog { get; set; }



        public DbSet<COM_CommercialInvoice> COM_CommercialInvoice { get; set; }
        public DbSet<COM_CommercialInvoice_Sub> COM_CommercialInvoice_Sub { get; set; }
        public DbSet<COM_MachinaryLC_Master> COM_MachinaryLC_Master { get; set; }
        public DbSet<COM_MachinaryLC_Details> COM_MachinaryLC_Details { get; set; }
        public DbSet<CommercialLCType> CommercialLCType { get; set; }
        public DbSet<DocumentStatus> DocumentStatus { get; set; }
        public DbSet<ProductWarehouseModel> ProductWarehouse { get; set; }
        public DbSet<DocPrefixModel> DocPrefix { get; set; }
        public DbSet<CategoryTypeModel> CategoryType { get; set; }

        public DbSet<BankAccountNoLienBank> BankAccountNoLienBank { get; set; }
        public DbSet<ContainerModel> Container { get; set; }
        public DbSet<ImportCI_Master> ImportCI_Master { get; set; }
        public DbSet<ImportCI_Details> ImportCI_Details { get; set; }
        public DbSet<ImportCI_Container> ImportCI_Container { get; set; }
        public DbSet<BoxCategoryModel> BoxCategory { get; set; }
        public DbSet<ColumnFilterModel> ColumnFilter { get; set; }
        public DbSet<ReportFilterModel> ReportFilter { get; set; }
        public DbSet<TaxCriteria> TaxCriteria { get; set; }


        public DbSet<BBLCMain> COM_BBLC_Master { get; set; }
        public DbSet<BBLC_Details> Com_BBLC_Details { get; set; }
        public DbSet<Destination> Destination { get; set; }
        public DbSet<MasterPODetailsModel> MasterPoDetails { get; set; }
        public DbSet<ApprovalStatusModel> ApprovalStatus { get; set; }
        public DbSet<TransactionApprovalStatusModel> TransactionApprovalStatus { get; set; }

        public DbSet<BuyerPO_MasterModel> OrderAllocationMaster { get; set; }
        public DbSet<BuyerPO_DetailsModel> OrderAllocationDetails { get; set; }
        public DbSet<BOMAllocationCategoryModel> BOMAllocationCategory { get; set; }
        public DbSet<BOMMasterModel> BOMMaster{ get; set; }
        public DbSet<BOMDetailsModel> BOMDetails { get; set; }
        public DbSet<COM_MasterLC_Details_Temp> COM_MasterLC_Details_Temp { get; set; }
        public DbSet<BOMQuantitySizeWiseModel> BOMQuantitySizeWise { get; set; }
        public DbSet<BuyerPO_ConsumptionModel> BuyerPO_Consumption { get; set; }
        public DbSet<ExportRealization_Master> ExportRealization_Master { get; set; }
        public DbSet<ExportRealization_Details> ExportRealization_Details { get; set; }
        public DbSet<MASTERPO_ConsumptionModel> MASTERPO_Consumption { get; set; }
        public DbSet<DailyProduction_MasterModel> DailyProduction_Master { get; set; }
        public DbSet<DailyProduction_DetailsModel> DailyProduction_Details { get; set; }
        public DbSet<DeptWise_DailyProduction_MasterModel> DeptWise_DailyProduction_Master { get; set; }
        public DbSet<DeptWise_DailyProduction_DetailsModel> DeptWise_DailyProduction_Details { get; set; }


        //32
        public DbSet<CommercialCompanyModel> CommercialCompany { get; set; }
        public DbSet<ItemGroupModel> ItemGroups { get; set; }
        public DbSet<PITypeModel> PIType { get; set; }
        public DbSet<ItemDescriptionModel> ItemDescription { get; set; }
        public DbSet<LCStatus> LCStatus { get; set; }
        public DbSet<LCNature> LCNature { get; set; }
        public DbSet<LCType> LCType { get; set; }
        public DbSet<ShipModel> ShipModel { get; set; }
        public DbSet<CommercialPaymentTerms> Com_PaymentTerms { get; set; }
        public DbSet<DayList> DayList { get; set; }
        public DbSet<ExportOrderStatus> ExportOrderStatus { get; set; }
        public DbSet<ExportOrderCategory> ExportOrderCategory { get; set; }
        public DbSet<GroupLC_MainModel> GroupLC_Main { get; set; }
        public DbSet<GroupLC_SubModel> GroupLC_Sub { get; set; }
        public DbSet<MasterLCModel> MasterLC { get; set; }
        public DbSet<PortOfDischarge> PortOfDischarge { get; set; }
        public DbSet<PortOfLoading> PortOfLoading { get; set; }
        public DbSet<LienBank> LienBank { get; set; }
        public DbSet<BankAccountNo> BankAccountNo { get; set; }

        public DbSet<OpeningBank> OpeningBank { get; set; }
        public DbSet<UnitMaster> UnitMaster { get; set; }
        public DbSet<ExportOrder> ExportOrder { get; set; }
        public DbSet<ExportInvoiceMaster> ExportInvoiceMaster { get; set; }
        public DbSet<ExportInvoiceDetails> ExportInvoiceDetails { get; set; }
        public DbSet<ExportInvoicePackingList> ExportInvoicePackingList { get; set; }
        public DbSet<COM_MasterLC_Details> COM_MasterLC_Details { get; set; }
        public DbSet<COM_MasterLCExport> COM_MasterLCExport { get; set; }
        public DbSet<BuyerGroup> BuyerGroup { get; set; }
        public DbSet<NotifyParty> NotifyParty { get; set; }
        public DbSet<DynamicReport> DynamicReport { get; set; }
        public DbSet<UnitGroup> UnitGroup { get; set; }




        public DbSet<AccountHeadModel> AccountHeads { get; set; }
        public DbSet<ColorsModel> Colors { get; set; }
        public DbSet<SizesModel> Sizes { get; set; }
        public DbSet<CompanyCurrencyModel> CompanyCurrencies { get; set; }
        public DbSet<AccountHeadSystemModel> AccountHeadSystem { get; set; }

        public DbSet<TransactionModel> Transactions { get; set; }
        public DbSet<TransactionDetailsModel> TransactionSub { get; set; }
        public DbSet<VariableModel> Variables { get; set; }
        public DbSet<DyDashBoardModel> DyDashBoards { get; set; }
        public DbSet<DashBoardLayoutOrder> DashBoardLayoutOrder { get; set; }



        public DbSet<CategoryModel> Categories { get; set; }
        public DbSet<CustomFormStyleVariableModel> CustomFormStyleVariables { get; set; }
        public DbSet<CustomFormStyleModel> CustomFormStyles { get; set; }


        public DbSet<DocTypeModel> DocType { get; set; }
        public DbSet<ApprovalTypeModel> ApprovalType { get; set; }
        public DbSet<DocApprovalSettingModel> DocApprovalSetting { get; set; }

        public DbSet<BrandModel> Brand { get; set; }

        public DbSet<BookModel> Books { get; set; }
        public DbSet<GalleryModel> Gallery { get; set; }


        public DbSet<EmailSettingModel> EmailSettings { get; set; }
        public DbSet<SmsSettingModel> SmsSettings { get; set; }
        public DbSet<VoterModel> Voters { get; set; }




        public DbSet<ProductModel> Products { get; set; }
        public DbSet<Gallery> Galleries { get; set; }


        public DbSet<BarcodePrintModel> BarcodePrint { get; set; }

        public DbSet<ProductReviewsModel> ProductReviews { get; set; }

        public DbSet<ProductSecUnitModel> ProductSecUnits { get; set; }
        public DbSet<PaymentTermsModel> Terms { get; set; }
        public DbSet<LinkShareModel> LinkShare { get; set; }



        public DbSet<StoreSettingModel> Settings { get; set; }
        public DbSet<PaymentMethodModel> PaymentMethods { get; set; }
        public DbSet<CountryModel> Countrys { get; set; }
        public DbSet<AccountCategoryModel> AccountCategory { get; set; }


        public DbSet<CustomerModel> Customers { get; set; }
        public DbSet<SupplierModel> Suppliers { get; set; }

        public DbSet<ReportModel> Reports { get; set; }
        public DbSet<ReportGroupModel> ReportGroup { get; set; }
        public DbSet<ReportUserTrackingModel> ReportUserTracking { get; set; }
        public DbSet<Acc_BudgetMainModel> BudgetMain { get; set; }


        public DbSet<GatePassModel> GatePass { get; set; }
        public DbSet<GatePassItemsModel> GatePassItems { get; set; }

        public DbSet<SalesModel> Sales { get; set; }
        public DbSet<AdvanceTrasactionTrackingModel> AdvanceTrasactionTracking { get; set; }
        public DbSet<FeedbackModel> Feedback { get; set; }
        public DbSet<SalesItemsModel> SaleItems { get; set; }
        public DbSet<SalesBatchItemsModel> SalesBatchItems { get; set; }
        public DbSet<AgencyModel> Agency { get; set; }
        public DbSet<SalesTaxModel> SalesTax { get; set; }
        public DbSet<MasterSalesTaxModel> MasterSalesTax { get; set; }
        public DbSet<RecurringDetailsModel> RecurringDetails { get; set; }


        public DbSet<TermsMainModel> TermsMain { get; set; }
        public DbSet<TermsSubModel> TermsSub { get; set; }

        public DbSet<MonthlySalesModel> MonthlySales { get; set; }

        public DbSet<OrdersModel> Orders { get; set; }
        public DbSet<OrdersItemsModel> OrderItems { get; set; }

        public DbSet<TokenSalesModel> TokenSales { get; set; }
        public DbSet<SalesReturnModel> SalesReturn { get; set; }
        public DbSet<SalesReturnItemsModel> SalesReturnItems { get; set; }
        public DbSet<SalesReturnBatchItemsModel> SalesReturnBatchItems { get; set; }
        public DbSet<SalesExchangeItemsModel> SalesExchangeItems { get; set; }
        public DbSet<SalesExchangeBatchItemsModel> SalesExchangeBatchItems { get; set; }



        public DbSet<PurchaseReturnModel> PurchaseReturn { get; set; }
        public DbSet<PurchaseReturnItemsModel> PurchaseReturnItems { get; set; }
        public DbSet<PurchaseReturnBatchItemsModel> PurchaseReturnBatchItems { get; set; }


        /// Issue

        public DbSet<IssueModel> Issue { get; set; }
        public DbSet<IssueItemsModel> IssueItems { get; set; }
        public DbSet<IssueBatchItemsModel> IssueBatchItems { get; set; }


        /// Damage
        public DbSet<DamageModel> Damage { get; set; }
        public DbSet<DamageItemsModel> DamageItems { get; set; }
        public DbSet<DamageBatchItemsModel> DamageBatchItems { get; set; }



        public DbSet<InternalTransferModel> InternalTransfer { get; set; }
        public DbSet<InternalTransferItemsModel> InternalTransferItems { get; set; }
        public DbSet<InternalTransferBatchItemsModel> InternalTransferBatchItems { get; set; }


        public DbSet<COM_DocumentAcceptance_Details> COM_DocumentAcceptance_Details { get; set; }
        public DbSet<COM_DocumentAcceptance_Master> COM_DocumentAcceptance_Master { get; set; }




        public DbSet<UserAccountModel> Users { get; set; }
        public DbSet<CompanyModel> Companys { get; set; }

        public DbSet<VGMModel> VGMs { get; set; }
        public DbSet<ShortLinkModel> ShortLink { get; set; }


        public DbSet<MemberStatusModel> MemberStatus { get; set; }
        public DbSet<MarketModel> Markets { get; set; }
        public DbSet<ShopModel> Shops { get; set; }
        public DbSet<MemberModel> Members { get; set; }
        public DbSet<EmployeeModel> Employee { get; set; }
        public DbSet<HR_ProssType> HR_ProssType { get; set; }
        public DbSet<HR_ProssType_WHDay> HR_ProssType_WHDay { get; set; }
        public DbSet<HR_OverTimeSetting> HR_OverTimeSetting { get; set; }



        public DbSet<COM_ProformaInvoice_Sub> COM_ProformaInvoice_Sub { get; set; }








        public DbSet<BusinessTypeModel> BusinessTypes { get; set; }
        public DbSet<AccountsReportModel> AccountsReports { get; set; }
        public DbSet<FiscalYearTypeModel> FiscalYearTypes { get; set; }

        public DbSet<ReportStyleModel> ReportStyles { get; set; }

        public DbSet<SubscriptionTypeModel> SubscriptionTypes { get; set; }
        public DbSet<SubscriptionActivationModel> SubscriptionActivation { get; set; }
        public DbSet<SubscriptionActivationCompanyModel> SubscriptionActivationCompany { get; set; }

        public DbSet<SoftwarePackageModel> SoftwarePackage { get; set; }
        public DbSet<PackageActivationModel> PackageActivation { get; set; }

        public DbSet<MenuModel> Menus { get; set; }
        public DbSet<AndroidMenuModel> AndroidMenus { get; set; }

        public DbSet<MenuPermissionModel> MenuPermissions { get; set; }
        public DbSet<CompanyPermissionModel> CompanyPermission { get; set; }

        public DbSet<AndroidMenuPermissionModel> AndroidMenuPermissions { get; set; }

        public DbSet<FromWarehousePermissionModel> FromWarehousePermissions { get; set; }
        public DbSet<ToWarehousePermissionModel> ToWarehousePermissions { get; set; }

        public DbSet<AccountHeadPermissionModel> AccountHeadPermissions { get; set; }



        public DbSet<WorkOrderMaster> WorkOrderMaster { get; set; }
        public DbSet<COM_MachineryLCDetails> COM_MachineryLCDetails { get; set; }
        public DbSet<COM_MachineryLCMaster> WorkOCOM_MachineryLCMasterrderMaster { get; set; }
        public DbSet<ApprovedBy> ApprovedBy { get; set; }
        public DbSet<WorkorderStatus> WorkorderStatus { get; set; }




        public DbSet<MenuPermission_MasterModel> MenuPermission_Master { get; set; }
        public DbSet<MenuPermission_DetailsModel> MenuPermission_Details { get; set; }


        public DbSet<AndroidMenuPermission_MasterModel> AndroidMenuPermission_Master { get; set; }
        public DbSet<AndroidMenuPermission_DetailsModel> AndroidMenuPermission_Details { get; set; }

        public DbSet<UserRoleModel> UserRoles { get; set; }

        public DbSet<UserLogingInfoModel> UserLoginginfos { get; set; }
        public DbSet<UserTransactionLogModel> UserTransactionLogs { get; set; }
        public DbSet<CostCalculatedModel> CostCalculatedInfo { get; set; }




        public DbSet<CreditBalanceModel> CreditBalance { get; set; }
        public DbSet<CreditUsedModel> CreditUsed { get; set; }
        public DbSet<WalletModel> Wallet { get; set; }


        public DbSet<StyleModel> Style { get; set; }
        public DbSet<ColorsChildModel> ColorsChilds { get; set; }
        public DbSet<SizesChildModel> SizesChilds { get; set; }


        public DbSet<PurchaseModel> Purchase { get; set; }
        public DbSet<PurchaseItemsModel> PurchaseItems { get; set; }
        public DbSet<PurchaseItemsCategoryModel> PurchaseItemsCategory { get; set; }
        public DbSet<PurchaseBatchItemsModel> PurchaseBatchItems { get; set; }
        public DbSet<WarrantyItemsModel> WarrantyItems { get; set; }



        public DbSet<InvoiceBillModel> InvoiceBills { get; set; }


        public DbSet<InternetPackageModel> InternetPackages { get; set; }
        public DbSet<COM_ProformaInvoice> Com_proformaInvoice { get; set; }
        public DbSet<PINature> PINature { get; set; }

        public DbSet<InternetUserModel> InternetUsers { get; set; }
        public DbSet<InternetUserStatusModel> InternetUserStatus { get; set; }
        public DbSet<ExpireDateExtendModel> ExpireDateExtends { get; set; }
        public DbSet<UserTerminateModel> UserTerminateData { get; set; }
        public DbSet<ProductLedgerModel> ProductLedgerData { get; set; }

        public DbSet<ProductType> ProductType { get; set; }
        public DbSet<TestRouterOnuTrackingModel> TestRouterOnuTracking { get; set; }

        public DbSet<ToDoModel> ToDoData { get; set; }
        public DbSet<WarrentyModel> WarrentyData { get; set; }

        public DbSet<TimeZoneSettingsModel> TimeZoneSettings { get; set; }
        public DbSet<TagsModel> Tags { get; set; }

        public DbSet<DurationTimeModel> DurationTime { get; set; }
        public DbSet<TradeTermsModel> TradeTerms { get; set; }
        public DbSet<CommercialTradeTerm> CommercialTradeTerm { get; set; }
        public DbSet<CommercialType> CommercialType { get; set; }
        public DbSet<ShipMode> ShipMode { get; set; }
        public DbSet<DayListTerm> DayListTerm { get; set; }

        //public DbSet<ColorModel> ColorData { get; set; }
        //public DbSet<SizeModel> SizeData { get; set; }
        public DbSet<DocTypeModel> DocTypeData { get; set; }



        public DbSet<ActivationTicketModel> ActivationTickets { get; set; }
        public DbSet<TroubleTicketModel> TroubleTickets { get; set; }
        public DbSet<TroubleTicketCommentModel> TroubleTicketComments { get; set; }


        public DbSet<InternetComplainModel> InternetComplain { get; set; }
        public DbSet<DiagnosisReportModel> DiagnosisReport { get; set; }
        public DbSet<DeliveryServiceWeightModel> DeliveryServiceWeight { get; set; }
        public DbSet<DeliveryServiceDistanceModel> DeliveryServiceDistance { get; set; }
        public DbSet<DeliveryServiceTimingModel> DeliveryServiceTiming { get; set; }
        public DbSet<DeliveryServiceModel> DeliveryService { get; set; }
        public DbSet<DeliveryServiceCommentModel> DeliveryServiceComment { get; set; }
        public DbSet<OfferModel> Offer { get; set; }
        public DbSet<ShippingChargeModel> ShippingCharge { get; set; }




        public DbSet<DailyCurrencyRate> DailyCurrencyRate { get; set; }

        public DbSet<Acc_VoucherMainModel> AccVoucherMain { get; set; }
        public DbSet<Acc_VoucherSubModel> AccVoucherSub { get; set; }
        public DbSet<Acc_VoucherSubChecknoModel> Acc_VoucherSubCheckno { get; set; }
        public DbSet<Acc_VoucherSubSectionModel> Acc_VoucherSubSection { get; set; }
        public DbSet<Acc_VoucherTranGroupModel> Acc_VoucherTranGroup { get; set; }
        public DbSet<VoucherTranGroupModel> VoucherTranGroup { get; set; }
        public DbSet<Cat_SubSectionModel> Cat_SubSection { get; set; }
        public DbSet<Cat_SectionModel> Cat_Section { get; set; }



        public DbSet<Cat_DepartmentModel> Cat_Department { get; set; }
        public DbSet<Cat_DesignationModel> Cat_Designation { get; set; }

        public DbSet<Acc_VoucherNoPrefixModel> Acc_VoucherNoPrefix { get; set; }
        public DbSet<Acc_VoucherTypeModel> Acc_VoucherType { get; set; }
        public DbSet<Acc_VoucherNoCreatedTypeModel> Acc_VoucherNoCreatedType { get; set; }
        public DbSet<Acc_FiscalYearModel> Acc_FiscalYear { get; set; }
        public DbSet<Acc_FiscalMonthModel> Acc_FiscalMonth { get; set; }
        public DbSet<Acc_FiscalHalfYear> Acc_FiscalHalfYear { get; set; }
        public DbSet<Acc_FiscalQtr> Acc_FiscalQtr { get; set; }
        public DbSet<PrdUnit> PrdUnit { get; set; }
        public DbSet<Cat_Integration_Setting_Main> IntegrationSettingMain { get; set; }
        public DbSet<Cat_Integration_Setting_Details> IntegrationSettingDetails { get; set; }
        public DbSet<Cat_PayrollIntegrationSummary> PayrollIntegration { get; set; }
        public DbSet<ProcessLock> ProcessLock { get; set; }
        public DbSet<NotificationModel> Notification { get; set; }
        public DbSet<DiscountTypeModel> DiscountType { get; set; }

        public DbSet<NotificationSeenModel> NotificationSeen { get; set; }
        public DbSet<EmployeeAttendanceModel> EmployeeAttendance { get; set; }
        public DbSet<HR_ProcessLockModel> HR_ProcessLock { get; set; }

        public DbSet<TaskToDoModel> TaskToDoModel { get; set; }
        public DbSet<MobileTextAnimationModel> MobileTextAnimation { get; set; }










        public DbSet<Cat_BankModel> Cat_Bank { get; set; }
        public DbSet<Cat_BankBranchModel> Cat_BankBranch { get; set; }
        public DbSet<Cat_BuildingTypeModel> Cat_BuildingType { get; set; }
        public DbSet<Cat_PostOfficeModel> Cat_PostOffice { get; set; }
        public DbSet<Cat_PoliceStationModel> Cat_PoliceStation { get; set; }
        public DbSet<HR_Emp_EducationModel> HR_Emp_Education { get; set; }



        public DbSet<HR_Emp_ExperienceModel> HR_Emp_Experience { get; set; }
        public DbSet<Cat_AccountTypeModel> Cat_AccountType { get; set; }
        public DbSet<Cat_PayModeModel> Cat_PayMode { get; set; }


        //Notification For android and IOS.....

        public DbSet<NotificationSetting> NotificationSettings { get; set; }
        public DbSet<NotificationMassage> NotificationMassages { get; set; }


    }









}
