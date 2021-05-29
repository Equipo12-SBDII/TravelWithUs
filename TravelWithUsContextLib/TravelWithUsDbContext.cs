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
                new { AgenciaID = 1, Nombre = "Cubanacan", Direccion = "Playa", Email = "cubanacan@gmail.com", , Fax = "78538964", DescripcionA = "Agencia de turismo que le permitira conocer diferentes lugares en toda la isla, con excelentes servicios en hoteles y casas de arrendamiento, asi como alquiler de autos." },
                new { AgenciaID = 2, Nombre = "Gaviota", Direccion = "Plaza", Email = "gaviota@gmail.com", Fax = "76885479" , DescripcionA = "La Agencia de Viajes gaviota brinda las facilidadesd de conocer maravillosos lugares de Cuba a la vez que disfruta de una agradable estancia. Cuenta con servicio de diferentes aerolíneas , con precios módicos y excelente calidad." },
                new { AgenciaID = 3, Nombre = "EcoCuba", Direccion = "Habana Vieja", Email = "ecocuba@gmail.com",Fax = "72086942", DescripcionA ="Agencia especializada en el turismo ecológico. Cuenta con excursiones a verdaderas maravillas naturales de Cuba y hospedajes en lugares en su mayoría rurales , especial para disfrutar de un ambiente sano." },
                new { AgenciaID = 4, Nombre = "caribeTour", Direccion = "Playa", Email = "caribe@gmail.com",Fax = "72028546", DescripcionA = " Agencia cubana que cuenta con mas de 200 sitios turísticos para visitar en Cuba en su catálogo , la mayoría de estos con estrecha relación con otros países del caribe y América Latina. " }

            );

            modelBuilder.Entity<Hotel>().HasData(
                new { HotelID = 1, Nombre = "Melia Cohiba", Direccion = "Plaza", Categoria = 3, DescripcionH= "Meliá Cohiba ofrece espectaculares vistas sobre el mar y la ciudad. Un excepcional hotel para viajes de placer o negocios que destaca por su ubicación, su exclusivo servicio The Level y su animada sala de fiestas."},
                new { HotelID = 2, Nombre = "Varadero", Direccion = "Habana Vieja", Categoria = 5, DescripcionH = "Este hotel de lujo con todo incluido tiene un impresionante vestíbulo circular con vistas al mar y está a 1,4 km del Varadero Golf Club y a 9 km de la Península de Hicacos."},
                new { HotelID = 3, Nombre = "Panorama", Direccion = "Habana Vieja", Categoria = 5, DescripcionH ="Hotel 4 estrellas, ubicado en la zona residencial de Miramar, donde se encuentran la mayoría de embajadas y firmas comerciales. Dispone de amplias habitaciones, una espectacular piscina, una completa oferta gastronómica, el servicio Privilege Exclusive Rooms and Services y tres salones de reuniones. Recomendado para viajes de negocios, grupos, parejas."},
                new { HotelID = 4, Nombre = "Hotel Nacional", Direccion = "Plaza", Categoria = 4 , DescripcionH = "Hotel Nacional es una magnífica elección para los viajeros que visiten La Habana, ya que ofrece un ambiente elegante, además de numerosos servicios diseñados para mejorar tu estancia. Al estar cerca de los puntos de referencia más conocidos de La Habana es un magnífico destino para turistas." },
                new { HotelID = 5, Nombre = "Habana Libre", Direccion = "Plaza", Categoria = 3 , DescripcionH = "El hotel 5 Estrellas Tryp Habana Libre, uno de los más emblemáticos de La Habana, está localizado en el corazón del Vedado. El hotel, con una altura majestuosa de 25 plantas y 572 habitaciones, ofrece impresionantes vistas de la ciudad y el mar. Ideal para hombres de negocios, eventos, vacaciones y lunas de miel." }
            );
            //Para las excursiones prolongadas hay q agregar diferentes dias en salida y llegada .Tambien se puede conocer si tiene un hotel asociado
            modelBuilder.Entity<Excursion>().HasData(
                new { ExcursionID = 1, LugarLlegadaE = "Cuevas de  Saturno", LugarSalidaE = "Parque Normal", HoraLlegadaE =new DateTime(19,0,0), HoraSalida=(7,0,0), DiaLlegadaE = new DateTime(2021, 7, 12), DiaSalidaE = new DateTime(2021, 7, 12), Precio = 17.00, DescripcionE ="A unos 12 km de Matanzas, Cuba en dirección Varadero se encuentra una gruta a la que aflora un lago de aguas cristalinas conocida con el nombre de Cueva Saturno. Se observan abundantes estalagmitas y estalactitas. El lago tiene una profundidad de 18 metros pero sus aguas son de una transparencia tan increíble que permiten ver el fondo sin dificultad alguna."},
                new { ExcursionID = 2, LugarLlegadaE = "valle de Viñales", LugarSalidaE = "Parque Normal", HoraLlegadaE =new DateTime(19,0,0), HoraSalida=(7,0,0), DiaLlegadaE = new DateTime(2021, 7, 15), DiaSalidaE = new DateTime(2021, 7, 15), Precio = 25.00 , DescripcionE = "Está ubicado en la provincia de Pinar del Río, zona más occidental de Cuba, exactamente en el grupo montañoso de la Cordillera de Guaniguanico. Este Valle y gran parte de la sierra que lo rodea fue aprobado en 1999 como Parque Nacional y, en diciembre de ese mismo año, fue declarado por la UNESCO Patrimonio de la Humanidad, en la categoría de Paisaje Cultural. Posee además la condición de Monumento Nacional."},
                new { ExcursionID = 3, LugarLlegadaE = "Varadero", LugarSalidaE = "Parque Normal", HoraLlegadaE =new DateTime(19,0,0), HoraSalida=(7,0,0), DiaLlegadaE = new DateTime(2021, 8, 12), DiaSalidaE = new DateTime(2021, 8, 12), Precio = 40.00, DescripcionE = "Con unos 30 kilómetros de largo, de los que 22 son playas, Varadero está considerado, por su perenne luz tropical, su exótica y exuberante vegetación y la calidad de sus aguas, uno de los principales atractivos para los viajeros de todo el mundo. La Playa de Varadero, o Playa Azul, hermosísimo enclave de arena rosa y blanca y agua cristalina, es una de las playas más espectaculares del mundo. Y, sin duda, la más bella de toda Cuba"},
                new { ExcursionID = 4, LugarLlegadaE = "Las Terrazas", LugarSalidaE = "Parque Normal", HoraLlegadaE =new DateTime(19,0,0), HoraSalida=(7,0,0), DiaLlegadaE = new DateTime(2021, 8, 12), DiaSalidaE = new DateTime(2021, 8, 12), Precio = 40.00, DescripcionE = "Las Terrazas es una pequeña comunidad turística rural de desarrollo sostenible que te ofrece un entorno único en el conectar con la naturaleza. Situada a 75 kilómetros al oeste de La Habana, este lugar forma parte de la Sierra del Rosario, catalogada por la UNESCO como Reserva de la Biosfera en 1985."}

            );

            modelBuilder.Entity<Facilidad>().HasData(
                new{ FacilidadID = 1 , DescripcionF = "todo incluido" },
                new {FacilidadID = 2, DescripcionF = "mesa buffet"},
                new {FacilidadID = 3, DescripcionF = "piscina interior, spa"},
                new {FacilidadID = 4, DescripcionF = "gimnasio, sala de juegos"},
                new {FacilidadID = 5, DescripcionF = "servicio de taxi"},
                new {FacilidadID = 6, DescripcionF = "servicio de internet"}


            )


            modelBuilder.Entity<Oferta>().HasData(
                new{ OfertaID = 1, HotelID = 1, DescripcionO = "Habitación para dos personas con cama matrimonial para una excelente velada romántica. Baño con jacuzzy con sales arómaticas ", PrecioO = 75.00},
            )
        }

    }
}