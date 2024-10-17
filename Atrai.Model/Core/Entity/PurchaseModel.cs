using Atrai.Model.Core.Entity.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Atrai.Model.Core.Entity
{
    [Table("Purchase")]
    public class PurchaseModel : BaseModel
    {

        /// <summary>
        ///  Remarks , ttlSumQty , ttlCountQty , ttlUnitPrice , ttlIndVat , ttlIndDisAmt , ttlIndPrice , ttlSumAmt will be delete
        /// </summary>
        /// 

        public bool IsRecognition { get; set; }
        [Required]
        [DisplayName("Purchase Date")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd-MMM-yyyy}", ApplyFormatInEditMode = true)]
        [Column(TypeName = "datetime2")]
        public DateTime PurchaseDate { get; set; }

        [DisplayName("Due Date")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd-MMM-yyyy}", ApplyFormatInEditMode = true)]
        [Column(TypeName = "datetime2")]
        public DateTime? DueDate { get; set; }

        [DisplayName("Purchase Doc No")]

        [StringLength(40)]
        public string? PurchaseCode { get; set; }

        public bool IsPaymentDone { get; set; }

        [DisplayName("Permit No")]

        [StringLength(40)]
        public string? PermitNo { get; set; }

        [StringLength(200)]
        public string? Notes { get; set; }
        [Required]
        public Double Total { get; set; }
        [StringLength(20)]

        public string? Status { get; set; }
        public double? Discount { get; set; }
        [Column(TypeName = "decimal(18,4)")]
        public decimal GrandTotal { get; set; }

        [DisplayName("Payment Method")]
        [StringLength(20)]

        public string? PaymentMethod { get; set; }

        [StringLength(200)]

        [DataType(DataType.MultilineText)]
        public string? Remarks { get; set; }

        public int ReturnStatus { get; set; } = 0;

        public int PaymentStatus { get; set; } = 0;


        [StringLength(20)]
        public string? AmountsAre { get; set; }

        [DataType(DataType.PhoneNumber)]
        [StringLength(20)]

        [DisplayName("Phone No")]
        public string? PhoneNo { get; set; }

        [StringLength(12)]

        [DisplayName("Postal Code")]
        public string? PostalCode { get; set; }

        [StringLength(100)]
        [DataType(DataType.EmailAddress)]


        [DisplayName("Email")]
        public string? EmailId { get; set; }

        [StringLength(150)]
        [DisplayName("ShippingAddress")]
        public string? ShippingAddress { get; set; }

        [StringLength(150)]
        [DisplayName("ShipVia")]
        public string? ShipVia { get; set; }


        [StringLength(50)]

        [DisplayName("City")]
        public string? City { get; set; }


        #region delete
        //[StringLength(50)]

        //[Display(Name = "Card No")]
        //public string? CardNo { get; set; }


        //[Display(Name = "No. Of Items[Sum]")]
        //[Column(TypeName = "decimal(18,2)")]
        //public decimal ttlSumQty { get; set; }

        //[Display(Name = "No. Of Items [Count]")]
        //[Column(TypeName = "decimal(18,2)")]
        //public decimal ttlCountQty { get; set; }

        //[Display(Name = "Unit Price")]

        //[Column(TypeName = "decimal(18,2)")]
        //public decimal ttlUnitPrice { get; set; }
        //[Display(Name = "Individual Vat")]

        //[Column(TypeName = "decimal(18,2)")]
        //public decimal ttlIndVat { get; set; }

        //[Display(Name = "Individual Discount")]

        //[Column(TypeName = "decimal(18,2)")]
        //public decimal ttlIndDisAmt { get; set; }

        //[Display(Name = "Individual Price")]

        //[Column(TypeName = "decimal(18,2)")]
        //public decimal ttlIndPrice { get; set; }




        //[Display(Name = "Sum of Amount")]
        //[Column(TypeName = "decimal(18,2)")]
        //public decimal ttlSumAmt { get; set; }

        #endregion delete


        [Display(Name = "Image [Folder]")]

        public string? FilePath { get; set; }

        public string? PurchaseFilePath { get; set; }

        public Boolean ChkPer { get; set; }

        [Display(Name = "% Discount")]

        [Column(TypeName = "decimal(18,4)")]
        public decimal DisPer { get; set; }
        [Display(Name = "Dis. Amount")]

        [Column(TypeName = "decimal(18,4)")]
        public decimal DisAmt { get; set; }

        public Boolean isDisPer { get; set; }
        public Boolean IsSystem { get; set; }


        [Display(Name = "Service Charge")]
        [DisplayFormat(DataFormatString = "{0:#,#.00}")]

        [Column(TypeName = "decimal(18,4)")]
        public decimal ServiceCharge { get; set; }

        [Display(Name = "Shipping")]

        [Column(TypeName = "decimal(18,4)")]
        public decimal Shipping { get; set; }

        [Display(Name = "Total Vat ")]

        [Column(TypeName = "decimal(18,4)")]
        public decimal TotalVat { get; set; }


        [Display(Name = "Net Amount")]

        [Column(TypeName = "decimal(18,4)")]
        public decimal NetAmount { get; set; }
        [Display(Name = "Paid Amount")]


        [Column(TypeName = "decimal(18,4)")]
        public decimal PaidAmt { get; set; }
        [Display(Name = "Due Amount")]


        [Column(TypeName = "decimal(18,4)")]
        public decimal DueAmt { get; set; }

        [StringLength(20)]

        [DataType(DataType.Text)]
        [Display(Name = "Cheque No")]
        public string? ChequeNo { get; set; }


        [Display(Name = "Store Location")]
        public int WarehouseIdMain { get; set; }
        [ForeignKey("WarehouseIdMain")]
        public virtual WarehouseModel? Warehouses { get; set; }


        [Display(Name = "Store Location")]

        [ForeignKey("MasterPO")]
        public int? MasterPOId { get; set; }
        public virtual MasterPOModel? MasterPO { get; set; }

        public int? FiscalMonthId { get; set; }
        [ForeignKey("FiscalMonthId")]
        public virtual Acc_FiscalMonthModel? Acc_FiscalMonth { get; set; }

        [DisplayName("SupplierId")]
        [ForeignKey("SupplierModel")]
        public int? SupplierId { get; set; }
        public SupplierModel? SupplierModel { get; set; }

        //[DisplayName("TermId")]
        //[ForeignKey("BillTermModel")]
        //public int TermId { get; set; }
        //public TermModel BillTermModel { get; set; }

        [StringLength(100)]

        [Display(Name = "Supplier Name")]
        public string? SupplierName { get; set; }

        public double? TDS { get; set; }

        //[Required]
        [StringLength(300)]

        [DataType(DataType.MultilineText)]
        [Display(Name = "Primary Address")]
        public string? PrimaryAddress { get; set; }

        [StringLength(300)]

        //[Required]
        [DataType(DataType.MultilineText)]
        [Display(Name = "Secoundary Address")]
        public string? SecoundaryAddress { get; set; }


        public bool isPOSPurchase { get; set; }
        public bool isBatchPurchase { get; set; }

        public bool isPosted { get; set; }
        public int? DocStatusId { get; set; }

        [ForeignKey("DocStatusId")]
        public virtual DocStatusModel? DocStatus { get; set; }

        public int? TermsMainId { get; set; }

        [ForeignKey("TermsMainId")]
        public virtual TermsMainModel? TermsMain { get; set; }


        public bool IsVatSales { get; set; }


        [DisplayName("Currency")]
        [ForeignKey("Currency")]
        public int? CurrencyId { get; set; }
        public CountryModel? Currency { get; set; }
        [Column(TypeName = "decimal(18,4)")]
        public double CurrencyRate { get; set; }



        [DisplayName("CustomerId")]
        [ForeignKey("CustomerModel")]
        public int? CustomerId { get; set; }
        public CustomerModel? CustomerModel { get; set; }

        //[Display(Name = "Received Head")]
        //[ForeignKey("vCreditAccount")]
        //public int? CreditAccountId { get; set; }
        //[Display(Name = "Payment / Received Head")]
        //public virtual AccountHeadModel? CreditAccount { get; set; }


        [Display(Name = "Doc Type")]
        [ForeignKey("DocTypeList")]
        public int? DocTypeId { get; set; }
        [Display(Name = "Doc Type")]
        public virtual DocTypeModel? DocTypeList { get; set; }


        public string? Cc { get; set; }
        public string? Bcc { get; set; }


        [Display(Name = "Payment Terms")]
        [ForeignKey("PaymentTermsInfo")]
        public int? PaymentTermsId { get; set; }
        [Display(Name = "Payment Terms")]
        public virtual PaymentTermsModel? PaymentTermsInfo { get; set; }
        public bool IsRecurring { get; set; }
        public bool IsPending { get; set; }
        public int? StatusId { get; set; }
        [ForeignKey("StatusId")]
        public virtual StatusModel? StatusInfo { get; set; }
        public ICollection<PurchaseItemsModel>? Items { get; set; }
        public ICollection<RecurringDetailsModel>? RecurringDetails { get; set; }     
        public ICollection<PurchaseItemsCategoryModel>? ItemsCategory { get; set; }
        public virtual ICollection<PurchasePaymentModel>? PurchasePayments { get; set; }
        public virtual ICollection<PurchaseTagModel>? PurchaseTags { get; set; }
        public ICollection<PurchaseProductTaxModel>? PurchaseProductTax { get; set; }

        [NotMapped]
        public string[]? VoucherTags { get; set; }

        public virtual ICollection<PurchaseTermsModel>? PurchaseTerms { get; set; }
        //public virtual ICollection<TermModel> BillTerms { get; set; }
        public virtual ICollection<TransactionModel>? AccountTransaction { get; set; }

        public ICollection<PurchaseReturnModel>? PurchaseReturn { get; set; }

        public int DocStatusCount { get; set; } = 0;


        [ForeignKey("CheckByUserAccountList")]
        public int? LuserIdCheck { get; set; }
        [Display(Name = "Check By User")]
        public virtual UserAccountModel? CheckByUserAccountList { get; set; }
        public DateTime? CheckDate { get; set; }



        [ForeignKey("VerifyByUserAccountList")]
        public int? LuserIdVerify { get; set; }
        [Display(Name = "Verify By User")]
        public virtual UserAccountModel? VerifyByUserAccountList { get; set; }
        public DateTime? VerifyDate { get; set; }

        public int? ApprovalStatusId { get; set; }
        [ForeignKey("ApprovalStatusId")]
        public virtual ApprovalStatusModel? ApprovalStatus { get; set; }

        [ForeignKey("ApproveByUserAccountList")]
        public int? LuserIdApprove { get; set; }
        [Display(Name = "Approve By User")]
        public virtual UserAccountModel? ApproveByUserAccountList { get; set; }
        public DateTime? ApproveDate { get; set; }

        [NotMapped]
        public decimal BeforeTax { get; set; }


        //newly added


        public PurchaseModel()
        {
            Items = new List<PurchaseItemsModel>();
            PurchasePayments = new List<PurchasePaymentModel>();
            CostCalculations = new List<CostCalculatedModel>();
            AccountTransaction = new List<TransactionModel>();

        }

        public virtual IEnumerable<CostCalculatedModel>? CostCalculations { get; set; }


    }


    [Table("PurchaseItems")]
    public class PurchaseItemsModel : BaseModel
    {
        [DisplayName("ProductId")]
        [ForeignKey("ProductModel")]
        public int ProductId { get; set; }
        public virtual ProductModel? Product { get; set; }
        [StringLength(200)]

        public string? Name { get; set; }

        [NotMapped]
        public string? ProductName { get; set; }

        [Required]
        [Column(TypeName = "decimal(18,4)")]

        public double Price { get; set; }
        [Column(TypeName = "decimal(18,4)")]

        [Required]
        public double Quantity { get; set; }

        [MaxLength]
        public string? Description { get; set; }

        [MaxLength(30)]
        public string? SKU { get; set; }

        public double QTY { get; set; }
        public double Rate { get; set; }
        public double Amount { get; set; }
        public bool IsInclusive { get; set; }

        public int SLNo { get; set; }


        [DisplayName("Customer")]
        [ForeignKey("ItemWiseCustomer")]
        public int? CustomerId { get; set; }
        public CustomerModel? ItemWiseCustomer { get; set; }

        [ForeignKey("MasterSalesTax")]
        public int? MasterTaxId { get; set; }
        public MasterSalesTaxModel? MasterSalesTax { get; set; }

        [StringLength(100)]
        public string? MasterTaxName { get; set; }

        [StringLength(100)]
        public string? WHName { get; set; }

        [DataType(DataType.MultilineText)]
        [StringLength(100)]
        public string? BatchStartFrom { get; set; }
        [NotMapped]

        public string? BatchToFrom { get; set; }



        [DisplayName("Purchase")]
        [ForeignKey("PurchaseModel")]
        public int PurchaseId { get; set; }
        public PurchaseModel? PurchaseModel { get; set; }

        [Display(Name = "Store Location")]
        public int? WarehouseId { get; set; }

        [ForeignKey("WarehouseId")]

        public virtual WarehouseModel? vWarehouse { get; set; }


        [Display(Name = "Style")]
        [ForeignKey("Style")]
        public int? StyleId { get; set; }
        public virtual StyleModel? Style { get; set; }

        [Display(Name = "Color")]
        [ForeignKey("Colors")]
        public int? ColorId { get; set; }
        public virtual ColorsModel? Colors { get; set; }


        [Display(Name = "Size")]
        [ForeignKey("Sizes")]
        public int? SizeId { get; set; }
        public virtual SizesModel? Sizes { get; set; }

        [Display(Name = "BuyerPOId")]
        [ForeignKey("BuyerPO_Master")]
        public int? BuyerPOId { get; set; }
        public virtual BuyerPO_MasterModel? BuyerPO_Master { get; set; }

        public double? TDS { get; set; }
        public double? VAT { get; set; }
        public double? VDS { get; set; }

        [Display(Name = "Linked Items")]
        public int? PurchaseItemsId { get; set; }
        [ForeignKey("PurchaseItemsId")]
        public ICollection<PurchaseItemsModel>? PurchaseItems { get; set; }

        public virtual PurchaseItemsModel? PurchaseInfo { get; set; }
        //public virtual PurchaseItemsModel BDPO { get; set; }

        public ICollection<PurchaseBatchItemsModel>? PurchaseBatchItems { get; set; }

        [NotMapped]
        public bool isTransaction { get; set; }

        [Column(TypeName = "decimal(18,4)")]

        public double IndDiscount { get; set; }
        [Column(TypeName = "decimal(18,4)")]

        public double IndShippingProportion { get; set; }


        public Boolean isDisPerRow { get; set; }



        [Column(TypeName = "decimal(18,4)")]

        //[Required]
        public double SalesUnitPrice { get; set; }
        //[Required]
        [Column(TypeName = "decimal(18,4)")]

        public double ProfitPer { get; set; }


        public int? ItemsReturnStatus { get; set; }

        public double IndDiscountProportion { get; set; }

        public double NewQTY { get; set; }

        public double QTYOnHand { get; set; }

        public int? PrimaryUnitId { get; set; }
        [ForeignKey("PrimaryUnitId")]
        public virtual UnitModel? PrimaryUnitModel { get; set; }

        public int? SecondaryUnitId { get; set; }
        [ForeignKey("SecondaryUnitId")]
        public virtual UnitModel? SecondaryUnitModel { get; set; }

        public double? ConversionRate { get; set; } = 0;

        public double? InputQuantity { get; set; } = 0;

        public string? Unit { get; set; }

        public double DefaultPrice { get; set; } = 0;
        public double? SecondaryPrice { get; set; }

        public virtual ICollection<SalesItemsModel>? SalesItemsList { get; set; }

    }


    [Table("PurchaseItemsCategory")]

    public class PurchaseItemsCategoryModel : BaseModel
    {
        public int AccId { get; set; }
        [ForeignKey("AccId")]
        public virtual AccountHeadModel? Acc_ChartOfAccount { get; set; }




        [Display(Name = "Linked Items")]
        public int? PurchaseItemsCategoryId { get; set; }
        [ForeignKey("PurchaseItemsCategoryId")]
        public ICollection<PurchaseItemsCategoryModel>? PurchaseItemsCategory { get; set; }
        public virtual PurchaseItemsCategoryModel? PurchaseCategoryInfo { get; set; }

        //public int SRowNo { get; set; }
        //public int ccId { get; set; }

        //public int CurrencyId { get; set; }
        //[ForeignKey("CurrencyId")]
        //public virtual CountryModel? Country { get; set; }
        //public int CurrencyForeignId { get; set; }
        //[ForeignKey("CurrencyForeignId")]
        //public virtual CountryModel? CountryForeign { get; set; }

        //public double TKDebit { get; set; }
        //public double TKCredit { get; set; }
        //public double TKDebitLocal { get; set; }
        //public double TKCreditLocal { get; set; }
        //public double CurrencyRate { get; set; }

        [MaxLength]
        public string? Description { get; set; }
        public double Amount { get; set; } = 0;
        public bool IsBillable { get; set; }
        public bool IsTax { get; set; }

        public int SLNo { get; set; }

        [ForeignKey("MasterSalesTax")]
        public int? MasterTaxId { get; set; }
        public MasterSalesTaxModel? MasterSalesTax { get; set; }

        [StringLength(100)]
        public string? MasterTaxName { get; set; }

        [NotMapped]
        public bool isTransaction { get; set; }

        //public string? Note1 { get; set; }
        //public string? Note2 { get; set; }
        //public string? Note3 { get; set; }
        //public string? Note4 { get; set; }
        //public string? Note5 { get; set; }
        //public int? RowNo { get; set; }
        //public int? RefId { get; set; }
        //public int? SLNo { get; set; }
        //public int? EmpId { get; set; }
        //[ForeignKey("EmpId")]
        //public virtual EmployeeModel? EmployeeData { get; set; }
        public double? TDS { get; set; }
        public double? VAT { get; set; }
        public double? VDS { get; set; }


        [DisplayName("Purchase")]
        [ForeignKey("PurchaseModel")]
        public int? PurchaseId { get; set; }
        public PurchaseModel? PurchaseModel { get; set; }


        public int? CustomerId { get; set; }
        [ForeignKey("CustomerId")]
        public virtual CustomerModel? Customers { get; set; }

        //public int? TermsId { get; set; }
        //[ForeignKey("TermsId")]
        //public virtual PurchaseTermsModel TermsInfo { get; set; }

        //public int? SupplierId { get; set; }
        //[ForeignKey("SupplierId")]
        //public virtual SupplierModel? Suppliers { get; set; }


        //public int VoucherId { get; set; }
        //[ForeignKey("VoucherId")]
        //public virtual Acc_VoucherMainModel? Acc_VoucherMain { get; set; }

        //public int? VoucherTranGroupIdRow { get; set; }
        //[Display(Name = "Transaction Group")]
        //[ForeignKey("VoucherTranGroupIdRow")]
        //public virtual VoucherTranGroupModel VoucherTranGroups { get; set; }

        //public virtual ICollection<Acc_VoucherSubChecknoModel> VoucherSubChecnoes { get; set; }

        //public virtual ICollection<Acc_VoucherSubSectionModel> VoucherSubSections { get; set; }


        ////public string? SerialItem { get; set; }



        //public int? SalesId { get; set; }
        //[ForeignKey("SalesId")]
        //public virtual SalesModel? Sale { get; set; }


        //public int? PurchaseId { get; set; }
        //[ForeignKey("PurchaseId")]
        //public virtual PurchaseModel? Purchase { get; set; }



        //public int? SalesReturnId { get; set; }
        //[ForeignKey("SalesReturnId")]
        //public virtual SalesReturnModel? SalesReturn { get; set; }



        //public int? PurchaseReturnId { get; set; }
        //[ForeignKey("PurchaseReturnId")]
        //public virtual PurchaseReturnModel? PurchaseReturn { get; set; }




        //public int? DamageId { get; set; }
        //[ForeignKey("DamageId")]
        //public virtual DamageModel? Damage { get; set; }



        //public int? IssueId { get; set; }
        //[ForeignKey("IssueId")]
        //public virtual IssueModel? Issue { get; set; }



        //public int? TransferInId { get; set; }
        //[ForeignKey("TransferInId")]
        //public virtual InternalTransferModel? TransferIn { get; set; }



        //public int? TransferOutId { get; set; }
        //[ForeignKey("TransferOutId")]
        //public virtual InternalTransferModel? TransferOut { get; set; }


        //public int? MemberId { get; set; }
        //[ForeignKey("MemberId")]
        //public virtual MemberModel? Member { get; set; }
    }



    [Table("PurchasePayment")]
    public class PurchasePaymentModel : BaseModel
    {

        //[Key, Column(Order = 0)]
        public int PurchaseId { get; set; }

        //[Display(Name = "Payment Type")]
        //public int PaymentTypeId { get; set; }
        [StringLength(100)]


        public string? PaymentCardNo { get; set; }


        public Boolean isPosted { get; set; }

        [Column(TypeName = "decimal(18,4)")]
        public Decimal Amount { get; set; }



        public int? RowNo { get; set; }

        //public string? ComId { get; set; }



        [ForeignKey("PurchaseId")]

        public virtual PurchaseModel? PurchaseMain { get; set; }

        //[ForeignKey("PaymentTypeId")]

        //public virtual PaymentTypeModel? vPaymentType { get; set; }
        public int? AccountHeadId { get; set; }

        [ForeignKey("AccountHeadId")]
        public virtual AccountHeadModel? vChartofAccounts { get; set; }



        public int? TransactionId { get; set; }
        [ForeignKey("TransactionId")]
        public virtual TransactionModel? Transaction { get; set; }


        public int? VoucherId { get; set; }
        [ForeignKey("VoucherId")]
        public virtual Acc_VoucherMainModel? Voucher { get; set; }
    }

    [Table("purchaseTag")]
    public class PurchaseTagModel : BaseModel
    {
        public int PurchaseId { get; set; }
        [ForeignKey("PurchaseId")]
        public virtual PurchaseModel? PurchaseMaster { get; set; }

        public int? TagsId { get; set; }
        [ForeignKey("TagsId")]
        public virtual TagsModel? Tags { get; set; }
        //[Key]
        //public int VoucherSubCheckId { get; set; }
        public string? tag { get; set; }


    }

    [Table("PurchaseBatchItems")]
    public class PurchaseBatchItemsModel : BaseModel
    {

        [DisplayName("Purchase Items")]
        [ForeignKey("PurchaseItems")]
        public int PurchaseItemId { get; set; }
        public virtual PurchaseItemsModel? PurchaseItems { get; set; }


        [DisplayName("Product Name")]
        [ForeignKey("Products")]
        public int ProductId { get; set; }
        public virtual ProductModel? Products { get; set; }

        [Required]
        [StringLength(20)]
        public string? BatchSerialNo { get; set; }

        [StringLength(20)]
        public string? ExchangeSerialNo { get; set; }

        [DisplayName("Supplier Name")]
        [ForeignKey("SupplierList")]
        public int? SupplierId { get; set; }
        public virtual SupplierModel? SupplierList { get; set; }



        [Column(TypeName = "datetime2")]
        public DateTime ExchangeDate { get; set; }


        public int SLNo { get; set; }


        public double PurchaseBatchPrice { get; set; }

        public int PurchaseBatchQuantity { get; set; }

        public double PurchaseBatchAmount { get; set; }


        [StringLength(50)]

        public string? BatchRemarks { get; set; }

        public bool IsUsed { get; set; }
        public bool IsReturn { get; set; }


        [NotMapped]
        public bool IsTransaction { get; set; }


        [NotMapped]
        public string? ProductName { get; set; }


        [NotMapped]
        public string? PurchaseInvoiceNo { get; set; }

        [NotMapped]
        public string? PurchaseDate { get; set; }


        public ICollection<SalesBatchItemsModel>? SalesBatchItems { get; set; }


        public ICollection<WarrantyItemsModel>? WarrentyList { get; set; }
    }

    [Table("PurchaseProductTax")]
    public class PurchaseProductTaxModel : BaseModel
    {
        [ForeignKey("PurchaseModel")]
        public int? PurchaseId { get; set; }
        public PurchaseModel? PurchaseModel { get; set; }
        public string? Nickname { get; set; }
        public float? Amount { get; set; }
        public bool? IsSum { get; set; }

        [ForeignKey("SalesTaxModel")]
        public int? TaxId { get; set; }
        public SalesTaxModel? SalesTaxModel { get; set; }
    }





    [Table("WarrentyItems")]
    public class WarrantyItemsModel : BaseModel
    {

        [DisplayName("Complain No")]

        [StringLength(40)]
        public string? ComplainNo { get; set; }


        //[DisplayName("Warrenty Items")]
        //[ForeignKey("WarrentyItems")]
        //public int WarrentyItemId { get; set; }
        //public virtual WarrentyItemsModel WarrentyItems { get; set; }


        //[DisplayName("Product Name")]
        //[ForeignKey("Products")]
        //public int? ProductId { get; set; }
        //[DisplayName("Product Name")]

        //public virtual ProductModel? Products { get; set; }



        [DisplayName("Product Name")]
        [ForeignKey("Products")]
        public int? ProductId { get; set; }
        public virtual ProductModel? Products { get; set; }




        [DisplayName("Batch Serial No")]
        [ForeignKey("PurchaseBatchItems")]
        public int? PurchaseBatchId { get; set; }
        [DisplayName("Serial No")]

        public virtual PurchaseBatchItemsModel? PurchaseBatchItems { get; set; }

        [StringLength(50)]
        [DisplayName("Replaced Serial No")]

        public string? ReplacedSerialNo { get; set; }


        [NotMapped]
        [DisplayName("Serial No")]

        public string? SerialNo { get; set; }
        [NotMapped]
        [DisplayName("Product Name")]
        public string? ProductName { get; set; }


        [DisplayName("Invoice No")]

        [NotMapped]
        public string? InvoiceNo { get; set; }

        [StringLength(50)]
        [DisplayName("Complainer")]
        public string? Complainer { get; set; }

        [StringLength(50)]
        [DisplayName("Contact No")]
        public string? ContactNo { get; set; }

        [StringLength(150)]
        [DisplayName("Address")]
        public string? PrimaryAddress { get; set; }



        [StringLength(200)]
        [DataType(DataType.MultilineText)]
        public string? Remarks { get; set; }


        [StringLength(200)]
        [DataType(DataType.MultilineText)]
        public string? Problem { get; set; }


        [DisplayName("Invoice No")]
        [ForeignKey("Sales")]
        public int? SalesId { get; set; }


        [DisplayName("Supplier")]
        [ForeignKey("SupplierList")]
        public int? SupplierId { get; set; }
        [DisplayName("Supplier")]
        public virtual SupplierModel? SupplierList { get; set; }




        [DisplayName("Invoice No")]
        public virtual SalesModel? Sales { get; set; }



        [DisplayName("Replaced Date")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd-MMM-yyyy}", ApplyFormatInEditMode = true)]
        [Column(TypeName = "datetime2")]
        public DateTime? ReplacedDate { get; set; }



        [Required]
        [DisplayName("Next Follow Date")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd-MMM-yyyy}", ApplyFormatInEditMode = true)]
        [Column(TypeName = "datetime2")]
        public DateTime NextFollowDate { get; set; }


        //[Required]
        //[DisplayName("Received Time")]
        //[DataType(DataType.Date)]
        //[DisplayFormat(DataFormatString = "{0:dd-MMM-yyyy}", ApplyFormatInEditMode = true)]
        //[Column(TypeName = "datetime2")]
        //public DateTime ReceivedTime { get; set; }



        //[Required]
        //[StringLength(20)]
        //public string? BatchSerialNo { get; set; }


        public bool IsUsed { get; set; }
        //[NotMapped]
        //public bool IsTransaction { get; set; }

        [StringLength(20)]
        public string? Status { get; set; }


    }




}
