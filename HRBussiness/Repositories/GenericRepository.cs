using DAL;
using DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Linq.Expressions;
using System.Data.Entity;

namespace HRBussiness
{
    public class GenericRepository<T, TID> : IGenericRepository<T, TID>
        where T : class, ISoftDelete, IDateConstraint, IStepable
        where TID : struct
    {
        protected readonly HRWebContext _hrContext;
        protected readonly DbSet<T> _dbSet;
        public GenericRepository(HRWebContext hrContext)
        {
            _hrContext = hrContext;
            _dbSet = hrContext.Set<T>();
        }
        public void Delete(T ent)
        {
            //_dbSet.Attach(ent);
            ent.IsValid = false;
            ent.ModifiedDate = DateTime.Now;
            _hrContext.Entry<T>(ent).State = EntityState.Modified;
        }

        public IQueryable<T> GetAll()
        {
            return _dbSet.Where(X => X.IsValid);
        }

        public T GetById(TID _id)
        {
            return _dbSet.Find(_id);
        }

        public IQueryable<T> GetFilteredData(Expression<Func<T, bool>> expression, params string[] includes)
        {
            if (includes != null && includes.Length > 0)
                return _dbSet.Include(string.Join(",", includes)).Where(expression);
            return _dbSet.Where(expression);
        }

        public IQueryable<T> GetFilteredData(Expression<Func<T, bool>> expression)
        {
            return _dbSet.Where(expression);
        }

        public virtual void Insert(T ent)
        {
            ent.IsValid = true;
            ent.CreatedDate = DateTime.Now;
            //_dbSet.Add(ent);
            _hrContext.Entry<T>(ent).State = EntityState.Added;
            Transaction trn = Helper.GetStep(ent, _hrContext);
            _hrContext.Transaction.Add(trn);
            _hrContext.Entry<Transaction>(trn).State = EntityState.Added;
        }

        public virtual void Update(T ent)
        {
            ent.ModifiedDate = DateTime.Now;
            //_dbSet.Attach(ent);
            _hrContext.Entry<T>(ent).State = EntityState.Modified;

        }

        //public virtual void UpdateAsNoTracking(T ent)
        //{
        //    //_dbSet.Attach(ent);
        //    _hrContext.Entry<T>(ent).State = EntityState.Detached;
        //    ent.ModifiedDate = DateTime.Now;
        //}

        public T FirstOrDefault(Expression<Func<T, bool>> expression, params string[] includes)
        {
            if (includes != null && includes.Length > 0)
                return _dbSet.Include(string.Join(",", includes)).FirstOrDefault(expression);
            return _dbSet.FirstOrDefault(expression);
        }

        public T FirstOrDefault(Expression<Func<T, bool>> expression)
        {
            return _dbSet.FirstOrDefault(expression);//_dbSet.AsNoTracking().FirstOrDefault(expression);
        }
        public T FirstOrDefaultAsNotracking(Expression<Func<T, bool>> expression)
        {
            return _dbSet.AsNoTracking().FirstOrDefault(expression);
        }
        public T FirstOrDefaultAsNotracking(Expression<Func<T, bool>> expression, string include)
        {
            return _dbSet.Include(include) .AsNoTracking().FirstOrDefault(expression);
        }

        public T SingleOrDefault(Expression<Func<T, bool>> expression, params string[] includes)
        {
            if (includes != null && includes.Length > 0)
                return _dbSet.Include(string.Join(",", includes)).SingleOrDefault(expression);
            return _dbSet.SingleOrDefault(expression);
        }

        public T SingleOrDefault(Expression<Func<T, bool>> expression)
        {
            return _dbSet.SingleOrDefault(expression);
        }

    }

}
