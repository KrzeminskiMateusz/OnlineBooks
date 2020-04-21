using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineBooksApi.Models
{
    public class ShelfBookAssigment
    {
        public int ShelfId { get; set; }
        public int BookId { get; set; }

        public Shelf Shelf { get; set; }
        public Book Book { get; set; }
    }
}
