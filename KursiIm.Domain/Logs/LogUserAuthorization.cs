using KursiIm.Domain.SeedWork;
using System;
using System.Collections.Generic;

#nullable disable

namespace KursiIm.Domain.KursiIm
{
    public partial class LogUserAuthorization : BaseEntity
    {
      //  public int Id { get; set; }
        public int Iduser { get; set; }
        public DateTime EntryDate { get; set; }
        public string ComputerName { get; set; }
        public string Ipaddress { get; set; }
        public int IdlogBrowserType { get; set; }
        public int IdlogOperatingSystemType { get; set; }
        public bool IsMobileDevice { get; set; }
        public int IdlogUserAuthorizationStatus { get; set; }
        public string EntryUser { get; set; }

        public virtual LogUserAuthorizationStatus IdlogUserAuthorizationStatusNavigation { get; set; }
        public virtual LogInternetBrowserType IdlogBrowserTypeNavigation { get; set; }
        public virtual LogOperatingSystemType IdlogOperatingSystemTypeNavigation { get; set; }
    }
}
