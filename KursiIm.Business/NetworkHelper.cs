using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using KursiIm.Domain.Logs;
using UAParser;

namespace KursiIm.Business
{
    public static class NetworkHelper
    {
        public static IHttpContextAccessor _contextAccessor;
        public static void SetHttpContextAccessor(IHttpContextAccessor accessor)
        {
            _contextAccessor = accessor;
        }
        public static string GetIPAddress()
        {
            if (!string.IsNullOrWhiteSpace(_contextAccessor.HttpContext.Request.Headers["client-ip"]))
                return _contextAccessor.HttpContext.Request.Headers["client-ip"];

            return _contextAccessor.HttpContext.Connection.RemoteIpAddress.ToString();
        }

        public static ClientInfo GetBrowserType()
        {
            var ua = _contextAccessor.HttpContext.Request.Headers["User-Agent"].ToString();

            var uaParser = Parser.GetDefault();

            ClientInfo ci = uaParser.Parse(ua);

            return ci;

        }

        public static bool IsMobileDevice()
        {
            var ua = _contextAccessor.HttpContext.Request.Headers["User-Agent"].ToString();

            var uaParser = Parser.GetDefault();

            ClientInfo ci = uaParser.Parse(ua);

            if (ci.OS.Family.ToLower() == "ios" || ci.OS.Family.ToLower() == "android")
                return true;
            
            return false;
        }


        public static int GetBrowserTypeId()
        {
            var type = GetBrowserType().UA.Family;
            if (type.Contains(InternetBrowserType.Chrome.ToString()))
                return (int)InternetBrowserType.Chrome;
            else if (type.Contains(InternetBrowserType.Edge.ToString()))
                return (int)InternetBrowserType.Edge;
            else if (type.Contains(InternetBrowserType.Explorer.ToString()))
                return (int)InternetBrowserType.Explorer;
                
            return (int)InternetBrowserType.Other;

        }

        public static int GetOperatingSystemTypeId()
        {
            var type = GetBrowserType().OS.Family;
            if (type.Contains(OperatingSystemType.Windows.ToString()))
                return (int)OperatingSystemType.Windows;
            else if (type.Contains(OperatingSystemType.Android.ToString()))
                return (int)OperatingSystemType.Android;
            else if (type.Contains(OperatingSystemType.IOS.ToString()))
                return (int)OperatingSystemType.IOS;
            else if (type.Contains(OperatingSystemType.MacOS.ToString()))
                return (int)OperatingSystemType.MacOS;

            return (int)InternetBrowserType.Other;

        }

        public static string GetComputerName()
        {
            return DetermineCompName(GetIPAddress());
        }

        public static string DetermineCompName(string IP)
        {
            try
            {
                IPAddress myIP = IPAddress.Parse(IP);
                IPHostEntry GetIPHost = Dns.GetHostEntry(myIP);
                List<string> compName = GetIPHost.HostName.ToString().Split('.').ToList();
                return compName.First();
            }
            catch (Exception ex){ return ""; }
        }

    }
}
