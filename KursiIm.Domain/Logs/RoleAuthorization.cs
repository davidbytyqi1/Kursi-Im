using System;
using System.Collections.Generic;

#nullable disable

namespace KursiIm.Domain.KursiIm
{
    public partial class RoleAuthorization
    {
        public int Id { get; set; }
        public int Idrole { get; set; }
        public int IdroleAuthorizationType { get; set; }
        public int Idmodule { get; set; }
        public string EntryUser { get; set; }
        public DateTime EntryDate { get; set; }
        public int IdentryUser { get; set; }
        public DateTime? UpdateDate { get; set; }
        public int? IdupdateUser { get; set; }
        public string UpdateUser { get; set; }

        public virtual Module IdmoduleNavigation { get; set; }
        public virtual RoleAuthorizationType IdroleAuthorizationTypeNavigation { get; set; }
        public virtual Role IdroleNavigation { get; set; }
    }
}
