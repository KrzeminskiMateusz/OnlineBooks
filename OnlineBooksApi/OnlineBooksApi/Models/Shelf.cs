using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineBooksApi.Models
{
    public class Shelf
    {
        public int Id { get; set; }

        [Required]
        [StringLength(100, MinimumLength = 2)]
        public string Name { get; set; }

#nullable enable
       public IEnumerable<ShelfBookAssigment>? Books { get; set; }
        public IEnumerable<ShelftAuthorAssigment>? Authors { get; set; }
#nullable disable
    }
}
