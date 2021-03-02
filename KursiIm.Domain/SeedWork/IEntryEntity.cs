using System;
using System.Collections.Generic;
using System.Text;

namespace KursiIm.Domain.SeedWork
{
    public interface IEntryEntity
    {
        int IdEntryUser { get; set; }
        string EntryUser { get; set; }
        DateTime EntryDate { get; set; }
    }
}
