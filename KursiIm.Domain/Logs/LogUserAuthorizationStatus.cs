using KursiIm.Domain.SeedWork;
using System;
using System.Collections.Generic;

#nullable disable

namespace KursiIm.Domain.KursiIm
{
    public partial class LogUserAuthorizationStatus : BaseEntity, IEntryEntity
    {
        public LogUserAuthorizationStatus()
        {
            LogUserAuthorization = new HashSet<LogUserAuthorization>();
        }

       // public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime EntryDate { get; set; }
        public int IdentryUser { get; set; }
       // public int IdEntryUser { get; set; }
        public string EntryUser { get; set; }

        public virtual ICollection<LogUserAuthorization> LogUserAuthorization { get; set; }
    }
}
