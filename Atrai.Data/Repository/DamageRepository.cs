using Atrai.Model.Core.Entity;
using Atrai.Data.Interfaces;
using Atrai.Data.Context.AppDataContext;
using Atrai.Data.Repository.Base;

namespace Atrai.Data.Repository
{
    public class DamageRepository : BaseRepository<DamageModel>, IDamageRepository
    {
        public DamageRepository(InvoiceDbContext context) : base(context)
        {
        }
    }



    public class DamageItemRepository : BaseRepository<DamageItemsModel>, IDamageItemsRepository
    {
        public DamageItemRepository(InvoiceDbContext context) : base(context)
        {
        }
    }

    public class DamageBatchItemsRepository : BaseRepository<DamageBatchItemsModel>, IDamageBatchItemsRepository
    {
        public DamageBatchItemsRepository(InvoiceDbContext context) : base(context)
        {
        }
    }
}
