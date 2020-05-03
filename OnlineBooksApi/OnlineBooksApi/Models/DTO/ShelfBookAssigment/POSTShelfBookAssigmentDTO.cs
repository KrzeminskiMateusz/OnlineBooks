using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineBooksApi.Models.DTO.ShelfBookAssigment
{
    public class POSTShelfBookAssigmentDTO
    {
        public int ShelfId { get; set; }
        public int BookId { get; set; }
    }
}
