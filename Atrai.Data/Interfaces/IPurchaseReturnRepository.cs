using Atrai.Model.Core.Entity;
using Atrai.Data.Interfaces.Base;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;

namespace Atrai.Data.Interfaces
{
    public interface IPurchaseReturnRepository : IBaseRepository<PurchaseReturnModel>
    {
        IEnumerable<SelectListItem> GetAllForDropDown(bool isComId = true);
    }

    public interface IPurchaseReturnItemsRepository : IBaseRepository<PurchaseReturnItemsModel>
    {
    }

    public interface IPurchaseReturnPaymentRepository : IBaseRepository<PurchaseReturnPaymentModel>
    {
    }


    public interface IPurchaseReturnBatchItemsRepository : IBaseRepository<PurchaseReturnBatchItemsModel>
    {
    }

    public interface IPurchaseItemsRepository : IBaseRepository<PurchaseItemsModel>
    {
        IEnumerable<PurchaseItemsModel> GetAllPurchase();

    }

    public interface IPurchaseProductTaxRepository : IBaseRepository<PurchaseProductTaxModel>
    {
    }
    public interface IPurchaseItemsCategoryRepository : IBaseRepository<PurchaseItemsCategoryModel>
    {
        IEnumerable<PurchaseItemsCategoryModel> GetAllPurchase();

    }

    public interface IPurchaseRepository : IBaseRepository<PurchaseModel>
    {
        IEnumerable<SelectListItem> GetAllForDropDown(bool isComId = true);
        IEnumerable<SelectListItem> GetAllForDropDownForSupplier(bool isComId = true,int SupplierId=0);
        IEnumerable<PurchaseModel> GetAllPurchase();
    }
    public interface IPaymentMethodRepository : IBaseRepository<PaymentMethodModel>
    {
    }

    public interface IPurchasePaymentRepository : IBaseRepository<PurchasePaymentModel>
    {
    }

    public interface IPurchaseBatchItemsRepository : IBaseRepository<PurchaseBatchItemsModel>
    {

    }



    //newly added
    public interface IBudgetMainRepository : IBaseRepository<Acc_BudgetMainModel>
    {
        IEnumerable<Acc_BudgetMainModel> GetAllBudget();
        IEnumerable<SelectListItem> GetAllForDropDown();

    }


    public interface IBudgetSubRepository : IBaseRepository<BudgetSubModel>
    {
        IEnumerable<BudgetSubModel> GetAllBudget();

    }

    public interface IColorsChildRepository : IBaseRepository<ColorsChildModel>
    {
        IEnumerable<ColorsChildModel> GetAllData();
        //IEnumerable<ColorsChildModel> GetAllForDropDown();
        IEnumerable<SelectListItem> GetAllForDropDown(bool isComId = true);
    }


    public interface IColorsRepository : IBaseRepository<ColorsModel>
    {
        IEnumerable<ColorsModel> GetAllData();
        //IEnumerable<ColorsModel> GetAllForDropDown();
        IEnumerable<SelectListItem> GetAllForDropDown(bool isComId = true);
    }
    public interface ISizesRepository : IBaseRepository<SizesModel>
    {
        IEnumerable<SelectListItem> GetAllForDropDown(bool isComId = true);
    }


    public interface IBomCategoryRepository : IBaseRepository<BOMAllocationCategoryModel>
    {
        IEnumerable<SelectListItem> GetAllForDropDown(bool isComId = true);
    }

    public interface IStyleRepository : IBaseRepository<StyleModel>
    {
        IEnumerable<SelectListItem> GetAllForDropDown(bool isComId = true);
        IEnumerable<SelectListItem> GetAllForDropDownForSupplier(bool isComId = true, int SupplierId = 0);
        IEnumerable<StyleModel> GetAllStyle();
    }



    public interface IColorChildRepository : IBaseRepository<ColorsChildModel>
    {
        IEnumerable<ColorsChildModel> GetAllColors();

    }
    public interface ISizeChildRepository : IBaseRepository<SizesChildModel>
    {
        IEnumerable<SizesChildModel> GetAllSizes();

    }














    public interface IMasterPORepository : IBaseRepository<MasterPOModel>
    {
        IEnumerable<SelectListItem> GetAllForDropDown(bool isComId = true);
        IEnumerable<SelectListItem> GetAllForDropDownForSupplier(bool isComId = true, int SupplierId = 0);
        IEnumerable<MasterPOModel> GetAllStyle();
    }



    public interface IMasterPODetailsRepository : IBaseRepository<MasterPODetailsModel>
    {
        IEnumerable<MasterPODetailsModel> GetAllColors();

    }

    public interface IPurchaseTermsRepository : IBaseRepository<PurchaseTermsModel>
    {
        IEnumerable<SelectListItem> GetAllForDropDown(bool isComId = true);
    }

}
