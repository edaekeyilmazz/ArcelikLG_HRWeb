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
    public class WorkInformationRep:GenericRepository<WorkInformation, long>
    {
        private readonly WorkInfoSources workInfoSource = WorkInfoSources.WorkInfoSourcesInstance;
        public WorkInformationRep(HRWebContext hrcontext) : base(hrcontext) { }
        public List<string> Years { get { return workInfoSource.GetYears(); } }


        public void deleteDetails(ICollection<WorkExperience> wExperience)
        {
            //foreach (var item in wExperience)
            //{
            //    var res = _hrContext.WorkExperience.FirstOrDefault(X => X.WorkExperienceID == item.WorkExperienceID);
            //    if (res != null)
            //        _hrContext.WorkExperience.Remove(res);
            //}
           // _hrContext.SaveChanges();

            if (wExperience.Count > 0)
                _hrContext.WorkExperience.RemoveRange(wExperience);
        }

        public void deleteDetails(long workId)
        {

            var res = _hrContext.WorkExperience.Where(X => X.WorkID == workId);
            if (res != null)
                _hrContext.WorkExperience.RemoveRange(res.ToList());
        }
    }
}
