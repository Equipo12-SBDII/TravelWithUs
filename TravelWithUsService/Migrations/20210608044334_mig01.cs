using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace TravelWithUsService.Migrations
{
    public partial class mig01 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Agencia",
                columns: table => new
                {
                    IdA = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NombreA = table.Column<string>(type: "nvarchar(40)", maxLength: 40, nullable: false),
                    DescripcionA = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: true),
                    DireccionA = table.Column<string>(type: "nvarchar(120)", maxLength: 120, nullable: false),
                    EmailA = table.Column<string>(type: "nvarchar(120)", maxLength: 120, nullable: false),
                    NumFaxA = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Agencia", x => x.IdA);
                });

            migrationBuilder.CreateTable(
                name: "Excursion",
                columns: table => new
                {
                    IdE = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Precio = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    DescripcionE = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: true),
                    FechaSalidaE = table.Column<DateTime>(type: "datetime2", nullable: false),
                    FechaLlegadaE = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LugarSalidaE = table.Column<string>(type: "nvarchar(120)", maxLength: 120, nullable: false),
                    LugarLlegadaE = table.Column<string>(type: "nvarchar(120)", maxLength: 120, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Excursion", x => x.IdE);
                });

            migrationBuilder.CreateTable(
                name: "Facilidades",
                columns: table => new
                {
                    IdF = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DescripcionF = table.Column<string>(type: "nvarchar(240)", maxLength: 240, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Facilidades", x => x.IdF);
                });

            migrationBuilder.CreateTable(
                name: "Hotel",
                columns: table => new
                {
                    IdH = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NombreH = table.Column<string>(type: "nvarchar(40)", maxLength: 40, nullable: false),
                    DescripcionH = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: true),
                    DireccionH = table.Column<string>(type: "nvarchar(120)", maxLength: 120, nullable: false),
                    CategoriaH = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Hotel", x => x.IdH);
                });

            migrationBuilder.CreateTable(
                name: "Turistas",
                columns: table => new
                {
                    IdT = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NombreT = table.Column<string>(type: "nvarchar(120)", maxLength: 120, nullable: false),
                    NacionalidadT = table.Column<string>(type: "nvarchar(120)", maxLength: 120, nullable: true),
                    EmailT = table.Column<string>(type: "nvarchar(120)", maxLength: 120, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Turistas", x => x.IdT);
                });

            migrationBuilder.CreateTable(
                name: "Paquete",
                columns: table => new
                {
                    CodigoP = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DescripcionP = table.Column<string>(type: "nvarchar(240)", maxLength: 240, nullable: true),
                    Precio = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    DuracionP = table.Column<TimeSpan>(type: "time", nullable: false),
                    ExcursionID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Paquete", x => x.CodigoP);
                    table.ForeignKey(
                        name: "FK_Paquete_Excursion_ExcursionID",
                        column: x => x.ExcursionID,
                        principalTable: "Excursion",
                        principalColumn: "IdE",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ExcursionHotel",
                columns: table => new
                {
                    ExcursionesExcursionID = table.Column<int>(type: "int", nullable: false),
                    HotelesHotelID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ExcursionHotel", x => new { x.ExcursionesExcursionID, x.HotelesHotelID });
                    table.ForeignKey(
                        name: "FK_ExcursionHotel_Excursion_ExcursionesExcursionID",
                        column: x => x.ExcursionesExcursionID,
                        principalTable: "Excursion",
                        principalColumn: "IdE",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ExcursionHotel_Hotel_HotelesHotelID",
                        column: x => x.HotelesHotelID,
                        principalTable: "Hotel",
                        principalColumn: "IdH",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Ofertas",
                columns: table => new
                {
                    IdH = table.Column<int>(type: "int", nullable: false),
                    IdO = table.Column<int>(type: "int", nullable: false),
                    Precio = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    DescripcionO = table.Column<string>(type: "nvarchar(240)", maxLength: 240, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ofertas", x => new { x.IdO, x.IdH });
                    table.ForeignKey(
                        name: "FK_Ofertas_Hotel_IdH",
                        column: x => x.IdH,
                        principalTable: "Hotel",
                        principalColumn: "IdH",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ReservasExcursiones",
                columns: table => new
                {
                    IdT = table.Column<int>(type: "int", nullable: false),
                    IdA = table.Column<int>(type: "int", nullable: false),
                    IdE = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ReservasExcursiones", x => new { x.IdA, x.IdE, x.IdT });
                    table.ForeignKey(
                        name: "FK_ReservasExcursiones_Agencia_IdA",
                        column: x => x.IdA,
                        principalTable: "Agencia",
                        principalColumn: "IdA",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ReservasExcursiones_Excursion_IdE",
                        column: x => x.IdE,
                        principalTable: "Excursion",
                        principalColumn: "IdE",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ReservasExcursiones_Turistas_IdT",
                        column: x => x.IdT,
                        principalTable: "Turistas",
                        principalColumn: "IdT",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "FacilidadPaquete",
                columns: table => new
                {
                    FacilidadesFacilidadID = table.Column<int>(type: "int", nullable: false),
                    PaquetesCodigo = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FacilidadPaquete", x => new { x.FacilidadesFacilidadID, x.PaquetesCodigo });
                    table.ForeignKey(
                        name: "FK_FacilidadPaquete_Facilidades_FacilidadesFacilidadID",
                        column: x => x.FacilidadesFacilidadID,
                        principalTable: "Facilidades",
                        principalColumn: "IdF",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_FacilidadPaquete_Paquete_PaquetesCodigo",
                        column: x => x.PaquetesCodigo,
                        principalTable: "Paquete",
                        principalColumn: "CodigoP",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ReservasPaquetes",
                columns: table => new
                {
                    IdA = table.Column<int>(type: "int", nullable: false),
                    IdT = table.Column<int>(type: "int", nullable: false),
                    CodigoP = table.Column<int>(type: "int", nullable: false),
                    CompAereaRP = table.Column<string>(type: "nvarchar(40)", maxLength: 40, nullable: true),
                    FechaSalidaRP = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CantParticipantes = table.Column<int>(type: "int", nullable: false),
                    Precio = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ReservasPaquetes", x => new { x.IdA, x.IdT, x.CodigoP });
                    table.ForeignKey(
                        name: "FK_ReservasPaquetes_Agencia_IdA",
                        column: x => x.IdA,
                        principalTable: "Agencia",
                        principalColumn: "IdA",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ReservasPaquetes_Paquete_CodigoP",
                        column: x => x.CodigoP,
                        principalTable: "Paquete",
                        principalColumn: "CodigoP",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ReservasPaquetes_Turistas_IdT",
                        column: x => x.IdT,
                        principalTable: "Turistas",
                        principalColumn: "IdT",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ReservasIndividuales",
                columns: table => new
                {
                    IdRI = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdA = table.Column<int>(type: "int", nullable: false),
                    IdT = table.Column<int>(type: "int", nullable: false),
                    IdH = table.Column<int>(type: "int", nullable: false),
                    IdO = table.Column<int>(type: "int", nullable: false),
                    NumAcompanantes = table.Column<int>(type: "int", nullable: false),
                    CompAereaRI = table.Column<string>(type: "nvarchar(40)", maxLength: 40, nullable: true),
                    Precio = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    FechaLlegadaH = table.Column<DateTime>(type: "datetime2", nullable: false),
                    FechaSalidaH = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ReservasIndividuales", x => new { x.IdRI, x.IdA, x.IdH, x.IdO, x.IdT });
                    table.ForeignKey(
                        name: "FK_ReservasIndividuales_Agencia_IdA",
                        column: x => x.IdA,
                        principalTable: "Agencia",
                        principalColumn: "IdA",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ReservasIndividuales_Ofertas_IdO_IdH",
                        columns: x => new { x.IdO, x.IdH },
                        principalTable: "Ofertas",
                        principalColumns: new[] { "IdO", "IdH" },
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ReservasIndividuales_Turistas_IdT",
                        column: x => x.IdT,
                        principalTable: "Turistas",
                        principalColumn: "IdT",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Agencia",
                columns: new[] { "IdA", "DescripcionA", "DireccionA", "EmailA", "NumFaxA", "NombreA" },
                values: new object[,]
                {
                    { 1, "Agencia de turismo que le permitira conocer diferentes lugares en toda la isla, con excelentes servicios en hoteles y casas de arrendamiento, asi como alquiler de autos.", "Playa", "cubanacan@gmail.com", "78538964", "Cubanacan" },
                    { 2, "La Agencia de Viajes gaviota brinda las facilidadesd de conocer maravillosos lugares de Cuba a la vez que disfruta de una agradable estancia. Cuenta con servicio de diferentes aerolíneas , con precios módicos y excelente calidad.", "Plaza", "gaviota@gmail.com", "76885479", "Gaviota" },
                    { 3, "Agencia especializada en el turismo ecológico. Cuenta con excursiones a verdaderas maravillas naturales de Cuba y hospedajes en lugares en su mayoría rurales , especial para disfrutar de un ambiente sano.", "Habana Vieja", "ecocuba@gmail.com", "72086942", "EcoCuba" },
                    { 4, " Agencia cubana que cuenta con mas de 200 sitios turísticos para visitar en Cuba en su catálogo , la mayoría de estos con estrecha relación con otros países del caribe y América Latina. ", "Playa", "caribe@gmail.com", "72028546", "CaribeTour" },
                    { 5, " Agencia cubana creada hace poco mas de dos años que en su catálogo muestra diversas opciones encaminadas principalmente al publico joven. ", "Vedado", "cubaviaje@gmail.com", "72028642", "CubaViaje" }
                });

            migrationBuilder.InsertData(
                table: "Excursion",
                columns: new[] { "IdE", "DescripcionE", "FechaLlegadaE", "FechaSalidaE", "LugarLlegadaE", "LugarSalidaE", "Precio" },
                values: new object[,]
                {
                    { 1, "A unos 12 km de Matanzas, Cuba en dirección Varadero se encuentra una gruta a la que aflora un lago de aguas cristalinas conocida con el nombre de Cueva Saturno. Se observan abundantes estalagmitas y estalactitas. El lago tiene una profundidad de 18 metros pero sus aguas son de una transparencia tan increíble que permiten ver el fondo sin dificultad alguna.", new DateTime(2021, 6, 6, 7, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2021, 6, 5, 19, 0, 0, 0, DateTimeKind.Unspecified), "Cuevas de  Saturno", "Parque Normal", 17m },
                    { 2, "Está ubicado en la provincia de Pinar del Río, zona más occidental de Cuba, exactamente en el grupo montañoso de la Cordillera de Guaniguanico. Este Valle y gran parte de la sierra que lo rodea fue aprobado en 1999 como Parque Nacional y, en diciembre de ese mismo año, fue declarado por la UNESCO Patrimonio de la Humanidad, en la categoría de Paisaje Cultural. Posee además la condición de Monumento Nacional.", new DateTime(2021, 7, 15, 7, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2021, 7, 15, 19, 0, 0, 0, DateTimeKind.Unspecified), "valle de Viñales", "Parque Normal", 25m },
                    { 3, "Con unos 30 kilómetros de largo, de los que 22 son playas, Varadero está considerado, por su perenne luz tropical, su exótica y exuberante vegetación y la calidad de sus aguas, uno de los principales atractivos para los viajeros de todo el mundo. La Playa de Varadero, o Playa Azul, hermosísimo enclave de arena rosa y blanca y agua cristalina, es una de las playas más espectaculares del mundo. Y, sin duda, la más bella de toda Cuba", new DateTime(2021, 8, 12, 7, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2021, 8, 12, 19, 0, 0, 0, DateTimeKind.Unspecified), "Varadero", "Parque Normal", 40m },
                    { 4, "Las Terrazas es una pequeña comunidad turística rural de desarrollo sostenible que te ofrece un entorno único en el conectar con la naturaleza. Situada a 75 kilómetros al oeste de La Habana, este lugar forma parte de la Sierra del Rosario, catalogada por la UNESCO como Reserva de la Biosfera en 1985.", new DateTime(2021, 8, 12, 7, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2021, 8, 12, 19, 0, 0, 0, DateTimeKind.Unspecified), "Las Terrazas", "Parque Normal", 40m }
                });

            migrationBuilder.InsertData(
                table: "Facilidades",
                columns: new[] { "IdF", "DescripcionF" },
                values: new object[,]
                {
                    { 5, "servicio de taxi" },
                    { 4, "gimnasio, sala de juegos" },
                    { 6, "servicio de internet" },
                    { 2, "mesa buffet" },
                    { 1, "todo incluido" },
                    { 3, "piscina interior, spa" }
                });

            migrationBuilder.InsertData(
                table: "Hotel",
                columns: new[] { "IdH", "CategoriaH", "DescripcionH", "DireccionH", "NombreH" },
                values: new object[,]
                {
                    { 1, 3, "Meliá Cohiba ofrece espectaculares vistas sobre el mar y la ciudad. Un excepcional hotel para viajes de placer o negocios que destaca por su ubicación, su exclusivo servicio The Level y su animada sala de fiestas.", "Plaza", "Melia Cohiba" },
                    { 2, 5, "Este hotel de lujo con todo incluido tiene un impresionante vestíbulo circular con vistas al mar y está a 1,4 km del Varadero Golf Club y a 9 km de la Península de Hicacos.", "Habana Vieja", "Varadero" },
                    { 3, 5, "Hotel 4 estrellas, ubicado en la zona residencial de Miramar, donde se encuentran la mayoría de embajadas y firmas comerciales. Dispone de amplias habitaciones, una espectacular piscina, una completa oferta gastronómica, el servicio Privilege Exclusive Rooms and Services y tres salones de reuniones. Recomendado para viajes de negocios, grupos, parejas.", "Habana Vieja", "Panorama" },
                    { 4, 4, "Hotel Nacional es una magnífica elección para los viajeros que visiten La Habana, ya que ofrece un ambiente elegante, además de numerosos servicios diseñados para mejorar tu estancia. Al estar cerca de los puntos de referencia más conocidos de La Habana es un magnífico destino para turistas.", "Plaza", "Hotel Nacional" },
                    { 5, 3, "El hotel 5 Estrellas Tryp Habana Libre, uno de los más emblemáticos de La Habana, está localizado en el corazón del Vedado. El hotel, con una altura majestuosa de 25 plantas y 572 habitaciones, ofrece impresionantes vistas de la ciudad y el mar. Ideal para hombres de negocios, eventos, vacaciones y lunas de miel.", "Plaza", "Habana Libre" }
                });

            migrationBuilder.InsertData(
                table: "Turistas",
                columns: new[] { "IdT", "EmailT", "NacionalidadT", "NombreT" },
                values: new object[,]
                {
                    { 8, "li@travelwithus.com", "Japon", "Hissake Li" },
                    { 7, "smith@travelwithus.com", "Canada", "Jhon Smith" },
                    { 6, "perez25@travelwithus.com", "Panama", "Lidia Perez" },
                    { 5, "perez@travelwithus.com", "Panama", "Hector Perez" },
                    { 1, "juan@travelwithus.com", "España", "Juan Gonzalez" },
                    { 3, "clear@travelwithus.com", "Alemania", "Clear Yort" },
                    { 2, "luci@travelwithus.com", "China", "Luci Wong" },
                    { 9, "yen@travelwithus.com", "japon", "Yen Gij" },
                    { 4, "arman@travelwithus.com", "Mexico", "Armando Perez" },
                    { 10, "ruz@travelwithus.com", "Suecia", "Liana Ruz" }
                });

            migrationBuilder.InsertData(
                table: "ExcursionHotel",
                columns: new[] { "ExcursionesExcursionID", "HotelesHotelID" },
                values: new object[,]
                {
                    { 1, 1 },
                    { 2, 2 }
                });

            migrationBuilder.InsertData(
                table: "Ofertas",
                columns: new[] { "IdH", "IdO", "DescripcionO", "Precio" },
                values: new object[,]
                {
                    { 2, 3, "Fin de semana exclusivo ", 150m },
                    { 4, 2, "Fin de semana romantico ,para parejas de aniversario con descuento. ", 80m },
                    { 3, 3, "Habitación para una persona con servicio a la habitacion ", 40m },
                    { 3, 2, "Habitación familiar para un dia y una noche con servivio d spa. ", 100m },
                    { 1, 1, "Habitación para dos personas con cama matrimonial para una excelente velada romántica. Baño con jacuzzy con sales arómaticas ", 75m },
                    { 1, 2, "Habitación para una persona con servicio a la habitacion ", 30m },
                    { 1, 3, "Habitación para dos personas . Baño con jacuzzy con sales arómaticas ", 60m },
                    { 2, 1, "Habitación para familia.Servicio de habiatcion ", 100m },
                    { 2, 2, "Oferta para un dia con derecho a habitacion y piscina.", 20m },
                    { 3, 1, "Habitación para dos personas . Baño con jacuzzy con sales arómaticas ", 60m }
                });

            migrationBuilder.InsertData(
                table: "Paquete",
                columns: new[] { "CodigoP", "DescripcionP", "DuracionP", "ExcursionID", "Precio" },
                values: new object[,]
                {
                    { 1, "Viaje maritimo", new TimeSpan(0, 5, 10, 4, 0), 1, 75m },
                    { 2, "Viaje rural", new TimeSpan(0, 3, 10, 4, 0), 2, 50m },
                    { 4, "Viaje a lugares historicos", new TimeSpan(0, 7, 10, 5, 0), 1, 60m },
                    { 3, "Viaje a zona de playa ", new TimeSpan(0, 2, 10, 4, 0), 1, 100m }
                });

            migrationBuilder.InsertData(
                table: "ReservasExcursiones",
                columns: new[] { "IdA", "IdE", "IdT" },
                values: new object[,]
                {
                    { 2, 2, 1 },
                    { 3, 3, 2 },
                    { 1, 1, 4 },
                    { 5, 1, 5 },
                    { 2, 4, 6 },
                    { 2, 1, 7 },
                    { 2, 1, 9 }
                });

            migrationBuilder.InsertData(
                table: "ReservasIndividuales",
                columns: new[] { "IdA", "IdH", "IdO", "IdRI", "IdT", "NumAcompanantes", "CompAereaRI", "FechaLlegadaH", "Precio", "FechaSalidaH" },
                values: new object[,]
                {
                    { 2, 1, 1, 1, 7, 1, null, new DateTime(2021, 7, 12, 7, 0, 0, 0, DateTimeKind.Unspecified), 30m, new DateTime(2021, 10, 12, 7, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 2, 1, 2, 5, 7, 1, null, new DateTime(2021, 7, 12, 7, 0, 0, 0, DateTimeKind.Unspecified), 30m, new DateTime(2021, 10, 12, 7, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 2, 1, 3, 2, 2, 2, null, new DateTime(2021, 7, 10, 7, 0, 0, 0, DateTimeKind.Unspecified), 40m, new DateTime(2021, 10, 8, 9, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 3, 2, 3, 6, 8, 5, null, new DateTime(2021, 7, 12, 7, 0, 0, 0, DateTimeKind.Unspecified), 30m, new DateTime(2021, 10, 12, 7, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 1, 3, 1, 3, 3, 0, null, new DateTime(2021, 4, 1, 12, 0, 0, 0, DateTimeKind.Unspecified), 20m, new DateTime(2021, 5, 1, 9, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 3, 3, 3, 7, 2, 5, null, new DateTime(2021, 7, 12, 7, 0, 0, 0, DateTimeKind.Unspecified), 30m, new DateTime(2021, 10, 12, 7, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 5, 4, 2, 4, 2, 1, null, new DateTime(2021, 12, 10, 7, 0, 0, 0, DateTimeKind.Unspecified), 50m, new DateTime(2021, 12, 11, 7, 0, 0, 0, DateTimeKind.Unspecified) }
                });

            migrationBuilder.InsertData(
                table: "ReservasPaquetes",
                columns: new[] { "IdA", "CodigoP", "IdT", "CompAereaRP", "CantParticipantes", "Precio", "FechaSalidaRP" },
                values: new object[,]
                {
                    { 2, 1, 7, null, 2, 30.00m, new DateTime(2021, 10, 12, 7, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 2, 1, 2, null, 4, 40.00m, new DateTime(2021, 10, 8, 9, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 2, 1, 1, null, 10, 30.00m, new DateTime(2021, 10, 12, 7, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 1, 3, 3, null, 2, 20.00m, new DateTime(2021, 5, 1, 9, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 5, 4, 2, null, 5, 50.00m, new DateTime(2021, 12, 11, 7, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 3, 2, 8, null, 4, 30.00m, new DateTime(2021, 10, 12, 7, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 3, 2, 9, null, 5, 40.00m, new DateTime(2021, 10, 12, 7, 0, 0, 0, DateTimeKind.Unspecified) }
                });

            migrationBuilder.CreateIndex(
                name: "IX_ExcursionHotel_HotelesHotelID",
                table: "ExcursionHotel",
                column: "HotelesHotelID");

            migrationBuilder.CreateIndex(
                name: "IX_FacilidadPaquete_PaquetesCodigo",
                table: "FacilidadPaquete",
                column: "PaquetesCodigo");

            migrationBuilder.CreateIndex(
                name: "IX_Ofertas_IdH",
                table: "Ofertas",
                column: "IdH");

            migrationBuilder.CreateIndex(
                name: "IX_Paquete_ExcursionID",
                table: "Paquete",
                column: "ExcursionID");

            migrationBuilder.CreateIndex(
                name: "IX_ReservasExcursiones_IdE",
                table: "ReservasExcursiones",
                column: "IdE");

            migrationBuilder.CreateIndex(
                name: "IX_ReservasExcursiones_IdT",
                table: "ReservasExcursiones",
                column: "IdT");

            migrationBuilder.CreateIndex(
                name: "IX_ReservasIndividuales_IdA",
                table: "ReservasIndividuales",
                column: "IdA");

            migrationBuilder.CreateIndex(
                name: "IX_ReservasIndividuales_IdO_IdH",
                table: "ReservasIndividuales",
                columns: new[] { "IdO", "IdH" });

            migrationBuilder.CreateIndex(
                name: "IX_ReservasIndividuales_IdT",
                table: "ReservasIndividuales",
                column: "IdT");

            migrationBuilder.CreateIndex(
                name: "IX_ReservasPaquetes_CodigoP",
                table: "ReservasPaquetes",
                column: "CodigoP");

            migrationBuilder.CreateIndex(
                name: "IX_ReservasPaquetes_IdT",
                table: "ReservasPaquetes",
                column: "IdT");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ExcursionHotel");

            migrationBuilder.DropTable(
                name: "FacilidadPaquete");

            migrationBuilder.DropTable(
                name: "ReservasExcursiones");

            migrationBuilder.DropTable(
                name: "ReservasIndividuales");

            migrationBuilder.DropTable(
                name: "ReservasPaquetes");

            migrationBuilder.DropTable(
                name: "Facilidades");

            migrationBuilder.DropTable(
                name: "Ofertas");

            migrationBuilder.DropTable(
                name: "Agencia");

            migrationBuilder.DropTable(
                name: "Paquete");

            migrationBuilder.DropTable(
                name: "Turistas");

            migrationBuilder.DropTable(
                name: "Hotel");

            migrationBuilder.DropTable(
                name: "Excursion");
        }
    }
}
