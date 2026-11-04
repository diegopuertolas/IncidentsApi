# Práctica de preparación — API REST de incidencias informáticas

Tiempo orientativo: 2 horas de clase + trabajo autónomo
Objetivo: repasar los conceptos necesarios para desarrollar una API REST con ASP.NET Core, controladores, Git y LINQ.

Una empresa necesita una API REST para gestionar las incidencias informáticas comunicadas por sus empleados. La aplicación almacenará los datos en memoria, sin utilizar bases de datos.

## Ejercicios

### 1. Proyecto y Git

Crea un proyecto ASP.NET Core Web API utilizando controladores e inicializa un repositorio Git con un archivo .gitignore adecuado para .NET.

Desarrolla cada ejercicio del 2 al 9 en una rama independiente (feature/ejercicio-2, feature/ejercicio-3, etc.), realizando al menos un commit por rama e integrando sus cambios en main antes de comenzar el siguiente ejercicio.

### 2. Modelo de datos

Crea una clase Incidencia con las siguientes propiedades:

- Id (int)
- Titulo (string)
- Descripcion (string)
- TecnicoAsignado (string)
- FechaCreacion (DateTime)
- Prioridad (int)
- Estado (EstadoIncidencia)

Define el enumerado EstadoIncidencia con los valores Abierta, EnProceso y Resuelta.

### 3. Almacenamiento en memoria

Crea un controlador de incidencias con una colección estática List<Incidencia> inicializada con al menos tres incidencias diferentes.

### 4. Consulta de incidencias

Implementa los siguientes endpoints:

- GET /api/incidencias: devuelve todas las incidencias.
- GET /api/incidencias/{id}: devuelve una incidencia por su identificador o 404 Not Found si no existe.

### 5. Creación de incidencias

Implementa POST /api/incidencias para registrar una nueva incidencia.

El identificador se generará automáticamente, la fecha de creación será la fecha y hora actuales y el estado inicial será siempre Abierta, independientemente de los valores recibidos.

Devuelve 201 Created utilizando CreatedAtAction.

### 6. Modificación y eliminación
Implementa los siguientes endpoints:

- PUT /api/incidencias/{id}: permite modificar el título, la descripción, el técnico asignado y la prioridad, sin modificar el identificador, la fecha de creación ni el estado.
- DELETE /api/incidencias/{id}: elimina una incidencia existente.
Devuelve 204 No Content cuando la operación se complete correctamente y 404 Not Found cuando no exista.

### 7. Resolución de incidencias

Implementa PUT /api/incidencias/{id}/resolver para cambiar el estado de una incidencia a Resuelta.

- Si la incidencia no existe, devuelve 404 Not Found.
- Si ya está resuelta, devuelve 409 Conflict.
- Si se resuelve correctamente, devuelve 204 No Content.

### 8. Consultas con LINQ

Implementa los siguientes endpoints:

- GET /api/incidencias/prioritarias: devuelve las incidencias ordenadas por prioridad de mayor a menor. Incorpora un parámetro opcional [FromQuery] llamado cantidad, con valor predeterminado de 3, para limitar los resultados. Si la cantidad es menor o igual que cero, devuelve 400 Bad Request.
- GET /api/incidencias/buscar: permite buscar incidencias cuyo Titulo contenga el texto recibido mediante un parámetro [FromQuery] llamado texto, sin distinguir entre mayúsculas y minúsculas. Si no hay coincidencias, devuelve una lista vacía.

### 9. Validaciones

En las operaciones de creación y modificación, comprueba que:

- El título y la descripción no estén vacíos.
- La prioridad esté comprendida entre 1 y 5.
- Si alguna condición no se cumple, devuelve 400 Bad Request.

### 10. Pruebas

Comprueba mediante Postman o Swagger que funcionan los endpoints desarrollados.

Realiza pruebas de consulta, creación, modificación, eliminación, resolución y búsqueda, incluyendo también peticiones que produzcan errores HTTP.

### Indicaciones

- Puedes utilizar .NET 8 o .NET 10.
- Es obligatorio utilizar controladores, no Minimal API.
- Utiliza una colección estática en memoria.
- No es necesario implementar DTO, servicios, repositorios, bases de datos ni Entity Framework.
- Puedes consultar apuntes, documentación y ejercicios anteriores.
- Se recomienda completar primero el CRUD y después las operaciones específicas y las consultas LINQ.
