using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
using DAL.Models;
using System.Data.Entity;
using System.Linq.Expressions;

namespace HRBussiness
{
    public class StepRep : IGenericRepository<Step, long>
    {
        public UserInformation User { get; set; }
       private readonly HRWebContext _hrContext;
        private readonly DbSet<Step> _dbSet;
        public StepRep(HRWebContext hrContext)
        {
            _hrContext = hrContext;
            _dbSet = hrContext.Set<Step>();
        }

        public void Insert(Step ent)
        {
            if (User != null)
            {
                Transaction trnObj = new Transaction() { CreatedDate = DateTime.Now, IsValid = true, UserID = User.UserID, UserInformation = User };
                trnObj.UserInformation = User;
                trnObj.FromStepId = ent.ID;
                trnObj.ToStepId = Helper.NextSteps[ent.StepName].ID;
                try
                {
                    if (HRServiceLayer.ServiceHelper.ServiceHelperInstance.SendInformationToSAP(new Dictionary<string, string>()))
                        trnObj.UserInformation.StatusType = (byte)StatusTypes.AllProccessFinished;
                }
                catch (Exception ex)
                {
                    trnObj.UserInformation.StatusType = (byte)(StatusTypes.StepsCompleted | StatusTypes.WaitingForSAP);
                    _hrContext.Entry<UserInformation>(trnObj.UserInformation).State = System.Data.Entity.EntityState.Modified;
                    throw new ArgumentException("SAP Transfer Exception", ex);
                }
                finally
                {
                    _hrContext.Transaction.Add(trnObj);
                }

            }
        }


         
        public void Delete(Step ent)
        {
            ent.IsValid = false;
            _hrContext.Entry<Step>(ent).State = EntityState.Modified;
        }

        public IQueryable<Step> GetAll()
        {
            return _dbSet.Where(X => X.IsValid);
        }

        public Step GetById(long _id)
        {
            return _dbSet.Find(_id);
        }

        public IQueryable<Step> GetFilteredData(Expression<Func<Step, bool>> expression, params string[] includes)
        {
            if (includes != null && includes.Length > 0)
                return _dbSet.Include(string.Join(",", includes)).Where(expression);
            return _dbSet.Where(expression);
        }

        public IQueryable<Step> GetFilteredData(Expression<Func<Step, bool>> expression)
        {
            return _dbSet.Where(expression);
        }

        public virtual void Update(Step ent)
        {
            _hrContext.Entry<Step>(ent).State = EntityState.Modified;
        }

        public Step FirstOrDefault(Expression<Func<Step, bool>> expression, params string[] includes)
        {
            if (includes != null && includes.Length > 0)
                return _dbSet.Include(string.Join(",", includes)).FirstOrDefault(expression);
            return _dbSet.FirstOrDefault(expression);
        }

        public Step FirstOrDefault(Expression<Func<Step, bool>> expression)
        {
            return _dbSet.FirstOrDefault(expression);//_dbSet.AsNoTracking().FirstOrDefault(expression);
        }
        public Step FirstOrDefaultAsNotracking(Expression<Func<Step, bool>> expression)
        {
            return _dbSet.AsNoTracking().FirstOrDefault(expression);
        }
        public Step FirstOrDefaultAsNotracking(Expression<Func<Step, bool>> expression, string include)
        {
            return _dbSet.Include(include).AsNoTracking().FirstOrDefault(expression);
        }

        public Step SingleOrDefault(Expression<Func<Step, bool>> expression, params string[] includes)
        {
            if (includes != null && includes.Length > 0)
                return _dbSet.Include(string.Join(",", includes)).SingleOrDefault(expression);
            return _dbSet.SingleOrDefault(expression);
        }

        public Step SingleOrDefault(Expression<Func<Step, bool>> expression)
        {
            return _dbSet.SingleOrDefault(expression);
        }
    }
}
