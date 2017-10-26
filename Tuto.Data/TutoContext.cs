using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Tuto.Data
{
    public class TutoContext : DbContext
    {
        public TutoContext(DbContextOptions options) : base(options) { }

    }
}
