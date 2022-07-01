using System;
using System.Collections.Generic;

#nullable disable

namespace BookEcommerce_ASP.NETCore_MVC.Entities
{
    public partial class Cart
    {
        public Cart()
        {
            CartItems = new HashSet<CartItem>();
        }

        public int Id { get; set; }
        public int? AccountId { get; set; }

        public virtual Account Account { get; set; }
        public virtual ICollection<CartItem> CartItems { get; set; }
    }
}
