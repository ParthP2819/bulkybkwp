﻿using bulkybkwp.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace bulkybkwp.DataAccess
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        public DbSet<Category> categories { get; set; }
        public DbSet<CoverType> covertypes { get; set; }
        public DbSet<Product> products { get; set; }
        public DbSet<ApplicationUser> applicationUsers { get; set; }
        public DbSet<Company> companys { get; set; }
    }
}
