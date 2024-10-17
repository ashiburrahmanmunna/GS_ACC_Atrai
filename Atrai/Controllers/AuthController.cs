using Atrai.Core.Common;
using Atrai.Data.Context.AppDataContext;
using Atrai.Data.Interfaces;
using Atrai.Model.Core.Entity;
using Atrai.Model.Core.ViewModel;
using Atrai.Services;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Atrai.Controllers
{
    public class AuthController : Controller
    {
        private readonly IOptions<SMTPConfigModel> _smtpConfig;

        private readonly IUserAccountRepository userAccountRepository;
        private readonly ICompanyRepository companyRepository;
        private readonly IStoreSettingRepository storeSettingRepository;
        private readonly IMenuPermissionRepository _menuPermissionRepository;
        private readonly ICompanyPermissionRepository _companyPermissionRepository;

        private readonly IMenuPermission_MasterRepository _menuPermissionMasterRepository;
        private readonly IMenuPermission_DetailsRepository _menuPermissionDetailsRepository;
        private readonly IEmailSettingRepository _emailSettingRepository;
        private IEmailSender _emailsender { get; }
        private ISmsSender _smsSender { get; }
        private readonly InvoiceDbContext db;


        private readonly IMenuRepository _menuRepository;
        private readonly ICountryRepository _countryRepository;
        private readonly ICategoryRepository _categoryRepository;
        private readonly IBrandRepository _brandRepository;

        private readonly IProductRepository _productRepository;
        private readonly IBusinessTypeRepository _businessTypeRepository;
        private readonly IFiscalYearTypeRepository _fiscalYearTypeRepository;

        private readonly ISubscriptionTypeRepository _subscriptionTypeRepository;
        private readonly ISubscriptionActivationRepository _subscriptionActivationRepository;
        private readonly ISubscriptionActivationCompanyRepository _subscriptionActivationCompanyRepository;

        private readonly IUnitRepository _unitRepository;
        private readonly ITimeZoneSettingsRepository _timeZoneSettingsRepository;


        private readonly ICustomerRepository _customerRepository;
        private readonly ISupplierRepository _supplierRepository;
        private readonly IWarehouseRepository _warehouseRepository;
        private readonly IAccountHeadRepository _accountHeadRepository;
        private readonly ISoftwarePackageRepository _softwarePackageRepository;
        private readonly IPackageActivationRepository _packageActivationRepository;
        private readonly IReportStyleRepository _reportStyleRepository;

        private readonly IOrdersRepository _ordersRepository;
        private readonly IOrdersItemsRepository _ordersItemsRepository;
        private readonly IConfiguration config;
        private readonly IAccFiscalYearRepository _accFiscalYearRepository;


        private readonly ISalesItemsRepository _salesItemsRepository;
        private readonly INotificationSender notificationSender;


        public AuthController(IUserAccountRepository userAccountRepository,
            ICompanyRepository companyRepository,
            IStoreSettingRepository storeSettingRepository
,
            IMenuPermissionRepository menuPermissionRepository,
            IMenuPermission_DetailsRepository menuPermissionDetailsRepository,
            IMenuRepository menuRepository,
            ICountryRepository countryRepository,
            IReportStyleRepository reportStyleRepository,
            ICompanyPermissionRepository companyPermissionRepository,
            ISubscriptionTypeRepository subscriptionTypeRepository,
            IBusinessTypeRepository businessTypeRepository,
            ISalesItemsRepository salesItemsRepository,
            IAccFiscalYearRepository accFiscalYearRepository,
            ITimeZoneSettingsRepository timeZoneSettingsRepository,
            ICustomerRepository customerRepository,
            ISupplierRepository supplierRepository,
            IWarehouseRepository warehouseRepository,
            IAccountHeadRepository accountHeadRepository,
            ISoftwarePackageRepository softwarePackageRepository,
            IPackageActivationRepository packageActivationRepository,
            IOrdersRepository ordersRepository,
            IOrdersItemsRepository ordersItemsRepository, IConfiguration config, InvoiceDbContext db, INotificationSender notificationSender)
        {
            this.userAccountRepository = userAccountRepository;
            this.companyRepository = companyRepository;
            this.storeSettingRepository = storeSettingRepository;
            _menuPermissionRepository = menuPermissionRepository;
            _menuPermissionDetailsRepository = menuPermissionDetailsRepository;
            _menuRepository = menuRepository;
            _countryRepository = countryRepository;
            _reportStyleRepository = reportStyleRepository;
            _companyPermissionRepository = companyPermissionRepository;
            _subscriptionTypeRepository = subscriptionTypeRepository;
            _businessTypeRepository = businessTypeRepository;
            _salesItemsRepository = salesItemsRepository;
            _accFiscalYearRepository = accFiscalYearRepository;
            _timeZoneSettingsRepository = timeZoneSettingsRepository;
            _customerRepository = customerRepository;
            _supplierRepository = supplierRepository;
            _warehouseRepository = warehouseRepository;
            _accountHeadRepository = accountHeadRepository;
            _softwarePackageRepository = softwarePackageRepository;
            _packageActivationRepository = packageActivationRepository;
            _ordersRepository = ordersRepository;
            _ordersItemsRepository = ordersItemsRepository;
            this.config = config;
            this.db = db;
            this.notificationSender = notificationSender;
        }
        [HttpPost]
        public async Task<IActionResult> CheckUserName(ChitraLogin model)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return View(model);
                }
                HttpClient client = new HttpClient();
                client.DefaultRequestHeaders.Add("Chitra-API-Key", "ChitraManechitramanebagbonerchitranakintoatagtrarchitra");
                var email = await client.GetAsync($"http://gtrbd.net/chitraupdateapi/api/Auth/EmailIsExits?email={model.Username}");
                var emailIsExist = Convert.ToBoolean(await email.Content.ReadAsStringAsync());
                if (emailIsExist)
                {
                    return RedirectToAction(nameof(PasswordChallange), new { email = model.Username });

                }
                var userName = await client.GetAsync($"http://gtrbd.net/chitraupdateapi/api/Auth/UserNameIsExits?username={model.Username}");
                //var result = await client.PostAsJsonAsync("http://gtrbd.net/chitraupdateapi/api/Auth/Login", model);
                var userIsExist = Convert.ToBoolean(await userName.Content.ReadAsStringAsync());
                if (userIsExist)
                {
                    return RedirectToAction(nameof(PasswordChallange), new { email = model.Username });

                }

                ModelState.AddModelError("Email", "User Name Not Found");
                return View(nameof(Login), model);

            }
            catch (Exception ex)
            {

                ModelState.AddModelError(string.Empty, "Something was wrong");
                return View(nameof(Login), model);

            }

        }

        public IActionResult PasswordChallange(string email)
        {

            return View(new ChitraPassword { Username = email });
        }
        public IActionResult Login()
        {
            return View();
        }
        public async Task<IActionResult> EmailIsExist(string email)
        {
            //HttpClient client = new HttpClient();
            //client.DefaultRequestHeaders.Add("Chitra-API-Key", "ChitraManechitramanebagbonerchitranakintoatagtrarchitra");
            //var responseMessage = await client.GetAsync($"http://gtrbd.net/chitraupdateapi/api/Auth/EmailIsExits?email={email}");
            //var emailIsExist = Convert.ToBoolean(await responseMessage.Content.ReadAsStringAsync());



            //var userinfo = userAccountRepository.All().Where(x=>x.Email == email).FirstOrDefault();
            //var emailIsExist = userinfo != null;
            //return Json(emailIsExist ? false : true);

            var userinfo = userAccountRepository.All().FirstOrDefault(x => x.Email == email);
            var emailIsExist = userinfo != null;
            return Json(!emailIsExist);
        }
        public async Task<IActionResult> UserNameIsExist(string UserName)
        {
            //HttpClient client = new HttpClient();
            //client.DefaultRequestHeaders.Add("Chitra-API-Key", "ChitraManechitramanebagbonerchitranakintoatagtrarchitra");
            //var responseMessage = await client.GetAsync($"http://gtrbd.net/chitraupdateapi/api/Auth/UserNameIsExits?Username={UserName}");
            //var emailIsExist = Convert.ToBoolean(await responseMessage.Content.ReadAsStringAsync());
            //return Json(emailIsExist ? false : true);
            var userinfo = userAccountRepository.All().FirstOrDefault(x => x.Name == UserName);
            var emailIsExist = userinfo != null;
            return Json(!emailIsExist);

        }
        [HttpPost]
        public async Task<IActionResult> Login(ChitraPassword model)
        {
            Atrai.Model.AppData.DefaultConnectionString = config.GetConnectionString("DefaultConnection");
            if (!ModelState.IsValid)
            {
                return View(nameof(PasswordChallange), model);
            }
            if (string.IsNullOrEmpty(model.Username))
            {
                ModelState.AddModelError(string.Empty, "Invalid login attempt");
                return View(nameof(PasswordChallange), model);
            }
            HttpClient client = new HttpClient();
            client.DefaultRequestHeaders.Add("Chitra-API-Key", "ChitraManechitramanebagbonerchitranakintoatagtrarchitra");

            var result = await client.PostAsJsonAsync("http://gtrbd.net/chitraupdateapi/api/Auth/Login", model);
            //var result = await client.PostAsJsonAsync("http://gtrbd.net/chitraupdateapi/api/Auth/Login", model);
            if (Convert.ToInt32(result.StatusCode) == 321)
            {
                return RedirectToAction(nameof(CofrimOTP));
            }
            if (Convert.ToInt32(result.StatusCode) == 411)
            {
                ModelState.AddModelError(string.Empty, "You Can not Login with Out Company");
                return View();
            }
            TokenResult resultToken = new TokenResult();
            if (result.IsSuccessStatusCode)
            {
                resultToken = await result.Content.ReadFromJsonAsync<TokenResult>();
            }
            else
            {
                var error = await result.Content.ReadFromJsonAsync<ChitraErrorViewModel>();
                ModelState.AddModelError(string.Empty, error.error_description);
                return View();
            }
            await DecodeTokenAndCreateCookie(resultToken.access_token, HttpContext);
            Response.Cookies.Append("access_token", resultToken.access_token, new CookieOptions
            {
                HttpOnly = true
            });
            Response.Cookies.Append("refresh_token", resultToken.Refresh_token, new CookieOptions
            {
                HttpOnly = true
            });
            return RedirectToAction(nameof(CompanyInfoSync), new { token = resultToken.access_token });
        }
        public IActionResult CofrimOTP()
        {
            return View();
        }
        public IActionResult AccessDenied()
        {
            return View();
        }
        public async Task<IActionResult> Logout()
        {
            Response.Cookies.Delete("access_token");
            Response.Cookies.Delete("refresh_token");
            HttpContext.Session.Remove("UserId");
            HttpContext.Session.Remove("ComId");
            await HttpContext.SignOutAsync("Chitra");
            return RedirectToAction(nameof(Login));
        }
        private async Task DecodeTokenAndCreateCookie(string encodedToken, HttpContext httpContext)
        {
            JwtSecurityTokenHandler tokenHandler = new JwtSecurityTokenHandler();
            JwtSecurityToken token = tokenHandler.ReadJwtToken(encodedToken);


            var identity = new ClaimsIdentity(token.Claims, "User");

            // Create an authentication ticket with the claims identity
            var principal = new ClaimsPrincipal(identity);
            var authenticationProperties = new AuthenticationProperties
            {

                ExpiresUtc = DateTime.UtcNow.AddSeconds(int.Parse(token.Claims.FirstOrDefault(x => x.Type == "exp")?.Value))
            };

            await httpContext.SignInAsync("Chitra", principal, authenticationProperties);
        }

        public async Task<IActionResult> CompanyInfoSync()
        {
            try
            {
                HttpClient client = new HttpClient();
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", Request.Cookies["access_token"].ToString());
                var reponse = await client.GetAsync("https://gtrbd.net/chitraupdateapi/api/UserCompany/UserCompanyInfo");
                //var reponse = await client.GetAsync("https://localhost:7074/api/UserCompany/UserCompanyInfo");
                if (reponse.IsSuccessStatusCode)
                {
                    var infos = await reponse.Content.ReadFromJsonAsync<UserCompanyDto>();

                    var user = userAccountRepository.All().Where(x => x.UniqueUserId == infos.UserInfo.Id).FirstOrDefault();
                    if (user == null)
                    {
                        user = new UserAccountModel
                        {
                            UniqueUserId = infos.UserInfo.Id,
                            Email = infos.UserInfo.Email,
                            PhoneNumber = infos.UserInfo.PhoneNumber,
                            Name = infos.UserInfo.Fullname ?? "",
                            Password = "",


                        };
                        userAccountRepository.AddRange(new List<UserAccountModel>
                    {user

                    });
                    }
                    var company = companyRepository.All().Where(x => x.UniqueCompanyId == infos.CompanyInfo.Id).FirstOrDefault();
                    if (company == null)
                    {
                        company = new CompanyModel
                        {
                            comEmail = infos.CompanyInfo.TeachnicalContactEmail ?? "",
                            UniqueCompanyId = infos.CompanyInfo.Id,
                            CompanyName = infos.CompanyInfo.Name ?? "",
                            comPhone = infos.CompanyInfo.PhoneNumber ?? "",
                        };
                        companyRepository.AddRange(new List<CompanyModel>
                    {company

                    });

                    }

                    if (company.CompanyName == "Default Company")
                    {
                        return RedirectToAction("CompanySetup", "Home");
                    }
                    HttpContext.Session.SetInt32("UserId", user.Id);
                    HttpContext.Session.SetInt32("ComId", company.Id);
                    return RedirectToAction(nameof(StoreSetup));
                }
                return View();
            }
            catch (Exception ex)
            {

                return View("Home", ex);
            }

        }

        public IActionResult StoreSetup()
        {
            var comunqId = User.Claims.FirstOrDefault(x => x.Type == "CompanyId").Value;
            var userId = User.Claims.FirstOrDefault(x => x.Type == ClaimTypes.NameIdentifier).Value;
            var company = companyRepository.All().Where(x => x.UniqueCompanyId == comunqId)//.Include(x => x.Currency)
                .Include(x => x.BusinessType).FirstOrDefault();
            var user = userAccountRepository.All().Where(x => x.UniqueUserId == userId).FirstOrDefault();
            var storeinfo = storeSettingRepository.All().Where(x => x.ComId == company.Id)
                    .Include(x => x.SalesReportStyle)
                    .Include(x => x.PurchaseReportStyle)
                    .Include(x => x.BarcodeReportStyle)
                    .Include(x => x.Currency)
                    .Include(x => x.Country)
                    .Include(x => x.TimeZones)
                    .FirstOrDefault();
            if (storeinfo == null)
            {

                //  var comid = HttpContext.Session.GetInt32("UserId");
                // var userid = HttpContext.Session.GetInt32("ComId");
                //HttpContext.Session.SetInt32("UserId", userid);
                //HttpContext.Session.SetInt32("ComId", comid);


                StoreSettingModel storesettings = new StoreSettingModel();
                storesettings.StoreName = company.CompanyName ?? "";
                storesettings.Phone = company.comPhone ?? "";
                storesettings.Email = company.comEmail ?? "";
                storesettings.Web = company.comWeb ?? "";
                storesettings.BusinessTypeId = company.BusinessTypeId;
                storesettings.SubscriptionTypeId = company.SubscriptionTypeId;
                storesettings.TimeZoneSettingsId = 36;
                storesettings.SalesReportStyleId = _reportStyleRepository.All().FirstOrDefault().Id;
                storesettings.PurchaseReportStyleId = _reportStyleRepository.All().FirstOrDefault().Id;

                //storesettings.Currency = "BDT ";
                storesettings.CountryId = storeinfo.CountryId;


                storesettings.Address = "=N/A=";
                storesettings.Logo = "/Content/Storeimages/0.png";
                storesettings.ComId = company.Id;
                storesettings.BaseComId = company.Id;



                storesettings.TaxPer = 0;
                storesettings.isTaxExcluded = false;
                storesettings.SalesReportStyleId = 2;
                storesettings.PurchaseReportStyleId = 2;

                storesettings.isChequeDetails = false;
                storesettings.isMultiCurrency = false;
                storesettings.isMultiDebitCredit = false;
                storesettings.isVoucherDistributionEntry = false;



                storesettings.isSMSService = false;
                storesettings.isEmailSerivce = false;

                //storesettings.Email = signinmodel.Email;

                storeSettingRepository.Insert(storesettings);



                var companypermission = new CompanyPermissionModel();
                companypermission.LuserId = user.Id;
                companypermission.ComId = company.Id;

                _companyPermissionRepository.Insert(companypermission);



                //var validitydays = _subscriptionTypeRepository.Find(company.SubscriptionTypeId.GetValueOrDefault()).ValidityDay;

                //SubscriptionActivationModel subscriptionActivation = new SubscriptionActivationModel();
                //subscriptionActivation.IsActive = true;
                //subscriptionActivation.IsDelete = false;
                //subscriptionActivation.LuserId = user.Id;
                //subscriptionActivation.Remarks = "Auto Entry by System";
                //subscriptionActivation.SubscriptionTypeId = company.SubscriptionTypeId;
                //subscriptionActivation.ActiveFromDate = DateTime.Now.Date;
                //subscriptionActivation.ActiveToDate = DateTime.Now.Date.AddDays(validitydays);
                //_subscriptionActivationRepository.Insert(subscriptionActivation);




                //SubscriptionActivationCompanyModel subscriptionActivationCompany = new SubscriptionActivationCompanyModel();
                //subscriptionActivationCompany.IsActive = true;
                //subscriptionActivationCompany.IsDelete = false;
                //subscriptionActivationCompany.Remarks = "Auto Entry by System";
                //subscriptionActivationCompany.SubscriptionTypeId = company.SubscriptionTypeId;
                //subscriptionActivationCompany.ActiveFromDate = DateTime.Now.Date;
                //subscriptionActivationCompany.ActiveToDate = DateTime.Now.Date.AddDays(validitydays);
                //subscriptionActivationCompany.ComId = company.Id;
                //_subscriptionActivationCompanyRepository.Insert(subscriptionActivationCompany);



                ////////Auto Unit Input by System 
                //UnitModel Units = new UnitModel();
                //Units.UnitName = "Pcs";
                //Units.UnitShortName = "Pcs";
                //Units.UnitNameBangla = "";
                //_unitRepository.Insert(Units);


                //var businesstypename = _businessTypeRepository.Find(storesettings.BusinessTypeId).BusinessTypeName;
                //if (businesstypename.ToLower().Contains("walton") || businesstypename.ToLower().Contains("marcel"))
                //{
                //    //////Auto Category Input by System 
                //    CategoryModel categorydata = new CategoryModel();
                //    categorydata.Name = "Electronics";
                //    categorydata.Description = "Electronics";
                //    _categoryRepository.Insert(categorydata);
                //}
                //else
                //{
                //    //////Auto Category Input by System 
                //    CategoryModel categorydata = new CategoryModel();
                //    categorydata.Name = "=N/A=";
                //    categorydata.Description = "=N/A=";
                //    _categoryRepository.Insert(categorydata);
                //}



                //CustomerModel customerdata = new CustomerModel();
                //customerdata.Name = "Walk In Customer";
                //customerdata.Phone = "";
                //customerdata.ComId = company.Id;
                //_customerRepository.Insert(customerdata);


                //SupplierModel supplierdata = new SupplierModel();
                //supplierdata.SupplierName = "Cash Supplier";
                //supplierdata.Phone = "";
                //supplierdata.ComId = company.Id;
                //_supplierRepository.Insert(supplierdata);


                //WarehouseModel warehousedata = new WarehouseModel();
                //warehousedata.WhName = "Main";
                //warehousedata.WhShortName = "Main";
                //warehousedata.WhType = "L";
                //warehousedata.ComId = company.Id;
                //_warehouseRepository.Insert(warehousedata);


                //TempData["Message"] = "User Created Successfully";
                //TempData["Status"] = "1";


            }



            HttpContext.Session.SetString("ShortCutKey", storeinfo.ShortCutKey != null ? storeinfo.ShortCutKey : "q"); // "y"
            HttpContext.Session.SetString("SearchType", storeinfo.isScanner == true ? "Scanner" : "Manual"); // "Scanner"
            HttpContext.Session.SetString("barcodeprefixforweightscale", storeinfo.BarcodePrefixForWeightScale != null ? storeinfo.BarcodePrefixForWeightScale : "99"); // "Scanner"


            HttpContext.Session.SetInt32("BaseComId", storeinfo.BaseComId);

            HttpContext.Session.SetInt32("BusinessTypeId", company.BusinessTypeId);
            HttpContext.Session.SetString("BusinessType", company.BusinessType.BusinessTypeName);
            HttpContext.Session.SetString("AppsName", company.BusinessType.AppsName != null ? company.BusinessType.AppsName : "");


            HttpContext.Session.SetString("CompanyName", company.CompanyName != null ? company.CompanyName : "");
            HttpContext.Session.SetString("PrimaryAddress", company.PrimaryAddress != null ? company.PrimaryAddress : "");
            HttpContext.Session.SetString("SecoundaryAddress", company.SecoundaryAddress != null ? company.SecoundaryAddress : "");
            HttpContext.Session.SetString("comPhone", company.comPhone != null ? company.comPhone : "");
            HttpContext.Session.SetString("comWeb", company.comWeb != null ? company.comWeb : "");
            HttpContext.Session.SetString("comEmail", company.comEmail != null ? company.comEmail : "");
            HttpContext.Session.SetString("CaptionOne", "CaptionOne");
            HttpContext.Session.SetString("CaptionTwo", "CaptionTwo");
            HttpContext.Session.SetString("PrintDate", DateTime.Now.Date.ToString("dd-MMM-yy"));
            HttpContext.Session.SetString("comImagePath", storeinfo != null ? storeinfo.Logo != null ? storeinfo.Logo : "" : "");
            //HttpContext.Session.SetString("weburl", resulta.ToString());

            HttpContext.Session.SetString("OfferDiscountPer", storeinfo != null ? storeinfo.OfferDiscountPer.ToString() : "0.00");
            HttpContext.Session.SetInt32("isDiscountOffer", storeinfo != null ? storeinfo.isDiscountOffer != false ? 1 : 0 : 0);


            HttpContext.Session.SetString("TaxPer", storeinfo != null ? storeinfo.TaxPer.ToString() : "0.00");
            HttpContext.Session.SetString("SalesReportStyle", storeinfo.SalesReportStyle != null ? storeinfo.SalesReportStyle.ReportStyleName : "Style1");
            HttpContext.Session.SetString("PurchaseReportStyle", storeinfo.PurchaseReportStyle != null ? storeinfo.PurchaseReportStyle.ReportStyleName : "Style1");
            HttpContext.Session.SetString("BarcodeReportStyle", storeinfo.BarcodeReportStyle != null ? storeinfo.BarcodeReportStyle.ReportStyleName : "Style1");

            HttpContext.Session.SetInt32("isTaxExcluded", storeinfo != null ? storeinfo.isTaxExcluded != false ? 1 : 0 : 0);

            HttpContext.Session.SetInt32("isMultiSelect", storeinfo != null ? storeinfo.isMultiSelect != false ? 1 : 0 : 0);
            HttpContext.Session.SetInt32("isFixedSalesValue", storeinfo != null ? storeinfo.IsFixedSalesValue != false ? 1 : 0 : 0);
            HttpContext.Session.SetInt32("IsFirstLetterUpperCase", storeinfo != null ? storeinfo.IsFirstLetterUpperCase != false ? 1 : 0 : 0);


            HttpContext.Session.SetInt32("IsSerialSales", storeinfo != null ? storeinfo.IsSerialSales != false ? 1 : 0 : 0);
            HttpContext.Session.SetInt32("IsIndDiscount", storeinfo != null ? storeinfo.IsIndDiscount != false ? 1 : 0 : 0);
            HttpContext.Session.SetInt32("IsSalesDescription", storeinfo != null ? storeinfo.IsSalesDescription != false ? 1 : 0 : 0);
            HttpContext.Session.SetInt32("IsVatLogin", storeinfo != null ? storeinfo.IsVatLogin != false ? 1 : 0 : 0);
            HttpContext.Session.SetInt32("isMultiCurrency", storeinfo != null ? storeinfo.isMultiCurrency != false ? 1 : 0 : 0);
            HttpContext.Session.SetInt32("IsTermsCondition", storeinfo != null ? storeinfo.IsTermsCondition != false ? 1 : 0 : 0);
            HttpContext.Session.SetInt32("IsDefaultDisAmount", storeinfo != null ? storeinfo.IsDefaultDisAmount != false ? 1 : 0 : 0);
            HttpContext.Session.SetInt32("DecimalField", storeinfo != null ? storeinfo.DecimalField : 0);


            HttpContext.Session.SetInt32("IsFixedDiscountMainValue", storeinfo != null ? storeinfo.IsFixedDiscountMainValue != false ? 1 : 0 : 0);
            HttpContext.Session.SetInt32("IsFixedDiscountRowValue", storeinfo != null ? storeinfo.IsFixedDiscountRowValue != false ? 1 : 0 : 0);
            HttpContext.Session.SetString("MaxDiscountMainValue", storeinfo != null ? storeinfo.MaxDiscountMainValue.ToString() : "0.00");
            HttpContext.Session.SetString("MaxDiscountPercentageMainValue", storeinfo != null ? storeinfo.MaxDiscountPercentageMainValue.ToString() : "0.00");
            HttpContext.Session.SetString("MaxDiscountRowValue", storeinfo != null ? storeinfo.MaxDiscountRowValue.ToString() : "0.00");




            HttpContext.Session.SetInt32("PrintProductName", storeinfo != null ? storeinfo.PrintProductName != false ? 1 : 0 : 0);
            HttpContext.Session.SetInt32("PrintProductCode", storeinfo != null ? storeinfo.PrintProductCode != false ? 1 : 0 : 0);
            HttpContext.Session.SetInt32("PrintProductDescription", storeinfo != null ? storeinfo.PrintProductDescription != false ? 1 : 0 : 0);
            HttpContext.Session.SetInt32("PrintBrandName", storeinfo != null ? storeinfo.PrintBrandName != false ? 1 : 0 : 0);
            HttpContext.Session.SetInt32("PrintModelName", storeinfo != null ? storeinfo.PrintModelName != false ? 1 : 0 : 0);
            HttpContext.Session.SetInt32("PrintSizeName", storeinfo != null ? storeinfo.PrintSizeName != false ? 1 : 0 : 0);
            HttpContext.Session.SetInt32("VisibleSalesCommission", storeinfo != null ? storeinfo.VisibleSalesCommission != false ? 1 : 0 : 0);



            HttpContext.Session.SetString("isMultiDebitCredit", storeinfo.isMultiDebitCredit.ToString());
            //HttpContext.Session.SetString("isMultiCurrency", company.isMultiCurrency.ToString());

            HttpContext.Session.SetString("isVoucherDistributionEntry", storeinfo.isVoucherDistributionEntry.ToString());
            HttpContext.Session.SetString("isChequeDetails", storeinfo.isChequeDetails.ToString());

            HttpContext.Session.SetString("isSMSService", storeinfo.isSMSService.ToString());
            HttpContext.Session.SetString("isEmailSerivce", storeinfo.isEmailSerivce.ToString());
            HttpContext.Session.SetString("IsSignature", storeinfo != null ? storeinfo.IsSignature.ToString() : "false");


            HttpContext.Session.SetInt32("defaultcurrencyid", storeinfo.CountryId);
            HttpContext.Session.SetString("defaultcurrencyname", storeinfo.Currency.CurrencyShortName.ToString());
            HttpContext.Session.SetInt32("TimeZoneSettingsId", storeinfo.TimeZones != null ? storeinfo.TimeZoneSettingsId : 36);
            HttpContext.Session.SetString("TimeZoneSettingsName", storeinfo.TimeZones != null ? storeinfo.TimeZones.TimeZoneName : "");
            HttpContext.Session.SetString("TimeZoneSettingsNameJquery", storeinfo.TimeZones != null ? storeinfo.TimeZones.TimeZoneNameJquery : "");

            var userdata = userAccountRepository.All().Include(x => x.UserRole).Include(x => x.EmployeeList).Where(x => x.UniqueUserId == userId).FirstOrDefault();

            if (userdata.IsBaseUser == true)
            {
                var userpermissionmenulist = _menuPermissionRepository.All().Include(x => x.Menus).Where(x => x.BusinessTypeId == company.BusinessTypeId);

                if (storeinfo.IsVatLogin == true)
                {
                    userpermissionmenulist = userpermissionmenulist.Where(x => x.Menus.IsVatMenu == true);
                    HttpContext.Session.SetInt32("VatViewActivate", 1);
                }

                List<UserMenuPermissionViewModel> userallmenulist = new List<UserMenuPermissionViewModel>();

                if (userpermissionmenulist != null)
                {
                    foreach (var item in userpermissionmenulist.OrderBy(x => x.Menus.DisplayOrder))
                    {
                        UserMenuPermissionViewModel usermenudata = new UserMenuPermissionViewModel();

                        usermenudata.Id = item.Menus.Id;

                        usermenudata.ActionName = item.Menus.ActionName;
                        usermenudata.ControllerName = item.Menus.ControllerName;
                        usermenudata.IsCreate = true;// item.IsCreate;
                        usermenudata.IsDeleteP = true;//item.IsDeleteP;
                        usermenudata.IsEdit = true;//item.IsEdit;
                        usermenudata.isDefault = true;//item.isDefault;
                        usermenudata.SLNo = item.Menus.DisplayOrder.GetValueOrDefault();

                        usermenudata.IsGroup = item.Menus.isGroup;
                        usermenudata.IsParent = item.Menus.isParent;
                        usermenudata.ParentId = item.Menus.ParentId;

                        usermenudata.MenuGroupName = item.Menus.MenuGroupName;
                        usermenudata.MenuName = item.Menus.MenuName;
                        usermenudata.MenuClass = item.Menus.MenuClass;


                        usermenudata.AllActionName = item.Menus.AllActionName;
                        usermenudata.IsCreateAction = item.Menus.IsCreateAction;
                        usermenudata.IsEditAction = item.Menus.IsEditAction;
                        usermenudata.IsDeleteAction = item.Menus.IsDeleteAction;
                        usermenudata.IsViewAction = item.Menus.IsViewAction;
                        usermenudata.IsListAction = item.Menus.IsListAction;
                        usermenudata.IsReportAction = item.Menus.IsReportAction;


                        userallmenulist.Add(usermenudata);
                    }
                }

                HttpContext.Session.SetObject("UserAllMenu", userallmenulist);
                HttpContext.Session.SetObject("UserGroupMenu", userallmenulist.Where(x => x.IsGroup == true));
                HttpContext.Session.SetObject("UserParentMenu", userallmenulist.Where(x => x.IsParent == true));
                HttpContext.Session.SetObject("UserChildMenu", userallmenulist.Where(x => x.ParentId != null));


            }
            else
            {

                var userpermissionmenulist = _menuPermissionDetailsRepository.All().Include(x => x.MenuPermissionMasters).Include(x => x.Menus).Where(x => x.MenuPermissionMasters.LUserIdPermission == user.Id && x.MenuPermissionMasters.ComId == company.Id);

                //HttpContext.Session.SetString("SummaryView", userpermissionmenulist.FirstOrDefault().MenuPermissionMasters.SummaryView.ToString()); /// fahad need to check for sales summary view activate


                if (storeinfo.IsVatLogin == true)
                {
                    userpermissionmenulist = userpermissionmenulist.Where(x => x.Menus.IsVatMenu == true);
                    HttpContext.Session.SetInt32("VatViewActivate", 1);
                }

                List<UserMenuPermissionViewModel> userallmenulist = new List<UserMenuPermissionViewModel>();

                if (userpermissionmenulist != null)
                {
                    foreach (var item in userpermissionmenulist.OrderBy(x => x.Menus.DisplayOrder))
                    {
                        UserMenuPermissionViewModel usermenudata = new UserMenuPermissionViewModel();

                        usermenudata.Id = item.Menus.Id;

                        usermenudata.ActionName = item.Menus.ActionName;
                        usermenudata.ControllerName = item.Menus.ControllerName;
                        usermenudata.IsCreate = item.IsCreate;
                        usermenudata.IsDeleteP = item.IsDeleteP;
                        usermenudata.IsEdit = item.IsEdit;
                        usermenudata.isDefault = item.isDefault;
                        usermenudata.SLNo = item.SLNo;

                        usermenudata.IsGroup = item.Menus.isGroup;
                        usermenudata.IsParent = item.Menus.isParent;
                        usermenudata.ParentId = item.Menus.ParentId;

                        usermenudata.MenuGroupName = item.Menus.MenuGroupName;
                        usermenudata.MenuName = item.Menus.MenuName;
                        usermenudata.MenuClass = item.Menus.MenuClass;



                        usermenudata.AllActionName = item.Menus.AllActionName;
                        usermenudata.IsCreateAction = item.Menus.IsCreateAction;
                        usermenudata.IsEditAction = item.Menus.IsEditAction;
                        usermenudata.IsDeleteAction = item.Menus.IsDeleteAction;
                        usermenudata.IsViewAction = item.Menus.IsViewAction;
                        usermenudata.IsListAction = item.Menus.IsListAction;
                        usermenudata.IsReportAction = item.Menus.IsReportAction;


                        userallmenulist.Add(usermenudata);
                    }
                }

                HttpContext.Session.SetObject("UserAllMenu", userallmenulist);
                HttpContext.Session.SetObject("UserGroupMenu", userallmenulist.Where(x => x.IsGroup == true));
                HttpContext.Session.SetObject("UserParentMenu", userallmenulist.Where(x => x.IsParent == true));
                HttpContext.Session.SetObject("UserChildMenu", userallmenulist.Where(x => x.ParentId != null));

            }


            HttpContext.Session.SetObject("MenuList", _menuRepository.All().OrderBy(x => x.ParentMenu.DisplayOrder));





            var countryinfo = _countryRepository.All().Where(x => x.Id == storeinfo.CountryId).FirstOrDefault();
            var countryinfoViewFormat = _countryRepository.All().Where(x => x.Id == 231).FirstOrDefault();


            HttpContext.Session.SetString("CurrencyShortNameViewFormat", countryinfoViewFormat.CurrencyShortName);
            HttpContext.Session.SetString("CultureInfoViewFormat", countryinfoViewFormat.CultureInfo);
            HttpContext.Session.SetString("CountryShortNameViewFormat", countryinfoViewFormat.CountryShortName);
            HttpContext.Session.SetString("CurrencySymbolViewFormat", countryinfoViewFormat.CurrencySymbol);


            HttpContext.Session.SetString("CurrencyShortName", countryinfo.CurrencyShortName);
            HttpContext.Session.SetString("CultureInfo", countryinfo.CultureInfo);
            HttpContext.Session.SetString("CountryShortName", countryinfo.CountryShortName);
            HttpContext.Session.SetString("CurrencySymbol", countryinfo.CurrencySymbol);

            if (userdata.IsBaseUser == true)
            {
                var firstmenu = _menuPermissionRepository.All().Include(x => x.Menus).Where(x => x.Menus.ParentId != null && x.BusinessTypeId == storeinfo.BusinessTypeId).OrderBy(x => x.Menus.DisplayOrder).FirstOrDefault();

                return RedirectToAction(firstmenu.Menus.ActionName, firstmenu.Menus.ControllerName);

            }
            else
            {
                var firstmenu = _menuPermissionDetailsRepository.All().Include(x => x.MenuPermissionMasters).Include(x => x.Menus).Where(x => x.Menus.ParentId != null && x.MenuPermissionMasters.LUserIdPermission == user.Id).OrderBy(x => x.Menus.DisplayOrder).FirstOrDefault();

                if (firstmenu == null)
                {
                    return AccessDenied();
                }
                return RedirectToAction(firstmenu.Menus.ActionName, firstmenu.Menus.ControllerName);

            }


        }
        //[HttpPost]
        //public async Task<IActionResult> SetDeviceInfo([FromBody] NotificationDto model)
        //{
        //    try
        //    {
        //        var usernoft = await db.NotificationSettings.Where(x => x.UserName == model.Email).ToListAsync();

        //        if (usernoft.Count() == 0)
        //        {
        //            await db.NotificationSettings.AddAsync(new NotificationSetting { DeviceToken = model.NewDeviceToken, UserName = model.Email });
        //            await db.SaveChangesAsync();
        //        }
        //        else
        //        {
        //            foreach (var item in usernoft)
        //            {
        //                if (item.UserName == model.Email && item.DeviceToken != model.OldDeviceToken)
        //                {
        //                    item.DeviceToken = model.NewDeviceToken;
        //                    await db.SaveChangesAsync();
        //                }
        //            }
        //        }

        //        return NoContent();
        //    }
        //    catch (Exception ex)
        //    {

        //        return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
        //    }

        //}
        [HttpPost]
        public async Task<IActionResult> TestNotification(string massage, string token, int count)
        {

            try
            {
                if (string.IsNullOrEmpty(massage))
                {
                    return BadRequest("Massage Not available");
                }
                if (string.IsNullOrEmpty(token))
                {
                    token = "fhX0dT3FRgujU-DnKMtDkV:APA91bEWGNMoGZkUF-YpWB9xX4ssPimHzYyFsruoUf6uGTJw7CQuhKs2lAEJ2fUKZ_j5xTEcV8v4GtK4mIAatr9kb95q8Zgc7M5K2zZYnuEvRqDPXa_jIAR7bpBMhPeHOH_xm1SLg2F7";
                }
                for (var i = 0; i < count; i++)
                {

                    await Task.Delay(10000);
                    await notificationSender.SendNotification(token, massage, "atrai");
                }



                return Ok();
            }
            catch (Exception ex)
            {

                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }



    }
}
