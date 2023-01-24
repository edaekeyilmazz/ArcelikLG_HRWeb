namespace DAL.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("WorkExperience")]
    public partial class WorkExperience
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long WorkExperienceID { get; set; }

        [StringLength(50)]
        public string WorkPlaceName { get; set; }

        [StringLength(50)]
        public string Position { get; set; }

        [StringLength(4)]
        public string BeginDateToWork { get; set; }

        [StringLength(4)]
        public string EndDateToWork { get; set; }

        [StringLength(50)]
        public string FireReasonFromLastJob { get; set; }

        public long WorkID { get; set; }

        public virtual WorkInformation WorkInformation { get; set; }
    }
}
