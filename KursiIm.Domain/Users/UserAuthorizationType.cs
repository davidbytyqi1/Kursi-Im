using KursiIm.Domain.SeedWork;
using System;
using System.Collections.Generic;

#nullable disable

namespace KursiIm.Domain.KursiIm
{
    [Serializable]
    public partial class UserAuthorizationType : BaseEntity, IEntryEntity
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime EntryDate { get; set; }
        public int IdentryUser { get; set; }
        public string EntryUser { get; set; }
        public virtual ICollection<User> User { get; set; }
    }
}
