using DAL.Models;
using HRBussiness;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArcelikLgHRWebTests.KisiselBilgiler
{
    public class MockObjectPersonalRep : IGenericRepository<PersonalInformation, long>
    {
        List<PersonalInformation> personalInfos;
        public MockObjectPersonalRep()
        {
            personalInfos = new List<PersonalInformation>() {
                new PersonalInformation() { 
                   PersonalID=1,
                   ModifiedDate = DateTime.Now,
                   SgkNumber = "1234567891011",
                   MotherName = "Test",
                   FatherName = "Test",
                   Gender = "Kadın",
                   BirthDate = new DateTime(1994,10,30),
                   BirthPlace = "MALATYA",
                   Education = "Lise (kolej) Mezunu",
                   WorkBeforeArcelikLg = false,
                   Overtime = false,
                   NightShift = false,
                   MilitaryStatus = "Muaf",
                   DefermentDate = null,
                   Nationality = "ALMANYA",
                   ProfessionalJob = "Bilgisayar Mühendisliği",
                   IsValid=true
                }};
        }
        public MockObjectPersonalRep(List<PersonalInformation> _personalInfos)
        {
            this.personalInfos = _personalInfos;
        }
        public IQueryable<PersonalInformation> GetAll()
        {
            return personalInfos.AsQueryable();
        }

        public IQueryable<PersonalInformation> GetFilteredData(System.Linq.Expressions.Expression<Func<PersonalInformation, bool>> expression, params string[] includes)
        {
            return personalInfos.Where(expression.Compile()).AsQueryable();
        }

        public IQueryable<PersonalInformation> GetFilteredData(System.Linq.Expressions.Expression<Func<PersonalInformation, bool>> expression)
        {
            return personalInfos.Where(expression.Compile()).AsQueryable();
        }

        public PersonalInformation SingleOrDefault(System.Linq.Expressions.Expression<Func<PersonalInformation, bool>> expression, params string[] includes)
        {
            return personalInfos.SingleOrDefault(expression.Compile());
        }

        public PersonalInformation SingleOrDefault(System.Linq.Expressions.Expression<Func<PersonalInformation, bool>> expression)
        {
            return personalInfos.SingleOrDefault(expression.Compile());
        }

        public PersonalInformation FirstOrDefault(System.Linq.Expressions.Expression<Func<PersonalInformation, bool>> expression, params string[] includes)
        {
            return personalInfos.FirstOrDefault(expression.Compile());
        }

        public PersonalInformation FirstOrDefault(System.Linq.Expressions.Expression<Func<PersonalInformation, bool>> expression)
        {
            return personalInfos.FirstOrDefault(expression.Compile());
        }

        public PersonalInformation FirstOrDefaultAsNotracking(System.Linq.Expressions.Expression<Func<PersonalInformation, bool>> expression)
        {
            throw new NotImplementedException();
        }

        public PersonalInformation FirstOrDefaultAsNotracking(System.Linq.Expressions.Expression<Func<PersonalInformation, bool>> expression, string include)
        {
            throw new NotImplementedException();
        }

        public PersonalInformation GetById(long _id)
        {
            throw new NotImplementedException();
        }

        public void Insert(PersonalInformation ent)
        {
            ent.PersonalID = personalInfos.Count + 1;
            ent.IsValid = true;
            ent.CreatedDate = DateTime.Now;
            if (personalInfos.Any(X => X.UserInfoId.Equals(ent.UserInfoId))) throw new ArgumentException("Eklemeye çalıştığınız kullanıcıya ait kişisel bilgiler sistemde kayıtlı!");
            personalInfos.Add(ent);
        }

        public void Update(PersonalInformation ent)
        {
            var personal = this.FirstOrDefault(x => x.UserInfoId == 1);
            var item = personalInfos.SingleOrDefault(x => x.UserInfoId == ent.UserInfoId);
            if (item != null)
            {
                item.ModifiedDate = DateTime.Now;
                item.SgkNumber = ent.SgkNumber;
                item.MotherName = ent.MotherName;
                item.FatherName = ent.FatherName;
                item.Gender = ent.Gender;
                item.BirthDate = ent.BirthDate;
                item.BirthPlace = ent.BirthPlace;
                item.Education = ent.Education;
                item.WorkBeforeArcelikLg = ent.WorkBeforeArcelikLg;
                item.Overtime = ent.Overtime;
                item.NightShift = ent.NightShift;
                item.MilitaryStatus = ent.MilitaryStatus;
                item.DefermentDate = ent.DefermentDate;
                item.Nationality = ent.Nationality;
                item.ProfessionalJob = ent.ProfessionalJob;
            }
        }

        public void Delete(PersonalInformation ent)
        {
            throw new NotImplementedException();
        }
    }
}
