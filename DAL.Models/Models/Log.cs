namespace DAL.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Log")]
    public partial class Log : ISoftDelete, IDateConstraint
    {
        public long LogID { get; set; }

        public Guid Sequence { get; set; }

        public byte LogType { get; set; }

        public long? UserID { get; set; }

        [Required]
        [StringLength(500)]
        public string Message { get; set; }

        [Required]
        public string Description { get; set; }

        public bool IsValid { get; set; }

        public DateTime CreatedDate { get; set; }

        public DateTime? ModifiedDate { get; set; }

        public virtual UserInformation UserInformation { get; set; }
    }
}
