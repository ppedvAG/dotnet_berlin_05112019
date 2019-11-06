using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace HalloWeb.Models
{
    public class BananenContext : DbContext
    {
        public BananenContext (DbContextOptions<BananenContext> options)
            : base(options)
        {
            this.Database.EnsureCreated();
        }

        public DbSet<HalloWeb.Models.Banane> Banane { get; set; }
    }
}
