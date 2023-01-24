namespace DAL.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Transaction")]
    public partial class Transaction : ISoftDelete, IDateConstraint, IStepable
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long TransactionID { get; set; }

        public long FromStepId { get; set; }

        public long ToStepId { get; set; }

        public long UserID { get; set; }

        public bool IsValid { get; set; }

        public DateTime CreatedDate { get; set; }

        public DateTime? ModifiedDate { get; set; }
        [ForeignKey("FromStepId")]
        public virtual Step FromStep { get; set; }

        [ForeignKey("ToStepId")]
        public virtual Step ToStep { get; set; }

        public virtual UserInformation UserInformation { get; set; }

        [NotMapped]
        long IStepable.UserInfoId
        {
            get
            {
                throw new NotImplementedException();
            }
            set
            {
                throw new NotImplementedException();
            }
        }

    }
}
