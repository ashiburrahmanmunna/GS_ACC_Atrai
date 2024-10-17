using Atrai.Data.Context.AppDataContext;
using Atrai.Model.Core.Entity;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using UAParser;

namespace Atrai.Services
{
    public class TransactionLogRepository
    {
        public IHttpContextAccessor Accessor { get; set; }
        public InvoiceDbContext db { get; set; }

        public TransactionLogRepository(InvoiceDbContext _db, IHttpContextAccessor httpContextAccessor)
        {
            db = _db;
            Accessor = httpContextAccessor;
        }
        public void errorlog(Exception ex)
        {
            string filePath = @"C:\DevelopmentError\DevelopmentFile.txt";


            using (StreamWriter writer = new StreamWriter(filePath, true))
            {
                writer.WriteLine("-----------------------------------------------------------------------------");
                writer.WriteLine("Date : " + DateTime.Now.ToString());
                writer.WriteLine();

                while (ex != null)
                {
                    writer.WriteLine(ex.GetType().FullName);
                    writer.WriteLine("Message : " + ex.Message);
                    writer.WriteLine("StackTrace : " + ex.StackTrace);

                    ex = ex.InnerException;
                }
            }
        }

        public void SuccessLogin(string Latitude, string Longitude, string Status)
        {
            try
            {

                var userAgent = Accessor.HttpContext.Request.Headers["User-Agent"];
                var UserId = Accessor.HttpContext.Session.GetInt32("UserId");
                var ComId = Accessor.HttpContext.Session.GetInt32("ComId");
                var UserInfo = Accessor.HttpContext.Session.GetString("UserInfo");

                string uaString = Convert.ToString(userAgent[0]);

                var uaParser = Parser.GetDefault();

                ClientInfo c = uaParser.Parse(uaString);
                //var devicetype = c.Device.Family;

                var devicetype = "";
                if (userAgent == true)
                {
                    devicetype = "Mobile";
                }
                else
                {
                    devicetype = "Computer";
                }
                //string IP = request.UserHostName;


                string userIpAddress = Accessor.HttpContext.Connection.RemoteIpAddress.ToString();
                //string userIpAddress = request.UserHostAddress;
                var userLoging = new UserLogingInfoModel();
                userLoging.LuserId = int.Parse(UserId.ToString());
                userLoging.ComId = int.Parse(ComId.ToString());

                userLoging.LoginDate = DateTime.Now.Date;
                userLoging.LoginTime = DateTime.Now;
                userLoging.DeviceType = devicetype;
                userLoging.IPAddress = userIpAddress;
                userLoging.Platform = c.OS.Family;
                userLoging.LongString = c.String;
                userLoging.UserName = Environment.UserName;

                //if ((UserInfo == "") || (UserInfo == null))
                //{ 
                //var userinfo = usera
                //}

                userLoging.Status = Status + " - " + UserInfo;


                userLoging.CreateDate = DateTime.UtcNow;
                userLoging.UpdateDate = DateTime.UtcNow;

                //if (Status == "Failure")
                //{
                //    userLoging.Status = Status + " - " + UserInfo;
                //}
                //else
                //{
                //    userLoging.Status = Status + " - " + InvalidUser;

                //}

                //userLoging.Platform = "";// GetUserEnvironment(request);

                userLoging.PcName = Environment.MachineName; // DetermineCompName(request.UserHostName);
                userLoging.WebBrowserName = c.UA.Family;
                userLoging.MacAddress = "";// c.String;//request.UserHostAddress;
                userLoging.WebLink = Accessor.HttpContext.Request.Headers["Referer"];
                userLoging.Latitude = Latitude;
                userLoging.Longitude = Longitude;
                userLoging.Longitude = Longitude;


                //db.AddAsync(userLoging);
                //db.UserLoginginfos.AddAsync(userLoging);
                db.Entry(userLoging).State = Microsoft.EntityFrameworkCore.EntityState.Added;

                db.SaveChanges();

            }
            catch (Exception ex)
            {
                errorlog(ex);
                Console.WriteLine(ex.Message);
            }
        }


        [Obsolete]
        public string? GetUserEnvironment()
        {

            var userAgent = Accessor.HttpContext.Request.Headers["User-Agent"];

            string uaString = Convert.ToString(userAgent[0]);

            var uaParser = Parser.GetDefault();

            ClientInfo c = uaParser.Parse(uaString);

            var browsr = c.UserAgent.Family; //IP Address from the request. 




            var platform = GetUserPlatform(Accessor.HttpContext.Request);
            return $"{browsr},{platform}";
        }

        [Obsolete]
        public string? GetUserPlatform(HttpRequest request)
        {

            var userAgent = request.Headers["User-Agent"];

            string uaString = Convert.ToString(userAgent[0]);

            var uaParser = Parser.GetDefault();

            ClientInfo c = uaParser.Parse(uaString);
            var ua = c.UserAgent.Family;

            if (ua.Contains("Android"))
                return string.Format("Android {0}", GetMobileVersion(ua, "Android"));

            if (ua.Contains("iPad"))
                return string.Format("iPad OS {0}", GetMobileVersion(ua, "OS"));

            if (ua.Contains("iPhone"))
                return string.Format("iPhone OS {0}", GetMobileVersion(ua, "OS"));

            if (ua.Contains("Linux") && ua.Contains("KFAPWI"))
                return "Kindle Fire";

            if (ua.Contains("RIM Tablet") || (ua.Contains("BB") && ua.Contains("Mobile")))
                return "Black Berry";

            if (ua.Contains("Windows Phone"))
                return string.Format("Windows Phone {0}", GetMobileVersion(ua, "Windows Phone"));

            if (ua.Contains("Mac OS"))
                return "Mac OS";

            if (ua.Contains("Windows NT 5.1") || ua.Contains("Windows NT 5.2"))
                return "Windows XP";

            if (ua.Contains("Windows NT 6.0"))
                return "Windows Vista";

            if (ua.Contains("Windows NT 6.1"))
                return "Windows 7";

            if (ua.Contains("Windows NT 6.2"))
                return "Windows 8";

            if (ua.Contains("Windows NT 6.3"))
                return "Windows 8.1";

            if (ua.Contains("Windows NT 10"))
                return "Windows 10";

            //fallback to basic platform:
            return c.UserAgent.Family + (ua.Contains("Mobile") ? " Mobile " : "");
        }

        public string? GetMobileVersion(string userAgent, string device)
        {
            var temp = userAgent.Substring(userAgent.IndexOf(device) + device.Length).TrimStart();
            var version = string.Empty;

            foreach (var character in temp)
            {
                var validCharacter = false;
                int test = 0;

                if (Int32.TryParse(character.ToString(), out test))
                {
                    version += character;
                    validCharacter = true;
                }

                if (character == '.' || character == '_')
                {
                    version += '.';
                    validCharacter = true;
                }

                if (validCharacter == false)
                    break;
            }

            return version;
        }


        public string? fnGetClientIP()
        {

            // Note in localhost you will get ::1 but when it hosted you will get IP Address

            var ip = Accessor.HttpContext.Connection.RemoteIpAddress.ToString();
            string ClientIP = string.Empty;
            if (!string.IsNullOrEmpty(ip))
            {
                string[] ipRange = ip.Split(',');
                int le = ipRange.Length - 1;
                ClientIP = ipRange[0];
            }
            else
            {
                ClientIP = ip;
            }

            return ClientIP;
        }


        public static string DetermineCompName(string IP)
        {
            if (IP.Length > 6)
            {
                IPAddress myIP = IPAddress.Parse(IP);
                IPHostEntry GetIPHost = Dns.GetHostEntry(myIP);
                List<string> compName = GetIPHost.HostName.ToString().Split('.').ToList();
                return compName.First();
            }
            else
            {
                return "Not Found";
            }

        }

        public void TransactionLog(string Controller, string Action, string TransactionStatement, string TransactionalId, string commandType, string DocumentReferance)
        {

            try
            {


                var userAgent = Accessor.HttpContext.Request.Headers["User-Agent"];
                var UserId = Accessor.HttpContext.Session.GetInt32("UserId");
                var ComId = Accessor.HttpContext.Session.GetInt32("ComId");

                string uaString = Convert.ToString(userAgent[0]);

                var uaParser = Parser.GetDefault();

                ClientInfo c = uaParser.Parse(uaString);
                var devicetype = c.Device.Family;

                if (ComId == null)
                {
                    ComId = 1;
                }

                if (UserId == null)
                {
                    UserId = 1;
                }


                string userIpAddress = Accessor.HttpContext.Connection.RemoteIpAddress.ToString();

                var userTranLog = new UserTransactionLogModel();
                userTranLog.LuserId = int.Parse(UserId.ToString());
                //userLoging.userid = Accessor.HttpContext.Session.GetString("userid");
                //Microsoft.Extensions.Primitives.StringValues d="";
                //    Accessor.HttpContext.Request.Headers.TryGetValue("Origin",out d);
                userTranLog.WebLink = Accessor.HttpContext.Request.Headers["Referer"]; // .AbsolutePath;
                userTranLog.TransactionStatement = TransactionStatement;
                userTranLog.CommandType = commandType;
                userTranLog.FromDateTime = DateTime.Now;
                userTranLog.ToDateTime = DateTime.Now;
                userTranLog.IPAddress = userIpAddress;//request.UserHostName;// request.UserHostAddress;
                userTranLog.ComId = int.Parse(ComId.ToString());
                userTranLog.ControllerName = Controller;
                userTranLog.ActionName = Action;
                userTranLog.FlagValue = TransactionalId;
                userTranLog.DocumentReferance = DocumentReferance;
                userTranLog.CreateDate = DateTime.UtcNow;
                userTranLog.UpdateDate = DateTime.UtcNow;



                userTranLog.PcName = Environment.MachineName;


                db.Entry(userTranLog).State = Microsoft.EntityFrameworkCore.EntityState.Added;

                //db.UserTransactionLogs.Add(userTranLog);
                db.SaveChanges();
            }
            catch (Exception ex)
            {
                errorlog(ex);
                Console.WriteLine(ex.Message);
            }

        }


    }
}
