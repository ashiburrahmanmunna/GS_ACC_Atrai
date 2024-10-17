using Atrai.Model.Core.Entity;
using Atrai.Data.Interfaces;
using Atrai.Data.Context.AppDataContext;
using Atrai.Data.Repository.Base;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;
using System.Linq;

namespace Atrai.Data.Repository
{
    public class SaleReturnRepository : BaseRepository<SalesReturnModel>, ISalesReturnRepository
    {
        public SaleReturnRepository(InvoiceDbContext context) : base(context)
        {
        }



        public IEnumerable<SelectListItem> GetAllForDropDown(bool isComId = true)
        {
            //return All(isComId).Where(x=>x.DueAmt - x.AccountTransaction.Sum(a => a.TransactionAmount + a.DiscountAmount) > 0).Select(x => new SelectListItem
            return All(isComId).Where(x => x.DueAmt - x.AccountTransaction.Where(x => x.isSystem == false && x.isPost == true).Sum(a => a.TransactionAmount + a.DiscountAmount) > 0).Select(x => new SelectListItem

            {
                Text = x.SalesReturnCode + " - " + x.CustomerModel.Name + " - " + x.CustomerName,
                Value = x.Id.ToString()
            });
        }




    }

    public class SalesReturnPaymentRepository : BaseRepository<SalesReturnPaymentModel>, ISalesReturnPaymentRepository
    {
        public SalesReturnPaymentRepository(InvoiceDbContext context) : base(context)
        {
        }

    }


    public class SalesReturnItemRepository : BaseRepository<SalesReturnItemsModel>, ISalesReturnItemsRepository
    {
        public SalesReturnItemRepository(InvoiceDbContext context) : base(context)
        {
        }
    }

    public class SalesReturnBatchItemsRepository : BaseRepository<SalesReturnBatchItemsModel>, ISalesReturnBatchItemsRepository
    {
        public SalesReturnBatchItemsRepository(InvoiceDbContext context) : base(context)
        {
        }
    }

    public class SalesExchangeItemRepository : BaseRepository<SalesExchangeItemsModel>, ISalesExchangeItemsRepository
    {
        public SalesExchangeItemRepository(InvoiceDbContext context) : base(context)
        {
        }
    }

    public class SalesExchangeBatchItemsRepository : BaseRepository<SalesExchangeBatchItemsModel>, ISalesExchangeBatchItemsRepository
    {
        public SalesExchangeBatchItemsRepository(InvoiceDbContext context) : base(context)
        {
        }
    }
}
