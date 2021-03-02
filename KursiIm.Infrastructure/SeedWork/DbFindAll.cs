
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

using KursiIm.Infrastructure;
using KursiIm.Infrastructure.Logs;
using KursiIm.Domain.SeedWork;
using Microsoft.EntityFrameworkCore;

namespace KursiIm.Infrastructure.SeedWork
{
    public class DbFindAll<T> where T : BaseEntity
    {
        protected readonly KursiImContext _dbContext;

        public DbFindAll()
        {
            _dbContext = new KursiImContext();
        }

        public IQueryable<T> FindAll(Expression<Func<T, bool>> criteria, params string[] includes)
        {
            IQueryable<T> query = this._dbContext.Set<T>();
            if (includes != null)
            {
                int count = includes.Length;
                for (int index = 0; index < count; index++)
                {
                    query = query.Include(includes[index]);
                }
            }

            return query.Where(criteria);

        }

        public IQueryable<T> FindAll(Expression<Func<T, bool>> criteria, string direction = "asc", params string[] includes)
        {
            IQueryable<T> query = this._dbContext.Set<T>();
            if (includes != null)
            {
                int count = includes.Length;
                for (int index = 0; index < count; index++)
                {
                    query = query.Include(includes[index]);
                }
            }
            if (direction == "desc")
                return query.Where(criteria).OrderByDescending(_ => _.Id);

            return query.Where(criteria);
        }
    }
}
