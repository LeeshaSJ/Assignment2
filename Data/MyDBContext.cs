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

        public DbSet<Assignment2.Models.UserModel> UserModel { get; set; } = default!;
        public DbSet<Assignment2.Models.Resources> Resources { get; set; } = default!;
        public DbSet<Assignment2.Models.Request> Request { get; set; } = default!;
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Request>()
                .HasOne(res => res.Resource)
                .WithOne(req => req.Request)
                .HasForeignKey<Request>(res => res.ResourceId);
        }
    }
}
