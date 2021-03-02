using KursiIm.Domain.SeedWork;
using System;
using System.Collections.Generic;
using System.Text;

namespace KursiIm.Domain.Logs
{
    public partial class LogUserAuthorization : BaseEntity
    {
        public int IdUser { get; set; }
        public DateTime EntryDate { get; set; }
        public string ComputerName { get; set; }
        public string IpAddress { get; set; }
        public int IdLogBrowserType { get; set; }
        public int IdLogOperatingSystemType { get; set; }
        public bool IsMobileDevice { get; set; }
        public int IdLogUserAuthorizationStatus { get; set; }
        public string EntryUser { get; set; }
    }
}
