using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace OnionStarter.Persistence.Migrations
{
    public partial class test : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Stock = table.Column<int>(type: "int", nullable: false),
                    Price = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Description", "Name", "Price", "Stock" },
                values: new object[,]
                {
                    { new Guid("002b881b-bdae-4f82-963f-efb4210a8a3b"), "Product 1 Description", "Product 1", 1000, 10 },
                    { new Guid("68b9b7a7-52a1-4924-9c62-60bcd9eec83f"), "Product 2 Description", "Product 2", 2000, 20 },
                    { new Guid("c71fed41-04e5-4f76-ad63-b31ca99e6681"), "Product 3 Description", "Product 3", 3000, 30 },
                    { new Guid("f753c922-e559-4684-ac01-4cb1c5f46393"), "Product 4 Description", "Product 4", 4000, 40 }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Products");
        }
    }
}
