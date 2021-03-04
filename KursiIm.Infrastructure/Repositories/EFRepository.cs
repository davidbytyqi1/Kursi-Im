using KursiIm.Domain.SeedWork;
using KursiIm.Infrastructure.KursiIm;
using KursiIm.Infrastructure.SeedWork;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace KursiIm.Infrastructure.Repositories
{
    public class EFRepository<T> : IRepository<T>, IAsyncRepository<T> where T : BaseEntity
    {
        protected readonly KursiImContext _dbContext;

        public EFRepository(KursiImContext dbContext)
        {
            _dbContext = dbContext;
        }

        public virtual T GetById(int id, params string[] includes)
        {
            IQueryable<T> query = _dbContext.Set<T>();

            if (includes != null)
            {
                int count = includes.Length;
                for (int index = 0; index < count; index++)
                {
                    query = query.Include(includes[index]);
                }
            }
            return query.FirstOrDefault(t => t.Id == id);
        }

        public T GetSingleBySpec(ISpecification<T> spec)
        {
            return List(spec).FirstOrDefault();
        }

        public virtual async Task<T> GetByIdAsync(int id, params string[] includes)
        {
            return await _dbContext.Set<T>().FindAsync(id);
        }

        public IEnumerable<T> ListAll(params string[] includes)
        {
            IQueryable<T> query = _dbContext.Set<T>();

            if (includes != null)
            {
                int count = includes.Length;
                for (int index = 0; index < count; index++)
                {
                    query = query.Include(includes[index]);
                }
            }

            return query.AsNoTracking().AsEnumerable();
        }

        public IQueryable<T> CreateQuery(params string[] includes)
        {
            IQueryable<T> query = _dbContext.Set<T>();

            if (includes != null)
            {
                int count = includes.Length;
                for (int index = 0; index < count; index++)
                {
                    query = query.Include(includes[index]);
                }
            }

            return query.AsNoTracking();
        }

        public T GetSingleByCriteria(Expression<Func<T, bool>> criteria)
        {
            return ListByCriteria(criteria).FirstOrDefault();
        }

        public T GetSingleByCriteria(Expression<Func<T, bool>> criteria, params string[] includes)
        {
            IQueryable<T> query = _dbContext.Set<T>();

            if (includes != null)
            {
                int count = includes.Length;
                for (int index = 0; index < count; index++)
                {
                    query = query.Include(includes[index]);
                }
            }

            return query.AsNoTracking().Where(criteria).FirstOrDefault();
        }

        public bool Any(Expression<Func<T, bool>> criteria)
        {
            IQueryable<T> query = _dbContext.Set<T>();
            return query.Any(criteria);
        }

        public async Task<List<T>> ListAllAsync()
        {
            return await _dbContext.Set<T>().AsNoTracking().ToListAsync();
        }

        public List<T> ListByCriteria(Expression<Func<T, bool>> criteria, params string[] includes)
        {
            IQueryable<T> query = _dbContext.Set<T>();

            if (includes != null)
            {
                int count = includes.Length;
                for (int index = 0; index < count; index++)
                {
                    query = query.Include(includes[index]);
                }
            }

            return query.AsNoTracking().Where(criteria).ToList();
        }

        public int CountByCriteria(Expression<Func<T, bool>> criteria)
        {
            IQueryable<T> query = _dbContext.Set<T>();
            return query.Where(criteria).Count();
        }

        public IEnumerable<T> List(ISpecification<T> spec)
        {
            var queryableResultWithIncludes = spec.Includes
                .Aggregate(_dbContext.Set<T>().AsQueryable(),
                    (current, include) => current.Include(include));

            var secondaryResult = spec.IncludeStrings
                .Aggregate(queryableResultWithIncludes,
                    (current, include) => current.Include(include));

            return secondaryResult.AsNoTracking()
                            .Where(spec.Criteria)
                            .AsEnumerable();
        }

        public async Task<List<T>> ListAsync(ISpecification<T> spec)
        {
            var queryableResultWithIncludes = spec.Includes
                .Aggregate(_dbContext.Set<T>().AsQueryable(),
                    (current, include) => current.Include(include));

            var secondaryResult = spec.IncludeStrings
                .Aggregate(queryableResultWithIncludes,
                    (current, include) => current.Include(include));

            return await secondaryResult.AsNoTracking()
                            .Where(spec.Criteria)
                            .ToListAsync();
        }

        public T Add(T entity)
        {
            _dbContext.Set<T>().Add(entity);
            _dbContext.SaveChanges();

            return entity;
        }


        public async Task<T> AddAsync(T entity)
        {
            _dbContext.Set<T>().Add(entity);
            await _dbContext.SaveChangesAsync();

            return entity;
        }

        public void Update(T entity)
        {
            _dbContext.Entry(entity).State = EntityState.Modified;
            _dbContext.SaveChanges();
        }

        public async Task UpdateAsync(T entity)
        {
            _dbContext.Entry(entity).State = EntityState.Modified;
            await _dbContext.SaveChangesAsync();
        }

        public void Delete(T entity)
        {
            _dbContext.Set<T>().Remove(entity);
            _dbContext.SaveChanges();
        }

        public async Task DeleteAsync(T entity)
        {
            _dbContext.Set<T>().Remove(entity);
            await _dbContext.SaveChangesAsync();
        }

        public Task<T> GetByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public virtual T GetLastEntity()
        {
            return _dbContext.Set<T>().OrderByDescending(t => t.Id).FirstOrDefault();
        }

        public void AddEntity(T entity)
        {
            _dbContext.Set<T>().Add(entity);
        }

        public void AddRange(IEnumerable<T> list)
        {
            _dbContext.Set<T>().AddRange(list);
        }

        public void Save()
        {
            _dbContext.SaveChanges();
        }

        public void DeleteRange(IEnumerable<T> entities)
        {
            _dbContext.Set<T>().RemoveRange(entities);
            _dbContext.SaveChanges();
        }

        public void UpdateRange(IEnumerable<T> entities)
        {
            _dbContext.Set<T>().UpdateRange(entities);
            _dbContext.SaveChanges();
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
    }
}
