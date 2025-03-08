using EF_Core.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EF_Core.Models
{
    public class Order
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public decimal TotalPrice { get; set; }
        public int TotalQuantity { get; set; }
        public OrderStatus Status { get; set; }

        public Client Client { get; set; }
        public int ClientId { get; set; }
        
        public ICollection<OrderItem> Items { get; set; }

    }
}
