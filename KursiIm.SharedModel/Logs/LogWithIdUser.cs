using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KursiIm.SharedModel.Logs
{
    public class LogWithIdUser : LogGeneralModel
    {
        public int IdUser { get; set; }
        public string EntryUser { get; set; }

    }
}
