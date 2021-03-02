using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KursiIm.SharedModel.Logs
{
    public class LogDataChangeModel : GeneralLogDataChange
    {
        public object Before { get; set; }
        public object After { get; set; }
        public string Table { get; set; }
        public int IdTable { get; set; }
        public List<LogData> LogData { get; set; }

    }
}
