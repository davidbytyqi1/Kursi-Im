using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KursiIm.SharedModel.General
{
    public class Pagination<T> where T : class
    {
        public int Count { get; set; } = 1;
        public int PageSize { get; set; }
        public int Page { get; set; }
        public IList<T> Result { get; set; }

    }
}
