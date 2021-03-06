﻿using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineBooksApi.Models
{
    public class Author
    {
        public int Id { get; set; }
#nullable enable

        [StringLength(50, MinimumLength = 2)] 
        public string? FirstName { get; set; }

        [StringLength(50, MinimumLength = 2)]
        public string? LastName { get; set; }

        public string? FullName
        {
            get
            {
                return FirstName + " " + LastName;
            }
        }

        [StringLength(50, MinimumLength = 2)]
        public string? Nationality { get; set; }

        [DataType(DataType.Date)]
        [Column(TypeName = "date")]
        public DateTime? DataOfBirth { get; set; }

        [StringLength(50, MinimumLength = 2)]
        public string? PlaceOfBirth { get; set; }

        [StringLength(50, MinimumLength = 2)]
        public string? CountryOfBirth { get; set; }

        [DataType(DataType.Date)]
        [Column(TypeName = "date")]
        public DateTime? DateOfDeath { get; set; }

        [StringLength(50, MinimumLength = 2)]
        public string? PlaceOfDeath { get; set; }

        [StringLength(50, MinimumLength = 2)]
        public string? CountryOfDeath { get; set; }

        [StringLength(2000, MinimumLength = 10)]
        public string? Description { get; set; }

        public byte[]? Image { get; set; }

        public bool? IsAlive { get; set; }

        public IEnumerable<AuthorCategoryAssigment>? Categories { get; set; }

        public IEnumerable<AuthorSubcategoryAssigment>? Subcategories { get; set; }

        public IEnumerable<ShelfAuthorAssigment>? Shelves { get; set; }

        public IEnumerable<Book>? Books { get; set; }
#nullable disable
    }
}

