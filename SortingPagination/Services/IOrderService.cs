using SortingPagination.DataAccess.Entities;
using SortingPagination.Models;
using System.Threading.Tasks;

namespace SortingPagination.Services
{
    public interface IOrderService
    {
        Task<ListResult<Order>> GetAsync(int pageIndex, int itemsPerPage, string orderBy);
    }
}