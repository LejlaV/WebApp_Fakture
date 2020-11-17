﻿// <auto-generated />
using System;
using Fakture.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Fakture.Migrations
{
    [DbContext(typeof(MojDbContext))]
    [Migration("20201117114426_t")]
    partial class t
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.5")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Fakture.Models.Faktura", b =>
                {
                    b.Property<int>("FakturaId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("BrojFakture")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("Datum")
                        .HasColumnType("datetime2");

                    b.Property<decimal>("IznosBezPdv")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal>("IznosSaPdv")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal>("IznosSaPdvBiH")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal>("IznosSaPdvHr")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int>("KupacId")
                        .HasColumnType("int");

                    b.Property<int>("NarudzbaId")
                        .HasColumnType("int");

                    b.Property<int>("PdvId")
                        .HasColumnType("int");

                    b.Property<bool>("Zakljucen")
                        .HasColumnType("bit");

                    b.HasKey("FakturaId");

                    b.HasIndex("KupacId");

                    b.HasIndex("NarudzbaId");

                    b.HasIndex("PdvId");

                    b.ToTable("Faktura");
                });

            modelBuilder.Entity("Fakture.Models.Korisnik", b =>
                {
                    b.Property<int>("KorisnikID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<Guid>("AutorizacijskiToken")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("BrojTelefona")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("DatumRodjenja")
                        .HasColumnType("datetime2");

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Ime")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PasswordHash")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PasswordSalt")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Prezime")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Slika")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("UlogaID")
                        .HasColumnType("int");

                    b.Property<string>("UserName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("KorisnikID");

                    b.HasIndex("UlogaID");

                    b.ToTable("Korisnici");

                    b.HasData(
                        new
                        {
                            KorisnikID = 1,
                            AutorizacijskiToken = new Guid("7e32b5bb-651c-48cf-bf30-d57b1eb0c16e"),
                            BrojTelefona = "061111111",
                            DatumRodjenja = new DateTime(1998, 12, 23, 12, 44, 26, 439, DateTimeKind.Local).AddTicks(3350),
                            Email = "demo.demo@hotmail.com",
                            Ime = "admin",
                            PasswordHash = "admin",
                            Prezime = "admin",
                            UlogaID = 1,
                            UserName = "admin"
                        });
                });

            modelBuilder.Entity("Fakture.Models.Kupac", b =>
                {
                    b.Property<int>("KupacID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("DatumRegistracije")
                        .HasColumnType("datetime2");

                    b.Property<int>("KorisnikID")
                        .HasColumnType("int");

                    b.HasKey("KupacID");

                    b.HasIndex("KorisnikID");

                    b.ToTable("Kupac");
                });

            modelBuilder.Entity("Fakture.Models.Narudzba", b =>
                {
                    b.Property<int>("NarudzbaId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<bool>("Aktivna")
                        .HasColumnType("bit");

                    b.Property<string>("BrojNarudzbe")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("Datum")
                        .HasColumnType("datetime2");

                    b.Property<int>("KupacId")
                        .HasColumnType("int");

                    b.HasKey("NarudzbaId");

                    b.HasIndex("KupacId");

                    b.ToTable("Narudzba");
                });

            modelBuilder.Entity("Fakture.Models.NarudzbaProizvod", b =>
                {
                    b.Property<int>("NarudzbaProizvodId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("Kolicina")
                        .HasColumnType("int");

                    b.Property<int>("NarudzbaId")
                        .HasColumnType("int");

                    b.Property<int>("ProizvodId")
                        .HasColumnType("int");

                    b.HasKey("NarudzbaProizvodId");

                    b.HasIndex("NarudzbaId");

                    b.HasIndex("ProizvodId");

                    b.ToTable("NarudzbaProizvod");
                });

            modelBuilder.Entity("Fakture.Models.Pdv", b =>
                {
                    b.Property<int>("PdvId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Drzava")
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("Vrijednost")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("PdvId");

                    b.ToTable("Pdv");

                    b.HasData(
                        new
                        {
                            PdvId = 1,
                            Drzava = "BiH",
                            Vrijednost = 0.17m
                        },
                        new
                        {
                            PdvId = 2,
                            Drzava = "HR",
                            Vrijednost = 0.25m
                        });
                });

            modelBuilder.Entity("Fakture.Models.Proizvod", b =>
                {
                    b.Property<int>("ProizvodId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<decimal>("Cijena")
                        .HasColumnType("decimal(18,2)");

                    b.Property<string>("Naziv")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Sifra")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Slika")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ProizvodId");

                    b.ToTable("Proizvod");

                    b.HasData(
                        new
                        {
                            ProizvodId = 1,
                            Cijena = 2m,
                            Naziv = "coca cola",
                            Sifra = "0f189889-e6b5-46e1-a0fa-e7c1d7b72f90"
                        },
                        new
                        {
                            ProizvodId = 2,
                            Cijena = 2m,
                            Naziv = "fanta",
                            Sifra = "eccb380b-b8b4-42c1-b4b1-bcab0965d000"
                        },
                        new
                        {
                            ProizvodId = 3,
                            Cijena = 3m,
                            Naziv = "cokolada",
                            Sifra = "8bd489a9-27c6-4506-bbf6-cf60d7732b5f"
                        });
                });

            modelBuilder.Entity("Fakture.Models.Uloga", b =>
                {
                    b.Property<int>("UlogaID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Naziv")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UlogaID");

                    b.ToTable("Uloga");

                    b.HasData(
                        new
                        {
                            UlogaID = 1,
                            Naziv = "administrator"
                        },
                        new
                        {
                            UlogaID = 3,
                            Naziv = "kupac"
                        });
                });

            modelBuilder.Entity("Fakture.Models.Faktura", b =>
                {
                    b.HasOne("Fakture.Models.Kupac", "Kupac")
                        .WithMany()
                        .HasForeignKey("KupacId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Fakture.Models.Narudzba", "Narudzba")
                        .WithMany()
                        .HasForeignKey("NarudzbaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Fakture.Models.Pdv", "Pdv")
                        .WithMany()
                        .HasForeignKey("PdvId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Fakture.Models.Korisnik", b =>
                {
                    b.HasOne("Fakture.Models.Uloga", "Uloga")
                        .WithMany()
                        .HasForeignKey("UlogaID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Fakture.Models.Kupac", b =>
                {
                    b.HasOne("Fakture.Models.Korisnik", "Korisnik")
                        .WithMany()
                        .HasForeignKey("KorisnikID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Fakture.Models.Narudzba", b =>
                {
                    b.HasOne("Fakture.Models.Kupac", "Kupac")
                        .WithMany()
                        .HasForeignKey("KupacId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Fakture.Models.NarudzbaProizvod", b =>
                {
                    b.HasOne("Fakture.Models.Narudzba", "Narudzba")
                        .WithMany()
                        .HasForeignKey("NarudzbaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Fakture.Models.Proizvod", "Proizvod")
                        .WithMany()
                        .HasForeignKey("ProizvodId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}