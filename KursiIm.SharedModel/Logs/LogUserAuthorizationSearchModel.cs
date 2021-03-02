using System;
using System.Collections.Generic;
using System.Text;
using KursiIm.SharedModel.General;

namespace KursiIm.SharedModel.Logs
{
    public class LogUserAuthorizationSearchModel : PagingParameters
    { 
        public int? IdUser { get; set; }
        public DateTime? EntryDate { get; set; }
        public int? IdEntryUser { get; set; }
        public string EntryUser { get; set; }
        public string ComputerName { get; set; }
        public string IpAddress { get; set; }
        public string LogBrowserType { get; set; }
        public int? IdLogUserAuthorizationStatus { get; set; }
        public string LogUserAuthorizationStatus { get; set; }
        public string LogOperatingSystemType { get; set; }
        public bool? IsMobileDevice { get; set; }
        public string LogDataChangeStatus { get; set; }
        public int? IdTable { get; set; }

    }

}
