using KursiIm.Domain.SeedWork;
using System;
using System.Collections.Generic;

#nullable disable

namespace KursiIm.Domain.KursiIm
{
    public partial class LogUserActivity: BaseEntity
    {
        public int IDUser { get; set; }
        public DateTime EntryDate { get; set; }
        public string ComputerName { get; set; }
        public string IPAddress { get; set; }
        public int IDLogBrowserType { get; set; }
        public int IDLogOperatingSystemType { get; set; }
        public int IDModule { get; set; }
        public string URL { get; set; }
        public bool? IsPublic { get; set; }
        public bool IsMobileDevice { get; set; }
        public int IDLogUserActivityStatus { get; set; }
        public string EntryUser { get; set; }

        public virtual LogInternetBrowserType IDLogBrowserTypeNavigation { get; set; }
        public virtual LogOperatingSystemType IDLogOperatingSystemTypeNavigation { get; set; }
        public virtual LogUserActivityStatus IDLogUserActivityStatusNavigation { get; set; }
        public virtual Module IDModuleNavigation { get; set; }
    }
}
