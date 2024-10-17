using Atrai.Model.Core.Entity;
using Atrai.Data.Interfaces;
using Atrai.Data.Context.AppDataContext;
using Atrai.Data.Repository.Self;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;
using System.Linq;

namespace Atrai.Data.Repository
{
    public class SubscriptionActivationRepository : SelfRepository<SubscriptionActivationModel>, ISubscriptionActivationRepository
    {
        public SubscriptionActivationRepository(InvoiceDbContext context) : base(context)
        {
        }

        public IEnumerable<SelectListItem> GetAllForDropDown()
        {
            return All().Select(x => new SelectListItem
            {
                Text = x.Remarks,
                Value = x.Id.ToString()
            });
        }
    }

    public class SubscriptionActivationCompanyRepository : SelfRepository<SubscriptionActivationCompanyModel>, ISubscriptionActivationCompanyRepository
    {
        public SubscriptionActivationCompanyRepository(InvoiceDbContext context) : base(context)
        {
        }

        public IEnumerable<SelectListItem> GetAllForDropDown()
        {
            return All().Select(x => new SelectListItem
            {
                Text = x.Remarks,
                Value = x.Id.ToString()
            });
        }
    }


    public class SubscriptionTypeRepository : SelfRepository<SubscriptionTypeModel>, ISubscriptionTypeRepository
    {
        public SubscriptionTypeRepository(InvoiceDbContext context) : base(context)
        {
        }

        public IEnumerable<SelectListItem> GetAllForDropDown()
        {
            return All().Select(x => new SelectListItem
            {
                Text = x.SubscriptionName,
                Value = x.Id.ToString()
            });
        }

        public IEnumerable<SelectListItem> GetActiveForDropDown()
        {
            return All().Where(x => x.IsInActive == false).Select(x => new SelectListItem
            {
                Text = x.SubscriptionName,
                Value = x.Id.ToString()
            });
        }






    }
}
