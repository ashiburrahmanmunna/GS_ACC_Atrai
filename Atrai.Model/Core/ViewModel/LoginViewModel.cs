//using Atrai.Services;
using Atrai.Model.Core.Entity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Atrai.Model.Core.ViewModel
{
    public class LoginViewModel
    {
        [Required]
        [Remote("CheckUserEmail", "Home", HttpMethod = "POST", ErrorMessage = "User Does'nt Exists.")]
        public string? Email { get; set; }
        [Required]
        public string? Password { get; set; }

        public string? EmpImagePath { get; set; }

        public string? CredentialType { get; set; }
        public string? ReturnUrl { get; set;}

    }

    public class CustomerLoginViewModel
    {
        [Required]
        [Phone]
        public string? PhoneNo { get; set; }
        [Required]
        public string? Password { get; set; }

        public string? EmpImagePath { get; set; }

    }


    public class SupplierLoginViewModel
    {
        [Required]
        [Phone]
        public string? PhoneNo { get; set; }
        [Required]
        public string? Password { get; set; }

        public string? EmpImagePath { get; set; }

    }
    public class ChitraLogin
    {
        [Required(ErrorMessage = "Please enter username or email")]
        public string? Username { get; set; }
    }
    public class ChitraPassword
    {
        [Required(ErrorMessage = "Please enter Password")]
        public string? Password { get; set; }
        public string? Username { get; set; }
    }
    public class TokenResult
    {

        public string? access_token { get; set; } = string.Empty;
        public string? accessToken { get; set; } = string.Empty;

        public DateTime Expair { get; set; }

        public string? Refresh_token { get; set; } = string.Empty;
        public string? token_type { get; set; } = string.Empty;


    }
    public class UserCompanyDto
    {
        public UserDto? UserInfo { get; set; }
        public CompanyInfoDto? CompanyInfo { get; set; }
    }
    public class UserDto
    {
        public string? Id { get; set; } = string.Empty;
        public string? Fullname { get; set; } = string.Empty;
        public string? UserName { get; set; } = string.Empty;
        public string? Email { get; set; } = string.Empty;
        public string? PhoneNumber { get; set; } = string.Empty;

    }
    public class CompanyInfoDto
    {
        public string? Id { get; set; } = string.Empty;
        public string? Name { get; set; } = string.Empty;
        public string? AddresLineOne { get; set; }
        public string? AddresLinetwo { get; set; }
        public string? City { get; set; }
        public string? State { get; set; }
        public string? ZipOrPostalCode { get; set; }
        public string? PhoneNumber { get; set; }
        public string? TeachnicalContactEmail { get; set; }
        public string? TradeLicenseNo { get; set; }
    }
    public class UserCreateDto
    {
        public string? Id { get; set; } = string.Empty;
        [Required]
        public string? Fullname { get; set; } = string.Empty;
        [Remote("UserNameIsExist", "Auth", ErrorMessage = "UserName Already Exist")]
        public string? UserName { get; set; } = string.Empty;
        [Required]
        //[Remote("EmailIsExist", "Auth", ErrorMessage = "Email Already Exist")]
        [Remote("CheckExistingEmail", "Values", HttpMethod = "POST", AdditionalFields = "Id", ErrorMessage = "User already exists. Try with a different email.")]
        public string? Email { get; set; } = string.Empty;
        public string? PhoneNumber { get; set; } = string.Empty;
        [Required]
        public string? Password { get; set; } = string.Empty;
     


        [Display(Name = "User Role")]
        public virtual UserRoleModel? UserRole { get; set; }
        [Display(Name = "User Role")]
        [ForeignKey("UserRole")]
        public int? UserRoleId { get; set; }

        public bool IsBaseUser { get; set; }

        [Display(Name = "Employee Info")]
        public virtual EmployeeModel? EmployeeList { get; set; }
        [Display(Name = "Employee Info")]
        [ForeignKey("EmployeeList")]
        public int? EmployeeId { get; set; }

        [Display(Name = "IsEmailVerified")]
        public bool IsEmailVerified { get; set; }

        [Display(Name = "IsMobileVerified")]
        public bool IsPhoneVerified { get; set; }

        [Column(TypeName = "VARCHAR")]
        [StringLength(6, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 0)]
        public string? OTP { get; set; }

    }
    public class UserCompanyIDDto
    {
        public string? CompanyId { get; set; }
        public string? UserId { get; set; }

    }

}
