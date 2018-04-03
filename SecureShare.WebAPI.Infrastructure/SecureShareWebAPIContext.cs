using System;
using Microsoft.EntityFrameworkCore;
using SecureShare.WebAPI.Core.Entities;

public class SecureShareWebAPIContext : DbContext
{
    public SecureShareWebAPIContext(DbContextOptions<SecureShareWebAPIContext> options)
        : base(options)
    {
    }
    public DbSet<UserFile> UserFile { get; set; }
    public DbSet<User> User { get; set; }
    public DbSet<Users_UserFiles> Users_UserFiles { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<UserFile>().ToTable("UserFiles");
        modelBuilder.Entity<User>().ToTable("Users");
        modelBuilder.Entity<Users_UserFiles>().ToTable("Users_UserFiles");

        modelBuilder.Entity<Users_UserFiles>().HasIndex(uu => new {uu.UserId, uu.UserFileId});

        modelBuilder.Entity<Users_UserFiles>()
            .HasOne(e => e.User)
            .WithMany(e => e.FilesSharedWithUser)
            .HasForeignKey(e => e.UserId).OnDelete(DeleteBehavior.Cascade);

        modelBuilder.Entity<Users_UserFiles>()
            .HasOne(e => e.UserFile)
            .WithMany(e => e.SharedWith)
            .HasForeignKey(e => e.UserFileId).OnDelete(DeleteBehavior.Restrict);

        modelBuilder.Entity<UserFile>().HasOne(e => e.Owner).WithMany().HasForeignKey(e => e.OwnerId);
    }
}
