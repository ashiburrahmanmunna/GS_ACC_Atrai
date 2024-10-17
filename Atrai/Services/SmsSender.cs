using Atrai.Data.Interfaces;
using Atrai.Model.Core.Entity;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;


namespace Atrai.Services
{
    public interface ISmsSender
    {
        Task SendSmsAsync(string Sms, string smsText);
    }




    public class SmsSender : ISmsSender
    {
        //private readonly SmsSettingModel _SmsSettings;
        private readonly ISmsSettingRepository _SmsSettingRepository;

        public SmsSender(IOptions<SmsSettingModel> SmsSettings, ISmsSettingRepository SmsSettingRepository)
        {
            //_SmsSettings = SmsSettings.Value;
            _SmsSettingRepository = SmsSettingRepository;
        }


        public async Task SendSmsAsync(string MobileNo, string Message)
        {
            try
            {
                SmsSettingModel smsSettings = _SmsSettingRepository.All(false).Where(x => x.IsActive == true).FirstOrDefault();

                if (smsSettings != null)
                {
                    string address = smsSettings.smsAddress;
                    string username = smsSettings.smsUser;
                    string password = smsSettings.smsPassword;
                    string sender = smsSettings.smsSender;

                    string baseUrl = address;

                    if (smsSettings.SmsProvider.Equals("dominate", StringComparison.OrdinalIgnoreCase))
                    {
                        baseUrl += $"?user={username}&password={password}&sender={sender}";
                    }
                    else if (smsSettings.SmsProvider.Equals("infobip", StringComparison.OrdinalIgnoreCase))
                    {
                        string msisdn = "&to=88" + MobileNo.Substring(MobileNo.Length - 11);
                        string message = "&text=" + Message;
                        baseUrl += $"?username={username}&password={password}{msisdn}{message}";
                    }
                    else if (smsSettings != null && smsSettings.SmsProvider.Equals("mobireach", StringComparison.OrdinalIgnoreCase))
                    {

                        try
                        {
                            var client = new HttpClient();

                            // Construct the request
                            var request = new HttpRequestMessage(HttpMethod.Post, address);

                            // Construct the form data
                            var collection = new List<KeyValuePair<string, string>>();
                            collection.Add(new KeyValuePair<string, string>("Username", username));
                            collection.Add(new KeyValuePair<string, string>("Password", password));
                            collection.Add(new KeyValuePair<string, string>("From", sender));
                            collection.Add(new KeyValuePair<string, string>("To", MobileNo.Substring(MobileNo.Length - 11)));
                            collection.Add(new KeyValuePair<string, string>("Message", Message));
                            var content = new FormUrlEncodedContent(collection);

                            // Set the request content
                            request.Content = content;

                            // Send the request and get the response
                            var responsea = await client.SendAsync(request);
                            responsea.EnsureSuccessStatusCode(); // Ensure success or throw exception

                            // Read the response content
                            string responseBody = await responsea.Content.ReadAsStringAsync();
                            Console.WriteLine("Response: " + responseBody);
                        }
                        catch (HttpRequestException ex)
                        {
                            Console.WriteLine("HTTP request failed: " + ex.Message);
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine("An error occurred: " + ex.Message);
                        }

                        //try
                        //{
                        //    using (HttpClient client = new HttpClient())
                        //    {
                        //        var postData = new FormUrlEncodedContent(new[]
                        //        {
                        //            new KeyValuePair<string, string>("Username", username),
                        //            new KeyValuePair<string, string>("Password", password),
                        //            new KeyValuePair<string, string>("From", sender),
                        //            new KeyValuePair<string, string>("To", MobileNo),
                        //            new KeyValuePair<string, string>("Message", Message)
                        //        });

                        //        HttpResponseMessage responsea = await client.PostAsync(baseUrl, postData);
                        //        responsea.EnsureSuccessStatusCode(); // Ensure success or throw exception

                        //        string responseBody = await responsea.Content.ReadAsStringAsync();
                        //        Console.WriteLine("Response: " + responseBody);
                        //    }
                        //}
                        //catch (HttpRequestException ex)
                        //{
                        //    Console.WriteLine("HTTP request failed: " + ex.Message);
                        //}
                        //catch (Exception ex)
                        //{
                        //    Console.WriteLine("An error occurred: " + ex.Message);
                        //}

                        //baseUrl = smsSettings.smsAddress;
                        //username = smsSettings.smsUser;
                        //password = smsSettings.smsPassword;
                        //sender = smsSettings.smsSender;

                        //var recipient = "88" + MobileNo.Substring(MobileNo.Length - 11);
                        //var message = Message;


                        //string encodedUrl = $"{baseUrl}?Username={username}" +
                        //                    $"&Password={password}" +
                        //                    $"&From={sender}" +
                        //                    $"&To={HttpUtility.UrlEncode(recipient)}" +
                        //                    $"&Message={HttpUtility.UrlEncode(message)}";

                        //try
                        //{
                        //    using (HttpClient client = new HttpClient())
                        //    {
                        //        HttpResponseMessage responsea = await client.GetAsync(encodedUrl);
                        //        responsea.EnsureSuccessStatusCode(); // Ensure success or throw exception

                        //        string responseBody = await responsea.Content.ReadAsStringAsync();
                        //        Console.WriteLine("Response: " + responseBody);
                        //    }
                        //}
                        //catch (HttpRequestException ex)
                        //{
                        //    Console.WriteLine("HTTP request failed: " + ex.Message);
                        //}
                        //catch (Exception ex)
                        //{
                        //    Console.WriteLine("An error occurred: " + ex.Message);
                        //}
                    }
                    else if (smsSettings.SmsProvider.Equals("sslwireless", StringComparison.OrdinalIgnoreCase))
                    {
                        // Implement SSL Wireless provider logic here
                    }
                    else if (smsSettings.SmsProvider.Equals("metrotel", StringComparison.OrdinalIgnoreCase))
                    {
                        // Implement Metrotel provider logic here
                    }
                    else
                    {
                        // Default provider logic
                    }

                    Stream data = new WebClient().OpenRead(baseUrl);
                    StreamReader reader = new StreamReader(data);
                    string response = reader.ReadToEnd();
                    data.Close();
                    reader.Close();
                }
            }
            catch (HttpRequestException ex)
            {
                Console.WriteLine("HTTP request failed: " + ex.Message);
            }
            catch (Exception ex)
            {
                Console.WriteLine("An error occurred: " + ex.Message);
            }
        }

        //public Task SendSmsAsync(string MobileNo, string Message)
        //{

        //    try
        //    {

        //        //bool condition = false;
        //        //if (IsSystem == 1)
        //        //{
        //        //    condition = true;
        //        //}

        //        WebClient client = new WebClient();
        //        SmsSettingModel asdf = new SmsSettingModel();
        //        //DataTable dt = new DataTable("smsSettings");

        //        var x = (_SmsSettingRepository.All(false).Where(x => x.IsActive == true).FirstOrDefault());


        //        var smssettingscount = _SmsSettingRepository.All(true).Where(x=>x.IsActive == true).Count();
        //        if (smssettingscount > 0)
        //        {
        //            x = (_SmsSettingRepository.All(true).Where(x => x.IsActive == true).FirstOrDefault());
        //        }


        //        //var x = (_SmsSettingRepository.All(false).Where(x => x.IsActive == true && x.IsSystem == condition).SingleOrDefault());
        //        //dt.Rows.Add(x);

        //        if (x != null)
        //        {



        //        //foreach (DataRow drCurrent in x))
        //        //{
        //        if (x.SmsProvider.ToString().ToUpper() == "Dominate".ToUpper())
        //        {
        //            string Address = x.smsAddress.ToString();
        //            string UserID = "?user=" + x.smsUser.ToString();
        //            string Password = "&password=" + x.smsPassword.ToString();
        //            string SendID = "&sender=" + x.smsSender.ToString();
        //            string Message1 = "";
        //            string MobileNo1 = "";

        //            string BaseUrl = Address + UserID + Password + SendID + Message1 + MobileNo1;

        //            Stream data = client.OpenRead(BaseUrl);
        //            StreamReader reader = new StreamReader(data);
        //            string s = reader.ReadToEnd();
        //            data.Close();
        //            reader.Close();
        //        }
        //        else if (x.SmsProvider.ToString() == "infobip")
        //        {

        //            string Address = x.smsAddress.ToString();
        //            string UserID = "?username=" + x.smsUser.ToString();
        //            string Password = "&password=" + x.smsPassword.ToString();

        //            string msisdn = "";


        //            string SendID = "&sender=" + x.smsSender.ToString();
        //            string Message1 = "";
        //            //string MyString = "+8801671303302";

        //            Message1 = "&text= " + Message.ToString();
        //            msisdn = "&to=88" + MobileNo.Substring(MobileNo.Length - 11);




        //            string BaseUrl = Address + UserID + Password + msisdn + Message1;

        //            Stream data = client.OpenRead(BaseUrl);
        //            StreamReader reader = new StreamReader(data);
        //            string s = reader.ReadToEnd();
        //            data.Close();
        //            reader.Close();

        //        }
        //        else if ((x.SmsProvider.ToString() == "sslwireless"))
        //        {

        //            string Address = x.smsAddress.ToString();


        //            string UserID = "?user=" + x.smsUser.ToString();
        //            string Password = "&pass=" + x.smsPassword.ToString();


        //            string SendID = "&sid=" + x.smsSender.ToString();
        //            string csmsid = "&csmsid=123456789";
        //            string Message1 = "";


        //            string msisdn = "";


        //            string MyString = "+8801671303302";

        //            Message1 = "&sms= " + "sms will generate here".ToString();
        //            msisdn = "&msisdn=88" + MyString.Substring(MyString.Length - 11);



        //            string BaseUrl = Address + UserID + Password + SendID + Message1 + msisdn + csmsid;

        //            Stream data = client.OpenRead(BaseUrl);
        //            StreamReader reader = new StreamReader(data);
        //            string s = reader.ReadToEnd();
        //            data.Close();
        //            reader.Close();

        //        }
        //        else if ((x.SmsProvider.ToString() == "metrotel"))
        //        {

        //            ///string url = "http://portal.metrotel.com.bd/smsapi?api_key=C20001625e50f2b354c127.63841004&type=text&contacts=" + to + "&senderid=8809612440541" + "&msg=" + text;
        //            //http://portal.metrotel.com.bd/smsapi?api_key=C20001625e50f2b354c127.63841004&type=text&contacts=8801671303302&pass=H2bfZIbRFi&senderid=8809612440541&msg= Your security code is 310677

        //            string contacts = "";
        //            string MyString = MobileNo;// "+8801671303302";



        //            string Address = x.smsAddress.ToString();
        //            string apikey = "?api_key=C20001625e50f2b354c127.63841004";
        //            string type = "&type=text";
        //            contacts = "&contacts=88" + MyString.Substring(MyString.Length - 11);
        //            string contactsSelf = "&contacts=8801671303302";



        //            string UserID = "?user=" + x.smsUser.ToString();
        //            string Password = "&pass=" + x.smsPassword.ToString();


        //            string senderid = "&senderid=" + x.smsSender.ToString();
        //            string msg = "";
        //            msg = "&msg= " + Message.ToString();



        //            string BaseUrl = Address + apikey + type + contacts + Password + senderid + msg.Replace("&amp;", "&");

        //            Stream data = client.OpenRead(BaseUrl);
        //            StreamReader reader = new StreamReader(data);
        //            string s = reader.ReadToEnd();
        //            data.Close();
        //            reader.Close();



        //            //string BaseUrlSelf = Address + apikey + type + contactsSelf + Password + senderid + msg.Replace("&amp;", "/");

        //            //Stream dataSelf = client.OpenRead(BaseUrlSelf);
        //            //StreamReader readerSelf = new StreamReader(dataSelf);
        //            //string sSelf = readerSelf.ReadToEnd();
        //            //dataSelf.Close();
        //            //readerSelf.Close();


        //        }
        //        else
        //        {
        //            string Address = x.smsAddress.ToString();
        //            string UserID = "?username=" + x.smsUser.ToString();
        //            string Password = "&password=" + x.smsPassword.ToString();
        //            string apicode = "&apicode=1";
        //            string msisdn = "";
        //            string countrycode = "&countrycode=880";
        //            string cli = "&cli=" + x.smsSender.ToString();
        //            string messagetype = "&messagetype=1";

        //            string SendID = "&sender=" + x.smsSender.ToString();
        //            string Message1 = "";

        //            string MyString = "+8801671303302";
        //            //string MyString = "+8801621657550";


        //            Message1 = "&message= " + "Sms generate here".ToString();
        //            msisdn = "&msisdn=88" + MyString.Substring(MyString.Length - 11);

        //            string BaseUrl = Address + UserID + Password + apicode + msisdn + countrycode + cli + messagetype + Message1;

        //            Stream data = client.OpenRead(BaseUrl);
        //            StreamReader reader = new StreamReader(data);
        //            string s = reader.ReadToEnd();
        //            data.Close();
        //            reader.Close();

        //        }
        //        }

        //        //}
        //    }
        //    catch (Exception ex)
        //    {
        //        // TODO: handle exception
        //        throw new InvalidOperationException(ex.Message);
        //    }

        //    return Task.CompletedTask;
        //}

    }
}