using DAL.Models;
using HRBussiness;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArcelikLgHRWebTests.CalismaControllerTests
{
    class MockObjectWorkRep : IGenericRepository<WorkInformation, long>
    {
     
        List<WorkInformation> workInf;
        public MockObjectWorkRep()
        {           
            workInf = new List<WorkInformation>(){
                new WorkInformation(){ WorkID=1,IsStillWorking=true,UserInfoId=3,FireDateOfLastJob=new DateTime(1994,10,30)}
            };
        }
        public MockObjectWorkRep(List<WorkInformation> works)
        {
            this.workInf = works;
        }
        public IQueryable<WorkInformation> GetAll()
        {
            return workInf.AsQueryable();
        }

        public IQueryable<WorkInformation> GetFilteredData(System.Linq.Expressions.Expression<Func<WorkInformation, bool>> expression, params string[] includes)
        {
            return workInf.Where(expression.Compile()).AsQueryable();
        }

        public IQueryable<WorkInformation> GetFilteredData(System.Linq.Expressions.Expression<Func<WorkInformation, bool>> expression)
        {
            return workInf.Where(expression.Compile()).AsQueryable();
        }

        public WorkInformation SingleOrDefault(System.Linq.Expressions.Expression<Func<WorkInformation, bool>> expression, params string[] includes)
        {
            return workInf.SingleOrDefault(expression.Compile());
        }

        public WorkInformation SingleOrDefault(System.Linq.Expressions.Expression<Func<WorkInformation, bool>> expression)
        {
            return workInf.SingleOrDefault(expression.Compile());
        }

        public WorkInformation FirstOrDefault(System.Linq.Expressions.Expression<Func<WorkInformation, bool>> expression, params string[] includes)
        {
            return workInf.FirstOrDefault(expression.Compile());
        }

        public WorkInformation FirstOrDefault(System.Linq.Expressions.Expression<Func<WorkInformation, bool>> expression)
        {
            return workInf.FirstOrDefault(expression.Compile());
        }

        public WorkInformation FirstOrDefaultAsNotracking(System.Linq.Expressions.Expression<Func<WorkInformation, bool>> expression)
        {
            throw new NotImplementedException();
        }

        public WorkInformation FirstOrDefaultAsNotracking(System.Linq.Expressions.Expression<Func<WorkInformation, bool>> expression, string include)
        {
            throw new NotImplementedException();
        }

        public WorkInformation GetById(long _id)
        {
            throw new NotImplementedException();
        }

        public void Insert(WorkInformation ent)
        {
            ent.IsValid = true;
            ent.CreatedDate = DateTime.Now;
          
            workInf.Add(ent);
        }

        public void Update(WorkInformation ent)
        {
            var item = workInf.SingleOrDefault(x => x.WorkID == ent.WorkID);
            if (item!=null)
            {
                item.IsStillWorking = ent.IsStillWorking;
                item.FireDateOfLastJob = ent.FireDateOfLastJob;
                item.ModifiedDate = DateTime.Now;                                        
            }
        }

        public void Delete(WorkInformation ent)
        {
            throw new NotImplementedException();
        }
    }
}
