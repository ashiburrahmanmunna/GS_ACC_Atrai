using Atrai.Model.Core.Entity;
using Atrai.Data.Interfaces;
using Atrai.Data.Context.AppDataContext;
using Atrai.Data.Repository.Base;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;
using System.Linq;

namespace Atrai.Data.Repository
{
    public class TransactionRepository : BaseRepository<TransactionModel>, ITransactionRepository
    {
        public TransactionRepository(InvoiceDbContext context) : base(context)
        {
        }

    }
    public class TransactionDetailsRepository : BaseRepository<TransactionDetailsModel>, ITransactionDetailsRepository
    {
        public TransactionDetailsRepository(InvoiceDbContext context) : base(context)
        {
        }

    }


    public class SupplierRepository : BaseRepository<SupplierModel>, ISupplierRepository
    {
        public SupplierRepository(InvoiceDbContext context) : base(context)
        {
        }

        public IEnumerable<SelectListItem> GetAllForDropDown()
        {
            return All().Select(x => new SelectListItem
            {
                Text = x.SupplierName,
                Value = x.Id.ToString()
            });
        }


        public IEnumerable<SelectListItem> GetSupplierLedgerHeadForDropDown()
        {
            return All().Where(x => x.SupType == "L").Select(x => new SelectListItem
            {
                Text = x.SupplierName,
                Value = x.Id.ToString()
            });
        }


        public IEnumerable<SelectListItem> GetSupplierGroupHeadForDropDown()
        {
            return All().Where(x => x.SupType == "G").Select(x => new SelectListItem
            {
                Text = x.SupplierName,
                Value = x.Id.ToString()
            });
        }


        public IEnumerable<SelectListItem> GetSupplierGroupHeadForDropDown(int SupplierId)
        {
            return All().Where(x => x.SupType == "G" && x.Id != SupplierId).Select(x => new SelectListItem
            {
                Text = x.SupplierName,
                Value = x.Id.ToString()
            });
        }


        public bool ValidateSupplier(SupplierModel supplier)
        {
            return All(false).Any(x => x.LoginId == supplier.LoginId && x.Password == supplier.Password && x.IsInActive == false);
        }

    }
}
