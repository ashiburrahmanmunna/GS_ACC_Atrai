using Atrai.Model.Core.Entity.Base;
using Atrai.Model.Core.Entity.Self;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Atrai.Model.Core.Entity
{
    [Table("Company")]
    public class CompanyModel : SelfModel
    {

        //[Key]
        //[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        //[Display(Name = "Company ID")]

        //public int ComId { get; set; }
        public string? UniqueCompanyId { get; set; }

        [Display(Name = "Code")]
        [StringLength(128)]
        public string? CompanyCode { get; set; }

        [Required]
        [Display(Name = "Company Name")]
        [StringLength(200, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 4)]
        public string? CompanyName { get; set; }

        //[Required]
        [StringLength(20, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 2)]
        [Display(Name = "Short Name")]
        public string? CompanyShortName { get; set; }


        //[Required]
        [DataType(DataType.MultilineText)]
        [StringLength(300)]
        [Display(Name = "Primary Address")]
        public string? PrimaryAddress { get; set; }


        [DataType(DataType.MultilineText)]
        [StringLength(300)]
        [Display(Name = "Secoundary Address")]
        public string? SecoundaryAddress { get; set; }


        //[Display(Name = "Company Name")]
        //public string? CompanyNameBangla { get; set; }

        //[DataType(DataType.MultilineText)]
        //[Display(Name = "Secoundary Address")]
        //public string? CompanyAddressBangla { get; set; }







        //[Required]
        [StringLength(20, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 4)]
        [DataType(DataType.PhoneNumber)]
        [Display(Name = "Phone No")]
        //[RegularExpression(@"^\(?([0-9]{3})\)?[-. ]?([0-9]{3})[-. ]?([0-9]{4})$", ErrorMessage = "Not a valid phone number")]
        public string? comPhone { get; set; }




        [Required]
        [EmailAddress]
        //[StringLength(30, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 8)]
        [DataType(DataType.EmailAddress, ErrorMessage = "E-mail is not valid")]
        [Display(Name = "Email Address")]
        public string? comEmail { get; set; }



        [StringLength(50, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 5)]
        [DataType(DataType.Text)]
        [Display(Name = "Web Site")]
        public string? comWeb { get; set; }


        //[Required]
        //[Display(Name = "Country")]
        //public int CountryId { get; set; }


        //[StringLength(150, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 5)]
        [DataType(DataType.Text)]
        [Display(Name = "Contact Person")]
        [StringLength(100, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 3)]
        public string? ContPerson { get; set; }

        //[StringLength(150, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 5)]
        [DataType(DataType.Text)]
        [Display(Name = "Contact Designation")]
        [StringLength(100, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 3)]
        public string? ContDesig { get; set; }


        [Display(Name = "Inactive")]
        public bool IsInActive { get; set; }



        [Display(Name = "Subscription Type")]
        public virtual SubscriptionTypeModel SubscriptionType { get; set; }
        [Display(Name = "Subscription Type")]
        [ForeignKey("SubscriptionType")]
        public int? SubscriptionTypeId { get; set; }



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


        //[Display(Name = "Country")]
        //public virtual CountryModel? Country { get; set; }
        //[Display(Name = "Country")]
        //[ForeignKey("Country")]
        //public int CountryId { get; set; }


        //[Display(Name = "Currency")]
        //public virtual CountryModel? Currency { get; set; }
        //[Display(Name = "Currency")]
        //[ForeignKey("Currency")]
        //public int CurrencyId { get; set; }


        //[Display(Name = "Enable Multi Currency")]
        //public bool isMultiCurrency { get; set; }

        //[Display(Name = "Enable Multi Debit Credit")]
        //public bool isMultiDebitCredit { get; set; }

        //[Display(Name = "Voucher Accunt Head Distribution Expense")]
        //public bool isVoucherDistributionEntry { get; set; }

        //[Display(Name = "Voucher Cheque Details / Head Wise Cheque No")]
        //public bool isChequeDetails { get; set; }


        //[Display(Name = "Voucher No Created Types")]
        //public int? VoucherNoCreatedTypeId { get; set; }
        //[ForeignKey("VoucherNoCreatedTypeId")]
        //public virtual Acc_VoucherNoCreatedTypeModel VoucherNoCreatedTypes { get; set; }


        public virtual ICollection<StoreSettingModel> storeinfo { get; set; }




        //[Display(Name = "Enable SMS Service")]
        //public bool isSMSService { get; set; }



        //[Display(Name = "Enable Email Service")]
        //public bool isEmailSerivce { get; set; }


        //[Display(Name = "Enable Signature Field In Reporting")]
        //public bool IsSignature { get; set; }


        //newly addedd
        [Display(Name = "Legal Name")]
        [StringLength(200, ErrorMessage = "The {0} must be at least {2} characters long.")]
        public string? LegalName { get; set; }

        [Display(Name = "Business Id No")]
        [StringLength(200, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 4)]
        public string? BusinessIdNo { get; set; }

        [Display(Name = "Vat")]
        [StringLength(200, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 4)]
        public string? vat { get; set; }

        [EmailAddress]
        [DataType(DataType.EmailAddress, ErrorMessage = "E-mail is not valid")]
        [Display(Name = "Customer Facing Email Address")]
        public string? customerFacingEmail { get; set; }

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


    }


    [Table("CompanyPermission")]

    public class CompanyPermissionModel : SelfModel
    {


        [Display(Name = "User")]
        public virtual UserAccountModel? UserList { get; set; }
        [Display(Name = "User")]
        [ForeignKey("UserList")]
        public int LuserId { get; set; }



        [Display(Name = "Company")]
        public virtual CompanyModel CompanyList { get; set; }
        [Display(Name = "Company")]
        [ForeignKey("CompanyList")]
        public int ComId { get; set; }




        public bool isDefault { get; set; }
        public bool isChecked { get; set; }


    }

    [Table("LinkShare")]
    public class LinkShareModel : BaseModel
    {

        public Guid SecretKey { get; set; }
    }


    [Table("MobileImages")]

    public class BookModel : BaseModel
    {
        //public int Id { get; set; }
        [StringLength(100, MinimumLength = 5)]
        [Required(ErrorMessage = "Please enter the title of your book")]
        public string? Title { get; set; }
        //[Required(ErrorMessage = "Please enter the author name")]
        //public string? Author { get; set; }
        //[StringLength(500)]
        //public string? Description { get; set; }
        //public string? Category { get; set; }
        ////[Required(ErrorMessage = "Please choose the language of your book")]
        //public int LanguageId { get; set; }
        //public string? Language { get; set; }

        //[Required(ErrorMessage = "Please enter the total pages")]
        //[Display(Name = "Total pages of book")]
        //public int? TotalPages { get; set; }

        //[Display(Name = "Choose the cover photo of your book")]
        //[Required]
        //public IFormFile CoverPhoto { get; set; }
        //public string? CoverImageUrl { get; set; }
        [NotMapped]
        [Display(Name = "Choose the gallery images of your book")]
        [Required]
        public IFormFileCollection GalleryFiles { get; set; }


        [NotMapped]
        [Display(Name = "Choose the gallery images of your book")]
        public IFormFileCollection Filelist { get; set; }

        public List<GalleryModel> Gallery { get; set; }

        //[Display(Name = "Upload your book in pdf format")]
        //[Required]
        //public IFormFile BookPdf { get; set; }
        //public string? BookPdfUrl { get; set; }
    }


    [Table("ImagesGallery")]

    public class GalleryModel : SelfModel
    {
        //public int Id { get; set; }
        public string? Name { get; set; }
        public string? URL { get; set; }
    }

    [Table("Gallery")]

    public class Gallery
    {
        [Key]
        public string? Id { get; set; }
        [MaxLength(256)]
        public string? Title { get; set; }
        [Required]
        [MaxLength(256)]
        public string? Name { get; set; }
        [MaxLength(256)]
        public string? Tags { get; set; }
        public DateTime UploadTime { get; set; }
        public DateTime? ModifiedTime { get; set; }

        [Display(Name = "User")]
        public virtual UserAccountModel? UserList { get; set; }
        [Display(Name = "User")]
        [ForeignKey("UserList")]
        public int? LuserId { get; set; }



        [Display(Name = "Company")]
        public virtual CompanyModel CompanyList { get; set; }
        [Display(Name = "Company")]
        [ForeignKey("CompanyList")]
        public int? ComId { get; set; }
    }

    public class MediaUploadVM
    {
        public IFormFile File { get; set; }
        public string? FileName { get; set; }
    }


    public class SMTPConfigModel
    {
        public string? SenderAddress { get; set; }
        public string? SenderDisplayName { get; set; }
        public string? UserName { get; set; }
        public string? Password { get; set; }
        public string? Host { get; set; }
        public int Port { get; set; }
        public bool EnableSSL { get; set; }
        public bool UseDefaultCredentials { get; set; }
        public bool IsBodyHTML { get; set; }

    }
}
