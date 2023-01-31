﻿using bulkybkwp.Models;
using Microsoft.EntityFrameworkCore;

namespace bulkybkwp.DataAccess
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        public DbSet<Category> categories { get; set; }
        public DbSet<CoverType> covertypes { get; set; }
        public DbSet<Product> products { get; set; }
    }
}