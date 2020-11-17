using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Fakture.Migrations
{
    public partial class fakture : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Pdv",
                columns: table => new
                {
                    PdvId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Drzava = table.Column<string>(nullable: true),
                    Vrijednost = table.Column<decimal>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pdv", x => x.PdvId);
                });

            migrationBuilder.CreateTable(
                name: "Proizvod",
                columns: table => new
                {
                    ProizvodId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Naziv = table.Column<string>(nullable: true),
                    Sifra = table.Column<string>(nullable: true),
                    Cijena = table.Column<decimal>(nullable: false),
                    Slika = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Proizvod", x => x.ProizvodId);
                });

            migrationBuilder.CreateTable(
                name: "Uloga",
                columns: table => new
                {
                    UlogaID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Naziv = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Uloga", x => x.UlogaID);
                });

            migrationBuilder.CreateTable(
                name: "Korisnici",
                columns: table => new
                {
                    KorisnikID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Ime = table.Column<string>(nullable: true),
                    Prezime = table.Column<string>(nullable: true),
                    AutorizacijskiToken = table.Column<Guid>(nullable: false),
                    BrojTelefona = table.Column<string>(nullable: true),
                    Email = table.Column<string>(nullable: true),
                    Slika = table.Column<string>(nullable: true),
                    DatumRodjenja = table.Column<DateTime>(nullable: false),
                    UserName = table.Column<string>(nullable: true),
                    PasswordHash = table.Column<string>(nullable: true),
                    PasswordSalt = table.Column<string>(nullable: true),
                    UlogaID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Korisnici", x => x.KorisnikID);
                    table.ForeignKey(
                        name: "FK_Korisnici_Uloga_UlogaID",
                        column: x => x.UlogaID,
                        principalTable: "Uloga",
                        principalColumn: "UlogaID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Kupac",
                columns: table => new
                {
                    KupacID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    KorisnikID = table.Column<int>(nullable: false),
                    DatumRegistracije = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Kupac", x => x.KupacID);
                    table.ForeignKey(
                        name: "FK_Kupac_Korisnici_KorisnikID",
                        column: x => x.KorisnikID,
                        principalTable: "Korisnici",
                        principalColumn: "KorisnikID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Narudzba",
                columns: table => new
                {
                    NarudzbaId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BrojNarudzbe = table.Column<string>(nullable: true),
                    KupacId = table.Column<int>(nullable: false),
                    Datum = table.Column<DateTime>(nullable: false),
                    Aktivna = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Narudzba", x => x.NarudzbaId);
                    table.ForeignKey(
                        name: "FK_Narudzba_Kupac_KupacId",
                        column: x => x.KupacId,
                        principalTable: "Kupac",
                        principalColumn: "KupacID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Faktura",
                columns: table => new
                {
                    FakturaId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BrojFakture = table.Column<string>(nullable: true),
                    Datum = table.Column<DateTime>(nullable: false),
                    KupacId = table.Column<int>(nullable: false),
                    Zakljucen = table.Column<bool>(nullable: false),
                    IznosBezPdv = table.Column<decimal>(nullable: false),
                    IznosSaPdv = table.Column<decimal>(nullable: false),
                    IznosSaPdvBiH = table.Column<decimal>(nullable: false),
                    IznosSaPdvHr = table.Column<decimal>(nullable: false),
                    NarudzbaId = table.Column<int>(nullable: false),
                    PdvId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Faktura", x => x.FakturaId);
                    table.ForeignKey(
                        name: "FK_Faktura_Kupac_KupacId",
                        column: x => x.KupacId,
                        principalTable: "Kupac",
                        principalColumn: "KupacID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Faktura_Narudzba_NarudzbaId",
                        column: x => x.NarudzbaId,
                        principalTable: "Narudzba",
                        principalColumn: "NarudzbaId",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_Faktura_Pdv_PdvId",
                        column: x => x.PdvId,
                        principalTable: "Pdv",
                        principalColumn: "PdvId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "NarudzbaProizvod",
                columns: table => new
                {
                    NarudzbaProizvodId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NarudzbaId = table.Column<int>(nullable: false),
                    ProizvodId = table.Column<int>(nullable: false),
                    Kolicina = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NarudzbaProizvod", x => x.NarudzbaProizvodId);
                    table.ForeignKey(
                        name: "FK_NarudzbaProizvod_Narudzba_NarudzbaId",
                        column: x => x.NarudzbaId,
                        principalTable: "Narudzba",
                        principalColumn: "NarudzbaId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_NarudzbaProizvod_Proizvod_ProizvodId",
                        column: x => x.ProizvodId,
                        principalTable: "Proizvod",
                        principalColumn: "ProizvodId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Proizvod",
                columns: new[] { "ProizvodId", "Cijena", "Naziv", "Sifra", "Slika" },
                values: new object[,]
                {
                    { 1, 2m, "coca cola", "6414966c-b225-4ba7-b9c8-c72c1555ee06", null },
                    { 2, 2m, "fanta", "c88a343b-39d7-4575-8c96-3befdb0688be", null },
                    { 3, 3m, "cokolada", "efc1fd1c-ecf3-410b-aea5-b7b73a6ce649", null }
                });

            migrationBuilder.InsertData(
                table: "Uloga",
                columns: new[] { "UlogaID", "Naziv" },
                values: new object[,]
                {
                    { 1, "administrator" },
                    { 2, "kupac" }
                });

            migrationBuilder.InsertData(
                table: "Korisnici",
                columns: new[] { "KorisnikID", "AutorizacijskiToken", "BrojTelefona", "DatumRodjenja", "Email", "Ime", "PasswordHash", "PasswordSalt", "Prezime", "Slika", "UlogaID", "UserName" },
                values: new object[] { 1, new Guid("ffb804f9-ff15-494f-a583-bb736327a9e8"), "061111111", new DateTime(1998, 12, 23, 11, 19, 59, 588, DateTimeKind.Local).AddTicks(5513), "demo.demo@hotmail.com", "admin", "admin", null, "admin", null, 1, "admin" });

            migrationBuilder.CreateIndex(
                name: "IX_Faktura_KupacId",
                table: "Faktura",
                column: "KupacId");

            migrationBuilder.CreateIndex(
                name: "IX_Faktura_NarudzbaId",
                table: "Faktura",
                column: "NarudzbaId");

            migrationBuilder.CreateIndex(
                name: "IX_Faktura_PdvId",
                table: "Faktura",
                column: "PdvId");

            migrationBuilder.CreateIndex(
                name: "IX_Korisnici_UlogaID",
                table: "Korisnici",
                column: "UlogaID");

            migrationBuilder.CreateIndex(
                name: "IX_Kupac_KorisnikID",
                table: "Kupac",
                column: "KorisnikID");

            migrationBuilder.CreateIndex(
                name: "IX_Narudzba_KupacId",
                table: "Narudzba",
                column: "KupacId");

            migrationBuilder.CreateIndex(
                name: "IX_NarudzbaProizvod_NarudzbaId",
                table: "NarudzbaProizvod",
                column: "NarudzbaId");

            migrationBuilder.CreateIndex(
                name: "IX_NarudzbaProizvod_ProizvodId",
                table: "NarudzbaProizvod",
                column: "ProizvodId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Faktura");

            migrationBuilder.DropTable(
                name: "NarudzbaProizvod");

            migrationBuilder.DropTable(
                name: "Pdv");

            migrationBuilder.DropTable(
                name: "Narudzba");

            migrationBuilder.DropTable(
                name: "Proizvod");

            migrationBuilder.DropTable(
                name: "Kupac");

            migrationBuilder.DropTable(
                name: "Korisnici");

            migrationBuilder.DropTable(
                name: "Uloga");
        }
    }
}
