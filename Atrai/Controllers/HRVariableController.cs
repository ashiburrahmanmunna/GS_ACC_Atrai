using Atrai.Core.Common;
using Atrai.Data.Context.AppDataContext;
using Atrai.Data.Interfaces;
using Atrai.Model.Core.Entity;
using Atrai.Model.Core.ViewModel;
using Atrai.Services;
using DataTablesParser;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace Atrai.Controllers
{
    [Authorize]
    [OverridableAuthorize]
    public class HRVariableController : Controller
    {
        #region Common Property
        DataSet dsList;
        DataSet dsDetails;
        public TransactionLogRepository tranlog { get; }
        //private readonly ILogger<HRVariableController> _logger;
        private readonly IWebHostEnvironment _env;

        private readonly IConfiguration configuration;
        private readonly InvoiceDbContext db;
        private readonly IGradeRepository _gradeRepository;
        private readonly IShiftRepository _shiftRepository;
        private readonly IEmployeeRepository _empInfoRepository;

        private readonly IEmpTypeRepository _empTypeRepository;
        private readonly IDistrictRepository _districtRepository;
        private readonly IDepartmentRepository _departmentRepository;
        private readonly IDesignationRepository _designationRepository;
        private readonly IPoliceStationRepository _policeStationRepository;



        private readonly IPostOfficeRepository _postOfficeRepository;
        private readonly IBuildingTypeRepository _buildingTypeRepository;
        private readonly IGenderRepository _genderRepository;
        private readonly IBankRepository _bankRepository;

        private readonly IHREmpInfoRepository _hREmpInfoRepository;
        private readonly IBankBranchRepository _bankBranchRepository;


        private readonly IFloorRepository _floorRepository;
        private readonly ILineRepository _lineRepository;
        private readonly IReligionRepository _religionRepository;
        private readonly ISectionRepository _sectionRepository;


        private readonly ISubSectionRepository _subSectionRepository;
        private readonly ICatUnitRepository _cat_UnitRepository;
        private readonly ISkillRepository _skillRepository;




        private readonly IBloodGroupRepository _bloodGroupRepository;

        private readonly IAttendanceProcessRepository _attendanceProcessRepository;

        private readonly IEmployeeTypeRepository _employeeTypeRepository;

        private readonly ISalaryTypeRepository _salaryTypeRepository;

        private readonly IWeekSegmentRepository _weekSegmentRepository;

        private readonly IEmployeeSalaryMasterRepository _employeeSalaryMasterRepository;
        private readonly IEmployeeSalaryDetailsRepository _employeeSalaryDetailsRepository;








        #endregion
        #region Constructor

        public HRVariableController(InvoiceDbContext context, IConfiguration configuration, TransactionLogRepository tranlogRepository, IShiftRepository shiftRepository, IGradeRepository gradeRepository, IEmployeeRepository empInfoRepository, IBloodGroupRepository bloodGroupRepository, IEmpTypeRepository empTypeRepository, IDistrictRepository districtRepository, IDepartmentRepository departmentRepository, IDesignationRepository designationRepository, IPoliceStationRepository policeStationRepository, IBuildingTypeRepository buildingTypeRepository, IPostOfficeRepository postOfficeRepository, IGenderRepository genderRepository, IBankRepository bankRepository, IHREmpInfoRepository hREmpInfoRepository, IBankBranchRepository bankBranchRepository, IFloorRepository floorRepository, ILineRepository lineRepository, ISkillRepository skillRepository, ICatUnitRepository cat_UnitRepository, ISubSectionRepository subSectionRepository, ISectionRepository sectionRepository, IReligionRepository religionRepository, IAttendanceProcessRepository attendanceProcessRepository, IEmployeeTypeRepository employeeTypeRepository, ISalaryTypeRepository salaryTypeRepository, IWeekSegmentRepository weekSegmentRepository, IEmployeeSalaryMasterRepository employeeSalaryMasterRepository, IEmployeeSalaryDetailsRepository employeeSalaryDetailsRepository)
        {
            tranlog = tranlogRepository;
            db = context;
            this.configuration = configuration;
            _shiftRepository = shiftRepository;
            _gradeRepository = gradeRepository;
            _empInfoRepository = empInfoRepository;
            _bloodGroupRepository = bloodGroupRepository;
            _empTypeRepository = empTypeRepository;
            _districtRepository = districtRepository;
            _departmentRepository = departmentRepository;
            _designationRepository = designationRepository;
            _policeStationRepository = policeStationRepository;
            _buildingTypeRepository = buildingTypeRepository;
            _postOfficeRepository = postOfficeRepository;
            _genderRepository = genderRepository;
            _bankRepository = bankRepository;
            _hREmpInfoRepository = hREmpInfoRepository;
            _bankBranchRepository = bankBranchRepository;
            _floorRepository = floorRepository;
            _lineRepository = lineRepository;
            _skillRepository = skillRepository;
            _cat_UnitRepository = cat_UnitRepository;
            _subSectionRepository = subSectionRepository;
            _sectionRepository = sectionRepository;
            _religionRepository = religionRepository;
            _attendanceProcessRepository = attendanceProcessRepository;
            _employeeTypeRepository = employeeTypeRepository;
            _salaryTypeRepository = salaryTypeRepository;
            _weekSegmentRepository = weekSegmentRepository;
            _employeeSalaryMasterRepository = employeeSalaryMasterRepository;
            _employeeSalaryDetailsRepository = employeeSalaryDetailsRepository;
        }
        #endregion





        #region EmpSlary



        [HttpGet]
        [Authorize]
        public IActionResult EditSalarySheet(int SalarySheetId, int IsCopy = 0)
        {

            return View("SalarySheet", model: SalarySheetId);
        }


        [HttpGet]
        public ActionResult SalarySheet()
        {
            ViewBag.ActionType = "Create";
            //ViewBag.SalarySheetTypeGroupHead = _SalarySheetTypeRepository.GetAllForDropDown();
            return View();
        }


        [AllowAnonymous]
        public JsonResult EmployeeLoanAdvanceInfo(int SalarySheetId, int EmployeeId)
        {
            try
            {

                var result = "";
                var comid = HttpContext.Session.GetInt32("ComId");
                var userid = HttpContext.Session.GetInt32("UserId");
                var UrlLink = "";
                var dtFrom = DateTime.Now.Date;
                var dtTo = DateTime.Now.Date;

                if (comid == null)
                {
                    result = "Please Login first";
                }
                var quary = $"EXEC Acc_EmployeeBalance '{comid}','{EmployeeId}','{UrlLink}','{dtFrom}','{dtTo}','Employee',0,'{SalarySheetId}' ";

                SqlParameter[] parameters = new SqlParameter[8];

                parameters[0] = new SqlParameter("@ComId", comid);
                parameters[1] = new SqlParameter("@EmployeeId", EmployeeId);
                parameters[2] = new SqlParameter("@UrlLink", UrlLink);
                parameters[3] = new SqlParameter("@FromDate", dtFrom);
                parameters[4] = new SqlParameter("@ToDate", dtTo);
                parameters[5] = new SqlParameter("@LedgerFor", "Employee");
                parameters[6] = new SqlParameter("@BalanceUpdate", 0);
                parameters[7] = new SqlParameter("@SalarySheetId", SalarySheetId);

                var abc = Helper.GetDataTable("Acc_EmployeeBalance", parameters);
                //datasetabc.Tables[0].TableName = "HeadWiseDetailsList";
                //datasetabc.Tables[1].TableName = "HeadWiseDetailsList";


                //var abc = Helper.ConvertDataSetasJSON(datasetabc);

                return Json(new { Success = 1, data = abc });
                //return View(datasetabc);

            }
            catch (Exception ex)
            {
                return Json(new { success = false, values = ex.Message.ToString() });
            }
        }





        [HttpGet]
        [AllowAnonymous]
        public JsonResult GetEmployeeListData(string SalaryMonth = "", string SalaryFromDate = "", string SalaryToDate = "", string EmployeeTypeId = "", string SalaryTypeId = "", string WeekSegmentId = "", string DepartmentId = "", string SalarySheetId = "")
        {

            try
            {


                //var model = sortedDataTable.AsEnumerable().Select(row => new GetEmployeeList
                //{

                //var model = new EmployeeSalaryModel();

                //}).ToList();
                //var model = new GetEmployeeList
                //{
                //    EmpCode = "E001",
                //    Name = "John Doe",
                //    Gs = 5000,
                //    hourrate = 0.0,
                //    productiverate = 0.0,
                //    BS = 5800,
                //    Allowance = 200,
                //    Absent = 2,
                //    Absentmoney = 387,
                //    deduction = 50,
                //    OtherAllowance = 100,
                //    total = 5048
                //};

                var result = "";
                var comid = HttpContext.Session.GetInt32("ComId");
                var userid = HttpContext.Session.GetInt32("UserId");
                var UrlLink = "";

                //var dtFrom = DateTime.Now.Date;
                //var dtTo = DateTime.Now.Date;


                var dtFrom = SalaryFromDate;
                var dtTo = SalaryToDate;


                if (comid == null)
                {
                    result = "Please Login first";
                }
                var quary = $"EXEC HR_EmployeeSalary '{comid}','{DepartmentId}','{UrlLink}','{dtFrom}','{dtTo}','{SalaryMonth}','{SalaryTypeId}','{EmployeeTypeId}','{WeekSegmentId}','{SalarySheetId}' ";

                SqlParameter[] parameters = new SqlParameter[10];

                parameters[0] = new SqlParameter("@ComId", comid);
                parameters[1] = new SqlParameter("@DepartmentId", DepartmentId);
                parameters[2] = new SqlParameter("@UrlLink", UrlLink);
                parameters[3] = new SqlParameter("@FromDate", dtFrom);
                parameters[4] = new SqlParameter("@ToDate", dtTo);
                parameters[5] = new SqlParameter("@SalaryMonth", dtTo);
                parameters[6] = new SqlParameter("@SalaryType", SalaryTypeId);
                parameters[7] = new SqlParameter("@EmployeeType", EmployeeTypeId);
                parameters[8] = new SqlParameter("@WeekSegment", WeekSegmentId);
                parameters[9] = new SqlParameter("@SalarySheetId", SalarySheetId);



                //var storesummarydetails = new StoreSummaryModel();
                //storesummarydetails.CompanyList = storeSettingRepository.All().Where(x => x.ComId == comid).FirstOrDefault();

                //var abc = Helper.ExecProcMapTList<GetEmployeeList>("HR_EmployeeSalary", parameters);



                var datasetabc = new System.Data.DataSet();
                datasetabc = Helper.ExecProcMapDS("HR_EmployeeSalary", parameters);
                //datasetabc.Tables[0].TableName = "HeadWiseDetailsList";
                //datasetabc.Tables[1].TableName = "HeadWiseDetailsList";


                var abc = Helper.ConvertDataSetasJSON(datasetabc);


                //var datasetabc = new System.Data.DataSet();
                //var abc = Helper.ExecProcMapDS("HR_EmployeeSalary", parameters);


                return Json(new { Success = 1, data = abc });
                //return Json(model);

            }
            catch (Exception ex)
            {
                return Json(new { success = false, error = ex.Message });
            }
        }





        public class EmployeeList : EmployeeModel
        {
            public string? DepartmentName { get; set; }
            public string? DesignationName { get; set; }
            public string? SectionName { get; set; }


            public string? SalaryMonth { get; set; }
            public string? SalaryMonthFrom { get; set; }
            public string? SalaryMonthTo { get; set; }

            public string? DtJoinString { get; set; }
            public string? EmployeeTypeName { get; set; }




        }



        public class EmployeeSalaryList : EmployeeSalaryDetailsModel
        {

            public string? EmployeeCode { get; set; }
            public string? DepartmentName { get; set; }
            public string? DesignationName { get; set; }
            public string? SectionName { get; set; }
            public string? EmployeeName { get; set; }


            public string? SalaryMonth { get; set; }
            public string? SalaryMonthFrom { get; set; }
            public string? SalaryMonthTo { get; set; }


            public int? SalaryTypeId { get; set; }
            public int? EmployeeTypeId { get; set; }
            public int? WeekSegmentId { get; set; }

            //public double HourRate { get; set; }

            //public double ProductionRate { get; set; }



        }



        [HttpGet]
        [Authorize]
        public IActionResult DeleteSalarySheet(int SalarySheetId)
        {
            try
            {


                var model = _employeeSalaryMasterRepository.All().Where(x => x.Id == SalarySheetId && x.IsPosted == false).FirstOrDefault();
                if (model != null)
                {
                    _employeeSalaryMasterRepository.Delete(model);


                    TempData["Message"] = "Data Delete Successfully";
                    TempData["Status"] = "3";
                    tranlog.TransactionLog(RouteData.Values["controller"].ToString(), RouteData.Values["action"].ToString(), TempData["Message"].ToString(), model.Id.ToString(), "Delete", model.SalaryMonth.ToString("dd-MMM-yy"));

                    return Json(new { Success = 1, msg = "Data Delete Successfully" });

                    //return RedirectToAction("SalarySheetList");
                }
                //return RedirectToAction("SalarySheetList");
                return Json(new { Success = 0, msg = "No Data Found or Posted !!!" });
            }
            catch (Exception ex)
            {

                return Json(new { Success = 0, ex = ex });
                throw ex;


            }
        }


        [HttpPost]
        [AllowAnonymous]
        public IActionResult AddSalaryEntry(EmployeeSalaryMasterModel model)
        {
            try
            {
                var UserId = HttpContext.Session.GetInt32("UserId");
                var ComId = HttpContext.Session.GetInt32("ComId");



                var errors = ModelState.Where(x => x.Value.Errors.Any())
                .Select(x => new { x.Key, x.Value.Errors });

                if (ModelState.IsValid)
                {
                    if (model.Id > 0)
                    {

                        _employeeSalaryMasterRepository.Update(model, model.Id);


                        foreach (EmployeeSalaryDetailsModel item in model.SalaryDetailsList)
                        {

                            if (item.Id > 0)
                            {
                                if (item.IsDelete == true || item.NetAmount == 0)
                                {
                                    int z = item.Id;
                                    _employeeSalaryDetailsRepository.Delete(item);

                                }
                                else
                                {
                                    item.SalaryMasterId = model.Id;
                                    _employeeSalaryDetailsRepository.Update(item, item.Id);


                                }
                            }
                            else
                            {
                                if (item.IsDelete == true)
                                {
                                }
                                else
                                {
                                    item.SalaryMasterId = model.Id;
                                    _employeeSalaryDetailsRepository.Insert(item);


                                }
                            }
                        }





                        TempData["Message"] = "Data Update Successfully";
                        TempData["Status"] = "2";
                        tranlog.TransactionLog(RouteData.Values["controller"].ToString(), RouteData.Values["action"].ToString(), TempData["Message"].ToString(), model.Id.ToString(), "Update", model.SalaryMonth.ToString("dd-MMM-yy"));



                        return Json(new { Success = 2, Id = model.Id, message = "Date Update successfully" });
                    }
                    else
                    {

                        foreach (var item in model.SalaryDetailsList)
                        {


                            item.CreateDate = DateTime.Now;
                            item.UpdateDate = DateTime.Now;


                        }



                        _employeeSalaryMasterRepository.Insert(model);



                        TempData["Message"] = "Data Save Successfully";
                        TempData["Status"] = "1";
                        tranlog.TransactionLog(RouteData.Values["controller"].ToString(), RouteData.Values["action"].ToString(), TempData["Message"].ToString(), model.Id.ToString(), "Create", model.SalaryMonth.ToString("dd-MMM-yy"));


                        return Json(new { Success = 1, Id = model.Id, message = "Data Save successfully" });
                    }

                }
                else
                {
                    return Json(new { error = true, message = "failed to Save the Data" });
                }



            }
            catch (Exception ex)
            {
                return Json(new { error = true, message = ex.Message });
            }
        }



        public class JsGridFilter
        {
            public int? pageIndex { get; set; }
            public int? pageSize { get; set; }

        }



        public class SalarySheetFilterData
        {
            public int SalaryMasterId { get; set; }
            public string? SalaryMonth { get; set; }
            public string? SalaryMonthFrom { get; set; }
            public string? SalaryMonthTo { get; set; }
            public string? SalaryMasterRemarks { get; set; }
            public string? SalaryType { get; set; }
            public string? EmpTypeName { get; set; }
            public string? Department { get; set; }
            public string? NetAmount { get; set; }

            public int? pageIndex { get; set; }
            public int? pageSize { get; set; }

            public string? sortField { get; set; }
            public string? sortOrder { get; set; }




        }



        //[Authorize]
        [AllowAnonymous]
        public IActionResult EmployeeListJsGrid()
        {

            //string FromDate, string ToDate, int? UserList, int? Warehouse
            var comid = HttpContext.Session.GetInt32("ComId");
            var userid = HttpContext.Session.GetInt32("UserId");

            return View();

        }


        #region jsgrid connected with sql server
        ///<summary>irfan code for jsgrid connected with sql server with filtering and searching 


        [AllowAnonymous]
        public JsonResult GetEmployeeListJson(int pageIndex, int pageSize, string From, string To, string criteria, string searchquery = "")
        {
            try
            {

                if (searchquery?.Length > 1)
                {
                    //products = products.Where(x => x.Name.ToLower().Contains(searchquery.ToLower()) || x.Code.ToLower().Contains(searchquery.ToLower()));


                    var searchitem = JsonConvert.DeserializeObject<JsGridFilter>(searchquery);

                    if (searchitem.pageIndex != null)
                    {
                        pageIndex = searchitem.pageIndex.GetValueOrDefault(); // || x.Code.ToLower().Contains(searchitem.Name.ToLower())
                        pageSize = searchitem.pageSize.GetValueOrDefault(); // || x.Code.ToLower().Contains(searchitem.Name.ToLower())


                    }

                }


                var ComId = HttpContext.Session.GetInt32("ComId");
                int Offset = (pageIndex - 1) * pageSize;
                int fetch = Offset + pageSize;
                string dateString = "1950-01-01 00:00:00.0000000";
                DateTime startDate = DateTime.Parse(dateString);
                DateTime endDate = DateTime.Parse(dateString);
                DateTime dateValue1;
                DateTime dateValue2;
                if (DateTime.TryParseExact(From, new[] { "d-MMM-yyyy", "dd-MMM-yyyy" }, CultureInfo.InvariantCulture, DateTimeStyles.None, out dateValue1))
                {
                    startDate = DateTime.ParseExact(dateValue1.ToString("yyyy-MM-dd HH:mm:ss.fffffff"), "yyyy-MM-dd HH:mm:ss.fffffff", CultureInfo.InvariantCulture);
                }
                if (DateTime.TryParseExact(To, new[] { "d-MMM-yyyy", "dd-MMM-yyyy" }, CultureInfo.InvariantCulture, DateTimeStyles.None, out dateValue2))
                {
                    endDate = DateTime.ParseExact(dateValue2.ToString("yyyy-MM-dd HH:mm:ss.fffffff"), "yyyy-MM-dd HH:mm:ss.fffffff", CultureInfo.InvariantCulture);
                }

                string SearchColumns = "";
                string SearchKeywords = "";
                if (searchquery?.Length > 1)
                {

                    JObject jsonObject = JObject.Parse(searchquery);


                    foreach (JProperty property in jsonObject.Properties())
                    {
                        string columnName = property.Name;
                        string value = property.Value.ToString();

                        if (!string.IsNullOrEmpty(value))
                        {
                            SearchColumns += columnName + ",";
                            SearchKeywords += value + ",";
                        }
                    }

                    string toremove = pageIndex.ToString() + "," + pageSize.ToString() + ",";
                    string toremove1 = "pageIndex,pageSize,";
                    int lastIndex = SearchKeywords.LastIndexOf(toremove);
                    int lastIndex1 = SearchColumns.LastIndexOf(toremove1);
                    if (lastIndex1 == -1)
                    {
                        lastIndex1 = 0;
                    }
                    if (lastIndex == -1)
                    {
                        lastIndex = 0;
                    }
                    SearchKeywords = SearchKeywords.Substring(0, lastIndex) + SearchKeywords.Substring(lastIndex + toremove.Length);
                    SearchColumns = SearchColumns.Substring(0, lastIndex1) + SearchColumns.Substring(lastIndex1 + toremove1.Length);
                    SearchColumns = SearchColumns.TrimEnd(',', ' ');

                }
                //var temp = criteria;
                //criteria += "Count";
                //var totalRow = _hRRepository.EmpListIndexCount(criteria, Offset, fetch, SearchKeywords, SearchColumns, startDate, endDate).ToList();
                //decimal TotalRecordCount = totalRow[0].TotalRecord;
                //var PageCountabc = decimal.Parse((TotalRecordCount / pageSize).ToString());
                //var PageCount = Math.Ceiling(PageCountabc);


                decimal skip = (pageIndex - 1) * pageSize;
                // Get total number of records
                //int total = totalRow[0].TotalRecord;
                //var employeelist = _hRRepository.EmpListIndex(temp, Offset, fetch, SearchKeywords, SearchColumns, startDate, endDate).ToList();


                //string comid = _httpContext.HttpContext.Session.GetString("comid");
                SqlParameter[] parameter = new SqlParameter[7];
                parameter[0] = new SqlParameter("@ComId", ComId);
                parameter[1] = new SqlParameter("@pageSize", pageSize);
                parameter[2] = new SqlParameter("@pageIndex", pageIndex);
                parameter[3] = new SqlParameter("@SearchKeywords", SearchKeywords);
                parameter[4] = new SqlParameter("@SearchColumns", SearchColumns);
                parameter[5] = new SqlParameter("@FromDate", startDate);
                parameter[6] = new SqlParameter("@ToDate", endDate);

                var query = $"Exec HR_EmployeeList '{ComId}', '{pageSize}','{pageIndex}','{SearchKeywords}','{SearchColumns}','{startDate}','{endDate}'";
                var employeelist = Helper.ExecProcMapDS("HR_EmployeeList", parameter);


                //return EmployeeListData;


                decimal TotalRecordCount = (int)employeelist.Tables[0].Rows[0]["TotalRecord"];
                var PageCountabc = decimal.Parse((TotalRecordCount / pageSize).ToString());
                var PageCount = Math.Ceiling(PageCountabc);

                //var abcd = employeelist.OrderByDescending(x => x.EmpCode).Skip(int.Parse(skip.ToString())).Take(int.Parse(pageSize.ToString())).ToList();// Take(50);
                var pageinfo = new PagingInfo();
                pageinfo.PageCount = int.Parse(PageCount.ToString());
                pageinfo.PageNo = pageIndex;
                pageinfo.PageSize = int.Parse(pageSize.ToString());
                pageinfo.TotalRecordCount = int.Parse(TotalRecordCount.ToString());

                //return  abcd;
                return Json(new { Success = 1, error = false, EmployeeList = employeelist.Tables[1], PageInfo = pageinfo });


            }
            catch (Exception ex)
            {
                throw ex;
            }
        }



        //public List<EmpList> EmpListIndex(string criteria, int Offset, int fetch, string EmpCode, string EmpName, DateTime startDate, DateTime endDate)
        //{
        //    var comid = _httpContext.HttpContext.Session.GetString("comid");

        //    try
        //    {
        //        //string comid = _httpContext.HttpContext.Session.GetString("comid");
        //        SqlParameter[] parameter = new SqlParameter[8];
        //        parameter[0] = new SqlParameter("@ComId", comid);
        //        parameter[1] = new SqlParameter("@Criteria", criteria);
        //        parameter[2] = new SqlParameter("@Offset", Offset);
        //        parameter[3] = new SqlParameter("@fetch", fetch);
        //        parameter[4] = new SqlParameter("@SearchKeywords", EmpCode);
        //        parameter[5] = new SqlParameter("@SearchColumns", EmpName);
        //        parameter[6] = new SqlParameter("@startDate", startDate);
        //        parameter[7] = new SqlParameter("@endDate", endDate);

        //        //var query = $"Exec HR_PrcGetEmpInfoListTest '{comid}', '{criteria}', '{Offset}','{fetch}','{EmpCode}','{EmpName}','{startDate}','{endDate}'";
        //        List<EmpList> EmployeeListData = Helper.ExecProcMapTList<EmpList>("HR_PrcGetEmpInfoList", parameter);
        //        return EmployeeListData;
        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex;
        //    }

        //}

        /// </summary>
        #endregion






        //[AllowAnonymous]
        [Authorize]

        public IActionResult SalarySheetList()
        {

            //string FromDate, string ToDate, int? UserList, int? Warehouse
            var comid = HttpContext.Session.GetInt32("ComId");
            var userid = HttpContext.Session.GetInt32("UserId");

            return View();

        }

        [AllowAnonymous]
        public JsonResult GetSalarySheetListByPage(int? UserId, int? SalaryTypeId, int pageNo = 1, decimal pageSize = 10, string searchquery = "")
        {
            try
            {
                //var products= _context.Products.ToList();

                //var accountheadlist = _accountHeadRepository.All().Include(x => x.vAccountGroupHead).Where(x => x.IsDelete == false);//.Include(x=>x.vUnit).Include(x=>x.Category);
                var salarysheetlist = _employeeSalaryMasterRepository.All()
                    .Include(x => x.DepartmentList)
                    .Include(x => x.EmployeeType)
                    .Include(x => x.SalaryType)
                    .Where(x => x.IsDelete == false);


                if (searchquery?.Length > 1)
                {
                    //products = products.Where(x => x.Name.ToLower().Contains(searchquery.ToLower()) || x.Code.ToLower().Contains(searchquery.ToLower()));


                    var searchitem = JsonConvert.DeserializeObject<SalarySheetFilterData>(searchquery);

                    if (searchitem.pageIndex != null)
                    {
                        pageNo = searchitem.pageIndex.GetValueOrDefault(); // || x.Code.ToLower().Contains(searchitem.Name.ToLower())
                        pageSize = searchitem.pageSize.GetValueOrDefault(); // || x.Code.ToLower().Contains(searchitem.Name.ToLower())


                    }



                    //if (searchitem.SalaryMonth != null)
                    //{
                    //    salarysheetlist = salarysheetlist.Where(x => x.SalaryMonth.ToString("MMM-YY").ToLower().Contains(searchitem.SalaryMonth.ToLower())); // || x.Code.ToLower().Contains(searchitem.Name.ToLower())

                    //}


                    if (searchitem.Department != "")
                    {
                        salarysheetlist = salarysheetlist.Where(x => x.DepartmentList.DeptName.ToLower().Contains(searchitem.Department.ToLower())); // || x.Code.ToLower().Contains(searchitem.Name.ToLower())

                    }

                    if (searchitem.EmpTypeName != "")
                    {
                        salarysheetlist = salarysheetlist.Where(x => x.EmployeeType.EmployeeType.ToLower().Contains(searchitem.EmpTypeName.ToLower())); // || x.Code.ToLower().Contains(searchitem.Name.ToLower())

                    }

                    if (searchitem.SalaryType != "")
                    {
                        salarysheetlist = salarysheetlist.Where(x => x.SalaryType.SalaryType.ToLower().Contains(searchitem.SalaryType.ToLower())); // || x.Code.ToLower().Contains(searchitem.Name.ToLower())

                    }

                    if (searchitem.SalaryMasterRemarks != "")
                    {
                        salarysheetlist = salarysheetlist.Where(x => x.SalaryMasterRemarks.ToLower().Contains(searchitem.SalaryMasterRemarks.ToLower())); // || x.Code.ToLower().Contains(searchitem.Name.ToLower())

                    }

                    if (searchitem.NetAmount != "")
                    {
                        salarysheetlist = salarysheetlist.Where(x => x.SalaryDetailsList.Sum(x => x.NetAmount).ToString() == searchitem.NetAmount); // || x.Code.ToLower().Contains(searchitem.Name.ToLower())

                    }


                    if (searchitem.sortOrder != null)
                    {
                        if (searchitem.sortField == "Department")
                        {
                            if (searchitem.sortOrder == "asc")
                            {
                                salarysheetlist = salarysheetlist.OrderBy(x => x.DepartmentList.DeptName);

                            }
                            else
                            {
                                salarysheetlist = salarysheetlist.OrderByDescending(x => x.DepartmentList.DeptName);

                            }

                        }


                        if (searchitem.sortField == "SalaryType")
                        {
                            if (searchitem.sortOrder == "asc")
                            {
                                salarysheetlist = salarysheetlist.OrderBy(x => x.SalaryType.SalaryType);

                            }
                            else
                            {
                                salarysheetlist = salarysheetlist.OrderByDescending(x => x.SalaryType.SalaryType);

                            }

                        }


                        if (searchitem.sortField == "EmpTypeName")
                        {
                            if (searchitem.sortOrder == "asc")
                            {
                                salarysheetlist = salarysheetlist.OrderBy(x => x.EmployeeType.EmployeeType);

                            }
                            else
                            {
                                salarysheetlist = salarysheetlist.OrderByDescending(x => x.EmployeeType.EmployeeType);

                            }

                        }


                        if (searchitem.sortField == "NetAmount")
                        {
                            if (searchitem.sortOrder == "asc")
                            {
                                salarysheetlist = salarysheetlist.OrderBy(x => x.SalaryDetailsList.Sum(x => x.NetAmount));

                            }
                            else
                            {
                                salarysheetlist = salarysheetlist.OrderByDescending(x => x.SalaryDetailsList.Sum(x => x.NetAmount));

                            }

                        }

                        if (searchitem.sortField == "SalaryMonth")
                        {
                            if (searchitem.sortOrder == "asc")
                            {
                                salarysheetlist = salarysheetlist.OrderBy(x => x.SalaryMonth);

                            }
                            else
                            {
                                salarysheetlist = salarysheetlist.OrderByDescending(x => x.SalaryMonth);

                            }

                        }


                    }
                    else
                    {
                        salarysheetlist = salarysheetlist.OrderByDescending(x => x.Id);
                    }





                }

                if (SalaryTypeId != null)
                {
                    salarysheetlist = salarysheetlist.Where(x => x.SalaryTypeId == SalaryTypeId);
                }

                //if (UserId != null)
                //{
                //    salarysheetlist = salarysheetlist.Where(x => x.LuserId == UserId);
                //}

                decimal TotalRecordCount = salarysheetlist.Count();
                var PageCountabc = decimal.Parse((TotalRecordCount / pageSize).ToString());
                var PageCount = Math.Ceiling(PageCountabc);





                decimal skip = (pageNo - 1) * pageSize;

                // Get total number of records
                int total = salarysheetlist.Count();



                var query = from e in salarysheetlist.Include(x => x.SalaryDetailsList).ThenInclude(x => x.Employee)//.Where(x => !x.SalarySheetNo.Contains("sys"))//.Where(x => x.Id > 0 && x.ComId == ComId).OrderByDescending(x => x.Id) //let vAccountGroupHead = e.vAccountGroupHead.AccName
                            select new
                            {
                                SalarySheetId = e.Id,
                                SalaryMonth = e.SalaryMonth.ToString("MMM-yy"),
                                SalaryMonthFrom = e.SalaryMonthFrom.ToString("dd-MMM-yy"),
                                SalaryMonthTo = e.SalaryMonthTo.ToString("dd-MMM-yy"),
                                SalaryMasterRemarks = e.SalaryMasterRemarks,
                                EmpTypeName = e.EmployeeType.EmployeeType,
                                SalaryType = e.SalaryType.SalaryType,
                                Department = e.DepartmentList.DeptName,
                                NetAmount = e.SalaryDetailsList.Sum(x => x.NetAmount),

                                //Status = e.isPosted != false ? "Posted" : "Not Posted",

                                SalaryDetailsList = e.SalaryDetailsList.Where(a => a.IsDelete == false)
                                .Select(a => new
                                {
                                    Id = a.Id,
                                    EmployeeCode = a.Employee.EmployeeCode,
                                    EmployeeName = a.Employee.EmployeeName,
                                    DeptName = a.Employee.DepartmentList.DeptName,
                                    NetAmount = a.NetAmount,
                                    GS = a.GS,
                                    ComId = a.ComId,
                                    SalaryDetailsRemarks = a.SalaryDetailsRemarks,
                                    a.Employee.EmployeeType.EmployeeType,

                                }),
                                CountSubData = e.SalaryDetailsList.Count()

                            };
                //.OrderByDescending(x => x.SalarySheetId)



                var abcd = query.Skip(int.Parse(skip.ToString())).Take(int.Parse(pageSize.ToString())).ToList();// Take(50);
                var pageinfo = new PagingInfo();
                pageinfo.PageCount = int.Parse(PageCount.ToString());
                pageinfo.PageNo = pageNo;
                pageinfo.PageSize = int.Parse(pageSize.ToString());
                pageinfo.TotalRecordCount = int.Parse(TotalRecordCount.ToString());

                //return  abcd;
                return Json(new { Success = 1, error = false, SalarySheetList = abcd, PageInfo = pageinfo });


            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        [AllowAnonymous]
        public ActionResult SalarySheetPrint(int? id)
        {
            string SqlCmd = "";
            string ReportPath = "";
            var ReportType = "PDF";
            var ComId = HttpContext.Session.GetInt32("ComId");


            //var abcvouchermain = _accVoucherRepository.All().Include(x => x.Acc_VoucherTypes).Where(x => x.Id == id && x.ComId == ComId).FirstOrDefault();

            var reportname = "rptSalarySheet_Fixed";// _accVoucherRepository.All().Where(x => x.VoucherId== id).Select(x => x.VoucherNo).FirstOrDefault();

            //if (abcvouchermain.Acc_VoucherTypes != null)
            //{
            //    if (abcvouchermain.Acc_VoucherTypes.VoucherTypeName.ToUpper() == "Bank Payment".ToUpper())
            //    {
            //        reportname = "rptShowVoucher_VBP";
            //    }


            //}

            HttpContext.Session.SetString("ReportPath", "~/ReportViewer/HR/" + reportname + ".rdlc");
            string filename = _employeeSalaryMasterRepository.All().Include(x => x.SalaryType).FirstOrDefault().SalaryMonth.ToString("dd-MMM-yy");// "VPC";
            //var Currency = "18";
            HttpContext.Session.SetString("ReportQuery", "Exec HR_rptSalarySheet '" + ComId + "' , " + id + "");


            //Session["ReportQuery"] = "Exec " + AppData.AppData.dbGTCommercial.ToString() + ".dbo.[rptCommercialInvoice_Export] '" + id + "','" + AppData.AppData.intComId + "'";
            //string filename = _employeeSalaryMasterRepository.All().Where(x => x.Id == id).FirstOrDefault().SalaryMasterRemarks;
            HttpContext.Session.SetString("PrintFileName", filename.Replace(".", "").Replace(" ", "").Replace(",", "").Replace("\"", ""));


            string DataSourceName = "DataSet1";
            clsReport.strReportPathMain = HttpContext.Session.GetString("ReportPath");
            clsReport.strQueryMain = HttpContext.Session.GetString("ReportQuery");
            clsReport.strDSNMain = DataSourceName;




            SqlCmd = clsReport.strQueryMain;
            ReportPath = clsReport.strReportPathMain;
            var abcd = HttpContext.Session.GetString("ReportType");

            if (abcd != null)
            {
                ReportType = abcd;

            }
            else
            {
                ReportType = "PDF";

            }

            //var jsonData = JsonConvert.SerializeObject(subReportObject);

            string callBackUrl = Url.Action("Index", "ReportViewer", new { reporttype = ReportType }); //Url.Action("Index", "ReportViewer", new { reporttype = ReportType });  //Repository.GenerateReport(ReportPath, SqlCmd, ConstrName, ReportType, jsonData);
            return Redirect(callBackUrl);

            ///return RedirectToAction("Index", "ReportViewer");


        }

        public class PagingInfo
        {
            public int PageNo { get; set; }

            public int PageSize { get; set; }

            public int PageCount { get; set; }

            public long TotalRecordCount { get; set; }

        }



        #endregion




        #region Employee Info
        public IActionResult EmployeeInfoList()
        {


            var result = "";
            var ComId = HttpContext.Session.GetInt32("ComId");
            var UserId = HttpContext.Session.GetInt32("UserId");


            var employeeid = "";
            //if (ReferanceId > 0)
            //{
            //    customerid = ReferanceId.ToString();
            //}
            string dtFrom = DateTime.Now.Date.ToString("dd-MMM-yy");
            string dtTo = DateTime.Now.Date.ToString("dd-MMM-yy");
            var Type = "Employee";


            var quary = $"Exec Acc_EmployeeBalance  '" + ComId + "','" + employeeid + "','','" + dtFrom + "' ,'" + dtTo + "','" + Type + "',1";


            SqlParameter[] parameters = new SqlParameter[7];
            parameters[0] = new SqlParameter("@ComId", ComId);
            parameters[1] = new SqlParameter("@EmployeeId", employeeid);
            parameters[2] = new SqlParameter("@UrlLink", "");
            parameters[3] = new SqlParameter("@FromDate", DateTime.Parse(dtFrom));
            parameters[4] = new SqlParameter("@ToDate", DateTime.Parse(dtTo));
            parameters[5] = new SqlParameter("@LedgerFor", Type);
            parameters[6] = new SqlParameter("@BalanceUpdate", "1");


            Helper.ExecProc("Acc_EmployeeBalance", parameters);



            TempData["Message"] = "Data Load Successfully";
            TempData["Status"] = "1";
            tranlog.TransactionLog(RouteData.Values["controller"].ToString(), RouteData.Values["action"].ToString(), TempData["Message"].ToString(), "", "List Show", "");

            //var data = _empInfoRepository.GetEmpInfoAll();
            //var gTRDBContext = db.EmployeeModel.Include(h => h.Cat_BloodGroup).Include(h => h.Cat_Department).Include(h => h.Cat_Designation).Include(h => h.Cat_Floor).Include(h => h.Cat_Grade).Include(h => h.Cat_Line).Include(h => h.Cat_Religion).Include(h => h.Cat_Section).Include(h => h.Cat_Shift).Include(h => h.Cat_SubSection).Include(h => h.Cat_Unit);
            //_empInfoRepository.GetEmpInfoAll()
            return View();


        }

        [HttpPost]
        [AllowAnonymous]
        public IActionResult GetEmployeeList()
        {
            try
            {
                var emplist = _empInfoRepository.All();
                var ComId = (HttpContext.Session.GetInt32("ComId"));

                Microsoft.Extensions.Primitives.StringValues y = "";

                var x = Request.Form.TryGetValue("search[value]", out y);


                if (y.ToString().Length > 0)
                {
                    emplist.Any(x => x.Cat_Department.DeptName.ToLower() == y.ToString().ToString());
                }
                else
                {

                    //invoicebill = invoicebill.Where(p => p.TokenDate >= dtFrom && p.TokenDate <= dtTo);

                }

                //if (y.ToString().Length > 0)
                //{

                //var query = _empInfoRepository.EmpInfo();



                var query = from e in emplist
                            .Include(x => x.Cat_Department)
                            .Include(x => x.Cat_Designation)
                            .Include(x => x.Cat_Section)


                            select new EmployeeList
                            {
                                SLNo = e.SLNo,
                                Id = e.Id,
                                EmployeeCode = e.EmployeeCode,
                                FingerId = e.FingerId,
                                EmployeeName = e.EmployeeName,
                                SectionName = e.Cat_Section.SectName,
                                DesignationName = e.DesignationList.DesigName,
                                DepartmentName = e.DepartmentList.DeptName,

                                EmpEmail = e.EmpEmail,
                                EmpPhone1 = e.EmpPhone1,
                                EmpPhone2 = e.EmpPhone2,
                                EmergencyMobileNo = e.EmergencyMobileNo,
                                MobileNo = e.MobileNo,

                                DtJoinString = e.DtJoin.GetValueOrDefault().ToString("dd-MMM-yy"),
                                EmployeeTypeName = e.EmployeeType.EmployeeType,


                                GrossSalary = e.GrossSalary,
                                EmpAdvanceBalance = e.EmpAdvanceBalance,
                                EmpLoanBalance = e.EmpLoanBalance
                            };

                var parser = new Parser<EmployeeList>(Request.Form, query);

                return Json(parser.Parse());

                //}
                //return Json("");

            }
            catch (Exception ex)
            {
                return Json(new { Success = "0", error = ex.Message });
                //throw ex;
            }

        }
        public IActionResult EmpCodeExist(string code)
        {
            var ComId = HttpContext.Session.GetInt32("ComId");
            var data = _empInfoRepository.GetEmp().Any(e => e.EmployeeCode == code && e.ComId == ComId);
            return Json(_empInfoRepository.GetEmp().Any(e => e.EmployeeCode == code && e.ComId == ComId));
        }

        public IActionResult CreateEmpInfo()
        {
            try
            {
                var ComId = HttpContext.Session.GetInt32("ComId"); ;
                ViewBag.ActionType = "Create";
                List<SelectListItem> WeekDaylist = new List<SelectListItem>();
                WeekDaylist.Add(new SelectListItem("SUNDAY", "1"));
                WeekDaylist.Add(new SelectListItem("MONDAY", "2"));
                WeekDaylist.Add(new SelectListItem("TUESDAY", "3"));
                WeekDaylist.Add(new SelectListItem("WEDNESDAY", "4"));
                WeekDaylist.Add(new SelectListItem("THURSDAY", "5"));
                WeekDaylist.Add(new SelectListItem("FRIDAY", "6", true));
                WeekDaylist.Add(new SelectListItem("SATURDAY", "7"));
                ViewData["WeekDay"] = WeekDaylist;

                ViewData["BloodId"] = _bloodGroupRepository.GetAllForDropDown();
                ViewData["DeptId"] = _departmentRepository.GetAllForDropDown();
                ViewData["DesigId"] = _designationRepository.GetAllForDropDown();
                ViewData["EmpCurrDistId"] = _districtRepository.GetAllForDropDown();
                ViewData["EmpPerDistId"] = _districtRepository.GetAllForDropDown();

                ViewData["EmpCurrPSId"] = _policeStationRepository.GetAllForDropDown();
                ViewData["EmpPerPSId"] = _policeStationRepository.GetAllForDropDown();

                ViewData["EmpCurrPOId"] = _postOfficeRepository.GetAllForDropDown();
                ViewData["EmpPerPOId"] = _postOfficeRepository.GetAllForDropDown();

                ViewData["BId"] = _buildingTypeRepository.GetAllForDropDown();

                ViewData["GenderId"] = _genderRepository.GetAllForDropDown();

                ViewData["EmpTypeId"] = _empTypeRepository.GetAllForDropDown();

                ViewData["PayModeId"] = _hREmpInfoRepository.PayModeList();
                ViewData["BankId"] = _bankRepository.GetAllForDropDown();
                ViewData["BranchId"] = _bankBranchRepository.GetAllForDropDown();
                ViewData["AccTypeId"] = _hREmpInfoRepository.AccTypeList();

                ViewData["FloorId"] = _floorRepository.GetAllForDropDown();
                ViewData["GradeId"] = _gradeRepository.GetAllForDropDown();
                ViewData["LineId"] = _lineRepository.GetAllForDropDown();
                ViewData["RelgionId"] = _religionRepository.GetAllForDropDown();
                ViewData["SectId"] = _sectionRepository.GetAllForDropDown();
                ViewData["ShiftId"] = _shiftRepository.GetAllForDropDown();
                ViewData["SubSectId"] = _subSectionRepository.GetAllForDropDown();
                ViewData["UnitId"] = _cat_UnitRepository.GetAllForDropDown();

                var year = db.Acc_FiscalYear.Where(f => f.ComId == ComId).Select(y => new { FiscalYearId = y.Id, FYName = y.FYName });

                ViewData["PFFinalYId"] = _hREmpInfoRepository.PFFinalYList();
                ViewData["PFFundTransferYId"] = _hREmpInfoRepository.PFFundTransferYList();
                ViewData["WFFinalYId"] = _hREmpInfoRepository.WFFinalYList();
                ViewData["WFFundTransferYId"] = _hREmpInfoRepository.WFFundTransferYList();
                ViewData["GratuityFinalYId"] = _hREmpInfoRepository.GratuityFinalYList();
                ViewData["GratuityFundTransferYId"] = _hREmpInfoRepository.GratuityFundTransferYList();

                ViewData["SkillId"] = _skillRepository.GetAllForDropDown();
                return View(new EmployeeModel());

            }
            catch (Exception ex)
            {

                throw ex;
            }

        }

        [HttpPost]
        [AllowAnonymous]
        //[ValidateAntiForgeryToken]
        //[Bind("ComId,EmpId,EmpCode,EmployeeName,EmpFather,EmpMother,EmpSpouse,EmpCurrAdd,EmpCurrVill,EmpCurrPo,EmpCurrPs,EmpCurrDistId,EmpPerAdd,EmpPerVill,EmpPerPo,EmpPerPs,EmpPerCity,EmpPerDistId,EmpPerZip,EmpPhone,EmpMobile,EmpEmail,EmpPicLocation,EmpRemarks,Sex,RelgionId,Caste,BloodId,MaritalSts,DtBirth,DtJoin,DtReleased,DtIncrement,IsConfirm,DtConfirm,ConfDay,DeptId,SectId,SubSectId,DesigId,GradeId,FloorId,LineId,EmpCategory,WorkPlace,ShiftId,Nationality,PassportNo,VoterNo,BirthCertNo,IsAllowPf,DtPf,IsAllowOt,PaySource,PayMode,EmpType,EmpSts,CardNo,BankId,BankAcNo,Fpid,WeekDayId,OldEmpId,Approved,NickName,DtApprove,ChildNo,EmpCurrDist,EmpPerDist,EduLvl,EmpRef,EmpRefMob,IsTax,IsAcc,EmpCurrZip,EmpCurrCity,DtTransport,IsDisabled,EmpNomineeName,EmpNomineeMob,EmergencyName,EmergencyMob,EmployementType,EmpCatagory,Title,DtCardAssign,IsContract,WorkType,DtMarrige,CardNoOld,IsNid,ChildM,ChildF,EmpPflocation,EmpMclocation,EmpHblocation,EmpWflocation,IsInactive,PcName,UserId,DateAdded,UpdateByUserId,DateUpdated")]
        public IActionResult CreateEmpInfo(EmployeeModel hrEmpInfo, IFormFile file, IFormFile signFile)
        {
            var dtConfirm = hrEmpInfo.DtConfirm;
            //var errors = ModelState.Where(x => x.Value.Errors.Any())
            //   .Select(x => new { x.Key, x.Value.Errors });
            var ComId = HttpContext.Session.GetInt32("ComId");
            if (ModelState.IsValid)
            {
                var UserId = HttpContext.Session.GetInt32("UserId");
                hrEmpInfo.LuserId = UserId.GetValueOrDefault();
                hrEmpInfo.ComId = ComId.GetValueOrDefault();
                if (hrEmpInfo.Id > 0)
                {
                    SqlParameter[] sqlParemeter = new SqlParameter[3];
                    sqlParemeter[0] = new SqlParameter("@ComID", ComId);
                    sqlParemeter[1] = new SqlParameter("@EmpID", hrEmpInfo.Id);
                    sqlParemeter[2] = new SqlParameter("@dtJoin", hrEmpInfo.DtJoin);

                    string query = $"Exec HR_prcProcessLeaveInput '{ComId}', {hrEmpInfo.Id}, '{hrEmpInfo.DtJoin}'";
                    Helper.ExecProcMapT<EmployeeModel>("HR_prcProcessLeaveInput", sqlParemeter);

                    _empInfoRepository.EmpInfoPost(hrEmpInfo, file, signFile);

                    TempData["Message"] = "Data Update Successfully";
                    TempData["Status"] = "2";
                    tranlog.TransactionLog(RouteData.Values["controller"].ToString(), RouteData.Values["action"].ToString(), TempData["Message"].ToString(), hrEmpInfo.Id.ToString(), "Update", hrEmpInfo.EmployeeName.ToString());

                }
                else
                {
                    _empInfoRepository.EmpInfoPostElse(hrEmpInfo, file, signFile);
                    TempData["Message"] = "Data Save Successfully";
                    TempData["Status"] = "1";

                }

                db.SaveChangesAsync();
                TempData["Message"] = "Data Save Successfully";
                TempData["Status"] = "1";
                tranlog.TransactionLog(RouteData.Values["controller"].ToString(), RouteData.Values["action"].ToString(), TempData["Message"].ToString(), hrEmpInfo.Id.ToString(), "Create", hrEmpInfo.EmployeeName.ToString());

                return RedirectToAction(nameof(EmployeeInfoList));
            }
            else
            {
                TempData["Message"] = "Something is wrong!";
                TempData["Status"] = "3";
            }

            ViewData["BloodId"] = _bloodGroupRepository.GetAllForDropDown();
            ViewData["DeptId"] = _departmentRepository.GetAllForDropDown();
            ViewData["DesigId"] = _designationRepository.GetAllForDropDown();
            ViewData["EmpCurrDistId"] = _districtRepository.GetAllForDropDown();
            ViewData["EmpPerDistId"] = _districtRepository.GetAllForDropDown();

            ViewData["EmpCurrPSId"] = _policeStationRepository.GetAllForDropDown();
            ViewData["EmpPerPSId"] = _policeStationRepository.GetAllForDropDown();

            ViewData["EmpCurrPOId"] = _postOfficeRepository.GetAllForDropDown();
            ViewData["EmpPerPOId"] = _postOfficeRepository.GetAllForDropDown();

            ViewData["BId"] = _buildingTypeRepository.GetAllForDropDown();

            ViewData["GenderId"] = _genderRepository.GetAllForDropDown();

            ViewData["EmpTypeId"] = _empTypeRepository.GetAllForDropDown();

            ViewData["PayModeId"] = _hREmpInfoRepository.PayModeList();
            ViewData["BankId"] = _bankRepository.GetAllForDropDown();
            ViewData["BranchId"] = _bankBranchRepository.GetAllForDropDown();
            ViewData["AccTypeId"] = _hREmpInfoRepository.AccTypeList();

            ViewData["FloorId"] = _floorRepository.GetAllForDropDown();
            ViewData["GradeId"] = _gradeRepository.GetAllForDropDown();
            ViewData["LineId"] = _lineRepository.GetAllForDropDown();
            ViewData["RelgionId"] = _religionRepository.GetAllForDropDown();
            ViewData["SectId"] = _sectionRepository.GetAllForDropDown();
            ViewData["ShiftId"] = _shiftRepository.GetAllForDropDown();
            ViewData["SubSectId"] = _subSectionRepository.GetAllForDropDown();
            ViewData["UnitId"] = _cat_UnitRepository.GetAllForDropDown();
            ViewData["SkillId"] = _skillRepository.GetAllForDropDown();

            var year = db.Acc_FiscalYear.Where(f => f.ComId == ComId).Select(y => new { FiscalYearId = y.Id, FYName = y.FYName });

            ViewData["PFFinalYId"] = _hREmpInfoRepository.PFFinalYList();
            ViewData["PFFundTransferYId"] = _hREmpInfoRepository.PFFundTransferYList();
            ViewData["WFFinalYId"] = _hREmpInfoRepository.WFFinalYList();
            ViewData["WFFundTransferYId"] = _hREmpInfoRepository.WFFundTransferYList();
            ViewData["GratuityFinalYId"] = _hREmpInfoRepository.GratuityFinalYList();
            ViewData["GratuityFundTransferYId"] = _hREmpInfoRepository.GratuityFundTransferYList();

            List<SelectListItem> WeekDaylist = new List<SelectListItem>();
            WeekDaylist.Add(new SelectListItem("SUNDAY", "1"));
            WeekDaylist.Add(new SelectListItem("MONDAY", "2"));
            WeekDaylist.Add(new SelectListItem("TUESDAY", "3"));
            WeekDaylist.Add(new SelectListItem("WEDNESDAY", "4"));
            WeekDaylist.Add(new SelectListItem("THURSDAY", "5"));
            WeekDaylist.Add(new SelectListItem("FRIDAY", "6", true));
            WeekDaylist.Add(new SelectListItem("SATURDAY", "7"));
            ViewData["WeekDay"] = WeekDaylist;
            return View(hrEmpInfo);
        }

        // Emp info edit 
        public async Task<IActionResult> EditEmpInfo(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var hrEmpInfo = await _empInfoRepository.EmpInfoEdit(id);

            if (hrEmpInfo == null)
            {
                return NotFound();
            }

            //ViewBag.DtJoin = DateTime.Parse(hrEmpInfo.DtJoin).ToString("dd-MMM-yy");
            ViewBag.ActionType = "Edit";
            List<SelectListItem> WeekDaylist = new List<SelectListItem>();
            WeekDaylist.Add(new SelectListItem("SUNDAY", "1"));
            WeekDaylist.Add(new SelectListItem("MONDAY", "2"));
            WeekDaylist.Add(new SelectListItem("TUESDAY", "3"));
            WeekDaylist.Add(new SelectListItem("WEDNESDAY", "4"));
            WeekDaylist.Add(new SelectListItem("THURSDAY", "5"));
            WeekDaylist.Add(new SelectListItem("FRIDAY", "6"));
            WeekDaylist.Add(new SelectListItem("SATURDAY", "7"));
            if ((hrEmpInfo.HR_Emp_PersonalInfo != null ? hrEmpInfo.HR_Emp_PersonalInfo.WeekDay : null) == null)
            {
                ViewData["WeekDay"] = new SelectList(WeekDaylist, "Value", "Text", 6);
            }
            else
            {
                ViewData["WeekDay"] = new SelectList(WeekDaylist, "Value", "Text", hrEmpInfo.HR_Emp_PersonalInfo.WeekDay);
            }
            var ComId = HttpContext.Session.GetInt32("ComId");
            ViewData["BloodId"] = _bloodGroupRepository.GetAllForDropDown();
            ViewData["DeptId"] = _departmentRepository.GetAllForDropDown();
            ViewData["DesigId"] = _designationRepository.GetAllForDropDown();
            var year = db.Acc_FiscalYear.Where(f => f.ComId == ComId).Select(y => new { FiscalYearId = y.Id, FYName = y.FYName });
            ViewData["PFFinalYId"] = _hREmpInfoRepository.PFFinalYList();
            ViewData["PFFundTransferYId"] = _hREmpInfoRepository.PFFundTransferYList();
            ViewData["WFFinalYId"] = _hREmpInfoRepository.WFFinalYList();
            ViewData["WFFundTransferYId"] = _hREmpInfoRepository.WFFundTransferYList();
            ViewData["GratuityFinalYId"] = _hREmpInfoRepository.GratuityFinalYList();
            ViewData["GratuityFundTransferYId"] = _hREmpInfoRepository.GratuityFundTransferYList();

            if (hrEmpInfo.HR_Emp_Address != null)
            {
                ViewData["EmpCurrDistId"] = _districtRepository.GetAllForDropDown();
                ViewData["EmpPerDistId"] = _districtRepository.GetAllForDropDown();

                ViewData["EmpCurrPSId"] = _hREmpInfoRepository.EmpCurrPSList(hrEmpInfo);
                ViewData["EmpPerPSId"] = _hREmpInfoRepository.EmpPerPSList(hrEmpInfo);


                ViewData["EmpCurrPOId"] = _hREmpInfoRepository.EmpCurrPOList(hrEmpInfo);
                ViewData["EmpPerPOId"] = _hREmpInfoRepository.EmpPerPOList(hrEmpInfo);
            }
            else
            {
                ViewData["EmpCurrDistId"] = _districtRepository.GetAllForDropDown();
                ViewData["EmpPerDistId"] = _districtRepository.GetAllForDropDown();

                ViewData["EmpCurrPSId"] = _policeStationRepository.GetAllForDropDown();
                ViewData["EmpPerPSId"] = _policeStationRepository.GetAllForDropDown();


                ViewData["EmpCurrPOId"] = _postOfficeRepository.GetAllForDropDown();
                ViewData["EmpPerPOId"] = _postOfficeRepository.GetAllForDropDown();
            }
            if (hrEmpInfo.HR_Emp_PersonalInfo != null)
            {
                ViewData["BId"] = _hREmpInfoRepository.EmpBuildingTypeList(hrEmpInfo);
            }
            else
            {
                ViewData["BId"] = _buildingTypeRepository.GetAllForDropDown();
            }

            ViewData["GenderId"] = _genderRepository.GetAllForDropDown();

            ViewData["EmpTypeId"] = _empTypeRepository.GetAllForDropDown();


            if (hrEmpInfo.HR_Emp_BankInfo != null)
            {
                ViewData["PayModeId"] = _hREmpInfoRepository.EmpPayModeList(hrEmpInfo);
                ViewData["BankId"] = _hREmpInfoRepository.EmpBankList(hrEmpInfo);
                ViewData["BranchId"] = _hREmpInfoRepository.EmpBranchList(hrEmpInfo);
                ViewData["AccTypeId"] = _hREmpInfoRepository.EmpBranchList(hrEmpInfo);
            }
            else
            {
                ViewData["PayModeId"] = _hREmpInfoRepository.PayModeList();
                ViewData["BankId"] = _bankRepository.GetAllForDropDown();
                ViewData["BranchId"] = _bankBranchRepository.GetAllForDropDown();
                ViewData["AccTypeId"] = _hREmpInfoRepository.AccTypeList();
            }

            HttpContext.Session.SetInt32("empid", (int)id);
            ViewData["FloorId"] = _floorRepository.GetAllForDropDown();
            ViewData["GradeId"] = _gradeRepository.GetAllForDropDown();
            ViewData["LineId"] = _lineRepository.GetAllForDropDown();
            ViewData["RelgionId"] = _religionRepository.GetAllForDropDown();
            ViewData["SectId"] = _sectionRepository.GetAllForDropDown();
            ViewData["ShiftId"] = _shiftRepository.GetAllForDropDown();
            ViewData["SubSectId"] = _subSectionRepository.GetAllForDropDown();
            ViewData["UnitId"] = _cat_UnitRepository.GetAllForDropDown();
            ViewData["SkillId"] = _skillRepository.GetAllForDropDown();
            return View("CreateEmpInfo", hrEmpInfo);
        }

        // GET: EmpInfoTemp/Delete/5
        public async Task<IActionResult> DeleteEmpInfo(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var ComId = HttpContext.Session.GetInt32("ComId");
            var hrEmpInfo = await _empInfoRepository.EmpInfoEdit(id);

            if (hrEmpInfo == null)
            {
                return NotFound();
            }

            ViewBag.ActionType = "Delete";

            List<SelectListItem> WeekDaylist = new List<SelectListItem>();
            WeekDaylist.Add(new SelectListItem("SUNDAY", "1"));
            WeekDaylist.Add(new SelectListItem("MONDAY", "2"));
            WeekDaylist.Add(new SelectListItem("TUESDAY", "3"));
            WeekDaylist.Add(new SelectListItem("WEDNESDAY", "4"));
            WeekDaylist.Add(new SelectListItem("THURSDAY", "5"));
            WeekDaylist.Add(new SelectListItem("FRIDAY", "6"));
            WeekDaylist.Add(new SelectListItem("SATURDAY", "7"));
            if (hrEmpInfo.HR_Emp_PersonalInfo.WeekDay == null)
            {
                ViewData["WeekDay"] = new SelectList(WeekDaylist, "Value", "Text", 6);
            }
            else
            {
                ViewData["WeekDay"] = new SelectList(WeekDaylist, "Value", "Text", hrEmpInfo.HR_Emp_PersonalInfo.WeekDay);
            }


            var year = db.Acc_FiscalYear.Where(f => f.ComId == ComId).Select(y => new { FiscalYearId = y.Id, FYName = y.FYName });
            ViewData["PFFinalYId"] = _hREmpInfoRepository.PFFinalYList();
            ViewData["PFFundTransferYId"] = _hREmpInfoRepository.PFFundTransferYList();
            ViewData["WFFinalYId"] = _hREmpInfoRepository.WFFinalYList();
            ViewData["WFFundTransferYId"] = _hREmpInfoRepository.WFFundTransferYList();
            ViewData["GratuityFinalYId"] = _hREmpInfoRepository.GratuityFinalYList();
            ViewData["GratuityFundTransferYId"] = _hREmpInfoRepository.GratuityFundTransferYList();
            ViewData["BloodId"] = _bloodGroupRepository.GetAllForDropDown();
            ViewData["DeptId"] = _departmentRepository.GetAllForDropDown();
            ViewData["DesigId"] = _designationRepository.GetAllForDropDown();

            if (hrEmpInfo.HR_Emp_Address != null)
            {
                ViewData["EmpCurrDistId"] = _districtRepository.GetAllForDropDown();
                ViewData["EmpPerDistId"] = _districtRepository.GetAllForDropDown();

                ViewData["EmpCurrPSId"] = _hREmpInfoRepository.EmpCurrPSList(hrEmpInfo);
                ViewData["EmpPerPSId"] = _hREmpInfoRepository.EmpPerPSList(hrEmpInfo);


                ViewData["EmpCurrPOId"] = _hREmpInfoRepository.EmpCurrPOList(hrEmpInfo);
                ViewData["EmpPerPOId"] = _hREmpInfoRepository.EmpPerPOList(hrEmpInfo);
            }
            else
            {
                ViewData["EmpCurrDistId"] = _districtRepository.GetAllForDropDown();
                ViewData["EmpPerDistId"] = _districtRepository.GetAllForDropDown();

                ViewData["EmpCurrPSId"] = _policeStationRepository.GetAllForDropDown();
                ViewData["EmpPerPSId"] = _policeStationRepository.GetAllForDropDown();


                ViewData["EmpCurrPOId"] = _postOfficeRepository.GetAllForDropDown();
                ViewData["EmpPerPOId"] = _postOfficeRepository.GetAllForDropDown();
            }
            if (hrEmpInfo.HR_Emp_PersonalInfo != null)
            {
                ViewData["BId"] = _hREmpInfoRepository.EmpBuildingTypeList(hrEmpInfo);
            }
            else
            {
                ViewData["BId"] = _buildingTypeRepository.GetAllForDropDown();
            }
            ViewData["GenderId"] = _genderRepository.GetAllForDropDown();

            ViewData["EmpTypeId"] = _empTypeRepository.GetAllForDropDown();


            if (hrEmpInfo.HR_Emp_BankInfo != null)
            {
                ViewData["PayModeId"] = _hREmpInfoRepository.EmpPayModeList(hrEmpInfo);
                ViewData["BankId"] = _hREmpInfoRepository.EmpBankList(hrEmpInfo);
                ViewData["BranchId"] = _hREmpInfoRepository.EmpBranchList(hrEmpInfo);
                ViewData["AccTypeId"] = _hREmpInfoRepository.EmpBranchList(hrEmpInfo);
            }
            else
            {
                ViewData["PayModeId"] = _hREmpInfoRepository.PayModeList();
                ViewData["BankId"] = _bankRepository.GetAllForDropDown();
                ViewData["BranchId"] = _bankBranchRepository.GetAllForDropDown();
                ViewData["AccTypeId"] = _hREmpInfoRepository.AccTypeList();
            }

            HttpContext.Session.SetInt32("empid", (int)id);
            ViewData["FloorId"] = _floorRepository.GetAllForDropDown();
            ViewData["GradeId"] = _gradeRepository.GetAllForDropDown();
            ViewData["LineId"] = _lineRepository.GetAllForDropDown();
            ViewData["RelgionId"] = _religionRepository.GetAllForDropDown();
            ViewData["SectId"] = _sectionRepository.GetAllForDropDown();
            ViewData["ShiftId"] = _shiftRepository.GetAllForDropDown();
            ViewData["SubSectId"] = _subSectionRepository.GetAllForDropDown();
            ViewData["UnitId"] = _cat_UnitRepository.GetAllForDropDown();
            ViewData["SkillId"] = _skillRepository.GetAllForDropDown();
            return View("CreateEmpInfo", hrEmpInfo);
        }

        // POST: EmpInfoTemp/Delete/5
        [HttpPost, ActionName("DeleteEmpInfo")]
        //[ValidateAntiForgeryToken]
        public IActionResult DeleteEmpInfoConfirmed(int id)
        {

            try
            {
                var EmployeeModel = _empInfoRepository.Find(id);
                _empInfoRepository.Delete(EmployeeModel);

                TempData["Message"] = "Data Delete Successfully";
                TempData["Status"] = "3";
                tranlog.TransactionLog(RouteData.Values["controller"].ToString(), RouteData.Values["action"].ToString(), TempData["Message"].ToString(), EmployeeModel.Id.ToString(), "Delete", EmployeeModel.EmployeeName);

                return Json(new { Success = 1, EmpId = EmployeeModel.Id, ex = TempData["Message"].ToString() });
            }
            catch (Exception ex)
            {
                //_logger.LogError(ex.InnerException.Message);
                return Json(new { Success = 0, ex = ex.InnerException.Message.ToString() });
            }

        }


        [HttpGet]
        public ActionResult GetPoliceStation(int id)
        {
            var ComId = HttpContext.Session.GetInt32("ComId");

            var policeStation = _policeStationRepository.All()
                .Select(p => new
                {
                    DistId = p.DistId,
                    Id = p.Id,
                    Name = p.PStationName
                })
                .Where(p => p.DistId == id).ToList();
            return Json(new { PoliceStation = policeStation });
        }
        [HttpGet]
        public ActionResult GetPostOffice(int id)
        {
            var ComId = HttpContext.Session.GetInt32("ComId"); ;
            var postOffice = _postOfficeRepository.All()
               .Select(p => new
               {
                   PStationId = p.PStationId,
                   Id = p.Id,
                   Name = p.POName
               })
               .Where(p => p.PStationId == id).ToList();
            //.Where(p => p.DistId == id && p.ComId == ComId).ToList();
            return Json(postOffice);
        }

        //---------------------For Education-------------------------------//

        [HttpPost]
        //[IgnoreAntiforgeryToken]
        public ActionResult EmpEducation(string HR_Emp_Educations)
        {
            try
            {

                _hREmpInfoRepository.EmpEducationDelete(HR_Emp_Educations);
                TempData["Message"] = "Data Update Successfully";
                return Json(new { Success = 2, ex = TempData["Message"].ToString() });
            }
            catch (Exception ex)
            {
                // If Sucess== 0 then Unable to perform Save/Update Operation and send Exception to View as JSON
                return Json(new { Success = 0, ex = ex.InnerException.InnerException.Message.ToString() });
            }
        }
        public async Task<IActionResult> EmpEducationUpdate(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var hrEmpInfo = await _empInfoRepository.EmpInfoEdit(id);

            if (hrEmpInfo == null)
            {
                return NotFound();
            }

            //ViewBag.DtJoin = DateTime.Parse(hrEmpInfo.DtJoin).ToString("dd-MMM-yy");
            ViewBag.ActionType = "Edit";
            List<SelectListItem> WeekDaylist = new List<SelectListItem>();
            WeekDaylist.Add(new SelectListItem("SUNDAY", "1"));
            WeekDaylist.Add(new SelectListItem("MONDAY", "2"));
            WeekDaylist.Add(new SelectListItem("TUESDAY", "3"));
            WeekDaylist.Add(new SelectListItem("WEDNESDAY", "4"));
            WeekDaylist.Add(new SelectListItem("THURSDAY", "5"));
            WeekDaylist.Add(new SelectListItem("FRIDAY", "6"));
            WeekDaylist.Add(new SelectListItem("SATURDAY", "7"));
            if (hrEmpInfo.HR_Emp_PersonalInfo.WeekDay == null)
            {
                ViewData["WeekDay"] = new SelectList(WeekDaylist, "Value", "Text", 6);
            }
            else
            {
                ViewData["WeekDay"] = new SelectList(WeekDaylist, "Value", "Text", hrEmpInfo.HR_Emp_PersonalInfo.WeekDay);
            }
            var ComId = HttpContext.Session.GetInt32("ComId"); ;
            ViewData["BloodId"] = _bloodGroupRepository.GetAllForDropDown();
            ViewData["DeptId"] = _departmentRepository.GetAllForDropDown();
            ViewData["DesigId"] = _designationRepository.GetAllForDropDown();
            var year = db.Acc_FiscalYear.Where(f => f.ComId == ComId).Select(y => new { FiscalYearId = y.Id, FYName = y.FYName });
            ViewData["PFFinalYId"] = _hREmpInfoRepository.PFFinalYList();
            ViewData["PFFundTransferYId"] = _hREmpInfoRepository.PFFundTransferYList();
            ViewData["WFFinalYId"] = _hREmpInfoRepository.WFFinalYList();
            ViewData["WFFundTransferYId"] = _hREmpInfoRepository.WFFundTransferYList();
            ViewData["GratuityFinalYId"] = _hREmpInfoRepository.GratuityFinalYList();
            ViewData["GratuityFundTransferYId"] = _hREmpInfoRepository.GratuityFundTransferYList();

            if (hrEmpInfo.HR_Emp_Address != null)
            {
                ViewData["EmpCurrDistId"] = _districtRepository.GetAllForDropDown();
                ViewData["EmpPerDistId"] = _districtRepository.GetAllForDropDown();

                ViewData["EmpCurrPSId"] = _hREmpInfoRepository.EmpCurrPSList(hrEmpInfo);
                ViewData["EmpPerPSId"] = _hREmpInfoRepository.EmpPerPSList(hrEmpInfo);


                ViewData["EmpCurrPOId"] = _hREmpInfoRepository.EmpCurrPOList(hrEmpInfo);
                ViewData["EmpPerPOId"] = _hREmpInfoRepository.EmpPerPOList(hrEmpInfo);
            }
            else
            {
                ViewData["EmpCurrDistId"] = _districtRepository.GetAllForDropDown();
                ViewData["EmpPerDistId"] = _districtRepository.GetAllForDropDown();

                ViewData["EmpCurrPSId"] = _policeStationRepository.GetAllForDropDown();
                ViewData["EmpPerPSId"] = _policeStationRepository.GetAllForDropDown();


                ViewData["EmpCurrPOId"] = _postOfficeRepository.GetAllForDropDown();
                ViewData["EmpPerPOId"] = _postOfficeRepository.GetAllForDropDown();
            }
            if (hrEmpInfo.HR_Emp_PersonalInfo != null)
            {
                ViewData["BId"] = _hREmpInfoRepository.EmpBuildingTypeList(hrEmpInfo);
            }
            else
            {
                ViewData["BId"] = _buildingTypeRepository.GetAllForDropDown();
            }

            ViewData["GenderId"] = _genderRepository.GetAllForDropDown();

            ViewData["EmpTypeId"] = _empTypeRepository.GetAllForDropDown();


            if (hrEmpInfo.HR_Emp_BankInfo != null)
            {
                ViewData["PayModeId"] = _hREmpInfoRepository.EmpPayModeList(hrEmpInfo);
                ViewData["BankId"] = _hREmpInfoRepository.EmpBankList(hrEmpInfo);
                ViewData["BranchId"] = _hREmpInfoRepository.EmpBranchList(hrEmpInfo);
                ViewData["AccTypeId"] = _hREmpInfoRepository.EmpBranchList(hrEmpInfo);
            }
            else
            {
                ViewData["PayModeId"] = _hREmpInfoRepository.PayModeList();
                ViewData["BankId"] = _bankRepository.GetAllForDropDown();
                ViewData["BranchId"] = _bankBranchRepository.GetAllForDropDown();
                ViewData["AccTypeId"] = _hREmpInfoRepository.AccTypeList();
            }

            HttpContext.Session.SetInt32("empid", (int)id);
            ViewData["FloorId"] = _floorRepository.GetAllForDropDown();
            ViewData["GradeId"] = _gradeRepository.GetAllForDropDown();
            ViewData["LineId"] = _lineRepository.GetAllForDropDown();
            ViewData["RelgionId"] = _religionRepository.GetAllForDropDown();
            ViewData["SectId"] = _sectionRepository.GetAllForDropDown();
            ViewData["ShiftId"] = _shiftRepository.GetAllForDropDown();
            ViewData["SubSectId"] = _subSectionRepository.GetAllForDropDown();
            ViewData["UnitId"] = _cat_UnitRepository.GetAllForDropDown();
            ViewData["SkillId"] = _skillRepository.GetAllForDropDown();
            return View(nameof(EmpEducation), hrEmpInfo);
        }
        public IActionResult UploadCertificate(IFormFile Certificate)
        {
            if (Certificate != null)
            {
                string filename = $"{_env.WebRootPath}\\EmpDocument\\Certificates\\{Certificate.FileName}";
                using (FileStream stream = System.IO.File.Create(filename))
                {
                    Certificate.CopyTo(stream);
                    stream.Flush();
                }
            }
            return View("EmpEducation");
        }
        //-------------------------End of Education-----------------------------//

        // for download file
        public IActionResult DownloadEducationFile(string file)
        {
            string filepath = $"{Directory.GetCurrentDirectory()}{@"\wwwroot\EmpDocument\Certificates"}" + "\\" + file;

            var fileBytes = System.IO.File.ReadAllBytes(filepath);
            var response = new FileContentResult(fileBytes, "application/octet-stream")
            {
                FileDownloadName = file
            };
            return Ok(response);
        }
        //[Obsolete]
        //public async Task<IActionResult> DownloadEducationFile(string file)
        //{ 
        //    if (file == null)
        //        return Content("filename is not availble");

        //    var path = $"{Directory.GetCurrentDirectory()}{@"\wwwroot\EmpDocument\Certificates"}" + "\\" + file;

        //    var memory = new MemoryStream();
        //    using (var stream = new FileStream(path, FileMode.Open))
        //    {
        //        await stream.CopyToAsync(memory);
        //    }
        //    memory.Position = 0;
        //    return File(memory, GetContentType(path), Path.GetFileName(path));
        //}
        private string GetContentType(string path)
        {
            var types = GetMimeTypes();
            var ext = Path.GetExtension(path).ToLowerInvariant();
            return types[ext];
        }
        private Dictionary<string, string> GetMimeTypes()
        {
            return new Dictionary<string, string>
            {
                {".txt", "text/plain"},
                {".pdf", "application/pdf"},
                {".doc", "application/vnd.ms-word"},
                {".docx", "application/vnd.ms-word"},
                {".xls", "application/vnd.ms-excel"},
                {".xlsx", "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet"},
                {".png", "image/png"},
                {".jpg", "image/jpeg"},
                {".jpeg", "image/jpeg"},
                {".gif", "image/gif"},
                {".csv", "text/csv"},
                {".zip", "application/zip" },
                {".rar" , "application/vnd.rar"}
            };
        }
        //-------------------------For Experience------------------------------//

        [HttpPost]
        public ActionResult EmpExperience(string HR_Emp_Experiences)
        {
            try
            {
                _hREmpInfoRepository.EmpExperienceDelete(HR_Emp_Experiences);
                TempData["Message"] = "Data Update Successfully";
                return Json(new { Success = 2, ex = TempData["Message"].ToString() });
            }
            catch (Exception ex)
            {
                // If Sucess== 0 then Unable to perform Save/Update Operation and send Exception to View as JSON
                return Json(new { Success = 0, ex = ex.InnerException.InnerException.Message.ToString() });
            }
        }

        public async Task<IActionResult> EmpExperienceUpdate(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var hrEmpInfo = await _empInfoRepository.EmpInfoEdit(id);

            if (hrEmpInfo == null)
            {
                return NotFound();
            }

            //ViewBag.DtJoin = DateTime.Parse(hrEmpInfo.DtJoin).ToString("dd-MMM-yy");
            ViewBag.ActionType = "Edit";
            List<SelectListItem> WeekDaylist = new List<SelectListItem>();
            WeekDaylist.Add(new SelectListItem("SUNDAY", "1"));
            WeekDaylist.Add(new SelectListItem("MONDAY", "2"));
            WeekDaylist.Add(new SelectListItem("TUESDAY", "3"));
            WeekDaylist.Add(new SelectListItem("WEDNESDAY", "4"));
            WeekDaylist.Add(new SelectListItem("THURSDAY", "5"));
            WeekDaylist.Add(new SelectListItem("FRIDAY", "6"));
            WeekDaylist.Add(new SelectListItem("SATURDAY", "7"));
            if (hrEmpInfo.HR_Emp_PersonalInfo.WeekDay == null)
            {
                ViewData["WeekDay"] = new SelectList(WeekDaylist, "Value", "Text", 6);
            }
            else
            {
                ViewData["WeekDay"] = new SelectList(WeekDaylist, "Value", "Text", hrEmpInfo.HR_Emp_PersonalInfo.WeekDay);
            }
            var ComId = HttpContext.Session.GetInt32("ComId"); ;
            ViewData["BloodId"] = _bloodGroupRepository.GetAllForDropDown();
            ViewData["DeptId"] = _departmentRepository.GetAllForDropDown();
            ViewData["DesigId"] = _designationRepository.GetAllForDropDown();
            var year = db.Acc_FiscalYear.Where(f => f.ComId == ComId).Select(y => new { FiscalYearId = y.Id, FYName = y.FYName });
            ViewData["PFFinalYId"] = _hREmpInfoRepository.PFFinalYList();
            ViewData["PFFundTransferYId"] = _hREmpInfoRepository.PFFundTransferYList();
            ViewData["WFFinalYId"] = _hREmpInfoRepository.WFFinalYList();
            ViewData["WFFundTransferYId"] = _hREmpInfoRepository.WFFundTransferYList();
            ViewData["GratuityFinalYId"] = _hREmpInfoRepository.GratuityFinalYList();
            ViewData["GratuityFundTransferYId"] = _hREmpInfoRepository.GratuityFundTransferYList();

            if (hrEmpInfo.HR_Emp_Address != null)
            {
                ViewData["EmpCurrDistId"] = _districtRepository.GetAllForDropDown();
                ViewData["EmpPerDistId"] = _districtRepository.GetAllForDropDown();

                ViewData["EmpCurrPSId"] = _hREmpInfoRepository.EmpCurrPSList(hrEmpInfo);
                ViewData["EmpPerPSId"] = _hREmpInfoRepository.EmpPerPSList(hrEmpInfo);


                ViewData["EmpCurrPOId"] = _hREmpInfoRepository.EmpCurrPOList(hrEmpInfo);
                ViewData["EmpPerPOId"] = _hREmpInfoRepository.EmpPerPOList(hrEmpInfo);
            }
            else
            {
                ViewData["EmpCurrDistId"] = _districtRepository.GetAllForDropDown();
                ViewData["EmpPerDistId"] = _districtRepository.GetAllForDropDown();

                ViewData["EmpCurrPSId"] = _policeStationRepository.GetAllForDropDown();
                ViewData["EmpPerPSId"] = _policeStationRepository.GetAllForDropDown();


                ViewData["EmpCurrPOId"] = _postOfficeRepository.GetAllForDropDown();
                ViewData["EmpPerPOId"] = _postOfficeRepository.GetAllForDropDown();
            }
            if (hrEmpInfo.HR_Emp_PersonalInfo != null)
            {
                ViewData["BId"] = _hREmpInfoRepository.EmpBuildingTypeList(hrEmpInfo);
            }
            else
            {
                ViewData["BId"] = _buildingTypeRepository.GetAllForDropDown();
            }

            ViewData["GenderId"] = _genderRepository.GetAllForDropDown();

            ViewData["EmpTypeId"] = _empTypeRepository.GetAllForDropDown();


            if (hrEmpInfo.HR_Emp_BankInfo != null)
            {
                ViewData["PayModeId"] = _hREmpInfoRepository.EmpPayModeList(hrEmpInfo);
                ViewData["BankId"] = _hREmpInfoRepository.EmpBankList(hrEmpInfo);
                ViewData["BranchId"] = _hREmpInfoRepository.EmpBranchList(hrEmpInfo);
                ViewData["AccTypeId"] = _hREmpInfoRepository.EmpBranchList(hrEmpInfo);
            }
            else
            {
                ViewData["PayModeId"] = _hREmpInfoRepository.PayModeList();
                ViewData["BankId"] = _bankRepository.GetAllForDropDown();
                ViewData["BranchId"] = _bankBranchRepository.GetAllForDropDown();
                ViewData["AccTypeId"] = _hREmpInfoRepository.AccTypeList();
            }

            HttpContext.Session.SetInt32("empid", (int)id);
            ViewData["FloorId"] = _floorRepository.GetAllForDropDown();
            ViewData["GradeId"] = _gradeRepository.GetAllForDropDown();
            ViewData["LineId"] = _lineRepository.GetAllForDropDown();
            ViewData["RelgionId"] = _religionRepository.GetAllForDropDown();
            ViewData["SectId"] = _sectionRepository.GetAllForDropDown();
            ViewData["ShiftId"] = _shiftRepository.GetAllForDropDown();
            ViewData["SubSectId"] = _subSectionRepository.GetAllForDropDown();
            ViewData["UnitId"] = _cat_UnitRepository.GetAllForDropDown();
            ViewData["SkillId"] = _skillRepository.GetAllForDropDown();
            return View(nameof(EmpExperience), hrEmpInfo);
        }
        //------------------------End of Experience----------------------------//
        #endregion





        #region Grade

        public IActionResult GradeList()
        {
            TempData["Message"] = "Data Load Successfully";
            TempData["Status"] = "1";
            tranlog.TransactionLog(RouteData.Values["controller"].ToString(), RouteData.Values["action"].ToString(), TempData["Message"].ToString(), "", "List Show", "");

            var data = _gradeRepository.All();
            return View(data.ToList());

        }

        public IActionResult CreateGrade()
        {

            ViewBag.ActionType = "Create";
            //ViewBag.DeptId = new SelectList(db.Cat_Department, "DeptId", "DeptName");
            return View();
        }

        [HttpPost]
        public IActionResult CreateGrade(Cat_GradeModel cat_Grade)
        {
            if (ModelState.IsValid)
            {

                if (cat_Grade.Id > 0)
                {
                    _gradeRepository.Update(cat_Grade, cat_Grade.Id);

                    TempData["Message"] = "Data Update Successfully";
                    TempData["Status"] = "2";
                    tranlog.TransactionLog(RouteData.Values["controller"].ToString(), RouteData.Values["action"].ToString(), TempData["Message"].ToString(), cat_Grade.Id.ToString(), "Update", cat_Grade.GradeName.ToString());

                }
                else
                {
                    _gradeRepository.Insert(cat_Grade);

                    TempData["Message"] = "Data Save Successfully";
                    TempData["Status"] = "1";
                    tranlog.TransactionLog(RouteData.Values["controller"].ToString(), RouteData.Values["action"].ToString(), TempData["Message"].ToString(), cat_Grade.Id.ToString(), "Create", cat_Grade.GradeName.ToString());

                }
                return RedirectToAction("GradeList", "HRVariable");
            }
            return View(cat_Grade);
        }
        public IActionResult EditGrade(int id)
        {
            ViewBag.ActionType = "Edit";
            var cat_Grade = _gradeRepository.Find(id);
            if (cat_Grade == null)
            {
                return NotFound();
            }
            return View("CreateGrade", cat_Grade);
        }


        public IActionResult DeleteGrade(int id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var Cat_Grade = _gradeRepository.Find(id);
            if (Cat_Grade == null)
            {
                return NotFound();
            }
            ViewBag.ActionType = "Delete";
            return View("CreateGrade", Cat_Grade);
        }

        [HttpPost, ActionName("DeleteGrade")]
        public IActionResult DeleteGradeConfirmed(int id)
        {
            try
            {
                var Cat_Grade = _gradeRepository.Find(id);
                _gradeRepository.Delete(Cat_Grade);

                TempData["Message"] = "Data Delete Successfully";
                TempData["Status"] = "3";
                tranlog.TransactionLog(RouteData.Values["controller"].ToString(), RouteData.Values["action"].ToString(), TempData["Message"].ToString(), Cat_Grade.Id.ToString(), "Delete", Cat_Grade.GradeName);

                return Json(new { Success = 1, GradeId = Cat_Grade.Id, ex = TempData["Message"].ToString() });
            }
            catch (Exception ex)
            {
                return Json(new { Success = 0, ex = ex.InnerException.InnerException.Message.ToString() });
            }
        }

        #endregion



        #region Attendance Process
        public IActionResult AttendanceProcessList(string msg)
        {
            try
            {

                TempData["Message"] = "Data Load Successfully";
                TempData["Status"] = "1";
                tranlog.TransactionLog(RouteData.Values["controller"].ToString(), RouteData.Values["action"].ToString(), TempData["Message"].ToString(), "", "List Show", "");

                var model = _attendanceProcessRepository.GetAttProcess(msg);
                model.dtProcess = model.dtLast;

                if (msg == null)
                {

                }
                else
                {
                    ModelState.AddModelError("CustomError", "Process complete");
                    ViewBag.loadMsg = msg;
                }

                ViewBag.Section = _sectionRepository.GetAllForDropDown();
                ViewBag.Employee = _attendanceProcessRepository.GetEmpSelectList();
                ViewBag.EmpData = _empInfoRepository.GetEmp();

                //string username = HttpContext.Session.GetString("username");


                ViewBag.monthlyprocess = true;
                //if (username != null)
                //{
                //    if (username.Contains("gtrbd"))
                //    {
                //        ViewBag.UserName = true;
                //    }
                //    else
                //    {
                //        ViewBag.UserName = false;
                //    }
                //}

                return View(model);

            }
            catch (Exception ex)
            {

                throw ex;
            }
        }







        [HttpPost]
        //[ValidateAntiForgeryToken]
        public ActionResult AttendanceProcessList(HR_AttendanceProcess model/*, string optSts, string optCriteria*/)
        {
            try
            {

                string optSts = model.dayType;
                string optCriteria = model.optCriteria;

                var comid = (HttpContext.Session.GetInt32("ComId"));
                var userid = HttpContext.Session.GetInt32("UserId");
                //var values = prcProcessData(model, optSts, optCriteria,comid,userid);
                string values = "";

                //string pcName = "AHSAN-PC";


                string sqlQuery = "";
                dsDetails = new DataSet();

                Int64 ChkLock = 0;

                sqlQuery = "Select dbo.HR_fncProcessLock ('" + comid + "', 'Attendance Lock','" + Helper.GTRDate(model.dtProcess.ToString()) + "')";
                ChkLock = Helper.GTRCountingDataLarge(sqlQuery);


                if (ChkLock == 1)
                {
                    TempData["Message"] = "Process Locked. Please communicate with Administrator";
                    return Json(new { Success = 2, ex = TempData["Message"].ToString() });
                }
                try
                {
                    // transaction path for transaction log 
                    //var path = Request.Url.AbsolutePath.ToString();
                    var path = "";
                    if (path == null || path.Length == 0)
                    {
                        path = "AttendanceProcess";
                    }

                    DateTime dt1 = model.dtProcess;
                    //DateTime dt1 = model.dtLast;
                    DateTime dt2 = model.dtLast;

                    TimeSpan ts = dt1 - dt2;
                    int days = ts.Days;
                    //if (days > 1)
                    //{
                    //    TempData["Message"] = "Please Run The Process For " + Helper.GTRDate(model.dtLast.AddDays(1).ToString());
                    //    return Json(new { Success = 2, ex = TempData["Message"].ToString() });
                    //}

                    if (model.Monthly == true)
                    {
                        int X = 0, Y = 0;
                        var m = model.dtLast;
                        X = DateTime.Parse(model.dtProcess.ToString()).Day;
                        Y = DateTime.Parse(model.dtTo.ToString()).Day;

                        while (X <= Y)
                        {
                            dsDetails = new DataSet();
                            {
                                if (optSts == "H" || optSts == "R" || optSts == "W" || optSts == "S")
                                {

                                    _attendanceProcessRepository.RemoveProssType(model);
                                    _attendanceProcessRepository.SaveAtt(model);

                                }
                                prcInsertEmp(model, model.optCriteria);


                                SqlParameter[] parameter = new SqlParameter[2];
                                parameter[0] = new SqlParameter("@ComID", comid);
                                parameter[1] = new SqlParameter("@Date", Helper.GTRDate(model.dtProcess.ToString()));

                                Helper.ExecProc("HR_PrcProcessAttend", parameter);

                            }
                            model.dtProcess = DateTime.Parse(model.dtProcess.ToString()).AddDays(1);
                            X++;
                        }
                    }
                    else
                    {
                        if (optSts == "H" || optSts == "R" || optSts == "W" || optSts == "S")
                        {
                            _attendanceProcessRepository.RemoveProssType(model);
                            _attendanceProcessRepository.SaveAtt(model);

                        }

                        SqlParameter[] parameter = new SqlParameter[2];
                        parameter[0] = new SqlParameter("@ComID", comid);
                        parameter[1] = new SqlParameter("@Date", Helper.GTRDate(model.dtProcess.ToString()));

                        Helper.ExecProc("HR_PrcProcessAttend", parameter);
                    }

                    values = "Process complete";
                }
                catch (Exception ex)
                {
                    return Json(ex.Message.ToString());
                }
                if (values == "Process complete")
                {
                    ModelState.AddModelError("CustomError", values);
                    ViewBag.loadMsg = "save";
                    TempData["Message"] = values;
                    return Json(new { Success = 1, ex = TempData["Message"].ToString() });

                }
                else
                {
                    ModelState.AddModelError("CustomError", values);

                    TempData["Message"] = "Process not complete";
                    return Json(new { Success = 1, ex = TempData["Message"].ToString() });
                }

            }
            catch (Exception ex)
            {
                ModelState.AddModelError("CustomError", ex.Message);
                ViewBag.msgErr = "error";
                return Json(new { Success = 0, ex = ex.InnerException.InnerException.Message.ToString() });

            }
        }
        public string? prcProcessData(HR_AttendanceProcess model, string optSts, string optCriteria, string comId, string userId)
        {
            string comid = comId;
            string userid = userId;

            string pcName = "Himu Test Pc";
            ArrayList arQuery = new ArrayList();

            string sqlQuery = "";
            dsDetails = new DataSet();
            Int64 ChkLock = 0;

            sqlQuery = "Select dbo.HR_fncProcessLock ('" + comid + "', 'Attendance Lock','" + Helper.GTRDate(model.dtProcess.ToString()) + "')";
            ChkLock = Helper.GTRCountingDataLarge(sqlQuery);


            if (ChkLock == 1)
            {
                return "Process Locked. Please communicate with Administrator";
            }
            try
            {

                var path = "";
                if (path == null || path.Length == 0)
                {
                    path = "AttendanceProcess";
                }

                DateTime dt1 = model.dtProcess;
                DateTime dt2 = model.dtLast;

                TimeSpan ts = dt1 - dt2;
                int days = ts.Days;
                //if (days > 1)
                //{
                //    return "Please Run The Process For " + Helper.GTRDate(model.dtLast.AddDays(1).ToString());
                //}

                if (model.Monthly == true)
                {
                    int X = 0, Y = 0;
                    var m = model.dtLast;
                    X = DateTime.Parse(model.dtProcess.ToString()).Day;
                    Y = DateTime.Parse(model.dtTo.ToString()).Day;

                    while (X <= Y)
                    {

                        {
                            if (optSts == "H" || optSts == "R" || optSts == "W" || optSts == "S")
                            {
                                sqlQuery = "delete tblProssType where ComId = " + comid + " and ProssDt =  '" + Helper.GTRDate(model.dtProcess.ToString()) + "' ";
                                arQuery.Add(sqlQuery);
                                sqlQuery = "insert into tblProssType(ComId, ProssDt, DaySts, DayStsB, IsLock) values(" + comid + ", '" + Helper.GTRDate(model.dtProcess.ToString()) + "', '" + optSts + "', '" + optSts + "', 0)";
                                arQuery.Add(sqlQuery);

                            }
                            prcInsertEmp(model, optCriteria);

                            sqlQuery = "Exec HR_PrcProcessAttend " + comid + ",'" + Helper.GTRDate(model.dtProcess.ToString()) + "'";
                            arQuery.Add(sqlQuery);

                        }
                        model.dtProcess = DateTime.Parse(model.dtProcess.ToString()).AddDays(1);
                        X++;

                    }
                }
                else
                {
                    if (optSts == "H" || optSts == "R" || optSts == "W" || optSts == "S")
                    {
                        sqlQuery = "delete tblProssType where ComId = " + comid + " and ProssDt =  '" + Helper.GTRDate(model.dtProcess.ToString()) + "' ";
                        arQuery.Add(sqlQuery);
                        sqlQuery = "insert into tblProssType(ComId, ProssDt, DaySts, DayStsB, IsLock) values(" + comid + ", '" + Helper.GTRDate(model.dtProcess.ToString()) + "', '" + optSts + "', '" + optSts + "', 0)";
                        arQuery.Add(sqlQuery);

                    }
                    sqlQuery = "Exec HR_PrcProcessAttend " + comid + ",'" + Helper.GTRDate(model.dtProcess.ToString()) + "'";
                    arQuery.Add(sqlQuery);

                }

                Helper.GTRSaveDataWithSQLCommand(arQuery);
                return "Process complete";
            }
            catch (Exception ex)
            {
                return ex.Message.ToString();
            }

        }

        private void prcInsertEmp(HR_AttendanceProcess model, string optCriteria)
        {
            _attendanceProcessRepository.prcInsertEmp(model, optCriteria);
        }
        #endregion


        //#region BloodGroup
        //public IActionResult BloodGroupList()
        //{
        //    TempData["Message"] = "Data Load Successfully";
        //    TempData["Status"] = "1";
        //    tranlog.TransactionLog(RouteData.Values["controller"].ToString(), RouteData.Values["action"].ToString(), TempData["Message"].ToString(), "", "List Show", "");

        //    return View(_bloodGroupRepository.GetBloodGroup().ToList());
        //}

        //public IActionResult CreateBloodGroup()
        //{
        //    ViewBag.ActionType = "Create";
        //    ViewBag.BloodId = new SelectList(_bloodGroupRepository.GetAllForDropDown(), "Value", "Text");
        //    return View();
        //}

        //[HttpPost]
        //public IActionResult CreateBloodGroup(Cat_BloodGroup Cat_BloodGroup)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        if (Cat_BloodGroup.BloodId > 0)
        //        {
        //            _bloodGroupRepository.Update(Cat_BloodGroup);

        //            TempData["Message"] = "Data Update Successfully";
        //            TempData["Status"] = "2";
        //            tranlog.TransactionLog(RouteData.Values["controller"].ToString(), RouteData.Values["action"].ToString(), TempData["Message"].ToString(), Cat_BloodGroup.BloodId.ToString(), "Update", Cat_BloodGroup.BloodName.ToString());

        //        }
        //        else
        //        {
        //            _bloodGroupRepository.Add(Cat_BloodGroup);

        //            TempData["Message"] = "Data Save Successfully";
        //            TempData["Status"] = "1";
        //            tranlog.TransactionLog(RouteData.Values["controller"].ToString(), RouteData.Values["action"].ToString(), TempData["Message"].ToString(), Cat_BloodGroup.BloodId.ToString(), "Create", Cat_BloodGroup.BloodName.ToString());

        //        }
        //        return RedirectToAction("BloodGroupList", "HRVariable");
        //    }
        //    return View(Cat_BloodGroup);
        //}

        //public IActionResult EditBloodGroup(int id)
        //{
        //    if (id == null)
        //    {
        //        return NotFound();
        //    }
        //    ViewBag.ActionType = "Edit";
        //    var Cat_BloodGroup = _bloodGroupRepository.Find(id);
        //    ViewBag.BloodId = new SelectList(_bloodGroupRepository.GetAllForDropDown(), "Value", "Text", Cat_BloodGroup.BloodId);
        //    if (Cat_BloodGroup == null)
        //    {
        //        return NotFound();
        //    }
        //    return View("CreateBloodGroup", Cat_BloodGroup);
        //}

        //public IActionResult DeleteBloodGroup(int id)
        //{
        //    if (id == null)
        //    {
        //        return NotFound();
        //    }

        //    var Cat_BloodGroup = _bloodGroupRepository.Find(id);
        //    if (Cat_BloodGroup == null)
        //    {
        //        return NotFound();
        //    }

        //    ViewBag.ActionType = "Delete";
        //    ViewBag.DeptId = new SelectList(_bloodGroupRepository.GetAllForDropDown(), "Value", "Text", Cat_BloodGroup.BloodId);
        //    return View("CreateBloodGroup", Cat_BloodGroup);
        //}


        //[HttpPost, ActionName("DeleteBloodGroup")]
        //public IActionResult DeleteBloodGroupConfirmed(int id)
        //{
        //    try
        //    {
        //        var Cat_BloodGroup = _bloodGroupRepository.Find(id);
        //        _bloodGroupRepository.Delete(Cat_BloodGroup);

        //        TempData["Message"] = "Data Delete Successfully";
        //        TempData["Status"] = "3";
        //        tranlog.TransactionLog(RouteData.Values["controller"].ToString(), RouteData.Values["action"].ToString(), TempData["Message"].ToString(), Cat_BloodGroup.BloodId.ToString(), "Delete", Cat_BloodGroup.BloodName);

        //        return Json(new { Success = 1, BloodId = Cat_BloodGroup.BloodId, ex = TempData["Message"].ToString() });
        //    }
        //    catch (Exception ex)
        //    {
        //        return Json(new { Success = 0, ex = ex.InnerException.InnerException.Message.ToString() });
        //    }
        //}

        //#endregion


        //#region Religion

        //public IActionResult ReligionList()
        //{
        //    TempData["Message"] = "Data Load Successfully";
        //    TempData["Status"] = "1";
        //    tranlog.TransactionLog(RouteData.Values["controller"].ToString(), RouteData.Values["action"].ToString(), TempData["Message"].ToString(), "", "List Show", "");

        //    return View(_religionRepository.GetReligionList().ToList());
        //}

        //public IActionResult CreateReligion()
        //{
        //    ViewBag.ActionType = "Create";
        //    ViewBag.RelgionId = new SelectList(_religionRepository.GetAllForDropDown(), "Value", "Text");
        //    return View();
        //}

        //[HttpPost]
        //public IActionResult CreateReligion(Cat_Religion Cat_Religion)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        if (Cat_Religion.RelgionId > 0)
        //        {
        //            _religionRepository.Update(Cat_Religion);

        //            TempData["Message"] = "Data Update Successfully";
        //            TempData["Status"] = "2";
        //            tranlog.TransactionLog(RouteData.Values["controller"].ToString(), RouteData.Values["action"].ToString(), TempData["Message"].ToString(), Cat_Religion.RelgionId.ToString(), "Update", Cat_Religion.ReligionName.ToString());

        //        }
        //        else
        //        {
        //            _religionRepository.Add(Cat_Religion);

        //            TempData["Message"] = "Data Save Successfully";
        //            TempData["Status"] = "1";
        //            tranlog.TransactionLog(RouteData.Values["controller"].ToString(), RouteData.Values["action"].ToString(), TempData["Message"].ToString(), Cat_Religion.RelgionId.ToString(), "Create", Cat_Religion.ReligionName.ToString());

        //        }
        //        return RedirectToAction("ReligionList", "HRVariable");
        //    }
        //    return View(Cat_Religion);
        //}

        //public IActionResult EditReligion(int id)
        //{
        //    if (id == null)
        //    {
        //        return NotFound();
        //    }
        //    ViewBag.ActionType = "Edit";
        //    var Cat_Religion = _religionRepository.Find(id);
        //    ViewBag.RelgionId = new SelectList(_religionRepository.GetAllForDropDown(), "Value", "Text", Cat_Religion.RelgionId);
        //    if (Cat_Religion == null)
        //    {
        //        return NotFound();
        //    }
        //    return View("CreateReligion", Cat_Religion);
        //}

        //public IActionResult DeleteReligion(int id)
        //{
        //    if (id == null)
        //    {
        //        return NotFound();
        //    }

        //    var Cat_Religion = _religionRepository.Find(id);

        //    if (Cat_Religion == null)
        //    {
        //        return NotFound();
        //    }

        //    ViewBag.ActionType = "Delete";
        //    ViewBag.DeptId = new SelectList(_religionRepository.GetAllForDropDown(), "Value", "Text", Cat_Religion.RelgionId);
        //    return View("CreateReligion", Cat_Religion);
        //}

        //[HttpPost, ActionName("DeleteReligion")]
        //public IActionResult DeleteReligionConfirmed(int id)
        //{
        //    try
        //    {
        //        var Cat_Religion = _religionRepository.Find(id);
        //        _religionRepository.Delete(Cat_Religion);

        //        TempData["Message"] = "Data Delete Successfully";
        //        TempData["Status"] = "3";
        //        tranlog.TransactionLog(RouteData.Values["controller"].ToString(), RouteData.Values["action"].ToString(), TempData["Message"].ToString(), Cat_Religion.RelgionId.ToString(), "Delete", Cat_Religion.ReligionName);

        //        return Json(new { Success = 1, RelgionId = Cat_Religion.RelgionId, ex = TempData["Message"].ToString() });
        //    }
        //    catch (Exception ex)
        //    {
        //        return Json(new { Success = 0, ex = ex.InnerException.InnerException.Message.ToString() });
        //    }
        //}
        //#endregion


        //#region Line
        //public IActionResult LineList()
        //{
        //    TempData["Message"] = "Data Load Successfully";
        //    TempData["Status"] = "1";
        //    tranlog.TransactionLog(RouteData.Values["controller"].ToString(), RouteData.Values["action"].ToString(), TempData["Message"].ToString(), "", "List Show", "");

        //    return View(_lineRepository.GetAll().ToList());
        //}

        //public IActionResult CreateLine()
        //{
        //    ViewBag.ActionType = "Create";
        //    return View();
        //}

        //[HttpPost]
        //public IActionResult CreateLine(Cat_Line Cat_Line)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        if (Cat_Line.LineId > 0)
        //        {
        //            _lineRepository.Update(Cat_Line);

        //            TempData["Message"] = "Data Update Successfully";
        //            TempData["Status"] = "2";
        //            tranlog.TransactionLog(RouteData.Values["controller"].ToString(), RouteData.Values["action"].ToString(), TempData["Message"].ToString(), Cat_Line.LineId.ToString(), "Update", Cat_Line.LineName.ToString());

        //        }
        //        else
        //        {
        //            _lineRepository.Add(Cat_Line);

        //            TempData["Message"] = "Data Save Successfully";
        //            TempData["Status"] = "1";
        //            tranlog.TransactionLog(RouteData.Values["controller"].ToString(), RouteData.Values["action"].ToString(), TempData["Message"].ToString(), Cat_Line.LineId.ToString(), "Create", Cat_Line.LineName.ToString());

        //        }
        //        return RedirectToAction("LineList", "HRVariable");
        //    }
        //    return View(Cat_Line);
        //}

        //public IActionResult EditLine(int id)
        //{
        //    if (id == null)
        //    {
        //        return NotFound();
        //    }
        //    ViewBag.ActionType = "Edit";
        //    var Cat_Line = _lineRepository.Find(id);
        //    if (Cat_Line == null)
        //    {
        //        return NotFound();
        //    }
        //    return View("CreateLine", Cat_Line);
        //}

        //public IActionResult DeleteLine(int id)
        //{
        //    if (id == null)
        //    {
        //        return NotFound();
        //    }

        //    var Cat_Line = _lineRepository.Find(id);

        //    if (Cat_Line == null)
        //    {
        //        return NotFound();
        //    }

        //    ViewBag.ActionType = "Delete";
        //    ViewBag.LineId = new SelectList(_lineRepository.GetAllForDropDown(), "Value", "Text", Cat_Line.LineId);
        //    return View("CreateLine", Cat_Line);
        //}

        //[HttpPost, ActionName("DeleteLine")]
        //public IActionResult DeleteLineConfirmed(int id)
        //{
        //    try
        //    {
        //        var Cat_Line = _lineRepository.Find(id);
        //        _lineRepository.Delete(Cat_Line);

        //        TempData["Message"] = "Data Delete Successfully";
        //        TempData["Status"] = "3";
        //        tranlog.TransactionLog(RouteData.Values["controller"].ToString(), RouteData.Values["action"].ToString(), TempData["Message"].ToString(), Cat_Line.LineId.ToString(), "Delete", Cat_Line.LineName);

        //        return Json(new { Success = 1, LineId = Cat_Line.LineId, ex = TempData["Message"].ToString() });
        //    }
        //    catch (Exception ex)
        //    {
        //        return Json(new { Success = 0, ex = ex.InnerException.InnerException.Message.ToString() });
        //    }
        //}
        //#endregion


        //#region Cat Variable
        //public IActionResult CatVariableList()
        //{
        //    TempData["Message"] = "Data Load Successfully";
        //    TempData["Status"] = "1";
        //    tranlog.TransactionLog(RouteData.Values["controller"].ToString(), RouteData.Values["action"].ToString(), TempData["Message"].ToString(), "", "List Show", "");

        //    return View(_catVariableRepository.GetAll().ToList());
        //}

        //public IActionResult CreateCatVariable()
        //{
        //    ViewBag.VarType = _catVariableRepository.GetCatVariableList();
        //    ViewBag.ActionType = "Create";
        //    return View();
        //}

        //[HttpPost]
        //public IActionResult CreateCatVariable(Cat_Variable Cat_Variable)
        //{
        //    ViewBag.VarType = _catVariableRepository.GetCatVariableList();
        //    if (ModelState.IsValid)
        //    {
        //        if (Cat_Variable.VarId > 0)
        //        {
        //            _catVariableRepository.Update(Cat_Variable);

        //            TempData["Message"] = "Data Update Successfully";
        //            TempData["Status"] = "2";
        //            tranlog.TransactionLog(RouteData.Values["controller"].ToString(), RouteData.Values["action"].ToString(), TempData["Message"].ToString(), Cat_Variable.VarId.ToString(), "Update", Cat_Variable.VarName.ToString());

        //        }
        //        else
        //        {
        //            _catVariableRepository.Add(Cat_Variable);

        //            TempData["Message"] = "Data Save Successfully";
        //            TempData["Status"] = "1";
        //            tranlog.TransactionLog(RouteData.Values["controller"].ToString(), RouteData.Values["action"].ToString(), TempData["Message"].ToString(), Cat_Variable.VarId.ToString(), "Create", Cat_Variable.VarName.ToString());

        //        }
        //        return RedirectToAction("CatVariableList", "HRVariable");
        //    }
        //    return View(Cat_Variable);
        //}

        //public IActionResult EditCatVariable(int id)
        //{
        //    ViewBag.VarType = _catVariableRepository.GetCatVariableList();
        //    if (id == null)
        //    {
        //        return NotFound();
        //    }
        //    ViewBag.ActionType = "Edit";
        //    var Cat_Variable = _catVariableRepository.Find(id);
        //    if (Cat_Variable == null)
        //    {
        //        return NotFound();
        //    }
        //    return View("CreateCatVariable", Cat_Variable);
        //}

        //public IActionResult DeleteCatVariable(int id)
        //{
        //    ViewBag.VarType = _catVariableRepository.GetCatVariableList();
        //    if (id == null)
        //    {
        //        return NotFound();
        //    }

        //    var Cat_Variable = _catVariableRepository.Find(id);

        //    if (Cat_Variable == null)
        //    {
        //        return NotFound();
        //    }

        //    ViewBag.ActionType = "Delete";

        //    return View("CreateCatVariable", Cat_Variable);
        //}

        //[HttpPost, ActionName("DeleteCatVariable")]
        //public IActionResult DeleteCatVariableConfirmed(int id)
        //{
        //    ViewBag.VarType = _catVariableRepository.GetCatVariableList();
        //    try
        //    {
        //        var Cat_Variable = _catVariableRepository.Find(id);
        //        _catVariableRepository.Delete(Cat_Variable);

        //        TempData["Message"] = "Data Delete Successfully";
        //        TempData["Status"] = "3";
        //        tranlog.TransactionLog(RouteData.Values["controller"].ToString(), RouteData.Values["action"].ToString(), TempData["Message"].ToString(), Cat_Variable.VarId.ToString(), "Delete", Cat_Variable.VarName);

        //        return Json(new { Success = 1, VarId = Cat_Variable.VarId, ex = TempData["Message"].ToString() });
        //    }
        //    catch (Exception ex)
        //    {
        //        return Json(new { Success = 0, ex = ex.InnerException.InnerException.Message.ToString() });
        //    }
        //}
        //#endregion


        #region Shift
        public IActionResult ShiftList()
        {
            return View(_shiftRepository.All());
        }

        [HttpGet]
        public ActionResult AddShift()
        {
            ViewBag.ActionType = "Create";
            ViewBag.ShiftGroupHead = _shiftRepository.GetAllForDropDown();
            return View();
        }
        [HttpPost]
        //[ValidateAntiForgeryToken]
        public ActionResult AddShift(Cat_ShiftModel model)
        {

            var errors = ModelState.Where(x => x.Value.Errors.Any())
            .Select(x => new { x.Key, x.Value.Errors });

            if (ModelState.IsValid)
            {
                if (model.Id == 0)
                {
                    _shiftRepository.Insert(model);


                    TempData["Message"] = "Data Save Successfully";
                    TempData["Status"] = "1";
                    tranlog.TransactionLog(RouteData.Values["controller"].ToString(), RouteData.Values["action"].ToString(), TempData["Message"].ToString(), model.Id.ToString(), "Create", model.ShiftName.ToString());

                }
                else
                {
                    _shiftRepository.Update(model, model.Id);


                    TempData["Message"] = "Data Update Successfully";
                    TempData["Status"] = "2";
                    tranlog.TransactionLog(RouteData.Values["controller"].ToString(), RouteData.Values["action"].ToString(), TempData["Message"].ToString(), model.Id.ToString(), "Update", model.ShiftName.ToString());

                }
                return RedirectToAction("ShiftList");
            }
            else
            {
                if (model.Id == 0)
                {
                    ViewBag.ActionType = "Create";
                }
                else
                {
                    ViewBag.ActionType = "Edit";
                }
            }
            return View(model);
        }


        [AllowAnonymous]
        public IActionResult GetShiftList(DateTime dateTime, string searchquery = "", int page = 1, decimal size = 5)
        {
            var ShiftList = _shiftRepository.All();

            if (searchquery?.Length > 1)
            {
                ShiftList = ShiftList.Where(x =>
                    x.ShiftName.ToLower().Contains(searchquery.ToLower())
                );

            }


            decimal TotalRecordCount = ShiftList.Count();
            var PageCountabc = decimal.Parse((TotalRecordCount / size).ToString());
            var PageCount = Math.Ceiling(PageCountabc);
            decimal skip = (page - 1) * size;

            var query = from x in ShiftList
                        select new
                        {
                            x.Id,
                            x.ShiftName,
                            x.ShiftCode,
                            x.ShiftDesc,
                            ShiftIn = x.ShiftIn.ToString("dd-MMM-yyyy"),
                            ShiftOut = x.ShiftOut.ToString("dd-MMM-yyyy"),
                            ShiftLate = x.ShiftLate.ToString("dd-MMM-yyyy"),
                            LunchTime = x.LunchTime.ToString("dd-MMM-yyyy"),
                            LunchIn = x.LunchIn.ToString("dd-MMM-yyyy"),
                            LunchOut = x.LunchOut.ToString("dd-MMM-yyyy"),
                            RegHour = x.RegHour.ToString("dd-MMM-yyyy"),
                            x.ShiftType,
                            x.ShiftCat,
                        };

            var abcd = query.OrderByDescending(x => x.Id).Skip(int.Parse(skip.ToString())).Take(int.Parse(size.ToString())).ToList();// Take(50);
            var pageinfo = new PagingInfo();
            pageinfo.PageCount = int.Parse(PageCount.ToString());
            pageinfo.PageNo = page;
            pageinfo.PageSize = int.Parse(size.ToString());
            pageinfo.TotalRecordCount = int.Parse(TotalRecordCount.ToString());
            return Json(new { Success = 1, error = false, data = abcd, page = page, size = size, last_page = pageinfo.PageCount, total = pageinfo.TotalRecordCount });
        }


        [HttpGet]
        public ActionResult EditShift(int ShiftId)
        {
            ViewBag.ActionType = "Edit";
            var Shift = _shiftRepository.Find(ShiftId);
            ViewBag.ShiftGroupHead = _shiftRepository.GetAllForDropDown();
            return View("AddShift", Shift);
        }

        public ActionResult DeleteShift(int ShiftId)
        {
            var model = _shiftRepository.Find(ShiftId);
            if (model != null)
            {
                _shiftRepository.Delete(model);


                TempData["Message"] = "Data Delete Successfully";
                TempData["Status"] = "3";
                tranlog.TransactionLog(RouteData.Values["controller"].ToString(), RouteData.Values["action"].ToString(), TempData["Message"].ToString(), model.Id.ToString(), "Delete", model.ShiftName);


                return Json(new { success = "1", msg = "Deleted Successfully" });

                //return RedirectToAction("ShiftList");
            }
            return Json(new { success = "0", msg = "No items found to delete." });
            //return RedirectToAction("ShiftList");
        }
        #endregion


        //#region Skill
        //public IActionResult SkillList()
        //{
        //    TempData["Message"] = "Data Load Successfully";
        //    TempData["Status"] = "1";
        //    tranlog.TransactionLog(RouteData.Values["controller"].ToString(), RouteData.Values["action"].ToString(), TempData["Message"].ToString(), "", "List Show", "");

        //    return View(_skillRepository.SkillAll());
        //}

        //public IActionResult CreateSkill()
        //{
        //    ViewBag.ActionType = "Create";
        //    return View();
        //}

        //[HttpPost]
        //public IActionResult CreateSkill(Cat_Skill Cat_Skill)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        if (Cat_Skill.SkillId > 0)
        //        {
        //            _skillRepository.Update(Cat_Skill);

        //            TempData["Message"] = "Data Update Successfully";
        //            TempData["Status"] = "2";
        //            tranlog.TransactionLog(RouteData.Values["controller"].ToString(), RouteData.Values["action"].ToString(), TempData["Message"].ToString(), Cat_Skill.SkillId.ToString(), "Update", Cat_Skill.SkillName.ToString());

        //        }
        //        else
        //        {
        //            _skillRepository.Add(Cat_Skill);

        //            TempData["Message"] = "Data Save Successfully";
        //            TempData["Status"] = "1";
        //            tranlog.TransactionLog(RouteData.Values["controller"].ToString(), RouteData.Values["action"].ToString(), TempData["Message"].ToString(), Cat_Skill.SkillId.ToString(), "Create", Cat_Skill.SkillName.ToString());

        //        }
        //        return RedirectToAction("SkillList", "HRVariable");
        //    }
        //    return View(Cat_Skill);
        //}

        //public IActionResult EditSkill(int id)
        //{
        //    if (id == null)
        //    {
        //        return NotFound();
        //    }
        //    ViewBag.ActionType = "Edit";
        //    var Cat_Skill = _skillRepository.Find(id);
        //    if (Cat_Skill == null)
        //    {
        //        return NotFound();
        //    }
        //    return View("CreateSkill", Cat_Skill);
        //}

        //public IActionResult DeleteSkill(int id)
        //{
        //    if (id == null)
        //    {
        //        return NotFound();
        //    }

        //    var Cat_Skill = _skillRepository.Find(id);

        //    if (Cat_Skill == null)
        //    {
        //        return NotFound();
        //    }

        //    ViewBag.ActionType = "Delete";
        //    ViewBag.SkillId = new SelectList(_skillRepository.GetAllForDropDown(), "Value", "Text", Cat_Skill.SkillId);
        //    return View("CreateSkill", Cat_Skill);
        //}

        //[HttpPost, ActionName("DeleteSkill")]
        //public IActionResult DeleteSkillConfirmed(int id)
        //{
        //    try
        //    {
        //        var Cat_Skill = _skillRepository.Find(id);
        //        _skillRepository.Delete(Cat_Skill);

        //        TempData["Message"] = "Data Delete Successfully";
        //        TempData["Status"] = "3";
        //        tranlog.TransactionLog(RouteData.Values["controller"].ToString(), RouteData.Values["action"].ToString(), TempData["Message"].ToString(), Cat_Skill.SkillId.ToString(), "Delete", Cat_Skill.SkillName);

        //        return Json(new { Success = 1, SkillId = Cat_Skill.SkillId, ex = TempData["Message"].ToString() });
        //    }
        //    catch (Exception ex)
        //    {
        //        return Json(new { Success = 0, ex = ex.InnerException.InnerException.Message.ToString() });
        //    }
        //}
        //#endregion


        //#region Floor
        //public IActionResult FloorList()
        //{
        //    TempData["Message"] = "Data Load Successfully";
        //    TempData["Status"] = "1";
        //    tranlog.TransactionLog(RouteData.Values["controller"].ToString(), RouteData.Values["action"].ToString(), TempData["Message"].ToString(), "", "List Show", "");

        //    return View(_floorRepository.GetAll().ToList());
        //}

        //public IActionResult CreateFloor()
        //{
        //    ViewBag.ActionType = "Create";
        //    return View();
        //}

        //[HttpPost]
        //public IActionResult CreateFloor(Cat_Floor Cat_Floor)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        if (Cat_Floor.FloorId > 0)
        //        {
        //            _floorRepository.Update(Cat_Floor);

        //            TempData["Message"] = "Data Update Successfully";
        //            TempData["Status"] = "2";
        //            tranlog.TransactionLog(RouteData.Values["controller"].ToString(), RouteData.Values["action"].ToString(), TempData["Message"].ToString(), Cat_Floor.FloorId.ToString(), "Update", Cat_Floor.FloorName.ToString());

        //        }
        //        else
        //        {
        //            _floorRepository.Add(Cat_Floor);

        //            TempData["Message"] = "Data Save Successfully";
        //            TempData["Status"] = "1";
        //            tranlog.TransactionLog(RouteData.Values["controller"].ToString(), RouteData.Values["action"].ToString(), TempData["Message"].ToString(), Cat_Floor.FloorId.ToString(), "Create", Cat_Floor.FloorName.ToString());

        //        }
        //        return RedirectToAction("FloorList", "HRVariable");
        //    }
        //    return View(Cat_Floor);
        //}

        //public IActionResult EditFloor(int id)
        //{
        //    if (id == null)
        //    {
        //        return NotFound();
        //    }
        //    ViewBag.ActionType = "Edit";
        //    var Cat_Floor = _floorRepository.Find(id);
        //    if (Cat_Floor == null)
        //    {
        //        return NotFound();
        //    }
        //    return View("CreateFloor", Cat_Floor);
        //}

        //public IActionResult DeleteFloor(int id)
        //{
        //    if (id == null)
        //    {
        //        return NotFound();
        //    }

        //    var Cat_Floor = _floorRepository.Find(id);

        //    if (Cat_Floor == null)
        //    {
        //        return NotFound();
        //    }

        //    ViewBag.ActionType = "Delete";

        //    return View("CreateFloor", Cat_Floor);
        //}

        //[HttpPost, ActionName("DeleteFloor")]
        //public IActionResult DeleteFloorConfirmed(int id)
        //{
        //    try
        //    {
        //        var Cat_Floor = _floorRepository.Find(id);
        //        _floorRepository.Delete(Cat_Floor);

        //        TempData["Message"] = "Data Delete Successfully";
        //        TempData["Status"] = "3";
        //        tranlog.TransactionLog(RouteData.Values["controller"].ToString(), RouteData.Values["action"].ToString(), TempData["Message"].ToString(), Cat_Floor.FloorId.ToString(), "Delete", Cat_Floor.FloorName);

        //        return Json(new { Success = 1, FloorId = Cat_Floor.FloorId, ex = TempData["Message"].ToString() });
        //    }
        //    catch (Exception ex)
        //    {
        //        return Json(new { Success = 0, ex = ex.InnerException.InnerException.Message.ToString() });
        //    }
        //}
        //#endregion


        //#region Unit
        //public IActionResult CatUnitList()
        //{
        //    TempData["Message"] = "Data Load Successfully";
        //    TempData["Status"] = "1";
        //    tranlog.TransactionLog(RouteData.Values["controller"].ToString(), RouteData.Values["action"].ToString(), TempData["Message"].ToString(), "", "List Show", "");

        //    return View(_catUnitRepository.GetAll().ToList());
        //}

        //public IActionResult CreateCatUnit()
        //{
        //    ViewBag.ActionType = "Create";
        //    return View();
        //}

        //[HttpPost]
        //public IActionResult CreateCatUnit(Cat_Unit Cat_Unit)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        if (Cat_Unit.UnitId > 0)
        //        {
        //            _catUnitRepository.Update(Cat_Unit);

        //            TempData["Message"] = "Data Update Successfully";
        //            TempData["Status"] = "2";
        //            tranlog.TransactionLog(RouteData.Values["controller"].ToString(), RouteData.Values["action"].ToString(), TempData["Message"].ToString(), Cat_Unit.UnitId.ToString(), "Update", Cat_Unit.UnitName.ToString());

        //        }
        //        else
        //        {
        //            _catUnitRepository.Add(Cat_Unit);

        //            TempData["Message"] = "Data Save Successfully";
        //            TempData["Status"] = "1";
        //            tranlog.TransactionLog(RouteData.Values["controller"].ToString(), RouteData.Values["action"].ToString(), TempData["Message"].ToString(), Cat_Unit.UnitId.ToString(), "Create", Cat_Unit.UnitName.ToString());

        //        }
        //        return RedirectToAction("CatUnitList", "HRVariable");
        //    }
        //    return View(Cat_Unit);
        //}

        //public IActionResult EditCatUnit(int id)
        //{
        //    if (id == null)
        //    {
        //        return NotFound();
        //    }
        //    ViewBag.ActionType = "Edit";
        //    var Cat_Unit = _catUnitRepository.Find(id);
        //    if (Cat_Unit == null)
        //    {
        //        return NotFound();
        //    }
        //    return View("CreateCatUnit", Cat_Unit);
        //}

        //public IActionResult DeleteCatUnit(int id)
        //{
        //    if (id == null)
        //    {
        //        return NotFound();
        //    }

        //    var Cat_Unit = _catUnitRepository.Find(id);

        //    if (Cat_Unit == null)
        //    {
        //        return NotFound();
        //    }

        //    ViewBag.ActionType = "Delete";

        //    return View("CreateCatUnit", Cat_Unit);
        //}

        //[HttpPost, ActionName("DeleteCatUnit")]
        //public IActionResult DeleteCatUnitConfirmed(int id)
        //{
        //    try
        //    {
        //        var Cat_Unit = _catUnitRepository.Find(id);
        //        _catUnitRepository.Delete(Cat_Unit);

        //        TempData["Message"] = "Data Delete Successfully";
        //        TempData["Status"] = "3";
        //        tranlog.TransactionLog(RouteData.Values["controller"].ToString(), RouteData.Values["action"].ToString(), TempData["Message"].ToString(), Cat_Unit.UnitId.ToString(), "Delete", Cat_Unit.UnitName);

        //        return Json(new { Success = 1, UnitId = Cat_Unit.UnitId, ex = TempData["Message"].ToString() });
        //    }
        //    catch (Exception ex)
        //    {
        //        return Json(new { Success = 0, ex = ex.InnerException.InnerException.Message.ToString() });
        //    }
        //}
        //#endregion


        //#region Bank
        //public IActionResult BankList()
        //{
        //    TempData["Message"] = "Data Load Successfully";
        //    TempData["Status"] = "1";
        //    tranlog.TransactionLog(RouteData.Values["controller"].ToString(), RouteData.Values["action"].ToString(), TempData["Message"].ToString(), "", "List Show", "");

        //    return View(_bankRepository.GetAll().ToList());
        //}

        //public IActionResult CreateBank()
        //{
        //    ViewBag.ActionType = "Create";
        //    return View();
        //}

        //[HttpPost]
        //public IActionResult CreateBank(Cat_Bank Cat_Bank)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        if (Cat_Bank.BankId > 0)
        //        {
        //            _bankRepository.Update(Cat_Bank);

        //            TempData["Message"] = "Data Update Successfully";
        //            TempData["Status"] = "2";
        //            tranlog.TransactionLog(RouteData.Values["controller"].ToString(), RouteData.Values["action"].ToString(), TempData["Message"].ToString(), Cat_Bank.BankId.ToString(), "Update", Cat_Bank.BankName.ToString());

        //        }
        //        else
        //        {
        //            _bankRepository.Add(Cat_Bank);

        //            TempData["Message"] = "Data Save Successfully";
        //            TempData["Status"] = "1";
        //            tranlog.TransactionLog(RouteData.Values["controller"].ToString(), RouteData.Values["action"].ToString(), TempData["Message"].ToString(), Cat_Bank.BankId.ToString(), "Create", Cat_Bank.BankName.ToString());

        //        }
        //        return RedirectToAction("BankList", "HRVariable");
        //    }
        //    return View(Cat_Bank);
        //}

        //public IActionResult EditBank(int id)
        //{
        //    if (id == null)
        //    {
        //        return NotFound();
        //    }
        //    ViewBag.ActionType = "Edit";
        //    var Cat_Bank = _bankRepository.Find(id);
        //    if (Cat_Bank == null)
        //    {
        //        return NotFound();
        //    }
        //    return View("CreateBank", Cat_Bank);
        //}

        //public IActionResult DeleteBank(int id)
        //{
        //    if (id == null)
        //    {
        //        return NotFound();
        //    }

        //    var Cat_Bank = _bankRepository.Find(id);

        //    if (Cat_Bank == null)
        //    {
        //        return NotFound();
        //    }

        //    ViewBag.ActionType = "Delete";

        //    return View("CreateBank", Cat_Bank);
        //}

        //[HttpPost, ActionName("DeleteBank")]
        //public IActionResult DeleteBankConfirmed(int id)
        //{
        //    try
        //    {
        //        var Cat_Bank = _bankRepository.Find(id);
        //        _bankRepository.Delete(Cat_Bank);

        //        TempData["Message"] = "Data Delete Successfully";
        //        TempData["Status"] = "3";
        //        tranlog.TransactionLog(RouteData.Values["controller"].ToString(), RouteData.Values["action"].ToString(), TempData["Message"].ToString(), Cat_Bank.BankId.ToString(), "Delete", Cat_Bank.BankName);

        //        return Json(new { Success = 1, BankId = Cat_Bank.BankId, ex = TempData["Message"].ToString() });
        //    }
        //    catch (Exception ex)
        //    {
        //        return Json(new { Success = 0, ex = ex.InnerException.InnerException.Message.ToString() });
        //    }
        //}
        //#endregion


        //#region Bank Branch
        //public IActionResult BankBranchList()
        //{
        //    TempData["Message"] = "Data Load Successfully";
        //    TempData["Status"] = "1";
        //    tranlog.TransactionLog(RouteData.Values["controller"].ToString(), RouteData.Values["action"].ToString(), TempData["Message"].ToString(), "", "List Show", "");

        //    return View(_bankBranchRepository.GetAll().ToList());
        //}

        //public IActionResult CreateBankBranch()
        //{
        //    ViewBag.ActionType = "Create";
        //    return View();
        //}

        //[HttpPost]
        //public IActionResult CreateBankBranch(Cat_BankBranch Cat_BankBranch)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        if (Cat_BankBranch.BranchId > 0)
        //        {
        //            _bankBranchRepository.Update(Cat_BankBranch);

        //            TempData["Message"] = "Data Update Successfully";
        //            TempData["Status"] = "2";
        //            tranlog.TransactionLog(RouteData.Values["controller"].ToString(), RouteData.Values["action"].ToString(), TempData["Message"].ToString(), Cat_BankBranch.BranchId.ToString(), "Update", Cat_BankBranch.BranchName.ToString());

        //        }
        //        else
        //        {
        //            _bankBranchRepository.Add(Cat_BankBranch);

        //            TempData["Message"] = "Data Save Successfully";
        //            TempData["Status"] = "1";
        //            tranlog.TransactionLog(RouteData.Values["controller"].ToString(), RouteData.Values["action"].ToString(), TempData["Message"].ToString(), Cat_BankBranch.BranchId.ToString(), "Create", Cat_BankBranch.BranchName.ToString());

        //        }
        //        return RedirectToAction("BankBranchList", "HRVariable");
        //    }
        //    return View(Cat_BankBranch);
        //}

        //public IActionResult EditBankBranch(int id)
        //{
        //    if (id == null)
        //    {
        //        return NotFound();
        //    }
        //    ViewBag.ActionType = "Edit";
        //    var Cat_BankBranch = _bankBranchRepository.Find(id);
        //    if (Cat_BankBranch == null)
        //    {
        //        return NotFound();
        //    }
        //    return View("CreateBankBranch", Cat_BankBranch);
        //}

        //public IActionResult DeleteBankBranch(int id)
        //{
        //    if (id == null)
        //    {
        //        return NotFound();
        //    }

        //    var Cat_BankBranch = _bankBranchRepository.Find(id);

        //    if (Cat_BankBranch == null)
        //    {
        //        return NotFound();
        //    }

        //    ViewBag.ActionType = "Delete";

        //    return View("CreateBankBranch", Cat_BankBranch);
        //}

        //[HttpPost, ActionName("DeleteBankBranch")]
        //public IActionResult DeleteBankBranchConfirmed(int id)
        //{
        //    try
        //    {
        //        var Cat_BankBranch = _bankBranchRepository.Find(id);
        //        _bankBranchRepository.Delete(Cat_BankBranch);

        //        TempData["Message"] = "Data Delete Successfully";
        //        TempData["Status"] = "3";
        //        tranlog.TransactionLog(RouteData.Values["controller"].ToString(), RouteData.Values["action"].ToString(), TempData["Message"].ToString(), Cat_BankBranch.BranchId.ToString(), "Delete", Cat_BankBranch.BranchName);

        //        return Json(new { Success = 1, BankBranchId = Cat_BankBranch.BranchId, ex = TempData["Message"].ToString() });
        //    }
        //    catch (Exception ex)
        //    {
        //        return Json(new { Success = 0, ex = ex.InnerException.InnerException.Message.ToString() });
        //    }
        //}
        //#endregion


        //#region Building Type
        //public IActionResult BuildingTypeList()
        //{
        //    TempData["Message"] = "Data Load Successfully";
        //    TempData["Status"] = "1";
        //    tranlog.TransactionLog(RouteData.Values["controller"].ToString(), RouteData.Values["action"].ToString(), TempData["Message"].ToString(), "", "List Show", "");

        //    return View(_buildingTypeRepository.GetAll().ToList());
        //}

        //public IActionResult CreateBuildingType()
        //{
        //    ViewBag.ActionType = "Create";
        //    return View();
        //}

        //[HttpPost]
        //public IActionResult CreateBuildingType(Cat_BuildingType Cat_BuildingType)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        if (Cat_BuildingType.BId > 0)
        //        {
        //            _buildingTypeRepository.Update(Cat_BuildingType);

        //            TempData["Message"] = "Data Update Successfully";
        //            TempData["Status"] = "2";
        //            tranlog.TransactionLog(RouteData.Values["controller"].ToString(), RouteData.Values["action"].ToString(), TempData["Message"].ToString(), Cat_BuildingType.BId.ToString(), "Update", Cat_BuildingType.BId.ToString());

        //        }
        //        else
        //        {
        //            _buildingTypeRepository.Add(Cat_BuildingType);

        //            TempData["Message"] = "Data Save Successfully";
        //            TempData["Status"] = "1";
        //            tranlog.TransactionLog(RouteData.Values["controller"].ToString(), RouteData.Values["action"].ToString(), TempData["Message"].ToString(), Cat_BuildingType.BId.ToString(), "Create", Cat_BuildingType.BuildingName.ToString());

        //        }
        //        return RedirectToAction("BuildingTypeList", "HRVariable");
        //    }
        //    return View(Cat_BuildingType);
        //}

        //public IActionResult EditBuildingType(int id)
        //{
        //    if (id == null)
        //    {
        //        return NotFound();
        //    }
        //    ViewBag.ActionType = "Edit";
        //    var Cat_BuildingType = _buildingTypeRepository.Find(id);
        //    if (Cat_BuildingType == null)
        //    {
        //        return NotFound();
        //    }
        //    return View("CreateBuildingType", Cat_BuildingType);
        //}

        //public IActionResult DeleteBuildingType(int id)
        //{
        //    if (id == null)
        //    {
        //        return NotFound();
        //    }

        //    var Cat_BuildingType = _buildingTypeRepository.Find(id);

        //    if (Cat_BuildingType == null)
        //    {
        //        return NotFound();
        //    }

        //    ViewBag.ActionType = "Delete";

        //    return View("CreateBuildingType", Cat_BuildingType);
        //}

        //[HttpPost, ActionName("DeleteBuildingType")]
        //public IActionResult DeleteBuildingTypeConfirmed(int id)
        //{
        //    try
        //    {
        //        var Cat_BuildingType = _buildingTypeRepository.Find(id);
        //        _buildingTypeRepository.Delete(Cat_BuildingType);

        //        TempData["Message"] = "Data Delete Successfully";
        //        TempData["Status"] = "3";
        //        tranlog.TransactionLog(RouteData.Values["controller"].ToString(), RouteData.Values["action"].ToString(), TempData["Message"].ToString(), Cat_BuildingType.BId.ToString(), "Delete", Cat_BuildingType.BuildingName);

        //        return Json(new { Success = 1, BId = Cat_BuildingType.BId, ex = TempData["Message"].ToString() });
        //    }
        //    catch (Exception ex)
        //    {
        //        return Json(new { Success = 0, ex = ex.InnerException.InnerException.Message.ToString() });
        //    }
        //}
        //#endregion


        //#region Emp Type
        //public IActionResult EmpTypeList()
        //{
        //    TempData["Message"] = "Data Load Successfully";
        //    TempData["Status"] = "1";
        //    tranlog.TransactionLog(RouteData.Values["controller"].ToString(), RouteData.Values["action"].ToString(), TempData["Message"].ToString(), "", "List Show", "");

        //    return View(_empTypeRepository.All().ToList());
        //}

        //public IActionResult CreateEmpType()
        //{
        //    ViewBag.ActionType = "Create";
        //    return View();
        //}

        //[HttpPost]
        //public IActionResult CreateEmpType(Cat_Emp_Type Cat_Emp_Type)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        if (Cat_Emp_Type.EmpTypeId > 0)
        //        {
        //            _empTypeRepository.Update(Cat_Emp_Type);

        //            TempData["Message"] = "Data Update Successfully";
        //            TempData["Status"] = "2";
        //            tranlog.TransactionLog(RouteData.Values["controller"].ToString(), RouteData.Values["action"].ToString(), TempData["Message"].ToString(), Cat_Emp_Type.EmpTypeId.ToString(), "Update", Cat_Emp_Type.EmpTypeName.ToString());

        //        }
        //        else
        //        {
        //            _empTypeRepository.Add(Cat_Emp_Type);

        //            TempData["Message"] = "Data Save Successfully";
        //            TempData["Status"] = "1";
        //            tranlog.TransactionLog(RouteData.Values["controller"].ToString(), RouteData.Values["action"].ToString(), TempData["Message"].ToString(), Cat_Emp_Type.EmpTypeId.ToString(), "Create", Cat_Emp_Type.EmpTypeName.ToString());

        //        }
        //        return RedirectToAction("EmpTypeList", "HRVariable");
        //    }
        //    return View(Cat_Emp_Type);
        //}

        //public IActionResult EditEmpType(int id)
        //{
        //    if (id == null)
        //    {
        //        return NotFound();
        //    }
        //    ViewBag.ActionType = "Edit";
        //    var Cat_Emp_Type = _empTypeRepository.Find(id);
        //    if (Cat_Emp_Type == null)
        //    {
        //        return NotFound();
        //    }
        //    return View("CreateEmpType", Cat_Emp_Type);
        //}

        //public IActionResult DeleteEmpType(int id)
        //{
        //    if (id == null)
        //    {
        //        return NotFound();
        //    }

        //    var Cat_Emp_Type = _empTypeRepository.Find(id);

        //    if (Cat_Emp_Type == null)
        //    {
        //        return NotFound();
        //    }

        //    ViewBag.ActionType = "Delete";

        //    return View("CreateEmpType", Cat_Emp_Type);
        //}

        //[HttpPost, ActionName("DeleteEmpType")]
        //public IActionResult DeleteEmpTypeConfirmed(int id)
        //{
        //    try
        //    {
        //        var Cat_Emp_Type = _empTypeRepository.Find(id);
        //        _empTypeRepository.Delete(Cat_Emp_Type);

        //        TempData["Message"] = "Data Delete Successfully";
        //        TempData["Status"] = "3";
        //        tranlog.TransactionLog(RouteData.Values["controller"].ToString(), RouteData.Values["action"].ToString(), TempData["Message"].ToString(), Cat_Emp_Type.EmpTypeId.ToString(), "Delete", Cat_Emp_Type.EmpTypeName);

        //        return Json(new { Success = 1, EmpTypeId = Cat_Emp_Type.EmpTypeId, ex = TempData["Message"].ToString() });
        //    }
        //    catch (Exception ex)
        //    {
        //        return Json(new { Success = 0, ex = ex.InnerException.InnerException.Message.ToString() });
        //    }
        //}
        //#endregion


        //#region Bus Stop
        //public IActionResult BusStopList()
        //{
        //    TempData["Message"] = "Data Load Successfully";
        //    TempData["Status"] = "1";
        //    tranlog.TransactionLog(RouteData.Values["controller"].ToString(), RouteData.Values["action"].ToString(), TempData["Message"].ToString(), "", "List Show", "");

        //    return View(_busStopRepository.GetAll().ToList());
        //}

        //public IActionResult CreateBusStop()
        //{
        //    ViewBag.ActionType = "Create";
        //    return View();
        //}

        //[HttpPost]
        //public IActionResult CreateBusStop(Cat_BusStop Cat_BusStop)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        if (Cat_BusStop.BusStopId > 0)
        //        {
        //            _busStopRepository.Update(Cat_BusStop);

        //            TempData["Message"] = "Data Update Successfully";
        //            TempData["Status"] = "2";
        //            tranlog.TransactionLog(RouteData.Values["controller"].ToString(), RouteData.Values["action"].ToString(), TempData["Message"].ToString(), Cat_BusStop.BusStopId.ToString(), "Update", Cat_BusStop.BusStopName.ToString());

        //        }
        //        else
        //        {
        //            _busStopRepository.Add(Cat_BusStop);

        //            TempData["Message"] = "Data Save Successfully";
        //            TempData["Status"] = "1";
        //            tranlog.TransactionLog(RouteData.Values["controller"].ToString(), RouteData.Values["action"].ToString(), TempData["Message"].ToString(), Cat_BusStop.BusStopId.ToString(), "Create", Cat_BusStop.BusStopName.ToString());

        //        }
        //        return RedirectToAction("BusStopList", "HRVariable");
        //    }
        //    return View(Cat_BusStop);
        //}

        //public IActionResult EditBusStop(int id)
        //{
        //    if (id == null)
        //    {
        //        return NotFound();
        //    }
        //    ViewBag.ActionType = "Edit";
        //    var Cat_BusStop = _busStopRepository.Find(id);
        //    if (Cat_BusStop == null)
        //    {
        //        return NotFound();
        //    }
        //    return View("CreateBusStop", Cat_BusStop);
        //}

        //public IActionResult DeleteBusStop(int id)
        //{
        //    if (id == null)
        //    {
        //        return NotFound();
        //    }

        //    var Cat_BusStop = _busStopRepository.Find(id);

        //    if (Cat_BusStop == null)
        //    {
        //        return NotFound();
        //    }

        //    ViewBag.ActionType = "Delete";

        //    return View("CreateBusStop", Cat_BusStop);
        //}

        //[HttpPost, ActionName("DeleteBusStop")]
        //public IActionResult DeleteBusStopConfirmed(int id)
        //{
        //    try
        //    {
        //        var Cat_BusStop = _busStopRepository.Find(id);
        //        _busStopRepository.Delete(Cat_BusStop);

        //        TempData["Message"] = "Data Delete Successfully";
        //        TempData["Status"] = "3";
        //        tranlog.TransactionLog(RouteData.Values["controller"].ToString(), RouteData.Values["action"].ToString(), TempData["Message"].ToString(), Cat_BusStop.BusStopId.ToString(), "Delete", Cat_BusStop.BusStopName);

        //        return Json(new { Success = 1, BusStopId = Cat_BusStop.BusStopId, ex = TempData["Message"].ToString() });
        //    }
        //    catch (Exception ex)
        //    {
        //        return Json(new { Success = 0, ex = ex.InnerException.InnerException.Message.ToString() });
        //    }
        //}
        //#endregion


        //#region Meeting
        //public IActionResult MeetingList()
        //{
        //    TempData["Message"] = "Data Load Successfully";
        //    TempData["Status"] = "1";
        //    tranlog.TransactionLog(RouteData.Values["controller"].ToString(), RouteData.Values["action"].ToString(), TempData["Message"].ToString(), "", "List Show", "");

        //    return View(_meetingRepository.GetAll().ToList());
        //}

        //public IActionResult CreateMeeting()
        //{
        //    ViewBag.ActionType = "Create";
        //    // this variable data is changed when add variable controller.
        //    ViewBag.MeetingType = _meetingRepository.GetMeetingList();
        //    return View();
        //}

        //[HttpPost]
        //public IActionResult CreateMeeting(Cat_Meeting Cat_Meeting)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        if (Cat_Meeting.MeetingId > 0)
        //        {
        //            _meetingRepository.Update(Cat_Meeting);

        //            TempData["Message"] = "Data Update Successfully";
        //            TempData["Status"] = "2";
        //            tranlog.TransactionLog(RouteData.Values["controller"].ToString(), RouteData.Values["action"].ToString(), TempData["Message"].ToString(), Cat_Meeting.MeetingId.ToString(), "Update", Cat_Meeting.Meeting.ToString());

        //        }
        //        else
        //        {
        //            _meetingRepository.Add(Cat_Meeting);

        //            TempData["Message"] = "Data Save Successfully";
        //            TempData["Status"] = "1";
        //            tranlog.TransactionLog(RouteData.Values["controller"].ToString(), RouteData.Values["action"].ToString(), TempData["Message"].ToString(), Cat_Meeting.MeetingId.ToString(), "Create", Cat_Meeting.Meeting.ToString());

        //        }
        //        // this variable data is changed when add variable controller.
        //        ViewBag.MeetingType = _meetingRepository.GetMeetingList();
        //        return RedirectToAction("MeetingList", "HRVariable");
        //    }
        //    return View(Cat_Meeting);
        //}

        //public IActionResult EditMeeting(int id)
        //{
        //    if (id == null)
        //    {
        //        return NotFound();
        //    }
        //    ViewBag.ActionType = "Edit";
        //    // this variable data is changed when add variable controller.
        //    ViewBag.MeetingType = _meetingRepository.GetMeetingList();
        //    var Cat_Meeting = _meetingRepository.Find(id);
        //    if (Cat_Meeting == null)
        //    {
        //        return NotFound();
        //    }
        //    return View("CreateMeeting", Cat_Meeting);
        //}

        //public IActionResult DeleteMeeting(int id)
        //{

        //    if (id == null)
        //    {
        //        return NotFound();
        //    }

        //    var Cat_Meeting = _meetingRepository.Find(id);

        //    if (Cat_Meeting == null)
        //    {
        //        return NotFound();
        //    }

        //    ViewBag.ActionType = "Delete";
        //    // this variable data is changed when add variable controller.
        //    ViewBag.MeetingType = _meetingRepository.GetMeetingList();
        //    return View("CreateMeeting", Cat_Meeting);
        //}

        //[HttpPost, ActionName("DeleteMeeting")]
        //public IActionResult DeleteMeetingConfirmed(int id)
        //{
        //    ViewBag.MeetingType = _meetingRepository.GetMeetingList();
        //    try
        //    {
        //        var Cat_Meeting = _meetingRepository.Find(id);
        //        _meetingRepository.Delete(Cat_Meeting);

        //        TempData["Message"] = "Data Delete Successfully";
        //        TempData["Status"] = "3";
        //        tranlog.TransactionLog(RouteData.Values["controller"].ToString(), RouteData.Values["action"].ToString(), TempData["Message"].ToString(), Cat_Meeting.MeetingId.ToString(), "Delete", Cat_Meeting.Meeting);

        //        return Json(new { Success = 1, MeetingId = Cat_Meeting.MeetingId, ex = TempData["Message"].ToString() });
        //    }
        //    catch (Exception ex)
        //    {
        //        return Json(new { Success = 0, ex = ex.InnerException.InnerException.Message.ToString() });
        //    }
        //}
        //#endregion


        //#region Location
        //public IActionResult LocationList()
        //{
        //    TempData["Message"] = "Data Load Successfully";
        //    TempData["Status"] = "1";
        //    tranlog.TransactionLog(RouteData.Values["controller"].ToString(), RouteData.Values["action"].ToString(), TempData["Message"].ToString(), "", "List Show", "");

        //    return View(_locationRepository.GetAll().ToList());
        //}

        //public IActionResult CreateLocation()
        //{
        //    ViewBag.ActionType = "Create";
        //    return View();
        //}

        //[HttpPost]
        //public IActionResult CreateLocation(Cat_Location Cat_Location)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        if (Cat_Location.LId > 0)
        //        {
        //            _locationRepository.Update(Cat_Location);

        //            TempData["Message"] = "Data Update Successfully";
        //            TempData["Status"] = "2";
        //            tranlog.TransactionLog(RouteData.Values["controller"].ToString(), RouteData.Values["action"].ToString(), TempData["Message"].ToString(), Cat_Location.LId.ToString(), "Update", Cat_Location.LocationName.ToString());

        //        }
        //        else
        //        {
        //            _locationRepository.Add(Cat_Location);

        //            TempData["Message"] = "Data Save Successfully";
        //            TempData["Status"] = "1";
        //            tranlog.TransactionLog(RouteData.Values["controller"].ToString(), RouteData.Values["action"].ToString(), TempData["Message"].ToString(), Cat_Location.LId.ToString(), "Create", Cat_Location.LocationName.ToString());

        //        }
        //        return RedirectToAction("LocationList", "HRVariable");
        //    }
        //    return View(Cat_Location);
        //}

        //public IActionResult EditLocation(int id)
        //{
        //    if (id == null)
        //    {
        //        return NotFound();
        //    }
        //    ViewBag.ActionType = "Edit";
        //    var Cat_Location = _locationRepository.Find(id);
        //    if (Cat_Location == null)
        //    {
        //        return NotFound();
        //    }
        //    return View("CreateLocation", Cat_Location);
        //}

        //public IActionResult DeleteLocation(int id)
        //{
        //    if (id == null)
        //    {
        //        return NotFound();
        //    }

        //    var Cat_Location = _locationRepository.Find(id);

        //    if (Cat_Location == null)
        //    {
        //        return NotFound();
        //    }

        //    ViewBag.ActionType = "Delete";

        //    return View("CreateLocation", Cat_Location);
        //}

        //[HttpPost, ActionName("DeleteLocation")]
        //public IActionResult DeleteLocationConfirmed(int id)
        //{
        //    try
        //    {
        //        var Cat_Location = _locationRepository.Find(id);
        //        _locationRepository.Delete(Cat_Location);

        //        TempData["Message"] = "Data Delete Successfully";
        //        TempData["Status"] = "3";
        //        tranlog.TransactionLog(RouteData.Values["controller"].ToString(), RouteData.Values["action"].ToString(), TempData["Message"].ToString(), Cat_Location.LId.ToString(), "Delete", Cat_Location.LocationName);

        //        return Json(new { Success = 1, LocationId = Cat_Location.LId, ex = TempData["Message"].ToString() });
        //    }
        //    catch (Exception ex)
        //    {
        //        return Json(new { Success = 0, ex = ex.InnerException.InnerException.Message.ToString() });
        //    }
        //}
        //#endregion


        //#region District
        //public IActionResult DistrictList()
        //{
        //    var ComId = HttpContext.Session.GetInt32("ComId");;
        //    TempData["Message"] = "Data Load Successfully";
        //    TempData["Status"] = "1";
        //    tranlog.TransactionLog(RouteData.Values["controller"].ToString(), RouteData.Values["action"].ToString(), TempData["Message"].ToString(), "", "List Show", "");

        //    return View(_districtRepository.GetAllDistrict().ToList());
        //}

        //public IActionResult CreateDistrict()
        //{
        //    ViewBag.ActionType = "Create";
        //    return View();
        //}

        //[HttpPost]
        //public IActionResult CreateDistrict(Cat_District Cat_District)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        if (Cat_District.DistId > 0)
        //        {
        //            _districtRepository.Update(Cat_District);

        //            TempData["Message"] = "Data Update Successfully";
        //            TempData["Status"] = "2";
        //            tranlog.TransactionLog(RouteData.Values["controller"].ToString(), RouteData.Values["action"].ToString(), TempData["Message"].ToString(), Cat_District.DistId.ToString(), "Update", Cat_District.DistName.ToString());

        //        }
        //        else
        //        {
        //            _districtRepository.Add(Cat_District);

        //            TempData["Message"] = "Data Save Successfully";
        //            TempData["Status"] = "1";
        //            tranlog.TransactionLog(RouteData.Values["controller"].ToString(), RouteData.Values["action"].ToString(), TempData["Message"].ToString(), Cat_District.DistId.ToString(), "Create", Cat_District.DistName.ToString());

        //        }
        //        return RedirectToAction("DistrictList", "HRVariable");
        //    }
        //    return View(Cat_District);
        //}

        //public IActionResult EditDistrict(int id)
        //{
        //    if (id == null)
        //    {
        //        return NotFound();
        //    }
        //    ViewBag.ActionType = "Edit";
        //    var Cat_District = _districtRepository.Find(id);
        //    if (Cat_District == null)
        //    {
        //        return NotFound();
        //    }
        //    return View("CreateDistrict", Cat_District);
        //}

        //public IActionResult DeleteDistrict(int id)
        //{
        //    if (id == null)
        //    {
        //        return NotFound();
        //    }

        //    var Cat_District = _districtRepository.Find(id);

        //    if (Cat_District == null)
        //    {
        //        return NotFound();
        //    }

        //    ViewBag.ActionType = "Delete";

        //    return View("CreateDistrict", Cat_District);
        //}

        //[HttpPost, ActionName("DeleteDistrict")]
        //public IActionResult DeleteDistrictConfirmed(int id)
        //{
        //    try
        //    {
        //        var Cat_District = _districtRepository.Find(id);
        //        _districtRepository.Delete(Cat_District);

        //        TempData["Message"] = "Data Delete Successfully";
        //        TempData["Status"] = "3";
        //        tranlog.TransactionLog(RouteData.Values["controller"].ToString(), RouteData.Values["action"].ToString(), TempData["Message"].ToString(), Cat_District.DistId.ToString(), "Delete", Cat_District.DistName);

        //        return Json(new { Success = 1, DistId = Cat_District.DistId, ex = TempData["Message"].ToString() });
        //    }
        //    catch (Exception ex)
        //    {
        //        return Json(new { Success = 0, ex = ex.InnerException.InnerException.Message.ToString() });
        //    }
        //}
        //#endregion


        //#region Police Station
        //public IActionResult PoliceStationList()
        //{
        //    TempData["Message"] = "Data Load Successfully";
        //    TempData["Status"] = "1";
        //    tranlog.TransactionLog(RouteData.Values["controller"].ToString(), RouteData.Values["action"].ToString(), TempData["Message"].ToString(), "", "List Show", "");

        //    return View(_policeStationRepository.GetPSList().ToList());
        //}

        //public IActionResult CreatePoliceStation()
        //{
        //    ViewBag.ActionType = "Create";

        //    ViewBag.DistId = _districtRepository.GetAllForDropDown();
        //    return View();
        //}

        //[HttpPost]
        //public IActionResult CreatePoliceStation(Cat_PoliceStation Cat_PoliceStation)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        if (Cat_PoliceStation.PStationId > 0)
        //        {
        //            _policeStationRepository.Update(Cat_PoliceStation);

        //            TempData["Message"] = "Data Update Successfully";
        //            TempData["Status"] = "2";
        //            tranlog.TransactionLog(RouteData.Values["controller"].ToString(), RouteData.Values["action"].ToString(), TempData["Message"].ToString(), Cat_PoliceStation.PStationId.ToString(), "Update", Cat_PoliceStation.PStationName.ToString());

        //        }
        //        else
        //        {
        //            _policeStationRepository.Add(Cat_PoliceStation);

        //            TempData["Message"] = "Data Save Successfully";
        //            TempData["Status"] = "1";
        //            tranlog.TransactionLog(RouteData.Values["controller"].ToString(), RouteData.Values["action"].ToString(), TempData["Message"].ToString(), Cat_PoliceStation.PStationId.ToString(), "Create", Cat_PoliceStation.PStationName.ToString());

        //        }
        //        return RedirectToAction("PoliceStationList", "HRVariable");

        //    }
        //    ViewBag.DistId = _districtRepository.GetAllForDropDown();
        //    return View(Cat_PoliceStation);
        //}

        //public IActionResult EditPoliceStation(int id)
        //{
        //    if (id == null)
        //    {
        //        return NotFound();
        //    }
        //    ViewBag.ActionType = "Edit";
        //    ViewBag.DistId = _districtRepository.GetAllForDropDown();
        //    var Cat_PoliceStation = _policeStationRepository.Find(id);
        //    if (Cat_PoliceStation == null)
        //    {
        //        return NotFound();
        //    }
        //    return View("CreatePoliceStation", Cat_PoliceStation);
        //}

        //public IActionResult DeletePoliceStation(int id)
        //{
        //    if (id == null)
        //    {
        //        return NotFound();
        //    }

        //    var Cat_PoliceStation = _policeStationRepository.Find(id);
        //    ViewBag.DistId = _districtRepository.GetAllForDropDown();
        //    if (Cat_PoliceStation == null)
        //    {
        //        return NotFound();
        //    }

        //    ViewBag.ActionType = "Delete";

        //    return View("CreatePoliceStation", Cat_PoliceStation);
        //}

        //[HttpPost, ActionName("DeletePoliceStation")]
        //public IActionResult DeletePoliceStationConfirmed(int id)
        //{
        //    ViewBag.DistId = _districtRepository.GetAllForDropDown();
        //    try
        //    {
        //        var Cat_PoliceStation = _policeStationRepository.Find(id);
        //        _policeStationRepository.Delete(Cat_PoliceStation);

        //        TempData["Message"] = "Data Delete Successfully";
        //        TempData["Status"] = "3";
        //        tranlog.TransactionLog(RouteData.Values["controller"].ToString(), RouteData.Values["action"].ToString(), TempData["Message"].ToString(), Cat_PoliceStation.PStationId.ToString(), "Delete", Cat_PoliceStation.PStationName);

        //        return Json(new { Success = 1, PSId = Cat_PoliceStation.PStationId, ex = TempData["Message"].ToString() });
        //    }
        //    catch (Exception ex)
        //    {
        //        return Json(new { Success = 0, ex = ex.InnerException.InnerException.Message.ToString() });
        //    }
        //}
        //#endregion


        //#region Post Office
        //public IActionResult PostOfficeList()
        //{
        //    TempData["Message"] = "Data Load Successfully";
        //    TempData["Status"] = "1";
        //    tranlog.TransactionLog(RouteData.Values["controller"].ToString(), RouteData.Values["action"].ToString(), TempData["Message"].ToString(), "", "List Show", "");

        //    return View(_postOfficeRepository.GetPOList().ToList());
        //}
        //[HttpGet]
        //public IActionResult GetPoliceStation(int id)
        //{
        //    var ComId = HttpContext.Session.GetInt32("ComId");;
        //    var data = _policeStationRepository.GetPSList().Where(p => p.DistId == id).ToList();
        //    return Json(data);
        //}

        //public IActionResult CreatePostOffice()
        //{
        //    ViewBag.ActionType = "Create";

        //    ViewBag.DistId = _districtRepository.GetAllForDropDown();
        //    return View();
        //}

        //[HttpPost]
        //public IActionResult CreatePostOffice(Cat_PostOffice Cat_PostOffice)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        if (Cat_PostOffice.POId > 0)
        //        {
        //            _postOfficeRepository.Update(Cat_PostOffice);

        //            TempData["Message"] = "Data Update Successfully";
        //            TempData["Status"] = "2";
        //            tranlog.TransactionLog(RouteData.Values["controller"].ToString(), RouteData.Values["action"].ToString(), TempData["Message"].ToString(), Cat_PostOffice.POId.ToString(), "Update", Cat_PostOffice.POName.ToString());

        //        }
        //        else
        //        {
        //            _postOfficeRepository.Add(Cat_PostOffice);

        //            TempData["Message"] = "Data Save Successfully";
        //            TempData["Status"] = "1";
        //            tranlog.TransactionLog(RouteData.Values["controller"].ToString(), RouteData.Values["action"].ToString(), TempData["Message"].ToString(), Cat_PostOffice.POId.ToString(), "Create", Cat_PostOffice.POName.ToString());

        //        }
        //        return RedirectToAction("PostOfficeList", "HRVariable");

        //    }
        //    ViewBag.DistId = _districtRepository.GetAllForDropDown();
        //    return View(Cat_PostOffice);
        //}

        //public IActionResult EditPostOffice(int id)
        //{
        //    if (id == null)
        //    {
        //        return NotFound();
        //    }
        //    ViewBag.ActionType = "Edit";
        //    ViewBag.DistId = _districtRepository.GetAllForDropDown();
        //    var Cat_PostOffice = _postOfficeRepository.Find(id);
        //    if (Cat_PostOffice == null)
        //    {
        //        return NotFound();
        //    }
        //    return View("CreatePostOffice", Cat_PostOffice);
        //}

        //public IActionResult DeletePostOffice(int id)
        //{
        //    if (id == null)
        //    {
        //        return NotFound();
        //    }

        //    var Cat_PostOffice = _postOfficeRepository.Find(id);
        //    ViewBag.DistId = _districtRepository.GetAllForDropDown();
        //    if (Cat_PostOffice == null)
        //    {
        //        return NotFound();
        //    }

        //    ViewBag.ActionType = "Delete";

        //    return View("CreatePostOffice", Cat_PostOffice);
        //}

        //[HttpPost, ActionName("DeletePostOffice")]
        //public IActionResult DeletePostOfficeConfirmed(int id)
        //{
        //    ViewBag.DistId = _districtRepository.GetAllForDropDown();
        //    try
        //    {
        //        var Cat_PostOffice = _postOfficeRepository.Find(id);
        //        _postOfficeRepository.Delete(Cat_PostOffice);

        //        TempData["Message"] = "Data Delete Successfully";
        //        TempData["Status"] = "3";
        //        tranlog.TransactionLog(RouteData.Values["controller"].ToString(), RouteData.Values["action"].ToString(), TempData["Message"].ToString(), Cat_PostOffice.POId.ToString(), "Delete", Cat_PostOffice.POName);

        //        return Json(new { Success = 1, POId = Cat_PostOffice.POId, ex = TempData["Message"].ToString() });
        //    }
        //    catch (Exception ex)
        //    {
        //        return Json(new { Success = 0, ex = ex.InnerException.InnerException.Message.ToString() });
        //    }
        //}
        //#endregion


        //#region Style
        //public IActionResult StyleList()
        //{
        //    TempData["Message"] = "Data Load Successfully";
        //    TempData["Status"] = "1";
        //    tranlog.TransactionLog(RouteData.Values["controller"].ToString(), RouteData.Values["action"].ToString(), TempData["Message"].ToString(), "", "List Show", "");

        //    return View(_styleRepository.GetAll().ToList());
        //}

        //public IActionResult CreateStyle()
        //{
        //    ViewBag.Color = _styleRepository.GetColor();
        //    ViewBag.Size = _styleRepository.GetSize();
        //    ViewBag.ActionType = "Create";
        //    return View();
        //}

        //[HttpPost]
        //public IActionResult CreateStyle(Cat_Style Cat_Style)
        //{
        //    ViewBag.StyleDate = DateTime.Now;
        //    if (ModelState.IsValid)
        //    {
        //        if (Cat_Style.StyleId > 0)
        //        {
        //            _styleRepository.Update(Cat_Style);

        //            TempData["Message"] = "Data Update Successfully";
        //            TempData["Status"] = "2";
        //            tranlog.TransactionLog(RouteData.Values["controller"].ToString(), RouteData.Values["action"].ToString(), TempData["Message"].ToString(), Cat_Style.StyleId.ToString(), "Update", Cat_Style.StyleName.ToString());

        //        }
        //        else
        //        {
        //            _styleRepository.Add(Cat_Style);

        //            TempData["Message"] = "Data Save Successfully";
        //            TempData["Status"] = "1";
        //            tranlog.TransactionLog(RouteData.Values["controller"].ToString(), RouteData.Values["action"].ToString(), TempData["Message"].ToString(), Cat_Style.StyleId.ToString(), "Create", Cat_Style.StyleName.ToString());

        //        }
        //        return RedirectToAction("StyleList", "HRVariable");
        //    }
        //    return View(Cat_Style);
        //}

        //public IActionResult EditStyle(int id)
        //{
        //    ViewBag.StyleDate = DateTime.Now;
        //    ViewBag.Color = _styleRepository.GetColor();
        //    ViewBag.Size = _styleRepository.GetSize();
        //    if (id == null)
        //    {
        //        return NotFound();
        //    }
        //    ViewBag.ActionType = "Edit";
        //    var Cat_Style = _styleRepository.Find(id);
        //    if (Cat_Style == null)
        //    {
        //        return NotFound();
        //    }
        //    return View("CreateStyle", Cat_Style);
        //}

        //public IActionResult DeleteStyle(int id)
        //{
        //    ViewBag.StyleDate = DateTime.Now;
        //    ViewBag.Color = _styleRepository.GetColor();
        //    ViewBag.Size = _styleRepository.GetSize();
        //    if (id == null)
        //    {
        //        return NotFound();
        //    }

        //    var Cat_Style = _styleRepository.Find(id);

        //    if (Cat_Style == null)
        //    {
        //        return NotFound();
        //    }

        //    ViewBag.ActionType = "Delete";

        //    return View("CreateStyle", Cat_Style);
        //}

        //[HttpPost, ActionName("DeleteStyle")]
        //public IActionResult DeleteStyleConfirmed(int id)
        //{

        //    try
        //    {
        //        var Cat_Style = _styleRepository.Find(id);
        //        _styleRepository.Delete(Cat_Style);

        //        TempData["Message"] = "Data Delete Successfully";
        //        TempData["Status"] = "3";
        //        tranlog.TransactionLog(RouteData.Values["controller"].ToString(), RouteData.Values["action"].ToString(), TempData["Message"].ToString(), Cat_Style.StyleId.ToString(), "Delete", Cat_Style.StyleName);

        //        return Json(new { Success = 1, StyleId = Cat_Style.StyleId, ex = TempData["Message"].ToString() });
        //    }
        //    catch (Exception ex)
        //    {
        //        return Json(new { Success = 0, ex = ex.InnerException.InnerException.Message.ToString() });
        //    }
        //}
        //#endregion


        //#region Unit
        //public IActionResult UnitList()
        //{
        //    TempData["Message"] = "Data Load Successfully";
        //    TempData["Status"] = "1";
        //    tranlog.TransactionLog(RouteData.Values["controller"].ToString(), RouteData.Values["action"].ToString(), TempData["Message"].ToString(), "", "List Show", "");

        //    return View(_unitRepository.All().ToList());
        //}

        //public IActionResult CreateUnit()
        //{
        //    ViewBag.ActionType = "Create";
        //    return View();
        //}

        //[HttpPost]
        //public IActionResult CreateUnit(Unit Unit)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        if (Unit.UnitId > 0)
        //        {
        //            _unitRepository.Update(Unit);

        //            TempData["Message"] = "Data Update Successfully";
        //            TempData["Status"] = "2";
        //            tranlog.TransactionLog(RouteData.Values["controller"].ToString(), RouteData.Values["action"].ToString(), TempData["Message"].ToString(), Unit.UnitId.ToString(), "Update", Unit.UnitName.ToString());

        //        }
        //        else
        //        {
        //            _unitRepository.Add(Unit);

        //            TempData["Message"] = "Data Save Successfully";
        //            TempData["Status"] = "1";
        //            tranlog.TransactionLog(RouteData.Values["controller"].ToString(), RouteData.Values["action"].ToString(), TempData["Message"].ToString(), Unit.UnitId.ToString(), "Create", Unit.UnitName.ToString());

        //        }
        //        return RedirectToAction("UnitList", "HRVariable");
        //    }
        //    return View(Unit);
        //}

        //public IActionResult EditUnit(int id)
        //{
        //    if (id == null)
        //    {
        //        return NotFound();
        //    }
        //    ViewBag.ActionType = "Edit";
        //    var Unit = _unitRepository.Find(id);
        //    if (Unit == null)
        //    {
        //        return NotFound();
        //    }
        //    return View("CreateUnit", Unit);
        //}

        //public IActionResult DeleteUnit(int id)
        //{
        //    if (id == null)
        //    {
        //        return NotFound();
        //    }

        //    var Unit = _unitRepository.Find(id);

        //    if (Unit == null)
        //    {
        //        return NotFound();
        //    }

        //    ViewBag.ActionType = "Delete";

        //    return View("CreateUnit", Unit);
        //}

        //[HttpPost, ActionName("DeleteUnit")]
        //public IActionResult DeleteUnitConfirmed(int id)
        //{
        //    try
        //    {
        //        var Unit = _unitRepository.Find(id);
        //        _unitRepository.Delete(Unit);

        //        TempData["Message"] = "Data Delete Successfully";
        //        TempData["Status"] = "3";
        //        tranlog.TransactionLog(RouteData.Values["controller"].ToString(), RouteData.Values["action"].ToString(), TempData["Message"].ToString(), Unit.UnitId.ToString(), "Delete", Unit.UnitName);

        //        return Json(new { Success = 1, UnitId = Unit.UnitId, ex = TempData["Message"].ToString() });
        //    }
        //    catch (Exception ex)
        //    {
        //        return Json(new { Success = 0, ex = ex.InnerException.InnerException.Message.ToString() });
        //    }
        //}
        //#endregion


        //#region Supplier
        //public IActionResult SupplierList()
        //{
        //    TempData["Message"] = "Data Load Successfully";
        //    TempData["Status"] = "1";
        //    tranlog.TransactionLog(RouteData.Values["controller"].ToString(), RouteData.Values["action"].ToString(), TempData["Message"].ToString(), "", "List Show", "");

        //    return View(_supplierRepository.GetAll().ToList());
        //}


        //public JsonResult getPoliceStation(int id)
        //{
        //    List<Cat_PoliceStation> PStation = _policeStationRepository.GetPSList().Where(x => x.DistId == id).ToList();

        //    List<SelectListItem> lipstation = new List<SelectListItem>();

        //    //licities.Add(new SelectListItem { Text = "--Select State--", Value = "0" });
        //    if (PStation != null)
        //    {
        //        foreach (Cat_PoliceStation x in PStation)
        //        {
        //            lipstation.Add(new SelectListItem { Text = x.PStationName, Value = x.PStationId.ToString() });
        //        }
        //    }
        //    return Json(new SelectList(lipstation, "Value", "Text"));
        //}

        //public IActionResult CreateSupplier()
        //{
        //    ViewBag.CountryId = _countryRepository.GetCountryList();
        //    ViewBag.DistId = _districtRepository.GetAllForDropDown();
        //    ViewBag.ActionType = "Create";
        //    return View();
        //}

        //[HttpPost]
        //public IActionResult CreateSupplier(Supplier Supplier)
        //{

        //    ViewBag.CountryId = _countryRepository.GetCountryList();
        //    ViewBag.DistId = _districtRepository.GetAllForDropDown();
        //    if (ModelState.IsValid)
        //    {
        //        if (Supplier.SupplierId > 0)
        //        {
        //            _supplierRepository.Update(Supplier);

        //            TempData["Message"] = "Data Update Successfully";
        //            TempData["Status"] = "2";
        //            tranlog.TransactionLog(RouteData.Values["controller"].ToString(), RouteData.Values["action"].ToString(), TempData["Message"].ToString(), Supplier.SupplierId.ToString(), "Update", Supplier.SupplierName.ToString());

        //        }
        //        else
        //        {
        //            _supplierRepository.Add(Supplier);

        //            TempData["Message"] = "Data Save Successfully";
        //            TempData["Status"] = "1";
        //            tranlog.TransactionLog(RouteData.Values["controller"].ToString(), RouteData.Values["action"].ToString(), TempData["Message"].ToString(), Supplier.SupplierId.ToString(), "Create", Supplier.SupplierName.ToString());

        //        }
        //        return RedirectToAction("SupplierList", "HRVariable");
        //    }
        //    return View(Supplier);
        //}

        //public IActionResult EditSupplier(int id)
        //{
        //    ViewBag.CountryId = _countryRepository.GetCountryList();
        //    ViewBag.DistId = _districtRepository.GetAllForDropDown();
        //    if (id == null)
        //    {
        //        return NotFound();
        //    }
        //    ViewBag.ActionType = "Edit";
        //    var Supplier = _supplierRepository.Find(id);
        //    if (Supplier == null)
        //    {
        //        return NotFound();
        //    }
        //    return View("CreateSupplier", Supplier);
        //}

        //public IActionResult DeleteSupplier(int id)
        //{
        //    ViewBag.CountryId = _countryRepository.GetCountryList();
        //    ViewBag.DistId = _districtRepository.GetAllForDropDown();
        //    if (id == null)
        //    {
        //        return NotFound();
        //    }

        //    var Supplier = _supplierRepository.Find(id);

        //    if (Supplier == null)
        //    {
        //        return NotFound();
        //    }

        //    ViewBag.ActionType = "Delete";

        //    return View("CreateSupplier", Supplier);
        //}

        //[HttpPost, ActionName("DeleteSupplier")]
        //public IActionResult DeleteSupplierConfirmed(int id)
        //{
        //    ViewBag.CountryId = _countryRepository.GetCountryList();
        //    ViewBag.DistId = _districtRepository.GetAllForDropDown();
        //    try
        //    {
        //        var Supplier = _supplierRepository.Find(id);
        //        _supplierRepository.Delete(Supplier);

        //        TempData["Message"] = "Data Delete Successfully";
        //        TempData["Status"] = "3";
        //        tranlog.TransactionLog(RouteData.Values["controller"].ToString(), RouteData.Values["action"].ToString(), TempData["Message"].ToString(), Supplier.SupplierId.ToString(), "Delete", Supplier.SupplierName);

        //        return Json(new { Success = 1, SupplierId = Supplier.SupplierId, ex = TempData["Message"].ToString() });
        //    }
        //    catch (Exception ex)
        //    {
        //        return Json(new { Success = 0, ex = ex.InnerException.InnerException.Message.ToString() });
        //    }
        //}
        //#endregion


        //#region Summer Winter Allowance
        //public IActionResult SWAllowanceList()
        //{
        //    TempData["Message"] = "Data Load Successfully";
        //    TempData["Status"] = "1";
        //    tranlog.TransactionLog(RouteData.Values["controller"].ToString(), RouteData.Values["action"].ToString(), TempData["Message"].ToString(), "", "List Show", "");

        //    return View(_summerWinterAllowanceRepository.GetAll().ToList());
        //}

        //public IActionResult CreateSWAllowance()
        //{
        //    ViewBag.ActionType = "Create";
        //    return View();
        //}

        //[HttpPost]
        //public IActionResult CreateSWAllowance(Cat_SummerWinterAllowanceSetting SWSetting)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        if (SWSetting.SWAllowanceId > 0)
        //        {
        //            var check = _summerWinterAllowanceRepository.GetAll().Where(s => s.ProssType == SWSetting.ProssType && s.SWAllowanceId != SWSetting.SWAllowanceId).FirstOrDefault();
        //            if (check != null)
        //            {
        //                _summerWinterAllowanceRepository.Update(SWSetting);

        //                TempData["Message"] = "Data Update Successfully";
        //                TempData["Status"] = "2";
        //                tranlog.TransactionLog(RouteData.Values["controller"].ToString(), RouteData.Values["action"].ToString(), TempData["Message"].ToString(), SWSetting.SWAllowanceId.ToString(), "Update", SWSetting.ProssType.ToString());

        //            }
        //        }

        //        else
        //        {
        //            var check = _summerWinterAllowanceRepository.GetAll().Where(s => s.ProssType == SWSetting.ProssType && s.SWAllowanceId != SWSetting.SWAllowanceId).FirstOrDefault();
        //            if (check != null)
        //            {
        //                _summerWinterAllowanceRepository.Add(SWSetting);

        //                TempData["Message"] = "Data Save Successfully";
        //                TempData["Status"] = "1";
        //                tranlog.TransactionLog(RouteData.Values["controller"].ToString(), RouteData.Values["action"].ToString(), TempData["Message"].ToString(), SWSetting.SWAllowanceId.ToString(), "Create", SWSetting.ProssType.ToString());
        //            }

        //        }
        //        return RedirectToAction("SWAllowanceList", "HRVariable");
        //    }
        //    return View(SWSetting);
        //}

        //public IActionResult EditSWAllowance(int id)
        //{
        //    if (id == null)
        //    {
        //        return NotFound();
        //    }
        //    ViewBag.ActionType = "Edit";
        //    var SWSetting = _summerWinterAllowanceRepository.Find(id);
        //    if (SWSetting == null)
        //    {
        //        return NotFound();
        //    }
        //    return View("CreateSWAllowance", SWSetting);
        //}

        //public IActionResult DeleteSWAllowance(int id)
        //{
        //    if (id == null)
        //    {
        //        return NotFound();
        //    }

        //    var SWSetting = _summerWinterAllowanceRepository.Find(id);

        //    if (SWSetting == null)
        //    {
        //        return NotFound();
        //    }

        //    ViewBag.ActionType = "Delete";

        //    return View("CreateSWAllowance", SWSetting);
        //}

        //[HttpPost, ActionName("DeleteSWAllowance")]
        //public IActionResult DeleteSWAllowanceConfirmed(int id)
        //{
        //    try
        //    {
        //        var SWSetting = _summerWinterAllowanceRepository.Find(id);
        //        _summerWinterAllowanceRepository.Delete(SWSetting);

        //        TempData["Message"] = "Data Delete Successfully";
        //        TempData["Status"] = "3";
        //        tranlog.TransactionLog(RouteData.Values["controller"].ToString(), RouteData.Values["action"].ToString(), TempData["Message"].ToString(), SWSetting.SWAllowanceId.ToString(), "Delete", SWSetting.ProssType);

        //        return Json(new { Success = 1, SWSettingId = SWSetting.SWAllowanceId, ex = TempData["Message"].ToString() });
        //    }
        //    catch (Exception ex)
        //    {
        //        return Json(new { Success = 0, ex = ex.InnerException.InnerException.Message.ToString() });
        //    }
        //}
        //#endregion


        //#region IT Computation Setting
        //public IActionResult ITComputationList()
        //{
        //    TempData["Message"] = "Data Load Successfully";
        //    TempData["Status"] = "1";
        //    tranlog.TransactionLog(RouteData.Values["controller"].ToString(), RouteData.Values["action"].ToString(), TempData["Message"].ToString(), "", "List Show", "");

        //    return View(_iTComputationSettingRepository.GetAll().ToList());
        //}

        //public IActionResult CreateITComputation()
        //{
        //    ViewBag.ActionType = "Create";
        //    return View();
        //}

        //[HttpPost]
        //public IActionResult CreateITComputation(Cat_ITComputationSetting Cat_ITComputation)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        if (Cat_ITComputation.Id > 0)
        //        {
        //            _iTComputationSettingRepository.Update(Cat_ITComputation);

        //            TempData["Message"] = "Data Update Successfully";
        //            TempData["Status"] = "2";
        //            tranlog.TransactionLog(RouteData.Values["controller"].ToString(), RouteData.Values["action"].ToString(), TempData["Message"].ToString(), Cat_ITComputation.Id.ToString(), "Update", Cat_ITComputation.TaxComputation.ToString());

        //        }
        //        else
        //        {
        //            _iTComputationSettingRepository.Add(Cat_ITComputation);

        //            TempData["Message"] = "Data Save Successfully";
        //            TempData["Status"] = "1";
        //            tranlog.TransactionLog(RouteData.Values["controller"].ToString(), RouteData.Values["action"].ToString(), TempData["Message"].ToString(), Cat_ITComputation.Id.ToString(), "Create", Cat_ITComputation.TaxComputation.ToString());

        //        }
        //        return RedirectToAction("ITComputationList", "HRVariable");
        //    }
        //    return View(Cat_ITComputation);
        //}

        //public IActionResult EditITComputation(int id)
        //{
        //    if (id == null)
        //    {
        //        return NotFound();
        //    }
        //    ViewBag.ActionType = "Edit";
        //    var Cat_ITComputation = _iTComputationSettingRepository.Find(id);
        //    if (Cat_ITComputation == null)
        //    {
        //        return NotFound();
        //    }
        //    return View("CreateITComputation", Cat_ITComputation);
        //}

        //public IActionResult DeleteITComputation(int id)
        //{
        //    if (id == null)
        //    {
        //        return NotFound();
        //    }

        //    var Cat_ITComputation = _iTComputationSettingRepository.Find(id);

        //    if (Cat_ITComputation == null)
        //    {
        //        return NotFound();
        //    }

        //    ViewBag.ActionType = "Delete";

        //    return View("CreateStyle", Cat_ITComputation);
        //}

        //[HttpPost, ActionName("DeleteITComputation")]
        //public IActionResult DeleteITComputationConfirmed(int id)
        //{
        //    try
        //    {
        //        var Cat_ITComputation = _iTComputationSettingRepository.Find(id);
        //        _iTComputationSettingRepository.Delete(Cat_ITComputation);

        //        TempData["Message"] = "Data Delete Successfully";
        //        TempData["Status"] = "3";
        //        tranlog.TransactionLog(RouteData.Values["controller"].ToString(), RouteData.Values["action"].ToString(), TempData["Message"].ToString(), Cat_ITComputation.Id.ToString(), "Delete", Cat_ITComputation.TaxComputation.ToString());

        //        return Json(new { Success = 1, StyleId = Cat_ITComputation.Id, ex = TempData["Message"].ToString() });
        //    }
        //    catch (Exception ex)
        //    {
        //        return Json(new { Success = 0, ex = ex.InnerException.InnerException.Message.ToString() });
        //    }
        //}
        //#endregion


        //#region Gas Charge Setting
        //public IActionResult GasChargeList()
        //{
        //    TempData["Message"] = "Data Load Successfully";
        //    TempData["Status"] = "1";
        //    tranlog.TransactionLog(RouteData.Values["controller"].ToString(), RouteData.Values["action"].ToString(), TempData["Message"].ToString(), "", "List Show", "");

        //    return View(_gasChargeSettingRepository.GetAll().ToList());
        //}

        //public IActionResult CreateGasCharge()
        //{
        //    ViewBag.LId = _locationRepository.GetLocationList();
        //    ViewBag.BId = _buildingTypeRepository.GetAllForDropDown();

        //    ViewBag.ActionType = "Create";
        //    return View();
        //}

        //[HttpPost]
        //public IActionResult CreateGasCharge(Cat_GasChargeSetting GasCharge)
        //{
        //    ViewBag.LId = _locationRepository.GetLocationList();
        //    ViewBag.BId = _buildingTypeRepository.GetAllForDropDown();
        //    if (ModelState.IsValid)
        //    {
        //        if (GasCharge.Id > 0)
        //        {
        //            _gasChargeSettingRepository.Update(GasCharge);

        //            TempData["Message"] = "Data Update Successfully";
        //            TempData["Status"] = "2";
        //            tranlog.TransactionLog(RouteData.Values["controller"].ToString(), RouteData.Values["action"].ToString(), TempData["Message"].ToString(), GasCharge.Id.ToString(), "Update", GasCharge.Cat_Location.ToString());

        //        }
        //        else
        //        {
        //            _gasChargeSettingRepository.Add(GasCharge);

        //            TempData["Message"] = "Data Save Successfully";
        //            TempData["Status"] = "1";
        //            tranlog.TransactionLog(RouteData.Values["controller"].ToString(), RouteData.Values["action"].ToString(), TempData["Message"].ToString(), GasCharge.Id.ToString(), "Create", GasCharge.Cat_Location.ToString());

        //        }
        //        return RedirectToAction("GasChargeList", "HRVariable");
        //    }
        //    return View(GasCharge);
        //}

        //public IActionResult EditGasCharge(int id)
        //{
        //    ViewBag.LId = _locationRepository.GetLocationList();
        //    ViewBag.BId = _buildingTypeRepository.GetAllForDropDown();
        //    if (id == null)
        //    {
        //        return NotFound();
        //    }
        //    ViewBag.ActionType = "Edit";
        //    var GasCharge = _gasChargeSettingRepository.Find(id);
        //    if (GasCharge == null)
        //    {
        //        return NotFound();
        //    }
        //    return View("CreateGasCharge", GasCharge);
        //}

        //public IActionResult DeleteGasCharge(int id)
        //{
        //    ViewBag.LId = _locationRepository.GetLocationList();
        //    ViewBag.BId = _buildingTypeRepository.GetAllForDropDown();
        //    if (id == null)
        //    {
        //        return NotFound();
        //    }

        //    var GasCharge = _gasChargeSettingRepository.Find(id);

        //    if (GasCharge == null)
        //    {
        //        return NotFound();
        //    }

        //    ViewBag.ActionType = "Delete";

        //    return View("CreateStyle", GasCharge);
        //}

        //[HttpPost, ActionName("DeleteGasCharge")]
        //public IActionResult DeleteGasChargeConfirmed(int id)
        //{
        //    ViewBag.LId = _locationRepository.GetLocationList();
        //    ViewBag.BId = _buildingTypeRepository.GetAllForDropDown();
        //    try
        //    {
        //        var GasCharge = _gasChargeSettingRepository.Find(id);
        //        _gasChargeSettingRepository.Delete(GasCharge);

        //        TempData["Message"] = "Data Delete Successfully";
        //        TempData["Status"] = "3";
        //        tranlog.TransactionLog(RouteData.Values["controller"].ToString(), RouteData.Values["action"].ToString(), TempData["Message"].ToString(), GasCharge.Id.ToString(), "Delete", GasCharge.Cat_Location.ToString());

        //        return Json(new { Success = 1, Id = GasCharge.Id, ex = TempData["Message"].ToString() });
        //    }
        //    catch (Exception ex)
        //    {
        //        return Json(new { Success = 0, ex = ex.InnerException.InnerException.Message.ToString() });
        //    }
        //}
        //#endregion


        //#region Tax Bank
        //public IActionResult TaxBankList()
        //{
        //    TempData["Message"] = "Data Load Successfully";
        //    TempData["Status"] = "1";
        //    tranlog.TransactionLog(RouteData.Values["controller"].ToString(), RouteData.Values["action"].ToString(), TempData["Message"].ToString(), "", "List Show", "");

        //    return View(_taxBankRepository.GetAll().ToList());
        //}

        //public IActionResult CreateTaxBank()
        //{
        //    ViewBag.BankId = _bankRepository.GetAllForDropDown();
        //    ViewBag.BranchId = _bankBranchRepository.GetAllForDropDown();
        //    ViewBag.ActionType = "Create";
        //    return View();
        //}

        //[HttpPost]
        //public IActionResult CreateTaxBank(Cat_ITaxBank Cat_TaxBank)
        //{
        //    ViewBag.BankId = _bankRepository.GetAllForDropDown();
        //    ViewBag.BranchId = _bankBranchRepository.GetAllForDropDown();
        //    if (ModelState.IsValid)
        //    {
        //        if (Cat_TaxBank.Id > 0)
        //        {
        //            _taxBankRepository.Update(Cat_TaxBank);

        //            TempData["Message"] = "Data Update Successfully";
        //            TempData["Status"] = "2";
        //            tranlog.TransactionLog(RouteData.Values["controller"].ToString(), RouteData.Values["action"].ToString(), TempData["Message"].ToString(), Cat_TaxBank.Id.ToString(), "Update", Cat_TaxBank.Cat_Bank.ToString());

        //        }
        //        else
        //        {
        //            _taxBankRepository.Add(Cat_TaxBank);

        //            TempData["Message"] = "Data Save Successfully";
        //            TempData["Status"] = "1";
        //            tranlog.TransactionLog(RouteData.Values["controller"].ToString(), RouteData.Values["action"].ToString(), TempData["Message"].ToString(), Cat_TaxBank.Id.ToString(), "Create", Cat_TaxBank.Cat_Bank.ToString());

        //        }
        //        return RedirectToAction("TaxBankList", "HRVariable");
        //    }
        //    return View(Cat_TaxBank);
        //}

        //public IActionResult EditTaxBank(int id)
        //{
        //    ViewBag.BankId = _bankRepository.GetAllForDropDown();
        //    ViewBag.BranchId = _bankBranchRepository.GetAllForDropDown();
        //    if (id == null)
        //    {
        //        return NotFound();
        //    }
        //    ViewBag.ActionType = "Edit";
        //    var Cat_TaxBank = _taxBankRepository.Find(id);
        //    if (Cat_TaxBank == null)
        //    {
        //        return NotFound();
        //    }
        //    return View("CreateTaxBank", Cat_TaxBank);
        //}

        //public IActionResult DeleteTaxBank(int id)
        //{
        //    ViewBag.BankId = _bankRepository.GetAllForDropDown();
        //    ViewBag.BranchId = _bankBranchRepository.GetAllForDropDown();
        //    if (id == null)
        //    {
        //        return NotFound();
        //    }

        //    var Cat_TaxBank = _taxBankRepository.Find(id);

        //    if (Cat_TaxBank == null)
        //    {
        //        return NotFound();
        //    }

        //    ViewBag.ActionType = "Delete";

        //    return View("CreateTaxBank", Cat_TaxBank);
        //}

        //[HttpPost, ActionName("DeleteTaxBank")]
        //public IActionResult DeleteTaxBankConfirmed(int id)
        //{
        //    ViewBag.BankId = _bankRepository.GetAllForDropDown();
        //    ViewBag.BranchId = _bankBranchRepository.GetAllForDropDown();
        //    try
        //    {
        //        var Cat_TaxBank = _taxBankRepository.Find(id);
        //        _taxBankRepository.Delete(Cat_TaxBank);

        //        TempData["Message"] = "Data Delete Successfully";
        //        TempData["Status"] = "3";
        //        tranlog.TransactionLog(RouteData.Values["controller"].ToString(), RouteData.Values["action"].ToString(), TempData["Message"].ToString(), Cat_TaxBank.Id.ToString(), "Delete", Cat_TaxBank.Cat_Bank.ToString());

        //        return Json(new { Success = 1, StyleId = Cat_TaxBank.Id, ex = TempData["Message"].ToString() });
        //    }
        //    catch (Exception ex)
        //    {
        //        return Json(new { Success = 0, ex = ex.InnerException.InnerException.Message.ToString() });
        //    }
        //}
        //#endregion


        //#region Incen Band
        //public IActionResult IncenBandList()
        //{
        //    TempData["Message"] = "Data Load Successfully";
        //    TempData["Status"] = "1";
        //    tranlog.TransactionLog(RouteData.Values["controller"].ToString(), RouteData.Values["action"].ToString(), TempData["Message"].ToString(), "", "List Show", "");

        //    return View(_incenBandRepository.GetAll().ToList());
        //}

        //public IActionResult CreateIncenBand()
        //{
        //    ViewBag.InBId = _incenBandRepository.GetIncenBandList();
        //    ViewBag.ActionType = "Create";
        //    return View();
        //}

        //[HttpPost]
        //public IActionResult CreateIncenBand(Cat_IncenBand Cat_IncenBand)
        //{
        //    ViewBag.InBId = _incenBandRepository.GetIncenBandList();
        //    if (ModelState.IsValid)
        //    {
        //        if (Cat_IncenBand.InBId > 0)
        //        {
        //            _incenBandRepository.Update(Cat_IncenBand);

        //            TempData["Message"] = "Data Update Successfully";
        //            TempData["Status"] = "2";
        //            tranlog.TransactionLog(RouteData.Values["controller"].ToString(), RouteData.Values["action"].ToString(), TempData["Message"].ToString(), Cat_IncenBand.InBId.ToString(), "Update", Cat_IncenBand.IncenBandName.ToString());

        //        }
        //        else
        //        {
        //            _incenBandRepository.Add(Cat_IncenBand);

        //            TempData["Message"] = "Data Save Successfully";
        //            TempData["Status"] = "1";
        //            tranlog.TransactionLog(RouteData.Values["controller"].ToString(), RouteData.Values["action"].ToString(), TempData["Message"].ToString(), Cat_IncenBand.InBId.ToString(), "Create", Cat_IncenBand.IncenBandName.ToString());

        //        }
        //        return RedirectToAction("IncenBandList", "HRVariable");
        //    }
        //    return View(Cat_IncenBand);
        //}

        //public IActionResult EditIncenBand(int id)
        //{
        //    ViewBag.InBId = _incenBandRepository.GetIncenBandList();
        //    if (id == null)
        //    {
        //        return NotFound();
        //    }
        //    ViewBag.ActionType = "Edit";
        //    var Cat_IncenBand = _incenBandRepository.Find(id);
        //    if (Cat_IncenBand == null)
        //    {
        //        return NotFound();
        //    }
        //    return View("CreateIncenBand", Cat_IncenBand);
        //}

        //public IActionResult DeleteIncenBand(int id)
        //{
        //    ViewBag.InBId = _incenBandRepository.GetIncenBandList();
        //    if (id == null)
        //    {
        //        return NotFound();
        //    }

        //    var Cat_IncenBand = _incenBandRepository.Find(id);

        //    if (Cat_IncenBand == null)
        //    {
        //        return NotFound();
        //    }

        //    ViewBag.ActionType = "Delete";

        //    return View("CreateIncenBand", Cat_IncenBand);
        //}

        //[HttpPost, ActionName("DeleteIncenBand")]
        //public IActionResult DeleteIncenBandConfirmed(int id)
        //{
        //    ViewBag.InBId = _incenBandRepository.GetIncenBandList();
        //    try
        //    {
        //        var Cat_IncenBand = _incenBandRepository.Find(id);
        //        _incenBandRepository.Delete(Cat_IncenBand);

        //        TempData["Message"] = "Data Delete Successfully";
        //        TempData["Status"] = "3";
        //        tranlog.TransactionLog(RouteData.Values["controller"].ToString(), RouteData.Values["action"].ToString(), TempData["Message"].ToString(), Cat_IncenBand.InBId.ToString(), "Delete", Cat_IncenBand.IncenBandName.ToString());

        //        return Json(new { Success = 1, InBId = Cat_IncenBand.InBId, ex = TempData["Message"].ToString() });
        //    }
        //    catch (Exception ex)
        //    {
        //        return Json(new { Success = 0, ex = ex.InnerException.InnerException.Message.ToString() });
        //    }
        //}
        //#endregion


        //#region Insure Grade
        //public IActionResult InsureGradeList()
        //{
        //    TempData["Message"] = "Data Load Successfully";
        //    TempData["Status"] = "1";
        //    tranlog.TransactionLog(RouteData.Values["controller"].ToString(), RouteData.Values["action"].ToString(), TempData["Message"].ToString(), "", "List Show", "");

        //    return View(_insureGradeRepository.GetAll().ToList());
        //}

        //public IActionResult CreateInsureGrade()
        //{
        //    ViewBag.ActionType = "Create";
        //    return View();
        //}

        //[HttpPost]
        //public IActionResult CreateInsureGrade(Cat_InsurGrade Cat_InsurGrade)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        if (Cat_InsurGrade.InGId > 0)
        //        {
        //            _insureGradeRepository.Update(Cat_InsurGrade);

        //            TempData["Message"] = "Data Update Successfully";
        //            TempData["Status"] = "2";
        //            tranlog.TransactionLog(RouteData.Values["controller"].ToString(), RouteData.Values["action"].ToString(), TempData["Message"].ToString(), Cat_InsurGrade.InGId.ToString(), "Update", Cat_InsurGrade.InSurGrade.ToString());

        //        }
        //        else
        //        {
        //            _insureGradeRepository.Add(Cat_InsurGrade);

        //            TempData["Message"] = "Data Save Successfully";
        //            TempData["Status"] = "1";
        //            tranlog.TransactionLog(RouteData.Values["controller"].ToString(), RouteData.Values["action"].ToString(), TempData["Message"].ToString(), Cat_InsurGrade.InGId.ToString(), "Create", Cat_InsurGrade.InSurGrade.ToString());

        //        }
        //        return RedirectToAction("InsureGradeList", "HRVariable");
        //    }
        //    return View(Cat_InsurGrade);
        //}

        //public IActionResult EditInsureGrade(int id)
        //{
        //    if (id == null)
        //    {
        //        return NotFound();
        //    }
        //    ViewBag.ActionType = "Edit";
        //    var Cat_InsurGrade = _insureGradeRepository.Find(id);
        //    if (Cat_InsurGrade == null)
        //    {
        //        return NotFound();
        //    }
        //    return View("CreateInsureGrade", Cat_InsurGrade);
        //}

        //public IActionResult DeleteInsureGrade(int id)
        //{
        //    if (id == null)
        //    {
        //        return NotFound();
        //    }

        //    var Cat_InsurGrade = _insureGradeRepository.Find(id);

        //    if (Cat_InsurGrade == null)
        //    {
        //        return NotFound();
        //    }

        //    ViewBag.ActionType = "Delete";

        //    return View("CreateInsureGrade", Cat_InsurGrade);
        //}

        //[HttpPost, ActionName("DeleteInsureGrade")]
        //public IActionResult DeleteInsureGradeConfirmed(int id)
        //{
        //    try
        //    {
        //        var Cat_InsurGrade = _insureGradeRepository.Find(id);
        //        _insureGradeRepository.Delete(Cat_InsurGrade);

        //        TempData["Message"] = "Data Delete Successfully";
        //        TempData["Status"] = "3";
        //        tranlog.TransactionLog(RouteData.Values["controller"].ToString(), RouteData.Values["action"].ToString(), TempData["Message"].ToString(), Cat_InsurGrade.InGId.ToString(), "Delete", Cat_InsurGrade.InSurGrade);

        //        return Json(new { Success = 1, InGId = Cat_InsurGrade.InGId, ex = TempData["Message"].ToString() });
        //    }
        //    catch (Exception ex)
        //    {
        //        return Json(new { Success = 0, ex = ex.InnerException.InnerException.Message.ToString() });
        //    }
        //}
        //#endregion


        //#region Exchange Rate
        //public IActionResult ExchangeRateList()
        //{
        //    TempData["Message"] = "Data Load Successfully";
        //    TempData["Status"] = "1";
        //    tranlog.TransactionLog(RouteData.Values["controller"].ToString(), RouteData.Values["action"].ToString(), TempData["Message"].ToString(), "", "List Show", "");

        //    return View(_exchangeRateRepository.GetAll().ToList());
        //}

        //public IActionResult CreateExchangeRate()
        //{
        //    ViewBag.ActionType = "Create";
        //    return View();
        //}

        //[HttpPost]
        //public IActionResult CreateExchangeRate(Cat_ExchangeRate Cat_ExchangeRate)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        if (Cat_ExchangeRate.ExChangeId > 0)
        //        {
        //            _exchangeRateRepository.Update(Cat_ExchangeRate);

        //            TempData["Message"] = "Data Update Successfully";
        //            TempData["Status"] = "2";
        //            tranlog.TransactionLog(RouteData.Values["controller"].ToString(), RouteData.Values["action"].ToString(), TempData["Message"].ToString(), Cat_ExchangeRate.ExChangeId.ToString(), "Update", Cat_ExchangeRate.ExchangeRate.ToString());

        //        }
        //        else
        //        {
        //            _exchangeRateRepository.Add(Cat_ExchangeRate);

        //            TempData["Message"] = "Data Save Successfully";
        //            TempData["Status"] = "1";
        //            tranlog.TransactionLog(RouteData.Values["controller"].ToString(), RouteData.Values["action"].ToString(), TempData["Message"].ToString(), Cat_ExchangeRate.ExChangeId.ToString(), "Create", Cat_ExchangeRate.ExchangeRate.ToString());

        //        }
        //        return RedirectToAction("ExchangeRateList", "HRVariable");
        //    }
        //    return View(Cat_ExchangeRate);
        //}

        //public IActionResult EditExchangeRate(int id)
        //{
        //    if (id == null)
        //    {
        //        return NotFound();
        //    }
        //    ViewBag.ActionType = "Edit";
        //    var Cat_ExchangeRate = _exchangeRateRepository.Find(id);
        //    if (Cat_ExchangeRate == null)
        //    {
        //        return NotFound();
        //    }
        //    return View("CreateExchangeRate", Cat_ExchangeRate);
        //}

        //public IActionResult DeleteExchangeRate(int id)
        //{
        //    if (id == null)
        //    {
        //        return NotFound();
        //    }

        //    var Cat_ExchangeRate = _exchangeRateRepository.Find(id);

        //    if (Cat_ExchangeRate == null)
        //    {
        //        return NotFound();
        //    }

        //    ViewBag.ActionType = "Delete";

        //    return View("CreateExchangeRate", Cat_ExchangeRate);
        //}

        //[HttpPost, ActionName("DeleteExchangeRate")]
        //public IActionResult DeleteExchangeRateConfirmed(int id)
        //{
        //    try
        //    {
        //        var Cat_ExchangeRate = _exchangeRateRepository.Find(id);
        //        _exchangeRateRepository.Delete(Cat_ExchangeRate);

        //        TempData["Message"] = "Data Delete Successfully";
        //        TempData["Status"] = "3";
        //        tranlog.TransactionLog(RouteData.Values["controller"].ToString(), RouteData.Values["action"].ToString(), TempData["Message"].ToString(), Cat_ExchangeRate.ExChangeId.ToString(), "Delete", Cat_ExchangeRate.ExchangeRate.ToString());

        //        return Json(new { Success = 1, StyleId = Cat_ExchangeRate.ExChangeId, ex = TempData["Message"].ToString() });
        //    }
        //    catch (Exception ex)
        //    {
        //        return Json(new { Success = 0, ex = ex.InnerException.InnerException.Message.ToString() });
        //    }
        //}
        //#endregion


        //#region Electric Charge Setting
        //public IActionResult ECSettingList()
        //{
        //    TempData["Message"] = "Data Load Successfully";
        //    TempData["Status"] = "1";
        //    tranlog.TransactionLog(RouteData.Values["controller"].ToString(), RouteData.Values["action"].ToString(), TempData["Message"].ToString(), "", "List Show", "");

        //    return View(_electricChargeSettingRepository.GetAll().ToList());
        //}

        //public IActionResult CreateECSetting()
        //{
        //    ViewBag.EmpTypeId = _empTypeRepository.GetAllForDropDown();
        //    ViewBag.LId = _locationRepository.GetLocationList();
        //    ViewBag.BId = _buildingTypeRepository.GetAllForDropDown();

        //    ViewBag.ActionType = "Create";
        //    return View();
        //}

        //[HttpPost]
        //public IActionResult CreateECSetting(Cat_ElectricChargeSetting Cat_ElectricChargeSetting)
        //{
        //    ViewBag.EmpTypeId = _empTypeRepository.GetAllForDropDown();
        //    ViewBag.LId = _locationRepository.GetLocationList();
        //    ViewBag.BId = _buildingTypeRepository.GetAllForDropDown();
        //    if (ModelState.IsValid)
        //    {
        //        if (Cat_ElectricChargeSetting.Id > 0)
        //        {
        //            _electricChargeSettingRepository.Update(Cat_ElectricChargeSetting);

        //            TempData["Message"] = "Data Update Successfully";
        //            TempData["Status"] = "2";
        //            tranlog.TransactionLog(RouteData.Values["controller"].ToString(), RouteData.Values["action"].ToString(), TempData["Message"].ToString(), Cat_ElectricChargeSetting.Id.ToString(), "Update", Cat_ElectricChargeSetting.ElectricCharge.ToString());

        //        }
        //        else
        //        {
        //            _electricChargeSettingRepository.Add(Cat_ElectricChargeSetting);

        //            TempData["Message"] = "Data Save Successfully";
        //            TempData["Status"] = "1";
        //            tranlog.TransactionLog(RouteData.Values["controller"].ToString(), RouteData.Values["action"].ToString(), TempData["Message"].ToString(), Cat_ElectricChargeSetting.Id.ToString(), "Create", Cat_ElectricChargeSetting.ElectricCharge.ToString());

        //        }
        //        return RedirectToAction("ECSettingList", "HRVariable");
        //    }
        //    return View(Cat_ElectricChargeSetting);
        //}

        //public IActionResult EditECSetting(int id)
        //{
        //    ViewBag.EmpTypeId = _empTypeRepository.GetAllForDropDown();
        //    ViewBag.LId = _locationRepository.GetLocationList();
        //    ViewBag.BId = _buildingTypeRepository.GetAllForDropDown();
        //    if (id == null)
        //    {
        //        return NotFound();
        //    }
        //    ViewBag.ActionType = "Edit";
        //    var Cat_ElectricChargeSetting = _electricChargeSettingRepository.Find(id);
        //    if (Cat_ElectricChargeSetting == null)
        //    {
        //        return NotFound();
        //    }
        //    return View("CreateECSetting", Cat_ElectricChargeSetting);
        //}

        //public IActionResult DeleteECSetting(int id)
        //{
        //    ViewBag.EmpTypeId = _empTypeRepository.GetAllForDropDown();
        //    ViewBag.LId = _locationRepository.GetLocationList();
        //    ViewBag.BId = _buildingTypeRepository.GetAllForDropDown();
        //    if (id == null)
        //    {
        //        return NotFound();
        //    }

        //    var Cat_ElectricChargeSetting = _electricChargeSettingRepository.Find(id);

        //    if (Cat_ElectricChargeSetting == null)
        //    {
        //        return NotFound();
        //    }

        //    ViewBag.ActionType = "Delete";

        //    return View("CreateECSetting", Cat_ElectricChargeSetting);
        //}

        //[HttpPost, ActionName("DeleteECSetting")]
        //public IActionResult DeleteECSettingConfirmed(int id)
        //{
        //    ViewBag.EmpTypeId = _empTypeRepository.GetAllForDropDown();
        //    ViewBag.LId = _locationRepository.GetLocationList();
        //    ViewBag.BId = _buildingTypeRepository.GetAllForDropDown();
        //    try
        //    {
        //        var Cat_ElectricChargeSetting = _electricChargeSettingRepository.Find(id);
        //        _electricChargeSettingRepository.Delete(Cat_ElectricChargeSetting);

        //        TempData["Message"] = "Data Delete Successfully";
        //        TempData["Status"] = "3";
        //        tranlog.TransactionLog(RouteData.Values["controller"].ToString(), RouteData.Values["action"].ToString(), TempData["Message"].ToString(), Cat_ElectricChargeSetting.Id.ToString(), "Delete", Cat_ElectricChargeSetting.ElectricCharge.ToString());

        //        return Json(new { Success = 1, ECSettingId = Cat_ElectricChargeSetting.Id, ex = TempData["Message"].ToString() });
        //    }
        //    catch (Exception ex)
        //    {
        //        return Json(new { Success = 0, ex = ex.InnerException.InnerException.Message.ToString() });
        //    }
        //}
        //#endregion


        //#region Diagnosis
        //public IActionResult DiagnosisList()
        //{
        //    TempData["Message"] = "Data Load Successfully";
        //    TempData["Status"] = "1";
        //    tranlog.TransactionLog(RouteData.Values["controller"].ToString(), RouteData.Values["action"].ToString(), TempData["Message"].ToString(), "", "List Show", "");

        //    return View(_diagnosisRepository.GetAll().ToList());
        //}

        //public IActionResult CreateDiagnosis()
        //{
        //    ViewBag.ActionType = "Create";
        //    return View();
        //}

        //[HttpPost]
        //public IActionResult CreateDiagnosis(Cat_MedicalDiagnosis Cat_MedicalDiagnosis)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        if (Cat_MedicalDiagnosis.DiagId > 0)
        //        {
        //            _diagnosisRepository.Update(Cat_MedicalDiagnosis);

        //            TempData["Message"] = "Data Update Successfully";
        //            TempData["Status"] = "2";
        //            tranlog.TransactionLog(RouteData.Values["controller"].ToString(), RouteData.Values["action"].ToString(), TempData["Message"].ToString(), Cat_MedicalDiagnosis.DiagId.ToString(), "Update", Cat_MedicalDiagnosis.DiagName.ToString());

        //        }
        //        else
        //        {
        //            _diagnosisRepository.Add(Cat_MedicalDiagnosis);

        //            TempData["Message"] = "Data Save Successfully";
        //            TempData["Status"] = "1";
        //            tranlog.TransactionLog(RouteData.Values["controller"].ToString(), RouteData.Values["action"].ToString(), TempData["Message"].ToString(), Cat_MedicalDiagnosis.DiagId.ToString(), "Create", Cat_MedicalDiagnosis.DiagName.ToString());

        //        }
        //        return RedirectToAction("DiagnosisList", "HRVariable");
        //    }
        //    return View(Cat_MedicalDiagnosis);
        //}

        //public IActionResult EditDiagnosis(int id)
        //{
        //    if (id == null)
        //    {
        //        return NotFound();
        //    }
        //    ViewBag.ActionType = "Edit";
        //    var Cat_MedicalDiagnosis = _diagnosisRepository.Find(id);
        //    if (Cat_MedicalDiagnosis == null)
        //    {
        //        return NotFound();
        //    }
        //    return View("CreateDiagnosis", Cat_MedicalDiagnosis);
        //}

        //public IActionResult DeleteDiagnosis(int id)
        //{
        //    if (id == null)
        //    {
        //        return NotFound();
        //    }

        //    var Cat_MedicalDiagnosis = _diagnosisRepository.Find(id);

        //    if (Cat_MedicalDiagnosis == null)
        //    {
        //        return NotFound();
        //    }

        //    ViewBag.ActionType = "Delete";

        //    return View("CreateDiagnosis", Cat_MedicalDiagnosis);
        //}

        //[HttpPost, ActionName("DeleteDiagnosis")]
        //public IActionResult DeleteDiagnosisConfirmed(int id)
        //{
        //    try
        //    {
        //        var Cat_MedicalDiagnosis = _diagnosisRepository.Find(id);
        //        _diagnosisRepository.Delete(Cat_MedicalDiagnosis);

        //        TempData["Message"] = "Data Delete Successfully";
        //        TempData["Status"] = "3";
        //        tranlog.TransactionLog(RouteData.Values["controller"].ToString(), RouteData.Values["action"].ToString(), TempData["Message"].ToString(), Cat_MedicalDiagnosis.DiagId.ToString(), "Delete", Cat_MedicalDiagnosis.DiagName);

        //        return Json(new { Success = 1, DiagId = Cat_MedicalDiagnosis.DiagId, ex = TempData["Message"].ToString() });
        //    }
        //    catch (Exception ex)
        //    {
        //        return Json(new { Success = 0, ex = ex.InnerException.InnerException.Message.ToString() });
        //    }
        //}
        //#endregion


        //#region Signatory
        //public IActionResult SignatoryList()
        //{
        //    ViewBag.ReportName = _signatoryRepository.ReportNames();
        //    TempData["Message"] = "Data Load Successfully";
        //    TempData["Status"] = "1";
        //    tranlog.TransactionLog(RouteData.Values["controller"].ToString(), RouteData.Values["action"].ToString(), TempData["Message"].ToString(), "", "List Show", "");

        //    return View(_signatoryRepository.GetAll());
        //}

        //public IActionResult CreateSignatory()
        //{
        //    ViewBag.ReportName = _signatoryRepository.ReportNames();
        //    ViewBag.ActionType = "Create";
        //    return View();
        //}

        //[HttpPost]
        //public IActionResult CreateSignatory(Cat_ReportSignatory Cat_ReportSignatory)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        if (Cat_ReportSignatory.SignatoryId > 0)
        //        {
        //            _signatoryRepository.Update(Cat_ReportSignatory);

        //            TempData["Message"] = "Data Update Successfully";
        //            TempData["Status"] = "2";
        //            tranlog.TransactionLog(RouteData.Values["controller"].ToString(), RouteData.Values["action"].ToString(), TempData["Message"].ToString(), Cat_ReportSignatory.SignatoryId.ToString(), "Update", Cat_ReportSignatory.Signatory1.ToString());

        //        }
        //        else
        //        {
        //            _signatoryRepository.Add(Cat_ReportSignatory);

        //            TempData["Message"] = "Data Save Successfully";
        //            TempData["Status"] = "1";
        //            tranlog.TransactionLog(RouteData.Values["controller"].ToString(), RouteData.Values["action"].ToString(), TempData["Message"].ToString(), Cat_ReportSignatory.SignatoryId.ToString(), "Create", Cat_ReportSignatory.Signatory1.ToString());

        //        }
        //        return RedirectToAction("SignatoryList", "HRVariable");
        //    }
        //    return View(Cat_ReportSignatory);
        //}

        //public IActionResult EditSignatory(int id)
        //{
        //    ViewBag.ReportName = _signatoryRepository.ReportNames();
        //    if (id == null)
        //    {
        //        return NotFound();
        //    }
        //    ViewBag.ActionType = "Edit";
        //    var Cat_ReportSignatory = _signatoryRepository.Find(id);
        //    if (Cat_ReportSignatory == null)
        //    {
        //        return NotFound();
        //    }
        //    return View("CreateSignatory", Cat_ReportSignatory);
        //}

        //public IActionResult DeleteSignatory(int id)
        //{
        //    ViewBag.ReportName = _signatoryRepository.ReportNames();
        //    if (id == null)
        //    {
        //        return NotFound();
        //    }

        //    var Cat_ReportSignatory = _signatoryRepository.Find(id);

        //    if (Cat_ReportSignatory == null)
        //    {
        //        return NotFound();
        //    }

        //    ViewBag.ActionType = "Delete";

        //    return View("CreateSignatory", Cat_ReportSignatory);
        //}

        //[HttpPost, ActionName("DeleteSignatory")]
        //public IActionResult DeleteSignatoryConfirmed(int id)
        //{
        //    try
        //    {
        //        var Cat_ReportSignatory = _signatoryRepository.Find(id);
        //        _signatoryRepository.Delete(Cat_ReportSignatory);

        //        TempData["Message"] = "Data Delete Successfully";
        //        TempData["Status"] = "3";
        //        tranlog.TransactionLog(RouteData.Values["controller"].ToString(), RouteData.Values["action"].ToString(), TempData["Message"].ToString(), Cat_ReportSignatory.SignatoryId.ToString(), "Delete", Cat_ReportSignatory.Signatory1);

        //        return Json(new { Success = 1, SignatoryId = Cat_ReportSignatory.SignatoryId, ex = TempData["Message"].ToString() });
        //    }
        //    catch (Exception ex)
        //    {
        //        return Json(new { Success = 0, ex = ex.InnerException.InnerException.Message.ToString() });
        //    }
        //}
        //#endregion


        //#region Ware House
        //public IActionResult WareHouseList()
        //{
        //    TempData["Message"] = "Data Load Successfully";
        //    TempData["Status"] = "1";
        //    tranlog.TransactionLog(RouteData.Values["controller"].ToString(), RouteData.Values["action"].ToString(), TempData["Message"].ToString(), "", "List Show", "");

        //    return View(_wareHouseRepository.GetAll().ToList());
        //}

        //public IActionResult CreateWareHouse()
        //{
        //    ViewBag.ParentId = _wareHouseRepository.GetWarehouseList();
        //    ViewBag.ActionType = "Create";
        //    return View();
        //}

        //[HttpPost]
        //public IActionResult CreateWareHouse(Warehouse Warehouse)
        //{
        //    ViewBag.ParentId = _wareHouseRepository.GetWarehouseList();
        //    if (ModelState.IsValid)
        //    {
        //        if (Warehouse.WarehouseId > 0)
        //        {
        //            _wareHouseRepository.Update(Warehouse);

        //            TempData["Message"] = "Data Update Successfully";
        //            TempData["Status"] = "2";
        //            tranlog.TransactionLog(RouteData.Values["controller"].ToString(), RouteData.Values["action"].ToString(), TempData["Message"].ToString(), Warehouse.WarehouseId.ToString(), "Update", Warehouse.WhName.ToString());

        //        }
        //        else
        //        {
        //            _wareHouseRepository.Add(Warehouse);

        //            TempData["Message"] = "Data Save Successfully";
        //            TempData["Status"] = "1";
        //            tranlog.TransactionLog(RouteData.Values["controller"].ToString(), RouteData.Values["action"].ToString(), TempData["Message"].ToString(), Warehouse.WarehouseId.ToString(), "Create", Warehouse.WhName.ToString());

        //        }
        //        return RedirectToAction("WareHouseList", "HRVariable");
        //    }
        //    return View(Warehouse);
        //}

        //public IActionResult EditWareHouse(int id)
        //{
        //    ViewBag.ParentId = _wareHouseRepository.GetWarehouseList();
        //    if (id == null)
        //    {
        //        return NotFound();
        //    }
        //    ViewBag.ActionType = "Edit";
        //    var Warehouse = _wareHouseRepository.Find(id);
        //    if (Warehouse == null)
        //    {
        //        return NotFound();
        //    }
        //    return View("CreateWareHouse", Warehouse);
        //}

        //public IActionResult DeleteWareHouse(int id)
        //{
        //    ViewBag.ParentId = _wareHouseRepository.GetWarehouseList();
        //    if (id == null)
        //    {
        //        return NotFound();
        //    }

        //    var Warehouse = _wareHouseRepository.Find(id);

        //    if (Warehouse == null)
        //    {
        //        return NotFound();
        //    }

        //    ViewBag.ActionType = "Delete";

        //    return View("CreateWareHouse", Warehouse);
        //}

        //[HttpPost, ActionName("DeleteWareHouse")]
        //public IActionResult DeleteWareHouseConfirmed(int id)
        //{
        //    ViewBag.ParentId = _wareHouseRepository.GetWarehouseList();
        //    try
        //    {
        //        var Warehouse = _wareHouseRepository.Find(id);
        //        _wareHouseRepository.Delete(Warehouse);

        //        TempData["Message"] = "Data Delete Successfully";
        //        TempData["Status"] = "3";
        //        tranlog.TransactionLog(RouteData.Values["controller"].ToString(), RouteData.Values["action"].ToString(), TempData["Message"].ToString(), Warehouse.WarehouseId.ToString(), "Delete", Warehouse.WhName);

        //        return Json(new { Success = 1, WareHouseId = Warehouse.WarehouseId, ex = TempData["Message"].ToString() });
        //    }
        //    catch (Exception ex)
        //    {
        //        return Json(new { Success = 0, ex = ex.InnerException.InnerException.Message.ToString() });
        //    }
        //}
        //#endregion


        //#region HR Exp Setting
        //public IActionResult HRExpList()
        //{
        //    TempData["Message"] = "Data Load Successfully";
        //    TempData["Status"] = "1";
        //    tranlog.TransactionLog(RouteData.Values["controller"].ToString(), RouteData.Values["action"].ToString(), TempData["Message"].ToString(), "", "List Show", "");

        //    return View(_hRExpSettingRepository.GetAll().ToList());
        //}

        //public IActionResult CreateHRExp()
        //{
        //    ViewBag.EmpTypeId = _empTypeRepository.GetAllForDropDown();
        //    ViewBag.LId = _locationRepository.GetLocationList();
        //    ViewBag.BId = _buildingTypeRepository.GetAllForDropDown();

        //    ViewBag.ActionType = "Create";
        //    return View();
        //}

        //[HttpPost]
        //public IActionResult CreateHRExp(Cat_HRExpSetting Cat_HRExpSetting)
        //{
        //    ViewBag.EmpTypeId = _empTypeRepository.GetAllForDropDown();
        //    ViewBag.LId = _locationRepository.GetLocationList();
        //    ViewBag.BId = _buildingTypeRepository.GetAllForDropDown();

        //    if (ModelState.IsValid)
        //    {
        //        if (Cat_HRExpSetting.Id > 0)
        //        {
        //            _hRExpSettingRepository.Update(Cat_HRExpSetting);

        //            TempData["Message"] = "Data Update Successfully";
        //            TempData["Status"] = "2";
        //            tranlog.TransactionLog(RouteData.Values["controller"].ToString(), RouteData.Values["action"].ToString(), TempData["Message"].ToString(), Cat_HRExpSetting.Id.ToString(), "Update", Cat_HRExpSetting.HRExp.ToString());

        //        }
        //        else
        //        {
        //            _hRExpSettingRepository.Add(Cat_HRExpSetting);

        //            TempData["Message"] = "Data Save Successfully";
        //            TempData["Status"] = "1";
        //            tranlog.TransactionLog(RouteData.Values["controller"].ToString(), RouteData.Values["action"].ToString(), TempData["Message"].ToString(), Cat_HRExpSetting.Id.ToString(), "Create", Cat_HRExpSetting.HRExp.ToString());

        //        }
        //        return RedirectToAction("HRExpList", "HRVariable");
        //    }
        //    return View(Cat_HRExpSetting);
        //}

        //public IActionResult EditHRExp(int id)
        //{
        //    ViewBag.EmpTypeId = _empTypeRepository.GetAllForDropDown();
        //    ViewBag.LId = _locationRepository.GetLocationList();
        //    ViewBag.BId = _buildingTypeRepository.GetAllForDropDown();

        //    if (id == null)
        //    {
        //        return NotFound();
        //    }
        //    ViewBag.ActionType = "Edit";
        //    var Cat_HRExpSetting = _hRExpSettingRepository.Find(id);
        //    if (Cat_HRExpSetting == null)
        //    {
        //        return NotFound();
        //    }
        //    return View("CreateHRExp", Cat_HRExpSetting);
        //}

        //public IActionResult DeleteHRExp(int id)
        //{
        //    ViewBag.EmpTypeId = _empTypeRepository.GetAllForDropDown();
        //    ViewBag.LId = _locationRepository.GetLocationList();
        //    ViewBag.BId = _buildingTypeRepository.GetAllForDropDown();

        //    if (id == null)
        //    {
        //        return NotFound();
        //    }

        //    var Cat_HRExpSetting = _hRExpSettingRepository.Find(id);

        //    if (Cat_HRExpSetting == null)
        //    {
        //        return NotFound();
        //    }

        //    ViewBag.ActionType = "Delete";

        //    return View("CreateHRExp", Cat_HRExpSetting);
        //}

        //[HttpPost, ActionName("DeleteStyle")]
        //public IActionResult DeleteHRExpConfirmed(int id)
        //{
        //    ViewBag.EmpTypeId = _empTypeRepository.GetAllForDropDown();
        //    ViewBag.LId = _locationRepository.GetLocationList();
        //    ViewBag.BId = _buildingTypeRepository.GetAllForDropDown();

        //    try
        //    {
        //        var Cat_HRExpSetting = _hRExpSettingRepository.Find(id);
        //        _hRExpSettingRepository.Delete(Cat_HRExpSetting);

        //        TempData["Message"] = "Data Delete Successfully";
        //        TempData["Status"] = "3";
        //        tranlog.TransactionLog(RouteData.Values["controller"].ToString(), RouteData.Values["action"].ToString(), TempData["Message"].ToString(), Cat_HRExpSetting.Id.ToString(), "Delete", Cat_HRExpSetting.HRExp.ToString());

        //        return Json(new { Success = 1, HRExpId = Cat_HRExpSetting.Id, ex = TempData["Message"].ToString() });
        //    }
        //    catch (Exception ex)
        //    {
        //        return Json(new { Success = 0, ex = ex.InnerException.InnerException.Message.ToString() });
        //    }
        //}
        //#endregion


        //#region HR Setting
        //public IActionResult HRSettingList()
        //{
        //    TempData["Message"] = "Data Load Successfully";
        //    TempData["Status"] = "1";
        //    tranlog.TransactionLog(RouteData.Values["controller"].ToString(), RouteData.Values["action"].ToString(), TempData["Message"].ToString(), "", "List Show", "");

        //    return View(_hRSettingRepository.GetAllData());
        //}

        //public IActionResult CreateHRSetting()
        //{
        //    ViewBag.EmpTypeId = _empTypeRepository.GetAllForDropDown();
        //    ViewBag.Company = _hRSettingRepository.GetCompanyName();
        //    ViewBag.LId = _locationRepository.GetLocationList();
        //    ViewBag.BId = _buildingTypeRepository.GetAllForDropDown();
        //    ViewBag.Company = new SelectList(db.Companys.ToList(), "CompanyCode", "CompanyName");
        //    ViewBag.ActionType = "Create";
        //    return View();
        //}

        //[HttpPost]
        //public IActionResult CreateHRSetting(Cat_HRSetting Cat_HRSetting)
        //{
        //    ViewBag.EmpTypeId = _empTypeRepository.GetAllForDropDown();
        //    ViewBag.Company = _hRSettingRepository.GetCompanyName();
        //    ViewBag.LId = _locationRepository.GetLocationList();
        //    ViewBag.BId = _buildingTypeRepository.GetAllForDropDown();
        //    Cat_HRSetting.UpdateByUserId = HttpContext.Session.GetString("UserId");
        //    Cat_HRSetting.DateAdded = DateTime.Parse(DateTime.Now.ToString("dd-MMM-yyyy"));
        //    Cat_HRSetting.DateUpdated = DateTime.Parse(DateTime.Now.ToString("dd-MMM-yyyy"));

        //    if (ModelState.IsValid)
        //    {
        //        if (Cat_HRSetting.Id > 0)
        //        {
        //            if (Cat_HRSetting.IsBSPersentage == true)
        //            {
        //                Cat_HRSetting.BS = Cat_HRSetting.BS / 100;
        //            }
        //            if (Cat_HRSetting.IsHRPersentage == true)
        //            {
        //                Cat_HRSetting.HR = Cat_HRSetting.HR / 100;
        //            }
        //            if (Cat_HRSetting.IsMAPersentage == true)
        //            {
        //                Cat_HRSetting.MA = Cat_HRSetting.MA / 100;
        //            }
        //            if (Cat_HRSetting.IsCAPersentage == true)
        //            {
        //                Cat_HRSetting.CA = Cat_HRSetting.CA / 100;
        //            }
        //            if (Cat_HRSetting.IsFAPersentage == true)
        //            {
        //                Cat_HRSetting.FA = Cat_HRSetting.FA / 100;
        //            }
        //            Cat_HRSetting.UpdateByUserId = HttpContext.Session.GetString("UserId");
        //            Cat_HRSetting.DateAdded = DateTime.Parse(DateTime.Now.ToString("dd-MMM-yyyy"));
        //            Cat_HRSetting.DateUpdated = DateTime.Parse(DateTime.Now.ToString("dd-MMM-yyyy"));

        //            _hRSettingRepository.Update(Cat_HRSetting);

        //            TempData["Message"] = "Data Update Successfully";
        //            TempData["Status"] = "2";
        //            tranlog.TransactionLog(RouteData.Values["controller"].ToString(), RouteData.Values["action"].ToString(), TempData["Message"].ToString(), Cat_HRSetting.Id.ToString(), "Update", Cat_HRSetting.HR.ToString());

        //        }
        //        else
        //        {

        //            if (Cat_HRSetting.IsBSPersentage == true)
        //            {
        //                Cat_HRSetting.BS = Cat_HRSetting.BS / 100;
        //            }
        //            else
        //                Cat_HRSetting.BS = Cat_HRSetting.BS;

        //            if (Cat_HRSetting.IsHRPersentage == true)
        //            {
        //                Cat_HRSetting.HR = Cat_HRSetting.HR / 100;
        //            }
        //            else
        //                Cat_HRSetting.HR = Cat_HRSetting.HR;


        //            if (Cat_HRSetting.IsMAPersentage == true)
        //            {
        //                Cat_HRSetting.MA = Cat_HRSetting.MA / 100;
        //            }
        //            else
        //                Cat_HRSetting.MA = Cat_HRSetting.MA;

        //            if (Cat_HRSetting.IsCAPersentage == true)
        //            {
        //                Cat_HRSetting.CA = Cat_HRSetting.CA / 100;
        //            }
        //            else
        //                Cat_HRSetting.CA = Cat_HRSetting.CA;

        //            if (Cat_HRSetting.IsFAPersentage == true)
        //            {
        //                Cat_HRSetting.FA = Cat_HRSetting.FA / 100;
        //            }
        //            else
        //                Cat_HRSetting.FA = Cat_HRSetting.FA;

        //            Cat_HRSetting.UpdateByUserId = HttpContext.Session.GetString("UserId");
        //            Cat_HRSetting.DateAdded = DateTime.Parse(DateTime.Now.ToString("dd-MMM-yyyy"));
        //            Cat_HRSetting.DateUpdated = DateTime.Parse(DateTime.Now.ToString("dd-MMM-yyyy"));

        //            _hRSettingRepository.Add(Cat_HRSetting);

        //            TempData["Message"] = "Data Save Successfully";
        //            TempData["Status"] = "1";
        //            tranlog.TransactionLog(RouteData.Values["controller"].ToString(), RouteData.Values["action"].ToString(), TempData["Message"].ToString(), Cat_HRSetting.Id.ToString(), "Create", Cat_HRSetting.HR.ToString());

        //        }
        //        return RedirectToAction("HRSettingList", "HRVariable");
        //    }
        //    return View(Cat_HRSetting);
        //}

        //public IActionResult EditHRSetting(int id)
        //{
        //    ViewBag.EmpTypeId = _empTypeRepository.GetAllForDropDown();
        //    ViewBag.Company = _hRSettingRepository.GetCompanyName();
        //    ViewBag.LId = _locationRepository.GetLocationList();
        //    ViewBag.BId = _buildingTypeRepository.GetAllForDropDown();
        //    if (id == null)
        //    {
        //        return NotFound();
        //    }
        //    ViewBag.ActionType = "Edit";
        //    var Cat_HRSetting = _hRSettingRepository.Find(id);
        //    if (Cat_HRSetting.IsBSPersentage == true)
        //    {
        //        Cat_HRSetting.BS = (float)Math.Round((Cat_HRSetting.BS * 100), 2);
        //    }
        //    if (Cat_HRSetting.IsHRPersentage == true)
        //    {
        //        Cat_HRSetting.HR = (float)Math.Round((Cat_HRSetting.HR * 100), 2);
        //    }
        //    if (Cat_HRSetting.IsMAPersentage == true)
        //    {
        //        Cat_HRSetting.MA = (float)Math.Round((Cat_HRSetting.MA * 100), 2);
        //    }
        //    if (Cat_HRSetting.IsCAPersentage == true)
        //    {
        //        Cat_HRSetting.CA = (float)Math.Round((Cat_HRSetting.CA * 100), 2);
        //    }
        //    if (Cat_HRSetting.IsFAPersentage == true)
        //    {
        //        Cat_HRSetting.FA = (float)Math.Round((Cat_HRSetting.FA * 100), 2);
        //    }
        //    if (Cat_HRSetting == null)
        //    {
        //        return NotFound();
        //    }
        //    return View("CreateHRSetting", Cat_HRSetting);
        //}

        //public IActionResult DeleteHRSetting(int id)
        //{
        //    ViewBag.EmpTypeId = _empTypeRepository.GetAllForDropDown();
        //    ViewBag.Company = _hRSettingRepository.GetCompanyName();
        //    ViewBag.LId = _locationRepository.GetLocationList();
        //    ViewBag.BId = _buildingTypeRepository.GetAllForDropDown();
        //    if (id == null)
        //    {
        //        return NotFound();
        //    }

        //    var Cat_HRSetting = _hRSettingRepository.Find(id);
        //    if (Cat_HRSetting.IsBSPersentage == true)
        //    {
        //        Cat_HRSetting.BS = (float)Math.Round((Cat_HRSetting.BS * 100), 2);
        //    }
        //    if (Cat_HRSetting.IsHRPersentage == true)
        //    {
        //        Cat_HRSetting.HR = (float)Math.Round((Cat_HRSetting.HR * 100), 2);
        //    }
        //    if (Cat_HRSetting.IsMAPersentage == true)
        //    {
        //        Cat_HRSetting.MA = (float)Math.Round((Cat_HRSetting.MA * 100), 2);
        //    }
        //    if (Cat_HRSetting.IsCAPersentage == true)
        //    {
        //        Cat_HRSetting.CA = (float)Math.Round((Cat_HRSetting.CA * 100), 2);
        //    }
        //    if (Cat_HRSetting.IsFAPersentage == true)
        //    {
        //        Cat_HRSetting.FA = (float)Math.Round((Cat_HRSetting.FA * 100), 2);
        //    }
        //    if (Cat_HRSetting == null)
        //    {
        //        return NotFound();
        //    }

        //    ViewBag.ActionType = "Delete";

        //    return View("CreateHRSetting", Cat_HRSetting);
        //}

        //[HttpPost, ActionName("DeleteHRSetting")]
        //public IActionResult DeleteHRSettingConfirmed(int id)
        //{
        //    ViewBag.EmpTypeId = _empTypeRepository.GetAllForDropDown();
        //    ViewBag.Company = _hRSettingRepository.GetCompanyName();
        //    ViewBag.LId = _locationRepository.GetLocationList();
        //    ViewBag.BId = _buildingTypeRepository.GetAllForDropDown();

        //    try
        //    {
        //        var Cat_HRSetting = _hRSettingRepository.Find(id);
        //        _hRSettingRepository.Delete(Cat_HRSetting);

        //        TempData["Message"] = "Data Delete Successfully";
        //        TempData["Status"] = "3";
        //        tranlog.TransactionLog(RouteData.Values["controller"].ToString(), RouteData.Values["action"].ToString(), TempData["Message"].ToString(), Cat_HRSetting.Id.ToString(), "Delete", Cat_HRSetting.HR.ToString());

        //        return Json(new { Success = 1, Id = Cat_HRSetting.Id, ex = TempData["Message"].ToString() });
        //    }
        //    catch (Exception ex)
        //    {
        //        return Json(new { Success = 0, ex = ex.InnerException.InnerException.Message.ToString() });
        //    }
        //}
        //#endregion


        //#region HRReportType 
        //public IActionResult HRReportTypeList()
        //{
        //    TempData["Message"] = "Data Load Successfully";
        //    TempData["Status"] = "1";
        //    tranlog.TransactionLog(RouteData.Values["controller"].ToString(), RouteData.Values["action"].ToString(), TempData["Message"].ToString(), "", "List Show", "");

        //    return View(_hRReportRepository.All().ToList());
        //}

        //public IActionResult CreateHRReportType()
        //{
        //    ViewBag.ActionType = "Create";
        //    ViewBag.ReportType = _hRReportRepository.GetReportType();
        //    ViewBag.ComId = _hRReportRepository.GetComId();
        //    return View();
        //}

        //[HttpPost]
        //public IActionResult CreateHRReportType(HR_ReportType HR_ReportType)
        //{

        //    ViewBag.ReportType = _hRReportRepository.GetReportType();
        //    ViewBag.ComId = _hRReportRepository.GetComId();
        //    if (ModelState.IsValid)
        //    {
        //        if (HR_ReportType.ReportId > 0)
        //        {
        //            _hRReportRepository.Update(HR_ReportType);

        //            TempData["Message"] = "Data Update Successfully";
        //            TempData["Status"] = "2";
        //            tranlog.TransactionLog(RouteData.Values["controller"].ToString(), RouteData.Values["action"].ToString(), TempData["Message"].ToString(), HR_ReportType.ReportId.ToString(), "Update", HR_ReportType.ReportName.ToString());

        //        }
        //        else
        //        {
        //            _hRReportRepository.Add(HR_ReportType);

        //            TempData["Message"] = "Data Save Successfully";
        //            TempData["Status"] = "1";
        //            tranlog.TransactionLog(RouteData.Values["controller"].ToString(), RouteData.Values["action"].ToString(), TempData["Message"].ToString(), HR_ReportType.ReportId.ToString(), "Create", HR_ReportType.ReportName.ToString());

        //        }
        //        return RedirectToAction("HRReportTypeList", "HRVariable");
        //    }
        //    return View(HR_ReportType);
        //}

        //public IActionResult EditHRReportType(int id)
        //{
        //    if (id == null)
        //    {
        //        return NotFound();
        //    }
        //    ViewBag.ReportType = _hRReportRepository.GetReportType();
        //    ViewBag.ComId = _hRReportRepository.GetComId();
        //    ViewBag.ActionType = "Edit";
        //    var HR_ReportType = _hRReportRepository.Find(id);
        //    if (HR_ReportType == null)
        //    {
        //        return NotFound();
        //    }
        //    return View("CreateHRReportType", HR_ReportType);
        //}

        //public IActionResult DeleteHRReportType(int id)
        //{
        //    if (id == null)
        //    {
        //        return NotFound();
        //    }
        //    ViewBag.ReportType = _hRReportRepository.GetReportType();
        //    ViewBag.ComId = _hRReportRepository.GetComId();
        //    var HR_ReportType = _hRReportRepository.Find(id);

        //    if (HR_ReportType == null)
        //    {
        //        return NotFound();
        //    }

        //    ViewBag.ActionType = "Delete";

        //    return View("CreateHRReportType", HR_ReportType);
        //}

        //[HttpPost, ActionName("DeleteHRReportType")]
        //public IActionResult DeleteHRReportTypeConfirmed(int id)
        //{
        //    ViewBag.ReportType = _hRReportRepository.GetReportType();
        //    ViewBag.ComId = _hRReportRepository.GetComId();
        //    try
        //    {
        //        var HR_ReportType = _hRReportRepository.Find(id);
        //        _hRReportRepository.Delete(HR_ReportType);

        //        TempData["Message"] = "Data Delete Successfully";
        //        TempData["Status"] = "3";
        //        tranlog.TransactionLog(RouteData.Values["controller"].ToString(), RouteData.Values["action"].ToString(), TempData["Message"].ToString(), HR_ReportType.ReportId.ToString(), "Delete", HR_ReportType.ReportName);

        //        return Json(new { Success = 1, StyleId = HR_ReportType.ReportId, ex = TempData["Message"].ToString() });
        //    }
        //    catch (Exception ex)
        //    {
        //        return Json(new { Success = 0, ex = ex.InnerException.InnerException.Message.ToString() });
        //    }
        //}
        //#endregion

        //#region Custom Report
        //public IActionResult HRCustomReportList()
        //{
        //    var ComId = HttpContext.Session.GetInt32("ComId");;
        //    TempData["Message"] = "Data Load Successfully";
        //    TempData["Status"] = "1";
        //    tranlog.TransactionLog(RouteData.Values["controller"].ToString(), RouteData.Values["action"].ToString(), TempData["Message"].ToString(), "", "List Show", "");



        //    //ViewBag.CompanyName = db.HR_CustomReport
        //    //                    .Include(x => x.Companys)
        //    //                    .Where(x => x.CompanyCode == ComId).ToList();

        //    return View(_hRReportRepository.GetCustomReport());
        //}

        //public IActionResult CreateHRCustomReport()
        //{
        //    ViewBag.ActionType = "Create";
        //    ViewBag.ReportType = _hRCustomReportRepository.GetReportType();
        //    ViewBag.EmpType = _hRCustomReportRepository.GetEmpType();
        //    ViewBag.CustomType = _hRCustomReportRepository.GetReportTypeCustom();
        //    ViewBag.ComId = _hRCustomReportRepository.GetComId();
        //    return View();
        //}

        //[HttpPost]
        //public IActionResult CreateHRCustomReport(HR_CustomReport HR_CustomReport)
        //{

        //    ViewBag.ReportType = _hRCustomReportRepository.GetReportType();
        //    ViewBag.CustomType = _hRCustomReportRepository.GetReportTypeCustom();
        //    ViewBag.EmpType = _hRCustomReportRepository.GetEmpType();
        //    ViewBag.ComId = _hRCustomReportRepository.GetComId();
        //    if (ModelState.IsValid)
        //    {
        //        if (HR_CustomReport.CustomReportId > 0)
        //        {
        //            _hRCustomReportRepository.Update(HR_CustomReport);

        //            TempData["Message"] = "Data Update Successfully";
        //            TempData["Status"] = "2";
        //            tranlog.TransactionLog(RouteData.Values["controller"].ToString(), RouteData.Values["action"].ToString(), TempData["Message"].ToString(), HR_CustomReport.CustomReportId.ToString(), "Update", HR_CustomReport.ReportName.ToString());

        //        }
        //        else
        //        {
        //            _hRCustomReportRepository.Add(HR_CustomReport);

        //            TempData["Message"] = "Data Save Successfully";
        //            TempData["Status"] = "1";
        //            tranlog.TransactionLog(RouteData.Values["controller"].ToString(), RouteData.Values["action"].ToString(), TempData["Message"].ToString(), HR_CustomReport.CustomReportId.ToString(), "Create", HR_CustomReport.ReportName.ToString());

        //        }
        //        return RedirectToAction("HRCustomReportList", "HRVariable");
        //    }
        //    return View(HR_CustomReport);
        //}

        //public IActionResult EditHRCustomReport(int id)
        //{
        //    if (id == null)
        //    {
        //        return NotFound();
        //    }
        //    ViewBag.ReportType = _hRCustomReportRepository.GetReportType();
        //    ViewBag.CustomType = _hRCustomReportRepository.GetReportTypeCustom();
        //    ViewBag.EmpType = _hRCustomReportRepository.GetEmpType();
        //    ViewBag.ComId = _hRCustomReportRepository.GetComId();
        //    ViewBag.ActionType = "Edit";
        //    var HR_CustomReport = _hRCustomReportRepository.Find(id);
        //    if (HR_CustomReport == null)
        //    {
        //        return NotFound();
        //    }
        //    return View("CreateHRCustomReport", HR_CustomReport);
        //}

        //public IActionResult DeleteHRCustomReport(int id)
        //{
        //    if (id == null)
        //    {
        //        return NotFound();
        //    }
        //    ViewBag.ReportType = _hRCustomReportRepository.GetReportType();
        //    ViewBag.CustomType = _hRCustomReportRepository.GetReportTypeCustom();
        //    ViewBag.EmpType = _hRCustomReportRepository.GetEmpType();
        //    ViewBag.ComId = _hRCustomReportRepository.GetComId();
        //    var HR_CustomReport = _hRCustomReportRepository.Find(id);

        //    if (HR_CustomReport == null)
        //    {
        //        return NotFound();
        //    }

        //    ViewBag.ActionType = "Delete";

        //    return View("CreateHRCustomReport", HR_CustomReport);
        //}

        //[HttpPost, ActionName("DeleteHRCustomReport")]
        //public IActionResult DeleteHRCustomReportConfirmed(int id)
        //{
        //    ViewBag.ReportType = _hRCustomReportRepository.GetReportType();
        //    ViewBag.CustomType = _hRCustomReportRepository.GetReportTypeCustom();
        //    ViewBag.EmpType = _hRCustomReportRepository.GetEmpType();
        //    ViewBag.ComId = _hRCustomReportRepository.GetComId();
        //    try
        //    {
        //        var HR_CustomReport = _hRCustomReportRepository.Find(id);
        //        _hRCustomReportRepository.Delete(HR_CustomReport);

        //        TempData["Message"] = "Data Delete Successfully";
        //        TempData["Status"] = "3";
        //        tranlog.TransactionLog(RouteData.Values["controller"].ToString(), RouteData.Values["action"].ToString(), TempData["Message"].ToString(), HR_CustomReport.CustomReportId.ToString(), "Delete", HR_CustomReport.ReportName);

        //        return Json(new { Success = 1, StyleId = HR_CustomReport.CustomReportId, ex = TempData["Message"].ToString() });
        //    }
        //    catch (Exception ex)
        //    {
        //        return Json(new { Success = 0, ex = ex.InnerException.InnerException.Message.ToString() });
        //    }
        //}
        //#endregion


        //#region Strength
        //public IActionResult StrengthList()
        //{
        //    TempData["Message"] = "Data Load Successfully";
        //    TempData["Status"] = "1";
        //    tranlog.TransactionLog(RouteData.Values["controller"].ToString(), RouteData.Values["action"].ToString(), TempData["Message"].ToString(), "", "List Show", "");

        //    return View(_strengthRepository.All().ToList());
        //}

        //public IActionResult CreateStrength()
        //{
        //    ViewBag.ActionType = "Create";
        //    ViewData["strengthType"] = _strengthRepository.GetStrengthList();
        //    return View();
        //}

        //[HttpPost]
        //public IActionResult CreateStrength(Cat_Strength Cat_Strength)
        //{
        //    ViewData["strengthType"] = _strengthRepository.GetStrengthList();
        //    if (ModelState.IsValid)
        //    {
        //        if (Cat_Strength.StId > 0)
        //        {
        //            _strengthRepository.Update(Cat_Strength);

        //            TempData["Message"] = "Data Update Successfully";
        //            TempData["Status"] = "2";
        //            tranlog.TransactionLog(RouteData.Values["controller"].ToString(), RouteData.Values["action"].ToString(), TempData["Message"].ToString(), Cat_Strength.StId.ToString(), "Update", Cat_Strength.StrengthType.ToString());

        //        }
        //        else
        //        {
        //            _strengthRepository.Add(Cat_Strength);

        //            TempData["Message"] = "Data Save Successfully";
        //            TempData["Status"] = "1";
        //            tranlog.TransactionLog(RouteData.Values["controller"].ToString(), RouteData.Values["action"].ToString(), TempData["Message"].ToString(), Cat_Strength.StId.ToString(), "Create", Cat_Strength.StrengthType.ToString());

        //        }
        //        return RedirectToAction("StrengthList", "HRVariable");
        //    }
        //    return View(Cat_Strength);
        //}
        //public JsonResult GetStates(string id)
        //{
        //    if (id == "1")
        //    {
        //        var state = _departmentRepository.GetAll()

        //                .Select(l => new
        //                {
        //                    a = l.DeptId,
        //                    b = l.DeptName,

        //                }).OrderBy(l => l.b).ToList();

        //        return Json(state);

        //    }
        //    else if (id == "2")
        //    {
        //        var state = _sectionRepository.GetAll()

        //            .Select(l => new
        //            {
        //                a = l.SectId,
        //                b = l.SectName,

        //            }).OrderBy(l => l.b).ToList();

        //        return Json(state);
        //    }
        //    else if (id == "3")
        //    {
        //        var state = _designationRepository.GetAll()

        //            .Select(l => new
        //            {
        //                a = l.DesigId,
        //                b = l.DesigName,

        //            }).OrderBy(l => l.b).ToList();

        //        return Json(state);
        //    }

        //    return Json("No data found");
        //}

        //public IActionResult EditStrength(int id)
        //{
        //    ViewData["strengthType"] = _strengthRepository.GetStrengthList();
        //    if (id == null)
        //    {
        //        return NotFound();
        //    }
        //    ViewBag.ActionType = "Edit";
        //    var Cat_Strength = _strengthRepository.Find(id);
        //    if (Cat_Strength == null)
        //    {
        //        return NotFound();
        //    }
        //    return View("CreateStrength", Cat_Strength);
        //}

        //public IActionResult DeleteStrength(int id)
        //{
        //    ViewData["strengthType"] = _strengthRepository.GetStrengthList();
        //    if (id == null)
        //    {
        //        return NotFound();
        //    }

        //    var Cat_Strength = _strengthRepository.Find(id);

        //    if (Cat_Strength == null)
        //    {
        //        return NotFound();
        //    }

        //    ViewBag.ActionType = "Delete";

        //    return View("CreateStrength", Cat_Strength);
        //}

        //[HttpPost, ActionName("DeleteStrength")]
        //public IActionResult DeleteStrengthConfirmed(int id)
        //{
        //    ViewData["strengthType"] = _strengthRepository.GetStrengthList();
        //    try
        //    {
        //        var Cat_Strength = _strengthRepository.Find(id);
        //        _strengthRepository.Delete(Cat_Strength);

        //        TempData["Message"] = "Data Delete Successfully";
        //        TempData["Status"] = "3";
        //        tranlog.TransactionLog(RouteData.Values["controller"].ToString(), RouteData.Values["action"].ToString(), TempData["Message"].ToString(), Cat_Strength.StId.ToString(), "Delete", Cat_Strength.StrengthType);

        //        return Json(new { Success = 1, StId = Cat_Strength.StId, ex = TempData["Message"].ToString() });
        //    }
        //    catch (Exception ex)
        //    {
        //        return Json(new { Success = 0, ex = ex.InnerException.InnerException.Message.ToString() });
        //    }
        //}
        //#endregion


        //#region Sub Section
        //public IActionResult SubSectList()
        //{
        //    TempData["Message"] = "Data Load Successfully";
        //    TempData["Status"] = "1";
        //    tranlog.TransactionLog(RouteData.Values["controller"].ToString(), RouteData.Values["action"].ToString(), TempData["Message"].ToString(), "", "List Show", "");

        //    //var section
        //    return View(_subSectionRepository.GetSubSectionAll());
        //}

        //// GET: Section/Details/5
        //public IActionResult SubSectDetails(int id)
        //{
        //    if (id == null)
        //    {
        //        return NotFound();
        //    }

        //    var cat_SubSection = _subSectionRepository.Details(id);
        //    if (cat_SubSection == null)
        //    {
        //        return NotFound();
        //    }

        //    return View(cat_SubSection);
        //}

        //// GET: Section/Create
        //public IActionResult CreateSubSect()
        //{
        //    ViewBag.ActionType = "Create";
        //    ViewBag.DeptId = _departmentRepository.GetAllForDropDown();
        //    ViewBag.SectId = _sectionRepository.GetAllForDropDown();
        //    return View();
        //}

        //// POST: Section/Create
        //// To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        //// more details see http://go.microsoft.com/fwlink/?LinkId=317598.

        //[HttpPost]
        ////  [ValidateAntiForgeryToken]
        //public IActionResult CreateSubSect(Cat_SubSection cat_SubSection)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        cat_SubSection.UserId = HttpContext.Session.GetString("UserId");
        //        cat_SubSection.ComId = HttpContext.Session.GetInt32("ComId");;

        //        cat_SubSection.DateUpdated = DateTime.Today;
        //        cat_SubSection.DtInput = DateTime.Today;
        //        cat_SubSection.DateAdded = DateTime.Today;

        //        if (cat_SubSection.SubSectId > 0)
        //        {
        //            cat_SubSection.UpdateByUserId = HttpContext.Session.GetString("UserId");
        //            _subSectionRepository.Update(cat_SubSection);
        //            TempData["Message"] = "Data Update Successfully";
        //            TempData["Status"] = "2";
        //            tranlog.TransactionLog(RouteData.Values["controller"].ToString(), RouteData.Values["action"].ToString(), TempData["Message"].ToString(), cat_SubSection.SubSectId.ToString(), "Update", cat_SubSection.SubSectName.ToString());

        //        }
        //        else
        //        {
        //            _subSectionRepository.Add(cat_SubSection);
        //            TempData["Message"] = "Data Save Successfully";
        //            TempData["Status"] = "1";
        //            tranlog.TransactionLog(RouteData.Values["controller"].ToString(), RouteData.Values["action"].ToString(), TempData["Message"].ToString(), cat_SubSection.SubSectId.ToString(), "Create", cat_SubSection.SubSectName.ToString());

        //        }
        //        return RedirectToAction(nameof(SubSectList));
        //    }
        //    return View(cat_SubSection);
        //}

        //// GET: Section/Edit/5
        //public IActionResult EditSubSect(int id)
        //{
        //    if (id == null)
        //    {
        //        return NotFound();
        //    }
        //    ViewBag.ActionType = "Edit";
        //    var cat_SubSection = _subSectionRepository.Find(id);
        //    ViewBag.DeptId = _departmentRepository.GetAllForDropDown();
        //    ViewBag.SectId = _sectionRepository.GetAllForDropDown();
        //    if (cat_SubSection == null)
        //    {
        //        return NotFound();
        //    }
        //    return View("CreateSubSect", cat_SubSection);
        //}


        //// GET: Section/Delete/5
        //public IActionResult DeleteSubSect(int id)
        //{
        //    if (id == null)
        //    {
        //        return NotFound();
        //    }

        //    var cat_SubSection = _subSectionRepository.Details(id);
        //    if (cat_SubSection == null)
        //    {
        //        return NotFound();
        //    }


        //    ViewBag.ActionType = "Delete";
        //    ViewBag.DeptId = _departmentRepository.GetAllForDropDown();
        //    ViewBag.SectId = _sectionRepository.GetAllForDropDown();

        //    return View("CreateSubSect", cat_SubSection);

        //}

        //// POST: Section/Delete/5
        //[HttpPost, ActionName("DeleteSubSect")]
        ////[ValidateAntiForgeryToken]
        //public IActionResult DeleteSubSectConfirmed(int id)
        //{
        //    try
        //    {
        //        var cat_SubSection = _subSectionRepository.Find(id);
        //        _subSectionRepository.Delete(cat_SubSection);

        //        TempData["Message"] = "Data Delete Successfully";
        //        TempData["Status"] = "3";
        //        tranlog.TransactionLog(RouteData.Values["controller"].ToString(), RouteData.Values["action"].ToString(), TempData["Message"].ToString(), cat_SubSection.SubSectId.ToString(), "Delete", cat_SubSection.SubSectName);
        //        //TempData["Message"] = "Data Delete Successfully";
        //        return Json(new { Success = 1, SubSectId = cat_SubSection.SubSectId, ex = TempData["Message"].ToString() });
        //    }
        //    catch (Exception ex)
        //    {
        //        // If Sucess== 0 then Unable to perform Save/Update Operation and send Exception to View as JSON
        //        return Json(new { Success = 0, ex = ex.InnerException.InnerException.Message.ToString() });
        //    }
        //}
        //#endregion

        //#region Size
        //public IActionResult SizeList()
        //{
        //    TempData["Message"] = "Data Load Successfully";
        //    TempData["Status"] = "1";
        //    tranlog.TransactionLog(RouteData.Values["controller"].ToString(), RouteData.Values["action"].ToString(), TempData["Message"].ToString(), "", "List Show", "");
        //    return View(_sizeRepository.GetAll().Include(x => x.Cat_Color));
        //}



        //// GET: Size
        //public IActionResult CreateSize()
        //{
        //    ViewBag.ActionType = "Create";
        //    ViewBag.Color = _colorRepository.GetColor();
        //    return View();
        //}

        //// POST: Section/Create
        //// To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        //// more details see http://go.microsoft.com/fwlink/?LinkId=317598.

        //[HttpPost]
        ////  [ValidateAntiForgeryToken]
        //public IActionResult CreateSize(Cat_Size cat_Size)
        //{
        //    ViewBag.Color = _colorRepository.GetColor();
        //    if (ModelState.IsValid)
        //    {
        //        cat_Size.UserId = HttpContext.Session.GetString("UserId");
        //        cat_Size.ComId = HttpContext.Session.GetInt32("ComId");;

        //        cat_Size.DateUpdated = DateTime.Today;
        //        cat_Size.DateAdded = DateTime.Today;

        //        if (cat_Size.SizeId > 0)
        //        {
        //            cat_Size.UpdateByUserId = HttpContext.Session.GetString("UserId");
        //            _sizeRepository.Update(cat_Size);
        //            TempData["Message"] = "Data Update Successfully";
        //            TempData["Status"] = "2";
        //            tranlog.TransactionLog(RouteData.Values["controller"].ToString(), RouteData.Values["action"].ToString(), TempData["Message"].ToString(), cat_Size.SizeId.ToString(), "Update", cat_Size.SizeName.ToString());

        //        }
        //        else
        //        {
        //            _sizeRepository.Add(cat_Size);
        //            TempData["Message"] = "Data Save Successfully";
        //            TempData["Status"] = "1";
        //            tranlog.TransactionLog(RouteData.Values["controller"].ToString(), RouteData.Values["action"].ToString(), TempData["Message"].ToString(), cat_Size.SizeId.ToString(), "Create", cat_Size.SizeName.ToString());

        //        }
        //        return RedirectToAction(nameof(SizeList));
        //    }
        //    return View(cat_Size);
        //}

        //// GET: Size/Edit/5
        //public IActionResult EditSize(int id)
        //{
        //    if (id == null)
        //    {
        //        return NotFound();
        //    }
        //    ViewBag.ActionType = "Edit";
        //    var cat_Size = _sizeRepository.Find(id);
        //    ViewBag.Color = _colorRepository.GetColor();

        //    if (cat_Size == null)
        //    {
        //        return NotFound();
        //    }
        //    return View("CreateSize", cat_Size);
        //}


        //// GET: Section/Delete/5
        //public IActionResult DeleteSize(int id)
        //{
        //    ViewBag.Color = _colorRepository.GetColor();
        //    if (id == null)
        //    {
        //        return NotFound();
        //    }

        //    var cat_Size = _sizeRepository.Find(id);
        //    if (cat_Size == null)
        //    {
        //        return NotFound();
        //    }


        //    ViewBag.ActionType = "Delete";


        //    return View("CreateSize", cat_Size);

        //}

        //// POST: Section/Delete/5
        //[HttpPost, ActionName("DeleteSize")]
        ////[ValidateAntiForgeryToken]
        //public IActionResult DeleteSizeConfirmed(int id)
        //{
        //    ViewBag.Color = _colorRepository.GetColor();
        //    try
        //    {
        //        var cat_Size = _sizeRepository.Find(id);
        //        _sizeRepository.Delete(cat_Size);

        //        TempData["Message"] = "Data Delete Successfully";
        //        TempData["Status"] = "3";
        //        tranlog.TransactionLog(RouteData.Values["controller"].ToString(), RouteData.Values["action"].ToString(), TempData["Message"].ToString(), cat_Size.SizeId.ToString(), "Delete", cat_Size.SizeName);
        //        //TempData["Message"] = "Data Delete Successfully";
        //        return Json(new { Success = 1, SubSectId = cat_Size.SizeId, ex = TempData["Message"].ToString() });
        //    }
        //    catch (Exception ex)
        //    {
        //        // If Sucess== 0 then Unable to perform Save/Update Operation and send Exception to View as JSON
        //        return Json(new { Success = 0, ex = ex.InnerException.InnerException.Message.ToString() });
        //    }
        //}
        //#endregion

        //#region Color
        //public IActionResult ColorList()
        //{
        //    TempData["Message"] = "Data Load Successfully";
        //    TempData["Status"] = "1";
        //    tranlog.TransactionLog(RouteData.Values["controller"].ToString(), RouteData.Values["action"].ToString(), TempData["Message"].ToString(), "", "List Show", "");
        //    return View(_colorRepository.GetAll().Include(x => x.Cat_Style));
        //}



        //// GET: Size
        //public IActionResult CreateColor()
        //{
        //    ViewBag.ActionType = "Create";
        //    ViewBag.Color = _colorRepository.GetColor();
        //    ViewBag.Style = _styleRepository.GetStyleList();
        //    return View();
        //}

        //// POST: Section/Create
        //// To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        //// more details see http://go.microsoft.com/fwlink/?LinkId=317598.

        //[HttpPost]
        ////  [ValidateAntiForgeryToken]
        //public IActionResult CreateColor(Cat_Color cat_Color)
        //{
        //    ViewBag.Color = _colorRepository.GetColor();
        //    ViewBag.Style = _styleRepository.GetStyleList();
        //    if (ModelState.IsValid)
        //    {
        //        cat_Color.UserId = HttpContext.Session.GetString("UserId");
        //        cat_Color.ComId = HttpContext.Session.GetInt32("ComId");;

        //        cat_Color.DateUpdated = DateTime.Today;
        //        cat_Color.DateAdded = DateTime.Today;

        //        if (cat_Color.ColorId > 0)
        //        {
        //            cat_Color.UpdateByUserId = HttpContext.Session.GetString("UserId");
        //            _colorRepository.Update(cat_Color);
        //            TempData["Message"] = "Data Update Successfully";
        //            TempData["Status"] = "2";
        //            tranlog.TransactionLog(RouteData.Values["controller"].ToString(), RouteData.Values["action"].ToString(), TempData["Message"].ToString(), cat_Color.ColorId.ToString(), "Update", cat_Color.ColorName.ToString());

        //        }
        //        else
        //        {
        //            _colorRepository.Add(cat_Color);
        //            TempData["Message"] = "Data Save Successfully";
        //            TempData["Status"] = "1";
        //            tranlog.TransactionLog(RouteData.Values["controller"].ToString(), RouteData.Values["action"].ToString(), TempData["Message"].ToString(), cat_Color.ColorId.ToString(), "Create", cat_Color.ColorName.ToString());

        //        }
        //        return RedirectToAction(nameof(ColorList));
        //    }
        //    return View(cat_Color);
        //}

        //// GET: Size/Edit/5
        //public IActionResult EditColor(int id)
        //{
        //    if (id == null)
        //    {
        //        return NotFound();
        //    }
        //    ViewBag.ActionType = "Edit";
        //    var cat_Color = _colorRepository.Find(id);
        //    ViewBag.Style = _styleRepository.GetStyleList();
        //    ViewBag.Color = _colorRepository.GetColor();

        //    if (cat_Color == null)
        //    {
        //        return NotFound();
        //    }
        //    return View("CreateColor", cat_Color);
        //}


        //// GET: Section/Delete/5
        //public IActionResult DeleteColor(int id)
        //{
        //    ViewBag.Color = _colorRepository.GetColor();
        //    ViewBag.Style = _styleRepository.GetStyleList();
        //    if (id == null)
        //    {
        //        return NotFound();
        //    }

        //    var cat_Color = _colorRepository.Find(id);
        //    if (cat_Color == null)
        //    {
        //        return NotFound();
        //    }


        //    ViewBag.ActionType = "Delete";


        //    return View("CreateColor", cat_Color);

        //}

        //// POST: Section/Delete/5
        //[HttpPost, ActionName("DeleteColor")]
        ////[ValidateAntiForgeryToken]
        //public IActionResult DeleteColorConfirmed(int id)
        //{
        //    ViewBag.Color = _colorRepository.GetColor();
        //    ViewBag.Style = _styleRepository.GetStyleList();
        //    try
        //    {
        //        var cat_Color = _colorRepository.Find(id);
        //        _colorRepository.Delete(cat_Color);

        //        TempData["Message"] = "Data Delete Successfully";
        //        TempData["Status"] = "3";
        //        tranlog.TransactionLog(RouteData.Values["controller"].ToString(), RouteData.Values["action"].ToString(), TempData["Message"].ToString(), cat_Color.ColorId.ToString(), "Delete", cat_Color.ColorName);
        //        //TempData["Message"] = "Data Delete Successfully";
        //        return Json(new { Success = 1, SubSectId = cat_Color.ColorId, ex = TempData["Message"].ToString() });
        //    }
        //    catch (Exception ex)
        //    {
        //        // If Sucess== 0 then Unable to perform Save/Update Operation and send Exception to View as JSON
        //        return Json(new { Success = 0, ex = ex.InnerException.InnerException.Message.ToString() });
        //    }
        //}
        //#endregion

        //#region HR Overtime Setting
        //public IActionResult OvertimeSettingList()
        //{
        //    return View(_hROvertimeSettingRepository.GetOvertimeList());
        //}
        //public IActionResult CreateOvertimeSetting()
        //{
        //    ViewBag.ActionType = "Create";
        //    ViewBag.CompanyName = _hROvertimeSettingRepository.GetCompany();
        //    return View();
        //}

        //[HttpPost]
        ////  [ValidateAntiForgeryToken]
        //public IActionResult CreateOvertimeSetting(HR_OverTimeSetting Overtime)
        //{

        //    if (ModelState.IsValid)
        //    {
        //        Overtime.DateUpdated = DateTime.Today;
        //        Overtime.DateAdded = DateTime.Today;

        //        if (Overtime.Id > 0)
        //        {
        //            //Overtime.UpdateByUserId = HttpContext.Session.GetString("UserId");
        //            _hROvertimeSettingRepository.Update(Overtime);
        //            TempData["Message"] = "Data Update Successfully";
        //            TempData["Status"] = "2";
        //            tranlog.TransactionLog(RouteData.Values["controller"].ToString(), RouteData.Values["action"].ToString(), TempData["Message"].ToString(), Overtime.Id.ToString(), "Update", Overtime.CompanyId.ToString());

        //        }
        //        else
        //        {

        //            _hROvertimeSettingRepository.Add(Overtime);
        //            TempData["Message"] = "Data Save Successfully";
        //            TempData["Status"] = "1";
        //            tranlog.TransactionLog(RouteData.Values["controller"].ToString(), RouteData.Values["action"].ToString(), TempData["Message"].ToString(), Overtime.Id.ToString(), "Create", Overtime.CompanyId.ToString());

        //        }
        //        return RedirectToAction(nameof(OvertimeSettingList));
        //    }
        //    return View(Overtime);
        //}

        //public IActionResult EditOvertimeSetting(int id)
        //{
        //    ViewBag.CompanyName = _hROvertimeSettingRepository.GetCompany();
        //    if (id == null)
        //    {
        //        return NotFound();
        //    }
        //    ViewBag.ActionType = "Edit";
        //    var Overtime = _hROvertimeSettingRepository.Find(id);

        //    if (Overtime == null)
        //    {
        //        return NotFound();
        //    }
        //    return View("CreateOvertimeSetting", Overtime);
        //}

        //public IActionResult DeleteOvertimeSetting(int id)
        //{
        //    ViewBag.CompanyName = _hROvertimeSettingRepository.GetCompany();
        //    if (id == null)
        //    {
        //        return NotFound();
        //    }

        //    var Overtime = _hROvertimeSettingRepository.Find(id);
        //    if (Overtime == null)
        //    {
        //        return NotFound();
        //    }


        //    ViewBag.ActionType = "Delete";


        //    return View("CreateOvertimeSetting", Overtime);

        //}

        //// POST: Section/Delete/5
        //[HttpPost, ActionName("DeleteOvertimeSetting")]
        ////[ValidateAntiForgeryToken]
        //public IActionResult DeleteOvertimeSettingConfirmed(int id)
        //{
        //    ViewBag.CompanyName = _hROvertimeSettingRepository.GetCompany();
        //    try
        //    {
        //        var Overtime = _hROvertimeSettingRepository.Find(id);
        //        _hROvertimeSettingRepository.Delete(Overtime);

        //        TempData["Message"] = "Data Delete Successfully";
        //        TempData["Status"] = "3";
        //        tranlog.TransactionLog(RouteData.Values["controller"].ToString(), RouteData.Values["action"].ToString(), TempData["Message"].ToString(), Overtime.Id.ToString(), "Delete", Overtime.CompanyId);
        //        //TempData["Message"] = "Data Delete Successfully";
        //        return Json(new { Success = 1, SubSectId = Overtime.Id, ex = TempData["Message"].ToString() });
        //    }
        //    catch (Exception ex)
        //    {

        //        return Json(new { Success = 0, ex = ex.InnerException.InnerException.Message.ToString() });
        //    }
        //}
        //#endregion

        //#region Income Tax Amount Setting
        //public IActionResult TaxSettingList()
        //{
        //    return View(_taxAmountSettingRepository.GetIncometaxList());
        //}



        //// GET: Size
        //public IActionResult CreateTaxSetting()
        //{
        //    ViewBag.CompanyName = _hROvertimeSettingRepository.GetCompany();
        //    ViewBag.ActionType = "Create";
        //    return View();
        //}

        //// POST: Section/Create
        //// To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        //// more details see http://go.microsoft.com/fwlink/?LinkId=317598.

        //[HttpPost]
        ////  [ValidateAntiForgeryToken]
        //public IActionResult CreateTaxSetting(Payroll_InComeTaxAmountSetting tax)
        //{

        //    if (ModelState.IsValid)
        //    {
        //        if (tax.Id > 0)
        //        {

        //            _taxAmountSettingRepository.UpdateData(tax);
        //            TempData["Message"] = "Data Update Successfully";
        //            TempData["Status"] = "2";
        //            tranlog.TransactionLog(RouteData.Values["controller"].ToString(), RouteData.Values["action"].ToString(), TempData["Message"].ToString(), tax.Id.ToString(), "Update", tax.IncomeTax.ToString());

        //        }
        //        else
        //        {
        //            _taxAmountSettingRepository.SaveData(tax);
        //            TempData["Message"] = "Data Save Successfully";
        //            TempData["Status"] = "1";
        //            tranlog.TransactionLog(RouteData.Values["controller"].ToString(), RouteData.Values["action"].ToString(), TempData["Message"].ToString(), tax.Id.ToString(), "Create", tax.IncomeTax.ToString());

        //        }
        //        return RedirectToAction(nameof(TaxSettingList));
        //    }
        //    return View(tax);
        //}

        //// GET: Size/Edit/5
        //public IActionResult EditTaxSetting(int id)
        //{
        //    ViewBag.CompanyName = _hROvertimeSettingRepository.GetCompany();
        //    if (id == null)
        //    {
        //        return NotFound();
        //    }
        //    ViewBag.ActionType = "Edit";
        //    var tax = _taxAmountSettingRepository.Find(id);

        //    if (tax == null)
        //    {
        //        return NotFound();
        //    }
        //    return View("CreateTaxSetting", tax);
        //}


        //// GET: Section/Delete/5
        //public IActionResult DeleteTaxSetting(int id)
        //{

        //    if (id == null)
        //    {
        //        return NotFound();
        //    }

        //    var tax = _taxAmountSettingRepository.Find(id);
        //    if (tax == null)
        //    {
        //        return NotFound();
        //    }


        //    ViewBag.ActionType = "Delete";


        //    return View("CreateTaxSetting", tax);

        //}

        //// POST: Section/Delete/5
        //[HttpPost, ActionName("DeleteTaxSetting")]
        ////[ValidateAntiForgeryToken]
        //public IActionResult DeleteTaxSettingConfirmed(int id)
        //{

        //    try
        //    {
        //        var tax = _taxAmountSettingRepository.Find(id);
        //        _taxAmountSettingRepository.Delete(tax);

        //        TempData["Message"] = "Data Delete Successfully";
        //        TempData["Status"] = "3";
        //        tranlog.TransactionLog(RouteData.Values["controller"].ToString(), RouteData.Values["action"].ToString(), TempData["Message"].ToString(), tax.Id.ToString(), "Delete", tax.IncomeTax.ToString());
        //        //TempData["Message"] = "Data Delete Successfully";
        //        return Json(new { Success = 1, Id = tax.Id, ex = TempData["Message"].ToString() });
        //    }
        //    catch (Exception ex)
        //    {
        //        // If Sucess== 0 then Unable to perform Save/Update Operation and send Exception to View as JSON
        //        return Json(new { Success = 0, ex = ex.InnerException.InnerException.Message.ToString() });
        //    }
        //}
        //#endregion


        //#region HR Approval Setting
        //public IActionResult HRApprovalSettingList()
        //{
        //    var data = _hR_ApprovalSettingRepository.GetApproveList();
        //    return View(data);
        //}



        //// GET: Size
        //public IActionResult CreateHRApproval()
        //{
        //    var userid = HttpContext.Session.GetString("UserId");
        //    ViewBag.CompanyName = _hROvertimeSettingRepository.GetCompany();

        //    ViewBag.useridPermission = _hR_ApprovalSettingRepository.GetUserList();

        //    ViewBag.ApprovalList = _hR_ApprovalSettingRepository.GetApprovalType();
        //    ViewBag.ActionType = "Create";
        //    return View();
        //}

        //// POST: Section/Create
        //// To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        //// more details see http://go.microsoft.com/fwlink/?LinkId=317598.

        //[HttpPost]
        ////  [ValidateAntiForgeryToken]
        //public IActionResult CreateHRApproval(HR_ApprovalSetting approval)
        //{

        //    if (ModelState.IsValid)
        //    {
        //        if (approval.ApprovalSettingId > 0)
        //        {

        //            _hR_ApprovalSettingRepository.Update(approval);
        //            TempData["Message"] = "Data Update Successfully";
        //            TempData["Status"] = "2";
        //            tranlog.TransactionLog(RouteData.Values["controller"].ToString(), RouteData.Values["action"].ToString(), TempData["Message"].ToString(), approval.ApprovalSettingId.ToString(), "Update", approval.UserId.ToString());

        //        }
        //        else
        //        {
        //            _hR_ApprovalSettingRepository.Add(approval);
        //            TempData["Message"] = "Data Save Successfully";
        //            TempData["Status"] = "1";
        //            tranlog.TransactionLog(RouteData.Values["controller"].ToString(), RouteData.Values["action"].ToString(), TempData["Message"].ToString(), approval.ApprovalSettingId.ToString(), "Create", approval.UserId.ToString());

        //        }
        //        return RedirectToAction(nameof(HRApprovalSettingList));
        //    }
        //    return View(approval);
        //}

        //// GET: Size/Edit/5
        //public IActionResult EditHRApproval(int id)
        //{
        //    ViewBag.CompanyName = _hROvertimeSettingRepository.GetCompany();
        //    ViewBag.useridPermission = _hR_ApprovalSettingRepository.GetUserList();
        //    ViewBag.ApprovalList = _hR_ApprovalSettingRepository.GetApprovalType();

        //    if (id == null)
        //    {
        //        return NotFound();
        //    }
        //    ViewBag.ActionType = "Edit";
        //    var approval = _hR_ApprovalSettingRepository.Find(id);

        //    if (approval == null)
        //    {
        //        return NotFound();
        //    }
        //    return View("CreateHRApproval", approval);
        //}


        //// GET: Section/Delete/5
        //public IActionResult DeleteHRApproval(int id)
        //{

        //    if (id == null)
        //    {
        //        return NotFound();
        //    }

        //    var approval = _hR_ApprovalSettingRepository.Find(id);
        //    if (approval == null)
        //    {
        //        return NotFound();
        //    }


        //    ViewBag.ActionType = "Delete";


        //    return View("CreateHRApproval", approval);

        //}

        //// POST: Section/Delete/5
        //[HttpPost, ActionName("DeleteHRApproval")]
        ////[ValidateAntiForgeryToken]
        //public IActionResult DeleteHRApprovalConfirmed(int id)
        //{

        //    try
        //    {
        //        var approval = _hR_ApprovalSettingRepository.Find(id);
        //        _hR_ApprovalSettingRepository.Delete(approval);

        //        TempData["Message"] = "Data Delete Successfully";
        //        TempData["Status"] = "3";
        //        tranlog.TransactionLog(RouteData.Values["controller"].ToString(), RouteData.Values["action"].ToString(), TempData["Message"].ToString(), approval.ApprovalSettingId.ToString(), "Delete", approval.UserId.ToString());
        //        return Json(new { Success = 1, Id = approval.ApprovalSettingId, ex = TempData["Message"].ToString() });
        //    }
        //    catch (Exception ex)
        //    {
        //        // If Sucess== 0 then Unable to perform Save/Update Operation and send Exception to View as JSON
        //        return Json(new { Success = 0, ex = ex.InnerException.InnerException.Message.ToString() });
        //    }
        //}
        //#endregion






        #region Job Card
        public IActionResult JobCard()
        {
            var comid = HttpContext.Session.GetInt32("ComId");
            var userid = HttpContext.Session.GetInt32("UserId");

            //List<Cat_SectionModel> Cat_Sections = new List<Cat_SectionModel>();
            //Cat_Sections = db.Cat_Section.Where(x => x.ComId == comid && !x.IsDelete).ToList();
            ViewBag.Sections = _sectionRepository.GetAllForDropDown();

            //List<Cat_SubSectionModel> SubSection = new List<Cat_SubSectionModel>();
            //SubSection = db.Cat_SubSection.Include(x => x.Sect).Where(x => x.ComId == comid && !x.IsDelete).ToList();
            ViewBag.SubSection = _subSectionRepository.GetAllForDropDown();

            //List<Cat_DesignationModel> Designation = new List<Cat_DesignationModel>();
            //Designation = db.Cat_Designation.Where(x => x.ComId == comid && !x.IsDelete).ToList();
            ViewBag.Designaiton = _designationRepository.GetAllForDropDown();

            //List<Cat_DepartmentModel> DepartmentList = new List<Cat_DepartmentModel>();
            //DepartmentList = db.Cat_Department.Where(x => x.ComId == comid && !x.IsDelete).ToList();
            ViewBag.Department = _departmentRepository.GetAllForDropDown();

            //List<EmployeeModel> employee = new List<EmployeeModel>();
            //employee = db.HR_Emp_Info
            //    .Include(d => d.Cat_Designation)
            //    .Where(x => x.ComId == comid && !x.IsDelete)
            //    .OrderBy(o => o.EmpCode)
            //    .ToList();
            ViewBag.Employee = _empInfoRepository.GetAllForDropDown();// .All().Include(x => x.DesignationList).ToList();

            //List<Cat_Floor> Floors = new List<Cat_Floor>();
            //Floors = db.Cat_Floor.Where(a => a.ComId == comid && !a.IsDelete).ToList();
            ViewBag.FloorList = _floorRepository.GetAllForDropDown();

            //List<Cat_Emp_Type> EmpTypes = new List<Cat_Emp_Type>();
            //EmpTypes = db.Cat_Emp_Type.Where(x => !x.IsDelete).ToList();
            ViewBag.EmpType = _empTypeRepository.GetAllForDropDown();

            ViewBag.UnitId = _cat_UnitRepository.GetAllForDropDown();// db.Cat_Unit.Where(a => a.ComId == comid && !a.IsDelete).ToList();
            ViewBag.LineId = _lineRepository.GetAllForDropDown();// db.Cat_Line.Where(a => a.ComId == comid && !a.IsDelete).ToList();


            ViewBag.ShiftList = _shiftRepository.GetAllForDropDown();// db.Cat_Shift.Where(a => a.ComId == comid && !a.IsDelete).ToList();

            var date = DateTime.Now.Date;
            var firstDayOfMonth = new DateTime(date.Year, date.Month, 1);
            var endDate = firstDayOfMonth.AddMonths(1).AddDays(-1);

            ViewBag.DateFrom = firstDayOfMonth;
            ViewBag.DateTo = endDate;

            var jobcardvm = new JobCardVM();

            return View(jobcardvm);
        }

        [HttpPost]
        public ActionResult JobCard(JobCardVM jobCard)
        {

            //if (HttpContext.Session.GetString("userid") == null)
            //{
            //    return RedirectToRoute("GTR");
            //}


            //string comid = _httpContext.HttpContext.Session.GetString("comid");

            var ComId = HttpContext.Session.GetInt32("ComId");
            var UserId = HttpContext.Session.GetInt32("UserId");

            ReportItem item = new ReportItem();
            var callBackUrl = "";
            var ReportPath = "";
            var SqlCmd = "";
            var ConstrName = "";
            var ReportType = "";
            JobCardGrid aJobCardGrid = jobCard.JobCardGrid;
            try
            {
                ReportPath = "/ReportViewer/HR/rptJobCard.rdlc";
                //SqlCmd = "Exec rptJobCard '" + comid + "', '" + jobCard.DtFrom + "', '" + jobCard.DtTo + "'," + jobCard.SectId + ", " + jobCard.EmpId + "";
                //ConstrName = "ApplicationServices";
                //ReportType = aIncrementReport.ReportFormat;
                SqlCmd = "Exec rptJobCard '" + ComId + "', '" + jobCard.FromDate + "', '" + jobCard.ToDate + "','" + aJobCardGrid.EmpId + "'," +
                             "" + aJobCardGrid.ShiftId + "," + aJobCardGrid.DesigId + "," + aJobCardGrid.DeptId + ", " + aJobCardGrid.SectId + "," +
                             aJobCardGrid.SubSectionId + "," + aJobCardGrid.EmpTypeId + "," + aJobCardGrid.LineId + "," + aJobCardGrid.UnitId + ","
                             + aJobCardGrid.FloorId + "";

                ConstrName = "ApplicationServices";
                ReportType = aJobCardGrid.ReportFormat;

                HttpContext.Session.SetString("ReportPath", ReportPath.ToString());
                HttpContext.Session.SetString("ReportQuery", SqlCmd);
                string filename = "JobCard".ToString();
                HttpContext.Session.SetString("PrintFileName", filename.Replace(".", "").Replace(" ", "").Replace(",", "").Replace("\"", ""));
                callBackUrl = Url.Action("Index", "ReportViewer", new { reporttype = ReportType });

                return Redirect(callBackUrl);
            }
            catch (Exception ex)
            {
                //_logger.LogError(ex.Message);
                throw ex;
            }



        }

        #endregion


        #region salary sheet print


        [AllowAnonymous]
        [HttpPost, ActionName("AllHRReport")]

        public JsonResult AllHRReport(string rptFormat, string action, string DepartmentId, string SalaryMonth, string EmployeeTypeId, string SalaryTypeId, string WeekSegmentId)
        {
            try
            {
                var ComId = HttpContext.Session.GetInt32("ComId");
                var FromDate = DateTime.Now.Date.ToString("dd-MMM-yy");
                var ToDate = DateTime.Now.Date.ToString("dd-MMM-yy");

                var reportname = "";
                var filename = "";
                string redirectUrl = "";
                if (action == "PrintSalarySheet")
                {
                    reportname = "rptSalarySheet_Fixed";
                    filename = "rptSalarySheet_Fixed_" + DateTime.Now.Date;
                    HttpContext.Session.SetString("ReportQuery", "Exec HR_rptSalarySheet '" + ComId + "','','" + DepartmentId + "' ,'" + SalaryTypeId + "' ,'" + EmployeeTypeId + "' , '" + WeekSegmentId + "', '" + SalaryMonth + "' "); //'" + FromDate + "','" + ToDate + "'
                    HttpContext.Session.SetString("ReportPath", "~/ReportViewer/HR/" + reportname + ".rdlc");
                }
                //else if (action == "StoreSummaryDateWise")
                //{


                //    redirectUrl = Url.Action("StoreSummaryDateWise", "Sales", new { WarehouseId = WarehouseId, dtFrom = FromDate, dtTo = ToDate });
                //    return Json(new { Url = redirectUrl });

                //}



                HttpContext.Session.SetString("PrintFileName", filename.Replace(".", "").Replace(" ", "").Replace(",", "").Replace("\"", ""));


                string DataSourceName = "DataSet1";

                //HttpContext.Session.SetObject("Acc_rptList", postData);

                //Common.Classes.clsMain.intHasSubReport = 0;
                clsReport.strReportPathMain = HttpContext.Session.GetString("ReportPath");// Session["ReportPath"].ToString();
                clsReport.strQueryMain = HttpContext.Session.GetString("ReportQuery");
                clsReport.strDSNMain = DataSourceName;

                //var ConstrName = "ApplicationServices";
                //string callBackUrl = this.Url.Action("Index", "ReportViewer", new { reporttype = rptFormat }); //Repository.GenerateReport(clsReport.strReportPathMain, clsReport.strQueryMain, ConstrName, rptFormat);

                string callBackUrl = this.Url.Action("Index", "ReportViewer", new { reporttype = rptFormat });
                redirectUrl = callBackUrl;



                return Json(new { Url = redirectUrl });

            }

            catch (Exception ex)
            {
                // If Sucess== 0 then Unable to perform Save/Update Operation and send Exception to View as JSON
                return Json(new { Success = 0, ex = ex.InnerException.InnerException.Message.ToString() });
            }

            return Json(new { Success = 0, ex = new Exception("Unable to Open").Message.ToString() });
            //return RedirectToAction("Index");

        }



        #endregion


    }
}