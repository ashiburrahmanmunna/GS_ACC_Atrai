using Atrai.Model.Core.Entity;
using Atrai.Data.Interfaces.Base;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;

namespace Atrai.Data.Interfaces
{
    public interface IMemberRepository : IBaseRepository<MemberModel>
    {
        IEnumerable<SelectListItem> GetAllForDropDown();
    }

    public interface IMemberStatusRepository : IBaseRepository<MemberStatusModel>
    {
        IEnumerable<SelectListItem> GetAllForDropDown();
    }

    public interface IShopRepository : IBaseRepository<ShopModel>
    {
        IEnumerable<SelectListItem> GetAllForDropDown();
    }

    public interface IMarketRepository : IBaseRepository<MarketModel>
    {
        IEnumerable<SelectListItem> GetAllForDropDown();
    }
}
