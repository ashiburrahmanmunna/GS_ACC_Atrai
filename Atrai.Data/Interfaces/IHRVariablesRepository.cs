using Atrai.Model.Core.Entity;
using Atrai.Data.Interfaces.Base;
using Atrai.Data.Interfaces.Self;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;

namespace Atrai.Data.Interfaces
{

    public interface IGradeRepository : IBaseRepository<Cat_GradeModel>
    {
        IEnumerable<SelectListItem> GetAllForDropDown();
    }


    public interface ISectionRepository : IBaseRepository<Cat_SectionModel>
    {
        IEnumerable<SelectListItem> GetAllForDropDown();
    }

    public interface ISubSectionRepository : IBaseRepository<Cat_SubSectionModel>
    {
        IEnumerable<SelectListItem> GetAllForDropDown();
    }


    public interface IDepartmentRepository : IBaseRepository<Cat_DepartmentModel>
    {
        IEnumerable<SelectListItem> GetAllForDropDown();
    }

    public interface IEmployeeTypeRepository : ISelfRepository<Cat_EmployeeTypeModel>
    {
        IEnumerable<SelectListItem> GetAllForDropDown();
    }

    public interface ISalaryTypeRepository : ISelfRepository<Cat_SalaryTypeModel>
    {
        IEnumerable<SelectListItem> GetAllForDropDown();
    }

    public interface IWeekSegmentRepository : ISelfRepository<Cat_WeekSegmentModel>
    {
        IEnumerable<SelectListItem> GetAllForDropDown();
    }

    public interface IBloodGroupRepository : ISelfRepository<Cat_BloodGroupModel>
    {
        IEnumerable<SelectListItem> GetAllForDropDown();
    }


    public interface IShiftRepository : IBaseRepository<Cat_ShiftModel>
    {
        IEnumerable<SelectListItem> GetAllForDropDown();
    }


    public interface IEmployeeSalaryMasterRepository : IBaseRepository<EmployeeSalaryMasterModel>
    {
        IEnumerable<SelectListItem> GetAllForDropDown();
    }


    public interface IEmployeeSalaryDetailsRepository : IBaseRepository<EmployeeSalaryDetailsModel>
    {
        IEnumerable<SelectListItem> GetAllForDropDown();
    }

    public interface IEmpTypeRepository : ISelfRepository<Cat_EmployeeTypeModel>
    {
        IEnumerable<SelectListItem> GetAllForDropDown();
    }

    public interface IDistrictRepository : IBaseRepository<Cat_DistrictModel>
    {
        IEnumerable<SelectListItem> GetAllForDropDown();
    }

    public interface IPoliceStationRepository : ISelfRepository<Cat_PoliceStationModel>
    {
        IEnumerable<SelectListItem> GetAllForDropDown();
    }



    public interface IPostOfficeRepository : ISelfRepository<Cat_PostOfficeModel>
    {
        IEnumerable<SelectListItem> GetAllForDropDown();
    }



    public interface IGenderRepository : ISelfRepository<Cat_GenderModel>
    {
        IEnumerable<SelectListItem> GetAllForDropDown();
    }


    public interface IFloorRepository : IBaseRepository<Cat_FloorModel>
    {
        IEnumerable<SelectListItem> GetAllForDropDown();
    }



    public interface IBuildingTypeRepository : IBaseRepository<Cat_BuildingTypeModel>
    {
        IEnumerable<SelectListItem> GetAllForDropDown();
    }



    public interface IBankRepository : IBaseRepository<Cat_BankModel>
    {
        IEnumerable<SelectListItem> GetAllForDropDown();
    }


    public interface IBankBranchRepository : IBaseRepository<Cat_BankBranchModel>
    {
        IEnumerable<SelectListItem> GetAllForDropDown();
    }



    public interface ILineRepository : IBaseRepository<Cat_LineModel>
    {
        IEnumerable<SelectListItem> GetAllForDropDown();
    }




    public interface IReligionRepository : ISelfRepository<Cat_ReligionModel>
    {
        IEnumerable<SelectListItem> GetAllForDropDown();
    }




    public interface ISkillRepository : IBaseRepository<Cat_SkillModel>
    {
        IEnumerable<SelectListItem> GetAllForDropDown();
    }


    public interface ICatUnitRepository : IBaseRepository<Cat_UnitModel>
    {
        IEnumerable<SelectListItem> GetAllForDropDown();
    }


    public interface IHREmpInfoRepository
    {
        IEnumerable<SelectListItem> PayModeList();
        IEnumerable<SelectListItem> AccTypeList();
        IEnumerable<SelectListItem> SubSectList();
        IEnumerable<SelectListItem> PFFinalYList();
        IEnumerable<SelectListItem> PFFundTransferYList();
        IEnumerable<SelectListItem> WFFinalYList();
        IEnumerable<SelectListItem> WFFundTransferYList();
        IEnumerable<SelectListItem> GratuityFinalYList();
        IEnumerable<SelectListItem> GratuityFundTransferYList();
        IEnumerable<SelectListItem> EmpCurrPSList(EmployeeModel hrEmpInfo);
        IEnumerable<SelectListItem> EmpPerPSList(EmployeeModel hrEmpInfo);
        IEnumerable<SelectListItem> EmpCurrPOList(EmployeeModel hrEmpInfo);
        IEnumerable<SelectListItem> EmpPerPOList(EmployeeModel hrEmpInfo);

        IEnumerable<SelectListItem> EmpAccTypeList(EmployeeModel hrEmpInfo);
        IEnumerable<SelectListItem> EmpBankList(EmployeeModel hrEmpInfo);
        IEnumerable<SelectListItem> EmpBranchList(EmployeeModel hrEmpInfo);
        IEnumerable<SelectListItem> EmpPayModeList(EmployeeModel hrEmpInfo);

        IEnumerable<SelectListItem> EmpBuildingTypeList(EmployeeModel hrEmpInfo);

        List<HR_Emp_ExperienceModel> EmpExperienceDelete(string HR_Emp_Experiences);
        List<HR_Emp_EducationModel> EmpEducationDelete(string HR_Emp_Experiences);
    }


    public interface IAttendanceProcessRepository
    {
        HR_AttendanceProcess GetAttProcess(string msg);
        IEnumerable<SelectListItem> GetEmpSelectList();
        void prcInsertEmp(HR_AttendanceProcess model, string optCriteria);
        void SaveAtt(HR_AttendanceProcess model);
        void RemoveProssType(HR_AttendanceProcess model);
    }

}
