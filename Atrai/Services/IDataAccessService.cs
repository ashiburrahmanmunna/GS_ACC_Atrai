using Invoice.Core.Entity;
using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Invoice.Service
{
	public interface IDataAccessService
	{
		Task<bool> GetMenuItemsAsync(ClaimsPrincipal ctx, string ctrl, string act);
		Task<List<NavigationMenuViewModel>> GetMenuItemsAsync(ClaimsPrincipal principal);
		Task<List<NavigationMenuViewModel>> GetPermissionsByRoleIdAsync(int id);
		Task<bool> SetPermissionsByRoleIdAsync(int id, IEnumerable<int> permissionIds);
	}
}