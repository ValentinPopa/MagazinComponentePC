using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MagazinComponentePC.Data.Migrations
{
    /// <inheritdoc />
    public partial class AddedIdForProduse : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Produse",
                columns: table => new
                {
                    ProdusID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    NumeProdus = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: false),
                    Descriere = table.Column<string>(type: "varchar(200)", unicode: false, maxLength: 200, nullable: true),
                    Pret = table.Column<decimal>(type: "decimal(10,2)", nullable: false),
                    Stoc = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Produse__09083E94DB357952", x => x.ProdusID);
                });

            migrationBuilder.CreateTable(
                name: "Utilizatori",
                columns: table => new
                {
                    UserID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Nume = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false),
                    Email = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: false),
                    Parola = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false),
                    DataInregistrare = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "(getdate())")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Utilizat__1788CCACB3DA232B", x => x.UserID);
                });

            migrationBuilder.CreateTable(
                name: "Comenzi",
                columns: table => new
                {
                    ComandaID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UserID = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    DataComanda = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "(getdate())"),
                    Stare = table.Column<string>(type: "varchar(20)", unicode: false, maxLength: 20, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Comenzi__845B4DBC303B22CF", x => x.ComandaID);
                    table.ForeignKey(
                        name: "FK_Comenzi_ToUtilizatori",
                        column: x => x.UserID,
                        principalTable: "Utilizatori",
                        principalColumn: "UserID");
                });

            migrationBuilder.CreateTable(
                name: "DetaliiComanda",
                columns: table => new
                {
                    DetaliiID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ComandaID = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    ProdusID = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    Cantitate = table.Column<int>(type: "int", nullable: false),
                    PretProdus = table.Column<decimal>(type: "decimal(10,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__DetaliiC__5182AC376F557BA9", x => x.DetaliiID);
                    table.ForeignKey(
                        name: "FK_DetaliiComanda_ToComenzi",
                        column: x => x.ComandaID,
                        principalTable: "Comenzi",
                        principalColumn: "ComandaID");
                    table.ForeignKey(
                        name: "FK_DetaliiComanda_ToProduse",
                        column: x => x.ProdusID,
                        principalTable: "Produse",
                        principalColumn: "ProdusID");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Comenzi_UserID",
                table: "Comenzi",
                column: "UserID");

            migrationBuilder.CreateIndex(
                name: "IX_DetaliiComanda_ComandaID",
                table: "DetaliiComanda",
                column: "ComandaID");

            migrationBuilder.CreateIndex(
                name: "IX_DetaliiComanda_ProdusID",
                table: "DetaliiComanda",
                column: "ProdusID");

            migrationBuilder.CreateIndex(
                name: "UQ__Utilizat__A9D10534AC0426FC",
                table: "Utilizatori",
                column: "Email",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DetaliiComanda");

            migrationBuilder.DropTable(
                name: "Comenzi");

            migrationBuilder.DropTable(
                name: "Produse");

            migrationBuilder.DropTable(
                name: "Utilizatori");
        }
    }
}
