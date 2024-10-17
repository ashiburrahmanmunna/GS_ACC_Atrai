using Atrai.Model.Core.Entity;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Atrai.Model.Core.ViewModel
{
    public class SigninViewModel
    {
        [NotMapped]
        public int? Id { get; set; }

        [Required]
        [EmailAddress]
        [Display(Name = "Email")]
        [Remote("CheckExistingEmail", "Values", HttpMethod = "POST", AdditionalFields = "Id", ErrorMessage = "User already exists. Try with a different email.")]
        public string? Email { get; set; }



        [Display(Name = "Web Address")]
        public string? Web { get; set; }


        [Required]
        [StringLength(100, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 5)]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string? Password { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Confirm password")]
        [Compare("Password", ErrorMessage = "The password and confirmation password do not match.")]
        //[Compare("Password")]
        //[Required]
        public string? ConfirmPassword { get; set; }


        //[Required]
        [NotMapped]
        [Display(Name = "Compnay Name")]
        public string? CompanyName { get; set; }


        //[Required]
        [NotMapped]
        [Display(Name = "Contact Name")]
        public string? ContactName { get; set; }


        //[Required]
        [Display(Name = "Contact Designation")]
        public string? ContactDesig { get; set; }


        [Display(Name = "Compnay Short Name")]
        public string? CompanyShortName { get; set; }


        [Required]
        [NotMapped]
        [Phone]
        [Remote("CheckExistingPhone", "Values", AdditionalFields = "Id", HttpMethod = "POST", ErrorMessage = "Phone No already Used. Try with a different Phone Number.")]
        [Display(Name = "Phone no")]
        public string? PhoneNumber { get; set; }


        //[Required]
        //[Display(Name = "Business Address")]
        //public string? BusinessAddress { get; set; }


        //[Required]
        //[Display(Name = "Subscription Type")]
        //public int? SubscriptionTypeId { get; set; }



        //[NotMapped]
        //[Display(Name = "Country")]
        //public virtual CountryModel? Currency { get; set; }

        //[NotMapped]

        //[Display(Name = "Country")]
        //[ForeignKey("Currency")]
        //public int CountryId { get; set; }


        //[Display(Name = "Business Type")]
        //public virtual BusinessTypeModel BusinessType { get; set; }
        //[Display(Name = "Business Type")]
        //[ForeignKey("BusinessType")]
        //public int? BusinessTypeId { get; set; }



        //[Display(Name = "Fiscal Year")]
        //public virtual FiscalYearTypeModel FiscalYearType { get; set; }
        //[Display(Name = "Fiscal Year")]
        //[ForeignKey("FiscalYearType")]
        //public int? FiscalYearTypeId { get; set; }
    }
    public class ChangePasswordViewModel
    {
        [Required]
        //[Remote("CheckUserEmail", "Home", HttpMethod = "POST", ErrorMessage = "User Does'nt Exists.")]
        //[EmailAddress]
        [Display(Name = "Email")]

        //[Remote("CheckExistingEmail", "Values", HttpMethod = "POST", ErrorMessage = "User already exists. Try with a different email.")]
        public string? EmailOrPhone { get; set; }


        [Required]
        [StringLength(100, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 5)]
        [DataType(DataType.Password)]
        [Display(Name = "Old Password")]
        public string? OldPassword { get; set; }


        [Required]
        [StringLength(100, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 5)]
        [DataType(DataType.Password)]
        [Display(Name = "New Password")]
        public string? Password { get; set; }


        [DataType(DataType.Password)]
        [Display(Name = "Confirm password")]
        [Compare("Password", ErrorMessage = "The password and confirmation password do not match.")]
        //[Compare("Password")]
        //[Required]
        public string? ConfirmPassword { get; set; }

        public string? OTP { get; set; }


        //[Required]
        //[NotMapped]
        //[Phone]
        //[Display(Name = "Phone no")]
        //public string? PhoneNo { get; set; }

    }

    public class ForgetPasswordViewModel
    {
        [Required]
        [EmailAddress]
        [Display(Name = "Email")]
        //[Remote("CheckExistingEmail", "Values", HttpMethod = "POST", ErrorMessage = "User already exists. Try with a different email.")]
        public string? EmailOrPhone { get; set; }


        //[Required]
        //[NotMapped]
        //[Phone]
        //[Display(Name = "Phone no")]
        //public string? PhoneNo { get; set; }

    }


    public class ForgetPasswordOTPViewModel
    {
        [Required]
        [EmailAddress]
        [Display(Name = "Email")]
        [Remote("CheckExistingEmail", "Values", HttpMethod = "POST", ErrorMessage = "User already exists. Try with a different email.")]
        public string? Email { get; set; }


        [Required]
        [NotMapped]
        [Phone]
        [Display(Name = "Phone no")]
        [Remote("CheckExistingEmail", "Values", HttpMethod = "POST", ErrorMessage = "User already exists. Try with a different email.")]

        public string? PhoneNo { get; set; }

        [Required]
        [NotMapped]
        [Display(Name = "OTP")]
        [Remote("CheckOTP", "Values", HttpMethod = "POST", ErrorMessage = "User already exists. Try with a different email.")]

        public string? OTP { get; set; }

    }


    public class OTPSetViewModel
    {
        [Required]
        //[EmailAddress]
        [Display(Name = "Email")]
        //[Remote("CheckExistingEmail", "Values", HttpMethod = "POST", ErrorMessage = "User already exists. Try with a different email.")]
        public string? EmailOrPhone { get; set; }

        [Required]
        [NotMapped]
        [Display(Name = "OTP")]
        [Remote("CheckOTP", "Values", HttpMethod = "POST", ErrorMessage = "OTP Not Matched. Try with a different email.")]
        public string? OTP { get; set; }

    }
}
