using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace KursiIm.Domain.Publication
{
    public partial class Subscribe
    {
        public int ID { get; set; }
        public int? IDCompany { get; set; }
        public string Email { get; set; }
        public DateTime? InsertionDate { get; set; }
    }
}
