using System;
using System.Collections.Generic;

#nullable disable

namespace KursiIm.Domain.KursiIm
{
    public partial class Role
    {
        public Role()
        {
            RoleAuthorizations = new HashSet<RoleAuthorization>();
        }

        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime EntryDate { get; set; }
        public int IdentryUser { get; set; }
        public string EntryUser { get; set; }
        public bool IsActive { get; set; }
        public DateTime? UpdateDate { get; set; }
        public int? IdupdateUser { get; set; }
        public string UpdateUser { get; set; }
        public bool WithPasswordPolicy { get; set; }
        public bool PasswordValidityDays { get; set; }

        public virtual ICollection<RoleAuthorization> RoleAuthorizations { get; set; }
    }
}
