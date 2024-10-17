using Atrai.Model.Core.Entity;
using Atrai.Data.Interfaces;
using Atrai.Data.Context.AppDataContext;
using Atrai.Data.Repository.Base;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;
using System.Linq;

namespace Atrai.Data.Repository
{
    public class CustomerRepository : BaseRepository<CustomerModel>, ICustomerRepository
    {
        private readonly IHttpContextAccessor httpcontext;
        public CustomerRepository(InvoiceDbContext context) : base(context)
        {
            httpcontext = new HttpContextAccessor();
        }

        public IEnumerable<SelectListItem> GetAllForDropDown()
        {
            return All().Select(x => new SelectListItem
            {
                Text = x.Name + " " + x.PrimaryAddress,
                Value = x.Id.ToString()
            });
        }

        public IEnumerable<SelectListItem> GetCustomerLedgerHeadForDropDown()
        {
            return All().Where(x => x.CustType == "L").Select(x => new SelectListItem
            {
                Text = x.Name + " " + x.PrimaryAddress,
                Value = x.Id.ToString()
            });
        }

        public IEnumerable<SelectListItem> GetCustomerGroupHeadForDropDown()
        {
            return All().Where(x => x.CustType == "G").Select(x => new SelectListItem
            {
                Text = x.Name,
                Value = x.Id.ToString()
            });
        }

        public IEnumerable<SelectListItem> GetCustomerGroupHeadForDropDown(int CustomerId)
        {
            return All().Where(x => x.CustType == "G" && x.Id != CustomerId).Select(x => new SelectListItem
            {
                Text = x.Name,
                Value = x.Id.ToString()
            });
        }


        public bool ValidateCustomer(CustomerModel customer)
        {
            return All(false).Any(x => x.LoginId == customer.LoginId && x.Password == customer.Password && x.IsInActive == false);
        }


        public IEnumerable<SelectListItem> CurrentUserCustomerForDropdown()
        {
            var sessionLuserId = (httpcontext.HttpContext.Session.GetInt32("UserId"));

            //return All().Where(x => x.IsInActive == false && x.SalesRepresentative.UserAccountList.LuserId == sessionLuserId).ToList().Select(x => new SelectListItem
            return All().Where(x => x.IsInActive == false).ToList().Select(x => new SelectListItem

            {
                Text = x.Name + " - " + x.Email,
                Value = x.Id.ToString()
            });
        }

        public IEnumerable<CustomerModel> GetAllCustomer()
        {
            return AllData();
        }

    }
}
