using Atrai.Model.Core.Entity;
using Atrai.Data.Interfaces;
using Atrai.Data.Context.AppDataContext;
using Atrai.Data.Repository.Base;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;
using System.Linq;

namespace Atrai.Data.Repository
{

    public class InvoiceBillRepository : BaseRepository<InvoiceBillModel>, IInvoiceBillRepository
    {
        public InvoiceBillRepository(InvoiceDbContext context) : base(context)
        {
        }

    }

    public class InternetPackageRepository : BaseRepository<InternetPackageModel>, IInternetPackageRepository
    {
        public InternetPackageRepository(InvoiceDbContext context) : base(context)
        {
        }

        public IEnumerable<SelectListItem> GetAllForDropDown(bool isComId = true)
        {
            return All(isComId).Select(x => new SelectListItem
            {
                Text = x.PackageName + " - " + x.Speed,
                Value = x.Id.ToString()
            });
        }
    }

    public class InternetUserRepository : BaseRepository<InternetUserModel>, IInternetUserRepository
    {
        public InternetUserRepository(InvoiceDbContext context) : base(context)
        {
        }

        public IEnumerable<SelectListItem> GetAllForDropDown()
        {
            return All().Select(x => new SelectListItem
            {
                Text = x.Id + " " + x.UserName + " " + " - [ " + x.UserStatus.UserStatusLong + " ] ",
                Value = x.Id.ToString()
            });
        }
    }

    public class InternetUserStatusRepository : BaseRepository<InternetUserStatusModel>, IInternetUserStatusRepository
    {
        public InternetUserStatusRepository(InvoiceDbContext context) : base(context)
        {
        }

        public IEnumerable<SelectListItem> GetAllForDropDown()
        {
            return All().Select(x => new SelectListItem
            {
                Text = x.UserStatusLong,
                Value = x.Id.ToString()
            });
        }
    }


    public class ExpireDateExtendRepository : BaseRepository<ExpireDateExtendModel>, IExpireDateExtendRepository
    {
        public ExpireDateExtendRepository(InvoiceDbContext context) : base(context)
        {
        }

        public IEnumerable<SelectListItem> GetAllForDropDown(bool isComId = true)
        {
            return All(isComId).Select(x => new SelectListItem
            {
                Text = x.Note,
                Value = x.Id.ToString()
            });
        }
    }
}
