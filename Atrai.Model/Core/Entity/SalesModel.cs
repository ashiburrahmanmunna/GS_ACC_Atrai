using Atrai.Model.Core.Entity.Base;
using Atrai.Model.Core.Entity.Self;
using DocumentFormat.OpenXml.Drawing;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Drawing;
using System.Numerics;

namespace Atrai.Model.Core.Entity
{
    [Table("Sales")]
    public class SalesModel : BaseModel
    {
        /// <summary>
        ///  Remarks , ttlSumQty , ttlCountQty , ttlUnitPrice , ttlIndVat , ttlIndDisAmt , ttlIndPrice , ttlSumAmt will be delete
        /// </summary>
        /// 
        public bool IsRecognition { get; set; }
        [Required]
        [DisplayName("Sales Date")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd-MMM-yyyy}", ApplyFormatInEditMode = true)]
        [Column(TypeName = "datetime2")]
        public DateTime SalesDate { get; set; }
        public bool IsPaymentDone { get; set; }

        [Required]
        [DisplayName("Due Date")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd-MMM-yyyy}", ApplyFormatInEditMode = true)]
        [Column(TypeName = "datetime2")]
        public DateTime DueDate { get; set; }

        [DisplayName("Sales Doc No")]
                //[Column(TypeName = "varchar(50)")]
        [StringLength(40)]
        public string? SaleCode { get; set; } = string.Empty;
        public string? StatusBy { get; set; } = string.Empty;

        public DateTime? StatusDate { get; set; }

        [StringLength(200)]
        public string? Notes { get; set; } = string.Empty;

        [Required]
        public Double Total { get; set; }

        public Double SubTotal { get; set; }

        public Double TaxAmount { get; set; }

        [StringLength(100)]

        public string? StatusRemarks { get; set; }

        public string? ApprovalStage { get; set; }

        public int ReturnStatus { get; set; } = 0;

        public int PaymentStatus { get; set; } = 0;


        [Column(TypeName = "decimal(18,4)")]
        public decimal? Discount { get; set; }

        [Column(TypeName = "decimal(18,4)")]
        public decimal? CustomerCommissionAmount { get; set; }


        [Column(TypeName = "decimal(18,4)")]
        public decimal? SRCommissionAmount { get; set; }


        [Column(TypeName = "decimal(18,4)")]
        public decimal? CustomerCommissionPer { get; set; }


        [Column(TypeName = "decimal(18,4)")]
        public decimal? SRCommissionPer { get; set; }


        [Column(TypeName = "decimal(18,4)")]

        public decimal GrandTotal { get; set; }

        [Column(TypeName = "decimal(18,4)")]

        public decimal TotalCommisionAmount { get; set; }


        [Column(TypeName = "decimal(18,4)")]
        public decimal PrevDue { get; set; }


        [Display(Name = "salesRecieved Terms")]
        [ForeignKey("salesRecievedTermsInfo")]
        public int? salesRecievedtTermsId { get; set; }
        [Display(Name = "salesRecieved Terms")]
        public virtual PaymentTermsModel? salesRecievedTermsInfo { get; set; }



        //[DisplayName("Payment Method")]
        //[StringLength(20)]

        //public string? PaymentMethod { get; set; }

        //[StringLength(200)]

        //[DataType(DataType.MultilineText)]
        //public string? Remarks { get; set; }


        [Phone]
        [DisplayName("Phone No")]
        [StringLength(30)]

        public string? PhoneNo { get; set; } = string.Empty;

        [StringLength(20)]

        [DisplayName("Postal Code")]
        public string? PostalCode { get; set; } = string.Empty;


        [StringLength(50)]

        [DisplayName("Email")]
        public string? EmailId { get; set; } = string.Empty;
        [StringLength(50)]

        [DisplayName("City")]
        public string? City { get; set; }

        public Boolean isDisPer { get; set; }

        [Display(Name = "% Discount")]

        [Column(TypeName = "decimal(18,4)")]
        public double DisPer { get; set; }
        [Display(Name = "Dis. Amount")]

        [Column(TypeName = "decimal(18,4)")]
        public decimal DisAmt { get; set; }

        [Display(Name = "Service Charge")]
        [DisplayFormat(DataFormatString = "{0:#,#.00}")]

        [Column(TypeName = "decimal(18,4)")]
        public decimal ServiceCharge { get; set; }

        [Display(Name = "Shipping")]

        [Column(TypeName = "decimal(18,4)")]
        public decimal Shipping { get; set; }
        
        [Display(Name = "Shipping Tax")]

        [Column(TypeName = "decimal(18,4)")]
        public decimal ShippingTax { get; set; }

        [StringLength(20)]
        public string? AmountsAre { get; set; }

        [Display(Name = "Total Vat ")]

        [Column(TypeName = "decimal(18,4)")]
        public decimal TotalVat { get; set; }


        [Display(Name = "Net Amount")]

        [Column(TypeName = "decimal(18,4)")]
        public decimal NetAmount { get; set; }
        [Display(Name = "Paid Amount")]


        [Column(TypeName = "decimal(18,4)")]
        public decimal PaidAmt { get; set; }
        public bool IsRecurring { get; set; }
        public bool IsPending { get; set; }


        [Display(Name = "Reward Point")]
        public int RewardPointValue { get; set; }


        [Display(Name = "Due Amount")]
        [Column(TypeName = "decimal(18,4)")]
        public decimal DueAmt { get; set; }

        [Display(Name = "Store Location")]
        public int WarehouseIdMain { get; set; }
        [ForeignKey("WarehouseIdMain")]
        public virtual WarehouseModel? Warehouses { get; set; }

        public int? FiscalMonthId { get; set; }
        [ForeignKey("FiscalMonthId")]
        public virtual Acc_FiscalMonthModel? Acc_FiscalMonth { get; set; }


        [DisplayName("CustomerId")]
        [ForeignKey("CustomerModel")]
        public int CustomerId { get; set; }
        public CustomerModel? CustomerModel { get; set; }
        [StringLength(100)]

        [Display(Name = "Customer Name")]
        public string? CustomerName { get; set; } = string.Empty;
        [StringLength(200)]

        //[Required]
        [DataType(DataType.MultilineText)]
        [Display(Name = "Primary Address")]
        public string? PrimaryAddress { get; set; } = string.Empty;

        [StringLength(200)]

        //[Required]
        [DataType(DataType.MultilineText)]
        [Display(Name = "Secoundary Address")]
        public string? SecoundaryAddress { get; set; } = string.Empty;


        public bool isPOSSales { get; set; }
        public bool isSerialSales { get; set; }
        public bool isWholeSales { get; set; }

        public bool isPosted { get; set; }

        [Column(TypeName = "decimal(18,4)")]
        public decimal Profit { get; set; }
        [Column(TypeName = "decimal(18,4)")]
        public decimal ProfitPercentage { get; set; }
        [Column(TypeName = "decimal(18,4)")]
        public decimal FinalCostingPrice { get; set; }


        [Column(TypeName = "decimal(18,4)")]
        public decimal PaidAmount { get; set; }

        [Column(TypeName = "decimal(18,4)")]
        public decimal ChangeAmount { get; set; }


        public bool IsVatSales { get; set; }



        [DisplayName("Currency")]
        [ForeignKey("Currency")]
        public int? CurrencyId { get; set; }
        public CountryModel? Currency { get; set; }

        [Display(Name = "Status")]
        public int? StatusId { get; set; }
        [ForeignKey("StatusId")]
        public virtual StatusModel? StatusValue { get; set; }

        [Column(TypeName = "decimal(18,4)")]
        public double CurrencyRate { get; set; }

        public string? ShippingTo { get; set; } = string.Empty;

        public string? ShippingVia { get; set; } = string.Empty;

        public DateTime? ShippingDate { get; set; }

        public string? TrackingNo { get; set; } = string.Empty;

        public string? FileName { get; set; } = string.Empty;

        public string? MessageInvoice { get; set; } = string.Empty;

        public string? MessageStatement { get; set; } = string.Empty;

        [StringLength(100)]
        public string? StatusUpdatedBy { get; set; } = string.Empty;

        public DateTime StatusUpdateDate { get; set; }


        public ICollection<SalesItemsModel> Items { get; set; }
        public ICollection<RecurringDetailsModel>? RecurringDetails { get; set; }
        public ICollection<SalesProductTaxModel> SalesProductTax { get; set; }

        public virtual ICollection<SalesTagModel> SalesTags { get; set; }
        public virtual ICollection<SalesPaymentModel>? SalesPayments { get; set; }

        public virtual ICollection<SalesTermsModel> SalesTerms { get; set; }

        public virtual ICollection<CostCalculatedModel> CostCalculations { get; set; }

        public virtual ICollection<TransactionModel>? AccountTransaction { get; set; }

        public ICollection<SalesReturnModel> SalesReturn { get; set; }


        [NotMapped]
        [DataType(DataType.Text)]
        [Display(Name = "UserId")]
        public string? UserId { get; set; }




        [Display(Name = "User Name")]
        [ForeignKey("InternetUserList")]
        public int? InternetUserId { get; set; }
        [Display(Name = "Internet User")]
        public virtual InternetUserModel? InternetUserList { get; set; }


        [Display(Name = "Doc Type")]
        [ForeignKey("DocTypeList")]
        public int? DocTypeId { get; set; }
        [Display(Name = "Doc Type")]
        public virtual DocTypeModel? DocTypeList { get; set; }


        [Display(Name = "Sales Representative")]
        [ForeignKey("SalesRep")]
        public int? SalesRepId { get; set; }
        [Display(Name = "Sales Representative")]
        public virtual EmployeeModel? SalesRep { get; set; }



        [DisplayName("OrderId")]
        [ForeignKey("OrdersModel")]
        public int? OrderId { get; set; }
        public OrdersModel OrdersModel { get; set; }


        public int? DocStatusId { get; set; }
        [ForeignKey("DocStatusId")]
        public virtual DocStatusModel? DocStatus { get; set; }
        

        public SalesModel()
        {
            Items = new List<SalesItemsModel>();
            SalesPayments = new List<SalesPaymentModel>();
            CostCalculations = new List<CostCalculatedModel>();
            AccountTransaction = new List<TransactionModel>();


        }



    }


    [Table("SalesItems")]
    public class SalesItemsModel : BaseModel
    {
        [DisplayName("ProductId")]
        [ForeignKey("ProductModel")]
        public int ProductId { get; set; }
        public virtual ProductModel? Product { get; set; }
        [StringLength(200)]

        public string? Name { get; set; }

        [Required]
        public double Price { get; set; }
        public double DefaultPrice { get; set; }
        [Required]
        public double Quantity { get; set; }
        [Required]
        public double Amount { get; set; }


        [Required]
        public double CommissionAmount { get; set; }
        [Required]
        public double CommissionPer { get; set; }
        [Required]
        public double UserCommissionAmount { get; set; }


        [Required]
        public double PCTN { get; set; }

        [Required]
        public double CartonQty { get; set; }


        [DataType(DataType.MultilineText)]
        [StringLength(200)]

        public string? Description { get; set; }


        [DisplayName("Sale")]
        [ForeignKey("SalesModel")]
        public int SalesId { get; set; }
        public SalesModel? SalesModel { get; set; }

        [Display(Name = "Store Location")]
        public int? WarehouseId { get; set; }

        [ForeignKey("WarehouseId")]

        public virtual WarehouseModel? vWarehouse { get; set; }

        [Required]
        [DisplayName("Service Date")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd-MMM-yyyy}", ApplyFormatInEditMode = true)]
        [Column(TypeName = "datetime2")]
        public DateTime ServiceDate { get; set; }

        public bool? IsTax { get; set; }

        [NotMapped]
        public string[]? SerialItemArray { get; set; }

        public string? SerialItem { get; set; } = string.Empty;
        [NotMapped]
        public bool IsTransaction { get; set; }

        public ICollection<SalesBatchItemsModel>? BatchSerialItems { get; set; }

        public double CostPrice { get; set; }

        public double AvgCostPrice { get; set; }



        [Column(TypeName = "decimal(18,4)")]
        public double IndDiscount { get; set; }

        [Column(TypeName = "decimal(18,4)")]
        public double IndDisPer { get; set; }

        public double IndDiscountProportion { get; set; }

        public Boolean isDisPerRow { get; set; }

        public int MasterTaxId { get; set; }

        public string? MasterTaxName { get; set; } = string.Empty;
        public string? WHName { get; set; } = string.Empty;

        //public int? SalesItemReturnId { get; set; }
        [Display(Name = "SalesReturn Items")]
        public int? SalesItemsId { get; set; }
        [ForeignKey("SalesItemsId")]
        public ICollection<SalesItemsModel>? SalesParentItems { get; set; }
        public virtual SalesItemsModel? SalesItemsParent { get; set; }

        //public int? Status { get; set; }
        public int? ItemsReturnStatus { get; set; }





        //[Display(Name = "BD PO Items")]
        //public int? PurchaseItemsId { get; set; }
        //[ForeignKey("PurchaseItemsId")]
        //public virtual ICollection<PurchaseItemsModel> PurchaseItems { get; set; }

        [Display(Name = "BD PO Items")]
        [ForeignKey("PurchaseItems")]
        public int? PurchaseItemsId { get; set; }
        public virtual PurchaseItemsModel? PurchaseItems { get; set; }


        [Display(Name = "Token Items")]
        [ForeignKey("TokenItems")]
        public int? TokenItemsId { get; set; }
        public virtual TokenSalesModel? TokenItems { get; set; }


        [Column(TypeName = "decimal(18,4)")]
        public double IssueQuantity { get; set; } = 0;

        [Column(TypeName = "decimal(18,4)")]
        public double ReturnQuantity { get; set; } = 0;

        [Column(TypeName = "decimal(18,4)")]
        public double ForwardSalesQuantity { get; set; } = 0;

        [Column(TypeName = "decimal(18,4)")]
        public double TokenSalesQty { get; set; } = 0;

        public int? PrimaryUnitId { get; set; }
        [ForeignKey("PrimaryUnitId")]
        public virtual UnitModel? PrimaryUnitModel { get; set; }

        public int? SecondaryUnitId { get; set; }
        [ForeignKey("SecondaryUnitId")]
        public virtual UnitModel? SecondaryUnitModel { get; set; }

        public double? ConversionRate { get; set; } = 0;

        public double? InputQuantity { get; set; } = 0;

        public string? Unit { get; set; }

        public double? SecondaryPrice { get; set; }

    }



    [Table("SalesProductTax")]
    public class SalesProductTaxModel : BaseModel
    {
        [DisplayName("Sale")]
        [ForeignKey("SalesModel")]
        public int SalesId { get; set; }
        public SalesModel? SalesModel { get; set; }


        public string? Nickname { get; set; }

        public float? Amount { get; set; }

        public float? TotalAmount { get; set; }
        public bool? IsSum { get; set; }

        [ForeignKey("SalesTaxModel")]
        public int? TaxId { get; set; }
        public SalesTaxModel? SalesTaxModel { get; set; }
    }

    [Table("TransactionApprovalStatus")]
    public class TransactionApprovalStatusModel : BaseModel
    {

        public int? ApprovalStatusId { get; set; }
        [ForeignKey("ApprovalStatusId")]
        public virtual ApprovalStatusModel? ApprovalStatus { get; set; }


        public int? SalesId { get; set; }
        [ForeignKey("SalesId")]
        public virtual SalesModel? Sales { get; set; }
        
        public int? PurchaseId { get; set; }
        [ForeignKey("PurchaseId")]
        public virtual PurchaseModel? Purchase { get; set; }

        public int? VoucherId { get; set; }
        [ForeignKey("VoucherId")]
        public virtual Acc_VoucherMainModel? Acc_VoucherMain { get; set; }

        public int? TransactionId { get; set; }
        [ForeignKey("TransactionId")]
        public virtual TransactionModel? Transaction { get; set; }
        
        public int? ProformaInvoiceId { get; set; }
        [ForeignKey("ProformaInvoiceId")]
        public virtual COM_ProformaInvoice? ProformaInvoice { get; set; }

        public int? DocTypeId { get; set; }
        [ForeignKey("DocTypeId")]
        public virtual DocTypeModel? DocType { get; set; }

        public bool IsDisApproved { get; set; }

        [ForeignKey("DisApprovedList")]
        public int? DisApproverId { get; set; }
        public virtual UserAccountModel? DisApprovedList { get; set; }

        [ForeignKey("CheckApprovedList")]
        public int? CheckApproverId { get; set; }
        public virtual UserAccountModel? CheckApprovedList { get; set; }

        [ForeignKey("VerifyApprovedList")]
        public int? VerifyApproverId { get; set; }
        public virtual UserAccountModel? VerifyApprovedList { get; set; }

        [ForeignKey("FinalApprovedList")]
        public int? FinalApproverId { get; set; }
        public virtual UserAccountModel? FinalApprovedList { get; set; }
    }

    [Table("RecurringDetails")]
    public class RecurringDetailsModel: BaseModel
    {
        public string? TemplateName { get; set; }
        public string? TemplateType { get; set; }
        public int CreateDays { get; set; }
        public string? Interval { get; set; }
        public int Every_ { get; set; }
        public string? Week_ { get; set; }
        public string? Month_ { get; set; }
        public string? Integer_ { get; set; }
        public string? Count_ { get; set; }
        public DateTime RecurringStartDate { get; set; }
        public DateTime RecurringEndDate { get; set; }
        public DateTime? PreviousDate { get; set; }
        public DateTime? NextDate { get; set; }
        public string? End_ { get; set; }
        public int occurences { get; set; }

        [DisplayName("Sale")]
        [ForeignKey("SalesModel")]
        public int? SalesId { get; set; }
        public SalesModel? SalesModel { get; set; }

        [DisplayName("Purchase")]
        [ForeignKey("PurchaseModel")]
        public int? PurchaseId { get; set; }
        public PurchaseModel? PurchaseModel { get; set; }

        [DisplayName("Transaction")]
        [ForeignKey("Transaction")]
        public int? TransactionId { get; set; }
        public TransactionModel? Transaction { get; set; }

        [NotMapped]
        public string? DocType { get; set; }

        [NotMapped]
        public string? CustomerOrSupplier { get; set; }

        [NotMapped]
        public decimal NetAmount { get; set; }
    }

    [Table("SalesBatchItems")]
    public class SalesBatchItemsModel : BaseModel
    {

        [DisplayName("Sales Items")]
        [ForeignKey("SalesItems")]
        public int SalesItemId { get; set; }
        public virtual SalesItemsModel? SalesItems { get; set; }


        [DisplayName("Product Name")]
        [ForeignKey("Products")]
        public int ProductId { get; set; }
        public virtual ProductModel? Products { get; set; }



        [DisplayName("Batch Serial No")]
        [ForeignKey("PurchaseBatchItems")]
        public int PurchaseBatchId { get; set; }
        public virtual PurchaseBatchItemsModel? PurchaseBatchItems { get; set; }



        [Required]
        [StringLength(20)]
        public string? BatchSerialNo { get; set; }


        public bool IsUsed { get; set; }
        [NotMapped]
        public bool IsTransaction { get; set; }


        //public double Price { get; set; }

        public int SalesBatchQuantity { get; set; }

        public double SalesBatchAmount { get; set; }

        public double SalesBatchPrice { get; set; }
        //public double CostPrice { get; set; }

    }

    [Table("salesTag")]
    public class SalesTagModel : BaseModel
    {
        public int SalesId { get; set; }
        [ForeignKey("SalesId")]
        public virtual SalesModel? Sales { get; set; }

        public int? TagsId { get; set; }
        [ForeignKey("TagsId")]
        public virtual TagsModel? Tags { get; set; }
       


    }

    [Table("Warehouse")]
    public class WarehouseModel : BaseModel
    {
        [Required]
        [StringLength(100, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 3)]
        [DataType(DataType.Text)]
        [Display(Name = "WH Name")]
        public string? WhName { get; set; }
        [Required]
        [StringLength(100, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 1)]
        [DataType(DataType.Text)]
        [Display(Name = "WH Short Name")]
        public string? WhShortName { get; set; }

        [StringLength(1, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 1)]
        [DataType(DataType.Text)]
        [Display(Name = "Ware House Type")]
        public string? WhType { get; set; }

        [ForeignKey("Warehouses")]
        public Nullable<int> ParentId { get; set; }
        [Display(Name = "Warehouse Name")]
        public virtual WarehouseModel? Warehouses { get; set; }

        [StringLength(200)]

        [Display(Name = "Remarks / Desc. / Vat / Tax")]
        [DataType(DataType.MultilineText)]
        public string? Remarks { get; set; }



        [StringLength(200)]

        [Display(Name = "Store Location / Address")]
        [DataType(DataType.MultilineText)]
        public string? StoreAddress { get; set; }

    }
    [Table("Tags")]
    public class TagsModel : BaseModel
    {
        [Required]
        [StringLength(100)]
        public string? TagName { get; set; }
        [Required]
        [StringLength(100)]
        [DataType(DataType.Text)]
        public string? TagShortName { get; set; }

        [StringLength(100)]
        [DataType(DataType.Text)]
        public string? TagsType { get; set; }

        [ForeignKey("Tags")]
        public Nullable<int> ParentId { get; set; }
        public virtual TagsModel? Tags { get; set; }

        [StringLength(200)]
        [DataType(DataType.MultilineText)]
        public string? Remarks { get; set; }

    }

    [Table("SalesPayment")]
    public class SalesPaymentModel : BaseModel
    {

        //[Key, Column(Order = 0)]
        public int SalesId { get; set; }

        //[Display(Name = "Payment Type")]
        //public int? PaymentTypeId { get; set; }
        [StringLength(100)]

        public string? PaymentCardNo { get; set; }


        public Boolean isPosted { get; set; }

        [Column(TypeName = "decimal(18,4)")]
        public decimal Amount { get; set; }



        public int? RowNo { get; set; }

        //public string? ComId { get; set; }



        [ForeignKey("SalesId")]

        public virtual SalesModel? SalesMain { get; set; }

        //[ForeignKey("PaymentTypeId")]

        //public virtual PaymentTypeModel? vPaymentType { get; set; }

        public int? AccountHeadId { get; set; }
        [ForeignKey("AccountHeadId")]
        public virtual AccountHeadModel? vChartofAccounts { get; set; }


        public int? TransactionId { get; set; }
        [ForeignKey("TransactionId")]
        public virtual TransactionModel? Transaction { get; set; }

        //public virtual ICollection<Product> vProducts { get; set; }



        public int? VoucherId { get; set; }
        [ForeignKey("VoucherId")]
        public virtual Acc_VoucherMainModel? Voucher { get; set; }

        [NotMapped]
        public string? DepositTo { get; set; }

    }

    [Table("PaymentType")]
    public class PaymentTypeModel : SelfModel
    {

        [Required]
        [StringLength(100, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 3)]
        [DataType(DataType.Text)]
        [Display(Name = "Type")]
        public string? TypeName { get; set; }
        [Required]
        [StringLength(100, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 1)]
        [DataType(DataType.Text)]
        [Display(Name = "Type Short Name")]
        public string? TypeShortName { get; set; }

        public int? ComId { get; set; }
        public virtual ICollection<SalesPaymentModel>? vTypeSalesSubs { get; set; }

        public bool IsDeliveryService { get; set; }
        public bool IsTrading { get; set; }




    }




    [Table("SalesTerms")]
    public class SalesTermsModel : BaseModel
    {

        public int SalesId { get; set; }

        [StringLength(50)]
        public string? TermsName { get; set; }

        [StringLength(200)]
        public string? TermsDescription { get; set; }

        public int? TermsSLNo { get; set; }

        [ForeignKey("SalesId")]
        public virtual SalesModel? SalesMain { get; set; }


    }


    [Table("PurchaseTerms")]
    public class PurchaseTermsModel : BaseModel
    {

        public int PurchaseId { get; set; }

        [StringLength(500)]
        public string? TermsName { get; set; }

        [StringLength(200)]
        public string? TermsDescription { get; set; }

        public int? TermsSLNo { get; set; }

        [ForeignKey("PurchaseId")]
        public virtual PurchaseModel? PurchaseMain { get; set; }


    }

    [Table("TermsMain")]

    public class TermsMainModel : BaseModel
    {
        
        [StringLength(50, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 4)]
        [DataType(DataType.Text)]
        [Display(Name = "Terms Name")]
        public string? TermsName { get; set; }


        [StringLength(20)]
        [DataType(DataType.Text)]
        [Display(Name = "Remarks")]
        public string? TermsRemarks { get; set; }

        public virtual ICollection<TermsSubModel>? TermsSubs { get; set; }


    }

    [Table("TermsSub")]

    public class TermsSubModel : BaseModel
    {

        [Required]
        [StringLength(50, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 4)]
        [DataType(DataType.Text)]
        [Display(Name = "Terms")]
        public string? Terms { get; set; }


        [DataType(DataType.Text)]
        [Display(Name = "Terms Description")]
        [StringLength(3000, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 4)]

        public string? TermsDescription { get; set; }


        [Required]
        [Display(Name = "Serial No")]
        public int TermsSerialNo { get; set; }

        [ForeignKey("TermsMain")]
        public int TermsId { get; set; }
        [Display(Name = "Terms")]
        public virtual TermsMainModel? TermsMain { get; set; }


    }


    public class MonthlySalesModel : BaseModel
    {
        public int Year { get; set; }
        public int MonthId { get; set; }
        public string? MonthName { get; set; }

        [Column(TypeName = "decimal(18,4)")]
        public decimal? TotalSales { get; set; }
    }


    public class DailySalesModel : BaseModel
    {
        public int DayId { get; set; }
        public int DayIdTemp { get; set; }
        public string? Caption { get; set; }
        public string? DateNameString { get; set; }
        public BigInteger TotalDocument { get; set; }
    }

    public class CategoryWiseSalesModel : BaseModel
    {
        public int Year { get; set; }
        public string? CategoryName { get; set; }

        [Column(TypeName = "decimal(18,4)")]
        public decimal? TotalQty { get; set; }

        [Column(TypeName = "decimal(18,4)")]
        public decimal? TotalSales { get; set; }
    }


    public class StockQtyValue : BaseModel
    {
        [Column(TypeName = "decimal(18,4)")]
        public decimal? TotalQty { get; set; }

        [Column(TypeName = "decimal(18,4)")]
        public decimal? TotalValue { get; set; }
    }








    [Table("GatePass")]
    public class GatePassModel : BaseModel
    {
        /// <summary>
        ///  Remarks , ttlSumQty , ttlCountQty , ttlUnitPrice , ttlIndVat , ttlIndDisAmt , ttlIndPrice , ttlSumAmt will be delete
        /// </summary>

        [Required]
        [DisplayName("GatePass Date")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd-MMM-yyyy}", ApplyFormatInEditMode = true)]
        [Column(TypeName = "datetime2")]
        public DateTime GatePassDate { get; set; }


        [NotMapped]
        public string? GatePassDateString { get; set; }

        [DisplayName("GatePass Doc No")]


        //[Column(TypeName = "varchar(50)")]
        [StringLength(40)]
        public string? GatePassCode { get; set; }
        [StringLength(200)]

        public string? Remarks { get; set; }

        public string? Status { get; set; }

        [Phone]
        [DisplayName("Phone No")]
        [StringLength(30)]

        public string? PhoneNo { get; set; }

        [StringLength(200)]

        [DisplayName("Style No")]
        public string? StyleNo { get; set; }



        [StringLength(200)]

        [DisplayName("Buyer Name")]
        public string? BuyerName { get; set; }


        [StringLength(50)]

        [DisplayName("Email")]
        public string? EmailId { get; set; }
        [StringLength(50)]

        [DisplayName("City")]
        public string? City { get; set; }


        [DisplayName("Transport")]
        public string? Transport { get; set; }

        [DisplayName("Manual No")]
        public string? ManualNo { get; set; }

        [DisplayName("Through")]
        public string? Through { get; set; }

        public string? ToName { get; set; }

        //[Display(Name = "Company")]
        //public int? CompanyId { get; set; }
        //[ForeignKey("Companys")]
        //public virtual CompanyModel Companys { get; set; }
        public bool isPosted { get; set; }
        public ICollection<GatePassItemsModel> Items { get; set; }

        public GatePassModel()
        {
            Items = new List<GatePassItemsModel>();

        }

    }


    [Table("GatePassItems")]
    public class GatePassItemsModel : BaseModel
    {
        [DisplayName("ProductId")]
        [ForeignKey("ProductModel")]
        public int? ProductId { get; set; }
        public virtual ProductModel? Product { get; set; }

        public int SLNo { get; set; }


        [StringLength(200)]

        public string? Name { get; set; }



        [StringLength(100)]

        public string? ColorName { get; set; }



        [StringLength(100)]

        public string? SizeName { get; set; }


        [Required]
        public double Price { get; set; }
        [Required]
        public double Quantity { get; set; }
        public double PackageQuantity { get; set; }

        public double Amount { get; set; }

        [DataType(DataType.MultilineText)]
        [StringLength(200)]

        public string? Description { get; set; }


        [DisplayName("GatePass")]
        [ForeignKey("GatePassModel")]
        public int GatePassId { get; set; }
        public GatePassModel? GatePassModel { get; set; }
        public bool IsTransaction { get; set; }


    }

    [Table("Agency")]
    public class AgencyModel : BaseModel
    {
        [DisplayName("Agency Name")]
        public string? AgencyName { get; set; }

        [DisplayName("Filling Frequency")]
        public string? Fillingfrequency { get; set; }

        [DisplayName("Start Date")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd-MMM-yyyy}", ApplyFormatInEditMode = true)]
        [Column(TypeName = "datetime2")]
        public DateTime StartDate { get; set; }

        [DisplayName("Reporting Method")]
        public string? ReportingMethod { get; set; }

        [DisplayName("Start Of Tax Period")]
        public string? StartOfTaxPeriod { get; set; }
    }

    [Table("SalesTax")]
    public class SalesTaxModel : BaseModel
    {

        [DisplayName("Nickname")]
        public string? Nickname { get; set; }

        [DisplayName("AgentId")]
        [ForeignKey("Agency")]
        public int? AgentId { get; set; }
        public virtual AgencyModel? Agency { get; set; }

        [DisplayName("SalesTasMastterId")]
        [ForeignKey("MasterSalesTax")]
        public int? SalesTaxMasterId { get; set; }
        public virtual MasterSalesTaxModel? MasterSalesTax { get; set; }

        [DisplayName("Rate")]
        public float? Rate { get; set; }

        [DisplayName("Custom Rate Total")]
        public float? CustomRateTotal { get; set; }

        [NotMapped]
        public string? AgentName { get; set; }

        [NotMapped]
        public string? Name { get; set; }

        public bool IsSingleTax { get; set; }

        [Display(Name = "Sales VAT Code :")]
        public int? AccIdSalesTaxes { get; set; }
        [ForeignKey("AccIdSalesTaxes")]
        public virtual AccountHeadModel? SalesVATAccount { get; set; }



        [Display(Name = "Purchase VAT Code :")]
        public int? AccIdPurchaseTaxes { get; set; }
        [ForeignKey("AccIdPurchaseTaxes")]
        public virtual AccountHeadModel? PurchaseVATAccount { get; set; }

        public int? AccIdExpenseTax { get; set; }
        [ForeignKey("AccIdExpenseTax")]
        public virtual AccountHeadModel? ExpenseVATAccount { get; set; }

        public int? TaxCriteriaId { get; set; }
        [ForeignKey("TaxCriteriaId")]
        public virtual TaxCriteria? TaxCriteria { get; set; }

    }

    public class MasterSalesTaxModel : BaseModel
    {
        public string? Name { get; set; }
        public string? DocForTax { get; set; } = string.Empty;

        public ICollection<SalesTaxModel>? SalesTax { get; set; }
    }

    public class FeedbackModel: BaseModel
    {
        public string? FeedbackForm { get; set; }
        public int Rating { get; set; }
        public string? Feedback { get; set; }
    }

    public class TaxCriteria : SelfModel
    {
        public string? Criteria { get; set; }
    }

    public class SalesTaxVMModel
    {
        public string? Id { get; set; }
        public string? Name { get; set; }
        public string? Nickname { get; set; }
        public string? Rate { get; set; }
        public string? AgentId { get; set; } // Include this property if it exists in your JSON
    }

    public class SalesModelVM
    {
        public int ComId { get; set; }
        public int LuserId { get; set; }
        public int Id { get; set; }
        public string? CustomerId { get; set; }
        public int? CurrencyId { get; set; }
        public int WarehouseIdMain { get; set; }
        public string? EstimateStatus { get; set; }
        public string? StatusBy { get; set; }
        public DateTime? StatusDate { get; set; }
        public string? EmailId { get; set; }
        public string? PrimaryAddress { get; set; }
        public string? SalesDate { get; set; }
        public string? DueDate { get; set; }
        public string? ShippingVia { get; set; } = string.Empty;
        public string? ShippingDate { get; set; }
        public string? TrackingNo { get; set; } = string.Empty;
        public string? SaleCode { get; set; }
        public string? SecoundaryAddress { get; set; } = string.Empty;
        public string? ShippingTo { get; set; } = string.Empty;
        public string? MessageInvoice { get; set; } = string.Empty;
        public string? MessageStatement { get; set; } = string.Empty;
        public double Total { get; set; }
        public double SubTotal { get; set; }
        public double TotalVat { get; set; }
        public double CurrencyRate { get; set; }
        public string? Notes { get; set; } = string.Empty;
        public decimal Shipping { get; set; }
        public decimal ShippingTax { get; set; }
        public string? AmountsAre { get; set; }
        public List<SalesItemVM>? SalesItemVM { get; set; }
        public List<SalesProductTaxVM>? SalesProductTaxVM { get; set; }
        public List<TransactionModelVM>? TransactionModelVM{ get; set;}
        public List<string>? SalesTags { get; set;}
        public bool IsRecurring { get; set; }
        public bool IsRecognition { get; set; }
        public int? salesRecievedtTermsId { get; set; }
        public int? FiscalMonthId { get; set; }
    }

    public class SalesTagModelVM
    {
        public string? Id { get; set; }
    }
    public class TransactionModelVM
    {
        public int Id { get; set; }
        public int AccountHeadId { get; set; }
        public string? PaymentCardNo { get; set; }
        public decimal Amount { get; set; }
    }
    public class SalesItemVM
    {
        public int Id { get; set; }
        public string? ServiceDate { get; set; }
        public string? ProductId { get; set; }
        public int? WarehouseId { get; set; }
        public int? PurchaseItemsId { get; set; }
        public string? WHName { get; set; }
        public string? Description { get; set; }
        public string? Quantity { get; set; }
        public string? Price { get; set; }
        public string? SecondaryPrice { get; set; }
        public string? DefaultPrice { get; set; }
        public string? CostPrice { get; set; }
        public string? Amount { get; set; }
        public string? MasterTaxId { get; set; }
        public string? IsTax { get; set; }
        public string? IndDiscount { get; set; }
        public int? PrimaryUnitId { get; set; }
        public int? SecondaryUnitId { get; set; }
        public double? ConversionRate { get; set; }
        public int InputQuantity { get; set; }
        public string? Unit { get; set; }
    }

    public class SalesProductTaxVM
    {
        public int Id { get; set; }
        public string? Nickname { get; set; }
        public string? Amount { get; set; }
        public bool IsSum { get; set; }
        public string? TotalAmount { get; set; }
        public int TaxId { get; set; }
    }

    public class RecurringDetailsModelVM 
    {
        public int Id { get; set; }
        public string? TemplateName { get; set; }
        public string? TemplateType { get; set; }
        public int CreateDays { get; set; }
        public string? Interval { get; set; }
        public int Every_ { get; set; }
        public string? Week_ { get; set; }
        public string? Month_ { get; set; }
        public string? Integer_ { get; set; }
        public string? Count_ { get; set; }
        public string? RecurringStartDate { get; set; }
        public string? RecurringEndDate { get; set; } 
        public string? PreviousDate { get; set; } 
        public string? NextDate { get; set; } 
        public string? End_ { get; set; }
        public int occurences { get; set; }
        public int? SalesId { get; set; }
        public int? PurchaseId { get; set; }
        public int? TransactionId { get; set; }
    }

    public class StockCountModelVM
    {
        public int Id { get; set; }
        public string? CustomerId { get; set; }
        public List<StockCountItemModelVM>? StockCountItem { get; set; }
    }

    public class StockCountItemModelVM
    {
        public int Id { get; set; }
        public string? ServiceDate { get; set; }
        public string? ProductId { get; set; }
        public int WarehouseId { get; set; }
        public string? WHName { get; set; }
        public string? Description { get; set; }
        public string? Quantity { get; set; }
       
    }

    [Table("TokenSales")]
    public class TokenSalesModel : BaseModel
    {
        [Display(Name = "Store Location")]
        public int WarehouseIdMain { get; set; }
        [ForeignKey("WarehouseIdMain")]
        public virtual WarehouseModel? Warehouses { get; set; }


        [DisplayName("CustomerId")]
        [ForeignKey("CustomerModel")]
        public int CustomerId { get; set; }
        public CustomerModel? CustomerModel { get; set; }


        [DisplayName("Token No")]
        [StringLength(40)]
        public string? TokenCode { get; set; }



        [Required]
        [DisplayName("Token Date")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd-MMM-yyyy}", ApplyFormatInEditMode = true)]
        [Column(TypeName = "datetime2")]
        public DateTime TokenDate { get; set; }



        [StringLength(200)]
        public string? Notes { get; set; } = string.Empty;



        [Phone]
        [DisplayName("Phone No")]
        [StringLength(30)]
        public string? PhoneNo { get; set; }

        [StringLength(100)]

        [Display(Name = "Customer Name")]
        public string? CustomerName { get; set; }
        [StringLength(200)]

        //[Required]
        [DataType(DataType.MultilineText)]
        [Display(Name = "Primary Address")]
        public string? PrimaryAddress { get; set; }



        [DisplayName("BlackProductId")]
        [ForeignKey("BlackProduct")]
        public int? BlackProductId { get; set; }
        public virtual ProductModel? BlackProduct { get; set; }


        [DisplayName("WhiteProductId")]
        [ForeignKey("WhiteProduct")]
        public int? WhiteProductId { get; set; }
        public virtual ProductModel? WhiteProduct { get; set; }


        [DisplayName("OtherOneProductId")]
        [ForeignKey("OtherOneProduct")]
        public int? OtherOneProductId { get; set; }
        public virtual ProductModel? OtherOneProduct { get; set; }


        [DisplayName("OtherTwoProduct")]
        [ForeignKey("OtherTwoProduct")]
        public int? OtherTwoProductId { get; set; }
        public virtual ProductModel? OtherTwoProduct { get; set; }





        [Display(Name = "Black Gross")]
        [Column(TypeName = "decimal(18,4)")]
        public decimal BlackGross { get; set; }


        [Display(Name = "White Gross")]
        [Column(TypeName = "decimal(18,4)")]
        public decimal WhiteGross { get; set; }



        [Display(Name = "Other1 Gross")]
        [Column(TypeName = "decimal(18,4)")]
        public decimal OtherOneGross { get; set; }


        [Display(Name = "Other2 Gross")]
        [Column(TypeName = "decimal(18,4)")]
        public decimal OtherTwoGross { get; set; }






        [Display(Name = "Black Tare")]
        [Column(TypeName = "decimal(18,4)")]
        public decimal BlackTare { get; set; }


        [Display(Name = "White Tare")]
        [Column(TypeName = "decimal(18,4)")]
        public decimal WhiteTare { get; set; }



        [Display(Name = "Other1 Tare")]
        [Column(TypeName = "decimal(18,4)")]
        public decimal OtherOneTare { get; set; }


        [Display(Name = "Other2 Tare")]
        [Column(TypeName = "decimal(18,4)")]
        public decimal OtherTwoTare { get; set; }


        [Display(Name = "Black Net")]
        [Column(TypeName = "decimal(18,4)")]
        public decimal BlackNet { get; set; }


        [Display(Name = "White Net")]
        [Column(TypeName = "decimal(18,4)")]
        public decimal WhiteNet { get; set; }



        [Display(Name = "Other1 Net")]
        [Column(TypeName = "decimal(18,4)")]
        public decimal OtherOneNet { get; set; }


        [Display(Name = "Other2 Net")]
        [Column(TypeName = "decimal(18,4)")]
        public decimal OtherTwoNet { get; set; }


        public bool isPosted { get; set; }


        [Display(Name = "Doc Type")]
        [ForeignKey("DocTypeList")]
        public int? DocTypeId { get; set; }
        [Display(Name = "Doc Type")]
        public virtual DocTypeModel? DocTypeList { get; set; }

        [NotMapped]
        public string? SaleCode_Barcode { get; set; }


        //public virtual ICollection<SalesModel> TokenBillNo { get; set; }
        public virtual ICollection<SalesItemsModel>? TokenBillList { get; set; }

    }
    
    
}
