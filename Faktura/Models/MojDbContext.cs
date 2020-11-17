using Microsoft.EntityFrameworkCore;
using System;
using System.Runtime.InteropServices;

namespace Fakture.Models
{
    public class MojDbContext: DbContext
    {
        public DbSet<Kupac> Kupac { get; set; }
        public DbSet< Korisnik> Korisnici { get; set; }
        public DbSet< Uloga> Uloga { get; set; }
        public DbSet< Proizvod> Proizvod { get; set; }
        public DbSet< Narudzba> Narudzba { get; set; }
        public DbSet< NarudzbaProizvod> NarudzbaProizvod { get; set; }
        public DbSet<Faktura> Faktura { get; set; }
        public DbSet<Pdv> Pdv { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=localhost;Database=Fakture;Trusted_Connection=True;MultipleActiveResultSets=true;");
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<Uloga>().HasData(new Uloga()
            {
                UlogaID = 1,
                Naziv = "administrator"
            });

            builder.Entity<Uloga>().HasData(new Uloga()
            {
                UlogaID = 3,
                Naziv = "kupac"
            });

            builder.Entity<Korisnik>().HasData(new Korisnik()
            {
                KorisnikID = 1,
                Ime = "admin",
                Prezime = "admin",
                UlogaID = 1,
                DatumRodjenja = DateTime.Now.AddDays(-8000),
                BrojTelefona = "061111111",
                Email = "demo.demo@hotmail.com",
                AutorizacijskiToken = Guid.NewGuid(),
                PasswordHash = "admin",
                UserName = "admin"

            });

            builder.Entity<Proizvod>().HasData(new Proizvod()
            {
                ProizvodId = 1,
                Naziv = "coca cola",
                Sifra = Guid.NewGuid().ToString(),
                Cijena = 2
            }) ;
            builder.Entity<Proizvod>().HasData(new Proizvod()
            {
                ProizvodId = 2,
                Naziv = "fanta",
                Sifra = Guid.NewGuid().ToString(),
                Cijena = 2
            });
            builder.Entity<Proizvod>().HasData(new Proizvod()
            {
                ProizvodId = 3,
                Naziv = "cokolada",
                Sifra = Guid.NewGuid().ToString(),
                Cijena = 3
            });

            builder.Entity<Pdv>().HasData(new Pdv()
            {
                PdvId = 1,
                Drzava = "BiH",
                Vrijednost = Convert.ToDecimal(0.17)
            });

            builder.Entity<Pdv>().HasData(new Pdv()
            {
                PdvId = 2,
                Drzava = "HR",
                Vrijednost = Convert.ToDecimal(0.25)
            });
        }
}
}
