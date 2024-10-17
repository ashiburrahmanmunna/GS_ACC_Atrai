using Atrai.Model.Core.Entity;
using Atrai.Data.Interfaces;
using Atrai.Model.Core.ViewModel;
using Atrai.Data.Context.AppDataContext;
using Atrai.Data.Repository.Base;
using Atrai.Data.Repository.Self;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;
using System.Linq;


namespace Atrai.Data.Repository
{
    public class UserAccountRepository : SelfRepository<UserAccountModel>, IUserAccountRepository
    {
        private readonly IHttpContextAccessor httpcontext;

        public UserAccountRepository(InvoiceDbContext context) : base(context)
        {
            httpcontext = new HttpContextAccessor();
        }




        public IEnumerable<SelectListItem> GetAllForDropDown()
        {
            return All().Where(x => x.IsInacitve == false).ToList().Select(x => new SelectListItem
            {
                Text = x.Name + " - " + x.Email,
                Value = x.Id.ToString()
            });
        }


        public IEnumerable<SelectListItem> GetAllForDropDownWithoutBase()
        {
            return All().Where(x => x.IsBaseUser == false).Where(x => x.IsInacitve == false).ToList().Select(x => new SelectListItem
            {
                Text = x.Name + " - " + x.Email,
                Value = x.Id.ToString()
            });
        }

        public IEnumerable<SelectListItem> GetAllByBaseCompanyForDropDownWithoutBase()
        {
            return AllByBaseCompany().Where(x => x.IsBaseUser == false).Where(x => x.IsInacitve == false && x.IsDelete == false).ToList().Select(x => new SelectListItem
            {
                Text = x.Name + " - " + x.Email,
                Value = x.Id.ToString()
            });
        }

        public bool ValidateUser(LoginViewModel user)
        {
            return GetUserData().Any(x => x.Email == user.Email && x.Password == user.Password && x.IsInacitve == false);
        }


        public UserAccountModel ValidateUserForApi(string email, string password)
        {
            //if (comid == null)
            //{
            return GetUserData().Where(x => x.Email == email && x.Password == password && x.IsInacitve == false).OrderBy(x => x.Id).FirstOrDefault();
            //}
            //else
            //{
            //    return GetUserData().Where(x => x.Email == email && x.Password == password && x.IsInacitve == false).FirstOrDefault();
            //}

        }


        public int GetUserId(LoginViewModel user)
        {
            return GetUserData().Where(x => x.Email == user.Email && x.Password == user.Password).FirstOrDefault().Id;
        }
        public int GetComId(LoginViewModel user)
        {
            return GetUserData().Where(x => x.Email == user.Email && x.Password == user.Password).FirstOrDefault().ComId;
        }



        public IEnumerable<SelectListItem> UserAccountForDropdown()
        {
            var ComId = (httpcontext.HttpContext.Session.GetInt32("ComId"));           
            return All().Where(x => x.IsInacitve == false && x.ComId == ComId).ToList().Select(x => new SelectListItem
            {
                Text = x.Name + " - " + x.Email,
                Value = x.Id.ToString()
            });
        }

        public IEnumerable<SelectListItem> CurrentUserAccountForDropdown()
        {
            var sessionLuserId = (httpcontext.HttpContext.Session.GetInt32("UserId"));

            return All().Where(x => x.IsInacitve == false && x.Id == sessionLuserId).ToList().Select(x => new SelectListItem
            {
                Text = x.Name + " - " + x.Email,
                Value = x.Id.ToString()
            });
        }

        public IEnumerable<SelectListItem> GetAllUserForDropDownNoComId()
        {
            return All(false).Where(x => x.IsInacitve == false).ToList().Select(x => new SelectListItem
            {
                Text = x.Name + " - " + x.Email,
                Value = x.Id.ToString()
            });
        }


        public IEnumerable<SelectListItem> GetAllUserForDropDownBaseComId()
        {
            //var BaseComId = (httpcontext.HttpContext.Session.GetInt32("BaseComId"));

            return AllByBaseCompany().Where(x => x.IsInacitve == false).Select(x => new SelectListItem
            {
                Text = x.Name + " - " + x.Email,
                Value = x.Id.ToString()
            });
        }


        //public IEnumerable<SelectListItem> GetAllUserForDropDownComId()
        //{
        //    //var BaseComId = (httpcontext.HttpContext.Session.GetInt32("BaseComId"));

        //    return All().Where(x => x.IsInacitve == false).Select(x => new SelectListItem
        //    {
        //        Text = x.Name + " - " + x.Email,
        //        Value = x.Id.ToString()
        //    });
        //}

    }



    public class UserTransactionLogRepository : BaseRepository<UserTransactionLogModel>, IUserTransactionLogRepository
    {
        public UserTransactionLogRepository(InvoiceDbContext context) : base(context)
        {
        }

    }

    public class CreditBalanceRepository : SelfRepository<CreditBalanceModel>, ICreditBalanceRepository
    {
        public CreditBalanceRepository(InvoiceDbContext context) : base(context)
        {
        }

    }

    public class WalletRepository : SelfRepository<WalletModel>, IWalletRepository
    {
        public WalletRepository(InvoiceDbContext context) : base(context)
        {
        }

    }


    public class CreditUsedRepository : BaseRepository<CreditUsedModel>, ICreditUsedRepository
    {
        public CreditUsedRepository(InvoiceDbContext context) : base(context)
        {
        }

    }


    public class UserLogingInfoRepository : BaseRepository<UserLogingInfoModel>, IUserLogingInfoRepository
    {
        public UserLogingInfoRepository(InvoiceDbContext context) : base(context)
        {
        }

    }
    
    public class AuditLogRepository : BaseRepository<AuditLogModel>, IAuditLogRepository
    {
        public AuditLogRepository(InvoiceDbContext context) : base(context)
        {
        }

    }


    public class UserRoleRepository : SelfRepository<UserRoleModel>, IUserRoleRepository
    {
        public UserRoleRepository(InvoiceDbContext context) : base(context)
        {
        }

        public IEnumerable<SelectListItem> GetAllForDropDown()
        {
            return All().Select(x => new SelectListItem
            {
                Text = x.RoleName,
                Value = x.Id.ToString()
            });
        }


        public IEnumerable<SelectListItem> GetAllForDropDownWithCondition(int? BusinessTypeId, int? ComId)
        {
            //var UserId = HttpContext.Session.GetInt32("UserId");
            //var ComId = HttpContext.Session.GetInt32("ComId");

            if (ComId == 1)
            {

                return All().Where(x => x.BusinessType == null || x.BusinessTypeId == BusinessTypeId).Select(x => new SelectListItem
                {
                    Text = x.RoleName,
                    Value = x.Id.ToString()
                });

            }
            else
            {
                return All().Where(x => (x.BusinessType == null || x.BusinessTypeId == BusinessTypeId) && (x.Id > 1)).Select(x => new SelectListItem
                {
                    Text = x.RoleRemarks,
                    Value = x.Id.ToString()
                });
            }

        }

    }


    public class UserTerminateRepository : BaseRepository<UserTerminateModel>, IUserTerminateRepository
    {
        public UserTerminateRepository(InvoiceDbContext context) : base(context)
        {
        }

    }


    public class VGMRepository : BaseRepository<VGMModel>, IVGMRepository
    {
        public VGMRepository(InvoiceDbContext context) : base(context)
        {
        }
    }


    public class ShortLinkRepository : BaseRepository<ShortLinkModel>, IShortLinkRepository
    {
        public ShortLinkRepository(InvoiceDbContext context) : base(context)
        {
        }
    }

    public class ShortLinkHitRepository : SelfRepository<ShortLinkHitModel>, IShortLinkHitRepository
    {
        public ShortLinkHitRepository(InvoiceDbContext context) : base(context)
        {
        }
    }
}
