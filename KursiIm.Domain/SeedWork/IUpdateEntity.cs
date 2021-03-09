
using System;
using System.Collections.Generic;
using System.Text;

namespace KursiIm.Domain.SeedWork
{
    public interface IUpdateEntity
    {
        int? IdupdateUser { get; set; }
        string UpdateUser { get; set; }
        DateTime? UpdateDate { get; set; }
    }
}
