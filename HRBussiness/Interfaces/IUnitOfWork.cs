using DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRBussiness
{
    public interface IUnitOfWork
    {
        UserInformationRep UserInformationRepository { get; }
        PersonalInformationRep PersonalInformationRepository { get; }
        ContactInformationRep ContactInformationRepository { get; }
        GraduationInformationRep GraduationInformationRepository { get; }
        WorkInformationRep WorkInformationRepository { get; }
        JobInformationRep JobInformationRepository { get; }
        TransactionRep TransactionRepository { get; }
        StepRep StepRepository { get; }
        LogRep LogRepository { get; }
        int SaveChanges();
    }
}
