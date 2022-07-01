using System;
using System.Collections.Generic;

#nullable disable

namespace BookEcommerce_ASP.NETCore_MVC.Entities
{
    public partial class PaymentMethod
    {
        public PaymentMethod()
        {
            Checkouts = new HashSet<Checkout>();
        }

        public int Id { get; set; }
        public string Paymentname { get; set; }

        public virtual ICollection<Checkout> Checkouts { get; set; }
    }
}
