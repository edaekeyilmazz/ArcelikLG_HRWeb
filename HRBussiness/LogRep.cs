using DAL;
using DAL.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace HRBussiness
{
    public class LogRep : IGenericRepository<Log, long>
    {
        private readonly HRWebContext _hrContext;
        private readonly DbSet<Log> _dbSet;
        public LogRep(HRWebContext hrContext)
        {
            _hrContext = hrContext;
            _dbSet = hrContext.Set<Log>();
        }
        public void Delete(Log ent)
        {
            //_dbSet.Attach(ent);
            ent.IsValid = false;
            ent.ModifiedDate = DateTime.Now;
            _hrContext.Entry<Log>(ent).State = EntityState.Modified;
        }

        public IQueryable<Log> GetAll()
        {
            return _dbSet.Where(X => X.IsValid);
        }

        public Log GetById(long _id)
        {
            return _dbSet.Find(_id);
        }

        public IQueryable<Log> GetFilteredData(Expression<Func<Log, bool>> expression, params string[] includes)
        {
            if (includes != null && includes.Length > 0)
                return _dbSet.Include(string.Join(",", includes)).Where(expression);
            return _dbSet.Where(expression);
        }

        public IQueryable<Log> GetFilteredData(Expression<Func<Log, bool>> expression)
        {
            return _dbSet.Where(expression);
        }

        public virtual void Insert(Log ent)
        {
            ent.IsValid = true;
            ent.CreatedDate = DateTime.Now;
            _hrContext.Entry<Log>(ent).State = EntityState.Added;
        }

        public virtual void Update(Log ent)
        {
            ent.ModifiedDate = DateTime.Now;
            _hrContext.Entry<Log>(ent).State = EntityState.Modified;

        }

        //public virtual void UpdateAsNoTracking(Log ent)
        //{
        //    _hrContext.Entry<Log>(ent).State = EntityState.Detached;
        //    ent.ModifiedDate = DateTime.Now;
        //}

        public Log FirstOrDefault(Expression<Func<Log, bool>> expression, params string[] includes)
        {
            if (includes != null && includes.Length > 0)
                return _dbSet.Include(string.Join(",", includes)).FirstOrDefault(expression);
            return _dbSet.FirstOrDefault(expression);
        }

        public Log FirstOrDefault(Expression<Func<Log, bool>> expression)
        {
            return _dbSet.FirstOrDefault(expression);//_dbSet.AsNoTracking().FirstOrDefault(expression);
        }
        public Log FirstOrDefaultAsNotracking(Expression<Func<Log, bool>> expression)
        {
            return _dbSet.AsNoTracking().FirstOrDefault(expression);
        }
        public Log FirstOrDefaultAsNotracking(Expression<Func<Log, bool>> expression, string include)
        {
            return _dbSet.Include(include).AsNoTracking().FirstOrDefault(expression);
        }

        public Log SingleOrDefault(Expression<Func<Log, bool>> expression, params string[] includes)
        {
            if (includes != null && includes.Length > 0)
                return _dbSet.Include(string.Join(",", includes)).SingleOrDefault(expression);
            return _dbSet.SingleOrDefault(expression);
        }

        public Log SingleOrDefault(Expression<Func<Log, bool>> expression)
        {
            return _dbSet.SingleOrDefault(expression);
        }
    }
}
