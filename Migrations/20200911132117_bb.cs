using Microsoft.EntityFrameworkCore.Migrations;

namespace Lubes.Migrations
{
    public partial class bb : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Add_item",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Category_id = table.Column<int>(nullable: false),
                    Item_name = table.Column<string>(maxLength: 50, nullable: false),
                    Item_price = table.Column<float>(nullable: false),
                    Quantity = table.Column<int>(nullable: false),
                    DateTime = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Add_item", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "c_Users",
                columns: table => new
                {
                    National_id = table.Column<int>(nullable: false),
                    Full_name = table.Column<string>(nullable: false),
                    Phone = table.Column<string>(nullable: false),
                    Password = table.Column<string>(nullable: false),
                    strRole = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_c_Users", x => x.National_id);
                });

            migrationBuilder.CreateTable(
                name: "Items_category",
                columns: table => new
                {
                    IDT = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Category_name = table.Column<string>(maxLength: 50, nullable: false),
                    ImageURL = table.Column<string>(nullable: true),
                    Item_categoryIDT = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Items_category", x => x.IDT);
                    table.ForeignKey(
                        name: "FK_Items_category_Items_category_Item_categoryIDT",
                        column: x => x.Item_categoryIDT,
                        principalTable: "Items_category",
                        principalColumn: "IDT",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Roles",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Role_id = table.Column<int>(nullable: false),
                    Role_name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Roles", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Stock_summary",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Item_price = table.Column<float>(nullable: false),
                    Category_name = table.Column<string>(nullable: true),
                    Item_name = table.Column<string>(nullable: true),
                    Quantity = table.Column<int>(nullable: false),
                    ImageURL = table.Column<string>(nullable: true),
                    IDT = table.Column<string>(nullable: true),
                    item_sold = table.Column<int>(nullable: false),
                    Cash_made = table.Column<float>(nullable: false),
                    User_id = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Stock_summary", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Submited_stock",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    item_id = table.Column<int>(nullable: false),
                    DateTime = table.Column<string>(nullable: false),
                    item_sold = table.Column<int>(nullable: false),
                    Cash_made = table.Column<float>(nullable: false),
                    User_id = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Submited_stock", x => x.id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Items_category_Item_categoryIDT",
                table: "Items_category",
                column: "Item_categoryIDT");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Add_item");

            migrationBuilder.DropTable(
                name: "c_Users");

            migrationBuilder.DropTable(
                name: "Items_category");

            migrationBuilder.DropTable(
                name: "Roles");

            migrationBuilder.DropTable(
                name: "Stock_summary");

            migrationBuilder.DropTable(
                name: "Submited_stock");
        }
    }
}
