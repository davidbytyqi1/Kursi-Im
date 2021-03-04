using System;
using System.Collections.Generic;

#nullable disable

namespace KursiIm.Domain.KursiIm
{
    public partial class LogDataChangeStatus
    {
        public LogDataChangeStatus()
        {
            LogDataChanges = new HashSet<LogDataChange>();
        }

        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime EntryDate { get; set; }
        public int IdentryUser { get; set; }
        public string EntryUser { get; set; }

        public virtual ICollection<LogDataChange> LogDataChanges { get; set; }
    }
}
