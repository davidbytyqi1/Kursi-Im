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
        public int IDEntryUser { get; set; }
        public string EntryUser { get; set; }
        public byte[] Before { get; set; }
        public byte[] After { get; set; }
        public string ComputerName { get; set; }
        public string IDAddress { get; set; }
        public int IDLogBrowserType { get; set; }
        public int IDLogOperatingSystemType { get; set; }
        public bool IsMobileDevice { get; set; }
        public int IDLogDataChangeStatus { get; set; }
        public int IDTable { get; set; }

        public virtual LogInternetBrowserType IDLogBrowserTypeNavigation { get; set; }
        public virtual LogDataChangeStatus IDLogDataChangeStatusNavigation { get; set; }
        public virtual LogOperatingSystemType IDLogOperatingSystemTypeNavigation { get; set; }
        public virtual Tables IDTableNavigation { get; set; }
    }
}
