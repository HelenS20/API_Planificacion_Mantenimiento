# API_Planificación_Mantenimiento
###  Descripción
API REST desarrollada en **ASP.NET Core Web API (.NET 8)** para calcular y registrar ciclos de mantenimiento de máquinas en una fábrica, según dos tipos de recurrencia:
- Por ciclos (tiempo)
- Por uso (ciclos impares)
###  Tecnologías utilizadas
- .NET 8
- ASP.NET Core Web API
- Entity Framework Core
- SQL Server Management Studio
- Swagger (Swashbuckle)
---
## Cómo ejecutar la prueba

1. Clonar el repositorio
2. Configurar la cadena de conexión en appsettings.json
3. Crear la base de datos en SQL Server o simplemente restaurar la base de datos desde backup :
   - Puedes crear la base de datos y la tabla ejecutando los siguientes scripts en SQL Server Management Studio o el repositorio incluye un archivo de respaldo (backup) de la base de          datos para facilitar la ejecución del proyecto. El archivo se llama `PruebaHBSolutions.bak`. No olvidar configurar la cadena de conexión en el archivo appsettings.json.:
     
     ```sql
      CREATE DATABASE PruebaHBSolutions;
      GO

      USE PruebaHBSolutions;
      GO

      CREATE TABLE mantenimientos (
          Id INT IDENTITY(1,1) PRIMARY KEY,
          CicloInicio INT NOT NULL,
          CicloFin INT NOT NULL,
          TipoRecurrencia VARCHAR(50) NOT NULL,
          Cada INT NOT NULL,
          Resultado NVARCHAR(MAX) NOT NULL,
          CreatedAt DATETIME NOT NULL DEFAULT GETDATE()
      );
     ```

4. Ejecutar: dotnet run por consola o por la inferfaz visual de Microsoft Visual Studio.
5. Abrir en el navegador: https://localhost:7030/swagger.
---
## Más información de la API 
* Endpoints
   1. POST /api/mantenimientos :Calcula y guarda un mantenimiento.
   2. GET /api/mantenimientos: Devuelve el historial registrado.
* Arquitectura: El proyecto está estructurado siguiendo principios SOLID:
   1. Controllers → manejo de requests
   2. Services → lógica de negocio
   3. Context → acceso a datos
   4. Models → separación de Request / Response / Entity
---
#### Autor: Helen Sanchez 
