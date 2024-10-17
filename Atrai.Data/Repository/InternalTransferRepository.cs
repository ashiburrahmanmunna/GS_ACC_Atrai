using Atrai.Model.Core.Entity;
using Atrai.Data.Interfaces;
using Atrai.Data.Context.AppDataContext;
using Atrai.Data.Repository.Base;

namespace Atrai.Data.Repository
{
    public class InternalTransferRepository : BaseRepository<InternalTransferModel>, IInternalTransferRepository
    {
        public InternalTransferRepository(InvoiceDbContext context) : base(context)
        {
        }
    }



    public class InternalTransferItemRepository : BaseRepository<InternalTransferItemsModel>, IInternalTransferItemsRepository
    {
        public InternalTransferItemRepository(InvoiceDbContext context) : base(context)
        {
        }
    }

    public class InternalTransferBatchItemsRepository : BaseRepository<InternalTransferBatchItemsModel>, IInternalTransferBatchItemsRepository
    {
        public InternalTransferBatchItemsRepository(InvoiceDbContext context) : base(context)
        {
        }
    }
}
