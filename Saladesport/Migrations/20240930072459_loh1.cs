using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Saladesport.Migrations
{
    /// <inheritdoc />
    public partial class loh1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Filiale",
                columns: table => new
                {
                    FilialeId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Locatia = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Filiale", x => x.FilialeId);
                });

            migrationBuilder.CreateTable(
                name: "Snacks",
                columns: table => new
                {
                    SnacksId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SnacksPrice = table.Column<int>(type: "int", nullable: false),
                    Durata = table.Column<int>(type: "int", nullable: false),
                    FilialeID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Snacks", x => x.SnacksId);
                    table.ForeignKey(
                        name: "FK_Snacks_Filiale_FilialeID",
                        column: x => x.FilialeID,
                        principalTable: "Filiale",
                        principalColumn: "FilialeId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Abonament",
                columns: table => new
                {
                    AbonamentId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Price = table.Column<int>(type: "int", nullable: false),
                    Durata = table.Column<int>(type: "int", nullable: false),
                    EquipmentID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Abonament", x => x.AbonamentId);
                });

            migrationBuilder.CreateTable(
                name: "Visitator",
                columns: table => new
                {
                    VisitatorId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SecondName = table.Column<int>(type: "int", nullable: false),
                    AbonamentName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    BirthDay = table.Column<DateTime>(type: "datetime2", nullable: false),
                    GettingDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Mail = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AbonamentID = table.Column<int>(type: "int", nullable: false),
                    VisitatorId1 = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Visitator", x => x.VisitatorId);
                    table.ForeignKey(
                        name: "FK_Visitator_Abonament_AbonamentID",
                        column: x => x.AbonamentID,
                        principalTable: "Abonament",
                        principalColumn: "AbonamentId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Visitator_Visitator_VisitatorId1",
                        column: x => x.VisitatorId1,
                        principalTable: "Visitator",
                        principalColumn: "VisitatorId");
                });

            migrationBuilder.CreateTable(
                name: "Equipment",
                columns: table => new
                {
                    EquipmentId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Number = table.Column<int>(type: "int", nullable: false),
                    ExerciseName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Vizitator = table.Column<int>(type: "int", nullable: false),
                    VizitatorsVisitatorId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Equipment", x => x.EquipmentId);
                    table.ForeignKey(
                        name: "FK_Equipment_Visitator_VizitatorsVisitatorId",
                        column: x => x.VizitatorsVisitatorId,
                        principalTable: "Visitator",
                        principalColumn: "VisitatorId");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Abonament_EquipmentID",
                table: "Abonament",
                column: "EquipmentID");

            migrationBuilder.CreateIndex(
                name: "IX_Equipment_VizitatorsVisitatorId",
                table: "Equipment",
                column: "VizitatorsVisitatorId");

            migrationBuilder.CreateIndex(
                name: "IX_Snacks_FilialeID",
                table: "Snacks",
                column: "FilialeID");

            migrationBuilder.CreateIndex(
                name: "IX_Visitator_AbonamentID",
                table: "Visitator",
                column: "AbonamentID");

            migrationBuilder.CreateIndex(
                name: "IX_Visitator_VisitatorId1",
                table: "Visitator",
                column: "VisitatorId1");

            migrationBuilder.AddForeignKey(
                name: "FK_Abonament_Equipment_EquipmentID",
                table: "Abonament",
                column: "EquipmentID",
                principalTable: "Equipment",
                principalColumn: "EquipmentId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Abonament_Equipment_EquipmentID",
                table: "Abonament");

            migrationBuilder.DropTable(
                name: "Snacks");

            migrationBuilder.DropTable(
                name: "Filiale");

            migrationBuilder.DropTable(
                name: "Equipment");

            migrationBuilder.DropTable(
                name: "Visitator");

            migrationBuilder.DropTable(
                name: "Abonament");
        }
    }
}
