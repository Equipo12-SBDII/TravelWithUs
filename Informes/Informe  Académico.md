 # Informe  Académico 

## Introducción:

El producto brindará una solución computacional al desarrollo de un sitio que permita gestionar y analizar el comportamiento de diferentes agencias de viaje para mejorar el servicio a los clientes, y además permitirá que se efectué una reserva individual. 

---

## Análisis de Requerimientos:
Los requerimientos funcionales del producto son principalmente obtener datos de las agencias, en específico datos de los hoteles y las distintas ofertas de estos, de las excursiones, de los paquetes y de los turistas, estos requerimientos forman parte del módulo de gestión del sitio. Otro requerimiento funcional es poder efectuar una reserva individual con cualquiera de las agencias disponibles.

---

## Solución Propuesta:

Para el desarrollo de este sitio web, decidimos trabajar enfocados en una arquitectura N-Capas, específicamente con una arquitectura Onion. 
La Arquitectura conocida como Onion debido a la similitud de una cebolla con el diagrama de capas que se forma para definir la arquitectura está formada por:

- Núcleo de la aplicación: En esta capa se incluyen los modelos de negocio que incluyen a las entidades y los servicios . Estos modelos son abstracciones para las tareas que se deben ejecutar en la capa de la infraestructura. En el caso de nuestra aplicación esta capa representa la definición de los modelos que no son más que clases que serán usadas en la capa de la infraestructura para mapear con las entidades de nuestra base de datos relacional.

- Infraestructura: En esta capa usualmente se pone toda la lógica de acceso a datos. Aunque la implementación de esta capa puede ser muy variada, una de las formas más comunes es la que seguimos en nuestro proyecto. Usamos esta capa para representar el DbContext que el ORM EntityFramwork usa para realizar la conexión y configuración de la base de datos. También en esta capa plantemos las migraciones utilizadas para generar la base de datos a partir de los modelos definidos en el núcleo a través del DbContext. Otra característica incluida en esta capa es el uso del patrón Repository para agregar abstracción a nuestra infraestructura para cuando esta sea usada por la capa de la interfaz.

- UI: Esta capa es el punto de entrada de la aplicación, en cual se configura todo el proceso de resolución de peticiones. Esta capa no debe interactuar con la lógica de acceso a datos definida en la infraestructura, sino que debe interactuar con las interfaces y modelos definidos en la capa del núcleo de la aplicación y hacer uso de las abstracciones que provee la infraestructura a través del patrón Repository. En nuestra aplicación esta capa está representada como una api la cual configura su pipeline a través de la clase Startup e implementa las respuestas a las peticiones con endpoints llamados controladores. A esta capa también se le integran las vistas que en nuestro caso son tratadas como un cliente de la api.


---
## Resultados Obtenidos:

Producto de la realización del trabajo se obtuvo un sitio web capaz de cumplir con los ya planteados requerimientos. El proyecto responde a las exigencias impuestas, como son un modelo de base de datos correctamente elaborado y un eficaz uso de las herramientas necesarias para el desarrollo de nuestra aplicación.

#### Home

![](.\home.png)


------

#### Reservaciones

![](.\reservas.png)

## Conclusiones:

A modo de conclusiones se puede decir que, realizando un correcto uso y desarrollo conceptual de un modelo de
bases de datos, pues es casi seguro el desarrollo eficiente de un producto de alta calidad. Esto, sumado a la certera utilización de los elementos correspondientes a la ingeniería de software, los cuales constituyen un factor primordial en el desenvolvimiento de la aplicación, permitió que el resultado obtenido constituyera un trabajo acertado..

## Bibliografía:

C# 9 and .Net 5 Modern Cross-Platform Development 2020 , Mark J. Price.

Aspnet Tutorial.

Cursos online de www.w3schools.com de HTML, CCS, ASPNET y ANGULAR.
