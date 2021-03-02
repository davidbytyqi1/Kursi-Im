using System;
using System.Collections.Generic;
using System.Text;

namespace KursiIm.SharedModel.Logs
{
    public class LogFailedAuthenticationModel : GeneralLogDataChange
    {
        public int IdUser { get; set; }
        public string Account { get; set; }
    }
}
