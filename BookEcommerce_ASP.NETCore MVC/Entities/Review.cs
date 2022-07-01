using System;
using System.Collections.Generic;

#nullable disable

namespace BookEcommerce_ASP.NETCore_MVC.Entities
{
    public partial class Review
    {
        public int Id { get; set; }
        public int? BookId { get; set; }
        public int? AccountId { get; set; }
        public string Comment { get; set; }

        public virtual Account Account { get; set; }
        public virtual Book Book { get; set; }
    }
}
