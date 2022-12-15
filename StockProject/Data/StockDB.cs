using Microsoft.EntityFrameworkCore;
using StockProject.Models;

namespace StockProject.Data
{
    public class StockDB : DbContext
    {
        public StockDB()
        {

        }

        public StockDB(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Item> Items { get; set; }
        public DbSet<Store> Stores { get; set; }
    }
}
