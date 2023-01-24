using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    [Flags]
    public enum StatusTypes : byte
    {
        Continue = 1, StepsCompleted = 2, WaitingForSAP = 4, AllProccessFinished = 8
    }

    public enum LogTypes : byte
    {
        Information = 1, Exception, Warning
    }
}
