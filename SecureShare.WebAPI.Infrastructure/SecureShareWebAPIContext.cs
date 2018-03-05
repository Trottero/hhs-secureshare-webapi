using Microsoft.EntityFrameworkCore;
using SecureShare.WebApi.Core.Models;
using System;

namespace SecureShare.WebAPI.Infrastructure
{
    public class SecureShareWebAPIContext : DbContext
    {
        public SecureShareWebAPIContext (DbContextOptions<SecureShareWebAPIContext> options)
            : base(options)
        {
        }

        public DbSet<File> File { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<File>().ToTable("Files");
        }
    }
}
