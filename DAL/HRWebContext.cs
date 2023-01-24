namespace DAL
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;
    using Models;

    public partial class HRWebContext : DbContext
    {
        public HRWebContext()
            : base("name=HRWebContext")
        {
            Configuration.ProxyCreationEnabled = false;
            Configuration.LazyLoadingEnabled = false;
        }

        public virtual DbSet<ContactInformation> ContactInformation { get; set; }
        public virtual DbSet<GraduationInformation> GraduationInformation { get; set; }
        public virtual DbSet<JobInformation> JobInformation { get; set; }
        public virtual DbSet<Log> Log { get; set; }
        public virtual DbSet<PersonalInformation> PersonalInformation { get; set; }
        public virtual DbSet<Transaction> Transaction { get; set; }
        public virtual DbSet<Step> Step { get; set; }
        public virtual DbSet<UserInformation> UserInformation { get; set; }
        public virtual DbSet<WorkExperience> WorkExperience { get; set; }
        public virtual DbSet<WorkInformation> WorkInformation { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Log>()
                .HasKey(X => X.LogID)
                .Property(e => e.LogID)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            
            modelBuilder.Entity<Transaction>()
                .HasKey(X => X.TransactionID)
                .Property(e => e.TransactionID)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            modelBuilder.Entity<UserInformation>()
                .HasKey(e => e.UserID)
                .Property(e => e.UserID)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            modelBuilder.Entity<WorkInformation>()
                .HasKey(e => e.WorkID)
                .Property(e => e.WorkID)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            modelBuilder.Entity<WorkInformation>()
                .HasIndex(e => e.UserInfoId).IsUnique();

            modelBuilder.Entity<PersonalInformation>()
                .HasKey(e => e.PersonalID)
                .Property(e => e.PersonalID)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            modelBuilder.Entity<PersonalInformation>()
                .HasIndex(e => e.UserInfoId).IsUnique();

            modelBuilder.Entity<ContactInformation>()
                .HasKey(e => e.ContactID)
                .Property(e => e.ContactID)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            modelBuilder.Entity<ContactInformation>()
                .HasIndex(e => e.UserInfoId).IsUnique();

            modelBuilder.Entity<JobInformation>()
                .HasKey(e => e.JobID)
                .Property(e => e.JobID)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            modelBuilder.Entity<JobInformation>()
                .HasIndex(e => e.UserInfoId).IsUnique();

            modelBuilder.Entity<GraduationInformation>()
                .HasKey(e => e.GraduateID, x => x.IsClustered())
                .Property(e => e.GraduateID)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            modelBuilder.Entity<GraduationInformation>()
                .HasIndex(e => e.UserInfoId).IsUnique();

            modelBuilder.Entity<PersonalInformation>()
                .Property(e => e.SgkNumber)
                .IsFixedLength();

            modelBuilder.Entity<Step>()
                .HasMany(e => e.FromTransactions)
                .WithRequired(e => e.FromStep)
                .HasForeignKey(e => e.FromStepId)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Step>()
                .HasMany(e => e.ToTransactions)
                .WithRequired(e => e.ToStep)
                .HasForeignKey(e => e.ToStepId)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<UserInformation>().HasIndex(X => X.TCNo).IsUnique();
            modelBuilder.Entity<UserInformation>().HasIndex(X => new { X.TCNo, X.Password });

            modelBuilder.Entity<UserInformation>()
                .Property(e => e.TCNo)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<UserInformation>()
                .Property(e => e.MobilePhone)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<UserInformation>()
                .HasMany(e => e.ContactInformation)
                .WithRequired(e => e.UserInformation)
                .HasForeignKey(e => e.UserInfoId)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<UserInformation>()
                .HasMany(e => e.GraduationInformation)
                .WithRequired(e => e.UserInformation)
                .HasForeignKey(e => e.UserInfoId)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<UserInformation>()
                .HasMany(e => e.JobInformation)
                .WithRequired(e => e.UserInformation)
                .HasForeignKey(e => e.UserInfoId)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<UserInformation>()
                .HasMany(e => e.Log)
                .WithRequired(e => e.UserInformation)
                .HasForeignKey(e => e.UserID)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<UserInformation>()
                .HasMany(e => e.PersonalInformation)
                .WithRequired(e => e.UserInformation)
                .HasForeignKey(e => e.UserInfoId)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<UserInformation>()
                .HasMany(e => e.Transaction)
                .WithRequired(e => e.UserInformation)
                .HasForeignKey(e => e.UserID)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<UserInformation>()
                .HasMany(e => e.WorkInformation)
                .WithRequired(e => e.UserInformation)
                .HasForeignKey(e => e.UserInfoId)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<WorkInformation>()
                .HasMany(e => e.WorkExperience)
                .WithRequired(e => e.WorkInformation)
                .WillCascadeOnDelete(false);
        }
    }
}
