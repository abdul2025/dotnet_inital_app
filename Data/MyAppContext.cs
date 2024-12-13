using Microsoft.EntityFrameworkCore;
using TestApp.Models;

namespace TestApp.Data
{
    public class MyAppContext(DbContextOptions<MyAppContext> options) : DbContext(options)
    {
        public DbSet<Item> Items { get; set; }
    }
}