using Atrai.Model.Core.Entity;
using Atrai.Data.Interfaces;
using Atrai.Data.Context.AppDataContext;
using Atrai.Data.Repository.Base;
using Atrai.Data.Repository.Self;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;
using System.Linq;

namespace Atrai.Data.Repository
{
    public class MenuRepository : SelfRepository<MenuModel>, IMenuRepository
    {
        public MenuRepository(InvoiceDbContext context) : base(context)
        {
        }

        public IEnumerable<SelectListItem> GetParentMenuForDropDown()
        {
            return All().Where(x => x.ParentId == null).Select(x => new SelectListItem
            {
                Text = x.MenuName,
                Value = x.Id.ToString()
            });
        }

        public IEnumerable<SelectListItem> GetMenuForDropDown()
        {
            return All().Where(x => x.ParentId != null).Select(x => new SelectListItem
            {
                Text = x.MenuName,
                Value = x.Id.ToString()
            });
        }





    }

    public class AndroidMenuRepository : SelfRepository<AndroidMenuModel>, IAndroidMenuRepository
    {
        public AndroidMenuRepository(InvoiceDbContext context) : base(context)
        {
        }

        public IEnumerable<SelectListItem> GetAndroidMenuForDropDown()
        {
            return All().Select(x => new SelectListItem
            {
                Text = x.MenuName + " - " + x.MenuCaption,
                Value = x.Id.ToString()
            });
        }


    }

    public class MenuPermissionRepository : SelfRepository<MenuPermissionModel>, IMenuPermissionRepository
    {
        public MenuPermissionRepository(InvoiceDbContext context) : base(context)
        {
        }

        public IEnumerable<SelectListItem> GetAllForDropDown()
        {
            return All().Select(x => new SelectListItem
            {
                Text = x.Id.ToString(),
                Value = x.Id.ToString()
            });
        }


        //public async Task<List<MenuPermissionModel>> GetPermissionsByRoleIdAsync(int id)
        //{
        //	var items = All().Where(x=>x.UserRoleId == id).AsNoTracking().ToListAsync();
        //	//  join rm in All()
        //	//on new { X1 = m.Id, X2 = id } equals new { X1 = rm.NavigationMenuId, X2 = rm.RoleId }
        //	//into rmp
        //	//from rm in rmp.DefaultIfEmpty()
        //	//Select new MenuPermissionModel()
        //	//{
        //	// Id = m.Id,
        //	// Name = m.Name,
        //	// Area = m.Area,
        //	// ActionName = m.ActionName,
        //	// ControllerName = m.ControllerName,
        //	// IsExternal = m.IsExternal,
        //	// ExternalUrl = m.ExternalUrl,
        //	// DisplayOrder = m.DisplayOrder,
        //	// ParentMenuId = m.ParentMenuId,
        //	// Visible = m.Visible,
        //	// Permitted = rm.RoleId == id
        //	//})


        //	//return items;
        //}
    }

    public class AndroidMenuPermissionRepository : SelfRepository<AndroidMenuPermissionModel>, IAndroidMenuPermissionRepository
    {
        public AndroidMenuPermissionRepository(InvoiceDbContext context) : base(context)
        {
        }

        public IEnumerable<SelectListItem> GetAllForDropDown()
        {
            return All().Select(x => new SelectListItem
            {
                Text = x.Id.ToString(),
                Value = x.Id.ToString()
            });
        }


    }







    public class FromWarehousePermissionRepository : BaseRepository<FromWarehousePermissionModel>, IFromWarehousePermissionRepository
    {
        private readonly IHttpContextAccessor httpcontext;
        public FromWarehousePermissionRepository(InvoiceDbContext context) : base(context)
        {
            httpcontext = new HttpContextAccessor();
        }

        public IEnumerable<SelectListItem> GetAllForDropDown()
        {
            var LuserId = httpcontext.HttpContext.Session.GetInt32("UserId");

            return All().Where(x => x.LuserIdAllow == LuserId).Select(x => new SelectListItem
            {
                Text = x.WarehouseList.WhShortName.ToString(),
                Value = x.WarehouseList.Id.ToString()
            });
        }

        //public IEnumerable<SelectListItem> GetUserWiseWarehouse(int LuserId)
        //{
        //    return All(true).Where(x=>x.LuserId == LuserId)
        //}


    }

    public class AccountHeadPermissionRepository : BaseRepository<AccountHeadPermissionModel>, IAccountHeadPermissionRepository
    {
        private readonly IHttpContextAccessor httpcontext;
        public AccountHeadPermissionRepository(InvoiceDbContext context) : base(context)
        {
            httpcontext = new HttpContextAccessor();
        }

        public IEnumerable<SelectListItem> GetAllForDropDown()
        {
            var LuserId = httpcontext.HttpContext.Session.GetInt32("UserId");

            return All().Where(x => x.LuserIdAllow == LuserId).Select(x => new SelectListItem
            {
                Text = x.AccountHeadList.AccName.ToString(),
                Value = x.AccountHeadList.Id.ToString()
            });
        }

        public IEnumerable<SelectListItem> GetAllForDropDownForCash()
        {
            var LuserId = httpcontext.HttpContext.Session.GetInt32("UserId");

            return All().Where(x => x.LuserIdAllow == LuserId && x.AccountHeadList.AccountCategorys.AccountCategoryName == "Cash").Select(x => new SelectListItem
            {
                Text = x.AccountHeadList.AccName.ToString(),
                Value = x.AccountHeadList.Id.ToString()
            });
        }



        public IEnumerable<SelectListItem> GetAllForDropDownForBank()
        {
            var LuserId = httpcontext.HttpContext.Session.GetInt32("UserId");

            return All().Where(x => x.LuserIdAllow == LuserId && x.AccountHeadList.AccountCategorys.AccountCategoryName == "Bank").Select(x => new SelectListItem
            {
                Text = x.AccountHeadList.AccName.ToString(),
                Value = x.AccountHeadList.Id.ToString()
            });
        }

        //public IEnumerable<SelectListItem> GetUserWiseWarehouse(int LuserId)
        //{
        //    return All(true).Where(x=>x.LuserId == LuserId)
        //}


    }


    public class ToWarehousePermissionRepository : BaseRepository<ToWarehousePermissionModel>, IToWarehousePermissionRepository
    {
        public ToWarehousePermissionRepository(InvoiceDbContext context) : base(context)
        {
        }
        public IEnumerable<SelectListItem> GetAllForDropDown()
        {
            return All().Select(x => new SelectListItem
            {
                Text = x.WarehouseList.WhShortName.ToString(),
                Value = x.WarehouseList.Id.ToString()
            });
        }


    }




    public class MenuPermission_MasterRepository : SelfRepository<MenuPermission_MasterModel>, IMenuPermission_MasterRepository
    {
        public MenuPermission_MasterRepository(InvoiceDbContext context) : base(context)
        {
        }

        public IEnumerable<SelectListItem> GetAllForDropDown()
        {
            return All().Select(x => new SelectListItem
            {
                Text = x.Id.ToString(),
                Value = x.Id.ToString()
            });
        }


    }
    public class MenuPermission_DetailsRepository : SelfRepository<MenuPermission_DetailsModel>, IMenuPermission_DetailsRepository
    {
        public MenuPermission_DetailsRepository(InvoiceDbContext context) : base(context)
        {
        }


    }





    public class AndroidMenuPermission_MasterRepository : SelfRepository<AndroidMenuPermission_MasterModel>, IAndroidMenuPermission_MasterRepository
    {
        public AndroidMenuPermission_MasterRepository(InvoiceDbContext context) : base(context)
        {
        }

        public IEnumerable<SelectListItem> GetAllForDropDown()
        {
            return All().Select(x => new SelectListItem
            {
                Text = x.Id.ToString(),
                Value = x.Id.ToString()
            });
        }


    }
    public class AndroidMenuPermission_DetailsRepository : SelfRepository<AndroidMenuPermission_DetailsModel>, IAndroidMenuPermission_DetailsRepository
    {
        public AndroidMenuPermission_DetailsRepository(InvoiceDbContext context) : base(context)
        {
        }


    }

}
