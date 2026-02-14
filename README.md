# API_Planificación_Mantenimiento

Descripción: API REST desarrollada en ASP.NET Core Web API (.NET 8) para calcular y registrar ciclos de mantenimiento de máquinas en una fábrica, según dos tipos de recurrencia:
*Por ciclos (tiempo)
*Por uso (ciclos impares)
Los resultados se almacenan en una base de datos SQL Server.
Tecnologías utilizadas
*.NET 8
*ASP.NET Core Web API
*Entity Framework Core
*SQL Server Management Studio
*Swagger (Swashbuckle)

# Cómo ejecutar el proyecto

1. Clonar el repositorio
2. Configurar la cadena de conexión en appsettings.json
3. Crear la base de datos en SQL Server o simplemente restaurar la base de datos desde backup :
   - Puedes crear la base de datos y la tabla ejecutando los siguientes scripts en SQL Server Management Studio:
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
o el repositorio incluye un archivo de respaldo (backup) de la base de datos para facilitar la ejecución del proyecto. El archivo se llama PruebaHBSolutions.bak. No olvidar configurar la cadena de conexión en el archivo appsettings.json.

4. Ejecutar: dotnet run por consola o por la inferfaz visual de microsoft visual studio.
5. Abrir en el navegador:https://localhost:7030/swagger

# Más información de la API 
* Endpoints
 - POST /api/mantenimientos :Calcula y guarda un mantenimiento.
 - GET /api/mantenimientos: Devuelve el historial registrado.
* Arquitectura
El proyecto está estructurado siguiendo principios SOLID:
 - Controllers → manejo de requests
 - Services → lógica de negocio
 - Context → acceso a datos
 - Models → separación de Request / Response / Entity

# Autor: Helen Sanchez 😋
