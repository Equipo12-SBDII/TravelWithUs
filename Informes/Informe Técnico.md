# Informe Técnico

## We Travel With Us


## Autores:

- Manuel Antonio Vilas Valiente
- Penélope Seijo
- Víctor Lantigua

------

## Diccionario de Datos:

#### Agencia

| Llave | Nombre | Tipo |
| :---- | :----- | :--- |
| PK |   IdA     |  int    |
|       |  NombreA      |  string  |
|       | DescripcionA | string |
| | DireccionA | string |
| | EmailA | string |
| | NumFaxA | string |

#### Hotel

| Llave | Nombre       | Tipo   |
| :---- | :----------- | :----- |
| PK    | IdH          | int    |
|       | NombreH      | string |
|       | DescripcionH | string |
|       | DireccionH   | string |
|       | CategoriaH   | int    |

#### Turista

| Llave | Nombre        | Tipo   |
| :---- | :------------ | :----- |
| PK    | IdT           | int    |
|       | NombreT       | string |
|       | NacionalidadT | string |

#### Oferta

| Llave | Nombre       | Tipo    |
| :---- | :----------- | :------ |
| FK    | IdH          | int     |
| PK    | IdO          | int     |
|       | PrecioO      | decimal |
|       | DescripcionO | string  |


#### Excursión

| Llave | Nombre        | Tipo     |
| :---- | :------------ | :------- |
| PK    | IdE           | int      |
|       | PrecioE       | decimal  |
|       | DescripcionE  | string   |
|       | FechaSalidaE  | DataTime |
|       | FechaLlegadaE | DataTime |
|       | LugarSalidaE  | string   |
|       | LugarLLegadaE | string   |

#### Paquete

| Llave | Nombre       | Tipo     |
| :---- | :----------- | :------- |
| PK    | CodigoP      | int      |
|       | DescripcionP | string   |
|       | PrecioP      | decimal  |
|       | DuracionP    | TimeSpan |

#### Facilidad
| Llave | Nombre       | Tipo   |
| :---- | :----------- | :----- |
| PK    | IdF          | int    |
|       | DescripcionF | string |

#### Reserva Excursión
| Llave | Nombre | Tipo |
| :---- | :----- | :--- |
| FK    | IdT    | int  |
| FK    | IdA    | int  |
| FK    | IdE    | int  |

#### Reserva Individual
| Llave | Nombre          | Tipo     |
| :---- | :-------------- | :------- |
| FK    | IdT             | int      |
| FK    | IdA             | int      |
| FK    | IdH             | int      |
| FK    | IdO             | int      |
|       | NumAcompanantes | int      |
|       | CompAereaRI     | string   |
|       | PrecioRI        | decimal  |
|       | FechaLlegadaH   | DataTime |
|       | FechaSalidaH    | DataTime |

#### Reserva Paquete
| Llave | Nombre            | Tipo     |
| :---- | :---------------- | :------- |
| FK    | IdA               | int      |
| FK    | IdT               | int      |
| FK    | CodigoP           | int      |
|       | CompAereaRP       | string   |
|       | FechaSalidaRP     | DataTime |
|       | CantParticipantes | int      |
|       | PrecioRP          | decimal  |

------

## Esquema con el diseño de la aplicación:

![](.\esquema.png)

------

## Esquema de las clases definidas:

```c#
//Entidades
public class Agencia {...}
public class Excursion {...}
public class Facilidad {...}
public class Hotel {...}
public class Oferta {...}
public class Paquete {...}
public class ReservaExcursion {...}
public class ReservaIndividual {...}
public class ReservaPaquete {...}
public class Turista {...}

//Repositorios
public class AgenciaRepository : IAgencia {...}
public class ExcursionRepository : IExcursion {...}
public class FacilidadRepository : IFacilidad {...}
public class HotelRepository : IHotel {...}
public class OfertaRepository : IOferta {...}
public class PaqueteRepository : IPaquete {...}
public class ReservaExcursionRepository : IReservaExcursion {...}
public class ReservaIndividualRepository : IReservaIndividual {...}
public class ReservaPaqueteRepository : IReservaPaquete {...}
public class TuristaRepository : ITurista {...}

//Clases Auxiliares
public class ExcursionExtendida {...}
public class GananciaAgencia {...}
public class PaqueteSobreMedida {...}
public class TuristaIndividualRepitente {...}

public class TravelWithUsDbContext : DbContext {...}
```

------

## Algo más:
A continuación, listaremos las tecnologías escogidas para resolver los detalles de implementación de nuestro software.\
 C# (C Sharp): Lenguaje de programación que forma parte de la plataforma .NET. Este es orientado a objeto y ofrece potentes herramientas para el desarrollo de software escalable y eficiente. Estaremos usándolo durante la mayor parte del desarrollo de este software. \
 Microsoft SQL Server: Es un gestor de base de datos relacionales, el cual utiliza como lenguaje de desarrollo Transact-SQL, una implementación del estándar ANSI del lenguaje SQL. Fue utilizado para resolver la persistencia de los datos que se manejan en nuestro software. Se escogió porque al ser de desarrollado por Microsoft ofrece muchas facilidades para integrarse con otras tecnologías de esta empresa, por ejemplo, .NET. \
 Entity Framework Core: Es un ORM (Object-Relational Mapping) incluido en el entorno .Net Core para relacionar las columnas de las tablas en las bases de datos con las propiedades de las clases en C#. Este ORM nos permitirá una comunicación eficaz, segura y de forma sencilla entre nuestras aplicaciones y las bases de datos utilizadas, pudiendo manejar todo tipo de consultas usando el mismo lenguaje de programación. \
 Angular: Framework basado en javascript utilizado para crear aplicaciones de una sola página (SPA por sus siglas en inglés). Este framework permite un trabajo escalado desarrollando componentes reusables, además de ser integrable con aplicaciones .NET a través del consumo de apis. \
 ASP.Net Core: Framework de desarrollo utilizado para el backend de nuestra aplicación. Altamente integrable con todas las tecnologías antes descritas. Además, posee características que facilitan mucho el desarrollo de software, como son sus múltiples opciones de despliegue, implementación muy efectiva de inyecciones de dependencias, implementación de un pipeline ligero y de alto rendimiento, entre muchas otras que lo hacen un framework muy deseado para el trabajo que nos proponemos desarrollar. 
