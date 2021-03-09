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
        public virtual DbSet<LogDataChangeStatus> LogDataChangeStatuses { get; set; }
        public virtual DbSet<LogFailedAuthentication> LogFailedAuthentications { get; set; }
        public virtual DbSet<LogInternetBrowserType> LogInternetBrowserTypes { get; set; }
        public virtual DbSet<LogOperatingSystemType> LogOperatingSystemTypes { get; set; }
        public virtual DbSet<LogUserActivity> LogUserActivities { get; set; }
        public virtual DbSet<LogUserActivityStatus> LogUserActivityStatuses { get; set; }
        public virtual DbSet<LogUserAuthorization> LogUserAuthorizations { get; set; }
        public virtual DbSet<LogUserAuthorizationStatus> LogUserAuthorizationStatuses { get; set; }
        public virtual DbSet<Module> Modules { get; set; }
        public virtual DbSet<Role> Roles { get; set; }
        public virtual DbSet<RoleAuthorization> RoleAuthorizations { get; set; }
        public virtual DbSet<RoleAuthorizationType> RoleAuthorizationTypes { get; set; }
        public virtual DbSet<Tables> Tables { get; set; }
        public virtual DbSet<User> User { get; set; }
        public virtual DbSet<UserAuthorizationType> UserAuthorizationTypes { get; set; }

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
                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.After)
                    .IsRequired()
                    .HasMaxLength(1000)
                    .IsFixedLength();

                entity.Property(e => e.Before)
                    .IsRequired()
                    .HasMaxLength(1000)
                    .IsFixedLength();

                entity.Property(e => e.ComputerName)
                    .IsRequired()
                    .HasMaxLength(250);

                entity.Property(e => e.EntryDate).HasColumnType("datetime");

                entity.Property(e => e.EntryUser)
                    .IsRequired()
                    .HasMaxLength(250);

                entity.Property(e => e.Idaddress)
                    .IsRequired()
                    .HasColumnName("IDAddress")
                    .HasMaxLength(250);

                entity.Property(e => e.IdentryUser).HasColumnName("IDEntryUser");

                entity.Property(e => e.IdlogBrowserType).HasColumnName("IDLogBrowserType");

                entity.Property(e => e.IdlogDataChangeStatus).HasColumnName("IDLogDataChangeStatus");

                entity.Property(e => e.IdlogOperatingSystemType).HasColumnName("IDLogOperatingSystemType");

                entity.Property(e => e.Idtable).HasColumnName("IDTable");

                entity.HasOne(d => d.IdlogBrowserTypeNavigation)
                    .WithMany(p => p.LogDataChange)
                    .HasForeignKey(d => d.IdlogBrowserType)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_LogDataChange_LogInternetBrowserType");

                entity.HasOne(d => d.IdlogDataChangeStatusNavigation)
                    .WithMany(p => p.LogDataChange)
                    .HasForeignKey(d => d.IdlogDataChangeStatus)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_LogDataChange_LogDataChangeStatus");

                entity.HasOne(d => d.IdlogOperatingSystemTypeNavigation)
                    .WithMany(p => p.LogDataChange)
                    .HasForeignKey(d => d.IdlogOperatingSystemType)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_LogDataChange_LogOperatingSystemType");

                entity.HasOne(d => d.IdtableNavigation)
                    .WithMany(p => p.LogDataChange)
                    .HasForeignKey(d => d.Idtable)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_LogDataChange_Tables");
            });

            modelBuilder.Entity<LogDataChangeStatus>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Description).HasMaxLength(250);

                entity.Property(e => e.EntryDate).HasColumnType("datetime");

                entity.Property(e => e.EntryUser)
                    .IsRequired()
                    .HasMaxLength(250);

                entity.Property(e => e.IdentryUser).HasColumnName("IDEntryUser");

                entity.Property(e => e.Title)
                    .IsRequired()
                    .HasMaxLength(250);
            });

            modelBuilder.Entity<LogFailedAuthentication>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Account)
                    .IsRequired()
                    .HasMaxLength(250)
                    .IsUnicode(false);

                entity.Property(e => e.ComputerName)
                    .IsRequired()
                    .HasMaxLength(250);

                entity.Property(e => e.EntryDate).HasColumnType("datetime");

                entity.Property(e => e.IdlogBrowserType).HasColumnName("IDLogBrowserType");

                entity.Property(e => e.IdlogOperationSystemType).HasColumnName("IDLogOperationSystemType");

                entity.Property(e => e.Ipaddress)
                    .IsRequired()
                    .HasColumnName("IPAddress")
                    .HasMaxLength(250)
                    .IsUnicode(false);

                entity.HasOne(d => d.IdlogBrowserTypeNavigation)
                    .WithMany(p => p.LogFailedAuthentication)
                    .HasForeignKey(d => d.IdlogBrowserType)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_LogFailedAuthentication_LogInternetBrowserType");

                entity.HasOne(d => d.IdlogOperationSystemTypeNavigation)
                    .WithMany(p => p.LogFailedAuthentication)
                    .HasForeignKey(d => d.IdlogOperationSystemType)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_LogFailedAuthentication_LogOperatingSystemType");
            });

            modelBuilder.Entity<LogInternetBrowserType>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Description)
                    .IsRequired()
                    .HasMaxLength(250);

                entity.Property(e => e.EntryDate).HasColumnType("datetime");

                entity.Property(e => e.EntryUser)
                    .IsRequired()
                    .HasMaxLength(250);

                entity.Property(e => e.IdentryUser).HasColumnName("IDEntryUser");

                entity.Property(e => e.Title)
                    .IsRequired()
                    .HasMaxLength(250);
            });

            modelBuilder.Entity<LogOperatingSystemType>(entity =>
            {
                entity.Property(e => e.Id)
                    .HasColumnName("ID")
                    .ValueGeneratedNever();

                entity.Property(e => e.Description)
                    .IsRequired()
                    .HasMaxLength(250);

                entity.Property(e => e.EntryDate).HasColumnType("datetime");

                entity.Property(e => e.EntryUser)
                    .IsRequired()
                    .HasMaxLength(250)
                    .IsUnicode(false);

                entity.Property(e => e.IdentryUser).HasColumnName("IDEntryUser");

                entity.Property(e => e.Title)
                    .IsRequired()
                    .HasMaxLength(250);
            });

            modelBuilder.Entity<LogUserActivity>(entity =>
            {
                entity.Property(e => e.Id)
                    .HasColumnName("ID")
                    .ValueGeneratedNever();

                entity.Property(e => e.ComputerName)
                    .IsRequired()
                    .HasMaxLength(250);

                entity.Property(e => e.EntryDate).HasColumnType("datetime");

                entity.Property(e => e.EntryUser)
                    .IsRequired()
                    .HasMaxLength(250);

                entity.Property(e => e.IdlogBrowserType).HasColumnName("IDLogBrowserType");

                entity.Property(e => e.IdlogOperatingSystemType).HasColumnName("IDLogOperatingSystemType");

                entity.Property(e => e.IdlogUserActivityStatus)
                    .HasColumnName("IDLogUserActivityStatus")
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.Idmodule).HasColumnName("IDModule");

                entity.Property(e => e.Iduser).HasColumnName("IDUser");

                entity.Property(e => e.Ipaddress)
                    .IsRequired()
                    .HasColumnName("IPAddress")
                    .HasMaxLength(250);

                entity.Property(e => e.Url)
                    .IsRequired()
                    .HasColumnName("URL")
                    .HasMaxLength(500);

                entity.HasOne(d => d.IdlogBrowserTypeNavigation)
                    .WithMany(p => p.LogUserActivity)
                    .HasForeignKey(d => d.IdlogBrowserType)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_LogUserActivity_LogInternetBrowserType");

                entity.HasOne(d => d.IdlogOperatingSystemTypeNavigation)
                    .WithMany(p => p.LogUserActivity)
                    .HasForeignKey(d => d.IdlogOperatingSystemType)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_LogUserActivity_LogOperatingSystemType");

                entity.HasOne(d => d.IdlogUserActivityStatusNavigation)
                    .WithMany(p => p.LogUserActivity)
                    .HasForeignKey(d => d.IdlogUserActivityStatus)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_LogUserActivity_LogUserActivityStatus");

                entity.HasOne(d => d.IdmoduleNavigation)
                    .WithMany(p => p.LogUserActivity)
                    .HasForeignKey(d => d.Idmodule)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_LogUserActivity_Module");
            });

            modelBuilder.Entity<LogUserActivityStatus>(entity =>
            {
                entity.Property(e => e.Id)
                    .HasColumnName("ID")
                    .ValueGeneratedNever();

                entity.Property(e => e.Description)
                    .IsRequired()
                    .HasMaxLength(500);

                entity.Property(e => e.EntryDate).HasColumnType("datetime");

                entity.Property(e => e.EntryUser)
                    .IsRequired()
                    .HasMaxLength(250);

                entity.Property(e => e.IdentryUser)
                    .HasColumnName("IDEntryUser")
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.Title).HasMaxLength(250);
            });

            modelBuilder.Entity<LogUserAuthorization>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.ComputerName)
                    .IsRequired()
                    .HasMaxLength(250);

                entity.Property(e => e.EntryDate).HasColumnType("datetime");

                entity.Property(e => e.EntryUser)
                    .IsRequired()
                    .HasMaxLength(150)
                    .IsUnicode(false);

                entity.Property(e => e.IdlogBrowserType).HasColumnName("IDLogBrowserType");

                entity.Property(e => e.IdlogOperatingSystemType).HasColumnName("IDLogOperatingSystemType");

                entity.Property(e => e.IdlogUserAuthorizationStatus).HasColumnName("IDLogUserAuthorizationStatus");

                entity.Property(e => e.Iduser).HasColumnName("IDUser");

                entity.Property(e => e.Ipaddress)
                    .IsRequired()
                    .HasColumnName("IPAddress")
                    .HasMaxLength(50);

                entity.HasOne(d => d.IdlogBrowserTypeNavigation)
                    .WithMany(p => p.LogUserAuthorization)
                    .HasForeignKey(d => d.IdlogBrowserType)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_LogUserAuthorization_LogInternetBrowserType");

                entity.HasOne(d => d.IdlogOperatingSystemTypeNavigation)
                    .WithMany(p => p.LogUserAuthorization)
                    .HasForeignKey(d => d.IdlogOperatingSystemType)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_LogUserAuthorization_LogOperatingSystemType");

                entity.HasOne(d => d.IdlogUserAuthorizationStatusNavigation)
                    .WithMany(p => p.LogUserAuthorization)
                    .HasForeignKey(d => d.IdlogUserAuthorizationStatus)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_LogUserAuthorization_LogUserAuthorizationStatus");
            });

            modelBuilder.Entity<LogUserAuthorizationStatus>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Description).HasMaxLength(500);

                entity.Property(e => e.EntryDate).HasColumnType("datetime");

                entity.Property(e => e.EntryUser)
                    .IsRequired()
                    .HasMaxLength(250);

                entity.Property(e => e.IdentryUser).HasColumnName("IDEntryUser");

                entity.Property(e => e.Title)
                    .IsRequired()
                    .HasMaxLength(250);
            });

            modelBuilder.Entity<Module>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Description).HasMaxLength(500);

                entity.Property(e => e.EntryDate).HasColumnType("datetime");

                entity.Property(e => e.EntryUser)
                    .IsRequired()
                    .HasMaxLength(150);

                entity.Property(e => e.IdentryUser).HasColumnName("IDEntryUser");

                entity.Property(e => e.Idparent).HasColumnName("IDParent");

                entity.Property(e => e.Title)
                    .IsRequired()
                    .HasMaxLength(150);
            });

            modelBuilder.Entity<Role>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Description).HasMaxLength(550);

                entity.Property(e => e.EntryDate).HasColumnType("datetime");

                entity.Property(e => e.EntryUser)
                    .IsRequired()
                    .HasMaxLength(150);

                entity.Property(e => e.IdentryUser).HasColumnName("IDEntryUser");

                entity.Property(e => e.IdupdateUser).HasColumnName("IDUpdateUser");

                entity.Property(e => e.Title)
                    .IsRequired()
                    .HasMaxLength(150);

                entity.Property(e => e.UpdateDate).HasColumnType("datetime");

                entity.Property(e => e.UpdateUser).HasMaxLength(150);
            });

            modelBuilder.Entity<RoleAuthorization>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.EntryDate).HasColumnType("datetime");

                entity.Property(e => e.EntryUser)
                    .IsRequired()
                    .HasMaxLength(150);

                entity.Property(e => e.IdentryUser).HasColumnName("IDEntryUser");

                entity.Property(e => e.Idmodule).HasColumnName("IDModule");

                entity.Property(e => e.Idrole).HasColumnName("IDRole");

                entity.Property(e => e.IdroleAuthorizationType).HasColumnName("IDRoleAuthorizationType");

                entity.Property(e => e.IdupdateUser).HasColumnName("IDUpdateUser");

                entity.Property(e => e.UpdateDate).HasColumnType("datetime");

                entity.Property(e => e.UpdateUser).HasMaxLength(150);

                entity.HasOne(d => d.IdmoduleNavigation)
                    .WithMany(p => p.RoleAuthorization)
                    .HasForeignKey(d => d.Idmodule)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_RoleAuthorization_Module");

                entity.HasOne(d => d.IdroleNavigation)
                    .WithMany(p => p.RoleAuthorization)
                    .HasForeignKey(d => d.Idrole)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_RoleAuthorization_Role");

                entity.HasOne(d => d.IdroleAuthorizationTypeNavigation)
                    .WithMany(p => p.RoleAuthorization)
                    .HasForeignKey(d => d.IdroleAuthorizationType)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_RoleAuthorization_RoleAuthorizationType");
            });

            modelBuilder.Entity<RoleAuthorizationType>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Description).HasMaxLength(500);

                entity.Property(e => e.EntryDate).HasColumnType("datetime");

                entity.Property(e => e.EntryUser)
                    .IsRequired()
                    .HasMaxLength(150);

                entity.Property(e => e.IdentryUser).HasColumnName("IDEntryUser");

                entity.Property(e => e.Title)
                    .IsRequired()
                    .HasMaxLength(150);
            });

            modelBuilder.Entity<Tables>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Title).HasMaxLength(250);
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("ID");

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

                entity.Property(e => e.IddeleteUser).HasColumnName("IDDeleteUser");

                entity.Property(e => e.IdentryUser).HasColumnName("IDEntryUser");

                entity.Property(e => e.Idrole).HasColumnName("IDRole");

                entity.Property(e => e.IdupdateUser).HasColumnName("IDUpdateUser");

                entity.Property(e => e.IduserAuthorizationType).HasColumnName("IDUserAuthorizationType");

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

                entity.HasOne(d => d.IdroleNavigation)
                    .WithMany(p => p.User)
                    .HasForeignKey(d => d.Idrole)
                    .HasConstraintName("FK_User_Role");

                entity.HasOne(d => d.IduserAuthorizationTypeNavigation)
                    .WithMany(p => p.User)
                    .HasForeignKey(d => d.IduserAuthorizationType)
                    .HasConstraintName("FK_User_UserAuthorizationType");
            });

            modelBuilder.Entity<UserAuthorizationType>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Description).HasMaxLength(500);

                entity.Property(e => e.EntryDate).HasColumnType("datetime");

                entity.Property(e => e.EntryUser)
                    .IsRequired()
                    .HasMaxLength(150);

                entity.Property(e => e.IdentryUser).HasColumnName("IDEntryUser");

                entity.Property(e => e.Title)
                    .IsRequired()
                    .HasMaxLength(250);
            });

            OnModelCreatingPartial(modelBuilder);
        }


        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
