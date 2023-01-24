using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace DAL.Models
{
    [Table("Step")]
    public class Step : IComparable<Step>, IDateConstraint, ISoftDelete
    {
        public Step()
        {
            FromTransactions = new HashSet<Transaction>();
            ToTransactions = new HashSet<Transaction>();
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long ID { get; set; }
        [Required]
        public int StepOrder { get; set; }
        [Required]
        public string StepName { get; set; }
        [Required]
        public string ControllerName { get; set; }
        [Required]
        public string ActionName { get; set; }
        [Required]
        [MaxLength(75)]
        public string TitleForLabel { get; set; }
        [NotMapped]
        public string URL { get { return string.Format("~/{0}/{1}", ControllerName, ActionName); } }

        public virtual ICollection<Transaction> FromTransactions { get; set; }
        public virtual ICollection<Transaction> ToTransactions { get; set; }
        public bool IsValid { get; set; }

        public DateTime CreatedDate
        {
            get; set;
        }

        [NotMapped]
        DateTime? IDateConstraint.ModifiedDate
        {
            get; set;
        }

        public int CompareTo(Step other)
        {
            return this.StepOrder.CompareTo(other.StepOrder);
        }
    }
}
