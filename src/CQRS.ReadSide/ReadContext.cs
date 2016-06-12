using CQRS.ReadSide.Entities;
using Microsoft.EntityFrameworkCore;

namespace CQRS.ReadSide
{
    public class ReadContext : DbContext
    {
        public DbSet<ItemEntity> Items { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Data Source=DESKTOP-JQOI1KG;database=CQRS-ReadDB;Integrated Security=True");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ItemEntity>().HasKey(e => e.Id).HasName("PrimaryKey_Id"); 
            base.OnModelCreating(modelBuilder);
        }
    }
}
