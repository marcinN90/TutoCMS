using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using Tuto.Data.Models;

namespace Tuto.Data
{
    public class TutoContext : IdentityDbContext<ApplicationUser>
    {
        public TutoContext(DbContextOptions<TutoContext> options) : base(options) { }

        public DbSet<Link> Link { get; set; }
        public DbSet<Category> Category { get; set; }
        public DbSet<Entry> EntryPost { get; set; }
        public DbSet<HomePageSettings> HomePageSettings { get; set; }
        public DbSet<WebsiteDetails> WebsiteDetails { get; set; }
        public DbSet<Image> Image { get; set; }
        
        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.HasDefaultSchema("dbo");
            base.OnModelCreating(builder);
        }
    }
}
