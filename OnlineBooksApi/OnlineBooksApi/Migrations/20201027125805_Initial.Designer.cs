﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using OnlineBooksApi.Data;

namespace OnlineBooksApi.Migrations
{
    [DbContext(typeof(LibraryContext))]
    [Migration("20201027125805_Initial")]
    partial class Initial
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.3")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("OnlineBooksApi.Models.Author", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("CountryOfBirth")
                        .HasColumnType("nvarchar(50)")
                        .HasMaxLength(50);

                    b.Property<string>("CountryOfDeath")
                        .HasColumnType("nvarchar(50)")
                        .HasMaxLength(50);

                    b.Property<DateTime?>("DataOfBirth")
                        .HasColumnType("date");

                    b.Property<DateTime?>("DateOfDeath")
                        .HasColumnType("date");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(2000)")
                        .HasMaxLength(2000);

                    b.Property<string>("FirstName")
                        .HasColumnType("nvarchar(50)")
                        .HasMaxLength(50);

                    b.Property<byte[]>("Image")
                        .HasColumnType("varbinary(max)");

                    b.Property<bool?>("IsAlive")
                        .HasColumnType("bit");

                    b.Property<string>("LastName")
                        .HasColumnType("nvarchar(50)")
                        .HasMaxLength(50);

                    b.Property<string>("Nationality")
                        .HasColumnType("nvarchar(50)")
                        .HasMaxLength(50);

                    b.Property<string>("PlaceOfBirth")
                        .HasColumnType("nvarchar(50)")
                        .HasMaxLength(50);

                    b.Property<string>("PlaceOfDeath")
                        .HasColumnType("nvarchar(50)")
                        .HasMaxLength(50);

                    b.HasKey("Id");

                    b.ToTable("Author");
                });

            modelBuilder.Entity("OnlineBooksApi.Models.AuthorCategoryAssigment", b =>
                {
                    b.Property<int>("AuthorId")
                        .HasColumnType("int");

                    b.Property<int>("CategoryId")
                        .HasColumnType("int");

                    b.HasKey("AuthorId", "CategoryId");

                    b.HasIndex("CategoryId");

                    b.ToTable("AuthorCategoryAssigment");
                });

            modelBuilder.Entity("OnlineBooksApi.Models.AuthorSubcategoryAssigment", b =>
                {
                    b.Property<int>("AuthorId")
                        .HasColumnType("int");

                    b.Property<int>("SubcategoryId")
                        .HasColumnType("int");

                    b.HasKey("AuthorId", "SubcategoryId");

                    b.HasIndex("SubcategoryId");

                    b.ToTable("AuthorSubcategoryAssigment");
                });

            modelBuilder.Entity("OnlineBooksApi.Models.Book", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("AuthorId")
                        .HasColumnType("int");

                    b.Property<byte[]>("Cover")
                        .HasColumnType("varbinary(max)");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(2000)")
                        .HasMaxLength(2000);

                    b.Property<int?>("NumberOfPages")
                        .HasColumnType("int");

                    b.Property<DateTime>("PublcationDate")
                        .HasColumnType("date");

                    b.Property<string>("Title")
                        .HasColumnType("nvarchar(100)")
                        .HasMaxLength(100);

                    b.HasKey("Id");

                    b.HasIndex("AuthorId");

                    b.ToTable("Book");
                });

            modelBuilder.Entity("OnlineBooksApi.Models.BookCategoryAssigment", b =>
                {
                    b.Property<int>("BookId")
                        .HasColumnType("int");

                    b.Property<int>("CategoryId")
                        .HasColumnType("int");

                    b.HasKey("BookId", "CategoryId");

                    b.HasIndex("CategoryId");

                    b.ToTable("BookCategoryAssigment");
                });

            modelBuilder.Entity("OnlineBooksApi.Models.BookSubcategoryAssigment", b =>
                {
                    b.Property<int>("BookId")
                        .HasColumnType("int");

                    b.Property<int>("SubcategoryId")
                        .HasColumnType("int");

                    b.HasKey("BookId", "SubcategoryId");

                    b.HasIndex("SubcategoryId");

                    b.ToTable("BookSubcategoryAssigment");
                });

            modelBuilder.Entity("OnlineBooksApi.Models.Category", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(100)")
                        .HasMaxLength(100);

                    b.HasKey("Id");

                    b.ToTable("Category");
                });

            modelBuilder.Entity("OnlineBooksApi.Models.CategorySubcategoryAssigment", b =>
                {
                    b.Property<int>("CategoryId")
                        .HasColumnType("int");

                    b.Property<int>("SubcategoryId")
                        .HasColumnType("int");

                    b.HasKey("CategoryId", "SubcategoryId");

                    b.HasIndex("SubcategoryId");

                    b.ToTable("CategorySubcategoryAssigment");
                });

            modelBuilder.Entity("OnlineBooksApi.Models.Shelf", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<bool>("IsAvelibleForAuthor")
                        .HasColumnType("bit");

                    b.Property<bool>("IsAvelibleForBook")
                        .HasColumnType("bit");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(100)")
                        .HasMaxLength(100);

                    b.HasKey("Id");

                    b.ToTable("Shelf");
                });

            modelBuilder.Entity("OnlineBooksApi.Models.ShelfAuthorAssigment", b =>
                {
                    b.Property<int>("ShelfId")
                        .HasColumnType("int");

                    b.Property<int>("AuthorId")
                        .HasColumnType("int");

                    b.HasKey("ShelfId", "AuthorId");

                    b.HasIndex("AuthorId");

                    b.ToTable("ShelftAuthorAssigment");
                });

            modelBuilder.Entity("OnlineBooksApi.Models.ShelfBookAssigment", b =>
                {
                    b.Property<int>("ShelfId")
                        .HasColumnType("int");

                    b.Property<int>("BookId")
                        .HasColumnType("int");

                    b.HasKey("ShelfId", "BookId");

                    b.HasIndex("BookId");

                    b.ToTable("ShelfBookAssigment");
                });

            modelBuilder.Entity("OnlineBooksApi.Models.Subcategory", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(100)")
                        .HasMaxLength(100);

                    b.HasKey("Id");

                    b.ToTable("Subcategory");
                });

            modelBuilder.Entity("OnlineBooksApi.Models.AuthorCategoryAssigment", b =>
                {
                    b.HasOne("OnlineBooksApi.Models.Author", "Author")
                        .WithMany("Categories")
                        .HasForeignKey("AuthorId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("OnlineBooksApi.Models.Category", "Category")
                        .WithMany("Authors")
                        .HasForeignKey("CategoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("OnlineBooksApi.Models.AuthorSubcategoryAssigment", b =>
                {
                    b.HasOne("OnlineBooksApi.Models.Author", "Author")
                        .WithMany("Subcategories")
                        .HasForeignKey("AuthorId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("OnlineBooksApi.Models.Subcategory", "Subcategory")
                        .WithMany("Authors")
                        .HasForeignKey("SubcategoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("OnlineBooksApi.Models.Book", b =>
                {
                    b.HasOne("OnlineBooksApi.Models.Author", "Author")
                        .WithMany("Books")
                        .HasForeignKey("AuthorId");
                });

            modelBuilder.Entity("OnlineBooksApi.Models.BookCategoryAssigment", b =>
                {
                    b.HasOne("OnlineBooksApi.Models.Book", "Book")
                        .WithMany("Categories")
                        .HasForeignKey("BookId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("OnlineBooksApi.Models.Category", "Category")
                        .WithMany("Books")
                        .HasForeignKey("CategoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("OnlineBooksApi.Models.BookSubcategoryAssigment", b =>
                {
                    b.HasOne("OnlineBooksApi.Models.Book", "Book")
                        .WithMany("Subcategories")
                        .HasForeignKey("BookId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("OnlineBooksApi.Models.Subcategory", "Subcategory")
                        .WithMany("Books")
                        .HasForeignKey("SubcategoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("OnlineBooksApi.Models.CategorySubcategoryAssigment", b =>
                {
                    b.HasOne("OnlineBooksApi.Models.Category", "Category")
                        .WithMany("Subcategories")
                        .HasForeignKey("CategoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("OnlineBooksApi.Models.Subcategory", "Subcategory")
                        .WithMany("Categories")
                        .HasForeignKey("SubcategoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("OnlineBooksApi.Models.ShelfAuthorAssigment", b =>
                {
                    b.HasOne("OnlineBooksApi.Models.Author", "Author")
                        .WithMany("Shelves")
                        .HasForeignKey("AuthorId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("OnlineBooksApi.Models.Shelf", "Shelf")
                        .WithMany("Authors")
                        .HasForeignKey("ShelfId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("OnlineBooksApi.Models.ShelfBookAssigment", b =>
                {
                    b.HasOne("OnlineBooksApi.Models.Book", "Book")
                        .WithMany("Shelves")
                        .HasForeignKey("BookId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("OnlineBooksApi.Models.Shelf", "Shelf")
                        .WithMany("Books")
                        .HasForeignKey("ShelfId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
