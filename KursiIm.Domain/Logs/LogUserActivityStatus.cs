using System;
using System.Collections.Generic;

#nullable disable

namespace KursiIm.Domain.KursiIm
{
    public partial class LogUserActivityStatus
    {
        public LogUserActivityStatus()
        {
            LogUserActivities = new HashSet<LogUserActivity>();
        }

        public int Id { get; set; }
        public string Description { get; set; }
        public DateTime EntryDate { get; set; }
        public int IdentryUser { get; set; }
        public string EntryUser { get; set; }

        public virtual ICollection<LogUserActivity> LogUserActivities { get; set; }
    }
}
