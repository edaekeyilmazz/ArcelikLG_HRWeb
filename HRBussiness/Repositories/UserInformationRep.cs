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
    public class UserInformationRep  : IGenericRepository<UserInformation, long>
    {
        private readonly HRWebContext _hrContext;
        private readonly DbSet<UserInformation> _dbSet;
        public UserInformationRep(HRWebContext hrContext)
        {
            _hrContext = hrContext;
            _dbSet = hrContext.Set<UserInformation>();
        }
        public UserInformationRep()
        {
            _hrContext = new HRWebContext();
        }
        public void Delete(UserInformation ent)
        {
            _dbSet.Attach(ent);
            ent.IsValid = false;
            ent.ModifiedDate = DateTime.Now;
            _hrContext.Entry<UserInformation>(ent).State = EntityState.Modified;
        }

        public IQueryable<UserInformation> GetAll()
        {
            return _dbSet.Where(X => X.IsValid);
        }

        public UserInformation GetById(long _id)
        {
            return _dbSet.Find(_id);
        }

        public IQueryable<UserInformation> GetFilteredData(Expression<Func<UserInformation, bool>> expression, params string[] includes)
        {
            if (includes != null && includes.Length > 0)
                return _dbSet.Include(string.Join(",", includes)).Where(expression);
            return _dbSet.Where(expression);
        }

        public IQueryable<UserInformation> GetFilteredData(Expression<Func<UserInformation, bool>> expression)
        {
            return _dbSet.Where(expression);
        }

        public virtual void Insert(UserInformation ent)
        {
            ent.IsValid = true;
            ent.CreatedDate = DateTime.Now;
            _dbSet.Add(ent);
            _hrContext.Entry<UserInformation>(ent).State = EntityState.Added;
            ent.StatusType = (byte)(StatusTypes.Continue | StatusTypes.StepsCompleted);
            Transaction trn = new Transaction();
            trn.FromStepId = Helper.Steps["UserInformation"].ID;
            trn.ToStepId = Helper.NextSteps["UserInformation"].ID;
            trn.CreatedDate = DateTime.Now;
            trn.IsValid = true;
            _hrContext.Transaction.Add(trn);
            _hrContext.Entry<Transaction>(trn).State = EntityState.Added;
            ent.Transaction.Add(trn);
        }

        public virtual void Update(UserInformation ent)
        {
            ent.ModifiedDate = DateTime.Now;
            _dbSet.Attach(ent);
            _hrContext.Entry<UserInformation>(ent).State = EntityState.Modified;
        }

        public UserInformation FirstOrDefault(Expression<Func<UserInformation, bool>> expression, params string[] includes)
        {
            if (includes != null && includes.Length > 0)
                return _dbSet.Include(string.Join(",", includes)).FirstOrDefault(expression);
            return _dbSet.FirstOrDefault(expression);
        }

        public UserInformation FirstOrDefault(Expression<Func<UserInformation, bool>> expression)
        {
            return _dbSet.FirstOrDefault(expression);
        }

        public UserInformation SingleOrDefault(Expression<Func<UserInformation, bool>> expression, params string[] includes)
        {
            if (includes != null && includes.Length > 0)
                return _dbSet.Include(string.Join(",", includes)).SingleOrDefault(expression);
            return _dbSet.SingleOrDefault(expression);
        }

        public UserInformation SingleOrDefault(Expression<Func<UserInformation, bool>> expression)
        {
            return _dbSet.SingleOrDefault(expression);
        }

        public UserInformation FirstOrDefaultAsNotracking(Expression<Func<UserInformation, bool>> expression)
        {
            return _dbSet.AsNoTracking().FirstOrDefault(expression);
        }

        public UserInformation FirstOrDefaultAsNotracking(Expression<Func<UserInformation, bool>> expression, string include)
        {
            return _dbSet.AsNoTracking().Include(include).FirstOrDefault(expression);
        }

        public UserInformation Login(string tcNo, string password)
        {
            var user = _hrContext.UserInformation.FirstOrDefault(X => X.TCNo.Equals(tcNo) && X.Password.Equals(password));
            if (user != null) user.IsAuthenticatedUser = true;
            return user;
        }

        public bool CheckStep(long userId, long toStepId)
        {
            var result = _hrContext.Transaction.Where(X => X.UserID == userId).Include("ToStep").OrderByDescending(X => X.TransactionID);
            if (result != null)
            {
                NextStep = result.FirstOrDefault().ToStep;
                //return result.Any(X => X.ToStepId == toStepId);
                if (result.Any(X => X.ToStepId == toStepId))
                    return true;
                else if (result.Any(X => X.FromStepId == toStepId))
                    return true;
                return false;
            }
            return (Helper.NextSteps["UserInformation"].ID == toStepId);
        }

        public Step GetNextStep(long userId)
        {
            var result = _hrContext.Transaction.Where(X => X.UserID == userId).Include("ToStep").OrderByDescending(X => X.TransactionID).FirstOrDefault();
            if (result != null)
            {
                NextStep = result.ToStep;
                return result.ToStep;
            }
            return Helper.NextSteps["UserInformation"];
        }

        public Step NextStep { get; private set; }
        //public Step CurrentStep { get; private set; }


    }
}
