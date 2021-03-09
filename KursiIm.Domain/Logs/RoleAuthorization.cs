using System;
using System.Collections.Generic;

#nullable disable

namespace KursiIm.Domain.KursiIm
{
    public partial class RoleAuthorization
    {
        public int ID { get; set; }
        public int IDRole { get; set; }
        public int IDRoleAuthorizationType { get; set; }
        public int IDModule { get; set; }
        public string EntryUser { get; set; }
        public DateTime EntryDate { get; set; }
        public int IDEntryUser { get; set; }
        public DateTime? UpdateDate { get; set; }
        public int? IDUpdateUser { get; set; }
        public string UpdateUser { get; set; }

        public virtual Module IDModuleNavigation { get; set; }
        public virtual RoleAuthorizationType IDRoleAuthorizationTypeNavigation { get; set; }
        public virtual Role IDRoleNavigation { get; set; }
    }
}
