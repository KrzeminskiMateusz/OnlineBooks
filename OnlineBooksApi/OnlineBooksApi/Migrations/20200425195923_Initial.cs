using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace OnlineBooksApi.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Author",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(maxLength: 50, nullable: true),
                    LastName = table.Column<string>(maxLength: 50, nullable: true),
                    Nationality = table.Column<string>(maxLength: 50, nullable: true),
                    DataOfBirth = table.Column<DateTime>(type: "date", nullable: true),
                    PlaceOfBirth = table.Column<string>(maxLength: 50, nullable: true),
                    CountryOfBirth = table.Column<string>(maxLength: 50, nullable: true),
                    DateOfDeath = table.Column<DateTime>(type: "date", nullable: true),
                    PlaceOfDeath = table.Column<string>(maxLength: 50, nullable: true),
                    CountryOfDeath = table.Column<string>(maxLength: 50, nullable: true),
                    Description = table.Column<string>(maxLength: 2000, nullable: true),
                    Image = table.Column<byte[]>(nullable: true),
                    IsAlive = table.Column<bool>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Author", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Category",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Category", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Shelf",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(maxLength: 100, nullable: false),
                    IsAvelibleForAuthor = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Shelf", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Subcategory",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Subcategory", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Book",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(maxLength: 100, nullable: true),
                    Description = table.Column<string>(maxLength: 2000, nullable: true),
                    Cover = table.Column<byte[]>(nullable: true),
                    PublcationDate = table.Column<DateTime>(type: "date", nullable: false),
                    NumberOfPages = table.Column<int>(nullable: true),
                    AuthorId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Book", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Book_Author_AuthorId",
                        column: x => x.AuthorId,
                        principalTable: "Author",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "AuthorCategoryAssigment",
                columns: table => new
                {
                    AuthorId = table.Column<int>(nullable: false),
                    CategoryId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AuthorCategoryAssigment", x => new { x.AuthorId, x.CategoryId });
                    table.ForeignKey(
                        name: "FK_AuthorCategoryAssigment_Author_AuthorId",
                        column: x => x.AuthorId,
                        principalTable: "Author",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AuthorCategoryAssigment_Category_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Category",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ShelftAuthorAssigment",
                columns: table => new
                {
                    ShelfId = table.Column<int>(nullable: false),
                    AuthorId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ShelftAuthorAssigment", x => new { x.ShelfId, x.AuthorId });
                    table.ForeignKey(
                        name: "FK_ShelftAuthorAssigment_Author_AuthorId",
                        column: x => x.AuthorId,
                        principalTable: "Author",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ShelftAuthorAssigment_Shelf_ShelfId",
                        column: x => x.ShelfId,
                        principalTable: "Shelf",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AuthorSubcategoryAssigment",
                columns: table => new
                {
                    AuthorId = table.Column<int>(nullable: false),
                    SubcategoryId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AuthorSubcategoryAssigment", x => new { x.AuthorId, x.SubcategoryId });
                    table.ForeignKey(
                        name: "FK_AuthorSubcategoryAssigment_Author_AuthorId",
                        column: x => x.AuthorId,
                        principalTable: "Author",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AuthorSubcategoryAssigment_Subcategory_SubcategoryId",
                        column: x => x.SubcategoryId,
                        principalTable: "Subcategory",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CategorySubcategoryAssigment",
                columns: table => new
                {
                    SubcategoryId = table.Column<int>(nullable: false),
                    CategoryId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CategorySubcategoryAssigment", x => new { x.CategoryId, x.SubcategoryId });
                    table.ForeignKey(
                        name: "FK_CategorySubcategoryAssigment_Category_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Category",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CategorySubcategoryAssigment_Subcategory_SubcategoryId",
                        column: x => x.SubcategoryId,
                        principalTable: "Subcategory",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "BookCategoryAssigment",
                columns: table => new
                {
                    BookId = table.Column<int>(nullable: false),
                    CategoryId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BookCategoryAssigment", x => new { x.BookId, x.CategoryId });
                    table.ForeignKey(
                        name: "FK_BookCategoryAssigment_Book_BookId",
                        column: x => x.BookId,
                        principalTable: "Book",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_BookCategoryAssigment_Category_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Category",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "BookSubcategoryAssigment",
                columns: table => new
                {
                    BookId = table.Column<int>(nullable: false),
                    SubcategoryId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BookSubcategoryAssigment", x => new { x.BookId, x.SubcategoryId });
                    table.ForeignKey(
                        name: "FK_BookSubcategoryAssigment_Book_BookId",
                        column: x => x.BookId,
                        principalTable: "Book",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_BookSubcategoryAssigment_Subcategory_SubcategoryId",
                        column: x => x.SubcategoryId,
                        principalTable: "Subcategory",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ShelfBookAssigment",
                columns: table => new
                {
                    ShelfId = table.Column<int>(nullable: false),
                    BookId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ShelfBookAssigment", x => new { x.ShelfId, x.BookId });
                    table.ForeignKey(
                        name: "FK_ShelfBookAssigment_Book_BookId",
                        column: x => x.BookId,
                        principalTable: "Book",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ShelfBookAssigment_Shelf_ShelfId",
                        column: x => x.ShelfId,
                        principalTable: "Shelf",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AuthorCategoryAssigment_CategoryId",
                table: "AuthorCategoryAssigment",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_AuthorSubcategoryAssigment_SubcategoryId",
                table: "AuthorSubcategoryAssigment",
                column: "SubcategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_Book_AuthorId",
                table: "Book",
                column: "AuthorId");

            migrationBuilder.CreateIndex(
                name: "IX_BookCategoryAssigment_CategoryId",
                table: "BookCategoryAssigment",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_BookSubcategoryAssigment_SubcategoryId",
                table: "BookSubcategoryAssigment",
                column: "SubcategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_CategorySubcategoryAssigment_SubcategoryId",
                table: "CategorySubcategoryAssigment",
                column: "SubcategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_ShelfBookAssigment_BookId",
                table: "ShelfBookAssigment",
                column: "BookId");

            migrationBuilder.CreateIndex(
                name: "IX_ShelftAuthorAssigment_AuthorId",
                table: "ShelftAuthorAssigment",
                column: "AuthorId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AuthorCategoryAssigment");

            migrationBuilder.DropTable(
                name: "AuthorSubcategoryAssigment");

            migrationBuilder.DropTable(
                name: "BookCategoryAssigment");

            migrationBuilder.DropTable(
                name: "BookSubcategoryAssigment");

            migrationBuilder.DropTable(
                name: "CategorySubcategoryAssigment");

            migrationBuilder.DropTable(
                name: "ShelfBookAssigment");

            migrationBuilder.DropTable(
                name: "ShelftAuthorAssigment");

            migrationBuilder.DropTable(
                name: "Category");

            migrationBuilder.DropTable(
                name: "Subcategory");

            migrationBuilder.DropTable(
                name: "Book");

            migrationBuilder.DropTable(
                name: "Shelf");

            migrationBuilder.DropTable(
                name: "Author");
        }
    }
}
