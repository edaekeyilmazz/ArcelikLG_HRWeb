using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRServiceLayer
{
    public class JobInfoSources
    {
        static Lazy<JobInfoSources> jobLazy = new Lazy<JobInfoSources>(() => new JobInfoSources());
        public static JobInfoSources JobInfoSourcesInstance { get { return jobLazy.Value; } }
        
        private readonly object lcObj = new object();
        private JobInfoSources()
        {

        }
        private List<string> requestedJobs;
        public List<string> GetRequestedJobs()
        {
            if (requestedJobs == null)
            {
                lock (lcObj)
                {
                    if (requestedJobs == null)
                    {
                        string[] reqJobs = new string[7];
                        reqJobs[0] = "BAKIM İŞÇİLİĞİ";
                        reqJobs[1] = "DEPO İŞÇİLİĞİ";
                        reqJobs[2] = "KALİTE KONTROL İŞÇİLİĞİ";
                        reqJobs[3] = "MAKİNE İŞÇİLİĞİ";
                        reqJobs[4] = "ÜRETİMİN HER YERİNDE";
                        reqJobs[5] = "MAVİ YAKA GENEL BAŞVURU";
                        reqJobs[6] = "BOYAHANE İŞÇİLİĞİ";
                        requestedJobs = new List<string>(reqJobs);
                    }
                }
            }
            return requestedJobs;
        }
    }
}
