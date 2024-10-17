using Atrai.Model.Core.Common;
using Atrai.Model.Core.Entity;
using Atrai.Data.Interfaces;
using Atrai.Data.Context.AppDataContext;
using Atrai.Data.Repository.Base;
using Atrai.Data.Repository.Self;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Data.SqlClient;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace Atrai.Data.Repository
{

    //public class AccountHeadSystemRepository : SelfRepository<AccountHeadSystemModel>, IAccountHeadSystemRepository
    //{
    //    public AccountHeadSystemRepository(InvoiceDbContext context) : base(context)
    //    {
    //    }


    //    public IEnumerable<SelectListItem> GetAccountGroupHeadForDropDown()
    //    {
    //        return All().Where(x => x.AccType == "G").Select(x => new SelectListItem
    //        {
    //            Text = x.AccName + " - [ " + x.AccCode + " ]",
    //            Value = x.Id.ToString()
    //        });
    //    }

    //}


    public class GradeRepository : BaseRepository<Cat_GradeModel>, IGradeRepository
    {
        public GradeRepository(InvoiceDbContext context) : base(context)
        {
        }
        public IEnumerable<SelectListItem> GetAllForDropDown()
        {
            return All().Where(x => !x.IsDelete).Select(x => new SelectListItem
            {
                Text = x.GradeName,
                Value = x.Id.ToString()
            });
        }
    }

    public class SubSectionRepository : BaseRepository<Cat_SubSectionModel>, ISubSectionRepository
    {
        public SubSectionRepository(InvoiceDbContext context) : base(context)
        {
        }
        public IEnumerable<SelectListItem> GetAllForDropDown()
        {
            return All().Select(x => new SelectListItem
            {
                Text = x.SubSectName,
                Value = x.Id.ToString()
            });
        }
    }
    public class SectionRepository : BaseRepository<Cat_SectionModel>, ISectionRepository
    {
        public SectionRepository(InvoiceDbContext context) : base(context)
        {
        }
        public IEnumerable<SelectListItem> GetAllForDropDown()
        {
            return All().Select(x => new SelectListItem
            {
                Text = x.SectName,
                Value = x.Id.ToString()
            });
        }
    }
    public class DepartmentRepository : BaseRepository<Cat_DepartmentModel>, IDepartmentRepository
    {
        public DepartmentRepository(InvoiceDbContext context) : base(context)
        {
        }
        public IEnumerable<SelectListItem> GetAllForDropDown()
        {
            return All().Select(x => new SelectListItem
            {
                Text = x.DeptName,
                Value = x.Id.ToString()
            });
        }
    }

    public class EmployeeTypeRepository : SelfRepository<Cat_EmployeeTypeModel>, IEmployeeTypeRepository
    {
        public EmployeeTypeRepository(InvoiceDbContext context) : base(context)
        {
        }
        public IEnumerable<SelectListItem> GetAllForDropDown()
        {
            return All().Select(x => new SelectListItem
            {
                Text = x.EmployeeType,
                Value = x.Id.ToString()
            });
        }
    }

    public class BloodGroupRepository : SelfRepository<Cat_BloodGroupModel>, IBloodGroupRepository
    {
        public BloodGroupRepository(InvoiceDbContext context) : base(context)
        {
        }
        public IEnumerable<SelectListItem> GetAllForDropDown()
        {
            return All().Select(x => new SelectListItem
            {
                Text = x.BloodName,
                Value = x.Id.ToString()
            });
        }
    }

    public class EmployeeSalaryMasterRepository : BaseRepository<EmployeeSalaryMasterModel>, IEmployeeSalaryMasterRepository
    {
        public EmployeeSalaryMasterRepository(InvoiceDbContext context) : base(context)
        {
        }
        public IEnumerable<SelectListItem> GetAllForDropDown()
        {
            //return All().Select(x => new SelectListItem
            //{
            //    Text = x.SalaryMonth.ToString("dd-MMM-yy"),
            //    Value = x.Id.ToString()
            //});

            return All()
            .GroupBy(x => x.SalaryMonth)
            .Select(g => new SelectListItem
            {
                Text = g.Key.ToString("dd-MMM-yy"),
                Value = g.Key.ToString()
            }).OrderByDescending(x => x.Value);

        }




    }

    public class EmployeeSalaryDetailsRepository : BaseRepository<EmployeeSalaryDetailsModel>, IEmployeeSalaryDetailsRepository
    {
        public EmployeeSalaryDetailsRepository(InvoiceDbContext context) : base(context)
        {
        }
        public IEnumerable<SelectListItem> GetAllForDropDown()
        {
            return All().Select(x => new SelectListItem
            {
                Text = x.SalaryDetailsRemarks,
                Value = x.Id.ToString()
            });
        }
    }

    public class ShiftRepository : BaseRepository<Cat_ShiftModel>, IShiftRepository
    {
        public ShiftRepository(InvoiceDbContext context) : base(context)
        {
        }
        public IEnumerable<SelectListItem> GetAllForDropDown()
        {
            return All().Select(x => new SelectListItem
            {
                Text = x.ShiftName,
                Value = x.Id.ToString()
            });
        }
    }


    public class EmpTypeRepository : SelfRepository<Cat_EmployeeTypeModel>, IEmpTypeRepository
    {
        public EmpTypeRepository(InvoiceDbContext context) : base(context)
        {
        }
        public IEnumerable<SelectListItem> GetAllForDropDown()
        {
            return All().Select(x => new SelectListItem
            {
                Text = x.EmployeeType,
                Value = x.Id.ToString()
            });
        }
    }






    public class SalaryTypeRepository : SelfRepository<Cat_SalaryTypeModel>, ISalaryTypeRepository
    {
        public SalaryTypeRepository(InvoiceDbContext context) : base(context)
        {
        }
        public IEnumerable<SelectListItem> GetAllForDropDown()
        {
            return All().Select(x => new SelectListItem
            {
                Text = x.SalaryType,
                Value = x.Id.ToString()
            });
        }
    }

    public class WeekSegmentRepository : SelfRepository<Cat_WeekSegmentModel>, IWeekSegmentRepository
    {
        public WeekSegmentRepository(InvoiceDbContext context) : base(context)
        {
        }
        public IEnumerable<SelectListItem> GetAllForDropDown()
        {
            return All().Select(x => new SelectListItem
            {
                Text = x.WeekName,
                Value = x.Id.ToString()
            });
        }
    }

    public class DisctrictRepository : BaseRepository<Cat_DistrictModel>, IDistrictRepository
    {
        public DisctrictRepository(InvoiceDbContext context) : base(context)
        {
        }
        public IEnumerable<SelectListItem> GetAllForDropDown()
        {
            return All().Select(x => new SelectListItem
            {
                Text = x.DistName,
                Value = x.Id.ToString()
            });
        }
    }





    public class PoliceStationRepository : SelfRepository<Cat_PoliceStationModel>, IPoliceStationRepository
    {
        public PoliceStationRepository(InvoiceDbContext context) : base(context)
        {
        }
        public IEnumerable<SelectListItem> GetAllForDropDown()
        {
            return All().Select(x => new SelectListItem
            {
                Text = x.PStationName,
                Value = x.Id.ToString()
            });
        }
    }


    public class PostOfficeRepository : SelfRepository<Cat_PostOfficeModel>, IPostOfficeRepository
    {
        public PostOfficeRepository(InvoiceDbContext context) : base(context)
        {
        }
        public IEnumerable<SelectListItem> GetAllForDropDown()
        {
            return All().Select(x => new SelectListItem
            {
                Text = x.POName,
                Value = x.Id.ToString()
            });
        }
    }



    public class GenderRepository : SelfRepository<Cat_GenderModel>, IGenderRepository
    {
        public GenderRepository(InvoiceDbContext context) : base(context)
        {
        }
        public IEnumerable<SelectListItem> GetAllForDropDown()
        {
            return All().Select(x => new SelectListItem
            {
                Text = x.GenderName,
                Value = x.Id.ToString()
            });
        }
    }


    public class FloorRepository : BaseRepository<Cat_FloorModel>, IFloorRepository
    {
        public FloorRepository(InvoiceDbContext context) : base(context)
        {
        }
        public IEnumerable<SelectListItem> GetAllForDropDown()
        {
            return All().Select(x => new SelectListItem
            {
                Text = x.FloorName,
                Value = x.Id.ToString()
            });
        }
    }





    public class BuildingTypeRepository : BaseRepository<Cat_BuildingTypeModel>, IBuildingTypeRepository
    {
        public BuildingTypeRepository(InvoiceDbContext context) : base(context)
        {
        }
        public IEnumerable<SelectListItem> GetAllForDropDown()
        {
            return All().Select(x => new SelectListItem
            {
                Text = x.BuildingName,
                Value = x.Id.ToString()
            });
        }
    }





    public class BankRepository : BaseRepository<Cat_BankModel>, IBankRepository
    {
        public BankRepository(InvoiceDbContext context) : base(context)
        {
        }
        public IEnumerable<SelectListItem> GetAllForDropDown()
        {
            return All().Select(x => new SelectListItem
            {
                Text = x.BankName,
                Value = x.Id.ToString()
            });
        }
    }





    public class BankBranchRepository : BaseRepository<Cat_BankBranchModel>, IBankBranchRepository
    {
        public BankBranchRepository(InvoiceDbContext context) : base(context)
        {
        }
        public IEnumerable<SelectListItem> GetAllForDropDown()
        {
            return All().Select(x => new SelectListItem
            {
                Text = x.BranchName,
                Value = x.Id.ToString()
            });
        }
    }



    public class LineRepository : BaseRepository<Cat_LineModel>, ILineRepository
    {
        public LineRepository(InvoiceDbContext context) : base(context)
        {
        }
        public IEnumerable<SelectListItem> GetAllForDropDown()
        {
            return All().Select(x => new SelectListItem
            {
                Text = x.LineName,
                Value = x.Id.ToString()
            });
        }
    }



    public class ReligionRepository : SelfRepository<Cat_ReligionModel>, IReligionRepository
    {
        public ReligionRepository(InvoiceDbContext context) : base(context)
        {
        }
        public IEnumerable<SelectListItem> GetAllForDropDown()
        {
            return All().Select(x => new SelectListItem
            {
                Text = x.ReligionName,
                Value = x.Id.ToString()
            });
        }
    }




    public class SkillRepository : BaseRepository<Cat_SkillModel>, ISkillRepository
    {
        public SkillRepository(InvoiceDbContext context) : base(context)
        {
        }
        public IEnumerable<SelectListItem> GetAllForDropDown()
        {
            return All().Select(x => new SelectListItem
            {
                Text = x.SkillName,
                Value = x.Id.ToString()
            });
        }
    }


    public class CatUnitRepository : BaseRepository<Cat_UnitModel>, ICatUnitRepository
    {
        public CatUnitRepository(InvoiceDbContext context) : base(context)
        {
        }
        public IEnumerable<SelectListItem> GetAllForDropDown()
        {
            return All().Select(x => new SelectListItem
            {
                Text = x.UnitName,
                Value = x.Id.ToString()
            });
        }
    }



    public class HREmpInfoListRepository : IHREmpInfoRepository
    {
        private readonly InvoiceDbContext db;
        private readonly IHttpContextAccessor _httpContext;
        public HREmpInfoListRepository(InvoiceDbContext context, IHttpContextAccessor httpContext)
        {
            db = context;
            _httpContext = httpContext;
        }
        public IEnumerable<SelectListItem> AccTypeList()
        {
            return new SelectList(db.Cat_AccountType, "AccTypeId", "AccTypeName");
        }

        public IEnumerable<SelectListItem> EmpAccTypeList(EmployeeModel hrEmpInfo)
        {
            return new SelectList(db.Cat_AccountType, "AccTypeId", "AccTypeName", hrEmpInfo.HR_Emp_BankInfo.AccTypeId);
        }

        public IEnumerable<SelectListItem> EmpBankList(EmployeeModel hrEmpInfo)
        {
            return new SelectList(db.Cat_Bank, "BankId", "BankName", hrEmpInfo.HR_Emp_BankInfo.BankId);
        }

        public IEnumerable<SelectListItem> EmpBranchList(EmployeeModel hrEmpInfo)
        {
            return new SelectList(db.Cat_BankBranch, "BranchId", "BranchName", hrEmpInfo.HR_Emp_BankInfo.BranchId);
        }

        public IEnumerable<SelectListItem> EmpBuildingTypeList(EmployeeModel hrEmpInfo)
        {
            return new SelectList(db.Cat_BuildingType, "BId", "BuildingName", hrEmpInfo.HR_Emp_PersonalInfo.BId);
        }

        public IEnumerable<SelectListItem> EmpCurrPOList(EmployeeModel hrEmpInfo)
        {
            return new SelectList(db.Cat_PostOffice
                    .Where(p => p.PStationId == hrEmpInfo.HR_Emp_Address.EmpCurrPSId), "POId", "POName", hrEmpInfo.HR_Emp_Address.EmpCurrPOId);
        }

        public IEnumerable<SelectListItem> EmpCurrPSList(EmployeeModel hrEmpInfo)
        {
            return new SelectList(db.Cat_PoliceStation
                     .Where(p => p.DistId == hrEmpInfo.HR_Emp_Address.EmpCurrDistId), "PStationId", "PStationName", hrEmpInfo.HR_Emp_Address.EmpCurrPSId);
        }

        public List<HR_Emp_EducationModel> EmpEducationDelete(string HR_Emp_Educations)
        {
            var JObject = new JObject();
            var data = JObject.Parse(HR_Emp_Educations);
            string objct = data["HR_Emp_Educations"].ToString();
            var emp_Educations = JsonConvert.DeserializeObject<List<HR_Emp_EducationModel>>(objct);

            if (emp_Educations.Count < 1)
            {
                var odlData = db.HR_Emp_Education.Where(e => e.EmpId == _httpContext.HttpContext.Session.GetInt32("empid")).ToList();
                db.RemoveRange(odlData);
            }
            else
            {
                var odlData = db.HR_Emp_Education.Where(e => e.EmpId == emp_Educations.FirstOrDefault().EmpId).ToList();
                db.RemoveRange(odlData);
                db.AddRange(emp_Educations);
            }

            db.SaveChanges();
            return emp_Educations;
        }

        public List<HR_Emp_ExperienceModel> EmpExperienceDelete(string HR_Emp_Experiences)
        {
            var JObject = new JObject();
            var data = JObject.Parse(HR_Emp_Experiences);
            string objct = data["HR_Emp_Experiences"].ToString();
            var emp_Experiences = JsonConvert.DeserializeObject<List<HR_Emp_ExperienceModel>>(objct);

            if (emp_Experiences.Count < 1)
            {
                var odlData = db.HR_Emp_Experience.Where(e => e.EmpId == _httpContext.HttpContext.Session.GetInt32("empid")).ToList();
                db.RemoveRange(odlData);
            }
            else
            {
                var odlData = db.HR_Emp_Experience.Where(e => e.EmpId == emp_Experiences.FirstOrDefault().EmpId).ToList();
                db.RemoveRange(odlData);
                db.AddRange(emp_Experiences);
            }

            db.SaveChanges();
            return emp_Experiences;
        }

        public IEnumerable<SelectListItem> EmpPayModeList(EmployeeModel hrEmpInfo)
        {
            return new SelectList(db.Cat_PayMode, "PayModeId", "PayModeName", hrEmpInfo.HR_Emp_BankInfo.PayModeId);
        }

        public IEnumerable<SelectListItem> EmpPerPOList(EmployeeModel hrEmpInfo)
        {
            return new SelectList(db.Cat_PostOffice
                    .Where(p => p.PStationId == hrEmpInfo.HR_Emp_Address.EmpPerPSId), "POId", "POName", hrEmpInfo.HR_Emp_Address.EmpPerPOId);
        }

        public IEnumerable<SelectListItem> EmpPerPSList(EmployeeModel hrEmpInfo)
        {
            return new SelectList(db.Cat_PoliceStation
                    .Where(p => p.DistId == hrEmpInfo.HR_Emp_Address.EmpPerDistId), "PStationId", "PStationName", hrEmpInfo.HR_Emp_Address.EmpPerPSId);
        }



        public IEnumerable<SelectListItem> GratuityFinalYList()
        {
            var comid = _httpContext.HttpContext.Session.GetInt32("ComId");
            var year = db.Acc_FiscalYear.Where(f => f.ComId == comid)
                .Select(y => new { Id = y.Id, FYName = y.FYName });
            return new SelectList(year, "Id", "FYName");
        }

        public IEnumerable<SelectListItem> GratuityFundTransferYList()
        {
            var comid = _httpContext.HttpContext.Session.GetInt32("ComId");
            var year = db.Acc_FiscalYear.Where(f => f.ComId == comid)
                .Select(y => new { Id = y.Id, FYName = y.FYName });
            return new SelectList(year, "Id", "FYName");
        }

        public IEnumerable<SelectListItem> PayModeList()
        {
            return new SelectList(db.Cat_PayMode, "PayModeId", "PayModeName");
        }

        public IEnumerable<SelectListItem> PFFinalYList()
        {
            var comid = _httpContext.HttpContext.Session.GetInt32("ComId");
            var year = db.Acc_FiscalYear.Where(f => f.ComId == comid)
                .Select(y => new { Id = y.Id, FYName = y.FYName });
            return new SelectList(year, "Id", "FYName");
        }

        public IEnumerable<SelectListItem> PFFundTransferYList()
        {
            var comid = _httpContext.HttpContext.Session.GetInt32("ComId");
            var year = db.Acc_FiscalYear.Where(f => f.ComId == comid)
                .Select(y => new { Id = y.Id, FYName = y.FYName });
            return new SelectList(year, "Id", "FYName");
        }

        public IEnumerable<SelectListItem> SubSectList()
        {

            return new SelectList(db.Cat_SubSection, "SubSectId", "SubSectName");
        }

        public IEnumerable<SelectListItem> WFFinalYList()
        {
            var comid = _httpContext.HttpContext.Session.GetInt32("ComId");
            var year = db.Acc_FiscalYear.Where(f => f.ComId == comid)
                .Select(y => new { Id = y.Id, FYName = y.FYName });
            return new SelectList(year, "Id", "FYName");
        }

        public IEnumerable<SelectListItem> WFFundTransferYList()
        {
            var comid = _httpContext.HttpContext.Session.GetInt32("ComId");
            var year = db.Acc_FiscalYear.Where(f => f.ComId == comid)
                .Select(y => new { Id = y.Id, FYName = y.FYName });
            return new SelectList(year, "Id", "FYName");
        }
    }


    public class AttendanceProcessRepository : IAttendanceProcessRepository
    {
        DataSet dsList;
        DataSet dsDetails;
        private readonly InvoiceDbContext _context;
        private readonly IHttpContextAccessor _httpContext;
        public AttendanceProcessRepository(InvoiceDbContext context, IHttpContextAccessor httpContext)
        {
            _context = context;
            _httpContext = httpContext;
        }

        public HR_AttendanceProcess GetAttProcess(string msg)
        {
            var comid = _httpContext.HttpContext.Session.GetInt32("ComId");
            HR_AttendanceProcess model = new HR_AttendanceProcess();

            DateTime now = DateTime.Now;
            var startDate = new DateTime(now.Year, now.Month, 1);
            var endDate = startDate.AddMonths(1).AddDays(-1);
            var x = _context.HR_ProssType.OrderByDescending(p => p.ProssDt).FirstOrDefault();
            if (x != null)
            {
                model.dtLast = x.ProssDt;
            }
            else
            {
                model.dtLast = DateTime.Now;
            }


            model.dtProcess = now;
            model.dtTo = endDate;
            return model;
        }

        public IEnumerable<SelectListItem> GetEmpSelectList()
        {
            var comid = _httpContext.HttpContext.Session.GetInt32("ComId");
            return new SelectList(_context.Employee.Where(x => x.ComId == comid), "Id", "EmployeeCode");
        }



        public void prcInsertEmp(HR_AttendanceProcess model, string optCriteria)
        {
            ArrayList arQuery = new ArrayList();
            //clsProcedure clsProc = new clsProcedure();
            //clsConnectionNew clsCon = new clsConnectionNew("GTRHRIS_WEBDEMO", true);
            string SQLQuery = "", SectId = "", DesigId = "", EmpId = "", ShiftId = "", SubSectId = "", Band = "";
            var comid = _httpContext.HttpContext.Session.GetInt32("ComId");
            var userid = _httpContext.HttpContext.Session.GetInt32("UserId"); ;

            var processDate = Helper.GTRDate(model.dtProcess.ToString());
            SqlParameter[] parameter = new SqlParameter[4];
            //Collecting Parameter Value
            if (optCriteria.ToString().ToUpper() == "All".ToUpper())
            {

                //SQLQuery = "Delete tblTempCount;Insert Into tblTempCount (EmpID, DateTime1) Select EmpId,'" + Helper.GTRDate(model.dtProcess.ToString())
                //           + "' from tblEmp_Info Where ComId = " + comid + " ";
                //arQuery.Add(SQLQuery);
                parameter[0] = new SqlParameter("@ComId", comid);
                parameter[1] = new SqlParameter("@dtPross", processDate);
                parameter[2] = new SqlParameter("@optCriteria", "All");
                parameter[3] = new SqlParameter("@id", "0");// no needed for all
            }
            else if (optCriteria.ToUpper() == "Sec".ToUpper())
            {
                SectId = model.SectId.ToString();
                //SQLQuery = "Delete tblTempCount;Insert Into tblTempCount (EmpID, DateTime1) Select EmpID,'" + Helper.GTRDate(model.dtProcess.ToString())
                //           + "' from tblEmp_Info Where ComId = " + comid + " and SectId = '" + SectId + "' ";
                //arQuery.Add(SQLQuery);
                parameter[0] = new SqlParameter("@ComId", comid);
                parameter[1] = new SqlParameter("@dtPross", processDate);
                parameter[2] = new SqlParameter("@optCriteria", "Sec");
                parameter[3] = new SqlParameter("@id", SectId);
            }

            else if (optCriteria.ToUpper() == "Desig".ToUpper())
            {
                DesigId = model.DesigId.ToString();
                //SQLQuery = "Delete tblTempCount;Insert Into tblTempCount (EmpID, DateTime1) Select EmpId,'" + Helper.GTRDate(model.dtProcess.ToString())
                //           + "' from tblEmp_Info Where ComID = " + comid + " and DesigId = '" + DesigId + "'";
                //arQuery.Add(SQLQuery);               
                parameter[0] = new SqlParameter("@ComId", comid);
                parameter[1] = new SqlParameter("@dtPross", processDate);
                parameter[2] = new SqlParameter("@optCriteria", "EmpId");
                parameter[3] = new SqlParameter("@id", DesigId);
            }

            else if (optCriteria.ToUpper() == "EmpId".ToUpper())
            {
                EmpId = model.EmpId.ToString();
                //SQLQuery = "Delete tblTempCount;Insert Into tblTempCount (EmpID, DateTime1) Select EmpId,'" + Helper.GTRDate(model.dtProcess.ToString())
                //           + "' from tblEmp_Info Where ComID = " + comid + " and EmpId = '" + EmpId + "'";
                //arQuery.Add(SQLQuery);
                parameter[0] = new SqlParameter("@ComId", comid);
                parameter[1] = new SqlParameter("@dtPross", processDate);
                parameter[2] = new SqlParameter("@optCriteria", "EmpId");
                parameter[3] = new SqlParameter("@id", EmpId);
            }

            Helper.ExecProc("HR_prcSetAttData", parameter);
        }

        public void SaveAtt(HR_AttendanceProcess model)
        {
            string optSts = model.dayType;
            var comid = _httpContext.HttpContext.Session.GetInt32("ComId");
            var userid = _httpContext.HttpContext.Session.GetInt32("userid");
            HR_ProssType nPross = new HR_ProssType();
            nPross.ComId = comid.GetValueOrDefault();
            nPross.ProssDt = Convert.ToDateTime(Helper.GTRDate(model.dtProcess.ToString()));
            nPross.DaySts = optSts;
            nPross.DayStsB = optSts;
            nPross.IsLock = "0";
            _context.Add(nPross);
            _context.SaveChanges();
        }

        public void RemoveProssType(HR_AttendanceProcess model)
        {
            var comid = _httpContext.HttpContext.Session.GetInt32("ComId");
            var prossType = _context.HR_ProssType.Where(p => p.ComId == comid && p.ProssDt == Convert.ToDateTime(Helper.GTRDate(model.dtProcess.ToString()))).FirstOrDefault();
            if (prossType != null)
            {
                _context.Remove(prossType);
            }
        }
    }

}
