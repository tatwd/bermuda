using System;

namespace Bermuda.Api.Models
{
    public class ShoppingCartViewModel
    {
        public long id { get; set; }
        public long user_id { get; set; }
        //public long product_id { get; set; }
        public ProductViewModel product { get; set; }
        public int quantity { get; set; }
        public DateTime created_at { get; set; }
    }
}
