using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KursiIm.SharedModel.Logs
{
    public class LogWithIdEntryUser : LogGeneralModel
    {
        public int IdEntryUser { get; set; }
        public string EntryUser { get; set; }
    }
}
