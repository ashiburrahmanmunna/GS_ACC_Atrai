using Atrai.Model.Core.Entity.Base;
using Atrai.Model.Core.Entity.Self;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Atrai.Model.Core.Entity
{
    [Table("UserAccount")]
    //public class UserAccountModel : BaseModel
    public class UserAccountModel : SelfModel
    {
        public string? UniqueUserId { get; set; }

        [EmailAddress(ErrorMessage = "Invalid Email Address")]
        [Required(ErrorMessage = "You must provide a Email Address")]
        [StringLength(100)]
        [Remote("CheckExistingEmail", "Values", HttpMethod = "POST", AdditionalFields = "Id", ErrorMessage = "Phone No already Used. Try with a different Phone Number.")]
        [RegularExpression(@"^([A-Za-z0-9][^'!&\\#*$%^?<>()+=:;`~\[\]{}|/,₹€@ ][a-zA-z0-9-._][^!&\\#*$%^?<>()+=:;`~\[\]{}|/,₹€@ ]*\@[a-zA-Z0-9][^!&@\\#*$%^?<> ()+=':;~`.\[\]{}|/,₹€ ]*\.[a-zA-Z]{2,6})$", ErrorMessage = "Please enter a valid Email")]
        public string? Email { get; set; }




        [StringLength(50, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 0)]
        [Required(ErrorMessage = "You must provide a phone number")]
        [Display(Name = "Phone")]
        [DataType(DataType.PhoneNumber)]
        [Remote("CheckExistingPhone", "Values", HttpMethod = "POST", AdditionalFields = "Id", ErrorMessage = "Phone No already Used. Try with a different Phone Number.")]
        //[RegularExpression(@"^\(?([0-9]{3})\)?[-. ]?([0-9]{3})[-. ]?([0-9]{4})$", ErrorMessage = "Not a valid phone number")]
        public string? PhoneNumber { get; set; }



        [Required]
        //[StringLength(10)]
        [StringLength(100, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 5)]
        public string? Password { get; set; }

        //[Compare("Password")]
        //[Required]
        [NotMapped]
        public string? ConfirmPassword { get; set; }


        [Required]
        [StringLength(100)]
        public string? Name { get; set; }

        //[Required]
        //public string? Role { get; set; }


        [Display(Name = "User Role")]
        public virtual UserRoleModel? UserRole { get; set; }
        [Display(Name = "User Role")]
        [ForeignKey("UserRole")]
        public int? UserRoleId { get; set; }



        [Display(Name = "Employee Info")]
        public virtual EmployeeModel? EmployeeList { get; set; }
        [Display(Name = "Employee Info")]
        [ForeignKey("EmployeeList")]
        public int? EmployeeId { get; set; }



        [Display(Name = "IsEmailVerified")]
        public bool IsEmailVerified { get; set; }

        [Display(Name = "IsMobileVerified")]
        public bool IsPhoneVerified { get; set; }



        public bool IsBaseUser { get; set; }

        [Display(Name = "Inactive")]

        public bool IsInacitve { get; set; }


        //[JsonIgnore]
        [ForeignKey("CompanyList")]

        public int ComId { get; set; }



        [ForeignKey("UserAccountList")]
        public int? LuserId { get; set; }


        //[JsonIgnore]
        [Display(Name = "User Account")]
        public virtual UserAccountModel? UserAccountList { get; set; }



        //[JsonIgnore]
        [Display(Name = "Company")]
        public virtual CompanyModel CompanyList { get; set; }


        [NotMapped]
        public string? Token { get; set; }


        [NotMapped]
        public int BaseComId { get; set; }


        [NotMapped]
        public int CurrentComId { get; set; }

        public virtual ICollection<SubscriptionActivationModel> UserActivationList { get; set; }

        public virtual ICollection<UserLogingInfoModel> UserloginInfo { get; set; }


        public virtual ICollection<UserTransactionLogModel> UserTransaction { get; set; }


        [Column(TypeName = "VARCHAR")]
        [StringLength(6, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 0)]
        public string? OTP { get; set; }



        public virtual ICollection<WalletModel> UserWallet { get; set; }
    }
}
