#region Using Directive
using Atrai.Core.Common;
using Atrai.Model.Core.Entity;
using Microsoft.AspNetCore.Authorization;
//using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.Extensions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Controllers;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Routing;
using System;
using System.Collections.Generic;
using System.Linq;
#endregion

namespace Atrai.Services
{
    public class OverridableAuthorize : Attribute, IAuthorizationFilter
    {
        //private readonly IServiceProvider _serviceProvider;
        public OverridableAuthorize()
        {
        }



        //public OverridableAuthorize(InvoiceDbContext _db)
        //{
        //    db = _db;
        //}

        //private InvoiceDbContext db { get; set; }
        //private List<MenuPermissionModel> filterpermission { get; set; }

        public void OnAuthorization(AuthorizationFilterContext filterContext)
        {
            //if ((filterContext.ActionDescriptor.EndpointMetadata.Any() is null)) return;

            bool hasAllowAnonymous = filterContext.ActionDescriptor.EndpointMetadata
                                            .Any(em => em.GetType() == typeof(AllowAnonymousAttribute)); //< -- Here it is

            if (hasAllowAnonymous) return;


            var UserRoleId = filterContext.HttpContext.Session.GetInt32("UserRoleId");
            if (UserRoleId <= 1)
            {
                return;
            }
            else //if (UserRoleId == 2)
            {
                var PurchasePackage = filterContext.HttpContext.Session.GetInt32("PurchasePackage");

                if (PurchasePackage == 1)
                {
                    filterContext.HttpContext.Session.SetString("Status", "4");
                    filterContext.HttpContext.Session.SetString("Message", "User Expired");

                    if (filterContext.HttpContext.Request != null)
                    {
                        string referer = filterContext.HttpContext.Request.Headers["Referer"].ToString();

                        filterContext.Result = new RedirectToRouteResult(
                        new RouteValueDictionary{{ "controller", "License" },
                                      { "action", "PurchasePackage" } });


                        //filterContext.Result = new RedirectToRouteResult(
                        //new RouteValueDictionary{{ "controller", "Home" },
                        //              { "action", "AccessDenied" }, {"null","null" } });
                    }

                }
                //return;
            }


            int MenuCount = 0;
            //int clickedMenuId = int.Parse(filterContext.HttpContext.Session.GetInt32("ActiveModuleMenuId").ToString());

            filterContext.HttpContext.Session.SetString("Status", "");
            filterContext.HttpContext.Session.SetString("Message", "");


            var UserId = filterContext.HttpContext.Session.GetInt32("UserId");
            //var UserRoleId = filterContext.HttpContext.Session.GetInt32("UserRoleId");
            var BusinessTypeId = filterContext.HttpContext.Session.GetInt32("BusinessTypeId");



            var controllerActionDescriptor = filterContext.ActionDescriptor as ControllerActionDescriptor;





            string controller = controllerActionDescriptor?.ControllerName;
            var action = controllerActionDescriptor?.ActionName;



            if (UserId == null)
            {
                filterContext.HttpContext.Session.SetString("Status", "4");
                filterContext.HttpContext.Session.SetString("Message", "Access Denied");

                filterContext.HttpContext.Session.SetString("gotourl", filterContext.HttpContext.Request.GetDisplayUrl());

                filterContext.Result = new RedirectResult("~/Home/Login");



            }
            else
            {


                var AllMenus = filterContext.HttpContext.Session.GetObject<List<UserMenuPermissionViewModel>>("UserAllMenu");
                //var AllMenus = filterContext.HttpContext.Session.GetObject<List<MenuPermissionModel>>("UserAllMenu");

                var MenuList = filterContext.HttpContext.Session.GetObject<List<MenuModel>>("MenuList").Where(x => x.ActionName != null);
                int CountMenuExist = MenuList.Where(x => x.ControllerName.ToLower() == controller.ToLower() && x.ActionName.ToLower() == action.ToLower()).ToList().Count();
                //int CountMenuExist = MenuList.Where(x => x.ControllerName.ToLower() == controller.ToLower() && (x.ActionName?.ToLower() == action.ToLower())).ToList().Count();
                //int CountMenuExist = MenuList.Where(x => x.ControllerName.ToLower() == controller.ToLower() && (x.ActionName.Contains(action))).ToList().Count();



                if (action.ToLower().Contains("delete"))
                {
                    //  List<UserMenuPermissionViewModel> filterpermission = AllMenus.Where(x => x.ControllerName == controller && x.AllActionName.ToLower().Contains(action.ToLower()) && x.IsDeleteP == true).ToList();
                    List<UserMenuPermissionViewModel> filterpermission = AllMenus.Where(x => x.ControllerName == controller && x.AllActionName.ToLower().Contains(action.ToLower()) && x.IsDeleteP == true).ToList();
                    MenuCount = filterpermission.Count();

                }
                else if (action.ToLower().Contains("new ") || action.ToLower().Contains("create") || action.ToLower().Contains("add") || action.ToLower().Contains("entry"))
                {
                    List<UserMenuPermissionViewModel> filterpermission = AllMenus.Where(x => x.ControllerName == controller && x.AllActionName.ToLower().Contains(action.ToLower()) && x.IsCreate == true).ToList();
                    MenuCount = filterpermission.Count();

                }
                else if (action.ToLower().Contains("edit") || action.ToLower().Contains("update"))
                {
                    //List<UserMenuPermissionViewModel> filterpermission = AllMenus.Where(x => x.ControllerName == controller && x.ActionName.ToLower() == action.ToLower() && x.IsEdit == true).ToList();
                    List<UserMenuPermissionViewModel> filterpermission = AllMenus.Where(x => x.ControllerName == controller && x.AllActionName.ToLower().Contains(action.ToLower()) && x.IsEdit == true).ToList();
                    MenuCount = filterpermission.Count();

                }
                else if (action.ToLower().Contains("print") || action.ToLower().Contains("report"))
                {
                    List<UserMenuPermissionViewModel> filterpermission = AllMenus.Where(x => x.ControllerName == controller && x.AllActionName.ToLower().Contains(action.ToLower())).ToList();
                    MenuCount = filterpermission.Count();

                }
                else if (action.ToLower().Contains("list"))
                {
                    List<UserMenuPermissionViewModel> filterpermission = AllMenus.Where(x => x.ControllerName == controller && x.AllActionName.ToLower().Contains(action.ToLower())).ToList();
                    MenuCount = filterpermission.Count();

                }
                else
                {
                    List<UserMenuPermissionViewModel> filterpermission = AllMenus.Where(x => x.ControllerName == controller && x.AllActionName.ToLower().Contains(action.ToLower())).ToList();
                    MenuCount = filterpermission.Count();

                }



                //if (action.ToLower().Contains("delete"))
                //{
                //    List<MenuPermissionModel> filterpermission = AllMenus.Where(x => x.Menu.ControllerName == controller && x.Menu.ActionName.ToLower() == action.ToLower() && x.UserRoleId == UserRoleId && x.BusinessTypeId == BusinessTypeId && x.IsDeletePermission == true).ToList();
                //    MenuCount = filterpermission.Count();

                //}
                //else if (action.ToLower().Contains("new ") || action.ToLower().Contains("create") || action.ToLower().Contains("entry"))
                //{
                //    List<MenuPermissionModel> filterpermission = AllMenus.Where(x => x.Menu.ControllerName == controller && x.Menu.ActionName.ToLower() == action.ToLower() && x.UserRoleId == UserRoleId && x.BusinessTypeId == BusinessTypeId && x.IsCreatePermission == true).ToList();
                //    MenuCount = filterpermission.Count();

                //}
                //else if (action.ToLower().Contains("edit") || action.ToLower().Contains("update"))
                //{
                //    List<MenuPermissionModel> filterpermission = AllMenus.Where(x => x.Menu.ControllerName == controller && x.Menu.ActionName.ToLower() == action.ToLower() && x.UserRoleId == UserRoleId && x.BusinessTypeId == BusinessTypeId && x.IsUpdatePermission == true).ToList();
                //    MenuCount = filterpermission.Count();

                //}
                //else
                //{
                //    List<MenuPermissionModel> filterpermission = AllMenus.Where(x => x.Menu.ControllerName == controller && x.Menu.ActionName.ToLower() == action.ToLower() && x.UserRoleId == UserRoleId && x.BusinessTypeId == BusinessTypeId).ToList();
                //    MenuCount = filterpermission.Count();

                //}



                //int CountMenuExist = MenuExist.Count();



                //int isactivemodule = AllMenus.Where(m => m.ModuleMenuController.ToLower() == controller.ToLower()).FirstOrDefault().ModuleId;
                //var modules= filterContext.HttpContext.Session.GetObject<List<Module>>("modules");

                //if (isactivemodule != 0 )
                //{
                //    filterContext.HttpContext.Session.SetInt32("isactivemodule", isactivemodule);

                //    if (modules != null)
                //    {
                //        var abc = modules.Where(x => x.ModuleId == isactivemodule).FirstOrDefault();
                //        filterContext.HttpContext.Session.SetInt32("activemenuid", isactivemodule);
                //        filterContext.HttpContext.Session.SetString("activemodulename", abc.ModuleName);
                //    }

                //}



                //if (AllMenus != null)
                //{

                //    AllMenus.ToList().ForEach
                //                            (c => {
                //                                c.Active = false; c.Visible = false;
                //                            });

                //    AllMenus.Where(x => x.ModuleId == isactivemodule).ToList().ForEach(c => c.Visible = true);


                //    int parentId = 0;
                //    if (clickedMenuId > 0)
                //    {
                //        parentId = AllMenus.Where(m => m.ModuleMenuId == clickedMenuId).FirstOrDefault().ParentId;

                //    }
                //    else
                //    {
                //        parentId = AllMenus.Where(m => m.ModuleMenuController.ToLower() == controller.ToLower()).FirstOrDefault().ParentId;

                //    }

                //    if (action.ToLower() == "BBLCReport".ToLower())
                //    {
                //        AllMenus.Where(m => m.ModuleMenuController.ToLower() == "BBLCReport".ToLower()).FirstOrDefault().Active = true;


                //    }
                //    else if (action.ToLower() == "ExportShippingReport".ToLower())
                //    {
                //        AllMenus.Where(m => m.ModuleMenuController.ToLower() == "ExportShippingReport".ToLower()).FirstOrDefault().Active = true;
                //    }
                //    else
                //    {
                //        if (clickedMenuId > 0)
                //        {
                //            AllMenus.Where(m => m.ModuleMenuId == clickedMenuId).FirstOrDefault().Active = true;

                //        }
                //        else
                //        {
                //            AllMenus.Where(m => m.ModuleMenuController.ToLower() == controller.ToLower()).FirstOrDefault().Active = true;

                //        }

                //    }

                //    AllMenus.Where(m => m.ModuleMenuId == parentId).FirstOrDefault().Active = true;

                //}


                //if (action == "Index")
                //{
                //    if (clickedMenuId > 0)
                //    {
                //        filterpermission = AllMenus.Where(m => m.ModuleMenuId == clickedMenuId).FirstOrDefault();
                //    }
                //    else
                //    {
                //        filterpermission = AllMenus.Where(m => m.ModuleMenuController.ToLower() == controller.ToLower() && m.IsView == true).OrderByDescending(x=>x.ModuleId).FirstOrDefault();

                //    }


                //    filterContext.HttpContext.Session.SetString("activemodulename", filterpermission.ModuleMenuCaption);

                //}
                //else if (action == "Create")
                //{
                //    filterpermission = AllMenus.Where(m => m.ModuleMenuController.ToLower() == controller.ToLower() && m.IsCreate == true).FirstOrDefault();

                //    if (filterpermission != null)
                //    {
                //        filterContext.HttpContext.Session.SetString("activemodulename", filterpermission.ModuleMenuCaption);

                //    }

                //}
                //else if (action == "Edit")
                //{
                //    filterpermission = AllMenus.Where(m => m.ModuleMenuController.ToLower() == controller.ToLower() && m.IsEdit == true).FirstOrDefault();
                //    if (filterpermission != null)
                //    {
                //        filterContext.HttpContext.Session.SetString("activemodulename", filterpermission.ModuleMenuCaption);

                //    }

                //}
                //else if (action == "Delete")
                //{
                //    filterpermission = AllMenus.Where(m => m.ModuleMenuController.ToLower() == controller.ToLower() && m.IsDelete == true).FirstOrDefault();
                //    if (filterpermission != null)
                //    {
                //        filterContext.HttpContext.Session.SetString("activemodulename", filterpermission.ModuleMenuCaption);

                //    }

                //}
                //else if (action == "Report")
                //{
                //    filterpermission = AllMenus.Where(m => m.ModuleMenuController.ToLower() == controller.ToLower() && m.IsReport == true).FirstOrDefault();
                //    filterContext.HttpContext.Session.SetString("activemodulename", filterpermission.ModuleMenuCaption);

                //}
                //else if (action.ToUpper() == "Dashboard".ToUpper())
                //{
                //    filterpermission = AllMenus.Where(m => m.ModuleMenuController.ToUpper() == controller.ToUpper() && m.ModuleMenuLink.ToUpper().Contains("DASHBOARD".ToUpper())).FirstOrDefault(); //
                //    filterContext.HttpContext.Session.SetString("activemodulename", filterpermission.ModuleMenuCaption);

                //}
                //else
                //{
                //    filterpermission = AllMenus.Where(m => m.ModuleMenuController.ToLower() == controller.ToLower() && m.IsCreate == true).FirstOrDefault();
                //    filterContext.HttpContext.Session.SetString("activemodulename", filterpermission.ModuleMenuCaption);

                //}



                if (MenuCount == 0 && CountMenuExist >= 0)
                {
                    filterContext.HttpContext.Session.SetString("Status", "4");
                    filterContext.HttpContext.Session.SetString("Message", "Access Denied");

                    if (filterContext.HttpContext.Request != null)
                    {
                        string referer = filterContext.HttpContext.Request.Headers["Referer"].ToString();

                        if ((filterContext.HttpContext.Request.ContentType == "application/json; charset=UTF-8" || filterContext.HttpContext.Request.ContentType == null || filterContext.HttpContext.Request.ContentType == "application/x-www-form-urlencoded; charset=UTF-8") && filterContext.HttpContext.Request.Method == "POST" || filterContext.HttpContext.Request.Method == "GET")
                        {
                            filterContext.Result = new RedirectToRouteResult(
                            new RouteValueDictionary{{ "controller", "Home" },
                                      { "action", "AccessDeniedJson" } });

                        }
                        else
                        {

                            filterContext.Result = new RedirectToRouteResult(
                            new RouteValueDictionary{{ "controller", "Home" },
                                      { "action", "AccessDenied" } });
                        }


                        //return Json(new { success = "1", error = false, message = "Data updated successfully", Id = model.Id });

                        //filterContext.Result = new RedirectToRouteResult(
                        //new RouteValueDictionary{{ "controller", "Home" },
                        //              { "action", "AccessDenied" }, {"null","null" } });
                    }

                }




                //else if ((MenuCount == 0) && (CountMenuExist == 0) && (!action.ToLower().Contains("get")))
                //{
                //    filterContext.HttpContext.Session.SetString("Status", "4");
                //    filterContext.HttpContext.Session.SetString("Message", "Access Denied");

                //    if (filterContext.HttpContext.Request != null)
                //    {
                //        string referer = filterContext.HttpContext.Request.Headers["Referer"].ToString();

                //        filterContext.Result = new RedirectToRouteResult(
                //        new RouteValueDictionary{{ "controller", "Home" },
                //                      { "action", "AccessDenied" } });


                //        //filterContext.Result = new RedirectToRouteResult(
                //        //new RouteValueDictionary{{ "controller", "Home" },
                //        //              { "action", "AccessDenied" }, {"null","null" } });
                //    }

                //}
                //else if (filterpermission.Count() == 0 && CountMenuExist == 0)
                //{
                //    string referer = filterContext.HttpContext.Request.Headers["Referer"].ToString();

                //    filterContext.Result = new RedirectToRouteResult(
                //    new RouteValueDictionary{{ "controller", "Home" },
                //                      { "action", "NotFound" } });
                //}
                else
                {
                    //var singleaction = filterpermission.OrderBy(x => x.Menu.DisplayOrder).FirstOrDefault();


                    //filterContext.Result = new RedirectToRouteResult(
                    //   new RouteValueDictionary{{ "controller", singleaction.Menu.ControllerName },
                    //                  { "action", singleaction.Menu.ActionName }, {"null","null" } });

                    //filterContext.HttpContext.Session.SetObject("UserMenu", AllMenus);
                    //filterContext.Result = null;

                }

            }

        }


    }


    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method)]
    public class ApiAuthorizeAttribute : Attribute, IAuthorizationFilter
    {
        private readonly IHttpContextAccessor _httpcontext;


        public ApiAuthorizeAttribute()//IHttpContextAccessor httpcontext
        {
            //_httpcontext = httpcontext;
        }

        public void OnAuthorization(AuthorizationFilterContext context)
        {
            var user = (UserAccountModel)context.HttpContext.Items["User"];
            //_httpcontext.HttpContext.Session.SetInt32("ComId", user.ComId);
            //_httpcontext.HttpContext.Session.SetInt32("UserId", user.LuserId);
            //var token=context.HttpContext.Request.Headers["Authorization"];

            //if (user)
            if (user == null)
            {
                // not logged in
                context.Result = new JsonResult(new { message = "Unauthorized" }) { StatusCode = StatusCodes.Status401Unauthorized };
            }
            else
            {
                context.HttpContext.Session.SetInt32("ComId", user.CurrentComId);
                context.HttpContext.Session.SetInt32("UserId", user.Id);
                //context.HttpContext.Session.SetInt32("UserRoleId", user.UserRoleId ?? 0);
                context.HttpContext.Session.SetString("UserRole", user.UserRole.RoleName ?? "");

            }
        }
    }
}
