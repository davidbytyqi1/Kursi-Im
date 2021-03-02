using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Data;
using System.Threading.Tasks;

namespace KursiIm.Business
{
	public class PagedList<T> : List<T>
	{
		public int CurrentPage { get; private set; }
		public int TotalPages { get; private set; }
		public int PageSize { get; private set; }
		public int TotalCount { get; private set; }

		public bool HasPrevious => CurrentPage > 1;
		public bool HasNext => CurrentPage < TotalPages;

		public PagedList(List<T> items, int count, int pageNumber, int pageSize)
		{
			TotalCount = count;
			PageSize = pageSize;
			CurrentPage = pageNumber > 0 ? pageNumber : 1;
			TotalPages = (int)Math.Ceiling(count / (double)pageSize);

			AddRange(items);
		}

		public static PagedList<T> ToPagedList(IQueryable<T> source, int pageNumber, int pageSize)
		{
			var count = source.Count();
			var items = source.Skip((pageNumber - 1) * pageSize).Take(pageSize).ToList();

			return new PagedList<T>(items, count, pageNumber, pageSize);
		}


		public static PagedList<T> ToPagedList(IQueryable<T> source, int pageNumber, int pageSize, string sortColumn, string sortDirection)
		{
			var sortedItems = source;
			if (!string.IsNullOrWhiteSpace(sortColumn))
			{
				var fUpperSortColumn = char.ToUpper(sortColumn[0]) + sortColumn.Substring(1);
                sortedItems = source.OrderBy(fUpperSortColumn + " " + sortDirection.ToUpper()); 
            }
			var count = source.Count();
			var items = sortedItems.Skip((pageNumber - 1) * pageSize).Take(pageSize).ToList();

			return new PagedList<T>(items, count, pageNumber, pageSize);
		}
	}
}
