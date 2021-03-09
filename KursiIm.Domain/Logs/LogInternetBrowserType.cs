using System;
using System.Collections.Generic;

#nullable disable

namespace KursiIm.Domain.KursiIm
{
    public partial class LogInternetBrowserType
    {
        public LogInternetBrowserType()
        {
            LogDataChange = new HashSet<LogDataChange>();
            LogFailedAuthentication = new HashSet<LogFailedAuthentication>();
            LogUserActivity = new HashSet<LogUserActivity>();
            LogUserAuthorization = new HashSet<LogUserAuthorization>();
        }

        public int ID { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime EntryDate { get; set; }
        public int IDEntryUser { get; set; }
        public string EntryUser { get; set; }

        public virtual ICollection<LogDataChange> LogDataChange { get; set; }
        public virtual ICollection<LogFailedAuthentication> LogFailedAuthentication { get; set; }
        public virtual ICollection<LogUserActivity> LogUserActivity { get; set; }
        public virtual ICollection<LogUserAuthorization> LogUserAuthorization { get; set; }
    }
}
