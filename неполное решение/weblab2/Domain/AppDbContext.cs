using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using weblab2.Domain.Entities;

namespace weblab2.Domain
{
    public class AppDbContext : IdentityDbContext<IdentityUser>
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<TextField> TextFields { get; set; }
        public DbSet<Serviceitem> Serviceitems { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.Entity<IdentityRole>().HasData(new IdentityRole
            { 
                Id = "12ac451e-14ef-d214-5dc2-157d2afb2356",
                Name = "admin",
                NormalizedName = "ADMIN",
            });

            builder.Entity<IdentityUser>().HasData(new IdentityUser
            {
                Id = "35ac3262-e5ff-45fa-5dc2-157d2af17356",
                UserName = "admin",
                NormalizedUserName = "ADMIN",
                Email = "my@mail.com",
                NormalizedEmail = "MY@MAIL.COM",
                EmailConfirmed = true,
                PasswordHash = new PasswordHasher<IdentityUser>().HashPassword(null, "superpassword"),
                SecurityStamp = string.Empty
                
            });

            builder.Entity<IdentityUserRole<string>>().HasData(new IdentityUserRole<string>
            {
                RoleId = "12ac451e-14ef-d214-5dc2-157d2afb2356",
                UserId = "35ac3262-e5ff-45fa-5dc2-157d2af17356"
            });

            builder.Entity<TextField>().HasData(new TextField
            {
                Id =  new Guid("d5ac3e62-f52f-452a-52c6-152d23f17656"),
                CodeWord = "PageIndex",
                Title = "Home"
            });
            builder.Entity<TextField>().HasData(new TextField
            {
                Id = new Guid("3bff3022-a5f2-f53a-51c2-127d2af1f356"),
                CodeWord = "PageService",
                Title = "Our books"
            });

            builder.Entity<TextField>().HasData(new TextField
            {
                Id = new Guid("a5df32e2-a52f-45fa-9db2-8f7d2af123a6"),
                CodeWord = "PageContacts",
                Title = "Contacts"
            });




        }

    }
}
