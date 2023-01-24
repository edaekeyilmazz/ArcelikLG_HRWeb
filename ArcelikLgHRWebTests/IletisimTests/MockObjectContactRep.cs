using DAL.Models;
using HRBussiness;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArcelikLgHRWebTests.IletisimControllerTests
{
    class MockObjectContactRep : IGenericRepository<ContactInformation, long>
    {
        List<ContactInformation> contactInfo;
        public MockObjectContactRep()
        {
            contactInfo = new List<ContactInformation>() { new ContactInformation() { UserInfoId = 1, ContactID=3, HomeAddress = string.Empty, ProvinceOfHomeAddress = "İstanbul", TownOfHomeAddress = "Ataşehir", HomePhone = null } };
        }
        public MockObjectContactRep(List<ContactInformation> contacts)
        {
            this.contactInfo = contacts;
        }
        public IQueryable<ContactInformation> GetAll()
        {
            return contactInfo.AsQueryable();
        }

        public IQueryable<ContactInformation> GetFilteredData(System.Linq.Expressions.Expression<Func<ContactInformation, bool>> expression, params string[] includes)
        {
            return contactInfo.Where(expression.Compile()).AsQueryable();
        }

        public IQueryable<ContactInformation> GetFilteredData(System.Linq.Expressions.Expression<Func<ContactInformation, bool>> expression)
        {
            return contactInfo.Where(expression.Compile()).AsQueryable();
        }

        public ContactInformation SingleOrDefault(System.Linq.Expressions.Expression<Func<ContactInformation, bool>> expression, params string[] includes)
        {
            return contactInfo.SingleOrDefault(expression.Compile());
        }

        public ContactInformation SingleOrDefault(System.Linq.Expressions.Expression<Func<ContactInformation, bool>> expression)
        {
            return contactInfo.SingleOrDefault(expression.Compile());
        }

        public ContactInformation FirstOrDefault(System.Linq.Expressions.Expression<Func<ContactInformation, bool>> expression, params string[] includes)
        {
            throw new NotImplementedException();
        }

        public ContactInformation FirstOrDefault(System.Linq.Expressions.Expression<Func<ContactInformation, bool>> expression)
        {
            return contactInfo.FirstOrDefault(expression.Compile());
        }

        public ContactInformation FirstOrDefaultAsNotracking(System.Linq.Expressions.Expression<Func<ContactInformation, bool>> expression)
        {
            return contactInfo.FirstOrDefault(expression.Compile());
        }

        public ContactInformation FirstOrDefaultAsNotracking(System.Linq.Expressions.Expression<Func<ContactInformation, bool>> expression, string include)
        {
            throw new NotImplementedException();
        }

        public ContactInformation GetById(long _id)
        {
            throw new NotImplementedException();
        }

        public void Insert(ContactInformation ent)
        {
            ent.IsValid = true;
            ent.CreatedDate = DateTime.Now;
            contactInfo.Add(ent);    
            
        }

        public void Update(ContactInformation ent)
        {
            var item = contactInfo.SingleOrDefault(x => x.ContactID == ent.ContactID);
            if (item != null)
            {
                item.HomeAddress = ent.HomeAddress;
                item.HomePhone = ent.HomePhone;
                item.ProvinceOfHomeAddress = ent.ProvinceOfHomeAddress;
                item.TownOfHomeAddress = ent.TownOfHomeAddress;
                item.ModifiedDate = DateTime.Now;
            }
        }

        public void Delete(ContactInformation ent)
        {
            ent.IsValid = false;
        }
    }
}
