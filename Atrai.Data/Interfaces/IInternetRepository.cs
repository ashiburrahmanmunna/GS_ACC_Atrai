using Atrai.Model.Core.Entity;
using Atrai.Data.Interfaces.Base;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;

namespace Atrai.Data.Interfaces
{

    public interface IProductLedgerRepository : IBaseRepository<ProductLedgerModel>
    {

    }


    public interface ITestRouterOnuTrackingRepository : IBaseRepository<TestRouterOnuTrackingModel>
    {

    }

    public interface IToDoRepository : IBaseRepository<ToDoModel>
    {

    }



    public interface IActivationTicketRepository : IBaseRepository<ActivationTicketModel>
    {

    }
    public interface ITroubleTicketRepository : IBaseRepository<TroubleTicketModel>
    {

    }
    public interface ITroubleTicketCommentRepository : IBaseRepository<TroubleTicketCommentModel>
    {

    }


    public interface IInternetComplainRepository : IBaseRepository<InternetComplainModel>
    {
        IEnumerable<SelectListItem> GetAllForDropDown(bool isComId = true);
    }



    public interface IInternetDiagnosisReportRepository : IBaseRepository<DiagnosisReportModel>
    {
        IEnumerable<SelectListItem> GetAllForDropDown(bool isComId = true);
    }



    public interface IInternetPackageRepository : IBaseRepository<InternetPackageModel>
    {
        IEnumerable<SelectListItem> GetAllForDropDown(bool isComId = true);
    }


    public interface IInternetUserRepository : IBaseRepository<InternetUserModel>
    {
        IEnumerable<SelectListItem> GetAllForDropDown();
    }

    public interface IUserTerminateRepository : IBaseRepository<UserTerminateModel>
    {

    }

    public interface IInternetUserStatusRepository : IBaseRepository<InternetUserStatusModel>
    {
        IEnumerable<SelectListItem> GetAllForDropDown();
    }

}
