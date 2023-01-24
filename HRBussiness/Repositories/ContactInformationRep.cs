using DAL.Models;
using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HRServiceLayer;

namespace HRBussiness
{
    public class ContactInformationRep : GenericRepository<ContactInformation, long>
    {
        private readonly ContactInfoSources contactInfoSource = ContactInfoSources.ContactInfoSourcesInstance;
        public ContactInformationRep(HRWebContext hrcontext) : base(hrcontext) { }
        //public ContactInformationRep() : base(new HRWebContext()) { }
        public List<string> Cities { get { return contactInfoSource.GetCities(); } }

        public List<string> GetDistrictsByCity(string cityName)
        {
            return contactInfoSource.GetDistrictsByCity(cityName);
        }
    }
}
