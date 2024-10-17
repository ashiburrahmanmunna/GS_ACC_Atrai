using Atrai.Model.Core.Entity;
using Atrai.Data.Interfaces;
using Atrai.Data.Context.AppDataContext;
using Atrai.Data.Repository.Base;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;
using System.Linq;

namespace Atrai.Data.Repository
{
    public class MemberRepository : BaseRepository<MemberModel>, IMemberRepository
    {
        public MemberRepository(InvoiceDbContext context) : base(context)
        {
        }

        public IEnumerable<SelectListItem> GetAllForDropDown()
        {
            return All().Select(x => new SelectListItem
            {
                Text = x.MembersNameEng + " " + x.MembersNameBng + " " + x.MemberAccessId + " - [ " + x.MemberType + " ] ",
                Value = x.Id.ToString()
            });
        }
    }



    public class MarketRepository : BaseRepository<MarketModel>, IMarketRepository
    {
        public MarketRepository(InvoiceDbContext context) : base(context)
        {
        }

        public IEnumerable<SelectListItem> GetAllForDropDown()
        {
            return All().Select(x => new SelectListItem
            {
                Text = x.MarketNameEng + " " + x.MarketNameBng,
                Value = x.Id.ToString()
            });
        }
    }


    public class ShopRepository : BaseRepository<ShopModel>, IShopRepository
    {
        public ShopRepository(InvoiceDbContext context) : base(context)
        {
        }

        public IEnumerable<SelectListItem> GetAllForDropDown()
        {
            return All().Select(x => new SelectListItem
            {
                Text = x.ShopNameEng + " " + x.ShopNameBng,
                Value = x.Id.ToString()
            });
        }
    }


    public class MemberStatusRepository : BaseRepository<MemberStatusModel>, IMemberStatusRepository
    {
        public MemberStatusRepository(InvoiceDbContext context) : base(context)
        {
        }

        public IEnumerable<SelectListItem> GetAllForDropDown()
        {
            return All().Select(x => new SelectListItem
            {
                Text = x.MemberStatusLong,
                Value = x.Id.ToString()
            });
        }
    }


    public class IssueRepository : BaseRepository<IssueModel>, IIssueRepository
    {
        public IssueRepository(InvoiceDbContext context) : base(context)
        {
        }
    }



    public class IssueItemRepository : BaseRepository<IssueItemsModel>, IIssueItemsRepository
    {
        public IssueItemRepository(InvoiceDbContext context) : base(context)
        {
        }
    }

    public class IssueBatchItemsRepository : BaseRepository<IssueBatchItemsModel>, IIssueBatchItemsRepository
    {
        public IssueBatchItemsRepository(InvoiceDbContext context) : base(context)
        {
        }
    }
}
