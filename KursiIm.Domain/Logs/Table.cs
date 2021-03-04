using System;
using System.Collections.Generic;

#nullable disable

namespace KursiIm.Domain.KursiIm
{
    public partial class Table
    {
        public Table()
        {
            LogDataChanges = new HashSet<LogDataChange>();
        }

        public int Id { get; set; }
        public string Title { get; set; }

        public virtual ICollection<LogDataChange> LogDataChanges { get; set; }
    }
}
