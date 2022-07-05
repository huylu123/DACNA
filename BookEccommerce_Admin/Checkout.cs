using System;
using System.Collections.Generic;

#nullable disable

namespace BookEccommerce_Admin
{
    public class Checkout
    {
        public int Id { get; set; }
        public int? AccountId { get; set; }
        public DateTime? CreateDate { get; set; }
       
        public int? ShippingfeeId { get; set; }
        

      
    }
}
