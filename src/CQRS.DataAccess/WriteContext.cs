using CQRS.Contracts.Events;
using Microsoft.EntityFrameworkCore;


namespace CQRS.DataAccess
{
    public class WriteContext : DbContext
    {
        public DbSet<ItemBaseEvent> ItemEvents { get; set; }
        
        protected  override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Data Source=DESKTOP-JQOI1KG;database=CQRS-WriteDB;Integrated Security=True");
        }
    }
}
