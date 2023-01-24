namespace DAL.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("JobInformation")]
    public partial class JobInformation : ISoftDelete, IDateConstraint, IStepable
    {
        public long JobID { get; set; }

        [StringLength(50)]
        public string RequestedJob1 { get; set; }

        [StringLength(50)]
        public string RequestedJob2 { get; set; }

        [StringLength(50)]
        public string RequestedJob3 { get; set; }

        public bool IsValid { get; set; }

        public DateTime CreatedDate { get; set; }

        public DateTime? ModifiedDate { get; set; }

        [Required]
        public long UserInfoId { get; set; }

        public virtual UserInformation UserInformation { get; set; }
    }
}
