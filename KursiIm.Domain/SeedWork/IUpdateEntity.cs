
using System;
using System.Collections.Generic;
using System.Text;

namespace KursiIm.Domain.SeedWork
{
    public interface IUpdateEntity
    {
        public DateTime? UpdateDate { get; set; }
        public int? IDUpdateUser { get; set; }
        public string UpdateUser { get; set; }
    }
}
