using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace Practical.Models
{
    public partial class Exam_ASPNetContext : DbContext
    {
        public Exam_ASPNetContext()
        {
        }

        public Exam_ASPNetContext(DbContextOptions<Exam_ASPNetContext> options)
            : base(options)
        {
        }

        public virtual DbSet<ExamStudent> ExamStudents { get; set; }
        public virtual DbSet<HtUser> HtUsers { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Data Source=DESKTOP-8JPNURT;Initial Catalog=Exam_ASPNet;Integrated Security=True");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");

            modelBuilder.Entity<ExamStudent>(entity =>
            {
                entity.HasKey(e => e.StudentId)
                    .HasName("PK__examStud__32C52A790CDC6838");

                entity.ToTable("examStudent");

                entity.Property(e => e.StudentId).HasColumnName("StudentID");

                entity.Property(e => e.Email).HasMaxLength(50);

                entity.Property(e => e.FirstName).HasMaxLength(50);

                entity.Property(e => e.LastName).HasMaxLength(50);

                entity.Property(e => e.PhoneNumber).HasMaxLength(20);
            });

            modelBuilder.Entity<HtUser>(entity =>
            {
                entity.HasKey(e => e.UserId);

                entity.ToTable("htUsers");

                entity.Property(e => e.UserId).HasColumnName("UserID");

                entity.Property(e => e.Active).HasDefaultValueSql("((1))");

                entity.Property(e => e.Admin).HasDefaultValueSql("((0))");

                entity.Property(e => e.Email).HasMaxLength(200);

                entity.Property(e => e.FullName)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.PassWord)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.UserName)
                    .IsRequired()
                    .HasMaxLength(50);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
