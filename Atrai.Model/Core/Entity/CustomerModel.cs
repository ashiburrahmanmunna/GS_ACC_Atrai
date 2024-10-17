using Atrai.Model.Core.Entity.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Atrai.Model.Core.Entity
{
    [Table("Customer")]
    public class CustomerModel : BaseModel
    {
        [Required]
        [StringLength(100)]

        public string? Name { get; set; }
        [StringLength(10)]
        public string? Title { get; set; }
        [StringLength(30)]
        public string? FirstName { get; set; }
        [StringLength(30)]
        public string? MiddelName { get; set; }
        [StringLength(30)]
        public string? LastName { get; set; }
        [StringLength(30)]
        public string? Suffix { get; set; }
        [StringLength(100)]
        public string? DisplayName { get; set; }
        [StringLength(100)]
        public string? CompanyName { get; set; }
        [StringLength(20)]
        public string? MobileNumber { get; set; }
        [StringLength(50)]
        public string? Fax { get; set; }
        [StringLength(50)]
        public string? Other { get; set; }

        [StringLength(50)]
        public string? ShippingMarks { get; set; }

        //new
        [Display(Name = "Currency")]
        public virtual CountryModel? Currency { get; set; }
        [Display(Name = "Currency")]
        [ForeignKey("Currency")]
        public int CustomerCurrencyId { get; set; }

        [StringLength(200)]
        public string? BillingStreetAddress { get; set; }
        [StringLength(50)]
        public string? BillingCity { get; set; }
        [StringLength(50)]
        public string? BillingProvince { get; set; }
        [StringLength(50)]
        public string? BillingPostalCode { get; set; }
        [StringLength(50)]
        public string? BillingCountry { get; set; }


        [StringLength(200)]
        public string? ShippingStreetAddress { get; set; }
        [StringLength(50)]
        public string? ShippingCity { get; set; }
        [StringLength(50)]
        public string? ShippingProvince { get; set; }
        [StringLength(50)]
        public string? ShippingPostalCode { get; set; }
        [StringLength(50)]
        public string? ShippingCountry { get; set; }



        [StringLength(300)]
        public string? FileName { get; set; }
        [StringLength(20)]
        //[Remote("CheckExistingCustomerCode", "Values", HttpMethod = "POST", AdditionalFields = "Id", ErrorMessage = "Customer Code already Used. Try with a different Code.")]

        [Display(Name = "Customer Code")]
        public string? CustomerCode { get; set; }


        [StringLength(100)]

        [EmailAddress]
        public string? Email { get; set; }

        
        [StringLength(30)]

        public string? Phone { get; set; } = string.Empty; 
        [StringLength(200)]


        [DataType(DataType.MultilineText)]
        [Display(Name = "Primary Address")]

        public string? PrimaryAddress { get; set; }

        [StringLength(200)]


        [Display(Name = "Secoundary Address")]
        [DataType(DataType.MultilineText)]
        public string? SecoundaryAddress { get; set; }

        [DataType(DataType.MultilineText)]
        [StringLength(200)]

        public string? Notes { get; set; }
        [StringLength(200)]
        public string? City { get; set; }
        [StringLength(100)]

        public string? PostalCode { get; set; }

        public virtual IEnumerable<TransactionModel>? AccountsDailyTransaction { get; set; }

        public virtual IEnumerable<SalesModel>? Sales { get; set; }



        [StringLength(1, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 1)]
        [DataType(DataType.Text)]
        [Display(Name = "Customer Type")]
        public string? CustType { get; set; }

        [ForeignKey("Customers")]
        [Display(Name = "Customer Group")]

        public int? CustParentId { get; set; }
        [Display(Name = "Group Customer Name")]
        public virtual CustomerModel? Customers { get; set; }

        [Display(Name = "Opening Balance")]
        [Column(TypeName = "decimal(18,4)")]
        public double OpBalance { get; set; }

        [Display(Name = "Closing Balance")]
        [Column(TypeName = "decimal(18,4)")]
        public decimal ClBalance { get; set; }


        [Display(Name = "OverDue Balance")]
        [Column(TypeName = "decimal(18,4)")]
        public double OverDueBalance { get; set; }

        [Display(Name = "Credit Limit")]
        [Column(TypeName = "decimal(18,4)")]
        public double CreditLimit { get; set; }


        [Display(Name = "Trade Terms")]

        public int? TradeTermsId { get; set; }
        [Display(Name = "Trade Terms")]
        public virtual TradeTermsModel? TradeTerms { get; set; }

        /// <summary>
        /// //////////////requirement from gazipur mobile sales dealer
        /// </summary>
        [Display(Name = "Monthly Sales Target")]
        [Column(TypeName = "decimal(18,4)")]
        public double MonthlyTarget { get; set; }


        [Display(Name = "Sales Representative")]
        public int? SalesRepresentativeId { get; set; }
        [Display(Name = "Sales Representative")]
        public virtual EmployeeModel? SalesRepresentative { get; set; }


        [Display(Name = "Next Payment Date")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd-MMM-yyyy}", ApplyFormatInEditMode = true)]

        [Column(TypeName = "datetime2")]
        public DateTime? NextPaymentDate { get; set; }


        [Phone]
        [StringLength(15, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 11)]
        [Microsoft.AspNetCore.Mvc.Remote("CheckExistingPhoneCustomer", "Values", HttpMethod = "POST", AdditionalFields = "Id", ErrorMessage = "Phone No already Used. Try with a different Phone Number.")]
        [Display(Name = "Login Id (Phone No)")]
        public string? LoginId { get; set; }

        [StringLength(20, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 6)]
        public string? Password { get; set; }

        public bool IsInActive { get; set; }


        [Display(Name = "Customer Commission %")]
        [Column(TypeName = "decimal(18,4)")]

        public decimal CustomerCommissionPer { get; set; } = 0;


        [Display(Name = "SR Commission %")]
        [Column(TypeName = "decimal(18,4)")]

        public decimal SRCommissionPer { get; set; } = 0;



        [StringLength(100)]
        [Display(Name = "Contact Person")]
        public string? ContactPersonName { get; set; }


        [StringLength(100)]
        [Display(Name = "Designation")]
        public string? ContactPersonDesignation { get; set; }

        [StringLength(100)]
        public string? Website { get; set; }

        public int? BuyerGroupId { get; set; }
        [ForeignKey("BuyerGroupId")]

        public virtual BuyerGroup? BuyerGroup { get; set; }

        public int? PaymentTypeId { get; set; }
        [ForeignKey("PaymentTypeId")]

        public virtual PaymentTypeModel? vPaymentType { get; set; }

        [Display(Name = "Payment Terms")]
        [ForeignKey("PaymentTermsInfo")]
        public int? PaymentTermsId { get; set; }
        [Display(Name = "Payment Terms")]
        public virtual PaymentTermsModel? PaymentTermsInfo { get; set; }

        [StringLength(100)]
        public string? DeliveryOptions { get; set; }
        [StringLength(50)]
        public string? Language { get; set; }

        [StringLength(50)]
        public string? Taxes { get; set; }
        public DateTime OpeningDate { get; set; }       
    }


    public class CustomerResultList
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Email { get; set; }
        public string? PrimaryAddress { get; set; }
        public string? SecoundaryAddress { get; set; }
        public string? Notes { get; set; }
        public string? Phone { get; set; }
        //public double TotalSalesQty { get; set; }
        [Column(TypeName = "decimal(18,4)")]
        public decimal TotalSalesValue { get; set; }
        [Column(TypeName = "decimal(18,4)")]
        public decimal TotalSalesReturnValue { get; set; }
        [Column(TypeName = "decimal(18,4)")]
        public decimal TotalAmountBack { get; set; }
        [Column(TypeName = "decimal(18,4)")]
        public decimal TotalCollection { get; set; }
        [Column(TypeName = "decimal(18,4)")]
        public decimal TotalDue { get; set; }

        public double OpBalance { get; set; }



        public string? LastSalesDate { get; set; }
        public string? LastInvoiceNo { get; set; }
        public string? LastSoldProduct { get; set; }

        public string? CustType { get; set; }
        public string? ParentCustomer { get; set; }
    }
}
