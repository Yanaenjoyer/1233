using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace WpfApp1.Models
{
    public partial class diplomContext : DbContext
    {
        public diplomContext()
        {
        }

        public diplomContext(DbContextOptions<diplomContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Buildings> Buildings { get; set; }
        public virtual DbSet<ComputerFacilities> ComputerFacilities { get; set; }
        public virtual DbSet<Department> Department { get; set; }
        public virtual DbSet<Employees> Employees { get; set; }
        public virtual DbSet<EmployeesDepartment> EmployeesDepartment { get; set; }
        public virtual DbSet<EquipmentTransfer> EquipmentTransfer { get; set; }
        public virtual DbSet<Orders> Orders { get; set; }
        public virtual DbSet<RepairRequests> RepairRequests { get; set; }
        public virtual DbSet<User> User { get; set; }
        public virtual DbSet<UserRepairRequests> UserRepairRequests { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Server=(local);Database=diplom;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Buildings>(entity =>
            {
                entity.HasKey(e => e.BuildingNumber)
                    .HasName("Unique_Identifier4");

                entity.Property(e => e.BuildingNumber)
                    .HasColumnName("Building_number")
                    .HasMaxLength(20);

                entity.Property(e => e.City)
                    .IsRequired()
                    .HasMaxLength(30);

                entity.Property(e => e.Home)
                    .IsRequired()
                    .HasMaxLength(30);

                entity.Property(e => e.Street)
                    .IsRequired()
                    .HasMaxLength(30);
            });

            modelBuilder.Entity<ComputerFacilities>(entity =>
            {
                entity.HasKey(e => new { e.SerialNumber, e.InventoryNumber, e.EmployeeId })
                    .HasName("Unique_Identifier2");

                entity.ToTable("Computer_Facilities");

                entity.Property(e => e.SerialNumber)
                    .HasColumnName("Serial_number")
                    .HasMaxLength(20);

                entity.Property(e => e.InventoryNumber)
                    .HasColumnName("Inventory_number")
                    .HasMaxLength(20);

                entity.Property(e => e.EmployeeId)
                    .HasColumnName("Employee_ID")
                    .HasMaxLength(20);

                entity.Property(e => e.Description).IsRequired();

                entity.Property(e => e.Type)
                    .IsRequired()
                    .HasMaxLength(30);

                entity.HasOne(d => d.Employee)
                    .WithMany(p => p.ComputerFacilities)
                    .HasForeignKey(d => d.EmployeeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Принадлежит");
            });

            modelBuilder.Entity<Department>(entity =>
            {
                entity.HasKey(e => new { e.DepartmentId, e.BuildingNumber })
                    .HasName("Unique_Identifier12");

                entity.Property(e => e.DepartmentId)
                    .HasColumnName("Department_ID")
                    .HasMaxLength(20);

                entity.Property(e => e.BuildingNumber)
                    .HasColumnName("Building_number")
                    .HasMaxLength(20);

                entity.Property(e => e.PersonNumber).HasColumnName("Person_number");

                entity.Property(e => e.SeatsNumber).HasColumnName("Seats_number");

                entity.HasOne(d => d.BuildingNumberNavigation)
                    .WithMany(p => p.Department)
                    .HasForeignKey(d => d.BuildingNumber)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Относится/Включает");
            });

            modelBuilder.Entity<Employees>(entity =>
            {
                entity.HasKey(e => e.EmployeeId)
                    .HasName("Unique_Identifier5");

                entity.Property(e => e.EmployeeId)
                    .HasColumnName("Employee_ID")
                    .HasMaxLength(20);

                entity.Property(e => e.City)
                    .IsRequired()
                    .HasMaxLength(30);

                entity.Property(e => e.FirstName)
                    .IsRequired()
                    .HasColumnName("First_name")
                    .HasMaxLength(30);

                entity.Property(e => e.Home)
                    .IsRequired()
                    .HasMaxLength(30);

                entity.Property(e => e.LastName)
                    .IsRequired()
                    .HasColumnName("Last_name")
                    .HasMaxLength(30);

                entity.Property(e => e.Patronymic)
                    .IsRequired()
                    .HasMaxLength(30);

                entity.Property(e => e.Phone)
                    .IsRequired()
                    .HasMaxLength(11);

                entity.Property(e => e.Street)
                    .IsRequired()
                    .HasMaxLength(30);
            });

            modelBuilder.Entity<EmployeesDepartment>(entity =>
            {
                entity.HasKey(e => new { e.DepartmentId, e.EmployeeId, e.BuildingNumber });

                entity.ToTable("Employees_Department");

                entity.Property(e => e.DepartmentId)
                    .HasColumnName("Department_ID")
                    .HasMaxLength(20);

                entity.Property(e => e.EmployeeId)
                    .HasColumnName("Employee_ID")
                    .HasMaxLength(20);

                entity.Property(e => e.BuildingNumber)
                    .HasColumnName("Building_number")
                    .HasMaxLength(20);

                entity.HasOne(d => d.BuildingNumberNavigation)
                    .WithMany(p => p.EmployeesDepartment)
                    .HasForeignKey(d => d.BuildingNumber)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Employees_Department_Buildings");

                entity.HasOne(d => d.Employee)
                    .WithMany(p => p.EmployeesDepartment)
                    .HasForeignKey(d => d.EmployeeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Employees_Department_Employees");
            });

            modelBuilder.Entity<EquipmentTransfer>(entity =>
            {
                entity.HasKey(e => new { e.DepartmentId, e.SerialNumber, e.InventoryNumber, e.BuildingNumber, e.EmployeeId })
                    .HasName("Unique_Identifier9");

                entity.ToTable("Equipment_Transfer");

                entity.Property(e => e.DepartmentId)
                    .HasColumnName("Department_ID")
                    .HasMaxLength(20);

                entity.Property(e => e.SerialNumber)
                    .HasColumnName("Serial_number")
                    .HasMaxLength(20);

                entity.Property(e => e.InventoryNumber)
                    .HasColumnName("Inventory_number")
                    .HasMaxLength(20);

                entity.Property(e => e.BuildingNumber)
                    .HasColumnName("Building_number")
                    .HasMaxLength(20);

                entity.Property(e => e.EmployeeId)
                    .HasColumnName("Employee_ID")
                    .HasMaxLength(20);

                entity.HasOne(d => d.Department)
                    .WithMany(p => p.EquipmentTransfer)
                    .HasForeignKey(d => new { d.DepartmentId, d.BuildingNumber })
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Передается_");

                entity.HasOne(d => d.ComputerFacilities)
                    .WithMany(p => p.EquipmentTransfer)
                    .HasForeignKey(d => new { d.SerialNumber, d.InventoryNumber, d.EmployeeId })
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Передается");
            });

            modelBuilder.Entity<Orders>(entity =>
            {
                entity.HasKey(e => new { e.EmployeeId, e.UserId, e.OrderId })
                    .HasName("Unique_Identifier8");

                entity.Property(e => e.EmployeeId)
                    .HasColumnName("Employee_ID")
                    .HasMaxLength(20);

                entity.Property(e => e.UserId)
                    .HasColumnName("User_ID")
                    .HasMaxLength(20);

                entity.Property(e => e.OrderId)
                    .HasColumnName("Order_ID")
                    .HasMaxLength(20);

                entity.Property(e => e.Type)
                    .IsRequired()
                    .HasMaxLength(30);

                entity.HasOne(d => d.User)
                    .WithMany(p => p.Orders)
                    .HasForeignKey(d => new { d.EmployeeId, d.UserId })
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Заказывает");
            });

            modelBuilder.Entity<RepairRequests>(entity =>
            {
                entity.HasKey(e => new { e.EmployeeId, e.UserId, e.RepairId })
                    .HasName("Unique_Identifier11");

                entity.ToTable("Repair_requests");

                entity.Property(e => e.EmployeeId)
                    .HasColumnName("Employee_ID")
                    .HasMaxLength(20);

                entity.Property(e => e.UserId)
                    .HasColumnName("User_ID")
                    .HasMaxLength(20);

                entity.Property(e => e.RepairId)
                    .HasColumnName("Repair_ID")
                    .HasMaxLength(20);

                entity.Property(e => e.Description).IsRequired();

                entity.HasOne(d => d.UserRepairRequests)
                    .WithMany(p => p.RepairRequests)
                    .HasForeignKey(d => new { d.EmployeeId, d.UserId })
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Relationship8");
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.HasKey(e => new { e.EmployeeId, e.UserId })
                    .HasName("Unique_Identifier1");

                entity.Property(e => e.EmployeeId)
                    .HasColumnName("Employee_ID")
                    .HasMaxLength(20);

                entity.Property(e => e.UserId)
                    .HasColumnName("User_ID")
                    .HasMaxLength(20);

                entity.Property(e => e.Login)
                    .IsRequired()
                    .HasMaxLength(30);

                entity.Property(e => e.Password)
                    .IsRequired()
                    .HasMaxLength(30);

                entity.Property(e => e.Role)
                    .IsRequired()
                    .HasMaxLength(15);

                entity.HasOne(d => d.Employee)
                    .WithMany(p => p.User)
                    .HasForeignKey(d => d.EmployeeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Является");
            });

            modelBuilder.Entity<UserRepairRequests>(entity =>
            {
                entity.HasKey(e => new { e.EmployeeId, e.UserId });

                entity.ToTable("User_Repair_requests");

                entity.Property(e => e.EmployeeId)
                    .HasColumnName("Employee_ID")
                    .HasMaxLength(20);

                entity.Property(e => e.UserId)
                    .HasColumnName("User_ID")
                    .HasMaxLength(20);

                entity.HasOne(d => d.User)
                    .WithOne(p => p.UserRepairRequests)
                    .HasForeignKey<UserRepairRequests>(d => new { d.EmployeeId, d.UserId })
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Создает");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
