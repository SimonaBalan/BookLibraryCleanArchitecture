using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace BookLibraryCleanArchitecture.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class ChangeCreatedByColumnTypeScript : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CreatedBy",
                table: "WaitingList"
            );
            migrationBuilder.AddColumn<Guid>(
                name: "CreatedBy",
                table: "WaitingList",
                type: "uniqueidentifier",
                nullable: true,
                defaultValueSql: "NEWID()");

            migrationBuilder.DropColumn(
               name: "CreatedBy",
               table: "Reservations"
           );
            migrationBuilder.AddColumn<Guid>(
                name: "CreatedBy",
                table: "Reservations",
                type: "uniqueidentifier",
                nullable: true,
                defaultValueSql: "NEWID()");

            migrationBuilder.DropColumn(
               name: "CreatedBy",
               table: "Loans"
           );
            migrationBuilder.AddColumn<Guid>(
                name: "CreatedBy",
                table: "Loans",
                type: "uniqueidentifier",
                nullable: true,
                defaultValueSql: "NEWID()");

            migrationBuilder.DropColumn(
               name: "CreatedBy",
               table: "Books"
           );
            migrationBuilder.AddColumn<Guid>(
                name: "CreatedBy",
                table: "Books",
                type: "uniqueidentifier",
                nullable: true,
                defaultValueSql: "NEWID()");

            migrationBuilder.DropColumn(
              name: "CreatedBy",
              table: "Authors"
          );
            migrationBuilder.AddColumn<Guid>(
                name: "CreatedBy",
                table: "Authors",
                type: "uniqueidentifier",
                nullable: true,
                defaultValueSql: "NEWID()");

            migrationBuilder.UpdateData(
                table: "BookAuthors",
                keyColumns: new[] { "AuthorId", "BookId" },
                keyValues: new object[] { 1, 1 },
                column: "CreatedAt",
                value: new DateTime(2025, 3, 2, 23, 49, 18, 909, DateTimeKind.Local).AddTicks(3998));

            migrationBuilder.UpdateData(
                table: "BookAuthors",
                keyColumns: new[] { "AuthorId", "BookId" },
                keyValues: new object[] { 1, 2 },
                column: "CreatedAt",
                value: new DateTime(2025, 3, 2, 23, 49, 18, 909, DateTimeKind.Local).AddTicks(4078));

            migrationBuilder.UpdateData(
                table: "BookAuthors",
                keyColumns: new[] { "AuthorId", "BookId" },
                keyValues: new object[] { 2, 3 },
                column: "CreatedAt",
                value: new DateTime(2025, 3, 2, 23, 49, 18, 909, DateTimeKind.Local).AddTicks(4083));

            migrationBuilder.UpdateData(
                table: "BookAuthors",
                keyColumns: new[] { "AuthorId", "BookId" },
                keyValues: new object[] { 2, 4 },
                column: "CreatedAt",
                value: new DateTime(2025, 3, 2, 23, 49, 18, 909, DateTimeKind.Local).AddTicks(4085));

            migrationBuilder.UpdateData(
                table: "BookAuthors",
                keyColumns: new[] { "AuthorId", "BookId" },
                keyValues: new object[] { 3, 5 },
                column: "CreatedAt",
                value: new DateTime(2025, 3, 2, 23, 49, 18, 909, DateTimeKind.Local).AddTicks(4088));

            migrationBuilder.UpdateData(
                table: "BookAuthors",
                keyColumns: new[] { "AuthorId", "BookId" },
                keyValues: new object[] { 5, 7 },
                column: "CreatedAt",
                value: new DateTime(2025, 3, 2, 23, 49, 18, 909, DateTimeKind.Local).AddTicks(4091));

            migrationBuilder.UpdateData(
                table: "BookAuthors",
                keyColumns: new[] { "AuthorId", "BookId" },
                keyValues: new object[] { 6, 6 },
                column: "CreatedAt",
                value: new DateTime(2025, 3, 2, 23, 49, 18, 909, DateTimeKind.Local).AddTicks(4094));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CreatedBy",
                table: "WaitingList"
            );
            migrationBuilder.AddColumn<int>(
                name: "CreatedBy",
                table: "WaitingList",
                type: "int",
                nullable: true);

            migrationBuilder.DropColumn(
               name: "CreatedBy",
               table: "Reservations"
           );
            migrationBuilder.AddColumn<int>(
                name: "CreatedBy",
                table: "Reservations",
                type: "int",
                nullable: true);

            migrationBuilder.DropColumn(
               name: "CreatedBy",
               table: "Loans"
           );
            migrationBuilder.AddColumn<int>(
                name: "CreatedBy",
                table: "Loans",
                type: "int",
                nullable: true);

            migrationBuilder.DropColumn(
               name: "CreatedBy",
               table: "Books"
           );
            migrationBuilder.AddColumn<int>(
                name: "CreatedBy",
                table: "Books",
                type: "int",
                nullable: true);

            migrationBuilder.DropColumn(
              name: "CreatedBy",
              table: "Authors"
          );
            migrationBuilder.AddColumn<int>(
                name: "CreatedBy",
                table: "Authors",
                type: "int",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "Authors",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedBy",
                value: null);

            migrationBuilder.UpdateData(
                table: "Authors",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedBy",
                value: null);

            migrationBuilder.UpdateData(
                table: "Authors",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedBy",
                value: null);

            migrationBuilder.UpdateData(
                table: "Authors",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedBy",
                value: null);

            migrationBuilder.UpdateData(
                table: "Authors",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedBy",
                value: null);

            migrationBuilder.UpdateData(
                table: "Authors",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedBy",
                value: null);

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

            migrationBuilder.UpdateData(
                table: "BookAuthors",
                keyColumns: new[] { "AuthorId", "BookId" },
                keyValues: new object[] { 6, 6 },
                column: "CreatedAt",
                value: new DateTime(2025, 3, 2, 17, 19, 55, 899, DateTimeKind.Local).AddTicks(9516));

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedBy",
                value: null);

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedBy",
                value: null);

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedBy",
                value: null);

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedBy",
                value: null);

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedBy",
                value: null);

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedBy",
                value: null);

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreatedBy",
                value: null);
        }
    }
}
