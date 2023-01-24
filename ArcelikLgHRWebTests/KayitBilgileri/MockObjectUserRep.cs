using DAL.Models;
using HRBussiness;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArcelikLgHRWebTests
{
    class MockObjectUserRep : IGenericRepository<UserInformation, long>
    {
        List<UserInformation> userInfos;
        public MockObjectUserRep()
        {
            userInfos = new List<UserInformation>() {
                new UserInformation() { UserID = 1, TCNo = "43372950092", Name = "Barış", Surname = "Alkan", MobilePhone = "05323334455", Password = "1", Email = "baris.alkan@trinoks.com", IsValid=true,ContractStatus = true },
                new UserInformation() { UserID = 2, TCNo = "41380742470", Name = "Eda", Surname = "Ekiz", MobilePhone = "05323334455", Password = "1", Email = "eda.ekiz@trinoks.com", IsValid=true, ContractStatus = true}};
        }

        public MockObjectUserRep(List<UserInformation> usrInfos)
        {
            this.userInfos = usrInfos;
        }
        public IQueryable<UserInformation> GetAll()
        {
            return userInfos.AsQueryable();
        }

        public IQueryable<UserInformation> GetFilteredData(System.Linq.Expressions.Expression<Func<UserInformation, bool>> expression, params string[] includes)
        {
            return userInfos.Where(expression.Compile()).AsQueryable();
        }

        public IQueryable<UserInformation> GetFilteredData(System.Linq.Expressions.Expression<Func<UserInformation, bool>> expression)
        {
            return userInfos.Where(expression.Compile()).AsQueryable();
        }

        public UserInformation SingleOrDefault(System.Linq.Expressions.Expression<Func<UserInformation, bool>> expression, params string[] includes)
        {
            return userInfos.SingleOrDefault(expression.Compile());
        }

        public UserInformation SingleOrDefault(System.Linq.Expressions.Expression<Func<UserInformation, bool>> expression)
        {
            return userInfos.SingleOrDefault(expression.Compile());
        }

        public UserInformation FirstOrDefault(System.Linq.Expressions.Expression<Func<UserInformation, bool>> expression, params string[] includes)
        {
            return userInfos.FirstOrDefault(expression.Compile());
        }

        public UserInformation FirstOrDefault(System.Linq.Expressions.Expression<Func<UserInformation, bool>> expression)
        {
            return userInfos.FirstOrDefault(expression.Compile());
        }

        public UserInformation FirstOrDefaultAsNotracking(System.Linq.Expressions.Expression<Func<UserInformation, bool>> expression)
        {
            throw new NotImplementedException();
        }

        public UserInformation FirstOrDefaultAsNotracking(System.Linq.Expressions.Expression<Func<UserInformation, bool>> expression, string include)
        {
            throw new NotImplementedException();
        }

        public UserInformation GetById(long _id)
        {
            throw new NotImplementedException();
        }

        public void Insert(UserInformation ent)
        {
            ent.UserID = userInfos.Count + 1;
            ent.IsValid = true;
            ent.CreatedDate = DateTime.Now;
            if (userInfos.Any(X => X.TCNo.Equals(ent.TCNo))) throw new ArgumentException("Aynısı var!");
            userInfos.Add(ent);
        }

        public void Update(UserInformation ent)
        {
            /*1*/
            var item = userInfos.SingleOrDefault(x => x.UserID == ent.UserID);
            if (item != null)
            {
                item.ModifiedDate = DateTime.Now;
                item.TCNo = ent.TCNo;
                item.Name = ent.Name;
                item.Surname = ent.Surname;
                item.MobilePhone = ent.MobilePhone;
                item.Password = ent.Password;
                item.Email = ent.Email;
                item.ContractStatus = ent.ContractStatus;
            }

            //int ind = userInfos.FindIndex(x=>x.TCNo == ent.TCNo);

            //if (ind > -1)
            //    userInfos.RemoveAt(ind);
        }

        public void Delete(UserInformation ent)
        {
            //userInfos.Remove(ent);
            ent.IsValid = false;
        }
    }
}
