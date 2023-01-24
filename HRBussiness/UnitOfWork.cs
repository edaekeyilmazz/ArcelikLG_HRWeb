using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Models;
using DAL;
using System.Transactions;
using Transaction = DAL.Models.Transaction;

namespace HRBussiness
{
    public class UnitOfWork : IUnitOfWork, IDisposable
    {
        private readonly Lazy<HRWebContext> _context = new Lazy<HRWebContext>(()=>new HRWebContext());
        //private static readonly Lazy<UnitOfWork> _UnitOfWorkInstance = new Lazy<UnitOfWork>(() => new UnitOfWork());
        //public static UnitOfWork UnitOfWorkInstance { get { return _UnitOfWorkInstance.Value; } }
        public UnitOfWork()
        {
            _contactInformationRepository = new ContactInformationRep(_context.Value);
            _graduationInformationRepository = new GraduationInformationRep(_context.Value);
            _jobInformationRepository = new JobInformationRep(_context.Value);
            _personalInformationRepository = new PersonalInformationRep(_context.Value);
            _transactionRepository = new TransactionRep(_context.Value);
            _userInformationRepository = new UserInformationRep(_context.Value);
            _workInformationRepository = new WorkInformationRep(_context.Value);
            _stepRepository = new StepRep(_context.Value);
            _logRepository = new LogRep(_context.Value);
        }
        private ContactInformationRep _contactInformationRepository;
        public ContactInformationRep ContactInformationRepository
        {
            get
            {
                return _contactInformationRepository;
            }
        }

        private GraduationInformationRep _graduationInformationRepository;
        public GraduationInformationRep GraduationInformationRepository
        {
            get
            {
                return _graduationInformationRepository;
            }
        }
        private JobInformationRep _jobInformationRepository;
        public JobInformationRep JobInformationRepository
        {
            get
            {
                return _jobInformationRepository;
            }
        }

        private PersonalInformationRep _personalInformationRepository;
        public PersonalInformationRep PersonalInformationRepository
        {
            get
            {
                return _personalInformationRepository;
            }
        }

        private TransactionRep _transactionRepository;
        public TransactionRep TransactionRepository
        {
            get
            {
                return _transactionRepository;
            }
        }

        UserInformationRep _userInformationRepository;
        public UserInformationRep UserInformationRepository
        {
            get
            {
                return _userInformationRepository;
            }
        }

        WorkInformationRep _workInformationRepository;
        public WorkInformationRep WorkInformationRepository
        {
            get
            {
                return _workInformationRepository;
            }
        }

        StepRep _stepRepository;
        public StepRep StepRepository
        {
            get
            {
                return _stepRepository;
            }
        }

        LogRep _logRepository;
        public LogRep LogRepository
        {
            get { return _logRepository; }
        }

        public int SaveChanges()
        {
            return _context.Value.SaveChanges();
            //using (TransactionScope scope = new TransactionScope())
            //{
            //    int result = _context.SaveChanges();
            //    scope.Complete();
            //    return result;
            //}
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        bool isDisposed = false;
        public void Dispose(bool dispose)
        {
            if (isDisposed) return;
            if (dispose)
                _context.Value.Dispose();
            isDisposed = true;
            
        }

        ~UnitOfWork()
        {
            Dispose(false);
        }
    }
}
