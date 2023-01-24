using DAL.Models;
using HRBussiness;
using Ninject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ArcelikLgHRWeb
{
    public class ArcelikLGNinjectResolver : IDependencyResolver
    {
        private IKernel _kernel;
        public ArcelikLGNinjectResolver()
        {
            _kernel = new StandardKernel();
        }
        public object GetService(Type serviceType)
        {
            return _kernel.TryGet(serviceType);
        }

        public IEnumerable<object> GetServices(Type serviceType)
        {
            return _kernel.GetAll(serviceType);
        }

        private void addBindings()
        {
            _kernel.Bind<IUnitOfWork>().To<UnitOfWork>();

            //dependency chain için diğerlerinide eklemeliyiz (nested olan)
            _kernel.Bind<IGenericRepository<UserInformation, long>>().To<UserInformationRep>();
            _kernel.Bind<IGenericRepository<PersonalInformation, long>>().To<PersonalInformationRep>();
            _kernel.Bind<IGenericRepository<ContactInformation, long>>().To<ContactInformationRep>();
            _kernel.Bind<IGenericRepository<GraduationInformation, long>>().To<GraduationInformationRep>();
            _kernel.Bind<IGenericRepository<WorkInformation, long>>().To<WorkInformationRep>();
            _kernel.Bind<IGenericRepository<JobInformation, long>>().To<JobInformationRep>();
            _kernel.Bind<IGenericRepository<Transaction, long>>().To<TransactionRep>();
            _kernel.Bind<IGenericRepository<Step, long>>().To<StepRep>();
            _kernel.Bind<IGenericRepository<Log, long>>().To<LogRep>();



            //PersonalInformationRep PersonalInformationRepository { get; }
            //ContactInformationRep ContactInformationRepository { get; }
            //GraduationInformationRep GraduationInformationRepository { get; }
            //WorkInformationRep WorkInformationRepository { get; }
            //JobInformationRep JobInformationRepository { get; }
            //TransactionRep TransactionRepository { get; }
            //StepRep StepRepository { get; }
            //LogRep LogRepository { get; }


            

        }
    }
}