using KursiIm.Domain.SeedWork;
using System;
using System.Collections.Generic;

#nullable disable

namespace KursiIm.Domain.KursiIm
{
    public partial class LogFailedAuthentication : BaseEntity
    {
        // public int Id { get; set; }
        public string Account { get; set; }
        public string ComputerName { get; set; }
        public string IPAddress { get; set; }
        public int IDLogOperationSystemType { get; set; }
        public int IDLogBrowserType { get; set; }
        public bool IsMobileDevice { get; set; }
        public DateTime EntryDate { get; set; }

        public virtual LogInternetBrowserType IDLogBrowserTypeNavigation { get; set; }
        public virtual LogOperatingSystemType IDLogOperationSystemTypeNavigation { get; set; }

    }
}
