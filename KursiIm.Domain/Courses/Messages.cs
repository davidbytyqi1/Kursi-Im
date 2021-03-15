using KursiIm.Domain.KursiIm;
using KursiIm.Domain.Publication;
using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace KursiIm.Domain.Courses
{
    public partial class Messages
    {
        public int ID { get; set; }
        public int? IDUser { get; set; }
        public int? IDCompany { get; set; }
        public int? IDPublication { get; set; }
        public string Email { get; set; }
        public string Message { get; set; }
        public DateTime? InsertionDate { get; set; }

        public virtual Company IDCompanyNavigation { get; set; }
        public virtual Publications IDPublicationNavigation { get; set; }
        public virtual User IDUserNavigation { get; set; }
    }
}
