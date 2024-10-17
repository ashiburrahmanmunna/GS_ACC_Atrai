using Atrai.Model.Core.Entity;
using Atrai.Data.Interfaces.Base;
using Atrai.Data.Interfaces.Self;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;

namespace Atrai.Data.Interfaces
{
    public interface ICommercialRepository:IBaseRepository<CommercialCompanyModel>
    {
        IEnumerable<SelectListItem> GetAllForDropDown();

    }
    //public interface IConcernBankAccountRepository : IBaseRepository<ConcernBankAccountModel>
    //{
    //    IEnumerable<SelectListItem> GetAllForDropDown();

    //}
    public interface IConcernBankRepository : IBaseRepository<OpeningBank>
    {
        IEnumerable<SelectListItem> GetAllForDropDown();

    }

    public interface IPINatureRepository : ISelfRepository<PINature>
    {
        IEnumerable<SelectListItem> GetAllForDropDown();

    }
    public interface ICategoryTypeRepository : ISelfRepository<CategoryTypeModel>
    {
        IEnumerable<SelectListItem> GetAllForDropDown();

    }
    public interface IBoxCategoryRepository : IBaseRepository<BoxCategoryModel>
    {
        IEnumerable<SelectListItem> GetAllForDropDown();

    }
    public interface IDestinationRepository : IBaseRepository<Destination>
    {
        IEnumerable<SelectListItem> GetAllForDropDown();

    }
    public interface ISupplierBankAccountRepository : IBaseRepository<LienBank>
    {
        IEnumerable<SelectListItem> GetAllForDropDown();

    }
    public interface IItemGroupRepository : IBaseRepository<ItemGroupModel>
    {
        IEnumerable<SelectListItem> GetAllForDropDown();

    }
    public interface ILCStatusRepository : ISelfRepository<LCStatus>
    {
        IEnumerable<SelectListItem> GetAllForDropDown();

    }
    public interface ILCTypeRepository : ISelfRepository<LCType>
    {
        IEnumerable<SelectListItem> GetAllForDropDown();

    }
    public interface IPITypeRepository : IBaseRepository<PITypeModel>
    {
        IEnumerable<SelectListItem> GetAllForDropDown();

    }
    public interface IItemDescriptionRepository : IBaseRepository<ItemDescriptionModel>
    {
        IEnumerable<SelectListItem> GetAllForDropDown();

    }





    public interface IGroupLCMainRepository : IBaseRepository<GroupLC_MainModel>
    {
        IEnumerable<SelectListItem> GetAllForDropDown();

    }
    public interface IGroupLCSubRepository : IBaseRepository<GroupLC_SubModel>
    {
        IEnumerable<SelectListItem> GetAllForDropDown();

    }
    public interface IMasterLCRepository : IBaseRepository<MasterLCModel>
    {
        IEnumerable<SelectListItem> GetAllForDropDown();

    }
    public interface IPostOfDischargeRepository : IBaseRepository<PortOfDischarge>
    {
        IEnumerable<SelectListItem> GetAllForDropDown();

    }
    public interface IPostOfLoadingRepository : IBaseRepository<PortOfLoading>
    {
        IEnumerable<SelectListItem> GetAllForDropDown();

    }
    public interface ILienBankRepository : IBaseRepository<LienBank>
    {
        IEnumerable<SelectListItem> GetAllForDropDown();

    }
    public interface IBankAccountNoRepository : IBaseRepository<BankAccountNo>
    {
        IEnumerable<SelectListItem> GetAllForDropDown();

    }
    //public interface IOpeningBankRepository : IBaseRepository<OpeningBank>
    //{
    //    IEnumerable<SelectListItem> GetAllForDropDown();

    //}
    public interface IUnitMasterRepository : IBaseRepository<UnitMaster>
    {
        IEnumerable<SelectListItem> GetAllForDropDown();

    }
    public interface IExportOrderRepository : IBaseRepository<ExportOrder>
    {
        IEnumerable<SelectListItem> GetAllForDropDown();

    }
    public interface IExportInvoiceMasterRepository : IBaseRepository<ExportInvoiceMaster>
    {
        IEnumerable<SelectListItem> GetAllForDropDown();

    }
    public interface IExportInvoiceDetailsRepository : IBaseRepository<ExportInvoiceDetails>
    {
        IEnumerable<SelectListItem> GetAllForDropDown();

    }
    
    public interface IExportInvoiceTruckDetailsRepository : IBaseRepository<ExportInvoiceTruckDetails>
    {

    }
    public interface IExportInvoicePackingListRepository : IBaseRepository<ExportInvoicePackingList>
    {
        IEnumerable<SelectListItem> GetAllForDropDown();

    }
    public interface IExportRealizationMasterRepository : IBaseRepository<ExportRealization_Master>
    {

    }
    public interface IExportRealizationDetailsRepository : IBaseRepository<ExportRealization_Details>
    {

    }
    public interface IMasterLCDetailsRepository : IBaseRepository<COM_MasterLC_Details>
    {
        IEnumerable<SelectListItem> GetAllForDropDown();

    }
    
    public interface IMasterLCDetailsTempRepository : IBaseRepository<COM_MasterLC_Details_Temp>
    {
    }
    public interface IMasterLCExportRepository : IBaseRepository<COM_MasterLCExport>
    {
        IEnumerable<SelectListItem> GetAllForDropDown();

    }
    public interface IReportFilterRepository : IBaseRepository<ReportFilterModel>
    {
    }
    public interface IBuyerGroupRepository : IBaseRepository<BuyerGroup>
    {
        IEnumerable<SelectListItem> GetAllForDropDown();

    }
    public interface INotifyPartyRepository : IBaseRepository<NotifyParty>
    {
        IEnumerable<SelectListItem> GetAllForDropDown();
        IEnumerable<SelectListItem> GetAllForDropDown(int BuyerId);

    }
    public interface IDynamicReportRepository : ISelfRepository<DynamicReport>
    {
        IEnumerable<SelectListItem> GetAllForDropDown();

    }
    public interface IUnitGroupRepository : IBaseRepository<UnitGroup>
    {
        IEnumerable<SelectListItem> GetAllForDropDown();

    }
    public interface ICOM_ProformaInvoiceRepository : IBaseRepository<COM_ProformaInvoice>
    {
        IEnumerable<SelectListItem> GetAllForDropDown();

    }
    public interface ICOM_ProformaInvoice_SubInvoiceRepository : IBaseRepository<COM_ProformaInvoice_Sub>
    {

    }
    public interface IPaymentTermsRepository : ISelfRepository<CommercialPaymentTerms>
    {
        IEnumerable<SelectListItem> GetAllForDropDown();

    }
    public interface IIncoTermRepository : ISelfRepository<CommercialTradeTerm>
    {
        IEnumerable<SelectListItem> GetAllForDropDown();

    }

    public interface ICommercialTypeRepository : ISelfRepository<CommercialType>
    {
        IEnumerable<SelectListItem> GetAllForDropDown();

    }
    public interface IDayListRepository : ISelfRepository<DayList> 
    {
        IEnumerable<SelectListItem> GetAllForDropDown();

    }
    public interface IShipModeRepository : ISelfRepository<ShipMode>
    {
        IEnumerable<SelectListItem> GetAllForDropDown();

    }
    public interface IDayListTermRepository : ISelfRepository<DayListTerm>
    {
        IEnumerable<SelectListItem> GetAllForDropDown();

    }
    public interface IBBLCMainRepository : IBaseRepository<BBLCMain>
    {
        IEnumerable<SelectListItem> GetAllForDropDown();

    }
    public interface IBBLCDetailsRepository : IBaseRepository<BBLC_Details>
    {

    }

    public interface IImportCIMasterRepository : IBaseRepository<ImportCI_Master>
    {
        IEnumerable<SelectListItem> GetAllForDropDown();

    }
    public interface IContainerRepository : IBaseRepository<ContainerModel>
    {
        IEnumerable<SelectListItem> GetAllForDropDown();

    }

    public interface IImportCIDetailsRepository : IBaseRepository<ImportCI_Details>
    {

    }

    public interface IImportCIContainerRepository : IBaseRepository<ImportCI_Container>
    {

    }

    public interface ICOM_CommercialInvoiceRepository : IBaseRepository<COM_CommercialInvoice>
    {

    }
    public interface ICOM_CommercialInvoice_SubRepository : IBaseRepository<COM_CommercialInvoice_Sub>
    {

    }
    public interface ICOM_MachinaryLC_MasterRepository : IBaseRepository<COM_MachinaryLC_Master>
    {

    }
    public interface ICOM_MachinaryLC_DetailsRepository : IBaseRepository<COM_MachinaryLC_Details>
    {

    }
    public interface IDocumentStatusRepository : ISelfRepository<DocumentStatus>
    {
        IEnumerable<SelectListItem> GetAllForDropDown();

    }
    public interface ICommercialLCTypeRepository : ISelfRepository<CommercialLCType>
    {
        IEnumerable<SelectListItem> GetAllForDropDown();

    }
    public interface IDocumentAcceptance_MasterRepository : IBaseRepository<COM_DocumentAcceptance_Master>
    {

    }
    public interface IDocumentAcceptance_DetailsRepository : IBaseRepository<COM_DocumentAcceptance_Details>
    {

    }



    public interface IWorkOrderMasterRepository : IBaseRepository<WorkOrderMaster>
    {

    }
    public interface ICOM_MachineryLCDetailsRepository : IBaseRepository<COM_MachineryLCDetails>
    {

    }
    public interface ICOM_MachineryLCMasterRepository : IBaseRepository<COM_MachineryLCMaster>
    {
        IEnumerable<SelectListItem> GetAllForDropDown();

    }
    public interface IApprovedByRepository : ISelfRepository<ApprovedBy>
    {
        IEnumerable<SelectListItem> GetAllForDropDown();

    }
    public interface IWorkorderStatusRepository : ISelfRepository<WorkorderStatus>
    {
        IEnumerable<SelectListItem> GetAllForDropDown();

    }
    public interface ITruckInfoRepository : IBaseRepository<TruckInfo>
    {

    }
    public interface IBankAccountNoLienBankRepository : IBaseRepository<BankAccountNoLienBank>
    {
        IEnumerable<SelectListItem> GetAllForDropDown();

    }
}
