using Atrai.Model.Core.Entity;
using Atrai.Data.Interfaces;
using Atrai.Data.Context.AppDataContext;
using Atrai.Data.Repository.Base;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;
using System.Linq;

namespace Atrai.Data.Repository
{
    public class PurchaseReturnRepository : BaseRepository<PurchaseReturnModel>, IPurchaseReturnRepository
    {
        public PurchaseReturnRepository(InvoiceDbContext context) : base(context)
        {
        }



        public IEnumerable<SelectListItem> GetAllForDropDown(bool isComId = true)
        {
            //return All(isComId).Where(x=>x.DueAmt - x.AccountTransaction.Sum(a => a.TransactionAmount + a.DiscountAmount) > 0).Select(x => new SelectListItem
            return All(isComId).Where(x => x.DueAmt - x.AccountTransaction.Where(x => x.isSystem == false && x.isPost == true).Sum(a => a.TransactionAmount + a.DiscountAmount) > 0).Select(x => new SelectListItem

            {
                Text = x.PurchaseReturnCode + " - " + x.SupplierModel.SupplierName + " - " + x.SupplierName,
                Value = x.Id.ToString()
            });
        }




    }

    public class PurchaseReturnPaymentRepository : BaseRepository<PurchaseReturnPaymentModel>, IPurchaseReturnPaymentRepository
    {
        public PurchaseReturnPaymentRepository(InvoiceDbContext context) : base(context)
        {
        }

    }


    public class PurchaseReturnItemRepository : BaseRepository<PurchaseReturnItemsModel>, IPurchaseReturnItemsRepository
    {
        public PurchaseReturnItemRepository(InvoiceDbContext context) : base(context)
        {
        }
    }

    public class PurchaseReturnBatchItemsRepository : BaseRepository<PurchaseReturnBatchItemsModel>, IPurchaseReturnBatchItemsRepository
    {
        public PurchaseReturnBatchItemsRepository(InvoiceDbContext context) : base(context)
        {
        }
    }
}
