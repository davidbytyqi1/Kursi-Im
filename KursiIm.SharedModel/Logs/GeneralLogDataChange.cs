using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KursiIm.SharedModel.Logs
{
    public class GeneralLogDataChange
    {
        public int Id { get; set; }
        public DateTime EntryDate { get; set; }
        public int IdEntryUser { get; set; }
        public string EntryUser { get; set; }
        public string ComputerName { get; set; }
        public string IpAddress { get; set; }
        public string LogBrowserType { get; set; }
        public string LogOperatingSystemType { get; set; }
        public bool IsMobileDevice { get; set; }
        public string LogDataChangeStatus { get; set; }

    }
}
