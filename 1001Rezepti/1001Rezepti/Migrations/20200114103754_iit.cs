using Microsoft.EntityFrameworkCore.Migrations;

namespace _1001Rezepti.Migrations
{
    public partial class iit : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Product",
                columns: table => new
                {
                    ProductID = table.Column<int>(nullable: false),
                    ProductName = table.Column<string>(maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Product", x => x.ProductID);
                });

            migrationBuilder.CreateTable(
                name: "Recepie",
                columns: table => new
                {
                    RecepieID = table.Column<int>(nullable: false),
                    RecepieName = table.Column<string>(maxLength: 100, nullable: false),
                    Description = table.Column<string>(maxLength: 10000, nullable: false),
                    ImagePath = table.Column<string>(nullable: true),
                    TimeToCook = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Recepie", x => x.RecepieID);
                });

            migrationBuilder.CreateTable(
                name: "RecProd",
                columns: table => new
                {
                    RecepieId = table.Column<int>(nullable: false),
                    ProductId = table.Column<int>(nullable: false),
                    Quantity = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RecProd", x => new { x.RecepieId, x.ProductId });
                    table.UniqueConstraint("AK_RecProd_ProductId_RecepieId", x => new { x.ProductId, x.RecepieId });
                    table.ForeignKey(
                        name: "FK_RecProd_Product_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Product",
                        principalColumn: "ProductID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_RecProd_Recepie_RecepieId",
                        column: x => x.RecepieId,
                        principalTable: "Recepie",
                        principalColumn: "RecepieID",
                        onDelete: ReferentialAction.Cascade);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "RecProd");

            migrationBuilder.DropTable(
                name: "Product");

            migrationBuilder.DropTable(
                name: "Recepie");
        }
    }
}
