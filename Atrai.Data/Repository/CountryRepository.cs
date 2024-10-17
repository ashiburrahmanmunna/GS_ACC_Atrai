using Atrai.Model.Core.Entity;
using Atrai.Data.Interfaces;
using Atrai.Data.Context.AppDataContext;
using Atrai.Data.Repository.Self;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;
using System.Linq;

namespace Atrai.Data.Repository
{
    public class CountryRepository : SelfRepository<CountryModel>, ICountryRepository
    {
        public CountryRepository(InvoiceDbContext context) : base(context)
        {
        }

        public IEnumerable<SelectListItem> GetAllForDropDown()
        {
            return All().Where(x => x.isActive == true).Select(x => new SelectListItem
            {
                Text = x.CountryName,
                Value = x.Id.ToString()
            });
        }


        public IEnumerable<SelectListItem> GetCurrencyList()
        {
            return All().Where(x => x.isActive == true).Select(x => new SelectListItem
            {
                Text = x.CurrencyShortName,
                Value = x.Id.ToString()
            });
        }

    }

    public class AccountCategoryRepository : SelfRepository<AccountCategoryModel>, IAccountCategoryRepository
    {
        public AccountCategoryRepository(InvoiceDbContext context) : base(context)
        {
        }

        public IEnumerable<SelectListItem> GetAllForDropDown()
        {
            return All().Where(x => x.IsActive == true).Select(x => new SelectListItem
            {
                Text = x.AccountCategoryName,
                Value = x.Id.ToString()
            });
        }
    }
}
