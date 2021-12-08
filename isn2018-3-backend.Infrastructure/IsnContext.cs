using isn2018_3_backend.Domain.Entity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace isn2018_3_backend.Infrastructure
{
    public class IsnContext : IdentityDbContext
    {
        public DbSet<Status> Statuses { get; set; }
        public DbSet<File> Files { get; set; }
        public DbSet<Project> Projects { get; set; }
        public DbSet<Priority> Priorities { get; set; }
        public DbSet<Domain.Entity.Task> Tasks { get; set; }
        public DbSet<UserProject> UserProjects { get; set; }

        public IsnContext(DbContextOptions options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Domain.Entity.Task>()
                .HasMany(a => a.File).WithOne(b => b.Task);

            builder.Entity<Domain.Entity.Task>()
                .HasMany(a => a.Priority).WithOne(b => b.Task);

            builder.Entity<Domain.Entity.Task>()
                .HasMany(a => a.Status).WithOne(b => b.Task);

            builder.Entity<Domain.Entity.Task>()
                .HasMany(a => a.Project).WithOne(b => b.Task);

            base.OnModelCreating(builder);
        }
    }
}
