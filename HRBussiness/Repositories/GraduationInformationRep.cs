using DAL;
using DAL.Models;
using HRServiceLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRBussiness
{
    public class GraduationInformationRep:GenericRepository<GraduationInformation, long>
    {
        private readonly GraduateInfoSources graduationInfoSource = GraduateInfoSources.GraduateInfoSourcesInstance;
        public GraduationInformationRep(HRWebContext hrcontext) : base(hrcontext) { }

        public List<string> Faculties { get { return graduationInfoSource.GetFaculties(); } }
        public List<string> GraduateYears { get { return graduationInfoSource.GetGraduateYears(); } }
        public List<string> HighSchools { get { return graduationInfoSource.GetHighSchools(); } }
        public List<string> HighSchoolTypes { get { return graduationInfoSource.GetHighSchoolTypes(); } }
        public List<string> Universities { get { return graduationInfoSource.GetUniversities(); } }
        public List<string> Cities { get { return graduationInfoSource.GetCities(); } }
        public List<string> GetDistrictsByCity(string cityName)
        {
            return graduationInfoSource.GetDistrictsByCity(cityName);
        }
    }
}
