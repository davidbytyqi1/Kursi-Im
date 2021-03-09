using KursiIm.Domain.SeedWork;
using System;
using System.Collections.Generic;

#nullable disable

namespace KursiIm.Domain.KursiIm
{
    public partial class LogDataChange : BaseEntity
    {
       // public int Id { get; set; }
        public DateTime EntryDate { get; set; }
        public int IdentryUser { get; set; }
        public string EntryUser { get; set; }
        public byte[] Before { get; set; }
        public byte[] After { get; set; }
        public string ComputerName { get; set; }
        public string Idaddress { get; set; }
        public int IdlogBrowserType { get; set; }
        public int IdlogOperatingSystemType { get; set; }
        public bool IsMobileDevice { get; set; }
        public int IdlogDataChangeStatus { get; set; }
        public int Idtable { get; set; }

        public virtual LogInternetBrowserType IdlogBrowserTypeNavigation { get; set; }
        public virtual LogDataChangeStatus IdlogDataChangeStatusNavigation { get; set; }
        public virtual LogOperatingSystemType IdlogOperatingSystemTypeNavigation { get; set; }
        public virtual Tables IdtableNavigation { get; set; }
    }
}
