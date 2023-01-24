using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRServiceLayer
{
    public class ContactInfoSources
    {
        static Lazy<ContactInfoSources> contactLazy = new Lazy<ContactInfoSources>(() => new ContactInfoSources());
        public static ContactInfoSources ContactInfoSourcesInstance { get { return contactLazy.Value; } }
        private readonly object lcObj = new object();
        private ContactInfoSources()
        {

        }

        public List<string> GetCities()
        {
            return PersonalInfoSources.PersonalInfoSourcesInstance.GetCities();
        }

        public List<string> GetDistrictsByCity(string cityName)
        {
            return PersonalInfoSources.PersonalInfoSourcesInstance.GetDistrictsByCity(cityName);
        }
    }
}
