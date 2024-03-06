using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using House_Data.Models;

namespace House_Data.Data
{
    /*
     Add-Migration [name]
     Update-Database


     */
    public class House_DataContext : DbContext
    {
        private string _dbConnectString = "Server=USER-PC\\SQLEXPRESS;Database=house_data;User ID=house_user;Password=BnNm2nye;TrustServerCertificate=true;Trusted_Connection=True;MultipleActiveResultSets=true";
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(_dbConnectString);
        }
        public House_DataContext (DbContextOptions<House_DataContext> options)
            : base(options)
        {
        }

        public DbSet<House_Data.Models.House> House { get; set; } = default!;
        public DbSet<House_Data.Models.Order> Order { get; set; } = default!;
        public DbSet<House_Data.Models.Sales> Sales { get; set; } = default!;
    }
}
