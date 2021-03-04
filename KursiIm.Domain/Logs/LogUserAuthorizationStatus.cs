using System;
using System.Collections.Generic;

#nullable disable

namespace KursiIm.Domain.KursiIm
{
    public partial class LogUserAuthorizationStatus
    {
        public LogUserAuthorizationStatus()
        {
            LogUserAuthorizations = new HashSet<LogUserAuthorization>();
        }

        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime EntryDate { get; set; }
        public int IdentryUser { get; set; }
        public string EntryUser { get; set; }

        public virtual ICollection<LogUserAuthorization> LogUserAuthorizations { get; set; }
    }
}
