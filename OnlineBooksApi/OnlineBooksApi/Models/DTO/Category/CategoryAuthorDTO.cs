using OnlineBooksApi.Models.DTO.Author;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineBooksApi.Models.DTO.Category
{
    public class CategoryAuthorDTO
    {
#nullable enable
        public long Id { get; set; }

        public string? FirstName { get; set; }

        public string? LastName { get; set; }

        public string? Nationality { get; set; }

        public DateTime? DataOfBirth { get; set; }

        public string? PlaceOfBirth { get; set; }

        public string? CountryOfBirth { get; set; }

        public DateTime? DateOfDeath { get; set; }

        public string? PlaceOfDeath { get; set; }

        public string? CountryOfDeath { get; set; }

        public string? Description { get; set; }

        public byte[]? Image { get; set; }

        public bool? IsAlive { get; set; }

        public IEnumerable<CategoryAssigmentDTO>? Categories { get; set; }

        public IEnumerable<SubcategoryAssigmentDTO>? Subcategories { get; set; }

        public IEnumerable<ShelftAssigmentDTO>? Shelves { get; set; }
#nullable disable
    }
}
