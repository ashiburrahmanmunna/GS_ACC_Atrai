using Atrai.Model.Core.Entity;
using Atrai.Data.Interfaces.Base;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using static Atrai.Data.Repository.EmployeeRepository;

namespace Atrai.Data.Interfaces
{
    public interface IEmployeeRepository : IBaseRepository<EmployeeModel>
    {

        IEnumerable<SelectListItem> GetEmpInfoAllList();
        List<EmployeeModel> GetEmp();
        IQueryable<EmployeeInfo> EmpInfo();
        void EmpInfoPost(EmployeeModel hrEmpInfo, IFormFile file, IFormFile signFile);
        void EmpInfoPostElse(EmployeeModel hrEmpInfo, IFormFile file, IFormFile signFile);
        Task<EmployeeModel> EmpInfoEdit(int? id);
        List<EmployeeModel> GetEmpInfoAll();
        FileContentResult DownloadEducationFile(string file);

        IEnumerable<SelectListItem> GetAllForDropDown();
    }

    public interface ICostCalculatedRepository : IBaseRepository<CostCalculatedModel>
    {
    }

    public interface IExpireDateExtendRepository : IBaseRepository<ExpireDateExtendModel>
    {
        IEnumerable<SelectListItem> GetAllForDropDown(bool isComId = true);
    }


}
