using System;
using System.Net.Mail;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using AT.Model.Common;

namespace AT.DataAccess.Data
{
    public class ATDbContext : DbContext
    {
        private readonly IConfiguration configuration;

        public ATDbContext () {}

        public ATDbContext (DbContextOptions Options, IConfiguration Configuration) : base(Options) 
        {
            configuration = Configuration;
        }

        protected override void  OnConfiguring(DbContextOptionsBuilder optionsBuilder) 
        {
            if(!optionsBuilder.IsConfigured)
            { 
                optionsBuilder.UseSqlServer(configuration.GetConnectionString("DefaultConnection"));
            }
        }

        public virtual DbSet<User> Users{get;set;}
        public virtual DbSet<Product> Products{get;set;}
        public virtual DbSet<ProductType> ProductTypes{get;set;}
        public DbSet<Student> Students { get; set; }
        public DbSet<Course> Courses { get; set; }
        public DbSet<StudentCourse> StudentCourses { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            #region ProductType
            modelBuilder.Entity<ProductType>().HasData(new ProductType {Id = 1, ProductTypeName = "Type1"});
            modelBuilder.Entity<ProductType>().HasData(new ProductType {Id = 2, ProductTypeName = "Type2"});
            modelBuilder.Entity<ProductType>().HasData(new ProductType {Id = 3, ProductTypeName = "Type3"});
            
            modelBuilder.Entity<StudentCourse>().HasKey(sc => new { sc.StudentId, sc.CourseId });

            modelBuilder.Entity<StudentCourse>()
                .HasOne<Student>(sc => sc.Student)
                .WithMany(s => s.StudentCourses)
                .HasForeignKey(sc => sc.StudentId);


            modelBuilder.Entity<StudentCourse>()
                .HasOne<Course>(sc => sc.Course)
                .WithMany(s => s.StudentCourses)
                .HasForeignKey(sc => sc.CourseId);
            #endregion
        }
    }
}