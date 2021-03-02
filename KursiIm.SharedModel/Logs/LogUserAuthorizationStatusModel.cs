using System;
using System.Collections.Generic;
using System.Text;

namespace KursiIm.SharedModel.Logs
{
    public class LogUserAuthorizationStatusModel
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime EntryDate { get; set; }
        public int IdEntryUser { get; set; }
        public string EntryUser { get; set; }
    }
}
