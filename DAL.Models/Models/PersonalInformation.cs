namespace DAL.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("PersonalInformation")]
    public partial class PersonalInformation : ISoftDelete, IDateConstraint, IStepable
    {
        public long PersonalID { get; set; }

        [StringLength(13)]
        public string SgkNumber { get; set; }

        [Required]
        [StringLength(50)]
        public string MotherName { get; set; }

        [Required]
        [StringLength(50)]
        public string FatherName { get; set; }

        [Required]
        [StringLength(50)]
        public string BirthPlace { get; set; }

        [MinimumAge(18, ErrorMessage = "18 yaþýndan küçükler baþvuramaz.")]
        [Column(TypeName = "date")]
        [DataType(DataType.Date)]
        [Required]
        public DateTime BirthDate { get; set; }

        [StringLength(50)]
        public string Gender { get; set; }

        [Required]
        [StringLength(50)]
        public string Education { get; set; }

        public bool Overtime { get; set; }

        public bool NightShift { get; set; }

        public bool WorkBeforeArcelikLg { get; set; }

        [StringLength(50)]
        [Required]
        public string MilitaryStatus { get; set; }

        [Column(TypeName = "date")]
        [DataType(DataType.Date)]
        public DateTime? DefermentDate { get; set; }

        [StringLength(50)]
        public string Nationality { get; set; }

        [Required]
        [StringLength(50)]
        public string ProfessionalJob { get; set; }

        public bool IsValid { get; set; }

        public DateTime CreatedDate { get; set; }

        public DateTime? ModifiedDate { get; set; }

        [Required]
        public long UserInfoId { get; set; }

        public virtual UserInformation UserInformation { get; set; }
    }
}
