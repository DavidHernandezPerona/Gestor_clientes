# Gestor de Clientes

Aplicación de consola en C# para la gestión de clientes (CRUD completo), desarrollada como proyecto de portfolio con el stack tecnológico de C# y SQL Server.

## Descripción

Gestor de Clientes es una aplicación de línea de comandos que permite dar de alta, listar, modificar y eliminar clientes, con persistencia real en una base de datos SQL Server. El proyecto está estructurado en capas, separando el modelo de datos, el acceso a la base de datos y la interacción con el usuario.

## Tecnologías utilizadas

- **C# / .NET 8**
- **SQL Server** (motor de base de datos)
- **ADO.NET** (Microsoft.Data.SqlClient) para la conexión y ejecución de consultas
- **Git / GitHub** para control de versiones

## Funcionalidades

- **Alta de cliente**: registro de nuevos clientes con validación de datos (nombre, apellidos, teléfono y email obligatorios; formato de email validado).
- **Listado de clientes**: muestra todos los clientes registrados en la base de datos.
- **Modificación de cliente**: actualización de los datos de un cliente existente, localizado por su Id.
- **Baja de cliente**: eliminación de un cliente por su Id.
- **Manejo de errores**: la aplicación gestiona de forma controlada errores de formato de entrada, validaciones de datos y fallos de conexión con la base de datos, evitando que el programa se cierre inesperadamente.

## Estructura del proyecto

El proyecto sigue una arquitectura en capas:

- **`Cliente.cs`** — Modelo de datos. Clase con encapsulación completa (campos privados, propiedades con validación), constructor y sobreescritura de `ToString()`.
- **`ClienteRepositorio.cs`** — Capa de acceso a datos. Contiene toda la lógica de conexión y consultas a SQL Server mediante ADO.NET (Alta, Listado, Búsqueda, Modificación y Baja).
- **`Program.cs`** — Capa de presentación. Menú de consola interactivo que recoge la entrada del usuario y delega la lógica de negocio en `ClienteRepositorio`.
- **`tabla_clientes.sql`** — Script SQL para crear la base de datos y la tabla `Clientes`.

## Autor

David Hernández Perona
