using System;
using System.Collections.Generic;

#nullable disable

namespace KursiIm.Domain.KursiIm
{
    public partial class LogFailedAuthentication
    {
        public int Id { get; set; }
        public byte[] Account { get; set; }
        public string ComputerName { get; set; }
        public string Ipaddress { get; set; }
        public int IdlogOperationSystemType { get; set; }
        public int IdlogBrowserType { get; set; }
        public bool IsMobileDevice { get; set; }
        public DateTime EntryDate { get; set; }

        public virtual LogInternetBrowserType IdlogBrowserTypeNavigation { get; set; }
        public virtual LogOperatingSystemType IdlogOperationSystemTypeNavigation { get; set; }
    }
}
