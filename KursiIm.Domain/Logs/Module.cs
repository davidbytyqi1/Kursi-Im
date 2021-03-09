using System;
using System.Collections.Generic;

#nullable disable

namespace KursiIm.Domain.KursiIm
{
    public partial class Module
    {
        public Module()
        {
            LogUserActivity = new HashSet<LogUserActivity>();
            RoleAuthorization = new HashSet<RoleAuthorization>();
        }

        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime EntryDate { get; set; }
        public int IdentryUser { get; set; }
        public string EntryUser { get; set; }
        public int? Idparent { get; set; }
        public bool? IsPublic { get; set; }

        public virtual ICollection<LogUserActivity> LogUserActivity { get; set; }
        public virtual ICollection<RoleAuthorization> RoleAuthorization { get; set; }
    }
}
