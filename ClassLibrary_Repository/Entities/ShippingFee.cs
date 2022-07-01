using System;
using System.Collections.Generic;

#nullable disable

namespace ClassLibrary_RepositoryDLL.Entities
{
    public partial class ShippingFee
    {
        public ShippingFee()
        {
            Checkouts = new HashSet<Checkout>();
        }

        public int Id { get; set; }
        public string Location { get; set; }
        public double Fee { get; set; }

        public virtual ICollection<Checkout> Checkouts { get; set; }
    }
}
