using System;
using System.Collections.Generic;

#nullable disable

namespace KursiIm.Domain.KursiIm
{
    public partial class LogOperatingSystemType
    {
        public LogOperatingSystemType()
        {
            LogDataChanges = new HashSet<LogDataChange>();
            LogFailedAuthentications = new HashSet<LogFailedAuthentication>();
        }

        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime EntryDate { get; set; }
        public DateTime IdentryUser { get; set; }
        public DateTime EntryUser { get; set; }

        public virtual ICollection<LogDataChange> LogDataChanges { get; set; }
        public virtual ICollection<LogFailedAuthentication> LogFailedAuthentications { get; set; }
    }
}
