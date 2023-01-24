using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Models
{
    public interface IStepable
    {
        long UserInfoId { get; set; }
        UserInformation UserInformation { get; set; }
    }
}
