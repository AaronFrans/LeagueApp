using Microsoft.EntityFrameworkCore.Migrations;

namespace DataLayer.Migrations
{
    public partial class Start : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Teams",
                columns: table => new
                {
                    Stamnummer = table.Column<int>(nullable: false),
                    Naam = table.Column<string>(nullable: true),
                    Bijnaam = table.Column<string>(nullable: true),
                    Trainer = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Teams", x => x.Stamnummer);
                });

            migrationBuilder.CreateTable(
                name: "Spelers",
                columns: table => new
                {
                    SpelerId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Naam = table.Column<string>(nullable: true),
                    Rugnummer = table.Column<int>(nullable: false),
                    Waarde = table.Column<int>(nullable: false),
                    TeamStamnummer = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Spelers", x => x.SpelerId);
                    table.ForeignKey(
                        name: "FK_Spelers_Teams_TeamStamnummer",
                        column: x => x.TeamStamnummer,
                        principalTable: "Teams",
                        principalColumn: "Stamnummer",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Transfers",
                columns: table => new
                {
                    TransferId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TransferredSpelerSpelerId = table.Column<int>(nullable: true),
                    TransferPrijs = table.Column<double>(nullable: false),
                    OudTeamStamnummer = table.Column<int>(nullable: true),
                    NieuwTeamStamnummer = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Transfers", x => x.TransferId);
                    table.ForeignKey(
                        name: "FK_Transfers_Teams_NieuwTeamStamnummer",
                        column: x => x.NieuwTeamStamnummer,
                        principalTable: "Teams",
                        principalColumn: "Stamnummer",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Transfers_Teams_OudTeamStamnummer",
                        column: x => x.OudTeamStamnummer,
                        principalTable: "Teams",
                        principalColumn: "Stamnummer",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Transfers_Spelers_TransferredSpelerSpelerId",
                        column: x => x.TransferredSpelerSpelerId,
                        principalTable: "Spelers",
                        principalColumn: "SpelerId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Spelers_TeamStamnummer",
                table: "Spelers",
                column: "TeamStamnummer");

            migrationBuilder.CreateIndex(
                name: "IX_Transfers_NieuwTeamStamnummer",
                table: "Transfers",
                column: "NieuwTeamStamnummer");

            migrationBuilder.CreateIndex(
                name: "IX_Transfers_OudTeamStamnummer",
                table: "Transfers",
                column: "OudTeamStamnummer");

            migrationBuilder.CreateIndex(
                name: "IX_Transfers_TransferredSpelerSpelerId",
                table: "Transfers",
                column: "TransferredSpelerSpelerId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Transfers");

            migrationBuilder.DropTable(
                name: "Spelers");

            migrationBuilder.DropTable(
                name: "Teams");
        }
    }
}
