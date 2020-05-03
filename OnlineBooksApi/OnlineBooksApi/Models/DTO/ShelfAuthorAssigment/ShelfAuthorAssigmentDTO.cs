using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineBooksApi.Models.DTO.ShelfAuthorAssigment
{
    public class ShelfAuthorAssigmentDTO
    {
        public OnlyShelfDTO Shelf { get; set; }
        public AuthorAssigmentDTO Author { get; set; }
    }
}
