using Atrai.Model.Core.Entity;
using Atrai.Data.Interfaces.Base;
using Atrai.Data.Interfaces.Self;
using Atrai.Model.Core.ViewModel;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;


namespace Atrai.Data.Interfaces
{
    public interface IUserAccountRepository : ISelfRepository<UserAccountModel>
    {
        bool ValidateUser(LoginViewModel user);

        UserAccountModel ValidateUserForApi(string email, string password);

        int GetUserId(LoginViewModel user);
        int GetComId(LoginViewModel user);

        IEnumerable<SelectListItem> UserAccountForDropdown();
        IEnumerable<SelectListItem> GetAllForDropDown();
        IEnumerable<SelectListItem> GetAllForDropDownWithoutBase();
        IEnumerable<SelectListItem> GetAllByBaseCompanyForDropDownWithoutBase();

        IEnumerable<SelectListItem> GetAllUserForDropDownNoComId();

        IEnumerable<SelectListItem> GetAllUserForDropDownBaseComId();


        IEnumerable<SelectListItem> CurrentUserAccountForDropdown();




    }

    public interface IUserRoleRepository : ISelfRepository<UserRoleModel>
    {
        IEnumerable<SelectListItem> GetAllForDropDown();

        IEnumerable<SelectListItem> GetAllForDropDownWithCondition(int? BusinessTypeId, int? ComId);

    }

    public interface IUserLogingInfoRepository : IBaseRepository<UserLogingInfoModel>
    {

    }


    public interface IUserTransactionLogRepository : IBaseRepository<UserTransactionLogModel>
    {

    }


    public interface ICreditBalanceRepository : ISelfRepository<CreditBalanceModel>
    {

    }

    public interface IWalletRepository : ISelfRepository<WalletModel>
    {

    }


    public interface ICreditUsedRepository : IBaseRepository<CreditUsedModel>
    {

    }

    public interface ITransactionRepository : IBaseRepository<TransactionModel>
    {
    }
    public interface ITransactionDetailsRepository : IBaseRepository<TransactionDetailsModel>
    {
    }
    
    public interface IAuditLogRepository : IBaseRepository<AuditLogModel>
    {
    }
}
