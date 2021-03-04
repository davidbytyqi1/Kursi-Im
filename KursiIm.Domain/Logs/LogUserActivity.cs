using System;
using System.Collections.Generic;

#nullable disable

namespace KursiIm.Domain.KursiIm
{
    public partial class LogUserActivity
    {
        public int Id { get; set; }
        public int Iduser { get; set; }
        public DateTime EntryDate { get; set; }
        public string ComputerName { get; set; }
        public string Ipaddress { get; set; }
        public int IdlogBrowserType { get; set; }
        public int IdlogOperatingSystemType { get; set; }
        public int Idmodule { get; set; }
        public string Url { get; set; }
        public bool? IsPublic { get; set; }
        public bool IsMobileDevice { get; set; }
        public int IdlogUserActivityStatus { get; set; }
        public string EntryUser { get; set; }

        public virtual LogUserActivityStatus IdlogUserActivityStatusNavigation { get; set; }
        public virtual Module IdmoduleNavigation { get; set; }
    }
}
