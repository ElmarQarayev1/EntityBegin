using System;
using EntityBegin.Models;
using Microsoft.EntityFrameworkCore;

namespace EntityBegin.DAL
{
	public class AppDbContext:DbContext
	{
        public DbSet<Brand> Brands { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=localhost;Database=company;User ID=sa; Password=reallyStrongPwd123;TrustServerCertificate=true;");
        }
    }
}

