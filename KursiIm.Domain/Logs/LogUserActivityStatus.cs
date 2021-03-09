using KursiIm.Domain.SeedWork;
using System;
using System.Collections.Generic;

#nullable disable

namespace KursiIm.Domain.KursiIm
{
    public partial class LogUserActivityStatus : BaseEntity, IEntryEntity
    {
        public LogUserActivityStatus()
        {
            LogUserActivity = new HashSet<LogUserActivity>();
        }

        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime EntryDate { get; set; }
        public int IDEntryUser { get; set; }
        public string EntryUser { get; set; }

        public virtual ICollection<LogUserActivity> LogUserActivity { get; set; }
    }
}
