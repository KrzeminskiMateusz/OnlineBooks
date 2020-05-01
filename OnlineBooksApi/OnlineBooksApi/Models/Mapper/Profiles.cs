using AutoMapper;
using OnlineBooksApi.Models.DTO;
using OnlineBooksApi.Models.DTO.Author;
using OnlineBooksApi.Models.DTO.AuthorCategoryAssigment;
using OnlineBooksApi.Models.DTO.AuthorSubcategoryAssigment;
using OnlineBooksApi.Models.DTO.Book;
using OnlineBooksApi.Models.DTO.Category;
using OnlineBooksApi.Models.DTO.Shelf;
using OnlineBooksApi.Models.DTO.Subcategory;
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
            CreateMap<Category, OnlyCategoryDTO>();
            CreateMap<Subcategory, OnlySubcategoryDTO>();
            CreateMap<Shelf, OnlyShelfDTO>();

            CreateMap<Category, CategoryDTO>();
            CreateMap<CategoryDTO, Category>();
            CreateMap<BookCategoryAssigment, CategoryBookAssigmentDTO>();
            CreateMap<AuthorCategoryAssigment, CategoryAuthorAssigmentDTO>();
            CreateMap<Author, CategoryAuthorDTO>();
            CreateMap<Book, CategoryBookDTO>();
            CreateMap<CategorySubcategoryAssigment, SubcategoryAssigmentDTO>();

            CreateMap<Subcategory, SubcategoryDTO>();
            CreateMap<SubcategoryDTO, Subcategory>();
            CreateMap<CategorySubcategoryAssigment, CategoryAssigmentDTO>();
            CreateMap<Author, SubcategoryAuthorDTO>();
            CreateMap<Book, SubcategoryBookDTO>();
            CreateMap<AuthorSubcategoryAssigment, SubcategoryAuthorAssigmentDTO>();
            CreateMap<BookSubcategoryAssigment, SubcategoryBookAssigmentDTO>();

            CreateMap<Shelf, ShelfDTO>();
            CreateMap<ShelfDTO, Shelf>();
            CreateMap<ShelfBookAssigment, ShelfBookAssigmentDTO>();
            CreateMap<ShelftAuthorAssigment, ShelfAuthorAssigmentDTO>();
            CreateMap<Book, ShelfBookDTO>();
            CreateMap<Author, ShelfAuthroDTO>();

            CreateMap<AuthorCategoryAssigment, AuthorCategoryAssigmentDTO>();
            CreateMap<Author, AuthorAssigmentDTO>();

            CreateMap<AuthorSubcategoryAssigment, AuthorSubcategoryAssigmentDTO>();
        }     
    }
}
