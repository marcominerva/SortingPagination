using Dapper;
using Microsoft.Data.SqlClient;
using SortingPagination.DataAccess.Entities;
using SortingPagination.Models;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace SortingPagination.Services
{
    public class DapperOrderService : IOrderService, IDisposable
    {
        private readonly SqlConnection connection;

        public DapperOrderService(string connectionString) => connection = new SqlConnection(connectionString);

        public async Task<ListResult<Order>> GetAsync(int pageIndex, int itemsPerPage, string orderBy)
        {
            var query = "SELECT COUNT(*) FROM Orders";
            var totalCount = await connection.ExecuteScalarAsync<int>(query);

            query = "SELECT OrderId, CustomerId, OrderDate, ShippedDate, ShipName, ShipAddress, ShipCity, ShipPostalCode, ShipCountry " +
                        "FROM Orders " +
                        $"ORDER BY {orderBy} " +
                        "OFFSET @offset ROWS FETCH NEXT @itemsPerPage ROWS ONLY";

            var orders = await connection.QueryAsync<Order>(query, new
            {
                Offset = pageIndex * itemsPerPage,
                ItemsPerPage = itemsPerPage + 1
            });

            var result = new ListResult<Order>(orders.Take(itemsPerPage), totalCount, orders.Count() > itemsPerPage);
            return result;
        }

        public void Dispose()
        {
            connection.Dispose();
            GC.SuppressFinalize(this);
        }
    }
}
