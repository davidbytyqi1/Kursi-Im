using System;
using System.Collections.Generic;
using System.Text;

namespace KursiIm.SharedModel.Logs
{
    public class LogActivityModel
    {
        public int IdModule { get; set; }  
        public int ActivityStatus { get; set; }
        public string Host { get; set; }
        public bool IsPublic { get; set; }
    }
}
