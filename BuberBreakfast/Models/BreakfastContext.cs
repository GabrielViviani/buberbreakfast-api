namespace BuberBreakfast.Models
{
    using Microsoft.EntityFrameworkCore;
    using BuberBreakfast.Models;
    public class BreakfastContext : DbContext
    {
        public BreakfastContext(DbContextOptions options) : base(options)
        {
            
        }

        public DbSet<BreakfastModel> Breakfasts { get; set; }
    }
}
