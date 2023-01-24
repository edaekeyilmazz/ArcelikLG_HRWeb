using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRServiceLayer
{
    public class ServiceHelper
    {
        
        static Lazy<ServiceHelper> serviceLazy = new Lazy<ServiceHelper>(() => new ServiceHelper());
        public static ServiceHelper ServiceHelperInstance { get { return serviceLazy.Value; } }
        private readonly object lcObj = new object();
        private ServiceHelper()
        {

        }

        public bool SendInformationToSAP(Dictionary<string,string> informations)
        {
            throw new InvalidOperationException("test");
            return true;
        }
    }
}
