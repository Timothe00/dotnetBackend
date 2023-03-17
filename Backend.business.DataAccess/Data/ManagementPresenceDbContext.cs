using Backend.business.DataAccess.Models;
using Microsoft.EntityFrameworkCore;
using System;
using static System.Formats.Asn1.AsnWriter;


namespace Backend.business.DataAccess.Data
{


    public class ManagementPresenceDbContext : DbContext
    {
        public virtual DbSet<Users> Users { get; set; }
        public virtual DbSet<Absence>? Absences { get; set; }
        public virtual DbSet<Admin>? Admins { get; set; }
        public virtual DbSet<Matters>? Matters { get; set; }
        public virtual DbSet<Role>? Roles { get; set; }
        public virtual DbSet<SessionCours>? SessionCours { get; set; }
        public virtual DbSet<Student>? Students { get; set; }
        public virtual DbSet<Teacher>? Teachers { get; set; }


        public ManagementPresenceDbContext()
        {

        }

        public ManagementPresenceDbContext(DbContextOptions<DbContext> options) : base(options)
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

            modelBuilder.Entity<Student>();
            modelBuilder.Entity<Teacher>();
            modelBuilder.Entity<Admin>();



            modelBuilder.Entity<Users>(o =>
            {
                o.HasKey(u => u.UserId);
                o.HasOne(r => r.Role)
                    .WithMany(u => u.Users)
                    .HasForeignKey(e => e.RoleId)
                    .IsRequired()
                    .OnDelete(DeleteBehavior.Cascade);
            });


            modelBuilder.Entity<Matters>(
              entity =>
              {
                  entity.HasKey(m => m.MatterId);
              }
           );

        //    modelBuilder.Entity<Absence>(o =>
        //    { 
        //      o.HasKey(a => a.AbsenceId);
        //      o.HasOne(r => r.Role)
        //         .WithMany(u => u.Users)
        //         .HasForeignKey(e => e.RoleId)
        //         .IsRequired()
        //         .OnDelete(DeleteBehavior.Cascade);
        //   });


          modelBuilder.Entity<SessionCours>(
             entity =>
             {
                 entity.HasKey(property => property.SessionCoursId);
             }
          );

        }




    }
}
