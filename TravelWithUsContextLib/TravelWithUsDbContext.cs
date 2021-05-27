using Microsoft.EntityFrameworkCore;
using TravelWithUs.Models;

namespace TravelWithUs.DBContext
{
    public class TravelWithUsDbContext : DbContext
    {
        public TravelWithUsDbContext()
        {

        }

        public TravelWithUsDbContext(DbContextOptions<TravelWithUsDbContext> options)
            : base(options)
        {

        }


        public DbSet<Agencia> Agencias { get; set; }
        public DbSet<Excursion> Excursiones { get; set; }
        public DbSet<Facilidad> Facilidades { get; set; }
        public DbSet<Hotel> Hoteles { get; set; }
        public DbSet<Oferta> Ofertas { get; set; }
        public DbSet<Paquete> Paquetes { get; set; }
        public DbSet<ReservaExcursion> ReservasExcursiones { get; set; }
        public DbSet<ReservaIndividual> ReservasIndividuales { get; set; }
        public DbSet<ReservaPaquete> ReservasPaquetes { get; set; }
        public DbSet<Turista> Turistas { get; set; }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //optionsBuilder.UseSqlServer($"Server=(localDB)\\MSSQLLocalDB;Database=TravelWithUsDB;Integrated Security=true;");
            string path = System.IO.Path.Combine(
                "..", "TravelWithUsDB.db");
            optionsBuilder.UseSqlite($"Filename={path}");

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Configuring characteristics for ReservaIndividdual

            modelBuilder.Entity<ReservaIndividual>()
                .HasKey(ri => new
                {
                    ri.AgenciaID,
                    ri.HotelID,
                    ri.OfertaID,
                    ri.TuristaID
                });

            modelBuilder.Entity<ReservaIndividual>()
                .HasOne(ri => ri.Turista)
                .WithMany(t => t.ReservasIndividuales)
                .HasForeignKey(ri => ri.TuristaID);

            modelBuilder.Entity<ReservaIndividual>()
                .HasOne(ri => ri.Agencia)
                .WithMany(a => a.ReservasIndividuales)
                .HasForeignKey(ri => ri.AgenciaID);

            modelBuilder.Entity<ReservaIndividual>()
                .HasOne(ri => ri.Oferta)
                .WithMany(o => o.ReservasIndividuales)
                .HasForeignKey(ri => new { ri.OfertaID, ri.HotelID });

            // Configuring characteristics for ReservaExcursion.

            modelBuilder.Entity<ReservaExcursion>()
                .HasKey(re => new
                {
                    re.AgenciaID,
                    re.ExcursionID,
                    re.TuristaID
                });

            modelBuilder.Entity<ReservaExcursion>()
                .HasOne(re => re.Agencia)
                .WithMany(a => a.ReservasExcursiones)
                .HasForeignKey(re => re.AgenciaID);

            modelBuilder.Entity<ReservaExcursion>()
                .HasOne(re => re.Excursion)
                .WithMany(e => e.ReservasExcursiones)
                .HasForeignKey(re => re.ExcursionID);

            modelBuilder.Entity<ReservaExcursion>()
                .HasOne(re => re.Turista)
                .WithMany(t => t.ReservasExcursiones)
                .HasForeignKey(re => re.TuristaID);

            // Configuring characteristics for ReservaPaquete.

            modelBuilder.Entity<ReservaPaquete>()
                .HasKey(rp => new { rp.AgenciaID, rp.TuristaID, rp.Codigo });

            modelBuilder.Entity<ReservaPaquete>()
                .HasOne(rp => rp.Agencia)
                .WithMany(a => a.ReservasPaquetes)
                .HasForeignKey(rp => rp.AgenciaID);

            modelBuilder.Entity<ReservaPaquete>()
                .HasOne(rp => rp.Paquete)
                .WithMany(p => p.ReservasPaquetes)
                .HasForeignKey(rp => rp.Codigo);

            modelBuilder.Entity<ReservaPaquete>()
                .HasOne(rp => rp.Turista)
                .WithMany(t => t.ReservasPaquetes)
                .HasForeignKey(rp => rp.TuristaID);

            // Configuring characteristics for Paquete.
            modelBuilder.Entity<Paquete>()
                .HasOne(p => p.Excursion)
                .WithMany(e => e.Paquetes)
                .HasForeignKey(p => p.ExcursionID);

            // Configuring characteristics for Oferta.
            modelBuilder.Entity<Oferta>()
                .HasKey(o => new { o.OfertaID, o.HotelID });

            modelBuilder.Entity<Oferta>()
                .HasOne(o => o.Hotel)
                .WithMany(h => h.Ofertas)
                .HasForeignKey(o => o.HotelID);

            modelBuilder.Entity<Agencia>().HasData(
                new { AgenciaID = 1, Nombre = "Cubanacan", Direccion = "Playa", Email = "cubanacan@gmail.com" },
                new { AgenciaID = 2, Nombre = "Gaviota", Direccion = "Plaza", Email = "gaviota@gmail.com" },
                new { AgenciaID = 3, Nombre = "Melia", Direccion = "Habana Vieja", Email = "melia@gmail.com" }
            );

            modelBuilder.Entity<Hotel>().HasData(
                new { HotelID = 1, Nombre = "Melia Cohiba", Direccion = "Plaza", Categoria = 3 },
                new { HotelID = 2, Nombre = "Manzana de Gomez", Direccion = "Habana Vieja", Categoria = 5 },
                new { HotelID = 3, Nombre = "Pakart", Direccion = "Habana Vieja", Categoria = 5 },
                new { HotelID = 4, Nombre = "Hotel Nacional", Direccion = "Plaza", Categoria = 4 },
                new { HotelID = 5, Nombre = "Habana Libre", Direccion = "Plaza", Categoria = 3 }
            );


        }

    }
}