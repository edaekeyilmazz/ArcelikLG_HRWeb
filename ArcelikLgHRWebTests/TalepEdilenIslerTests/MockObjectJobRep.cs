using DAL.Models;
using HRBussiness;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArcelikLgHRWebTests.TalepEdilenIslerTests
{
    class MockObjectJobRep:IGenericRepository<JobInformation,long>
    {
        List<JobInformation> jobInfo;
        public MockObjectJobRep()
        {
            jobInfo = new List<JobInformation>(){
                new JobInformation(){JobID=3,UserInfoId=3, RequestedJob1 ="Forklift Operatörü",RequestedJob2=string.Empty ,RequestedJob3=string.Empty }
            };
        }
        public MockObjectJobRep(List<JobInformation> job)
        {
            this.jobInfo = job;
        }
        public IQueryable<JobInformation> GetAll()
        {
            return jobInfo.AsQueryable();
        }
        public IQueryable<JobInformation> GetFilteredData(System.Linq.Expressions.Expression<Func<JobInformation, bool>> expression, params string[] includes)
        {
            return jobInfo.Where(expression.Compile()).AsQueryable();
        }

        public IQueryable<JobInformation> GetFilteredData(System.Linq.Expressions.Expression<Func<JobInformation, bool>> expression)
        {
            return jobInfo.Where(expression.Compile()).AsQueryable();
        }

        public JobInformation SingleOrDefault(System.Linq.Expressions.Expression<Func<JobInformation, bool>> expression, params string[] includes)
        {
            throw new NotImplementedException();
        }

        public JobInformation SingleOrDefault(System.Linq.Expressions.Expression<Func<JobInformation, bool>> expression)
        {
            return jobInfo.SingleOrDefault(expression.Compile());
        }

        public JobInformation FirstOrDefault(System.Linq.Expressions.Expression<Func<JobInformation, bool>> expression, params string[] includes)
        {
            return jobInfo.FirstOrDefault(expression.Compile());
        }

        public JobInformation FirstOrDefault(System.Linq.Expressions.Expression<Func<JobInformation, bool>> expression)
        {
            return jobInfo.FirstOrDefault(expression.Compile());
        }

        public JobInformation FirstOrDefaultAsNotracking(System.Linq.Expressions.Expression<Func<JobInformation, bool>> expression)
        {
            throw new NotImplementedException();
        }

        public JobInformation FirstOrDefaultAsNotracking(System.Linq.Expressions.Expression<Func<JobInformation, bool>> expression, string include)
        {
            throw new NotImplementedException();
        }

        public JobInformation GetById(long _id)
        {
            throw new NotImplementedException();
        }

        public void Insert(JobInformation ent)
        {
            ent.CreatedDate = DateTime.Now;
            ent.IsValid = true;
            jobInfo.Add(ent);
        }

        public void Update(JobInformation ent)
        {
            var item = jobInfo.SingleOrDefault(x => x.UserInfoId == ent.UserInfoId);
             if (item != null)
             {
                 item.RequestedJob1 = ent.RequestedJob1;
                 item.RequestedJob2 = ent.RequestedJob2;
                 item.RequestedJob3 = ent.RequestedJob3;
                 item.ModifiedDate = DateTime.Now;
                
             }
        }

        public void Delete(JobInformation ent)
        {
            ent.IsValid = false;
        }
    }
}
