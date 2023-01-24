using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRServiceLayer
{
    public class WorkInfoSources
    {
        static Lazy<WorkInfoSources> workLazy = new Lazy<WorkInfoSources>(() => new WorkInfoSources());
        public static WorkInfoSources WorkInfoSourcesInstance { get { return workLazy.Value; } }
        private readonly object lcObj = new object();
        private WorkInfoSources()
        {

        }

        public List<string> GetYears()
        {
            return GraduateInfoSources.GraduateInfoSourcesInstance.GetGraduateYears();
        }
    }
}
