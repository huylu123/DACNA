using System;
using System.Collections.Generic;

#nullable disable

namespace ClassLibrary_RepositoryDLL.Entities
{
    public partial class Publisher
    {
        public Publisher()
        {
            Books = new HashSet<Book>();
        }

        public int Id { get; set; }
        public string Publishname { get; set; }

        public virtual ICollection<Book> Books { get; set; }
    }
}
