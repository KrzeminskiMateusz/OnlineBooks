using Microsoft.EntityFrameworkCore;
using OnlineBooksApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineBooksApi.Data
{
    public class LibraryContext : DbContext
    {
        public LibraryContext(DbContextOptions<LibraryContext> options)
            : base(options)
        {
        }

        public DbSet<Author> Authors { get; set; }
        public DbSet<AuthorCategoryAssigment> AuthorCategoryAssigments { get; set; }
        public DbSet<Book> Books { get; set; }
        public DbSet<BookCategoryAssigment> BookCategoryAssigments { get; set; }
        public DbSet<Shelf> Shelves { get; set; }
        public DbSet<ShelftAuthorAssigment> ShelftAuthorAssigments { get; set; }
        public DbSet<ShelfBookAssigment> ShelfBookAssigments { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<CategorySubcategoryAssigment> CategorySubcategoryAssigments { get; set; }
        public DbSet<Subcategory> Subcategories { get; set; }
        public DbSet<AuthorSubcategoryAssigment> AuthorSubcategoryAssigments { get; set; }
        public DbSet<BookSubcategoryAssigment> BookSubcategoryAssigments { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Author>().ToTable("Author");
            modelBuilder.Entity<AuthorCategoryAssigment>().ToTable("AuthorCategoryAssigment");
            modelBuilder.Entity<AuthorSubcategoryAssigment>().ToTable("AuthorSubcategoryAssigment");
            modelBuilder.Entity<Book>().ToTable("Book");
            modelBuilder.Entity<BookCategoryAssigment>().ToTable("BookCategoryAssigment");
            modelBuilder.Entity<BookSubcategoryAssigment>().ToTable("BookSubcategoryAssigment");
            modelBuilder.Entity<Shelf>().ToTable("Shelf");
            modelBuilder.Entity<ShelftAuthorAssigment>().ToTable("ShelftAuthorAssigment");
            modelBuilder.Entity<ShelfBookAssigment>().ToTable("ShelfBookAssigment");
            modelBuilder.Entity<Category>().ToTable("Category");
            modelBuilder.Entity<CategorySubcategoryAssigment>().ToTable("CategorySubcategoryAssigment");
            modelBuilder.Entity<Subcategory>().ToTable("Subcategory");


            modelBuilder.Entity<AuthorCategoryAssigment>().HasKey(c => new { c.AuthorId, c.CategoryId });
            modelBuilder.Entity<BookCategoryAssigment>().HasKey(c => new { c.BookId, c.CategoryId });
            modelBuilder.Entity<ShelftAuthorAssigment>().HasKey(c => new { c.ShelfId, c.AuthorId });
            modelBuilder.Entity<ShelfBookAssigment>().HasKey(c => new { c.ShelfId, c.BookId });
            modelBuilder.Entity<CategorySubcategoryAssigment>().HasKey(c => new { c.CategoryId, c.SubcategoryId });
            modelBuilder.Entity<AuthorSubcategoryAssigment>().HasKey(c => new { c.AuthorId, c.SubcategoryId });
            modelBuilder.Entity<BookSubcategoryAssigment>().HasKey(c => new { c.BookId, c.SubcategoryId });
        }
    }
}
