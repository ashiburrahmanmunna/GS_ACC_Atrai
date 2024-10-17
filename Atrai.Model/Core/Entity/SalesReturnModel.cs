using Atrai.Model.Core.Entity.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Atrai.Model.Core.Entity
{
    [Table("SalesReturn")]
    public class SalesReturnModel : BaseModel
    {
        /// <summary>
        ///  Remarks , ttlSumQty , ttlCountQty , ttlUnitPrice , ttlIndVat , ttlIndDisAmt , ttlIndPrice , ttlSumAmt will be delete
        /// </summary>

        [Required]
        [DisplayName("SalesReturn Date")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd-MMM-yyyy}", ApplyFormatInEditMode = true)]
        [Column(TypeName = "datetime2")]
        public DateTime SalesReturnDate { get; set; }
        [DisplayName("SalesReturn Doc No")]


        //[Column(TypeName = "varchar(50)")]
        [StringLength(40)]
        public string? SalesReturnCode { get; set; }
        [StringLength(200)]

        public string? Notes { get; set; }
        [Required]
        public Double Total { get; set; }
        [StringLength(20)]

        public string? Status { get; set; }
        [Column(TypeName = "decimal(18,4)")]

        public decimal? Discount { get; set; }

        [Column(TypeName = "decimal(18,4)")]

        public decimal GrandTotal { get; set; }

        [Column(TypeName = "decimal(18,4)")]

        public decimal TotalCommisionAmount { get; set; }


        //[DisplayName("Payment Method")]
        //[StringLength(20)]

        //public string? PaymentMethod { get; set; }

        //[StringLength(200)]

        //[DataType(DataType.MultilineText)]
        //public string? Remarks { get; set; }


        [Phone]
        [DisplayName("Phone No")]
        [StringLength(30)]

        public string? PhoneNo { get; set; }

        [StringLength(20)]

        [DisplayName("Postal Code")]
        public string? PostalCode { get; set; }


        [StringLength(50)]

        [DisplayName("Email")]
        public string? EmailId { get; set; }
        [StringLength(50)]

        [DisplayName("City")]
        public string? City { get; set; }



        public Boolean ChkPer { get; set; }

        [Display(Name = "% Discount")]

        [Column(TypeName = "decimal(18,4)")]
        public decimal DisPer { get; set; }
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


        [Display(Name = "Store Location")]
        public int? WarehouseIdMain { get; set; }
        [ForeignKey("WarehouseIdMain")]
        public virtual WarehouseModel? Warehouses { get; set; }


        [DisplayName("CustomerId")]
        [ForeignKey("CustomerModel")]
        public int CustomerId { get; set; }
        public CustomerModel? CustomerModel { get; set; }


        [DisplayName("SaleId")]
        [ForeignKey("SalesInfo")]
        public int? SaleId { get; set; }
        public SalesModel SalesInfo { get; set; }



        [StringLength(100)]

        [Display(Name = "Customer Name")]
        public string? CustomerName { get; set; }
        [StringLength(200)]

        //[Required]
        [DataType(DataType.MultilineText)]
        [Display(Name = "Primary Address")]
        public string? PrimaryAddress { get; set; }

        [StringLength(200)]

        //[Required]
        [DataType(DataType.MultilineText)]
        [Display(Name = "Secoundary Address")]
        public string? SecoundaryAddress { get; set; }


        public bool isPOSSalesReturn { get; set; }
        public bool isSerialSalesReturn { get; set; }

        public bool isPosted { get; set; }

        [Column(TypeName = "decimal(18,4)")]
        public decimal Profit { get; set; }
        [Column(TypeName = "decimal(18,4)")]
        public decimal ProfitPercentage { get; set; }
        [Column(TypeName = "decimal(18,4)")]
        public decimal FinalCostingPrice { get; set; }


        //[Display(Name = "Received Head")]
        //[ForeignKey("vCreditAccount")]
        //public int? CreditAccountId { get; set; }
        //[Display(Name = "Payment / Received Head")]
        //public virtual AccountHeadModel? CreditAccount { get; set; }



        public ICollection<SalesReturnItemsModel> Items { get; set; }
        public ICollection<SalesExchangeItemsModel> ExchangeItems { get; set; }

        public virtual ICollection<SalesReturnPaymentModel> SalesReturnPayments { get; set; }
        public virtual ICollection<CostCalculatedModel> CostCalculations { get; set; }

        public virtual ICollection<TransactionModel>? AccountTransaction { get; set; }



        [NotMapped]
        [DataType(DataType.Text)]
        [Display(Name = "UserId")]
        public string? UserId { get; set; }

        //[Required]
        //[NotMapped]
        //[DataType(DataType.Text)]
        //[Display(Name = "UserName")]
        //public string? UserName { get; set; }


        [Display(Name = "User Name")]
        [ForeignKey("InternetUserList")]
        public int? InternetUserId { get; set; }
        [Display(Name = "Internet User")]
        public virtual InternetUserModel? InternetUserList { get; set; }

        [Display(Name = "Sales Representative")]
        [ForeignKey("SalesRep")]
        public int? SalesRepId { get; set; }
        [Display(Name = "Sales Representative")]
        public virtual EmployeeModel? SalesRep { get; set; }



        public SalesReturnModel()
        {
            Items = new List<SalesReturnItemsModel>();
            ExchangeItems = new List<SalesExchangeItemsModel>();
            SalesReturnPayments = new List<SalesReturnPaymentModel>();
            CostCalculations = new List<CostCalculatedModel>();
            AccountTransaction = new List<TransactionModel>();
        }



    }

    
    [Table("SalesReturnItems")]
    public class SalesReturnItemsModel : BaseModel
    {
        [DisplayName("ProductId")]
        [ForeignKey("ProductModel")]
        public int ProductId { get; set; }
        public virtual ProductModel? Product { get; set; }
        [StringLength(200)]

        public string? Name { get; set; }

        [Required]
        public double Price { get; set; }
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


        [DataType(DataType.MultilineText)]
        [StringLength(200)]

        public string? Description { get; set; }


        [DisplayName("Sale")]
        [ForeignKey("SalesReturnModel")]
        public int SalesReturnId { get; set; }
        public SalesReturnModel SalesReturnModel { get; set; }

        [Display(Name = "Store Location")]
        public int? WarehouseId { get; set; }

        [ForeignKey("WarehouseId")]

        public virtual WarehouseModel? vWarehouse { get; set; }


        [NotMapped]
        public string[]? SerialItemArray { get; set; }

        public string? SerialItem { get; set; }
        [NotMapped]
        public bool IsTransaction { get; set; }

        public ICollection<SalesReturnBatchItemsModel> BatchSerialItems { get; set; }

        public double CostPrice { get; set; }

        public double AvgCostPrice { get; set; }



        [Column(TypeName = "decimal(18,4)")]
        public double IndDiscount { get; set; }

        [Column(TypeName = "decimal(18,4)")]
        public double IndDisPer { get; set; }

        public double? IndDiscountProportionRtn { get; set; }

    }



    [Table("SalesReturnBatchItems")]
    public class SalesReturnBatchItemsModel : BaseModel
    {

        [DisplayName("SalesReturn Items")]
        [ForeignKey("SalesReturnItems")]
        public int SalesReturnItemId { get; set; }
        public virtual SalesReturnItemsModel SalesReturnItems { get; set; }


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


        //public double CostPrice { get; set; }

    }




    [Table("SalesReturnPayment")]
    public class SalesReturnPaymentModel : BaseModel
    {

        //[Key, Column(Order = 0)]

        //[Display(Name = "Payment Type")]
        //public int? PaymentTypeId { get; set; }
        [StringLength(100)]

        public string? PaymentCardNo { get; set; }


        public Boolean isPosted { get; set; }


        [Column(TypeName = "decimal(18,4)")]
        public decimal Amount { get; set; }



        public int? RowNo { get; set; }

        //public string? ComId { get; set; }


        public int SalesReturnId { get; set; }

        [ForeignKey("SalesReturnId")]

        public virtual SalesReturnModel? SalesReturnMain { get; set; }






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





    [Table("SalesExchangeItems")]
    public class SalesExchangeItemsModel : BaseModel
    {
        [DisplayName("ProductId")]
        [ForeignKey("ProductModel")]
        public int ProductId { get; set; }
        public virtual ProductModel? Product { get; set; }
        [StringLength(100)]

        public string? Name { get; set; }

        [Required]
        public double Price { get; set; }
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


        [DataType(DataType.MultilineText)]
        [StringLength(200)]

        public string? Description { get; set; }


        [DisplayName("Sale")]
        [ForeignKey("SalesReturnModel")]
        public int SalesReturnId { get; set; }
        public SalesReturnModel SalesReturnModel { get; set; }

        [Display(Name = "Store Location")]
        public int? WarehouseId { get; set; }

        [ForeignKey("WarehouseId")]

        public virtual WarehouseModel? vWarehouse { get; set; }


        [NotMapped]
        public string[]? SerialItemArray { get; set; }

        public string? SerialItem { get; set; }
        [NotMapped]
        public bool IsTransaction { get; set; }

        public ICollection<SalesExchangeBatchItemsModel> BatchSerialItems { get; set; }

        public double CostPrice { get; set; }

        public double AvgCostPrice { get; set; }


        public double IndDiscountProportionExc { get; set; }

        [Column(TypeName = "decimal(18,4)")]
        public double IndDiscount { get; set; }

        [Column(TypeName = "decimal(18,4)")]
        public double IndDisPer { get; set; }


        [Display(Name = "BD PO Items")]
        [ForeignKey("PurchaseItems")]
        public int? PurchaseItemsId { get; set; }
        public virtual PurchaseItemsModel? PurchaseItems { get; set; }

    }



    [Table("SalesExchangeBatchItems")]
    public class SalesExchangeBatchItemsModel : BaseModel
    {

        [DisplayName("SalesExchange Items")]
        [ForeignKey("SalesExchangeItems")]
        public int SalesExchangeItemId { get; set; }
        public virtual SalesExchangeItemsModel SalesExchangeItems { get; set; }


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


        //public double CostPrice { get; set; }

    }



}
