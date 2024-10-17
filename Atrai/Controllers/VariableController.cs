using Atrai.Core.Common;
using Atrai.Data.Interfaces;
using Atrai.Data.Repository;
using Atrai.Model.Core.Entity;
using Atrai.Model.Core.ViewModel;
using Atrai.Services;
//using DocumentFormat.OpenXml.Wordprocessing;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.CodeAnalysis;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using System;
//using System.Diagnostics.Metrics;
using System.Linq;
using System.Linq.Dynamic.Core;
using static Atrai.Controllers.AccountsController;
using static Atrai.Controllers.AdminController;

namespace Atrai.Controllers
{
    //[Authorize]
    [OverridableAuthorize]
    public class VariableController : Controller
    {

        private readonly ICommercialRepository commercialRepository;
        private readonly ILCTypeRepository _LCTypeRepository;
        private readonly IPostOfLoadingRepository portOfLoadingRepository;
        private readonly IPostOfDischargeRepository portOfDischargeRepository;
        private readonly IShipModeRepository shipModeRepository;
        private readonly IIncoTermRepository incoTermRepository;
        private readonly IDayListTermRepository dayListTermRepository;
        private readonly ITradeTermRepository dayTermDecTermRepository;
        private readonly IDestinationRepository destinationRepository;
        private readonly IItemGroupRepository itemGroupRepository;
        private readonly IItemDescriptionRepository itemDescriptionRepository;
        private readonly IBuyerGroupRepository buyerGroupRepository;
        private readonly INotifyPartyRepository notifyPartyRepository;
        private readonly IDynamicReportRepository dynamicReportRepository;
        private readonly ILienBankRepository lienBankRepository;
        private readonly IPINatureRepository piNatureRepository;
        private readonly ISupplierBankAccountRepository supplierBankAccountRepository;
        private readonly IBankAccountNoRepository bankAccountNoRepository;
        private readonly IBoxCategoryRepository BoxCategoryRepository;
        private readonly ICOM_ProformaInvoiceRepository proformaInvoiceRepository;
        private readonly ICountryRepository _countryRepository;
        private readonly ICustomerRepository customerRepository;
        private readonly ISupplierRepository supplierRepository;
        private readonly IEmployeeRepository employeeRepository;
        private readonly IConcernBankRepository concernBankRepository;
        private readonly IImportCIContainerRepository importCIContainerRepository;
        private readonly IPITypeRepository pITypeRepository;
        private readonly IGroupLCMainRepository groupLCMainRepository;
        private readonly IGroupLCSubRepository groupLCSubRepository;
        private readonly IBBLCMainRepository _bBLCMainRepository;
        private readonly IImportCIMasterRepository importCIMasterRepository;
        private readonly IImportCIDetailsRepository importCIDetailsRepository;
        private readonly IBBLCDetailsRepository _bBLCDetailsRepository;
        private readonly ITransactionApprovalStatusRepository transactionApprovalStatusRepository;
        private readonly IUnitRepository unitRepository;
        private readonly IPaymentTermsRepository paymentTermsRepository;
        private readonly IDayListRepository dayListRepository;
        private readonly IMasterLCRepository _masterLCRepository;
        private readonly IMasterLCDetailsRepository _masterLCDetailsRepository;
        private readonly ICOM_CommercialInvoiceRepository _CommercialInvoiceRepository;
        private readonly ICOM_CommercialInvoice_SubRepository _CommercialInvoice_SubRepository;
        private readonly ICOM_MachinaryLC_MasterRepository _MachinaryLC_MasterRepository;
        private readonly ICOM_MachinaryLC_DetailsRepository _MachinaryLC_DetailsRepository;
        private readonly IDocumentStatusRepository _DocumentStatusRepository;
        private readonly ICommercialLCTypeRepository _CommercialLCTypeRepository;
        private readonly IDocumentAcceptance_MasterRepository _DocumentAcceptance_MasterRepository;
        private readonly IDocumentAcceptance_DetailsRepository _DocumentAcceptance_DetailsRepository;
        private readonly ICOM_ProformaInvoice_SubInvoiceRepository _ProformaInvoiceSubInvoiceRepository;
        private readonly IWorkOrderMasterRepository _WorkOrderMasterRepository;
        private readonly ICOM_MachineryLCDetailsRepository _MachineryLCDetailsRepository;
        private readonly ICOM_MachineryLCMasterRepository _MachineryLCMasterRepository;
        private readonly IApprovedByRepository _ApprovedByRepository;
        private readonly IWorkorderStatusRepository _WorkorderStatusRepository;
        private readonly ITruckInfoRepository _TruckInfoRepository;
        private readonly IBankAccountNoLienBankRepository _BankAccountNoLienBankRepository;
        private readonly IExportInvoiceMasterRepository _exportInvoiceMasterRepository;
        private readonly IContainerRepository _containerRepository;
        private readonly IDocTypeRepository docTypeRepository;

        public VariableController(ICommercialRepository _commercialRepository, IPostOfLoadingRepository portOfLoadingRepository, ICountryRepository countryRepository,
            IPostOfDischargeRepository portOfDischargeRepository, IDestinationRepository destinationRepository, IItemGroupRepository itemGroupRepository, IImportCIMasterRepository importCIMasterRepository, ITransactionApprovalStatusRepository transactionApprovalStatusRepository,
            IItemDescriptionRepository itemDescriptionRepository, IBuyerGroupRepository buyerGroupRepository, ICustomerRepository customerRepository,
            INotifyPartyRepository notifyPartyRepository, IDynamicReportRepository dynamicReportRepository, ILienBankRepository lienBankRepository,
            IBankAccountNoRepository bankAccountNoRepository, ISupplierRepository supplierRepository, IEmployeeRepository employeeRepository, IExportInvoiceMasterRepository exportInvoiceMasterRepository, IDocTypeRepository docTypeRepository,
            IPaymentTermsRepository paymentTermsRepository, IConcernBankRepository concernBankRepository, ICOM_ProformaInvoiceRepository proformaInvoiceRepository,
            IPITypeRepository pITypeRepository, IGroupLCMainRepository groupLCMainRepository, IUnitRepository unitRepository, IDayListRepository dayListRepository,
            ISupplierBankAccountRepository supplierBankAccountRepository, IShipModeRepository shipModeRepository, IIncoTermRepository incoTermRepository,
            ITradeTermRepository dayTermDecTermRepository, IDayListTermRepository dayListTermRepository, IBBLCMainRepository _bBLCMainRepository, IContainerRepository containerRepository,
            IBBLCDetailsRepository _bBLCDetailsRepository, IMasterLCRepository masterLCRepository, IMasterLCDetailsRepository masterLCDetailsRepository,
            IGroupLCSubRepository groupLCSubRepository, IDocumentStatusRepository documentStatusRepository, ICommercialLCTypeRepository commercialLCTypeRepository,
            ICOM_MachinaryLC_DetailsRepository machinaryLC_DetailsRepository, ICOM_MachinaryLC_MasterRepository machinaryLC_MasterRepository, IImportCIDetailsRepository importCIDetailsRepository,
            ICOM_CommercialInvoice_SubRepository commercialInvoice_SubRepository, ICOM_CommercialInvoiceRepository commercialInvoiceRepository,
            ILCTypeRepository lCTypeRepository, IDocumentAcceptance_MasterRepository documentAcceptance_MasterRepository, IDocumentAcceptance_DetailsRepository documentAcceptance_DetailsRepository,
            ICOM_ProformaInvoice_SubInvoiceRepository proformaInvoiceSubInvoiceRepository, IWorkOrderMasterRepository workOrderMasterRepository,
            ICOM_MachineryLCDetailsRepository machineryLCDetailsRepository, ICOM_MachineryLCMasterRepository machineryLCMasterRepository, IImportCIContainerRepository importCIContainerRepository,
            IApprovedByRepository approvedByRepository, IWorkorderStatusRepository workorderStatusRepository, ITruckInfoRepository truckInfoRepository,
            IBankAccountNoLienBankRepository bankAccountNoLienBankRepository, IPINatureRepository piNatureRepository, IBoxCategoryRepository boxCategoryRepository)
        {
            commercialRepository = _commercialRepository;
            this.portOfLoadingRepository = portOfLoadingRepository;
            _countryRepository = countryRepository;
            this.portOfDischargeRepository = portOfDischargeRepository;
            this.destinationRepository = destinationRepository;
            this.itemGroupRepository = itemGroupRepository;
            this.itemDescriptionRepository = itemDescriptionRepository;
            this.transactionApprovalStatusRepository = transactionApprovalStatusRepository;
            this.buyerGroupRepository = buyerGroupRepository;
            this.customerRepository = customerRepository;
            this.notifyPartyRepository = notifyPartyRepository;
            this.dynamicReportRepository = dynamicReportRepository;
            this.lienBankRepository = lienBankRepository;
            this.piNatureRepository = piNatureRepository;
            this.docTypeRepository = docTypeRepository;
            this.bankAccountNoRepository = bankAccountNoRepository;
            this.supplierRepository = supplierRepository;
            this.employeeRepository = employeeRepository;
            this.importCIMasterRepository = importCIMasterRepository;
            this.paymentTermsRepository = paymentTermsRepository;
            this.concernBankRepository = concernBankRepository;
            this.importCIContainerRepository = importCIContainerRepository;
            this.proformaInvoiceRepository = proformaInvoiceRepository;
            this.pITypeRepository = pITypeRepository;
            this.groupLCMainRepository = groupLCMainRepository;
            this.unitRepository = unitRepository;
            this.importCIDetailsRepository = importCIDetailsRepository;
            this.dayListRepository = dayListRepository;
            _exportInvoiceMasterRepository = exportInvoiceMasterRepository;
            _containerRepository = containerRepository;
            this.supplierBankAccountRepository = supplierBankAccountRepository;
            this.shipModeRepository = shipModeRepository;
            this.incoTermRepository = incoTermRepository;
            this.dayTermDecTermRepository = dayTermDecTermRepository;
            this.dayListTermRepository = dayListTermRepository;
            this._bBLCMainRepository = _bBLCMainRepository;
            this._bBLCDetailsRepository = _bBLCDetailsRepository;
            _masterLCRepository = masterLCRepository;
            _masterLCDetailsRepository = masterLCDetailsRepository;
            this.groupLCSubRepository = groupLCSubRepository;
            _DocumentStatusRepository = documentStatusRepository;
            _CommercialLCTypeRepository = commercialLCTypeRepository;
            _MachinaryLC_DetailsRepository = machinaryLC_DetailsRepository;
            _MachinaryLC_MasterRepository = machinaryLC_MasterRepository;
            _CommercialInvoice_SubRepository = commercialInvoice_SubRepository;
            _CommercialInvoiceRepository = commercialInvoiceRepository;
            _LCTypeRepository = lCTypeRepository;
            _DocumentAcceptance_MasterRepository = documentAcceptance_MasterRepository;
            _DocumentAcceptance_DetailsRepository = documentAcceptance_DetailsRepository;
            _ProformaInvoiceSubInvoiceRepository = proformaInvoiceSubInvoiceRepository;
            _WorkOrderMasterRepository = workOrderMasterRepository;
            _MachineryLCDetailsRepository = machineryLCDetailsRepository;
            _MachineryLCMasterRepository = machineryLCMasterRepository;
            _ApprovedByRepository = approvedByRepository;
            _WorkorderStatusRepository = workorderStatusRepository;
            _TruckInfoRepository = truckInfoRepository;
            _BankAccountNoLienBankRepository = bankAccountNoLienBankRepository;
            BoxCategoryRepository = boxCategoryRepository;
        }


        // GET: VariableController
        public ActionResult Index(string Type)
        {
            ViewBag.ListType = Type ?? "portofLoading";
            return View();
        }
        public class PagingInfo
        {
            public int PageNo { get; set; }

            public int PageSize { get; set; }

            public int PageCount { get; set; }

            public long TotalRecordCount { get; set; }

        }

        #region pol  region
        [HttpPost]
        //[AllowAnonymous]
        [OverridableAuthorize]
        public IActionResult AddUpdatePol([FromBody] PortOfLoading model)
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

                        portOfLoadingRepository.Update(model, model.Id);
                        return Json(new { success = "1", error = false, message = "Data updated successfully", Id = model.Id });
                    }
                    else
                    {
                        portOfLoadingRepository.Insert(model);
                        return Json(new { success = "1", error = false, message = "Data saved successfully", Id = model.Id });
                    }
                }
                else
                {

                    return Json(new { error = true, message = "failed to save Data" });
                }



            }
            catch (Exception ex)
            {

                return Json(new { error = true, message = ex.Message });
            }
        }

        public IActionResult GetPOLs()
        {
            var comid = HttpContext.Session.GetInt32("ComId");
            var colors = portOfLoadingRepository.All().Where(x => x.ComId == comid);
            return Json(colors);
        }
        [HttpGet]
        [AllowAnonymous]

        public JsonResult InactivePOLs(int id)
        {
            try
            {
                var model = portOfLoadingRepository.Find(id);

                if (model != null)
                {
                    if (model.IsDelete == false)
                    {
                        model.IsDelete = true;
                        portOfLoadingRepository.Update(model, id);
                        return Json(new { success = "1", msg = "Deleted Successfully" });

                    }
                    else if (model.IsDelete == true)
                    {
                        model.IsDelete = false;
                        portOfLoadingRepository.Update(model, id);
                        return Json(new { success = "1", msg = "Restored Successfully." });
                    }

                }
                return Json(new { success = "0", msg = "No items found to Inactivate." });

            }
            catch (Exception ex)
            {
                return Json(new { success = "0", msg = "No items found to delete." });
                throw ex;
            }
        }

        [HttpGet]
        //[AllowAnonymous]
        [OverridableAuthorize]
        public JsonResult GetPOLEdit(int id)
        {
            try
            {
                var colorsquery = portOfLoadingRepository.All().Where(x => x.Id == id);

                var color = colorsquery
                  .Select(p => new
                  {
                      p.Id,
                      p.ComId,
                      p.PortOfLoadingName,
                      p.PortCode,
                      p.CountryId,
                      p.Countrys.CountryName,
                  }).FirstOrDefault();


                return Json(new { Success = 1, data = colorsquery, ex = "Data Load Successfully" });
            }
            catch (Exception e)
            {
                return Json(e.ToString());
            }

        }
        [HttpGet]
        //[AllowAnonymous]
        [OverridableAuthorize]
        public JsonResult DeletePOLs(int id)
        {
            try
            {


                var model = portOfLoadingRepository.Find(id);

                if (model != null)
                {

                    portOfLoadingRepository.Delete(model);

                    return Json(new { success = "1", msg = "Deleted Successfully" });
                }
                return Json(new { success = "0", msg = "No items found to delete." });

            }
            catch (Exception ex)
            {
                return Json(new { success = "0", msg = "No items found to delete." }); //msg = ex.ToString()
                throw ex;
            }
        }
        [AllowAnonymous]
        public JsonResult GetPOLList(int page = 1, decimal size = 5, string searchquery = "")
        {
            try
            {
                var CurrentUserId = HttpContext.Session.GetInt32("UserId");
                var ComId = HttpContext.Session.GetInt32("ComId");
                var purchaselist = portOfLoadingRepository.All();

                if (searchquery?.Length > 1)
                {
                    purchaselist = purchaselist.Where(
                        x => x.PortOfLoadingName.ToLower().Contains(searchquery.ToLower()) ||
                        x.PortCode.ToLower().Contains(searchquery.ToLower()) ||
                        x.Countrys.CountryName.ToLower().Contains(searchquery.ToLower())
                    );
                }

                decimal TotalRecordCount = purchaselist.Count();
                var PageCountabc = decimal.Parse((TotalRecordCount / size).ToString());
                var PageCount = Math.Ceiling(PageCountabc);



                decimal skip = (page - 1) * size;
                var query = from e in purchaselist //.Include(x=>x.Countrys)
                            select new
                            {
                                Id = e.Id,
                                e.ComId,
                                e.PortOfLoadingName,
                                e.PortCode,
                                e.CountryId,
                                polcountry = e.Countrys.CountryName,
                            };
                var abcd = query.OrderByDescending(x => x.Id).Skip(int.Parse(skip.ToString())).Take(int.Parse(size.ToString())).ToList();// Take(50);
                var pageinfo = new PagingInfo();
                pageinfo.PageCount = int.Parse(PageCount.ToString());
                pageinfo.PageNo = page;
                pageinfo.PageSize = int.Parse(size.ToString());
                pageinfo.TotalRecordCount = int.Parse(TotalRecordCount.ToString());
                return Json(new { Success = 1, error = false, data = abcd, page = page, size = size, last_page = pageinfo.PageCount, total = pageinfo.TotalRecordCount });
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        [AllowAnonymous]
        public JsonResult GetSizeSearchList(int? CategoryId, bool IncludingInative, int pageNo = 1, decimal pageSize = 10, string searchquery = "", string dropdownSearch = "")
        {
            try
            {
                if (dropdownSearch == null)
                {
                    dropdownSearch = "";
                }
                var productlist = portOfLoadingRepository.All().Where(x => x.IsDelete == false);
                if (searchquery?.Length > 1)
                {
                    var searchitem = JsonConvert.DeserializeObject<SizeListFilterData>(searchquery);

                    if (searchitem.pageIndex != null)
                    {
                        pageNo = searchitem.pageIndex.GetValueOrDefault(); // || x.Code.ToLower().Contains(searchitem.Name.ToLower())
                        pageSize = searchitem.pageSize.GetValueOrDefault();


                    }
                    if (searchitem.SizeName != null)
                    {
                        productlist = productlist.Where(x => x.PortOfLoadingName.ToLower().Contains(searchitem.SizeName.ToLower())); // || x.Code.ToLower().Contains(searchitem.Name.ToLower())

                    }
                    if (searchitem.SizeCode != null)
                    {
                        productlist = productlist.Where(x => x.PortCode.ToLower().Contains(searchitem.SizeCode.ToLower())); // || x.Code.ToLower().Contains(searchitem.Name.ToLower())

                    }
                }
                if ((dropdownSearch.Length > 1) || (dropdownSearch == ""))
                {
                    productlist = productlist.Where(x => x.PortOfLoadingName.ToLower().Contains(dropdownSearch.ToLower()) || x.PortCode.ToLower().Contains(dropdownSearch.ToLower()));
                }
                decimal TotalRecordCount = productlist.Count();
                var PageCountabc = decimal.Parse((TotalRecordCount / pageSize).ToString());
                var PageCount = Math.Ceiling(PageCountabc);
                decimal skip = (pageNo - 1) * pageSize;
                int total = productlist.Count();
                var query = from e in productlist
                            select new
                            {
                                id = e.Id,
                                text = e.PortOfLoadingName,
                                e.PortCode,
                                e.CountryId,
                                e.Countrys.CountryName,
                            };
                var abcd = query.OrderByDescending(x => x.id).Skip(int.Parse(skip.ToString())).Take(int.Parse(pageSize.ToString())).ToList();// Take(50);
                var pageinfo = new PagingInfo();
                pageinfo.PageCount = int.Parse(PageCount.ToString());
                pageinfo.PageNo = pageNo;
                pageinfo.PageSize = int.Parse(pageSize.ToString());
                pageinfo.TotalRecordCount = int.Parse(TotalRecordCount.ToString());

                //return  abcd;
                return Json(new { Success = 1, error = false, ProductList = abcd, PageInfo = pageinfo });
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        [HttpGet]
        [AllowAnonymous]
        public IActionResult GetCountryDrodpwon()
        {
            var ComId = HttpContext.Session.GetInt32("ComId");

            var countries = _countryRepository.All();
            return Json(countries);
        }
        #endregion


        #region pod  region
        [HttpPost]
        // [AllowAnonymous]
        //[Authorize]
        [OverridableAuthorize]

        public IActionResult AddUpdatePod([FromBody] PortOfDischarge model)
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

                        portOfDischargeRepository.Update(model, model.Id);
                        return Json(new { success = "1", error = false, message = "Data updated successfully", Id = model.Id });
                    }
                    else
                    {
                        portOfDischargeRepository.Insert(model);
                        return Json(new { success = "1", error = false, message = "Data saved successfully", Id = model.Id });
                    }
                }
                else
                {

                    return Json(new { error = true, message = "failed to save Data" });
                }



            }
            catch (Exception ex)
            {

                return Json(new { error = true, message = ex.Message });
            }
        }

        public IActionResult GetPODs()
        {
            var comid = HttpContext.Session.GetInt32("ComId");
            var colors = portOfDischargeRepository.All().Where(x => x.ComId == comid);
            return Json(colors);
        }

        [HttpGet]
        //[AllowAnonymous]
        [OverridableAuthorize]
        public JsonResult GetPODEdit(int id)
        {
            try
            {
                var colorsquery = portOfDischargeRepository.All().Where(x => x.Id == id);

                var color = colorsquery
                  .Select(p => new
                  {
                      p.Id,
                      p.ComId,
                      p.PortOfDischargeName,
                      podCode = p.PortCode,
                      p.CountryId,
                      p.Countrys.CountryName,
                  }).FirstOrDefault();


                return Json(new { Success = 1, data = colorsquery, ex = "Data Load Successfully" });
            }
            catch (Exception e)
            {
                return Json(e.ToString());
            }

        }
        [HttpGet]
        // [AllowAnonymous] 
        [OverridableAuthorize]
        public JsonResult DeletePODs(int id)
        {
            try
            {


                var model = portOfDischargeRepository.Find(id);

                if (model != null)
                {

                    portOfDischargeRepository.Delete(model);

                    return Json(new { success = "1", msg = "Deleted Successfully" });
                }
                return Json(new { success = "0", msg = "No items found to delete." });

            }
            catch (Exception ex)
            {
                return Json(new { success = "0", msg = "No items found to delete." }); //msg = ex.ToString()
                throw ex;
            }
        }
        [AllowAnonymous]
        public JsonResult GetPODList(int page = 1, decimal size = 5, string searchquery = "")
        {
            try
            {
                var CurrentUserId = HttpContext.Session.GetInt32("UserId");
                var ComId = HttpContext.Session.GetInt32("ComId");
                var purchaselist = portOfDischargeRepository.All();

                if (searchquery?.Length > 1)
                {
                    purchaselist = purchaselist.Where(x =>
                        x.PortOfDischargeName.ToLower().Contains(searchquery.ToLower()) ||
                        x.PortCode.ToLower().Contains(searchquery.ToLower()) ||
                        x.Countrys.CountryName.ToLower().Contains(searchquery.ToLower())
                    );

                }
                decimal TotalRecordCount = purchaselist.Count();
                var PageCountabc = decimal.Parse((TotalRecordCount / size).ToString());
                var PageCount = Math.Ceiling(PageCountabc);



                decimal skip = (page - 1) * size;
                var query = from e in purchaselist.Include(x => x.Countrys)
                            select new
                            {
                                Id = e.Id,
                                e.ComId,
                                e.PortOfDischargeName,
                                podCode = e.PortCode,
                                e.CountryId,
                                podcountry = e.Countrys.CountryName,
                            };
                var abcd = query.OrderByDescending(x => x.Id).Skip(int.Parse(skip.ToString())).Take(int.Parse(size.ToString())).ToList();// Take(50);
                var pageinfo = new PagingInfo();
                pageinfo.PageCount = int.Parse(PageCount.ToString());
                pageinfo.PageNo = page;
                pageinfo.PageSize = int.Parse(size.ToString());
                pageinfo.TotalRecordCount = int.Parse(TotalRecordCount.ToString());
                return Json(new { Success = 1, error = false, data = abcd, page = page, size = size, last_page = pageinfo.PageCount, total = pageinfo.TotalRecordCount });
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion


        #region fd  region
        [HttpPost]
        //[AllowAnonymous]
        [OverridableAuthorize]
        public IActionResult AddUpdateFD([FromBody] Destination model)
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

                        destinationRepository.Update(model, model.Id);
                        return Json(new { success = "1", error = false, message = "Data updated successfully", Id = model.Id });
                    }
                    else
                    {
                        destinationRepository.Insert(model);
                        return Json(new { success = "1", error = false, message = "Data saved successfully", Id = model.Id });
                    }
                }
                else
                {

                    return Json(new { error = true, message = "failed to save Data" });
                }



            }
            catch (Exception ex)
            {

                return Json(new { error = true, message = ex.Message });
            }
        }

        public IActionResult GetFDs()
        {
            var comid = HttpContext.Session.GetInt32("ComId");
            var colors = destinationRepository.All().Where(x => x.ComId == comid);
            return Json(colors);
        }

        [HttpGet]
        //[AllowAnonymous]
        [OverridableAuthorize]
        public JsonResult GetFDEdit(int id)
        {
            try
            {
                var colorsquery = destinationRepository.All().Where(x => x.Id == id);

                var color = colorsquery
                  .Select(p => new
                  {
                      p.Id,
                      p.ComId,
                      p.DestinationNameSearch,
                      p.DestinationName,
                      p.DestinationCode,
                      p.CountryId,
                      p.Countrys.CountryName,
                  }).FirstOrDefault();


                return Json(new { Success = 1, data = colorsquery, ex = "Data Load Successfully" });
            }
            catch (Exception e)
            {
                return Json(e.ToString());
            }

        }
        [HttpGet]
        //[AllowAnonymous]
        [OverridableAuthorize]
        public JsonResult DeleteFDs(int id)
        {
            try
            {


                var model = destinationRepository.Find(id);

                if (model != null)
                {

                    destinationRepository.Delete(model);

                    return Json(new { success = "1", msg = "Deleted Successfully" });
                }
                return Json(new { success = "0", msg = "No items found to delete." });

            }
            catch (Exception ex)
            {
                return Json(new { success = "0", msg = "No items found to delete." }); //msg = ex.ToString()
                throw ex;
            }
        }
        [AllowAnonymous]
        public JsonResult GetFDList(int page = 1, decimal size = 5, string searchquery = "")
        {
            try
            {
                var CurrentUserId = HttpContext.Session.GetInt32("UserId");
                var ComId = HttpContext.Session.GetInt32("ComId");
                var purchaselist = destinationRepository.All();

                if (searchquery?.Length > 1)
                {
                    purchaselist = purchaselist.Where(x =>
                        x.DestinationNameSearch.ToLower().Contains(searchquery.ToLower()) ||
                        x.DestinationCode.ToLower().Contains(searchquery.ToLower()) ||
                        x.DestinationName.ToLower().Contains(searchquery.ToLower()) ||
                        x.Countrys.CountryName.ToLower().Contains(searchquery.ToLower())
                    );

                }
                decimal TotalRecordCount = purchaselist.Count();
                var PageCountabc = decimal.Parse((TotalRecordCount / size).ToString());
                var PageCount = Math.Ceiling(PageCountabc);



                decimal skip = (page - 1) * size;
                var query = from e in purchaselist.Include(x => x.Countrys)
                            select new
                            {
                                Id = e.Id,
                                e.ComId,
                                e.DestinationNameSearch,
                                e.DestinationName,
                                e.DestinationCode,
                                e.CountryId,
                                fdcountry = e.Countrys.CountryName,
                            };
                var abcd = query.OrderByDescending(x => x.Id).Skip(int.Parse(skip.ToString())).Take(int.Parse(size.ToString())).ToList();// Take(50);
                var pageinfo = new PagingInfo();
                pageinfo.PageCount = int.Parse(PageCount.ToString());
                pageinfo.PageNo = page;
                pageinfo.PageSize = int.Parse(size.ToString());
                pageinfo.TotalRecordCount = int.Parse(TotalRecordCount.ToString());
                return Json(new { Success = 1, error = false, data = abcd, page = page, size = size, last_page = pageinfo.PageCount, total = pageinfo.TotalRecordCount });
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion

        #region ig  region
        [HttpPost]
        //[AllowAnonymous]
        [OverridableAuthorize]
        public IActionResult AddUpdateIG([FromBody] ItemGroupModel model)
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

                        itemGroupRepository.Update(model, model.Id);
                        return Json(new { success = "1", error = false, message = "Data updated successfully", Id = model.Id });
                    }
                    else
                    {
                        itemGroupRepository.Insert(model);
                        return Json(new { success = "1", error = false, message = "Data saved successfully", Id = model.Id });
                    }
                }
                else
                {

                    return Json(new { error = true, message = "failed to save Data" });
                }



            }
            catch (Exception ex)
            {

                return Json(new { error = true, message = ex.Message });
            }
        }

        [HttpGet]
        //[AllowAnonymous]
        [OverridableAuthorize]
        public JsonResult GetIGEdit(int id)
        {
            try
            {
                var colorsquery = itemGroupRepository.All().Where(x => x.Id == id);

                var color = colorsquery
                  .Select(p => new
                  {
                      p.Id,
                      p.ComId,
                      p.ItemGroupCode,
                      p.ItemGroupHSCode,
                      p.ItemGroupShortName,
                      p.ItemGroupName,
                      p.ItemMargin,
                  }).FirstOrDefault();


                return Json(new { Success = 1, data = colorsquery, ex = "Data Load Successfully" });
            }
            catch (Exception e)
            {
                return Json(e.ToString());
            }

        }
        [HttpGet]
        //[AllowAnonymous]
        [OverridableAuthorize]
        public JsonResult DeleteIGs(int id)
        {
            try
            {


                var model = itemGroupRepository.Find(id);

                if (model != null)
                {

                    itemGroupRepository.Delete(model);

                    return Json(new { success = "1", msg = "Deleted Successfully" });
                }
                return Json(new { success = "0", msg = "No items found to delete." });

            }
            catch (Exception ex)
            {
                return Json(new { success = "0", msg = "No items found to delete." }); //msg = ex.ToString()
                throw ex;
            }
        }
        [AllowAnonymous]
        public JsonResult GetIGList(int page = 1, decimal size = 5, string searchquery = "")
        {
            try
            {
                var CurrentUserId = HttpContext.Session.GetInt32("UserId");
                var ComId = HttpContext.Session.GetInt32("ComId");
                var purchaselist = itemGroupRepository.All();

                if (searchquery?.Length > 1)
                {
                    purchaselist = purchaselist.Where(x =>
                        x.ItemGroupName.ToLower().Contains(searchquery.ToLower()) ||
                        x.ItemGroupCode.ToLower().Contains(searchquery.ToLower()) ||
                        x.ItemGroupHSCode.ToLower().Contains(searchquery.ToLower()) ||
                        x.ItemMargin.ToString().ToLower().Contains(searchquery.ToLower()) ||
                        x.ItemGroupShortName.ToLower().Contains(searchquery.ToLower())
                    );

                }
                decimal TotalRecordCount = purchaselist.Count();
                var PageCountabc = decimal.Parse((TotalRecordCount / size).ToString());
                var PageCount = Math.Ceiling(PageCountabc);



                decimal skip = (page - 1) * size;
                var query = from p in purchaselist
                            select new
                            {
                                Id = p.Id,
                                p.ComId,
                                p.ItemGroupCode,
                                p.ItemGroupHSCode,
                                p.ItemGroupShortName,
                                p.ItemGroupName,
                                p.ItemMargin,
                            };
                var abcd = query.OrderByDescending(x => x.Id).Skip(int.Parse(skip.ToString())).Take(int.Parse(size.ToString())).ToList();// Take(50);
                var pageinfo = new PagingInfo();
                pageinfo.PageCount = int.Parse(PageCount.ToString());
                pageinfo.PageNo = page;
                pageinfo.PageSize = int.Parse(size.ToString());
                pageinfo.TotalRecordCount = int.Parse(TotalRecordCount.ToString());
                return Json(new { Success = 1, error = false, data = abcd, page = page, size = size, last_page = pageinfo.PageCount, total = pageinfo.TotalRecordCount });
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion







        #region ID  region
        [HttpPost]
        //[AllowAnonymous]
        [OverridableAuthorize]
        public IActionResult AddUpdateID([FromBody] ItemDescriptionModel model)
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

                        itemDescriptionRepository.Update(model, model.Id);
                        return Json(new { success = "1", error = false, message = "Data updated successfully", Id = model.Id });
                    }
                    else
                    {
                        itemDescriptionRepository.Insert(model);
                        return Json(new { success = "1", error = false, message = "Data saved successfully", Id = model.Id });
                    }
                }
                else
                {

                    return Json(new { error = true, message = "failed to save Data" });
                }



            }
            catch (Exception ex)
            {

                return Json(new { error = true, message = ex.Message });
            }
        }

        [HttpGet]
        //[AllowAnonymous]
        [OverridableAuthorize]
        public JsonResult GetIDEdit(int id)
        {
            try
            {
                var colorsquery = itemDescriptionRepository.All().Where(x => x.Id == id);

                var color = colorsquery
                  .Select(p => new
                  {
                      p.Id,
                      p.ComId,
                      p.ItemDescCode,
                      p.ItemDescHSCode,
                      p.ItemDescShortName,
                      p.ItemDescName,
                      p.ItemGroupId,
                      p.ItemGroups.ItemGroupName,
                  }).FirstOrDefault();


                return Json(new { Success = 1, data = colorsquery, ex = "Data Load Successfully" });
            }
            catch (Exception e)
            {
                return Json(e.ToString());
            }

        }
        [HttpGet]
        //[AllowAnonymous]
        [OverridableAuthorize]
        public JsonResult DeleteIDs(int id)
        {
            try
            {


                var model = itemDescriptionRepository.Find(id);

                if (model != null)
                {

                    itemDescriptionRepository.Delete(model);

                    return Json(new { success = "1", msg = "Deleted Successfully" });
                }
                return Json(new { success = "0", msg = "No items found to delete." });

            }
            catch (Exception ex)
            {
                return Json(new { success = "0", msg = "No items found to delete." }); //msg = ex.ToString()
                throw ex;
            }
        }
        [AllowAnonymous]
        public JsonResult GetITList(int page = 1, decimal size = 5, string searchquery = "")
        {
            try
            {
                var CurrentUserId = HttpContext.Session.GetInt32("UserId");
                var ComId = HttpContext.Session.GetInt32("ComId");
                var purchaselist = itemDescriptionRepository.All();

                if (searchquery?.Length > 1)
                {
                    purchaselist = purchaselist.Where(x =>
                        x.ItemDescName.ToLower().Contains(searchquery.ToLower()) ||
                        x.ItemDescCode.ToLower().Contains(searchquery.ToLower()) ||
                        x.ItemDescHSCode.ToLower().Contains(searchquery.ToLower()) ||
                        x.ItemDescShortName.ToLower().Contains(searchquery.ToLower()) ||
                        x.ItemGroups.ItemGroupName.ToLower().Contains(searchquery.ToLower())
                    );

                }
                decimal TotalRecordCount = purchaselist.Count();
                var PageCountabc = decimal.Parse((TotalRecordCount / size).ToString());
                var PageCount = Math.Ceiling(PageCountabc);



                decimal skip = (page - 1) * size;
                var query = from p in purchaselist.Include(x => x.ItemGroups)
                            select new
                            {
                                Id = p.Id,
                                p.ComId,
                                p.ItemDescCode,
                                p.ItemDescHSCode,
                                p.ItemDescShortName,
                                p.ItemDescName,
                                p.ItemGroupId,
                                igName = p.ItemGroups.ItemGroupName,
                            };
                var abcd = query.OrderByDescending(x => x.Id).Skip(int.Parse(skip.ToString())).Take(int.Parse(size.ToString())).ToList();// Take(50);
                var pageinfo = new PagingInfo();
                pageinfo.PageCount = int.Parse(PageCount.ToString());
                pageinfo.PageNo = page;
                pageinfo.PageSize = int.Parse(size.ToString());
                pageinfo.TotalRecordCount = int.Parse(TotalRecordCount.ToString());
                return Json(new { Success = 1, error = false, data = abcd, page = page, size = size, last_page = pageinfo.PageCount, total = pageinfo.TotalRecordCount });
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        [HttpGet]
        [AllowAnonymous]
        public IActionResult GetItemGroupDrodpwon()
        {
            var ComId = HttpContext.Session.GetInt32("ComId");

            var countries = itemGroupRepository.All();
            return Json(countries);
        }
        #endregion





        #region dr  region
        [HttpPost]
        //[AllowAnonymous]
        [OverridableAuthorize]
        public IActionResult AddUpdateDP([FromBody] DynamicReport model)
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

                        dynamicReportRepository.Update(model, model.Id);
                        return Json(new { success = "1", error = false, message = "Data updated successfully", Id = model.Id });
                    }
                    else
                    {
                        dynamicReportRepository.Insert(model);
                        return Json(new { success = "1", error = false, message = "Data saved successfully", Id = model.Id });
                    }
                }
                else
                {

                    return Json(new { error = true, message = "failed to save Data" });
                }



            }
            catch (Exception ex)
            {

                return Json(new { error = true, message = ex.Message });
            }
        }

        [HttpGet]
        //[AllowAnonymous]
        [OverridableAuthorize]
        public JsonResult GetDPEdit(int id)
        {
            try
            {
                var colorsquery = dynamicReportRepository.All().Where(x => x.Id == id);

                var color = colorsquery
                  .Select(p => new
                  {
                      p.Id,
                      // p.ComId,
                      p.DynamicReportName,
                      p.DynamicReportPackingListName,
                      p.DynamicReportPackingDetailsName,
                      p.DynamicReportCaption,
                      p.BuyerId,
                      p.BuyerInformations.Name,
                      p.ReportController,
                      p.DynamicReportActionName,
                      p.ReportDesignByPerson,
                      p.ReportLocation,
                      p.VerifiedByPerson,
                      p.CompletePercentage,
                      p.Remarks,
                      p.isVerified,
                  }).FirstOrDefault();


                return Json(new { Success = 1, data = colorsquery, ex = "Data Load Successfully" });
            }
            catch (Exception e)
            {
                return Json(e.ToString());
            }

        }
        [HttpGet]
        //[AllowAnonymous]
        [OverridableAuthorize]
        public JsonResult DeleteDPs(int id)
        {
            try
            {


                var model = dynamicReportRepository.Find(id);

                if (model != null)
                {

                    dynamicReportRepository.Delete(model);

                    return Json(new { success = "1", msg = "Deleted Successfully" });
                }
                return Json(new { success = "0", msg = "No items found to delete." });

            }
            catch (Exception ex)
            {
                return Json(new { success = "0", msg = "No items found to delete." }); //msg = ex.ToString()
                throw ex;
            }
        }
        [HttpGet]
        [AllowAnonymous]
        public JsonResult GetDPList(int page = 1, decimal size = 5, string searchquery = "")
        {
            try
            {
                var CurrentUserId = HttpContext.Session.GetInt32("UserId");
                var ComId = HttpContext.Session.GetInt32("ComId");
                var purchaselist = dynamicReportRepository.All();

                if (searchquery?.Length > 1)
                {
                    purchaselist = purchaselist.Where(x =>
                        x.DynamicReportName.ToLower().Contains(searchquery.ToLower()) ||
                        x.DynamicReportPackingListName.ToLower().Contains(searchquery.ToLower()) ||
                        x.DynamicReportPackingDetailsName.ToLower().Contains(searchquery.ToLower()) ||
                        x.DynamicReportCaption.ToLower().Contains(searchquery.ToLower()) ||
                        x.DynamicReportActionName.ToLower().Contains(searchquery.ToLower()) ||
                        x.ReportDesignByPerson.ToLower().Contains(searchquery.ToLower()) ||
                        x.ReportLocation.ToLower().Contains(searchquery.ToLower()) ||
                        x.ReportController.ToLower().Contains(searchquery.ToLower()) ||
                        x.VerifiedByPerson.ToLower().Contains(searchquery.ToLower()) ||
                        x.CompletePercentage.ToString().ToLower().Contains(searchquery.ToLower()) ||
                        x.Remarks.ToLower().Contains(searchquery.ToLower()) ||
                        x.BuyerInformations.DisplayName.ToLower().Contains(searchquery.ToLower())
                    );

                }
                decimal TotalRecordCount = purchaselist.Count();
                var PageCountabc = decimal.Parse((TotalRecordCount / size).ToString());
                var PageCount = Math.Ceiling(PageCountabc);



                decimal skip = (page - 1) * size;
                var query = from p in purchaselist.Include(x => x.BuyerInformations)
                            select new
                            {
                                Id = p.Id,
                                // p.ComId,
                                p.DynamicReportName,
                                p.DynamicReportPackingListName,
                                p.DynamicReportPackingDetailsName,
                                p.DynamicReportCaption,
                                p.BuyerId,
                                dpbuyer = p.BuyerInformations.Name,
                                p.ReportController,
                                p.DynamicReportActionName,
                                p.ReportDesignByPerson,
                                p.ReportLocation,
                                p.VerifiedByPerson,
                                p.CompletePercentage,
                                p.Remarks,
                                p.isVerified,
                            };
                var abcd = query.OrderByDescending(x => x.Id).Skip(int.Parse(skip.ToString())).Take(int.Parse(size.ToString())).ToList();// Take(50);
                var pageinfo = new PagingInfo();
                pageinfo.PageCount = int.Parse(PageCount.ToString());
                pageinfo.PageNo = page;
                pageinfo.PageSize = int.Parse(size.ToString());
                pageinfo.TotalRecordCount = int.Parse(TotalRecordCount.ToString());
                return Json(new { Success = 1, error = false, data = abcd, page = page, size = size, last_page = pageinfo.PageCount, total = pageinfo.TotalRecordCount });
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion




        #region np  region
        [HttpPost]
        //[AllowAnonymous]
        [OverridableAuthorize]
        public IActionResult AddUpdateNP([FromBody] NotifyParty model)
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

                        notifyPartyRepository.Update(model, model.Id);
                        return Json(new { success = "1", error = false, message = "Data updated successfully", Id = model.Id });
                    }
                    else
                    {
                        notifyPartyRepository.Insert(model);
                        return Json(new { success = "1", error = false, message = "Data saved successfully", Id = model.Id });
                    }
                }
                else
                {

                    return Json(new { error = true, message = "failed to save Data" });
                }



            }
            catch (Exception ex)
            {

                return Json(new { error = true, message = ex.Message });
            }
        }

        [HttpGet]
        //[AllowAnonymous]
        [OverridableAuthorize]
        public JsonResult GetNPEdit(int id)
        {
            try
            {
                var colorsquery = notifyPartyRepository.All().Where(x => x.Id == id);

                var color = colorsquery
                  .Select(p => new
                  {
                      p.Id,
                      p.ComId,
                      p.NotifyPartyName,
                      p.NotifyPartyNameSearch,
                      p.ShopCode,
                      p.Email,
                      p.IsDelete,
                      p.SLNO,
                      p.BuyerId,
                      p.buyers.Name,
                      p.CountryId,
                      p.Countrys.CountryName,
                      p.PortOfDischargeId,
                      p.PortOfDischarge.PortOfDischargeName,
                      p.PhoneNo,
                      p.Address1,
                      p.Address2,
                      p.ShippedTo,
                      p.isInactive,
                  }).FirstOrDefault();


                return Json(new { Success = 1, data = colorsquery, ex = "Data Load Successfully" });
            }
            catch (Exception e)
            {
                return Json(e.ToString());
            }

        }
        [HttpGet]
        //[AllowAnonymous]
        [OverridableAuthorize]
        public JsonResult DeleteNPs(int id)
        {
            try
            {


                var model = notifyPartyRepository.Find(id);

                if (model != null)
                {

                    notifyPartyRepository.Delete(model);

                    return Json(new { success = "1", msg = "Deleted Successfully" });
                }
                return Json(new { success = "0", msg = "No items found to delete." });

            }
            catch (Exception ex)
            {
                return Json(new { success = "0", msg = "No items found to delete." }); //msg = ex.ToString()
                throw ex;
            }
        }
        [HttpGet]
        [AllowAnonymous]
        public JsonResult GetNPList(int page = 1, decimal size = 5, string searchquery = "")
        {
            try
            {
                var CurrentUserId = HttpContext.Session.GetInt32("UserId");
                var ComId = HttpContext.Session.GetInt32("ComId");
                var purchaselist = notifyPartyRepository.All();

                if (searchquery?.Length > 1)
                {
                    purchaselist = purchaselist.Where(x =>
                        x.NotifyPartyName.ToLower().Contains(searchquery.ToLower()) ||
                        x.NotifyPartyNameSearch.ToLower().Contains(searchquery.ToLower()) ||
                        x.Address1.ToLower().Contains(searchquery.ToLower()) ||
                        x.Address2.ToLower().Contains(searchquery.ToLower()) ||
                        x.PhoneNo.ToLower().Contains(searchquery.ToLower()) ||
                        x.Email.ToLower().Contains(searchquery.ToLower()) ||
                        x.buyers.DisplayName.ToLower().Contains(searchquery.ToLower()) ||
                        x.Countrys.CountryName.ToLower().Contains(searchquery.ToLower()) ||
                        x.PortOfDischarge.PortOfDischargeName.ToLower().Contains(searchquery.ToLower()) ||
                        x.ShopCode.ToLower().Contains(searchquery.ToLower()) ||
                        x.ShippedTo.ToLower().Contains(searchquery.ToLower()) ||
                        x.SLNO.ToString().ToLower().Contains(searchquery.ToLower()) ||
                        x.DynamicReports.DynamicReportName.ToLower().Contains(searchquery.ToLower())
                    );

                }
                decimal TotalRecordCount = purchaselist.Count();
                var PageCountabc = decimal.Parse((TotalRecordCount / size).ToString());
                var PageCount = Math.Ceiling(PageCountabc);



                decimal skip = (page - 1) * size;
                var query = from p in purchaselist.Include(x => x.Countrys).Include(x => x.PortOfDischarge).Include(x => x.buyers)
                            select new
                            {
                                Id = p.Id,
                                p.ComId,
                                p.NotifyPartyName,
                                p.NotifyPartyNameSearch,
                                p.ShopCode,
                                p.Email,
                                p.IsDelete,
                                p.SLNO,
                                p.BuyerId,
                                p.buyers.Name,
                                p.CountryId,
                                npcountry = p.Countrys.CountryName,
                                p.PortOfDischargeId,
                                nppod = p.PortOfDischarge.PortOfDischargeName,
                                p.PhoneNo,
                                p.Address1,
                                p.Address2,
                                p.ShippedTo,
                                p.isInactive,
                            };
                var abcd = query.OrderByDescending(x => x.Id).Skip(int.Parse(skip.ToString())).Take(int.Parse(size.ToString())).ToList();// Take(50);
                var pageinfo = new PagingInfo();
                pageinfo.PageCount = int.Parse(PageCount.ToString());
                pageinfo.PageNo = page;
                pageinfo.PageSize = int.Parse(size.ToString());
                pageinfo.TotalRecordCount = int.Parse(TotalRecordCount.ToString());
                return Json(new { Success = 1, error = false, data = abcd, page = page, size = size, last_page = pageinfo.PageCount, total = pageinfo.TotalRecordCount });
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        [HttpGet]
        [AllowAnonymous]
        public IActionResult GetBuyerGroupDrodpwon()
        {
            var ComId = HttpContext.Session.GetInt32("ComId");

            var countries = customerRepository.All();
            return Json(countries);
        }

        [HttpGet]
        [AllowAnonymous]
        public IActionResult GetBuyerGroupDrodpwonForGroupLC()
        {
            var ComId = HttpContext.Session.GetInt32("ComId");

            var countries = customerRepository.GetAllForDropDown();
            return Json(countries);
        }
        [HttpGet]
        [AllowAnonymous]
        public IActionResult GetPODGroupDrodpwon()
        {
            var ComId = HttpContext.Session.GetInt32("ComId");

            var countries = portOfDischargeRepository.All();
            return Json(countries);
        }
        [HttpGet]
        [AllowAnonymous]
        public IActionResult GetReportLinkGroupDrodpwon()
        {
            var ComId = HttpContext.Session.GetInt32("ComId");

            var countries = dynamicReportRepository.GetAllForDropDown();
            return Json(countries);
        }
        #endregion



        #region concern  region
        [HttpPost]
        //[AllowAnonymous]
        [OverridableAuthorize]
        public IActionResult AddUpdateConcern([FromBody] OpeningBank model)
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

                        concernBankRepository.Update(model, model.Id);
                        return Json(new { success = "1", error = false, message = "Data updated successfully", Id = model.Id });
                    }
                    else
                    {
                        concernBankRepository.Insert(model);
                        return Json(new { success = "1", error = false, message = "Data saved successfully", Id = model.Id });
                    }
                }
                else
                {

                    return Json(new { error = true, message = "failed to save Data" });
                }



            }
            catch (Exception ex)
            {

                return Json(new { error = true, message = ex.Message });
            }
        }

        [HttpGet]
        //[AllowAnonymous]
        [OverridableAuthorize]
        public JsonResult GetConcernEdit(int id)
        {
            try
            {
                var colorsquery = concernBankRepository.All().Where(x => x.Id == id);

                var color = colorsquery
                  .Select(p => new
                  {
                      p.Id,
                      p.ComId,
                      p.OpeningBankName,
                      p.SwiftCode,
                      p.BranchAddress,
                      p.CountryId,
                      p.BranchAddress2,
                      p.PhoneNo,
                      p.Remarks,
                  }).FirstOrDefault();


                return Json(new { Success = 1, data = colorsquery, ex = "Data Load Successfully" });
            }
            catch (Exception e)
            {
                return Json(e.ToString());
            }

        }
        [HttpGet]
        //[AllowAnonymous]
        [OverridableAuthorize]
        public JsonResult DeleteConcern(int id)
        {
            try
            {


                var model = concernBankRepository.Find(id);

                if (model != null)
                {

                    concernBankRepository.Delete(model);

                    return Json(new { success = "1", msg = "Deleted Successfully" });
                }
                return Json(new { success = "0", msg = "No items found to delete." });

            }
            catch (Exception ex)
            {
                return Json(new { success = "0", msg = "No items found to delete." }); //msg = ex.ToString()
                throw ex;
            }
        }
        [HttpGet]
        [AllowAnonymous]
        public JsonResult GetConcernList(int page = 1, decimal size = 5, string searchquery = "")
        {
            try
            {
                var CurrentUserId = HttpContext.Session.GetInt32("UserId");
                var ComId = HttpContext.Session.GetInt32("ComId");
                var purchaselist = concernBankRepository.All();

                if (searchquery?.Length > 1)
                {
                    purchaselist = purchaselist.Where(x =>
                        x.OpeningBankName.ToLower().Contains(searchquery.ToLower())
                    );

                }
                decimal TotalRecordCount = purchaselist.Count();
                var PageCountabc = decimal.Parse((TotalRecordCount / size).ToString());
                var PageCount = Math.Ceiling(PageCountabc);



                decimal skip = (page - 1) * size;
                var query = from p in purchaselist
                            select new
                            {
                                Id = p.Id,
                                p.ComId,
                                p.OpeningBankName,
                                p.SwiftCode,
                                p.BranchAddress,
                                p.Country.CountryName,
                                p.BranchAddress2,
                                p.PhoneNo,
                                p.Remarks,
                            };
                var abcd = query.OrderByDescending(x => x.Id).Skip(int.Parse(skip.ToString())).Take(int.Parse(size.ToString())).ToList();// Take(50);
                var pageinfo = new PagingInfo();
                pageinfo.PageCount = int.Parse(PageCount.ToString());
                pageinfo.PageNo = page;
                pageinfo.PageSize = int.Parse(size.ToString());
                pageinfo.TotalRecordCount = int.Parse(TotalRecordCount.ToString());
                return Json(new { Success = 1, error = false, data = abcd, page = page, size = size, last_page = pageinfo.PageCount, total = pageinfo.TotalRecordCount });
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        #endregion



        #region bg  region
        [HttpPost]
        //[AllowAnonymous]
        [OverridableAuthorize]
        public IActionResult AddUpdateBG([FromBody] BuyerGroup model)
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

                        buyerGroupRepository.Update(model, model.Id);
                        return Json(new { success = "1", error = false, message = "Data updated successfully", Id = model.Id });
                    }
                    else
                    {
                        buyerGroupRepository.Insert(model);
                        return Json(new { success = "1", error = false, message = "Data saved successfully", Id = model.Id });
                    }
                }
                else
                {

                    return Json(new { error = true, message = "failed to save Data" });
                }



            }
            catch (Exception ex)
            {

                return Json(new { error = true, message = ex.Message });
            }
        }

        [HttpGet]
        //[AllowAnonymous]
        [OverridableAuthorize]
        public JsonResult GetBGEdit(int id)
        {
            try
            {
                var colorsquery = buyerGroupRepository.All().Where(x => x.Id == id);

                var color = colorsquery
                  .Select(p => new
                  {
                      p.Id,
                      p.ComId,
                      p.BuyerGroupName,
                      p.BuyerGroupShortName,
                      p.BuyerGroupCode,
                  }).FirstOrDefault();


                return Json(new { Success = 1, data = colorsquery, ex = "Data Load Successfully" });
            }
            catch (Exception e)
            {
                return Json(e.ToString());
            }

        }
        [HttpGet]
        //[AllowAnonymous]
        [OverridableAuthorize]
        public JsonResult DeleteBGs(int id)
        {
            try
            {


                var model = buyerGroupRepository.Find(id);

                if (model != null)
                {

                    buyerGroupRepository.Delete(model);

                    return Json(new { success = "1", msg = "Deleted Successfully" });
                }
                return Json(new { success = "0", msg = "No items found to delete." });

            }
            catch (Exception ex)
            {
                return Json(new { success = "0", msg = "No items found to delete." }); //msg = ex.ToString()
                throw ex;
            }
        }
        [AllowAnonymous]
        public JsonResult GetBGList(int page = 1, decimal size = 5, string searchquery = "")
        {
            try
            {
                var CurrentUserId = HttpContext.Session.GetInt32("UserId");
                var ComId = HttpContext.Session.GetInt32("ComId");
                var purchaselist = buyerGroupRepository.All();

                if (searchquery?.Length > 1)
                {
                    purchaselist = purchaselist.Where(x =>
                        x.BuyerGroupName.ToLower().Contains(searchquery.ToLower()) ||
                        x.BuyerGroupCode.ToLower().Contains(searchquery.ToLower()) ||
                        x.BuyerGroupShortName.ToLower().Contains(searchquery.ToLower())
                    );

                }
                decimal TotalRecordCount = purchaselist.Count();
                var PageCountabc = decimal.Parse((TotalRecordCount / size).ToString());
                var PageCount = Math.Ceiling(PageCountabc);



                decimal skip = (page - 1) * size;
                var query = from p in purchaselist
                            select new
                            {
                                Id = p.Id,
                                p.ComId,
                                p.BuyerGroupName,
                                p.BuyerGroupShortName,
                                p.BuyerGroupCode
                            };
                var abcd = query.OrderByDescending(x => x.Id).Skip(int.Parse(skip.ToString())).Take(int.Parse(size.ToString())).ToList();// Take(50);
                var pageinfo = new PagingInfo();
                pageinfo.PageCount = int.Parse(PageCount.ToString());
                pageinfo.PageNo = page;
                pageinfo.PageSize = int.Parse(size.ToString());
                pageinfo.TotalRecordCount = int.Parse(TotalRecordCount.ToString());
                return Json(new { Success = 1, error = false, data = abcd, page = page, size = size, last_page = pageinfo.PageCount, total = pageinfo.TotalRecordCount });
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion


        #region CI  region
        [HttpPost]
        //[AllowAnonymous]
        [OverridableAuthorize]
        public IActionResult AddUpdateCI([FromBody] CommercialCompanyModel model)
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

                        commercialRepository.Update(model, model.Id);
                        return Json(new { success = "1", error = false, message = "Data updated successfully", Id = model.Id });
                    }
                    else
                    {
                        commercialRepository.Insert(model);
                        return Json(new { success = "1", error = false, message = "Data saved successfully", Id = model.Id });
                    }
                }
                else
                {

                    return Json(new { error = true, message = "failed to save Data" });
                }



            }
            catch (Exception ex)
            {

                return Json(new { error = true, message = ex.Message });
            }
        }

        [HttpGet]
        //[AllowAnonymous]
        [OverridableAuthorize]
        public JsonResult GetCIEdit(int id)
        {
            try
            {
                var colorsquery = commercialRepository.All().Where(x => x.Id == id);

                var color = colorsquery
                  .Select(p => new
                  {
                      p.Id,
                      p.ComId,
                      p.CompanyName,
                      p.CompanyShortName,
                      p.Address,
                      p.Address2,
                      p.PhoneNumber,
                      p.FactoryPhoneNumber,
                      p.FaxNumber,
                      p.EmailID,
                      p.Web,
                      p.TradeLicenceNo,
                      p.TINNo,
                      p.VATNo,
                      p.IRCNo,
                      p.BKMEARegNo,
                      p.ContactPerson,
                      p.ContactPersonDesignation,
                      p.BusinessType,
                      p.ShippingMarks,
                  }).FirstOrDefault();


                return Json(new { Success = 1, data = colorsquery, ex = "Data Load Successfully" });
            }
            catch (Exception e)
            {
                return Json(e.ToString());
            }

        }
        [HttpGet]
        //[AllowAnonymous]
        [OverridableAuthorize]
        public JsonResult DeleteCIs(int id)
        {
            try
            {


                var model = commercialRepository.Find(id);

                if (model != null)
                {

                    commercialRepository.Delete(model);

                    return Json(new { success = "1", msg = "Deleted Successfully" });
                }
                return Json(new { success = "0", msg = "No items found to delete." });

            }
            catch (Exception ex)
            {
                return Json(new { success = "0", msg = "No items found to delete." }); //msg = ex.ToString()
                throw ex;
            }
        }
        [AllowAnonymous]
        public JsonResult GetCIList(int page = 1, decimal size = 5, string searchquery = "")
        {
            try
            {
                var CurrentUserId = HttpContext.Session.GetInt32("UserId");
                var ComId = HttpContext.Session.GetInt32("ComId");
                var purchaselist = commercialRepository.All();

                if (searchquery?.Length > 1)
                {
                    purchaselist = purchaselist.Where(x =>
                        x.CompanyName.ToLower().Contains(searchquery.ToLower()) ||
                        x.CompanyShortName.ToLower().Contains(searchquery.ToLower()) ||
                        x.Address.ToLower().Contains(searchquery.ToLower()) ||
                        x.Address2.ToLower().Contains(searchquery.ToLower()) ||
                        x.PhoneNumber.ToLower().Contains(searchquery.ToLower()) ||
                        x.FactoryPhoneNumber.ToLower().Contains(searchquery.ToLower()) ||
                        x.FaxNumber.ToLower().Contains(searchquery.ToLower()) ||
                        x.EmailID.ToLower().Contains(searchquery.ToLower()) ||
                        x.Web.ToLower().Contains(searchquery.ToLower()) ||
                        x.TradeLicenceNo.ToLower().Contains(searchquery.ToLower()) ||
                        x.TINNo.ToLower().Contains(searchquery.ToLower()) ||
                        x.VATNo.ToLower().Contains(searchquery.ToLower()) ||
                        x.IRCNo.ToLower().Contains(searchquery.ToLower()) ||
                        x.BKMEARegNo.ToLower().Contains(searchquery.ToLower()) ||
                        x.ContactPerson.ToLower().Contains(searchquery.ToLower()) ||
                        x.ContactPersonDesignation.ToLower().Contains(searchquery.ToLower()) ||
                        x.BusinessType.ToLower().Contains(searchquery.ToLower())
                    );

                }
                decimal TotalRecordCount = purchaselist.Count();
                var PageCountabc = decimal.Parse((TotalRecordCount / size).ToString());
                var PageCount = Math.Ceiling(PageCountabc);



                decimal skip = (page - 1) * size;
                var query = from p in purchaselist
                            select new
                            {
                                Id = p.Id,
                                p.ComId,
                                p.CompanyName,
                                p.CompanyShortName,
                                p.Address,
                                ciadrs2 = p.Address2,
                                p.PhoneNumber,
                                p.FactoryPhoneNumber,
                                p.FaxNumber,
                                p.EmailID,
                                p.Web,
                                p.TradeLicenceNo,
                                p.TINNo,
                                p.VATNo,
                                p.IRCNo,
                                p.BKMEARegNo,
                                p.ContactPerson,
                                p.ContactPersonDesignation,
                                p.BusinessType,
                            };
                var abcd = query.OrderByDescending(x => x.Id).Skip(int.Parse(skip.ToString())).Take(int.Parse(size.ToString())).ToList();// Take(50);
                var pageinfo = new PagingInfo();
                pageinfo.PageCount = int.Parse(PageCount.ToString());
                pageinfo.PageNo = page;
                pageinfo.PageSize = int.Parse(size.ToString());
                pageinfo.TotalRecordCount = int.Parse(TotalRecordCount.ToString());
                return Json(new { Success = 1, error = false, data = abcd, page = page, size = size, last_page = pageinfo.PageCount, total = pageinfo.TotalRecordCount });
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion




        #region LB  region
        [HttpPost]
        //[AllowAnonymous]
        [OverridableAuthorize]
        public IActionResult AddUpdateLB([FromBody] LienBank model)
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

                        lienBankRepository.Update(model, model.Id);
                        return Json(new { success = "1", error = false, message = "Data updated successfully", Id = model.Id });
                    }
                    else
                    {
                        lienBankRepository.Insert(model);
                        return Json(new { success = "1", error = false, message = "Data saved successfully", Id = model.Id });
                    }
                }
                else
                {

                    return Json(new { error = true, message = "failed to save Data" });
                }



            }
            catch (Exception ex)
            {

                return Json(new { error = true, message = ex.Message });
            }
        }

        [HttpGet]
        //[AllowAnonymous]
        [OverridableAuthorize]
        public JsonResult GetLBEdit(int id)
        {
            try
            {
                var colorsquery = lienBankRepository.All().Where(x => x.Id == id);

                var color = colorsquery
                  .Select(p => new
                  {
                      p.Id,
                      p.ComId,
                      p.LienBankName,
                      p.CountryId,
                      p.SwiftCode,
                      p.LienBankAccountNo,
                      p.BranchAddress,
                      p.BranchAddress2,
                      p.PhoneNo,
                      p.Remarks,
                  }).FirstOrDefault();


                return Json(new { Success = 1, data = colorsquery, ex = "Data Load Successfully" });
            }
            catch (Exception e)
            {
                return Json(e.ToString());
            }

        }
        [HttpGet]
        //[AllowAnonymous]
        [OverridableAuthorize]
        public JsonResult DeleteLBs(int id)
        {
            try
            {


                var model = lienBankRepository.Find(id);

                if (model != null)
                {

                    lienBankRepository.Delete(model);

                    return Json(new { success = "1", msg = "Deleted Successfully" });
                }
                return Json(new { success = "0", msg = "No items found to delete." });

            }
            catch (Exception ex)
            {
                return Json(new { success = "0", msg = "No items found to delete." }); //msg = ex.ToString()
                throw ex;
            }
        }
        [AllowAnonymous]
        public JsonResult GetLBList(int page = 1, decimal size = 5, string searchquery = "")
        {
            try
            {
                var CurrentUserId = HttpContext.Session.GetInt32("UserId");
                var ComId = HttpContext.Session.GetInt32("ComId");
                var purchaselist = lienBankRepository.All();

                if (searchquery?.Length > 1)
                {
                    purchaselist = purchaselist.Where(x =>
                        x.LienBankName.ToLower().Contains(searchquery.ToLower()) ||
                        x.Country.CountryName.ToLower().Contains(searchquery.ToLower()) ||
                        x.SwiftCode.ToLower().Contains(searchquery.ToLower()) ||
                        x.LienBankAccountNo.ToLower().Contains(searchquery.ToLower()) ||
                        x.BranchAddress.ToLower().Contains(searchquery.ToLower()) ||
                        x.BranchAddress2.ToLower().Contains(searchquery.ToLower()) ||
                        x.PhoneNo.ToLower().Contains(searchquery.ToLower()) ||
                        x.Remarks.ToLower().Contains(searchquery.ToLower())
                    );

                }
                decimal TotalRecordCount = purchaselist.Count();
                var PageCountabc = decimal.Parse((TotalRecordCount / size).ToString());
                var PageCount = Math.Ceiling(PageCountabc);



                decimal skip = (page - 1) * size;
                var query = from p in purchaselist.Include(x => x.Country)
                            select new
                            {
                                Id = p.Id,
                                p.ComId,
                                p.LienBankName,
                                p.CountryId,
                                lbcountry = p.Country.CountryName,
                                p.SwiftCode,
                                p.LienBankAccountNo,
                                p.BranchAddress,
                                p.BranchAddress2,
                                lbphone = p.PhoneNo,
                                p.Remarks,
                            };
                var abcd = query.OrderByDescending(x => x.Id).Skip(int.Parse(skip.ToString())).Take(int.Parse(size.ToString())).ToList();// Take(50);
                var pageinfo = new PagingInfo();
                pageinfo.PageCount = int.Parse(PageCount.ToString());
                pageinfo.PageNo = page;
                pageinfo.PageSize = int.Parse(size.ToString());
                pageinfo.TotalRecordCount = int.Parse(TotalRecordCount.ToString());
                return Json(new { Success = 1, error = false, data = abcd, page = page, size = size, last_page = pageinfo.PageCount, total = pageinfo.TotalRecordCount });
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion

        #region lien bank acc no  region
        [HttpPost]
        //[AllowAnonymous]
        [OverridableAuthorize]
        public IActionResult AddUpdateLienBannkAcc([FromBody] BankAccountNoLienBank model)
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

                        _BankAccountNoLienBankRepository.Update(model, model.Id);
                        return Json(new { success = "1", error = false, message = "Data updated successfully", Id = model.Id });
                    }
                    else
                    {
                        _BankAccountNoLienBankRepository.Insert(model);
                        return Json(new { success = "1", error = false, message = "Data saved successfully", Id = model.Id });
                    }
                }
                else
                {

                    return Json(new { error = true, message = "failed to save Data" });
                }



            }
            catch (Exception ex)
            {

                return Json(new { error = true, message = ex.Message });
            }
        }

        [HttpGet]
        //[AllowAnonymous]
        [OverridableAuthorize]
        public JsonResult GetLienBankAccEdit(int id)
        {
            try
            {
                var colorsquery = _BankAccountNoLienBankRepository.All().Where(x => x.Id == id);

                var color = colorsquery
                  .Select(p => new
                  {
                      p.Id,
                      p.ComId,
                      p.BankAccountNumber,
                      p.BankAccountName,
                      p.SwiftCodeBankAccountNoLienBank,
                      p.CountryId,
                      p.CommercialCompanyId,
                      p.LienBankId,
                      p.SupplierId,
                      p.BuyerId,
                  }).FirstOrDefault();


                return Json(new { Success = 1, data = colorsquery, ex = "Data Load Successfully" });
            }
            catch (Exception e)
            {
                return Json(e.ToString());
            }

        }
        [HttpGet]
        //[AllowAnonymous]
        [OverridableAuthorize]
        public JsonResult DeleteLienBankAcc(int id)
        {
            try
            {


                var model = _BankAccountNoLienBankRepository.Find(id);

                if (model != null)
                {

                    _BankAccountNoLienBankRepository.Delete(model);

                    return Json(new { success = "1", msg = "Deleted Successfully" });
                }
                return Json(new { success = "0", msg = "No items found to delete." });

            }
            catch (Exception ex)
            {
                return Json(new { success = "0", msg = "No items found to delete." }); //msg = ex.ToString()
                throw ex;
            }
        }
        [HttpGet]
        [AllowAnonymous]
        public JsonResult GetLienBankAccList(int page = 1, decimal size = 5, string searchquery = "")
        {
            try
            {
                var CurrentUserId = HttpContext.Session.GetInt32("UserId");
                var ComId = HttpContext.Session.GetInt32("ComId");
                var purchaselist = _BankAccountNoLienBankRepository.All();

                if (searchquery?.Length > 1)
                {
                    purchaselist = purchaselist.Where(x =>
                        x.BankAccountNumber.ToLower().Contains(searchquery.ToLower()) ||
                        x.LienBanks.LienBankName.ToLower().Contains(searchquery.ToLower()) ||
                        x.CommercialCompanys.CompanyName.ToLower().Contains(searchquery.ToLower())
                    );

                }
                decimal TotalRecordCount = purchaselist.Count();
                var PageCountabc = decimal.Parse((TotalRecordCount / size).ToString());
                var PageCount = Math.Ceiling(PageCountabc);



                decimal skip = (page - 1) * size;
                var query = from p in purchaselist
                            select new
                            {
                                Id = p.Id,
                                p.ComId,
                                p.BankAccountNumber,
                                p.SwiftCodeBankAccountNoLienBank,
                                p.Countrys.CountryName,
                                p.CommercialCompanys.CompanyName,
                                p.LienBanks.LienBankName,
                                p.SupplierInformations.SupplierName,
                                p.BuyerInformations.Name
                            };
                var abcd = query.OrderByDescending(x => x.Id).Skip(int.Parse(skip.ToString())).Take(int.Parse(size.ToString())).ToList();// Take(50);
                var pageinfo = new PagingInfo();
                pageinfo.PageCount = int.Parse(PageCount.ToString());
                pageinfo.PageNo = page;
                pageinfo.PageSize = int.Parse(size.ToString());
                pageinfo.TotalRecordCount = int.Parse(TotalRecordCount.ToString());
                return Json(new { Success = 1, error = false, data = abcd, page = page, size = size, last_page = pageinfo.PageCount, total = pageinfo.TotalRecordCount });
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        #endregion


        #region BA  region
        [HttpPost]
        //[AllowAnonymous]
        [OverridableAuthorize]
        public IActionResult AddUpdateBA([FromBody] BankAccountNo model)
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

                        bankAccountNoRepository.Update(model, model.Id);
                        return Json(new { success = "1", error = false, message = "Data updated successfully", Id = model.Id });
                    }
                    else
                    {
                        bankAccountNoRepository.Insert(model);
                        return Json(new { success = "1", error = false, message = "Data saved successfully", Id = model.Id });
                    }
                }
                else
                {

                    return Json(new { error = true, message = "failed to save Data" });
                }



            }
            catch (Exception ex)
            {

                return Json(new { error = true, message = ex.Message });
            }
        }

        [HttpGet]
        //[AllowAnonymous]
        [OverridableAuthorize]
        public JsonResult GetBAEdit(int id)
        {
            try
            {
                var colorsquery = bankAccountNoRepository.All().Where(x => x.Id == id);

                var color = colorsquery
                  .Select(p => new
                  {
                      p.Id,
                      p.ComId,
                      p.BankAccountNumber,
                      p.CommercialCompanyId,
                      p.OpeningBankId,
                  }).FirstOrDefault();


                return Json(new { Success = 1, data = colorsquery, ex = "Data Load Successfully" });
            }
            catch (Exception e)
            {
                return Json(e.ToString());
            }

        }


        [HttpPost]
        [AllowAnonymous]
        public IActionResult GetBankAccountNameByBankAccNo(int BankAccountNoId)
        {
            var openingBankId = bankAccountNoRepository.All().Where(x => x.Id == BankAccountNoId).FirstOrDefault().OpeningBankId;
            var concernBankData = concernBankRepository.All().Where(x => x.Id == openingBankId)
                .Select(x => new
                {
                    x.Id,
                    x.OpeningBankName
                }).FirstOrDefault();
            return Json(concernBankData);
        }
        [HttpGet]
        //[AllowAnonymous]
        [OverridableAuthorize]
        public JsonResult DeleteBAs(int id)
        {
            try
            {


                var model = bankAccountNoRepository.Find(id);

                if (model != null)
                {

                    bankAccountNoRepository.Delete(model);

                    return Json(new { success = "1", msg = "Deleted Successfully" });
                }
                return Json(new { success = "0", msg = "No items found to delete." });

            }
            catch (Exception ex)
            {
                return Json(new { success = "0", msg = "No items found to delete." }); //msg = ex.ToString()
                throw ex;
            }
        }
        [AllowAnonymous]
        public JsonResult GetLBAist(int page = 1, decimal size = 5, string searchquery = "")
        {
            try
            {
                var CurrentUserId = HttpContext.Session.GetInt32("UserId");
                var ComId = HttpContext.Session.GetInt32("ComId");
                var purchaselist = bankAccountNoRepository.All();

                if (searchquery?.Length > 1)
                {
                    purchaselist = purchaselist.Where(x =>
                        x.BankAccountNumber.ToLower().Contains(searchquery.ToLower()) ||
                        x.CommercialCompanies.CompanyName.ToLower().Contains(searchquery.ToLower()) ||
                        x.OpeningBanks.OpeningBankName.ToLower().Contains(searchquery.ToLower())
                    );

                }
                decimal TotalRecordCount = purchaselist.Count();
                var PageCountabc = decimal.Parse((TotalRecordCount / size).ToString());
                var PageCount = Math.Ceiling(PageCountabc);



                decimal skip = (page - 1) * size;
                var query = from p in purchaselist.Include(x => x.CommercialCompanies).Include(x => x.OpeningBanks)
                            select new
                            {
                                Id = p.Id,
                                p.ComId,
                                p.BankAccountNumber,
                                p.CommercialCompanyId,
                                bacom = p.CommercialCompanies.CompanyName,
                                p.OpeningBankId,
                                babank = p.OpeningBanks.OpeningBankName,
                            };
                var abcd = query.OrderByDescending(x => x.Id).Skip(int.Parse(skip.ToString())).Take(int.Parse(size.ToString())).ToList();// Take(50);
                var pageinfo = new PagingInfo();
                pageinfo.PageCount = int.Parse(PageCount.ToString());
                pageinfo.PageNo = page;
                pageinfo.PageSize = int.Parse(size.ToString());
                pageinfo.TotalRecordCount = int.Parse(TotalRecordCount.ToString());
                return Json(new { Success = 1, error = false, data = abcd, page = page, size = size, last_page = pageinfo.PageCount, total = pageinfo.TotalRecordCount });
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public IActionResult commercialCompanyDropdown()
        {
            var dropdown = commercialRepository.GetAllForDropDown();
            return Json(dropdown);
        }
        public IActionResult oepningBankDropdown()
        {
            var dropdown = lienBankRepository.GetAllForDropDown();
            return Json(dropdown);
        }
        #endregion


        #region Box Measurement
        [HttpPost]
        //[AllowAnonymous]
        [OverridableAuthorize]
        public IActionResult AddUpdateMeasurement([FromBody] BoxCategoryModel model)
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

                        BoxCategoryRepository.Update(model, model.Id);
                        return Json(new { success = "1", error = false, message = "Data updated successfully", Id = model.Id });
                    }
                    else
                    {
                        BoxCategoryRepository.Insert(model);
                        return Json(new { success = "1", error = false, message = "Data saved successfully", Id = model.Id });
                    }
                }
                else
                {

                    return Json(new { error = true, message = "failed to save Data" });
                }



            }
            catch (Exception ex)
            {

                return Json(new { error = true, message = ex.Message });
            }
        }

        [HttpGet]
        //[AllowAnonymous]
        [OverridableAuthorize]
        public JsonResult GetMeasurementEdit(int id)
        {
            try
            {
                var measurement = BoxCategoryRepository.All().Where(x => x.Id == id);

                var box = measurement
                  .Select(p => new
                  {
                      p.Id,
                      p.ComId,
                      p.MeasurementName,
                      p.MeasurementNo,
                      p.BoxHeight,
                      p.BoxLength,
                      p.BoxWidth,
                      p.Calculation,
                  }).FirstOrDefault();


                return Json(new { Success = 1, data = measurement, ex = "Data Load Successfully" });
            }
            catch (Exception e)
            {
                return Json(e.ToString());
            }

        }



        [HttpGet]
        //[AllowAnonymous]
        [OverridableAuthorize]
        public JsonResult DeleteMeasurement(int id)
        {
            try
            {


                var model = BoxCategoryRepository.Find(id);

                if (model != null)
                {

                    BoxCategoryRepository.Delete(model);

                    return Json(new { success = "1", msg = "Deleted Successfully" });
                }
                return Json(new { success = "0", msg = "No items found to delete." });

            }
            catch (Exception ex)
            {
                return Json(new { success = "0", msg = "No items found to delete." }); //msg = ex.ToString()
                throw ex;
            }
        }
        [AllowAnonymous]
        public JsonResult GetMeasurementList(int page = 1, decimal size = 5, string searchquery = "")
        {
            try
            {
                var CurrentUserId = HttpContext.Session.GetInt32("UserId");
                var ComId = HttpContext.Session.GetInt32("ComId");
                var purchaselist = BoxCategoryRepository.All();

                if (searchquery?.Length > 1)
                {
                    purchaselist = purchaselist.Where(x =>
                        x.MeasurementName.ToLower().Contains(searchquery.ToLower()) ||
                        x.MeasurementNo.ToLower().Contains(searchquery.ToLower()) ||
                        x.BoxHeight.ToString().ToLower().Contains(searchquery.ToLower()) ||
                        x.BoxWidth.ToString().ToLower().Contains(searchquery.ToLower()) ||
                        x.BoxLength.ToString().ToLower().Contains(searchquery.ToLower()) ||
                        x.Calculation.ToString().ToLower().Contains(searchquery.ToLower())
                    );

                }
                decimal TotalRecordCount = purchaselist.Count();
                var PageCountabc = decimal.Parse((TotalRecordCount / size).ToString());
                var PageCount = Math.Ceiling(PageCountabc);



                decimal skip = (page - 1) * size;
                var query = from p in purchaselist
                            select new
                            {
                                Id = p.Id,
                                p.ComId,
                                p.MeasurementName,
                                p.MeasurementNo,
                                p.BoxHeight,
                                p.BoxWidth,
                                p.BoxLength,
                                p.Calculation,
                            };
                var abcd = query.OrderByDescending(x => x.Id).Skip(int.Parse(skip.ToString())).Take(int.Parse(size.ToString())).ToList();// Take(50);
                var pageinfo = new PagingInfo();
                pageinfo.PageCount = int.Parse(PageCount.ToString());
                pageinfo.PageNo = page;
                pageinfo.PageSize = int.Parse(size.ToString());
                pageinfo.TotalRecordCount = int.Parse(TotalRecordCount.ToString());
                return Json(new { Success = 1, error = false, data = abcd, page = page, size = size, last_page = pageinfo.PageCount, total = pageinfo.TotalRecordCount });
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        #endregion

        public IActionResult Import(string Type)
        {
            ViewBag.ListType = Type ?? "proformaInvoice";
            return View();
        }

        #region proforma invoice region
        [HttpPost]
        //[AllowAnonymous]
        [OverridableAuthorize]
        public IActionResult AddUpdateProforma([FromBody] COM_ProformaInvoice model)
        {
            try
            {
                var UserId = HttpContext.Session.GetInt32("UserId");
                var ComId = HttpContext.Session.GetInt32("ComId");

                var errors = ModelState.Where(x => x.Value.Errors.Any())
                .Select(x => new { x.Key, x.Value.Errors });

                model.DoctypeId = docTypeRepository.All().Where(x => x.DocType == "Proforma Invoice").FirstOrDefault().Id;

                if (ModelState.IsValid)
                {
                    if (model.Id > 0)
                    {

                        proformaInvoiceRepository.Update(model, model.Id);

                        var previousitem = _ProformaInvoiceSubInvoiceRepository.All().Where(x => x.PIId == model.Id).ToList();
                        var tmp = previousitem.Where(x => !model.COM_ProformaInvoice_Subs.Any(z => x.Id == z.Id)).ToList();
                        _ProformaInvoiceSubInvoiceRepository.RemoveRange(tmp);

                        foreach (COM_ProformaInvoice_Sub item in model.COM_ProformaInvoice_Subs)
                        {
                            if (item.Id > 0)
                            {
                                item.PIId = model.Id;
                                _ProformaInvoiceSubInvoiceRepository.Update(item, item.Id);

                            }
                            else
                            {
                                item.PIId = model.Id;
                                _ProformaInvoiceSubInvoiceRepository.Insert(item);

                            }
                        }

                        return Json(new { success = "1", error = false, message = "Data updated successfully", Id = model.Id });
                    }
                    else
                    {
                        foreach (var item in model.COM_ProformaInvoice_Subs)
                        {

                            item.CreateDate = DateTime.Now;
                            item.UpdateDate = DateTime.Now;
                            item.ComId = int.Parse(ComId.ToString());
                            item.LuserId = int.Parse(UserId.ToString());
                            item.PIId = model.Id;
                        }
                        proformaInvoiceRepository.Insert(model);
                        return Json(new { success = "1", error = false, message = "Data saved successfully", Id = model.Id });
                    }
                }
                else
                {

                    return Json(new { error = true, message = "failed to save Data" });
                }



            }
            catch (Exception ex)
            {

                return Json(new { error = true, message = ex.Message });
            }
        }

        [HttpGet]
        //[AllowAnonymous]
        [OverridableAuthorize]
        public JsonResult GetProformaEdit(int id)
        {
            try
            {
                var colorsquery = proformaInvoiceRepository.All().Where(x => x.Id == id);

                var data = transactionApprovalStatusRepository.All().Where(x => x.ProformaInvoiceId == id).FirstOrDefault();

                var editable = data == null ? true : false;

                var color = colorsquery.Include(p => p.COM_ProformaInvoice_Subs).Include(p => p.COM_GroupLC_Mains)
                  .Select(p => new
                  {
                      p.Id,
                      p.ComId,
                      p.PINo,
                      PIDate = p.PIDate.ToString("dd-MMM-yyyy"),
                      PIReceivingDate = p.PIReceivingDate.ToString("dd-MMM-yyyy"),
                      p.CommercialCompanyId,
                      p.CurrencyId,
                      p.SupplierId,
                      p.ImportPONo,
                      p.FileNo,
                      p.ItemGroupId,
                      p.ItemGroups,
                      p.GroupLCId,
                      p.COM_GroupLC_Mains.GroupLCRefName,
                      p.ItemGroupName,
                      p.Size,
                      p.Remarks,
                      p.ImportQty,
                      p.UnitId,
                      p.SecondaryUnitId,
                      p.ImportRate,
                      p.CartonRollQty,
                      p.TotalValue,
                      p.HSCode,
                      p.EmployeeId,
                      p.MerchandiserName,
                      p.RevNo,
                      p.PaymentTermsId,
                      p.DayListId,
                      p.BankAccountNoLienBankId,
                      p.BankAccountId,
                      p.LienBankId,
                      p.PITypeId,
                      p.PortOfLoadingId,
                      p.PortOfLoadingCountryOfOriginId,
                      p.PortOfDestinationId,
                      p.LCAF,
                      p.PortOfLoadingDestinationId,
                      p.COM_ProformaInvoice_Subs,
                      p.PINatureId,
                      //COM_ProformaInvoice_Subs = p.COM_ProformaInvoice_Subs.Select(y => new
                      //{
                      //    ItemDescId=y.ItemDescId
                      //}),
                  }).FirstOrDefault();


                return Json(new { Success = 1, data = color, editable = editable, ex = "Data Load Successfully" });
            }
            catch (Exception e)
            {
                return Json(e.ToString());
            }

        }
        [HttpGet]
        //[AllowAnonymous]
        [OverridableAuthorize]
        public JsonResult DeleteProformas(int id)
        {
            try
            {


                var model = proformaInvoiceRepository.Find(id);
                var modelItemDesc = _ProformaInvoiceSubInvoiceRepository.All().Where(x => x.PIId == id).ToList();

                if (model != null)
                {

                    _ProformaInvoiceSubInvoiceRepository.RemoveRange(modelItemDesc);
                    proformaInvoiceRepository.Delete(model);

                    return Json(new { success = "1", msg = "Deleted Successfully" });
                }
                return Json(new { success = "0", msg = "No items found to delete." });

            }
            catch (Exception ex)
            {
                return Json(new { success = "0", msg = "No items found to delete." }); //msg = ex.ToString()
                throw ex;
            }
        }
        [AllowAnonymous]
        public JsonResult GetProformaList(string fromDate = "", string toDate = "", int supplierid = 0, int page = 1, decimal size = 5, string searchquery = "")
        {
            try
            {
                var CurrentUserId = HttpContext.Session.GetInt32("UserId");
                var ComId = HttpContext.Session.GetInt32("ComId");
                var purchaselist = proformaInvoiceRepository.All();

                if (searchquery?.Length > 1)
                {
                    purchaselist = purchaselist.Where(x =>
                        x.PINo.ToLower().Contains(searchquery.ToLower()) ||
                        x.PIDate.ToString().ToLower().Contains(searchquery.ToLower()) ||
                        x.PIReceivingDate.ToString().ToLower().Contains(searchquery.ToLower()) ||
                        x.CommercialCompanies.CompanyName.ToLower().Contains(searchquery.ToLower()) ||
                        x.Currencies.CountryName.ToLower().Contains(searchquery.ToLower()) ||
                        x.Suppliers.SupplierName.ToLower().Contains(searchquery.ToLower()) ||
                        x.ImportPONo.ToLower().Contains(searchquery.ToLower()) ||
                        x.FileNo.ToLower().Contains(searchquery.ToLower()) ||
                        x.LCAF.ToLower().Contains(searchquery.ToLower()) ||
                        x.ItemDescList.ToLower().Contains(searchquery.ToLower()) ||
                        x.ItemGroups.ItemGroupName.ToLower().Contains(searchquery.ToLower()) ||
                        x.COM_GroupLC_Mains.GroupLCRefName.ToLower().Contains(searchquery.ToLower()) ||
                        x.ItemGroupName.ToLower().Contains(searchquery.ToLower()) ||
                        x.ItemDescs.ItemDescName.ToLower().Contains(searchquery.ToLower()) ||
                        x.Size.ToLower().Contains(searchquery.ToLower()) ||
                        x.Remarks.ToLower().Contains(searchquery.ToLower()) ||
                        x.ImportQty.ToString().ToLower().Contains(searchquery.ToLower()) ||
                        x.ImportRate.ToString().ToLower().Contains(searchquery.ToLower()) ||
                        x.CartonRollQty.ToString().ToLower().Contains(searchquery.ToLower()) ||
                        x.TotalValue.ToString().ToLower().Contains(searchquery.ToLower()) ||
                        x.HSCode.ToLower().Contains(searchquery.ToLower()) ||
                        x.employees.EmployeeName.ToLower().Contains(searchquery.ToLower()) ||
                        x.MerchandiserName.ToLower().Contains(searchquery.ToLower()) ||
                        x.RevNo.ToLower().Contains(searchquery.ToLower()) ||
                        x.UnitMaster.UnitName.ToLower().Contains(searchquery.ToLower()) ||
                        x.PaymentTerms.PaymentTermsName.ToLower().Contains(searchquery.ToLower()) ||
                        x.DayList.DayListName.ToLower().Contains(searchquery.ToLower()) ||
                        x.BankAccountNos.BankAccountNumber.ToLower().Contains(searchquery.ToLower()) ||
                        x.LienBanks.LienBankName.ToLower().Contains(searchquery.ToLower()) ||
                        x.PITypes.PITytpeName.ToLower().Contains(searchquery.ToLower()) ||
                        x.PortOfLoading.PortOfLoadingName.ToLower().Contains(searchquery.ToLower()) ||
                        x.PortOfLoadingDestination.PortOfLoadingName.ToLower().Contains(searchquery.ToLower()) ||
                        x.PortOfLoadingCountryOfOrigin.PortOfLoadingName.ToLower().Contains(searchquery.ToLower())
                    );

                }


                if (supplierid > 0)
                {
                    purchaselist = proformaInvoiceRepository.All().Where(x => x.SupplierId == supplierid);
                }
                if (!string.IsNullOrEmpty(fromDate))
                {
                    DateTime fromDateValue = Convert.ToDateTime(fromDate);
                    purchaselist = proformaInvoiceRepository.All().Where(x => x.PIDate.Date >= fromDateValue.Date);
                }
                if (!string.IsNullOrEmpty(toDate))
                {
                    DateTime fromDateValue = Convert.ToDateTime(toDate);
                    purchaselist = proformaInvoiceRepository.All().Where(x => x.PIDate.Date >= fromDateValue.Date);
                }

                decimal TotalRecordCount = purchaselist.Count();
                var PageCountabc = decimal.Parse((TotalRecordCount / size).ToString());
                var PageCount = Math.Ceiling(PageCountabc);



                decimal skip = (page - 1) * size;
                var query = from p in purchaselist.Include(x => x.CommercialCompanies).Include(x => x.ItemDescs).Include(x => x.ItemDescs).Include(x => x.ItemGroups)
                            select new
                            {
                                Id = p.Id,
                                p.ComId,
                                p.PINo,
                                p.COM_GroupLC_Mains.GroupLCAmdNo,
                                p.COM_GroupLC_Mains.GroupLCRefName,
                                p.Currencies.CountryName,
                                p.Suppliers.SupplierName,
                                p.UnitMaster.UnitName,
                                PIDate = p.PIDate.ToString("dd-MMM-yyyy"),
                                PIReceivingDate = p.PIReceivingDate.ToString("dd-MMM-yyyy"),
                                p.CommercialCompanyId,
                                p.CommercialCompanies.CompanyName,
                                p.CurrencyId,
                                p.SupplierId,
                                p.ImportPONo,
                                p.FileNo,
                                p.LCAF,
                                p.ItemGroupId,
                                p.ItemDescription,
                                p.ItemGroups.ItemGroupName,
                                p.GroupLCId,
                                p.ItemDescId,
                                p.ItemDescs.ItemDescName,
                                p.Size,
                                p.Remarks,
                                p.ImportQty,
                                p.UnitId,
                                p.ImportRate,
                                p.CartonRollQty,
                                p.TotalValue,
                                p.HSCode,
                                p.EmployeeId,
                                p.MerchandiserName,
                                p.RevNo,
                                p.PaymentTermsId,
                                p.DayListId,
                                p.BankAccountNoLienBankId,
                                p.BankAccountId,
                                p.LienBankId,
                                p.PITypeId,
                                p.PortOfLoadingId,
                                p.PortOfLoadingDestinationId,
                                p.PortOfLoadingCountryOfOriginId,
                            };
                var abcd = query.OrderByDescending(x => x.Id).Skip(int.Parse(skip.ToString())).Take(int.Parse(size.ToString())).ToList();// Take(50);
                var pageinfo = new PagingInfo();
                pageinfo.PageCount = int.Parse(PageCount.ToString());
                pageinfo.PageNo = page;
                pageinfo.PageSize = int.Parse(size.ToString());
                pageinfo.TotalRecordCount = int.Parse(TotalRecordCount.ToString());
                return Json(new { Success = 1, error = false, data = abcd, page = page, size = size, last_page = pageinfo.PageCount, total = pageinfo.TotalRecordCount });
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        [AllowAnonymous]
        public JsonResult GetProformaList1(string fromDate = "", string toDate = "", int supplierid = 0, int page = 1, decimal size = 5, string searchquery = "")
        {
            try
            {
                var errors = ModelState.Where(x => x.Value.Errors.Any())
                .Select(x => new { x.Key, x.Value.Errors });

                var CurrentUserId = HttpContext.Session.GetInt32("UserId");
                var ComId = HttpContext.Session.GetInt32("ComId");
                DateTime fromDateValue = Convert.ToDateTime(fromDate);
                DateTime toDateValue = Convert.ToDateTime(toDate);
                var purchaselist = proformaInvoiceRepository.All().Where(x => x.IsDelete == false);

                var taburesquest = JsonConvert.DeserializeObject<TabulatorRequest>(searchquery);
                if (taburesquest.Filter.Count == 0)
                {
                    purchaselist = purchaselist.Where(x => x.PIDate.Date >= fromDateValue.Date && x.PIDate.Date <= toDateValue.Date);

                }

                foreach (var item in taburesquest.Filter)
                {
                    if (item.Field == "LCNo")
                    {
                        purchaselist = purchaselist.Where(x => x.BBLC_Info.FirstOrDefault().BBLCMain.BBLCNo.ToLower().Contains(item.Value.ToLower()));
                    }
                    if (item.Field == "LCType")
                    {
                        purchaselist = purchaselist.Where(x => x.BBLC_Info.FirstOrDefault().BBLCMain.LCType.CommercialLCTypeName.ToLower().Contains(item.Value.ToLower()));
                    }
                    if (item.Field == "GroupLCAmdNo")
                    {
                        purchaselist = purchaselist.Where(x => x.COM_GroupLC_Mains.GroupLCAmdNo.ToLower().Contains(item.Value.ToLower()));
                    }

                    if (item.Field == "GroupLCRefName")
                    {
                        purchaselist = purchaselist.Where(x => x.COM_GroupLC_Mains.GroupLCRefName.ToLower().Contains(item.Value.ToLower()));
                    }
                    if (item.Field == "PINo")
                    {
                        purchaselist = purchaselist.Where(x => x.PINo.ToLower().Contains(item.Value.ToLower()));
                    }
                    if (item.Field == "CompanyName")
                    {
                        purchaselist = purchaselist.Where(x => x.CommercialCompanies.CompanyName.ToLower().Contains(item.Value.ToLower()));
                    }
                    if (item.Field == "CurrencyShortName")
                    {
                        purchaselist = purchaselist.Where(x => x.Currencies.CurrencyShortName.ToLower().Contains(item.Value.ToLower()));
                    }

                    if (item.Field == "SupplierName")
                    {
                        purchaselist = purchaselist.Where(x => x.Suppliers.SupplierName.ToLower().Contains(item.Value.ToLower()));
                    }

                    if (item.Field == "ImportPONo")
                    {
                        purchaselist = purchaselist.Where(x => x.ImportPONo.ToLower().Contains(item.Value.ToLower()));
                    }

                    if (item.Field == "FileNo")
                    {
                        purchaselist = purchaselist.Where(x => x.FileNo.ToLower().Contains(item.Value.ToLower()));
                    }
                    if (item.Field == "LCAF")
                    {
                        purchaselist = purchaselist.Where(x => x.LCAF.ToLower().Contains(item.Value.ToLower()));
                    }
                    if (item.Field == "ItemGroupName")
                    {
                        purchaselist = purchaselist.Where(x => x.ItemGroupName.ToLower().Contains(item.Value.ToLower()));
                    }
                    if (item.Field == "ImportQty")
                    {
                        purchaselist = purchaselist.Where(x => x.ImportQty.ToString().ToLower().Contains(item.Value.ToLower()));
                    }
                    if (item.Field == "UnitName")
                    {
                        purchaselist = purchaselist.Where(x => x.UnitMaster.UnitName.ToLower().Contains(item.Value.ToLower()));
                    }
                    if (item.Field == "ImportRate")
                    {
                        purchaselist = purchaselist.Where(x => x.ImportRate.ToString().ToLower().Contains(item.Value.ToLower()));
                    }
                    if (item.Field == "TotalValue")
                    {
                        purchaselist = purchaselist.Where(x => x.TotalValue.ToString().ToLower().Contains(item.Value.ToLower()));
                    }

                }


                if (supplierid > 0)
                {
                    purchaselist = proformaInvoiceRepository.All().Where(x => x.SupplierId == supplierid && x.IsDelete == false);
                }
                //if (!string.IsNullOrEmpty(fromDate))
                //{
                //    DateTime fromDateValue = Convert.ToDateTime(fromDate);
                //    purchaselist = proformaInvoiceRepository.All().Where(x => x.PIDate.Date >= fromDateValue.Date);
                //}
                //if (!string.IsNullOrEmpty(toDate))
                //{
                //    DateTime toDateValue = Convert.ToDateTime(toDate);
                //    purchaselist = proformaInvoiceRepository.All().Where(x => x.PIDate.Date <= toDateValue.Date);
                //}

                decimal TotalRecordCount = purchaselist.Count();
                var PageCountabc = decimal.Parse((TotalRecordCount / taburesquest.Size).ToString());
                var PageCount = Math.Ceiling(PageCountabc);

                int skip = (taburesquest.Page - 1) * taburesquest.Size;


                var query = from p in purchaselist.Include(x => x.CommercialCompanies)
                            .Include(x => x.ItemDescs)
                            .Include(x => x.ItemGroups).Include(x => x.BBLC_Info)
                            select new
                            {
                                Id = p.Id,
                                p.ComId,
                                p.PINo,
                                GroupLCAmdNo = p.COM_GroupLC_Mains.GroupLCAmdNo,
                                LCNo = p.BBLC_Info.FirstOrDefault().BBLCMain.BBLCNo ?? "LC Not Linked",
                                LCType = p.BBLC_Info.FirstOrDefault().BBLCMain.LCType.CommercialLCTypeName ?? "N/A",
                                p.COM_GroupLC_Mains.GroupLCRefName,
                                p.Currencies.CurrencyShortName,
                                p.Suppliers.SupplierName,
                                p.UnitMaster.UnitName,
                                PIDate = p.PIDate.ToString("dd-MMM-yyyy"),
                                PIReceivingDate = p.PIReceivingDate.ToString("dd-MMM-yyyy"),
                                p.CommercialCompanyId,
                                p.CommercialCompanies.CompanyName,
                                p.CurrencyId,
                                p.SupplierId,
                                p.ImportPONo,
                                p.FileNo,
                                p.LCAF,
                                p.ItemGroupId,
                                p.ItemDescription,
                                p.ItemGroups.ItemGroupName,
                                p.GroupLCId,
                                p.ItemDescId,
                                p.ItemDescs.ItemDescName,
                                p.Size,
                                p.Remarks,
                                p.ImportQty,
                                p.UnitId,
                                p.ImportRate,
                                p.CartonRollQty,
                                p.TotalValue,
                                p.HSCode,
                                p.EmployeeId,
                                p.MerchandiserName,
                                p.RevNo,
                                p.PaymentTermsId,
                                p.DayListId,
                                p.BankAccountNoLienBankId,
                                p.BankAccountId,
                                p.LienBankId,
                                p.PITypeId,
                                p.PortOfLoadingId,
                                p.PortOfLoadingDestinationId,
                                p.PortOfLoadingCountryOfOriginId
                            };
                var abcd = query.OrderByDescending(x => x.Id).Skip(skip).Take(taburesquest.Size).ToList();
                var pageinfo = new PagingInfo();
                pageinfo.PageCount = int.Parse(PageCount.ToString());
                pageinfo.PageNo = taburesquest.Page;
                pageinfo.PageSize = taburesquest.Size;
                pageinfo.TotalRecordCount = int.Parse(TotalRecordCount.ToString());

                //return  abcd;
                return Json(new { Success = 1, error = false, data = abcd, page = taburesquest.Page, size = taburesquest.Size, last_page = pageinfo.PageCount, total = pageinfo.TotalRecordCount });

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        //dropdowns starts==============================
        [AllowAnonymous]
        public IActionResult concernDrodpdown()
        {
            var dropdown = commercialRepository.GetAllForDropDown();
            return Json(dropdown);
        }
        [AllowAnonymous]
        public IActionResult approvedByDrodpdown()
        {
            var dropdown = _ApprovedByRepository.GetAllForDropDown();
            return Json(dropdown);
        }
        [AllowAnonymous]
        public IActionResult currencyDrodpdown()
        {
            var dropdown = _countryRepository.GetCurrencyList();
            return Json(dropdown);
        }
        [AllowAnonymous]
        public IActionResult supplierDrodpdown()
        {
            var dropdown = supplierRepository.GetAllForDropDown();
            return Json(dropdown);
        }
        [AllowAnonymous]
        public IActionResult employeeDrodpdown()
        {
            var dropdown = employeeRepository.GetAllForDropDown();
            return Json(dropdown);
        }
        [AllowAnonymous]
        public IActionResult concernBankAccountDrodpdown()
        {
            var dropdown = bankAccountNoRepository.GetAllForDropDown();
            return Json(dropdown);
        }
        [AllowAnonymous]
        public IActionResult concernBankDrodpdown()
        {
            var dropdown = concernBankRepository.GetAllForDropDown();
            return Json(dropdown);
        }
        [AllowAnonymous]
        public IActionResult supplierBankDrodpdown()
        {
            var dropdown = lienBankRepository.GetAllForDropDown();
            return Json(dropdown);
        }
        [AllowAnonymous]
        public IActionResult supplierBankNoDrodpdown()
        {
            var dropdown = _BankAccountNoLienBankRepository.GetAllForDropDown();
            return Json(dropdown);
        }
        [AllowAnonymous]
        public IActionResult itemGroupDrodpdown()
        {
            var dropdown = itemGroupRepository.GetAllForDropDown();
            return Json(dropdown);
        }
        [AllowAnonymous]
        public IActionResult piTypeDrodpdown()
        {
            var dropdown = pITypeRepository.GetAllForDropDown();
            return Json(dropdown);
        }
        [AllowAnonymous]
        public IActionResult itemDescriptionDrodpdown()
        {
            var dropdown = itemDescriptionRepository.GetAllForDropDown();
            return Json(dropdown);
        }
        [AllowAnonymous]
        public IActionResult itemDescriptionDrodpdownTable()
        {
            var dropdown = itemDescriptionRepository.All().Select(x => new
            {
                ItemDescId = x.Id
            });
            return Json(dropdown);
        }
        [AllowAnonymous]
        public IActionResult groupLCMainDrodpdown()
        {
            var dropdown = groupLCMainRepository.GetAllForDropDown();
            return Json(dropdown);
        }

        [AllowAnonymous]
        public JsonResult GroupLCSearch(string query)
        {
            var abc = groupLCMainRepository.All()
                .Where(x => (x.GroupLCRefName.ToLower().Contains(query.ToLower()))).ToList()
                        .Select(p => new
                        {
                            Id = p.Id,
                            p.GroupLCRefName,
                        }).Take(10);

            return Json(abc);
        }
        [AllowAnonymous]
        public IActionResult qtyDrodpdown()
        {
            var dropdown = unitRepository.GetAllForDropDown();
            return Json(dropdown);
        }
        [AllowAnonymous]
        public IActionResult paymentTermsDrodpdown()
        {
            var dropdown = paymentTermsRepository.GetAllForDropDown();
            return Json(dropdown);
        }
        [AllowAnonymous]
        public IActionResult piNatureDrodpdown()
        {
            var dropdown = piNatureRepository.GetAllForDropDown();
            return Json(dropdown);
        }
        [AllowAnonymous]
        public IActionResult dayListDrodpdown()
        {
            var dropdown = dayListRepository.GetAllForDropDown();
            return Json(dropdown);
        }
        [AllowAnonymous]
        public IActionResult countryOFOriginDrodpdown()
        {
            var dropdown = _countryRepository.All();
            return Json(dropdown);
        }
        [AllowAnonymous]
        public IActionResult portOFLoadingDrodpdown()
        {
            var dropdown = portOfLoadingRepository.GetAllForDropDown();
            return Json(dropdown);
        }
        [AllowAnonymous]
        public IActionResult destinationDrodpdown()
        {
            var dropdown = destinationRepository.GetAllForDropDown();
            return Json(dropdown);
        }
        [AllowAnonymous]
        public IActionResult portOFDischargeDrodpdown()
        {
            var dropdown = portOfDischargeRepository.GetAllForDropDown();
            return Json(dropdown);
        }
        #endregion


        #region BBLC region
        //public IActionResult CreateBackToBackLC(int backtobacklcid = 0)
        [OverridableAuthorize]
        public IActionResult AddBackToBackLC(int backtobacklcid = 0)
        {

            ViewBag.ActionType = "Create";
            ViewBag.BBLCID = backtobacklcid;
            return View();
        }

        [OverridableAuthorize]
        public IActionResult UpdateBackToBackLC(int backtobacklcid)
        {

            ViewBag.ActionType = "Edit";
            ViewBag.BBLCID = backtobacklcid;
            return View("AddBackToBackLC");
        }

        [HttpPost]
        [AllowAnonymous]
        public IActionResult getMasterLCData(int groupLCid = 0)
        {

            if (groupLCid > 0)
            {
                var groupLCDataa = proformaInvoiceRepository.All().Where(x => x.GroupLCId == groupLCid);

                var buyerId = groupLCMainRepository.All().Where(x => x.Id == groupLCid).FirstOrDefault().BuyerId;

                var sumAmount = groupLCMainRepository.All().Where(x => x.Id == groupLCid && x.Buyers.Id == buyerId).Sum(x => x.TotalGroupLCValue);

                var groupLCData = groupLCMainRepository.All().Where(x => x.Id == groupLCid)
                    .Select(x => new
                    {
                        buyerName = x.Buyers.Name,
                        Benificiary = "Benificiary",
                        ContactRef = x.GroupLCRefName,
                        //LCDate = x.GroupLC_Sub.FirstOrDefault().MasterLC.LCOpenDate.ToString("dd-MMM-yyyy"),                       
                        LCDate = x.GroupLC_Sub.FirstOrDefault().MasterLC.LCOpenDate != null ? x.GroupLC_Sub.FirstOrDefault().MasterLC.LCOpenDate.Value.ToString("dd-MMM-yyyy") : null,
                        Amount = x.TotalGroupLCValue

                    }).ToList();
                //var piid = groupLCDataa.FirstOrDefault().Id;


                var ComId = HttpContext.Session.GetInt32("ComId");
                var UserId = HttpContext.Session.GetInt32("UserId");
                var queryname = "getMasterLCDataforBBLC";
                var viewquery = $"Exec {queryname} '{ComId}','{groupLCid}','{0}'";
                Console.WriteLine(viewquery);
                SqlParameter[] parameters = new SqlParameter[3];
                parameters[0] = new SqlParameter("@ComId", ComId);
                parameters[1] = new SqlParameter("@groupLCid ", groupLCid);
                parameters[2] = new SqlParameter("@PIID  ", 0);

                var datasetabc = new System.Data.DataSet();
                datasetabc = Helper.ExecProcMapDS(queryname, parameters);
                var dataTable1 = datasetabc.Tables[0];

                var margin = _bBLCMainRepository.All().Where(x => x.GroupLCId == groupLCid).Sum(x => x.Tenor);

                return Json(new { data = groupLCData, datasetabc = dataTable1, sumAmount = sumAmount, margin = margin });
            }
            return Json(new { data = "" });
        }
        [HttpPost]
        [AllowAnonymous]
        public IActionResult getProformaInvoiceData(int SupplierID = 0, int ItemGroupId = 0, int GroupLCId = 0)
        {
            var ComId = HttpContext.Session.GetInt32("ComId");
            var UserId = HttpContext.Session.GetInt32("UserId");
            var queryname = "getProformaInvoiceData";
            var viewquery = $"Exec {queryname} '{ComId}','{SupplierID}','{ItemGroupId}','{GroupLCId}'";
            Console.WriteLine(viewquery);
            SqlParameter[] parameters = new SqlParameter[4];
            parameters[0] = new SqlParameter("@ComId", ComId);
            parameters[1] = new SqlParameter("@SupplierID ", SupplierID);
            parameters[2] = new SqlParameter("@ItemGroupId ", ItemGroupId);
            parameters[3] = new SqlParameter("@GroupLCId ", GroupLCId);

            var datasetabc = new System.Data.DataSet();
            datasetabc = Helper.ExecProcMapDS(queryname, parameters);

            return Json(new { data = datasetabc, ex = "" });

        }



        [HttpPost]
        [AllowAnonymous]
        public IActionResult SaveBBLC([FromBody] BBLCMain model)
        {
            try
            {
                var UserId = HttpContext.Session.GetInt32("UserId");
                var ComId = HttpContext.Session.GetInt32("ComId");

                var errors = ModelState.Where(x => x.Value.Errors.Any())
                .Select(x => new { x.Key, x.Value.Errors });

                var lctype = _CommercialLCTypeRepository.All().Where(x => x.CommercialLCTypeShortName == "BBLC").FirstOrDefault().Id;
                if (ModelState.IsValid)
                {
                    if (model.Id > 0)
                    {
                        model.LCTypeId = lctype;
                        _bBLCMainRepository.Update(model, model.Id);

                        var previousitem = _bBLCDetailsRepository.All().Where(x => x.BBLCMainId == model.Id).ToList();
                        var tmp = previousitem.Where(x => !model.BBLC_Details.Any(z => x.Id == z.Id)).ToList();
                        _bBLCDetailsRepository.RemoveRange(tmp);
                        foreach (BBLC_Details item in model.BBLC_Details)
                        {
                            if (item.Id > 0)
                            {
                                item.BBLCMainId = model.Id;
                                _bBLCDetailsRepository.Update(item, item.Id);

                            }
                            else
                            {
                                item.BBLCMainId = model.Id;
                                _bBLCDetailsRepository.Insert(item);

                            }
                        }
                        TempData["Message"] = "Data Update Successfully";
                        TempData["Status"] = "2";
                        return Json(new { error = false, message = "Updated successfully", Id = model.Id });
                    }
                    else
                    {
                        model.LCTypeId = lctype;
                        foreach (var item in model.BBLC_Details.Where(x => x.IsDelete == false))
                        {

                            item.CreateDate = DateTime.Now;
                            item.UpdateDate = DateTime.Now;
                            item.ComId = int.Parse(ComId.ToString());
                            item.LuserId = int.Parse(UserId.ToString());
                            item.BBLCMainId = model.Id;
                        }
                        _bBLCMainRepository.Insert(model);
                        TempData["Message"] = "Data Save Successfully";
                        TempData["Status"] = "1";
                        return Json(new { error = false, message = "Saved successfully", Id = model.Id });
                    }
                }
                else
                {

                    return Json(new { error = true, message = "failed to save" });
                }



            }
            catch (Exception ex)
            {

                return Json(new { error = true, message = ex.Message });
            }
        }


        [HttpGet]
        [AllowAnonymous]
        public IActionResult getBBLCData(int id = 0)
        {
            var getAllBBLC = _bBLCMainRepository.All().Where(x => x.Id == id);
            var itemDescription = _bBLCDetailsRepository.All().Where(x => x.BBLCMainId == id).ToList();

            var itemDesp = "";
            foreach (var item in itemDescription)
            {
                var proformaSub = _ProformaInvoiceSubInvoiceRepository.All().Where(x => x.PIId == item.PIId).ToList();
                foreach (var proforma in proformaSub)
                {
                    var description = itemDescriptionRepository.All().Where(x => x.Id == proforma.ItemDescId).FirstOrDefault().ItemDescName;
                    itemDesp += description + " ,\n";
                }
            }

            int lastIndex = itemDesp.LastIndexOf(',');
            string CONresult = "";
            if (lastIndex != -1)
            {
                CONresult = itemDesp.Substring(0, lastIndex) + itemDesp.Substring(lastIndex + 1).TrimEnd();
            }

            var query = getAllBBLC.Include(x => x.BBLC_Details)
                .Select(x => new
                {
                    x.Id,
                    x.ComId,
                    x.BBLCNo,
                    x.BBLCAmdNo,
                    x.UDNo,
                    x.AmdNo,
                    x.CommercialCompanyId,
                    x.ShipModeId,
                    x.GroupLCId,
                    x.TotalValue,
                    x.PaymentTerm,
                    x.PaymentTermsId,
                    x.DayListId,
                    x.DecreaseValue,
                    x.NetValue,
                    x.SecondaryQty,
                    x.GroupLCAverage,
                    x.DayListTermId,
                    x.Insurance,
                    x.Remarks,
                    x.CurrencyId,
                    x.PortOfLoadingId,
                    x.PortOfDischargeId,
                    x.Percentage,
                    x.OpeningBankId,
                    x.Tenor,
                    x.LienBankId,
                    x.TradeTermId,
                    x.ForwarderId,
                    DescriptionString = CONresult,
                    LcOpeningDate = x.LcOpeningDate != null ? x.LcOpeningDate.Value.ToString("dd-MMM-yyyy") : null,
                    ExpiryDate = x.ExpiryDate != null ? x.ExpiryDate.Value.ToString("dd-MMM-yyyy") : null,
                    UDDate = x.UDDate != null ? x.UDDate.Value.ToString("dd-MMM-yyyy") : null,
                    FirstShipmentDate = x.FirstShipmentDate != null ? x.FirstShipmentDate.Value.ToString("dd-MMM-yyyy") : null,
                    LastShipmentDate = x.LastShipmentDate != null ? x.LastShipmentDate.Value.ToString("dd-MMM-yyyy") : null,
                    x.DestinationID,
                    x.ConvertRate,
                    x.BBLCValue,
                    x.BBLCQty,
                    x.Balance,
                    x.PrevBBLCValue,
                    x.IncreaseValue,
                    x.SupplierId,
                    x.ItemGroupId,
                    BBLCDetails = x.BBLC_Details.Select(y => new
                    {
                        y.Id,
                        piid = y.PIId,
                        PINo = y.COM_ProformaInvoice.PINo,
                        ImportPONo = y.COM_ProformaInvoice.ImportPONo,
                        ItemGroupName = y.COM_ProformaInvoice.ItemGroups.ItemGroupName,
                        PrimaryUnit = y.COM_ProformaInvoice.UnitMaster.UnitName,
                        SecondaryUnit = y.COM_ProformaInvoice.SecondaryUnit.UnitName,
                        SecondaryQty = y.COM_ProformaInvoice.CartonRollQty,
                        //ItemDescName = y.COM_ProformaInvoice.ItemDescs.ItemDescName,
                        ImportQty = y.COM_ProformaInvoice.ImportQty,
                        ImportRate = y.COM_ProformaInvoice.ImportRate,
                        TotalValue = y.COM_ProformaInvoice.TotalValue,
                        ItemDescName = CONresult,
                        y.BBLCMainId,
                        y.ComId
                    })
                }).FirstOrDefault();
            return Json(query);
        }

        [AllowAnonymous]
        public JsonResult BBLCSearch(string query)
        {

            var bblcResults = _bBLCMainRepository.All()
                .Where(x => x.BBLCNo.ToLower().Contains(query.ToLower()))
                .Select(p => new
                {
                    Id = p.Id,
                    BBLCNo = p.BBLCNo,
                })
                .Take(10)
                .ToList();

            var ciResults = importCIMasterRepository.All()
                .Where(x => x.CICode.ToLower().Contains(query.ToLower()))
                .Select(p => new
                {
                    Id = p.Id,
                    BBLCNo = p.CICode + "_CI",
                })
                .Take(10)
                .ToList();

            // Combine both results
            var combinedResults = bblcResults.Concat(ciResults).ToList();

            return Json(combinedResults);
        }


        [AllowAnonymous]
        public JsonResult GetBBLCList(string fromDate = "", string toDate = "", int supplierid = 0, int concernid = 0, int page = 1, decimal size = 5, string searchquery = "", string dropdownSearch = "")
        {
            try
            {
                var CurrentUserId = HttpContext.Session.GetInt32("UserId");
                var ComId = HttpContext.Session.GetInt32("ComId");
                var purchaselist = _bBLCMainRepository.All();
                if (concernid > 0)
                {
                    purchaselist = _bBLCMainRepository.All().Where(x => x.CommercialCompanyId == concernid);
                }
                if (supplierid > 0)
                {
                    purchaselist = _bBLCMainRepository.All().Where(x => x.SupplierId == supplierid);
                }
                if (!string.IsNullOrEmpty(fromDate))
                {
                    DateTime fromDateValue = Convert.ToDateTime(fromDate);
                    purchaselist = _bBLCMainRepository.All().Where(x => x.LcOpeningDate >= fromDateValue.Date);
                }
                if (!string.IsNullOrEmpty(toDate))
                {
                    DateTime toDateValue = Convert.ToDateTime(toDate);
                    purchaselist = _bBLCMainRepository.All().Where(x => x.ExpiryDate >= toDateValue.Date);
                }

                if (searchquery?.Length > 1)
                {
                    purchaselist = purchaselist.Where(x =>
                        x.BBLCNo.ToLower().Contains(searchquery.ToLower()) ||
                        x.BBLCAmdNo.ToLower().Contains(searchquery.ToLower()) ||
                        x.BBLC_Details.FirstOrDefault().COM_ProformaInvoice.PINo.ToLower().Contains(searchquery.ToLower()) ||
                        x.SupplierInformation.SupplierName.ToLower().Contains(searchquery.ToLower())
                    );

                }

                if ((dropdownSearch.Length > 1) || (dropdownSearch == ""))
                {
                    purchaselist = purchaselist.Where(x => x.BBLCNo.ToLower().Contains(dropdownSearch.ToLower()));
                }


                decimal TotalRecordCount = purchaselist.Count();
                var PageCountabc = decimal.Parse((TotalRecordCount / size).ToString());
                var PageCount = Math.Ceiling(PageCountabc);



                decimal skip = (page - 1) * size;
                var query = from e in purchaselist.Include(x => x.BBLC_Details).Include(x => x.SupplierInformation).Include(x => x.CompanyList).Include(x => x.COM_GroupLC_Main)
                            select new
                            {
                                Id = e.Id,
                                e.ComId,
                                e.BBLCNo,
                                e.BBLCAmdNo,
                                e.SupplierId,
                                bblcCompanyName = e.Company.CompanyName,
                                e.SupplierInformation.SupplierName,
                                bblcPINo = e.BBLC_Details.FirstOrDefault().COM_ProformaInvoice.PINo,
                                e.COM_GroupLC_Main.GroupLCRefName,
                                e.BBLCQty,
                                e.BBLCValue,
                                e.LcOpeningDate,
                                e.Destination.DestinationName,
                                e.Currency.CurrencyName,
                                e.PortOfLoading.PortOfLoadingName,
                                e.ShipMode.ShipModeName,
                                e.Tenor,
                                e.PaymentTermss.PaymentTermsName,
                                e.ExpiryDate,
                                e.FirstShipmentDate,
                                e.LastShipmentDate,
                                e.ConvertRate,
                                e.Balance,
                                e.Insurance,
                                e.UDNo,
                                e.UDDate,
                                e.AmdNo,
                            };
                var abcd = query.OrderByDescending(x => x.Id).Skip(int.Parse(skip.ToString())).Take(int.Parse(size.ToString())).ToList();// Take(50);
                var pageinfo = new PagingInfo();
                pageinfo.PageCount = int.Parse(PageCount.ToString());
                pageinfo.PageNo = page;
                pageinfo.PageSize = int.Parse(size.ToString());
                pageinfo.TotalRecordCount = int.Parse(TotalRecordCount.ToString());
                return Json(new { Success = 1, error = false, data = abcd, page = page, size = size, last_page = pageinfo.PageCount, total = pageinfo.TotalRecordCount });
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        [AllowAnonymous]
        public JsonResult GetBBLCList1(string fromDate = "", string toDate = "", int supplierid = 0, int concernid = 0, int userId = 0, int page = 1, decimal size = 5, string searchquery = "", string dropdownSearch = "")
        {
            try
            {
                var CurrentUserId = HttpContext.Session.GetInt32("UserId");
                var ComId = HttpContext.Session.GetInt32("ComId");
                DateTime fromDateValue = Convert.ToDateTime(fromDate);
                DateTime toDateValue = Convert.ToDateTime(toDate);
                var lctypeId = _CommercialLCTypeRepository.All().Where(x => x.CommercialLCTypeShortName == "BBLC").FirstOrDefault().Id;
                var purchaselist = _bBLCMainRepository.All().Where(x => x.IsDelete == false && x.LCTypeId == lctypeId);

                //if (!string.IsNullOrEmpty(fromDate))
                //{
                //    DateTime fromDateValue = Convert.ToDateTime(fromDate);
                //    purchaselist = _bBLCMainRepository.All().Where(x => x.LcOpeningDate >= fromDateValue.Date);
                //}
                //if (!string.IsNullOrEmpty(toDate))
                //{
                //    DateTime toDateValue = Convert.ToDateTime(toDate);
                //    purchaselist = _bBLCMainRepository.All().Where(x => x.ExpiryDate <= toDateValue.Date);
                //}


                var taburesquest = JsonConvert.DeserializeObject<TabulatorRequest>(searchquery);

                if (taburesquest.Filter.Count == 0)
                {
                    purchaselist = purchaselist.Where(x => x.LcOpeningDate >= fromDateValue.Date && x.LcOpeningDate <= toDateValue.Date);

                }

                foreach (var item in taburesquest.Filter)
                {
                    if (item.Field == "BBLCNo")
                    {
                        purchaselist = purchaselist.Where(x => x.BBLCNo.ToLower().Contains(item.Value.ToLower()));
                    }

                    if (item.Field == "BBLCAmdNo")
                    {
                        purchaselist = purchaselist.Where(x => x.BBLCAmdNo.ToLower().Contains(item.Value.ToLower()));
                    }
                    if (item.Field == "ItemGroupName1")
                    {
                        purchaselist = purchaselist.Where(x => x.ItemGroups.ItemGroupName.ToLower().Contains(item.Value.ToLower()));
                    }
                    if (item.Field == "bblcPINo")
                    {
                        purchaselist = purchaselist.Where(x => x.BBLC_Details.FirstOrDefault().COM_ProformaInvoice.PINo.ToLower().Contains(item.Value.ToLower()));
                    }
                    if (item.Field == "bblcCompanyName")
                    {
                        purchaselist = purchaselist.Where(x => x.Company.CompanyName.ToLower().Contains(item.Value.ToLower()));
                    }
                    if (item.Field == "SupplierName1")
                    {
                        purchaselist = purchaselist.Where(x => x.SupplierInformation.SupplierName.ToLower().Contains(item.Value.ToLower()));
                    }

                    if (item.Field == "GroupLCRefName1")
                    {
                        purchaselist = purchaselist.Where(x => x.COM_GroupLC_Main.GroupLCRefName.ToLower().Contains(item.Value.ToLower()));
                    }

                    if (item.Field == "BBLCQty")
                    {
                        purchaselist = purchaselist.Where(x => x.BBLCQty.ToString().ToLower().Contains(item.Value.ToLower()));
                    }

                    if (item.Field == "BBLCValue")
                    {
                        purchaselist = purchaselist.Where(x => x.BBLCValue.ToString().ToLower().Contains(item.Value.ToLower()));
                    }
                    if (item.Field == "CurrencyName")
                    {
                        purchaselist = purchaselist.Where(x => x.Currency.CurrencyName.ToLower().Contains(item.Value.ToLower()));
                    }
                    if (item.Field == "DestinationName")
                    {
                        purchaselist = purchaselist.Where(x => x.Destination.DestinationName.ToLower().Contains(item.Value.ToLower()));
                    }
                    if (item.Field == "PortOfLoadingName")
                    {
                        purchaselist = purchaselist.Where(x => x.PortOfLoading.PortOfLoadingName.ToLower().Contains(item.Value.ToLower()));
                    }
                    if (item.Field == "ShipModeName")
                    {
                        purchaselist = purchaselist.Where(x => x.ShipMode.ShipModeName.ToLower().Contains(item.Value.ToLower()));
                    }
                    if (item.Field == "Tenor")
                    {
                        purchaselist = purchaselist.Where(x => x.Tenor.ToString().ToLower().Contains(item.Value.ToLower()));
                    }
                    if (item.Field == "PaymentTermsName")
                    {
                        purchaselist = purchaselist.Where(x => x.PaymentTermss.PaymentTermsName.ToLower().Contains(item.Value.ToLower()));
                    }
                    if (item.Field == "ConvertRate")
                    {
                        purchaselist = purchaselist.Where(x => x.ConvertRate.ToString().ToLower().Contains(item.Value.ToLower()));
                    }
                    if (item.Field == "Balance")
                    {
                        purchaselist = purchaselist.Where(x => x.Balance.ToString().ToLower().Contains(item.Value.ToLower()));
                    }
                    if (item.Field == "Insurance")
                    {
                        purchaselist = purchaselist.Where(x => x.Insurance.ToLower().Contains(item.Value.ToLower()));
                    }
                    if (item.Field == "UDNo")
                    {
                        purchaselist = purchaselist.Where(x => x.UDNo.ToLower().Contains(item.Value.ToLower()));
                    }
                    if (item.Field == "AmdNo")
                    {
                        purchaselist = purchaselist.Where(x => x.AmdNo.ToLower().Contains(item.Value.ToLower()));
                    }


                }

                if (concernid > 0)
                {
                    purchaselist = _bBLCMainRepository.All().Where(x => x.CommercialCompanyId == concernid && x.IsDelete == false && x.LCTypeId == lctypeId);
                }
                if (supplierid > 0)
                {
                    purchaselist = _bBLCMainRepository.All().Where(x => x.SupplierId == supplierid && x.IsDelete == false && x.LCTypeId == lctypeId);
                }

                if (userId > 0)
                {
                    purchaselist = _bBLCMainRepository.All().Where(x => x.LuserId == userId && x.IsDelete == false && x.LCTypeId == lctypeId);
                }

                if ((dropdownSearch.Length > 1) || (dropdownSearch == ""))
                {
                    purchaselist = purchaselist.Where(x => x.BBLCNo.ToLower().Contains(dropdownSearch.ToLower()));
                }


                decimal TotalRecordCount = purchaselist.Count();
                var PageCountabc = decimal.Parse((TotalRecordCount / taburesquest.Size).ToString());
                var PageCount = Math.Ceiling(PageCountabc);

                int skip = (taburesquest.Page - 1) * taburesquest.Size;

                var query = from e in purchaselist.Include(x => x.BBLC_Details).Include(x => x.SupplierInformation).Include(x => x.CompanyList).Include(x => x.COM_GroupLC_Main)
                            select new
                            {
                                Id = e.Id,
                                e.ComId,
                                e.BBLCNo,
                                e.BBLCAmdNo,
                                ItemGroupName1 = e.ItemGroups.ItemGroupName,
                                e.SupplierId,
                                bblcCompanyName = e.Company.CompanyName,
                                SupplierName1 = e.SupplierInformation.SupplierName,
                                bblcPINo = e.BBLC_Details.FirstOrDefault().COM_ProformaInvoice.PINo,
                                GroupLCRefName1 = e.COM_GroupLC_Main.GroupLCRefName,
                                e.BBLCQty,
                                e.BBLCValue,
                                e.LcOpeningDate,
                                e.Destination.DestinationName,
                                e.Currency.CurrencyName,
                                e.PortOfLoading.PortOfLoadingName,
                                e.ShipMode.ShipModeName,
                                e.Tenor,
                                e.PaymentTermss.PaymentTermsName,
                                e.ExpiryDate,
                                e.FirstShipmentDate,
                                e.LastShipmentDate,
                                e.ConvertRate,
                                e.Balance,
                                e.Insurance,
                                e.UDNo,
                                e.UDDate,
                                e.AmdNo,
                            };
                var abcd = query.OrderByDescending(x => x.Id).Skip(skip).Take(taburesquest.Size).ToList();
                var pageinfo = new PagingInfo();
                pageinfo.PageCount = int.Parse(PageCount.ToString());
                pageinfo.PageNo = taburesquest.Page;
                pageinfo.PageSize = taburesquest.Size;
                pageinfo.TotalRecordCount = int.Parse(TotalRecordCount.ToString());

                //return  abcd;
                return Json(new { Success = 1, error = false, data = abcd, page = taburesquest.Page, size = taburesquest.Size, last_page = pageinfo.PageCount, total = pageinfo.TotalRecordCount });

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        [AllowAnonymous]
        public JsonResult GetBBLCList2(string fromDate = "", string toDate = "", int LCTypesId = 0, int supplierid = 0, int concernid = 0, int userId = 0, int page = 1, decimal size = 5, string searchquery = "", string dropdownSearch = "")
        {
            try
            {
                var CurrentUserId = HttpContext.Session.GetInt32("UserId");
                var ComId = HttpContext.Session.GetInt32("ComId");
                DateTime fromDateValue = Convert.ToDateTime(fromDate);
                DateTime toDateValue = Convert.ToDateTime(toDate);
                var lctypeId = _CommercialLCTypeRepository.All().Where(x => x.CommercialLCTypeShortName == "REGULAR LC").FirstOrDefault().Id;
                var purchaselist = _bBLCMainRepository.All().Where(x => x.IsDelete == false && x.LCTypeId == lctypeId);


                //if (!string.IsNullOrEmpty(fromDate))
                //{
                //    DateTime fromDateValue = Convert.ToDateTime(fromDate);
                //    purchaselist = purchaselist.Where(x => x.LcOpeningDate >= fromDateValue.Date);
                //}
                //if (!string.IsNullOrEmpty(toDate))
                //{
                //    DateTime toDateValue = Convert.ToDateTime(toDate);
                //    purchaselist = purchaselist.Where(x => x.ExpiryDate <= toDateValue.Date);
                //}

                var taburesquest = JsonConvert.DeserializeObject<TabulatorRequest>(searchquery);

                if (taburesquest.Filter.Count == 0)
                {
                    purchaselist = purchaselist.Where(x => x.LcOpeningDate >= fromDateValue.Date && x.LcOpeningDate <= toDateValue.Date);

                }


                foreach (var item in taburesquest.Filter)
                {
                    if (item.Field == "BBLCNo")
                    {
                        purchaselist = purchaselist.Where(x => x.BBLCNo.ToLower().Contains(item.Value.ToLower()));
                    }

                    if (item.Field == "BBLCAmdNo")
                    {
                        purchaselist = purchaselist.Where(x => x.BBLCAmdNo.ToLower().Contains(item.Value.ToLower()));
                    }
                    if (item.Field == "ItemGroupName")
                    {
                        purchaselist = purchaselist.Where(x => x.ItemGroups.ItemGroupName.ToLower().Contains(item.Value.ToLower()));
                    }
                    if (item.Field == "bblcPINo")
                    {
                        purchaselist = purchaselist.Where(x => x.BBLC_Details.FirstOrDefault().COM_ProformaInvoice.PINo.ToLower().Contains(item.Value.ToLower()));
                    }
                    if (item.Field == "bblcCompanyName")
                    {
                        purchaselist = purchaselist.Where(x => x.Company.CompanyName.ToLower().Contains(item.Value.ToLower()));
                    }
                    if (item.Field == "SupplierName")
                    {
                        purchaselist = purchaselist.Where(x => x.SupplierInformation.SupplierName.ToLower().Contains(item.Value.ToLower()));
                    }

                    if (item.Field == "GroupLCRefName")
                    {
                        purchaselist = purchaselist.Where(x => x.COM_GroupLC_Main.GroupLCRefName.ToLower().Contains(item.Value.ToLower()));
                    }

                    if (item.Field == "BBLCQty")
                    {
                        purchaselist = purchaselist.Where(x => x.BBLCQty.ToString().ToLower().Contains(item.Value.ToLower()));
                    }

                    if (item.Field == "BBLCValue")
                    {
                        purchaselist = purchaselist.Where(x => x.BBLCValue.ToString().ToLower().Contains(item.Value.ToLower()));
                    }
                    if (item.Field == "CurrencyName")
                    {
                        purchaselist = purchaselist.Where(x => x.Currency.CurrencyName.ToLower().Contains(item.Value.ToLower()));
                    }
                    if (item.Field == "DestinationName")
                    {
                        purchaselist = purchaselist.Where(x => x.Destination.DestinationName.ToLower().Contains(item.Value.ToLower()));
                    }
                    if (item.Field == "PortOfLoadingName")
                    {
                        purchaselist = purchaselist.Where(x => x.PortOfLoading.PortOfLoadingName.ToLower().Contains(item.Value.ToLower()));
                    }
                    if (item.Field == "ShipModeName")
                    {
                        purchaselist = purchaselist.Where(x => x.ShipMode.ShipModeName.ToLower().Contains(item.Value.ToLower()));
                    }
                    if (item.Field == "Tenor")
                    {
                        purchaselist = purchaselist.Where(x => x.Tenor.ToString().ToLower().Contains(item.Value.ToLower()));
                    }
                    if (item.Field == "PaymentTermsName")
                    {
                        purchaselist = purchaselist.Where(x => x.PaymentTermss.PaymentTermsName.ToLower().Contains(item.Value.ToLower()));
                    }
                    if (item.Field == "ConvertRate")
                    {
                        purchaselist = purchaselist.Where(x => x.ConvertRate.ToString().ToLower().Contains(item.Value.ToLower()));
                    }
                    if (item.Field == "Balance")
                    {
                        purchaselist = purchaselist.Where(x => x.Balance.ToString().ToLower().Contains(item.Value.ToLower()));
                    }
                    if (item.Field == "Insurance")
                    {
                        purchaselist = purchaselist.Where(x => x.Insurance.ToLower().Contains(item.Value.ToLower()));
                    }
                    if (item.Field == "UDNo")
                    {
                        purchaselist = purchaselist.Where(x => x.UDNo.ToLower().Contains(item.Value.ToLower()));
                    }
                    if (item.Field == "AmdNo")
                    {
                        purchaselist = purchaselist.Where(x => x.AmdNo.ToLower().Contains(item.Value.ToLower()));
                    }


                }

                if (concernid > 0)
                {
                    purchaselist = _bBLCMainRepository.All().Where(x => x.CommercialCompanyId == concernid && x.IsDelete == false && x.LCTypeId == lctypeId);
                }
                if (supplierid > 0)
                {
                    purchaselist = _bBLCMainRepository.All().Where(x => x.SupplierId == supplierid && x.IsDelete == false && x.LCTypeId == lctypeId);
                }

                if (userId > 0)
                {
                    purchaselist = _bBLCMainRepository.All().Where(x => x.LuserId == userId && x.IsDelete == false && x.LCTypeId == lctypeId);
                }

                if (LCTypesId > 0)
                {
                    purchaselist = _bBLCMainRepository.All().Where(x => x.ItemGroupId == LCTypesId && x.IsDelete == false && x.LCTypeId == lctypeId);
                }

                if ((dropdownSearch.Length > 1) || (dropdownSearch == ""))
                {
                    purchaselist = purchaselist.Where(x => x.BBLCNo.ToLower().Contains(dropdownSearch.ToLower()));
                }


                decimal TotalRecordCount = purchaselist.Count();
                var PageCountabc = decimal.Parse((TotalRecordCount / taburesquest.Size).ToString());
                var PageCount = Math.Ceiling(PageCountabc);

                int skip = (taburesquest.Page - 1) * taburesquest.Size;

                var query = from e in purchaselist.Include(x => x.BBLC_Details).Include(x => x.SupplierInformation).Include(x => x.CompanyList).Include(x => x.COM_GroupLC_Main)
                            select new
                            {
                                Id = e.Id,
                                e.ComId,
                                e.BBLCNo,
                                e.BBLCAmdNo,
                                ItemGroupName = e.ItemGroups.ItemGroupName,
                                e.SupplierId,
                                bblcCompanyName = e.Company.CompanyName,
                                e.SupplierInformation.SupplierName,
                                bblcPINo = e.BBLC_Details.FirstOrDefault().COM_ProformaInvoice.PINo,
                                e.COM_GroupLC_Main.GroupLCRefName,
                                e.BBLCQty,
                                e.BBLCValue,
                                e.LcOpeningDate,
                                e.Destination.DestinationName,
                                e.Currency.CurrencyName,
                                e.PortOfLoading.PortOfLoadingName,
                                e.ShipMode.ShipModeName,
                                e.Tenor,
                                e.PaymentTermss.PaymentTermsName,
                                e.ExpiryDate,
                                e.FirstShipmentDate,
                                e.LastShipmentDate,
                                e.ConvertRate,
                                e.Balance,
                                e.Insurance,
                                e.UDNo,
                                e.UDDate,
                                e.AmdNo,
                            };
                var abcd = query.OrderByDescending(x => x.Id).Skip(skip).Take(taburesquest.Size).ToList();
                var pageinfo = new PagingInfo();
                pageinfo.PageCount = int.Parse(PageCount.ToString());
                pageinfo.PageNo = taburesquest.Page;
                pageinfo.PageSize = taburesquest.Size;
                pageinfo.TotalRecordCount = int.Parse(TotalRecordCount.ToString());

                //return  abcd;
                return Json(new { Success = 1, error = false, data = abcd, page = taburesquest.Page, size = taburesquest.Size, last_page = pageinfo.PageCount, total = pageinfo.TotalRecordCount });

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        [OverridableAuthorize]
        public JsonResult DeleteBBLC(int id)
        {
            try
            {


                var model = _bBLCMainRepository.Find(id);
                var modelSub = _bBLCDetailsRepository.All().Where(x => x.BBLCMainId == model.Id).ToList();

                if (model != null)
                {

                    _bBLCDetailsRepository.RemoveRange(modelSub);
                    _bBLCMainRepository.Delete(model);

                    return Json(new { success = "1", msg = "Deleted Successfully" });
                }
                return Json(new { success = "0", msg = "No items found to delete." });

            }
            catch (Exception ex)
            {
                return Json(new { success = "0", msg = "No items found to delete." }); //msg = ex.ToString()
                throw ex;
            }
        }

        [OverridableAuthorize]
        public JsonResult DeleteRBBLC(int id)
        {
            try
            {


                var model = _bBLCMainRepository.Find(id);
                var modelSub = _bBLCDetailsRepository.All().Where(x => x.BBLCMainId == model.Id).ToList();

                if (model != null)
                {

                    _bBLCDetailsRepository.RemoveRange(modelSub);
                    _bBLCMainRepository.Delete(model);

                    return Json(new { success = "1", msg = "Deleted Successfully" });
                }
                return Json(new { success = "0", msg = "No items found to delete." });

            }
            catch (Exception ex)
            {
                return Json(new { success = "0", msg = "No items found to delete." }); //msg = ex.ToString()
                throw ex;
            }
        }

        [AllowAnonymous]
        public IActionResult shipModeDrodpdown()
        {
            var dropdown = shipModeRepository.GetAllForDropDown();
            return Json(dropdown);
        }
        [AllowAnonymous]
        public IActionResult incoTermDrodpdown()
        {
            var dropdown = incoTermRepository.GetAllForDropDown();
            return Json(dropdown);
        }
        [AllowAnonymous]
        public IActionResult dayTermDescDrodpdown()
        {
            var dropdown = dayListTermRepository.GetAllForDropDown();
            return Json(dropdown);
        }
        [AllowAnonymous]
        public IActionResult destinationnDrodpdown()
        {
            var dropdown = destinationRepository.GetAllForDropDown();
            return Json(dropdown);
        }

        [AllowAnonymous]
        public JsonResult GetGroupLC()
        {
            var ComId = HttpContext.Session.GetInt32("ComId");

            var groupLC = groupLCMainRepository.GetAllForDropDown();
            return Json(groupLC);
        }

        [AllowAnonymous]
        public JsonResult GetItemGroup()
        {
            var ComId = HttpContext.Session.GetInt32("ComId");

            var itemgroup = itemGroupRepository.GetAllForDropDown();
            return Json(itemgroup);
        }

        [AllowAnonymous]
        public JsonResult GetSalesContract()
        {
            var ComId = HttpContext.Session.GetInt32("ComId");

            var itemgroup = _masterLCRepository.GetAllForDropDown();
            return Json(itemgroup);
        }

        [AllowAnonymous]
        public JsonResult upgradeSalesContract(int id)
        {
            var ComId = HttpContext.Session.GetInt32("ComId");

            var groupLC = groupLCSubRepository.All().Where(x => x.GroupLCId == id).Include(x => x.MasterLC).Select(x => new SelectListItem
            {
                Text = x.MasterLC.LCRefNo,
                Value = x.Id.ToString()
            }).ToList();

            var proformaInvoice = proformaInvoiceRepository.All().Where(x => x.GroupLCId == id).Select(
                x => new SelectListItem
                {
                    Text = x.PINo,
                    Value = x.Id.ToString()
                }).ToList();
            return Json(new { success = "1", groupLC = groupLC, proformaInvoice = proformaInvoice });
        }

        [AllowAnonymous]
        public JsonResult upgradeProformaInvoice(int id)
        {

            var proformaInvoice = proformaInvoiceRepository.All().Where(x => x.ItemGroupId == id).Select(
                x => new SelectListItem
                {
                    Text = x.PINo,
                    Value = x.Id.ToString()
                }).ToList();
            return Json(new { success = "1", proformaInvoice = proformaInvoice });
        }



        [AllowAnonymous]
        [HttpPost, ActionName("SetSession")]
        public IActionResult SetSession(string reporttype, string action, int? reportid, int? ciid, string refno, string printdate, string truckno, string drivername, string drivermobileno, int? grouplcid, string multipleproformainvoice, string Percentage, string multiplemasterlc)
        {
            try
            {
                var comid = HttpContext.Session.GetInt32("ComId");
                var userid = HttpContext.Session.GetInt32("Userid");

                HttpContext.Session.SetString("ReportType", reporttype);
                HttpContext.Session.SetString("MultiSelectData", multipleproformainvoice ?? "");
                HttpContext.Session.SetString("MultiSelectDataMasterLC", multiplemasterlc ?? "");
                HttpContext.Session.SetString("GroupLCId", grouplcid.ToString() ?? "");
                HttpContext.Session.SetString("RefNo", refno ?? "");
                HttpContext.Session.SetString("PrintDate", printdate ?? DateTime.Now.Date.ToString("dd-MMM-yy"));
                HttpContext.Session.SetString("Percentage", Percentage ?? "");
                HttpContext.Session.SetString("TruckNo", truckno ?? "");
                HttpContext.Session.SetString("DriverName", drivername ?? "");
                HttpContext.Session.SetString("DriverMobileNo", drivermobileno ?? "");



                if (truckno != null || truckno != "")
                {

                    TruckInfo abc = new TruckInfo();
                    abc.TruckNo = truckno;
                    abc.DriverName = drivername;
                    abc.MobileNo = drivermobileno;
                    abc.ComId = int.Parse(comid.ToString());
                    abc.LuserId = userid ?? 0;

                    abc.CreateDate = DateTime.Now;
                    abc.PrintDate = printdate;
                    abc.Percentage = Percentage;

                    abc.RefNo = refno;
                    abc.LCId = reportid;
                    abc.ReportName = action;

                    abc.GroupLcId = grouplcid;
                    abc.PINo = multipleproformainvoice;
                    abc.MasterLC = multiplemasterlc;



                    _TruckInfoRepository.Insert(abc);
                }


                string redirectUrl = "";
                if (action == "PrintBBLCOpen" || action == "PrintRegularLCOpen" || action == "PrintFTT" || action == "PrintFDD" || action == "PrintCityBankLetter" || action == "PrintUCBLBankLetter" || action == "PrintShahjalalBankLetter" || action == "PrintABBankLetter")
                {
                    redirectUrl = Url.Action(action, "Variable", new { id = grouplcid, type = reporttype, multiselectData = multipleproformainvoice, refno = refno, percentage = Percentage, multiSelectDataMasterLC = multiplemasterlc });

                }
                else if (action == "PrintCI")
                {
                    redirectUrl = Url.Action(action, "Variable", new { id = reportid, type = reporttype, refno = refno, ciid = ciid });
                }
                else
                {
                    redirectUrl = Url.Action(action, "Variable", new { id = reportid, type = reporttype, refno = refno, ciid = ciid });
                }


                return Redirect(redirectUrl);

            }

            catch (Exception ex)
            {
                return Json(new { Success = 0, ex = ex.InnerException.InnerException.Message.ToString() });
            }

            return Json(new { Success = 0, ex = new Exception("Unable to Delete").Message.ToString() });

        }

        [AllowAnonymous]
        public ActionResult PrintBBLCOpen(int? id, string type, string multiselectData, int refno, int percentage, string multiSelectDataMasterLC)
        {
            try
            {
                clsReport.rptList = null;

                HttpContext.Session.SetString("ReportPath", "~/ReportViewer/CommercialReport/rptOpenBBLBank.rdlc");

                //var multiselectData = HttpContext.Session.GetInt32("MultiSelectData");
                var comid = HttpContext.Session.GetInt32("ComId");
                //var refno = HttpContext.Session.GetInt32("RefNo");
                var printDate = DateTime.Parse(HttpContext.Session.GetString("PrintDate"));
                //var percentage = HttpContext.Session.GetInt32("Percentage");
                //var multiSelectDataMasterLC = HttpContext.Session.GetInt32("MultiSelectDataMasterLC");

                HttpContext.Session.SetString("ReportQuery", "Exec rptBBLCOpen_Import '" + multiselectData + "', '" + comid + "' ,'" + refno + "' ,'" + printDate + "','" + percentage + "','" + multiSelectDataMasterLC + "'");

                var filename = "ABCD";
                HttpContext.Session.SetString("PrintFileName", filename.Replace(".", "").Replace(" ", "").Replace(",", "").Replace("\"", ""));


                string DataSourceName = "DataSet1";
                clsReport.strReportPathMain = HttpContext.Session.GetString("ReportPath");
                clsReport.strQueryMain = HttpContext.Session.GetString("ReportQuery");
                clsReport.strDSNMain = DataSourceName;

                string callBackUrl = this.Url.Action("Index", "ReportViewer", new { reporttype = type });
                var redirectUrl = callBackUrl;


                return Json(new { Url = redirectUrl });

            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        [AllowAnonymous]
        public ActionResult PrintCOP(int? id, string type, int refno)
        {
            try
            {
                clsReport.rptList = null;

                HttpContext.Session.SetString("ReportPath", "~/ReportViewer/CommercialReport/rptCollectionOfProceeds.rdlc");

                var comid = HttpContext.Session.GetInt32("ComId");
                var printDate = DateTime.Parse(HttpContext.Session.GetString("PrintDate"));
                HttpContext.Session.SetString("ReportQuery", "Exec rptImportDocumentsAutomation '" + id + "', '" + comid + "' ,'" + refno + "' ,'" + printDate + "'");




                string filename = _bBLCMainRepository.All().Where(x => x.Id == id).Select(x => x.BBLCNo).FirstOrDefault() + "_" + refno + "_CollectionOfProceeds";
                HttpContext.Session.SetString("PrintFileName", filename.Replace(".", "").Replace(" ", "").Replace(",", "").Replace("\"", ""));


                string DataSourceName = "DataSet1";
                clsReport.strReportPathMain = HttpContext.Session.GetString("ReportPath");
                clsReport.strQueryMain = HttpContext.Session.GetString("ReportQuery");
                clsReport.strDSNMain = DataSourceName;

                string callBackUrl = this.Url.Action("Index", "ReportViewer", new { reporttype = type });
                var redirectUrl = callBackUrl;

                return Json(new { Url = redirectUrl });
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        [AllowAnonymous]
        public ActionResult PrintFBOE(int? id, string type, int refno)
        {
            try
            {
                clsReport.rptList = null;

                HttpContext.Session.SetString("ReportPath", "~/ReportViewer/CommercialReport/rptBillOfExchange1ST.rdlc");

                var comid = HttpContext.Session.GetInt32("ComId");
                var printDate = DateTime.Parse(HttpContext.Session.GetString("PrintDate"));

                HttpContext.Session.SetString("ReportQuery", "Exec rptImportDocumentsAutomation '" + id + "', '" + comid + "' ,'" + refno + "' ,'" + printDate + "'");

                string filename = _bBLCMainRepository.All().Where(x => x.Id == id).Select(x => x.BBLCNo).FirstOrDefault() + "_" + refno + "_CollectionOfProceeds";
                HttpContext.Session.SetString("PrintFileName", filename.Replace(".", "").Replace(" ", "").Replace(",", "").Replace("\"", ""));


                string DataSourceName = "DataSet1";
                clsReport.strReportPathMain = HttpContext.Session.GetString("ReportPath");
                clsReport.strQueryMain = HttpContext.Session.GetString("ReportQuery");
                clsReport.strDSNMain = DataSourceName;

                string callBackUrl = this.Url.Action("Index", "ReportViewer", new { reporttype = type });
                var redirectUrl = callBackUrl;

                return Json(new { Url = redirectUrl });

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        [AllowAnonymous]
        public ActionResult PrintCI(int? id, string type, int refno)
        {
            try
            {
                clsReport.rptList = null;
                HttpContext.Session.SetString("ReportPath", "~/ReportViewer/CommercialReport/rptDocumentsCommercialInvoice.rdlc");

                var comid = HttpContext.Session.GetInt32("ComId");
                var printDate = HttpContext.Session.GetString("PrintDate");

                HttpContext.Session.SetString("ReportQuery", "Exec rptImportDocumentsAutomation '" + id + "', '" + comid + "' ,'" + refno + "' ,'" + printDate + "'");

                string filename = _bBLCMainRepository.All().Where(x => x.Id == id).Select(x => x.BBLCNo).FirstOrDefault() + "_" + refno + "_rptDocumentsCommercialInvoice";
                HttpContext.Session.SetString("PrintFileName", filename.Replace(".", "").Replace(" ", "").Replace(",", "").Replace("\"", ""));


                string DataSourceName = "DataSet1";
                clsReport.strReportPathMain = HttpContext.Session.GetString("ReportPath");
                clsReport.strQueryMain = HttpContext.Session.GetString("ReportQuery");
                clsReport.strDSNMain = DataSourceName;

                string callBackUrl = this.Url.Action("Index", "ReportViewer", new { reporttype = type });
                var redirectUrl = callBackUrl;

                return Json(new { Url = redirectUrl });
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }


        [AllowAnonymous]
        public ActionResult PrintCommercialInvoice(int? id, string type, int refno, int ciid)
        {
            try
            {
                clsReport.rptList = null;
                HttpContext.Session.SetString("ReportPath", "~/ReportViewer/CommercialReport/rptCommercialInvoiceCI.rdlc");

                var comid = HttpContext.Session.GetInt32("ComId");
                var printDate = HttpContext.Session.GetString("PrintDate");

                HttpContext.Session.SetString("ReportQuery", "Exec rptImportDocumentsAutomation '" + id + "', '" + comid + "' ,'" + refno + "' ,'" + printDate + "', '" + "" + "', '" + "" + "', '" + "" + "', '" + "" + "','" + ciid + "'");

                string filename = _bBLCMainRepository.All().Where(x => x.Id == id).Select(x => x.BBLCNo).FirstOrDefault() + "_" + refno + "_rptCommercialInvoiceCI";
                HttpContext.Session.SetString("PrintFileName", filename.Replace(".", "").Replace(" ", "").Replace(",", "").Replace(" ", ""));


                string DataSourceName = "DataSet1";
                clsReport.strReportPathMain = HttpContext.Session.GetString("ReportPath");
                clsReport.strQueryMain = HttpContext.Session.GetString("ReportQuery");
                clsReport.strDSNMain = DataSourceName;

                string callBackUrl = this.Url.Action("Index", "ReportViewer", new { reporttype = type });
                var redirectUrl = callBackUrl;

                return Json(new { Url = redirectUrl });
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        [AllowAnonymous]
        public ActionResult PrintSalesContract(int? id, string type, int refno)
        {
            try
            {
                clsReport.rptList = null;
                HttpContext.Session.SetString("ReportPath", "~/ReportViewer/CommercialReport/rptDocumentsSalesContract.rdlc");

                var comid = HttpContext.Session.GetInt32("ComId");
                var printDate = DateTime.Parse(HttpContext.Session.GetString("PrintDate"));

                HttpContext.Session.SetString("ReportQuery", "Exec rptImportDocumentsAutomation '" + id + "', '" + comid + "' ,'" + refno + "' ,'" + printDate + "'");

                string filename = _bBLCMainRepository.All().Where(x => x.Id == id).Select(x => x.BBLCNo).FirstOrDefault() + "_" + refno + "_CollectionOfProceeds";
                HttpContext.Session.SetString("PrintFileName", filename.Replace(".", "").Replace(" ", "").Replace(",", "").Replace("\"", ""));


                string DataSourceName = "DataSet1";
                clsReport.strReportPathMain = HttpContext.Session.GetString("ReportPath");
                clsReport.strQueryMain = HttpContext.Session.GetString("ReportQuery");
                clsReport.strDSNMain = DataSourceName;

                string callBackUrl = this.Url.Action("Index", "ReportViewer", new { reporttype = type });
                var redirectUrl = callBackUrl;

                return Json(new { Url = redirectUrl });
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        [AllowAnonymous]
        public ActionResult PrintPL(int? id, string type, int refno)
        {
            try
            {
                clsReport.rptList = null;

                HttpContext.Session.SetString("ReportPath", "~/ReportViewer/CommercialReport/rptPackingList.rdlc");

                var comid = HttpContext.Session.GetInt32("ComId");
                var printDate = DateTime.Parse(HttpContext.Session.GetString("PrintDate"));

                HttpContext.Session.SetString("ReportQuery", "Exec rptImportDocumentsAutomation '" + id + "', '" + comid + "' ,'" + refno + "' ,'" + printDate + "'");

                string filename = _bBLCMainRepository.All().Where(x => x.Id == id).Select(x => x.BBLCNo).FirstOrDefault() + "_" + refno + "_CollectionOfProceeds";
                HttpContext.Session.SetString("PrintFileName", filename.Replace(".", "").Replace(" ", "").Replace(",", "").Replace("\"", ""));


                string DataSourceName = "DataSet1";
                clsReport.strReportPathMain = HttpContext.Session.GetString("ReportPath");
                clsReport.strQueryMain = HttpContext.Session.GetString("ReportQuery");
                clsReport.strDSNMain = DataSourceName;

                string callBackUrl = this.Url.Action("Index", "ReportViewer", new { reporttype = type });
                var redirectUrl = callBackUrl;

                return Json(new { Url = redirectUrl });
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        [AllowAnonymous]
        public ActionResult PrintBC(int? id, string type, int refno)
        {
            try
            {
                clsReport.rptList = null;

                HttpContext.Session.SetString("ReportPath", "~/ReportViewer/CommercialReport/rptBenificiaryCertificate.rdlc");

                var comid = HttpContext.Session.GetInt32("ComId");
                var printDate = DateTime.Parse(HttpContext.Session.GetString("PrintDate"));

                HttpContext.Session.SetString("ReportQuery", "Exec rptImportDocumentsAutomation '" + id + "', '" + comid + "' ,'" + refno + "' ,'" + printDate + "'");

                string filename = _bBLCMainRepository.All().Where(x => x.Id == id).Select(x => x.BBLCNo).FirstOrDefault() + "_" + refno + "_CollectionOfProceeds";
                HttpContext.Session.SetString("PrintFileName", filename.Replace(".", "").Replace(" ", "").Replace(",", "").Replace("\"", ""));


                string DataSourceName = "DataSet1";
                clsReport.strReportPathMain = HttpContext.Session.GetString("ReportPath");
                clsReport.strQueryMain = HttpContext.Session.GetString("ReportQuery");
                clsReport.strDSNMain = DataSourceName;

                string callBackUrl = this.Url.Action("Index", "ReportViewer", new { reporttype = type });
                var redirectUrl = callBackUrl;

                return Json(new { Url = redirectUrl });
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        [AllowAnonymous]
        public ActionResult PrintDC(int? id, string type, int refno)
        {
            try
            {
                clsReport.rptList = null;
                HttpContext.Session.SetString("ReportPath", "~/ReportViewer/CommercialReport/rptDeliveryChallan.rdlc");

                var comid = HttpContext.Session.GetInt32("ComId");
                var printDate = DateTime.Parse(HttpContext.Session.GetString("PrintDate"));

                HttpContext.Session.SetString("ReportQuery", "Exec rptImportDocumentsAutomation '" + id + "', '" + comid + "' ,'" + refno + "' ,'" + printDate + "'");

                string filename = _bBLCMainRepository.All().Where(x => x.Id == id).Select(x => x.BBLCNo).FirstOrDefault() + "_" + refno + "_CollectionOfProceeds";
                HttpContext.Session.SetString("PrintFileName", filename.Replace(".", "").Replace(" ", "").Replace(",", "").Replace("\"", ""));


                string DataSourceName = "DataSet1";
                clsReport.strReportPathMain = HttpContext.Session.GetString("ReportPath");
                clsReport.strQueryMain = HttpContext.Session.GetString("ReportQuery");
                clsReport.strDSNMain = DataSourceName;

                string callBackUrl = this.Url.Action("Index", "ReportViewer", new { reporttype = type });
                var redirectUrl = callBackUrl;

                return Json(new { Url = redirectUrl });
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        [AllowAnonymous]
        public ActionResult PrintTC(int? id, string type, int refno)
        {
            try
            {
                clsReport.rptList = null;
                HttpContext.Session.SetString("ReportPath", "~/ReportViewer/CommercialReport/rptTruckChallan.rdlc");

                var comid = HttpContext.Session.GetInt32("ComId");
                var printDate = DateTime.Parse(HttpContext.Session.GetString("PrintDate"));
                var truckno = HttpContext.Session.GetString("TruckNo");
                var driverName = HttpContext.Session.GetString("DriverName");
                var driverMobileNo = HttpContext.Session.GetString("DriverMobileNo");
                var percentage = HttpContext.Session.GetString("Percentage");

                HttpContext.Session.SetString("ReportQuery", "Exec rptImportDocumentsAutomation '" + id + "', '" + comid + "' ,'" + refno + "' ,'" + printDate + "', '" + truckno + "', '" + driverName + "', '" + driverMobileNo + "', '" + percentage + "'");


                string filename = _bBLCMainRepository.All().Where(x => x.Id == id).Select(x => x.BBLCNo).FirstOrDefault() + "_" + refno + "_CollectionOfProceeds";
                HttpContext.Session.SetString("PrintFileName", filename.Replace(".", "").Replace(" ", "").Replace(",", "").Replace("\"", ""));


                string DataSourceName = "DataSet1";
                clsReport.strReportPathMain = HttpContext.Session.GetString("ReportPath");
                clsReport.strQueryMain = HttpContext.Session.GetString("ReportQuery");
                clsReport.strDSNMain = DataSourceName;

                string callBackUrl = this.Url.Action("Index", "ReportViewer", new { reporttype = type });
                var redirectUrl = callBackUrl;

                return Json(new { Url = redirectUrl });
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        [AllowAnonymous]
        public ActionResult PrintCOO(int? id, string type, int refno)
        {
            try
            {
                clsReport.rptList = null;

                HttpContext.Session.SetString("ReportPath", "~/ReportViewer/CommercialReport/rptCertificateOfOrigin.rdlc");

                var comid = HttpContext.Session.GetInt32("ComId");
                var printDate = DateTime.Parse(HttpContext.Session.GetString("PrintDate"));

                HttpContext.Session.SetString("ReportQuery", "Exec rptImportDocumentsAutomation '" + id + "', '" + comid + "' ,'" + refno + "' ,'" + printDate + "'");

                string filename = _bBLCMainRepository.All().Where(x => x.Id == id).Select(x => x.BBLCNo).FirstOrDefault() + "_" + refno + "_CollectionOfProceeds";
                HttpContext.Session.SetString("PrintFileName", filename.Replace(".", "").Replace(" ", "").Replace(",", "").Replace("\"", ""));


                string DataSourceName = "DataSet1";
                clsReport.strReportPathMain = HttpContext.Session.GetString("ReportPath");
                clsReport.strQueryMain = HttpContext.Session.GetString("ReportQuery");
                clsReport.strDSNMain = DataSourceName;

                string callBackUrl = this.Url.Action("Index", "ReportViewer", new { reporttype = type });
                var redirectUrl = callBackUrl;

                return Json(new { Url = redirectUrl });
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        [AllowAnonymous]
        public ActionResult PrintPSIC(int? id, string type, int refno)
        {
            try
            {
                clsReport.rptList = null;

                HttpContext.Session.SetString("ReportPath", "~/ReportViewer/CommercialReport/rptPreShipmentInspecitonCertificate.rdlc");

                var comid = HttpContext.Session.GetInt32("ComId");
                var printDate = DateTime.Parse(HttpContext.Session.GetString("PrintDate"));

                HttpContext.Session.SetString("ReportQuery", "Exec rptImportDocumentsAutomation '" + id + "', '" + comid + "' ,'" + refno + "' ,'" + printDate + "'");

                string filename = _bBLCMainRepository.All().Where(x => x.Id == id).Select(x => x.BBLCNo).FirstOrDefault() + "_" + refno + "_CollectionOfProceeds";
                HttpContext.Session.SetString("PrintFileName", filename.Replace(".", "").Replace(" ", "").Replace(",", "").Replace("\"", ""));


                string DataSourceName = "DataSet1";
                clsReport.strReportPathMain = HttpContext.Session.GetString("ReportPath");
                clsReport.strQueryMain = HttpContext.Session.GetString("ReportQuery");
                clsReport.strDSNMain = DataSourceName;

                string callBackUrl = this.Url.Action("Index", "ReportViewer", new { reporttype = type });
                var redirectUrl = callBackUrl;

                return Json(new { Url = redirectUrl });
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        [AllowAnonymous]
        public ActionResult PrintRegularLCOpen(int? id, string type, string multiselectData, int refno, int percentage, string multiSelectDataMasterLC)
        {
            try
            {
                clsReport.rptList = null;
                var comid = HttpContext.Session.GetInt32("ComId");
                var printDate = DateTime.Parse(HttpContext.Session.GetString("PrintDate"));

                HttpContext.Session.SetString("ReportPath", "~/ReportViewer/CommercialReport/rptOpenRegularLCBank.rdlc");

                HttpContext.Session.SetString("ReportQuery", "Exec rptRegularLCOpen_Import '" + multiselectData + "', '" + comid + "' ,'" + refno + "' ,'" + printDate + "','" + percentage + "','" + multiSelectDataMasterLC + "'");

                var filename = "ABCD";
                HttpContext.Session.SetString("PrintFileName", filename.Replace(".", "").Replace(" ", "").Replace(",", "").Replace("\"", ""));


                string DataSourceName = "DataSet1";
                clsReport.strReportPathMain = HttpContext.Session.GetString("ReportPath");
                clsReport.strQueryMain = HttpContext.Session.GetString("ReportQuery");
                clsReport.strDSNMain = DataSourceName;

                string callBackUrl = this.Url.Action("Index", "ReportViewer", new { reporttype = type });
                var redirectUrl = callBackUrl;


                return Json(new { Url = redirectUrl });
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        [AllowAnonymous]
        public ActionResult PrintFTT(int? id, string type, string multiselectData, int refno, int percentage, string multiSelectDataMasterLC)
        {
            try
            {
                clsReport.rptList = null;
                var comid = HttpContext.Session.GetInt32("ComId");
                var printDate = DateTime.Parse(HttpContext.Session.GetString("PrintDate"));
                var truckno = HttpContext.Session.GetString("TruckNo");
                var driverName = HttpContext.Session.GetString("DriverName");
                var driverMobileNo = HttpContext.Session.GetString("DriverMobileNo");

                HttpContext.Session.SetString("ReportPath", "~/ReportViewer/CommercialReport/rptFTTissuance.rdlc");

                HttpContext.Session.SetString("ReportQuery", "Exec rptImportDocumentsAutomationForPI '" + multiselectData + "', '" + comid + "' ,'" + refno + "' ,'" + printDate + "','" + truckno + "', '" + driverName + "','" + driverMobileNo + "','" + percentage + "','" + multiSelectDataMasterLC + "'");


                string DataSourceName = "DataSet1";
                clsReport.strReportPathMain = HttpContext.Session.GetString("ReportPath");
                clsReport.strQueryMain = HttpContext.Session.GetString("ReportQuery");
                clsReport.strDSNMain = DataSourceName;

                string callBackUrl = this.Url.Action("Index", "ReportViewer", new { reporttype = type });
                var redirectUrl = callBackUrl;


                return Json(new { Url = redirectUrl });

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        [AllowAnonymous]
        public ActionResult PrintFDD(int? id, string type, string multiselectData, int refno, int percentage, string multiSelectDataMasterLC)
        {
            try
            {
                clsReport.rptList = null;
                var comid = HttpContext.Session.GetInt32("ComId");
                var printDate = DateTime.Parse(HttpContext.Session.GetString("PrintDate"));
                var truckno = HttpContext.Session.GetString("TruckNo");
                var driverName = HttpContext.Session.GetString("DriverName");
                var driverMobileNo = HttpContext.Session.GetString("DriverMobileNo");

                HttpContext.Session.SetString("ReportPath", "~/ReportViewer/CommercialReport/rptFDDissuance.rdlc");

                HttpContext.Session.SetString("ReportQuery", "Exec rptImportDocumentsAutomationForPI '" + multiselectData + "', '" + comid + "' ,'" + refno + "' ,'" + printDate + "','" + truckno + "', '" + driverName + "','" + driverMobileNo + "','" + percentage + "','" + multiSelectDataMasterLC + "'");

                string DataSourceName = "DataSet1";
                clsReport.strReportPathMain = HttpContext.Session.GetString("ReportPath");
                clsReport.strQueryMain = HttpContext.Session.GetString("ReportQuery");
                clsReport.strDSNMain = DataSourceName;

                string callBackUrl = this.Url.Action("Index", "ReportViewer", new { reporttype = type });
                var redirectUrl = callBackUrl;


                return Json(new { Url = redirectUrl });

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        [AllowAnonymous]
        public ActionResult PrintCNFNOC(int? id, string type, int refno, int ciid)
        {
            try
            {
                clsReport.rptList = null;

                HttpContext.Session.SetString("ReportPath", "~/ReportViewer/CommercialReport/rptCNFNOC.rdlc");

                var comid = HttpContext.Session.GetInt32("ComId");
                var printDate = HttpContext.Session.GetString("PrintDate");

                HttpContext.Session.SetString("ReportQuery", "Exec rptImportDocumentsAutomation '" + id + "', '" + comid + "' ,'" + refno + "' ,'" + printDate + "', '" + "" + "', '" + "" + "', '" + "" + "', '" + "" + "','" + ciid + "'");

                string filename = _bBLCMainRepository.All().Where(x => x.Id == id).Select(x => x.BBLCNo).FirstOrDefault() + "_" + refno + "_rptCNFNOC";
                HttpContext.Session.SetString("PrintFileName", filename.Replace(".", "").Replace(" ", "").Replace(",", "").Replace(" ", ""));


                string DataSourceName = "DataSet1";
                clsReport.strReportPathMain = HttpContext.Session.GetString("ReportPath");
                clsReport.strQueryMain = HttpContext.Session.GetString("ReportQuery");
                clsReport.strDSNMain = DataSourceName;

                string callBackUrl = this.Url.Action("Index", "ReportViewer", new { reporttype = type });
                var redirectUrl = callBackUrl;

                return Json(new { Url = redirectUrl });
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        [AllowAnonymous]
        public ActionResult PrintPackingListImport(int? id, string type, int refno, int ciid)
        {
            try
            {
                clsReport.rptList = null;

                HttpContext.Session.SetString("ReportPath", "~/ReportViewer/CommercialReport/rptPackingListImport.rdlc");

                var comid = HttpContext.Session.GetInt32("ComId");
                var printDate = HttpContext.Session.GetString("PrintDate");

                HttpContext.Session.SetString("ReportQuery", "Exec rptImportDocumentsAutomation '" + id + "', '" + comid + "' ,'" + refno + "' ,'" + printDate + "', '" + "" + "', '" + "" + "', '" + "" + "', '" + "" + "','" + ciid + "'");

                string filename = _bBLCMainRepository.All().Where(x => x.Id == id).Select(x => x.BBLCNo).FirstOrDefault() + "_" + refno + "_rptPackingListImport";
                HttpContext.Session.SetString("PrintFileName", filename.Replace(".", "").Replace(" ", "").Replace(",", "").Replace(" ", ""));


                string DataSourceName = "DataSet1";
                clsReport.strReportPathMain = HttpContext.Session.GetString("ReportPath");
                clsReport.strQueryMain = HttpContext.Session.GetString("ReportQuery");
                clsReport.strDSNMain = DataSourceName;

                string callBackUrl = this.Url.Action("Index", "ReportViewer", new { reporttype = type });
                var redirectUrl = callBackUrl;

                return Json(new { Url = redirectUrl });
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }


        [AllowAnonymous]
        public ActionResult PrintDetailPackingList(int? id, string type, int refno, int ciid)
        {
            try
            {
                clsReport.rptList = null;

                HttpContext.Session.SetString("ReportPath", "~/ReportViewer/CommercialReport/rptDetailsPackingList.rdlc");

                var comid = HttpContext.Session.GetInt32("ComId");
                var printDate = HttpContext.Session.GetString("PrintDate");

                HttpContext.Session.SetString("ReportQuery", "Exec rptImportDocumentsAutomation '" + id + "', '" + comid + "' ,'" + refno + "' ,'" + printDate + "', '" + "" + "', '" + "" + "', '" + "" + "', '" + "" + "','" + ciid + "'");

                string filename = _bBLCMainRepository.All().Where(x => x.Id == id).Select(x => x.BBLCNo).FirstOrDefault() + "_" + refno + "_rptDetailsPackingList";
                HttpContext.Session.SetString("PrintFileName", filename.Replace(".", "").Replace(" ", "").Replace(",", "").Replace(" ", ""));


                string DataSourceName = "DataSet1";
                clsReport.strReportPathMain = HttpContext.Session.GetString("ReportPath");
                clsReport.strQueryMain = HttpContext.Session.GetString("ReportQuery");
                clsReport.strDSNMain = DataSourceName;

                string callBackUrl = this.Url.Action("Index", "ReportViewer", new { reporttype = type });
                var redirectUrl = callBackUrl;

                return Json(new { Url = redirectUrl });
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        [AllowAnonymous]
        public ActionResult PrintSalesContractImport(int? id, string type, int refno, int ciid)
        {
            try
            {
                clsReport.rptList = null;

                HttpContext.Session.SetString("ReportPath", "~/ReportViewer/CommercialReport/rptSalesContractImport.rdlc");

                var comid = HttpContext.Session.GetInt32("ComId");
                var printDate = HttpContext.Session.GetString("PrintDate");

                HttpContext.Session.SetString("ReportQuery", "Exec rptImportDocumentsAutomation '" + id + "', '" + comid + "' ,'" + refno + "' ,'" + printDate + "', '" + "" + "', '" + "" + "', '" + "" + "', '" + "" + "','" + ciid + "'");

                string filename = _bBLCMainRepository.All().Where(x => x.Id == id).Select(x => x.BBLCNo).FirstOrDefault() + "_" + refno + "_rptSalesContractImport";
                HttpContext.Session.SetString("PrintFileName", filename.Replace(".", "").Replace(" ", "").Replace(",", "").Replace(" ", ""));


                string DataSourceName = "DataSet1";
                clsReport.strReportPathMain = HttpContext.Session.GetString("ReportPath");
                clsReport.strQueryMain = HttpContext.Session.GetString("ReportQuery");
                clsReport.strDSNMain = DataSourceName;

                string callBackUrl = this.Url.Action("Index", "ReportViewer", new { reporttype = type });
                var redirectUrl = callBackUrl;

                return Json(new { Url = redirectUrl });
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        [AllowAnonymous]
        public ActionResult PrintRiskBond(int? id, string type, int refno, int ciid)
        {
            try
            {
                clsReport.rptList = null;

                HttpContext.Session.SetString("ReportPath", "~/ReportViewer/CommercialReport/rptRiskBond.rdlc");

                var comid = HttpContext.Session.GetInt32("ComId");
                var printDate = HttpContext.Session.GetString("PrintDate");

                HttpContext.Session.SetString("ReportQuery", "Exec rptImportDocumentsAutomation '" + id + "', '" + comid + "' ,'" + refno + "' ,'" + printDate + "', '" + "" + "', '" + "" + "', '" + "" + "', '" + "" + "','" + ciid + "'");

                string filename = _bBLCMainRepository.All().Where(x => x.Id == id).Select(x => x.BBLCNo).FirstOrDefault() + "_" + refno + "_rptRiskBond";
                HttpContext.Session.SetString("PrintFileName", filename.Replace(".", "").Replace(" ", "").Replace(",", "").Replace(" ", ""));


                string DataSourceName = "DataSet1";
                clsReport.strReportPathMain = HttpContext.Session.GetString("ReportPath");
                clsReport.strQueryMain = HttpContext.Session.GetString("ReportQuery");
                clsReport.strDSNMain = DataSourceName;

                string callBackUrl = this.Url.Action("Index", "ReportViewer", new { reporttype = type });
                var redirectUrl = callBackUrl;

                return Json(new { Url = redirectUrl });
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        [AllowAnonymous]
        public ActionResult PrintUND300(int? id, string type, int refno, int ciid)
        {
            try
            {
                clsReport.rptList = null;

                HttpContext.Session.SetString("ReportPath", "~/ReportViewer/CommercialReport/rptUND300.rdlc");

                var comid = HttpContext.Session.GetInt32("ComId");
                var printDate = HttpContext.Session.GetString("PrintDate");

                HttpContext.Session.SetString("ReportQuery", "Exec rptImportDocumentsAutomation '" + id + "', '" + comid + "' ,'" + refno + "' ,'" + printDate + "', '" + "" + "', '" + "" + "', '" + "" + "', '" + "" + "','" + ciid + "'");

                string filename = _bBLCMainRepository.All().Where(x => x.Id == id).Select(x => x.BBLCNo).FirstOrDefault() + "_" + refno + "_rptUND300";
                HttpContext.Session.SetString("PrintFileName", filename.Replace(".", "").Replace(" ", "").Replace(",", "").Replace(" ", ""));


                string DataSourceName = "DataSet1";
                clsReport.strReportPathMain = HttpContext.Session.GetString("ReportPath");
                clsReport.strQueryMain = HttpContext.Session.GetString("ReportQuery");
                clsReport.strDSNMain = DataSourceName;

                string callBackUrl = this.Url.Action("Index", "ReportViewer", new { reporttype = type });
                var redirectUrl = callBackUrl;

                return Json(new { Url = redirectUrl });
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }



        [AllowAnonymous]
        public ActionResult PrintBILLDISCOUNTING(int? id, string type, int refno)
        {
            try
            {
                clsReport.rptList = null;
                var comid = HttpContext.Session.GetInt32("ComId");
                var printDate = DateTime.Parse(HttpContext.Session.GetString("PrintDate"));
                var truckno = HttpContext.Session.GetString("TruckNo");
                var driverName = HttpContext.Session.GetString("DriverName");
                var driverMobileNo = HttpContext.Session.GetString("DriverMobileNo");
                var percentage = HttpContext.Session.GetString("Percentage");

                HttpContext.Session.SetString("ReportPath", "~/ReportViewer/CommercialReport/rptBILLDISCOUNTING.rdlc");
                HttpContext.Session.SetString("ReportQuery", "Exec rptImportDocumentsAutomation '" + id + "', '" + comid + "' ,'" + refno + "' ,'" + printDate + "', '" + truckno + "', '" + driverName + "', '" + driverMobileNo + "', '" + percentage + "'");

                string filename = _bBLCMainRepository.All().Where(x => x.Id == id).Select(x => x.BBLCNo).FirstOrDefault() + "_" + refno + "_CollectionOfProceeds";
                HttpContext.Session.SetString("PrintFileName", filename.Replace(".", "").Replace(" ", "").Replace(",", "").Replace("\"", ""));


                string DataSourceName = "DataSet1";
                clsReport.strReportPathMain = HttpContext.Session.GetString("ReportPath");
                clsReport.strQueryMain = HttpContext.Session.GetString("ReportQuery");
                clsReport.strDSNMain = DataSourceName;

                string callBackUrl = this.Url.Action("Index", "ReportViewer", new { reporttype = type });
                var redirectUrl = callBackUrl;

                return Json(new { Url = redirectUrl });

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        [AllowAnonymous]
        public ActionResult PrintAllReport(int? id, string type, int refno)
        {
            try
            {
                clsReport.rptList = null;
                var comid = HttpContext.Session.GetInt32("ComId");
                var printDate = DateTime.Parse(HttpContext.Session.GetString("PrintDate"));
                var truckno = HttpContext.Session.GetString("TruckNo");
                var driverName = HttpContext.Session.GetString("DriverName");
                var driverMobileNo = HttpContext.Session.GetString("DriverMobileNo");
                var percentage = HttpContext.Session.GetString("Percentage");

                HttpContext.Session.SetString("ReportPath", "~/ReportViewer/CommercialReport/rptAllReport.rdlc");
                HttpContext.Session.SetString("ReportQuery", "Exec rptImportDocumentsAutomation '" + id + "', '" + comid + "' ,'" + refno + "' ,'" + printDate + "', '" + truckno + "', '" + driverName + "', '" + driverMobileNo + "', '" + percentage + "'");

                string filename = _bBLCMainRepository.All().Where(x => x.Id == id).Select(x => x.BBLCNo).FirstOrDefault() + "_" + refno + "_CollectionOfProceeds";
                HttpContext.Session.SetString("PrintFileName", filename.Replace(".", "").Replace(" ", "").Replace(",", "").Replace("\"", ""));


                string DataSourceName = "DataSet1";
                clsReport.strReportPathMain = HttpContext.Session.GetString("ReportPath");
                clsReport.strQueryMain = HttpContext.Session.GetString("ReportQuery");
                clsReport.strDSNMain = DataSourceName;

                string callBackUrl = this.Url.Action("Index", "ReportViewer", new { reporttype = type });
                var redirectUrl = callBackUrl;

                return Json(new { Url = redirectUrl });

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        [AllowAnonymous]
        public ActionResult PrintCityBankLetter(int? id, string type, string multiselectData, int refno, int percentage, string multiSelectDataMasterLC)
        {
            try
            {
                clsReport.rptList = null;
                var comid = HttpContext.Session.GetInt32("ComId");
                var printDate = DateTime.Parse(HttpContext.Session.GetString("PrintDate"));

                HttpContext.Session.SetString("ReportPath", "~/ReportViewer/CommercialReport/rptCityBankLetter.rdlc");

                HttpContext.Session.SetString("ReportQuery", "Exec rptCityBankLetter '" + multiselectData + "', '" + comid + "' ,'" + refno + "' ,'" + printDate + "','" + percentage + "','" + multiSelectDataMasterLC + "'");


                string filename = "CityBankApplication";
                HttpContext.Session.SetString("PrintFileName", filename.Replace(".", "").Replace(" ", "").Replace(",", "").Replace("\"", ""));

                string DataSourceName = "DataSet1";
                clsReport.strReportPathMain = HttpContext.Session.GetString("ReportPath");
                clsReport.strQueryMain = HttpContext.Session.GetString("ReportQuery");
                clsReport.strDSNMain = DataSourceName;

                string callBackUrl = this.Url.Action("Index", "ReportViewer", new { reporttype = type });
                var redirectUrl = callBackUrl;


                return Json(new { Url = redirectUrl });
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        [AllowAnonymous]
        public ActionResult PrintUCBLBankLetter(int? id, string type, string multiselectData, int refno, int percentage, string multiSelectDataMasterLC)
        {
            try
            {
                clsReport.rptList = null;

                var comid = HttpContext.Session.GetInt32("ComId");
                var printDate = DateTime.Parse(HttpContext.Session.GetString("PrintDate"));

                HttpContext.Session.SetString("ReportPath", "~/ReportViewer/CommercialReport/rptUCBLBankLetter.rdlc");

                HttpContext.Session.SetString("ReportQuery", "Exec rptCityBankLetter '" + multiselectData + "', '" + comid + "' ,'" + refno + "' ,'" + printDate + "','" + percentage + "','" + multiSelectDataMasterLC + "'");

                string filename = "CityBankApplication";
                HttpContext.Session.SetString("PrintFileName", filename.Replace(".", "").Replace(" ", "").Replace(",", "").Replace("\"", ""));

                string DataSourceName = "DataSet1";
                clsReport.strReportPathMain = HttpContext.Session.GetString("ReportPath");
                clsReport.strQueryMain = HttpContext.Session.GetString("ReportQuery");
                clsReport.strDSNMain = DataSourceName;

                string callBackUrl = this.Url.Action("Index", "ReportViewer", new { reporttype = type });
                var redirectUrl = callBackUrl;


                return Json(new { Url = redirectUrl });
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        [AllowAnonymous]
        public ActionResult PrintShahjalalBankLetter(int? id, string type, string multiselectData, int refno, int percentage, string multiSelectDataMasterLC)
        {
            try
            {
                clsReport.rptList = null;

                var comid = HttpContext.Session.GetInt32("ComId");
                var printDate = DateTime.Parse(HttpContext.Session.GetString("PrintDate"));

                HttpContext.Session.SetString("ReportPath", "~/ReportViewer/CommercialReport/rptShahjalalBankLetter.rdlc");

                HttpContext.Session.SetString("ReportQuery", "Exec rptCityBankLetter '" + multiselectData + "', '" + comid + "' ,'" + refno + "' ,'" + printDate + "','" + percentage + "','" + multiSelectDataMasterLC + "'");

                string filename = "CityBankApplication";
                HttpContext.Session.SetString("PrintFileName", filename.Replace(".", "").Replace(" ", "").Replace(",", "").Replace("\"", ""));

                string DataSourceName = "DataSet1";
                clsReport.strReportPathMain = HttpContext.Session.GetString("ReportPath");
                clsReport.strQueryMain = HttpContext.Session.GetString("ReportQuery");
                clsReport.strDSNMain = DataSourceName;

                string callBackUrl = this.Url.Action("Index", "ReportViewer", new { reporttype = type });
                var redirectUrl = callBackUrl;


                return Json(new { Url = redirectUrl });
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        public ActionResult PrintABBankLetter(int? id, string type, string multiselectData, int refno, int percentage, string multiSelectDataMasterLC)
        {
            try
            {
                clsReport.rptList = null;

                var comid = HttpContext.Session.GetInt32("ComId");
                var printDate = DateTime.Parse(HttpContext.Session.GetString("PrintDate"));

                HttpContext.Session.SetString("ReportPath", "~/ReportViewer/CommercialReport/rptABBankLetter.rdlc");

                HttpContext.Session.SetString("ReportQuery", "Exec rptCityBankLetter '" + multiselectData + "', '" + comid + "' ,'" + refno + "' ,'" + printDate + "','" + percentage + "','" + multiSelectDataMasterLC + "'");

                string filename = "CityBankApplication";
                HttpContext.Session.SetString("PrintFileName", filename.Replace(".", "").Replace(" ", "").Replace(",", "").Replace("\"", ""));

                string DataSourceName = "DataSet1";
                clsReport.strReportPathMain = HttpContext.Session.GetString("ReportPath");
                clsReport.strQueryMain = HttpContext.Session.GetString("ReportQuery");
                clsReport.strDSNMain = DataSourceName;

                string callBackUrl = this.Url.Action("Index", "ReportViewer", new { reporttype = type });
                var redirectUrl = callBackUrl;


                return Json(new { Url = redirectUrl });
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        #endregion

        #region Regular LC
        [OverridableAuthorize]
        public IActionResult AddRegularLC(int Id = 0)
        {

            ViewBag.ActionType = "Create";
            ViewBag.BBLCID = Id;
            return View();
        }

        [OverridableAuthorize]
        public IActionResult EditRegularLC(int Id = 0)
        {

            ViewBag.ActionType = "Edit";
            ViewBag.BBLCID = Id;
            return View("AddRegularLC");
        }

        [HttpPost]
        [AllowAnonymous]
        public IActionResult SaveRegularLC([FromBody] BBLCMain model)
        {
            try
            {
                var UserId = HttpContext.Session.GetInt32("UserId");
                var ComId = HttpContext.Session.GetInt32("ComId");

                var errors = ModelState.Where(x => x.Value.Errors.Any())
                .Select(x => new { x.Key, x.Value.Errors });

                var lctype = _CommercialLCTypeRepository.All().Where(x => x.CommercialLCTypeShortName == "REGULAR LC").FirstOrDefault().Id;

                if (ModelState.IsValid)
                {
                    if (model.Id > 0)
                    {
                        model.LCTypeId = lctype;
                        _bBLCMainRepository.Update(model, model.Id);

                        var previousitem = _bBLCDetailsRepository.All().Where(x => x.BBLCMainId == model.Id).ToList();
                        var tmp = previousitem.Where(x => !model.BBLC_Details.Any(z => x.Id == z.Id)).ToList();
                        _bBLCDetailsRepository.RemoveRange(tmp);
                        foreach (BBLC_Details item in model.BBLC_Details)
                        {
                            if (item.Id > 0)
                            {
                                item.BBLCMainId = model.Id;
                                _bBLCDetailsRepository.Update(item, item.Id);

                            }
                            else
                            {
                                item.BBLCMainId = model.Id;
                                _bBLCDetailsRepository.Insert(item);

                            }
                        }
                        TempData["Message"] = "Data Update Successfully";
                        TempData["Status"] = "2";
                        return Json(new { error = false, message = "Updated successfully", Id = model.Id, Success = 1 });
                    }
                    else
                    {
                        model.LCTypeId = lctype;

                        foreach (var item in model.BBLC_Details.Where(x => x.IsDelete == false))
                        {

                            item.CreateDate = DateTime.Now;
                            item.UpdateDate = DateTime.Now;
                            item.ComId = int.Parse(ComId.ToString());
                            item.LuserId = int.Parse(UserId.ToString());
                            item.BBLCMainId = model.Id;
                        }
                        _bBLCMainRepository.Insert(model);
                        TempData["Message"] = "Data Save Successfully";
                        TempData["Status"] = "1";
                        return Json(new { error = false, message = "Saved successfully", Id = model.Id, Success = 1 });
                    }
                }
                else
                {

                    return Json(new { error = true, message = "failed to save" });
                }



            }
            catch (Exception ex)
            {

                return Json(new { error = true, message = ex.Message });
            }
        }

        #endregion





        #region import commercial invoice region

        [OverridableAuthorize]
        //public IActionResult CreateCommercialInvoice(int commercialInvoiceId = 0)
        public IActionResult AddCommercialInvoice(int commercialInvoiceId = 0)
        {

            ViewBag.ActionType = "Create";
            ViewBag.commercialInvoiceId = commercialInvoiceId;
            return View();
        }

        [OverridableAuthorize]
        public IActionResult UpdateCommercialInvoice(int commercialInvoiceId = 0)
        {

            ViewBag.ActionType = "Edit";
            ViewBag.commercialInvoiceId = commercialInvoiceId;
            return View("AddCommercialInvoice");
        }

        [HttpPost]
        [AllowAnonymous]
        public IActionResult SaveCommercialInvoice([FromBody] COM_CommercialInvoice model)
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

                        _CommercialInvoiceRepository.Update(model, model.Id);
                        TempData["Message"] = "Data Update Successfully";
                        TempData["Status"] = "2";
                        return Json(new { error = false, message = "Updated successfully", Id = model.Id });
                    }
                    else
                    {
                        _CommercialInvoiceRepository.Insert(model);
                        TempData["Message"] = "Data Save Successfully";
                        TempData["Status"] = "1";
                        return Json(new { error = false, message = "Saved successfully", Id = model.Id });
                    }
                }
                else
                {

                    return Json(new { error = true, message = "failed to save" });
                }



            }
            catch (Exception ex)
            {

                return Json(new { error = true, message = ex.Message });
            }
        }


        [HttpGet]
        [AllowAnonymous]
        public IActionResult getCommercialInvoiceData(int id = 0)
        {
            var getData = _CommercialInvoiceRepository.All().Where(x => x.Id == id);
            var query = getData
                .Select(x => new
                {
                    x.Id,
                    x.ComId,
                    x.CommercialInvoiceNo,
                    CommercialInvoiceDate = x.CommercialInvoiceDate != null ? x.CommercialInvoiceDate.Value.ToString("dd-MMM-yyyy") : null,
                    DocumentReceiptDate = x.DocumentReceiptDate != null ? x.DocumentReceiptDate.Value.ToString("dd-MMM-yyyy") : null,
                    x.CommercialCompanyID,
                    x.CommercialLCTypeId,
                    x.CurrencyId,
                    x.ItemGroupId,
                    x.ItemDescId,
                    x.UnitMasterId,
                    x.SecondaryUnitId,
                    x.BBLCId,
                    x.SupplierID,
                    x.DocumentStatusId,
                    x.BLNo,
                    BLDate = x.BLDate != null ? x.BLDate.Value.ToString("dd-MMM-yyyy") : null,
                    DocumentAssesmentDate = x.DocumentAssesmentDate != null ? x.DocumentAssesmentDate.Value.ToString("dd-MMM-yyyy") : null,
                    x.Quantity,
                    x.SecondaryQuantity,
                    x.TotalPI,
                    x.TotalValue,
                    x.ConversionRate,
                    x.BillOfEntryNo,
                    BillOfEntryDate = x.BillOfEntryDate != null ? x.BillOfEntryDate.Value.ToString("dd-MMM-yyyy") : null,
                    CustomAssesmentDate = x.CustomAssesmentDate != null ? x.CustomAssesmentDate.Value.ToString("dd-MMM-yyyy") : null,
                    VasselETADate = x.VasselETADate != null ? x.VasselETADate.Value.ToString("dd-MMM-yyyy") : null,
                    ETBDate = x.ETBDate != null ? x.ETBDate.Value.ToString("dd-MMM-yyyy") : null,
                    x.MotherVassel,
                    GoodsInhouseDate = x.GoodsInhouseDate != null ? x.GoodsInhouseDate.Value.ToString("dd-MMM-yyyy") : null,
                    x.Remarks,
                }).FirstOrDefault();
            return Json(query);
        }


        [AllowAnonymous]
        public JsonResult GetCommercialInvoiceList(string fromDate = "", string toDate = "", int supplierId = 0, int page = 1, decimal size = 5, string searchquery = "")
        {
            try
            {
                var CurrentUserId = HttpContext.Session.GetInt32("UserId");
                var ComId = HttpContext.Session.GetInt32("ComId");
                var purchaselist = _CommercialInvoiceRepository.All();
                if (supplierId > 0)
                {
                    purchaselist = _CommercialInvoiceRepository.All().Where(x => x.SupplierID == supplierId);
                }
                if (!string.IsNullOrEmpty(fromDate))
                {
                    DateTime fromDateValue = Convert.ToDateTime(fromDate);
                    purchaselist = _CommercialInvoiceRepository.All().Where(x => x.CommercialInvoiceDate >= fromDateValue.Date);
                }
                if (!string.IsNullOrEmpty(toDate))
                {
                    DateTime toDateValue = Convert.ToDateTime(toDate);
                    purchaselist = _CommercialInvoiceRepository.All().Where(x => x.DocumentReceiptDate >= toDateValue.Date);
                }

                if (searchquery?.Length > 1)
                {
                    purchaselist = purchaselist.Where(x =>
                        x.CommercialInvoiceNo.ToLower().Contains(searchquery.ToLower())
                    );

                }
                decimal TotalRecordCount = purchaselist.Count();
                var PageCountabc = decimal.Parse((TotalRecordCount / size).ToString());
                var PageCount = Math.Ceiling(PageCountabc);



                decimal skip = (page - 1) * size;
                var query = from e in purchaselist
                            select new
                            {
                                Id = e.Id,
                                e.ComId,
                                e.CommercialInvoiceNo,
                                CommercialInvoiceDate = e.CommercialInvoiceDate != null ? e.CommercialInvoiceDate.Value.ToString("dd-MMM-yyyy") : null,
                                e.CommercialLCTypes.CommercialLCTypeShortName,
                                e.COM_BBLC_Master.BBLCNo,
                                e.CommercialCompany.CompanyName,
                                e.SupplierInformations.SupplierName,
                                e.Currency.CurrencyShortName,
                                e.Quantity,
                                e.UnitMaster.UnitShortName,
                                e.TotalValue,
                                e.ItemGroups.ItemGroupName,
                                e.ItemDescs.ItemDescName,
                                e.BLNo,
                                BLDate = e.BLDate != null ? e.BLDate.Value.ToString("dd-MMM-yyyy") : null,
                                e.DocumentStatus.DocumentStatusShortName,
                                e.MotherVassel,
                                VasselETADate = e.VasselETADate != null ? e.VasselETADate.Value.ToString("dd-MMM-yyyy") : null,
                                e.BillOfEntryNo,
                                BillOfEntryDate = e.BillOfEntryDate != null ? e.BillOfEntryDate.Value.ToString("dd-MMM-yyyy") : null,
                                GoodsInhouseDate = e.GoodsInhouseDate != null ? e.GoodsInhouseDate.Value.ToString("dd-MMM-yyyy") : null,
                            };
                var abcd = query.OrderByDescending(x => x.Id).Skip(int.Parse(skip.ToString())).Take(int.Parse(size.ToString())).ToList();// Take(50);
                var pageinfo = new PagingInfo();
                pageinfo.PageCount = int.Parse(PageCount.ToString());
                pageinfo.PageNo = page;
                pageinfo.PageSize = int.Parse(size.ToString());
                pageinfo.TotalRecordCount = int.Parse(TotalRecordCount.ToString());
                return Json(new { Success = 1, error = false, data = abcd, page = page, size = size, last_page = pageinfo.PageCount, total = pageinfo.TotalRecordCount });
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        [AllowAnonymous]
        public JsonResult GetCommercialInvoiceList1(string fromDate = "", string toDate = "", string LoadType = "", int supplierId = 0, int userId = 0, int page = 1, decimal size = 5, string searchquery = "")
        {
            try
            {
                var CurrentUserId = HttpContext.Session.GetInt32("UserId");
                var ComId = HttpContext.Session.GetInt32("ComId");
                DateTime fromDateValue = Convert.ToDateTime(fromDate);
                DateTime toDateValue = Convert.ToDateTime(toDate);
                var purchaselist = _CommercialInvoiceRepository.All().Where(x => x.IsDelete == false);

                //if (!string.IsNullOrEmpty(fromDate))
                //{
                //    DateTime fromDateValue = Convert.ToDateTime(fromDate);
                //    purchaselist = _CommercialInvoiceRepository.All().Where(x => x.CommercialInvoiceDate >= fromDateValue.Date);
                //}
                //if (!string.IsNullOrEmpty(toDate))
                //{
                //    DateTime toDateValue = Convert.ToDateTime(toDate);
                //    purchaselist = _CommercialInvoiceRepository.All().Where(x => x.DocumentReceiptDate <= toDateValue.Date);
                //}


                var taburesquest = JsonConvert.DeserializeObject<TabulatorRequest>(searchquery);

                if (taburesquest.Filter.Count == 0)
                {
                    purchaselist = purchaselist.Where(x => x.CommercialInvoiceDate >= fromDateValue.Date && x.CommercialInvoiceDate <= toDateValue.Date);

                    if (LoadType == "cidate")
                    {
                        purchaselist = purchaselist.Where(x => x.CommercialInvoiceDate >= fromDateValue.Date && x.CommercialInvoiceDate <= toDateValue.Date);
                    }

                    if (LoadType == "bldate")
                    {
                        purchaselist = purchaselist.Where(x => x.BLDate >= fromDateValue.Date && x.BLDate <= toDateValue.Date);
                    }

                }

                foreach (var item in taburesquest.Filter)
                {
                    if (item.Field == "CommercialInvoiceNo")
                    {
                        purchaselist = purchaselist.Where(x => x.CommercialInvoiceNo.ToLower().Contains(item.Value.ToLower()));
                    }

                    if (item.Field == "CommercialLCTypeShortName")
                    {
                        purchaselist = purchaselist.Where(x => x.CommercialLCTypes.CommercialLCTypeShortName.ToLower().Contains(item.Value.ToLower()));
                    }
                    if (item.Field == "BBLCNo")
                    {
                        purchaselist = purchaselist.Where(x => x.COM_BBLC_Master.BBLCNo.ToLower().Contains(item.Value.ToLower()));
                    }
                    if (item.Field == "CompanyName")
                    {
                        purchaselist = purchaselist.Where(x => x.CompanyList.CompanyName.ToLower().Contains(item.Value.ToLower()));
                    }
                    if (item.Field == "SupplierName")
                    {
                        purchaselist = purchaselist.Where(x => x.SupplierInformations.SupplierName.ToLower().Contains(item.Value.ToLower()));
                    }

                    if (item.Field == "CurrencyShortName")
                    {
                        purchaselist = purchaselist.Where(x => x.Currency.CurrencyShortName.ToLower().Contains(item.Value.ToLower()));
                    }

                    if (item.Field == "Quantity")
                    {
                        purchaselist = purchaselist.Where(x => x.Quantity.ToString().ToLower().Contains(item.Value.ToLower()));
                    }

                    if (item.Field == "UnitShortName")
                    {
                        purchaselist = purchaselist.Where(x => x.UnitMaster.UnitShortName.ToLower().Contains(item.Value.ToLower()));
                    }
                    if (item.Field == "TotalValue")
                    {
                        purchaselist = purchaselist.Where(x => x.TotalValue.ToString().ToLower().Contains(item.Value.ToLower()));
                    }
                    if (item.Field == "ItemGroupName")
                    {
                        purchaselist = purchaselist.Where(x => x.ItemGroupName.ToLower().Contains(item.Value.ToLower()));
                    }
                    if (item.Field == "ItemDescName")
                    {
                        purchaselist = purchaselist.Where(x => x.ItemDescs.ItemDescName.ToLower().Contains(item.Value.ToLower()));
                    }
                    if (item.Field == "BLNo")
                    {
                        purchaselist = purchaselist.Where(x => x.COM_BBLC_Master.BBLCNo.ToLower().Contains(item.Value.ToLower()));
                    }
                    if (item.Field == "DocumentStatusShortName")
                    {
                        purchaselist = purchaselist.Where(x => x.DocumentStatus.DocumentStatusShortName.ToLower().Contains(item.Value.ToLower()));
                    }
                    if (item.Field == "MotherVassel")
                    {
                        purchaselist = purchaselist.Where(x => x.MotherVassel.ToLower().Contains(item.Value.ToLower()));
                    }
                    if (item.Field == "BillOfEntryNo")
                    {
                        purchaselist = purchaselist.Where(x => x.BillOfEntryNo.ToLower().Contains(item.Value.ToLower()));
                    }


                }

                if (supplierId > 0)
                {
                    purchaselist = _CommercialInvoiceRepository.All().Where(x => x.SupplierID == supplierId && x.IsDelete == false);
                }

                if (userId > 0)
                {
                    purchaselist = _CommercialInvoiceRepository.All().Where(x => x.LuserId == userId && x.IsDelete == false);
                }

                decimal TotalRecordCount = purchaselist.Count();
                var PageCountabc = decimal.Parse((TotalRecordCount / taburesquest.Size).ToString());
                var PageCount = Math.Ceiling(PageCountabc);

                int skip = (taburesquest.Page - 1) * taburesquest.Size;

                var query = from e in purchaselist
                            select new
                            {
                                Id = e.Id,
                                e.ComId,
                                e.CommercialInvoiceNo,
                                CommercialInvoiceDate = e.CommercialInvoiceDate != null ? e.CommercialInvoiceDate.Value.ToString("dd-MMM-yyyy") : null,
                                e.CommercialLCTypes.CommercialLCTypeShortName,
                                e.COM_BBLC_Master.BBLCNo,
                                e.CommercialCompany.CompanyName,
                                e.SupplierInformations.SupplierName,
                                e.Currency.CurrencyShortName,
                                e.Quantity,
                                e.UnitMaster.UnitShortName,
                                e.TotalValue,
                                e.ItemGroups.ItemGroupName,
                                e.ItemDescs.ItemDescName,
                                e.BLNo,
                                BLDate = e.BLDate != null ? e.BLDate.Value.ToString("dd-MMM-yyyy") : null,
                                e.DocumentStatus.DocumentStatusShortName,
                                e.MotherVassel,
                                VasselETADate = e.VasselETADate != null ? e.VasselETADate.Value.ToString("dd-MMM-yyyy") : null,
                                e.BillOfEntryNo,
                                BillOfEntryDate = e.BillOfEntryDate != null ? e.BillOfEntryDate.Value.ToString("dd-MMM-yyyy") : null,
                                GoodsInhouseDate = e.GoodsInhouseDate != null ? e.GoodsInhouseDate.Value.ToString("dd-MMM-yyyy") : null,
                            };
                var abcd = query.OrderByDescending(x => x.Id).Skip(skip).Take(taburesquest.Size).ToList();
                var pageinfo = new PagingInfo();
                pageinfo.PageCount = int.Parse(PageCount.ToString());
                pageinfo.PageNo = taburesquest.Page;
                pageinfo.PageSize = taburesquest.Size;
                pageinfo.TotalRecordCount = int.Parse(TotalRecordCount.ToString());

                //return  abcd;
                return Json(new { Success = 1, error = false, data = abcd, page = taburesquest.Page, size = taburesquest.Size, last_page = pageinfo.PageCount, total = pageinfo.TotalRecordCount });

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        public JsonResult DeleteCommercialInvoice(int id)
        {
            try
            {


                var model = _CommercialInvoiceRepository.Find(id);

                if (model != null)
                {
                    _CommercialInvoiceRepository.Delete(model);

                    return Json(new { success = "1", msg = "Deleted Successfully" });
                }
                return Json(new { success = "0", msg = "No items found to delete." });

            }
            catch (Exception ex)
            {
                return Json(new { success = "0", msg = "No items found to delete." }); //msg = ex.ToString()
                throw ex;
            }
        }
        [HttpPost]
        [AllowAnonymous]
        public IActionResult GetBBLCData(int BBLCID)
        {
            var itemDescription = _bBLCDetailsRepository.All().Where(x => x.BBLCMainId == BBLCID).ToList();

            var itemDesp = "";
            foreach (var item in itemDescription)
            {
                var proformaSub = _ProformaInvoiceSubInvoiceRepository.All().Where(x => x.PIId == item.PIId).ToList();
                foreach (var proforma in proformaSub)
                {
                    var description = itemDescriptionRepository.All().Where(x => x.Id == proforma.ItemDescId).FirstOrDefault().ItemDescName;
                    itemDesp += description + " ,\n";
                }
            }

            int lastIndex = itemDesp.LastIndexOf(',');
            string CONresult = "";
            if (lastIndex != -1)
            {
                CONresult = itemDesp.Substring(0, lastIndex) + itemDesp.Substring(lastIndex + 1).TrimEnd();
            }

            var piModel = new COM_ProformaInvoice();

            var bblcdetailsId = _bBLCDetailsRepository.All().Where(x => x.BBLCMainId == BBLCID).FirstOrDefault();
            if (bblcdetailsId != null)
            {
                piModel = proformaInvoiceRepository.All().Where(x => x.Id == bblcdetailsId.PIId).FirstOrDefault();
            }

            var data = _bBLCMainRepository.All().Where(x => x.Id == BBLCID)
                .Select(x => new
                {
                    x.Id,
                    x.BBLCValue,
                    DescriptionString = CONresult,
                    x.CommercialCompanyId,
                    x.SupplierId,
                    x.LCTypeId,
                    x.CurrencyId,
                    x.ConvertRate,
                    x.ItemGroupId,
                    PrimaryUnit = piModel != null ? piModel.UnitId : null,
                    SecondaryUnit = piModel != null ? piModel.SecondaryUnitId : null,
                    Quantity = piModel != null ? piModel.ImportQty : null,
                    SecondaryQuantity = piModel != null ? piModel.CartonRollQty : null,
                });
            return Json(data);
        }
        //dropdowns
        [AllowAnonymous]
        public IActionResult lctypeDropdown()
        {
            var dropdown = _CommercialLCTypeRepository.GetAllForDropDown();
            return Json(dropdown);
        }
        [AllowAnonymous]
        public IActionResult bblcnoDropdown()
        {
            var dropdown = _bBLCMainRepository.GetAllForDropDown();
            return Json(dropdown);
        }
        [AllowAnonymous]
        public IActionResult documentStatusDropdown()
        {
            var dropdown = _DocumentStatusRepository.GetAllForDropDown();
            return Json(dropdown);
        }

        #endregion



        #region document acceptance region
        [OverridableAuthorize]
        //public IActionResult CreateDocumentAcceptance(int DocumentAcceptanceid = 0)
        public IActionResult AddDocumentAcceptance(int DocumentAcceptanceid = 0)
        {

            ViewBag.ActionType = "Create";
            ViewBag.DocumentAcceptanceid = DocumentAcceptanceid;
            return View();
        }

        [OverridableAuthorize]
        public IActionResult UpdateDocumentAcceptance(int DocumentAcceptanceid = 0)
        {

            ViewBag.ActionType = "Edit";
            ViewBag.DocumentAcceptanceid = DocumentAcceptanceid;
            return View("AddDocumentAcceptance");
        }

        [HttpPost]
        [AllowAnonymous]
        public IActionResult getCommercialInvoiceProcData(int BBLCID = 0)
        {
            var ComId = HttpContext.Session.GetInt32("ComId");
            var UserId = HttpContext.Session.GetInt32("UserId");
            var queryname = "getCommercialInvoiceData";
            var viewquery = $"Exec {queryname} '{ComId}','{BBLCID}'";
            Console.WriteLine(viewquery);
            SqlParameter[] parameters = new SqlParameter[2];
            parameters[0] = new SqlParameter("@ComId", ComId);
            parameters[1] = new SqlParameter("@BBLCID ", BBLCID);

            var datasetabc = new System.Data.DataSet();
            datasetabc = Helper.ExecProcMapDS(queryname, parameters);

            return Json(new { data = datasetabc, ex = "" });
        }



        [HttpPost]
        [AllowAnonymous]
        public IActionResult SaveDocumentAcceptance([FromBody] COM_DocumentAcceptance_Master model)
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

                        _DocumentAcceptance_MasterRepository.Update(model, model.Id);

                        var previousitem = _DocumentAcceptance_DetailsRepository.All().Where(x => x.DocumentAcceptanceMasterId == model.Id).ToList();
                        var tmp = previousitem.Where(x => !model.COM_DocumentAcceptance_Details.Any(z => x.Id == z.Id)).ToList();
                        _DocumentAcceptance_DetailsRepository.RemoveRange(tmp);
                        foreach (COM_DocumentAcceptance_Details item in model.COM_DocumentAcceptance_Details)
                        {
                            if (item.Id > 0)
                            {
                                item.DocumentAcceptanceMasterId = model.Id;
                                _DocumentAcceptance_DetailsRepository.Update(item, item.Id);

                            }
                            else
                            {
                                item.DocumentAcceptanceMasterId = model.Id;
                                _DocumentAcceptance_DetailsRepository.Insert(item);

                            }
                        }
                        TempData["Message"] = "Data Update Successfully";
                        TempData["Status"] = "2";
                        return Json(new { error = false, message = "Updated successfully", Id = model.Id });
                    }
                    else
                    {

                        foreach (var item in model.COM_DocumentAcceptance_Details.Where(x => x.IsDelete == false))
                        {

                            item.CreateDate = DateTime.Now;
                            item.UpdateDate = DateTime.Now;
                            item.ComId = int.Parse(ComId.ToString());
                            item.LuserId = int.Parse(UserId.ToString());
                            item.DocumentAcceptanceMasterId = model.Id;
                        }
                        _DocumentAcceptance_MasterRepository.Insert(model);
                        TempData["Message"] = "Data Save Successfully";
                        TempData["Status"] = "1";
                        return Json(new { error = false, message = "Saved successfully", Id = model.Id });
                    }
                }
                else
                {

                    return Json(new { error = true, message = "failed to save" });
                }



            }
            catch (Exception ex)
            {

                return Json(new { error = true, message = ex.Message });
            }
        }


        [HttpGet]
        [AllowAnonymous]
        public IActionResult getDocumentAcceptanceData(int id = 0)
        {
            var getAllBBLC = _DocumentAcceptance_MasterRepository.All().Where(x => x.Id == id);
            var query = getAllBBLC.Include(x => x.COM_DocumentAcceptance_Details)
                .Select(x => new
                {
                    x.Id,
                    x.ComId,
                    x.BillOfExchangeRef,
                    BillDate = x.BillDate != null ? x.BillDate.Value.ToString("dd-MMM-yyyy") : null,
                    BillMaturityDate = x.BillMaturityDate != null ? x.BillMaturityDate.Value.ToString("dd-MMM-yyyy") : null,
                    BillPaymentDate = x.BillPaymentDate != null ? x.BillPaymentDate.Value.ToString("dd-MMM-yyyy") : null,
                    x.BBLCId,
                    x.COM_BBLC_Master.BBLCNo,
                    x.CommercialCompanyId,
                    x.SupplierId,
                    x.GroupLCId,
                    x.MasterLCId,
                    x.ConversionRate,
                    x.CurrencyId,
                    x.BuyerId,
                    //x.bblcamount,
                    //x.previousaccepted,
                    //x.payableamount,
                    //x.NewCIAmount,
                    DocumentCceptanceDetails = x.COM_DocumentAcceptance_Details.Select(y => new
                    {
                        y.Id,
                        y.ComId,
                        CommercialInvoiceId = y.CommercialInvoiceId,
                        y.DocumentAcceptanceMasterId,
                        y.COM_CommercialInvoice.CommercialInvoiceNo,
                        y.COM_CommercialInvoice.ConversionRate,
                        y.COM_CommercialInvoice.Currency.CurrencyShortName,
                        ItemGroupName = y.COM_CommercialInvoice.ItemGroups.ItemGroupShortName,
                        ItemDescName = y.COM_CommercialInvoice.ItemDescs.ItemDescShortName,
                        PrimaryUnit = y.COM_CommercialInvoice.UnitMaster.UnitShortName,
                        SecondaryUnit = y.COM_CommercialInvoice.SecondaryUnit.UnitShortName,
                        PrimaryQuantity = y.COM_CommercialInvoice.Quantity,
                        y.COM_CommercialInvoice.TotalValue
                    })
                }).FirstOrDefault();
            return Json(query);
        }


        [AllowAnonymous]
        public JsonResult GetDocumentAcceptanceList(int page = 1, decimal size = 5, string searchquery = "")
        {
            try
            {
                var CurrentUserId = HttpContext.Session.GetInt32("UserId");
                var ComId = HttpContext.Session.GetInt32("ComId");
                var purchaselist = _DocumentAcceptance_MasterRepository.All();


                if (searchquery?.Length > 1)
                {
                    purchaselist = purchaselist.Where(x =>
                        x.BillOfExchangeRef.ToLower().Contains(searchquery.ToLower())
                    );

                }
                decimal TotalRecordCount = purchaselist.Count();
                var PageCountabc = decimal.Parse((TotalRecordCount / size).ToString());
                var PageCount = Math.Ceiling(PageCountabc);



                decimal skip = (page - 1) * size;
                var query = from e in purchaselist.Include(x => x.COM_DocumentAcceptance_Details).Include(x => x.CompanyList)
                            select new
                            {
                                Id = e.Id,
                                e.ComId,
                                e.BillOfExchangeRef,
                                BillDate = e.BillDate != null ? e.BillDate.Value.ToString("dd-MMM-yyyy") : null,
                                e.SupplierInformations.SupplierName,
                                e.COM_BBLC_Master.BBLCNo,
                                e.TotalBBLCAmount,
                            };
                var abcd = query.OrderByDescending(x => x.Id).Skip(int.Parse(skip.ToString())).Take(int.Parse(size.ToString())).ToList();// Take(50);
                var pageinfo = new PagingInfo();
                pageinfo.PageCount = int.Parse(PageCount.ToString());
                pageinfo.PageNo = page;
                pageinfo.PageSize = int.Parse(size.ToString());
                pageinfo.TotalRecordCount = int.Parse(TotalRecordCount.ToString());
                return Json(new { Success = 1, error = false, data = abcd, page = page, size = size, last_page = pageinfo.PageCount, total = pageinfo.TotalRecordCount });
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        [AllowAnonymous]
        public JsonResult GetDocumentAcceptanceList1(string fromDate = "", string toDate = "", int supplierId = 0, int page = 1, decimal size = 5, string searchquery = "")
        {
            try
            {
                var CurrentUserId = HttpContext.Session.GetInt32("UserId");
                var ComId = HttpContext.Session.GetInt32("ComId");
                DateTime fromDateValue = Convert.ToDateTime(fromDate);
                DateTime toDateValue = Convert.ToDateTime(toDate);
                var purchaselist = _DocumentAcceptance_MasterRepository.All().Where(x => x.IsDelete == false);

                var taburesquest = JsonConvert.DeserializeObject<TabulatorRequest>(searchquery);

                if (taburesquest.Filter.Count == 0)
                {
                    purchaselist = purchaselist.Where(x => x.BillDate >= fromDateValue.Date && x.BillDate <= toDateValue.Date);

                }

                foreach (var item in taburesquest.Filter)
                {
                    if (item.Field == "BillOfExchangeRef")
                    {
                        purchaselist = purchaselist.Where(x => x.BillOfExchangeRef.ToLower().Contains(item.Value.ToLower()));
                    }

                    if (item.Field == "SupplierName")
                    {
                        purchaselist = purchaselist.Where(x => x.SupplierInformations.SupplierName.ToLower().Contains(item.Value.ToLower()));
                    }
                    if (item.Field == "BBLCNo")
                    {
                        purchaselist = purchaselist.Where(x => x.COM_BBLC_Master.BBLCNo.ToLower().Contains(item.Value.ToLower()));
                    }
                    if (item.Field == "TotalBBLCAmount")
                    {
                        purchaselist = purchaselist.Where(x => x.TotalBBLCAmount.ToString().ToLower().Contains(item.Value.ToLower()));
                    }

                }

                if (supplierId > 0)
                {
                    purchaselist = _DocumentAcceptance_MasterRepository.All().Where(x => x.SupplierId == supplierId && x.IsDelete == false);
                }

                decimal TotalRecordCount = purchaselist.Count();
                var PageCountabc = decimal.Parse((TotalRecordCount / taburesquest.Size).ToString());
                var PageCount = Math.Ceiling(PageCountabc);

                int skip = (taburesquest.Page - 1) * taburesquest.Size;

                var query = from e in purchaselist.Include(x => x.COM_DocumentAcceptance_Details).Include(x => x.CompanyList)
                            select new
                            {
                                Id = e.Id,
                                e.ComId,
                                e.BillOfExchangeRef,
                                BillDate = e.BillDate != null ? e.BillDate.Value.ToString("dd-MMM-yyyy") : null,
                                //e.SupplierInformations.SupplierName,
                                e.COM_BBLC_Master.SupplierInformation.SupplierName,
                                e.COM_BBLC_Master.BBLCNo,
                                e.TotalBBLCAmount,
                            };
                var abcd = query.OrderByDescending(x => x.Id).Skip(skip).Take(taburesquest.Size).ToList();
                var pageinfo = new PagingInfo();
                pageinfo.PageCount = int.Parse(PageCount.ToString());
                pageinfo.PageNo = taburesquest.Page;
                pageinfo.PageSize = taburesquest.Size;
                pageinfo.TotalRecordCount = int.Parse(TotalRecordCount.ToString());

                //return  abcd;
                return Json(new { Success = 1, error = false, data = abcd, page = taburesquest.Page, size = taburesquest.Size, last_page = pageinfo.PageCount, total = pageinfo.TotalRecordCount });

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        [OverridableAuthorize]
        public JsonResult DeleteDocumentAcceptance(int id)
        {
            try
            {


                var model = _DocumentAcceptance_MasterRepository.Find(id);
                var modelSub = _DocumentAcceptance_DetailsRepository.All().Where(x => x.DocumentAcceptanceMasterId == model.Id).ToList();

                if (model != null)
                {

                    _DocumentAcceptance_DetailsRepository.RemoveRange(modelSub);
                    _DocumentAcceptance_MasterRepository.Delete(model);

                    return Json(new { success = "1", msg = "Deleted Successfully" });
                }
                return Json(new { success = "0", msg = "No items found to delete." });

            }
            catch (Exception ex)
            {
                return Json(new { success = "0", msg = "No items found to delete." }); //msg = ex.ToString()
                throw ex;
            }
        }
        public IActionResult getBBLCDrodpwn()
        {
            var data = _bBLCMainRepository.GetAllForDropDown();
            return Json(data);
        }
        #endregion



        #region work order region
        [OverridableAuthorize]
        //public IActionResult CreateWorkOrder(int WorkOrderId = 0)
        public IActionResult AddWorkOrder(int WorkOrderId = 0)
        {

            ViewBag.ActionType = "Create";
            ViewBag.WorkOrderId = WorkOrderId;
            return View();
        }

        [OverridableAuthorize]
        //public IActionResult CreateWorkOrder(int WorkOrderId = 0)
        public IActionResult UpdateWorkOrder(int WorkOrderId)
        {
            ViewBag.ActionType = "Edit";
            ViewBag.WorkOrderId = WorkOrderId;
            return View("AddWorkOrder");
        }
        [HttpPost]
        [AllowAnonymous]
        public IActionResult SaveWorkOrder([FromBody] WorkOrderMaster model)
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

                        _WorkOrderMasterRepository.Update(model, model.Id);
                        return Json(new { success = "1", error = false, message = "Data updated successfully", Id = model.Id });
                    }
                    else
                    {
                        _WorkOrderMasterRepository.Insert(model);
                        return Json(new { success = "1", error = false, message = "Data saved successfully", Id = model.Id });
                    }
                }
                else
                {

                    return Json(new { error = true, message = "failed to save Data" });
                }



            }
            catch (Exception ex)
            {

                return Json(new { error = true, message = ex.Message });
            }
        }

        [HttpGet]
        [AllowAnonymous]
        public JsonResult GetWorkOrder(int id)
        {
            try
            {
                var colorsquery = _WorkOrderMasterRepository.All().Where(x => x.Id == id);

                var color = colorsquery.Include(p => p.CommercialCompany)
                  .Select(p => new
                  {
                      p.Id,
                      p.ComId,
                      p.CommercialCompanyId,
                      p.WorkOrderNo,
                      WorkOrderDate = p.WorkOrderDate != null ? p.WorkOrderDate.Value.ToString("dd-MMM-yyyy") : null,
                      p.SupplierId,
                      p.ToPerson,
                      ServiceContractStartDate = p.ServiceContractStartDate != null ? p.ServiceContractStartDate.Value.ToString("dd-MMM-yyyy") : null,
                      ServiceContractEndDate = p.ServiceContractEndDate != null ? p.ServiceContractEndDate.Value.ToString("dd-MMM-yyyy") : null,
                      p.CurrencyId,
                      p.ConversionRate,
                      p.WorkOrderType,
                      AgreementDate = p.AgreementDate != null ? p.AgreementDate.Value.ToString("dd-MMM-yyyy") : null,
                      DeliveryDate = p.DeliveryDate != null ? p.DeliveryDate.Value.ToString("dd-MMM-yyyy") : null,
                      p.Subject,
                      p.PaymentTerms,
                      p.ShipTo,
                      p.OtherTerms,
                      p.SubTotal,
                      p.RecommenedById,
                      p.SalesTax,
                      p.ApprovedById,
                      p.Shipping,
                      p.OtherExp,
                      p.Total,
                      p.AdvancePayment,
                      p.NetPayable,
                  }).FirstOrDefault();


                return Json(new { Success = 1, data = color, ex = "Data Load Successfully" });
            }
            catch (Exception e)
            {
                return Json(e.ToString());
            }

        }
        [HttpGet]
        [AllowAnonymous]

        public JsonResult DeleteWorkOrder(int id)
        {
            try
            {


                var model = _WorkOrderMasterRepository.Find(id);

                if (model != null)
                {
                    _WorkOrderMasterRepository.Delete(model);

                    return Json(new { success = "1", msg = "Deleted Successfully" });
                }
                return Json(new { success = "0", msg = "No items found to delete." });

            }
            catch (Exception ex)
            {
                return Json(new { success = "0", msg = "No items found to delete." }); //msg = ex.ToString()
                throw ex;
            }
        }




        [AllowAnonymous]
        public JsonResult GetWorkOrderList(string fromDate = "", string toDate = "", int supplierid = 0, int page = 1, decimal size = 5, string searchquery = "")
        {
            try
            {
                var CurrentUserId = HttpContext.Session.GetInt32("UserId");
                var ComId = HttpContext.Session.GetInt32("ComId");
                var purchaselist = _WorkOrderMasterRepository.All();

                if (searchquery?.Length > 1)
                {
                    purchaselist = purchaselist.Where(x =>
                        x.WorkOrderNo.ToLower().Contains(searchquery.ToLower())
                    );

                }

                decimal TotalRecordCount = purchaselist.Count();
                var PageCountabc = decimal.Parse((TotalRecordCount / size).ToString());
                var PageCount = Math.Ceiling(PageCountabc);



                decimal skip = (page - 1) * size;
                var query = from p in purchaselist.Include(x => x.CommercialCompany)
                            select new
                            {
                                Id = p.Id,
                                p.ComId,
                                woconcrn = p.CommercialCompany.CompanyName,
                                woWorkorderStatus = p.WorkorderStatus,
                                woWorkOrderNo = p.WorkOrderNo,
                                woWorkOrderDate = p.WorkOrderDate != null ? p.WorkOrderDate.Value.ToString("dd-MMM-yyyy") : null,
                                woSupplierName = p.SupplierInformation.SupplierName,
                                woToPerson = p.ToPerson,
                                woAgreementDate = p.AgreementDate != null ? p.AgreementDate.Value.ToString("dd-MMM-yyyy") : null,
                                woDeliveryDate = p.DeliveryDate != null ? p.DeliveryDate.Value.ToString("dd-MMM-yyyy") : null,
                                woServiceContractStartDate = p.ServiceContractStartDate != null ? p.ServiceContractStartDate.Value.ToString("dd-MMM-yyyy") : null,
                                woServiceContractEndDate = p.ServiceContractEndDate != null ? p.ServiceContractEndDate.Value.ToString("dd-MMM-yyyy") : null,
                                woCountryShortName = p.Currency.CountryShortName,
                                woConversionRate = p.ConversionRate,
                                woWorkOrderType = p.WorkOrderType,
                                woSubject = p.Subject,
                                woPaymentTerms = p.PaymentTerms,
                                woOtherTerms = p.OtherTerms,
                                woWorkOrderQty = p.WorkOrderQty,
                                woWorkOrderRate = p.WorkOrderRate,
                                woSubTotal = p.SubTotal,
                                woSalesTax = p.SalesTax,
                                woOtherExp = p.OtherExp,
                                woWorkOrderAmt = p.WorkOrderAmt,
                                woAdvancePayment = p.AdvancePayment,
                                woTotal = p.Total,
                                Remarks = p.Remarks,
                                IsLocked = p.IsLocked,
                                WODetails = p.WODetails,
                                woShipTo = p.ShipTo,
                                woShipping = p.Shipping,
                                Total = p.Total,
                            };
                var abcd = query.OrderByDescending(x => x.Id).Skip(int.Parse(skip.ToString())).Take(int.Parse(size.ToString())).ToList();// Take(50);
                var pageinfo = new PagingInfo();
                pageinfo.PageCount = int.Parse(PageCount.ToString());
                pageinfo.PageNo = page;
                pageinfo.PageSize = int.Parse(size.ToString());
                pageinfo.TotalRecordCount = int.Parse(TotalRecordCount.ToString());
                return Json(new { Success = 1, error = false, data = abcd, page = page, size = size, last_page = pageinfo.PageCount, total = pageinfo.TotalRecordCount });
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        [AllowAnonymous]
        public JsonResult GetWorkOrderList1(string fromDate = "", string toDate = "", int supplierId = 0, int page = 1, decimal size = 5, string searchquery = "")
        {
            try
            {
                var CurrentUserId = HttpContext.Session.GetInt32("UserId");
                var ComId = HttpContext.Session.GetInt32("ComId");
                DateTime fromDateValue = Convert.ToDateTime(fromDate);
                DateTime toDateValue = Convert.ToDateTime(toDate);
                var purchaselist = _WorkOrderMasterRepository.All().Where(x => x.IsDelete == false);

                var taburesquest = JsonConvert.DeserializeObject<TabulatorRequest>(searchquery);

                if (taburesquest.Filter.Count == 0)
                {
                    purchaselist = purchaselist.Where(x => x.WorkOrderDate >= fromDateValue.Date && x.WorkOrderDate <= toDateValue.Date);

                }

                foreach (var item in taburesquest.Filter)
                {
                    if (item.Field == "woconcrn")
                    {
                        purchaselist = purchaselist.Where(x => x.CommercialCompany.CompanyName.ToLower().Contains(item.Value.ToLower()));
                    }

                    if (item.Field == "woWorkorderStatus")
                    {
                        purchaselist = purchaselist.Where(x => x.WorkorderStatus.ToString().ToLower().Contains(item.Value.ToLower()));
                    }
                    if (item.Field == "woWorkOrderNo")
                    {
                        purchaselist = purchaselist.Where(x => x.WorkOrderNo.ToLower().Contains(item.Value.ToLower()));
                    }
                    if (item.Field == "woSupplierName")
                    {
                        purchaselist = purchaselist.Where(x => x.SupplierInformation.SupplierName.ToLower().Contains(item.Value.ToLower()));
                    }
                    if (item.Field == "woToPerson")
                    {
                        purchaselist = purchaselist.Where(x => x.ToPerson.ToLower().Contains(item.Value.ToLower()));
                    }

                    if (item.Field == "woCountryShortName")
                    {
                        purchaselist = purchaselist.Where(x => x.Currency.CountryShortName.ToLower().Contains(item.Value.ToLower()));
                    }

                    if (item.Field == "woConversionRate")
                    {
                        purchaselist = purchaselist.Where(x => x.ConversionRate.ToString().ToLower().Contains(item.Value.ToLower()));
                    }

                    if (item.Field == "woWorkOrderType")
                    {
                        purchaselist = purchaselist.Where(x => x.WorkOrderType.ToLower().Contains(item.Value.ToLower()));
                    }
                    if (item.Field == "woSubject")
                    {
                        purchaselist = purchaselist.Where(x => x.Subject.ToLower().Contains(item.Value.ToLower()));
                    }
                    if (item.Field == "woPaymentTerms")
                    {
                        purchaselist = purchaselist.Where(x => x.PaymentTerms.ToLower().Contains(item.Value.ToLower()));
                    }
                    if (item.Field == "woOtherTerms")
                    {
                        purchaselist = purchaselist.Where(x => x.OtherTerms.ToLower().Contains(item.Value.ToLower()));
                    }
                    if (item.Field == "woWorkOrderQty")
                    {
                        purchaselist = purchaselist.Where(x => x.WorkOrderQty.ToString().ToLower().Contains(item.Value.ToLower()));
                    }
                    if (item.Field == "woWorkOrderRate")
                    {
                        purchaselist = purchaselist.Where(x => x.WorkOrderRate.ToString().ToLower().Contains(item.Value.ToLower()));
                    }
                    if (item.Field == "woSubTotal")
                    {
                        purchaselist = purchaselist.Where(x => x.SubTotal.ToString().ToLower().Contains(item.Value.ToLower()));
                    }
                    if (item.Field == "woSalesTax")
                    {
                        purchaselist = purchaselist.Where(x => x.SalesTax.ToString().ToLower().Contains(item.Value.ToLower()));
                    }
                    if (item.Field == "woOtherExp")
                    {
                        purchaselist = purchaselist.Where(x => x.OtherExp.ToString().ToLower().Contains(item.Value.ToLower()));
                    }
                    if (item.Field == "woWorkOrderAmt")
                    {
                        purchaselist = purchaselist.Where(x => x.WorkOrderAmt.ToString().ToLower().Contains(item.Value.ToLower()));
                    }
                    if (item.Field == "woAdvancePayment")
                    {
                        purchaselist = purchaselist.Where(x => x.AdvancePayment.ToString().ToLower().Contains(item.Value.ToLower()));
                    }
                    if (item.Field == "woTotal")
                    {
                        purchaselist = purchaselist.Where(x => x.Total.ToString().ToLower().Contains(item.Value.ToLower()));
                    }
                    if (item.Field == "Remarks")
                    {
                        purchaselist = purchaselist.Where(x => x.Remarks.ToLower().Contains(item.Value.ToLower()));
                    }
                    if (item.Field == "IsLocked")
                    {
                        purchaselist = purchaselist.Where(x => x.IsLocked.ToString().ToLower().Contains(item.Value.ToLower()));
                    }
                    if (item.Field == "WODetails")
                    {
                        purchaselist = purchaselist.Where(x => x.WODetails.ToLower().Contains(item.Value.ToLower()));
                    }
                    if (item.Field == "woShipTo")
                    {
                        purchaselist = purchaselist.Where(x => x.ShipTo.ToLower().Contains(item.Value.ToLower()));
                    }
                    if (item.Field == "woShipping")
                    {
                        purchaselist = purchaselist.Where(x => x.Shipping.ToLower().Contains(item.Value.ToLower()));
                    }
                    if (item.Field == "Total")
                    {
                        purchaselist = purchaselist.Where(x => x.Total.ToString().ToLower().Contains(item.Value.ToLower()));
                    }

                }

                if (supplierId > 0)
                {
                    purchaselist = _WorkOrderMasterRepository.All().Where(x => x.SupplierId == supplierId && x.IsDelete == false);
                }

                decimal TotalRecordCount = purchaselist.Count();
                var PageCountabc = decimal.Parse((TotalRecordCount / taburesquest.Size).ToString());
                var PageCount = Math.Ceiling(PageCountabc);

                int skip = (taburesquest.Page - 1) * taburesquest.Size;

                var query = from p in purchaselist.Include(x => x.CommercialCompany)
                            select new
                            {
                                Id = p.Id,
                                p.ComId,
                                woconcrn = p.CommercialCompany.CompanyName,
                                woWorkorderStatus = p.WorkorderStatus,
                                woWorkOrderNo = p.WorkOrderNo,
                                woWorkOrderDate = p.WorkOrderDate != null ? p.WorkOrderDate.Value.ToString("dd-MMM-yyyy") : null,
                                woSupplierName = p.SupplierInformation.SupplierName,
                                woToPerson = p.ToPerson,
                                woAgreementDate = p.AgreementDate != null ? p.AgreementDate.Value.ToString("dd-MMM-yyyy") : null,
                                woDeliveryDate = p.DeliveryDate != null ? p.DeliveryDate.Value.ToString("dd-MMM-yyyy") : null,
                                woServiceContractStartDate = p.ServiceContractStartDate != null ? p.ServiceContractStartDate.Value.ToString("dd-MMM-yyyy") : null,
                                woServiceContractEndDate = p.ServiceContractEndDate != null ? p.ServiceContractEndDate.Value.ToString("dd-MMM-yyyy") : null,
                                woCountryShortName = p.Currency.CountryShortName,
                                woConversionRate = p.ConversionRate,
                                woWorkOrderType = p.WorkOrderType,
                                woSubject = p.Subject,
                                woPaymentTerms = p.PaymentTerms,
                                woOtherTerms = p.OtherTerms,
                                woWorkOrderQty = p.WorkOrderQty,
                                woWorkOrderRate = p.WorkOrderRate,
                                woSubTotal = p.SubTotal,
                                woSalesTax = p.SalesTax,
                                woOtherExp = p.OtherExp,
                                woWorkOrderAmt = p.WorkOrderAmt,
                                woAdvancePayment = p.AdvancePayment,
                                woTotal = p.Total,
                                Remarks = p.Remarks,
                                IsLocked = p.IsLocked,
                                WODetails = p.WODetails,
                                woShipTo = p.ShipTo,
                                woShipping = p.Shipping,
                                Total = p.Total,
                            };
                var abcd = query.OrderByDescending(x => x.Id).Skip(skip).Take(taburesquest.Size).ToList();
                var pageinfo = new PagingInfo();
                pageinfo.PageCount = int.Parse(PageCount.ToString());
                pageinfo.PageNo = taburesquest.Page;
                pageinfo.PageSize = taburesquest.Size;
                pageinfo.TotalRecordCount = int.Parse(TotalRecordCount.ToString());

                //return  abcd;
                return Json(new { Success = 1, error = false, data = abcd, page = taburesquest.Page, size = taburesquest.Size, last_page = pageinfo.PageCount, total = pageinfo.TotalRecordCount });

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        #endregion


        #region doc automation region
        public IActionResult BBLCReport(int backtobacklcid = 0)
        {

            if (backtobacklcid > 0)
            {
                ViewBag.ActionType = "Edit";
                ViewBag.BBLCID = backtobacklcid;
                return View();
            }
            else
            {
                ViewBag.ActionType = "Create";
                ViewBag.BBLCID = backtobacklcid;
                return View();
            }
        }


        [HttpPost]
        [AllowAnonymous]
        public IActionResult getOtherDataForBBLCReport(int BBLCId = 0)
        {
            var data = _bBLCMainRepository.All().Where(x => x.Id == BBLCId)
                .Select(x => new
                {
                    x.Id,
                    x.RefNo,
                    x.Percentage,
                    x.PrintDate,
                }).FirstOrDefault();
            return Json(data);
        }


        [HttpPost]
        [AllowAnonymous]
        public JsonResult UpsertBBLCRefNo(int BBLCId, string RefNo, string Percentage, string PrintDate)
        {
            var bblcOtherDatas = _bBLCMainRepository.All().Where(a => a.Id == BBLCId).FirstOrDefault();
            if (bblcOtherDatas != null)
            {
                bblcOtherDatas.RefNo = RefNo;
                bblcOtherDatas.Percentage = Percentage;
                bblcOtherDatas.PrintDate = PrintDate;
                _bBLCMainRepository.Update(bblcOtherDatas, BBLCId);

                return Json(new { error = false, message = "Updated successfully", Id = BBLCId });
            }
            return Json(new { error = false, message = "", Id = BBLCId });
        }
        [HttpPost]
        [AllowAnonymous]
        public IActionResult SaveTruckInfo([FromBody] TruckInfo model)
        {
            var UserId = HttpContext.Session.GetInt32("UserId");
            var ComId = HttpContext.Session.GetInt32("ComId");

            var errors = ModelState.Where(x => x.Value.Errors.Any())
            .Select(x => new { x.Key, x.Value.Errors });

            try
            {

                if (ModelState.IsValid)
                {

                    if (model.Id > 0)
                    {
                        _TruckInfoRepository.Update(model, model.Id);
                        return Json(new { error = false, message = "Updated successfully", Id = model.Id });
                    }
                    else
                    {
                        _TruckInfoRepository.Insert(model);
                        return Json(new { error = false, message = "Saved successfully", Id = model.Id });
                    }
                }
                return Json(new { error = false, message = "", Id = model.Id });
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }


        [AllowAnonymous]
        public JsonResult TruckInfoSearch(string query)
        {
            var abc = _TruckInfoRepository.All()
                .Where(x => (x.TruckNo.ToLower().Contains(query.ToLower())) ||
                (x.DriverName.ToLower().Contains(query.ToLower())) ||
                (x.MobileNo.ToLower().Contains(query.ToLower()))
                ).ToList()
                        .Select(p => new
                        {
                            Id = p.Id,
                            p.TruckNo,
                            p.DriverName,
                            p.MobileNo,
                        }).Take(10);
            return Json(abc);
        }

        [HttpPost]
        [AllowAnonymous]
        public IActionResult GetReport(string reporttype, string action, int? reportid, string refno, string printdate, string truckno, string drivername, string drivermobileno, int? grouplcid, string multipleproformainvoice, string Percentage, string multiplemasterlc)
        {
            try
            {
                string redirectUrl = "";
                //return Json(new { Success = 1, TermsId = param, ex = "" });
                if (action == "PrintBBLCOpen")
                {
                    redirectUrl = Url.Action("COM_BBLC_Master", "Variable", new { id = grouplcid });
                    return Json(new { Url = redirectUrl });
                }
                else
                {
                    redirectUrl = Url.Action("COM_BBLC_Master", "Variable", new { id = reportid });
                    return Json(new { Url = redirectUrl });
                }


                return Json(new { Url = redirectUrl });

            }

            catch (Exception ex)
            {
                // If Sucess== 0 then Unable to perform Save/Update Operation and send Exception to View as JSON
                return Json(new { Success = 0, ex = ex.InnerException.InnerException.Message.ToString() });
            }

            return Json(new { Success = 0, ex = new Exception("Unable to Delete").Message.ToString() });
            //return RedirectToAction("Index");

        }



        [AllowAnonymous]
        public JsonResult GroupLCSearchAutocomplete(string query)
        {
            var abc = groupLCMainRepository.All()
                .Where(x => (x.GroupLCRefName.ToLower().Contains(query.ToLower()))).ToList()
                        .Select(p => new
                        {
                            Id = p.Id,
                            p.GroupLCRefName,
                        }).Take(10);

            return Json(abc);
        }


        [AllowAnonymous]
        public JsonResult getOtherDataByGroupLCId(int GroupLCID)
        {
            var proformaInvoice = proformaInvoiceRepository.All().Where(x => x.GroupLCId == GroupLCID)
                        .Select(p => new
                        {
                            p.Id,
                            p.PINo,
                        }).ToList();

            var ComId = HttpContext.Session.GetInt32("ComId");
            var UserId = HttpContext.Session.GetInt32("UserId");
            var queryname = "getExportInvoiceByGroupLC";
            var viewquery = $"Exec {queryname} '{ComId}','{GroupLCID}'";
            Console.WriteLine(viewquery);
            SqlParameter[] parameters = new SqlParameter[2];
            parameters[0] = new SqlParameter("@ComId", ComId);
            parameters[1] = new SqlParameter("@GroupLCID ", GroupLCID);

            var datasetabc = new System.Data.DataSet();
            datasetabc = Helper.ExecProcMapDS(queryname, parameters);

            return Json(new { proformaInvoice = proformaInvoice, exportLC = datasetabc });
        }

        [HttpGet]
        public IActionResult proformaInvoiceDrodpdown()
        {
            var dropdown = proformaInvoiceRepository.GetAllForDropDown();
            return Json(dropdown);
        }
        #endregion

        #region Export doc automation
        public IActionResult ExportShippingReport()
        {

            return View();
        }

        [HttpGet]
        [AllowAnonymous]
        public IActionResult getMasterLCDropdown()
        {
            var dropdown = _masterLCRepository.GetAllForDropDown();
            return Json(dropdown);
        }

        [AllowAnonymous]
        [HttpGet]
        public JsonResult GetInvoiceDetails(int id)
        {

            var proformaInvoice = _exportInvoiceMasterRepository.All().Where(x => x.Id == id).Select(
                x => new
                {
                    Buyer = x.BuyerInformation.Name,
                    Exporter = x.ComercialCompanyss.CompanyName,
                    TotalInvoiceQty = x.TotalInvoiceQty,
                    TotalValue = x.TotalValue
                }).FirstOrDefault();
            return Json(new { success = "1", data = proformaInvoice });
        }


        [HttpGet]
        [AllowAnonymous]
        public JsonResult upgradeInvoiceId(int id)
        {

            var proformaInvoice = _exportInvoiceMasterRepository.All().Where(x => x.MasterLCId == id).Select(
                x => new SelectListItem
                {
                    Text = x.InvoiceNo,
                    Value = x.Id.ToString()
                }).ToList();
            return Json(new { success = "1", proformaInvoice = proformaInvoice });
        }

        [AllowAnonymous]
        [HttpPost]
        public IActionResult ExportSetSession(string reporttype, string action, int masterlcid, int grouplcid, string reportid, DateTime printdate)
        {
            try
            {

                var comid = HttpContext.Session.GetInt32("ComId");
                var userid = HttpContext.Session.GetInt32("Userid");

                HttpContext.Session.SetString("ReportType", reporttype);
                HttpContext.Session.SetString("MultiSelectData", reportid);
                HttpContext.Session.SetString("GroupLCId", grouplcid.ToString());
                HttpContext.Session.SetString("RefNo", "");
                HttpContext.Session.SetString("PrintDate", printdate.ToString());
                HttpContext.Session.SetString("MasterLCId", masterlcid.ToString());



                var redirectUrl = "";

                if (action == "PrintCOPE")
                {
                    redirectUrl = Url.Action(action, "Variable", new { id = reportid, type = reporttype });
                } else if (action == "ExportPackingList")
                {
                    redirectUrl = Url.Action(action, "Variable", new { id = reportid, type = reporttype, value = "Packing List" });
                }
                else if (action == "ExportDetailsPackingList")
                {
                    redirectUrl = Url.Action(action, "Variable", new { id = reportid, type = reporttype, value = "De_Packing List" });
                }
                else
                {
                    var vals = reportid.Split(',')[0];
                    redirectUrl = Url.Action(action, "Variable", new { id = reportid, type = reporttype });

                }
                return Redirect(redirectUrl);
            }

            catch (Exception ex)
            {
                return Json(new { Success = 0, ex = ex.InnerException.InnerException.Message.ToString() });
            }

            return Json(new { Success = 0, ex = new Exception("Unable to Delete").Message.ToString() });

        }


        [AllowAnonymous]
        public ActionResult ExportPackingList(int? id, string type, string value)
        {
            try
            {
                var comid = HttpContext.Session.GetInt32("ComId");
                var printDate = DateTime.Parse(HttpContext.Session.GetString("PrintDate"));

                var reportname = _exportInvoiceMasterRepository.All().Where(x => x.Id == id).Select(x => x.NotifyPartyFirst.DynamicReports.DynamicReportName).FirstOrDefault();
                if (value == "Packing List")
                {
                    reportname = _exportInvoiceMasterRepository.All().Where(x => x.Id == id).Select(x => x.NotifyPartyFirst.DynamicReports.DynamicReportPackingListName).FirstOrDefault();
                }

                if (value == "Out Pass")
                {
                    reportname = "rptCommercialInvoice_Export_PRIMARK_CMT_OutPass";
                }

                if (value == "Out PassEng")
                {
                    reportname = "rptCommercialInvoice_Export_PRIMARK_CMT_OutPassEng";
                }

                if (reportname == null || reportname == "")
                {
                    reportname = "rptCommercialInvoice_Export";
                }

                if (type == null)
                {
                    type = "PDF";
                }
                int WarehouseCount = _exportInvoiceMasterRepository.All().Where(x => x.Id == id && x.COM_MasterLC.BuyerGroups.BuyerGroupName.ToUpper().Contains("H&M".ToUpper()) && x.Destination.DestinationNameSearch.ToUpper().Contains("warehouse".ToUpper())).Count();
                if (WarehouseCount > 0) { reportname = "rptCommercialInvoice_Export_HM_Warehouse"; }

                clsReport.rptList = null;

                HttpContext.Session.SetString("ReportPath", "~/ReportViewer/CommercialReport/" + reportname + ".rdlc");
                HttpContext.Session.SetString("ReportQuery", "Exec rptCommercialInvoice_Export '" + id + "', '" + comid + "'");


                string filename = _exportInvoiceMasterRepository.All().Where(x => x.Id == id).Select(x => x.BuyerInformation.Name + "_" + x.ShipModel.ShipName + "_" + x.Destination.DestinationName + "_" + x.InvoiceNo).Single();
                HttpContext.Session.SetString("PrintFileName", filename.Replace(".", "").Replace(" ", "").Replace(",", "").Replace(" ", ""));



                string DataSourceName = "DataSet1";

                clsReport.strReportPathMain = HttpContext.Session.GetString("ReportPath");
                clsReport.strQueryMain = HttpContext.Session.GetString("ReportQuery");
                clsReport.strDSNMain = DataSourceName;

                string callBackUrl = this.Url.Action("Index", "ReportViewer", new { reporttype = type });
                var redirectUrl = callBackUrl;


                //return Redirect(redirectUrl);
                return Json(new { Url = redirectUrl });
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }

        [AllowAnonymous]
        public ActionResult ExportDetailsPackingList(int? id, string type, string value)
        {
            try
            {
                var comid = HttpContext.Session.GetInt32("ComId");

                var reportname = _exportInvoiceMasterRepository.All().Where(x => x.Id == id).Select(x => x.NotifyPartyFirst.DynamicReports.DynamicReportName).FirstOrDefault();

                if (value == "De_Packing List")
                {
                    reportname = "rptCommercialInvoice_Export_Details_Packing_List";
                }

                if (reportname == null)
                {
                    reportname = "rptCommercialInvoice_Export_Details_Packing_List";
                }

                if (type == null)
                {
                    type = "PDF";
                }
                int WarehouseCount = _exportInvoiceMasterRepository.All().Where(x => x.Id == id && x.COM_MasterLC.BuyerGroups.BuyerGroupName.ToUpper().Contains("H&M".ToUpper()) && x.Destination.DestinationNameSearch.ToUpper().Contains("warehouse".ToUpper())).Count();
                if (WarehouseCount > 0) { reportname = "rptCommercialInvoice_Export_HM_Warehouse"; }

                clsReport.rptList = null;

                HttpContext.Session.SetString("ReportPath", "~/ReportViewer/CommercialReport/" + reportname + ".rdlc");
                HttpContext.Session.SetString("ReportQuery", "Exec rptCommercialInvoice_Export_PackingList_Static '" + id + "', '" + comid + "'");


                string filename = _exportInvoiceMasterRepository.All().Where(x => x.Id == id).Select(x => x.BuyerInformation.Name + "_" + x.ShipModel.ShipName + "_" + x.Destination.DestinationName + "_" + x.InvoiceNo).Single();
                HttpContext.Session.SetString("PrintFileName", filename.Replace(".", "").Replace(" ", "").Replace(",", "").Replace(" ", ""));



                string DataSourceName = "DataSet1";

                clsReport.strReportPathMain = HttpContext.Session.GetString("ReportPath");
                clsReport.strQueryMain = HttpContext.Session.GetString("ReportQuery");
                clsReport.strDSNMain = DataSourceName;

                string callBackUrl = this.Url.Action("Index", "ReportViewer", new { reporttype = type });
                var redirectUrl = callBackUrl;


                //return Redirect(redirectUrl);
                return Json(new { Url = redirectUrl });
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }

        [AllowAnonymous]
        public ActionResult PrintCIE(int? id, string type)
        {
            try
            {
                var comid = HttpContext.Session.GetInt32("ComId");
                var printDate = DateTime.Parse(HttpContext.Session.GetString("PrintDate"));

                var reportname = _exportInvoiceMasterRepository.All().Where(x => x.Id == id).Select(x => x.NotifyPartyFirst.DynamicReports.DynamicReportName).FirstOrDefault();

                if (reportname == null)
                {
                    reportname = "rptCommercialInvoice_Export";
                }

                if (type == null)
                {
                    type = "PDF";
                }
                int WarehouseCount = _exportInvoiceMasterRepository.All().Where(x => x.Id == id && x.COM_MasterLC.BuyerGroups.BuyerGroupName.ToUpper().Contains("H&M".ToUpper()) && x.Destination.DestinationNameSearch.ToUpper().Contains("warehouse".ToUpper())).Count();
                if (WarehouseCount > 0) { reportname = "rptCommercialInvoice_Export_HM_Warehouse"; }

                clsReport.rptList = null;

                HttpContext.Session.SetString("ReportPath", "~/ReportViewer/CommercialReport/" + reportname + ".rdlc");
                HttpContext.Session.SetString("ReportQuery", "Exec rptCommercialInvoice_Export '" + id + "', '" + comid + "'");


                string filename = _exportInvoiceMasterRepository.All().Where(x => x.Id == id).Select(x => x.BuyerInformation.Name + "_" + x.ShipModel.ShipName + "_" + x.Destination.DestinationName + "_" + x.InvoiceNo).Single();
                HttpContext.Session.SetString("PrintFileName", filename.Replace(".", "").Replace(" ", "").Replace(",", "").Replace("\"", ""));



                string DataSourceName = "DataSet1";

                clsReport.strReportPathMain = HttpContext.Session.GetString("ReportPath");
                clsReport.strQueryMain = HttpContext.Session.GetString("ReportQuery");
                clsReport.strDSNMain = DataSourceName;

                string callBackUrl = this.Url.Action("Index", "ReportViewer", new { reporttype = type });
                var redirectUrl = callBackUrl;


                return Json(new { Url = redirectUrl });
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }

        [AllowAnonymous]
        public ActionResult PrintCountryOfOrigin(int? id, string type)
        {
            try
            {
                clsReport.rptList = null;
                var comid = HttpContext.Session.GetInt32("ComId");
                var refno = HttpContext.Session.GetString("RefNo");
                var printDate = DateTime.Parse(HttpContext.Session.GetString("PrintDate"));
                var multiselectData = HttpContext.Session.GetString("MultiSelectData");
                var groupLCId = 0;

                HttpContext.Session.SetString("ReportPath", "~/ReportViewer/CommercialReport/rptCountryOfOrigin_Export.rdlc");
                HttpContext.Session.SetString("ReportQuery", "Exec rptExportDocumentsAutomation '" + id + "', '" + comid + "', '" + refno + "','" + printDate + "','" + multiselectData + "','" + groupLCId + "'");

                string filename = _exportInvoiceMasterRepository.All().Where(x => x.Id == id).Select(x => x.BuyerInformation.Name + "_" + x.ShipModel.ShipName + "_" + x.Destination.DestinationName + "_" + x.InvoiceNo).Single();
                HttpContext.Session.SetString("PrintFileName", filename.Replace(".", "").Replace(" ", "").Replace(",", "").Replace("\"", ""));



                string DataSourceName = "DataSet1";

                clsReport.strReportPathMain = HttpContext.Session.GetString("ReportPath");
                clsReport.strQueryMain = HttpContext.Session.GetString("ReportQuery");
                clsReport.strDSNMain = DataSourceName;

                string callBackUrl = this.Url.Action("Index", "ReportViewer", new { reporttype = type });
                var redirectUrl = callBackUrl;


                return Json(new { Url = redirectUrl });
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }

        [AllowAnonymous]
        public ActionResult PrintGSP(int? id, string type)
        {
            try
            {
                clsReport.rptList = null;
                var comid = HttpContext.Session.GetInt32("ComId");
                var refno = HttpContext.Session.GetString("RefNo");
                var printDate = DateTime.Parse(HttpContext.Session.GetString("PrintDate"));
                var multiselectData = HttpContext.Session.GetString("MultiSelectData");
                var groupLCId = 0;

                HttpContext.Session.SetString("ReportPath", "~/ReportViewer/CommercialReport/rptGSP_Export.rdlc");
                HttpContext.Session.SetString("ReportQuery", "Exec rptExportDocumentsAutomation '" + id + "', '" + comid + "', '" + refno + "','" + printDate + "','" + multiselectData + "','" + groupLCId + "'");


                string filename = _exportInvoiceMasterRepository.All().Where(x => x.Id == id).Select(x => x.BuyerInformation.Name + "_" + x.ShipModel.ShipName + "_" + x.Destination.DestinationName + "_" + x.InvoiceNo).Single();
                HttpContext.Session.SetString("PrintFileName", filename.Replace(".", "").Replace(" ", "").Replace(",", "").Replace("\"", ""));

                string DataSourceName = "DataSet1";

                clsReport.strReportPathMain = HttpContext.Session.GetString("ReportPath");
                clsReport.strQueryMain = HttpContext.Session.GetString("ReportQuery");
                clsReport.strDSNMain = DataSourceName;

                string callBackUrl = this.Url.Action("Index", "ReportViewer", new { reporttype = type });
                var redirectUrl = callBackUrl;


                return Json(new { Url = redirectUrl });
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }
        [AllowAnonymous]
        public ActionResult PrintBillOfExchange(int? id, string type)
        {
            try
            {
                clsReport.rptList = null;

                var comid = HttpContext.Session.GetInt32("ComId");
                var refno = HttpContext.Session.GetString("RefNo");
                var printDate = DateTime.Parse(HttpContext.Session.GetString("PrintDate"));
                var multiselectData = HttpContext.Session.GetString("MultiSelectData");
                var groupLCId = 0;

                HttpContext.Session.SetString("ReportPath", "~/ReportViewer/CommercialReport/rptBillOfExchange_Export.rdlc");
                HttpContext.Session.SetString("ReportQuery", "Exec rptExportDocumentsAutomation '" + id + "', '" + comid + "', '" + refno + "','" + printDate + "','" + multiselectData + "','" + groupLCId + "'");


                string filename = _exportInvoiceMasterRepository.All().Where(x => x.Id == id).Select(x => x.BuyerInformation.Name + "_" + x.ShipModel.ShipName + "_" + x.Destination.DestinationName + "_" + x.InvoiceNo).Single();
                HttpContext.Session.SetString("PrintFileName", filename.Replace(".", "").Replace(" ", "").Replace(",", "").Replace("\"", ""));

                string DataSourceName = "DataSet1";

                clsReport.strReportPathMain = HttpContext.Session.GetString("ReportPath");
                clsReport.strQueryMain = HttpContext.Session.GetString("ReportQuery");
                clsReport.strDSNMain = DataSourceName;

                string callBackUrl = this.Url.Action("Index", "ReportViewer", new { reporttype = type });
                var redirectUrl = callBackUrl;


                return Json(new { Url = redirectUrl });
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }

        [AllowAnonymous]
        public ActionResult PrintBL(int? id, string type)
        {
            try
            {
                clsReport.rptList = null;
                var comid = HttpContext.Session.GetInt32("ComId");
                var refno = HttpContext.Session.GetString("RefNo");
                var printDate = DateTime.Parse(HttpContext.Session.GetString("PrintDate"));
                var multiselectData = HttpContext.Session.GetString("MultiSelectData");
                var groupLCId = 0;

                HttpContext.Session.SetString("ReportPath", "~/ReportViewer/CommercialReport/rptBLDraft_Export.rdlc");
                HttpContext.Session.SetString("ReportQuery", "Exec rptExportDocumentsAutomation '" + id + "', '" + comid + "', '" + refno + "','" + printDate + "','" + multiselectData + "','" + groupLCId + "'");


                string filename = _exportInvoiceMasterRepository.All().Where(x => x.Id == id).Select(x => x.BuyerInformation.Name + "_" + x.ShipModel.ShipName + "_" + x.Destination.DestinationName + "_" + x.InvoiceNo).Single();
                HttpContext.Session.SetString("PrintFileName", filename.Replace(".", "").Replace(" ", "").Replace(",", "").Replace("\"", ""));

                string DataSourceName = "DataSet1";

                clsReport.strReportPathMain = HttpContext.Session.GetString("ReportPath");
                clsReport.strQueryMain = HttpContext.Session.GetString("ReportQuery");
                clsReport.strDSNMain = DataSourceName;

                string callBackUrl = this.Url.Action("Index", "ReportViewer", new { reporttype = type });
                var redirectUrl = callBackUrl;


                return Json(new { Url = redirectUrl });
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }

        [AllowAnonymous]
        public ActionResult PrintKPT(int? id, string type)
        {
            try
            {
                clsReport.rptList = null;

                var comid = HttpContext.Session.GetInt32("ComId");
                var refno = HttpContext.Session.GetString("RefNo");
                var printDate = DateTime.Parse(HttpContext.Session.GetString("PrintDate"));
                var multiselectData = HttpContext.Session.GetString("MultiSelectData");
                var groupLCId = 0;

                HttpContext.Session.SetString("ReportPath", "~/ReportViewer/CommercialReport/rptKEPTKoreaPossible_Export.rdlc");
                HttpContext.Session.SetString("ReportQuery", "Exec rptExportDocumentsAutomation '" + id + "', '" + comid + "', '" + refno + "','" + printDate + "','" + multiselectData + "','" + groupLCId + "'");


                string filename = _exportInvoiceMasterRepository.All().Where(x => x.Id == id).Select(x => x.BuyerInformation.Name + "_" + x.ShipModel.ShipName + "_" + x.Destination.DestinationName + "_" + x.InvoiceNo).Single();
                HttpContext.Session.SetString("PrintFileName", filename.Replace(".", "").Replace(" ", "").Replace(",", "").Replace("\"", ""));

                string DataSourceName = "DataSet1";

                clsReport.strReportPathMain = HttpContext.Session.GetString("ReportPath");
                clsReport.strQueryMain = HttpContext.Session.GetString("ReportQuery");
                clsReport.strDSNMain = DataSourceName;

                string callBackUrl = this.Url.Action("Index", "ReportViewer", new { reporttype = type });
                var redirectUrl = callBackUrl;


                return Json(new { Url = redirectUrl });
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }

        [AllowAnonymous]
        public ActionResult PrintSAFTA(int? id, string type)
        {
            try
            {
                clsReport.rptList = null;
                var comid = HttpContext.Session.GetInt32("ComId");
                var refno = HttpContext.Session.GetString("RefNo");
                var printDate = DateTime.Parse(HttpContext.Session.GetString("PrintDate"));
                var multiselectData = HttpContext.Session.GetString("MultiSelectData");
                var groupLCId = 0;

                HttpContext.Session.SetString("ReportPath", "~/ReportViewer/CommercialReport/rptSAFTAforIndia_Export.rdlc");
                HttpContext.Session.SetString("ReportQuery", "Exec rptExportDocumentsAutomation '" + id + "', '" + comid + "', '" + refno + "','" + printDate + "','" + multiselectData + "','" + groupLCId + "'");


                string filename = _exportInvoiceMasterRepository.All().Where(x => x.Id == id).Select(x => x.BuyerInformation.Name + "_" + x.ShipModel.ShipName + "_" + x.Destination.DestinationName + "_" + x.InvoiceNo).Single();
                HttpContext.Session.SetString("PrintFileName", filename.Replace(".", "").Replace(" ", "").Replace(",", "").Replace("\"", ""));

                string DataSourceName = "DataSet1";

                clsReport.strReportPathMain = HttpContext.Session.GetString("ReportPath");
                clsReport.strQueryMain = HttpContext.Session.GetString("ReportQuery");
                clsReport.strDSNMain = DataSourceName;

                string callBackUrl = this.Url.Action("Index", "ReportViewer", new { reporttype = type });
                var redirectUrl = callBackUrl;


                return Json(new { Url = redirectUrl });

            }
            catch (Exception ex)
            {

                throw ex;
            }

        }
        [AllowAnonymous]
        public ActionResult PrintB255(int? id, string type)
        {
            try
            {
                clsReport.rptList = null;
                var comid = HttpContext.Session.GetInt32("ComId");
                var refno = HttpContext.Session.GetString("RefNo");
                var printDate = DateTime.Parse(HttpContext.Session.GetString("PrintDate"));
                var multiselectData = HttpContext.Session.GetString("MultiSelectData");
                var groupLCId = 0;

                HttpContext.Session.SetString("ReportPath", "~/ReportViewer/CommercialReport/rptB255E_Export.rdlc");
                HttpContext.Session.SetString("ReportQuery", "Exec rptExportDocumentsAutomation '" + id + "', '" + comid + "', '" + refno + "','" + printDate + "','" + multiselectData + "','" + groupLCId + "'");


                string filename = _exportInvoiceMasterRepository.All().Where(x => x.Id == id).Select(x => x.BuyerInformation.Name + "_" + x.ShipModel.ShipName + "_" + x.Destination.DestinationName + "_" + x.InvoiceNo).Single();
                HttpContext.Session.SetString("PrintFileName", filename.Replace(".", "").Replace(" ", "").Replace(",", "").Replace("\"", ""));

                string DataSourceName = "DataSet1";

                clsReport.strReportPathMain = HttpContext.Session.GetString("ReportPath");
                clsReport.strQueryMain = HttpContext.Session.GetString("ReportQuery");
                clsReport.strDSNMain = DataSourceName;

                string callBackUrl = this.Url.Action("Index", "ReportViewer", new { reporttype = type });
                var redirectUrl = callBackUrl;


                return Json(new { Url = redirectUrl });
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }

        [AllowAnonymous]
        public ActionResult PrintCanadaCustom(int? id, string type)
        {
            try
            {
                clsReport.rptList = null;
                var comid = HttpContext.Session.GetInt32("ComId");
                var refno = HttpContext.Session.GetString("RefNo");
                var printDate = DateTime.Parse(HttpContext.Session.GetString("PrintDate"));
                var multiselectData = HttpContext.Session.GetString("MultiSelectData");
                var groupLCId = 0;

                HttpContext.Session.SetString("ReportPath", "~/ReportViewer/CommercialReport/rptCanadaCustomInvoice.rdlc");
                HttpContext.Session.SetString("ReportQuery", "Exec rptExportDocumentsAutomation '" + id + "', '" + comid + "', '" + refno + "','" + printDate + "','" + multiselectData + "','" + groupLCId + "'");


                string filename = _exportInvoiceMasterRepository.All().Where(x => x.Id == id).Select(x => x.BuyerInformation.Name + "_" + x.ShipModel.ShipName + "_" + x.Destination.DestinationName + "_" + x.InvoiceNo).Single();
                HttpContext.Session.SetString("PrintFileName", filename.Replace(".", "").Replace(" ", "").Replace(",", "").Replace("\"", ""));

                string DataSourceName = "DataSet1";

                clsReport.strReportPathMain = HttpContext.Session.GetString("ReportPath");
                clsReport.strQueryMain = HttpContext.Session.GetString("ReportQuery");
                clsReport.strDSNMain = DataSourceName;

                string callBackUrl = this.Url.Action("Index", "ReportViewer", new { reporttype = type });
                var redirectUrl = callBackUrl;


                return Json(new { Url = redirectUrl });
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }

        [AllowAnonymous]
        public ActionResult PrintCOPE(int? id, string type)
        {
            try
            {
                clsReport.rptList = null;
                var comid = HttpContext.Session.GetInt32("ComId");
                var refno = HttpContext.Session.GetString("RefNo");
                var printDate = DateTime.Parse(HttpContext.Session.GetString("PrintDate"));
                var multiselectData = HttpContext.Session.GetString("MultiSelectData");


                HttpContext.Session.SetString("ReportPath", "~/ReportViewer/CommercialReport/rptCollectionOfProceeds_Export.rdlc");
                HttpContext.Session.SetString("ReportQuery", "Exec rptCollectionOfProceeds_Export '" + id + "', '" + comid + "', '" + refno + "','" + printDate + "'");


                string filename = "COP_" + _exportInvoiceMasterRepository.All().Where(x => x.Id == id).Select(x => x.BuyerInformation.Name + "_" + x.ShipModel.ShipName + "_" + x.Destination.DestinationName + "_" + x.InvoiceNo).Single();
                HttpContext.Session.SetString("PrintFileName", filename.Replace(".", "").Replace(" ", "").Replace(",", "").Replace("\"", ""));

                string DataSourceName = "DataSet1";

                clsReport.strReportPathMain = HttpContext.Session.GetString("ReportPath");
                clsReport.strQueryMain = HttpContext.Session.GetString("ReportQuery");
                clsReport.strDSNMain = DataSourceName;

                string callBackUrl = this.Url.Action("Index", "ReportViewer", new { reporttype = type });
                var redirectUrl = callBackUrl;


                return Json(new { Url = redirectUrl });
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }

        [AllowAnonymous]
        public ActionResult PrintCertificateOfOrigin(int? id, string type)
        {
            try
            {
                clsReport.rptList = null;
                var comid = HttpContext.Session.GetInt32("ComId");
                var refno = HttpContext.Session.GetString("RefNo");
                var printDate = DateTime.Parse(HttpContext.Session.GetString("PrintDate"));
                var multiselectData = HttpContext.Session.GetString("MultiSelectData");
                var groupLCId = 0;

                HttpContext.Session.SetString("ReportPath", "~/ReportViewer/CommercialReport/rptCertificateOfOrigin_Export.rdlc");
                HttpContext.Session.SetString("ReportQuery", "Exec rptExportDocumentsAutomation '" + id + "', '" + comid + "', '" + refno + "','" + printDate + "','" + multiselectData + "','" + groupLCId + "'");


                string filename = "CertificateOfOrigin_" + _exportInvoiceMasterRepository.All().Where(x => x.Id == id).Select(x => x.BuyerInformation.Name + "_" + x.ShipModel.ShipName + "_" + x.Destination.DestinationName + "_" + x.InvoiceNo).Single();
                HttpContext.Session.SetString("PrintFileName", filename.Replace(".", "").Replace(" ", "").Replace(",", "").Replace("\"", ""));

                string DataSourceName = "DataSet1";

                clsReport.strReportPathMain = HttpContext.Session.GetString("ReportPath");
                clsReport.strQueryMain = HttpContext.Session.GetString("ReportQuery");
                clsReport.strDSNMain = DataSourceName;

                string callBackUrl = this.Url.Action("Index", "ReportViewer", new { reporttype = type });
                var redirectUrl = callBackUrl;


                return Json(new { Url = redirectUrl });
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }

        [AllowAnonymous]
        public ActionResult PrintEPB(int? id, string type)
        {
            try
            {
                clsReport.rptList = null;
                var comid = HttpContext.Session.GetInt32("ComId");
                var refno = HttpContext.Session.GetString("RefNo");
                var printDate = DateTime.Parse(HttpContext.Session.GetString("PrintDate"));
                var multiselectData = HttpContext.Session.GetString("MultiSelectData");
                var groupLCId = 0;

                HttpContext.Session.SetString("ReportPath", "~/ReportViewer/CommercialReport/rptEPB_Export.rdlc");
                HttpContext.Session.SetString("ReportQuery", "Exec rptExportDocumentsAutomation '" + id + "', '" + comid + "', '" + refno + "','" + printDate + "','" + multiselectData + "','" + groupLCId + "'");


                string filename = "EPB_" + _exportInvoiceMasterRepository.All().Where(x => x.Id == id).Select(x => x.BuyerInformation.Name + "_" + x.ShipModel.ShipName + "_" + x.Destination.DestinationName + "_" + x.InvoiceNo).Single();
                HttpContext.Session.SetString("PrintFileName", filename.Replace(".", "").Replace(" ", "").Replace(",", "").Replace("\"", ""));

                string DataSourceName = "DataSet1";

                clsReport.strReportPathMain = HttpContext.Session.GetString("ReportPath");
                clsReport.strQueryMain = HttpContext.Session.GetString("ReportQuery");
                clsReport.strDSNMain = DataSourceName;

                string callBackUrl = this.Url.Action("Index", "ReportViewer", new { reporttype = type });
                var redirectUrl = callBackUrl;

                return Json(new { Url = redirectUrl });
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }

        [AllowAnonymous]
        public ActionResult PrintPriceList(int? id, string type)
        {
            try
            {
                clsReport.rptList = null;
                var comid = HttpContext.Session.GetInt32("ComId");
                var refno = HttpContext.Session.GetString("RefNo");
                var printDate = DateTime.Parse(HttpContext.Session.GetString("PrintDate"));
                var multiselectData = HttpContext.Session.GetString("MultiSelectData");
                var groupLCId = 0;

                HttpContext.Session.SetString("ReportPath", "~/ReportViewer/CommercialReport/rptOrderPriceList.rdlc");
                HttpContext.Session.SetString("ReportQuery", "Exec rptPriceList '" + id + "', '" + comid + "', '" + refno + "','" + printDate + "','" + multiselectData + "'");


                string filename = "PriceList_" + _exportInvoiceMasterRepository.All().Where(x => x.Id == id).Select(x => x.BuyerInformation.Name + "_" + x.ShipModel.ShipName + "_" + x.Destination.DestinationName + "_" + x.InvoiceNo).Single();
                HttpContext.Session.SetString("PrintFileName", filename.Replace(".", "").Replace(" ", "").Replace(",", "").Replace("\"", ""));

                string DataSourceName = "DataSet1";

                clsReport.strReportPathMain = HttpContext.Session.GetString("ReportPath");
                clsReport.strQueryMain = HttpContext.Session.GetString("ReportQuery");
                clsReport.strDSNMain = DataSourceName;

                string callBackUrl = this.Url.Action("Index", "ReportViewer", new { reporttype = type });
                var redirectUrl = callBackUrl;

                return Json(new { Url = redirectUrl });
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }

        [AllowAnonymous]
        public ActionResult PrintBillOfExchangeTwo(int? id, string type)
        {
            try
            {
                clsReport.rptList = null;
                var comid = HttpContext.Session.GetInt32("ComId");
                var refno = HttpContext.Session.GetString("RefNo");
                var printDate = DateTime.Parse(HttpContext.Session.GetString("PrintDate"));
                var multiselectData = HttpContext.Session.GetString("MultiSelectData");
                var groupLCId = 0;


                HttpContext.Session.SetString("ReportPath", "~/ReportViewer/CommercialReport/rptBillOfExchangeTwo_Export.rdlc");
                HttpContext.Session.SetString("ReportQuery", "Exec rptExportDocumentsAutomation '" + id + "', '" + comid + "', '" + refno + "','" + printDate + "','" + multiselectData + "','" + groupLCId + "'");


                string filename = "BillOfExchange_" + _exportInvoiceMasterRepository.All().Where(x => x.Id == id).Select(x => x.BuyerInformation.Name + "_" + x.ShipModel.ShipName + "_" + x.Destination.DestinationName + "_" + x.InvoiceNo).Single();
                HttpContext.Session.SetString("PrintFileName", filename.Replace(".", "").Replace(" ", "").Replace(",", "").Replace("\"", ""));

                string DataSourceName = "DataSet1";

                clsReport.strReportPathMain = HttpContext.Session.GetString("ReportPath");
                clsReport.strQueryMain = HttpContext.Session.GetString("ReportQuery");
                clsReport.strDSNMain = DataSourceName;

                string callBackUrl = this.Url.Action("Index", "ReportViewer", new { reporttype = type });
                var redirectUrl = callBackUrl;

                return Json(new { Url = redirectUrl });
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }

        [AllowAnonymous]
        public ActionResult PrintLDCStatement813(int? id, string type)
        {
            try
            {
                clsReport.rptList = null;
                var comid = HttpContext.Session.GetInt32("ComId");
                var refno = HttpContext.Session.GetString("RefNo");
                var printDate = DateTime.Parse(HttpContext.Session.GetString("PrintDate"));
                var multiselectData = HttpContext.Session.GetString("MultiSelectData");
                var groupLCId = 0;

                HttpContext.Session.SetString("ReportPath", "~/ReportViewer/CommercialReport/rptLDCStatement813.rdlc");
                HttpContext.Session.SetString("ReportQuery", "Exec rptExportDocumentsAutomation '" + id + "', '" + comid + "', '" + refno + "','" + printDate + "','" + multiselectData + "','" + groupLCId + "'");


                string filename = "LDCStatement813_" + _exportInvoiceMasterRepository.All().Where(x => x.Id == id).Select(x => x.BuyerInformation.Name + "_" + x.ShipModel.ShipName + "_" + x.Destination.DestinationName + "_" + x.InvoiceNo).Single();
                HttpContext.Session.SetString("PrintFileName", filename.Replace(".", "").Replace(" ", "").Replace(",", "").Replace("\"", ""));

                string DataSourceName = "DataSet1";

                clsReport.strReportPathMain = HttpContext.Session.GetString("ReportPath");
                clsReport.strQueryMain = HttpContext.Session.GetString("ReportQuery");
                clsReport.strDSNMain = DataSourceName;

                string callBackUrl = this.Url.Action("Index", "ReportViewer", new { reporttype = type });
                var redirectUrl = callBackUrl;

                return Json(new { Url = redirectUrl });
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }

        [AllowAnonymous]
        public ActionResult PrintProductionCertificate(int? id, string type)
        {
            try
            {
                clsReport.rptList = null;
                var comid = HttpContext.Session.GetInt32("ComId");
                var refno = HttpContext.Session.GetString("RefNo");
                var printDate = DateTime.Parse(HttpContext.Session.GetString("PrintDate"));
                var multiselectData = HttpContext.Session.GetString("MultiSelectData");
                var groupLCId = 0;

                HttpContext.Session.SetString("ReportPath", "~/ReportViewer/CommercialReport/rptProductionCertificate.rdlc");
                HttpContext.Session.SetString("ReportQuery", "Exec rptExportDocumentsAutomation '" + id + "', '" + comid + "', '" + refno + "','" + printDate + "','" + multiselectData + "','" + groupLCId + "'");


                string filename = "ProductionCertificate_" + _exportInvoiceMasterRepository.All().Where(x => x.Id == id).Select(x => x.BuyerInformation.Name + "_" + x.ShipModel.ShipName + "_" + x.Destination.DestinationName + "_" + x.InvoiceNo).Single();
                HttpContext.Session.SetString("PrintFileName", filename.Replace(".", "").Replace(" ", "").Replace(",", "").Replace("\"", ""));

                string DataSourceName = "DataSet1";

                clsReport.strReportPathMain = HttpContext.Session.GetString("ReportPath");
                clsReport.strQueryMain = HttpContext.Session.GetString("ReportQuery");
                clsReport.strDSNMain = DataSourceName;

                string callBackUrl = this.Url.Action("Index", "ReportViewer", new { reporttype = type });
                var redirectUrl = callBackUrl;

                return Json(new { Url = redirectUrl });
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }

        [AllowAnonymous]
        public ActionResult PrintBeneficiaryConfirmation785(int? id, string type)
        {
            try
            {
                clsReport.rptList = null;
                var comid = HttpContext.Session.GetInt32("ComId");
                var refno = HttpContext.Session.GetString("RefNo");
                var printDate = DateTime.Parse(HttpContext.Session.GetString("PrintDate"));
                var multiselectData = HttpContext.Session.GetString("MultiSelectData");
                var groupLCId = 0;

                HttpContext.Session.SetString("ReportPath", "~/ReportViewer/CommercialReport/rptBeneficiaryConfirmation785.rdlc");
                HttpContext.Session.SetString("ReportQuery", "Exec rptExportDocumentsAutomation '" + id + "', '" + comid + "', '" + refno + "','" + printDate + "','" + multiselectData + "','" + groupLCId + "'");


                string filename = "BeneficiaryConfirmation_" + _exportInvoiceMasterRepository.All().Where(x => x.Id == id).Select(x => x.BuyerInformation.Name + "_" + x.ShipModel.ShipName + "_" + x.Destination.DestinationName + "_" + x.InvoiceNo).Single();
                HttpContext.Session.SetString("PrintFileName", filename.Replace(".", "").Replace(" ", "").Replace(",", "").Replace("\"", ""));

                string DataSourceName = "DataSet1";

                clsReport.strReportPathMain = HttpContext.Session.GetString("ReportPath");
                clsReport.strQueryMain = HttpContext.Session.GetString("ReportQuery");
                clsReport.strDSNMain = DataSourceName;

                string callBackUrl = this.Url.Action("Index", "ReportViewer", new { reporttype = type });
                var redirectUrl = callBackUrl;

                return Json(new { Url = redirectUrl });
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }

        [AllowAnonymous]
        public ActionResult PrintSubmissionDOC(int? id, string type)
        {
            try
            {
                clsReport.rptList = null;
                var comid = HttpContext.Session.GetInt32("ComId");
                var refno = HttpContext.Session.GetString("RefNo");
                var printDate = DateTime.Parse(HttpContext.Session.GetString("PrintDate"));
                var multiselectData = HttpContext.Session.GetString("MultiSelectData");
                var groupLCId = 0;


                HttpContext.Session.SetString("ReportPath", "~/ReportViewer/CommercialReport/rptSubmissionDOC.rdlc");
                HttpContext.Session.SetString("ReportQuery", "Exec rptExportDocumentsAutomation '" + id + "', '" + comid + "', '" + refno + "','" + printDate + "','" + multiselectData + "','" + groupLCId + "'");


                string filename = "SubmissionDOC_" + _exportInvoiceMasterRepository.All().Where(x => x.Id == id).Select(x => x.BuyerInformation.Name + "_" + x.ShipModel.ShipName + "_" + x.Destination.DestinationName + "_" + x.InvoiceNo).Single();
                HttpContext.Session.SetString("PrintFileName", filename.Replace(".", "").Replace(" ", "").Replace(",", "").Replace("\"", ""));

                string DataSourceName = "DataSet1";

                clsReport.strReportPathMain = HttpContext.Session.GetString("ReportPath");
                clsReport.strQueryMain = HttpContext.Session.GetString("ReportQuery");
                clsReport.strDSNMain = DataSourceName;

                string callBackUrl = this.Url.Action("Index", "ReportViewer", new { reporttype = type });
                var redirectUrl = callBackUrl;

                return Json(new { Url = redirectUrl });
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }

        [AllowAnonymous]
        public ActionResult PrintIDMForm(int? id, string type)
        {
            try
            {
                clsReport.rptList = null;
                var comid = HttpContext.Session.GetInt32("ComId");
                var refno = HttpContext.Session.GetString("RefNo");
                var printDate = DateTime.Parse(HttpContext.Session.GetString("PrintDate"));
                var multiselectData = HttpContext.Session.GetString("MultiSelectData");
                var groupLCId = 0;

                HttpContext.Session.SetString("ReportPath", "~/ReportViewer/CommercialReport/rptIDMForm.rdlc");
                HttpContext.Session.SetString("ReportQuery", "Exec rptExportDocumentsAutomation '" + id + "', '" + comid + "', '" + refno + "','" + printDate + "','" + multiselectData + "','" + groupLCId + "'");


                string filename = "IDmForm_" + _exportInvoiceMasterRepository.All().Where(x => x.Id == id).Select(x => x.BuyerInformation.Name + "_" + x.ShipModel.ShipName + "_" + x.Destination.DestinationName + "_" + x.InvoiceNo).Single();
                HttpContext.Session.SetString("PrintFileName", filename.Replace(".", "").Replace(" ", "").Replace(",", "").Replace("\"", ""));

                string DataSourceName = "DataSet1";

                clsReport.strReportPathMain = HttpContext.Session.GetString("ReportPath");
                clsReport.strQueryMain = HttpContext.Session.GetString("ReportQuery");
                clsReport.strDSNMain = DataSourceName;

                string callBackUrl = this.Url.Action("Index", "ReportViewer", new { reporttype = type });
                var redirectUrl = callBackUrl;

                return Json(new { Url = redirectUrl });
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }

        [AllowAnonymous]
        public ActionResult PrintNewPackingDec(int? id, string type)
        {
            try
            {
                clsReport.rptList = null;
                var comid = HttpContext.Session.GetInt32("ComId");
                var refno = HttpContext.Session.GetString("RefNo");
                var printDate = DateTime.Parse(HttpContext.Session.GetString("PrintDate"));
                var multiselectData = HttpContext.Session.GetString("MultiSelectData");
                var groupLCId = 0;

                HttpContext.Session.SetString("ReportPath", "~/ReportViewer/CommercialReport/rptNewPackingDec.rdlc");
                HttpContext.Session.SetString("ReportQuery", "Exec rptExportDocumentsAutomation '" + id + "', '" + comid + "', '" + refno + "','" + printDate + "','" + multiselectData + "','" + groupLCId + "'");


                string filename = "BeneficiaryConfirmation_" + _exportInvoiceMasterRepository.All().Where(x => x.Id == id).Select(x => x.BuyerInformation.Name + "_" + x.ShipModel.ShipName + "_" + x.Destination.DestinationName + "_" + x.InvoiceNo).Single();
                HttpContext.Session.SetString("PrintFileName", filename.Replace(".", "").Replace(" ", "").Replace(",", "").Replace("\"", ""));

                string DataSourceName = "DataSet1";

                clsReport.strReportPathMain = HttpContext.Session.GetString("ReportPath");
                clsReport.strQueryMain = HttpContext.Session.GetString("ReportQuery");
                clsReport.strDSNMain = DataSourceName;

                string callBackUrl = this.Url.Action("Index", "ReportViewer", new { reporttype = type });
                var redirectUrl = callBackUrl;

                return Json(new { Url = redirectUrl });
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }
        [AllowAnonymous]
        public ActionResult PrintDOCWithoutIC(int? id, string type)
        {
            try
            {
                clsReport.rptList = null;
                var comid = HttpContext.Session.GetInt32("ComId");
                var refno = HttpContext.Session.GetString("RefNo");
                var printDate = DateTime.Parse(HttpContext.Session.GetString("PrintDate"));
                var multiselectData = HttpContext.Session.GetString("MultiSelectData");
                var groupLCId = 0;


                HttpContext.Session.SetString("ReportPath", "~/ReportViewer/CommercialReport/rptDOCWithoutIC.rdlc");
                HttpContext.Session.SetString("ReportQuery", "Exec rptExportDocumentsAutomation '" + id + "', '" + comid + "', '" + refno + "','" + printDate + "','" + multiselectData + "','" + groupLCId + "'");


                string filename = "DOCWithoutIC" + _exportInvoiceMasterRepository.All().Where(x => x.Id == id).Select(x => x.BuyerInformation.Name + "_" + x.ShipModel.ShipName + "_" + x.Destination.DestinationName + "_" + x.InvoiceNo).Single();
                HttpContext.Session.SetString("PrintFileName", filename.Replace(".", "").Replace(" ", "").Replace(",", "").Replace("\"", ""));

                string DataSourceName = "DataSet1";

                clsReport.strReportPathMain = HttpContext.Session.GetString("ReportPath");
                clsReport.strQueryMain = HttpContext.Session.GetString("ReportQuery");
                clsReport.strDSNMain = DataSourceName;

                string callBackUrl = this.Url.Action("Index", "ReportViewer", new { reporttype = type });
                var redirectUrl = callBackUrl;

                return Json(new { Url = redirectUrl });
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }

        [AllowAnonymous]
        public ActionResult PrintProformaInvoice(int? id, string type)
        {
            try
            {
                clsReport.rptList = null;
                var comid = HttpContext.Session.GetInt32("ComId");
                var refno = HttpContext.Session.GetString("RefNo");
                var printDate = HttpContext.Session.GetString("PrintDate");
                var multiselectData = HttpContext.Session.GetString("MultiSelectData");
                var groupLCId = 0;


                HttpContext.Session.SetString("ReportPath", "~/ReportViewer/CommercialReport/rptProformaInvoice_Nakano.rdlc");


                HttpContext.Session.SetString("ReportQuery", "Exec rptExportDocumentsAutomation '" + id + "', '" + comid + "', '" + refno + "','" + printDate + "','" + multiselectData + "','" + groupLCId + "'");

                string filename = "ProformaInvoice" + _exportInvoiceMasterRepository.All().Where(x => x.Id == id).Select(x => x.BuyerInformation.Name + "_" + x.ShipModel.ShipName + "_" + x.Destination.DestinationName + "_" + x.InvoiceNo).Single();
                HttpContext.Session.SetString("PrintFileName", filename.Replace(".", "").Replace(" ", "").Replace(",", "").Replace(" ", ""));


                string DataSourceName = "DataSet1";
                clsReport.strReportPathMain = HttpContext.Session.GetString("ReportPath");
                clsReport.strQueryMain = HttpContext.Session.GetString("ReportQuery");
                clsReport.strDSNMain = DataSourceName;

                string callBackUrl = this.Url.Action("Index", "ReportViewer", new { reporttype = type });
                var redirectUrl = callBackUrl;

                return Json(new { Url = redirectUrl });
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        [AllowAnonymous]
        public ActionResult PrintExportSalesContract(int? id, string type)
        {
            try
            {
                clsReport.rptList = null;
                var comid = HttpContext.Session.GetInt32("ComId");
                var refno = HttpContext.Session.GetString("RefNo");
                var printDate = HttpContext.Session.GetString("PrintDate");
                var multiselectData = HttpContext.Session.GetString("MultiSelectData");
                var groupLCId = 0;


                HttpContext.Session.SetString("ReportPath", "~/ReportViewer/CommercialReport/rptExportSalesContract_Nakano.rdlc");


                HttpContext.Session.SetString("ReportQuery", "Exec rptExportDocumentsAutomation '" + id + "', '" + comid + "', '" + refno + "','" + printDate + "','" + multiselectData + "','" + groupLCId + "'");

                string filename = "SalesContract" + _exportInvoiceMasterRepository.All().Where(x => x.Id == id).Select(x => x.BuyerInformation.Name + "_" + x.ShipModel.ShipName + "_" + x.Destination.DestinationName + "_" + x.InvoiceNo).Single();
                HttpContext.Session.SetString("PrintFileName", filename.Replace(".", "").Replace(" ", "").Replace(",", "").Replace(" ", ""));


                string DataSourceName = "DataSet1";
                clsReport.strReportPathMain = HttpContext.Session.GetString("ReportPath");
                clsReport.strQueryMain = HttpContext.Session.GetString("ReportQuery");
                clsReport.strDSNMain = DataSourceName;

                string callBackUrl = this.Url.Action("Index", "ReportViewer", new { reporttype = type });
                var redirectUrl = callBackUrl;

                return Json(new { Url = redirectUrl });
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        [AllowAnonymous]
        public ActionResult PrintBankCertificate(int? id, string type)
        {
            try
            {
                clsReport.rptList = null;
                var comid = HttpContext.Session.GetInt32("ComId");
                var refno = HttpContext.Session.GetString("RefNo");
                var printDate = HttpContext.Session.GetString("PrintDate");
                var multiselectData = HttpContext.Session.GetString("MultiSelectData");
                var groupLCId = 0;


                HttpContext.Session.SetString("ReportPath", "~/ReportViewer/CommercialReport/rptExport_BankCertificate.rdlc");


                HttpContext.Session.SetString("ReportQuery", "Exec rptExportDocumentsAutomation '" + id + "', '" + comid + "', '" + refno + "','" + printDate + "','" + multiselectData + "','" + groupLCId + "'");

                string filename = "ProformaInvoice" + _exportInvoiceMasterRepository.All().Where(x => x.Id == id).Select(x => x.BuyerInformation.Name + "_" + x.ShipModel.ShipName + "_" + x.Destination.DestinationName + "_" + x.InvoiceNo).Single();
                HttpContext.Session.SetString("PrintFileName", filename.Replace(".", "").Replace(" ", "").Replace(",", "").Replace(" ", ""));


                string DataSourceName = "DataSet1";
                clsReport.strReportPathMain = HttpContext.Session.GetString("ReportPath");
                clsReport.strQueryMain = HttpContext.Session.GetString("ReportQuery");
                clsReport.strDSNMain = DataSourceName;

                string callBackUrl = this.Url.Action("Index", "ReportViewer", new { reporttype = type });
                var redirectUrl = callBackUrl;

                return Json(new { Url = redirectUrl });
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        [AllowAnonymous]
        public ActionResult PrintCIFCIPFOB(int? id, string type)
        {
            try
            {
                clsReport.rptList = null;
                var comid = HttpContext.Session.GetInt32("ComId");
                var refno = HttpContext.Session.GetString("RefNo");
                var printDate = HttpContext.Session.GetString("PrintDate");
                var multiselectData = HttpContext.Session.GetString("MultiSelectData");
                var groupLCId = 0;


                HttpContext.Session.SetString("ReportPath", "~/ReportViewer/CommercialReport/rptExport_CIFCIPFOB.rdlc");


                HttpContext.Session.SetString("ReportQuery", "Exec rptExportDocumentsAutomation '" + id + "', '" + comid + "', '" + refno + "','" + printDate + "','" + multiselectData + "','" + groupLCId + "'");

                string filename = "ProformaInvoice" + _exportInvoiceMasterRepository.All().Where(x => x.Id == id).Select(x => x.BuyerInformation.Name + "_" + x.ShipModel.ShipName + "_" + x.Destination.DestinationName + "_" + x.InvoiceNo).Single();
                HttpContext.Session.SetString("PrintFileName", filename.Replace(".", "").Replace(" ", "").Replace(",", "").Replace(" ", ""));


                string DataSourceName = "DataSet1";
                clsReport.strReportPathMain = HttpContext.Session.GetString("ReportPath");
                clsReport.strQueryMain = HttpContext.Session.GetString("ReportQuery");
                clsReport.strDSNMain = DataSourceName;

                string callBackUrl = this.Url.Action("Index", "ReportViewer", new { reporttype = type });
                var redirectUrl = callBackUrl;

                return Json(new { Url = redirectUrl });
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        [AllowAnonymous]
        public ActionResult PrintUndertaking(int? id, string type)
        {
            try
            {
                clsReport.rptList = null;
                var comid = HttpContext.Session.GetInt32("ComId");
                var refno = HttpContext.Session.GetString("RefNo");
                var printDate = HttpContext.Session.GetString("PrintDate");
                var multiselectData = HttpContext.Session.GetString("MultiSelectData");
                var groupLCId = 0;


                HttpContext.Session.SetString("ReportPath", "~/ReportViewer/CommercialReport/rptExportInvoice_Undertaking.rdlc");


                HttpContext.Session.SetString("ReportQuery", "Exec rptExportDocumentsAutomation '" + id + "', '" + comid + "', '" + refno + "','" + printDate + "','" + multiselectData + "','" + groupLCId + "'");

                string filename = "ProformaInvoice" + _exportInvoiceMasterRepository.All().Where(x => x.Id == id).Select(x => x.BuyerInformation.Name + "_" + x.ShipModel.ShipName + "_" + x.Destination.DestinationName + "_" + x.InvoiceNo).Single();
                HttpContext.Session.SetString("PrintFileName", filename.Replace(".", "").Replace(" ", "").Replace(",", "").Replace(" ", ""));


                string DataSourceName = "DataSet1";
                clsReport.strReportPathMain = HttpContext.Session.GetString("ReportPath");
                clsReport.strQueryMain = HttpContext.Session.GetString("ReportQuery");
                clsReport.strDSNMain = DataSourceName;

                string callBackUrl = this.Url.Action("Index", "ReportViewer", new { reporttype = type });
                var redirectUrl = callBackUrl;

                return Json(new { Url = redirectUrl });
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        [AllowAnonymous]
        public ActionResult PrintOutPass(int? id, string type)
        {
            try
            {
                clsReport.rptList = null;
                var comid = HttpContext.Session.GetInt32("ComId");
                var refno = HttpContext.Session.GetString("RefNo");
                var printDate = HttpContext.Session.GetString("PrintDate");
                var multiselectData = HttpContext.Session.GetString("MultiSelectData");
                var groupLCId = 0;


                HttpContext.Session.SetString("ReportPath", "~/ReportViewer/CommercialReport/rptExport_OutPass.rdlc");


                HttpContext.Session.SetString("ReportQuery", "Exec rptExportDocumentsAutomation '" + id + "', '" + comid + "', '" + refno + "','" + printDate + "','" + multiselectData + "','" + groupLCId + "'");

                string filename = "ProformaInvoice" + _exportInvoiceMasterRepository.All().Where(x => x.Id == id).Select(x => x.BuyerInformation.Name + "_" + x.ShipModel.ShipName + "_" + x.Destination.DestinationName + "_" + x.InvoiceNo).Single();
                HttpContext.Session.SetString("PrintFileName", filename.Replace(".", "").Replace(" ", "").Replace(",", "").Replace(" ", ""));


                string DataSourceName = "DataSet1";
                clsReport.strReportPathMain = HttpContext.Session.GetString("ReportPath");
                clsReport.strQueryMain = HttpContext.Session.GetString("ReportQuery");
                clsReport.strDSNMain = DataSourceName;

                string callBackUrl = this.Url.Action("Index", "ReportViewer", new { reporttype = type });
                var redirectUrl = callBackUrl;

                return Json(new { Url = redirectUrl });
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        [AllowAnonymous]
        public ActionResult PrintOutPassBn(int? id, string type)
        {
            try
            {
                clsReport.rptList = null;
                var comid = HttpContext.Session.GetInt32("ComId");
                var refno = HttpContext.Session.GetString("RefNo");
                var printDate = HttpContext.Session.GetString("PrintDate");
                var multiselectData = HttpContext.Session.GetString("MultiSelectData");
                var groupLCId = 0;


                HttpContext.Session.SetString("ReportPath", "~/ReportViewer/CommercialReport/rptCommercialInvoice_Export_PRIMARK_CMT_OutPass.rdlc");


                HttpContext.Session.SetString("ReportQuery", "Exec rptExportDocumentsAutomation '" + id + "', '" + comid + "', '" + refno + "','" + printDate + "','" + multiselectData + "','" + groupLCId + "'");

                string filename = "ProformaInvoice" + _exportInvoiceMasterRepository.All().Where(x => x.Id == id).Select(x => x.BuyerInformation.Name + "_" + x.ShipModel.ShipName + "_" + x.Destination.DestinationName + "_" + x.InvoiceNo).Single();
                HttpContext.Session.SetString("PrintFileName", filename.Replace(".", "").Replace(" ", "").Replace(",", "").Replace(" ", ""));


                string DataSourceName = "DataSet1";
                clsReport.strReportPathMain = HttpContext.Session.GetString("ReportPath");
                clsReport.strQueryMain = HttpContext.Session.GetString("ReportQuery");
                clsReport.strDSNMain = DataSourceName;

                string callBackUrl = this.Url.Action("Index", "ReportViewer", new { reporttype = type });
                var redirectUrl = callBackUrl;

                return Json(new { Url = redirectUrl });
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        [AllowAnonymous]
        public ActionResult PrintOutPassChoice(int? id, string type)
        {
            try
            {
                clsReport.rptList = null;
                var comid = HttpContext.Session.GetInt32("ComId");
                var refno = HttpContext.Session.GetString("RefNo");
                var printDate = HttpContext.Session.GetString("PrintDate");
                var multiselectData = HttpContext.Session.GetString("MultiSelectData");
                var groupLCId = 0;


                HttpContext.Session.SetString("ReportPath", "~/ReportViewer/CommercialReport/rptCommercialInvoice_Export_PROGRESS_OutPass.rdlc");


                HttpContext.Session.SetString("ReportQuery", "Exec rptExportDocumentsAutomation '" + id + "', '" + comid + "', '" + refno + "','" + printDate + "','" + multiselectData + "','" + groupLCId + "'");

                string filename = "ProformaInvoice" + _exportInvoiceMasterRepository.All().Where(x => x.Id == id).Select(x => x.BuyerInformation.Name + "_" + x.ShipModel.ShipName + "_" + x.Destination.DestinationName + "_" + x.InvoiceNo).Single();
                HttpContext.Session.SetString("PrintFileName", filename.Replace(".", "").Replace(" ", "").Replace(",", "").Replace(" ", ""));


                string DataSourceName = "DataSet1";
                clsReport.strReportPathMain = HttpContext.Session.GetString("ReportPath");
                clsReport.strQueryMain = HttpContext.Session.GetString("ReportQuery");
                clsReport.strDSNMain = DataSourceName;

                string callBackUrl = this.Url.Action("Index", "ReportViewer", new { reporttype = type });
                var redirectUrl = callBackUrl;

                return Json(new { Url = redirectUrl });
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        [AllowAnonymous]
        public ActionResult PrintOutPassEn(int? id, string type)
        {
            try
            {
                clsReport.rptList = null;
                var comid = HttpContext.Session.GetInt32("ComId");
                var refno = HttpContext.Session.GetString("RefNo");
                var printDate = HttpContext.Session.GetString("PrintDate");
                var multiselectData = HttpContext.Session.GetString("MultiSelectData");
                var groupLCId = 0;


                HttpContext.Session.SetString("ReportPath", "~/ReportViewer/CommercialReport/rptCommercialInvoice_Export_PRIMARK_CMT_OutPassEng.rdlc");


                HttpContext.Session.SetString("ReportQuery", "Exec rptExportDocumentsAutomation '" + id + "', '" + comid + "', '" + refno + "','" + printDate + "','" + multiselectData + "','" + groupLCId + "'");

                string filename = "ProformaInvoice" + _exportInvoiceMasterRepository.All().Where(x => x.Id == id).Select(x => x.BuyerInformation.Name + "_" + x.ShipModel.ShipName + "_" + x.Destination.DestinationName + "_" + x.InvoiceNo).Single();
                HttpContext.Session.SetString("PrintFileName", filename.Replace(".", "").Replace(" ", "").Replace(",", "").Replace(" ", ""));


                string DataSourceName = "DataSet1";
                clsReport.strReportPathMain = HttpContext.Session.GetString("ReportPath");
                clsReport.strQueryMain = HttpContext.Session.GetString("ReportQuery");
                clsReport.strDSNMain = DataSourceName;

                string callBackUrl = this.Url.Action("Index", "ReportViewer", new { reporttype = type });
                var redirectUrl = callBackUrl;

                return Json(new { Url = redirectUrl });
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }


        [AllowAnonymous]
        public ActionResult PrintUndertakingChoice(int? id, string type)
        {
            try
            {
                clsReport.rptList = null;
                var comid = HttpContext.Session.GetInt32("ComId");
                var refno = HttpContext.Session.GetString("RefNo");
                var printDate = HttpContext.Session.GetString("PrintDate");
                var multiselectData = HttpContext.Session.GetString("MultiSelectData");
                var groupLCId = 0;


                HttpContext.Session.SetString("ReportPath", "~/ReportViewer/CommercialReport/rptCommercialInvoice_Export_PROGRESS_Undertaking.rdlc");


                HttpContext.Session.SetString("ReportQuery", "Exec rptExportDocumentsAutomation '" + id + "', '" + comid + "', '" + refno + "','" + printDate + "','" + multiselectData + "','" + groupLCId + "'");

                string filename = "ProformaInvoice" + _exportInvoiceMasterRepository.All().Where(x => x.Id == id).Select(x => x.BuyerInformation.Name + "_" + x.ShipModel.ShipName + "_" + x.Destination.DestinationName + "_" + x.InvoiceNo).Single();
                HttpContext.Session.SetString("PrintFileName", filename.Replace(".", "").Replace(" ", "").Replace(",", "").Replace(" ", ""));


                string DataSourceName = "DataSet1";
                clsReport.strReportPathMain = HttpContext.Session.GetString("ReportPath");
                clsReport.strQueryMain = HttpContext.Session.GetString("ReportQuery");
                clsReport.strDSNMain = DataSourceName;

                string callBackUrl = this.Url.Action("Index", "ReportViewer", new { reporttype = type });
                var redirectUrl = callBackUrl;

                return Json(new { Url = redirectUrl });
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        [AllowAnonymous]
        public ActionResult PrintUndertakingProg(int? id, string type)
        {
            try
            {
                clsReport.rptList = null;
                var comid = HttpContext.Session.GetInt32("ComId");
                var refno = HttpContext.Session.GetString("RefNo");
                var printDate = HttpContext.Session.GetString("PrintDate");
                var multiselectData = HttpContext.Session.GetString("MultiSelectData");
                var groupLCId = 0;


                HttpContext.Session.SetString("ReportPath", "~/ReportViewer/CommercialReport/rptCommercialInvoice_Export_Undertaking_Prog.rdlc");


                HttpContext.Session.SetString("ReportQuery", "Exec rptExportDocumentsAutomation '" + id + "', '" + comid + "', '" + refno + "','" + printDate + "','" + multiselectData + "','" + groupLCId + "'");

                string filename = "ProformaInvoice" + _exportInvoiceMasterRepository.All().Where(x => x.Id == id).Select(x => x.BuyerInformation.Name + "_" + x.ShipModel.ShipName + "_" + x.Destination.DestinationName + "_" + x.InvoiceNo).Single();
                HttpContext.Session.SetString("PrintFileName", filename.Replace(".", "").Replace(" ", "").Replace(",", "").Replace(" ", ""));


                string DataSourceName = "DataSet1";
                clsReport.strReportPathMain = HttpContext.Session.GetString("ReportPath");
                clsReport.strQueryMain = HttpContext.Session.GetString("ReportQuery");
                clsReport.strDSNMain = DataSourceName;

                string callBackUrl = this.Url.Action("Index", "ReportViewer", new { reporttype = type });
                var redirectUrl = callBackUrl;

                return Json(new { Url = redirectUrl });
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        [AllowAnonymous]
        public ActionResult PrintOutPassSains(int? id, string type)
        {
            try
            {
                clsReport.rptList = null;
                var comid = HttpContext.Session.GetInt32("ComId");
                var refno = HttpContext.Session.GetString("RefNo");
                var printDate = HttpContext.Session.GetString("PrintDate");
                var multiselectData = HttpContext.Session.GetString("MultiSelectData");
                var groupLCId = 0;


                HttpContext.Session.SetString("ReportPath", "~/ReportViewer/CommercialReport/rptCommercialInvoice_Export_SAINSBURY_OutPass.rdlc");


                HttpContext.Session.SetString("ReportQuery", "Exec rptExportDocumentsAutomation '" + id + "', '" + comid + "', '" + refno + "','" + printDate + "','" + multiselectData + "','" + groupLCId + "'");

                string filename = "ProformaInvoice" + _exportInvoiceMasterRepository.All().Where(x => x.Id == id).Select(x => x.BuyerInformation.Name + "_" + x.ShipModel.ShipName + "_" + x.Destination.DestinationName + "_" + x.InvoiceNo).Single();
                HttpContext.Session.SetString("PrintFileName", filename.Replace(".", "").Replace(" ", "").Replace(",", "").Replace(" ", ""));


                string DataSourceName = "DataSet1";
                clsReport.strReportPathMain = HttpContext.Session.GetString("ReportPath");
                clsReport.strQueryMain = HttpContext.Session.GetString("ReportQuery");
                clsReport.strDSNMain = DataSourceName;

                string callBackUrl = this.Url.Action("Index", "ReportViewer", new { reporttype = type });
                var redirectUrl = callBackUrl;

                return Json(new { Url = redirectUrl });
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        [AllowAnonymous]
        public ActionResult PrintUndertakingPrimark(int? id, string type)
        {
            try
            {
                clsReport.rptList = null;
                var comid = HttpContext.Session.GetInt32("ComId");
                var refno = HttpContext.Session.GetString("RefNo");
                var printDate = HttpContext.Session.GetString("PrintDate");
                var multiselectData = HttpContext.Session.GetString("MultiSelectData");
                var groupLCId = 0;


                HttpContext.Session.SetString("ReportPath", "~/ReportViewer/CommercialReport/rptCommercialInvoice_Export_Primark_Undertaking.rdlc");


                HttpContext.Session.SetString("ReportQuery", "Exec rptExportDocumentsAutomation '" + id + "', '" + comid + "', '" + refno + "','" + printDate + "','" + multiselectData + "','" + groupLCId + "'");

                string filename = "ProformaInvoice" + _exportInvoiceMasterRepository.All().Where(x => x.Id == id).Select(x => x.BuyerInformation.Name + "_" + x.ShipModel.ShipName + "_" + x.Destination.DestinationName + "_" + x.InvoiceNo).Single();
                HttpContext.Session.SetString("PrintFileName", filename.Replace(".", "").Replace(" ", "").Replace(",", "").Replace(" ", ""));


                string DataSourceName = "DataSet1";
                clsReport.strReportPathMain = HttpContext.Session.GetString("ReportPath");
                clsReport.strQueryMain = HttpContext.Session.GetString("ReportQuery");
                clsReport.strDSNMain = DataSourceName;

                string callBackUrl = this.Url.Action("Index", "ReportViewer", new { reporttype = type });
                var redirectUrl = callBackUrl;

                return Json(new { Url = redirectUrl });
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        [AllowAnonymous]
        public ActionResult PrintOutPassPrimark(int? id, string type)
        {
            try
            {
                clsReport.rptList = null;
                var comid = HttpContext.Session.GetInt32("ComId");
                var refno = HttpContext.Session.GetString("RefNo");
                var printDate = HttpContext.Session.GetString("PrintDate");
                var multiselectData = HttpContext.Session.GetString("MultiSelectData");
                var groupLCId = 0;


                HttpContext.Session.SetString("ReportPath", "~/ReportViewer/CommercialReport/rptCommercialInvoice_Export_Primark_OutPass.rdlc");


                HttpContext.Session.SetString("ReportQuery", "Exec rptExportDocumentsAutomation '" + id + "', '" + comid + "', '" + refno + "','" + printDate + "','" + multiselectData + "','" + groupLCId + "'");

                string filename = "ProformaInvoice" + _exportInvoiceMasterRepository.All().Where(x => x.Id == id).Select(x => x.BuyerInformation.Name + "_" + x.ShipModel.ShipName + "_" + x.Destination.DestinationName + "_" + x.InvoiceNo).Single();
                HttpContext.Session.SetString("PrintFileName", filename.Replace(".", "").Replace(" ", "").Replace(",", "").Replace(" ", ""));


                string DataSourceName = "DataSet1";
                clsReport.strReportPathMain = HttpContext.Session.GetString("ReportPath");
                clsReport.strQueryMain = HttpContext.Session.GetString("ReportQuery");
                clsReport.strDSNMain = DataSourceName;

                string callBackUrl = this.Url.Action("Index", "ReportViewer", new { reporttype = type });
                var redirectUrl = callBackUrl;

                return Json(new { Url = redirectUrl });
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        #endregion

        #region Import Document

        [AllowAnonymous]
        public IActionResult AddImportDocument(int Id = 0)
        {

            ViewBag.ActionType = "Create";
            ViewBag.commercialInvoiceId = Id;
            ViewBag.ItemDescList = itemDescriptionRepository.GetAllForDropDown();
            ViewBag.ContainerList = _containerRepository.GetAllForDropDown();
            ViewBag.UnitList = unitRepository.GetAllForDropDown();
            return View();
        }

        [AllowAnonymous]
        public IActionResult UpdateImportDocument(int Id = 0)
        {

            ViewBag.ActionType = "Edit";
            ViewBag.commercialInvoiceId = Id;
            ViewBag.ItemDescList = itemDescriptionRepository.GetAllForDropDown();
            ViewBag.ContainerList = _containerRepository.GetAllForDropDown();
            ViewBag.UnitList = unitRepository.GetAllForDropDown();
            return View("AddImportDocument");
        }

        [AllowAnonymous]
        public JsonResult GetItemDespSearchList(int pageNo = 1, decimal pageSize = 10, string searchquery = "", string dropdownSearch = "")
        {
            try
            {
                //var products= _context.Products.ToList();
                if (dropdownSearch == null)
                {
                    dropdownSearch = "";
                }
                var productlist = itemDescriptionRepository.All().Where(x => x.IsDelete == false);

                if (searchquery?.Length > 1)
                {
                    var searchitem = JsonConvert.DeserializeObject<ItemListFilterData>(searchquery);

                    if (searchitem.pageIndex != null)
                    {
                        pageNo = searchitem.pageIndex.GetValueOrDefault(); // || x.Code.ToLower().Contains(searchitem.Name.ToLower())
                        pageSize = searchitem.pageSize.GetValueOrDefault(); // || x.Code.ToLower().Contains(searchitem.Name.ToLower())


                    }

                    if (searchitem.ItemDescCode != null)
                    {
                        productlist = productlist.Where(x => x.ItemDescCode.ToLower().Contains(searchitem.ItemDescCode.ToLower())); // || x.Code.ToLower().Contains(searchitem.Name.ToLower())

                    }

                    if (searchitem.ItemDescName != null)
                    {
                        productlist = productlist.Where(x => x.ItemDescName.ToLower().Contains(searchitem.ItemDescName.ToLower())); // || x.Code.ToLower().Contains(searchitem.Name.ToLower())

                    }

                }

                if ((dropdownSearch.Length > 1) || (dropdownSearch == ""))
                {
                    productlist = productlist.Where(x => x.ItemDescCode.ToLower().Contains(dropdownSearch.ToLower()) || x.ItemDescName.ToLower().Contains(dropdownSearch.ToLower()));
                }



                decimal TotalRecordCount = productlist.Count();
                var PageCountabc = decimal.Parse((TotalRecordCount / pageSize).ToString());
                var PageCount = Math.Ceiling(PageCountabc);





                decimal skip = (pageNo - 1) * pageSize;

                // Get total number of records
                int total = productlist.Count();



                var query = from e in productlist
                            select new
                            {
                                Id = e.Id,
                                ItemDescname = e.ItemDescName
                            };


                var abcd = query.OrderByDescending(x => x.Id).Skip(int.Parse(skip.ToString())).Take(int.Parse(pageSize.ToString())).ToList();// Take(50);
                var pageinfo = new PagingInfo();
                pageinfo.PageCount = int.Parse(PageCount.ToString());
                pageinfo.PageNo = pageNo;
                pageinfo.PageSize = int.Parse(pageSize.ToString());
                pageinfo.TotalRecordCount = int.Parse(TotalRecordCount.ToString());

                return Json(new { Success = 1, error = false, ProductList = abcd, PageInfo = pageinfo });


            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        [AllowAnonymous]
        public JsonResult GetImportDocumentList(string fromDate = "", string toDate = "", int supplierid = 0, int concernid = 0, int page = 1, decimal size = 5, string searchquery = "", string dropdownSearch = "")
        {
            try
            {
                var CurrentUserId = HttpContext.Session.GetInt32("UserId");
                var ComId = HttpContext.Session.GetInt32("ComId");
                var purchaselist = importCIMasterRepository.All();
                if (concernid > 0)
                {
                    purchaselist = importCIMasterRepository.All().Where(x => x.CommercialCompanyID == concernid);
                }
                if (!string.IsNullOrEmpty(fromDate))
                {
                    DateTime fromDateValue = Convert.ToDateTime(fromDate);
                    purchaselist = importCIMasterRepository.All().Where(x => x.CIDate >= fromDateValue.Date);
                }
                if (!string.IsNullOrEmpty(toDate))
                {
                    DateTime toDateValue = Convert.ToDateTime(toDate);
                    purchaselist = importCIMasterRepository.All().Where(x => x.CIDate >= toDateValue.Date);
                }

                if (searchquery?.Length > 1)
                {
                    purchaselist = purchaselist.Where(x =>
                        x.CICode.ToLower().Contains(searchquery.ToLower())
                    );

                }

                if ((dropdownSearch.Length > 1) || (dropdownSearch == ""))
                {
                    purchaselist = purchaselist.Where(x => x.CICode.ToLower().Contains(dropdownSearch.ToLower()));
                }


                decimal TotalRecordCount = purchaselist.Count();
                var PageCountabc = decimal.Parse((TotalRecordCount / size).ToString());
                var PageCount = Math.Ceiling(PageCountabc);



                decimal skip = (page - 1) * size;
                var query = from e in purchaselist
                            select new
                            {
                                Id = e.Id,
                                e.ComId,
                                e.CICode
                            };
                var abcd = query.OrderByDescending(x => x.Id).Skip(int.Parse(skip.ToString())).Take(int.Parse(size.ToString())).ToList();// Take(50);
                var pageinfo = new PagingInfo();
                pageinfo.PageCount = int.Parse(PageCount.ToString());
                pageinfo.PageNo = page;
                pageinfo.PageSize = int.Parse(size.ToString());
                pageinfo.TotalRecordCount = int.Parse(TotalRecordCount.ToString());
                return Json(new { Success = 1, error = false, data = abcd, page = page, size = size, last_page = pageinfo.PageCount, total = pageinfo.TotalRecordCount });
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        [AllowAnonymous]
        [HttpPost]
        public IActionResult ImportDocumentCreation([FromBody] ImportCI_Master model)
        {
            try
            {

                var ComId = HttpContext.Session.GetInt32("ComId");
                var UserId = HttpContext.Session.GetInt32("UserId");

                if (model.Id == 0)
                {
                    importCIMasterRepository.Insert(model);
                    return Json(new { error = false, message = "Import Document saved successfully" });

                }
                else
                {

                    importCIMasterRepository.Update(model, model.Id);

                    var data = importCIDetailsRepository.All().Where(x => x.ImportCIMasterId == model.Id).ToList();
                    foreach (var item in data)
                    {
                        var childData = importCIContainerRepository.All().Where(x => x.ImportCI_DetailsId == item.Id).ToList();
                        importCIContainerRepository.RemoveRange(childData);

                        importCIDetailsRepository.Delete(item);
                    }

                    foreach (var item in model.ImportCI_DetailsList)
                    {
                        item.ImportCIMasterId = model.Id;
                        item.Id = 0;

                        importCIDetailsRepository.Insert(item);


                    }

                    return Json(new { error = false, message = "Import Document Updated successfully" });

                }

            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        [HttpGet]
        [AllowAnonymous]

        public JsonResult DeleteImportDocument(int id)
        {
            try
            {


                var model = importCIMasterRepository.Find(id);
                var data = importCIDetailsRepository.All().Where(x => x.ImportCIMasterId == id).ToList();
                foreach (var item in data)
                {
                    var childData = importCIContainerRepository.All().Where(x => x.ImportCI_DetailsId == item.Id).ToList();
                    importCIContainerRepository.RemoveRange(childData);

                    importCIDetailsRepository.Delete(item);
                }


                if (model != null)
                {
                    importCIMasterRepository.Delete(model);

                    return Json(new { success = "1", msg = "Deleted Successfully" });
                }
                return Json(new { success = "0", msg = "No items found to delete." });

            }
            catch (Exception ex)
            {
                return Json(new { success = "0", msg = "No items found to delete." }); //msg = ex.ToString()
                throw ex;
            }
        }

        [HttpGet]
        [AllowAnonymous]
        public IActionResult GetImportDocumentDetails(int id)
        {

            var ComId = HttpContext.Session.GetInt32("ComId");

            SqlParameter[] sqlParameter1 = new SqlParameter[2];

            sqlParameter1[0] = new SqlParameter("@Id", id);
            sqlParameter1[1] = new SqlParameter("@Comid", ComId);

            var datasetabc = new System.Data.DataSet();
            datasetabc = Helper.ExecProcMapDS("GetImportDocumentDetails", sqlParameter1);

            var masterTable = datasetabc.Tables[0];
            var detailsTable = datasetabc.Tables[1];
            var packingTable = datasetabc.Tables[2];

            return Json(new { Success = 1, data = masterTable, details = detailsTable, packing = packingTable, ex = "Data Loaded Successfully" });
        }

        [AllowAnonymous]
        public IActionResult GetImportDocumentList1(string fromDate = "", string toDate = "", int? CommercialCompanyId = 0, int page = 1, decimal size = 5, string searchquery = "")
        {
            try
            {
                var CurrentUserId = HttpContext.Session.GetInt32("UserId");
                var ComId = HttpContext.Session.GetInt32("ComId");
                DateTime fromDateValue = Convert.ToDateTime(fromDate);
                DateTime toDateValue = Convert.ToDateTime(toDate);
                var purchaselist = importCIMasterRepository.All().Where(x => x.IsDelete == false);

                var taburesquest = JsonConvert.DeserializeObject<TabulatorRequest>(searchquery);

                if (taburesquest.Filter.Count == 0)
                {
                    purchaselist = purchaselist.Where(x => x.CIDate >= fromDateValue.Date && x.CIDate <= toDateValue.Date);

                }

                if (CommercialCompanyId > 0)
                {
                    purchaselist = purchaselist.Where(x => x.CommercialCompanyID == CommercialCompanyId);
                }

                decimal TotalRecordCount = purchaselist.Count();
                var PageCountabc = decimal.Parse((TotalRecordCount / taburesquest.Size).ToString());
                var PageCount = Math.Ceiling(PageCountabc);

                int skip = (taburesquest.Page - 1) * taburesquest.Size;

                var query = from p in purchaselist.Include(x => x.CommercialCompany)
                            select new
                            {
                                Id = p.Id,
                                p.ComId,
                                CICode = p.CICode,
                                PortOfLoadingId = p.PortOfLoading.PortOfLoadingName,
                                PortOfDischargeId = p.PortOfDischarge.PortOfDischargeName,
                                CIDate = p.CIDate != null ? p.CIDate.ToString("dd-MMM-yyyy") : null,

                            };
                var abcd = query.OrderByDescending(x => x.Id).Skip(skip).Take(taburesquest.Size).ToList();
                var pageinfo = new PagingInfo();
                pageinfo.PageCount = int.Parse(PageCount.ToString());
                pageinfo.PageNo = taburesquest.Page;
                pageinfo.PageSize = taburesquest.Size;
                pageinfo.TotalRecordCount = int.Parse(TotalRecordCount.ToString());

                //return  abcd;
                return Json(new { Success = 1, error = false, data = abcd, page = taburesquest.Page, size = taburesquest.Size, last_page = pageinfo.PageCount, total = pageinfo.TotalRecordCount });

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        [AllowAnonymous]
        public JsonResult GetImportDocumentSearchListEditor(int? CategoryId, bool IncludingInative, int pageNo = 1, decimal pageSize = 10, string searchquery = "", string dropdownSearch = "")
        {
            try
            {
                if (dropdownSearch == null)
                {
                    dropdownSearch = "";
                }
                var buyerpoList = itemDescriptionRepository.All().Where(x => x.IsDelete == false);

                if (searchquery?.Length > 1)
                {

                    var searchitem = JsonConvert.DeserializeObject<ItemListFilterData>(searchquery);

                    if (searchitem.pageIndex != null)
                    {
                        pageNo = searchitem.pageIndex.GetValueOrDefault();
                        pageSize = searchitem.pageSize.GetValueOrDefault();

                    }


                    if (searchitem.ItemDescName != null)
                    {
                        buyerpoList = buyerpoList.Where(x => x.ItemDescName.ToLower().Contains(searchitem.ItemDescName.ToLower()));
                    }
                }

                if ((dropdownSearch.Length > 1) || (dropdownSearch == ""))
                {
                    buyerpoList = buyerpoList.Where(x => x.ItemDescName.ToLower().Contains(dropdownSearch.ToLower()));
                }



                decimal TotalRecordCount = buyerpoList.Count();
                var PageCountabc = decimal.Parse((TotalRecordCount / pageSize).ToString());
                var PageCount = Math.Ceiling(PageCountabc);





                decimal skip = (pageNo - 1) * pageSize;

                int total = buyerpoList.Count();



                var query = from e in buyerpoList.Where(x => x.IsDelete == false)
                            select new
                            {
                                Id = e.Id,
                                ItemDesc = e.ItemDescName
                            };


                var abcd = query.OrderByDescending(x => x.Id).Skip(int.Parse(skip.ToString())).Take(int.Parse(pageSize.ToString())).ToList();// Take(50);
                var pageinfo = new PagingInfo();
                pageinfo.PageCount = int.Parse(PageCount.ToString());
                pageinfo.PageNo = pageNo;
                pageinfo.PageSize = int.Parse(pageSize.ToString());
                pageinfo.TotalRecordCount = int.Parse(TotalRecordCount.ToString());

                return Json(new { Success = 1, error = false, ItemDescList = abcd, PageInfo = pageinfo });


            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        [AllowAnonymous]
        public JsonResult GetSupplierListEditor(bool IncludingInative, int pageNo = 1, decimal pageSize = 10, string searchquery = "", string dropdownSearch = "")
        {
            try
            {
                if (dropdownSearch == null)
                {
                    dropdownSearch = "";
                }
                var buyerpoList = supplierRepository.All().Where(x => x.IsDelete == false);

                if (searchquery?.Length > 1)
                {

                    var searchitem = JsonConvert.DeserializeObject<SupplierListFilterData>(searchquery);

                    if (searchitem.pageIndex != null)
                    {
                        pageNo = searchitem.pageIndex.GetValueOrDefault();
                        pageSize = searchitem.pageSize.GetValueOrDefault();

                    }


                    if (searchitem.SupplierName != null)
                    {
                        buyerpoList = buyerpoList.Where(x => x.SupplierName.ToLower().Contains(searchitem.SupplierName.ToLower()));
                    }
                }

                if ((dropdownSearch.Length > 1) || (dropdownSearch == ""))
                {
                    buyerpoList = buyerpoList.Where(x => x.SupplierName.ToLower().Contains(dropdownSearch.ToLower()));
                }



                decimal TotalRecordCount = buyerpoList.Count();
                var PageCountabc = decimal.Parse((TotalRecordCount / pageSize).ToString());
                var PageCount = Math.Ceiling(PageCountabc);





                decimal skip = (pageNo - 1) * pageSize;

                int total = buyerpoList.Count();



                var query = from e in buyerpoList.Where(x => x.IsDelete == false)
                            select new
                            {
                                Id = e.Id,
                                Name = e.SupplierName
                            };


                var abcd = query.OrderByDescending(x => x.Id).Skip(int.Parse(skip.ToString())).Take(int.Parse(pageSize.ToString())).ToList();// Take(50);
                var pageinfo = new PagingInfo();
                pageinfo.PageCount = int.Parse(PageCount.ToString());
                pageinfo.PageNo = pageNo;
                pageinfo.PageSize = int.Parse(pageSize.ToString());
                pageinfo.TotalRecordCount = int.Parse(TotalRecordCount.ToString());

                return Json(new { Success = 1, error = false, SupplierList = abcd, PageInfo = pageinfo });


            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        [AllowAnonymous]
        public JsonResult GetUnitListEditor(int? CategoryId, bool IncludingInative, int pageNo = 1, decimal pageSize = 10, string searchquery = "", string dropdownSearch = "")
        {
            try
            {
                if (dropdownSearch == null)
                {
                    dropdownSearch = "";
                }
                var buyerpoList = unitRepository.All().Where(x => x.IsDelete == false);

                if (searchquery?.Length > 1)
                {

                    var searchitem = JsonConvert.DeserializeObject<UnitListFilterData>(searchquery);

                    if (searchitem.pageIndex != null)
                    {
                        pageNo = searchitem.pageIndex.GetValueOrDefault();
                        pageSize = searchitem.pageSize.GetValueOrDefault();

                    }


                    if (searchitem.UnitName != null)
                    {
                        buyerpoList = buyerpoList.Where(x => x.UnitName.ToLower().Contains(searchitem.UnitName.ToLower()));
                    }
                }

                if ((dropdownSearch.Length > 1) || (dropdownSearch == ""))
                {
                    buyerpoList = buyerpoList.Where(x => x.UnitName.ToLower().Contains(dropdownSearch.ToLower()));
                }



                decimal TotalRecordCount = buyerpoList.Count();
                var PageCountabc = decimal.Parse((TotalRecordCount / pageSize).ToString());
                var PageCount = Math.Ceiling(PageCountabc);





                decimal skip = (pageNo - 1) * pageSize;

                int total = buyerpoList.Count();



                var query = from e in buyerpoList.Where(x => x.IsDelete == false)
                            select new
                            {
                                Id = e.Id,
                                UnitName = e.UnitName
                            };


                var abcd = query.OrderByDescending(x => x.Id).Skip(int.Parse(skip.ToString())).Take(int.Parse(pageSize.ToString())).ToList();// Take(50);
                var pageinfo = new PagingInfo();
                pageinfo.PageCount = int.Parse(PageCount.ToString());
                pageinfo.PageNo = pageNo;
                pageinfo.PageSize = int.Parse(pageSize.ToString());
                pageinfo.TotalRecordCount = int.Parse(TotalRecordCount.ToString());

                return Json(new { Success = 1, error = false, ItemDescList = abcd, PageInfo = pageinfo });


            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        [AllowAnonymous]
        public JsonResult GetContainerListEditor(int? CategoryId, bool IncludingInative, int pageNo = 1, decimal pageSize = 10, string searchquery = "", string dropdownSearch = "")
        {
            try
            {
                if (dropdownSearch == null)
                {
                    dropdownSearch = "";
                }
                var buyerpoList = _containerRepository.All().Where(x => x.IsDelete == false);

                if (searchquery?.Length > 1)
                {

                    var searchitem = JsonConvert.DeserializeObject<ContainerListFilterData>(searchquery);

                    if (searchitem.pageIndex != null)
                    {
                        pageNo = searchitem.pageIndex.GetValueOrDefault();
                        pageSize = searchitem.pageSize.GetValueOrDefault();

                    }


                    if (searchitem.ContainerName != null)
                    {
                        buyerpoList = buyerpoList.Where(x => x.ContainerName.ToLower().Contains(searchitem.ContainerName.ToLower()));
                    }
                }

                if ((dropdownSearch.Length > 1) || (dropdownSearch == ""))
                {
                    buyerpoList = buyerpoList.Where(x => x.ContainerName.ToLower().Contains(dropdownSearch.ToLower()));
                }



                decimal TotalRecordCount = buyerpoList.Count();
                var PageCountabc = decimal.Parse((TotalRecordCount / pageSize).ToString());
                var PageCount = Math.Ceiling(PageCountabc);





                decimal skip = (pageNo - 1) * pageSize;

                int total = buyerpoList.Count();



                var query = from e in buyerpoList.Where(x => x.IsDelete == false)
                            select new
                            {
                                Id = e.Id,
                                ContainerName = e.ContainerName
                            };


                var abcd = query.OrderByDescending(x => x.Id).Skip(int.Parse(skip.ToString())).Take(int.Parse(pageSize.ToString())).ToList();// Take(50);
                var pageinfo = new PagingInfo();
                pageinfo.PageCount = int.Parse(PageCount.ToString());
                pageinfo.PageNo = pageNo;
                pageinfo.PageSize = int.Parse(pageSize.ToString());
                pageinfo.TotalRecordCount = int.Parse(TotalRecordCount.ToString());

                return Json(new { Success = 1, error = false, ItemDescList = abcd, PageInfo = pageinfo });


            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        #endregion


        [AllowAnonymous]
        [HttpPost, ActionName("SetSessionbblc")]
        public IActionResult SetSessionbblc(string reporttype, string action, int? reportid, string refno, string fromDatebblc, string toDatebblc, string supplierIDbblc, string concernbblc)
        {
            try
            {
                var comid = HttpContext.Session.GetInt32("ComId");
                var userid = HttpContext.Session.GetInt32("Userid");


                string redirectUrl = "";
                if (action == "PrintBBLCReport")
                {
                    redirectUrl = Url.Action(action, "Variable", new { type = reporttype, FromDate = fromDatebblc, ToDate = toDatebblc, Supplierid = supplierIDbblc, CommercialCompanyId = concernbblc });

                }

                else
                {
                    redirectUrl = Url.Action(action, "Variable", new { id = reportid, type = reporttype, refno = refno });
                }


                return Redirect(redirectUrl);

            }

            catch (Exception ex)
            {
                return Json(new { Success = 0, ex = ex.InnerException.InnerException.Message.ToString() });
            }

            return Json(new { Success = 0, ex = new Exception("Unable to Delete").Message.ToString() });

        }

        [AllowAnonymous]
        public ActionResult PrintBBLCReport(int? id, string type, string FromDate, string ToDate, int? Supplierid, int? CommercialCompanyId)
        {
            try
            {

                var comid = HttpContext.Session.GetInt32("ComId");

                clsReport.rptList = null;

                HttpContext.Session.SetString("ReportPath", "~/ReportViewer/ImportReport/rptBBLCReport.rdlc");
                HttpContext.Session.SetString("ReportQuery", "Exec rptBBLCReport '" + comid + "' ,'" + FromDate + "' ,'" + ToDate + "','" + Supplierid + "','" + CommercialCompanyId + "'");

                var filename = "ABCD";
                HttpContext.Session.SetString("PrintFileName", filename.Replace(".", "").Replace(" ", "").Replace(",", "").Replace("\"", ""));


                string DataSourceName = "DataSet1";
                clsReport.strReportPathMain = HttpContext.Session.GetString("ReportPath");
                clsReport.strQueryMain = HttpContext.Session.GetString("ReportQuery");
                clsReport.strDSNMain = DataSourceName;

                string callBackUrl = this.Url.Action("Index", "ReportViewer", new { reporttype = type });
                var redirectUrl = callBackUrl;


                return Json(new { Url = redirectUrl });



            }
            catch (Exception ex)
            {

                throw ex;
            }

        }

        [AllowAnonymous]
        [HttpPost, ActionName("SetSessionRegularLCReport")]

        public IActionResult SetSessionRegularLCReport(string reporttype, int? reportid, string refno, string action, string fromDaterlc, string toDaterlc, int? supplierIDrlc, int? concernrlc, string itemgrpname1)
        {
            try
            {
                var comid = HttpContext.Session.GetInt32("ComId");
                var userid = HttpContext.Session.GetInt32("Userid");

                string redirectUrl = "";

                if (action == "PrintRegularLCReport")
                {
                    redirectUrl = Url.Action(action, "Variable", new { type = reporttype, FromDate = fromDaterlc, ToDate = toDaterlc, Supplierid = supplierIDrlc, CommercialCompanyId = concernrlc, ItemGroupId = itemgrpname1 });

                }

                else
                {
                    redirectUrl = Url.Action(action, "Variable", new { id = reportid, type = reporttype, refno = refno });
                }


                return Redirect(redirectUrl);

            }

            catch (Exception ex)
            {

                return Json(new { Success = 0, ex = ex.InnerException.InnerException.Message.ToString() });
            }

            return Json(new { Success = 0, ex = new Exception("Unable to Open").Message.ToString() });


        }

        [AllowAnonymous]
        public ActionResult PrintRegularLCReport(int? id, string type, string FromDate, string ToDate, int? Supplierid, int? CommercialCompanyId, string ItemGroupId)
        {
            try
            {

                var comid = HttpContext.Session.GetInt32("ComId");

                clsReport.rptList = null;

                HttpContext.Session.SetString("ReportPath", "~/ReportViewer/ImportReport/rptRegularLCReport.rdlc");
                HttpContext.Session.SetString("ReportQuery", "Exec rptRegularLCReport '" + comid + "' ,'" + FromDate + "' ,'" + ToDate + "','" + Supplierid + "','" + CommercialCompanyId + "','" + ItemGroupId + "' ");

                var filename = "ABCD";
                HttpContext.Session.SetString("PrintFileName", filename.Replace(".", "").Replace(" ", "").Replace(",", "").Replace("\"", ""));


                string DataSourceName = "DataSet1";
                clsReport.strReportPathMain = HttpContext.Session.GetString("ReportPath");
                clsReport.strQueryMain = HttpContext.Session.GetString("ReportQuery");
                clsReport.strDSNMain = DataSourceName;

                string callBackUrl = this.Url.Action("Index", "ReportViewer", new { reporttype = type });
                var redirectUrl = callBackUrl;


                return Json(new { Url = redirectUrl });




            }
            catch (Exception ex)
            {

                throw ex;
            }

        }


        [AllowAnonymous]
        public ActionResult PrintComInvoice(int? id, string type)
        {
            try
            {
                var comid = HttpContext.Session.GetInt32("ComId");

                clsReport.rptList = null;

                HttpContext.Session.SetString("ReportPath", "~/ReportViewer/ImportReport/rptComInvoiceCI.rdlc");
                HttpContext.Session.SetString("ReportQuery", "Exec rptComInvoiceCI '" + id + "', '" + comid + "'");


                var filename = "ComInvoiceCI";
                HttpContext.Session.SetString("PrintFileName", filename.Replace(".", "").Replace(" ", "").Replace(",", "").Replace("\"", ""));



                string DataSourceName = "DataSet1";

                clsReport.strReportPathMain = HttpContext.Session.GetString("ReportPath");
                clsReport.strQueryMain = HttpContext.Session.GetString("ReportQuery");
                clsReport.strDSNMain = DataSourceName;

                string callBackUrl = this.Url.Action("Index", "ReportViewer", new { reporttype = type });
                var redirectUrl = callBackUrl;


                return Redirect(redirectUrl);
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }

        [AllowAnonymous]
        public ActionResult PrintWorkOrder(int? id, string type)
        {
            try
            {
                var comid = HttpContext.Session.GetInt32("ComId");

                clsReport.rptList = null;

                HttpContext.Session.SetString("ReportPath", "~/ReportViewer/ImportReport/rptWorkOrder.rdlc");
                HttpContext.Session.SetString("ReportQuery", "Exec rptWorkOrder '" + id + "', '" + comid + "'");


                var filename = "ComWorkOrder";
                HttpContext.Session.SetString("PrintFileName", filename.Replace(".", "").Replace(" ", "").Replace(",", "").Replace("\"", ""));



                string DataSourceName = "DataSet1";

                clsReport.strReportPathMain = HttpContext.Session.GetString("ReportPath");
                clsReport.strQueryMain = HttpContext.Session.GetString("ReportQuery");
                clsReport.strDSNMain = DataSourceName;

                string callBackUrl = this.Url.Action("Index", "ReportViewer", new { reporttype = type });
                var redirectUrl = callBackUrl;


                return Redirect(redirectUrl);
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }

    }
}
