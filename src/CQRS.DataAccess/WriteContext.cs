using CQRS.Contracts.Events;
using Microsoft.EntityFrameworkCore;


namespace CQRS.DataAccess
{
    public class WriteContext : DbContext
    {
        public virtual DbSet<ItemBaseEvent> ItemEvents { get; set; }
        public virtual DbSet<ItemUpdatedEvent> ItemUpdated { get; set; }
        public virtual DbSet<ItemAddedEvent> ItemAdded { get; set; }

        protected  override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Data Source=DESKTOP-JQOI1KG;database=CQRS-WriteDB;Integrated Security=True");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ItemBaseEvent>().HasKey(e => e.AggregateId).HasName("PrimaryKey_AggregateId");
            base.OnModelCreating(modelBuilder);
        }
    }
}
