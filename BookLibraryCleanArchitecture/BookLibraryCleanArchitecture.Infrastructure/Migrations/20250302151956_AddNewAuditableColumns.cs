using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace BookLibraryCleanArchitecture.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddNewAuditableColumns : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CreatedBy",
                table: "WaitingList",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedOn",
                table: "WaitingList",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<int>(
                name: "CreatedBy",
                table: "Authors",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedOn",
                table: "Authors",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "Authors",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedBy", "CreatedOn" },
                values: new object[] { null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "Authors",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedBy", "CreatedOn" },
                values: new object[] { null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "Authors",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedBy", "CreatedOn" },
                values: new object[] { null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "Authors",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedBy", "CreatedOn" },
                values: new object[] { null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "Authors",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CreatedBy", "CreatedOn" },
                values: new object[] { null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "Authors",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "CreatedBy", "CreatedOn" },
                values: new object[] { null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "BookAuthors",
                keyColumns: new[] { "AuthorId", "BookId" },
                keyValues: new object[] { 1, 1 },
                column: "CreatedAt",
                value: new DateTime(2025, 3, 2, 17, 19, 55, 899, DateTimeKind.Local).AddTicks(9458));

            migrationBuilder.UpdateData(
                table: "BookAuthors",
                keyColumns: new[] { "AuthorId", "BookId" },
                keyValues: new object[] { 1, 2 },
                column: "CreatedAt",
                value: new DateTime(2025, 3, 2, 17, 19, 55, 899, DateTimeKind.Local).AddTicks(9508));

            migrationBuilder.UpdateData(
                table: "BookAuthors",
                keyColumns: new[] { "AuthorId", "BookId" },
                keyValues: new object[] { 2, 3 },
                column: "CreatedAt",
                value: new DateTime(2025, 3, 2, 17, 19, 55, 899, DateTimeKind.Local).AddTicks(9510));

            migrationBuilder.UpdateData(
                table: "BookAuthors",
                keyColumns: new[] { "AuthorId", "BookId" },
                keyValues: new object[] { 2, 4 },
                column: "CreatedAt",
                value: new DateTime(2025, 3, 2, 17, 19, 55, 899, DateTimeKind.Local).AddTicks(9511));

            migrationBuilder.UpdateData(
                table: "BookAuthors",
                keyColumns: new[] { "AuthorId", "BookId" },
                keyValues: new object[] { 3, 5 },
                column: "CreatedAt",
                value: new DateTime(2025, 3, 2, 17, 19, 55, 899, DateTimeKind.Local).AddTicks(9513));

            migrationBuilder.UpdateData(
                table: "BookAuthors",
                keyColumns: new[] { "AuthorId", "BookId" },
                keyValues: new object[] { 5, 7 },
                column: "CreatedAt",
                value: new DateTime(2025, 3, 2, 17, 19, 55, 899, DateTimeKind.Local).AddTicks(9515));            
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CreatedBy",
                table: "WaitingList");

            migrationBuilder.DropColumn(
                name: "CreatedOn",
                table: "WaitingList");

            migrationBuilder.DropColumn(
                name: "CreatedBy",
                table: "Authors");

            migrationBuilder.DropColumn(
                name: "CreatedOn",
                table: "Authors");

            migrationBuilder.UpdateData(
                table: "BookAuthors",
                keyColumns: new[] { "AuthorId", "BookId" },
                keyValues: new object[] { 1, 1 },
                column: "CreatedAt",
                value: new DateTime(2025, 3, 1, 2, 28, 46, 142, DateTimeKind.Local).AddTicks(8783));

            migrationBuilder.UpdateData(
                table: "BookAuthors",
                keyColumns: new[] { "AuthorId", "BookId" },
                keyValues: new object[] { 1, 2 },
                column: "CreatedAt",
                value: new DateTime(2025, 3, 1, 2, 28, 46, 142, DateTimeKind.Local).AddTicks(8826));

            migrationBuilder.UpdateData(
                table: "BookAuthors",
                keyColumns: new[] { "AuthorId", "BookId" },
                keyValues: new object[] { 2, 3 },
                column: "CreatedAt",
                value: new DateTime(2025, 3, 1, 2, 28, 46, 142, DateTimeKind.Local).AddTicks(8828));

            migrationBuilder.UpdateData(
                table: "BookAuthors",
                keyColumns: new[] { "AuthorId", "BookId" },
                keyValues: new object[] { 2, 4 },
                column: "CreatedAt",
                value: new DateTime(2025, 3, 1, 2, 28, 46, 142, DateTimeKind.Local).AddTicks(8830));

            migrationBuilder.UpdateData(
                table: "BookAuthors",
                keyColumns: new[] { "AuthorId", "BookId" },
                keyValues: new object[] { 3, 5 },
                column: "CreatedAt",
                value: new DateTime(2025, 3, 1, 2, 28, 46, 142, DateTimeKind.Local).AddTicks(8831));

            migrationBuilder.UpdateData(
                table: "BookAuthors",
                keyColumns: new[] { "AuthorId", "BookId" },
                keyValues: new object[] { 5, 7 },
                column: "CreatedAt",
                value: new DateTime(2025, 3, 1, 2, 28, 46, 142, DateTimeKind.Local).AddTicks(8833));

            migrationBuilder.InsertData(
                table: "BookAuthors",
                columns: new[] { "AuthorId", "BookId", "CreatedAt" },
                values: new object[] { 6, 8, new DateTime(2025, 3, 1, 2, 28, 46, 142, DateTimeKind.Local).AddTicks(8834) });
        }
    }
}
