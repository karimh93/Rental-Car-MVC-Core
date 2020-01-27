using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace CarRent.Entities
{
    public partial class CarRentContext : DbContext
    {
        public CarRentContext()
        {
        }

        public CarRentContext(DbContextOptions<CarRentContext> options)
            : base(options)
        {
        }

        public virtual DbSet<CarRentRegister> CarRentRegister { get; set; }
        public virtual DbSet<Cars> Cars { get; set; }
        public virtual DbSet<Coupons> Coupons { get; set; }
        public virtual DbSet<Customers> Customers { get; set; }
        public virtual DbSet<Permissions> Permissions { get; set; }
        public virtual DbSet<ReservationStatuses> ReservationStatuses { get; set; }
        public virtual DbSet<Reservations> Reservations { get; set; }
        public virtual DbSet<Roles> Roles { get; set; }
        public virtual DbSet<Users> Users { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=CarR;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<CarRentRegister>(entity =>
            {
                entity.HasKey(e => e.CarRentId)
                    .HasName("RolesPermissions_pk");

                entity.Property(e => e.CarRentId).HasColumnName("CarRentID");

                entity.Property(e => e.CarModel)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.City)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.ClientId).HasColumnName("ClientID");

                entity.Property(e => e.EndDate).HasColumnType("date");

                entity.Property(e => e.StartDate).HasColumnType("date");

                entity.HasOne(d => d.Client)
                    .WithMany(p => p.CarRentRegister)
                    .HasForeignKey(d => d.ClientId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__CarRentReg__City__4222D4EF");
            });

            modelBuilder.Entity<Cars>(entity =>
            {
                entity.HasKey(e => e.CarId)
                    .HasName("Cars_pk");

                entity.Property(e => e.CarId).HasColumnName("CarID");

                entity.Property(e => e.Manufacturer)
                    .IsRequired()
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.Model)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Plate)
                    .IsRequired()
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.PricePerDay).HasColumnType("money");
            });

            modelBuilder.Entity<Coupons>(entity =>
            {
                entity.HasKey(e => e.CouponCode)
                    .HasName("Coupons_pk");

                entity.Property(e => e.CouponCode)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.Description)
                    .IsRequired()
                    .HasColumnType("ntext");

                entity.Property(e => e.Discount).HasColumnType("decimal(4, 2)");
            });

            modelBuilder.Entity<Customers>(entity =>
            {
                entity.HasKey(e => e.CostumerId)
                    .HasName("Customers_pk");

                entity.Property(e => e.CostumerId).HasColumnName("CostumerID");

                entity.Property(e => e.BirthDate).HasColumnType("date");

                entity.Property(e => e.Location)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Permissions>(entity =>
            {
                entity.HasKey(e => e.PermissionId)
                    .HasName("Permissions_pk");

                entity.Property(e => e.PermissionId).HasColumnName("PermissionID");

                entity.Property(e => e.Description)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(10)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<ReservationStatuses>(entity =>
            {
                entity.HasKey(e => e.ReservStatsId)
                    .HasName("ReservationStatuses_pk");

                entity.Property(e => e.ReservStatsId)
                    .HasColumnName("ReservStatsID")
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.Description)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Reservations>(entity =>
            {
                entity.HasKey(e => new { e.CarId, e.CostumerId })
                    .HasName("Reservations_pk");

                entity.Property(e => e.CarId).HasColumnName("CarID");

                entity.Property(e => e.CostumerId).HasColumnName("CostumerID");

                entity.Property(e => e.CouponCode)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.EndDate).HasColumnType("date");

                entity.Property(e => e.Location)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.ReservStatsId).HasColumnName("ReservStatsID");

                entity.Property(e => e.StartDate).HasColumnType("date");

                entity.HasOne(d => d.Car)
                    .WithMany(p => p.Reservations)
                    .HasForeignKey(d => d.CarId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Reservations_Cars");

                entity.HasOne(d => d.Costumer)
                    .WithMany(p => p.Reservations)
                    .HasForeignKey(d => d.CostumerId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Reservations_Customers");

                entity.HasOne(d => d.CouponCodeNavigation)
                    .WithMany(p => p.Reservations)
                    .HasForeignKey(d => d.CouponCode)
                    .HasConstraintName("Reservations_Coupons");

                entity.HasOne(d => d.ReservStats)
                    .WithMany(p => p.Reservations)
                    .HasForeignKey(d => d.ReservStatsId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Reservations_ReservationStatuses");
            });

            modelBuilder.Entity<Roles>(entity =>
            {
                entity.HasKey(e => e.RoleId)
                    .HasName("Roles_pk");

                entity.Property(e => e.RoleId).HasColumnName("RoleID");

                entity.Property(e => e.Description)
                    .IsRequired()
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Users>(entity =>
            {
                entity.HasKey(e => e.UserId)
                    .HasName("Users_pk");

                entity.Property(e => e.UserId).HasColumnName("UserID");

                entity.Property(e => e.Password)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.RoleId).HasColumnName("RoleID");

                entity.HasOne(d => d.Role)
                    .WithMany(p => p.Users)
                    .HasForeignKey(d => d.RoleId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Users_Roles");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
