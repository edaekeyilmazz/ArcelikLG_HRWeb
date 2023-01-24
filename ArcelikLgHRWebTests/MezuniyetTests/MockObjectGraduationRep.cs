using DAL.Models;
using HRBussiness;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArcelikLgHRWebTests.MezuniyetControllerTests
{
    class MockObjectGraduationRep:IGenericRepository<GraduationInformation,long>
    {
        List<GraduationInformation> graduationInfo;
        public MockObjectGraduationRep()
        {
            graduationInfo = new List<GraduationInformation>(){
                new GraduationInformation(){HighSchoolName="HYL",HighSchoolDiplomaDegree="3.50",HighSchoolDepartment="Fen",HighSchoolProvince="İstanbul",HighSchoolGraduationYear="2011",HighSchoolType="Meslek Lisesi", UniversityName="Kocaeli Üniversitesi",UniversityDiplomaDegree="2.50",UniversityGraduationYear="2016",UniversityProvince="Kocaeli",OtherUniversityName=string.Empty,MYOName="Bilgisayar",DepartmentName="Matematik",UserInfoId=3,GraduateID=3}
            };
        }
        public MockObjectGraduationRep(List<GraduationInformation> graduate)
        {
            this.graduationInfo = graduate;
        }
        public IQueryable<GraduationInformation> GetAll()
        {
            return graduationInfo.AsQueryable();
        }

        public IQueryable<GraduationInformation> GetFilteredData(System.Linq.Expressions.Expression<Func<GraduationInformation, bool>> expression, params string[] includes)
        {
            return graduationInfo.Where(expression.Compile()).AsQueryable();
        }

        public IQueryable<GraduationInformation> GetFilteredData(System.Linq.Expressions.Expression<Func<GraduationInformation, bool>> expression)
        {
            return graduationInfo.Where(expression.Compile()).AsQueryable();
        }

        public GraduationInformation SingleOrDefault(System.Linq.Expressions.Expression<Func<GraduationInformation, bool>> expression, params string[] includes)
        {
            return graduationInfo.SingleOrDefault(expression.Compile());
        }

        public GraduationInformation SingleOrDefault(System.Linq.Expressions.Expression<Func<GraduationInformation, bool>> expression)
        {
            return graduationInfo.SingleOrDefault(expression.Compile());
        }

        public GraduationInformation FirstOrDefault(System.Linq.Expressions.Expression<Func<GraduationInformation, bool>> expression, params string[] includes)
        {
            return graduationInfo.FirstOrDefault(expression.Compile());
        }

        public GraduationInformation FirstOrDefault(System.Linq.Expressions.Expression<Func<GraduationInformation, bool>> expression)
        {
            return graduationInfo.FirstOrDefault(expression.Compile());
        }

        public GraduationInformation FirstOrDefaultAsNotracking(System.Linq.Expressions.Expression<Func<GraduationInformation, bool>> expression)
        {
            throw new NotImplementedException();
        }

        public GraduationInformation FirstOrDefaultAsNotracking(System.Linq.Expressions.Expression<Func<GraduationInformation, bool>> expression, string include)
        {
            throw new NotImplementedException();
        }

        public GraduationInformation GetById(long _id)
        {
            throw new NotImplementedException();
        }

        public void Insert(GraduationInformation ent)
        {
            ent.CreatedDate = DateTime.Now;
            ent.IsValid = true;
            graduationInfo.Add(ent);
        }

        public void Update(GraduationInformation ent)
        {
            var item = graduationInfo.SingleOrDefault(x => x.UserInfoId == ent.UserInfoId);
            if (item != null)
            {
                item.HighSchoolName = ent.HighSchoolName;
                item.HighSchoolProvince = ent.HighSchoolProvince;
                item.HighSchoolType = ent.HighSchoolType;
                item.HighSchoolGraduationYear = ent.HighSchoolGraduationYear;
                item.HighSchoolDiplomaDegree = ent.HighSchoolDiplomaDegree;
                item.HighSchoolDepartment = ent.HighSchoolDepartment;
                item.OtherUniversityName = ent.OtherUniversityName;
                item.MYOName = ent.MYOName;
                item.UniversityDiplomaDegree = ent.UniversityDiplomaDegree;
                item.UniversityGraduationYear = ent.UniversityGraduationYear;
                item.UniversityName = ent.UniversityName;
                item.UniversityProvince = ent.UniversityProvince;
                item.DepartmentName = ent.DepartmentName;
                item.ModifiedDate = DateTime.Now;
            }
        }

        public void Delete(GraduationInformation ent)
        {
            throw new NotImplementedException();
        }
    }
}
