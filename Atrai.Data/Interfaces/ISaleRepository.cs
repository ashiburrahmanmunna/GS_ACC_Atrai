using Atrai.Model.Core.Entity;
using Atrai.Data.Interfaces.Base;
using Atrai.Data.Interfaces.Self;
using Atrai.Model.Core.ViewModel;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Atrai.Data.Interfaces
{
    public interface ISaleRepository : IBaseRepository<SalesModel>
    {
        IEnumerable<SelectListItem> GetAllForDropDown(bool isComId = true);
        IEnumerable<SelectListItem> GetAllForDropDownForCustomer(bool isComId = true , int CustomerId=0);
        Task<List<InvoiceReportViewModel>> InvoiceList(DateTime startdt,DateTime endDt); 
    }

    public interface ISalesTagRepository : IBaseRepository<SalesTagModel>
    {
    }
    public interface IRecurringDetailsRepository : IBaseRepository<RecurringDetailsModel>
    {
    }
    public interface ISalesProductTaxRepository : IBaseRepository<SalesProductTaxModel>
    {
    }  
    public interface IFeedbackRepository : IBaseRepository<FeedbackModel>
    {
    }

    public interface ISalesItemsRepository : IBaseRepository<SalesItemsModel>
    {
    }
    public interface IAgencyRepository : IBaseRepository<AgencyModel>
    {
    }
    public interface ISalesTaxRepository : IBaseRepository<SalesTaxModel>
    {
    }
    public interface ITaxCriteriaRepository : ISelfRepository<TaxCriteria>
    {
        IEnumerable<SelectListItem> GetAllDropDown();
    }
    public interface IAdvanceTrasactionTrackingRepository : IBaseRepository<AdvanceTrasactionTrackingModel>
    {
    }
    public interface IMasterSalesTaxRepository : IBaseRepository<MasterSalesTaxModel>
    {
        IEnumerable<SelectListItem> GetAllSalesTaxForDropDown(bool isComId = true);
        IEnumerable<SelectListItem> GetAllPurchaseTaxForDropDown(bool isComId = true);
    }

    //public interface IMasterSalesTaxRepository : IBaseRepository<MasterSalesTaxModel>
    //{
    //}

    public interface ISalesPaymentRepository : IBaseRepository<SalesPaymentModel>
    {
    }

    public interface ISalesTermsRepository : IBaseRepository<SalesTermsModel>
    {
    }


    public interface ISalesBatchItemsRepository : IBaseRepository<SalesBatchItemsModel>
    {
    }

    public interface IColumnFilterRepository : IBaseRepository<ColumnFilterModel>
    {
    }


    public interface ITermsMainRepository : IBaseRepository<TermsMainModel>
    {
        IEnumerable<SelectListItem> GetAllForDropDown(bool isComId = true);

        IEnumerable<SelectListItem> GetSalesTermsList(bool isComId = true);
    }

    public interface ITermsSubRepository : IBaseRepository<TermsSubModel>
    {
    }

    public interface IMonthlySalesRepository : IBaseRepository<MonthlySalesModel>
    {
        IEnumerable<SelectListItem> GetAllForDropDown(bool isComId = true);
    }


    public interface IPaymentTypeRepository : ISelfRepository<PaymentTypeModel>
    {
        IEnumerable<SelectListItem> GetAllForDropDown();
        IEnumerable<SelectListItem> GetAllForDropDownTrading();
        IEnumerable<SelectListItem> GetAllForDropDownDeliveryService();

    }




    public interface IGatePassRepository : IBaseRepository<GatePassModel>
    {
       
        IEnumerable<SelectListItem> GetAllForDropDown(bool isComId = true);

    }
    public interface ITokenSalesRepository : IBaseRepository<TokenSalesModel>
    {
        IEnumerable<SelectListItem> GetAllForDropDown(bool isComId = true);

    }
    public interface IGatePassItemsRepository : IBaseRepository<GatePassItemsModel>
    {
    }

}
