using Atrai.Model.Core.Entity;
using Atrai.Data.Interfaces;
using Atrai.Data.Context.AppDataContext;
using Atrai.Data.Repository.Base;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace Atrai.Data.Repository
{
    public class ProductLedgerRepository : BaseRepository<ProductLedgerModel>, IProductLedgerRepository
    {
        public ProductLedgerRepository(InvoiceDbContext context) : base(context)
        {
        }

    }
    public class TestRouterOnuTrackingRepository : BaseRepository<TestRouterOnuTrackingModel>, ITestRouterOnuTrackingRepository
    {
        public TestRouterOnuTrackingRepository(InvoiceDbContext context) : base(context)
        {
        }

    }

    public class ToDoRepository : BaseRepository<ToDoModel>, IToDoRepository
    {
        public ToDoRepository(InvoiceDbContext context) : base(context)
        {
        }

    }



    public class ActivationTicketRepository : BaseRepository<ActivationTicketModel>, IActivationTicketRepository
    {
        public ActivationTicketRepository(InvoiceDbContext context) : base(context)
        {
        }

    }

    public class TroubleTicketRepository : BaseRepository<TroubleTicketModel>, ITroubleTicketRepository
    {
        public TroubleTicketRepository(InvoiceDbContext context) : base(context)
        {
        }

    }


    public class TroubleTicketCommentRepository : BaseRepository<TroubleTicketCommentModel>, ITroubleTicketCommentRepository
    {
        public TroubleTicketCommentRepository(InvoiceDbContext context) : base(context)
        {
        }

    }



    public class InternetComplainRepository : BaseRepository<InternetComplainModel>, IInternetComplainRepository
    {
        public InternetComplainRepository(InvoiceDbContext context) : base(context)
        {
        }

        public IEnumerable<SelectListItem> GetAllForDropDown(bool isComId = true)
        {
            return All(isComId).Select(x => new SelectListItem
            {
                Text = x.ComplainName,
                Value = x.Id.ToString()
            });
        }
    }



    public class InternetDiagnosisReportRepository : BaseRepository<DiagnosisReportModel>, IInternetDiagnosisReportRepository
    {
        public InternetDiagnosisReportRepository(InvoiceDbContext context) : base(context)
        {
        }

        public IEnumerable<SelectListItem> GetAllForDropDown(bool isComId = true)
        {
            return All(isComId).Select(x => new SelectListItem
            {
                Text = x.Name,
                Value = x.Id.ToString()
            });
        }

    }


    public class EmployeeRepository : BaseRepository<EmployeeModel>, IEmployeeRepository
    {
        private readonly InvoiceDbContext _context;
        private readonly IHttpContextAccessor _httpContext;
        public EmployeeRepository(InvoiceDbContext context, IHttpContextAccessor httpContext) : base(context)
        {
            _context = context;
            _httpContext = httpContext;
        }

        public IEnumerable<SelectListItem> GetAllForDropDown()
        {
            return All().Select(x => new SelectListItem
            {
                Text = x.EmployeeName + " " + x.PositionTitle + " - [ " + x.EmployeeCode + " ] ",
                Value = x.Id.ToString()
            });
        }




        public IEnumerable<SelectListItem> GetAllForDropDown(bool isComId = true)
        {
            return All(isComId).Select(x => new SelectListItem
            {
                Text = x.EmployeeName,
                Value = x.Id.ToString()
            });
        }

        public class EmployeeInfo
        {
            public int EmpId { get; set; }
            public string? EmpCode { get; set; }
            public string? EmpName { get; set; }
            public string? DesigName { get; set; }
            public string? DeptName { get; set; }
            public string? SectName { get; set; }
            public string? EmpType { get; set; }
            public DateTime? DtJoin { get; set; }
            public string? Email { get; set; }

        }



        public IQueryable<EmployeeInfo> EmpInfo()
        {
            var ComId = _httpContext.HttpContext.Session.GetInt32("ComId");
            var query = from e in _context.Employee
                        .Where(x => x.ComId == ComId
                        && x.IsInactive == false
                        && x.IsCasual == false
                        && !x.IsDelete
                        ).OrderByDescending(x => x.Id)
                        select new EmployeeInfo
                        {
                            EmpId = e.Id,
                            EmpCode = e.EmployeeCode,
                            EmpName = e.EmployeeName,
                            DesigName = e.Cat_Designation != null ? e.Cat_Designation.DesigName : "",
                            DeptName = e.Cat_Department != null ? e.Cat_Department.DeptName : "",
                            SectName = e.Cat_Section != null ? e.Cat_Section.SectName : "",
                            EmpType = e.EmployeeType != null ? e.EmployeeType.EmployeeType : "",
                            //DtJoin= e.DtJoin.HasValue ? e.DtJoin.Value.ToString("dd-MMM-yyyy") : "",
                            //DtJoin= e.DtJoin!=null ? e.DtJoin.Value.ToString("dd-MMM-yyyy") : "",
                            DtJoin = e.DtJoin,
                            Email = e.EmpEmail

                        };
            return query;
        }

        public void EmpInfoPost(EmployeeModel hrEmpInfo, IFormFile file, IFormFile signFile)
        {
            var ComId = _httpContext.HttpContext.Session.GetInt32("ComId");
            hrEmpInfo.LuserIdUpdate = _httpContext.HttpContext.Session.GetInt32("LuserId");
            hrEmpInfo.UpdateDate = DateTime.Now;
            _context.Entry(hrEmpInfo).State = EntityState.Modified;

            if (hrEmpInfo.HR_Emp_PersonalInfo.Id > 0)
            {
                hrEmpInfo.HR_Emp_PersonalInfo.ComId = ComId.GetValueOrDefault();
                _context.Entry(hrEmpInfo.HR_Emp_PersonalInfo).State = EntityState.Modified;
            }

            else
            {
                hrEmpInfo.HR_Emp_PersonalInfo.ComId = ComId.GetValueOrDefault();
                _context.Add(hrEmpInfo.HR_Emp_PersonalInfo);
            }


            if (hrEmpInfo.HR_Emp_Address.EmpAddId > 0)
            {
                hrEmpInfo.HR_Emp_Address.ComId = ComId.GetValueOrDefault();
                _context.Entry(hrEmpInfo.HR_Emp_Address).State = EntityState.Modified;
            }

            else
            {
                hrEmpInfo.HR_Emp_Address.ComId = ComId.GetValueOrDefault();
                _context.Add(hrEmpInfo.HR_Emp_Address);
            }


            if (hrEmpInfo.HR_Emp_Family.Id > 0)
            {
                hrEmpInfo.HR_Emp_Family.ComId = ComId.GetValueOrDefault();
                _context.Entry(hrEmpInfo.HR_Emp_Family).State = EntityState.Modified;

            }
            else
            {
                hrEmpInfo.HR_Emp_Family.ComId = ComId.GetValueOrDefault();
                _context.Add(hrEmpInfo.HR_Emp_Family);
            }


            if (hrEmpInfo.HR_Emp_Nominee.Id > 0)
            {
                hrEmpInfo.HR_Emp_Nominee.ComId = ComId.GetValueOrDefault();
                _context.Entry(hrEmpInfo.HR_Emp_Nominee).State = EntityState.Modified;
            }

            else
            {
                hrEmpInfo.HR_Emp_Nominee.ComId = ComId.GetValueOrDefault();
                _context.Add(hrEmpInfo.HR_Emp_Nominee);
            }


            if (hrEmpInfo.HR_Emp_BankInfo.BankId > 0)
            {
                hrEmpInfo.HR_Emp_BankInfo.ComId = ComId.GetValueOrDefault();
                _context.Entry(hrEmpInfo.HR_Emp_BankInfo).State = EntityState.Modified;
            }

            else
            {
                hrEmpInfo.HR_Emp_BankInfo.ComId = ComId.GetValueOrDefault();
                _context.Add(hrEmpInfo.HR_Emp_BankInfo);
            }


            if (hrEmpInfo.HR_Emp_Image.EmpImageId > 0)
            {
                hrEmpInfo.HR_Emp_Image.ComId = ComId.GetValueOrDefault();
                if (file != null)
                {
                    hrEmpInfo.HR_Emp_Image.EmpImage = SetImage(file);
                }
                if (signFile != null)
                {
                    hrEmpInfo.HR_Emp_Image.EmpSign = SetImage(signFile);
                }
                _context.Entry(hrEmpInfo.HR_Emp_Image).State = EntityState.Modified;
                _context.Update(hrEmpInfo.HR_Emp_Image);
                _context.SaveChanges();
            }

            else
            {
                hrEmpInfo.HR_Emp_Image.ComId = ComId.GetValueOrDefault();
                if (file != null)
                {
                    hrEmpInfo.HR_Emp_Image.EmpImage = SetImage(file);
                }
                if (signFile != null)
                {
                    hrEmpInfo.HR_Emp_Image.EmpSign = SetImage(signFile);
                }
                _context.Add(hrEmpInfo.HR_Emp_Image);
                _context.SaveChanges();
            }

            //else
            //{
            //    hrEmpInfo.HR_Emp_Image.EmpSign = hrEmpInfo.HR_Emp_Image.EmpSign;
            //    _context.Update(hrEmpInfo.HR_Emp_Image);

            //}

        }
        private byte[] SetImage(IFormFile file)
        {
            byte[] image = null;
            using (var fs = file.OpenReadStream())
            using (var ms = new MemoryStream())
            {
                fs.CopyTo(ms);
                image = ms.ToArray();
            }
            return image;
        }

        public List<EmployeeModel> GetEmp()
        {
            var ComId = _httpContext.HttpContext.Session.GetInt32("ComId");
            return _context.Employee.Where(x => x.ComId == ComId).ToList();
        }

        public IEnumerable<SelectListItem> GetEmpInfoAllList()
        {
            var ComId = _httpContext.HttpContext.Session.GetInt32("ComId");
            return new SelectList(_context.Employee.Where(x => x.ComId == ComId).ToList(), "Id", "EmployeeName");
        }

        public void EmpInfoPostElse(EmployeeModel hrEmpInfo, IFormFile file, IFormFile signFile)
        {
            var ComId = _httpContext.HttpContext.Session.GetInt32("ComId");
            hrEmpInfo.CreateDate = DateTime.Now;

            hrEmpInfo.HR_Emp_BankInfo.ComId = ComId.GetValueOrDefault();
            hrEmpInfo.HR_Emp_Address.ComId = ComId.GetValueOrDefault();
            hrEmpInfo.HR_Emp_Nominee.ComId = ComId.GetValueOrDefault();
            hrEmpInfo.HR_Emp_PersonalInfo.ComId = ComId.GetValueOrDefault();
            hrEmpInfo.HR_Emp_Family.ComId = ComId.GetValueOrDefault();


            _context.Add(hrEmpInfo.HR_Emp_BankInfo);
            _context.Add(hrEmpInfo.HR_Emp_Address);
            _context.Add(hrEmpInfo.HR_Emp_Nominee);
            _context.Add(hrEmpInfo.HR_Emp_PersonalInfo);
            _context.Add(hrEmpInfo.HR_Emp_Family);
            _context.Add(hrEmpInfo);

            if (file != null)
            {
                hrEmpInfo.HR_Emp_Image.ComId = ComId.GetValueOrDefault();
                hrEmpInfo.HR_Emp_Image.EmpImage = SetImage(file);
                _context.Add(hrEmpInfo.HR_Emp_Image);
            }
            if (signFile != null)
            {
                hrEmpInfo.HR_Emp_Image.ComId = ComId.GetValueOrDefault();
                hrEmpInfo.HR_Emp_Image.EmpSign = SetImage(signFile);
                _context.Add(hrEmpInfo.HR_Emp_Image);
            }
            else
            {
                hrEmpInfo.HR_Emp_Image.ComId = ComId.GetValueOrDefault();
                _context.Add(hrEmpInfo.HR_Emp_Image);
            }
        }

        public Task<EmployeeModel> EmpInfoEdit(int? id)
        {
            var ComId = _httpContext.HttpContext.Session.GetInt32("ComId");
            var hrEmpInfo = _context.Employee
                .Include(h => h.HR_Emp_PersonalInfo)
                .Include(h => h.Cat_Skill)
                .Include(h => h.HR_Emp_Address)
                .Include(h => h.Cat_Department)
                .Include(h => h.Cat_Designation)
                .Include(h => h.Cat_Line)
                .Include(h => h.Cat_Floor)
                .Include(h => h.Cat_Unit)
                .Include(h => h.Cat_BloodGroup)
                .Include(h => h.Cat_Grade)
                .Include(h => h.Cat_Gender)
                .Include(h => h.Cat_Religion)
                .Include(h => h.HR_Emp_Address.Cat_DistrictCurr)
                .Include(h => h.HR_Emp_Address.Cat_DistrictPer)
                .Include(h => h.HR_Emp_Address.Cat_PoliceStationCurr)
                .Include(h => h.HR_Emp_Address.Cat_PoliceStationPer)
                .Include(h => h.HR_Emp_Address.Cat_PostOfficeCurr)
                .Include(h => h.HR_Emp_Address.Cat_PostOfficePer)
                .Include(h => h.HR_Emp_Educations)
                .Include(h => h.HR_Emp_Family)
                .Include(h => h.HR_Emp_Experiences)
                .Include(h => h.HR_Emp_Image)
                .Include(h => h.HR_Emp_Nominee)
                .Include(h => h.HR_Emp_BankInfo)
                .Include(h => h.HR_Emp_BankInfo.Cat_PayMode)
                .Include(h => h.HR_Emp_BankInfo.Cat_Bank)
                .Include(h => h.HR_Emp_BankInfo.Cat_BankBranch)
                .Include(h => h.HR_Emp_BankInfo.Cat_AccountType).Where(e => e.Id == id).FirstOrDefaultAsync();
            return hrEmpInfo;
        }

        public List<EmployeeModel> GetEmpInfoAll()
        {
            var data = _context.Employee
                .Include(h => h.Cat_BloodGroup)
                .Include(h => h.Cat_Skill)
                .Include(h => h.Cat_Department)
                .Include(h => h.Cat_Designation)
                .Include(h => h.Cat_Floor)
                .Include(h => h.Cat_Grade)
                .Include(h => h.Cat_Line)
                .Include(h => h.Cat_Religion)
                .Include(h => h.Cat_Section)
                .Include(h => h.Cat_Shift)
                .Include(h => h.Cat_SubSection)
                .Include(h => h.Cat_Unit)
                .Include(h => h.Cat_Skill)
                .Include(h => h.Cat_Gender)
                .Where(x => !x.IsDelete).ToList();
            var count = data.Count;
            return data;
        }

        public FileContentResult DownloadEducationFile(string file)
        {
            string filepath = $"{Directory.GetCurrentDirectory()}{@"\wwwroot\EmpDocument\Certificates"}" + "\\" + file;

            var fileBytes = System.IO.File.ReadAllBytes(filepath);
            var response = new FileContentResult(fileBytes, "application/octet-stream")
            {
                FileDownloadName = file
            };
            return response;
        }
    }


}
