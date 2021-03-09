using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using KursiIm.Domain;
using KursiIm.Domain.KursiIm;

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

        public virtual DbSet<LogDataChange> LogDataChange { get; set; }
        public virtual DbSet<LogDataChangeStatus> LogDataChangeStatus { get; set; }
        public virtual DbSet<LogFailedAuthentication> LogFailedAuthentication { get; set; }
        public virtual DbSet<LogInternetBrowserType> LogInternetBrowserType { get; set; }
        public virtual DbSet<LogOperatingSystemType> LogOperatingSystemType { get; set; }
        public virtual DbSet<LogUserActivity> LogUserActivity { get; set; }
        public virtual DbSet<LogUserActivityStatus> LogUserActivityStatus { get; set; }
        public virtual DbSet<LogUserAuthorization> LogUserAuthorization { get; set; }
        public virtual DbSet<LogUserAuthorizationStatus> LogUserAuthorizationStatus { get; set; }
        public virtual DbSet<Module> Module { get; set; }
        public virtual DbSet<Role> Role { get; set; }
        public virtual DbSet<RoleAuthorization> RoleAuthorization { get; set; }
        public virtual DbSet<RoleAuthorizationType> RoleAuthorizationType { get; set; }
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

                entity.Property(e => e.ComputerName)
                    .IsRequired()
                    .HasMaxLength(250);

                entity.Property(e => e.EntryDate).HasColumnType("datetime");

                entity.Property(e => e.IPAddress)
                    .IsRequired()
                    .HasMaxLength(250)
                    .IsUnicode(false);

                entity.HasOne(d => d.IDLogBrowserTypeNavigation)
                    .WithMany(p => p.LogFailedAuthentication)
                    .HasForeignKey(d => d.IDLogBrowserType)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_LogFailedAuthentication_LogInternetBrowserType");

                entity.HasOne(d => d.IDLogOperationSystemTypeNavigation)
                    .WithMany(p => p.LogFailedAuthentication)
                    .HasForeignKey(d => d.IDLogOperationSystemType)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_LogFailedAuthentication_LogOperatingSystemType");
            });

            modelBuilder.Entity<LogInternetBrowserType>(entity =>
            {
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
