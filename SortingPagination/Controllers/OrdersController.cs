using Microsoft.AspNetCore.Mvc;
using SortingPagination.DataAccess.Entities;
using SortingPagination.Models;
using SortingPagination.Services;
using System.Net.Mime;
using System.Threading.Tasks;

namespace SortingPagination.Controllers
{
    [ApiController]
    [Route("[controller]")]
    [Produces(MediaTypeNames.Application.Json)]
    public class OrdersController : ControllerBase
    {
        private readonly IOrderService orderService;

        public OrdersController(IOrderService orderService)
        {
            this.orderService = orderService;
        }

        [HttpGet]
        public async Task<ListResult<Order>> Get(int pageIndex = 0, int itemsPerPage = 50, string orderBy = "OrderDate DESC")
        {
            var orders = await orderService.GetAsync(pageIndex, itemsPerPage, orderBy);
            return orders;
        }
    }
}
