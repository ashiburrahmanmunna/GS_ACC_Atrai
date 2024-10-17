using Atrai.Model.Core.Entity;
using Atrai.Data.Interfaces.Base;
using Atrai.Data.Interfaces.Self;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;

namespace Atrai.Data.Interfaces
{
    public interface ICompanyRepository : ISelfRepository<CompanyModel>
    {


        IEnumerable<SelectListItem> GetAllForDropDown();

        IEnumerable<SelectListItem> GetAllForDropDownSuperAdmin();

        IEnumerable<SelectListItem> GetActiveForDropDown();

        string GetComName(int id);
    }

    public interface ICompanyPermissionRepository : ISelfRepository<CompanyPermissionModel>
    {
        IEnumerable<SelectListItem> GetAllForDropDown();

        IEnumerable<SelectListItem> GetActiveForDropDown();

        IEnumerable<SelectListItem> GetActivePermitUserDropDown(int ComId);


    }

    public interface ICountryRepository : ISelfRepository<CountryModel>
    {
        IEnumerable<SelectListItem> GetAllForDropDown();

        IEnumerable<SelectListItem> GetCurrencyList();

    }

    public interface IAccountCategoryRepository : ISelfRepository<AccountCategoryModel>
    {
        IEnumerable<SelectListItem> GetAllForDropDown();
    }

    public interface IBusinessTypeRepository : ISelfRepository<BusinessTypeModel>
    {
        IEnumerable<SelectListItem> GetAllForDropDown();

        IEnumerable<SelectListItem> GetAllForDropDownSuperAdmin();

        IEnumerable<SelectListItem> GetActiveForDropDown();




    }
    public interface ITaxFormRepository : ISelfRepository<TaxFormModel>
    {
        IEnumerable<SelectListItem> GetAllForDropDown();

        IEnumerable<SelectListItem> GetAllForDropDownSuperAdmin();

        IEnumerable<SelectListItem> GetActiveForDropDown();




    }
    public interface IAccountsReportRepository : ISelfRepository<AccountsReportModel>
    {
        IEnumerable<SelectListItem> GetAllForDropDown();

        IEnumerable<SelectListItem> GetAllForDropDownSuperAdmin();

        IEnumerable<SelectListItem> GetActiveForDropDown();




    }
    public interface IFiscalYearTypeRepository : ISelfRepository<FiscalYearTypeModel>
    {
        IEnumerable<SelectListItem> GetAllForDropDown();
    }

    public interface IReportStyleVariableRepository : ISelfRepository<CustomFormStyleVariableModel>
    {
        IEnumerable<SelectListItem> GetAllVariableForTemplate();
        IEnumerable<SelectListItem> GetAllVariableForColor();
        IEnumerable<SelectListItem> GetAllVariableForLogoSize();
        IEnumerable<SelectListItem> GetAllVariableForFontSize();
        IEnumerable<SelectListItem> GetAllVariableForLogoPlacement();
        IEnumerable<SelectListItem> GetAllVariableForFontFamily();
        IEnumerable<SelectListItem> GetAllVariableForPageMargins();
        IEnumerable<SelectListItem> GetAllVariableForGreetingAppeal();
        IEnumerable<SelectListItem> GetAllVariableForGreetingName();


    }
    public interface IReportStyleRepository : ISelfRepository<ReportStyleModel>
    {
        IEnumerable<SelectListItem> GetAllInvoiceReportForDropDown();

        IEnumerable<SelectListItem> GetAllPurchaseReportForDropDown();


        IEnumerable<SelectListItem> GetAllBarcodeReportForDropDown();


    }


    public interface IStoreSettingRepository : IBaseRepository<StoreSettingModel>
    {

    }
    public interface ICustomFormStyleRepository : IBaseRepository<CustomFormStyleModel>
    {

    }
    public interface ICompanyCurrencyRepository : IBaseRepository<CompanyCurrencyModel>
    {

    }



    public interface ISoftwarePackageRepository : ISelfRepository<SoftwarePackageModel>
    {
        IEnumerable<SelectListItem> GetAllForDropDown();
    }

}
