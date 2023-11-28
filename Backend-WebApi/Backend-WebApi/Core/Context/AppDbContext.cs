using Backend_WebApi.Core.Entities;
using Microsoft.EntityFrameworkCore;

namespace Backend_WebApi.Core.Context
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }
        public DbSet<Company> companies { get; set; }
        public DbSet<Job> Jobs { get; set; }
        public DbSet<Candidates> candidates { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Job>()
                .HasOne(job => job.Company)
                .WithMany(company => company.jobs)
                .HasForeignKey(job => job.CompanyId);
            modelBuilder.Entity<Candidates>()
                .HasOne(candidate => candidate.Job)
                .WithMany(job => job.Candidates)
                .HasForeignKey(candidate => candidate.JobID);
            modelBuilder.Entity<Company>()
                .Property(company => company.Size)
                .HasConversion<string>();
            modelBuilder.Entity<Job>()
                .Property(job => job.Level)
                .HasConversion<string>();
        }
    }
}
