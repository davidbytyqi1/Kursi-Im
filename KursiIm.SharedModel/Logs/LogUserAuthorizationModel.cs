using System;
using System.Collections.Generic;
using System.Text;

namespace KursiIm.SharedModel.Logs
{
    public class LogUserAuthorizationModel : GeneralLogDataChange
    {
        public int IdUser { get; set; }
        public string LogUserAuthorizationStatus { get; set; }

    }
}
