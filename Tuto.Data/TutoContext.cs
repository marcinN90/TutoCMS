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
    }
}
