using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EF_Core.Models
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int Quantity { get; set; }
        public decimal Price { get; set; }
        
        public int CategoryId { get; set; }
        public Category Category { get; set; }

        public int VendorId { get; set; }
        public Vendor Vendor { get; set; }
        public bool IsDelated { get; set; }
        public DateTime CreatedAt { get; set; }
        public ICollection<ProductAttachment> Attachments { get; set; }
        public ICollection<OrderItem> OrderItems { get; set; }
    }
}
