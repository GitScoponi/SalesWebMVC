using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace SalesWebMVC.Models
{
    public class SalesWebMVCContext : DbContext
    {
        public SalesWebMVCContext (DbContextOptions<SalesWebMVCContext> options)
            : base(options)
        {
        }

        public DbSet<SalesWebMVC.Models.Department> Department { get; set; }
        public DbSet<SalesWebMVC.Models.SalesRecord> SalesRecord { get; set; }
        public DbSet<SalesWebMVC.Models.Seller> Seller { get; set; }
    }
}
