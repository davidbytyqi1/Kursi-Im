using System;
using System.Collections.Generic;
using System.Text;

namespace KursiIm.Domain.SeedWork
{
    public interface IEntryEntity
    {
        int IdentryUser { get; set; }
        string EntryUser { get; set; }
        DateTime EntryDate { get; set; }
    }
}
