﻿using System;
using System.Collections.Generic;

#nullable disable

namespace KursiIm.Domain.KursiIm
{
    public partial class LogUserAuthorization
    {
        public int Id { get; set; }
        public int Iduser { get; set; }
        public DateTime EntryDate { get; set; }
        public string ComputerName { get; set; }
        public string Ipaddress { get; set; }
        public int IdlogBrowserType { get; set; }
        public int IdlogOperatingSystemType { get; set; }
        public bool IsMobileDevice { get; set; }
        public int IdlogUserAuthorizationStatus { get; set; }
        public DateTime EntryUser { get; set; }

        public virtual LogUserAuthorizationStatus IdlogUserAuthorizationStatusNavigation { get; set; }
    }
}
