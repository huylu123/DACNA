using System;
using System.Collections.Generic;

#nullable disable

namespace BookEcommerce_ASP.NETCore_MVC.Entities
{
    public partial class CartItem
    {
        public int Id { get; set; }
        public int CartId { get; set; }
        public int BookId { get; set; }
        public double? Price { get; set; }
        public int? Quantity { get; set; }

        public virtual Book Book { get; set; }
        public virtual Cart Cart { get; set; }
    }
}
