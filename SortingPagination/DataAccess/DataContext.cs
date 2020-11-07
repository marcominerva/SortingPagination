using Microsoft.EntityFrameworkCore;
using SortingPagination.DataAccess.Entities;

namespace SortingPagination.DataAccess
{
    public class DataContext : DbContext
    {
        public DbSet<Order> Orders { get; set; }

        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
        }
    }
}
