using Atrai.Model.Core.Entity;
using Atrai.Data.Interfaces.Base;
using Atrai.Data.Interfaces.Self;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;

namespace Atrai.Data.Interfaces
{
    //public interface IAccountHeadRepository : IRecursiveRepository<AccountHeadModel>
    public interface IAccountHeadRepository : IBaseRepository<AccountHeadModel>
    {
        IEnumerable<SelectListItem> GetAllForDropDown();
        IEnumerable<SelectListItem> GetAccountGroupHeadForDropDown();
        IEnumerable<SelectListItem> GetAccountLedgerHeadForDropDown();
        IEnumerable<SelectListItem> GetIncomeExpenseHeadForDropDown();
        IEnumerable<SelectListItem> GetInventoryShrinkageForDropDown();
        IEnumerable<SelectListItem> GetAssetLiabilityHeadForDropDown();
        IEnumerable<SelectListItem> GetCashBankHeadForDropDown(bool WithAccountCode = false);
        IEnumerable<SelectListItem> GetIncomeHeadForDropDown();
        IEnumerable<SelectListItem> GetExpenseHeadForDropDown();

        IEnumerable<SelectListItem> GetDropdownCategoryWise(int? AccountCategoryId);



        IEnumerable<SelectListItem> GetInventoryDropdown();
        IEnumerable<SelectListItem> GetConsumptionDropdown();
        IEnumerable<SelectListItem> GetSalesDropdown();

        IEnumerable<SelectListItem> GetSalesVATDropdown();


        IEnumerable<SelectListItem> GetPurchaseVATDropdown();
        IEnumerable<SelectListItem> GetExpenseVATDropdown();


        IEnumerable<SelectListItem> GetCashHeadForDropDown();
        IEnumerable<SelectListItem> GetBankHeadForDropDown();


        IEnumerable<SelectListItem> GetDiscountIncomeHeadForDropDown();
        IEnumerable<SelectListItem> GetDiscountExpenseHeadForDropDown();
        IEnumerable<SelectListItem> GetLoanAdvanceHeadForDropDown();

        IEnumerable<SelectListItem> GetDebitHeadForDropDown();
        IEnumerable<SelectListItem> GetCreditHeadForDropDown();
        IEnumerable<SelectListItem> GetAssetHeadForDropDown();

        IEnumerable<SelectListItem> GetSupplierPayableHeadForDropDown();
        IEnumerable<SelectListItem> GetCustomerReceivableHeadForDropDown();



    }

    public interface IAccountHeadSystemRepository : ISelfRepository<AccountHeadSystemModel>
    {
        IEnumerable<SelectListItem> GetAccountGroupHeadForDropDown();
    }

    public interface IAccVoucherMainRepository : IBaseRepository<Acc_VoucherMainModel>
    {
        IEnumerable<SelectListItem> GetAllForDropDown();
    }

    public interface IDailyCurrencyRateRepository : IBaseRepository<DailyCurrencyRate>
    {
        IEnumerable<SelectListItem> GetAllForDropDown();
    }

    public interface IAccVoucherSubRepository : IBaseRepository<Acc_VoucherSubModel>
    {
        IEnumerable<SelectListItem> GetAllForDropDown();
    }

    public interface IAccVoucherSubCheckNoRepository : IBaseRepository<Acc_VoucherSubChecknoModel>
    {
        IEnumerable<SelectListItem> GetAllForDropDown();
    }

    public interface IAccVoucherSubSectionRepository : IBaseRepository<Acc_VoucherSubSectionModel>
    {
        IEnumerable<SelectListItem> GetAllForDropDown();
    }

    //public interface ICountryRepository : ISelfRepository<Country>
    //{
    //    IEnumerable<SelectListItem> GetAllForDropDown();
    //}


    //public interface IStateRepository : ISelfRepository<State>
    //{
    //    IEnumerable<SelectListItem> GetAllForDropDown();
    //}


    //public interface ICityRepository : ISelfRepository<City>
    //{
    //    IEnumerable<SelectListItem> GetAllForDropDown();
    //}

    public interface IAccVoucherTranGroupRepository : IBaseRepository<Acc_VoucherTranGroupModel>
    {
        IEnumerable<SelectListItem> GetAllForDropDown();
    }


    public interface IAccVoucherTagsRepository : IBaseRepository<Acc_VoucherTagsModel>
    {
        IEnumerable<SelectListItem> GetAllForDropDown();
    }
    public interface IPurchaseTagsRepository : IBaseRepository<PurchaseTagModel>
    {
        IEnumerable<SelectListItem> GetAllForDropDown();
    }

    public interface ITransactionTagsRepository : IBaseRepository<TransactionTagsModel>
    {
        IEnumerable<SelectListItem> GetAllForDropDown();
    }

    public interface IVoucherTranGroupRepository : ISelfRepository<VoucherTranGroupModel>
    {
        IEnumerable<SelectListItem> GetAllForDropDown();
    }

    public interface IAllReportRepository : ISelfRepository<AccountsReportModel>
    {
        IEnumerable<SelectListItem> GetAllForDropDown();
    }

    public interface IAccVoucherNoPrefixRepository : IBaseRepository<Acc_VoucherNoPrefixModel>
    {
        IEnumerable<SelectListItem> GetAllForDropDown();
    }

    public interface IAccVoucherTypeRepository : ISelfRepository<Acc_VoucherTypeModel>
    {
        IEnumerable<SelectListItem> GetAllForDropDown();
    }

    public interface IAccVoucherCreatedTypeRepository : ISelfRepository<Acc_VoucherNoCreatedTypeModel>
    {
        IEnumerable<SelectListItem> GetAllForDropDown();
    }

    public interface IAccFiscalYearRepository : IBaseRepository<Acc_FiscalYearModel>
    {
        IEnumerable<SelectListItem> GetAllForDropDown();
    }

    public interface IAccFiscalMonthRepository : IBaseRepository<Acc_FiscalMonthModel>
    {
        IEnumerable<SelectListItem> GetAllForDropDown();
    }

    public interface IAccFiscalHalfYearRepository : IBaseRepository<Acc_FiscalHalfYear>
    {
        IEnumerable<SelectListItem> GetAllForDropDown();
    }

    public interface IAccFiscalQtrRepository : IBaseRepository<Acc_FiscalQtr>
    {
        IEnumerable<SelectListItem> GetAllForDropDown();
    }

    public interface IPrdUnitRepository : IBaseRepository<PrdUnit>
    {
        IEnumerable<SelectListItem> GetAllForDropDown();
    }

    public interface IIntegrationSettingMainRepository : IBaseRepository<Cat_Integration_Setting_Main>
    {
        IEnumerable<SelectListItem> GetAllForDropDown();
    }


    public interface IIntegrationSettingDetailsRepository : IBaseRepository<Cat_Integration_Setting_Details>
    {
    }


    public interface IPayrollIntegrationSummaryRepository : IBaseRepository<Cat_PayrollIntegrationSummary>
    {
        IEnumerable<SelectListItem> GetAllForDropDown();
    }

    public interface IProcessLockRepository : IBaseRepository<ProcessLock>
    {
        IEnumerable<SelectListItem> GetAllForDropDown();
    }

    public interface IReportsRepository : ISelfRepository<ReportModel>
    {
        IEnumerable<SelectListItem> GetAllForDropDown();
    }

    public interface IReportGrouptRepository : ISelfRepository<ReportGroupModel>
    {
        IEnumerable<SelectListItem> GetAllForDropDown();
    }

    public interface IReportUserTrackingRepository : IBaseRepository<ReportUserTrackingModel>
    {
    }
}
