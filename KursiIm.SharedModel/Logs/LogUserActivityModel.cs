using System;
using System.Collections.Generic;
using System.Text;

namespace KursiIm.SharedModel.Logs
{
    public class LogUserActivityModel : GeneralLogDataChange
    {
        public int? IDLogUserActivityStatus { get; set; }
        public string LogUserActivityStatus { get; set; }
        public string URL { get; set; }
        public bool? IsPublic { get; set; }
        public int? IDModule { get; set; }
        public string Module { get; set; }
    }
}
