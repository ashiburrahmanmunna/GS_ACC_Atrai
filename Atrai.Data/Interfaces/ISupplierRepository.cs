using Atrai.Model.Core.Entity;
using Atrai.Data.Interfaces.Base;
using Atrai.Data.Interfaces.Self;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;

namespace Atrai.Data.Interfaces
{
    public interface ISupplierRepository : IBaseRepository<SupplierModel>
    {
        bool ValidateSupplier(SupplierModel supplier);
        IEnumerable<SelectListItem> GetAllForDropDown();

        IEnumerable<SelectListItem> GetSupplierLedgerHeadForDropDown();

        IEnumerable<SelectListItem> GetSupplierGroupHeadForDropDown(int SupplierId);

        IEnumerable<SelectListItem> GetSupplierGroupHeadForDropDown();
    }


    public interface ICustomerRepository : IBaseRepository<CustomerModel>
    {
        bool ValidateCustomer(CustomerModel customer);
        IEnumerable<SelectListItem> GetAllForDropDown();

        IEnumerable<SelectListItem> GetCustomerLedgerHeadForDropDown();

        IEnumerable<SelectListItem> GetCustomerGroupHeadForDropDown();
        IEnumerable<SelectListItem> GetCustomerGroupHeadForDropDown(int CustomerId);

        IEnumerable<SelectListItem> CurrentUserCustomerForDropdown();

        IEnumerable<CustomerModel> GetAllCustomer();


    }

    


    public interface ISubscriptionActivationRepository : ISelfRepository<SubscriptionActivationModel>
    {
        IEnumerable<SelectListItem> GetAllForDropDown();
    }

    public interface ISubscriptionActivationCompanyRepository : ISelfRepository<SubscriptionActivationCompanyModel>
    {
        IEnumerable<SelectListItem> GetAllForDropDown();
    }

    public interface ISubscriptionTypeRepository : ISelfRepository<SubscriptionTypeModel>
    {
        IEnumerable<SelectListItem> GetAllForDropDown();

        IEnumerable<SelectListItem> GetActiveForDropDown();
    }


    public interface IPackageActivationRepository : IBaseRepository<PackageActivationModel>
    {
        IEnumerable<SelectListItem> GetAllForDropDown();

    }
}
