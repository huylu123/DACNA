using System;
using System.Collections.Generic;

#nullable disable

namespace ClassLibrary_RepositoryDLL.Entities
{
    public partial class Account
    {
        public Account()
        {
            Carts = new HashSet<Cart>();
            Checkouts = new HashSet<Checkout>();
            Reviews = new HashSet<Review>();
        }

        public int Id { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public int RoleId { get; set; }
        public string Fullname { get; set; }
        public string Address { get; set; }
        public string Phone { get; set; }

        public virtual Role Role { get; set; }
        public virtual ICollection<Cart> Carts { get; set; }
        public virtual ICollection<Checkout> Checkouts { get; set; }
        public virtual ICollection<Review> Reviews { get; set; }
    }
}
