using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ApplicationCore.Entities;

namespace Infrastructure.Data
{
    public class MvcProductContext : DbContext
    {
        public MvcProductContext(DbContextOptions<MvcProductContext> options)
             : base(options) { }

        public DbSet<ApplicationCore.Entities.Products> Products { get; set; } = default!;
    }
}
