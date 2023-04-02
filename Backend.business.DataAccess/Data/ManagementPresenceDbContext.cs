using Backend.business.DataAccess.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Net;
using static System.Formats.Asn1.AsnWriter;


namespace Backend.business.DataAccess.Data
{


    public class presenceManagementDbContext : DbContext
    {
        public virtual DbSet<Users>? Users { get; set; }
        public virtual DbSet<Absence>? Absences { get; set; }
        public virtual DbSet<Admin>? Admins { get; set; }
        public virtual DbSet<Matters>? Matters { get; set; }
        public virtual DbSet<Role>? Roles { get; set; }
        public virtual DbSet<SessionCours>? SessionCours { get; set; }
        public virtual DbSet<Permission>? Permissions { get; set; }
        public virtual DbSet<Student>? Students { get; set; }
        public virtual DbSet<Teacher>? Teachers { get; set; }
        public virtual DbSet<justificationAbsence>? justificationAbsences { get; set; }
        public virtual DbSet<MatterTeacher>? MatterTeachers  { get; set; }

        public presenceManagementDbContext()
        {

        }

        public presenceManagementDbContext(DbContextOptions<DbContext> options) : base(options)
        {

        }


        protected override void OnConfiguring(DbContextOptionsBuilder Dbcontextoptions)
        {
            if (!Dbcontextoptions.IsConfigured)
            {
                Dbcontextoptions.UseSqlServer("Server=DESKTOP-1MJGFMU;Database=DBPresenceManagement;Trusted_Connection=True;Encrypt=false;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);


            modelBuilder.Entity<Student>().ToTable("Student");
            modelBuilder.Entity<Teacher>().ToTable("Teacher");
            modelBuilder.Entity<Admin>().ToTable("Admin");

            modelBuilder.Entity<Student>(s => { });
            modelBuilder.Entity<Teacher>(t => { });
            modelBuilder.Entity<Admin>(a => { });



            modelBuilder.Entity<Users>(o =>
            {
                o.HasKey(u => u.UserId);
                o.HasOne(r => r.Role)
                    .WithMany(u => u.Users)
                    .HasForeignKey(e => e.RoleId)
                    .IsRequired()
                    .OnDelete(DeleteBehavior.Cascade);
            });


            modelBuilder.Entity<Role>(o =>
            {
                o.HasKey(r => r.RoleId);
            });


            modelBuilder.Entity<Matters>(o =>
            {
                o.HasKey(m => m.MatterId);
            });


            modelBuilder.Entity<SessionCours>(o =>
            {
                o.HasKey(s => s.SessionCoursId);
                o.HasOne(m => m.MatterTeacher)
                    .WithMany(s => s.SessionCours)
                    .HasForeignKey(e => e.MatterTeacherId)
                    .IsRequired()
                    .OnDelete(DeleteBehavior.Cascade);
                    
            });

            modelBuilder.Entity<MatterTeacher>(o =>
            {
                o.HasKey(s => s.MatterTeacherId);
                o.HasOne(m => m.Matters)
                    .WithMany(s => s.MatterTeachers)
                    .HasForeignKey(e => e.MatterId)
                    .IsRequired()
                    .OnDelete(DeleteBehavior.Cascade);
                    
                o.HasOne(m => m.Teachers)
                    .WithMany(s => s.MatterTeachers)
                    .HasForeignKey(e => e.TeacherId)
                    .IsRequired()
                    .OnDelete(DeleteBehavior.Cascade);
            });

            modelBuilder.Entity<Permission>(o =>
            {
                o.HasKey(pe => pe.PermissionId);
                o.HasOne(p => p.Student)
                    .WithMany(p => p.Permissions)
                    .HasForeignKey(e => e.StudentId)
                    .IsRequired()
                    .OnDelete(DeleteBehavior.Cascade);
            });


            modelBuilder.Entity<Absence>(o =>
            {
                o.HasKey(ps => ps.AbsenceId);

                o.HasOne(p => p.Student)
                    .WithMany(p => p.Absences)
                    .HasForeignKey(e => e.StudentId)
                    .IsRequired()
                    .OnDelete(DeleteBehavior.Cascade);

                o.HasOne(p => p.SessionCours)
                    .WithMany(p => p.Absences)
                    .HasForeignKey(e => e.SessionCoursId)
                    .IsRequired()
                    .OnDelete(DeleteBehavior.Cascade);
            });


            modelBuilder.Entity<justificationAbsence>(o =>
            {
                o.HasKey(pe => pe.JustificationId);

                o.HasOne(p => p.Students)
                    .WithMany(p => p.justificationAbsence)
                    .HasForeignKey(e => e.StudentId)
                    .IsRequired()
                    .OnDelete(DeleteBehavior.Cascade);
            });


            modelBuilder.Entity<Absence>()
                .HasOne(a => a.JustificationAbsence)
                .WithOne(jus => jus.Absence)
                .HasForeignKey<justificationAbsence>(a => a.AbsenceId);


        }




    }
}
