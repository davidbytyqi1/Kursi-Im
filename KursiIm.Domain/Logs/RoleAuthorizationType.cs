using System;
using System.Collections.Generic;

#nullable disable

namespace KursiIm.Domain.KursiIm
{
    public partial class RoleAuthorizationType
    {
        public RoleAuthorizationType()
        {
            RoleAuthorization = new HashSet<RoleAuthorization>();
        }

        public int ID { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime EntryDate { get; set; }
        public int IDEntryUser { get; set; }
        public string EntryUser { get; set; }

        public virtual ICollection<RoleAuthorization> RoleAuthorization { get; set; }
    }
}
