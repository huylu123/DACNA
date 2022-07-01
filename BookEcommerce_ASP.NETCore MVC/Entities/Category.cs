using System;
using System.Collections.Generic;

#nullable disable

namespace BookEcommerce_ASP.NETCore_MVC.Entities
{
    public partial class Category
    {
        public Category()
        {
            Books = new HashSet<Book>();
        }

        public int Id { get; set; }
        public string Categoryname { get; set; }

        public virtual ICollection<Book> Books { get; set; }
    }
}
