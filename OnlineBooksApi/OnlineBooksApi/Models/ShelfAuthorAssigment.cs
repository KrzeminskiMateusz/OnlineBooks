using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineBooksApi.Models
{
    public class ShelfAuthorAssigment
    {
        public int ShelfId { get; set; }
        public int AuthorId { get; set; }

        public Shelf Shelf { get; set; }
        public Author Author { get; set; }
    }
}
