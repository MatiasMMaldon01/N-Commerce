# N-Commerce

Esta aplicación de ventas es una solución desarrollada en .NET con el lenguaje de programación C# y utiliza Microsoft SQL Server como base de datos. 

Se ha implementado siguiendo una arquitectura en capas.Con patrón de repositorio genérico, unidad de trabajo y manejo de datos a traves de DTOs (Data Transfer Object).

## Características principales

* Gestión completa de ventas, incluyendo sistema de facturación y manejo de inventarios.

* Administración de clientes (con cuenta corriente), proveedores y productos.

* Registro de usuarios con roles y permisos.

* Registro y manejo de cajas.

## Tecnologías utilizadas

* .NET Framework: Plataforma de desarrollo para la creación de aplicaciones en entornos Windows con soporte para C#.
  
* C#: Lenguaje de programación orientado a objetos utilizado para el desarrollo de la lógica de negocio de la aplicación.
  
* Microsoft SQL Server: Sistema de gestión de bases de datos relacional utilizado para el almacenamiento persistente de los datos de la aplicación.
  
* Arquitectura en capas: Se ha seguido una arquitectura en capas para separar las responsabilidades y mejorar la modularidad y mantenibilidad del código.
  
* Patrón de repositorio genérico: Se ha implementado el patrón de repositorio genérico para abstraer el acceso a la base de datos y facilitar la reutilización del código.
  
* Unidad de trabajo: Se ha utilizado el patrón de unidad de trabajo para gestionar las transacciones y asegurar la consistencia de los datos en operaciones complejas.
  
* DTOs: En esta aplicación, se utiliza el patrón de transferencia de datos para facilitar el intercambio de datos entre las diferentes capas de la arquitectura. Los DTOs son objetos simples que contienen propiedades que representan los datos que se van a transferir.

## Estructura del proyecto

El proyecto está organizado en las siguientes capas:

* Capa de presentación (UI): Contiene la interfaz de usuario creada a través de formularios de Windows (WinForms).

* Capa de Servicios (Services): Gestiona la lógica de la aplicación, coordinando las interacciones entre la capa de presentación y la capa de dominio.

* Capa de dominio (Domain): Contiene las entidades y las interfaces del repositorio y unidad de trabajo.

* Capa de infraestructura (Infrastructure): Proporciona la implementación concreta de los repositorios, la unidad de trabajo y otros componentes de acceso a datos.


## Instalación y configuración
Para ejecutar la aplicación de ventas en tu entorno local, sigue estos pasos:

1) Clona este repositorio en tu máquina local.

2) Abre el proyecto en tu entorno de desarrollo preferido (por ejemplo, Visual Studio).

3) Configura la cadena de conexión a tu instancia de Microsoft SQL Server en el archivo de configuración de la capa de infraestructura.

4) Ejecuta el script de creación de la base de datos para crear las tablas y los datos iniciales.

5) Compila y ejecuta la aplicación.

### Contribución

Si deseas contribuir a este proyecto, puedes seguir los siguientes pasos:

1) Realiza un fork de este repositorio.

2) Crea una nueva rama con el nombre descriptivo de tu contribución.

3) Realiza los cambios y mejoras en tu rama.

4) Envía un pull request para revisar tus cambios.
