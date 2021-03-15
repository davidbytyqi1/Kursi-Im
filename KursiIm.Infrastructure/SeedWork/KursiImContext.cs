using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using KursiIm.Domain;
using KursiIm.Domain.KursiIm;
using KursiIm.Domain.Publication;
using KursiIm.Domain.Courses;

#nullable disable

namespace KursiIm.Infrastructure.KursiIm
{
    public partial class KursiImContext : DbContext
    {
        public KursiImContext()
        {
        }

        public KursiImContext(DbContextOptions<KursiImContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Categories> Categories { get; set; }
        public virtual DbSet<Company> Company { get; set; }
        public virtual DbSet<CompanyDocuments> CompanyDocuments { get; set; }
        public virtual DbSet<CompanyRatings> CompanyRatings { get; set; }
        public virtual DbSet<LogDataChange> LogDataChange { get; set; }
        public virtual DbSet<LogDataChangeStatus> LogDataChangeStatus { get; set; }
        public virtual DbSet<LogFailedAuthentication> LogFailedAuthentication { get; set; }
        public virtual DbSet<LogInternetBrowserType> LogInternetBrowserType { get; set; }
        public virtual DbSet<LogOperatingSystemType> LogOperatingSystemType { get; set; }
        public virtual DbSet<LogUserActivity> LogUserActivity { get; set; }
        public virtual DbSet<LogUserActivityStatus> LogUserActivityStatus { get; set; }
        public virtual DbSet<LogUserAuthorization> LogUserAuthorization { get; set; }
        public virtual DbSet<LogUserAuthorizationStatus> LogUserAuthorizationStatus { get; set; }
        public virtual DbSet<Messages> Messages { get; set; }
        public virtual DbSet<Module> Module { get; set; }
        public virtual DbSet<Municipality> Municipality { get; set; }
        public virtual DbSet<PromotionType> PromotionType { get; set; }
        public virtual DbSet<Publications> Publications { get; set; }
        public virtual DbSet<Role> Role { get; set; }
        public virtual DbSet<RoleAuthorization> RoleAuthorization { get; set; }
        public virtual DbSet<RoleAuthorizationType> RoleAuthorizationType { get; set; }
        public virtual DbSet<Subscribe> Subscribe { get; set; }
        public virtual DbSet<Tables> Tables { get; set; }
        public virtual DbSet<User> User { get; set; }
        public virtual DbSet<UserAuthorizationType> UserAuthorizationType { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Categories>(entity =>
            {
                entity.Property(e => e.ID).ValueGeneratedNever();

                entity.Property(e => e.Title)
                    .HasMaxLength(100)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Company>(entity =>
            {
                entity.Property(e => e.Address)
                    .HasMaxLength(150)
                    .IsUnicode(false);

                entity.Property(e => e.DeleteDate).HasColumnType("datetime");

                entity.Property(e => e.Description)
                    .HasMaxLength(500)
                    .IsUnicode(false);

                entity.Property(e => e.Email)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Facebook)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.InsertionDate).HasColumnType("datetime");

                entity.Property(e => e.Instagram)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.LastModifiedDate).HasColumnType("datetime");

                entity.Property(e => e.Latitude)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.LegalName)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.LinkedIn)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Longitude)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.PhoneNumber)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.Subtitle)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Website)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.HasOne(d => d.IDEntryUserNavigation)
                    .WithMany(p => p.Company)
                    .HasForeignKey(d => d.IDEntryUser)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Company_User");

                entity.HasOne(d => d.IDMunicipalityNavigation)
                    .WithMany(p => p.Company)
                    .HasForeignKey(d => d.IDMunicipality)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Company_Municipality");
            });

            modelBuilder.Entity<CompanyDocuments>(entity =>
            {
                entity.Property(e => e.InsertionDate).HasColumnType("datetime");

                entity.Property(e => e.Name)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Path)
                    .HasMaxLength(150)
                    .IsUnicode(false);

                entity.HasOne(d => d.IDCompanyNavigation)
                    .WithMany(p => p.CompanyDocuments)
                    .HasForeignKey(d => d.IDCompany)
                    .HasConstraintName("FK_CompanyDocuments_Company");

                entity.HasOne(d => d.IDEntryUserNavigation)
                    .WithMany(p => p.CompanyDocuments)
                    .HasForeignKey(d => d.IDEntryUser)
                    .HasConstraintName("FK_CompanyDocuments_User");
            });

            modelBuilder.Entity<CompanyRatings>(entity =>
            {
                entity.HasNoKey();

                entity.Property(e => e.Comment)
                    .HasMaxLength(250)
                    .IsUnicode(false);

                entity.HasOne(d => d.IDCompanyNavigation)
                    .WithMany()
                    .HasForeignKey(d => d.IDCompany)
                    .HasConstraintName("FK_CompanyRatings_Company");
            });

            modelBuilder.Entity<LogDataChange>(entity =>
            {
                entity.Property(e => e.After).IsRequired();

                entity.Property(e => e.Before).IsRequired();

                entity.Property(e => e.ComputerName)
                    .IsRequired()
                    .HasMaxLength(250);

                entity.Property(e => e.EntryDate).HasColumnType("datetime");

                entity.Property(e => e.EntryUser)
                    .IsRequired()
                    .HasMaxLength(250);

                entity.Property(e => e.IDAddress)
                    .IsRequired()
                    .HasMaxLength(250);

                entity.HasOne(d => d.IDLogBrowserTypeNavigation)
                    .WithMany(p => p.LogDataChange)
                    .HasForeignKey(d => d.IDLogBrowserType)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_LogDataChange_LogInternetBrowserType");

                entity.HasOne(d => d.IDLogDataChangeStatusNavigation)
                    .WithMany(p => p.LogDataChange)
                    .HasForeignKey(d => d.IDLogDataChangeStatus)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_LogDataChange_LogDataChangeStatus");

                entity.HasOne(d => d.IDLogOperatingSystemTypeNavigation)
                    .WithMany(p => p.LogDataChange)
                    .HasForeignKey(d => d.IDLogOperatingSystemType)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_LogDataChange_LogOperatingSystemType");

                entity.HasOne(d => d.IDTableNavigation)
                    .WithMany(p => p.LogDataChange)
                    .HasForeignKey(d => d.IDTable)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_LogDataChange_Tables");
            });

            modelBuilder.Entity<LogDataChangeStatus>(entity =>
            {
                entity.Property(e => e.Description).HasMaxLength(250);

                entity.Property(e => e.EntryDate).HasColumnType("datetime");

                entity.Property(e => e.EntryUser)
                    .IsRequired()
                    .HasMaxLength(250);

                entity.Property(e => e.Title)
                    .IsRequired()
                    .HasMaxLength(250);
            });

            modelBuilder.Entity<LogFailedAuthentication>(entity =>
            {
                entity.Property(e => e.Account)
                    .IsRequired()
                    .HasMaxLength(250)
                    .IsUnicode(false);

                entity.Property(e => e.ComputerName).HasMaxLength(250);

                entity.Property(e => e.EntryDate).HasColumnType("datetime");

                entity.Property(e => e.IPAddress)
                    .HasMaxLength(250)
                    .IsUnicode(false);

                entity.HasOne(d => d.IDLogBrowserTypeNavigation)
                    .WithMany(p => p.LogFailedAuthentication)
                    .HasForeignKey(d => d.IDLogBrowserType)
                    .HasConstraintName("FK_LogFailedAuthentication_LogInternetBrowserType");

                entity.HasOne(d => d.IDLogOperationSystemTypeNavigation)
                    .WithMany(p => p.LogFailedAuthentication)
                    .HasForeignKey(d => d.IDLogOperationSystemType)
                    .HasConstraintName("FK_LogFailedAuthentication_LogOperatingSystemType");
            });

            modelBuilder.Entity<LogInternetBrowserType>(entity =>
            {
                entity.Property(e => e.ID).ValueGeneratedNever();

                entity.Property(e => e.Description)
                    .IsRequired()
                    .HasMaxLength(250);

                entity.Property(e => e.EntryDate).HasColumnType("datetime");

                entity.Property(e => e.EntryUser)
                    .IsRequired()
                    .HasMaxLength(250);

                entity.Property(e => e.Title)
                    .IsRequired()
                    .HasMaxLength(250);
            });

            modelBuilder.Entity<LogOperatingSystemType>(entity =>
            {
                entity.Property(e => e.ID).ValueGeneratedNever();

                entity.Property(e => e.Description)
                    .IsRequired()
                    .HasMaxLength(250);

                entity.Property(e => e.EntryDate).HasColumnType("datetime");

                entity.Property(e => e.EntryUser)
                    .IsRequired()
                    .HasMaxLength(250)
                    .IsUnicode(false);

                entity.Property(e => e.Title)
                    .IsRequired()
                    .HasMaxLength(250);
            });

            modelBuilder.Entity<LogUserActivity>(entity =>
            {
                entity.Property(e => e.ID).ValueGeneratedNever();

                entity.Property(e => e.ComputerName)
                    .IsRequired()
                    .HasMaxLength(250);

                entity.Property(e => e.EntryDate).HasColumnType("datetime");

                entity.Property(e => e.EntryUser)
                    .IsRequired()
                    .HasMaxLength(250);

                entity.Property(e => e.IDLogUserActivityStatus).ValueGeneratedOnAdd();

                entity.Property(e => e.IPAddress)
                    .IsRequired()
                    .HasMaxLength(250);

                entity.Property(e => e.URL)
                    .IsRequired()
                    .HasMaxLength(500);

                entity.HasOne(d => d.IDLogBrowserTypeNavigation)
                    .WithMany(p => p.LogUserActivity)
                    .HasForeignKey(d => d.IDLogBrowserType)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_LogUserActivity_LogInternetBrowserType");

                entity.HasOne(d => d.IDLogOperatingSystemTypeNavigation)
                    .WithMany(p => p.LogUserActivity)
                    .HasForeignKey(d => d.IDLogOperatingSystemType)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_LogUserActivity_LogOperatingSystemType");

                entity.HasOne(d => d.IDLogUserActivityStatusNavigation)
                    .WithMany(p => p.LogUserActivity)
                    .HasForeignKey(d => d.IDLogUserActivityStatus)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_LogUserActivity_LogUserActivityStatus");

                entity.HasOne(d => d.IDModuleNavigation)
                    .WithMany(p => p.LogUserActivity)
                    .HasForeignKey(d => d.IDModule)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_LogUserActivity_Module");
            });

            modelBuilder.Entity<LogUserActivityStatus>(entity =>
            {
                entity.Property(e => e.ID).ValueGeneratedNever();

                entity.Property(e => e.Description)
                    .IsRequired()
                    .HasMaxLength(500);

                entity.Property(e => e.EntryDate).HasColumnType("datetime");

                entity.Property(e => e.EntryUser)
                    .IsRequired()
                    .HasMaxLength(250);

                entity.Property(e => e.IDEntryUser).ValueGeneratedOnAdd();

                entity.Property(e => e.Title).HasMaxLength(250);
            });

            modelBuilder.Entity<LogUserAuthorization>(entity =>
            {
                entity.Property(e => e.ComputerName)
                    .IsRequired()
                    .HasMaxLength(250);

                entity.Property(e => e.EntryDate).HasColumnType("datetime");

                entity.Property(e => e.EntryUser)
                    .IsRequired()
                    .HasMaxLength(150)
                    .IsUnicode(false);

                entity.Property(e => e.IPAddress)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.HasOne(d => d.IDLogBrowserTypeNavigation)
                    .WithMany(p => p.LogUserAuthorization)
                    .HasForeignKey(d => d.IDLogBrowserType)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_LogUserAuthorization_LogInternetBrowserType");

                entity.HasOne(d => d.IDLogOperatingSystemTypeNavigation)
                    .WithMany(p => p.LogUserAuthorization)
                    .HasForeignKey(d => d.IDLogOperatingSystemType)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_LogUserAuthorization_LogOperatingSystemType");

                entity.HasOne(d => d.IDLogUserAuthorizationStatusNavigation)
                    .WithMany(p => p.LogUserAuthorization)
                    .HasForeignKey(d => d.IDLogUserAuthorizationStatus)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_LogUserAuthorization_LogUserAuthorizationStatus");
            });

            modelBuilder.Entity<LogUserAuthorizationStatus>(entity =>
            {
                entity.Property(e => e.Description).HasMaxLength(500);

                entity.Property(e => e.EntryDate).HasColumnType("datetime");

                entity.Property(e => e.EntryUser)
                    .IsRequired()
                    .HasMaxLength(250);

                entity.Property(e => e.Title)
                    .IsRequired()
                    .HasMaxLength(250);
            });

            modelBuilder.Entity<Messages>(entity =>
            {
                entity.Property(e => e.Email)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.InsertionDate).HasColumnType("datetime");

                entity.Property(e => e.Message)
                    .HasMaxLength(500)
                    .IsUnicode(false);

                entity.HasOne(d => d.IDCompanyNavigation)
                    .WithMany(p => p.Messages)
                    .HasForeignKey(d => d.IDCompany)
                    .HasConstraintName("FK_Messages_Company");

                entity.HasOne(d => d.IDPublicationNavigation)
                    .WithMany(p => p.Messages)
                    .HasForeignKey(d => d.IDPublication)
                    .HasConstraintName("FK_Messages_Publications");

                entity.HasOne(d => d.IDUserNavigation)
                    .WithMany(p => p.Messages)
                    .HasForeignKey(d => d.IDUser)
                    .HasConstraintName("FK_Messages_User");
            });

            modelBuilder.Entity<Module>(entity =>
            {
                entity.Property(e => e.Description).HasMaxLength(500);

                entity.Property(e => e.EntryDate).HasColumnType("datetime");

                entity.Property(e => e.EntryUser)
                    .IsRequired()
                    .HasMaxLength(150);

                entity.Property(e => e.Title)
                    .IsRequired()
                    .HasMaxLength(150);
            });

            modelBuilder.Entity<Municipality>(entity =>
            {
                entity.Property(e => e.Title)
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<PromotionType>(entity =>
            {
                entity.Property(e => e.InsertionDate).HasColumnType("datetime");

                entity.Property(e => e.LastModifiedDate).HasColumnType("datetime");

                entity.Property(e => e.Price).HasColumnType("decimal(12, 2)");

                entity.Property(e => e.Title)
                    .HasMaxLength(100)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Publications>(entity =>
            {
                entity.Property(e => e.Description)
                    .HasMaxLength(500)
                    .IsUnicode(false);

                entity.Property(e => e.EndDate).HasColumnType("datetime");

                entity.Property(e => e.ImagePath)
                    .HasMaxLength(150)
                    .IsUnicode(false);

                entity.Property(e => e.InsertionDate).HasColumnType("datetime");

                entity.Property(e => e.Latitude)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Longitude)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Price).HasColumnType("decimal(12, 2)");

                entity.Property(e => e.PromotionEndDate).HasColumnType("datetime");

                entity.Property(e => e.StartDate).HasColumnType("datetime");

                entity.Property(e => e.Subtitle)
                    .HasMaxLength(150)
                    .IsUnicode(false);

                entity.Property(e => e.Title)
                    .HasMaxLength(150)
                    .IsUnicode(false);

                entity.HasOne(d => d.IDCategoryNavigation)
                    .WithMany(p => p.Publications)
                    .HasForeignKey(d => d.IDCategory)
                    .HasConstraintName("FK_Publications_Categories");

                entity.HasOne(d => d.IDEntryUserNavigation)
                    .WithMany(p => p.Publications)
                    .HasForeignKey(d => d.IDEntryUser)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Publications_User");

                entity.HasOne(d => d.IDMunicipalityNavigation)
                    .WithMany(p => p.Publications)
                    .HasForeignKey(d => d.IDMunicipality)
                    .HasConstraintName("FK_Publications_Municipality");

                entity.HasOne(d => d.IDPromotionTypeNavigation)
                    .WithMany(p => p.Publications)
                    .HasForeignKey(d => d.IDPromotionType)
                    .HasConstraintName("FK_Publications_PromotionType");
            });

            modelBuilder.Entity<Role>(entity =>
            {
                entity.Property(e => e.Description).HasMaxLength(550);

                entity.Property(e => e.EntryDate).HasColumnType("datetime");

                entity.Property(e => e.EntryUser)
                    .IsRequired()
                    .HasMaxLength(150);

                entity.Property(e => e.Title)
                    .IsRequired()
                    .HasMaxLength(150);

                entity.Property(e => e.UpdateDate).HasColumnType("datetime");

                entity.Property(e => e.UpdateUser).HasMaxLength(150);
            });

            modelBuilder.Entity<RoleAuthorization>(entity =>
            {
                entity.Property(e => e.EntryDate).HasColumnType("datetime");

                entity.Property(e => e.EntryUser)
                    .IsRequired()
                    .HasMaxLength(150);

                entity.Property(e => e.UpdateDate).HasColumnType("datetime");

                entity.Property(e => e.UpdateUser).HasMaxLength(150);

                entity.HasOne(d => d.IDModuleNavigation)
                    .WithMany(p => p.RoleAuthorization)
                    .HasForeignKey(d => d.IDModule)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_RoleAuthorization_Module");

                entity.HasOne(d => d.IDRoleNavigation)
                    .WithMany(p => p.RoleAuthorization)
                    .HasForeignKey(d => d.IDRole)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_RoleAuthorization_Role");

                entity.HasOne(d => d.IDRoleAuthorizationTypeNavigation)
                    .WithMany(p => p.RoleAuthorization)
                    .HasForeignKey(d => d.IDRoleAuthorizationType)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_RoleAuthorization_RoleAuthorizationType");
            });

            modelBuilder.Entity<RoleAuthorizationType>(entity =>
            {
                entity.Property(e => e.Description).HasMaxLength(500);

                entity.Property(e => e.EntryDate).HasColumnType("datetime");

                entity.Property(e => e.EntryUser)
                    .IsRequired()
                    .HasMaxLength(150);

                entity.Property(e => e.Title)
                    .IsRequired()
                    .HasMaxLength(150);
            });

            modelBuilder.Entity<Subscribe>(entity =>
            {
                entity.Property(e => e.Email)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.InsertionDate).HasColumnType("datetime");
            });

            modelBuilder.Entity<Tables>(entity =>
            {
                entity.Property(e => e.Title).HasMaxLength(250);
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.Property(e => e.Account)
                    .IsRequired()
                    .HasMaxLength(500);

                entity.Property(e => e.ConfirmationDate).HasColumnType("datetime");

                entity.Property(e => e.DeleteDate).HasColumnType("datetime");

                entity.Property(e => e.EmailAddress)
                    .IsRequired()
                    .HasMaxLength(150);

                entity.Property(e => e.EntryDate).HasColumnType("datetime");

                entity.Property(e => e.EntryUser)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(e => e.ExpireDate).HasColumnType("datetime");

                entity.Property(e => e.First)
                    .IsRequired()
                    .HasMaxLength(500);

                entity.Property(e => e.Last)
                    .IsRequired()
                    .HasMaxLength(500);

                entity.Property(e => e.LatestPasswordChangeDate).HasColumnType("datetime");

                entity.Property(e => e.Password)
                    .IsRequired()
                    .HasMaxLength(500);

                entity.Property(e => e.SaltedPassword).IsRequired();

                entity.Property(e => e.UpdateDate).HasColumnType("datetime");

                entity.Property(e => e.UpdateUser).HasMaxLength(100);

                entity.Property(e => e.UserDelete).HasMaxLength(100);

                entity.HasOne(d => d.IDRoleNavigation)
                    .WithMany(p => p.User)
                    .HasForeignKey(d => d.IDRole)
                    .HasConstraintName("FK_User_Role");

                entity.HasOne(d => d.IDUserAuthorizationTypeNavigation)
                    .WithMany(p => p.User)
                    .HasForeignKey(d => d.IDUserAuthorizationType)
                    .HasConstraintName("FK_User_UserAuthorizationType");
            });

            modelBuilder.Entity<UserAuthorizationType>(entity =>
            {
                entity.Property(e => e.Description).HasMaxLength(500);

                entity.Property(e => e.EntryDate).HasColumnType("datetime");

                entity.Property(e => e.EntryUser)
                    .IsRequired()
                    .HasMaxLength(150);

                entity.Property(e => e.Title)
                    .IsRequired()
                    .HasMaxLength(250);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
