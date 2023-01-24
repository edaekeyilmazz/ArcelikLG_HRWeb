using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRServiceLayer
{
    public class GraduateInfoSources
    {
        static Lazy<GraduateInfoSources> graduateLazy = new Lazy<GraduateInfoSources>(() => new GraduateInfoSources());
        public static GraduateInfoSources GraduateInfoSourcesInstance { get { return graduateLazy.Value; } }

        private readonly object lcObj = new object();
        private GraduateInfoSources()
        {

        }

        private List<string> graduateYears;
        private List<string> faculties;
        private List<string> universities;
        private List<string> highSchools;
        private List<string> highSchoolTypes;
        public List<string> GetGraduateYears()
        {
            if (graduateYears == null)
            {
                lock (lcObj)
                {
                    if (graduateYears == null)
                        graduateYears = new List<string>(Enumerable.Range(1995, 23).Select(X => X.ToString()));
                }
            }
            return graduateYears;
        }

        public List<string> GetFaculties()
        {
            if (faculties == null)
            {
                lock (lcObj)
                {
                    if (faculties == null)
                    {
                        string[] _faculties = new string[5];

                        _faculties[0] = "AÇIKÖĞRETİM FAKÜLTESİ";
                        _faculties[1] = "BANKACILIK VE SİGORTACILIK Y.O";
                        _faculties[2] = "BASIN YAYIN Y.O";
                        _faculties[3] = "DENİZCİLİK FKLT.";
                        _faculties[4] = "DEVLET MİMARLIK MÜH. AKADEMİ";

                        faculties = new List<string>(_faculties);
                    }
                }
            }
            return faculties;
        }

        public List<string> GetUniversities()
        {
            if (universities == null)
            {
                lock (lcObj)
                {
                    if (universities == null)
                    {
                        string[] UniversityNames = new string[6];
                        UniversityNames[0] = "DiĞER";
                        UniversityNames[1] = "İSTANBUL ÜNİV.";
                        UniversityNames[2] = "HACETTEPE ÜNİV.";
                        UniversityNames[3] = "KOCAELİ ÜNİV.";
                        UniversityNames[4] = "MALTEPE ÜNİV.";
                        UniversityNames[5] = "YILDIZ TEKNİK ÜNİV.";

                        universities = new List<string>(UniversityNames);
                    }
                }
            }
            return universities;
        }

        public List<string> GetHighSchools()
        {
            if (highSchools == null)
            {
                lock (lcObj)
                {
                    if (highSchools == null)
                    {
                        string[] highsNames = new string[6];
                        highsNames[0] = "AĞAÇ İŞLERİ";
                        highsNames[1] = "BİLGİSAYAR";
                        highsNames[2] = "CNC";
                        highsNames[3] = "DOKUMA";
                        highsNames[4] = "DÖKÜM";
                        highsNames[5] = "ENDÜSTRİYEL ELEKTRONİK";
                        highSchools = new List<string>(highsNames);
                    }
                }
            }
            return highSchools;
        }

        public List<string> GetHighSchoolTypes()
        {
            if (highSchoolTypes == null)
            {
                lock (lcObj)
                {
                    if (highSchoolTypes == null)
                    {
                        string[] highSTNames = new string[6];
                        highSTNames[0] = "AKŞAM LİSESİ";
                        highSTNames[1] = "ANADOLU GÜZEL SANATLAR";
                        highSTNames[2] = "ANADOLU LİSESİ";
                        highSTNames[3] = "ASKERİ LİSE";
                        highSTNames[4] = "DİĞER MESLEK LİSELER";
                        highSTNames[5] = "FEN LİSESİ";
                        highSchoolTypes = new List<string>(highSTNames);
                    }
                }
            }
            return highSchoolTypes;
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
