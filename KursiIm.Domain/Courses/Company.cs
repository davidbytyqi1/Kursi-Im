using KursiIm.Domain.KursiIm;
using KursiIm.Domain.SeedWork;
using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace KursiIm.Domain.Courses
{
    public partial class Company: DeleteClass
    {
        public Company()
        {
            CompanyDocuments = new HashSet<CompanyDocuments>();
            Messages = new HashSet<Messages>();
        }

        public int IDMunicipality { get; set; }
        public int IDEntryUser { get; set; }
        public string LegalName { get; set; }
        public string Subtitle { get; set; }
        public string Description { get; set; }
        public bool? IsActive { get; set; }
        public DateTime InsertionDate { get; set; }
        public DateTime? LastModifiedDate { get; set; }
        public int? IDLastModifiedUser { get; set; }
        public string PhoneNumber { get; set; }
        public string Website { get; set; }
        public string Email { get; set; }
        public string Facebook { get; set; }
        public string Instagram { get; set; }
        public string LinkedIn { get; set; }
        public string Address { get; set; }
        public string Latitude { get; set; }
        public string Longitude { get; set; }
        public int? TotalRate { get; set; }

        public virtual User IDEntryUserNavigation { get; set; }
        public virtual Municipality IDMunicipalityNavigation { get; set; }
        public virtual ICollection<CompanyDocuments> CompanyDocuments { get; set; }
        public virtual ICollection<Messages> Messages { get; set; }
    }
}
