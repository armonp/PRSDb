using Microsoft.EntityFrameworkCore;
using PRSDbLibrary.Models;
using System;

namespace PRSDbLibrary {
    public class AppDbContext : DbContext {

        public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<Vendor> Vendors { get; set; }
        public virtual DbSet<Product> Products { get; set; }
        public virtual DbSet<Request> Requests { get; set; }
        public virtual DbSet<RequestLine> RequestLines { get; set; }

        public AppDbContext() { }
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }
        protected override void OnConfiguring(DbContextOptionsBuilder builder) {
            if (!builder.IsConfigured) {
                builder.UseLazyLoadingProxies();
                var connStr = @"server=localhost\sqlexpress;database=PRSDb;trusted_connection=true;";
                builder.UseSqlServer(connStr);
            }
        }

        protected override void OnModelCreating(ModelBuilder model) {
            model.Entity<User>(u => {
                u.Property(x => x.Firstname).HasMaxLength(30).IsRequired();
                u.Property(x => x.Lastname).HasMaxLength(30).IsRequired();
                u.Property(x => x.Username).HasMaxLength(30).IsRequired();
                u.HasIndex(x => x.Username).IsUnique();
                u.Property(x => x.Phone).HasMaxLength(12);
                u.Property(x => x.Email).HasMaxLength(255);
            });
            model.Entity<Vendor>(v => {
                v.HasIndex(x => x.Code).IsUnique();
            });
            model.Entity<Product>(p => {
                p.HasIndex(x => x.PartNbr).IsUnique();
            });

        }
    }
}
