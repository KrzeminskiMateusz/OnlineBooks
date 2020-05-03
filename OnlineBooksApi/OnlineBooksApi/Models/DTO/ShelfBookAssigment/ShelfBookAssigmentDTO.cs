using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineBooksApi.Models.DTO.ShelfBookAssigment
{
    public class ShelfBookAssigmentDTO
    {
        public OnlyShelfDTO Shelf { get; set; }
        public BookAssigmentDTO Book { get; set; }
    }
}
