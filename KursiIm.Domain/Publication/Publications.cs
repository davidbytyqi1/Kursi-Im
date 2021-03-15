using KursiIm.Domain.Courses;
using KursiIm.Domain.KursiIm;
using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace KursiIm.Domain.Publication
{
    public partial class Publications
    {
        public Publications()
        {
            Messages = new HashSet<Messages>();
        }

        public int ID { get; set; }
        public int IDEntryUser { get; set; }
        public int? IDMunicipality { get; set; }
        public int? IDCategory { get; set; }
        public string Title { get; set; }
        public string Subtitle { get; set; }
        public string Description { get; set; }
        public string ImagePath { get; set; }
        public DateTime? InsertionDate { get; set; }
        public bool? IsActive { get; set; }
        public bool? HasPromotion { get; set; }
        public int? IDPromotionType { get; set; }
        public DateTime? PromotionEndDate { get; set; }
        public int? ViewCounts { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public decimal? Price { get; set; }
        public bool? HasPrice { get; set; }
        public int? Sale { get; set; }
        public string Latitude { get; set; }
        public string Longitude { get; set; }
        public int? AvailableStudentsNumber { get; set; }
        public int? VacanciesNumber { get; set; }

        public virtual Categories IDCategoryNavigation { get; set; }
        public virtual User IDEntryUserNavigation { get; set; }
        public virtual Municipality IDMunicipalityNavigation { get; set; }
        public virtual PromotionType IDPromotionTypeNavigation { get; set; }
        public virtual ICollection<Messages> Messages { get; set; }
    }
}
