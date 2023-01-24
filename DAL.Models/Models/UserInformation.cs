namespace DAL.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("UserInformation")]
    public partial class UserInformation : ISoftDelete, IDateConstraint
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public UserInformation()
        {
            Log = new HashSet<Log>();
            Transaction = new HashSet<Transaction>();
            ContactInformation = new HashSet<ContactInformation>();
            PersonalInformation = new HashSet<PersonalInformation>();
            GraduationInformation = new HashSet<GraduationInformation>();
            WorkInformation = new HashSet<WorkInformation>();
            JobInformation = new HashSet<JobInformation>();
        }

        public long UserID { get; set; }

        [TCKimlikNoValidation]
        [Required(AllowEmptyStrings = false, ErrorMessage = "{0} alanı boş geçilemez!")]
        [StringLength(maximumLength: 11, MinimumLength = 11, ErrorMessage = "{0} alanı 11 haneli olmalıdır!")]
        public string TCNo { get; set; }

        [ContractValidation]
        [Required(ErrorMessage = "Aydınlatma ve Rıza Metni ile Referans Taahhüdünü onaylamanız gerekmektedir!")]
        public bool ContractStatus { get; set; }

        [Required]
        [StringLength(50)]
        public string Name { get; set; }

        [Required]
        [StringLength(50)]
        public string Surname { get; set; }

        [Required]
        [StringLength(50)]
        public string Password { get; set; }

        [Required]
        [StringLength(150)]
        [DataType(System.ComponentModel.DataAnnotations.DataType.EmailAddress)]
        [EmailAddress(ErrorMessage="Lütfen geçerli bir email adresi giriniz!.")]
        public string Email { get; set; }
        
        [Required]
        [StringLength(11)]
        [Phone]
        [RegularExpression(@"^(0(\d{3})(\d{3})(\d{2})(\d{2}))$", ErrorMessage = "Lütfen uygun formatta bir telefon numarası giriniz.")]
        public string MobilePhone { get; set; }

        public byte StatusType { get; set; }

        public bool IsValid { get; set; }

        public DateTime CreatedDate { get; set; }

        public DateTime? ModifiedDate { get; set; }

        [NotMapped]
        public bool IsAuthenticatedUser { get; set; }

        public virtual ICollection<ContactInformation> ContactInformation { get; set; }

        public virtual ICollection<GraduationInformation> GraduationInformation { get; set; }

        public virtual ICollection<JobInformation> JobInformation { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Log> Log { get; set; }

        //[System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<PersonalInformation> PersonalInformation { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Transaction> Transaction { get; set; }

        public virtual ICollection<WorkInformation> WorkInformation { get; set; }
    }
}
