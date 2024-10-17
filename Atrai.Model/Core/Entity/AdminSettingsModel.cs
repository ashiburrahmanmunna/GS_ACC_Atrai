using Atrai.Model.Core.Entity.Base;
using Atrai.Model.Core.Entity.Self;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Atrai.Model.Core.Entity
{


    [Table("AccountsReport")]
    public class AccountsReportModel : SelfModel
    {
        //[Key]
        //[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        //public int BusinessTypeId { get; set; }

        [Required]
        [StringLength(30)]
        [Display(Name = "Tab")]
        public string? Tab { get; set; }


        [Display(Name = "Group")]
        [StringLength(200)]
        public string? Group { get; set; }
        [StringLength(100)]

        [Display(Name = "Report Name")]
        public string? ReportName { get; set; }

        [Display(Name = "Controller Name")]
        public string? ControllerName { get; set; }

        [Display(Name = "Action Name")]
        public string? ActionName { get; set; }

        [Display(Name = "Inactive")]
        public bool IsInActive { get; set; }

        [Display(Name = "Is Favorite")]
        public bool IsFavorite { get; set; }

         [Display(Name = "Serial No.")]
        public int? SerialNo { get; set; }

    }

    [Table("BusinessType")]
    public class BusinessTypeModel : SelfModel
    {
        //[Key]
        //[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        //public int BusinessTypeId { get; set; }

        [Required]
        [StringLength(300)]
        [Display(Name = "Business Type")]

        public string? BusinessTypeName { get; set; }
        [Display(Name = "Remarks")]
        [StringLength(200)]

        public string? BusinessTypeRemarks { get; set; }
        [StringLength(100)]

        [Display(Name = "Apps Name")]
        public string? AppsName { get; set; }

        [Display(Name = "Inactive")]
        public bool IsInActive { get; set; }


        [Display(Name = "IsAccounts")]
        public bool IsAccounts { get; set; }


        [Display(Name = "IsWalton")]
        public bool IsWalton { get; set; }


        [Display(Name = "IsMarcel")]
        public bool IsMarcel { get; set; }

        [Display(Name = "Is Dealer Based Organization")]
        public bool IsDealerBasedOrganization { get; set; }

    }


    [Table("TaxForm")]
    public class TaxFormModel : SelfModel
    {

        [Required]
        [StringLength(300)]
        [Display(Name = "Tax Form")]
        public string? TaxFormName { get; set; }

        [StringLength(200)]
        [Display(Name = "Inactive")]
        public bool IsInActive { get; set; }

    }



    [Table("FiscalYearType")]
    public class FiscalYearTypeModel : SelfModel
    {
        [Required]
        [StringLength(30)]
        [Display(Name = "Fiscal Year Type")]

        public string? FYName { get; set; }

        [Range(1, 31)]
        [Display(Name = "Start Date Int Value")]
        public int FYStartDate { get; set; }

        [Range(1, 12)]
        [Display(Name = "Start Month Int Value")]
        public int FYStartMonth { get; set; }

        [Range(1, 31)]
        [Display(Name = "End Date Int Value")]
        public int FYEndDate { get; set; }

        [Range(1, 12)]
        [Display(Name = "End Month Int Value")]
        public int FYEndMonth { get; set; }



        [Display(Name = "Inactive")]
        public bool IsInActive { get; set; }
    }



    [Table("CustomFormStyleVariable")]
    public class CustomFormStyleVariableModel : SelfModel
    {
        [StringLength(30)]
        public string? VariableName { get; set; }

        [StringLength(30)]
        public string? VariableValue { get; set; }
        [Required]
        [StringLength(30)]
        public string? VariableFor { get; set; }

    }

    [Table("Variable")]
    public class VariableModel : SelfModel
    {
        [StringLength(30)]
        public string? VariableName { get; set; }

        [StringLength(30)]
        public string? VariableValue { get; set; }
        [Required]
        [StringLength(30)]
        public string? VariableFor { get; set; }

        [StringLength(30)]
        public string? VariableCategory { get; set; }

        [StringLength(100)]
        public string? ClassName { get; set; }

        [StringLength(30)]
        public string? VariableAction { get; set; }

        [StringLength(50)]
        public string? VariableController { get; set; }

        [StringLength(30)]
        public string? VariablePerameter { get; set; }

        [StringLength(50)]
        public string? PerameterValue { get; set; }

        public bool IsTop { get; set; }

        [StringLength(300)]
        [Display(Name = "Icons")]

        public string? Icons { get; set; }

    }
    [Table("CustomFormStyle")]
    public class CustomFormStyleModel : BaseModel
    {
        [StringLength(100)]
        [Display(Name = "Name")]
        public string? Name { get; set; }
        public bool IsInActive { get; set; }

        [StringLength(50)]
        public string? ReportFor { get; set; }
        [StringLength(100)]
        public string? Template { get; set; }

        [StringLength(100)]
        [Display(Name = "Business Name")]
        public string? BusinessName { get; set; }

        [StringLength(20)]
        public string? Color { get; set; }
        [StringLength(20)]
        public string? FontColor { get; set; }

        [StringLength(20)]
        [Display(Name = "Phone")]
        public string? Phone { get; set; }

        [StringLength(100)]
        public string? LogoSize { get; set; }

        [EmailAddress]
        public string? Email { get; set; }

        [StringLength(100)]
        public string? FontSize { get; set; }
        [StringLength(100)]
        [Display(Name = "Company Reg No")]
        public string? CompanyRegNo { get; set; }

        [StringLength(100)]
        public string? LogoPlacement { get; set; }
        [StringLength(100)]
        [Display(Name = "Business All Address")]
        public string? BusinessAllAddress { get; set; }

        [StringLength(100)]
        public string? FontFamily { get; set; }


        [StringLength(100)]
        public string? PageMarginLeft { get; set; }

        [StringLength(100)]
        public string? PageMarginRight { get; set; }

        [StringLength(100)]
        public string? PageMarginTop { get; set; }

        [StringLength(100)]
        public string? PageMarginBottom { get; set; }
        [Display(Name = "IsFitPrinted")]
        public bool IsFitPrinted { get; set; }

        [Display(Name = "IsLetterHeadUsed")]
        public bool IsLetterHeadUsed { get; set; }

        //newly added starts--
        [Display(Name = "Doc Type")]
        [ForeignKey("DocTypeList")]
        public int? DocTypeId { get; set; }
        [Display(Name = "Doc Type")]
        public virtual DocTypeModel? DocTypeList { get; set; }
        [Display(Name = "IsDefault")]

        public bool IsDefault { get; set; }
        public bool IsBusinessNameShow { get; set; }
        public bool IsPhoneShow { get; set; }
        public bool IsEmailShow { get; set; }
        public bool IsComRegShow { get; set; }
        public bool IsBusinessAddrsShow { get; set; }
        public bool IsWebsiteShow { get; set; }
        public bool IsFormNumbers { get; set; }
        public bool IsCustomTranUsed { get; set; }
        public bool IsBillingAddress { get; set; }
        public bool IsShipping { get; set; }
        public bool IsDueDate { get; set; }
        public bool IsCustomVatNo { get; set; }
        public bool IsDiscounted { get; set; }
        public bool IsDeposited { get; set; }
        public bool IsTaxSummary { get; set; }
        public bool IsEstimateSummary { get; set; }
        public bool IsShowOnInvoice { get; set; }

        [StringLength(300)]
        [Display(Name = "MessageToCustomer")]
        public string? MessageToCustomer { get; set; }

        [StringLength(300)]
        [Display(Name = "FooterText")]
        public string? FooterText { get; set; }

        [StringLength(100)]
        [Display(Name = "Invoice")]
        public string? Invoice { get; set; }

        [StringLength(100)]
        [Display(Name = "Tax Invoice")]
        public string? TaxInvoice { get; set; }

        [StringLength(100)]
        [Display(Name = "Com Reg No")]
        public string? ComRegNo { get; set; }

        [StringLength(100)]
        [Display(Name = "Website")]
        public string? Website { get; set; }

        [StringLength(20)]
        public string? MessageToCustTextSize { get; set; }

        [StringLength(20)]
        public string? FooterTextSize { get; set; }
        [StringLength(20)]
        public string? FootertextPlacement { get; set; }
        public string? ColumnOrder { get; set; }

        public bool IsFullDetails { get; set; }
        public bool IsSummarizedDetails { get; set; }
        public bool IsPdfAttached { get; set; }



        [StringLength(200)]
        [Display(Name = "StandardEmailSubject")]
        public string? StandardEmailSubject { get; set; }
        public bool IsStandardEmialGreetingUsed { get; set; }

        [StringLength(200)]
        [Display(Name = "StandardEmailGreetingsAppeal")]
        public string? StandardEmailGreetingsAppeal { get; set; }
        [StringLength(200)]
        [Display(Name = "StandardEmailGreetingFullName")]
        public string? StandardEmailGreetingFullName { get; set; }
        [StringLength(200)]
        [Display(Name = "StandardEmailMsgToCustomer")]
        public string? StandardEmailMsgToCustomer { get; set; }




        [StringLength(200)]
        [Display(Name = "ReiminderEmailSubject")]
        public string? ReiminderEmailSubject { get; set; }
        public bool IsReiminderEmailGreetingUsed { get; set; }

        [StringLength(200)]
        [Display(Name = "ReiminderEmailGreetingsAppeal")]
        public string? ReiminderEmailGreetingsAppeal { get; set; }
        [StringLength(200)]
        [Display(Name = "ReiminderEmailFullName")]
        public string? ReiminderEmailGreetingFullName { get; set; }
        [StringLength(200)]
        [Display(Name = "ReiminderEmailMsgToCustomer")]
        public string? ReiminderEmailMsgToCustomer { get; set; }

        public string? StandardEmailTemplateHolder { get; set; }
        public string? ReminderEmailTemplateHolder { get; set; }

        //newly added ends----
    }



    [Table("ReportStyle")]
    public class ReportStyleModel : SelfModel
    {
        [Required]
        [StringLength(30)]
        [Display(Name = "Report Style Name")]

        public string? ReportStyleName { get; set; }
        [Display(Name = "ReportStyleRemarks")]
        [StringLength(200)]

        public string? ReportStyleRemarks { get; set; }

        [Display(Name = "Inactive")]
        public bool IsInActive { get; set; }

        [StringLength(50)]
        public string? ReportFor { get; set; }

        [StringLength(50)]
        public string? LogoPlacement { get; set; }

        [StringLength(50)]
        public string? TextPlacement { get; set; }

    }


    [Table("SubscriptionType")]
    public class SubscriptionTypeModel : SelfModel
    {
        //[Key]
        //[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        //public int SubscriptionId { get; set; }

        [Required]
        [StringLength(30)]
        [Display(Name = "Subscription Type")]

        public string? SubscriptionName { get; set; }
        [Display(Name = "Subscription Remarks")]

        public string? SubscriptionRemarks { get; set; }
        [Display(Name = "Validity Days")]

        public int ValidityDay { get; set; }


        [Required]
        [Display(Name = "Amount")]
        public float SubscriptionAmount { get; set; }

        [Display(Name = "Validation Remarks")]
        public string? ValidationRemarks { get; set; }



        [Display(Name = "Business Type")]
        public virtual BusinessTypeModel? BusinessType { get; set; }
        [Display(Name = "Business Type")]
        [ForeignKey("BusinessType")]
        public int? BusinessTypeId { get; set; }

        [Display(Name = "Inactive")]
        public bool IsInActive { get; set; }

    }


    [Table("SubscriptionActivation")]
    public class SubscriptionActivationModel : SelfModel
    {
        //[Key]
        //[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        //public int SubscriptionId { get; set; }
        //select SubscriptiontypeId, Amount, ActiveFromDate, ActiveToDate, ActiveYesNo, Remarks from InvoiceSubs

        [Required]
        [Display(Name = "Amount")]
        public float Amount { get; set; }
        [Display(Name = "Remarks")]
        public string? Remarks { get; set; }

        [Display(Name = "Validity Days")]
        public double ValidityDay { get; set; } = 0;


        [Display(Name = "IsActive")]
        public bool IsActive { get; set; }


        [Display(Name = "Active From Date")]
        [DataType(DataType.Date)]
        [Column(TypeName = "datetime2")]
        public DateTime ActiveFromDate { get; set; }

        [Display(Name = "Active To Date")]
        [DataType(DataType.Date)]
        [Column(TypeName = "datetime2")]
        public DateTime ActiveToDate { get; set; }


        [Display(Name = "Subscription Type")]
        public virtual SubscriptionTypeModel? SubscriptionType { get; set; }
        [Display(Name = "Subscription Type")]
        [ForeignKey("SubscriptionType")]
        public int? SubscriptionTypeId { get; set; }



        [Display(Name = "User Name")]
        public virtual UserAccountModel? UserAccount { get; set; }
        [Display(Name = "User Name")]
        [ForeignKey("UserAccount")]
        public int LuserId { get; set; }


        [Display(Name = "Company")]
        public virtual CompanyModel? CompanyList { get; set; } 
        [Display(Name = "Company")]
        [ForeignKey("CompanyList")]
        public int? ComId { get; set; }

    }

    [Table("SubscriptionActivationCompany")]
    public class SubscriptionActivationCompanyModel : SelfModel
    {
        //[Key]
        //[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        //public int SubscriptionId { get; set; }
        //select SubscriptiontypeId, Amount, ActiveFromDate, ActiveToDate, ActiveYesNo, Remarks from InvoiceSubs

        [Required]
        [Display(Name = "Amount")]
        public float Amount { get; set; }
        [Display(Name = "Remarks")]
        public string? Remarks { get; set; }

        [Display(Name = "Validity Days")]
        public double ValidityDay { get; set; }


        [Display(Name = "IsActive")]
        public bool IsActive { get; set; }


        [Display(Name = "Active From Date")]
        [DataType(DataType.Date)]
        [Column(TypeName = "datetime2")]
        public DateTime ActiveFromDate { get; set; }

        [Display(Name = "Active To Date")]
        [DataType(DataType.Date)]
        [Column(TypeName = "datetime2")]
        public DateTime ActiveToDate { get; set; }


        [Display(Name = "Subscription Type")]
        public virtual SubscriptionTypeModel? SubscriptionType { get; set; }
        [Display(Name = "Subscription Type")]
        [ForeignKey("SubscriptionType")]
        public int? SubscriptionTypeId { get; set; }



        //[Display(Name = "User Name")]
        //public virtual UserAccountModel? UserAccount { get; set; }
        //[Display(Name = "User Name")]
        //[ForeignKey("UserAccount")]
        //public int LuserId { get; set; }


        [Display(Name = "Company")]
        public virtual CompanyModel? CompanyList { get; set; }
        [Display(Name = "Company")]
        [ForeignKey("CompanyList")]
        public int? ComId { get; set; }

    }






    [Table("SoftwarePackage")]

    public class SoftwarePackageModel : SelfModel
    {


        [Required]
        [Display(Name = "Software Package Code")]
        public string? SoftwarePackageCode { get; set; }

        [Required]
        [Display(Name = "Software Package")]
        public string? Name { get; set; }

        [Required]
        [StringLength(300, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 6)]
        [DataType(DataType.MultilineText)]
        [Display(Name = "Software Package Content")]
        public string? SoftwarePackageDescription { get; set; }

        [Display(Name = "Software Package Link")]
        public string? LinkAdd { get; set; }


        [Display(Name = "Price")]
        public float PackagePrice { get; set; }

        [Display(Name = "Package Discount Percentages [%]")]
        public float DiscountPercentage { get; set; }


        [Display(Name = "Duration")]
        public float Duration { get; set; }



        [Display(Name = "Total User")]
        public int UserCount { get; set; }



        //[Display(Name = "SoftwarePackage Image [DB]")]
        //[ValidateFile(ErrorMessage = "Please select a PNG image smaller than 1MB")]

        //public byte[] SoftwarePackageImage { get; set; }

        //[Required]
        //[DataType(DataType.ImageUrl)]

        [Display(Name = "SoftwarePackage Image [Folder]")]

        public string? SoftwarePackageImagePath { get; set; }

        [Display(Name = "SoftwarePackage Files Extension")]
        public string? SoftwarePackageFileExtension { get; set; }

        //[Display(Name = "Start From Date")]
        //public string? PackageStartDate { get; set; }


        //[Display(Name = "End Date")]
        //public string? PackageEndDate { get; set; }



        [Display(Name = "Is Active")]
        public bool ActiveYesNo { get; set; }

        [NotMapped]
        public string? InvoiceNo { get; set; }


        [Display(Name = "Business Type")]
        public virtual BusinessTypeModel? BusinessType { get; set; }
        [Display(Name = "Business Type")]
        [ForeignKey("BusinessType")]
        public int? BusinessTypeId { get; set; }


        [Display(Name = "Package Duration")]
        public virtual DurationTimeModel DurationType { get; set; }
        [Display(Name = "Package Duration")]
        [ForeignKey("DurationType")]
        public int? DurationId { get; set; }
        public int TotalDays { get; set; }



        public int? CurrencyId { get; set; }
        [ForeignKey("CurrencyId")]
        public virtual CountryModel? Country { get; set; }
        //[Display(Name = "SoftwarePackage")]

        //public virtual ICollection<Product> vProducts { get; set; }
    }


    [Table("PackageActivation")]
    public class PackageActivationModel : BaseModel
    {

        [Required]
        [Display(Name = "Amount")]
        [Column(TypeName = "decimal(18,4)")]
        public decimal Amount { get; set; }
        [Display(Name = "Remarks")]
        public string? Remarks { get; set; }

        [Display(Name = "Validity Days")]
        public double ValidityDay { get; set; }


        [Display(Name = "IsActive")]
        public bool IsActive { get; set; }


        [Display(Name = "Active From Date")]
        [DataType(DataType.Date)]
        [Column(TypeName = "datetime2")]
        public DateTime ActiveFromDate { get; set; }

        [Display(Name = "Active To Date")]
        [DataType(DataType.Date)]
        [Column(TypeName = "datetime2")]
        public DateTime ActiveToDate { get; set; }


        [Display(Name = "Software Package")]
        public virtual SoftwarePackageModel? SoftwarePackage { get; set; }
        [Display(Name = "Software Package")]
        [ForeignKey("SoftwarePackage")]
        public int? PackageId { get; set; }

        [StringLength(50)]
        [Display(Name = "Invoice No")]
        public string? InvoiceNo { get; set; }

        [StringLength(50)]
        [Display(Name = "Billing Name")]
        public string? BillingName { get; set; }

        [StringLength(50)]
        [Display(Name = "Status")]
        public string? Status { get; set; }



        [DataType(DataType.Date)]
        [Display(Name = "Payment Date")]
        public DateTime PaymentDate { get; set; }

        [StringLength(50)]
        [Display(Name = "Transaction Id")]
        public string? TrxId { get; set; }

        public bool ActiveYesNo { get; set; }

    }



    [Table("EmailSettings")]

    public class EmailSettingModel : BaseModel
    {
        [Display(Name = "Host")]
        public string? MailServer { get; set; }
        [Display(Name = "Port")]
        public int MailPort { get; set; }

        [Display(Name = "Sender Address")]
        public string? Sender { get; set; }
        [Display(Name = "Password")]
        public string? Password { get; set; }
        [Display(Name = "Display Name")]
        public string? SenderName { get; set; }

        public Boolean IsActive { get; set; }
        [Display(Name = "Remarks")]

        public string? Remarks { get; set; }


    }


    [Table("SmsSetting")]

    public class SmsSettingModel : BaseModel
    {
        public string? smsAddress { get; set; }
        public string? smsUser { get; set; }
        public string? smsPassword { get; set; }
        public string? smsSender { get; set; }
        public string? SmsProvider { get; set; }
        //public string? smsCollection { get; set; }
        //public string? smsAbsent { get; set; }
        //public string? smsPresent { get; set; }
        //public string? smsLate { get; set; }
        public bool IsActive { get; set; }
       // public bool IsSystem { get; set; }


        //public string? isGtrServer { get; set; }
        //public string? IsSendToFahad { get; set; }
        //public string? EmailAddress_Fahad { get; set; }
        //public string? MobileNo_Fahad { get; set; }

    }

    [Table("Voter")]
    public class VoterModel : BaseModel
    {


        [MaxLength(20)]
        [Required(ErrorMessage = "ইনপুট নিশ্চিত করুন ।")]
        //[Display(Name = "Serial No")]
        [Display(Name = "ভোটার নাম্বার :")]
        [StringLength(30, ErrorMessage = "ভোটার নাম্বার অবশ্যই কমপক্ষে ১০ অক্ষর এবং সর্বোচ্চ 17 অক্ষর দীর্ঘ হতে হবে |", MinimumLength = 10)]
        [RegularExpression(@"^[0-9]+$", ErrorMessage = "ইংরেজি তে লিখুন । বিশেষ অক্ষর অনুমোদিত নয় |")]
        public string? voterNo { get; set; }


        [MaxLength(300)]
        [Required(ErrorMessage = "ইনপুট নিশ্চিত করুন।")]
        //[Display(Name = "Customer Name")]
        [Display(Name = "নাম :")]
        //[RegularExpression(@"^[a-zA-Z]+$", ErrorMessage = "ইংরেজি তে লিখুন । বিশেষ অক্ষর অনুমোদিত নয়।")]
        [StringLength(300, ErrorMessage = "নাম অবশ্যই কমপক্ষে 5 অক্ষর এবং সর্বোচ্চ 300 অক্ষর দীর্ঘ হতে হবে |", MinimumLength = 5)]

        public string? name { get; set; }



        [MaxLength(150)]
        [Required(ErrorMessage = "ইনপুট নিশ্চিত করুন।")]
        //[Display(Name = "Customer Name")]
        [Display(Name = "ইংরেজি নাম :")]
        //[RegularExpression(@"^[a-zA-Z]+$", ErrorMessage = "ইংরেজি তে লিখুন । বিশেষ অক্ষর অনুমোদিত নয়।")]
        [StringLength(150, ErrorMessage = "ইংরেজি তে লিখুন । নাম অবশ্যই কমপক্ষে 5 অক্ষর এবং সর্বোচ্চ 150 অক্ষর দীর্ঘ হতে হবে |", MinimumLength = 5)]
        public string? nameEn { get; set; }


        [MaxLength(300)]
        [Required(ErrorMessage = "ইনপুট নিশ্চিত করুন।")]
        //[Display(Name = "Customer Name")]
        [Display(Name = "পিতার নাম :")]
        //[RegularExpression(@"^[a-zA-Z]+$", ErrorMessage = "ইংরেজি তে লিখুন । বিশেষ অক্ষর অনুমোদিত নয়।")]
        [StringLength(300, ErrorMessage = "পিতার নাম অবশ্যই কমপক্ষে 5 অক্ষর এবং সর্বোচ্চ 300 অক্ষর দীর্ঘ হতে হবে |", MinimumLength = 5)]
        public string? father { get; set; }

        [MaxLength(300)]
        [Required(ErrorMessage = "ইনপুট নিশ্চিত করুন।")]
        //[Display(Name = "Customer Name")]
        [Display(Name = "মাতার নাম :")]
        //[RegularExpression(@"^[a-zA-Z]+$", ErrorMessage = "ইংরেজি তে মোবাইল নাম্বার লিখুন । বিশেষ অক্ষর অনুমোদিত নয়।")]
        [StringLength(300, ErrorMessage = "মাতার  নাম অবশ্যই কমপক্ষে 5 অক্ষর এবং সর্বোচ্চ 300 অক্ষর দীর্ঘ হতে হবে |", MinimumLength = 5)]
        public string? mother { get; set; }


        [MaxLength(10)]
        [Required(ErrorMessage = "ইনপুট নিশ্চিত করুন।")]
        //[Display(Name = "Customer Name")]
        [Display(Name = "লিঙ্গ :")]
        [RegularExpression(@"^[a-zA-Z]+$", ErrorMessage = "ইংরেজি তে  লিখুন । বিশেষ অক্ষর অনুমোদিত নয়।")]
        [StringLength(10, ErrorMessage = "Gender অবশ্যই কমপক্ষে 4 অক্ষর এবং সর্বোচ্চ 10 অক্ষর দীর্ঘ হতে হবে |", MinimumLength = 4)]
        public string? gender { get; set; }



        [MaxLength(300)]
        //[Required(ErrorMessage = "ইনপুট নিশ্চিত করুন।")]
        //[Display(Name = "Customer Name")]
        [Display(Name = "পত্নীর নাম :")]
        //[RegularExpression(@"^[a-zA-Z]+$", ErrorMessage = "ইংরেজি তে মোবাইল নাম্বার লিখুন । বিশেষ অক্ষর অনুমোদিত নয়।")]
        //[StringLength(300, ErrorMessage = "পত্নীর নাম অবশ্যই কমপক্ষে 5 অক্ষর এবং সর্বোচ্চ 300 অক্ষর দীর্ঘ হতে হবে |", MinimumLength = 5)]
        public string? spouse { get; set; }

        ////[Display(Name = "Entry Date")]
        [Display(Name = "জন্ম তারিখ :")]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}")]
        [DataType(DataType.Date)]
        //[DataType(DataType.DateTime)]
        public DateTime dob { get; set; }



        [MaxLength(600)]
        [Required(ErrorMessage = "ইনপুট নিশ্চিত করুন ।")]
        [StringLength(600, ErrorMessage = "স্থায়ী ঠিকানা অবশ্যই কমপক্ষে 5 অক্ষর এবং সর্বোচ্চ 600 অক্ষর দীর্ঘ হতে হবে |", MinimumLength = 5)]
        [DataType(DataType.MultilineText)]

        [Display(Name = "স্থায়ী ঠিকানা :")]

        public string? permanentAddress { get; set; }


        [MaxLength(600)]
        [Required(ErrorMessage = "ইনপুট নিশ্চিত করুন ।")]
        [StringLength(600, ErrorMessage = "বর্তমান ঠিকানা অবশ্যই কমপক্ষে 5 অক্ষর এবং সর্বোচ্চ 600 অক্ষর দীর্ঘ হতে হবে |", MinimumLength = 5)]
        [DataType(DataType.MultilineText)]

        [Display(Name = "বর্তমান ঠিকানা :")]

        public string? presentAddressBN { get; set; }



        [StringLength(50, ErrorMessage = "স্থায়ী ঠিকানা অবশ্যই কমপক্ষে 5 অক্ষর এবং সর্বোচ্চ 600 অক্ষর দীর্ঘ হতে হবে |", MinimumLength = 5)]
        [Display(Name = "পেশা :")]

        public string? profession { get; set; }




        [Display(Name = "Image [DB]")]

        public byte[]? photo { get; set; }



        [Column(TypeName = "nvarchar")]
        [StringLength(300)]
        [Display(Name = "স্ট্যাটাস")]
        public string? Status { get; set; }


        [Display(Name = "Photo Image [Folder]")]
        public string? photoPath { get; set; }

        [Display(Name = "Photo Files Extension")]
        public string? photoExtension { get; set; }

        [MaxLength(20)]
        [Display(Name = "পুরাতন ভোটার নাম্বার :")]
        public string? oldNationalIdNumber { get; set; }


        [NotMapped]
        public string? DateOfBirth { get; set; }
        [NotMapped]
        public int CreditCost { get; set; }
        [NotMapped]
        public int CreditCurrent { get; set; }

    }



    [Table("UserRole")]
    public class UserRoleModel : SelfModel
    {
        //[Key]
        //[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        //public int UserRoleId { get; set; }

        [Required]
        [StringLength(30)]
        [Display(Name = "Role Name")]

        public string? RoleName { get; set; }
        [Display(Name = "Remarks")]

        public string? RoleRemarks { get; set; }


        [Display(Name = "Business Type")]
        public virtual BusinessTypeModel? BusinessType { get; set; }
        [Display(Name = "Business Type")]
        [ForeignKey("BusinessType")]
        public int? BusinessTypeId { get; set; }


    }


    [Table("Menu")]
    public class MenuModel : SelfModel
    {
        //[Key]
        //[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        //public int MenuId { get; set; }
        [Required]
        [StringLength(30)]
        [Display(Name = "Menu Name")]
        public string? MenuName { get; set; }
        [Display(Name = "Menu Class")]
        public string? MenuClass { get; set; }
        [Display(Name = "Remarks")]
        public string? MenuRemarks { get; set; }
        //[Display(Name = "Is Dashboard")]
        //public bool isDashboard { get; set; }
        [Display(Name = "Is Parent")]
        public bool isParent { get; set; }

        [Display(Name = "Group Name")]
        public string? MenuGroupName { get; set; }

        [Display(Name = "Controller")]
        public string? ControllerName { get; set; } = "";

        [Display(Name = "Action")]
        public string? ActionName { get; set; } = "";
        [Display(Name = "Parent Menu")]
        public virtual MenuModel? ParentMenu { get; set; }
        [Display(Name = "Base / Parent Menu")]
        [ForeignKey("ParentMenu")]
        public int? ParentId { get; set; }
        public bool isGroup { get; set; }
        //public bool isBaseMenu { get; set; }
        [Display(Name = "Order")]
        public int? DisplayOrder { get; set; }


        [StringLength(300)]
        [Display(Name = "All Action Name")]
        public string? AllActionName { get; set; }



        [StringLength(50)]
        [Display(Name = "First Parameter")]
        public string? FirstParameter { get; set; }


        [StringLength(50)]
        [Display(Name = "First Value")]
        public string? FirstValue { get; set; }

        //public bool CreateAction { get; set; }
        //public bool EditAction { get; set; }
        //public bool DeleteAction { get; set; }
        //public bool ViewAction { get; set; }
        //public bool ReportAction { get; set; }


        [Display(Name = "Create")]

        public bool IsCreateAction { get; set; }
        [Display(Name = "Edit")]

        public bool IsEditAction { get; set; }
        [Display(Name = "Delete")]

        public bool IsDeleteAction { get; set; }
        [Display(Name = "View")]

        public bool IsViewAction { get; set; }
        [Display(Name = "List")]

        public bool IsListAction { get; set; }
        [Display(Name = "Report")]

        public bool IsReportAction { get; set; }

        public bool IsVatMenu { get; set; }


    }


    [Table("MenuPermission")]
    public class MenuPermissionModel : SelfModel
    {
        //[Key]
        //[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        //public int MenuPermissionId { get; set; }


        //[Display(Name = "User Role")]
        //public virtual UserRoleModel? UserRole { get; set; }
        //[Display(Name = "User Role")]
        //[ForeignKey("UserRole")]
        //public int UserRoleId { get; set; }



        [Display(Name = "Business Type")]
        public virtual BusinessTypeModel? BusinessType { get; set; }
        [Display(Name = "Business Type")]
        [ForeignKey("BusinessType")]
        public int BusinessTypeId { get; set; }


        //[NotMapped]
        //public int? Permitted { get; set; }
        //[NotMapped]
        //public int? MenuName { get; set; }


        [Display(Name = "Menu")]
        public virtual MenuModel? Menus { get; set; }
        [Display(Name = "Menu")]
        [ForeignKey("Menus")]
        public int MenuId { get; set; }


        //public bool IsCreatePermission { get; set; }
        //public bool IsUpdatePermission { get; set; }
        //public bool IsDeletePermission { get; set; }


    }


    [Table("AndroidMenu")]
    public class AndroidMenuModel : SelfModel
    {

        [Required]
        [StringLength(40)]
        [Display(Name = "Menu Name")]
        public string? MenuName { get; set; }
        [Display(Name = "Menu Page")]
        public int MenuPage { get; set; }

        [Display(Name = "Menu Caption")]
        [StringLength(40)]
        [Required]
        public string? MenuCaption { get; set; }


        [Display(Name = "Color One")]
        [StringLength(40)]
        [Required]
        public string? ColorOne { get; set; }

        [Display(Name = "Color Two")]
        [StringLength(40)]
        public string? ColorTwo { get; set; }

        [Display(Name = "Color Three")]
        [StringLength(40)]
        public string? ColorThree { get; set; }


        [Display(Name = "Gradiant Style")]
        [StringLength(40)]
        public string? GradiantStyle { get; set; }


        [Display(Name = "Icon Name")]
        [StringLength(40)]
        public string? IconName { get; set; }

        [Display(Name = "Icon Path")]
        [StringLength(40)]
        public string? IconPath { get; set; }

        [Display(Name = "Font Color")]
        [StringLength(40)]
        public string? FontColor { get; set; }

        [Display(Name = "Remarks")]
        public string? MenuRemarks { get; set; }
        public int? DisplayOrder { get; set; }

        public int? Radius { get; set; }

    }


    [Table("AndroidMenuPermission")]
    public class AndroidMenuPermissionModel : SelfModel
    {

        [Display(Name = "Business Type")]
        public virtual BusinessTypeModel? BusinessType { get; set; }
        [Display(Name = "Business Type")]
        [ForeignKey("BusinessType")]
        public int BusinessTypeId { get; set; }


        [Display(Name = "Android Menu")]
        public virtual AndroidMenuModel AndroidMenus { get; set; }
        [Display(Name = "Android Menu")]
        [ForeignKey("AndroidMenus")]
        public int AndroidMenuId { get; set; }

    }





    [Table("FromWarehousePermission")]
    public class FromWarehousePermissionModel : BaseModel
    {
        //[Display(Name = "User Account")]
        //public virtual UserAccountModel? UserAccountList { get; set; }
        //[Display(Name = "User Account")]
        //[ForeignKey("UserAccountList")]
        //public int LuserId { get; set; }

        public int LuserIdAllow { get; set; }



        [Display(Name = "Warehouse")]
        public virtual WarehouseModel? WarehouseList { get; set; }
        [Display(Name = "Warehouse")]
        [ForeignKey("WarehouseList")]
        public int WarehouseId { get; set; }

    }

    [Table("ToWarehousePermission")]
    public class ToWarehousePermissionModel : BaseModel
    {
        //[Display(Name = "User Account")]
        //public virtual UserAccountModel? UserAccountList { get; set; }
        //[Display(Name = "User Account")]
        //[ForeignKey("UserAccountList")]
        //public int LuserId { get; set; }

        public int LuserIdAllow { get; set; }


        [Display(Name = "Warehouse")]
        public virtual WarehouseModel? WarehouseList { get; set; }
        [Display(Name = "Warehouse")]
        [ForeignKey("WarehouseList")]
        public int WarehouseId { get; set; }

    }


    [Table("AccountHeadPermission")]
    public class AccountHeadPermissionModel : BaseModel
    {
        //[Display(Name = "User Account")]
        //public virtual UserAccountModel? UserAccountList { get; set; }
        //[Display(Name = "User Account")]
        //[ForeignKey("UserAccountList")]
        //public int LuserId { get; set; }

        public int LuserIdAllow { get; set; }



        [Display(Name = "Account Head")]
        public virtual AccountHeadModel? AccountHeadList { get; set; }
        [Display(Name = "Account Head")]
        [ForeignKey("AccountHeadList")]
        public int AccId { get; set; }

    }




    [Table("MenuPermission_Master")]

    public class MenuPermission_MasterModel : SelfModel
    {
        [Display(Name = "User")]
        public virtual UserAccountModel? UserAccount { get; set; }
        [Display(Name = "User")]
        [ForeignKey("UserAccount")]
        public int LUserIdPermission { get; set; }

        public int LuserId { get; set; }


        //public int? DefaultModuleId { get; set; }

        [Display(Name = "Company")]
        public virtual CompanyModel? Company { get; set; }
        [Display(Name = "Company")]
        [ForeignKey("Company")]
        public int ComId { get; set; }


        //[StringLength(128)]
        //[Display(Name = "Entry User")]

        //public string? userid { get; set; }

        //[StringLength(128)]
        //[Display(Name = "Update By")]

        //public string? useridUpdate { get; set; }

        //[NotMapped]
        public bool Active { get; set; }


        public bool SummaryView { get; set; }

        //public DateTime? DateAdded { get; set; }

        //[StringLength(50)]
        //public string? Updatedby { get; set; }

        //public Nullable<System.DateTime> DateUpdated { get; set; }


        public virtual ICollection<MenuPermission_DetailsModel>? MenuPermission_Details { get; set; }

    }

    [Table("MenuPermission_Details")]
    public class MenuPermission_DetailsModel : SelfModel
    {

        //[ForeignKey("MenuPermissionMasters")]
        //public int MenuPermissionId { get; set; }
        //public virtual MenuPermission_Master MenuPermissionMasters { get; set; }



        [Display(Name = "Menu Permission Master")]
        public virtual MenuPermission_MasterModel? MenuPermissionMasters { get; set; }
        [Display(Name = "Menu Permission Master")]
        [ForeignKey("MenuPermissionMasters")]
        public int MenuPermissionId { get; set; }


        //public int ModuleMenuId { get; set; }
        //public virtual ModuleMenu ModuleMenus { get; set; }





        [Display(Name = "Menu")]
        public virtual MenuModel? Menus { get; set; }
        [Display(Name = "Menu")]
        [ForeignKey("Menus")]
        public int MenuId { get; set; }






        public bool IsCreate { get; set; }
        public bool IsEdit { get; set; }
        public bool IsDeleteP { get; set; }
        public bool IsView { get; set; }
        public bool IsReport { get; set; }

        public int SLNo { get; set; }
        public bool isDefault { get; set; }



    }






    [Table("AndroidMenuPermission_Master")]

    public class AndroidMenuPermission_MasterModel : SelfModel
    {
        [Display(Name = "User")]
        public virtual UserAccountModel? UserAccount { get; set; }
        [Display(Name = "User")]
        [ForeignKey("UserAccount")]
        public int LUserIdPermission { get; set; }

        public int LuserId { get; set; }


        //public int? DefaultModuleId { get; set; }

        [Display(Name = "Company")]
        public virtual CompanyModel? Company { get; set; }
        [Display(Name = "Company")]
        [ForeignKey("Company")]
        public int ComId { get; set; }


        //[StringLength(128)]
        //[Display(Name = "Entry User")]

        //public string? userid { get; set; }

        //[StringLength(128)]
        //[Display(Name = "Update By")]

        //public string? useridUpdate { get; set; }

        //[NotMapped]
        public bool Active { get; set; }


        //public DateTime? DateAdded { get; set; }

        //[StringLength(50)]
        //public string? Updatedby { get; set; }

        //public Nullable<System.DateTime> DateUpdated { get; set; }


        public virtual ICollection<AndroidMenuPermission_DetailsModel> AndroidMenuPermission_Details { get; set; }

    }

    [Table("AndroidMenuPermission_Details")]
    public class AndroidMenuPermission_DetailsModel : SelfModel
    {

        //[ForeignKey("AndroidMenuPermissionMasters")]
        //public int AndroidMenuPermissionId { get; set; }
        //public virtual AndroidMenuPermission_Master AndroidMenuPermissionMasters { get; set; }



        [Display(Name = "Menu Permission Master")]
        public virtual AndroidMenuPermission_MasterModel? AndroidMenuPermissionMasters { get; set; }
        [Display(Name = "Menu Permission Master")]
        [ForeignKey("AndroidMenuPermissionMasters")]
        public int AndroidMenuPermissionId { get; set; }


        //public int ModuleMenuId { get; set; }
        //public virtual ModuleMenu ModuleMenus { get; set; }





        [Display(Name = "Menu")]
        public virtual AndroidMenuModel AndroidMenus { get; set; }
        [Display(Name = "Menu")]
        [ForeignKey("AndroidMenus")]
        public int MenuId { get; set; }






        public bool IsCreate { get; set; }
        public bool IsEdit { get; set; }
        public bool IsDeleteP { get; set; }
        public bool IsView { get; set; }
        public bool IsReport { get; set; }

        public int SLNo { get; set; }
        public bool isDefault { get; set; }



    }




    public class UserMenuPermissionViewModel
    {
        public int Id { get; set; }

        public string? ControllerName { get; set; }
        public string? ActionName { get; set; }
        public string? ParentName { get; set; }

        public string? MenuGroupName { get; set; }
        public string? MenuName { get; set; }
        public string? MenuClass { get; set; }



        public bool IsCreate { get; set; }
        public bool IsEdit { get; set; }
        public bool IsDeleteP { get; set; }
        public bool IsView { get; set; }
        public bool IsReport { get; set; }

        public bool IsGroup { get; set; }
        public bool IsParent { get; set; }

        public int? ParentId { get; set; }

        public int SLNo { get; set; }
        public bool isDefault { get; set; }

        public string? FirstParameter { get; set; }
        public string? FirstValue { get; set; }

        public string? AllActionName { get; set; } = "";
        public bool IsCreateAction { get; set; }
        public bool IsEditAction { get; set; }
        public bool IsDeleteAction { get; set; }
        public bool IsViewAction { get; set; }
        public bool IsReportAction { get; set; }
        public bool IsListAction { get; set; }

    }




    [Table("UserLogingInfo")]
    public class UserLogingInfoModel : BaseModel
    {

        [StringLength(300)]
        [Display(Name = "Web Link")]
        public string? WebLink { get; set; }
        [StringLength(100)]
        public string? Status { get; set; }
        public string? LongString { get; set; }
        public string? UserName { get; set; }

        //[Required]
        [Display(Name = "Transaction Date")]
        [DisplayFormat(DataFormatString = "{0:dd-MMM-yyyy}", ApplyFormatInEditMode = true)]
        public DateTime? LoginDate { get; set; }

        public DateTime? LoginTime { get; set; }

        [StringLength(50)]

        public string? PcName { get; set; }
        [StringLength(30)]

        public string? MacAddress { get; set; }
        [StringLength(128)]


        public string? IPAddress { get; set; }
        [StringLength(50)]


        public string? DeviceType { get; set; }
        [StringLength(128)]


        public string? Platform { get; set; }
        [StringLength(128)]

        public string? WebBrowserName { get; set; }


        [StringLength(128)]

        public string? Latitude { get; set; }
        [StringLength(128)]

        public string? Longitude { get; set; }


    }


    [Table("UserTransactionLog")]
    public class UserTransactionLogModel : BaseModel
    {
        [StringLength(300)]
        [Display(Name = "Web Link")]
        public string? WebLink { get; set; }


        [StringLength(300)]
        [Display(Name = "Transaction Statement")]
        public string? TransactionStatement { get; set; }
        [StringLength(60)]

        [Display(Name = "ControllerName")]
        public string? ControllerName { get; set; }
        [StringLength(100)]

        [Display(Name = "Action")]
        public string? ActionName { get; set; }
        [StringLength(300)]

        [Display(Name = "DocumentReferance")]
        public string? DocumentReferance { get; set; }
        [StringLength(300)]

        public string? CommandType { get; set; }

        [StringLength(200)]
        public string? PcName { get; set; }

        //[Required]
        [Display(Name = "Transaction Date")]
        [DisplayFormat(DataFormatString = "{0:dd-MMM-yyyy}", ApplyFormatInEditMode = true)]
        public DateTime? FromDateTime { get; set; }

        public DateTime? ToDateTime { get; set; }
        [StringLength(100)]

        public string? FlagValue { get; set; }

        [StringLength(100)]
        public string? IPAddress { get; set; }

    }

    [Table("AuditLog")]
    public class AuditLogModel : BaseModel
    {
        public string? DocType { get; set; }

        [ForeignKey("DocTypeList")]
        public int DocTypeId { get; set; }
        public virtual DocTypeModel? DocTypeList { get; set; }

        public string? KeyValue { get; set; }

        public string? Action { get; set; }
        
        public int TransactionId { get; set; }

    }


    [Table("CreditUsed")]
    public class CreditUsedModel : BaseModel
    {
        [StringLength(500)]
        [Display(Name = "SMS Text")]
        public string? SMSText { get; set; }


        [StringLength(300)]
        public string? CommandType { get; set; }

        [StringLength(300)]
        public string? Remarks { get; set; }

        public int TextLength { get; set; }
        public int Quantity { get; set; }

        public decimal UsedValue { get; set; }

        //[Required]
        [Display(Name = "Sending Date")]
        [DisplayFormat(DataFormatString = "{0:dd-MMM-yyyy}", ApplyFormatInEditMode = true)]
        public DateTime? SendingDate { get; set; }

    }


    [Table("Wallet")]
    public class WalletModel : SelfModel
    {
        [StringLength(10)]
        [Display(Name = "Transaction Type")]
        public string? TransactionType { get; set; }

        public DateTime PurchaseDate { get; set; }

        public DateTime ValidityDate { get; set; }
        [StringLength(200)]
        [Display(Name = "Remarks")]
        public string? Remarks { get; set; }

        [StringLength(50)]
        [Display(Name = "Recharge By")]
        public string? RechargeBy { get; set; }

        public decimal RechargeAmount { get; set; }
        public decimal UsedAmount { get; set; }

        [NotMapped]
        public decimal RemainingBalance { get; set; }

        [ForeignKey("CompanyList")]
        public int ComId { get; set; }
        [Display(Name = "Company")]
        public virtual CompanyModel? CompanyList { get; set; }


        [ForeignKey("UserList")]
        public int LuserId { get; set; }
        [Display(Name = "User")]
        public virtual UserAccountModel? UserList { get; set; }

        public bool IsPost { get; set; }
        public bool IsSystem { get; set; }


        [Display(Name = "Service Purchase")]
        public virtual CreditBalanceModel PurchaseItem { get; set; }
        [Display(Name = "Service Purchase")]
        [ForeignKey("PurchaseItem")]
        public int? CreditBalanceId { get; set; }



    }










    [Table("CreditBalance")]
    public class CreditBalanceModel : SelfModel
    {
        //[Display(Name = "Purchase Date")]
        //[DisplayFormat(DataFormatString = "{0:dd-MMM-yyyy}", ApplyFormatInEditMode = true)]
        public DateTime ActivationDate { get; set; }

        public DateTime ValidityDate { get; set; }

        //public decimal RechargeAmount { get; set; }
        //public decimal UsedAmount { get; set; }
        public int PurchaseQuantity { get; set; }
        public int UsedQuantity { get; set; }
        [Column(TypeName = "decimal(18,4)")]
        public decimal PurchaseRate { get; set; }

        [StringLength(500)]
        [Display(Name = "Remarks")]
        public string? Remarks { get; set; }


        [ForeignKey("CompanyList")]
        public int ComId { get; set; }
        [Display(Name = "Company")]
        public virtual CompanyModel? CompanyList { get; set; }
        //[Required]



        [ForeignKey("UserList")]
        public int LuserId { get; set; }
        [Display(Name = "User")]
        public virtual UserAccountModel? UserList { get; set; }



        [ForeignKey("PackageList")]
        public int? SoftwarePackageId { get; set; }
        [Display(Name = "Package")]
        public virtual SoftwarePackageModel? PackageList { get; set; }


        [StringLength(30)]
        [Display(Name = "Purchase For")]
        public string? Type { get; set; }
    }


    public class UserCompanyView
    {
        public int Id { get; set; }

        public int ComId { get; set; }
        public int LuserId { get; set; }

        public string? CompnayName { get; set; }

        public string? UserName { get; set; }

        public bool Permitted { get; set; }
    }


    public class UserRoleMenuView
    {
        public int Id { get; set; }

        public int MenuId { get; set; }
        public string? MenuGroupName { get; set; }

        public string? ParentMenuName { get; set; }

        public string? MenuName { get; set; }


        public int BusinessTypeId { get; set; }
        public string? BusinessTypeName { get; set; }




        //public int UserRoleId { get; set; }
        public string? RoleName { get; set; }


        public bool Permitted { get; set; }

        //public bool IsCreatePermission { get; set; }
        //public bool IsUpdatePermission { get; set; }
        //public bool IsDeletePermission { get; set; }



    }



    public class UserWarehouseView
    {
        public int Id { get; set; }
        public int WarehouseId { get; set; }

        public string? WarehouseName { get; set; }

        public string? ParentWarehouse { get; set; }

        public int LuserIdAllow { get; set; }
        public string? UserName { get; set; }

        public bool Permitted { get; set; }
    }



    public class UserAccountHeadView
    {
        public int Id { get; set; }
        public int AccId { get; set; }

        public string? AccName { get; set; }

        public string? ParentAccName { get; set; }

        public int LuserIdAllow { get; set; }
        public string? UserName { get; set; }

        public bool Permitted { get; set; }
    }

    [Table("CostCalculated")]

    public class CostCalculatedModel : BaseModel
    {


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


        //[Display(Name = "Sales Exchange")]
        //public virtual SalesReturnModel? SalesExchange { get; set; }
        [Display(Name = "Sales Exchange")]
        [ForeignKey("SalesExchange")]
        public int? SalesExchangeId { get; set; }


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


        //[Display(Name = "Transfer In")]
        //public virtual InternalTransferModel? TransferIn { get; set; }
        //[Display(Name = "Transfer In")]
        //[ForeignKey("TransferIn")]
        //public int? TransferInId { get; set; }



        [Display(Name = "Internal Transfer")]
        public virtual InternalTransferModel? InternalTransfer { get; set; }
        [Display(Name = "Internal Transfer")]
        [ForeignKey("InternalTransfer")]
        public int? InternalTransferId { get; set; }


        public bool IsTransferIn { get; set; }
        public bool IsTransferOut { get; set; }



        [Display(Name = "Product")]
        public virtual ProductModel? Product { get; set; }
        [Display(Name = "Product")]
        [ForeignKey("Product")]
        public int? ProductId { get; set; }


        [Display(Name = "Warehouse")]
        public virtual WarehouseModel? Warehouse { get; set; }
        [Display(Name = "Warehouse")]
        [ForeignKey("Warehouse")]
        public int? WarehouseId { get; set; }



        //[Display(Name = "isSubStore")]
        //public bool isSubStore { get; set; }


        [Display(Name = "isManualProcess")]
        public bool isManualProcess { get; set; }

        //[DisplayFormat(DataFormatString = "{0:#,#.00}")]
        //[DataType(DataType.Currency)]
        [Display(Name = "Current Qty")]
        [Column(TypeName = "decimal(18,6)")]

        public double CurrQty { get; set; } = 0;

        [Display(Name = "Current Price")]
        [Column(TypeName = "decimal(18,5)")]

        public decimal CurrPrice { get; set; } = 0;
        [Display(Name = "Total Current Price")]
        [Column(TypeName = "decimal(18,5)")]

        public decimal TotalCurrPrice { get; set; } = 0;

        [Display(Name = "Previous Qty")]
        [Column(TypeName = "decimal(18,6)")]

        public double PrevQty { get; set; } = 0;
        [Display(Name = "Previous Price")]
        [Column(TypeName = "decimal(18,5)")]

        public decimal PrevPrice { get; set; } = 0;
        [Display(Name = "Total Previous Price")]
        [Column(TypeName = "decimal(18,5)")]

        public decimal TotalPrevPrice { get; set; } = 0;

        [Display(Name = "Calculated Price")]
        [Column(TypeName = "decimal(18,5)")]

        public double CalculatedPrice { get; set; } = 0;

        [Display(Name = "Calculated Date")]
        public DateTime CalculatedDate { get; set; }

        [StringLength(200)]
        public string? DeletedDocNo { get; set; }


    }


    public partial class DocumentList
    {
        [Key]
        [Display(Name = "Document Id")]
        public int DocumentId { get; set; }

        [Display(Name = "Document No"), StringLength(30, ErrorMessage = "Max length 30 char.")]
        public string? DocumentNo { get; set; }

        [Display(Name = "Date")]
        public string? DocumentDate { get; set; }


        [Display(Name = "Order Date")]
        public DateTime OrderDate { get; set; }

        [Display(Name = "Net Amount")]
        [Column(TypeName = "decimal(18,4)")]
        public string? NetAmount { get; set; }
        //public decimal NetAmount { get; set; }


        [Display(Name = "Remarks")]
        public string? Remarks { get; set; }

        [Display(Name = "Approve Status")]
        public string? ApproveStatus { get; set; }

        [Display(Name = "Document Type")]
        public string? DocumentType { get; set; }


        [Display(Name = "Document Status")]
        public string? DocumentStatus { get; set; }

        [Display(Name = "User Info")]
        public string? UserName { get; set; }

        public string? Location { get; set; }


        public int? CostCaclculatedId { get; set; }
        public DateTime? CreatedDate { get; set; }

        public int DocPriority { get; set; } = 0;


        [NotMapped]
        public string? UserInfo { get; set; }



    }

    [Table("AccountCategory")]
    public partial class AccountCategoryModel : SelfModel
    {

        [Display(Name = "Account Category")]
        public string? AccountCategoryName { get; set; }

        [Display(Name = "Base / Parent Category")]
        public virtual AccountCategoryModel? ParentCategory { get; set; }
        [Display(Name = "Base / Parent Category")]
        [ForeignKey("ParentCategory")]
        public int? ParentAccountCategoryId { get; set; }


        [Display(Name = "Is Active")]
        public bool IsActive { get; set; }


        [Display(Name = "Account Type")]
        public string? AccountType { get; set; }


        [Display(Name = "SLNo")]
        public int SLNo { get; set; }

        [Display(Name = "Note No")]
        public string? NoteNo { get; set; }

    }


    [Table("Country")]
    public class CountryModel : SelfModel
    {

        [Required]
        [StringLength(10, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 2)]
        [DataType(DataType.Text)]
        [Display(Name = "Country Code")]
        public string? CountryCode { get; set; }

        [Required]
        [StringLength(10, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 2)]
        [DataType(DataType.Text)]
        [Display(Name = "Dial Code")]
        public string? DialCode { get; set; }


        [Required]
        [StringLength(100, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 3)]
        [DataType(DataType.Text)]
        [Display(Name = "Country Name")]
        public string? CountryName { get; set; }

        [Required]
        [StringLength(30, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 2)]
        [DataType(DataType.Text)]
        [Display(Name = "Country Short Name")]
        public string? CountryShortName { get; set; }


        [Required]
        [StringLength(10, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 4)]
        [DataType(DataType.Text)]
        [Display(Name = "Culture Info")]
        public string? CultureInfo { get; set; }

        //[Required]
        //public int TimeZone { get; set; }

        [Required]
        [StringLength(50, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 1)]
        [Display(Name = "Currency Name")]
        public string? CurrencyName { get; set; }


        [Required]
        [StringLength(20, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 1)]
        [Display(Name = "Currency Symbol")]
        public string? CurrencySymbol { get; set; }


        [Required]
        [StringLength(20, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 2)]
        [DataType(DataType.Text)]
        [Display(Name = "Currency Short Name")]
        public string? CurrencyShortName { get; set; }


        [Required]
        [StringLength(30, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 6)]
        [DataType(DataType.Text)]
        [Display(Name = "Flag Class")]
        public string? FlagClass { get; set; }


        public bool isActive { get; set; }


        //[Display(Name = "State")]
        //public virtual ICollection<State> vStateCountry { get; set; }


    }




    //public class NavigationMenuViewModel
    //{
    //    public int Id { get; set; }


    //    public string? MenuName { get; set; }


    //    public string? MenuClass { get; set; }


    //    public string? ControllerName { get; set; }

    //    public string? ActionName { get; set; }

    //    public int? ParentId { get; set; }

    //    public string? MenuGroupName { get; set; }
    //    public string? MenuRemarks { get; set; }


    //    //public bool Permitted { get; set; }

    //    //public int DisplayOrder { get; set; }

    //    //public bool Visible { get; set; }

    //    public bool isParent { get; set; }

    //    public bool isDashboard { get; set; }
    //    public bool UserRoleId { get; set; }


    //}



}
