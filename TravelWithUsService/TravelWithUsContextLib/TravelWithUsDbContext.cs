using Microsoft.EntityFrameworkCore;
using TravelWithUsService.Models;
using System;

namespace TravelWithUsService.DBContext
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
            optionsBuilder.UseSqlServer($"Server=(localDB)\\MSSQLLocalDB;Database=TravelWithUsDB;Integrated Security=true;"
            , o => o.UseQuerySplittingBehavior(QuerySplittingBehavior.SplitQuery));
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
                    ri.ReservaIndividualID,
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

            this.SeedData(modelBuilder);
        }

        private void SeedData(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Agencia>().HasData(
                new { AgenciaID = 1, Nombre = "Cubanacan", Direccion = "Playa", Email = "cubanacan@gmail.com", Fax = "78538964", Descripcion = "Agencia de turismo que le permitira conocer diferentes lugares en toda la isla, con excelentes servicios en hoteles y casas de arrendamiento, asi como alquiler de autos." },
                new { AgenciaID = 2, Nombre = "Gaviota", Direccion = "Plaza", Email = "gaviota@gmail.com", Fax = "76885479", Descripcion = "La Agencia de Viajes gaviota brinda las facilidadesd de conocer maravillosos lugares de Cuba a la vez que disfruta de una agradable estancia. Cuenta con servicio de diferentes aerol??neas , con precios m??dicos y excelente calidad." },
                new { AgenciaID = 3, Nombre = "EcoCuba", Direccion = "Habana Vieja", Email = "ecocuba@gmail.com", Fax = "72086942", Descripcion = "Agencia especializada en el turismo ecol??gico. Cuenta con excursiones a verdaderas maravillas naturales de Cuba y hospedajes en lugares en su mayor??a rurales , especial para disfrutar de un ambiente sano." },
                new { AgenciaID = 4, Nombre = "CaribeTour", Direccion = "Playa", Email = "caribe@gmail.com", Fax = "72028546", Descripcion = " Agencia cubana que cuenta con mas de 200 sitios tur??sticos para visitar en Cuba en su cat??logo , la mayor??a de estos con estrecha relaci??n con otros pa??ses del caribe y Am??rica Latina. " },
                new { AgenciaID = 5, Nombre = "CubaViaje", Direccion = "Vedado", Email = "cubaviaje@gmail.com", Fax = "72028642", Descripcion = " Agencia cubana creada hace poco mas de dos a??os que en su cat??logo muestra diversas opciones encaminadas principalmente al publico joven. " }

            );

            modelBuilder.Entity<Hotel>().HasData(
                new { HotelID = 1, Nombre = "Melia Cohiba", Direccion = "Plaza", Categoria = 3, Descripcion = "Meli?? Cohiba ofrece espectaculares vistas sobre el mar y la ciudad. Un excepcional hotel para viajes de placer o negocios que destaca por su ubicaci??n, su exclusivo servicio The Level y su animada sala de fiestas." },
                new { HotelID = 2, Nombre = "Varadero", Direccion = "Habana Vieja", Categoria = 5, Descripcion = "Este hotel de lujo con todo incluido tiene un impresionante vest??bulo circular con vistas al mar y est?? a 1,4 km del Varadero Golf Club y a 9 km de la Pen??nsula de Hicacos." },
                new { HotelID = 3, Nombre = "Panorama", Direccion = "Habana Vieja", Categoria = 5, Descripcion = "Hotel 4 estrellas, ubicado en la zona residencial de Miramar, donde se encuentran la mayor??a de embajadas y firmas comerciales. Dispone de amplias habitaciones, una espectacular piscina, una completa oferta gastron??mica, el servicio Privilege Exclusive Rooms and Services y tres salones de reuniones. Recomendado para viajes de negocios, grupos, parejas." },
                new { HotelID = 4, Nombre = "Hotel Nacional", Direccion = "Plaza", Categoria = 4, Descripcion = "Hotel Nacional es una magn??fica elecci??n para los viajeros que visiten La Habana, ya que ofrece un ambiente elegante, adem??s de numerosos servicios dise??ados para mejorar tu estancia. Al estar cerca de los puntos de referencia m??s conocidos de La Habana es un magn??fico destino para turistas." },
                new { HotelID = 5, Nombre = "Habana Libre", Direccion = "Plaza", Categoria = 3, Descripcion = "El hotel 5 Estrellas Tryp Habana Libre, uno de los m??s emblem??ticos de La Habana, est?? localizado en el coraz??n del Vedado. El hotel, con una altura majestuosa de 25 plantas y 572 habitaciones, ofrece impresionantes vistas de la ciudad y el mar. Ideal para hombres de negocios, eventos, vacaciones y lunas de miel." }
            );
            //Para las excursiones prolongadas hay q agregar diferentes dias en salida y llegada .Tambien se puede conocer si tiene un hotel asociado
            modelBuilder.Entity<Excursion>().HasData(
                new { ExcursionID = 1, LugarLlegada = "Cuevas de  Saturno", LugarSalida = "Parque Normal", FechaLlegada = new DateTime(2021, 6, 6, 7, 0, 0), FechaSalida = new DateTime(2021, 6, 5, 19, 0, 0), Precio = (decimal)17.00, Descripcion = "A unos 12 km de Matanzas, Cuba en direcci??n Varadero se encuentra una gruta a la que aflora un lago de aguas cristalinas conocida con el nombre de Cueva Saturno. Se observan abundantes estalagmitas y estalactitas. El lago tiene una profundidad de 18 metros pero sus aguas son de una transparencia tan incre??ble que permiten ver el fondo sin dificultad alguna." },
                new { ExcursionID = 2, LugarLlegada = "valle de Vi??ales", LugarSalida = "Parque Normal", FechaLlegada = new DateTime(2021, 7, 15, 7, 0, 0), FechaSalida = new DateTime(2021, 7, 15, 19, 0, 0), Precio = (decimal)25.00, Descripcion = "Est?? ubicado en la provincia de Pinar del R??o, zona m??s occidental de Cuba, exactamente en el grupo monta??oso de la Cordillera de Guaniguanico. Este Valle y gran parte de la sierra que lo rodea fue aprobado en 1999 como Parque Nacional y, en diciembre de ese mismo a??o, fue declarado por la UNESCO Patrimonio de la Humanidad, en la categor??a de Paisaje Cultural. Posee adem??s la condici??n de Monumento Nacional." },
                new { ExcursionID = 3, LugarLlegada = "Varadero", LugarSalida = "Parque Normal", FechaLlegada = new DateTime(2021, 8, 12, 7, 0, 0), FechaSalida = new DateTime(2021, 8, 12, 19, 0, 0), Precio = (decimal)40.00, Descripcion = "Con unos 30 kil??metros de largo, de los que 22 son playas, Varadero est?? considerado, por su perenne luz tropical, su ex??tica y exuberante vegetaci??n y la calidad de sus aguas, uno de los principales atractivos para los viajeros de todo el mundo. La Playa de Varadero, o Playa Azul, hermos??simo enclave de arena rosa y blanca y agua cristalina, es una de las playas m??s espectaculares del mundo. Y, sin duda, la m??s bella de toda Cuba" },
                new { ExcursionID = 4, LugarLlegada = "Las Terrazas", LugarSalida = "Parque Normal", FechaLlegada = new DateTime(2021, 8, 12, 7, 0, 0), FechaSalida = new DateTime(2021, 8, 12, 19, 0, 0), Precio = (decimal)40.00, Descripcion = "Las Terrazas es una peque??a comunidad tur??stica rural de desarrollo sostenible que te ofrece un entorno ??nico en el conectar con la naturaleza. Situada a 75 kil??metros al oeste de La Habana, este lugar forma parte de la Sierra del Rosario, catalogada por la UNESCO como Reserva de la Biosfera en 1985." }

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
                new { OfertaID = 1, HotelID = 1, Descripcion = "Habitaci??n para dos personas con cama matrimonial para una excelente velada rom??ntica. Ba??o con jacuzzy con sales ar??maticas ", Precio = (decimal)75.00 },
                new { OfertaID = 2, HotelID = 1, Descripcion = "Habitaci??n para una persona con servicio a la habitacion ", Precio = (decimal)30.00 },
                new { OfertaID = 3, HotelID = 1, Descripcion = "Habitaci??n para dos personas . Ba??o con jacuzzy con sales ar??maticas ", Precio = (decimal)60.00 },
                new { OfertaID = 1, HotelID = 2, Descripcion = "Habitaci??n para familia.Servicio de habiatcion ", Precio = (decimal)100.00 },
                new { OfertaID = 2, HotelID = 2, Descripcion = "Oferta para un dia con derecho a habitacion y piscina.", Precio = (decimal)20.00 },
                new { OfertaID = 3, HotelID = 2, Descripcion = "Fin de semana exclusivo ", Precio = (decimal)150.00 },
                new { OfertaID = 1, HotelID = 3, Descripcion = "Habitaci??n para dos personas . Ba??o con jacuzzy con sales ar??maticas ", Precio = (decimal)60.00 },
                new { OfertaID = 2, HotelID = 3, Descripcion = "Habitaci??n familiar para un dia y una noche con servivio d spa. ", Precio = (decimal)100.00 },
                new { OfertaID = 3, HotelID = 3, Descripcion = "Habitaci??n para una persona con servicio a la habitacion ", Precio = (decimal)40.00 },
                new { OfertaID = 2, HotelID = 4, Descripcion = "Fin de semana romantico ,para parejas de aniversario con descuento. ", Precio = (decimal)80.00 }

            );


            modelBuilder.Entity<Turista>().HasData(
                new { TuristaID = 1, Nombre = "Juan Gonzalez", Nacionalidad = "Espa??a", Email = "juan@travelwithus.com" },
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
            modelBuilder.Entity<Paquete>().HasData(
                new { Codigo = 1, Descripcion = "Viaje maritimo", Precio = (decimal)75, Duracion = new TimeSpan(5, 10, 4), ExcursionID = 1 },
                new { Codigo = 2, Descripcion = "Viaje rural", Precio = (decimal)50, Duracion = new TimeSpan(3, 10, 4), ExcursionID = 2 },
                new { Codigo = 3, Descripcion = "Viaje a zona de playa ", Precio = (decimal)100, Duracion = new TimeSpan(2, 10, 4), ExcursionID = 1 },
                new { Codigo = 4, Descripcion = "Viaje a lugares historicos", Precio = (decimal)60, Duracion = new TimeSpan(7, 10, 5), ExcursionID = 1 }
            );

            modelBuilder.Entity<ReservaExcursion>().HasData(
                new { TuristaID = 7, AgenciaID = 2, ExcursionID = 1 },
                new { TuristaID = 5, AgenciaID = 5, ExcursionID = 1 },
                new { TuristaID = 4, AgenciaID = 1, ExcursionID = 1 },
                new { TuristaID = 1, AgenciaID = 2, ExcursionID = 2 },
                new { TuristaID = 9, AgenciaID = 2, ExcursionID = 1 },
                new { TuristaID = 6, AgenciaID = 2, ExcursionID = 4 },
                new { TuristaID = 2, AgenciaID = 3, ExcursionID = 3 }
            );

            modelBuilder.Entity<ReservaIndividual>().HasData(
                    new { ReservaIndividualID = 1, TuristaID = 7, AgenciaID = 2, HotelID = 1, OfertaID = 1, Acompanantes = 1, Precio = (decimal)30, Llegada = new DateTime(2021, 7, 12, 7, 0, 0), Salida = new DateTime(2021, 10, 12, 7, 0, 0) },
                    new { ReservaIndividualID = 2, TuristaID = 2, AgenciaID = 2, HotelID = 1, OfertaID = 3, Acompanantes = 2, Precio = (decimal)40, Llegada = new DateTime(2021, 7, 10, 7, 0, 0), Salida = new DateTime(2021, 10, 8, 9, 0, 0) },
                    new { ReservaIndividualID = 3, TuristaID = 3, AgenciaID = 1, HotelID = 3, OfertaID = 1, Acompanantes = 0, Precio = (decimal)20, Llegada = new DateTime(2021, 4, 1, 12, 0, 0), Salida = new DateTime(2021, 5, 1, 9, 0, 0) },
                    new { ReservaIndividualID = 4, TuristaID = 2, AgenciaID = 5, HotelID = 4, OfertaID = 2, Acompanantes = 1, Precio = (decimal)50, Llegada = new DateTime(2021, 12, 10, 7, 0, 0), Salida = new DateTime(2021, 12, 11, 7, 0, 0) },
                    new { ReservaIndividualID = 5, TuristaID = 7, AgenciaID = 2, HotelID = 1, OfertaID = 2, Acompanantes = 1, Precio = (decimal)30, Llegada = new DateTime(2021, 7, 12, 7, 0, 0), Salida = new DateTime(2021, 10, 12, 7, 0, 0) },
                    new { ReservaIndividualID = 6, TuristaID = 8, AgenciaID = 3, HotelID = 2, OfertaID = 3, Acompanantes = 5, Precio = (decimal)30, Llegada = new DateTime(2021, 7, 12, 7, 0, 0), Salida = new DateTime(2021, 10, 12, 7, 0, 0) },
                    new { ReservaIndividualID = 7, TuristaID = 2, AgenciaID = 3, HotelID = 3, OfertaID = 3, Acompanantes = 5, Precio = (decimal)30, Llegada = new DateTime(2021, 7, 12, 7, 0, 0), Salida = new DateTime(2021, 10, 12, 7, 0, 0) }
            );

            modelBuilder.Entity<ReservaPaquete>().HasData(
                new { TuristaID = 7, AgenciaID = 2, Codigo = 1, Precio = 30.00m, Participantes = 2, Salida = new DateTime(2021, 10, 12, 7, 0, 0) },
                    new { TuristaID = 2, AgenciaID = 2, Codigo = 1, Precio = 40.00m, Participantes = 4, Salida = new DateTime(2021, 10, 8, 9, 0, 0) },
                    new { TuristaID = 3, AgenciaID = 1, Codigo = 3, Precio = 20.00m, Participantes = 2, Salida = new DateTime(2021, 5, 1, 9, 0, 0) },
                    new { TuristaID = 2, AgenciaID = 5, Codigo = 4, Precio = 50.00m, Participantes = 5, Salida = new DateTime(2021, 12, 11, 7, 0, 0) },
                    new { TuristaID = 1, AgenciaID = 2, Codigo = 1, Precio = 30.00m, Participantes = 10, Salida = new DateTime(2021, 10, 12, 7, 0, 0) },
                    new { TuristaID = 8, AgenciaID = 3, Codigo = 2, Precio = 30.00m, Participantes = 4, Salida = new DateTime(2021, 10, 12, 7, 0, 0) },
                    new { TuristaID = 9, AgenciaID = 3, Codigo = 2, Precio = 40.00m, Participantes = 5, Salida = new DateTime(2021, 10, 12, 7, 0, 0) }
            );



            // Configuring characteristics for Paquete.
            // modelBuilder.Entity<Paquete>()
            //     .HasMany(p => p.Excursion)
            //     .WithMany(e => e.Paquetes)
            //     .HasForeignKey(p => p.ExcursionID)
            //     .UsingEntity( j => j.HasData(new{ExcursionExcursionID = 1, PaquetesCodigo = 1}));

            // Configuring characteristics for Excursion.
            modelBuilder.Entity<Excursion>()
                .HasMany(e => e.Hoteles)
                .WithMany(h => h.Excursiones)
                .UsingEntity(j => j.HasData(new { ExcursionesExcursionID = 1, HotelesHotelID = 1 }
                       , new { ExcursionesExcursionID = 2, HotelesHotelID = 2 }));




            // Configuring characteristics for Hotel.
            // modelBuilder.Entity<Hotel>()
            //     .HasOne(h => h.Hotel)      //no se si sea necesario poner esta relacion tambien, aunq creo q no
            //     .WithMany(e => e.Excursiones)
            //     .UsingEntity( j => j.HasData(new{ExcursionExcursionID = 1, HotelesHotelID = 1}));
        }
    }
}
