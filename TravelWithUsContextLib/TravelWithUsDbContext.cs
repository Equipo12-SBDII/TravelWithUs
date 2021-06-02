using Microsoft.EntityFrameworkCore;
using TravelWithUs.Models;
using System;

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
            optionsBuilder.UseSqlServer($"Server=(localDB)\\MSSQLLocalDB;Database=TravelWithUsDB;Integrated Security=true;");
            // string path = System.IO.Path.Combine(
            //     "..", "TravelWithUsDB.db");
            // optionsBuilder.UseSqlite($"Filename={path}");


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

            SeedData(modelBuilder);
        }
        
        private void SeedData(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Agencia>().HasData(
                new { AgenciaID = 1, Nombre = "Cubanacan", Direccion = "Playa", Email = "cubanacan@gmail.com", Fax = "78538964", Descripcion = "Agencia de turismo que le permitira conocer diferentes lugares en toda la isla, con excelentes servicios en hoteles y casas de arrendamiento, asi como alquiler de autos." },
                new { AgenciaID = 2, Nombre = "Gaviota", Direccion = "Plaza", Email = "gaviota@gmail.com", Fax = "76885479", Descripcion = "La Agencia de Viajes gaviota brinda las facilidadesd de conocer maravillosos lugares de Cuba a la vez que disfruta de una agradable estancia. Cuenta con servicio de diferentes aerolíneas , con precios módicos y excelente calidad." },
                new { AgenciaID = 3, Nombre = "EcoCuba", Direccion = "Habana Vieja", Email = "ecocuba@gmail.com", Fax = "72086942", Descripcion = "Agencia especializada en el turismo ecológico. Cuenta con excursiones a verdaderas maravillas naturales de Cuba y hospedajes en lugares en su mayoría rurales , especial para disfrutar de un ambiente sano." },
                new { AgenciaID = 4, Nombre = "CaribeTour", Direccion = "Playa", Email = "caribe@gmail.com", Fax = "72028546", Descripcion = " Agencia cubana que cuenta con mas de 200 sitios turísticos para visitar en Cuba en su catálogo , la mayoría de estos con estrecha relación con otros países del caribe y América Latina. " },
                new { AgenciaID = 5, Nombre = "CubaViaje", Direccion = "Vedado", Email = "cubaviaje@gmail.com", Fax = "72028642", Descripcion = " Agencia cubana creada hace poco mas de dos años que en su catálogo muestra diversas opciones encaminadas principalmente al publico joven. " }

            );

            modelBuilder.Entity<Hotel>().HasData(
                new { HotelID = 1, Nombre = "Melia Cohiba", Direccion = "Plaza", Categoria = 3, Descripcion = "Meliá Cohiba ofrece espectaculares vistas sobre el mar y la ciudad. Un excepcional hotel para viajes de placer o negocios que destaca por su ubicación, su exclusivo servicio The Level y su animada sala de fiestas." },
                new { HotelID = 2, Nombre = "Varadero", Direccion = "Habana Vieja", Categoria = 5, Descripcion = "Este hotel de lujo con todo incluido tiene un impresionante vestíbulo circular con vistas al mar y está a 1,4 km del Varadero Golf Club y a 9 km de la Península de Hicacos." },
                new { HotelID = 3, Nombre = "Panorama", Direccion = "Habana Vieja", Categoria = 5, Descripcion = "Hotel 4 estrellas, ubicado en la zona residencial de Miramar, donde se encuentran la mayoría de embajadas y firmas comerciales. Dispone de amplias habitaciones, una espectacular piscina, una completa oferta gastronómica, el servicio Privilege Exclusive Rooms and Services y tres salones de reuniones. Recomendado para viajes de negocios, grupos, parejas." },
                new { HotelID = 4, Nombre = "Hotel Nacional", Direccion = "Plaza", Categoria = 4, Descripcion = "Hotel Nacional es una magnífica elección para los viajeros que visiten La Habana, ya que ofrece un ambiente elegante, además de numerosos servicios diseñados para mejorar tu estancia. Al estar cerca de los puntos de referencia más conocidos de La Habana es un magnífico destino para turistas." },
                new { HotelID = 5, Nombre = "Habana Libre", Direccion = "Plaza", Categoria = 3, Descripcion = "El hotel 5 Estrellas Tryp Habana Libre, uno de los más emblemáticos de La Habana, está localizado en el corazón del Vedado. El hotel, con una altura majestuosa de 25 plantas y 572 habitaciones, ofrece impresionantes vistas de la ciudad y el mar. Ideal para hombres de negocios, eventos, vacaciones y lunas de miel." }
            );
            //Para las excursiones prolongadas hay q agregar diferentes dias en salida y llegada .Tambien se puede conocer si tiene un hotel asociado
            modelBuilder.Entity<Excursion>().HasData(
                new { ExcursionID = 1, LugarLlegada = "Cuevas de  Saturno", LugarSalida = "Parque Normal", FechaLlegada = new DateTime(2021, 7, 12, 19, 0, 0), FechaSalida = new DateTime(2021, 7, 12, 7, 0, 0), Precio = (decimal)17.00, Descripcion = "A unos 12 km de Matanzas, Cuba en dirección Varadero se encuentra una gruta a la que aflora un lago de aguas cristalinas conocida con el nombre de Cueva Saturno. Se observan abundantes estalagmitas y estalactitas. El lago tiene una profundidad de 18 metros pero sus aguas son de una transparencia tan increíble que permiten ver el fondo sin dificultad alguna." },
                new { ExcursionID = 2, LugarLlegada = "valle de Viñales", LugarSalida = "Parque Normal", FechaLlegada = new DateTime(2021, 7, 15, 19, 0, 0), FechaSalida = new DateTime(2021, 7, 15, 7, 0, 0), Precio = (decimal)25.00, Descripcion = "Está ubicado en la provincia de Pinar del Río, zona más occidental de Cuba, exactamente en el grupo montañoso de la Cordillera de Guaniguanico. Este Valle y gran parte de la sierra que lo rodea fue aprobado en 1999 como Parque Nacional y, en diciembre de ese mismo año, fue declarado por la UNESCO Patrimonio de la Humanidad, en la categoría de Paisaje Cultural. Posee además la condición de Monumento Nacional." },
                new { ExcursionID = 3, LugarLlegada = "Varadero", LugarSalida = "Parque Normal", FechaLlegada = new DateTime(2021, 8, 12, 19, 0, 0), FechaSalida = new DateTime(2021, 8, 12, 7, 0, 0), Precio = (decimal)40.00, Descripcion = "Con unos 30 kilómetros de largo, de los que 22 son playas, Varadero está considerado, por su perenne luz tropical, su exótica y exuberante vegetación y la calidad de sus aguas, uno de los principales atractivos para los viajeros de todo el mundo. La Playa de Varadero, o Playa Azul, hermosísimo enclave de arena rosa y blanca y agua cristalina, es una de las playas más espectaculares del mundo. Y, sin duda, la más bella de toda Cuba" },
                new { ExcursionID = 4, LugarLlegada = "Las Terrazas", LugarSalida = "Parque Normal", FechaLlegada = new DateTime(2021, 8, 12, 19, 0, 0), FechaSalida = new DateTime(2021, 8, 12, 7, 0, 0), Precio = (decimal)40.00, Descripcion = "Las Terrazas es una pequeña comunidad turística rural de desarrollo sostenible que te ofrece un entorno único en el conectar con la naturaleza. Situada a 75 kilómetros al oeste de La Habana, este lugar forma parte de la Sierra del Rosario, catalogada por la UNESCO como Reserva de la Biosfera en 1985." }

            );

            modelBuilder.Entity<Facilidad>().HasData(
                new { FacilidadID = 1, Descripcion = "todo incluido" },
                new { FacilidadID = 2, Descripcion = "mesa buffet" },
                new { FacilidadID = 3, Descripcion = "piscina interior, spa" },
                new { FacilidadID = 4, Descripcion = "gimnasio, sala de juegos" },
                new { FacilidadID = 5, Descripcion = "servicio de taxi" },
                new { FacilidadID = 6, Descripcion = "servicio de internet" }
            );


            modelBuilder.Entity<Oferta>().HasData(
                new { OfertaID = 1, HotelID = 1, Descripcion = "Habitación para dos personas con cama matrimonial para una excelente velada romántica. Baño con jacuzzy con sales arómaticas ", Precio = (decimal)75.00 },
                new { OfertaID = 2, HotelID = 1, Descripcion = "Habitación para una persona con servicio a la habitacion ", Precio = (decimal)30.00 },
                new { OfertaID = 3, HotelID = 1, Descripcion = "Habitación para dos personas . Baño con jacuzzy con sales arómaticas ", Precio = (decimal)60.00 },
                new { OfertaID = 1, HotelID = 2, Descripcion = "Habitación para familia.Servicio de habiatcion ", Precio = (decimal)100.00 },
                new { OfertaID = 2, HotelID = 2, Descripcion = "Oferta para un dia con derecho a habitacion y piscina.", Precio = (decimal)20.00 },
                new { OfertaID = 3, HotelID = 2, Descripcion = "Fin de semana exclusivo ", Precio = (decimal)150.00 },
                new { OfertaID = 1, HotelID = 3, Descripcion = "Habitación para dos personas . Baño con jacuzzy con sales arómaticas ", Precio = (decimal)60.00 },
                new { OfertaID = 2, HotelID = 3, Descripcion = "Habitación familiar para un dia y una noche con servivio d spa. ", Precio = (decimal)100.00 },
                new { OfertaID = 3, HotelID = 3, Descripcion = "Habitación para una persona con servicio a la habitacion ", Precio = (decimal)40.00 },
                new { OfertaID = 2, HotelID = 4, Descripcion = "Fin de semana romantico ,para parejas de aniversario con descuento. ", Precio = (decimal)80.00 }

            );


            modelBuilder.Entity<Turista>().HasData(
                new { TuristaID = 1, Nombre = "Juan Gonzalez", Nacionalidad = "España", Email = "juan@travelwithus.com" },
                new { TuristaID = 2, Nombre = "Luci Wong", Nacionalidad = "China", Email = "luci@travelwithus.com" },
                new { TuristaID = 3, Nombre = "Clear Yort", Nacionalidad = "Alemania", Email = "clear@travelwithus.com" },
                new { TuristaID = 4, Nombre = "Armando Perez", Nacionalidad = "Mexico", Email = "arman@travelwithus.com" },
                new { TuristaID = 5, Nombre = "Hector Perez", Nacionalidad = "Panama", Email = "perez@travelwithus.com" },
                new { TuristaID = 6, Nombre = "Lidia Perez", Nacionalidad = "Panama", Email = "perez25@travelwithus.com" },
                new { TuristaID = 7, Nombre = "Jhon Smith", Nacionalidad = "Canada", Email = "smith@travelwithus.com" },
                new { TuristaID = 8, Nombre = "Hissake Li", Nacionalidad = "Japon", Email = "li@travelwithus.com" },
                new { TuristaID = 9, Nombre = "Yen Gij", Nacionalidad = "japon", Email = "yen@travelwithus.com" },
                new { TuristaID = 10, Nombre = "Liana Ruz", Nacionalidad = "Suecia", Email = "ruz@travelwithus.com" }
            );
            modelBuilder.Entitity<Paquete>().HasData(
                new{ Codigo = 1, Descripcion="Viaje maritimo" ,Precio=(decimal)75 ,Duracion= new TimeSpan(5,10,4)},
                new{ Codigo = 2, Descripcion="Viaje rural" ,Precio=(decimal)50 ,Duracion= new TimeSpan(3,10,4)},
                new{ Codigo = 1, Descripcion="Viaje a zona de playa " ,Precio=(decimal)100 ,Duracion= new TimeSpan(2,10,4) },
                new{ Codigo = 1, Descripcion="Viaje a lugares historicos" ,Precio=(decimal)60 ,Duracion= new TimeSpan(7,10,5) }
            );

            modelBuilder.Entitity<ReservaExcursion>().HasData(
                new {TuirstaID= 7, AgenciaID=2, ExcursionID=1 },
                new {TuirstaID= 5, AgenciaID=5, ExcursionID=1 },
                new {TuirstaID= 4, AgenciaID=1, ExcursionID=1 },
                new {TuirstaID= 1, AgenciaID=2, ExcursionID=2 },
                new {TuirstaID= 9, AgenciaID=2, ExcursionID=1 },
                new {TuirstaID= 6, AgenciaID=2, ExcursionID=4 },
                new {TuirstaID= 2, AgenciaID=3, ExcursionID=3 }
              );

            modelBuilder.Entitity<ReservaIndividual>().HasData(
               new {TuirstaID= 7, AgenciaID=2, HotelID=1, OfertaID=1, Acompanantes =1, Precio=(decimal)30, Llegada=new DateTime(2021, 7, 12, 7, 0, 0) , Salida= new DateTime(2021, 10, 12, 7, 0, 0)  },
               new {TuirstaID= 2, AgenciaID=2, HotelID=1, OfertaID=3, Acompanantes =2, Precio=(decimal)40, Llegada=new DateTime(2021, 7, 10, 7, 0, 0) , Salida= new DateTime(2021, 10, 8, 9, 0, 0)  },
               new {TuirstaID= 3, AgenciaID=1, HotelID=3, OfertaID=1, Acompanantes =0, Precio=(decimal)20, Llegada=new DateTime(2021, 4, 1, 12, 0, 0) , Salida= new DateTime(2021, 5, 1, 9, 0, 0)  },
               new {TuirstaID= 2, AgenciaID=5, HotelID=4, OfertaID=2, Acompanantes =1, Precio=(decimal)50, Llegada=new DateTime(2021, 12, 10, 7, 0, 0) , Salida= new DateTime(2021, 15, 11, 7, 0, 0)  },
               new {TuirstaID= 7, AgenciaID=2, HotelID=1, OfertaID=2, Acompanantes =1, Precio=(decimal)30, Llegada=new DateTime(2021, 7, 12, 7, 0, 0) , Salida= new DateTime(2021, 10, 12, 7, 0, 0)  },
               new {TuirstaID= 8, AgenciaID=3, HotelID=2, OfertaID=3, Acompanantes =5, Precio=(decimal)30, Llegada=new DateTime(2021, 7, 12, 7, 0, 0) , Salida= new DateTime(2021, 10, 12, 7, 0, 0)  },
               new {TuirstaID= 2, AgenciaID=3,  HotelID=3 }
            );

             modelBuilder.Entitity<ReservaPaquete>().HasData(
              new {TuirstaID= 7, AgenciaID=2, Codigo=1,  Precio=(decimal)30, Participante=2, Salida= new DateTime(2021, 10, 12, 7, 0, 0)  },
              new {TuirstaID= 2, AgenciaID=2, Codigo=1,   Precio=(decimal)40, Participante=4, Salida= new DateTime(2021, 10, 8, 9, 0, 0)  },
              new {TuirstaID= 3, AgenciaID=1, Codigo=3,  Precio=(decimal)20, Participante=2 , Salida= new DateTime(2021, 5, 1, 9, 0, 0)  },
              new {TuirstaID= 2, AgenciaID=5, Codigo=4,   Precio=(decimal)50, Participante=5 , Salida= new DateTime(2021, 15, 11, 7, 0, 0)  },
              new {TuirstaID= 7, AgenciaID=2, Codigo=1,   Precio=(decimal)30, Participante=10 , Salida= new DateTime(2021, 10, 12, 7, 0, 0)  },
              new {TuirstaID= 8, AgenciaID=3, Codigo=2,   Precio=(decimal)30,Participante=4, Salida= new DateTime(2021, 10, 12, 7, 0, 0)  },
              new {TuirstaID= 8, AgenciaID=3, Codigo=2,   Precio=(decimal)40,Participante=5, Salida= new DateTime(2021, 10, 12, 7, 0, 0)  }
            );
        }
    

    }
}
