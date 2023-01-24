namespace DAL.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("GraduationInformation")]
    public partial class GraduationInformation : ISoftDelete, IDateConstraint, IStepable
    {
        public long GraduateID { get; set; }

        [Required]
        [StringLength(50)]
        public string HighSchoolName { get; set; }

        [Required]
        [StringLength(50)]
        public string HighSchoolProvince { get; set; }

        [Required]
        [StringLength(50)]
        public string HighSchoolType { get; set; }

        [Required]
        [StringLength(50)]
        public string HighSchoolDepartment { get; set; }

        public string HighSchoolDiplomaDegree { get; set; }

        [StringLength(4)]
        public string HighSchoolGraduationYear { get; set; }

        [StringLength(50)]
        public string UniversityName { get; set; }

        [StringLength(50)]
        public string OtherUniversityName { get; set; }

        [StringLength(50)]
        public string UniversityProvince { get; set; }

        [StringLength(50)]
        public string MYOName { get; set; }

        [StringLength(50)]
        public string DepartmentName { get; set; }

        public string UniversityDiplomaDegree { get; set; }

        [StringLength(4)]
        public string UniversityGraduationYear { get; set; }

        public bool IsValid { get; set; }

        public DateTime CreatedDate { get; set; }

        public DateTime? ModifiedDate { get; set; }

        [Required]
        public long UserInfoId { get; set; }

        public virtual UserInformation UserInformation { get; set; }
    }
}
