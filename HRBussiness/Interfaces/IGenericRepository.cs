using DAL;
using DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace HRBussiness
{
    public interface IGenericRepository<T, TID> where T : class,  ISoftDelete, IDateConstraint where TID : struct
    {
        IQueryable<T> GetAll();
        IQueryable<T> GetFilteredData(Expression<Func<T, bool>> expression, params string[] includes);
        IQueryable<T> GetFilteredData(Expression<Func<T, bool>> expression);
        T SingleOrDefault(Expression<Func<T, bool>> expression, params string[] includes);
        T SingleOrDefault(Expression<Func<T, bool>> expression);
        T FirstOrDefault(Expression<Func<T, bool>> expression, params string[] includes);
        T FirstOrDefault(Expression<Func<T, bool>> expression);
        T FirstOrDefaultAsNotracking(Expression<Func<T, bool>> expression);
        T FirstOrDefaultAsNotracking(Expression<Func<T, bool>> expression, string include);
        T GetById(TID _id);
        void Insert(T ent);
        void Update(T ent);
        void Delete(T ent);
    }
}
