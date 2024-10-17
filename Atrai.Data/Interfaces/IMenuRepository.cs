using Atrai.Model.Core.Entity;
using Atrai.Data.Interfaces.Base;
using Atrai.Data.Interfaces.Self;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;

namespace Atrai.Data.Interfaces
{
    public interface IMenuRepository : ISelfRepository<MenuModel>
    {
        IEnumerable<SelectListItem> GetParentMenuForDropDown();

        IEnumerable<SelectListItem> GetMenuForDropDown();

    }

    public interface IAndroidMenuRepository : ISelfRepository<AndroidMenuModel>
    {
        IEnumerable<SelectListItem> GetAndroidMenuForDropDown();

    }

    public interface IMenuPermissionRepository : ISelfRepository<MenuPermissionModel>
    {
        IEnumerable<SelectListItem> GetAllForDropDown();
    }

    public interface IAndroidMenuPermissionRepository : ISelfRepository<AndroidMenuPermissionModel>
    {
        IEnumerable<SelectListItem> GetAllForDropDown();
    }


    public interface IFromWarehousePermissionRepository : IBaseRepository<FromWarehousePermissionModel>
    {
        IEnumerable<SelectListItem> GetAllForDropDown();

        //IEnumerable<SelectListItem> GetUserWiseWarehouse(int LuserId);



    }

    public interface IAccountHeadPermissionRepository : IBaseRepository<AccountHeadPermissionModel>
    {
        IEnumerable<SelectListItem> GetAllForDropDown();
        IEnumerable<SelectListItem> GetAllForDropDownForCash();
        IEnumerable<SelectListItem> GetAllForDropDownForBank();


        //IEnumerable<SelectListItem> GetUserWiseWarehouse(int LuserId);



    }

    public interface IToWarehousePermissionRepository : IBaseRepository<ToWarehousePermissionModel>
    {
        IEnumerable<SelectListItem> GetAllForDropDown();

    }


    public interface IMenuPermission_MasterRepository : ISelfRepository<MenuPermission_MasterModel>
    {
        IEnumerable<SelectListItem> GetAllForDropDown();
    }


    public interface IMenuPermission_DetailsRepository : ISelfRepository<MenuPermission_DetailsModel>
    {
    }


    public interface IAndroidMenuPermission_MasterRepository : ISelfRepository<AndroidMenuPermission_MasterModel>
    {
        IEnumerable<SelectListItem> GetAllForDropDown();
    }
    public interface IAndroidMenuPermission_DetailsRepository : ISelfRepository<AndroidMenuPermission_DetailsModel>
    {
    }


}
