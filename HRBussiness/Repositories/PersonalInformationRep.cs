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
    public class PersonalInformationRep:GenericRepository<PersonalInformation, long>
    {
        private readonly PersonalInfoSources personalInfoSource = PersonalInfoSources.PersonalInfoSourcesInstance;
        public PersonalInformationRep() : base(new HRWebContext()) { }
        public PersonalInformationRep(HRWebContext hrcontext) : base(hrcontext) { }
        public List<string> BloodTypes { get { return personalInfoSource.GetBloodTypes(); } }
        public List<string> DisablityReasons { get { return personalInfoSource.GetDisablityReasons(); } }
        public List<string> EducationInformations { get { return personalInfoSource.GetEducationInformations(); } }
        public List<string> Genders { get { return personalInfoSource.GetGenders(); } }
        public List<string> HealthStatus { get { return personalInfoSource.GetHealthStatus(); } }
        public List<string> JobList { get { return personalInfoSource.GetJobList(); } }
        public List<string> MilitaryExemptionReasons { get { return personalInfoSource.GetMilitaryExemptionReasons(); } }
        public List<string> MilitaryInformations { get { return personalInfoSource.GetMilitaryInformations(); } }
        public List<string> Nationalities { get { return personalInfoSource.GetNationality(); } }
        public List<string> Cities { get { return personalInfoSource.GetCities(); } }
        public List<string> GetDistrictsByCity(string cityName) { return personalInfoSource.GetDistrictsByCity(cityName); }
        
    }
}
