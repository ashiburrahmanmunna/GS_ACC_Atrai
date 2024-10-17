using Atrai.Data.Interfaces;
using Atrai.Model.Core.Entity;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Atrai.Services
{
    public interface INIDVerify
    {
        Task<VoterModel> NIDVerifyAsync(string Sms, string smsText);
    }


    public class NIDVerify : INIDVerify
    {
        //private readonly SmsSettingModel _SmsSettings;
        private readonly ISmsSettingRepository _SmsSettingRepository;
        private readonly IVoterRepository _voterRepository;


        public NIDVerify(IOptions<SmsSettingModel> SmsSettings, ISmsSettingRepository SmsSettingRepository, IVoterRepository voterRepository)
        {
            //_SmsSettings = SmsSettings.Value;
            _SmsSettingRepository = SmsSettingRepository;
            _voterRepository = voterRepository;
        }

        public async Task<VoterModel> NIDVerifyAsync(string VoterIdCardScan, string dateOfBirth)
        {
            VoterModel abc = new VoterModel();
            try
            {
                string app_key_porichoy_GTR = "dcedfa21-c1a8-4d8c-8472-df06aa538d0a";
                string ResponseText = "";

                string errorCode = "";
                string errorMessage = "";
                string status = "";
                string msg = "";



                using (var httpClient = new HttpClient())
                {
                    ///https://api.porichoybd.com  //https://api.porichoybd.com/api/kyc/nid-person-values
                    //////https://api.porichoybd.com/api/v2/verifications/autofill
                    using (var request = new HttpRequestMessage(new HttpMethod("POST"), "https://api.porichoybd.com/api/v2/verifications/autofill"))
                    {
                        ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;
                        request.Headers.TryAddWithoutValidation("x-api-key", app_key_porichoy_GTR);

                        request.Content = new StringContent("{\"nidNumber\":\"" + VoterIdCardScan + "\",\"dateOfBirth\":\"" + dateOfBirth + "\"}", Encoding.UTF8, "application/json");

                        HttpResponseMessage response = await httpClient.SendAsync(request);
                        if (response.IsSuccessStatusCode)
                        {
                            ResponseText = await response.Content.ReadAsStringAsync();
                        }

                        //ResponseText = ;

                        //JObject asd = JObject.Parse('{"transactionId":"59dca817-bf0f-4ba8-9af4-f5bf8b0683c9-O2aAgI3","creditCost":2,"creditCurrent":904,"status":"YES","data":{"nid":{"fullNameEN":"Rubayet Fahad","fullNameBN":"রুবায়েত ফাহাদ","fathersNameBN":"মোঃ ইলিয়াছ ভুঁইয়া","mothersNameBN":"ফেরদৌস আরা বেগম","spouseNameBN":"","presentAddressBN":"বাসা / হোল্ডিং: ১০, গ্রাম / রাস্তা: এম এম আলী রোড, ওয়ার্ড নং -১৫(পার্ট), ডাকঘর: দামপাড়া - 4000, কোতয়ালী, চট্টগ্রাম","permanentAddressBN":"বাসা / হোল্ডিং: , গ্রাম / রাস্তা: ফতেপুর, , ডাকঘর: -0016, ফেনী সদর, ফেনী","gender":"male","profession":"ছাত্র / ছাত্রী","dateOfBirth":"1986 - 06 - 12T00: 00:00","nationalIdNumber":"1468196009","oldNationalIdNumber":"19861594115410392","photoUrl":"https://prportal.nidw.gov.bd/file-fe/8/b/6/6ec34aa0-4d4a-102b-b186-9fdb6b84541b/Photo-6ec34aa0-4d4a-102b-b186-9fdb6b84541b.jpg?X-Amz-Algorithm=AWS4-HMAC-SHA256&X-Amz-Credential=fileobj%2F20220724%2Fus-east-1%2Fs3%2Faws4_request&X-Amz-Date=20220724T134502Z&X-Amz-Expires=120&X-Amz-SignedHeaders=host&X-Amz-Signature=3ac415b0c667b4870db9c0a53a12d1bd055a8e2e75af32984be4a69b34935e27"}},"errors":[]}');

                        //json json_serializer = new JsonSerializer();
                        JObject asd = JObject.Parse(ResponseText);
                        string data = asd["data"]["nid"].ToString();
                        //JObject data2 = JObject.Parse(data);

                        //MyObjPorichoy routes_list_error = json_serializer.Deserialize<MyObjPorichoy>(ResponseText);
                        //MyObjPorichoy routes_list = JsonConvert.DeserializeObject<MyObjPorichoy>(data);

                        //JsonSerializerSettings xyz = new JsonSerializerSettings();

                        MyObjPorichoy routes_list = JsonConvert.DeserializeObject<MyObjPorichoy>(data);


                        errorCode = routes_list.errorCode;
                        errorMessage = routes_list.passKyc;
                        status = routes_list.voter;
                        ////msg = routes_list.msg;
                        ////errorCode = routes_list.errorCode;
                        ////errorMessage = routes_list.errorMessage;
                        ////status = routes_list.status;
                        ////msg = routes_list.msg;
                        //if (errorMessage == "fail")
                        //{
                        //    return Json(new { success = false, responseText = msg }, JsonRequestBehavior.AllowGet);
                        //}

                        ////////perfect now
                        abc.name = routes_list.fullNameBN;
                        abc.nameEn = routes_list.fullNameEN;
                        abc.father = routes_list.fathersNameBN;
                        abc.mother = routes_list.mothersNameBN;
                        abc.gender = routes_list.gender;
                        abc.spouse = routes_list.spouseNameBN;
                        abc.permanentAddress = routes_list.permanentAddressBN;
                        abc.presentAddressBN = routes_list.presentAddressBN;
                        abc.profession = routes_list.profession;
                        abc.oldNationalIdNumber = routes_list.oldNationalIdNumber;

                        //abc.presentAddressBN = routes_list.presentAddressBN;


                        string url = routes_list.photoUrl;

                        string encodedUrl = Convert.ToBase64String(Encoding.Default.GetBytes(url));

                        using (var client = new WebClient())
                        {
                            byte[] dataBytes = client.DownloadData(new Uri(url));
                            string encodedFileAsBase64 = Convert.ToBase64String(dataBytes);
                            abc.photo = dataBytes;
                        }


                        abc.voterNo = VoterIdCardScan;
                        abc.dob = DateTime.Parse(routes_list.dateOfBirth.ToString());

                        _voterRepository.Insert(abc);
                        //db.SaveChanges();

                    }

                    //return Json(ResponseText, JsonRequestBehavior.AllowGet);


                    //return Json(new { success = true, responseText = ResponseText }, JsonRequestBehavior.AllowGet);

                }

            }
            catch (Exception ex)
            {
                // TODO: handle exception
                throw new InvalidOperationException(ex.Message);
            }

            return abc;
        }


        struct MyObjPorichoy
        {
            public string? voterId { get; set; }
            public string? voterNo { get; set; }
            public string? fullNameEN { get; set; }
            public string? fathersNameEN { get; set; }
            public string? mothersNameEN { get; set; }
            public string? spouseNameEN { get; set; }
            public string? presentAddressEN { get; set; }
            public string? permenantAddressEN { get; set; }
            public string? fullNameBN { get; set; }
            public string? fathersNameBN { get; set; }
            public string? mothersNameBN { get; set; }
            public string? spouseNameBN { get; set; }
            public string? presentAddressBN { get; set; }
            public string? permanentAddressBN { get; set; }
            public string? gender { get; set; }
            public string? profession { get; set; }
            public string? dateOfBirth { get; set; }
            public string? nationalIdNumber { get; set; }
            public string? oldNationalIdNumber { get; set; }
            public string? photoUrl { get; set; }

            public string? msg { get; set; }
            public string? errorCode { get; set; }
            public string? passKyc { get; set; }
            public string? voter { get; set; }
        }
    }
}