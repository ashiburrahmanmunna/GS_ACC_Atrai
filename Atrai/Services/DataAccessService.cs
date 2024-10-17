using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Invoice.Core.Entity;
using Invoice.Service;
using Invoice.Data.AppDataContext;

namespace Invoice.Services
{
	public class DataAccessService : IDataAccessService
	{
		private readonly InvoiceDbContext _context;

		public DataAccessService(InvoiceDbContext context)
		{
			_context = context;
		}

		public async Task<List<MenuModel>> GetMenuItemsAsync(ClaimsPrincipal principal)
		{
			var isAuthenticated = principal.Identity.IsAuthenticated;
			if (!isAuthenticated)
				return new List<MenuModel>();

			var roleIds = await GetUserRoleIds(principal);
			var data = await (from menu in _context.MenuPermissions
							  where roleIds.Equals(menu.UserRoleId)
							  select menu)
							  .Select(m => new MenuModel()
							  {
								  Id = m.Menu.Id,
								  MenuName = m.Menu.MenuName,
								  MenuClass = m.Menu.MenuClass,
								  ActionName = m.Menu.ActionName,
								  ControllerName = m.Menu.ControllerName,
								  isParent = m.Menu.isParent,
								  isDashboard = m.Menu.isDashboard,
								  ParentId = m.Menu.ParentId,
								  MenuGroupName = m.Menu.MenuGroupName,
								  MenuRemarks = m.Menu.MenuRemarks
							  }).Distinct().ToListAsync();

			return data;
		}

		public async Task<bool> GetMenuItemsAsync(ClaimsPrincipal ctx, string ctrl, string act)
		{
			var result = false;
			var roleIds = await GetUserRoleIds(ctx);
			var data = await (from menu in _context.MenuPermissions
							  where roleIds.Equals(menu.UserRoleId)
							  select menu)
							  .Select(m => m.Menu).Distinct().ToListAsync();

			foreach (var item in data)
			{
				result = (item.ControllerName == ctrl && item.ActionName == act);
				if (result)
					break;
			}

			return result;
		}

		public async Task<List<NavigationMenuViewModel>> GetPermissionsByRoleIdAsync(int id)
		{
			var items = await (from m in _context.Menus
							   join rm in _context.MenuPermissions
							   on new { X1 = m.Id, X2 = id } equals new { X1 = rm.MenuId, X2 = rm.UserRoleId }
								into rmp
							   from rm in rmp.DefaultIfEmpty()
							   select new NavigationMenuViewModel()
							   {
								   Id = m.Menu.Id,
								   MenuName = m.Menu.MenuName,
								   MenuClass = m.Menu.MenuClass,
								   ActionName = m.Menu.ActionName,
								   ControllerName = m.Menu.ControllerName,
								   isParent = m.Menu.isParent,
								   isDashboard = m.Menu.isDashboard,
								   ParentId = m.Menu.ParentId,
								   MenuGroupName = m.Menu.MenuGroupName,
								   MenuRemarks = m.Menu.MenuRemarks,
								   UserRoleId = rm.UserRoleId == id
							   })
							   .AsNoTracking()
							   .ToListAsync();

			return items;
		}

		public async Task<bool> SetPermissionsByRoleIdAsync(int id, IEnumerable<int> permissionIds)
		{
			var existing = await _context.MenuPermissions.Where(x => x.UserRoleId == id).ToListAsync();
			_context.RemoveRange(existing);

			foreach (var item in permissionIds)
			{
				await _context.MenuPermissions.AddAsync(new MenuPermissionModel()
				{
					UserRoleId = id,
					MenuId = item,
				});
			}

			var result = await _context.SaveChangesAsync();

			return result > 0;
		}

		private async Task<List<int>> GetUserRoleIds(ClaimsPrincipal ctx)
		{
			var userId = GetUserId(ctx);
			var data = await (from role in _context.UserRoles
							  where role.Id == int.Parse(userId.ToString())
							  select role.Id).ToListAsync();

			return data;
		}

		private string GetUserId(ClaimsPrincipal user)
		{
			return ((ClaimsIdentity)user.Identity).FindFirst(ClaimTypes.NameIdentifier)?.Value;
		}
	}
}