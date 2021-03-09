using KursiIm.Domain.SeedWork;
using System;
using System.Collections.Generic;

#nullable disable

namespace KursiIm.Domain.KursiIm
{
    public partial class Tables : BaseEntity
    {
        public Tables()
        {
            LogDataChange = new HashSet<LogDataChange>();
        }

       // public int Id { get; set; }
        public string Title { get; set; }

        public virtual ICollection<LogDataChange> LogDataChange { get; set; }
    }
}
