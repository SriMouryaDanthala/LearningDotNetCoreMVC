using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace LearningDotNetCoreMVC.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class SeedingProducts : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Author", "Description", "ISBN", "Name", "Price", "PriceForFifty", "PriceForHundred" },
                values: new object[,]
                {
                    { 1, "Paulo Coelho", "A journey of self-discovery", "ISBN001", "The Alchemist", 499.0, 450.0, 400.0 },
                    { 2, "Robert C. Martin", "A handbook of agile software craftsmanship", "ISBN002", "Clean Code", 999.0, 900.0, 850.0 },
                    { 3, "Andrew Hunt", "Your journey to mastery", "ISBN003", "The Pragmatic Programmer", 899.0, 800.0, 750.0 },
                    { 4, "James Clear", "An easy & proven way to build good habits", "ISBN004", "Atomic Habits", 699.0, 650.0, 600.0 },
                    { 5, "Cal Newport", "Rules for focused success", "ISBN005", "Deep Work", 799.0, 720.0, 680.0 },
                    { 6, "Robert Kiyosaki", "What the rich teach their kids", "ISBN006", "Rich Dad Poor Dad", 599.0, 550.0, 500.0 },
                    { 7, "Peter Thiel", "Notes on startups and building the future", "ISBN007", "Zero to One", 749.0, 700.0, 650.0 },
                    { 8, "Napoleon Hill", "Classic personal success guide", "ISBN008", "Think and Grow Rich", 399.0, 350.0, 300.0 },
                    { 9, "Yuval Noah Harari", "A brief history of humankind", "ISBN009", "Sapiens", 1099.0, 1000.0, 950.0 },
                    { 10, "Eric Ries", "How today's entrepreneurs use continuous innovation", "ISBN010", "The Lean Startup", 899.0, 820.0, 780.0 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 10);
        }
    }
}
