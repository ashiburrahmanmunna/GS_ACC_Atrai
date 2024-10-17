using Atrai.Model.Core.Entity;
using Atrai.Data.Interfaces.Base;
using Atrai.Data.Interfaces.Self;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;
using System.Linq;

namespace Atrai.Data.Interfaces
{
    public interface IProductRepository : IBaseRepository<ProductModel>
    {
        IEnumerable<SelectListItem> GetAllBarcodeForDropDown(bool isComId = true);

        IEnumerable<SelectListItem> GetAllProductForDropDown(bool isComId = true);

        IEnumerable<SelectListItem> GetComplexProductDropDown(bool isComId = true);


        IEnumerable<SelectListItem> GetBrandDropDown(bool isComId = true);
        IEnumerable<SelectListItem> GetModelDropDown(bool isComId = true);
        IEnumerable<SelectListItem> GetModelByBrandDropDown(int BrandId);
        IEnumerable<SelectListItem> GetColorDropDown(bool isComId = true);
        IEnumerable<SelectListItem> GetSizeDropDown(bool isComId = true);

    }

    public interface IProductColorRepository : ISelfRepository<ProductColorModel>
    {
        IEnumerable<SelectListItem> GetAllForDropDown();
    }


    public interface IProductSizeRepository : ISelfRepository<ProductSizeModel>
    {
        IEnumerable<SelectListItem> GetAllForDropDown();
    }

    public interface IProductTypeRepository : ISelfRepository<ProductType>
    {
    }

    public interface IProductWarehouseRepository : IBaseRepository<ProductWarehouseModel>
    {
    }
    public interface IWarehouseRepository : IBaseRepository<WarehouseModel>
    {
        IEnumerable<SelectListItem> GetAllForDropDown();

        IEnumerable<SelectListItem> GetWarehouseLedgerHeadForDropDown();

        IEnumerable<SelectListItem> GetWarehouseGroupHeadForDropDown();


    }
    public interface ITagsRepository : IBaseRepository<TagsModel>
    {
        IEnumerable<SelectListItem> GetAllForDropDown();

        IEnumerable<SelectListItem> GetAllForDropDownForGroup();
    }

    public interface ICategoryRepository : IBaseRepository<CategoryModel>
    {
        IEnumerable<SelectListItem> GetAllForDropDown(bool isComId = true);

        IEnumerable<SelectListItem> GetAllForDropDownComId(bool isComId = true, int ComId = 0);

    }

    public interface IBrandRepository : IBaseRepository<BrandModel>
    {
        IEnumerable<SelectListItem> GetAllForDropDown(bool isComId = true);
    }


    public interface IDocApprovalSettingRepository : IBaseRepository<DocApprovalSettingModel>
    {
        IEnumerable<SelectListItem> GetAllForDropDown(bool isComId = true);
    }

    public interface IApprovalStatusRepository : ISelfRepository<ApprovalStatusModel>
    {
        IEnumerable<SelectListItem> GetAllForDropDown(bool isComId = true);
    }

    public interface ITransactionApprovalStatusRepository : IBaseRepository<TransactionApprovalStatusModel>
    {
       
    }

    public interface IDesignationRepository : IBaseRepository<Cat_DesignationModel>
    {
        IEnumerable<SelectListItem> GetAllForDropDown(bool isComId = true);
    }



    public interface ITaskToDoRepository : IBaseRepository<TaskToDoModel>
    {
        IEnumerable<SelectListItem> GetAllForDropDown(bool isComId = true);
    }
    public interface IMobileTextAnimationRepository : IBaseRepository<MobileTextAnimationModel>
    {
    }

    public interface IEmailSettingRepository : IBaseRepository<EmailSettingModel>
    {
        IEnumerable<SelectListItem> GetAllForDropDown(bool isComId = true);
    }


    public interface ISmsSettingRepository : IBaseRepository<SmsSettingModel>
    {
        IEnumerable<SelectListItem> GetAllForDropDown(bool isComId = true);
    }

    public interface IVoterRepository : IBaseRepository<VoterModel>
    {
        IEnumerable<SelectListItem> GetAllForDropDown(bool isComId = true);
    }

    public interface IWarrentyRepository : ISelfRepository<WarrentyModel>
    {
        IEnumerable<SelectListItem> GetAllForDropDown();
    }

    public interface ITimeZoneSettingsRepository : ISelfRepository<TimeZoneSettingsModel>
    {
        IEnumerable<SelectListItem> GetAllForDropDown();
    }

    public interface IDurationTimeRepository : ISelfRepository<DurationTimeModel>
    {
        IEnumerable<SelectListItem> GetAllForDropDown();
    }
    //public interface ITradeTermsRepository : ISelfRepository<TradeTermsModel>
    //{
    //    IEnumerable<SelectListItem> GetAllForDropDown();
    //}

    //public interface ISizeRepository : ISelfRepository<SizeModel>
    //{
    //    IEnumerable<SelectListItem> GetAllForDropDown();



    //}

    public interface IDocTypeRepository : ISelfRepository<DocTypeModel>
    {
        IEnumerable<SelectListItem> GetAllDocForDropDown();
        IEnumerable<SelectListItem> GetAllDoctypeList();
        IEnumerable<SelectListItem> GetSalesDocForDropDown();
        List<DocTypeModel> GetAllDocTypeSalesForDropDown();
        IEnumerable<SelectListItem> GetPurchaseDocForDropDown();
        IEnumerable<SelectListItem> GetApprovalDocForDropDown();
        IEnumerable<SelectListItem> GetApprovalDocValueForDropDown();
        IEnumerable<DocTypeModel> GetAllDoctype();

    }


    public interface IApprovalTypeRepository : ISelfRepository<ApprovalTypeModel>
    {
        IEnumerable<SelectListItem> GetAllForDropDown();
    }
    //public interface IColorRepository : ISelfRepository<ColorModel>
    //{
    //    IEnumerable<SelectListItem> GetAllForDropDown();
    //    IEnumerable<SelectListItem> GetAllForDropDownWtihValue();



    //}
    public interface IMasterPOConsumptionRepository : IBaseRepository<MASTERPO_ConsumptionModel>
    {
    }
    public interface IBOMMasterRepository : IBaseRepository<BOMMasterModel>
    {
    }
    public interface IBOMDetailsRepository : IBaseRepository<BOMDetailsModel>
    {
    }
    public interface IBOMQuantitySizeWiseRepository : IBaseRepository<BOMQuantitySizeWiseModel>
    {
    }
    public interface IDailyProduction_MasterRepository : IBaseRepository<DailyProduction_MasterModel>
    {
    }
    public interface IDailyProduction_DetailsRepository : IBaseRepository<DailyProduction_DetailsModel>
    {
    }
    public interface IDeptWiseDailyProduction_MasterRepository : IBaseRepository<DeptWise_DailyProduction_MasterModel>
    {
    }
    public interface IDeptWiseDailyProduction_DetailsRepository : IBaseRepository<DeptWise_DailyProduction_DetailsModel>   
    {
    }
    public interface IBOMAllocationCategoryRepository : IBaseRepository<BOMAllocationCategoryModel>
    {
        IEnumerable<SelectListItem> GetAllForDropDown();
    }

    public interface IBuyerPO_MasterRepository : IBaseRepository<BuyerPO_MasterModel>
    {
    }
    public interface IBuyerPO_DetailsRepository : IBaseRepository<BuyerPO_DetailsModel>
    {
    }

    public interface IProductReviewsRepository : ISelfRepository<ProductReviewsModel>
    {
        IEnumerable<SelectListItem> GetAllForDropDown();
    }


    public interface IProductSecUnitRepository : IBaseRepository<ProductSecUnitModel>
    {

    }

    public interface IWarrantyItemsRepository : IBaseRepository<WarrantyItemsModel>
    {

    }



    public interface IUnitRepository : IBaseRepository<UnitModel>
    {
        IEnumerable<SelectListItem> GetAllForDropDown();
    }
    public interface ITermRepository : IBaseRepository<PaymentTermsModel>
    {
        IEnumerable<SelectListItem> GetAllForDropDown();
        IEnumerable<PaymentTermsModel> GetAllTerms();
        List<PaymentTermsModel> GetAlltermsForDropDown();
    }

    public interface ITermMainRepository : IBaseRepository<TermsMainModel>
    {
        IEnumerable<SelectListItem> GetAllForDropDown();
        IEnumerable<TermsMainModel> GetAllTerms();
        List<TermsMainModel> GetAlltermsForDropDown();
    }
    public interface IVariableRepository : ISelfRepository<VariableModel>
    {
        IEnumerable<SelectListItem> GetAllForDropDown(string VarType);
        //IEnumerable<VariableModel> GetAllTerms();
        List<VariableModel> GetAllVariableForDropDown(string VarType);
    }
    public interface ITradeTermRepository : IBaseRepository<TradeTermsModel>
    {
        IEnumerable<SelectListItem> GetAllForDropDown();

        IEnumerable<SelectListItem> GetAllTradeTerms();
        IEnumerable<TradeTermsModel> GetAllTerms();
    }

    public interface IOfferRepository : IBaseRepository<OfferModel>
    {
        IEnumerable<SelectListItem> GetAllForDropDown();
    }


    public interface IShippingChargeRepository : IBaseRepository<ShippingChargeModel>
    {
        IEnumerable<SelectListItem> GetAllForDropDown();
    }

    public interface ILinkShareRepository : IBaseRepository<LinkShareModel>
    {

    }

    public interface IBarcodePrintRepository : IBaseRepository<BarcodePrintModel>
    {
    }



    public interface IBookRepository : IBaseRepository<BookModel>
    {
        IEnumerable<SelectListItem> GetAllForDropDown(bool isComId = true);


        //Task<int> AddNewBook(BookModel model);
        //Task<List<BookModel>> GetAllBooks();
        //Task<BookModel> GetBookById(int id);


    }

    public interface IGalleryRepository : ISelfRepository<GalleryModel>
    {

    }



    public interface INotificationRepository : IBaseRepository<NotificationModel>
    {
        IEnumerable<SelectListItem> GetAllForDropDown(bool isComId = true);
    }

    public interface IDiscountTypeRepository : IBaseRepository<DiscountTypeModel>
    {
        IEnumerable<SelectListItem> GetAllForDropDown(bool isComId = true);
    }

    public interface IDocStatusRepository : ISelfRepository<DocStatusModel>
    {
        //IEnumerable<SelectListItem> GetAllForDropDown();
        IEnumerable<DocStatusModel> GetAllDoctype();

    }
    public interface IStatusRepository : ISelfRepository<StatusModel>
    {
        IEnumerable<SelectListItem> GetAllForDropDown();
        //IEnumerable<StatusModel> GetAllDocStatus();
        IEnumerable<StatusModel> GetAllDocStatusForExpenses();

    }

    public interface INotificationSeenRepository : IBaseRepository<NotificationSeenModel>
    {
    }

    public interface IEmployeeAttendanceRepository : IBaseRepository<EmployeeAttendanceModel>
    {
    }
    public interface IDyDashBoardModelRepository : IBaseRepository<DyDashBoardModel>
    {

    }
    public interface IDashBoardLayoutOrderRepository : IBaseRepository<DashBoardLayoutOrder>
    {
        //public void AddDashBoadLayout(IEnumerable<DashBoardLayoutOrder> model);
    }
    public interface INotificationSettingRepository : IBaseRepository<NotificationSetting>
    {
        IEnumerable<SelectListItem> GetAllForDropDown(bool isComId = true);
    }
}

