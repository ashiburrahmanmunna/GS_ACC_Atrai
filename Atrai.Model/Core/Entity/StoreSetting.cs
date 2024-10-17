
using Atrai.Model.Core.Entity.Base;

using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Atrai.Model.Core.Entity
{
    [Table("StoreSetting")]
    public class StoreSettingModel : BaseModel
    {
        [StringLength(400)]
        public string? Logo { get; set; }

        [DisplayName("Store Name")]
        [StringLength(200)]
        public string? StoreName { get; set; }

        [EmailAddress]
        [Required]
        public string? Email { get; set; }
        [Required]
        [StringLength(80)]

        public string? Web { get; set; }

        [StringLength(50)]

        public string? Facebook { get; set; }

        [Phone]
        [Required]
        public string? Phone { get; set; }

        [StringLength(30)]

        [DisplayName("Other Phone")]

        public string? PhoneTwo { get; set; }

        [StringLength(200)]

        [DisplayName("Report Caption After Compnay Name")]

        public string? ReportCaptionSmall { get; set; }

        [StringLength(60)]

        [DisplayName("If You Need Customizaed Report Format Then Place the Name ")]

        public string? CustomizedReportFormatName { get; set; }

        //[Required]
        //public string? Currency { get; set; }
        [DataType(DataType.MultilineText)]
        [StringLength(400)]
        public string? Address { get; set; }


        [Display(Name = "Business Type")]
        public virtual BusinessTypeModel BusinessType { get; set; }
        [Display(Name = "Business Type")]
        [ForeignKey("BusinessType")]
        public int BusinessTypeId { get; set; }

        //[Display(Name = "Fiscal Year")]
        //public virtual FiscalYearTypeModel FiscalYearType { get; set; }
        //[Display(Name = "Fiscal Year Type")]
        //[ForeignKey("FiscalYearType")]
        //public int? FiscalYearTypeId { get; set; }


        [Display(Name = "Time Zone")]
        public virtual TimeZoneSettingsModel TimeZones { get; set; }
        [Display(Name = "Time Zone")]
        [ForeignKey("TimeZones")]
        public int TimeZoneSettingsId { get; set; }



        [Display(Name = "Sales Report Style")]
        public virtual ReportStyleModel SalesReportStyle { get; set; }
        [Display(Name = "Sales Report Style")]
        [ForeignKey("SalesReportStyle")]
        public int? SalesReportStyleId { get; set; }


        [Display(Name = "Purchase Report Style")]
        public virtual ReportStyleModel PurchaseReportStyle { get; set; }
        [Display(Name = "Purchase Report Style")]
        [ForeignKey("PurchaseReportStyle")]
        public int? PurchaseReportStyleId { get; set; }


        [Display(Name = "Barcode Report Style")]
        public virtual ReportStyleModel BarcodeReportStyle { get; set; }
        [Display(Name = "Barcode Report Style")]
        [ForeignKey("BarcodeReportStyle")]
        public int? BarcodeReportStyleId { get; set; }



        [Display(Name = "Subscription Type")]
        public virtual SubscriptionTypeModel SubscriptionType { get; set; }
        [Display(Name = "Subscription Type")]
        [ForeignKey("SubscriptionType")]
        public int? SubscriptionTypeId { get; set; }


        [Display(Name = "Currency")]
        public virtual CountryModel? Currency { get; set; }
        [Display(Name = "Currency")]
        [ForeignKey("Currency")]
        public int CurrencyId { get; set; }



        [Display(Name = "Country")]
        public virtual CountryModel? Country { get; set; }
        [Display(Name = "Country")]
        [ForeignKey("Country")]
        public int CountryId { get; set; }

        [Display(Name = "Decimal Field")]

        public int DecimalField { get; set; } = 0;




        //[StringLength(50)]
        [Display(Name = "Tax % [If Applicable]")]
        [Column(TypeName = "decimal(18,4)")]
        public double TaxPer { get; set; } = 0;

        [Display(Name = "Tax Excluded")]
        public bool isTaxExcluded { get; set; }



        [Display(Name = "Discount % [For Offer]")]
        [Column(TypeName = "decimal(18,4)")]
        public double OfferDiscountPer { get; set; } = 0;

        [Display(Name = "Enable Discount Offer")]
        public bool isDiscountOffer { get; set; }



        [Display(Name = "Header Caption / Vat Details")]
        //[Required]
        [DataType(DataType.MultilineText)]
        [StringLength(400)]
        public string? HeaderCaption { get; set; }



        [Display(Name = "Enable Multi Currency")]
        public bool isMultiCurrency { get; set; }


        [Display(Name = "Enable Terms Condition")]
        public bool IsTermsCondition { get; set; }

        [Display(Name = "Default Discount By Amount")]
        public bool IsDefaultDisAmount { get; set; }


        [Display(Name = "Enable Multi Debit Credit")]
        public bool isMultiDebitCredit { get; set; }

        [Display(Name = "Voucher Account Head Dist. Expense")]
        public bool isVoucherDistributionEntry { get; set; }

        [Display(Name = "Voucher Cheque Details ")]
        public bool isChequeDetails { get; set; }


        [Display(Name = "Voucher No Created Types")]
        public int? VoucherNoCreatedTypeId { get; set; }
        [ForeignKey("VoucherNoCreatedTypeId")]
        public virtual Acc_VoucherNoCreatedTypeModel VoucherNoCreatedTypes { get; set; }


        [Display(Name = "Fixed Sales Unit Price")]
        public bool IsFixedSalesValue { get; set; }


        [Display(Name = "Multiselect Dropdown")]
        public bool isMultiSelect { get; set; }

        

        [Display(Name = "Not Editable Discount [ Row ]")]
        public bool IsFixedDiscountRowValue { get; set; }

        [Display(Name = "Maximum Value of Discount [Row]")]
        public double MaxDiscountRowValue { get; set; } = 0;



        [Display(Name = "Not Editable Discount [ Final ]")]
        public bool IsFixedDiscountMainValue { get; set; }


        [Display(Name = "Maximum Value of Discount [Final Value]")]
        public double MaxDiscountMainValue { get; set; } = 0;


        [Display(Name = "Maximum % of Discount [Final Value]")]
        public double MaxDiscountPercentageMainValue { get; set; } = 0;




        [Display(Name = "First Letter Upper Case")]
        public bool IsFirstLetterUpperCase { get; set; }



        [Display(Name = "Back Date Permission Days")]

        public int Days { get; set; } = 0;

        [Display(Name = "Redirect to Ecommerce Page")]

        public bool RedirectToEcommercePage { get; set; }

        [Display(Name = "Back Date Permission")]
        public bool isBackDatePermission { get; set; }







        [Display(Name = "Enable Serial Sales")]
        public bool IsSerialSales { get; set; }
        [Display(Name = "Enable Sales Description")]
        public bool IsSalesDescription { get; set; }
        [Display(Name = "Enable Ind. Discount")]
        public bool IsIndDiscount { get; set; }





        [Display(Name = "Print Product Code")]
        public bool PrintProductCode { get; set; }
        [Display(Name = "Print Product Name")]
        public bool PrintProductName { get; set; }
        [Display(Name = "Print Brand")]
        public bool PrintBrandName { get; set; }
        [Display(Name = "Print Model")]
        public bool PrintModelName { get; set; }
        [Display(Name = "Print Size")]
        public bool PrintSizeName { get; set; }

        [Display(Name = "Print Proudct Description")]
        public bool PrintProductDescription { get; set; }


        [Display(Name = "Visible Sales Comission")]
        public bool VisibleSalesCommission { get; set; }



        [Display(Name = "VAT Login")]
        public bool IsVatLogin { get; set; }








        //[ForeignKey("BaseCompanyList")]
        public int BaseComId { get; set; }
        //[Display(Name = "Company")]
        //public virtual CompanyModel BaseCompanyList { get; set; }

        [Display(Name = "Enable SMS Service")]
        public bool isSMSService { get; set; }



        [Display(Name = "Enable Email Service")]
        public bool isEmailSerivce { get; set; }


        [Display(Name = "Enable Signature Field In Reporting")]
        public bool IsSignature { get; set; }



        [Display(Name = "Enable Scanner")]
        public bool isScanner { get; set; }


        [Display(Name = "Short-Cut Key")]
        [StringLength(2)]
        public string? ShortCutKey { get; set; }


        [Display(Name = "Barcode Prefix For Weight Scale")]
        [StringLength(6)]
        public string? BarcodePrefixForWeightScale { get; set; }

        [Display(Name = "Software Package")]
        [ForeignKey("SoftwarePackages")]
        public int? SoftwarePackageId  { get; set; }
        public virtual SoftwarePackageModel SoftwarePackages { get; set; }


        //newly addedd for company starts============================
        [Display(Name = "Legal Name")]
        [StringLength(200)]
        public string? LegalName { get; set; }

        [Display(Name = "Business Id No")]
        [StringLength(200)]
        public string? BusinessIdNo { get; set; }

        [Display(Name = "Vat")]
        [StringLength(200)]
        public string? vat { get; set; }

        [EmailAddress]
        [DataType(DataType.EmailAddress)]
        [Display(Name = "Customer Facing Email Address")]
        public string? customerFacingEmail { get; set; }

        [StringLength(300)]
        [Display(Name = "City")]
        public string? City { get; set; }
        
        [StringLength(300)]
        [Display(Name = "State")]
        public string? State { get; set; }

        [StringLength(300)]
        [Display(Name = "Zip code")]
        public string? ZipCode { get; set; }

        [DataType(DataType.MultilineText)]
        [StringLength(300)]
        [Display(Name = "Customer Facing Address")]
        public string? CustomerFacingAddress { get; set; }

        [DataType(DataType.MultilineText)]
        [StringLength(300)]
        [Display(Name = "Customer Facing City Address")]
        public string? CustomerFacingCityAddress { get; set; }

        [StringLength(300)]
        [Display(Name = "Customer Facing State")]
        public string? CustomerFacingState { get; set; }

        [StringLength(300)]
        [Display(Name = "Customer Facing Zip code")]
        public string? CustomerFacingZipCode { get; set; }


        [DataType(DataType.MultilineText)]
        [StringLength(300)]
        [Display(Name = "Legal Address")]
        public string? LegalAddress { get; set; }

        [DataType(DataType.MultilineText)]
        [StringLength(300)]
        [Display(Name = "Legal City Address")]
        public string? LegalCityAddress { get; set; }

        [StringLength(300)]
        [Display(Name = "Legal State")]
        public string? LegalState { get; set; }

        [StringLength(300)]
        [Display(Name = "Legal Zip code")]
        public string? LegalZipCode { get; set; }

        [Display(Name = "Tax Form")]
        public virtual TaxFormModel TaxForm { get; set; }
        [Display(Name = "Tax Form")]
        [ForeignKey("TaxForm")]
        public int? TaxFormId { get; set; }
        //newly addedd for company ends============================





        //newly addedd for sales starts============================

        public int? TermsId { get; set; }
        [ForeignKey("TermsId")]
        public virtual PaymentTermsModel? TermsInfo { get; set; }

        [StringLength(100)]
        [Display(Name = "Delivery Method")]
        public string? DeliveryMethod { get; set; }
        public bool IsShipping { get; set; }
        public bool IsCustomTransactionNumber { get; set; }
        public bool IsServiceDate { get; set; }
        public bool IsDiscount { get; set; }
        public bool IsDeposit { get; set; }
        public bool IsTags { get; set; }

        [StringLength(300)]
        [Display(Name = "Payment Instructions")]
        public string? PaymentInstructions { get; set; }
        public bool IsShowProductServiceColumn { get; set; }
        public bool IsShowSku { get; set; }
        public bool IsTracktyRatePrice { get; set; }
        public bool IsTrackQtyOnHand { get; set; }
        public bool IsCreateMultiplePartialInvoice { get; set; }

        [StringLength(50)]
        [Display(Name = "Greeting Appeal")]
        public string? GreetingAppeal { get; set; }
        [StringLength(100)]
        [Display(Name = "Greeting NameFormat")]
        public string? GreetingNameFormat { get; set; }

        [Display(Name = "Doc Type")]
        [ForeignKey("DocTypeList")]
        public int? DocTypeId { get; set; }
        [Display(Name = "Doc Type")]
        public virtual DocTypeModel? DocTypeList { get; set; }
        [StringLength(100)]
        [Display(Name = "Email SubjectLine")]
        public string? EmailSubjectLine { get; set; }
        [StringLength(500)]
        [Display(Name = "Email Message")]
        public string? EmailMessage { get; set; }
        public bool IsCopyEmail { get; set; }
        [StringLength(200)]
        [Display(Name = "Cc")]
        public string? Cc { get; set; }
        [StringLength(200)]
        [Display(Name = "Bcc")]
        public string? Bcc { get; set; }

        [Display(Name = "Reminder One Days")]
        public string? ReminderOneDays { get; set; }
        [StringLength(20)]
        [Display(Name = "Reminder One DueDate")]
        public string? ReminderOneDueDate { get; set; }
        [StringLength(20)]
        [Display(Name = "Reminder One SubjectLine")]
        public string? ReminderOneSubjectLine { get; set; }
        [StringLength(20)]
        [Display(Name = "Reminder One GreetingAppeal")]
        public string? ReminderOneGreetingAppeal { get; set; }
        [StringLength(50)]
        [Display(Name = "ReminderOne Greeting Name Format")]
        public string? ReminderOneGreetingNameFormat { get; set; }
        [StringLength(500)]
        [Display(Name = "Reminder One Message")]
        public string? ReminderOneMessage { get; set; }

        [Display(Name = "Reminder Two Days")]
        public string? ReminderTwoDays { get; set; }

        [Display(Name = "Reminder Two DueDate")]
        public string? ReminderTwoDueDate { get; set; }

        [Display(Name = "Reminder Two SubjectLine")]
        [StringLength(20)]
        public string? ReminderTwoSubjectLine { get; set; }

        [Display(Name = "Reminder Two GreetingAppeal")]
        [StringLength(20)]
        public string? ReminderTwoGreetingAppeal { get; set; }

        [Display(Name = "Reminder Two Greeting Name Format")]
        [StringLength(50)]
        public string? ReminderTwoGreetingNameFormat { get; set; }

        [Display(Name = "Reminder Two Message")]
        [StringLength(500)]
        public string? ReminderTwoMessage { get; set; }


        [Display(Name = "Reminder Three Days")]
        public string? ReminderThreeDays { get; set; } 

        [Display(Name = "Reminder Three DueDate")]
        public string? ReminderThreeDueDate { get; set; }

        [Display(Name = "Reminder Three SubjectLine")] 
        [StringLength(20)]
        public string? ReminderThreeSubjectLine { get; set; }

        [Display(Name = "Reminder Three GreetingAppeal")]
        [StringLength(20)]
        public string? ReminderThreeGreetingAppeal { get; set; }

        [Display(Name = "Reminder Three Greeting Name Format")]
        [StringLength(50)]
        public string? ReminderThreeGreetingNameFormat { get; set; }

        [Display(Name = "Reminder Three Message")]
        [StringLength(500)]
        public string? ReminderThreeMessage { get; set; }

        public bool IsShowSummaryInEmail { get; set; }
        public bool IsShowFullDetailsInEmail { get; set; }
        public bool IsPdfAttached { get; set; }
        public string? AdditionalEmailOptions { get; set; }

        public bool IsListEachTransaction { get; set; }
        public bool IsListAllTransaction { get; set; }
        //newly addedd for sales ends============================



        //newly addedd for expenses starts============================
        public bool IsShowItemsTablesOnForms { get; set; }
        public bool IsShowTagsOnFroms { get; set; }
        public bool IsTrackedByCustomer { get; set; }
        public bool IsBillableItemAndExpenses { get; set; }
        public bool IsSalesCustomtransactionNumber { get; set; }

        [Display(Name = "Default Message for purchase")]
        [StringLength(500)]
        public string? DefaultMessageForPurchase { get; set; }

        [StringLength(50)]
        [Display(Name = "Sales Greeting Appeal")]
        public string? SalesGreetingAppeal { get; set; }
        [StringLength(100)]
        [Display(Name = "Greeting NameFormat")]
        public string? SalesGreetingNameFormat { get; set; }

        [StringLength(100)]
        [Display(Name = "Sales Email SubjectLine")]
        public string? SalesEmailSubjectLine { get; set; }
        [StringLength(500)]
        [Display(Name = "Sales Email Message")]
        public string? SalesEmailMessage { get; set; }
        public bool IsSalesCopyEmail { get; set; }
        [StringLength(200)]
        [Display(Name = "Cc")]
        public string? SalesCc { get; set; }
        [StringLength(200)]
        [Display(Name = "Bcc")]
        public string? SalesBcc { get; set; }
        //newly addedd for expenses ends==============================


        //newly addedd for time starts============================
        [Display(Name = "First day of week")]
        [StringLength(50)]
        public string? FirstDayOfWeek { get; set; }

        public bool IsShowServiceField { get; set; }
        public bool IsAllowTimeToBillable{ get; set; }
        public bool IsShowBillingRateToUser{ get; set; }
        //newly addedd for time ends==============================



        //newly addedd for advanced starts============================

        public int? FinancialYearId { get; set; }
        [ForeignKey("FinancialYearId")]
        public virtual VariableModel FinancialYears { get; set; }
        public int? AccountingMethodId { get; set; }
        [ForeignKey("AccountingMethodId")]
        public virtual VariableModel AccountingMethods { get; set; }

        public int? TaxRateId { get; set; }
        [ForeignKey("TaxRateId")]
        public virtual VariableModel TaxRates { get; set; }
        public int? LanguageId { get; set; }
        [ForeignKey("LanguageId")]
        public virtual VariableModel Languages { get; set; }

        public int? DateFormatId { get; set; }
        [ForeignKey("DateFormatId")]
        public virtual VariableModel DateFormats { get; set; }
        public int? NumberFormatId { get; set; }
        [ForeignKey("NumberFormatId")]
        public virtual VariableModel NumberFormats { get; set; }
        public int? SignOutDurationId { get; set; }
        [ForeignKey("SignOutDurationId")]
        public virtual VariableModel SignOutDurations { get; set; }


        [Display(Name = "Fix month of the tax year")]
        [StringLength(50)]
        public string? fixMonthofTaxYear { get; set; }

        public bool IsCloseTheBooks { get; set; }
        public bool IsEnabledAccNumbers { get; set; }
        public bool IsTrackedClasses { get; set; }
        public bool IsTrackedLocations { get; set; }
        public bool IsPreFillFormsPrevEnteredContent { get; set; }
        public bool IsAutoInvoicedUnbilled { get; set; }
        public bool IsAutoAppliedBillPayment { get; set; }
        public bool IsOrganisedJob { get; set; }
        public bool IsDuplicateCheque { get; set; }
        public bool IsDuplicateBillNo { get; set; }
        public bool IsDuplicateJournal { get; set; }
        //newly addedd for advanced ends==============================


    }






    [Table("PaymentMethod")]
    public class PaymentMethodModel : BaseModel
    {

        [DisplayName("Card Number")]
        [StringLength(200)]
        public string? CardNumber { get; set; }

        [DisplayName("Card Nick Name")]
        [StringLength(200)]
        public string? CardNickName { get; set; }

        [DisplayName("Name On Card")]
        [StringLength(200)]
        public string? NameOnCard { get; set; }

        [Display(Name = "Country")]
        public virtual CountryModel? Country { get; set; }
        [Display(Name = "Country")]
        [ForeignKey("Country")]
        public int CountryId { get; set; }

        [Display(Name = "Tax Debit/Credit")]
        public bool IsDebitCredit { get; set; }

        [Display(Name = "Pay Pal")]
        public bool IsPayPal { get; set; }


        [Display(Name = "Store Setting")]
        [ForeignKey("StoreSettings")]
        public int? StoreSettingId { get; set; }
        public virtual StoreSettingModel StoreSettings { get; set; }

        [Display(Name = "Month")]
        public string? Month { get; set; }

        [Display(Name = "Year")]
        public string? Year { get; set; }

        [Display(Name = "CW")]
        public string? CW { get; set; }

        [DataType(DataType.MultilineText)]
        [StringLength(300)]
        [Display(Name = "Address")]
        public string? Address { get; set; }

        [StringLength(300)]
        [Display(Name = "City")]
        public string? City { get; set; }

        [StringLength(300)]
        [Display(Name = "State")]
        public string? State { get; set; }

        [StringLength(300)]
        [Display(Name = "Zip code")]
        public string? ZipCode { get; set; }



        [DataType(DataType.MultilineText)]
        [StringLength(300)]
        [Display(Name = "Legal Address")]
        public string? LegalAddress { get; set; }

        [DataType(DataType.MultilineText)]
        [StringLength(300)]
        [Display(Name = "Legal City Address")]
        public string? LegalCityAddress { get; set; }

        [StringLength(300)]
        [Display(Name = "Legal State")]
        public string? LegalState { get; set; }

        [StringLength(300)]
        [Display(Name = "Legal Zip code")]
        public string? LegalZipCode { get; set; }

        [StringLength(30)]
        [Display(Name = "Business Id No")]
        public string? BusinessIdNo { get; set; }

    }


}
