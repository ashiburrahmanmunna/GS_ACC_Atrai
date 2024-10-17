using Atrai.Data.Interfaces;
using Atrai.Model.Core.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System;
using System.ComponentModel.DataAnnotations;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Text.RegularExpressions;

namespace Atrai.Services
{
    public interface IUserService
    {
        public UserAccountModel Authenticate(string UserName, string Password, int? ComId);
        public UserAccountModel GetUser(int UserId, int? ComId);
    }

    public class UserService : IUserService
    {
        ////private GTRSystemContext systemContext;
        private readonly IUserAccountRepository _userAccountRepository;

        public UserService(IUserAccountRepository userAccountRepository)
        {
            _userAccountRepository = userAccountRepository;
        }
        public UserAccountModel Authenticate(string email, string password, int? ComId)
        {

            var user = _userAccountRepository.ValidateUserForApi(email, password);
            //user.BaseComId = user.ComId;

            if (user == null) return null;
            //if (ComId != null)
            //{
            //    user.ComId = int.Parse(ComId.ToString());
            //}
            if (ComId == null)
            {
                user.Token = generateJwtToken(user, user.ComId.ToString());
            }
            else
            {
                user.Token = generateJwtToken(user, ComId.ToString());

            }

            return user;
        }
        public UserAccountModel GetUser(int UserId, int? ComId)
        {
            var user = _userAccountRepository.All(false).Include(x => x.UserRole).Where(x => x.Id == UserId).FirstOrDefault();

            if (user == null) return null;

            if (ComId == null)
            {
                user.Token = generateJwtToken(user, user.ComId.ToString());
            }
            else
            {
                user.Token = generateJwtToken(user, ComId.ToString());

            }

            return user;
        }

        private string generateJwtToken(UserAccountModel user, string ComId)
        {
            // generate token that is valid for 7 days
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes("THIS IS THE FIRST TIME CREATE JWT TOKEN FOR GTR");
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new[] { new Claim("UserId", user.Id.ToString()), new Claim("CurrentComId", ComId.ToString()) }),
                Expires = DateTime.UtcNow.AddDays(7),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }
    }



    public class EmailPhoneValidation : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            if (value != null)
            {
                string email = value.ToString();
                if (Regex.IsMatch(email, @"[A-Za-z0-9._%+-]+@[A-Za-z0-9.-]+\.[A-Za-z]{2,4}", RegexOptions.IgnoreCase))
                {
                    return ValidationResult.Success;
                }
                else if (Regex.IsMatch(email, @"(\d*-)?\d{10}", RegexOptions.IgnoreCase))
                {
                    return ValidationResult.Success;
                }
                else
                {
                    return new ValidationResult("Invalid EmailID or Mobile Number");
                }

            }
            else
            {
                return new ValidationResult("" + validationContext.DisplayName + "is required");
            }
            //return base.IsValid(value, validationContext);
        }

    }
}
