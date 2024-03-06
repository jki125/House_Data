using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using House_Data.Models;

namespace House_Data.Data
{
    public class House_DataContext : DbContext
    {
        public House_DataContext (DbContextOptions<House_DataContext> options)
            : base(options)
        {
        }

        public DbSet<House_Data.Models.House> House { get; set; } = default!;
    }
}
