using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace VIIS.API.Data.DBObjects
{
    public partial class VIISDBContext : DbContext
    {
        public virtual DbSet<AddressesTt> AddressesTt { get; set; }
        public virtual DbSet<AspNetRoleClaims> AspNetRoleClaims { get; set; }
        public virtual DbSet<AspNetRoles> AspNetRoles { get; set; }
        public virtual DbSet<AspNetUserClaims> AspNetUserClaims { get; set; }
        public virtual DbSet<AspNetUserLogins> AspNetUserLogins { get; set; }
        public virtual DbSet<AspNetUserRoles> AspNetUserRoles { get; set; }
        public virtual DbSet<AspNetUsers> AspNetUsers { get; set; }
        public virtual DbSet<AspNetUserTokens> AspNetUserTokens { get; set; }
        public virtual DbSet<EmployeesTt> EmployeesTt { get; set; }
        public virtual DbSet<MastersCashTt> MastersCashTt { get; set; }
        public virtual DbSet<OrdersTt> OrdersTt { get; set; }
        public virtual DbSet<PassportsTt> PassportsTt { get; set; }
        public virtual DbSet<PersonsTt> PersonsTt { get; set; }
        public virtual DbSet<ServicesTt> ServicesTt { get; set; }
        public virtual DbSet<ServiceValuesTs> ServiceValuesTs { get; set; }
        public virtual DbSet<TransactionsTt> TransactionsTt { get; set; }
        public virtual DbSet<WorkDaysTt> WorkDaysTt { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
//#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Server=37.140.192.98;Database=u0992410_VIISDB;User ID=u0992410_pro06QTE;Password=9Rk-qyH-5pk-5np;MultipleActiveResultSets=true");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:DefaultSchema", "u0992410_pro06QTE");

            modelBuilder.Entity<AddressesTt>(entity =>
            {
                entity.ToTable("Addresses_TT", "u0992410_vitek4051");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.City)
                    .HasColumnName("city")
                    .HasMaxLength(50);

                entity.Property(e => e.Flat)
                    .HasColumnName("flat")
                    .HasMaxLength(50);

                entity.Property(e => e.House)
                    .HasColumnName("house")
                    .HasMaxLength(50);

                entity.Property(e => e.Postcode).HasColumnName("postcode");

                entity.Property(e => e.Street)
                    .HasColumnName("street")
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<AspNetRoleClaims>(entity =>
            {
                entity.HasIndex(e => e.RoleId);

                entity.Property(e => e.RoleId).IsRequired();

                entity.HasOne(d => d.Role)
                    .WithMany(p => p.AspNetRoleClaims)
                    .HasForeignKey(d => d.RoleId);
            });

            modelBuilder.Entity<AspNetRoles>(entity =>
            {
                entity.HasIndex(e => e.NormalizedName)
                    .HasName("RoleNameIndex");

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.Name).HasMaxLength(256);

                entity.Property(e => e.NormalizedName).HasMaxLength(256);
            });

            modelBuilder.Entity<AspNetUserClaims>(entity =>
            {
                entity.HasIndex(e => e.UserId);

                entity.Property(e => e.UserId).IsRequired();

                entity.HasOne(d => d.User)
                    .WithMany(p => p.AspNetUserClaims)
                    .HasForeignKey(d => d.UserId);
            });

            modelBuilder.Entity<AspNetUserLogins>(entity =>
            {
                entity.HasKey(e => new { e.LoginProvider, e.ProviderKey });

                entity.HasIndex(e => e.UserId);

                entity.Property(e => e.UserId).IsRequired();

                entity.HasOne(d => d.User)
                    .WithMany(p => p.AspNetUserLogins)
                    .HasForeignKey(d => d.UserId);
            });

            modelBuilder.Entity<AspNetUserRoles>(entity =>
            {
                entity.HasKey(e => new { e.UserId, e.RoleId });

                entity.HasIndex(e => e.RoleId);

                entity.HasIndex(e => e.UserId);

                entity.HasOne(d => d.Role)
                    .WithMany(p => p.AspNetUserRoles)
                    .HasForeignKey(d => d.RoleId);

                entity.HasOne(d => d.User)
                    .WithMany(p => p.AspNetUserRoles)
                    .HasForeignKey(d => d.UserId);
            });

            modelBuilder.Entity<AspNetUsers>(entity =>
            {
                entity.HasIndex(e => e.NormalizedEmail)
                    .HasName("EmailIndex");

                entity.HasIndex(e => e.NormalizedUserName)
                    .HasName("UserNameIndex")
                    .IsUnique();

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.Email).HasMaxLength(256);

                entity.Property(e => e.NormalizedEmail).HasMaxLength(256);

                entity.Property(e => e.NormalizedUserName).HasMaxLength(256);

                entity.Property(e => e.UserName).HasMaxLength(256);
            });

            modelBuilder.Entity<AspNetUserTokens>(entity =>
            {
                entity.HasKey(e => new { e.UserId, e.LoginProvider, e.Name });
            });

            modelBuilder.Entity<EmployeesTt>(entity =>
            {
                entity.ToTable("Employees_TT", "u0992410_vitek4051");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Birthday)
                    .HasColumnName("birthday")
                    .HasColumnType("date");

                entity.Property(e => e.ContractId).HasColumnName("contract_id");

                entity.Property(e => e.PassportId).HasColumnName("passportID");

                entity.Property(e => e.PersonId).HasColumnName("personID");

                entity.Property(e => e.Position)
                    .IsRequired()
                    .HasColumnName("position")
                    .HasMaxLength(50);

                entity.Property(e => e.StartDate)
                    .HasColumnName("startDate")
                    .HasColumnType("date");

                entity.HasOne(d => d.Passport)
                    .WithMany(p => p.EmployeesTt)
                    .HasForeignKey(d => d.PassportId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Employees_TT_Passports_TT");

                entity.HasOne(d => d.Person)
                    .WithMany(p => p.EmployeesTt)
                    .HasForeignKey(d => d.PersonId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Employees_TT_Persons_TT");
            });

            modelBuilder.Entity<MastersCashTt>(entity =>
            {
                entity.HasKey(e => new { e.MasterId, e.StartDate, e.FinishDate });

                entity.ToTable("MastersCash_TT", "u0992410_vitek4051");

                entity.Property(e => e.MasterId).HasColumnName("masterID");

                entity.Property(e => e.StartDate)
                    .HasColumnName("startDate")
                    .HasColumnType("date");

                entity.Property(e => e.FinishDate)
                    .HasColumnName("finishDate")
                    .HasColumnType("date");

                entity.Property(e => e.Value)
                    .HasColumnName("value")
                    .HasColumnType("decimal(18, 0)");
            });

            modelBuilder.Entity<OrdersTt>(entity =>
            {
                entity.ToTable("Orders_TT", "u0992410_vitek4051");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.ClientId).HasColumnName("clientID");

                entity.Property(e => e.Comment).HasColumnName("comment");

                entity.Property(e => e.IsFinished).HasColumnName("isFinished");

                entity.Property(e => e.MasterId).HasColumnName("masterID");

                entity.Property(e => e.Sale)
                    .HasColumnName("sale")
                    .HasColumnType("decimal(18, 0)");

                entity.Property(e => e.Start)
                    .HasColumnName("start")
                    .HasColumnType("datetime");

                entity.HasOne(d => d.Client)
                    .WithMany(p => p.OrdersTt)
                    .HasForeignKey(d => d.ClientId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Orders_TT_Persons_TT");

                entity.HasOne(d => d.Master)
                    .WithMany(p => p.OrdersTt)
                    .HasForeignKey(d => d.MasterId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Orders_TT_Employees_TT");
            });

            modelBuilder.Entity<PassportsTt>(entity =>
            {
                entity.ToTable("Passports_TT", "u0992410_vitek4051");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.IssusiesDate)
                    .HasColumnName("issusiesDate")
                    .HasColumnType("date");

                entity.Property(e => e.Organization)
                    .IsRequired()
                    .HasColumnName("organization")
                    .HasMaxLength(50);

                entity.Property(e => e.PassportNumber)
                    .IsRequired()
                    .HasColumnName("passport_number")
                    .HasMaxLength(50);

                entity.Property(e => e.Series)
                    .IsRequired()
                    .HasColumnName("series")
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<PersonsTt>(entity =>
            {
                entity.ToTable("Persons_TT", "u0992410_vitek4051");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.AddressId).HasColumnName("addressID");

                entity.Property(e => e.Comment).HasColumnName("comment");

                entity.Property(e => e.Email)
                    .HasColumnName("email")
                    .HasMaxLength(50);

                entity.Property(e => e.FirstName)
                    .IsRequired()
                    .HasColumnName("firstName")
                    .HasMaxLength(50);

                entity.Property(e => e.LastName)
                    .IsRequired()
                    .HasColumnName("lastName")
                    .HasMaxLength(50);

                entity.Property(e => e.MiddleName)
                    .HasColumnName("middleName")
                    .HasMaxLength(50);

                entity.Property(e => e.Phone)
                    .IsRequired()
                    .HasColumnName("phone")
                    .HasMaxLength(50);

                entity.HasOne(d => d.Address)
                    .WithMany(p => p.PersonsTt)
                    .HasForeignKey(d => d.AddressId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Persons_TT_Addresses_TT");
            });

            modelBuilder.Entity<ServicesTt>(entity =>
            {
                entity.HasKey(e => new { e.ServiceValueId, e.OrderId });

                entity.ToTable("Services_TT", "u0992410_vitek4051");

                entity.Property(e => e.ServiceValueId).HasColumnName("serviceValueID");

                entity.Property(e => e.OrderId).HasColumnName("orderID");

                entity.Property(e => e.TimeSpan).HasColumnName("timeSpan");

                entity.HasOne(d => d.Order)
                    .WithMany(p => p.ServicesTt)
                    .HasForeignKey(d => d.OrderId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Services_TT_Orders_TT");

                entity.HasOne(d => d.ServiceValue)
                    .WithMany(p => p.ServicesTt)
                    .HasForeignKey(d => d.ServiceValueId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Services_TT_ServiceValues_TS");
            });

            modelBuilder.Entity<ServiceValuesTs>(entity =>
            {
                entity.ToTable("ServiceValues_TS", "u0992410_vitek4051");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnName("name")
                    .HasMaxLength(50);

                entity.Property(e => e.Sale)
                    .HasColumnName("sale")
                    .HasColumnType("decimal(18, 0)");
            });

            modelBuilder.Entity<TransactionsTt>(entity =>
            {
                entity.ToTable("Transactions_TT", "u0992410_vitek4051");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnName("name");

                entity.Property(e => e.Sale)
                    .HasColumnName("sale")
                    .HasColumnType("decimal(18, 0)");
            });

            modelBuilder.Entity<WorkDaysTt>(entity =>
            {
                entity.HasKey(e => new { e.MasterId, e.WorkDate });

                entity.ToTable("WorkDays_TT", "u0992410_vitek4051");

                entity.Property(e => e.MasterId).HasColumnName("masterID");

                entity.Property(e => e.WorkDate)
                    .HasColumnName("workDate")
                    .HasColumnType("date");

                entity.HasOne(d => d.Master)
                    .WithMany(p => p.WorkDaysTt)
                    .HasForeignKey(d => d.MasterId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_WorkDays_TT_Employees_TT");
            });
        }
    }
}
