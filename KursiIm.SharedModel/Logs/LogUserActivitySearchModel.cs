using System;
using System.Collections.Generic;
using System.Text;
using KursiIm.SharedModel.General;

namespace KursiIm.SharedModel.Logs
{
    public class LogUserActivitySearchModel : PagingParameters
    {
        public int? IdUser { get; set; }
        public string ComputerName { get; set; }
        public string IpAddress { get; set; }
        public string LogBrowserType { get; set; }
        public string LogOperatingSystemType { get; set; }
        public int? IdModule { get; set; }
        public string Module { get; set; }
        public bool? IsMobileDevice { get; set; }
        public bool? IsPublic { get; set; }
        public string URL { get; set; }
        public int? IdLogUserActivityStatus { get; set; }
        public string LogUserActivityStatus { get; set; }
        public string EntryUser { get; set; }
        public DateTime? EntryDate { get; set; }
    }
}
