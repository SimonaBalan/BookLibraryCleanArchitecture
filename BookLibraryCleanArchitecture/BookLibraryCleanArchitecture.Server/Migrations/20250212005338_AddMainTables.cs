using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace BookLibraryCleanArchitecture.Server.Migrations
{
    /// <inheritdoc />
    public partial class AddMainTables : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Authors",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Country = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Authors", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Books",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ISBN = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Publisher = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ReleaseYear = table.Column<int>(type: "int", nullable: false),
                    Genre = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Status = table.Column<int>(type: "int", nullable: false),
                    NumberOfCopies = table.Column<int>(type: "int", nullable: false),
                    LoanedQuantity = table.Column<int>(type: "int", nullable: false),
                    NumberOfPages = table.Column<int>(type: "int", nullable: false),
                    Version = table.Column<byte[]>(type: "rowversion", rowVersion: true, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Books", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "BookAuthors",
                columns: table => new
                {
                    AuthorId = table.Column<int>(type: "int", nullable: false),
                    BookId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BookAuthors", x => new { x.AuthorId, x.BookId });
                    table.ForeignKey(
                        name: "FK_BookAuthors_Authors_AuthorId",
                        column: x => x.AuthorId,
                        principalTable: "Authors",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_BookAuthors_Books_BookId",
                        column: x => x.BookId,
                        principalTable: "Books",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Authors",
                columns: new[] { "Id", "Country", "Name" },
                values: new object[,]
                {
                    { 1, "Japan", "Haruki Murakami" },
                    { 2, "Denmark", "Helle Helle" },
                    { 3, "Belgium", "Georges Simenon" },
                    { 4, "Denmark", "Martin Simon" },
                    { 5, "USA", "Avi Silberchatz" },
                    { 6, "USA", "Paul Auster" }
                });

            migrationBuilder.InsertData(
                table: "Books",
                columns: new[] { "Id", "Genre", "ISBN", "LoanedQuantity", "NumberOfCopies", "NumberOfPages", "Publisher", "ReleaseYear", "Status", "Title" },
                values: new object[,]
                {
                    { 1, "Fiction-SF", "978-606-123-1", 0, 3, 505, "Klim", 2007, 0, "Kafka on the shore" },
                    { 2, "Fiction-Romance", "093-184-732-2", 0, 4, 808, "Klim", 2011, 0, "1Q84" },
                    { 3, "Fiction-Thriller", "731-847-427-0", 0, 3, 0, "Samleren", 2011, 0, "Rodby-Puttgarden" },
                    { 4, "Fiction-Crime", "743-263-482-8", 0, 5, 144, "Lindhart op Linghorf", 2011, 0, "Maigret" },
                    { 5, "NonFiction-Textbook", "943-921-813-0", 0, 10, 505, "McGraw-Hill", 2010, 0, "Database System Concenpts 6th Edition" },
                    { 7, "NonFiction-Guide", "453-263-283-4", 0, 5, 255, "Textmaster", 2014, 0, "Windows 8.1-Effectiv udden touch" },
                    { 8, "Fiction-Crime", "253-273-284-9", 0, 3, 458, "Faber and Faber", 1985, 0, "The New York Triogy" }
                });

            migrationBuilder.InsertData(
                table: "BookAuthors",
                columns: new[] { "AuthorId", "BookId" },
                values: new object[,]
                {
                    { 1, 1 },
                    { 1, 2 },
                    { 2, 3 },
                    { 2, 4 },
                    { 3, 5 },
                    { 5, 7 },
                    { 6, 8 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_BookAuthors_BookId",
                table: "BookAuthors",
                column: "BookId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BookAuthors");

            migrationBuilder.DropTable(
                name: "Authors");

            migrationBuilder.DropTable(
                name: "Books");
        }
    }
}
