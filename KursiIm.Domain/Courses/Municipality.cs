using System;
using System.Collections.Generic;
using KursiIm.Domain.Publication;
using KursiIm.Domain.SeedWork;
// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace KursiIm.Domain.Courses
{
    public partial class Municipality : BaseEntity
    {
        public Municipality()
        {
            Company = new HashSet<Company>();
            Publications = new HashSet<Publications>();
        }

        public int ID { get; set; }
        public string Title { get; set; }

        public virtual ICollection<Company> Company { get; set; }
        public virtual ICollection<Publications> Publications { get; set; }
    }
}
