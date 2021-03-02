using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KursiIm.SharedModel.Logs
{
    public class LogGeneralModel
    {
        public int Id { get; set; }
        public DateTime EntryDate { get; set; }
        public string ComputerName { get; set; }
        public string IPAddress { get; set; }
        public int IdLogBrowserType { get; set; }
        public int IdLogOperationSystemType { get; set; }
        public bool IsMobileDevice { get; set; }
        public int IdLogUserAuthorizationStatus { get; set; }
    }
}
