using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Fakture.Migrations
{
    public partial class t : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Uloga",
                keyColumn: "UlogaID",
                keyValue: 2);

            migrationBuilder.UpdateData(
                table: "Korisnici",
                keyColumn: "KorisnikID",
                keyValue: 1,
                columns: new[] { "AutorizacijskiToken", "DatumRodjenja" },
                values: new object[] { new Guid("7e32b5bb-651c-48cf-bf30-d57b1eb0c16e"), new DateTime(1998, 12, 23, 12, 44, 26, 439, DateTimeKind.Local).AddTicks(3350) });

            migrationBuilder.InsertData(
                table: "Pdv",
                columns: new[] { "PdvId", "Drzava", "Vrijednost" },
                values: new object[,]
                {
                    { 1, "BiH", 0.17m },
                    { 2, "HR", 0.25m }
                });

            migrationBuilder.UpdateData(
                table: "Proizvod",
                keyColumn: "ProizvodId",
                keyValue: 1,
                column: "Sifra",
                value: "0f189889-e6b5-46e1-a0fa-e7c1d7b72f90");

            migrationBuilder.UpdateData(
                table: "Proizvod",
                keyColumn: "ProizvodId",
                keyValue: 2,
                column: "Sifra",
                value: "eccb380b-b8b4-42c1-b4b1-bcab0965d000");

            migrationBuilder.UpdateData(
                table: "Proizvod",
                keyColumn: "ProizvodId",
                keyValue: 3,
                column: "Sifra",
                value: "8bd489a9-27c6-4506-bbf6-cf60d7732b5f");

            migrationBuilder.InsertData(
                table: "Uloga",
                columns: new[] { "UlogaID", "Naziv" },
                values: new object[] { 3, "kupac" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Pdv",
                keyColumn: "PdvId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Pdv",
                keyColumn: "PdvId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Uloga",
                keyColumn: "UlogaID",
                keyValue: 3);

            migrationBuilder.UpdateData(
                table: "Korisnici",
                keyColumn: "KorisnikID",
                keyValue: 1,
                columns: new[] { "AutorizacijskiToken", "DatumRodjenja" },
                values: new object[] { new Guid("ffb804f9-ff15-494f-a583-bb736327a9e8"), new DateTime(1998, 12, 23, 11, 19, 59, 588, DateTimeKind.Local).AddTicks(5513) });

            migrationBuilder.UpdateData(
                table: "Proizvod",
                keyColumn: "ProizvodId",
                keyValue: 1,
                column: "Sifra",
                value: "6414966c-b225-4ba7-b9c8-c72c1555ee06");

            migrationBuilder.UpdateData(
                table: "Proizvod",
                keyColumn: "ProizvodId",
                keyValue: 2,
                column: "Sifra",
                value: "c88a343b-39d7-4575-8c96-3befdb0688be");

            migrationBuilder.UpdateData(
                table: "Proizvod",
                keyColumn: "ProizvodId",
                keyValue: 3,
                column: "Sifra",
                value: "efc1fd1c-ecf3-410b-aea5-b7b73a6ce649");

            migrationBuilder.InsertData(
                table: "Uloga",
                columns: new[] { "UlogaID", "Naziv" },
                values: new object[] { 2, "kupac" });
        }
    }
}
