using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using Tuto.Data.Models;

namespace Tuto.Data
{
    public class TutoContext : DbContext
    {
        public TutoContext(DbContextOptions options) : base(options) { }

        public DbSet<Link> Link { get; set; }
        public DbSet<Category> Category { get; set; }
        public DbSet<Entry> Entry { get; set; }
        public DbSet<HomePageSettings> HomePageSettings { get; set; }
        public DbSet<WebsiteDetails> WebsiteDetails { get; set; }
        
        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.HasDefaultSchema("dbo");
            base.OnModelCreating(builder);
        }
    }
}
