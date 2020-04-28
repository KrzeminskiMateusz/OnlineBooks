using AutoMapper;
using OnlineBooksApi.Models.DTO;
using OnlineBooksApi.Models.DTO.Author;
using OnlineBooksApi.Models.DTO.Book;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;

namespace OnlineBooksApi.Models.Mapper
{
    public class Profiles : Profile
    {
        public Profiles()
        {
            CreateMap<Author, AuthorDTO>();
            CreateMap<AuthorDTO, Author>();
            CreateMap<Book, AuthorBooksDTO>();
            CreateMap<Book, BookDTO>();
            CreateMap<BookDTO, Book>();
            CreateMap<Author, BookAuthorDTO>();
            CreateMap<AuthorCategoryAssigment, CategoryAssigmentDTO>();
            CreateMap<AuthorSubcategoryAssigment, SubcategoryAssigmentDTO>();
            CreateMap<ShelftAuthorAssigment, ShelftAssigmentDTO>();
            CreateMap<BookCategoryAssigment, CategoryAssigmentDTO>();
            CreateMap<BookSubcategoryAssigment, SubcategoryAssigmentDTO>();
            CreateMap<ShelfBookAssigment, ShelftAssigmentDTO>();
            CreateMap<Category, CategoryDTO>();
            CreateMap<Subcategory, SubcategoryDTO>();
            CreateMap<Shelf, ShelfDTO>();
        }     
    }
}
