using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace KursiIm.Domain.Publication
{
    public partial class Categories
    {
        public Categories()
        {
            Publications = new HashSet<Publications>();
        }

        public int ID { get; set; }
        public string Title { get; set; }

        public virtual ICollection<Publications> Publications { get; set; }
    }
}
