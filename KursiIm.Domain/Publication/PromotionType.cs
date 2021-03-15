using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace KursiIm.Domain.Publication
{
    public partial class PromotionType
    {
        public PromotionType()
        {
            Publications = new HashSet<Publications>();
        }

        public int ID { get; set; }
        public string Title { get; set; }
        public decimal? Price { get; set; }
        public int? DurationDays { get; set; }
        public DateTime? InsertionDate { get; set; }
        public int? IDEntryUser { get; set; }
        public DateTime? LastModifiedDate { get; set; }
        public int? IDLastModifiedUser { get; set; }

        public virtual ICollection<Publications> Publications { get; set; }
    }
}
