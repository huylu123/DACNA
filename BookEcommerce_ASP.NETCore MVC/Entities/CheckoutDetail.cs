using System;
using System.Collections.Generic;

#nullable disable

namespace BookEcommerce_ASP.NETCore_MVC.Entities
{
    public partial class CheckoutDetail
    {
        public int Id { get; set; }
        public int? CheckoutId { get; set; }
        public int? BookId { get; set; }
        public int? Quantity { get; set; }
        public double? Total { get; set; }

        public virtual Book Book { get; set; }
        public virtual Checkout Checkout { get; set; }
    }
}
