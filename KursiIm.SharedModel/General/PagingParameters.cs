using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KursiIm.SharedModel.General
{
    public class PagingParameters
    {
        const int maxPageSize = 50;

        private int _pageSize = 10;

        public int PageSize
        {
            get
            {
                return _pageSize;
            }
            set
            {
                _pageSize = (value > maxPageSize) ? maxPageSize : value < 5 ? 10 : value;
            }
        }

        private int _page = 1;
        public int Page
        {
            get
            {
                return _page;
            }
            set
            {
                _page = value == 0 ? 1 : value;
            }
        }
    }
}
