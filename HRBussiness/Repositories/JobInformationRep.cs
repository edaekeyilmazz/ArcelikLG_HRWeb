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
    public class JobInformationRep:GenericRepository<JobInformation, long>
    {
        private readonly JobInfoSources jobInfoSource = JobInfoSources.JobInfoSourcesInstance;
        public JobInformationRep(HRWebContext hrcontext) : base(hrcontext) { }

        public List<string> RequestedJobs { get { return jobInfoSource.GetRequestedJobs(); } }
    }
}
