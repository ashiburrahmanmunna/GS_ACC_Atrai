using Atrai.Model.Core.Entity.Base;

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Atrai.Model.Core.Entity
{
    [Table("Supplier")]
    public class SupplierModel : BaseModel
    {
        [Required]
        [Display(Name = "Supplier Name")]

        public string? SupplierName { get; set; }
        [EmailAddress]
        public string? Email { get; set; }

        [StringLength(30)]
        public string? Phone { get; set; }

        [StringLength(20)]
        //[Remote("CheckExistingCustomerCode", "Values", HttpMethod = "POST", AdditionalFields = "Id", ErrorMessage = "Customer Code already Used. Try with a different Code.")]

        [Display(Name = "Supplier Code")]
        public string? SupplierCode { get; set; }


        [DataType(DataType.MultilineText)]
        [Display(Name = "Primary Address")]

        public string? PrimaryAddress { get; set; }

        //[StringLength(200)]

        //[DataType(DataType.MultilineText)]
        //public string? PrimaryAddress { get; set; }

        [StringLength(200)]

        [Display(Name = "Secoundary Address")]
        [DataType(DataType.MultilineText)]
        public string? SecoundaryAddress { get; set; }

        [StringLength(200)]
        public string? City { get; set; }

        [StringLength(200)]
        [DataType(DataType.MultilineText)]
        public string? Notes { get; set; }

        public virtual IEnumerable<TransactionModel>? AccountsDailyTransaction { get; set; }

        public virtual IEnumerable<PurchaseModel>? Purchase { get; set; }

        public string? StatusRemarks { get; set; }

        [StringLength(1, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 1)]
        [DataType(DataType.Text)]
        [Display(Name = "Supplier Type")]
        public string? SupType { get; set; }

        [ForeignKey("Suppliers")]
        [Display(Name = "Supplier Group")]

        public int? SupParentId { get; set; }
        [Display(Name = "Group Supplier Name")]
        public virtual SupplierModel? Suppliers { get; set; }


        [Display(Name = "Opening Balance")]
        [Column(TypeName = "decimal(18,4)")]
        public double OpBalance { get; set; }

        [Display(Name = "Balance")]
        [Column(TypeName = "decimal(18,4)")]
        public decimal ClBalance { get; set; }

        [Phone]
        [StringLength(15, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 11)]
        [Display(Name = "Login Id (Phone No)")]
        [Microsoft.AspNetCore.Mvc.Remote("CheckExistingPhoneSupplier", "Values", HttpMethod = "POST", AdditionalFields = "Id", ErrorMessage = "Phone No already Used. Try with a different Phone Number.")]
        public string? LoginId { get; set; }

        [StringLength(20, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 6)]
        public string? Password { get; set; }

        [StringLength(10, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 6)]
        [Display(Name = "Trade License")]
        public string? TradeLicenseNo { get; set; }

        public bool IsInActive { get; set; }
        [Display(Name = "Supplier Commission %")]
        [Column(TypeName = "decimal(18,4)")]
        public decimal SupplierCommissionPer { get; set; } = 0;



        [StringLength(100)]
        [Display(Name = "Contact Person")]
        public string? ContactPersonName { get; set; }


        [StringLength(100)]
        [Display(Name = "Designation")]
        public string? ContactPersonDesignation { get; set; }

        [StringLength(100)]
        public string? Website { get; set; }



        //================ column added by Mahin starts====================
        [StringLength(60)]
        [Display(Name = "Title")]
        public string? Title { get; set; }
        [StringLength(60)]
        [Display(Name = "FirstName")]
        public string? FirstName { get; set; }

        [StringLength(60)]
        [Display(Name = "MiddleName")]
        public string? MiddleName { get; set; }

        [StringLength(60)]
        [Display(Name = "LastName")]
        public string? LastName { get; set; }

        [StringLength(60)]
        [Display(Name = "Suffix")]
        public string? Suffix { get; set; }
        [StringLength(120)]
        [Display(Name = "CompanyName")]
        public string? CompanyName { get; set; }
        [Display(Name = "MobileNo")]
        [Phone]
        public string? MobileNo { get; set; }

        [StringLength(60)]
        [Display(Name = "Fax")]
        public string? Fax { get; set; }

        [Display(Name = "Street Address")]
        public string? Other { get; set; }
        [DataType(DataType.MultilineText)]
        public string? StreetAddress { get; set; }

        [StringLength(60)]
        [Display(Name = "Province")]
        public string? Province { get; set; }

        [StringLength(60)]
        [Display(Name = "PostalCode")]
        public string? PostalCode { get; set; }
        public string? Country { get; set; }
        [Display(Name = "Image [Folder]")]

        public string? FilePath { get; set; }

        public string? SupplierFilePath { get; set; }

        [StringLength(60)]
        [Display(Name = "BusinessIdNo")]
        public string? BusinessIdNo { get; set; }

        [StringLength(60)]
        [Display(Name = "Billing Rate")]
        public string? BillingRate { get; set; }

        [Display(Name = "Payment Terms")]
        [ForeignKey("PaymentTermsInfo")]
        public int? PaymentTermsId { get; set; }
        [Display(Name = "Payment Terms")]
        public virtual PaymentTermsModel? PaymentTermsInfo { get; set; }


        [StringLength(60)]
        [Display(Name = "AccountNo")]
        public string? AccountNo { get; set; } = string.Empty;


        [Display(Name = "Expense Category Head :")]
        public int? AccIdExpenseCategory { get; set; }
        [ForeignKey("AccIdExpenseCategory")]
        public virtual AccountHeadModel? ExpenseCategoryAccount { get; set; }

        [DisplayName("As of")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd-MMM-yyyy}", ApplyFormatInEditMode = true)]
        [Column(TypeName = "datetime2")]
        public DateTime? AsOf { get; set; }



        [Display(Name = "Currency")]
        public virtual CountryModel? Currency { get; set; }
        [Display(Name = "Currency")]
        [ForeignKey("Currency")]
        public int SupplierCurrencyId { get; set; }
        //================ column added by Mahin ends======================



    }


    public class SupplierResultList
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Email { get; set; }
        public string? Address { get; set; }
        public string? PrimaryAddress { get; set; }
        public string? SecoundaryAddress { get; set; }
        public string? SupplierCode { get; set; }

        public string? Notes { get; set; }
        public string? Phone { get; set; } = string.Empty;
        public decimal TotalPurchaseValue { get; set; }
        public decimal TotalPurchaseReturnValue { get; set; }
        public decimal TotalAmountBack { get; set; }

        public string? SupType { get; set; }
        public string? ParentSupplier { get; set; }

        public decimal TotalPayment { get; set; }
        public decimal TotalDue { get; set; }
        public string? LastPurchaseDate { get; set; }
        public string? LastInvoiceNo { get; set; }

        public string? LastPurchaseProduct { get; set; }


    }
}
