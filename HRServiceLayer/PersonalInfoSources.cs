using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRServiceLayer
{
    public class PersonalInfoSources
    {
        static Lazy<PersonalInfoSources> personalLazy = new Lazy<PersonalInfoSources>(() => new PersonalInfoSources());
        public static PersonalInfoSources PersonalInfoSourcesInstance { get { return personalLazy.Value; } }
        private readonly object lcObj = new object();

        private List<string> educationInformations;
        private List<string> militaryInformations;
        private List<string> militaryExemptionReasons;
        private List<string> disablityReasons;
        private List<string> healthStatus;
        private List<string> jobList;
        private List<string> bloodTypes;
        private List<string> nationality;
        private List<string> cities;
        private List<string> districts;
        private List<string> genders;
        private PersonalInfoSources()
        {

        }

        public List<string> GetEducationInformations()
        {
            if (educationInformations == null)
            {
                lock (lcObj)
                {
                    if (educationInformations == null)
                    {
                        string[] educations = new string[12];
                        educations[0] = "İlkokul Mezunu";
                        educations[1] = "Ortaokul Mezunu";
                        educations[2] = "Orta (kolej) Mezunu";
                        educations[3] = "Orta Sanat Mezunu";
                        educations[3] = "Orta Sanat Mezunu";
                        educations[4] = "Sanat Enstitüsü Mezunu";
                        educations[5] = "Normal Lise Mezunu";
                        educations[6] = "Lise (kolej) Mezunu";
                        educations[7] = "Meslek Lisesi Mezunu";
                        educations[8] = "Teknik Lise Mezunu";
                        educations[9] = "Ticaret Lisesi Mezunu";
                        educations[10] = "İmam Hatip Lisesi Mezunu";
                        educations[11] = "Ön Lisans Mezunu";

                        educationInformations = new List<string>(educations);
                    }
                }
            }
            return educationInformations;
        }

        //private async Task<string[]> GetEducationInformationsAsync()
        //{
        //    return await Task.Run(() =>
        //    {
        //        string[] educations = new string[12];
        //        educations[0] = "İlkokul Mezunu";
        //        educations[1] = "Ortaokul Mezunu";
        //        educations[2] = "Orta (kolej) Mezunu";
        //        educations[3] = "Orta Sanat Mezunu";
        //        educations[3] = "Orta Sanat Mezunu";
        //        educations[4] = "Sanat Enstitüsü Mezunu";
        //        educations[5] = "Normal Lise Mezunu";
        //        educations[6] = "Lise (kolej) Mezunu";
        //        educations[7] = "Meslek Lisesi Mezunu";
        //        educations[8] = "Teknik Lise Mezunu";
        //        educations[9] = "Ticaret Lisesi Mezunu";
        //        educations[10] = "İmam Hatip Lisesi Mezunu";
        //        educations[11] = "Ön Lisans Mezunu";
        //        return educations;
        //    });
        //}

        public List<string> GetMilitaryInformations()
        {
            if (militaryInformations == null)
            {
                lock (lcObj)
                {
                    if (militaryInformations == null)
                    {
                        string[] militaryInfos = new string[4];
                        militaryInfos[0] = "Yaptım";
                        militaryInfos[1] = "Tecilli";
                        militaryInfos[2] = "Muaf";
                        militaryInfos[3] = "Yapmadım";

                        militaryInformations = new List<string>(militaryInfos);
                    }
                }
            }
            return militaryInformations;
        }

        public List<string> GetMilitaryExemptionReasons()
        {
            if (militaryExemptionReasons == null)
            {
                lock (lcObj)
                {
                    if (militaryExemptionReasons == null)
                    {
                        string[] reasons = new string[12];
                        reasons[0] = "Diğer";
                        reasons[1] = "Akciğer Ameliyatı";
                        reasons[2] = "Anemi";
                        reasons[3] = "Beyin Hastalıkları";
                        reasons[4] = "Böbrek Yetmezliği";
                        reasons[5] = "Diabet";
                        reasons[6] = "Göz";
                        reasons[7] = "Hepatit B";
                        reasons[8] = "Kalp Yetmezliği";
                        reasons[9] = "Kas Gücü Kaybı";
                        reasons[10] = "Obezite";
                        reasons[11] = "Ortopedik Engelli";

                        militaryExemptionReasons = new List<string>(reasons);
                    }
                }
            }
            return militaryExemptionReasons;
        }

        public List<string> GetDisablityReasons()
        {
            if (disablityReasons == null)
            {
                lock (lcObj)
                {
                    if (disablityReasons == null)
                    {
                        string[] reasons = new string[12];
                        reasons[0] = "Diğer";
                        reasons[1] = "Akciğer Ameliyatı";
                        reasons[2] = "Anemi";
                        reasons[3] = "Beyin Hastalıkları";
                        reasons[4] = "Böbrek Yetmezliği";
                        reasons[5] = "Diabet";
                        reasons[6] = "Göz";
                        reasons[7] = "Hepatit B";
                        reasons[8] = "Kalp Yetmezliği";
                        reasons[9] = "Kas Gücü Kaybı";
                        reasons[10] = "Obezite";
                        reasons[11] = "Ortopedik Engelli";

                        disablityReasons = new List<string>(reasons);
                    }
                }
            }
            return disablityReasons;
        }

        public List<string> GetHealthStatus()
        {
            if (healthStatus == null)
            {
                lock (lcObj)
                {
                    if (healthStatus == null)
                    {
                        string[] healthStatuses = new string[4];
                        healthStatuses[0] = "Normal";
                        healthStatuses[1] = "Sakatlık1";
                        healthStatuses[2] = "Sakatlık2";
                        healthStatuses[3] = "Sakatlık3";

                        healthStatus = new List<string>(healthStatuses);
                    }
                }
            }
            return healthStatus;
        }

        public List<string> GetJobList()
        {
            if (jobList == null)
            {
                lock (lcObj)
                {
                    if (jobList == null)
                    {
                        string[] jobs = new string[7];
                        jobs[0] = "AVUKAT";
                        jobs[1] = "BİLGİ KAYIT OPERATÖRÜ";
                        jobs[2] = "BİLGİSAYAR MÜHENDİSİ";
                        jobs[3] = "DOKTOR (TIP)";
                        jobs[4] = "DİĞER";
                        jobs[5] = "EKONOMETRİ";
                        jobs[6] = "ELEKTRONİK HABERLEŞME MÜH.";
                        jobList = new List<string>(jobs);
                    }
                }
            }
            return jobList;
        }

        public List<string> GetBloodTypes()
        {
            if (bloodTypes == null)
            {
                lock (lcObj)
                {
                    if (bloodTypes == null)
                    {
                        string[] _bloodTypes = new string[8];
                        _bloodTypes[0] = "0 Rh +";
                        _bloodTypes[1] = "0 Rh -";
                        _bloodTypes[2] = "A Rh +";
                        _bloodTypes[3] = "A Rh -";
                        _bloodTypes[4] = "AB Rh +";
                        _bloodTypes[5] = "AB Rh -";
                        _bloodTypes[6] = "B Rh +";
                        _bloodTypes[7] = "B Rh -";
                        bloodTypes = new List<string>(_bloodTypes);
                    }
                }
            }
            return bloodTypes;
        }

        public List<string> GetNationality()
        {
            if (nationality == null)
            {
                lock (lcObj)
                {
                    if (nationality == null)
                    {
                        string[] country = new string[7];
                        country[0] = "A.B.D";
                        country[1] = "AFGANİSTAN";
                        country[2] = "ALASKA";
                        country[3] = "ALMANYA";
                        country[4] = "AVUSTURALYA";
                        country[5] = "BELÇİKA";
                        country[6] = "DANİMARKA";
                        nationality = new List<string>(country);
                    }
                }
            }
            return nationality;
        }

        public List<string> GetCities()
        {
            if (cities == null)
            {
                lock (lcObj)
                {
                    if (cities == null)
                    {
                        string[] _cities = new string[4];
                        _cities[0] = "ISTANBUL";
                        _cities[1] = "IZMIR";
                        _cities[2] = "MALATYA";
                        _cities[3] = "TRABZON";

                        cities = new List<string>(_cities);
                    }
                }
            }
            return cities;
        }

        public List<string> GetDistrictsByCity(string cityName)
        {
            if (districts == null)
            {
                lock (lcObj)
                {
                    if (districts == null)
                    {
                        string[] _districts = new string[29];
                        _districts[0] = "2#Akçadağ";
                        _districts[1] = "2#Arapgir";
                        _districts[2] = "2#Arguvan";
                        _districts[3] = "2#Battalgazi";
                        _districts[4] = "2#Darende";
                        _districts[5] = "2#Doğanşehir";
                        _districts[6] = "2#Doğanyol";
                        _districts[7] = "2#Hekimhan";
                        _districts[8] = "1#Aliağa";
                        _districts[9] = "1#Balçova";
                        _districts[10] = "1#Bayındır";
                        _districts[11] = "1#Bayraklı";
                        _districts[12] = "1#Bergama";
                        _districts[13] = "1#Beydağ";
                        _districts[14] = "1#Bornova";
                        _districts[15] = "0#Adalar";
                        _districts[16] = "0#Arnavutköy";
                        _districts[17] = "0#Ataşehir";
                        _districts[18] = "0#Avcılar";
                        _districts[19] = "0#Bağcılar";
                        _districts[20] = "0#Bahçelievler";
                        _districts[21] = "0#Bakırköy";
                        _districts[22] = "3#Akçaabat";
                        _districts[23] = "3#Araklı";
                        _districts[24] = "3#Arsin";
                        _districts[25] = "3#Beşikdüzü";
                        _districts[26] = "3#Çarşıbaşı";
                        _districts[27] = "3#Çaykara";
                        _districts[28] = "3#Dernekpazarı";
                        districts = new List<string>(_districts);
                    }
                }
            }
            int indx = GetCities().FindIndex(X => X.Equals(cityName));
            return districts.Where(X => X.StartsWith(indx.ToString())).ToList();
        }

        public List<string> GetGenders()
        {
            if (genders == null)
            {
                lock (lcObj)
                {
                    if (genders == null)
                    {
                        genders = new List<string>() { "Kadın", "Erkek" };
                    }
                }
            }
            return genders;
        }
    }
}
