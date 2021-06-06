# Manual de Usuario

## We Travel With Us

------

## Autores:

- Manuel Antonio Vilas Valiente 

  CI: 99022606760

- Penélope Seijo 

   CI: 99100207290

- Víctor Lantigua 

   CI: 94111031542

------

## Objetivos:

El presente proyecto tiene como objetivos principales la  modelación y el trabajo de los elementos más representativos de una agencia de viajes, brindando un sitio donde se pueda consultar cualquier información de la misma, además de la inclusión de nuevos datos sobre las diferentes ofertas que esta brinda. Para ello se ideó un entorno amistoso al usuario, en el cual este pudiera revisar toda los datos existentes sin dificultades.

------

## Requerimientos Técnicos:

El acceso al sitio estará mediado por un dispositivo con acceso a Internet (móviles, ordenadores, tabletas, etc).

Pensando en un correcto funcionamiento del sitio se sugiere que el servidor sea alojado en una computadora que posea los siguientes requerimientos mínimos:

- Memoria RAM: 8 Gb

- Disco Duro: 256 Gb

- Disponibilidad de conexión a una red

El sistema operativo recomendado:

- Windows 10
- Ubuntu 20.04

------

## Requerimientos de Software:

El acceso a la aplicación sólo exigirá un navegador de Internet (Firefox, Chrome, Edge, etc.), el cual permita acceder a la página web de nuestro sitio.

Será necesario tener instalado para el funcionamiento del servidor de la plataforma los siguientes softwares:

- SDK de .NET v5 o superior 
- NodeJs v14 o superior

------

## Cómo ejecutar?

Para poner a correr la aplicación será necesario encontrarse en la carpeta TravelWithUsApp que se encuentra en la carpeta raíz del proyecto, abrir una terminal en esta ruta y ejecutar el comando:

```asp
> ng serve 
```

------
## Comenzando a usar la aplicación:
Para iniciar una sesión de la Aplicación:  

- Abra su Navegador Web.
- Escriba la dirección (URL) de la aplicación en el espacio correspondiente a la misma. Ejemplo: http://localhost:4200 
-  Se mostrará la página de inicio de la aplicación como se observa en la imagen. Esta pagina posee una barra de navegación en la parte superior que le permitirá moverse directamente a la opción que desee.
- Además, posee un botón en la esquina superior derecha con la opción Reservar, y en la esquina superior izquierda un botón con forma de casa, en caso que esté navegando por algunas de las opciones, este último lo redireccionará hacia la pagina de inicio.


## Explicación de las opciones:

La aplicación propuesta cuenta con diversas opciones, las cuales proponen resolver los diferentes problemas indicados en los requerimientos, respondiendo a las consultas que se hagan a la base de datos. Tales consultas se hacen sobre los hoteles, turistas, agencias, excursiones, etc. 

#### Turistas:

![](.\turistas.png)


#### Hoteles:

![](.\hoteles.png)

#### Ofertas:

![](.\ofertas.png)

#### Reservas:

![](.\reservas.png)

------

## Botones de la barra de navegación

| Botón       | Descripción                                                  |
| ----------- | ------------------------------------------------------------ |
| Home        | Este botón nos enviará a la vista principal, donde se encuentra el carrusel de imágenes que describen de forma atractiva las opciones que brinda la aplicación. |
| Agencias    | Este nos conducirá a la página que muestra una tabla con toda la información que se tiene acerca de las agencias. |
| Hoteles     | Nos redirecciona a la vista donde se expone la tabla con la consulta sobre todos los hoteles que se utilizan en paquetes, además de una tabla con  todos los datos que se conocen sobre los hoteles. |
| Turistas    | Este nos posiciona en la vista donde se muestra la información requerida de los turistas, en este caso es la tabla con los turistas que han viajado más de una vez a Cuba, como también un tabla con todos los turistas. |
| Excursiones | El botón en cuestión nos envía a la vista donde se visualiza la tabla que nos indica todas las excursiones prolongadas, las cuales no son más que todas las excursiones que se brindan los fines de semana extendidos. Aquí también nos encontramos con una tabla donde todas las excursiones son expuestas. |
| Paquetes    | Nos redirige a la vista que muestra la tabla de los paquetes con un precio por encima del promedio y la tabla donde están todos los paquetes. |
| Ofertas     | El cual nos conducirá a la página que muestra la tabla con toda la información referente a las todas las ofertas. |
|             |                                                              |


## Botón del Administrador :

La opción Reservar nos redireccionará hacia una vista que posee varios campos a rellenar para escoger la agencia, la oferta y el turista que desea realizar la reserva. Estos campos poseen las opciones elegibles que se despliegan al tocar la flecha que contienen, estas opciones no son más que los datos que posee la base de datos de cada uno de estos campos, es decir todas las agencias, las ofertas y los turistas que están en el sistema. Al marcar una de estas opciones queda entonces visualizado como la opción seleccionada. 

Además, en esta vista se nos presenta la tabla con todas las reservas individuales que han sido efectuadas y la información que se tiene de ellas.




