using DataAccess.Entity;
using Helper.CookieCrypto;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{
    public class ApplicationDbContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<Bilet> Bilets { get; set; }
        public DbSet<Cart> Carts { get; set; }
        public DbSet<About> Abouts { get; set; }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<Role>().HasData(
                new Role
                {
                    Id = 1,
                    Name = "Admin",
                    CreatedDate = DateTime.Now,
                    CreatedAt = 1
                });

            modelBuilder.Entity<Role>().HasData(
                new Role
                {
                    Id = 2,
                    Name = "User",
                    CreatedDate = DateTime.Now,
                    CreatedAt = 1
                }
                );

            var salt = Crypto.GenerateSalt();

            modelBuilder.Entity<User>().HasData(
                new User
                {
                    Id = 1,
                    UserName = "Admin",
                    Salt = salt,
                    PasswordHash = Crypto.GenerateSHA256Hash("Admin123", salt),
                    RoleId = 1,
                    CreatedDate = DateTime.Now,
                    CreatedAt = 1
                }
                );
        }
    }
}
