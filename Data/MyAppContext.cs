using Microsoft.EntityFrameworkCore;
using TestApp.Models;

namespace TestApp.Data
{
    public class MyAppContext(DbContextOptions<MyAppContext> options) : DbContext(options)
    {
        

        // Intal value to x model
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            
            modelBuilder.Entity<ItemClient>().HasKey(ic => new
                {
                    ic.ItemId,
                    ic.ClientId
                    
                }
            );

            modelBuilder.Entity<ItemClient>().HasOne(i => i.Item).WithMany(ic => ic.ItemClients).HasForeignKey(i => i.ItemId);
            modelBuilder.Entity<ItemClient>().HasOne(c => c.Client).WithMany(ic => ic.ItemClients).HasForeignKey(c => c.ClientId);
            

            modelBuilder.Entity<Item>().HasData(
                new Item
                {
                    Id = 10,
                    name = "New Item PC",
                    price = 100,
                    SerialNumberID = 10
                }
            );
            modelBuilder.Entity<SerialNumber>().HasData(
                new SerialNumber
                {
                    Id = 1,
                    Name = "PC3455",
                    ItemId = 10
                }
            );
            modelBuilder.Entity<Catogery>().HasData(
                new Catogery
                {
                    Id = 1,
                    Name = "Electro",
                },
                new Catogery
                {
                    Id = 2,
                    Name = "Electro",
                }
            );



            base.OnModelCreating(modelBuilder);
        }
        public DbSet<Item> Items { get; set; }
        public DbSet<SerialNumber> SerialNumber { get; set; }
        public DbSet<Catogery> Catogery { get; set; }
    }
}