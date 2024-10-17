using Atrai.Model.Core.Entity;
using Atrai.Data.Interfaces;
using Atrai.Data.Interfaces.Base;
using Atrai.Model.Core.ViewModel;
using Atrai.Data.Context.AppDataContext;
using Atrai.Data.Repository.Base;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Atrai.Data.Repository.Self;

namespace Atrai.Data.Repository
{
    public class SaleRepository : BaseRepository<SalesModel>, ISaleRepository
    {
        public SaleRepository(InvoiceDbContext context) : base(context)
        {
        }
        public IEnumerable<SelectListItem> GetAllForDropDown(bool isComId = true)
        {
            //return All(isComId).Where(x=>x.DueAmt - x.AccountTransaction.Sum(a => a.TransactionAmount + a.DiscountAmount) > 0).Select(x => new SelectListItem
            return All(isComId).Where(x => (x.NetAmount - x.SalesPayments.Sum(x => x.Amount)) > 0).Select(x => new SelectListItem
            {
                Text = x.SaleCode + " - " + x.CustomerModel.Name + "  " + x.CustomerName + " - " + x.NetAmount + "    Due : " + (x.NetAmount - (x.SalesPayments.Sum(x => x.Amount))),
                Value = x.Id.ToString()
            });



            //return All(isComId).Where(x => x.NetAmount - (x.SalesPayments.Sum(x => x.Amount) + x.AccountTransaction.Where(x => x.isSystem == false && x.isPost == true).Sum(a => a.TransactionAmount + a.DiscountAmount)) > 0).Select(x => new SelectListItem
            //{
            //    Text = x.SaleCode + " - " + x.CustomerModel.Name + "  " + x.CustomerName + " - " + x.NetAmount,
            //    Value = x.Id.ToString()
            //});
        }


        public IEnumerable<SelectListItem> GetAllForDropDownForCustomer(bool isComId = true,int CustomerId = 0)
        {
            //return All(isComId).Where(x=>x.DueAmt - x.AccountTransaction.Sum(a => a.TransactionAmount + a.DiscountAmount) > 0).Select(x => new SelectListItem
            return All(isComId).Where(x => (x.NetAmount - x.SalesPayments.Sum(x => x.Amount)) > 0 && x.CustomerId == CustomerId).Select(x => new SelectListItem
            {
                Text = x.SaleCode + " - " + x.CustomerModel.Name + "  " + x.CustomerName + " - " + x.NetAmount + "    Due : " + (x.NetAmount - (x.SalesPayments.Sum(x => x.Amount))),
                Value = x.Id.ToString()
            });



            //return All(isComId).Where(x => x.NetAmount - (x.SalesPayments.Sum(x => x.Amount) + x.AccountTransaction.Where(x => x.isSystem == false && x.isPost == true).Sum(a => a.TransactionAmount + a.DiscountAmount)) > 0).Select(x => new SelectListItem
            //{
            //    Text = x.SaleCode + " - " + x.CustomerModel.Name + "  " + x.CustomerName + " - " + x.NetAmount,
            //    Value = x.Id.ToString()
            //});
        }

        public async Task<List<InvoiceReportViewModel>> InvoiceList(DateTime startdt, DateTime endDt)
        {
           var result=await  All().Where(x=>x.DocTypeList.DocFor=="Sales" && x.SalesDate>=startdt && x.SalesDate<=endDt).Select(x=>new InvoiceReportViewModel{
               Id= x.Id,
               Amount=x.NetAmount,
               CustomerName=x.CustomerName,
               DueDate=x.DueDate,
               InvoiceNumber=x.SaleCode,
                Location="",
                Memo=x.Notes,
                 OpenBalance=x.DueAmt,
                  SaleDate=x.SalesDate,
                  TransactionType=x.DocTypeList.DocFor
                
           }).ToListAsync();
           return result;
        }
    }



    public class SalesItemRepository : BaseRepository<SalesItemsModel>, ISalesItemsRepository
    {
        public SalesItemRepository(InvoiceDbContext context) : base(context)
        {
        }
    }

    public class SalesTagRepository : BaseRepository<SalesTagModel>, ISalesTagRepository
    {
        public SalesTagRepository(InvoiceDbContext context) : base(context)
        {
        }
    }
    public class ColumnFilterRepository : BaseRepository<ColumnFilterModel>, IColumnFilterRepository
    {
        public ColumnFilterRepository(InvoiceDbContext context) : base(context)
        {
        }
    }

    public class RecurringDetailsRepository : BaseRepository<RecurringDetailsModel>, IRecurringDetailsRepository
    {
        public RecurringDetailsRepository(InvoiceDbContext context) : base(context)
        {
        }
    }

    public class SalesProductTaxRepository : BaseRepository<SalesProductTaxModel>, ISalesProductTaxRepository
    {
        public SalesProductTaxRepository(InvoiceDbContext context) : base(context)
        {

        }
    }
  
    public class FeedbackRepository : BaseRepository<FeedbackModel>, IFeedbackRepository
    {
        public FeedbackRepository(InvoiceDbContext context) : base(context)
        {

        }
    }

    public class AgencyRepository : BaseRepository<AgencyModel>, IAgencyRepository
    {
        public AgencyRepository(InvoiceDbContext context) : base(context)
        {
        }
    }
    public class SalesTaxRepository : BaseRepository<SalesTaxModel>, ISalesTaxRepository
    {
        public SalesTaxRepository(InvoiceDbContext context) : base(context)
        {
        }
    }
    public class TaxCriteriaRepository : SelfRepository<TaxCriteria>, ITaxCriteriaRepository
    {
        public TaxCriteriaRepository(InvoiceDbContext context) : base(context)
        {
        }

        public IEnumerable<SelectListItem> GetAllDropDown()
        {
            return All().Select(x => new SelectListItem
            {
                Text = x.Criteria,
                Value = x.Id.ToString()
            });
        }
    }
    public class MasterSalesTaxRepository : BaseRepository<MasterSalesTaxModel>, IMasterSalesTaxRepository
    {
        public MasterSalesTaxRepository(InvoiceDbContext context) : base(context)
        {
        }

        public IEnumerable<SelectListItem> GetAllSalesTaxForDropDown(bool isComId = true)
        {
            return All(isComId).Where(x=> x.DocForTax.ToUpper().Contains("Sales".ToUpper())).Select(x => new SelectListItem
            {
                Text = x.Name,
                Value = x.Id.ToString()
            });
        }
        public IEnumerable<SelectListItem> GetAllPurchaseTaxForDropDown(bool isComId = true)
        {
            return All(isComId).Where(x => x.DocForTax.ToUpper().Contains("Purchase".ToUpper())).Select(x => new SelectListItem
            {
                Text = x.Name,
                Value = x.Id.ToString()
            });
        }
    }


    public class SalesPaymentRepository : BaseRepository<SalesPaymentModel>, ISalesPaymentRepository
    {
        public SalesPaymentRepository(InvoiceDbContext context) : base(context)
        {
        }

    }


    public class SalesTermsRepository : BaseRepository<SalesTermsModel>, ISalesTermsRepository
    {
        public SalesTermsRepository(InvoiceDbContext context) : base(context)
        {
        }

    }

    public class SalesBatchItemsRepository : BaseRepository<SalesBatchItemsModel>, ISalesBatchItemsRepository
    {
        public SalesBatchItemsRepository(InvoiceDbContext context) : base(context)
        {
        }
    }

    public class TermsMainRepository : BaseRepository<TermsMainModel>, ITermsMainRepository
    {
        public TermsMainRepository(InvoiceDbContext context) : base(context)
        {
        }
        public IEnumerable<SelectListItem> GetAllForDropDown(bool isComId = true)
        {
            return All(isComId).Select(x => new SelectListItem
            {
                Text = x.TermsName,
                Value = x.Id.ToString()
            });
        }

        public IEnumerable<SelectListItem> GetSalesTermsList(bool isComId = true)
        {
            return All(isComId).Where(x => x.TermsName.ToUpper().Contains("Sales".ToUpper())).Select(x => new SelectListItem
            {
                Text = x.TermsName,
                Value = x.Id.ToString()
            });
        }
    }

    public class TermsSubRepository : BaseRepository<TermsSubModel>, ITermsSubRepository
    {
        public TermsSubRepository(InvoiceDbContext context) : base(context)
        {
        }
    }

    public class AdvanceTrasactionTrackingRepository : BaseRepository<AdvanceTrasactionTrackingModel>, IAdvanceTrasactionTrackingRepository
    {
        public AdvanceTrasactionTrackingRepository(InvoiceDbContext context) : base(context)
        {
        }
    }


    public class MonthlySalesRepository : BaseRepository<MonthlySalesModel>, IMonthlySalesRepository
    {
        public MonthlySalesRepository(InvoiceDbContext context) : base(context)
        {
        }
        public IEnumerable<SelectListItem> GetAllForDropDown(bool isComId = true)
        {
            return All(isComId).Select(x => new SelectListItem
            {
                Text = x.TotalSales.GetValueOrDefault().ToString(),
                Value = x.MonthId.ToString()
            });
        }
    }




    public class GatePassRepository : BaseRepository<GatePassModel>, IGatePassRepository
    {
        public GatePassRepository(InvoiceDbContext context) : base(context)
        {
        }
        public IEnumerable<SelectListItem> GetAllForDropDown(bool isComId = true)
        {
            return All(isComId).Select(x => new SelectListItem
            {
                Text = x.GatePassCode,
                Value = x.Id.ToString()
            });

        }
    }


    public class TokenSalesRepository : BaseRepository<TokenSalesModel>, ITokenSalesRepository
    {
        public TokenSalesRepository(InvoiceDbContext context) : base(context)
        {
        }
        public IEnumerable<SelectListItem> GetAllForDropDown(bool isComId = true)
        {
            return All(isComId).Select(x => new SelectListItem
            {
                Text = x.TokenCode + " - " + x.CustomerModel.Name + "  " + x.CustomerName,
                Value = x.Id.ToString()
            });
        }
    }



    public class GatePassItemRepository : BaseRepository<GatePassItemsModel>, IGatePassItemsRepository
    {
        public GatePassItemRepository(InvoiceDbContext context) : base(context)
        {
        }
    }


}
