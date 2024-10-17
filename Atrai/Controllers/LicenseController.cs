using Atrai.Data.Interfaces;
using Atrai.Model.Core.Entity;
using Atrai.Model.Core.ViewModel;
using Atrai.Services;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;


namespace Atrai.Controllers
{
    [AllowAnonymous]
    public class LicenseController : Controller
    {
        public static string token_id;
        public static string refresh_token;
        public static string paymentID;
        public static string agreementID;
        public static string ResponseText = "";

        //perfect
        public static string username = "GENUINETECRELTD";//"testdemo";//;"sandboxTestUser";
        public static string password = "gN1@etA6rM4kH";//"test%#de23@msdao";//"hWD@8vtzw0";
        public static string app_secret = "pknp7emvns1sh3cad3387tov2bg3pgom4214udd89or7m9se3ui";//"1honf6u1c56mqcivtc9ffl960slp4v2756jle5925nbooa46ch62";//"1vggbqd4hqk9g96o9rrrp2jftvek578v7d2bnerim12a87dbrrka";
        public static string app_key = "43ge0m747a0o0ae7n5jo3uhnb1";//"5nej5keguopj928ekcj3dne8p";//"5tunt4masn6pv2hnvte1sb5n3j";
        //01770618575

        //public static string username = "sandboxTestUser";
        //public static string password = "hWD@8vtzw0";
        //public static string app_secret = "1vggbqd4hqk9g96o9rrrp2jftvek578v7d2bnerim12a87dbrrka";
        //public static string app_key = "5tunt4masn6pv2hnvte1sb5n3j";


        //public static string username = "testdemo";
        //public static string password = "test%#de23@msdao";
        //public static string app_secret = "1honf6u1c56mqcivtc9ffl960slp4v2756jle5925nbooa46ch62";
        //public static string app_key = "5nej5keguopj928ekcj3dne8p";


        public static string currency = "BDT";
        public static decimal amount = 0;
        public static string intent = "sale";
        public static string merchantInvoiceNumber = "126iXJi3omiO";
        public static string trxID = "";

        public static string errorCode = "";
        public static string errorMessage = "";
        public static string status = "";
        public static string msg = "";

        public static DateTime createTime = DateTime.Now.Date;
        public static DateTime updateTime = DateTime.Now.Date;
        public static string userid = "";
        public static string userphone = "";

        private readonly ISubscriptionTypeRepository _subscriptionTypeRepository;
        private readonly IUserAccountRepository _userAccountRepository;
        private readonly ICompanyRepository _companyRepository;
        private readonly ICountryRepository _countryRepository;

        private readonly ISubscriptionActivationRepository _subscriptionActivationRepository;
        private readonly ISoftwarePackageRepository _softwarePackageRepository;
        private readonly IPackageActivationRepository _packageActivationRepository;
        private readonly IStoreSettingRepository _storeSettingRepository;
        private readonly IPaymentMethodRepository _paymentMethodRepository;
        public TransactionLogRepository LogRepository { get; }
        public IConfiguration Config { get; }
        private IEmailSender _emailsender { get; }
        public LicenseController(IUserAccountRepository userAccountRepository, ICompanyRepository companyRepository,
            IStoreSettingRepository storeSettingRepository,
            IConfiguration config, TransactionLogRepository logRepository, //IUserTransactionLogRepository logRepository, 
            ISoftwarePackageRepository softwarePackageRepository, IPackageActivationRepository packageActivationRepository,
            ISubscriptionTypeRepository subscriptionTypeRepository, ISubscriptionActivationRepository subscriptionActivationRepository,
            IEmailSender emailsender, ICountryRepository countryRepository, IPaymentMethodRepository paymentMethodRepository)
        {
            Config = config;
            LogRepository = logRepository;
            _userAccountRepository = userAccountRepository;
            _companyRepository = companyRepository;
            _storeSettingRepository = storeSettingRepository;
            _softwarePackageRepository = softwarePackageRepository;
            _packageActivationRepository = packageActivationRepository;

            _subscriptionTypeRepository = subscriptionTypeRepository;
            _subscriptionActivationRepository = subscriptionActivationRepository;
            _emailsender = emailsender;
            _countryRepository = countryRepository;
            _paymentMethodRepository = paymentMethodRepository;
        }
        [HttpGet]
        public IActionResult GetCountry()
        {
            return Json(_countryRepository.GetAllForDropDown());
        }

        [HttpGet]
        [AllowAnonymous]
        public ActionResult PurchasePackage()
        {

            try
            {
                var callbackurllink = ""; //Request.GetTypedHeaders().Referer.ToString().ToLower();

                //var BusinessTypeId =  HttpContext.Session.GetInt32("BusinessTypeId");
                var ComId = HttpContext.Session.GetInt32("ComId");
                var UserId = HttpContext.Session.GetInt32("UserId");
                HttpContext.Session.SetString("CallBackUrlLink", callbackurllink);
                //var weburl =


                var BusinessType = _storeSettingRepository.All().Include(x => x.BusinessType).Where(x => x.ComId == ComId).FirstOrDefault();
                if (BusinessType.BusinessType != null)
                {

                    //if (BusinessTypeId == 0)
                    //{
                    //    var abc = _softwarePackageRepository.All();
                    //    return View(abc);

                    //}
                    //else
                    //{
                    var abc = _softwarePackageRepository.All().Include(x => x.DurationType).Include(x => x.Country).Where(x => x.BusinessTypeId == BusinessType.BusinessTypeId);
                    return View(abc);

                    //}
                }
                else
                {
                    var abc = _softwarePackageRepository.All().Include(x => x.DurationType);
                    return View(abc);
                }

                return View();
            }
            catch (Exception ex)
            {
                return Json(new { success = false, error = ex.Message });
            }
        }

        [HttpGet]
        public IActionResult GetStoreSettings()
        {
            var ComId = HttpContext.Session.GetInt32("ComId");
            var UserId = HttpContext.Session.GetInt32("UserId");
            var StoreSettings = _storeSettingRepository.All().Where(x => x.ComId == ComId);
            var query = StoreSettings.Select(x => new
            {
                x.Address,
                x.City,
                x.State,
                x.ZipCode
            });
            return Json(query);
        }


        [HttpGet]
        public IActionResult GetPaymentMethod()
        {
            var ComId = HttpContext.Session.GetInt32("ComId");
            var UserId = HttpContext.Session.GetInt32("UserId");
            var query = _paymentMethodRepository.All().Where(x => x.ComId == ComId).Select(x => new
            {
                x.Id,
                x.CardNumber,
                x.CardNickName,
                x.NameOnCard,
                x.IsDebitCredit,
                x.IsPayPal,
                x.Month,
                x.Year,
                x.CW,
                x.Address,
                x.City,
                x.State,
                x.ZipCode,
                x.LegalAddress,
                x.LegalCityAddress,
                x.LegalState,
                x.LegalZipCode,
                x.Country.CountryName,
                x.Country.CountryCode,
                StoreAddress = x.StoreSettings.Address,
                StoreCity = x.StoreSettings.City,
                StoreState = x.StoreSettings.State,
                StoreZipCode = x.StoreSettings.ZipCode
            });
            return Json(query);
        }


        [HttpGet]
        public IActionResult EditPaymentMethod(int id)
        {
            var ComId = HttpContext.Session.GetInt32("ComId");
            var UserId = HttpContext.Session.GetInt32("UserId");
            var query = _paymentMethodRepository.Find(id);
            return Json(query);
        }

        [HttpPost]
        [AllowAnonymous]
        public IActionResult PaymentMethodEntry([FromBody] PaymentMethodModel model)
        {
            try
            {
                var UserId = HttpContext.Session.GetInt32("UserId");
                var ComId = HttpContext.Session.GetInt32("ComId");

                var errors = ModelState.Where(x => x.Value.Errors.Any())
                .Select(x => new { x.Key, x.Value.Errors });

                Console.WriteLine(errors);

                if (ModelState.IsValid)
                {
                    if (model.Id > 0)
                    {
                        _paymentMethodRepository.Update(model, model.Id);
                        TempData["Message"] = "Data Update Successfully";
                        TempData["Status"] = "2";

                        return Json(new { error = false, message = "Data updated successfully", Id = model.Id });
                    }
                    else
                    {
                        _paymentMethodRepository.Insert(model);


                        TempData["Message"] = "Data Save Successfully";
                        TempData["Status"] = "1";
                        return Json(new { error = false, message = "Data saved successfully", Id = model.Id });
                    }

                }
                else
                {

                    return Json(new { error = true, message = "failed to save Data" });
                }



            }
            catch (Exception ex)
            {

                return Json(new { error = true, message = ex.Message });
            }
        }


        [HttpGet]
        [AllowAnonymous]
        public ActionResult CheckOut(int packageid)
        {
            ViewBag.IsBkash = 0;
            ViewBag.IsAuto = 0;
            ViewBag.IsNagad = 0;

            //var abc = _softwarePackageRepository.Find(packageid);

            //if (abc == null)
            //{
            var abc = _softwarePackageRepository.All()
               //.Include(x=>x.Duration)
               .Include(x => x.BusinessType)
               .Include(x => x.Country)
               .Where(x => x.Id == packageid).FirstOrDefault();
            //}
            HttpContext.Session.SetInt32("packageid", abc.Id);

            abc.InvoiceNo = "INV#" + long.Parse(DateTime.Now.ToString("yyyyMMddHHmmss"));
            HttpContext.Session.SetString("invoiceno", abc.InvoiceNo);


            return View(abc);
        }

        [HttpGet]
        [AllowAnonymous]
        public ActionResult BkashAutoCheckOut(int packageid, int UserId, string CallBackURL)
        {
            var abc = _softwarePackageRepository.Find(packageid);

            ViewBag.IsBkash = 1;
            ViewBag.IsAuto = 1;
            ViewBag.IsNagad = 0;

            if (abc != null && UserId > 0)
            {
                if (UserId > 0)
                {
                    var userdata = _userAccountRepository.All(false).Where(x => x.Id == UserId).FirstOrDefault();
                    //var companydata = _companyRepository.All().Where(x => x.Id == userdata.ComId).FirstOrDefault();
                    LoginViewModel loginviewmodel = new LoginViewModel();
                    loginviewmodel.Email = userdata.Email;
                    loginviewmodel.Password = userdata.Password;


                    //int ComId = _userAccountRepository.GetComId(loginviewmodel);
                    HttpContext.Session.SetInt32("ComId", userdata.ComId);
                    HttpContext.Session.SetInt32("UserId", userdata.Id);
                    HttpContext.Session.SetString("CallBackUrlLink", CallBackURL);
                    HttpContext.Session.SetString("UserInfo", userdata.Email);
                    HttpContext.Session.SetInt32("packageid", abc.Id);
                    //var softwarepacakge = _softwarePackageRepository.All().Where(x => x.BusinessTypeId == companydata.BusinessTypeId).FirstOrDefault();
                    //HttpContext.Session.SetInt32("packageid", softwarepacakge.Id);

                }
                //else
                //{
                //    //HttpContext.Session.SetInt32("packageid", packageid);
                //    HttpContext.Session.SetInt32("packageid", abc.Id);

                //}
                //abc = _softwarePackageRepository.All().FirstOrDefault();
            }
            //else if (abc == null)
            //{ 
            //  HttpContext.Session.SetInt32("packageid", packageid);

            //}

            abc.InvoiceNo = "INV#" + long.Parse(DateTime.Now.ToString("yyyyMMddHHmmss"));
            HttpContext.Session.SetString("invoiceno", abc.InvoiceNo);


            return View("CheckOut", abc);
        }

        private static readonly Random getrandom = new Random();
        public static int GetRandomNumber(int min, int max)
        {
            lock (getrandom)
            {
                return getrandom.Next(min, max);
            }
        }
        public async Task<JsonResult> createpayment(string invno, decimal invamount, string comsecret, string BackUrl)
        {
            try
            {
                var previnvoiceno = _packageActivationRepository.All().Where(x => x.InvoiceNo == invno).FirstOrDefault();
                if (previnvoiceno != null)
                {
                    return Json(new { success = false, responseText = "Inoice No Already Include in the System.Please try to Refresh the Page." });
                }
                //else
                //{
                //    if (invno == HttpContext.Session.GetString("InvoiceNo")  && invamount.ToString() == HttpContext.Session.GetString("Amount"))
                //    {
                //        var x = "Success";
                //    }
                //    else
                //    {
                //        return Json(new { success = false, responseText = "Inoice No / Invoice Amount is not Same.Please try to Refresh the Page." });
                //    }

                //}

                using (var httpClient = new HttpClient())
                {

                    System.Net.ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12 | SecurityProtocolType.Tls11 | SecurityProtocolType.Tls;
                    //using (var request = new HttpRequestMessage(new HttpMethod("POST"), "https://checkout.sandbox.bka.sh/v1.2.0-beta/checkout/token/grant"))
                    using (var request = new HttpRequestMessage(new HttpMethod("POST"), " https://checkout.pay.bka.sh/v1.2.0-beta/checkout/token/grant"))
                    {


                        request.Headers.TryAddWithoutValidation("password", password);
                        request.Headers.TryAddWithoutValidation("username", username);

                        request.Content = new StringContent("{\"app_secret\":\"" + app_secret + "\",\"app_key\":\"" + app_key + "\"}", Encoding.UTF8, "application/json");


                        HttpResponseMessage response = await httpClient.SendAsync(request);
                        if (response.IsSuccessStatusCode)
                        {
                            ResponseText = await response.Content.ReadAsStringAsync();


                        }


                        // json_serializer = new JavaScriptSerializer();
                        MyObj routes_list = JsonSerializer.Deserialize<MyObj>(ResponseText);

                        errorCode = routes_list.errorCode;
                        errorMessage = routes_list.errorMessage;
                        status = routes_list.status;
                        msg = routes_list.msg;
                        if (status == "fail")
                        {
                            return Json(new { success = false, responseText = msg });
                        }

                        token_id = routes_list.id_token;
                        refresh_token = routes_list.refresh_token;

                        //return Json(new { Success = 1, ResponseText, ex = "" });
                        //string idToken = response.Content.ReadAsStreamAsync["id_token"].Trim();
                    }



                    //using (var request = new HttpRequestMessage(new HttpMethod("POST"), "https://checkout.sandbox.bka.sh/v1.2.0-beta/checkout/payment/create"))
                    using (var request = new HttpRequestMessage(new HttpMethod("POST"), "https://checkout.pay.bka.sh/v1.2.0-beta/checkout/payment/create"))
                    {
                        merchantInvoiceNumber = HttpContext.Session.GetString("invoiceno");//"INV#" + long.Parse(DateTime.Now.ToString("yyyyMMddHHmmss"));//invno;//
                        amount = decimal.Parse(invamount.ToString());//GetRandomNumber(10, 50);
                        currency = "BDT";

                        //HttpContext.Session.SetString("InvoiceNo", invno);
                        HttpContext.Session.SetString("Amount", amount.ToString());


                        request.Headers.TryAddWithoutValidation("Authorization", token_id);
                        request.Headers.TryAddWithoutValidation("x-app-key", app_key);

                        string asdf = "{\"currency\":\"" + currency + "\",\"amount\":\"" + amount + "\",\"intent\":\"" + intent + "\",\"merchantInvoiceNumber\":\"" + merchantInvoiceNumber + "\"}";

                        request.Content = new StringContent("{\"currency\":\"" + currency + "\",\"amount\":\"" + amount + "\",\"intent\":\"" + intent + "\",\"merchantInvoiceNumber\":\"" + merchantInvoiceNumber + "\"}", Encoding.UTF8, "application/json");

                        //var response = await httpClient.SendAsync(request);


                        HttpResponseMessage response = await httpClient.SendAsync(request);
                        if (response.IsSuccessStatusCode)
                        {
                            ResponseText = await response.Content.ReadAsStringAsync();


                        }
                        //var options = new JsonSerializerOptions
                        //{
                        //    //IncludeFields = true,
                        //};

                        var options = new JsonSerializerOptions
                        {
                            PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
                        };
                        var routes_list = JsonSerializer.Deserialize<MyObj>(ResponseText, options);
                        //var routes_list = JsonSerializer.Deserialize<MyObj>(ResponseText , options);
                        //MyObj routes_list = JsonSerializer.Deserialize<MyObj>(ResponseText);

                        //JavaScriptSerializer json_serializer = new JavaScriptSerializer();
                        //MyObj routes_list = JsonSerializer.Deserialize<MyObj>(ResponseText);

                        errorCode = routes_list.errorCode;
                        errorMessage = routes_list.errorMessage;

                        //token_id = routes_list.id_token;
                        //refresh_token = routes_list.refresh_token;
                        paymentID = routes_list.paymentID;

                        //var response = await httpClient.SendAsync(request);
                    }


                    //return Json(ResponseText);
                    return Json(new { success = true, responseText = ResponseText });

                }


            }
            catch (Exception ex)
            {

                //return Json(new { Success = 0, ex = ex.Message.ToString() });
                return Json(new { success = false, responseText = ex.Message });

            }

            //return Json(new { Success = 0, ex = new Exception("Unable to Execute").Message.ToString() });
        }
        public async Task<JsonResult> executepayment()//string packageid
        {
            try
            {
                var packageid = HttpContext.Session.GetInt32("packageid");
                using (var httpClient = new HttpClient())
                {
                    //using (var request = new HttpRequestMessage(new HttpMethod("POST"), "https://checkout.sandbox.bka.sh/v1.2.0-beta/checkout/payment/execute/" + paymentID + ""))
                    using (var request = new HttpRequestMessage(new HttpMethod("POST"), "https://checkout.pay.bka.sh/v1.2.0-beta/checkout/payment/execute/" + paymentID + ""))
                    {
                        request.Headers.TryAddWithoutValidation("Authorization", token_id);
                        request.Headers.TryAddWithoutValidation("x-app-key", app_key);

                        //HttpResponseMessage response =await httpClient.SendAsync(request);
                        //ResponseText = response.AsyncState.ToString();

                        HttpResponseMessage response = await httpClient.SendAsync(request);
                        if (response.IsSuccessStatusCode)
                        {
                            ResponseText = await response.Content.ReadAsStringAsync();



                        }


                        //JavaScriptSerializer json_serializer = new JavaScriptSerializer();
                        MyObj routes_list = JsonSerializer.Deserialize<MyObj>(ResponseText);
                        //token_id = routes_list.id_token;
                        //refresh_token = routes_list.refresh_token;
                        errorCode = routes_list.errorCode;
                        errorMessage = routes_list.errorMessage;

                        if (errorCode != null) ///errorCode != null && 
                        {

                            return Json(new { Success = 0, ex = errorMessage });
                            //return Json(new { error = true, ex = errorMessage });

                        }


                        trxID = routes_list.trxID;
                        createTime = DateTime.Now;
                        updateTime = DateTime.Now;
                        amount = decimal.Parse(routes_list.amount);
                        currency = routes_list.currency;

                        //var durationdata = _packageActivationRepository.All().Include(x=>x.SoftwarePackage).ThenInclude(x=>x.DurationType).Where(x=>x.PackageId == int.Parse(packageid.ToString())).FirstOrDefault();
                        var durationdata = _softwarePackageRepository.All().Include(x => x.DurationType).Where(x => x.Id == int.Parse(packageid.ToString())).FirstOrDefault();


                        var duration = int.Parse(durationdata.Duration.ToString()); // fahad
                        var durationtype = durationdata.DurationType.DurationName;
                        DateTime startDate = DateTime.Parse(DateTime.Now.Date.ToString("dd-MMM-yy"));
                        DateTime expiryDate = startDate;
                        if (durationtype == "Day")
                        {
                            expiryDate = startDate.AddDays(duration);
                        }
                        else if (durationtype == "Month")
                        {
                            expiryDate = startDate.AddMonths(duration);
                        }
                        else if (durationtype == "Year")
                        {
                            expiryDate = startDate.AddYears(duration);
                        }



                        PackageActivationModel cstpayment = new PackageActivationModel();
                        cstpayment.InvoiceNo = merchantInvoiceNumber;
                        cstpayment.PaymentDate = createTime;
                        cstpayment.Amount = amount;
                        cstpayment.TrxId = trxID;
                        cstpayment.Status = "Success";
                        cstpayment.ActiveFromDate = startDate;
                        cstpayment.ActiveToDate = expiryDate;
                        cstpayment.ActiveYesNo = true;
                        cstpayment.PackageId = packageid;
                        cstpayment.ValidityDay = durationdata.TotalDays;




                        //cstpayment.userid = HttpContext.Session.GetInt32("UserId");
                        //cstpayment.UserPhoneNo = Session["userphoneno"].ToString();
                        var UserId = HttpContext.Session.GetInt32("UserId");
                        var useremailaddress = HttpContext.Session.GetString("UserInfo");



                        cstpayment.LuserId = UserId.GetValueOrDefault();
                        cstpayment.BillingName = useremailaddress;


                        //cstpayment.PaymentDate =
                        if (trxID != null)
                        {
                            _packageActivationRepository.Insert(cstpayment);
                            await _emailsender.SendEmailAsync(useremailaddress, "Payment Status", "Your Payment have received Successfully.");
                            //db.SaveChanges();
                            //Session["activepackage"] = 1;
                        }


                        var subscritpion = _subscriptionActivationRepository.All().Where(x => x.LuserId == UserId).OrderByDescending(x => x.Id).FirstOrDefault();
                        subscritpion.ValidityDay = 30;
                        subscritpion.ActiveToDate = DateTime.Now.AddMonths(1);
                        subscritpion.Amount = float.Parse(amount.ToString());
                        subscritpion.IsActive = true;
                        subscritpion.UpdateDate = DateTime.Now.Date;
                        subscritpion.Remarks = "Last purchase Invoice No : " + HttpContext.Session.GetString("invoiceno");


                        _subscriptionActivationRepository.Update(subscritpion, subscritpion.Id);


                        if (cstpayment.InvoiceNo == HttpContext.Session.GetString("invoiceno") && cstpayment.Amount.ToString() == HttpContext.Session.GetString("Amount"))
                        {
                            var x = "Success";
                        }
                        else
                        {
                            return Json(new { success = false, responseText = "Inoice No / Invoice Amount is not Same.Please try to Refresh the Page." });
                        }






                        //JsonResult query = await paymentquery();
                        //JsonResult trandetails = await transactiondetails();

                    }
                    var callbackurl = HttpContext.Session.GetString("CallBackUrlLink");
                    return Json(new { Success = 1, ex = "Payment Success", CallBackURL = callbackurl });


                    //return Json(ResponseText);

                }
            }
            catch (Exception ex)
            {

                return Json(new { Success = 0, ex = ex.Message.ToString() });

            }
        }
        public async Task<JsonResult> paymentquery()
        {
            try
            {
                using (var httpClient = new HttpClient())
                {
                    //using (var request = new HttpRequestMessage(new HttpMethod("GET"), "https://checkout.sandbox.bka.sh/v1.2.0-beta/checkout/payment/query/" + paymentID + ""))
                    using (var request = new HttpRequestMessage(new HttpMethod("GET"), "https://checkout.pay.bka.sh/v1.2.0-beta/checkout/payment/query/" + paymentID + ""))
                    {
                        request.Headers.TryAddWithoutValidation("Authorization", token_id);
                        request.Headers.TryAddWithoutValidation("x-app-key", app_key);

                        //HttpResponseMessage response =await httpClient.SendAsync(request);
                        //ResponseText = response.AsyncState.ToString();

                        HttpResponseMessage response = await httpClient.SendAsync(request);
                        if (response.IsSuccessStatusCode)
                        {
                            ResponseText = await response.Content.ReadAsStringAsync();


                        }



                    }

                    return Json(ResponseText);

                }
            }
            catch (Exception ex)
            {

                return Json(new { Success = 0, ex = ex.Message.ToString() });

            }
        }
        public async Task<JsonResult> transactiondetails()
        {
            try
            {
                using (var httpClient = new HttpClient())
                {

                    //using (var request = new HttpRequestMessage(new HttpMethod("GET"), "https://checkout.sandbox.bka.sh/v1.2.0-beta/checkout/payment/search/"+ trxID + ""))
                    using (var request = new HttpRequestMessage(new HttpMethod("GET"), "https://checkout.pay.bka.sh/v1.2.0-beta/checkout/payment/search/" + trxID + ""))
                    {
                        request.Headers.TryAddWithoutValidation("Authorization", token_id);
                        request.Headers.TryAddWithoutValidation("x-app-key", app_key);

                        //HttpResponseMessage response =await httpClient.SendAsync(request);
                        //ResponseText = response.AsyncState.ToString();

                        HttpResponseMessage response = await httpClient.SendAsync(request);
                        if (response.IsSuccessStatusCode)
                        {
                            ResponseText = await response.Content.ReadAsStringAsync();


                        }


                        //JavaScriptSerializer json_serializer = new JavaScriptSerializer();
                        MyObj routes_list = JsonSerializer.Deserialize<MyObj>(ResponseText);
                        //token_id = routes_list.id_token;
                        //refresh_token = routes_list.refresh_token;
                        errorCode = routes_list.errorCode;
                        errorMessage = routes_list.errorMessage;

                        //trxID = routes_list.trxID;
                        createTime = DateTime.Now.Date;
                        updateTime = DateTime.Now.Date;
                        amount = decimal.Parse(routes_list.amount);
                        currency = routes_list.currency;



                    }

                    return Json(ResponseText);

                }
            }
            catch (Exception ex)
            {

                return Json(new { Success = 0, ex = ex.Message.ToString() });

            }
        }
        struct MyObj
        {
            public string? token_type { get; set; }
            public string? id_token { get; set; }
            public string? refresh_token { get; set; }
            public string? paymentID { get; set; }
            public string? agreementID { get; set; }
            public string? trxID { get; set; }
            public string? amount { get; set; }
            public string? currency { get; set; }
            public string? errorCode { get; set; }
            public string? errorMessage { get; set; }
            public string? status { get; set; }
            public string? msg { get; set; }
        }
    }
}
