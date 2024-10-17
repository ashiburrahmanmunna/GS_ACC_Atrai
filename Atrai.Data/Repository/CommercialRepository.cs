using Atrai.Model.Core.Entity;
using Atrai.Data.Interfaces;
using Atrai.Data.Context.AppDataContext;
using Atrai.Data.Repository.Base;
using Atrai.Data.Repository.Self;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;
using System.Linq;

namespace Atrai.Data.Repository
{
    public class CommercialRepository : BaseRepository<CommercialCompanyModel>, ICommercialRepository
    {
        public CommercialRepository(InvoiceDbContext context) : base(context)
        {
        }
       public IEnumerable<SelectListItem> GetAllForDropDown()
        {
            return All().Select(x => new SelectListItem
            {
                Text=x.CompanyName,
                Value=x.Id.ToString()
            });
        }
    }
    //public class ConcernBankAccountRepository : BaseRepository<ConcernBankAccountModel>, IConcernBankAccountRepository
    //{
    //    public ConcernBankAccountRepository(InvoiceDbContext context) : base(context)
    //    {
    //    }
    //   public IEnumerable<SelectListItem> GetAllForDropDown()
    //    {
    //        return All().Select(x => new SelectListItem
    //        {
    //            Text=x.BankAccountNumber,
    //            Value=x.Id.ToString()
    //        });
    //    }
    //}
    public class ConcernBankRepository : BaseRepository<OpeningBank>, IConcernBankRepository
    {
        public ConcernBankRepository(InvoiceDbContext context) : base(context)
        {
        }
       public IEnumerable<SelectListItem> GetAllForDropDown()
        {
            return All().Select(x => new SelectListItem
            {
                Text=x.OpeningBankName,
                Value=x.Id.ToString()
            });
        }
    }
    public class DestinationRepository : BaseRepository<Destination>, IDestinationRepository
    {
        public DestinationRepository(InvoiceDbContext context) : base(context)
        {
        }
       public IEnumerable<SelectListItem> GetAllForDropDown()
        {
            return All().Select(x => new SelectListItem
            {
                Text=x.DestinationName,
                Value=x.Id.ToString()
            });
        }
    }
    public class SupplierBankAccountRepository : BaseRepository<LienBank>, ISupplierBankAccountRepository
    {
        public SupplierBankAccountRepository(InvoiceDbContext context) : base(context)
        {
        }
       public IEnumerable<SelectListItem> GetAllForDropDown()
        {
            return All().Select(x => new SelectListItem
            {
                Text=x.LienBankName,
                Value=x.Id.ToString()
            });
        }
    }

    public class LCTypeRepository : SelfRepository<LCType>, ILCTypeRepository
    {
        public LCTypeRepository(InvoiceDbContext context) : base(context)
        {
        }
        public IEnumerable<SelectListItem> GetAllForDropDown()
        {
            return All().Select(x => new SelectListItem
            {
                Text = x.LCTypeName,
                Value = x.Id.ToString()
            });
        }
    }

    public class CategoryTypeRepository : SelfRepository<CategoryTypeModel>, ICategoryTypeRepository
    {
        public CategoryTypeRepository(InvoiceDbContext context) : base(context)
        {
        }
        public IEnumerable<SelectListItem> GetAllForDropDown()
        {
            return All().Select(x => new SelectListItem
            {
                Text = x.Name,
                Value = x.Id.ToString()
            });
        }
    }
    
    public class BoxCategoryRepository : BaseRepository<BoxCategoryModel>, IBoxCategoryRepository
    {
        public BoxCategoryRepository(InvoiceDbContext context) : base(context)
        {
        }
        public IEnumerable<SelectListItem> GetAllForDropDown()
        {
            return All().Select(x => new SelectListItem
            {
                Text = x.MeasurementName,
                Value = x.Id.ToString()
            });
        }
    }

    public class ItemGroupRepository : BaseRepository<ItemGroupModel>, IItemGroupRepository
    {
        public ItemGroupRepository(InvoiceDbContext context) : base(context)
        {
        }
       public IEnumerable<SelectListItem> GetAllForDropDown()
        {
            return All().Select(x => new SelectListItem
            {
                Text=x.ItemGroupName,
                Value=x.Id.ToString()
            });
        }
    }
    public class PITypeRepository : BaseRepository<PITypeModel>, IPITypeRepository
    {
        public PITypeRepository(InvoiceDbContext context) : base(context)
        {
        }
       public IEnumerable<SelectListItem> GetAllForDropDown()
        {
            return All().Select(x => new SelectListItem
            {
                Text=x.PITytpeShortName,
                Value=x.Id.ToString()
            });
        }
    }

    public class PINatureRepository : SelfRepository<PINature>, IPINatureRepository
    {
        public PINatureRepository(InvoiceDbContext context) : base(context)
        {
        }
        public IEnumerable<SelectListItem> GetAllForDropDown()
        {
            return All().Select(x => new SelectListItem
            {
                Text = x.PINatureName,
                Value = x.Id.ToString()
            });
        }
    }
    public class ItemDescriptionRepository : BaseRepository<ItemDescriptionModel>, IItemDescriptionRepository
    {
        public ItemDescriptionRepository(InvoiceDbContext context) : base(context)
        {
        }
       public IEnumerable<SelectListItem> GetAllForDropDown()
        {
            return All().Select(x => new SelectListItem
            {
                Text=x.ItemDescName,
                Value=x.Id.ToString()
            });
        }
    }


    public class GroupLCMainRepository : BaseRepository<GroupLC_MainModel>, IGroupLCMainRepository
    {
        public GroupLCMainRepository(InvoiceDbContext context) : base(context)
        {
        }
        public IEnumerable<SelectListItem> GetAllForDropDown()
        {
            return All().Select(x => new SelectListItem
            {
                Text = x.GroupLCRefName,
                Value = x.Id.ToString()
            });
        }
    }
    public class GroupLCSubRepository : BaseRepository<GroupLC_SubModel>, IGroupLCSubRepository
    {
        public GroupLCSubRepository(InvoiceDbContext context) : base(context)
        {
        }
        public IEnumerable<SelectListItem> GetAllForDropDown()
        {
            return All().Select(x => new SelectListItem
            {
                Text = x.Id.ToString(),
                Value = x.Id.ToString()
            });
        }
    }
    public class MasterLCRepository : BaseRepository<MasterLCModel>, IMasterLCRepository
    {
        public MasterLCRepository(InvoiceDbContext context) : base(context)
        {
        }
        public IEnumerable<SelectListItem> GetAllForDropDown()
        {
            return All().Select(x => new SelectListItem
            {
                Text = x.LCRefNo,
                Value = x.Id.ToString()
            });
        }
    }
    public class PostOfDischargeRepository : BaseRepository<PortOfDischarge>, IPostOfDischargeRepository
    {
        public PostOfDischargeRepository(InvoiceDbContext context) : base(context)
        {
        }
        public IEnumerable<SelectListItem> GetAllForDropDown()
        {
            return All().Select(x => new SelectListItem
            {
                Text = x.PortOfDischargeName,
                Value = x.Id.ToString()
            });
        }
    }
    public class LCStatusRepository : SelfRepository<LCStatus>, ILCStatusRepository
    {
        public LCStatusRepository(InvoiceDbContext context) : base(context)
        {
        }
        public IEnumerable<SelectListItem> GetAllForDropDown()
        {
            return All().Select(x => new SelectListItem
            {
                Text = x.LCStatusName,
                Value = x.Id.ToString()
            });
        }
    }
    public class PostOfLoadingRepository : BaseRepository<PortOfLoading>, IPostOfLoadingRepository
    {
        public PostOfLoadingRepository(InvoiceDbContext context) : base(context)
        {
        }
        public IEnumerable<SelectListItem> GetAllForDropDown()
        {
            return All().Select(x => new SelectListItem
            {
                Text = x.PortOfLoadingName,
                Value = x.Id.ToString()
            });
        }
    }
    public class LienBankRepository : BaseRepository<LienBank>, ILienBankRepository
    {
        public LienBankRepository(InvoiceDbContext context) : base(context)
        {
        }
        public IEnumerable<SelectListItem> GetAllForDropDown()
        {
            return All().Select(x => new SelectListItem
            {
                Text = x.LienBankName,
                Value = x.Id.ToString()
            });
        }
    }
    public class BankAccountNoRepository : BaseRepository<BankAccountNo>, IBankAccountNoRepository
    {
        public BankAccountNoRepository(InvoiceDbContext context) : base(context)
        {
        }
        public IEnumerable<SelectListItem> GetAllForDropDown()
        {
            return All().Select(x => new SelectListItem
            {
                Text = x.BankAccountNumber,
                Value = x.Id.ToString()
            });
        }
    }
    //public class OpeningBankRepository : BaseRepository<OpeningBank>, IOpeningBankRepository
    //{
    //    public OpeningBankRepository(InvoiceDbContext context) : base(context)
    //    {
    //    }
    //    public IEnumerable<SelectListItem> GetAllForDropDown()
    //    {
    //        return All().Select(x => new SelectListItem
    //        {
    //            Text = x.Remarks,
    //            Value = x.Id.ToString()
    //        });
    //    }
    //}
    public class UnitMasterRepository : BaseRepository<UnitMaster>, IUnitMasterRepository
    {
        public UnitMasterRepository(InvoiceDbContext context) : base(context)
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
    public class ExportOrderRepository : BaseRepository<ExportOrder>, IExportOrderRepository
    {
        public ExportOrderRepository(InvoiceDbContext context) : base(context)
        {
        }
        public IEnumerable<SelectListItem> GetAllForDropDown()
        {
            return All().Select(x => new SelectListItem
            {
                Text = x.CM.ToString(),
                Value = x.Id.ToString()
            });
        }
    }
    public class ExportInvoiceMasterRepository : BaseRepository<ExportInvoiceMaster>, IExportInvoiceMasterRepository
    {
        public ExportInvoiceMasterRepository(InvoiceDbContext context) : base(context)
        {
        }
        public IEnumerable<SelectListItem> GetAllForDropDown()
        {
            return All().Select(x => new SelectListItem
            {
                Text = x.VesselName,
                Value = x.Id.ToString()
            });
        }
    }
    public class ExportInvoiceDetailsRepository : BaseRepository<ExportInvoiceDetails>, IExportInvoiceDetailsRepository
    {
        public ExportInvoiceDetailsRepository(InvoiceDbContext context) : base(context)
        {
        }
        public IEnumerable<SelectListItem> GetAllForDropDown()
        {
            return All().Select(x => new SelectListItem
            {
                Text = x.InvoiceFactor.ToString(),
                Value = x.Id.ToString()
            });
        }
    }
    
    public class ExportInvoiceTruckDetailsRepository : BaseRepository<ExportInvoiceTruckDetails>, IExportInvoiceTruckDetailsRepository
    {
        public ExportInvoiceTruckDetailsRepository(InvoiceDbContext context) : base(context)
        {
        }
        
    }
    public class ExportInvoicePackingListRepository : BaseRepository<ExportInvoicePackingList>, IExportInvoicePackingListRepository
    {
        public ExportInvoicePackingListRepository(InvoiceDbContext context) : base(context)
        {
        }
        public IEnumerable<SelectListItem> GetAllForDropDown()
        {
            return All().Select(x => new SelectListItem
            {
                Text = x.CtnNoToPL,
                Value = x.Id.ToString()
            });
        }
    }

    public class ExportRealizationMasterRepository : BaseRepository<ExportRealization_Master>, IExportRealizationMasterRepository
    {
        public ExportRealizationMasterRepository(InvoiceDbContext context) : base(context)
        {
        }
        
    }

    public class ExportRealizationDetailsRepository : BaseRepository<ExportRealization_Details>, IExportRealizationDetailsRepository
    {
        public ExportRealizationDetailsRepository(InvoiceDbContext context) : base(context)
        {
        }

    }
    public class MasterLCDetailsRepository : BaseRepository<COM_MasterLC_Details>, IMasterLCDetailsRepository
    {
        public MasterLCDetailsRepository(InvoiceDbContext context) : base(context)
        {
        }
        public IEnumerable<SelectListItem> GetAllForDropDown()
        {
            return All().Select(x => new SelectListItem
            {
                Text = x.ContractNo,
                Value = x.Id.ToString()
            });
        }
    }
    
    public class MasterLCDetailsTempRepository : BaseRepository<COM_MasterLC_Details_Temp>, IMasterLCDetailsTempRepository
    {
        public MasterLCDetailsTempRepository(InvoiceDbContext context) : base(context)
        {
        }
    }
    public class MasterLCExportRepository : BaseRepository<COM_MasterLCExport>, IMasterLCExportRepository
    {
        public MasterLCExportRepository(InvoiceDbContext context) : base(context)
        {
        }
        public IEnumerable<SelectListItem> GetAllForDropDown()
        {
            return All().Select(x => new SelectListItem
            {
                Text = x.Id.ToString(),
                Value = x.Id.ToString()
            });
        }
    }
    public class ReportFilterRepository : BaseRepository<ReportFilterModel>, IReportFilterRepository
    {
        public ReportFilterRepository(InvoiceDbContext context) : base(context)
        {
        }
    }
    public class BuyerGroupRepository : BaseRepository<BuyerGroup>, IBuyerGroupRepository
    {
        public BuyerGroupRepository(InvoiceDbContext context) : base(context)
        {
        }
        public IEnumerable<SelectListItem> GetAllForDropDown()
        {
            return All().Select(x => new SelectListItem
            {
                Text = x.BuyerGroupName,
                Value = x.Id.ToString()
            });
        }
    }
    public class NotifyPartyRepository : BaseRepository<NotifyParty>, INotifyPartyRepository
    {
        public NotifyPartyRepository(InvoiceDbContext context) : base(context)
        {
        }
        public IEnumerable<SelectListItem> GetAllForDropDown()
        {
            return All().Select(x => new SelectListItem
            {
                Text = x.NotifyPartyName,
                Value = x.Id.ToString()
            });
        }
        public IEnumerable<SelectListItem> GetAllForDropDown(int BuyerId)
        {
            return All().Where(x => x.BuyerId == BuyerId).Select(x => new SelectListItem
            {
                Text = x.NotifyPartyName,
                Value = x.Id.ToString()
            });
        }
    }
    public class DynamicReportRepository : SelfRepository<DynamicReport>, IDynamicReportRepository
    {
        public DynamicReportRepository(InvoiceDbContext context) : base(context)
        {
        }
        public IEnumerable<SelectListItem> GetAllForDropDown()
        {
            return All().Select(x => new SelectListItem
            {
                Text = x.DynamicReportCaption,
                Value = x.Id.ToString()
            });
        }
    }
    public class UnitGroupRepository : BaseRepository<UnitGroup>, IUnitGroupRepository
    {
        public UnitGroupRepository(InvoiceDbContext context) : base(context)
        {
        }
        public IEnumerable<SelectListItem> GetAllForDropDown()
        {
            return All().Select(x => new SelectListItem
            {
                Text = x.UnitMaster.ToString(),
                Value = x.Id.ToString()
            });
        }
    }
    public class COM_ProformaInvoiceRepository : BaseRepository<COM_ProformaInvoice>, ICOM_ProformaInvoiceRepository
    {
        public COM_ProformaInvoiceRepository(InvoiceDbContext context) : base(context)
        {
        }
        public IEnumerable<SelectListItem> GetAllForDropDown()
        {
            return All().Select(x => new SelectListItem
            {
                Text = x.UnitMaster.ToString(),
                Value = x.Id.ToString()
            });
        }
    }
    public class COM_ProformaInvoice_SubInvoiceRepository : BaseRepository<COM_ProformaInvoice_Sub>, ICOM_ProformaInvoice_SubInvoiceRepository
    {
        public COM_ProformaInvoice_SubInvoiceRepository(InvoiceDbContext context) : base(context)
        {
        }
    }
    public class PaymentTermsRepository : SelfRepository<CommercialPaymentTerms>, IPaymentTermsRepository
    {
        public PaymentTermsRepository(InvoiceDbContext context) : base(context)
        {
        }
        public IEnumerable<SelectListItem> GetAllForDropDown()
        {
            return All().Select(x => new SelectListItem
            {
                Text = x.PaymentTermsName,
                Value = x.Id.ToString()
            });
        }
    }

    public class CommercialTypeRepository : SelfRepository<CommercialType>, ICommercialTypeRepository
    {
        public CommercialTypeRepository(InvoiceDbContext context) : base(context)
        {
        }
        public IEnumerable<SelectListItem> GetAllForDropDown()
        {
            return All().Select(x => new SelectListItem
            {
                Text = x.CommercialTypeName,
                Value = x.Id.ToString()
            });
        }
    }
    public class IncoTermRepository : SelfRepository<CommercialTradeTerm>, IIncoTermRepository
    {
        public IncoTermRepository(InvoiceDbContext context) : base(context)
        {
        }
        public IEnumerable<SelectListItem> GetAllForDropDown()
        {
            return All().Select(x => new SelectListItem
            {
                Text = x.TradeTermName,
                Value = x.Id.ToString()
            });
        }
    }
    public class DayListRepository : SelfRepository<DayList>, IDayListRepository
    {
        public DayListRepository(InvoiceDbContext context) : base(context)
        {
        }
        public IEnumerable<SelectListItem> GetAllForDropDown()
        {
            return All().Select(x => new SelectListItem
            {
                Text = x.DayListName,
                Value = x.Id.ToString()
            });
        }
    }
    public class ShipModeRepository : SelfRepository<ShipMode>, IShipModeRepository
    {
        public ShipModeRepository(InvoiceDbContext context) : base(context)
        {
        }
        public IEnumerable<SelectListItem> GetAllForDropDown()
        {
            return All().Select(x => new SelectListItem
            {
                Text = x.ShipModeShortName,
                Value = x.Id.ToString()
            });
        }
    }
    public class DayListTermRepository : SelfRepository<DayListTerm>, IDayListTermRepository
    {
        public DayListTermRepository(InvoiceDbContext context) : base(context)
        {
        }
        public IEnumerable<SelectListItem> GetAllForDropDown()
        {
            return All().Select(x => new SelectListItem
            {
                Text = x.DayListTermShortName,
                Value = x.Id.ToString()
            });
        }
    }
    public class BBLCMainRepository : BaseRepository<BBLCMain>, IBBLCMainRepository
    {
        public BBLCMainRepository(InvoiceDbContext context) : base(context)
        {
        }
        public IEnumerable<SelectListItem> GetAllForDropDown()
        {
            return All().Select(x => new SelectListItem
            {
                Text = x.BBLCNo,
                Value = x.Id.ToString()
            });
        }
    }
    public class BBLCDetailsRepository : BaseRepository<BBLC_Details>, IBBLCDetailsRepository
    {
        public BBLCDetailsRepository(InvoiceDbContext context) : base(context)
        {
        }
    }

    public class ImportCIMasterRepository : BaseRepository<ImportCI_Master>, IImportCIMasterRepository
    {
        public ImportCIMasterRepository(InvoiceDbContext context) : base(context)
        {
        }
        public IEnumerable<SelectListItem> GetAllForDropDown()
        {
            return All().Select(x => new SelectListItem
            {
                Text = x.CICode,
                Value = x.Id.ToString()
            });
        }
    }
    
    public class ContainerRepository : BaseRepository<ContainerModel>, IContainerRepository
    {
        public ContainerRepository(InvoiceDbContext context) : base(context)
        {
        }
        public IEnumerable<SelectListItem> GetAllForDropDown()
        {
            return All().Select(x => new SelectListItem
            {
                Text = x.ContainerName,
                Value = x.Id.ToString()
            });
        }
    }

    public class ImportCIDetailsRepository : BaseRepository<ImportCI_Details>, IImportCIDetailsRepository
    {
        public ImportCIDetailsRepository(InvoiceDbContext context) : base(context)
        {
        }
    }
    public class ImportCIContainerRepository : BaseRepository<ImportCI_Container>, IImportCIContainerRepository
    {
        public ImportCIContainerRepository(InvoiceDbContext context) : base(context)
        {
        }
    }

    public class CommercialInvoiceRepository : BaseRepository<COM_CommercialInvoice>, ICOM_CommercialInvoiceRepository
    {
        public CommercialInvoiceRepository(InvoiceDbContext context) : base(context)
        {
        }
    }
    public class CommercialInvoice_SubRepository : BaseRepository<COM_CommercialInvoice_Sub>, ICOM_CommercialInvoice_SubRepository
    {
        public CommercialInvoice_SubRepository(InvoiceDbContext context) : base(context)
        {
        }
    }
    public class MachinaryLC_MasterRepository : BaseRepository<COM_MachinaryLC_Master>, ICOM_MachinaryLC_MasterRepository
    {
        public MachinaryLC_MasterRepository(InvoiceDbContext context) : base(context)
        {
        }
    }
    public class MachinaryLC_DetailsRepository : BaseRepository<COM_MachinaryLC_Details>, ICOM_MachinaryLC_DetailsRepository
    {
        public MachinaryLC_DetailsRepository(InvoiceDbContext context) : base(context)
        {
        }
    }
    public class DocumentStatusRepository : SelfRepository<DocumentStatus>, IDocumentStatusRepository
    {
        public DocumentStatusRepository(InvoiceDbContext context) : base(context)
        {
        }

        public IEnumerable<SelectListItem> GetAllForDropDown()
        {
            return All().Select(x => new SelectListItem
            {
                Text = x.DocumentStatusName,
                Value = x.Id.ToString()
            });
        }
    }
    public class CommercialLCTypeRepository : SelfRepository<CommercialLCType>, ICommercialLCTypeRepository
    {
        public CommercialLCTypeRepository(InvoiceDbContext context) : base(context)
        {
        }

        public IEnumerable<SelectListItem> GetAllForDropDown()
        {
            return All().Select(x => new SelectListItem
            {
                Text = x.CommercialLCTypeShortName,
                Value = x.Id.ToString()
            });
        }
    }


    public class DocumentAcceptance_MasterRepository : BaseRepository<COM_DocumentAcceptance_Master>, IDocumentAcceptance_MasterRepository
    {
        public DocumentAcceptance_MasterRepository(InvoiceDbContext context) : base(context)
        {
        }
    }
    public class DocumentAcceptance_DetailsRepository : BaseRepository<COM_DocumentAcceptance_Details>, IDocumentAcceptance_DetailsRepository
    {
        public DocumentAcceptance_DetailsRepository(InvoiceDbContext context) : base(context)
        {
        }
    }
    public class WorkOrderMasterRepository : BaseRepository<WorkOrderMaster>, IWorkOrderMasterRepository
    {
        public WorkOrderMasterRepository(InvoiceDbContext context) : base(context)
        {
        }
    }
    public class COM_MachineryLCDetailsRepository : BaseRepository<COM_MachineryLCDetails>, ICOM_MachineryLCDetailsRepository
    {
        public COM_MachineryLCDetailsRepository(InvoiceDbContext context) : base(context)
        {
        }
    }
    public class COM_MachineryLCMasterRepository : BaseRepository<COM_MachineryLCMaster>, ICOM_MachineryLCMasterRepository
    {
        public COM_MachineryLCMasterRepository(InvoiceDbContext context) : base(context)
        {
        }
        public IEnumerable<SelectListItem> GetAllForDropDown()
        {
            return All().Select(x => new SelectListItem
            {
                Text = x.LCNumber,
                Value = x.Id.ToString()
            });
        }
    }
    public class ApprovedByRepository : SelfRepository<ApprovedBy>, IApprovedByRepository
    {
        public ApprovedByRepository(InvoiceDbContext context) : base(context)
        {
        }
        public IEnumerable<SelectListItem> GetAllForDropDown()
        {
            return All().Select(x => new SelectListItem
            {
                Text = x.ApprovedByShortName,
                Value = x.Id.ToString()
            });
        }
    }
    public class WorkorderStatusRepository : SelfRepository<WorkorderStatus>, IWorkorderStatusRepository
    {
        public WorkorderStatusRepository(InvoiceDbContext context) : base(context)
        {
        }
        public IEnumerable<SelectListItem> GetAllForDropDown()
        {
            return All().Select(x => new SelectListItem
            {
                Text = x.WorkorderStatusShortName,
                Value = x.Id.ToString()
            });
        }
    }
    public class TruckInfoRepository : BaseRepository<TruckInfo>, ITruckInfoRepository
    {
        public TruckInfoRepository(InvoiceDbContext context) : base(context)
        {
        }
    }

    public class BankAccountNoLienBankRepository : BaseRepository<BankAccountNoLienBank>, IBankAccountNoLienBankRepository
    {
        public BankAccountNoLienBankRepository(InvoiceDbContext context) : base(context)
        {
        }
        public IEnumerable<SelectListItem> GetAllForDropDown()
        {
            return All().Select(x => new SelectListItem
            {
                Text = x.BankAccountNumber,
                Value = x.Id.ToString()
            });
        }
    }
}
