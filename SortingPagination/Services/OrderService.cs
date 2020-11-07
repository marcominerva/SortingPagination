using Microsoft.EntityFrameworkCore;
using SortingPagination.DataAccess;
using SortingPagination.DataAccess.Entities;
using SortingPagination.Models;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Threading.Tasks;

namespace SortingPagination.Services
{
    public class OrderService : IOrderService
    {
        private readonly DataContext dataContext;

        public OrderService(DataContext dataContext)
        {
            this.dataContext = dataContext;
        }

        public async Task<ListResult<Order>> GetAsync(int pageIndex, int itemsPerPage, string orderBy)
        {
            var query = dataContext.Orders;
            var totalCount = await query.CountAsync();

            var orders = await query
                .OrderBy(orderBy)
                .Skip(pageIndex * itemsPerPage).Take(itemsPerPage + 1)
                .ToListAsync();

            var result = new ListResult<Order>(orders.Take(itemsPerPage), totalCount,
                orders.Count > itemsPerPage);

            return result;
        }
    }
}
