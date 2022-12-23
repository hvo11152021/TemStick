using Microsoft.EntityFrameworkCore.Migrations;

namespace ShippingMark.Data.SPMigrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CartonLabels",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    CartonNumber = table.Column<int>(nullable: false),
                    BuyerCartonNumber = table.Column<int>(nullable: false),
                    StylePPJ = table.Column<int>(nullable: false),
                    Brand = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    Fab = table.Column<string>(nullable: true),
                    ColorName = table.Column<string>(nullable: true),
                    Col00 = table.Column<int>(nullable: false),
                    Col0 = table.Column<int>(nullable: false),
                    Col1 = table.Column<int>(nullable: false),
                    Col2 = table.Column<int>(nullable: false),
                    Col3 = table.Column<int>(nullable: false),
                    Col4 = table.Column<int>(nullable: false),
                    Col5 = table.Column<int>(nullable: false),
                    Col6 = table.Column<int>(nullable: false),
                    Col8 = table.Column<int>(nullable: false),
                    Col10 = table.Column<int>(nullable: false),
                    Col12 = table.Column<int>(nullable: false),
                    Col14 = table.Column<int>(nullable: false),
                    Col16 = table.Column<int>(nullable: false),
                    Col18 = table.Column<int>(nullable: false),
                    Col20 = table.Column<int>(nullable: false),
                    Col22 = table.Column<int>(nullable: false),
                    Col24 = table.Column<int>(nullable: false),
                    Col26 = table.Column<int>(nullable: false),
                    Col28 = table.Column<int>(nullable: false),
                    Col30 = table.Column<int>(nullable: false),
                    TotalQuantity = table.Column<int>(nullable: false),
                    CartonQuantity = table.Column<int>(nullable: false),
                    TotalPieces = table.Column<int>(nullable: false),
                    TotalNetWeight = table.Column<double>(nullable: false),
                    TotalGrossWeight = table.Column<double>(nullable: false),
                    Dimension = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CartonLabels", x => x.ID);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CartonLabels");
        }
    }
}
