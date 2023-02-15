using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Assignment2.Models;

namespace Assignment2.Data
{
    public class MyDBContext : DbContext
    {
        public MyDBContext (DbContextOptions<MyDBContext> options)
            : base(options)
        {
        }

        public DbSet<Assignment2.Models.UserModel> User { get; set; } = default!;
        public DbSet<Assignment2.Models.StudentModel> Student { get; set; } = default!;
        public DbSet<Assignment2.Models.TeacherModel> Teacher { get; set; } = default!;
        public DbSet<Assignment2.Models.ResourcesModel> Resources { get; set; } = default!;
        public DbSet<Assignment2.Models.RequestModel> Request { get; set; } = default!;
        public DbSet<Assignment2.Models.AllocationModel> Allocation { get; set; } = default!;
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<RequestModel>()
                .HasOne(res => res.Resource)
                .WithOne(req => req.Request)
                .HasForeignKey<RequestModel>(res => res.ResourceId);

            modelBuilder.Entity<StudentModel>()
                .HasOne(u => u.User)
                .WithOne(s => s.Student)
                .HasForeignKey<StudentModel>(u => u.UserId);

            modelBuilder.Entity<TeacherModel>()
                .HasOne(u => u.User)
                .WithOne(t => t.Teacher)
                .HasForeignKey<TeacherModel>(u => u.UserId);
        }
    }
}
