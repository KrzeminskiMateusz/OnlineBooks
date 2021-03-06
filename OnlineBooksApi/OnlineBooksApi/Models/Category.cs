﻿using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineBooksApi.Models
{
    public class Category
    {
        // Znaleźć atrybut sprawdzający unikalność categoryName w bazie
        public int Id { get; set; }

        [Required]
        [StringLength(100, MinimumLength = 2)]
        public string Name { get; set; }

#nullable enable
        public IEnumerable<BookCategoryAssigment>? Books { get; set; }

        public IEnumerable<AuthorCategoryAssigment>? Authors { get; set; }

        public IEnumerable<CategorySubcategoryAssigment>? Subcategories { get; set; }
#nullable disable
    }
}
