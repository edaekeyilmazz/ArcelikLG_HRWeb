namespace DAL.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("WorkInformation")]
    public partial class WorkInformation : ISoftDelete, IDateConstraint, IStepable
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public WorkInformation()
        {
            WorkExperience = new HashSet<WorkExperience>();
        }
        public long WorkID { get; set; }

        public bool? IsStillWorking { get; set; }

        [Column(TypeName = "date")]
        public DateTime? FireDateOfLastJob { get; set; }

        public bool IsValid { get; set; }

        public DateTime CreatedDate { get; set; }

        public DateTime? ModifiedDate { get; set; }

        [Required]
        public long UserInfoId { get; set; }

        public virtual UserInformation UserInformation { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<WorkExperience> WorkExperience { get; set; }
    }
}
