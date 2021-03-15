using KursiIm.Domain.KursiIm;
using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace KursiIm.Domain.Courses
{
    public partial class CompanyDocuments
    {
        public int ID { get; set; }
        public int? IDCompany { get; set; }
        public string Name { get; set; }
        public string Path { get; set; }
        public bool? IsPrimary { get; set; }
        public int? IDEntryUser { get; set; }
        public DateTime? InsertionDate { get; set; }

        public virtual Company IDCompanyNavigation { get; set; }
        public virtual User IDEntryUserNavigation { get; set; }
    }
}
