using System;

namespace SortingPagination.DataAccess.Entities
{
    public class Order
    {
        public int OrderId { get; set; }

        public string CustomerId { get; set; }

        public DateTime OrderDate { get; set; }

        public DateTime? ShippedDate { get; set; }

        public string ShipName { get; set; }

        public string ShipAddress { get; set; }

        public string ShipCity { get; set; }

        public string ShipPostalCode { get; set; }

        public string ShipCountry { get; set; }
    }
}
