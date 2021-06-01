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

No sé a que se refiere.

------

## Esquema de las clases definidas:

Tampoco.

------

## Algo más:
A continuación, listaremos las tecnologías escogidas para resolver los detalles de implementación de nuestro software. 
•	C# (C Sharp)
•	Microsoft SQL Server 
•	Entity Framework Core
•	 Angular
•	 ASP.Net Core
 
