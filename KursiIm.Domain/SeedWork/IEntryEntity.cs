using System;
using System.Collections.Generic;
using System.Text;

namespace KursiIm.Domain.SeedWork
{
    public interface IEntryEntity
    {
        public DateTime EntryDate { get; set; }
        public int IDEntryUser { get; set; }
        public string EntryUser { get; set; }
    }
}
