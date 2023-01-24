namespace DAL.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("ContactInformation")]
    public partial class ContactInformation:ISoftDelete, IDateConstraint, IStepable
    {
        public long ContactID { get; set; }

        [Required]
        [StringLength(100)]
        public string HomeAddress { get; set; }

        [Required]
        [StringLength(50)]
        public string ProvinceOfHomeAddress { get; set; }

        [Required]
        [StringLength(50)]
        public string TownOfHomeAddress { get; set; }

        [StringLength(20)]
        public string HomePhone { get; set; }

        public bool IsValid { get; set; }

        public DateTime CreatedDate { get; set; }

        public DateTime? ModifiedDate { get; set; }

        [Required]
        public long UserInfoId { get; set; }

        public virtual UserInformation UserInformation { get; set; }
    }
}
