﻿using Microsoft.EntityFrameworkCore;
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
        public DbSet<Entry> EntryPart { get; set; }
        public DbSet<HomePageSettings> HomePageSettings { get; set; }
        public DbSet<Link> WebsiteDetails { get; set; }
    }
}