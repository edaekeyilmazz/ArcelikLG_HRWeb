using DAL;
using DAL.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRBussiness
{
    public class TransactionRep : GenericRepository<Transaction, long>
    {
        public TransactionRep(HRWebContext hrContext) : base(hrContext)
        {

        }

        public override void Insert(Transaction ent)
        {
            _dbSet.Add(ent);
            ent.IsValid = true;
            ent.CreatedDate = DateTime.Now;
            _hrContext.Entry<Transaction>(ent).State = EntityState.Added;
        }

        public override void Update(Transaction ent)
        {
            _dbSet.Add(ent);
            ent.IsValid = true;
            ent.CreatedDate = DateTime.Now;
            _hrContext.Entry<Transaction>(ent).State = EntityState.Modified;
        }
    }
}
