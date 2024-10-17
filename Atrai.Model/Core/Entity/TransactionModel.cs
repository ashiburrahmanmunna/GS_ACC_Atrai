using Atrai.Model.Core.Entity.Base;
using Atrai.Model.Core.Entity.Self;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Atrai.Model.Core.Entity
{
    //[Table("AccountsDailyTransaction")]
    //public class TransactionModel : BaseModel
    //{
    //    [Display(Name = "Transaction Code")]
    //    [StringLength(30)]
    //    public string? TransactionCode { get; set; }

    //    [Display(Name = "Transaction Type")]
    //    [StringLength(30)]
    //    public string? TransactionType { get; set; }

    //    [Display(Name = "Transaction Category")]
    //    [StringLength(30)]
    //    public string? TransactionCategory { get; set; }


    //    [Required]
    //    [Display(Name = "Entry Date")]
    //    [DataType(DataType.Date)]
    //    [DisplayFormat(DataFormatString = "{0:dd-MMM-yyyy}", ApplyFormatInEditMode = true)]
    //    [Column(TypeName = "datetime2")]
    //    public DateTime InputDate { get; set; }

    //    [Display(Name = "Transaction Head")]
    //    public virtual AccountHeadModel? Account { get; set; }
    //    [Display(Name = "Transaction Head")]
    //    [ForeignKey("vAccount")]
    //    public int? AccountId { get; set; }





    //    [Display(Name = "Asset / Liability Head")]
    //    public virtual AccountHeadModel? AccountAssetLiability { get; set; }
    //    [Display(Name = "Asset / Liability Head")]
    //    [ForeignKey("AccountAssetLiability")]
    //    public int? AssetLiabilityAccountId { get; set; }





    //    [Display(Name = "Description")]
    //    [DataType(DataType.MultilineText)]
    //    public string? Description { get; set; }



    //    [Display(Name = "Currency")]
    //    [ForeignKey("Currency")]
    //    public int? CurrencyId { get; set; }
    //    public CountryModel? Currency { get; set; }


    //    [Display(Name = "Currency Rate")]
    //    //[Range(1, int.MaxValue, ErrorMessage = "Please enter a value bigger than {1}")]
    //    [Column(TypeName = "decimal(18,4)")]
    //    public double CurrencyRate { get; set; } = 0;


    //    [Display(Name = "Transaction Amount")]
    //    [Range(0, int.MaxValue, ErrorMessage = "Please enter a value bigger than {0}")]
    //    [Column(TypeName = "decimal(18,4)")]
    //    public decimal TransactionAmount { get; set; }

    //    //[NotMapped]
    //    [Display(Name = "Discount Amount")]
    //    [Column(TypeName = "decimal(18,4)")]
    //    public decimal DiscountAmount { get; set; } = 0;

    //    [Display(Name = "VAT Amount")]
    //    [Column(TypeName = "decimal(18,4)")]
    //    public decimal VATAmount { get; set; } = 0;


    //    [Display(Name = "AIT Amount")]
    //    [Column(TypeName = "decimal(18,4)")]
    //    public decimal AITAmount { get; set; } = 0;


    //    [Display(Name = "Is Post")]
    //    public bool isPost { get; set; }
    //    [Display(Name = "Payment / Received Head")]
    //    [ForeignKey("vCreditAccount")]
    //    public int? CreditAccountId { get; set; }
    //    [Display(Name = "Payment / Received Head")]
    //    public virtual AccountHeadModel? CreditAccount { get; set; }


    //    [ForeignKey("PaymentType")]
    //    public int? PaymentTypeId { get; set; }
    //    public virtual PaymentTypeModel? PaymentType { get; set; }


    //    [Display(Name = "Is System")]
    //    public bool isSystem { get; set; }







    //    [Display(Name = "Customer")]
    //    public virtual CustomerModel? Customer { get; set; }
    //    [Display(Name = "Customer")]
    //    [ForeignKey("vCustomer")]
    //    public int? CustomerId { get; set; }

    //    [Display(Name = "Internet User")]
    //    public virtual InternetUserModel? InternetUser { get; set; }
    //    [Display(Name = "Internet User")]
    //    [ForeignKey("InternetUser")]
    //    public int? InternetUserId { get; set; }


    //    [Display(Name = "Supplier")]
    //    public virtual SupplierModel? Supplier { get; set; }
    //    [Display(Name = "Supplier")]
    //    [ForeignKey("vSupplier")]
    //    public int? SupplierId { get; set; }


    //    [Display(Name = "Member")]
    //    public virtual MemberModel? Member { get; set; }
    //    [Display(Name = "Member")]
    //    [ForeignKey("vMember")]
    //    public int? MemberId { get; set; }


    //    [Display(Name = "Employee")]
    //    public virtual EmployeeModel? Employee { get; set; }
    //    [Display(Name = "Employee")]
    //    [ForeignKey("Employee")]
    //    public int? EmployeeId { get; set; }



    //    [Display(Name = "Purchase")]
    //    public virtual PurchaseModel? Purchase { get; set; }
    //    [Display(Name = "Purchase")]
    //    [ForeignKey("Purchase")]
    //    public int? PurchaseId { get; set; }




    //    [Display(Name = "Purchase Return")]
    //    public virtual PurchaseReturnModel? PurchaseReturn { get; set; }
    //    [Display(Name = "Purchase Return")]
    //    [ForeignKey("PurchaseReturn")]
    //    public int? PurchaseReturnId { get; set; }




    //    [Display(Name = "Sales")]
    //    public virtual SalesModel? Sales { get; set; }
    //    [Display(Name = "Sales")]
    //    [ForeignKey("Sales")]
    //    public int? SalesId { get; set; }


    //    [Display(Name = "Sales Return")]
    //    public virtual SalesReturnModel? SalesReturn { get; set; }
    //    [Display(Name = "Sales Return")]
    //    [ForeignKey("SalesReturn")]
    //    public int? SalesReturnId { get; set; }






    //    [Display(Name = "Issue")]
    //    public virtual IssueModel? Issue { get; set; }
    //    [Display(Name = "Issue")]
    //    [ForeignKey("Issue")]
    //    public int? IssueId { get; set; }




    //    [Display(Name = "Damage")]
    //    public virtual DamageModel? Damage { get; set; }
    //    [Display(Name = "Damage")]
    //    [ForeignKey("Damage")]
    //    public int? DamageId { get; set; }


    //    [Display(Name = "Transfer In")]
    //    public virtual InternalTransferModel? TransferIn { get; set; }
    //    [Display(Name = "Transfer In")]
    //    [ForeignKey("TransferIn")]
    //    public int? TransferInId { get; set; }



    //    [Display(Name = "Transfer Out")]
    //    public virtual InternalTransferModel? TransferOut { get; set; }
    //    [Display(Name = "Transfer Out")]
    //    [ForeignKey("TransferOut")]
    //    public int? TransferOutId { get; set; }



    //    [Display(Name = "Voucher")]
    //    public virtual Acc_VoucherMainModel? VoucherMain { get; set; }
    //    [Display(Name = "Voucher")]
    //    [ForeignKey("VoucherMain")]
    //    public int? VoucherId { get; set; }


    //    public IEnumerable<TransactionDetailsModel>? TransactionDetails { get; set; }
    //    //public ICollection<TransactionDetailsModel> TransactionDetails { get; set; }


    //    [DisplayName("Transaction")]
    //    [ForeignKey("ParentTransaction")]
    //    public int? ParentTransactionId { get; set; }
    //    public TransactionModel? ParentTransaction { get; set; }



    //    [Display(Name = "Location")]
    //    public int? WarehouseId { get; set; }

    //    [ForeignKey("WarehouseId")]

    //    public virtual WarehouseModel? vWarehouse { get; set; }


    //    [Display(Name = "Image [Folder]")]

    //    public string? FilePath { get; set; }

    //    public virtual ICollection<TransactionTagsModel>? TransactionTagsList { get; set; }

    //    [NotMapped]
    //    public string[]? TransactionTags { get; set; }

    //    public string? TransactionFilePath { get; set; }


    //}

    //[Table("AccountsDailyTransactionDetails")]
    //public class TransactionDetailsModel : BaseModel
    //{

    //    //public int TransactionId { get; set; }
    //    //[ForeignKey("TransactionId")]
    //    //public virtual TransactionModel? TransactionMain { get; set; }


    //    [DisplayName("Transaction")]
    //    [ForeignKey("TransactionMain")]
    //    public int TransactionId { get; set; }
    //    public TransactionModel? TransactionMain { get; set; }




    //    [Display(Name = "Sales")]
    //    public virtual SalesModel? Sales { get; set; }
    //    [Display(Name = "Sales")]
    //    [ForeignKey("Sales")]
    //    public int? SalesId { get; set; }


    //    [Display(Name = "Purchase")]
    //    public virtual PurchaseModel? Purchase { get; set; }
    //    [Display(Name = "Purchase")]
    //    [ForeignKey("Purchase")]
    //    public int? PurchaseId { get; set; }




    //    //[Display(Name = "Purchase Return")]
    //    //public virtual PurchaseReturnModel? PurchaseReturn { get; set; }
    //    //[Display(Name = "Purchase Return")]
    //    //[ForeignKey("PurchaseReturn")]
    //    //public int? PurchaseReturnId { get; set; }

    //    public float Amount { get; set; }


    //    [Column(TypeName = "decimal(18,4)")]
    //    public decimal Discount { get; set; }


    //    [Column(TypeName = "decimal(18,4)")]
    //    public decimal VAT { get; set; }


    //    [Column(TypeName = "decimal(18,4)")]
    //    public decimal AIT { get; set; }


    //    [Column(TypeName = "decimal(18,4)")]
    //    public decimal NetAmount { get; set; }
    //    public int? PaymentType { get; set; } = 0;


    //}


    [Table("AccountsDailyTransaction")]
    public class TransactionModel : BaseModel
    {
        [Display(Name = "Transaction Code")]
        [StringLength(30)]
        public string? TransactionCode { get; set; }

        [Display(Name = "Transaction Type")]
        [StringLength(30)]
        public string? TransactionType { get; set; } = string.Empty;


        //[Required]
        [Display(Name = "Transaction Category")]
        [StringLength(30)]
        public string? TransactionCategory { get; set; } = "";


        [Required]
        [Display(Name = "Entry Date")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd-MMM-yyyy}", ApplyFormatInEditMode = true)]
        [Column(TypeName = "datetime2")]
        public DateTime InputDate { get; set; }



        [ForeignKey("PaymentType")]
        public int? PaymentTypeId { get; set; }
        public virtual PaymentTypeModel? PaymentType { get; set; }

        public bool IsRecurring { get; set; }

        [Display(Name = "Image [Folder]")]

        public string? FilePath { get; set; } = string.Empty;

        public virtual ICollection<TransactionTagsModel>? TransactionTagsList { get; set; }

        [NotMapped]
        public string[]? TransactionTags { get; set; }

        public string? TransactionFilePath { get; set; } = string.Empty;


        //[Display(Name = "Transaction Head")]
        //public virtual AccountHeadModel? Account_Test { get; set; }
        //[Display(Name = "Transaction Head")]
        //[ForeignKey("Account_Test")]
        //public int? AccountId_Test { get; set; }



        //[Display(Name = "Payment / Received Head")]
        //[ForeignKey("CreditAccount_Test")]
        //public int? CreditAccountId_Test { get; set; }
        //[Display(Name = "Payment / Received Head")]
        //public virtual AccountHeadModel? CreditAccount_Test { get; set; }



        //[Display(Name = "Asset / Liability Head")]
        //public virtual AccountHeadModel? AccountAssetLiability_Test { get; set; }
        //[Display(Name = "Asset / Liability Head")]
        //[ForeignKey("AccountAssetLiability_Test")]
        //public int? AssetLiabilityAccountId_Test { get; set; }



        public string? ApprovalStage { get; set; }


        [Display(Name = "Description")]
        [DataType(DataType.MultilineText)]
        public string? Description { get; set; } = string.Empty;



        [Display(Name = "Currency")]
        [ForeignKey("Currency")]
        public int? CurrencyId { get; set; }
        public CountryModel? Currency { get; set; }


        [Display(Name = "Currency Rate")]
        //[Range(1, int.MaxValue, ErrorMessage = "Please enter a value bigger than {1}")]
        [Column(TypeName = "decimal(18,4)")]
        public double CurrencyRate { get; set; } = 0;


        [Display(Name = "Transaction Amount")]
        [Range(0.001, int.MaxValue, ErrorMessage = "Please enter a value bigger than {0}")]
        [Column(TypeName = "decimal(18,4)")]
        public decimal TransactionAmount { get; set; }


        [Display(Name = "Quantity")]
        //[Range(0.000, int.MaxValue, ErrorMessage = "Please enter a value bigger than {0}")]
        [Column(TypeName = "decimal(18,4)")]
        public decimal TransactionQuantity { get; set; }

        [Display(Name = "Rate")]
        //[Range(0.000, int.MaxValue, ErrorMessage = "Please enter a value bigger than {0}")]
        [Column(TypeName = "decimal(18,4)")]
        public decimal TransactionRate { get; set; }


        //[NotMapped]
        [Display(Name = "Discount Amount")]
        [Column(TypeName = "decimal(18,4)")]
        public decimal DiscountAmount { get; set; } = 0;

        [Display(Name = "VAT Amount")]
        [Column(TypeName = "decimal(18,4)")]
        public decimal VATAmount { get; set; } = 0;


        [Display(Name = "AIT Amount")]
        [Column(TypeName = "decimal(18,4)")]
        public decimal AITAmount { get; set; } = 0;


        [Display(Name = "Is Post")]
        public bool isPost { get; set; }


        [Display(Name = "Is System")]
        public bool isSystem { get; set; }

        

        [Display(Name = "Debit Account")]
        public virtual AccountHeadModel? DebitAccount { get; set; }
        [Display(Name = "Debit Account")]
        [ForeignKey("DebitAccount")]
        [Required(ErrorMessage = "Debit Account is required.")]
        public int? DebitAccountId { get; set; }



        [Display(Name = "Credit Account")]
        public virtual AccountHeadModel? CreditAccount { get; set; }
        [Display(Name = "Credit Account")]
        [ForeignKey("CreditAccount")]
        [Required(ErrorMessage = "Credit Account is required.")]
        public int? CreditAccountId { get; set; }



        [Display(Name = "Customer")]
        public virtual CustomerModel? Customer { get; set; }
        [Display(Name = "Customer")]
        [ForeignKey("vCustomer")]
        public int? CustomerId { get; set; }

        [Display(Name = "Internet User")]
        public virtual InternetUserModel? InternetUser { get; set; }
        [Display(Name = "Internet User")]
        [ForeignKey("InternetUser")]
        public int? InternetUserId { get; set; }


        [Display(Name = "Supplier")]
        public virtual SupplierModel? Supplier { get; set; }
        [Display(Name = "Supplier")]
        [ForeignKey("vSupplier")]
        public int? SupplierId { get; set; }


        [Display(Name = "Member")]
        public virtual MemberModel? Member { get; set; }
        [Display(Name = "Member")]
        [ForeignKey("vMember")]
        public int? MemberId { get; set; }


        [Display(Name = "Employee")]
        public virtual EmployeeModel? Employee { get; set; }
        [Display(Name = "Employee")]
        [ForeignKey("Employee")]
        public int? EmployeeId { get; set; }



        [Display(Name = "Purchase")]
        public virtual PurchaseModel? Purchase { get; set; }
        [Display(Name = "Purchase")]
        [ForeignKey("Purchase")]
        public int? PurchaseId { get; set; }




        [Display(Name = "Purchase Return")]
        public virtual PurchaseReturnModel? PurchaseReturn { get; set; }
        [Display(Name = "Purchase Return")]
        [ForeignKey("PurchaseReturn")]
        public int? PurchaseReturnId { get; set; }


        [Display(Name = "Salary")]
        public virtual EmployeeSalaryMasterModel? SalarySheet { get; set; }
        [Display(Name = "SalarySheet")]
        [ForeignKey("SalarySheet")]
        public int? SalarySheetId { get; set; }


        [Display(Name = "Sales")]
        public virtual SalesModel? Sales { get; set; }
        [Display(Name = "Sales")]
        [ForeignKey("Sales")]
        public int? SalesId { get; set; }


        [Display(Name = "Sales Return")]
        public virtual SalesReturnModel? SalesReturn { get; set; }
        [Display(Name = "Sales Return")]
        [ForeignKey("SalesReturn")]
        public int? SalesReturnId { get; set; }


        public int? FiscalMonthId { get; set; }
        [ForeignKey("FiscalMonthId")]
        public virtual Acc_FiscalMonthModel? Acc_FiscalMonth { get; set; }



        [Display(Name = "Issue")]
        public virtual IssueModel? Issue { get; set; }
        [Display(Name = "Issue")]
        [ForeignKey("Issue")]
        public int? IssueId { get; set; }




        [Display(Name = "Damage")]
        public virtual DamageModel? Damage { get; set; }
        [Display(Name = "Damage")]
        [ForeignKey("Damage")]
        public int? DamageId { get; set; }


        [Display(Name = "Transfer In")]
        public virtual InternalTransferModel? TransferIn { get; set; }
        [Display(Name = "Transfer In")]
        [ForeignKey("TransferIn")]
        public int? TransferInId { get; set; }



        [Display(Name = "Transfer Out")]
        public virtual InternalTransferModel? TransferOut { get; set; }
        [Display(Name = "Transfer Out")]
        [ForeignKey("TransferOut")]
        public int? TransferOutId { get; set; }






        [Display(Name = "Voucher")]
        public virtual Acc_VoucherMainModel? VoucherMain { get; set; }
        [Display(Name = "Voucher")]
        [ForeignKey("VoucherMain")]
        public int? VoucherId { get; set; }


        public IEnumerable<TransactionDetailsModel>? TransactionDetails { get; set; }
        //public ICollection<TransactionDetailsModel> TransactionDetails { get; set; }


        [DisplayName("Transaction")]
        [ForeignKey("ParentTransaction")]
        public int? ParentTransactionId { get; set; }
        public TransactionModel? ParentTransaction { get; set; }



        [Display(Name = "Location")]
        public int? WarehouseId { get; set; }

        [ForeignKey("WarehouseId")]

        public virtual WarehouseModel? vWarehouse { get; set; }

        public int? ComingFrom { get; set; }



        public double ReceivedAmount { get; set; } = 0;
        public double AdjustedAmount { get; set; } = 0;





        [Display(Name = "Product")]
        public virtual ProductModel? vProduct { get; set; }
        [Display(Name = "Product")]
        [ForeignKey("vProduct")]
        public int? ProductItemId { get; set; }



        [Display(Name = "Category")]
        public virtual CategoryModel? vCategory { get; set; }
        [Display(Name = "Category")]
        [ForeignKey("vCategory")]
        public int? CategoryItemId { get; set; }





        [StringLength(30)]
        [Display(Name = "Check No")]

        public string? CheckNo { get; set; } = string.Empty;
        [Display(Name = "Rec. Date")]

        public DateTime? dtFromChk { get; set; }
        [Display(Name = "Validity Date")]

        public DateTime? dtToChk { get; set; }
        [Display(Name = "Clear Date")]

        public DateTime? dtClearChk { get; set; }
        [StringLength(100)]
        [Display(Name = "Check Notes")]

        public string? CheckRemarks { get; set; } = string.Empty;


        [NotMapped]
        public string? TransactionImageString { get; set; } = string.Empty;


        [Display(Name = "Is Receipt")]
        public bool isReceipt { get; set; }

        [Display(Name = "Is Payment")]
        public bool isPayment { get; set; }

    }





    [Table("AccountsDailyTransactionDetails")]
    public class TransactionDetailsModel : BaseModel
    {

        //public int TransactionId { get; set; }
        //[ForeignKey("TransactionId")]
        //public virtual TransactionModel? TransactionMain { get; set; }


        [DisplayName("Transaction")]
        [ForeignKey("TransactionMain")]
        public int TransactionId { get; set; }
        public TransactionModel? TransactionMain { get; set; }




        [Display(Name = "Sales")]
        public virtual SalesModel? Sales { get; set; }
        [Display(Name = "Sales")]
        [ForeignKey("Sales")]
        public int? SalesId { get; set; }


        [Display(Name = "Purchase")]
        public virtual PurchaseModel? Purchase { get; set; }
        [Display(Name = "Purchase")]
        [ForeignKey("Purchase")]
        public int? PurchaseId { get; set; }




        //[Display(Name = "Purchase Return")]
        //public virtual PurchaseReturnModel? PurchaseReturn { get; set; }
        //[Display(Name = "Purchase Return")]
        //[ForeignKey("PurchaseReturn")]
        //public int? PurchaseReturnId { get; set; }

        public float Amount { get; set; }


        [Column(TypeName = "decimal(18,4)")]
        public decimal Discount { get; set; }

        [Column(TypeName = "decimal(18,4)")]
        public decimal ExchangeLossGain { get; set; }

        [Column(TypeName = "decimal(18,4)")]
        public decimal VAT { get; set; }


        [Column(TypeName = "decimal(18,4)")]
        public decimal AIT { get; set; }


        [Column(TypeName = "decimal(18,4)")]
        public decimal NetAmount { get; set; }


        [NotMapped]
        [Column(TypeName = "decimal(18,4)")]
        public decimal PrevReceived { get; set; }

    }




    [Table("TransactionTags")]
    public class TransactionTagsModel : BaseModel
    {
        public int TransactionId { get; set; }
        [ForeignKey("TransactionId")]
        public virtual TransactionModel? Transactions { get; set; }
        //[Key]
        //public int VoucherSubCheckId { get; set; }
        public string? tag { get; set; }


    }





    [Table("EmployeeSalary_Master")]
    public class EmployeeSalaryMasterModel : BaseModel
    {

        [Display(Name = "Salary Month")]
        public DateTime SalaryMonth { get; set; }

        [Display(Name = "Salary Date From")]
        public DateTime SalaryMonthFrom { get; set; }


        [Display(Name = "Salary Date To")]
        public DateTime SalaryMonthTo { get; set; }

        [Display(Name = "Salary Type")]
        public int? SalaryTypeId { get; set; }
        [ForeignKey("SalaryTypeId")]
        public virtual Cat_SalaryTypeModel SalaryType { get; set; }


        [Display(Name = "Employee Type")]
        public int? EmployeeTypeId { get; set; }
        [ForeignKey("EmployeeTypeId")]
        public virtual Cat_EmployeeTypeModel? EmployeeType { get; set; }


        [Display(Name = "Department")]
        public int? DepartmentId { get; set; }
        [ForeignKey("DepartmentId")]
        public virtual Cat_DepartmentModel? DepartmentList { get; set; }


        [Display(Name = "Week Segment")]
        public int? WeekSegmentId { get; set; }
        [ForeignKey("WeekSegmentId")]
        public virtual Cat_WeekSegmentModel WeekSegment { get; set; }


        [Display(Name = "Location")]
        public int? WarehouseId { get; set; }
        [ForeignKey("WarehouseId")]
        public virtual WarehouseModel? Location { get; set; }


        [Display(Name = "Remarks")]
        public string? SalaryMasterRemarks { get; set; }

        //public virtual ICollection<EmployeeSalaryDetailsModel> SalaryDetailsList { get; set; }

        public ICollection<EmployeeSalaryDetailsModel> SalaryDetailsList { get; set; }

        public EmployeeSalaryMasterModel()
        {
            SalaryDetailsList = new List<EmployeeSalaryDetailsModel>();

        }

        public bool IsPosted { get; set; }

    }



    [Table("Cat_EmployeeType")]
    public partial class Cat_EmployeeTypeModel : SelfModel
    {

        [Display(Name = "Section Name")]
        [Required(ErrorMessage = "Please Provide Section Name")]
        [StringLength(100)]
        [DataType("NVARCHAR(100)")]
        public string? EmployeeType { get; set; }

        [Display(Name = "Section Bangla")]
        [StringLength(100)]
        [DataType("NVARCHAR(100)")]
        public string? EmployeeTypeBangla { get; set; }

        [Display(Name = "SL NO")]
        public int Slno { get; set; }

        //public virtual ICollection<EmployeeModel> EmployeeList { get; set; }
        //fahad
    }


    [Table("Cat_SalaryType")]
    public partial class Cat_SalaryTypeModel : SelfModel
    {

        [Display(Name = "Salary Name")]
        [Required(ErrorMessage = "Please Provide Salary Type")]
        [StringLength(100)]
        [DataType("NVARCHAR(100)")]
        public string? SalaryType { get; set; }


        [Display(Name = "SL NO")]
        public int Slno { get; set; }

        //public virtual ICollection<EmployeeModel> EmployeeList { get; set; }
        //fahad
    }


    [Table("Cat_WeekSegment")]
    public partial class Cat_WeekSegmentModel : SelfModel
    {

        [Display(Name = "Section Name")]
        [Required(ErrorMessage = "Please Provide Section Name")]
        [StringLength(100)]
        [DataType("NVARCHAR(100)")]
        public string? WeekName { get; set; }

        [Display(Name = "SL NO")]
        public int Slno { get; set; }
    }



    [Table("EmployeeSalary_Details")]
    public class EmployeeSalaryDetailsModel : BaseModel
    {

        //[Display(Name = "Salary Master")]
        //public int EmployeeSalaryMasterId { get; set; }
        //[ForeignKey("EmployeeSalaryMasterId")]
        //public virtual EmployeeSalaryMasterModel? EmployeeSalaryMaster { get; set; }


        [DisplayName("Salary Master")]
        [ForeignKey("EmployeeSalaryMaster")]
        public int SalaryMasterId { get; set; }
        public EmployeeSalaryMasterModel EmployeeSalaryMaster { get; set; }



        [Display(Name = "Employee")]
        public int? EmployeeId { get; set; }
        [ForeignKey("EmployeeId")]
        public virtual EmployeeModel? Employee { get; set; }




        [Display(Name = "GS")]
        public float GS { get; set; } = 0;


        [Display(Name = "BS")]
        public float BS { get; set; } = 0;


        [Display(Name = "Allowance")]
        public float Allowance { get; set; } = 0;

        [Display(Name = "TotalDay")]
        public float TotalDay { get; set; } = 0;


        [Display(Name = "Other Addition")]
        public float OtherAddition { get; set; } = 0;


        [Display(Name = "AbsentDay")]
        public float AbsentDay { get; set; } = 0;

        [Display(Name = "AbsentDeduction")]
        public float AbsentDeduction { get; set; } = 0;

        [Display(Name = "OtherDeduction")]
        public float OtherDeduction { get; set; } = 0;

        [Display(Name = "Advance Deduction")]
        public float AdvanceDeduction { get; set; } = 0;

        [Display(Name = "LoanDeduction")]
        public float LoanDeduction { get; set; } = 0;

        [Display(Name = "Net Amount")]
        public float NetAmount { get; set; } = 0;


        [Display(Name = "Count")]
        public float HourProductionCount { get; set; } = 0;


        [Display(Name = "Salary Details Remarks")]
        public string? SalaryDetailsRemarks { get; set; }



    }






}
