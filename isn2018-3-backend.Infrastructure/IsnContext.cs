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

        public IsnContext(DbContextOptions options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<File>()
                .HasOne(a => a.Task).WithOne(b => b.File)
                .HasForeignKey<File>(e => e.TaskId);

            builder.Entity<Domain.Entity.Task>()
                .HasOne(a => a.Priority).WithOne(b => b.Task)
                .HasForeignKey<Domain.Entity.Task>(e => e.PriorityId);

            builder.Entity<Domain.Entity.Task>()
                .HasOne(a => a.Status).WithOne(b => b.Task)
                .HasForeignKey<Domain.Entity.Task>(e => e.StatusId);

            builder.Entity<Domain.Entity.Task>()
                .HasOne(a => a.Project).WithOne(b => b.Task)
                .HasForeignKey<Domain.Entity.Task>(e => e.ProjectId);

            base.OnModelCreating(builder);
        }
    }
}
