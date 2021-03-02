using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KursiIm.Domain.SeedWork
{
    [Serializable]
    public class DeleteClass : BaseEntity
    {
        public bool IsDeleted { get; set; }
        public int? IDDeleteUser { get; set; }
        public DateTime? DeleteDate { get; set; }

    }
}
