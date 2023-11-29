using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace time
{
    public partial class Ivanova_AS41_courseContext : DbContext
    {
        public Ivanova_AS41_courseContext()
        {
        }

        public Ivanova_AS41_courseContext(DbContextOptions<Ivanova_AS41_courseContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Department> Departments { get; set; }
        public virtual DbSet<DepartmentExpousesView> DepartmentExpousesViews { get; set; }
        public virtual DbSet<Employee> Employees { get; set; }
        public virtual DbSet<EmployeesView> EmployeesViews { get; set; }
        public virtual DbSet<Expense> Expenses { get; set; }
        public virtual DbSet<ExpenseType> ExpenseTypes { get; set; }
        public virtual DbSet<ExpensesView> ExpensesViews { get; set; }
        public virtual DbSet<Limit> Limits { get; set; }
        public virtual DbSet<LimitsView> LimitsViews { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Data Source=LAPTOP-SI1BVELI;Initial Catalog=Ivanova_AS41_course;Integrated Security=True");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "Cyrillic_General_CI_AS");

            modelBuilder.Entity<Department>(entity =>
            {
                entity.Property(e => e.Name)
                    .IsRequired()
                    .IsUnicode(false);
            });

            modelBuilder.Entity<DepartmentExpousesView>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("DepartmentExpousesView");

                entity.Property(e => e.DepartmentName)
                    .IsRequired()
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Employee>(entity =>
            {
                entity.Property(e => e.FirstName)
                    .IsRequired()
                    .IsUnicode(false);

                entity.Property(e => e.LastName)
                    .IsRequired()
                    .IsUnicode(false);

                entity.Property(e => e.Patronymic)
                    .IsRequired()
                    .IsUnicode(false);

                entity.HasOne(d => d.Department)
                    .WithMany(p => p.Employees)
                    .HasForeignKey(d => d.DepartmentId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Employees_Departments");
            });

            modelBuilder.Entity<EmployeesView>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("EmployeesView");

                entity.Property(e => e.DepartmentName)
                    .IsRequired()
                    .IsUnicode(false);

                entity.Property(e => e.FirstName)
                    .IsRequired()
                    .IsUnicode(false);

                entity.Property(e => e.LastName)
                    .IsRequired()
                    .IsUnicode(false);

                entity.Property(e => e.Patronymic)
                    .IsRequired()
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Expense>(entity =>
            {
                entity.Property(e => e.Date).HasColumnType("date");

                entity.HasOne(d => d.Employee)
                    .WithMany(p => p.Expenses)
                    .HasForeignKey(d => d.EmployeeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Expenses_Departments");

                entity.HasOne(d => d.Type)
                    .WithMany(p => p.Expenses)
                    .HasForeignKey(d => d.TypeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Expenses_ExpenseTypes");
            });

            modelBuilder.Entity<ExpenseType>(entity =>
            {
                entity.Property(e => e.Description).IsUnicode(false);

                entity.Property(e => e.Name)
                    .IsRequired()
                    .IsUnicode(false);
            });

            modelBuilder.Entity<ExpensesView>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("ExpensesView");

                entity.Property(e => e.Date).HasColumnType("date");

                entity.Property(e => e.DepartmentName)
                    .IsRequired()
                    .IsUnicode(false);

                entity.Property(e => e.Description).IsUnicode(false);

                entity.Property(e => e.FirstName)
                    .IsRequired()
                    .IsUnicode(false);

                entity.Property(e => e.LastName)
                    .IsRequired()
                    .IsUnicode(false);

                entity.Property(e => e.Patronymic)
                    .IsRequired()
                    .IsUnicode(false);

                entity.Property(e => e.TypeName)
                    .IsRequired()
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Limit>(entity =>
            {
                entity.Property(e => e.Date).HasColumnType("date");

                entity.HasOne(d => d.Department)
                    .WithMany(p => p.Limits)
                    .HasForeignKey(d => d.DepartmentId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Limits_Departments");
            });

            modelBuilder.Entity<LimitsView>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("LimitsView");

                entity.Property(e => e.Date).HasColumnType("date");

                entity.Property(e => e.DepartmentName)
                    .IsRequired()
                    .IsUnicode(false);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
